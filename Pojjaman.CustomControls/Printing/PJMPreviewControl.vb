Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Namespace Longkong.Pojjaman.Gui.Components
    Public Delegate Sub SetPreviewPageInfo(ByVal ppis() As PreviewPageInfo)
    Public Class PJMPreviewControl
        Inherits PreviewPrintController

#Region "Members"
        Private m_handler As SetPreviewPageInfo
#End Region

#Region "Constructors"
        Public Sub New(ByVal handler As SetPreviewPageInfo)
            m_handler = handler
        End Sub
#End Region

#Region "Overrides"
        Public Overrides Sub OnEndPage(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
            MyBase.OnEndPage(document, e)
        End Sub
        Public Overrides Sub OnEndPrint(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintEventArgs)
            MyBase.OnEndPrint(document, e)
            Dim ppis As PreviewPageInfo() = GetPreviewPageInfo()
            If ppis.Length > 0 Then
                If Not m_handler Is Nothing Then
                    m_handler(ppis)
                End If
            End If
        End Sub
        Public Overrides Function OnStartPage(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintPageEventArgs) As System.Drawing.Graphics
            Return MyBase.OnStartPage(document, e)
        End Function
        Public Overrides Sub OnStartPrint(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintEventArgs)
            MyBase.OnStartPrint(document, e)
        End Sub
        'Public Overrides Property UseAntiAlias() As Boolean
        '    Get
        '        Return MyBase.UseAntiAlias
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        MyBase.UseAntiAlias = Value
        '    End Set
        'End Property
#End Region

    End Class
End Namespace

