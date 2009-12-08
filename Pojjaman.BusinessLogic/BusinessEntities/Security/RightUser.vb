Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Security.Cryptography
Imports Longkong.Pojjaman.Gui.Components
Imports System.Reflection
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RightUser

#Region "Members"
        Private m_right As Right
        Private m_user As User
        Private m_level As Integer
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & "userright_level") AndAlso Not dr.IsNull(aliasPrefix & "userright_level") Then
                    .m_level = CInt(dr(aliasPrefix & "userright_level"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "user_id") AndAlso Not dr.IsNull(aliasPrefix & "user_id") Then
                    If Not dr.IsNull("user_id") Then
                        .m_user = New User(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "userright_user") AndAlso Not dr.IsNull(aliasPrefix & "userright_user") Then
                        .m_user = New User(CInt(dr(aliasPrefix & "userright_user")))
                    End If
                End If
            End With
        End Sub
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Property Right() As Right            Get                Return m_right            End Get            Set(ByVal Value As Right)                m_right = Value            End Set        End Property
        Public Property User() As User            Get                Return m_user            End Get            Set(ByVal Value As User)                m_user = Value            End Set        End Property        Public Property Level() As Integer            Get                Return m_level            End Get            Set(ByVal Value As Integer)                m_level = Value            End Set        End Property
#End Region

#Region "Methods"
        Function ToBinary(ByVal Num As Decimal) As String
            Do
                ToBinary = CStr(IIf(Num / 2 <> Int(Num / 2), 1, 0)) & ToBinary
                Num = Int(Num / 2)
            Loop Until Num = 0
        End Function
        Function ToBinary(ByVal Num As Decimal, ByVal digit As Integer) As String
            For i As Integer = 0 To digit - 1
                ToBinary = CStr(IIf(Num / 2 <> Int(Num / 2), 1, 0)) & ToBinary
                Num = Int(Num / 2)
            Next
        End Function
        Function BinToDec(ByVal value As String) As Integer
            Return Convert.ToInt32(value, 2)
        End Function
        Function BoolToIntString(ByVal value As Boolean) As String
            If value Then
                Return "1"
            End If
            Return "0"
        End Function
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            If Not Me.User Is Nothing Then
                row("userright_user") = Me.User.Id
                row("Code") = Me.User.Code
                row("Name") = Me.User.Name

                row("level0") = False
                row("level1") = False
                row("level2") = False
                row("level3") = False
                Dim rightString As String = ToBinary(Me.Level, 4)
                row("level3") = CBool(rightString.Substring(0, 1))
                row("level2") = CBool(rightString.Substring(1, 1))
                row("level1") = CBool(rightString.Substring(2, 1))
                row("level0") = CBool(rightString.Substring(3, 1))
            End If
        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Try
                If Not row.IsNull(("userright_user")) Then
                    Me.User = New User(CInt(row("userright_user")))
                End If
                Me.Level = Me.BinToDec(BoolToIntString(cbool(row("level3"))) _
                                    & BoolToIntString(cbool(row("level2"))) _
                                    & BoolToIntString(cbool(row("level1"))) _
                                    & BoolToIntString(cbool(row("level0"))))
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
   Public Class RightUserCollection
        Inherits CollectionBase

#Region "Members"
        Private m_right As Right
        Private m_user As User

        Private m_table As TreeTable
        Private m_manager As TreeManager
#End Region

#Region "Constructors"
        Public Sub New(ByVal owner As Right, ByVal ds As DataSet, ByVal aliasPrefix As String)
            Me.m_right = owner
            If Not Me.m_right.Valid Then
                Return
            End If
            Me.m_table = Me.m_right.UserTable
            For Each dr As DataRow In ds.Tables(1).Rows
                Dim item As New RightUser(dr, aliasPrefix)
                item.Right = owner
                Me.Add(item)
            Next
        End Sub
        Public Sub New(ByVal owner As Right, ByVal rows As DataRowCollection)
            Me.m_right = owner
            Me.m_table = Me.m_right.UserTable
            For Each row As TreeRow In rows
                If row.Level = CType(row.Table, TreeTable).MaxLevel Then
                    Dim item As New RightUser(row, "")
                    item.Right = owner
                    Me.Add(item)
                End If
            Next
        End Sub
        Public Sub New(ByVal owner As Right)
            Me.m_right = owner
            If Not Me.m_right.Valid Then
                Return
            End If
            Me.m_table = Me.m_right.UserTable

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetRightUsers" _
            , New SqlParameter("@userright_right", Me.m_right.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New RightUser(row, "")
                item.Right = m_right
                Me.Add(item)
            Next
        End Sub
#End Region

#Region "Properties"
        Public Property Manager() As TreeManager            Get                Return m_manager            End Get            Set(ByVal Value As TreeManager)                m_manager = Value            End Set        End Property        Default Public Property Item(ByVal index As Integer) As RightUser
            Get
                Return CType(MyBase.List.Item(index), RightUser)
            End Get
            Set(ByVal value As RightUser)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overridable Function Save() As SaveErrorException
            Debug.WriteLine("Implement Me!!! ColumnCollection.Save")
        End Function
        Public Overridable Function Save(ByVal currentUserId As Integer) As SaveErrorException

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            conn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter("Select * from userright where userright_right=" & Me.m_right.Id, conn)
            da.Fill(ds, "RightUsers")
            Dim cmdBuilder As New SqlCommandBuilder(da)
            With ds.Tables("RightUsers")
                For Each row As DataRow In .Rows
                    row.Delete()
                Next
                For Each item As RightUser In Me
                    Dim dr As DataRow = .NewRow
                    dr("userright_right") = Me.m_right.Id
                    dr("userright_user") = item.User.Id
                    dr("userright_level") = item.Level
                    .Rows.Add(dr)
                Next
            End With
            Dim dt As DataTable = ds.Tables("RightUsers")
            ' First process deletes.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        End Function
#End Region

#Region "Methods"
        Public Function Add(ByVal value As RightUser) As Integer
            If Me.m_right Is Nothing OrElse Not Me.m_right.ManualAdding Then
                Dim myRow As TreeRow = Me.m_table.Childs.Add
                value.CopyToDataRow(myRow)
            End If
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As RightUserCollection)
            For i As Integer = 0 To value.Count - 1
                Dim myRow As TreeRow = Me.m_table.Childs.Add
                value(i).CopyToDataRow(myRow)
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As RightUser())
            For i As Integer = 0 To value.Length - 1
                Dim myRow As TreeRow = Me.m_table.Childs.Add
                value(i).CopyToDataRow(myRow)
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As RightUser) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As RightUser(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As RightUserEnumerator
            Return New RightUserEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As RightUser) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As RightUser)
            If Not Me.m_right Is Nothing Then
                Me.m_right.UserInitialized = False
            End If
            Dim myRow As TreeRow
            If Not Me.m_manager Is Nothing Then
                myRow = Me.m_manager.InsertBlankFriendOfSelectedRow()
            End If
            value.CopyToDataRow(myRow)
            Me.m_manager.SelectedRow = myRow
            'Hack อีกแล้ว (ถ้าไม่ AcceptChanges มันจะแสดงผลเพี้ยนๆบน Grid)
            Me.m_manager.Treetable.AcceptChanges()
            MyBase.List.Insert(index, value)
            If Not Me.m_right Is Nothing Then
                Me.m_right.UserInitialized = True
            End If
        End Sub
        Public Sub Remove(ByVal value As RightUser)
            Me.m_table.Childs.RemoveAt(Me.IndexOf(value))
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal index As Integer)
            Me.m_table.Childs.Remove(Me.m_table.Childs(index))
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class RightUserEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As RightUserCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, RightUser)
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