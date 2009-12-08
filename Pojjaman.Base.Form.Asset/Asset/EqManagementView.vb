Imports system.Configuration
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class EqManagementView
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
        Friend WithEvents btnWithdraw As System.Windows.Forms.Button
        Friend WithEvents btnReturn As System.Windows.Forms.Button
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents txtLocation As System.Windows.Forms.TextBox
        Friend WithEvents txtLocation1 As System.Windows.Forms.TextBox
        Friend WithEvents grbYTD As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtInternal As System.Windows.Forms.TextBox
        Friend WithEvents lblInternal As System.Windows.Forms.Label
        Friend WithEvents lblExternal As System.Windows.Forms.Label
        Friend WithEvents txtExternal As System.Windows.Forms.TextBox
        Friend WithEvents lblMaintenance As System.Windows.Forms.Label
        Friend WithEvents txtMaintenance As System.Windows.Forms.TextBox
        Friend WithEvents lblDepre As System.Windows.Forms.Label
        Friend WithEvents txtDepre As System.Windows.Forms.TextBox
        Friend WithEvents lblProfit As System.Windows.Forms.Label
        Friend WithEvents txtProfit As System.Windows.Forms.TextBox
        Friend WithEvents grbLTD As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtInternal1 As System.Windows.Forms.TextBox
        Friend WithEvents lblInternal1 As System.Windows.Forms.Label
        Friend WithEvents lblExternal1 As System.Windows.Forms.Label
        Friend WithEvents txtExternal1 As System.Windows.Forms.TextBox
        Friend WithEvents lblMaintenance1 As System.Windows.Forms.Label
        Friend WithEvents txtMaintenance1 As System.Windows.Forms.TextBox
        Friend WithEvents lblDepre1 As System.Windows.Forms.Label
        Friend WithEvents txtDepre1 As System.Windows.Forms.TextBox
        Friend WithEvents lblProfit1 As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtAssetCode As System.Windows.Forms.TextBox
        Friend WithEvents lblAsset As System.Windows.Forms.Label
        Friend WithEvents txtAssetName As System.Windows.Forms.TextBox
        Friend WithEvents lblAssetStatus As System.Windows.Forms.Label
        Friend WithEvents txtAssetStatus As System.Windows.Forms.TextBox
        Friend WithEvents txtBuyDate As System.Windows.Forms.TextBox
        Friend WithEvents lblBuyDate As System.Windows.Forms.Label
        Friend WithEvents txtBuyPrice As System.Windows.Forms.TextBox
        Friend WithEvents lblBuyPrice As System.Windows.Forms.Label
        Friend WithEvents lblCurrency1 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency2 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency3 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency4 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency5 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency6 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency7 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency8 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency9 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency10 As System.Windows.Forms.Label
        Friend WithEvents lblCurrency11 As System.Windows.Forms.Label
        Friend WithEvents dtpBuyDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtProfit1 As System.Windows.Forms.TextBox
        Friend WithEvents lblYTDLastDate As System.Windows.Forms.Label
        Friend WithEvents txtYTDLastDate As System.Windows.Forms.TextBox
        Friend WithEvents lblLTDLastDate As System.Windows.Forms.Label
        Friend WithEvents txtLTDLastDate As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.txtAssetCode = New System.Windows.Forms.TextBox
            Me.lblAsset = New System.Windows.Forms.Label
            Me.btnWithdraw = New System.Windows.Forms.Button
            Me.btnReturn = New System.Windows.Forms.Button
            Me.txtAssetName = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblAssetStatus = New System.Windows.Forms.Label
            Me.txtAssetStatus = New System.Windows.Forms.TextBox
            Me.lblLocation = New System.Windows.Forms.Label
            Me.txtBuyDate = New System.Windows.Forms.TextBox
            Me.lblBuyDate = New System.Windows.Forms.Label
            Me.txtLocation = New System.Windows.Forms.TextBox
            Me.txtLocation1 = New System.Windows.Forms.TextBox
            Me.txtBuyPrice = New System.Windows.Forms.TextBox
            Me.lblBuyPrice = New System.Windows.Forms.Label
            Me.lblCurrency1 = New System.Windows.Forms.Label
            Me.dtpBuyDate = New System.Windows.Forms.DateTimePicker
            Me.grbYTD = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblYTDLastDate = New System.Windows.Forms.Label
            Me.txtYTDLastDate = New System.Windows.Forms.TextBox
            Me.lblCurrency2 = New System.Windows.Forms.Label
            Me.txtInternal = New System.Windows.Forms.TextBox
            Me.lblInternal = New System.Windows.Forms.Label
            Me.lblExternal = New System.Windows.Forms.Label
            Me.txtExternal = New System.Windows.Forms.TextBox
            Me.lblCurrency3 = New System.Windows.Forms.Label
            Me.lblCurrency4 = New System.Windows.Forms.Label
            Me.lblMaintenance = New System.Windows.Forms.Label
            Me.txtMaintenance = New System.Windows.Forms.TextBox
            Me.lblCurrency5 = New System.Windows.Forms.Label
            Me.lblDepre = New System.Windows.Forms.Label
            Me.txtDepre = New System.Windows.Forms.TextBox
            Me.lblCurrency6 = New System.Windows.Forms.Label
            Me.lblProfit = New System.Windows.Forms.Label
            Me.txtProfit = New System.Windows.Forms.TextBox
            Me.grbLTD = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblLTDLastDate = New System.Windows.Forms.Label
            Me.txtLTDLastDate = New System.Windows.Forms.TextBox
            Me.lblCurrency7 = New System.Windows.Forms.Label
            Me.txtInternal1 = New System.Windows.Forms.TextBox
            Me.lblInternal1 = New System.Windows.Forms.Label
            Me.lblExternal1 = New System.Windows.Forms.Label
            Me.txtExternal1 = New System.Windows.Forms.TextBox
            Me.lblCurrency8 = New System.Windows.Forms.Label
            Me.lblCurrency9 = New System.Windows.Forms.Label
            Me.lblMaintenance1 = New System.Windows.Forms.Label
            Me.txtMaintenance1 = New System.Windows.Forms.TextBox
            Me.lblCurrency10 = New System.Windows.Forms.Label
            Me.lblDepre1 = New System.Windows.Forms.Label
            Me.txtDepre1 = New System.Windows.Forms.TextBox
            Me.lblCurrency11 = New System.Windows.Forms.Label
            Me.lblProfit1 = New System.Windows.Forms.Label
            Me.txtProfit1 = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbDetail.SuspendLayout()
            Me.grbYTD.SuspendLayout()
            Me.grbLTD.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtAssetCode
            '
            Me.Validator.SetDataType(Me.txtAssetCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAssetCode, "")
            Me.txtAssetCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAssetCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAssetCode, System.Drawing.Color.Empty)
            Me.txtAssetCode.Location = New System.Drawing.Point(120, 16)
            Me.Validator.SetMaxValue(Me.txtAssetCode, "")
            Me.Validator.SetMinValue(Me.txtAssetCode, "")
            Me.txtAssetCode.Name = "txtAssetCode"
            Me.txtAssetCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAssetCode, "")
            Me.Validator.SetRequired(Me.txtAssetCode, False)
            Me.txtAssetCode.Size = New System.Drawing.Size(104, 21)
            Me.txtAssetCode.TabIndex = 199
            Me.txtAssetCode.Text = ""
            '
            'lblAsset
            '
            Me.lblAsset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAsset.ForeColor = System.Drawing.Color.Black
            Me.lblAsset.Location = New System.Drawing.Point(8, 16)
            Me.lblAsset.Name = "lblAsset"
            Me.lblAsset.Size = New System.Drawing.Size(104, 18)
            Me.lblAsset.TabIndex = 200
            Me.lblAsset.Text = "เครื่องจักร:"
            Me.lblAsset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnWithdraw
            '
            Me.btnWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnWithdraw.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnWithdraw.Location = New System.Drawing.Point(408, 336)
            Me.btnWithdraw.Name = "btnWithdraw"
            Me.btnWithdraw.TabIndex = 203
            Me.btnWithdraw.Text = "เบิกใช้"
            '
            'btnReturn
            '
            Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReturn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturn.Location = New System.Drawing.Point(488, 336)
            Me.btnReturn.Name = "btnReturn"
            Me.btnReturn.TabIndex = 203
            Me.btnReturn.Text = "คืน"
            '
            'txtAssetName
            '
            Me.Validator.SetDataType(Me.txtAssetName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAssetName, "")
            Me.txtAssetName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAssetName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAssetName, System.Drawing.Color.Empty)
            Me.txtAssetName.Location = New System.Drawing.Point(224, 16)
            Me.Validator.SetMaxValue(Me.txtAssetName, "")
            Me.Validator.SetMinValue(Me.txtAssetName, "")
            Me.txtAssetName.Name = "txtAssetName"
            Me.txtAssetName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAssetName, "")
            Me.Validator.SetRequired(Me.txtAssetName, False)
            Me.txtAssetName.Size = New System.Drawing.Size(224, 21)
            Me.txtAssetName.TabIndex = 199
            Me.txtAssetName.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.lblAsset)
            Me.grbDetail.Controls.Add(Me.txtAssetCode)
            Me.grbDetail.Controls.Add(Me.txtAssetName)
            Me.grbDetail.Controls.Add(Me.lblAssetStatus)
            Me.grbDetail.Controls.Add(Me.txtAssetStatus)
            Me.grbDetail.Controls.Add(Me.lblLocation)
            Me.grbDetail.Controls.Add(Me.txtBuyDate)
            Me.grbDetail.Controls.Add(Me.lblBuyDate)
            Me.grbDetail.Controls.Add(Me.txtLocation)
            Me.grbDetail.Controls.Add(Me.txtLocation1)
            Me.grbDetail.Controls.Add(Me.txtBuyPrice)
            Me.grbDetail.Controls.Add(Me.lblBuyPrice)
            Me.grbDetail.Controls.Add(Me.lblCurrency1)
            Me.grbDetail.Controls.Add(Me.dtpBuyDate)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(624, 120)
            Me.grbDetail.TabIndex = 204
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลเครื่องจักร"
            '
            'lblAssetStatus
            '
            Me.lblAssetStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAssetStatus.ForeColor = System.Drawing.Color.Black
            Me.lblAssetStatus.Location = New System.Drawing.Point(8, 40)
            Me.lblAssetStatus.Name = "lblAssetStatus"
            Me.lblAssetStatus.Size = New System.Drawing.Size(104, 18)
            Me.lblAssetStatus.TabIndex = 200
            Me.lblAssetStatus.Text = "สถานะ:"
            Me.lblAssetStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAssetStatus
            '
            Me.Validator.SetDataType(Me.txtAssetStatus, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAssetStatus, "")
            Me.txtAssetStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAssetStatus, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAssetStatus, System.Drawing.Color.Empty)
            Me.txtAssetStatus.Location = New System.Drawing.Point(120, 40)
            Me.Validator.SetMaxValue(Me.txtAssetStatus, "")
            Me.Validator.SetMinValue(Me.txtAssetStatus, "")
            Me.txtAssetStatus.Name = "txtAssetStatus"
            Me.txtAssetStatus.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAssetStatus, "")
            Me.Validator.SetRequired(Me.txtAssetStatus, False)
            Me.txtAssetStatus.Size = New System.Drawing.Size(104, 21)
            Me.txtAssetStatus.TabIndex = 199
            Me.txtAssetStatus.Text = "ว่าง/ใช้งาน/ซ่อม"
            '
            'lblLocation
            '
            Me.lblLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.Black
            Me.lblLocation.Location = New System.Drawing.Point(8, 64)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(104, 18)
            Me.lblLocation.TabIndex = 200
            Me.lblLocation.Text = "Location ล่าสุด:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBuyDate
            '
            Me.Validator.SetDataType(Me.txtBuyDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBuyDate, "")
            Me.txtBuyDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBuyDate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBuyDate, System.Drawing.Color.Empty)
            Me.txtBuyDate.Location = New System.Drawing.Point(120, 88)
            Me.Validator.SetMaxValue(Me.txtBuyDate, "")
            Me.Validator.SetMinValue(Me.txtBuyDate, "")
            Me.txtBuyDate.Name = "txtBuyDate"
            Me.txtBuyDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBuyDate, "")
            Me.Validator.SetRequired(Me.txtBuyDate, False)
            Me.txtBuyDate.Size = New System.Drawing.Size(104, 21)
            Me.txtBuyDate.TabIndex = 199
            Me.txtBuyDate.Text = ""
            '
            'lblBuyDate
            '
            Me.lblBuyDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBuyDate.ForeColor = System.Drawing.Color.Black
            Me.lblBuyDate.Location = New System.Drawing.Point(8, 88)
            Me.lblBuyDate.Name = "lblBuyDate"
            Me.lblBuyDate.Size = New System.Drawing.Size(104, 18)
            Me.lblBuyDate.TabIndex = 200
            Me.lblBuyDate.Text = "วันที่ซื้อ:"
            Me.lblBuyDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLocation
            '
            Me.Validator.SetDataType(Me.txtLocation, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLocation, "")
            Me.txtLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLocation, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLocation, System.Drawing.Color.Empty)
            Me.txtLocation.Location = New System.Drawing.Point(120, 64)
            Me.Validator.SetMaxValue(Me.txtLocation, "")
            Me.Validator.SetMinValue(Me.txtLocation, "")
            Me.txtLocation.Name = "txtLocation"
            Me.txtLocation.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtLocation, "")
            Me.Validator.SetRequired(Me.txtLocation, False)
            Me.txtLocation.Size = New System.Drawing.Size(104, 21)
            Me.txtLocation.TabIndex = 199
            Me.txtLocation.Text = ""
            '
            'txtLocation1
            '
            Me.Validator.SetDataType(Me.txtLocation1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLocation1, "")
            Me.txtLocation1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLocation1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLocation1, System.Drawing.Color.Empty)
            Me.txtLocation1.Location = New System.Drawing.Point(224, 64)
            Me.Validator.SetMaxValue(Me.txtLocation1, "")
            Me.Validator.SetMinValue(Me.txtLocation1, "")
            Me.txtLocation1.Name = "txtLocation1"
            Me.txtLocation1.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtLocation1, "")
            Me.Validator.SetRequired(Me.txtLocation1, False)
            Me.txtLocation1.Size = New System.Drawing.Size(224, 21)
            Me.txtLocation1.TabIndex = 199
            Me.txtLocation1.Text = ""
            '
            'txtBuyPrice
            '
            Me.Validator.SetDataType(Me.txtBuyPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBuyPrice, "")
            Me.txtBuyPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBuyPrice, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBuyPrice, System.Drawing.Color.Empty)
            Me.txtBuyPrice.Location = New System.Drawing.Point(344, 88)
            Me.Validator.SetMaxValue(Me.txtBuyPrice, "")
            Me.Validator.SetMinValue(Me.txtBuyPrice, "")
            Me.txtBuyPrice.Name = "txtBuyPrice"
            Me.txtBuyPrice.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBuyPrice, "")
            Me.Validator.SetRequired(Me.txtBuyPrice, False)
            Me.txtBuyPrice.Size = New System.Drawing.Size(104, 21)
            Me.txtBuyPrice.TabIndex = 199
            Me.txtBuyPrice.Text = ""
            Me.txtBuyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblBuyPrice
            '
            Me.lblBuyPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBuyPrice.ForeColor = System.Drawing.Color.Black
            Me.lblBuyPrice.Location = New System.Drawing.Point(248, 88)
            Me.lblBuyPrice.Name = "lblBuyPrice"
            Me.lblBuyPrice.Size = New System.Drawing.Size(88, 18)
            Me.lblBuyPrice.TabIndex = 200
            Me.lblBuyPrice.Text = "ราคาซื้อ:"
            Me.lblBuyPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrency1
            '
            Me.lblCurrency1.AutoSize = True
            Me.lblCurrency1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency1.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency1.Location = New System.Drawing.Point(456, 88)
            Me.lblCurrency1.Name = "lblCurrency1"
            Me.lblCurrency1.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency1.TabIndex = 200
            Me.lblCurrency1.Text = "บาท"
            Me.lblCurrency1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpBuyDate
            '
            Me.dtpBuyDate.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBuyDate.Location = New System.Drawing.Point(120, 88)
            Me.dtpBuyDate.Name = "dtpBuyDate"
            Me.dtpBuyDate.Size = New System.Drawing.Size(124, 21)
            Me.dtpBuyDate.TabIndex = 201
            '
            'grbYTD
            '
            Me.grbYTD.Controls.Add(Me.lblYTDLastDate)
            Me.grbYTD.Controls.Add(Me.txtYTDLastDate)
            Me.grbYTD.Controls.Add(Me.lblCurrency2)
            Me.grbYTD.Controls.Add(Me.txtInternal)
            Me.grbYTD.Controls.Add(Me.lblInternal)
            Me.grbYTD.Controls.Add(Me.lblExternal)
            Me.grbYTD.Controls.Add(Me.txtExternal)
            Me.grbYTD.Controls.Add(Me.lblCurrency3)
            Me.grbYTD.Controls.Add(Me.lblCurrency4)
            Me.grbYTD.Controls.Add(Me.lblMaintenance)
            Me.grbYTD.Controls.Add(Me.txtMaintenance)
            Me.grbYTD.Controls.Add(Me.lblCurrency5)
            Me.grbYTD.Controls.Add(Me.lblDepre)
            Me.grbYTD.Controls.Add(Me.txtDepre)
            Me.grbYTD.Controls.Add(Me.lblCurrency6)
            Me.grbYTD.Controls.Add(Me.lblProfit)
            Me.grbYTD.Controls.Add(Me.txtProfit)
            Me.grbYTD.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbYTD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbYTD.Location = New System.Drawing.Point(8, 136)
            Me.grbYTD.Name = "grbYTD"
            Me.grbYTD.Size = New System.Drawing.Size(312, 176)
            Me.grbYTD.TabIndex = 201
            Me.grbYTD.TabStop = False
            Me.grbYTD.Text = "สรุปรายได้(Year-to-date)"
            '
            'lblYTDLastDate
            '
            Me.lblYTDLastDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblYTDLastDate.ForeColor = System.Drawing.Color.Black
            Me.lblYTDLastDate.Location = New System.Drawing.Point(8, 24)
            Me.lblYTDLastDate.Name = "lblYTDLastDate"
            Me.lblYTDLastDate.Size = New System.Drawing.Size(144, 18)
            Me.lblYTDLastDate.TabIndex = 203
            Me.lblYTDLastDate.Text = "วันที่ซื้อ:"
            Me.lblYTDLastDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtYTDLastDate
            '
            Me.Validator.SetDataType(Me.txtYTDLastDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtYTDLastDate, "")
            Me.txtYTDLastDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtYTDLastDate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtYTDLastDate, System.Drawing.Color.Empty)
            Me.txtYTDLastDate.Location = New System.Drawing.Point(152, 24)
            Me.Validator.SetMaxValue(Me.txtYTDLastDate, "")
            Me.Validator.SetMinValue(Me.txtYTDLastDate, "")
            Me.txtYTDLastDate.Name = "txtYTDLastDate"
            Me.txtYTDLastDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtYTDLastDate, "")
            Me.Validator.SetRequired(Me.txtYTDLastDate, False)
            Me.txtYTDLastDate.Size = New System.Drawing.Size(112, 21)
            Me.txtYTDLastDate.TabIndex = 202
            Me.txtYTDLastDate.Text = ""
            '
            'lblCurrency2
            '
            Me.lblCurrency2.AutoSize = True
            Me.lblCurrency2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency2.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency2.Location = New System.Drawing.Point(272, 48)
            Me.lblCurrency2.Name = "lblCurrency2"
            Me.lblCurrency2.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency2.TabIndex = 200
            Me.lblCurrency2.Text = "บาท"
            Me.lblCurrency2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtInternal
            '
            Me.Validator.SetDataType(Me.txtInternal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtInternal, "")
            Me.txtInternal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtInternal, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtInternal, System.Drawing.Color.Empty)
            Me.txtInternal.Location = New System.Drawing.Point(152, 48)
            Me.Validator.SetMaxValue(Me.txtInternal, "")
            Me.Validator.SetMinValue(Me.txtInternal, "")
            Me.txtInternal.Name = "txtInternal"
            Me.txtInternal.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtInternal, "")
            Me.Validator.SetRequired(Me.txtInternal, False)
            Me.txtInternal.Size = New System.Drawing.Size(112, 21)
            Me.txtInternal.TabIndex = 199
            Me.txtInternal.Text = ""
            Me.txtInternal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblInternal
            '
            Me.lblInternal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInternal.ForeColor = System.Drawing.Color.Black
            Me.lblInternal.Location = New System.Drawing.Point(8, 48)
            Me.lblInternal.Name = "lblInternal"
            Me.lblInternal.Size = New System.Drawing.Size(144, 18)
            Me.lblInternal.TabIndex = 200
            Me.lblInternal.Text = "รายได้ภายใน:"
            Me.lblInternal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblExternal
            '
            Me.lblExternal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblExternal.ForeColor = System.Drawing.Color.Black
            Me.lblExternal.Location = New System.Drawing.Point(8, 72)
            Me.lblExternal.Name = "lblExternal"
            Me.lblExternal.Size = New System.Drawing.Size(144, 18)
            Me.lblExternal.TabIndex = 200
            Me.lblExternal.Text = "รายได้ภายนอก:"
            Me.lblExternal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtExternal
            '
            Me.Validator.SetDataType(Me.txtExternal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtExternal, "")
            Me.txtExternal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtExternal, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtExternal, System.Drawing.Color.Empty)
            Me.txtExternal.Location = New System.Drawing.Point(152, 72)
            Me.Validator.SetMaxValue(Me.txtExternal, "")
            Me.Validator.SetMinValue(Me.txtExternal, "")
            Me.txtExternal.Name = "txtExternal"
            Me.txtExternal.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtExternal, "")
            Me.Validator.SetRequired(Me.txtExternal, False)
            Me.txtExternal.Size = New System.Drawing.Size(112, 21)
            Me.txtExternal.TabIndex = 199
            Me.txtExternal.Text = ""
            Me.txtExternal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblCurrency3
            '
            Me.lblCurrency3.AutoSize = True
            Me.lblCurrency3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency3.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency3.Location = New System.Drawing.Point(272, 72)
            Me.lblCurrency3.Name = "lblCurrency3"
            Me.lblCurrency3.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency3.TabIndex = 200
            Me.lblCurrency3.Text = "บาท"
            Me.lblCurrency3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCurrency4
            '
            Me.lblCurrency4.AutoSize = True
            Me.lblCurrency4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency4.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency4.Location = New System.Drawing.Point(272, 96)
            Me.lblCurrency4.Name = "lblCurrency4"
            Me.lblCurrency4.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency4.TabIndex = 200
            Me.lblCurrency4.Text = "บาท"
            Me.lblCurrency4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMaintenance
            '
            Me.lblMaintenance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMaintenance.ForeColor = System.Drawing.Color.Black
            Me.lblMaintenance.Location = New System.Drawing.Point(8, 96)
            Me.lblMaintenance.Name = "lblMaintenance"
            Me.lblMaintenance.Size = New System.Drawing.Size(144, 18)
            Me.lblMaintenance.TabIndex = 200
            Me.lblMaintenance.Text = "รวมค่าซ่อมบำรุง"
            Me.lblMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMaintenance
            '
            Me.Validator.SetDataType(Me.txtMaintenance, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMaintenance, "")
            Me.txtMaintenance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtMaintenance, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMaintenance, System.Drawing.Color.Empty)
            Me.txtMaintenance.Location = New System.Drawing.Point(152, 96)
            Me.Validator.SetMaxValue(Me.txtMaintenance, "")
            Me.Validator.SetMinValue(Me.txtMaintenance, "")
            Me.txtMaintenance.Name = "txtMaintenance"
            Me.txtMaintenance.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMaintenance, "")
            Me.Validator.SetRequired(Me.txtMaintenance, False)
            Me.txtMaintenance.Size = New System.Drawing.Size(112, 21)
            Me.txtMaintenance.TabIndex = 199
            Me.txtMaintenance.Text = ""
            Me.txtMaintenance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblCurrency5
            '
            Me.lblCurrency5.AutoSize = True
            Me.lblCurrency5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency5.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency5.Location = New System.Drawing.Point(272, 120)
            Me.lblCurrency5.Name = "lblCurrency5"
            Me.lblCurrency5.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency5.TabIndex = 200
            Me.lblCurrency5.Text = "บาท"
            Me.lblCurrency5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDepre
            '
            Me.lblDepre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDepre.ForeColor = System.Drawing.Color.Black
            Me.lblDepre.Location = New System.Drawing.Point(8, 120)
            Me.lblDepre.Name = "lblDepre"
            Me.lblDepre.Size = New System.Drawing.Size(144, 18)
            Me.lblDepre.TabIndex = 200
            Me.lblDepre.Text = "รวมค่าเสื่อม"
            Me.lblDepre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDepre
            '
            Me.Validator.SetDataType(Me.txtDepre, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDepre, "")
            Me.txtDepre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDepre, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDepre, System.Drawing.Color.Empty)
            Me.txtDepre.Location = New System.Drawing.Point(152, 120)
            Me.Validator.SetMaxValue(Me.txtDepre, "")
            Me.Validator.SetMinValue(Me.txtDepre, "")
            Me.txtDepre.Name = "txtDepre"
            Me.txtDepre.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDepre, "")
            Me.Validator.SetRequired(Me.txtDepre, False)
            Me.txtDepre.Size = New System.Drawing.Size(112, 21)
            Me.txtDepre.TabIndex = 199
            Me.txtDepre.Text = ""
            Me.txtDepre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblCurrency6
            '
            Me.lblCurrency6.AutoSize = True
            Me.lblCurrency6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency6.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency6.Location = New System.Drawing.Point(272, 144)
            Me.lblCurrency6.Name = "lblCurrency6"
            Me.lblCurrency6.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency6.TabIndex = 200
            Me.lblCurrency6.Text = "บาท"
            Me.lblCurrency6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblProfit
            '
            Me.lblProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProfit.ForeColor = System.Drawing.Color.Black
            Me.lblProfit.Location = New System.Drawing.Point(8, 144)
            Me.lblProfit.Name = "lblProfit"
            Me.lblProfit.Size = New System.Drawing.Size(144, 18)
            Me.lblProfit.TabIndex = 200
            Me.lblProfit.Text = "กำไร/ขาดทุน"
            Me.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtProfit
            '
            Me.Validator.SetDataType(Me.txtProfit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProfit, "")
            Me.txtProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProfit, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProfit, System.Drawing.Color.Empty)
            Me.txtProfit.Location = New System.Drawing.Point(152, 144)
            Me.Validator.SetMaxValue(Me.txtProfit, "")
            Me.Validator.SetMinValue(Me.txtProfit, "")
            Me.txtProfit.Name = "txtProfit"
            Me.txtProfit.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProfit, "")
            Me.Validator.SetRequired(Me.txtProfit, False)
            Me.txtProfit.Size = New System.Drawing.Size(112, 21)
            Me.txtProfit.TabIndex = 199
            Me.txtProfit.Text = ""
            Me.txtProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'grbLTD
            '
            Me.grbLTD.Controls.Add(Me.lblLTDLastDate)
            Me.grbLTD.Controls.Add(Me.txtLTDLastDate)
            Me.grbLTD.Controls.Add(Me.lblCurrency7)
            Me.grbLTD.Controls.Add(Me.txtInternal1)
            Me.grbLTD.Controls.Add(Me.lblInternal1)
            Me.grbLTD.Controls.Add(Me.lblExternal1)
            Me.grbLTD.Controls.Add(Me.txtExternal1)
            Me.grbLTD.Controls.Add(Me.lblCurrency8)
            Me.grbLTD.Controls.Add(Me.lblCurrency9)
            Me.grbLTD.Controls.Add(Me.lblMaintenance1)
            Me.grbLTD.Controls.Add(Me.txtMaintenance1)
            Me.grbLTD.Controls.Add(Me.lblCurrency10)
            Me.grbLTD.Controls.Add(Me.lblDepre1)
            Me.grbLTD.Controls.Add(Me.txtDepre1)
            Me.grbLTD.Controls.Add(Me.lblCurrency11)
            Me.grbLTD.Controls.Add(Me.lblProfit1)
            Me.grbLTD.Controls.Add(Me.txtProfit1)
            Me.grbLTD.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbLTD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbLTD.Location = New System.Drawing.Point(320, 136)
            Me.grbLTD.Name = "grbLTD"
            Me.grbLTD.Size = New System.Drawing.Size(312, 176)
            Me.grbLTD.TabIndex = 201
            Me.grbLTD.TabStop = False
            Me.grbLTD.Text = "สรุปรายได้(Life-to-date)"
            '
            'lblLTDLastDate
            '
            Me.lblLTDLastDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLTDLastDate.ForeColor = System.Drawing.Color.Black
            Me.lblLTDLastDate.Location = New System.Drawing.Point(8, 24)
            Me.lblLTDLastDate.Name = "lblLTDLastDate"
            Me.lblLTDLastDate.Size = New System.Drawing.Size(144, 18)
            Me.lblLTDLastDate.TabIndex = 203
            Me.lblLTDLastDate.Text = "วันที่ซื้อ:"
            Me.lblLTDLastDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLTDLastDate
            '
            Me.Validator.SetDataType(Me.txtLTDLastDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLTDLastDate, "")
            Me.txtLTDLastDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLTDLastDate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLTDLastDate, System.Drawing.Color.Empty)
            Me.txtLTDLastDate.Location = New System.Drawing.Point(152, 24)
            Me.Validator.SetMaxValue(Me.txtLTDLastDate, "")
            Me.Validator.SetMinValue(Me.txtLTDLastDate, "")
            Me.txtLTDLastDate.Name = "txtLTDLastDate"
            Me.txtLTDLastDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtLTDLastDate, "")
            Me.Validator.SetRequired(Me.txtLTDLastDate, False)
            Me.txtLTDLastDate.Size = New System.Drawing.Size(112, 21)
            Me.txtLTDLastDate.TabIndex = 202
            Me.txtLTDLastDate.Text = ""
            '
            'lblCurrency7
            '
            Me.lblCurrency7.AutoSize = True
            Me.lblCurrency7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency7.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency7.Location = New System.Drawing.Point(272, 48)
            Me.lblCurrency7.Name = "lblCurrency7"
            Me.lblCurrency7.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency7.TabIndex = 200
            Me.lblCurrency7.Text = "บาท"
            Me.lblCurrency7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtInternal1
            '
            Me.Validator.SetDataType(Me.txtInternal1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtInternal1, "")
            Me.txtInternal1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtInternal1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtInternal1, System.Drawing.Color.Empty)
            Me.txtInternal1.Location = New System.Drawing.Point(152, 48)
            Me.Validator.SetMaxValue(Me.txtInternal1, "")
            Me.Validator.SetMinValue(Me.txtInternal1, "")
            Me.txtInternal1.Name = "txtInternal1"
            Me.txtInternal1.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtInternal1, "")
            Me.Validator.SetRequired(Me.txtInternal1, False)
            Me.txtInternal1.Size = New System.Drawing.Size(112, 21)
            Me.txtInternal1.TabIndex = 199
            Me.txtInternal1.Text = ""
            Me.txtInternal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblInternal1
            '
            Me.lblInternal1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInternal1.ForeColor = System.Drawing.Color.Black
            Me.lblInternal1.Location = New System.Drawing.Point(8, 48)
            Me.lblInternal1.Name = "lblInternal1"
            Me.lblInternal1.Size = New System.Drawing.Size(144, 18)
            Me.lblInternal1.TabIndex = 200
            Me.lblInternal1.Text = "รายได้ภายใน:"
            Me.lblInternal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblExternal1
            '
            Me.lblExternal1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblExternal1.ForeColor = System.Drawing.Color.Black
            Me.lblExternal1.Location = New System.Drawing.Point(8, 72)
            Me.lblExternal1.Name = "lblExternal1"
            Me.lblExternal1.Size = New System.Drawing.Size(144, 18)
            Me.lblExternal1.TabIndex = 200
            Me.lblExternal1.Text = "Total Ext. Income"
            Me.lblExternal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtExternal1
            '
            Me.Validator.SetDataType(Me.txtExternal1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtExternal1, "")
            Me.txtExternal1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtExternal1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtExternal1, System.Drawing.Color.Empty)
            Me.txtExternal1.Location = New System.Drawing.Point(152, 72)
            Me.Validator.SetMaxValue(Me.txtExternal1, "")
            Me.Validator.SetMinValue(Me.txtExternal1, "")
            Me.txtExternal1.Name = "txtExternal1"
            Me.txtExternal1.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtExternal1, "")
            Me.Validator.SetRequired(Me.txtExternal1, False)
            Me.txtExternal1.Size = New System.Drawing.Size(112, 21)
            Me.txtExternal1.TabIndex = 199
            Me.txtExternal1.Text = ""
            Me.txtExternal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblCurrency8
            '
            Me.lblCurrency8.AutoSize = True
            Me.lblCurrency8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency8.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency8.Location = New System.Drawing.Point(272, 72)
            Me.lblCurrency8.Name = "lblCurrency8"
            Me.lblCurrency8.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency8.TabIndex = 200
            Me.lblCurrency8.Text = "บาท"
            Me.lblCurrency8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCurrency9
            '
            Me.lblCurrency9.AutoSize = True
            Me.lblCurrency9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency9.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency9.Location = New System.Drawing.Point(272, 96)
            Me.lblCurrency9.Name = "lblCurrency9"
            Me.lblCurrency9.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency9.TabIndex = 200
            Me.lblCurrency9.Text = "บาท"
            Me.lblCurrency9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMaintenance1
            '
            Me.lblMaintenance1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMaintenance1.ForeColor = System.Drawing.Color.Black
            Me.lblMaintenance1.Location = New System.Drawing.Point(8, 96)
            Me.lblMaintenance1.Name = "lblMaintenance1"
            Me.lblMaintenance1.Size = New System.Drawing.Size(144, 18)
            Me.lblMaintenance1.TabIndex = 200
            Me.lblMaintenance1.Text = "Total Maintenance Amount"
            Me.lblMaintenance1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMaintenance1
            '
            Me.Validator.SetDataType(Me.txtMaintenance1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMaintenance1, "")
            Me.txtMaintenance1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtMaintenance1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMaintenance1, System.Drawing.Color.Empty)
            Me.txtMaintenance1.Location = New System.Drawing.Point(152, 96)
            Me.Validator.SetMaxValue(Me.txtMaintenance1, "")
            Me.Validator.SetMinValue(Me.txtMaintenance1, "")
            Me.txtMaintenance1.Name = "txtMaintenance1"
            Me.txtMaintenance1.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMaintenance1, "")
            Me.Validator.SetRequired(Me.txtMaintenance1, False)
            Me.txtMaintenance1.Size = New System.Drawing.Size(112, 21)
            Me.txtMaintenance1.TabIndex = 199
            Me.txtMaintenance1.Text = ""
            Me.txtMaintenance1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblCurrency10
            '
            Me.lblCurrency10.AutoSize = True
            Me.lblCurrency10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency10.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency10.Location = New System.Drawing.Point(272, 120)
            Me.lblCurrency10.Name = "lblCurrency10"
            Me.lblCurrency10.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency10.TabIndex = 200
            Me.lblCurrency10.Text = "บาท"
            Me.lblCurrency10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDepre1
            '
            Me.lblDepre1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDepre1.ForeColor = System.Drawing.Color.Black
            Me.lblDepre1.Location = New System.Drawing.Point(8, 120)
            Me.lblDepre1.Name = "lblDepre1"
            Me.lblDepre1.Size = New System.Drawing.Size(144, 18)
            Me.lblDepre1.TabIndex = 200
            Me.lblDepre1.Text = "รวมค่าเสื่อม"
            Me.lblDepre1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDepre1
            '
            Me.Validator.SetDataType(Me.txtDepre1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDepre1, "")
            Me.txtDepre1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDepre1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDepre1, System.Drawing.Color.Empty)
            Me.txtDepre1.Location = New System.Drawing.Point(152, 120)
            Me.Validator.SetMaxValue(Me.txtDepre1, "")
            Me.Validator.SetMinValue(Me.txtDepre1, "")
            Me.txtDepre1.Name = "txtDepre1"
            Me.txtDepre1.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDepre1, "")
            Me.Validator.SetRequired(Me.txtDepre1, False)
            Me.txtDepre1.Size = New System.Drawing.Size(112, 21)
            Me.txtDepre1.TabIndex = 199
            Me.txtDepre1.Text = ""
            Me.txtDepre1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblCurrency11
            '
            Me.lblCurrency11.AutoSize = True
            Me.lblCurrency11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCurrency11.ForeColor = System.Drawing.Color.Black
            Me.lblCurrency11.Location = New System.Drawing.Point(272, 144)
            Me.lblCurrency11.Name = "lblCurrency11"
            Me.lblCurrency11.Size = New System.Drawing.Size(25, 17)
            Me.lblCurrency11.TabIndex = 200
            Me.lblCurrency11.Text = "บาท"
            Me.lblCurrency11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblProfit1
            '
            Me.lblProfit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProfit1.ForeColor = System.Drawing.Color.Black
            Me.lblProfit1.Location = New System.Drawing.Point(8, 144)
            Me.lblProfit1.Name = "lblProfit1"
            Me.lblProfit1.Size = New System.Drawing.Size(144, 18)
            Me.lblProfit1.TabIndex = 200
            Me.lblProfit1.Text = "กำไร/ขาดทุน"
            Me.lblProfit1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtProfit1
            '
            Me.Validator.SetDataType(Me.txtProfit1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProfit1, "")
            Me.txtProfit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProfit1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProfit1, System.Drawing.Color.Empty)
            Me.txtProfit1.Location = New System.Drawing.Point(152, 144)
            Me.Validator.SetMaxValue(Me.txtProfit1, "")
            Me.Validator.SetMinValue(Me.txtProfit1, "")
            Me.txtProfit1.Name = "txtProfit1"
            Me.txtProfit1.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProfit1, "")
            Me.Validator.SetRequired(Me.txtProfit1, False)
            Me.txtProfit1.Size = New System.Drawing.Size(112, 21)
            Me.txtProfit1.TabIndex = 199
            Me.txtProfit1.Text = ""
            Me.txtProfit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'EqManagementView
            '
            Me.Controls.Add(Me.btnWithdraw)
            Me.Controls.Add(Me.btnReturn)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.grbYTD)
            Me.Controls.Add(Me.grbLTD)
            Me.Name = "EqManagementView"
            Me.Size = New System.Drawing.Size(640, 368)
            Me.grbDetail.ResumeLayout(False)
            Me.grbYTD.ResumeLayout(False)
            Me.grbLTD.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblAsset.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblAsset}")

            Me.lblAssetStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblAssetStatus}")

            Me.lblLocation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblLocation}")

            Me.lblBuyDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblBuyDate}")

            Me.lblBuyPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblPrice}")

            Me.lblYTDLastDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblYTDLastDate}")

            Me.lblLTDLastDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblLTDLastDate}")

            ' Year to date
            Me.lblInternal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblInternal}")
            Me.lblExternal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblExternal}")
            Me.lblMaintenance.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblMaintenance}")
            Me.lblDepre.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblDepre}")
            Me.lblProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblProfit}")

            ' Lift to date
            Me.lblInternal1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblInternal1}")
            Me.lblExternal1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblExternal1}")
            Me.lblMaintenance1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblMaintenance1}")
            Me.lblDepre1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblDepre1}")
            Me.lblProfit1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.lblProfit1}")

            ' Global Text
            Me.lblCurrency1.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency2.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency3.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency4.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency5.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency6.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency7.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency8.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency9.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency10.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblCurrency11.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")

            ' Buttons 
            Me.btnWithdraw.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.btnWithdraw}")
            Me.btnReturn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.btnReturn}")

            ' Group Box
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.grbDetail}")
            Me.grbYTD.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.grbYTD}")
            Me.grbLTD.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqManagementView.grbLTD}")

        End Sub
#End Region

#Region " Members "
        Private m_entity As Asset
        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()

            Me.SetLabelText()
            EventWiring()

            Me.UpdateEntityProperties()
            LoopControl(Me)
        End Sub

#End Region

#Region "ISimpleListPanel"
        ' Initialize
        Public Overrides Sub Initialize()

        End Sub
        ' CheckFormEnable
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity.Canceled Then
                For Each grbCtrl As Control In Me.Controls
                    If TypeOf grbCtrl Is FixedGroupBox Then
                        For Each Ctrl As Control In grbCtrl.Controls
                            Ctrl.Enabled = False
                        Next
                    End If
                Next
            Else
                For Each grbCtrl As Control In Me.Controls
                    If TypeOf grbCtrl Is FixedGroupBox Then
                        For Each Ctrl As Control In grbCtrl.Controls
                            Ctrl.Enabled = True
                        Next
                    End If
                Next
            End If
        End Sub
        ' ClearDetail
        Public Overrides Sub ClearDetail()
            For Each grbCtrl As Control In Me.Controls
                If TypeOf grbCtrl Is FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next
        End Sub
        ' EventWiring
        Protected Overrides Sub EventWiring()
            ' Year to date
            AddHandler txtInternal.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtExternal.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtMaintenance.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtDepre.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtProfit.TextChanged, AddressOf Me.ChangeProperty

            ' Life to date
            AddHandler txtInternal1.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtExternal1.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtMaintenance1.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtDepre1.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtProfit1.TextChanged, AddressOf Me.ChangeProperty

        End Sub
        ' UpdateEntityProperties
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            If Not m_entity Is Nothing Then

                txtAssetCode.Text = m_entity.Code
                txtAssetName.Text = m_entity.Name

                txtAssetStatus.Text = m_entity.Status.Description

                txtLocation.Text = m_entity.LastLocation.Code
                txtLocation1.Text = m_entity.LastLocation.Name

                txtBuyDate.Text = MinDateToNull(Me.m_entity.BuyDate, "")

                dtpBuyDate.Value = Me.MinDateToNow(m_entity.BuyDate)

                txtBuyPrice.Text = Configuration.FormatToString(m_entity.BuyPrice, DigitConfig.Price)
            End If

            SetEqManagementValue()


            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        ' SetEqManagementValue 
        Public Sub SetEqManagementValue()
            Me.m_entity.RefreshSummaryInfo()
            Me.m_entity.DepreciationCalc()
            ' Year to date
            txtInternal.Text = Configuration.FormatToString(Me.m_entity.InternalIncomeYTD, DigitConfig.Price)
            txtExternal.Text = Configuration.FormatToString(Me.m_entity.ExternalIncomeYTD, DigitConfig.Price)
            txtMaintenance.Text = Configuration.FormatToString(Me.m_entity.MaintenanceCostYTD, DigitConfig.Price)
            txtDepre.Text = Configuration.FormatToString(Me.m_entity.DepreYTD, DigitConfig.Price)
            txtProfit.Text = Configuration.FormatToString(Me.m_entity.ProfitYTD, DigitConfig.Price)

            ' Life to date 
            txtInternal1.Text = Configuration.FormatToString(Me.m_entity.InternalIncomeLTD, DigitConfig.Price)
            txtExternal1.Text = Configuration.FormatToString(Me.m_entity.ExternalIncomeLTD, DigitConfig.Price)
            txtMaintenance1.Text = Configuration.FormatToString(Me.m_entity.MaintenanceCostLTD, DigitConfig.Price)
            txtDepre1.Text = Configuration.FormatToString(Me.m_entity.DepreLTD, DigitConfig.Price)
            txtProfit1.Text = Configuration.FormatToString(Me.m_entity.ProfitLTD, DigitConfig.Price)

            txtYTDLastDate.Text = MinDateToNull(Me.m_entity.LastdateYTD, "")
            txtLTDLastDate.Text = MinDateToNull(Me.m_entity.LastdateLTD, "")
        End Sub
        ' ChangeProperty  (ไม่ได้ใช้งาน)
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case ""

            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        ' SetStatus
        Public Sub SetStatus()
            ' TODO : Check for entity status
        End Sub
        ' Entity
        Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, Asset)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property
#End Region

#Region "Event Handlers"
        Private Sub ToggleVisibility(ByVal show As Boolean)
            If Me.SecurityService.CurrentUser.Id = 1 Then
                show = True
            End If
            Me.grbDetail.Enabled = show
            If Not show Then
                Me.ErrorProvider1.SetError(Me.txtAssetCode, "")
                Me.ErrorProvider1.SetError(Me.txtAssetName, "")
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

#Region " Buttons Envent "
        Private Sub btnWithdraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWithdraw.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New AssetWithdraw)
        End Sub

        Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New AssetReturn)
        End Sub
#End Region

        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)

        End Sub
    End Class
End Namespace