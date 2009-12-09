Imports WeifenLuo.WinFormsUI.Docking
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports System.IO
Imports System.Reflection
Imports Longkong.Core.AddIns
Imports System.ComponentModel
Imports Longkong.Core
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Commands
Namespace Longkong.Pojjaman.Gui
    Public Class PojjamanWorkspaceWindow
        Inherits DockContent
        Implements IWorkbenchWindow, IOwnerState

#Region "Members"
        Private Shared ReadOnly m_contextMenuPath As String = "/Pojjaman/Workbench/OpenFileTab/ContextMenu"
        Private Shared m_stringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

        Private m_content As IViewContent 'ตัว content หลัก
        Private m_subViewContents As ArrayList 'content รองต่างๆ

        Private m_internalState As OpenFileTabState
        Private m_myUntitledTitle As String
        Private m_oldIndex As Integer

        Private m_viewTabControl As PJMTabControl 'TabControl 'Tab ที่ host ตัว content ทั้งหลักและรอง
#End Region

#Region "Constructors"
        Public Sub New(ByVal content As IViewContent)
            Me.m_internalState = OpenFileTabState.Nothing
            Me.m_viewTabControl = Nothing
            Me.m_subViewContents = Nothing
            Me.m_myUntitledTitle = Nothing
            Me.m_oldIndex = 0

            Me.m_content = content
            content.WorkbenchWindow = Me

            Me.KeyPreview = True


            AddHandler content.TitleNameChanged, New EventHandler(AddressOf Me.SetTitleEvent)
            AddHandler content.DirtyChanged, New EventHandler(AddressOf Me.SetTitleEvent)
            AddHandler content.Saving, New EventHandler(AddressOf Me.BeforeSave)
            AddHandler content.Saved, New SaveEventHandler(AddressOf Me.AfterSave)

            Me.SetTitleEvent(Nothing, Nothing)

            '*****************************************
      MyBase.DockAreas = DockAreas.Document ' นี่แหละที่ทำให้ Window นี้อยู่บริเวณเดียว ลากไปไหนไม่ได้    
            '*****************************************

            MyBase.DockPadding.All = 2

            Me.SetTitleEvent(Me, EventArgs.Empty)

            Dim myMenuService As MenuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
            MyBase.TabPageContextMenu = myMenuService.CreateContextMenu(Me, PojjamanWorkspaceWindow.m_contextMenuPath)

            Me.InitControls() 'เหมือน initializecomponent 
        End Sub
        Public Sub DetachContent()
            RemoveHandler Me.m_content.TitleNameChanged, New EventHandler(AddressOf Me.SetTitleEvent)
            RemoveHandler Me.m_content.DirtyChanged, New EventHandler(AddressOf Me.SetTitleEvent)
            RemoveHandler Me.m_content.Saving, New EventHandler(AddressOf Me.BeforeSave)
            RemoveHandler Me.m_content.Saved, New SaveEventHandler(AddressOf Me.AfterSave)
        End Sub

#End Region

#Region "Properties"
        Protected Overrides ReadOnly Property DefaultSize() As Size
            Get
                Return Size.Empty
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub AfterSave(ByVal sender As Object, ByVal e As SaveEventArgs)
            If ((Me.SubViewContents Is Nothing) OrElse (Me.SubViewContents.Count = 0)) Then
                Return
            End If
            For i As Integer = 1 To Me.SubViewContents.Count - 1
                Try
                    CType(Me.SubViewContents(i), ISecondaryViewContent).NotifyAfterSave(e.Successful)
                Catch ex As Exception
                End Try
            Next
        End Sub
        Private Sub BeforeSave(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.SubViewContents Is Nothing) OrElse (Me.SubViewContents.Count = 0)) Then
                Return
            End If
            For i As Integer = 1 To Me.SubViewContents.Count - 1
                Try
                    CType(Me.SubViewContents(i), ISecondaryViewContent).NotifyBeforeSave()
                Catch ex As Exception
                End Try
            Next
        End Sub
        Protected Overloads Overrides Sub Dispose(ByVal isDisposing As Boolean)
            Try
                MyBase.Dispose(isDisposing)
                If (Not isDisposing OrElse (Me.SubViewContents Is Nothing)) Then
                    Return
                End If
                For Each disposable As IDisposable In Me.SubViewContents
                    disposable.Dispose()
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
        Friend Sub InitControls()
            If Me.m_content.CreateAsSubViewContent Then
                Me.InitializeSubViewContents()
            Else
                Me.m_content.Control.Dock = DockStyle.Fill
                MyBase.Controls.Add(Me.m_content.Control)
            End If
        End Sub
        Private Sub InitializeSubViewContents()
            Me.m_subViewContents = New ArrayList
            Me.m_subViewContents.Add(Me.m_content)
            Me.m_viewTabControl = New PJMTabControl 'TabControl
            Me.m_viewTabControl.Alignment = TabAlignment.Bottom
            Me.m_viewTabControl.Dock = DockStyle.Fill
            Me.m_viewTabControl.ImageList = New ImageList
            'Me.m_viewTabControl.DrawMode = TabDrawMode.OwnerDrawFixed
            'AddHandler Me.m_viewTabControl.DrawItem, AddressOf Me.TabControl_DrawItem
            AddHandler Me.m_viewTabControl.SelectedIndexChanged, New EventHandler(AddressOf Me.ViewTabControlIndexChanged)
            AddHandler Me.m_viewTabControl.SelectedIndexChanging, AddressOf Me.SelectedIndexChanging
            MyBase.Controls.Clear()
            MyBase.Controls.Add(Me.m_viewTabControl)
            Dim page As New TabPage(PojjamanWorkspaceWindow.m_stringParserService.Parse(Me.m_content.TabPageText))
            Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
            Me.m_viewTabControl.ImageList.Images.Clear()
            Me.m_viewTabControl.ImageList.Images.Add(myIconService.GetBitmap("Icons.16x16.List"))
            page.ImageIndex = 0
            page.Tag = Me.m_content
            Me.m_content.Control.Dock = DockStyle.Fill
            page.Controls.Add(Me.m_content.Control)
            Me.m_viewTabControl.TabPages.Add(page)
        End Sub
        Private Sub TabControl_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
            Dim f As Font
            Dim backBrush As Brush
            Dim foreBrush As Brush

            If e.Index = 0 Then ' CType(sender, TabControl).SelectedIndex Then
                f = New Font(e.Font, FontStyle.Italic Or FontStyle.Bold)
                backBrush = Brushes.PaleTurquoise
                foreBrush = Brushes.Black
            Else
                f = e.Font
                backBrush = New SolidBrush(e.BackColor)
                foreBrush = New SolidBrush(e.ForeColor)
            End If

            Dim tabName As String = CType(sender, TabControl).TabPages(e.Index).Text
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            e.Graphics.FillRectangle(backBrush, e.Bounds)
            Dim r As RectangleF = New RectangleF(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height - 4)
            e.Graphics.DrawString(tabName, f, foreBrush, r, sf)

            sf.Dispose()
            If e.Index = 0 Then 'CType(sender, TabControl).SelectedIndex Then
                f.Dispose()
            Else
                backBrush.Dispose()
                foreBrush.Dispose()
            End If
        End Sub
        Private Sub LeaveTabPage(ByVal sender As Object, ByVal e As EventArgs)
            Me.OnWindowDeselected(EventArgs.Empty)
        End Sub
        Protected Overridable Sub OnCloseEvent(ByVal e As EventArgs)
            Me.OnWindowDeselected(e)
            RaiseEvent CloseEvent(Me, e)
        End Sub
        Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
            e.Cancel = Not Me.CloseWindow(False)
        End Sub
        Protected Overridable Sub OnTitleChanged(ByVal e As EventArgs)
            RaiseEvent TitleChanged(Me, e)
            WorkbenchSingleton.Workbench.WorkbenchLayout.OnActiveWorkbenchWindowChanged(EventArgs.Empty)
        End Sub
        Public Sub SetTitleEvent(ByVal sender As Object, ByVal e As EventArgs)
            Me.m_internalState = OpenFileTabState.Nothing
            If (Me.m_content Is Nothing) Then
                Return
            End If
            Me.SetToolTipText()
            Dim untitledTitle As String = ""
            If (Me.m_content.TitleName Is Nothing) Then
                Me.m_myUntitledTitle = Path.GetFileNameWithoutExtension(Me.m_content.UntitledName)
                untitledTitle = Me.m_myUntitledTitle
                Me.m_internalState = (Me.m_internalState Or OpenFileTabState.FileUntitled)
            Else
                untitledTitle = Me.m_content.TitleName
            End If
            If Me.m_content.IsDirty Then
                Me.m_internalState = (Me.m_internalState Or OpenFileTabState.FileDirty)
                untitledTitle = (untitledTitle & "*")
            Else
                If Me.m_content.IsReadOnly Then
                    untitledTitle = (untitledTitle & "+")
                End If
            End If
            If (Not untitledTitle = Me.Title) Then
                Me.Text = untitledTitle
                CType(WorkbenchSingleton.Workbench, PojjamanWorkbench).UpdateToolbars()
            End If
        End Sub
        Private Sub SetToolTipText()
            If (Not Me.m_content Is Nothing) Then
                Try
                    If ((Not Me.m_content.FileName Is Nothing) AndAlso (Me.m_content.FileName.Length > 0)) Then
                        MyBase.ToolTipText = Path.GetFullPath(Me.m_content.FileName)
                    Else
                        MyBase.ToolTipText = Me.m_content.TitleName
                    End If
                Catch ex As Exception
                    MyBase.ToolTipText = Me.m_content.FileName
                End Try
            Else
                MyBase.ToolTipText = Nothing
            End If
        End Sub
        Public Sub SelectedIndexChanging(ByVal sender As Object, ByVal e As TabSelectionChangingArgs)
            Dim statusbarService As DefaultStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), DefaultStatusBarService)
            'If TypeOf Me.ViewContent Is LCIListViewPanelView Then
            '    If e.CurrentTabIndex = 0 Then
            '        Dim lci As LCIItem = CType(CType(Me.ViewContent, LCIListViewPanelView).SelectedEntity, LCIItem)
            '        If lci Is Nothing OrElse lci.Level < 5 Then
            '            e.Cancel = True
            '            statusbarService.SetMessage("${res:MainWindow.StatusBar.LowLCILevel}")
            '            Return
            '        End If
            '    End If
            'End If
      statusbarService.SetMessage("${res:MainWindow.StatusBar.ReadyMessage}")
            If e.NewTabIndex = 0 AndAlso TypeOf Me.ViewContent Is ISimpleListPanel AndAlso Me.ViewContent.IsDirty Then
        Dim resourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
                Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + Title + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case dr
                    Case DialogResult.Yes
                        Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
                        myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf Me.ViewContent.Save), CType(Me.ViewContent, ISimpleListPanel).SelectedEntity)
                    Case DialogResult.No
                        Me.ViewContent.IsDirty = False
                        Dim oldEntity As ISimpleEntity = CType(Me.ViewContent, ISimpleListPanel).SelectedEntity
                        CType(Me.ViewContent, ISimpleListPanel).SelectedEntity = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(oldEntity.EntityId), oldEntity.Id)
                    Case DialogResult.Cancel
                        e.Cancel = True
                        Return
                End Select
            End If

        End Sub
        Private Sub ViewTabControlIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim statusbarService As DefaultStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), DefaultStatusBarService)
            'If TypeOf Me.ViewContent Is LCIListViewPanelView Then
            '    Dim lciView As LCIListViewPanelView = CType(Me.ViewContent, LCIListViewPanelView)
            '    If Me.m_oldIndex = 0 Then
            '        Dim lci As LCIItem = CType(lciView.SelectedEntity, LCIItem)
            '        If lci Is Nothing OrElse (lci.Level < 5 And Not lciView.Adding) Then
            '            Dim oldOldIndex As Integer = m_oldIndex
            '            m_oldIndex = -1
            '            Me.m_viewTabControl.SelectedIndex = oldOldIndex
            '            statusbarService.SetMessage("${res:MainWindow.StatusBar.LowLCILevel}")
            '            Return
            '        End If
            '    End If
            'End If
      statusbarService.SetMessage("${res:MainWindow.StatusBar.ReadyMessage}")
            If Me.m_viewTabControl.SelectedIndex = 0 AndAlso TypeOf Me.ViewContent Is ISimpleListPanel AndAlso Me.ViewContent.IsDirty Then
        Dim resourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
                Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + Title + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case dr
                    Case DialogResult.Yes
                        Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
                        myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf Me.ViewContent.Save), CType(Me.ViewContent, ISimpleListPanel).SelectedEntity)
                    Case DialogResult.No
                        Me.ViewContent.IsDirty = False
                        Dim oldEntity As ISimpleEntity = CType(Me.ViewContent, ISimpleListPanel).SelectedEntity
                        CType(Me.ViewContent, ISimpleListPanel).SelectedEntity = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(oldEntity.EntityId), oldEntity.Id)
                    Case DialogResult.Cancel
                        Dim oldOldIndex As Integer = m_oldIndex
                        m_oldIndex = -1
                        Me.m_viewTabControl.SelectedIndex = oldOldIndex
                        Return
                End Select
            End If

            If (Me.m_oldIndex >= 0) Then
                Dim oldContent As IBaseViewContent = CType(Me.SubViewContents(Me.m_oldIndex), IBaseViewContent)
                If (Not oldContent Is Nothing) Then
                    oldContent.Deselected()
                End If
            End If
            If (Me.m_viewTabControl.SelectedIndex >= 0) Then
                Dim newContent As IBaseViewContent = CType(Me.SubViewContents.Item(Me.m_viewTabControl.SelectedIndex), IBaseViewContent)
                If (Not newContent Is Nothing) Then
                    newContent.SwitchedTo()
                    newContent.Selected()
                End If
            End If
            Me.m_oldIndex = Me.m_viewTabControl.SelectedIndex
            WorkbenchSingleton.Workbench.WorkbenchLayout.OnActiveWorkbenchWindowChanged(EventArgs.Empty)
            Me.ActiveViewContent.Control.Focus()

            'Todo: Delete old Code:::
            'If Me.m_oldIndex > 0 And TypeOf Me.ViewContent Is ISimpleListPanel And Me.ViewContent.IsDirty Then
            '    Dim resourceService As resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), resourceService)
            '    Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + Title + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            '    Select Case dr
            '        Case DialogResult.Yes
            '            Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
            '            myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf Me.ViewContent.Save), CType(Me.ViewContent, ISimpleListPanel).SelectedEntity)
            '        Case DialogResult.No
            '            Me.ViewContent.IsDirty = False
            '        Case DialogResult.Cancel
            '            Dim oldOldIndex As Integer = m_oldIndex
            '            m_oldIndex = -1
            '            Me.m_viewTabControl.SelectedIndex = oldOldIndex
            '            Return
            '    End Select
            'End If
            'If (Me.m_oldIndex >= 0) Then
            '    Dim oldContent As IBaseViewContent = CType(Me.SubViewContents(Me.m_oldIndex), IBaseViewContent)
            '    If (Not oldContent Is Nothing) Then
            '        oldContent.Deselected()
            '    End If
            'End If
            'If (Me.m_viewTabControl.SelectedIndex >= 0) Then
            '    Dim newContent As IBaseViewContent = CType(Me.SubViewContents.Item(Me.m_viewTabControl.SelectedIndex), IBaseViewContent)
            '    If (Not newContent Is Nothing) Then
            '        newContent.SwitchedTo()
            '        newContent.Selected()
            '    End If
            'End If
            'Me.m_oldIndex = Me.m_viewTabControl.SelectedIndex
            'WorkbenchSingleton.Workbench.WorkbenchLayout.OnActiveWorkbenchWindowChanged(EventArgs.Empty)
            'Me.ActiveViewContent.Control.Focus()
        End Sub
#End Region

#Region "IWorkbenchWindow"
        Public Event WindowDeselected(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWorkbenchWindow.WindowDeselected
        Public Event WindowSelected(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWorkbenchWindow.WindowSelected
        Public Event TitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWorkbenchWindow.TitleChanged
        Public Event CloseEvent(ByVal sender As Object, ByVal e As System.EventArgs) Implements IWorkbenchWindow.CloseEvent

        Public ReadOnly Property ActiveViewContent() As IBaseViewContent Implements IWorkbenchWindow.ActiveViewContent
            Get
                If ((Not Me.m_viewTabControl Is Nothing) AndAlso (Me.m_viewTabControl.SelectedIndex > 0)) Then
                    Return CType(Me.SubViewContents(Me.m_viewTabControl.SelectedIndex), IBaseViewContent)
                End If
                Return Me.m_content
            End Get
        End Property

        Public Sub AttachSecondaryViewContent(ByVal subViewContent As ISecondaryViewContent) Implements IWorkbenchWindow.AttachSecondaryViewContent
            If (Me.SubViewContents Is Nothing) Then
                'ไม่เคยมี content หน้ารองมาก่อน
                Me.InitializeSubViewContents()
            End If
            subViewContent.WorkbenchWindow = Me
            Me.SubViewContents.Add(subViewContent)
            Dim page As New TabPage(PojjamanWorkspaceWindow.m_stringParserService.Parse(subViewContent.TabPageText))
            page.Tag = subViewContent
            If TypeOf subViewContent Is ISimpleEntityPanel Then
                Dim icon As String = subViewContent.TabPageIcon
                Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
                Me.m_viewTabControl.ImageList.Images.Add(myIconService.GetBitmap(icon))
                page.ImageIndex = Me.m_viewTabControl.ImageList.Images.Count - 1
            End If
            Try
                subViewContent.Control.Dock = DockStyle.Fill
            Catch ex As Exception
            End Try
            page.Controls.Add(subViewContent.Control)
            Me.m_viewTabControl.TabPages.Add(page)
        End Sub

        Public Function CloseWindow(ByVal force As Boolean) As Boolean Implements IWorkbenchWindow.CloseWindow
            If Not force AndAlso Not (ViewContent Is Nothing) AndAlso ViewContent.IsDirty Then
        Dim resourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
                Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + Title + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case dr
                    Case DialogResult.Yes
                        If TypeOf m_content Is ISimpleListPanel Then
                            Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
                            Dim myEntity As ISimpleEntity = CType(m_content, ISimpleListPanel).SelectedEntity
                            myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf m_content.Save), myEntity)
                            If TypeOf myEntity Is IDisposable Then
                                CType(myEntity, IDisposable).Dispose()
                            End If
                            CType(m_content, ISimpleListPanel).SelectedEntity = Nothing
                            myEntity = Nothing
                        ElseIf Me.m_content.FileName Is Nothing Then
                            While True
                                Dim cmd As New Longkong.Pojjaman.Commands.SaveFileAs
                                cmd.Run()
                                If ViewContent.IsDirty Then
                                    Dim messageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                                    If messageService.AskQuestion("${res:MainWindow.DiscardChangesMessage}") Then
                                        Exit While
                                    End If
                                Else
                                    Exit While
                                End If
                            End While
                        Else
              Dim fileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
                            fileUtilityService.ObservedSave(New FileOperationDelegate(AddressOf ViewContent.Save), ViewContent.FileName, FileErrorPolicy.ProvideAlternative)
                        End If
                        For Each content As Object In Me.SubViewContents
                            If TypeOf content Is AbstractEntityDetailPanelView Then
                                If TypeOf CType(content, AbstractEntityDetailPanelView).Entity Is IDisposable Then
                                    CType(CType(content, AbstractEntityDetailPanelView).Entity, IDisposable).Dispose()
                                End If
                                Try
                                    'Undone: เอา Try ออก
                                    CType(content, AbstractEntityDetailPanelView).Entity = Nothing
                                Catch ex As Exception

                                End Try
                            End If
                        Next
                    Case DialogResult.No
                    Case DialogResult.Cancel
                        Return False
                End Select
            ElseIf Not ViewContent Is Nothing AndAlso Not ViewContent.IsDirty Then
                If TypeOf m_content Is ISimpleListPanel Then
                    If TypeOf CType(m_content, ISimpleListPanel).SelectedEntity Is IDisposable Then
                        CType(CType(m_content, ISimpleListPanel).SelectedEntity, IDisposable).Dispose()
                    End If
                    CType(m_content, ISimpleListPanel).SelectedEntity = Nothing
                End If
                If Not Me.SubViewContents Is Nothing Then
                    For Each content As Object In Me.SubViewContents
                        If TypeOf content Is AbstractEntityDetailPanelView Then
                            If TypeOf CType(content, AbstractEntityDetailPanelView).Entity Is IDisposable Then
                                CType(CType(content, AbstractEntityDetailPanelView).Entity, IDisposable).Dispose()
                            End If
                            Try
                                'Undone: เอา Try ออก
                                CType(content, AbstractEntityDetailPanelView).Entity = Nothing
                            Catch ex As Exception

                            End Try
                        End If
                    Next
                End If
            End If

            OnCloseEvent(Nothing)
            Dispose()
            'PERFORMANCE
            GC.Collect()
            'PERFORMANCE
            Return True
        End Function

        Public Sub OnWindowDeselected(ByVal e As System.EventArgs) Implements IWorkbenchWindow.OnWindowDeselected
            RaiseEvent WindowDeselected(Me, e)
        End Sub

        Public Sub OnWindowSelected(ByVal e As System.EventArgs) Implements IWorkbenchWindow.OnWindowSelected
            RaiseEvent WindowSelected(Me, e)
        End Sub

        Public Sub RedrawContent() Implements IWorkbenchWindow.RedrawContent
            If (Me.m_viewTabControl Is Nothing) Then
                Return
            End If
            For i As Integer = 0 To Me.m_viewTabControl.TabPages.Count - 1
                Dim page As TabPage = Me.m_viewTabControl.TabPages.Item(i)
                If (i = 0) Then
                    page.Text = PojjamanWorkspaceWindow.m_stringParserService.Parse(Me.m_content.TabPageText)
                    page.ImageIndex = 0
                Else
                    page.Text = PojjamanWorkspaceWindow.m_stringParserService.Parse(CType(Me.SubViewContents(i), IBaseViewContent).TabPageText)
                End If
            Next
        End Sub

        Public Sub SelectWindow() Implements IWorkbenchWindow.SelectWindow
            MyBase.Show()
        End Sub

        Public ReadOnly Property SubViewContents() As System.Collections.ArrayList Implements IWorkbenchWindow.SubViewContents
            Get
                Return Me.m_subViewContents
            End Get
        End Property

        'เลือก content ที่ต้องการ
        Public Sub SwitchView(ByVal viewNumber As Integer) Implements IWorkbenchWindow.SwitchView
            If (Not Me.m_viewTabControl Is Nothing) Then
                Me.m_viewTabControl.SelectedIndex = viewNumber
            End If
        End Sub

        Public Property Title() As String Implements IWorkbenchWindow.Title
            Get
                Return Me.Text
            End Get
            Set(ByVal value As String)
                Me.Text = value
                Me.OnTitleChanged(Nothing)
            End Set
        End Property

        Public Property ViewContent() As IViewContent Implements IWorkbenchWindow.ViewContent
            Get
                Return Me.m_content
            End Get
            Set(ByVal value As IViewContent)
                Me.m_content = value
            End Set
        End Property
#End Region

#Region "IOwnerState"
        Public ReadOnly Property InternalState() As System.Enum Implements Core.AddIns.IOwnerState.InternalState
            Get
                Return Me.m_internalState
            End Get
        End Property
#End Region

        <Flags()> _
        Public Enum OpenFileTabState
            [Nothing] = 0
            FileDirty = 1
            ClickedWindowIsForm = 2
            FileUntitled = 4
        End Enum

        'Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        '    If e.KeyCode = Keys.Enter Then
        '        'If TypeOf Me.ActiveControl Is MultiLineTextBox Then
        '        '    Dim tb As MultiLineTextBox = DirectCast(Me.ActiveControl, MultiLineTextBox)
        '        '    If tb.Multiline AndAlso e.Alt Then
        '        '        Dim pos As Integer = tb.SelectionStart
        '        '        If tb.SelectionLength > 0 Then
        '        '            tb.Text = tb.Text.Remove(tb.SelectionStart, tb.SelectionLength)
        '        '        End If
        '        '        tb.SelectionStart = pos
        '        '        tb.Text = tb.Text.Insert(tb.SelectionStart, Microsoft.VisualBasic.Constants.vbCrLf)
        '        '        tb.SelectionStart = pos + Len(Microsoft.VisualBasic.Constants.vbCrLf)
        '        '        tb.ScrollToCaret()
        '        '        e.Handled = False
        '        '        MyBase.OnKeyUp(e)
        '        '        Return
        '        '    End If
        '        'End If
        '        e.Handled = True
        '        'SendKeys.Send("{Tab}")
        '    Else
        '        e.Handled = False
        '        MyBase.OnKeyUp(e)
        '    End If
        'End Sub
        Private Sub PojjamanWorkspaceWindow_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            Try
                Select Case e.KeyCode
                    Case Keys.Enter
            If StartPojjamanWorkbenchCommand.ALLOWTAB Then
                        SendKeys.Send("{tab}")
            End If
                        e.Handled = True
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub

        Private Sub PojjamanWorkspaceWindow_InputLanguageChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.InputLanguageChangedEventArgs) Handles MyBase.InputLanguageChanged
            Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
            myStatusBarService.RefreshLanguage()
        End Sub
    End Class
End Namespace
