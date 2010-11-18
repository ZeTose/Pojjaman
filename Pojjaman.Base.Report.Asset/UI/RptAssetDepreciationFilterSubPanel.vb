Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptAssetDepreciationFilterSubPanel
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
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents btnCCEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblCCEnd As System.Windows.Forms.Label
        Friend WithEvents btnCCStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtAssetCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblAssetEnd As System.Windows.Forms.Label
        Friend WithEvents txtAssetCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblAssetStart As System.Windows.Forms.Label
        Friend WithEvents btnAssetEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAssetStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAssetTypeCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents btnAssetTypeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAssetTypeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblAssetTypeEnd As System.Windows.Forms.Label
        Friend WithEvents txtAssetTypeCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblAssetTypeStart As System.Windows.Forms.Label
        Friend WithEvents txtAssetAcctCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents btnAssetAcctEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAssetAcctStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblAssetAcctEnd As System.Windows.Forms.Label
        Friend WithEvents txtAssetAcctCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblAssetAcctStart As System.Windows.Forms.Label
        Friend WithEvents chkOption As System.Windows.Forms.CheckBox
        Friend WithEvents lblPeriodEnd As System.Windows.Forms.Label
        Friend WithEvents lblYearAcct As System.Windows.Forms.Label
        Friend WithEvents lblPeriodStart As System.Windows.Forms.Label
        Friend WithEvents cmbPeriodEnd As System.Windows.Forms.ComboBox
        Friend WithEvents cmbYearAcct As System.Windows.Forms.ComboBox
        Friend WithEvents KeepKeyCombo1 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
        Friend WithEvents chkDoubleDeclining As System.Windows.Forms.CheckBox
        Friend WithEvents chkStraightLine As System.Windows.Forms.CheckBox
        Friend WithEvents chkAssetShowAll As System.Windows.Forms.CheckBox
        Friend WithEvents cmbPeriodStart As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptAssetDepreciationFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.KeepKeyCombo1 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
            Me.txtTemp = New System.Windows.Forms.TextBox()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.chkDoubleDeclining = New System.Windows.Forms.CheckBox()
            Me.chkStraightLine = New System.Windows.Forms.CheckBox()
            Me.cmbPeriodEnd = New System.Windows.Forms.ComboBox()
            Me.lblPeriodEnd = New System.Windows.Forms.Label()
            Me.cmbYearAcct = New System.Windows.Forms.ComboBox()
            Me.lblYearAcct = New System.Windows.Forms.Label()
            Me.cmbPeriodStart = New System.Windows.Forms.ComboBox()
            Me.lblPeriodStart = New System.Windows.Forms.Label()
            Me.chkOption = New System.Windows.Forms.CheckBox()
            Me.btnCCEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCCCodeEnd = New System.Windows.Forms.TextBox()
            Me.lblCCEnd = New System.Windows.Forms.Label()
            Me.btnCCStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
            Me.lblCCStart = New System.Windows.Forms.Label()
            Me.btnAssetStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAssetEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtAssetCodeEnd = New System.Windows.Forms.TextBox()
            Me.lblAssetEnd = New System.Windows.Forms.Label()
            Me.txtAssetCodeStart = New System.Windows.Forms.TextBox()
            Me.lblAssetStart = New System.Windows.Forms.Label()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.txtAssetTypeCodeEnd = New System.Windows.Forms.TextBox()
            Me.btnAssetTypeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAssetTypeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblAssetTypeEnd = New System.Windows.Forms.Label()
            Me.txtAssetTypeCodeStart = New System.Windows.Forms.TextBox()
            Me.lblAssetTypeStart = New System.Windows.Forms.Label()
            Me.txtAssetAcctCodeEnd = New System.Windows.Forms.TextBox()
            Me.btnAssetAcctEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAssetAcctStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblAssetAcctEnd = New System.Windows.Forms.Label()
            Me.txtAssetAcctCodeStart = New System.Windows.Forms.TextBox()
            Me.lblAssetAcctStart = New System.Windows.Forms.Label()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.chkAssetShowAll = New System.Windows.Forms.CheckBox()
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.KeepKeyCombo1)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(472, 290)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ค้นหา"
            '
            'KeepKeyCombo1
            '
            Me.KeepKeyCombo1.FormattingEnabled = True
            Me.KeepKeyCombo1.Location = New System.Drawing.Point(222, 319)
            Me.KeepKeyCombo1.Name = "KeepKeyCombo1"
            Me.KeepKeyCombo1.Size = New System.Drawing.Size(121, 21)
            Me.KeepKeyCombo1.TabIndex = 4
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(488, 32)
            Me.txtTemp.MaxLength = 255
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
            Me.grbDetail.Controls.Add(Me.chkAssetShowAll)
            Me.grbDetail.Controls.Add(Me.chkDoubleDeclining)
            Me.grbDetail.Controls.Add(Me.chkStraightLine)
            Me.grbDetail.Controls.Add(Me.cmbPeriodEnd)
            Me.grbDetail.Controls.Add(Me.lblPeriodEnd)
            Me.grbDetail.Controls.Add(Me.cmbYearAcct)
            Me.grbDetail.Controls.Add(Me.lblYearAcct)
            Me.grbDetail.Controls.Add(Me.cmbPeriodStart)
            Me.grbDetail.Controls.Add(Me.lblPeriodStart)
            Me.grbDetail.Controls.Add(Me.chkOption)
            Me.grbDetail.Controls.Add(Me.btnCCEndFind)
            Me.grbDetail.Controls.Add(Me.txtCCCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblCCEnd)
            Me.grbDetail.Controls.Add(Me.btnCCStartFind)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.btnAssetStartFind)
            Me.grbDetail.Controls.Add(Me.btnAssetEndFind)
            Me.grbDetail.Controls.Add(Me.txtAssetCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblAssetEnd)
            Me.grbDetail.Controls.Add(Me.txtAssetCodeStart)
            Me.grbDetail.Controls.Add(Me.lblAssetStart)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtAssetTypeCodeEnd)
            Me.grbDetail.Controls.Add(Me.btnAssetTypeEndFind)
            Me.grbDetail.Controls.Add(Me.btnAssetTypeStartFind)
            Me.grbDetail.Controls.Add(Me.lblAssetTypeEnd)
            Me.grbDetail.Controls.Add(Me.txtAssetTypeCodeStart)
            Me.grbDetail.Controls.Add(Me.lblAssetTypeStart)
            Me.grbDetail.Controls.Add(Me.txtAssetAcctCodeEnd)
            Me.grbDetail.Controls.Add(Me.btnAssetAcctEndFind)
            Me.grbDetail.Controls.Add(Me.btnAssetAcctStartFind)
            Me.grbDetail.Controls.Add(Me.lblAssetAcctEnd)
            Me.grbDetail.Controls.Add(Me.txtAssetAcctCodeStart)
            Me.grbDetail.Controls.Add(Me.lblAssetAcctStart)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(440, 236)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'chkDoubleDeclining
            '
            Me.chkDoubleDeclining.Location = New System.Drawing.Point(296, 208)
            Me.chkDoubleDeclining.Name = "chkDoubleDeclining"
            Me.chkDoubleDeclining.Size = New System.Drawing.Size(128, 24)
            Me.chkDoubleDeclining.TabIndex = 39
            Me.chkDoubleDeclining.Text = "วิธียอดลดลงทวีคูณ"
            '
            'chkStraightLine
            '
            Me.chkStraightLine.Checked = True
            Me.chkStraightLine.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkStraightLine.Location = New System.Drawing.Point(296, 188)
            Me.chkStraightLine.Name = "chkStraightLine"
            Me.chkStraightLine.Size = New System.Drawing.Size(128, 24)
            Me.chkStraightLine.TabIndex = 38
            Me.chkStraightLine.Text = "วิธีเส้นตรง"
            '
            'cmbPeriodEnd
            '
            Me.cmbPeriodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbPeriodEnd.Location = New System.Drawing.Point(296, 40)
            Me.cmbPeriodEnd.Name = "cmbPeriodEnd"
            Me.cmbPeriodEnd.Size = New System.Drawing.Size(121, 21)
            Me.cmbPeriodEnd.TabIndex = 3
            '
            'lblPeriodEnd
            '
            Me.lblPeriodEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPeriodEnd.ForeColor = System.Drawing.Color.Black
            Me.lblPeriodEnd.Location = New System.Drawing.Point(264, 40)
            Me.lblPeriodEnd.Name = "lblPeriodEnd"
            Me.lblPeriodEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblPeriodEnd.TabIndex = 37
            Me.lblPeriodEnd.Text = "ถึง"
            Me.lblPeriodEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmbYearAcct
            '
            Me.cmbYearAcct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbYearAcct.Location = New System.Drawing.Point(136, 16)
            Me.cmbYearAcct.Name = "cmbYearAcct"
            Me.cmbYearAcct.Size = New System.Drawing.Size(121, 21)
            Me.cmbYearAcct.TabIndex = 0
            '
            'lblYearAcct
            '
            Me.lblYearAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblYearAcct.ForeColor = System.Drawing.Color.Black
            Me.lblYearAcct.Location = New System.Drawing.Point(24, 16)
            Me.lblYearAcct.Name = "lblYearAcct"
            Me.lblYearAcct.Size = New System.Drawing.Size(104, 18)
            Me.lblYearAcct.TabIndex = 32
            Me.lblYearAcct.Text = "ปีภาษี"
            Me.lblYearAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbPeriodStart
            '
            Me.cmbPeriodStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbPeriodStart.Location = New System.Drawing.Point(136, 40)
            Me.cmbPeriodStart.Name = "cmbPeriodStart"
            Me.cmbPeriodStart.Size = New System.Drawing.Size(121, 21)
            Me.cmbPeriodStart.TabIndex = 2
            '
            'lblPeriodStart
            '
            Me.lblPeriodStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPeriodStart.ForeColor = System.Drawing.Color.Black
            Me.lblPeriodStart.Location = New System.Drawing.Point(24, 40)
            Me.lblPeriodStart.Name = "lblPeriodStart"
            Me.lblPeriodStart.Size = New System.Drawing.Size(104, 18)
            Me.lblPeriodStart.TabIndex = 35
            Me.lblPeriodStart.Text = "งวดบัญชี"
            Me.lblPeriodStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkOption
            '
            Me.chkOption.Checked = True
            Me.chkOption.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkOption.Location = New System.Drawing.Point(296, 16)
            Me.chkOption.Name = "chkOption"
            Me.chkOption.Size = New System.Drawing.Size(128, 24)
            Me.chkOption.TabIndex = 1
            Me.chkOption.Text = "งวดบัญชี"
            '
            'btnCCEndFind
            '
            Me.btnCCEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCEndFind.Location = New System.Drawing.Point(392, 160)
            Me.btnCCEndFind.Name = "btnCCEndFind"
            Me.btnCCEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnCCEndFind.TabIndex = 31
            Me.btnCCEndFind.TabStop = False
            Me.btnCCEndFind.ThemedImage = CType(resources.GetObject("btnCCEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCCCodeEnd
            '
            Me.Validator.SetDataType(Me.txtCCCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCodeEnd, "")
            Me.txtCCCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCCodeEnd, System.Drawing.Color.Empty)
            Me.txtCCCodeEnd.Location = New System.Drawing.Point(296, 160)
            Me.Validator.SetMinValue(Me.txtCCCodeEnd, "")
            Me.txtCCCodeEnd.Name = "txtCCCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtCCCodeEnd, "")
            Me.Validator.SetRequired(Me.txtCCCodeEnd, False)
            Me.txtCCCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeEnd.TabIndex = 13
            '
            'lblCCEnd
            '
            Me.lblCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCEnd.ForeColor = System.Drawing.Color.Black
            Me.lblCCEnd.Location = New System.Drawing.Point(264, 160)
            Me.lblCCEnd.Name = "lblCCEnd"
            Me.lblCCEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblCCEnd.TabIndex = 29
            Me.lblCCEnd.Text = "ถึง"
            Me.lblCCEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnCCStartFind
            '
            Me.btnCCStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCStartFind.Location = New System.Drawing.Point(232, 160)
            Me.btnCCStartFind.Name = "btnCCStartFind"
            Me.btnCCStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnCCStartFind.TabIndex = 28
            Me.btnCCStartFind.TabStop = False
            Me.btnCCStartFind.ThemedImage = CType(resources.GetObject("btnCCStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCCCodeStart
            '
            Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.txtCCCodeStart.Location = New System.Drawing.Point(136, 160)
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 12
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(32, 160)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(96, 18)
            Me.lblCCStart.TabIndex = 26
            Me.lblCCStart.Text = "ตั้งแต่ CostCenter"
            Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnAssetStartFind
            '
            Me.btnAssetStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAssetStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAssetStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAssetStartFind.Location = New System.Drawing.Point(232, 136)
            Me.btnAssetStartFind.Name = "btnAssetStartFind"
            Me.btnAssetStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAssetStartFind.TabIndex = 24
            Me.btnAssetStartFind.TabStop = False
            Me.btnAssetStartFind.ThemedImage = CType(resources.GetObject("btnAssetStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAssetEndFind
            '
            Me.btnAssetEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAssetEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAssetEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAssetEndFind.Location = New System.Drawing.Point(392, 136)
            Me.btnAssetEndFind.Name = "btnAssetEndFind"
            Me.btnAssetEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAssetEndFind.TabIndex = 23
            Me.btnAssetEndFind.TabStop = False
            Me.btnAssetEndFind.ThemedImage = CType(resources.GetObject("btnAssetEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAssetCodeEnd
            '
            Me.Validator.SetDataType(Me.txtAssetCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAssetCodeEnd, "")
            Me.txtAssetCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAssetCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAssetCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAssetCodeEnd, System.Drawing.Color.Empty)
            Me.txtAssetCodeEnd.Location = New System.Drawing.Point(296, 136)
            Me.Validator.SetMinValue(Me.txtAssetCodeEnd, "")
            Me.txtAssetCodeEnd.Name = "txtAssetCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtAssetCodeEnd, "")
            Me.Validator.SetRequired(Me.txtAssetCodeEnd, False)
            Me.txtAssetCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtAssetCodeEnd.TabIndex = 11
            '
            'lblAssetEnd
            '
            Me.lblAssetEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAssetEnd.ForeColor = System.Drawing.Color.Black
            Me.lblAssetEnd.Location = New System.Drawing.Point(264, 136)
            Me.lblAssetEnd.Name = "lblAssetEnd"
            Me.lblAssetEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblAssetEnd.TabIndex = 9
            Me.lblAssetEnd.Text = "ถึง"
            Me.lblAssetEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtAssetCodeStart
            '
            Me.Validator.SetDataType(Me.txtAssetCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAssetCodeStart, "")
            Me.txtAssetCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAssetCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAssetCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAssetCodeStart, System.Drawing.Color.Empty)
            Me.txtAssetCodeStart.Location = New System.Drawing.Point(136, 136)
            Me.Validator.SetMinValue(Me.txtAssetCodeStart, "")
            Me.txtAssetCodeStart.Name = "txtAssetCodeStart"
            Me.Validator.SetRegularExpression(Me.txtAssetCodeStart, "")
            Me.Validator.SetRequired(Me.txtAssetCodeStart, False)
            Me.txtAssetCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtAssetCodeStart.TabIndex = 10
            '
            'lblAssetStart
            '
            Me.lblAssetStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAssetStart.ForeColor = System.Drawing.Color.Black
            Me.lblAssetStart.Location = New System.Drawing.Point(40, 136)
            Me.lblAssetStart.Name = "lblAssetStart"
            Me.lblAssetStart.Size = New System.Drawing.Size(88, 18)
            Me.lblAssetStart.TabIndex = 6
            Me.lblAssetStart.Text = "รหัสสินทรัพย์:"
            Me.lblAssetStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(296, 64)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(86, 21)
            Me.txtDocDateEnd.TabIndex = 5
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Enabled = False
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(136, 64)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(83, 21)
            Me.txtDocDateStart.TabIndex = 4
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Enabled = False
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateStart.Location = New System.Drawing.Point(136, 64)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Enabled = False
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(296, 64)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 64)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(120, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่วันที่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(264, 64)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtAssetTypeCodeEnd
            '
            Me.Validator.SetDataType(Me.txtAssetTypeCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAssetTypeCodeEnd, "")
            Me.txtAssetTypeCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAssetTypeCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAssetTypeCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAssetTypeCodeEnd, System.Drawing.Color.Empty)
            Me.txtAssetTypeCodeEnd.Location = New System.Drawing.Point(296, 112)
            Me.Validator.SetMinValue(Me.txtAssetTypeCodeEnd, "")
            Me.txtAssetTypeCodeEnd.Name = "txtAssetTypeCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtAssetTypeCodeEnd, "")
            Me.Validator.SetRequired(Me.txtAssetTypeCodeEnd, False)
            Me.txtAssetTypeCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtAssetTypeCodeEnd.TabIndex = 9
            '
            'btnAssetTypeEndFind
            '
            Me.btnAssetTypeEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAssetTypeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAssetTypeEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAssetTypeEndFind.Location = New System.Drawing.Point(392, 112)
            Me.btnAssetTypeEndFind.Name = "btnAssetTypeEndFind"
            Me.btnAssetTypeEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAssetTypeEndFind.TabIndex = 23
            Me.btnAssetTypeEndFind.TabStop = False
            Me.btnAssetTypeEndFind.ThemedImage = CType(resources.GetObject("btnAssetTypeEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAssetTypeStartFind
            '
            Me.btnAssetTypeStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAssetTypeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAssetTypeStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAssetTypeStartFind.Location = New System.Drawing.Point(232, 112)
            Me.btnAssetTypeStartFind.Name = "btnAssetTypeStartFind"
            Me.btnAssetTypeStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAssetTypeStartFind.TabIndex = 24
            Me.btnAssetTypeStartFind.TabStop = False
            Me.btnAssetTypeStartFind.ThemedImage = CType(resources.GetObject("btnAssetTypeStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblAssetTypeEnd
            '
            Me.lblAssetTypeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAssetTypeEnd.ForeColor = System.Drawing.Color.Black
            Me.lblAssetTypeEnd.Location = New System.Drawing.Point(264, 112)
            Me.lblAssetTypeEnd.Name = "lblAssetTypeEnd"
            Me.lblAssetTypeEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblAssetTypeEnd.TabIndex = 9
            Me.lblAssetTypeEnd.Text = "ถึง"
            Me.lblAssetTypeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtAssetTypeCodeStart
            '
            Me.Validator.SetDataType(Me.txtAssetTypeCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAssetTypeCodeStart, "")
            Me.txtAssetTypeCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAssetTypeCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAssetTypeCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAssetTypeCodeStart, System.Drawing.Color.Empty)
            Me.txtAssetTypeCodeStart.Location = New System.Drawing.Point(136, 112)
            Me.Validator.SetMinValue(Me.txtAssetTypeCodeStart, "")
            Me.txtAssetTypeCodeStart.Name = "txtAssetTypeCodeStart"
            Me.Validator.SetRegularExpression(Me.txtAssetTypeCodeStart, "")
            Me.Validator.SetRequired(Me.txtAssetTypeCodeStart, False)
            Me.txtAssetTypeCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtAssetTypeCodeStart.TabIndex = 8
            '
            'lblAssetTypeStart
            '
            Me.lblAssetTypeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAssetTypeStart.ForeColor = System.Drawing.Color.Black
            Me.lblAssetTypeStart.Location = New System.Drawing.Point(40, 112)
            Me.lblAssetTypeStart.Name = "lblAssetTypeStart"
            Me.lblAssetTypeStart.Size = New System.Drawing.Size(88, 18)
            Me.lblAssetTypeStart.TabIndex = 6
            Me.lblAssetTypeStart.Text = "ประเภทสินทรัพย์:"
            Me.lblAssetTypeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAssetAcctCodeEnd
            '
            Me.Validator.SetDataType(Me.txtAssetAcctCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAssetAcctCodeEnd, "")
            Me.txtAssetAcctCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAssetAcctCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAssetAcctCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAssetAcctCodeEnd, System.Drawing.Color.Empty)
            Me.txtAssetAcctCodeEnd.Location = New System.Drawing.Point(296, 88)
            Me.Validator.SetMinValue(Me.txtAssetAcctCodeEnd, "")
            Me.txtAssetAcctCodeEnd.Name = "txtAssetAcctCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtAssetAcctCodeEnd, "")
            Me.Validator.SetRequired(Me.txtAssetAcctCodeEnd, False)
            Me.txtAssetAcctCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtAssetAcctCodeEnd.TabIndex = 7
            '
            'btnAssetAcctEndFind
            '
            Me.btnAssetAcctEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAssetAcctEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAssetAcctEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAssetAcctEndFind.Location = New System.Drawing.Point(392, 88)
            Me.btnAssetAcctEndFind.Name = "btnAssetAcctEndFind"
            Me.btnAssetAcctEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAssetAcctEndFind.TabIndex = 23
            Me.btnAssetAcctEndFind.TabStop = False
            Me.btnAssetAcctEndFind.ThemedImage = CType(resources.GetObject("btnAssetAcctEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAssetAcctStartFind
            '
            Me.btnAssetAcctStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAssetAcctStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAssetAcctStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAssetAcctStartFind.Location = New System.Drawing.Point(232, 88)
            Me.btnAssetAcctStartFind.Name = "btnAssetAcctStartFind"
            Me.btnAssetAcctStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAssetAcctStartFind.TabIndex = 24
            Me.btnAssetAcctStartFind.TabStop = False
            Me.btnAssetAcctStartFind.ThemedImage = CType(resources.GetObject("btnAssetAcctStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblAssetAcctEnd
            '
            Me.lblAssetAcctEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAssetAcctEnd.ForeColor = System.Drawing.Color.Black
            Me.lblAssetAcctEnd.Location = New System.Drawing.Point(264, 88)
            Me.lblAssetAcctEnd.Name = "lblAssetAcctEnd"
            Me.lblAssetAcctEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblAssetAcctEnd.TabIndex = 9
            Me.lblAssetAcctEnd.Text = "ถึง"
            Me.lblAssetAcctEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtAssetAcctCodeStart
            '
            Me.Validator.SetDataType(Me.txtAssetAcctCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAssetAcctCodeStart, "")
            Me.txtAssetAcctCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAssetAcctCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAssetAcctCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAssetAcctCodeStart, System.Drawing.Color.Empty)
            Me.txtAssetAcctCodeStart.Location = New System.Drawing.Point(136, 88)
            Me.Validator.SetMinValue(Me.txtAssetAcctCodeStart, "")
            Me.txtAssetAcctCodeStart.Name = "txtAssetAcctCodeStart"
            Me.Validator.SetRegularExpression(Me.txtAssetAcctCodeStart, "")
            Me.Validator.SetRequired(Me.txtAssetAcctCodeStart, False)
            Me.txtAssetAcctCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtAssetAcctCodeStart.TabIndex = 6
            '
            'lblAssetAcctStart
            '
            Me.lblAssetAcctStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAssetAcctStart.ForeColor = System.Drawing.Color.Black
            Me.lblAssetAcctStart.Location = New System.Drawing.Point(40, 88)
            Me.lblAssetAcctStart.Name = "lblAssetAcctStart"
            Me.lblAssetAcctStart.Size = New System.Drawing.Size(88, 18)
            Me.lblAssetAcctStart.TabIndex = 6
            Me.lblAssetAcctStart.Text = "บัญชีสินทรัพย์:"
            Me.lblAssetAcctStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(384, 258)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(304, 258)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
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
            'chkAssetShowAll
            '
            Me.chkAssetShowAll.Location = New System.Drawing.Point(136, 188)
            Me.chkAssetShowAll.Name = "chkAssetShowAll"
            Me.chkAssetShowAll.Size = New System.Drawing.Size(128, 24)
            Me.chkAssetShowAll.TabIndex = 40
            Me.chkAssetShowAll.Text = "แสดงสินทรัพย์ทั้งหมด"
            '
            'RptAssetDepreciationFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptAssetDepreciationFilterSubPanel"
            Me.Size = New System.Drawing.Size(488, 316)
            Me.grbMaster.ResumeLayout(False)
            Me.grbMaster.PerformLayout()
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblAssetStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.lblAssetStart}")
            Me.Validator.SetDisplayName(txtAssetCodeStart, lblAssetStart.Text)

            Me.lblAssetTypeStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.lblAssetTypeStart}")
            Me.Validator.SetDisplayName(txtAssetTypeCodeStart, lblAssetTypeStart.Text)

            Me.lblAssetAcctStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.lblAssetAcctStart}")
            Me.Validator.SetDisplayName(txtAssetAcctCodeStart, lblAssetAcctStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.lblCCStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.lblYearAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.lblYearAcct}")
            Me.lblPeriodStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.lblPeriodStart}")
            Me.chkOption.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.chkOption}")


            ' Global {ถึง}
            Me.lblAssetEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtAssetCodeEnd, lblAssetEnd.Text)

            Me.lblAssetTypeEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtAssetTypeCodeEnd, lblAssetTypeEnd.Text)

            Me.lblAssetAcctEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtAssetAcctCodeEnd, lblAssetAcctEnd.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.lblCCEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtCCCodeEnd, lblCCEnd.Text)

            Me.lblPeriodend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAssetDepreciationFilterSubPanel.grbDetail}")
        End Sub
#End Region

#Region "Member"
        Private m_asset As Asset
        Private m_assetstart As Asset
        Private m_assetend As Asset

        Private m_assettypestart As AssetType
        Private m_assettypeend As AssetType

        Private m_assetacctstart As Account
        Private m_assetacctend As Account

        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date

        Private m_cc As CostCenter
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
        Public Property AssetStart() As Asset
            Get
                Return m_assetstart
            End Get
            Set(ByVal Value As Asset)
                m_assetstart = Value
            End Set
        End Property
        Public Property AssetEnd() As Asset
            Get
                Return m_assetend
            End Get
            Set(ByVal Value As Asset)
                m_assetend = Value
            End Set
        End Property
        Public Property AssetTypeStart() As AssetType
            Get
                Return m_assettypestart
            End Get
            Set(ByVal Value As AssetType)
                m_assettypestart = Value
            End Set
        End Property
        Public Property AssetTypeEnd() As AssetType
            Get
                Return m_assettypeend
            End Get
            Set(ByVal Value As AssetType)
                m_assettypeend = Value
            End Set
        End Property
        Public Property AssetAcctStart() As Account
            Get
                Return m_assetacctstart
            End Get
            Set(ByVal Value As Account)
                m_assetacctstart = Value
            End Set
        End Property
        Public Property AssetAcctEnd() As Account
            Get
                Return m_assetacctend
            End Get
            Set(ByVal Value As Account)
                m_assetacctend = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property

        Public Property CostCenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
        End Property
#End Region

#Region "Methods"

        Private Sub Initialize()
            RegisterDropdown()
            ClearCriterias()
        End Sub
        Private Sub RegisterDropdown()
            ' ปี
            Dim baseDate As Date = AccountBaseDate.GetBaseDateFromDB() 'CDate(Configuration.GetConfig("BaseDate"))
            Dim years(9) As Date
            For i As Integer = 0 To 9
                years(i) = New Date(baseDate.Year + i, 1, 1)
            Next
            Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
            myDateTimeService.ListYearsInComboBox(Me.cmbYearAcct, years)

            ' งวดบัญชี
            Me.cmbPeriodStart.Items.Clear()
            Me.cmbPeriodEnd.Items.Clear()
            Dim period As String
            For i As Integer = 1 To 12
                period = i.ToString("0#")
                Me.cmbPeriodStart.Items.Add(period)
                Me.cmbPeriodEnd.Items.Add(period)
            Next

            'JournalEntryFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbFormat, "rpt_journalentryfilter")
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

            Me.CostCenter = New CostCenter

            Me.AssetStart = New Asset
            Me.AssetEnd = New Asset
            Me.AssetTypeStart = New AssetType
            Me.AssetTypeEnd = New AssetType
            Me.AssetAcctStart = New Account
            Me.AssetAcctEnd = New Account

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.cmbYearAcct.SelectedIndex = (Date.Now.Year - AccountBaseDate.GetBaseDateFromDB().Year) 'CDate(Configuration.GetConfig("BaseDate")).Year)
            Me.cmbPeriodStart.SelectedIndex = 0
            Me.cmbPeriodEnd.SelectedIndex = 0
            Me.chkOption.Checked = True
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(18) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("AssetCodeStart", IIf(txtAssetCodeStart.TextLength > 0, txtAssetCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("AssetCodeEnd", IIf(txtAssetCodeEnd.TextLength > 0, txtAssetCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("AssetTypeCodeStart", IIf(txtAssetTypeCodeStart.TextLength > 0, txtAssetTypeCodeStart.Text, DBNull.Value))
            arr(5) = New Filter("AssetTypeCodeEnd", IIf(txtAssetTypeCodeEnd.TextLength > 0, txtAssetTypeCodeEnd.Text, DBNull.Value))
            arr(6) = New Filter("AssetAcctCodeStart", IIf(txtAssetAcctCodeStart.TextLength > 0, txtAssetAcctCodeStart.Text, DBNull.Value))
            arr(7) = New Filter("AssetAcctCodeEnd", IIf(txtAssetAcctCodeEnd.TextLength > 0, txtAssetAcctCodeEnd.Text, DBNull.Value))
            arr(8) = New Filter("CostCenterCodeStart", IIf(txtCCCodeStart.TextLength > 0, txtCCCodeStart.Text, DBNull.Value))
            arr(9) = New Filter("CostCenterCodeEnd", IIf(txtCCCodeEnd.TextLength > 0, txtCCCodeEnd.Text, DBNull.Value))
            arr(10) = New Filter("YearAcct", cmbYearAcct.SelectedValue)
            arr(11) = New Filter("PeriodStart", IIf(Me.cmbPeriodStart.Text.Length > 0, Me.cmbPeriodStart.Text, DBNull.Value))
            arr(12) = New Filter("PeriodEnd", IIf(Me.cmbPeriodEnd.Text.Length > 0, Me.cmbPeriodEnd.Text, DBNull.Value))
            arr(13) = New Filter("isByPeriod", IIf(chkOption.Checked, 1, 0))
            arr(14) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(15) = New Filter("assetId", Me.ValidIdOrDBNull(m_asset))
            arr(16) = New Filter("isStraightLine", IIf(chkStraightLine.Checked, 1, 0))
            arr(17) = New Filter("isDoubleDeclining", IIf(chkDoubleDeclining.Checked, 1, 0))
            arr(18) = New Filter("AssetShowAll", IIf(chkAssetShowAll.Checked, 1, 0))
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

            If chkOption.Checked Then
                'year
                dpi = New DocPrintingItem
                dpi.Mapping = "year"
                dpi.Value = Me.cmbYearAcct.Text
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)

                ' period start
                dpi = New DocPrintingItem
                dpi.Mapping = "periodstart"
                dpi.Value = cmbPeriodStart.Text
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)

                ' period end
                dpi = New DocPrintingItem
                dpi.Mapping = "periodend"
                dpi.Value = cmbPeriodEnd.Text
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            Else
                'DocDateStart
                dpi = New DocPrintingItem
                dpi.Mapping = "DocDateStart"
                dpi.Value = Me.txtDocDateStart.Text
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)

                'DocDateEnd
                dpi = New DocPrintingItem
                dpi.Mapping = "DocDateEnd"
                dpi.Value = Me.txtDocDateEnd.Text
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            ' EndDate
            If chkOption.Checked Then
                If TypeOf cmbYearAcct.SelectedItem Is ValueDisplayPair Then
                    Dim code As String = cmbYearAcct.SelectedText
                    Dim myItem As ValueDisplayPair = CType(cmbYearAcct.SelectedItem, ValueDisplayPair)
                    Dim dt As Date = CType(myItem.Value, Date)
                    Dim period As AccountPeriod = AccountPeriod.GetAccountPeriod(dt, code)
                    If period Is Nothing Then
                        Dim acctPeriodcoll As AccountPeriodCollection = AccountPeriod.GetLastestAccountPeriod()
                        period = acctPeriodcoll.Item(acctPeriodcoll.Count - 1)
                    End If

                    ' EndDateShort
                    dpi = New DocPrintingItem
                    dpi.Mapping = "enddateshort"
                    dpi.Value = period.EndDate.ToShortDateString
                    dpi.DataType = "System.String"
                    dpiColl.Add(dpi)

                    ' EndDateFull
                    dpi = New DocPrintingItem
                    dpi.Mapping = "enddatefull"
                    dpi.Value = period.EndDate.ToLongDateString
                    dpi.DataType = "System.String"
                    dpiColl.Add(dpi)

                End If
            Else
                ' EndDateShort
                dpi = New DocPrintingItem
                dpi.Mapping = "enddateshort"
                dpi.Value = DocDateStart.ToShortDateString
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)

                ' EndDateFull
                dpi = New DocPrintingItem
                dpi.Mapping = "enddatefull"
                dpi.Value = DocDateStart.ToLongDateString
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'Asset Start
            dpi = New DocPrintingItem
            dpi.Mapping = "AssetStart"
            dpi.Value = Me.txtAssetCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Asset End
            dpi = New DocPrintingItem
            dpi.Mapping = "AssetEnd"
            dpi.Value = Me.txtAssetCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'AssetType Start
            dpi = New DocPrintingItem
            dpi.Mapping = "AssetTypeStart"
            dpi.Value = Me.txtAssetTypeCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'AssetType End
            dpi = New DocPrintingItem
            dpi.Mapping = "AssetTypeEnd"
            dpi.Value = Me.txtAssetTypeCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'AssetAcct Start
            dpi = New DocPrintingItem
            dpi.Mapping = "AssetAcctStart"
            dpi.Value = Me.txtAssetAcctCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'AssetAcct End
            dpi = New DocPrintingItem
            dpi.Mapping = "AssetAcctEnd"
            dpi.Value = Me.txtAssetAcctCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterStart
            dpi = New DocPrintingItem
            dpi.Mapping = "CostcenterStart"
            dpi.Value = Me.txtCCCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterEnd
            dpi = New DocPrintingItem
            dpi.Mapping = "CostcenterEnd"
            dpi.Value = Me.txtCCCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'today
            dpi = New DocPrintingItem
            dpi.Mapping = "today"
            dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnAssetStartFind.Click, AddressOf Me.btnAssetFind_Click
            AddHandler btnAssetEndFind.Click, AddressOf Me.btnAssetFind_Click

            AddHandler btnAssetTypeStartFind.Click, AddressOf Me.btnAssetTypeFind_Click
            AddHandler btnAssetTypeEndFind.Click, AddressOf Me.btnAssetTypeFind_Click

            AddHandler btnAssetAcctStartFind.Click, AddressOf Me.btnAssetAcctFind_Click
            AddHandler btnAssetAcctEndFind.Click, AddressOf Me.btnAssetAcctFind_Click

            AddHandler btnCCStartFind.Click, AddressOf Me.btnCCFind_Click
            AddHandler btnCCEndFind.Click, AddressOf Me.btnCCFind_Click

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtCCCodeEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler chkOption.CheckedChanged, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

                Case "txtcccodeend"
                    CostCenter.GetCostCenter(txtCCCodeEnd, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

                Case "chkoption"
                    If chkOption.Checked Then
                        txtDocDateStart.Enabled = False
                        txtDocDateEnd.Enabled = False
                        dtpDocDateStart.Enabled = False
                        dtpDocDateEnd.Enabled = False

                        cmbPeriodStart.Enabled = True
                        cmbPeriodEnd.Enabled = True
                        cmbYearAcct.Enabled = True
                    Else
                        txtDocDateStart.Enabled = True
                        txtDocDateEnd.Enabled = True
                        dtpDocDateStart.Enabled = True
                        dtpDocDateEnd.Enabled = True

                        cmbPeriodStart.Enabled = False
                        cmbPeriodEnd.Enabled = False
                        cmbYearAcct.Enabled = False
                    End If
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
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtassetcodestart", "txtassetcodeend"
                                Return True
                        End Select
                    End If
                End If
                ' CostCenter
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
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtassetcodestart"
                            Me.SetAssetStartDialog(entity)

                        Case "txtassetcodeend"
                            Me.SetAssetEndDialog(entity)

                    End Select
                End If
            End If
            ' CostCenter
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcccodestart"
                            Me.SetCCCodeStartDialog(entity)

                        Case "txtcccodestart"
                            Me.SetCCCodeStartDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnAssetFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnassetstartfind"
                    myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetStartDialog)

                Case "btnassetendfind"
                    myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetEndDialog)
            End Select
        End Sub
        Private Sub btnAssetTypeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnassettypestartfind"
                    myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeStartDialog)

                Case "btnassettypeendfind"
                    myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeEndDialog)
            End Select
        End Sub
        Private Sub btnAssetAcctFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnassetacctstartfind"
                    myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAssetAcctStartDialog)

                Case "btnassetacctendfind"
                    myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAssetAcctEndDialog)
            End Select
        End Sub
        ' CostCenter
        Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnccstartfind"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)

                Case "btnccendfind"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeEndDialog)
            End Select
        End Sub
        Private Sub SetAssetStartDialog(ByVal e As ISimpleEntity)
            Me.txtAssetCodeStart.Text = e.Code
            Asset.GetAsset(txtAssetCodeStart, txtTemp, Me.AssetStart)
        End Sub
        Private Sub SetAssetEndDialog(ByVal e As ISimpleEntity)
            Me.txtAssetCodeEnd.Text = e.Code
            Asset.GetAsset(txtAssetCodeEnd, txtTemp, Me.AssetEnd)
        End Sub
        Private Sub SetAssetTypeStartDialog(ByVal e As ISimpleEntity)
            Me.txtAssetTypeCodeStart.Text = e.Code
            AssetType.GetAssetType(txtAssetTypeCodeStart, txtTemp, Me.AssetTypeStart)
        End Sub
        Private Sub SetAssetTypeEndDialog(ByVal e As ISimpleEntity)
            Me.txtAssetTypeCodeEnd.Text = e.Code
            AssetType.GetAssetType(txtAssetTypeCodeEnd, txtTemp, Me.AssetTypeEnd)
        End Sub
        Private Sub SetAssetAcctStartDialog(ByVal e As ISimpleEntity)
            Me.txtAssetAcctCodeStart.Text = e.Code
            Account.GetAccount(txtAssetAcctCodeStart, txtTemp, Me.AssetAcctStart)
        End Sub
        Private Sub SetAssetAcctEndDialog(ByVal e As ISimpleEntity)
            Me.txtAssetAcctCodeEnd.Text = e.Code
            Account.GetAccount(txtAssetAcctCodeEnd, txtTemp, Me.AssetAcctEnd)
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub SetCCCodeEndDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeEnd.Text = e.Code
            CostCenter.GetCostCenter(txtCCCodeEnd, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
#End Region

    End Class
End Namespace

