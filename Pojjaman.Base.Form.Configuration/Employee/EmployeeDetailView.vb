Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class EmployeeDetailView
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
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents picImage As System.Windows.Forms.PictureBox
        Friend WithEvents btnLoadImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnClearImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblPicSize As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EmployeeDetailView))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnLoadImage = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnClearImage = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.picImage = New System.Windows.Forms.PictureBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.lblPicSize = New System.Windows.Forms.Label
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.lblPicSize)
            Me.grbDetail.Controls.Add(Me.btnLoadImage)
            Me.grbDetail.Controls.Add(Me.btnClearImage)
            Me.grbDetail.Controls.Add(Me.picImage)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.ForeColor = System.Drawing.Color.Blue
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(536, 184)
            Me.grbDetail.TabIndex = 6
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูล Employee:"
            '
            'btnLoadImage
            '
            Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLoadImage.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLoadImage.Image = CType(resources.GetObject("btnLoadImage.Image"), System.Drawing.Image)
            Me.btnLoadImage.Location = New System.Drawing.Point(472, 150)
            Me.btnLoadImage.Name = "btnLoadImage"
            Me.btnLoadImage.Size = New System.Drawing.Size(24, 23)
            Me.btnLoadImage.TabIndex = 25
            Me.btnLoadImage.TabStop = False
            Me.btnLoadImage.ThemedImage = CType(resources.GetObject("btnLoadImage.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnClearImage
            '
            Me.btnClearImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnClearImage.Image = CType(resources.GetObject("btnClearImage.Image"), System.Drawing.Image)
            Me.btnClearImage.Location = New System.Drawing.Point(496, 150)
            Me.btnClearImage.Name = "btnClearImage"
            Me.btnClearImage.Size = New System.Drawing.Size(24, 23)
            Me.btnClearImage.TabIndex = 26
            Me.btnClearImage.TabStop = False
            Me.btnClearImage.ThemedImage = CType(resources.GetObject("btnClearImage.ThemedImage"), System.Drawing.Bitmap)
            '
            'picImage
            '
            Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.picImage.Location = New System.Drawing.Point(400, 24)
            Me.picImage.Name = "picImage"
            Me.picImage.Size = New System.Drawing.Size(120, 120)
            Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.picImage.TabIndex = 12
            Me.picImage.TabStop = False
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(64, 56)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(320, 22)
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(16, 56)
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
            Me.lblCode.Location = New System.Drawing.Point(16, 32)
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
            Me.txtCode.Location = New System.Drawing.Point(64, 32)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(112, 22)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
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
            'lblPicSize
            '
            Me.lblPicSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPicSize.Location = New System.Drawing.Point(410, 72)
            Me.lblPicSize.Name = "lblPicSize"
            Me.lblPicSize.TabIndex = 203
            Me.lblPicSize.Text = "120 X 120 pixel"
            Me.lblPicSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'EmployeeDetailView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "EmployeeDetailView"
            Me.Size = New System.Drawing.Size(552, 200)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Member"
        Private m_entity As New Employee
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
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EmployeeDetail.lblCode}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EmployeeDetail.grbDetail}")
        End Sub

        ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()

            If m_entity Is Nothing Then
                Return
            End If

            m_entity.LoadImage()
            ' ทำการผูก Property ต่าง ๆ ของเข้ากับ control
            With Me
                .txtCode.Text = .m_entity.Code
                .txtName.Text = .m_entity.Name
                picImage.Image = Me.m_entity.Image
                CheckLabelImgSize()
            End With

            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True

        End Sub

        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = CType(Value, Employee)
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()

        End Sub

        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If

            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = Me.txtCode.Text
                    dirtyFlag = True
                Case "txtname"
                    Me.m_entity.Name = Me.txtName.Text
                    dirtyFlag = True
            End Select

            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

        End Sub

#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadImage.Click
            Dim dlg As New OpenFileDialog
            Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
            dlg.Filter = String.Join("|", fileFilters)
            If dlg.ShowDialog = DialogResult.OK Then
                Dim img As Image = Image.FromFile(dlg.FileName)
                If img.Size.Height > Me.picImage.Height OrElse img.Size.Width >= Me.picImage.Width Then
                    Dim percent As Decimal = 100 * (Math.Min(Me.picImage.Height / img.Size.Height, Me.picImage.Width / img.Size.Width))
                    img = ImageHelper.Resize(img, percent)
                End If
                Me.picImage.Image = img
                m_entity.Image = img
                'Hack
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
                CheckLabelImgSize()
            End If
        End Sub
#End Region

        Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearImage.Click
            m_entity.Image = Nothing
            Me.picImage.Image = Nothing
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = True
            CheckLabelImgSize()
        End Sub
        Private Sub CheckLabelImgSize()
            Me.lblPicSize.Text = "120 X 120 pixel"
            If Me.m_entity.Image Is Nothing Then
                Me.lblPicSize.Visible = True
            Else
                Me.lblPicSize.Visible = False
            End If
        End Sub
    End Class

End Namespace
