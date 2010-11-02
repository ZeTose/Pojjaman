Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptVatNotDueByDebtFilterSubPanel
        Inherits AbstractFilterSubPanel
        Implements IReportFilterSubPanel

#Region " Windows Form Designer generated code "

        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents KeepKeyCombo1 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.txtTemp = New System.Windows.Forms.TextBox()
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.KeepKeyCombo1 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.txtTemp)
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 0)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(472, 130)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "Incoming Vat Report"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(488, 142)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(104, 20)
            Me.txtTemp.TabIndex = 5
            Me.txtTemp.Visible = False
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.KeepKeyCombo1)
            Me.grbDocDate.Controls.Add(Me.chkIncludeChildren)
            Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(16, 16)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(440, 75)
            Me.grbDocDate.TabIndex = 1
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "Date"
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(112, 44)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 51
            Me.chkIncludeChildren.Text = "Include Sub CC:"
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(296, 18)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(93, 20)
            Me.txtDocDateEnd.TabIndex = 4
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(112, 18)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(92, 20)
            Me.txtDocDateStart.TabIndex = 1
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(16, 18)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "Start Date"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(264, 18)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "To"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 18)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(296, 18)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(381, 98)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 3
            Me.btnSearch.Text = "Find"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(293, 98)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 2
            Me.btnReset.Text = "Reset"
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Me.ErrorProvider1
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'KeepKeyCombo1
            '
            Me.KeepKeyCombo1.FormattingEnabled = True
            Me.KeepKeyCombo1.Location = New System.Drawing.Point(261, 139)
            Me.KeepKeyCombo1.Name = "KeepKeyCombo1"
            Me.KeepKeyCombo1.Size = New System.Drawing.Size(121, 21)
            Me.KeepKeyCombo1.TabIndex = 52
            '
            'RptVatNotDueByDebtFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "RptVatNotDueByDebtFilterSubPanel"
            Me.Size = New System.Drawing.Size(488, 138)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            Me.grbDocDate.ResumeLayout(False)
            Me.grbDocDate.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            ' Global text
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            ' Group box
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.grbDetail}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.grbDocDate}")
            'Checkbox
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.chkIncludeChildren}")
        End Sub
#End Region

#Region " Member "
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        Private m_SubmitalDateEnd As Date
        Private m_SubmitalDateStart As Date
        Private m_vatgstart As VatGroup
        Private m_vatgend As VatGroup
        Private m_cc As Costcenter
#End Region

#Region " Constructors "
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region " Properties "
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        Public Property SubmitalDateEnd() As Date            Get                Return m_SubmitalDateEnd            End Get            Set(ByVal Value As Date)                m_SubmitalDateEnd = Value            End Set        End Property        Public Property SubmitalDateStart() As Date            Get                Return m_SubmitalDateStart            End Get            Set(ByVal Value As Date)                m_SubmitalDateStart = Value            End Set        End Property
        Public Property Costcenter() As Costcenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As Costcenter)
                m_cc = Value
            End Set
        End Property
        Public Property VatGroupStart() As VatGroup            Get                Return m_vatgstart            End Get            Set(ByVal Value As VatGroup)                m_vatgstart = Value            End Set        End Property
        Public Property VatGroupEnd() As VatGroup            Get                Return m_vatgend            End Get            Set(ByVal Value As VatGroup)                m_vatgend = Value            End Set        End Property
#End Region

#Region " Methods "
        'Private Sub PopulateStatus()
        '    Dim baseDate As Date = AccountBaseDate.GetBaseDateFromDB() 'CDate(Configuration.GetConfig("BaseDate"))
        '    Dim years(9) As Date
        '    For i As Integer = 0 To 9
        '        years(i) = DateAdd(DateInterval.Year, i, baseDate)
        '    Next
        '    Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
        '    myDateTimeService.ListYearsInComboBox(Me.cmbYear, years)
        '    myDateTimeService.ListMonthsInComboBox(Me.cmbMonth, False, , False)
        'End Sub
        Private Sub Initialize()
            'PopulateStatus()
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()
            For Each grbCtrl As Control In grbDetail.Controls
                If TypeOf grbCtrl Is Pojjaman.Gui.Components.FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next

            Me.chkIncludeChildren.Checked = False

            Me.Costcenter = New CostCenter
            Me.VatGroupStart = New VatGroup
            Me.VatGroupEnd = New VatGroup

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.txtDocDateStart.Text = MinDateToNull(dtStart, "")
            Me.dtpDocDateStart.Value = dtStart
            Me.DocDateStart = dtStart

            Me.txtDocDateEnd.Text = MinDateToNull(Date.Now, "")
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.Now
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(3) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(3) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region " IReportFilterSubPanel "
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'Docdate Start
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateStart"
            dpi.Value = Me.txtDocDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate End
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateEnd"
            dpi.Value = Me.txtDocDateEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CheckBox ChildInclude
            If Me.chkIncludeChildren.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "childincluded"
                dpi.Value = "(รวมในสังกัด)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty Methods "
        Private Sub EventWiring()
            AddHandler dtpDocDateStart.ValueChanged, AddressOf ChangeProperty
            AddHandler txtDocDateStart.Validated, AddressOf ChangeProperty

            AddHandler dtpDocDateEnd.ValueChanged, AddressOf ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf ChangeProperty

        End Sub

        Private m_dateSetting As Boolean

        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower

                Case "dtpdocdatestart"
                    If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.DocDateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.DocDateStart = Date.MinValue
                    End If
                    m_dateSetting = False

                Case "dtpdocdateend"
                    If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.DocDateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.DocDateEnd = Date.MinValue
                    End If
                    m_dateSetting = False

                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' Costcenter
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccodestart", "txtcccodeend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            ' Costcenter
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercodestart"
                            'Me.SetCCCodeStartDialog(entity)

                        Case "txtcostcentercodeend"
                            'Me.SetCCCodeStartDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    '  myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub


#End Region

    End Class
End Namespace

