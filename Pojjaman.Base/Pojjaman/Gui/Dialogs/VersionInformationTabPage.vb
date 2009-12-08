Imports Longkong.Pojjaman.Gui.XmlForms
Imports System.Reflection
Imports Longkong.Core.Services
Imports System.Text
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class VersionInformationTabPage
        Inherits UserControl

#Region "Members"
        Private m_button As button
        Private m_columnHeader As columnHeader
        Private m_columnHeader2 As ColumnHeader
        Private m_columnHeader3 As ColumnHeader
        Private m_listView As listView
#End Region

#Region "Constructors"
        Public Sub New()
            Me.InitializeComponent()
            Me.Dock = DockStyle.Fill
            Me.FillListView()
        End Sub
#End Region

#Region "Methods"
        Private Sub CopyButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim builder As New StringBuilder
            Dim asms As [Assembly]() = AppDomain.CurrentDomain.GetAssemblies
            For i As Integer = 0 To asms.Length - 1
                Dim asm As [Assembly] = asms(i)
                Dim name As AssemblyName = asm.GetName
                builder.Append(name.Name)
                builder.Append(",")
                builder.Append(name.Version.ToString)
                builder.Append(",")
                Try
                    builder.Append(asm.Location)
                Catch ex As Exception
                    builder.Append("dynamic")
                End Try
                builder.Append(Environment.NewLine)
            Next
            Clipboard.SetDataObject(New DataObject(DataFormats.Text, builder.ToString), True)
        End Sub
        Private Sub FillListView()
            Me.m_listView.BeginUpdate()
            Dim asms As [Assembly]() = AppDomain.CurrentDomain.GetAssemblies
            For i As Integer = 0 To asms.Length - 1
                Dim asm As [Assembly] = asms(i)
                Dim name As AssemblyName = asm.GetName
                Dim item As New ListViewItem(name.Name)
                item.SubItems.Add(name.Version.ToString)
                Try
                    item.SubItems.Add(asm.Location)
                Catch ex As Exception
                    item.SubItems.Add("dynamic")
                End Try
                Me.m_listView.Items.Add(item)
            Next
            Me.m_listView.EndUpdate()
        End Sub
        Private Sub InitializeComponent()
            Dim rService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Me.m_columnHeader = New ColumnHeader
            Me.m_button = New Button
            Me.m_columnHeader2 = New ColumnHeader
            Me.m_listView = New ListView
            Me.m_columnHeader3 = New ColumnHeader
            MyBase.SuspendLayout()
            Me.m_columnHeader.Text = rService.GetString("Dialog.About.VersionInfoTabName.NameColumn")
            Me.m_columnHeader.Width = 130
            Me.m_button.Anchor = (AnchorStyles.Left Or AnchorStyles.Bottom)
            Me.m_button.Location = New Point(8, 184)
            Me.m_button.Name = "button"
            Me.m_button.TabIndex = 1
            Me.m_button.Text = rService.GetString("Dialog.About.VersionInfoTabName.CopyButton")
            AddHandler Me.m_button.Click, New EventHandler(AddressOf Me.CopyButtonClick)
            Me.m_button.FlatStyle = FlatStyle.System
            Me.m_columnHeader2.Text = rService.GetString("Dialog.About.VersionInfoTabName.VersionColumn")
            Me.m_columnHeader2.Width = 100
            Me.m_listView.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Dim headerArray1 As ColumnHeader() = New ColumnHeader() {Me.m_columnHeader, Me.m_columnHeader2, Me.m_columnHeader3}
            Me.m_listView.Columns.AddRange(headerArray1)
            Me.m_listView.FullRowSelect = True
            Me.m_listView.GridLines = True
            Me.m_listView.Sorting = SortOrder.Ascending
            Me.m_listView.Location = New Point(0, 0)
            Me.m_listView.Name = "listView"
            Me.m_listView.Size = New Size(248, 176)
            Me.m_listView.TabIndex = 0
            Me.m_listView.View = View.Details
            Me.m_columnHeader3.Text = rService.GetString("Dialog.About.VersionInfoTabName.PathColumn")
            Me.m_columnHeader3.Width = 150
            MyBase.Controls.Add(Me.m_button)
            MyBase.Controls.Add(Me.m_listView)
            MyBase.Name = "CreatedUserControl"
            MyBase.Size = New Size(248, 216)
            MyBase.ResumeLayout(False)
        End Sub
#End Region
    End Class
End Namespace

