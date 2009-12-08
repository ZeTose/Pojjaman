Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports System.IO
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports ICSharpCode.TextEditor
Imports ICSharpCode.TextEditor.Document
Imports System.Windows.Forms
Namespace Longkong.Pojjaman.DefaultEditor.Gui.Editor
    Public Class TextEditorDisplayBindingWrapper
        Inherits AbstractViewContent
        Implements IMementoCapable, IPrintable, IEditable, IPositionable _
        , ITextEditorControlProvider, IParseInformationListener, IClipboardHandler, IHelpProvider



        Private Delegate Sub VoidDelegate(ByVal margin As AbstractMargin)


#Region "Members"
        Public TextAreaControl As PojjamanTextAreaControl
        Private m_wasChangedExternally As Boolean
        Private m_watcher As FileSystemWatcher
#End Region

#Region "Constructors"
        Public Sub New()
            Me.TextAreaControl = Nothing
            Me.m_wasChangedExternally = False
            Me.TextAreaControl = Me.CreatePojjamanTextAreaControl
            AddHandler Me.TextAreaControl.Document.DocumentChanged, New DocumentEventHandler(AddressOf Me.TextAreaChangedEvent)
            'AddHandler Me.TextAreaControl.ActiveTextAreaControl.Caret.CaretModeChanged, New EventHandler(AddressOf Me.CaretModeChanged)
            'AddHandler Me.TextAreaControl.ActiveTextAreaControl.Enter, New EventHandler(AddressOf Me.CaretUpdate)
            AddHandler CType(WorkbenchSingleton.Workbench, Form).Activated, New EventHandler(AddressOf Me.GotFocusEvent)
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Load(ByVal fileName As String)
            Me.TextAreaControl.IsReadOnly = ((File.GetAttributes(fileName) And FileAttributes.ReadOnly) = FileAttributes.ReadOnly)
            Me.TextAreaControl.LoadFile(fileName)
            Me.FileName = fileName
            Me.TitleName = Path.GetFileName(fileName)
            Me.IsDirty = False
            Me.SetWatcher()
        End Sub
        Private Sub SetWatcher()
            Try
                If (Me.m_watcher Is Nothing) Then
                    Me.m_watcher = New FileSystemWatcher
                    AddHandler Me.m_watcher.Changed, New FileSystemEventHandler(AddressOf Me.OnFileChangedEvent)
                Else
                    Me.m_watcher.EnableRaisingEvents = False
                End If
                Me.m_watcher.Path = Path.GetDirectoryName(Me.TextAreaControl.FileName)
                Me.m_watcher.Filter = Path.GetFileName(Me.TextAreaControl.FileName)
                Me.m_watcher.NotifyFilter = NotifyFilters.LastWrite
                Me.m_watcher.EnableRaisingEvents = True
            Catch ex As Exception
                Me.m_watcher = Nothing
            End Try
        End Sub
        Protected Overridable Function CreatePojjamanTextAreaControl() As PojjamanTextAreaControl
            Return New PojjamanTextAreaControl
        End Function
        Public Overrides Sub Dispose()
            RemoveHandler CType(WorkbenchSingleton.Workbench, Form).Activated, New EventHandler(AddressOf Me.GotFocusEvent)
            Me.TextAreaControl.Dispose()
        End Sub
        Private Sub GotFocusEvent(ByVal sender As Object, ByVal e As EventArgs)
            SyncLock Me
                If Not Me.m_wasChangedExternally Then
                    Return
                End If
                Me.m_wasChangedExternally = False
                Dim service1 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                Dim textArray1(,) As String = New String(1 - 1, 2 - 1) {}
                textArray1(0, 0) = "File"
                textArray1(0, 1) = Path.GetFullPath(Me.TextAreaControl.FileName)
                Dim text1 As String = service1.Parse("${res:ICSharpCode.SharpDevelop.DefaultEditor.Gui.Editor.TextEditorDisplayBinding.FileAlteredMessage}", textArray1)
                If (MessageBox.Show(text1, service1.Parse("${res:MainWindow.DialogName}"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    Me.Load(Me.TextAreaControl.FileName)
                Else
                    Me.IsDirty = True
                End If
            End SyncLock
        End Sub
        Private Sub OnFileChangedEvent(ByVal sender As Object, ByVal e As FileSystemEventArgs)
            SyncLock Me
                If (e.ChangeType <> WatcherChangeTypes.Deleted) Then
                    Me.m_wasChangedExternally = True
                    If Not CType(WorkbenchSingleton.Workbench, Form).Focused Then
                        Return
                    End If
                    Me.GotFocusEvent(Me, EventArgs.Empty)
                End If
            End SyncLock
        End Sub
        Protected Overrides Sub OnFileNameChanged(ByVal e As EventArgs)
            MyBase.OnFileNameChanged(e)
            Me.TextAreaControl.FileName = MyBase.FileName
        End Sub
        Public Overrides Sub RedrawContent()
            Me.TextAreaControl.OptionsChanged()
            Me.TextAreaControl.Refresh()
        End Sub
        Public Overloads Overrides Sub Save(ByVal fileName As String)
            Me.OnSaving(EventArgs.Empty)
            If (Not Me.m_watcher Is Nothing) Then
                Me.m_watcher.EnableRaisingEvents = False
            End If
            Me.TextAreaControl.SaveFile(fileName)
            Me.FileName = fileName
            Me.TitleName = Path.GetFileName(fileName)
            Me.IsDirty = False
            Me.SetWatcher()
            Me.OnSaved(New SaveEventArgs(True))
        End Sub
#End Region

#Region "IMementoCapable"
        Public Function CreateMemento() As Core.Properties.IXmlConvertable Implements Pojjaman.Gui.IMementoCapable.CreateMemento
            Dim myDefaultProperties As New DefaultProperties
            Dim textArray1 As String() = New String(Me.TextAreaControl.Document.BookmarkManager.Marks.Count - 1) {}
            For i As Integer = 0 To textArray1.Length - 1
                textArray1(i) = Me.TextAreaControl.Document.BookmarkManager.Marks.Item(i).ToString
            Next
            myDefaultProperties.SetProperty("Bookmarks", String.Join(",", textArray1))
            myDefaultProperties.SetProperty("CaretOffset", Me.TextAreaControl.ActiveTextAreaControl.Caret.Offset)
            myDefaultProperties.SetProperty("VisibleLine", Me.TextAreaControl.ActiveTextAreaControl.TextArea.TextView.FirstVisibleLine)
            myDefaultProperties.SetProperty("HighlightingLanguage", Me.TextAreaControl.Document.HighlightingStrategy.Name)
            myDefaultProperties.SetProperty("Foldings", Me.TextAreaControl.Document.FoldingManager.SerializeToString)
            Return myDefaultProperties
        End Function
        Public Sub SetMemento(ByVal memento As Core.Properties.IXmlConvertable) Implements Pojjaman.Gui.IMementoCapable.SetMemento
            Dim properties1 As IProperties = CType(memento, IProperties)
            Dim chArray1 As Char() = New Char() {","c}
            Dim textArray1 As String() = properties1.GetProperty("Bookmarks").ToString.Split(chArray1)
            Dim textArray2 As String() = textArray1
            Dim num1 As Integer
            For num1 = 0 To textArray2.Length - 1
                Dim text1 As String = textArray2(num1)
                If ((Not text1 Is Nothing) AndAlso (text1.Length > 0)) Then
                    Me.TextAreaControl.Document.BookmarkManager.Marks.Add(Integer.Parse(text1))
                End If
            Next num1
            Me.TextAreaControl.ActiveTextAreaControl.Caret.Position = Me.TextAreaControl.Document.OffsetToPosition(Math.Min(Me.TextAreaControl.Document.TextLength, Math.Max(0, properties1.GetProperty("CaretOffset", Me.TextAreaControl.ActiveTextAreaControl.Caret.Offset))))
            If (Not Me.TextAreaControl.Document.HighlightingStrategy.Name Is properties1.GetProperty("HighlightingLanguage", Me.TextAreaControl.Document.HighlightingStrategy.Name)) Then
                Dim strategy1 As IHighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(properties1.GetProperty("HighlightingLanguage", Me.TextAreaControl.Document.HighlightingStrategy.Name))
                If (Not strategy1 Is Nothing) Then
                    Me.TextAreaControl.Document.HighlightingStrategy = strategy1
                End If
            End If
            Me.TextAreaControl.ActiveTextAreaControl.TextArea.TextView.FirstVisibleLine = properties1.GetProperty("VisibleLine", 0)
            Me.TextAreaControl.Document.FoldingManager.DeserializeFromString(properties1.GetProperty("Foldings", ""))
        End Sub
        Private Sub TextAreaChangedEvent(ByVal sender As Object, ByVal e As DocumentEventArgs)
            Me.IsDirty = True
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Control() As Control
            Get
                Return Me.TextAreaControl
            End Get
        End Property
        Public Overrides Property FileName() As String
            Get
                Return MyBase.FileName
            End Get
            Set(ByVal value As String)
                If ((Not Path.GetExtension(Me.FileName) Is Path.GetExtension(value)) AndAlso (Not Me.TextAreaControl.Document.HighlightingStrategy Is Nothing)) Then
                    Me.TextAreaControl.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategyForFile(value)
                    Me.TextAreaControl.Refresh()
                End If
                MyBase.FileName = value
                MyBase.TitleName = Path.GetFileName(value)
            End Set
        End Property
        Public Overrides ReadOnly Property IsReadOnly() As Boolean
            Get
                Return Me.TextAreaControl.IsReadOnly
            End Get
        End Property
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Return "${res:FormsDesigner.DesignTabPages.SourceTabPage}"
            End Get
        End Property
#End Region

#Region "IEditable"
        Public ReadOnly Property ClipboardHandler() As Pojjaman.Gui.IClipboardHandler Implements Pojjaman.Gui.IEditable.ClipboardHandler
            Get
                Return Me
            End Get
        End Property
        Public ReadOnly Property EnableRedo() As Boolean Implements Pojjaman.Gui.IEditable.EnableRedo
            Get
                Return Me.TextAreaControl.EnableRedo
            End Get
        End Property
        Public ReadOnly Property EnableUndo() As Boolean Implements Pojjaman.Gui.IEditable.EnableUndo
            Get
                Return Me.TextAreaControl.EnableUndo
            End Get
        End Property
        Public Sub Redo() Implements Pojjaman.Gui.IEditable.Redo
            Me.TextAreaControl.Redo()
        End Sub
        Public Property Text() As String Implements Pojjaman.Gui.IEditable.Text
            Get
                Return Me.TextAreaControl.Document.TextContent
            End Get
            Set(ByVal value As String)
                Me.TextAreaControl.Document.TextContent = value
            End Set
        End Property
        Public Sub Undo() Implements Pojjaman.Gui.IEditable.Undo
            Me.TextAreaControl.Undo()
        End Sub
#End Region

#Region "IPositionable"
        Public Sub JumpTo(ByVal line As Integer, ByVal column As Integer) Implements Pojjaman.Gui.IPositionable.JumpTo
            Me.TextAreaControl.ActiveTextAreaControl.JumpTo(line, column)
        End Sub
#End Region

#Region "ITextEditorControlProvider"
        Public ReadOnly Property TextEditorControl() As ICSharpCode.TextEditor.TextEditorControl Implements ITextEditorControlProvider.TextEditorControl
            Get

            End Get
        End Property
#End Region

#Region "IParseInformationListener"
        Public Sub ParseInformationUpdated(ByVal parseInfo As Pojjaman.Services.IParseInformation) Implements Pojjaman.Gui.IParseInformationListener.ParseInformationUpdated
            If Me.TextAreaControl.TextEditorProperties.EnableFolding Then
                Me.TextAreaControl.Document.FoldingManager.UpdateFoldings(Me.TitleName, parseInfo)
                parseInfo = Nothing
                Dim objArray1 As Object() = New Object() {Me.TextAreaControl.ActiveTextAreaControl.TextArea.FoldMargin}
                Me.TextAreaControl.ActiveTextAreaControl.TextArea.Invoke(New VoidDelegate(AddressOf Me.TextAreaControl.ActiveTextAreaControl.TextArea.Refresh), objArray1)
            End If
        End Sub
#End Region

#Region "IClipboardHandler"
        Public Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs) Implements Pojjaman.Gui.IClipboardHandler.Copy
            Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e)
        End Sub
        Public Sub Cut(ByVal sender As Object, ByVal e As System.EventArgs) Implements Pojjaman.Gui.IClipboardHandler.Cut
            Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e)
        End Sub
        Public Sub Delete(ByVal sender As Object, ByVal e As System.EventArgs) Implements Pojjaman.Gui.IClipboardHandler.Delete
            Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e)
        End Sub
        Public ReadOnly Property EnableCopy() As Boolean Implements Pojjaman.Gui.IClipboardHandler.EnableCopy
            Get
                Return Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.EnableCopy
            End Get
        End Property
        Public ReadOnly Property EnableCut() As Boolean Implements Pojjaman.Gui.IClipboardHandler.EnableCut
            Get
                Return Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.EnableCut
            End Get
        End Property
        Public ReadOnly Property EnableDelete() As Boolean Implements Pojjaman.Gui.IClipboardHandler.EnableDelete
            Get
                Return Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.EnableDelete
            End Get
        End Property
        Public ReadOnly Property EnablePaste() As Boolean Implements Pojjaman.Gui.IClipboardHandler.EnablePaste
            Get
                Return Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.EnablePaste
            End Get
        End Property
        Public ReadOnly Property EnableSelectAll() As Boolean Implements Pojjaman.Gui.IClipboardHandler.EnableSelectAll
            Get
                Return Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.EnableSelectAll
            End Get
        End Property
        Public Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs) Implements Pojjaman.Gui.IClipboardHandler.Paste
            Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e)
        End Sub
        Public Sub SelectAll(ByVal sender As Object, ByVal e As System.EventArgs) Implements Pojjaman.Gui.IClipboardHandler.SelectAll
            Me.TextAreaControl.ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(sender, e)
        End Sub
#End Region

#Region "IHelpProvider"
        Public Sub ShowHelp() Implements Pojjaman.Gui.IHelpProvider.ShowHelp
            'Dim text1 As String = TextUtilities.GetWordAt(Me.TextAreaControl.Document, Me.TextAreaControl.ActiveTextAreaControl.Caret.Offset)
            'Dim browser1 As HelpBrowser = CType(WorkbenchSingleton.Workbench.GetPad(GetType(HelpBrowser)), HelpBrowser)
            ''Dim class1 As IClass = IIf((Not Me.TextAreaControl.QuickClassBrowserPanel Is Nothing), Me.TextAreaControl.QuickClassBrowserPanel.GetCurrentSelectedClass, Nothing)
            ''Dim service1 As IParserService = CType(ServiceManager.Services.GetService(GetType(IParserService)), IParserService)
            ''If (Not class1 Is Nothing) Then
            ''    Dim class2 As IClass = service1.SearchType(text1, class1, Me.TextAreaControl.ActiveTextAreaControl.Caret.Line, Me.TextAreaControl.ActiveTextAreaControl.Caret.Column)
            ''    If (Not class2 Is Nothing) Then
            ''        browser1.ShowHelpFromType(class2.FullyQualifiedName)
            ''    End If
            ''End If
        End Sub
#End Region

#Region "IPrintable"
        Public ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument Implements Pojjaman.Gui.IPrintable.PrintDocument
            Get
                Return Me.TextAreaControl.PrintDocument
            End Get
        End Property
        Public ReadOnly Property CanPrint() As Boolean Implements Pojjaman.Gui.IPrintable.CanPrint
            Get
                Return True
            End Get
        End Property
        Public ReadOnly Property PrintDocuments() As System.Collections.ArrayList Implements Pojjaman.Gui.IPrintable.PrintDocuments
            Get

            End Get
        End Property
#End Region

    End Class
End Namespace