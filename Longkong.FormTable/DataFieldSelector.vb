Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.FormTable
    Public Class DataFieldSelector
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NO The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents lvItem As System.Windows.Forms.ListView
        Friend WithEvents Fields As System.Windows.Forms.ColumnHeader
        Friend WithEvents Notes As System.Windows.Forms.ColumnHeader
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lvItem = New System.Windows.Forms.ListView
            Me.Fields = New System.Windows.Forms.ColumnHeader
            Me.Notes = New System.Windows.Forms.ColumnHeader
            Me.SuspendLayout()
            '
            'lvItem
            '
            Me.lvItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lvItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Fields, Me.Notes})
            Me.lvItem.FullRowSelect = True
            Me.lvItem.GridLines = True
            Me.lvItem.HideSelection = False
            Me.lvItem.Location = New System.Drawing.Point(8, 8)
            Me.lvItem.Name = "lvItem"
            Me.lvItem.Size = New System.Drawing.Size(296, 264)
            Me.lvItem.TabIndex = 0
            Me.lvItem.View = System.Windows.Forms.View.Details
            '
            'Fields
            '
            Me.Fields.Text = "ตัวแปร"
            Me.Fields.Width = 113
            '
            'Notes
            '
            Me.Notes.Text = "คำอธิบาย"
            Me.Notes.Width = 167
            '
            'DataFieldSelector
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(312, 278)
            Me.Controls.Add(Me.lvItem)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "DataFieldSelector"
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "ตัวแปรที่สามารถใช้ได้ในฟอร์ม"
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_field As String
#End Region

        Public Sub New(ByVal field As String)
            InitializeComponent()
            m_field = field
            SetValue(field)
        End Sub
        Public Sub New(ByVal field As String, ByVal ffCode As String, ByVal tableName As String, Optional ByVal isReport As Boolean = False)
            InitializeComponent()
            m_field = field
            If Not isReport Then
                Dim ff As New FormFormat(ffCode)
                If tableName.Length = 0 Then
                    PopulateList(ff)
                Else
                    PopulateList(ff, tableName)
                End If
            Else
                Dim rf As New ReportFormat(ffCode)
                If tableName.Length = 0 Then
                    PopulateList(rf)
                Else
                    PopulateList(rf, tableName)
                End If
            End If
            SetValue(field)
        End Sub
        Private Sub PopulateList(ByVal rf As ReportFormat)
            Dim rows As DataRow() = rf.GetFieldRows
            For Each row As DataRow In rows
                Dim litem As ListViewItem = Me.lvItem.Items.Add(row("Name").ToString)
                litem.SubItems.Add(row("Note").ToString)
                litem.Tag = row("reportfi_mapping")
            Next
            Dim item As ListViewItem = Me.lvItem.Items.Add("")
            item.Tag = "Separator"
            item = Me.lvItem.Items.Add("ข้อมูลบริษัท:")
            item.BackColor = Color.BurlyWood
            item.Tag = "Separator"
            PopulateConfigList()
        End Sub
        Private Sub PopulateList(ByVal ff As FormFormat)
            Dim rows As DataRow() = ff.GetFieldRows
            For Each row As DataRow In rows
                Dim litem As ListViewItem = Me.lvItem.Items.Add(row("Name").ToString)
                litem.SubItems.Add(row("Note").ToString)
                litem.Tag = row("formfi_mapping")
            Next
            Dim item As ListViewItem = Me.lvItem.Items.Add("")
            item.Tag = "Separator"
            item = Me.lvItem.Items.Add("ข้อมูลบริษัท:")
            item.BackColor = Color.BurlyWood
            item.Tag = "Separator"
            PopulateConfigList()
        End Sub
        Private Sub PopulateConfigList()
            'Add รายการทั่วไป
            'ชื่อ
            Dim litem As ListViewItem = Me.lvItem.Items.Add(Configuration.GetConfig("CompanyName").ToString)
            litem.SubItems.Add(Configuration.GetConfigDesc("CompanyName").ToString)
            litem.Tag = "Config.CompanyName"
            'ที่อยู่
            litem = Me.lvItem.Items.Add(Configuration.GetConfig("CompanyAddress").ToString)
            litem.SubItems.Add(Configuration.GetConfigDesc("CompanyAddress").ToString)
            litem.Tag = "Config.CompanyAddress"
            'ที่อยู่ออกบิล
            litem = Me.lvItem.Items.Add(Configuration.GetConfig("CompanyBillingAddress").ToString)
            litem.SubItems.Add(Configuration.GetConfigDesc("CompanyBillingAddress").ToString)
            litem.Tag = "Config.CompanyBillingAddress"
            'โทรศพท์
            litem = Me.lvItem.Items.Add(Configuration.GetConfig("CompanyPhone").ToString)
            litem.SubItems.Add(Configuration.GetConfigDesc("CompanyPhone").ToString)
            litem.Tag = "Config.CompanyPhone"
            'โทรสาร
            litem = Me.lvItem.Items.Add(Configuration.GetConfig("CompanyFax").ToString)
            litem.SubItems.Add(Configuration.GetConfigDesc("CompanyFax").ToString)
            litem.Tag = "Config.CompanyFax"
            'เลขประจำตัวผู้เสียภาษี
            litem = Me.lvItem.Items.Add(Configuration.GetConfig("CompanyTaxId").ToString)
            litem.SubItems.Add(Configuration.GetConfigDesc("CompanyTaxId").ToString)
            litem.Tag = "Config.CompanyTaxId"
        End Sub
        Private Sub PopulateList(ByVal ff As FormFormat, ByVal tb As String)
            Dim rows As DataRow() = ff.GetFieldRows(tb)
            For Each row As DataRow In rows
                Dim litem As ListViewItem = Me.lvItem.Items.Add(row("Name").ToString)
                litem.SubItems.Add(row("Note").ToString)
                litem.Tag = row("formfi_mapping")
            Next
        End Sub
        Private Sub PopulateList(ByVal rf As ReportFormat, ByVal tb As String)
            Dim rows As DataRow() = rf.GetFieldRows(tb)
            For Each row As DataRow In rows
                Dim litem As ListViewItem = Me.lvItem.Items.Add(row("Name").ToString)
                litem.SubItems.Add(row("Note").ToString)
                litem.Tag = row("reportfi_mapping")
            Next
        End Sub
        Private Sub SetValue(ByVal val As String)
            Me.lvItem.SelectedItems.Clear()
            Dim item As ListViewItem = ListViewHelper.SearchTag(Me.lvItem, val)
            If Not item Is Nothing Then
                item.Selected = True
            End If
        End Sub
        Public Property Field() As String
            Get
                Return m_field
            End Get
            Set(ByVal Value As String)
                m_field = Value
            End Set
        End Property
        Private Sub lvItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvItem.SelectedIndexChanged
            If Me.lvItem.SelectedItems.Count > 0 Then
                If lvItem.SelectedItems(0).Tag.ToString.ToLower = "separator" Then
                    Me.Field = ""
                    'ElseIf lvItem.SelectedItems(0).Tag.ToString.StartsWith("Config.") Then
                    '    Me.Field = "Config." & lvItem.SelectedItems(0).Text
                Else
                    Me.Field = lvItem.SelectedItems(0).Tag.ToString
                End If
            End If
        End Sub
        Private Sub lvItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick
            Me.Close()
        End Sub
    End Class

    Public Class DataFieldTypeEditor
        Inherits UITypeEditor

#Region "Members"

#End Region

#Region "Constructor"
        Public Sub New()
        End Sub
#End Region

#Region "Overrides"
        Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
            If (Not context Is Nothing And _
            Not context.Instance Is Nothing And _
            Not provider Is Nothing) Then
                Dim edSvc As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
                Try
                    If Not (edSvc Is Nothing) Then
                        If TypeOf context.Instance Is Column Then
                            Dim col As Column = CType(context.Instance, Column)
                            Dim editor As New DataFieldSelector(CStr(value), col.FormFormatCode, col.Table, col.IsReport)
                            edSvc.ShowDialog(editor)
                            ' Return the value in the appropraite data format.
                            Return editor.Field
                        ElseIf TypeOf context.Instance Is DataBoxControl Then
                            Dim dbc As DataBoxControl = CType(context.Instance, DataBoxControl)
                            If Not dbc.FindForm Is Nothing Then
                                If TypeOf dbc.FindForm Is PojjamanDoc Then
                                    Dim val As String = ""
                                    If dbc.Data.StartsWith("=") Then
                                        val = dbc.Data.Substring(1, dbc.Data.Length - 1)
                                    End If
                                    Dim pjmDoc As PojjamanDoc = CType(dbc.FindForm, PojjamanDoc)
                                    Dim editor As New DataFieldSelector(CStr(val), pjmDoc.FormFormatCode, "")
                                    edSvc.ShowDialog(editor)
                                    ' Return the value in the appropraite data format.
                                    If editor.Field.Length > 0 Then
                                        If editor.Field.StartsWith("Config.") Then
                                            Return editor.Field.Substring(7, editor.Field.Length - 7)
                                        End If
                                        Return "=" & editor.Field
                                    End If
                                ElseIf TypeOf dbc.FindForm Is PojjamanReport Then
                                    Dim val As String = ""
                                    If dbc.Data.StartsWith("=") Then
                                        val = dbc.Data.Substring(1, dbc.Data.Length - 1)
                                    End If
                                    Dim pjmReport As PojjamanReport = CType(dbc.FindForm, PojjamanReport)
                                    Dim editor As New DataFieldSelector(CStr(val), pjmReport.FormFormatCode, "", True)
                                    edSvc.ShowDialog(editor)
                                    ' Return the value in the appropraite data format.
                                    If editor.Field.Length > 0 Then
                                        If editor.Field.StartsWith("Config.") Then
                                            Return editor.Field.Substring(7, editor.Field.Length - 7)
                                        End If
                                        Return "=" & editor.Field
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try

            End If
            Return value
        End Function
        Public Overloads Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
            If (Not context Is Nothing And _
              Not context.Instance Is Nothing) Then
                Return UITypeEditorEditStyle.Modal
            End If
            Return MyBase.GetEditStyle(context)
        End Function
        Public Overloads Overrides Function GetPaintValueSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return False
        End Function
        Public Overloads Overrides Sub PaintValue(ByVal e As System.Drawing.Design.PaintValueEventArgs)

        End Sub
#End Region

    End Class

End Namespace
