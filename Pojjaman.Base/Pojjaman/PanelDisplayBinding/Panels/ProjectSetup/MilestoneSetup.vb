Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Reporting
Imports System.Drawing.Printing
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MilestoneSetup
        Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

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
        Friend WithEvents ListView1 As System.Windows.Forms.ListView
        Friend WithEvents TreeGrid2 As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
        Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblProject As System.Windows.Forms.Label
        Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
        Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblInc As System.Windows.Forms.Label
        Friend WithEvents lblContact As System.Windows.Forms.Label
        Friend WithEvents txtContact As System.Windows.Forms.TextBox
        Friend WithEvents txtInc As System.Windows.Forms.TextBox
        Friend WithEvents lblBaht As System.Windows.Forms.Label
        Friend WithEvents lblBaht2 As System.Windows.Forms.Label
        Friend WithEvents lblDec As System.Windows.Forms.Label
        Friend WithEvents txtDec As System.Windows.Forms.TextBox
        Friend WithEvents lblBaht4 As System.Windows.Forms.Label
        Friend WithEvents lblBaht1 As System.Windows.Forms.Label
        Friend WithEvents lblTotal As System.Windows.Forms.Label
        Friend WithEvents txtTotal As System.Windows.Forms.TextBox
        Friend WithEvents lblBaht3 As System.Windows.Forms.Label
        Friend WithEvents btnRetention As System.Windows.Forms.Button
        Friend WithEvents btnAdvance As System.Windows.Forms.Button
        Friend WithEvents btnInstalment As System.Windows.Forms.Button
        Friend WithEvents btnInc As System.Windows.Forms.Button
        Friend WithEvents btnDec As System.Windows.Forms.Button
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents lblPenalty As System.Windows.Forms.Label
        Friend WithEvents ibtnShowDefaultUnitDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowReturnPerson As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton2 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents txtProjectCodeName As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtPenalty As System.Windows.Forms.TextBox
        Friend WithEvents btnPenalty As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MilestoneSetup))
            Me.ListView1 = New System.Windows.Forms.ListView
            Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
            Me.TreeGrid2 = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtCustomer = New System.Windows.Forms.TextBox
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.lblProject = New System.Windows.Forms.Label
            Me.txtProjectCode = New System.Windows.Forms.TextBox
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.txtProjectCodeName = New System.Windows.Forms.TextBox
            Me.lblInc = New System.Windows.Forms.Label
            Me.lblContact = New System.Windows.Forms.Label
            Me.txtContact = New System.Windows.Forms.TextBox
            Me.txtInc = New System.Windows.Forms.TextBox
            Me.lblBaht = New System.Windows.Forms.Label
            Me.lblBaht2 = New System.Windows.Forms.Label
            Me.lblDec = New System.Windows.Forms.Label
            Me.txtDec = New System.Windows.Forms.TextBox
            Me.lblBaht4 = New System.Windows.Forms.Label
            Me.lblPenalty = New System.Windows.Forms.Label
            Me.txtPenalty = New System.Windows.Forms.TextBox
            Me.lblBaht1 = New System.Windows.Forms.Label
            Me.lblTotal = New System.Windows.Forms.Label
            Me.txtTotal = New System.Windows.Forms.TextBox
            Me.lblBaht3 = New System.Windows.Forms.Label
            Me.btnRetention = New System.Windows.Forms.Button
            Me.btnPenalty = New System.Windows.Forms.Button
            Me.btnAdvance = New System.Windows.Forms.Button
            Me.btnInstalment = New System.Windows.Forms.Button
            Me.btnInc = New System.Windows.Forms.Button
            Me.btnDec = New System.Windows.Forms.Button
            Me.btnPrint = New System.Windows.Forms.Button
            Me.ibtnShowDefaultUnitDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowReturnPerson = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton1 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton2 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            CType(Me.TreeGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'ListView1
            '
            Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader3, Me.ColumnHeader2, Me.ColumnHeader1, Me.ColumnHeader11})
            Me.ListView1.Location = New System.Drawing.Point(16, 200)
            Me.ListView1.Name = "ListView1"
            Me.ListView1.Size = New System.Drawing.Size(640, 112)
            Me.ListView1.TabIndex = 192
            Me.ListView1.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader7
            '
            Me.ColumnHeader7.Text = "No."
            Me.ColumnHeader7.Width = 30
            '
            'ColumnHeader8
            '
            Me.ColumnHeader8.Text = "รหัสงวด"
            Me.ColumnHeader8.Width = 57
            '
            'ColumnHeader9
            '
            Me.ColumnHeader9.Text = "ชื่องวด"
            Me.ColumnHeader9.Width = 127
            '
            'ColumnHeader10
            '
            Me.ColumnHeader10.Text = "มูลค่างวดตามสัญญา"
            Me.ColumnHeader10.Width = 113
            '
            'ColumnHeader3
            '
            Me.ColumnHeader3.Text = "%มูลค่าสัญญา"
            Me.ColumnHeader3.Width = 81
            '
            'ColumnHeader2
            '
            Me.ColumnHeader2.Text = "กำหนดส่งงาน"
            Me.ColumnHeader2.Width = 81
            '
            'ColumnHeader1
            '
            Me.ColumnHeader1.Text = "กำหนดเบิก"
            Me.ColumnHeader1.Width = 75
            '
            'ColumnHeader11
            '
            Me.ColumnHeader11.Text = "หมายเหตุ"
            Me.ColumnHeader11.Width = 72
            '
            'TreeGrid2
            '
            Me.TreeGrid2.AllowNew = True
            Me.TreeGrid2.AllowSorting = False
            Me.TreeGrid2.CaptionVisible = False
            Me.TreeGrid2.Cellchanged = False
            Me.TreeGrid2.DataMember = ""
            Me.TreeGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.TreeGrid2.Location = New System.Drawing.Point(0, 152)
            Me.TreeGrid2.Name = "TreeGrid2"
            Me.TreeGrid2.Size = New System.Drawing.Size(664, 264)
            Me.TreeGrid2.SortingArrowColor = System.Drawing.Color.Red
            Me.TreeGrid2.TabIndex = 194
            Me.TreeGrid2.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(8, 136)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(120, 18)
            Me.lblItem.TabIndex = 193
            Me.lblItem.Text = "รายการรับเงินงวด:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.ImageButton1)
            Me.grbDetail.Controls.Add(Me.ImageButton2)
            Me.grbDetail.Controls.Add(Me.ibtnShowDefaultUnitDialog)
            Me.grbDetail.Controls.Add(Me.ibtnShowReturnPerson)
            Me.grbDetail.Controls.Add(Me.txtCustomer)
            Me.grbDetail.Controls.Add(Me.lblCustomer)
            Me.grbDetail.Controls.Add(Me.lblProject)
            Me.grbDetail.Controls.Add(Me.txtProjectCode)
            Me.grbDetail.Controls.Add(Me.txtCustomerName)
            Me.grbDetail.Controls.Add(Me.txtProjectCodeName)
            Me.grbDetail.Controls.Add(Me.lblInc)
            Me.grbDetail.Controls.Add(Me.lblContact)
            Me.grbDetail.Controls.Add(Me.txtContact)
            Me.grbDetail.Controls.Add(Me.txtInc)
            Me.grbDetail.Controls.Add(Me.lblBaht)
            Me.grbDetail.Controls.Add(Me.lblBaht2)
            Me.grbDetail.Controls.Add(Me.lblDec)
            Me.grbDetail.Controls.Add(Me.txtDec)
            Me.grbDetail.Controls.Add(Me.lblBaht4)
            Me.grbDetail.Controls.Add(Me.lblPenalty)
            Me.grbDetail.Controls.Add(Me.txtPenalty)
            Me.grbDetail.Controls.Add(Me.lblBaht1)
            Me.grbDetail.Controls.Add(Me.lblTotal)
            Me.grbDetail.Controls.Add(Me.txtTotal)
            Me.grbDetail.Controls.Add(Me.lblBaht3)
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(664, 120)
            Me.grbDetail.TabIndex = 199
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลโครงการ"
            '
            'txtCustomer
            '
            Me.txtCustomer.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCustomer, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomer, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomer, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomer, System.Drawing.Color.Empty)
            Me.txtCustomer.Location = New System.Drawing.Point(88, 40)
            Me.Validator.SetMaxValue(Me.txtCustomer, "")
            Me.Validator.SetMinValue(Me.txtCustomer, "")
            Me.txtCustomer.Name = "txtCustomer"
            Me.txtCustomer.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomer, "")
            Me.Validator.SetRequired(Me.txtCustomer, False)
            Me.txtCustomer.Size = New System.Drawing.Size(88, 21)
            Me.txtCustomer.TabIndex = 175
            Me.txtCustomer.Text = ""
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(8, 40)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(72, 18)
            Me.lblCustomer.TabIndex = 124
            Me.lblCustomer.Text = "ลูกค้า:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProject
            '
            Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProject.Location = New System.Drawing.Point(8, 16)
            Me.lblProject.Name = "lblProject"
            Me.lblProject.Size = New System.Drawing.Size(72, 18)
            Me.lblProject.TabIndex = 124
            Me.lblProject.Text = "โครงการ:"
            Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtProjectCode
            '
            Me.txtProjectCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.txtProjectCode.Location = New System.Drawing.Point(88, 16)
            Me.Validator.SetMaxValue(Me.txtProjectCode, "")
            Me.Validator.SetMinValue(Me.txtProjectCode, "")
            Me.txtProjectCode.Name = "txtProjectCode"
            Me.txtProjectCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
            Me.Validator.SetRequired(Me.txtProjectCode, False)
            Me.txtProjectCode.Size = New System.Drawing.Size(88, 21)
            Me.txtProjectCode.TabIndex = 175
            Me.txtProjectCode.Text = ""
            '
            'txtCustomerName
            '
            Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.txtCustomerName.Location = New System.Drawing.Point(176, 40)
            Me.Validator.SetMaxValue(Me.txtCustomerName, "")
            Me.Validator.SetMinValue(Me.txtCustomerName, "")
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
            Me.Validator.SetRequired(Me.txtCustomerName, False)
            Me.txtCustomerName.Size = New System.Drawing.Size(408, 21)
            Me.txtCustomerName.TabIndex = 175
            Me.txtCustomerName.Text = ""
            '
            'txtProjectCodeName
            '
            Me.txtProjectCodeName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtProjectCodeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectCodeName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtProjectCodeName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectCodeName, System.Drawing.Color.Empty)
            Me.txtProjectCodeName.Location = New System.Drawing.Point(176, 16)
            Me.Validator.SetMaxValue(Me.txtProjectCodeName, "")
            Me.Validator.SetMinValue(Me.txtProjectCodeName, "")
            Me.txtProjectCodeName.Name = "txtProjectCodeName"
            Me.txtProjectCodeName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProjectCodeName, "")
            Me.Validator.SetRequired(Me.txtProjectCodeName, False)
            Me.txtProjectCodeName.Size = New System.Drawing.Size(408, 21)
            Me.txtProjectCodeName.TabIndex = 175
            Me.txtProjectCodeName.Text = ""
            '
            'lblInc
            '
            Me.lblInc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInc.Location = New System.Drawing.Point(240, 64)
            Me.lblInc.Name = "lblInc"
            Me.lblInc.Size = New System.Drawing.Size(72, 18)
            Me.lblInc.TabIndex = 124
            Me.lblInc.Text = "มูลค่างานเพิ่ม:"
            Me.lblInc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblContact
            '
            Me.lblContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblContact.Location = New System.Drawing.Point(16, 64)
            Me.lblContact.Name = "lblContact"
            Me.lblContact.Size = New System.Drawing.Size(72, 18)
            Me.lblContact.TabIndex = 124
            Me.lblContact.Text = "มูลค่าสัญญา:"
            Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtContact
            '
            Me.txtContact.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtContact, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtContact, "")
            Me.Validator.SetGotFocusBackColor(Me.txtContact, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtContact, System.Drawing.Color.Empty)
            Me.txtContact.Location = New System.Drawing.Point(88, 64)
            Me.Validator.SetMaxValue(Me.txtContact, "")
            Me.Validator.SetMinValue(Me.txtContact, "")
            Me.txtContact.Name = "txtContact"
            Me.Validator.SetRegularExpression(Me.txtContact, "")
            Me.Validator.SetRequired(Me.txtContact, False)
            Me.txtContact.Size = New System.Drawing.Size(104, 21)
            Me.txtContact.TabIndex = 175
            Me.txtContact.Text = ""
            '
            'txtInc
            '
            Me.txtInc.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtInc, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtInc, "")
            Me.Validator.SetGotFocusBackColor(Me.txtInc, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtInc, System.Drawing.Color.Empty)
            Me.txtInc.Location = New System.Drawing.Point(312, 64)
            Me.Validator.SetMaxValue(Me.txtInc, "")
            Me.Validator.SetMinValue(Me.txtInc, "")
            Me.txtInc.Name = "txtInc"
            Me.Validator.SetRegularExpression(Me.txtInc, "")
            Me.Validator.SetRequired(Me.txtInc, False)
            Me.txtInc.Size = New System.Drawing.Size(104, 21)
            Me.txtInc.TabIndex = 175
            Me.txtInc.Text = ""
            '
            'lblBaht
            '
            Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht.Location = New System.Drawing.Point(192, 64)
            Me.lblBaht.Name = "lblBaht"
            Me.lblBaht.Size = New System.Drawing.Size(32, 18)
            Me.lblBaht.TabIndex = 124
            Me.lblBaht.Text = "บาท"
            Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBaht2
            '
            Me.lblBaht2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht2.Location = New System.Drawing.Point(416, 64)
            Me.lblBaht2.Name = "lblBaht2"
            Me.lblBaht2.Size = New System.Drawing.Size(32, 18)
            Me.lblBaht2.TabIndex = 124
            Me.lblBaht2.Text = "บาท"
            Me.lblBaht2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDec
            '
            Me.lblDec.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDec.Location = New System.Drawing.Point(432, 64)
            Me.lblDec.Name = "lblDec"
            Me.lblDec.Size = New System.Drawing.Size(88, 18)
            Me.lblDec.TabIndex = 124
            Me.lblDec.Text = "มูลค่างานลด:"
            Me.lblDec.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDec
            '
            Me.txtDec.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDec, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDec, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDec, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDec, System.Drawing.Color.Empty)
            Me.txtDec.Location = New System.Drawing.Point(520, 64)
            Me.Validator.SetMaxValue(Me.txtDec, "")
            Me.Validator.SetMinValue(Me.txtDec, "")
            Me.txtDec.Name = "txtDec"
            Me.Validator.SetRegularExpression(Me.txtDec, "")
            Me.Validator.SetRequired(Me.txtDec, False)
            Me.txtDec.Size = New System.Drawing.Size(104, 21)
            Me.txtDec.TabIndex = 175
            Me.txtDec.Text = ""
            '
            'lblBaht4
            '
            Me.lblBaht4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht4.Location = New System.Drawing.Point(624, 64)
            Me.lblBaht4.Name = "lblBaht4"
            Me.lblBaht4.Size = New System.Drawing.Size(32, 18)
            Me.lblBaht4.TabIndex = 124
            Me.lblBaht4.Text = "บาท"
            Me.lblBaht4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPenalty
            '
            Me.lblPenalty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPenalty.Location = New System.Drawing.Point(16, 88)
            Me.lblPenalty.Name = "lblPenalty"
            Me.lblPenalty.Size = New System.Drawing.Size(72, 18)
            Me.lblPenalty.TabIndex = 124
            Me.lblPenalty.Text = "ค่าปรับรวม:"
            Me.lblPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPenalty
            '
            Me.txtPenalty.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtPenalty, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPenalty, "")
            Me.Validator.SetGotFocusBackColor(Me.txtPenalty, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPenalty, System.Drawing.Color.Empty)
            Me.txtPenalty.Location = New System.Drawing.Point(88, 88)
            Me.Validator.SetMaxValue(Me.txtPenalty, "")
            Me.Validator.SetMinValue(Me.txtPenalty, "")
            Me.txtPenalty.Name = "txtPenalty"
            Me.Validator.SetRegularExpression(Me.txtPenalty, "")
            Me.Validator.SetRequired(Me.txtPenalty, False)
            Me.txtPenalty.Size = New System.Drawing.Size(104, 21)
            Me.txtPenalty.TabIndex = 175
            Me.txtPenalty.Text = ""
            '
            'lblBaht1
            '
            Me.lblBaht1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht1.Location = New System.Drawing.Point(192, 88)
            Me.lblBaht1.Name = "lblBaht1"
            Me.lblBaht1.Size = New System.Drawing.Size(32, 18)
            Me.lblBaht1.TabIndex = 124
            Me.lblBaht1.Text = "บาท"
            Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTotal
            '
            Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTotal.Location = New System.Drawing.Point(224, 88)
            Me.lblTotal.Name = "lblTotal"
            Me.lblTotal.Size = New System.Drawing.Size(88, 18)
            Me.lblTotal.TabIndex = 124
            Me.lblTotal.Text = "มูลค่างานทั้งหมด:"
            Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTotal
            '
            Me.txtTotal.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTotal, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTotal, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTotal, System.Drawing.Color.Empty)
            Me.txtTotal.Location = New System.Drawing.Point(312, 88)
            Me.Validator.SetMaxValue(Me.txtTotal, "")
            Me.Validator.SetMinValue(Me.txtTotal, "")
            Me.txtTotal.Name = "txtTotal"
            Me.Validator.SetRegularExpression(Me.txtTotal, "")
            Me.Validator.SetRequired(Me.txtTotal, False)
            Me.txtTotal.Size = New System.Drawing.Size(104, 21)
            Me.txtTotal.TabIndex = 175
            Me.txtTotal.Text = ""
            '
            'lblBaht3
            '
            Me.lblBaht3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht3.Location = New System.Drawing.Point(416, 88)
            Me.lblBaht3.Name = "lblBaht3"
            Me.lblBaht3.Size = New System.Drawing.Size(32, 18)
            Me.lblBaht3.TabIndex = 124
            Me.lblBaht3.Text = "บาท"
            Me.lblBaht3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnRetention
            '
            Me.btnRetention.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnRetention.Location = New System.Drawing.Point(248, 128)
            Me.btnRetention.Name = "btnRetention"
            Me.btnRetention.Size = New System.Drawing.Size(56, 23)
            Me.btnRetention.TabIndex = 200
            Me.btnRetention.Text = "Retention"
            '
            'btnPenalty
            '
            Me.btnPenalty.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnPenalty.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnPenalty.Location = New System.Drawing.Point(304, 128)
            Me.btnPenalty.Name = "btnPenalty"
            Me.btnPenalty.Size = New System.Drawing.Size(56, 23)
            Me.btnPenalty.TabIndex = 200
            Me.btnPenalty.Text = "ค่าปรับ"
            '
            'btnAdvance
            '
            Me.btnAdvance.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAdvance.Location = New System.Drawing.Point(192, 128)
            Me.btnAdvance.Name = "btnAdvance"
            Me.btnAdvance.Size = New System.Drawing.Size(56, 23)
            Me.btnAdvance.TabIndex = 200
            Me.btnAdvance.Text = "Advance"
            '
            'btnInstalment
            '
            Me.btnInstalment.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnInstalment.Location = New System.Drawing.Point(136, 128)
            Me.btnInstalment.Name = "btnInstalment"
            Me.btnInstalment.Size = New System.Drawing.Size(56, 23)
            Me.btnInstalment.TabIndex = 200
            Me.btnInstalment.Text = "งวด"
            '
            'btnInc
            '
            Me.btnInc.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnInc.Location = New System.Drawing.Point(360, 128)
            Me.btnInc.Name = "btnInc"
            Me.btnInc.Size = New System.Drawing.Size(56, 23)
            Me.btnInc.TabIndex = 200
            Me.btnInc.Text = "งานเพิ่ม"
            '
            'btnDec
            '
            Me.btnDec.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnDec.Location = New System.Drawing.Point(416, 128)
            Me.btnDec.Name = "btnDec"
            Me.btnDec.Size = New System.Drawing.Size(56, 23)
            Me.btnDec.TabIndex = 200
            Me.btnDec.Text = "งานลด"
            '
            'btnPrint
            '
            Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnPrint.Location = New System.Drawing.Point(568, 416)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(96, 23)
            Me.btnPrint.TabIndex = 200
            Me.btnPrint.Text = "ทำรายการส่งงาน"
            '
            'ibtnShowDefaultUnitDialog
            '
            Me.ibtnShowDefaultUnitDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowDefaultUnitDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowDefaultUnitDialog.Image = CType(resources.GetObject("ibtnShowDefaultUnitDialog.Image"), System.Drawing.Image)
            Me.ibtnShowDefaultUnitDialog.Location = New System.Drawing.Point(584, 16)
            Me.ibtnShowDefaultUnitDialog.Name = "ibtnShowDefaultUnitDialog"
            Me.ibtnShowDefaultUnitDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowDefaultUnitDialog.TabIndex = 212
            Me.ibtnShowDefaultUnitDialog.TabStop = False
            Me.ibtnShowDefaultUnitDialog.ThemedImage = CType(resources.GetObject("ibtnShowDefaultUnitDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowReturnPerson
            '
            Me.ibtnShowReturnPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowReturnPerson.Image = CType(resources.GetObject("ibtnShowReturnPerson.Image"), System.Drawing.Image)
            Me.ibtnShowReturnPerson.Location = New System.Drawing.Point(608, 16)
            Me.ibtnShowReturnPerson.Name = "ibtnShowReturnPerson"
            Me.ibtnShowReturnPerson.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowReturnPerson.TabIndex = 211
            Me.ibtnShowReturnPerson.TabStop = False
            Me.ibtnShowReturnPerson.ThemedImage = CType(resources.GetObject("ibtnShowReturnPerson.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton1
            '
            Me.ImageButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton1.ForeColor = System.Drawing.SystemColors.Control
            Me.ImageButton1.Image = CType(resources.GetObject("ImageButton1.Image"), System.Drawing.Image)
            Me.ImageButton1.Location = New System.Drawing.Point(584, 40)
            Me.ImageButton1.Name = "ImageButton1"
            Me.ImageButton1.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton1.TabIndex = 214
            Me.ImageButton1.TabStop = False
            Me.ImageButton1.ThemedImage = CType(resources.GetObject("ImageButton1.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton2
            '
            Me.ImageButton2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton2.Image = CType(resources.GetObject("ImageButton2.Image"), System.Drawing.Image)
            Me.ImageButton2.Location = New System.Drawing.Point(608, 40)
            Me.ImageButton2.Name = "ImageButton2"
            Me.ImageButton2.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton2.TabIndex = 213
            Me.ImageButton2.TabStop = False
            Me.ImageButton2.ThemedImage = CType(resources.GetObject("ImageButton2.ThemedImage"), System.Drawing.Bitmap)
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
            'MilestoneSetup
            '
            Me.Controls.Add(Me.btnRetention)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.ListView1)
            Me.Controls.Add(Me.TreeGrid2)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.btnPenalty)
            Me.Controls.Add(Me.btnAdvance)
            Me.Controls.Add(Me.btnInstalment)
            Me.Controls.Add(Me.btnInc)
            Me.Controls.Add(Me.btnDec)
            Me.Controls.Add(Me.btnPrint)
            Me.Name = "MilestoneSetup"
            Me.Size = New System.Drawing.Size(680, 448)
            CType(Me.TreeGrid2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


        Public Sub SetLabelText()
            ' If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            'Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Global.CustomerText}")
            ' Me.lblProject.Text = Me.StringParserService.Parse("${res:Global.CostCenterText}")
            'Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.lblItem}")
            'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.grbDetail}")
            'Me.lblInc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.lblInc}")
            'Me.lblContact.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.lblContact}")
            'Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            'Me.lblBaht2.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            'Me.lblDec.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.lblDec}")
            'Me.lblBaht4.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            'Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            'Me.lblTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.lblTotal}")
            'Me.lblBaht3.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            'Me.btnRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.btnRetention}")
            'Me.btnAdvance.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.btnAdvance}")
            'Me.btnInstalment.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.btnInstalment}")
            'Me.btnInc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.btnInc}")
            'Me.btnDec.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.btnDec}")
            'Me.btnPrint.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.btnPrint}")
            'Me.lblPenalty.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.lblPenalty}")
            'Me.btnPenalty.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MilestoneSetup.btnPenalty}")


        End Sub
        Private Sub txtDec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDec.TextChanged

        End Sub

        Private Sub txtInc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInc.TextChanged

        End Sub

        Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)


        End Sub

    End Class
End Namespace