Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AccessDialog
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Form overrides dispose to clean up the component list.
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
        Friend WithEvents lvEntity As System.Windows.Forms.ListView
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblAccessName As System.Windows.Forms.Label
        Friend WithEvents txtAccessCode As System.Windows.Forms.TextBox
        Friend WithEvents txtDescription As System.Windows.Forms.TextBox
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents tvAccess As GroupTreeView
        Friend WithEvents imlTree As System.Windows.Forms.ImageList
        Friend WithEvents lblAccess As System.Windows.Forms.Label
        Friend WithEvents lblEntity As System.Windows.Forms.Label
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.lvEntity = New System.Windows.Forms.ListView
            Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ComboBox1 = New System.Windows.Forms.ComboBox
            Me.lblAccessName = New System.Windows.Forms.Label
            Me.txtAccessCode = New System.Windows.Forms.TextBox
            Me.txtDescription = New System.Windows.Forms.TextBox
            Me.lblDescription = New System.Windows.Forms.Label
            Me.Label1 = New System.Windows.Forms.Label
            Me.tvAccess = New Longkong.Pojjaman.Gui.Components.GroupTreeView
            Me.imlTree = New System.Windows.Forms.ImageList(Me.components)
            Me.lblAccess = New System.Windows.Forms.Label
            Me.lblEntity = New System.Windows.Forms.Label
            Me.btnSave = New System.Windows.Forms.Button
            Me.btnAdd = New System.Windows.Forms.Button
            Me.grbItem.SuspendLayout()
            Me.SuspendLayout()
            '
            'lvEntity
            '
            Me.lvEntity.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
            Me.lvEntity.FullRowSelect = True
            Me.lvEntity.GridLines = True
            Me.lvEntity.Location = New System.Drawing.Point(328, 176)
            Me.lvEntity.Name = "lvEntity"
            Me.lvEntity.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.lvEntity.Size = New System.Drawing.Size(360, 400)
            Me.lvEntity.TabIndex = 200
            Me.lvEntity.View = System.Windows.Forms.View.Details
            Me.lvEntity.AllowDrop = True
            '
            'ColumnHeader1
            '
            Me.ColumnHeader1.Text = "No."
            Me.ColumnHeader1.Width = 41
            '
            'ColumnHeader2
            '
            Me.ColumnHeader2.Text = "ฟอร์ม"
            Me.ColumnHeader2.Width = 269
            '
            'grbItem
            '
            Me.grbItem.Controls.Add(Me.ComboBox1)
            Me.grbItem.Controls.Add(Me.lblAccessName)
            Me.grbItem.Controls.Add(Me.txtAccessCode)
            Me.grbItem.Controls.Add(Me.txtDescription)
            Me.grbItem.Controls.Add(Me.lblDescription)
            Me.grbItem.Controls.Add(Me.Label1)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(328, 16)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(248, 136)
            Me.grbItem.TabIndex = 196
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "รายละเอียดสิทธิ"
            '
            'ComboBox1
            '
            Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ComboBox1.Items.AddRange(New Object() {"ดู/แก้ไข", "ดู/แก้ไข/สร้างใหม่", "ดู/แก้ไข/สร้างใหม่/พิมพ์", "ดู/พิมพ์"})
            Me.ComboBox1.Location = New System.Drawing.Point(72, 104)
            Me.ComboBox1.Name = "ComboBox1"
            Me.ComboBox1.Size = New System.Drawing.Size(168, 21)
            Me.ComboBox1.TabIndex = 184
            '
            'lblAccessName
            '
            Me.lblAccessName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccessName.ForeColor = System.Drawing.Color.Black
            Me.lblAccessName.Location = New System.Drawing.Point(16, 24)
            Me.lblAccessName.Name = "lblAccessName"
            Me.lblAccessName.Size = New System.Drawing.Size(56, 18)
            Me.lblAccessName.TabIndex = 183
            Me.lblAccessName.Text = "สิทธิ:"
            Me.lblAccessName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAccessCode
            '
            Me.txtAccessCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtAccessCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtAccessCode.Location = New System.Drawing.Point(72, 24)
            Me.txtAccessCode.Name = "txtAccessCode"
            Me.txtAccessCode.ReadOnly = True
            Me.txtAccessCode.Size = New System.Drawing.Size(168, 21)
            Me.txtAccessCode.TabIndex = 182
            Me.txtAccessCode.TabStop = False
            Me.txtAccessCode.Text = ""
            '
            'txtDescription
            '
            Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtDescription.Location = New System.Drawing.Point(72, 48)
            Me.txtDescription.Multiline = True
            Me.txtDescription.Name = "txtDescription"
            Me.txtDescription.ReadOnly = True
            Me.txtDescription.Size = New System.Drawing.Size(168, 48)
            Me.txtDescription.TabIndex = 182
            Me.txtDescription.TabStop = False
            Me.txtDescription.Text = ""
            '
            'lblDescription
            '
            Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDescription.ForeColor = System.Drawing.Color.Black
            Me.lblDescription.Location = New System.Drawing.Point(16, 48)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(56, 18)
            Me.lblDescription.TabIndex = 183
            Me.lblDescription.Text = "คำอธิบาย:"
            Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(16, 104)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(56, 18)
            Me.Label1.TabIndex = 183
            Me.Label1.Text = "คำอธิบาย:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tvAccess
            '
            Me.tvAccess.AllowDrop = True
            Me.tvAccess.FullRowSelect = True
            Me.tvAccess.HideSelection = False
            Me.tvAccess.ImageList = Me.imlTree
            Me.tvAccess.Location = New System.Drawing.Point(8, 24)
            Me.tvAccess.Name = "tvAccess"
            Me.tvAccess.Size = New System.Drawing.Size(312, 552)
            Me.tvAccess.TabIndex = 199
            Me.tvAccess.TabStop = False
            '
            'imlTree
            '
            Me.imlTree.ImageSize = New System.Drawing.Size(16, 16)
            Me.imlTree.TransparentColor = System.Drawing.Color.Transparent
            '
            'lblAccess
            '
            Me.lblAccess.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccess.ForeColor = System.Drawing.Color.Black
            Me.lblAccess.Location = New System.Drawing.Point(8, 8)
            Me.lblAccess.Name = "lblAccess"
            Me.lblAccess.Size = New System.Drawing.Size(40, 18)
            Me.lblAccess.TabIndex = 198
            Me.lblAccess.Text = "สิทธิ:"
            Me.lblAccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblEntity
            '
            Me.lblEntity.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEntity.ForeColor = System.Drawing.Color.Black
            Me.lblEntity.Location = New System.Drawing.Point(328, 160)
            Me.lblEntity.Name = "lblEntity"
            Me.lblEntity.Size = New System.Drawing.Size(168, 18)
            Me.lblEntity.TabIndex = 197
            Me.lblEntity.Text = "หน้าจอ:"
            Me.lblEntity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(584, 24)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.TabIndex = 201
            Me.btnSave.Text = "Save"
            '
            'btnAdd
            '
            Me.btnAdd.Location = New System.Drawing.Point(56, 0)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(32, 23)
            Me.btnAdd.TabIndex = 202
            Me.btnAdd.Text = "+"
            '
            'AccessDialog
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(704, 590)
            Me.Controls.Add(Me.btnAdd)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.lvEntity)
            Me.Controls.Add(Me.grbItem)
            Me.Controls.Add(Me.tvAccess)
            Me.Controls.Add(Me.lblEntity)
            Me.Controls.Add(Me.lblAccess)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "AccessDialog"
            Me.Text = "AccessDialog"
            Me.grbItem.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_access As Access
#End Region

        Private Sub AccessDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim myIConService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
            Me.imlTree.Images.Add(myIConService.GetBitmap("Icons.16x16.NoAccess"))
            Me.imlTree.Images.Add(myIConService.GetBitmap("Icons.16x16.FullAccess"))
            Me.imlTree.Images.Add(myIConService.GetBitmap("Icons.16x16.PartialAccess"))
            Dim accessColl As New AccessCollection(True)
            accessColl.Populate(Me.tvAccess)
        End Sub
        Public Sub UpdateAccess()
            If m_access Is Nothing Then
                Return
            End If
            Me.txtAccessCode.Text = m_access.Code
            Me.txtDescription.Text = m_access.Description
            Dim formColl As FormEntityCollection = m_access.GetFormEntityCollection
            Dim i As Integer = 0
            lvEntity.Items.Clear()
            For Each formEn As FormEntity In formColl
                i += 1
                Dim lvItem As ListViewItem = Me.lvEntity.Items.Add(i.ToString)
                lvItem.Tag = formEn.Id
                lvItem.SubItems.Add(formEn.Description)
            Next
        End Sub
        Public Sub ClearAccess()
            Me.txtAccessCode.Text = ""
            Me.txtDescription.Text = ""
        End Sub

#Region "ListView Events"
        Private m_draggedItem As ListViewItem
        Private Sub lvEntity_QueryContinueDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles lvEntity.QueryContinueDrag
            If e.EscapePressed Then
                e.Action = DragAction.Cancel
            End If
        End Sub
        Private Sub lvEntity_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvEntity.ItemDrag
            m_draggedNode = Nothing
            m_draggedItem = CType(e.Item, ListViewItem)
        End Sub
        Private Sub lvEntity_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvEntity.DragOver
            e.Effect = DragDropEffects.None
        End Sub
        Private Sub lvEntity_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvEntity.MouseMove
            If Not e.Button = MouseButtons.Left Then
                Return
            End If
            If lvEntity.SelectedItems.Count <= 0 Then
                Return
            End If
            lvEntity.DoDragDrop(lvEntity.SelectedItems(0), DragDropEffects.Move)
        End Sub
#End Region

#Region "TreeView Events"
        Private m_draggedNode As TreeNode
        Private m_tmpDropNode As TreeNode
        Private imlDraggedNode As New ImageList
        Private m_Ticks As Long
        Private m_dragTimer As New Timer
        Private Sub tvAccess_QueryContinueDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles tvAccess.QueryContinueDrag
            If e.EscapePressed Then
                e.Action = DragAction.Cancel
            End If
        End Sub
        Private Sub tvAccess_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvAccess.DragDrop
            'Unlock updates
            DragHelper.ImageList_DragLeave(Me.tvAccess.Handle)

            Dim pt As Point = tvAccess.PointToClient(New Point(e.X, e.Y))
            Dim targetNode As TreeNode = tvAccess.GetNodeAt(pt)

            Dim sourceNode As TreeNode = Me.m_draggedNode
            Dim sourceItem As ListViewItem = Me.m_draggedItem
            Try
                If Not targetNode.Bounds.Contains(pt) Then
                    If Not sourceNode Is Nothing AndAlso e.X < targetNode.Bounds.X Then
                        'ย้ายไปที่ root
                        SwitchTreeParent(sourceNode, sourceNode)
                        sourceNode.Remove()
                        tvAccess.Nodes.Add(sourceNode)
                        tvAccess.SelectedNode = sourceNode
                        sourceNode.EnsureVisible()
                    End If
                ElseIf Not sourceItem Is Nothing Then
                    SwitchListParent(sourceItem, targetNode)
                    tvAccess.SelectedNode = targetNode
                    Me.UpdateAccess()
                ElseIf Not TreeViewHelper.IsAncecstor(sourceNode, targetNode) And Not sourceNode Is targetNode And Not targetNode Is sourceNode.Parent Then
                    SwitchTreeParent(sourceNode, targetNode)
                    sourceNode.Remove()
                    targetNode.Nodes.Add(sourceNode)
                    tvAccess.SelectedNode = sourceNode
                    sourceNode.EnsureVisible()
                Else
                    If sourceNode.Parent Is targetNode Then
                        MessageBox.Show("ไม่จำเป็นต้องย้ายเพราะ '" & sourceNode.ToString & "' อยู่ภายใต้ '" & targetNode.ToString & "' อยู่แล้ว")
                    ElseIf targetNode Is sourceNode Then
                        'MessageBox.Show("ไม่สามารถย้ายได้เพราะลูกกับแม่เป็นกลุ่มเดียวกัน")
                    Else
                        MessageBox.Show("ไม่สามารถย้ายได้ '" & targetNode.ToString & "' อยู่ภายใต้ '" & sourceNode.ToString & "'")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Me.m_dragTimer.Enabled = False
            Me.tvAccess.Invalidate()
        End Sub
        Private Sub tvAccess_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvAccess.DragOver

            'Compute drag position and move image
            Dim formP As Point = Me.PointToClient(New Point(e.X, e.Y))
            DragHelper.ImageList_DragMove(formP.X - Me.tvAccess.Left, formP.Y) '- Me.tvAccess.Top)

            'Get actual drop node
            Dim dropNode As TreeNode = Me.tvAccess.GetNodeAt(Me.tvAccess.PointToClient(New Point(e.X, e.Y)))
            If dropNode Is Nothing Then
                'ไม่มี Node หรือ ห้าม Move
                e.Effect = DragDropEffects.None
                Return
            End If

            If Not dropNode.Bounds.Contains(formP) Then
                'ตำแหน่ง mouse อยู่นอก dropNode ไปทางซ้าย
                If e.X < dropNode.Bounds.X Then
                    e.Effect = DragDropEffects.None
                    Return
                End If
            End If

            If CBool(e.KeyState And 8) Then
                e.Effect = e.AllowedEffect And DragDropEffects.Copy
            Else
                e.Effect = e.AllowedEffect And DragDropEffects.Move
            End If

            ' Avoid that drop node is child of drag node *********
            'Todo '---> เอาไปใช้ที่อื่นได้
            Dim tmpNode As TreeNode = dropNode
            Dim cyclic As Boolean = False
            While Not tmpNode.Parent Is Nothing
                If tmpNode.Parent Is Me.m_draggedNode Then
                    cyclic = True
                    Exit While
                End If
                tmpNode = tmpNode.Parent
            End While
            If cyclic Then
                e.Effect = DragDropEffects.None
                Return
            End If

            ' if mouse is on a new node select it
            If Not Me.m_tmpDropNode Is dropNode Then
                DragHelper.ImageList_DragShowNolock(False)
                Me.tvAccess.SelectedNode = dropNode
                DragHelper.ImageList_DragShowNolock(True)
                m_tmpDropNode = dropNode
            End If

        End Sub
        Private Sub tvAccess_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles tvAccess.ItemDrag
            m_draggedItem = Nothing
            m_draggedNode = CType(e.Item, TreeNode)
            Me.tvAccess.SelectedNode = m_draggedNode

            'reset the imagelist
            Me.imlDraggedNode.Images.Clear()
            Dim w As Integer = Math.Min(Me.m_draggedNode.Bounds.Size.Width + Me.tvAccess.Indent, 256)
            Me.imlDraggedNode.ImageSize = New Size(w, Me.m_draggedNode.Bounds.Height)

            'สร้างรูปภาพเปล่าๆขนาดเท่า item ที่ถูกลาก
            Dim bmp As New Bitmap(Me.m_draggedNode.Bounds.Width + Me.tvAccess.Indent, Me.m_draggedNode.Bounds.Height)

            'สร้าง Graphics จาก bitmap
            Dim g As Graphics = Graphics.FromImage(bmp)
            Dim imgIndx As Integer = m_draggedNode.ImageIndex
            If imgIndx < 0 Then imgIndx = 0
            g.DrawImage(Me.tvAccess.ImageList.Images(imgIndx), 0, 0)

            g.DrawString(Me.m_draggedNode.Text, _
            Me.tvAccess.Font, _
            New SolidBrush(Me.tvAccess.ForeColor), _
            Me.tvAccess.Indent, 1.0F)

            Me.imlDraggedNode.Images.Add(bmp)

            'Get mouse position in client coordinates
            Dim p As Point = Me.tvAccess.PointToClient(Control.MousePosition)

            'Compute delta between mouse position and node bounds
            Dim dx As Integer = p.X + Me.tvAccess.Indent - Me.m_draggedNode.Bounds.Left
            Dim dy As Integer = p.Y - Me.m_draggedNode.Bounds.Top

            'Begin dragging image
            If (DragHelper.ImageList_BeginDrag(Me.imlDraggedNode.Handle, 0, dx, dy)) Then
                'Begin dragging
                Me.tvAccess.DoDragDrop(bmp, DragDropEffects.Move)
                'End dragging image
                DragHelper.ImageList_EndDrag()
            End If
        End Sub
        Private Sub tvAccess_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvAccess.DragEnter
            DragHelper.ImageList_DragEnter(Me.Handle, e.X - Me.Left, _
            e.Y - Me.Top)
            Me.m_dragTimer.Enabled = True
        End Sub
        Private Sub tvAccess_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvAccess.DragLeave
            DragHelper.ImageList_DragLeave(Me.Handle)
            Me.m_dragTimer.Enabled = False
        End Sub
        Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
            ' get node at mouse position
            Dim pt As Point = PointToClient(Control.MousePosition)
            Dim node As TreeNode = Me.tvAccess.GetNodeAt(pt)

            If node Is Nothing Then Return

            'if mouse is near to the top, scroll up
            If (pt.Y < 30) Then
                ' set actual node to the upper one
                If Not node.PrevVisibleNode Is Nothing Then
                    node = node.PrevVisibleNode
                    ' hide drag image
                    DragHelper.ImageList_DragShowNolock(False)
                    ' scroll and refresh
                    node.EnsureVisible()
                    Me.tvAccess.Refresh()
                    'show drag image
                    DragHelper.ImageList_DragShowNolock(True)
                End If
            ElseIf pt.Y > Me.tvAccess.Size.Height - 30 Then
                If Not node.NextVisibleNode Is Nothing Then
                    node = node.NextVisibleNode
                    DragHelper.ImageList_DragShowNolock(False)
                    node.EnsureVisible()
                    Me.tvAccess.Refresh()
                    DragHelper.ImageList_DragShowNolock(True)
                End If
            End If
        End Sub
        Private Sub tvAccess_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvAccess.AfterSelect
            If TypeOf e.Node.Tag Is Access Then
                Dim myAccess As Access = CType(e.Node.Tag, Access)
                Me.m_access = myAccess
                UpdateAccess()
            Else
                ClearAccess()
            End If
        End Sub
        Private Sub TryPaste(ByVal sourceNode As TreeNode, ByVal targetNode As TreeNode)
            Try
                If Not TreeViewHelper.IsAncecstor(sourceNode, targetNode) And Not sourceNode Is targetNode And Not targetNode Is sourceNode.Parent Then
                    SwitchTreeParent(sourceNode, targetNode)
                    sourceNode.Remove()
                    targetNode.Nodes.Add(sourceNode)
                    tvAccess.SelectedNode = sourceNode
                    sourceNode.EnsureVisible()
                Else
                    If sourceNode.Parent Is targetNode Then
                        MessageBox.Show("ไม่จำเป็นต้องย้ายเพราะ '" & sourceNode.ToString & "' อยู่ภายใต้ '" & targetNode.ToString & "' อยู่แล้ว")
                    ElseIf targetNode Is sourceNode Then
                        'MessageBox.Show("ไม่สามารถย้ายได้เพราะลูกกับแม่เป็นกลุ่มเดียวกัน")
                    Else
                        MessageBox.Show("ไม่สามารถย้ายได้ '" & targetNode.ToString & "' อยู่ภายใต้ '" & sourceNode.ToString & "'")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message & ":" & ex.StackTrace)
            End Try
        End Sub
        Private Sub SwitchTreeParent(ByVal child As TreeNode, ByVal parentNode As TreeNode)
            Try
                Dim acc As New Access
                Dim result As Integer = acc.ChangeParent(CType(child.Tag, Access).Id, CType(parentNode.Tag, Access).Id)
                If result = -1 Then
                    MessageBox.Show("ไม่สามารถย้ายได้ '" & parentNode.ToString & "' อยู่ภายใต้ '" & child.ToString & "'")
                ElseIf result > 0 Then
                    RecursiveSwitchTreeParent(child.Nodes)
                End If
            Catch ex As Exception
                Throw New Exception("เกิด error " & ex.Message)
            End Try
        End Sub
        Private Sub RecursiveSwitchTreeParent(ByVal childNodes As TreeNodeCollection)
            Dim node As TreeNode
            For Each node In childNodes
                Dim acc As New Access
                Dim result As Integer = acc.ChangeParent(CType(node.Tag, Access).Id, CType(node.Parent.Tag, Access).Id)
                If result = -1 Then
                    MessageBox.Show("ไม่สามารถย้ายได้ '" & node.Parent.ToString & "' อยู่ภายใต้ '" & node.ToString & "'")
                ElseIf result > 0 Then
                    RecursiveSwitchTreeParent(node.Nodes)
                End If
            Next
        End Sub
        Private Sub SwitchListParent(ByVal child As ListViewItem, ByVal parentNode As TreeNode)
            Try
                Dim result As Integer = Entity.ChangeAccess(CInt(child.Tag), CType(parentNode.Tag, Access).Id)
                Entity.RefreshEntityList()
            Catch ex As Exception
                Throw New Exception("เกิด error " & ex.Message)
            End Try
        End Sub
#End Region

    End Class
End Namespace
