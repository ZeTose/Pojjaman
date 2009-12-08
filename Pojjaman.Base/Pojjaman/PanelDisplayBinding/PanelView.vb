Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Namespace Longkong.Pojjaman.PanelDisplayBinding
    Public Class PanelView
        Inherits AbstractViewContent
        Implements IPrintable, IEditable, IClipboardHandler

#Region "Members"
        Protected m_control As UserControl
        Protected m_isDirty As Boolean
#End Region

#Region "Constructors"
        Public Sub New(ByVal control As UserControl)
            Me.m_control = control
            Dim strParserSrv As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.TitleName = m_control.Text
            Me.PanelName = m_control.Name
            If TypeOf Me.m_control Is IPanel Then
                CType(Me.m_control, IPanel).View = Me
            End If
            AddHandler Me.m_control.TextChanged, AddressOf Me.TitleChange
            If TypeOf Me.m_control Is IEntityPanel Then
                AddHandler CType(Me.m_control, IEntityPanel).EntityPropertyChanged, AddressOf Me.EntityPropertyChangedEvent
            End If
            Dim myMenuService As MenuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
            Me.IsDirty = False
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Control() As Control
            Get
                Return Me.m_control
            End Get
        End Property
        Public Overrides ReadOnly Property IsViewOnly() As Boolean
            Get
                Return False
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub EntityPropertyChangedEvent(ByVal sender As Object, ByVal e As EventArgs)
            Me.IsDirty = True
        End Sub

        Public Overrides Sub Load(ByVal url As String)
        End Sub
        Public Overrides Sub Dispose()
            Me.m_control.Dispose()
        End Sub
        Public Overloads Overrides Sub Save(ByVal url As String)
        End Sub
        Private Sub TitleChange(ByVal sender As Object, ByVal e As EventArgs)
            Me.TitleName = m_control.Text
        End Sub
        Public Overloads Overrides Sub Save()
            If TypeOf Me.Control Is IListPanel Then
                Dim eventID As String = CType(Me.Control, IListPanel).SelectedEntity.Save()
                If Not IsNumeric(eventID) Then 'Todo
                    MessageBox.Show(eventID)
                Else
                    MessageBox.Show("ข้อมูลถูกเก็บเรียบร้อย")
                    CType(Me.Control, IListPanel).RefreshData(eventID.ToString)
                End If
                Me.IsDirty = False
                Me.OnSaved(New SaveEventArgs(True))
            ElseIf TypeOf Me.Control Is IEntityPanel Then
                CType(Me.Control, IEntityPanel).Entity.Save()
                Me.IsDirty = False
                Me.OnSaved(New SaveEventArgs(True))
            End If
        End Sub
#End Region

#Region "IPrintable"
        Public ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument Implements Gui.IPrintable.PrintDocument
            Get
                If TypeOf Me.Control Is IPrintable Then
                    Return CType(Me.Control, IPrintable).PrintDocument
                End If
            End Get
        End Property
        Public Overridable ReadOnly Property CanPrint() As Boolean Implements Gui.IPrintable.CanPrint
            Get
                Return True
            End Get
        End Property
        Public ReadOnly Property PrintDocuments() As System.Collections.ArrayList Implements Gui.IPrintable.PrintDocuments
            Get

            End Get
        End Property
#End Region

#Region "IEditable"
        Public ReadOnly Property ClipboardHandler() As Gui.IClipboardHandler Implements Gui.IEditable.ClipboardHandler
            Get
                If TypeOf Me.Control Is IEditable Then
                    Return CType(Me.Control, IEditable).ClipboardHandler
                Else
                    Return Me
                End If
            End Get
        End Property

        Public ReadOnly Property EnableRedo() As Boolean Implements Gui.IEditable.EnableRedo
            Get
                If TypeOf Me.Control Is IEditable Then
                    Return CType(Me.Control, IEditable).EnableRedo
                End If
                Return False
            End Get
        End Property

        Public ReadOnly Property EnableUndo() As Boolean Implements Gui.IEditable.EnableUndo
            Get
                If TypeOf Me.Control Is IEditable Then
                    Return CType(Me.Control, IEditable).EnableUndo
                End If
                Return False
            End Get
        End Property

        Public Sub Redo() Implements Gui.IEditable.Redo
            If TypeOf Me.Control Is IEditable Then
                CType(Me.Control, IEditable).Redo()
            End If
        End Sub

        Public Property Text() As String Implements Gui.IEditable.Text
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Public Sub Undo() Implements Gui.IEditable.Undo
            If TypeOf Me.Control Is IEditable Then
                CType(Me.Control, IEditable).Undo()
            End If
        End Sub
#End Region

#Region "IClipboardHandler"
        Public Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs) Implements Gui.IClipboardHandler.Copy

        End Sub
        Public Sub Cut(ByVal sender As Object, ByVal e As System.EventArgs) Implements Gui.IClipboardHandler.Cut

        End Sub
        Public Sub Delete(ByVal sender As Object, ByVal e As System.EventArgs) Implements Gui.IClipboardHandler.Delete

        End Sub
        Public ReadOnly Property EnableCopy() As Boolean Implements Gui.IClipboardHandler.EnableCopy
            Get
                Return False
            End Get
        End Property
        Public ReadOnly Property EnableCut() As Boolean Implements Gui.IClipboardHandler.EnableCut
            Get
                Return False
            End Get
        End Property
        Public ReadOnly Property EnableDelete() As Boolean Implements Gui.IClipboardHandler.EnableDelete
            Get
                Return False
            End Get
        End Property
        Public ReadOnly Property EnablePaste() As Boolean Implements Gui.IClipboardHandler.EnablePaste
            Get
                Return False
            End Get
        End Property
        Public ReadOnly Property EnableSelectAll() As Boolean Implements Gui.IClipboardHandler.EnableSelectAll
            Get
                Return False
            End Get
        End Property
        Public Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs) Implements Gui.IClipboardHandler.Paste

        End Sub
        Public Sub SelectAll(ByVal sender As Object, ByVal e As System.EventArgs) Implements Gui.IClipboardHandler.SelectAll

        End Sub
#End Region

    End Class
End Namespace

