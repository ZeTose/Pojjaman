Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Delegate Sub NodeAction(ByVal n As TreeNode)
    Public NotInheritable Class TreeViewHelper

        Private Sub New()
        End Sub 'New
        Private Function GetMaximumLevel(ByVal node As TreeNode, ByVal currentLevel As Integer) As Integer
            If node.GetNodeCount(False) = 0 Then
                Return currentLevel
            End If
            Return GetMaximumLevel(node.Nodes, currentLevel)
        End Function
        Private Function GetMaximumLevel(ByVal nodes As TreeNodeCollection, ByVal currentLevel As Integer) As Integer
            Dim max As Integer = 0
            currentLevel += 1
            For Each node As TreeNode In nodes
                max = Math.Max(max, GetMaximumLevel(node, currentLevel))
            Next
            Return max
        End Function
        Public Shared Function GetTreeString(ByVal tv As TreeView) As String
            If tv.GetNodeCount(True) = 0 Then
                Return ""
            End If
            Dim ret As String = GetNodeString(tv.Nodes, 0)
            Return ret
        End Function
        Private Shared Function GetNodeString(ByVal nodes As TreeNodeCollection, ByVal level As Integer) As String
            Dim s As String = ""
            For Each node As TreeNode In nodes
                If node.IsExpanded Then
                    s &= Space(10 * level) & "-" & node.Text & vbCrLf
                    s &= GetNodeString(node.Nodes, level + 1)
                ElseIf node.GetNodeCount(True) = 0 Then
                    s &= Space(10 * level) & node.Text & vbCrLf
                Else
                    s &= Space(10 * level) & "+" & node.Text & vbCrLf
                End If
            Next
            Return s
        End Function
        Public Shared Sub TraverseNode(ByVal n As TreeNode, ByVal na As NodeAction, ByVal desiredLevel As Integer)
            TraverseNode(n, na, desiredLevel, 0)
        End Sub
        Private Shared Sub TraverseNode(ByVal n As TreeNode, ByVal na As NodeAction, ByVal desiredLevel As Integer, ByVal currentLevel As Integer)
            If currentLevel = desiredLevel Then
                na(n)
            End If
            currentLevel += 1
            For Each aNode As TreeNode In n.Nodes
                TraverseNode(aNode, na, desiredLevel, currentLevel)
            Next
        End Sub
        Public Shared Sub TraverseNode(ByVal n As TreeNode, ByVal na As NodeAction)
            na(n)
            For Each aNode As TreeNode In n.Nodes
                TraverseNode(aNode, na)
            Next
        End Sub
        Public Shared Sub TraverseNodeBackward(ByVal n As TreeNode, ByVal na As NodeAction)
            For Each aNode As TreeNode In n.Nodes
                TraverseNodeBackward(aNode, na)
            Next
            na(n)
        End Sub
        Public Shared Function GetChildIndex(ByVal nodes As TreeNodeCollection, ByVal childNode As TreeNode) As Integer
            Dim i As Integer = 0
            For Each node As TreeNode In nodes
                If node.Text.CompareTo(childNode.Text) > 0 Then
                    Return i
                End If
                i += 1
            Next
            Return i
        End Function
        '**********************************************************************
        'ใช้ method นี้เพื่อแสดง/ไม่แสดง จำนวนลูกของ node ใน nodeCollection ใดๆ
        'โดยเลือกจาก parameter "display"
        '**********************************************************************
        Public Shared Sub DisplayChildrenCount(ByVal nodes As TreeNodeCollection, ByVal display As Boolean)
            Dim node As TreeNode
            For Each node In nodes
                node.Text = System.Text.RegularExpressions.Regex.Replace(node.Text, " \[.*\]$", "")
                If display Then
                    node.Text &= " [" & CStr(node.Nodes.Count) & "]"
                End If
                DisplayChildrenCount(node.Nodes, display)
            Next
        End Sub
        '**********************************************************************
        'ใช้ method นี้เพื่อสร้าง treeview ของ database ที่มีลักษณะเป็น hierarchical 
        'Warning!!!! column order --> id,parid,level,code,tnme,enme,path
        '**********************************************************************
        Public Shared Sub PopulateTree(ByVal myTree As TreeView)
            Dim sql As String

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim cn As New SqlConnection(sqlConString)
            cn.Open()
            sql = "select csg_id,csg_parid,csg_level,csg_code,csg_name,csg_altname,csg_path from customergroup"
            Dim ds As DataSet = SqlHelper.ExecuteDataset(cn, CommandType.Text, sql)
            Dim rows As DataRow() = ds.Tables(0).Select("csg_parid is null or csg_parid = csg_id")
            myTree.BeginUpdate()
            myTree.Nodes.Clear()
            Dim i As Integer
            For i = 0 To rows.GetUpperBound(0)
                Dim NodeTag As Integer = CInt(rows(i)(0))
                Dim NodeNme As String = CStr(rows(i)(3)) & " - " & CStr(rows(i)(4))
                Dim theNode As TreeNode = myTree.Nodes.Add(NodeNme)
                theNode.Tag = NodeTag
                AddChildren(theNode, ds.Tables(0))
            Next
            myTree.EndUpdate()
            cn.Close()
            ds = Nothing
        End Sub

        Private Shared Sub AddChildren(ByVal nodeParent As TreeNode, ByVal dTable As DataTable)
            Dim row As DataRow
            Dim theNode As TreeNode
            Dim NodeTag As Integer
            Dim NodeNme As String
            For Each row In dTable.Select("csg_parid <> csg_id and csg_parid=" & CStr(nodeParent.Tag))
                NodeTag = CInt(row(0))
                NodeNme = CStr(row(3)) & " - " & CStr(row(4))
                theNode = nodeParent.Nodes.Add(NodeNme)
                theNode.Tag = NodeTag
                AddChildren(theNode, dTable)
            Next
        End Sub
        Public Shared Function IsAncecstor(ByVal father As TreeNode, ByVal suspectedChild As TreeNode) As Boolean
            Dim node As TreeNode
            If suspectedChild.Parent Is Nothing Then
                Return False
            End If
            If suspectedChild.Parent Is father Then
                Return True
            End If
            Return TreeViewHelper.IsAncecstor(father, suspectedChild.Parent)
        End Function
        Public Shared Sub Search(ByVal myTree As TreeView, ByVal criteria As String)
            If criteria = "" Then
                Return
            End If
            myTree.BeginUpdate()
            Dim i As Integer
            For i = 0 To 3
                Search(myTree.Nodes, criteria)
            Next
            myTree.EndUpdate()
        End Sub
        Public Shared Sub Search(ByVal myNodes As TreeNodeCollection, ByVal criteria As String)
            Dim node As TreeNode
            Dim i As Integer = 0
            While i < myNodes.Count
                node = myNodes(i)
                i += 1
                'ClearHilightNode(node)
                If Not node Is Nothing Then
                    If node.Text.ToUpper.IndexOf(criteria.ToUpper) >= 0 Then
                        HilightNode(node)
                    Else
                        If node.Nodes.Count <= 0 Then
                            node.Remove()
                            node = Nothing
                            i -= 1
                        End If
                    End If
                    If Not node Is Nothing Then
                        Search(node.Nodes, criteria)
                    End If
                End If
            End While
        End Sub
        Public Shared Sub HilightNode(ByVal node As TreeNode)
            HilightNode(node, Color.Red)
        End Sub
        Public Shared Sub HilightNode(ByVal node As TreeNode, ByVal color As Color)
            node.ForeColor = color
            node.EnsureVisible()
        End Sub
        Public Shared Sub ClearHilightNode(ByVal node As TreeNode)
            node.BackColor = node.TreeView.BackColor
            node.ForeColor = node.TreeView.ForeColor
        End Sub
        Private Shared Sub PrintRecursive(ByVal n As TreeNode)
            System.Diagnostics.Debug.WriteLine(n.Text)
            Dim aNode As TreeNode
            For Each aNode In n.Nodes
                PrintRecursive(aNode)
            Next
        End Sub
        Public Shared Sub CallRecursive(ByVal aTreeView As TreeView)
            Dim n As TreeNode
            For Each n In aTreeView.Nodes
                PrintRecursive(n)
            Next
        End Sub
        Private Shared Function SearchTag(ByVal n As TreeNode, ByVal t As Integer) As TreeNode
            If IsNumeric(n.Tag) AndAlso CInt(n.Tag) = t Then
                Return n
            End If
            Dim aNode As TreeNode
            For Each aNode In n.Nodes
                Dim tn As TreeNode = SearchTag(aNode, t)
                If Not tn Is Nothing Then
                    Return tn
                End If
            Next
        End Function
        Public Shared Function SearchTag(ByVal tv As TreeView, ByVal t As Integer) As TreeNode
            Dim n As TreeNode
            For Each n In tv.Nodes
                Dim tn As TreeNode = SearchTag(n, t)
                If Not tn Is Nothing Then
                    Return tn
                End If
            Next
        End Function

        '----------------------Search ตาม string id|parid
        Private Shared Function SearchTagString(ByVal n As TreeNode, ByVal t As Integer) As TreeNode
            Dim tag As String = CStr(n.Tag)
            If tag.IndexOf("|"c) > 0 Then ' > 0 เพราะต้องมีอย่างอื่นอยู่หน้า |
                Dim id As Integer = CInt(tag.Split("|"c)(0))
                If id = t Then
                    Return n
                End If
                For Each aNode As TreeNode In n.Nodes
                    Dim tn As TreeNode = SearchTagString(aNode, t)
                    If Not tn Is Nothing Then
                        Return tn
                    End If
                Next
            End If
        End Function
        Public Shared Function SearchTagString(ByVal tv As TreeView, ByVal t As Integer) As TreeNode
            For Each n As TreeNode In tv.Nodes
                Dim tn As TreeNode = SearchTagString(n, t)
                If Not tn Is Nothing Then
                    Return tn
                End If
            Next
        End Function
    End Class
End Namespace
