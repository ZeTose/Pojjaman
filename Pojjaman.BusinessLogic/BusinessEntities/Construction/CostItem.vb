Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports System.Collections.Generic
Imports Longkong.Core.Services
Imports System.Text.RegularExpressions

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class CostItem

  End Class
  Public Class CostItemType
    Implements IDescripable
#Region "Members"
    Private entity_id As Integer
    Private entity_description As String
    Private entity_name As String

    Private Shared m_costTypeDic As Dictionary(Of String, CostItemType)
#End Region

#Region "Properties"
    Public Property ID As Integer Implements IDescripable.id
      Get
        Return entity_id
      End Get
      Set(ByVal value As Integer)
        entity_id = value
      End Set
    End Property
    Public Property Desc As String Implements IDescripable.desc
      Get
        Return entity_description
      End Get
      Set(ByVal value As String)
        entity_description = value
      End Set
    End Property
    Public Property Name As String Implements IDescripable.name
      Get
        Return entity_name
      End Get
      Set(ByVal value As String)
        entity_name = value
      End Set
    End Property
#End Region

#Region "Constructors"
    Shared Sub New()
      RefreshCodeList()
    End Sub
    Public Sub New()

    End Sub
    'Public Sub New(ByVal value As Integer)
    '  Me.code_value = value
    '  Me.code_description = CodeDescription.GetDescription(Me.CodeName, Me.Value)
    'End Sub

    'Public Sub New(ByVal description As String)
    '  Me.Description = description
    '  Me.Value = CodeDescription.GetValue(Me.CodeName, Me.Description)
    'End Sub

    Public Sub New(ByVal dr As DataRow)
      With Me
        If Not dr.IsNull("entity_id") Then
          Dim drh As New DataRowHelper(dr)
          .entity_id = drh.GetValue(Of Integer)("entity_id")
          .entity_description = drh.GetValue(Of String)("entity_description")
          .entity_name = drh.GetValue(Of String)("entity_name")
        End If
      End With
    End Sub
    'Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
    '  Me.New(ds.Tables(0).Rows(0), aliasPrefix)
    'End Sub
#End Region

#Region "Methods"
    Public Overrides Function ToString() As String
      Return Me.entity_description
    End Function
#End Region

#Region "Shared"
    ''' <summary>
    ''' ได้ List ของชนิดเอกสารที่มีต้นทุน
    ''' มีทั้ง id และ ชื่อ และ descrition
    ''' </summary>
    ''' <param name="filter">เลขที่เอกสารที่จะไม่ใช้</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCostDocList(ByVal filter As String) As List(Of IDescripable)
      Dim ret As New List(Of IDescripable)
      If filter.Length <> 0 Then
        filter = Replace(filter, ",", "||")
        filter = "|" & filter & "|"
        For Each kv As KeyValuePair(Of String, CostItemType) In m_costTypeDic
          If Not Regex.IsMatch(filter.ToLower, "\|" & kv.Key & "\|") Then
            ret.Add(kv.Value)
          End If
        Next
      Else
        For Each kv As KeyValuePair(Of String, CostItemType) In m_costTypeDic
          ret.Add(kv.Value)
        Next
      End If
      Return ret
    End Function
    Public Shared Sub RefreshCodeList()
      Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select entity_id,entity_name,entity_description from entity where entity_hasCost = 1")
      Dim myTable As DataTable = ds.Tables(0)
      m_costTypeDic = New Dictionary(Of String, CostItemType)
      For Each row As DataRow In myTable.Rows
        m_costTypeDic.Add(row("entity_id").ToString.ToLower, New CostItemType(row))
      Next
    End Sub
#End Region
  End Class
End Namespace

