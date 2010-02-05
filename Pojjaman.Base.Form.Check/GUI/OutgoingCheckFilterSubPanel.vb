Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class OutgoingCheckFilterSubPanel
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
    Friend WithEvents txtCqcode As System.Windows.Forms.TextBox
    Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSupplierFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAcctName As System.Windows.Forms.TextBox
    Friend WithEvents btnBankAcctEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblBankAcct As System.Windows.Forms.Label
    Friend WithEvents btnBankAcctFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBankAcctCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblRecipient As System.Windows.Forms.Label
    Friend WithEvents txtRepient As System.Windows.Forms.TextBox
    Friend WithEvents lblCqcode As System.Windows.Forms.Label
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents grbDueDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblDueDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDueDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDueDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCheckStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OutgoingCheckFilterSubPanel))
      Me.lblCqcode = New System.Windows.Forms.Label()
      Me.txtCqcode = New System.Windows.Forms.TextBox()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.txtSupplierCode = New System.Windows.Forms.TextBox()
      Me.lblCheckStatus = New System.Windows.Forms.Label()
      Me.lblRecipient = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnSupplierEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnSupplierFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.txtSupplierName = New System.Windows.Forms.TextBox()
      Me.txtBankAcctName = New System.Windows.Forms.TextBox()
      Me.btnBankAcctEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblBankAcct = New System.Windows.Forms.Label()
      Me.btnBankAcctFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBankAcctCode = New System.Windows.Forms.TextBox()
      Me.txtRepient = New System.Windows.Forms.TextBox()
      Me.grbDueDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblDueDateStart = New System.Windows.Forms.Label()
      Me.lblDueDateEnd = New System.Windows.Forms.Label()
      Me.dtpDueDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDueDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbDueDate.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCqcode
      '
      Me.lblCqcode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCqcode.ForeColor = System.Drawing.Color.Black
      Me.lblCqcode.Location = New System.Drawing.Point(8, 49)
      Me.lblCqcode.Name = "lblCqcode"
      Me.lblCqcode.Size = New System.Drawing.Size(104, 18)
      Me.lblCqcode.TabIndex = 2
      Me.lblCqcode.Text = "เลขที่เช็ค:"
      Me.lblCqcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCqcode
      '
      Me.txtCqcode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtCqcode.Location = New System.Drawing.Point(120, 48)
      Me.txtCqcode.Name = "txtCqcode"
      Me.txtCqcode.Size = New System.Drawing.Size(248, 21)
      Me.txtCqcode.TabIndex = 3
      '
      'lblSupplier
      '
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.ForeColor = System.Drawing.Color.Black
      Me.lblSupplier.Location = New System.Drawing.Point(16, 120)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(96, 18)
      Me.lblSupplier.TabIndex = 8
      Me.lblSupplier.Text = "Supplier:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierCode
      '
      Me.txtSupplierCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtSupplierCode.Location = New System.Drawing.Point(120, 120)
      Me.txtSupplierCode.Name = "txtSupplierCode"
      Me.txtSupplierCode.Size = New System.Drawing.Size(88, 21)
      Me.txtSupplierCode.TabIndex = 9
      '
      'lblCheckStatus
      '
      Me.lblCheckStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCheckStatus.ForeColor = System.Drawing.Color.Black
      Me.lblCheckStatus.Location = New System.Drawing.Point(8, 96)
      Me.lblCheckStatus.Name = "lblCheckStatus"
      Me.lblCheckStatus.Size = New System.Drawing.Size(104, 18)
      Me.lblCheckStatus.TabIndex = 6
      Me.lblCheckStatus.Text = "สถานะเช็คจ่าย:"
      Me.lblCheckStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRecipient
      '
      Me.lblRecipient.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRecipient.ForeColor = System.Drawing.Color.Black
      Me.lblRecipient.Location = New System.Drawing.Point(16, 72)
      Me.lblRecipient.Name = "lblRecipient"
      Me.lblRecipient.Size = New System.Drawing.Size(96, 18)
      Me.lblRecipient.TabIndex = 4
      Me.lblRecipient.Text = "ผู้รับเช็ค:"
      Me.lblRecipient.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 25)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtCode.Location = New System.Drawing.Point(120, 24)
      Me.txtCode.Name = "txtCode"
      Me.txtCode.Size = New System.Drawing.Size(248, 21)
      Me.txtCode.TabIndex = 1
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbDueDate)
      Me.grbDetail.Controls.Add(Me.cmbStatus)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSupplierEdit)
      Me.grbDetail.Controls.Add(Me.btnSupplierFind)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.txtSupplierCode)
      Me.grbDetail.Controls.Add(Me.txtCqcode)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblCqcode)
      Me.grbDetail.Controls.Add(Me.lblSupplier)
      Me.grbDetail.Controls.Add(Me.lblRecipient)
      Me.grbDetail.Controls.Add(Me.lblCheckStatus)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.txtSupplierName)
      Me.grbDetail.Controls.Add(Me.txtBankAcctName)
      Me.grbDetail.Controls.Add(Me.btnBankAcctEdit)
      Me.grbDetail.Controls.Add(Me.lblBankAcct)
      Me.grbDetail.Controls.Add(Me.btnBankAcctFind)
      Me.grbDetail.Controls.Add(Me.txtBankAcctCode)
      Me.grbDetail.Controls.Add(Me.txtRepient)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(683, 184)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "เช็คจ่าย"
      '
      'cmbStatus
      '
      Me.cmbStatus.Location = New System.Drawing.Point(120, 96)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(176, 21)
      Me.cmbStatus.TabIndex = 7
      '
      'grbDocDate
      '
      Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocDate.Location = New System.Drawing.Point(442, 10)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(228, 68)
      Me.grbDocDate.TabIndex = 18
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "วันที่เอกสาร"
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(12, 17)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(12, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(56, 18)
      Me.lblDocDateEnd.TabIndex = 2
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(74, 17)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDateStart.TabIndex = 1
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(74, 41)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(144, 21)
      Me.dtpDocDateEnd.TabIndex = 3
      '
      'btnSupplierEdit
      '
      Me.btnSupplierEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierEdit.Location = New System.Drawing.Point(400, 120)
      Me.btnSupplierEdit.Name = "btnSupplierEdit"
      Me.btnSupplierEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierEdit.TabIndex = 12
      Me.btnSupplierEdit.TabStop = False
      Me.btnSupplierEdit.ThemedImage = CType(resources.GetObject("btnSupplierEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnSupplierFind
      '
      Me.btnSupplierFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSupplierFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSupplierFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSupplierFind.Location = New System.Drawing.Point(376, 120)
      Me.btnSupplierFind.Name = "btnSupplierFind"
      Me.btnSupplierFind.Size = New System.Drawing.Size(24, 23)
      Me.btnSupplierFind.TabIndex = 11
      Me.btnSupplierFind.TabStop = False
      Me.btnSupplierFind.ThemedImage = CType(resources.GetObject("btnSupplierFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(591, 155)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 20
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(513, 154)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 19
      Me.btnReset.Text = "เคลียร์"
      '
      'txtSupplierName
      '
      Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
      Me.txtSupplierName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtSupplierName.Location = New System.Drawing.Point(208, 120)
      Me.txtSupplierName.Name = "txtSupplierName"
      Me.txtSupplierName.ReadOnly = True
      Me.txtSupplierName.Size = New System.Drawing.Size(168, 21)
      Me.txtSupplierName.TabIndex = 10
      '
      'txtBankAcctName
      '
      Me.txtBankAcctName.BackColor = System.Drawing.SystemColors.Control
      Me.txtBankAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBankAcctName.Location = New System.Drawing.Point(208, 144)
      Me.txtBankAcctName.Name = "txtBankAcctName"
      Me.txtBankAcctName.ReadOnly = True
      Me.txtBankAcctName.Size = New System.Drawing.Size(168, 21)
      Me.txtBankAcctName.TabIndex = 15
      '
      'btnBankAcctEdit
      '
      Me.btnBankAcctEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAcctEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAcctEdit.Location = New System.Drawing.Point(400, 144)
      Me.btnBankAcctEdit.Name = "btnBankAcctEdit"
      Me.btnBankAcctEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAcctEdit.TabIndex = 17
      Me.btnBankAcctEdit.TabStop = False
      Me.btnBankAcctEdit.ThemedImage = CType(resources.GetObject("btnBankAcctEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblBankAcct
      '
      Me.lblBankAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBankAcct.ForeColor = System.Drawing.Color.Black
      Me.lblBankAcct.Location = New System.Drawing.Point(8, 144)
      Me.lblBankAcct.Name = "lblBankAcct"
      Me.lblBankAcct.Size = New System.Drawing.Size(104, 18)
      Me.lblBankAcct.TabIndex = 13
      Me.lblBankAcct.Text = "สมุดบัญชี:"
      Me.lblBankAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnBankAcctFind
      '
      Me.btnBankAcctFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBankAcctFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBankAcctFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBankAcctFind.Location = New System.Drawing.Point(376, 144)
      Me.btnBankAcctFind.Name = "btnBankAcctFind"
      Me.btnBankAcctFind.Size = New System.Drawing.Size(24, 23)
      Me.btnBankAcctFind.TabIndex = 16
      Me.btnBankAcctFind.TabStop = False
      Me.btnBankAcctFind.ThemedImage = CType(resources.GetObject("btnBankAcctFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBankAcctCode
      '
      Me.txtBankAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBankAcctCode.Location = New System.Drawing.Point(120, 144)
      Me.txtBankAcctCode.Name = "txtBankAcctCode"
      Me.txtBankAcctCode.Size = New System.Drawing.Size(88, 21)
      Me.txtBankAcctCode.TabIndex = 14
      '
      'txtRepient
      '
      Me.txtRepient.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtRepient.Location = New System.Drawing.Point(120, 72)
      Me.txtRepient.Name = "txtRepient"
      Me.txtRepient.Size = New System.Drawing.Size(248, 21)
      Me.txtRepient.TabIndex = 5
      '
      'grbDueDate
      '
      Me.grbDueDate.Controls.Add(Me.lblDueDateStart)
      Me.grbDueDate.Controls.Add(Me.lblDueDateEnd)
      Me.grbDueDate.Controls.Add(Me.dtpDueDateStart)
      Me.grbDueDate.Controls.Add(Me.dtpDueDateEnd)
      Me.grbDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDueDate.Location = New System.Drawing.Point(442, 84)
      Me.grbDueDate.Name = "grbDueDate"
      Me.grbDueDate.Size = New System.Drawing.Size(228, 68)
      Me.grbDueDate.TabIndex = 19
      Me.grbDueDate.TabStop = False
      Me.grbDueDate.Text = "วันที่ครบกำหนด"
      '
      'lblDueDateStart
      '
      Me.lblDueDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDueDateStart.Location = New System.Drawing.Point(12, 17)
      Me.lblDueDateStart.Name = "lblDueDateStart"
      Me.lblDueDateStart.Size = New System.Drawing.Size(56, 18)
      Me.lblDueDateStart.TabIndex = 0
      Me.lblDueDateStart.Text = "ตั้งแต่"
      Me.lblDueDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDueDateEnd
      '
      Me.lblDueDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDueDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDueDateEnd.Location = New System.Drawing.Point(12, 41)
      Me.lblDueDateEnd.Name = "lblDueDateEnd"
      Me.lblDueDateEnd.Size = New System.Drawing.Size(56, 18)
      Me.lblDueDateEnd.TabIndex = 2
      Me.lblDueDateEnd.Text = "ถึง"
      Me.lblDueDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDueDateStart
      '
      Me.dtpDueDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDateStart.Location = New System.Drawing.Point(74, 17)
      Me.dtpDueDateStart.Name = "dtpDueDateStart"
      Me.dtpDueDateStart.Size = New System.Drawing.Size(144, 21)
      Me.dtpDueDateStart.TabIndex = 1
      '
      'dtpDueDateEnd
      '
      Me.dtpDueDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDateEnd.Location = New System.Drawing.Point(74, 41)
      Me.dtpDueDateEnd.Name = "dtpDueDateEnd"
      Me.dtpDueDateEnd.Size = New System.Drawing.Size(144, 21)
      Me.dtpDueDateEnd.TabIndex = 3
      '
      'OutgoingCheckFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "OutgoingCheckFilterSubPanel"
      Me.Size = New System.Drawing.Size(698, 200)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDueDate.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_supplier As New Supplier
    Private m_bankacct As New BankAccount
    Private m_checkstatus As OutgoingCheckDocStatus

    Private m_includeref As Boolean = True
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()
      Initialize()

      SetLabelText()
      LoopControl(Me)

    End Sub
#End Region

#Region "Properties"
    Private Property Supplier() As Supplier
      Get
        Return m_supplier
      End Get
      Set(ByVal Value As Supplier)
        m_supplier = Value
      End Set
    End Property
    Private Property BankAccount() As BankAccount
      Get
        Return m_bankacct
      End Get
      Set(ByVal Value As BankAccount)
        m_bankacct = Value
      End Set
    End Property
    Private Property CheckStatus() As CodeDescription
      Get
        Return m_checkstatus
      End Get
      Set(ByVal Value As CodeDescription)
        m_checkstatus = CType(Value, OutgoingCheckDocStatus)
      End Set
    End Property
#End Region

#Region "Methods"
    Private Sub Initialize()
      ' list in combobox
      OutgoingCheckDocStatus.ListCodeDescriptionInComboBox(cmbStatus, "outgoingcheck_docstatus")
      ' clear item
      ClearCriterias()
    End Sub

    Private Sub ClearCriterias()
      For Each ctrl As Control In grbDetail.Controls
        If TypeOf ctrl Is TextBox Then
          ctrl.Text = ""
        End If
      Next

      Me.Supplier = New Supplier
      Me.BankAccount = New BankAccount

      Me.cmbStatus.SelectedIndex = -1
      Me.cmbStatus.SelectedIndex = -1

      Me.dtpDocDateStart.Value = Date.Now.Subtract(New TimeSpan(30, 0, 0, 0))
      Me.dtpDocDateEnd.Value = Date.Now
      Me.dtpDueDateStart.Value = Date.Now.Subtract(New TimeSpan(30, 0, 0, 0))
      Me.dtpDueDateEnd.Value = Date.Now
      EntityRefresh()
    End Sub

    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(9) As Filter
      arr(0) = New Filter("code", IIf(txtCode.TextLength = 0, DBNull.Value, txtCode.Text))
      arr(1) = New Filter("cqcode", IIf(txtCqcode.Text.Length = 0, DBNull.Value, txtCqcode.Text))
      arr(2) = New Filter("recipient", IIf(txtRepient.TextLength = 0, DBNull.Value, txtRepient.Text))
      arr(3) = New Filter("supplier", IIf(Me.Supplier.Originated, Me.Supplier.Id, DBNull.Value))
      arr(4) = New Filter("bankaccount", IIf(Me.BankAccount.Originated, Me.BankAccount.Id, DBNull.Value))
      Dim docstatus As Integer
      If TypeOf cmbStatus.SelectedItem Is IdValuePair Then
        docstatus = CType(cmbStatus.SelectedItem, IdValuePair).Id
      End If
      arr(5) = New Filter("status", IIf(Me.cmbStatus.SelectedIndex = -1, DBNull.Value, docstatus))
      arr(6) = New Filter("startdate ", dtpDocDateStart.Value)
      arr(7) = New Filter("enddate", dtpDocDateEnd.Value)
      arr(8) = New Filter("duedatestart", dtpDueDateStart.Value)
      arr(9) = New Filter("duedateend", dtpDueDateEnd.Value)

      Return arr
    End Function

    Public Property IncludeRef() As Boolean
      Get
        Return m_includeref
      End Get
      Set(ByVal Value As Boolean)
        m_includeref = Value
      End Set
    End Property

    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
    ' supplier
    Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New supplier)
    End Sub
    Private Sub txtSupplierCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Validated
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.Supplier)
    End Sub
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    End Sub
    Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.Supplier)
    End Sub
    ' BankAccount
    Private Sub txtBankAcctCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBankAcctCode.Validated
      BankAccount.GetBankAccount(txtBankAcctCode, txtBankAcctName, Me.BankAccount)
    End Sub
    Private Sub btnBankAcctEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAcctEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New BankAccount)
    End Sub
    Private Sub btnBankAcctFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAcctFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccounDialog)
    End Sub
    Private Sub SetBankAccounDialog(ByVal e As ISimpleEntity)
      Me.txtBankAcctCode.Text = e.Code
      BankAccount.GetBankAccount(txtBankAcctCode, txtBankAcctName, Me.BankAccount)
    End Sub

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
              Case "txtbankacctcode", "txtbankacctname"
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
            Case "txtbankacctcode", "txtbankacctname"
              Me.SetBankAccounDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblDocDateEnd}")
      Me.lblBankAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblBankAcct}")
      Me.lblRecipient.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblRecipient}")
      Me.lblCqcode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblCqcode}")
      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Global.SupplierText}")
      Me.lblCheckStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblCheckStatus}")
      Me.grbDueDate.Text = Me.StringParserService.Parse("${res:Global.DueDateText}")
      Me.lblDueDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblDocDateStart}")
      Me.lblDueDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckFilterSubPanel.lblDocDateEnd}")
    End Sub
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
      If Entities Is Nothing Then
        Return
      End If
      For Each entity As ISimpleEntity In Entities

        If TypeOf entity Is OutgoingCheck Then
          ' set me.Includeref
          Me.IncludeRef = False

          Dim obj As OutgoingCheck = CType(entity, OutgoingCheck)
          If Not obj.DocStatus Is Nothing Then
            For Each item As IdValuePair In cmbStatus.Items
              If item.Id = obj.DocStatus.Value Then
                Me.cmbStatus.SelectedItem = item
              End If
            Next
            'Me.cmbStatus.SelectedIndex = obj.DocStatus.Value
            Me.cmbStatus.Enabled = False
          End If

          ' recieve person
          If obj.Supplier.Originated Then
            Me.SetSupplierDialog(obj.Supplier)
            Me.txtSupplierCode.Enabled = False
            Me.txtSupplierName.Enabled = False
            Me.btnSupplierEdit.Enabled = False
            Me.btnSupplierFind.Enabled = False
          End If
          ' customer 
          If obj.Bankacct.Originated Then
            Me.SetBankAccounDialog(obj.Bankacct)
            Me.txtBankAcctCode.Enabled = False
            Me.txtBankAcctName.Enabled = False
            Me.btnBankAcctEdit.Enabled = False
            Me.btnBankAcctFind.Enabled = False
          End If
        End If
        If TypeOf entity Is Supplier Then
          Me.SetSupplierDialog(CType(entity, Supplier))
          Me.txtSupplierCode.Enabled = False
          Me.txtSupplierName.Enabled = False
          Me.btnSupplierEdit.Enabled = False
          Me.btnSupplierFind.Enabled = False
        End If

      Next
    End Sub
  End Class
End Namespace

