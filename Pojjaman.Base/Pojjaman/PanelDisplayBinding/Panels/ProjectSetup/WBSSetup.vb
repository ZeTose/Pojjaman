Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Reporting
Imports System.Drawing.Printing
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class WBSSetup
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
        Friend WithEvents tvProject As System.Windows.Forms.TreeView
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents lblPJWorkBreakdownItem As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.tvProject = New System.Windows.Forms.TreeView
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.lblPJWorkBreakdownItem = New System.Windows.Forms.Label
            Me.btnDelete = New System.Windows.Forms.Button
            Me.btnNew = New System.Windows.Forms.Button
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'tvProject
            '
            Me.tvProject.ImageIndex = -1
            Me.tvProject.Location = New System.Drawing.Point(8, 32)
            Me.tvProject.Name = "tvProject"
            Me.tvProject.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Project1", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Addenda")}), New System.Windows.Forms.TreeNode("Project2"), New System.Windows.Forms.TreeNode("Project3")})
            Me.tvProject.SelectedImageIndex = -1
            Me.tvProject.Size = New System.Drawing.Size(648, 304)
            Me.tvProject.TabIndex = 1
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.txtNote)
            Me.grbDetail.Controls.Add(Me.lblNote)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 336)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(656, 112)
            Me.grbDetail.TabIndex = 2
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียดหมวดงาน"
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(40, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(32, 18)
            Me.lblCode.TabIndex = 202
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCode.Location = New System.Drawing.Point(72, 24)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(128, 22)
            Me.txtCode.TabIndex = 203
            Me.txtCode.Text = ""
            '
            'txtName
            '
            Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtName.Location = New System.Drawing.Point(72, 48)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(568, 22)
            Me.txtName.TabIndex = 203
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(40, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(32, 18)
            Me.lblName.TabIndex = 202
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtNote.Location = New System.Drawing.Point(72, 72)
            Me.txtNote.Name = "txtNote"
            Me.txtNote.Size = New System.Drawing.Size(568, 22)
            Me.txtNote.TabIndex = 203
            Me.txtNote.Text = ""
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(16, 72)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(56, 18)
            Me.lblNote.TabIndex = 202
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPJWorkBreakdownItem
            '
            Me.lblPJWorkBreakdownItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPJWorkBreakdownItem.Location = New System.Drawing.Point(8, 16)
            Me.lblPJWorkBreakdownItem.Name = "lblPJWorkBreakdownItem"
            Me.lblPJWorkBreakdownItem.Size = New System.Drawing.Size(224, 23)
            Me.lblPJWorkBreakdownItem.TabIndex = 3
            Me.lblPJWorkBreakdownItem.Text = "Project Work Breakdown Structure"
            '
            'btnDelete
            '
            Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnDelete.Location = New System.Drawing.Point(296, 8)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(64, 23)
            Me.btnDelete.TabIndex = 7
            Me.btnDelete.Text = "ลบ"
            '
            'btnNew
            '
            Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnNew.Location = New System.Drawing.Point(240, 8)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(56, 23)
            Me.btnNew.TabIndex = 6
            Me.btnNew.Text = "เพิ่ม"
            '
            'WBSSetup
            '
            Me.Controls.Add(Me.btnDelete)
            Me.Controls.Add(Me.btnNew)
            Me.Controls.Add(Me.grbDetail)
            Me.Controls.Add(Me.tvProject)
            Me.Controls.Add(Me.lblPJWorkBreakdownItem)
            Me.Name = "WBSSetup"
            Me.Size = New System.Drawing.Size(672, 456)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            'Me.btnDelete.Text = Me.StringParserService.Parse("${res:Global.DeleteButtonText}")
            'Me.btnNew.Text = Me.StringParserService.Parse("${res:Global.AddButtonText}")
            'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSSetup.lblCode}")
            'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSSetup.grbDetail}")
            'Me.lblName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
            'Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            'Me.lblPJWorkBreakdownItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSSetup.lblPJWorkBreakdownItem}")

        End Sub
    End Class
End Namespace

