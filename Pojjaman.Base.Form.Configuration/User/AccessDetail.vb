Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AccessDetail
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
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblAccess As System.Windows.Forms.Label
        Friend WithEvents tvAccess As System.Windows.Forms.TreeView
        Friend WithEvents lblAccessName As System.Windows.Forms.Label
        Friend WithEvents txtAccessCode As System.Windows.Forms.TextBox
        Friend WithEvents txtDescription As System.Windows.Forms.TextBox
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents imlTree As System.Windows.Forms.ImageList
        Friend WithEvents lvEntity As System.Windows.Forms.ListView
        Friend WithEvents lblEntity As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.tvAccess = New System.Windows.Forms.TreeView
            Me.imlTree = New System.Windows.Forms.ImageList(Me.components)
            Me.lblAccess = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtAccessCode = New System.Windows.Forms.TextBox
            Me.txtDescription = New System.Windows.Forms.TextBox
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblAccessName = New System.Windows.Forms.Label
            Me.lblDescription = New System.Windows.Forms.Label
            Me.lvEntity = New System.Windows.Forms.ListView
            Me.lblEntity = New System.Windows.Forms.Label
            Me.grbItem.SuspendLayout()
            Me.SuspendLayout()
            '
            'tvAccess
            '
            Me.tvAccess.FullRowSelect = True
            Me.tvAccess.HideSelection = False
            Me.tvAccess.ImageList = Me.imlTree
            Me.tvAccess.Location = New System.Drawing.Point(8, 24)
            Me.tvAccess.Name = "tvAccess"
            Me.tvAccess.Size = New System.Drawing.Size(312, 464)
            Me.tvAccess.TabIndex = 194
            Me.tvAccess.TabStop = False
            '
            'imlTree
            '
            Me.imlTree.ImageSize = New System.Drawing.Size(16, 16)
            Me.imlTree.TransparentColor = System.Drawing.Color.Transparent
            '
            'lblAccess
            '
            Me.lblAccess.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccess.ForeColor = System.Drawing.Color.Black
            Me.lblAccess.Location = New System.Drawing.Point(8, 8)
            Me.lblAccess.Name = "lblAccess"
            Me.lblAccess.Size = New System.Drawing.Size(168, 18)
            Me.lblAccess.TabIndex = 184
            Me.lblAccess.Text = "สิทธิ:"
            Me.lblAccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Nothing
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'txtAccessCode
            '
            Me.txtAccessCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtAccessCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccessCode, "")
            Me.txtAccessCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccessCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccessCode, System.Drawing.Color.Empty)
            Me.txtAccessCode.Location = New System.Drawing.Point(72, 24)
            Me.Validator.SetMaxValue(Me.txtAccessCode, "")
            Me.Validator.SetMinValue(Me.txtAccessCode, "")
            Me.txtAccessCode.Name = "txtAccessCode"
            Me.txtAccessCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccessCode, "")
            Me.Validator.SetRequired(Me.txtAccessCode, False)
            Me.txtAccessCode.Size = New System.Drawing.Size(168, 21)
            Me.txtAccessCode.TabIndex = 182
            Me.txtAccessCode.TabStop = False
            Me.txtAccessCode.Text = ""
            '
            'txtDescription
            '
            Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtDescription, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDescription, "")
            Me.txtDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDescription, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDescription, System.Drawing.Color.Empty)
            Me.txtDescription.Location = New System.Drawing.Point(72, 48)
            Me.Validator.SetMaxValue(Me.txtDescription, "")
            Me.Validator.SetMinValue(Me.txtDescription, "")
            Me.txtDescription.Multiline = True
            Me.txtDescription.Name = "txtDescription"
            Me.txtDescription.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDescription, "")
            Me.Validator.SetRequired(Me.txtDescription, False)
            Me.txtDescription.Size = New System.Drawing.Size(168, 48)
            Me.txtDescription.TabIndex = 182
            Me.txtDescription.TabStop = False
            Me.txtDescription.Text = ""
            '
            'grbItem
            '
            Me.grbItem.Controls.Add(Me.lblAccessName)
            Me.grbItem.Controls.Add(Me.txtAccessCode)
            Me.grbItem.Controls.Add(Me.txtDescription)
            Me.grbItem.Controls.Add(Me.lblDescription)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(328, 16)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(248, 112)
            Me.grbItem.TabIndex = 1
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "รายละเอียดสิทธิ"
            '
            'lblAccessName
            '
            Me.lblAccessName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccessName.ForeColor = System.Drawing.Color.Black
            Me.lblAccessName.Location = New System.Drawing.Point(8, 24)
            Me.lblAccessName.Name = "lblAccessName"
            Me.lblAccessName.Size = New System.Drawing.Size(64, 18)
            Me.lblAccessName.TabIndex = 183
            Me.lblAccessName.Text = "สิทธิ:"
            Me.lblAccessName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDescription
            '
            Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDescription.ForeColor = System.Drawing.Color.Black
            Me.lblDescription.Location = New System.Drawing.Point(8, 48)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(64, 18)
            Me.lblDescription.TabIndex = 183
            Me.lblDescription.Text = "Description:"
            Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lvEntity
            '
            Me.lvEntity.Location = New System.Drawing.Point(328, 144)
            Me.lvEntity.Name = "lvEntity"
            Me.lvEntity.Size = New System.Drawing.Size(248, 344)
            Me.lvEntity.TabIndex = 195
            '
            'lblEntity
            '
            Me.lblEntity.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEntity.ForeColor = System.Drawing.Color.Black
            Me.lblEntity.Location = New System.Drawing.Point(328, 128)
            Me.lblEntity.Name = "lblEntity"
            Me.lblEntity.Size = New System.Drawing.Size(168, 18)
            Me.lblEntity.TabIndex = 184
            Me.lblEntity.Text = "หน้าจอ:"
            Me.lblEntity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'AccessDetail
            '
            Me.Controls.Add(Me.lvEntity)
            Me.Controls.Add(Me.grbItem)
            Me.Controls.Add(Me.tvAccess)
            Me.Controls.Add(Me.lblAccess)
            Me.Controls.Add(Me.lblEntity)
            Me.Name = "AccessDetail"
            Me.Size = New System.Drawing.Size(584, 496)
            Me.grbItem.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_isInitialized As Boolean
        Private m_access As Access
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            UpdateEntityProperties()
            EventWiring()
            Dim myIConService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
            Me.imlTree.Images.Add(myIConService.GetBitmap("Icons.16x16.NoAccess"))
            Me.imlTree.Images.Add(myIConService.GetBitmap("Icons.16x16.FullAccess"))
            Me.imlTree.Images.Add(myIConService.GetBitmap("Icons.16x16.PartialAccess"))
        End Sub

#End Region

#Region "Method"
        Protected Overrides Sub EventWiring()
            'AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            'AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
        End Sub
#End Region

#Region "IListDetail"

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()

        End Sub

        ' เคลียร์ข้อมูลใน control
        Public Overrides Sub ClearDetail()

        End Sub
        Public Overrides Sub SetLabelText()
            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetail.grbItem}")
            Me.lblAccess.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetail.lblAccess}")
            Me.lblAccessName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetail.lblAccessName}")
            Me.lblDescription.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetail.lblDescription}")
        End Sub
        ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()

            Dim accessColl As New AccessCollection(True)
            accessColl.Populate(Me.tvAccess)

            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                'Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                'Me.m_entity = Value
                UpdateEntityProperties()
                EventWiring()
            End Set
        End Property
        Public Overrides Sub Initialize()

        End Sub

        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

#End Region

#Region "Event Handlers"
        Private Sub tvAccess_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvAccess.AfterSelect
            If TypeOf e.Node.Tag Is Access Then
                Dim myAccess As Access = CType(e.Node.Tag, Access)
                Me.m_access = myAccess
                UpdateAccess()
            Else
                ClearAccess()
            End If
        End Sub
        Public Sub UpdateAccess()
            If m_access Is Nothing Then
                Return
            End If
            Me.txtAccessCode.Text = m_access.Code
            Me.txtDescription.Text = m_access.Description
        End Sub
        Public Sub ClearAccess()
            Me.txtAccessCode.Text = ""
            Me.txtDescription.Text = ""
        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get

            End Get
        End Property
#End Region

    End Class
End Namespace