Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels

    Public Class AssetAuxDetail
        Inherits AbstractEntityDetailPanelView
        Implements IHelperCapable, IReversibleEntityProperty, IValidatable


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
        Friend WithEvents PrimaryGroupBoxControl As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblBuyer As System.Windows.Forms.Label
        Friend WithEvents lblSaleDocCode As System.Windows.Forms.Label
        Friend WithEvents lblSalePrice As System.Windows.Forms.Label
        Friend WithEvents txtSalePrice As System.Windows.Forms.TextBox
        Friend WithEvents lblInsuranceCode As System.Windows.Forms.Label
        Friend WithEvents txtSaftyCode As System.Windows.Forms.TextBox
        Friend WithEvents txtInsurranceCode As System.Windows.Forms.TextBox
        Friend WithEvents lblSaftyCode As System.Windows.Forms.Label
        Friend WithEvents txtBuyer As System.Windows.Forms.TextBox
        Friend WithEvents txtSaleDocCode As System.Windows.Forms.TextBox
        Friend WithEvents lblSaleDocDate As System.Windows.Forms.Label
        Friend WithEvents txtInsurrancePremium As System.Windows.Forms.TextBox
        Friend WithEvents lblInsuranceeAge As System.Windows.Forms.Label
        Friend WithEvents txtInsurranceAge As System.Windows.Forms.TextBox
        Friend WithEvents lblInsuranceStartDate As System.Windows.Forms.Label
        Friend WithEvents lblSaftyCompany As System.Windows.Forms.Label
        Friend WithEvents lblInsuranceEndDate As System.Windows.Forms.Label
        Friend WithEvents txtSaftyCompany As System.Windows.Forms.TextBox
        Friend WithEvents lblInsurancePremium As System.Windows.Forms.Label
        Friend WithEvents dtpSaleDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpSaleDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpInsurranceStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpInsurranceEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblSaleDate As System.Windows.Forms.Label
        Friend WithEvents grbSaleDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbInsurranceDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtSaleDate As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtSaleDocDate As System.Windows.Forms.TextBox
        Friend WithEvents txtInsurranceStartDate As System.Windows.Forms.TextBox
        Friend WithEvents txtInsurranceEndDate As System.Windows.Forms.TextBox
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblAssetList As System.Windows.Forms.Label
    Friend WithEvents tgAssetList As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents btnAssetList As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCurrencyUnit As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssetAuxDetail))
      Me.PrimaryGroupBoxControl = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.grbInsurranceDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtInsurranceEndDate = New System.Windows.Forms.TextBox()
      Me.txtInsurranceStartDate = New System.Windows.Forms.TextBox()
      Me.lblInsuranceeAge = New System.Windows.Forms.Label()
      Me.txtInsurranceAge = New System.Windows.Forms.TextBox()
      Me.lblInsuranceStartDate = New System.Windows.Forms.Label()
      Me.lblSaftyCompany = New System.Windows.Forms.Label()
      Me.lblInsuranceEndDate = New System.Windows.Forms.Label()
      Me.txtSaftyCompany = New System.Windows.Forms.TextBox()
      Me.lblInsurancePremium = New System.Windows.Forms.Label()
      Me.lblInsuranceCode = New System.Windows.Forms.Label()
      Me.txtSaftyCode = New System.Windows.Forms.TextBox()
      Me.txtInsurranceCode = New System.Windows.Forms.TextBox()
      Me.lblSaftyCode = New System.Windows.Forms.Label()
      Me.dtpInsurranceEndDate = New System.Windows.Forms.DateTimePicker()
      Me.txtInsurrancePremium = New System.Windows.Forms.TextBox()
      Me.dtpInsurranceStartDate = New System.Windows.Forms.DateTimePicker()
      Me.lblYear = New System.Windows.Forms.Label()
      Me.grbSaleDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtSaleDate = New System.Windows.Forms.TextBox()
      Me.lblCurrencyUnit = New System.Windows.Forms.Label()
      Me.lblSaleDocCode = New System.Windows.Forms.Label()
      Me.lblSaleDate = New System.Windows.Forms.Label()
      Me.lblSalePrice = New System.Windows.Forms.Label()
      Me.txtSalePrice = New System.Windows.Forms.TextBox()
      Me.dtpSaleDate = New System.Windows.Forms.DateTimePicker()
      Me.txtSaleDocCode = New System.Windows.Forms.TextBox()
      Me.lblSaleDocDate = New System.Windows.Forms.Label()
      Me.lblBuyer = New System.Windows.Forms.Label()
      Me.txtBuyer = New System.Windows.Forms.TextBox()
      Me.txtSaleDocDate = New System.Windows.Forms.TextBox()
      Me.dtpSaleDocDate = New System.Windows.Forms.DateTimePicker()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.tgAssetList = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblAssetList = New System.Windows.Forms.Label()
      Me.btnAssetList = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.PrimaryGroupBoxControl.SuspendLayout()
      Me.grbInsurranceDetail.SuspendLayout()
      Me.grbSaleDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgAssetList, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'PrimaryGroupBoxControl
      '
      Me.PrimaryGroupBoxControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.PrimaryGroupBoxControl.Controls.Add(Me.btnAssetList)
      Me.PrimaryGroupBoxControl.Controls.Add(Me.lblAssetList)
      Me.PrimaryGroupBoxControl.Controls.Add(Me.tgAssetList)
      Me.PrimaryGroupBoxControl.Controls.Add(Me.btnOk)
      Me.PrimaryGroupBoxControl.Controls.Add(Me.btnCancel)
      Me.PrimaryGroupBoxControl.Controls.Add(Me.grbInsurranceDetail)
      Me.PrimaryGroupBoxControl.Controls.Add(Me.grbSaleDetail)
      Me.PrimaryGroupBoxControl.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.PrimaryGroupBoxControl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.PrimaryGroupBoxControl.ForeColor = System.Drawing.Color.Blue
      Me.PrimaryGroupBoxControl.Location = New System.Drawing.Point(8, 8)
      Me.PrimaryGroupBoxControl.Name = "PrimaryGroupBoxControl"
      Me.PrimaryGroupBoxControl.Size = New System.Drawing.Size(632, 454)
      Me.PrimaryGroupBoxControl.TabIndex = 0
      Me.PrimaryGroupBoxControl.TabStop = False
      Me.PrimaryGroupBoxControl.Text = "ข้อมูลสินทรัพย์เพิ่มเติม : "
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnOk.ForeColor = System.Drawing.Color.Black
      Me.btnOk.Location = New System.Drawing.Point(416, 424)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(96, 24)
      Me.btnOk.TabIndex = 33
      Me.btnOk.Text = "OK"
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.Black
      Me.btnCancel.Location = New System.Drawing.Point(520, 424)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(96, 24)
      Me.btnCancel.TabIndex = 34
      Me.btnCancel.TabStop = False
      Me.btnCancel.Text = "Cancel"
      '
      'grbInsurranceDetail
      '
      Me.grbInsurranceDetail.Controls.Add(Me.txtInsurranceEndDate)
      Me.grbInsurranceDetail.Controls.Add(Me.txtInsurranceStartDate)
      Me.grbInsurranceDetail.Controls.Add(Me.lblInsuranceeAge)
      Me.grbInsurranceDetail.Controls.Add(Me.txtInsurranceAge)
      Me.grbInsurranceDetail.Controls.Add(Me.lblInsuranceStartDate)
      Me.grbInsurranceDetail.Controls.Add(Me.lblSaftyCompany)
      Me.grbInsurranceDetail.Controls.Add(Me.lblInsuranceEndDate)
      Me.grbInsurranceDetail.Controls.Add(Me.txtSaftyCompany)
      Me.grbInsurranceDetail.Controls.Add(Me.lblInsurancePremium)
      Me.grbInsurranceDetail.Controls.Add(Me.lblInsuranceCode)
      Me.grbInsurranceDetail.Controls.Add(Me.txtSaftyCode)
      Me.grbInsurranceDetail.Controls.Add(Me.txtInsurranceCode)
      Me.grbInsurranceDetail.Controls.Add(Me.lblSaftyCode)
      Me.grbInsurranceDetail.Controls.Add(Me.dtpInsurranceEndDate)
      Me.grbInsurranceDetail.Controls.Add(Me.txtInsurrancePremium)
      Me.grbInsurranceDetail.Controls.Add(Me.dtpInsurranceStartDate)
      Me.grbInsurranceDetail.Controls.Add(Me.lblYear)
      Me.grbInsurranceDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbInsurranceDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbInsurranceDetail.Location = New System.Drawing.Point(320, 16)
      Me.grbInsurranceDetail.Name = "grbInsurranceDetail"
      Me.grbInsurranceDetail.Size = New System.Drawing.Size(296, 200)
      Me.grbInsurranceDetail.TabIndex = 15
      Me.grbInsurranceDetail.TabStop = False
      Me.grbInsurranceDetail.Text = "ข้อมูลการรับประกัน : "
      '
      'txtInsurranceEndDate
      '
      Me.Validator.SetDataType(Me.txtInsurranceEndDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtInsurranceEndDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInsurranceEndDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInsurranceEndDate, System.Drawing.Color.Empty)
      Me.txtInsurranceEndDate.Location = New System.Drawing.Point(144, 168)
      Me.Validator.SetMinValue(Me.txtInsurranceEndDate, "")
      Me.txtInsurranceEndDate.Name = "txtInsurranceEndDate"
      Me.Validator.SetRegularExpression(Me.txtInsurranceEndDate, "")
      Me.Validator.SetRequired(Me.txtInsurranceEndDate, False)
      Me.txtInsurranceEndDate.Size = New System.Drawing.Size(92, 21)
      Me.txtInsurranceEndDate.TabIndex = 31
      '
      'txtInsurranceStartDate
      '
      Me.Validator.SetDataType(Me.txtInsurranceStartDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtInsurranceStartDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtInsurranceStartDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInsurranceStartDate, System.Drawing.Color.Empty)
      Me.txtInsurranceStartDate.Location = New System.Drawing.Point(144, 144)
      Me.Validator.SetMinValue(Me.txtInsurranceStartDate, "")
      Me.txtInsurranceStartDate.Name = "txtInsurranceStartDate"
      Me.Validator.SetRegularExpression(Me.txtInsurranceStartDate, "")
      Me.Validator.SetRequired(Me.txtInsurranceStartDate, False)
      Me.txtInsurranceStartDate.Size = New System.Drawing.Size(92, 21)
      Me.txtInsurranceStartDate.TabIndex = 28
      '
      'lblInsuranceeAge
      '
      Me.lblInsuranceeAge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInsuranceeAge.ForeColor = System.Drawing.Color.Black
      Me.lblInsuranceeAge.Location = New System.Drawing.Point(8, 120)
      Me.lblInsuranceeAge.Name = "lblInsuranceeAge"
      Me.lblInsuranceeAge.Size = New System.Drawing.Size(136, 18)
      Me.lblInsuranceeAge.TabIndex = 24
      Me.lblInsuranceeAge.Text = "ระยะเวลารับประกัน:"
      Me.lblInsuranceeAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtInsurranceAge
      '
      Me.Validator.SetDataType(Me.txtInsurranceAge, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
      Me.Validator.SetDisplayName(Me.txtInsurranceAge, "")
      Me.txtInsurranceAge.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtInsurranceAge, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInsurranceAge, System.Drawing.Color.Empty)
      Me.txtInsurranceAge.Location = New System.Drawing.Point(144, 120)
      Me.Validator.SetMinValue(Me.txtInsurranceAge, "0")
      Me.txtInsurranceAge.Name = "txtInsurranceAge"
      Me.Validator.SetRegularExpression(Me.txtInsurranceAge, "")
      Me.Validator.SetRequired(Me.txtInsurranceAge, False)
      Me.txtInsurranceAge.Size = New System.Drawing.Size(112, 21)
      Me.txtInsurranceAge.TabIndex = 25
      Me.txtInsurranceAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblInsuranceStartDate
      '
      Me.lblInsuranceStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInsuranceStartDate.ForeColor = System.Drawing.Color.Black
      Me.lblInsuranceStartDate.Location = New System.Drawing.Point(8, 144)
      Me.lblInsuranceStartDate.Name = "lblInsuranceStartDate"
      Me.lblInsuranceStartDate.Size = New System.Drawing.Size(136, 18)
      Me.lblInsuranceStartDate.TabIndex = 27
      Me.lblInsuranceStartDate.Text = "วันเริ่มประกัน:"
      Me.lblInsuranceStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSaftyCompany
      '
      Me.lblSaftyCompany.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSaftyCompany.ForeColor = System.Drawing.Color.Black
      Me.lblSaftyCompany.Location = New System.Drawing.Point(8, 72)
      Me.lblSaftyCompany.Name = "lblSaftyCompany"
      Me.lblSaftyCompany.Size = New System.Drawing.Size(136, 18)
      Me.lblSaftyCompany.TabIndex = 20
      Me.lblSaftyCompany.Text = "ประกันกับบริษัท:"
      Me.lblSaftyCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInsuranceEndDate
      '
      Me.lblInsuranceEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInsuranceEndDate.ForeColor = System.Drawing.Color.Black
      Me.lblInsuranceEndDate.Location = New System.Drawing.Point(8, 168)
      Me.lblInsuranceEndDate.Name = "lblInsuranceEndDate"
      Me.lblInsuranceEndDate.Size = New System.Drawing.Size(136, 18)
      Me.lblInsuranceEndDate.TabIndex = 30
      Me.lblInsuranceEndDate.Text = "วันสิ้นประกัน:"
      Me.lblInsuranceEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSaftyCompany
      '
      Me.Validator.SetDataType(Me.txtSaftyCompany, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSaftyCompany, "")
      Me.txtSaftyCompany.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSaftyCompany, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSaftyCompany, System.Drawing.Color.Empty)
      Me.txtSaftyCompany.Location = New System.Drawing.Point(144, 72)
      Me.Validator.SetMinValue(Me.txtSaftyCompany, "")
      Me.txtSaftyCompany.Name = "txtSaftyCompany"
      Me.Validator.SetRegularExpression(Me.txtSaftyCompany, "")
      Me.Validator.SetRequired(Me.txtSaftyCompany, False)
      Me.txtSaftyCompany.Size = New System.Drawing.Size(112, 21)
      Me.txtSaftyCompany.TabIndex = 21
      '
      'lblInsurancePremium
      '
      Me.lblInsurancePremium.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInsurancePremium.ForeColor = System.Drawing.Color.Black
      Me.lblInsurancePremium.Location = New System.Drawing.Point(8, 96)
      Me.lblInsurancePremium.Name = "lblInsurancePremium"
      Me.lblInsurancePremium.Size = New System.Drawing.Size(136, 18)
      Me.lblInsurancePremium.TabIndex = 22
      Me.lblInsurancePremium.Text = "InsurancePremium:"
      Me.lblInsurancePremium.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblInsuranceCode
      '
      Me.lblInsuranceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInsuranceCode.ForeColor = System.Drawing.Color.Black
      Me.lblInsuranceCode.Location = New System.Drawing.Point(8, 24)
      Me.lblInsuranceCode.Name = "lblInsuranceCode"
      Me.lblInsuranceCode.Size = New System.Drawing.Size(136, 18)
      Me.lblInsuranceCode.TabIndex = 16
      Me.lblInsuranceCode.Text = "เลขที่ประกัน:"
      Me.lblInsuranceCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSaftyCode
      '
      Me.Validator.SetDataType(Me.txtSaftyCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSaftyCode, "")
      Me.txtSaftyCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSaftyCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSaftyCode, System.Drawing.Color.Empty)
      Me.txtSaftyCode.Location = New System.Drawing.Point(144, 48)
      Me.Validator.SetMinValue(Me.txtSaftyCode, "")
      Me.txtSaftyCode.Name = "txtSaftyCode"
      Me.Validator.SetRegularExpression(Me.txtSaftyCode, "")
      Me.Validator.SetRequired(Me.txtSaftyCode, False)
      Me.txtSaftyCode.Size = New System.Drawing.Size(112, 21)
      Me.txtSaftyCode.TabIndex = 19
      '
      'txtInsurranceCode
      '
      Me.Validator.SetDataType(Me.txtInsurranceCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtInsurranceCode, "")
      Me.txtInsurranceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtInsurranceCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInsurranceCode, System.Drawing.Color.Empty)
      Me.txtInsurranceCode.Location = New System.Drawing.Point(144, 24)
      Me.Validator.SetMinValue(Me.txtInsurranceCode, "")
      Me.txtInsurranceCode.Name = "txtInsurranceCode"
      Me.Validator.SetRegularExpression(Me.txtInsurranceCode, "")
      Me.Validator.SetRequired(Me.txtInsurranceCode, False)
      Me.txtInsurranceCode.Size = New System.Drawing.Size(112, 21)
      Me.txtInsurranceCode.TabIndex = 17
      '
      'lblSaftyCode
      '
      Me.lblSaftyCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSaftyCode.ForeColor = System.Drawing.Color.Black
      Me.lblSaftyCode.Location = New System.Drawing.Point(8, 48)
      Me.lblSaftyCode.Name = "lblSaftyCode"
      Me.lblSaftyCode.Size = New System.Drawing.Size(136, 18)
      Me.lblSaftyCode.TabIndex = 18
      Me.lblSaftyCode.Text = "เลขที่กรมธรรม์:"
      Me.lblSaftyCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpInsurranceEndDate
      '
      Me.dtpInsurranceEndDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpInsurranceEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpInsurranceEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpInsurranceEndDate.Location = New System.Drawing.Point(144, 168)
      Me.dtpInsurranceEndDate.Name = "dtpInsurranceEndDate"
      Me.dtpInsurranceEndDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpInsurranceEndDate.TabIndex = 32
      Me.dtpInsurranceEndDate.TabStop = False
      '
      'txtInsurrancePremium
      '
      Me.Validator.SetDataType(Me.txtInsurrancePremium, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtInsurrancePremium, "")
      Me.txtInsurrancePremium.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtInsurrancePremium, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtInsurrancePremium, System.Drawing.Color.Empty)
      Me.txtInsurrancePremium.Location = New System.Drawing.Point(144, 96)
      Me.Validator.SetMinValue(Me.txtInsurrancePremium, "")
      Me.txtInsurrancePremium.Name = "txtInsurrancePremium"
      Me.Validator.SetRegularExpression(Me.txtInsurrancePremium, "")
      Me.Validator.SetRequired(Me.txtInsurrancePremium, False)
      Me.txtInsurrancePremium.Size = New System.Drawing.Size(112, 21)
      Me.txtInsurrancePremium.TabIndex = 23
      Me.txtInsurrancePremium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpInsurranceStartDate
      '
      Me.dtpInsurranceStartDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpInsurranceStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpInsurranceStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpInsurranceStartDate.Location = New System.Drawing.Point(144, 144)
      Me.dtpInsurranceStartDate.Name = "dtpInsurranceStartDate"
      Me.dtpInsurranceStartDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpInsurranceStartDate.TabIndex = 29
      Me.dtpInsurranceStartDate.TabStop = False
      '
      'lblYear
      '
      Me.lblYear.AutoSize = True
      Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYear.ForeColor = System.Drawing.Color.Black
      Me.lblYear.Location = New System.Drawing.Point(264, 120)
      Me.lblYear.Name = "lblYear"
      Me.lblYear.Size = New System.Drawing.Size(14, 13)
      Me.lblYear.TabIndex = 26
      Me.lblYear.Text = "ปี"
      Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbSaleDetail
      '
      Me.grbSaleDetail.Controls.Add(Me.txtSaleDate)
      Me.grbSaleDetail.Controls.Add(Me.lblCurrencyUnit)
      Me.grbSaleDetail.Controls.Add(Me.lblSaleDocCode)
      Me.grbSaleDetail.Controls.Add(Me.lblSaleDate)
      Me.grbSaleDetail.Controls.Add(Me.lblSalePrice)
      Me.grbSaleDetail.Controls.Add(Me.txtSalePrice)
      Me.grbSaleDetail.Controls.Add(Me.dtpSaleDate)
      Me.grbSaleDetail.Controls.Add(Me.txtSaleDocCode)
      Me.grbSaleDetail.Controls.Add(Me.lblSaleDocDate)
      Me.grbSaleDetail.Controls.Add(Me.lblBuyer)
      Me.grbSaleDetail.Controls.Add(Me.txtBuyer)
      Me.grbSaleDetail.Controls.Add(Me.txtSaleDocDate)
      Me.grbSaleDetail.Controls.Add(Me.dtpSaleDocDate)
      Me.grbSaleDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSaleDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbSaleDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbSaleDetail.Name = "grbSaleDetail"
      Me.grbSaleDetail.Size = New System.Drawing.Size(296, 152)
      Me.grbSaleDetail.TabIndex = 1
      Me.grbSaleDetail.TabStop = False
      Me.grbSaleDetail.Text = "ข้อมูลการขาย : "
      '
      'txtSaleDate
      '
      Me.Validator.SetDataType(Me.txtSaleDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtSaleDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSaleDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSaleDate, System.Drawing.Color.Empty)
      Me.txtSaleDate.Location = New System.Drawing.Point(128, 24)
      Me.Validator.SetMinValue(Me.txtSaleDate, "")
      Me.txtSaleDate.Name = "txtSaleDate"
      Me.Validator.SetRegularExpression(Me.txtSaleDate, "")
      Me.Validator.SetRequired(Me.txtSaleDate, False)
      Me.txtSaleDate.Size = New System.Drawing.Size(91, 21)
      Me.txtSaleDate.TabIndex = 3
      '
      'lblCurrencyUnit
      '
      Me.lblCurrencyUnit.AutoSize = True
      Me.lblCurrencyUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCurrencyUnit.ForeColor = System.Drawing.Color.Black
      Me.lblCurrencyUnit.Location = New System.Drawing.Point(248, 48)
      Me.lblCurrencyUnit.Name = "lblCurrencyUnit"
      Me.lblCurrencyUnit.Size = New System.Drawing.Size(27, 13)
      Me.lblCurrencyUnit.TabIndex = 7
      Me.lblCurrencyUnit.Text = "บาท"
      Me.lblCurrencyUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblSaleDocCode
      '
      Me.lblSaleDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSaleDocCode.ForeColor = System.Drawing.Color.Black
      Me.lblSaleDocCode.Location = New System.Drawing.Point(8, 72)
      Me.lblSaleDocCode.Name = "lblSaleDocCode"
      Me.lblSaleDocCode.Size = New System.Drawing.Size(112, 18)
      Me.lblSaleDocCode.TabIndex = 8
      Me.lblSaleDocCode.Text = "เลขที่ขายในเอกสาร:"
      Me.lblSaleDocCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSaleDate
      '
      Me.lblSaleDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSaleDate.ForeColor = System.Drawing.Color.Black
      Me.lblSaleDate.Location = New System.Drawing.Point(8, 24)
      Me.lblSaleDate.Name = "lblSaleDate"
      Me.lblSaleDate.Size = New System.Drawing.Size(112, 18)
      Me.lblSaleDate.TabIndex = 2
      Me.lblSaleDate.Text = "วันที่ขาย:"
      Me.lblSaleDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSalePrice
      '
      Me.lblSalePrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSalePrice.ForeColor = System.Drawing.Color.Black
      Me.lblSalePrice.Location = New System.Drawing.Point(8, 48)
      Me.lblSalePrice.Name = "lblSalePrice"
      Me.lblSalePrice.Size = New System.Drawing.Size(112, 18)
      Me.lblSalePrice.TabIndex = 5
      Me.lblSalePrice.Text = "ราคาขาย:"
      Me.lblSalePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSalePrice
      '
      Me.Validator.SetDataType(Me.txtSalePrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtSalePrice, "")
      Me.txtSalePrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSalePrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSalePrice, System.Drawing.Color.Empty)
      Me.txtSalePrice.Location = New System.Drawing.Point(128, 48)
      Me.Validator.SetMinValue(Me.txtSalePrice, "")
      Me.txtSalePrice.Name = "txtSalePrice"
      Me.Validator.SetRegularExpression(Me.txtSalePrice, "")
      Me.Validator.SetRequired(Me.txtSalePrice, False)
      Me.txtSalePrice.Size = New System.Drawing.Size(112, 21)
      Me.txtSalePrice.TabIndex = 6
      Me.txtSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpSaleDate
      '
      Me.dtpSaleDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpSaleDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpSaleDate.Location = New System.Drawing.Point(128, 24)
      Me.dtpSaleDate.Name = "dtpSaleDate"
      Me.dtpSaleDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpSaleDate.TabIndex = 4
      Me.dtpSaleDate.TabStop = False
      '
      'txtSaleDocCode
      '
      Me.Validator.SetDataType(Me.txtSaleDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSaleDocCode, "")
      Me.txtSaleDocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSaleDocCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSaleDocCode, System.Drawing.Color.Empty)
      Me.txtSaleDocCode.Location = New System.Drawing.Point(128, 72)
      Me.Validator.SetMinValue(Me.txtSaleDocCode, "")
      Me.txtSaleDocCode.Name = "txtSaleDocCode"
      Me.Validator.SetRegularExpression(Me.txtSaleDocCode, "")
      Me.Validator.SetRequired(Me.txtSaleDocCode, False)
      Me.txtSaleDocCode.Size = New System.Drawing.Size(112, 21)
      Me.txtSaleDocCode.TabIndex = 9
      '
      'lblSaleDocDate
      '
      Me.lblSaleDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSaleDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblSaleDocDate.Location = New System.Drawing.Point(8, 96)
      Me.lblSaleDocDate.Name = "lblSaleDocDate"
      Me.lblSaleDocDate.Size = New System.Drawing.Size(112, 18)
      Me.lblSaleDocDate.TabIndex = 10
      Me.lblSaleDocDate.Text = "วันที่ขายในเอกสาร:"
      Me.lblSaleDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBuyer
      '
      Me.lblBuyer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuyer.ForeColor = System.Drawing.Color.Black
      Me.lblBuyer.Location = New System.Drawing.Point(8, 120)
      Me.lblBuyer.Name = "lblBuyer"
      Me.lblBuyer.Size = New System.Drawing.Size(112, 18)
      Me.lblBuyer.TabIndex = 13
      Me.lblBuyer.Text = "ผู้รับซื้อ:"
      Me.lblBuyer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBuyer
      '
      Me.Validator.SetDataType(Me.txtBuyer, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuyer, "")
      Me.txtBuyer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuyer, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuyer, System.Drawing.Color.Empty)
      Me.txtBuyer.Location = New System.Drawing.Point(128, 120)
      Me.Validator.SetMinValue(Me.txtBuyer, "")
      Me.txtBuyer.Name = "txtBuyer"
      Me.Validator.SetRegularExpression(Me.txtBuyer, "")
      Me.Validator.SetRequired(Me.txtBuyer, False)
      Me.txtBuyer.Size = New System.Drawing.Size(112, 21)
      Me.txtBuyer.TabIndex = 14
      '
      'txtSaleDocDate
      '
      Me.Validator.SetDataType(Me.txtSaleDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtSaleDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSaleDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSaleDocDate, System.Drawing.Color.Empty)
      Me.txtSaleDocDate.Location = New System.Drawing.Point(128, 96)
      Me.Validator.SetMinValue(Me.txtSaleDocDate, "")
      Me.txtSaleDocDate.Name = "txtSaleDocDate"
      Me.Validator.SetRegularExpression(Me.txtSaleDocDate, "")
      Me.Validator.SetRequired(Me.txtSaleDocDate, False)
      Me.txtSaleDocDate.Size = New System.Drawing.Size(91, 21)
      Me.txtSaleDocDate.TabIndex = 11
      '
      'dtpSaleDocDate
      '
      Me.dtpSaleDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpSaleDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpSaleDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpSaleDocDate.Location = New System.Drawing.Point(128, 96)
      Me.dtpSaleDocDate.Name = "dtpSaleDocDate"
      Me.dtpSaleDocDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpSaleDocDate.TabIndex = 12
      Me.dtpSaleDocDate.TabStop = False
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
      'tgAssetList
      '
      Me.tgAssetList.AllowNew = False
      Me.tgAssetList.AllowSorting = False
      Me.tgAssetList.AlternatingBackColor = System.Drawing.Color.Khaki
      Me.tgAssetList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgAssetList.AutoColumnResize = True
      Me.tgAssetList.BackColor = System.Drawing.Color.LemonChiffon
      Me.tgAssetList.CaptionForeColor = System.Drawing.SystemColors.Window
      Me.tgAssetList.CaptionVisible = False
      Me.tgAssetList.Cellchanged = False
      Me.tgAssetList.DataMember = ""
      Me.tgAssetList.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.tgAssetList.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(120, Byte), Integer))
      Me.tgAssetList.HeaderBackColor = System.Drawing.Color.DarkGoldenrod
      Me.tgAssetList.HeaderForeColor = System.Drawing.Color.White
      Me.tgAssetList.Location = New System.Drawing.Point(16, 222)
      Me.tgAssetList.Name = "tgAssetList"
      Me.tgAssetList.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
      Me.tgAssetList.SelectionBackColor = System.Drawing.Color.Sienna
      Me.tgAssetList.Size = New System.Drawing.Size(600, 196)
      Me.tgAssetList.SortingArrowColor = System.Drawing.Color.Red
      Me.tgAssetList.TabIndex = 35
      Me.tgAssetList.TreeManager = Nothing
      '
      'lblAssetList
      '
      Me.lblAssetList.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetList.ForeColor = System.Drawing.Color.Black
      Me.lblAssetList.Location = New System.Drawing.Point(13, 201)
      Me.lblAssetList.Name = "lblAssetList"
      Me.lblAssetList.Size = New System.Drawing.Size(123, 18)
      Me.lblAssetList.TabIndex = 33
      Me.lblAssetList.Text = "ความเคลื่อนไหวสินทรัพย์"
      Me.lblAssetList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'btnAssetList
      '
      Me.btnAssetList.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetList.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetList.Location = New System.Drawing.Point(144, 196)
      Me.btnAssetList.Name = "btnAssetList"
      Me.btnAssetList.Size = New System.Drawing.Size(24, 23)
      Me.btnAssetList.TabIndex = 36
      Me.btnAssetList.TabStop = False
      Me.btnAssetList.ThemedImage = CType(resources.GetObject("btnAssetList.ThemedImage"), System.Drawing.Bitmap)
      '
      'AssetAuxDetail
      '
      Me.Controls.Add(Me.PrimaryGroupBoxControl)
      Me.Name = "AssetAuxDetail"
      Me.Size = New System.Drawing.Size(648, 470)
      Me.PrimaryGroupBoxControl.ResumeLayout(False)
      Me.grbInsurranceDetail.ResumeLayout(False)
      Me.grbInsurranceDetail.PerformLayout()
      Me.grbSaleDetail.ResumeLayout(False)
      Me.grbSaleDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgAssetList, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SelLabelText "
        Public Overrides Sub SetLabelText()
            lblSaleDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaleDate}")
            Me.Validator.SetDisplayName(txtSaleDate, lblSaleDate.Text)

            lblSalePrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSalePrice}")
            Me.Validator.SetDisplayName(txtSalePrice, lblSalePrice.Text)

            lblSaleDocCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaleDocCode}")
            Me.Validator.SetDisplayName(txtSaleDocCode, lblSaleDocCode.Text)

            lblSaleDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaleDocDate}")
            Me.Validator.SetDisplayName(txtSaleDocDate, lblSaleDocDate.Text)

            lblBuyer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblBuyer}")
            Me.Validator.SetDisplayName(txtBuyer, lblBuyer.Text)

            lblInsuranceCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsuranceCode}")
            Me.Validator.SetDisplayName(txtInsurranceCode, lblInsuranceCode.Text)

            lblSaftyCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaftyCode}")
            Me.Validator.SetDisplayName(txtSaftyCode, lblSaftyCode.Text)

            lblSaftyCompany.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaftyCompany}")
            Me.Validator.SetDisplayName(txtSaftyCompany, lblSaftyCompany.Text)

            lblInsurancePremium.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsurancePremium}")
            Me.Validator.SetDisplayName(txtInsurrancePremium, lblInsurancePremium.Text)

            lblInsuranceeAge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsuranceeAge}")
            Me.Validator.SetDisplayName(txtInsurranceAge, lblInsuranceeAge.Text)

            lblInsuranceStartDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsuranceStartDate}")
            Me.Validator.SetDisplayName(txtInsurranceStartDate, lblInsuranceStartDate.Text)

            lblInsuranceEndDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsuranceEndDate}")
            Me.Validator.SetDisplayName(txtInsurranceEndDate, lblInsuranceEndDate.Text)

            ' Description
            lblYear.Text = Me.StringParserService.Parse("${res:Global.YearText}")
            lblCurrencyUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyText}")
            ' Button 
            btnOk.Text = Me.StringParserService.Parse("${res:Global.OKButtonText}")
            btnCancel.Text = Me.StringParserService.Parse("${res:Global.CancelButtonText}")

            ' GroupBox ...
            PrimaryGroupBoxControl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.PrimaryGroupBoxControl}")
            grbSaleDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.grbSaleDetail}")
            grbInsurranceDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.grbInsurranceDetail}")

        End Sub
#End Region

#Region "Member"
        Private m_entity As Asset
        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.m_entity = CType(Entity, Asset)
        End Sub
        Public Sub New(ByVal m_entity As Asset)
            MyBase.New()
            Me.InitializeComponent()
            Me.Initialize()
            Me.Entity = m_entity
            Me.UpdateEntityProperties()
            Me.EventWiring()
            Me.SetLabelText()
        End Sub
#End Region

#Region "Property"
        Property Asset() As Asset
            Get
                Return m_entity
            End Get
            Set(ByVal Value As Asset)
                m_entity = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Sub Initialize()

        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler txtSaleDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpSaleDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtSalePrice.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtSaleDocCode.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtSaleDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpSaleDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtBuyer.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtInsurranceCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtSaftyCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtSaftyCompany.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtInsurrancePremium.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtInsurranceAge.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtInsurranceStartDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpInsurranceStartDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtInsurranceEndDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpInsurranceEndDate.ValueChanged, AddressOf Me.ChangeProperty

            ' Set Numeric Format ...
            AddHandler txtSalePrice.Validated, AddressOf Me.NumericTextBoxChanged
            AddHandler txtInsurrancePremium.Validated, AddressOf Me.NumericTextBoxChanged
            AddHandler txtInsurranceAge.Validated, AddressOf Me.NumericTextBoxChanged

        End Sub
#End Region

#Region "IListDetail"

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity.Canceled Then
                For Each grbCtrl As Control In PrimaryGroupBoxControl.Controls
                    grbCtrl.Enabled = False
                Next
            Else
                For Each grbCtrl As Control In PrimaryGroupBoxControl.Controls
                    grbCtrl.Enabled = True
                Next
            End If

            grbSaleDetail.Enabled = False

        End Sub

        ' เคลียร์ข้อมูลใน control
        Public Overrides Sub ClearDetail()
            For Each grbCtrl As Control In PrimaryGroupBoxControl.Controls
                If TypeOf grbCtrl Is FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next

            txtSaleDate.Text = ""
            dtpSaleDate.Value = Date.Now

            txtSaleDocDate.Text = ""
            dtpSaleDocDate.Value = Date.Now

            txtInsurranceStartDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            dtpInsurranceStartDate.Value = Date.Now

            txtInsurranceEndDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            dtpInsurranceEndDate.Value = Date.Now

        End Sub

        ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            If m_entity Is Nothing OrElse Not m_entity.Originated Then
                ClearDetail()
                Return
            End If

            ' ทำการผูก Property ต่าง ๆ เข้ากับ control
            txtSaleDate.Text = MinDateToNull(Me.m_entity.SaleDate, "")
            dtpSaleDate.Value = MinDateToNow(Me.m_entity.SaleDate)

            txtSalePrice.Text = Configuration.FormatToString(Me.m_entity.SalePrice, DigitConfig.Price)
            txtSaleDocCode.Text = Me.m_entity.SaleDocCode

            txtSaleDocDate.Text = MinDateToNull(Me.m_entity.SaleDocDate, "")
            dtpSaleDocDate.Value = MinDateToNow(Me.m_entity.SaleDocDate)

            txtBuyer.Text = Me.m_entity.Buyer
            txtInsurranceCode.Text = Me.m_entity.InsuranceCode

            txtSaftyCode.Text = Me.m_entity.SaftyCode
            txtSaftyCompany.Text = Me.m_entity.SaftyCompany

            txtInsurrancePremium.Text = Configuration.FormatToString(Me.m_entity.InsurancePremium, DigitConfig.Price)
            txtInsurranceAge.Text = Configuration.FormatToString(Me.m_entity.InsuranceAge, DigitConfig.Int)

            txtInsurranceStartDate.Text = MinDateToNull(Me.m_entity.InsuranceStartDate, "")
            dtpInsurranceStartDate.Value = MinDateToNow(Me.m_entity.InsuranceStartDate)

            txtInsurranceEndDate.Text = MinDateToNull(Me.m_entity.InsuranceEndDate, "")
            dtpInsurranceEndDate.Value = MinDateToNow(Me.m_entity.InsuranceEndDate)

            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True
        End Sub
        Public Sub NumericTextBoxChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If

            Select Case CType(sender, Control).Name.ToLower
                Case "txtsaleprice"
                    txtSalePrice.Text = Configuration.FormatToString(Me.m_entity.SalePrice, DigitConfig.Price)
                Case "txtinsurrancepremium"
                    txtInsurrancePremium.Text = Configuration.FormatToString(Me.m_entity.InsurancePremium, DigitConfig.Price)
                Case "txtinsurranceage"
                    txtInsurranceAge.Text = Configuration.FormatToString(Me.m_entity.InsuranceAge, DigitConfig.Int)
            End Select
        End Sub
        Private m_dateSetting As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If

            Select Case CType(sender, Control).Name.ToLower
                Case "txtsaledate"
                    m_dateSetting = True
                    If Not Me.txtSaleDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtSaleDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtSaleDate.Text)
                        If Not Me.m_entity.SaleDate.Equals(theDate) Then
                            dtpSaleDate.Value = theDate
                            Me.m_entity.SaleDate = dtpSaleDate.Value
                        End If
                    Else
                        dtpSaleDate.Value = Date.Now
                        Me.m_entity.SaleDate = Date.MinValue
                    End If
                    m_dateSetting = False
                Case "dtpsaledate"
                    If Not Me.m_entity.SaleDate.Equals(dtpSaleDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtSaleDate.Text = MinDateToNull(dtpSaleDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.SaleDate = dtpSaleDate.Value
                        End If
                    End If
                Case "txtsaleprice"
                    If txtSalePrice.TextLength > 0 Then
                        Me.m_entity.SalePrice = CDec(txtSalePrice.Text)
                    Else
                        Me.m_entity.SalePrice = Nothing
                    End If
                Case "txtsaledoccode"
                    Me.m_entity.SaleDocCode = txtSaleDocCode.Text

                Case "txtsaledocdate"
                    m_dateSetting = True
                    If Not Me.txtSaleDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtSaleDocDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtSaleDocDate.Text)
                        If Not Me.m_entity.SaleDocDate.Equals(theDate) Then
                            dtpSaleDocDate.Value = theDate
                            Me.m_entity.SaleDocDate = dtpSaleDocDate.Value
                        End If
                    Else
                        dtpSaleDocDate.Value = Date.Now
                        Me.m_entity.SaleDocDate = Date.MinValue
                    End If
                    m_dateSetting = False
                Case "dtpsaledocdate"
                    If Not Me.m_entity.SaleDocDate.Equals(dtpSaleDocDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtSaleDocDate.Text = MinDateToNull(dtpSaleDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.SaleDocDate = dtpSaleDocDate.Value
                        End If
                    End If
                Case "txtbuyer"
                    Me.m_entity.Buyer = txtBuyer.Text
                Case "txtinsurrancecode"
                    Me.m_entity.InsuranceCode = txtInsurranceCode.Text
                Case "txtsaftycode"
                    Me.m_entity.SaftyCode = txtSaftyCode.Text
                Case "txtsaftycompany"
                    Me.m_entity.SaftyCompany = txtSaftyCompany.Text
                Case "txtinsurrancepremium"
                    If txtInsurrancePremium.TextLength > 0 Then
                        Me.m_entity.InsurancePremium = CDec(txtInsurrancePremium.Text)
                    Else
                        Me.m_entity.InsurancePremium = Nothing
                    End If
                Case "txtinsurranceage"
                    If txtInsurranceAge.TextLength > 0 Then
                        Me.m_entity.InsuranceAge = CInt(txtInsurranceAge.Text)
                    Else
                        Me.m_entity.InsuranceAge = Nothing
                    End If

                Case "txtinsurrancestartdate"
                    m_dateSetting = True
                    If Not Me.txtInsurranceStartDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtInsurranceStartDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtInsurranceStartDate.Text)
                        If Not Me.m_entity.InsuranceStartDate.Equals(theDate) Then
                            dtpInsurranceStartDate.Value = theDate
                            Me.m_entity.InsuranceStartDate = dtpInsurranceStartDate.Value
                        End If
                    Else
                        dtpInsurranceStartDate.Value = Date.Now
                        Me.m_entity.InsuranceStartDate = Date.MinValue
                    End If
                    m_dateSetting = False
                Case "dtpinsurrancestartdate"
                    If Not Me.m_entity.InsuranceStartDate.Equals(dtpInsurranceStartDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtInsurranceStartDate.Text = MinDateToNull(dtpInsurranceStartDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.InsuranceStartDate = dtpInsurranceStartDate.Value
                        End If
                    End If
                Case "txtinsurranceenddate"
                    m_dateSetting = True
                    If Not Me.txtInsurranceEndDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtInsurranceEndDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtInsurranceEndDate.Text)
                        If Not Me.m_entity.InsuranceEndDate.Equals(theDate) Then
                            dtpInsurranceEndDate.Value = theDate
                            Me.m_entity.InsuranceEndDate = dtpInsurranceEndDate.Value
                        End If
                    Else
                        dtpInsurranceEndDate.Value = Date.Now
                        Me.m_entity.InsuranceEndDate = Date.MinValue
                    End If
                    m_dateSetting = False
                Case "dtpinsurranceenddate"
                    If Not Me.m_entity.InsuranceEndDate.Equals(dtpInsurranceEndDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtInsurranceEndDate.Text = MinDateToNull(dtpInsurranceEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.InsuranceEndDate = dtpInsurranceEndDate.Value
                        End If
                    End If
            End Select

            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = True
        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = CType(Value, Asset)
                Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
                Me.SaveProperties()
                'Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
                EventWiring()
            End Set
        End Property

#End Region

#Region " Ivalidator "
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "IHelperCapable"
        Public ReadOnly Property Helpers() As HelperCollection Implements IHelperCapable.Helpers
            Get

            End Get
        End Property

        Public Sub LoadHelpers() Implements IHelperCapable.LoadHelpers

        End Sub

        Public Sub UpdateValue(ByVal value As BusinessLogic.BusinessEntity) Implements IHelperCapable.UpdateValue

        End Sub

#End Region

#Region "Member Old Entity"
        Private m_oldstatusisdirty As Boolean
        Private m_oldsaledate As DateTime
        Private m_oldsaleprice As Decimal
        Private m_oldsaledoccode As String
        Private m_oldsaledocdate As DateTime
        Private m_oldbuyer As String
        Private m_oldinsurancecode As String
        Private m_oldsaftycode As String
        Private m_oldsaftycompany As String
        Private m_oldinsurancepremium As Decimal
        Private m_oldinsuranceage As Integer
        Private m_oldinsurancestartdate As DateTime
        Private m_oldinsuranceenddate As DateTime
#End Region

#Region " IReversibleEntityProperty "
        Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = m_oldstatusisdirty
            Me.m_entity.SaleDate = m_oldsaledate
            Me.m_entity.SalePrice = m_oldsaleprice
            Me.m_entity.SaleDocCode = m_oldsaledoccode
            Me.m_entity.SaleDocDate = m_oldsaledocdate
            Me.m_entity.Buyer = m_oldbuyer
            Me.m_entity.InsuranceCode = m_oldinsurancecode
            Me.m_entity.SaftyCode = m_oldsaftycode
            Me.m_entity.SaftyCompany = m_oldsaftycompany
            Me.m_entity.InsurancePremium = m_oldinsurancepremium
            Me.m_entity.InsuranceAge = m_oldinsuranceage
            Me.m_entity.InsuranceStartDate = m_oldinsurancestartdate
            Me.m_entity.InsuranceEndDate = m_oldinsuranceenddate
        End Sub

        Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            m_oldstatusisdirty = myContent.IsDirty
            m_oldsaledate = Me.m_entity.SaleDate
            m_oldsaleprice = Me.m_entity.SalePrice
            m_oldsaledoccode = Me.m_entity.SaleDocCode
            m_oldsaledocdate = Me.m_entity.SaleDocDate
            m_oldbuyer = Me.m_entity.Buyer
            m_oldinsurancecode = Me.m_entity.InsuranceCode
            m_oldsaftycode = Me.m_entity.SaftyCode
            m_oldsaftycompany = Me.m_entity.SaftyCompany
            m_oldinsurancepremium = Me.m_entity.InsurancePremium
            m_oldinsuranceage = Me.m_entity.InsuranceAge
            m_oldinsuranceenddate = Me.m_entity.InsuranceStartDate
            m_oldinsuranceenddate = Me.m_entity.InsuranceEndDate
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.RevertProperties()
        End Sub
#End Region

    End Class

End Namespace
