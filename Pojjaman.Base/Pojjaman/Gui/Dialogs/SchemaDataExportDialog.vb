Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Text
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Collections.Generic
Imports DevExpress.XtraReports.UI
Imports System.Reflection
Imports DevExpress.LookAndFeel

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class SchemaDataExportDialog
    Inherits System.Windows.Forms.Form

#Region "Member"
    'Private m_entity As ISimpleEntity
    Private m_printingEntity As INewPrintableEntity
    Private m_entity As ISimpleEntity
    'Private m_hashDataSet As Hashtable
    Private ds As DataSet
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
    'Private ReadOnly Property IsSchemaPreview As Boolean
    '  Get
    '    Return Me.RadioButton1.Checked
    '  End Get
    'End Property
    'Public Property EntitySimpleSchema As EntitySimpleSchema
    Public ReadOnly Property DefaultReportPath As String      Get
        Dim newDirectoty As String = Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) &
                                     Path.DirectorySeparatorChar & ".." & Path.DirectorySeparatorChar & "data" &
                                     Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "DevExpress" & Path.DirectorySeparatorChar
        Return IO.Path.GetFullPath(newDirectoty)
      End Get
    End Property
    Public ReadOnly Property FullReportTemplateName As String      Get
        Return Me.DefaultReportPath & "XtraReportTemplate1.repx"
      End Get
    End Property
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

      Me.lbListTableName.Items.Clear()
      Me.dgSchema.DataSource = Nothing

      'Dim ds As DataSet

      'If Me.IsSchemaPreview Then
      ds = EntitySimpleSchema.GetSchema(m_entity, Me.m_printingEntity, Me.SchemaName)
      'Me.txtPreview.Text = ds.GetXmlSchema()
      'Else


      Dim ds2 As DataSet = EntitySimpleSchema.GetData(m_entity, Me.m_printingEntity, Me.SchemaName)


      For Each dt As DataTable In ds.Tables
        If ds2.Tables.Contains(dt.TableName) Then
          For Each drow As DataRow In ds2.Tables(dt.TableName).Rows
            Dim dr As DataRow = dt.NewRow()
            For Each dcol As DataColumn In ds2.Tables(dt.TableName).Columns
              dr(dcol.ColumnName) = drow(dcol.ColumnName)
            Next
            dt.Rows.Add(dr)
          Next
        End If
      Next

      'Me.txtPreview.Text = ds.GetXml
      'End If

      For Each dt As DataTable In ds.Tables
        Me.lbListTableName.Items.Add(dt.TableName)
      Next

      If ds.Tables.Count > 0 Then
        Me.PreviewGrid(ds, ds.Tables(0).TableName)
      End If

    End Sub
    Private Sub PreviewGrid(ds As DataSet, ByVal tableName As String)
      Me.dgSchema.DataSource = Nothing

      dgSchema.DataSource = ds.Tables(tableName)
      dgSchema.ReadOnly = True
    End Sub
    'Private Sub PreviewText()
    '  If m_printingEntity Is Nothing Then
    '    Return
    '  End If

    '  Dim ds As DataSet

    '  If Me.IsSchemaPreview Then
    '    ds = EntitySimpleSchema.GetSchema(m_entity, Me.m_printingEntity, Me.SchemaName)
    '    Me.txtPreview.Text = ds.GetXmlSchema()
    '  Else
    '    ds = EntitySimpleSchema.GetData(m_entity, Me.m_printingEntity, Me.SchemaName)
    '    Me.txtPreview.Text = ds.GetXml
    '  End If

    'End Sub
    Private Sub ExportTemplate()
      'Me.RadioButton1.Checked = True

      Dim dsc As DataSet = EntitySimpleSchema.GetSchema(m_entity, Me.m_printingEntity, Me.SchemaName)

      Dim newReport As New XtraReport
      newReport.PaperKind = Printing.PaperKind.A4

      If IO.File.Exists(Me.FullReportTemplateName) Then
        newReport = XtraReport.FromFile(Me.FullReportTemplateName, True)
      End If

      newReport.Name = m_entity.ClassName & "General"
      newReport.DisplayName = m_entity.ClassName & "General"
      newReport.DataSourceSchema = dsc.GetXmlSchema

      'ds = entitysc.DataSet
      If Not dsc Is Nothing AndAlso Not dsc.Tables.Count = 0 Then
        Using dlg As New System.Windows.Forms.SaveFileDialog()
          dlg.Title = "Export Report Template"
          dlg.Filter = "Report File (*.repx)|*.repx"
          dlg.FileName = m_entity.ClassName & "General"
          If dlg.ShowDialog = DialogResult.OK Then
            Dim path As String = dlg.FileName()
            Try
              newReport.Name = IO.Path.GetFileName(dlg.FileName).Replace(".repx", "")
              newReport.DisplayName = IO.Path.GetFileName(dlg.FileName).Replace(".repx", "")
              newReport.SaveLayout(path)

              Dim msg As String = "Export Template เรียบร้อยแล้ว" & vbCrLf & "ต้องการเปิด Pojjaman Form Designer เลยหรือไม่"
              If MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Dim userLookAndFeel_ As New UserLookAndFeel(newReport)
                userLookAndFeel_.UseDefaultLookAndFeel = False
                userLookAndFeel_.UseWindowsXPTheme = False
                userLookAndFeel_.Style = LookAndFeelStyle.Skin
                userLookAndFeel_.SkinName = "Metropolis"
                newReport.ShowRibbonDesigner(userLookAndFeel_)
              End If

              'newReport.ShowDesigner()
              'Process.Start(path)
              'Shell("C:\Program Files (x86)\Longkong Studio\Pojjaman Form Designer\PojjamanFormDesigner.exe", AppWinStyle.MaximizedFocus)



              'dsc.WriteXmlSchema(path)
              'If MessageBox.Show("Export Template Complete, เปิดเลยป่าว??", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
              '  Dim str As String = System.Reflection.Assembly.GetExecutingAssembly.Location()

              '  'Process.Start
              'End If

            Catch ex As Exception
              Throw New Exception("Export Failed.")
            End Try
          End If
        End Using
      End If
    End Sub

    Private Sub ExportSchema()
      'Me.RadioButton1.Checked = True

      Dim dsc As DataSet = EntitySimpleSchema.GetSchema(m_entity, Me.m_printingEntity, Me.SchemaName)

      'ds = entitysc.DataSet
      If Not dsc Is Nothing AndAlso Not dsc.Tables.Count = 0 Then
        Using dlg As New System.Windows.Forms.SaveFileDialog()
          dlg.Title = "Export entity schema"
          dlg.Filter = "XML schema files|*.xsd"
          dlg.FileName = Me.SchemaName
          If dlg.ShowDialog = DialogResult.OK Then
            Dim path As String = dlg.FileName()
            Try
              dsc.WriteXmlSchema(path)
              MessageBox.Show("Export Entity Schema Complete.")
            Catch ex As Exception
              Throw New Exception("Export Failed.")
            End Try
          End If
        End Using
      End If
    End Sub

    Private Sub ExportData()
      'Me.RadioButton2.Checked = True

      Dim dsd As DataSet = EntitySimpleSchema.GetData(m_entity, Me.m_printingEntity, Me.SchemaName)

      'ds = entitysc.DataSet
      If Not dsd Is Nothing AndAlso Not dsd.Tables.Count = 0 Then
        Using dlg As New System.Windows.Forms.SaveFileDialog()
          dlg.Title = "Export entity data"
          dlg.Filter = "XML data Files|*.xml"
          dlg.FileName = Me.SchemaName
          If dlg.ShowDialog = DialogResult.OK Then
            Dim path As String = dlg.FileName()
            Try
              dsd.WriteXml(path)
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
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.dgSchema = New System.Windows.Forms.DataGridView()
      Me.lbListTableName = New System.Windows.Forms.ListBox()
      Me.cmbSchemaName = New System.Windows.Forms.ComboBox()
      Me.btnExportSchema = New System.Windows.Forms.Button()
      Me.btnExportData = New System.Windows.Forms.Button()
      Me.btnExportTemplate = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.GroupBox1.SuspendLayout()
      CType(Me.dgSchema, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.dgSchema)
      Me.GroupBox1.Controls.Add(Me.lbListTableName)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 55)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(674, 528)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(6, 140)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(47, 13)
      Me.Label3.TabIndex = 2
      Me.Label3.Text = "Columns"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 15)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(39, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Tables"
      '
      'dgSchema
      '
      Me.dgSchema.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgSchema.Location = New System.Drawing.Point(9, 157)
      Me.dgSchema.Name = "dgSchema"
      Me.dgSchema.Size = New System.Drawing.Size(659, 365)
      Me.dgSchema.TabIndex = 3
      '
      'lbListTableName
      '
      Me.lbListTableName.FormattingEnabled = True
      Me.lbListTableName.Location = New System.Drawing.Point(7, 32)
      Me.lbListTableName.Name = "lbListTableName"
      Me.lbListTableName.Size = New System.Drawing.Size(249, 95)
      Me.lbListTableName.TabIndex = 2
      '
      'cmbSchemaName
      '
      Me.cmbSchemaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSchemaName.FormattingEnabled = True
      Me.cmbSchemaName.Location = New System.Drawing.Point(12, 25)
      Me.cmbSchemaName.Name = "cmbSchemaName"
      Me.cmbSchemaName.Size = New System.Drawing.Size(249, 21)
      Me.cmbSchemaName.TabIndex = 1
      '
      'btnExportSchema
      '
      Me.btnExportSchema.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExportSchema.Location = New System.Drawing.Point(141, 589)
      Me.btnExportSchema.Name = "btnExportSchema"
      Me.btnExportSchema.Size = New System.Drawing.Size(116, 49)
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
      Me.btnExportData.Visible = False
      '
      'btnExportTemplate
      '
      Me.btnExportTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExportTemplate.Location = New System.Drawing.Point(19, 589)
      Me.btnExportTemplate.Name = "btnExportTemplate"
      Me.btnExportTemplate.Size = New System.Drawing.Size(116, 49)
      Me.btnExportTemplate.TabIndex = 1
      Me.btnExportTemplate.Text = "Export Template"
      Me.btnExportTemplate.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(9, 7)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(46, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Schema"
      '
      'SchemaDataExportDialog
      '
      Me.ClientSize = New System.Drawing.Size(698, 645)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmbSchemaName)
      Me.Controls.Add(Me.btnExportData)
      Me.Controls.Add(Me.btnExportTemplate)
      Me.Controls.Add(Me.btnExportSchema)
      Me.Controls.Add(Me.GroupBox1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SchemaDataExportDialog"
      Me.Text = "Report Template/Schema Export Dialog"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.dgSchema, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

    Private Sub btnExportSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportSchema.Click
      Me.SchemaName = CType(Me.cmbSchemaName.SelectedItem, KeyValuePair).Value

      'PreviewText()
      ExportSchema()
      Me.Close()

    End Sub

    Private Sub btnExportTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportTemplate.Click
      Me.SchemaName = CType(Me.cmbSchemaName.SelectedItem, KeyValuePair).Value

      'PreviewText()
      ExportTemplate()
      Me.Close()

    End Sub

    Private Sub cmbSchemaName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSchemaName.SelectedIndexChanged
      Me.SchemaName = CType(Me.cmbSchemaName.SelectedItem, KeyValuePair).Value

      If Not m_initialize Then
        PreviewText()
      End If
    End Sub

    Private Sub btnExportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportData.Click
      Me.SchemaName = CType(Me.cmbSchemaName.SelectedItem, KeyValuePair).Value

      'PreviewText()
      ExportData()
    End Sub

    Friend WithEvents dgSchema As System.Windows.Forms.DataGridView
    Friend WithEvents lbListTableName As System.Windows.Forms.ListBox


    Private Sub lbListTableName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbListTableName.SelectedIndexChanged
      If ds Is Nothing Then
        ds = EntitySimpleSchema.GetData(m_entity, Me.m_printingEntity, Me.SchemaName)
      End If

      Dim tbName As String = lbListTableName.SelectedItem.ToString

      PreviewGrid(ds, tbName)
    End Sub
    Friend WithEvents btnExportTemplate As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

  End Class

End Namespace