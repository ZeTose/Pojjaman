Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class ReSaveGL
    Inherits SimpleBusinessEntityBase

#Region "Member"
    Private ArrEntity As New ArrayList
    Private m_datestart As Date
    Private m_dateend As Date

#End Region
    Public Property DocList As String
    Public Property DateStart As Date
      Get
        Return m_datestart
      End Get
      Set(ByVal value As Date)
        m_datestart = value
      End Set
    End Property
    Public Property DateEnd As Date
      Get
        Return m_dateend
      End Get
      Set(ByVal value As Date)
        m_dateend = value
      End Set
    End Property
    Public Property OnlyDontHaveAtom As Boolean

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "ReSaveGL"
      End Get
    End Property
    Public Overrides ReadOnly Property FullClassName As String
      Get
        Return "Longkong.Pojjaman.BusinessLogic.ReSaveGL"
      End Get
    End Property
    Public Sub New()
      'Me.Load()
    End Sub
    Public ReadOnly Property ConnectionString() As String
      Get
        Return RecentCompanies.CurrentCompany.ConnectionString
      End Get
    End Property
    Public Sub Load()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
                , "GetForResaveGLDetailMiss" _
                , New SqlParameter("@DocDateStart", Me.DateStart) _
                , New SqlParameter("@DocDateEnd", Me.DateEnd) _
                )
      For Each dr As DataRow In ds.Tables(0).Rows
        ArrEntity.Add(dr)
      Next
    End Sub
    Public Sub save()
      Me.Load()
      Try
        Dim entityType As Integer
        Dim entityId As Integer
        Dim EditorId As Integer
        Dim count45 As Integer
        Dim count31 As Integer
        Dim count51 As Integer
        For Each item As DataRow In ArrEntity
          entityType = CInt(item("gl_refdoctype"))
          entityId = CInt(item("gl_refid"))
          EditorId = CInt(item("editor"))
          Select Case entityType
            Case 45
              Dim GR As New GoodsReceipt(entityId)
              GR.LastEditDate = Now
              GR.OnGlChanged()
              GR.Save(EditorId)
              count45 += 1
            Case 31
              Dim MW As New MatTransfer(entityId)
              MW.LastEditDate = Now
              MW.Save(EditorId)
              count31 += 1
            Case 51
              Dim MR As New MatReturn(entityId)
              MR.LastEditDate = Now
              MR.Save(EditorId)
              count51 += 1
            Case 83
              Dim GS As New GoodsSold(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 37
              Dim GS As New UpdateCheckPayment(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 59
              Dim GS As New AdvancePay(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 73
              Dim GS As New PaySelection(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 129
              Dim GS As New PettyCashClosed(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 248
              Dim GS As New AdvanceMoneyClosed(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)

          End Select
        Next
        MessageBox.Show("Save Succeed " & vbCrLf & _
                         count45.ToString & " " & count31.ToString & " " & count51.ToString)
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Sub

#Region "Gen GL Atom"
    Public Sub GenGLAtom()
      ArrEntity.Clear()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
                , "GetGLDocforGenAtom" _
                , New SqlParameter("@DocDateStart", Me.DateStart) _
                , New SqlParameter("@DocDateEnd", Me.DateEnd) _
                , New SqlParameter("@OnlyDonHaveAtom", Me.OnlyDontHaveAtom) _
                , New SqlParameter("@Doclist", Me.DocList) _
                )
      For Each dr As DataRow In ds.Tables(0).Rows
        ArrEntity.Add(dr)
      Next


      Dim entityType As Integer
      Dim entityId As Integer

      Dim counts As New Dictionary(Of String, Integer)
      For Each item As DataRow In ArrEntity

        entityType = CInt(item("gl_refdoctype"))
        entityId = CInt(item("gl_refid"))

        Try
          Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(entityType), entityId)
          Dim err As SaveErrorException
          If Not en Is Nothing AndAlso TypeOf en Is INewGLAble Then
            If counts.ContainsKey(entityType.ToString) Then
              counts.Item(entityType.ToString) += 1
            Else
              counts.Add(entityType.ToString, 1)
            End If
            err = CType(en, INewGLAble).OnlyGenGLAtom()
          End If
        Catch ex As Exception
          MessageBox.Show(ex.ToString)
        End Try

      Next

      Dim msg As New List(Of String)

      For Each kv As KeyValuePair(Of String, Integer) In counts
        msg.Add(kv.Key & ":" & kv.Value.ToString)
      Next

      MessageBox.Show("Gen GLAtom Succeed " & vbCrLf & String.Join(",", msg))
    End Sub
#End Region

#Region "Insert Gl Mapping "
    Public Sub UpdateGLMapping()
      ArrEntity.Clear()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
                , "GetGLDocforGenAtom" _
                , New SqlParameter("@DocDateStart", Me.DateStart) _
                , New SqlParameter("@DocDateEnd", Me.DateEnd) _
                , New SqlParameter("@OnlyDonHaveAtom", Me.OnlyDontHaveAtom) _
                , New SqlParameter("@Doclist", Me.DocList) _
                )
      For Each dr As DataRow In ds.Tables(0).Rows
        ArrEntity.Add(dr)
      Next


      Dim entityType As Integer
      Dim entityId As Integer

      Dim counts As New Dictionary(Of String, Integer)
      For Each item As DataRow In ArrEntity

        entityType = CInt(item("gl_refdoctype"))
        entityId = CInt(item("gl_refid"))


        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(entityType), entityId)
        Dim err As SaveErrorException
        If TypeOf en Is INewGLAble Then
          If counts.ContainsKey(entityType.ToString) Then
            counts.Item(entityType.ToString) += 1
          Else
            counts.Add(entityType.ToString, 1)
          End If
          CType(en, INewGLAble).JournalEntry.UpdateGLItemMapping()
        End If

      Next

      Dim msg As New List(Of String)

      For Each kv As KeyValuePair(Of String, Integer) In counts
        msg.Add(kv.Key & ":" & kv.Value.ToString)
      Next

      MessageBox.Show("Gen GLAtom Succeed " & vbCrLf & String.Join(",", msg))
    End Sub
#End Region

    Shared Function GetEntityTableForGLDoc() As DataTable
      Return Entity.GetEntityTableForGLDoc
    End Function
  End Class

End Namespace

