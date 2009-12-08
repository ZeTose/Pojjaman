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
  Public Class CostCenterMatListDetail
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
    Friend WithEvents lblAltName As System.Windows.Forms.Label
    Friend WithEvents txtAltName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtlv1 As System.Windows.Forms.TextBox
    Friend WithEvents lblLCI As System.Windows.Forms.Label
    Friend WithEvents txtlv5 As System.Windows.Forms.TextBox
    Friend WithEvents txtlv4 As System.Windows.Forms.TextBox
    Friend WithEvents txtlv3 As System.Windows.Forms.TextBox
    Friend WithEvents txtlv2 As System.Windows.Forms.TextBox
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
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CostCenterMatListDetail))
      Me.txtName = New System.Windows.Forms.TextBox
      Me.txtAltName = New System.Windows.Forms.TextBox
      Me.txtlv1 = New System.Windows.Forms.TextBox
      Me.txtlv5 = New System.Windows.Forms.TextBox
      Me.txtlv4 = New System.Windows.Forms.TextBox
      Me.txtlv3 = New System.Windows.Forms.TextBox
      Me.txtlv2 = New System.Windows.Forms.TextBox
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbLCI = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.ibtnShowCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnShowCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblAltName = New System.Windows.Forms.Label
      Me.lblName = New System.Windows.Forms.Label
      Me.lblLCI = New System.Windows.Forms.Label
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lvItem = New Longkong.Pojjaman.Gui.Components.PJMListView
      Me.lblItem = New System.Windows.Forms.Label
      Me.btnReset = New System.Windows.Forms.Button
      Me.btnSearch = New System.Windows.Forms.Button
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
      'txtAltName
      '
      Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtAltName.Location = New System.Drawing.Point(104, 64)
      Me.txtAltName.Name = "txtAltName"
      Me.txtAltName.Size = New System.Drawing.Size(344, 21)
      Me.txtAltName.TabIndex = 3
      Me.txtAltName.Text = ""
      '
      'txtlv1
      '
      Me.txtlv1.BackColor = System.Drawing.SystemColors.Info
      Me.txtlv1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv1.Location = New System.Drawing.Point(104, 16)
      Me.txtlv1.MaxLength = 2
      Me.txtlv1.Name = "txtlv1"
      Me.txtlv1.Size = New System.Drawing.Size(24, 23)
      Me.txtlv1.TabIndex = 163
      Me.txtlv1.Text = ""
      '
      'txtlv5
      '
      Me.txtlv5.BackColor = System.Drawing.SystemColors.Window
      Me.txtlv5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv5.Location = New System.Drawing.Point(200, 16)
      Me.txtlv5.MaxLength = 4
      Me.txtlv5.Name = "txtlv5"
      Me.txtlv5.Size = New System.Drawing.Size(56, 23)
      Me.txtlv5.TabIndex = 167
      Me.txtlv5.Text = ""
      '
      'txtlv4
      '
      Me.txtlv4.BackColor = System.Drawing.SystemColors.Window
      Me.txtlv4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv4.Location = New System.Drawing.Point(176, 16)
      Me.txtlv4.MaxLength = 2
      Me.txtlv4.Name = "txtlv4"
      Me.txtlv4.Size = New System.Drawing.Size(24, 23)
      Me.txtlv4.TabIndex = 166
      Me.txtlv4.Text = ""
      '
      'txtlv3
      '
      Me.txtlv3.BackColor = System.Drawing.SystemColors.Info
      Me.txtlv3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv3.Location = New System.Drawing.Point(152, 16)
      Me.txtlv3.MaxLength = 2
      Me.txtlv3.Name = "txtlv3"
      Me.txtlv3.Size = New System.Drawing.Size(24, 23)
      Me.txtlv3.TabIndex = 165
      Me.txtlv3.Text = ""
      '
      'txtlv2
      '
      Me.txtlv2.BackColor = System.Drawing.SystemColors.Info
      Me.txtlv2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv2.Location = New System.Drawing.Point(128, 16)
      Me.txtlv2.MaxLength = 2
      Me.txtlv2.Name = "txtlv2"
      Me.txtlv2.Size = New System.Drawing.Size(24, 23)
      Me.txtlv2.TabIndex = 164
      Me.txtlv2.Text = ""
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
      Me.grbLCI.Controls.Add(Me.lblAltName)
      Me.grbLCI.Controls.Add(Me.txtAltName)
      Me.grbLCI.Controls.Add(Me.lblName)
      Me.grbLCI.Controls.Add(Me.txtlv1)
      Me.grbLCI.Controls.Add(Me.lblLCI)
      Me.grbLCI.Controls.Add(Me.txtlv5)
      Me.grbLCI.Controls.Add(Me.txtlv4)
      Me.grbLCI.Controls.Add(Me.txtlv3)
      Me.grbLCI.Controls.Add(Me.txtlv2)
      Me.grbLCI.Location = New System.Drawing.Point(16, 24)
      Me.grbLCI.Name = "grbLCI"
      Me.grbLCI.Size = New System.Drawing.Size(624, 96)
      Me.grbLCI.TabIndex = 178
      Me.grbLCI.TabStop = False
      Me.grbLCI.Text = "LCI"
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
      'lblAltName
      '
      Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAltName.ForeColor = System.Drawing.Color.Black
      Me.lblAltName.Location = New System.Drawing.Point(8, 64)
      Me.lblAltName.Name = "lblAltName"
      Me.lblAltName.Size = New System.Drawing.Size(96, 18)
      Me.lblAltName.TabIndex = 8
      Me.lblAltName.Text = "ชื่ออื่น:"
      Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'lblLCI
      '
      Me.lblLCI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLCI.ForeColor = System.Drawing.Color.Black
      Me.lblLCI.Location = New System.Drawing.Point(16, 17)
      Me.lblLCI.Name = "lblLCI"
      Me.lblLCI.Size = New System.Drawing.Size(88, 20)
      Me.lblLCI.TabIndex = 168
      Me.lblLCI.Text = "LCI Code:"
      Me.lblLCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.lvItem.Location = New System.Drawing.Point(3, 152)
      Me.lvItem.MultiSelect = False
      Me.lvItem.Name = "lvItem"
      Me.lvItem.Size = New System.Drawing.Size(746, 288)
      Me.lvItem.SortIndex = -1
      Me.lvItem.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lvItem.TabIndex = 179
      Me.lvItem.View = System.Windows.Forms.View.Details
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 136)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(168, 18)
      Me.lblItem.TabIndex = 165
      Me.lblItem.Text = "รายการวัสดุ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'btnReset
      '
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(464, 64)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 186
      Me.btnReset.Text = "Reset"
      '
      'btnSearch
      '
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(544, 64)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 187
      Me.btnSearch.Text = "Search"
      '
      'CostCenterMatListDetail
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "CostCenterMatListDetail"
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
    Private m_entity As LCIItem
    Private m_mode As Mode
    Private m_cc As CostCenter
    Private m_fromWip As Boolean = False
    Private m_refEntityId As Integer

#End Region

#Region "Constructor"
    Public Enum Mode
      SingleSelect
      MultiSelect
    End Enum
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      Me.InitializeComponent()

      If Not TypeOf entity Is LCIForSelection Then
        Return
      End If

      m_mode = Mode.MultiSelect
      If TypeOf handler Is NamedEntityOperationDelegate Then
        m_mode = Mode.SingleSelect
      End If
      m_cc = CType(entity, LCIForSelection).CC
      m_refEntityId = CType(entity, LCIForSelection).refEntityId
      EnableCC()
      Me.m_fromWip = CType(entity, LCIForSelection).FromWip
      m_basketItems = New BasketItemCollection
      m_proposedBasketItems = New BasketItemCollection
      m_oldBasket = New BasketItemCollection

      m_entity = New LCIItem
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
      For Each col As Column In m_entity.Columns
        lvItem.Columns.Add(col.Alias, col.Width, col.Alignment)
      Next
    End Sub
#End Region

#Region "Methods"
    Private Function GetFilterArray() As Filter()
      Dim arr(9) As Filter
      arr(0) = New Filter("lci_lv1", IIf(Me.txtlv1.Text.Length = 0, DBNull.Value, Me.txtlv1.Text))
      arr(1) = New Filter("lci_lv2", IIf(Me.txtlv2.Text.Length = 0, DBNull.Value, Me.txtlv2.Text))
      arr(2) = New Filter("lci_lv3", IIf(Me.txtlv3.Text.Length = 0, DBNull.Value, Me.txtlv3.Text))
      arr(3) = New Filter("lci_lv4", IIf(Me.txtlv4.Text.Length = 0, DBNull.Value, Me.txtlv4.Text))
      arr(4) = New Filter("lci_lv5", IIf(Me.txtlv5.Text.Length = 0, DBNull.Value, Me.txtlv5.Text))
      arr(5) = New Filter("lci_name", IIf(Me.txtName.Text.Length = 0, DBNull.Value, Me.txtName.Text))
      arr(6) = New Filter("lci_altname", IIf(Me.txtAltName.Text.Length = 0, DBNull.Value, Me.txtAltName.Text))
      arr(7) = New Filter("cc_id", IIf(m_cc.Originated, m_cc.Id, DBNull.Value))
      Dim accType As Integer = 3
      If m_fromWip Then
        accType = 1
      End If
      arr(8) = New Filter("FromacctType", accType)
      arr(9) = New Filter("EntityId", m_refEntityId)
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
          Dim id As Integer = CInt(item.Tag)
          Dim entity As ISimpleEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName, id)
          Dim basketitem As New basketitem(id, entity.Code, entity.FullClassName, entity.Code)
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
      Me.txtlv1.Text = ""
      Me.txtlv2.Text = ""
      Me.txtlv3.Text = ""
      Me.txtlv4.Text = ""
      Me.txtlv5.Text = ""
      Me.txtAltName.Text = ""
      Me.txtName.Text = ""
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
      lvItem.Items.Clear()
      Dim comparer As IComparer = lvItem.ListViewItemSorter
      lvItem.ListViewItemSorter = Nothing
      Dim filters As Filter() = Me.GetFilterArray
      Dim dt As DataTable = LCIItem.GetAvailabilityInCC(filters)
      For Each row As DataRow In dt.Rows
        Dim litem As ListViewItem = Me.lvItem.Items.Add(row(m_entity.Columns(0).Name).ToString)
        litem.Tag = row(Me.m_entity.Prefix & "_id")
        For i As Integer = 1 To m_entity.Columns.Count - 1
          litem.SubItems.Add(row(m_entity.Columns(i).Name).ToString)
        Next
      Next
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