Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CustomNoteForm
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        'Form overrides dispose to clean up the component list.
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

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents lvNotes As System.Windows.Forms.ListView
        Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
        Friend WithEvents cmbType As System.Windows.Forms.ComboBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents btnDel As System.Windows.Forms.Button
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblValue As System.Windows.Forms.Label
        Friend WithEvents cmbValue As System.Windows.Forms.ComboBox
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents chkFix As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblItem = New System.Windows.Forms.Label
            Me.lvNotes = New System.Windows.Forms.ListView
            Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
            Me.cmbType = New System.Windows.Forms.ComboBox
            Me.lblType = New System.Windows.Forms.Label
            Me.btnAdd = New System.Windows.Forms.Button
            Me.btnDel = New System.Windows.Forms.Button
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.lblValue = New System.Windows.Forms.Label
            Me.cmbValue = New System.Windows.Forms.ComboBox
            Me.btnOK = New System.Windows.Forms.Button
            Me.chkFix = New System.Windows.Forms.CheckBox
            Me.SuspendLayout()
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(16, 8)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.TabIndex = 1
            Me.lblItem.Text = "รายการหมายเหตุ"
            '
            'lvNotes
            '
            Me.lvNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lvNotes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
            Me.lvNotes.FullRowSelect = True
            Me.lvNotes.GridLines = True
            Me.lvNotes.HideSelection = False
            Me.lvNotes.Location = New System.Drawing.Point(16, 24)
            Me.lvNotes.MultiSelect = False
            Me.lvNotes.Name = "lvNotes"
            Me.lvNotes.Size = New System.Drawing.Size(592, 352)
            Me.lvNotes.TabIndex = 2
            Me.lvNotes.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader1
            '
            Me.ColumnHeader1.Text = "ชื่อ"
            Me.ColumnHeader1.Width = 134
            '
            'ColumnHeader2
            '
            Me.ColumnHeader2.Text = "Note"
            Me.ColumnHeader2.Width = 442
            '
            'cmbType
            '
            Me.cmbType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbType.Items.AddRange(New Object() {"คีย์ค่าโดยตรง", "จริง/เท็จ"})
            Me.cmbType.Location = New System.Drawing.Point(312, 384)
            Me.cmbType.Name = "cmbType"
            Me.cmbType.Size = New System.Drawing.Size(176, 21)
            Me.cmbType.TabIndex = 3
            '
            'lblType
            '
            Me.lblType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblType.Location = New System.Drawing.Point(256, 384)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(48, 23)
            Me.lblType.TabIndex = 4
            Me.lblType.Text = "ประเภท:"
            Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnAdd
            '
            Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAdd.Location = New System.Drawing.Point(120, 0)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(24, 23)
            Me.btnAdd.TabIndex = 5
            Me.btnAdd.Text = "+"
            '
            'btnDel
            '
            Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnDel.Location = New System.Drawing.Point(144, 0)
            Me.btnDel.Name = "btnDel"
            Me.btnDel.Size = New System.Drawing.Size(24, 23)
            Me.btnDel.TabIndex = 6
            Me.btnDel.Text = "-"
            '
            'txtName
            '
            Me.txtName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtName.Location = New System.Drawing.Point(72, 384)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(176, 20)
            Me.txtName.TabIndex = 8
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblName.Location = New System.Drawing.Point(16, 384)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(48, 23)
            Me.lblName.TabIndex = 4
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblValue
            '
            Me.lblValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblValue.Location = New System.Drawing.Point(16, 408)
            Me.lblValue.Name = "lblValue"
            Me.lblValue.Size = New System.Drawing.Size(48, 23)
            Me.lblValue.TabIndex = 4
            Me.lblValue.Text = "Note:"
            Me.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbValue
            '
            Me.cmbValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.cmbValue.Location = New System.Drawing.Point(72, 408)
            Me.cmbValue.Name = "cmbValue"
            Me.cmbValue.Size = New System.Drawing.Size(528, 21)
            Me.cmbValue.TabIndex = 3
            '
            'btnOK
            '
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Location = New System.Drawing.Point(176, 0)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.TabIndex = 9
            Me.btnOK.Text = "OK"
            '
            'chkFix
            '
            Me.chkFix.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkFix.Location = New System.Drawing.Point(496, 384)
            Me.chkFix.Name = "chkFix"
            Me.chkFix.TabIndex = 10
            Me.chkFix.Text = "Fix"
            '
            'CustomNoteForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(616, 438)
            Me.Controls.Add(Me.chkFix)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.btnDel)
            Me.Controls.Add(Me.btnAdd)
            Me.Controls.Add(Me.lblType)
            Me.Controls.Add(Me.cmbType)
            Me.Controls.Add(Me.lvNotes)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.lblValue)
            Me.Controls.Add(Me.cmbValue)
            Me.Name = "CustomNoteForm"
            Me.Text = "Custom Note"
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As ISimpleEntity
        Private m_customNote As CustomNote
        Private m_customNoteColl As CustomNoteCollection
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity)
            MyBase.New()
            InitializeComponent()
            m_entity = entity
            If Not m_entity.Originated Then
                Return
            End If
            m_customNoteColl = New CustomNoteCollection(m_entity)
            Populate()
        End Sub
        Private Sub Populate()
            Me.lvNotes.Items.Clear()
            If m_customNoteColl Is Nothing Then
                Return
            End If
            For Each note As CustomNote In m_customNoteColl
                Dim lvi As ListViewItem = Me.lvNotes.Items.Add(note.NoteName)
                lvi.SubItems.Add(CStr(note.Note))
                lvi.Tag = note
            Next
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            If m_customNoteColl Is Nothing Then
                Return
            End If
            m_customNote = New CustomNote
            m_customNote.NoteName = "<New>"
            m_customNoteColl.Add(m_customNote)
            Dim lvi As ListViewItem = Me.lvNotes.Items.Add("<New>")
            lvi.SubItems.Add("")
            lvi.Tag = m_customNote
            lvi.Selected = True
        End Sub
        Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
            If m_customNoteColl Is Nothing Then
                Return
            End If
            If m_customNote Is Nothing Then
                Return
            End If
            m_customNoteColl.Remove(m_customNote)
            Populate()
        End Sub
        Private Sub lvNotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvNotes.SelectedIndexChanged
            If lvNotes.SelectedItems.Count <= 0 Then
                m_customNote = Nothing
                UpdateNote()
                Return
            End If
            m_customNote = CType(lvNotes.SelectedItems(0).Tag, CustomNote)
            UpdateNote()
        End Sub
        Private Sub UpdateNote()
            If m_customNote Is Nothing Then
                Me.cmbValue.Text = ""
                If Me.cmbValue.Items.Count > 0 Then
                    Me.cmbValue.SelectedIndex = 0
                End If
                Me.cmbType.SelectedIndex = 0
                Me.txtName.Text = ""
                Me.chkFix.Checked = False
            Else
                Me.txtName.Text = m_customNote.NoteName
                Me.chkFix.Checked = m_customNote.Fix
                If m_customNote.IsDropDown Then
                    Me.cmbType.SelectedIndex = 1
                    Select Case CStr(m_customNote.Note).ToLower
                        Case "true"
                            Me.cmbValue.SelectedIndex = 0
                        Case "false"
                            Me.cmbValue.SelectedIndex = 1
                    End Select
                Else
                    Me.cmbType.SelectedIndex = 0
                    Me.cmbValue.Text = CStr(m_customNote.Note)
                End If
            End If
        End Sub
        Private Sub UpdateItem()
            If m_customNote Is Nothing Then
                Return
            End If
            If lvNotes.Items.Count <= 0 Then
                Return
            End If
            Dim lvi As ListViewItem = Me.lvNotes.SelectedItems(0)
            lvi.Text = m_customNote.NoteName
            lvi.SubItems(1).Text = CStr(m_customNote.Note)
        End Sub
        Private Sub chkFix_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFix.CheckedChanged
            If m_customNote Is Nothing Then
                Return
            End If
            m_customNote.Fix = chkFix.Checked
        End Sub
        Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
            If m_customNote Is Nothing Then
                Return
            End If
            Select Case Me.cmbType.SelectedIndex
                Case 0 'คีย์ตรง
                    Me.cmbValue.DropDownStyle = ComboBoxStyle.DropDown
                    Me.cmbValue.Items.Clear()
                    m_customNote.IsDropDown = False
                Case 1 'True/False
                    Me.cmbValue.Items.Clear()
                    Me.cmbValue.Items.AddRange(New Object() {"True", "False"})
                    m_customNote.IsDropDown = True
                    Me.cmbValue.SelectedIndex = 0
            End Select
            UpdateItem()
        End Sub
        Private Sub txtName_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Validated
            If m_customNote Is Nothing Then
                Return
            End If
            m_customNote.NoteName = txtName.Text
            UpdateItem()
        End Sub
        Private Sub cmbValue_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbValue.Validated
            If m_customNote Is Nothing Then
                Return
            End If
            If m_customNote.IsDropDown Then
                m_customNote.Note = Boolean.Parse(cmbValue.Text)
            Else
                m_customNote.Note = cmbValue.Text
            End If
            UpdateItem()
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property CustomNoteColl() As CustomNoteCollection
            Get
                Return m_customNoteColl
            End Get
        End Property
#End Region

    End Class
End Namespace

