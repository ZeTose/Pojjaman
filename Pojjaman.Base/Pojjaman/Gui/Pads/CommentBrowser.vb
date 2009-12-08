Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports Microsoft.Win32
Imports System.Text
Imports System.Threading
Imports Longkong.Pojjaman.FormDisplayBinding

Namespace Longkong.Pojjaman.Gui.Pads
    Public Class CommentBrowser
        Inherits AbstractPadContent
        Implements IContentUpdate

#Region "Members"
        Private m_commentPanel As Panel
        Private m_richTextBox As RichTextBox
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New("${res:MainWindow.Windows.CommentBrowserLabel}", "Icons.16x16.HelpTopic")
            Me.m_commentPanel = New Panel
            Me.m_richTextBox = New RichTextBox
            Me.m_richTextBox.Dock = DockStyle.Fill
            Me.m_richTextBox.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.m_commentPanel.Controls.Add(Me.m_richTextBox)
            Dim service1 As ResourceService = CType(ServiceManager.Services.GetService(GetType(Longkong.Core.Services.IResourceService)), ResourceService)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Control() As System.Windows.Forms.Control
            Get
                Return Me.m_commentPanel
            End Get
        End Property
#End Region

#Region "Methods"

#End Region

#Region "IContentUpdate"
        Public Sub UpdateContent() Implements IContentUpdate.UpdateContent
            Me.m_richTextBox.Text = "TestContentUpdate"
        End Sub
#End Region

    End Class
End Namespace

