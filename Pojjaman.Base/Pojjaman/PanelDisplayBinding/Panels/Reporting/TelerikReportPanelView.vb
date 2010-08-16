Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Imports Syncfusion.Windows.Forms.Grid
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class TelerikReportPanelView
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
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents Grid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.pnlFilter = New System.Windows.Forms.Panel()
      Me.Splitter1 = New System.Windows.Forms.Splitter()
      Me.Grid = New Telerik.WinControls.UI.RadGridView()
      CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'pnlFilter
      '
      Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
      Me.pnlFilter.Name = "pnlFilter"
      Me.pnlFilter.Size = New System.Drawing.Size(768, 152)
      Me.pnlFilter.TabIndex = 0
      '
      'Splitter1
      '
      Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Splitter1.Location = New System.Drawing.Point(0, 152)
      Me.Splitter1.Name = "Splitter1"
      Me.Splitter1.Size = New System.Drawing.Size(768, 3)
      Me.Splitter1.TabIndex = 1
      Me.Splitter1.TabStop = False
      '
      'Grid
      '
      Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Grid.Location = New System.Drawing.Point(0, 155)
      Me.Grid.Name = "Grid"
      Me.Grid.Size = New System.Drawing.Size(768, 328)
      Me.Grid.TabIndex = 2
      '
      'TelerikReportPanelView
      '
      Me.Controls.Add(Me.Grid)
      Me.Controls.Add(Me.Splitter1)
      Me.Controls.Add(Me.pnlFilter)
      Me.Name = "TelerikReportPanelView"
      Me.Size = New System.Drawing.Size(768, 483)
      CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_filterSubPanel As IReportFilterSubPanel
    Private m_entity As Report
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      InitializeComponent()
      m_entity = CType(entity, Report)
      Me.SetLabelText()
      Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      Me.PanelName = Me.Name

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      m_filterSubPanel = myEntityPanelService.GetReportFilterSubPanel(m_entity)

      Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
      Me.pnlFilter.Controls.Add(filterControl)
      Me.pnlFilter.Height = filterControl.Height
      AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click

    End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
        Return
      End If
      'If Not m_selectedEntity Is Nothing Then
      '    Me.TitleName = m_selectedEntity.TabPageText
      'End If
    End Sub
    Public Sub OnEntityPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
      RaiseEvent EntityPropertyChanged(sender, e)
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim filters As Filter() = Me.m_filterSubPanel.GetFilterArray
      Dim fixVals As DocPrintingItemCollection = Me.m_filterSubPanel.GetFixValueCollection
      m_entity.Filters = filters
      m_entity.FixValueCollection = fixVals
      m_entity.RefreshDataSet()
      m_entity.ListInNewGrid(Grid)
    End Sub
    Private Sub RefreshEditableStatus()
      'WorkbenchSingleton.Workbench.RedrawAllComponents()
    End Sub
#End Region

#Region "ISimpleListPanel"
    Public Event EntitySelected(ByVal e As ISimpleEntity) Implements ISimpleListPanel.EntitySelected
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
        Me.m_entity = CType(Value, Report)
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
    Private Sub CloseHandler(ByVal sender As Object, ByVal e As EventArgs)
      'Dim dlg As Longkong.Pojjaman.Gui.Dialogs.PanelDialog = CType(sender, Longkong.Pojjaman.Gui.Dialogs.PanelDialog)
      'Dim row As DataRow = CType(dlg.Control, AssetSelectionView).SelectedRow
      'If dlg.DialogResult <> DialogResult.OK OrElse row Is Nothing Then
      '    Return
      'End If
      'm_selectedEntity = New Asset(row)
      'If Not m_selectedEntity Is Nothing Then
      '    AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
      'End If
      'If TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
      '    For Each view As ISimpleEntityPanel In Me.WorkbenchWindow.SubViewContents
      '        view.Entity = m_selectedEntity
      '    Next
      'End If
      'If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
      '    Me.WorkbenchWindow.SwitchView(1)
      'End If
    End Sub
    Public Sub AddNew() Implements ISimpleListPanel.AddNew

    End Sub
    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData

    End Sub
    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        Me.m_entity = CType(Value, Report)
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
        Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReportPanelView.TabPageText}")
      End Get
    End Property
#End Region

#Region "IClipboardHandler"
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

    'TODO: Ctrl+A
    'Private Sub tgItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '  If e.Control AndAlso e.KeyCode = Keys.A Then
    '    tgItem.Selections.SelectRange(GridRangeInfo.Cells(0, 0, tgItem.RowCount, tgItem.ColCount), True)
    '  End If
    'End Sub
  End Class
End Namespace

