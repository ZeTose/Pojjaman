Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Text.RegularExpressions
Imports Longkong.Pojjaman.Commands
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class SelectFormsDialog
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
        Friend WithEvents lblPath As System.Windows.Forms.Label
        Friend WithEvents txtPath As System.Windows.Forms.TextBox
        Friend WithEvents cmbFormsList As System.Windows.Forms.ComboBox
        Friend WithEvents lblForms As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SelectFormsDialog))
            Me.lblPath = New System.Windows.Forms.Label
            Me.txtPath = New System.Windows.Forms.TextBox
            Me.cmbFormsList = New System.Windows.Forms.ComboBox
            Me.lblForms = New System.Windows.Forms.Label
            Me.btnCancel = New System.Windows.Forms.Button
            Me.btnOK = New System.Windows.Forms.Button
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.SuspendLayout()
            '
            'lblPath
            '
            Me.lblPath.Location = New System.Drawing.Point(8, 40)
            Me.lblPath.Name = "lblPath"
            Me.lblPath.Size = New System.Drawing.Size(80, 23)
            Me.lblPath.TabIndex = 7
            Me.lblPath.Text = "Path"
            Me.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPath
            '
            Me.txtPath.Location = New System.Drawing.Point(96, 40)
            Me.txtPath.Multiline = True
            Me.txtPath.Name = "txtPath"
            Me.txtPath.ReadOnly = True
            Me.txtPath.Size = New System.Drawing.Size(368, 40)
            Me.txtPath.TabIndex = 3
            Me.txtPath.TabStop = False
            Me.txtPath.Text = ""
            '
            'cmbFormsList
            '
            Me.cmbFormsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbFormsList.Location = New System.Drawing.Point(96, 16)
            Me.cmbFormsList.Name = "cmbFormsList"
            Me.cmbFormsList.Size = New System.Drawing.Size(320, 21)
            Me.cmbFormsList.TabIndex = 0
            '
            'lblForms
            '
            Me.lblForms.Location = New System.Drawing.Point(8, 16)
            Me.lblForms.Name = "lblForms"
            Me.lblForms.Size = New System.Drawing.Size(88, 23)
            Me.lblForms.TabIndex = 6
            Me.lblForms.Text = "ฟอร์มมาตรฐาน"
            Me.lblForms.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Location = New System.Drawing.Point(368, 88)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 23)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "Cancel"
            '
            'btnOK
            '
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Location = New System.Drawing.Point(288, 88)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.TabIndex = 4
            Me.btnOK.Text = "OK"
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(416, 16)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 1
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(440, 16)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 2
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'SelectFormsDialog
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
            Me.ClientSize = New System.Drawing.Size(474, 120)
            Me.ControlBox = False
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.cmbFormsList)
            Me.Controls.Add(Me.txtPath)
            Me.Controls.Add(Me.lblPath)
            Me.Controls.Add(Me.lblForms)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.KeyPreview = True
            Me.Name = "SelectFormsDialog"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "เลือกฟอร์ม"
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_keyvaluepairList As ArrayList
        Private m_keyvaluepair As KeyValuePair
        Private StringParserService As StringParserService
        Private m_paths As FormPaths
#End Region

#Region "Constructors"
        Public Sub New(ByVal paths As FormPaths)
            InitializeComponent()
            m_paths = paths
            m_keyvaluepairList = New ArrayList
            StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim keys(paths.FormPaths.Count - 1) As KeyValuePair
            Dim i As Integer = 0
            For Each fp As FormPath In paths.FormPaths
                keys(i) = New KeyValuePair(fp.Name, fp.Path)
                m_keyvaluepairList.Add(keys(i))
                i += 1
            Next
            Initialize()
            SetLabelText()
            EventWiring()
            UpdateEntityProperties()
        End Sub
#End Region

#Region "Methods"
        Private m_isInit As Boolean = False
        Private Sub Initialize()
            m_isInit = True
            For Each keyVal As KeyValuePair In m_keyvaluepairList
                cmbFormsList.Items.Add(keyVal)
            Next
            If cmbFormsList.Items.Count > 0 Then
                cmbFormsList.SelectedIndex = 0
            End If
        End Sub
        Private Sub SetLabelText()
            Me.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog.Text}")
            Me.btnOK.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog.btnOK}")
            Me.btnCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog.btnCancel}")
            Me.lblForms.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog.lblForms}")
            Me.lblPath.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog.lblPath}")
        End Sub
        Protected Sub EventWiring()
            AddHandler cmbFormsList.SelectedIndexChanged, AddressOf Me.ChangeProperty
            AddHandler ibtnBlank.Click, AddressOf Me.ChangeProperty
            AddHandler ibtnDelRow.Click, AddressOf Me.ChangeProperty
        End Sub
        Protected Sub UpdateEntityProperties()
            For Each item As KeyValuePair In Me.cmbFormsList.Items
                If Me.cmbFormsList.SelectedItem Is item Then
                    Me.KeyValuePair = item
                    Exit For
                End If
            Next
            txtPath.Text = Me.KeyValuePair.Value
        End Sub
        Protected Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Not m_isInit Then
                Return
            End If
            m_isInit = False
            Select Case CType(sender, Control).Name.ToLower
                Case "cmbformslist"
                    If Not Me.cmbFormsList.SelectedItem Is Nothing Then
                        Me.m_paths.ChangeCurrentFormPath(CType(Me.cmbFormsList.SelectedItem, KeyValuePair).Key)
                    End If
                Case "ibtnblank"
                    Dim dlg As New System.Windows.Forms.OpenFileDialog
                    With dlg
                        .Title = Me.Text
            .Filter = "XML File|*.xml|All File|*.*"
                    End With
                    If dlg.ShowDialog = DialogResult.OK Then
                        Dim path As String = dlg.FileName()
                        Dim item As Object = FindInCombo(path)
                        If item Is Nothing Then
                            Dim id As Integer = MaxIndex()
                            Dim key As String = Microsoft.VisualBasic.InputBox("กรุณาระบุชื่อฟอร์ม", "ชื่อฟอร์ม", "User Defined" & id.ToString)
                            If key.Length = 0 Then
                                key = "User Defined" & id.ToString
                            End If
                            item = New KeyValuePair(key, path)
                            If cmbFormsList.Items.Count > 0 Then
                                cmbFormsList.Items.Insert(0, item)
                            Else
                                cmbFormsList.Items.Add(item)
                            End If
                        End If
                        cmbFormsList.SelectedItem = item
                        Me.m_paths.AddFormPath(CType(item, KeyValuePair).Key, CType(item, KeyValuePair).Value)
                    End If
                Case "ibtndelrow"
                    If Me.m_paths.FormPaths.Count > 1 Then
                        If Not Me.cmbFormsList.SelectedItem Is Nothing Then
                            Dim fp As FormPath = Me.FindInPaths(CType(Me.cmbFormsList.SelectedItem, KeyValuePair).Key)
                            If Me.m_paths.FormPaths.Contains(fp) Then
                                Me.m_paths.FormPaths.Remove(fp)
                            End If
                            Me.cmbFormsList.Items.Remove(Me.cmbFormsList.SelectedItem)
                            If Me.cmbFormsList.Items.Count > 0 Then
                                Me.cmbFormsList.SelectedIndex = 0
                            End If
                            If Not Me.cmbFormsList.SelectedItem Is Nothing Then
                                Me.m_paths.ChangeCurrentFormPath(CType(Me.cmbFormsList.SelectedItem, KeyValuePair).Key)
                            End If
                        End If
                    End If
            End Select
            m_isInit = True
            UpdateEntityProperties()
        End Sub
        Private Function MaxIndex() As Integer
            Dim re As New Regex("User\sDefined(\d+)$")
            Dim maxId As Integer = 0
            For Each item As KeyValuePair In Me.cmbFormsList.Items
                If re.IsMatch(item.Key) Then
                    Dim m As Match = re.Match(item.Key)
                    Dim num As String = m.Groups(1).Value
                    If maxId < CInt(num) Then
                        maxId = CInt(num)
                    End If
                End If
            Next
            Return maxId + 1
        End Function
        Private Function FindInPaths(ByVal name As String) As FormPath
            For Each fp As FormPath In Me.m_paths.FormPaths
                If fp.Name.ToLower = name.ToLower Then
                    Return fp
                End If
            Next
            Return Nothing
        End Function
        Private Function FindInCombo(ByVal path As String) As Object
            For Each item As KeyValuePair In Me.cmbFormsList.Items
                If item.Value.ToLower = path.ToLower Then
                    Return item
                End If
            Next
            Return Nothing
        End Function
#End Region

#Region "Properties"
        Public Property KeyValuePair() As KeyValuePair
            Get
                Return m_keyvaluepair
            End Get
            Set(ByVal Value As KeyValuePair)
                m_keyvaluepair = Value
            End Set
        End Property
#End Region

#Region "Event Handlers"
        Private Sub LoginDiaog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            Select Case e.KeyCode
                Case Keys.Enter
          If StartPojjamanWorkbenchCommand.ALLOWTAB Then
                    SendKeys.Send("{tab}")
          End If
                    e.Handled = True
            End Select
        End Sub

#End Region

    End Class

End Namespace
