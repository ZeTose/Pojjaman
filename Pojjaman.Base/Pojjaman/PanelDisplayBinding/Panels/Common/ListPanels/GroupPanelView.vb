Imports System.Data.SqlClient
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports System.Drawing.Printing
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class GroupPanelView
    Inherits AbstractEntityPanelViewContent
    Implements IGroupPanel, IValidatable

#Region " Windows Form Designer generated code "

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
    Friend WithEvents ctmnuTreeGroup As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuAddGroup As Longkong.Pojjaman.Gui.Components.IconMenu
    Friend WithEvents mnuDeleteGroup As Longkong.Pojjaman.Gui.Components.IconMenu
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents tvGroup As GroupTreeView
    Public WithEvents grbDragging As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents chkAllowDrag As System.Windows.Forms.CheckBox
    Friend WithEvents imlTree As System.Windows.Forms.ImageList
    Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbSummarize As System.Windows.Forms.GroupBox
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents chkSelectChild As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GroupPanelView))
      Me.pnlFilter = New System.Windows.Forms.Panel
      Me.grbSummarize = New System.Windows.Forms.GroupBox
      Me.lblLevel = New System.Windows.Forms.Label
      Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbDragging = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkAllowDrag = New System.Windows.Forms.CheckBox
      Me.chkSelectChild = New System.Windows.Forms.CheckBox
      Me.ctmnuTreeGroup = New System.Windows.Forms.ContextMenu
      Me.mnuAddGroup = New Longkong.Pojjaman.Gui.Components.IconMenu
      Me.mnuDeleteGroup = New Longkong.Pojjaman.Gui.Components.IconMenu
      Me.Splitter1 = New System.Windows.Forms.Splitter
      Me.tvGroup = New Longkong.Pojjaman.Gui.Components.GroupTreeView
      Me.imlTree = New System.Windows.Forms.ImageList(Me.components)
      Me.pnlFilter.SuspendLayout()
      Me.grbSummarize.SuspendLayout()
      Me.grbDragging.SuspendLayout()
      Me.SuspendLayout()
      '
      'pnlFilter
      '
      Me.pnlFilter.Controls.Add(Me.grbSummarize)
      Me.pnlFilter.Controls.Add(Me.grbDragging)
      Me.pnlFilter.Controls.Add(Me.chkSelectChild)
      Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
      Me.pnlFilter.Name = "pnlFilter"
      Me.pnlFilter.Size = New System.Drawing.Size(792, 152)
      Me.pnlFilter.TabIndex = 9
      '
      'grbSummarize
      '
      Me.grbSummarize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSummarize.Controls.Add(Me.lblLevel)
      Me.grbSummarize.Controls.Add(Me.ibtnZoomOut)
      Me.grbSummarize.Controls.Add(Me.ibtnZoomIn)
      Me.grbSummarize.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummarize.Location = New System.Drawing.Point(616, 64)
      Me.grbSummarize.Name = "grbSummarize"
      Me.grbSummarize.Size = New System.Drawing.Size(168, 48)
      Me.grbSummarize.TabIndex = 14
      Me.grbSummarize.TabStop = False
      Me.grbSummarize.Text = "Summarize"
      '
      'lblLevel
      '
      Me.lblLevel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLevel.Location = New System.Drawing.Point(64, 16)
      Me.lblLevel.Name = "lblLevel"
      Me.lblLevel.Size = New System.Drawing.Size(40, 23)
      Me.lblLevel.TabIndex = 13
      Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnZoomOut
      '
      Me.ibtnZoomOut.Image = CType(resources.GetObject("ibtnZoomOut.Image"), System.Drawing.Image)
      Me.ibtnZoomOut.Location = New System.Drawing.Point(16, 16)
      Me.ibtnZoomOut.Name = "ibtnZoomOut"
      Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomOut.TabIndex = 12
      Me.ibtnZoomOut.TabStop = False
      Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnZoomIn
      '
      Me.ibtnZoomIn.Image = CType(resources.GetObject("ibtnZoomIn.Image"), System.Drawing.Image)
      Me.ibtnZoomIn.Location = New System.Drawing.Point(40, 16)
      Me.ibtnZoomIn.Name = "ibtnZoomIn"
      Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomIn.TabIndex = 11
      Me.ibtnZoomIn.TabStop = False
      Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbDragging
      '
      Me.grbDragging.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDragging.Controls.Add(Me.chkAllowDrag)
      Me.grbDragging.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDragging.Location = New System.Drawing.Point(615, 8)
      Me.grbDragging.Name = "grbDragging"
      Me.grbDragging.Size = New System.Drawing.Size(168, 48)
      Me.grbDragging.TabIndex = 13
      Me.grbDragging.TabStop = False
      Me.grbDragging.Text = "Drag?"
      '
      'chkAllowDrag
      '
      Me.chkAllowDrag.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkAllowDrag.Location = New System.Drawing.Point(24, 16)
      Me.chkAllowDrag.Name = "chkAllowDrag"
      Me.chkAllowDrag.Size = New System.Drawing.Size(128, 24)
      Me.chkAllowDrag.TabIndex = 0
      Me.chkAllowDrag.Text = "Drag?"
      '
      'chkSelectChild
      '
      Me.chkSelectChild.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkSelectChild.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkSelectChild.Location = New System.Drawing.Point(488, 80)
      Me.chkSelectChild.Name = "chkSelectChild"
      Me.chkSelectChild.Size = New System.Drawing.Size(128, 24)
      Me.chkSelectChild.TabIndex = 0
      Me.chkSelectChild.Text = "Also Select Child"
      '
      'ctmnuTreeGroup
      '
      Me.ctmnuTreeGroup.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddGroup, Me.mnuDeleteGroup})
      '
      'mnuAddGroup
      '
      Me.mnuAddGroup.BackColor = System.Drawing.SystemColors.Window
      Me.mnuAddGroup.BarColor = System.Drawing.SystemColors.Menu
      Me.mnuAddGroup.FrameColor = System.Drawing.SystemColors.InactiveCaption
      Me.mnuAddGroup.Icon = CType(resources.GetObject("mnuAddGroup.Icon"), System.Drawing.Image)
      Me.mnuAddGroup.Index = 0
      Me.mnuAddGroup.OwnerDraw = True
      Me.mnuAddGroup.SelectionColor = System.Drawing.SystemColors.InactiveCaption
      Me.mnuAddGroup.ShortcutText = ""
      Me.mnuAddGroup.Text = "เพิ่ม"
      '
      'mnuDeleteGroup
      '
      Me.mnuDeleteGroup.BackColor = System.Drawing.SystemColors.Window
      Me.mnuDeleteGroup.BarColor = System.Drawing.SystemColors.Menu
      Me.mnuDeleteGroup.FrameColor = System.Drawing.SystemColors.InactiveCaption
      Me.mnuDeleteGroup.Icon = CType(resources.GetObject("mnuDeleteGroup.Icon"), System.Drawing.Image)
      Me.mnuDeleteGroup.Index = 1
      Me.mnuDeleteGroup.OwnerDraw = True
      Me.mnuDeleteGroup.SelectionColor = System.Drawing.SystemColors.InactiveCaption
      Me.mnuDeleteGroup.ShortcutText = ""
      Me.mnuDeleteGroup.Text = "ลบ"
      '
      'Splitter1
      '
      Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Splitter1.Location = New System.Drawing.Point(0, 152)
      Me.Splitter1.Name = "Splitter1"
      Me.Splitter1.Size = New System.Drawing.Size(792, 3)
      Me.Splitter1.TabIndex = 10
      Me.Splitter1.TabStop = False
      '
      'tvGroup
      '
      Me.tvGroup.AllowDrop = True
      Me.tvGroup.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tvGroup.FullRowSelect = True
      Me.tvGroup.HideSelection = False
      Me.tvGroup.ImageList = Me.imlTree
      Me.tvGroup.Location = New System.Drawing.Point(0, 155)
      Me.tvGroup.Name = "tvGroup"
      Me.tvGroup.Size = New System.Drawing.Size(792, 328)
      Me.tvGroup.TabIndex = 11
      '
      'imlTree
      '
      Me.imlTree.ImageSize = New System.Drawing.Size(16, 16)
      Me.imlTree.TransparentColor = System.Drawing.Color.Transparent
      '
      'GroupPanelView
      '
      Me.Controls.Add(Me.tvGroup)
      Me.Controls.Add(Me.Splitter1)
      Me.Controls.Add(Me.pnlFilter)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "GroupPanelView"
      Me.Size = New System.Drawing.Size(792, 483)
      Me.pnlFilter.ResumeLayout(False)
      Me.grbSummarize.ResumeLayout(False)
      Me.grbDragging.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As TreeBaseEntity
    Private m_selectedEntity As TreeBaseEntity
    Private Shared m_formCount As Integer
    Private m_NewNode As TreeNode
    Private m_NewEntity As TreeBaseEntity
    Public Const AddBehavior As AddNodeBehavior = AddNodeBehavior.AddSingle
    Private m_owner As IHelperCapable
    Private m_view As PanelView

    Private m_filterSubPanel As IFilterSubPanel

    Private m_selectionMode As Selection

    Private m_basketItems As BasketItemCollection
    Private m_proposedBasketItems As BasketItemCollection

    Private m_otherFilters As Filter()

    Public CanDrag As Boolean = False
    Public CanDragToParent As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      Dim mode As Selection = Selection.MultiSelect
      If TypeOf handler Is NamedEntityOperationDelegate Then
        mode = Selection.SingleSelect
      End If
      If TypeOf entity Is TreeBaseEntity Then
        Construct(CType(entity, TreeBaseEntity), mode, basket, filters, entities)
      End If
    End Sub
    Private Sub Construct(ByVal entity As TreeBaseEntity, ByVal mode As Selection, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      InitializeComponent()
      m_entity = entity
      Me.SetLabelText()
      Me.TitleName = Me.Text
      Me.PanelName = Me.Name

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If entities Is Nothing Then
        m_filterSubPanel = myEntityPanelService.GetFilterSubPanel(m_entity)
      Else
        m_filterSubPanel = myEntityPanelService.GetFilterSubPanel(m_entity, entities)
      End If

      Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
      Me.pnlFilter.Controls.Add(filterControl)
      Me.pnlFilter.Height = Math.Max(filterControl.Height, Me.grbDragging.Height + Me.grbSummarize.Height + 20)
      Me.pnlFilter.Width = filterControl.Width + 20
      Me.Width = Me.pnlFilter.Width
      AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf Search 'btnSearch_Click

      'Filter อื่น
      m_otherFilters = filters


      'Me.m_entity.PopulateTree(tvGroup, m_filterSubPanel.GetFilterArray)
      m_selectionMode = mode
      Select Case m_selectionMode
        Case Selection.None, Selection.SingleSelect
          Me.chkSelectChild.Visible = False
          Me.tvGroup.CheckBoxes = False
          Me.CanDrag = Me.chkAllowDrag.Checked
        Case Else
          Me.chkSelectChild.Visible = True
          Me.dlg = basket
          Me.tvGroup.CheckBoxes = True
          Me.CanDrag = False
      End Select

      Search(Nothing, Nothing)
      If Me.tvGroup.Nodes.Count > 0 Then
        tvGroup.SelectedNode = tvGroup.Nodes(0)
      End If
      If Me.tvGroup.SelectedNode Is Nothing Then
        SelectNewEntity()
      End If

      m_basketItems = New BasketItemCollection
      m_proposedBasketItems = New BasketItemCollection

      'm_selectionMode = mode
      'Select Case m_selectionMode
      '  Case Selection.None, Selection.SingleSelect
      '    Me.chkSelectChild.Visible = False
      '    Me.tvGroup.CheckBoxes = False
      '    Me.CanDrag = Me.chkAllowDrag.Checked
      '  Case Else
      '    Me.chkSelectChild.Visible = True
      '    Me.dlg = basket
      '    Me.tvGroup.CheckBoxes = True
      '    Me.CanDrag = False
      'End Select

      m_dragTimer.Interval = 200
      AddHandler m_dragTimer.Tick, AddressOf Timer_Tick

      Dim myIConService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
      Me.imlTree.Images.Add(myIConService.GetBitmap(Me.Entity.ListPanelIcon))
      Me.imlTree.Images.Add(myIConService.GetBitmap(Me.Entity.ListPanelIcon & ".Cut"))
    End Sub
#End Region

#Region "Properties"
    Public Enum Selection
      None
      MultiSelect
      SingleSelect
    End Enum
    Public ReadOnly Property SelectionMode() As Selection
      Get
        Return Me.m_selectionMode
      End Get
    End Property
#End Region

#Region "Methods"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.Text
      ElseIf Not Me.m_selectedEntity Is Nothing Then
        Me.TitleName = Me.m_selectedEntity.TabPageText
      End If
    End Sub
    Private Function CleanSQL(ByVal txt As String) As String
      Return txt.Replace("'", "''")
    End Function
    Private Sub Search(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim filters As Filter() = Me.m_filterSubPanel.GetFilterArray
      Dim otherLength As Integer = 0
      If Not m_otherFilters Is Nothing AndAlso m_otherFilters.Length > 0 Then
        otherLength = m_otherFilters.Length
      End If
      Dim newfilters(filters.Length + otherLength - 1) As Filter
      For i As Integer = 0 To filters.Length - 1
        newfilters(i) = filters(i)
      Next
      If otherLength > 0 Then
        For i As Integer = 0 To otherLength - 1
          newfilters(i + filters.Length) = m_otherFilters(i)
        Next
      End If

      Me.m_entity.PopulateTree(tvGroup, newfilters)
      TreeViewHelper.Search(Me.tvGroup, "")
      'If TypeOf Me.m_entity Is CostCenter Then
      '   m_level = 2
      '   TreeViewHelper.TraverseNode(Me.tvGroup.Nodes(0), AddressOf Summarize, m_level)
      '   Me.lblLevel.Text = m_level.ToString()
      'Else
      If TypeOf Me.m_entity Is Account Then
        'If Not filters Is Nothing AndAlso filters.Length > 1 Then ' 1 for status 
        '    Me.tvGroup.ExpandAll()
        'Else
        '    m_level = 0
        '    Me.tvGroup.CollapseAll()
        '    Me.lblLevel.Text = m_level.ToString()
        'End If
        Me.tvGroup.ExpandAll()
      Else
        Me.tvGroup.ExpandAll()
      End If

      'For Each node As TreeNode In Me.tvGroup.Nodes
      '  CheckChild(node)
      'Next

    End Sub
#End Region

#Region "TreeView Events"
    Private m_draggedNode As TreeNode
    Private m_tmpDropNode As TreeNode
    Private imlDraggedNode As New ImageList
    Private m_Ticks As Long
        Private m_dragTimer As New Timer
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

    Private Sub tvGroup_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tvGroup.DoubleClick
      Dim tv As TreeView = CType(sender, TreeView)
      If Not Me.WorkbenchWindow Is Nothing Then
        If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
          CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity = Me.m_selectedEntity
        End If
        If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
          Me.WorkbenchWindow.SwitchView(1)
        End If
        Return
      End If
      If Not Me.m_selectedEntity Is Nothing Then
        If Me.m_selectedEntity.IsControlGroup Then
          If TypeOf Me.m_selectedEntity Is IControlItem Then
            Dim msgString As String = CType(Me.m_selectedEntity, IControlItem).ControlMessage
            MessageService.ShowMessage(msgString)
            Me.m_selectedEntity = Nothing
            Return
          End If
        End If
      End If
      Me.OnEntitySelected(Me.SelectedEntity)
      If Not Me.SelectionMode = Selection.MultiSelect AndAlso Not Me.FindForm Is Nothing Then
        Me.FindForm.Close()
      End If
    End Sub
    Private Sub tvGroup_QueryContinueDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles tvGroup.QueryContinueDrag
      If e.EscapePressed Then
        e.Action = DragAction.Cancel
      End If
    End Sub
    Private Sub tvGroup_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvGroup.DragDrop
      'Unlock updates
      DragHelper.ImageList_DragLeave(Me.tvGroup.Handle)

      Dim pt As Point = tvGroup.PointToClient(New Point(e.X, e.Y))
      Dim targetNode As TreeNode = tvGroup.GetNodeAt(pt)

      Dim sourceNode As TreeNode = Me.m_draggedNode 'DirectCast(e.Data.GetData(Me.Entity.FullClassName), TreeNode)
      Try
        If Not targetNode.Bounds.Contains(pt) Then
          If e.X < targetNode.Bounds.X And CanDragToParent Then
            'ย้ายไปที่ root
            SwitchTreeParent(sourceNode, sourceNode)
            sourceNode.Remove()
            tvGroup.Nodes.Add(sourceNode)
            tvGroup.SelectedNode = sourceNode
            sourceNode.EnsureVisible()
          End If
          Dim myentity As TreeBaseEntity = CType(SimpleBusinessEntityBase.GetEntity(Me.Entity.FullClassName, CInt(sourceNode.Tag)), TreeBaseEntity)
          Me.RefreshData(myentity)
          Me.RefreshData(sourceNode.Tag.ToString)
          Return
        End If
        If Not TreeViewHelper.IsAncecstor(sourceNode, targetNode) And Not sourceNode Is targetNode And Not targetNode Is sourceNode.Parent Then
          SwitchTreeParent(sourceNode, targetNode)
          sourceNode.Remove()
          targetNode.Nodes.Add(sourceNode)
          tvGroup.SelectedNode = sourceNode
          sourceNode.EnsureVisible()
        Else
          If sourceNode.Parent Is targetNode Then
                        'MessageService.ShowMessage("ไม่จำเป็นต้องย้ายเพราะ '" & sourceNode.ToString & "' อยู่ภายใต้ '" & targetNode.ToString & "' อยู่แล้ว")
                        msgServ.ShowMessage("${res:ShowMessage.CostCenterPanelView.dispensable}" & " '" & sourceNode.ToString & "' " & "${res:ShowMessage.CostCenterPanelView.IsUnder}" & " '" & targetNode.ToString & "' " & "${res:ShowMessage.CostCenterPanelView.Orready}")

          ElseIf targetNode Is sourceNode Then
            'MessageBox.Show("ไม่สามารถย้ายได้เพราะลูกกับแม่เป็นกลุ่มเดียวกัน")
          Else
                        ' MessageService.ShowMessage("ไม่สามารถย้ายได้ '" & targetNode.ToString & "' อยู่ภายใต้ '" & sourceNode.ToString & "'")
                        MessageService.ShowMessage("${res:ShowMessage.CostCenterPanelView.NotMove}" & " '" & targetNode.ToString & "' " & "${res:ShowMessage.CostCenterPanelView.IsUnder}" & " '" & sourceNode.ToString & "'")

          End If
        End If
        Dim entity As TreeBaseEntity = CType(SimpleBusinessEntityBase.GetEntity(Me.Entity.FullClassName, CInt(sourceNode.Tag)), TreeBaseEntity)
        Me.RefreshData(entity)
        Me.RefreshData(sourceNode.Tag.ToString)
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
      Me.m_dragTimer.Enabled = False
      Me.tvGroup.Invalidate()
    End Sub
    Private Sub tvGroup_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvGroup.DragOver

      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)

      'Compute drag position and move image
      Dim formP As Point = Me.PointToClient(New Point(e.X, e.Y))
      DragHelper.ImageList_DragMove(formP.X - Me.tvGroup.Left, formP.Y) '- Me.tvGroup.Top)

      'Get actual drop node
      Dim dropNode As TreeNode = Me.tvGroup.GetNodeAt(Me.tvGroup.PointToClient(New Point(e.X, e.Y)))
      If dropNode Is Nothing Or Not CanDrag Then
        'ไม่มี Node หรือ ห้าม Move
        'myStatusBarService.SetMessage("ไม่มี Node หรือ ห้าม Move:" & CanDrag.ToString)
        e.Effect = DragDropEffects.None
        Return
      End If

      If Not dropNode.Bounds.Contains(formP) Then
        'ตำแหน่ง mouse อยู่นอก dropNode ไปทางซ้าย
        If e.X < dropNode.Bounds.X Then
          e.Effect = DragDropEffects.None
          'myStatusBarService.SetMessage("ตำแหน่ง mouse อยู่นอก dropNode ไปทางซ้าย")
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
        'myStatusBarService.SetMessage("cyclic")
        Return
      End If

      'myStatusBarService.SetMessage("Can Move")

      ' if mouse is on a new node select it
      If Not Me.m_tmpDropNode Is dropNode Then
        DragHelper.ImageList_DragShowNolock(False)
        Me.tvGroup.SelectedNode = dropNode
        DragHelper.ImageList_DragShowNolock(True)
        m_tmpDropNode = dropNode
      End If

    End Sub
    Private Sub tvGroup_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles tvGroup.ItemDrag
      m_draggedNode = CType(e.Item, TreeNode)
      Me.tvGroup.SelectedNode = m_draggedNode

      'reset the imagelist
      Me.imlDraggedNode.Images.Clear()
      Dim w As Integer = Math.Min(Me.m_draggedNode.Bounds.Size.Width + Me.tvGroup.Indent, 256)
      Me.imlDraggedNode.ImageSize = New Size(w, Me.m_draggedNode.Bounds.Height)

      'สร้างรูปภาพเปล่าๆขนาดเท่า item ที่ถูกลาก
      Dim bmp As New Bitmap(Me.m_draggedNode.Bounds.Width + Me.tvGroup.Indent, Me.m_draggedNode.Bounds.Height)

      'สร้าง Graphics จาก bitmap
      Dim g As Graphics = Graphics.FromImage(bmp)
      Dim imgIndx As Integer = m_draggedNode.ImageIndex
      If imgIndx < 0 Then imgIndx = 0
      g.DrawImage(Me.tvGroup.ImageList.Images(imgIndx), 0, 0)

      g.DrawString(Me.m_draggedNode.Text, _
      Me.tvGroup.Font, _
      New SolidBrush(Me.tvGroup.ForeColor), _
      Me.tvGroup.Indent, 1.0F)

      Me.imlDraggedNode.Images.Add(bmp)

      'Get mouse position in client coordinates
      Dim p As Point = Me.tvGroup.PointToClient(Control.MousePosition)

      'Compute delta between mouse position and node bounds
      Dim dx As Integer = p.X + Me.tvGroup.Indent - Me.m_draggedNode.Bounds.Left
      Dim dy As Integer = p.Y - Me.m_draggedNode.Bounds.Top

      'Begin dragging image
      If (DragHelper.ImageList_BeginDrag(Me.imlDraggedNode.Handle, 0, dx, dy)) Then
        'Begin dragging
        Me.tvGroup.DoDragDrop(bmp, DragDropEffects.Move)
        'End dragging image
        DragHelper.ImageList_EndDrag()
      End If
    End Sub
    Private Sub tvGroup_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvGroup.DragEnter
      DragHelper.ImageList_DragEnter(Me.Handle, e.X - Me.Left, _
      e.Y - Me.Top)
      Me.m_dragTimer.Enabled = True
    End Sub
    Private Sub tvGroup_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvGroup.DragLeave
      DragHelper.ImageList_DragLeave(Me.Handle)
      Me.m_dragTimer.Enabled = False
    End Sub
    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
      ' get node at mouse position
      Dim pt As Point = PointToClient(Control.MousePosition)
      Dim node As TreeNode = Me.tvGroup.GetNodeAt(pt)

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
          Me.tvGroup.Refresh()
          'show drag image
          DragHelper.ImageList_DragShowNolock(True)
        End If
      ElseIf pt.Y > Me.tvGroup.Size.Height - 30 Then
        If Not node.NextVisibleNode Is Nothing Then
          node = node.NextVisibleNode
          DragHelper.ImageList_DragShowNolock(False)
          node.EnsureVisible()
          Me.tvGroup.Refresh()
          DragHelper.ImageList_DragShowNolock(True)
        End If
      End If
    End Sub

    Private Sub tvGroup_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvGroup.AfterSelect
      'Clear the resource
      If m_entitySeting Then
        Return
      End If
      'Application.DoEvents()
      Me.m_selectedEntity = Nothing
      If Not e.Node Is Nothing Then
        If TypeOf e.Node.Tag Is TreeBaseEntity Then
          Me.m_selectedEntity = CType(e.Node.Tag, TreeBaseEntity)
          If Not Me.m_selectedEntity Is Nothing Then
            AddHandler Me.m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
          End If
        Else
          Me.m_selectedEntity = CType(SimpleBusinessEntityBase.GetEntity(Me.Entity.FullClassName, CInt(e.Node.Tag)), TreeBaseEntity)
          If Not Me.m_selectedEntity Is Nothing Then
            AddHandler Me.m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
          End If
        End If
        If Not Me.WorkbenchWindow Is Nothing Then
          RefreshEditableStatus()
        End If
      Else
        Me.m_selectedEntity = CType(SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName), TreeBaseEntity)
        If Not Me.m_selectedEntity Is Nothing Then
          AddHandler Me.m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        End If
      End If


    End Sub
    Private Sub TryPaste(ByVal sourceNode As TreeNode, ByVal targetNode As TreeNode)
      Try
        If Not TreeViewHelper.IsAncecstor(sourceNode, targetNode) And Not sourceNode Is targetNode And Not targetNode Is sourceNode.Parent Then
          SwitchTreeParent(sourceNode, targetNode)
          sourceNode.Remove()
          targetNode.Nodes.Add(sourceNode)
          tvGroup.SelectedNode = sourceNode
          sourceNode.EnsureVisible()
        Else
          If sourceNode.Parent Is targetNode Then
                        ' MessageBox.Show("ไม่จำเป็นต้องย้ายเพราะ '" & sourceNode.ToString & "' อยู่ภายใต้ '" & targetNode.ToString & "' อยู่แล้ว")
                        msgServ.ShowMessage("${res:ShowMessage.CostCenterPanelView.dispensable}" & " '" & sourceNode.ToString & "' " & "${res:ShowMessage.CostCenterPanelView.IsUnder}" & " '" & targetNode.ToString & "' " & "${res:ShowMessage.CostCenterPanelView.Orready}")
          ElseIf targetNode Is sourceNode Then
            'MessageBox.Show("ไม่สามารถย้ายได้เพราะลูกกับแม่เป็นกลุ่มเดียวกัน")
          Else
                        'MessageBox.Show("ไม่สามารถย้ายได้ '" & targetNode.ToString & "' อยู่ภายใต้ '" & sourceNode.ToString & "'")
                        MessageService.ShowMessage("${res:ShowMessage.CostCenterPanelView.NotMove}" & " '" & targetNode.ToString & "' " & "${res:ShowMessage.CostCenterPanelView.IsUnder}" & " '" & sourceNode.ToString & "'")
          End If
        End If
        Dim entity As TreeBaseEntity = CType(SimpleBusinessEntityBase.GetEntity(Me.Entity.FullClassName, CInt(sourceNode.Tag)), TreeBaseEntity)
        Me.RefreshData(entity)
        Me.RefreshData(sourceNode.Tag.ToString)
      Catch ex As Exception
        MessageBox.Show(ex.Message & ":" & ex.StackTrace)
      End Try
    End Sub
    Private Sub SwitchTreeParent(ByVal child As TreeNode, ByVal parentNode As TreeNode)
      Try
        Dim result As Integer = Me.m_entity.ChangeParent(CInt(child.Tag), CInt(parentNode.Tag))
        If result = -1 Then
                    'MessageBox.Show("ไม่สามารถย้ายได้ '" & parentNode.ToString & "' อยู่ภายใต้ '" & child.ToString & "'")
                    MessageService.ShowMessage("${res:ShowMessage.NotMove}" & " '" & parentNode.ToString & "' " & "${res:ShowMessage.IsUnder}" & " '" & child.ToString & "'")
        ElseIf result > 0 Then
          RecursiveSwitchTreeParent(child.Nodes)
        End If
      Catch ex As Exception
                'Throw New Exception("เกิด error " & ex.Message)
                Throw New Exception("${res:ShowMessage.Error}" & " " & ex.Message)
      End Try
    End Sub
    Private Sub RecursiveSwitchTreeParent(ByVal childNodes As TreeNodeCollection)
      Dim node As TreeNode
      For Each node In childNodes
        Dim result As Integer = Me.m_entity.ChangeParent(CInt(node.Tag), CInt(node.Parent.Tag))
        If result = -1 Then
                    'MessageBox.Show("ไม่สามารถย้ายได้ '" & node.Parent.ToString & "' อยู่ภายใต้ '" & node.ToString & "'")
                    MessageService.ShowMessage("${res:ShowMessage.NotMove}" & " '" & node.Parent.ToString & "' " & "${res:ShowMessage.IsUnder}" & " '" & node.ToString & "'")

        ElseIf result > 0 Then
          RecursiveSwitchTreeParent(node.Nodes)
        End If
      Next
    End Sub
#End Region

#Region "Events"
    Private Sub chkAllowDrag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllowDrag.CheckedChanged
      Me.CanDrag = Me.chkAllowDrag.Checked
    End Sub
    Private Sub RefreshEditableStatus()
      'WorkbenchSingleton.Workbench.RedrawAllComponents()
    End Sub
    Public Sub OnEntityPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
      RaiseEvent EntityPropertyChanged(sender, e)
    End Sub
    Private Sub ctmnuTreeGroup_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuTreeGroup.Popup
      Dim pt As System.Drawing.Point
      pt = tvGroup.PointToClient(tvGroup.MousePosition)
      If Not tvGroup.SelectedNode Is Nothing AndAlso tvGroup.SelectedNode.Bounds.Contains(pt) Then
        If tvGroup.SelectedNode.GetNodeCount(False) = 0 Then
          'ไม่มีลูก -- ลบได้ เพิ่มลูกได้
          Me.mnuAddGroup.Enabled = True
          Me.mnuDeleteGroup.Enabled = True
        Else
          Me.mnuAddGroup.Enabled = True
          Me.mnuDeleteGroup.Enabled = False
        End If
      Else 'ไม่มีกลุ่มอยู่ตรงจุดที่คลิก
        Dim mn As MenuItem
        For Each mn In ctmnuTreeGroup.MenuItems
          mn.Enabled = False
        Next
      End If
    End Sub
#End Region

#Region "IGroupPanel"
    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IGroupPanel.EntityPropertyChanged
    Public Sub CheckFormEnable() Implements IGroupPanel.CheckFormEnable

    End Sub

    Public Sub ClearDetail() Implements IGroupPanel.ClearDetail

    End Sub

    Public Sub UpdateEntityProperties() Implements IGroupPanel.UpdateEntityProperties

    End Sub
    Public Property Entity() As ISimpleEntity Implements IGroupPanel.Entity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, TreeBaseEntity)
      End Set
    End Property
    Public ReadOnly Property Icon() As String Implements IGroupPanel.Icon
      Get
        Return Me.m_entity.ListPanelIcon
      End Get
    End Property
    Public ReadOnly Property Title() As String Implements IGroupPanel.Title
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
    Private Sub SetLabelText() Implements IGroupPanel.SetLabelText
      If Not m_entity Is Nothing Then
        Me.Text = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      End If
      Me.grbDragging.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupPanelView.grbDragging}")
      Me.chkAllowDrag.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GroupPanelView.chkAllowDrag}")
    End Sub
    Public Sub ShowInPad() Implements IGroupPanel.ShowInPad
      'Dim myListPad As IPadContent = WorkbenchSingleton.Workbench.GetPad(Me.m_entity.ClassName)
      'If Not myListPad Is Nothing Then
      '    WorkbenchSingleton.Workbench.WorkbenchLayout.ActivatePad(myListPad)
      'Else
      '    Dim pad As New PanelPad(Me, True)
      '    pad.DockAreas = New String() {"Float"}
      '    WorkbenchSingleton.Workbench.ShowPad(pad)
      'End If
    End Sub
    'Public Sub HidePad()
    'Dim myListPad As IPadContent = WorkbenchSingleton.Workbench.GetPad(Me.m_entity.ClassName)
    'If Not myListPad Is Nothing Then
    'WorkbenchSingleton.Workbench.WorkbenchLayout.HidePad(myListPad)
    'End If
    'End Sub

    Public Event EntitySelected(ByVal e As ISimpleEntity) Implements ISimpleListPanel.EntitySelected
    Public Sub OnEntitySelected(ByVal e As ISimpleEntity)
      RaiseEvent EntitySelected(e)
    End Sub
    Private m_entitySeting As Boolean
    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements IGroupPanel.SelectedEntity
      Get
        Return m_selectedEntity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        'If m_selectedEntity Is Nothing OrElse CType(m_selectedEntity, Object).Equals(Value) Then
        '    Return
        'End If
        Me.m_selectedEntity = CType(Value, TreeBaseEntity)
        If Not m_selectedEntity Is Nothing Then
          'เอาออก ให้ตอน save เร็วขึ้น
          'Me.RefreshData(m_selectedEntity.Id.ToString)
        End If

        'If CType(m_selectedEntity, Object).Equals(Value) Then
        '    Return
        'End If
        'Me.m_selectedEntity = CType(Value, TreeBaseEntity)
        'If Not m_selectedEntity Is Nothing Then
        '    m_entitySeting = True
        '    Me.RefreshData(m_selectedEntity)
        '    m_entitySeting = False
        '    RefreshEditableStatus()
        'End If
      End Set
    End Property
    Public Sub RefreshData(ByVal id As String) Implements IGroupPanel.RefreshData
      Search(Nothing, Nothing)
      If IsNumeric(id) Then
        Dim node As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(id))
        If Not node Is Nothing Then
          tvGroup.SelectedNode = node
          node.EnsureVisible()
        End If
      End If
      If tvGroup.SelectedNode Is Nothing Then
        tvGroup.SelectedNode = tvGroup.Nodes(0)
      End If
    End Sub
    Public Sub RefreshData(ByVal entity As TreeBaseEntity) Implements IGroupPanel.RefreshData
      Search(Nothing, Nothing)
      If entity Is Nothing OrElse Not entity.Originated Then
        Try
          Dim flag As Boolean = m_entitySeting
          m_entitySeting = False
          Me.tvGroup.SelectedNode = Nothing
          Me.tvGroup.SelectedNode = Me.tvGroup.Nodes(0)
          m_entitySeting = flag
        Catch ex As Exception

        End Try
        Return
      End If
      If TreeViewHelper.SearchTag(tvGroup, entity.Id) Is Nothing Then
        'เพิ่ง add เข้ามา
        Dim newNode As New TreeNode(entity.Code & " - " & entity.Name)
        newNode.Tag = entity.Id
        If entity.Parent Is Nothing OrElse entity.Parent.Id = entity.Id OrElse Not entity.Parent.Originated Then
          'ใต้ root
          Dim newPosition As Integer = TreeViewHelper.GetChildIndex(tvGroup.Nodes, newNode)
          If newPosition = tvGroup.Nodes.Count Then
            tvGroup.Nodes.Add(newNode)
          Else
            tvGroup.Nodes.Insert(newPosition, newNode)
          End If
        Else
          'มี parent
          Dim parnode As TreeNode = TreeViewHelper.SearchTag(tvGroup, entity.Parent.Id)
          If Not parnode Is Nothing Then
            Dim newPosition As Integer = TreeViewHelper.GetChildIndex(tvGroup.Nodes, newNode)
            If newPosition = parnode.Nodes.Count Then
              parnode.Nodes.Add(newNode)
            Else
              parnode.Nodes.Insert(newPosition, newNode)
            End If
          End If
        End If
        tvGroup.SelectedNode = newNode
        newNode.EnsureVisible()
        Return
      End If
      Dim node As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(entity.Id))
      If Not node Is Nothing Then
        node.Text = entity.Code & " - " & entity.Name
        Dim nodes As TreeNodeCollection
        If node.Parent Is Nothing Then
          nodes = tvGroup.Nodes
        Else
          nodes = node.Parent.Nodes
        End If
        nodes.Remove(node)
        Dim newPosition As Integer = TreeViewHelper.GetChildIndex(nodes, node)
        If newPosition = nodes.Count Then
          nodes.Add(node)
        Else
          nodes.Insert(newPosition, node)
        End If
        tvGroup.SelectedNode = node
        node.EnsureVisible()
      End If
    End Sub
    Public Sub SelectNewEntity()
      Me.m_selectedEntity = CType(SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName), TreeBaseEntity)
      m_selectedEntity.Parent = m_selectedEntity
      'AddHandler Me.m_selectedEntity.PropertyChanged, AddressOf Me.OnEntityPropertyChanged
    End Sub
    Public Sub Initialize() Implements ISimpleEntityPanel.Initialize

    End Sub
    Public Sub AddNew() Implements IGroupPanel.AddNew
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        Dim newParent As TreeBaseEntity = Me.m_selectedEntity
        If TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Or (newParent Is Nothing OrElse Not newParent.Originated) Then
          If Not Me.m_selectedEntity Is Nothing AndAlso Not Me.m_selectedEntity.Parent Is Nothing AndAlso Me.m_selectedEntity.Parent.Originated Then
            newParent = Me.m_selectedEntity.Parent
          End If
        End If
        Me.m_selectedEntity = CType(SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName), TreeBaseEntity)
        If Not m_selectedEntity Is Nothing Then
          If Not newParent Is Nothing Then
            m_selectedEntity.Parent = newParent
          End If
          'AddHandler Me.m_selectedEntity.PropertyChanged, AddressOf Me.OnEntityPropertyChanged
          If TypeOf m_selectedEntity Is ICodeGeneratable Then
            CType(m_selectedEntity, ICodeGeneratable).AutoGen = BusinessLogic.Entity.GetAutoGenStatus(m_selectedEntity.ClassName)
          End If
        End If
        If TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
          For Each view As ISimpleEntityPanel In Me.WorkbenchWindow.SubViewContents
            view.Entity = m_selectedEntity
          Next
        End If
        If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
          Me.WorkbenchWindow.SwitchView(1)
        End If
      End If
    End Sub
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
                Return "${res:Longkong.Pojjaman.Gui.Panels.Global.ItemList}" '"รายการ"
      End Get
    End Property
    Public Overrides Sub Deselected()
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        If Not m_selectedEntity Is Nothing Then
          AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        End If
      End If
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        If Not Me.WorkbenchWindow Is Nothing AndAlso Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
          If TypeOf Me.WorkbenchWindow.SubViewContents(1) Is IValidatable Then
            Return CType(Me.WorkbenchWindow.SubViewContents(1), IValidatable).FormValidator
          End If
        End If
      End Get
    End Property
#End Region

#Region "IBasketCollectable"
    Private dlg As BasketDialog
    Private checkIds As ArrayList
    Private Sub GetCheckNodes(ByVal nodes As TreeNodeCollection)
      For Each node As TreeNode In nodes
        If node.Checked Then
          Dim id As Integer = CInt(node.Tag)
          checkIds.Add(id)
        End If
        GetCheckNodes(node.Nodes)
      Next
    End Sub
    Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
      Get
        m_basketItems.Clear()
        checkIds = New ArrayList
        GetCheckNodes(Me.tvGroup.Nodes)
        Dim idList As String = ""
        For Each id As Integer In checkIds
          idList &= "|" & id.ToString & "|"
        Next
        Dim filters(0) As Filter
        filters(0) = New Filter("IncludeIdList", idList)
        Dim dt As DataTable = m_entity.GetListDataSet("", filters).Tables(1)
        Dim newCheckIds As New ArrayList
        If TypeOf Me.m_entity Is TreeBaseEntity AndAlso TypeOf Me.m_entity Is Account Then
          For Each id As Integer In checkIds
            Dim newAcc As New Account(id)
            If newAcc.IsControlGroup Then
              If checkIds.Count = 1 Then
                MessageService.ShowMessage(newAcc.ControlMessage)
                m_basketItems.Clear()
                Return m_basketItems
              End If
            Else
              newCheckIds.Add(id)
            End If
          Next
        End If
        For Each id As Integer In newCheckIds
          Dim row As DataRow = dt.Select(m_entity.Prefix & "_id=" & id.ToString)(0)
          Dim basketitem As New BasketItem(CInt(row(m_entity.Prefix & "_id")), row(m_entity.Prefix & "_code").ToString, m_entity.FullClassName, row(m_entity.Prefix & "_code").ToString)
          basketitem.Tag = row
          m_basketItems.Add(basketitem)
        Next
        Return m_basketItems
      End Get
    End Property
    Public Overrides ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection
      Get
        Return m_proposedBasketItems
      End Get
    End Property
#End Region

#Region "IClipboardHandler"
    Public Overrides Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim oldData As IDataObject = Clipboard.GetDataObject
      If oldData.GetDataPresent(Me.Entity.FullClassName) Then
        Dim id As Integer = CInt(oldData.GetData(Me.Entity.FullClassName))
        Dim oldCopiedNode As TreeNode = TreeViewHelper.SearchTag(tvGroup, id)
        If Not oldCopiedNode Is Nothing Then
          oldCopiedNode.SelectedImageIndex = 0
          oldCopiedNode.ImageIndex = 0
        End If
      End If

      Dim newData As New DataObject
      newData.SetData(Me.Entity.FullClassName, tvGroup.SelectedNode.Tag)
      Clipboard.SetDataObject(newData)
      Me.RefreshEditableStatus()
    End Sub
    Public Overrides Sub Cut(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim oldData As IDataObject = Clipboard.GetDataObject
      If oldData.GetDataPresent(Me.Entity.FullClassName) Then
        Dim id As Integer = CInt(oldData.GetData(Me.Entity.FullClassName))
        Dim oldCopiedNode As TreeNode = TreeViewHelper.SearchTag(tvGroup, id)
        If Not oldCopiedNode Is Nothing Then
          oldCopiedNode.SelectedImageIndex = 0
          oldCopiedNode.ImageIndex = 0
        End If
      End If

      Dim newData As New DataObject
      newData.SetData(Me.Entity.FullClassName, tvGroup.SelectedNode.Tag)
      tvGroup.SelectedNode.SelectedImageIndex = 1
      tvGroup.SelectedNode.ImageIndex = 1
      Clipboard.SetDataObject(newData)
      Me.RefreshEditableStatus()
    End Sub
    Public Overrides ReadOnly Property EnableCopy() As Boolean
      Get
        If Not Me.m_selectedEntity Is Nothing AndAlso Me.m_selectedEntity.Valid AndAlso Not tvGroup.SelectedNode Is Nothing Then
          Return True
        End If
      End Get
    End Property
    Public Overrides ReadOnly Property EnableCut() As Boolean
      Get
        If Not Me.m_selectedEntity Is Nothing AndAlso Me.m_selectedEntity.Originated AndAlso Not tvGroup.SelectedNode Is Nothing Then
          Return True
        End If
        Return False
      End Get
    End Property
    Public Overrides ReadOnly Property EnableDelete() As Boolean
      Get
        If TypeOf Me.m_selectedEntity Is Account Then
          If Not Me.m_selectedEntity Is Nothing AndAlso Me.m_selectedEntity.Originated AndAlso Not tvGroup.SelectedNode Is Nothing Then
            If tvGroup.SelectedNode.Nodes.Count = 0 Then
              Return True
            End If
          End If
        End If
      End Get
    End Property
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent(Me.Entity.FullClassName) Then
          Dim id As Integer = CInt(data.GetData(Me.Entity.FullClassName))
          Dim copiedNode As TreeNode = TreeViewHelper.SearchTag(tvGroup, id)
          If Not copiedNode Is Nothing AndAlso copiedNode.ImageIndex = 1 AndAlso Not tvGroup.SelectedNode Is Nothing Then
            Return True
          End If
        End If
        If Not Me.m_filterSubPanel Is Nothing Then
          Return Me.m_filterSubPanel.EnablePaste
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent(Me.Entity.FullClassName) Then
        Dim id As Integer = CInt(data.GetData(Me.Entity.FullClassName))
        Dim copiedNode As TreeNode = TreeViewHelper.SearchTag(tvGroup, id)
        If copiedNode.ImageIndex = 1 Then
          TryPaste(copiedNode, tvGroup.SelectedNode)
          copiedNode.ImageIndex = 0
          copiedNode.SelectedImageIndex = 0
          Clipboard.SetDataObject(New DataObject)
        End If
      End If
      If Not Me.m_filterSubPanel Is Nothing AndAlso Me.m_filterSubPanel.EnablePaste Then
        Me.m_filterSubPanel.Paste(sender, e)
      End If
      Me.RefreshEditableStatus()
    End Sub
    Public Overrides Sub Delete(ByVal sender As Object, ByVal e As System.EventArgs)
      If TypeOf Me.m_selectedEntity Is Account Then
        If Not Me.m_selectedEntity Is Nothing AndAlso Me.m_selectedEntity.Originated AndAlso Not tvGroup.SelectedNode Is Nothing Then
          If tvGroup.SelectedNode.Nodes.Count = 0 Then
            Dim saveError As SaveErrorException = CType(Me.m_selectedEntity, Account).Delete()
            If Not IsNumeric(saveError.Message) Then  'Todo
              If Not saveError.Params Is Nothing AndAlso saveError.Params.Length > 0 Then
                Me.MessageService.ShowMessageFormatted(saveError.Message, saveError.Params)
              Else
                Me.MessageService.ShowMessage(saveError.Message)
              End If
            Else
              If Not Me.tvGroup.SelectedNode Is Nothing Then
                Me.tvGroup.SelectedNode.Remove()
              End If
            End If
          End If
        End If
      End If
    End Sub
#End Region

#Region "IPrintable"
    Private m_pageCount As Integer
    Private m_currentPage As Integer
    Private m_treeString As String
    Private m_treeStrings As String()
    Private m_rowsPerPage As Integer = 50
    Private m_startX As Integer = 50
    Private m_startY As Integer = 50
    Private m_rowHeight As Integer = 10
    Private Sub Init()
      m_pageCount = 0
      m_currentPage = 0
      m_treeString = TreeViewHelper.GetTreeString(Me.tvGroup)
      m_treeStrings = Me.m_treeString.Split(vbCrLf.ToCharArray)
      Dim cnt As Integer = m_treeStrings.Length
      Dim pgs As Integer = CInt(Math.Ceiling(cnt / (m_rowsPerPage * 2)))
      m_pageCount = pgs
    End Sub
    Private Function GetPageCount() As Integer
      Return m_pageCount
    End Function
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Return Me.tvGroup.GetNodeCount(True) > 0
      End Get
    End Property
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Init()
        Dim pd As New System.Drawing.Printing.PrintDocument
        AddHandler pd.PrintPage, AddressOf PrintPage_Handler
        Return pd
      End Get
    End Property
    Private Sub PrintPage_Handler(ByVal sender As Object, ByVal pe As PrintPageEventArgs)
      Me.m_currentPage += 1
      Try
        Dim startRow As Integer = ((m_currentPage - 1) * m_rowsPerPage * 2)
        Dim colOffset As Integer = 0
        Dim verticalInterval As Integer = 5
        Dim horizontalInterval As Integer = 5
        For i As Integer = startRow To (m_rowsPerPage * 2 + startRow - 1)
          If i > m_treeStrings.Length - 1 Then
            Exit For
          End If
          Dim data As String
          data = m_treeStrings(i)
          Dim dataFont As Font = Me.Font
          Dim textSize As SizeF = pe.Graphics.MeasureString(data, dataFont)
          Dim stf As New StringFormat
          stf.Trimming = StringTrimming.EllipsisWord
          stf.LineAlignment = StringAlignment.Center
          stf.Alignment = StringAlignment.Near
          Dim x1 As Integer = m_startX
          Dim y1 As Integer = m_startY + (i - startRow) * m_rowHeight
          Dim drawRect As New RectangleF(x1, y1, textSize.Width, textSize.Height)
          pe.Graphics.DrawString(data, dataFont, New SolidBrush(Me.ForeColor), drawRect, stf)
        Next
        If m_currentPage < Me.m_pageCount Then
          pe.HasMorePages = True
        Else
          pe.HasMorePages = False
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
#End Region

#Region "Summarize"
    Private m_level As Integer
    Private m_affected As Boolean
    Private Sub ibtnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomOut.Click
      If m_level > 0 Then
        m_level -= 1
      End If
      TreeViewHelper.TraverseNode(Me.tvGroup.Nodes(0), AddressOf Summarize, m_level)
      Me.lblLevel.Text = m_level.ToString()
    End Sub
    Private Sub ibtnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomIn.Click
      m_level += 1
      m_affected = False
      TreeViewHelper.TraverseNode(Me.tvGroup.Nodes(0), AddressOf Summarize, m_level)
      If Not m_affected Then
        m_level -= 1
      End If
      Me.lblLevel.Text = m_level.ToString()
    End Sub
    Private Sub Summarize(ByVal n As TreeNode)
      If Not m_affected Then
        m_affected = True
      End If
      n.Collapse()
      n.EnsureVisible()
    End Sub
#End Region

#Region "Parent Selection"
    Private Sub tvGroup_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvGroup.AfterCheck
      If Me.chkSelectChild.Checked Then
        If e.Node.Checked Then
          TreeViewHelper.TraverseNode(e.Node, AddressOf CheckChild)
        Else
          TreeViewHelper.TraverseNode(e.Node, AddressOf UnCheckChild)
        End If
      End If
    End Sub
    Private Sub CheckChild(ByVal n As TreeNode)
      If Not n.Checked Then
        n.Checked = True
      End If
    End Sub
    Private Sub UnCheckChild(ByVal n As TreeNode)
      If n.Checked Then
        n.Checked = False
      End If
    End Sub
#End Region

  End Class
  Public Enum AddNodeBehavior
    RemoveWhenLeave
    AddSingle
    AddMultiple
  End Enum
End Namespace
