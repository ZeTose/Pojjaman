Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ViewCreateModifyDeletePanel
        Inherits System.Windows.Forms.UserControl
        Implements IAccessPanel

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents rdNone As System.Windows.Forms.RadioButton
        Friend WithEvents rdFull As System.Windows.Forms.RadioButton
        Friend WithEvents rdPartial As System.Windows.Forms.RadioButton
        Friend WithEvents chkView As System.Windows.Forms.CheckBox
        Friend WithEvents chkCreate As System.Windows.Forms.CheckBox
        Friend WithEvents chkModify As System.Windows.Forms.CheckBox
        Friend WithEvents chkDelete As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.rdNone = New System.Windows.Forms.RadioButton
            Me.rdFull = New System.Windows.Forms.RadioButton
            Me.rdPartial = New System.Windows.Forms.RadioButton
            Me.chkView = New System.Windows.Forms.CheckBox
            Me.chkCreate = New System.Windows.Forms.CheckBox
            Me.chkModify = New System.Windows.Forms.CheckBox
            Me.chkDelete = New System.Windows.Forms.CheckBox
            Me.SuspendLayout()
            '
            'rdNone
            '
            Me.rdNone.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdNone.Location = New System.Drawing.Point(24, 8)
            Me.rdNone.Name = "rdNone"
            Me.rdNone.TabIndex = 0
            Me.rdNone.Text = "None"
            '
            'rdFull
            '
            Me.rdFull.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdFull.Location = New System.Drawing.Point(24, 32)
            Me.rdFull.Name = "rdFull"
            Me.rdFull.TabIndex = 1
            Me.rdFull.Text = "Full"
            '
            'rdPartial
            '
            Me.rdPartial.Enabled = False
            Me.rdPartial.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdPartial.Location = New System.Drawing.Point(24, 56)
            Me.rdPartial.Name = "rdPartial"
            Me.rdPartial.TabIndex = 2
            Me.rdPartial.Text = "Partial"
            '
            'chkView
            '
            Me.chkView.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkView.Location = New System.Drawing.Point(48, 80)
            Me.chkView.Name = "chkView"
            Me.chkView.TabIndex = 3
            Me.chkView.Text = "View"
            '
            'chkCreate
            '
            Me.chkCreate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkCreate.Location = New System.Drawing.Point(72, 104)
            Me.chkCreate.Name = "chkCreate"
            Me.chkCreate.TabIndex = 4
            Me.chkCreate.Text = "Create"
            '
            'chkModify
            '
            Me.chkModify.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkModify.Location = New System.Drawing.Point(72, 128)
            Me.chkModify.Name = "chkModify"
            Me.chkModify.TabIndex = 4
            Me.chkModify.Text = "Modify"
            '
            'chkDelete
            '
            Me.chkDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkDelete.Location = New System.Drawing.Point(72, 152)
            Me.chkDelete.Name = "chkDelete"
            Me.chkDelete.TabIndex = 4
            Me.chkDelete.Text = "Delete"
            '
            'ViewCreateModifyDeletePanel
            '
            Me.Controls.Add(Me.chkCreate)
            Me.Controls.Add(Me.chkView)
            Me.Controls.Add(Me.rdPartial)
            Me.Controls.Add(Me.rdFull)
            Me.Controls.Add(Me.rdNone)
            Me.Controls.Add(Me.chkModify)
            Me.Controls.Add(Me.chkDelete)
            Me.Name = "ViewCreateModifyDeletePanel"
            Me.Size = New System.Drawing.Size(176, 272)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_accessValue As Integer
#End Region

#Region "Event"
        Private Sub EventWiring()
            AddHandler rdNone.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdFull.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdPartial.CheckedChanged, AddressOf ChangeProperty

            AddHandler chkView.CheckedChanged, AddressOf ChangeProperty
            AddHandler chkCreate.CheckedChanged, AddressOf ChangeProperty
            AddHandler chkModify.CheckedChanged, AddressOf ChangeProperty
            AddHandler chkDelete.CheckedChanged, AddressOf ChangeProperty

        End Sub
        Private m_updating As Boolean = False
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Select Case CType(sender, Control).Name.ToLower
                Case "rdnone", "rdfull", "rdpartial"
                    If rdNone.Checked Then
                        Me.chkView.Checked = False
                        Me.chkCreate.Checked = False
                        Me.chkModify.Checked = False
                        Me.chkDelete.Checked = False
                        m_accessValue = 1
                    ElseIf rdFull.Checked Then
                        Me.chkView.Checked = True
                        Me.chkCreate.Checked = True
                        Me.chkModify.Checked = True
                        Me.chkDelete.Checked = True
                        m_accessValue = 122
                    Else
                        'Do nothing
                    End If
                Case "chkview"
                    If chkView.Checked Then
                        'ยังไงก็ 1 มาก่อน
                        m_accessValue = 12
                        Me.rdPartial.PerformClick()
                    Else
                        Me.rdNone.PerformClick()
                        Me.chkView.Checked = False
                        Me.chkCreate.Checked = False
                        Me.chkModify.Checked = False
                        Me.chkDelete.Checked = False
                        m_accessValue = 1
                    End If
                Case "chkcreate"
                    If chkCreate.Checked Then
                        If m_accessValue = 108 Then
                            'ก่อนจะ Full
                            m_accessValue = 122
                            Me.rdFull.PerformClick()
                        ElseIf m_accessValue = 1 Then
                            'None
                            m_accessValue = 28
                            Me.rdPartial.PerformClick()
                        Else
                            m_accessValue += 16
                        End If
                    Else
                        If m_accessValue = 122 Then
                            'Full
                            m_accessValue = 108
                            Me.rdPartial.PerformClick()
                        Else
                            m_accessValue -= 16
                        End If
                    End If
            End Select
            m_updating = False
        End Sub
#End Region

#Region "IAccessPanel"
        Public Property AccessValue() As Integer Implements IAccessPanel.AccessValue
            Get
                Return Me.m_accessValue
            End Get
            Set(ByVal Value As Integer)
                m_accessValue = Value
            End Set
        End Property
        Public Property Value() As Decimal Implements IAccessPanel.Value
            Get
                Return 0
            End Get
            Set(ByVal Value As Decimal)

            End Set
        End Property
        Public Sub SetToFull() Implements IAccessPanel.SetToFull
        End Sub
        Public Sub SetToNone() Implements IAccessPanel.SetToNone
        End Sub
#End Region

    End Class
End Namespace
