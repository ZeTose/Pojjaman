Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports System.ComponentModel
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Pads
    Public Class ToolPad
        Inherits AbstractPadContent

#Region "Members"
        Private Shared m_toolBox As ToolBox = Nothing
        Private Shared m_path As String = "/Pojjaman/Workbench/FormatToolBar"
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New("${res:MainWindow.Windows.FormatToolBoxLabel}", "Icons.16x16.FormatToolBox")
            m_toolBox = New ToolBox(m_path)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Control() As System.Windows.Forms.Control
            Get
                Return ToolPad.m_toolBox
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overrides Sub Dispose()
            MyBase.Dispose()
            If (ToolPad.m_toolBox Is Nothing) Then
                Return
            End If
            ToolPad.m_toolBox.Dispose()
            ToolPad.m_toolBox = Nothing
        End Sub
#End Region

    End Class

End Namespace

