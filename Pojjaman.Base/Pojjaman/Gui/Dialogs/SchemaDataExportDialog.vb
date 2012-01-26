Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Text
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class SchemaDataExportDialog
    Inherits System.Windows.Forms.Form

#Region "Member"
    'Private m_entity As ISimpleEntity
    Private m_printingEntity As INewPrintableEntity
    Private m_entity As ISimpleEntity
    'Private m_hashDataSet As Hashtable
#End Region

#Region "Constructor"
    Public Sub New(ByVal printingEntity As INewPrintableEntity, ByVal entity As ISimpleEntity) ', ByVal printTableEntity As IPrintableEntity)
      Me.InitializeComponent()
      Me.StartPosition = FormStartPosition.CenterParent

      m_printingEntity = printingEntity
      m_entity = entity
      'm_printTableEntity = printTableEntity
      'If TypeOf m_entity Is SimpleBusinessEntityBase Then
      '  Me.EntitySimpleSchema = CType(m_entity, SimpleBusinessEntityBase).SimpleSchema
      'End If
      'm_hashDataSet = New Hashtable
      Me.Initialize()
    End Sub

#Region "Properties"
    Public Property SchemaName As String
    Private ReadOnly Property IsSchemaPreview As Boolean
      Get
        Return Me.RadioButton1.Checked
      End Get
    End Property
    'Public Property EntitySimpleSchema As EntitySimpleSchema
#End Region

#Region "Method"
    Private m_initialize As Boolean = False
    Private Sub Initialize()
      If m_printingEntity Is Nothing Then
        Return
      End If

      m_initialize = True
      Dim listofschemaname As List(Of KeyValuePair)
      If TypeOf m_printingEntity Is ISimpleListPanel Then
        listofschemaname = EntitySimpleSchema.GetListSchemaName(m_entity)
        Me.cmbSchemaName.Enabled = False
      Else
        listofschemaname = EntitySimpleSchema.GetGeneralSchemaNameList(m_entity)
        Me.cmbSchemaName.Enabled = True
      End If

      For Each schemaname As KeyValuePair In listofschemaname
        Me.cmbSchemaName.Items.Add(schemaname)
      Next

      Me.cmbSchemaName.SelectedIndex = 0
      Me.SchemaName = CType(Me.cmbSchemaName.SelectedItem, KeyValuePair).Value

      PreviewText()
      'Me.cmbSchemaName.Focus()
      m_initialize = False
    End Sub
    Private Sub PreviewText()
      If m_printingEntity Is Nothing Then
        Return
      End If

      Dim ds As DataSet

      If Me.IsSchemaPreview Then
        ds = EntitySimpleSchema.GetSchema(m_entity, Me.m_printingEntity, Me.SchemaName)
        Me.txtPreview.Text = ds.GetXmlSchema()
      Else
        ds = EntitySimpleSchema.GetData(m_entity, Me.m_printingEntity, Me.SchemaName)
        Me.txtPreview.Text = ds.GetXml
      End If

    End Sub
    Private Sub ExportSchema()
      Me.RadioButton1.Checked = True

      Dim ds As DataSet = EntitySimpleSchema.GetSchema(m_entity, Me.m_printingEntity, Me.SchemaName)

      'ds = entitysc.DataSet
      If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 Then
        Using dlg As New System.Windows.Forms.SaveFileDialog()
          dlg.Title = "Export entity schema"
          dlg.Filter = "XML schema files|*.xsd"
          dlg.FileName = Me.SchemaName
          If dlg.ShowDialog = DialogResult.OK Then
            Dim path As String = dlg.FileName()
            Try
              ds.WriteXmlSchema(path)
              MessageBox.Show("Export entity schema complete.")
            Catch ex As Exception
              Throw New Exception("export entity schema failed.")
            End Try
          End If
        End Using
      End If
    End Sub

    Private Sub ExportData()
      Me.RadioButton2.Checked = True

      Dim ds As DataSet = EntitySimpleSchema.GetData(m_entity, Me.m_printingEntity, Me.SchemaName)

      'ds = entitysc.DataSet
      If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 Then
        Using dlg As New System.Windows.Forms.SaveFileDialog()
          dlg.Title = "Export entity data"
          dlg.Filter = "XML data Files|*.xml"
          dlg.FileName = Me.SchemaName
          If dlg.ShowDialog = DialogResult.OK Then
            Dim path As String = dlg.FileName()
            Try
              ds.WriteXml(path)
              MessageBox.Show("Export entity data complete.")
            Catch ex As Exception
              Throw New Exception("export entity data failed.")
            End Try
          End If
        End Using
      End If
    End Sub
#End Region

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSchemaName As System.Windows.Forms.ComboBox
    Friend WithEvents btnExportSchema As System.Windows.Forms.Button
    Friend WithEvents btnExportData As System.Windows.Forms.Button
#End Region

    Private Sub InitializeComponent()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.cmbSchemaName = New System.Windows.Forms.ComboBox()
      Me.txtPreview = New System.Windows.Forms.TextBox()
      Me.btnExportSchema = New System.Windows.Forms.Button()
      Me.btnExportData = New System.Windows.Forms.Button()
      Me.RadioButton1 = New System.Windows.Forms.RadioButton()
      Me.RadioButton2 = New System.Windows.Forms.RadioButton()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.cmbSchemaName)
      Me.GroupBox1.Controls.Add(Me.txtPreview)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(674, 571)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      '
      'cmbSchemaName
      '
      Me.cmbSchemaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSchemaName.FormattingEnabled = True
      Me.cmbSchemaName.Location = New System.Drawing.Point(7, 15)
      Me.cmbSchemaName.Name = "cmbSchemaName"
      Me.cmbSchemaName.Size = New System.Drawing.Size(249, 21)
      Me.cmbSchemaName.TabIndex = 1
      '
      'txtPreview
      '
      Me.txtPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPreview.Location = New System.Drawing.Point(7, 44)
      Me.txtPreview.Multiline = True
      Me.txtPreview.Name = "txtPreview"
      Me.txtPreview.ReadOnly = True
      Me.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtPreview.Size = New System.Drawing.Size(661, 521)
      Me.txtPreview.TabIndex = 0
      '
      'btnExportSchema
      '
      Me.btnExportSchema.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnExportSchema.Location = New System.Drawing.Point(564, 589)
      Me.btnExportSchema.Name = "btnExportSchema"
      Me.btnExportSchema.Size = New System.Drawing.Size(116, 23)
      Me.btnExportSchema.TabIndex = 1
      Me.btnExportSchema.Text = "Export Schema"
      Me.btnExportSchema.UseVisualStyleBackColor = True
      '
      'btnExportData
      '
      Me.btnExportData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnExportData.Location = New System.Drawing.Point(564, 615)
      Me.btnExportData.Name = "btnExportData"
      Me.btnExportData.Size = New System.Drawing.Size(116, 23)
      Me.btnExportData.TabIndex = 1
      Me.btnExportData.Text = "Export Data"
      Me.btnExportData.UseVisualStyleBackColor = True
      '
      'RadioButton1
      '
      Me.RadioButton1.AccessibleName = "previewType"
      Me.RadioButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.RadioButton1.AutoSize = True
      Me.RadioButton1.Checked = True
      Me.RadioButton1.Location = New System.Drawing.Point(13, 594)
      Me.RadioButton1.Name = "RadioButton1"
      Me.RadioButton1.Size = New System.Drawing.Size(104, 17)
      Me.RadioButton1.TabIndex = 2
      Me.RadioButton1.TabStop = True
      Me.RadioButton1.Text = "Schema preview"
      Me.RadioButton1.UseVisualStyleBackColor = True
      '
      'RadioButton2
      '
      Me.RadioButton2.AccessibleName = "previewType"
      Me.RadioButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.RadioButton2.AutoSize = True
      Me.RadioButton2.Location = New System.Drawing.Point(123, 595)
      Me.RadioButton2.Name = "RadioButton2"
      Me.RadioButton2.Size = New System.Drawing.Size(88, 17)
      Me.RadioButton2.TabIndex = 2
      Me.RadioButton2.Text = "Data preview"
      Me.RadioButton2.UseVisualStyleBackColor = True
      '
      'SchemaDataExportDialog
      '
      Me.ClientSize = New System.Drawing.Size(698, 645)
      Me.Controls.Add(Me.RadioButton2)
      Me.Controls.Add(Me.RadioButton1)
      Me.Controls.Add(Me.btnExportData)
      Me.Controls.Add(Me.btnExportSchema)
      Me.Controls.Add(Me.GroupBox1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SchemaDataExportDialog"
      Me.Text = "Schema data export dialog"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

    Private Sub btnExportSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportSchema.Click
      Me.SchemaName = CType(Me.cmbSchemaName.SelectedItem, KeyValuePair).Value

      PreviewText()
      ExportSchema()
    End Sub

    Private Sub cmbSchemaName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSchemaName.SelectedIndexChanged
      Me.SchemaName = CType(Me.cmbSchemaName.SelectedItem, KeyValuePair).Value

      If Not m_initialize Then
        PreviewText()

      End If
    End Sub
    Friend WithEvents txtPreview As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton

    Private Sub btnExportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportData.Click
      Me.SchemaName = CType(Me.cmbSchemaName.SelectedItem, KeyValuePair).Value

      PreviewText()
      ExportData()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
      PreviewText()
    End Sub
  End Class

End Namespace