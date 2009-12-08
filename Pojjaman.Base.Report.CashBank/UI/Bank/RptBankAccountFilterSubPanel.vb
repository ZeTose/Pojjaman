Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.DataAccessLayer

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptBankAccountFilterSubPanel
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
        Friend WithEvents lblOrderBy As System.Windows.Forms.Label
        Friend WithEvents cmbOrderBy As System.Windows.Forms.ComboBox
        Friend WithEvents btnBankbranchend As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtBankbranchend As System.Windows.Forms.TextBox
        Friend WithEvents lblBankbranchend As System.Windows.Forms.Label
        Friend WithEvents txtBankbranchstart As System.Windows.Forms.TextBox
        Friend WithEvents lblBankbranchstart As System.Windows.Forms.Label
        Friend WithEvents lblBankType As System.Windows.Forms.Label
        Friend WithEvents cmbBankType As System.Windows.Forms.ComboBox
        Friend WithEvents btnBankbranchstart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents lbBankCode As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptBankAccountFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblBankType = New System.Windows.Forms.Label
      Me.cmbBankType = New System.Windows.Forms.ComboBox
      Me.lblOrderBy = New System.Windows.Forms.Label
      Me.cmbOrderBy = New System.Windows.Forms.ComboBox
      Me.btnBankbranchend = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtBankbranchend = New System.Windows.Forms.TextBox
      Me.lblBankbranchend = New System.Windows.Forms.Label
      Me.btnBankbranchstart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtBankbranchstart = New System.Windows.Forms.TextBox
      Me.lblBankbranchstart = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtBankCode = New System.Windows.Forms.TextBox
      Me.lbBankCode = New System.Windows.Forms.Label
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
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(512, 192)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.lbBankCode)
      Me.grbDetail.Controls.Add(Me.txtBankCode)
      Me.grbDetail.Controls.Add(Me.lblBankType)
      Me.grbDetail.Controls.Add(Me.cmbBankType)
      Me.grbDetail.Controls.Add(Me.lblOrderBy)
      Me.grbDetail.Controls.Add(Me.cmbOrderBy)
      Me.grbDetail.Controls.Add(Me.btnBankbranchend)
      Me.grbDetail.Controls.Add(Me.txtBankbranchend)
      Me.grbDetail.Controls.Add(Me.lblBankbranchend)
      Me.grbDetail.Controls.Add(Me.btnBankbranchstart)
      Me.grbDetail.Controls.Add(Me.txtBankbranchstart)
      Me.grbDetail.Controls.Add(Me.lblBankbranchstart)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(472, 128)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'lblBankType
      '
      Me.lblBankType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankType.ForeColor = System.Drawing.Color.Black
      Me.lblBankType.Location = New System.Drawing.Point(8, 16)
      Me.lblBankType.Name = "lblBankType"
      Me.lblBankType.Size = New System.Drawing.Size(136, 18)
      Me.lblBankType.TabIndex = 0
      Me.lblBankType.Text = "ประเภทสมุดบัญชี"
      Me.lblBankType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbBankType
      '
      Me.cmbBankType.Location = New System.Drawing.Point(152, 16)
      Me.cmbBankType.Name = "cmbBankType"
      Me.cmbBankType.Size = New System.Drawing.Size(128, 21)
      Me.cmbBankType.TabIndex = 1
      '
      'lblOrderBy
      '
      Me.lblOrderBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOrderBy.ForeColor = System.Drawing.Color.Black
      Me.lblOrderBy.Location = New System.Drawing.Point(8, 64)
      Me.lblOrderBy.Name = "lblOrderBy"
      Me.lblOrderBy.Size = New System.Drawing.Size(136, 18)
      Me.lblOrderBy.TabIndex = 8
      Me.lblOrderBy.Text = "เรียงตาม"
      Me.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbOrderBy
      '
      Me.cmbOrderBy.Enabled = False
      Me.cmbOrderBy.Location = New System.Drawing.Point(152, 64)
      Me.cmbOrderBy.Name = "cmbOrderBy"
      Me.cmbOrderBy.Size = New System.Drawing.Size(128, 21)
      Me.cmbOrderBy.TabIndex = 9
      '
      'btnBankbranchend
      '
      Me.btnBankbranchend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankbranchend.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankbranchend.Image = CType(resources.GetObject("btnBankbranchend.Image"), System.Drawing.Image)
      Me.btnBankbranchend.Location = New System.Drawing.Point(424, 40)
      Me.btnBankbranchend.Name = "btnBankbranchend"
      Me.btnBankbranchend.Size = New System.Drawing.Size(24, 22)
      Me.btnBankbranchend.TabIndex = 7
      Me.btnBankbranchend.TabStop = False
      Me.btnBankbranchend.ThemedImage = CType(resources.GetObject("btnBankbranchend.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankbranchend
      '
      Me.Validator.SetDataType(Me.txtBankbranchend, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankbranchend, "")
      Me.txtBankbranchend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankbranchend, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankbranchend, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankbranchend, System.Drawing.Color.Empty)
      Me.txtBankbranchend.Location = New System.Drawing.Point(320, 40)
      Me.Validator.SetMaxValue(Me.txtBankbranchend, "")
      Me.Validator.SetMinValue(Me.txtBankbranchend, "")
      Me.txtBankbranchend.Name = "txtBankbranchend"
      Me.Validator.SetRegularExpression(Me.txtBankbranchend, "")
      Me.Validator.SetRequired(Me.txtBankbranchend, False)
      Me.txtBankbranchend.Size = New System.Drawing.Size(104, 21)
      Me.txtBankbranchend.TabIndex = 6
      Me.txtBankbranchend.Text = ""
      '
      'lblBankbranchend
      '
      Me.lblBankbranchend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankbranchend.ForeColor = System.Drawing.Color.Black
      Me.lblBankbranchend.Location = New System.Drawing.Point(288, 40)
      Me.lblBankbranchend.Name = "lblBankbranchend"
      Me.lblBankbranchend.Size = New System.Drawing.Size(24, 18)
      Me.lblBankbranchend.TabIndex = 5
      Me.lblBankbranchend.Text = "ถึง"
      Me.lblBankbranchend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnBankbranchstart
      '
      Me.btnBankbranchstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankbranchstart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankbranchstart.Image = CType(resources.GetObject("btnBankbranchstart.Image"), System.Drawing.Image)
      Me.btnBankbranchstart.Location = New System.Drawing.Point(256, 40)
      Me.btnBankbranchstart.Name = "btnBankbranchstart"
      Me.btnBankbranchstart.Size = New System.Drawing.Size(24, 22)
      Me.btnBankbranchstart.TabIndex = 4
      Me.btnBankbranchstart.TabStop = False
      Me.btnBankbranchstart.ThemedImage = CType(resources.GetObject("btnBankbranchstart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankbranchstart
      '
      Me.Validator.SetDataType(Me.txtBankbranchstart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankbranchstart, "")
      Me.txtBankbranchstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankbranchstart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankbranchstart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankbranchstart, System.Drawing.Color.Empty)
      Me.txtBankbranchstart.Location = New System.Drawing.Point(152, 40)
      Me.Validator.SetMaxValue(Me.txtBankbranchstart, "")
      Me.Validator.SetMinValue(Me.txtBankbranchstart, "")
      Me.txtBankbranchstart.Name = "txtBankbranchstart"
      Me.Validator.SetRegularExpression(Me.txtBankbranchstart, "")
      Me.Validator.SetRequired(Me.txtBankbranchstart, False)
      Me.txtBankbranchstart.Size = New System.Drawing.Size(104, 21)
      Me.txtBankbranchstart.TabIndex = 3
      Me.txtBankbranchstart.Text = ""
      '
      'lblBankbranchstart
      '
      Me.lblBankbranchstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankbranchstart.ForeColor = System.Drawing.Color.Black
      Me.lblBankbranchstart.Location = New System.Drawing.Point(8, 40)
      Me.lblBankbranchstart.Name = "lblBankbranchstart"
      Me.lblBankbranchstart.Size = New System.Drawing.Size(136, 18)
      Me.lblBankbranchstart.TabIndex = 2
      Me.lblBankbranchstart.Text = "ตั้งแต่ธนาคาร/สาขา"
      Me.lblBankbranchstart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(424, 160)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(344, 160)
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
      'txtBankCode
      '
      Me.Validator.SetDataType(Me.txtBankCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
      Me.txtBankCode.Location = New System.Drawing.Point(152, 88)
      Me.Validator.SetMaxValue(Me.txtBankCode, "")
      Me.Validator.SetMinValue(Me.txtBankCode, "")
      Me.txtBankCode.Name = "txtBankCode"
      Me.Validator.SetRegularExpression(Me.txtBankCode, "")
      Me.Validator.SetRequired(Me.txtBankCode, False)
      Me.txtBankCode.Size = New System.Drawing.Size(128, 21)
      Me.txtBankCode.TabIndex = 10
      Me.txtBankCode.Text = ""
      '
      'lbBankCode
      '
      Me.lbBankCode.Location = New System.Drawing.Point(72, 91)
      Me.lbBankCode.Name = "lbBankCode"
      Me.lbBankCode.Size = New System.Drawing.Size(80, 23)
      Me.lbBankCode.TabIndex = 11
      Me.lbBankCode.Text = "เลขที่สมุดบัญชี"
      '
      'RptBankAccountFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptBankAccountFilterSubPanel"
      Me.Size = New System.Drawing.Size(528, 208)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblBankbranchstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankAccountFilterSubPanel.lblBankbranchstart}")
            Me.Validator.SetDisplayName(txtBankbranchstart, lblBankbranchstart.Text)

            ' Global {ถึง}
            Me.lblBankbranchend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtBankbranchend, lblBankbranchend.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankAccountFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankAccountFilterSubPanel.grbDetail}")

            Me.lblOrderBy.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankAccountFilterSubPanel.lblOrderBy}")
            Me.lblBankType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptBankAccountFilterSubPanel.lblBankType}")
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
        Private Sub RefreshBalance()
            
        End Sub
        Private Sub RegisterDropdown()
            RefreshBalance()
            ' ประเภทบัญชี
            BankAccountType.ListCodeDescriptionInComboBox(Me.cmbBankType, "bankacct_type", True)
            ' เรียงตาม 
            RptBankAccountFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbOrderBy, "rpt_bankaccount")
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

            If Me.cmbOrderBy.Items.Count > 0 Then Me.cmbOrderBy.SelectedIndex = 0
            If Me.cmbBankType.Items.Count > 0 Then Me.cmbBankType.SelectedIndex = 0
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim val As Integer = -1
            If Me.cmbBankType.Text.Length > 0 Then
                val = BankAccountType.GetValue("bankacct_type", Me.cmbBankType.Text)
            End If
      Dim arr(3) As Filter
            arr(0) = New Filter("BankAcctType", val)
            arr(1) = New Filter("BankBrhCodeStart", IIf(Me.txtBankbranchstart.TextLength > 0, Me.txtBankbranchstart.Text, DBNull.Value))
            arr(2) = New Filter("BankBrhCodeEnd", IIf(Me.txtBankbranchend.TextLength > 0, Me.txtBankbranchend.Text, DBNull.Value))
      arr(3) = New Filter("BankAccountCode", IIf(Me.txtBankCode.TextLength > 0, Me.txtBankCode.Text, DBNull.Value))

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
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'Type
            dpi = New DocPrintingItem
            dpi.Mapping = "Type"
            dpi.Value = Me.cmbBankType.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'OrderBy
            dpi = New DocPrintingItem
            dpi.Mapping = "OrderBy"
            dpi.Value = Me.cmbOrderBy.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Bankacct start
            dpi = New DocPrintingItem
            dpi.Mapping = "BankacctStart"
            dpi.Value = Me.txtBankbranchstart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Bankacct end
            dpi = New DocPrintingItem
            dpi.Mapping = "BankacctEnd"
            dpi.Value = Me.txtBankbranchend.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'today
            dpi = New DocPrintingItem
            dpi.Mapping = "today"
            dpi.Value = MinDateToNull(Now, "") + " " + Now.ToShortTimeString
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnBankbranchstart.Click, AddressOf Me.btnBankBranchFind_Click
            AddHandler btnBankbranchend.Click, AddressOf Me.btnBankBranchFind_Click
        End Sub

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
                If data.GetDataPresent((New BankBranch).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtbankbranchstart", "txtbankbranchend"
                                Return True

                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New BankBranch).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New BankBranch).FullClassName))
                Dim entity As New BankBranch(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtbankbranchstart"
                            Me.SetBankBranchStartDialog(entity)

                        Case "txtbankbranchend"
                            Me.SetBankBranchEndDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnBankBranchFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnbankbranchstart"
                    myEntityPanelService.OpenListDialog(New BankBranch, AddressOf SetBankBranchStartDialog)

                Case "btnbankbranchend"
                    myEntityPanelService.OpenListDialog(New BankBranch, AddressOf SetBankBranchEndDialog)

            End Select
        End Sub
        Private Sub SetBankBranchStartDialog(ByVal e As ISimpleEntity)
            Me.txtBankbranchstart.Text = e.Code
        End Sub
        Private Sub SetBankBranchEndDialog(ByVal e As ISimpleEntity)
            Me.txtBankbranchend.Text = e.Code
        End Sub

#End Region

    End Class

    ' เรียงตาม 
    Public Class RptBankAccountFilterOrderBy
        Inherits CodeDescription

#Region "Construtors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "rpt_bankaccount"
            End Get
        End Property
#End Region

    End Class
End Namespace

