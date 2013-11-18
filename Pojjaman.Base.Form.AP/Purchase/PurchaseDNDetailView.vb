Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class PurchaseDNDetailView
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
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents cmbNote As System.Windows.Forms.ComboBox
        Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lbOrgTotalUnit As System.Windows.Forms.Label
        Friend WithEvents lblOrgTotal As System.Windows.Forms.Label
        Friend WithEvents lblAdjValUnit As System.Windows.Forms.Label
        Friend WithEvents lblAdjVal As System.Windows.Forms.Label
        Friend WithEvents txtAdjVal As System.Windows.Forms.TextBox
        Friend WithEvents txtDiff As System.Windows.Forms.TextBox
        Friend WithEvents lblDiffUnit As System.Windows.Forms.Label
        Friend WithEvents lblDiff As System.Windows.Forms.Label
        Friend WithEvents txtOrgTotal As System.Windows.Forms.TextBox
        Friend WithEvents lblItemRf As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblPercent As System.Windows.Forms.Label
        Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
        Friend WithEvents txtBeforeTax As System.Windows.Forms.TextBox
        Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblGross As System.Windows.Forms.Label
        Friend WithEvents lblTaxAmount As System.Windows.Forms.Label
        Friend WithEvents txtGross As System.Windows.Forms.TextBox
        Friend WithEvents txtDiscountRate As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxType As System.Windows.Forms.Label
        Friend WithEvents txtAfterTax As System.Windows.Forms.TextBox
        Friend WithEvents lblAfterTax As System.Windows.Forms.Label
        Friend WithEvents lblDiscountAmount As System.Windows.Forms.Label
        Friend WithEvents lblTaxBase As System.Windows.Forms.Label
        Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
        Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
        Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
        Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxRate As System.Windows.Forms.Label
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnBlankDoc As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelDoc As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents grbDelivery As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ibtnShowSupplier As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblSupplier As System.Windows.Forms.Label
        Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCreditPrd As System.Windows.Forms.Label
        Friend WithEvents lblDay As System.Windows.Forms.Label
        Friend WithEvents txtCreditPrd As System.Windows.Forms.TextBox
        Friend WithEvents lblDueDate As System.Windows.Forms.Label
        Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents txtInvoiceCode As System.Windows.Forms.TextBox
        Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
        Friend WithEvents txtInvoiceDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents ibtnEnableVatInput As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblInvoiceCode As System.Windows.Forms.Label
        Friend WithEvents tgRefDoc As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents tgWBS As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ibtnAddWBS As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelWBS As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblWBS As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PurchaseDNDetailView))
            Me.tgRefDoc = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblNote = New System.Windows.Forms.Label
            Me.cmbNote = New System.Windows.Forms.ComboBox
            Me.lblItemRf = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lbOrgTotalUnit = New System.Windows.Forms.Label
            Me.lblOrgTotal = New System.Windows.Forms.Label
            Me.lblAdjValUnit = New System.Windows.Forms.Label
            Me.lblAdjVal = New System.Windows.Forms.Label
            Me.txtAdjVal = New System.Windows.Forms.TextBox
            Me.txtDiff = New System.Windows.Forms.TextBox
            Me.lblDiffUnit = New System.Windows.Forms.Label
            Me.lblDiff = New System.Windows.Forms.Label
            Me.txtOrgTotal = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtDocDate = New System.Windows.Forms.TextBox
            Me.txtInvoiceDate = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtTaxBase = New System.Windows.Forms.TextBox
            Me.txtBeforeTax = New System.Windows.Forms.TextBox
            Me.txtTaxAmount = New System.Windows.Forms.TextBox
            Me.txtGross = New System.Windows.Forms.TextBox
            Me.txtDiscountRate = New System.Windows.Forms.TextBox
            Me.txtAfterTax = New System.Windows.Forms.TextBox
            Me.txtDiscountAmount = New System.Windows.Forms.TextBox
            Me.txtTaxRate = New System.Windows.Forms.TextBox
            Me.txtSupplierName = New System.Windows.Forms.TextBox
            Me.txtSupplierCode = New System.Windows.Forms.TextBox
            Me.txtCreditPrd = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtInvoiceCode = New System.Windows.Forms.TextBox
            Me.lblPercent = New System.Windows.Forms.Label
            Me.lblGross = New System.Windows.Forms.Label
            Me.lblTaxAmount = New System.Windows.Forms.Label
            Me.lblTaxType = New System.Windows.Forms.Label
            Me.lblAfterTax = New System.Windows.Forms.Label
            Me.lblDiscountAmount = New System.Windows.Forms.Label
            Me.lblTaxBase = New System.Windows.Forms.Label
            Me.lblBeforeTax = New System.Windows.Forms.Label
            Me.cmbTaxType = New System.Windows.Forms.ComboBox
            Me.lblTaxRate = New System.Windows.Forms.Label
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnBlankDoc = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelDoc = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbDelivery = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnShowSupplier = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblSupplier = New System.Windows.Forms.Label
            Me.lblCreditPrd = New System.Windows.Forms.Label
            Me.lblDay = New System.Windows.Forms.Label
            Me.lblDueDate = New System.Windows.Forms.Label
            Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblInvoiceDate = New System.Windows.Forms.Label
            Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker
            Me.ibtnEnableVatInput = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblInvoiceCode = New System.Windows.Forms.Label
            Me.tgWBS = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.ibtnAddWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblWBS = New System.Windows.Forms.Label
            CType(Me.tgRefDoc, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbSummary.SuspendLayout()
            Me.grbDelivery.SuspendLayout()
            CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tgRefDoc
            '
            Me.tgRefDoc.AllowNew = False
            Me.tgRefDoc.AllowSorting = False
            Me.tgRefDoc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgRefDoc.AutoColumnResize = True
            Me.tgRefDoc.CaptionVisible = False
            Me.tgRefDoc.Cellchanged = False
            Me.tgRefDoc.DataMember = ""
            Me.tgRefDoc.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgRefDoc.Location = New System.Drawing.Point(8, 88)
            Me.tgRefDoc.Name = "tgRefDoc"
            Me.tgRefDoc.Size = New System.Drawing.Size(504, 120)
            Me.tgRefDoc.SortingArrowColor = System.Drawing.Color.Red
            Me.tgRefDoc.TabIndex = 7
            Me.tgRefDoc.TreeManager = Nothing
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(160, 208)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(88, 18)
            Me.lblNote.TabIndex = 26
            Me.lblNote.Text = "หมายเหตุเพิ่มหนี้"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbNote
            '
            Me.cmbNote.Location = New System.Drawing.Point(256, 208)
            Me.cmbNote.Name = "cmbNote"
            Me.cmbNote.Size = New System.Drawing.Size(320, 21)
            Me.cmbNote.TabIndex = 8
            '
            'lblItemRf
            '
            Me.lblItemRf.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemRf.Location = New System.Drawing.Point(8, 72)
            Me.lblItemRf.Name = "lblItemRf"
            Me.lblItemRf.Size = New System.Drawing.Size(96, 18)
            Me.lblItemRf.TabIndex = 15
            Me.lblItemRf.Text = "เอกสารอ้างอิง"
            Me.lblItemRf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tgItem
            '
            Me.tgItem.AllowNew = False
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = False
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 232)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(800, 168)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 9
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 216)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(96, 18)
            Me.lblItem.TabIndex = 27
            Me.lblItem.Text = "รายการเพิ่มหนี้"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbSummary
            '
            Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbSummary.Controls.Add(Me.lbOrgTotalUnit)
            Me.grbSummary.Controls.Add(Me.lblOrgTotal)
            Me.grbSummary.Controls.Add(Me.lblAdjValUnit)
            Me.grbSummary.Controls.Add(Me.lblAdjVal)
            Me.grbSummary.Controls.Add(Me.txtAdjVal)
            Me.grbSummary.Controls.Add(Me.txtDiff)
            Me.grbSummary.Controls.Add(Me.lblDiffUnit)
            Me.grbSummary.Controls.Add(Me.lblDiff)
            Me.grbSummary.Controls.Add(Me.txtOrgTotal)
            Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSummary.Location = New System.Drawing.Point(512, 96)
            Me.grbSummary.Name = "grbSummary"
            Me.grbSummary.Size = New System.Drawing.Size(304, 96)
            Me.grbSummary.TabIndex = 0
            Me.grbSummary.TabStop = False
            Me.grbSummary.Text = "สรุปรายการเพิ่มหนี้"
            '
            'lbOrgTotalUnit
            '
            Me.lbOrgTotalUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lbOrgTotalUnit.Location = New System.Drawing.Point(264, 16)
            Me.lbOrgTotalUnit.Name = "lbOrgTotalUnit"
            Me.lbOrgTotalUnit.Size = New System.Drawing.Size(32, 18)
            Me.lbOrgTotalUnit.TabIndex = 2
            Me.lbOrgTotalUnit.Text = "บาท"
            Me.lbOrgTotalUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblOrgTotal
            '
            Me.lblOrgTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblOrgTotal.Location = New System.Drawing.Point(8, 16)
            Me.lblOrgTotal.Name = "lblOrgTotal"
            Me.lblOrgTotal.Size = New System.Drawing.Size(136, 18)
            Me.lblOrgTotal.TabIndex = 0
            Me.lblOrgTotal.Text = "มูลค่าตามใบกำกับภาษีเดิม:"
            Me.lblOrgTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAdjValUnit
            '
            Me.lblAdjValUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAdjValUnit.Location = New System.Drawing.Point(264, 40)
            Me.lblAdjValUnit.Name = "lblAdjValUnit"
            Me.lblAdjValUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblAdjValUnit.TabIndex = 5
            Me.lblAdjValUnit.Text = "บาท"
            Me.lblAdjValUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAdjVal
            '
            Me.lblAdjVal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAdjVal.Location = New System.Drawing.Point(16, 40)
            Me.lblAdjVal.Name = "lblAdjVal"
            Me.lblAdjVal.Size = New System.Drawing.Size(128, 18)
            Me.lblAdjVal.TabIndex = 3
            Me.lblAdjVal.Text = "มูลค่าที่ถูกต้อง:"
            Me.lblAdjVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAdjVal
            '
            Me.txtAdjVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtAdjVal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAdjVal, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAdjVal, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAdjVal, System.Drawing.Color.Empty)
            Me.txtAdjVal.Location = New System.Drawing.Point(144, 40)
            Me.Validator.SetMaxValue(Me.txtAdjVal, "")
            Me.Validator.SetMinValue(Me.txtAdjVal, "")
            Me.txtAdjVal.Name = "txtAdjVal"
            Me.txtAdjVal.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAdjVal, "")
            Me.Validator.SetRequired(Me.txtAdjVal, False)
            Me.txtAdjVal.Size = New System.Drawing.Size(120, 21)
            Me.txtAdjVal.TabIndex = 4
            Me.txtAdjVal.Text = ""
            Me.txtAdjVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDiff
            '
            Me.txtDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtDiff, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDiff, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDiff, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDiff, System.Drawing.Color.Empty)
            Me.txtDiff.Location = New System.Drawing.Point(144, 64)
            Me.Validator.SetMaxValue(Me.txtDiff, "")
            Me.Validator.SetMinValue(Me.txtDiff, "")
            Me.txtDiff.Name = "txtDiff"
            Me.txtDiff.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDiff, "")
            Me.Validator.SetRequired(Me.txtDiff, False)
            Me.txtDiff.Size = New System.Drawing.Size(120, 21)
            Me.txtDiff.TabIndex = 7
            Me.txtDiff.Text = ""
            Me.txtDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblDiffUnit
            '
            Me.lblDiffUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDiffUnit.Location = New System.Drawing.Point(264, 64)
            Me.lblDiffUnit.Name = "lblDiffUnit"
            Me.lblDiffUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblDiffUnit.TabIndex = 8
            Me.lblDiffUnit.Text = "บาท"
            Me.lblDiffUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDiff
            '
            Me.lblDiff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDiff.Location = New System.Drawing.Point(16, 64)
            Me.lblDiff.Name = "lblDiff"
            Me.lblDiff.Size = New System.Drawing.Size(128, 18)
            Me.lblDiff.TabIndex = 6
            Me.lblDiff.Text = "มูลค่าเพิ่มหนี้ทั้งสิ้น:"
            Me.lblDiff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtOrgTotal
            '
            Me.txtOrgTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtOrgTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtOrgTotal, "")
            Me.Validator.SetGotFocusBackColor(Me.txtOrgTotal, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtOrgTotal, System.Drawing.Color.Empty)
            Me.txtOrgTotal.Location = New System.Drawing.Point(144, 16)
            Me.Validator.SetMaxValue(Me.txtOrgTotal, "")
            Me.Validator.SetMinValue(Me.txtOrgTotal, "")
            Me.txtOrgTotal.Name = "txtOrgTotal"
            Me.txtOrgTotal.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtOrgTotal, "")
            Me.Validator.SetRequired(Me.txtOrgTotal, False)
            Me.txtOrgTotal.Size = New System.Drawing.Size(120, 21)
            Me.txtOrgTotal.TabIndex = 1
            Me.txtOrgTotal.Text = ""
            Me.txtOrgTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            Me.txtDocDate.Location = New System.Drawing.Point(240, 16)
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(78, 21)
            Me.txtDocDate.TabIndex = 1
            Me.txtDocDate.Text = ""
            '
            'txtInvoiceDate
            '
            Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
            Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
            Me.txtInvoiceDate.Location = New System.Drawing.Point(240, 40)
            Me.Validator.SetMaxValue(Me.txtInvoiceDate, "")
            Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
            Me.txtInvoiceDate.Name = "txtInvoiceDate"
            Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
            Me.Validator.SetRequired(Me.txtInvoiceDate, False)
            Me.txtInvoiceDate.Size = New System.Drawing.Size(78, 21)
            Me.txtInvoiceDate.TabIndex = 5
            Me.txtInvoiceDate.Text = ""
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
            'txtTaxBase
            '
            Me.txtTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxBase, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
            Me.txtTaxBase.Location = New System.Drawing.Point(656, 471)
            Me.Validator.SetMaxValue(Me.txtTaxBase, "")
            Me.Validator.SetMinValue(Me.txtTaxBase, "")
            Me.txtTaxBase.Name = "txtTaxBase"
            Me.txtTaxBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
            Me.Validator.SetRequired(Me.txtTaxBase, False)
            Me.txtTaxBase.Size = New System.Drawing.Size(144, 21)
            Me.txtTaxBase.TabIndex = 44
            Me.txtTaxBase.TabStop = False
            Me.txtTaxBase.Text = ""
            Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtBeforeTax
            '
            Me.txtBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtBeforeTax.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtBeforeTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBeforeTax, "")
            Me.Validator.SetGotFocusBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
            Me.txtBeforeTax.Location = New System.Drawing.Point(656, 450)
            Me.Validator.SetMaxValue(Me.txtBeforeTax, "")
            Me.Validator.SetMinValue(Me.txtBeforeTax, "")
            Me.txtBeforeTax.Name = "txtBeforeTax"
            Me.txtBeforeTax.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
            Me.Validator.SetRequired(Me.txtBeforeTax, False)
            Me.txtBeforeTax.Size = New System.Drawing.Size(144, 21)
            Me.txtBeforeTax.TabIndex = 43
            Me.txtBeforeTax.TabStop = False
            Me.txtBeforeTax.Text = ""
            Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtTaxAmount
            '
            Me.txtTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxAmount.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
            Me.txtTaxAmount.Location = New System.Drawing.Point(656, 492)
            Me.Validator.SetMaxValue(Me.txtTaxAmount, "")
            Me.Validator.SetMinValue(Me.txtTaxAmount, "")
            Me.txtTaxAmount.Name = "txtTaxAmount"
            Me.txtTaxAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
            Me.Validator.SetRequired(Me.txtTaxAmount, False)
            Me.txtTaxAmount.Size = New System.Drawing.Size(144, 21)
            Me.txtTaxAmount.TabIndex = 45
            Me.txtTaxAmount.TabStop = False
            Me.txtTaxAmount.Text = ""
            Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtGross
            '
            Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtGross.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGross, "")
            Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.txtGross.Location = New System.Drawing.Point(656, 408)
            Me.Validator.SetMaxValue(Me.txtGross, "")
            Me.Validator.SetMinValue(Me.txtGross, "")
            Me.txtGross.Name = "txtGross"
            Me.txtGross.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGross, "")
            Me.Validator.SetRequired(Me.txtGross, False)
            Me.txtGross.Size = New System.Drawing.Size(144, 21)
            Me.txtGross.TabIndex = 41
            Me.txtGross.TabStop = False
            Me.txtGross.Text = ""
            Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDiscountRate
            '
            Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDiscountRate.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
            Me.txtDiscountRate.Location = New System.Drawing.Point(560, 429)
            Me.Validator.SetMaxValue(Me.txtDiscountRate, "")
            Me.Validator.SetMinValue(Me.txtDiscountRate, "")
            Me.txtDiscountRate.Name = "txtDiscountRate"
            Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
            Me.Validator.SetRequired(Me.txtDiscountRate, False)
            Me.txtDiscountRate.Size = New System.Drawing.Size(88, 21)
            Me.txtDiscountRate.TabIndex = 10
            Me.txtDiscountRate.Text = ""
            '
            'txtAfterTax
            '
            Me.txtAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtAfterTax.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtAfterTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAfterTax, "")
            Me.txtAfterTax.ForeColor = System.Drawing.Color.Blue
            Me.Validator.SetGotFocusBackColor(Me.txtAfterTax, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAfterTax, System.Drawing.Color.Empty)
            Me.txtAfterTax.Location = New System.Drawing.Point(656, 513)
            Me.Validator.SetMaxValue(Me.txtAfterTax, "")
            Me.Validator.SetMinValue(Me.txtAfterTax, "")
            Me.txtAfterTax.Name = "txtAfterTax"
            Me.txtAfterTax.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
            Me.Validator.SetRequired(Me.txtAfterTax, False)
            Me.txtAfterTax.Size = New System.Drawing.Size(144, 21)
            Me.txtAfterTax.TabIndex = 46
            Me.txtAfterTax.TabStop = False
            Me.txtAfterTax.Text = ""
            Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDiscountAmount
            '
            Me.txtDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
            Me.txtDiscountAmount.Location = New System.Drawing.Point(656, 429)
            Me.Validator.SetMaxValue(Me.txtDiscountAmount, "")
            Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
            Me.txtDiscountAmount.Name = "txtDiscountAmount"
            Me.txtDiscountAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
            Me.Validator.SetRequired(Me.txtDiscountAmount, False)
            Me.txtDiscountAmount.Size = New System.Drawing.Size(144, 21)
            Me.txtDiscountAmount.TabIndex = 42
            Me.txtDiscountAmount.TabStop = False
            Me.txtDiscountAmount.Text = ""
            Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtTaxRate
            '
            Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtTaxRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.txtTaxRate.Location = New System.Drawing.Point(528, 492)
            Me.Validator.SetMaxValue(Me.txtTaxRate, "")
            Me.Validator.SetMinValue(Me.txtTaxRate, "")
            Me.txtTaxRate.Name = "txtTaxRate"
            Me.txtTaxRate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
            Me.Validator.SetRequired(Me.txtTaxRate, True)
            Me.txtTaxRate.Size = New System.Drawing.Size(32, 21)
            Me.txtTaxRate.TabIndex = 36
            Me.txtTaxRate.Text = ""
            Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtSupplierName
            '
            Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.txtSupplierName.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMaxValue(Me.txtSupplierName, "")
            Me.Validator.SetMinValue(Me.txtSupplierName, "")
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.txtSupplierName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
            Me.Validator.SetRequired(Me.txtSupplierName, False)
            Me.txtSupplierName.Size = New System.Drawing.Size(168, 21)
            Me.txtSupplierName.TabIndex = 4
            Me.txtSupplierName.TabStop = False
            Me.txtSupplierName.Text = ""
            '
            'txtSupplierCode
            '
            Me.txtSupplierCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.txtSupplierCode.Location = New System.Drawing.Point(88, 16)
            Me.txtSupplierCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtSupplierCode, "")
            Me.Validator.SetMinValue(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
            Me.Validator.SetRequired(Me.txtSupplierCode, True)
            Me.txtSupplierCode.Size = New System.Drawing.Size(64, 21)
            Me.txtSupplierCode.TabIndex = 0
            Me.txtSupplierCode.Text = ""
            '
            'txtCreditPrd
            '
            Me.txtCreditPrd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCreditPrd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
            Me.Validator.SetDisplayName(Me.txtCreditPrd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
            Me.txtCreditPrd.Location = New System.Drawing.Point(88, 40)
            Me.Validator.SetMaxValue(Me.txtCreditPrd, "")
            Me.Validator.SetMinValue(Me.txtCreditPrd, "0")
            Me.txtCreditPrd.Name = "txtCreditPrd"
            Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
            Me.Validator.SetRequired(Me.txtCreditPrd, False)
            Me.txtCreditPrd.Size = New System.Drawing.Size(64, 21)
            Me.txtCreditPrd.TabIndex = 1
            Me.txtCreditPrd.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(96, 16)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'txtInvoiceCode
            '
            Me.Validator.SetDataType(Me.txtInvoiceCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtInvoiceCode, "")
            Me.txtInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
            Me.txtInvoiceCode.Location = New System.Drawing.Point(96, 40)
            Me.txtInvoiceCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtInvoiceCode, "")
            Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
            Me.txtInvoiceCode.Name = "txtInvoiceCode"
            Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
            Me.Validator.SetRequired(Me.txtInvoiceCode, False)
            Me.txtInvoiceCode.Size = New System.Drawing.Size(112, 21)
            Me.txtInvoiceCode.TabIndex = 4
            Me.txtInvoiceCode.TabStop = False
            Me.txtInvoiceCode.Text = ""
            '
            'lblPercent
            '
            Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPercent.BackColor = System.Drawing.Color.Transparent
            Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent.Location = New System.Drawing.Point(560, 493)
            Me.lblPercent.Name = "lblPercent"
            Me.lblPercent.Size = New System.Drawing.Size(16, 18)
            Me.lblPercent.TabIndex = 37
            Me.lblPercent.Text = "%"
            Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblGross
            '
            Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblGross.BackColor = System.Drawing.Color.Transparent
            Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGross.Location = New System.Drawing.Point(576, 409)
            Me.lblGross.Name = "lblGross"
            Me.lblGross.Size = New System.Drawing.Size(80, 18)
            Me.lblGross.TabIndex = 33
            Me.lblGross.Text = "ยอดเงินรวม :"
            Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTaxAmount
            '
            Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxAmount.Location = New System.Drawing.Point(576, 493)
            Me.lblTaxAmount.Name = "lblTaxAmount"
            Me.lblTaxAmount.Size = New System.Drawing.Size(80, 18)
            Me.lblTaxAmount.TabIndex = 39
            Me.lblTaxAmount.Text = "ภาษีมูลค่าเพิ่ม :"
            Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTaxType
            '
            Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxType.Location = New System.Drawing.Point(328, 493)
            Me.lblTaxType.Name = "lblTaxType"
            Me.lblTaxType.Size = New System.Drawing.Size(72, 18)
            Me.lblTaxType.TabIndex = 30
            Me.lblTaxType.Text = "ประเภทภาษี:"
            Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAfterTax
            '
            Me.lblAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAfterTax.BackColor = System.Drawing.Color.Transparent
            Me.lblAfterTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAfterTax.Location = New System.Drawing.Point(560, 514)
            Me.lblAfterTax.Name = "lblAfterTax"
            Me.lblAfterTax.Size = New System.Drawing.Size(96, 18)
            Me.lblAfterTax.TabIndex = 40
            Me.lblAfterTax.Text = "ยอดสุทธิ :"
            Me.lblAfterTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDiscountAmount
            '
            Me.lblDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDiscountAmount.Location = New System.Drawing.Point(504, 432)
            Me.lblDiscountAmount.Name = "lblDiscountAmount"
            Me.lblDiscountAmount.Size = New System.Drawing.Size(48, 18)
            Me.lblDiscountAmount.TabIndex = 31
            Me.lblDiscountAmount.Text = "ส่วนลด :"
            Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTaxBase
            '
            Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxBase.Location = New System.Drawing.Point(544, 472)
            Me.lblTaxBase.Name = "lblTaxBase"
            Me.lblTaxBase.Size = New System.Drawing.Size(112, 18)
            Me.lblTaxBase.TabIndex = 34
            Me.lblTaxBase.Text = "มูลค่าสินค้า/บริการ:"
            Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBeforeTax
            '
            Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
            Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBeforeTax.Location = New System.Drawing.Point(536, 451)
            Me.lblBeforeTax.Name = "lblBeforeTax"
            Me.lblBeforeTax.Size = New System.Drawing.Size(120, 18)
            Me.lblBeforeTax.TabIndex = 32
            Me.lblBeforeTax.Text = "ยอดเงินไม่รวมภาษี :"
            Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbTaxType
            '
            Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTaxType.Location = New System.Drawing.Point(400, 492)
            Me.cmbTaxType.Name = "cmbTaxType"
            Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
            Me.cmbTaxType.TabIndex = 11
            '
            'lblTaxRate
            '
            Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxRate.Location = New System.Drawing.Point(464, 493)
            Me.lblTaxRate.Name = "lblTaxRate"
            Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
            Me.lblTaxRate.TabIndex = 35
            Me.lblTaxRate.Text = "อัตราภาษี :"
            Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(104, 208)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 28
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(128, 208)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 29
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnBlankDoc
            '
            Me.ibtnBlankDoc.Image = CType(resources.GetObject("ibtnBlankDoc.Image"), System.Drawing.Image)
            Me.ibtnBlankDoc.Location = New System.Drawing.Point(104, 64)
            Me.ibtnBlankDoc.Name = "ibtnBlankDoc"
            Me.ibtnBlankDoc.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlankDoc.TabIndex = 24
            Me.ibtnBlankDoc.TabStop = False
            Me.ibtnBlankDoc.ThemedImage = CType(resources.GetObject("ibtnBlankDoc.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelDoc
            '
            Me.ibtnDelDoc.Image = CType(resources.GetObject("ibtnDelDoc.Image"), System.Drawing.Image)
            Me.ibtnDelDoc.Location = New System.Drawing.Point(128, 64)
            Me.ibtnDelDoc.Name = "ibtnDelDoc"
            Me.ibtnDelDoc.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelDoc.TabIndex = 25
            Me.ibtnDelDoc.TabStop = False
            Me.ibtnDelDoc.ThemedImage = CType(resources.GetObject("ibtnDelDoc.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbDelivery
            '
            Me.grbDelivery.Controls.Add(Me.ibtnShowSupplier)
            Me.grbDelivery.Controls.Add(Me.txtSupplierName)
            Me.grbDelivery.Controls.Add(Me.ibtnShowSupplierDialog)
            Me.grbDelivery.Controls.Add(Me.lblSupplier)
            Me.grbDelivery.Controls.Add(Me.txtSupplierCode)
            Me.grbDelivery.Controls.Add(Me.lblCreditPrd)
            Me.grbDelivery.Controls.Add(Me.lblDay)
            Me.grbDelivery.Controls.Add(Me.txtCreditPrd)
            Me.grbDelivery.Controls.Add(Me.lblDueDate)
            Me.grbDelivery.Controls.Add(Me.dtpDueDate)
            Me.grbDelivery.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDelivery.Location = New System.Drawing.Point(376, 0)
            Me.grbDelivery.Name = "grbDelivery"
            Me.grbDelivery.Size = New System.Drawing.Size(384, 72)
            Me.grbDelivery.TabIndex = 6
            Me.grbDelivery.TabStop = False
            Me.grbDelivery.Text = "ผู้ขาย"
            '
            'ibtnShowSupplier
            '
            Me.ibtnShowSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowSupplier.Image = CType(resources.GetObject("ibtnShowSupplier.Image"), System.Drawing.Image)
            Me.ibtnShowSupplier.Location = New System.Drawing.Point(344, 16)
            Me.ibtnShowSupplier.Name = "ibtnShowSupplier"
            Me.ibtnShowSupplier.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowSupplier.TabIndex = 10
            Me.ibtnShowSupplier.TabStop = False
            Me.ibtnShowSupplier.ThemedImage = CType(resources.GetObject("ibtnShowSupplier.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowSupplierDialog
            '
            Me.ibtnShowSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowSupplierDialog.Image = CType(resources.GetObject("ibtnShowSupplierDialog.Image"), System.Drawing.Image)
            Me.ibtnShowSupplierDialog.Location = New System.Drawing.Point(320, 16)
            Me.ibtnShowSupplierDialog.Name = "ibtnShowSupplierDialog"
            Me.ibtnShowSupplierDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowSupplierDialog.TabIndex = 9
            Me.ibtnShowSupplierDialog.TabStop = False
            Me.ibtnShowSupplierDialog.ThemedImage = CType(resources.GetObject("ibtnShowSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblSupplier
            '
            Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplier.Location = New System.Drawing.Point(8, 16)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(80, 18)
            Me.lblSupplier.TabIndex = 2
            Me.lblSupplier.Text = "ผู้ขาย:"
            Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCreditPrd
            '
            Me.lblCreditPrd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditPrd.Location = New System.Drawing.Point(8, 40)
            Me.lblCreditPrd.Name = "lblCreditPrd"
            Me.lblCreditPrd.Size = New System.Drawing.Size(80, 18)
            Me.lblCreditPrd.TabIndex = 3
            Me.lblCreditPrd.Text = "ระยะเครดิต:"
            Me.lblCreditPrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDay
            '
            Me.lblDay.AutoSize = True
            Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDay.Location = New System.Drawing.Point(152, 42)
            Me.lblDay.Name = "lblDay"
            Me.lblDay.Size = New System.Drawing.Size(17, 17)
            Me.lblDay.TabIndex = 5
            Me.lblDay.Text = "วัน"
            Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDueDate
            '
            Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDate.ForeColor = System.Drawing.Color.Black
            Me.lblDueDate.Location = New System.Drawing.Point(176, 41)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(88, 18)
            Me.lblDueDate.TabIndex = 6
            Me.lblDueDate.Text = "วันที่:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDueDate
            '
            Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDueDate.Enabled = False
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDueDate.Location = New System.Drawing.Point(272, 40)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpDueDate.TabIndex = 8
            Me.dtpDueDate.TabStop = False
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(184, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 16
            '
            'dtpDocDate
            '
            Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDocDate.Location = New System.Drawing.Point(240, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpDocDate.TabIndex = 20
            Me.dtpDocDate.TabStop = False
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.ForeColor = System.Drawing.Color.Black
            Me.lblDocDate.Location = New System.Drawing.Point(200, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
            Me.lblDocDate.TabIndex = 17
            Me.lblDocDate.Text = "วันที่:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.lblInvoiceDate.Location = New System.Drawing.Point(200, 40)
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            Me.lblInvoiceDate.Size = New System.Drawing.Size(40, 18)
            Me.lblInvoiceDate.TabIndex = 19
            Me.lblInvoiceDate.Text = "วันที่:"
            Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpInvoiceDate
            '
            Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(240, 40)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpInvoiceDate.TabIndex = 22
            Me.dtpInvoiceDate.TabStop = False
            '
            'ibtnEnableVatInput
            '
            Me.ibtnEnableVatInput.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnEnableVatInput.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnEnableVatInput.Image = CType(resources.GetObject("ibtnEnableVatInput.Image"), System.Drawing.Image)
            Me.ibtnEnableVatInput.Location = New System.Drawing.Point(336, 40)
            Me.ibtnEnableVatInput.Name = "ibtnEnableVatInput"
            Me.ibtnEnableVatInput.Size = New System.Drawing.Size(24, 24)
            Me.ibtnEnableVatInput.TabIndex = 23
            Me.ibtnEnableVatInput.TabStop = False
            Me.ibtnEnableVatInput.ThemedImage = CType(resources.GetObject("ibtnEnableVatInput.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 12
            Me.lblCode.Text = "เลขที่ใบเพิ่มหนี้:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblInvoiceCode
            '
            Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
            Me.lblInvoiceCode.Location = New System.Drawing.Point(0, 40)
            Me.lblInvoiceCode.Name = "lblInvoiceCode"
            Me.lblInvoiceCode.Size = New System.Drawing.Size(96, 18)
            Me.lblInvoiceCode.TabIndex = 14
            Me.lblInvoiceCode.Text = "เลขที่ใบกำกับภาษี:"
            Me.lblInvoiceCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tgWBS
            '
            Me.tgWBS.AllowNew = False
            Me.tgWBS.AllowSorting = False
            Me.tgWBS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgWBS.AutoColumnResize = True
            Me.tgWBS.CaptionVisible = False
            Me.tgWBS.Cellchanged = False
            Me.tgWBS.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))})
            Me.tgWBS.DataMember = ""
            Me.tgWBS.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgWBS.Location = New System.Drawing.Point(8, 424)
            Me.tgWBS.Name = "tgWBS"
            Me.tgWBS.Size = New System.Drawing.Size(320, 128)
            Me.tgWBS.SortingArrowColor = System.Drawing.Color.Red
            Me.tgWBS.TabIndex = 47
            Me.tgWBS.TreeManager = Nothing
            '
            'ibtnAddWBS
            '
            Me.ibtnAddWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnAddWBS.Image = CType(resources.GetObject("ibtnAddWBS.Image"), System.Drawing.Image)
            Me.ibtnAddWBS.Location = New System.Drawing.Point(104, 400)
            Me.ibtnAddWBS.Name = "ibtnAddWBS"
            Me.ibtnAddWBS.Size = New System.Drawing.Size(24, 24)
            Me.ibtnAddWBS.TabIndex = 49
            Me.ibtnAddWBS.TabStop = False
            Me.ibtnAddWBS.ThemedImage = CType(resources.GetObject("ibtnAddWBS.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelWBS
            '
            Me.ibtnDelWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnDelWBS.Image = CType(resources.GetObject("ibtnDelWBS.Image"), System.Drawing.Image)
            Me.ibtnDelWBS.Location = New System.Drawing.Point(128, 400)
            Me.ibtnDelWBS.Name = "ibtnDelWBS"
            Me.ibtnDelWBS.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelWBS.TabIndex = 50
            Me.ibtnDelWBS.TabStop = False
            Me.ibtnDelWBS.ThemedImage = CType(resources.GetObject("ibtnDelWBS.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblWBS
            '
            Me.lblWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblWBS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblWBS.ForeColor = System.Drawing.Color.Black
            Me.lblWBS.Location = New System.Drawing.Point(8, 408)
            Me.lblWBS.Name = "lblWBS"
            Me.lblWBS.Size = New System.Drawing.Size(104, 18)
            Me.lblWBS.TabIndex = 48
            Me.lblWBS.Text = "จัดสรร WBS:"
            Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'PurchaseDNDetailView
            '
            Me.Controls.Add(Me.tgWBS)
            Me.Controls.Add(Me.ibtnAddWBS)
            Me.Controls.Add(Me.ibtnDelWBS)
            Me.Controls.Add(Me.lblWBS)
            Me.Controls.Add(Me.chkAutorun)
            Me.Controls.Add(Me.txtDocDate)
            Me.Controls.Add(Me.dtpDocDate)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblDocDate)
            Me.Controls.Add(Me.txtInvoiceCode)
            Me.Controls.Add(Me.lblInvoiceDate)
            Me.Controls.Add(Me.txtInvoiceDate)
            Me.Controls.Add(Me.dtpInvoiceDate)
            Me.Controls.Add(Me.ibtnEnableVatInput)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.lblInvoiceCode)
            Me.Controls.Add(Me.grbDelivery)
            Me.Controls.Add(Me.ibtnBlankDoc)
            Me.Controls.Add(Me.ibtnDelDoc)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.lblPercent)
            Me.Controls.Add(Me.txtTaxBase)
            Me.Controls.Add(Me.txtBeforeTax)
            Me.Controls.Add(Me.txtTaxAmount)
            Me.Controls.Add(Me.lblGross)
            Me.Controls.Add(Me.lblTaxAmount)
            Me.Controls.Add(Me.txtGross)
            Me.Controls.Add(Me.txtDiscountRate)
            Me.Controls.Add(Me.lblTaxType)
            Me.Controls.Add(Me.txtAfterTax)
            Me.Controls.Add(Me.lblAfterTax)
            Me.Controls.Add(Me.lblDiscountAmount)
            Me.Controls.Add(Me.lblTaxBase)
            Me.Controls.Add(Me.lblBeforeTax)
            Me.Controls.Add(Me.cmbTaxType)
            Me.Controls.Add(Me.txtDiscountAmount)
            Me.Controls.Add(Me.txtTaxRate)
            Me.Controls.Add(Me.lblTaxRate)
            Me.Controls.Add(Me.grbSummary)
            Me.Controls.Add(Me.cmbNote)
            Me.Controls.Add(Me.tgRefDoc)
            Me.Controls.Add(Me.lblNote)
            Me.Controls.Add(Me.lblItemRf)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.lblItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "PurchaseDNDetailView"
            Me.Size = New System.Drawing.Size(824, 560)
            CType(Me.tgRefDoc, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbSummary.ResumeLayout(False)
            Me.grbDelivery.ResumeLayout(False)
            CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region "Members"
        Private m_entity As PurchaseDN
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
        Private m_docTreeManager As TreeManager
        Private m_docCollInitialized As Boolean
        Private m_itemInitialized As Boolean

        Private m_tableStyleEnable As Hashtable

        Private m_enableState As Hashtable

        Private m_wbsTreeManager As TreeManager
        Private m_wbsdInitialized As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            SaveEnableState()
            m_tableStyleEnable = New Hashtable

            Dim dt As TreeTable = PurchaseDN.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False

            Wire()

            Dim dtDoc As TreeTable = PurchaseDN.GetDocSchemaTable()
            Dim dstDoc As DataGridTableStyle = Me.CreateDocTableStyle()
            m_docTreeManager = New TreeManager(dtDoc, tgRefDoc)
            m_docTreeManager.SetTableStyle(dstDoc)
            m_docTreeManager.AllowSorting = False
            m_docTreeManager.AllowDelete = False

            AddHandler dtDoc.ColumnChanging, AddressOf DocTreetable_ColumnChanging
            AddHandler dtDoc.ColumnChanged, AddressOf DocTreetable_ColumnChanged
            AddHandler dtDoc.RowDeleted, AddressOf DocItemDelete

            Dim dtWBS As TreeTable = Me.GetSchemaTable()
            Dim dstWBS As DataGridTableStyle = Me.CreateWBSTableStyle()
            m_wbsTreeManager = New TreeManager(dtWBS, tgWBS)
            m_wbsTreeManager.SetTableStyle(dstWBS)
            m_wbsTreeManager.AllowSorting = False
            m_wbsTreeManager.AllowDelete = False

            AddHandler dtWBS.ColumnChanging, AddressOf WBSTreetable_ColumnChanging
            AddHandler dtWBS.ColumnChanged, AddressOf WBSTreetable_ColumnChanged
            AddHandler dtWBS.RowDeleted, AddressOf WBSItemDelete

            EventWiring()
        End Sub
        Private Sub Wire()
            AddHandler m_treeManager.Treetable.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler m_treeManager.Treetable.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler m_treeManager.Treetable.RowDeleted, AddressOf ItemDelete
        End Sub
        Private Sub UnWire()
            RemoveHandler m_treeManager.Treetable.ColumnChanging, AddressOf Treetable_ColumnChanging
            RemoveHandler m_treeManager.Treetable.ColumnChanged, AddressOf Treetable_ColumnChanged
            RemoveHandler m_treeManager.Treetable.RowDeleted, AddressOf ItemDelete
        End Sub
        Private Sub SaveEnableState()
            m_enableState = New Hashtable
            For Each ctrl As Control In Me.grbDelivery.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
            For Each ctrl As Control In Me.grbSummary.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
            For Each ctrl As Control In Me.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
        End Sub
#End Region

#Region "Style"
        Private Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("WBS")
            myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("WBS", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Percent", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
            Return myDatatable
        End Function
        Public Function CreateWBSTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "WBS"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "LineNumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "LineNumber"

            Dim csWBS As New TreeTextColumn
            csWBS.MappingName = "WBS"
            csWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.WBSHeaderText}")
            csWBS.NullText = ""
            csWBS.Width = 100
            csWBS.ReadOnly = True
            csWBS.TextBox.Name = "WBS"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf WBSButtonClicked

            Dim csPercent As New TreeTextColumn
            csPercent.MappingName = "Percent"
            csPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.PercentHeaderText}")
            csPercent.NullText = ""
            csPercent.DataAlignment = HorizontalAlignment.Right
            csPercent.Format = "#,###.##"
            csPercent.TextBox.Name = "Percent"

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "Amount"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmoluntHeaderText}")
            csAmount.NullText = ""
            csAmount.DataAlignment = HorizontalAlignment.Right
            csAmount.Format = "#,###.##"
            csAmount.TextBox.Name = "Amount"
            csAmount.ReadOnly = True

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csWBS)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csPercent)
            dst.GridColumnStyles.Add(csAmount)

            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
        Public Sub WBSButtonClicked(ByVal e As ButtonColumnEventArgs)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim currWorkingDoc As DNRefDoc = Me.CurrentWorkingDoc
            If currWorkingDoc Is Nothing Then
                Return
            End If
            If currWorkingDoc.ToCostCenter Is Nothing Then
                msgServ.ShowMessage("${res:Global.Error.SelectRefDocWithCC}")
                Return
            End If
            If currWorkingDoc.ToCostCenter.BoqId = 0 Then
                msgServ.ShowMessage("${res:Global.Error.SelectRefDocWithBOQ}")
                Return
            End If
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            If currItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotEditWBS}")
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filters(0) As Filter
            filters(0) = New Filter("boq_id", currWorkingDoc.ToCostCenter.BoqId)
            myEntityPanelService.OpenTreeDialog(New WBS, AddressOf SetWBS)
        End Sub
        Private Sub SetWBS(ByVal wbs As ISimpleEntity)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim currWorkingDoc As DNRefDoc = Me.CurrentWorkingDoc
            If currWorkingDoc Is Nothing Then
                Return
            End If
            If currWorkingDoc.ToCostCenter Is Nothing Then
                msgServ.ShowMessage("${res:Global.Error.SelectRefDocWithCC}")
                Return
            End If
            If currWorkingDoc.ToCostCenter.BoqId = 0 Then
                msgServ.ShowMessage("${res:Global.Error.SelectRefDocWithBOQ}")
                Return
            End If
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            If currItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotEditWBS}")
                Return
            End If
            Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
            Dim wsdColl As WBSDistributeCollection = currItem.WbsdColl
            Me.CurrentWsbsd.WBS = CType(wbs, wbs)
            'wbs
            m_wbsdInitialized = False
            'wsdColl.Populate(dt, currItem.Amount)
            m_wbsdInitialized = True
        End Sub
        Public Function CreateDocTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "PurchaseDNDoc"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "Linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetail.DocLineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "Linenumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetail.DocCodeHeaderText}")
            csCode.NullText = ""
            'Hack ไปก่อน
            csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf DocButtonClicked

            Dim csRealAmount As New TreeTextColumn
            csRealAmount.MappingName = "RealAmount"
            csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetail.DocRealAmountHeaderText}")
            csRealAmount.NullText = ""
            csRealAmount.TextBox.Name = "RealAmount"
            csRealAmount.ReadOnly = True
            csRealAmount.Format = "#,###.##"

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "stockstock_amt"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetail.DocAmountHeaderText}")
            csAmount.NullText = ""
            csAmount.TextBox.Name = "stockstock_amt"
            csAmount.Format = "#,###.##"

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "stockstock_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetail.DocNoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "stockstock_note"

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csRealAmount)
            dst.GridColumnStyles.Add(csAmount)
            dst.GridColumnStyles.Add(csNote)

            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
        Public Sub DocButtonClicked(ByVal e As ButtonColumnEventArgs)
            DocButtonClick(e)
        End Sub
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "PurchaseDN"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csRef As New DataGridCheckBoxColumn
            csRef.MappingName = "Ref"
            csRef.HeaderText = "R" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnVatableHeaderText}")
            csRef.Width = 30
            csRef.ReadOnly = True
            csRef.InvisibleWhenUnspcified = True

            'Stock Items
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "stocki_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "stocki_linenumber"

            Dim csBarrier As New DataGridBarrierColumn
            csBarrier.MappingName = "Barrier"
            csBarrier.HeaderText = ""
            csBarrier.NullText = ""
            csBarrier.ReadOnly = True

            Dim csType As DataGridComboColumn
            csType = New DataGridComboColumn("stocki_entityType" _
            , CodeDescription.GetCodeList("stocki_enitytype") _
            , "code_description", "code_value")
            csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.TypeHeaderText}")
            csType.NullText = String.Empty

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 100
            'csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""

            Dim csName As New TreeTextColumn
            csName.MappingName = "stocki_itemName"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.DescriptionHeaderText}")
            csName.NullText = ""
            csName.Width = 200
            csName.TextBox.Name = "Description"
            'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
            'csDescription.ReadOnly = True

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnitHeaderText}")
            csUnit.NullText = ""
            csUnit.TextBox.Name = "Unit"
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csUnitButton As New DataGridButtonColumn
            csUnitButton.MappingName = "UnitButton"
            csUnitButton.HeaderText = ""
            csUnitButton.NullText = ""
            AddHandler csUnitButton.Click, AddressOf ButtonClicked

            Dim csQty As New TreeTextColumn
            csQty.MappingName = "stocki_qty"
            csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.QtyHeaderText}")
            csQty.NullText = ""
            csQty.DataAlignment = HorizontalAlignment.Right
            csQty.Format = "#,###.##"
            csQty.TextBox.Name = "Qty"

            Dim csStockQty As New TreeTextColumn
            csStockQty.MappingName = "StockQty"
            csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.StockQtyHeaderText}")
            csStockQty.NullText = ""
            csStockQty.DataAlignment = HorizontalAlignment.Right
            csStockQty.Format = "#,###.##"
            csStockQty.ReadOnly = True

            Dim csUnitPRice As New TreeTextColumn
            csUnitPRice.MappingName = "stocki_unitprice"
            csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnitpriceHeaderText}")
            csUnitPRice.NullText = ""
            csUnitPRice.TextBox.Name = "stocki_unitprice"
            csUnitPRice.DataAlignment = HorizontalAlignment.Right

            Dim csDiscount As New TreeTextColumn
            csDiscount.MappingName = "stocki_discrate"
            csDiscount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.DiscountHeaderText}")
            csDiscount.NullText = ""
            csDiscount.TextBox.Name = "stocki_discrate"

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "Amount"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmountHeaderText}")
            csAmount.NullText = ""
            csAmount.TextBox.Name = "Amount"
            csAmount.ReadOnly = True
            csAmount.Format = "#,###.##"
            csAmount.DataAlignment = HorizontalAlignment.Right

            Dim csAccountCode As New TreeTextColumn
            csAccountCode.MappingName = "AccountCode"
            csAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountCodeHeaderText}")
            csAccountCode.NullText = ""
            csAccountCode.TextBox.Name = "AccountCode"

            Dim csAccount As New TreeTextColumn
            csAccount.MappingName = "Account"
            csAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountHeaderText}")
            csAccount.NullText = ""
            csAccount.ReadOnly = True
            csAccount.TextBox.Name = "Account"

            Dim csAccountButton As New DataGridButtonColumn
            csAccountButton.MappingName = "AccountButton"
            csAccountButton.HeaderText = ""
            csAccountButton.NullText = ""

            Dim csVatable As New DataGridCheckBoxColumn
            csVatable.MappingName = "stocki_unvatable"
            csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnVatableHeaderText}")
            csVatable.Width = 100
            csVatable.InvisibleWhenUnspcified = True

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "stocki_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "stocki_note"

            dst.GridColumnStyles.Add(csRef)
            dst.GridColumnStyles.Add(csType)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csUnitButton)
            dst.GridColumnStyles.Add(csQty)
            dst.GridColumnStyles.Add(csUnitPRice)
            dst.GridColumnStyles.Add(csDiscount)
            dst.GridColumnStyles.Add(csAmount)
            dst.GridColumnStyles.Add(csAccountCode)
            dst.GridColumnStyles.Add(csAccountButton)
            dst.GridColumnStyles.Add(csAccount)
            dst.GridColumnStyles.Add(csVatable)
            dst.GridColumnStyles.Add(csNote)

            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
        Public Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 6 Then
                Me.UnitButtonClick(e)
            ElseIf e.Column = 3 Then
                Me.ItemButtonClick(e)
            Else
                Me.AcctButtonClick(e)
            End If
        End Sub
#End Region

#Region "Properties"
        Private ReadOnly Property CurrentWorkingDoc() As DNRefDoc
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If TypeOf row.Tag Is PurchaseDNItem Then
                    Return CType(CType(row.Parent, TreeRow).Tag, DNRefDoc)
                End If
                If TypeOf row.Tag Is DNRefDoc Then
                    Return CType(row.Tag, DNRefDoc)
                End If
                Return Nothing
            End Get
        End Property
        Private ReadOnly Property CurrentDoc() As DNRefDoc
            Get
                Dim row As TreeRow = Me.m_docTreeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is DNRefDoc Then
                    Return Nothing
                End If
                Return CType(row.Tag, DNRefDoc)
            End Get
        End Property
        Private ReadOnly Property CurrentItem() As PurchaseDNItem
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is PurchaseDNItem Then
                    Return Nothing
                End If
                Return CType(row.Tag, PurchaseDNItem)
            End Get
        End Property
        Private ReadOnly Property CurrentWsbsd() As WBSDistribute
            Get
                Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                Return CType(row.Tag, WBSDistribute)
            End Get
        End Property
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_itemInitialized Then
                Return
            End If
            If CType(e.Row, TreeRow).Level = 0 Then
                Return
            End If
            Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                If index = Me.m_treeManager.Treetable.Childs.Count - 1 Then
                    Me.m_treeManager.Treetable.Childs.Add()
                End If
                If e.Column.ColumnName.ToLower <> "amount" Then
                    UpdateAmount(e)
                End If
                Me.m_treeManager.Treetable.AcceptChanges()
            End If
        End Sub
        Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
            Dim pdnItem As PurchaseDNItem = Me.CurrentItem
            If pdnItem Is Nothing Then
                Return
            End If
            pdnItem.CopyFromDataRow(CType(e.Row, TreeRow))
            e.Row("Amount") = Configuration.FormatToString(pdnItem.Amount, DigitConfig.Price)
            UpdateAmount()
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_itemInitialized Then
                Return
            End If
            If CType(e.Row, TreeRow).Level = 0 Then
                e.ProposedValue = e.Row(e.Column)
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetCode(e)
                    Case "stocki_itemname"
                        SetName(e)
                    Case "unit"
                        SetUnitValue(e)
                    Case "stocki_qty"
                        SetQty(e)
                    Case "stocki_unitprice"
                        SetUnitPrice(e)
                    Case "accountcode"
                        SetAccount(e)
                    Case "stocki_entitytype"
                        SetEntityType(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim code As Object = e.Row("code")
            Dim stocki_itemname As Object = e.Row("stocki_itemname")
            Dim stocki_entitytype As Object = e.Row("stocki_entitytype")
            Dim accountcode As Object = e.Row("accountcode")
            Dim unit As Object = e.Row("unit")
            Dim stocki_unitprice As Object = e.Row("stocki_unitprice")
            Dim stocki_qty As Object = e.Row("stocki_qty")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    code = e.ProposedValue
                Case "stocki_itemname"
                    stocki_itemname = e.ProposedValue
                Case "stocki_entitytype"
                    stocki_entitytype = e.ProposedValue
                Case "accountcode"
                    accountcode = e.ProposedValue
                Case "unit"
                    unit = e.ProposedValue
                Case "stocki_unitprice"
                    stocki_unitprice = e.ProposedValue
                Case "stocki_qty"
                    stocki_qty = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If IsDBNull(stocki_entitytype) Then
                isBlankRow = True
            End If

            If Not isBlankRow Then
                Select Case CInt(stocki_entitytype)
                    Case 0, 88, 89 'blank item /ค่าแรง/เครื่องจักร
                        If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                            e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_itemname", "")
                        End If
                        If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                            e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_qty", "")
                        End If
                        If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                            e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_unitprice", "")
                        End If
                        If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                            e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                        Else
                            e.Row.SetColumnError("accountcode", "")
                        End If
                        e.Row.SetColumnError("code", "")
                    Case 19 'เครื่องมือ
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                        If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                            e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_itemname", "")
                        End If
                        If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                            e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_qty", "")
                        End If
                        If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                            e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_unitprice", "")
                        End If
                        If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                            e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                        Else
                            e.Row.SetColumnError("accountcode", "")
                        End If
                    Case 28 'F/A
                        If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                            e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_itemname", "")
                        End If
                        If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                            e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_qty", "")
                        End If
                        If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                            e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_unitprice", "")
                        End If
                        If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                            e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                        Else
                            e.Row.SetColumnError("accountcode", "")
                        End If
                        e.Row.SetColumnError("code", "")
                    Case 42 'LCI
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                        If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                            e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_itemname", "")
                        End If
                        If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                            e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_qty", "")
                        End If
                        If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                            e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_unitprice", "")
                        End If
                        If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                            e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                        Else
                            e.Row.SetColumnError("accountcode", "")
                        End If
                    Case Else
                        Return
                End Select
            End If

        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            If row.IsNull("stocki_entitytype") Then
                Return False
            End If
            Return True
        End Function
        Private m_updating As Boolean = False
        Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim pdnItem As PurchaseDNItem = Me.CurrentItem
            If pdnItem Is Nothing Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
            Dim value As Decimal = CDec(e.ProposedValue)
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("stocki_entityType"))
                Case 0, 19, 28, 42, 88, 89
                    'ผ่าน
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            m_updating = False
        End Sub
        Public Sub SetUnitPrice(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim pdnItem As PurchaseDNItem = Me.CurrentItem
            If pdnItem Is Nothing Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.UnitPrice)
            Dim value As Decimal = CDec(e.ProposedValue)
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("stocki_entityType"))
                Case 0, 19, 28, 42, 88, 89
                    'ผ่าน
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            m_updating = False
        End Sub
        Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim pdnItem As PurchaseDNItem = Me.CurrentItem
            If pdnItem Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If pdnItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotBeEdit}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            If e.Row.IsNull(e.Column) Then
                e.Row("Ref") = False
                e.Row("stocki_entity") = DBNull.Value
                e.Row("stocki_itemname") = DBNull.Value
                e.Row("Amount") = DBNull.Value
                e.Row("stocki_qty") = DBNull.Value
                e.Row("StockQty") = DBNull.Value
                e.Row("stocki_unit") = DBNull.Value
                e.Row("stocki_unitprice") = DBNull.Value
                e.Row("stocki_discrate") = DBNull.Value
                e.Row("Unit") = DBNull.Value
                e.Row("UnitButton") = DBNull.Value
                e.Row("stocki_unvatable") = False
                e.Row("stocki_note") = DBNull.Value
                e.Row("Amount") = DBNull.Value
                e.Row("code") = DBNull.Value
                e.Row("stocki_acct") = DBNull.Value
                e.Row("AccountCode") = DBNull.Value
                e.Row("AccountButton") = ""
                e.Row("Account") = DBNull.Value
                If IsNumeric(e.ProposedValue) AndAlso (CInt(e.ProposedValue) = 0 Or CInt(e.ProposedValue) = 28) Then
                    e.Row("Button") = "invisible"
                Else
                    e.Row("Button") = ""
                End If
                m_updating = False
                Return
            End If

            If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
                'ผ่านโลด
                m_updating = False
                Return
            End If
            If msgServ.AskQuestion("${res:Global.Question.ChangePurchaseDNEntityType}") Then
                ClearRow(e)
            Else
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            m_updating = False
        End Sub
        Private Sub ClearRow(ByVal e As DataColumnChangeEventArgs)
            e.Row("Ref") = False
            e.Row("stocki_entity") = DBNull.Value
            e.Row("stocki_itemname") = DBNull.Value
            e.Row("Amount") = DBNull.Value
            e.Row("stocki_qty") = DBNull.Value
            e.Row("StockQty") = DBNull.Value
            e.Row("stocki_unit") = DBNull.Value
            e.Row("stocki_unitprice") = DBNull.Value
            e.Row("stocki_discrate") = DBNull.Value
            e.Row("Unit") = DBNull.Value
            e.Row("UnitButton") = DBNull.Value
            e.Row("stocki_unvatable") = False
            e.Row("stocki_note") = DBNull.Value
            e.Row("Amount") = DBNull.Value
            e.Row("code") = DBNull.Value
            e.Row("stocki_acct") = DBNull.Value
            e.Row("AccountCode") = DBNull.Value
            e.Row("AccountButton") = ""
            e.Row("Account") = DBNull.Value
            If IsNumeric(e.ProposedValue) AndAlso (CInt(e.ProposedValue) = 0 Or CInt(e.ProposedValue) = 28) Then
                e.Row("Button") = "invisible"
            Else
                e.Row("Button") = ""
            End If
        End Sub
        Public Sub SetAccount(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim pdnItem As PurchaseDNItem = Me.CurrentItem
            If pdnItem Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If pdnItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotBeEdit}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Dim entity As New Account(e.ProposedValue.ToString)
            If entity.Originated Then
                e.Row("stocki_acct") = entity.Id
                e.ProposedValue = entity.Code
                e.Row("Account") = entity.Name
                m_updating = False
                pdnItem.CopyFromDataRow(CType(e.Row, TreeRow))
                Return
            Else
                Select Case CInt(e.Row("stocki_entityType"))
                    Case 0, 28, 88, 89
                        e.Row("stocki_acct") = DBNull.Value
                        e.ProposedValue = DBNull.Value
                        e.Row("Account") = DBNull.Value
                        m_updating = False
                        Return
                    Case 19 'Tool
                        If Not pdnItem.Entity Is Nothing AndAlso pdnItem.Entity.Id <> 0 Then
                            Dim myTool As Tool = CType(pdnItem.Entity, Tool)
                            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOther)
                            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
                                e.Row("stocki_acct") = ga.Account.Id
                                e.ProposedValue = ga.Account.Code
                                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                                m_updating = False
                                Return
                            End If
                        End If
                        e.Row("stocki_acct") = DBNull.Value
                        e.ProposedValue = DBNull.Value
                        e.Row("Account") = DBNull.Value
                        m_updating = False
                        Return
                    Case 42 ' Lci
                        Dim item As New PurchaseDNItem
                        item.CopyFromDataRow(CType(e.Row, TreeRow))
                        If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 Then
                            Dim lci As LCIItem = CType(item.Entity, LCIItem)
                            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                                e.Row("stocki_acct") = lci.Account.Id
                                e.ProposedValue = lci.Account.Code
                                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                                m_updating = False
                                Return
                            End If
                        End If
                        e.Row("stocki_acct") = DBNull.Value
                        e.ProposedValue = DBNull.Value
                        e.Row("Account") = DBNull.Value
                        m_updating = False
                        Return
                    Case Else
                        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                End Select
            End If
            m_updating = False
        End Sub
        Public Sub SetName(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim pdnItem As PurchaseDNItem = Me.CurrentItem
            If pdnItem Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If pdnItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotBeEdit}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("stocki_entityType"))
                Case 0, 28, 88, 89
                    'ผ่าน
                    'Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(CInt(e.Row("stocki_entityType")), Me.EntityId)
                    'If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
                    '    e.Row("stocki_acct") = ga.Account.Id
                    '    e.Row("AccountCode") = ga.Account.Code
                    '    e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                    'Else
                    '    e.Row("stocki_acct") = DBNull.Value
                    '    e.Row("AccountCode") = DBNull.Value
                    '    e.Row("Account") = DBNull.Value
                    'End If
                Case 19, 42
                    If Not e.Row.IsNull("Code") AndAlso e.Row("Code").ToString.Length > 0 Then
                        'มี Code อยู่ ---> 
                        If Not IsDBNull(e.ProposedValue) AndAlso Not e.ProposedValue.ToString.Length = 0 Then
                            Dim suffix As String = "<" & pdnItem.Entity.Name & ">"
                            If e.ProposedValue.ToString <> suffix Then
                                If e.ProposedValue.ToString.EndsWith(suffix) Then
                                    Dim s As String = e.ProposedValue.ToString
                                    e.ProposedValue = s.Remove(s.Length - suffix.Length, suffix.Length)
                                End If
                            End If
                            If e.ProposedValue.ToString <> pdnItem.Entity.Name Then
                                e.ProposedValue = e.ProposedValue.ToString & suffix
                            End If
                        End If
                    Else
                        msgServ.ShowMessage("${res:Global.Error.ItemCodeMissing}")
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    End If
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            m_updating = False
        End Sub
        Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
            'If CType(e.Row, TreeRow).Tag Is Nothing Then
            '    Return False
            'End If
            'If IsDBNull(e.ProposedValue) Then
            '    Return False
            'End If
            'Dim tr As TreeRow = CType(e.Row, TreeRow)
            'For Each doc As DNRefDoc In Me.m_entity.RefDocCollection
            '    If Not tr.Tag Is doc Then
            '        If e.ProposedValue.ToString = doc.Code Then
            '            Return True
            '        End If
            '    End If
            'Next
            Return False
        End Function
        Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim pdnItem As PurchaseDNItem = Me.CurrentItem
            If pdnItem Is Nothing Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If pdnItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotBeEdit}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            If DupCode(e) Then
                msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {pdnItem.ItemType.Description, e.ProposedValue.ToString})
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("stocki_entityType"))
                Case 0, 88, 89 'Blank
                    msgServ.ShowMessage("${res:Global.Error.BlankItemORLaborOrEQCannotHaveCode}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
                Case 28 'F/A
                    msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
                Case 19 'Tool
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
                                ClearRow(e)
                                pdnItem.CopyFromDataRow(CType(e.Row, TreeRow))
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim myTool As New Tool(e.ProposedValue.ToString)
                    If Not myTool.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        Dim myUnit As Unit = myTool.Unit
                        e.Row("stocki_entity") = myTool.Id
                        e.ProposedValue = myTool.Code
                        e.Row("stocki_itemName") = myTool.Name
                        If Not myUnit Is Nothing AndAlso myUnit.Originated Then
                            e.Row("stocki_unit") = myUnit.Id
                            e.Row("Unit") = myUnit.Name
                        Else
                            e.Row("stocki_unit") = DBNull.Value
                            e.Row("Unit") = DBNull.Value
                        End If
                        Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOtherIncome)
                        If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
                            e.Row("stocki_acct") = ga.Account.Id
                            e.Row("AccountCode") = ga.Account.Code
                            e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                        Else
                            e.Row("stocki_acct") = DBNull.Value
                            e.Row("AccountCode") = DBNull.Value
                            e.Row("Account") = DBNull.Value
                        End If
                        pdnItem.CopyFromDataRow(CType(e.Row, TreeRow))
                    End If
                Case 42 'LCI
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
                                ClearRow(e)
                                pdnItem.CopyFromDataRow(CType(e.Row, TreeRow))
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim lci As New LCIItem(e.ProposedValue.ToString)
                    If Not lci.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        Dim myUnit As Unit = lci.DefaultUnit
                        e.Row("stocki_entity") = lci.Id
                        e.ProposedValue = lci.Code
                        e.Row("stocki_itemName") = lci.Name
                        If Not myUnit Is Nothing AndAlso myUnit.Originated Then
                            e.Row("stocki_unit") = myUnit.Id
                            e.Row("Unit") = myUnit.Name
                        Else
                            e.Row("stocki_unit") = DBNull.Value
                            e.Row("Unit") = DBNull.Value
                        End If
                        If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                            e.Row("stocki_acct") = lci.Account.Id
                            e.Row("AccountCode") = lci.Account.Code
                            e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                        Else
                            e.Row("stocki_acct") = DBNull.Value
                            e.Row("AccountCode") = DBNull.Value
                            e.Row("Account") = DBNull.Value
                        End If
                        pdnItem.CopyFromDataRow(CType(e.Row, TreeRow))
                    End If
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)

            m_updating = False
        End Sub
        Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim pdnItem As PurchaseDNItem = Me.CurrentItem
            If pdnItem Is Nothing Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If pdnItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotBeEdit}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Dim oldConversion As Decimal = pdnItem.Conversion
            Dim newConversion As Decimal = 1
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            Dim err As String = ""
            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
                If TypeOf pdnItem.Entity Is LCIItem Then
                    If Not CType(pdnItem.Entity, LCIItem).ValidUnit(myUnit) Then
                        err = "${res:Global.Error.NoUnitConversion}"
                    Else
                        newConversion = CType(pdnItem.Entity, LCIItem).GetConversion(myUnit)
                    End If
                ElseIf TypeOf pdnItem.Entity Is Tool Then
                    If Not (Not CType(pdnItem.Entity, Tool).Unit Is Nothing AndAlso CType(pdnItem.Entity, Tool).Unit.Id = myUnit.Id) Then
                        err = "${res:Global.Error.NoUnitConversion}"
                    End If
                End If
            Else
                err = "${res:Global.Error.InvalidUnit}"
            End If
            If err.Length = 0 Then
                If Not e.Row.IsNull("stocki_qty") AndAlso e.Row("stocki_qty").ToString.Length > 0 Then
                    e.Row("stocki_qty") = (oldConversion / newConversion) * CDec(e.Row("stocki_qty"))
                End If
                If Not e.Row.IsNull("stocki_unitprice") AndAlso e.Row("stocki_unitprice").ToString.Length > 0 Then
                    e.Row("stocki_unitprice") = (newConversion / oldConversion) * CDec(e.Row("stocki_unitprice"))
                End If
                e.Row("stocki_unit") = myUnit.Id
                e.ProposedValue = myUnit.Name
            Else
                e.ProposedValue = e.Row(e.Column)
                msgServ.ShowMessage(err)
            End If
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
            'Dim row As DataRow = e.Row
            'Me.m_treeManager.Treetable.Childs.Remove(CType(row, TreeRow))
            'Try
            '    If Not Me.m_isInitialized Then
            '        Return
            '    End If

            '    Dim index As TreeRow = CType(e.Row, TreeRow)
            '    Me.m_treeManager.Treetable.Childs.Remove(index)
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString)
            'End Try
        End Sub
#End Region

#Region "Doc TreeTable Handlers"
        Private Sub DocTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_docCollInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_docTreeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If DocValidateRow(CType(e.Row, TreeRow)) Then
                DocUpdateAmount(e)
                Me.m_docTreeManager.Treetable.AcceptChanges()
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub DocUpdateAmount(ByVal e As DataColumnChangeEventArgs)
            Dim doc As DNRefDoc = Me.CurrentDoc
            If doc Is Nothing Then
                Return
            End If
            UpdateAmount()
        End Sub
        Private Sub DocTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.m_docCollInitialized Then
                Return
            End If
            If Me.m_docTreeManager.SelectedRow Is Nothing Then
                Return
            End If
            If Me.CurrentDoc Is Nothing Then
                Dim doc As New DNRefDoc
                Me.m_entity.RefDocCollection.Add(doc)
                Me.m_docTreeManager.SelectedRow.Tag = doc
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetDocCode(e)
                        Return
                    Case "stockstock_amt"
                        SetDocAmount(e)
                    Case "stockstock_note"
                        SetDocNote(e)
                End Select
                DocValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub DocValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim code As Object = e.Row("code")
            Dim amount As Object = e.Row("stockstock_amt")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    code = e.ProposedValue
                Case "stockstock_amt"
                    amount = e.ProposedValue
            End Select

            'If IsDBNull(amount) OrElse CDec(amount) <= 0 Then
            '    e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.AmountMissing}"))
            'Else
            '    e.Row.SetColumnError("percent", "")
            'End If
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.DNRefDocMissing}"))
            Else
                e.Row.SetColumnError("code", "")
            End If

        End Sub
        Public Function DocValidateRow(ByVal row As TreeRow) As Boolean
            If row.Tag Is Nothing Then
                Return False
            End If
            Return True
        End Function
        Private m_DocUpdating As Boolean = False
        Public Sub SetDocAmount(ByVal e As DataColumnChangeEventArgs)
            If m_DocUpdating Then
                Return
            End If
            Dim doc As DNRefDoc = Me.CurrentDoc
            If doc Is Nothing Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)
            m_DocUpdating = True
            doc.Amount = value
            m_DocUpdating = False
        End Sub
        Public Sub SetDocNote(ByVal e As DataColumnChangeEventArgs)
            If m_DocUpdating Then
                Return
            End If
            Dim doc As DNRefDoc = Me.CurrentDoc
            If doc Is Nothing Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            m_DocUpdating = True
            doc.Note = e.ProposedValue.ToString
            m_DocUpdating = False
        End Sub
        Private Function DupDocCode(ByVal e As DataColumnChangeEventArgs) As Boolean
            If CType(e.Row, TreeRow).Tag Is Nothing Then
                Return False
            End If
            If IsDBNull(e.ProposedValue) Then
                Return False
            End If
            Dim tr As TreeRow = CType(e.Row, TreeRow)
            For Each doc As DNRefDoc In Me.m_entity.RefDocCollection
                If Not tr.Tag Is doc Then
                    If e.ProposedValue.ToString = doc.Code Then
                        Return True
                    End If
                End If
            Next
            Return False
        End Function
        Public Sub SetDocCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_DocUpdating Then
                Return
            End If
            If Me.CurrentDoc Is Nothing Then
                Return
            End If
            Dim doc As DNRefDoc = Me.CurrentDoc
            m_DocUpdating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If DupDocCode(e) Then
                msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {"${res:Global.Error.Billstock}", e.ProposedValue.ToString})
                e.ProposedValue = e.Row(e.Column)
                m_DocUpdating = False
                Return
            End If
            If e.ProposedValue.ToString.Length = 0 Then
                If e.Row(e.Column).ToString.Length <> 0 Then
                    If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteDocDetail}", New String() {e.Row(e.Column).ToString}) Then
                        ClearDocRow(e)
                        Dim currDoc As DNRefDoc = Me.CurrentDoc
                        If Not currDoc Is Nothing Then
                            Me.m_entity.RefDocCollection.Remove(currDoc)
                            RefreshItems()
                            RefreshDocs()
                            UpdateAmount()
                        End If
                    Else
                        e.ProposedValue = e.Row(e.Column)
                    End If
                End If
                m_DocUpdating = False
                Return
            End If
            Dim myGR As New GoodsReceipt(e.ProposedValue.ToString)
            If Not myGR.Originated Then
                msgServ.ShowMessageFormatted("${res:Global.Error.NoGoodsReceipt}", New String() {e.ProposedValue.ToString})
                e.ProposedValue = e.Row(e.Column)
                m_DocUpdating = False
                Return
            Else
                Dim newItem As New DNRefDoc(myGR, Me.m_entity)
                Dim index As Integer = tgRefDoc.CurrentRowIndex
                If Me.m_entity.RefDocCollection.Count = 0 Then
                    Me.m_entity.RefDocCollection.Add(newItem)
                Else
                    If doc Is Nothing Then
                        Me.m_entity.RefDocCollection.Insert(index, newItem)
                        doc = Me.m_entity.RefDocCollection(index)
                    End If
                    doc.Id = newItem.Id
                    doc.Code = newItem.Code
                    doc.RealAmount = newItem.RealAmount
                End If
                RefreshItems()
                RefreshDocs()
                UpdateAmount()
                tgRefDoc.CurrentRowIndex = index
            End If
            m_DocUpdating = False
        End Sub
        Private Sub DocItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

        End Sub
        Private Sub ClearDocRow(ByVal e As DataColumnChangeEventArgs)
            e.Row("Linenumber") = DBNull.Value
            e.Row("Code") = DBNull.Value
            e.Row("RealAmount") = DBNull.Value
            e.Row("stockstock_amt") = DBNull.Value
            e.Row("stockstock_note") = DBNull.Value
        End Sub
#End Region

#Region "WBS TreeTable Handlers"
        Private Sub WBSTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_wbsdInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_wbsTreeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If WBSValidateRow(CType(e.Row, TreeRow)) Then
                'UpdateAmount(e)
                Me.m_wbsTreeManager.Treetable.AcceptChanges()
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub WBSUpdateAmount(ByVal e As DataColumnChangeEventArgs)
            Dim item As WBSDistribute = Me.CurrentWsbsd
            If item Is Nothing Then
                Return
            End If
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            e.Row("Amount") = Configuration.FormatToString(item.Percent * currItem.Amount / 100, DigitConfig.Price)
        End Sub
        Private Sub WBSTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_wbsdInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "wbs"
                        SetWBSCode(e)
                    Case "percent"
                        SetWBSPercent(e)
                End Select
                WBSValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub WBSValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim wbs As Object = e.Row("wbs")
            Dim percent As Object = e.Row("percent")

            Select Case e.Column.ColumnName.ToLower
                Case "wbs"
                    wbs = e.ProposedValue
                Case "percent"
                    percent = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If IsDBNull(wbs) Then
                isBlankRow = True
            End If

            If Not isBlankRow Then
                If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
                    e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
                Else
                    e.Row.SetColumnError("percent", "")
                End If
                If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
                    e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
                Else
                    e.Row.SetColumnError("wbs", "")
                End If
            End If

        End Sub
        Public Function WBSValidateRow(ByVal row As TreeRow) As Boolean
            If row.IsNull("WBS") Then
                Return False
            End If
            Return True
        End Function
        Private m_wbsUpdating As Boolean = False
        Public Sub SetWBSPercent(ByVal e As DataColumnChangeEventArgs)
            If m_wbsUpdating Then
                Return
            End If
            Dim item As WBSDistribute = Me.CurrentWsbsd
            If item Is Nothing Then
                Return
            End If
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If currItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotEditWBS}")
                e.ProposedValue = e.Row(e.Column)
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)
            m_wbsUpdating = True
            item.Percent = value
            m_wbsUpdating = False
        End Sub

        'Private Function DupWBSCode(ByVal e As DataColumnChangeEventArgs) As Boolean
        '    If e.Row.IsNull("stocki_entityType") Then
        '        Return False
        '    End If
        '    If IsDBNull(e.ProposedValue) Then
        '        Return False
        '    End If
        '    For Each row As TreeRow In Me.ItemTable.Childs
        '        If Not row Is e.Row Then
        '            If Not row.IsNull("stocki_entityType") Then
        '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
        '                    If Not row.IsNull("code") Then
        '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
        '                            Return True
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If
        '    Next
        '    Return False
        'End Function
        Public Sub SetWBSCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            'If m_wbsUpdating Then
            '    Return
            'End If
            'm_wbsUpdating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            If currItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotEditWBS}")
                e.ProposedValue = e.Row(e.Column)
                Return
            End If
            'If e.Row.IsNull("stocki_entityType") Then
            '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
            '    e.ProposedValue = e.Row(e.Column)
            '    m_wbsUpdating = False
            '    Return
            'End If
            'If DupCode(e) Then
            '    Dim item As New GoodsReceiptItem
            '    item.CopyFromDataRow(CType(e.Row, TreeRow))
            '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
            '    e.ProposedValue = e.Row(e.Column)
            '    m_wbsUpdating = False
            '    Return
            'End If
            'Select Case CInt(e.Row("stocki_entityType"))
            '    Case 0 'Blank
            '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
            '        e.ProposedValue = e.Row(e.Column)
            '        m_wbsUpdating = False
            '        Return
            '    Case 28 'F/A
            '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
            '        e.ProposedValue = e.Row(e.Column)
            '        m_wbsUpdating = False
            '        Return
            '    Case 19 'Tool
            '        If e.ProposedValue.ToString.Length = 0 Then
            '            If e.Row(e.Column).ToString.Length <> 0 Then
            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
            '                    ClearRow(e)
            '                Else
            '                    e.ProposedValue = e.Row(e.Column)
            '                End If
            '            End If
            '            m_wbsUpdating = False
            '            Return
            '        End If
            '        Dim myTool As New Tool(e.ProposedValue.ToString)
            '        If Not myTool.Originated Then
            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
            '            e.ProposedValue = e.Row(e.Column)
            '            m_wbsUpdating = False
            '            Return
            '        Else
            '            Dim myUnit As Unit = myTool.Unit
            '            e.Row("stocki_entity") = myTool.Id
            '            e.ProposedValue = myTool.Code
            '            e.Row("stocki_itemName") = myTool.Name
            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
            '                e.Row("stocki_unit") = myUnit.Id
            '                e.Row("Unit") = myUnit.Name
            '            Else
            '                e.Row("stocki_unit") = DBNull.Value
            '                e.Row("Unit") = DBNull.Value
            '            End If
            '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
            '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
            '                e.Row("stocki_acct") = ga.Account.Id
            '                e.Row("AccountCode") = ga.Account.Code
            '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            '            Else
            '                e.Row("stocki_acct") = DBNull.Value
            '                e.Row("AccountCode") = DBNull.Value
            '                e.Row("Account") = DBNull.Value
            '            End If
            '        End If
            '    Case 42 'LCI
            '        If e.ProposedValue.ToString.Length = 0 Then
            '            If e.Row(e.Column).ToString.Length <> 0 Then
            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
            '                    ClearRow(e)
            '                Else
            '                    e.ProposedValue = e.Row(e.Column)
            '                End If
            '            End If
            '            m_wbsUpdating = False
            '            Return
            '        End If
            '        Dim lci As New LCIItem(e.ProposedValue.ToString)
            '        If Not lci.Originated Then
            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
            '            e.ProposedValue = e.Row(e.Column)
            '            m_wbsUpdating = False
            '            Return
            '        Else
            '            Dim myUnit As Unit = lci.DefaultUnit
            '            e.Row("stocki_entity") = lci.Id
            '            e.ProposedValue = lci.Code
            '            e.Row("stocki_itemName") = lci.Name
            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
            '                e.Row("stocki_unit") = myUnit.Id
            '                e.Row("Unit") = myUnit.Name
            '            Else
            '                e.Row("stocki_unit") = DBNull.Value
            '                e.Row("Unit") = DBNull.Value
            '            End If
            '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
            '                e.Row("stocki_acct") = lci.Account.Id
            '                e.Row("AccountCode") = lci.Account.Code
            '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            '            Else
            '                e.Row("stocki_acct") = DBNull.Value
            '                e.Row("AccountCode") = DBNull.Value
            '                e.Row("Account") = DBNull.Value
            '            End If
            '        End If
            '    Case Else
            '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
            '        e.ProposedValue = e.Row(e.Column)
            '        m_wbsUpdating = False
            '        Return
            'End Select
            'e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
            'm_wbsUpdating = False
        End Sub
        Private Sub WBSItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Status.Value = 0 _
            OrElse Me.m_entity.Status.Value >= 3 _
            OrElse Me.m_entity.Payment.Status.Value = 0 _
            OrElse Me.m_entity.Payment.Status.Value >= 3 _
            Then
                For Each ctrl As Control In Me.grbDelivery.Controls
                    ctrl.Enabled = False
                Next
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = False
                Next
                tgItem.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next
                Me.tgRefDoc.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_docTreeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next
                Me.tgWBS.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_wbsTreeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next
            Else
                For Each ctrl As Control In Me.grbDelivery.Controls
                    ctrl.Enabled = CBool(m_enableState(ctrl))
                Next
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = CBool(m_enableState(ctrl))
                Next
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next
                For Each colStyle As DataGridColumnStyle In Me.m_docTreeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next
                For Each colStyle As DataGridColumnStyle In Me.m_wbsTreeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next
            End If
        End Sub
        Public Overrides Sub ClearDetail()
            Me.StatusBarService.SetMessage("")
            For Each ctrl As Control In Me.grbDelivery.Controls
                If ctrl.Name.StartsWith("txt") Then
                    ctrl.Text = ""
                End If
            Next
            For Each ctrl As Control In Me.grbSummary.Controls
                If ctrl.Name.StartsWith("txt") Then
                    ctrl.Text = ""
                End If
            Next
            For Each ctrl As Control In Me.Controls
                If ctrl.Name.StartsWith("txt") Then
                    ctrl.Text = ""
                End If
            Next
            Me.dtpDocDate.Value = Now
            cmbTaxType.SelectedIndex = 1
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.grbSummary}")
            Me.lblAdjVal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblAdjVal}")
            Me.lblDiff.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblDiff}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblNote}")
            Me.lblItemRf.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblItemRf}")
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblItem}")
            Me.lbOrgTotalUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblAdjValUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblDiffUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblOrgTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblOrgTotal}")
            Me.grbDelivery.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.grbDelivery}")
            Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblSupplier}")
            Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblCreditPrd}")
            Me.lblDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblDay}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblCode}")
            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblDocDate}")
            Me.lblInvoiceCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblInvoiceCode}")
            Me.lblInvoiceDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblInvoiceDate}")
            Me.lblPercent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblPercent}")
            Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblDiscountAmount}")
            Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblBeforeTax}")
            Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblGross}")
            Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblTaxType}")
            Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblTaxRate}")
            Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblTaxBase}")
            Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblAfterTax}")
            Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblTaxAmount}")
            Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.lblDueDate}")
        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            'AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler

            AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtCreditPrd.Validated, AddressOf Me.ChangeProperty
            AddHandler txtCreditPrd.TextChanged, AddressOf Me.TextHandler

            AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

            AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

            AddHandler txtInvoiceCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtInvoiceDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpInvoiceDate.ValueChanged, AddressOf Me.ChangeProperty

        End Sub
        Private supplierCodeChanged As Boolean = False
        Private txtcreditprdChanged As Boolean = False
        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtsuppliercode"
                    supplierCodeChanged = True
                Case "txtcreditprd"
                    txtcreditprdChanged = True
            End Select
        End Sub
        Private m_oldInvoiceCode As String = ""
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            oldSupId = Me.m_entity.Supplier.Id
            txtCode.Text = m_entity.Code
            txtCreditPrd.Text = m_entity.CreditPeriod.ToString
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

            Dim myVat As Vat = Me.m_entity.Vat
            If Not myVat Is Nothing Then
                If myVat.ItemCollection.Count <= 0 Then  ' No Vat
                    VatInputEnabled(True)
                    Me.txtInvoiceCode.Text = ""
                    Me.txtInvoiceDate.Text = ""
                    Me.dtpInvoiceDate.Value = Now
                ElseIf myVat.ItemCollection.Count = 1 Then
                    VatInputEnabled(True)
                    Dim vi As VatItem
                    vi = myVat.ItemCollection(0)
                    Me.txtInvoiceCode.Text = vi.Code
                    Me.txtInvoiceDate.Text = MinDateToNull(vi.DocDate, "") 'Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                    Me.dtpInvoiceDate.Value = MinDateToNow(vi.DocDate)
                Else
                    VatInputEnabled(False)
                    Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
                    Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
                    Me.dtpInvoiceDate.Value = Now
                End If
            End If
            m_oldInvoiceCode = Me.txtInvoiceCode.Text

            txtSupplierCode.Text = m_entity.Supplier.Code
            txtSupplierName.Text = m_entity.Supplier.Name
            Me.dtpDueDate.Value = Me.m_entity.DueDate

            For Each item As IdValuePair In Me.cmbTaxType.Items
                If Me.m_entity.TaxType.Value = item.Id Then
                    Me.cmbTaxType.SelectedItem = item
                End If
            Next

            RefreshDocs()
            RefreshItems()
            Me.Validator.DataTable = m_treeManager.Treetable

            UpdateAmount()


            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Private Sub VatInputEnabled(ByVal enable As Boolean)
            Me.txtInvoiceCode.Enabled = enable
            Me.txtInvoiceDate.Enabled = enable
            Me.dtpInvoiceDate.Enabled = enable
            If enable Then
                Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.DateTimeType)
                Me.Validator.SetRequired(Me.txtInvoiceCode, True)
                If Me.m_isInitialized Then
                    SetVatToOneDoc()
                End If
            Else
                Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.StringType)
                Me.Validator.SetRequired(Me.txtInvoiceCode, False)
            End If
        End Sub
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If Me.m_isInitialized AndAlso (e.Name = "ItemChanged" Or e.Name = "QtyChanged") Then
                If e.Name = "QtyChanged" Then
                    Me.UpdateAmount()
                End If
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Private m_dateSetting As Boolean = False
        Private oldSupId As Integer
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                    dirtyFlag = True
                    'Case "txtnote"
                    '    Me.m_entity.Note = txtNote.Text
                    '    dirtyFlag = True
                Case "txtsuppliercode"
                    If supplierCodeChanged Then
                        supplierCodeChanged = False
                        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                        If Me.txtSupplierCode.TextLength <> 0 Then
                            Dim oldSupplier As Supplier = Me.m_entity.Supplier
                            Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier)
                            Try
                                If oldSupId <> Me.m_entity.Supplier.Id Then
                                    If oldSupId = 0 OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.Message.ChangeSupplier}", "${res:Longkong.Pojjaman.Gui.Panels.PurchaseDNDetailView.Caption.ChangeSupplier}") Then
                                        oldSupId = Me.m_entity.Supplier.Id
                                        dirtyFlag = True
                                        ChangeSupplier()
                                    Else
                                        dirtyFlag = False
                                        Me.m_entity.Supplier = oldSupplier
                                        Me.txtSupplierCode.Text = oldSupplier.Code
                                        Me.txtSupplierName.Text = oldSupplier.Name
                                        supplierCodeChanged = False
                                    End If
                                End If
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                Case "dtpdocdate"
                    If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.DocDate = dtpDocDate.Value
                            Me.m_entity.Payment.DocDate = dtpDocDate.Value
                            dirtyFlag = True
                            Me.dtpDueDate.Value = Me.m_entity.DueDate
                        End If
                    End If
                Case "txtdocdate"
                    m_dateSetting = True
                    If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDate.Text)
                        If Not Me.m_entity.DocDate.Equals(theDate) Then
                            dtpDocDate.Value = theDate
                            Me.m_entity.DocDate = dtpDocDate.Value
                            Me.m_entity.Payment.DocDate = dtpDocDate.Value
                            dirtyFlag = True
                        End If
                    Else
                        dtpDocDate.Value = Date.Now
                        Me.m_entity.DocDate = Date.MinValue
                        Me.m_entity.Payment.DocDate = Date.MinValue
                    End If
                    Me.dtpDueDate.Value = Me.m_entity.DueDate
                    m_dateSetting = False
                Case "txtcreditprd"
                    If txtcreditprdChanged Then
                        txtcreditprdChanged = False
                        Dim txt As String = Me.txtCreditPrd.Text
                        If txt.Length > 0 AndAlso IsNumeric(txt) Then
                            Me.m_entity.CreditPeriod = CInt(txt)
                        Else
                            Me.m_entity.CreditPeriod = 0
                        End If
                        txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
                        Me.dtpDueDate.Value = Me.m_entity.DueDate
                        dirtyFlag = True
                    End If
                Case "txttaxbase"
                    'Todo
                Case "txtdiscountrate"
                    Me.m_entity.Discount.Rate = txtDiscountRate.Text
                    UpdateAmount()
                    dirtyFlag = True
                Case "cmbtaxtype"
                    Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
                    Me.m_entity.TaxType.Value = item.Id
                    UpdateAmount()
                    dirtyFlag = True
                Case "txtinvoicecode"
                    If m_oldInvoiceCode <> Me.txtInvoiceCode.Text Then
                        Me.m_entity.Vat.CodeChanged(Me.txtInvoiceCode.Text)
                        m_oldInvoiceCode = Me.txtInvoiceCode.Text
                        dirtyFlag = True
                    End If
                Case "txtinvoicedate"
                    m_dateSetting = True
                    dirtyFlag = Me.m_entity.Vat.DateTextChanged(txtInvoiceDate, dtpInvoiceDate, Me.Validator)
                    m_dateSetting = False
                Case "dtpinvoicedate"
                    dirtyFlag = Me.m_entity.Vat.DatePickerChanged(dtpInvoiceDate, txtInvoiceDate, m_dateSetting)
                Case Else
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Private Sub RefreshDocs()
            Me.m_docCollInitialized = False
            Me.m_entity.RefDocCollection.Populate(m_docTreeManager.Treetable)
            Me.m_docCollInitialized = True
            RefreshBlankDocGrid()
            Me.tgRefDoc.RefreshHeights()
        End Sub
        Private Sub RefreshItems()
            m_itemInitialized = False
            UnWire()
            Me.m_entity.RefDocCollection.PopulateItem(m_treeManager.Treetable)
            Wire()
            m_itemInitialized = True
            RefreshBlankGrid()
            Me.tgItem.RefreshHeights()
        End Sub
        Private Sub ChangeSupplier()
            oldSupId = Me.m_entity.Supplier.Id
            For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
                vitem.PrintName = Me.m_entity.Supplier.Name
                vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
                vitem.TaxId = Me.m_entity.Supplier.TaxId
                vitem.BranchId = Me.m_entity.Supplier.BranchId
            Next

            Me.m_entity.RefDocCollection.Clear()
            RefreshDocs()
            RefreshItems()
            UpdateAmount()

            supplierCodeChanged = False
            Me.m_entity.CreditPeriod = Me.m_entity.Supplier.CreditPeriod
            Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
            Me.dtpDueDate.Value = Me.m_entity.DueDate
            txtcreditprdChanged = False
        End Sub
        Private Sub SetVatToNoDoc()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            Me.m_entity.Vat.ItemCollection.Clear()
            Me.txtInvoiceCode.Text = ""
            Me.txtInvoiceDate.Text = ""
            Me.dtpInvoiceDate.Value = Now
            Me.m_isInitialized = flag
        End Sub
        Private Sub SetVatToOneDoc()
            If Me.m_entity.Vat.ItemCollection.Count > 0 Then
                Dim vitem As VatItem = Me.m_entity.Vat.ItemCollection(0)
                If Me.m_entity.Vat.ItemCollection.Count = 1 Then
                    'มี 1 ใบ
                    Dim flag As Boolean = Me.m_isInitialized
                    Me.m_isInitialized = False
                    Me.txtInvoiceCode.Text = vitem.Code
                    Me.txtInvoiceDate.Text = MinDateToNull(vitem.DocDate, "")
                    Me.dtpInvoiceDate.Value = MinDateToNow(vitem.DocDate)
                    Me.m_isInitialized = flag
                Else
                    'มีหลายใบ
                    Dim flag As Boolean = Me.m_isInitialized
                    Me.m_isInitialized = False
                    Me.txtInvoiceCode.Text = ""
                    Me.txtInvoiceDate.Text = MinDateToNull(Now, "")
                    Me.dtpInvoiceDate.Value = Now
                    Me.m_isInitialized = flag
                    vitem.Code = Me.txtInvoiceCode.Text
                    vitem.DocDate = Me.dtpInvoiceDate.Value
                End If
                'If Me.m_entity.Vat.MaxRowIndex = -1 Then 'Not Me.m_entity.Originated Then
                '    vitem.TaxBase = Me.m_entity.TaxBase
                'End If
                vitem.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
                Me.m_entity.Vat.ItemCollection.Clear()
                Me.m_entity.Vat.ItemCollection.Add(vitem)
            Else
                Return

                'ไม่มี Vatitem เลย
                Dim vitem As New VatItem
                vitem.DocDate = Me.m_entity.DocDate
                vitem.PrintName = Me.m_entity.Supplier.Name
                vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
                vitem.TaxId = Me.m_entity.Supplier.TaxId
                vitem.BranchId = Me.m_entity.Supplier.BranchId
                vitem.TaxBase = Me.m_entity.TaxBase
                vitem.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
                Me.m_entity.Vat.ItemCollection.Clear()
                Me.m_entity.Vat.ItemCollection.Add(vitem)
                Me.m_isInitialized = False
                Me.txtInvoiceDate.Text = MinDateToNull(Now, "")
                Me.dtpInvoiceDate.Value = Now
                Me.m_isInitialized = True
            End If
        End Sub
        Private Sub UpdateAmount()
            m_isInitialized = False
            txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
            txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
            txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
            txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
            txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
            txtDiscountRate.Text = m_entity.Discount.Rate
            txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
            txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)

            Dim realAmt As Decimal = m_entity.RefDocCollection.RealAmount
            txtOrgTotal.Text = Configuration.FormatToString(realAmt, DigitConfig.Price)
            txtAdjVal.Text = Configuration.FormatToString(realAmt + m_entity.Gross, DigitConfig.Price)
            txtDiff.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)

            m_isInitialized = True
            SetVatInputAfterAmountChange()
            RefreshWBS()
        End Sub
        Private Sub SetVatInputAfterAmountChange()
            If Me.m_entity.TaxType.Value = 0 Then
                'ไม่มี Vat
                SetVatToNoDoc()
                Me.VatInputEnabled(False)
                Me.ibtnEnableVatInput.Enabled = False
                Dim flag As Boolean = m_isInitialized
                Me.m_isInitialized = False
                Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.NoTaxText}")
                Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.NoTaxText}")
                Me.dtpInvoiceDate.Value = Now
                Me.m_isInitialized = flag
            ElseIf Me.m_entity.Vat.ItemCollection.Count > 1 Then
                'มี Vatitem มากกว่า 1 ใบ
                Me.VatInputEnabled(False)
                Me.ibtnEnableVatInput.Enabled = True
                Dim flag As Boolean = m_isInitialized
                Me.m_isInitialized = False
                Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
                Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
                Me.dtpInvoiceDate.Value = Now
                Me.m_isInitialized = flag
            ElseIf Me.m_entity.Vat.ItemCollection.Count <= 0 Then
                'ไม่มี Vatitem
                Dim flag As Boolean = m_isInitialized
                Me.m_isInitialized = False
                Me.txtInvoiceCode.Text = ""
                Me.txtInvoiceDate.Text = ""
                Me.dtpInvoiceDate.Value = Now
                Me.m_isInitialized = True
                Me.VatInputEnabled(True)
                Me.m_isInitialized = flag
                Me.ibtnEnableVatInput.Enabled = True
            Else
                'มี Vatitem ใบเดียว
                Dim flag As Boolean = m_isInitialized
                Me.m_isInitialized = True
                Me.VatInputEnabled(True)
                Me.m_isInitialized = flag
                Me.ibtnEnableVatInput.Enabled = True
            End If
        End Sub
    Public Sub SetStatus()
    MyBase.SetStatusBarMessage()
    End Sub
        Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)
                If Not m_entity Is Nothing Then
                    RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
                End If
                If Not Object.ReferenceEquals(Me.m_entity, Value) Then
                    Me.m_entity = Nothing
                    Me.m_entity = CType(Value, PurchaseDN)
                End If
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property
        Public Overrides Sub Initialize()
            SetTaxTypeComboBox()
        End Sub
        ' 
        Private Sub SetTaxTypeComboBox()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
            cmbTaxType.SelectedIndex = 1
        End Sub
#End Region

#Region "Event Handler"
        Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddWBS.Click
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim currWorkingDoc As DNRefDoc = Me.CurrentWorkingDoc
            If currWorkingDoc Is Nothing Then
                Return
            End If

            If currWorkingDoc.ToCostCenter Is Nothing Then
                msgServ.ShowMessage("${res:Global.Error.SelectRefDocWithCC}")
                Return
            End If
            If currWorkingDoc.ToCostCenter.BoqId = 0 Then
                msgServ.ShowMessage("${res:Global.Error.SelectRefDocWithBOQ}")
                Return
            End If
            Dim tr As TreeRow = Me.m_treeManager.SelectedRow
            Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
            dt.Clear()
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            If currItem.GoodsReceiptLine <> 0 Then
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotEditWBS}")
                Return
            End If
            Dim wsdColl As WBSDistributeCollection = currItem.WbsdColl
            wsdColl.Add(New WBSDistribute)
            m_wbsdInitialized = False
            'wsdColl.Populate(dt, currItem.Amount)
            m_wbsdInitialized = True
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelWBS.Click
            Dim tr As TreeRow = Me.m_treeManager.SelectedRow
            Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
            dt.Clear()
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim wsdColl As WBSDistributeCollection = currItem.WbsdColl
            If currItem.GoodsReceiptLine <> 0 Then
                m_wbsdInitialized = False
                'wsdColl.Populate(dt, currItem.Amount)
                m_wbsdInitialized = True
                msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotEditWBS}")
                Return
            End If
            If wsdColl.Count > 0 Then
                wsdColl.Remove(wsdColl.Count - 1)
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
            m_wbsdInitialized = False
            'wsdColl.Populate(dt, currItem.Amount)
            m_wbsdInitialized = True
        End Sub
        Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
            RefreshWBS()
        End Sub
        Private Sub RefreshWBS()
            Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
            dt.Clear()
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            Dim wsdColl As WBSDistributeCollection = currItem.WbsdColl
            m_wbsdInitialized = False
            'wsdColl.Populate(dt, currItem.Amount)
            m_wbsdInitialized = True
        End Sub
        Private Sub ibtnEnableVatInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnEnableVatInput.Click
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity.Vat.ItemCollection.Count > 1 Then
                If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.MultipleVatDoc}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.InputTax}") Then
                    Me.VatInputEnabled(True)
                    Me.WorkbenchWindow.ViewContent.IsDirty = True
                End If
            End If
        End Sub
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
        Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAcct)
        End Sub
        Private Sub SetAcct(ByVal acct As ISimpleEntity)
            Me.m_treeManager.SelectedRow("AccountCode") = acct.Code
        End Sub
        Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filters(0) As Filter
            Dim includeFilter As Boolean = False
            If TypeOf currItem.Entity Is Tool Then
                Dim mytool As Tool = CType(currItem.Entity, Tool)
                If Not mytool.Unit Is Nothing AndAlso mytool.Unit.Originated Then
                    filters(0) = New Filter("includedId", mytool.Unit.Id)
                    includeFilter = True
                End If
            ElseIf TypeOf currItem.Entity Is LCIItem Then
                Dim idList As String = CType(currItem.Entity, LCIItem).GetUnitIdList
                If idList.Length > 0 Then
                    filters(0) = New Filter("includedId", idList)
                    includeFilter = True
                End If
            End If
            If includeFilter Then
                myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
            Else
                myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
            End If
        End Sub
        Private Sub SetUnit(ByVal unit As ISimpleEntity)
            Me.m_treeManager.SelectedRow("Unit") = unit.Code
        End Sub
        Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim currWorkingDoc As DNRefDoc = Me.CurrentWorkingDoc
            If currWorkingDoc Is Nothing Then
                Return
            End If
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim dummy As New GoodsReceipt
            dummy.Supplier = Me.m_entity.Supplier
            Dim entities(2) As ISimpleEntity
            entities(0) = New DNRefDoc
            entities(1) = New LCIItem
            entities(2) = New Tool
            Dim filters(2)() As Filter
            filters(0) = New Filter() {New Filter("ExcludeIdList", GetItemIDList), New Filter("stock_id", currWorkingDoc.Id)}
            filters(1) = Nothing
            filters(2) = Nothing
            Dim filterEntities(2) As ArrayList
            For i As Integer = 0 To 2
                filterEntities(i) = New ArrayList
                filterEntities(i).Add(dummy)
            Next
            myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
            '***************** ให้เลือกได้ทุกอย่างจะใช้ง่ายกว่า ******************
            'Select Case currItem.ItemType.Value
            '    Case -1
            '        Dim dummy As New GoodsReceipt
            '        dummy.Supplier = Me.m_entity.Supplier
            '        Dim entities(2) As ISimpleEntity
            '        entities(0) = New DNRefDoc
            '        entities(1) = New LCIItem
            '        entities(2) = New Tool
            '        Dim filters(2)() As Filter
            '        filters(0) = New Filter() {New Filter("ExcludeIdList", GetItemIDList), New Filter("stock_id", currWorkingDoc.Id)}
            '        filters(1) = Nothing
            '        filters(2) = Nothing
            '        Dim filterEntities(2) As ArrayList
            '        For i As Integer = 0 To 2
            '            filterEntities(i) = New ArrayList
            '            filterEntities(i).Add(dummy)
            '        Next
            '        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
            '    Case 0, 28 'Blank
            '        Dim dummy As New GoodsReceipt
            '        dummy.Supplier = Me.m_entity.Supplier
            '        Dim entities(0) As ISimpleEntity
            '        entities(0) = New DNRefDoc
            '        Dim filters(0)() As Filter
            '        filters(0) = New Filter() {New Filter("ExcludeIdList", GetItemIDList), New Filter("stock_id", currWorkingDoc.Id)}
            '        Dim filterEntities(2) As ArrayList
            '        For i As Integer = 0 To 0
            '            filterEntities(i) = New ArrayList
            '            filterEntities(i).Add(dummy)
            '        Next
            '        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
            '    Case 19 'Tool
            '        Dim dummy As New GoodsReceipt
            '        dummy.Supplier = Me.m_entity.Supplier
            '        Dim entities(1) As ISimpleEntity
            '        entities(0) = New DNRefDoc
            '        entities(1) = New Tool
            '        Dim filters(1)() As Filter
            '        filters(0) = New Filter() {New Filter("ExcludeIdList", GetItemIDList), New Filter("stock_id", currWorkingDoc.Id)}
            '        filters(1) = Nothing
            '        Dim filterEntities(1) As ArrayList
            '        For i As Integer = 0 To 1
            '            filterEntities(i) = New ArrayList
            '            filterEntities(i).Add(dummy)
            '        Next
            '        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
            '    Case 42 'LCI
            '        Dim dummy As New GoodsReceipt
            '        dummy.Supplier = Me.m_entity.Supplier
            '        Dim entities(1) As ISimpleEntity
            '        entities(0) = New DNRefDoc
            '        entities(1) = New LCIItem
            '        Dim filters(1)() As Filter
            '        filters(0) = New Filter() {New Filter("ExcludeIdList", GetItemIDList), New Filter("stock_id", currWorkingDoc.Id)}
            '        filters(1) = Nothing
            '        Dim filterEntities(1) As ArrayList
            '        For i As Integer = 0 To 1
            '            filterEntities(i) = New ArrayList
            '            filterEntities(i).Add(dummy)
            '        Next
            '        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities)
            '    Case Else

            'End Select
        End Sub
        Private Function GetItemIDList() As String
            Dim currWorkingDoc As DNRefDoc = Me.CurrentWorkingDoc
            If currWorkingDoc Is Nothing Then
                Return ""
            End If
            Dim ret As String = ""
            For Each item As PurchaseDNItem In currWorkingDoc.ItemCollection
                If item.GoodsReceiptId <> 0 And item.GoodsReceiptLine <> 0 Then
                    ret &= "|" & item.GoodsReceiptId & ":" & item.GoodsReceiptLine & "|"
                End If
            Next
            Return ret
        End Function
        Private Sub SetItems(ByVal items As BasketItemCollection)
            Dim currWorkingDoc As DNRefDoc = Me.CurrentWorkingDoc
            If currWorkingDoc Is Nothing Then
                Return
            End If
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim currIndex As Integer = currWorkingDoc.ItemCollection.IndexOf(currItem)
            For i As Integer = items.Count - 1 To 0 Step -1
                If TypeOf items(i) Is StockBasketItem Then
                    Dim item As StockBasketItem = CType(items(i), StockBasketItem)
                    Dim gi As New GoodsReceiptItem(item.Id, item.Linenumber)
                    If i = items.Count - 1 Then
                        currItem.CopyFromGRItem(gi)
                        currItem.GoodsReceiptId = currWorkingDoc.Id
                        currItem.WbsdColl = gi.WBSDistributeCollection
                    Else
                        Dim newItem As New PurchaseDNItem
                        newItem.CopyFromGRItem(gi)
                        newItem.GoodsReceiptId = currWorkingDoc.Id
                        currWorkingDoc.ItemCollection.Insert(currIndex, newitem)
                    End If
                Else
                    Dim item As BasketItem = CType(items(i), BasketItem)
                    Dim entity As ISimpleEntity
                    Select Case item.FullClassName.ToLower
                        Case "longkong.pojjaman.businesslogic.lciitem"
                            entity = New LCIItem(item.Id)
                        Case "longkong.pojjaman.businesslogic.tool"
                            entity = New Tool(item.Id)
                    End Select
                    If i = items.Count - 1 Then
                        currItem.CopyFromEntity(entity)
                        currItem.GoodsReceiptId = currWorkingDoc.Id
                    Else
                        Dim newItem As New PurchaseDNItem
                        newItem.CopyFromEntity(entity)
                        newItem.GoodsReceiptId = currWorkingDoc.Id
                        currWorkingDoc.ItemCollection.Insert(currIndex, newitem)
                    End If
                End If
            Next
            RefreshItems()
            tgItem.CurrentRowIndex = index
            UpdateAmount()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim currWorkingDoc As DNRefDoc = Me.CurrentWorkingDoc
            If currWorkingDoc Is Nothing Then
                Return
            End If
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            Dim childIndex As Integer
            Dim newItem As New PurchaseDNItem
            If Not currItem Is Nothing Then
                currWorkingDoc.ItemCollection.Insert(currWorkingDoc.ItemCollection.IndexOf(currItem), newItem)
            Else
                currWorkingDoc.ItemCollection.Add(newItem)
            End If
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            RefreshItems()
            RefreshBlankGrid()
            Me.tgItem.CurrentRowIndex = Math.Max(index, 0)
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            UpdateAmount()
            tgItem.RefreshHeights()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim currWorkingDoc As DNRefDoc = Me.CurrentWorkingDoc
            If currWorkingDoc Is Nothing Then
                Return
            End If
            Dim currItem As PurchaseDNItem = Me.CurrentItem
            If currItem Is Nothing Then
                Return
            End If
            currWorkingDoc.ItemCollection.Remove(currItem)
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            RefreshItems()
            RefreshBlankGrid()
            If Me.m_treeManager.Treetable.Rows.Count > 0 Then
                Me.tgItem.CurrentRowIndex = Math.Min(Math.Max(index, 0), Me.m_treeManager.Treetable.Rows.Count - 1)
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            UpdateAmount()
            tgItem.RefreshHeights()
        End Sub
        Public Sub DocButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Supplier Is Nothing OrElse Not Me.m_entity.Supplier.Originated Then
                msgServ.ShowMessage("${res:Global.Error.SpecifySupplier}")
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim dummy As New GoodsReceipt
            dummy.Supplier = Me.m_entity.Supplier
            Dim entities(0) As ISimpleEntity
            entities(0) = dummy
            Dim filters(0)() As Filter
            filters(0) = New Filter() {New Filter("IDList", GetDocIDList)}
            Dim filterEntities(0) As ArrayList
            For i As Integer = 0 To 0
                filterEntities(i) = New ArrayList
                filterEntities(i).Add(dummy)
            Next
            myEntityPanelService.OpenListDialog(entities, AddressOf SetDocs, filters, filterEntities)
        End Sub
        Private Function GetDocIDList() As String
            Dim ret As String = ""
            For Each doc As DNRefDoc In Me.m_entity.RefDocCollection
                If doc.Originated Then
                    ret &= doc.Id.ToString & ","
                End If
            Next
            If ret.EndsWith(",") Then
                ret = ret.Substring(0, ret.Length - 1)
            End If
            Return ret
        End Function
        Private Sub SetDocs(ByVal items As BasketItemCollection)
            Dim index As Integer = tgRefDoc.CurrentRowIndex
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                Dim newItem As DNRefDoc
                If TypeOf item.Tag Is DataRow Then
                    newItem = New DNRefDoc(CType(item.Tag, DataRow), "", Me.m_entity)
                Else
                    newItem = New DNRefDoc(New GoodsReceipt(item.Id), Me.m_entity)
                End If
                If i = items.Count - 1 Then
                    'ตัวแรก -- update old item
                    If Me.m_entity.RefDocCollection.Count = 0 Then
                        Me.m_entity.RefDocCollection.Add(newItem)
                    Else
                        Dim theDoc As DNRefDoc = Me.CurrentDoc
                        If Me.CurrentDoc Is Nothing Then
                            Me.m_entity.RefDocCollection.Insert(index, newItem)
                            theDoc = Me.m_entity.RefDocCollection(index)
                        End If
                        theDoc.Id = newItem.Id
                        theDoc.Code = newItem.Code
                        theDoc.RealAmount = newItem.RealAmount
                    End If
                Else
                    Me.m_entity.RefDocCollection.Insert(index, newItem)
                End If
            Next
            RefreshDocs()
            RefreshItems()
            tgRefDoc.CurrentRowIndex = index
            UpdateAmount()
            tgRefDoc.RefreshHeights()
        End Sub
        Private Sub ibtnBlankDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlankDoc.Click
            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'If Me.m_entity Is Nothing Then
            '    Return
            'End If
            'Dim index As Integer = Me.tgRefDoc.CurrentRowIndex
            'If index = -1 Then
            '    Return
            'End If
            'If index > Me.m_entity.MaxRowIndex Then
            '    Return
            'End If
            'Dim row As TreeRow = CType(Me.m_entity.ItemTable.Rows(index), TreeRow)
            'If row.Level = 0 Then
            '    Return
            'End If
            'Dim parRow As TreeRow = CType(row.Parent, TreeRow)
            'If Not IsDBNull(parRow("poi_po")) AndAlso CStr(parRow("poi_po")).Length > 0 AndAlso CInt(parRow("poi_po")) > 0 Then
            '    Return
            'End If
            'Dim theItem As New PurchaseDNItem
            'Me.m_entity.Insert(index, theItem)
            'Me.m_entity.ItemTable.AcceptChanges()
            'Me.tgRefDoc.CurrentRowIndex = index
            'RefreshBlankGrid()
            'Me.WorkbenchWindow.ViewContent.IsDirty = True
            'UpdateAmount()
        End Sub
        Private Sub ibtnDelDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelDoc.Click
            Dim currDoc As DNRefDoc = Me.CurrentDoc
            If currDoc Is Nothing Then
                Return
            End If
            Dim index As Integer = Me.tgRefDoc.CurrentRowIndex
            Me.m_entity.RefDocCollection.Remove(currDoc)

            RefreshItems()
            RefreshDocs()

            UpdateAmount()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            Me.tgRefDoc.CurrentRowIndex = Math.Min(Math.Max(0, index), Me.m_docTreeManager.Treetable.Rows.Count - 1)
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
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New PO).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Event of Button controls"
        ' Supplier
        Private Sub ibtnShowSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplier.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Supplier)
        End Sub
        Private Sub ibtnShowSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplierDialog.Click
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplier)
        End Sub
        Private Sub SetSupplier(ByVal e As ISimpleEntity)
            Me.txtSupplierCode.Text = e.Code
            Me.ChangeProperty(txtSupplierCode, Nothing)
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
                            Me.SetSupplier(entity)
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
            Return
            If Me.tgItem.Height = 0 Then
                Return
            End If
            Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim maxVisibleCount As Integer
            Dim tgRowHeight As Integer = 17
            maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
            Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
                'เพิ่มแถวจนเต็ม
                Me.m_treeManager.Treetable.Childs.Add()
            Loop
            'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
            '    If Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1 Then
            '        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
            '        Me.m_entity.ItemTable.Childs.Add()
            '    End If
            'End If
            Me.m_treeManager.Treetable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
        Private Sub tgRefDoc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgRefDoc.Resize
            If Me.m_entity Is Nothing Then
                Return
            End If
            RefreshBlankDocGrid()
        End Sub
        Private Sub RefreshBlankDocGrid()
            If Me.tgRefDoc.Height = 0 Then
                Return
            End If
            Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            Dim index As Integer = tgRefDoc.CurrentRowIndex
            Dim maxVisibleCount As Integer
            Dim tgRowHeight As Integer = 17
            maxVisibleCount = CInt(Math.Floor((Me.tgRefDoc.Height - tgRowHeight) / tgRowHeight))
            Do While Me.m_docTreeManager.Treetable.Rows.Count < maxVisibleCount - 1
                'เพิ่มแถวจนเต็ม
                Me.m_docTreeManager.Treetable.Childs.Add()
            Loop
            'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
            '    If Me.m_docTreeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
            '        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
            '        Me.m_docTreeManager.Treetable.Childs.Add()
            '    End If
            'End If
            Me.m_docTreeManager.Treetable.AcceptChanges()
            tgRefDoc.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub

#End Region

    End Class
End Namespace

