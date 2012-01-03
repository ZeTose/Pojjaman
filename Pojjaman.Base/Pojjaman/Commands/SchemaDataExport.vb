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

Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.ComponentModel
Imports System.IO

Namespace Longkong.Pojjaman.Commands
  Public Class SchemaDataExport
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

          'myMessageService.ShowError("${res:Longkong.Pojjaman.Commands.Print.CantPrintWindowContentError}")
          Return
        End If

        If TypeOf window.ActiveViewContent Is INewPrintable Then
          CType(window.ActiveViewContent, INewPrintable).ShowSelectSchemaDataDialog()
        End If
        Trace.WriteLine(window.ActiveViewContent)
        'Dim dialog As New SchemaDataExportDialog
        'dialog.StartPosition = FormStartPosition.CenterParent
        'dialog.ShowDialog()


        'Dim document As PrintDocument
        'Dim documents As ArrayList
        'Try
        '  If TypeOf window.ActiveViewContent Is IPrintable Then
        '    document = CType(window.ActiveViewContent, IPrintable).PrintDocument
        '    documents = CType(window.ActiveViewContent, IPrintable).PrintDocuments
        '  ElseIf TypeOf window.ViewContent Is IPrintable Then
        '    document = CType(window.ViewContent, IPrintable).PrintDocument
        '    documents = CType(window.ViewContent, IPrintable).PrintDocuments
        '  End If
        'Catch ex As Exception
        '  MessageBox.Show(ex.ToString)
        'End Try

        'If Not documents Is Nothing Then
        '  For Each doc As PrintDocument In documents
        '    Dim dialog As PrintDialog = New PrintDialog
        '    dialog.Document = doc
        '    dialog.AllowSomePages = True
        '    If (dialog.ShowDialog = DialogResult.OK) Then
        '      doc.Print()
        '    End If
        '  Next
        'ElseIf (Not document Is Nothing) Then
        '  Dim dialog As PrintDialog = New PrintDialog
        '  dialog.Document = document
        '  dialog.AllowSomePages = True

        '  Dim thePaper As PaperSize = AdobeForm.PJMPaper.Letter
        '  Try
        '    thePaper = dialog.PrinterSettings.PaperSizes(0)
        '    Dim found As Boolean = False
        '    'หาตาม PaperSize
        '    For Each pSz As PaperSize In dialog.PrinterSettings.PaperSizes
        '      If document.DefaultPageSettings.PaperSize.PaperName.ToLower = pSz.PaperName.ToLower Then
        '        thePaper = pSz
        '        found = True
        '        Exit For
        '      End If
        '    Next
        '    If Not found Then
        '      'หาตาม Kind
        '      For Each pSz As PaperSize In dialog.PrinterSettings.PaperSizes
        '        If document.DefaultPageSettings.PaperSize.Kind.ToString.ToLower = pSz.PaperName.ToLower Then
        '          thePaper = pSz
        '          found = True
        '          Exit For
        '        End If
        '      Next
        '    End If
        '  Catch ex As Exception
        '    MessageBox.Show("Error #" + Str$(Err.Number) + " has occured." + Err.Description)
        '  Finally
        '    dialog.PrinterSettings.DefaultPageSettings.PaperSize = thePaper
        '  End Try
        '  If (dialog.ShowDialog = DialogResult.OK) Then
        '    If CBool(Configuration.GetConfig("PrintXPSDIR")) Then
        '      If dialog.PrinterSettings.PrinterName.ToUpper.Contains("XPS") Then
        '        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        '        Dim xpsDIR As String = myPropertyService.GetProperty("XPSDIR", "C:\")
        '        dialog.PrinterSettings.PrintToFile = True
        '        dialog.PrinterSettings.PrintFileName = xpsDIR & Path.DirectorySeparatorChar & Now.Ticks.ToString & ".xps"
        '      End If
        '    End If

        '    document.Print()
        '  End If
        'End If

        'myMessageService.ShowError("${res:Longkong.Pojjaman.Commands.Print.CreatePrintDocumentError}")
      Catch ex As InvalidPrinterException

      End Try
    End Sub
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
        If TypeOf window.ActiveViewContent Is IPrintable Then
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

