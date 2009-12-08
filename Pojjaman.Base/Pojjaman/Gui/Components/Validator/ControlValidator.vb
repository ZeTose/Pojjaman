Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Namespace Pojjaman.UI.Validator
    <ProvideProperty("RequiredField", GetType(Control)), _
    ProvideProperty("ErrorColor", GetType(Control)), _
    ProvideProperty("CustomRegularExpression", GetType(Control)), _
    ProvideProperty("RegularExpression", GetType(Control))> _
    Public Class ControlValidator
        Inherits System.ComponentModel.Component
        Implements IExtenderProvider

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

#Region "Members"
        '-- We will use a Hashtable to hold a class containing each
        '-- property we want to validate for each text box
        Friend htTextProps As New Hashtable
        Dim m_isEnabled As Boolean = True  'enable or disable textvalidator
#End Region

#Region "IExtenderProvider implementation"
        '------------------------------------------------------------------
        '-- Extend the additional validation properties only to text boxes
        '------------------------------------------------------------------
        Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
            If TypeOf extendee Is TextBox Then
                '-- Add the control to the hash table
                addPropertyValue(CType(extendee, Control))
                addPropertyValue(CType(extendee, Control)).validColor = CType(extendee, Control).BackColor
                Return True
            Else
                Return False
            End If
        End Function
#End Region

#Region "Properties"
        '------------------------------------------------------------
        '-- These are the public properties that will be shown 
        '-- in the Properties window of the TextValidator control
        '-------------------------------------------------------------
        <Description("Enable validation on all TextBox controls?"), _
        Category("Extended Validation"), DefaultValue(False)> _
        Public Property Enabled() As Boolean
            Get
                Return m_isEnabled
            End Get
            Set(ByVal Value As Boolean)
                m_isEnabled = Value
            End Set
        End Property
#End Region

#Region "GetPROPERTYNAME & SetPROPERTYNAME"
        '--------------------------------------------------------------------
        '-- These are the GetPROPERTYNAME and SetPROPERTYNAME properties 
        '-- that will be extended to all legit controls (Textboxes in this 
        '-- case)
        '--------------------------------------------------------------------
        <Description("Is this a required field?"), _
        Category("Extended Validation"), DefaultValue(False)> _
        Function GetRequiredField(ByVal ctrl As Control) As Boolean
            If htTextProps.Contains(ctrl) Then
                Return CType(htTextProps(ctrl), TextExtendedProperties).Required
            Else
                Return False
            End If
        End Function
        Sub SetRequiredField(ByVal ctrl As Control, ByVal value As Boolean)
            addPropertyValue(ctrl).Required = value
        End Sub

        <Description("Background color on Invalid entry."), _
        Category("Extended Validation"), DefaultValue(GetType(Color), "White")> _
        Function GetErrorColor(ByVal ctrl As Control) As System.Drawing.Color
            If htTextProps.Contains(ctrl) Then
                Return CType(htTextProps(ctrl), TextExtendedProperties).errColor
            Else
                Return System.Drawing.Color.White
            End If
        End Function

        Sub SetErrorColor(ByVal ctrl As Control, _
            ByVal value As System.Drawing.Color)
            addPropertyValue(ctrl).errColor = value
        End Sub

        <Description("A Validated Entry"), Category("Extended Validation"), _
        DefaultValue(GetType(ValidateStrings), "None")> _
        Function GetRegularExpression(ByVal ctrl As Control) As ValidateStrings
            If htTextProps.Contains(ctrl) Then
                Return CType(htTextProps(ctrl), TextExtendedProperties).regularExp
            Else
                Return ValidateStrings.None
            End If
        End Function

        Sub SetRegularExpression(ByVal ctrl As Control, _
            ByVal value As ValidateStrings)
            If value <> ValidateStrings.None Then
                SetCustomRegularExpression(ctrl, "")
            End If
            addPropertyValue(ctrl).regularExp = value
        End Sub

        <Description("A Custom Validated Entry"), Category("Extended Validation"), _
        DefaultValue("")> _
        Function GetCustomRegularExpression(ByVal ctrl As Control) As String
            If htTextProps.Contains(ctrl) Then
                Return CType(htTextProps(ctrl), TextExtendedProperties).customRegularExp
            Else
                Return String.Empty
            End If
        End Function

        Sub SetCustomRegularExpression(ByVal ctrl As Control, _
            ByVal value As String)
            If GetRegularExpression(ctrl) <> ValidateStrings.None Then
                value = ""
            End If
            addPropertyValue(ctrl).customRegularExp = value
        End Sub
#End Region

#Region "Helper Methods"
        Private Function addPropertyValue(ByVal ctrl As Control) _
        As TextExtendedProperties
            '-- If the TextExtendedProperties class for the text box in question
            '-- is in the hash table, return it to the caller.
            If htTextProps.Contains(ctrl) Then
                Return CType(htTextProps(ctrl), TextExtendedProperties)
            Else
                '-- If the TextExtendedProperties class is not in the
                '—hash table for this control, then add it.
                Dim tbProperties As New TextExtendedProperties
                htTextProps.Add(ctrl, tbProperties)
                '-- We register a handler (i.e., listener) to trap the
                '-- validating event of each textbox we are validating
                AddHandler ctrl.Validating, AddressOf tbValidateHandler
                AddHandler ctrl.MouseHover, AddressOf Ctrl_MouseHover
                'AddHandler ctrl.MouseLeave, AddressOf Ctrl_MouseLeave
                '-- Return the TextExtendedProperties class to the caller
                '-- so the relevant property can be set.
                Return tbProperties
            End If
        End Function
        Private Sub tbValidateHandler(ByVal sender As Object, ByVal e As _
            System.ComponentModel.CancelEventArgs)
            '-- Ignore validation if the TextValidator control is disabled.
            If m_isEnabled = False Then Exit Sub
            '-- Determine the control to be validated
            Dim ctrl As Control = CType(sender, Control)
            '-- Validate
            Dim errorMsg As String = ValidateProps(ctrl)

            If errorMsg <> String.Empty Then
                Dim g As Graphics = ctrl.CreateGraphics
                e.Cancel = True
                'Dim bl As New MyBalloonWindow
                'bl.SuspendLayout()
                'Dim tb As New TextBox
                'tb.Text = errorMsg
                'tb.Size = New Size(100, 20)
                'tb.Location = New System.Drawing.Point(20, 50)
                'bl.Controls.Add(tb)
                'bl.Size = New Size(200, 100)
                'bl.CloseBox = False
                'bl.Timeout = 2000

                'addPropertyValue(ctrl).balloon = bl
                'MessageBox.Show(errorMsg, "Validation Error", _
                'MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                'addPropertyValue(ctrl).balloon = Nothing
            End If
        End Sub

        Private Sub Ctrl_MouseHover(ByVal sender As Object, ByVal e As EventArgs)
            'Dim ctrl As Control = CType(sender, Control)
            'Dim bl As MyBalloonWindow = CType(htTextProps(ctrl), TextExtendedProperties).balloon
            'If Not IsNothing(bl) Then
            '    Try
            '        bl.Show(ctrl)
            '        bl.TargetControl = ctrl
            '        bl.MoveWithTarget = True
            '        ctrl.Focus()
            '    Catch ex As Exception

            '    End Try
            'End If
        End Sub
        Private Function ValidateProps(ByVal ctrl As Control) As String
            '-- Extract the class from the hash table and evaluate the properties 
            Dim props As TextExtendedProperties = CType(htTextProps(ctrl), _
               TextExtendedProperties)
            If props.Required Then
                If ctrl.Text.Length < 1 Then
                    ctrl.BackColor = props.errColor
                    Return "This field requires an entry."
                End If
            End If
            '-- User set a regular expression --
            If props.regularExp <> ValidateStrings.None Then
                Select Case props.regularExp
                    Case ValidateStrings.USPhone
                        Dim rRegex As New _
                            Regex("((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")
                        Dim mMatch As Match = rRegex.Match(ctrl.Text)
                        If Not mMatch.Success Then
                            ctrl.BackColor = props.errColor
                            Return "This field requires a valid phone number."
                        End If
                    Case ValidateStrings.SocialSecurity
                        Dim rRegex As New Regex("\d{3}-\d{2}-\d{4}")
                        Dim mMatch As Match = rRegex.Match(ctrl.Text)
                        If Not mMatch.Success Then
                            ctrl.BackColor = props.errColor
                            Return "This field requires a Social Security Number."
                        End If
                    Case ValidateStrings.ZipCode
                        Dim rRegex As New Regex("\d{5}(-\d{4})?")
                        Dim mMatch As Match = rRegex.Match(ctrl.Text)
                        If Not mMatch.Success Then
                            ctrl.BackColor = props.errColor
                            Return "This field requires a valid Zip Code."
                        End If
                    Case ValidateStrings.URL
                        Dim rRegex As New Regex("http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?")
                        Dim mMatch As Match = rRegex.Match(ctrl.Text)
                        If Not mMatch.Success Then
                            ctrl.BackColor = props.errColor
                            Return "This field requires a valid Web address."
                        End If
                    Case ValidateStrings.InternetEmail
                        Dim rRegex As New _
                            Regex("\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                        Dim mMatch As Match = rRegex.Match(ctrl.Text)
                        If Not mMatch.Success Then
                            ctrl.BackColor = props.errColor
                            Return "This field requires a valid email address."
                        End If
                    Case ValidateStrings.Numeric
                        If Not IsNumeric(ctrl.Text) Then
                            ctrl.BackColor = props.errColor
                            Return "This field requires a valid numeric data."
                        End If
                End Select
            Else
                Dim rRegex As New Regex(props.customRegularExp)
                Dim mMatch As Match = rRegex.Match(ctrl.Text)
                If Not mMatch.Success Then
                    ctrl.BackColor = props.errColor
                    Return "This field requires a valid entry."
                End If
            End If

            '-- Validation successful --
            ctrl.BackColor = props.validColor
            Return String.Empty

        End Function
#End Region

    End Class

    '-- This class will be created for each text box that
    '-- will have extended properties. An instance of this
    '-- class will be placed in the hash table htTextProps
    Class TextExtendedProperties
        Public Required As Boolean
        Public errColor As Drawing.Color
        Public validColor As Drawing.Color
        Public regularExp As ValidateStrings
        Public customRegularExp As String
        'Public balloon As MyBalloonWindow
    End Class

    Public Enum ValidateStrings
        None
        USPhone
        SocialSecurity
        ZipCode
        URL
        InternetEmail
        Numeric
    End Enum
End Namespace
