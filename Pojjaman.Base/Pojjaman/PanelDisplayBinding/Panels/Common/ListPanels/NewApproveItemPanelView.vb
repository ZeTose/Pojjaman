Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Reflection
Imports System.Data.SqlClient 'Hack!!!!! 
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class NewApproveItemPanelView
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPercent As System.Windows.Forms.TextBox
    Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents numPages As System.Windows.Forms.NumericUpDown
    Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents pnlPicHolder As System.Windows.Forms.Panel
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents lstLogs As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewApproveItemPanelView))
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtPercent = New System.Windows.Forms.TextBox()
      Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ListBox1 = New System.Windows.Forms.ListBox()
      Me.numPages = New System.Windows.Forms.NumericUpDown()
      Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.btnPrint = New System.Windows.Forms.Button()
      Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.pnlPicHolder = New System.Windows.Forms.Panel()
      Me.picMap = New System.Windows.Forms.PictureBox()
      Me.lstLogs = New System.Windows.Forms.ListBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.pnlFilter = New System.Windows.Forms.Panel()
      CType(Me.numPages, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.FixedGroupBox1.SuspendLayout()
      Me.FlowLayoutPanel1.SuspendLayout()
      Me.grbMap.SuspendLayout()
      Me.pnlPicHolder.SuspendLayout()
      CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(568, 267)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(76, 13)
      Me.Label3.TabIndex = 14
      Me.Label3.Text = "Select a Form:"
      '
      'txtPercent
      '
      Me.txtPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPercent.Location = New System.Drawing.Point(774, 361)
      Me.txtPercent.Name = "txtPercent"
      Me.txtPercent.ReadOnly = True
      Me.txtPercent.Size = New System.Drawing.Size(48, 21)
      Me.txtPercent.TabIndex = 13
      '
      'ibtnZoomOut
      '
      Me.ibtnZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomOut.Location = New System.Drawing.Point(774, 335)
      Me.ibtnZoomOut.Name = "ibtnZoomOut"
      Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomOut.TabIndex = 11
      Me.ibtnZoomOut.TabStop = False
      Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
      '
      'ListBox1
      '
      Me.ListBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ListBox1.FormattingEnabled = True
      Me.ListBox1.Items.AddRange(New Object() {"Form1", "Form2", "Form3", "Form4", "Form5"})
      Me.ListBox1.Location = New System.Drawing.Point(571, 312)
      Me.ListBox1.Name = "ListBox1"
      Me.ListBox1.Size = New System.Drawing.Size(197, 69)
      Me.ListBox1.TabIndex = 9
      '
      'numPages
      '
      Me.numPages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.numPages.Location = New System.Drawing.Point(774, 312)
      Me.numPages.Name = "numPages"
      Me.numPages.Size = New System.Drawing.Size(40, 21)
      Me.numPages.TabIndex = 10
      '
      'ibtnZoomIn
      '
      Me.ibtnZoomIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomIn.Location = New System.Drawing.Point(798, 335)
      Me.ibtnZoomIn.Name = "ibtnZoomIn"
      Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomIn.TabIndex = 12
      Me.ibtnZoomIn.TabStop = False
      Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
      '
      'FixedGroupBox1
      '
      Me.FixedGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.FixedGroupBox1.Controls.Add(Me.FlowLayoutPanel1)
      Me.FixedGroupBox1.Location = New System.Drawing.Point(276, 3)
      Me.FixedGroupBox1.Name = "FixedGroupBox1"
      Me.FixedGroupBox1.Size = New System.Drawing.Size(548, 69)
      Me.FixedGroupBox1.TabIndex = 15
      Me.FixedGroupBox1.TabStop = False
      Me.FixedGroupBox1.Text = "Possible Actions:"
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.FlowLayoutPanel1.Controls.Add(Me.btnPrint)
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 19)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(538, 44)
      Me.FlowLayoutPanel1.TabIndex = 6
      '
      'btnPrint
      '
      Me.btnPrint.Location = New System.Drawing.Point(3, 3)
      Me.btnPrint.Name = "btnPrint"
      Me.btnPrint.Size = New System.Drawing.Size(75, 23)
      Me.btnPrint.TabIndex = 0
      Me.btnPrint.Text = "Print"
      Me.btnPrint.UseVisualStyleBackColor = True
      '
      'grbMap
      '
      Me.grbMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMap.Controls.Add(Me.pnlPicHolder)
      Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMap.Location = New System.Drawing.Point(276, 78)
      Me.grbMap.Name = "grbMap"
      Me.grbMap.Size = New System.Drawing.Size(544, 228)
      Me.grbMap.TabIndex = 16
      Me.grbMap.TabStop = False
      Me.grbMap.Text = "Preview"
      '
      'pnlPicHolder
      '
      Me.pnlPicHolder.AutoScroll = True
      Me.pnlPicHolder.Controls.Add(Me.picMap)
      Me.pnlPicHolder.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlPicHolder.Location = New System.Drawing.Point(3, 17)
      Me.pnlPicHolder.Name = "pnlPicHolder"
      Me.pnlPicHolder.Size = New System.Drawing.Size(538, 208)
      Me.pnlPicHolder.TabIndex = 0
      '
      'picMap
      '
      Me.picMap.BackColor = System.Drawing.SystemColors.Window
      Me.picMap.Location = New System.Drawing.Point(0, 0)
      Me.picMap.Name = "picMap"
      Me.picMap.Size = New System.Drawing.Size(932, 326)
      Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picMap.TabIndex = 6
      Me.picMap.TabStop = False
      '
      'lstLogs
      '
      Me.lstLogs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
      Me.lstLogs.FormattingEnabled = True
      Me.lstLogs.Location = New System.Drawing.Point(6, 22)
      Me.lstLogs.Name = "lstLogs"
      Me.lstLogs.Size = New System.Drawing.Size(264, 278)
      Me.lstLogs.TabIndex = 18
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.Location = New System.Drawing.Point(3, 3)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(209, 20)
      Me.Label2.TabIndex = 17
      Me.Label2.Text = "History of this document:"
      '
      'pnlFilter
      '
      Me.pnlFilter.Location = New System.Drawing.Point(7, 401)
      Me.pnlFilter.Name = "pnlFilter"
      Me.pnlFilter.Size = New System.Drawing.Size(815, 124)
      Me.pnlFilter.TabIndex = 19
      '
      'NewApproveItemPanelView
      '
      Me.Controls.Add(Me.pnlFilter)
      Me.Controls.Add(Me.lstLogs)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.grbMap)
      Me.Controls.Add(Me.FixedGroupBox1)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtPercent)
      Me.Controls.Add(Me.ibtnZoomOut)
      Me.Controls.Add(Me.ListBox1)
      Me.Controls.Add(Me.numPages)
      Me.Controls.Add(Me.ibtnZoomIn)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "NewApproveItemPanelView"
      Me.Size = New System.Drawing.Size(827, 528)
      CType(Me.numPages, System.ComponentModel.ISupportInitialize).EndInit()
      Me.FixedGroupBox1.ResumeLayout(False)
      Me.FlowLayoutPanel1.ResumeLayout(False)
      Me.grbMap.ResumeLayout(False)
      Me.pnlPicHolder.ResumeLayout(False)
      CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

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

      m_basketItems = New BasketItemCollection
      m_proposedBasketItems = New BasketItemCollection
      m_oldBasket = New BasketItemCollection

      m_selectionMode = Selection.MultiSelect
      'If m_selectionMode = Selection.None Or m_selectionMode = Selection.SingleSelect Then
      '  Me.lvItem.CheckBoxes = False
      'Else
      '  Me.lvItem.CheckBoxes = True
      'End If
      'If Me.lvItem.CheckBoxes = True Then
      '  Me.ibtnAll.Visible = True
      '  Me.ibtnNone.Visible = True
      'Else
      '  Me.ibtnAll.Visible = False
      '  Me.ibtnNone.Visible = False
      '  Me.Height = 0
      'End If
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
        Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NewApproveItemPanelView.Approve}") & MyBase.TitleName
      End Get
      Set(ByVal Value As String)
        MyBase.TitleName = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.NewApproveItemPanelView.Approve}") & Me.StringParserService.Parse(m_entity.ListPanelTitle)
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
    Public Sub SearchData(ByVal order As String)
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
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.SearchData(GetColumnString("_code"))
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
        End If
      End Set
    End Property
    Public Sub Initialize() Implements ISimpleEntityPanel.Initialize

    End Sub
    Public Sub SetLabelText() Implements ISimpleEntityPanel.SetLabelText
      If Not m_entity Is Nothing Then
        Me.Text = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      End If
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
    End Sub
    Public Sub RefreshSelectedEntity()
      m_selectedEntity = Nothing
      m_selectedEntity = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName, m_selectedID)
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
                Return "${res:Longkong.Pojjaman.Gui.Panels.Global.ItemList}" '"รายการ"
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
    End Sub
    Public Overrides ReadOnly Property EnableCopy() As Boolean
      Get
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
      Dim f As New DocumentApprovalForm
      f.Show()
    End Sub
  End Class
End Namespace

