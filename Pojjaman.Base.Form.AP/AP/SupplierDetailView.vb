Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.Services
Imports System.Text.RegularExpressions

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class SupplierDetailView
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
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents btnAuxDetail As System.Windows.Forms.Button
        Friend WithEvents primaryDetailGroupBox As FixedGroupBox
        Friend WithEvents txtEmail As System.Windows.Forms.TextBox
        Friend WithEvents lblEmail As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblAltName As System.Windows.Forms.Label
        Friend WithEvents txtBillingAddress As System.Windows.Forms.TextBox
        Friend WithEvents lblBillingAddress As System.Windows.Forms.Label
        Friend WithEvents txtAltName As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress As System.Windows.Forms.TextBox
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents txtFax As System.Windows.Forms.TextBox
        Friend WithEvents lblFax As System.Windows.Forms.Label
        Friend WithEvents otherDetailGroupBox As FixedGroupBox
        Friend WithEvents rdJuris As System.Windows.Forms.RadioButton
        Friend WithEvents txtAuthorizeAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblAuthorizeAmount As System.Windows.Forms.Label
        Friend WithEvents txtTaxID As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxID As System.Windows.Forms.Label
        Friend WithEvents lblPersonType As System.Windows.Forms.Label
        Friend WithEvents rdIndividual As System.Windows.Forms.RadioButton
        Friend WithEvents lblAccount As System.Windows.Forms.Label
        Friend WithEvents grbDetail As FixedGroupBox
        Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
        Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents txtContact As System.Windows.Forms.TextBox
        Friend WithEvents lblContact As System.Windows.Forms.Label
        Friend WithEvents chkcancel As System.Windows.Forms.CheckBox
        Friend WithEvents lblIdNo As System.Windows.Forms.Label
        Friend WithEvents txtIdNo As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents btnGroupEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
        Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
        Friend WithEvents cbmProvince As System.Windows.Forms.ComboBox
        Friend WithEvents lblProvince As System.Windows.Forms.Label
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtMobile As System.Windows.Forms.TextBox
        Friend WithEvents lblMobile As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents tgContact As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ibtnAddContact As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelContact As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblContactItem As System.Windows.Forms.Label
        Friend WithEvents btnLock As System.Windows.Forms.Button
        Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtMCAccount As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtDCBank As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtDCACcount As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtMCBank As System.Windows.Forms.TextBox
        Friend WithEvents txtFaxforExport As System.Windows.Forms.TextBox
        Friend WithEvents lblFaxforExport As System.Windows.Forms.Label
        Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SupplierDetailView))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.txtMCAccount = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtDCBank = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtDCACcount = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtMCBank = New System.Windows.Forms.TextBox()
            Me.btnLock = New System.Windows.Forms.Button()
            Me.tgContact = New Longkong.Pojjaman.Gui.Components.TreeGrid()
            Me.ibtnAddContact = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnDelContact = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblContactItem = New System.Windows.Forms.Label()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.btnAuxDetail = New System.Windows.Forms.Button()
            Me.primaryDetailGroupBox = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.cmbCode = New System.Windows.Forms.ComboBox()
            Me.chkAutorun = New System.Windows.Forms.CheckBox()
            Me.cbmProvince = New System.Windows.Forms.ComboBox()
            Me.chkcancel = New System.Windows.Forms.CheckBox()
            Me.txtEmail = New System.Windows.Forms.TextBox()
            Me.lblEmail = New System.Windows.Forms.Label()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.lblName = New System.Windows.Forms.Label()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.lblAltName = New System.Windows.Forms.Label()
            Me.txtBillingAddress = New System.Windows.Forms.TextBox()
            Me.lblBillingAddress = New System.Windows.Forms.Label()
            Me.txtAltName = New System.Windows.Forms.TextBox()
            Me.txtAddress = New System.Windows.Forms.TextBox()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.txtPhone = New System.Windows.Forms.TextBox()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.txtFax = New System.Windows.Forms.TextBox()
            Me.lblFax = New System.Windows.Forms.Label()
            Me.lblProvince = New System.Windows.Forms.Label()
            Me.txtMobile = New System.Windows.Forms.TextBox()
            Me.lblMobile = New System.Windows.Forms.Label()
            Me.otherDetailGroupBox = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnGroupEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtContact = New System.Windows.Forms.TextBox()
            Me.lblContact = New System.Windows.Forms.Label()
            Me.rdJuris = New System.Windows.Forms.RadioButton()
            Me.txtAuthorizeAmount = New System.Windows.Forms.TextBox()
            Me.lblAuthorizeAmount = New System.Windows.Forms.Label()
            Me.txtTaxID = New System.Windows.Forms.TextBox()
            Me.lblTaxID = New System.Windows.Forms.Label()
            Me.lblPersonType = New System.Windows.Forms.Label()
            Me.rdIndividual = New System.Windows.Forms.RadioButton()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.lblAccount = New System.Windows.Forms.Label()
            Me.txtAccountName = New System.Windows.Forms.TextBox()
            Me.txtGroupName = New System.Windows.Forms.TextBox()
            Me.lblIdNo = New System.Windows.Forms.Label()
            Me.txtIdNo = New System.Windows.Forms.TextBox()
            Me.txtGroupCode = New System.Windows.Forms.TextBox()
            Me.txtAccountCode = New System.Windows.Forms.TextBox()
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtFaxforExport = New System.Windows.Forms.TextBox()
            Me.lblFaxforExport = New System.Windows.Forms.Label()
            Me.grbDetail.SuspendLayout()
            Me.FixedGroupBox1.SuspendLayout()
            CType(Me.tgContact, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.primaryDetailGroupBox.SuspendLayout()
            Me.otherDetailGroupBox.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.FixedGroupBox1)
            Me.grbDetail.Controls.Add(Me.btnLock)
            Me.grbDetail.Controls.Add(Me.tgContact)
            Me.grbDetail.Controls.Add(Me.ibtnAddContact)
            Me.grbDetail.Controls.Add(Me.ibtnDelContact)
            Me.grbDetail.Controls.Add(Me.lblContactItem)
            Me.grbDetail.Controls.Add(Me.lblStatus)
            Me.grbDetail.Controls.Add(Me.btnAuxDetail)
            Me.grbDetail.Controls.Add(Me.primaryDetailGroupBox)
            Me.grbDetail.Controls.Add(Me.otherDetailGroupBox)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.ForeColor = System.Drawing.Color.Blue
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(974, 480)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียด Supplier : "
            '
            'FixedGroupBox1
            '
            Me.FixedGroupBox1.Controls.Add(Me.txtMCAccount)
            Me.FixedGroupBox1.Controls.Add(Me.Label1)
            Me.FixedGroupBox1.Controls.Add(Me.txtDCBank)
            Me.FixedGroupBox1.Controls.Add(Me.Label2)
            Me.FixedGroupBox1.Controls.Add(Me.txtDCACcount)
            Me.FixedGroupBox1.Controls.Add(Me.Label3)
            Me.FixedGroupBox1.Controls.Add(Me.Label7)
            Me.FixedGroupBox1.Controls.Add(Me.txtMCBank)
            Me.FixedGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.FixedGroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.FixedGroupBox1.Location = New System.Drawing.Point(750, 24)
            Me.FixedGroupBox1.Name = "FixedGroupBox1"
            Me.FixedGroupBox1.Size = New System.Drawing.Size(206, 124)
            Me.FixedGroupBox1.TabIndex = 329
            Me.FixedGroupBox1.TabStop = False
            Me.FixedGroupBox1.Text = "Export : "
            '
            'txtMCAccount
            '
            Me.Validator.SetDataType(Me.txtMCAccount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMCAccount, "")
            Me.txtMCAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtMCAccount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMCAccount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMCAccount, System.Drawing.Color.Empty)
            Me.txtMCAccount.Location = New System.Drawing.Point(80, 92)
            Me.txtMCAccount.MaxLength = 100
            Me.Validator.SetMinValue(Me.txtMCAccount, "")
            Me.txtMCAccount.Name = "txtMCAccount"
            Me.Validator.SetRegularExpression(Me.txtMCAccount, "")
            Me.Validator.SetRequired(Me.txtMCAccount, False)
            Me.txtMCAccount.Size = New System.Drawing.Size(120, 21)
            Me.txtMCAccount.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(5, 92)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(78, 18)
            Me.Label1.TabIndex = 15
            Me.Label1.Text = "MCL Account:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDCBank
            '
            Me.Validator.SetDataType(Me.txtDCBank, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDCBank, "")
            Me.txtDCBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDCBank, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDCBank, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDCBank, System.Drawing.Color.Empty)
            Me.txtDCBank.Location = New System.Drawing.Point(80, 20)
            Me.Validator.SetMinValue(Me.txtDCBank, "")
            Me.txtDCBank.Name = "txtDCBank"
            Me.Validator.SetRegularExpression(Me.txtDCBank, "")
            Me.Validator.SetRequired(Me.txtDCBank, False)
            Me.txtDCBank.Size = New System.Drawing.Size(120, 21)
            Me.txtDCBank.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(5, 20)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(78, 18)
            Me.Label2.TabIndex = 12
            Me.Label2.Text = "DCT Bank :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDCACcount
            '
            Me.Validator.SetDataType(Me.txtDCACcount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDCACcount, "")
            Me.txtDCACcount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDCACcount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDCACcount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDCACcount, System.Drawing.Color.Empty)
            Me.txtDCACcount.Location = New System.Drawing.Point(80, 44)
            Me.txtDCACcount.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtDCACcount, "")
            Me.txtDCACcount.Name = "txtDCACcount"
            Me.Validator.SetRegularExpression(Me.txtDCACcount, "")
            Me.Validator.SetRequired(Me.txtDCACcount, False)
            Me.txtDCACcount.Size = New System.Drawing.Size(120, 21)
            Me.txtDCACcount.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(5, 44)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(78, 18)
            Me.Label3.TabIndex = 13
            Me.Label3.Text = "DCT Account"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(5, 68)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(78, 18)
            Me.Label7.TabIndex = 14
            Me.Label7.Text = "MCL Bank:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMCBank
            '
            Me.Validator.SetDataType(Me.txtMCBank, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMCBank, "")
            Me.txtMCBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtMCBank, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMCBank, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMCBank, System.Drawing.Color.Empty)
            Me.txtMCBank.Location = New System.Drawing.Point(80, 68)
            Me.txtMCBank.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtMCBank, "")
            Me.txtMCBank.Name = "txtMCBank"
            Me.Validator.SetRegularExpression(Me.txtMCBank, "")
            Me.Validator.SetRequired(Me.txtMCBank, False)
            Me.txtMCBank.Size = New System.Drawing.Size(120, 21)
            Me.txtMCBank.TabIndex = 6
            '
            'btnLock
            '
            Me.btnLock.Image = Global.My.Resources.Resources.padlock_unlocked
            Me.btnLock.Location = New System.Drawing.Point(8, 371)
            Me.btnLock.Name = "btnLock"
            Me.btnLock.Size = New System.Drawing.Size(39, 44)
            Me.btnLock.TabIndex = 18
            Me.btnLock.UseVisualStyleBackColor = True
            '
            'tgContact
            '
            Me.tgContact.AllowNew = False
            Me.tgContact.AllowSorting = False
            Me.tgContact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgContact.AutoColumnResize = True
            Me.tgContact.CaptionVisible = False
            Me.tgContact.Cellchanged = False
            Me.tgContact.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))})
            Me.tgContact.DataMember = ""
            Me.tgContact.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgContact.Location = New System.Drawing.Point(360, 288)
            Me.tgContact.Name = "tgContact"
            Me.tgContact.Size = New System.Drawing.Size(606, 184)
            Me.tgContact.SortingArrowColor = System.Drawing.Color.Red
            Me.tgContact.TabIndex = 325
            Me.tgContact.TreeManager = Nothing
            '
            'ibtnAddContact
            '
            Me.ibtnAddContact.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnAddContact.Location = New System.Drawing.Point(488, 261)
            Me.ibtnAddContact.Name = "ibtnAddContact"
            Me.ibtnAddContact.Size = New System.Drawing.Size(24, 24)
            Me.ibtnAddContact.TabIndex = 327
            Me.ibtnAddContact.TabStop = False
            Me.ibtnAddContact.ThemedImage = CType(resources.GetObject("ibtnAddContact.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelContact
            '
            Me.ibtnDelContact.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnDelContact.Location = New System.Drawing.Point(512, 261)
            Me.ibtnDelContact.Name = "ibtnDelContact"
            Me.ibtnDelContact.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelContact.TabIndex = 328
            Me.ibtnDelContact.TabStop = False
            Me.ibtnDelContact.ThemedImage = CType(resources.GetObject("ibtnDelContact.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblContactItem
            '
            Me.lblContactItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblContactItem.ForeColor = System.Drawing.Color.Black
            Me.lblContactItem.Location = New System.Drawing.Point(360, 264)
            Me.lblContactItem.Name = "lblContactItem"
            Me.lblContactItem.Size = New System.Drawing.Size(128, 18)
            Me.lblContactItem.TabIndex = 326
            Me.lblContactItem.Text = "Contact:"
            Me.lblContactItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.GrayText
            Me.lblStatus.Location = New System.Drawing.Point(8, 456)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(52, 13)
            Me.lblStatus.TabIndex = 3
            Me.lblStatus.Text = "Status จ้า"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnAuxDetail
            '
            Me.btnAuxDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAuxDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAuxDetail.Location = New System.Drawing.Point(664, 256)
            Me.btnAuxDetail.Name = "btnAuxDetail"
            Me.btnAuxDetail.Size = New System.Drawing.Size(75, 23)
            Me.btnAuxDetail.TabIndex = 2
            Me.btnAuxDetail.Text = "เพิ่มเติม"
            '
            'primaryDetailGroupBox
            '
            Me.primaryDetailGroupBox.Controls.Add(Me.txtFaxforExport)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblFaxforExport)
            Me.primaryDetailGroupBox.Controls.Add(Me.cmbCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.chkAutorun)
            Me.primaryDetailGroupBox.Controls.Add(Me.cbmProvince)
            Me.primaryDetailGroupBox.Controls.Add(Me.chkcancel)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtEmail)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblEmail)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtName)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblName)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblAltName)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtBillingAddress)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblBillingAddress)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtAltName)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtAddress)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblAddress)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtPhone)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblPhone)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtFax)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblFax)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblProvince)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtMobile)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblMobile)
            Me.primaryDetailGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.primaryDetailGroupBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.primaryDetailGroupBox.Location = New System.Drawing.Point(8, 24)
            Me.primaryDetailGroupBox.Name = "primaryDetailGroupBox"
            Me.primaryDetailGroupBox.Size = New System.Drawing.Size(338, 341)
            Me.primaryDetailGroupBox.TabIndex = 0
            Me.primaryDetailGroupBox.TabStop = False
            Me.primaryDetailGroupBox.Text = "ข้อมูลเบื้องต้น : "
            '
            'cmbCode
            '
            Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
            Me.cmbCode.Location = New System.Drawing.Point(96, 24)
            Me.cmbCode.Name = "cmbCode"
            Me.cmbCode.Size = New System.Drawing.Size(120, 21)
            Me.cmbCode.TabIndex = 22
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(216, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 20
            Me.chkAutorun.TabStop = False
            '
            'cbmProvince
            '
            Me.ErrorProvider1.SetIconPadding(Me.cbmProvince, -15)
            Me.cbmProvince.Location = New System.Drawing.Point(96, 192)
            Me.cbmProvince.MaxLength = 100
            Me.cbmProvince.Name = "cbmProvince"
            Me.cbmProvince.Size = New System.Drawing.Size(224, 21)
            Me.cbmProvince.TabIndex = 5
            '
            'chkcancel
            '
            Me.chkcancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkcancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.chkcancel.ForeColor = System.Drawing.Color.Black
            Me.chkcancel.Location = New System.Drawing.Point(256, 24)
            Me.chkcancel.Name = "chkcancel"
            Me.chkcancel.Size = New System.Drawing.Size(72, 20)
            Me.chkcancel.TabIndex = 21
            Me.chkcancel.TabStop = False
            Me.chkcancel.Text = "ยกเลิก"
            '
            'txtEmail
            '
            Me.Validator.SetDataType(Me.txtEmail, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmail, "")
            Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmail, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEmail, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEmail, System.Drawing.Color.Empty)
            Me.txtEmail.Location = New System.Drawing.Point(96, 288)
            Me.txtEmail.MaxLength = 250
            Me.Validator.SetMinValue(Me.txtEmail, "")
            Me.txtEmail.Name = "txtEmail"
            Me.Validator.SetRegularExpression(Me.txtEmail, "")
            Me.Validator.SetRequired(Me.txtEmail, False)
            Me.txtEmail.Size = New System.Drawing.Size(224, 21)
            Me.txtEmail.TabIndex = 9
            '
            'lblEmail
            '
            Me.lblEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEmail.ForeColor = System.Drawing.Color.Black
            Me.lblEmail.Location = New System.Drawing.Point(8, 288)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(88, 18)
            Me.lblEmail.TabIndex = 19
            Me.lblEmail.Text = "อีเมล์:"
            Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(96, 48)
            Me.txtName.MaxLength = 200
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(224, 21)
            Me.txtName.TabIndex = 1
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(88, 18)
            Me.lblName.TabIndex = 11
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(88, 18)
            Me.lblCode.TabIndex = 10
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAltName
            '
            Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAltName.ForeColor = System.Drawing.Color.Black
            Me.lblAltName.Location = New System.Drawing.Point(8, 72)
            Me.lblAltName.Name = "lblAltName"
            Me.lblAltName.Size = New System.Drawing.Size(88, 18)
            Me.lblAltName.TabIndex = 12
            Me.lblAltName.Text = "ชื่ออื่น:"
            Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBillingAddress
            '
            Me.Validator.SetDataType(Me.txtBillingAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillingAddress, "")
            Me.txtBillingAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillingAddress, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBillingAddress, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBillingAddress, System.Drawing.Color.Empty)
            Me.txtBillingAddress.Location = New System.Drawing.Point(96, 96)
            Me.txtBillingAddress.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtBillingAddress, "")
            Me.txtBillingAddress.Multiline = True
            Me.txtBillingAddress.Name = "txtBillingAddress"
            Me.Validator.SetRegularExpression(Me.txtBillingAddress, "")
            Me.Validator.SetRequired(Me.txtBillingAddress, True)
            Me.txtBillingAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtBillingAddress.Size = New System.Drawing.Size(224, 42)
            Me.txtBillingAddress.TabIndex = 3
            Me.txtBillingAddress.WordWrap = False
            '
            'lblBillingAddress
            '
            Me.lblBillingAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillingAddress.ForeColor = System.Drawing.Color.Black
            Me.lblBillingAddress.Location = New System.Drawing.Point(8, 96)
            Me.lblBillingAddress.Name = "lblBillingAddress"
            Me.lblBillingAddress.Size = New System.Drawing.Size(88, 18)
            Me.lblBillingAddress.TabIndex = 13
            Me.lblBillingAddress.Text = "ที่อยู่ตามเอกสาร:"
            Me.lblBillingAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAltName
            '
            Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAltName, "")
            Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAltName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.txtAltName.Location = New System.Drawing.Point(96, 72)
            Me.txtAltName.MaxLength = 200
            Me.Validator.SetMinValue(Me.txtAltName, "")
            Me.txtAltName.Name = "txtAltName"
            Me.Validator.SetRegularExpression(Me.txtAltName, "")
            Me.Validator.SetRequired(Me.txtAltName, False)
            Me.txtAltName.Size = New System.Drawing.Size(224, 21)
            Me.txtAltName.TabIndex = 2
            '
            'txtAddress
            '
            Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAddress, "")
            Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAddress, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.txtAddress.Location = New System.Drawing.Point(96, 144)
            Me.txtAddress.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtAddress, "")
            Me.txtAddress.Multiline = True
            Me.txtAddress.Name = "txtAddress"
            Me.Validator.SetRegularExpression(Me.txtAddress, "")
            Me.Validator.SetRequired(Me.txtAddress, False)
            Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtAddress.Size = New System.Drawing.Size(224, 42)
            Me.txtAddress.TabIndex = 4
            Me.txtAddress.WordWrap = False
            '
            'lblAddress
            '
            Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAddress.ForeColor = System.Drawing.Color.Black
            Me.lblAddress.Location = New System.Drawing.Point(8, 144)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(88, 18)
            Me.lblAddress.TabIndex = 14
            Me.lblAddress.Text = "ที่อยู่ปัจจุบัน:"
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPhone
            '
            Me.Validator.SetDataType(Me.txtPhone, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPhone, "")
            Me.txtPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPhone, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.txtPhone.Location = New System.Drawing.Point(96, 216)
            Me.txtPhone.MaxLength = 250
            Me.Validator.SetMinValue(Me.txtPhone, "")
            Me.txtPhone.Name = "txtPhone"
            Me.Validator.SetRegularExpression(Me.txtPhone, "")
            Me.Validator.SetRequired(Me.txtPhone, False)
            Me.txtPhone.Size = New System.Drawing.Size(224, 21)
            Me.txtPhone.TabIndex = 6
            '
            'lblPhone
            '
            Me.lblPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPhone.ForeColor = System.Drawing.Color.Black
            Me.lblPhone.Location = New System.Drawing.Point(8, 216)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(88, 18)
            Me.lblPhone.TabIndex = 16
            Me.lblPhone.Text = "โทรศัพท์:"
            Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtFax
            '
            Me.Validator.SetDataType(Me.txtFax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFax, "")
            Me.txtFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtFax, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtFax, -15)
            Me.Validator.SetInvalidBackColor(Me.txtFax, System.Drawing.Color.Empty)
            Me.txtFax.Location = New System.Drawing.Point(96, 264)
            Me.txtFax.MaxLength = 250
            Me.Validator.SetMinValue(Me.txtFax, "")
            Me.txtFax.Name = "txtFax"
            Me.Validator.SetRegularExpression(Me.txtFax, "")
            Me.Validator.SetRequired(Me.txtFax, False)
            Me.txtFax.Size = New System.Drawing.Size(224, 21)
            Me.txtFax.TabIndex = 8
            '
            'lblFax
            '
            Me.lblFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFax.ForeColor = System.Drawing.Color.Black
            Me.lblFax.Location = New System.Drawing.Point(8, 264)
            Me.lblFax.Name = "lblFax"
            Me.lblFax.Size = New System.Drawing.Size(88, 18)
            Me.lblFax.TabIndex = 18
            Me.lblFax.Text = "โทรสาร:"
            Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProvince
            '
            Me.lblProvince.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProvince.ForeColor = System.Drawing.Color.Black
            Me.lblProvince.Location = New System.Drawing.Point(8, 192)
            Me.lblProvince.Name = "lblProvince"
            Me.lblProvince.Size = New System.Drawing.Size(88, 18)
            Me.lblProvince.TabIndex = 15
            Me.lblProvince.Text = "จังหวัด:"
            Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMobile
            '
            Me.Validator.SetDataType(Me.txtMobile, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMobile, "")
            Me.txtMobile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtMobile, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtMobile, -15)
            Me.Validator.SetInvalidBackColor(Me.txtMobile, System.Drawing.Color.Empty)
            Me.txtMobile.Location = New System.Drawing.Point(96, 240)
            Me.txtMobile.MaxLength = 250
            Me.Validator.SetMinValue(Me.txtMobile, "")
            Me.txtMobile.Name = "txtMobile"
            Me.Validator.SetRegularExpression(Me.txtMobile, "")
            Me.Validator.SetRequired(Me.txtMobile, False)
            Me.txtMobile.Size = New System.Drawing.Size(224, 21)
            Me.txtMobile.TabIndex = 7
            '
            'lblMobile
            '
            Me.lblMobile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMobile.ForeColor = System.Drawing.Color.Black
            Me.lblMobile.Location = New System.Drawing.Point(8, 240)
            Me.lblMobile.Name = "lblMobile"
            Me.lblMobile.Size = New System.Drawing.Size(88, 18)
            Me.lblMobile.TabIndex = 17
            Me.lblMobile.Text = "โทรศัพท์มือถือ:"
            Me.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'otherDetailGroupBox
            '
            Me.otherDetailGroupBox.Controls.Add(Me.btnGroupFind)
            Me.otherDetailGroupBox.Controls.Add(Me.btnAccountFind)
            Me.otherDetailGroupBox.Controls.Add(Me.btnGroupEdit)
            Me.otherDetailGroupBox.Controls.Add(Me.btnAccountEdit)
            Me.otherDetailGroupBox.Controls.Add(Me.txtContact)
            Me.otherDetailGroupBox.Controls.Add(Me.lblContact)
            Me.otherDetailGroupBox.Controls.Add(Me.rdJuris)
            Me.otherDetailGroupBox.Controls.Add(Me.txtAuthorizeAmount)
            Me.otherDetailGroupBox.Controls.Add(Me.lblAuthorizeAmount)
            Me.otherDetailGroupBox.Controls.Add(Me.txtTaxID)
            Me.otherDetailGroupBox.Controls.Add(Me.lblTaxID)
            Me.otherDetailGroupBox.Controls.Add(Me.lblPersonType)
            Me.otherDetailGroupBox.Controls.Add(Me.rdIndividual)
            Me.otherDetailGroupBox.Controls.Add(Me.lblGroup)
            Me.otherDetailGroupBox.Controls.Add(Me.lblAccount)
            Me.otherDetailGroupBox.Controls.Add(Me.txtAccountName)
            Me.otherDetailGroupBox.Controls.Add(Me.txtGroupName)
            Me.otherDetailGroupBox.Controls.Add(Me.lblIdNo)
            Me.otherDetailGroupBox.Controls.Add(Me.txtIdNo)
            Me.otherDetailGroupBox.Controls.Add(Me.txtGroupCode)
            Me.otherDetailGroupBox.Controls.Add(Me.txtAccountCode)
            Me.otherDetailGroupBox.Controls.Add(Me.txtNote)
            Me.otherDetailGroupBox.Controls.Add(Me.lblNote)
            Me.otherDetailGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.otherDetailGroupBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.otherDetailGroupBox.Location = New System.Drawing.Point(352, 24)
            Me.otherDetailGroupBox.Name = "otherDetailGroupBox"
            Me.otherDetailGroupBox.Size = New System.Drawing.Size(392, 224)
            Me.otherDetailGroupBox.TabIndex = 1
            Me.otherDetailGroupBox.TabStop = False
            Me.otherDetailGroupBox.Text = "ข้อมูลอื่น ๆ : "
            '
            'btnGroupFind
            '
            Me.btnGroupFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnGroupFind.Location = New System.Drawing.Point(336, 47)
            Me.btnGroupFind.Name = "btnGroupFind"
            Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
            Me.btnGroupFind.TabIndex = 20
            Me.btnGroupFind.TabStop = False
            Me.btnGroupFind.ThemedImage = CType(resources.GetObject("btnGroupFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind
            '
            Me.btnAccountFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind.Location = New System.Drawing.Point(336, 71)
            Me.btnAccountFind.Name = "btnAccountFind"
            Me.btnAccountFind.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind.TabIndex = 22
            Me.btnAccountFind.TabStop = False
      Me.btnAccountFind.Tag = "NotGigaSite"
            Me.btnAccountFind.ThemedImage = CType(resources.GetObject("btnAccountFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnGroupEdit
            '
            Me.btnGroupEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnGroupEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGroupEdit.Location = New System.Drawing.Point(360, 47)
            Me.btnGroupEdit.Name = "btnGroupEdit"
            Me.btnGroupEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnGroupEdit.TabIndex = 21
            Me.btnGroupEdit.TabStop = False
            Me.btnGroupEdit.ThemedImage = CType(resources.GetObject("btnGroupEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit
            '
            Me.btnAccountEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit.Location = New System.Drawing.Point(360, 71)
            Me.btnAccountEdit.Name = "btnAccountEdit"
            Me.btnAccountEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit.TabIndex = 0
            Me.btnAccountEdit.TabStop = False
      Me.btnAccountEdit.Tag = "NotGigaSite"
            Me.btnAccountEdit.ThemedImage = CType(resources.GetObject("btnAccountEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtContact
            '
            Me.Validator.SetDataType(Me.txtContact, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtContact, "")
            Me.txtContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtContact, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtContact, -15)
            Me.Validator.SetInvalidBackColor(Me.txtContact, System.Drawing.Color.Empty)
            Me.txtContact.Location = New System.Drawing.Point(136, 168)
            Me.txtContact.MaxLength = 100
            Me.Validator.SetMinValue(Me.txtContact, "")
            Me.txtContact.Name = "txtContact"
            Me.Validator.SetRegularExpression(Me.txtContact, "")
            Me.Validator.SetRequired(Me.txtContact, False)
            Me.txtContact.Size = New System.Drawing.Size(248, 21)
            Me.txtContact.TabIndex = 7
            '
            'lblContact
            '
            Me.lblContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblContact.ForeColor = System.Drawing.Color.Black
            Me.lblContact.Location = New System.Drawing.Point(8, 168)
            Me.lblContact.Name = "lblContact"
            Me.lblContact.Size = New System.Drawing.Size(128, 18)
            Me.lblContact.TabIndex = 15
            Me.lblContact.Text = "ผู้ติดต่อ:"
            Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rdJuris
            '
            Me.rdJuris.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdJuris.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.rdJuris.ForeColor = System.Drawing.Color.Black
            Me.rdJuris.Location = New System.Drawing.Point(136, 24)
            Me.rdJuris.Name = "rdJuris"
            Me.rdJuris.Size = New System.Drawing.Size(72, 24)
            Me.rdJuris.TabIndex = 0
            Me.rdJuris.Text = "นิติบุคคล"
            '
            'txtAuthorizeAmount
            '
            Me.Validator.SetDataType(Me.txtAuthorizeAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtAuthorizeAmount, "")
            Me.txtAuthorizeAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAuthorizeAmount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAuthorizeAmount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAuthorizeAmount, System.Drawing.Color.Empty)
            Me.txtAuthorizeAmount.Location = New System.Drawing.Point(136, 96)
            Me.Validator.SetMinValue(Me.txtAuthorizeAmount, "")
            Me.txtAuthorizeAmount.Name = "txtAuthorizeAmount"
            Me.Validator.SetRegularExpression(Me.txtAuthorizeAmount, "")
            Me.Validator.SetRequired(Me.txtAuthorizeAmount, False)
            Me.txtAuthorizeAmount.Size = New System.Drawing.Size(248, 21)
            Me.txtAuthorizeAmount.TabIndex = 4
            '
            'lblAuthorizeAmount
            '
            Me.lblAuthorizeAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAuthorizeAmount.ForeColor = System.Drawing.Color.Black
            Me.lblAuthorizeAmount.Location = New System.Drawing.Point(8, 96)
            Me.lblAuthorizeAmount.Name = "lblAuthorizeAmount"
            Me.lblAuthorizeAmount.Size = New System.Drawing.Size(128, 18)
            Me.lblAuthorizeAmount.TabIndex = 12
            Me.lblAuthorizeAmount.Text = "ทุนจดทะเบียน :"
            Me.lblAuthorizeAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTaxID
            '
            Me.Validator.SetDataType(Me.txtTaxID, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxID, "")
            Me.txtTaxID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTaxID, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtTaxID, -15)
            Me.Validator.SetInvalidBackColor(Me.txtTaxID, System.Drawing.Color.Empty)
            Me.txtTaxID.Location = New System.Drawing.Point(136, 120)
            Me.txtTaxID.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtTaxID, "")
            Me.txtTaxID.Name = "txtTaxID"
            Me.Validator.SetRegularExpression(Me.txtTaxID, "")
            Me.Validator.SetRequired(Me.txtTaxID, False)
            Me.txtTaxID.Size = New System.Drawing.Size(248, 21)
            Me.txtTaxID.TabIndex = 5
            '
            'lblTaxID
            '
            Me.lblTaxID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxID.ForeColor = System.Drawing.Color.Black
            Me.lblTaxID.Location = New System.Drawing.Point(8, 120)
            Me.lblTaxID.Name = "lblTaxID"
            Me.lblTaxID.Size = New System.Drawing.Size(128, 18)
            Me.lblTaxID.TabIndex = 13
            Me.lblTaxID.Text = "เลขที่ประจำตัวผู้เสียภาษี :"
            Me.lblTaxID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPersonType
            '
            Me.lblPersonType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPersonType.ForeColor = System.Drawing.Color.Black
            Me.lblPersonType.Location = New System.Drawing.Point(8, 24)
            Me.lblPersonType.Name = "lblPersonType"
            Me.lblPersonType.Size = New System.Drawing.Size(128, 18)
            Me.lblPersonType.TabIndex = 9
            Me.lblPersonType.Text = "ประเภทบุคคล :"
            Me.lblPersonType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rdIndividual
            '
            Me.rdIndividual.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdIndividual.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.rdIndividual.ForeColor = System.Drawing.Color.Black
            Me.rdIndividual.Location = New System.Drawing.Point(216, 24)
            Me.rdIndividual.Name = "rdIndividual"
            Me.rdIndividual.Size = New System.Drawing.Size(104, 24)
            Me.rdIndividual.TabIndex = 1
            Me.rdIndividual.Text = "บุคคลธรรมดา"
            '
            'lblGroup
            '
            Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Black
            Me.lblGroup.Location = New System.Drawing.Point(8, 48)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(128, 18)
            Me.lblGroup.TabIndex = 10
            Me.lblGroup.Text = "กลุ่ม Supplier :"
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAccount
            '
            Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccount.ForeColor = System.Drawing.Color.Black
            Me.lblAccount.Location = New System.Drawing.Point(8, 72)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.Size = New System.Drawing.Size(128, 18)
            Me.lblAccount.TabIndex = 11
      Me.lblAccount.Tag = "NotGigaSite"
            Me.lblAccount.Text = "บัญชี :"
            Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAccountName
            '
            Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName, "")
            Me.txtAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.txtAccountName.Location = New System.Drawing.Point(216, 72)
            Me.Validator.SetMinValue(Me.txtAccountName, "")
            Me.txtAccountName.Name = "txtAccountName"
            Me.txtAccountName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName, "")
            Me.Validator.SetRequired(Me.txtAccountName, False)
            Me.txtAccountName.Size = New System.Drawing.Size(120, 21)
            Me.txtAccountName.TabIndex = 18
            Me.txtAccountName.TabStop = False
      Me.txtAccountName.Tag = "NotGigaSite"
            '
            'txtGroupName
            '
            Me.Validator.SetDataType(Me.txtGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroupName, "")
            Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.txtGroupName.Location = New System.Drawing.Point(216, 48)
            Me.Validator.SetMinValue(Me.txtGroupName, "")
            Me.txtGroupName.Name = "txtGroupName"
            Me.txtGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGroupName, "")
            Me.Validator.SetRequired(Me.txtGroupName, False)
            Me.txtGroupName.Size = New System.Drawing.Size(120, 21)
            Me.txtGroupName.TabIndex = 17
            Me.txtGroupName.TabStop = False
            '
            'lblIdNo
            '
            Me.lblIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblIdNo.ForeColor = System.Drawing.Color.Black
            Me.lblIdNo.Location = New System.Drawing.Point(8, 144)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(128, 18)
            Me.lblIdNo.TabIndex = 14
            Me.lblIdNo.Text = "เลขที่บัตรประชาชน :"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtIdNo
            '
            Me.Validator.SetDataType(Me.txtIdNo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtIdNo, "")
            Me.txtIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtIdNo, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtIdNo, -15)
            Me.Validator.SetInvalidBackColor(Me.txtIdNo, System.Drawing.Color.Empty)
            Me.txtIdNo.Location = New System.Drawing.Point(136, 144)
            Me.txtIdNo.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtIdNo, "")
            Me.txtIdNo.Name = "txtIdNo"
            Me.Validator.SetRegularExpression(Me.txtIdNo, "")
            Me.Validator.SetRequired(Me.txtIdNo, False)
            Me.txtIdNo.Size = New System.Drawing.Size(248, 21)
            Me.txtIdNo.TabIndex = 6
            '
            'txtGroupCode
            '
            Me.Validator.SetDataType(Me.txtGroupCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroupCode, "")
            Me.txtGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtGroupCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
            Me.txtGroupCode.Location = New System.Drawing.Point(136, 48)
            Me.txtGroupCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtGroupCode, "")
            Me.txtGroupCode.Name = "txtGroupCode"
            Me.Validator.SetRegularExpression(Me.txtGroupCode, "")
            Me.Validator.SetRequired(Me.txtGroupCode, True)
            Me.txtGroupCode.Size = New System.Drawing.Size(80, 21)
            Me.txtGroupCode.TabIndex = 2
            '
            'txtAccountCode
            '
            Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode, "")
            Me.txtAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
            Me.txtAccountCode.Location = New System.Drawing.Point(136, 72)
            Me.txtAccountCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode, "")
            Me.txtAccountCode.Name = "txtAccountCode"
            Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
            Me.Validator.SetRequired(Me.txtAccountCode, True)
            Me.txtAccountCode.Size = New System.Drawing.Size(80, 21)
            Me.txtAccountCode.TabIndex = 3
      Me.txtAccountCode.Tag = "NotGigaSite"
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtNote, -15)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(136, 192)
            Me.txtNote.MaxLength = 100
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(248, 21)
            Me.txtNote.TabIndex = 8
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 192)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(128, 18)
            Me.lblNote.TabIndex = 16
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'txtFaxforExport
            '
            Me.Validator.SetDataType(Me.txtFaxforExport, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFaxforExport, "")
            Me.txtFaxforExport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtFaxforExport, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtFaxforExport, -15)
            Me.Validator.SetInvalidBackColor(Me.txtFaxforExport, System.Drawing.Color.Empty)
            Me.txtFaxforExport.Location = New System.Drawing.Point(96, 312)
            Me.txtFaxforExport.MaxLength = 250
            Me.Validator.SetMinValue(Me.txtFaxforExport, "")
            Me.txtFaxforExport.Name = "txtFaxforExport"
            Me.Validator.SetRegularExpression(Me.txtFaxforExport, "")
            Me.Validator.SetRequired(Me.txtFaxforExport, False)
            Me.txtFaxforExport.Size = New System.Drawing.Size(224, 21)
            Me.txtFaxforExport.TabIndex = 23
            '
            'lblFaxforExport
            '
            Me.lblFaxforExport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFaxforExport.ForeColor = System.Drawing.Color.Black
            Me.lblFaxforExport.Location = New System.Drawing.Point(8, 312)
            Me.lblFaxforExport.Name = "lblFaxforExport"
            Me.lblFaxforExport.Size = New System.Drawing.Size(88, 18)
            Me.lblFaxforExport.TabIndex = 24
            Me.lblFaxforExport.Text = "Fax for Export:"
            Me.lblFaxforExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'SupplierDetailView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "SupplierDetailView"
            Me.Size = New System.Drawing.Size(990, 496)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            Me.FixedGroupBox1.ResumeLayout(False)
            Me.FixedGroupBox1.PerformLayout()
            CType(Me.tgContact, System.ComponentModel.ISupportInitialize).EndInit()
            Me.primaryDetailGroupBox.ResumeLayout(False)
            Me.primaryDetailGroupBox.PerformLayout()
            Me.otherDetailGroupBox.ResumeLayout(False)
            Me.otherDetailGroupBox.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblCode}")
            Me.Validator.SetDisplayName(Me.cmbCode, lblCode.Text)

            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblName}")
            Me.Validator.SetDisplayName(Me.txtName, lblName.Text)

            Me.lblAltName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblAltName}")
            Me.Validator.SetDisplayName(Me.txtAltName, lblAltName.Text)

            Me.lblEmail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblEmail}")
            Me.Validator.SetDisplayName(Me.txtEmail, lblEmail.Text)

            Me.lblBillingAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblBillingAddress}")
            Me.Validator.SetDisplayName(Me.txtBillingAddress, lblBillingAddress.Text)

            Me.lblAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblAddress}")
            Me.Validator.SetDisplayName(Me.txtAddress, lblAddress.Text)

            Me.lblPhone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblPhone}")
            Me.Validator.SetDisplayName(Me.txtPhone, lblPhone.Text)

            Me.lblFax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblFax}")
            Me.Validator.SetDisplayName(Me.txtFax, lblFax.Text)

            Me.rdJuris.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.rdJuris}")
            Me.rdIndividual.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.rdIndividual}")

            Me.lblAuthorizeAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblAuthorizeAmount}")
            Me.Validator.SetDisplayName(Me.txtAuthorizeAmount, lblAuthorizeAmount.Text)

            Me.lblTaxID.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblTaxID}")
            Me.Validator.SetDisplayName(Me.txtTaxID, lblTaxID.Text)

            Me.lblPersonType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblPersonType}")

            Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblAccount}")
            Me.Validator.SetDisplayName(Me.txtAccountCode, lblAccount.Text)

            Me.lblGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblGroup}")
            Me.Validator.SetDisplayName(Me.txtGroupCode, lblGroup.Text)

            Me.lblContact.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblContact}")
            Me.Validator.SetDisplayName(Me.txtContact, lblContact.Text)

            Me.lblIdNo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblIdNo}")
            Me.Validator.SetDisplayName(Me.txtIdNo, lblIdNo.Text)

            Me.lblProvince.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblProvince}")

            Me.chkcancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.chkcancel}")

            Me.btnAuxDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.btnAuxDetail}")

            Me.primaryDetailGroupBox.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.primaryDetailGroupBox}")
            Me.otherDetailGroupBox.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.otherDetailGroupBox}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.grbDetail}")

            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblNote}")
            Me.lblMobile.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblMobile}")

            Me.lblContactItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblContactItem}")
            Me.lblFaxforExport.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.lblFaxforExport}")
        End Sub
#End Region

#Region " Member "
        Private m_entity As Supplier
        Private m_isInitialized As Boolean = False

        Private m_tableStyleEnable As Hashtable

        Private m_treeManager As TreeManager
        Private m_contactInitialized As Boolean
        Private m_combocodeindex As Integer

        Private m_locked As Boolean = True
        Private m_lockedInit As Boolean = True
#End Region

#Region " Constructor "
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Me.Initialize()

            Dim dt As TreeTable = SupplierContact.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgContact)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False

            AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete

            Me.EventWiring()
      DisableGigaSiteControl()
    End Sub
    Private Sub DisableGigaSiteControl()
      If Longkong.Pojjaman.BusinessLogic.Configuration.CheckGigaSiteRight Then
        Me.btnAccountFind.Enabled = False
        Me.btnAccountEdit.Enabled = False
        Me.lblAccount.Enabled = False
        Me.txtAccountName.Enabled = False
        Me.txtAccountCode.Enabled = False
      End If
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Contact"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "LineNumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "LineNumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 70

            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.NameHeaderText}")
            csName.NullText = ""
            csName.Width = 70

            Dim csTitle As New TreeTextColumn
            csTitle.MappingName = "Title"
            csTitle.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.TitleHeaderText}")
            csTitle.NullText = ""
            csTitle.Width = 70

            Dim csPhone As New TreeTextColumn
            csPhone.MappingName = "Phone"
            csPhone.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.PhoneHeaderText}")
            csPhone.NullText = ""
            csPhone.Width = 70

            Dim csEmail As New TreeTextColumn
            csEmail.MappingName = "Email"
            csEmail.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierDetailView.EmailHeaderText}")
            csEmail.NullText = ""
            csEmail.Width = 70

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csTitle)
            dst.GridColumnStyles.Add(csPhone)
            dst.GridColumnStyles.Add(csEmail)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
        Private ReadOnly Property CurrentContact() As SupplierContact
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                Return CType(row.Tag, SupplierContact)
            End Get
        End Property
        Private Property ComboCodeIndex() As Integer
            Get
                If m_combocodeindex = -1 Then
                    If cmbCode.Items.Count > 0 Then
                        m_combocodeindex = 0
                    End If
                End If
                Return m_combocodeindex
            End Get
            Set(ByVal Value As Integer)
                m_combocodeindex = Value
            End Set
        End Property
        Private Sub RefreshContact()
            Dim dt As TreeTable = Me.m_treeManager.Treetable
            dt.Clear()
            Dim scColl As SupplierContactCollection = Me.m_entity.ContactCollection
            m_contactInitialized = False
            scColl.Populate(dt)
            m_contactInitialized = True
        End Sub
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_contactInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                Me.m_treeManager.Treetable.AcceptChanges()
            End If
            Dim currIndex As Integer = Me.tgContact.CurrentRowIndex
            RefreshContact()
            tgContact.CurrentRowIndex = currIndex
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_contactInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetCode(e)
                    Case "name"
                        SetName(e)
                    Case "title"
                        SetTitle(e)
                    Case "phone"
                        SetPhone(e)
                    Case "email"
                        SetEmail(e)
                    Case "fax"
                        SetFax(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim code As Object = e.Row("code")
            Dim name As Object = e.Row("name")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    code = e.ProposedValue
                Case "name"
                    name = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If IsDBNull(code) Then
                isBlankRow = True
            End If

            If Not isBlankRow Then
                If IsDBNull(name) OrElse CStr(name).Length = 0 Then
                    e.Row.SetColumnError("name", Me.StringParserService.Parse("${res:Global.Error.NameMissing}"))
                Else
                    e.Row.SetColumnError("name", "")
                End If
                If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                    e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.CodeMissing}"))
                Else
                    e.Row.SetColumnError("code", "")
                End If
            End If

        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            If row.IsNull("code") Then
                Return False
            End If
            Return True
        End Function
        Private m_updating As Boolean = False
        Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
            If e.Row.IsNull("code") Then
                Return False
            End If
            If IsDBNull(e.ProposedValue) Then
                Return False
            End If
            For Each row As TreeRow In Me.m_treeManager.Treetable.Childs
                If Not row Is e.Row Then
                    If Not row.IsNull("code") Then
                        If CStr(row("code")).ToLower = CStr(e.Row("code")).ToLower Then
                            If Not row.IsNull("code") Then
                                If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If
            Next
            Return False
        End Function
        Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim item As SupplierContact = Me.CurrentContact
            If item Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If DupCode(e) Then
                msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.DetailPanelTitle, e.ProposedValue.ToString})
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            item.Code = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Public Sub SetName(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim item As SupplierContact = Me.CurrentContact
            If item Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            item.Name = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Public Sub SetTitle(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim item As SupplierContact = Me.CurrentContact
            If item Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            item.Title = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Public Sub SetPhone(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim item As SupplierContact = Me.CurrentContact
            If item Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            item.Phone = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Public Sub SetFax(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim item As SupplierContact = Me.CurrentContact
            If item Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            item.Fax = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Public Sub SetEmail(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim item As SupplierContact = Me.CurrentContact
            If item Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            item.Email = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

        End Sub
#End Region

#Region " IListDetail "
        Public Overrides Sub Initialize()
            Province.ListProvinceInComboBox(Me.cbmProvince)
        End Sub

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()

            Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            Dim level As Integer = secSrv.GetAccess(338)       'ตรวจสอบ สิทธิปลดล๊อคใบรับของ
            Dim checkString As String = BinaryHelper.DecToBin(level, 5)      'เปลี่ยนตัวเลขเป็น รหัส 01 5ตัว ตามค่าตัวเลข
            checkString = BinaryHelper.RevertString(checkString)
            btnLock.Visible = False
            'lblStatus.Text = ""
            If Me.m_entity.Canceled Then
                For Each ctrl As Control In primaryDetailGroupBox.Controls
                    ctrl.Enabled = False
                Next
                Me.chkcancel.Enabled = True
                otherDetailGroupBox.Enabled = False
            Else
                If Not m_entity.IsReferenced OrElse Not m_locked Then
                    For Each ctrl As Control In primaryDetailGroupBox.Controls
                        ctrl.Enabled = True
                    Next
                    otherDetailGroupBox.Enabled = True
                ElseIf m_locked Then
                    For Each ctrl As Control In primaryDetailGroupBox.Controls
                        ctrl.Enabled = False
                    Next
                    otherDetailGroupBox.Enabled = False
                End If

                If CBool(checkString.Substring(0, 1)) AndAlso m_entity.Originated Then
                    btnLock.Enabled = True
                    btnLock.Visible = True
                End If
            End If
            Me.FixedGroupBox1.Enabled = True
            Me.txtDCACcount.Enabled = True
            Me.txtDCBank.Enabled = True
            Me.txtMCBank.Enabled = True
            Me.txtMCAccount.Enabled = True

            Try
                Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
                Dim currentUser As User = mySService.CurrentUser
                If Not currentUser Is Nothing AndAlso currentUser.Originated Then
                    Dim value As Integer = currentUser.GetAccess(New Access(354))
                    Select Case value
                        Case 0
                            Me.FixedGroupBox1.Visible = False
                        Case 1
                            Me.FixedGroupBox1.Visible = True
                            Me.FixedGroupBox1.Enabled = False
                        Case 3
                            Me.FixedGroupBox1.Visible = True
                            Me.FixedGroupBox1.Enabled = True
                    End Select
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.ToString)
            End Try
        End Sub

        ' เคลียร์ข้อมูลลูกค้าใน control
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In grbDetail.Controls
                If TypeOf crlt Is TextBox Then
                    crlt.Text = ""
                End If
            Next

            rdJuris.PerformClick()
            chkcancel.Checked = False

            cbmProvince.SelectedIndex = -1
            cbmProvince.SelectedIndex = -1
            lblStatus.Text = ""
        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtAltName.TextChanged, AddressOf Me.ChangeProperty

            AddHandler chkcancel.CheckedChanged, AddressOf Me.ChangeProperty

            AddHandler txtBillingAddress.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtAddress.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtPhone.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtContact.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtFax.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtEmail.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtFaxforExport.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtFaxforExport.Validated, AddressOf Me.ValidateText

            AddHandler txtAuthorizeAmount.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtTaxID.TextChanged, AddressOf Me.ChangeProperty

            AddHandler rdJuris.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler rdIndividual.CheckedChanged, AddressOf Me.ChangeProperty

            AddHandler txtIdNo.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtGroupCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtAccountCode.Validated, AddressOf Me.ChangeProperty

            AddHandler cbmProvince.Validated, AddressOf Me.ChangeProperty

            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtMobile.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtDCBank.TextChanged, AddressOf ChangeProperty
            AddHandler txtDCACcount.TextChanged, AddressOf ChangeProperty
            AddHandler txtMCBank.TextChanged, AddressOf ChangeProperty
            AddHandler txtMCAccount.TextChanged, AddressOf ChangeProperty

        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            cmbCode.Items.Clear()
            cmbCode.DropDownStyle = ComboBoxStyle.Simple
            cmbCode.Text = m_entity.Code
            BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
            txtName.Text = m_entity.Name
            txtNote.Text = m_entity.Note
            txtMobile.Text = m_entity.Mobile
            m_entity.LoadImage()

            ' AutoRun 
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtAltName.Text = m_entity.AlternateName
            txtBillingAddress.Text = m_entity.BillingAddress

            txtAddress.Text = m_entity.Address
            txtPhone.Text = m_entity.Phone
            txtFax.Text = m_entity.Fax
            txtEmail.Text = m_entity.EmailAddress
            txtFaxforExport.Text = m_entity.FaxforExport

            txtGroupCode.Text = m_entity.Group.Code
            txtGroupName.Text = m_entity.Group.Name

            txtAccountCode.Text = m_entity.Account.Code
            txtAccountName.Text = m_entity.Account.Name

            txtAuthorizeAmount.Text = Configuration.FormatToString(m_entity.AuthorizeAmount, DigitConfig.Price)
            txtTaxID.Text = m_entity.TaxId
            txtIdNo.Text = m_entity.IdNo
            txtContact.Text = m_entity.Contact

            If (Me.m_entity.IsReferenced OrElse Me.m_entity.Canceled) AndAlso m_lockedInit = True Then
                m_locked = True
            ElseIf m_lockedInit = True Then
                m_locked = False
            End If

            Dim flaginlist As Boolean = False
            For Each item As IdValuePair In Me.cbmProvince.Items
                If item.Value = Me.m_entity.Province Then
                    Me.cbmProvince.SelectedItem = item
                    flaginlist = True
                    Exit For
                End If
            Next
            If Not flaginlist Then
                Me.cbmProvince.Text = Me.m_entity.Province
            End If


            If Me.m_entity.PersonType.Value = 0 Then
                rdIndividual.PerformClick()
            Else
                rdJuris.PerformClick()
            End If
            If Me.m_entity.Canceled Then
                chkcancel.Checked = True
            Else
                chkcancel.Checked = False
            End If

            If Not m_entity.Originated Then
                btnLock.Visible = False

            ElseIf m_locked Then
                Me.btnLock.Image = Global.My.Resources.Resources.padlock_unlocked

            Else
                Me.btnLock.Image = Global.My.Resources.Resources.padlock_locked

            End If

            Me.txtDCBank.Text = m_entity.DCBank
            txtDCACcount.Text = m_entity.DCAccount

            txtMCBank.Text = m_entity.MCBank
            txtMCAccount.Text = m_entity.MCAccount

            Me.RefreshContact()

            SetStatus()
            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True
        End Sub


        Private Sub btnLockBoq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLock.Click
            If m_locked Then
                m_locked = False
            Else
                m_locked = True
            End If
            m_lockedInit = False
            UpdateEntityProperties()
        End Sub
        Dim m_txtsetting As Boolean = True
        Public Sub ValidateText(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If

            Dim dirtyFlag As Boolean
            Select Case CType(sender, Control).Name.ToLower
                Case "cmbcode"
                    Me.m_entity.Code = cmbCode.Text
                    ComboCodeIndex = cmbCode.SelectedIndex
                    m_oldCode = Me.cmbCode.Text
                    dirtyFlag = True

                Case txtDCBank.Name.ToLower
                    m_entity.DCBank = txtDCBank.Text
                    dirtyFlag = True
                Case txtDCACcount.Name.ToLower
                    m_entity.DCAccount = txtDCACcount.Text
                    dirtyFlag = True
                Case txtMCBank.Name.ToLower
                    m_entity.MCBank = txtMCBank.Text
                    dirtyFlag = True
                Case txtMCAccount.Name.ToLower
                    m_entity.MCAccount = txtMCAccount.Text
                    dirtyFlag = True
                Case "chkcancel"
                    Me.m_entity.Canceled = chkcancel.Checked
                    dirtyFlag = True

                Case "txtname"
                    Me.m_entity.Name = txtName.Text
                    dirtyFlag = True

                Case "txtmobile"
                    Me.m_entity.Mobile = txtMobile.Text
                    dirtyFlag = True

                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True

                Case "txtaltname"
                    Me.m_entity.AlternateName = txtAltName.Text
                    dirtyFlag = True

                Case "txtbillingaddress"
                    Me.m_entity.BillingAddress = txtBillingAddress.Text
                    dirtyFlag = True

                Case "txtaddress"
                    Me.m_entity.Address = txtAddress.Text
                    dirtyFlag = True

                Case "txtphone"
                    Me.m_entity.Phone = txtPhone.Text
                    dirtyFlag = True

                Case "txtcontact"
                    Me.m_entity.Contact = txtContact.Text
                    dirtyFlag = True

                Case "txtfax"
                    Me.m_entity.Fax = txtFax.Text
                    dirtyFlag = True

                Case "txtfaxforexport"
                    Try
                        Me.m_entity.FaxforExport = Regex.Replace(txtFaxforExport.Text, "\D+", "")
                        txtFaxforExport.Text = Me.m_entity.FaxforExport
                    Catch ex As Exception

                    End Try

                    'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                    'msgServ.ShowMessageFormatted("${res:Global.Error.FillWithInteger}")

                    dirtyFlag = True

                Case "txtemail"
                    Me.m_entity.EmailAddress = txtEmail.Text
                    dirtyFlag = True

                Case "txtgroupcode"
                    dirtyFlag = SupplierGroup.GetSupplierGroup(txtGroupCode, txtGroupName, Me.m_entity.Group)

                Case "txtaccountcode"
                    dirtyFlag = Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)

                Case "txtauthorizeamount"
                    If IsNumeric(txtAuthorizeAmount.Text) Then
                        Try
                            Me.m_entity.AuthorizeAmount = CDec(txtAuthorizeAmount.Text)
                        Catch ex As Exception

                        End Try
                    Else
                        Me.m_entity.AuthorizeAmount = 0
                    End If
                    dirtyFlag = True

                Case "txttaxid"
                    Me.m_entity.TaxId = txtTaxID.Text
                    dirtyFlag = True

                Case "txtidno"
                    Me.m_entity.IdNo = txtIdNo.Text
                    dirtyFlag = True

                Case "rdjuris", "rdIndividual"
                    If rdJuris.Checked Then
                        Me.m_entity.PersonType.Value = 1
                    Else
                        Me.m_entity.PersonType.Value = 0
                    End If
                    dirtyFlag = True

                Case "cbmprovince"
                    Me.m_entity.Province = Me.cbmProvince.Text
                    dirtyFlag = True

            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

            CheckFormEnable()

        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If

            Dim dirtyFlag As Boolean
            Select Case CType(sender, Control).Name.ToLower
                Case "cmbcode"
                    Me.m_entity.Code = cmbCode.Text
                    ComboCodeIndex = cmbCode.SelectedIndex
                    m_oldCode = Me.cmbCode.Text
                    dirtyFlag = True

                Case txtDCBank.Name.ToLower
                    m_entity.DCBank = txtDCBank.Text
                    dirtyFlag = True
                Case txtDCACcount.Name.ToLower
                    m_entity.DCAccount = txtDCACcount.Text
                    dirtyFlag = True
                Case txtMCBank.Name.ToLower
                    m_entity.MCBank = txtMCBank.Text
                    dirtyFlag = True
                Case txtMCAccount.Name.ToLower
                    m_entity.MCAccount = txtMCAccount.Text
                    dirtyFlag = True
                Case "chkcancel"
                    Me.m_entity.Canceled = chkcancel.Checked
                    dirtyFlag = True

                Case "txtname"
                    Me.m_entity.Name = txtName.Text
                    dirtyFlag = True

                Case "txtmobile"
                    Me.m_entity.Mobile = txtMobile.Text
                    dirtyFlag = True

                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True

                Case "txtaltname"
                    Me.m_entity.AlternateName = txtAltName.Text
                    dirtyFlag = True

                Case "txtbillingaddress"
                    Me.m_entity.BillingAddress = txtBillingAddress.Text
                    dirtyFlag = True

                Case "txtaddress"
                    Me.m_entity.Address = txtAddress.Text
                    dirtyFlag = True

                Case "txtphone"
                    Me.m_entity.Phone = txtPhone.Text
                    dirtyFlag = True

                Case "txtcontact"
                    Me.m_entity.Contact = txtContact.Text
                    dirtyFlag = True

                Case "txtfax"
                    Me.m_entity.Fax = txtFax.Text
                    dirtyFlag = True

                Case "txtfaxforexport"
                    'If IsNumeric(txtFaxforExport.Text) Then

                    Try

                        Me.m_entity.FaxforExport = Regex.Replace(txtFaxforExport.Text, "\b\D+\b", "")

                    Catch ex As Exception

                    End Try
                    'Else
                    'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                    'msgServ.ShowMessageFormatted("${res:Global.Error.FillWithInteger}")
                    'End If
                    dirtyFlag = True

                Case "txtemail"
                    Me.m_entity.EmailAddress = txtEmail.Text
                    dirtyFlag = True

                Case "txtgroupcode"
                    dirtyFlag = SupplierGroup.GetSupplierGroup(txtGroupCode, txtGroupName, Me.m_entity.Group)

                Case "txtaccountcode"
                    dirtyFlag = Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)

                Case "txtauthorizeamount"
                    If IsNumeric(txtAuthorizeAmount.Text) Then
                        Try
                            Me.m_entity.AuthorizeAmount = CDec(txtAuthorizeAmount.Text)
                        Catch ex As Exception

                        End Try
                    Else
                        Me.m_entity.AuthorizeAmount = 0
                    End If
                    dirtyFlag = True

                Case "txttaxid"
                    Me.m_entity.TaxId = txtTaxID.Text
                    dirtyFlag = True

                Case "txtidno"
                    Me.m_entity.IdNo = txtIdNo.Text
                    dirtyFlag = True

                Case "rdjuris", "rdIndividual"
                    If rdJuris.Checked Then
                        Me.m_entity.PersonType.Value = 1
                    Else
                        Me.m_entity.PersonType.Value = 0
                    End If
                    dirtyFlag = True

                Case "cbmprovince"
                    Me.m_entity.Province = Me.cbmProvince.Text
                    dirtyFlag = True

            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

            CheckFormEnable()

        End Sub
        'Public Function OnlyNumeric(ByVal txt As String) As String
        '    Dim ret As String = ""
        '    Dim arrt() As Char = txt.ToCharArray()
        '    For i As Integer = 1 To txt.Length
        '        arrt(i)
        '    Next

        'End Function
        Public Sub SetStatus()
            MyBase.SetStatusBarMessage()
        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, Supplier)
                'Hack:
                m_locked = True
                m_lockedInit = True
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

#End Region

#Region " Event of Button Controls "
        Private Sub ibtnAddContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddContact.Click
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity Is Nothing Then
                Return
            End If
            Dim scColl As SupplierContactCollection = Me.m_entity.ContactCollection
            Dim sc As New SupplierContact
            scColl.Add(sc)
            RefreshContact()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ibtnDelContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelContact.Click
            Dim item As SupplierContact = Me.CurrentContact
            If item Is Nothing Then
                Return
            End If
            Dim scColl As SupplierContactCollection = Me.m_entity.ContactCollection
            scColl.Remove(item)
            RefreshContact()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub btnAuxDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuxDetail.Click
            Dim myAuxPanel As New Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView
            myAuxPanel.Entity = Me.m_entity
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(myAuxPanel)
            If myDialog.ShowDialog() = DialogResult.Cancel Then
                Me.WorkbenchWindow.ViewContent.IsDirty = False
            End If
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New SupplierGroup).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtgroupcode", "txtgroupname"
                                Return True
                        End Select
                    End If
                End If
                If data.GetDataPresent((New Account).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtaccountcode", "txtaccountname"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New SupplierGroup).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New SupplierGroup).FullClassName))
                Dim entity As New SupplierGroup(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtgroupcode", "txtgroupname"
                            Me.SetSupplierGroupDialog(entity)
                    End Select
                End If
            End If
            If data.GetDataPresent((New Account).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
                Dim entity As New Account(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtaccountcode", "txtaccountname"
                            Me.SetAccountDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Event of Button Controls"
        ' Open Entity panels
        Private Sub btnGroupEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New SupplierGroup)
        End Sub

        Private Sub btnAccountEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccountEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Account)
        End Sub
        ' Supplier Group
        Private Sub btnGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSupplierGroupDialog)
        End Sub
        Private Sub SetSupplierGroupDialog(ByVal e As ISimpleEntity)
            Me.txtGroupCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or SupplierGroup.GetSupplierGroup(txtGroupCode, txtGroupName, Me.m_entity.Group)
        End Sub
        ' Account
        Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountDialog)
        End Sub
        Private Sub SetAccountDialog(ByVal e As ISimpleEntity)
            Me.txtAccountCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty Or _
                Account.GetAccount(txtAccountCode, txtAccountName, Me.m_entity.Account)
        End Sub
#End Region

#Region " AutoGenCode "
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_oldCode As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
                'Me.Validator.SetRequired(Me.txtCode, False)
                'Me.ErrorProvider1.SetError(Me.txtCode, "")
                'Me.txtCode.ReadOnly = True
                Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
                cmbCode.SelectedIndex = ComboCodeIndex
                m_oldCode = Me.cmbCode.Text
                'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
                'Hack: set Code เป็น "" เอง
                'Me.m_entity.Code = ""
                Me.m_entity.Code = m_oldCode
                Me.m_entity.AutoGen = True
            Else
                'Me.Validator.SetRequired(Me.txtCode, True)
                Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
                Me.cmbCode.Text = m_oldCode
                'Me.txtCode.ReadOnly = False
                Me.m_entity.AutoGen = False
            End If
        End Sub
#End Region

        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            MyBase.NotifyAfterSave(successful)
            For Each myView As IViewContent In WorkbenchSingleton.Workbench.ViewContentCollection
                For Each o As Object In myView.WorkbenchWindow.SubViewContents
                    If TypeOf o Is ICanRefreshAutoComplete Then
                        CType(o, ICanRefreshAutoComplete).RefreshAutoComplete(10)
                    End If
                Next
            Next
        End Sub
    End Class
End Namespace
