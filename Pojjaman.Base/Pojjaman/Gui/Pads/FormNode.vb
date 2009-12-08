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

Namespace Longkong.Pojjaman.Gui.Pads
    Public Class FormNode
        Inherits AbstractBrowserNode

#Region "Members"
        Public Shared ReadOnly DefaultContextMenuPath As String = "/Pojjaman/Views/FormsBrowser/ContextMenu/DefaultFormNode"
#End Region

#Region "Constructors"
        Public Sub New(ByVal viewInfo As ITreeBrowsableViewContent)
            MyBase.UserData = viewInfo
            Me.m_contextmenuAddinTreePath = FormNode.DefaultContextMenuPath
            Me.SetNodeLabel()
            Me.SetNodeIcon()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub ActivateItem()
            If Not Me.UserData Is Nothing AndAlso TypeOf Me.UserData Is Form Then
                'Todo: Show Form!
            End If
        End Sub
        Protected Overridable Sub SetNodeIcon()
            Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
            MyBase.IconImage = myIconService.GetImageForFormType(CType(Me.UserData, ITreeBrowsableViewContent).Control.Name)
        End Sub
        Protected Overridable Sub SetNodeLabel()
            MyBase.Text = CType(Me.UserData, ITreeBrowsableViewContent).TabPageText
        End Sub
        Public Overrides Sub UpdateNaming()
            Me.SetNodeLabel()
            MyBase.UpdateNaming()
        End Sub
#End Region

    End Class
End Namespace

