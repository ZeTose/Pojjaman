Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MarkupDistribution
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
        Friend WithEvents grbDistMarkup As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents cmbMethod As System.Windows.Forms.ComboBox
        Friend WithEvents lblMethod As System.Windows.Forms.Label
        Friend WithEvents grbUseItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtFrom As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents lblFrom As System.Windows.Forms.Label
        Friend WithEvents txtTo As System.Windows.Forms.TextBox
        Friend WithEvents lblTo As System.Windows.Forms.Label
        Friend WithEvents lblBaht As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblWBS As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents grbInformation As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtTotalMarkup As System.Windows.Forms.TextBox
        Friend WithEvents lblTotalMarkup As System.Windows.Forms.Label
        Friend WithEvents lblDistributeMarkup As System.Windows.Forms.Label
        Friend WithEvents txtDistributeMarkup As System.Windows.Forms.TextBox
        Friend WithEvents lblRemainingMarkup As System.Windows.Forms.Label
        Friend WithEvents txtRemainingMarkup As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider2 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblBOQCode As System.Windows.Forms.Label
        Friend WithEvents txtBOQCode As System.Windows.Forms.TextBox
        Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
        Friend WithEvents lblProject As System.Windows.Forms.Label
        Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
        Friend WithEvents tvMarkup As System.Windows.Forms.TreeView
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents rdSearch As System.Windows.Forms.RadioButton
        Friend WithEvents rdAll As System.Windows.Forms.RadioButton
        Friend WithEvents rdSelected As System.Windows.Forms.RadioButton
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDistributedAmount As System.Windows.Forms.Label
        Friend WithEvents txtAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblAmount As System.Windows.Forms.Label
        Friend WithEvents lblDistribuetedAmountUnit As System.Windows.Forms.Label
        Friend WithEvents txtDistributedAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblAmountUnit As System.Windows.Forms.Label
        Friend WithEvents lblTotalProfit As System.Windows.Forms.Label
        Friend WithEvents lblDistributedProfit As System.Windows.Forms.Label
        Friend WithEvents txtTotalProfit As System.Windows.Forms.TextBox
        Friend WithEvents txtDistributedProfit As System.Windows.Forms.TextBox
        Friend WithEvents lblRemainingProfit As System.Windows.Forms.Label
        Friend WithEvents txtRemainingProfit As System.Windows.Forms.TextBox
        Friend WithEvents txtTotalMarkupPercent As System.Windows.Forms.TextBox
        Friend WithEvents txtDistributeMarkupPercent As System.Windows.Forms.TextBox
        Friend WithEvents txtRemainingMarkupPercent As System.Windows.Forms.TextBox
        Friend WithEvents txtTotalProfitPercent As System.Windows.Forms.TextBox
        Friend WithEvents txtDistributedProfitPercent As System.Windows.Forms.TextBox
        Friend WithEvents txtRemainingProfitPercent As System.Windows.Forms.TextBox
        Friend WithEvents lblPercent1 As System.Windows.Forms.Label
        Friend WithEvents lblPercent2 As System.Windows.Forms.Label
        Friend WithEvents lblPercent3 As System.Windows.Forms.Label
        Friend WithEvents lblPercent4 As System.Windows.Forms.Label
        Friend WithEvents lblPercent5 As System.Windows.Forms.Label
        Friend WithEvents lblPercent6 As System.Windows.Forms.Label
        Friend WithEvents txtMarkupName As System.Windows.Forms.TextBox
        Friend WithEvents lblMarkupName As System.Windows.Forms.Label
        Friend WithEvents cmbWBS As System.Windows.Forms.ComboBox
        Friend WithEvents grbView As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSelectAll As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.grbDistMarkup = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbView = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.rdSearch = New System.Windows.Forms.RadioButton
            Me.rdSelected = New System.Windows.Forms.RadioButton
            Me.rdAll = New System.Windows.Forms.RadioButton
            Me.txtMarkupName = New System.Windows.Forms.TextBox
            Me.lblMarkupName = New System.Windows.Forms.Label
            Me.cmbMethod = New System.Windows.Forms.ComboBox
            Me.lblMethod = New System.Windows.Forms.Label
            Me.grbUseItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbWBS = New System.Windows.Forms.ComboBox
            Me.txtFrom = New System.Windows.Forms.TextBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.lblFrom = New System.Windows.Forms.Label
            Me.txtTo = New System.Windows.Forms.TextBox
            Me.lblTo = New System.Windows.Forms.Label
            Me.lblBaht = New System.Windows.Forms.Label
            Me.lblName = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblWBS = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.txtAmount = New System.Windows.Forms.TextBox
            Me.lblAmount = New System.Windows.Forms.Label
            Me.lblDistribuetedAmountUnit = New System.Windows.Forms.Label
            Me.txtDistributedAmount = New System.Windows.Forms.TextBox
            Me.lblAmountUnit = New System.Windows.Forms.Label
            Me.lblDistributedAmount = New System.Windows.Forms.Label
            Me.btnSelectAll = New System.Windows.Forms.Button
            Me.tvMarkup = New System.Windows.Forms.TreeView
            Me.grbInformation = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTotalMarkup = New System.Windows.Forms.TextBox
            Me.lblTotalMarkup = New System.Windows.Forms.Label
            Me.lblDistributeMarkup = New System.Windows.Forms.Label
            Me.txtDistributeMarkup = New System.Windows.Forms.TextBox
            Me.lblRemainingMarkup = New System.Windows.Forms.Label
            Me.txtRemainingMarkup = New System.Windows.Forms.TextBox
            Me.lblTotalProfit = New System.Windows.Forms.Label
            Me.lblDistributedProfit = New System.Windows.Forms.Label
            Me.txtTotalProfit = New System.Windows.Forms.TextBox
            Me.txtDistributedProfit = New System.Windows.Forms.TextBox
            Me.lblRemainingProfit = New System.Windows.Forms.Label
            Me.txtRemainingProfit = New System.Windows.Forms.TextBox
            Me.txtTotalMarkupPercent = New System.Windows.Forms.TextBox
            Me.txtDistributeMarkupPercent = New System.Windows.Forms.TextBox
            Me.txtRemainingMarkupPercent = New System.Windows.Forms.TextBox
            Me.txtTotalProfitPercent = New System.Windows.Forms.TextBox
            Me.txtDistributedProfitPercent = New System.Windows.Forms.TextBox
            Me.txtRemainingProfitPercent = New System.Windows.Forms.TextBox
            Me.lblPercent1 = New System.Windows.Forms.Label
            Me.lblPercent2 = New System.Windows.Forms.Label
            Me.lblPercent3 = New System.Windows.Forms.Label
            Me.lblPercent4 = New System.Windows.Forms.Label
            Me.lblPercent5 = New System.Windows.Forms.Label
            Me.lblPercent6 = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider2 = New System.Windows.Forms.ErrorProvider
            Me.txtBOQCode = New System.Windows.Forms.TextBox
            Me.txtProjectName = New System.Windows.Forms.TextBox
            Me.txtProjectCode = New System.Windows.Forms.TextBox
            Me.lblBOQCode = New System.Windows.Forms.Label
            Me.lblProject = New System.Windows.Forms.Label
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDistMarkup.SuspendLayout()
            Me.grbView.SuspendLayout()
            Me.grbUseItem.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbInformation.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDistMarkup
            '
            Me.grbDistMarkup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDistMarkup.Controls.Add(Me.lblMethod)
            Me.grbDistMarkup.Controls.Add(Me.cmbMethod)
            Me.grbDistMarkup.Controls.Add(Me.grbView)
            Me.grbDistMarkup.Controls.Add(Me.txtMarkupName)
            Me.grbDistMarkup.Controls.Add(Me.lblMarkupName)
            Me.grbDistMarkup.Controls.Add(Me.grbUseItem)
            Me.grbDistMarkup.Controls.Add(Me.tgItem)
            Me.grbDistMarkup.Controls.Add(Me.lblItem)
            Me.grbDistMarkup.Controls.Add(Me.txtAmount)
            Me.grbDistMarkup.Controls.Add(Me.lblDistribuetedAmountUnit)
            Me.grbDistMarkup.Controls.Add(Me.txtDistributedAmount)
            Me.grbDistMarkup.Controls.Add(Me.lblAmountUnit)
            Me.grbDistMarkup.Controls.Add(Me.lblDistributedAmount)
            Me.grbDistMarkup.Controls.Add(Me.btnSelectAll)
            Me.grbDistMarkup.Controls.Add(Me.lblAmount)
            Me.grbDistMarkup.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDistMarkup.Location = New System.Drawing.Point(264, 8)
            Me.grbDistMarkup.Name = "grbDistMarkup"
            Me.grbDistMarkup.Size = New System.Drawing.Size(504, 440)
            Me.grbDistMarkup.TabIndex = 1
            Me.grbDistMarkup.TabStop = False
            Me.grbDistMarkup.Text = "Distribution Markup"
            '
            'grbView
            '
            Me.grbView.Controls.Add(Me.rdSearch)
            Me.grbView.Controls.Add(Me.rdSelected)
            Me.grbView.Controls.Add(Me.rdAll)
            Me.grbView.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbView.Location = New System.Drawing.Point(352, 96)
            Me.grbView.Name = "grbView"
            Me.grbView.Size = New System.Drawing.Size(144, 96)
            Me.grbView.TabIndex = 4
            Me.grbView.TabStop = False
            Me.grbView.Text = "ดูรายการ"
            '
            'rdSearch
            '
            Me.rdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdSearch.Location = New System.Drawing.Point(16, 16)
            Me.rdSearch.Name = "rdSearch"
            Me.rdSearch.Size = New System.Drawing.Size(120, 24)
            Me.rdSearch.TabIndex = 0
            Me.rdSearch.Text = "ค้นหา"
            '
            'rdSelected
            '
            Me.rdSelected.Checked = True
            Me.rdSelected.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdSelected.Location = New System.Drawing.Point(16, 64)
            Me.rdSelected.Name = "rdSelected"
            Me.rdSelected.Size = New System.Drawing.Size(120, 24)
            Me.rdSelected.TabIndex = 2
            Me.rdSelected.TabStop = True
            Me.rdSelected.Text = "เฉพาะรายการที่เลือก"
            '
            'rdAll
            '
            Me.rdAll.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdAll.Location = New System.Drawing.Point(16, 40)
            Me.rdAll.Name = "rdAll"
            Me.rdAll.Size = New System.Drawing.Size(120, 24)
            Me.rdAll.TabIndex = 1
            Me.rdAll.Text = "ทั้งหมด"
            '
            'txtMarkupName
            '
            Me.Validator.SetDataType(Me.txtMarkupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMarkupName, "")
            Me.txtMarkupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtMarkupName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMarkupName, System.Drawing.Color.Empty)
            Me.txtMarkupName.Location = New System.Drawing.Point(88, 16)
            Me.Validator.SetMaxValue(Me.txtMarkupName, "")
            Me.Validator.SetMinValue(Me.txtMarkupName, "")
            Me.txtMarkupName.Name = "txtMarkupName"
            Me.txtMarkupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMarkupName, "")
            Me.Validator.SetRequired(Me.txtMarkupName, False)
            Me.txtMarkupName.Size = New System.Drawing.Size(336, 22)
            Me.txtMarkupName.TabIndex = 12
            Me.txtMarkupName.TabStop = False
            Me.txtMarkupName.Text = ""
            '
            'lblMarkupName
            '
            Me.lblMarkupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMarkupName.ForeColor = System.Drawing.Color.Black
            Me.lblMarkupName.Location = New System.Drawing.Point(8, 16)
            Me.lblMarkupName.Name = "lblMarkupName"
            Me.lblMarkupName.Size = New System.Drawing.Size(80, 18)
            Me.lblMarkupName.TabIndex = 7
            Me.lblMarkupName.Text = "Name:"
            Me.lblMarkupName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbMethod
            '
            Me.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbMethod.Location = New System.Drawing.Point(88, 66)
            Me.cmbMethod.Name = "cmbMethod"
            Me.cmbMethod.Size = New System.Drawing.Size(336, 21)
            Me.cmbMethod.TabIndex = 1
            '
            'lblMethod
            '
            Me.lblMethod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMethod.Location = New System.Drawing.Point(16, 64)
            Me.lblMethod.Name = "lblMethod"
            Me.lblMethod.Size = New System.Drawing.Size(72, 24)
            Me.lblMethod.TabIndex = 8
            Me.lblMethod.Text = "Markup Distrubution:"
            Me.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbUseItem
            '
            Me.grbUseItem.Controls.Add(Me.cmbWBS)
            Me.grbUseItem.Controls.Add(Me.txtFrom)
            Me.grbUseItem.Controls.Add(Me.btnSearch)
            Me.grbUseItem.Controls.Add(Me.lblFrom)
            Me.grbUseItem.Controls.Add(Me.txtTo)
            Me.grbUseItem.Controls.Add(Me.lblTo)
            Me.grbUseItem.Controls.Add(Me.lblBaht)
            Me.grbUseItem.Controls.Add(Me.lblName)
            Me.grbUseItem.Controls.Add(Me.txtName)
            Me.grbUseItem.Controls.Add(Me.lblWBS)
            Me.grbUseItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbUseItem.Location = New System.Drawing.Point(8, 96)
            Me.grbUseItem.Name = "grbUseItem"
            Me.grbUseItem.Size = New System.Drawing.Size(336, 96)
            Me.grbUseItem.TabIndex = 3
            Me.grbUseItem.TabStop = False
            Me.grbUseItem.Text = "รายการที่ต้องการกระจาย Markup"
            '
            'cmbWBS
            '
            Me.cmbWBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbWBS.Location = New System.Drawing.Point(72, 72)
            Me.cmbWBS.Name = "cmbWBS"
            Me.cmbWBS.Size = New System.Drawing.Size(192, 21)
            Me.cmbWBS.TabIndex = 3
            '
            'txtFrom
            '
            Me.Validator.SetDataType(Me.txtFrom, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFrom, "")
            Me.txtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtFrom, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFrom, System.Drawing.Color.Empty)
            Me.txtFrom.Location = New System.Drawing.Point(72, 24)
            Me.Validator.SetMaxValue(Me.txtFrom, "")
            Me.Validator.SetMinValue(Me.txtFrom, "")
            Me.txtFrom.Name = "txtFrom"
            Me.Validator.SetRegularExpression(Me.txtFrom, "")
            Me.Validator.SetRequired(Me.txtFrom, False)
            Me.txtFrom.Size = New System.Drawing.Size(80, 22)
            Me.txtFrom.TabIndex = 0
            Me.txtFrom.Text = ""
            '
            'btnSearch
            '
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(272, 72)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(56, 23)
            Me.btnSearch.TabIndex = 9
            Me.btnSearch.Text = "ค้นหา"
            '
            'lblFrom
            '
            Me.lblFrom.BackColor = System.Drawing.Color.Transparent
            Me.lblFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFrom.Location = New System.Drawing.Point(8, 24)
            Me.lblFrom.Name = "lblFrom"
            Me.lblFrom.Size = New System.Drawing.Size(64, 20)
            Me.lblFrom.TabIndex = 4
            Me.lblFrom.Text = "Price from:"
            Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTo
            '
            Me.Validator.SetDataType(Me.txtTo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTo, "")
            Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTo, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTo, System.Drawing.Color.Empty)
            Me.txtTo.Location = New System.Drawing.Point(184, 24)
            Me.Validator.SetMaxValue(Me.txtTo, "")
            Me.Validator.SetMinValue(Me.txtTo, "")
            Me.txtTo.Name = "txtTo"
            Me.Validator.SetRegularExpression(Me.txtTo, "")
            Me.Validator.SetRequired(Me.txtTo, False)
            Me.txtTo.Size = New System.Drawing.Size(80, 22)
            Me.txtTo.TabIndex = 1
            Me.txtTo.Text = ""
            '
            'lblTo
            '
            Me.lblTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTo.Location = New System.Drawing.Point(152, 24)
            Me.lblTo.Name = "lblTo"
            Me.lblTo.Size = New System.Drawing.Size(32, 20)
            Me.lblTo.TabIndex = 7
            Me.lblTo.Text = "To"
            Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBaht
            '
            Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht.Location = New System.Drawing.Point(272, 24)
            Me.lblBaht.Name = "lblBaht"
            Me.lblBaht.Size = New System.Drawing.Size(32, 20)
            Me.lblBaht.TabIndex = 8
            Me.lblBaht.Text = "บาท"
            Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.Location = New System.Drawing.Point(8, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(64, 20)
            Me.lblName.TabIndex = 5
            Me.lblName.Text = "Description:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(72, 48)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(192, 22)
            Me.txtName.TabIndex = 2
            Me.txtName.Text = ""
            '
            'lblWBS
            '
            Me.lblWBS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblWBS.Location = New System.Drawing.Point(8, 72)
            Me.lblWBS.Name = "lblWBS"
            Me.lblWBS.Size = New System.Drawing.Size(64, 20)
            Me.lblWBS.TabIndex = 6
            Me.lblWBS.Text = "WBS:"
            Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.tgItem.Location = New System.Drawing.Point(8, 216)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(488, 216)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 5
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(16, 200)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(84, 19)
            Me.lblItem.TabIndex = 14
            Me.lblItem.Text = "รายการBOQ"
            '
            'txtAmount
            '
            Me.Validator.SetDataType(Me.txtAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAmount, "")
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAmount, System.Drawing.Color.Empty)
            Me.txtAmount.Location = New System.Drawing.Point(88, 40)
            Me.Validator.SetMaxValue(Me.txtAmount, "")
            Me.Validator.SetMinValue(Me.txtAmount, "")
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAmount, "")
            Me.Validator.SetRequired(Me.txtAmount, False)
            Me.txtAmount.Size = New System.Drawing.Size(104, 22)
            Me.txtAmount.TabIndex = 9
            Me.txtAmount.TabStop = False
            Me.txtAmount.Text = ""
            '
            'lblAmount
            '
            Me.lblAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAmount.Location = New System.Drawing.Point(8, 40)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(80, 20)
            Me.lblAmount.TabIndex = 6
            Me.lblAmount.Text = "Amount:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDistribuetedAmountUnit
            '
            Me.lblDistribuetedAmountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDistribuetedAmountUnit.Location = New System.Drawing.Point(424, 40)
            Me.lblDistribuetedAmountUnit.Name = "lblDistribuetedAmountUnit"
            Me.lblDistribuetedAmountUnit.Size = New System.Drawing.Size(32, 20)
            Me.lblDistribuetedAmountUnit.TabIndex = 13
            Me.lblDistribuetedAmountUnit.Text = "บาท"
            Me.lblDistribuetedAmountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDistributedAmount
            '
            Me.Validator.SetDataType(Me.txtDistributedAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDistributedAmount, "")
            Me.txtDistributedAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDistributedAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDistributedAmount, System.Drawing.Color.Empty)
            Me.txtDistributedAmount.Location = New System.Drawing.Point(288, 40)
            Me.Validator.SetMaxValue(Me.txtDistributedAmount, "")
            Me.Validator.SetMinValue(Me.txtDistributedAmount, "")
            Me.txtDistributedAmount.Name = "txtDistributedAmount"
            Me.Validator.SetRegularExpression(Me.txtDistributedAmount, "")
            Me.Validator.SetRequired(Me.txtDistributedAmount, False)
            Me.txtDistributedAmount.Size = New System.Drawing.Size(136, 22)
            Me.txtDistributedAmount.TabIndex = 0
            Me.txtDistributedAmount.Text = ""
            '
            'lblAmountUnit
            '
            Me.lblAmountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAmountUnit.Location = New System.Drawing.Point(192, 40)
            Me.lblAmountUnit.Name = "lblAmountUnit"
            Me.lblAmountUnit.Size = New System.Drawing.Size(32, 20)
            Me.lblAmountUnit.TabIndex = 10
            Me.lblAmountUnit.Text = "บาท"
            Me.lblAmountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDistributedAmount
            '
            Me.lblDistributedAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDistributedAmount.Location = New System.Drawing.Point(224, 40)
            Me.lblDistributedAmount.Name = "lblDistributedAmount"
            Me.lblDistributedAmount.Size = New System.Drawing.Size(64, 20)
            Me.lblDistributedAmount.TabIndex = 11
            Me.lblDistributedAmount.Text = "Distribute:"
            Me.lblDistributedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSelectAll
            '
            Me.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSelectAll.Location = New System.Drawing.Point(104, 192)
            Me.btnSelectAll.Name = "btnSelectAll"
            Me.btnSelectAll.Size = New System.Drawing.Size(128, 23)
            Me.btnSelectAll.TabIndex = 2
            Me.btnSelectAll.Text = "เลือก/ไม่เลือกทั้งหมด"
            '
            'tvMarkup
            '
            Me.tvMarkup.FullRowSelect = True
            Me.tvMarkup.HideSelection = False
            Me.tvMarkup.ImageIndex = -1
            Me.tvMarkup.Location = New System.Drawing.Point(0, 16)
            Me.tvMarkup.Name = "tvMarkup"
            Me.tvMarkup.SelectedImageIndex = -1
            Me.tvMarkup.Size = New System.Drawing.Size(264, 264)
            Me.tvMarkup.TabIndex = 0
            '
            'grbInformation
            '
            Me.grbInformation.Controls.Add(Me.lblTotalMarkup)
            Me.grbInformation.Controls.Add(Me.txtTotalMarkup)
            Me.grbInformation.Controls.Add(Me.lblDistributeMarkup)
            Me.grbInformation.Controls.Add(Me.txtDistributeMarkup)
            Me.grbInformation.Controls.Add(Me.lblRemainingMarkup)
            Me.grbInformation.Controls.Add(Me.txtRemainingMarkup)
            Me.grbInformation.Controls.Add(Me.lblTotalProfit)
            Me.grbInformation.Controls.Add(Me.lblDistributedProfit)
            Me.grbInformation.Controls.Add(Me.txtTotalProfit)
            Me.grbInformation.Controls.Add(Me.txtDistributedProfit)
            Me.grbInformation.Controls.Add(Me.lblRemainingProfit)
            Me.grbInformation.Controls.Add(Me.txtRemainingProfit)
            Me.grbInformation.Controls.Add(Me.txtTotalMarkupPercent)
            Me.grbInformation.Controls.Add(Me.txtDistributeMarkupPercent)
            Me.grbInformation.Controls.Add(Me.txtRemainingMarkupPercent)
            Me.grbInformation.Controls.Add(Me.txtTotalProfitPercent)
            Me.grbInformation.Controls.Add(Me.txtDistributedProfitPercent)
            Me.grbInformation.Controls.Add(Me.txtRemainingProfitPercent)
            Me.grbInformation.Controls.Add(Me.lblPercent1)
            Me.grbInformation.Controls.Add(Me.lblPercent2)
            Me.grbInformation.Controls.Add(Me.lblPercent3)
            Me.grbInformation.Controls.Add(Me.lblPercent4)
            Me.grbInformation.Controls.Add(Me.lblPercent5)
            Me.grbInformation.Controls.Add(Me.lblPercent6)
            Me.grbInformation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbInformation.Location = New System.Drawing.Point(8, 280)
            Me.grbInformation.Name = "grbInformation"
            Me.grbInformation.Size = New System.Drawing.Size(256, 168)
            Me.grbInformation.TabIndex = 2
            Me.grbInformation.TabStop = False
            Me.grbInformation.Text = "Information"
            '
            'txtTotalMarkup
            '
            Me.Validator.SetDataType(Me.txtTotalMarkup, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalMarkup, "")
            Me.txtTotalMarkup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalMarkup, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalMarkup, System.Drawing.Color.Empty)
            Me.txtTotalMarkup.Location = New System.Drawing.Point(112, 16)
            Me.Validator.SetMaxValue(Me.txtTotalMarkup, "")
            Me.Validator.SetMinValue(Me.txtTotalMarkup, "")
            Me.txtTotalMarkup.Name = "txtTotalMarkup"
            Me.txtTotalMarkup.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotalMarkup, "")
            Me.Validator.SetRequired(Me.txtTotalMarkup, False)
            Me.txtTotalMarkup.Size = New System.Drawing.Size(72, 22)
            Me.txtTotalMarkup.TabIndex = 1
            Me.txtTotalMarkup.TabStop = False
            Me.txtTotalMarkup.Text = ""
            Me.txtTotalMarkup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblTotalMarkup
            '
            Me.lblTotalMarkup.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalMarkup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotalMarkup.Location = New System.Drawing.Point(8, 16)
            Me.lblTotalMarkup.Name = "lblTotalMarkup"
            Me.lblTotalMarkup.Size = New System.Drawing.Size(104, 24)
            Me.lblTotalMarkup.TabIndex = 0
            Me.lblTotalMarkup.Text = "Include Overhead Amout:"
            Me.lblTotalMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDistributeMarkup
            '
            Me.lblDistributeMarkup.BackColor = System.Drawing.Color.Transparent
            Me.lblDistributeMarkup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDistributeMarkup.Location = New System.Drawing.Point(0, 40)
            Me.lblDistributeMarkup.Name = "lblDistributeMarkup"
            Me.lblDistributeMarkup.Size = New System.Drawing.Size(112, 20)
            Me.lblDistributeMarkup.TabIndex = 4
            Me.lblDistributeMarkup.Text = "Distributed:"
            Me.lblDistributeMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDistributeMarkup
            '
            Me.Validator.SetDataType(Me.txtDistributeMarkup, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDistributeMarkup, "")
            Me.txtDistributeMarkup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDistributeMarkup, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDistributeMarkup, System.Drawing.Color.Empty)
            Me.txtDistributeMarkup.Location = New System.Drawing.Point(112, 40)
            Me.Validator.SetMaxValue(Me.txtDistributeMarkup, "")
            Me.Validator.SetMinValue(Me.txtDistributeMarkup, "")
            Me.txtDistributeMarkup.Name = "txtDistributeMarkup"
            Me.txtDistributeMarkup.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDistributeMarkup, "")
            Me.Validator.SetRequired(Me.txtDistributeMarkup, False)
            Me.txtDistributeMarkup.Size = New System.Drawing.Size(72, 22)
            Me.txtDistributeMarkup.TabIndex = 5
            Me.txtDistributeMarkup.TabStop = False
            Me.txtDistributeMarkup.Text = ""
            Me.txtDistributeMarkup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblRemainingMarkup
            '
            Me.lblRemainingMarkup.BackColor = System.Drawing.Color.Transparent
            Me.lblRemainingMarkup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRemainingMarkup.Location = New System.Drawing.Point(0, 64)
            Me.lblRemainingMarkup.Name = "lblRemainingMarkup"
            Me.lblRemainingMarkup.Size = New System.Drawing.Size(112, 20)
            Me.lblRemainingMarkup.TabIndex = 8
            Me.lblRemainingMarkup.Text = "Remain Markup:"
            Me.lblRemainingMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRemainingMarkup
            '
            Me.Validator.SetDataType(Me.txtRemainingMarkup, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRemainingMarkup, "")
            Me.txtRemainingMarkup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRemainingMarkup, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRemainingMarkup, System.Drawing.Color.Empty)
            Me.txtRemainingMarkup.Location = New System.Drawing.Point(112, 64)
            Me.Validator.SetMaxValue(Me.txtRemainingMarkup, "")
            Me.Validator.SetMinValue(Me.txtRemainingMarkup, "")
            Me.txtRemainingMarkup.Name = "txtRemainingMarkup"
            Me.txtRemainingMarkup.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRemainingMarkup, "")
            Me.Validator.SetRequired(Me.txtRemainingMarkup, False)
            Me.txtRemainingMarkup.Size = New System.Drawing.Size(72, 22)
            Me.txtRemainingMarkup.TabIndex = 9
            Me.txtRemainingMarkup.TabStop = False
            Me.txtRemainingMarkup.Text = ""
            Me.txtRemainingMarkup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblTotalProfit
            '
            Me.lblTotalProfit.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotalProfit.Location = New System.Drawing.Point(8, 88)
            Me.lblTotalProfit.Name = "lblTotalProfit"
            Me.lblTotalProfit.Size = New System.Drawing.Size(104, 20)
            Me.lblTotalProfit.TabIndex = 12
            Me.lblTotalProfit.Text = "Total Profit"
            Me.lblTotalProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDistributedProfit
            '
            Me.lblDistributedProfit.BackColor = System.Drawing.Color.Transparent
            Me.lblDistributedProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDistributedProfit.Location = New System.Drawing.Point(0, 112)
            Me.lblDistributedProfit.Name = "lblDistributedProfit"
            Me.lblDistributedProfit.Size = New System.Drawing.Size(112, 20)
            Me.lblDistributedProfit.TabIndex = 16
            Me.lblDistributedProfit.Text = "Distribute Profit:"
            Me.lblDistributedProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTotalProfit
            '
            Me.Validator.SetDataType(Me.txtTotalProfit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalProfit, "")
            Me.txtTotalProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalProfit, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalProfit, System.Drawing.Color.Empty)
            Me.txtTotalProfit.Location = New System.Drawing.Point(112, 88)
            Me.Validator.SetMaxValue(Me.txtTotalProfit, "")
            Me.Validator.SetMinValue(Me.txtTotalProfit, "")
            Me.txtTotalProfit.Name = "txtTotalProfit"
            Me.txtTotalProfit.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotalProfit, "")
            Me.Validator.SetRequired(Me.txtTotalProfit, False)
            Me.txtTotalProfit.Size = New System.Drawing.Size(72, 22)
            Me.txtTotalProfit.TabIndex = 13
            Me.txtTotalProfit.TabStop = False
            Me.txtTotalProfit.Text = ""
            Me.txtTotalProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDistributedProfit
            '
            Me.Validator.SetDataType(Me.txtDistributedProfit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDistributedProfit, "")
            Me.txtDistributedProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDistributedProfit, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDistributedProfit, System.Drawing.Color.Empty)
            Me.txtDistributedProfit.Location = New System.Drawing.Point(112, 112)
            Me.Validator.SetMaxValue(Me.txtDistributedProfit, "")
            Me.Validator.SetMinValue(Me.txtDistributedProfit, "")
            Me.txtDistributedProfit.Name = "txtDistributedProfit"
            Me.txtDistributedProfit.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDistributedProfit, "")
            Me.Validator.SetRequired(Me.txtDistributedProfit, False)
            Me.txtDistributedProfit.Size = New System.Drawing.Size(72, 22)
            Me.txtDistributedProfit.TabIndex = 17
            Me.txtDistributedProfit.TabStop = False
            Me.txtDistributedProfit.Text = ""
            Me.txtDistributedProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblRemainingProfit
            '
            Me.lblRemainingProfit.BackColor = System.Drawing.Color.Transparent
            Me.lblRemainingProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRemainingProfit.Location = New System.Drawing.Point(0, 136)
            Me.lblRemainingProfit.Name = "lblRemainingProfit"
            Me.lblRemainingProfit.Size = New System.Drawing.Size(112, 20)
            Me.lblRemainingProfit.TabIndex = 20
            Me.lblRemainingProfit.Text = "Remain Profit:"
            Me.lblRemainingProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRemainingProfit
            '
            Me.Validator.SetDataType(Me.txtRemainingProfit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRemainingProfit, "")
            Me.txtRemainingProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRemainingProfit, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRemainingProfit, System.Drawing.Color.Empty)
            Me.txtRemainingProfit.Location = New System.Drawing.Point(112, 136)
            Me.Validator.SetMaxValue(Me.txtRemainingProfit, "")
            Me.Validator.SetMinValue(Me.txtRemainingProfit, "")
            Me.txtRemainingProfit.Name = "txtRemainingProfit"
            Me.txtRemainingProfit.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRemainingProfit, "")
            Me.Validator.SetRequired(Me.txtRemainingProfit, False)
            Me.txtRemainingProfit.Size = New System.Drawing.Size(72, 22)
            Me.txtRemainingProfit.TabIndex = 21
            Me.txtRemainingProfit.TabStop = False
            Me.txtRemainingProfit.Text = ""
            Me.txtRemainingProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtTotalMarkupPercent
            '
            Me.Validator.SetDataType(Me.txtTotalMarkupPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalMarkupPercent, "")
            Me.txtTotalMarkupPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalMarkupPercent, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalMarkupPercent, System.Drawing.Color.Empty)
            Me.txtTotalMarkupPercent.Location = New System.Drawing.Point(184, 16)
            Me.Validator.SetMaxValue(Me.txtTotalMarkupPercent, "")
            Me.Validator.SetMinValue(Me.txtTotalMarkupPercent, "")
            Me.txtTotalMarkupPercent.Name = "txtTotalMarkupPercent"
            Me.txtTotalMarkupPercent.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotalMarkupPercent, "")
            Me.Validator.SetRequired(Me.txtTotalMarkupPercent, False)
            Me.txtTotalMarkupPercent.Size = New System.Drawing.Size(48, 22)
            Me.txtTotalMarkupPercent.TabIndex = 2
            Me.txtTotalMarkupPercent.TabStop = False
            Me.txtTotalMarkupPercent.Text = ""
            Me.txtTotalMarkupPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDistributeMarkupPercent
            '
            Me.Validator.SetDataType(Me.txtDistributeMarkupPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDistributeMarkupPercent, "")
            Me.txtDistributeMarkupPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDistributeMarkupPercent, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDistributeMarkupPercent, System.Drawing.Color.Empty)
            Me.txtDistributeMarkupPercent.Location = New System.Drawing.Point(184, 40)
            Me.Validator.SetMaxValue(Me.txtDistributeMarkupPercent, "")
            Me.Validator.SetMinValue(Me.txtDistributeMarkupPercent, "")
            Me.txtDistributeMarkupPercent.Name = "txtDistributeMarkupPercent"
            Me.txtDistributeMarkupPercent.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDistributeMarkupPercent, "")
            Me.Validator.SetRequired(Me.txtDistributeMarkupPercent, False)
            Me.txtDistributeMarkupPercent.Size = New System.Drawing.Size(48, 22)
            Me.txtDistributeMarkupPercent.TabIndex = 6
            Me.txtDistributeMarkupPercent.TabStop = False
            Me.txtDistributeMarkupPercent.Text = ""
            Me.txtDistributeMarkupPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtRemainingMarkupPercent
            '
            Me.Validator.SetDataType(Me.txtRemainingMarkupPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRemainingMarkupPercent, "")
            Me.txtRemainingMarkupPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRemainingMarkupPercent, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRemainingMarkupPercent, System.Drawing.Color.Empty)
            Me.txtRemainingMarkupPercent.Location = New System.Drawing.Point(184, 64)
            Me.Validator.SetMaxValue(Me.txtRemainingMarkupPercent, "")
            Me.Validator.SetMinValue(Me.txtRemainingMarkupPercent, "")
            Me.txtRemainingMarkupPercent.Name = "txtRemainingMarkupPercent"
            Me.txtRemainingMarkupPercent.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRemainingMarkupPercent, "")
            Me.Validator.SetRequired(Me.txtRemainingMarkupPercent, False)
            Me.txtRemainingMarkupPercent.Size = New System.Drawing.Size(48, 22)
            Me.txtRemainingMarkupPercent.TabIndex = 10
            Me.txtRemainingMarkupPercent.TabStop = False
            Me.txtRemainingMarkupPercent.Text = ""
            Me.txtRemainingMarkupPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtTotalProfitPercent
            '
            Me.Validator.SetDataType(Me.txtTotalProfitPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotalProfitPercent, "")
            Me.txtTotalProfitPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTotalProfitPercent, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotalProfitPercent, System.Drawing.Color.Empty)
            Me.txtTotalProfitPercent.Location = New System.Drawing.Point(184, 88)
            Me.Validator.SetMaxValue(Me.txtTotalProfitPercent, "")
            Me.Validator.SetMinValue(Me.txtTotalProfitPercent, "")
            Me.txtTotalProfitPercent.Name = "txtTotalProfitPercent"
            Me.txtTotalProfitPercent.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTotalProfitPercent, "")
            Me.Validator.SetRequired(Me.txtTotalProfitPercent, False)
            Me.txtTotalProfitPercent.Size = New System.Drawing.Size(48, 22)
            Me.txtTotalProfitPercent.TabIndex = 14
            Me.txtTotalProfitPercent.TabStop = False
            Me.txtTotalProfitPercent.Text = ""
            Me.txtTotalProfitPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDistributedProfitPercent
            '
            Me.Validator.SetDataType(Me.txtDistributedProfitPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDistributedProfitPercent, "")
            Me.txtDistributedProfitPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDistributedProfitPercent, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDistributedProfitPercent, System.Drawing.Color.Empty)
            Me.txtDistributedProfitPercent.Location = New System.Drawing.Point(184, 112)
            Me.Validator.SetMaxValue(Me.txtDistributedProfitPercent, "")
            Me.Validator.SetMinValue(Me.txtDistributedProfitPercent, "")
            Me.txtDistributedProfitPercent.Name = "txtDistributedProfitPercent"
            Me.txtDistributedProfitPercent.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDistributedProfitPercent, "")
            Me.Validator.SetRequired(Me.txtDistributedProfitPercent, False)
            Me.txtDistributedProfitPercent.Size = New System.Drawing.Size(48, 22)
            Me.txtDistributedProfitPercent.TabIndex = 18
            Me.txtDistributedProfitPercent.TabStop = False
            Me.txtDistributedProfitPercent.Text = ""
            Me.txtDistributedProfitPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtRemainingProfitPercent
            '
            Me.Validator.SetDataType(Me.txtRemainingProfitPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRemainingProfitPercent, "")
            Me.txtRemainingProfitPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtRemainingProfitPercent, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRemainingProfitPercent, System.Drawing.Color.Empty)
            Me.txtRemainingProfitPercent.Location = New System.Drawing.Point(184, 136)
            Me.Validator.SetMaxValue(Me.txtRemainingProfitPercent, "")
            Me.Validator.SetMinValue(Me.txtRemainingProfitPercent, "")
            Me.txtRemainingProfitPercent.Name = "txtRemainingProfitPercent"
            Me.txtRemainingProfitPercent.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRemainingProfitPercent, "")
            Me.Validator.SetRequired(Me.txtRemainingProfitPercent, False)
            Me.txtRemainingProfitPercent.Size = New System.Drawing.Size(48, 22)
            Me.txtRemainingProfitPercent.TabIndex = 22
            Me.txtRemainingProfitPercent.TabStop = False
            Me.txtRemainingProfitPercent.Text = ""
            Me.txtRemainingProfitPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblPercent1
            '
            Me.lblPercent1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent1.Location = New System.Drawing.Point(232, 16)
            Me.lblPercent1.Name = "lblPercent1"
            Me.lblPercent1.Size = New System.Drawing.Size(16, 20)
            Me.lblPercent1.TabIndex = 3
            Me.lblPercent1.Text = "%"
            Me.lblPercent1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPercent2
            '
            Me.lblPercent2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent2.Location = New System.Drawing.Point(232, 40)
            Me.lblPercent2.Name = "lblPercent2"
            Me.lblPercent2.Size = New System.Drawing.Size(16, 20)
            Me.lblPercent2.TabIndex = 7
            Me.lblPercent2.Text = "%"
            Me.lblPercent2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPercent3
            '
            Me.lblPercent3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent3.Location = New System.Drawing.Point(232, 64)
            Me.lblPercent3.Name = "lblPercent3"
            Me.lblPercent3.Size = New System.Drawing.Size(16, 20)
            Me.lblPercent3.TabIndex = 11
            Me.lblPercent3.Text = "%"
            Me.lblPercent3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPercent4
            '
            Me.lblPercent4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent4.Location = New System.Drawing.Point(232, 88)
            Me.lblPercent4.Name = "lblPercent4"
            Me.lblPercent4.Size = New System.Drawing.Size(16, 20)
            Me.lblPercent4.TabIndex = 15
            Me.lblPercent4.Text = "%"
            Me.lblPercent4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPercent5
            '
            Me.lblPercent5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent5.Location = New System.Drawing.Point(232, 112)
            Me.lblPercent5.Name = "lblPercent5"
            Me.lblPercent5.Size = New System.Drawing.Size(16, 20)
            Me.lblPercent5.TabIndex = 19
            Me.lblPercent5.Text = "%"
            Me.lblPercent5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPercent6
            '
            Me.lblPercent6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent6.Location = New System.Drawing.Point(232, 136)
            Me.lblPercent6.Name = "lblPercent6"
            Me.lblPercent6.Size = New System.Drawing.Size(16, 20)
            Me.lblPercent6.TabIndex = 23
            Me.lblPercent6.Text = "%"
            Me.lblPercent6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Me.ErrorProvider2
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'ErrorProvider2
            '
            Me.ErrorProvider2.ContainerControl = Me
            '
            'txtBOQCode
            '
            Me.Validator.SetDataType(Me.txtBOQCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBOQCode, "")
            Me.txtBOQCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
            Me.txtBOQCode.Location = New System.Drawing.Point(64, 6)
            Me.Validator.SetMaxValue(Me.txtBOQCode, "")
            Me.Validator.SetMinValue(Me.txtBOQCode, "")
            Me.txtBOQCode.Name = "txtBOQCode"
            Me.txtBOQCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBOQCode, "")
            Me.Validator.SetRequired(Me.txtBOQCode, False)
            Me.txtBOQCode.Size = New System.Drawing.Size(96, 22)
            Me.txtBOQCode.TabIndex = 2
            Me.txtBOQCode.TabStop = False
            Me.txtBOQCode.Text = ""
            '
            'txtProjectName
            '
            Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectName, "")
            Me.txtProjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.txtProjectName.Location = New System.Drawing.Point(344, 6)
            Me.Validator.SetMaxValue(Me.txtProjectName, "")
            Me.Validator.SetMinValue(Me.txtProjectName, "")
            Me.txtProjectName.Name = "txtProjectName"
            Me.txtProjectName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProjectName, "")
            Me.Validator.SetRequired(Me.txtProjectName, False)
            Me.txtProjectName.Size = New System.Drawing.Size(352, 22)
            Me.txtProjectName.TabIndex = 5
            Me.txtProjectName.TabStop = False
            Me.txtProjectName.Text = ""
            '
            'txtProjectCode
            '
            Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectCode, "")
            Me.txtProjectCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.txtProjectCode.Location = New System.Drawing.Point(248, 6)
            Me.Validator.SetMaxValue(Me.txtProjectCode, "")
            Me.Validator.SetMinValue(Me.txtProjectCode, "")
            Me.txtProjectCode.Name = "txtProjectCode"
            Me.txtProjectCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
            Me.Validator.SetRequired(Me.txtProjectCode, False)
            Me.txtProjectCode.Size = New System.Drawing.Size(96, 22)
            Me.txtProjectCode.TabIndex = 4
            Me.txtProjectCode.TabStop = False
            Me.txtProjectCode.Text = ""
            '
            'lblBOQCode
            '
            Me.lblBOQCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBOQCode.ForeColor = System.Drawing.Color.Black
            Me.lblBOQCode.Location = New System.Drawing.Point(8, 8)
            Me.lblBOQCode.Name = "lblBOQCode"
            Me.lblBOQCode.Size = New System.Drawing.Size(56, 18)
            Me.lblBOQCode.TabIndex = 1
            Me.lblBOQCode.Text = "รหัสBOQ:"
            Me.lblBOQCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProject
            '
            Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProject.ForeColor = System.Drawing.Color.Black
            Me.lblProject.Location = New System.Drawing.Point(168, 8)
            Me.lblProject.Name = "lblProject"
            Me.lblProject.Size = New System.Drawing.Size(80, 18)
            Me.lblProject.TabIndex = 3
            Me.lblProject.Text = "โครงการประมูล:"
            Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.tvMarkup)
            Me.grbDetail.Controls.Add(Me.grbDistMarkup)
            Me.grbDetail.Controls.Add(Me.grbInformation)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 32)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(776, 456)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "Markup Distribution Settings"
            '
            'MarkupDistribution
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.lblBOQCode)
            Me.Controls.Add(Me.txtBOQCode)
            Me.Controls.Add(Me.txtProjectName)
            Me.Controls.Add(Me.lblProject)
            Me.Controls.Add(Me.txtProjectCode)
            Me.Name = "MarkupDistribution"
            Me.Size = New System.Drawing.Size(792, 496)
            Me.grbDistMarkup.ResumeLayout(False)
            Me.grbView.ResumeLayout(False)
            Me.grbUseItem.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbInformation.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As BOQ
        Private m_markup As Markup
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
        Private m_tableInitialized As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = BOQ.GetSchemaTable()
            m_treeManager = New TreeManager(dt, tgItem)
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False

            EventWiring()
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "BOQ"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csSelected As New DataGridCheckBoxColumn
            csSelected.MappingName = "Selected"
            csSelected.HeaderText = ""
            AddHandler csSelected.Click, AddressOf RowIcon_Click

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "boqi_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "boqi_linenumber"

            Dim csType As New TreeTextColumn
            csType.MappingName = "boqi_entityTypeDesc"
            csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TypeHeaderText}")
            csType.NullText = ""
            csType.TextBox.Name = "boqi_entityTypeDesc"
            csType.ReadOnly = True

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CodeHeaderText}")
            csCode.NullText = ""
            csCode.TextBox.Name = "Code"
            csCode.ReadOnly = True

            Dim csName As New PlusMinusTreeTextColumn
            csName.MappingName = "boqi_itemName"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
            csName.NullText = ""
            csName.Width = 180
            csName.TextBox.Name = "Description"
            csName.ReadOnly = True

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UnitHeaderText}")
            csUnit.NullText = ""
            csUnit.TextBox.Name = "Unit"
            csUnit.ReadOnly = True

            Dim csQty As New TreeTextColumn
            csQty.MappingName = "boqi_qty"
            csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.QtyHeaderText}")
            csQty.NullText = ""
            csQty.DataAlignment = HorizontalAlignment.Right
            csQty.Format = "#,###.##"
            csQty.TextBox.Name = "Qty"
            csQty.ReadOnly = True

            Dim csUMC As New TreeTextColumn
            csUMC.MappingName = "boqi_umc"
            csUMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UMCHeaderText}")
            csUMC.NullText = ""
            csUMC.DataAlignment = HorizontalAlignment.Right
            csUMC.Format = "#,###.##"
            csUMC.TextBox.Name = "boqi_umc"
            csUMC.ReadOnly = True

            Dim csTotalMC As New TreeTextColumn
            csTotalMC.MappingName = "TotalMaterialCost"
            csTotalMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalMaterialCostHeaderText}")
            csTotalMC.NullText = ""
            csTotalMC.DataAlignment = HorizontalAlignment.Right
            csTotalMC.Format = "#,###.##"
            csTotalMC.TextBox.Name = "TotalMaterialCost"
            csTotalMC.ReadOnly = True

            Dim csULC As New TreeTextColumn
            csULC.MappingName = "boqi_ulc"
            csULC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.ULCHeaderText}")
            csULC.NullText = ""
            csULC.DataAlignment = HorizontalAlignment.Right
            csULC.Format = "#,###.##"
            csULC.TextBox.Name = "boqi_ulc"
            csULC.ReadOnly = True

            Dim csTotalLC As New TreeTextColumn
            csTotalLC.MappingName = "TotalLaborCost"
            csTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalLaborCostHeaderText}")
            csTotalLC.NullText = ""
            csTotalLC.DataAlignment = HorizontalAlignment.Right
            csTotalLC.Format = "#,###.##"
            csTotalLC.TextBox.Name = "TotalLaborCost"
            csTotalLC.ReadOnly = True

            Dim csUEC As New TreeTextColumn
            csUEC.MappingName = "boqi_uec"
            csUEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UECHeaderText}")
            csUEC.NullText = ""
            csUEC.DataAlignment = HorizontalAlignment.Right
            csUEC.Format = "#,###.##"
            csUEC.TextBox.Name = "boqi_uec"
            csUEC.ReadOnly = True

            Dim csTotalEC As New TreeTextColumn
            csTotalEC.MappingName = "TotalEquipmentCost"
            csTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalEquipmentCostHeaderText}")
            csTotalEC.NullText = ""
            csTotalEC.DataAlignment = HorizontalAlignment.Right
            csTotalEC.Format = "#,###.##"
            csTotalEC.TextBox.Name = "TotalEquipmentCost"
            csTotalEC.ReadOnly = True

            Dim csTotal As New TreeTextColumn
            csTotal.MappingName = "Total"
            csTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalCostHeaderText}")
            csTotal.NullText = ""
            csTotal.DataAlignment = HorizontalAlignment.Right
            csTotal.Format = "#,###.##"
            csTotal.TextBox.Name = "Total"
            csTotal.ReadOnly = True

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "boqi_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "boqi_note"
            csNote.ReadOnly = True

            dst.GridColumnStyles.Add(csSelected)
            'dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csType)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csQty)
            dst.GridColumnStyles.Add(csUMC)
            dst.GridColumnStyles.Add(csTotalMC)
            dst.GridColumnStyles.Add(csULC)
            dst.GridColumnStyles.Add(csTotalLC)
            dst.GridColumnStyles.Add(csUEC)
            dst.GridColumnStyles.Add(csTotalEC)
            dst.GridColumnStyles.Add(csTotal)

            Return dst
        End Function
        Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
            Dim myTable As TreeTable = Me.m_treeManager.Treetable
            '******************************************************************************
            Dim clickedRow As TreeRow = CType(myTable.Rows(e.Row), TreeRow)
            If CBool(clickedRow("Selected")) Then
                TreeRow.TraverseRow(clickedRow, AddressOf CheckRow)
            Else
                TreeRow.TraverseRow(clickedRow, AddressOf UnCheckRow)
            End If
            '***************ถ้าไม่ AccepChanges จะเพี้ยน*************
            Me.m_treeManager.Treetable.AcceptChanges()
            Me.tgItem.RefreshHeights()
            '******************************************************************************
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub CheckRow(ByVal tr As TreeRow)
            Dim theCollection As DistributedItemCollection
            If Not Me.m_markup Is Nothing Then
                theCollection = Me.m_markup.DistributedItems
            ElseIf Not Me.tvMarkup.SelectedNode Is Nothing Then
                Select Case Me.tvMarkup.SelectedNode.Tag.ToString.ToLower
                    Case "matadj"
                        theCollection = Me.m_entity.MaterialMarkupItems
                    Case "labadj"
                        theCollection = Me.m_entity.LaborMarkupItems
                    Case "eqadj"
                        theCollection = Me.m_entity.LaborMarkupItems
                End Select
            End If
            If theCollection Is Nothing Then
                Return
            End If
            If TypeOf tr.Tag Is BoqItem Then
                theCollection.Add(CType(tr.Tag, BoqItem))
            End If
            tr("Selected") = True
        End Sub
        Private Sub UnCheckRow(ByVal tr As TreeRow)
            Dim theCollection As DistributedItemCollection
            If Not Me.m_markup Is Nothing Then
                theCollection = Me.m_markup.DistributedItems
            ElseIf Not Me.tvMarkup.SelectedNode Is Nothing Then
                Select Case Me.tvMarkup.SelectedNode.Tag.ToString.ToLower
                    Case "matadj"
                        theCollection = Me.m_entity.MaterialMarkupItems
                    Case "labadj"
                        theCollection = Me.m_entity.LaborMarkupItems
                    Case "eqadj"
                        theCollection = Me.m_entity.LaborMarkupItems
                End Select
            End If
            If theCollection Is Nothing Then
                Return
            End If
            If TypeOf tr.Tag Is BoqItem Then
                theCollection.Remove(CType(tr.Tag, BoqItem))
            End If
            tr("Selected") = False
        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()

        End Sub
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In Me.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            Me.cmbMethod.SelectedIndex = 0
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbDistMarkup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.grbDistMarkup}")
            Me.lblMethod.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblMethod}")
            Me.grbUseItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.grbUseItem}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.btnSearch}")
            Me.lblFrom.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblFrom}")
            Me.lblTo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblTo}")
            Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblName}")
            Me.lblWBS.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblWBS}")
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblItem}")
            Me.grbInformation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.grbInformation}")
            Me.lblTotalMarkup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblTotalMarkup}")
            Me.lblDistributeMarkup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblDistributeMarkup}")
            Me.lblRemainingMarkup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblRemainingMarkup}")
            Me.lblBOQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblBOQCode}")
            Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblProject}")
            Me.btnSelectAll.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.btnSelectAll}")
            Me.rdAll.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.rdAll}")
            Me.rdSearch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.rdSearch}")
            Me.rdSelected.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.rdSelected}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.grbDetail}")
            Me.grbView.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.grbView}")
            Me.lblMarkupName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblMarkupName}")
            Me.lblTotalProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblTotalProfit}")
            Me.lblDistributedProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblDistributedProfit}")
            Me.lblRemainingProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblRemainingProfit}")
            Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblAmount}")
            Me.lblAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblDistributedAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblDistributedAmount}")
            Me.lblDistribuetedAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblPercent1.Text = Me.StringParserService.Parse("${res:Global.PercentText}")
            Me.lblPercent2.Text = Me.StringParserService.Parse("${res:Global.PercentText}")
            Me.lblPercent3.Text = Me.StringParserService.Parse("${res:Global.PercentText}")
            Me.lblPercent4.Text = Me.StringParserService.Parse("${res:Global.PercentText}")
            Me.lblPercent5.Text = Me.StringParserService.Parse("${res:Global.PercentText}")
            Me.lblPercent6.Text = Me.StringParserService.Parse("${res:Global.PercentText}")
        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler txtDistributedAmount.Validated, AddressOf Me.TextHandler
            AddHandler txtDistributedAmount.TextChanged, AddressOf Me.ChangeProperty

            AddHandler cmbMethod.SelectedIndexChanged, AddressOf Me.ChangeProperty

            AddHandler rdSearch.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler rdAll.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler rdSelected.CheckedChanged, AddressOf Me.ChangeProperty
        End Sub
        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtdistributedamount"
                    If Not Me.m_markup Is Nothing Then
                        Dim txt As String = Me.txtDistributedAmount.Text
                        txt = txt.Replace(",", "")
                        If txt.Length = 0 Then
                            Me.m_markup.DistributedAmount = 0
                        Else
                            Try
                                Me.m_markup.DistributedAmount = Math.Min(CDec(TextParser.Evaluate(txt)), Me.m_markup.TotalAmount)
                            Catch ex As Exception
                                Me.m_markup.DistributedAmount = 0
                            End Try
                        End If
                        Me.txtDistributedAmount.Text = Configuration.FormatToString(Me.m_markup.DistributedAmount, DigitConfig.Price)
                        UpdateAmount()
                    ElseIf Not Me.tvMarkup.SelectedNode Is Nothing Then
                        If Not Me.tvMarkup.SelectedNode.Tag Is Nothing Then
                            Select Case Me.tvMarkup.SelectedNode.Tag.ToString.ToLower
                                Case "matadj"
                                Case "labadj"
                                Case "eqadj"
                            End Select
                        End If
                    End If
            End Select
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            txtBOQCode.Text = m_entity.Code
            txtProjectCode.Text = m_entity.Project.Code
            txtProjectName.Text = m_entity.Project.Name

            m_entity.MarkupCollection.Populate(Me.tvMarkup)

            If Me.m_entity.MaterialMarkup <> 0 Then
                Dim theNode As New TreeNode(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.MatAdjust}"))
                theNode.Tag = "matAdj"
                Me.tvMarkup.Nodes.Add(theNode)
            End If
            If Me.m_entity.LaborMarkup <> 0 Then
                Dim theNode As New TreeNode(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.LaborAdjust}"))
                theNode.Tag = "labAdj"
                Me.tvMarkup.Nodes.Add(theNode)
            End If
            If Me.m_entity.EquipmentMarkup <> 0 Then
                Dim theNode As New TreeNode(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.EqAdjust}"))
                theNode.Tag = "eqAdj"
                Me.tvMarkup.Nodes.Add(theNode)
            End If

            Me.tvMarkup.ExpandAll()

            ListWBS()

            UpdateTable()

            UpdateAmount()

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Private Sub ListWBS()
            Me.cmbWBS.Items.Clear()
            Me.cmbWBS.Items.Add(Me.StringParserService.Parse("${res:Global.Unspecified}"))
            Dim g As Graphics = Me.CreateGraphics
            Dim w As Single = 10.0!
            Dim ef1 As New SizeF(0.0!, 0.0!)
            For Each myWbs As WBS In Me.m_entity.WBSCollection
                Me.cmbWBS.Items.Add(myWbs)
                ef1 = g.MeasureString(myWbs.ToString, Me.Font)
                If (ef1.Width > w) Then
                    w = ef1.Width
                End If
            Next
            Me.cmbWBS.DropDownWidth = CType(Math.Ceiling(CType(w, Double)), Integer)
            If cmbWBS.Items.Count > 0 Then
                Me.cmbWBS.SelectedIndex = 0
            End If
        End Sub
        Public Sub UpdateAmount()
            Dim base As Decimal = Me.m_entity.TotalAmount
            Dim overhead As Decimal = Me.m_entity.MarkupCollection.GetOverhead
            Me.txtTotalMarkup.Text = Configuration.FormatToString(overhead, DigitConfig.Price)

            Dim distOverhead As Decimal = Me.m_entity.MarkupCollection.GetDistributedOverhead
            Me.txtDistributeMarkup.Text = Configuration.FormatToString(distOverhead, DigitConfig.Price)

            Dim remOverhead As Decimal = Me.m_entity.MarkupCollection.GetUndistributedOverhead
            Me.txtRemainingMarkup.Text = Configuration.FormatToString(remOverhead, DigitConfig.Price)

            Dim profit As Decimal = Me.m_entity.MarkupCollection.GetProfit
            Me.txtTotalProfit.Text = Configuration.FormatToString(profit, DigitConfig.Price)

            Dim distProfit As Decimal = Me.m_entity.MarkupCollection.GetDistributedProfit
            Me.txtDistributedProfit.Text = Configuration.FormatToString(distProfit, DigitConfig.Price)

            Dim remProfit As Decimal = Me.m_entity.MarkupCollection.GetUndistributedProfit
            Me.txtRemainingProfit.Text = Configuration.FormatToString(remProfit, DigitConfig.Price)

            If base <> 0 Then
                Me.txtTotalMarkupPercent.Text = Configuration.FormatToString((overhead / base) * 100, DigitConfig.Price)
                Me.txtDistributeMarkupPercent.Text = Configuration.FormatToString((distOverhead / base) * 100, DigitConfig.Price)
                Me.txtRemainingMarkupPercent.Text = Configuration.FormatToString((remOverhead / base) * 100, DigitConfig.Price)
                Me.txtTotalProfitPercent.Text = Configuration.FormatToString((profit / base) * 100, DigitConfig.Price)
                Me.txtDistributedProfitPercent.Text = Configuration.FormatToString((distProfit / base) * 100, DigitConfig.Price)
                Me.txtRemainingProfitPercent.Text = Configuration.FormatToString((remProfit / base) * 100, DigitConfig.Price)
            Else
                Me.txtTotalMarkupPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
                Me.txtDistributeMarkupPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
                Me.txtRemainingMarkupPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
                Me.txtTotalProfitPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
                Me.txtDistributedProfitPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
                Me.txtRemainingProfitPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
            End If
        End Sub
        Private m_dateSetting As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtdistributedamount"
                    If Not Me.m_markup Is Nothing Then
                        dirtyFlag = True
                    ElseIf Not Me.tvMarkup.SelectedNode Is Nothing Then
                        If Not Me.tvMarkup.SelectedNode.Tag Is Nothing Then
                            Select Case Me.tvMarkup.SelectedNode.Tag.ToString.ToLower
                                Case "matadj"
                                    dirtyFlag = True
                                Case "labadj"
                                    dirtyFlag = True
                                Case "eqadj"
                                    dirtyFlag = True
                            End Select
                        End If
                    End If
                Case "rdall", "rdsearch", "rdselected"
                    If Not Me.m_markup Is Nothing Then
                        If Me.rdAll.Checked Then
                            ToggleSearch(False)
                        ElseIf Me.rdSearch.Checked Then
                            ToggleSearch(True)
                        ElseIf Me.rdSelected.Checked Then
                            ToggleSearch(False)
                        End If
                        UpdateTable()
                        'dirtyFlag = True (ไม่เกี่ยว)
                    ElseIf Not Me.tvMarkup.SelectedNode Is Nothing Then
                        If Not Me.tvMarkup.SelectedNode.Tag Is Nothing Then
                            Select Case Me.tvMarkup.SelectedNode.Tag.ToString.ToLower
                                Case "matadj", "labadj", "eqadj"
                                    If Me.rdAll.Checked Then
                                        ToggleSearch(False)
                                    ElseIf Me.rdSearch.Checked Then
                                        ToggleSearch(True)
                                    ElseIf Me.rdSelected.Checked Then
                                        ToggleSearch(False)
                                    End If
                                    UpdateTable()
                                    'dirtyFlag = True (ไม่เกี่ยว)
                            End Select
                        End If
                    End If
                Case "cmbmethod"
                    If Me.cmbMethod.SelectedItem Is Nothing Then
                        Return
                    End If
                    Dim node As TreeNode = tvMarkup.SelectedNode
                    If node Is Nothing Then
                        Return
                    End If
                    If TypeOf node.Tag Is Markup Then
                        Dim item As IdValuePair = CType(Me.cmbMethod.SelectedItem, IdValuePair)
                        Me.m_markup.DistributionMethod.Value = item.Id
                    ElseIf IsNumeric(node.Tag) Then
                        Return
                    Else
                        Dim item As IdValuePair = CType(Me.cmbMethod.SelectedItem, IdValuePair)
                        Select Case node.Tag.ToString.ToLower
                            Case "matadj"
                                Me.m_entity.MaterialMarkupMethod.Value = item.Id
                            Case "labadj"
                                Me.m_entity.LaborMarkupMethod.Value = item.Id
                            Case "eqadj"
                                Me.m_entity.EquipmentMarkupMethod.Value = item.Id
                        End Select
                    End If
                    UpdateAmount()
                    dirtyFlag = True
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Private Sub ToggleSearch(ByVal search As Boolean)
            Me.grbUseItem.Enabled = search
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not Object.ReferenceEquals(Me.m_entity, Value) Then
                    If Not Me.m_entity Is Nothing Then
                        Me.m_entity.Dispose()
                        Me.m_entity = Nothing
                    End If
                    Me.m_entity = CType(Value, BOQ)
                End If
                'Hack:
                If Not m_entity Is Nothing Then
                    Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                End If
                If Me.WorkbenchWindow.ActiveViewContent Is Me Then
                    UpdateEntityProperties()
                End If
            End Set
        End Property

        Public Overrides Sub Initialize()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbMethod, "markup_dmethod")
        End Sub
        Public Overrides Sub InitProgress()
            If Me.m_entity Is Nothing Then
                Return
            End If
            Dim totalWork As Integer = Me.m_entity.WBSCollection.Count + Me.m_entity.ItemCollection.Count
            Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
            myStatusBarService.ProgressMonitor.BeginTask("${res:MainWindow.StatusBar.LoadingEntity}", totalWork)
        End Sub
        Public Sub WorkDone(ByVal i As Integer)
            Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
            myStatusBarService.ProgressMonitor.Worked(i)
        End Sub
#End Region

#Region "Event Handlers"
        Private AllSelected As Boolean = False
        Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
            If Me.m_treeManager.Treetable.Childs.Count = 0 Then
                Return
            End If
            Dim row As TreeRow = Me.m_treeManager.Treetable.Childs(0)
            If AllSelected Then
                row("Selected") = False
                TreeRow.TraverseRow(row, AddressOf UnCheckRow)
            Else
                row("Selected") = True
                TreeRow.TraverseRow(row, AddressOf CheckRow)
            End If
            AllSelected = Not AllSelected
            '***************ถ้าไม่ AccepChanges จะเพี้ยน*************
            Me.m_treeManager.Treetable.AcceptChanges()
            '******************************************************************************
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            UpdateTable()
        End Sub
        Private Sub tvMarkup_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMarkup.AfterSelect
            AllSelected = False
            m_markup = Nothing
            If TypeOf e.Node.Tag Is Markup Then
                Dim myMarkup As Markup = CType(e.Node.Tag, Markup)
                Me.m_markup = myMarkup
                UpdateMarkup()
            ElseIf IsNumeric(e.Node.Tag) Then
                UpdateType(CInt(e.Node.Tag))
            Else
                Select Case e.Node.Tag.ToString.ToLower
                    Case "matadj", "labadj", "eqadj"
                        UpdateAdj(e.Node.Tag.ToString.ToLower)
                End Select
            End If
            UpdateTable()
        End Sub
        Private Sub UpdateAdj(ByVal type As String)
            Dim name As String = ""
            Dim amt As Decimal = 0
            Dim method As New MarkupDistributionMethod(1)
            Select Case type.ToLower
                Case "matadj"
                    name = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.MatAdjust}")
                    amt = Me.m_entity.MaterialMarkup
                    method = Me.m_entity.MaterialMarkupMethod
                Case "labadj"
                    name = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.LaborAdjust}")
                    amt = Me.m_entity.LaborMarkup
                    method = Me.m_entity.LaborMarkupMethod
                Case "eqadj"
                    name = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.EqAdjust}")
                    amt = Me.m_entity.EquipmentMarkup
                    method = Me.m_entity.EquipmentMarkupMethod
            End Select
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            Me.txtDistributedAmount.ReadOnly = True
            txtMarkupName.Text = name
            Me.txtAmount.Text = Configuration.FormatToString(amt, DigitConfig.Price)
            Me.txtDistributedAmount.Text = Configuration.FormatToString(amt, DigitConfig.Price)
            CodeDescription.ComboSelect(Me.cmbMethod, method)

            Me.rdSelected.PerformClick()
            ToggleSearch(False)

            Me.m_isInitialized = flag
        End Sub
        Private Sub UpdateMarkup()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            txtMarkupName.Text = m_markup.Name
            Me.txtAmount.Text = Configuration.FormatToString(Me.m_markup.TotalAmount, DigitConfig.Price)
            Me.txtDistributedAmount.Text = Configuration.FormatToString(Me.m_markup.DistributedAmount, DigitConfig.Price)
            CodeDescription.ComboSelect(Me.cmbMethod, Me.m_markup.DistributionMethod)

            Me.txtDistributedAmount.ReadOnly = False
            Me.grbView.Enabled = True
            Me.grbUseItem.Enabled = True
            Me.btnSelectAll.Enabled = True
            Me.tgItem.Enabled = True
            Me.rdSelected.PerformClick()
            ToggleSearch(False)

            Me.m_isInitialized = flag
        End Sub
        Private Sub UpdateTable()
            Me.m_tableInitialized = False
            InitProgress()
            If Me.m_markup Is Nothing Then
                If Me.tvMarkup.SelectedNode Is Nothing Then
                    Me.m_treeManager.ClearTable()
                    Me.m_tableInitialized = True
                Else
                    Select Case Me.tvMarkup.SelectedNode.Tag.ToString.ToLower
                        Case "matadj"
                            If Me.rdSelected.Checked Then
                                Me.m_entity.PopulateItemListing(m_treeManager, m_entity.MaterialMarkupItems, AddressOf WorkDone)
                                Me.tgItem.RefreshHeights()
                            ElseIf Me.rdAll.Checked Then
                                Me.m_entity.PopulateItemListing(m_treeManager, m_entity.MaterialMarkupItems, True, AddressOf WorkDone)
                                Me.tgItem.RefreshHeights()
                            ElseIf Me.rdSearch.Checked Then
                                Me.m_entity.PopulateItemListing(m_treeManager, GetFilterArray, m_entity.MaterialMarkupItems, AddressOf WorkDone)
                                Me.tgItem.RefreshHeights()
                            End If
                        Case "labadj"
                            If Me.rdSelected.Checked Then
                                Me.m_entity.PopulateItemListing(m_treeManager, m_entity.LaborMarkupItems, AddressOf WorkDone)
                                Me.tgItem.RefreshHeights()
                            ElseIf Me.rdAll.Checked Then
                                Me.m_entity.PopulateItemListing(m_treeManager, m_entity.LaborMarkupItems, True, AddressOf WorkDone)
                                Me.tgItem.RefreshHeights()
                            ElseIf Me.rdSearch.Checked Then
                                Me.m_entity.PopulateItemListing(m_treeManager, GetFilterArray, m_entity.LaborMarkupItems, AddressOf WorkDone)
                                Me.tgItem.RefreshHeights()
                            End If
                        Case "eqadj"
                            If Me.rdSelected.Checked Then
                                Me.m_entity.PopulateItemListing(m_treeManager, m_entity.EquipmentMarkupItems, AddressOf WorkDone)
                                Me.tgItem.RefreshHeights()
                            ElseIf Me.rdAll.Checked Then
                                Me.m_entity.PopulateItemListing(m_treeManager, m_entity.EquipmentMarkupItems, True, AddressOf WorkDone)
                                Me.tgItem.RefreshHeights()
                            ElseIf Me.rdSearch.Checked Then
                                Me.m_entity.PopulateItemListing(m_treeManager, GetFilterArray, m_entity.EquipmentMarkupItems, AddressOf WorkDone)
                                Me.tgItem.RefreshHeights()
                            End If
                        Case Else
                            Me.m_treeManager.ClearTable()
                            Me.tgItem.RefreshHeights()
                    End Select
                    Me.m_tableInitialized = True
                End If
                EndProgress()
            Else
                If Me.tvMarkup.SelectedNode Is Nothing Then
                    Me.m_treeManager.ClearTable()
                ElseIf Me.rdSelected.Checked Then
                    Me.m_entity.PopulateItemListing(m_treeManager, m_markup.DistributedItems, AddressOf WorkDone)
                    Me.tgItem.RefreshHeights()
                ElseIf Me.rdAll.Checked Then
                    Me.m_entity.PopulateItemListing(m_treeManager, m_markup.DistributedItems, True, AddressOf WorkDone)
                    Me.tgItem.RefreshHeights()
                ElseIf Me.rdSearch.Checked Then
                    Me.m_entity.PopulateItemListing(m_treeManager, GetFilterArray, m_markup.DistributedItems, AddressOf WorkDone)
                    Me.tgItem.RefreshHeights()
                End If
                EndProgress()
                Me.m_tableInitialized = True
            End If
        End Sub
        Public Function GetFilterArray() As Filter()
            Dim ValueFrom As Object = DBNull.Value
            Dim ValueTo As Object = DBNull.Value
            Dim ContainName As Object = DBNull.Value
            Dim UnderWBS As Object = DBNull.Value

            If Me.txtFrom.TextLength = 0 Then
                ValueFrom = DBNull.Value
            Else
                Try
                    ValueFrom = CDec(TextParser.Evaluate(Me.txtFrom.Text))
                Catch ex As Exception
                    ValueFrom = DBNull.Value
                End Try
            End If

            If Me.txtTo.TextLength = 0 Then
                ValueTo = DBNull.Value
            Else
                Try
                    ValueTo = CDec(TextParser.Evaluate(Me.txtTo.Text))
                Catch ex As Exception
                    ValueTo = DBNull.Value
                End Try
            End If

            If Me.txtName.TextLength = 0 Then
                ContainName = DBNull.Value
            Else
                ContainName = Me.txtName.Text
            End If

            If Me.cmbWBS.SelectedItem Is Nothing Then
                UnderWBS = DBNull.Value
            Else
                If TypeOf Me.cmbWBS.SelectedItem Is WBS Then
                    UnderWBS = Me.cmbWBS.SelectedItem
                End If
            End If

            Dim arr(3) As Filter
            arr(0) = New Filter("ValueFrom", ValueFrom)
            arr(1) = New Filter("ValueTo", ValueTo)
            arr(2) = New Filter("ContainName", ContainName)
            arr(3) = New Filter("UnderWBS", UnderWBS)
            Return arr
        End Function
        Private Sub UpdateType(ByVal id As Integer)
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            Dim mt As New MarkupType(id)
            txtMarkupName.Text = mt.Description
            Me.cmbMethod.SelectedIndex = -1
            Me.txtAmount.Text = Configuration.FormatToString(Me.m_entity.MarkupCollection.GetAmountForType(id), DigitConfig.Price)
            Me.txtDistributedAmount.Text = Configuration.FormatToString(Me.m_entity.MarkupCollection.GetDistributedAmountForType(id), DigitConfig.Price)

            Me.txtDistributedAmount.ReadOnly = True
            Me.grbView.Enabled = False
            Me.grbUseItem.Enabled = False
            Me.btnSelectAll.Enabled = False
            Me.tgItem.Enabled = False
            Me.m_isInitialized = flag
        End Sub
        Private Sub UpdateNode()
            Me.tvMarkup.SelectedNode.Text = m_markup.ToString
        End Sub
        Private Sub ClearMarkup()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            txtMarkupName.Text = ""
            Me.m_isInitialized = flag
        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Event of Button controls"
        ' Requestor
        Private Sub ibtnShowEstimator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub ibtnShowEstimatorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeDialog)
        End Sub

        Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
            'Me.txtEstimatorCode.Text = e.Code
            'Me.WorkbenchWindow.ViewContent.IsDirty = _
            '    Me.WorkbenchWindow.ViewContent.IsDirty _
            '    Or Employee.GetEmployee(txtEstimatorCode, txtEstimatorName, Me.m_entity.Estimator)
        End Sub

#End Region

#Region "IClipboardHandler Overrides"
#End Region

#Region "After the main entity has been saved"
        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            If Not successful Then
                Return
            End If
            Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
#End Region

    End Class
End Namespace
