Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MapDialog
        Inherits AbstractEntityDetailPanelView
        Implements IReversibleEntityProperty

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
        Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents picMap As System.Windows.Forms.PictureBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnOK As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.picMap = New System.Windows.Forms.PictureBox
            Me.btnCancel = New System.Windows.Forms.Button
            Me.btnOK = New System.Windows.Forms.Button
            Me.grbMap.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMap
            '
            Me.grbMap.Controls.Add(Me.picMap)
            Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMap.Location = New System.Drawing.Point(8, 8)
            Me.grbMap.Name = "grbMap"
            Me.grbMap.Size = New System.Drawing.Size(464, 304)
            Me.grbMap.TabIndex = 0
            Me.grbMap.TabStop = False
            Me.grbMap.Text = "grbMap"
            '
            'picMap
            '
            Me.picMap.Location = New System.Drawing.Point(8, 16)
            Me.picMap.Name = "picMap"
            Me.picMap.Size = New System.Drawing.Size(144, 120)
            Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.picMap.TabIndex = 0
            Me.picMap.TabStop = False
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(376, 320)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 23)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "btnCancel"
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnOK.ForeColor = System.Drawing.Color.Black
            Me.btnOK.Location = New System.Drawing.Point(272, 320)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(96, 23)
            Me.btnOK.TabIndex = 1
            Me.btnOK.Text = "btnOK"
            '
            'MapDialog
            '
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.grbMap)
            Me.Name = "MapDialog"
            Me.Size = New System.Drawing.Size(480, 360)
            Me.grbMap.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As ISimpleEntity
        Private m_previousPanel As UserControl
        Private m_locatableEntity As ILocatable
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            m_locatableEntity = CType(Entity, ILocatable)
        End Sub
        Public Sub New(ByVal entity As ISimpleEntity)
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            Me.Entity = entity
        End Sub
        Public Sub New(ByVal entity As ISimpleEntity, ByVal prevPanel As UserControl)
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            Me.Entity = entity
            Me.m_previousPanel = prevPanel
        End Sub
#End Region

#Region "Properties"
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Value
                m_locatableEntity = CType(m_entity, ILocatable)
                SaveProperties()
                Me.picMap.Image = m_locatableEntity.Map
                SetLabelText()
                'UpdateEntityProperties()
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Sub CheckFormEnable()

        End Sub
        Public Overrides Sub ClearDetail()

        End Sub
        Public Overrides Sub SetLabelText()
            If Not Me.m_entity Is Nothing Then
                Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            End If
            Me.btnCancel.Text = Me.StringParserService.Parse("${res:Global.CancelButtonText}")
            Me.btnOK.Text = Me.StringParserService.Parse("${res:Global.OKButtonText}")
            Me.grbMap.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MapDialog.grbMap}")
        End Sub
        Public Overrides Sub UpdateEntityProperties()
            'ClearDetail()
            'If Me.m_entity Is Nothing OrElse Not TypeOf m_entity Is ILocatable Then
            '    Return
            'End If
            'Dim entityWithMap As ILocatable = CType(Me.m_entity, ILocatable)
            'If Not entityWithMap.Map Is Nothing Then
            '    Me.picMap.Image = entityWithMap.Map
            'End If
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub picMap_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles picMap.Resize
            'Me.grbMap.ClientSize = New Size(picMap.ClientSize.Width + 10, picMap.ClientSize.Height + 15)
            'Me.ClientSize = New Size(grbMap.ClientSize.Width + 30, grbMap.ClientSize.Height + 58)
        End Sub
#End Region

#Region "PinPoint"
        Private Sub picMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picMap.Paint
            Dim g As Graphics = e.Graphics
            Dim pn As New Pen(Color.Red, 3)
            Dim top As Integer = Me.m_locatableEntity.MapPosition.Y - 10
            If top < 0 Then top = 0
            Dim left As Integer = Me.m_locatableEntity.MapPosition.X - 10
            If left < 0 Then left = 0
            Dim bottom As Integer = Me.m_locatableEntity.MapPosition.Y + 10
            If bottom > picMap.Height Then bottom = picMap.Height
            Dim right As Integer = Me.m_locatableEntity.MapPosition.X + 10
            If right > picMap.Width Then right = picMap.Width
            g.DrawLine(pn, left, top, right, bottom)
            g.DrawLine(pn, right, top, left, bottom)
            pn.Dispose()

            'Todo:
            Me.grbMap.ClientSize = New Size(picMap.ClientSize.Width + 10, picMap.ClientSize.Height + 15)
            Me.ClientSize = New Size(grbMap.ClientSize.Width + 30, grbMap.ClientSize.Height + 58)
        End Sub
        Private m_Ticks As Long
        Private m_canDrag As Boolean = False
        Const TICKS_OFFSET As Long = 0
        Private Sub picMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseMove
            Dim ts As New TimeSpan(Now.Ticks - m_Ticks)
            If m_canDrag And e.Button = MouseButtons.Left And ts.TotalMilliseconds > TICKS_OFFSET Then
                If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
                    Me.m_locatableEntity.MapPosition = New Point(e.X, e.Y)
                    picMap.Invalidate()
                    m_Ticks = Now.Ticks
                End If
            End If
        End Sub
        Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseDown
            'Dim top As Integer = Me.m_locatableEntity.MapPosition.Y - 10
            'If top < 0 Then top = 0
            'Dim left As Integer = Me.m_locatableEntity.MapPosition.X - 10
            'If left < 0 Then left = 0
            'Dim bottom As Integer = Me.m_locatableEntity.MapPosition.Y + 10
            'If bottom > picMap.Height Then bottom = picMap.Height
            'Dim right As Integer = Me.m_locatableEntity.MapPosition.X + 10
            'If right > picMap.Width Then right = picMap.Width

            'Dim xBounds As New Rectangle(left, top, 20, 20)
            'If xBounds.Contains(New Point(e.X, e.Y)) Then
            '    m_canDrag = True
            'End If

            m_canDrag = True
            If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
                Me.m_locatableEntity.MapPosition = New Point(e.X, e.Y)
                picMap.Invalidate()
                'Hack
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
        End Sub
        Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseUp
            If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
                Me.m_locatableEntity.MapPosition = New Point(e.X, e.Y)
                'Hack
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
            m_canDrag = False
        End Sub
#End Region

#Region "IReversibleEntityProperty"
        Private m_oldDirtyState As Boolean = False
        Private m_oldPosition As Point
        Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = m_oldDirtyState
            Me.m_locatableEntity.MapPosition = Me.m_oldPosition
        End Sub

        Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            m_oldDirtyState = myContent.IsDirty
            m_oldPosition = Me.m_locatableEntity.MapPosition
        End Sub
#End Region

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            RevertProperties()
        End Sub
    End Class
End Namespace

