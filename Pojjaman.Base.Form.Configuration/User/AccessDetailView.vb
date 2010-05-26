Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AccessDetailView
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
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbUser As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblAccess As System.Windows.Forms.Label
        Friend WithEvents tvAccess As System.Windows.Forms.TreeView
        Friend WithEvents lblAccessName As System.Windows.Forms.Label
        Friend WithEvents txtAccessCode As System.Windows.Forms.TextBox
        Friend WithEvents txtDescription As System.Windows.Forms.TextBox
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents imlTree As System.Windows.Forms.ImageList
        Friend WithEvents grbLevel As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkView As System.Windows.Forms.CheckBox
        Friend WithEvents chkModify As System.Windows.Forms.CheckBox
        Friend WithEvents chkCreate As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
        Friend WithEvents chkDelete As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.grbUser = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.tvAccess = New System.Windows.Forms.TreeView
            Me.imlTree = New System.Windows.Forms.ImageList(Me.components)
            Me.lblAccess = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtAccessCode = New System.Windows.Forms.TextBox
            Me.txtDescription = New System.Windows.Forms.TextBox
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbLevel = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkDelete = New System.Windows.Forms.CheckBox
            Me.chkView = New System.Windows.Forms.CheckBox
            Me.chkModify = New System.Windows.Forms.CheckBox
            Me.chkCreate = New System.Windows.Forms.CheckBox
            Me.chkPrint = New System.Windows.Forms.CheckBox
            Me.lblAccessName = New System.Windows.Forms.Label
            Me.lblDescription = New System.Windows.Forms.Label
            Me.grbUser.SuspendLayout()
            Me.grbItem.SuspendLayout()
            Me.grbLevel.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(40, 18)
            Me.lblCode.TabIndex = 183
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(56, 24)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.txtCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(56, 21)
            Me.txtCode.TabIndex = 182
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'grbUser
            '
            Me.grbUser.Controls.Add(Me.lblCode)
            Me.grbUser.Controls.Add(Me.txtCode)
            Me.grbUser.Controls.Add(Me.txtName)
            Me.grbUser.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbUser.Location = New System.Drawing.Point(8, 8)
            Me.grbUser.Name = "grbUser"
            Me.grbUser.Size = New System.Drawing.Size(552, 56)
            Me.grbUser.TabIndex = 2
            Me.grbUser.TabStop = False
            Me.grbUser.Text = "ผู้ใช้"
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(112, 24)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.txtName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(432, 21)
            Me.txtName.TabIndex = 182
            Me.txtName.TabStop = False
            Me.txtName.Text = ""
            '
            'tvAccess
            '
            Me.tvAccess.FullRowSelect = True
            Me.tvAccess.HideSelection = False
            Me.tvAccess.ImageList = Me.imlTree
            Me.tvAccess.Location = New System.Drawing.Point(8, 80)
            Me.tvAccess.Name = "tvAccess"
            Me.tvAccess.Size = New System.Drawing.Size(312, 408)
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
            Me.lblAccess.Location = New System.Drawing.Point(8, 64)
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
            Me.txtAccessCode.Size = New System.Drawing.Size(152, 21)
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
            Me.txtDescription.Size = New System.Drawing.Size(152, 48)
            Me.txtDescription.TabIndex = 182
            Me.txtDescription.TabStop = False
            Me.txtDescription.Text = ""
            '
            'grbItem
            '
            Me.grbItem.Controls.Add(Me.grbLevel)
            Me.grbItem.Controls.Add(Me.lblAccessName)
            Me.grbItem.Controls.Add(Me.txtAccessCode)
            Me.grbItem.Controls.Add(Me.txtDescription)
            Me.grbItem.Controls.Add(Me.lblDescription)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(328, 72)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(232, 416)
            Me.grbItem.TabIndex = 1
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "รายละเอียดสิทธิ"
            '
            'grbLevel
            '
            Me.grbLevel.Controls.Add(Me.chkDelete)
            Me.grbLevel.Controls.Add(Me.chkView)
            Me.grbLevel.Controls.Add(Me.chkModify)
            Me.grbLevel.Controls.Add(Me.chkCreate)
            Me.grbLevel.Controls.Add(Me.chkPrint)
            Me.grbLevel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbLevel.Location = New System.Drawing.Point(16, 120)
            Me.grbLevel.Name = "grbLevel"
            Me.grbLevel.Size = New System.Drawing.Size(200, 200)
            Me.grbLevel.TabIndex = 184
            Me.grbLevel.TabStop = False
            Me.grbLevel.Text = "ระดับ"
            '
            'chkDelete
            '
            Me.chkDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkDelete.Location = New System.Drawing.Point(88, 128)
            Me.chkDelete.Name = "chkDelete"
            Me.chkDelete.TabIndex = 3
            Me.chkDelete.Text = "ลบ"
            '
            'chkView
            '
            Me.chkView.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkView.Location = New System.Drawing.Point(32, 32)
            Me.chkView.Name = "chkView"
            Me.chkView.TabIndex = 0
            Me.chkView.Text = "ดูรายละเอียด"
            '
            'chkModify
            '
            Me.chkModify.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkModify.Location = New System.Drawing.Point(48, 64)
            Me.chkModify.Name = "chkModify"
            Me.chkModify.TabIndex = 1
            Me.chkModify.Text = "แก้ไข"
            '
            'chkCreate
            '
            Me.chkCreate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkCreate.Location = New System.Drawing.Point(64, 96)
            Me.chkCreate.Name = "chkCreate"
            Me.chkCreate.TabIndex = 2
            Me.chkCreate.Text = "สร้างใหม่"
            '
            'chkPrint
            '
            Me.chkPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkPrint.Location = New System.Drawing.Point(32, 160)
            Me.chkPrint.Name = "chkPrint"
            Me.chkPrint.TabIndex = 4
            Me.chkPrint.Text = "พิมพ์"
            '
            'lblAccessName
            '
            Me.lblAccessName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccessName.ForeColor = System.Drawing.Color.Black
            Me.lblAccessName.Location = New System.Drawing.Point(16, 24)
            Me.lblAccessName.Name = "lblAccessName"
            Me.lblAccessName.Size = New System.Drawing.Size(56, 18)
            Me.lblAccessName.TabIndex = 183
            Me.lblAccessName.Text = "สิทธิ:"
            Me.lblAccessName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDescription
            '
            Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDescription.ForeColor = System.Drawing.Color.Black
            Me.lblDescription.Location = New System.Drawing.Point(16, 48)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(56, 18)
            Me.lblDescription.TabIndex = 183
            Me.lblDescription.Text = "คำอธิบาย:"
            Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'AccessDetailView
            '
            Me.Controls.Add(Me.grbItem)
            Me.Controls.Add(Me.tvAccess)
            Me.Controls.Add(Me.grbUser)
            Me.Controls.Add(Me.lblAccess)
            Me.Name = "AccessDetailView"
            Me.Size = New System.Drawing.Size(568, 496)
            Me.grbUser.ResumeLayout(False)
            Me.grbItem.ResumeLayout(False)
            Me.grbLevel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As ISimpleEntity
        Private m_treeManager As TreeManager

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
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler chkView.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler chkModify.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler chkCreate.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler chkPrint.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler chkDelete.CheckedChanged, AddressOf Me.ChangeProperty
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
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.lblCode}")
            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.grbItem}")
            Me.grbUser.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.grbUser}")
            Me.lblAccess.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.lblAccess}")
            Me.lblAccessName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.lblAccessName}")
            Me.lblDescription.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.lblDescription}")
            Me.grbLevel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.grbLevel}")
            Me.chkView.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.chkView}")
            Me.chkModify.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.chkModify}")
            Me.chkCreate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.chkCreate}")
            Me.chkPrint.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.chkPrint}")
            Me.chkDelete.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccessDetailView.chkDelete}")
        End Sub
        ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()

            If m_entity Is Nothing Then
                Return
            End If

            ' ทำการผูก Property ต่าง ๆ ของเข้ากับ control
            With Me
                .txtCode.Text = .m_entity.Code
                If TypeOf .m_entity Is IHasName Then
                    .txtName.Text = CType(.m_entity, IHasName).Name
                End If
            End With

            If TypeOf Me.m_entity Is IHasAccess Then
                If CType(Me.m_entity, IHasAccess).AccessCollection Is Nothing Then
                    CType(Me.m_entity, IHasAccess).SetAccessCollection()
                End If
                CType(Me.m_entity, IHasAccess).AccessCollection.Populate(Me.tvAccess)
            End If
            If Me.tvAccess.Nodes.Count > 0 Then
                Me.tvAccess.SelectedNode = Me.tvAccess.Nodes(0)
            End If
            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Value
                UpdateEntityProperties()
        'EventWiring()
            End Set
        End Property
        Public Overrides Sub Initialize()

        End Sub

        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            If Me.m_access Is Nothing Then
                Return
            End If
            Dim forceView As Boolean = False
            Dim forceModify As Boolean = False
            Dim forceCreate As Boolean = False
            Dim forcePrint As Boolean = False
            Dim forceDelete As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "chkview"
                    forceView = True
                    If chkView.Checked Then
                        m_access.Current = 1
                    Else
                        m_access.Current = 0
                    End If
                Case "chkmodify"
                    forceModify = True
                    If chkModify.Checked Then
                        Select Case m_access.Current
                            Case 0, 1
                                m_access.Current = 3
                            Case 9
                                m_access.Current = 11
                        End Select
                    Else
                        Select Case m_access.Current
                            Case 3, 7, 23
                                m_access.Current = 1
                            Case 11, 15, 31
                                m_access.Current = 9
                        End Select
                    End If
                Case "chkcreate"
                    forceCreate = True
                    If chkCreate.Checked Then
                        Select Case m_access.Current
                            Case 0, 1, 3
                                m_access.Current = 7
                            Case 9, 11
                                m_access.Current = 15
                        End Select
                    Else
                        Select Case m_access.Current
                            Case 7, 23
                                m_access.Current = 3
                            Case 15, 31
                                m_access.Current = 11
                        End Select
                    End If
                Case "chkprint"
                    forcePrint = True
                    If chkPrint.Checked Then
                        Select Case m_access.Current
                            Case 0, 1
                                m_access.Current = 9
                            Case 3
                                m_access.Current = 11
                            Case 7
                                m_access.Current = 15
                            Case 23
                                m_access.Current = 31
                        End Select
                    Else
                        Select Case m_access.Current
                            Case 9
                                m_access.Current = 1
                            Case 11
                                m_access.Current = 3
                            Case 15
                                m_access.Current = 7
                            Case 31
                                m_access.Current = 23
                        End Select
                    End If
                Case "chkdelete"
                    forceDelete = True
                    If chkDelete.Checked Then
                        Select Case m_access.Current
                            Case 0, 1, 3, 7
                                m_access.Current = 23
                            Case 9, 11, 15
                                m_access.Current = 31
                        End Select
                    Else
                        Select Case m_access.Current
                            Case 23
                                m_access.Current = 7
                            Case 31
                                m_access.Current = 15
                        End Select
                    End If
            End Select
            SetAccess(forceView, forceModify, forceCreate, forcePrint, forceDelete)
            If TypeOf Me.m_entity Is IHasAccess Then
                CType(Me.m_entity, IHasAccess).AccessCollection.SetChildAccess(m_access)
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            CheckFormEnable()
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
        Private Function RevertString(ByVal st As String) As String
            Dim chArr As Char() = st.ToCharArray
            Array.Reverse(chArr)
            st = ""
            For Each ch As Char In chArr
                st &= ch
            Next
            Return st
        End Function

        Private Function LoopChild(ByVal node As TreeNode, ByVal bit As Integer, ByVal value As Boolean) As Boolean
            'Hack
            Return True

            'Undone
            If Not TypeOf node.Tag Is Access Then
                Return False
            End If
            Dim flag As Boolean
            For Each childNode As TreeNode In node.Nodes
                Dim myAcc As Access = CType(node.Tag, Access)
                Dim checkString As String = BinaryHelper.DecToBin(myAcc.Current, 5)
                checkString = BinaryHelper.RevertString(checkString)
                Dim myValue As Boolean = CBool(checkString.Substring(bit, 1))
                If value = myValue Then
                    Return LoopChild(childNode, bit, value)
                Else
                    Return False
                End If
            Next
            Return True
        End Function

        Private Sub SetAccess( _
        ByVal forceView As Boolean _
        , ByVal forceModify As Boolean _
        , ByVal forceCreate As Boolean _
        , ByVal forcePrint As Boolean _
        , ByVal forceDelete As Boolean)
            If m_access Is Nothing Then
                Return
            End If
            Me.m_isInitialized = False
            Dim checkString As String = BinaryHelper.DecToBin(m_access.Current, 5)
            checkString = BinaryHelper.RevertString(checkString)
            Dim canView As Boolean = CBool(checkString.Substring(0, 1))
            Dim canModify As Boolean = CBool(checkString.Substring(1, 1))
            Dim canCreate As Boolean = CBool(checkString.Substring(2, 1))
            Dim canPrint As Boolean = CBool(checkString.Substring(3, 1))
            Dim canDelete As Boolean = CBool(checkString.Substring(4, 1))

            Dim sameCanViewEveryChild As Boolean = forceView OrElse LoopChild(Me.tvAccess.SelectedNode, 0, canView)
            Dim sameCanModifyEveryChild As Boolean = forceModify OrElse LoopChild(Me.tvAccess.SelectedNode, 1, canModify)
            Dim sameCanCreateEveryChild As Boolean = forceCreate OrElse LoopChild(Me.tvAccess.SelectedNode, 2, canCreate)
            Dim sameCanPrintEveryChild As Boolean = forcePrint OrElse LoopChild(Me.tvAccess.SelectedNode, 3, canPrint)
            Dim sameCanDeleteEveryChild As Boolean = forceDelete OrElse LoopChild(Me.tvAccess.SelectedNode, 4, canDelete)

            Select Case m_access.CodeName.ToLower
                Case "v"
                    Me.chkCreate.Enabled = False
                    Me.chkModify.Enabled = False
                    Me.chkPrint.Enabled = False
                    Me.chkDelete.Enabled = False
                    If sameCanViewEveryChild Then
                        chkView.Checked = canView
                    Else
                        chkView.CheckState = CheckState.Indeterminate
                    End If
                    chkCreate.Checked = False
                    chkPrint.Checked = False
                    chkModify.Checked = False
                    chkDelete.Checked = False
                Case "v/p"
                    Me.chkCreate.Enabled = False
                    Me.chkModify.Enabled = False
                    Me.chkPrint.Enabled = True
                    Me.chkDelete.Enabled = False
                    If sameCanViewEveryChild Then
                        chkView.Checked = canView
                    Else
                        chkView.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanPrintEveryChild Then
                        chkPrint.Checked = canPrint
                    Else
                        chkPrint.CheckState = CheckState.Indeterminate
                    End If
                    chkCreate.Checked = False
                    chkModify.Checked = False
                    chkDelete.Checked = False
                Case "v/m"
                    Me.chkCreate.Enabled = False
                    Me.chkModify.Enabled = True
                    Me.chkPrint.Enabled = False
                    Me.chkDelete.Enabled = False
                    If sameCanViewEveryChild Then
                        chkView.Checked = canView
                    Else
                        chkView.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanModifyEveryChild Then
                        chkModify.Checked = canModify
                    Else
                        chkModify.CheckState = CheckState.Indeterminate
                    End If
                    chkCreate.Checked = False
                    chkPrint.Checked = False
                    chkDelete.Checked = False
                Case "v/m/c"
                    Me.chkCreate.Enabled = True
                    Me.chkModify.Enabled = True
                    Me.chkPrint.Enabled = False
                    Me.chkDelete.Enabled = False
                    If sameCanViewEveryChild Then
                        chkView.Checked = canView
                    Else
                        chkView.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanModifyEveryChild Then
                        chkModify.Checked = canModify
                    Else
                        chkModify.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanCreateEveryChild Then
                        chkCreate.Checked = canCreate
                    Else
                        chkCreate.CheckState = CheckState.Indeterminate
                    End If
                    chkPrint.Checked = False
                    chkDelete.Checked = False
                Case "v/m/c/d"
                    Me.chkCreate.Enabled = True
                    Me.chkModify.Enabled = True
                    Me.chkPrint.Enabled = False
                    Me.chkDelete.Enabled = True
                    If sameCanViewEveryChild Then
                        chkView.Checked = canView
                    Else
                        chkView.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanModifyEveryChild Then
                        chkModify.Checked = canModify
                    Else
                        chkModify.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanCreateEveryChild Then
                        chkCreate.Checked = canCreate
                    Else
                        chkCreate.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanDeleteEveryChild Then
                        chkDelete.Checked = canDelete
                    Else
                        chkDelete.CheckState = CheckState.Indeterminate
                    End If
                    chkPrint.Checked = False
                Case "v/m/c/p"
                    Me.chkCreate.Enabled = True
                    Me.chkModify.Enabled = True
                    Me.chkPrint.Enabled = True
                    Me.chkDelete.Enabled = False
                    If sameCanViewEveryChild Then
                        chkView.Checked = canView
                    Else
                        chkView.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanModifyEveryChild Then
                        chkModify.Checked = canModify
                    Else
                        chkModify.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanCreateEveryChild Then
                        chkCreate.Checked = canCreate
                    Else
                        chkCreate.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanPrintEveryChild Then
                        chkPrint.Checked = canPrint
                    Else
                        chkPrint.CheckState = CheckState.Indeterminate
                    End If
                    chkDelete.Checked = False
                Case "v/m/c/p/d"
                    Me.chkCreate.Enabled = True
                    Me.chkModify.Enabled = True
                    Me.chkPrint.Enabled = True
                    Me.chkDelete.Enabled = True
                    If sameCanViewEveryChild Then
                        chkView.Checked = canView
                    Else
                        chkView.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanModifyEveryChild Then
                        chkModify.Checked = canModify
                    Else
                        chkModify.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanCreateEveryChild Then
                        chkCreate.Checked = canCreate
                    Else
                        chkCreate.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanPrintEveryChild Then
                        chkPrint.Checked = canPrint
                    Else
                        chkPrint.CheckState = CheckState.Indeterminate
                    End If
                    If sameCanDeleteEveryChild Then
                        chkDelete.Checked = canDelete
                    Else
                        chkDelete.CheckState = CheckState.Indeterminate
                    End If
            End Select
            Me.m_isInitialized = True
        End Sub
        Public Sub UpdateAccess()
            If m_access Is Nothing Then
                Return
            End If
            Me.txtAccessCode.Text = m_access.Code
            Me.txtDescription.Text = m_access.Description
            Me.grbLevel.Enabled = True
            SetAccess(False, False, False, False, False)
        End Sub
        Public Sub ClearAccess()
            Me.txtAccessCode.Text = ""
            Me.txtDescription.Text = ""
            Me.grbLevel.Enabled = False
        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get

            End Get
        End Property
#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
    Public Overrides Sub NotifyBeforeSave()
      MyBase.NotifyBeforeSave()
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

    End Class
End Namespace