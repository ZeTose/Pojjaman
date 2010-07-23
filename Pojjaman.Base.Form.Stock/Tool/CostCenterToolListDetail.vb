Imports System.IO
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.ComponentModel
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Commands
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CostCenterToolListDetail
    Inherits UserControl
    Implements IBasketCollectable, IKeyReceiver

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
    Friend WithEvents ibtnAdd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grbLCI As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lvItem As Longkong.Pojjaman.Gui.Components.PJMListView
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CostCenterToolListDetail))
      Me.txtName = New System.Windows.Forms.TextBox
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbLCI = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.ibtnShowCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblName = New System.Windows.Forms.Label
      Me.lblCode = New System.Windows.Forms.Label
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lvItem = New Longkong.Pojjaman.Gui.Components.PJMListView
      Me.lblItem = New System.Windows.Forms.Label
      Me.grbLCI.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'txtName
      '
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtName.Location = New System.Drawing.Point(104, 40)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(344, 21)
      Me.txtName.TabIndex = 2
      Me.txtName.Text = ""
      '
      'txtCode
      '
      Me.txtCode.BackColor = System.Drawing.SystemColors.Window
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtCode.Location = New System.Drawing.Point(104, 16)
      Me.txtCode.MaxLength = 4
      Me.txtCode.Name = "txtCode"
      Me.txtCode.Size = New System.Drawing.Size(152, 23)
      Me.txtCode.TabIndex = 167
      Me.txtCode.Text = ""
      '
      'grbLCI
      '
      Me.grbLCI.Controls.Add(Me.btnSearch)
      Me.grbLCI.Controls.Add(Me.btnReset)
      Me.grbLCI.Controls.Add(Me.txtCostCenterCode)
      Me.grbLCI.Controls.Add(Me.lblCostCenter)
      Me.grbLCI.Controls.Add(Me.txtCostCenterName)
      Me.grbLCI.Controls.Add(Me.ibtnShowCostCenter)
      Me.grbLCI.Controls.Add(Me.ibtnShowCostCenterDialog)
      Me.grbLCI.Controls.Add(Me.txtName)
      Me.grbLCI.Controls.Add(Me.lblName)
      Me.grbLCI.Controls.Add(Me.lblCode)
      Me.grbLCI.Controls.Add(Me.txtCode)
      Me.grbLCI.Location = New System.Drawing.Point(16, 24)
      Me.grbLCI.Name = "grbLCI"
      Me.grbLCI.Size = New System.Drawing.Size(624, 72)
      Me.grbLCI.TabIndex = 178
      Me.grbLCI.TabStop = False
      Me.grbLCI.Text = "เครื่องมือ"
      '
      'btnSearch
      '
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(544, 40)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 187
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(464, 40)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 186
      Me.btnReset.Text = "Reset"
      '
      'txtCostCenterCode
      '
      Me.txtCostCenterCode.Location = New System.Drawing.Point(384, 17)
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.txtCostCenterCode.Size = New System.Drawing.Size(64, 20)
      Me.txtCostCenterCode.TabIndex = 181
      Me.txtCostCenterCode.Text = ""
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.Location = New System.Drawing.Point(272, 18)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(104, 18)
      Me.lblCostCenter.TabIndex = 185
      Me.lblCostCenter.Text = "จาก Cost Center:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.Location = New System.Drawing.Point(448, 17)
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.txtCostCenterName.Size = New System.Drawing.Size(120, 20)
      Me.txtCostCenterName.TabIndex = 182
      Me.txtCostCenterName.TabStop = False
      Me.txtCostCenterName.Text = ""
      '
      'ibtnShowCostCenter
      '
      Me.ibtnShowCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCostCenter.Image = CType(resources.GetObject("ibtnShowCostCenter.Image"), System.Drawing.Image)
      Me.ibtnShowCostCenter.Location = New System.Drawing.Point(592, 16)
      Me.ibtnShowCostCenter.Name = "ibtnShowCostCenter"
      Me.ibtnShowCostCenter.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCostCenter.TabIndex = 184
      Me.ibtnShowCostCenter.TabStop = False
      Me.ibtnShowCostCenter.ThemedImage = CType(resources.GetObject("ibtnShowCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowCostCenterDialog
      '
      Me.ibtnShowCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCostCenterDialog.Image = CType(resources.GetObject("ibtnShowCostCenterDialog.Image"), System.Drawing.Image)
      Me.ibtnShowCostCenterDialog.Location = New System.Drawing.Point(568, 16)
      Me.ibtnShowCostCenterDialog.Name = "ibtnShowCostCenterDialog"
      Me.ibtnShowCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCostCenterDialog.TabIndex = 183
      Me.ibtnShowCostCenterDialog.TabStop = False
      Me.ibtnShowCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(8, 40)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(96, 18)
      Me.lblName.TabIndex = 11
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 17)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 20)
      Me.lblCode.TabIndex = 168
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.lvItem)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.grbLCI)
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(752, 448)
      Me.grbDetail.TabIndex = 179
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'lvItem
      '
      Me.lvItem.AllowSort = True
      Me.lvItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lvItem.CheckBoxes = True
      Me.lvItem.FullRowSelect = True
      Me.lvItem.GridLines = True
      Me.lvItem.HideSelection = False
      Me.lvItem.Location = New System.Drawing.Point(3, 120)
      Me.lvItem.MultiSelect = False
      Me.lvItem.Name = "lvItem"
      Me.lvItem.Size = New System.Drawing.Size(746, 320)
      Me.lvItem.SortIndex = -1
      Me.lvItem.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lvItem.TabIndex = 179
      Me.lvItem.View = System.Windows.Forms.View.Details
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 104)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(168, 18)
      Me.lblItem.TabIndex = 165
      Me.lblItem.Text = "รายการเครื่องมือ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'CostCenterToolListDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "CostCenterToolListDetail"
      Me.Size = New System.Drawing.Size(776, 464)
      Me.grbLCI.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_basketItems As BasketItemCollection
    Private m_proposedBasketItems As BasketItemCollection
    Private m_oldBasket As BasketItemCollection
    Private m_entity As Tool
    Private m_mode As Mode
    Private m_cc As CostCenter
    Private m_eqtclass As String
    Private m_fromWip As Boolean = False
    Private m_filters As Filter()
#End Region

#Region "Constructor"
    Public Enum Mode
      SingleSelect
      MultiSelect
    End Enum
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      Me.InitializeComponent()

      If Not TypeOf entity Is ToolForSelection Then
        Return
      End If
      m_mode = Mode.MultiSelect
      If TypeOf handler Is NamedEntityOperationDelegate Then
        m_mode = Mode.SingleSelect
      End If
      m_cc = CType(entity, ToolForSelection).CC
      EnableCC()
      Me.m_fromWip = CType(entity, ToolForSelection).FromWip
      m_basketItems = New BasketItemCollection
      m_proposedBasketItems = New BasketItemCollection
      m_oldBasket = New BasketItemCollection
      m_eqtclass = CType(entity, ToolForSelection).EqtClass
      m_entity = New Tool
      m_filters = filters
      CreateColumn()
      If m_mode = Mode.MultiSelect Then
        Me.lvItem.CheckBoxes = True
      Else
        Me.lvItem.CheckBoxes = False
      End If
    End Sub
    Private Sub EnableCC()
      Me.txtCostCenterCode.Text = Me.m_cc.Code
      Me.txtCostCenterName.Text = Me.m_cc.Name
      If m_cc.Originated Then
        Me.txtCostCenterCode.Enabled = False
        Me.txtCostCenterName.Enabled = False
        Me.ibtnShowCostCenter.Enabled = False
        Me.ibtnShowCostCenterDialog.Enabled = False
      Else
        Me.txtCostCenterCode.Enabled = True
        Me.txtCostCenterName.Enabled = True
        Me.ibtnShowCostCenter.Enabled = True
        Me.ibtnShowCostCenterDialog.Enabled = True
      End If
    End Sub
    Private Sub CreateColumn()
      'For Each col As Column In m_entity.Columns
      '    lvItem.Columns.Add(col.Alias, col.Width, col.Alignment)
      'Next
      lvItem.Columns.Add("toolCode", 80, HorizontalAlignment.Center)
      lvItem.Columns.Add("toolname", 80, HorizontalAlignment.Center)
      lvItem.Columns.Add("toolrentrate", 80, HorizontalAlignment.Center)
      lvItem.Columns.Add("toolrentunit", 80, HorizontalAlignment.Center)


      Dim spar As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim remainText As String = spar.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostCenterToolListDetail.Remain}")
      lvItem.Columns.Add(remainText, 100, HorizontalAlignment.Right)
    End Sub
#End Region

#Region "Methods"
    Private Function GetFilterArray() As Filter()
      Dim i As Integer = 0
      Dim arr(3 + m_filters.Length) As Filter
      arr(0) = New Filter("tool_code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("tool_name", IIf(Me.txtName.Text.Length = 0, DBNull.Value, Me.txtName.Text))
      arr(2) = New Filter("cc_id", IIf(m_cc.Originated, m_cc.Id, DBNull.Value))
      Dim accType As Integer = 3
      If m_fromWip Then
        accType = 1
      End If
      arr(3) = New Filter("FromacctType", accType)
      For Each f As Filter In m_filters
        i += 1
        arr(3 + i) = m_filters(i - 1)
      Next
      Return arr
    End Function
#End Region

#Region "IBasketCollectable"
    Private dlg As BasketDialog
    Public Sub OnEmptyBasket(ByVal items As BusinessLogic.BasketItemCollection)
      RaiseEvent EmptyBasket(items)
    End Sub
    Public Event EmptyBasket(ByVal items As BusinessLogic.BasketItemCollection) Implements IBasketCollectable.EmptyBasket
    Public ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection Implements IBasketCollectable.BasketItems
      Get
        m_basketItems.Clear()
        For Each item As ListViewItem In Me.lvItem.CheckedItems
          Dim row As DataRow = CType(item.Tag, DataRow)
          Dim id As Integer = row("tool_id")
          Dim code As String = row("tool_code")
          'Dim entity As ISimpleEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName, id)
          Dim basketitem As New BasketItem(id, code, m_entity.FullClassName, code)
          basketitem.Tag = row
          m_basketItems.Add(basketitem)
        Next
        Return m_basketItems
      End Get
    End Property
    Public ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection Implements IBasketCollectable.ProposedBasketItems
      Get
        Return m_proposedBasketItems
      End Get
    End Property
#End Region

#Region "IKeyReceiver"
    Public Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean Implements IKeyReceiver.ProcessKey
      Select Case keyPressed
        Case Keys.Insert
          Return False
        Case Else
          Return False
      End Select
    End Function
#End Region

#Region "Event Handlers"
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      Me.txtCode.Text = ""
      Me.txtName.Text = ""
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
      lvItem.Items.Clear()
      Dim comparer As IComparer = lvItem.ListViewItemSorter
      lvItem.ListViewItemSorter = Nothing
      Dim filters As Filter() = Me.GetFilterArray
      Dim dt As DataTable = ToolForSelection.GetQtyOfToolsInCC(filters, m_eqtclass) 'Tool.GetAvailabilityInCC(filters)
      If dt IsNot Nothing Then
        For Each row As DataRow In dt.Rows
          Dim litem As ListViewItem = Me.lvItem.Items.Add(row(m_entity.Columns(0).Name).ToString)
          litem.Tag = row
          'litem.Tag = row(Me.m_entity.Prefix & "_id")
          'For i As Integer = 1 To m_entity.Columns.Count - 1
          litem.SubItems.Add(row("tool_name").ToString)
          litem.SubItems.Add(row("tool_rentalrate").ToString)
          litem.SubItems.Add(row("tool_rentalunit").ToString)
          'Next
          litem.SubItems.Add(row("remain").ToString)
        Next
      End If

      lvItem.ListViewItemSorter = comparer
      If Not lvItem.ListViewItemSorter Is Nothing Then
        lvItem.Sort()
      End If
      lvItem.PaintAlternatingBackColor(Color.White, Color.Khaki)
    End Sub
    Private Sub lvItem_SortChanged() Handles lvItem.SortChanged
      If m_entity Is Nothing Then
        Return
      End If
      Dim indx As Integer = lvItem.SortIndex
      Dim sortOrder As sortOrder = lvItem.SortOrder
      Dim myType As Type = m_entity.Columns(indx).DataType
      If myType Is GetType(Date) Then
        lvItem.ListViewItemSorter = New ListViewHelper.CompareByDate(indx, sortOrder)
      ElseIf myType Is GetType(String) Then
        lvItem.ListViewItemSorter = New ListViewHelper.CompareByText(indx, sortOrder)
      Else
        lvItem.ListViewItemSorter = New ListViewHelper.CompareByNumber(indx, sortOrder)
      End If
      lvItem.Sort()
      lvItem.PaintAlternatingBackColor(Color.White, Color.Khaki)
    End Sub
    Private Sub ibtnShowCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCostCenterDialog.Click

    End Sub
    Private Sub ibtnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCostCenter.Click

    End Sub
#End Region

  End Class
End Namespace