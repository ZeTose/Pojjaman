Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels

  Public Class SupplierExportDetailView
    Inherits AbstractEntityDetailPanelView
    'Implements IReversibleEntityProperty
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
    Friend WithEvents grbExportVatDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblTitleName As System.Windows.Forms.Label
    Friend WithEvents lblPhoneNumber As System.Windows.Forms.Label
    Friend WithEvents lblPostCode As System.Windows.Forms.Label
    Friend WithEvents lblProvince As System.Windows.Forms.Label
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents lblTambon As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents lblSubstreet As System.Windows.Forms.Label
    Friend WithEvents lblMoo As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblFloor As System.Windows.Forms.Label
    Friend WithEvents lblRoomNo As System.Windows.Forms.Label
    Friend WithEvents lblVillageName As System.Windows.Forms.Label
    Friend WithEvents lblBuildingName As System.Windows.Forms.Label
    Friend WithEvents lblBranchId As System.Windows.Forms.Label
    Friend WithEvents lblTaxIdNo As System.Windows.Forms.Label
    Friend WithEvents lblIdNo As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents txtTitleName As System.Windows.Forms.TextBox
    Friend WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPostCode As System.Windows.Forms.TextBox
    Friend WithEvents txtProvince As System.Windows.Forms.TextBox
    Friend WithEvents txtDistrict As System.Windows.Forms.TextBox
    Friend WithEvents txtTambon As System.Windows.Forms.TextBox
    Friend WithEvents txtStreet As System.Windows.Forms.TextBox
    Friend WithEvents txtSubstreet As System.Windows.Forms.TextBox
    Friend WithEvents txtMoo As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtFloor As System.Windows.Forms.TextBox
    Friend WithEvents txtRoomNo As System.Windows.Forms.TextBox
    Friend WithEvents txtVillageName As System.Windows.Forms.TextBox
    Friend WithEvents txtBuildingName As System.Windows.Forms.TextBox
    Friend WithEvents txtBranchId As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxIdNo As System.Windows.Forms.TextBox
    Friend WithEvents txtIdNo As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.grbExportVatDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblTitleName = New System.Windows.Forms.Label()
      Me.lblPhoneNumber = New System.Windows.Forms.Label()
      Me.lblPostCode = New System.Windows.Forms.Label()
      Me.lblProvince = New System.Windows.Forms.Label()
      Me.lblDistrict = New System.Windows.Forms.Label()
      Me.lblTambon = New System.Windows.Forms.Label()
      Me.lblStreet = New System.Windows.Forms.Label()
      Me.lblSubstreet = New System.Windows.Forms.Label()
      Me.lblMoo = New System.Windows.Forms.Label()
      Me.lblAddress = New System.Windows.Forms.Label()
      Me.lblFloor = New System.Windows.Forms.Label()
      Me.lblRoomNo = New System.Windows.Forms.Label()
      Me.lblVillageName = New System.Windows.Forms.Label()
      Me.lblBuildingName = New System.Windows.Forms.Label()
      Me.lblBranchId = New System.Windows.Forms.Label()
      Me.lblTaxIdNo = New System.Windows.Forms.Label()
      Me.lblIdNo = New System.Windows.Forms.Label()
      Me.lblLastName = New System.Windows.Forms.Label()
      Me.lblFirstName = New System.Windows.Forms.Label()
      Me.txtTitleName = New System.Windows.Forms.TextBox()
      Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
      Me.txtPostCode = New System.Windows.Forms.TextBox()
      Me.txtProvince = New System.Windows.Forms.TextBox()
      Me.txtDistrict = New System.Windows.Forms.TextBox()
      Me.txtTambon = New System.Windows.Forms.TextBox()
      Me.txtStreet = New System.Windows.Forms.TextBox()
      Me.txtSubstreet = New System.Windows.Forms.TextBox()
      Me.txtMoo = New System.Windows.Forms.TextBox()
      Me.txtAddress = New System.Windows.Forms.TextBox()
      Me.txtFloor = New System.Windows.Forms.TextBox()
      Me.txtRoomNo = New System.Windows.Forms.TextBox()
      Me.txtVillageName = New System.Windows.Forms.TextBox()
      Me.txtBuildingName = New System.Windows.Forms.TextBox()
      Me.txtBranchId = New System.Windows.Forms.TextBox()
      Me.txtTaxIdNo = New System.Windows.Forms.TextBox()
      Me.txtIdNo = New System.Windows.Forms.TextBox()
      Me.txtLastName = New System.Windows.Forms.TextBox()
      Me.txtFirstName = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbExportVatDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbExportVatDetail
      '
      Me.grbExportVatDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbExportVatDetail.Controls.Add(Me.lblTitleName)
      Me.grbExportVatDetail.Controls.Add(Me.lblPhoneNumber)
      Me.grbExportVatDetail.Controls.Add(Me.lblPostCode)
      Me.grbExportVatDetail.Controls.Add(Me.lblProvince)
      Me.grbExportVatDetail.Controls.Add(Me.lblDistrict)
      Me.grbExportVatDetail.Controls.Add(Me.lblTambon)
      Me.grbExportVatDetail.Controls.Add(Me.lblStreet)
      Me.grbExportVatDetail.Controls.Add(Me.lblSubstreet)
      Me.grbExportVatDetail.Controls.Add(Me.lblMoo)
      Me.grbExportVatDetail.Controls.Add(Me.lblAddress)
      Me.grbExportVatDetail.Controls.Add(Me.lblFloor)
      Me.grbExportVatDetail.Controls.Add(Me.lblRoomNo)
      Me.grbExportVatDetail.Controls.Add(Me.lblVillageName)
      Me.grbExportVatDetail.Controls.Add(Me.lblBuildingName)
      Me.grbExportVatDetail.Controls.Add(Me.lblBranchId)
      Me.grbExportVatDetail.Controls.Add(Me.lblTaxIdNo)
      Me.grbExportVatDetail.Controls.Add(Me.lblIdNo)
      Me.grbExportVatDetail.Controls.Add(Me.lblLastName)
      Me.grbExportVatDetail.Controls.Add(Me.lblFirstName)
      Me.grbExportVatDetail.Controls.Add(Me.txtTitleName)
      Me.grbExportVatDetail.Controls.Add(Me.txtPhoneNumber)
      Me.grbExportVatDetail.Controls.Add(Me.txtPostCode)
      Me.grbExportVatDetail.Controls.Add(Me.txtProvince)
      Me.grbExportVatDetail.Controls.Add(Me.txtDistrict)
      Me.grbExportVatDetail.Controls.Add(Me.txtTambon)
      Me.grbExportVatDetail.Controls.Add(Me.txtStreet)
      Me.grbExportVatDetail.Controls.Add(Me.txtSubstreet)
      Me.grbExportVatDetail.Controls.Add(Me.txtMoo)
      Me.grbExportVatDetail.Controls.Add(Me.txtAddress)
      Me.grbExportVatDetail.Controls.Add(Me.txtFloor)
      Me.grbExportVatDetail.Controls.Add(Me.txtRoomNo)
      Me.grbExportVatDetail.Controls.Add(Me.txtVillageName)
      Me.grbExportVatDetail.Controls.Add(Me.txtBuildingName)
      Me.grbExportVatDetail.Controls.Add(Me.txtBranchId)
      Me.grbExportVatDetail.Controls.Add(Me.txtTaxIdNo)
      Me.grbExportVatDetail.Controls.Add(Me.txtIdNo)
      Me.grbExportVatDetail.Controls.Add(Me.txtLastName)
      Me.grbExportVatDetail.Controls.Add(Me.txtFirstName)
      Me.grbExportVatDetail.Controls.Add(Me.lblCode)
      Me.grbExportVatDetail.Controls.Add(Me.txtCode)
      Me.grbExportVatDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbExportVatDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbExportVatDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbExportVatDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbExportVatDetail.Name = "grbExportVatDetail"
      Me.grbExportVatDetail.Size = New System.Drawing.Size(840, 393)
      Me.grbExportVatDetail.TabIndex = 0
      Me.grbExportVatDetail.TabStop = False
      Me.grbExportVatDetail.Text = "ข้อมูลหลัก"
      '
      'lblTitleName
      '
      Me.lblTitleName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTitleName.ForeColor = System.Drawing.Color.Black
      Me.lblTitleName.Location = New System.Drawing.Point(35, 58)
      Me.lblTitleName.Name = "lblTitleName"
      Me.lblTitleName.Size = New System.Drawing.Size(104, 18)
      Me.lblTitleName.TabIndex = 4
      Me.lblTitleName.Text = "คำนำหน้า:"
      Me.lblTitleName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPhoneNumber
      '
      Me.lblPhoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPhoneNumber.ForeColor = System.Drawing.Color.Black
      Me.lblPhoneNumber.Location = New System.Drawing.Point(432, 177)
      Me.lblPhoneNumber.Name = "lblPhoneNumber"
      Me.lblPhoneNumber.Size = New System.Drawing.Size(104, 18)
      Me.lblPhoneNumber.TabIndex = 4
      Me.lblPhoneNumber.Text = "โทรศัพท์:"
      Me.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPostCode
      '
      Me.lblPostCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPostCode.ForeColor = System.Drawing.Color.Black
      Me.lblPostCode.Location = New System.Drawing.Point(432, 153)
      Me.lblPostCode.Name = "lblPostCode"
      Me.lblPostCode.Size = New System.Drawing.Size(104, 18)
      Me.lblPostCode.TabIndex = 4
      Me.lblPostCode.Text = "รหัสไปรษณีย์:"
      Me.lblPostCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblProvince
      '
      Me.lblProvince.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProvince.ForeColor = System.Drawing.Color.Black
      Me.lblProvince.Location = New System.Drawing.Point(432, 129)
      Me.lblProvince.Name = "lblProvince"
      Me.lblProvince.Size = New System.Drawing.Size(104, 18)
      Me.lblProvince.TabIndex = 4
      Me.lblProvince.Text = "จังหวัด:"
      Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDistrict
      '
      Me.lblDistrict.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDistrict.ForeColor = System.Drawing.Color.Black
      Me.lblDistrict.Location = New System.Drawing.Point(432, 105)
      Me.lblDistrict.Name = "lblDistrict"
      Me.lblDistrict.Size = New System.Drawing.Size(104, 18)
      Me.lblDistrict.TabIndex = 4
      Me.lblDistrict.Text = "อำเภอ/เขต:"
      Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTambon
      '
      Me.lblTambon.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTambon.ForeColor = System.Drawing.Color.Black
      Me.lblTambon.Location = New System.Drawing.Point(432, 81)
      Me.lblTambon.Name = "lblTambon"
      Me.lblTambon.Size = New System.Drawing.Size(104, 18)
      Me.lblTambon.TabIndex = 4
      Me.lblTambon.Text = "ตำบล/แขวง:"
      Me.lblTambon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStreet
      '
      Me.lblStreet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStreet.ForeColor = System.Drawing.Color.Black
      Me.lblStreet.Location = New System.Drawing.Point(35, 357)
      Me.lblStreet.Name = "lblStreet"
      Me.lblStreet.Size = New System.Drawing.Size(104, 18)
      Me.lblStreet.TabIndex = 4
      Me.lblStreet.Text = "ถนน:"
      Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSubstreet
      '
      Me.lblSubstreet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubstreet.ForeColor = System.Drawing.Color.Black
      Me.lblSubstreet.Location = New System.Drawing.Point(35, 334)
      Me.lblSubstreet.Name = "lblSubstreet"
      Me.lblSubstreet.Size = New System.Drawing.Size(104, 18)
      Me.lblSubstreet.TabIndex = 4
      Me.lblSubstreet.Text = "ตรอก/ซอย:"
      Me.lblSubstreet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMoo
      '
      Me.lblMoo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMoo.ForeColor = System.Drawing.Color.Black
      Me.lblMoo.Location = New System.Drawing.Point(35, 311)
      Me.lblMoo.Name = "lblMoo"
      Me.lblMoo.Size = New System.Drawing.Size(104, 18)
      Me.lblMoo.TabIndex = 4
      Me.lblMoo.Text = "หมู่ที่:"
      Me.lblMoo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAddress
      '
      Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAddress.ForeColor = System.Drawing.Color.Black
      Me.lblAddress.Location = New System.Drawing.Point(35, 288)
      Me.lblAddress.Name = "lblAddress"
      Me.lblAddress.Size = New System.Drawing.Size(104, 18)
      Me.lblAddress.TabIndex = 4
      Me.lblAddress.Text = "บ้านเลขที่:"
      Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFloor
      '
      Me.lblFloor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFloor.ForeColor = System.Drawing.Color.Black
      Me.lblFloor.Location = New System.Drawing.Point(35, 265)
      Me.lblFloor.Name = "lblFloor"
      Me.lblFloor.Size = New System.Drawing.Size(104, 18)
      Me.lblFloor.TabIndex = 4
      Me.lblFloor.Text = "ชั้นที่:"
      Me.lblFloor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblRoomNo
      '
      Me.lblRoomNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRoomNo.ForeColor = System.Drawing.Color.Black
      Me.lblRoomNo.Location = New System.Drawing.Point(35, 242)
      Me.lblRoomNo.Name = "lblRoomNo"
      Me.lblRoomNo.Size = New System.Drawing.Size(104, 18)
      Me.lblRoomNo.TabIndex = 4
      Me.lblRoomNo.Text = "ห้องเลขที่:"
      Me.lblRoomNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblVillageName
      '
      Me.lblVillageName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblVillageName.ForeColor = System.Drawing.Color.Black
      Me.lblVillageName.Location = New System.Drawing.Point(35, 219)
      Me.lblVillageName.Name = "lblVillageName"
      Me.lblVillageName.Size = New System.Drawing.Size(104, 18)
      Me.lblVillageName.TabIndex = 4
      Me.lblVillageName.Text = "ชื่อหมู่บ้าน:"
      Me.lblVillageName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBuildingName
      '
      Me.lblBuildingName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuildingName.ForeColor = System.Drawing.Color.Black
      Me.lblBuildingName.Location = New System.Drawing.Point(35, 196)
      Me.lblBuildingName.Name = "lblBuildingName"
      Me.lblBuildingName.Size = New System.Drawing.Size(104, 18)
      Me.lblBuildingName.TabIndex = 4
      Me.lblBuildingName.Text = "ชื่ออาคาร:"
      Me.lblBuildingName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBranchId
      '
      Me.lblBranchId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBranchId.ForeColor = System.Drawing.Color.Black
      Me.lblBranchId.Location = New System.Drawing.Point(35, 173)
      Me.lblBranchId.Name = "lblBranchId"
      Me.lblBranchId.Size = New System.Drawing.Size(104, 18)
      Me.lblBranchId.TabIndex = 4
      Me.lblBranchId.Text = "สาขาที่:"
      Me.lblBranchId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxIdNo
      '
      Me.lblTaxIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxIdNo.ForeColor = System.Drawing.Color.Black
      Me.lblTaxIdNo.Location = New System.Drawing.Point(9, 150)
      Me.lblTaxIdNo.Name = "lblTaxIdNo"
      Me.lblTaxIdNo.Size = New System.Drawing.Size(130, 18)
      Me.lblTaxIdNo.TabIndex = 4
      Me.lblTaxIdNo.Text = "เลขประจำตัวผู้เสียภาษี:"
      Me.lblTaxIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblIdNo
      '
      Me.lblIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblIdNo.ForeColor = System.Drawing.Color.Black
      Me.lblIdNo.Location = New System.Drawing.Point(6, 127)
      Me.lblIdNo.Name = "lblIdNo"
      Me.lblIdNo.Size = New System.Drawing.Size(133, 18)
      Me.lblIdNo.TabIndex = 4
      Me.lblIdNo.Text = "เลขประจำตัวประชาชน:"
      Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLastName
      '
      Me.lblLastName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLastName.ForeColor = System.Drawing.Color.Black
      Me.lblLastName.Location = New System.Drawing.Point(35, 104)
      Me.lblLastName.Name = "lblLastName"
      Me.lblLastName.Size = New System.Drawing.Size(104, 18)
      Me.lblLastName.TabIndex = 4
      Me.lblLastName.Text = "นามสกุล:"
      Me.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFirstName
      '
      Me.lblFirstName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFirstName.ForeColor = System.Drawing.Color.Black
      Me.lblFirstName.Location = New System.Drawing.Point(35, 81)
      Me.lblFirstName.Name = "lblFirstName"
      Me.lblFirstName.Size = New System.Drawing.Size(104, 18)
      Me.lblFirstName.TabIndex = 4
      Me.lblFirstName.Text = "ชื่อผู้มีเงินได้:"
      Me.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTitleName
      '
      Me.Validator.SetDataType(Me.txtTitleName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTitleName, "")
      Me.txtTitleName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTitleName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTitleName, System.Drawing.Color.Empty)
      Me.txtTitleName.Location = New System.Drawing.Point(139, 58)
      Me.txtTitleName.MaxLength = 100
      Me.Validator.SetMaxValue(Me.txtTitleName, "")
      Me.Validator.SetMinValue(Me.txtTitleName, "")
      Me.txtTitleName.Name = "txtTitleName"
      Me.Validator.SetRegularExpression(Me.txtTitleName, "")
      Me.Validator.SetRequired(Me.txtTitleName, False)
      Me.txtTitleName.Size = New System.Drawing.Size(288, 21)
      Me.txtTitleName.TabIndex = 2
      '
      'txtPhoneNumber
      '
      Me.Validator.SetDataType(Me.txtPhoneNumber, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPhoneNumber, "")
      Me.txtPhoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPhoneNumber, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPhoneNumber, System.Drawing.Color.Empty)
      Me.txtPhoneNumber.Location = New System.Drawing.Point(536, 177)
      Me.txtPhoneNumber.MaxLength = 30
      Me.Validator.SetMaxValue(Me.txtPhoneNumber, "")
      Me.Validator.SetMinValue(Me.txtPhoneNumber, "")
      Me.txtPhoneNumber.Name = "txtPhoneNumber"
      Me.Validator.SetRegularExpression(Me.txtPhoneNumber, "")
      Me.Validator.SetRequired(Me.txtPhoneNumber, False)
      Me.txtPhoneNumber.Size = New System.Drawing.Size(288, 21)
      Me.txtPhoneNumber.TabIndex = 20
      '
      'txtPostCode
      '
      Me.Validator.SetDataType(Me.txtPostCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPostCode, "")
      Me.txtPostCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPostCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPostCode, System.Drawing.Color.Empty)
      Me.txtPostCode.Location = New System.Drawing.Point(536, 153)
      Me.txtPostCode.MaxLength = 5
      Me.Validator.SetMaxValue(Me.txtPostCode, "")
      Me.Validator.SetMinValue(Me.txtPostCode, "")
      Me.txtPostCode.Name = "txtPostCode"
      Me.Validator.SetRegularExpression(Me.txtPostCode, "")
      Me.Validator.SetRequired(Me.txtPostCode, False)
      Me.txtPostCode.Size = New System.Drawing.Size(288, 21)
      Me.txtPostCode.TabIndex = 19
      '
      'txtProvince
      '
      Me.Validator.SetDataType(Me.txtProvince, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProvince, "")
      Me.txtProvince.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtProvince, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProvince, System.Drawing.Color.Empty)
      Me.txtProvince.Location = New System.Drawing.Point(536, 129)
      Me.txtProvince.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtProvince, "")
      Me.Validator.SetMinValue(Me.txtProvince, "")
      Me.txtProvince.Name = "txtProvince"
      Me.Validator.SetRegularExpression(Me.txtProvince, "")
      Me.Validator.SetRequired(Me.txtProvince, False)
      Me.txtProvince.Size = New System.Drawing.Size(288, 21)
      Me.txtProvince.TabIndex = 18
      '
      'txtDistrict
      '
      Me.Validator.SetDataType(Me.txtDistrict, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDistrict, "")
      Me.txtDistrict.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDistrict, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDistrict, System.Drawing.Color.Empty)
      Me.txtDistrict.Location = New System.Drawing.Point(536, 105)
      Me.txtDistrict.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtDistrict, "")
      Me.Validator.SetMinValue(Me.txtDistrict, "")
      Me.txtDistrict.Name = "txtDistrict"
      Me.Validator.SetRegularExpression(Me.txtDistrict, "")
      Me.Validator.SetRequired(Me.txtDistrict, False)
      Me.txtDistrict.Size = New System.Drawing.Size(288, 21)
      Me.txtDistrict.TabIndex = 17
      '
      'txtTambon
      '
      Me.Validator.SetDataType(Me.txtTambon, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTambon, "")
      Me.txtTambon.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTambon, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTambon, System.Drawing.Color.Empty)
      Me.txtTambon.Location = New System.Drawing.Point(536, 81)
      Me.txtTambon.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtTambon, "")
      Me.Validator.SetMinValue(Me.txtTambon, "")
      Me.txtTambon.Name = "txtTambon"
      Me.Validator.SetRegularExpression(Me.txtTambon, "")
      Me.Validator.SetRequired(Me.txtTambon, False)
      Me.txtTambon.Size = New System.Drawing.Size(288, 21)
      Me.txtTambon.TabIndex = 16
      '
      'txtStreet
      '
      Me.Validator.SetDataType(Me.txtStreet, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtStreet, "")
      Me.txtStreet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtStreet, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtStreet, System.Drawing.Color.Empty)
      Me.txtStreet.Location = New System.Drawing.Point(139, 357)
      Me.txtStreet.MaxLength = 100
      Me.Validator.SetMaxValue(Me.txtStreet, "")
      Me.Validator.SetMinValue(Me.txtStreet, "")
      Me.txtStreet.Name = "txtStreet"
      Me.Validator.SetRegularExpression(Me.txtStreet, "")
      Me.Validator.SetRequired(Me.txtStreet, False)
      Me.txtStreet.Size = New System.Drawing.Size(288, 21)
      Me.txtStreet.TabIndex = 15
      '
      'txtSubstreet
      '
      Me.Validator.SetDataType(Me.txtSubstreet, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubstreet, "")
      Me.txtSubstreet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSubstreet, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubstreet, System.Drawing.Color.Empty)
      Me.txtSubstreet.Location = New System.Drawing.Point(139, 334)
      Me.txtSubstreet.MaxLength = 100
      Me.Validator.SetMaxValue(Me.txtSubstreet, "")
      Me.Validator.SetMinValue(Me.txtSubstreet, "")
      Me.txtSubstreet.Name = "txtSubstreet"
      Me.Validator.SetRegularExpression(Me.txtSubstreet, "")
      Me.Validator.SetRequired(Me.txtSubstreet, False)
      Me.txtSubstreet.Size = New System.Drawing.Size(288, 21)
      Me.txtSubstreet.TabIndex = 14
      '
      'txtMoo
      '
      Me.Validator.SetDataType(Me.txtMoo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtMoo, "")
      Me.txtMoo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtMoo, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMoo, System.Drawing.Color.Empty)
      Me.txtMoo.Location = New System.Drawing.Point(139, 311)
      Me.txtMoo.MaxLength = 3
      Me.Validator.SetMaxValue(Me.txtMoo, "")
      Me.Validator.SetMinValue(Me.txtMoo, "")
      Me.txtMoo.Name = "txtMoo"
      Me.Validator.SetRegularExpression(Me.txtMoo, "")
      Me.Validator.SetRequired(Me.txtMoo, False)
      Me.txtMoo.Size = New System.Drawing.Size(288, 21)
      Me.txtMoo.TabIndex = 13
      '
      'txtAddress
      '
      Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAddress, "")
      Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.txtAddress.Location = New System.Drawing.Point(139, 288)
      Me.txtAddress.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtAddress, "")
      Me.Validator.SetMinValue(Me.txtAddress, "")
      Me.txtAddress.Name = "txtAddress"
      Me.Validator.SetRegularExpression(Me.txtAddress, "")
      Me.Validator.SetRequired(Me.txtAddress, False)
      Me.txtAddress.Size = New System.Drawing.Size(288, 21)
      Me.txtAddress.TabIndex = 12
      '
      'txtFloor
      '
      Me.Validator.SetDataType(Me.txtFloor, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFloor, "")
      Me.txtFloor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFloor, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFloor, System.Drawing.Color.Empty)
      Me.txtFloor.Location = New System.Drawing.Point(139, 265)
      Me.txtFloor.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtFloor, "")
      Me.Validator.SetMinValue(Me.txtFloor, "")
      Me.txtFloor.Name = "txtFloor"
      Me.Validator.SetRegularExpression(Me.txtFloor, "")
      Me.Validator.SetRequired(Me.txtFloor, False)
      Me.txtFloor.Size = New System.Drawing.Size(288, 21)
      Me.txtFloor.TabIndex = 11
      '
      'txtRoomNo
      '
      Me.Validator.SetDataType(Me.txtRoomNo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRoomNo, "")
      Me.txtRoomNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtRoomNo, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRoomNo, System.Drawing.Color.Empty)
      Me.txtRoomNo.Location = New System.Drawing.Point(139, 242)
      Me.txtRoomNo.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtRoomNo, "")
      Me.Validator.SetMinValue(Me.txtRoomNo, "")
      Me.txtRoomNo.Name = "txtRoomNo"
      Me.Validator.SetRegularExpression(Me.txtRoomNo, "")
      Me.Validator.SetRequired(Me.txtRoomNo, False)
      Me.txtRoomNo.Size = New System.Drawing.Size(288, 21)
      Me.txtRoomNo.TabIndex = 10
      '
      'txtVillageName
      '
      Me.Validator.SetDataType(Me.txtVillageName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtVillageName, "")
      Me.txtVillageName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtVillageName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtVillageName, System.Drawing.Color.Empty)
      Me.txtVillageName.Location = New System.Drawing.Point(139, 219)
      Me.txtVillageName.MaxLength = 100
      Me.Validator.SetMaxValue(Me.txtVillageName, "")
      Me.Validator.SetMinValue(Me.txtVillageName, "")
      Me.txtVillageName.Name = "txtVillageName"
      Me.Validator.SetRegularExpression(Me.txtVillageName, "")
      Me.Validator.SetRequired(Me.txtVillageName, False)
      Me.txtVillageName.Size = New System.Drawing.Size(288, 21)
      Me.txtVillageName.TabIndex = 9
      '
      'txtBuildingName
      '
      Me.Validator.SetDataType(Me.txtBuildingName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuildingName, "")
      Me.txtBuildingName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuildingName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuildingName, System.Drawing.Color.Empty)
      Me.txtBuildingName.Location = New System.Drawing.Point(139, 196)
      Me.txtBuildingName.MaxLength = 40
      Me.Validator.SetMaxValue(Me.txtBuildingName, "")
      Me.Validator.SetMinValue(Me.txtBuildingName, "")
      Me.txtBuildingName.Name = "txtBuildingName"
      Me.Validator.SetRegularExpression(Me.txtBuildingName, "")
      Me.Validator.SetRequired(Me.txtBuildingName, False)
      Me.txtBuildingName.Size = New System.Drawing.Size(288, 21)
      Me.txtBuildingName.TabIndex = 8
      '
      'txtBranchId
      '
      Me.Validator.SetDataType(Me.txtBranchId, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBranchId, "")
      Me.txtBranchId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBranchId, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBranchId, System.Drawing.Color.Empty)
      Me.txtBranchId.Location = New System.Drawing.Point(139, 173)
      Me.txtBranchId.MaxLength = 5
      Me.Validator.SetMaxValue(Me.txtBranchId, "")
      Me.Validator.SetMinValue(Me.txtBranchId, "")
      Me.txtBranchId.Name = "txtBranchId"
      Me.Validator.SetRegularExpression(Me.txtBranchId, "")
      Me.Validator.SetRequired(Me.txtBranchId, False)
      Me.txtBranchId.Size = New System.Drawing.Size(288, 21)
      Me.txtBranchId.TabIndex = 7
      '
      'txtTaxIdNo
      '
      Me.Validator.SetDataType(Me.txtTaxIdNo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxIdNo, "")
      Me.txtTaxIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTaxIdNo, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxIdNo, System.Drawing.Color.Empty)
      Me.txtTaxIdNo.Location = New System.Drawing.Point(139, 150)
      Me.txtTaxIdNo.MaxLength = 13
      Me.Validator.SetMaxValue(Me.txtTaxIdNo, "")
      Me.Validator.SetMinValue(Me.txtTaxIdNo, "")
      Me.txtTaxIdNo.Name = "txtTaxIdNo"
      Me.Validator.SetRegularExpression(Me.txtTaxIdNo, "")
      Me.Validator.SetRequired(Me.txtTaxIdNo, False)
      Me.txtTaxIdNo.Size = New System.Drawing.Size(288, 21)
      Me.txtTaxIdNo.TabIndex = 6
      '
      'txtIdNo
      '
      Me.Validator.SetDataType(Me.txtIdNo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtIdNo, "")
      Me.txtIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtIdNo, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtIdNo, System.Drawing.Color.Empty)
      Me.txtIdNo.Location = New System.Drawing.Point(139, 127)
      Me.txtIdNo.MaxLength = 13
      Me.Validator.SetMaxValue(Me.txtIdNo, "")
      Me.Validator.SetMinValue(Me.txtIdNo, "")
      Me.txtIdNo.Name = "txtIdNo"
      Me.Validator.SetRegularExpression(Me.txtIdNo, "")
      Me.Validator.SetRequired(Me.txtIdNo, False)
      Me.txtIdNo.Size = New System.Drawing.Size(288, 21)
      Me.txtIdNo.TabIndex = 5
      '
      'txtLastName
      '
      Me.Validator.SetDataType(Me.txtLastName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLastName, "")
      Me.txtLastName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLastName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLastName, System.Drawing.Color.Empty)
      Me.txtLastName.Location = New System.Drawing.Point(139, 104)
      Me.txtLastName.MaxLength = 160
      Me.Validator.SetMaxValue(Me.txtLastName, "")
      Me.Validator.SetMinValue(Me.txtLastName, "")
      Me.txtLastName.Name = "txtLastName"
      Me.Validator.SetRegularExpression(Me.txtLastName, "")
      Me.Validator.SetRequired(Me.txtLastName, False)
      Me.txtLastName.Size = New System.Drawing.Size(288, 21)
      Me.txtLastName.TabIndex = 4
      '
      'txtFirstName
      '
      Me.Validator.SetDataType(Me.txtFirstName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFirstName, "")
      Me.txtFirstName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFirstName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtFirstName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtFirstName, System.Drawing.Color.Empty)
      Me.txtFirstName.Location = New System.Drawing.Point(139, 81)
      Me.txtFirstName.MaxLength = 160
      Me.Validator.SetMaxValue(Me.txtFirstName, "")
      Me.Validator.SetMinValue(Me.txtFirstName, "")
      Me.txtFirstName.Name = "txtFirstName"
      Me.Validator.SetRegularExpression(Me.txtFirstName, "")
      Me.Validator.SetRequired(Me.txtFirstName, False)
      Me.txtFirstName.Size = New System.Drawing.Size(288, 21)
      Me.txtFirstName.TabIndex = 3
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(35, 35)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 2
      Me.lblCode.Text = "รหัส:"
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
      Me.txtCode.Location = New System.Drawing.Point(139, 35)
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.txtCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(128, 21)
      Me.txtCode.TabIndex = 1
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnOk.ForeColor = System.Drawing.Color.Black
      Me.btnOk.Location = New System.Drawing.Point(632, 407)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(96, 24)
      Me.btnOk.TabIndex = 21
      Me.btnOk.Text = "OK"
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.Black
      Me.btnCancel.Location = New System.Drawing.Point(736, 407)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(96, 24)
      Me.btnCancel.TabIndex = 22
      Me.btnCancel.Text = "Cancel"
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
      'SupplierExportDetailView
      '
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.grbExportVatDetail)
      Me.Controls.Add(Me.btnCancel)
      Me.Name = "SupplierExportDetailView"
      Me.Size = New System.Drawing.Size(859, 442)
      Me.grbExportVatDetail.ResumeLayout(False)
      Me.grbExportVatDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblFirstName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCode}")

      'Me.lblbirthDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblbirthDate}")
      'Me.Validator.SetDisplayName(Me.txtbirthdate, lblbirthDate.Text)

      'Me.lblHomePage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblHomePage}")
      'Me.Validator.SetDisplayName(Me.txtHomePage, lblHomePage.Text)

      'Me.lblLastContactDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblLastContactDate}")
      'Me.Validator.SetDisplayName(Me.txtLastContactDate, Me.lblLastContactDate.Text)

      'Me.lblLastPayDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblLastPayDate}")
      'Me.Validator.SetDisplayName(Me.txtLastPaydate, Me.lblLastPayDate.Text)

      'Me.lblSummaryDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblSummaryDiscount}")
      'Me.Validator.SetDisplayName(Me.txtSummaryDiscount, Me.lblSummaryDiscount.Text)

      'Me.lblDetailDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblDetailDiscount}")
      'Me.Validator.SetDisplayName(Me.txtDetailDiscount, Me.lblDetailDiscount.Text)

      'Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Global.TaxRateText}")
      'Me.Validator.SetDisplayName(Me.txtTaxRate, Me.lblTaxRate.Text)

      'Me.lblCreditType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditType}")

      'Me.lblCreditPeriod.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditPeriod}")
      'Me.Validator.SetDisplayName(Me.txtCreditPeriod, Me.lblCreditPeriod.Text)

      'Me.lblCreditPeriodUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditPeriodUnit}")

      'Me.lblCreditAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditAmount}")
      'Me.Validator.SetDisplayName(Me.txtCreditAmount, Me.lblCreditAmount.Text)

      'Me.lblCreditPeriodFromTransport.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditPeriodFromTransport}")
      'Me.Validator.SetDisplayName(Me.txtCreditPeriodFromTransport, Me.lblCreditPeriodFromTransport.Text)

      Me.btnOk.Text = Me.StringParserService.Parse("${res:Global.OKButtonText}")
      Me.btnCancel.Text = Me.StringParserService.Parse("${res:Global.CancelButtonText}")

      'Me.btnShowMap.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.btnShowMap}")
      'Me.btnLoadMap.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.btnLoadMap}")
      'Me.btnLoadImage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.btnLoadImage}")

      'Me.lblReceiveDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblReceiveDate}")
      'Me.Validator.SetDisplayName(Me.txtReceiveDates, Me.lblReceiveDate.Text)

      'Me.lblReceiveWeek.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblReceiveWeek}")
      'Me.Validator.SetDisplayName(Me.txtReceiveWeeks, Me.lblReceiveWeek.Text)

      'Me.lblReceiveDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblReceiveDay}")
      'Me.Validator.SetDisplayName(Me.txtReceiveDays, Me.lblReceiveDay.Text)

      'Me.lblBillRecWeek.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblBillRecWeek}")
      'Me.Validator.SetDisplayName(Me.txtBillRecWeeks, Me.txtBillRecWeeks.Text)

      'Me.lblBillRecDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblBillRecDate}")
      'Me.Validator.SetDisplayName(Me.txtBillRecDates, Me.txtBillRecDates.Text)

      'Me.lblBillRecDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblBillRecDay}")
      'Me.Validator.SetDisplayName(Me.txtBillRecDays, Me.lblBillRecDay.Text)

      'Me.grbReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.grbReceive}")
      'Me.lblCheckAmountOnHand.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCheckAmountOnHand}")

    End Sub
#End Region

#Region "Member"
    Private m_entity As Supplier
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()
    End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"
    'Private Function ConvertItemsToValueArray(ByVal list As String) As String
    '  Dim result As String = ""
    '  If list Is Nothing OrElse list.Length = 0 Then
    '    Return Nothing
    '  Else
    '    For Each item As String In list.Split(","c)
    '      result &= CStr(CInt(item) + 1) & ","
    '    Next
    '    If result.Length <> 0 Then
    '      result = result.TrimEnd(","c)
    '    End If
    '    Return result
    '  End If
    'End Function
#End Region

#Region "IListDetail"

    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      'If m_entity.Canceled Then
      '  For Each ctrl As Control In grbExportVatDetail.Controls
      '    If ctrl.Name.ToLower <> "btncancel" Then
      '      ctrl.Enabled = False
      '    End If
      '  Next
      '  grbSupplier.Enabled = False
      '  grbReceive.Enabled = False
      '  grbBillRec.Enabled = False
      '  grbFinancial.Enabled = False
      '  grbCredit.Enabled = False
      '  grbMap.Enabled = False
      'Else
      '  For Each ctrl As Control In grbExportVatDetail.Controls
      '    ctrl.Enabled = True
      '  Next
      '  grbSupplier.Enabled = True
      '  grbReceive.Enabled = True
      '  grbBillRec.Enabled = True
      '  grbFinancial.Enabled = True
      '  grbCredit.Enabled = True
      '  grbMap.Enabled = True
      'End If
    End Sub

    ' เคลียร์ข้อมูลลูกค้าใน control
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbExportVatDetail.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        End If
      Next

      'txtbirthdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      'txtLastContactDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      'txtLastPaydate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      'dtpBirthDate.Value = Now.Date
      'dtpLastContactDate.Value = Now.Date
      'dtpLastPayDate.Value = Now.Date

      'cmbCreditType.SelectedIndex = -1
      'cmbCreditType.SelectedIndex = -1

    End Sub

    Protected Overrides Sub EventWiring()
      'AddHandler dtpBirthDate.ValueChanged, AddressOf Me.ChangeProperty
      'AddHandler dtpLastContactDate.ValueChanged, AddressOf Me.ChangeProperty
      'AddHandler dtpLastPayDate.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtbirthdate.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtLastContactDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtLastPaydate.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtHomePage.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtBillRecDates.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtBillRecWeeks.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtReceiveDates.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtReceiveWeeks.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtSummaryDiscount.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtDetailDiscount.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtTaxRate.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtCheckAmountOnHand.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler cmbCreditType.SelectedValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtCreditPeriod.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtCreditAmount.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtCreditPeriodFromTransport.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtTitleName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPhoneNumber.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPostCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtProvince.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtDistrict.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtTambon.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtStreet.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtSubstreet.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtMoo.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAddress.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtFloor.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRoomNo.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtVillageName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBuildingName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBranchId.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtTaxIdNo.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtIdNo.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtLastName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtFirstName.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing AndAlso m_entity.ExportEntity Is Nothing Then
        Return
      End If

      Me.txtCode.Text = Me.m_entity.Code

      Me.txtTitleName.Text = Me.m_entity.ExportEntity.TitleName
      Me.txtPhoneNumber.Text = Me.m_entity.ExportEntity.PhoneNumber
      Me.txtPostCode.Text = Me.m_entity.ExportEntity.PostCode
      Me.txtProvince.Text = Me.m_entity.ExportEntity.Province
      Me.txtDistrict.Text = Me.m_entity.ExportEntity.District
      Me.txtTambon.Text = Me.m_entity.ExportEntity.TamBon
      Me.txtStreet.Text = Me.m_entity.ExportEntity.Street
      Me.txtSubstreet.Text = Me.m_entity.ExportEntity.SubStreet
      Me.txtMoo.Text = Me.m_entity.ExportEntity.Moo
      Me.txtAddress.Text = Me.m_entity.ExportEntity.Address
      Me.txtFloor.Text = Me.m_entity.ExportEntity.Floor
      Me.txtRoomNo.Text = Me.m_entity.ExportEntity.RoomNumber
      Me.txtVillageName.Text = Me.m_entity.ExportEntity.VillageName
      Me.txtBuildingName.Text = Me.m_entity.ExportEntity.BuildingName
      Me.txtBranchId.Text = Me.m_entity.ExportEntity.BranchId
      Me.txtTaxIdNo.Text = Me.m_entity.ExportEntity.TaxIdNo
      Me.txtIdNo.Text = Me.m_entity.ExportEntity.Idno
      Me.txtLastName.Text = Me.m_entity.ExportEntity.LastName
      Me.txtFirstName.Text = Me.m_entity.ExportEntity.FirstName

      'txtFirstName.Text = Me.m_entity.Name

      'picImage.Image = Me.m_entity.Image
      'CheckLabelImgSize()
      'picMap.Image = Me.m_entity.Map

      'dtpBirthDate.Value = MinDateToNow(Me.m_entity.BirthDate)
      'txtbirthdate.Text = MinDateToNull(Me.m_entity.BirthDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      'dtpLastContactDate.Value = MinDateToNow(Me.m_entity.LastContactDate)
      'txtLastContactDate.Text = MinDateToNull(Me.m_entity.LastContactDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      'dtpLastPayDate.Value = MinDateToNow(Me.m_entity.LastPayDate)
      'txtLastPaydate.Text = MinDateToNull(Me.m_entity.LastPayDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))


      'txtHomePage.Text = Me.m_entity.HomePage

      'txtBillRecDays.Text = DateTimeService.GetDayStrings(Me.m_entity.BillrecDays, False)
      'txtBillRecDates.Text = ConvertItemsToValueArray(Me.m_entity.BillRecDates)
      'txtBillRecWeeks.Text = ConvertItemsToValueArray(Me.m_entity.BillRecWeeks)
      'txtReceiveDays.Text = DateTimeService.GetDayStrings(Me.m_entity.ReceiveDays, False)
      'txtReceiveDates.Text = ConvertItemsToValueArray(Me.m_entity.ReceiveDates)
      'txtReceiveWeeks.Text = ConvertItemsToValueArray(Me.m_entity.ReceiveWeeks)

      'txtSummaryDiscount.Text = Me.m_entity.SummaryDiscount.Rate
      'txtDetailDiscount.Text = Me.m_entity.DetailDiscount.Rate

      'txtTaxRate.Text = Me.m_entity.TaxRate.ToString
      'txtCheckAmountOnHand.Text = Me.m_entity.CheckAmountOnHand.ToString

      'cmbCreditType.SelectedValue = Me.m_entity.CreditType.Value

      'txtCreditPeriod.Text = Me.m_entity.CreditPeriod.ToString
      'txtCreditAmount.Text = Me.m_entity.CreditAmount.ToString
      'txtCreditPeriodFromTransport.Text = Me.m_entity.CreditPeriodFromTransport.ToString

      'SetLabelText()
      'CheckFormEnable()

      m_isInitialized = True
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing OrElse Me.m_entity.ExportEntity Is Nothing OrElse Not m_isInitialized Then
        Return
      End If



      Try
        Select Case CType(sender, Control).Name.ToLower
          Case Me.txtTitleName.Name.ToLower
            Me.m_entity.ExportEntity.TitleName = Me.txtTitleName.Text
          Case Me.txtPhoneNumber.Name.ToLower
            Me.m_entity.ExportEntity.PhoneNumber = Me.txtPhoneNumber.Text
          Case Me.txtPostCode.Name.ToLower
            Me.m_entity.ExportEntity.PostCode = Me.txtPostCode.Text
          Case Me.txtProvince.Name.ToLower
            Me.m_entity.ExportEntity.Province = Me.txtProvince.Text
          Case Me.txtDistrict.Name.ToLower
            Me.m_entity.ExportEntity.District = Me.txtDistrict.Text
          Case Me.txtTambon.Name.ToLower
            Me.m_entity.ExportEntity.TamBon = Me.txtTambon.Text
          Case Me.txtStreet.Name.ToLower
            Me.m_entity.ExportEntity.Street = Me.txtStreet.Text
          Case Me.txtSubstreet.Name.ToLower
            Me.m_entity.ExportEntity.SubStreet = Me.txtSubstreet.Text
          Case Me.txtMoo.Name.ToLower
            Me.m_entity.ExportEntity.Moo = Me.txtMoo.Text
          Case Me.txtAddress.Name.ToLower
            Me.m_entity.ExportEntity.Address = Me.txtAddress.Text
          Case Me.txtFloor.Name.ToLower
            Me.m_entity.ExportEntity.Floor = Me.txtFloor.Text
          Case Me.txtRoomNo.Name.ToLower
            Me.m_entity.ExportEntity.RoomNumber = Me.txtRoomNo.Text
          Case Me.txtVillageName.Name.ToLower
            Me.m_entity.ExportEntity.VillageName = Me.txtVillageName.Text
          Case Me.txtBuildingName.Name.ToLower
            Me.m_entity.ExportEntity.BuildingName = Me.txtBuildingName.Text
          Case Me.txtBranchId.Name.ToLower
            Me.m_entity.ExportEntity.BranchId = Me.txtBranchId.Text
          Case Me.txtTaxIdNo.Name.ToLower
            Me.m_entity.ExportEntity.TaxIdNo = Me.txtTaxIdNo.Text
          Case Me.txtIdNo.Name.ToLower
            Me.m_entity.ExportEntity.Idno = Me.txtIdNo.Text
          Case Me.txtLastName.Name.ToLower
            Me.m_entity.ExportEntity.LastName = Me.txtLastName.Text
          Case Me.txtFirstName.Name.ToLower
            Me.m_entity.ExportEntity.FirstName = Me.txtFirstName.Text
            'Case "dtpbirthdate"
            '  DateToString(dtpBirthDate, txtbirthdate)
            '  Me.m_entity.BirthDate = dtpBirthDate.Value

            'Case "txthomepage"
            '  Me.m_entity.HomePage = txtHomePage.Text

            'Case "dtplastcontactdate"
            '  DateToString(dtpLastContactDate, txtLastContactDate)
            '  Me.m_entity.LastContactDate = dtpLastContactDate.Value

            'Case "dtplastpaydate"
            '  DateToString(dtpLastPayDate, txtLastPaydate)
            '  Me.m_entity.LastPayDate = dtpLastPayDate.Value

            'Case "txtdetaildiscount"
            '  Me.m_entity.DetailDiscount.Rate = txtDetailDiscount.Text

            'Case "txtsummarydiscount"
            '  Me.m_entity.SummaryDiscount.Rate = txtSummaryDiscount.Text

            'Case "txttaxrate"
            '  If IsNumeric(txtTaxRate.Text) Then
            '    Me.m_entity.TaxRate = CDec(txtTaxRate.Text)
            '  Else
            '    Me.m_entity.TaxRate = Nothing
            '  End If

            'Case "txtcheckamountonhand"
            '  If IsNumeric(txtCheckAmountOnHand.Text) Then
            '    Me.m_entity.CheckAmountOnHand = CDec(txtCheckAmountOnHand.Text)
            '  Else
            '    Me.m_entity.CheckAmountOnHand = Nothing
            '  End If

            'Case "cmbcredittype"
            '  Me.m_entity.CreditType.Value = CInt(cmbCreditType.SelectedValue)

            'Case "txtcreditperiod"
            '  If IsNumeric(txtCreditPeriod.Text) Then
            '    Me.m_entity.CreditPeriod = CInt(txtCreditPeriod.Text)
            '  Else
            '    Me.m_entity.CreditPeriod = Nothing
            '  End If

            'Case "txtcreditamount"
            '  If IsNumeric(txtCreditAmount.Text) Then
            '    Me.m_entity.CreditAmount = CDec(txtCreditAmount.Text)
            '  Else
            '    Me.m_entity.CreditAmount = Nothing
            '  End If

            'Case "txtcreditperiodfromtransport"
            '  If IsNumeric(txtCreditPeriodFromTransport.Text) Then
            '    Me.m_entity.CreditPeriodFromTransport = CInt(txtCreditPeriodFromTransport.Text)
            '  Else
            '    Me.m_entity.CreditPeriodFromTransport = Nothing
            '  End If

            'Case "txtbirthdate"
            '  Dim dt As DateTime = StringToDate(txtbirthdate, dtpBirthDate)
            '  Me.m_entity.BirthDate = dt

            'Case "txtlastcontactdate"
            '  Dim dt As DateTime = StringToDate(txtLastContactDate, dtpLastContactDate)
            '  Me.m_entity.LastContactDate = dt

            'Case "txtlastpaydate"
            '  Dim dt As DateTime = StringToDate(txtLastPaydate, dtpLastPayDate)
            '  Me.m_entity.LastPayDate = dt

        End Select
      Catch ex As Exception

      End Try
      'Hack
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = True
      m_entity.ExportEntity.IsDirty = True
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        'Me.m_entity = Nothing
        Me.m_entity = CType(Value, Supplier)
        Me.m_entity.GetExportEntity()
        Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
        'Me.SaveProperties()
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      'Dim propService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      'Dim culture As String = propService.GetProperty("CoreProperties.UILanguage", "th")
      'culture = culture & "-" & culture.ToUpper
      ''Me.DateTimeService.ListDaysInComboBox(Me.cmbBillrecDay, False, culture)
      ''Me.DateTimeService.ListDaysInComboBox(Me.cmbReceiveDay, False, culture)

      'Me.cmbCreditType.DataSource = CodeDescription.GetCodeList("credit_type")
      'Me.cmbCreditType.DisplayMember = "code_description"
      'Me.cmbCreditType.ValueMember = "code_value"

      Me.RefreshAutoComplete()
    End Sub
    Public Sub RefreshAutoComplete()
      'If Me.m_entity Is Nothing OrElse Me.m_entity.ExportEntity Is Nothing Then
      '  Return
      'End If
      ExportEntity.GetCompleteCode()

      Me.txtTitleName.AutoCompleteSource = AutoCompleteSource.CustomSource
      Me.txtStreet.AutoCompleteSource = AutoCompleteSource.CustomSource
      Me.txtTambon.AutoCompleteSource = AutoCompleteSource.CustomSource
      Me.txtDistrict.AutoCompleteSource = AutoCompleteSource.CustomSource
      Me.txtProvince.AutoCompleteSource = AutoCompleteSource.CustomSource
      Me.txtPostCode.AutoCompleteSource = AutoCompleteSource.CustomSource

      Me.txtTitleName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
      Me.txtStreet.AutoCompleteMode = AutoCompleteMode.SuggestAppend
      Me.txtTambon.AutoCompleteMode = AutoCompleteMode.SuggestAppend
      Me.txtDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend
      Me.txtProvince.AutoCompleteMode = AutoCompleteMode.SuggestAppend
      Me.txtPostCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend

      Me.txtTitleName.AutoCompleteCustomSource = ExportEntity.AutoCompleteOfTitleName
      Me.txtStreet.AutoCompleteCustomSource = ExportEntity.AutoCompleteOfStreet
      Me.txtTambon.AutoCompleteCustomSource = ExportEntity.AutoCompleteOfTambon
      Me.txtDistrict.AutoCompleteCustomSource = ExportEntity.AutoCompleteOfDistrict
      Me.txtProvince.AutoCompleteCustomSource = ExportEntity.AutoCompleteOfProvince
      Me.txtPostCode.AutoCompleteCustomSource = ExportEntity.AutoCompleteOfPostCode

    End Sub
#End Region

#Region "Event Handlers"
    'Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim dlg As New OpenFileDialog
    '  Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
    '  dlg.Filter = String.Join("|", fileFilters)
    '  If dlg.ShowDialog = DialogResult.OK Then
    '    Dim img As Image = Image.FromFile(dlg.FileName)
    '    If img.Size.Height > Me.picImage.Height OrElse img.Size.Width >= Me.picImage.Width Then
    '      Dim percent As Decimal = 100 * (Math.Min(Me.picImage.Height / img.Size.Height, Me.picImage.Width / img.Size.Width))
    '      img = ImageHelper.Resize(img, percent)
    '    End If
    '    Me.picImage.Image = img
    '    m_entity.Image = img
    '    'Hack
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '    CheckLabelImgSize()
    '  End If
    'End Sub

    'Private Sub btnLoadMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim dlg As New OpenFileDialog
    '  Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
    '  dlg.Filter = String.Join("|", fileFilters)
    '  If dlg.ShowDialog = DialogResult.OK Then
    '    Dim img As Image = Image.FromFile(dlg.FileName)
    '    Me.picMap.Image = img
    '    m_entity.Map = img
    '    'Hack
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.MapDialog(m_entity, Me))
    '    myDialog.ShowDialog()
    '  End If
    'End Sub

    'Private Sub btnShowMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.MapDialog(m_entity, Me))
    '  myDialog.ShowDialog()
    '  Me.picMap.Invalidate()
    'End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      'Me.RevertProperties()
    End Sub
    'Private Sub ImbBillRecDate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '  Dim dates(30) As Object
    '  For i As Integer = 1 To 31
    '    dates(i - 1) = i
    '  Next
    '  Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(dates, Me.m_entity.BillRecDates)
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
    '  If myDialog.ShowDialog() = DialogResult.OK Then
    '    Me.txtBillRecDates.Text = chkdlg.CheckedItemsString
    '    Me.m_entity.BillRecDates = chkdlg.CheckedValuesString
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '  End If
    'End Sub
    'Private Sub ImbBillRecDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim days As Object() = Me.DateTimeService.GetDays(False).ToArray
    '  Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(days, Me.m_entity.BillrecDays)
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
    '  If myDialog.ShowDialog() = DialogResult.OK Then
    '    Me.txtBillRecDays.Text = chkdlg.CheckedItemsString
    '    Me.m_entity.BillrecDays = chkdlg.CheckedValuesString
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '  End If
    'End Sub
    'Private Sub ImbBillRecWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim weeks(3) As Object
    '  For i As Integer = 1 To 4
    '    weeks(i - 1) = i
    '  Next
    '  Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(weeks, Me.m_entity.BillRecWeeks)
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
    '  If myDialog.ShowDialog() = DialogResult.OK Then
    '    Me.txtBillRecWeeks.Text = chkdlg.CheckedItemsString
    '    Me.m_entity.BillRecWeeks = chkdlg.CheckedValuesString
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '  End If
    'End Sub
    'Private Sub ImbReceiveDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim days As Object() = Me.DateTimeService.GetDays(False).ToArray
    '  Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(days, Me.m_entity.ReceiveDays)
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
    '  If myDialog.ShowDialog() = DialogResult.OK Then
    '    Me.txtReceiveDays.Text = chkdlg.CheckedItemsString
    '    Me.m_entity.ReceiveDays = chkdlg.CheckedValuesString
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '  End If
    'End Sub
    'Private Sub ImbReceiveDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim dates(30) As Object
    '  For i As Integer = 1 To 31
    '    dates(i - 1) = i
    '  Next
    '  Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(dates, Me.m_entity.ReceiveDates)
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
    '  If myDialog.ShowDialog() = DialogResult.OK Then
    '    Me.txtReceiveDates.Text = chkdlg.CheckedItemsString
    '    Me.m_entity.ReceiveDates = chkdlg.CheckedValuesString
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '  End If
    'End Sub
    'Private Sub ImbReceiveWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim weeks(3) As Object
    '  For i As Integer = 1 To 4
    '    weeks(i - 1) = i
    '  Next
    '  Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(weeks, Me.m_entity.ReceiveWeeks)
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
    '  If myDialog.ShowDialog() = DialogResult.OK Then
    '    Me.txtReceiveWeeks.Text = chkdlg.CheckedItemsString
    '    Me.m_entity.ReceiveWeeks = chkdlg.CheckedValuesString
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '  End If
    'End Sub
    'Private Sub picMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
    '  Dim g As Graphics = e.Graphics
    '  Dim pn As New Pen(Color.Red, 3)
    '  Dim top As Integer = Me.m_entity.MapPosition.Y - 10
    '  If top < 0 Then top = 0
    '  Dim left As Integer = Me.m_entity.MapPosition.X - 10
    '  If left < 0 Then left = 0
    '  Dim bottom As Integer = Me.m_entity.MapPosition.Y + 10
    '  If bottom > picMap.Height Then bottom = picMap.Height
    '  Dim right As Integer = Me.m_entity.MapPosition.X + 10
    '  If right > picMap.Width Then right = picMap.Width
    '  g.DrawLine(pn, left, top, right, bottom)
    '  g.DrawLine(pn, right, top, left, bottom)
    '  pn.Dispose()
    'End Sub
    'Private m_Ticks As Long
    'Private m_canDrag As Boolean = False
    'Const TICKS_OFFSET As Long = 0
    'Private Sub picMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '  Dim ts As New TimeSpan(Now.Ticks - m_Ticks)
    '  If m_canDrag And e.Button = MouseButtons.Left And ts.TotalMilliseconds > TICKS_OFFSET Then
    '    If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
    '      Me.m_entity.MapPosition = New Point(e.X, e.Y)
    '      picMap.Invalidate()
    '      m_Ticks = Now.Ticks
    '    End If
    '  End If
    'End Sub
    'Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '  'Dim top As Integer = Me.m_entity.MapPosition.Y - 10
    '  'If top < 0 Then top = 0
    '  'Dim left As Integer = Me.m_entity.MapPosition.X - 10
    '  'If left < 0 Then left = 0
    '  'Dim bottom As Integer = Me.m_entity.MapPosition.Y + 10
    '  'If bottom > picMap.Height Then bottom = picMap.Height
    '  'Dim right As Integer = Me.m_entity.MapPosition.X + 10
    '  'If right > picMap.Width Then right = picMap.Width

    '  'Dim xBounds As New Rectangle(left, top, 20, 20)
    '  'If xBounds.Contains(New Point(e.X, e.Y)) Then
    '  '    m_canDrag = True
    '  'End If

    '  m_canDrag = True
    '  If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
    '    Me.m_entity.MapPosition = New Point(e.X, e.Y)
    '    picMap.Invalidate()
    '    'Hack
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '  End If
    'End Sub
    'Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '  If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
    '    Me.m_entity.MapPosition = New Point(e.X, e.Y)
    '    'Hack
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '  End If
    '  m_canDrag = False
    'End Sub
#End Region

#Region "IReversibleEntityProperty"

#Region "Members"
    Private m_oldStatusIsDirty As Boolean
    Private m_oldBirthdate As Date
    Private m_oldHomePage As String
    Private m_oldLastContactDate As Date
    Private m_oldBillrecDay As DayOfWeek
    Private m_oldBillRecDate As Integer
    Private m_oldBillRecWeek As Integer
    Private m_oldReceiveDay As DayOfWeek
    Private m_oldReceiveDate As Integer
    Private m_oldReceiveWeek As Integer
    Private m_oldLastPayDate As Date
    Private m_oldSummaryDiscount As Discount
    Private m_oldDetailDiscount As Discount
    Private m_oldTaxRate As Decimal
    Private m_oldCheckAmountOnHand As Decimal
    Private m_oldCreditType As CreditType
    Private m_oldCreditPeriod As Integer
    Private m_oldCreditAmount As Decimal
    Private m_oldCreditPeriodFromTransport As Integer
    Private m_oldMap As Image
    Private m_oldImage As Image
    Private m_oldMapPosition As Point
#End Region

    'Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties
    '  Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '  myContent.IsDirty = m_oldStatusIsDirty
    '  Me.m_entity.BirthDate = m_oldBirthdate
    '  Me.m_entity.HomePage = m_oldHomePage
    '  Me.m_entity.LastContactDate = m_oldLastContactDate
    '  'Me.m_entity.BillrecDay = m_oldBillrecDay
    '  'Me.m_entity.BillRecDate = m_oldBillRecDate
    '  'Me.m_entity.BillRecWeek = m_oldBillRecWeek
    '  'Me.m_entity.ReceiveDays = m_oldReceiveDay
    '  'Me.m_entity.ReceiveDate = m_oldReceiveDate
    '  'Me.m_entity.ReceiveWeek = m_oldReceiveWeek
    '  Me.m_entity.LastPayDate = m_oldLastPayDate
    '  Me.m_entity.SummaryDiscount = m_oldSummaryDiscount
    '  Me.m_entity.DetailDiscount = m_oldDetailDiscount
    '  Me.m_entity.TaxRate = m_oldTaxRate
    '  Me.m_entity.CheckAmountOnHand = m_oldCheckAmountOnHand
    '  Me.m_entity.CreditType = m_oldCreditType
    '  Me.m_entity.CreditPeriod = m_oldCreditPeriod
    '  Me.m_entity.CreditAmount = m_oldCreditAmount
    '  Me.m_entity.CreditPeriodFromTransport = m_oldCreditPeriodFromTransport
    '  Me.m_entity.Map = m_oldMap
    '  Me.m_entity.Image = m_oldImage
    '  Me.m_entity.MapPosition = m_oldMapPosition
    '  Me.m_entity.HtChangedProperties.Clear()
    'End Sub
    'Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties
    '  Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '  m_oldStatusIsDirty = myContent.IsDirty
    '  m_oldBirthdate = Me.m_entity.BirthDate
    '  m_oldHomePage = Me.m_entity.HomePage
    '  m_oldLastContactDate = Me.m_entity.LastContactDate
    '  'm_oldBillrecDay = Me.m_entity.BillrecDay
    '  'm_oldBillRecDate = Me.m_entity.BillRecDate
    '  'm_oldBillRecWeek = Me.m_entity.BillRecWeek
    '  'm_oldReceiveDay = Me.m_entity.ReceiveDays
    '  'm_oldReceiveDate = Me.m_entity.ReceiveDate
    '  'm_oldReceiveWeek = Me.m_entity.ReceiveWeek
    '  m_oldLastPayDate = Me.m_entity.LastPayDate
    '  m_oldSummaryDiscount = Me.m_entity.SummaryDiscount
    '  m_oldDetailDiscount = Me.m_entity.DetailDiscount
    '  m_oldTaxRate = Me.m_entity.TaxRate
    '  m_oldCheckAmountOnHand = Me.m_entity.CheckAmountOnHand
    '  m_oldCreditType = Me.m_entity.CreditType
    '  m_oldCreditPeriod = Me.m_entity.CreditPeriod
    '  m_oldCreditAmount = Me.m_entity.CreditAmount
    '  m_oldCreditPeriodFromTransport = Me.m_entity.CreditPeriodFromTransport
    '  m_oldMap = Me.m_entity.Map
    '  m_oldImage = Me.m_entity.Image
    '  m_oldMapPosition = Me.m_entity.MapPosition
    'End Sub
#End Region

    'Private Sub btnClearMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  m_entity.Map = Nothing
    '  Me.picMap.Image = Nothing
    '  Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '  myContent.IsDirty = True
    'End Sub

    'Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  m_entity.Image = Nothing
    '  Me.picImage.Image = Nothing
    '  Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '  myContent.IsDirty = True
    '  CheckLabelImgSize()
    'End Sub
    'Private Sub CheckLabelImgSize()
    '  Me.lblPicSize.Text = "120 X 120 pixel"
    '  If Me.m_entity.Image Is Nothing Then
    '    Me.lblPicSize.Visible = True
    '  Else
    '    Me.lblPicSize.Visible = False
    '  End If
    'End Sub
  End Class

End Namespace
