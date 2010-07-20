Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BankTransferOutDetailView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable, IReversibleEntityProperty

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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbBankTransferOut As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblIssueDate As System.Windows.Forms.Label
    Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBankAccount As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblBank As System.Windows.Forms.Label
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtIssueDate As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtbankbranch As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents btnBankAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSupplierFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSupplierEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnBankAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblBaht3 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents RadGridView2 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cmbExportType As System.Windows.Forms.ComboBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankTransferOutDetailView))
      Me.grbBankTransferOut = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbExportType = New System.Windows.Forms.ComboBox()
      Me.btnExport = New System.Windows.Forms.Button()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.RadGridView2 = New Telerik.WinControls.UI.RadGridView()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtTotal = New System.Windows.Forms.TextBox()
      Me.lblBaht3 = New System.Windows.Forms.Label()
      Me.lblTotal = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.btnBankAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnSupplierFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtIssueDate = New System.Windows.Forms.TextBox()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.txtAmount = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.btnSupplierEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.lblIssueDate = New System.Windows.Forms.Label()
      Me.lblBankAccount = New System.Windows.Forms.Label()
      Me.lblAmount = New System.Windows.Forms.Label()
      Me.lblCurrency = New System.Windows.Forms.Label()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.btnBankAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblBank = New System.Windows.Forms.Label()
      Me.txtbankbranch = New System.Windows.Forms.TextBox()
      Me.txtBankAccountCode = New System.Windows.Forms.TextBox()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.txtBankAccountName = New System.Windows.Forms.TextBox()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbBankTransferOut.SuspendLayout()
      CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbBankTransferOut
      '
      Me.grbBankTransferOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbBankTransferOut.Controls.Add(Me.cmbExportType)
      Me.grbBankTransferOut.Controls.Add(Me.btnExport)
      Me.grbBankTransferOut.Controls.Add(Me.ibtnDelRow)
      Me.grbBankTransferOut.Controls.Add(Me.RadGridView2)
      Me.grbBankTransferOut.Controls.Add(Me.ibtnBlank)
      Me.grbBankTransferOut.Controls.Add(Me.txtTotal)
      Me.grbBankTransferOut.Controls.Add(Me.lblBaht3)
      Me.grbBankTransferOut.Controls.Add(Me.lblTotal)
      Me.grbBankTransferOut.Controls.Add(Me.lblItem)
      Me.grbBankTransferOut.Controls.Add(Me.chkAutorun)
      Me.grbBankTransferOut.Controls.Add(Me.btnBankAccountFind)
      Me.grbBankTransferOut.Controls.Add(Me.btnSupplierFind)
      Me.grbBankTransferOut.Controls.Add(Me.txtIssueDate)
      Me.grbBankTransferOut.Controls.Add(Me.txtSupplierCode)
      Me.grbBankTransferOut.Controls.Add(Me.txtAmount)
      Me.grbBankTransferOut.Controls.Add(Me.lblCode)
      Me.grbBankTransferOut.Controls.Add(Me.btnSupplierEdit)
      Me.grbBankTransferOut.Controls.Add(Me.dtpIssueDate)
      Me.grbBankTransferOut.Controls.Add(Me.lblSupplier)
      Me.grbBankTransferOut.Controls.Add(Me.lblIssueDate)
      Me.grbBankTransferOut.Controls.Add(Me.lblBankAccount)
      Me.grbBankTransferOut.Controls.Add(Me.lblAmount)
      Me.grbBankTransferOut.Controls.Add(Me.lblCurrency)
      Me.grbBankTransferOut.Controls.Add(Me.lblStatus)
      Me.grbBankTransferOut.Controls.Add(Me.btnBankAccountEdit)
      Me.grbBankTransferOut.Controls.Add(Me.lblBank)
      Me.grbBankTransferOut.Controls.Add(Me.txtbankbranch)
      Me.grbBankTransferOut.Controls.Add(Me.txtBankAccountCode)
      Me.grbBankTransferOut.Controls.Add(Me.txtSupplierName)
      Me.grbBankTransferOut.Controls.Add(Me.txtBankAccountName)
      Me.grbBankTransferOut.Controls.Add(Me.txtCode)
      Me.grbBankTransferOut.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbBankTransferOut.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbBankTransferOut.ForeColor = System.Drawing.Color.Blue
      Me.grbBankTransferOut.Location = New System.Drawing.Point(8, 8)
      Me.grbBankTransferOut.Name = "grbBankTransferOut"
      Me.grbBankTransferOut.Size = New System.Drawing.Size(693, 520)
      Me.grbBankTransferOut.TabIndex = 0
      Me.grbBankTransferOut.TabStop = False
      Me.grbBankTransferOut.Text = "ข้อมูลเงินโอน : "
      '
      'cmbExportType
      '
      Me.cmbExportType.FormattingEnabled = True
      Me.cmbExportType.Items.AddRange(New Object() {"MCL", "DCT", "PCT"})
      Me.cmbExportType.Location = New System.Drawing.Point(300, 164)
      Me.cmbExportType.Name = "cmbExportType"
      Me.cmbExportType.Size = New System.Drawing.Size(82, 21)
      Me.cmbExportType.TabIndex = 209
      Me.cmbExportType.TabStop = False
      '
      'btnExport
      '
      Me.btnExport.Location = New System.Drawing.Point(219, 162)
      Me.btnExport.Name = "btnExport"
      Me.btnExport.Size = New System.Drawing.Size(75, 23)
      Me.btnExport.TabIndex = 208
      Me.btnExport.TabStop = False
      Me.btnExport.Text = "Export"
      Me.btnExport.UseVisualStyleBackColor = True
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(189, 162)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 207
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'RadGridView2
      '
      Me.RadGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.RadGridView2.Location = New System.Drawing.Point(19, 189)
      Me.RadGridView2.Name = "RadGridView2"
      Me.RadGridView2.Size = New System.Drawing.Size(668, 304)
      Me.RadGridView2.TabIndex = 206
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(161, 162)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 205
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtTotal
      '
      Me.Validator.SetDataType(Me.txtTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotal, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotal, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotal, System.Drawing.Color.Empty)
      Me.txtTotal.Location = New System.Drawing.Point(509, 162)
      Me.Validator.SetMinValue(Me.txtTotal, "")
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotal, "")
      Me.Validator.SetRequired(Me.txtTotal, False)
      Me.txtTotal.Size = New System.Drawing.Size(136, 21)
      Me.txtTotal.TabIndex = 201
      '
      'lblBaht3
      '
      Me.lblBaht3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht3.ForeColor = System.Drawing.Color.Black
      Me.lblBaht3.Location = New System.Drawing.Point(653, 162)
      Me.lblBaht3.Name = "lblBaht3"
      Me.lblBaht3.Size = New System.Drawing.Size(32, 16)
      Me.lblBaht3.TabIndex = 198
      Me.lblBaht3.Text = "บาท"
      Me.lblBaht3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblTotal
      '
      Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotal.ForeColor = System.Drawing.Color.Black
      Me.lblTotal.Location = New System.Drawing.Point(413, 162)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(88, 18)
      Me.lblTotal.TabIndex = 200
      Me.lblTotal.Text = "ยอดเงินโอนคงเหลือ:"
      Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(19, 170)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(136, 18)
      Me.lblItem.TabIndex = 199
      Me.lblItem.Text = "บันทีกยอดตัดจ่ายเงินโอน"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(272, 24)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 2
      Me.chkAutorun.TabStop = False
      '
      'btnBankAccountFind
      '
      Me.btnBankAccountFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAccountFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankAccountFind.Location = New System.Drawing.Point(496, 78)
      Me.btnBankAccountFind.Name = "btnBankAccountFind"
      Me.btnBankAccountFind.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAccountFind.TabIndex = 21
      Me.btnBankAccountFind.TabStop = False
      Me.btnBankAccountFind.ThemedImage = CType(resources.GetObject("btnBankAccountFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnSupplierFind
      '
      Me.btnSupplierFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierFind.Location = New System.Drawing.Point(496, 51)
      Me.btnSupplierFind.Name = "btnSupplierFind"
      Me.btnSupplierFind.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierFind.TabIndex = 16
      Me.btnSupplierFind.TabStop = False
      Me.btnSupplierFind.ThemedImage = CType(resources.GetObject("btnSupplierFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtIssueDate
      '
      Me.Validator.SetDataType(Me.txtIssueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtIssueDate, "")
      Me.ErrorProvider1.SetError(Me.txtIssueDate, "กำหนดวันที่เอกสาร")
      Me.Validator.SetGotFocusBackColor(Me.txtIssueDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtIssueDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtIssueDate, System.Drawing.Color.Empty)
      Me.txtIssueDate.Location = New System.Drawing.Point(400, 24)
      Me.Validator.SetMinValue(Me.txtIssueDate, "")
      Me.txtIssueDate.Name = "txtIssueDate"
      Me.Validator.SetRegularExpression(Me.txtIssueDate, "")
      Me.Validator.SetRequired(Me.txtIssueDate, True)
      Me.txtIssueDate.Size = New System.Drawing.Size(123, 21)
      Me.txtIssueDate.TabIndex = 4
      '
      'txtSupplierCode
      '
      Me.txtSupplierCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
      Me.txtSupplierCode.Location = New System.Drawing.Point(144, 51)
      Me.Validator.SetMinValue(Me.txtSupplierCode, "")
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
      Me.Validator.SetRequired(Me.txtSupplierCode, False)
      Me.txtSupplierCode.Size = New System.Drawing.Size(128, 21)
      Me.txtSupplierCode.TabIndex = 14
      '
      'txtAmount
      '
      Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtAmount, "")
      Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAmount, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
      Me.txtAmount.Location = New System.Drawing.Point(144, 132)
      Me.Validator.SetMinValue(Me.txtAmount, "")
      Me.txtAmount.Name = "txtAmount"
      Me.Validator.SetRegularExpression(Me.txtAmount, "")
      Me.Validator.SetRequired(Me.txtAmount, True)
      Me.txtAmount.Size = New System.Drawing.Size(128, 21)
      Me.txtAmount.TabIndex = 26
      Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 25)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(128, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSupplierEdit
      '
      Me.btnSupplierEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierEdit.Location = New System.Drawing.Point(520, 51)
      Me.btnSupplierEdit.Name = "btnSupplierEdit"
      Me.btnSupplierEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierEdit.TabIndex = 17
      Me.btnSupplierEdit.TabStop = False
      Me.btnSupplierEdit.ThemedImage = CType(resources.GetObject("btnSupplierEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'dtpIssueDate
      '
      Me.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpIssueDate.Location = New System.Drawing.Point(400, 24)
      Me.dtpIssueDate.Name = "dtpIssueDate"
      Me.dtpIssueDate.Size = New System.Drawing.Size(144, 21)
      Me.dtpIssueDate.TabIndex = 5
      Me.dtpIssueDate.TabStop = False
      '
      'lblSupplier
      '
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.ForeColor = System.Drawing.Color.Black
      Me.lblSupplier.Location = New System.Drawing.Point(8, 51)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(128, 18)
      Me.lblSupplier.TabIndex = 13
      Me.lblSupplier.Text = "ผู้ขาย:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblIssueDate
      '
      Me.lblIssueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblIssueDate.ForeColor = System.Drawing.Color.Black
      Me.lblIssueDate.Location = New System.Drawing.Point(296, 25)
      Me.lblIssueDate.Name = "lblIssueDate"
      Me.lblIssueDate.Size = New System.Drawing.Size(96, 18)
      Me.lblIssueDate.TabIndex = 3
      Me.lblIssueDate.Text = "วันที่:"
      Me.lblIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBankAccount
      '
      Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
      Me.lblBankAccount.Location = New System.Drawing.Point(8, 78)
      Me.lblBankAccount.Name = "lblBankAccount"
      Me.lblBankAccount.Size = New System.Drawing.Size(128, 18)
      Me.lblBankAccount.TabIndex = 18
      Me.lblBankAccount.Text = "สมุดเงินฝากธนาคาร:"
      Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAmount
      '
      Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAmount.ForeColor = System.Drawing.Color.Black
      Me.lblAmount.Location = New System.Drawing.Point(8, 132)
      Me.lblAmount.Name = "lblAmount"
      Me.lblAmount.Size = New System.Drawing.Size(128, 18)
      Me.lblAmount.TabIndex = 25
      Me.lblAmount.Text = "จำนวนเงิน:"
      Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCurrency
      '
      Me.lblCurrency.AutoSize = True
      Me.lblCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrency.ForeColor = System.Drawing.Color.Black
      Me.lblCurrency.Location = New System.Drawing.Point(280, 132)
      Me.lblCurrency.Name = "lblCurrency"
      Me.lblCurrency.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrency.TabIndex = 27
      Me.lblCurrency.Text = "บาท"
      Me.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStatus
      '
      Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(8, 496)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(69, 13)
      Me.lblStatus.TabIndex = 32
      Me.lblStatus.Text = "Status กั๊บผม"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnBankAccountEdit
      '
      Me.btnBankAccountEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAccountEdit.Location = New System.Drawing.Point(520, 78)
      Me.btnBankAccountEdit.Name = "btnBankAccountEdit"
      Me.btnBankAccountEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAccountEdit.TabIndex = 22
      Me.btnBankAccountEdit.TabStop = False
      Me.btnBankAccountEdit.ThemedImage = CType(resources.GetObject("btnBankAccountEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblBank
      '
      Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBank.ForeColor = System.Drawing.Color.Black
      Me.lblBank.Location = New System.Drawing.Point(8, 105)
      Me.lblBank.Name = "lblBank"
      Me.lblBank.Size = New System.Drawing.Size(128, 18)
      Me.lblBank.TabIndex = 23
      Me.lblBank.Text = "ธนาคาร/สาขา:"
      Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtbankbranch
      '
      Me.Validator.SetDataType(Me.txtbankbranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtbankbranch, "")
      Me.txtbankbranch.Enabled = False
      Me.txtbankbranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtbankbranch, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtbankbranch, -15)
      Me.Validator.SetInvalidBackColor(Me.txtbankbranch, System.Drawing.Color.Empty)
      Me.txtbankbranch.Location = New System.Drawing.Point(144, 105)
      Me.Validator.SetMinValue(Me.txtbankbranch, "")
      Me.txtbankbranch.Name = "txtbankbranch"
      Me.txtbankbranch.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtbankbranch, "")
      Me.Validator.SetRequired(Me.txtbankbranch, False)
      Me.txtbankbranch.Size = New System.Drawing.Size(400, 21)
      Me.txtbankbranch.TabIndex = 24
      Me.txtbankbranch.TabStop = False
      '
      'txtBankAccountCode
      '
      Me.txtBankAccountCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtBankAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAccountCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAccountCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
      Me.txtBankAccountCode.Location = New System.Drawing.Point(144, 78)
      Me.Validator.SetMinValue(Me.txtBankAccountCode, "")
      Me.txtBankAccountCode.Name = "txtBankAccountCode"
      Me.Validator.SetRegularExpression(Me.txtBankAccountCode, "")
      Me.Validator.SetRequired(Me.txtBankAccountCode, True)
      Me.txtBankAccountCode.Size = New System.Drawing.Size(128, 21)
      Me.txtBankAccountCode.TabIndex = 19
      '
      'txtSupplierName
      '
      Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierName, "")
      Me.txtSupplierName.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
      Me.txtSupplierName.Location = New System.Drawing.Point(272, 51)
      Me.Validator.SetMinValue(Me.txtSupplierName, "")
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
      Me.Validator.SetRequired(Me.txtSupplierName, False)
      Me.txtSupplierName.Size = New System.Drawing.Size(224, 21)
      Me.txtSupplierName.TabIndex = 15
      Me.txtSupplierName.TabStop = False
      '
      'txtBankAccountName
      '
      Me.txtBankAccountName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBankAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBankAccountName, "")
      Me.txtBankAccountName.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBankAccountName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
      Me.txtBankAccountName.Location = New System.Drawing.Point(272, 78)
      Me.Validator.SetMinValue(Me.txtBankAccountName, "")
      Me.txtBankAccountName.Name = "txtBankAccountName"
      Me.txtBankAccountName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBankAccountName, "")
      Me.Validator.SetRequired(Me.txtBankAccountName, False)
      Me.txtBankAccountName.Size = New System.Drawing.Size(224, 21)
      Me.txtBankAccountName.TabIndex = 20
      Me.txtBankAccountName.TabStop = False
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.ErrorProvider1.SetError(Me.txtCode, "กำหนดเลขที่เอกสาร")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(144, 24)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(128, 21)
      Me.txtCode.TabIndex = 1
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'BankTransferOutDetailView
      '
      Me.Controls.Add(Me.grbBankTransferOut)
      Me.Name = "BankTransferOutDetailView"
      Me.Size = New System.Drawing.Size(709, 504)
      Me.grbBankTransferOut.ResumeLayout(False)
      Me.grbBankTransferOut.PerformLayout()
      CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not Me.m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferOutDetailView.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblIssueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferOutDetailView.lblIssueDate}")
      Me.Validator.SetDisplayName(txtIssueDate, lblIssueDate.Text)

      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferOutDetailView.lblSupplier}")
      Me.Validator.SetDisplayName(txtSupplierCode, lblSupplier.Text)

      Me.lblBankAccount.Text = Me.StringParserService.Parse("${res:Global.BankAccountText}")
      Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferOutDetailView.lblBank}")
      Me.Validator.SetDisplayName(txtBankAccountCode, lblBankAccount.Text)

      Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankTransferOutDetailView.lblAmount}")
      Me.Validator.SetDisplayName(txtAmount, lblAmount.Text)

      Me.lblCurrency.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
    End Sub
#End Region

#Region "Member"
    Private m_entity As New BankTransferOut
    Private m_isInitialized As Boolean = False
    Private m_tableInitialized2 As Boolean = False
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      Initialize()

      Me.SetLabelText()
      Me.UpdateEntityProperties()
      Me.EventWiring()
    End Sub
#End Region

#Region "Method"
    Private Sub SetBankBranch()
      Dim oldstatus As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      If m_entity.BankAccount Is Nothing _
      OrElse Not Me.m_entity.BankAccount.Originated Then
        txtbankbranch.Text = ""
      Else
        txtbankbranch.Text = Me.m_entity.BankAccount.BankBranch.Bank.Name & " : " & Me.m_entity.BankAccount.BankBranch.Name
      End If
      Me.m_isInitialized = oldstatus
    End Sub
#End Region
    Dim viewDef As ColumnGroupsViewDefinition
    Private Sub GetColumns(ByVal grid As RadGridView, ByVal istop As Boolean)

      viewDef = New ColumnGroupsViewDefinition
      Dim colNum As Integer = 0
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim gcLineNumber As New GridViewDecimalColumn("Linenumber")
      gcLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.LineNumberHeaderText}")
      gcLineNumber.Width = 45
      gcLineNumber.ReadOnly = True
      gcLineNumber.DecimalPlaces = 0
      gcLineNumber.TextAlignment = ContentAlignment.MiddleCenter
      grid.Columns.Add(gcLineNumber)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcLineNumber)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim colName As String
      If istop Then
        colName = "Selected"
      Else
        colName = "SelectedForDeleted"
      End If
      Dim gcSelected As New GridViewCheckBoxColumn(colName)
      gcSelected.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
      gcSelected.Width = 30
      gcSelected.ReadOnly = False
      gcSelected.AllowSort = False
      grid.Columns.Add(gcSelected)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcSelected)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim gcPaymentCode As New GridViewTextBoxColumn("PaymentCode")
      gcPaymentCode.HeaderText = "เลขที่ PV" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
      gcPaymentCode.Width = 100
      gcPaymentCode.ReadOnly = True
      grid.Columns.Add(gcPaymentCode)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcPaymentCode)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim gcRefCode As New GridViewTextBoxColumn("RefCode")
      gcRefCode.HeaderText = "เอกสารอ้างอิง" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      gcRefCode.Width = 100
      gcRefCode.ReadOnly = True
      grid.Columns.Add(gcRefCode)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefCode)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim gcRefType As New GridViewTextBoxColumn("RefType")
      gcRefType.HeaderText = "ประเภท" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      gcRefType.Width = 100
      gcRefType.ReadOnly = True
      grid.Columns.Add(gcRefType)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefType)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim gcRefDueDate As New GridViewTextBoxColumn("RefDueDate")
      gcRefDueDate.HeaderText = "วันที่ครบกำหนด" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      gcRefDueDate.Width = 100
      gcRefDueDate.ReadOnly = True
      grid.Columns.Add(gcRefDueDate)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefDueDate)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1

      Dim csRefAmount As New GridViewTextBoxColumn("RefAmount")
      csRefAmount.HeaderText = "จำนวนเงิน PV" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
      csRefAmount.ReadOnly = True
      csRefAmount.Width = 150
      csRefAmount.TextAlignment = ContentAlignment.MiddleRight
      csRefAmount.ReadOnly = True
      grid.Columns.Add(csRefAmount)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csRefAmount)
      viewDef.ColumnGroups(colNum).IsPinned = True

      Dim csRemain As New GridViewTextBoxColumn("Remain")
      csRemain.HeaderText = "คงเหลือ" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
      csRemain.ReadOnly = True
      csRemain.Width = 150
      csRemain.TextAlignment = ContentAlignment.MiddleRight
      csRemain.ReadOnly = True
      grid.Columns.Add(csRemain)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csRemain)
      viewDef.ColumnGroups(colNum).IsPinned = True

      Dim csAmount As New GridViewTextBoxColumn("Amount")
      csAmount.HeaderText = "จำนวนจ่ายโดยการโอนนี้" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.AmountHeaderText}")
      csAmount.Width = 150
      csAmount.TextAlignment = ContentAlignment.MiddleRight
      csAmount.ReadOnly = True
      grid.Columns.Add(csAmount)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csAmount)
      viewDef.ColumnGroups(colNum).IsPinned = True
      colNum += 1
    End Sub
    Private Sub RefreshSelectedItems()
      m_tableInitialized2 = False
      Me.RadGridView2.GridElement.BeginUpdate()
      Me.RadGridView2.Rows.Clear()
      For Each p As PaymentForList In m_entity.PaymentList
        Dim row As GridViewDataRowInfo = Me.RadGridView2.Rows.AddNew()
        PopulateRow(p, row)
      Next
      Dim i As Integer = 1
      For Each row As GridViewDataRowInfo In Me.RadGridView2.Rows
        row.Cells("Linenumber").Value = i
        i += 1
      Next
      Me.RadGridView2.GridElement.EndUpdate(True)
      m_tableInitialized2 = True
    End Sub

    Public Sub PopulateRow(ByVal p As PaymentForList, ByVal tr As GridViewDataRowInfo)
      If tr Is Nothing Then
        Return
      End If

      If tr.ViewTemplate.Columns.Contains("SelectedForDeleted") Then
        tr.Cells("SelectedForDeleted").Value = p.SelectedForDeleted
      End If
      If tr.ViewTemplate.Columns.Contains("Selected") Then
        tr.Cells("Selected").Value = p.Selected
      End If
      tr.Cells("PaymentCode").Value = p.Code
      tr.Cells("RefCode").Value = p.RefCode
      tr.Cells("RefType").Value = p.RefType
      tr.Cells("RefDueDate").Value = p.RefDueDate.ToShortDateString
      tr.Cells("RefAmount").Value = Configuration.FormatToString(p.RefAmount, DigitConfig.Price)
      Dim remain As Decimal = p.RefRemain
      If Not p.JustAdded Then
        remain += p.Amount
      End If
      tr.Cells("Remain").Value = Configuration.FormatToString(remain, DigitConfig.Price)
      tr.Cells("Amount").Value = Configuration.FormatToString(p.Amount, DigitConfig.Price)

      tr.Tag = p

    End Sub

#Region "ISimpleEntityPanel"
    Public Overrides Sub Initialize()
      Me.RadGridView2.MasterGridViewTemplate.AllowAddNewRow = False
      Me.RadGridView2.MasterGridViewTemplate.AllowDragToGroup = False
      Me.RadGridView2.ShowGroupPanel = False
      GetColumns(RadGridView2, False)
    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtIssueDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpIssueDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtBankAccountCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAmount.Validated, AddressOf Me.NumberTextBoxChange

      AddHandler cmbExportType.SelectedIndexChanged, AddressOf Me.ChangeProperty

    End Sub
    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
          OrElse Me.m_entity.Status.Value >= 3 Then   '{-1 ยังไม่บันทึก, 0 ยกเลิก  , 1 ในมือ  , 2 เช็คผ่าน }
        For Each ctrl As Control In grbBankTransferOut.Controls
          If TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is Button Then
            'MessageBox.Show(Me.m_entity.Supplier.Id)
            If ctrl.Name = "txtrecipient" And Me.m_entity.Supplier.invisible = True Then   'เช็คว่าเป็นเงินสดย่อยถึงให้เปลี่ยนชื่อคนรับได้ 
              'MessageBox.Show(ctrl.Name & " isTrue")
            Else
              ctrl.Enabled = False
              'MessageBox.Show(ctrl.Name & " isFalse")
            End If
          End If
        Next
        dtpIssueDate.Enabled = False
        txtBankAccountCode.Enabled = False
        btnBankAccountFind.Enabled = False
        btnBankAccountEdit.Enabled = False
        'If m_entity.Status.Value = 3 AndAlso m_entity.DocStatus.Value <> 2 Then 'ยังไม่ผ่าน
        '  txtNote.Enabled = True
        '  If CBool(Configuration.GetConfig("CanEditBankTransferOutRecipient")) Then
        '    txtrecipient.Enabled = True
        '  End If
        'End If
      Else
        For Each ctrl As Control In grbBankTransferOut.Controls
          If TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is Button Then
            ctrl.Enabled = True
          End If
        Next
        dtpIssueDate.Enabled = True
        txtBankAccountCode.Enabled = True
        btnBankAccountFind.Enabled = True
        btnBankAccountEdit.Enabled = True
      End If
      Me.ibtnBlank.Enabled = True
      Me.ibtnDelRow.Enabled = True
      Me.btnExport.Enabled = True
    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      For Each ctrl As Control In grbBankTransferOut.Controls
        If TypeOf ctrl Is TextBox Then
          ctrl.Text = ""
        End If
      Next

      txtIssueDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      dtpIssueDate.Value = Date.Now

      cmbExportType.SelectedIndex = 0
      cmbExportType.SelectedIndex = 0
    End Sub

    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()

      If m_entity Is Nothing Then
        Return
      End If

      ' ทำการผูก Property ต่าง ๆ เข้ากับ control
      With Me
        .txtCode.Text = .m_entity.Code
        ' autogencode 
        m_oldCode = m_entity.Code
        Me.chkAutorun.Checked = Me.m_entity.AutoGen
        Me.UpdateAutogenStatus()

        dtpIssueDate.Value = MinDateToNow(Me.m_entity.DocDate)
        txtIssueDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))


        cmbExportType.Text = m_entity.ExportType.ToUpper

        txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)

        'txtNote.Text = .m_entity.Note

        If Not .m_entity.Supplier Is Nothing Then
          txtSupplierCode.Text = .m_entity.Supplier.Code
          txtSupplierName.Text = .m_entity.Supplier.Name
        End If

        If Not .m_entity.BankAccount Is Nothing Then
          txtBankAccountCode.Text = .m_entity.BankAccount.Code
          txtBankAccountName.Text = .m_entity.BankAccount.Name
          SetBankBranch()
        End If
        
      End With

      Me.RefreshSelectedItems()

      UpdateAmount()

      SetStatus()
      CheckFormEnable()
      SetLabelText()

      m_isInitialized = True
    End Sub
    Private Sub SetStatus()
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

    Public Sub NumberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtamount"
          txtAmount.Text = Configuration.FormatToString(Me.m_entity.Amount, DigitConfig.Price)
      End Select
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbexporttype"
          Me.m_entity.ExportType = Me.cmbExportType.Text.ToUpper
          dirtyFlag = True
        Case "txtcode"
          Me.m_entity.Code = Me.txtCode.Text
          dirtyFlag = True
        Case "dtpissuedate"
          txtIssueDate.Text = MinDateToNull(dtpIssueDate.Value, "")
          Me.m_entity.DocDate = Me.dtpIssueDate.Value
          dirtyFlag = True

        Case "txtissuedate"
          Dim dt As DateTime = StringToDate(txtIssueDate, dtpIssueDate)
          Me.m_entity.DocDate = dt
          dirtyFlag = True

        Case "txtamount"
          If txtAmount.TextLength > 0 Then
            Me.m_entity.Amount = CDec(Me.txtAmount.Text)
          Else
            Me.m_entity.Amount = Nothing
          End If
          'UpdateAmount()
          dirtyFlag = True

          'Case "txtnote"
          '  Me.m_entity.Note = Me.txtNote.Text
          '  dirtyFlag = True

        Case "txtbankaccountcode"
          dirtyFlag = BankAccount.GetBankAccount(txtBankAccountCode, txtBankAccountName, Me.m_entity.BankAccount)
          SetBankBranch()

        Case "txtsuppliercode"
          dirtyFlag = Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      SetStatus()
      'CheckFormEnable()

    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, BankTransferOut)
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
        EventWiring()
      End Set
    End Property

#End Region

#Region "IReversibleEntityProperty"
    Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties

    End Sub

    Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties

    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercode", "txtsuppliername"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New BankAccount).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtbankaccountcode", "txtbankaccountname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtsuppliercode", "txtsuppliername"
              Me.SetSupplierDialog(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New BankAccount).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New BankAccount).FullClassName))
        Dim entity As New BankAccount(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtbankaccountcode", "txtbankaccountname"
              Me.SetBankAccountDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Autogencode"
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

#Region " Event of Button controls "
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    End Sub

    Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty Or _
          Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
      Dim tmp As Boolean = m_isInitialized
    End Sub

    Private Sub btnBankAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAccountFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountDialog)
    End Sub

    Private Sub SetBankAccountDialog(ByVal e As ISimpleEntity)
      Me.txtBankAccountCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty Or _
          BankAccount.GetBankAccount(txtBankAccountCode, txtBankAccountName, Me.m_entity.BankAccount)
      SetBankBranch()
    End Sub

    Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub

    Private Sub btnBankAccountEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAccountEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New BankAccount)
    End Sub
#End Region

    Private Sub UpdateAmount()
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      txtTotal.Text = Configuration.FormatToString(m_entity.GetRemain, DigitConfig.Price)
      txtAmount.Text = Configuration.FormatToString(m_entity.Amount, DigitConfig.Price)
      m_isInitialized = flag
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim f As New PaymentList
      f.SetSupplier(Me.m_entity.Supplier)
      f.SetType(22)
      If f.ShowDialog() = DialogResult.OK Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        Dim list As List(Of PaymentForList) = f.Selected
        If Not list Is Nothing Then
          Dim originalSum As Decimal = m_entity.GetSum
          For Each p As PaymentForList In list
            If Not m_entity.PaymentList.Contains(p) Then
              p.Amount = p.RefRemain
              p.JustAdded = True
              originalSum += p.Amount
              If m_entity.Amount < originalSum Then
                If MessageBox.Show("ยอดเกินจำนวนเงินโอน ท่านต้องการปรับยอดเงินหรือไม่?", "ยอดเกิน", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                  m_entity.Amount = originalSum
                Else
                  Exit For
                End If
              End If
              m_entity.PaymentList.Add(p)
            End If
          Next
        End If
      End If
      RefreshSelectedItems()
      UpdateAmount()
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim deleted As New List(Of PaymentForList)
      For Each p As PaymentForList In m_entity.PaymentList
        If p.SelectedForDeleted Then
          deleted.Add(p)
        End If
      Next
      For Each p As PaymentForList In deleted
        p.SelectedForDeleted = False
        If p.JustAdded Then
          m_entity.PaymentList.Remove(p)
        End If
      Next
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      RefreshSelectedItems()
      UpdateAmount()
    End Sub
    Private m_updating2 As Boolean = False
    Private Sub RadGridView2_CellValidating(ByVal sender As Object, ByVal e As CellValidatingEventArgs) Handles RadGridView2.CellValidating
      Dim column As GridViewDataColumn = TryCast(e.Column, GridViewDataColumn)
      If e.Row Is Nothing Then
        Return
      End If
      If Not TypeOf e.Row Is GridViewDataRowInfo OrElse column Is Nothing Then
        Return
      End If
      If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
        Return
      End If
      If Not Me.m_tableInitialized2 Then
        Return
      End If
      Dim p As PaymentForList = CType(e.Row.Tag, PaymentForList)
      If m_updating2 Then
        Return
      End If
      m_updating2 = True
      If Not e.Value Is Nothing Then
        Select Case column.FieldName.ToLower
          Case "selectedfordeleted"
            p.SelectedForDeleted = e.Value
          Case Else
        End Select
      End If
      m_updating2 = False
    End Sub
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
      Dim myOpb As New SaveFileDialog
      myOpb.Filter = "All Files|*.*"
      myOpb.FilterIndex = 1
      myOpb.FileName = m_entity.ExportType.ToUpper & ".txt"
      If myOpb.ShowDialog() = DialogResult.OK Then
        Dim fileName As String = Path.GetDirectoryName(myOpb.FileName) & Path.DirectorySeparatorChar & Path.GetFileName(myOpb.FileName)
        Dim writer As New IO.StreamWriter(fileName, False, System.Text.Encoding.GetEncoding(874))
        Try
          'Exporter.Export(m_entity, writer)
          MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportBankTransferOutDetail.ExportCompleted}"))
        Catch ex As Exception
          MessageBox.Show("Error:" & ex.ToString)
        Finally
          writer.Close()
        End Try
      End If
    End Sub
  End Class

End Namespace
