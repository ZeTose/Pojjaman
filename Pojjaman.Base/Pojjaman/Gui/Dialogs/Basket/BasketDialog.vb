Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BasketDialog
    Inherits System.Windows.Forms.UserControl

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
    Public WithEvents tvItems As System.Windows.Forms.TreeView
    Friend WithEvents ibtnDelete As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnAdd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnClear As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BasketDialog))
      Me.tvItems = New System.Windows.Forms.TreeView
      Me.ibtnDelete = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnAdd = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnClear = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.SuspendLayout()
      '
      'tvItems
      '
      Me.tvItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tvItems.FullRowSelect = True
      Me.tvItems.HideSelection = False
      Me.tvItems.ImageIndex = -1
      Me.tvItems.Location = New System.Drawing.Point(0, 48)
      Me.tvItems.Name = "tvItems"
      Me.tvItems.SelectedImageIndex = -1
      Me.tvItems.Size = New System.Drawing.Size(504, 328)
      Me.tvItems.TabIndex = 5
      '
      'ibtnDelete
      '
      Me.ibtnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnDelete.Image = CType(resources.GetObject("ibtnDelete.Image"), System.Drawing.Image)
      Me.ibtnDelete.Location = New System.Drawing.Point(40, 8)
      Me.ibtnDelete.Name = "ibtnDelete"
      Me.ibtnDelete.Size = New System.Drawing.Size(32, 32)
      Me.ibtnDelete.TabIndex = 207
      Me.ibtnDelete.TabStop = False
      Me.ibtnDelete.ThemedImage = CType(resources.GetObject("ibtnDelete.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDelete, "ลบออกจากตะกร้า")
      '
      'ibtnAdd
      '
      Me.ibtnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnAdd.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnAdd.Image = CType(resources.GetObject("ibtnAdd.Image"), System.Drawing.Image)
      Me.ibtnAdd.Location = New System.Drawing.Point(8, 8)
      Me.ibtnAdd.Name = "ibtnAdd"
      Me.ibtnAdd.Size = New System.Drawing.Size(32, 32)
      Me.ibtnAdd.TabIndex = 208
      Me.ibtnAdd.TabStop = False
      Me.ibtnAdd.ThemedImage = CType(resources.GetObject("ibtnAdd.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnAdd, "จับใส่ตะกร้า")
      '
      'ibtnClear
      '
      Me.ibtnClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnClear.Image = CType(resources.GetObject("ibtnClear.Image"), System.Drawing.Image)
      Me.ibtnClear.Location = New System.Drawing.Point(72, 8)
      Me.ibtnClear.Name = "ibtnClear"
      Me.ibtnClear.Size = New System.Drawing.Size(32, 32)
      Me.ibtnClear.TabIndex = 207
      Me.ibtnClear.TabStop = False
      Me.ibtnClear.ThemedImage = CType(resources.GetObject("ibtnClear.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnClear, "เทตะกร้า")
      '
      'BasketDialog
      '
      Me.Controls.Add(Me.ibtnDelete)
      Me.Controls.Add(Me.ibtnAdd)
      Me.Controls.Add(Me.tvItems)
      Me.Controls.Add(Me.ibtnClear)
      Me.Name = "BasketDialog"
      Me.Size = New System.Drawing.Size(504, 384)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_lists As ArrayList
    Private m_basketItems As BasketItemCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      SetLabelText()
      m_basketItems = New BasketItemCollection
      m_lists = New ArrayList
    End Sub
    Public Sub New(ByVal lists As ArrayList)
      MyBase.New()
      InitializeComponent()
      SetLabelText()
      m_basketItems = New BasketItemCollection
      m_lists = lists
    End Sub
#End Region

#Region "Methods"
        Dim StringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Public Sub SetLabelText()
            Me.Name = "ตะกร้า"
            Me.ToolTip1.SetToolTip(Me.ibtnClear, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BasketDialog.ibtnClear}")) ' "เทตะกร้า")
            Me.ToolTip1.SetToolTip(Me.ibtnAdd, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BasketDialog.ibtnAdd}")) '"จับใส่ตะกร้า")
            Me.ToolTip1.SetToolTip(Me.ibtnDelete, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BasketDialog.ibtnDelete}")) ' "ลบออกจากตะกร้า")
        End Sub
        Public Event EmptyBasket As BasketOperationDelegate
        Public Sub OnEmptyBasket(ByVal items As BusinessLogic.BasketItemCollection)
            RaiseEvent EmptyBasket(items)
        End Sub
#End Region

#Region "Properties"
    Public Overridable ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
      Get
        Return m_basketItems
      End Get
    End Property
    Public Property Lists() As ArrayList      Get        Return m_lists      End Get      Set(ByVal Value As ArrayList)        m_lists = Value      End Set    End Property
#End Region

#Region "Event Handlers"
    Private Sub ibtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAdd.Click
      If Me.m_lists Is Nothing OrElse m_lists.Count = 0 Then
        Return
      End If
      Dim oldBasketItems As New BasketItemCollection
      For Each bkc As IBasketCollectable In Me.m_lists
        For Each item As IBasketItem In m_basketItems
          oldBasketItems.Add(item)
        Next
        m_basketItems.AddRange(bkc.BasketItems)
        For Each item As IBasketItem In m_basketItems
          If Not oldBasketItems.Contains(item) Then
            If TypeOf item Is StockBasketItem Then
              Dim sti As StockBasketItem = CType(item, StockBasketItem)
              Dim node As TreeNode = TreeViewHelper.SearchTag(Me.tvItems, sti.Id)
              If node Is Nothing Then
                node = Me.tvItems.Nodes.Add(sti.ParentText)
                node.Tag = sti.Id
              End If
              node.Nodes.Add(sti.TextInBasket).Tag = sti
            ElseIf TypeOf item Is EqtBasketItem Then
              'ต้องใช้ id ปลอม หากันเจอ โดยไม่ซ้ำกัน
              Dim eti As EqtBasketItem = CType(item, EqtBasketItem)
              Dim node As TreeNode
              If eti.ParId <> 0 Then
                node = TreeViewHelper.SearchTag(Me.tvItems, eti.ParId)
              End If
              If node Is Nothing AndAlso eti.Level = 1 Then ' AndAlso eti.Qty > 0 Then  'จะแสดงปริมาณที่ เป็น 0 ด้วยหรือเปล่ายังคิดอยู๋
                node = Me.tvItems.Nodes.Add(eti.ParentText)
                node.Tag = eti.ParId
              End If
              If eti.Level = 1 Then 'AndAlso eti.Qty > 0 Then 'จะแสดงปริมาณที่ เป็น 0 ด้วยหรือเปล่ายังคิดอยู๋
                If node Is Nothing Then
                  node = Me.tvItems.Nodes.Add(eti.ParentText)
                End If
                node.Nodes.Add(eti.TextInBasket).Tag = eti
              End If
              If eti.Level = 0 AndAlso Not eti.haschilds Then
                tvItems.Nodes.Add(item.TextInBasket).Tag = item
              End If
              Else
                tvItems.Nodes.Add(item.TextInBasket).Tag = item
              End If
          End If
        Next
        For Each item As IBasketItem In m_basketItems
          oldBasketItems.Add(item)
        Next
        tvItems.ExpandAll()
      Next
    End Sub
    Private Sub ibtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelete.Click
      Dim node As TreeNode = Me.tvItems.SelectedNode
      If node Is Nothing Then
        Return
      End If
      If IsNumeric(node.Tag) Then
        For Each child As TreeNode In node.Nodes
          m_basketItems.Remove(CType(child.Tag, IBasketItem))
          For Each bkc As IBasketCollectable In Me.m_lists
            bkc.BasketItems.Remove(CType(child.Tag, IBasketItem))
            bkc.ProposedBasketItems.Remove(CType(child.Tag, IBasketItem))
          Next
        Next
      ElseIf TypeOf node.Tag Is IBasketItem Then
        m_basketItems.Remove(CType(node.Tag, IBasketItem))
        For Each bkc As IBasketCollectable In Me.m_lists
          bkc.BasketItems.Remove(CType(node.Tag, IBasketItem))
          bkc.ProposedBasketItems.Remove(CType(node.Tag, IBasketItem))
        Next
      End If
      node.Remove()
    End Sub
    Private Sub ibtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnClear.Click
      Me.OnEmptyBasket(Me.m_basketItems)
      Me.m_basketItems.Clear()
      tvItems.Nodes.Clear()
    End Sub
#End Region

  End Class
End Namespace