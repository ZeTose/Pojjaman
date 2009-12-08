Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns.Conditions
Imports System.Windows.Forms
Namespace Longkong.Core.AddIns
    Public Class DefaultAddInTreeNode
        Implements IAddInTreeNode

#Region "Members"
        Private m_childNodes As Hashtable
        Private m_codon As ICodon
        Private m_conditionCollection As ConditionCollection
#End Region

#Region "Constructrs"
        Public Sub New()
            Me.m_childNodes = New Hashtable
            Me.m_codon = Nothing
            Me.m_conditionCollection = Nothing
        End Sub
#End Region

#Region "Methods"
        Private Function GetSubnodesAsSortedArray() As IAddInTreeNode()
            Dim node As IAddInTreeNode = Me
            Dim index As Integer = node.ChildNodes.Count
            Dim sortedNodes As IAddInTreeNode() = New IAddInTreeNode(index - 1) {}
            Dim visited As New Hashtable(index)
            Dim anchestor As New Hashtable(index)
            For Each key As String In node.ChildNodes.Keys
                visited.Item(key) = False
                anchestor.Item(key) = New ArrayList
            Next
            For Each child As DictionaryEntry In node.ChildNodes
                If (Not CType(child.Value, IAddInTreeNode).Codon.InsertAfter Is Nothing) Then
                    For i As Integer = 0 To CType(child.Value, IAddInTreeNode).Codon.InsertAfter.Length - 1
                        If anchestor.Contains(CType(child.Value, IAddInTreeNode).Codon.InsertAfter(i).ToString) Then
                            CType(anchestor(CType(child.Value, IAddInTreeNode).Codon.InsertAfter(i).ToString), ArrayList).Add(child.Key)
                        End If
                    Next
                End If
                If (Not CType(child.Value, IAddInTreeNode).Codon.InsertBefore Is Nothing) Then
                    For i As Integer = 0 To CType(child.Value, IAddInTreeNode).Codon.InsertBefore.Length - 1
                        If anchestor.Contains(child.Key) Then
                            CType(anchestor.Item(child.Key), ArrayList).Add(CType(child.Value, IAddInTreeNode).Codon.InsertBefore(i))
                        End If
                    Next
                End If
            Next
            Dim keyarray As String() = New String(visited.Keys.Count - 1) {}
            visited.Keys.CopyTo(keyarray, 0)

            For i As Integer = 0 To keyarray.Length - 1
                If Not CType(visited.Item(keyarray(i)), Boolean) Then
                    index = Me.Visit(keyarray(i), node.ChildNodes, sortedNodes, visited, anchestor, index)
                End If
            Next
            Return sortedNodes
        End Function
        Private Function Visit(ByVal key As String, ByVal nodes As Hashtable, ByVal sortedNodes As IAddInTreeNode(), ByVal visited As Hashtable, ByVal anchestor As Hashtable, ByVal index As Integer) As Integer
            visited(key) = True
            Try
                For Each anch As String In CType(anchestor.Item(key), ArrayList)
                    If Not CType(visited.Item(anch), Boolean) Then
                        index = Me.Visit(anch, nodes, sortedNodes, visited, anchestor, index)
                    End If
                Next
                index -= 1
                sortedNodes(index) = CType(nodes.Item(key), IAddInTreeNode)
                Return index
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(key & ":" & ex.Message)
            End Try
        End Function
#End Region

#Region "IAddInTreeNode"
        Public Function BuildChildItem(ByVal childItemID As String, ByVal caller As Object) As Object Implements IAddInTreeNode.BuildChildItem
            Dim sortedNodes As IAddInTreeNode() = Me.GetSubnodesAsSortedArray
            For Each curNode As IAddInTreeNode In sortedNodes
                If curNode.Codon.ID = childItemID Then
                    Dim subItems As ArrayList = curNode.BuildChildItems(caller)
                    Return curNode.Codon.BuildItem(caller, subItems, Nothing)
                End If
                Dim o As Object = curNode.BuildChildItem(childItemID, caller)
                If Not o Is Nothing Then
                    Return o
                End If
            Next
            Return Nothing
        End Function

        Public Function BuildChildItems(ByVal caller As Object) As System.Collections.ArrayList Implements IAddInTreeNode.BuildChildItems
            Dim items As New ArrayList
            Dim sortedNodes As IAddInTreeNode() = Me.GetSubnodesAsSortedArray
            For Each curNode As IAddInTreeNode In sortedNodes
                Dim subItems As ArrayList = curNode.BuildChildItems(caller)
                Dim newItem As Object = Nothing
                If (curNode.Codon.HandleConditions OrElse (curNode.ConditionCollection.GetCurrentConditionFailedAction(caller) = ConditionFailedAction.Nothing)) Then
                    newItem = curNode.Codon.BuildItem(caller, subItems, curNode.ConditionCollection)
                End If
                If Not newItem Is Nothing Then
                    items.Add(newItem)
                End If
            Next
            Return items
        End Function

        Public ReadOnly Property ChildNodes() As System.Collections.Hashtable Implements IAddInTreeNode.ChildNodes
            Get
                Return Me.m_childNodes
            End Get
        End Property

        Public Property Codon() As Codons.ICodon Implements IAddInTreeNode.Codon
            Get
                Return Me.m_codon
            End Get
            Set(ByVal Value As Codons.ICodon)
                Me.m_codon = Value
            End Set
        End Property

        Public Property ConditionCollection() As Conditions.ConditionCollection Implements IAddInTreeNode.ConditionCollection
            Get
                Return Me.m_conditionCollection
            End Get
            Set(ByVal Value As Conditions.ConditionCollection)
                Me.m_conditionCollection = Value
            End Set
        End Property

        Public Function GetCurrentConditionFailedAction(ByVal caller As Object) As Conditions.ConditionFailedAction Implements IAddInTreeNode.GetCurrentConditionFailedAction
            If (Me.ConditionCollection Is Nothing) Then
                Return ConditionFailedAction.Nothing
            End If
            Return Me.ConditionCollection.GetCurrentConditionFailedAction(caller)
        End Function
#End Region

    End Class
End Namespace
