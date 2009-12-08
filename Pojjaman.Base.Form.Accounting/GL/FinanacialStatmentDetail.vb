Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class FinanacialStatmentDetail
        Inherits AbstractEntityDetailPanelView

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
        Friend WithEvents tvAccountChart As System.Windows.Forms.TreeView
        Friend WithEvents lvFSReport As Longkong.Pojjaman.Gui.Components.PJMListView
        Friend WithEvents ImageButton3 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton2 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton4 As Longkong.Pojjaman.Gui.Components.ImageButton
        Private WithEvents grbFSReport As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblRefTx As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents cmbType As System.Windows.Forms.ComboBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "BOQ001"}, -1)
            Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "BOQ002"}, -1)
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FinanacialStatmentDetail))
            Me.tvAccountChart = New System.Windows.Forms.TreeView
            Me.lvFSReport = New Longkong.Pojjaman.Gui.Components.PJMListView
            Me.grbFSReport = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ImageButton3 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton1 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton2 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton4 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblRefTx = New System.Windows.Forms.Label
            Me.lblItem = New System.Windows.Forms.Label
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.cmbType = New System.Windows.Forms.ComboBox
            Me.btnReset = New System.Windows.Forms.Button
            Me.lblType = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.grbFSReport.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'tvAccountChart
            '
            Me.tvAccountChart.ImageIndex = -1
            Me.tvAccountChart.Location = New System.Drawing.Point(8, 24)
            Me.tvAccountChart.Name = "tvAccountChart"
            Me.tvAccountChart.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("1000 สินทรัพย์", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Addenda")})})
            Me.tvAccountChart.SelectedImageIndex = -1
            Me.tvAccountChart.Size = New System.Drawing.Size(216, 384)
            Me.tvAccountChart.TabIndex = 10
            '
            'lvFSReport
            '
            Me.lvFSReport.AllowSort = True
            Me.lvFSReport.CheckBoxes = True
            Me.lvFSReport.FullRowSelect = True
            Me.lvFSReport.GridLines = True
            Me.lvFSReport.HideSelection = False
            ListViewItem1.StateImageIndex = 0
            ListViewItem2.StateImageIndex = 0
            Me.lvFSReport.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
            Me.lvFSReport.Location = New System.Drawing.Point(256, 24)
            Me.lvFSReport.Name = "lvFSReport"
            Me.lvFSReport.Size = New System.Drawing.Size(432, 384)
            Me.lvFSReport.SortIndex = -1
            Me.lvFSReport.SortOrder = System.Windows.Forms.SortOrder.None
            Me.lvFSReport.TabIndex = 11
            Me.lvFSReport.View = System.Windows.Forms.View.Details
            '
            'grbFSReport
            '
            Me.grbFSReport.Controls.Add(Me.ImageButton3)
            Me.grbFSReport.Controls.Add(Me.tvAccountChart)
            Me.grbFSReport.Controls.Add(Me.lvFSReport)
            Me.grbFSReport.Controls.Add(Me.ImageButton1)
            Me.grbFSReport.Controls.Add(Me.ImageButton2)
            Me.grbFSReport.Controls.Add(Me.ImageButton4)
            Me.grbFSReport.Controls.Add(Me.lblRefTx)
            Me.grbFSReport.Controls.Add(Me.lblItem)
            Me.grbFSReport.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbFSReport.Location = New System.Drawing.Point(8, 64)
            Me.grbFSReport.Name = "grbFSReport"
            Me.grbFSReport.Size = New System.Drawing.Size(696, 416)
            Me.grbFSReport.TabIndex = 12
            Me.grbFSReport.TabStop = False
            '
            'ImageButton3
            '
            Me.ImageButton3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton3.Image = CType(resources.GetObject("ImageButton3.Image"), System.Drawing.Image)
            Me.ImageButton3.Location = New System.Drawing.Point(224, 56)
            Me.ImageButton3.Name = "ImageButton3"
            Me.ImageButton3.Size = New System.Drawing.Size(32, 32)
            Me.ImageButton3.TabIndex = 260
            Me.ImageButton3.TabStop = False
            Me.ImageButton3.ThemedImage = CType(resources.GetObject("ImageButton3.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton1
            '
            Me.ImageButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton1.Image = CType(resources.GetObject("ImageButton1.Image"), System.Drawing.Image)
            Me.ImageButton1.Location = New System.Drawing.Point(224, 88)
            Me.ImageButton1.Name = "ImageButton1"
            Me.ImageButton1.Size = New System.Drawing.Size(32, 32)
            Me.ImageButton1.TabIndex = 260
            Me.ImageButton1.TabStop = False
            Me.ImageButton1.ThemedImage = CType(resources.GetObject("ImageButton1.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton2
            '
            Me.ImageButton2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton2.Image = CType(resources.GetObject("ImageButton2.Image"), System.Drawing.Image)
            Me.ImageButton2.Location = New System.Drawing.Point(224, 136)
            Me.ImageButton2.Name = "ImageButton2"
            Me.ImageButton2.Size = New System.Drawing.Size(32, 32)
            Me.ImageButton2.TabIndex = 260
            Me.ImageButton2.TabStop = False
            Me.ImageButton2.ThemedImage = CType(resources.GetObject("ImageButton2.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton4
            '
            Me.ImageButton4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton4.Image = CType(resources.GetObject("ImageButton4.Image"), System.Drawing.Image)
            Me.ImageButton4.Location = New System.Drawing.Point(224, 168)
            Me.ImageButton4.Name = "ImageButton4"
            Me.ImageButton4.Size = New System.Drawing.Size(32, 32)
            Me.ImageButton4.TabIndex = 260
            Me.ImageButton4.TabStop = False
            Me.ImageButton4.ThemedImage = CType(resources.GetObject("ImageButton4.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblRefTx
            '
            Me.lblRefTx.BackColor = System.Drawing.Color.Transparent
            Me.lblRefTx.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblRefTx.Location = New System.Drawing.Point(8, 8)
            Me.lblRefTx.Name = "lblRefTx"
            Me.lblRefTx.Size = New System.Drawing.Size(72, 18)
            Me.lblRefTx.TabIndex = 261
            Me.lblRefTx.Text = "ผังบัญชี"
            Me.lblRefTx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(256, 8)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(144, 16)
            Me.lblItem.TabIndex = 261
            Me.lblItem.Text = "รายงานงบการเงิน..."
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.cmbType)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.lblType)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblDocDate)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtNote)
            Me.grbDetail.Controls.Add(Me.lblNote)
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(696, 64)
            Me.grbDetail.TabIndex = 13
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายงานงบการเงิน"
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(296, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(112, 20)
            Me.dtpDocDateStart.TabIndex = 249
            '
            'cmbType
            '
            Me.cmbType.Location = New System.Drawing.Point(512, 16)
            Me.cmbType.Name = "cmbType"
            Me.cmbType.Size = New System.Drawing.Size(128, 21)
            Me.cmbType.TabIndex = 248
            Me.cmbType.Text = "งบกำไรขาดทุน,งบดุล"
            '
            'btnReset
            '
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(640, 16)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(48, 23)
            Me.btnReset.TabIndex = 247
            Me.btnReset.Text = "Reset"
            '
            'lblType
            '
            Me.lblType.Location = New System.Drawing.Point(424, 16)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(88, 16)
            Me.lblType.TabIndex = 0
            Me.lblType.Text = "ประเภทงบการเงิน:"
            Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.txtCode.BackColor = System.Drawing.SystemColors.Window
            Me.txtCode.Location = New System.Drawing.Point(72, 16)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(152, 20)
            Me.txtCode.TabIndex = 246
            Me.txtCode.Text = ""
            '
            'lblDocDate
            '
            Me.lblDocDate.Location = New System.Drawing.Point(208, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(88, 16)
            Me.lblDocDate.TabIndex = 0
            Me.lblDocDate.Text = "วันที่รายงาน:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(64, 16)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "รหัสรายงาน:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.txtNote.Location = New System.Drawing.Point(72, 40)
            Me.txtNote.Name = "txtNote"
            Me.txtNote.Size = New System.Drawing.Size(336, 20)
            Me.txtNote.TabIndex = 246
            Me.txtNote.Text = ""
            '
            'lblNote
            '
            Me.lblNote.Location = New System.Drawing.Point(8, 40)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(64, 16)
            Me.lblNote.TabIndex = 0
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'FinanacialStatmentDetail
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.grbFSReport)
            Me.Name = "FinanacialStatmentDetail"
            Me.Size = New System.Drawing.Size(712, 488)
            Me.grbFSReport.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub ImageButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageButton3.Click

        End Sub
        Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageButton1.Click

        End Sub
        Private Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageButton2.Click

        End Sub
        Friend WithEvents btnReset As System.Windows.Forms.Button

        Public Overrides Property Site() As System.ComponentModel.ISite
            Get

            End Get
            Set(ByVal Value As System.ComponentModel.ISite)

            End Set
        End Property

        Public Overrides Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbFSReport.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FinanacialStatmentDetail.grbFSReport}")
            Me.lblRefTx.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FinanacialStatmentDetail.lblRefTx}")
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FinanacialStatmentDetail.lblItem}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FinanacialStatmentDetail.grbDetail}")
            Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FinanacialStatmentDetail.lblType}")
            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FinanacialStatmentDetail.lblDocDate}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FinanacialStatmentDetail.lblCode}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")


        End Sub
    End Class
End Namespace
