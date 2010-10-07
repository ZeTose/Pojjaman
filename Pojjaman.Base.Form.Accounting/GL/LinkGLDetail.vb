Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class LinkGLDetail
        Inherits AbstractEntityPanelViewContent
        Implements IValidatable, ISimpleListPanel

#Region "Members"
        Private m_entity As GLFormat
        Private m_treeManager As TreeManager
        Private m_enableState As Hashtable
        Private m_isInitialized As Boolean
        Private m_tableStyleEnable As Hashtable
        Private m_dummyAccount As New Account

        Private m_treemanager2 As TreeManager
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
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents grbGl As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents chkDefault As System.Windows.Forms.CheckBox
        Friend WithEvents lblPost As System.Windows.Forms.Label
        Friend WithEvents grbPostGl As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblAccountBook As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents tvLinkGL As System.Windows.Forms.TreeView
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblFormat As System.Windows.Forms.Label
        Friend WithEvents txtFormatCode As System.Windows.Forms.TextBox
        Friend WithEvents txtFormatName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowAccountBook As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowAccountBookDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAccountBookName As System.Windows.Forms.TextBox
        Friend WithEvents txtAccountBookCode As System.Windows.Forms.TextBox
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnToggleDebit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnGetDefault As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents tgDefault As Longkong.Pojjaman.Gui.Components.TreeGrid
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LinkGLDetail))
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblAccountBook = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.grbGl = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.chkDefault = New System.Windows.Forms.CheckBox
            Me.lblFormat = New System.Windows.Forms.Label
            Me.txtFormatCode = New System.Windows.Forms.TextBox
            Me.tvLinkGL = New System.Windows.Forms.TreeView
            Me.lblPost = New System.Windows.Forms.Label
            Me.grbPostGl = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnShowAccountBook = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowAccountBookDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtAccountBookName = New System.Windows.Forms.TextBox
            Me.txtAccountBookCode = New System.Windows.Forms.TextBox
            Me.txtFormatName = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnToggleDebit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.tgDefault = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.ibtnGetDefault = New Longkong.Pojjaman.Gui.Components.ImageButton
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbGl.SuspendLayout()
            Me.grbPostGl.SuspendLayout()
            Me.grbItem.SuspendLayout()
            CType(Me.tgDefault, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(24, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(72, 18)
            Me.lblCode.TabIndex = 183
            Me.lblCode.Text = "รหัสการผ่าน:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(96, 24)
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
            'tgItem
            '
            Me.tgItem.AllowNew = False
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = True
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(16, 48)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(520, 200)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 0
            Me.tgItem.TreeManager = Nothing
            '
            'lblAccountBook
            '
            Me.lblAccountBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountBook.Location = New System.Drawing.Point(8, 40)
            Me.lblAccountBook.Name = "lblAccountBook"
            Me.lblAccountBook.Size = New System.Drawing.Size(88, 18)
            Me.lblAccountBook.TabIndex = 189
            Me.lblAccountBook.Text = "สมุดรายวัน:"
            Me.lblAccountBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(96, 64)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(424, 21)
            Me.txtNote.TabIndex = 3
            Me.txtNote.TabStop = False
            Me.txtNote.Text = ""
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 64)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(88, 18)
            Me.lblNote.TabIndex = 183
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbGl
            '
            Me.grbGl.Controls.Add(Me.lblCode)
            Me.grbGl.Controls.Add(Me.txtCode)
            Me.grbGl.Controls.Add(Me.txtName)
            Me.grbGl.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbGl.Location = New System.Drawing.Point(272, 8)
            Me.grbGl.Name = "grbGl"
            Me.grbGl.Size = New System.Drawing.Size(544, 56)
            Me.grbGl.TabIndex = 2
            Me.grbGl.TabStop = False
            Me.grbGl.Text = "การผ่านบัญชี"
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(152, 24)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.txtName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(368, 21)
            Me.txtName.TabIndex = 182
            Me.txtName.TabStop = False
            Me.txtName.Text = ""
            '
            'chkDefault
            '
            Me.chkDefault.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkDefault.Location = New System.Drawing.Point(328, 42)
            Me.chkDefault.Name = "chkDefault"
            Me.chkDefault.Size = New System.Drawing.Size(104, 16)
            Me.chkDefault.TabIndex = 194
            Me.chkDefault.Text = "Default"
            '
            'lblFormat
            '
            Me.lblFormat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFormat.Location = New System.Drawing.Point(8, 16)
            Me.lblFormat.Name = "lblFormat"
            Me.lblFormat.Size = New System.Drawing.Size(88, 18)
            Me.lblFormat.TabIndex = 189
            Me.lblFormat.Text = "รูปแบบการเชื่อม:"
            Me.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtFormatCode
            '
            Me.txtFormatCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtFormatCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFormatCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtFormatCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFormatCode, System.Drawing.Color.Empty)
            Me.txtFormatCode.Location = New System.Drawing.Point(96, 16)
            Me.Validator.SetMaxValue(Me.txtFormatCode, "")
            Me.Validator.SetMinValue(Me.txtFormatCode, "")
            Me.txtFormatCode.Name = "txtFormatCode"
            Me.Validator.SetRegularExpression(Me.txtFormatCode, "")
            Me.Validator.SetRequired(Me.txtFormatCode, True)
            Me.txtFormatCode.Size = New System.Drawing.Size(56, 20)
            Me.txtFormatCode.TabIndex = 0
            Me.txtFormatCode.Text = ""
            '
            'tvLinkGL
            '
            Me.tvLinkGL.FullRowSelect = True
            Me.tvLinkGL.HideSelection = False
            Me.tvLinkGL.ImageIndex = -1
            Me.tvLinkGL.Location = New System.Drawing.Point(8, 16)
            Me.tvLinkGL.Name = "tvLinkGL"
            Me.tvLinkGL.SelectedImageIndex = -1
            Me.tvLinkGL.Size = New System.Drawing.Size(248, 200)
            Me.tvLinkGL.TabIndex = 194
            Me.tvLinkGL.TabStop = False
            '
            'lblPost
            '
            Me.lblPost.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPost.ForeColor = System.Drawing.Color.Black
            Me.lblPost.Location = New System.Drawing.Point(8, 0)
            Me.lblPost.Name = "lblPost"
            Me.lblPost.Size = New System.Drawing.Size(168, 18)
            Me.lblPost.TabIndex = 184
            Me.lblPost.Text = "การเชื่อมGL:"
            Me.lblPost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbPostGl
            '
            Me.grbPostGl.Controls.Add(Me.ibtnShowAccountBook)
            Me.grbPostGl.Controls.Add(Me.ibtnShowAccountBookDialog)
            Me.grbPostGl.Controls.Add(Me.txtAccountBookName)
            Me.grbPostGl.Controls.Add(Me.txtAccountBookCode)
            Me.grbPostGl.Controls.Add(Me.lblNote)
            Me.grbPostGl.Controls.Add(Me.txtNote)
            Me.grbPostGl.Controls.Add(Me.txtFormatName)
            Me.grbPostGl.Controls.Add(Me.lblFormat)
            Me.grbPostGl.Controls.Add(Me.chkDefault)
            Me.grbPostGl.Controls.Add(Me.lblAccountBook)
            Me.grbPostGl.Controls.Add(Me.txtFormatCode)
            Me.grbPostGl.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbPostGl.Location = New System.Drawing.Point(272, 64)
            Me.grbPostGl.Name = "grbPostGl"
            Me.grbPostGl.Size = New System.Drawing.Size(544, 96)
            Me.grbPostGl.TabIndex = 0
            Me.grbPostGl.TabStop = False
            Me.grbPostGl.Text = "กำหนดรูปแบบการเชื่อม"
            '
            'ibtnShowAccountBook
            '
            Me.ibtnShowAccountBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowAccountBook.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowAccountBook.Image = CType(resources.GetObject("ibtnShowAccountBook.Image"), System.Drawing.Image)
            Me.ibtnShowAccountBook.Location = New System.Drawing.Point(296, 39)
            Me.ibtnShowAccountBook.Name = "ibtnShowAccountBook"
            Me.ibtnShowAccountBook.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowAccountBook.TabIndex = 215
            Me.ibtnShowAccountBook.TabStop = False
            Me.ibtnShowAccountBook.ThemedImage = CType(resources.GetObject("ibtnShowAccountBook.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowAccountBookDialog
            '
            Me.ibtnShowAccountBookDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowAccountBookDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowAccountBookDialog.Image = CType(resources.GetObject("ibtnShowAccountBookDialog.Image"), System.Drawing.Image)
            Me.ibtnShowAccountBookDialog.Location = New System.Drawing.Point(272, 39)
            Me.ibtnShowAccountBookDialog.Name = "ibtnShowAccountBookDialog"
            Me.ibtnShowAccountBookDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowAccountBookDialog.TabIndex = 214
            Me.ibtnShowAccountBookDialog.TabStop = False
            Me.ibtnShowAccountBookDialog.ThemedImage = CType(resources.GetObject("ibtnShowAccountBookDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountBookName
            '
            Me.txtAccountBookName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtAccountBookName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountBookName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountBookName, System.Drawing.Color.Empty)
            Me.txtAccountBookName.Location = New System.Drawing.Point(152, 40)
            Me.Validator.SetMaxValue(Me.txtAccountBookName, "")
            Me.Validator.SetMinValue(Me.txtAccountBookName, "")
            Me.txtAccountBookName.Name = "txtAccountBookName"
            Me.txtAccountBookName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountBookName, "")
            Me.Validator.SetRequired(Me.txtAccountBookName, False)
            Me.txtAccountBookName.Size = New System.Drawing.Size(120, 20)
            Me.txtAccountBookName.TabIndex = 213
            Me.txtAccountBookName.TabStop = False
            Me.txtAccountBookName.Text = ""
            '
            'txtAccountBookCode
            '
            Me.Validator.SetDataType(Me.txtAccountBookCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountBookCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountBookCode, System.Drawing.Color.Empty)
            Me.txtAccountBookCode.Location = New System.Drawing.Point(96, 40)
            Me.Validator.SetMaxValue(Me.txtAccountBookCode, "")
            Me.Validator.SetMinValue(Me.txtAccountBookCode, "")
            Me.txtAccountBookCode.Name = "txtAccountBookCode"
            Me.Validator.SetRegularExpression(Me.txtAccountBookCode, "")
            Me.Validator.SetRequired(Me.txtAccountBookCode, True)
            Me.txtAccountBookCode.Size = New System.Drawing.Size(56, 20)
            Me.txtAccountBookCode.TabIndex = 2
            Me.txtAccountBookCode.Text = ""
            '
            'txtFormatName
            '
            Me.Validator.SetDataType(Me.txtFormatName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFormatName, "")
            Me.txtFormatName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtFormatName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFormatName, System.Drawing.Color.Empty)
            Me.txtFormatName.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMaxValue(Me.txtFormatName, "")
            Me.Validator.SetMinValue(Me.txtFormatName, "")
            Me.txtFormatName.Name = "txtFormatName"
            Me.Validator.SetRegularExpression(Me.txtFormatName, "")
            Me.Validator.SetRequired(Me.txtFormatName, True)
            Me.txtFormatName.Size = New System.Drawing.Size(368, 21)
            Me.txtFormatName.TabIndex = 1
            Me.txtFormatName.Text = ""
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
            'grbItem
            '
            Me.grbItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbItem.Controls.Add(Me.ibtnBlank)
            Me.grbItem.Controls.Add(Me.ibtnDelRow)
            Me.grbItem.Controls.Add(Me.tgItem)
            Me.grbItem.Controls.Add(Me.ibtnToggleDebit)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(272, 168)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(544, 256)
            Me.grbItem.TabIndex = 1
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "grbItem"
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(16, 24)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 224
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(40, 24)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 223
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnToggleDebit
            '
            Me.ibtnToggleDebit.Image = CType(resources.GetObject("ibtnToggleDebit.Image"), System.Drawing.Image)
            Me.ibtnToggleDebit.Location = New System.Drawing.Point(80, 16)
            Me.ibtnToggleDebit.Name = "ibtnToggleDebit"
            Me.ibtnToggleDebit.Size = New System.Drawing.Size(32, 32)
            Me.ibtnToggleDebit.TabIndex = 224
            Me.ibtnToggleDebit.TabStop = False
            Me.ibtnToggleDebit.ThemedImage = CType(resources.GetObject("ibtnToggleDebit.ThemedImage"), System.Drawing.Bitmap)
            '
            'tgDefault
            '
            Me.tgDefault.AllowNew = False
            Me.tgDefault.AllowSorting = False
            Me.tgDefault.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tgDefault.AutoColumnResize = True
            Me.tgDefault.CaptionVisible = False
            Me.tgDefault.Cellchanged = False
            Me.tgDefault.DataMember = ""
            Me.tgDefault.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgDefault.Location = New System.Drawing.Point(8, 216)
            Me.tgDefault.Name = "tgDefault"
            Me.tgDefault.Size = New System.Drawing.Size(248, 200)
            Me.tgDefault.SortingArrowColor = System.Drawing.Color.Red
            Me.tgDefault.TabIndex = 195
            Me.tgDefault.TreeManager = Nothing
            '
            'ibtnGetDefault
            '
            Me.ibtnGetDefault.Image = CType(resources.GetObject("ibtnGetDefault.Image"), System.Drawing.Image)
            Me.ibtnGetDefault.Location = New System.Drawing.Point(256, 232)
            Me.ibtnGetDefault.Name = "ibtnGetDefault"
            Me.ibtnGetDefault.Size = New System.Drawing.Size(24, 24)
            Me.ibtnGetDefault.TabIndex = 224
            Me.ibtnGetDefault.TabStop = False
            Me.ibtnGetDefault.ThemedImage = CType(resources.GetObject("ibtnGetDefault.ThemedImage"), System.Drawing.Bitmap)
            '
            'LinkGLDetail
            '
            Me.Controls.Add(Me.ibtnGetDefault)
            Me.Controls.Add(Me.tgDefault)
            Me.Controls.Add(Me.grbItem)
            Me.Controls.Add(Me.tvLinkGL)
            Me.Controls.Add(Me.grbGl)
            Me.Controls.Add(Me.lblPost)
            Me.Controls.Add(Me.grbPostGl)
            Me.Name = "LinkGLDetail"
            Me.Size = New System.Drawing.Size(832, 432)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbGl.ResumeLayout(False)
            Me.grbPostGl.ResumeLayout(False)
            Me.grbItem.ResumeLayout(False)
            CType(Me.tgDefault, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
            MyBase.New()
            InitializeComponent()

            m_entity = New GLFormat
            SaveEnableState()
            m_tableStyleEnable = New Hashtable

            LinkGL.Populate(Me.tvLinkGL, filters)


            Dim dt As TreeTable = GLFormat.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf GLFItemDelete

            Dim dt2 As TreeTable = GLFormat.GetSchemaTable()
            Dim dst2 As DataGridTableStyle = Me.CreateTableStyle2()
            m_treemanager2 = New TreeManager(dt2, tgDefault)
            m_treemanager2.SetTableStyle(dst2)
            m_treemanager2.AllowSorting = False
            m_treemanager2.AllowDelete = False
            tgItem.AllowNew = False

            EventWiring()

            'initial entity
            Me.UpdateEntityProperties()
            Me.TitleName = m_entity.TabPageText
        End Sub
        Private Sub SaveEnableState()
            m_enableState = New Hashtable
            For Each ctrl As Control In Me.grbItem.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
            For Each ctrl As Control In Me.grbPostGl.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "GLFormat"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "glfi_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "glfi_linenumber"


            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.DescriptionHeaderText}")
            csName.NullText = ""
            csName.Width = 180
            csName.TextBox.Name = "Description"

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "Note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "Note"
            csNote.ReadOnly = True

            Dim csAcctCode As New TreeTextColumn
            csAcctCode.MappingName = "AcctCode"
            csAcctCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.AcctCodeHeaderText}")
            csAcctCode.NullText = ""
            csAcctCode.TextBox.Name = "AcctCode"
            csAcctCode.Width = 70
            csAcctCode.DataAlignment = HorizontalAlignment.Right
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csAcctButton As New DataGridButtonColumn
            csAcctButton.MappingName = "AcctButton"
            csAcctButton.HeaderText = ""
            csAcctButton.NullText = ""

            Dim csAcctName As New TreeTextColumn
            csAcctName.MappingName = "AcctName"
            csAcctName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.AcctNameHeaderText}")
            csAcctName.NullText = ""
            csAcctName.TextBox.Name = "AcctName"
            csAcctName.ReadOnly = True
            csAcctName.Width = 180

            Dim csMapping As New TreeTextColumn
            csMapping.MappingName = "glfi_mapping"
            csMapping.HeaderText = "Mapping"
            csMapping.NullText = ""
            csMapping.Width = 180

            Dim csCCCode As New TreeTextColumn
            csCCCode.MappingName = "CCCode"
            csCCCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CCCodeHeaderText}")
            csCCCode.NullText = ""
            csCCCode.TextBox.Name = "CCCode"
            csCCCode.Width = 60
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csCCButton As New DataGridButtonColumn
            csCCButton.MappingName = "CCButton"
            csCCButton.HeaderText = ""
            csCCButton.NullText = ""
            AddHandler csCCButton.Click, AddressOf AcctButtonClicked


            Dim csCCName As New TreeTextColumn
            csCCName.MappingName = "CCName"
            csCCName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CCNameHeaderText}")
            csCCName.NullText = ""
            csCCName.TextBox.Name = "CCName"
            csCCName.ReadOnly = True
            csCCName.Width = 100

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csNote)
            dst.GridColumnStyles.Add(csAcctCode)
            dst.GridColumnStyles.Add(csAcctButton)
            dst.GridColumnStyles.Add(csAcctName)
            dst.GridColumnStyles.Add(csCCCode)
            dst.GridColumnStyles.Add(csCCButton)
            dst.GridColumnStyles.Add(csCCName)
            dst.GridColumnStyles.Add(csMapping)

            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
        Public Sub AcctButtonClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 4 Then
                AccountButtonClick(e)
            Else
                CCButtonClick(e)
            End If
        End Sub
        Public Function CreateTableStyle2() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "GLFormat"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)


            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.DescriptionHeaderText}")
            csName.NullText = ""
            csName.Width = 100
            csName.TextBox.Name = "Description"
            csName.ReadOnly = True

            Dim csMapping As New TreeTextColumn
            csMapping.MappingName = "glfi_mapping"
            csMapping.HeaderText = "Mapping"
            csMapping.NullText = ""
            csMapping.Width = 60
            csMapping.ReadOnly = True

            dst.GridColumnStyles.Add(csMapping)
            dst.GridColumnStyles.Add(csName)

            Return dst
        End Function
#End Region

#Region "Properties"
        Private ReadOnly Property CurrentItem() As GLFormatItem
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is GLFormatItem Then
                    Return Nothing
                End If
                Return CType(row.Tag, GLFormatItem)
            End Get
        End Property
        Private ReadOnly Property CurrentItem2() As GLFormatItem
            Get
                Dim row As TreeRow = Me.m_treemanager2.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is GLFormatItem Then
                    Return Nothing
                End If
                Return CType(row.Tag, GLFormatItem)
            End Get
        End Property
#End Region

#Region "ItemTreeTable Handlers"
        Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
                Return
            End If
            If Not Me.WorkbenchWindow Is Nothing Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            RefreshDocs()
            tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized OrElse e.Column.ColumnName.ToLower = "selected" Then
                Return
            End If
            If Me.m_treeManager.SelectedRow Is Nothing Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity Is Nothing Then
                Return
            End If
            Dim doc As GLFormatItem = Me.CurrentItem
            If doc Is Nothing Then
                doc = New GLFormatItem
                doc.Field = New BlankItem("")
                doc.FieldType = New GLFormatItemType(1)
                Me.m_entity.ItemCollection.Add(doc)
                Me.m_treeManager.SelectedRow.Tag = doc
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "acctcode"
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
                            e.ProposedValue = ""
                        End If
                        doc.SetItemCode(CStr(e.ProposedValue))
                    Case "cccode"
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
                            e.ProposedValue = ""
                        End If
                        doc.SetItemCCCode(CStr(e.ProposedValue))
                    Case "glfi_mapping"
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
                            e.ProposedValue = ""
                        End If
                        doc.Mapping = CStr(e.ProposedValue)
                    Case "name"
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
                            e.ProposedValue = ""
                        End If
                        doc.Field = New BlankItem(CStr(e.ProposedValue))
                        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                        doc.Field.Name = doc.Field.Name.Replace(myStringParserService.Parse("${res:Global.DebitPrefix}"), "")
                        doc.Field.Name = doc.Field.Name.Replace(myStringParserService.Parse("${res:Global.CreditPrefix}"), "")
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.ToString & ex.StackTrace)
            End Try
        End Sub
        Private Sub GLFItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        End Sub
#End Region


#Region "ISimpleListPanel"
        Public Sub ChangeTitle(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleListPanel.ChangeTitle

        End Sub
        Public Sub CheckFormEnable() Implements ISimplePanel.CheckFormEnable

        End Sub
        Public Sub ClearDetail() Implements ISimplePanel.ClearDetail
            txtCode.Text = ""
            txtName.Text = ""
            txtFormatCode.Text = ""
            txtFormatName.Text = ""
            txtAccountBookCode.Text = ""
            txtAccountBookName.Text = ""
            txtNote.Text = ""
            chkDefault.Checked = False
        End Sub
        Public Sub SetLabelText() Implements ISimplePanel.SetLabelText
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.lblCode}")
            Me.lblAccountBook.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.lblAccountBook}")
            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.lblItem}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.grbGl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.grbGl}")
            Me.chkDefault.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.chkDefault}")
            Me.lblFormat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.lblPost1}")
            Me.lblPost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.lblPost}")
            Me.grbPostGl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LinkGLDetail.grbPostGl}")
        End Sub
        Protected Sub EventWiring()
            AddHandler txtFormatCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtFormatName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtAccountBookCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
            AddHandler chkDefault.CheckedChanged, AddressOf Me.ChangeProperty
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            txtCode.Text = m_entity.LinkGL.Code
            txtName.Text = m_entity.LinkGL.Name
            txtNote.Text = m_entity.Note

            If Not m_entity.AccountBook Is Nothing Then
                txtAccountBookCode.Text = m_entity.AccountBook.Code
                txtAccountBookName.Text = m_entity.AccountBook.Name
            End If

            Me.chkDefault.Checked = Me.m_entity.IsDefault
            Me.chkDefault.Enabled = Not Me.m_entity.IsDefault

            txtFormatCode.Text = m_entity.Code
            txtFormatName.Text = m_entity.Name

            RefreshDocs()

            'Hack
            Me.IsDirty = False

            SetStatus()
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
                Case "txtformatcode"
                    Me.m_entity.Code = txtFormatCode.Text
                    dirtyFlag = True
                Case "txtformatname"
                    Me.m_entity.Name = txtFormatName.Text
                    dirtyFlag = True
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True
                Case "txtaccountbookcode"
                    dirtyFlag = AccountBook.GetAccountBook(txtAccountBookCode, txtAccountBookName, Me.m_entity.AccountBook)
                Case "chkdefault"
                    Me.m_entity.IsDefault = Me.chkDefault.Checked
                    dirtyFlag = True
            End Select
            If Not Me.WorkbenchWindow Is Nothing Then
                Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            End If
            CheckFormEnable()
        End Sub
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If e.Name = "ItemChanged" Then
                If Not Me.WorkbenchWindow Is Nothing Then
                    Me.WorkbenchWindow.ViewContent.IsDirty = True
                End If
            End If
        End Sub
        Private Sub RefreshDocs()
            Try
                Dim flag As Boolean = Me.m_isInitialized
                Me.m_treeManager.Treetable.Clear()
                Me.m_treemanager2.Treetable.Clear()
        If Me.m_entity.Originated OrElse IsNewEntity Then
          IsNewEntity = False
          Me.m_isInitialized = False
          Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
          RefreshBlankGrid()
          ReIndex()
          Me.m_treeManager.Treetable.AcceptChanges()
          Dim glf As New GLFormat(Me.m_entity.LinkGL)
          glf.ItemCollection.Populate(m_treemanager2.Treetable)
        End If
                Me.m_isInitialized = flag
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Private Sub ReIndex()
            Dim i As Integer = 0
            For Each row As DataRow In Me.m_treeManager.Treetable.Rows
                row("glfi_linenumber") = i + 1
                i += 1
            Next
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

        End Sub

        Public ReadOnly Property Title() As String Implements ISimplePanel.Title
            Get
                If Not m_entity Is Nothing Then
                    Return Me.m_entity.ListPanelTitle
                End If
            End Get
        End Property
        Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)

            End Set
        End Property

        Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged
    Dim IsNewEntity As Boolean = False
    Public Sub AddNew() Implements ISimpleListPanel.AddNew
      Dim node As TreeNode = Me.tvLinkGL.SelectedNode
      If node Is Nothing Then
        Return
      End If
      If TypeOf node.Tag Is IdValuePair Then
        Dim item As IdValuePair = CType(node.Tag, IdValuePair)
        Select Case item.Value.ToLower
          Case "linkgl"
            Dim glf As New GLFormat(New LinkGL(item.Id))
            Dim newNode As TreeNode = node.Nodes.Add("<NEW>")
            newNode.Tag = New IdValuePair(glf.Id, "glformat")
            IsNewEntity = True
            Me.SelectedEntity = glf
            Me.tvLinkGL.SelectedNode = newNode
            Return
          Case "glformat"
            Dim parentItem As IdValuePair = CType(node.Parent.Tag, IdValuePair)
            Dim glf As New GLFormat(New LinkGL(parentItem.Id))
            Dim newNode As TreeNode = node.Parent.Nodes.Add("<NEW>")
            newNode.Tag = New IdValuePair(glf.Id, "glformat")
            IsNewEntity = True
            Me.SelectedEntity = glf
            Me.tvLinkGL.SelectedNode = newNode
            Return
        End Select
      End If
      ToggleVisibility(False)
    End Sub

        Private Sub OnEntitySelected(ByVal entity As ISimpleEntity)
            RaiseEvent EntitySelected(entity)
        End Sub
        Public Event EntitySelected(ByVal entity As BusinessLogic.ISimpleEntity) Implements ISimpleListPanel.EntitySelected

        Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData

        End Sub

        Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)
                If Not m_entity Is Nothing Then
                    RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
                    Me.m_entity = Nothing
                End If
                If Not Value Is Nothing Then
                    Me.m_entity = CType(Value, GLFormat)
                    'Hack:
                    Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                End If
                UpdateEntityProperties()
            End Set
        End Property
        Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
            Get

            End Get
        End Property

        Public Sub Initialize() Implements ISimplePanel.Initialize

        End Sub
#End Region

#Region "Event Handlers"
        Private Sub ToggleVisibility(ByVal show As Boolean)
            If Not show Then
                For Each ctrl As Control In Me.grbPostGl.Controls
                    ctrl.Enabled = False
                Next
                For Each ctrl As Control In Me.grbItem.Controls
                    ctrl.Enabled = False
                Next
                Me.tgItem.Enabled = True
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = True
                Next
                Me.ErrorProvider1.SetError(Me.txtAccountBookCode, "")
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.ErrorProvider1.SetError(Me.txtName, "")
            Else
                For Each ctrl As Control In Me.grbPostGl.Controls
                    ctrl.Enabled = CBool(m_enableState(ctrl))
                Next
                For Each ctrl As Control In Me.grbItem.Controls
                    ctrl.Enabled = CBool(m_enableState(ctrl))
                Next
                For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                Next
            End If
            Me.ibtnGetDefault.Enabled = show
        End Sub
        Private Sub tvLinkGL_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvLinkGL.BeforeSelect
            If Me.IsDirty Then
                Dim resourceService As resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), resourceService)
                Dim dr As DialogResult = MessageBox.Show(resourceService.GetString("MainWindow.SaveChangesMessage"), resourceService.GetString("MainWindow.SaveChangesMessageHeader") + " " + WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.TitleName + " ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case dr
                    Case DialogResult.Yes
                        Dim myEntityUtilityService As EntityUtilityService = CType(ServiceManager.Services.GetService(GetType(EntityUtilityService)), EntityUtilityService)
                        myEntityUtilityService.ObservedSave(New EntityOperationDelegate(AddressOf Me.Save), CType(Me, ISimpleListPanel).SelectedEntity)
                    Case DialogResult.No
                        Me.IsDirty = False
                    Case DialogResult.Cancel
                        e.Cancel = True
                        Return
                End Select
            End If
            If Me.tvLinkGL.SelectedNode Is Nothing OrElse Not TypeOf Me.tvLinkGL.SelectedNode.Tag Is IdValuePair Then
                Return
            End If
            Dim item As IdValuePair = CType(Me.tvLinkGL.SelectedNode.Tag, IdValuePair)
            If item.Value = "glformat" And item.Id = 0 Then
                Me.tvLinkGL.SelectedNode.Remove()
            End If
        End Sub
        Private Sub tvLinkGL_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvLinkGL.AfterSelect
            If TypeOf e.Node.Tag Is IdValuePair Then
                Dim item As IdValuePair = CType(e.Node.Tag, IdValuePair)
                Select Case item.Value.ToLower
                    Case "glformat"
                        If item.Id > 0 Then
                            Me.SelectedEntity = New GLFormat(item.Id)
                        End If
                        'If e.Node.Parent.Nodes.IndexOf(e.Node) = 0 Then
                        '    ToggleVisibility(False)
                        'Else
                        '    ToggleVisibility(True)
                        'End If
                        ToggleVisibility(True)
                    Case "linkgl"
                        Dim glf As New GLFormat(New LinkGL(item.Id))
                        Me.SelectedEntity = glf
                        ToggleVisibility(False)
                    Case Else
                        ToggleVisibility(False)
                End Select
            Else
                Me.m_isInitialized = False
                ClearDetail()
                Me.m_isInitialized = True
                Me.SelectedEntity = Nothing
                ToggleVisibility(False)
            End If
            WorkbenchSingleton.Workbench.RedrawAllComponents()
        End Sub
        Private Sub tvLinkGL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvLinkGL.DoubleClick
            If SelectedEntity Is Nothing Then
                Return
            End If
            Me.OnEntitySelected(Me.SelectedEntity)
            If Not Me.FindForm Is Nothing AndAlso TypeOf Me.FindForm Is Gui.Dialogs.PanelDialog Then
                Me.FindForm.Close()
            End If
        End Sub
        Public Sub AccountButtonClick(ByVal e As ButtonColumnEventArgs)
            'Dim fieldType As Object = Me.m_entity.ItemTable.Rows(e.Row)("glfi_fieldtype")
            ''Hack: hard-coded
            'If IsDBNull(fieldType) OrElse CInt(fieldType) = 2 OrElse CInt(fieldType) = 3 Then
            '    Return
            'End If
            Dim doc As GLFormatItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            If doc.FieldType Is Nothing _
            OrElse doc.FieldType.Value = 2 _
            OrElse doc.FieldType.Value = 3 Then
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(m_dummyAccount, AddressOf SetAccount)
        End Sub
        Private Sub SetAccount(ByVal acct As ISimpleEntity)
            Me.m_treeManager.SelectedRow("AcctCode") = acct.Code
        End Sub
        Public Sub CCButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCC)
        End Sub
        Private Sub SetCC(ByVal cc As ISimpleEntity)
            Me.m_treeManager.SelectedRow("CCCode") = cc.Code
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.ItemCollection.Count - 1 Then
                Return
            End If
            Dim glfi As New GLFormatItem
            glfi.Field = New BlankItem("")
            glfi.FieldType = New GLFormatItemType(1)
            Me.m_entity.ItemCollection.Insert(index, glfi)
            RefreshDocs()
            tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            If index > Me.m_entity.ItemCollection.Count - 1 Then
                Return
            End If
            Me.m_entity.ItemCollection.Remove(index)
            Me.tgItem.CurrentRowIndex = index
            RefreshDocs()
            If Not Me.WorkbenchWindow Is Nothing Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Private Sub ibtnToggleDebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnToggleDebit.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Dim doc As GLFormatItem = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            doc.IsDebit = Not doc.IsDebit
            RefreshDocs()
            tgItem.CurrentRowIndex = index
            If Not Me.WorkbenchWindow Is Nothing Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Private Sub ibtnGetDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnGetDefault.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Dim index2 As Integer = Me.tgDefault.CurrentRowIndex
            Dim doc As GLFormatItem = Me.CurrentItem
            If doc Is Nothing Then
                doc = New GLFormatItem
                Me.m_entity.ItemCollection.Add(doc)
                Me.m_treeManager.SelectedRow.Tag = doc
            End If
            Dim doc2 As GLFormatItem = Me.CurrentItem2
            If doc2 Is Nothing Then
                Return
            End If
            doc2.CloneTo(doc)
            RefreshDocs()
            tgItem.CurrentRowIndex = index
            tgDefault.CurrentRowIndex = index2
            If Not Me.WorkbenchWindow Is Nothing Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Private Sub LinkGLDetail_Saved(ByVal sender As Object, ByVal e As SaveEventArgs) Handles MyBase.Saved
            If Not e.Successful Then
                Return
            End If
            Me.tvLinkGL.SelectedNode.Text = Me.m_entity.Code & " - " & Me.m_entity.Name
            Me.tvLinkGL.SelectedNode.Tag = New IdValuePair(Me.m_entity.Id, "glformat")
            Me.chkDefault.Enabled = Not Me.m_entity.IsDefault
        End Sub
        Private Sub ibtnShowAccountBookDialog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowAccountBookDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBook)
        End Sub
        Private Sub ibtnShowAccountBook_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowAccountBook.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New AccountBook)
        End Sub
        Public Sub SetAccountBook(ByVal e As ISimpleEntity)
            Dim dirtyFlag As Boolean
            Me.txtAccountBookCode.Text = e.Code
            dirtyFlag = AccountBook.GetAccountBook(txtAccountBookCode, txtAccountBookName, Me.m_entity.AccountBook)
            If Not Me.WorkbenchWindow Is Nothing Then
                Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            End If
        End Sub
#End Region

#Region "Overrides"
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Return Me.m_entity.ListPanelTitle
            End Get
        End Property
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnableDelete() As Boolean
            Get
                Dim node As TreeNode = Me.tvLinkGL.SelectedNode
                If node Is Nothing Then
                    Return False
                End If
                If Not TypeOf node.Tag Is IdValuePair Then
                    Return False
                End If
                Dim item As IdValuePair = CType(node.Tag, IdValuePair)
                If item.Value <> "glformat" Then
                    Return False
                End If
                If m_entity Is Nothing Then
                    Return False
                End If
                Return Not Me.m_entity.IsDefault
            End Get
        End Property
        Public Overrides Sub Delete(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim msg As String = Me.m_entity.Delete.Message
            If Not IsNumeric(msg) Then
                MessageBox.Show(msg)
                Return
            End If
            If Not Me.tvLinkGL.SelectedNode Is Nothing Then
                Me.tvLinkGL.SelectedNode.Remove()
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessage("${res:Global.Deleted}")
        End Sub
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((m_dummyAccount).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "tgitem"
                            Return True
                    End Select
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.ActiveControl Is Nothing Then
                Return
            End If
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((m_dummyAccount).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((m_dummyAccount).FullClassName))
                Dim entity As New Account(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "tgitem"
                        Me.SetAccount(entity)
                End Select
            End If
        End Sub
#End Region

#Region "IPrintable"
        Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
            Get
                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
                'Dim thePath As String = FormPath & Path.DirectorySeparatorChar & m_payment.ClassName & ".xml"
                Dim thePath As String = FormPath & Path.DirectorySeparatorChar & "RptLinkGL.xml"
                Dim df As New DesignerForm(thePath, New LinkGL)
                Return df.PrintDocument
            End Get
        End Property
        Public Overrides ReadOnly Property CanPrint() As Boolean
            Get
                Return True
            End Get
        End Property
#End Region

#Region "Grid Resizing"
        Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Me.m_entity Is Nothing Then
                Return
            End If
            RefreshBlankGrid()
            ReIndex()
        End Sub
        Private Sub RefreshBlankGrid()
            If Me.tgItem.Height = 0 Then
                Return
            End If
            Dim dirtyFlag As Boolean
            If Not Me.WorkbenchWindow Is Nothing Then
                dirtyFlag = Me.WorkbenchWindow.ViewContent.IsDirty
            End If
            Dim index As Integer = tgItem.CurrentRowIndex
            Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
                'เพิ่มแถวจนเต็ม
                Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
            Loop
            If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
                'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
                Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
            End If

            Me.m_treeManager.Treetable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            If Not Me.WorkbenchWindow Is Nothing Then
                Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
            End If
        End Sub
#End Region

    End Class
End Namespace