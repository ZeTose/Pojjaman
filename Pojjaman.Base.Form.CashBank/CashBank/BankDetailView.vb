Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class BankDetailView
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable, IReversibleEntityProperty

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
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.ForeColor = System.Drawing.Color.Blue
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(392, 80)
            Me.grbDetail.TabIndex = 3
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลธนาคาร : "
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(64, 48)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(312, 22)
            Me.txtName.TabIndex = 12
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(16, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(48, 18)
            Me.lblName.TabIndex = 11
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(48, 18)
            Me.lblCode.TabIndex = 7
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(64, 24)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(112, 22)
            Me.txtCode.TabIndex = 10
            Me.txtCode.Text = ""
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.ErrorProvider = Nothing
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'BankDetailView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "BankDetailView"
            Me.Size = New System.Drawing.Size(408, 96)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Member"
        Private m_Bank As New Bank
        Private m_owner As IListPanel
        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            UpdateEntityProperties()
            EventWiring()
        End Sub
#End Region

#Region "Method"

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
        End Sub

#End Region

#Region "IListDetail"

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()

        End Sub

        ' เคลียร์ข้อมูลใน control
        Public Overrides Sub ClearDetail()
            txtCode.Text = ""
            txtName.Text = ""
        End Sub

        Public Overrides Sub SetLabelText()
            If Not Me.m_Bank Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_Bank.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankDetail.lblCode}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankDetail.lblName}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankDetail.grbDetail}")
        End Sub

        ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()

            If m_Bank Is Nothing Then
                Return
            End If

            ' ทำการผูก Property ต่าง ๆ เข้ากับ control
            With Me
                .txtCode.Text = .m_Bank.Code
                .txtName.Text = .m_Bank.Name
            End With

            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub

        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_Bank Is Nothing Or Not m_isInitialized Then
                Return
            End If

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_Bank.Code = Me.txtCode.Text
                Case "txtname"
                    Me.m_Bank.Name = Me.txtName.Text
            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = True

        End Sub

        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_Bank
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_Bank = CType(Value, Bank)
                'Me.m_Bank.OnTabPageTextChanged(m_Bank, EventArgs.Empty)
                UpdateEntityProperties()
                EventWiring()
            End Set
        End Property

        Public Overrides Sub Initialize()

        End Sub

#End Region

#Region "IReversibleEntityProperty"
        Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties

        End Sub

        Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties

        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

        Private Sub BankDetailView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
            AddHandler Me.WorkbenchWindow.ViewContent.Saved, AddressOf EntitySaved
            AddHandler Me.WorkbenchWindow.ViewContent.Saving, AddressOf EntitySaving
        End Sub

        Private Sub EntitySaving(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

        End Sub

    End Class

End Namespace
