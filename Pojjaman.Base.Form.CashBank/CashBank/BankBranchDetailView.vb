Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class BankBranchDetailView
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

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
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
        Friend WithEvents txtBankName As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents lblBank As System.Windows.Forms.Label
        Friend WithEvents btnBankFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnBankEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BankBranchDetailView))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.btnBankFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnBankEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtBankCode = New System.Windows.Forms.TextBox
            Me.txtBankName = New System.Windows.Forms.TextBox
            Me.lblBank = New System.Windows.Forms.Label
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.chkAutorun)
            Me.grbDetail.Controls.Add(Me.btnBankFind)
            Me.grbDetail.Controls.Add(Me.btnBankEdit)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.txtBankCode)
            Me.grbDetail.Controls.Add(Me.txtBankName)
            Me.grbDetail.Controls.Add(Me.lblBank)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.ForeColor = System.Drawing.Color.Blue
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(568, 128)
            Me.grbDetail.TabIndex = 3
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลธนาคาร/สาขา : "
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(248, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 328
            Me.chkAutorun.TabStop = False
            '
            'btnBankFind
            '
            Me.btnBankFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBankFind.Image = CType(resources.GetObject("btnBankFind.Image"), System.Drawing.Image)
            Me.btnBankFind.Location = New System.Drawing.Point(456, 72)
            Me.btnBankFind.Name = "btnBankFind"
            Me.btnBankFind.Size = New System.Drawing.Size(24, 23)
            Me.btnBankFind.TabIndex = 210
            Me.btnBankFind.TabStop = False
            Me.btnBankFind.ThemedImage = CType(resources.GetObject("btnBankFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnBankEdit
            '
            Me.btnBankEdit.Image = CType(resources.GetObject("btnBankEdit.Image"), System.Drawing.Image)
            Me.btnBankEdit.Location = New System.Drawing.Point(480, 72)
            Me.btnBankEdit.Name = "btnBankEdit"
            Me.btnBankEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnBankEdit.TabIndex = 209
            Me.btnBankEdit.ThemedImage = CType(resources.GetObject("btnBankEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(128, 48)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(328, 21)
            Me.txtName.TabIndex = 2
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(112, 18)
            Me.lblName.TabIndex = 11
            Me.lblName.Text = "ชื่อสาขา:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(112, 18)
            Me.lblCode.TabIndex = 7
            Me.lblCode.Text = "รหัสสาขา:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(128, 24)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(120, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'txtBankCode
            '
            Me.Validator.SetDataType(Me.txtBankCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankCode, "")
            Me.txtBankCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBankCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBankCode, System.Drawing.Color.Empty)
            Me.txtBankCode.Location = New System.Drawing.Point(128, 72)
            Me.Validator.SetMaxValue(Me.txtBankCode, "")
            Me.Validator.SetMinValue(Me.txtBankCode, "")
            Me.txtBankCode.Name = "txtBankCode"
            Me.Validator.SetRegularExpression(Me.txtBankCode, "")
            Me.Validator.SetRequired(Me.txtBankCode, True)
            Me.txtBankCode.Size = New System.Drawing.Size(120, 21)
            Me.txtBankCode.TabIndex = 3
            Me.txtBankCode.Text = ""
            '
            'txtBankName
            '
            Me.Validator.SetDataType(Me.txtBankName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankName, "")
            Me.txtBankName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBankName, System.Drawing.Color.Empty)
            Me.txtBankName.Location = New System.Drawing.Point(248, 72)
            Me.Validator.SetMaxValue(Me.txtBankName, "")
            Me.Validator.SetMinValue(Me.txtBankName, "")
            Me.txtBankName.Name = "txtBankName"
            Me.txtBankName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankName, "")
            Me.Validator.SetRequired(Me.txtBankName, False)
            Me.txtBankName.Size = New System.Drawing.Size(208, 21)
            Me.txtBankName.TabIndex = 4
            Me.txtBankName.Text = ""
            '
            'lblBank
            '
            Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBank.ForeColor = System.Drawing.Color.Black
            Me.lblBank.Location = New System.Drawing.Point(8, 72)
            Me.lblBank.Name = "lblBank"
            Me.lblBank.Size = New System.Drawing.Size(112, 18)
            Me.lblBank.TabIndex = 11
            Me.lblBank.Text = "ธนคาร:"
            Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Me.ErrorProvider1
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'BankBranchDetailView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "BankBranchDetailView"
            Me.Size = New System.Drawing.Size(584, 144)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankBranchDetailView.lblName}")
            Me.Validator.SetDisplayName(txtName, lblName.Text)

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankBranchDetailView.lblCode}")
            Me.Validator.SetDisplayName(txtCode, lblCode.Text)

            Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankBranchDetailView.lblBank}")
            Me.Validator.SetDisplayName(txtBankCode, lblBank.Text)

            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankBranchDetailView.grbDetail}")
        End Sub
#End Region

#Region "Member"
        Private m_entity As New BankBranch
        Private m_owner As IListPanel
        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Initialize()
            SetLabelText()
            UpdateEntityProperties()
            EventWiring()
        End Sub
#End Region

#Region "Method"

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtBankCode.Validated, AddressOf Me.ChangeProperty
        End Sub

#End Region

#Region "IListDetail"
        Public Overrides Sub Initialize()

        End Sub

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()

        End Sub

        ' เคลียร์ข้อมูลใน control
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In grbDetail.Controls
                If TypeOf crlt Is TextBox Then
                    crlt.Text = ""
                End If
            Next
        End Sub

        ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            ' ทำการผูก Property ต่าง ๆ เข้ากับ control
            With Me
                .txtCode.Text = .m_entity.Code
                .txtName.Text = .m_entity.Name
                ' autogencode 
                m_oldCode = m_entity.Code
                Me.chkAutorun.Checked = Me.m_entity.AutoGen
                Me.UpdateAutogenStatus()

                If Not Me.m_entity.Bank Is Nothing Then
                    .txtBankCode.Text = Me.m_entity.Bank.Code
                    .txtBankName.Text = Me.m_entity.Bank.Name
                End If
            End With

            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub

        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    dirtyFlag = True
                    Me.m_entity.Code = Me.txtCode.Text
                Case "txtname"
                    dirtyFlag = True
                    Me.m_entity.Name = Me.txtName.Text
                Case "txtbankcode"
                    dirtyFlag = Bank.GetBank(txtBankCode, txtBankName, Me.m_entity.Bank)
            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

        End Sub

        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = CType(Value, BankBranch)
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
                EventWiring()
            End Set
        End Property

#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Overrides"
       
#End Region

#Region "Event of Button controls"
        ' Bank
        Private Sub btnBankEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Bank)
        End Sub
        Private Sub btnBankFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Bank, AddressOf SetBankDialog)
        End Sub
        Private Sub SetBankDialog(ByVal e As ISimpleEntity)
            Me.txtBankCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Bank.GetBank(txtBankCode, txtBankName, Me.m_entity.Bank)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Bank).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtbankcode", "txtbankname"
                                Return True
                        End Select
                    End If
                End If
                Return False
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New BankAccount).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New BankAccount).FullClassName))
                Dim entity As New BankAccount(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtbankcode", "txtbankname"
                            Me.SetBankDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Autogencode "
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_oldCode As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
                Me.Validator.SetRequired(Me.txtCode, False)
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.txtCode.ReadOnly = True
                m_oldCode = Me.txtCode.Text
                Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
                'Hack: set Code เป็น "" เอง
                Me.m_entity.Code = ""
                Me.m_entity.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtCode, True)
                Me.txtCode.Text = m_oldCode
                Me.txtCode.ReadOnly = False
                Me.m_entity.AutoGen = False
            End If
        End Sub
#End Region

    End Class

End Namespace
