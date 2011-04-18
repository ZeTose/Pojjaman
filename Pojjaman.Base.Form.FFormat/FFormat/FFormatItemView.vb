Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class FFormatItemView
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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblFontName As System.Windows.Forms.Label
    Friend WithEvents txtFontName As System.Windows.Forms.TextBox
    Friend WithEvents grbFormat As System.Windows.Forms.GroupBox
    Friend WithEvents lblFontStyle As System.Windows.Forms.Label
    Friend WithEvents txtFontStyle As System.Windows.Forms.TextBox
    Friend WithEvents lblFontSize As System.Windows.Forms.Label
    Friend WithEvents txtFontSize As System.Windows.Forms.TextBox
    Friend WithEvents ibtnFont As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbUnderline As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnderline As System.Windows.Forms.Label
    Friend WithEvents ibtnIncIndent As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDecIndent As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyColumn As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblIndention As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FFormatItemView))
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.txtFontName = New System.Windows.Forms.TextBox()
      Me.txtFontStyle = New System.Windows.Forms.TextBox()
      Me.txtFontSize = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblName = New System.Windows.Forms.Label()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.cmbType = New System.Windows.Forms.ComboBox()
      Me.lblType = New System.Windows.Forms.Label()
      Me.lblFontName = New System.Windows.Forms.Label()
      Me.grbFormat = New System.Windows.Forms.GroupBox()
      Me.lblFontStyle = New System.Windows.Forms.Label()
      Me.lblFontSize = New System.Windows.Forms.Label()
      Me.ibtnFont = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbUnderline = New System.Windows.Forms.ComboBox()
      Me.lblUnderline = New System.Windows.Forms.Label()
      Me.ibtnIncIndent = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDecIndent = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblIndention = New System.Windows.Forms.Label()
      Me.ibtnCopyColumn = New Longkong.Pojjaman.Gui.Components.ImageButton()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFormat.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 104)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(64, 18)
      Me.lblItem.TabIndex = 12
      Me.lblItem.Text = "รายการ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Enabled = False
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(96, 15)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(88, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.TabStop = False
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Enabled = False
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(96, 39)
      Me.txtName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, False)
      Me.txtName.Size = New System.Drawing.Size(288, 21)
      Me.txtName.TabIndex = 2
      Me.txtName.TabStop = False
      '
      'txtFontName
      '
      Me.Validator.SetDataType(Me.txtFontName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFontName, "")
      Me.txtFontName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFontName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFontName, System.Drawing.Color.Empty)
      Me.txtFontName.Location = New System.Drawing.Point(72, 15)
      Me.txtFontName.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtFontName, "")
      Me.txtFontName.Name = "txtFontName"
      Me.txtFontName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFontName, "")
      Me.Validator.SetRequired(Me.txtFontName, False)
      Me.txtFontName.Size = New System.Drawing.Size(160, 21)
      Me.txtFontName.TabIndex = 4
      Me.txtFontName.TabStop = False
      '
      'txtFontStyle
      '
      Me.Validator.SetDataType(Me.txtFontStyle, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFontStyle, "")
      Me.txtFontStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFontStyle, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFontStyle, System.Drawing.Color.Empty)
      Me.txtFontStyle.Location = New System.Drawing.Point(72, 39)
      Me.txtFontStyle.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtFontStyle, "")
      Me.txtFontStyle.Name = "txtFontStyle"
      Me.txtFontStyle.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFontStyle, "")
      Me.Validator.SetRequired(Me.txtFontStyle, False)
      Me.txtFontStyle.Size = New System.Drawing.Size(160, 21)
      Me.txtFontStyle.TabIndex = 5
      Me.txtFontStyle.TabStop = False
      '
      'txtFontSize
      '
      Me.Validator.SetDataType(Me.txtFontSize, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFontSize, "")
      Me.txtFontSize.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFontSize, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFontSize, System.Drawing.Color.Empty)
      Me.txtFontSize.Location = New System.Drawing.Point(72, 63)
      Me.txtFontSize.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtFontSize, "")
      Me.txtFontSize.Name = "txtFontSize"
      Me.txtFontSize.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFontSize, "")
      Me.Validator.SetRequired(Me.txtFontSize, False)
      Me.txtFontSize.Size = New System.Drawing.Size(160, 21)
      Me.txtFontSize.TabIndex = 6
      Me.txtFontSize.TabStop = False
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 9
      Me.lblCode.Text = "เลขที่:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(16, 40)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(80, 18)
      Me.lblName.TabIndex = 11
      Me.lblName.Text = "ชื่อรายงาน:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(120, 96)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 4
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(144, 96)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 5
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = False
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 120)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(792, 272)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'cmbType
      '
      Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbType.Enabled = False
      Me.cmbType.Location = New System.Drawing.Point(264, 16)
      Me.cmbType.Name = "cmbType"
      Me.cmbType.Size = New System.Drawing.Size(121, 21)
      Me.cmbType.TabIndex = 1
      '
      'lblType
      '
      Me.lblType.Enabled = False
      Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblType.ForeColor = System.Drawing.Color.Black
      Me.lblType.Location = New System.Drawing.Point(208, 16)
      Me.lblType.Name = "lblType"
      Me.lblType.Size = New System.Drawing.Size(56, 18)
      Me.lblType.TabIndex = 10
      Me.lblType.Text = "ประเภท:"
      Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFontName
      '
      Me.lblFontName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFontName.ForeColor = System.Drawing.Color.Black
      Me.lblFontName.Location = New System.Drawing.Point(8, 16)
      Me.lblFontName.Name = "lblFontName"
      Me.lblFontName.Size = New System.Drawing.Size(64, 18)
      Me.lblFontName.TabIndex = 1
      Me.lblFontName.Text = "Font Name:"
      Me.lblFontName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbFormat
      '
      Me.grbFormat.Controls.Add(Me.lblFontName)
      Me.grbFormat.Controls.Add(Me.txtFontName)
      Me.grbFormat.Controls.Add(Me.lblFontStyle)
      Me.grbFormat.Controls.Add(Me.txtFontStyle)
      Me.grbFormat.Controls.Add(Me.lblFontSize)
      Me.grbFormat.Controls.Add(Me.txtFontSize)
      Me.grbFormat.Controls.Add(Me.ibtnFont)
      Me.grbFormat.Controls.Add(Me.cmbUnderline)
      Me.grbFormat.Controls.Add(Me.lblUnderline)
      Me.grbFormat.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbFormat.Location = New System.Drawing.Point(400, 8)
      Me.grbFormat.Name = "grbFormat"
      Me.grbFormat.Size = New System.Drawing.Size(392, 96)
      Me.grbFormat.TabIndex = 3
      Me.grbFormat.TabStop = False
      Me.grbFormat.Text = "Format"
      '
      'lblFontStyle
      '
      Me.lblFontStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFontStyle.ForeColor = System.Drawing.Color.Black
      Me.lblFontStyle.Location = New System.Drawing.Point(8, 40)
      Me.lblFontStyle.Name = "lblFontStyle"
      Me.lblFontStyle.Size = New System.Drawing.Size(64, 18)
      Me.lblFontStyle.TabIndex = 2
      Me.lblFontStyle.Text = "Font Style:"
      Me.lblFontStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFontSize
      '
      Me.lblFontSize.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFontSize.ForeColor = System.Drawing.Color.Black
      Me.lblFontSize.Location = New System.Drawing.Point(8, 64)
      Me.lblFontSize.Name = "lblFontSize"
      Me.lblFontSize.Size = New System.Drawing.Size(64, 18)
      Me.lblFontSize.TabIndex = 3
      Me.lblFontSize.Text = "Size:"
      Me.lblFontSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnFont
      '
      Me.ibtnFont.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnFont.Location = New System.Drawing.Point(232, 13)
      Me.ibtnFont.Name = "ibtnFont"
      Me.ibtnFont.Size = New System.Drawing.Size(24, 24)
      Me.ibtnFont.TabIndex = 7
      Me.ibtnFont.TabStop = False
      Me.ibtnFont.ThemedImage = CType(resources.GetObject("ibtnFont.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbUnderline
      '
      Me.cmbUnderline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUnderline.Location = New System.Drawing.Point(272, 32)
      Me.cmbUnderline.Name = "cmbUnderline"
      Me.cmbUnderline.Size = New System.Drawing.Size(112, 21)
      Me.cmbUnderline.TabIndex = 0
      '
      'lblUnderline
      '
      Me.lblUnderline.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblUnderline.ForeColor = System.Drawing.Color.Black
      Me.lblUnderline.Location = New System.Drawing.Point(272, 16)
      Me.lblUnderline.Name = "lblUnderline"
      Me.lblUnderline.Size = New System.Drawing.Size(56, 18)
      Me.lblUnderline.TabIndex = 8
      Me.lblUnderline.Text = "ขีดเส้นใต้:"
      Me.lblUnderline.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnIncIndent
      '
      Me.ibtnIncIndent.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnIncIndent.Location = New System.Drawing.Point(208, 96)
      Me.ibtnIncIndent.Name = "ibtnIncIndent"
      Me.ibtnIncIndent.Size = New System.Drawing.Size(24, 24)
      Me.ibtnIncIndent.TabIndex = 7
      Me.ibtnIncIndent.TabStop = False
      Me.ibtnIncIndent.ThemedImage = CType(resources.GetObject("ibtnIncIndent.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDecIndent
      '
      Me.ibtnDecIndent.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDecIndent.Location = New System.Drawing.Point(184, 96)
      Me.ibtnDecIndent.Name = "ibtnDecIndent"
      Me.ibtnDecIndent.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDecIndent.TabIndex = 6
      Me.ibtnDecIndent.TabStop = False
      Me.ibtnDecIndent.ThemedImage = CType(resources.GetObject("ibtnDecIndent.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblIndention
      '
      Me.lblIndention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblIndention.ForeColor = System.Drawing.Color.Black
      Me.lblIndention.Location = New System.Drawing.Point(232, 99)
      Me.lblIndention.Name = "lblIndention"
      Me.lblIndention.Size = New System.Drawing.Size(48, 18)
      Me.lblIndention.TabIndex = 3
      Me.lblIndention.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnCopyColumn
      '
      Me.ibtnCopyColumn.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyColumn.Location = New System.Drawing.Point(264, 96)
      Me.ibtnCopyColumn.Name = "ibtnCopyColumn"
      Me.ibtnCopyColumn.Size = New System.Drawing.Size(24, 24)
      Me.ibtnCopyColumn.TabIndex = 13
      Me.ibtnCopyColumn.TabStop = False
      Me.ibtnCopyColumn.ThemedImage = Nothing
      '
      'FFormatItemView
      '
      Me.Controls.Add(Me.ibtnCopyColumn)
      Me.Controls.Add(Me.grbFormat)
      Me.Controls.Add(Me.cmbType)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.txtCode)
      Me.Controls.Add(Me.lblName)
      Me.Controls.Add(Me.txtName)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblType)
      Me.Controls.Add(Me.ibtnIncIndent)
      Me.Controls.Add(Me.ibtnDecIndent)
      Me.Controls.Add(Me.lblIndention)
      Me.Name = "FFormatItemView"
      Me.Size = New System.Drawing.Size(808, 400)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFormat.ResumeLayout(False)
      Me.grbFormat.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As FFormat
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As FFormatItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is FFormatItem Then
          Return Nothing
        End If
        Return CType(row.Tag, FFormatItem)
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      Try
        If Not m_isInitialized Then
          Return
        End If
        If Me.m_treeManager.SelectedRow Is Nothing Then
          Return
        End If
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.m_entity Is Nothing Then
          Return
        End If
        Dim item As FFormatItem = Me.CurrentItem
        If item Is Nothing Then
          item = New FFormatItem(Me.m_entity)
          Me.m_entity.ItemCollection.Add(item)
          Me.m_treeManager.SelectedRow.Tag = item
        End If
        Select Case e.Column.ColumnName.ToLower
          Case "ffi_style"
            If Not IsDBNull(e.ProposedValue) Then
              item.Style = CStr(e.ProposedValue)
            End If
          Case "ffi_isnewpage"
            If Not IsDBNull(e.ProposedValue) Then
              item.IsNewPage = CBool(e.ProposedValue)
            End If
          Case "ffi_invisible"
            If Not IsDBNull(e.ProposedValue) Then
              item.IsInvisible = CBool(e.ProposedValue)
            End If
          Case "ffi_linestyle"
            If Not IsDBNull(e.ProposedValue) Then
              item.LineStyle = CInt(e.ProposedValue)
            End If
        End Select
        For Each col As FFormatColumn In Me.m_entity.ColumnCollection
          If e.Column.ColumnName.ToLower = "ffi_formula" & col.LineNumber.ToString Then
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            item.DataCollection(col).Formula = CStr(e.ProposedValue)
          End If
        Next
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString & ex.StackTrace)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      ''Dim proposedCode As Object = e.Row("ffi_code")
      'Dim proposedName As Object = e.Row("ffi_name")

      'Select Case e.Column.ColumnName.ToLower
      '    Case "ffi_code"
      '        'proposedCode = e.ProposedValue
      '    Case "ffi_name"
      '        proposedName = e.ProposedValue
      '    Case Else
      '        Return
      'End Select

      'If IsDBNull(proposedName) OrElse CStr(proposedName).Length = 0 Then
      '    e.Row.SetColumnError("ffi_name", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
      'Else
      '    e.Row.SetColumnError("ffi_name", "")
      'End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Return row.Tag Is Nothing
    End Function
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub

#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 _
      Then
        Me.Enabled = False
      Else
        Me.Enabled = True
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatItemView.lblItem}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatItemView.lblCode}")
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatItemView.lblName}")
      Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatItemView.lblType}")
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

      txtCode.Text = m_entity.Code
      txtName.Text = m_entity.Name

      CodeDescription.ComboSelect(Me.cmbType, Me.m_entity.ReportType)

      Dim dt As TreeTable = m_entity.GetSchemaTable()
      Dim dst As DataGridTableStyle = m_entity.CreateTableStyle()

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      RemoveHandler m_entity.FormulaButtonClicked, AddressOf AccountButtonClicked
      RemoveHandler m_entity.FormulaButtonClicked, AddressOf AccountButtonClicked

      RemoveHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      RemoveHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      RemoveHandler dt.RowDeleted, AddressOf ItemDelete

      RefreshDocs()

      AddHandler m_entity.FormulaButtonClicked, AddressOf AccountButtonClicked
      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf ItemDelete


      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(Me.m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_optionsetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtname"
          Me.m_entity.Name = txtName.Text
          dirtyFlag = True
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()
      'If m_entity.Canceled Then
      '    Me.StatusBarService.SetMessage("ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '    " " & m_entity.CancelDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.CancelPerson.Name)
      'ElseIf m_entity.Edited Then
      '    Me.StatusBarService.SetMessage("แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '    " " & m_entity.LastEditDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.LastEditor.Name)
      'ElseIf m_entity.Originated Then
      '    Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '    " " & m_entity.OriginDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.Originator.Name)
      'Else
      '    Me.StatusBarService.SetMessage("")
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, FFormat)
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      PopulateType()
    End Sub
    Private Sub PopulateType()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "financialstatement_type")
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbUnderline, "line_style")
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemCollection.Count - 1 Then
        Return
      End If
      Me.m_entity.ItemCollection.Insert(index, New FFormatItem(Me.m_entity))
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
      , Me.m_treeManager.Treetable.Columns("ffi_code") _
      , Me.CurrentItem.Code)
      Me.ValidateRow(re)
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      If row Is Nothing Then
        Return
      End If
      Dim doc As FFormatItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Me.m_entity.ItemCollection.Remove(doc)
      RefreshDocs()
      Me.tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("ffi_linenumber") = i + 1
        i += 1
      Next
    End Sub
    Private m_currentColName As String = ""
    Public Sub AccountButtonClicked(ByVal e As ButtonColumnEventArgs)
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      Dim item As FFormatItem = Me.CurrentItem
      m_currentColName = "ffi_formula" & CStr(e.Column / 2)
      If item Is Nothing Then
        Return
      End If
      If Not Me.m_treeManager.Treetable.Columns.Contains(m_currentColName) Then
        Return
      End If
      Dim filters(0) As Filter
      filters(0) = New Filter("CodeList", GenIDListFromDataTable(theRow, m_currentColName))
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccts, filters, Nothing)
    End Sub
    Private Sub SetAccts(ByVal items As BasketItemCollection)
      Dim acctList As String = ""
      For i As Integer = 0 To items.Count - 1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim myItem As New Account(item.Id)
        If myItem.IsControlGroup Then
          ' ToDo :
        Else
          acctList += "|" & myItem.Code & "|"
        End If
      Next
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      theRow(m_currentColName) = acctList
      Me.m_treeManager.Treetable.AcceptChanges()
      'RefreshBlankGrid()
    End Sub
    Private Function GenIDListFromDataTable(ByVal theRow As TreeRow, ByVal colName As String) As String
      Dim idlist As String = ""
      Me.m_treeManager.Treetable.AcceptChanges()
      For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
        If Not row Is theRow Then
          If Not row.IsNull(colName) Then
            Dim formula As String = CStr(row(colName))
            idlist += formula
          End If
        End If
      Next
      Return idlist
    End Function
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides Sub NotifyBeforeSave()

    End Sub
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New PR).DetailPanelIcon
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
#End Region

#Region "Event of Button controls"
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      WorkbenchSingleton.Workbench.RedrawEditComponents()
      Dim item As FFormatItem = Me.CurrentItem
      If item Is Nothing Then
        Return
      End If
      Dim colIndex As Integer = tgItem.CurrentCell.ColumnNumber
      colIndex = CInt((colIndex + 1) / 2)
      Dim theDat As FFormatData = item.DataCollection(m_entity.ColumnCollection(colIndex))
      If theDat Is Nothing Then
        Return
      End If
      Dim f As Font = FFormat.StringToFont(theDat.Style)
      Me.txtFontName.Text = f.FontFamily.Name
      Me.txtFontSize.Text = f.Size
      Me.txtFontStyle.Text = f.Style.ToString
      Me.lblIndention.Text = theDat.Indentation.ToString
      Dim flg As Boolean
      flg = Me.m_isInitialized
      Me.m_isInitialized = False
      CodeDescription.ComboSelect(Me.cmbUnderline, New CodeDescription(theDat.Linestyle))
      Me.m_isInitialized = flg
    End Sub
    Private ReadOnly Property StandardFont() As Font
      Get
        Return New Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      End Get
    End Property
    Public Sub SetFontStyle()
      Dim colIndex As Integer = tgItem.CurrentCell.ColumnNumber
      colIndex = CInt((colIndex + 1) / 2)
      Dim item As FFormatItem = Me.CurrentItem
      If item Is Nothing Then
        item = New FFormatItem(Me.m_entity)
        Me.m_entity.ItemCollection.Add(item)
        Me.m_treeManager.SelectedRow.Tag = item
      End If
      Dim theDat As FFormatData = item.DataCollection(m_entity.ColumnCollection(colIndex))
      Dim fnt As System.Drawing.Font
      Dim dialog As New FontDialog
      With dialog
        .MinSize = 6
        .MaxSize = 72
        .Font = FFormat.StringToFont(theDat.Style)
        If .ShowDialog = DialogResult.OK Then
          fnt = .Font
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      End With
      theDat.Style = FFormat.FontToString(fnt)
      tgItem_CurrentCellChanged(Nothing, Nothing)
    End Sub
    Private Sub ibtnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnFont.Click
      SetFontStyle()
    End Sub
    Private Sub ibtnDecIndent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDecIndent.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim colIndex As Integer = tgItem.CurrentCell.ColumnNumber
      colIndex = CInt((colIndex + 1) / 2)
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim item As FFormatItem = Me.CurrentItem
      If Me.CurrentItem Is Nothing Then
        item = New FFormatItem(Me.m_entity)
        Me.m_entity.ItemCollection.Add(item)
        Me.m_treeManager.SelectedRow.Tag = item
      End If
      Dim theDat As FFormatData = item.DataCollection(m_entity.ColumnCollection(colIndex))
      If theDat Is Nothing Then
        Return
      End If
      If theDat.Indentation > 0 Then
        theDat.Indentation -= 1
      End If
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      Me.m_treeManager.SelectedRow("ffi_formula" & (colIndex).ToString) = theDat.FormulaText
      Me.lblIndention.Text = theDat.Indentation.ToString
      Me.tgItem.CurrentRowIndex = index
      m_isInitialized = flag
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnIncIndent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnIncIndent.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim colIndex As Integer = tgItem.CurrentCell.ColumnNumber
      colIndex = CInt((colIndex + 1) / 2)
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim item As FFormatItem = Me.CurrentItem
      If Me.CurrentItem Is Nothing Then
        item = New FFormatItem(Me.m_entity)
        Me.m_entity.ItemCollection.Add(item)
        Me.m_treeManager.SelectedRow.Tag = item
      End If
      Dim theDat As FFormatData = item.DataCollection(m_entity.ColumnCollection(colIndex))
      If theDat Is Nothing Then
        Return
      End If
      theDat.Indentation += 1
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      Me.m_treeManager.SelectedRow("ffi_formula" & (colIndex).ToString) = theDat.FormulaText
      Me.lblIndention.Text = theDat.Indentation.ToString
      Me.tgItem.CurrentRowIndex = index
      m_isInitialized = flag
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub cmbUnderline_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUnderline.SelectedIndexChanged
      If Not m_isInitialized Then
        Return
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim colIndex As Integer = tgItem.CurrentCell.ColumnNumber
      colIndex = CInt((colIndex + 1) / 2)
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim item As FFormatItem = Me.CurrentItem
      If Me.CurrentItem Is Nothing Then
        item = New FFormatItem(Me.m_entity)
        Me.m_entity.ItemCollection.Add(item)
        Me.m_treeManager.SelectedRow.Tag = item
      End If
      Dim theDat As FFormatData = item.DataCollection(m_entity.ColumnCollection(colIndex))
      If theDat Is Nothing Then
        Return
      End If
      If TypeOf Me.cmbUnderline.SelectedItem Is IdValuePair Then
        theDat.Linestyle = CType(Me.cmbUnderline.SelectedItem, IdValuePair).Id
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If
      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

      'If Me.tgItem.Height = 0 Then
      '    Return
      'End If
      'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim maxVisibleCount As Integer
      'Dim tgRowHeight As Integer = 17
      'maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      'Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
      '    'เพิ่มแถวจนเต็ม
      '    Me.m_treeManager.Treetable.Childs.Add()
      'Loop
      ''If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
      ''    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
      ''        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      ''        Me.m_treeManager.Treetable.Childs.Add()
      ''    End If
      ''End If
      'Me.m_treeManager.Treetable.AcceptChanges()
      'tgItem.CurrentRowIndex = Math.Max(0, index)
      'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnableCopy() As Boolean
      Get
        Return tgItem.CurrentCell.ColumnNumber <> -1 AndAlso tgItem.CurrentRowIndex <> -1
      End Get
    End Property
    Public Overrides ReadOnly Property EnableCut() As Boolean
      Get
        Return False
      End Get
    End Property
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Return Not IsNothing(m_copiedFdata)
      End Get
    End Property
    Private m_copiedFdata As CopiedFdata
    'Public ReadOnly Property CopiedColl() As String
    '  Get
    '    Return m_copiedFdata
    '  End Get
    'End Property

    Public Overrides Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs)
      'Dim formula As String = m_treeManager.SelectedRow(tgItem.CurrentCell.ColumnNumber + 1).ToString()
      Dim ffdata As New FFormatData
      Dim item As FFormatItem = Me.CurrentItem
      Dim colIndex As Integer = tgItem.CurrentCell.ColumnNumber
      colIndex = CInt((colIndex + 1) / 2)
      Dim theDat As FFormatData = item.DataCollection(m_entity.ColumnCollection(colIndex))
      If theDat Is Nothing Then
        Return
      End If
      'ffdata.Formula = formula
      'ffdata.Style = theDat.Style
      'ffdata.Linestyle = theDat.Linestyle
      'ffdata.Indentation = theDat.Indentation


      m_copiedFdata = New CopiedFdata(theDat, tgItem.CurrentCell.ColumnNumber + 1, tgItem.CurrentRowIndex + 1)
      WorkbenchSingleton.Workbench.RedrawEditComponents()
    End Sub
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If m_copiedFdata Is Nothing Then
        Return
      End If
      Dim item As FFormatItem = Me.CurrentItem

      Dim newcoli As Integer = tgItem.CurrentCell.ColumnNumber + 1
      Dim newrowi As Integer = tgItem.CurrentRowIndex + 1

      Dim ffdata As New FFormatData
      ffdata.Clone(m_copiedFdata.fformatdata)

      If ffdata.IsFormula Then

        ffdata.ShiftFormula(m_copiedFdata.RowIndex, m_copiedFdata.ColIndex, newrowi, newcoli)
      End If

      m_treeManager.SelectedRow(tgItem.CurrentCell.ColumnNumber + 1) = ffdata.Formula

      Dim colIndex As Integer = tgItem.CurrentCell.ColumnNumber
      colIndex = CInt((colIndex + 1) / 2)
      Dim theDat As FFormatData = item.DataCollection(m_entity.ColumnCollection(colIndex))
      If theDat Is Nothing Then
        Return
      End If
      item.DataCollection(m_entity.ColumnCollection(colIndex)).Clone(ffdata)

      Dim f As Font = FFormat.StringToFont(theDat.Style)
      Me.txtFontName.Text = f.FontFamily.Name
      Me.txtFontSize.Text = f.Size
      Me.txtFontStyle.Text = f.Style.ToString
      Me.lblIndention.Text = theDat.Indentation.ToString
      Dim flg As Boolean
      flg = Me.m_isInitialized
      Me.m_isInitialized = False
      CodeDescription.ComboSelect(Me.cmbUnderline, New CodeDescription(theDat.Linestyle))
      Me.m_isInitialized = flg

      WorkbenchSingleton.Workbench.RedrawEditComponents()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

#End Region

    Private Class CopiedFdata
      Sub New(ByVal f As FFormatData, ByVal coli As Decimal, ByVal rowi As Decimal)
        fformatdata = New FFormatData
        Me.fformatdata = f
        Me.ColIndex = coli
        Me.RowIndex = rowi

      End Sub
      Public Property fformatdata As FFormatData
      Public Property ColIndex As Decimal
      Public Property RowIndex As Decimal

    End Class

    Private Sub ibtnCopyColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyColumn.Click

      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CopyCheckListDialog(Me.m_entity.ColumnCollection.GetMaxLine, Me.m_entity.ColumnCollection)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Dim source As Integer = chkdlg.SourceColumn
        Dim listCol As List(Of Integer) = chkdlg.CheckedCopyColumn
        Me.m_entity.CopyColumn(source, listCol)
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        RefreshDocs()
        myContent.IsDirty = True
      End If
    End Sub
  End Class
End Namespace