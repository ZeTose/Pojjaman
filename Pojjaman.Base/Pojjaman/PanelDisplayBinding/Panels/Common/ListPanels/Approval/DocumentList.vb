Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic
Imports Longkong.Core.Services
Imports Longkong.Pojjaman

Public Class DocumentList
  Public ParentForm As DocumentApprovalForm
  Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    lvItem.BeginUpdate()
    lvItem.Items.Clear()
    Try
      Dim secServ As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), Services.SecurityService)
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetWaitingActionLogs" _
      , New Data.SqlClient.SqlParameter("@UserId", secServ.CurrentUser.Id) _
      )
      For Each row As DataRow In ds.Tables(0).Rows
        Dim myType As String = ""
        Dim myProject As String = ""
        Dim myDocCode As String = ""
        Dim myAction As String = ""
        Dim myDate As Date = Now.Date
        If Not row.IsNull("Type") Then
          myType = CStr(row("Type"))
        End If
        If Not row.IsNull("Project") Then
          myProject = CStr(row("Project"))
        End If
        If Not row.IsNull("DocumentCode") Then
          myDocCode = CStr(row("DocumentCode"))
        End If
        If Not row.IsNull("Action") Then
          myAction = CStr(row("Action"))
        End If
        If Not row.IsNull("DocumentDate") Then
          myDate = CDate(row("DocumentDate"))
        End If
        Dim litem As ListViewItem = Me.lvItem.Items.Add(myDocCode)
        litem.ImageIndex = 0
        Dim myId As Integer
        If Not row.IsNull("DocumentId") Then
          myId = CInt(row("DocumentId"))
        End If
        Dim myTypeId As Integer
        If Not row.IsNull("DocumentType") Then
          myTypeId = CInt(row("DocumentType"))
        End If
        litem.Tag = New KeyValuePair(Of Integer, Integer)(myId, myTypeId)
      Next
    Catch ex As Exception

    End Try
    lvItem.EndUpdate()
    'Me.lblTodoCount.Text = "(" & lvItem.Items.Count.ToString & ")"
  End Sub
  Private m_entity As SimpleBusinessEntityBase
  Private Sub lvItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.SelectedIndexChanged
    m_entity = New PO(Me.lvItem.SelectedItems(0).Text)
    ParentForm.SetEntity(m_entity)
  End Sub
End Class
