Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptGLPayReceivebyAcctFilterSubPanel
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel
    'Inherits UserControl

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
    Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
    Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
    Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
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
    Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierGroup As System.Windows.Forms.Label
    Friend WithEvents txtSupplierGroupStart As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierGroupStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkIncludeSGChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnAcctCodeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnAcctCodeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents chkAPAcctOnly As System.Windows.Forms.CheckBox
    Friend WithEvents lblAcctEnd As System.Windows.Forms.Label
    Friend WithEvents btnAccountEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
    Friend WithEvents btnAccountStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountStart As System.Windows.Forms.Label
    Friend WithEvents txtCustGName As System.Windows.Forms.TextBox
    Friend WithEvents lblCustG As System.Windows.Forms.Label
    Friend WithEvents txtCustGCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnCustGDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkIncludeChildCustG As System.Windows.Forms.CheckBox
    Friend WithEvents ibtnFindCustTo As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCustCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents lblCust2 As System.Windows.Forms.Label
    Friend WithEvents ibtnFindCustFrom As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCustCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents lblAcctStart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptGLPayReceivebyAcctFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnAccountEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAccountCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblAccountEnd = New System.Windows.Forms.Label()
      Me.btnAccountStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAccountCodeStart = New System.Windows.Forms.TextBox()
      Me.lblAccountStart = New System.Windows.Forms.Label()
      Me.chkAPAcctOnly = New System.Windows.Forms.CheckBox()
      Me.btnAcctCodeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblAcctEnd = New System.Windows.Forms.Label()
      Me.btnAcctCodeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctCodeStart = New System.Windows.Forms.TextBox()
      Me.lblAcctStart = New System.Windows.Forms.Label()
      Me.txtSupplierGroupName = New System.Windows.Forms.TextBox()
      Me.lblSupplierGroup = New System.Windows.Forms.Label()
      Me.txtSupplierGroupStart = New System.Windows.Forms.TextBox()
      Me.btnSupplierGroupStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkIncludeSGChildren = New System.Windows.Forms.CheckBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblSuppliEnd = New System.Windows.Forms.Label()
      Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSuppliStart = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.lblCust = New System.Windows.Forms.Label()
      Me.txtCustCodeFrom = New System.Windows.Forms.TextBox()
      Me.ibtnFindCustFrom = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCust2 = New System.Windows.Forms.Label()
      Me.txtCustCodeTo = New System.Windows.Forms.TextBox()
      Me.ibtnFindCustTo = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkIncludeChildCustG = New System.Windows.Forms.CheckBox()
      Me.ibtnCustGDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCustGCode = New System.Windows.Forms.TextBox()
      Me.lblCustG = New System.Windows.Forms.Label()
      Me.txtCustGName = New System.Windows.Forms.TextBox()
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
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 4)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(790, 284)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(794, 32)
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
      Me.grbDetail.Controls.Add(Me.btnAccountEndFind)
      Me.grbDetail.Controls.Add(Me.txtAccountCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblAccountEnd)
      Me.grbDetail.Controls.Add(Me.btnAccountStartFind)
      Me.grbDetail.Controls.Add(Me.txtAccountCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAccountStart)
      Me.grbDetail.Controls.Add(Me.chkAPAcctOnly)
      Me.grbDetail.Controls.Add(Me.btnAcctCodeEndFind)
      Me.grbDetail.Controls.Add(Me.txtAcctCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblAcctEnd)
      Me.grbDetail.Controls.Add(Me.btnAcctCodeStartFind)
      Me.grbDetail.Controls.Add(Me.txtAcctCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAcctStart)
      Me.grbDetail.Controls.Add(Me.txtCustGName)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
      Me.grbDetail.Controls.Add(Me.lblCustG)
      Me.grbDetail.Controls.Add(Me.lblSupplierGroup)
      Me.grbDetail.Controls.Add(Me.txtCustGCode)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupStart)
      Me.grbDetail.Controls.Add(Me.ibtnCustGDialog)
      Me.grbDetail.Controls.Add(Me.btnSupplierGroupStart)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildCustG)
      Me.grbDetail.Controls.Add(Me.chkIncludeSGChildren)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.ibtnFindCustTo)
      Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
      Me.grbDetail.Controls.Add(Me.txtCustCodeTo)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblCust2)
      Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
      Me.grbDetail.Controls.Add(Me.ibtnFindCustFrom)
      Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
      Me.grbDetail.Controls.Add(Me.txtCustCodeFrom)
      Me.grbDetail.Controls.Add(Me.lblCust)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSuppliStart)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(13, 14)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(764, 233)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnAccountEndFind
      '
      Me.btnAccountEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountEndFind.Location = New System.Drawing.Point(734, 68)
      Me.btnAccountEndFind.Name = "btnAccountEndFind"
      Me.btnAccountEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAccountEndFind.TabIndex = 29
      Me.btnAccountEndFind.TabStop = False
      Me.btnAccountEndFind.ThemedImage = CType(resources.GetObject("btnAccountEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAccountCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCodeEnd, "")
      Me.txtAccountCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
      Me.txtAccountCodeEnd.Location = New System.Drawing.Point(638, 68)
      Me.Validator.SetMinValue(Me.txtAccountCodeEnd, "")
      Me.txtAccountCodeEnd.Name = "txtAccountCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAccountCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAccountCodeEnd, False)
      Me.txtAccountCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountCodeEnd.TabIndex = 28
      '
      'lblAccountEnd
      '
      Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAccountEnd.Location = New System.Drawing.Point(606, 68)
      Me.lblAccountEnd.Name = "lblAccountEnd"
      Me.lblAccountEnd.Size = New System.Drawing.Size(31, 18)
      Me.lblAccountEnd.TabIndex = 57
      Me.lblAccountEnd.Text = "ถึง"
      Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAccountStartFind
      '
      Me.btnAccountStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAccountStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAccountStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAccountStartFind.Location = New System.Drawing.Point(574, 68)
      Me.btnAccountStartFind.Name = "btnAccountStartFind"
      Me.btnAccountStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAccountStartFind.TabIndex = 27
      Me.btnAccountStartFind.TabStop = False
      Me.btnAccountStartFind.ThemedImage = CType(resources.GetObject("btnAccountStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAccountCodeStart
      '
      Me.Validator.SetDataType(Me.txtAccountCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCodeStart, "")
      Me.txtAccountCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
      Me.txtAccountCodeStart.Location = New System.Drawing.Point(478, 68)
      Me.Validator.SetMinValue(Me.txtAccountCodeStart, "")
      Me.txtAccountCodeStart.Name = "txtAccountCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAccountCodeStart, "")
      Me.Validator.SetRequired(Me.txtAccountCodeStart, False)
      Me.txtAccountCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAccountCodeStart.TabIndex = 26
      '
      'lblAccountStart
      '
      Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
      Me.lblAccountStart.Location = New System.Drawing.Point(382, 68)
      Me.lblAccountStart.Name = "lblAccountStart"
      Me.lblAccountStart.Size = New System.Drawing.Size(95, 18)
      Me.lblAccountStart.TabIndex = 56
      Me.lblAccountStart.Text = "ตั้งแต่สมุดรายวัน"
      Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkAPAcctOnly
      '
      Me.chkAPAcctOnly.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkAPAcctOnly.Location = New System.Drawing.Point(478, 41)
      Me.chkAPAcctOnly.Name = "chkAPAcctOnly"
      Me.chkAPAcctOnly.Size = New System.Drawing.Size(176, 24)
      Me.chkAPAcctOnly.TabIndex = 25
      Me.chkAPAcctOnly.Text = "เฉพาะผังบัญชีที่ระบุไว้กับเจ้าหนี้"
      '
      'btnAcctCodeEndFind
      '
      Me.btnAcctCodeEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctCodeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctCodeEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctCodeEndFind.Location = New System.Drawing.Point(734, 19)
      Me.btnAcctCodeEndFind.Name = "btnAcctCodeEndFind"
      Me.btnAcctCodeEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctCodeEndFind.TabIndex = 24
      Me.btnAcctCodeEndFind.TabStop = False
      Me.btnAcctCodeEndFind.ThemedImage = CType(resources.GetObject("btnAcctCodeEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAcctCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctCodeEnd, "")
      Me.txtAcctCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctCodeEnd, System.Drawing.Color.Empty)
      Me.txtAcctCodeEnd.Location = New System.Drawing.Point(638, 19)
      Me.Validator.SetMinValue(Me.txtAcctCodeEnd, "")
      Me.txtAcctCodeEnd.Name = "txtAcctCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAcctCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAcctCodeEnd, False)
      Me.txtAcctCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctCodeEnd.TabIndex = 23
      '
      'lblAcctEnd
      '
      Me.lblAcctEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAcctEnd.Location = New System.Drawing.Point(606, 19)
      Me.lblAcctEnd.Name = "lblAcctEnd"
      Me.lblAcctEnd.Size = New System.Drawing.Size(31, 18)
      Me.lblAcctEnd.TabIndex = 48
      Me.lblAcctEnd.Text = "ถึง"
      Me.lblAcctEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAcctCodeStartFind
      '
      Me.btnAcctCodeStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctCodeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctCodeStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctCodeStartFind.Location = New System.Drawing.Point(574, 19)
      Me.btnAcctCodeStartFind.Name = "btnAcctCodeStartFind"
      Me.btnAcctCodeStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctCodeStartFind.TabIndex = 22
      Me.btnAcctCodeStartFind.TabStop = False
      Me.btnAcctCodeStartFind.ThemedImage = CType(resources.GetObject("btnAcctCodeStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctCodeStart
      '
      Me.Validator.SetDataType(Me.txtAcctCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctCodeStart, "")
      Me.txtAcctCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctCodeStart, System.Drawing.Color.Empty)
      Me.txtAcctCodeStart.Location = New System.Drawing.Point(478, 19)
      Me.Validator.SetMinValue(Me.txtAcctCodeStart, "")
      Me.txtAcctCodeStart.Name = "txtAcctCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAcctCodeStart, "")
      Me.Validator.SetRequired(Me.txtAcctCodeStart, False)
      Me.txtAcctCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctCodeStart.TabIndex = 21
      '
      'lblAcctStart
      '
      Me.lblAcctStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctStart.ForeColor = System.Drawing.Color.Black
      Me.lblAcctStart.Location = New System.Drawing.Point(382, 19)
      Me.lblAcctStart.Name = "lblAcctStart"
      Me.lblAcctStart.Size = New System.Drawing.Size(95, 18)
      Me.lblAcctStart.TabIndex = 45
      Me.lblAcctStart.Text = "ผังบัญชี:"
      Me.lblAcctStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierGroupName
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.txtSupplierGroupName.Location = New System.Drawing.Point(220, 40)
      Me.txtSupplierGroupName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
      Me.txtSupplierGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
      Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
      Me.txtSupplierGroupName.TabIndex = 41
      '
      'lblSupplierGroup
      '
      Me.lblSupplierGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplierGroup.ForeColor = System.Drawing.Color.Black
      Me.lblSupplierGroup.Location = New System.Drawing.Point(6, 40)
      Me.lblSupplierGroup.Name = "lblSupplierGroup"
      Me.lblSupplierGroup.Size = New System.Drawing.Size(86, 18)
      Me.lblSupplierGroup.TabIndex = 40
      Me.lblSupplierGroup.Text = "กลุ่มผู้ขาย:"
      Me.lblSupplierGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierGroupStart
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupStart, "")
      Me.txtSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupStart, System.Drawing.Color.Empty)
      Me.txtSupplierGroupStart.Location = New System.Drawing.Point(100, 40)
      Me.txtSupplierGroupStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtSupplierGroupStart, "")
      Me.txtSupplierGroupStart.Name = "txtSupplierGroupStart"
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupStart, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupStart, False)
      Me.txtSupplierGroupStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSupplierGroupStart.TabIndex = 4
      '
      'btnSupplierGroupStart
      '
      Me.btnSupplierGroupStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierGroupStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierGroupStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierGroupStart.Location = New System.Drawing.Point(196, 40)
      Me.btnSupplierGroupStart.Name = "btnSupplierGroupStart"
      Me.btnSupplierGroupStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSupplierGroupStart.TabIndex = 5
      Me.btnSupplierGroupStart.TabStop = False
      Me.btnSupplierGroupStart.ThemedImage = CType(resources.GetObject("btnSupplierGroupStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkIncludeSGChildren
      '
      Me.chkIncludeSGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeSGChildren.Location = New System.Drawing.Point(100, 62)
      Me.chkIncludeSGChildren.Name = "chkIncludeSGChildren"
      Me.chkIncludeSGChildren.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeSGChildren.TabIndex = 6
      Me.chkIncludeSGChildren.Text = "รวมกลุ่มผู้ขายลูก"
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(260, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDateEnd.TabIndex = 1
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(100, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDateStart.TabIndex = 0
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(100, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(260, 16)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 3
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(4, 16)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 29
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(228, 16)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 32
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(100, 206)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildren.TabIndex = 20
      Me.chkIncludeChildren.Text = "รวม Cost Center ลูก"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(196, 184)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 19
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
      Me.txtCCCodeStart.Location = New System.Drawing.Point(100, 184)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 18
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(20, 184)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(72, 18)
      Me.lblCCStart.TabIndex = 24
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
      Me.txtCostCenterName.Location = New System.Drawing.Point(220, 184)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 25
      '
      'btnSuppliEndFind
      '
      Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliEndFind.Location = New System.Drawing.Point(356, 88)
      Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
      Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliEndFind.TabIndex = 10
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
      Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(260, 88)
      Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
      Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeEnd.TabIndex = 9
      '
      'lblSuppliEnd
      '
      Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliEnd.Location = New System.Drawing.Point(228, 88)
      Me.lblSuppliEnd.Name = "lblSuppliEnd"
      Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSuppliEnd.TabIndex = 9
      Me.lblSuppliEnd.Text = "ถึง"
      Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSuppliStartFind
      '
      Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliStartFind.Location = New System.Drawing.Point(196, 88)
      Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
      Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliStartFind.TabIndex = 8
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
      Me.txtSuppliCodeStart.Location = New System.Drawing.Point(100, 88)
      Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
      Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeStart.TabIndex = 7
      '
      'lblSuppliStart
      '
      Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliStart.Location = New System.Drawing.Point(4, 88)
      Me.lblSuppliStart.Name = "lblSuppliStart"
      Me.lblSuppliStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSuppliStart.TabIndex = 6
      Me.lblSuppliStart.Text = "Supplier:"
      Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(694, 252)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(614, 252)
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
      'lblCust
      '
      Me.lblCust.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCust.ForeColor = System.Drawing.Color.Black
      Me.lblCust.Location = New System.Drawing.Point(4, 160)
      Me.lblCust.Name = "lblCust"
      Me.lblCust.Size = New System.Drawing.Size(88, 18)
      Me.lblCust.TabIndex = 6
      Me.lblCust.Text = "Customer:"
      Me.lblCust.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustCodeFrom
      '
      Me.Validator.SetDataType(Me.txtCustCodeFrom, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustCodeFrom, "")
      Me.txtCustCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustCodeFrom, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustCodeFrom, System.Drawing.Color.Empty)
      Me.txtCustCodeFrom.Location = New System.Drawing.Point(100, 160)
      Me.Validator.SetMinValue(Me.txtCustCodeFrom, "")
      Me.txtCustCodeFrom.Name = "txtCustCodeFrom"
      Me.Validator.SetRegularExpression(Me.txtCustCodeFrom, "")
      Me.Validator.SetRequired(Me.txtCustCodeFrom, False)
      Me.txtCustCodeFrom.Size = New System.Drawing.Size(96, 21)
      Me.txtCustCodeFrom.TabIndex = 14
      '
      'ibtnFindCustFrom
      '
      Me.ibtnFindCustFrom.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnFindCustFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnFindCustFrom.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnFindCustFrom.Location = New System.Drawing.Point(196, 160)
      Me.ibtnFindCustFrom.Name = "ibtnFindCustFrom"
      Me.ibtnFindCustFrom.Size = New System.Drawing.Size(24, 22)
      Me.ibtnFindCustFrom.TabIndex = 15
      Me.ibtnFindCustFrom.TabStop = False
      Me.ibtnFindCustFrom.ThemedImage = CType(resources.GetObject("ibtnFindCustFrom.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCust2
      '
      Me.lblCust2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCust2.ForeColor = System.Drawing.Color.Black
      Me.lblCust2.Location = New System.Drawing.Point(228, 160)
      Me.lblCust2.Name = "lblCust2"
      Me.lblCust2.Size = New System.Drawing.Size(24, 18)
      Me.lblCust2.TabIndex = 9
      Me.lblCust2.Text = "ถึง"
      Me.lblCust2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtCustCodeTo
      '
      Me.Validator.SetDataType(Me.txtCustCodeTo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustCodeTo, "")
      Me.txtCustCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustCodeTo, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustCodeTo, System.Drawing.Color.Empty)
      Me.txtCustCodeTo.Location = New System.Drawing.Point(260, 160)
      Me.Validator.SetMinValue(Me.txtCustCodeTo, "")
      Me.txtCustCodeTo.Name = "txtCustCodeTo"
      Me.Validator.SetRegularExpression(Me.txtCustCodeTo, "")
      Me.Validator.SetRequired(Me.txtCustCodeTo, False)
      Me.txtCustCodeTo.Size = New System.Drawing.Size(96, 21)
      Me.txtCustCodeTo.TabIndex = 16
      '
      'ibtnFindCustTo
      '
      Me.ibtnFindCustTo.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnFindCustTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnFindCustTo.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnFindCustTo.Location = New System.Drawing.Point(356, 160)
      Me.ibtnFindCustTo.Name = "ibtnFindCustTo"
      Me.ibtnFindCustTo.Size = New System.Drawing.Size(24, 22)
      Me.ibtnFindCustTo.TabIndex = 17
      Me.ibtnFindCustTo.TabStop = False
      Me.ibtnFindCustTo.ThemedImage = CType(resources.GetObject("ibtnFindCustTo.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkIncludeChildCustG
      '
      Me.chkIncludeChildCustG.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildCustG.Location = New System.Drawing.Point(100, 134)
      Me.chkIncludeChildCustG.Name = "chkIncludeChildCustG"
      Me.chkIncludeChildCustG.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildCustG.TabIndex = 13
      Me.chkIncludeChildCustG.Text = "รวมกลุ่มผู้ขายลูก"
      '
      'ibtnCustGDialog
      '
      Me.ibtnCustGDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCustGDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCustGDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCustGDialog.Location = New System.Drawing.Point(196, 112)
      Me.ibtnCustGDialog.Name = "ibtnCustGDialog"
      Me.ibtnCustGDialog.Size = New System.Drawing.Size(24, 22)
      Me.ibtnCustGDialog.TabIndex = 12
      Me.ibtnCustGDialog.TabStop = False
      Me.ibtnCustGDialog.ThemedImage = CType(resources.GetObject("ibtnCustGDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCustGCode
      '
      Me.Validator.SetDataType(Me.txtCustGCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustGCode, "")
      Me.txtCustGCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustGCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustGCode, System.Drawing.Color.Empty)
      Me.txtCustGCode.Location = New System.Drawing.Point(100, 112)
      Me.txtCustGCode.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCustGCode, "")
      Me.txtCustGCode.Name = "txtCustGCode"
      Me.Validator.SetRegularExpression(Me.txtCustGCode, "")
      Me.Validator.SetRequired(Me.txtCustGCode, False)
      Me.txtCustGCode.Size = New System.Drawing.Size(96, 21)
      Me.txtCustGCode.TabIndex = 11
      '
      'lblCustG
      '
      Me.lblCustG.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustG.ForeColor = System.Drawing.Color.Black
      Me.lblCustG.Location = New System.Drawing.Point(6, 112)
      Me.lblCustG.Name = "lblCustG"
      Me.lblCustG.Size = New System.Drawing.Size(86, 18)
      Me.lblCustG.TabIndex = 40
      Me.lblCustG.Text = "กลุ่มลูกค้า:"
      Me.lblCustG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustGName
      '
      Me.Validator.SetDataType(Me.txtCustGName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustGName, "")
      Me.txtCustGName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustGName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustGName, System.Drawing.Color.Empty)
      Me.txtCustGName.Location = New System.Drawing.Point(220, 112)
      Me.txtCustGName.MaxLength = 50
      Me.Validator.SetMinValue(Me.txtCustGName, "")
      Me.txtCustGName.Name = "txtCustGName"
      Me.txtCustGName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustGName, "")
      Me.Validator.SetRequired(Me.txtCustGName, False)
      Me.txtCustGName.Size = New System.Drawing.Size(160, 21)
      Me.txtCustGName.TabIndex = 41
      '
      'RptGLPayReceivebyAcctFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptGLPayReceivebyAcctFilterSubPanel"
      Me.Size = New System.Drawing.Size(806, 296)
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
      Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.lblSuppliStart}")
      Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      'SupplierGroup
      Me.lblSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.lblSupplierGroup}")
      Me.Validator.SetDisplayName(txtSupplierGroupStart, lblSupplierGroup.Text)
      Me.chkIncludeSGChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.chkIncludeSGChildren}")
      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)


      'Account
      Me.lblAcctStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPGLFilterSubPanel.lblAcctStart}")
      Me.lblAcctEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

      ' Global {ถึง}
      Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtSuppliCodeEnd, lblSuppliEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.grbDetail}")

      'Checkbox
      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.chkIncludeChildren}")
      Me.chkAPAcctOnly.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPGLFilterSubPanel.chkAPAcctOnly}")

      Me.lblCustG.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPGLFilterSubPanel.lblCustG}")
      Me.lblCust.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPGLFilterSubPanel.lblCust}")
      Me.lblCust2.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.chkIncludeChildCustG.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPGLFilterSubPanel.chkIncludeChildCustG}")
            Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Global.AccountBookStart}")

            Me.lblAccountEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtAccountCodeEnd, lblAccountEnd.Text)
    End Sub
#End Region

#Region "Member"
    Private m_supplierstart As Supplier
    Private m_supplierend As Supplier
    Private m_sg As SupplierGroup

    Private m_acctstart As Account
    Private m_acctend As Account

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_cc As CostCenter

    Private m_AccountBookStart As AccountBook
    Private m_AccountBookEnd As AccountBook
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
    Public Property CustomerGroup As CustomerGroup
    Public Property CustomerStart As Customer
    Public Property CustomerEnd As Customer
    Public Property SupplierStart() As Supplier
      Get
        Return m_supplierstart
      End Get
      Set(ByVal Value As Supplier)
        m_supplierstart = Value
      End Set
    End Property
    Public Property SupplierEnd() As Supplier
      Get
        Return m_supplierend
      End Get
      Set(ByVal Value As Supplier)
        m_supplierend = Value
      End Set
    End Property
    Public Property AcctStart() As Account
      Get
        Return m_acctstart
      End Get
      Set(ByVal Value As Account)
        m_acctstart = Value
      End Set
    End Property
    Public Property AcctEnd() As Account
      Get
        Return m_acctend
      End Get
      Set(ByVal Value As Account)
        m_acctend = Value
      End Set
    End Property

    Public Property SupplierGroup() As SupplierGroup
      Get
        Return m_sg
      End Get
      Set(ByVal Value As SupplierGroup)
        m_sg = Value
      End Set
    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property

    Public Property Costcenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
      End Set
    End Property

    Public Property AccountBookStart() As AccountBook
      Get
        Return m_AccountBookStart
      End Get
      Set(ByVal Value As AccountBook)
        m_AccountBookStart = Value
      End Set
    End Property
    Public Property AccountBookEnd() As AccountBook
      Get
        Return m_AccountBookEnd
      End Get
      Set(ByVal Value As AccountBook)
        m_AccountBookEnd = Value
      End Set
    End Property
#End Region

#Region "Methods"

    Private Sub Initialize()
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

      Me.CustomerStart = New Customer
      Me.CustomerEnd = New Customer
      Me.CustomerGroup = New CustomerGroup

      Me.SupplierStart = New Supplier
      Me.SupplierEnd = New Supplier
      Me.SupplierGroup = New SupplierGroup

      Me.AcctStart = New Account
      Me.AcctEnd = New Account

      Me.AccountBookStart = New AccountBook
      Me.AccountBookEnd = New AccountBook

      Me.Costcenter = New Costcenter

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      'Me.chkIncludeRetention.Checked = False
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(17) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("sg_id", Me.ValidIdOrDBNull(m_sg))
      arr(5) = New Filter("IncludeChildSG", Me.chkIncludeSGChildren.Checked)
      arr(6) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      arr(7) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      'arr(8) = New Filter("IncludeRetention", Me.chkIncludeRetention.Checked)
      arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

      arr(9) = New Filter("AcctCodeStart", IIf(txtAcctCodeStart.TextLength > 0, txtAcctCodeStart.Text, DBNull.Value))
      arr(10) = New Filter("AcctCodeEnd", IIf(txtAcctCodeEnd.TextLength > 0, txtAcctCodeEnd.Text, DBNull.Value))
      arr(11) = New Filter("APAcctOnly", Me.chkAPAcctOnly.Checked)
      arr(12) = New Filter("accountbookfrom", IIf(txtAccountCodeStart.TextLength > 0, txtAccountCodeStart.Text, DBNull.Value))
      arr(13) = New Filter("accountbookend", IIf(txtAccountCodeEnd.TextLength > 0, txtAccountCodeEnd.Text, DBNull.Value))
      arr(14) = New Filter("CustCodeStart", IIf(txtCustCodeFrom.TextLength > 0, txtCustCodeFrom.Text, DBNull.Value))
      arr(15) = New Filter("CustCodeEnd", IIf(txtCustCodeTo.TextLength > 0, txtCustCodeTo.Text, DBNull.Value))
      arr(16) = New Filter("custg_id", Me.ValidIdOrDBNull(Me.CustomerGroup))
      arr(17) = New Filter("IncludeChildCG", Me.chkIncludeChildCustG.Checked)
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

      'Month
      dpi = New DocPrintingItem
      dpi.Mapping = "Month"
      dpi.Value = ""    'Me.cmbMonth.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Year
      dpi = New DocPrintingItem
      dpi.Mapping = "Year"
      dpi.Value = ""    'Me.cmbYear.Text
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

      'Supplier Start
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierStart"
      dpi.Value = Me.txtSuppliCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Supplier End
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierEnd"
      dpi.Value = Me.txtSuppliCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SupplierGroup
      dpi = New DocPrintingItem
      dpi.Mapping = "SupplierGroup"
      dpi.Value = Me.txtSupplierGroupName.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterStart"
      dpi.Value = Me.txtCostCenterName.Text
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

      'AccountStart
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountStart"
      dpi.Value = Me.txtAcctCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AccountEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountEnd"
      dpi.Value = Me.txtAcctCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox APAcctOnly
      If Me.chkAPAcctOnly.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "APAcctOnly"
        dpi.Value = "(เฉพาะผังบัญชีที่ระบุไว้กับเจ้าหนี้)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      ''CheckBox IncludeRetention
      'If Me.chkIncludeRetention.Checked Then
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "includeretention"
      '    dpi.Value = "(" & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPFilterSubPanel.chkIncludeRetention}") & ")"
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler ibtnFindCustFrom.Click, AddressOf Me.btnCustFind_Click
      AddHandler ibtnFindCustTo.Click, AddressOf Me.btnCustFind_Click

      AddHandler ibtnCustGDialog.Click, AddressOf Me.btnCustGFind_Click
      AddHandler txtCustGCode.Validated, AddressOf Me.ChangeProperty

      AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

      AddHandler btnAcctCodeStartFind.Click, AddressOf Me.btnAcctCodeFind_Click
      AddHandler btnAcctCodeEndFind.Click, AddressOf Me.btnAcctCodeFind_Click

      AddHandler btnSupplierGroupStart.Click, AddressOf Me.btnSupplierGroupFind_Click
      AddHandler txtSupplierGroupStart.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtSuppliCodeStart.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtSuppliCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler btnAccountStartFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnAccountEndFind.Click, AddressOf Me.btnAccountFind_Click
      AddHandler txtAccountCodeEnd.Validated, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case txtCustGCode.Name.ToLower
          CustomerGroup.GetCustomerGroup(txtCustGCode, txtCustGName, Me.CustomerGroup)

        Case "txtcccodestart"
          Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "txtsuppliergroupstart"
          SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, Me.txtSupplierGroupName, m_sg)

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
        Case "txtaccountcodestart"
          AccountBook.GetAccountBook(txtAccountCodeStart, txtTemp, Me.m_AccountBookStart)
        Case "txtaccountcodeend"
          AccountBook.GetAccountBook(txtAccountCodeEnd, txtTemp, Me.m_AccountBookEnd)
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
        ' Account
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtacctcodestart", "txtacctcodeend"
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
            Case "txtsupplicodestart"
              Me.SetSupplierStartDialog(entity)

            Case "txtsupplicodeend"
              Me.SetSupplierEndDialog(entity)

          End Select
        End If
      End If
      ' Costcenter
      If data.GetDataPresent((New Costcenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
        Dim entity As New Costcenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcccodestart"
              Me.SetCCCodeStartDialog(entity)

            Case "txtcccodeend"
              Me.SetCCCodeStartDialog(entity)

          End Select
        End If
      End If

      ' Account
      If data.GetDataPresent((New Account).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        Dim entity As New Account(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtacctcodestart"
              Me.SetAccountStartDialog(entity)

            Case "txtacctcodeend"
              Me.SetAccountEndDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    '--Customer-- ================================== 
    Private Sub btnCustGFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case ibtnCustGDialog.Name.ToLower
          myEntityPanelService.OpenTreeDialog(New CustomerGroup, AddressOf SetCustGDialog)
      End Select
    End Sub
    Private Sub btnCustFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case ibtnFindCustFrom.Name.ToLower ' "btnsupplistartfind"
          myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustStartDialog)
        Case ibtnFindCustTo.Name.ToLower ' "btnsuppliendfind"
          myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustEndDialog)
      End Select
    End Sub
    Private Sub SetCustStartDialog(ByVal e As ISimpleEntity)
      Me.txtCustCodeFrom.Text = e.Code
      Customer.GetCustomer(txtCustCodeFrom, txtTemp, Me.CustomerStart)
    End Sub
    Private Sub SetCustEndDialog(ByVal e As ISimpleEntity)
      Me.txtCustCodeTo.Text = e.Code
      Customer.GetCustomer(txtCustCodeTo, txtTemp, Me.CustomerEnd)
    End Sub
    Private Sub SetCustGDialog(ByVal e As ISimpleEntity)
      Me.txtCustGCode.Text = e.Code
      CustomerGroup.GetCustomerGroup(txtCustGCode, txtCustGName, Me.CustomerGroup)
    End Sub

    '--Supplier-- ================================== 
    Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsuppliergroupstart"
          myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSupplierGroupStartDialog)
      End Select
    End Sub
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
      Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)
    End Sub
    Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeEnd.Text = e.Code
      Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)
    End Sub
    Private Sub SetSupplierGroupStartDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierGroupStart.Text = e.Code
      SupplierGroup.GetSupplierGroup(txtSupplierGroupStart, txtSupplierGroupName, m_sg)
    End Sub

    '--Account-- ===================================
    Private Sub btnAcctCodeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnacctcodestartfind"
          myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountStartDialog)
        Case "btnacctcodeendfind"
          myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountEndDialog)
      End Select
    End Sub
    Private Sub SetAccountStartDialog(ByVal e As ISimpleEntity)
      Me.txtAcctCodeStart.Text = e.Code
      Account.GetAccount(txtAcctCodeStart, txtTemp, Me.AcctStart)
    End Sub
    Private Sub SetAccountEndDialog(ByVal e As ISimpleEntity)
      Me.txtAcctCodeEnd.Text = e.Code
      Account.GetAccount(txtAcctCodeEnd, txtTemp, Me.AcctEnd)
    End Sub

    '--Costcenter-- ==================================
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncccodestart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub

    'Account Book-- ===================================
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnaccountstartfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookStartDialog)
        Case "btnaccountendfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookEndDialog)
      End Select
    End Sub
    Private Sub SetAcctBookStartDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCodeStart.Text = e.Code
      AccountBook.GetAccountBook(txtAccountCodeStart, txtTemp, Me.m_AccountBookStart)
    End Sub
    Private Sub SetAcctBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAccountCodeEnd.Text = e.Code
      AccountBook.GetAccountBook(txtAccountCodeEnd, txtTemp, Me.m_AccountBookEnd)
    End Sub

#End Region

  End Class
End Namespace

