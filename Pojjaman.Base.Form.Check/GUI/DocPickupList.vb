Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Reflection
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Public Class DocPickupList

  Dim m_entity As IAbleSelectDocPickup

  Public Sub New(ByVal entity As IAbleSelectDocPickup, ByVal CheckString As String)
    Me.InitializeComponent()
    Me.InialListBox(CheckString)

    m_entity = entity
  End Sub

  Private Sub InialListBox(ByVal CheckString As String)
    ListView1.View = View.Details
    ListView1.CheckBoxes = True
    ListView1.Columns.Add("")
    ListView1.Columns(0).Width = 20
    ListView1.Columns.Add("Document for Pickup")
    ListView1.Columns(1).Width = 250
    ListView1.FullRowSelect = True

    Dim DocumentForPickup As DataTable = CodeDescription.GetCodeList("DocumentForPickup")
    For Each row As DataRow In DocumentForPickup.Rows
      If Not row.IsNull("code_description") Then
        Dim lv As New ListViewItem("")
        lv.SubItems.Add(row("code_description"))
        lv.Tag = row("code_tag")
        If Not CheckString Is Nothing Then
          lv.Checked = Regex.Match(CheckString, "\b" & CStr(row("code_tag"))).Value.ToString.Length > 0
        End If
        ListView1.Items.Add(lv)
      End If
    Next

    'If DocumentForPickup.Rows.Count > 0 Then
    '  'chkDocPickupList.Items.Add( 
    'End If
  End Sub

  Public Sub RefreshSelectedItem()
    Dim pick As New ArrayList
    For i As Integer = 0 To ListView1.Items.Count - 1

    Next
    For Each lv As ListViewItem In Me.ListView1.Items
      If lv.Checked Then
        pick.Add(lv.Tag)
      End If
    Next

    m_entity.DocumentPickingList = ""
    If pick.Count > 0 Then
      m_entity.DocumentPickingList = String.Join(Space(1), pick.ToArray)
    End If
  End Sub

  Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
    'Me.RefreshSelectedItem()
  End Sub

  Private Sub DocPickupList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Me.RefreshSelectedItem()
  End Sub
End Class