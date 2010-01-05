Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BankTransferDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNote As Longkong.Pojjaman.Gui.Components.MultiLineTextBox
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblBankcharge As System.Windows.Forms.Label
    Friend WithEvents txtBankcharge As System.Windows.Forms.TextBox
    Friend WithEvents lblBaht1 As System.Windows.Forms.Label
    Friend WithEvents lblWHT As System.Windows.Forms.Label
    Friend WithEvents txtWHT As System.Windows.Forms.TextBox
    Friend WithEvents lblBaht2 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCqCode As System.Windows.Forms.TextBox
    Friend WithEvents grbDestination As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnDestinationFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDestinationBranch As System.Windows.Forms.TextBox
    Friend WithEvents lblDestinationBranch As System.Windows.Forms.Label
    Friend WithEvents lblDestination As System.Windows.Forms.Label
    Friend WithEvents btnDestinationEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDestinationCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDestinationName As System.Windows.Forms.TextBox
    Friend WithEvents grbSource As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnSourceFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSourceBranch As System.Windows.Forms.TextBox
    Friend WithEvents lblSourceBranch As System.Windows.Forms.Label
    Friend WithEvents btnSourceEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents txtSourceName As System.Windows.Forms.TextBox
    Friend WithEvents txtSourceCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCqCode As System.Windows.Forms.Label
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblBankAcctType As System.Windows.Forms.Label
    Friend WithEvents cmbBankAcctType As System.Windows.Forms.ComboBox
    Friend WithEvents ibtnShowCheckDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblBaht3 As System.Windows.Forms.Label
    Friend WithEvents txtSum As System.Windows.Forms.TextBox
    Friend WithEvents lblSum As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox

    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankTransferDetail))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnShowCheckDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblBankcharge = New System.Windows.Forms.Label()
      Me.txtBankcharge = New System.Windows.Forms.TextBox()
      Me.lblBaht1 = New System.Windows.Forms.Label()
      Me.lblWHT = New System.Windows.Forms.Label()
      Me.txtWHT = New System.Windows.Forms.TextBox()
      Me.lblBaht2 = New System.Windows.Forms.Label()
      Me.grbDestination = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnDestinationFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDestinationBranch = New System.Windows.Forms.TextBox()
      Me.lblDestinationBranch = New System.Windows.Forms.Label()
      Me.lblDestination = New System.Windows.Forms.Label()
      Me.btnDestinationEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDestinationCode = New System.Windows.Forms.TextBox()
      Me.txtDestinationName = New System.Windows.Forms.TextBox()
      Me.grbSource = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblBankAcctType = New System.Windows.Forms.Label()
      Me.cmbBankAcctType = New System.Windows.Forms.ComboBox()
      Me.btnSourceFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSourceBranch = New System.Windows.Forms.TextBox()
      Me.lblSourceBranch = New System.Windows.Forms.Label()
      Me.btnSourceEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblSource = New System.Windows.Forms.Label()
      Me.txtSourceName = New System.Windows.Forms.TextBox()
      Me.txtSourceCode = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.txtNote = New Longkong.Pojjaman.Gui.Components.MultiLineTextBox()
      Me.lblCqCode = New System.Windows.Forms.Label()
      Me.txtCqCode = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.txtSum = New System.Windows.Forms.TextBox()
      Me.lblBaht3 = New System.Windows.Forms.Label()
      Me.lblSum = New System.Windows.Forms.Label()
      Me.grbMaster.SuspendLayout()
      Me.grbDestination.SuspendLayout()
      Me.grbSource.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.lblSum)
      Me.grbMaster.Controls.Add(Me.lblBaht3)
      Me.grbMaster.Controls.Add(Me.txtSum)
      Me.grbMaster.Controls.Add(Me.ibtnShowCheckDialog)
      Me.grbMaster.Controls.Add(Me.chkAutorun)
      Me.grbMaster.Controls.Add(Me.lblStatus)
      Me.grbMaster.Controls.Add(Me.txtDocDate)
      Me.grbMaster.Controls.Add(Me.lblBaht)
      Me.grbMaster.Controls.Add(Me.lblAmount)
      Me.grbMaster.Controls.Add(Me.txtAmount)
      Me.grbMaster.Controls.Add(Me.lblBankcharge)
      Me.grbMaster.Controls.Add(Me.txtBankcharge)
      Me.grbMaster.Controls.Add(Me.lblBaht1)
      Me.grbMaster.Controls.Add(Me.lblWHT)
      Me.grbMaster.Controls.Add(Me.txtWHT)
      Me.grbMaster.Controls.Add(Me.lblBaht2)
      Me.grbMaster.Controls.Add(Me.grbDestination)
      Me.grbMaster.Controls.Add(Me.grbSource)
      Me.grbMaster.Controls.Add(Me.lblNote)
      Me.grbMaster.Controls.Add(Me.txtNote)
      Me.grbMaster.Controls.Add(Me.lblCqCode)
      Me.grbMaster.Controls.Add(Me.txtCqCode)
      Me.grbMaster.Controls.Add(Me.lblCode)
      Me.grbMaster.Controls.Add(Me.txtCode)
      Me.grbMaster.Controls.Add(Me.lblDocDate)
      Me.grbMaster.Controls.Add(Me.dtpDocDate)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(696, 400)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "รายละเอียดโอนเงิน"
      '
      'ibtnShowCheckDialog
      '
      Me.ibtnShowCheckDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCheckDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCheckDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCheckDialog.Location = New System.Drawing.Point(267, 47)
      Me.ibtnShowCheckDialog.Name = "ibtnShowCheckDialog"
      Me.ibtnShowCheckDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCheckDialog.TabIndex = 182
      Me.ibtnShowCheckDialog.TabStop = False
      Me.ibtnShowCheckDialog.ThemedImage = CType(resources.GetObject("ibtnShowCheckDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(264, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 3
      Me.chkAutorun.TabStop = False
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Location = New System.Drawing.Point(16, 376)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(48, 13)
      Me.lblStatus.TabIndex = 37
      Me.lblStatus.Text = "lblStatus"
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.txtDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(384, 24)
      Me.txtDocDate.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(124, 21)
      Me.txtDocDate.TabIndex = 4
      '
      'lblBaht
      '
      Me.lblBaht.AutoSize = True
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.ForeColor = System.Drawing.Color.Black
      Me.lblBaht.Location = New System.Drawing.Point(496, 280)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(27, 13)
      Me.lblBaht.TabIndex = 30
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(240, 280)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(136, 18)
      Me.lblAmount.TabIndex = 28
      Me.lblAmount.Text = "จำนวนโอน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAmount
      '
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(384, 280)
      Me.txtAmount.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(104, 21)
      Me.txtAmount.TabIndex = 29
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBankcharge
      '
      Me.lblBankcharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankcharge.ForeColor = System.Drawing.Color.Black
      Me.lblBankcharge.Location = New System.Drawing.Point(240, 304)
      Me.lblBankcharge.Name = "lblBankcharge"
      Me.lblBankcharge.Size = New System.Drawing.Size(136, 18)
      Me.lblBankcharge.TabIndex = 31
      Me.lblBankcharge.Text = "ค่าธรรมเนียมธนาคาร:"
      Me.lblBankcharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBankcharge
      '
      Me.Validator.SetDataType(Me.txtBankcharge, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtBankcharge, "")
      Me.txtBankcharge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBankcharge, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankcharge, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankcharge, System.Drawing.Color.Empty)
      Me.txtBankcharge.Location = New System.Drawing.Point(384, 304)
      Me.txtBankcharge.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtBankcharge, "")
      Me.txtBankcharge.Name = "txtBankcharge"
      Me.Validator.SetRegularExpression(Me.txtBankcharge, "")
      Me.Validator.SetRequired(Me.txtBankcharge, False)
      Me.txtBankcharge.Size = New System.Drawing.Size(104, 21)
      Me.txtBankcharge.TabIndex = 32
      Me.txtBankcharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBaht1
      '
      Me.lblBaht1.AutoSize = True
      Me.lblBaht1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht1.ForeColor = System.Drawing.Color.Black
      Me.lblBaht1.Location = New System.Drawing.Point(496, 304)
      Me.lblBaht1.Name = "lblBaht1"
      Me.lblBaht1.Size = New System.Drawing.Size(27, 13)
      Me.lblBaht1.TabIndex = 33
      Me.lblBaht1.Text = "บาท"
      Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblWHT
      '
      Me.lblWHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWHT.ForeColor = System.Drawing.Color.Black
      Me.lblWHT.Location = New System.Drawing.Point(240, 328)
      Me.lblWHT.Name = "lblWHT"
      Me.lblWHT.Size = New System.Drawing.Size(136, 18)
      Me.lblWHT.TabIndex = 34
      Me.lblWHT.Text = "ภาษ๊หัก ณ ที่จ่าย:"
      Me.lblWHT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtWHT
      '
      Me.Validator.SetDataType(Me.txtWHT, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtWHT, "")
      Me.txtWHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtWHT, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtWHT, -15)
      Me.Validator.SetInvalidBackColor(Me.txtWHT, System.Drawing.Color.Empty)
      Me.txtWHT.Location = New System.Drawing.Point(384, 328)
      Me.txtWHT.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtWHT, "")
      Me.txtWHT.Name = "txtWHT"
      Me.txtWHT.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWHT, "")
      Me.Validator.SetRequired(Me.txtWHT, False)
      Me.txtWHT.Size = New System.Drawing.Size(104, 21)
      Me.txtWHT.TabIndex = 35
      Me.txtWHT.TabStop = False
      Me.txtWHT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBaht2
      '
      Me.lblBaht2.AutoSize = True
      Me.lblBaht2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht2.ForeColor = System.Drawing.Color.Black
      Me.lblBaht2.Location = New System.Drawing.Point(496, 328)
      Me.lblBaht2.Name = "lblBaht2"
      Me.lblBaht2.Size = New System.Drawing.Size(27, 13)
      Me.lblBaht2.TabIndex = 36
      Me.lblBaht2.Text = "บาท"
      Me.lblBaht2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbDestination
      '
      Me.grbDestination.Controls.Add(Me.btnDestinationFind)
      Me.grbDestination.Controls.Add(Me.txtDestinationBranch)
      Me.grbDestination.Controls.Add(Me.lblDestinationBranch)
      Me.grbDestination.Controls.Add(Me.lblDestination)
      Me.grbDestination.Controls.Add(Me.btnDestinationEdit)
      Me.grbDestination.Controls.Add(Me.txtDestinationCode)
      Me.grbDestination.Controls.Add(Me.txtDestinationName)
      Me.grbDestination.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDestination.Location = New System.Drawing.Point(12, 200)
      Me.grbDestination.Name = "grbDestination"
      Me.grbDestination.Size = New System.Drawing.Size(548, 72)
      Me.grbDestination.TabIndex = 20
      Me.grbDestination.TabStop = False
      Me.grbDestination.Text = "โอนเข้า"
      '
      'btnDestinationFind
      '
      Me.btnDestinationFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDestinationFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDestinationFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDestinationFind.Location = New System.Drawing.Point(472, 16)
      Me.btnDestinationFind.Name = "btnDestinationFind"
      Me.btnDestinationFind.Size = New System.Drawing.Size(24, 23)
      Me.btnDestinationFind.TabIndex = 24
      Me.btnDestinationFind.TabStop = False
      Me.btnDestinationFind.ThemedImage = CType(resources.GetObject("btnDestinationFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDestinationBranch
      '
      Me.Validator.SetDataType(Me.txtDestinationBranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDestinationBranch, "")
      Me.txtDestinationBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDestinationBranch, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDestinationBranch, System.Drawing.Color.Empty)
      Me.txtDestinationBranch.Location = New System.Drawing.Point(128, 40)
      Me.txtDestinationBranch.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtDestinationBranch, "")
      Me.txtDestinationBranch.Name = "txtDestinationBranch"
      Me.txtDestinationBranch.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDestinationBranch, "")
      Me.Validator.SetRequired(Me.txtDestinationBranch, False)
      Me.txtDestinationBranch.Size = New System.Drawing.Size(392, 21)
      Me.txtDestinationBranch.TabIndex = 27
      Me.txtDestinationBranch.TabStop = False
      '
      'lblDestinationBranch
      '
      Me.lblDestinationBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDestinationBranch.ForeColor = System.Drawing.Color.Black
      Me.lblDestinationBranch.Location = New System.Drawing.Point(8, 40)
      Me.lblDestinationBranch.Name = "lblDestinationBranch"
      Me.lblDestinationBranch.Size = New System.Drawing.Size(112, 16)
      Me.lblDestinationBranch.TabIndex = 26
      Me.lblDestinationBranch.Text = "ธนาคาร/สาขา:"
      Me.lblDestinationBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDestination
      '
      Me.lblDestination.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDestination.ForeColor = System.Drawing.Color.Black
      Me.lblDestination.Location = New System.Drawing.Point(8, 16)
      Me.lblDestination.Name = "lblDestination"
      Me.lblDestination.Size = New System.Drawing.Size(112, 18)
      Me.lblDestination.TabIndex = 21
      Me.lblDestination.Text = "สมุดเงินฝากธนาคาร:"
      Me.lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnDestinationEdit
      '
      Me.btnDestinationEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDestinationEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDestinationEdit.Location = New System.Drawing.Point(496, 16)
      Me.btnDestinationEdit.Name = "btnDestinationEdit"
      Me.btnDestinationEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnDestinationEdit.TabIndex = 25
      Me.btnDestinationEdit.TabStop = False
      Me.btnDestinationEdit.ThemedImage = CType(resources.GetObject("btnDestinationEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDestinationCode
      '
      Me.Validator.SetDataType(Me.txtDestinationCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDestinationCode, "")
      Me.txtDestinationCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDestinationCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDestinationCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDestinationCode, System.Drawing.Color.Empty)
      Me.txtDestinationCode.Location = New System.Drawing.Point(128, 16)
      Me.txtDestinationCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtDestinationCode, "")
      Me.txtDestinationCode.Name = "txtDestinationCode"
      Me.Validator.SetRegularExpression(Me.txtDestinationCode, "")
      Me.Validator.SetRequired(Me.txtDestinationCode, True)
      Me.txtDestinationCode.Size = New System.Drawing.Size(128, 21)
      Me.txtDestinationCode.TabIndex = 22
      '
      'txtDestinationName
      '
      Me.Validator.SetDataType(Me.txtDestinationName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDestinationName, "")
      Me.txtDestinationName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDestinationName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDestinationName, System.Drawing.Color.Empty)
      Me.txtDestinationName.Location = New System.Drawing.Point(256, 16)
      Me.txtDestinationName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtDestinationName, "")
      Me.txtDestinationName.Name = "txtDestinationName"
      Me.txtDestinationName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDestinationName, "")
      Me.Validator.SetRequired(Me.txtDestinationName, False)
      Me.txtDestinationName.Size = New System.Drawing.Size(216, 21)
      Me.txtDestinationName.TabIndex = 23
      Me.txtDestinationName.TabStop = False
      '
      'grbSource
      '
      Me.grbSource.Controls.Add(Me.lblBankAcctType)
      Me.grbSource.Controls.Add(Me.cmbBankAcctType)
      Me.grbSource.Controls.Add(Me.btnSourceFind)
      Me.grbSource.Controls.Add(Me.txtSourceBranch)
      Me.grbSource.Controls.Add(Me.lblSourceBranch)
      Me.grbSource.Controls.Add(Me.btnSourceEdit)
      Me.grbSource.Controls.Add(Me.lblSource)
      Me.grbSource.Controls.Add(Me.txtSourceName)
      Me.grbSource.Controls.Add(Me.txtSourceCode)
      Me.grbSource.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSource.Location = New System.Drawing.Point(12, 96)
      Me.grbSource.Name = "grbSource"
      Me.grbSource.Size = New System.Drawing.Size(548, 96)
      Me.grbSource.TabIndex = 10
      Me.grbSource.TabStop = False
      Me.grbSource.Text = "โอนจาก"
      '
      'lblBankAcctType
      '
      Me.lblBankAcctType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAcctType.ForeColor = System.Drawing.Color.Black
      Me.lblBankAcctType.Location = New System.Drawing.Point(8, 64)
      Me.lblBankAcctType.Name = "lblBankAcctType"
      Me.lblBankAcctType.Size = New System.Drawing.Size(112, 18)
      Me.lblBankAcctType.TabIndex = 18
      Me.lblBankAcctType.Text = "ประเภทสมุดบัญชี:"
      Me.lblBankAcctType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbBankAcctType
      '
      Me.cmbBankAcctType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbBankAcctType.Enabled = False
      Me.cmbBankAcctType.Location = New System.Drawing.Point(128, 64)
      Me.cmbBankAcctType.Name = "cmbBankAcctType"
      Me.cmbBankAcctType.Size = New System.Drawing.Size(152, 21)
      Me.cmbBankAcctType.TabIndex = 19
      Me.cmbBankAcctType.TabStop = False
      '
      'btnSourceFind
      '
      Me.btnSourceFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSourceFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSourceFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSourceFind.Location = New System.Drawing.Point(472, 16)
      Me.btnSourceFind.Name = "btnSourceFind"
      Me.btnSourceFind.Size = New System.Drawing.Size(24, 23)
      Me.btnSourceFind.TabIndex = 14
      Me.btnSourceFind.TabStop = False
      Me.btnSourceFind.ThemedImage = CType(resources.GetObject("btnSourceFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSourceBranch
      '
      Me.Validator.SetDataType(Me.txtSourceBranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSourceBranch, "")
      Me.txtSourceBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSourceBranch, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSourceBranch, System.Drawing.Color.Empty)
      Me.txtSourceBranch.Location = New System.Drawing.Point(128, 40)
      Me.txtSourceBranch.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtSourceBranch, "")
      Me.txtSourceBranch.Name = "txtSourceBranch"
      Me.txtSourceBranch.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSourceBranch, "")
      Me.Validator.SetRequired(Me.txtSourceBranch, False)
      Me.txtSourceBranch.Size = New System.Drawing.Size(392, 21)
      Me.txtSourceBranch.TabIndex = 17
      Me.txtSourceBranch.TabStop = False
      '
      'lblSourceBranch
      '
      Me.lblSourceBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSourceBranch.ForeColor = System.Drawing.Color.Black
      Me.lblSourceBranch.Location = New System.Drawing.Point(8, 40)
      Me.lblSourceBranch.Name = "lblSourceBranch"
      Me.lblSourceBranch.Size = New System.Drawing.Size(112, 16)
      Me.lblSourceBranch.TabIndex = 16
      Me.lblSourceBranch.Text = "ธนาคาร/สาขา:"
      Me.lblSourceBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSourceEdit
      '
      Me.btnSourceEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSourceEdit.Location = New System.Drawing.Point(496, 16)
      Me.btnSourceEdit.Name = "btnSourceEdit"
      Me.btnSourceEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnSourceEdit.TabIndex = 15
      Me.btnSourceEdit.TabStop = False
      Me.btnSourceEdit.ThemedImage = CType(resources.GetObject("btnSourceEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblSource
      '
      Me.lblSource.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSource.ForeColor = System.Drawing.Color.Black
      Me.lblSource.Location = New System.Drawing.Point(8, 16)
      Me.lblSource.Name = "lblSource"
      Me.lblSource.Size = New System.Drawing.Size(112, 18)
      Me.lblSource.TabIndex = 11
      Me.lblSource.Text = "สมุดเงินฝากธนาคาร:"
      Me.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSourceName
      '
      Me.Validator.SetDataType(Me.txtSourceName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSourceName, "")
      Me.txtSourceName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSourceName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSourceName, System.Drawing.Color.Empty)
      Me.txtSourceName.Location = New System.Drawing.Point(256, 16)
      Me.txtSourceName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtSourceName, "")
      Me.txtSourceName.Name = "txtSourceName"
      Me.txtSourceName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSourceName, "")
      Me.Validator.SetRequired(Me.txtSourceName, False)
      Me.txtSourceName.Size = New System.Drawing.Size(216, 21)
      Me.txtSourceName.TabIndex = 13
      Me.txtSourceName.TabStop = False
      '
      'txtSourceCode
      '
      Me.Validator.SetDataType(Me.txtSourceCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSourceCode, "")
      Me.txtSourceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSourceCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSourceCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSourceCode, System.Drawing.Color.Empty)
      Me.txtSourceCode.Location = New System.Drawing.Point(128, 16)
      Me.txtSourceCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtSourceCode, "")
      Me.txtSourceCode.Name = "txtSourceCode"
      Me.Validator.SetRegularExpression(Me.txtSourceCode, "")
      Me.Validator.SetRequired(Me.txtSourceCode, True)
      Me.txtSourceCode.Size = New System.Drawing.Size(128, 21)
      Me.txtSourceCode.TabIndex = 12
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.ForeColor = System.Drawing.Color.Black
      Me.lblNote.Location = New System.Drawing.Point(8, 72)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(120, 18)
      Me.lblNote.TabIndex = 8
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(136, 72)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(392, 21)
      Me.txtNote.TabIndex = 9
      '
      'lblCqCode
      '
      Me.lblCqCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCqCode.ForeColor = System.Drawing.Color.Black
      Me.lblCqCode.Location = New System.Drawing.Point(8, 48)
      Me.lblCqCode.Name = "lblCqCode"
      Me.lblCqCode.Size = New System.Drawing.Size(120, 18)
      Me.lblCqCode.TabIndex = 6
      Me.lblCqCode.Text = "เลขที่เช็ค:"
      Me.lblCqCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCqCode
      '
      Me.Validator.SetDataType(Me.txtCqCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCqCode, "")
      Me.txtCqCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCqCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCqCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCqCode, System.Drawing.Color.Empty)
      Me.txtCqCode.Location = New System.Drawing.Point(136, 48)
      Me.txtCqCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCqCode, "")
      Me.txtCqCode.Name = "txtCqCode"
      Me.Validator.SetRegularExpression(Me.txtCqCode, "")
      Me.Validator.SetRequired(Me.txtCqCode, False)
      Me.txtCqCode.Size = New System.Drawing.Size(128, 21)
      Me.txtCqCode.TabIndex = 7
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(120, 18)
      Me.lblCode.TabIndex = 1
      Me.lblCode.Text = "รหัสเอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(136, 24)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(128, 21)
      Me.txtCode.TabIndex = 2
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(288, 24)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDate.TabIndex = 181
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDate.Location = New System.Drawing.Point(384, 24)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDate.TabIndex = 5
      Me.dtpDocDate.TabStop = False
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'txtSum
      '
      Me.Validator.SetDataType(Me.txtSum, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtSum, "")
      Me.txtSum.Enabled = False
      Me.txtSum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSum, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSum, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSum, System.Drawing.Color.Empty)
      Me.txtSum.Location = New System.Drawing.Point(384, 352)
      Me.txtSum.MaxLength = 13
      Me.Validator.SetMinValue(Me.txtSum, "")
      Me.txtSum.Name = "txtSum"
      Me.txtSum.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSum, "")
      Me.Validator.SetRequired(Me.txtSum, False)
      Me.txtSum.Size = New System.Drawing.Size(104, 21)
      Me.txtSum.TabIndex = 183
      Me.txtSum.TabStop = False
      Me.txtSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBaht3
      '
      Me.lblBaht3.AutoSize = True
      Me.lblBaht3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht3.ForeColor = System.Drawing.Color.Black
      Me.lblBaht3.Location = New System.Drawing.Point(496, 354)
      Me.lblBaht3.Name = "lblBaht3"
      Me.lblBaht3.Size = New System.Drawing.Size(27, 13)
      Me.lblBaht3.TabIndex = 184
      Me.lblBaht3.Text = "บาท"
      Me.lblBaht3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblSum
      '
      Me.lblSum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSum.ForeColor = System.Drawing.Color.Black
      Me.lblSum.Location = New System.Drawing.Point(331, 353)
      Me.lblSum.Name = "lblSum"
      Me.lblSum.Size = New System.Drawing.Size(45, 18)
      Me.lblSum.TabIndex = 185
      Me.lblSum.Text = "รวม:"
      Me.lblSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'BankTransferDetail
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Name = "BankTransferDetail"
      Me.Size = New System.Drawing.Size(712, 424)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbDestination.ResumeLayout(False)
      Me.grbDestination.PerformLayout()
      Me.grbSource.ResumeLayout(False)
      Me.grbSource.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

    Private Enum BankFocus
      BankSource
      BankDestination
    End Enum

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.grbMaster}")
      Me.grbSource.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.grbSource}")
      Me.grbDestination.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.grbDestination}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.lblAmount}")
      Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

      Me.lblBankcharge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.lblBankcharge}")
      Me.Validator.SetDisplayName(txtBankcharge, lblBankcharge.Text)

      Me.lblWHT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.lblWHT}")
      Me.Validator.SetDisplayName(txtWHT, lblWHT.Text)

      Me.lblDestinationBranch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.lblDestinationBranch}")
      Me.lblSourceBranch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.lblSourceBranch}")

      Me.lblCqCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.lblCqCode}")
      Me.Validator.SetDisplayName(txtCqCode, lblCqCode.Text)

      Me.lblSource.Text = Me.StringParserService.Parse("${res:Global.BankAccountText}")
      Me.Validator.SetDisplayName(txtSourceCode, lblSource.Text)

      Me.lblDestination.Text = Me.StringParserService.Parse("${res:Global.BankAccountText}")
      Me.Validator.SetDisplayName(txtDestinationCode, lblDestination.Text)

      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblBaht2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

    End Sub
#End Region

#Region "Members"
    Private m_entity As BankTransfer
    Private m_isInitialized As Boolean = False
#End Region

#Region "Methods"
    Private Sub UpdateBankBranchName(ByVal focus As BankFocus)
      Dim oldStatus As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Select Case focus
        Case BankFocus.BankSource
          If Me.m_entity.Bankacct.BankBranch Is Nothing OrElse Not Me.m_entity.Bankacct.BankBranch.Originated Then
            txtSourceBranch.Text = ""
            cmbBankAcctType.SelectedIndex = 0
          Else
            txtSourceBranch.Text = Me.m_entity.Bankacct.BankBranch.Bank.Name & " / " & _
                                   Me.m_entity.Bankacct.BankBranch.Name
          End If
          If Me.m_entity.Bankacct.Type Is Nothing Then
            Me.m_entity.Bankacct.Type = New BankAccountType(1)
          End If
          For Each item As IdValuePair In Me.cmbBankAcctType.Items
            If item.Id = Me.m_entity.Bankacct.Type.Value Then
              cmbBankAcctType.SelectedItem = item
            End If
          Next
          'Hack: Harcoded
          If (Me.m_entity.Bankacct.Type.Value = 3) Then
            'กระแสรายวัน
            If CBool(Configuration.GetConfig("AllowNoCqCode")) = True Then
              Me.Validator.SetRequired(Me.txtCqCode, False)
            Else
              Me.Validator.SetRequired(Me.txtCqCode, True)
            End If
          Else
            Me.Validator.SetRequired(Me.txtCqCode, False)
            Me.ErrorProvider1.SetError(Me.txtCqCode, "")
          End If
        Case BankFocus.BankDestination
          If Me.m_entity.BankacctDestinate.BankBranch Is Nothing OrElse Not Me.m_entity.BankacctDestinate.BankBranch.Originated Then
            txtDestinationBranch.Text = ""
          Else
            txtDestinationBranch.Text = Me.m_entity.BankacctDestinate.BankBranch.Bank.Name & " / " & _
                                   Me.m_entity.BankacctDestinate.BankBranch.Name
          End If
      End Select
      Me.m_isInitialized = oldStatus
    End Sub
#End Region

#Region "Constructs"
    Public Sub New()
      MyBase.New()
      InitializeComponent()

      Initialize()
      EventWiring()
      SetLabelText()
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Not Me.m_entity.Check Is Nothing AndAlso Me.m_entity.Check.Originated Then
        Me.txtSourceCode.Enabled = False
        Me.txtAmount.Enabled = False
        Me.btnSourceEdit.Enabled = False
        Me.btnSourceFind.Enabled = False
      ElseIf Not Me.m_entity.Check Is Nothing AndAlso Not Me.m_entity.Check.Originated Then
        Me.txtSourceCode.Enabled = True
        Me.txtAmount.Enabled = True
        Me.btnSourceEdit.Enabled = True
        Me.btnSourceFind.Enabled = True
      End If
      If Not Me.m_entity.Status Is Nothing Then
        If Me.m_entity.Status.Value = 0 _
        OrElse Me.m_entity.Status.Value >= 3 _
        Then
          Me.Enabled = False
        Else
          Me.Enabled = True
        End If
      End If
    End Sub
    Public Overrides Sub Initialize()
      CodeDescription.ListCodeDescriptionInComboBox(cmbBankAcctType, "bankacct_type")
    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCqCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDestinationCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSourceCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBankcharge.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtWHT.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtAmount.Validated, AddressOf Me.NumberTextBoxChange
      AddHandler txtBankcharge.Validated, AddressOf Me.NumberTextBoxChange
      AddHandler txtWHT.Validated, AddressOf Me.NumberTextBoxChange
    End Sub
    Private Sub NumberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtamount"
          txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
        Case "txtbankcharge"
          txtBankcharge.Text = Configuration.FormatToString(Me.m_entity.BankCharge, DigitConfig.Price)
        Case "txtwht"
          txtWHT.Text = Configuration.FormatToString(Me.m_entity.WHT, DigitConfig.Price)
      End Select
    End Sub
    Private m_dateSetting As Boolean
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          dirtyFlag = True
          Me.m_entity.Code = txtCode.Text
        Case "txtcqcode"
          dirtyFlag = True
          'If Me.m_entity.Check.Originated Then
          'Me.m_entity.Check.DocStatus = New OutgoingCheckDocStatus(1)

          'End If
          Me.m_entity.CqCode = txtCqCode.Text
          Me.m_entity.Check = New OutgoingCheck
        Case "txtnote"
          dirtyFlag = True
          Me.m_entity.Note = txtNote.Text
        Case "dtpdocdate"
          If Not Me.m_entity.Docdate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.Docdate = dtpDocDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.Docdate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.Docdate = dtpDocDate.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDate.Value = Date.Now
            Me.m_entity.Docdate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "txtdestinationcode"
          Dim editBankacct As New BankAccount(txtDestinationCode.Text)
          If CheckSamBankAccount(BankFocus.BankDestination, editBankacct) Then
            txtDestinationCode.Text = ""
            txtDestinationName.Text = ""
            editBankacct = New BankAccount
          Else
            txtDestinationCode.Text = editBankacct.Code
            txtDestinationName.Text = editBankacct.Name
          End If
          Me.m_entity.BankacctDestinate = editBankacct
          UpdateBankBranchName(BankFocus.BankDestination)
          dirtyFlag = True

        Case "txtsourcecode"
          Dim editBankacct As New BankAccount(txtSourceCode.Text)
          If CheckSamBankAccount(BankFocus.BankSource, editBankacct) Then
            txtSourceCode.Text = ""
            txtSourceName.Text = ""
            editBankacct = New BankAccount
          Else
            txtSourceCode.Text = editBankacct.Code
            txtSourceName.Text = editBankacct.Name
          End If
          Me.m_entity.Bankacct = editBankacct
          UpdateBankBranchName(BankFocus.BankSource)
          dirtyFlag = True

        Case "txtamount"
          dirtyFlag = True
          If txtAmount.TextLength > 0 Then
            Me.m_entity.Amount = CDec(txtAmount.Text)
          Else
            Me.m_entity.Amount = Nothing
          End If

        Case "txtbankcharge"
          dirtyFlag = True
          If txtBankcharge.TextLength > 0 Then
            Me.m_entity.BankCharge = CDec(txtBankcharge.Text)
            If txtSum.TextLength > 0 Then
              Me.m_entity.Amount = CDec(txtSum.Text) - Me.m_entity.BankCharge
              txtAmount.Text = Me.m_entity.Amount
            End If
          Else
            Me.m_entity.BankCharge = Nothing
          End If

        Case "txtwht"

      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      SetStatus()
      CheckFormEnable()
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      txtCode.Text = Me.m_entity.Code
      txtCqCode.Text = Me.m_entity.CqCode
      txtSum.Text = Configuration.FormatToString(Me.m_entity.Amount + Me.m_entity.BankCharge, DigitConfig.Price)
      ' autogencode
      m_oldCode = m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      dtpDocDate.Value = MinDateToNow(Me.m_entity.Docdate)
      txtDocDate.Text = MinDateToNull(Me.m_entity.Docdate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      txtNote.Text = Me.m_entity.Note

      ' ผู้โอนให้
      If Not Me.m_entity.Bankacct Is Nothing Then
        txtSourceCode.Text = Me.m_entity.Bankacct.Code
        txtSourceName.Text = Me.m_entity.Bankacct.Name
        UpdateBankBranchName(BankFocus.BankSource)
      End If

      ' ผู้รับปลายทาง
      If Not Me.m_entity.BankacctDestinate Is Nothing Then
        txtDestinationCode.Text = Me.m_entity.BankacctDestinate.Code
        txtDestinationName.Text = Me.m_entity.BankacctDestinate.Name
        UpdateBankBranchName(BankFocus.BankDestination)
      End If

      txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
      txtBankcharge.Text = Configuration.FormatToString(Me.m_entity.BankCharge, DigitConfig.Price)

      If Not Me.m_entity.WitholdingTaxCollection Is Nothing Then
        txtWHT.Text = Configuration.FormatToString(Me.m_entity.WitholdingTaxCollection.Amount, DigitConfig.Price)
      End If

      For Each item As IdValuePair In Me.cmbBankAcctType.Items
        If item.Id = Me.m_entity.Bankacct.Type.Value Then
          cmbBankAcctType.SelectedItem = item
          Exit For
        End If
      Next

      m_isInitialized = True

      SetStatus()
      SetLabelText()
      CheckFormEnable()
    End Sub
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbMaster.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        End If
      Next

      txtDocDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      dtpDocDate.Value = Date.Now

      cmbBankAcctType.SelectedIndex = -1
      cmbBankAcctType.SelectedIndex = -1
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, BankTransfer)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Sub SetStatus()
      If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
        lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  โดย:" & m_entity.CancelPerson.Name
      ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
        lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  โดย:" & m_entity.LastEditor.Name
      ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
        lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  โดย:" & m_entity.Originator.Name
      Else
        lblStatus.Text = "ยังไม่ได้บันทึก"
      End If
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"

#End Region

#Region "Event of Button controls"
    ' BankAccount Source 
    Private Sub btnSourceEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSourceEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New BankAccount)
    End Sub
    Private Sub btnSourceFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSourceFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountSourceDialog)
    End Sub
    Private Sub SetBankAccountSourceDialog(ByVal e As ISimpleEntity)
      If CheckSamBankAccount(BankFocus.BankSource, e) Then
        txtSourceCode.Text = ""
        txtSourceName.Text = ""
        Me.m_entity.Bankacct = New BankAccount
        UpdateBankBranchName(BankFocus.BankSource)
        Return
      End If
      Me.txtSourceCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or BankAccount.GetBankAccount(txtSourceCode, txtSourceName, Me.m_entity.Bankacct)
      UpdateBankBranchName(BankFocus.BankSource)
    End Sub

    ' BankAccount Destination
    Private Sub btnDestinationEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDestinationEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New BankAccount)
    End Sub
    Private Sub btnDestinationFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDestinationFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountDestinateDialog)
    End Sub
    Private Sub SetBankAccountDestinateDialog(ByVal e As ISimpleEntity)
      If CheckSamBankAccount(BankFocus.BankDestination, e) Then
        txtDestinationCode.Text = ""
        txtDestinationName.Text = ""
        Me.m_entity.BankacctDestinate = New BankAccount
        UpdateBankBranchName(BankFocus.BankDestination)
        Return
      End If
      Me.txtDestinationCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or BankAccount.GetBankAccount(txtDestinationCode, txtDestinationName, Me.m_entity.BankacctDestinate)
      UpdateBankBranchName(BankFocus.BankDestination)
    End Sub
    Private Function CheckSamBankAccount(ByVal traget As BankFocus, ByVal e As ISimpleEntity) As Boolean
      Select Case traget
        Case BankFocus.BankSource
          If Not Me.m_entity.BankacctDestinate Is Nothing AndAlso Me.m_entity.BankacctDestinate.Originated Then
            If e.Id = Me.m_entity.BankacctDestinate.Id Then
              Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              myMessageService.ShowWarningFormatted("${res:Global.BankAccountOutDuplicateIn}")
              txtSourceCode.Focus()
              Return True
            End If
          End If
        Case BankFocus.BankDestination
          If Not Me.m_entity.Bankacct Is Nothing AndAlso Me.m_entity.Bankacct.Originated Then
            If e.Id = Me.m_entity.Bankacct.Id Then
              Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              myMessageService.ShowWarningFormatted("${res:Global.BankAccountOutDuplicateIn}")
              txtDestinationCode.Focus()
              Return True
            End If
          End If
        Case Else
          Return False
      End Select
      Return False
    End Function


#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New BankAccount).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsourcecode", "txtsourcename" _
                  , "txtdestinationcode", "txtdestinationname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New BankAccount).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New BankAccount).FullClassName))
        Dim entity As New BankAccount(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsourcecode", "txtsourcename"
              Me.SetBankAccountSourceDialog(entity)
            Case "txtdestinationcode", "txtdestinationname"
              Me.SetBankAccountDestinateDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Autogencode "
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        m_oldCode = Me.txtCode.Text
        Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
#End Region

    Private Sub ibtnShowCheckDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCheckDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)

      Dim filters(0) As Filter
      'filters(0) = New Filter("IDList", GenIDListFromDataTable()) 'ID ที่ต้องไม่เรียกมา
      filters(0) = New Filter("showOnlyAmountMoreThanZero", True)

      myEntityPanelService.OpenListDialog(New OutgoingCheck, AddressOf SetCheck, filters)
    End Sub
    Private Sub SetCheck(ByVal e As ISimpleEntity)

      Me.txtCqCode.Text = CType(e, OutgoingCheck).CqCode
      Me.ChangeProperty(txtCqCode, Nothing)
      Me.txtAmount.Text = CType(e, OutgoingCheck).Amount '- CType(e, OutgoingCheck).BankCharge
      Me.ChangeProperty(txtAmount, Nothing)
      Me.txtSum.Text = CType(e, OutgoingCheck).Amount
      Me.ChangeProperty(txtSum, Nothing)
      Me.txtSourceCode.Text = CType(e, OutgoingCheck).Bankacct.Code
      Me.ChangeProperty(txtSourceCode, Nothing)
      Me.txtBankcharge.Text = 0
      Me.ChangeProperty(txtBankcharge, Nothing)

      CType(Me.Entity, BankTransfer).Check = CType(e, OutgoingCheck)

      Me.CheckFormEnable()

    End Sub
  End Class
End Namespace