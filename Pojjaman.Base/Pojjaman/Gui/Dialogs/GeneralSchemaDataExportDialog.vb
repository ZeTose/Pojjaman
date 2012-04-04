Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Text
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Collections.Generic
Imports Longkong.Pojjaman.DataAccessLayer

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class GeneralSchemaDataExportDialog
    Inherits System.Windows.Forms.Form

    Private Shared m_dsList As DataSet
    Private m_schemaName As String

    Public Sub New()
      Me.InitializeComponent()
      RefreshListReportName()
    End Sub

    Private Sub RefreshListReportName()
      If m_dsList Is Nothing Then
        m_dsList = Me.GetSchemaFromDB
      End If
      For Each row As DataRow In m_dsList.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        Dim litem As New ListViewItem(drh.GetValue(Of String)("row"))
        litem.SubItems.Add(drh.GetValue(Of String)("name"))
        litem.SubItems.Add(drh.GetValue(Of String)("entity_name"))
        litem.Tag = drh.GetValue(Of String)("entity_name")
        ListView1.Items.Add(litem)
      Next
    End Sub
    Private Function GetSchemaFromDB() As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetListSchemaName")
      Return ds
    End Function

    Private Sub InitializeComponent()
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.ListView1 = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Button1 = New System.Windows.Forms.Button()
      Me.TextBox1 = New System.Windows.Forms.TextBox()
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.SuspendLayout()
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Name = "SplitContainer1"
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.ListView1)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.Button1)
      Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox1)
      Me.SplitContainer1.Size = New System.Drawing.Size(750, 467)
      Me.SplitContainer1.SplitterDistance = 520
      Me.SplitContainer1.TabIndex = 0
      '
      'ListView1
      '
      Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
      Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ListView1.FullRowSelect = True
      Me.ListView1.Location = New System.Drawing.Point(0, 0)
      Me.ListView1.Name = "ListView1"
      Me.ListView1.Size = New System.Drawing.Size(520, 467)
      Me.ListView1.TabIndex = 0
      Me.ListView1.UseCompatibleStateImageBehavior = False
      Me.ListView1.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "No."
      Me.ColumnHeader1.Width = 50
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Name"
      Me.ColumnHeader2.Width = 235
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Schema Name"
      Me.ColumnHeader3.Width = 230
      '
      'Button1
      '
      Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Button1.Location = New System.Drawing.Point(94, 432)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(121, 23)
      Me.Button1.TabIndex = 1
      Me.Button1.Text = "Schema export"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'TextBox1
      '
      Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TextBox1.Location = New System.Drawing.Point(3, 3)
      Me.TextBox1.Multiline = True
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(220, 423)
      Me.TextBox1.TabIndex = 0
      '
      'GeneralSchemaDataExportDialog
      '
      Me.ClientSize = New System.Drawing.Size(750, 467)
      Me.Controls.Add(Me.SplitContainer1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "GeneralSchemaDataExportDialog"
      Me.ShowIcon = False
      Me.Text = "Schema export dialog"
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.Panel2.PerformLayout()
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
      m_schemaName = CStr(ListView1.SelectedItems(0).Tag)
      PreviewText()
    End Sub

    Private Sub PreviewText()
      Me.TextBox1.Text = ""
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, m_schemaName, New SqlClient.SqlParameter("@GetSchemaDate", Date.Now))
        ds.DataSetName = m_schemaName
        Me.TextBox1.Text = ds.GetXmlSchema
      Catch ex As Exception

      End Try
    End Sub

    Private Sub ExportSchema()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, m_schemaName, New SqlClient.SqlParameter("@GetSchemaDate", Date.Now))

      'ds = entitysc.DataSet
      If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 Then
        Using dlg As New System.Windows.Forms.SaveFileDialog()
          dlg.Title = "Schema export dialog"
          dlg.Filter = "XML schema files|*.xsd"
          dlg.FileName = Me.m_schemaName
          If dlg.ShowDialog = DialogResult.OK Then
            Dim path As String = dlg.FileName()
            Try
              ds.DataSetName = m_schemaName
              ds.WriteXmlSchema(path)
              MessageBox.Show("Export completed.")
            Catch ex As Exception
              Throw New Exception("Export failed.")
            End Try
          End If
        End Using
      End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
      If m_schemaName Is Nothing OrElse m_schemaName.Length = 0 Then
        Return
      End If
      Try
        PreviewText()
        ExportSchema()
      Catch ex As Exception

      End Try
    End Sub

  End Class

End Namespace