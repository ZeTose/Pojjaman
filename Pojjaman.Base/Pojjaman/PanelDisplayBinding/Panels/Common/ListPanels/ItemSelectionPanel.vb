Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.PanelDisplayBinding
Namespace Longkong.Pojjaman.Gui.Panels.BusinessForms
    Public Class ItemSelectionPanel
        Inherits UserControl

#Region "Members"
        Private dmTable As ExpandableRowDataTable
        Private m_groupBys As New ArrayList
        Private m_selectedItems As ArrayList
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.m_groupBys.Add("Code")
            m_selectedItems = New ArrayList
            LoadData()
        End Sub
#End Region

#Region "Initialize"
        Friend WithEvents ibtnGenCode As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents dgItem As Longkong.Pojjaman.Gui.Components.PJMDataGrid
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ItemSelectionPanel))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.ibtnGenCode = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton1 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.dgItem = New Longkong.Pojjaman.Gui.Components.PJMDataGrid
            Me.btnOk = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            CType(Me.dgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(112, 23)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลขที่:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.txtCode.BackColor = System.Drawing.SystemColors.Window
            Me.txtCode.Location = New System.Drawing.Point(120, 16)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(256, 23)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'ibtnGenCode
            '
            Me.ibtnGenCode.Image = CType(resources.GetObject("ibtnGenCode.Image"), System.Drawing.Image)
            Me.ibtnGenCode.Location = New System.Drawing.Point(376, 16)
            Me.ibtnGenCode.Name = "ibtnGenCode"
            Me.ibtnGenCode.Size = New System.Drawing.Size(24, 23)
            Me.ibtnGenCode.TabIndex = 2
            Me.ibtnGenCode.TabStop = False
            Me.ibtnGenCode.ThemedImage = CType(resources.GetObject("ibtnGenCode.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton1
            '
            Me.ImageButton1.Image = CType(resources.GetObject("ImageButton1.Image"), System.Drawing.Image)
            Me.ImageButton1.Location = New System.Drawing.Point(400, 16)
            Me.ImageButton1.Name = "ImageButton1"
            Me.ImageButton1.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton1.TabIndex = 3
            Me.ImageButton1.TabStop = False
            Me.ImageButton1.ThemedImage = CType(resources.GetObject("ImageButton1.ThemedImage"), System.Drawing.Bitmap)
            '
            'dgItem
            '
            Me.dgItem.AllowColumnDrag = False
            Me.dgItem.AllowColumnResize = False
            Me.dgItem.AllowDrop = True
            Me.dgItem.AllowNew = False
            Me.dgItem.AllowRowDeletion = False
            Me.dgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgItem.AutoColumnResize = True
            Me.dgItem.CaptionVisible = False
            Me.dgItem.CustomColumnHeaders = False
            Me.dgItem.DataMember = ""
            Me.dgItem.FullRowSelect = True
            Me.dgItem.HeaderBackColor = System.Drawing.Color.IndianRed
            Me.dgItem.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dgItem.Location = New System.Drawing.Point(16, 56)
            Me.dgItem.m_dataTable = Nothing
            Me.dgItem.Name = "dgItem"
            Me.dgItem.ShowColumnHeaderWhileDragging = True
            Me.dgItem.ShowColumnWhileDragging = True
            Me.dgItem.Size = New System.Drawing.Size(648, 376)
            Me.dgItem.TabIndex = 5
            '
            'btnOk
            '
            Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOk.ForeColor = System.Drawing.Color.Black
            Me.btnOk.Location = New System.Drawing.Point(464, 440)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(96, 24)
            Me.btnOk.TabIndex = 8
            Me.btnOk.Text = "OK"
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(568, 440)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 24)
            Me.btnCancel.TabIndex = 9
            Me.btnCancel.Text = "Cancel"
            '
            'ItemSelectionPanel
            '
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.dgItem)
            Me.Controls.Add(Me.ImageButton1)
            Me.Controls.Add(Me.ibtnGenCode)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.txtCode)
            Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "ItemSelectionPanel"
            Me.Size = New System.Drawing.Size(681, 483)
            CType(Me.dgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
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
#End Region

#Region "Property"
        Public Property GroupBys() As ArrayList            Get                Return m_groupBys            End Get            Set(ByVal Value As ArrayList)                m_groupBys = Value            End Set        End Property
#End Region

#Region "Methods"
        Private Sub SetSelectedItem()
            Dim myTable As ExpandableRowDataTable = CType(dgItem.DataSource, ExpandableRowDataTable)
            For Each row As ExpandableDataRow In myTable.Childs
                For Each childRow As ExpandableDataRow In row.Childs
                    If Not IsDBNull(childRow("Selected")) Then
                        If CBool(childRow("Selected")) Then
                            m_selectedItems.Add(childRow)
                        End If
                    End If
                Next
            Next
        End Sub
        Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
            Dim myTable As ExpandableRowDataTable = CType(dgItem.DataSource, ExpandableRowDataTable)
            Dim clickedRow As ExpandableDataRow = CType(myTable.Rows(e.Row), ExpandableDataRow)
            If Not IsDBNull(clickedRow("Selected")) Then
                clickedRow("Selected") = Not CBool(clickedRow("Selected"))
            Else
                clickedRow("Selected") = False
            End If
            For Each row As ExpandableDataRow In myTable.Childs
                Dim checkCount As Integer
                For Each childRow As ExpandableDataRow In row.Childs
                    If e.Row = row.Index Then
                        childRow("Selected") = row("Selected")
                    End If
                    If CBool(childRow("Selected")) Then
                        checkCount += 1
                    End If
                Next
                If checkCount = row.Childs.Count Then
                    row("Selected") = True
                ElseIf checkCount = 0 Then
                    row("Selected") = False
                Else
                    row("Selected") = DBNull.Value
                End If
            Next
        End Sub
        Private Sub ExpandCollapseHandler(ByVal e As ExpandCollapseEventArgs)

        End Sub
        Private Sub Group()

            If Not dgItem.DataSource Is Nothing Then
                dmTable = CType(dgItem.DataSource, ExpandableRowDataTable).ChildTable
            End If
            dmTable = dmTable.UpdateGroup(m_groupBys, "Date,Requestor,Site", "Entity", "", False)
            For Each row As ExpandableDataRow In dmTable.Childs
                row("Selected") = False
            Next
            dgItem.DataSource = dmTable
            dgItem.m_dataTable = dmTable
            dgItem.Update()
            dgItem.TableStyles(0).AllowSorting = False
        End Sub
        Private Sub ResetGroup()
            If Not dgItem.DataSource Is Nothing Then
                dmTable = CType(dgItem.DataSource, ExpandableRowDataTable).ChildTable
            End If
            dgItem.DataSource = dmTable
            dgItem.m_dataTable = dmTable
            dgItem.TableStyles(0).AllowSorting = False
        End Sub
        Private Function CanGroup() As Boolean
            For Each item As String In Me.GroupBys
                If item <> "" And item <> "<None>" Then
                    Return True
                End If
            Next
            Return False
        End Function
        Public Sub LoadData()
            'Dim pr As New pr(1)

            'Dim dst As DataGridTableStyle = pr.Items.CreateTableStyle
            'If Not dst.GridColumnStyles.Contains("Selected") Then
            '    Return
            'End If
            'Dim csSelected As DatagridCheckBoxColumn = CType(dst.GridColumnStyles("Selected"), DatagridCheckBoxColumn)
            'AddHandler csSelected.Click, AddressOf Me.RowIcon_Click

            'dst.AllowSorting = False
            'dst.GridLineColor = dgItem.GridLineColor
            'dst.GridLineStyle = dgItem.GridLineStyle
            'dst.ReadOnly = True
            'dmTable = pr.Items.GetDataTable
            'For i As Integer = 0 To dmTable.Rows.Count - 1
            '    Dim row As ExpandableDataRow = CType(dmTable.Rows(i), ExpandableDataRow)
            '    row.Index = i
            '    dmTable.Rows(i)("SortIndex") = i
            '    dmTable.Childs.Add(row)
            'Next
            'dgItem.TableStyles.Add(dst)
            'dgItem.DataSource = dmTable
            'dgItem.m_dataTable = dmTable
            'AddHandler dmTable.Expand, AddressOf ExpandCollapseHandler
            'AddHandler dmTable.Collapse, AddressOf ExpandCollapseHandler

            ''สั่ง group ซะ
            'Me.Group()

        End Sub
#End Region

        Private Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImageButton1.Click
            Dim crs As New SearchCriteriaCollection
            crs.PanelText = "Test"
            For i As Integer = 1 To 10
                Dim cr As New SearchCriteria("cr1", GetType(String), "Criteria" & i)
                crs.Add(cr)
            Next

            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.AdvancedSearch(crs))
            myDialog.ShowDialog()
        End Sub

        Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
            SetSelectedItem()
            For Each item As ExpandableDataRow In Me.m_selectedItems
                MessageBox.Show(item("Entity").ToString)
            Next
        End Sub

        Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged

        End Sub
    End Class
End Namespace

