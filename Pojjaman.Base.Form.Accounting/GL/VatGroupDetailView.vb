Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class VatGroupDetailView
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region "Members"
        Private m_entity As VatGroup
        Private m_isInitialized As Boolean = False
#End Region

#Region "Properties"

#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            UpdateEntityProperties()
            EventWiring()
            LoopControl(Me)
        End Sub
#End Region

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
        Friend WithEvents lblAltName As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtAltName As System.Windows.Forms.TextBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblParent As System.Windows.Forms.Label
        Friend WithEvents txtParent As System.Windows.Forms.TextBox
        Friend WithEvents chkControl As System.Windows.Forms.CheckBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VatGroupDetailView))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.chkControl = New System.Windows.Forms.CheckBox
            Me.lblParent = New System.Windows.Forms.Label
            Me.txtParent = New System.Windows.Forms.TextBox
            Me.lblAltName = New System.Windows.Forms.Label
            Me.txtAltName = New System.Windows.Forms.TextBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblName = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.chkAutorun)
            Me.grbDetail.Controls.Add(Me.txtNote)
            Me.grbDetail.Controls.Add(Me.lblNote)
            Me.grbDetail.Controls.Add(Me.chkControl)
            Me.grbDetail.Controls.Add(Me.lblParent)
            Me.grbDetail.Controls.Add(Me.txtParent)
            Me.grbDetail.Controls.Add(Me.lblAltName)
            Me.grbDetail.Controls.Add(Me.txtAltName)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(384, 184)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียด"
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(216, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 131
            '
            'txtNote
            '
            Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(128, 96)
            Me.txtNote.MaxLength = 1000
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtNote.Size = New System.Drawing.Size(248, 48)
            Me.txtNote.TabIndex = 130
            Me.txtNote.Text = ""
            Me.txtNote.WordWrap = False
            '
            'lblNote
            '
            Me.lblNote.Location = New System.Drawing.Point(16, 104)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(112, 20)
            Me.lblNote.TabIndex = 129
            Me.lblNote.Text = "หมายเหตุ"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkControl
            '
            Me.chkControl.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkControl.Location = New System.Drawing.Point(280, 25)
            Me.chkControl.Name = "chkControl"
            Me.chkControl.Size = New System.Drawing.Size(96, 20)
            Me.chkControl.TabIndex = 2
            Me.chkControl.Text = "เป็นบัญชีคุม"
            '
            'lblParent
            '
            Me.lblParent.Location = New System.Drawing.Point(8, 144)
            Me.lblParent.Name = "lblParent"
            Me.lblParent.Size = New System.Drawing.Size(120, 20)
            Me.lblParent.TabIndex = 127
            Me.lblParent.Text = "Under Group VAT:"
            Me.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtParent
            '
            Me.txtParent.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtParent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtParent, "")
            Me.Validator.SetGotFocusBackColor(Me.txtParent, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtParent, System.Drawing.Color.Empty)
            Me.txtParent.Location = New System.Drawing.Point(128, 144)
            Me.Validator.SetMaxValue(Me.txtParent, "")
            Me.Validator.SetMinValue(Me.txtParent, "")
            Me.txtParent.Name = "txtParent"
            Me.txtParent.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtParent, "")
            Me.Validator.SetRequired(Me.txtParent, False)
            Me.txtParent.Size = New System.Drawing.Size(248, 22)
            Me.txtParent.TabIndex = 5
            Me.txtParent.Text = ""
            '
            'lblAltName
            '
            Me.lblAltName.Location = New System.Drawing.Point(16, 72)
            Me.lblAltName.Name = "lblAltName"
            Me.lblAltName.Size = New System.Drawing.Size(112, 20)
            Me.lblAltName.TabIndex = 124
            Me.lblAltName.Text = "ชื่ออื่น:"
            Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAltName
            '
            Me.txtAltName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAltName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.txtAltName.Location = New System.Drawing.Point(128, 72)
            Me.Validator.SetMaxValue(Me.txtAltName, "")
            Me.Validator.SetMinValue(Me.txtAltName, "")
            Me.txtAltName.Name = "txtAltName"
            Me.Validator.SetRegularExpression(Me.txtAltName, "")
            Me.Validator.SetRequired(Me.txtAltName, False)
            Me.txtAltName.Size = New System.Drawing.Size(248, 22)
            Me.txtAltName.TabIndex = 4
            Me.txtAltName.Text = ""
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(128, 24)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(84, 22)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Location = New System.Drawing.Point(16, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(112, 20)
            Me.lblCode.TabIndex = 123
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Location = New System.Drawing.Point(16, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(112, 20)
            Me.lblName.TabIndex = 122
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(128, 48)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(248, 22)
            Me.txtName.TabIndex = 3
            Me.txtName.Text = ""
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            'VatGroupDetailView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "VatGroupDetailView"
            Me.Size = New System.Drawing.Size(400, 200)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Methods"

#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, VatGroup)
                Dim parentAcct As VatGroup = CType(Me.m_entity.Parent, VatGroup)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property


        Public Overrides Sub ClearDetail()
            Me.StatusBarService.SetMessage("")
            For Each ctrl As Control In Me.grbDetail.Controls
                If ctrl.Name.StartsWith("txt") Then
                    ctrl.Text = ""
                End If
            Next
            For Each ctrl As Control In Me.Controls
                If ctrl.Name.StartsWith("txt") Then
                    ctrl.Text = ""
                End If
            Next
            chkControl.Checked = False
        End Sub
        Public Overrides Sub Initialize()
        End Sub

        Public Overrides Sub SetLabelText()
            If Not Me.m_entity Is Nothing Then
                Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            End If
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupDetailView.lblCode}")
            Me.Validator.SetDisplayName(Me.txtCode, Me.lblCode.Text.TrimEnd(":".ToCharArray))
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupDetailView.lblName}")
            Me.Validator.SetDisplayName(Me.txtName, Me.lblName.Text.TrimEnd(":".ToCharArray))
            Me.lblAltName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupDetailView.lblAltName}")
            Me.Validator.SetDisplayName(Me.txtAltName, Me.lblAltName.Text.TrimEnd(":".ToCharArray))
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupDetailView.lblNote}")
            Me.Validator.SetDisplayName(Me.txtNote, Me.lblNote.Text.TrimEnd(":".ToCharArray))
            Me.lblParent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupDetailView.lblParent}")
            Me.Validator.SetDisplayName(Me.txtParent, Me.lblParent.Text.TrimEnd(":".ToCharArray))
            Me.chkControl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupDetailView.chkControl}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupDetailView.grbDetail}")
            Me.ToolTip1.SetToolTip(Me.chkAutorun, Me.StringParserService.Parse("${res:Global.chkAutorun}")) '"เลขที่อัตโนมัติ")
        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtAltName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
            AddHandler chkControl.CheckedChanged, AddressOf Me.ChangeProperty
        End Sub

        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            txtCode.Text = m_entity.Code
            txtName.Text = m_entity.Name
            txtAltName.Text = m_entity.AlternateName
            If Not m_entity.Parent Is Nothing AndAlso m_entity.Parent.Originated Then
                Me.txtParent.Text = m_entity.Parent.Name
            Else
                Me.txtParent.Text = Me.StringParserService.Parse("${res:Global.TreeRoot}")
            End If
            txtNote.Text = m_entity.Note
            If Me.m_entity.IsControlGroup Then
                chkControl.Checked = True
            Else
                chkControl.Checked = False
            End If
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                Case "txtname"
                    Me.m_entity.Name = txtName.Text
                Case "txtaltname"
                    Me.m_entity.AlternateName = txtAltName.Text
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                Case "chkcontrol"
                    Me.m_entity.IsControlGroup = chkControl.Checked
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            CheckFormEnable()
        End Sub
#End Region

#Region "Event"
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

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Overides"
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New VatGroup).DetailPanelIcon
            End Get
        End Property
#End Region

    End Class
End Namespace
