Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MatReturnFilterSubPanel
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
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ibtnShowLCIDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowLCI As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblLCI As System.Windows.Forms.Label
        Friend WithEvents txtLCI As System.Windows.Forms.TextBox
        Friend WithEvents txtLCIName As System.Windows.Forms.TextBox
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtToCCPersonCode As System.Windows.Forms.TextBox
        Friend WithEvents btnToCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents txtToCCPersonName As System.Windows.Forms.TextBox
        Friend WithEvents lblToCCPerson As System.Windows.Forms.Label
        Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnToCCPersonPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lbltoCC As System.Windows.Forms.Label
        Friend WithEvents btnToCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnFromCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
        Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
        Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnFromCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnFromCCPersonPanel As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
        Friend WithEvents ibtnFromCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MatReturnFilterSubPanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnShowLCIDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowLCI = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblLCI = New System.Windows.Forms.Label
            Me.txtLCI = New System.Windows.Forms.TextBox
            Me.txtLCIName = New System.Windows.Forms.TextBox
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox
            Me.ibtnFromCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox
            Me.txtFromCCPersonName = New System.Windows.Forms.TextBox
            Me.lblFromCCPerson = New System.Windows.Forms.Label
            Me.txtFromCostCenterName = New System.Windows.Forms.TextBox
            Me.ibtnFromCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnFromCCPersonPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblFromCostCenter = New System.Windows.Forms.Label
            Me.ibtnFromCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtToCCPersonCode = New System.Windows.Forms.TextBox
            Me.btnToCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtToCostCenterCode = New System.Windows.Forms.TextBox
            Me.txtToCCPersonName = New System.Windows.Forms.TextBox
            Me.lblToCCPerson = New System.Windows.Forms.Label
            Me.txtToCostCenterName = New System.Windows.Forms.TextBox
            Me.btnToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnToCCPersonPanel = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lbltoCC = New System.Windows.Forms.Label
            Me.btnToCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.grbItem.SuspendLayout()
            Me.grbMainDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(144, 18)
            Me.lblCode.TabIndex = 6
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCode.Location = New System.Drawing.Point(160, 16)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(224, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.grbItem)
            Me.grbDetail.Controls.Add(Me.grbMainDetail)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(728, 176)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(408, 64)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(240, 72)
            Me.grbDocDate.TabIndex = 2
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "วันที่เอกสาร"
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 17)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(72, 18)
            Me.lblDocDateStart.TabIndex = 11
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 41)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(72, 18)
            Me.lblDocDateEnd.TabIndex = 11
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(96, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
            Me.dtpDocDateStart.TabIndex = 0
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(96, 40)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
            Me.dtpDocDateEnd.TabIndex = 1
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(648, 144)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 1
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(568, 144)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 0
            Me.btnReset.Text = "Reset"
            '
            'grbItem
            '
            Me.grbItem.Controls.Add(Me.ibtnShowLCIDialog)
            Me.grbItem.Controls.Add(Me.ibtnShowLCI)
            Me.grbItem.Controls.Add(Me.lblLCI)
            Me.grbItem.Controls.Add(Me.txtLCI)
            Me.grbItem.Controls.Add(Me.txtLCIName)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(408, 16)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(312, 48)
            Me.grbItem.TabIndex = 1
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "ของที่คืน"
            '
            'ibtnShowLCIDialog
            '
            Me.ibtnShowLCIDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowLCIDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowLCIDialog.Image = CType(resources.GetObject("ibtnShowLCIDialog.Image"), System.Drawing.Image)
            Me.ibtnShowLCIDialog.Location = New System.Drawing.Point(256, 16)
            Me.ibtnShowLCIDialog.Name = "ibtnShowLCIDialog"
            Me.ibtnShowLCIDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowLCIDialog.TabIndex = 206
            Me.ibtnShowLCIDialog.TabStop = False
            Me.ibtnShowLCIDialog.ThemedImage = CType(resources.GetObject("ibtnShowLCIDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowLCI
            '
            Me.ibtnShowLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowLCI.Image = CType(resources.GetObject("ibtnShowLCI.Image"), System.Drawing.Image)
            Me.ibtnShowLCI.Location = New System.Drawing.Point(280, 16)
            Me.ibtnShowLCI.Name = "ibtnShowLCI"
            Me.ibtnShowLCI.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowLCI.TabIndex = 205
            Me.ibtnShowLCI.TabStop = False
            Me.ibtnShowLCI.ThemedImage = CType(resources.GetObject("ibtnShowLCI.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblLCI
            '
            Me.lblLCI.BackColor = System.Drawing.Color.Transparent
            Me.lblLCI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLCI.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblLCI.Location = New System.Drawing.Point(8, 16)
            Me.lblLCI.Name = "lblLCI"
            Me.lblLCI.Size = New System.Drawing.Size(64, 18)
            Me.lblLCI.TabIndex = 203
            Me.lblLCI.Text = "LCI:"
            Me.lblLCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLCI
            '
            Me.txtLCI.Location = New System.Drawing.Point(80, 16)
            Me.txtLCI.Name = "txtLCI"
            Me.txtLCI.Size = New System.Drawing.Size(80, 20)
            Me.txtLCI.TabIndex = 0
            Me.txtLCI.Text = ""
            '
            'txtLCIName
            '
            Me.txtLCIName.Location = New System.Drawing.Point(160, 16)
            Me.txtLCIName.Name = "txtLCIName"
            Me.txtLCIName.ReadOnly = True
            Me.txtLCIName.Size = New System.Drawing.Size(96, 20)
            Me.txtLCIName.TabIndex = 204
            Me.txtLCIName.TabStop = False
            Me.txtLCIName.Text = ""
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.txtFromCCPersonCode)
            Me.grbMainDetail.Controls.Add(Me.ibtnFromCostCenterPanel)
            Me.grbMainDetail.Controls.Add(Me.txtFromCostCenterCode)
            Me.grbMainDetail.Controls.Add(Me.txtFromCCPersonName)
            Me.grbMainDetail.Controls.Add(Me.lblFromCCPerson)
            Me.grbMainDetail.Controls.Add(Me.txtFromCostCenterName)
            Me.grbMainDetail.Controls.Add(Me.ibtnFromCostCenterDialog)
            Me.grbMainDetail.Controls.Add(Me.ibtnFromCCPersonPanel)
            Me.grbMainDetail.Controls.Add(Me.lblFromCostCenter)
            Me.grbMainDetail.Controls.Add(Me.ibtnFromCCPersonDialog)
            Me.grbMainDetail.Controls.Add(Me.txtToCCPersonCode)
            Me.grbMainDetail.Controls.Add(Me.btnToCostCenterPanel)
            Me.grbMainDetail.Controls.Add(Me.txtToCostCenterCode)
            Me.grbMainDetail.Controls.Add(Me.txtToCCPersonName)
            Me.grbMainDetail.Controls.Add(Me.txtCode)
            Me.grbMainDetail.Controls.Add(Me.lblToCCPerson)
            Me.grbMainDetail.Controls.Add(Me.txtToCostCenterName)
            Me.grbMainDetail.Controls.Add(Me.lblCode)
            Me.grbMainDetail.Controls.Add(Me.btnToCostCenterDialog)
            Me.grbMainDetail.Controls.Add(Me.btnToCCPersonPanel)
            Me.grbMainDetail.Controls.Add(Me.lbltoCC)
            Me.grbMainDetail.Controls.Add(Me.btnToCCPersonDialog)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(392, 144)
            Me.grbMainDetail.TabIndex = 0
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
            '
            'txtFromCCPersonCode
            '
            Me.txtFromCCPersonCode.Location = New System.Drawing.Point(160, 88)
            Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
            Me.txtFromCCPersonCode.Size = New System.Drawing.Size(80, 20)
            Me.txtFromCCPersonCode.TabIndex = 3
            Me.txtFromCCPersonCode.Text = ""
            '
            'ibtnFromCostCenterPanel
            '
            Me.ibtnFromCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnFromCostCenterPanel.Image = CType(resources.GetObject("ibtnFromCostCenterPanel.Image"), System.Drawing.Image)
            Me.ibtnFromCostCenterPanel.Location = New System.Drawing.Point(360, 112)
            Me.ibtnFromCostCenterPanel.Name = "ibtnFromCostCenterPanel"
            Me.ibtnFromCostCenterPanel.Size = New System.Drawing.Size(24, 23)
            Me.ibtnFromCostCenterPanel.TabIndex = 209
            Me.ibtnFromCostCenterPanel.TabStop = False
            Me.ibtnFromCostCenterPanel.ThemedImage = CType(resources.GetObject("ibtnFromCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtFromCostCenterCode
            '
            Me.txtFromCostCenterCode.Location = New System.Drawing.Point(160, 112)
            Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
            Me.txtFromCostCenterCode.Size = New System.Drawing.Size(80, 20)
            Me.txtFromCostCenterCode.TabIndex = 4
            Me.txtFromCostCenterCode.Text = ""
            '
            'txtFromCCPersonName
            '
            Me.txtFromCCPersonName.Location = New System.Drawing.Point(240, 88)
            Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
            Me.txtFromCCPersonName.ReadOnly = True
            Me.txtFromCCPersonName.Size = New System.Drawing.Size(96, 20)
            Me.txtFromCCPersonName.TabIndex = 208
            Me.txtFromCCPersonName.TabStop = False
            Me.txtFromCCPersonName.Text = ""
            '
            'lblFromCCPerson
            '
            Me.lblFromCCPerson.BackColor = System.Drawing.Color.Transparent
            Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFromCCPerson.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblFromCCPerson.Location = New System.Drawing.Point(8, 88)
            Me.lblFromCCPerson.Name = "lblFromCCPerson"
            Me.lblFromCCPerson.Size = New System.Drawing.Size(144, 18)
            Me.lblFromCCPerson.TabIndex = 205
            Me.lblFromCCPerson.Text = "ผู้คืน:"
            Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtFromCostCenterName
            '
            Me.txtFromCostCenterName.Location = New System.Drawing.Point(240, 112)
            Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
            Me.txtFromCostCenterName.ReadOnly = True
            Me.txtFromCostCenterName.Size = New System.Drawing.Size(96, 20)
            Me.txtFromCostCenterName.TabIndex = 207
            Me.txtFromCostCenterName.TabStop = False
            Me.txtFromCostCenterName.Text = ""
            '
            'ibtnFromCostCenterDialog
            '
            Me.ibtnFromCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnFromCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnFromCostCenterDialog.Image = CType(resources.GetObject("ibtnFromCostCenterDialog.Image"), System.Drawing.Image)
            Me.ibtnFromCostCenterDialog.Location = New System.Drawing.Point(336, 112)
            Me.ibtnFromCostCenterDialog.Name = "ibtnFromCostCenterDialog"
            Me.ibtnFromCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnFromCostCenterDialog.TabIndex = 211
            Me.ibtnFromCostCenterDialog.TabStop = False
            Me.ibtnFromCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnFromCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnFromCCPersonPanel
            '
            Me.ibtnFromCCPersonPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnFromCCPersonPanel.Image = CType(resources.GetObject("ibtnFromCCPersonPanel.Image"), System.Drawing.Image)
            Me.ibtnFromCCPersonPanel.Location = New System.Drawing.Point(360, 88)
            Me.ibtnFromCCPersonPanel.Name = "ibtnFromCCPersonPanel"
            Me.ibtnFromCCPersonPanel.Size = New System.Drawing.Size(24, 23)
            Me.ibtnFromCCPersonPanel.TabIndex = 210
            Me.ibtnFromCCPersonPanel.TabStop = False
            Me.ibtnFromCCPersonPanel.ThemedImage = CType(resources.GetObject("ibtnFromCCPersonPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblFromCostCenter
            '
            Me.lblFromCostCenter.BackColor = System.Drawing.Color.Transparent
            Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFromCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblFromCostCenter.Location = New System.Drawing.Point(0, 112)
            Me.lblFromCostCenter.Name = "lblFromCostCenter"
            Me.lblFromCostCenter.Size = New System.Drawing.Size(152, 18)
            Me.lblFromCostCenter.TabIndex = 206
            Me.lblFromCostCenter.Text = "คืนจาก Cost Center:"
            Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnFromCCPersonDialog
            '
            Me.ibtnFromCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnFromCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnFromCCPersonDialog.Image = CType(resources.GetObject("ibtnFromCCPersonDialog.Image"), System.Drawing.Image)
            Me.ibtnFromCCPersonDialog.Location = New System.Drawing.Point(336, 88)
            Me.ibtnFromCCPersonDialog.Name = "ibtnFromCCPersonDialog"
            Me.ibtnFromCCPersonDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnFromCCPersonDialog.TabIndex = 212
            Me.ibtnFromCCPersonDialog.TabStop = False
            Me.ibtnFromCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnFromCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtToCCPersonCode
            '
            Me.txtToCCPersonCode.Location = New System.Drawing.Point(160, 40)
            Me.txtToCCPersonCode.Name = "txtToCCPersonCode"
            Me.txtToCCPersonCode.Size = New System.Drawing.Size(80, 20)
            Me.txtToCCPersonCode.TabIndex = 1
            Me.txtToCCPersonCode.Text = ""
            '
            'btnToCostCenterPanel
            '
            Me.btnToCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCostCenterPanel.Image = CType(resources.GetObject("btnToCostCenterPanel.Image"), System.Drawing.Image)
            Me.btnToCostCenterPanel.Location = New System.Drawing.Point(360, 64)
            Me.btnToCostCenterPanel.Name = "btnToCostCenterPanel"
            Me.btnToCostCenterPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnToCostCenterPanel.TabIndex = 199
            Me.btnToCostCenterPanel.TabStop = False
            Me.btnToCostCenterPanel.ThemedImage = CType(resources.GetObject("btnToCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtToCostCenterCode
            '
            Me.txtToCostCenterCode.Location = New System.Drawing.Point(160, 64)
            Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
            Me.txtToCostCenterCode.Size = New System.Drawing.Size(80, 20)
            Me.txtToCostCenterCode.TabIndex = 2
            Me.txtToCostCenterCode.Text = ""
            '
            'txtToCCPersonName
            '
            Me.txtToCCPersonName.Location = New System.Drawing.Point(240, 40)
            Me.txtToCCPersonName.Name = "txtToCCPersonName"
            Me.txtToCCPersonName.ReadOnly = True
            Me.txtToCCPersonName.Size = New System.Drawing.Size(96, 20)
            Me.txtToCCPersonName.TabIndex = 196
            Me.txtToCCPersonName.TabStop = False
            Me.txtToCCPersonName.Text = ""
            '
            'lblToCCPerson
            '
            Me.lblToCCPerson.BackColor = System.Drawing.Color.Transparent
            Me.lblToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToCCPerson.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblToCCPerson.Location = New System.Drawing.Point(8, 40)
            Me.lblToCCPerson.Name = "lblToCCPerson"
            Me.lblToCCPerson.Size = New System.Drawing.Size(144, 18)
            Me.lblToCCPerson.TabIndex = 191
            Me.lblToCCPerson.Text = "ผู้รับคืน:"
            Me.lblToCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtToCostCenterName
            '
            Me.txtToCostCenterName.Location = New System.Drawing.Point(240, 64)
            Me.txtToCostCenterName.Name = "txtToCostCenterName"
            Me.txtToCostCenterName.ReadOnly = True
            Me.txtToCostCenterName.Size = New System.Drawing.Size(96, 20)
            Me.txtToCostCenterName.TabIndex = 196
            Me.txtToCostCenterName.TabStop = False
            Me.txtToCostCenterName.Text = ""
            '
            'btnToCostCenterDialog
            '
            Me.btnToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnToCostCenterDialog.Image = CType(resources.GetObject("btnToCostCenterDialog.Image"), System.Drawing.Image)
            Me.btnToCostCenterDialog.Location = New System.Drawing.Point(336, 64)
            Me.btnToCostCenterDialog.Name = "btnToCostCenterDialog"
            Me.btnToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnToCostCenterDialog.TabIndex = 201
            Me.btnToCostCenterDialog.TabStop = False
            Me.btnToCostCenterDialog.ThemedImage = CType(resources.GetObject("btnToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnToCCPersonPanel
            '
            Me.btnToCCPersonPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCCPersonPanel.Image = CType(resources.GetObject("btnToCCPersonPanel.Image"), System.Drawing.Image)
            Me.btnToCCPersonPanel.Location = New System.Drawing.Point(360, 40)
            Me.btnToCCPersonPanel.Name = "btnToCCPersonPanel"
            Me.btnToCCPersonPanel.Size = New System.Drawing.Size(24, 23)
            Me.btnToCCPersonPanel.TabIndex = 200
            Me.btnToCCPersonPanel.TabStop = False
            Me.btnToCCPersonPanel.ThemedImage = CType(resources.GetObject("btnToCCPersonPanel.ThemedImage"), System.Drawing.Bitmap)
            '
            'lbltoCC
            '
            Me.lbltoCC.BackColor = System.Drawing.Color.Transparent
            Me.lbltoCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lbltoCC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lbltoCC.Location = New System.Drawing.Point(8, 64)
            Me.lbltoCC.Name = "lbltoCC"
            Me.lbltoCC.Size = New System.Drawing.Size(144, 18)
            Me.lbltoCC.TabIndex = 192
            Me.lbltoCC.Text = "คืนเข้า Cost Center:"
            Me.lbltoCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnToCCPersonDialog
            '
            Me.btnToCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnToCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.btnToCCPersonDialog.Image = CType(resources.GetObject("btnToCCPersonDialog.Image"), System.Drawing.Image)
            Me.btnToCCPersonDialog.Location = New System.Drawing.Point(336, 40)
            Me.btnToCCPersonDialog.Name = "btnToCCPersonDialog"
            Me.btnToCCPersonDialog.Size = New System.Drawing.Size(24, 23)
            Me.btnToCCPersonDialog.TabIndex = 202
            Me.btnToCCPersonDialog.TabStop = False
            Me.btnToCCPersonDialog.ThemedImage = CType(resources.GetObject("btnToCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'MatReturnFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "MatReturnFilterSubPanel"
            Me.Size = New System.Drawing.Size(744, 192)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.grbItem.ResumeLayout(False)
            Me.grbMainDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()
            Me.LoopControl(Me)
        End Sub
#End Region

#Region "Members"
        Private m_toCCPerson As Employee
        Private m_toCC As CostCenter
        Private m_fromCCPerson As Employee
        Private m_fromCC As CostCenter
        Private m_lci As LCIItem
#End Region

#Region "Methods"
        Public Sub Initialize()
            'PopulateStatus()
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""

            Me.txtFromCCPersonCode.Text = ""
            Me.txtFromCCPersonName.Text = ""
            Me.m_fromCCPerson = New Employee

            Me.txtFromCostCenterCode.Text = ""
            Me.txtFromCostCenterName.Text = ""
            Me.m_fromCC = New CostCenter

            Me.txtToCCPersonCode.Text = ""
            Me.txtToCCPersonName.Text = ""
            Me.m_toCCPerson = New Employee

            Me.txtToCostCenterCode.Text = ""
            Me.txtToCostCenterName.Text = ""
            Me.m_toCC = New CostCenter

            Me.txtLCI.Text = ""
            Me.txtLCIName.Text = ""
            Me.m_lci = New LCIItem

            Me.dtpDocDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.dtpDocDateEnd.Value = Now.Date
        End Sub
        Private Sub PopulateStatus()
            'Dim dt As DataTable = CodeDescription.GetCodeList("mattransfer_status")
            'Me.cmbStatus.DataSource = dt
            'Me.cmbStatus.DisplayMember = "code_description"
            'Me.cmbStatus.ValueMember = "code_value"
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.grbDocDate}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.lblDocDateEnd}")
            'Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.lblStatus}")
            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.grbItem}")
            Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.lblLCI}")
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.grbMainDetail}")
            Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.lblToCCPerson}")
            Me.lbltoCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.lbltoCC}")
            Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.lblFromCCPerson}")
            Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatReturnFilterSubPanel.lblFromCostCenter}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(8) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("toccperson", IIf(Me.m_toCCPerson.Originated, Me.m_toCCPerson.Id, DBNull.Value))
            arr(2) = New Filter("tocc", IIf(Me.m_toCC.Originated, Me.m_toCC.Id, DBNull.Value))
            arr(3) = New Filter("docdatestart", Me.dtpDocDateStart.Value.Date)
            arr(4) = New Filter("fromccperson", IIf(Me.m_fromCCPerson.Originated, Me.m_fromCCPerson.Id, DBNull.Value))
            arr(5) = New Filter("fromcc", IIf(Me.m_fromCC.Valid, Me.m_fromCC.Id, DBNull.Value))
            arr(6) = New Filter("docdateend", Me.dtpDocDateEnd.Value.Date)
            arr(7) = New Filter("lci_id", IIf(Me.m_lci.Valid, Me.m_lci.Id, DBNull.Value))
            arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"

        Private Sub txtToCCPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToCCPersonCode.Validated
            Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_toCCPerson)
        End Sub
        Private Sub btnToCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCCPersonDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToCCPerson)
        End Sub
        Private Sub btnToCCPersonPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCCPersonPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub SetToCCPerson(ByVal e As ISimpleEntity)
            Me.txtToCCPersonCode.Text = e.Code
            Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_toCCPerson)
        End Sub

        Private Sub txtFromCCPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromCCPersonCode.Validated
            Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_fromCCPerson)
        End Sub
        Private Sub btnFromCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnFromCCPersonDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetFromCCPerson)
        End Sub
        Private Sub btnFromCCPersonPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnFromCCPersonPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub SetFromCCPerson(ByVal e As ISimpleEntity)
            Me.txtFromCCPersonCode.Text = e.Code
            Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_fromCCPerson)
        End Sub

        Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToCostCenterCode.Validated
            CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_toCC, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub btnToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter)
        End Sub
        Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
            Me.txtToCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtToCostCenterCode, txtToCostCenterName, Me.m_toCC, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub btnToCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToCostCenterPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub

        Private Sub txtFromCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromCostCenterCode.Validated
            CostCenter.GetCostCenterWithoutRight(txtFromCostCenterCode, txtFromCostCenterName, Me.m_fromCC)
        End Sub
        Private Sub btnFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnFromCostCenterDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCostCenter, New Filter() {New Filter("checkright", False)})
        End Sub
        Private Sub SetFromCostCenter(ByVal e As ISimpleEntity)
            Me.txtFromCostCenterCode.Text = e.Code
            CostCenter.GetCostCenterWithoutRight(txtFromCostCenterCode, txtFromCostCenterName, Me.m_fromCC)
        End Sub
        Private Sub btnFromCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnFromCostCenterPanel.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub

        Private Sub ibtnShowLCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowLCI.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New LCIItem)
        End Sub
        Private Sub txtLCI_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLCI.Validated
            LCIItem.GetLCIItem(txtLCI, txtLCIName, Me.m_lci)
        End Sub
        Private Sub SetLCi(ByVal e As ISimpleEntity)
            Me.txtLCI.Text = e.Code
            LCIItem.GetLCIItem(txtLCI, txtLCIName, Me.m_lci)
        End Sub
        Private Sub ibtnShowLCIDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowLCIDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCi)
        End Sub


        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub


#End Region

#Region "IClipboardHandler Overrides" 'Undone
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject

                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txttocostcentercode", "txttocostcentername", "txtfromcostcentercode", "txtfromcostcentername"
                            Return True
                    End Select
                End If
                If data.GetDataPresent((New Employee).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtfromccpersoncode", "txtfromccpersonname", "txttoccpersoncode", "txttoccpersoncode"
                            Return True
                    End Select
                End If
                If data.GetDataPresent((New LCIItem).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtlci", "txtlciname"
                            Return True
                    End Select
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.ActiveControl Is Nothing Then
                Return
            End If
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txttocostcentercode", "txttocostcentername"
                        Me.SetToCostCenter(entity)
                    Case "txtfromcostcentercode", "txtfromcostcentername"
                        Me.SetFromCostCenter(entity)
                End Select
            End If
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txttoccpersoncode", "txttoccpersonname"
                        Me.SetToCCPerson(entity)
                    Case "txtfromccpersoncode", "txtfromccpersoncode"
                        Me.SetFromCCPerson(entity)
                End Select
            End If
            If data.GetDataPresent((New LCIItem).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New LCIItem).FullClassName))
                Dim entity As New LCIItem(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtlci", "txtlciname"
                        Me.SetLCi(entity)
                End Select
            End If
        End Sub
#End Region

    End Class
End Namespace

