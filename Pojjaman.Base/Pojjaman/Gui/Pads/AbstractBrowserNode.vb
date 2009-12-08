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
Imports ICSharpCode.SharpZipLib.Zip

Namespace Longkong.Pojjaman.Gui.Pads
    Public MustInherit Class AbstractBrowserNode
        Inherits TreeNode

#Region "Members"
        Public Shared ShowExtensions As Boolean = False

        Protected m_canLabelEdited As Boolean
        Protected m_contextmenuAddinTreePath As String
        Private m_iconImage As Image
        Protected m_userData As Object
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_iconImage = Nothing
            Me.m_canLabelEdited = True
            Me.m_userData = Nothing
            Me.m_contextmenuAddinTreePath = String.Empty
            MyBase.NodeFont = FormBrowserView.PlainFont
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property CanLabelEdited() As Boolean
            Get
                Return Me.m_canLabelEdited
            End Get
        End Property
        Public Overridable Property ContextmenuAddinTreePath() As String
            Get
                Return Me.m_contextmenuAddinTreePath
            End Get
            Set(ByVal value As String)
                Me.m_contextmenuAddinTreePath = value
            End Set
        End Property
        Public Overridable ReadOnly Property DragDropDataObject() As DataObject
            Get
                Return Nothing
            End Get
        End Property
        Public Property IconImage() As Image
            Get
                Return Me.m_iconImage
            End Get
            Set(ByVal value As Image)
                Dim index As Integer
                Me.m_iconImage = value
                index = FormBrowserView.GetImageIndexForImage(Me.m_iconImage)
                MyBase.SelectedImageIndex = index
                MyBase.ImageIndex = index
            End Set
        End Property
        Public Property UserData() As Object
            Get
                Return Me.m_userData
            End Get
            Set(ByVal value As Object)
                Me.m_userData = value
            End Set
        End Property
        'Public Overridable ReadOnly Property Project() As IProject
        '    Get
        '        If ((Not MyBase.Parent Is Nothing) AndAlso TypeOf MyBase.Parent Is AbstractBrowserNode) Then
        '            Return CType(MyBase.Parent, AbstractBrowserNode).Project
        '        End If
        '        Return Nothing
        '    End Get
        'End Property
        'Public Overridable ReadOnly Property Combine() As Combine
        '    Get
        '        If ((Not MyBase.Parent Is Nothing) AndAlso TypeOf MyBase.Parent Is AbstractBrowserNode) Then
        '            Return CType(MyBase.Parent, AbstractBrowserNode).Combine
        '        End If
        '        Return Nothing
        '    End Get
        'End Property
#End Region

#Region "Methods"
        Public Overridable Sub ActivateItem()
        End Sub
        Public Overridable Sub AfterLabelEdit(ByVal newName As String)
            Throw New NotImplementedException
        End Sub
        Public Overridable Sub BeforeCollapse()
        End Sub
        Public Overridable Sub BeforeExpand()
        End Sub
        Public Overridable Sub BeforeLabelEdit()
        End Sub
        Public Overridable Sub Dispose()
        End Sub
        Public Overridable Sub DoDragDrop(ByVal dataObject As IDataObject, ByVal effect As DragDropEffects)
            Throw New NotImplementedException
        End Sub
        Public Overridable Function GetDragDropEffect(ByVal dataObject As IDataObject, ByVal proposedEffect As DragDropEffects) As DragDropEffects
            Return DragDropEffects.None
        End Function
        Public Overridable Function RemoveNode() As Boolean
            Throw New NotImplementedException
        End Function
        Public Overridable Sub UpdateNaming()
            Dim node As AbstractBrowserNode
            For Each node In MyBase.Nodes
                node.UpdateNaming()
            Next
        End Sub
#End Region

    End Class
End Namespace

