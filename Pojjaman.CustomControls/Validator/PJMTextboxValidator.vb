Option Strict Off
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
    <ProvideProperty("DataType", GetType(Control)), _
         ProvideProperty("DisplayName", GetType(Control)), _
         ProvideProperty("GotFocusBackColor", GetType(Control)), _
         ProvideProperty("InvalidBackColor", GetType(Control)), _
         ProvideProperty("MinValue", GetType(Control)), _
         ProvideProperty("MaxValue", GetType(Control)), _
         ProvideProperty("Required", GetType(Control)), _
         ProvideProperty("RegularExpression", GetType(Control))> _
    Public Class PJMTextboxValidator
        Inherits System.ComponentModel.Component
        Implements System.ComponentModel.IExtenderProvider

#Region " Component Designer generated code "

        Public Sub New(ByVal Container As System.ComponentModel.IContainer)
            MyClass.New()

            'Required for Windows.Forms Class Composition Designer support
            Container.Add(Me)
        End Sub

        Public Sub New()
            MyBase.New()

            'This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Component overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Component Designer
        'It can be modified using the Component Designer.
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
        End Sub

#End Region

#Region "IExtenderProvider"
        Public Function CanExtend(ByVal extendee As Object) As Boolean _
                  Implements System.ComponentModel.IExtenderProvider.CanExtend
            If TypeOf extendee Is TextBox Then
                Return True
            Else
                Return False
            End If
        End Function
#End Region

#Region "Member"
        Private m_ErrorProvider As ErrorProvider
        Private m_InvalidBackColor As Color = Color.Empty
        Private m_GotFocusBackColor As Color = Color.Empty
        Private m_BackcolorChanging As Boolean = False

        Private m_StringParserService As StringParserService

        Private m_dataTable As DataTable

        ' this hashtable holds property values for individual controls
        Friend htProvidedProperties As New Hashtable

        Private m_hasNewRow As Boolean

#End Region

#Region "Methods"
        Private Function GetAddControl(ByVal ctrl As Control) As TextboxValidatorProvidedProperties
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), TextboxValidatorProvidedProperties)
            Else
                ' add an element to the hashtable
                Dim ProvidedProperties As New TextboxValidatorProvidedProperties

                ProvidedProperties.OldBackColor = ctrl.BackColor

                htProvidedProperties.Add(ctrl, ProvidedProperties)

                ' Trap the Validating event and KeyUp events
                AddHandler ctrl.Validating, AddressOf ValidatingHandler
                AddHandler ctrl.TextChanged, AddressOf TextChangedHandler
                AddHandler ctrl.KeyUp, AddressOf CheckOnKeystrokeHandler
                Return ProvidedProperties
            End If
        End Function
        Public Sub TextChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
            Dim ctrl As Control
            ctrl = CType(sender, Control)
            ProcessError(ctrl)
        End Sub
        Private Sub ValidatingHandler(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

            ' Get the control to work with and the collection item associated
            ' with the control
            Dim ctrl As Control
            ctrl = CType(sender, Control)
            ProcessError(ctrl)
        End Sub

        Private Sub CheckOnKeystrokeHandler(ByVal sender As Object, ByVal e As KeyEventArgs)

            ' Get the control to work with and the collection item associated
            ' with the control
            Dim ctrl As Control
            ctrl = CType(sender, Control)
            ProcessError(ctrl)
        End Sub

        Public Sub ProcessError(ByVal ctrl As Control)
            Dim ctrlProperties As TextboxValidatorProvidedProperties
            ctrlProperties = CType(htProvidedProperties(ctrl), _
                             TextboxValidatorProvidedProperties)

            ' Fetch the error message - it may be empty, which means no error.
            Dim msg As String = GetErrorMessage(ctrl)

            If m_BackcolorChanging Then
                If msg.Length > 0 Then
                    If ctrlProperties.InvalidBackColor.Equals(Color.Empty) Then
                        ctrl.BackColor = m_InvalidBackColor
                    Else
                        ctrl.BackColor = ctrlProperties.InvalidBackColor
                    End If
                ElseIf ctrl.Focused Then
                    If ctrlProperties.GotFocusBackColor.Equals(Color.Empty) Then
                        ctrl.BackColor = m_GotFocusBackColor
                    Else
                        ctrl.BackColor = ctrlProperties.GotFocusBackColor
                    End If
                Else
                    ctrl.BackColor = ctrlProperties.OldBackColor
                End If
            End If

            ' Unconditionally set the Error message in the ErrorProvider.
            If Not Me.ErrorProvider Is Nothing Then
                Me.ErrorProvider.SetError(ctrl, msg)
            End If

        End Sub
        Public Function GetErrorMessage(ByVal ctrl As Control) As String
            ' This array is used to speed up validation against the _
            ' DataType property.
            ' IMPORTANT: its elements must match the ordering of DataTypeConstants
            ' in the enum defined at the end of this module.
            Static types() As Type = {GetType(String), GetType(Byte), _
              GetType(Int16), GetType(Int32), GetType(Int64), GetType(Single), _
              GetType(Double), GetType(Decimal), GetType(DateTime)}

            ' Get the set of provided properties for this control.
            Dim ProvidedProperties As TextboxValidatorProvidedProperties = _
                DirectCast(htProvidedProperties(ctrl), _
                TextboxValidatorProvidedProperties)

            ' Use either the DisplayName value or the control's name for messages
            Dim sDisplayName As String
            If ProvidedProperties.DisplayName = String.Empty Then
                sDisplayName = ctrl.Name
            Else
                sDisplayName = ProvidedProperties.DisplayName
            End If

            Dim value As String = ctrl.Text

            ' If Required is true and TextBox is empty, 
            ' then return validation error. If not required,
            ' it's OK to be empty, and don't check anything else.
            If value.Length = 0 Then
                If ProvidedProperties.Required Then
                    Return StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Components.Validator.RequiredMessage}") & " " & sDisplayName
                Else
                    ' if not required, return OK
                    Return String.Empty
                End If
            End If

            Dim valueType As Type = types(CInt(ProvidedProperties.DataType))

            ' Validate against the DataType property.
            Try
                'Attempt the conversion, return False if any exception.
                Dim o As Object = Convert.ChangeType(value, valueType)

                ' Additional validation for integer types. 
                Select Case ProvidedProperties.DataType
                    Case DataTypeConstants.ByteType, _
                         DataTypeConstants.Int16Type, _
                         DataTypeConstants.Int32Type, _
                         DataTypeConstants.Int64Type
                        If CDec(value) <> CLng(value) Then
                            Return sDisplayName & StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Components.Validator.MustBeIntegerMessage}")
                        End If
                End Select

            Catch ex As Exception
                Return sDisplayName & StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Components.Validator.InvalidTypeMessage}")
                'Return "**Entry in textbox " & sDisplayName & _
                '       " can't be converted to type " & valueType.Name & "**"
            End Try

            ' Validate against the RegularExpression property
            If ProvidedProperties.RegularExpression.Length > 0 Then
                ' Must enclose the regular expression between ^ and $
                If Not System.Text.RegularExpressions.Regex.IsMatch(value, "^" & _
                       ProvidedProperties.RegularExpression & "$") Then
                    Return sDisplayName & StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Components.Validator.RegExNotMatchMessage}")
                    '             Return "**Entry in textbox " & sDisplayName & _
                    '" doesn't match expected format**"
                End If
            End If

            ' validate against the MinValue and MaxValue property
            If ProvidedProperties.MinValue.Length > 0 Then
                ' perform type-agnostic comparison
                If Convert.ChangeType(value, valueType) < _
                   Convert.ChangeType(ProvidedProperties.MinValue, valueType) Then
                    Return sDisplayName & StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Components.Validator.TooLowMessage}")
                    'Return "**Entry in textbox " & sDisplayName & " is too low**"
                End If
            End If
            If ProvidedProperties.MaxValue.Length > 0 Then
                ' perform type-agnostic comparison
                If Convert.ChangeType(value, valueType) > _
                   Convert.ChangeType(ProvidedProperties.MaxValue, valueType) Then
                    Return sDisplayName & StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Components.Validator.TooHighMessage}")
                    'Return sDisplayName & " is greater than the maximum value of " & ProvidedProperties.MaxValue
                End If
            End If

            ' all tests passed
            Return String.Empty
        End Function
#End Region

#Region "Get - Set Property for control"

        ' รับค่าประเภทข้อมูลที่ป้อนลงใน control
        Function GetDataType(ByVal ctrl As Control) As DataTypeConstants
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       TextboxValidatorProvidedProperties).DataType
            Else
                Return DataTypeConstants.StringType
            End If
        End Function

        ' ตั้งค่าประเภทข้อมูลที่ป้อนลงใน control
        Sub SetDataType(ByVal ctrl As Control, ByVal value As DataTypeConstants)
            AddHandler CType(ctrl, TextBox).GotFocus, AddressOf ControlGotFocusHandler
            AddHandler CType(ctrl, TextBox).LostFocus, AddressOf ControlLostFocusHandler
            GetAddControl(ctrl).DataType = value
            Select Case value
                Case DataTypeConstants.DecimalType, DataTypeConstants.DoubleType, DataTypeConstants.SingleType
                    ' ทำการดัก Event KeyPress ของ control แล้วให้ทำงานที่ DecimalKeyPressHandler
                    AddHandler ctrl.KeyPress, AddressOf DecimalKeyPressHandler
                Case DataTypeConstants.Int16Type, DataTypeConstants.Int32Type, DataTypeConstants.Int64Type
                    ' ทำการดัก Event KeyPress ของ control แล้วให้ทำงานที่ IntegerKeyPressHandler
                    AddHandler ctrl.KeyPress, AddressOf IntegerKeyPressHandler
            End Select

        End Sub

        ' รับค่า RegularExpression ของ control
        Function GetRegularExpression(ByVal ctrl As Control) As String
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       TextboxValidatorProvidedProperties).RegularExpression
            Else
                Return String.Empty
            End If
        End Function

        ' ตั้งค่า RegularExpression ของ control
        Sub SetRegularExpression(ByVal ctrl As Control, ByVal value As String)
            If value Is Nothing Then value = ""
            GetAddControl(ctrl).RegularExpression = value
        End Sub

        ' รับค่าต่ำสุดที่ยอมให้ป้อนลงใน control
        Function GetMinValue(ByVal ctrl As Control) As String
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       TextboxValidatorProvidedProperties).MinValue
            Else
                Return String.Empty
            End If
        End Function

        ' ตั้งค่าต่ำสุดที่ยอมให้ป้อนลงใน control
        Sub SetMinValue(ByVal ctrl As Control, ByVal value As String)
            If value Is Nothing Then value = String.Empty
            GetAddControl(ctrl).MinValue = value
        End Sub

        ' รับค่าสูงสุดที่ยอมให้ป้อนลงใน control
        Function GetMaxValue(ByVal ctrl As Object) As String
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       TextboxValidatorProvidedProperties).MaxValue
            Else
                Return String.Empty
            End If
        End Function

        ' ตั้งค่าสูงสุดที่ยอมให้ป้อนลงใน control
        Sub SetMaxValue(ByVal ctrl As Control, ByVal value As String)
            If value Is Nothing Then value = String.Empty
            GetAddControl(ctrl).MaxValue = value
        End Sub

        ' รับค่าความต้องการป้อนข้อมูลของ control
        Function GetRequired(ByVal ctrl As Control) As Boolean
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       TextboxValidatorProvidedProperties).Required
            Else
                Return False
            End If
        End Function

        ' ตั้งค่าความต้องการป้อนข้อมูลของ control
        Sub SetRequired(ByVal ctrl As Control, ByVal value As Boolean)
            GetAddControl(ctrl).Required = value
        End Sub

        ' รับค่าชื่อที่ต้องการให้แสดงของ control
        Function GetDisplayName(ByVal ctrl As Control) As String
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       TextboxValidatorProvidedProperties).DisplayName
            Else
                Return String.Empty
            End If
        End Function

        ' ตั้งค่าชื่อที่ต้องการให้แสดงของ control
        Sub SetDisplayName(ByVal ctrl As Control, ByVal value As String)
            If value Is Nothing Then value = String.Empty
            GetAddControl(ctrl).DisplayName = value
        End Sub

        ' รับค่าสีพื้นหลังให้กับ control ในกรณีที่ Invalid
        Function GetInvalidBackColor(ByVal ctrl As Control) As Color
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       TextboxValidatorProvidedProperties).InvalidBackColor
            Else
                Return Color.Empty
            End If
        End Function

        ' ตั้งค่าสีพื้นหลังให้กับ control ในกรณีที่ Invalid
        Sub SetInvalidBackColor(ByVal ctrl As Control, ByVal value As Color)
            GetAddControl(ctrl).InvalidBackColor = value
        End Sub

        ' รับค่าสีพื้นหลังให้กับ control ในกรณีที่ GotFocus
        Function GetGotFocusBackColor(ByVal ctrl As Control) As Color
            If htProvidedProperties.Contains(ctrl) Then
                Return DirectCast(htProvidedProperties(ctrl), _
                       TextboxValidatorProvidedProperties).GotFocusBackColor
            Else
                Return Color.Empty
            End If
        End Function

        ' ตั้งค่าสีพื้นหลังให้กับ control ในกรณีที่ GotFocus
        Sub SetGotFocusBackColor(ByVal ctrl As Control, ByVal value As Color)
            GetAddControl(ctrl).GotFocusBackColor = value
        End Sub

        Function GetOldBackColor(ByVal ctrl As Control) As Color
            If htProvidedProperties.Contains(ctrl) Then
                If TypeOf ctrl Is TextBox AndAlso (CType(ctrl, TextBox).ReadOnly Or Not CType(ctrl, TextBox).Enabled) Then
                    Return SystemColors.Control
                End If
                Return DirectCast(htProvidedProperties(ctrl), _
                       TextboxValidatorProvidedProperties).OldBackColor
            Else
                Return Color.Empty
            End If
        End Function
#End Region

#Region "Property"

        <Description("The control used to display an icon and a validation error message for invalid controls")> _
        Public Property ErrorProvider() As ErrorProvider
            Get
                Return m_ErrorProvider
            End Get
            Set(ByVal Value As ErrorProvider)
                m_ErrorProvider = Value
            End Set
        End Property

        <Description("Back Color for invalid data")> _
        Public Property InvalidBackColor() As Color
            Get
                Return m_InvalidBackColor
            End Get
            Set(ByVal Value As Color)
                m_InvalidBackColor = Value
            End Set
        End Property

        <Description("Back Color for gotfocus control")> _
        Public Property GotFocusBackColor() As Color
            Get
                Return m_GotFocusBackColor
            End Get
            Set(ByVal Value As Color)
                m_GotFocusBackColor = Value
            End Set
        End Property

        <Description("Can the BackColor be changed?")> _
        Public Property BackcolorChanging() As Boolean            Get                Return m_BackcolorChanging            End Get            Set(ByVal Value As Boolean)                m_BackcolorChanging = Value            End Set        End Property
        <Browsable(False)> _
        Public Property DataTable() As DataTable
            Get
                Return m_dataTable
            End Get
            Set(ByVal Value As DataTable)
                m_dataTable = Value
            End Set
        End Property

        <Browsable(False)> _
        Public ReadOnly Property StringParserService() As StringParserService
            Get
                If m_StringParserService Is Nothing Then
                    m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                End If
                Return m_StringParserService
            End Get
        End Property
        <Browsable(False)> _
        Public ReadOnly Property InvalidMessages() As ArrayList
            Get
                Dim sMessage As String
                Dim sControlError As String
                Dim ctrl As Control
                Dim colInvalidMessages As New SortedList

                ' Loop through controls and find which ones are invalid.
                ' Get the invalid message for each.
                ' Stuff the messages into a SortedList 
                ' using the TabOrder for the control to 
                ' establish the correct order.
                For Each ctrl In htProvidedProperties.Keys
                    sMessage = GetErrorMessage(ctrl)
                    If Not sMessage = String.Empty Then
                        'If Not ctrl.FindForm Is Nothing Then
                        '    sMessage &= ":" & ctrl.FindForm.Name
                        'End If
                        Try
                            colInvalidMessages.Add(ctrl.TabIndex, sMessage)
                        Catch ex As Exception
                        End Try
                    End If
                Next

                Dim colErrorsByIndex As New ArrayList
                Dim obj As Object
                For Each obj In colInvalidMessages.Values
                    sMessage = CType(obj, String)
                    colErrorsByIndex.Add(sMessage)
                Next
                Return colErrorsByIndex
            End Get
        End Property
        <Browsable(False)> _
        Public Property HasNewRow() As Boolean            Get                Return m_hasNewRow            End Get            Set(ByVal Value As Boolean)                m_hasNewRow = Value            End Set        End Property
        <Browsable(False)> Public ReadOnly Property ValidationSummary() As String
            Get
                Dim sMessage As String
                Dim sControlError As String
                Dim ctrl As Control
                Dim colInvalidMessages As ArrayList

                ' Get invalid messages ordered by TabOrder of controls
                colInvalidMessages = Me.InvalidMessages

                ' Append together to get a complete summary. 
                ' Messages are separated by carriage return - line feeds.
                Dim ctlIndex As Object
                For Each ctlIndex In colInvalidMessages
                    Dim sThisMessage As String
                    sThisMessage = CType(ctlIndex, String)

                    If Len(sThisMessage) > 0 Then
                        If Len(sMessage) > 0 Then
                            sMessage &= vbCrLf
                        End If
                        sMessage &= " - " & sThisMessage
                    End If
                Next

                Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                Dim nameChangedError As String = myStringParserService.Parse("${res:Global.Error.NameChanged}")
                If Not m_dataTable Is Nothing AndAlso m_dataTable.HasErrors Then
                    For Each row As DataRow In Me.DataTable.GetErrors
                        For Each col As DataColumn In row.GetColumnsInError
                            If Not row.GetColumnError(col).StartsWith(nameChangedError) Then
                                Dim sThisMessage As String
                                sThisMessage = row.GetColumnError(col)
                                If Len(sMessage) > 0 Then
                                    sMessage &= vbCrLf
                                End If
                                sMessage &= " - " & sThisMessage & ":" & col.Caption
                            End If
                        Next
                    Next
                End If

                If m_hasNewRow Then
                    sMessage &= " - " & Me.StringParserService.Parse("${res:Global.Error.GridHasNewLine}")
                End If

                Return sMessage

            End Get
        End Property
#End Region

#Region "Event for control"
        ' ตรวจสอบการคีย์ตัวเลขจำนวนเต็ม
        Private Sub IntegerKeyPressHandler(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            ' ตรวจสอบก่อนว่าตัวที่กำลังคีย์นั้นเป็นตัวเลขหรือไม่
            If e.KeyChar.IsDigit(e.KeyChar) Then
                Exit Sub
            End If

            Dim ctrl As TextBox
            ctrl = CType(sender, TextBox)

            Select Case e.KeyChar.ToString
                'เป็นจำนวนเต็มลบได้ คือมีเครื่องหมายลบอยู่หน้าสุดได้เท่านั้น
            Case "-"
                    If ctrl.SelectionStart = 0 Then
                        ' ต้องยังไม่มีเครื่องหมายลบอยู่ก่อนหน้า ถ้าจะคีย์เป็นจำนวนลบ
                        If InStr(ctrl.Text, "-") = 0 Then
                            Exit Sub
                        End If
                    End If

                    ' ถ้าเป็นการคีย์ปุ่มดังกล่าวนี้ ก็สามารถคีย์ได้
                Case vbCr, vbLf, vbTab, Chr(8), Chr(22), Chr(24), Chr(3)
                    ' Carriage return, Line feed, tab, Backspace, Paste, cut, copy
                    Exit Sub

            End Select

            e.Handled = True
        End Sub

        ' ตรวจสอบคีย์ตัวเลขทศนิยม
        Private Sub DecimalKeyPressHandler(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            ' ตรวจสอบก่อนว่าตัวที่กำลังคีย์นั้นเป็นตัวเลขหรือไม่
            If e.KeyChar.IsDigit(e.KeyChar) Then
                Exit Sub
            End If

            Dim ctrl As TextBox
            ctrl = CType(sender, TextBox)

            Select Case e.KeyChar.ToString
                'เป็นจำนวนลบได้ คือมีเครื่องหมายลบอยู่หน้าสุดได้เท่านั้น
            Case "-"
                    If ctrl.SelectionStart = 0 Then
                        ' ต้องยังไม่มีเครื่องหมายลบอยู่ก่อนหน้า ถ้าจะคีย์เป็นจำนวนลบ
                        If InStr(ctrl.Text, "-") = 0 Then
                            Exit Sub
                        End If
                    End If

                    ' มีจุดทศนิยมได้
                Case "."
                    ' ถ้าจะคีย์จุดทศนิยม ต้องไม่มีจุดทศนิยมอยู่ก่อนหน้า
                    If InStr(ctrl.Text, ".") = 0 Then
                        Exit Sub
                    End If

                    ' ถ้าเป็นการคีย์ปุ่มดังกล่าวนี้ ก็สามารถคีย์ได้
                Case vbCr, vbLf, vbTab, Chr(8), Chr(22), Chr(24), Chr(3)
                    ' Carriage return, Line feed, tab, Backspace, Paste, cut, copy
                    Exit Sub

            End Select

            e.Handled = True
        End Sub

        Private Sub ControlGotFocusHandler(ByVal sender As Object, ByVal e As EventArgs)
            Dim ctrl As TextBox
            ctrl = CType(sender, TextBox)
            If m_BackcolorChanging Then
                ctrl.BackColor = m_GotFocusBackColor
                ctrl.Invalidate()
            End If

        End Sub

        Private Sub ControlLostFocusHandler(ByVal sender As Object, ByVal e As EventArgs)
            Dim ctrl As TextBox
            ctrl = CType(sender, TextBox)
            If m_BackcolorChanging Then
                ctrl.BackColor = Me.GetOldBackColor(ctrl)
                ctrl.Invalidate()
            End If
        End Sub
#End Region

        Private Class TextboxValidatorProvidedProperties
            Public DataType As DataTypeConstants
            Public RegularExpression As String = String.Empty
            Public MinValue As String = String.Empty
            Public MaxValue As String = String.Empty
            Public Required As Boolean = False
            Public DisplayName As String
            Public InvalidBackColor As Color = Color.Empty
            Public GotFocusBackColor As Color = Color.Empty
            Public OldBackColor As Color = Color.Empty
        End Class

    End Class

    Public Enum DataTypeConstants
        StringType
        ByteType
        Int16Type
        Int32Type
        Int64Type
        SingleType
        DoubleType
        DecimalType
        DateTimeType
    End Enum
End Namespace


