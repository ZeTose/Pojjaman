Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports System.Drawing.Printing
Namespace Longkong.Pojjaman.Commands
  'Public Interface IPreviewable
  '  ReadOnly Property CanPreview As Boolean
  'End Interface
  Public Class PrintPreviewList
    Inherits AbstractEntityAccessCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Public Overrides Sub Run()
      Try
        Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
        Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If window Is Nothing Then
          Return
        End If
        If Not TypeOf window.ActiveViewContent Is IPrintable AndAlso Not TypeOf window.ViewContent Is IPrintable Then
          myMessageService.ShowError("${res:Longkong.Pojjaman.Commands.Print.CantPrintWindowContentError}")
          Return
        End If

        'Dim document As PrintDocument
        'Dim documents As ArrayList
        If TypeOf window.ActiveViewContent Is ListViewItemSelectionPanelView Then
          CType(window.ActiveViewContent, ListViewItemSelectionPanelView).PrintDocumentList()
          'CType(window.ActiveViewContent, IPrintable).PrintDocuments
          'Document = CType(window.ActiveViewContent, IPrintable).PrintDocument
          'documents = CType(window.ActiveViewContent, IPrintable).PrintDocuments
          'ElseIf TypeOf window.ViewContent Is IPrintable Then
          '  document = CType(window.ViewContent, IPrintable).PrintDocument
          '  documents = CType(window.ViewContent, IPrintable).PrintDocuments
        End If
        'If Not documents Is Nothing Then
        '  For Each doc As PrintDocument In documents
        '    Dim dialog As New PrintPreviewDialog
        '    dialog.Owner = CType(WorkbenchSingleton.Workbench, Form)
        '    dialog.WindowState = FormWindowState.Maximized
        '    dialog.PrintPreviewControl.Zoom = 1.0
        '    dialog.TopMost = True
        '    dialog.Document = doc
        '    DirectCast(DirectCast(dialog.Controls(1), ToolStrip).Items(0), ToolStripButton).Enabled = CanPrint()
        '    dialog.Show()
        '    AddHandler dialog.Closed, AddressOf ClosePreview
        '  Next
        'ElseIf Not document Is Nothing Then
        '  Dim dialog As New PrintPreviewDialog
        '  dialog.Owner = CType(WorkbenchSingleton.Workbench, Form)
        '  dialog.WindowState = FormWindowState.Maximized
        '  dialog.PrintPreviewControl.Zoom = 1.0
        '  'dialog.PrintPreviewControl
        '  dialog.TopMost = True
        '  dialog.Document = document
        '  DirectCast(DirectCast(dialog.Controls(1), ToolStrip).Items(0), ToolStripButton).Enabled = CanPrint()
        '  dialog.Show()
        '  AddHandler dialog.Closed, AddressOf ClosePreview
        'Else
        '  'myMessageService.ShowError("${res:Longkong.Pojjaman.Commands.Print.CreatePrintDocumentError}")
        'End If
      Catch ex As InvalidPrinterException
      End Try
    End Sub
    Private Sub ClosePreview(ByVal sender As Object, ByVal e As EventArgs)
      CType(WorkbenchSingleton.Workbench, Form).Activate()
    End Sub
#End Region

#Region "Properties"
    Private Function CanPrint() As Boolean
      Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
      If window Is Nothing Then
        Return MyBase.IsEnabled
      End If
      If window.ViewContent Is Nothing Then
        Return MyBase.IsEnabled
      End If
      If Not TypeOf window.ViewContent Is ISimpleListPanel Then
        Return MyBase.IsEnabled
      End If
      If TypeOf window.ActiveViewContent Is IPrintable Then
        Return CType(window.ActiveViewContent, IPrintable).CanPrint AndAlso MyBase.IsEnabledWithChecking
      ElseIf TypeOf window.ViewContent Is IPrintable Then
        Return CType(window.ViewContent, IPrintable).CanPrint AndAlso MyBase.IsEnabledWithChecking
      End If
      Return MyBase.IsEnabledWithChecking
    End Function
    Public Overrides Property IsEnabled() As Boolean
      Get
        Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
        If window Is Nothing Then
          Return MyBase.IsEnabled
        End If
        If window.ViewContent Is Nothing Then
          Return MyBase.IsEnabled
        End If
        If Not TypeOf window.ViewContent Is ISimpleListPanel Then
          Return MyBase.IsEnabled
        End If
        If TypeOf window.ActiveViewContent Is IPreviewable Then
          Return CType(window.ActiveViewContent, IPreviewable).CanPreview AndAlso MyBase.IsEnabledWithChecking
        ElseIf TypeOf window.ViewContent Is IPreviewable Then
          Return CType(window.ViewContent, IPreviewable).CanPreview AndAlso MyBase.IsEnabledWithChecking
        ElseIf TypeOf window.ActiveViewContent Is IPrintable Then
          Return CType(window.ActiveViewContent, IPrintable).CanPrint AndAlso MyBase.IsEnabledWithChecking
        ElseIf TypeOf window.ViewContent Is IPrintable Then
          Return CType(window.ViewContent, IPrintable).CanPrint AndAlso MyBase.IsEnabledWithChecking
        End If
        Return MyBase.IsEnabledWithChecking
      End Get
      Set(ByVal Value As Boolean)
        MyBase.IsEnabled = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ValidLevel() As Integer
      Get
        Return 3
      End Get
    End Property
#End Region

  End Class
End Namespace
