Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class Rpt276FilterSubPanel
    'Inherits UserControl
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
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtDueDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDateStart As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildSupplierGroup As System.Windows.Forms.CheckBox
    Friend WithEvents btnSpgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSpgCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSpgStart As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents cmbDocStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDocStatus As System.Windows.Forms.Label
    Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
    Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents txtPersonReceiveCode As System.Windows.Forms.TextBox
    Friend WithEvents lblPersonReceive As System.Windows.Forms.Label
    Friend WithEvents txtPersonReceiveName As System.Windows.Forms.TextBox
    Friend WithEvents btnPersonReceiveDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grbTypeDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkAssets As System.Windows.Forms.CheckBox
    Friend WithEvents chkEtc As System.Windows.Forms.CheckBox
    Friend WithEvents chkMechine As System.Windows.Forms.CheckBox
    Friend WithEvents chkWage As System.Windows.Forms.CheckBox
    Friend WithEvents chkLCI As System.Windows.Forms.CheckBox
    Friend WithEvents chkTool As System.Windows.Forms.CheckBox
    Friend WithEvents chkNote As System.Windows.Forms.CheckBox
    Friend WithEvents grbRank As System.Windows.Forms.GroupBox
    Friend WithEvents txtPoEnd As System.Windows.Forms.TextBox
    Friend WithEvents cmbPORefStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblPORefStatus As System.Windows.Forms.Label
    Friend WithEvents txtDocEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtPoStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPOStart As System.Windows.Forms.Label
    Friend WithEvents txtDocStart As System.Windows.Forms.TextBox
    Friend WithEvents lblPOEnd As System.Windows.Forms.Label
    Friend WithEvents lblDocStart As System.Windows.Forms.Label
    Friend WithEvents lblDocEnd As System.Windows.Forms.Label
    Friend WithEvents ibtnPO2 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnGR2 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnPO1 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnGR1 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents grbReferenceStatus As System.Windows.Forms.GroupBox
        Friend WithEvents chkNoReference As System.Windows.Forms.CheckBox
        Friend WithEvents chkPatialReference As System.Windows.Forms.CheckBox
        Friend WithEvents chkFullReference As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowDetail As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt276FilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.grbRank = New System.Windows.Forms.GroupBox()
            Me.ibtnPO2 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnGR2 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnPO1 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnGR1 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtPoEnd = New System.Windows.Forms.TextBox()
            Me.cmbPORefStatus = New System.Windows.Forms.ComboBox()
            Me.lblPORefStatus = New System.Windows.Forms.Label()
            Me.txtDocEnd = New System.Windows.Forms.TextBox()
            Me.txtPoStart = New System.Windows.Forms.TextBox()
            Me.lblPOStart = New System.Windows.Forms.Label()
            Me.txtDocStart = New System.Windows.Forms.TextBox()
            Me.lblPOEnd = New System.Windows.Forms.Label()
            Me.lblDocStart = New System.Windows.Forms.Label()
            Me.lblDocEnd = New System.Windows.Forms.Label()
            Me.grbDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.grbTypeDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.chkNote = New System.Windows.Forms.CheckBox()
            Me.chkTool = New System.Windows.Forms.CheckBox()
            Me.chkAssets = New System.Windows.Forms.CheckBox()
            Me.chkEtc = New System.Windows.Forms.CheckBox()
            Me.chkMechine = New System.Windows.Forms.CheckBox()
            Me.chkWage = New System.Windows.Forms.CheckBox()
            Me.chkLCI = New System.Windows.Forms.CheckBox()
            Me.cmbStatus = New System.Windows.Forms.ComboBox()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.txtTemp = New System.Windows.Forms.TextBox()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.chkShowDetail = New System.Windows.Forms.CheckBox()
            Me.txtPersonReceiveCode = New System.Windows.Forms.TextBox()
            Me.lblPersonReceive = New System.Windows.Forms.Label()
            Me.txtPersonReceiveName = New System.Windows.Forms.TextBox()
            Me.btnPersonReceiveDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtDueDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDueDateStart = New System.Windows.Forms.TextBox()
            Me.dtpDueDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDueDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDueDateStart = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.chkIncludeChildSupplierGroup = New System.Windows.Forms.CheckBox()
            Me.btnSpgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtSpgCodeStart = New System.Windows.Forms.TextBox()
            Me.lblSpgStart = New System.Windows.Forms.Label()
            Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
            Me.cmbDocStatus = New System.Windows.Forms.ComboBox()
            Me.lblDocStatus = New System.Windows.Forms.Label()
            Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
            Me.lblSuppliEnd = New System.Windows.Forms.Label()
            Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
            Me.lblSuppliStart = New System.Windows.Forms.Label()
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
            Me.lblCCStart = New System.Windows.Forms.Label()
            Me.txtCostCenterName = New System.Windows.Forms.TextBox()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.grbReferenceStatus = New System.Windows.Forms.GroupBox()
            Me.chkFullReference = New System.Windows.Forms.CheckBox()
            Me.chkPatialReference = New System.Windows.Forms.CheckBox()
            Me.chkNoReference = New System.Windows.Forms.CheckBox()
            Me.grbMaster.SuspendLayout()
            Me.grbRank.SuspendLayout()
            Me.grbDisplay.SuspendLayout()
            Me.grbTypeDisplay.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbReferenceStatus.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbRank)
            Me.grbMaster.Controls.Add(Me.grbDisplay)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 0)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(1203, 293)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'grbRank
            '
            Me.grbRank.Controls.Add(Me.grbReferenceStatus)
            Me.grbRank.Controls.Add(Me.ibtnPO2)
            Me.grbRank.Controls.Add(Me.ibtnGR2)
            Me.grbRank.Controls.Add(Me.ibtnPO1)
            Me.grbRank.Controls.Add(Me.ibtnGR1)
            Me.grbRank.Controls.Add(Me.txtPoEnd)
            Me.grbRank.Controls.Add(Me.cmbPORefStatus)
            Me.grbRank.Controls.Add(Me.lblPORefStatus)
            Me.grbRank.Controls.Add(Me.txtDocEnd)
            Me.grbRank.Controls.Add(Me.txtPoStart)
            Me.grbRank.Controls.Add(Me.lblPOStart)
            Me.grbRank.Controls.Add(Me.txtDocStart)
            Me.grbRank.Controls.Add(Me.lblPOEnd)
            Me.grbRank.Controls.Add(Me.lblDocStart)
            Me.grbRank.Controls.Add(Me.lblDocEnd)
            Me.grbRank.Location = New System.Drawing.Point(452, 15)
            Me.grbRank.Name = "grbRank"
            Me.grbRank.Size = New System.Drawing.Size(450, 270)
            Me.grbRank.TabIndex = 8
            Me.grbRank.TabStop = False
            Me.grbRank.Text = "ข้อมูลทัวไป"
            '
            'ibtnPO2
            '
            Me.ibtnPO2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnPO2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnPO2.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnPO2.Location = New System.Drawing.Point(418, 39)
            Me.ibtnPO2.Name = "ibtnPO2"
            Me.ibtnPO2.Size = New System.Drawing.Size(24, 22)
            Me.ibtnPO2.TabIndex = 207
            Me.ibtnPO2.TabStop = False
            Me.ibtnPO2.ThemedImage = CType(resources.GetObject("ibtnPO2.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnGR2
            '
            Me.ibtnGR2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnGR2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnGR2.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnGR2.Location = New System.Drawing.Point(418, 16)
            Me.ibtnGR2.Name = "ibtnGR2"
            Me.ibtnGR2.Size = New System.Drawing.Size(24, 22)
            Me.ibtnGR2.TabIndex = 207
            Me.ibtnGR2.TabStop = False
            Me.ibtnGR2.ThemedImage = CType(resources.GetObject("ibtnGR2.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnPO1
            '
            Me.ibtnPO1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnPO1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnPO1.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnPO1.Location = New System.Drawing.Point(258, 39)
            Me.ibtnPO1.Name = "ibtnPO1"
            Me.ibtnPO1.Size = New System.Drawing.Size(24, 22)
            Me.ibtnPO1.TabIndex = 207
            Me.ibtnPO1.TabStop = False
            Me.ibtnPO1.ThemedImage = CType(resources.GetObject("ibtnPO1.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnGR1
            '
            Me.ibtnGR1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnGR1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnGR1.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnGR1.Location = New System.Drawing.Point(258, 16)
            Me.ibtnGR1.Name = "ibtnGR1"
            Me.ibtnGR1.Size = New System.Drawing.Size(24, 22)
            Me.ibtnGR1.TabIndex = 207
            Me.ibtnGR1.TabStop = False
            Me.ibtnGR1.ThemedImage = CType(resources.GetObject("ibtnGR1.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPoEnd
            '
            Me.Validator.SetDataType(Me.txtPoEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPoEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtPoEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPoEnd, System.Drawing.Color.Empty)
            Me.txtPoEnd.Location = New System.Drawing.Point(313, 40)
            Me.Validator.SetMaxValue(Me.txtPoEnd, "")
            Me.Validator.SetMinValue(Me.txtPoEnd, "")
            Me.txtPoEnd.Name = "txtPoEnd"
            Me.Validator.SetRegularExpression(Me.txtPoEnd, "")
            Me.Validator.SetRequired(Me.txtPoEnd, False)
            Me.txtPoEnd.Size = New System.Drawing.Size(105, 21)
            Me.txtPoEnd.TabIndex = 3
            '
            'cmbPORefStatus
            '
            Me.cmbPORefStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbPORefStatus.Location = New System.Drawing.Point(116, 64)
            Me.cmbPORefStatus.Name = "cmbPORefStatus"
            Me.cmbPORefStatus.Size = New System.Drawing.Size(208, 21)
            Me.cmbPORefStatus.TabIndex = 4
            '
            'lblPORefStatus
            '
            Me.lblPORefStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPORefStatus.ForeColor = System.Drawing.Color.Black
            Me.lblPORefStatus.Location = New System.Drawing.Point(52, 65)
            Me.lblPORefStatus.Name = "lblPORefStatus"
            Me.lblPORefStatus.Size = New System.Drawing.Size(56, 18)
            Me.lblPORefStatus.TabIndex = 0
            Me.lblPORefStatus.Text = "สถานะ"
            Me.lblPORefStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocEnd
            '
            Me.Validator.SetDataType(Me.txtDocEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDocEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocEnd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocEnd, System.Drawing.Color.Empty)
            Me.txtDocEnd.Location = New System.Drawing.Point(313, 17)
            Me.Validator.SetMaxValue(Me.txtDocEnd, "")
            Me.Validator.SetMinValue(Me.txtDocEnd, "")
            Me.txtDocEnd.Name = "txtDocEnd"
            Me.Validator.SetRegularExpression(Me.txtDocEnd, "")
            Me.Validator.SetRequired(Me.txtDocEnd, False)
            Me.txtDocEnd.Size = New System.Drawing.Size(105, 21)
            Me.txtDocEnd.TabIndex = 1
            '
            'txtPoStart
            '
            Me.Validator.SetDataType(Me.txtPoStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPoStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtPoStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPoStart, System.Drawing.Color.Empty)
            Me.txtPoStart.Location = New System.Drawing.Point(116, 40)
            Me.Validator.SetMaxValue(Me.txtPoStart, "")
            Me.Validator.SetMinValue(Me.txtPoStart, "")
            Me.txtPoStart.Name = "txtPoStart"
            Me.Validator.SetRegularExpression(Me.txtPoStart, "")
            Me.Validator.SetRequired(Me.txtPoStart, False)
            Me.txtPoStart.Size = New System.Drawing.Size(145, 21)
            Me.txtPoStart.TabIndex = 2
            '
            'lblPOStart
            '
            Me.lblPOStart.BackColor = System.Drawing.Color.Transparent
            Me.lblPOStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPOStart.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblPOStart.Location = New System.Drawing.Point(22, 41)
            Me.lblPOStart.Name = "lblPOStart"
            Me.lblPOStart.Size = New System.Drawing.Size(88, 18)
            Me.lblPOStart.TabIndex = 206
            Me.lblPOStart.Text = "ตั้งแต่เลขที่ PO"
            Me.lblPOStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocStart
            '
            Me.Validator.SetDataType(Me.txtDocStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDocStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocStart, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDocStart, System.Drawing.Color.Empty)
            Me.txtDocStart.Location = New System.Drawing.Point(116, 17)
            Me.Validator.SetMaxValue(Me.txtDocStart, "")
            Me.Validator.SetMinValue(Me.txtDocStart, "")
            Me.txtDocStart.Name = "txtDocStart"
            Me.Validator.SetRegularExpression(Me.txtDocStart, "")
            Me.Validator.SetRequired(Me.txtDocStart, False)
            Me.txtDocStart.Size = New System.Drawing.Size(145, 21)
            Me.txtDocStart.TabIndex = 0
            Me.ToolTip1.SetToolTip(Me.txtDocStart, "คีย์รหัส prefix หรือใส่ comma (""GR%"" หรือ ""GR1,GR2"")")
            '
            'lblPOEnd
            '
            Me.lblPOEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPOEnd.ForeColor = System.Drawing.Color.Black
            Me.lblPOEnd.Location = New System.Drawing.Point(284, 41)
            Me.lblPOEnd.Name = "lblPOEnd"
            Me.lblPOEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblPOEnd.TabIndex = 2
            Me.lblPOEnd.Text = "ถึง"
            Me.lblPOEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDocStart
            '
            Me.lblDocStart.BackColor = System.Drawing.Color.Transparent
            Me.lblDocStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocStart.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblDocStart.Location = New System.Drawing.Point(6, 18)
            Me.lblDocStart.Name = "lblDocStart"
            Me.lblDocStart.Size = New System.Drawing.Size(104, 18)
            Me.lblDocStart.TabIndex = 206
            Me.lblDocStart.Text = "ตั้งแต่เลขที่เอกสาร"
            Me.lblDocStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocEnd
            '
            Me.lblDocEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocEnd.Location = New System.Drawing.Point(284, 18)
            Me.lblDocEnd.Name = "lblDocEnd"
            Me.lblDocEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocEnd.TabIndex = 2
            Me.lblDocEnd.Text = "ถึง"
            Me.lblDocEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grbDisplay
            '
            Me.grbDisplay.Controls.Add(Me.grbTypeDisplay)
            Me.grbDisplay.Controls.Add(Me.cmbStatus)
            Me.grbDisplay.Controls.Add(Me.lblStatus)
            Me.grbDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDisplay.Location = New System.Drawing.Point(908, 16)
            Me.grbDisplay.Name = "grbDisplay"
            Me.grbDisplay.Size = New System.Drawing.Size(287, 198)
            Me.grbDisplay.TabIndex = 7
            Me.grbDisplay.TabStop = False
            Me.grbDisplay.Text = "รูปแบบการแสดงผล"
            '
            'grbTypeDisplay
            '
            Me.grbTypeDisplay.Controls.Add(Me.chkNote)
            Me.grbTypeDisplay.Controls.Add(Me.chkTool)
            Me.grbTypeDisplay.Controls.Add(Me.chkAssets)
            Me.grbTypeDisplay.Controls.Add(Me.chkEtc)
            Me.grbTypeDisplay.Controls.Add(Me.chkMechine)
            Me.grbTypeDisplay.Controls.Add(Me.chkWage)
            Me.grbTypeDisplay.Controls.Add(Me.chkLCI)
            Me.grbTypeDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbTypeDisplay.Location = New System.Drawing.Point(11, 43)
            Me.grbTypeDisplay.Name = "grbTypeDisplay"
            Me.grbTypeDisplay.Size = New System.Drawing.Size(269, 149)
            Me.grbTypeDisplay.TabIndex = 8
            Me.grbTypeDisplay.TabStop = False
            Me.grbTypeDisplay.Text = "การแสดงผลตามประเภท"
            '
            'chkNote
            '
            Me.chkNote.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkNote.Location = New System.Drawing.Point(64, 123)
            Me.chkNote.Name = "chkNote"
            Me.chkNote.Size = New System.Drawing.Size(199, 16)
            Me.chkNote.TabIndex = 0
            Me.chkNote.Tag = "160,162"
            Me.chkNote.Text = "หมายเหตุ"
            '
            'chkTool
            '
            Me.chkTool.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkTool.Location = New System.Drawing.Point(64, 107)
            Me.chkTool.Name = "chkTool"
            Me.chkTool.Size = New System.Drawing.Size(199, 16)
            Me.chkTool.TabIndex = 6
            Me.chkTool.Tag = "19"
            Me.chkTool.Text = "เครื่องมือ"
            '
            'chkAssets
            '
            Me.chkAssets.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkAssets.Location = New System.Drawing.Point(64, 91)
            Me.chkAssets.Name = "chkAssets"
            Me.chkAssets.Size = New System.Drawing.Size(199, 16)
            Me.chkAssets.TabIndex = 5
            Me.chkAssets.Tag = "28"
            Me.chkAssets.Text = "สินทรัพย์"
            '
            'chkEtc
            '
            Me.chkEtc.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkEtc.Location = New System.Drawing.Point(64, 43)
            Me.chkEtc.Name = "chkEtc"
            Me.chkEtc.Size = New System.Drawing.Size(199, 16)
            Me.chkEtc.TabIndex = 1
            Me.chkEtc.Tag = "0"
            Me.chkEtc.Text = "อื่น ๆ"
            '
            'chkMechine
            '
            Me.chkMechine.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkMechine.Location = New System.Drawing.Point(64, 75)
            Me.chkMechine.Name = "chkMechine"
            Me.chkMechine.Size = New System.Drawing.Size(199, 16)
            Me.chkMechine.TabIndex = 4
            Me.chkMechine.Tag = "89"
            Me.chkMechine.Text = "ค่าเช่าเครื่องจักร "
            '
            'chkWage
            '
            Me.chkWage.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkWage.Location = New System.Drawing.Point(64, 59)
            Me.chkWage.Name = "chkWage"
            Me.chkWage.Size = New System.Drawing.Size(199, 16)
            Me.chkWage.TabIndex = 3
            Me.chkWage.Tag = "88"
            Me.chkWage.Text = "ค่าแรง"
            '
            'chkLCI
            '
            Me.chkLCI.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkLCI.Location = New System.Drawing.Point(64, 27)
            Me.chkLCI.Name = "chkLCI"
            Me.chkLCI.Size = New System.Drawing.Size(199, 16)
            Me.chkLCI.TabIndex = 0
            Me.chkLCI.Tag = "42"
            Me.chkLCI.Text = "วัสดุ"
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(72, 16)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(208, 21)
            Me.cmbStatus.TabIndex = 0
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Black
            Me.lblStatus.Location = New System.Drawing.Point(8, 17)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(56, 18)
            Me.lblStatus.TabIndex = 0
            Me.lblStatus.Text = "สถานะ"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(1115, 263)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 1
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(1035, 263)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 0
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(463, 324)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtTemp, "")
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(104, 21)
            Me.txtTemp.TabIndex = 3
            Me.txtTemp.Visible = False
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.chkShowDetail)
            Me.grbDetail.Controls.Add(Me.txtPersonReceiveCode)
            Me.grbDetail.Controls.Add(Me.lblPersonReceive)
            Me.grbDetail.Controls.Add(Me.txtPersonReceiveName)
            Me.grbDetail.Controls.Add(Me.btnPersonReceiveDialog)
            Me.grbDetail.Controls.Add(Me.txtDueDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDueDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDueDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDueDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDueDateStart)
            Me.grbDetail.Controls.Add(Me.Label2)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildSupplierGroup)
            Me.grbDetail.Controls.Add(Me.btnSpgCodeStart)
            Me.grbDetail.Controls.Add(Me.txtSpgCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSpgStart)
            Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
            Me.grbDetail.Controls.Add(Me.cmbDocStatus)
            Me.grbDetail.Controls.Add(Me.lblDocStatus)
            Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSuppliStart)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(430, 269)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'chkShowDetail
            '
            Me.chkShowDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkShowDetail.Location = New System.Drawing.Point(128, 241)
            Me.chkShowDetail.Name = "chkShowDetail"
            Me.chkShowDetail.Size = New System.Drawing.Size(128, 21)
            Me.chkShowDetail.TabIndex = 12
            Me.chkShowDetail.Text = "แสดงรายละเอียด"
            '
            'txtPersonReceiveCode
            '
            Me.Validator.SetDataType(Me.txtPersonReceiveCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPersonReceiveCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtPersonReceiveCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPersonReceiveCode, System.Drawing.Color.Empty)
            Me.txtPersonReceiveCode.Location = New System.Drawing.Point(127, 194)
            Me.Validator.SetMaxValue(Me.txtPersonReceiveCode, "")
            Me.Validator.SetMinValue(Me.txtPersonReceiveCode, "")
            Me.txtPersonReceiveCode.Name = "txtPersonReceiveCode"
            Me.Validator.SetRegularExpression(Me.txtPersonReceiveCode, "")
            Me.Validator.SetRequired(Me.txtPersonReceiveCode, False)
            Me.txtPersonReceiveCode.Size = New System.Drawing.Size(105, 21)
            Me.txtPersonReceiveCode.TabIndex = 10
            '
            'lblPersonReceive
            '
            Me.lblPersonReceive.BackColor = System.Drawing.Color.Transparent
            Me.lblPersonReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPersonReceive.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblPersonReceive.Location = New System.Drawing.Point(32, 194)
            Me.lblPersonReceive.Name = "lblPersonReceive"
            Me.lblPersonReceive.Size = New System.Drawing.Size(88, 18)
            Me.lblPersonReceive.TabIndex = 206
            Me.lblPersonReceive.Text = "ชื่อผู้รับของ"
            Me.lblPersonReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPersonReceiveName
            '
            Me.Validator.SetDataType(Me.txtPersonReceiveName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPersonReceiveName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtPersonReceiveName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPersonReceiveName, System.Drawing.Color.Empty)
            Me.txtPersonReceiveName.Location = New System.Drawing.Point(255, 194)
            Me.Validator.SetMaxValue(Me.txtPersonReceiveName, "")
            Me.Validator.SetMinValue(Me.txtPersonReceiveName, "")
            Me.txtPersonReceiveName.Name = "txtPersonReceiveName"
            Me.txtPersonReceiveName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtPersonReceiveName, "")
            Me.Validator.SetRequired(Me.txtPersonReceiveName, False)
            Me.txtPersonReceiveName.Size = New System.Drawing.Size(159, 21)
            Me.txtPersonReceiveName.TabIndex = 15
            Me.txtPersonReceiveName.TabStop = False
            '
            'btnPersonReceiveDialog
            '
            Me.btnPersonReceiveDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnPersonReceiveDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPersonReceiveDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPersonReceiveDialog.Location = New System.Drawing.Point(231, 193)
            Me.btnPersonReceiveDialog.Name = "btnPersonReceiveDialog"
            Me.btnPersonReceiveDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnPersonReceiveDialog.TabIndex = 209
            Me.btnPersonReceiveDialog.TabStop = False
            Me.btnPersonReceiveDialog.ThemedImage = CType(resources.GetObject("btnPersonReceiveDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtDueDateEnd
            '
            Me.Validator.SetDataType(Me.txtDueDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDueDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateEnd, System.Drawing.Color.Empty)
            Me.txtDueDateEnd.Location = New System.Drawing.Point(288, 39)
            Me.txtDueDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDueDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDueDateEnd, "")
            Me.txtDueDateEnd.Name = "txtDueDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDueDateEnd, "")
            Me.Validator.SetRequired(Me.txtDueDateEnd, False)
            Me.txtDueDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDueDateEnd.TabIndex = 3
            '
            'txtDueDateStart
            '
            Me.Validator.SetDataType(Me.txtDueDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDueDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDueDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDueDateStart, System.Drawing.Color.Empty)
            Me.txtDueDateStart.Location = New System.Drawing.Point(129, 39)
            Me.txtDueDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDueDateStart, "")
            Me.Validator.SetMinValue(Me.txtDueDateStart, "")
            Me.txtDueDateStart.Name = "txtDueDateStart"
            Me.Validator.SetRegularExpression(Me.txtDueDateStart, "")
            Me.Validator.SetRequired(Me.txtDueDateStart, False)
            Me.txtDueDateStart.Size = New System.Drawing.Size(99, 21)
            Me.txtDueDateStart.TabIndex = 2
            '
            'dtpDueDateStart
            '
            Me.dtpDueDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDueDateStart.Location = New System.Drawing.Point(129, 39)
            Me.dtpDueDateStart.Name = "dtpDueDateStart"
            Me.dtpDueDateStart.Size = New System.Drawing.Size(129, 21)
            Me.dtpDueDateStart.TabIndex = 6
            Me.dtpDueDateStart.TabStop = False
            '
            'dtpDueDateEnd
            '
            Me.dtpDueDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDueDateEnd.Location = New System.Drawing.Point(296, 39)
            Me.dtpDueDateEnd.Name = "dtpDueDateEnd"
            Me.dtpDueDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDueDateEnd.TabIndex = 5
            Me.dtpDueDateEnd.TabStop = False
            '
            'lblDueDateStart
            '
            Me.lblDueDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDueDateStart.Location = New System.Drawing.Point(1, 39)
            Me.lblDueDateStart.Name = "lblDueDateStart"
            Me.lblDueDateStart.Size = New System.Drawing.Size(120, 18)
            Me.lblDueDateStart.TabIndex = 37
            Me.lblDueDateStart.Text = "ตั้งแต่วันที่ครบกำหนด"
            Me.lblDueDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(262, 39)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(24, 18)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "ถึง"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkIncludeChildSupplierGroup
            '
            Me.chkIncludeChildSupplierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildSupplierGroup.Location = New System.Drawing.Point(130, 84)
            Me.chkIncludeChildSupplierGroup.Name = "chkIncludeChildSupplierGroup"
            Me.chkIncludeChildSupplierGroup.Size = New System.Drawing.Size(128, 21)
            Me.chkIncludeChildSupplierGroup.TabIndex = 5
            Me.chkIncludeChildSupplierGroup.Text = "รวมกลุ่มผู้ขายลูก"
            '
            'btnSpgCodeStart
            '
            Me.btnSpgCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSpgCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSpgCodeStart.Location = New System.Drawing.Point(232, 62)
            Me.btnSpgCodeStart.Name = "btnSpgCodeStart"
            Me.btnSpgCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnSpgCodeStart.TabIndex = 19
            Me.btnSpgCodeStart.TabStop = False
            Me.btnSpgCodeStart.ThemedImage = CType(resources.GetObject("btnSpgCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSpgCodeStart
            '
            Me.Validator.SetDataType(Me.txtSpgCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSpgCodeStart, "")
            Me.txtSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSpgCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
            Me.txtSpgCodeStart.Location = New System.Drawing.Point(129, 62)
            Me.txtSpgCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtSpgCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSpgCodeStart, "")
            Me.txtSpgCodeStart.Name = "txtSpgCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSpgCodeStart, "")
            Me.Validator.SetRequired(Me.txtSpgCodeStart, False)
            Me.txtSpgCodeStart.Size = New System.Drawing.Size(108, 21)
            Me.txtSpgCodeStart.TabIndex = 4
            '
            'lblSpgStart
            '
            Me.lblSpgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSpgStart.ForeColor = System.Drawing.Color.Black
            Me.lblSpgStart.Location = New System.Drawing.Point(33, 62)
            Me.lblSpgStart.Name = "lblSpgStart"
            Me.lblSpgStart.Size = New System.Drawing.Size(88, 18)
            Me.lblSpgStart.TabIndex = 35
            Me.lblSpgStart.Text = "กลุ่มผู้ขาย"
            Me.lblSpgStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSupplierGroupName
            '
            Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
            Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
            Me.txtSupplierGroupName.Location = New System.Drawing.Point(256, 62)
            Me.txtSupplierGroupName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtSupplierGroupName, "")
            Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
            Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
            Me.txtSupplierGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
            Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
            Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
            Me.txtSupplierGroupName.TabIndex = 36
            '
            'cmbDocStatus
            '
            Me.cmbDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbDocStatus.Location = New System.Drawing.Point(127, 219)
            Me.cmbDocStatus.Name = "cmbDocStatus"
            Me.cmbDocStatus.Size = New System.Drawing.Size(127, 21)
            Me.cmbDocStatus.TabIndex = 11
            '
            'lblDocStatus
            '
            Me.lblDocStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocStatus.ForeColor = System.Drawing.Color.Black
            Me.lblDocStatus.Location = New System.Drawing.Point(40, 219)
            Me.lblDocStatus.Name = "lblDocStatus"
            Me.lblDocStatus.Size = New System.Drawing.Size(80, 18)
            Me.lblDocStatus.TabIndex = 31
            Me.lblDocStatus.Text = "สถานะเอกสาร"
            Me.lblDocStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSuppliEndFind
            '
            Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliEndFind.Location = New System.Drawing.Point(390, 118)
            Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
            Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliEndFind.TabIndex = 21
            Me.btnSuppliEndFind.TabStop = False
            Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeEnd
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(294, 118)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
            Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtSuppliCodeEnd.TabIndex = 7
            '
            'lblSuppliEnd
            '
            Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliEnd.Location = New System.Drawing.Point(262, 118)
            Me.lblSuppliEnd.Name = "lblSuppliEnd"
            Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblSuppliEnd.TabIndex = 22
            Me.lblSuppliEnd.Text = "ถึง"
            Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSuppliStartFind
            '
            Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliStartFind.Location = New System.Drawing.Point(230, 118)
            Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
            Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliStartFind.TabIndex = 20
            Me.btnSuppliStartFind.TabStop = False
            Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeStart
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.txtSuppliCodeStart.Location = New System.Drawing.Point(127, 118)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
            Me.txtSuppliCodeStart.Size = New System.Drawing.Size(108, 21)
            Me.txtSuppliCodeStart.TabIndex = 6
            '
            'lblSuppliStart
            '
            Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliStart.Location = New System.Drawing.Point(7, 118)
            Me.lblSuppliStart.Name = "lblSuppliStart"
            Me.lblSuppliStart.Size = New System.Drawing.Size(112, 18)
            Me.lblSuppliStart.TabIndex = 19
            Me.lblSuppliStart.Text = "ผู้ขาย"
            Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(129, 163)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 21)
            Me.chkIncludeChildren.TabIndex = 9
            Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Location = New System.Drawing.Point(230, 140)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 22
            Me.btnCCCodeStart.TabStop = False
            Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCCCodeStart
            '
            Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.txtCCCodeStart.Location = New System.Drawing.Point(127, 141)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(108, 21)
            Me.txtCCCodeStart.TabIndex = 8
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(7, 141)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(112, 18)
            Me.lblCCStart.TabIndex = 14
            Me.lblCCStart.Text = "Cost Center"
            Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(254, 141)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 15
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(288, 16)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 1
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(129, 16)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateStart.TabIndex = 0
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateStart.Location = New System.Drawing.Point(129, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(129, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(296, 16)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 4
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(9, 16)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(112, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(262, 16)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 2
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
            'grbReferenceStatus
            '
            Me.grbReferenceStatus.Controls.Add(Me.chkNoReference)
            Me.grbReferenceStatus.Controls.Add(Me.chkPatialReference)
            Me.grbReferenceStatus.Controls.Add(Me.chkFullReference)
            Me.grbReferenceStatus.Location = New System.Drawing.Point(19, 103)
            Me.grbReferenceStatus.Name = "grbReferenceStatus"
            Me.grbReferenceStatus.Size = New System.Drawing.Size(422, 96)
            Me.grbReferenceStatus.TabIndex = 208
            Me.grbReferenceStatus.TabStop = False
            Me.grbReferenceStatus.Text = "สถานะการอ้างอิง"
            '
            'chkFullReference
            '
            Me.chkFullReference.AutoSize = True
            Me.chkFullReference.Location = New System.Drawing.Point(50, 21)
            Me.chkFullReference.Name = "chkFullReference"
            Me.chkFullReference.Size = New System.Drawing.Size(74, 17)
            Me.chkFullReference.TabIndex = 0
            Me.chkFullReference.Text = "อ้างอิงแล้ว"
            Me.chkFullReference.UseVisualStyleBackColor = True
            '
            'chkPatialReference
            '
            Me.chkPatialReference.AutoSize = True
            Me.chkPatialReference.Location = New System.Drawing.Point(50, 44)
            Me.chkPatialReference.Name = "chkPatialReference"
            Me.chkPatialReference.Size = New System.Drawing.Size(91, 17)
            Me.chkPatialReference.TabIndex = 1
            Me.chkPatialReference.Text = "อ้างอิงบางส่วน"
            Me.chkPatialReference.UseVisualStyleBackColor = True
            '
            'chkNoReference
            '
            Me.chkNoReference.AutoSize = True
            Me.chkNoReference.Location = New System.Drawing.Point(50, 67)
            Me.chkNoReference.Name = "chkNoReference"
            Me.chkNoReference.Size = New System.Drawing.Size(92, 17)
            Me.chkNoReference.TabIndex = 2
            Me.chkNoReference.Text = "ยังไม่ถูกอ้างอิง"
            Me.chkNoReference.UseVisualStyleBackColor = True
            '
            'Rpt276FilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "Rpt276FilterSubPanel"
            Me.Size = New System.Drawing.Size(1219, 299)
            Me.grbMaster.ResumeLayout(False)
            Me.grbMaster.PerformLayout()
            Me.grbRank.ResumeLayout(False)
            Me.grbRank.PerformLayout()
            Me.grbDisplay.ResumeLayout(False)
            Me.grbTypeDisplay.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbReferenceStatus.ResumeLayout(False)
            Me.grbReferenceStatus.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblCostcenter}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblSuppliStart}")
            Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)


            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            'ตั้งแต่วันที่ครบกำหนด: Start
            Me.lblDueDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblDueDateStart}")
            Me.Validator.SetDisplayName(txtDueDateStart, lblDueDateStart.Text)

            'ตั้งแต่วันที่ครบกำหนด: End
            Me.Label2.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDueDateEnd, lblDocDateEnd.Text)


            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.grbDetail}")

            Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblDocStatus}")

            Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblSpgStart}")
            Me.chkIncludeChildSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.chkIncludeChildSupplierGroup}")

            'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt274FilterSubPanel.cbCancel}"))
            'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt274FilterSubPanel.cbAll}"))
            Me.cmbDocStatus.SelectedIndex = 0
            Me.grbDisplay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.grbDisplay}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.lblStatus}")
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.cmbDocAll}")) 'เอกสารซื้อสินค้า/บริการทั้งหมด
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.cmbDocApprove}")) 'เอกสารซื้อสินค้า/บริการที่อนุมัติแล้ว
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.cmbDocNoApprove}")) 'เอกสารซื้อสินค้า/บริการที่ยังไม่อนุมัติ
            Me.cmbStatus.SelectedIndex = 0

            Me.grbTypeDisplay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.grbTypeDisplay}") 'การแสดงผลตามประเภท
            Me.chkLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.chkLCI}") 'วัสดุ
            Me.chkEtc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.chkEtc}") 'อื่น ๆ
            Me.chkWage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.chkWage}") 'ค่าแรง
            Me.chkMechine.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.chkMechine}") 'ค่าเช่าเครื่องจักร 
            Me.chkAssets.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.chkAssets}") 'สินทรัพย์
            Me.chkNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.chkNote}") 'หมายเหตุ

            'Me.ToolTip1.SetToolTip(Me.txtDocStart, "คีย์รหัส prefix หรือใส่ comma (""GR%"" หรือ ""GR550001,GR550002"")")
            'Me.ToolTip1.SetToolTip(Me.txtPoStart, "คีย์รหัส prefix หรือใส่ comma (""PO%"" หรือ ""PO550001,PO550002"")")

            Me.ToolTip1.SetToolTip(Me.txtDocStart, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.txtDocStartToolTip}"))
            Me.ToolTip1.SetToolTip(Me.txtPoStart, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.txtPoStartTooltip}"))

            Me.lblPOEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblDocEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Label2.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            'Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.lblSuppliEnd}")
            Me.lblPersonReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.lblPersonReceive}")
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Global.chkIncludeChildren}")
            Me.chkShowDetail.Text = Me.StringParserService.Parse("${res:Global.ShowDetail}")
            Me.lblDocStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.lblDocStart}")
            Me.lblPOStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.lblPOStart}")
            Me.lblPORefStatus.Text = Me.StringParserService.Parse("${res:Global.Status}")
            Me.grbRank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.grbDetail}")

            'Me.grbReferenceStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.grbReferenceStatus}") 'สถานะการอ้างอิง
            'Me.chkFullReference.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.chkFullReference}") 'อ้างอิงแล้ว
            'Me.chkPatialReference.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.chkPatialReference}") 'อ้างอิงบางส่วน
            'Me.chkNoReference.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.chkNoReference}") 'ยังไม่ถูกอ้างอิง

        End Sub
#End Region

#Region "Member"
        Private m_cc As Costcenter
        Private m_supplier As Supplier
        Private m_PersonReceive As Employee
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        Private m_DueDateEnd As Date
        Private m_DueDateStart As Date
        Private m_suppliergroup As SupplierGroup
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
        Public Property Costcenter() As Costcenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As Costcenter)
                m_cc = Value
            End Set
        End Property
        Public Property Supplier() As Supplier
            Get
                Return m_supplier
            End Get
            Set(ByVal Value As Supplier)
                m_supplier = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date
            Get
                Return m_DocDateEnd
            End Get
            Set(ByVal Value As Date)
                m_DocDateEnd = Value
            End Set
        End Property

        Public Property DocDateStart() As Date
            Get
                Return m_DocDateStart
            End Get
            Set(ByVal Value As Date)
                m_DocDateStart = Value
            End Set
        End Property
        Public Property DueDateEnd() As Date
            Get
                Return m_DueDateEnd
            End Get
            Set(ByVal Value As Date)
                m_DueDateEnd = Value
            End Set
        End Property

        Public Property DueDateStart() As Date
            Get
                Return m_DueDateStart
            End Get
            Set(ByVal Value As Date)
                m_DueDateStart = Value
            End Set
        End Property
        Public Property SupplierGroup() As SupplierGroup
            Get
                Return m_suppliergroup
            End Get
            Set(ByVal Value As SupplierGroup)
                m_suppliergroup = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub RegisterDropdown()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocStatus, "goodsreceipt_status", True)
            Me.cmbDocStatus.SelectedIndex = 0

            cmbPORefStatus.Items.Add(New IdValuePair(0, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.cmbPORefStatus.NotInitial}")))
            cmbPORefStatus.Items.Add(New IdValuePair(0, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.cmbPORefStatus.OnlyReferencedPO}")))
            cmbPORefStatus.Items.Add(New IdValuePair(0, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.cmbPORefStatus.OnlyNOtReferencedPO}")))
            Me.cmbPORefStatus.SelectedIndex = 0
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

            Me.Supplier = New Supplier
            Me.Costcenter = New Costcenter
            Me.txtPersonReceiveCode.Text = ""
            Me.txtPersonReceiveName.Text = ""
            Me.m_PersonReceive = New Employee
            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))

            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.DueDateStart = dtStart
            Me.txtDueDateStart.Text = MinDateToNull(Me.DueDateStart, "")
            Me.dtpDueDateStart.Value = Me.DueDateStart

            Me.DueDateEnd = Date.Now
            Me.txtDueDateEnd.Text = MinDateToNull(Me.DueDateEnd, "")
            Me.dtpDueDateEnd.Value = Me.DueDateEnd

            Me.SupplierGroup = New SupplierGroup

            For Each chk As CheckBox In Me.grbTypeDisplay.Controls
                chk.Checked = False
            Next

            Me.cmbPORefStatus.SelectedIndex = 0

            Me.chkFullReference.Checked = True
            Me.chkPatialReference.Checked = True
            Me.chkNoReference.Checked = True

        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(23) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("duedatestart", IIf(Me.DueDateStart.Equals(Date.MinValue), DBNull.Value, Me.DueDateStart))
            arr(3) = New Filter("duedateend", IIf(Me.DueDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DueDateEnd))
            arr(4) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(5) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(6) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(7) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(8) = New Filter("status", IIf(cmbDocStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbDocStatus.SelectedItem, IdValuePair).Id)) 'cmbDocStatus.SelectedIndex) ' IIf(cmbDocStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbDocStatus.SelectedItem, IdValuePair).Id))
            arr(9) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(10) = New Filter("SupplierGroupID", Me.ValidIdOrDBNull(m_suppliergroup))
            arr(11) = New Filter("IncludeChildSupplierGroup", Me.chkIncludeChildSupplierGroup.Checked)
            arr(12) = New Filter("ApproveStatus", Me.cmbStatus.SelectedIndex)
            arr(13) = New Filter("PersonReceive", IIf(Me.m_PersonReceive.Valid, Me.m_PersonReceive.Id, DBNull.Value))
            arr(14) = New Filter("ShowDetail", Me.chkShowDetail.Checked)
            If GetChekType() = "" Then
                arr(15) = New Filter("Type", DBNull.Value)
            Else
                arr(15) = New Filter("Type", GetChekType())
            End If

            arr(16) = New Filter("grCodeStart", IIf(txtDocStart.TextLength > 0, txtDocStart.Text, DBNull.Value))
            arr(17) = New Filter("grCodeEnd", IIf(txtDocEnd.TextLength > 0, txtDocEnd.Text, DBNull.Value))
            arr(18) = New Filter("poCodeStart", IIf(txtPoStart.TextLength > 0, txtPoStart.Text, DBNull.Value))
            arr(19) = New Filter("poCodeEnd", IIf(txtPoEnd.TextLength > 0, txtPoEnd.Text, DBNull.Value))
            arr(20) = New Filter("poRefStatus", Me.cmbPORefStatus.SelectedIndex)

            arr(21) = New Filter("FullReference", Me.chkFullReference.Checked)
            arr(22) = New Filter("PatialReference", Me.chkPatialReference.Checked)
            arr(23) = New Filter("NoReference", Me.chkNoReference.Checked)

            Return arr
        End Function

        Private Function GetChekType() As String
            Dim type As String = ""

            Dim arrChk As New ArrayList
            For Each chk As CheckBox In Me.grbTypeDisplay.Controls
                If chk.Checked Then
                    arrChk.Add(chk.Tag)
                End If
            Next

            type = String.Join(",", arrChk.ToArray)

            'If Me.chkLCI.Checked = False And Me.chkEtc.Checked = False And Me.chkWage.Checked = False And Me.chkMechine.Checked = False And Me.chkAssets.Checked = False Then
            '  type &= ""
            'Else

            '  If Me.chkLCI.Checked Then
            '    type &= "42"
            '  End If
            '  If Me.chkEtc.Checked Then
            '    If Len(type) > 0 Then
            '      type &= ","
            '    End If
            '    type &= "0"
            '  End If

            '  If Me.chkWage.Checked Then
            '    If Len(type) > 0 Then
            '      type &= ","
            '    End If
            '    type &= "88"
            '  End If
            '  If Me.chkMechine.Checked Then
            '    If Len(type) > 0 Then
            '      type &= ","
            '    End If
            '    type &= "89"
            '  End If
            '  If Me.chkAssets.Checked Then
            '    If Len(type) > 0 Then
            '      type &= ","
            '    End If
            '    type &= "28"
            '  End If
            '  If Me.chkTool.Checked Then
            '    If Len(type) > 0 Then
            '      type &= ","
            '    End If
            '    type &= "19"
            '  End If
            'End If

            Return type
        End Function


        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            'Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "IReportFilterSubPanel"
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'Status
      dpi = New DocPrintingItem
      dpi.Mapping = "Status"
      dpi.Value = Me.cmbDocStatus.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Month
      dpi = New DocPrintingItem
      dpi.Mapping = "Month"
      dpi.Value = "" 'Me.cmbMonth.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Year
      dpi = New DocPrintingItem
      dpi.Mapping = "Year"
      dpi.Value = "" 'Me.cmbYear.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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

      'SupplierStart
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierStart"
      dpi.Value = Me.txtSuppliCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SupplierEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierEnd"
      dpi.Value = Me.txtSuppliCodeEnd.Text
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

      'CostCenter Start
      dpi = New DocPrintingItem
      dpi.Mapping = "CostcenterStart"
      dpi.Value = Me.txtCCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SupplierGroup Start
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierGroupCodeStart"
      dpi.Value = Me.txtSpgCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox ChildSupplierGroupInclude
      If Me.chkIncludeChildSupplierGroup.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "childSupplierGroupincluded"
        dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt276FilterSubPanel.childSupplierGroupincluded}")
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'ApproveStatus
      dpi = New DocPrintingItem
      dpi.Mapping = "ApproveStatus"
      dpi.Value = Me.cmbStatus.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'CheckBox LCI
      If Me.chkLCI.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "chkLCI"
        dpi.Value = "(แสดงประเภทวัสดุ)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CheckBox Etc
      If Me.chkEtc.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "chkEtc"
        dpi.Value = "(แสดงประเภทอื่นๆ)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CheckBox Wage
      If Me.chkWage.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "chkWage"
        dpi.Value = "(แสดงประเภทค่าแรง)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CheckBox Mechine
      If Me.chkMechine.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "chkMechine"
        dpi.Value = "(แสดงประเภทค่าเชาเครื่องจักร)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CheckBox Assets
      If Me.chkAssets.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "chkAssets"
        dpi.Value = "(แสดงประเภทค่าเชาเครื่องจักร)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CheckBox Tool
      If Me.chkTool.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "chkTool"
        dpi.Value = "(แสดงประเภทเครื่องมือ)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDueDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDueDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler dtpDueDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDueDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcccodestart"
          Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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

          '************************* start
        Case "dtpduedatestart"
          If Not Me.DueDateStart.Equals(dtpDueDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDateStart.Text = MinDateToNull(dtpDueDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DueDateStart = dtpDueDateStart.Value
            End If
          End If
        Case "txtduedatestart"
          m_dateSetting = True
          If Not Me.txtDueDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDueDateStart.Text)
            If Not Me.DueDateStart.Equals(theDate) Then
              dtpDueDateStart.Value = theDate
              Me.DueDateStart = dtpDueDateStart.Value
            End If
          Else
            Me.dtpDueDateStart.Value = Date.Now
            Me.DueDateStart = Date.MinValue
          End If
          m_dateSetting = False
          '************************* start

          '************************* End
        Case "dtpduedateend"
          If Not Me.DueDateEnd.Equals(dtpDueDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDateEnd.Text = MinDateToNull(dtpDueDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DueDateEnd = dtpDueDateEnd.Value
            End If
          End If
        Case "txtduedateend"
          m_dateSetting = True
          If Not Me.txtDueDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DueDateEnd.Equals(theDate) Then
              dtpDueDateEnd.Value = theDate
              Me.DueDateEnd = dtpDueDateEnd.Value
            End If
          Else
            Me.dtpDueDateEnd.Value = Date.Now
            Me.DueDateEnd = Date.MinValue
          End If
          m_dateSetting = False
          '************************* End

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        ' Supplier
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsupplicodestart", "txtsupplicodeend"
                Return True
            End Select
          End If
        End If
        ' Costcenter
        If data.GetDataPresent((New Costcenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcccodestart", "txtcccodeend"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtpersonreceivecode", "txtpersonreceivename"
              Return True
          End Select
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' Supplier
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsupplicodestart"
              Me.SetSupplierStartDialog(entity)

            Case "txtsupplicodeend"
              Me.SetSupplierEndDialog(entity)

          End Select
        End If
      End If
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower
          Case "txtpersonreceivecode", "txtpersonreceivename"
            Me.SetToCCPerson(entity)
        End Select
      End If
      ' Costcenter
      If data.GetDataPresent((New Costcenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
        Dim entity As New Costcenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcostcentercodestart"
              Me.SetCCCodeStartDialog(entity)

            Case "txtcostcentercodeend"
              Me.SetCCCodeStartDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    ' Supplier
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsupplistartfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

        Case "btnsuppliendfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

      End Select
    End Sub
    Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeStart.Text = e.Code
      Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.Supplier)
    End Sub
    Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeEnd.Text = e.Code
      Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.Supplier)
    End Sub
    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncccodestart"
          myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    ' SupplierGroup
    Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnspgcodestart"
          myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSpgCodeStartDialog)
      End Select
    End Sub
    Private Sub SetSpgCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtSpgCodeStart.Text = e.Code
      SupplierGroup.GetSupplierGroup(txtSpgCodeStart, txtSupplierGroupName, m_suppliergroup, True)
    End Sub
    Private Sub txtpersonreceiveCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPersonReceiveCode.Validated, txtDocStart.Validated, txtDocEnd.Validated, txtPoStart.Validated, txtPoEnd.Validated
      Employee.GetEmployee(txtPersonReceiveCode, txtPersonReceiveName, Me.m_PersonReceive)
    End Sub
    Private Sub btnpersonreceiveDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersonReceiveDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToCCPerson)
    End Sub
    Private Sub SetToCCPerson(ByVal e As ISimpleEntity)
      Me.txtPersonReceiveCode.Text = e.Code
      Employee.GetEmployee(txtPersonReceiveCode, txtPersonReceiveName, Me.m_PersonReceive)
    End Sub
#End Region

    Private Sub btnFiler_Click(sender As System.Object, e As System.EventArgs) Handles ibtnGR1.Click, ibtnGR2.Click, ibtnPO1.Click, ibtnPO2.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Gui.Components.ImageButton).Name.ToLower
        Case ibtnGR1.Name.ToLower
          myEntityPanelService.OpenListDialog(New GoodsReceipt, AddressOf SetGRStartDialog)
        Case ibtnGR2.Name.ToLower
          myEntityPanelService.OpenListDialog(New GoodsReceipt, AddressOf SetGREndDialog)
        Case ibtnPO1.Name.ToLower
          myEntityPanelService.OpenListDialog(New PO, AddressOf SetPOStartDialog)
        Case ibtnPO2.Name.ToLower
          myEntityPanelService.OpenListDialog(New PO, AddressOf SetPOEndDialog)
      End Select
    End Sub
    Private Sub SetGRStartDialog(ByVal e As ISimpleEntity)
      Me.txtDocStart.Text = e.Code
    End Sub
    Private Sub SetGREndDialog(ByVal e As ISimpleEntity)
      Me.txtDocEnd.Text = e.Code
    End Sub
    Private Sub SetPOStartDialog(ByVal e As ISimpleEntity)
      Me.txtPoStart.Text = e.Code
    End Sub
    Private Sub SetPOEndDialog(ByVal e As ISimpleEntity)
      Me.txtPoEnd.Text = e.Code
    End Sub
  End Class
End Namespace

