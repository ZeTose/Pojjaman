Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptGLStatementBalanceSheetFilterSubPanel
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
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
        Friend WithEvents lblAccountStart As System.Windows.Forms.Label
        Friend WithEvents lblYear As System.Windows.Forms.Label
        Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
        Friend WithEvents btnAccountEnd As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAccountEnd As System.Windows.Forms.TextBox
        Friend WithEvents btnAccountStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAccountStart As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptGLStatementBalanceSheetFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblYear = New System.Windows.Forms.Label
            Me.cmbYear = New System.Windows.Forms.ComboBox
            Me.btnAccountEnd = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtAccountEnd = New System.Windows.Forms.TextBox
            Me.lblAccountEnd = New System.Windows.Forms.Label
            Me.btnAccountStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtAccountStart = New System.Windows.Forms.TextBox
            Me.lblAccountStart = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 0)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(432, 128)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.lblYear)
            Me.grbDetail.Controls.Add(Me.cmbYear)
            Me.grbDetail.Controls.Add(Me.btnAccountEnd)
            Me.grbDetail.Controls.Add(Me.txtAccountEnd)
            Me.grbDetail.Controls.Add(Me.lblAccountEnd)
            Me.grbDetail.Controls.Add(Me.btnAccountStart)
            Me.grbDetail.Controls.Add(Me.txtAccountStart)
            Me.grbDetail.Controls.Add(Me.lblAccountStart)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(400, 72)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'lblYear
            '
            Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblYear.ForeColor = System.Drawing.Color.Black
            Me.lblYear.Location = New System.Drawing.Point(8, 16)
            Me.lblYear.Name = "lblYear"
            Me.lblYear.Size = New System.Drawing.Size(88, 18)
            Me.lblYear.TabIndex = 0
            Me.lblYear.Text = "เรียงตาม"
            Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbYear
            '
            Me.cmbYear.Location = New System.Drawing.Point(104, 16)
            Me.cmbYear.Name = "cmbYear"
            Me.cmbYear.Size = New System.Drawing.Size(120, 21)
            Me.cmbYear.TabIndex = 1
            '
            'btnAccountEnd
            '
            Me.btnAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEnd.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountEnd.Image = CType(resources.GetObject("btnAccountEnd.Image"), System.Drawing.Image)
            Me.btnAccountEnd.Location = New System.Drawing.Point(360, 40)
            Me.btnAccountEnd.Name = "btnAccountEnd"
            Me.btnAccountEnd.Size = New System.Drawing.Size(24, 22)
            Me.btnAccountEnd.TabIndex = 7
            Me.btnAccountEnd.TabStop = False
            Me.btnAccountEnd.ThemedImage = CType(resources.GetObject("btnAccountEnd.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountEnd
            '
            Me.Validator.SetDataType(Me.txtAccountEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountEnd, "")
            Me.txtAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountEnd, System.Drawing.Color.Empty)
            Me.txtAccountEnd.Location = New System.Drawing.Point(264, 40)
            Me.Validator.SetMaxValue(Me.txtAccountEnd, "")
            Me.Validator.SetMinValue(Me.txtAccountEnd, "")
            Me.txtAccountEnd.Name = "txtAccountEnd"
            Me.Validator.SetRegularExpression(Me.txtAccountEnd, "")
            Me.Validator.SetRequired(Me.txtAccountEnd, False)
            Me.txtAccountEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtAccountEnd.TabIndex = 6
            Me.txtAccountEnd.Text = ""
            '
            'lblAccountEnd
            '
            Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
            Me.lblAccountEnd.Location = New System.Drawing.Point(232, 40)
            Me.lblAccountEnd.Name = "lblAccountEnd"
            Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblAccountEnd.TabIndex = 5
            Me.lblAccountEnd.Text = "ถึง"
            Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnAccountStart
            '
            Me.btnAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountStart.Image = CType(resources.GetObject("btnAccountStart.Image"), System.Drawing.Image)
            Me.btnAccountStart.Location = New System.Drawing.Point(200, 40)
            Me.btnAccountStart.Name = "btnAccountStart"
            Me.btnAccountStart.Size = New System.Drawing.Size(24, 22)
            Me.btnAccountStart.TabIndex = 4
            Me.btnAccountStart.TabStop = False
            Me.btnAccountStart.ThemedImage = CType(resources.GetObject("btnAccountStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountStart
            '
            Me.Validator.SetDataType(Me.txtAccountStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountStart, "")
            Me.txtAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountStart, System.Drawing.Color.Empty)
            Me.txtAccountStart.Location = New System.Drawing.Point(104, 40)
            Me.Validator.SetMaxValue(Me.txtAccountStart, "")
            Me.Validator.SetMinValue(Me.txtAccountStart, "")
            Me.txtAccountStart.Name = "txtAccountStart"
            Me.Validator.SetRegularExpression(Me.txtAccountStart, "")
            Me.Validator.SetRequired(Me.txtAccountStart, False)
            Me.txtAccountStart.Size = New System.Drawing.Size(96, 21)
            Me.txtAccountStart.TabIndex = 3
            Me.txtAccountStart.Text = ""
            '
            'lblAccountStart
            '
            Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
            Me.lblAccountStart.Location = New System.Drawing.Point(8, 40)
            Me.lblAccountStart.Name = "lblAccountStart"
            Me.lblAccountStart.Size = New System.Drawing.Size(88, 18)
            Me.lblAccountStart.TabIndex = 2
            Me.lblAccountStart.Text = "ตั้งแต่สมุดรายวัน"
            Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(344, 96)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(264, 96)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Me.ErrorProvider1
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'RptGLStatementBalanceSheetFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptGLStatementBalanceSheetFilterSubPanel"
            Me.Size = New System.Drawing.Size(448, 136)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLStatementBalanceSheetFilterSubPanel.lblYear}")

            Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLStatementBalanceSheetFilterSubPanel.lblAccountStart}")
            Me.Validator.SetDisplayName(txtAccountStart, lblAccountStart.Text)

            ' Global {ถึง}
            Me.lblAccountEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtAccountEnd, lblAccountEnd.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLStatementBalanceSheetFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLStatementBalanceSheetFilterSubPanel.grbDetail}")

        End Sub
#End Region

#Region "Member"
        
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"
        Private Sub RegisterDropdown()
            Dim baseDate As Date = CDate(Configuration.GetConfig("BaseDate"))
            Dim years(9) As Date
            For i As Integer = 0 To 9
                years(i) = DateAdd(DateInterval.Year, i, baseDate)
            Next
            Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
            myDateTimeService.ListYearsInComboBox(Me.cmbYear, years)

        End Sub
        Private Sub Initialize()
            RegisterDropdown()
            ClearCriterias()
        End Sub

        Private Sub ClearCriterias()
            For Each grbCtrl As Control In grbMaster.Controls
                If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next

            Me.cmbYear.SelectedIndex = 0
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(2) As Filter
            arr(0) = New Filter("YearAcct", Me.cmbYear.SelectedValue)
            arr(1) = New Filter("acctCodeStart", IIf(Me.txtAccountStart.TextLength > 0, Me.txtAccountStart.Text, DBNull.Value))
            arr(2) = New Filter("acctCodeEnd", IIf(Me.txtAccountEnd.TextLength > 0, Me.txtAccountEnd.Text, DBNull.Value))

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

#Region "IReportFilterSubPanel"
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection

        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()

            AddHandler btnAccountStart.Click, AddressOf Me.btnAccountFind_Click
            AddHandler btnAccountEnd.Click, AddressOf Me.btnAccountFind_Click

        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
             
                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New AccountBook).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtaccountstart", "txtaccountend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New AccountBook).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New AccountBook).FullClassName))
                Dim entity As New AccountBook(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtaccountstart"
                            Me.SetAcctBookStartDialog(entity)

                        Case "txtaccountend"
                            Me.SetAcctBookEndDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnaccountstart"
                    myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookStartDialog)

                Case "btnaccountend"
                    myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookEndDialog)

            End Select
        End Sub
        Private Sub SetAcctBookStartDialog(ByVal e As ISimpleEntity)
            Me.txtAccountStart.Text = e.Code
        End Sub
        Private Sub SetAcctBookEndDialog(ByVal e As ISimpleEntity)
            Me.txtAccountEnd.Text = e.Code
        End Sub
#End Region

    End Class

End Namespace

