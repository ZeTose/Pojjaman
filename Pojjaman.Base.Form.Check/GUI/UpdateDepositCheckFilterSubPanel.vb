Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class UpdateDepositCheckFilterSubPanel
        Inherits AbstractFilterSubPanel

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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents txtCqcode As System.Windows.Forms.TextBox
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtBankAcctName As System.Windows.Forms.TextBox
        Friend WithEvents lblBankAcct As System.Windows.Forms.Label
        Friend WithEvents btnBankAcctFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtBankAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCqcode As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UpdateDepositCheckFilterSubPanel))
            Me.lblCqcode = New System.Windows.Forms.Label
            Me.txtCqcode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.txtBankAcctName = New System.Windows.Forms.TextBox
            Me.lblBankAcct = New System.Windows.Forms.Label
            Me.btnBankAcctFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtBankAcctCode = New System.Windows.Forms.TextBox
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCqcode
            '
            Me.lblCqcode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCqcode.ForeColor = System.Drawing.Color.Black
            Me.lblCqcode.Location = New System.Drawing.Point(8, 48)
            Me.lblCqcode.Name = "lblCqcode"
            Me.lblCqcode.Size = New System.Drawing.Size(104, 18)
            Me.lblCqcode.TabIndex = 2
            Me.lblCqcode.Text = "เลขที่เช็ค:"
            Me.lblCqcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCqcode
            '
            Me.txtCqcode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCqcode.Location = New System.Drawing.Point(120, 48)
            Me.txtCqcode.Name = "txtCqcode"
            Me.txtCqcode.Size = New System.Drawing.Size(272, 21)
            Me.txtCqcode.TabIndex = 3
            Me.txtCqcode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 25)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCode.Location = New System.Drawing.Point(120, 24)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(272, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.txtCqcode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.lblCqcode)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.txtBankAcctName)
            Me.grbDetail.Controls.Add(Me.lblBankAcct)
            Me.grbDetail.Controls.Add(Me.btnBankAcctFind)
            Me.grbDetail.Controls.Add(Me.txtBankAcctCode)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(696, 128)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "เช็คจ่าย"
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(432, 16)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(248, 72)
            Me.grbDocDate.TabIndex = 18
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "วันที่เอกสาร"
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 17)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 40)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateEnd.TabIndex = 2
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(72, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(144, 21)
            Me.dtpDocDateStart.TabIndex = 1
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(72, 40)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(144, 21)
            Me.dtpDocDateEnd.TabIndex = 3
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(608, 96)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 20
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(520, 96)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 19
            Me.btnReset.Text = "เคลียร์"
            '
            'txtBankAcctName
            '
            Me.txtBankAcctName.BackColor = System.Drawing.SystemColors.Control
            Me.txtBankAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtBankAcctName.Location = New System.Drawing.Point(208, 72)
            Me.txtBankAcctName.Name = "txtBankAcctName"
            Me.txtBankAcctName.ReadOnly = True
            Me.txtBankAcctName.Size = New System.Drawing.Size(160, 21)
            Me.txtBankAcctName.TabIndex = 15
            Me.txtBankAcctName.Text = ""
            '
            'lblBankAcct
            '
            Me.lblBankAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankAcct.ForeColor = System.Drawing.Color.Black
            Me.lblBankAcct.Location = New System.Drawing.Point(8, 72)
            Me.lblBankAcct.Name = "lblBankAcct"
            Me.lblBankAcct.Size = New System.Drawing.Size(104, 18)
            Me.lblBankAcct.TabIndex = 13
            Me.lblBankAcct.Text = "สมุดบัญชี:"
            Me.lblBankAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnBankAcctFind
            '
            Me.btnBankAcctFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankAcctFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBankAcctFind.Image = CType(resources.GetObject("btnBankAcctFind.Image"), System.Drawing.Image)
            Me.btnBankAcctFind.Location = New System.Drawing.Point(368, 72)
            Me.btnBankAcctFind.Name = "btnBankAcctFind"
            Me.btnBankAcctFind.Size = New System.Drawing.Size(24, 23)
            Me.btnBankAcctFind.TabIndex = 16
            Me.btnBankAcctFind.TabStop = False
            Me.btnBankAcctFind.ThemedImage = CType(resources.GetObject("btnBankAcctFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtBankAcctCode
            '
            Me.txtBankAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtBankAcctCode.Location = New System.Drawing.Point(120, 72)
            Me.txtBankAcctCode.Name = "txtBankAcctCode"
            Me.txtBankAcctCode.Size = New System.Drawing.Size(88, 21)
            Me.txtBankAcctCode.TabIndex = 14
            Me.txtBankAcctCode.Text = ""
            '
            'UpdateDepositCheckFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "UpdateDepositCheckFilterSubPanel"
            Me.Size = New System.Drawing.Size(704, 144)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Member"
        Private m_bankacct As New BankAccount

        Private m_includeref As Boolean = True
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()

            SetLabelText()
            LoopControl(Me)

        End Sub
#End Region

#Region "Properties"
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
        Private Sub Initialize()
            ' clear item
            ClearCriterias()
        End Sub

        Private Sub ClearCriterias()
            For Each ctrl As Control In grbDetail.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

            Me.BankAccount = New BankAccount

            Me.dtpDocDateStart.Value = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.dtpDocDateEnd.Value = Date.Now

            EntityRefresh()
        End Sub

        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(4) As Filter
            arr(0) = New Filter("code", IIf(txtCode.TextLength = 0, DBNull.Value, txtCode.Text))
            arr(1) = New Filter("cqcode", IIf(txtCqcode.Text.Length = 0, DBNull.Value, txtCqcode.Text))
            arr(2) = New Filter("bankaccount", IIf(Me.BankAccount.Originated, Me.BankAccount.Id, DBNull.Value))
            arr(3) = New Filter("startdate ", dtpDocDateStart.Value)
            arr(4) = New Filter("enddate", dtpDocDateEnd.Value)

            Return arr
        End Function

        Public Property IncludeRef() As Boolean
            Get
                Return m_includeref
            End Get
            Set(ByVal Value As Boolean)
                m_includeref = Value
            End Set
        End Property

        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
        ' BankAccount
        Private Sub txtBankAcctCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBankAcctCode.Validated
            BankAccount.GetBankAccount(txtBankAcctCode, txtBankAcctName, Me.BankAccount)
        End Sub
        Private Sub btnBankAcctFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAcctFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccounDialog)
        End Sub
        Private Sub SetBankAccounDialog(ByVal e As ISimpleEntity)
            Me.txtBankAcctCode.Text = e.Code
            BankAccount.GetBankAccount(txtBankAcctCode, txtBankAcctName, Me.BankAccount)
        End Sub

#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New BankAccount).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtbankacctcode", "txtbankacctname"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New BankAccount).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New BankAccount).FullClassName))
                Dim entity As New BankAccount(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtbankacctcode", "txtbankacctname"
                            Me.SetBankAccounDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region "SetLabelText"
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckFilterSubPanel.grbDocDate}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckFilterSubPanel.lblDocDateEnd}")
            Me.lblBankAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckFilterSubPanel.lblBankAcct}")
            Me.lblCqcode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UpdateDepositCheckFilterSubPanel.lblCqcode}")
        End Sub
        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                EntityRefresh()
            End Set
        End Property
        Private Sub EntityRefresh()
            If Entities Is Nothing Then
                Return
            End If
            For Each entity As ISimpleEntity In Entities

                If TypeOf entity Is UpdateCheckDeposit Then
                    ' set me.Includeref
                    Me.IncludeRef = False

                    Dim obj As UpdateCheckDeposit = CType(entity, UpdateCheckDeposit)
                    ' BankAcct
                    If obj.BankAccount.Originated Then
                        Me.SetBankAccounDialog(obj.BankAccount)
                        Me.txtBankAcctCode.Enabled = False
                        Me.txtBankAcctName.Enabled = False
                        Me.btnBankAcctFind.Enabled = False
                    End If
                End If

            Next
        End Sub
#End Region

    End Class
End Namespace

