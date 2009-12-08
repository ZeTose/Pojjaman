Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CheckRunningView
        Inherits System.Windows.Forms.UserControl
        Implements IPreAddView

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

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents lblStartCode As System.Windows.Forms.Label
        Friend WithEvents txtStartCode As System.Windows.Forms.TextBox
        Friend WithEvents lblEndCode As System.Windows.Forms.Label
        Friend WithEvents txtEndCode As System.Windows.Forms.TextBox
        Friend WithEvents grbCheckRegister As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnBankAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblBankAccount As System.Windows.Forms.Label
        Friend WithEvents txtBankAccountCode As System.Windows.Forms.TextBox
        Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
        Friend WithEvents btnAutoRun As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CheckRunningView))
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.grbCheckRegister = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnBankAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblBankAccount = New System.Windows.Forms.Label
            Me.txtBankAccountCode = New System.Windows.Forms.TextBox
            Me.txtBankAccountName = New System.Windows.Forms.TextBox
            Me.btnAutoRun = New System.Windows.Forms.Button
            Me.lblStartCode = New System.Windows.Forms.Label
            Me.txtStartCode = New System.Windows.Forms.TextBox
            Me.lblEndCode = New System.Windows.Forms.Label
            Me.txtEndCode = New System.Windows.Forms.TextBox
            Me.grbCheckRegister.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbCheckRegister
            '
            Me.grbCheckRegister.Controls.Add(Me.btnBankAccountFind)
            Me.grbCheckRegister.Controls.Add(Me.lblBankAccount)
            Me.grbCheckRegister.Controls.Add(Me.txtBankAccountCode)
            Me.grbCheckRegister.Controls.Add(Me.txtBankAccountName)
            Me.grbCheckRegister.Controls.Add(Me.btnAutoRun)
            Me.grbCheckRegister.Controls.Add(Me.lblStartCode)
            Me.grbCheckRegister.Controls.Add(Me.txtStartCode)
            Me.grbCheckRegister.Controls.Add(Me.lblEndCode)
            Me.grbCheckRegister.Controls.Add(Me.txtEndCode)
            Me.grbCheckRegister.Location = New System.Drawing.Point(8, 8)
            Me.grbCheckRegister.Name = "grbCheckRegister"
            Me.grbCheckRegister.Size = New System.Drawing.Size(536, 88)
            Me.grbCheckRegister.TabIndex = 0
            Me.grbCheckRegister.TabStop = False
            Me.grbCheckRegister.Text = "ทะเบียนเช็ค"
            '
            'btnBankAccountFind
            '
            Me.btnBankAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankAccountFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBankAccountFind.Image = CType(resources.GetObject("btnBankAccountFind.Image"), System.Drawing.Image)
            Me.btnBankAccountFind.Location = New System.Drawing.Point(496, 22)
            Me.btnBankAccountFind.Name = "btnBankAccountFind"
            Me.btnBankAccountFind.Size = New System.Drawing.Size(24, 23)
            Me.btnBankAccountFind.TabIndex = 6
            Me.btnBankAccountFind.TabStop = False
            Me.btnBankAccountFind.ThemedImage = CType(resources.GetObject("btnBankAccountFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblBankAccount
            '
            Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
            Me.lblBankAccount.Location = New System.Drawing.Point(16, 24)
            Me.lblBankAccount.Name = "lblBankAccount"
            Me.lblBankAccount.Size = New System.Drawing.Size(128, 18)
            Me.lblBankAccount.TabIndex = 4
            Me.lblBankAccount.Text = "สมุดเงินฝากธนาคาร:"
            Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBankAccountCode
            '
            Me.txtBankAccountCode.BackColor = System.Drawing.SystemColors.Window
            Me.txtBankAccountCode.Location = New System.Drawing.Point(144, 23)
            Me.txtBankAccountCode.Name = "txtBankAccountCode"
            Me.txtBankAccountCode.Size = New System.Drawing.Size(128, 20)
            Me.txtBankAccountCode.TabIndex = 0
            Me.txtBankAccountCode.Text = ""
            '
            'txtBankAccountName
            '
            Me.txtBankAccountName.BackColor = System.Drawing.SystemColors.Control
            Me.txtBankAccountName.Enabled = False
            Me.txtBankAccountName.Location = New System.Drawing.Point(272, 23)
            Me.txtBankAccountName.Name = "txtBankAccountName"
            Me.txtBankAccountName.ReadOnly = True
            Me.txtBankAccountName.Size = New System.Drawing.Size(224, 20)
            Me.txtBankAccountName.TabIndex = 5
            Me.txtBankAccountName.TabStop = False
            Me.txtBankAccountName.Text = ""
            '
            'btnAutoRun
            '
            Me.btnAutoRun.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAutoRun.Location = New System.Drawing.Point(376, 48)
            Me.btnAutoRun.Name = "btnAutoRun"
            Me.btnAutoRun.TabIndex = 3
            Me.btnAutoRun.Text = "Autorun"
            '
            'lblStartCode
            '
            Me.lblStartCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStartCode.ForeColor = System.Drawing.Color.Black
            Me.lblStartCode.Location = New System.Drawing.Point(56, 48)
            Me.lblStartCode.Name = "lblStartCode"
            Me.lblStartCode.Size = New System.Drawing.Size(88, 18)
            Me.lblStartCode.TabIndex = 7
            Me.lblStartCode.Text = "เลขที่เช็คตั้งแต่:"
            Me.lblStartCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtStartCode
            '
            Me.txtStartCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtStartCode.Location = New System.Drawing.Point(144, 48)
            Me.txtStartCode.Name = "txtStartCode"
            Me.txtStartCode.Size = New System.Drawing.Size(96, 22)
            Me.txtStartCode.TabIndex = 1
            Me.txtStartCode.Text = ""
            '
            'lblEndCode
            '
            Me.lblEndCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEndCode.ForeColor = System.Drawing.Color.Black
            Me.lblEndCode.Location = New System.Drawing.Point(240, 48)
            Me.lblEndCode.Name = "lblEndCode"
            Me.lblEndCode.Size = New System.Drawing.Size(32, 18)
            Me.lblEndCode.TabIndex = 8
            Me.lblEndCode.Text = "ถึง:"
            Me.lblEndCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEndCode
            '
            Me.txtEndCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtEndCode.Location = New System.Drawing.Point(272, 48)
            Me.txtEndCode.Name = "txtEndCode"
            Me.txtEndCode.Size = New System.Drawing.Size(96, 22)
            Me.txtEndCode.TabIndex = 2
            Me.txtEndCode.Text = ""
            '
            'CheckRunningView
            '
            Me.Controls.Add(Me.grbCheckRegister)
            Me.Name = "CheckRunningView"
            Me.Size = New System.Drawing.Size(552, 104)
            Me.grbCheckRegister.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_bankacct As New BankAccount
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()

            Me.SetLabelText()
        End Sub
#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()

        End Sub
#End Region

#Region "Properties"
        Public Property SelectedRow() As DataRow Implements IPreAddView.SelectedRow            Get                Return Nothing            End Get            Set(ByVal Value As DataRow)            End Set        End Property
        Private Property BankAccount() As BankAccount
            Get
                Return m_bankacct
            End Get
            Set(ByVal Value As BankAccount)
                m_bankacct = Value
            End Set
        End Property
#End Region

#Region "Methods"
        ' BankAccount
        Private Sub txtBankAccountCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBankAccountCode.Validated
            BankAccount.GetBankAccount(txtBankAccountCode, txtBankAccountName, Me.BankAccount)
        End Sub
        Private Sub btnBankAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAccountFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccounDialog)
        End Sub
        Private Sub SetBankAccounDialog(ByVal e As ISimpleEntity)
            Me.txtBankAccountCode.Text = e.Code
            BankAccount.GetBankAccount(txtBankAccountCode, txtBankAccountName, Me.BankAccount)
        End Sub
        Private Sub btnAutoRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoRun.Click
            OutgoingCheck.CreateChecks(Me.BankAccount, Me.txtStartCode.Text, Me.txtEndCode.Text, 1)
            Me.FindForm.DialogResult = DialogResult.Cancel
            Me.FindForm.Close()
        End Sub
#End Region

    End Class
End Namespace