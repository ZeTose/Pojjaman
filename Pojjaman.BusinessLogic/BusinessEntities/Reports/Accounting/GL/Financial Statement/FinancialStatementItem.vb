Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class FinancialStatementItem
        Inherits TreeBaseEntity

#Region "Member"
        'Private m_grouptype As FinancialStatementType
        Private m_linenumber As Integer
        Private m_itemtype As Integer
        Private m_formular As String
        Private m_note As String
        Private m_isroot As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal myParent As FinancialStatementItem)
            MyBase.New(myParent)
            Me.Level = myParent.Level + 1
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                '.m_grouptype = New FinancialStatementType(-1)
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' linenumber
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_linenumber") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_linenumber") Then
                    .m_linenumber = CInt(dr(aliasPrefix & Me.Prefix & "_linenumber"))
                End If
                ' itemtype
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entitytype") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entitytype") Then
                    .m_itemtype = CInt(dr(aliasPrefix & Me.Prefix & "_entitytype"))
                End If
                ' formular
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_formular") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_formular") Then
                    .m_formular = CStr(dr(aliasPrefix & Me.Prefix & "_formular"))
                End If
                ' note
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"        'Public Property GroupType() As FinancialStatementType        '    Get
        '        Return m_grouptype
        '    End Get
        '    Set(ByVal Value As FinancialStatementType)
        '        m_grouptype = Value
        '    End Set
        'End Property        Public Property LineNumber() As Integer            Get
                Return m_linenumber
            End Get
            Set(ByVal Value As Integer)
                m_linenumber = Value
            End Set
        End Property        Public Property Formular() As String            Get
                Return m_formular
            End Get
            Set(ByVal Value As String)
                m_formular = Value
            End Set
        End Property        Public Property ItemType() As Integer            Get
                Return m_itemtype
            End Get
            Set(ByVal Value As Integer)
                m_itemtype = Value
            End Set
        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property#End Region#Region " Overrides Properties "        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "FinancialStatementItem"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.FinancialStatementItem.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.FinancialStatementItem"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.FinancialStatementItem"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.FinancialStatementItem.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "fswbs"
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
            If parId <> Id Then
                Me.Parent = New FinancialStatementItem(parId)
            Else
                Me.Parent = Nothing
            End If
        End Sub
        Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
            Dim par As New FinancialStatementItem
            par.Id = id
            par.Code = code
            par.Name = name
            Me.Parent = par
        End Sub
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("0")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try
                Dim cmd As New SqlCommand("delete wbs where wbs_id=" & Me.Id)
                cmd.Connection = conn
                cmd.Transaction = trans
                cmd.CommandText = "delete glformat where glf_id=" & Me.Id
                cmd.ExecuteNonQuery()
                trans.Commit()
                Return New SaveErrorException("1")
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Finally
                conn.Close()
            End Try
        End Function
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                Dim parID As Object = 0
                If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
                    parID = Me.Parent.Id
                End If

                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
                Dim paramArrayList As New ArrayList

                paramArrayList.Add(returnVal)
                If Me.Originated Then
                    paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
                'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_boq", ValidIdOrDBNull(Me.Boq)))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_parid", parID))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_level", Me.Level))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_path", Me.Path))
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))


                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(Me.ConnectionString)
                conn.Open()
                trans = conn.BeginTransaction()
                Try
                    Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

                    If IsNumeric(returnVal.Value) Then
                        Select Case CInt(returnVal.Value)
                            Case -1, -2, -5
                                trans.Rollback()
                                Return New SaveErrorException(returnVal.Value.ToString)
                            Case Else
                        End Select
                    ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                        trans.Rollback()
                        Return New SaveErrorException(returnVal.Value.ToString)
                    End If
                    trans.Commit()
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Return New SaveErrorException(ex.ToString)
                Finally
                    conn.Close()
                End Try
            End With
        End Function
#End Region

#Region "OVerrides"
        Public Overrides Sub PopulateTree(ByVal tvGroup As TreeView, ByVal ParamArray filters() As Filter)
            Dim ds As DataSet = Me.GetListDataSet("", filters)
            Dim dt As DataTable = ds.Tables(0)
            tvGroup.BeginUpdate()
            tvGroup.Nodes.Clear()
            'tvGroup.ForeColor = Color.Gray
            For Each row As DataRow In dt.Rows
                Dim NodeTag As FinancialStatementItem = New FinancialStatementItem(row, "")
                Dim nodeNote As String = ""
                If Not row.IsNull(Prefix & "_note") AndAlso row(Prefix & "_note").ToString.Length > 0 Then
                    nodeNote = " (" & CStr(row(Prefix & "_note")) & ")"
                End If
                Dim NodeNme As String = CStr(row(Prefix & "_code")) & " - " & CStr(row(Prefix & "_name")) & nodeNote
                Dim parentNodes As TreeNodeCollection
                If IsDBNull(row(Prefix & "_parid")) OrElse CInt(row(Prefix & "_parid")) = CInt(row(Prefix & "_id")) Then
                    parentNodes = tvGroup.Nodes
                Else
                    Dim parnode As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(row(Prefix & "_parid")))
                    If parnode Is Nothing Then
                        parentNodes = tvGroup.Nodes
                    Else
                        parentNodes = parnode.Nodes
                    End If
                End If
                Dim theNode As TreeNode = parentNodes.Add(NodeNme)
                theNode.Tag = NodeTag
            Next
            If ds.Tables.Count = 2 Then
                Dim dt2 As DataTable = ds.Tables(1)
                For Each row As DataRow In dt2.Rows
                    Dim node As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(row(Prefix & "_id")))
                    TreeViewHelper.HilightNode(node, Color.Blue)
                Next
            End If
            tvGroup.EndUpdate()
        End Sub
        Public Overrides Function ToString() As String
            Dim nodeNote As String = ""
            If Not Me.Note Is Nothing AndAlso Me.Note.Length > 0 Then
                nodeNote = " (" & Me.Note & ")"
            End If
            Return Me.Code & " - " & Me.Name & nodeNote
        End Function
#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
Public Class FinancialStatementItemCollection
        Inherits CollectionBase

#Region " Members "
        Private m_owner As FinancialStatementFormat
#End Region

#Region " Constructors "
        Public Sub New()
        End Sub
        Public Sub New(ByVal owner As FinancialStatementFormat)
            Me.m_owner = owner
            If Not Me.m_owner.Originated Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetFinanceWBSs" _
            , New SqlParameter("@financef_id", Me.m_owner.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New FinancialStatementItem(row, "")
                'item.Boq = m_boq
                Me.Add(Item)
            Next
        End Sub
#End Region

#Region " Properties "
        Public Property FinancialStatementFormat() As FinancialStatementFormat            Get                Return m_owner            End Get            Set(ByVal Value As FinancialStatementFormat)                m_owner = Value            End Set        End Property        Default Public Property Item(ByVal index As Integer) As FinancialStatementItem
            Get
                Return CType(MyBase.List.Item(index), FinancialStatementItem)
            End Get
            Set(ByVal value As FinancialStatementItem)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region " Class Methods "
        Public Function GetRoot() As FinancialStatementItem
            For Each myItem As FinancialStatementItem In Me
                If myItem.Id <> 0 And myItem.Parent.Id = myItem.Id Then
                    Return myItem
                End If
                If myItem.Parent Is myItem Then
                    Return myItem
                End If
            Next
        End Function
        Public Sub UpdateParentId(ByVal oldParid As Integer, ByVal newParid As Integer)
            For Each myItem As FinancialStatementItem In Me
                Dim parent As FinancialStatementItem = CType(myItem.Parent, FinancialStatementItem)
                If Not Me.Contains(parent) Then
                    If parent.Id = oldParid Then
                        parent.Id = newParid
                    End If
                End If
            Next
        End Sub
        Public Function GetChildsOf(ByVal parent As FinancialStatementItem) As FinancialStatementItemCollection
            Dim newFIColl As New FinancialStatementItemCollection
            For Each myItem As FinancialStatementItem In Me
                If Not myItem Is myItem.Parent AndAlso myItem.Parent Is parent Then
                    newFIColl.Add(myItem)
                ElseIf myItem.Id <> 0 AndAlso myItem.Id <> parent.Id AndAlso myItem.Parent.Id = parent.Id Then
                    newFIColl.Add(myItem)
                Else
                End If
            Next
            Return newFIColl
        End Function
        Public Function GetSubOrdinatesOf(ByVal parent As FinancialStatementItem) As FinancialStatementItemCollection
            Dim newWbsColl As New FinancialStatementItemCollection
            For Each collWbs As FinancialStatementItem In Me
                Dim tmpWbs As FinancialStatementItem = collWbs
                Dim tmpColl As New FinancialStatementItemCollection
                tmpColl.Add(tmpWbs)
                While Not tmpWbs Is Nothing
                    '>>>> สุดทางเจอแม่แล้ว
                    If tmpWbs.Id <> 0 And tmpWbs.Id = parent.Id Then
                        newWbsColl.AddRange(tmpColl)
                        Exit While
                    ElseIf tmpWbs Is parent Then
                        newWbsColl.AddRange(tmpColl)
                        Exit While
                    End If
                    tmpWbs = CType(tmpWbs.Parent, FinancialStatementItem)
                    If Not tmpWbs Is Nothing Then
                        tmpColl.Add(tmpWbs)
                    End If
                End While
                tmpColl.Clear()
            Next
            Return newWbsColl
        End Function
        Public Sub Populate(ByVal tvWbs As TreeView)
            tvWbs.Nodes.Clear()
            For Each myWbs As FinancialStatementItem In Me
                Dim parentNodes As TreeNodeCollection = Nothing
                If myWbs.Parent Is myWbs Then
                    parentNodes = tvWbs.Nodes
                ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
                    parentNodes = tvWbs.Nodes
                Else
                    Dim parentNode As TreeNode = FindNode(tvWbs, CType(myWbs.Parent, FinancialStatementItem))
                    If Not parentNode Is Nothing Then
                        parentNodes = parentNode.Nodes
                    End If
                End If
                If Not parentNodes Is Nothing Then
                    parentNodes.Add(myWbs.ToString).Tag = myWbs
                End If
            Next
        End Sub
        Public Function FindNode(ByVal tv As TreeView, ByVal myWbs As FinancialStatementItem) As TreeNode
            Dim n As TreeNode
            For Each n In tv.Nodes
                Dim tn As TreeNode = FindNode(n, myWbs)
                If Not tn Is Nothing Then
                    Return tn
                End If
            Next
        End Function
        Private Function FindNode(ByVal n As TreeNode, ByVal myWbs As FinancialStatementItem) As TreeNode
            If TypeOf n.Tag Is FinancialStatementItem Then
                Dim nodeWbs As FinancialStatementItem = CType(n.Tag, FinancialStatementItem)
                If nodeWbs Is myWbs Then
                    Return n
                End If
                If nodeWbs.Id <> 0 And nodeWbs.Id = myWbs.Id Then
                    Return n
                End If
            End If
            Dim aNode As TreeNode
            For Each aNode In n.Nodes
                Dim tn As TreeNode = FindNode(aNode, myWbs)
                If Not tn Is Nothing Then
                    Return tn
                End If
            Next
        End Function
#End Region

#Region " Collection Methods "
        Public Function Add(ByVal value As FinancialStatementItem) As Integer
            If Not Me.Contains(value) Then
                'value.Boq = m_boq
                Return MyBase.List.Add(value)
            End If
        End Function
        Public Sub AddRange(ByVal value As FinancialStatementItemCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As FinancialStatementItem())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As FinancialStatementItem) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As FinancialStatementItem(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As FinancialStatementItemEnumerator
            Return New FinancialStatementItemEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As FinancialStatementItem) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As FinancialStatementItem)
            'value.Boq = m_boq
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As FinancialStatementItem)
            If Not Me.m_owner Is Nothing Then
                'If Not Me.m_owner.ItemCollection Is Nothing Then
                '    'Me.m_boq.ItemCollection.Remove(Me.m_boq.ItemCollection.GetCollectionForFinancialStatementItem(value))
                'End If
            End If
            For Each toDelete As FinancialStatementItem In GetSubOrdinatesOf(value)
                MyBase.List.Remove(toDelete)
            Next
        End Sub
        Public Sub Remove(ByVal value As FinancialStatementItemCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub

#End Region

        Public Class FinancialStatementItemEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As FinancialStatementItemCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, FinancialStatementItem)
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                Return Me.m_baseEnumerator.MoveNext
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                Me.m_baseEnumerator.Reset()
            End Sub
        End Class
    End Class

End Namespace

