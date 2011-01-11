Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Core.AddIns

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class PaySelectionDetail
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
        Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
        Friend WithEvents lblItemCount As System.Windows.Forms.Label
        Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents grbSupplier As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblSupplier As System.Windows.Forms.Label
        Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
        Friend WithEvents lblRemaining As System.Windows.Forms.Label
        Friend WithEvents txtRemaining As System.Windows.Forms.TextBox
        Friend WithEvents lblRemainingUnit As System.Windows.Forms.Label
        Friend WithEvents lblGrossUnit As System.Windows.Forms.Label
        Friend WithEvents txtGross As System.Windows.Forms.TextBox
        Friend WithEvents lblGross As System.Windows.Forms.Label
        Friend WithEvents ibtnShowSupplier As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowSupplierDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblRetention As System.Windows.Forms.Label
        Friend WithEvents txtRetention As System.Windows.Forms.TextBox
        Friend WithEvents lblRetentionUnit As System.Windows.Forms.Label
        Friend WithEvents lblPlusRetentionUnit As System.Windows.Forms.Label
        Friend WithEvents txtPlusRetention As System.Windows.Forms.TextBox
        Friend WithEvents lblPlusRetention As System.Windows.Forms.Label
        Friend WithEvents ibtnUpDateVat As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents chkOnHold As System.Windows.Forms.CheckBox
        Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblRate As System.Windows.Forms.Label
        Friend WithEvents lblLanguage As System.Windows.Forms.Label
        Friend WithEvents txtRate As System.Windows.Forms.TextBox
        Friend WithEvents lblUnit2 As System.Windows.Forms.Label
        Friend WithEvents txtUnit1 As System.Windows.Forms.TextBox
        Friend WithEvents lblUnit1 As System.Windows.Forms.Label
        Friend WithEvents txtUnit2 As System.Windows.Forms.TextBox
        Friend WithEvents txtLanguage As System.Windows.Forms.TextBox
        Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaySelectionDetail))
            Me.lblSupplier = New System.Windows.Forms.Label()
            Me.txtSupplierCode = New System.Windows.Forms.TextBox()
            Me.lblItem = New System.Windows.Forms.Label()
            Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblRetention = New System.Windows.Forms.Label()
            Me.txtRetention = New System.Windows.Forms.TextBox()
            Me.lblRetentionUnit = New System.Windows.Forms.Label()
            Me.lblPlusRetentionUnit = New System.Windows.Forms.Label()
            Me.txtPlusRetention = New System.Windows.Forms.TextBox()
            Me.lblPlusRetention = New System.Windows.Forms.Label()
            Me.lblRemaining = New System.Windows.Forms.Label()
            Me.txtRemaining = New System.Windows.Forms.TextBox()
            Me.lblRemainingUnit = New System.Windows.Forms.Label()
            Me.txtItemCount = New System.Windows.Forms.TextBox()
            Me.lblItemCount = New System.Windows.Forms.Label()
            Me.lblItemCountUnit = New System.Windows.Forms.Label()
            Me.lblGrossUnit = New System.Windows.Forms.Label()
            Me.txtGross = New System.Windows.Forms.TextBox()
            Me.lblGross = New System.Windows.Forms.Label()
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.ibtnShowSupplier = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtSupplierName = New System.Windows.Forms.TextBox()
            Me.ibtnShowSupplierDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.txtDocDate = New System.Windows.Forms.TextBox()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.chkAutorun = New System.Windows.Forms.CheckBox()
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.lblDocDate = New System.Windows.Forms.Label()
            Me.grbSupplier = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
            Me.ibtnUpDateVat = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.cmbCode = New System.Windows.Forms.ComboBox()
            Me.chkOnHold = New System.Windows.Forms.CheckBox()
            Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblRate = New System.Windows.Forms.Label()
            Me.lblLanguage = New System.Windows.Forms.Label()
            Me.txtRate = New System.Windows.Forms.TextBox()
            Me.lblUnit2 = New System.Windows.Forms.Label()
            Me.txtUnit1 = New System.Windows.Forms.TextBox()
            Me.lblUnit1 = New System.Windows.Forms.Label()
            Me.txtUnit2 = New System.Windows.Forms.TextBox()
            Me.txtLanguage = New System.Windows.Forms.TextBox()
            Me.grbSummary.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbSupplier.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.FixedGroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblSupplier
            '
            Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplier.Location = New System.Drawing.Point(16, 16)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(72, 18)
            Me.lblSupplier.TabIndex = 2
            Me.lblSupplier.Text = "ผู้ขาย:"
            Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSupplierCode
            '
            Me.txtSupplierCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.txtSupplierCode.Location = New System.Drawing.Point(88, 16)
            Me.Validator.SetMinValue(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
            Me.Validator.SetRequired(Me.txtSupplierCode, True)
            Me.txtSupplierCode.Size = New System.Drawing.Size(64, 20)
            Me.txtSupplierCode.TabIndex = 0
            '
            'lblItem
            '
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(3, 141)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(112, 18)
            Me.lblItem.TabIndex = 9
            Me.lblItem.Text = "รายการชำระหนี้:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbSummary
            '
            Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbSummary.Controls.Add(Me.lblRetention)
            Me.grbSummary.Controls.Add(Me.txtRetention)
            Me.grbSummary.Controls.Add(Me.lblRetentionUnit)
            Me.grbSummary.Controls.Add(Me.lblPlusRetentionUnit)
            Me.grbSummary.Controls.Add(Me.txtPlusRetention)
            Me.grbSummary.Controls.Add(Me.lblPlusRetention)
            Me.grbSummary.Controls.Add(Me.lblRemaining)
            Me.grbSummary.Controls.Add(Me.txtRemaining)
            Me.grbSummary.Controls.Add(Me.lblRemainingUnit)
            Me.grbSummary.Controls.Add(Me.txtItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCount)
            Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
            Me.grbSummary.Controls.Add(Me.lblGrossUnit)
            Me.grbSummary.Controls.Add(Me.txtGross)
            Me.grbSummary.Controls.Add(Me.lblGross)
            Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSummary.Location = New System.Drawing.Point(120, 312)
            Me.grbSummary.Name = "grbSummary"
            Me.grbSummary.Size = New System.Drawing.Size(696, 72)
            Me.grbSummary.TabIndex = 13
            Me.grbSummary.TabStop = False
            Me.grbSummary.Text = "สรุปรายการชำระหนี้"
            '
            'lblRetention
            '
            Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRetention.Location = New System.Drawing.Point(456, 40)
            Me.lblRetention.Name = "lblRetention"
            Me.lblRetention.Size = New System.Drawing.Size(104, 18)
            Me.lblRetention.TabIndex = 19
            Me.lblRetention.Text = "Retention"
            Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRetention
            '
            Me.txtRetention.BackColor = System.Drawing.SystemColors.Control
            Me.txtRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRetention, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
            Me.txtRetention.Location = New System.Drawing.Point(560, 40)
            Me.Validator.SetMinValue(Me.txtRetention, "")
            Me.txtRetention.Name = "txtRetention"
            Me.txtRetention.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRetention, "")
            Me.Validator.SetRequired(Me.txtRetention, False)
            Me.txtRetention.Size = New System.Drawing.Size(96, 20)
            Me.txtRetention.TabIndex = 20
            Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblRetentionUnit
            '
            Me.lblRetentionUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRetentionUnit.Location = New System.Drawing.Point(656, 40)
            Me.lblRetentionUnit.Name = "lblRetentionUnit"
            Me.lblRetentionUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblRetentionUnit.TabIndex = 15
            Me.lblRetentionUnit.Text = "บาท"
            Me.lblRetentionUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPlusRetentionUnit
            '
            Me.lblPlusRetentionUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPlusRetentionUnit.Location = New System.Drawing.Point(432, 40)
            Me.lblPlusRetentionUnit.Name = "lblPlusRetentionUnit"
            Me.lblPlusRetentionUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblPlusRetentionUnit.TabIndex = 18
            Me.lblPlusRetentionUnit.Text = "บาท"
            Me.lblPlusRetentionUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPlusRetention
            '
            Me.txtPlusRetention.BackColor = System.Drawing.SystemColors.Control
            Me.txtPlusRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtPlusRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPlusRetention, "")
            Me.Validator.SetGotFocusBackColor(Me.txtPlusRetention, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPlusRetention, System.Drawing.Color.Empty)
            Me.txtPlusRetention.Location = New System.Drawing.Point(320, 40)
            Me.Validator.SetMinValue(Me.txtPlusRetention, "")
            Me.txtPlusRetention.Name = "txtPlusRetention"
            Me.txtPlusRetention.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtPlusRetention, "")
            Me.Validator.SetRequired(Me.txtPlusRetention, False)
            Me.txtPlusRetention.Size = New System.Drawing.Size(112, 20)
            Me.txtPlusRetention.TabIndex = 17
            Me.txtPlusRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblPlusRetention
            '
            Me.lblPlusRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPlusRetention.Location = New System.Drawing.Point(192, 40)
            Me.lblPlusRetention.Name = "lblPlusRetention"
            Me.lblPlusRetention.Size = New System.Drawing.Size(128, 18)
            Me.lblPlusRetention.TabIndex = 16
            Me.lblPlusRetention.Text = "Total with Retention"
            Me.lblPlusRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRemaining
            '
            Me.lblRemaining.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRemaining.Location = New System.Drawing.Point(456, 16)
            Me.lblRemaining.Name = "lblRemaining"
            Me.lblRemaining.Size = New System.Drawing.Size(104, 18)
            Me.lblRemaining.TabIndex = 6
            Me.lblRemaining.Text = "Remaining Payment"
            Me.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRemaining
            '
            Me.txtRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtRemaining, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRemaining, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRemaining, System.Drawing.Color.Empty)
            Me.txtRemaining.Location = New System.Drawing.Point(560, 16)
            Me.Validator.SetMinValue(Me.txtRemaining, "")
            Me.txtRemaining.Name = "txtRemaining"
            Me.txtRemaining.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRemaining, "")
            Me.Validator.SetRequired(Me.txtRemaining, False)
            Me.txtRemaining.Size = New System.Drawing.Size(96, 20)
            Me.txtRemaining.TabIndex = 7
            Me.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblRemainingUnit
            '
            Me.lblRemainingUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRemainingUnit.Location = New System.Drawing.Point(656, 16)
            Me.lblRemainingUnit.Name = "lblRemainingUnit"
            Me.lblRemainingUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblRemainingUnit.TabIndex = 8
            Me.lblRemainingUnit.Text = "บาท"
            Me.lblRemainingUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtItemCount
            '
            Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtItemCount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
            Me.txtItemCount.Location = New System.Drawing.Point(104, 16)
            Me.Validator.SetMinValue(Me.txtItemCount, "")
            Me.txtItemCount.Name = "txtItemCount"
            Me.txtItemCount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtItemCount, "")
            Me.Validator.SetRequired(Me.txtItemCount, False)
            Me.txtItemCount.Size = New System.Drawing.Size(64, 20)
            Me.txtItemCount.TabIndex = 1
            Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblItemCount
            '
            Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCount.Location = New System.Drawing.Point(16, 16)
            Me.lblItemCount.Name = "lblItemCount"
            Me.lblItemCount.Size = New System.Drawing.Size(80, 18)
            Me.lblItemCount.TabIndex = 0
            Me.lblItemCount.Text = "จำนวนรายการ"
            Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItemCountUnit
            '
            Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemCountUnit.Location = New System.Drawing.Point(168, 16)
            Me.lblItemCountUnit.Name = "lblItemCountUnit"
            Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
            Me.lblItemCountUnit.TabIndex = 2
            Me.lblItemCountUnit.Text = "รายการ"
            Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGrossUnit
            '
            Me.lblGrossUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGrossUnit.Location = New System.Drawing.Point(432, 16)
            Me.lblGrossUnit.Name = "lblGrossUnit"
            Me.lblGrossUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblGrossUnit.TabIndex = 5
            Me.lblGrossUnit.Text = "บาท"
            Me.lblGrossUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtGross
            '
            Me.txtGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGross, "")
            Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.txtGross.Location = New System.Drawing.Point(320, 16)
            Me.Validator.SetMinValue(Me.txtGross, "")
            Me.txtGross.Name = "txtGross"
            Me.txtGross.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGross, "")
            Me.Validator.SetRequired(Me.txtGross, False)
            Me.txtGross.Size = New System.Drawing.Size(112, 20)
            Me.txtGross.TabIndex = 4
            Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblGross
            '
            Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGross.Location = New System.Drawing.Point(208, 16)
            Me.lblGross.Name = "lblGross"
            Me.lblGross.Size = New System.Drawing.Size(112, 18)
            Me.lblGross.TabIndex = 3
            Me.lblGross.Text = "Total Amount"
            Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(504, 67)
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(304, 73)
            Me.txtNote.TabIndex = 3
            '
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(408, 67)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(96, 18)
            Me.lblNote.TabIndex = 12
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnShowSupplier
            '
            Me.ibtnShowSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowSupplier.Location = New System.Drawing.Point(344, 16)
            Me.ibtnShowSupplier.Name = "ibtnShowSupplier"
            Me.ibtnShowSupplier.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowSupplier.TabIndex = 8
            Me.ibtnShowSupplier.TabStop = False
            Me.ibtnShowSupplier.ThemedImage = CType(resources.GetObject("ibtnShowSupplier.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSupplierName
            '
            Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.txtSupplierName.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMinValue(Me.txtSupplierName, "")
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.txtSupplierName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
            Me.Validator.SetRequired(Me.txtSupplierName, False)
            Me.txtSupplierName.Size = New System.Drawing.Size(168, 20)
            Me.txtSupplierName.TabIndex = 4
            Me.txtSupplierName.TabStop = False
            '
            'ibtnShowSupplierDialog
            '
            Me.ibtnShowSupplierDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowSupplierDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowSupplierDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowSupplierDialog.Location = New System.Drawing.Point(320, 16)
            Me.ibtnShowSupplierDialog.Name = "ibtnShowSupplierDialog"
            Me.ibtnShowSupplierDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowSupplierDialog.TabIndex = 7
            Me.ibtnShowSupplierDialog.TabStop = False
            Me.ibtnShowSupplierDialog.ThemedImage = CType(resources.GetObject("ibtnShowSupplierDialog.ThemedImage"), System.Drawing.Bitmap)
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
            Me.txtDocDate.Location = New System.Drawing.Point(264, 15)
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(78, 20)
            Me.txtDocDate.TabIndex = 1
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
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(200, 15)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 6
            '
            'dtpDocDate
            '
            Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDocDate.Location = New System.Drawing.Point(264, 15)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpDocDate.TabIndex = 8
            Me.dtpDocDate.TabStop = False
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(0, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 5
            Me.lblCode.Text = "เลขที่:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.ForeColor = System.Drawing.Color.Black
            Me.lblDocDate.Location = New System.Drawing.Point(224, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
            Me.lblDocDate.TabIndex = 7
            Me.lblDocDate.Text = "วันที่:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbSupplier
            '
            Me.grbSupplier.Controls.Add(Me.ibtnShowSupplier)
            Me.grbSupplier.Controls.Add(Me.txtSupplierName)
            Me.grbSupplier.Controls.Add(Me.txtSupplierCode)
            Me.grbSupplier.Controls.Add(Me.ibtnShowSupplierDialog)
            Me.grbSupplier.Controls.Add(Me.lblSupplier)
            Me.grbSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSupplier.Location = New System.Drawing.Point(376, 0)
            Me.grbSupplier.Name = "grbSupplier"
            Me.grbSupplier.Size = New System.Drawing.Size(384, 48)
            Me.grbSupplier.TabIndex = 2
            Me.grbSupplier.TabStop = False
            Me.grbSupplier.Text = "ผู้ขาย"
            '
            'ibtnBlank
            '
            Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnBlank.Location = New System.Drawing.Point(115, 133)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 10
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnDelRow.Location = New System.Drawing.Point(139, 133)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 11
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
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
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 159)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(808, 145)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 15
            Me.tgItem.TreeManager = Nothing
            '
            'ibtnUpDateVat
            '
            Me.ibtnUpDateVat.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnUpDateVat.Location = New System.Drawing.Point(195, 133)
            Me.ibtnUpDateVat.Name = "ibtnUpDateVat"
            Me.ibtnUpDateVat.Size = New System.Drawing.Size(20, 24)
            Me.ibtnUpDateVat.TabIndex = 11
            Me.ibtnUpDateVat.TabStop = False
            Me.ibtnUpDateVat.ThemedImage = CType(resources.GetObject("ibtnUpDateVat.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnUpDateVat, "Update Vat")
            '
            'cmbCode
            '
            Me.cmbCode.Location = New System.Drawing.Point(80, 15)
            Me.cmbCode.Name = "cmbCode"
            Me.cmbCode.Size = New System.Drawing.Size(120, 21)
            Me.cmbCode.TabIndex = 0
            '
            'chkOnHold
            '
            Me.chkOnHold.AutoSize = True
            Me.chkOnHold.Location = New System.Drawing.Point(80, 40)
            Me.chkOnHold.Name = "chkOnHold"
            Me.chkOnHold.Size = New System.Drawing.Size(65, 17)
            Me.chkOnHold.TabIndex = 16
            Me.chkOnHold.TabStop = False
            Me.chkOnHold.Text = "On Hold"
            Me.chkOnHold.UseVisualStyleBackColor = True
            '
            'FixedGroupBox1
            '
            Me.FixedGroupBox1.Controls.Add(Me.lblRate)
            Me.FixedGroupBox1.Controls.Add(Me.lblLanguage)
            Me.FixedGroupBox1.Controls.Add(Me.txtRate)
            Me.FixedGroupBox1.Controls.Add(Me.lblUnit2)
            Me.FixedGroupBox1.Controls.Add(Me.txtUnit1)
            Me.FixedGroupBox1.Controls.Add(Me.lblUnit1)
            Me.FixedGroupBox1.Controls.Add(Me.txtUnit2)
            Me.FixedGroupBox1.Controls.Add(Me.txtLanguage)
            Me.FixedGroupBox1.Location = New System.Drawing.Point(80, 63)
            Me.FixedGroupBox1.Name = "FixedGroupBox1"
            Me.FixedGroupBox1.Size = New System.Drawing.Size(280, 64)
            Me.FixedGroupBox1.TabIndex = 344
            Me.FixedGroupBox1.TabStop = False
            Me.FixedGroupBox1.Text = "Currency"
            '
            'lblRate
            '
            Me.lblRate.BackColor = System.Drawing.Color.Transparent
            Me.lblRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRate.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRate.Location = New System.Drawing.Point(6, 14)
            Me.lblRate.Name = "lblRate"
            Me.lblRate.Size = New System.Drawing.Size(62, 18)
            Me.lblRate.TabIndex = 342
            Me.lblRate.Text = "Rate"
            Me.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblLanguage
            '
            Me.lblLanguage.BackColor = System.Drawing.Color.Transparent
            Me.lblLanguage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLanguage.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblLanguage.Location = New System.Drawing.Point(210, 15)
            Me.lblLanguage.Name = "lblLanguage"
            Me.lblLanguage.Size = New System.Drawing.Size(62, 18)
            Me.lblLanguage.TabIndex = 342
            Me.lblLanguage.Text = "Language"
            Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtRate
            '
            Me.Validator.SetDataType(Me.txtRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRate, System.Drawing.Color.Empty)
            Me.txtRate.Location = New System.Drawing.Point(6, 34)
            Me.Validator.SetMinValue(Me.txtRate, "")
            Me.txtRate.Name = "txtRate"
            Me.Validator.SetRegularExpression(Me.txtRate, "")
            Me.Validator.SetRequired(Me.txtRate, False)
            Me.txtRate.Size = New System.Drawing.Size(62, 20)
            Me.txtRate.TabIndex = 341
            '
            'lblUnit2
            '
            Me.lblUnit2.BackColor = System.Drawing.Color.Transparent
            Me.lblUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit2.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblUnit2.Location = New System.Drawing.Point(142, 15)
            Me.lblUnit2.Name = "lblUnit2"
            Me.lblUnit2.Size = New System.Drawing.Size(62, 18)
            Me.lblUnit2.TabIndex = 342
            Me.lblUnit2.Text = "Unit2"
            Me.lblUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtUnit1
            '
            Me.Validator.SetDataType(Me.txtUnit1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnit1, "")
            Me.Validator.SetGotFocusBackColor(Me.txtUnit1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtUnit1, System.Drawing.Color.Empty)
            Me.txtUnit1.Location = New System.Drawing.Point(74, 35)
            Me.Validator.SetMinValue(Me.txtUnit1, "")
            Me.txtUnit1.Name = "txtUnit1"
            Me.Validator.SetRegularExpression(Me.txtUnit1, "")
            Me.Validator.SetRequired(Me.txtUnit1, False)
            Me.txtUnit1.Size = New System.Drawing.Size(62, 20)
            Me.txtUnit1.TabIndex = 341
            '
            'lblUnit1
            '
            Me.lblUnit1.BackColor = System.Drawing.Color.Transparent
            Me.lblUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit1.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblUnit1.Location = New System.Drawing.Point(74, 15)
            Me.lblUnit1.Name = "lblUnit1"
            Me.lblUnit1.Size = New System.Drawing.Size(62, 18)
            Me.lblUnit1.TabIndex = 342
            Me.lblUnit1.Text = "Unit1"
            Me.lblUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtUnit2
            '
            Me.Validator.SetDataType(Me.txtUnit2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnit2, "")
            Me.Validator.SetGotFocusBackColor(Me.txtUnit2, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtUnit2, System.Drawing.Color.Empty)
            Me.txtUnit2.Location = New System.Drawing.Point(142, 35)
            Me.Validator.SetMinValue(Me.txtUnit2, "")
            Me.txtUnit2.Name = "txtUnit2"
            Me.Validator.SetRegularExpression(Me.txtUnit2, "")
            Me.Validator.SetRequired(Me.txtUnit2, False)
            Me.txtUnit2.Size = New System.Drawing.Size(62, 20)
            Me.txtUnit2.TabIndex = 341
            '
            'txtLanguage
            '
            Me.Validator.SetDataType(Me.txtLanguage, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLanguage, "")
            Me.Validator.SetGotFocusBackColor(Me.txtLanguage, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLanguage, System.Drawing.Color.Empty)
            Me.txtLanguage.Location = New System.Drawing.Point(210, 35)
            Me.Validator.SetMinValue(Me.txtLanguage, "")
            Me.txtLanguage.Name = "txtLanguage"
            Me.Validator.SetRegularExpression(Me.txtLanguage, "")
            Me.Validator.SetRequired(Me.txtLanguage, False)
            Me.txtLanguage.Size = New System.Drawing.Size(62, 20)
            Me.txtLanguage.TabIndex = 341
            '
            'PaySelectionDetail
            '
            Me.Controls.Add(Me.FixedGroupBox1)
            Me.Controls.Add(Me.chkOnHold)
            Me.Controls.Add(Me.cmbCode)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.grbSummary)
            Me.Controls.Add(Me.grbSupplier)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.txtDocDate)
            Me.Controls.Add(Me.lblNote)
            Me.Controls.Add(Me.chkAutorun)
            Me.Controls.Add(Me.dtpDocDate)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.txtNote)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.lblDocDate)
            Me.Controls.Add(Me.ibtnUpDateVat)
            Me.Name = "PaySelectionDetail"
            Me.Size = New System.Drawing.Size(832, 400)
            Me.grbSummary.ResumeLayout(False)
            Me.grbSummary.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbSupplier.ResumeLayout(False)
            Me.grbSupplier.PerformLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.FixedGroupBox1.ResumeLayout(False)
            Me.FixedGroupBox1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

#Region "Members"
        Private m_entity As PaySelection
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager

        Private m_tableStyleEnable As Hashtable

        Private m_enableState As Hashtable
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            SaveEnableState()
            Dim dt As TreeTable = PaySelection.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete

            EventWiring()
        End Sub
        Private Sub SaveEnableState()
            m_enableState = New Hashtable
            For Each ctrl As Control In Me.grbSupplier.Controls
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
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "PaySelection"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "paysi_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "paysi_linenumber"

            Dim csType As DataGridComboColumn
            csType = New DataGridComboColumn("paysi_entityType", CodeDescription.GetCodeList("PayableItemType", "code_value not in (47)"), "code_description", "code_value")
            csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.TypeHeaderText}")
            csType.Width = 70
            csType.NullText = String.Empty
            csType.ReadOnly = True

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.TextBox.Name = "Code"
            csCode.ReadOnly = True

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf ItemButtonClick

            Dim csDocDate As New DataGridTimePickerColumn
            csDocDate.MappingName = "DocDate"
            csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.DocDateHeaderText}")
            'csDocDate.Width = 90
            csDocDate.NullText = ""
            csDocDate.ReadOnly = True

            Dim csDueDate As New DataGridTimePickerColumn
            csDueDate.MappingName = "DueDate"
            csDueDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.DueDateHeaderText}")
            'csDueDate.Width = 90
            csDueDate.NullText = ""
            csDueDate.ReadOnly = True

            Dim csRetention As New TreeTextColumn
            csRetention.MappingName = "Retention"
            csRetention.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.RetentionHeaderText}")
            csRetention.NullText = ""
            csRetention.DataAlignment = HorizontalAlignment.Right
            csRetention.Format = "#,###.##"
            csRetention.TextBox.Name = "Retention"

            Dim csPlusRetention As New TreeTextColumn
            csPlusRetention.MappingName = "PlusRetention"
            csPlusRetention.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.PlusRetentionHeaderText}")
            csPlusRetention.NullText = ""
            csPlusRetention.DataAlignment = HorizontalAlignment.Right
            csPlusRetention.Format = "#,###.##"
            csPlusRetention.ReadOnly = True
            csPlusRetention.TextBox.Name = "PlusRetention"

            Dim csRealAmount As New TreeTextColumn
            csRealAmount.MappingName = "RealAmount"
            csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.RealAmountHeaderText}")
            csRealAmount.NullText = ""
            csRealAmount.DataAlignment = HorizontalAlignment.Right
            csRealAmount.Format = "#,###.##"
            csRealAmount.ReadOnly = True
            csRealAmount.TextBox.Name = "RealAmount"

            Dim csUnpaidAmount As New TreeTextColumn
            csUnpaidAmount.MappingName = "UnpaidAmount"
            csUnpaidAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.UnpaidAmountHeaderText}")
            csUnpaidAmount.NullText = ""
            csUnpaidAmount.DataAlignment = HorizontalAlignment.Right
            csUnpaidAmount.Format = "#,###.##"
            csUnpaidAmount.ReadOnly = True
            csUnpaidAmount.TextBox.Name = "UnpaidAmount"

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "paysi_amt"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.AmountHeaderText}")
            csAmount.NullText = ""
            csAmount.DataAlignment = HorizontalAlignment.Right
            csAmount.Format = "#,###.##"
            csAmount.TextBox.Name = "paysi_amt"

            Dim csRemain As New TreeTextColumn
            csRemain.MappingName = "RemainningBalance"
            csRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.RemainningBalanceHeaderText}")
            csRemain.NullText = ""
            csRemain.DataAlignment = HorizontalAlignment.Right
            csRemain.Format = "#,###.##"
            csRemain.ReadOnly = True
            csRemain.TextBox.Name = "RemainningBalance"

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "paysi_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "paysi_note"

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csType)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csDocDate)
            dst.GridColumnStyles.Add(csDueDate)
            dst.GridColumnStyles.Add(csRetention)
            dst.GridColumnStyles.Add(csPlusRetention)
            dst.GridColumnStyles.Add(csRealAmount)
            dst.GridColumnStyles.Add(csUnpaidAmount)
            dst.GridColumnStyles.Add(csAmount)
            'dst.GridColumnStyles.Add(csRemain)''ยังผิดกรณีวางบิลหลายเอกสาร !!เอาไว้ก่อนละกัน pui
            dst.GridColumnStyles.Add(csNote)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
#End Region

#Region "Properties"
        Private ReadOnly Property CurrentItem() As BillAcceptanceItem
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is BillAcceptanceItem Then
                    Return Nothing
                End If
                Return CType(row.Tag, BillAcceptanceItem)
            End Get
        End Property
        Private ReadOnly Property CurrentParItem() As BillAcceptance
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is BillAcceptance Then
                    Return Nothing
                End If
                Return CType(row.Tag, BillAcceptance)
            End Get
        End Property
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized Then
                Return
            End If
            If ValidateRow(CType(e.Row, TreeRow)) Then
                UpdateAmount()
                Me.m_treeManager.Treetable.AcceptChanges()
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            RefreshDocs()
            tgItem.CurrentRowIndex = index
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized Then
                Return
            End If
            If Me.m_treeManager.SelectedRow Is Nothing Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Supplier Is Nothing OrElse Not Me.m_entity.Supplier.Originated Then
                msgServ.ShowMessage("${res:Global.Error.SpecifySupplier}")
                e.ProposedValue = e.Row(e.Column)
                Return
            End If
            If Me.CurrentItem Is Nothing Then
                Dim doc As New BillAcceptanceItem
                Me.m_entity.ItemCollection.Add(doc)
                Me.m_treeManager.SelectedRow.Tag = doc
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetCode(e)
                    Case "paysi_entitytype"
                        SetEntityType(e)
                    Case "duedate"
                        SetDueDate(e)
                    Case "docdate"
                        SetDate(e)
                    Case "realamount"
                        SetRealAmount(e)
                    Case "paysi_amt"
                        'If IsNumeric(e) Then
                        SetAmount(e)
                        'End If
                    Case "retention"
                        SetRetention(e)
                    Case "paysi_note"
                        SetNote(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim code As Object = e.Row("code")
            Dim paysi_entitytype As Object = e.Row("paysi_entitytype")
            Dim paysi_amt As Object = e.Row("paysi_amt")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    code = e.ProposedValue
                Case "paysi_entitytype"
                    paysi_entitytype = e.ProposedValue
                Case "paysi_amt"
                    paysi_amt = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If IsDBNull(paysi_entitytype) Then
                isBlankRow = True
            End If
            If Not isBlankRow Then
                Select Case CInt(paysi_entitytype)
                    Case 45 'รับของ
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.GoodsReceiptCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case 46 'ลดหนี้
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.PurchaseCNCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case 47 'เพิ่มหนี้
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.BillAcceptanceCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case 15 'เจ้าหนี้ยกมา
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.APOpeningBalanceCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case 50 'ซ่อมบำรุง
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.EqMaintenanceCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                    Case Else
                        Return
                End Select
                If IsDBNull(paysi_amt) OrElse Not IsNumeric(paysi_amt) OrElse CDec(paysi_amt) <= 0 Then
                    e.Row.SetColumnError("paysi_amt", Me.StringParserService.Parse("${res:Global.Error.BillAcceptanceAmountMissing}"))
                Else
                    e.Row.SetColumnError("paysi_amt", "")
                End If
            End If
        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            If row.Tag Is Nothing Then
                Return False
            End If
            Return True
        End Function
        Private m_updating As Boolean = False
        Public Sub SetNote(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As BillAcceptanceItem = Me.CurrentItem
            m_updating = True
            doc.Note = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As BillAcceptanceItem = Me.CurrentItem
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = 0
            End If
            If Not IsNumeric(e.ProposedValue) Then
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)
            'Dim remain As Decimal = doc.GetRemainingAmountPayselection(Me.m_entity.Id)
            'remain = Math.Min(doc.BilledAmount, remain)
            'Dim remain2 As Decimal = Me.m_entity.ItemCollection.GetRemainFromOtherDocs(doc)
            'remain = Math.Min(remain, remain2)
            Dim remain As Decimal = doc.UnpaidAmount
            m_updating = True
            'If doc.UnpaidAmount <> remain Then
            'doc.UnpaidAmount = remain
            'e.Row("UnpaidAmount") = Configuration.FormatToString(doc.UnpaidAmount, DigitConfig.Price)
            'End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("paysi_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoPaySelectionEntityType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If

            If Configuration.Compare(remain, value, DigitConfig.Price) < 0 Then
                msgServ.ShowMessageFormatted("${res:Global.Error.PaysRemainingAmountLessThanAmount}", _
                New String() { _
                Configuration.FormatToString(remain, DigitConfig.Price) _
                , Configuration.FormatToString(value, DigitConfig.Price) _
                })

                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            doc.Amount = value
            m_updating = False
        End Sub
        Public Sub SetRetention(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As BillAcceptanceItem = Me.CurrentItem
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = 0
            End If
            If Not IsNumeric(e.ProposedValue) Then
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)
            'Dim remain As Decimal = doc.UnpaidAmount
            m_updating = True
            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'If e.Row.IsNull("paysi_entityType") Then
            'msgServ.ShowMessage("${res:Global.Error.NoPaySelectionEntityType}")
            'e.ProposedValue = e.Row(e.Column)
            'm_updating = False
            'Return
            'End If
            'If Configuration.Compare(remain, value, DigitConfig.Price) < 0 Then
            'msgServ.ShowMessageFormatted("${res:Global.Error.PaysRemainingAmountLessThanAmount}", _
            'New String() { _
            'Configuration.FormatToString(remain, DigitConfig.Price) _
            ', Configuration.FormatToString(value, DigitConfig.Price) _
            '})

            'e.ProposedValue = e.Row(e.Column)
            'm_updating = False
            'Return
            'End If
            doc.Retention = value
            m_updating = False
        End Sub
        Public Sub SetRealAmount(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Global.Error.CannotChangeRealAmount}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
        End Sub
        Public Sub SetDate(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Global.Error.CannotChangeDate}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
        End Sub
        Public Sub SetDueDate(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Global.Error.CannotChangeDueDate}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
        End Sub
        Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As BillAcceptanceItem = Me.CurrentItem
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull(e.Column) Then
                m_updating = False
                Return
            End If

            If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
                'ผ่านโลด
                m_updating = False
                Return
            End If
            If msgServ.AskQuestion("${res:Global.Question.ChangePaySelectionEntityType}") Then
                e.Row("paysi_entity") = DBNull.Value
                e.Row("code") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("paysi_amt") = DBNull.Value
                e.Row("UnpaidAmount") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
                e.Row("DocDate") = Date.MinValue
                doc.Clear()
            Else
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            m_updating = False
        End Sub
        Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
            If e.Row.IsNull("paysi_entityType") Then
                Return False
            End If
            If IsDBNull(e.ProposedValue) Then
                Return False
            End If
            Dim doc As BillAcceptanceItem = Me.CurrentItem
            If doc Is Nothing Then
                Return False
            End If
            For Each item As BillAcceptanceItem In Me.m_entity.ItemCollection
                If Not doc Is item Then
                    If item.EntityId = CInt(e.Row("paysi_entityType")) Then
                        If e.ProposedValue.ToString.ToLower = item.Code.ToLower Then
                            Return True
                        End If
                    End If
                End If
            Next
            Return False
        End Function
        Public Sub SetCode(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As BillAcceptanceItem = Me.CurrentItem
            If doc Is Nothing Then
                e.ProposedValue = e.Row(e.Column)
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("paysi_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoPaySelectionEntityType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            If DupCode(e) Then
                msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {BusinessLogic.Entity.GetFullClassName(doc.EntityId), e.ProposedValue.ToString})
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("paysi_entityType"))
                Case 45 'รับของ
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteGoodsReceiptDetail}", New String() {e.Row(e.Column).ToString}) Then
                                e.Row("paysi_entity") = DBNull.Value
                                e.Row("RealAmount") = DBNull.Value
                                e.Row("UnpaidAmount") = DBNull.Value
                                e.Row("paysi_amt") = DBNull.Value
                                e.Row("DueDate") = Date.MinValue
                                e.Row("DocDate") = Date.MinValue
                                doc.Clear()
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim gr As New GoodsReceipt(e.ProposedValue.ToString)
                    If Not gr.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoGoodsReceipt}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        If gr.Status.Value = 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.GoodsReceiptIsCanceled}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        Dim remain As Decimal = gr.GetRemainingAmountPayselection(Me.m_entity.Id)
                        If remain <= 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessGoodsReceiptAmount}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        e.Row("paysi_entity") = gr.Id
                        e.ProposedValue = gr.Code
                        e.Row("RealAmount") = Configuration.FormatToString(gr.Payment.Amount, DigitConfig.Price)
                        e.Row("paysi_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("DueDate") = gr.DueDate
                        e.Row("DocDate") = gr.DocDate
                        doc.Id = gr.Id
                        doc.RealAmount = gr.Payment.Amount
                        doc.UnpaidAmount = remain
                        doc.Amount = remain
                        doc.Code = gr.Code
                        doc.Date = gr.DocDate
                        doc.CreditPeriod = gr.CreditPeriod
                        doc.SetType(45)
                    End If
                Case 50 'ซ่อมบำรุง
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteEqMaintenanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                                e.Row("paysi_entity") = DBNull.Value
                                e.Row("RealAmount") = DBNull.Value
                                e.Row("UnpaidAmount") = DBNull.Value
                                e.Row("paysi_amt") = DBNull.Value
                                e.Row("DueDate") = Date.MinValue
                                e.Row("DocDate") = Date.MinValue
                                doc.Clear()
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim eqm As New EqMaintenance(e.ProposedValue.ToString)
                    If Not eqm.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoEqMaintenance}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        If eqm.Status.Value = 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.EqMaintenanceIsCanceled}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        Dim remain As Decimal = eqm.GetRemainingAmountPayselection(Me.m_entity.Id)
                        If remain <= 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessEqMaintenanceAmount}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        e.Row("paysi_entity") = eqm.Id
                        e.ProposedValue = eqm.Code
                        e.Row("RealAmount") = Configuration.FormatToString(eqm.Payment.Amount, DigitConfig.Price)
                        e.Row("paysi_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("DueDate") = eqm.DueDate
                        e.Row("DocDate") = eqm.DocDate
                        doc.Id = eqm.Id
                        doc.RealAmount = eqm.Payment.Amount
                        doc.UnpaidAmount = remain
                        doc.Amount = remain
                        doc.Code = eqm.Code
                        doc.Date = eqm.DocDate
                        doc.CreditPeriod = eqm.CreditPeriod
                        doc.SetType(50)
                    End If
                Case 46 'ลดหนี้
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeletePurchaseCNDetail}", New String() {e.Row(e.Column).ToString}) Then
                                e.Row("paysi_entity") = DBNull.Value
                                e.Row("RealAmount") = DBNull.Value
                                e.Row("UnpaidAmount") = DBNull.Value
                                e.Row("paysi_amt") = DBNull.Value
                                e.Row("DueDate") = Date.MinValue
                                e.Row("DocDate") = Date.MinValue
                                doc.Clear()
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim pcn As New PurchaseCN(e.ProposedValue.ToString)
                    If Not pcn.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoPurchaseCN}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        If pcn.Status.Value = 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.PurchaseCNIsCanceled}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        Dim remain As Decimal = pcn.GetRemainingAmountPayselection(Me.m_entity.Id)
                        If remain <= 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessPurchaseCNAmount}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        e.Row("paysi_entity") = pcn.Id
                        e.ProposedValue = pcn.Code
                        e.Row("RealAmount") = Configuration.FormatToString(pcn.Payment.Amount, DigitConfig.Price)
                        e.Row("paysi_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("DueDate") = pcn.DueDate
                        e.Row("DocDate") = pcn.DocDate
                        doc.Id = pcn.Id
                        doc.RealAmount = pcn.Payment.Amount
                        doc.UnpaidAmount = remain
                        doc.Amount = remain
                        doc.Code = pcn.Code
                        doc.Date = pcn.DocDate
                        doc.CreditPeriod = pcn.CreditPeriod
                        doc.SetType(46)
                    End If
                Case 47 'เพิ่มหนี้
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteBillAcceptanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                                e.Row("paysi_entity") = DBNull.Value
                                e.Row("RealAmount") = DBNull.Value
                                e.Row("UnpaidAmount") = DBNull.Value
                                e.Row("paysi_amt") = DBNull.Value
                                e.Row("DueDate") = Date.MinValue
                                e.Row("DocDate") = Date.MinValue
                                doc.Clear()
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim pdn As New PurchaseDN(e.ProposedValue.ToString)
                    If Not pdn.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoPurchaseDN}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        If pdn.Status.Value = 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.PurchaseDNIsCanceled}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        Dim remain As Decimal = pdn.GetRemainingAmountPayselection(Me.m_entity.Id)
                        If remain <= 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessPurchaseDNAmount}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        e.Row("paysi_entity") = pdn.Id
                        e.ProposedValue = pdn.Code
                        e.Row("RealAmount") = Configuration.FormatToString(pdn.Payment.Amount, DigitConfig.Price)
                        e.Row("paysi_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("DueDate") = pdn.DueDate
                        e.Row("DocDate") = pdn.DocDate
                        doc.Id = pdn.Id
                        doc.RealAmount = pdn.Payment.Amount
                        doc.UnpaidAmount = remain
                        doc.Amount = remain
                        doc.Code = pdn.Code
                        doc.Date = pdn.DocDate
                        doc.CreditPeriod = pdn.CreditPeriod
                        doc.SetType(46)
                    End If
                Case 15 'เจ้าหนี้ยกมา
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAPOpeningBalanceDetail}", New String() {e.Row(e.Column).ToString}) Then
                                e.Row("paysi_entity") = DBNull.Value
                                e.Row("RealAmount") = DBNull.Value
                                e.Row("paysi_amt") = DBNull.Value
                                e.Row("UnpaidAmount") = DBNull.Value
                                e.Row("DueDate") = Date.MinValue
                                e.Row("DocDate") = Date.MinValue
                                doc.Clear()
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim apo As New APOpeningBalance(e.ProposedValue.ToString)
                    If Not apo.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoAPOpeningBalance}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        If apo.Status.Value = 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.APOpeningBalanceIsCanceled}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        Dim remain As Decimal = apo.GetRemainingAmountPayselection(Me.m_entity.Id)
                        If remain <= 0 Then
                            msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessAPOpeningBalanceAmount}", New String() {e.ProposedValue.ToString})
                            e.ProposedValue = e.Row(e.Column)
                            m_updating = False
                            Return
                        End If
                        e.Row("paysi_entity") = apo.Id
                        e.ProposedValue = apo.Code
                        e.Row("RealAmount") = Configuration.FormatToString(apo.Payment.Amount, DigitConfig.Price)
                        e.Row("paysi_amt") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("UnpaidAmount") = Configuration.FormatToString(remain, DigitConfig.Price)
                        e.Row("DueDate") = apo.DueDate
                        e.Row("DocDate") = apo.DocDate
                        doc.Id = apo.Id
                        doc.RealAmount = apo.Payment.Amount
                        doc.UnpaidAmount = remain
                        doc.Amount = remain
                        doc.Code = apo.Code
                        doc.Date = apo.DocDate
                        doc.CreditPeriod = apo.CreditPeriod
                        doc.SetType(46)
                    End If
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoPaySelectionEntityType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            m_updating = False
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Status.Value = 0 Or Me.m_entity.Status.Value >= 3 Then
                Me.Enabled = False
            Else
                Me.Enabled = True
            End If

            '==Checking for addin
            Dim hasExport As Boolean = False
            For Each a As AddIn In AddInTreeSingleton.AddInTree.AddIns
                If a.FileName.ToLower.Contains("textexport") Then
                    hasExport = True
                End If
            Next
            Me.chkOnHold.Visible = hasExport
        End Sub
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In Me.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            For Each crlt As Control In grbSupplier.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            For Each crlt As Control In grbSummary.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            Me.dtpDocDate.Value = Now
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblDocDate}")
            Me.Validator.SetDisplayName(Me.txtDocDate, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.txtDocDateAlert}"))

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblCode}")

            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblItem}")
            Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.grbSummary}")
            Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblItemCount}")
            Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblItemCountUnit}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.grbSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.grbSupplier}")

            Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblSupplier}")
            Me.Validator.SetDisplayName(Me.txtSupplierCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.txtSupplierCodeAlert}"))

            Me.lblRemaining.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblRemaining}")
            Me.lblRemainingUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblRemainingUnit}")
            Me.lblGrossUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblGrossUnit}")
            Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblGross}")

            Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblRetention}")
            Me.lblPlusRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblPlusRetention}")
            Me.lblRetentionUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblRemainingUnit}")
            Me.lblPlusRetentionUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.lblRemainingUnit}")
        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler

            AddHandler chkOnHold.CheckedChanged, AddressOf Me.ChangeProperty

            RemoveHandler tgItem.DoubleClick, AddressOf CellDblClick
            AddHandler tgItem.DoubleClick, AddressOf CellDblClick

            '==============CURRENCY=================================
            AddHandler txtRate.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtRate.Validated, AddressOf Me.TextHandler
            AddHandler txtUnit1.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtUnit2.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtLanguage.TextChanged, AddressOf Me.ChangeProperty
            '==============CURRENCY=================================
        End Sub
        Private supplierCodeChanged As Boolean = False
        Private txtCreditPeriodChanged As Boolean = False
        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                '==============CURRENCY=================================
                Case "txtrate"
                    Dim txt As String = Me.txtRate.Text
                    txt = txt.Replace(",", "")
                    If txt.Length = 0 Then
                        Me.m_entity.Currency.Conversion = 0
                    Else
                        Try
                            Me.m_entity.Currency.Conversion = CDec(TextParser.Evaluate(txt))
                        Catch ex As Exception
                            Me.m_entity.Currency.Conversion = 0
                        End Try
                    End If
                    Me.txtRate.Text = Configuration.FormatToString(Me.m_entity.Currency.Conversion, DigitConfig.Price)
                    '==============CURRENCY=================================
                Case "txtsuppliercode"
                    supplierCodeChanged = True
                Case "txtcreditperiod"
                    txtCreditPeriodChanged = True
            End Select
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            oldSupId = Me.m_entity.Supplier.Id

            'cmbCode.Items.Clear()
            'cmbCode.DropDownStyle = ComboBoxStyle.Simple
            'cmbCode.Text = m_entity.Code

            txtNote.Text = m_entity.Note
            Me.m_oldCode = Me.m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtSupplierCode.Text = m_entity.Supplier.Code
            txtSupplierName.Text = m_entity.Supplier.Name

            txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

            chkOnHold.Checked = m_entity.Payment.OnHold
            RefreshDocs()

            UpdateCurrency()

            UpdateAmount()

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        '==============CURRENCY=================================
        Private Sub UpdateCurrency()
            txtRate.Text = Configuration.FormatToString(Me.m_entity.Currency.Conversion, DigitConfig.Price)
            txtLanguage.Text = Me.m_entity.Currency.Language
            txtUnit1.Text = Me.m_entity.Currency.Unit
            txtUnit2.Text = Me.m_entity.Currency.SubUnit
        End Sub
        '==============CURRENCY=================================
        Private Sub ibtnUpDateVat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnUpDateVat.Click
            UpdateVat()
        End Sub
        Private Sub UpdateVat()
            Me.m_entity.GenVatItems()
        End Sub
        Private Sub RefreshDocs(Optional ByVal refresh As Boolean = False)
            Me.m_isInitialized = False
            Me.m_entity.ItemCollection.PopulatePaySelectionItem(m_treeManager.Treetable, refresh)
            RefreshBlankGrid()
            ReIndex()
            Me.m_treeManager.Treetable.AcceptChanges()
            Me.m_isInitialized = True
        End Sub
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If e.Name = "ItemChanged" Then
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
                '==============CURRENCY=================================
                Case "txtrate"
                    dirtyFlag = True
                Case "txtlanguage"
                    Me.m_entity.Currency.Language = txtLanguage.Text
                    dirtyFlag = True
                Case "txtunit1"
                    Me.m_entity.Currency.Unit = txtUnit1.Text
                    dirtyFlag = True
                Case "txtunit2"
                    Me.m_entity.Currency.SubUnit = txtUnit2.Text
                    dirtyFlag = True
                    '==============CURRENCY=================================
                Case "chkonhold"
                    Me.m_entity.Payment.OnHold = chkOnHold.Checked
                    dirtyFlag = True
                Case "cmbcode"
                    Me.m_entity.Code = cmbCode.Text
                    'เพิ่ม AutoCode
                    If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
                        Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
                        Me.m_entity.OnGlChanged()
                    End If
                    dirtyFlag = True
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True
                Case "txtsuppliercode"
                    If supplierCodeChanged Then
                        supplierCodeChanged = False
                        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                        If Me.txtSupplierCode.TextLength <> 0 Then
                            Dim oldSupplier As Supplier = Me.m_entity.Supplier
                            Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, False)
                            Try
                                If oldSupId <> Me.m_entity.Supplier.Id Then
                                    If oldSupId = 0 Then
                                        oldSupId = Me.m_entity.Supplier.Id
                                        dirtyFlag = True
                                        ChangeSupplier()
                                    Else
                                        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.Message.ChangeSupplier}", "${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.Caption.ChangeSupplier}") Then
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
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdate"
                    m_dateSetting = True
                    If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDate.Text)
                        If Not Me.m_entity.DocDate.Equals(theDate) Then
                            dtpDocDate.Value = theDate
                            Me.m_entity.DocDate = dtpDocDate.Value
                            dirtyFlag = True
                        End If
                    Else
                        dtpDocDate.Value = Date.Now
                        Me.m_entity.DocDate = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Private Sub ChangeSupplier()
            oldSupId = Me.m_entity.Supplier.Id
            Me.m_entity.ItemCollection.Clear()
            RefreshDocs()
            UpdateAmount()
            supplierCodeChanged = False
            Me.m_entity.CreditPeriod = Me.m_entity.Supplier.CreditPeriod
            txtCreditPeriodChanged = False
        End Sub
        Private Sub UpdateAmount()
            m_isInitialized = False
            txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
            Me.txtItemCount.Text = Configuration.FormatToString(m_entity.ItemCount, DigitConfig.Int)
            Me.txtRemaining.Text = Configuration.FormatToString(m_entity.RemainingAmountAfter, DigitConfig.Price)
            Me.txtRetention.Text = Configuration.FormatToString(m_entity.ItemCollection.GetRetentionDeducted, DigitConfig.Price)
            Me.txtPlusRetention.Text = Configuration.FormatToString(m_entity.ItemCollection.GetPlusRetention, DigitConfig.Price)
            m_isInitialized = True
        End Sub
        Public Sub SetStatus()
            MyBase.SetStatusBarMessage()
        End Sub
        Private m_entityChanged As Boolean = False
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not Object.ReferenceEquals(Value, m_entity) Then
                    m_entityChanged = False
                Else
                    m_entityChanged = True
                End If
                If Not m_entity Is Nothing Then
                    RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, PaySelection)
                'Hack:
                If Not m_entity Is Nothing Then
                    Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                End If
                'PurchaseCN เมื่อ save
                RemoveHandler m_entity.PurchaseCNClick, AddressOf ItemButtonClick
                AddHandler m_entity.PurchaseCNClick, AddressOf ItemButtonClick
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()
            'PopulateRequestor()
            'PopulateCostCenter()
        End Sub


#End Region

#Region "Event Handlers"
        Private Sub CellDblClick(ByVal sender As Object, ByVal e As System.EventArgs)

            Dim doc As BillAcceptanceItem = Me.CurrentItem

            Dim dpar As BillAcceptance = Me.CurrentParItem

            Dim docId As Integer
            Dim docType As Integer

            If doc Is Nothing AndAlso dpar Is Nothing Then
                Return
            Else
                If Not dpar Is Nothing Then
                    docId = dpar.Id
                    docType = dpar.EntityId
                Else
                    docId = doc.Id
                    docType = doc.EntityId
                End If
            End If

            If docType = 199 Then 'รับวางบิล Retention
                docType = doc.RetentionType
            End If

            If docId > 0 AndAlso docType > 0 Then
                Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(docType), docId)
                myEntityPanelService.OpenDetailPanel(en)
            End If

        End Sub
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_oldCode As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
                'Me.Validator.SetRequired(Me.txtCode, False)
                'Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDown
                Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
                BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
                If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
                    If Me.cmbCode.Items.Count > 0 Then
                        Me.m_entity.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
                        Me.cmbCode.SelectedIndex = 0
                        Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
                    End If
                Else
                    Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(Me.m_entity.Code)
                    If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
                        Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
                    End If
                End If
                m_oldCode = Me.cmbCode.Text
                Me.m_entity.Code = m_oldCode
                Me.m_entity.AutoGen = True
            Else
                'Me.Validator.SetRequired(Me.txtCode, True)
                Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
                Me.cmbCode.Items.Clear()
                Me.cmbCode.Text = m_oldCode
                Me.m_entity.AutoGen = False
            End If
        End Sub
        Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Supplier Is Nothing OrElse Not Me.m_entity.Supplier.Originated Then
                msgServ.ShowMessage("${res:Global.Error.SpecifySupplier}")
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filterEntities(7) As ArrayList
            For i As Integer = 0 To 7
                filterEntities(i) = New ArrayList
                filterEntities(i).Add(Me.m_entity.Supplier)
            Next
            Dim filters(7)() As Filter
            Dim grNeedsApproval As Boolean = False
            grNeedsApproval = CBool(Configuration.GetConfig("ApproveDO"))

            filters(0) = New Filter() {New Filter("IDList", GetItemIDList(45)), _
            New Filter("grNeedsApproval", grNeedsApproval)}

            filters(1) = New Filter() {New Filter("ExcludeIdList", GetBAExcludeList), _
            New Filter("remainMustValid", True), _
            New Filter("pays_id", Me.m_entity.Id) _
            , New Filter("grNeedsApproval", grNeedsApproval), _
            New Filter("Id", Me.m_entity.Id)} 'Hack: filter อันสุดท้ายไม่เอาไป Query

            filters(2) = New Filter() {New Filter("IDList", GetItemIDList(15))}

            filters(3) = New Filter() {New Filter("IDList", GetItemIDList(50)), _
            New Filter("remainMustValid", True), _
            New Filter("pays_id", Me.m_entity.Id)}

            filters(4) = New Filter() {New Filter("IDList", GetItemIDList(46))}

            filters(5) = New Filter() {New Filter("IDList", GetRetItemIDList(45)) _
            , New Filter("grNeedsApproval", grNeedsApproval)}
            filters(6) = New Filter() {New Filter("IDList", GetRetItemIDList(292)) _
           , New Filter("grNeedsApproval", grNeedsApproval)}

            filters(7) = New Filter() {New Filter("IDList", GetItemIDList(292))}
            'New Filter("remainMustValid", True), _

            'filters(5) = New Filter() {New Filter("IDList", GetItemIDList(47))}
            Dim entities(7) As ISimpleEntity
            entities(0) = New GoodsReceiptForPaySelection
            entities(1) = New BillAcceptanceItem
            entities(2) = New APOpeningBalanceForPaySelection
            entities(3) = New EqMaintenance
            entities(4) = New PurchaseCNForPaySelection
            entities(5) = New PurchaseRetentionForPaySelection
            entities(6) = New PARetentionForPaySelection
            'entities(5) = New PurchaseDN
            entities(7) = New PAForPaySelection
            myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, filters, filterEntities, 0)
        End Sub
        Private Function GetItemIDList(ByVal type As Integer) As String
            Dim ret As String = ""
            For Each item As BillAcceptanceItem In Me.m_entity.ItemCollection
                If item.Originated AndAlso item.EntityId = type AndAlso item.ParentType = 0 Then
                    ret &= item.Id.ToString & ","
                End If
            Next
            If ret.EndsWith(",") Then
                ret = ret.Substring(0, ret.Length - 1)
            End If
            Return ret
        End Function
        Private Function GetRetItemIDList(ByVal type As Integer) As String
            Dim ret As String = ""
            For Each item As BillAcceptanceItem In Me.m_entity.ItemCollection
                If item.Originated AndAlso item.EntityId = 199 AndAlso item.RetentionType = type AndAlso item.ParentType = 0 Then
                    ret &= item.Id.ToString & ","
                End If
            Next
            If ret.EndsWith(",") Then
                ret = ret.Substring(0, ret.Length - 1)
            End If
            Return ret
        End Function
        Private Function GetBAExcludeList() As String
            Dim ret As String = ""
            For Each item As BillAcceptanceItem In Me.m_entity.ItemCollection
                If item.ParentId <> 0 Then
                    ret &= "|" & item.ParentId.ToString & ":" & item.Linenumber.ToString & "|"
                End If
            Next
            Return ret
        End Function
        Private Sub SetItems(ByVal items As BasketItemCollection)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If items.Count = 0 Then
                Return
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim insertIndex As Integer
            Dim newItem As BillAcceptanceItem
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim payable As IPayable
                If TypeOf items(i) Is StockBasketItem Then
                    Dim item As StockBasketItem = CType(items(i), StockBasketItem)
                    Select Case item.FullClassName.ToLower
                        Case "longkong.pojjaman.businesslogic.billacceptanceitem"
                            newItem = CType(item.Tag, BillAcceptanceItem)
                            'Case "Longkong.Pojjaman.BusinessLogic.GoodsReceipt"
                            '    If Not IsDBNull(item.Tag) Then
                            '       newItem = New BillAcceptanceItem(New GoodsReceipt(CInt(item.Tag)), Me.m_entity)
                            '    End If
                            'Case "Longkong.Pojjaman.BusinessLogic.PurchaseCN"
                            '    If Not IsDBNull(item.Tag) Then
                            '        newItem = New BillAcceptanceItem(New PurchaseCN(CInt(item.Tag)), Me.m_entity)
                            '    End If
                            'Case "Longkong.Pojjaman.BusinessLogic.PurchaseDN"
                            '    If Not IsDBNull(item.Tag) Then
                            '        newItem = New BillAcceptanceItem(New PurchaseDN(CInt(item.Tag)), Me.m_entity)
                            '    End If
                            'Case "Longkong.Pojjaman.BusinessLogic.APOpeningBalance"
                            '    If Not IsDBNull(item.Tag) Then
                            '        newItem = New BillAcceptanceItem(New APOpeningBalance(CInt(item.Tag)), Me.m_entity)
                            '    End If
                    End Select
                Else
                    Dim item As BasketItem = CType(items(i), BasketItem)
                    If TypeOf item.Tag Is DataRow Then
                        'If item.FullClassName.ToLower = "longkong.pojjaman.businesslogic.pa" Then
                        '  'newItem = New BillAcceptanceItem(New PA(item.Id), Me.m_entity)
                        '  newItem = New BillAcceptanceItem(CType(item.Tag, DataRow), "", Me.m_entity)
                        'Else
                        newItem = New BillAcceptanceItem(CType(item.Tag, DataRow), "", Me.m_entity)
                        'End If
                        If newItem.EntityId = 45 Or newItem.EntityId = 292 Then
                            'payable = New GoodsReceipt(item.Id) 'Julawut ถ้า new GoodsReceipt จะช้ามาก ๆ *แก้เรื่องความเร็ว
                            Dim wht As WitholdingTaxCollection = New WitholdingTaxCollection(newItem.Id, newItem.EntityId)
                            payable = New GoodsReceipt
                            CType(payable, GoodsReceipt).WitholdingTaxCollection = wht
                        End If
                    Else
                        Select Case item.FullClassName.ToLower
                            Case "longkong.pojjaman.businesslogic.goodsreceipt"
                                payable = New GoodsReceipt(item.Id)
                                newItem = New BillAcceptanceItem(payable, Me.m_entity)
                            Case "longkong.pojjaman.businesslogic.purchasecn"
                                payable = New PurchaseCN(item.Id)
                                newItem = New BillAcceptanceItem(payable, Me.m_entity)
                            Case "longkong.pojjaman.businesslogic.purchasedn"
                                payable = New PurchaseDN(item.Id)
                                newItem = New BillAcceptanceItem(payable, Me.m_entity)
                            Case "longkong.pojjaman.businesslogic.apopeningbalance"
                                payable = New APOpeningBalance(item.Id)
                                newItem = New BillAcceptanceItem(payable, Me.m_entity)
                            Case "longkong.pojjaman.businesslogic.eqmaintenance"
                                payable = New EqMaintenance(item.Id)
                                newItem = New BillAcceptanceItem(payable, Me.m_entity)
                            Case "longkong.pojjaman.businesslogic.pa"
                                payable = New PA(item.Id)
                                newItem = New BillAcceptanceItem(payable, Me.m_entity)
                        End Select
                    End If
                End If
                If Not newItem Is Nothing Then
                    If Not Me.m_entity.ValidateReferenceDocDate(newItem) Then
                        msgServ.ShowWarningFormatted("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.Message.DocDateLessThanRefDocDae}", New String() {newItem.Date.ToShortDateString, Me.m_entity.DocDate.ToShortDateString})
                        Return
                    End If
                    'newItem.Amount = Math.Min(newItem.UnpaidAmount, newItem.BilledAmount)
                    'newItem.UnpaidAmount = Math.Min(newItem.RealAmount, newItem.UnpaidAmount)
                    newItem.Amount = 0
                    If i = items.Count - 1 Then
                        'ตัวแรก -- update old item
                        If Me.m_entity.ItemCollection.Count = 0 Then
                            Me.m_entity.ItemCollection.Add(newItem)

                            '===CURRENCY===
                            Me.m_entity.Currency = newItem.Currency.Clone
                            UpdateCurrency()
                            '===CURRENCY===
                        Else
                            Dim theDoc As BillAcceptanceItem = Me.CurrentItem
                            If theDoc Is Nothing Then
                                If index > Me.m_entity.ItemCollection.Count - 1 Then
                                    Me.m_entity.ItemCollection.Add(newItem)
                                    theDoc = newItem
                                    insertIndex = Me.m_entity.ItemCollection.IndexOf(newItem)
                                Else
                                    Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
                                    theDoc = Me.m_entity.ItemCollection(insertIndex)
                                End If
                            End If
                            theDoc.Id = newItem.Id
                            theDoc.Code = newItem.Code
                            theDoc.AfterTax = newItem.AfterTax
                            theDoc.RealAmount = newItem.BilledAmount
                            theDoc.BilledAmount = newItem.BilledAmount
                            theDoc.Amount = newItem.Amount
                            theDoc.UnpaidAmount = newItem.UnpaidAmount
                            theDoc.SetType(newItem.EntityId)
                            theDoc.CreditPeriod = newItem.CreditPeriod
                            theDoc.Date = newItem.Date
                            theDoc.RetentionType = newItem.RetentionType
                        End If
                    Else
                        If Not Me.m_entity.ValidateReferenceDocDate(newItem) Then
                            msgServ.ShowWarningFormatted("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.Message.DocDateLessThanRefDocDae}", New String() {newItem.Date.ToShortDateString, Me.m_entity.DocDate.ToShortDateString})
                            Return
                        End If
                        Me.m_entity.ItemCollection.Insert(insertIndex, newItem)
                    End If
                    If TypeOf payable Is ICanDelayWHT Then
                        If TypeOf payable Is IWitholdingTaxable Then
                            If CType(payable, IWitholdingTaxable).WitholdingTaxCollection.IsBeforePay Then
                                CType(payable, IWitholdingTaxable).WitholdingTaxCollection.RefDoc = payable

                                Dim key As Integer
                                Dim delCurrWHT As New Hashtable
                                For Each wht As WitholdingTax In Me.m_entity.WitholdingTaxCollection
                                    key += 1

                                    If Not wht.RefDoc Is Nothing AndAlso (TypeOf wht.RefDoc Is PaySelection OrElse TypeOf wht.RefDoc Is ReceiveSelection) Then
                                        delCurrWHT(key) = wht
                                    End If
                                Next
                                For Each wht As WitholdingTax In delCurrWHT.Values
                                    If Me.m_entity.WitholdingTaxCollection.Contains(wht) Then
                                        Me.m_entity.WitholdingTaxCollection.Remove(wht)
                                    End If
                                Next
                                For Each wht As WitholdingTax In CType(payable, IWitholdingTaxable).WitholdingTaxCollection
                                    wht.RefDoc = payable
                                    wht.AutoGen = True
                                    wht.Code = BusinessLogic.Entity.GetAutoCodeFormat(wht.EntityId)
                                    Me.m_entity.WitholdingTaxCollection.Add(wht)
                                Next
                                Me.m_entity.RefWHTCollection.Add(CType(payable, IWitholdingTaxable).WitholdingTaxCollection)
                            End If
                        End If
                    End If
                End If
            Next
            RefreshDocs(True)
            tgItem.CurrentRowIndex = index
            UpdateAmount()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.ItemCollection.Count - 1 Then
                Return
            End If
            Me.m_entity.ItemCollection.Insert(index, New BillAcceptanceItem)
            RefreshDocs()
            tgItem.CurrentRowIndex = index
            Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
        , Me.m_treeManager.Treetable.Columns("paysi_amt") _
        , Me.CurrentItem.Amount)
            Me.ValidateRow(re)
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Dim row As TreeRow = Me.m_treeManager.SelectedRow
            If row Is Nothing Then
                Return
            End If
            Dim doc As BillAcceptanceItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            'Dim key As Integer
            'Dim oldWht As New Hashtable
            'For Each wht As WitholdingTax In Me.m_entity.WitholdingTaxCollection
            '  key += 1
            '  If Not wht.RefDoc Is Nothing AndAlso Object.ReferenceEquals(wht.RefDoc, doc) Then
            '    oldWht(key) = wht
            '  End If
            'Next
            'For Each wht As WitholdingTax In oldWht.Values
            '  If oldWht.Contains(wht) Then
            '    Me.m_entity.WitholdingTaxCollection.Remove(wht)
            '  End If
            'Next
            Me.m_entity.ItemCollection.Remove(doc)

            RefreshDocs()
            Me.tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ReIndex()
            Dim i As Integer = 0
            For Each row As DataRow In Me.m_treeManager.Treetable.Rows
                row("paysi_linenumber") = i + 1
                i += 1
            Next
        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Overrides"
        Public Overrides Sub NotifyBeforeSave()

        End Sub
        'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
        '    If Not successful Then
        '        Return
        '    End If
        '    Me.Entity = New PR(Me.Entity.Id)
        '    Dim listPanel As ISimpleListPanel = CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel)
        '    listPanel.SelectedEntity = Me.Entity
        'End Sub
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New PR).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Event of Button controls"
        Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplier.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Supplier)
        End Sub
        Private Sub btnSupplierDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowSupplierDialog.Click
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
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
        Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Me.m_entity Is Nothing Then
                Return
            End If
            RefreshBlankGrid()
        End Sub
        Private Sub RefreshBlankGrid()
            'If Me.tgItem.Height = 0 Then
            '    Return
            'End If
            'Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            'Dim noParentText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.BlankParentText}")
            'Dim parRow As TreeRow = BillAcceptanceItemCollection.FindRow(Me.m_treeManager.Treetable, 0, noParentText, 0)
            'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            'Dim index As Integer = tgItem.CurrentRowIndex
            'Dim maxVisibleCount As Integer
            'Dim tgRowHeight As Integer = 17
            'maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
            'Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
            '    'เพิ่มแถวจนเต็ม
            '    parRow.Childs.Add()
            'Loop
            ''If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
            ''    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
            ''        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
            ''        parRow.Childs.Add()
            ''    End If
            ''End If
            'Me.m_treeManager.Treetable.AcceptChanges()
            'tgItem.CurrentRowIndex = Math.Max(0, index)
            'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

            If Me.tgItem.Height = 0 Then
                Return
            End If
            Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            Dim index As Integer = tgItem.CurrentRowIndex
            Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
                'เพิ่มแถวจนเต็ม
                Me.m_treeManager.Treetable.Childs.Add()
            Loop

            Dim rowCount As Integer = 0
            For Each child As TreeRow In Me.m_treeManager.Treetable.Childs
                rowCount += child.Childs.Count
            Next
            If Me.m_entity.ItemCollection.Count = rowCount Then
                'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                Me.m_treeManager.Treetable.Childs.Add()
            End If

            Me.m_treeManager.Treetable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

    End Class
End Namespace