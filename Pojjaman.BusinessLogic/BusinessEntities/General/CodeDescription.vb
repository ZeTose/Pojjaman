Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class CodeDescription
#Region "Members"
    Private code_value As Integer
    Private code_description As String
    Private m_locked As Boolean

    Private Shared m_codeDescHash As Hashtable
#End Region

#Region "Constructors"
    Shared Sub New()
      RefreshCodeList()
    End Sub
    Public Sub New()

    End Sub
    Public Sub New(ByVal value As Integer)
      Me.code_value = value
      Me.code_description = CodeDescription.GetDescription(Me.CodeName, Me.Value)
    End Sub

    Public Sub New(ByVal description As String)
      Me.Description = description
      Me.Value = CodeDescription.GetValue(Me.CodeName, Me.Description)
    End Sub

    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If Not dr.IsNull(aliasPrefix & "code_value") Then
          .code_value = CInt(dr(aliasPrefix & "code_value"))
          .code_description = CodeDescription.GetDescription(Me.CodeName, Me.Value)
        End If
      End With
    End Sub
    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      Me.New(ds.Tables(0).Rows(0), aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property Locked() As Boolean
      Get
        Return m_locked
      End Get
      Set(ByVal Value As Boolean)
        m_locked = Value
      End Set
    End Property
    Public Property Value() As Integer
      Get
        Return code_value
      End Get
      Set(ByVal Value As Integer)
        code_value = Value
        code_description = CodeDescription.GetDescription(Me.CodeName, Me.code_value)
      End Set
    End Property
    Public Property Description() As String
      Get
        Dim service As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Return service.Parse(code_description)
      End Get
      Set(ByVal Value As String)
        code_description = Value
      End Set
    End Property
    Public Overridable ReadOnly Property CodeName() As String
      Get
        Return ""
      End Get
    End Property
#End Region

#Region "Methods"
    Public Shared Sub ComboSelect(ByVal cmb As ComboBox, ByVal codeDes As CodeDescription)
      For Each item As IdValuePair In cmb.Items
        If codeDes.Value = item.Id Then
          cmb.SelectedItem = item
          Return
        End If
      Next
      cmb.SelectedIndex = -1
    End Sub
    Public Shared Sub ListCodeDescriptionInComboBox(ByVal cmb As ComboBox, ByVal code As String, Optional ByVal includeNothing As Boolean = False, Optional ByVal excludeCancel As Boolean = False)
      Dim dt As DataTable = GetCodeList(code)
      cmb.Items.Clear()
      Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      For Each row As DataRow In dt.Rows
        If Not (excludeCancel AndAlso CInt(row("code_value")) = 0) Then
          Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
          cmb.Items.Add(item)
        End If
      Next
      If includeNothing Then
        cmb.Items.Insert(0, New IdValuePair(-1, myService.Parse("${res:Global.Unspecified}")))
      End If
    End Sub
    Public Shared Sub ListCodeDescriptionInComboBox(ByVal cmb As ComboBox, ByVal code As String, ByVal filter As String, Optional ByVal includeNothing As Boolean = False, Optional ByVal excludeCancel As Boolean = False)
      Dim dt As DataTable = GetCodeList(code, filter)
      cmb.Items.Clear()
      Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      For Each row As DataRow In dt.Rows
        If Not (excludeCancel AndAlso CInt(row("code_value")) = 0) Then
          Dim item As New IdValuePair(CInt(row("code_value")), myService.Parse(CStr(row("code_description"))))
          cmb.Items.Add(item)
        End If
      Next
      If includeNothing Then
        cmb.Items.Insert(0, New IdValuePair(-1, myService.Parse("${res:Global.Unspecified}")))
      End If
    End Sub
    Public Shared Function GetValue(ByVal code As String, ByVal description As String) As Integer
      If code.Length <> 0 Then
        Dim newHash As New Hashtable
        For Each key As String In m_codeDescHash.Keys
          If key.ToLower.StartsWith(code.ToLower & "|") Then
            newHash(key) = m_codeDescHash(key)
          End If
        Next
        For Each row As DataRow In newHash.Values
          If CStr(row("code_description")).ToLower = description.ToLower Then
            Return CInt(row("code_value"))
          End If
        Next
      End If
    End Function
    Public Shared Function GetTag(ByVal code As String, ByVal value As Integer) As Integer
      If code.Length <> 0 Then
        Dim row As DataRow = CType(m_codeDescHash(code.ToLower & "|" & value.ToString.ToLower), DataRow)
        If Not row Is Nothing Then
          Return CInt(row("code_tag"))
        End If
      End If
    End Function
    Public Shared Function GetDescription(ByVal code As String, ByVal value As Integer) As String
      If code.Length <> 0 Then
        Dim row As DataRow = CType(m_codeDescHash(code.ToLower & "|" & value.ToString.ToLower), DataRow)
        If Not row Is Nothing Then
          Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
          Return myService.Parse(row("code_description").ToString)
        End If
      End If
    End Function
    Public Shared Function GetCodeList(ByVal code As String, ByVal filter As String) As DataTable
      If code.Length <> 0 Then
        Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim tmpdt As New DataTable
        tmpdt.Columns.Add(New DataColumn("code_value"))
        tmpdt.Columns.Add(New DataColumn("code_description"))
        tmpdt.Columns.Add(New DataColumn("code_order"))
        Dim newHash As New Hashtable
        For Each key As String In m_codeDescHash.Keys
          If key.ToLower.StartsWith(code.ToLower & "|") Then
            newHash(key) = m_codeDescHash(key)
          End If
        Next
        For Each row As DataRow In newHash.Values
          tmpdt.ImportRow(row)
        Next
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("code_value"))
        dt.Columns.Add(New DataColumn("code_description"))
        dt.Columns.Add(New DataColumn("code_order"))
        For Each row As DataRow In tmpdt.Select(filter, "code_order")
          If Not row.IsNull("code_description") Then
            row("code_description") = myService.Parse(row("code_description").ToString)
          End If
          dt.ImportRow(row)
        Next
        tmpdt = Nothing
        newHash = Nothing
        Return dt
      End If
    End Function
    Public Shared Function GetCodeListOf(ByVal code As String, ByVal filter As String) As List(Of CodeDescription)
      If code.Length <> 0 Then
        Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim tmpdt As New DataTable
        tmpdt.Columns.Add(New DataColumn("code_value"))
        tmpdt.Columns.Add(New DataColumn("code_description"))
        tmpdt.Columns.Add(New DataColumn("code_order"))
        Dim newHash As New Hashtable
        For Each key As String In m_codeDescHash.Keys
          If key.ToLower.StartsWith(code.ToLower & "|") Then
            newHash(key) = m_codeDescHash(key)
          End If
        Next
        For Each row As DataRow In newHash.Values
          tmpdt.ImportRow(row)
        Next
        Dim dt As New List(Of CodeDescription)
       
        For Each row As DataRow In tmpdt.Select(filter, "code_order")
          If Not row.IsNull("code_description") Then
            row("code_description") = myService.Parse(row("code_description").ToString)
          End If
          dt.Add(New CodeDescription(row, ""))
        Next
        tmpdt = Nothing
        newHash = Nothing
        Return dt
      End If
    End Function
    Public Shared Function GetCodeList(ByVal code As String) As DataTable
      If code.Length <> 0 Then
        Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("code_value"))
        dt.Columns.Add(New DataColumn("code_description"))
        dt.Columns.Add(New DataColumn("code_order"))
        dt.Columns.Add(New DataColumn("code_tag"))

        Dim newHash As New Hashtable
        For Each key As String In m_codeDescHash.Keys
          If key.ToLower.StartsWith(code.ToLower & "|") Then
            newHash(key) = m_codeDescHash(key)
          End If
        Next
        Dim tmpDt As DataTable = dt.Clone
        For Each row As DataRow In newHash.Values
          tmpDt.ImportRow(row)
        Next
        For Each row As DataRow In tmpDt.Select("", "code_order")
          If Not row.IsNull("code_description") Then
            row("code_description") = myService.Parse(row("code_description").ToString)
          End If
          dt.ImportRow(row)
        Next
        newHash = Nothing
        Return dt
      End If
    End Function

    Public Shared Sub RefreshCodeList()
      Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select code_value,code_description,code_name,code_order,code_tag from codedescription order by code_name,code_order")
      Dim myTable As DataTable = ds.Tables(0)
      m_codeDescHash = New Hashtable
      For Each row As DataRow In myTable.Rows
        m_codeDescHash(row("code_name").ToString.ToLower & "|" & myService.Parse(row("code_value").ToString).ToLower) = row
      Next
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Function ToString() As String
      Return Me.Value & ":" & Me.Description
    End Function
#End Region

  End Class

End Namespace
