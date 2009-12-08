Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Windows.Forms
Namespace Longkong.Reporting.Printing
    <DefaultEvent("Printing"), DefaultProperty("Document")> _
    Public Class PrintLogic
        Inherits Component

        Private Delegate Sub PrintInBackgroundDelegate()

#Region "Events"
        Public Event Printed As EventHandler
        Public Event Printing As EventHandler
#End Region

#Region "Members"
        Private m_document As PrintDocument
        Private m_printInBackground As Boolean
        Private m_printInProgress As Boolean
        Private m_showStatusDialog As Boolean

        Private pageSetupDialog1 As PageSetupDialog
        Private printDialog1 As PrintDialog
        Private printPreviewDialog1 As PrintPreviewDialog
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_showStatusDialog = True
            Me.m_printInBackground = False
            Me.m_printInProgress = False
            Me.pageSetupDialog1 = New PageSetupDialog
            Me.printPreviewDialog1 = New PrintPreviewDialog
            Me.printDialog1 = New PrintDialog
        End Sub
#End Region

#Region "Properties"
        <Description("Gets or sets the PrintDocument used by the dialog.")> _
        Public Property Document() As PrintDocument
            Get
                Return Me.m_document
            End Get
            Set(ByVal value As PrintDocument)
                Me.m_document = value
            End Set
        End Property
        <Description("Indicates that printing should be done in the background."), DefaultValue(False)> _
        Public Property PrintInBackground() As Boolean
            Get
                Return Me.m_printInBackground
            End Get
            Set(ByVal value As Boolean)
                Me.m_printInBackground = value
            End Set
        End Property
        <Browsable(False)> _
        Public ReadOnly Property PrintInProgress() As Boolean
            Get
                Return Me.m_printInProgress
            End Get
        End Property
        <DefaultValue(True), Description("The progress of the print job is shown in a status dialog.")> _
        Public Property ShowStatusDialog() As Boolean
            Get
                Return Me.m_showStatusDialog
            End Get
            Set(ByVal value As Boolean)
                Me.m_showStatusDialog = value
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overridable Sub BeginBackgroundPrint()
            Me.m_printInProgress = True
            Me.m_document.Print()
        End Sub
        Protected Overridable Sub OnPrinted()
            RaiseEvent Printed(Me, New EventArgs)
        End Sub
        Protected Overridable Sub OnPrinting()
            RaiseEvent Printing(Me, New EventArgs)
        End Sub
        Public Overridable Sub PageSetup(ByVal sender As Object, ByVal e As EventArgs)
            If Not Me.m_printInProgress Then
                Me.pageSetupDialog1.Document = Me.m_document
                Me.pageSetupDialog1.ShowDialog()
            End If
        End Sub
        Public Overridable Sub Preview(ByVal sender As Object, ByVal e As EventArgs)
            If Not Me.m_printInProgress Then
                Me.printPreviewDialog1.Document = Me.m_document
                Me.OnPrinting()
                Me.printPreviewDialog1.ShowDialog()
            End If
        End Sub
        Public Overridable Sub Print(ByVal sender As Object, ByVal e As EventArgs)
            If Not Me.m_printInProgress Then
                Me.printDialog1.Document = Me.m_document
                Dim result1 As DialogResult = Me.printDialog1.ShowDialog
                If (result1 = DialogResult.OK) Then
                    Dim controller1 As New StandardPrintController
                    If Me.ShowStatusDialog Then
                        Me.m_document.PrintController = New PrintControllerWithStatusDialog(controller1, "Please wait...")
                    Else
                        Me.m_document.PrintController = controller1
                    End If
                    Me.OnPrinting()
                    If Me.PrintInBackground Then
                        Dim delegate1 As PrintInBackgroundDelegate = New PrintInBackgroundDelegate(AddressOf Me.BeginBackgroundPrint)
                        delegate1.BeginInvoke(New AsyncCallback(AddressOf Me.PrintInBackgroundComplete), Nothing)
                    Else
                        Me.m_printInProgress = True
                        Me.m_document.Print()
                        Me.m_printInProgress = False
                        Me.OnPrinted()
                    End If
                End If
            End If
        End Sub
        Protected Overridable Sub PrintInBackgroundComplete(ByVal r As IAsyncResult)
            Me.m_printInProgress = False
            Me.OnPrinted()
        End Sub
#End Region

    End Class
End Namespace