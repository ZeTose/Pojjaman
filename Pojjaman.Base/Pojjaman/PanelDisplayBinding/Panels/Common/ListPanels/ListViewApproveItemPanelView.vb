Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Reflection
Imports System.Data.SqlClient 'Hack!!!!! 
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ListViewApproveItemPanelView
    Inherits AbstractEntityPanelViewContent
    Implements ISimpleListPanel

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
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents ibtnUnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pnlFilter2 As System.Windows.Forms.Panel
    Friend WithEvents pnlFilter3 As System.Windows.Forms.Panel
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents lvItem As Longkong.Pojjaman.Gui.Components.PJMListView
    Friend WithEvents lblSelectTop As System.Windows.Forms.Label
    Friend WithEvents txtSelectTop As System.Windows.Forms.TextBox
    Friend WithEvents ibtnSelectTop As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnAll As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnNone As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ListViewApproveItemPanelView))
      Me.pnlButton = New System.Windows.Forms.Panel
      Me.ibtnUnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.pnlFilter = New System.Windows.Forms.Panel
      Me.Splitter1 = New System.Windows.Forms.Splitter
      Me.pnlFilter2 = New System.Windows.Forms.Panel
      Me.lvItem = New Longkong.Pojjaman.Gui.Components.PJMListView
      Me.Splitter2 = New System.Windows.Forms.Splitter
      Me.pnlFilter3 = New System.Windows.Forms.Panel
      Me.lblSelectTop = New System.Windows.Forms.Label
      Me.txtSelectTop = New System.Windows.Forms.TextBox
      Me.ibtnSelectTop = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.Splitter3 = New System.Windows.Forms.Splitter
      Me.ibtnAll = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnNone = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.pnlButton.SuspendLayout()
      Me.pnlFilter2.SuspendLayout()
      Me.pnlFilter3.SuspendLayout()
      Me.SuspendLayout()
      '
      'pnlButton
      '
      Me.pnlButton.Controls.Add(Me.ibtnUnApprove)
      Me.pnlButton.Controls.Add(Me.ibtnApprove)
      Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.pnlButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.pnlButton.Location = New System.Drawing.Point(0, 403)
      Me.pnlButton.Name = "pnlButton"
      Me.pnlButton.Size = New System.Drawing.Size(768, 80)
      Me.pnlButton.TabIndex = 3
      '
      'ibtnUnApprove
      '
      Me.ibtnUnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnUnApprove.Image = CType(resources.GetObject("ibtnUnApprove.Image"), System.Drawing.Image)
      Me.ibtnUnApprove.Location = New System.Drawing.Point(96, 8)
      Me.ibtnUnApprove.Name = "ibtnUnApprove"
      Me.ibtnUnApprove.Size = New System.Drawing.Size(72, 64)
      Me.ibtnUnApprove.TabIndex = 222
      Me.ibtnUnApprove.TabStop = False
      Me.ibtnUnApprove.ThemedImage = CType(resources.GetObject("ibtnUnApprove.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtnUnApprove.Visible = False
      '
      'ibtnApprove
      '
      Me.ibtnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnApprove.Image = CType(resources.GetObject("ibtnApprove.Image"), System.Drawing.Image)
      Me.ibtnApprove.Location = New System.Drawing.Point(8, 8)
      Me.ibtnApprove.Name = "ibtnApprove"
      Me.ibtnApprove.Size = New System.Drawing.Size(72, 64)
      Me.ibtnApprove.TabIndex = 220
      Me.ibtnApprove.TabStop = False
      Me.ibtnApprove.ThemedImage = CType(resources.GetObject("ibtnApprove.ThemedImage"), System.Drawing.Bitmap)
      '
      'pnlFilter
      '
      Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
      Me.pnlFilter.Name = "pnlFilter"
      Me.pnlFilter.Size = New System.Drawing.Size(768, 96)
      Me.pnlFilter.TabIndex = 0
      '
      'Splitter1
      '
      Me.Splitter1.BackColor = System.Drawing.SystemColors.InactiveBorder
      Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Splitter1.Location = New System.Drawing.Point(0, 96)
      Me.Splitter1.Name = "Splitter1"
      Me.Splitter1.Size = New System.Drawing.Size(768, 1)
      Me.Splitter1.TabIndex = 224
      Me.Splitter1.TabStop = False
      '
      'pnlFilter2
      '
      Me.pnlFilter2.Controls.Add(Me.lvItem)
      Me.pnlFilter2.Controls.Add(Me.Splitter2)
      Me.pnlFilter2.Controls.Add(Me.pnlFilter3)
      Me.pnlFilter2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlFilter2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.pnlFilter2.Location = New System.Drawing.Point(0, 97)
      Me.pnlFilter2.Name = "pnlFilter2"
      Me.pnlFilter2.Size = New System.Drawing.Size(768, 306)
      Me.pnlFilter2.TabIndex = 225
      '
      'lvItem
      '
      Me.lvItem.AllowSort = True
      Me.lvItem.CheckBoxes = True
      Me.lvItem.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lvItem.FullRowSelect = True
      Me.lvItem.GridLines = True
      Me.lvItem.HideSelection = False
      Me.lvItem.Location = New System.Drawing.Point(0, 37)
      Me.lvItem.MultiSelect = False
      Me.lvItem.Name = "lvItem"
      Me.lvItem.Size = New System.Drawing.Size(768, 269)
      Me.lvItem.SortIndex = -1
      Me.lvItem.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lvItem.TabIndex = 226
      Me.lvItem.View = System.Windows.Forms.View.Details
      '
      'Splitter2
      '
      Me.Splitter2.BackColor = System.Drawing.SystemColors.InactiveCaption
      Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
      Me.Splitter2.Location = New System.Drawing.Point(0, 36)
      Me.Splitter2.Name = "Splitter2"
      Me.Splitter2.Size = New System.Drawing.Size(768, 1)
      Me.Splitter2.TabIndex = 225
      Me.Splitter2.TabStop = False
      '
      'pnlFilter3
      '
      Me.pnlFilter3.Controls.Add(Me.ibtnAll)
      Me.pnlFilter3.Controls.Add(Me.ibtnNone)
      Me.pnlFilter3.Controls.Add(Me.lblSelectTop)
      Me.pnlFilter3.Controls.Add(Me.txtSelectTop)
      Me.pnlFilter3.Controls.Add(Me.ibtnSelectTop)
      Me.pnlFilter3.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFilter3.Location = New System.Drawing.Point(0, 0)
      Me.pnlFilter3.Name = "pnlFilter3"
      Me.pnlFilter3.Size = New System.Drawing.Size(768, 36)
      Me.pnlFilter3.TabIndex = 224
      '
      'lblSelectTop
      '
      Me.lblSelectTop.Location = New System.Drawing.Point(296, 7)
      Me.lblSelectTop.Name = "lblSelectTop"
      Me.lblSelectTop.Size = New System.Drawing.Size(80, 23)
      Me.lblSelectTop.TabIndex = 226
      Me.lblSelectTop.Text = "Select Top:"
      Me.lblSelectTop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSelectTop
      '
      Me.txtSelectTop.Location = New System.Drawing.Point(376, 8)
      Me.txtSelectTop.Name = "txtSelectTop"
      Me.txtSelectTop.TabIndex = 225
      Me.txtSelectTop.Text = ""
      '
      'ibtnSelectTop
      '
      Me.ibtnSelectTop.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnSelectTop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnSelectTop.Location = New System.Drawing.Point(480, 6)
      Me.ibtnSelectTop.Name = "ibtnSelectTop"
      Me.ibtnSelectTop.Size = New System.Drawing.Size(72, 24)
      Me.ibtnSelectTop.TabIndex = 224
      Me.ibtnSelectTop.TabStop = False
      Me.ibtnSelectTop.Text = "Go!"
      Me.ibtnSelectTop.ThemedImage = Nothing
      '
      'Splitter3
      '
      Me.Splitter3.BackColor = System.Drawing.SystemColors.InactiveBorder
      Me.Splitter3.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Splitter3.Location = New System.Drawing.Point(0, 402)
      Me.Splitter3.Name = "Splitter3"
      Me.Splitter3.Size = New System.Drawing.Size(768, 1)
      Me.Splitter3.TabIndex = 226
      Me.Splitter3.TabStop = False
      '
      'ibtnAll
      '
      Me.ibtnAll.Image = CType(resources.GetObject("ibtnAll.Image"), System.Drawing.Image)
      Me.ibtnAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnAll.Location = New System.Drawing.Point(8, 8)
      Me.ibtnAll.Name = "ibtnAll"
      Me.ibtnAll.Size = New System.Drawing.Size(120, 24)
      Me.ibtnAll.TabIndex = 228
      Me.ibtnAll.TabStop = False
      Me.ibtnAll.Text = "เลือกทั้งหมด"
      Me.ibtnAll.ThemedImage = CType(resources.GetObject("ibtnAll.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnNone
      '
      Me.ibtnNone.Image = CType(resources.GetObject("ibtnNone.Image"), System.Drawing.Image)
      Me.ibtnNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnNone.Location = New System.Drawing.Point(144, 8)
      Me.ibtnNone.Name = "ibtnNone"
      Me.ibtnNone.Size = New System.Drawing.Size(120, 24)
      Me.ibtnNone.TabIndex = 227
      Me.ibtnNone.TabStop = False
      Me.ibtnNone.Text = "ไม่เลือกทั้งหมด"
      Me.ibtnNone.ThemedImage = CType(resources.GetObject("ibtnNone.ThemedImage"), System.Drawing.Bitmap)
      '
      'ListViewApproveItemPanelView
      '
      Me.Controls.Add(Me.Splitter3)
      Me.Controls.Add(Me.pnlFilter2)
      Me.Controls.Add(Me.Splitter1)
      Me.Controls.Add(Me.pnlFilter)
      Me.Controls.Add(Me.pnlButton)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "ListViewApproveItemPanelView"
      Me.Size = New System.Drawing.Size(768, 483)
      Me.pnlButton.ResumeLayout(False)
      Me.pnlFilter2.ResumeLayout(False)
      Me.pnlFilter3.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_filterSubPanel As IFilterSubPanel
    Private m_entity As ISimpleEntity
    Private m_selectedEntity As ISimpleEntity
    Private m_selectedID As Integer
    Private m_selectionMode As Selection

    Private m_basketItems As BasketItemCollection
    Private m_proposedBasketItems As BasketItemCollection
    Private m_oldBasket As BasketItemCollection

    Private m_otherFilters As Filter()

#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()

      InitializeComponent()
      m_entity = entity
      Me.SetLabelText()
      Me.PanelName = Me.Name

      m_entity.Status.Value = 2
      If entities Is Nothing Then
        entities = New ArrayList
      End If
      entities.Add(m_entity)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      m_filterSubPanel = myEntityPanelService.GetFilterSubPanel(m_entity, entities)

      Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
      Me.pnlFilter.Controls.Add(filterControl)
      Me.pnlFilter.Height = filterControl.Height
      AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click
      Me.RefreshData("")
      CreateColumn()

      m_basketItems = New BasketItemCollection
      m_proposedBasketItems = New BasketItemCollection
      m_oldBasket = New BasketItemCollection

      m_selectionMode = Selection.MultiSelect
      If m_selectionMode = Selection.None Or m_selectionMode = Selection.SingleSelect Then
        Me.lvItem.CheckBoxes = False
      Else
        Me.lvItem.CheckBoxes = True
      End If
      If Me.lvItem.CheckBoxes = True Then
        Me.ibtnAll.Visible = True
        Me.ibtnNone.Visible = True
      Else
        Me.ibtnAll.Visible = False
        Me.ibtnNone.Visible = False
        Me.Height = 0
      End If
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
    Public Overrides Property TitleName() As String
      Get
        Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ListViewApproveItemPanelView.Approve}") & MyBase.TitleName
      End Get
      Set(ByVal Value As String)
        MyBase.TitleName = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ListViewApproveItemPanelView.Approve}") & Me.StringParserService.Parse(m_entity.ListPanelTitle)
      ElseIf Not Me.m_selectedEntity Is Nothing Then
        Me.TitleName = Me.m_selectedEntity.TabPageText
      End If
    End Sub
    Private Function GetColumnString(ByVal s As String) As String
      For Each col As Column In Me.m_entity.Columns
        If col.Name.ToLower.EndsWith(s.ToLower) Then
          Return col.Name
        End If
      Next
      'Return ""
      If Not Me.m_entity Is Nothing Then
        Return Me.m_entity.Prefix & s
      Else
        Return ""
      End If
    End Function
    Public Sub OnEntityPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
      RaiseEvent EntityPropertyChanged(sender, e)
    End Sub
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = m_entity.ClassName
      'dst.AlternatingBackColor = dgList.AlternatingBackColor
      'dst.PreferredRowHeight = dgList.PreferredRowHeight
      'dst.RowHeadersVisible = dgList.RowHeadersVisible
      'Dim checkColumn As New DataGridCheckBoxColumn
      'checkColumn.Width = 60
      'dst.GridColumnStyles.Add(checkColumn)
      For Each col As Column In m_entity.Columns
        Dim cs As New DataGridTextColumn
        cs.MappingName = col.Name
        cs.HeaderText = Me.StringParserService.Parse(col.Alias)
        cs.Width = col.Width
        cs.NullText = ""
        dst.GridColumnStyles.Add(cs)
      Next
      Return dst
    End Function
    Private Sub CreateColumn()
      For Each col As Column In m_entity.Columns
        lvItem.Columns.Add(col.Alias, col.Width, col.Alignment)
      Next
    End Sub
    Public Sub SearchData(ByVal order As String)
      lvItem.Items.Clear()
      Dim comparer As IComparer = lvItem.ListViewItemSorter
      lvItem.ListViewItemSorter = Nothing
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

      Dim dt As DataTable = m_entity.GetListDatatable(order, newfilters)

      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)

      Dim ApprovalDocLevel As New ApprovalDocLevelCollection(myService.CurrentUser)

      'For Each row As DataRow In dt.Rows
      For Each row As DataRow In dt.Select("isnull(" & m_entity.Prefix & "_approveperson,0) = 0")
        Dim id As Integer = CInt(row(Me.m_entity.Prefix & "_id"))
        m_entity.Id = id

        Dim amt As Decimal = 0
        If row.Table.Columns.Contains(Me.m_entity.Prefix & "_aftertax") Then
          If Not row.IsNull(Me.m_entity.Prefix & "_aftertax") Then
            amt = CDec(row(Me.m_entity.Prefix & "_aftertax"))
          End If
        ElseIf row.Table.Columns.Contains(Me.m_entity.Prefix & "_gross") Then
          If Not row.IsNull(Me.m_entity.Prefix & "_gross") Then
            amt = CDec(row(Me.m_entity.Prefix & "_gross"))
          End If
        End If
        Dim approveDocColl As New ApproveDocCollection(m_entity)
        If ApprovalDocLevel.GetItem(m_entity.EntityId).Level > approveDocColl.MaxLevel _
        AndAlso ApprovalDocLevel.GetItem(m_entity.EntityId).Level > approveDocColl.MaxLevel _
        AndAlso ApprovalDocLevel.GetItem(m_entity.EntityId).MaxAmount >= amt Then
          Dim mineType As Type = m_entity.Columns(0).DataType
          Dim mineValue As String = ""
          If row.Table.Columns.Contains(m_entity.Columns(0).Name) Then
            Select Case mineType.FullName.ToLower
              Case "system.datetime"
                Dim val As Date = Date.Now
                If Not row.IsNull(m_entity.Columns(0).Name) Then
                  val = CDate(row(m_entity.Columns(0).Name))
                  If m_entity.Columns(0).Format = 2 Then
                    mineValue = val.ToShortDateString
                  Else
                    mineValue = val.ToShortDateString & ":" & val.ToShortTimeString
                  End If
                Else
                  mineValue = ""
                End If
              Case "system.decimal"
                Dim val As Decimal = 0
                If Not row.IsNull(m_entity.Columns(0).Name) Then
                  val = CDec(row(m_entity.Columns(0).Name))
                End If
                mineValue = Configuration.FormatToString(val, m_entity.Columns(0).Format)
              Case Else
                mineValue = row(m_entity.Columns(0).Name).ToString()
                mineValue = Me.StringParserService.Parse(mineValue)
            End Select
          End If
          Dim litem As ListViewItem = Me.lvItem.Items.Add(mineValue)
          litem.Tag = row(Me.m_entity.Prefix & "_id")
          For i As Integer = 1 To m_entity.Columns.Count - 1
            Dim myType As Type = m_entity.Columns(i).DataType
            Dim value As String = ""
            If row.Table.Columns.Contains(m_entity.Columns(i).Name) Then
              Select Case myType.FullName.ToLower
                Case "system.datetime"
                  Dim val As Date = Date.Now
                  If Not row.IsNull(m_entity.Columns(i).Name) Then
                    val = CDate(row(m_entity.Columns(i).Name))
                    If m_entity.Columns(i).Format = 2 Then
                      value = val.ToShortDateString
                    Else
                      value = val.ToShortDateString & ":" & val.ToShortTimeString
                    End If
                  Else
                    value = ""
                  End If
                Case "system.decimal"
                  Dim val As Decimal = 0
                  If Not row.IsNull(m_entity.Columns(i).Name) Then
                    val = CDec(row(m_entity.Columns(i).Name))
                  End If
                  value = Configuration.FormatToString(val, m_entity.Columns(i).Format)
                Case Else
                  value = row(m_entity.Columns(i).Name).ToString()
                  value = Me.StringParserService.Parse(value)
              End Select
            End If
            litem.SubItems.Add(value)
          Next
        End If
      Next
      lvItem.ListViewItemSorter = comparer
      If Not lvItem.ListViewItemSorter Is Nothing Then
        lvItem.Sort()
      End If
      lvItem.PaintAlternatingBackColor(Color.White, Color.Khaki)
    End Sub
    Private Function ApproveData() As SaveErrorException
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)

      Dim userApproveLevelCollection As New ApprovalDocLevelCollection(myService.CurrentUser)
      Dim theTime As Date = Now

      Try
        Dim saveEx As SaveErrorException
        For Each item As ListViewItem In Me.lvItem.CheckedItems
          Dim id As Integer = CInt(item.Tag)
          Dim newEntity As IApprovAble = CType(Me.m_entity, IApprovAble)

          m_entity.Id = id

          Dim approveDocColl As New ApproveDocCollection(m_entity)
          Dim approveDoc As New approveDoc
          approveDoc.EntityId = m_entity.Id
          approveDoc.EntityType = m_entity.EntityId

          approveDoc.LineNumber = approveDocColl.Count + 1
          approveDoc.Comment = "Multi-document approved"
          approveDoc.Level = userApproveLevelCollection.GetItem(m_entity.EntityId).Level
          'Record Submitter
          approveDoc.Originator = myService.CurrentUser.Id
          approveDoc.OriginDate = Now
          'Add to Collection
          approveDocColl.Add(approveDoc)

          Dim saveEx2 As SaveErrorException = approveDocColl.Save()

          If Not IsNumeric(saveEx2.Message) Then   'Todo
            If Not saveEx2.Params Is Nothing AndAlso saveEx2.Params.Length > 0 Then
              msgServ.ShowMessageFormatted(saveEx2.Message, saveEx2.Params)
            Else
              msgServ.ShowMessage(saveEx2.Message)
            End If
            MessageBox.Show(String.Format("Collection Not Saved:{0}:{1}:{3}", approveDocColl.MaxLevel, approveDocColl.GetMaxLevel, id))
            Exit For
          End If

          If approveDocColl.IsApproved Then
            Dim saveError As SaveErrorException = newEntity.ApproveData(id, myService.CurrentUser.Id, theTime)
            If Not IsNumeric(saveError.Message) Then   'Todo
              If Not saveError.Params Is Nothing AndAlso saveError.Params.Length > 0 Then
                msgServ.ShowMessageFormatted(saveError.Message, saveError.Params)
              Else
                msgServ.ShowMessage(saveError.Message)
              End If
              MessageBox.Show(String.Format("Cannot Approve:{0}:{1}:{2}", approveDocColl.MaxLevel, approveDocColl.GetMaxLevel, id))
              Exit For
            End If
          Else
            'MessageBox.Show(String.Format("{0}:{1}", approveDocColl.MaxLevel, approveDocColl.GetMaxLevel))
          End If
        Next
        Return saveEx
      Catch ex As SqlException
        MessageBox.Show(ex.ToString)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
      lvItem.Items.Clear()
    End Function
#End Region

#Region "Event Handlers"
    Private Sub btnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnApprove.Click
      ApproveData()
      Me.SearchData(GetColumnString("_code"))
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.SearchData(GetColumnString("_code"))
    End Sub
    Private Sub lvItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.SelectedIndexChanged
      'Application.DoEvents()
      If lvItem.SelectedItems.Count > 0 Then
        m_selectedID = CInt(lvItem.SelectedItems(0).Tag)
      End If
      'RefreshSelectedEntity()
      If Not Me.WorkbenchWindow Is Nothing Then
        RefreshEditableStatus()
      End If
    End Sub
    Private Sub RefreshEditableStatus()
      'WorkbenchSingleton.Workbench.RedrawAllComponents()
    End Sub
    Private Sub lvItem_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick
      If Not Me.WorkbenchWindow Is Nothing Then
        If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
          Me.WorkbenchWindow.SwitchView(1)
        End If
        Return
      End If
      If Not Me.SelectionMode = Selection.MultiSelect AndAlso Not Me.FindForm Is Nothing Then
        RefreshSelectedEntity() 'UNDONE********************
        Me.OnEntitySelected(Me.SelectedEntity)
        Me.FindForm.Close()
      End If
    End Sub
    Private Sub lvItem_SortChanged() Handles lvItem.SortChanged
      If m_entity Is Nothing Then
        Return
      End If
      Dim indx As Integer = lvItem.SortIndex
      Dim sortOrder As System.Windows.Forms.SortOrder = lvItem.SortOrder
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
    Private Sub ibtnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAll.Click
      For Each item As ListViewItem In Me.lvItem.Items
        item.Checked = True
      Next
    End Sub
    Private Sub ibtnNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnNone.Click
      For Each item As ListViewItem In Me.lvItem.Items
        item.Checked = False
      Next
    End Sub
    Private Sub ibtnSelectTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSelectTop.Click
      Dim count As Integer = 0
      If IsNumeric(Me.txtSelectTop.Text) Then
        count = CInt(Me.txtSelectTop.Text)
      End If
      If count <= 0 Then
        Return
      End If
      Dim i As Integer = 0
      For Each item As ListViewItem In Me.lvItem.Items
        i += 1
        If i <= count Then
          item.Checked = True
        Else
          item.Checked = False
        End If
      Next
    End Sub
#End Region

#Region "ISimpleListPanel"
    Public Event EntitySelected(ByVal e As ISimpleEntity) Implements ISimpleListPanel.EntitySelected
    Public Sub OnEntitySelected(ByVal e As ISimpleEntity)
      RaiseEvent EntitySelected(e)
    End Sub
    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

    Public Sub CheckFormEnable() Implements ISimpleEntityPanel.CheckFormEnable

    End Sub
    Public Sub ClearDetail() Implements ISimpleEntityPanel.ClearDetail

    End Sub
    Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)

        Me.m_entity = Value
        If TypeOf Value Is IApprovAble Then
          Dim apv As IApprovAble = CType(Value, IApprovAble)
          Me.ibtnUnApprove.Visible = apv.ShowUnApproveButton
          Dim svc As ResourceService = CType(ServiceManager.Services.GetService(GetType(ResourceService)), ResourceService)
          Me.ibtnApprove.ThemedImage = svc.GetBitmap(apv.ApproveIcon)
          Me.ibtnUnApprove.ThemedImage = svc.GetBitmap(apv.UnApproveIcon)
        End If
      End Set
    End Property
    Public Sub Initialize() Implements ISimpleEntityPanel.Initialize

    End Sub
    Public Sub SetLabelText() Implements ISimpleEntityPanel.SetLabelText
      If Not m_entity Is Nothing Then
        Me.Text = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      End If
      Me.ibtnAll.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ListViewApproveItemPanelView.ibtnAll}")
      Me.ibtnNone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ListViewApproveItemPanelView.ibtnNone}")
    End Sub
    Public Sub UpdateEntityProperties() Implements ISimpleEntityPanel.UpdateEntityProperties

    End Sub
    Private m_addingIHasConditionBeforeAdding As Boolean = False
    Private Sub CloseHandler(ByVal sender As Object, ByVal e As EventArgs)
      Dim dlg As Longkong.Pojjaman.Gui.Dialogs.PanelDialog = CType(sender, Longkong.Pojjaman.Gui.Dialogs.PanelDialog)
      Dim row As DataRow = CType(dlg.Control, IPreAddView).SelectedRow
      If dlg.DialogResult <> DialogResult.OK OrElse row Is Nothing Then
        Return
      End If
      m_addingIHasConditionBeforeAdding = True
      Dim newInstance As Object
      newInstance = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName, row)
      If (newInstance Is Nothing) Then
        Debug.WriteLine("Type not found: " & Me.m_entity.FullClassName)
        Return
      End If
      m_selectedEntity = CType(newInstance, ISimpleEntity)
      If Not m_selectedEntity Is Nothing Then
        RemoveHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
      End If
      If TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
        For Each view As ISimpleEntityPanel In Me.WorkbenchWindow.SubViewContents
          view.Entity = m_selectedEntity
        Next
      End If
      If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
        Me.WorkbenchWindow.SwitchView(1)
      End If
    End Sub
    Public Sub AddNew() Implements ISimpleListPanel.AddNew
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        Dim svc As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim preAddView As UserControl = svc.GetPreAddViewForEntity(Me.m_entity)
        If Not preAddView Is Nothing Then
          Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(preAddView)
          AddHandler dlg.Closed, AddressOf Me.CloseHandler
          dlg.ShowDialog()
          Return
        Else
          m_selectedID = 0
          RefreshSelectedEntity()
        End If
        If Not m_selectedEntity Is Nothing Then
          RemoveHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
          AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
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
    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData
      SearchData(GetColumnString("_code"))
      If Me.lvItem.Items.Count = 0 Then
        Return
      End If
      If id Is Nothing OrElse id.Length = 0 Then
        Me.lvItem.Items(0).Selected = True
        Return
      End If
      If Me.lvItem.MultiSelect = False Then
        Me.lvItem.SelectedItems.Clear()
      End If
      Dim item As ListViewItem = ListViewHelper.SearchTag(Me.lvItem, CInt(id))
      If Not item Is Nothing Then
        item.Selected = True
        item.EnsureVisible()
      End If
      Me.lvItem.Focus()
    End Sub
    Public Sub RefreshSelectedEntity()
      'If Not m_selectedEntity Is Nothing AndAlso m_selectedID <> 0 AndAlso m_selectedID = m_selectedEntity.Id Then
      '    Return
      'End If
      m_selectedEntity = Nothing
      If lvItem.Items.Count = 0 Or m_selectedID = 0 Then
        m_selectedEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName)
      Else
        m_selectedEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName, m_selectedID)
      End If
    End Sub
    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
        Return m_selectedEntity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        'If m_selectedEntity Is Nothing OrElse CType(m_selectedEntity, Object).Equals(Value) Then
        '    Return
        'End If
        Me.m_selectedEntity = Value
        If Not m_selectedEntity Is Nothing Then
          Me.RefreshData(m_selectedEntity.Id.ToString)
        End If
      End Set
    End Property
    Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
      Get
        Return Me.m_entity.ListPanelIcon
      End Get
    End Property
    Public Sub ShowInPad() Implements ISimplePanel.ShowInPad
      Return
    End Sub
    Public ReadOnly Property Title() As String Implements ISimplePanel.Title
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return "รายการ"
      End Get
    End Property
    Public Overrides Sub Deselected()
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        If Not m_addingIHasConditionBeforeAdding Then
          RefreshSelectedEntity() 'UNDONE********************
        Else
          m_addingIHasConditionBeforeAdding = False
        End If
        If Not m_selectedEntity Is Nothing Then
          RemoveHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
          AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        End If
      End If
    End Sub

#End Region

#Region "IClipboardHandler"
    Public Overrides Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim oldData As IDataObject = Clipboard.GetDataObject
      If oldData.GetDataPresent(Me.Entity.FullClassName) Then
        Dim id As Integer = CInt(oldData.GetData(Me.Entity.FullClassName))
      End If

      Dim newData As New DataObject
      newData.SetData(Me.Entity.FullClassName, Me.m_selectedEntity.Id)
      Clipboard.SetDataObject(newData)
      Me.RefreshEditableStatus()
    End Sub
    Public Overrides ReadOnly Property EnableCopy() As Boolean
      Get
        If Not Me.m_selectedEntity Is Nothing AndAlso Me.m_selectedEntity.Id <> 0 AndAlso Me.lvItem.SelectedItems.Count > 0 Then
          Return True
        End If
        Return False
      End Get
    End Property
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Not Me.m_filterSubPanel Is Nothing Then
          Return Me.m_filterSubPanel.EnablePaste
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If Not Me.m_filterSubPanel Is Nothing AndAlso Me.m_filterSubPanel.EnablePaste Then
        Me.m_filterSubPanel.Paste(sender, e)
      End If
    End Sub
#End Region

#Region "IBasketCollectable"
    Private dlg As BasketDialog
    Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
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
    Public Overrides ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection
      Get
        Return m_proposedBasketItems
      End Get
    End Property
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Select Case keyPressed
        Case Keys.Insert
          Me.AddNew()
          Return True
        Case Else
          Return False
      End Select
    End Function
#End Region

  End Class
End Namespace

