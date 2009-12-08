Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CSISelectionPanel
        Inherits AbstractEntityPanelViewContent
        Implements ISimpleEntityPanel

#Region "Members"
        Private m_lci As LCIItem
        Private m_entity As ILCIGroupable
        Private m_selectedEntity As ILCIGroupable

        Private m_treeManager As TreeManager
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                If Me.Entity Is Nothing OrElse Not Me.Entity.Originated Then
                    Return "รายละเอียด"
                End If
                Return "รายละเอียด:" & Me.Entity.Code
            End Get
        End Property
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ILCIGroupable)
            MyBase.New()
            InitializeComponent()
            m_entity = entity
            Me.SetLabelText()
            Me.TitleName = Me.Text
            Me.PanelName = Me.Name
            Me.m_lci = New LCIItem
            Dim dst As DataGridTableStyle = CreateTableStyle()
            m_treeManager = New TreeManager(GetDataTable(), tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
        End Sub
        Public Sub SelectNewEntity()
            Me.m_selectedEntity = CType(SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName), ILCIGroupable) 'CType(SimpleEntityFactory.CreateEntity(Me.m_entity.FullClassName), ILCIGroupable)
        End Sub
#End Region

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
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtlv5 As System.Windows.Forms.TextBox
        Friend WithEvents txtlv4 As System.Windows.Forms.TextBox
        Friend WithEvents txtlv3 As System.Windows.Forms.TextBox
        Friend WithEvents txtlv2 As System.Windows.Forms.TextBox
        Friend WithEvents chkControl As System.Windows.Forms.CheckBox
        Friend WithEvents lblAltName As System.Windows.Forms.Label
        Friend WithEvents txtAltName As System.Windows.Forms.TextBox
        Friend WithEvents txtlv1 As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblLevel4_5 As System.Windows.Forms.Label
        Friend WithEvents lblLevel3 As System.Windows.Forms.Label
        Friend WithEvents lblLevel2 As System.Windows.Forms.Label
        Friend WithEvents lblLevel1 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents grpAmount As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents clbLevel1 As System.Windows.Forms.CheckedListBox
        Friend WithEvents clbLevel2 As System.Windows.Forms.CheckedListBox
        Friend WithEvents clbLevel3 As System.Windows.Forms.CheckedListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnClear = New System.Windows.Forms.Button
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtlv5 = New System.Windows.Forms.TextBox
            Me.txtlv4 = New System.Windows.Forms.TextBox
            Me.txtlv3 = New System.Windows.Forms.TextBox
            Me.txtlv2 = New System.Windows.Forms.TextBox
            Me.chkControl = New System.Windows.Forms.CheckBox
            Me.lblAltName = New System.Windows.Forms.Label
            Me.txtAltName = New System.Windows.Forms.TextBox
            Me.txtlv1 = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblName = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblLevel4_5 = New System.Windows.Forms.Label
            Me.lblLevel3 = New System.Windows.Forms.Label
            Me.lblLevel2 = New System.Windows.Forms.Label
            Me.lblLevel1 = New System.Windows.Forms.Label
            Me.GroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grpAmount = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.Label5 = New System.Windows.Forms.Label
            Me.Label6 = New System.Windows.Forms.Label
            Me.TextBox8 = New System.Windows.Forms.TextBox
            Me.TextBox9 = New System.Windows.Forms.TextBox
            Me.Label7 = New System.Windows.Forms.Label
            Me.Label8 = New System.Windows.Forms.Label
            Me.TextBox1 = New System.Windows.Forms.TextBox
            Me.TextBox2 = New System.Windows.Forms.TextBox
            Me.TextBox3 = New System.Windows.Forms.TextBox
            Me.TextBox4 = New System.Windows.Forms.TextBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.TextBox5 = New System.Windows.Forms.TextBox
            Me.TextBox6 = New System.Windows.Forms.TextBox
            Me.Label3 = New System.Windows.Forms.Label
            Me.Label4 = New System.Windows.Forms.Label
            Me.TextBox7 = New System.Windows.Forms.TextBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.Button1 = New System.Windows.Forms.Button
            Me.Button2 = New System.Windows.Forms.Button
            Me.Button3 = New System.Windows.Forms.Button
            Me.clbLevel1 = New System.Windows.Forms.CheckedListBox
            Me.clbLevel2 = New System.Windows.Forms.CheckedListBox
            Me.clbLevel3 = New System.Windows.Forms.CheckedListBox
            Me.grbDetail.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.grpAmount.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnClear
            '
            Me.btnClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnClear.Location = New System.Drawing.Point(216, 18)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(40, 23)
            Me.btnClear.TabIndex = 184
            Me.btnClear.Text = "Clear"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.txtlv5)
            Me.grbDetail.Controls.Add(Me.txtlv4)
            Me.grbDetail.Controls.Add(Me.txtlv3)
            Me.grbDetail.Controls.Add(Me.txtlv2)
            Me.grbDetail.Controls.Add(Me.chkControl)
            Me.grbDetail.Controls.Add(Me.lblAltName)
            Me.grbDetail.Controls.Add(Me.txtAltName)
            Me.grbDetail.Controls.Add(Me.txtlv1)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.Location = New System.Drawing.Point(16, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(288, 104)
            Me.grbDetail.TabIndex = 180
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียดวัสดุ"
            '
            'txtlv5
            '
            Me.txtlv5.BackColor = System.Drawing.SystemColors.Window
            Me.txtlv5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtlv5.Location = New System.Drawing.Point(160, 16)
            Me.txtlv5.MaxLength = 4
            Me.txtlv5.Name = "txtlv5"
            Me.txtlv5.ReadOnly = True
            Me.txtlv5.Size = New System.Drawing.Size(56, 26)
            Me.txtlv5.TabIndex = 4
            Me.txtlv5.Text = ""
            '
            'txtlv4
            '
            Me.txtlv4.BackColor = System.Drawing.SystemColors.Window
            Me.txtlv4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtlv4.Location = New System.Drawing.Point(136, 16)
            Me.txtlv4.MaxLength = 2
            Me.txtlv4.Name = "txtlv4"
            Me.txtlv4.ReadOnly = True
            Me.txtlv4.Size = New System.Drawing.Size(24, 26)
            Me.txtlv4.TabIndex = 3
            Me.txtlv4.Text = ""
            '
            'txtlv3
            '
            Me.txtlv3.BackColor = System.Drawing.SystemColors.Info
            Me.txtlv3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtlv3.Location = New System.Drawing.Point(112, 16)
            Me.txtlv3.MaxLength = 2
            Me.txtlv3.Name = "txtlv3"
            Me.txtlv3.ReadOnly = True
            Me.txtlv3.Size = New System.Drawing.Size(24, 26)
            Me.txtlv3.TabIndex = 2
            Me.txtlv3.Text = ""
            '
            'txtlv2
            '
            Me.txtlv2.BackColor = System.Drawing.SystemColors.Info
            Me.txtlv2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtlv2.Location = New System.Drawing.Point(88, 16)
            Me.txtlv2.MaxLength = 2
            Me.txtlv2.Name = "txtlv2"
            Me.txtlv2.ReadOnly = True
            Me.txtlv2.Size = New System.Drawing.Size(24, 26)
            Me.txtlv2.TabIndex = 1
            Me.txtlv2.Text = ""
            '
            'chkControl
            '
            Me.chkControl.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkControl.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.chkControl.Location = New System.Drawing.Point(232, 16)
            Me.chkControl.Name = "chkControl"
            Me.chkControl.Size = New System.Drawing.Size(40, 20)
            Me.chkControl.TabIndex = 5
            Me.chkControl.Text = "คุม"
            '
            'lblAltName
            '
            Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAltName.Location = New System.Drawing.Point(24, 72)
            Me.lblAltName.Name = "lblAltName"
            Me.lblAltName.Size = New System.Drawing.Size(40, 20)
            Me.lblAltName.TabIndex = 124
            Me.lblAltName.Text = "ชื่ออื่น:"
            Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAltName
            '
            Me.txtAltName.BackColor = System.Drawing.SystemColors.Window
            Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtAltName.Location = New System.Drawing.Point(64, 72)
            Me.txtAltName.MaxLength = 200
            Me.txtAltName.Name = "txtAltName"
            Me.txtAltName.ReadOnly = True
            Me.txtAltName.Size = New System.Drawing.Size(216, 22)
            Me.txtAltName.TabIndex = 7
            Me.txtAltName.Text = ""
            '
            'txtlv1
            '
            Me.txtlv1.BackColor = System.Drawing.SystemColors.Info
            Me.txtlv1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtlv1.Location = New System.Drawing.Point(64, 16)
            Me.txtlv1.MaxLength = 2
            Me.txtlv1.Name = "txtlv1"
            Me.txtlv1.ReadOnly = True
            Me.txtlv1.Size = New System.Drawing.Size(24, 26)
            Me.txtlv1.TabIndex = 0
            Me.txtlv1.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(56, 20)
            Me.lblCode.TabIndex = 123
            Me.lblCode.Text = "รหัสวัสดุ:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.Location = New System.Drawing.Point(16, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(48, 20)
            Me.lblName.TabIndex = 122
            Me.lblName.Text = "ชื่อวัสดุ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.SystemColors.Window
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtName.Location = New System.Drawing.Point(64, 48)
            Me.txtName.MaxLength = 200
            Me.txtName.Name = "txtName"
            Me.txtName.ReadOnly = True
            Me.txtName.Size = New System.Drawing.Size(216, 22)
            Me.txtName.TabIndex = 6
            Me.txtName.Text = ""
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.tgItem.AutoColumnResize = True
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 280)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(960, 344)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 190
            Me.tgItem.TreeManager = Nothing
            '
            'lblLevel4_5
            '
            Me.lblLevel4_5.AutoSize = True
            Me.lblLevel4_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLevel4_5.Location = New System.Drawing.Point(0, 264)
            Me.lblLevel4_5.Name = "lblLevel4_5"
            Me.lblLevel4_5.Size = New System.Drawing.Size(64, 18)
            Me.lblLevel4_5.TabIndex = 189
            Me.lblLevel4_5.Text = "รายการวัสดุ"
            Me.lblLevel4_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLevel3
            '
            Me.lblLevel3.AutoSize = True
            Me.lblLevel3.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLevel3.Location = New System.Drawing.Point(648, 112)
            Me.lblLevel3.Name = "lblLevel3"
            Me.lblLevel3.Size = New System.Drawing.Size(54, 21)
            Me.lblLevel3.TabIndex = 188
            Me.lblLevel3.Text = "Level3"
            Me.lblLevel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLevel2
            '
            Me.lblLevel2.AutoSize = True
            Me.lblLevel2.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLevel2.Location = New System.Drawing.Point(328, 112)
            Me.lblLevel2.Name = "lblLevel2"
            Me.lblLevel2.Size = New System.Drawing.Size(54, 21)
            Me.lblLevel2.TabIndex = 187
            Me.lblLevel2.Text = "Level2"
            Me.lblLevel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLevel1
            '
            Me.lblLevel1.AutoSize = True
            Me.lblLevel1.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLevel1.Location = New System.Drawing.Point(8, 112)
            Me.lblLevel1.Name = "lblLevel1"
            Me.lblLevel1.Size = New System.Drawing.Size(54, 21)
            Me.lblLevel1.TabIndex = 186
            Me.lblLevel1.Text = "Level1"
            Me.lblLevel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.grpAmount)
            Me.GroupBox1.Controls.Add(Me.TextBox1)
            Me.GroupBox1.Controls.Add(Me.TextBox2)
            Me.GroupBox1.Controls.Add(Me.TextBox3)
            Me.GroupBox1.Controls.Add(Me.TextBox4)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.TextBox5)
            Me.GroupBox1.Controls.Add(Me.TextBox6)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.TextBox7)
            Me.GroupBox1.Controls.Add(Me.btnClear)
            Me.GroupBox1.Controls.Add(Me.btnSearch)
            Me.GroupBox1.Controls.Add(Me.Button1)
            Me.GroupBox1.Controls.Add(Me.Button2)
            Me.GroupBox1.Controls.Add(Me.Button3)
            Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(304, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(672, 104)
            Me.GroupBox1.TabIndex = 180
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "ค้นหาวัสดุ/หมวดวัสดุ"
            '
            'grpAmount
            '
            Me.grpAmount.Controls.Add(Me.Label5)
            Me.grpAmount.Controls.Add(Me.Label6)
            Me.grpAmount.Controls.Add(Me.TextBox8)
            Me.grpAmount.Controls.Add(Me.TextBox9)
            Me.grpAmount.Controls.Add(Me.Label7)
            Me.grpAmount.Controls.Add(Me.Label8)
            Me.grpAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grpAmount.Location = New System.Drawing.Point(352, 8)
            Me.grpAmount.Name = "grpAmount"
            Me.grpAmount.Size = New System.Drawing.Size(200, 72)
            Me.grpAmount.TabIndex = 189
            Me.grpAmount.TabStop = False
            Me.grpAmount.Text = "ราคา"
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(8, 18)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(32, 18)
            Me.Label5.TabIndex = 11
            Me.Label5.Text = "ตั้งแต่"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(24, 42)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(16, 18)
            Me.Label6.TabIndex = 11
            Me.Label6.Text = "ถึง"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TextBox8
            '
            Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.TextBox8.Location = New System.Drawing.Point(56, 16)
            Me.TextBox8.Name = "TextBox8"
            Me.TextBox8.Size = New System.Drawing.Size(80, 22)
            Me.TextBox8.TabIndex = 187
            Me.TextBox8.Text = ""
            '
            'TextBox9
            '
            Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.TextBox9.Location = New System.Drawing.Point(56, 40)
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.Size = New System.Drawing.Size(80, 22)
            Me.TextBox9.TabIndex = 187
            Me.TextBox9.Text = ""
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(136, 24)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(56, 18)
            Me.Label7.TabIndex = 11
            Me.Label7.Text = "บาท/หน่วย"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(136, 48)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(56, 18)
            Me.Label8.TabIndex = 11
            Me.Label8.Text = "บาท/หน่วย"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TextBox1
            '
            Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
            Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.TextBox1.Location = New System.Drawing.Point(160, 16)
            Me.TextBox1.MaxLength = 4
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(56, 26)
            Me.TextBox1.TabIndex = 4
            Me.TextBox1.Text = ""
            '
            'TextBox2
            '
            Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
            Me.TextBox2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.TextBox2.Location = New System.Drawing.Point(136, 16)
            Me.TextBox2.MaxLength = 2
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(24, 26)
            Me.TextBox2.TabIndex = 3
            Me.TextBox2.Text = ""
            '
            'TextBox3
            '
            Me.TextBox3.BackColor = System.Drawing.SystemColors.Info
            Me.TextBox3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.TextBox3.Location = New System.Drawing.Point(112, 16)
            Me.TextBox3.MaxLength = 2
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Size = New System.Drawing.Size(24, 26)
            Me.TextBox3.TabIndex = 2
            Me.TextBox3.Text = ""
            '
            'TextBox4
            '
            Me.TextBox4.BackColor = System.Drawing.SystemColors.Info
            Me.TextBox4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.TextBox4.Location = New System.Drawing.Point(88, 16)
            Me.TextBox4.MaxLength = 2
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Size = New System.Drawing.Size(24, 26)
            Me.TextBox4.TabIndex = 1
            Me.TextBox4.Text = ""
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label2.Location = New System.Drawing.Point(8, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(56, 20)
            Me.Label2.TabIndex = 124
            Me.Label2.Text = "ชื่ออื่น:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TextBox5
            '
            Me.TextBox5.BackColor = System.Drawing.SystemColors.Window
            Me.TextBox5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.TextBox5.Location = New System.Drawing.Point(64, 72)
            Me.TextBox5.MaxLength = 200
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.Size = New System.Drawing.Size(240, 22)
            Me.TextBox5.TabIndex = 7
            Me.TextBox5.Text = ""
            '
            'TextBox6
            '
            Me.TextBox6.BackColor = System.Drawing.SystemColors.Info
            Me.TextBox6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.TextBox6.Location = New System.Drawing.Point(64, 16)
            Me.TextBox6.MaxLength = 2
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Size = New System.Drawing.Size(24, 26)
            Me.TextBox6.TabIndex = 0
            Me.TextBox6.Text = ""
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label3.Location = New System.Drawing.Point(8, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(56, 20)
            Me.Label3.TabIndex = 123
            Me.Label3.Text = "รหัสวัสดุ:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label4.Location = New System.Drawing.Point(8, 48)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(56, 20)
            Me.Label4.TabIndex = 122
            Me.Label4.Text = "ชื่อวัสดุ:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TextBox7
            '
            Me.TextBox7.BackColor = System.Drawing.SystemColors.Window
            Me.TextBox7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.TextBox7.Location = New System.Drawing.Point(64, 48)
            Me.TextBox7.MaxLength = 200
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.Size = New System.Drawing.Size(240, 22)
            Me.TextBox7.TabIndex = 6
            Me.TextBox7.Text = ""
            '
            'btnSearch
            '
            Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSearch.Location = New System.Drawing.Point(552, 40)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 24)
            Me.btnSearch.TabIndex = 184
            Me.btnSearch.Text = "ค้นหา"
            '
            'Button1
            '
            Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Button1.Location = New System.Drawing.Point(304, 48)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(40, 23)
            Me.Button1.TabIndex = 184
            Me.Button1.Text = "Clear"
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Button2.Location = New System.Drawing.Point(304, 72)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(40, 23)
            Me.Button2.TabIndex = 184
            Me.Button2.Text = "Clear"
            '
            'Button3
            '
            Me.Button3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Button3.Location = New System.Drawing.Point(552, 16)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(75, 24)
            Me.Button3.TabIndex = 184
            Me.Button3.Text = "Clear All"
            '
            'clbLevel1
            '
            Me.clbLevel1.BackColor = System.Drawing.SystemColors.Info
            Me.clbLevel1.CheckOnClick = True
            Me.clbLevel1.Location = New System.Drawing.Point(16, 128)
            Me.clbLevel1.Name = "clbLevel1"
            Me.clbLevel1.Size = New System.Drawing.Size(312, 139)
            Me.clbLevel1.TabIndex = 191
            '
            'clbLevel2
            '
            Me.clbLevel2.BackColor = System.Drawing.SystemColors.Info
            Me.clbLevel2.CheckOnClick = True
            Me.clbLevel2.Location = New System.Drawing.Point(328, 128)
            Me.clbLevel2.Name = "clbLevel2"
            Me.clbLevel2.Size = New System.Drawing.Size(312, 139)
            Me.clbLevel2.TabIndex = 191
            '
            'clbLevel3
            '
            Me.clbLevel3.BackColor = System.Drawing.SystemColors.Info
            Me.clbLevel3.CheckOnClick = True
            Me.clbLevel3.Location = New System.Drawing.Point(640, 128)
            Me.clbLevel3.Name = "clbLevel3"
            Me.clbLevel3.Size = New System.Drawing.Size(328, 139)
            Me.clbLevel3.TabIndex = 191
            '
            'CSISelectionPanel
            '
            Me.Controls.Add(Me.clbLevel1)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.lblLevel4_5)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.clbLevel2)
            Me.Controls.Add(Me.clbLevel3)
            Me.Controls.Add(Me.lblLevel3)
            Me.Controls.Add(Me.lblLevel2)
            Me.Controls.Add(Me.lblLevel1)
            Me.Name = "CSISelectionPanel"
            Me.Size = New System.Drawing.Size(984, 632)
            Me.grbDetail.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.grpAmount.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Overrides"
        Public Sub CheckFormEnable() Implements ISimpleEntityPanel.CheckFormEnable

        End Sub

        Public Sub ClearDetail() Implements ISimpleEntityPanel.ClearDetail

        End Sub

        Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
            Get

            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)

            End Set
        End Property

        Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

        Public Sub Initialize() Implements ISimpleEntityPanel.Initialize

        End Sub

        Public Sub SetLabelText() Implements ISimpleEntityPanel.SetLabelText

        End Sub

        Public Sub UpdateEntityProperties() Implements ISimpleEntityPanel.UpdateEntityProperties

        End Sub

        Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
            Get

            End Get
        End Property

        Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

        End Sub

        Public ReadOnly Property Title() As String Implements ISimplePanel.Title
            Get

            End Get
        End Property
#End Region

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Me.clbLevel1.Items.Clear()
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim t As Date = Now
            Dim coll As TreeBaseEntityCollection = Me.m_lci.GetCollection(1, -1)
            Me.clbLevel1.Items.Clear()
            Me.clbLevel2.Items.Clear()
            Me.clbLevel3.Items.Clear()
            Me.m_treeManager.Treetable.Rows.Clear()
            For Each csi As LCIItem In coll
                Me.clbLevel1.Items.Add(csi)
            Next
            lblLevel1.Text = "Level1:" & coll.Count.ToString & ":" & t.Subtract(Now).ToString
            lblLevel2.Text = "Level2"
            lblLevel3.Text = "Level3"
        End Sub

        Private Sub clbLevel1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbLevel1.SelectedIndexChanged
            If clbLevel1.SelectedItem Is Nothing Then
                Return
            End If
            Dim t As Date = Now
            Dim parentItem As LCIItem = CType(clbLevel1.SelectedItem, LCIItem)
            Dim coll As TreeBaseEntityCollection = Me.m_lci.GetCollection(2, parentItem.Id)
            Me.clbLevel2.Items.Clear()
            Me.clbLevel3.Items.Clear()
            Me.m_treeManager.Treetable.Rows.Clear()
            For Each csi As LCIItem In coll
                Me.clbLevel2.Items.Add(csi)
            Next
            lblLevel2.Text = "Level2:" & coll.Count.ToString & ":" & t.Subtract(Now).ToString
            lblLevel3.Text = "Level3"
        End Sub

        Private Sub clbLevel2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbLevel2.SelectedIndexChanged
            If clbLevel2.SelectedItem Is Nothing Then
                Return
            End If
            Dim t As Date = Now
            Dim parentItem As LCIItem = CType(clbLevel2.SelectedItem, LCIItem)
            Dim coll As TreeBaseEntityCollection = Me.m_lci.GetCollection(3, parentItem.Id)
            Me.clbLevel3.Items.Clear()
            Me.m_treeManager.Treetable.Rows.Clear()
            For Each csi As LCIItem In coll
                Me.clbLevel3.Items.Add(csi)
            Next
            lblLevel3.Text = "Level3:" & coll.Count.ToString & ":" & t.Subtract(Now).ToString
        End Sub

        Private Sub clbLevel3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbLevel3.SelectedIndexChanged
            If clbLevel3.SelectedItem Is Nothing Then
                Return
            End If
            Dim parentItem As LCIItem = CType(clbLevel3.SelectedItem, LCIItem)
            Me.m_treeManager.Treetable.Rows.Clear()
            Dim l4coll As TreeBaseEntityCollection = Me.m_lci.GetCollection(4, parentItem.Id)
            For Each l4item As LCIItem In l4coll
                Dim l4row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
                l4row.State = RowExpandState.Collapsed
                l4row("Code") = l4item.Code
                l4row("Description") = l4item.Name
                Dim l5coll As TreeBaseEntityCollection = Me.m_lci.GetCollection(5, l4item.Id)
                For Each l5item As LCIItem In l5coll
                    Dim l5row As TreeRow = l4row.Childs.Add()
                    l5row.State = RowExpandState.Expanded
                    l5row("Code") = l5item.Code
                    l5row("Description") = l5item.Name

                    Dim l6row As TreeRow = l5row.Childs.Add()
                    l6row("Code") = "Test"
                    l6row("Description") = "Test"
                    l6row("unitId") = 1
                    l6row("Unit") = "โหล"
                    l6row("UnitPrice") = 350

                    l6row = l5row.Childs.Add()
                    l6row("Code") = "Test2"
                    l6row("Description") = "Test2"
                    l6row("unitId") = 1
                    l6row("Unit") = "โหล"
                    l6row("UnitPrice") = 330
                Next
            Next
            Me.m_treeManager.Treegrid.RefreshHeights()
        End Sub
        Private Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "CSI"
            dst.ReadOnly = True

            Dim csCode As New PlusMinusTreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanel.CodeHeaderText}")
            csCode.NullText = ""
            csCode.ReadOnly = True

            Dim csDescription As New TreeTextColumn
            csDescription.MappingName = "Description"
            csDescription.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanel.DescriptionHeaderText}")
            csDescription.NullText = ""
            csDescription.Width = 180
            'csDescription.ReadOnly = True

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanel.UnitHeaderText}")
            csUnit.NullText = ""
            csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csUMC As New TreeTextColumn
            csUMC.MappingName = "UnitPrice"
            csUMC.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanel.UnitPriceHeaderText}")
            csUMC.NullText = ""
            csUMC.DataAlignment = HorizontalAlignment.Right
            csUMC.Format = "#,##0.00"

            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csDescription)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csUMC)
            Return dst
        End Function
        Private Function GetDataTable() As TreeTable
            Dim myDatatable As New TreeTable("CSI")
            myDatatable.Columns.Add(New DataColumn("Id", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("unitId", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("UnitPrice", GetType(Decimal)))
            Return myDatatable
        End Function


    End Class
End Namespace

