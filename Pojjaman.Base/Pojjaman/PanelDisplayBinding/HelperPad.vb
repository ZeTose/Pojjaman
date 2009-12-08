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
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Namespace Longkong.Pojjaman.PanelDisplayBinding
    Public Class HelperPad
        Inherits AbstractPadContent

#Region "Members"
        Private m_panel As UserControl
#End Region

#Region "Constructors"
        Public Sub New(ByVal panel As IPanel)
            MyBase.New(panel.Title, panel.Icon)
            Me.m_panel = CType(panel, UserControl)
            'Me.DockAreas = New String() {"Float", "DockBottom"}
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Control() As System.Windows.Forms.Control
            Get
                Return Me.m_panel
            End Get
        End Property
        Public Overrides ReadOnly Property HideOnClose() As Boolean
            Get
                Return False
            End Get
        End Property
#End Region

    End Class
End Namespace

