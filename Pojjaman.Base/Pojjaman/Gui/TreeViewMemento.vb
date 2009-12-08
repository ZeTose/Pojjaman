Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Gui
Imports System.Xml
Namespace Longkong.Pojjaman.Gui
    Public Class TreeViewMemento
        Implements IXmlConvertable

#Region "Members"
        Private m_parent As XmlElement
        Private m_treeView As treeView
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_treeView = Nothing
            Me.m_parent = Nothing
        End Sub
        Public Sub New(ByVal treeView As TreeView)
            Me.m_treeView = Nothing
            Me.m_parent = Nothing
            Me.m_treeView = treeView
        End Sub
#End Region

#Region "Methods"
        Private Sub RestoreTree(ByVal nodes As TreeNodeCollection, ByVal parent As XmlElement)
            For Each el As XmlElement In parent.ChildNodes
                For Each node As TreeNode In nodes
                    If (node.Text = el.Attributes.ItemOf("name").InnerText) Then
                        node.Expand()
                        Me.RestoreTree(node.Nodes, el)
                        Exit For
                    End If
                Next
            Next
        End Sub
        Private Sub SaveTree(ByVal nodes As TreeNodeCollection, ByVal doc As XmlDocument, ByVal el As XmlElement)
            For Each node As TreeNode In nodes
                If node.IsExpanded Then
                    Dim nodeEl As XmlElement = doc.CreateElement("Node")
                    Dim attribute1 As XmlAttribute = doc.CreateAttribute("name")
                    attribute1.InnerText = node.Text
                    nodeEl.Attributes.Append(attribute1)
                    el.AppendChild(nodeEl)
                    Me.SaveTree(node.Nodes, doc, nodeEl)
                End If
            Next
        End Sub
        Public Sub Restore(ByVal view As TreeView)
            view.BeginUpdate()
            Me.RestoreTree(view.Nodes, Me.m_parent)
            view.EndUpdate()
        End Sub
#End Region

#Region "IXmlConvertable"
        Public Function FromXmlElement(ByVal element As System.Xml.XmlElement) As Object Implements IXmlConvertable.FromXmlElement
            Me.m_parent = element
            Return Me
        End Function
        Public Function ToXmlElement(ByVal doc As System.Xml.XmlDocument) As System.Xml.XmlElement Implements IXmlConvertable.ToXmlElement
            Dim el As XmlElement = doc.CreateElement("TreeView")
            Me.SaveTree(Me.m_treeView.Nodes, doc, el)
            Return el
        End Function
#End Region

    End Class
End Namespace