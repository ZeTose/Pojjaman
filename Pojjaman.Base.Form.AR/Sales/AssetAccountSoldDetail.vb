Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AssetAccountSoldDetail
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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents grbDocInfo As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblAccDepre As System.Windows.Forms.Label
    Friend WithEvents txtBuyAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblWriteOffAmt As System.Windows.Forms.Label
    Friend WithEvents lblBuyAmt As System.Windows.Forms.Label
    Friend WithEvents txtWriteOffAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtAccDepre As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents grbSummary As System.Windows.Forms.GroupBox
    Friend WithEvents lblDocStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox()
      Me.lblFromCostCenter = New System.Windows.Forms.Label()
      Me.grbDocInfo = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.txtBuyAmt = New System.Windows.Forms.TextBox()
      Me.txtWriteOffAmt = New System.Windows.Forms.TextBox()
      Me.txtAccDepre = New System.Windows.Forms.TextBox()
      Me.lblAccDepre = New System.Windows.Forms.Label()
      Me.lblWriteOffAmt = New System.Windows.Forms.Label()
      Me.lblBuyAmt = New System.Windows.Forms.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.lblDocStatus = New System.Windows.Forms.Label()
      Me.grbSummary = New System.Windows.Forms.GroupBox()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDocInfo.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbSummary.SuspendLayout()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 112)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 272)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(6, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 13
      Me.lblCode.Text = "เลขที่ใบส่งของ:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(110, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(88, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(400, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(48, 18)
      Me.lblDocDate.TabIndex = 16
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(6, 91)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 28
      Me.lblItem.Text = "รายการสินทรัพย์:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtFromCostCenterName
      '
      Me.txtFromCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(512, 41)
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(176, 20)
      Me.txtFromCostCenterName.TabIndex = 4
      Me.txtFromCostCenterName.TabStop = False
      '
      'txtFromCostCenterCode
      '
      Me.txtFromCostCenterCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(448, 41)
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, True)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(64, 20)
      Me.txtFromCostCenterCode.TabIndex = 0
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.Location = New System.Drawing.Point(392, 41)
      Me.lblFromCostCenter.Name = "lblFromCostCenter"
      Me.lblFromCostCenter.Size = New System.Drawing.Size(56, 18)
      Me.lblFromCostCenter.TabIndex = 2
      Me.lblFromCostCenter.Text = "จาก CC:"
      Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDocInfo
      '
      Me.grbDocInfo.Controls.Add(Me.txtCustomerName)
      Me.grbDocInfo.Controls.Add(Me.txtFromCostCenterName)
      Me.grbDocInfo.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbDocInfo.Controls.Add(Me.lblCustomer)
      Me.grbDocInfo.Controls.Add(Me.lblFromCostCenter)
      Me.grbDocInfo.Controls.Add(Me.txtCustomerCode)
      Me.grbDocInfo.Controls.Add(Me.lblCode)
      Me.grbDocInfo.Controls.Add(Me.lblDocDate)
      Me.grbDocInfo.Controls.Add(Me.txtCode)
      Me.grbDocInfo.Controls.Add(Me.txtDocDate)
      Me.grbDocInfo.Enabled = False
      Me.grbDocInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocInfo.Location = New System.Drawing.Point(8, 12)
      Me.grbDocInfo.Name = "grbDocInfo"
      Me.grbDocInfo.Size = New System.Drawing.Size(752, 76)
      Me.grbDocInfo.TabIndex = 6
      Me.grbDocInfo.TabStop = False
      Me.grbDocInfo.Text = "ข้อมูลเอกสาร"
      '
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(174, 43)
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(168, 20)
      Me.txtCustomerName.TabIndex = 5
      Me.txtCustomerName.TabStop = False
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.Location = New System.Drawing.Point(30, 43)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(80, 18)
      Me.lblCustomer.TabIndex = 3
      Me.lblCustomer.Text = "ลูกค้า:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustomerCode
      '
      Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(110, 43)
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, True)
      Me.txtCustomerCode.Size = New System.Drawing.Size(64, 20)
      Me.txtCustomerCode.TabIndex = 0
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
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(448, 16)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(97, 20)
      Me.txtDocDate.TabIndex = 1
      '
      'txtBuyAmt
      '
      Me.txtBuyAmt.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtBuyAmt, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuyAmt, "")
      Me.Validator.SetGotFocusBackColor(Me.txtBuyAmt, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuyAmt, System.Drawing.Color.Empty)
      Me.txtBuyAmt.Location = New System.Drawing.Point(34, 37)
      Me.Validator.SetMinValue(Me.txtBuyAmt, "")
      Me.txtBuyAmt.Name = "txtBuyAmt"
      Me.txtBuyAmt.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBuyAmt, "")
      Me.Validator.SetRequired(Me.txtBuyAmt, False)
      Me.txtBuyAmt.Size = New System.Drawing.Size(144, 20)
      Me.txtBuyAmt.TabIndex = 31
      Me.txtBuyAmt.TabStop = False
      Me.txtBuyAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtWriteOffAmt
      '
      Me.txtWriteOffAmt.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtWriteOffAmt, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWriteOffAmt, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWriteOffAmt, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWriteOffAmt, System.Drawing.Color.Empty)
      Me.txtWriteOffAmt.Location = New System.Drawing.Point(199, 37)
      Me.Validator.SetMinValue(Me.txtWriteOffAmt, "")
      Me.txtWriteOffAmt.Name = "txtWriteOffAmt"
      Me.txtWriteOffAmt.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtWriteOffAmt, "")
      Me.Validator.SetRequired(Me.txtWriteOffAmt, False)
      Me.txtWriteOffAmt.Size = New System.Drawing.Size(144, 20)
      Me.txtWriteOffAmt.TabIndex = 33
      Me.txtWriteOffAmt.TabStop = False
      Me.txtWriteOffAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAccDepre
      '
      Me.txtAccDepre.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtAccDepre, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccDepre, "")
      Me.txtAccDepre.ForeColor = System.Drawing.Color.Blue
      Me.Validator.SetGotFocusBackColor(Me.txtAccDepre, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccDepre, System.Drawing.Color.Empty)
      Me.txtAccDepre.Location = New System.Drawing.Point(367, 37)
      Me.Validator.SetMinValue(Me.txtAccDepre, "")
      Me.txtAccDepre.Name = "txtAccDepre"
      Me.txtAccDepre.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccDepre, "")
      Me.Validator.SetRequired(Me.txtAccDepre, False)
      Me.txtAccDepre.Size = New System.Drawing.Size(144, 20)
      Me.txtAccDepre.TabIndex = 36
      Me.txtAccDepre.TabStop = False
      Me.txtAccDepre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAccDepre
      '
      Me.lblAccDepre.BackColor = System.Drawing.Color.Transparent
      Me.lblAccDepre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccDepre.Location = New System.Drawing.Point(364, 16)
      Me.lblAccDepre.Name = "lblAccDepre"
      Me.lblAccDepre.Size = New System.Drawing.Size(100, 18)
      Me.lblAccDepre.TabIndex = 41
      Me.lblAccDepre.Text = "ค่าเสื่อมสะสมรวม"
      Me.lblAccDepre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblWriteOffAmt
      '
      Me.lblWriteOffAmt.BackColor = System.Drawing.Color.Transparent
      Me.lblWriteOffAmt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWriteOffAmt.Location = New System.Drawing.Point(196, 16)
      Me.lblWriteOffAmt.Name = "lblWriteOffAmt"
      Me.lblWriteOffAmt.Size = New System.Drawing.Size(87, 18)
      Me.lblWriteOffAmt.TabIndex = 43
      Me.lblWriteOffAmt.Text = "มูลค่า Write-off"
      Me.lblWriteOffAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBuyAmt
      '
      Me.lblBuyAmt.BackColor = System.Drawing.Color.Transparent
      Me.lblBuyAmt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuyAmt.Location = New System.Drawing.Point(15, 16)
      Me.lblBuyAmt.Name = "lblBuyAmt"
      Me.lblBuyAmt.Size = New System.Drawing.Size(80, 18)
      Me.lblBuyAmt.TabIndex = 30
      Me.lblBuyAmt.Text = "มูลค่าซื้อรวม"
      Me.lblBuyAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocStatus
      '
      Me.lblDocStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblDocStatus.BackColor = System.Drawing.Color.Transparent
      Me.lblDocStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocStatus.Location = New System.Drawing.Point(8, 488)
      Me.lblDocStatus.Name = "lblDocStatus"
      Me.lblDocStatus.Size = New System.Drawing.Size(472, 18)
      Me.lblDocStatus.TabIndex = 12
      Me.lblDocStatus.Text = "Status"
      Me.lblDocStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbSummary
      '
      Me.grbSummary.Controls.Add(Me.lblAccDepre)
      Me.grbSummary.Controls.Add(Me.txtAccDepre)
      Me.grbSummary.Controls.Add(Me.lblWriteOffAmt)
      Me.grbSummary.Controls.Add(Me.txtBuyAmt)
      Me.grbSummary.Controls.Add(Me.txtWriteOffAmt)
      Me.grbSummary.Controls.Add(Me.lblBuyAmt)
      Me.grbSummary.Location = New System.Drawing.Point(232, 399)
      Me.grbSummary.Name = "grbSummary"
      Me.grbSummary.Size = New System.Drawing.Size(528, 75)
      Me.grbSummary.TabIndex = 44
      Me.grbSummary.TabStop = False
      Me.grbSummary.Text = "สรุป"
      '
      'AssetAccountSoldDetail
      '
      Me.Controls.Add(Me.grbDocInfo)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblDocStatus)
      Me.Controls.Add(Me.grbSummary)
      Me.Name = "AssetAccountSoldDetail"
      Me.Size = New System.Drawing.Size(784, 520)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDocInfo.ResumeLayout(False)
      Me.grbDocInfo.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbSummary.ResumeLayout(False)
      Me.grbSummary.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)


      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblItem}")
      Me.grbDocInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.grbDelivery}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)



      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblDocDate}")
      Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)





      Me.lblAccDepre.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblAfterTax}")
      Me.Validator.SetDisplayName(txtAccDepre, lblAccDepre.Text)



      Me.lblWriteOffAmt.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblBeforeTax}")
      Me.Validator.SetDisplayName(txtWriteOffAmt, lblWriteOffAmt.Text)

      Me.lblBuyAmt.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblGross}")
      Me.Validator.SetDisplayName(txtBuyAmt, lblBuyAmt.Text)





      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblFromCostCenter}")
      Me.Validator.SetDisplayName(txtFromCostCenterCode, lblFromCostCenter.Text)

      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.lblCustomer}")
      Me.Validator.SetDisplayName(txtCustomerCode, lblCustomer.Text)





    End Sub
#End Region

#Region "Members"
    Private m_entity As AssetSold
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_tableStyleEnable As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = AssetSold.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      EventWiring()
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "AssetSold"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'Stock Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "stocki_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "stocki_linenumber"


      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 80
      csCode.ReadOnly = False
      csCode.TextBox.Name = "Code"

      'Dim csButton As New DataGridButtonColumn
      'csButton.MappingName = "Button"
      'csButton.HeaderText = ""
      'csButton.NullText = ""
      'AddHandler csButton.Click, AddressOf ButtonClick

      Dim csName As New TreeTextColumn
      csName.MappingName = "stocki_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.Width = 30
      csUnit.TextBox.Name = "Unit"
      csUnit.ReadOnly = True
      csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "stocki_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.QtyHeaderText}")
      csQty.NullText = ""
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      csQty.ReadOnly = True
      csQty.DataAlignment = HorizontalAlignment.Right

      Dim csStockQty As New TreeTextColumn
      csStockQty.MappingName = "StockQty"
      csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.StockQtyHeaderText}")
      csStockQty.NullText = ""
      csStockQty.Format = "#,###.##"
      csStockQty.ReadOnly = True
      csStockQty.DataAlignment = HorizontalAlignment.Right

      Dim csBuyAmount As New TreeTextColumn
      csBuyAmount.MappingName = "BuyAmount"
      csBuyAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.BuyAmount}")
      csBuyAmount.NullText = ""
      csBuyAmount.TextBox.Name = "BuyAmount"
      csBuyAmount.Format = "#,###.##"
      csBuyAmount.ReadOnly = False
      csBuyAmount.DataAlignment = HorizontalAlignment.Right



      Dim csWriteOffAmount As New TreeTextColumn
      csWriteOffAmount.MappingName = "WriteOffAmount"
      csWriteOffAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.WriteOffAmount}")
      csWriteOffAmount.NullText = ""
      csWriteOffAmount.TextBox.Name = "WriteOffAmount"
      csWriteOffAmount.ReadOnly = True
      csWriteOffAmount.Format = "#,###.##"
      csWriteOffAmount.DataAlignment = HorizontalAlignment.Right

      Dim csAccDepre As New TreeTextColumn
      csAccDepre.MappingName = "Accdepreamt"
      csAccDepre.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.DeprecalcHeaderText}")
      csAccDepre.NullText = ""
      csAccDepre.TextBox.Name = "Accdepreamt"
      csAccDepre.ReadOnly = True
      csAccDepre.Format = "#,###.##"
      csAccDepre.DataAlignment = HorizontalAlignment.Right
      'ผังบัญชี Fix Asset
      Dim csFAAccountCode As New TreeTextColumn
      csFAAccountCode.MappingName = "FAAcctCode"
      csFAAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AccountCodeHeaderText}")
      csFAAccountCode.NullText = ""
      csFAAccountCode.TextBox.Name = "FAAcctCode"

      Dim csFAAccount As New TreeTextColumn
      csFAAccount.MappingName = "FAAcct"
      csFAAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AccountHeaderText}")
      csFAAccount.NullText = ""
      csFAAccount.ReadOnly = True
      csFAAccount.TextBox.Name = "FAAcct"

      'ผังบัญชี ค่าเสื่อมสะสม
      Dim csAccAccountCode As New TreeTextColumn
      csAccAccountCode.MappingName = "AccAcctCode"
      csAccAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AccountCodeHeaderText}")
      csAccAccountCode.NullText = ""
      csAccAccountCode.TextBox.Name = "AccAcctCode"

      Dim csAccAccount As New TreeTextColumn
      csAccAccount.MappingName = "AccAccount"
      csAccAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.AccountHeaderText}")
      csAccAccount.NullText = ""
      csAccAccount.ReadOnly = True
      csAccAccount.TextBox.Name = "AccAccount"

      Dim csAccountButton As New DataGridButtonColumn
      csAccountButton.MappingName = "AccountButton"
      csAccountButton.HeaderText = ""
      csAccountButton.NullText = ""
      'AddHandler csAccountButton.Click, AddressOf ButtonClick

      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "stocki_unvatable"
      csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.UnVatableHeaderText}")
      csVatable.Width = 100
      csVatable.ReadOnly = True
      csVatable.InvisibleWhenUnspcified = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "stocki_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSoldDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "stocki_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      'dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      'dst.GridColumnStyles.Add(csUnit)
      'dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csBuyAmount)
      dst.GridColumnStyles.Add(csWriteOffAmount)
      dst.GridColumnStyles.Add(csFAAccountCode)
      dst.GridColumnStyles.Add(csFAAccount)
      dst.GridColumnStyles.Add(csAccDepre)
      dst.GridColumnStyles.Add(csAccAccountCode)
      dst.GridColumnStyles.Add(csAccAccount)
      'dst.GridColumnStyles.Add(csAccountCode)
      'dst.GridColumnStyles.Add(csAccountButton)
      'dst.GridColumnStyles.Add(csAccount)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Public Sub ButtonClick(ByVal e As ButtonColumnEventArgs)
      If e.Column = 2 Then
        Me.ItemButtonClick(e)
      Else
        Me.AcctButtonClick(e)
      End If
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
      OrElse m_entityRefed = 1 _
      Then
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = True
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      Me.StatusBarService.SetMessage("")
      For Each crlt As Control In Me.grbDocInfo.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In Me.grbSummary.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next

    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty



      AddHandler txtFromCostCenterCode.Validated, AddressOf Me.ChangeProperty


    End Sub
    Private m_oldInvoiceCode As String = ""
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtCode.Text = m_entity.Code

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))




      txtCustomerCode.Text = m_entity.Customer.Code
      txtCustomerName.Text = m_entity.Customer.Name


      txtFromCostCenterCode.Text = m_entity.FromCostCenter.Code
      txtFromCostCenterName.Text = m_entity.FromCostCenter.Name




      RefreshDocs()
      ''Load Items**********************************************************
      'Me.m_treeManager.Treetable = Me.m_entity.ItemTable
      'AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
      'Me.Validator.DataTable = m_treeManager.Treetable
      ''********************************************************************

      'UpdateAmount(True)

      'RefreshBlankGrid()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub


    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If Me.m_isInitialized AndAlso (e.Name = "ItemChanged" Or e.Name = "QtyChanged") Then
        If e.Name = "QtyChanged" Then
          Me.UpdateAmount(False)
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True

        Case "txtcustomercode"
          dirtyFlag = Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
          If dirtyFlag Then
            UpdateCustomer()
          End If

        Case "txtfromcostcentercode"
          dirtyFlag = CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter)
          If dirtyFlag Then
            Me.m_entity.FromCostCenterPerson = Me.m_entity.FromCostCenter.Admin

          End If
        Case Else
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub

    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount(True)
      Me.m_isInitialized = True

    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("stocki_linenumber") = i + 1
        i += 1
      Next
    End Sub
    Private Sub UpdateAmount(ByVal refresh As Boolean)
      m_isInitialized = False
      If refresh Then
        Me.m_entity.RefreshTaxBase()
      End If
      txtBuyAmt.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
      txtWriteOffAmt.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
      txtAccDepre.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
      m_isInitialized = True
    End Sub

    Public Sub SetStatus()
        MyBase.SetStatusBarMessage()
    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          'If Not Me.m_treeManager.GridTableStyle Is Nothing Then
          '    If Me.m_treeManager.GridTableStyle.GridColumnStyles.Contains("Button") Then
          '        Dim btnCol As DataGridButtonColumn = CType(Me.m_treeManager.GridTableStyle.GridColumnStyles("Button"), DataGridButtonColumn)
          '        RemoveHandler btnCol.Click, AddressOf ButtonClick
          '    End If
          'End If
        End If
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = CType(Value, AssetSold)
        End If
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
    End Sub
    ' 

#End Region

#Region "Event Handler"

    Private m_oldCode As String = ""



    Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim acct As New Account
      Dim entities As New ArrayList
      acct.Type = New AccountType(4) ' รายได้
      entities.Add(acct)

      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAcct, Nothing, entities)
    End Sub
    Private Sub SetAcct(ByVal acct As ISimpleEntity)
      Me.m_treeManager.SelectedRow("AccountCode") = acct.Code
    End Sub

    Private Function GetToolIdList() As String
      Dim idlist As String
      Me.m_entity.ItemTable.AcceptChanges()
      For Each row As TreeRow In Me.m_entity.ItemTable.Rows
        If Me.m_entity.ValidateRow(row) Then
          If Not row.IsNull("stocki_entity") Then
            idlist &= "|" & CStr(row("stocki_entity")) & "|"
          End If
        End If
      Next
      Return idlist
    End Function
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity.FromCostCenter Is Nothing OrElse Not Me.m_entity.FromCostCenter.Originated Then
        Dim myMsgService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        myMsgService.ShowWarning("${res:Global.Error.SpecifyCC}")
        txtFromCostCenterCode.Focus()
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      filters(0) = New Filter("idlist", GetToolIdList())

      Dim entities As New ArrayList
      Dim obj As New Asset
      obj.Costcenter = Me.m_entity.FromCostCenter
      entities.Add(obj)

      myEntityPanelService.OpenListDialog(New Asset, AddressOf SetItems, filters, entities)
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As Asset
        Dim newType As Integer = -1

        newItem = New Asset(item.Id)
        newType = newItem.EntityId

        If i = items.Count - 1 Then
          If Me.m_entity.ItemTable.Childs.Count = 0 Then
            Me.m_entity.AddBlankRow(1)
            Me.m_entity.ItemTable.Rows(index)("stocki_entityType") = newType
            Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
          Else
            Me.m_entity.ItemTable.Rows(index)("stocki_entityType") = newType
            Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
          End If
        Else
          Dim mySolditem As New AssetSoldItem
          mySolditem.AssetSold = Me.m_entity
          mySolditem.Entity = newItem

          Me.m_entity.Insert(index, mySolditem)
          Me.m_entity.ItemTable.Rows(index)("stocki_entityType") = newType
          Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
        End If
        Me.m_entity.ItemTable.AcceptChanges()
      Next
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.MaxRowIndex Then
        Return
      End If
      Dim item As New AssetSoldItem
      Me.m_entity.Insert(index, item)
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      If index > Me.m_entity.MaxRowIndex Then
        Return
      End If
      Me.m_entity.Remove(index)
      Me.tgItem.CurrentRowIndex = index
      RefreshBlankGrid()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

#Region "Comment"
    'Private Sub ibtnGenCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Dim nextCode As String = Me.m_entity.GetNextCode
    '    'If Me.txtCode.Text = "" And Me.m_entity.Code <> Me.m_entity.GetLastCode Then
    '    '    Me.txtCode.Text = nextCode
    '    '    Me.txtCode.Update()
    '    'End If
    'End Sub
    'Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
    '    'Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.POItemAuxDetail(CType(Me.m_entity.Items(e.Row), POItem)))
    '    'myDialog.ShowDialog()
    'End Sub
    'Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
    '    'For Each helper As IHelper In Me.m_helpers
    '    '    helper.HideHelper()
    '    'Next
    '    Dim cellRect As Rectangle = tgItem.GetCellBounds(tgItem.CurrentCell.RowNumber, tgItem.CurrentCell.ColumnNumber)
    '    Dim cellPoint As Point = tgItem.PointToScreen(cellRect.Location)
    '    cellPoint.Y += cellRect.Height
    '    Dim helperRect As New Rectangle(cellPoint, New Size(250, 250))
    '    Dim colName As String = tgItem.TableStyles(0).GridColumnStyles(tgItem.CurrentCell.ColumnNumber).MappingName

    '    Select Case colName.ToLower
    '        Case "description"
    '        Case "unit"
    '    End Select
    'End Sub

    'Private Sub txtRequestor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'End Sub

    'Private Sub ibtnItemSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.POItemSelectionPanel)
    '    myDialog.ShowDialog()
    'End Sub
#End Region

#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New AssetSold).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Customer
    Private Sub ibtnShowCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Customer)
    End Sub
    Private Sub ibtnShowCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomerDialog)
    End Sub
    Private Sub SetCustomerDialog(ByVal e As ISimpleEntity)
      Me.txtCustomerCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
      UpdateCustomer()
    End Sub
    Private Sub UpdateCustomer()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Customer Is Nothing Then
        Return
      End If

    End Sub
    'Cost Center
    Private Sub ibtnShowFromCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub ibtnShowFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCostCenter)
    End Sub
    Private Sub SetFromCostCenter(ByVal e As ISimpleEntity)
      Me.txtFromCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter)
      If Me.WorkbenchWindow.ViewContent.IsDirty Then
        Me.m_entity.FromCostCenterPerson = Me.m_entity.FromCostCenter.Admin
        'txtFromCCPersonCode.Text = Me.m_entity.FromCostCenterPerson.Code
        'txtFromCCPersonName.Text = Me.m_entity.FromCostCenterPerson.Name
      End If
    End Sub

    'Cost Person
    'Private Sub ibtnShowCCPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New Employee)
    'End Sub
    'Private Sub ibtnShowCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = _
    '   CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New Employee, AddressOf SetCCPerson)
    'End Sub
    'Private Sub SetCCPerson(ByVal e As ISimpleEntity)
    '  Me.txtFromCCPersonCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      Or Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromCostCenterPerson)
    'End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Customer).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcustomercode", "txtcustomername"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Customer).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
        Dim entity As New Customer(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcustomercode", "txtcustomername"
              Me.SetCustomerDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim maxVisibleCount As Integer
      Dim tgRowHeight As Integer = 17
      maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      Do While Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1
        'เพิ่มแถวจนเต็ม
        Me.m_entity.AddBlankRow(1)
      Loop
      If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
        If Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1 Then
          'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          Me.m_entity.AddBlankRow(1)
        End If
      End If
      'Do While Me.m_entity.ItemTable.Rows.Count > maxVisibleCount - 1 And Me.m_entity.ItemTable.Rows.Count - 2 <> Me.m_entity.MaxRowIndex
      '    'ลบแถวที่ไม่จำเป็น
      '    Me.m_entity.Remove(Me.m_entity.ItemTable.Rows.Count - 1)
      'Loop
      Me.m_entity.ItemTable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

  End Class
End Namespace