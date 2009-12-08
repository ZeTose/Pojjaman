Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Namespace Longkong.Pojjaman.Gui.Panels

    Public Class BOQOptionsView
        Inherits AbstractEntityDetailPanelView
        Implements IReversibleEntityProperty

#Region "Member"
        Private m_entity As BOQ
        Private m_isInitialized As Boolean = False
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
        Friend WithEvents PrimaryGroupBoxControl As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents pgLevelProp As System.Windows.Forms.PropertyGrid
        Friend WithEvents lsbLevel As System.Windows.Forms.ListBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.PrimaryGroupBoxControl = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lsbLevel = New System.Windows.Forms.ListBox
            Me.pgLevelProp = New System.Windows.Forms.PropertyGrid
            Me.btnOk = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.PrimaryGroupBoxControl.SuspendLayout()
            Me.SuspendLayout()
            '
            'PrimaryGroupBoxControl
            '
            Me.PrimaryGroupBoxControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.lsbLevel)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.pgLevelProp)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnOk)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnCancel)
            Me.PrimaryGroupBoxControl.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.PrimaryGroupBoxControl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.PrimaryGroupBoxControl.ForeColor = System.Drawing.Color.Blue
            Me.PrimaryGroupBoxControl.Location = New System.Drawing.Point(8, 8)
            Me.PrimaryGroupBoxControl.Name = "PrimaryGroupBoxControl"
            Me.PrimaryGroupBoxControl.Size = New System.Drawing.Size(568, 320)
            Me.PrimaryGroupBoxControl.TabIndex = 0
            Me.PrimaryGroupBoxControl.TabStop = False
            Me.PrimaryGroupBoxControl.Text = "ข้อมูลหลัก"
            '
            'lsbLevel
            '
            Me.lsbLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.lsbLevel.ItemHeight = 24
            Me.lsbLevel.Location = New System.Drawing.Point(8, 24)
            Me.lsbLevel.Name = "lsbLevel"
            Me.lsbLevel.Size = New System.Drawing.Size(272, 268)
            Me.lsbLevel.TabIndex = 11
            '
            'pgLevelProp
            '
            Me.pgLevelProp.CommandsForeColor = System.Drawing.Color.Blue
            Me.pgLevelProp.CommandsVisibleIfAvailable = True
            Me.pgLevelProp.LargeButtons = False
            Me.pgLevelProp.LineColor = System.Drawing.SystemColors.ScrollBar
            Me.pgLevelProp.Location = New System.Drawing.Point(288, 24)
            Me.pgLevelProp.Name = "pgLevelProp"
            Me.pgLevelProp.Size = New System.Drawing.Size(272, 264)
            Me.pgLevelProp.TabIndex = 10
            Me.pgLevelProp.Text = "PropertyGrid1"
            Me.pgLevelProp.ViewBackColor = System.Drawing.SystemColors.Window
            Me.pgLevelProp.ViewForeColor = System.Drawing.SystemColors.WindowText
            '
            'btnOk
            '
            Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnOk.ForeColor = System.Drawing.Color.Black
            Me.btnOk.Location = New System.Drawing.Point(352, 288)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(96, 24)
            Me.btnOk.TabIndex = 9
            Me.btnOk.Text = "OK"
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(456, 288)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 24)
            Me.btnCancel.TabIndex = 0
            Me.btnCancel.Text = "Cancel"
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
            'BOQOptionsView
            '
            Me.Controls.Add(Me.PrimaryGroupBoxControl)
            Me.Name = "BOQOptionsView"
            Me.Size = New System.Drawing.Size(584, 344)
            Me.PrimaryGroupBoxControl.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.btnOk.Text = Me.StringParserService.Parse("${res:Global.OKButtonText}")
            Me.btnCancel.Text = Me.StringParserService.Parse("${res:Global.CancelButtonText}")
        End Sub
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            EventWiring()
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"

#End Region

#Region "IListDetail"

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()

        End Sub

        ' เคลียร์ข้อมูลลูกค้าใน control
        Public Overrides Sub ClearDetail()
            For Each ctrl As Control In PrimaryGroupBoxControl.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

        End Sub

        Protected Overrides Sub EventWiring()

        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            Dim list As ArrayList = m_entity.LevelConfigs
            For Each lvcfg As LevelConfig In list
                Me.lsbLevel.Items.Add(lvcfg)
            Next


            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If

            Try
                Select Case CType(sender, Control).Name.ToLower

                End Select
            Catch ex As Exception

            End Try
            'Hack
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = True

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not m_entity Is Nothing Then
                    Me.m_entity.Dispose()
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, BOQ)
                Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
                Me.SaveProperties()
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()
            Dim propService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim culture As String = propService.GetProperty("CoreProperties.UILanguage", "th")
            culture = culture & "-" & culture.ToUpper
            'Me.DateTimeService.ListDaysInComboBox(Me.cmbBillrecDay, False, culture)
            'Me.DateTimeService.ListDaysInComboBox(Me.cmbReceiveDay, False, culture)

            'Me.cmbCreditType.DataSource = CodeDescription.GetCodeList("credit_type")
            'Me.cmbCreditType.DisplayMember = "code_description"
            'Me.cmbCreditType.ValueMember = "code_value"
        End Sub

#End Region

#Region "Event Handlers"

#End Region

#Region "IReversibleEntityProperty"
#Region "Members"
        Private m_oldStatusIsDirty As Boolean
#End Region
        Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = m_oldStatusIsDirty
        End Sub
        Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            m_oldStatusIsDirty = myContent.IsDirty
        End Sub
#End Region

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Private Sub lsbLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsbLevel.SelectedIndexChanged
            Me.pgLevelProp.SelectedObject = lsbLevel.SelectedItem
        End Sub

        Private Sub lsbLevel_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lsbLevel.DrawItem
            Dim rect As Rectangle = e.Bounds

            If CBool(e.State And DrawItemState.Selected) Then
                e.Graphics.FillRectangle(SystemBrushes.Highlight, rect)
            Else
                e.Graphics.FillRectangle(SystemBrushes.Window, rect)
            End If
            Dim lvcfg As LevelConfig = CType(Me.lsbLevel.Items(e.Index), LevelConfig)
            Dim b As New SolidBrush(lvcfg.BackColor)
            rect.Inflate(-16, -2)
            e.Graphics.FillRectangle(b, rect)
            Dim p As New Pen(lvcfg.BorderColor)
            Select Case lvcfg.LevelLineStyle
                Case LevelConfig.LineStyle.Double
                    e.Graphics.DrawLine(p, rect.X, rect.Y + rect.Height - 3, rect.X + rect.Width, rect.Y + rect.Height - 3)
                Case LevelConfig.LineStyle.Solid
            End Select
            p.Width = lvcfg.PenWidth
            e.Graphics.DrawRectangle(p, rect)

            Dim b2 As New SolidBrush(lvcfg.ForeColor)
            e.Graphics.DrawString(lvcfg.ToString, lvcfg.Font, b2, rect.X + 4, rect.Y + 2)

            b.Dispose()
            b2.Dispose()
        End Sub
    End Class

End Namespace
'Todo: เพิ่ม CheckListBox