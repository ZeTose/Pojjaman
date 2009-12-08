Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class BOQFilterSubPanel
        Inherits AbstractFilterSubPanel

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
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents txtEstimatorCode As System.Windows.Forms.TextBox
        Friend WithEvents txtEstimatorName As System.Windows.Forms.TextBox
        Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowProjectDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowProject As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
        Friend WithEvents lblProject As System.Windows.Forms.Label
        Friend WithEvents btnCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents lblEstimator As System.Windows.Forms.Label
        Friend WithEvents btnEstimatorPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnEstimatorDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BOQFilterSubPanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.txtEstimatorCode = New System.Windows.Forms.TextBox
            Me.btnCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCostCenterCode = New System.Windows.Forms.TextBox
            Me.txtEstimatorName = New System.Windows.Forms.TextBox
            Me.lblEstimator = New System.Windows.Forms.Label
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.btnCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnEstimatorPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCC = New System.Windows.Forms.Label
            Me.btnEstimatorDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtProjectName = New System.Windows.Forms.TextBox
            Me.ibtnShowProjectDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowProject = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtProjectCode = New System.Windows.Forms.TextBox
            Me.lblProject = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.grbMainDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 6
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(392, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.grbMainDetail)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(528, 200)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(448, 168)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(368, 168)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 4
            Me.btnReset.Text = "Reset"
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.cmbStatus)
            Me.grbMainDetail.Controls.Add(Me.lblStatus)
            Me.grbMainDetail.Controls.Add(Me.txtEstimatorCode)
            Me.grbMainDetail.Controls.Add(Me.btnCostCenterPanel)
            Me.grbMainDetail.Controls.Add(Me.txtCostCenterCode)
            Me.grbMainDetail.Controls.Add(Me.txtEstimatorName)
            Me.grbMainDetail.Controls.Add(Me.txtCode)
            Me.grbMainDetail.Controls.Add(Me.lblEstimator)
            Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbMainDetail.Controls.Add(Me.lblCode)
            Me.grbMainDetail.Controls.Add(Me.btnCostCenterDialog)
            Me.grbMainDetail.Controls.Add(Me.btnEstimatorPanel)
            Me.grbMainDetail.Controls.Add(Me.lblCC)
            Me.grbMainDetail.Controls.Add(Me.btnEstimatorDialog)
            Me.grbMainDetail.Controls.Add(Me.txtProjectName)
            Me.grbMainDetail.Controls.Add(Me.ibtnShowProjectDialog)
            Me.grbMainDetail.Controls.Add(Me.ibtnShowProject)
            Me.grbMainDetail.Controls.Add(Me.txtProjectCode)
            Me.grbMainDetail.Controls.Add(Me.lblProject)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(512, 144)
            Me.grbMainDetail.TabIndex = 0
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(112, 112)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(224, 21)
            Me.cmbStatus.TabIndex = 3
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblStatus.Location = New System.Drawing.Point(8, 112)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(104, 18)
            Me.lblStatus.TabIndex = 197
            Me.lblStatus.Text = "สถานะ:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEstimatorCode
            '
            Me.Validator.SetDataType(Me.txtEstimatorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEstimatorCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtEstimatorCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEstimatorCode, System.Drawing.Color.Empty)
            Me.txtEstimatorCode.Location = New System.Drawing.Point(112, 40)
            Me.Validator.SetMaxValue(Me.txtEstimatorCode, "")
            Me.Validator.SetMinValue(Me.txtEstimatorCode, "")
            Me.txtEstimatorCode.Name = "txtEstimatorCode"
            Me.Validator.SetRegularExpression(Me.txtEstimatorCode, "")
            Me.Validator.SetRequired(Me.txtEstimatorCode, False)
            Me.txtEstimatorCode.Size = New System.Drawing.Size(80, 20)
            Me.txtEstimatorCode.TabIndex = 1
            Me.txtEstimatorCode.Text = ""
            '
            'btnCostCenterPanel
            '
            Me.btnCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCostCenterPanel.Image = CType(resources.GetObject("btnCostCenterPanel.Image"), System.Drawing.Image)
            Me.btnCostCenterPanel.Location = New System.Drawing.Point(480, 88)
            Me.btnCostCenterPanel.Name = "btnCostCenterPanel"
            Me.btnCostCenterPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnCostCenterPanel.TabIndex = 199
            Me.btnCostCenterPanel.TabStop = False
            Me.btnCostCenterPanel.ThemedImage = CType(resources.GetObject("btnCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.txtCostCenterCode.Location = New System.Drawing.Point(112, 88)
            Me.Validator.SetMaxValue(Me.txtCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
            Me.txtCostCenterCode.Name = "txtCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtCostCenterCode, False)
            Me.txtCostCenterCode.Size = New System.Drawing.Size(80, 20)
            Me.txtCostCenterCode.TabIndex = 2
            Me.txtCostCenterCode.Text = ""
            '
            'txtEstimatorName
            '
            Me.Validator.SetDataType(Me.txtEstimatorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEstimatorName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtEstimatorName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEstimatorName, System.Drawing.Color.Empty)
            Me.txtEstimatorName.Location = New System.Drawing.Point(192, 40)
            Me.Validator.SetMaxValue(Me.txtEstimatorName, "")
            Me.Validator.SetMinValue(Me.txtEstimatorName, "")
            Me.txtEstimatorName.Name = "txtEstimatorName"
            Me.txtEstimatorName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtEstimatorName, "")
            Me.Validator.SetRequired(Me.txtEstimatorName, False)
            Me.txtEstimatorName.Size = New System.Drawing.Size(264, 20)
            Me.txtEstimatorName.TabIndex = 196
            Me.txtEstimatorName.TabStop = False
            Me.txtEstimatorName.Text = ""
            '
            'lblEstimator
            '
            Me.lblEstimator.BackColor = System.Drawing.Color.Transparent
            Me.lblEstimator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEstimator.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblEstimator.Location = New System.Drawing.Point(8, 40)
            Me.lblEstimator.Name = "lblEstimator"
            Me.lblEstimator.Size = New System.Drawing.Size(104, 18)
            Me.lblEstimator.TabIndex = 191
            Me.lblEstimator.Text = "ผู้รับ:"
            Me.lblEstimator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(192, 88)
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(264, 20)
            Me.txtCostCenterName.TabIndex = 196
            Me.txtCostCenterName.TabStop = False
            Me.txtCostCenterName.Text = ""
            '
            'btnCostCenterDialog
            '
            Me.btnCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCostCenterDialog.Image = CType(resources.GetObject("btnCostCenterDialog.Image"), System.Drawing.Image)
            Me.btnCostCenterDialog.Location = New System.Drawing.Point(456, 88)
            Me.btnCostCenterDialog.Name = "btnCostCenterDialog"
            Me.btnCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnCostCenterDialog.TabIndex = 201
            Me.btnCostCenterDialog.TabStop = False
            Me.btnCostCenterDialog.ThemedImage = CType(resources.GetObject("btnCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnEstimatorPanel
            '
            Me.btnEstimatorPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnEstimatorPanel.Image = CType(resources.GetObject("btnEstimatorPanel.Image"), System.Drawing.Image)
            Me.btnEstimatorPanel.Location = New System.Drawing.Point(480, 40)
            Me.btnEstimatorPanel.Name = "btnEstimatorPanel"
            Me.btnEstimatorPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnEstimatorPanel.TabIndex = 200
            Me.btnEstimatorPanel.TabStop = False
            Me.btnEstimatorPanel.ThemedImage = CType(resources.GetObject("btnEstimatorPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCC
            '
            Me.lblCC.BackColor = System.Drawing.Color.Transparent
            Me.lblCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblCC.Location = New System.Drawing.Point(8, 88)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(104, 18)
            Me.lblCC.TabIndex = 192
            Me.lblCC.Text = "โครงการก่อสร้าง:"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnEstimatorDialog
            '
            Me.btnEstimatorDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnEstimatorDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnEstimatorDialog.Image = CType(resources.GetObject("btnEstimatorDialog.Image"), System.Drawing.Image)
            Me.btnEstimatorDialog.Location = New System.Drawing.Point(456, 40)
            Me.btnEstimatorDialog.Name = "btnEstimatorDialog"
            Me.btnEstimatorDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnEstimatorDialog.TabIndex = 202
            Me.btnEstimatorDialog.TabStop = False
            Me.btnEstimatorDialog.ThemedImage = CType(resources.GetObject("btnEstimatorDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtProjectName
            '
            Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.txtProjectName.Location = New System.Drawing.Point(192, 64)
            Me.Validator.SetMaxValue(Me.txtProjectName, "")
            Me.Validator.SetMinValue(Me.txtProjectName, "")
            Me.txtProjectName.Name = "txtProjectName"
            Me.txtProjectName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProjectName, "")
            Me.Validator.SetRequired(Me.txtProjectName, False)
            Me.txtProjectName.Size = New System.Drawing.Size(264, 20)
            Me.txtProjectName.TabIndex = 196
            Me.txtProjectName.TabStop = False
            Me.txtProjectName.Text = ""
            '
            'ibtnShowProjectDialog
            '
            Me.ibtnShowProjectDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowProjectDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowProjectDialog.Image = CType(resources.GetObject("ibtnShowProjectDialog.Image"), System.Drawing.Image)
            Me.ibtnShowProjectDialog.Location = New System.Drawing.Point(456, 64)
            Me.ibtnShowProjectDialog.Name = "ibtnShowProjectDialog"
            Me.ibtnShowProjectDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowProjectDialog.TabIndex = 201
            Me.ibtnShowProjectDialog.TabStop = False
            Me.ibtnShowProjectDialog.ThemedImage = CType(resources.GetObject("ibtnShowProjectDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowProject
            '
            Me.ibtnShowProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowProject.Image = CType(resources.GetObject("ibtnShowProject.Image"), System.Drawing.Image)
            Me.ibtnShowProject.Location = New System.Drawing.Point(480, 64)
            Me.ibtnShowProject.Name = "ibtnShowProject"
            Me.ibtnShowProject.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowProject.TabIndex = 199
            Me.ibtnShowProject.TabStop = False
            Me.ibtnShowProject.ThemedImage = CType(resources.GetObject("ibtnShowProject.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtProjectCode
            '
            Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.txtProjectCode.Location = New System.Drawing.Point(112, 64)
            Me.Validator.SetMaxValue(Me.txtProjectCode, "")
            Me.Validator.SetMinValue(Me.txtProjectCode, "")
            Me.txtProjectCode.Name = "txtProjectCode"
            Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
            Me.Validator.SetRequired(Me.txtProjectCode, False)
            Me.txtProjectCode.Size = New System.Drawing.Size(80, 20)
            Me.txtProjectCode.TabIndex = 2
            Me.txtProjectCode.Text = ""
            '
            'lblProject
            '
            Me.lblProject.BackColor = System.Drawing.Color.Transparent
            Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProject.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblProject.Location = New System.Drawing.Point(8, 64)
            Me.lblProject.Name = "lblProject"
            Me.lblProject.Size = New System.Drawing.Size(104, 18)
            Me.lblProject.TabIndex = 192
            Me.lblProject.Text = "Bidding Project:"
            Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            'BOQFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "BOQFilterSubPanel"
            Me.Size = New System.Drawing.Size(544, 216)
            Me.grbDetail.ResumeLayout(False)
            Me.grbMainDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()
            Me.LoopControl(Me)
        End Sub
#End Region

#Region "Members"
        Private m_estimator As Employee
        Private m_cc As CostCenter
        Private m_customer As Customer
        Private docDateStart As Date
        Private docDateEnd As Date
        Private m_dummyCC As CostCenter
        Private m_project As Project
#End Region

#Region "Methods"
        Public Sub Initialize()
            PopulateStatus()
            ClearCriterias()
        End Sub
        Private m_dateSetting As Boolean
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case Else
            End Select
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""
            Me.txtCostCenterCode.Text = ""
            Me.txtCostCenterName.Text = ""
            Me.m_cc = New CostCenter

            Me.txtEstimatorCode.Text = ""
            Me.txtEstimatorName.Text = ""
            Me.m_estimator = New Employee

            Me.docDateStart = Date.MinValue
            Me.docDateEnd = Date.MinValue

            cmbStatus.SelectedIndex = 0
            EntityRefresh()
        End Sub
        Private Sub PopulateStatus()
            CodeDescription.ListCodeDescriptionInComboBox(cmbStatus, "goodsreceipt_status", True)
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.lblEstimator.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQFilterSubPanel.lblEstimator}")
            Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PLE_BOQFilterSubPanel.lblProject}")
            Me.lblCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQFilterSubPanel.lblCC}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQFilterSubPanel.lblStatus}")
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQFilterSubPanel.grbMainDetail}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(6) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("employee_id", ValidIdOrDBNull(Me.m_estimator))
            arr(2) = New Filter("cc_id", ValidIdOrDBNull(Me.m_cc))
            arr(3) = New Filter("status", IIf(cmbStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbStatus.SelectedItem, IdValuePair).Id))
            arr(4) = New Filter("cust_id", ValidIdOrDBNull(Me.m_customer))
            arr(5) = New Filter("project_id", ValidIdOrDBNull(Me.m_project))
            arr(6) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub txtEstimatorCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEstimatorCode.Validated
            Employee.GetEmployee(txtEstimatorCode, txtEstimatorName, Me.m_estimator)
        End Sub
        Private Sub txtCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostCenterCode.Validated
            CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub txtProjectCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProjectCode.Validated
            Project.GetProject(txtProjectCode, txtProjectName, Me.m_project)
        End Sub
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
        Private Sub btnToCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimatorDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToCCPerson)
        End Sub
        Private Sub SetToCCPerson(ByVal e As ISimpleEntity)
            Me.txtEstimatorCode.Text = e.Code
            Employee.GetEmployee(txtEstimatorCode, txtEstimatorName, Me.m_estimator)
        End Sub
        Private Sub btnToCCPersonPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimatorPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub btnToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
        End Sub
        Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
            Me.txtCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub btnToCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCostCenterPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(DummyCC)
        End Sub
        Private Sub btnProjectDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowProjectDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New Project, AddressOf SetProject)
        End Sub
        Private Sub SetProject(ByVal e As ISimpleEntity)
            Me.txtProjectCode.Text = e.Code
            Project.GetProject(txtProjectCode, txtProjectName, Me.m_project)
        End Sub
        Private Sub btnProjectPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowProject.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Project)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property DummyCC() As CostCenter            Get                If m_dummyCC Is Nothing Then                    m_dummyCC = New CostCenter
                End If                Return m_dummyCC            End Get        End Property
#End Region

#Region "IClipboardHandler Overrides"         'Undone
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject

                If data.GetDataPresent((DummyCC).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercode", "txtcostcentername"
                            Return True
                    End Select
                End If
                If data.GetDataPresent((New Employee).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtestimatorcode", "txtestimatorname"
                            Return True
                    End Select
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.ActiveControl Is Nothing Then
                Return
            End If
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((DummyCC).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((DummyCC).FullClassName))
                Dim entity As New CostCenter(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtcostcentercode", "txtcostcentername"
                        Me.SetToCostCenter(entity)
                End Select
            End If
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtestimatorcode", "txtestimatorname"
                        Me.SetToCCPerson(entity)
                End Select
            End If
        End Sub
#End Region

        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                EntityRefresh()
            End Set
        End Property
        Private Sub EntityRefresh()
            'If Entities Is Nothing Then
            '    Return
            'End If
            'For Each entity As ISimpleEntity In Entities

            '    If TypeOf entity Is GoodsReceipt Then
            '        Dim obj As GoodsReceipt
            '        obj = CType(entity, GoodsReceipt)
            '        ' Customer ...
            '        If obj.Customer.Originated Then
            '            Me.SetCustomer(obj.Customer)
            '            Me.txtCustomerCode.Enabled = False
            '            Me.txtCustomerName.Enabled = False
            '            Me.btnCustomerDialog.Enabled = False
            '            Me.btnCustomerPanel.Enabled = False
            '        End If
            '        If entity.Status.Value <> -1 Then
            '            CodeDescription.ComboSelect(Me.cmbStatus, entity.Status)
            '            Me.cmbStatus.Enabled = False
            '        End If
            '    End If
            '    If TypeOf entity Is Customer Then
            '        Me.SetCustomer(entity)
            '        Me.txtCustomerCode.Enabled = False
            '        Me.txtCustomerName.Enabled = False
            '        Me.btnCustomerDialog.Enabled = False
            '        Me.btnCustomerPanel.Enabled = False
            '    End If
            'Next
        End Sub
    End Class
End Namespace

