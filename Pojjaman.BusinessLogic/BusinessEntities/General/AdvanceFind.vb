Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Reflection
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class AdvanceFindField

#Region "Members"
        Private advfind_code As String
        Private advfind_description As String
        Private advfind_dataType As String
        Private m_locked As Boolean

        Private Shared m_advFindHash As Hashtable
#End Region

#Region "Constructors"
        Shared Sub New()
            RefreshCodeList()
        End Sub
        Public Sub New()

        End Sub
        'Public Sub New(ByVal value As Integer)
        '    Me.code_value = value
        '    Me.code_description = AdvanceFind.GetDescription(Me.CodeName, Me.Value)
        'End Sub

        'Public Sub New(ByVal description As String)
        '    Me.Description = description
        '    Me.Value = AdvanceFind.GetValue(Me.CodeName, Me.Description)
        'End Sub

        'Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
        '    With Me
        '        If Not dr.IsNull(aliasPrefix & "code_value") Then
        '            .code_value = CInt(dr(aliasPrefix & "code_value"))        '            .code_description = AdvanceFind.GetDescription(Me.CodeName, Me.Value)        '        End If
        '    End With
        'End Sub
        'Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
        '    Me.New(ds.Tables(0).Rows(0), aliasPrefix)
        'End Sub
#End Region

#Region "Properties"
        Public Property Code() As String            Get                Return advfind_code            End Get            Set(ByVal Value As String)                advfind_code = Value                advfind_description = AdvanceFindField.GetDescription(Me.CodeName, Me.advfind_code)            End Set        End Property        Public Property Description() As String            Get                Dim service As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)                Return service.Parse(advfind_description)            End Get            Set(ByVal Value As String)                advfind_description = Value            End Set        End Property
        Public Property DataType() As String            Get                Return advfind_dataType            End Get            Set(ByVal Value As String)                advfind_dataType = Value            End Set        End Property
        Public Overridable ReadOnly Property CodeName() As String
            Get
                Return ""
            End Get
        End Property
#End Region

#Region "Methods"
        'Public Shared Sub ComboSelect(ByVal cmb As ComboBox, ByVal advsDes As AdvanceFind)
        '    For Each item As IdValuePair In cmb.Items
        '        If advsDes.Code = item.Id Then
        '            cmb.SelectedItem = item
        '            Return
        '        End If
        '    Next
        '    cmb.SelectedIndex = -1
        'End Sub
        'Public Shared Sub ListAdvanceFindInComboBox(ByVal cmb As ComboBox, ByVal code As String, Optional ByVal includeNothing As Boolean = False)
        '    Dim dt As DataTable = GetCodeList(code)
        '    cmb.Items.Clear()
        '    For Each row As DataRow In dt.Rows
        '        Dim item As New IdValuePair(CInt(row("code_value")), CStr(row("code_description")))
        '        cmb.Items.Add(item)
        '    Next
        '    If includeNothing Then
        '        Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        '        cmb.Items.Insert(0, New IdValuePair(-1, myService.Parse("${res:Global.Unspecified}")))
        '    End If
        'End Sub
        'Public Shared Sub ListAdvanceFindInComboBox(ByVal cmb As ComboBox, ByVal code As String, ByVal filter As String, Optional ByVal includeNothing As Boolean = False)
        '    Dim dt As DataTable = GetCodeList(code, filter)
        '    cmb.Items.Clear()
        '    For Each row As DataRow In dt.Rows
        '        Dim item As New IdValuePair(CInt(row("code_value")), CStr(row("code_description")))
        '        cmb.Items.Add(item)
        '    Next
        '    If includeNothing Then
        '        Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        '        cmb.Items.Insert(0, New IdValuePair(-1, myService.Parse("${res:Global.Unspecified}")))
        '    End If
        'End Sub
        'Public Shared Function GetValue(ByVal code As String, ByVal description As String) As Integer
        '    If code.Length <> 0 Then
        '        Dim newHash As New Hashtable
        '        For Each key As String In m_codeDescHash.Keys
        '            If key.ToLower.StartsWith(code.ToLower & "|") Then
        '                newHash(key) = m_codeDescHash(key)
        '            End If
        '        Next
        '        For Each row As DataRow In newHash.Values
        '            If CStr(row("code_description")).ToLower = description.ToLower Then
        '                Return CInt(row("code_value"))
        '            End If
        '        Next
        '    End If
        'End Function
        'Public Shared Function GetTag(ByVal code As String, ByVal value As Integer) As Integer
        '    If code.Length <> 0 Then
        '        Dim row As DataRow = CType(m_codeDescHash(code.ToLower & "|" & value.ToString.ToLower), DataRow)
        '        If Not row Is Nothing Then
        '            Return CInt(row("code_tag"))
        '        End If
        '    End If
        'End Function
        Public Shared Function GetDescription(ByVal group As String, ByVal code As String) As String
            If code.Length <> 0 Then
                Dim row As DataRow = CType(m_advFindHash(group.ToLower & "|" & code.ToLower), DataRow)
                If Not row Is Nothing Then
                    Return row("advfind_description").ToString
                End If
            End If
        End Function
        Public Shared Function GetDataType(ByVal group As String, ByVal code As String) As String
            If code.Length <> 0 Then
                Dim row As DataRow = CType(m_advFindHash(group.ToLower & "|" & code.ToLower), DataRow)
                If Not row Is Nothing Then
                    Return row("advfind_dataType").ToString
                End If
            End If
        End Function
        'Public Shared Function GetCodeList(ByVal code As String, ByVal filter As String) As DataTable
        '    If code.Length <> 0 Then
        '        Dim tmpdt As New DataTable
        '        tmpdt.Columns.Add(New DataColumn("code_value"))
        '        tmpdt.Columns.Add(New DataColumn("code_description"))
        '        tmpdt.Columns.Add(New DataColumn("code_order"))
        '        Dim newHash As New Hashtable
        '        For Each key As String In m_codeDescHash.Keys
        '            If key.ToLower.StartsWith(code.ToLower & "|") Then
        '                newHash(key) = m_codeDescHash(key)
        '            End If
        '        Next
        '        For Each row As DataRow In newHash.Values
        '            tmpdt.ImportRow(row)
        '        Next
        '        Dim dt As New DataTable
        '        dt.Columns.Add(New DataColumn("code_value"))
        '        dt.Columns.Add(New DataColumn("code_description"))
        '        dt.Columns.Add(New DataColumn("code_order"))
        '        For Each row As DataRow In tmpdt.Select(filter)
        '            dt.ImportRow(row)
        '        Next
        '        tmpdt = Nothing
        '        newHash = Nothing
        '        Return dt
        '    End If
        'End Function
        Public Shared Function GetFieldList(ByVal group As String) As DataTable
            If group.Length <> 0 Then
                Dim dt As New DataTable
                dt.Columns.Add(New DataColumn("advfind_code"))
                dt.Columns.Add(New DataColumn("advfind_description"))
                dt.Columns.Add(New DataColumn("advfind_dataType"))
                dt.Columns.Add(New DataColumn("advfind_order"))

                Dim newHash As New Hashtable
                For Each key As String In m_advFindHash.Keys
                    If key.ToLower.StartsWith(group.ToLower & "|") Then
                        newHash(key) = m_advFindHash(key)
                    End If
                Next
                Dim tmpDt As DataTable = dt.Clone
                For Each row As DataRow In newHash.Values
                    tmpDt.ImportRow(row)
                Next
                For Each row As DataRow In tmpDt.Select("", "advfind_order")
                    dt.ImportRow(row)
                Next
                newHash = Nothing
                Return dt
            End If
        End Function

        Public Shared Sub RefreshCodeList()
            Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select advfind_group,advfind_code,advfind_description,advfind_datatype,advfind_order from AdvanceFind order by advfind_group,advfind_order")
            Dim myTable As DataTable = ds.Tables(0)
            m_advFindHash = New Hashtable
            For Each row As DataRow In myTable.Rows
                m_advFindHash(row("advfind_group").ToString.ToLower & "|" & row("advfind_code").ToString.ToLower) = row
            Next
        End Sub
#End Region

#Region "Overrides"
        'Public Overrides Function ToString() As String
        '    Return Me.Value & ":" & Me.Description
        'End Function
#End Region

    End Class


    Public Interface iAdvanceFind
        Property AdvanceFindCollection() As AdvanceFindCollection
    End Interface


    <Serializable(), DefaultMember("Item")> _
    Public Class AdvanceFindCollection
        Inherits CollectionBase

#Region "Members"
        Dim m_sqlstring As String
#End Region

#Region "Constructors"
        Public Sub New()

        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As AdvanceFind
            Get
                Return CType(MyBase.List.Item(index), AdvanceFind)
            End Get
            Set(ByVal value As AdvanceFind)
                MyBase.List.Item(index) = value
            End Set
        End Property
        Public Property SQLString() As String
            Get
                Return m_sqlstring
            End Get
            Set(ByVal Value As String)
                m_sqlstring = Value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Function GetItem(ByVal Level As Integer) As AdvanceFind
            Dim ret As AdvanceFind
            For Each temp As AdvanceFind In Me.List
                If Level = temp.Level Then
                    ret = temp
                End If
            Next
            If ret Is Nothing Then
                ret = New AdvanceFind
                ret.Level = Level
                ret.OperatorAnd = True
                Me.Add(ret)
            End If
            Return ret
        End Function
        Public Function GetBuiltSQLString() As String
            Dim ret As String
            Dim ret1 As String
            Dim advanceFindString(0) As String
            Dim tempFindString(0) As String
            Dim i As Integer = 0
            Dim j As Integer = 0

            For Each myAdvf As AdvanceFind In Me
                If myAdvf.ItemCollection.Count > 0 Then

                    j = 0
                    For Each myAdvfItem As AdvanceFindItem In myAdvf.ItemCollection
                        If Not myAdvfItem.Field.StartsWith("lci") Then

                            ' ถ้ามี MinValue
                            If Not myAdvfItem.MinValue Is Nothing AndAlso myAdvfItem.MinValue.Length > 0 Then
                                ReDim Preserve tempFindString(j)
                                ''' ตรวจสอบค่าที่ใส่ ถ้ามีทั้งคู่ ให้เป็น between ถ้ามีตัวเดียวให้ดู datatype แล้วกำหนดเป็น = หรือ like

                                If Not myAdvfItem.MaxValue Is Nothing AndAlso myAdvfItem.MaxValue.Length > 0 Then
                                    Dim hasSingleQuot As String = ""
                                    Dim wildCard As String = "%"
                                    If (myAdvfItem.DataType.ToLower.StartsWith("system.string") OrElse myAdvfItem.DataType.ToLower = "system.string") Then
                                        hasSingleQuot = "'"
                                    End If

                                    tempFindString(j) = myAdvfItem.Field
                                    tempFindString(j) &= CStr(IIf(hasSingleQuot.Length = 0, " >= ", " like "))
                                    tempFindString(j) &= hasSingleQuot & myAdvfItem.MinValue & CStr(IIf(hasSingleQuot.Length = 0, "", wildCard)) & hasSingleQuot
                                    tempFindString(j) &= " and " & myAdvfItem.Field
                                    tempFindString(j) &= CStr(IIf(hasSingleQuot.Length = 0, " <= ", " like "))
                                    tempFindString(j) &= hasSingleQuot & myAdvfItem.MaxValue & CStr(IIf(hasSingleQuot.Length = 0, "", wildCard)) & hasSingleQuot
                                End If
                            End If

                            If Not tempFindString(j) Is Nothing AndAlso tempFindString(j).Length > 0 Then
                                j += 1
                            Else
                                ReDim Preserve tempFindString(j - 1)
                            End If

                        End If
                    Next

                    ReDim Preserve advanceFindString(i)
                    advanceFindString(i) = Join(tempFindString, CStr(IIf(myAdvf.OperatorAnd, " and ", " or ")))
                    If Not advanceFindString(i) Is Nothing AndAlso advanceFindString(i).Length > 0 Then
                        advanceFindString(i) = "(" & advanceFindString(i) & ")"
                        i += 1
                    Else
                        ReDim Preserve advanceFindString(i - 1)
                    End If
                    tempFindString = Nothing

                End If
            Next

            ret = CStr(IIf(advanceFindString.Length > 0, Join(advanceFindString, " and "), ""))
            Return CStr(IIf(ret.Length > 0, " where " & ret, ""))
            'Return ret & ""
        End Function

        Public Function GetBuiltSQLString1() As String
            Dim ret As String
            Dim ret1 As String
            Dim advanceFindString(0) As String
            Dim tempFindString(0) As String
            Dim i As Integer = 0
            Dim j As Integer = 0

            For Each myAdvf As AdvanceFind In Me
                If myAdvf.ItemCollection.Count > 0 Then

                    j = 0
                    For Each myAdvfItem As AdvanceFindItem In myAdvf.ItemCollection
                        If myAdvfItem.Field.StartsWith("lci") Then

                            ' ถ้ามี MinValue
                            If Not myAdvfItem.MinValue Is Nothing AndAlso myAdvfItem.MinValue.Length > 0 Then
                                ReDim Preserve tempFindString(j)
                                ''' ตรวจสอบค่าที่ใส่ ถ้ามีทั้งคู่ ให้เป็น between ถ้ามีตัวเดียวให้ดู datatype แล้วกำหนดเป็น = หรือ like

                                If Not myAdvfItem.MaxValue Is Nothing AndAlso myAdvfItem.MaxValue.Length > 0 Then
                                    Dim hasSingleQuot As String = ""
                                    Dim wildCard As String = "%"
                                    If (myAdvfItem.DataType.ToLower.StartsWith("system.string") OrElse myAdvfItem.DataType.ToLower = "system.string") Then
                                        hasSingleQuot = "'"
                                    End If

                                    tempFindString(j) = myAdvfItem.Field
                                    tempFindString(j) &= CStr(IIf(hasSingleQuot.Length = 0, " >= ", " like "))
                                    tempFindString(j) &= hasSingleQuot & myAdvfItem.MinValue & CStr(IIf(hasSingleQuot.Length = 0, "", wildCard)) & hasSingleQuot
                                    tempFindString(j) &= " and " & myAdvfItem.Field
                                    tempFindString(j) &= CStr(IIf(hasSingleQuot.Length = 0, " <= ", " like "))
                                    tempFindString(j) &= hasSingleQuot & myAdvfItem.MaxValue & CStr(IIf(hasSingleQuot.Length = 0, "", wildCard)) & hasSingleQuot
                                End If
                            End If

                            If Not tempFindString(j) Is Nothing AndAlso tempFindString(j).Length > 0 Then
                                j += 1
                            Else
                                ReDim Preserve tempFindString(j - 1)
                            End If

                        End If
                    Next

                    ReDim Preserve advanceFindString(i)
                    advanceFindString(i) = Join(tempFindString, CStr(IIf(myAdvf.OperatorAnd, " and ", " or ")))
                    If Not advanceFindString(i) Is Nothing AndAlso advanceFindString(i).Length > 0 Then
                        advanceFindString(i) = "(" & advanceFindString(i) & ")"
                        i += 1
                    Else
                        ReDim Preserve advanceFindString(i - 1)
                    End If
                    tempFindString = Nothing

                End If
            Next

            ret = CStr(IIf(advanceFindString.Length > 0, Join(advanceFindString, " and "), ""))
            Return CStr(IIf(ret.Length > 0, " where " & ret, ""))
            'Return CStr(IIf(ret.Length > 0, " and " & ret, "")) & ""
        End Function
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As AdvanceFind) As Integer
            If Not Me.Contains(value) Then
                Return MyBase.List.Add(value)
            End If
        End Function
        Public Sub AddRange(ByVal value As AdvanceFindCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As AdvanceFind())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As AdvanceFind) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As AdvanceFind(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Function IndexOf(ByVal value As AdvanceFind) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As AdvanceFind)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As AdvanceFind)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As AdvanceFindCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region

    End Class


    Public Class AdvanceFind
#Region "Members"
        Private m_level As Integer
        Private m_operatorAnd As Boolean
        Private m_itemColl As AdvanceFindItemCollection
#End Region

#Region "Constructors"
        Public Sub New()
            m_itemColl = New AdvanceFindItemCollection
        End Sub
        'Public Sub New(ByVal value As Integer)
        '    Me.code_value = value
        '    Me.code_description = AdvanceFind.GetDescription(Me.CodeName, Me.Value)
        'End Sub

        'Public Sub New(ByVal description As String)
        '    Me.Description = description
        '    Me.Value = AdvanceFind.GetValue(Me.CodeName, Me.Description)
        'End Sub

        'Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
        '    With Me
        '        If Not dr.IsNull(aliasPrefix & "code_value") Then
        '            .code_value = CInt(dr(aliasPrefix & "code_value"))        '            .code_description = AdvanceFind.GetDescription(Me.CodeName, Me.Value)        '        End If
        '    End With
        'End Sub
        'Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
        '    Me.New(ds.Tables(0).Rows(0), aliasPrefix)
        'End Sub
#End Region

#Region "Properties"
        Public Property Level() As Integer            Get                Return m_level            End Get            Set(ByVal Value As Integer)                m_level = Value            End Set        End Property        Public Property OperatorAnd() As Boolean            Get                Return m_operatorAnd            End Get            Set(ByVal Value As Boolean)                m_operatorAnd = Value            End Set        End Property        Public Property ItemCollection() As AdvanceFindItemCollection            Get                Return m_itemColl            End Get            Set(ByVal Value As AdvanceFindItemCollection)                m_itemColl = Value            End Set        End Property#End Region

    End Class


    <Serializable(), DefaultMember("Item")> _
    Public Class AdvanceFindItemCollection
        Inherits CollectionBase
#Region "Members"

#End Region

#Region "Constructors"
        Public Sub New()

        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As AdvanceFindItem
            Get
                Return CType(MyBase.List.Item(index), AdvanceFindItem)
            End Get
            Set(ByVal value As AdvanceFindItem)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"

#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As AdvanceFindItem) As Integer
            If Not Me.Contains(value) Then
                Return MyBase.List.Add(value)
            End If
        End Function
        Public Sub AddRange(ByVal value As AdvanceFindItemCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As AdvanceFindItem())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As AdvanceFindItem) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As AdvanceFindItem(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Function IndexOf(ByVal value As AdvanceFindItem) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As AdvanceFindItem)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As AdvanceFindItem)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As AdvanceFindItemCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region

    End Class


    Public Class AdvanceFindItem

#Region "Members"
        Private m_field As String
        Private m_dataType As String
        Private m_minVal As String
        Private m_maxVal As String
#End Region

#Region "Constructors"
        Public Sub New()

        End Sub
#End Region

#Region "Properties"
        Public Property Field() As String            Get                Return m_field            End Get            Set(ByVal Value As String)                m_field = Value            End Set        End Property        Public Property DataType() As String            Get                Return m_dataType            End Get            Set(ByVal Value As String)                m_dataType = Value            End Set        End Property        Public Property MinValue() As String            Get                Return m_minVal            End Get            Set(ByVal Value As String)                m_minVal = Value            End Set        End Property        Public Property MaxValue() As String            Get                Return m_maxVal            End Get            Set(ByVal Value As String)                m_maxVal = Value            End Set        End Property#End Region

    End Class

End Namespace
