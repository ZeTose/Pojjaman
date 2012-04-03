Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
'Imports Longkong.Pojjaman.TextHelper
'Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports Longkong.Pojjaman.DataAccessLayer

'Imports System.Globalization
'Imports System.Reflection
'Imports System.Drawing.Printing
Imports System
Imports System.Threading
Imports System.Collections.Generic
Imports System.Data.SqlClient

Imports Syncfusion.Windows.Forms.Grid


Namespace Longkong.Pojjaman.Gui.Panels
  Public Class EntityAutoGenView
    Inherits AbstractEntityPanelViewContent
    'Implements IValidatable, ISimpleListPanel
    'Inherits UserControl

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
    Friend WithEvents ibtnAdd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tgItem As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbGLConfig As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbGLFormat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEntity As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Dim GridBaseStyle1 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle2 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle3 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle4 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridCellInfo1 As Syncfusion.Windows.Forms.Grid.GridCellInfo = New Syncfusion.Windows.Forms.Grid.GridCellInfo()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.btnDelete = New System.Windows.Forms.Button()
      Me.btnSave = New System.Windows.Forms.Button()
      Me.btnNew = New System.Windows.Forms.Button()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmbGLConfig = New System.Windows.Forms.ComboBox()
      Me.txtDescription = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtFormat = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmbGLFormat = New System.Windows.Forms.ComboBox()
      Me.cmbEntity = New System.Windows.Forms.ComboBox()
      Me.tgItem = New Syncfusion.Windows.Forms.Grid.GridControl()
      Me.grbDetail.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.GroupBox1)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(1240, 404)
      Me.grbDetail.TabIndex = 179
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายการ"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.btnDelete)
      Me.GroupBox1.Controls.Add(Me.btnSave)
      Me.GroupBox1.Controls.Add(Me.btnNew)
      Me.GroupBox1.Controls.Add(Me.Label5)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.cmbGLConfig)
      Me.GroupBox1.Controls.Add(Me.txtDescription)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.txtFormat)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.cmbGLFormat)
      Me.GroupBox1.Controls.Add(Me.cmbEntity)
      Me.GroupBox1.Location = New System.Drawing.Point(832, 19)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(402, 311)
      Me.GroupBox1.TabIndex = 11
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Edit"
      '
      'btnDelete
      '
      Me.btnDelete.Location = New System.Drawing.Point(200, 268)
      Me.btnDelete.Name = "btnDelete"
      Me.btnDelete.Size = New System.Drawing.Size(75, 23)
      Me.btnDelete.TabIndex = 16
      Me.btnDelete.Text = "Delete"
      Me.btnDelete.UseVisualStyleBackColor = True
      '
      'btnSave
      '
      Me.btnSave.Location = New System.Drawing.Point(304, 268)
      Me.btnSave.Name = "btnSave"
      Me.btnSave.Size = New System.Drawing.Size(73, 23)
      Me.btnSave.TabIndex = 14
      Me.btnSave.Text = "Save"
      Me.btnSave.UseVisualStyleBackColor = True
      '
      'btnNew
      '
      Me.btnNew.Location = New System.Drawing.Point(96, 268)
      Me.btnNew.Name = "btnNew"
      Me.btnNew.Size = New System.Drawing.Size(75, 23)
      Me.btnNew.TabIndex = 13
      Me.btnNew.Text = "New"
      Me.btnNew.UseVisualStyleBackColor = True
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(8, 192)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(60, 13)
      Me.Label5.TabIndex = 12
      Me.Label5.Text = "Description"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(8, 154)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(67, 13)
      Me.Label4.TabIndex = 10
      Me.Label4.Text = "Code Format"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(8, 115)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(54, 13)
      Me.Label3.TabIndex = 10
      Me.Label3.Text = "GL Config"
      '
      'cmbGLConfig
      '
      Me.cmbGLConfig.FormattingEnabled = True
      Me.cmbGLConfig.Location = New System.Drawing.Point(80, 112)
      Me.cmbGLConfig.Name = "cmbGLConfig"
      Me.cmbGLConfig.Size = New System.Drawing.Size(316, 21)
      Me.cmbGLConfig.TabIndex = 11
      '
      'txtDescription
      '
      Me.txtDescription.AcceptsReturn = True
      Me.txtDescription.Location = New System.Drawing.Point(80, 189)
      Me.txtDescription.Multiline = True
      Me.txtDescription.Name = "txtDescription"
      Me.txtDescription.Size = New System.Drawing.Size(316, 60)
      Me.txtDescription.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(6, 37)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(56, 13)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Document"
      '
      'txtFormat
      '
      Me.txtFormat.Location = New System.Drawing.Point(80, 151)
      Me.txtFormat.Name = "txtFormat"
      Me.txtFormat.Size = New System.Drawing.Size(316, 20)
      Me.txtFormat.TabIndex = 4
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 76)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(56, 13)
      Me.Label2.TabIndex = 7
      Me.Label2.Text = "GL Format"
      '
      'cmbGLFormat
      '
      Me.cmbGLFormat.FormattingEnabled = True
      Me.cmbGLFormat.Location = New System.Drawing.Point(80, 73)
      Me.cmbGLFormat.Name = "cmbGLFormat"
      Me.cmbGLFormat.Size = New System.Drawing.Size(316, 21)
      Me.cmbGLFormat.TabIndex = 9
      '
      'cmbEntity
      '
      Me.cmbEntity.FormattingEnabled = True
      Me.cmbEntity.Location = New System.Drawing.Point(80, 34)
      Me.cmbEntity.Name = "cmbEntity"
      Me.cmbEntity.Size = New System.Drawing.Size(316, 21)
      Me.cmbEntity.TabIndex = 8
      '
      'tgItem
      '
      Me.tgItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      GridBaseStyle1.Name = "Header"
      GridBaseStyle1.StyleInfo.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.Borders.Left = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.CellType = "Header"
      GridBaseStyle1.StyleInfo.Font.Bold = True
      GridBaseStyle1.StyleInfo.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
      GridBaseStyle2.Name = "Standard"
      GridBaseStyle2.StyleInfo.Font.Facename = "Tahoma"
      GridBaseStyle3.Name = "Row Header"
      GridBaseStyle3.StyleInfo.BaseStyle = "Header"
      GridBaseStyle3.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      GridBaseStyle4.Name = "Column Header"
      GridBaseStyle4.StyleInfo.BaseStyle = "Header"
      GridBaseStyle4.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      Me.tgItem.BaseStylesMap.AddRange(New Syncfusion.Windows.Forms.Grid.GridBaseStyle() {GridBaseStyle1, GridBaseStyle2, GridBaseStyle3, GridBaseStyle4})
      Me.tgItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.tgItem.ColCount = 3
      Me.tgItem.DefaultColWidth = 100
      Me.tgItem.DefaultRowHeight = 18
      Me.tgItem.ExcelLikeSelectionFrame = True
      Me.tgItem.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.tgItem.ForeColor = System.Drawing.SystemColors.ControlText
      GridCellInfo1.Col = -1
      GridCellInfo1.Row = -1
      GridCellInfo1.StyleInfo.Font.Bold = False
      GridCellInfo1.StyleInfo.Font.Facename = "Tahoma"
      GridCellInfo1.StyleInfo.Font.Italic = False
      GridCellInfo1.StyleInfo.Font.Size = 8.25!
      GridCellInfo1.StyleInfo.Font.Strikeout = False
      GridCellInfo1.StyleInfo.Font.Underline = False
      GridCellInfo1.StyleInfo.Font.Unit = System.Drawing.GraphicsUnit.Point
      Me.tgItem.GridCells.AddRange(New Syncfusion.Windows.Forms.Grid.GridCellInfo() {GridCellInfo1})
      Me.tgItem.Location = New System.Drawing.Point(3, 19)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Properties.ColHeaders = False
      Me.tgItem.Properties.RowHeaders = False
      Me.tgItem.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.tgItem.RowCount = 20
      Me.tgItem.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeIntoCode
      Me.tgItem.Size = New System.Drawing.Size(823, 379)
      Me.tgItem.SmartSizeBox = False
      Me.tgItem.TabIndex = 3
      Me.tgItem.ThemesEnabled = True
      '
      'EntityAutoGenView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "EntityAutoGenView"
      Me.Size = New System.Drawing.Size(1261, 420)
      Me.grbDetail.ResumeLayout(False)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean

    Private AutoGenList As List(Of EntityAutoGen)

    Private EntityList As List(Of IdValuePair)

    'Private GLFormatList As List(Of IdValuePair)

    Private EntityGLFormat As Dictionary(Of Integer, List(Of IdValuePair))

    Private CurrentFormat As EntityAutoGen
    Private CurrentRow As Integer

#End Region

#Region "Constructors"

    Public Sub New()

      m_isInitialized = False

      InitializeComponent()

      Initialize()

      CurrentFormat = New EntityAutoGen

      m_isInitialized = True

      RefreshEdit(True)

    End Sub

#End Region

#Region "Properties"
    Public Overrides Property TitleName As String
      Get
        Return "Set Entity AutoGen"
      End Get
      Set(ByVal value As String)
        MyBase.TitleName = value
      End Set
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return "Set Entity AutoGen" 'Me.m_entity.ListPanelTitle
      End Get
    End Property
#End Region

#Region "Methods"

    Public Function ValidIdOrDBNull(ByVal entity As SimpleBusinessEntityBase) As Object
      If entity Is Nothing OrElse Not entity.Valid Then
        Return DBNull.Value
      End If
      Return entity.Id
    End Function

    Public Function ValidDateOrDBNull(ByVal myDate As Date) As Object
      If myDate.Equals(Date.MinValue) Then
        Return DBNull.Value
      End If
      Return myDate
    End Function

    Public Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
      If dt.Equals(Date.MinValue) Then
        Return nullString
      End If
      Return dt.ToShortDateString
    End Function

    Public Function MinDateToNow(ByVal dt As Date) As Date
      If dt.Equals(Date.MinValue) Then
        dt = Now
      End If
      Return dt
    End Function

    '-----------------------------------------------------------------------------------------------

    Private Sub Initialize()

      InitGrid()

      PopulateData()

      PopulateComboBox()

      PopulateGrid()

    End Sub

    '-----------------------------------------------------------------------------------------------

    Private Sub InitGrid()

      tgItem.ColCount = 5
      tgItem.RowCount = 1
      tgItem.Rows.HeaderCount = 1
      tgItem.Rows.FrozenCount = 1

      tgItem.ColWidths(1) = 180
      tgItem.ColWidths(2) = 250
      tgItem.ColWidths(3) = 250
      tgItem.ColWidths(4) = 200
      tgItem.ColWidths(5) = 300

      SetGridValue(1, 1, "Document", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 2, "GL Format", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 3, "GL Config", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 4, "Code Format", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 5, "Description", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)


    End Sub

    Private Sub PopulateData()

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
, CommandType.StoredProcedure _
, "GetSetEntityAutoGenInfo")

      AutoGenList = New List(Of EntityAutoGen)

      EntityList = New List(Of IdValuePair)

      'GLFormatList = New List(Of IdValuePair)

      EntityGLFormat = New Dictionary(Of Integer, List(Of IdValuePair))

      Dim ea As EntityAutoGen

      For Each row As DataRow In ds.Tables(0).Rows

        ea = New EntityAutoGen

        ea.EntityFormatId = CInt(row("EntityFormatId"))
        ea.EntityId = CInt(row("EntityId"))
        ea.EntityName = CStr(row("EntityName"))
        If Not row.IsNull("EntityGLId") Then
          ea.EntityGLId = CInt(row("EntityGLId"))
        End If
        ea.EntityGLName = CStr(row("EntityGLName"))
        ea.EntityConfigId = CInt(row("EntityConfigId"))
        ea.EntityConfigName = CStr(row("EntityConfigName"))
        ea.EntityFormat = CStr(row("EntityFormat"))
        ea.EntityNote = CStr(row("EntityNote"))

        AutoGenList.Add(ea)

      Next

      Dim iv As IdValuePair

      For Each row As DataRow In ds.Tables(1).Rows

        iv = New IdValuePair(CInt(row("entity_id")), CStr(row("entity_description")))

        EntityList.Add(iv)

      Next

      Dim Doc As Integer = -1
      Dim currentDoc As Integer = -1

      For Each row As DataRow In ds.Tables(2).Rows

        currentDoc = CInt(row("linkgl_doc"))

        If Doc <> currentDoc Then
          EntityGLFormat.Add(currentDoc, New List(Of IdValuePair))
          Doc = currentDoc
        End If

        EntityGLFormat(Doc).Add(New IdValuePair(CInt(row("glf_id")), CStr(row("glf_name"))))

      Next

    End Sub

    Private Sub PopulateGrid()
      tgItem.RowCount = 1

      For Each ea As EntityAutoGen In AutoGenList

        tgItem.RowCount += 1

        SetGridValue(tgItem.RowCount, 1, ea.EntityName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
        SetGridValue(tgItem.RowCount, 2, ea.EntityGLName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
        SetGridValue(tgItem.RowCount, 3, ea.EntityConfigName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
        SetGridValue(tgItem.RowCount, 4, ea.EntityFormat, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
        SetGridValue(tgItem.RowCount, 5, ea.EntityNote, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
        tgItem(tgItem.RowCount, 1).Tag = ea

      Next

    End Sub

    '-----------------------------------------------------------------------------------------------

    Private Sub PopulateComboBox()

      cmbGLConfig.Items.Clear()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbGLConfig, "entityAuto_Config")
      cmbGLConfig.SelectedIndex = 0

      cmbEntity.Items.Clear()
      For Each iv As IdValuePair In Me.EntityList
        Me.cmbEntity.Items.Add(iv)
      Next
      cmbEntity.SelectedIndex = 0

      cmbGLFormat.Items.Clear()
      Dim nulliv As New IdValuePair(-1, "")
      Me.cmbGLFormat.Items.Add(nulliv)
      cmbGLFormat.SelectedIndex = 0
      If Me.EntityGLFormat.ContainsKey(Me.EntityList(0).Id) Then
        For Each iv As IdValuePair In Me.EntityGLFormat(Me.EntityList(0).Id)
          Me.cmbGLFormat.Items.Add(iv)
        Next
        'If cmbGLFormat.Items.Count > 0 Then
        '  cmbGLFormat.SelectedIndex = 0
        'End If
      End If


    End Sub


    Private Sub SetGridValue(ByVal row As Integer, ByVal col As Integer, ByVal value As String _
, Optional ByVal bold As Boolean = False _
, Optional ByVal hAlign As Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left _
, Optional ByVal vAlign As Syncfusion.Windows.Forms.Grid.GridVerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle)
      tgItem(row, col).HorizontalAlignment = hAlign
      tgItem(row, col).VerticalAlignment = vAlign
      tgItem(row, col).Text = value
      tgItem(row, col).Font.Bold = bold
    End Sub

    '-----------------------------------------------------------------------------------------------

    Private Sub RefreshEdit(isnew As Boolean)

      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False

      Dim i As Integer

      If Not isnew Then
        i = 0
        For Each iv As IdValuePair In cmbEntity.Items

          If iv.Id = CurrentFormat.EntityId Then
            cmbEntity.SelectedIndex = i
            Exit For
          End If

          i += 1
        Next

        cmbGLFormat.Items.Clear()
        Dim nulliv As New IdValuePair(-1, "")
        Me.cmbGLFormat.Items.Add(nulliv)
        cmbGLFormat.SelectedIndex = 0

        If Me.EntityGLFormat.ContainsKey(CType(Me.cmbEntity.SelectedItem, IdValuePair).Id) Then

          For Each iv As IdValuePair In Me.EntityGLFormat(CType(Me.cmbEntity.SelectedItem, IdValuePair).Id)
            Me.cmbGLFormat.Items.Add(iv)
          Next
          If cmbGLFormat.Items.Count > 0 Then
            'cmbGLFormat.SelectedIndex = 0
            i = 0
            For Each iv As IdValuePair In cmbGLFormat.Items

              If iv.Id = CurrentFormat.EntityGLId Then
                cmbGLFormat.SelectedIndex = i
                Exit For
              End If

              i += 1
            Next

          End If
        End If

        i = 0
        For Each iv As IdValuePair In cmbGLConfig.Items

          If iv.Id = CurrentFormat.EntityConfigId Then
            cmbGLConfig.SelectedIndex = i
            Exit For
          End If

          i += 1
        Next

        txtFormat.Text = CurrentFormat.EntityFormat

        txtDescription.Text = CurrentFormat.EntityNote

      Else

        cmbEntity.SelectedIndex = 0

        cmbGLFormat.Items.Clear()
        Dim nulliv As New IdValuePair(-1, "")
        Me.cmbGLFormat.Items.Add(nulliv)
        cmbGLFormat.SelectedIndex = 0

        If Me.EntityGLFormat.ContainsKey(Me.EntityList(0).Id) Then
          For Each iv As IdValuePair In Me.EntityGLFormat(Me.EntityList(0).Id)
            Me.cmbGLFormat.Items.Add(iv)
          Next
          'If cmbGLFormat.Items.Count > 0 Then
          '  cmbGLFormat.SelectedIndex = 0
          'End If
        End If

        cmbGLConfig.SelectedIndex = 0

        txtFormat.Text = ""

        txtDescription.Text = ""

      End If

      If CurrentFormat.EntityFormatId = -1 Then
        btnDelete.Enabled = False
      Else
        btnDelete.Enabled = True
      End If



      m_isInitialized = flag

    End Sub

#End Region

#Region "Style"
    'Private Function GetLockingComboTable() As DataTable
    '  Dim dt As New DataTable
    '  dt.Columns.Add(New DataColumn("Value"))
    '  dt.Columns.Add(New DataColumn("Description"))

    '  Dim row As DataRow = dt.NewRow
    '  row("Value") = 0
    '  row("Description") = "No Lock"
    '  dt.Rows.Add(row)

    '  row = dt.NewRow
    '  row("Value") = 1
    '  row("Description") = "GL Lock"
    '  dt.Rows.Add(row)

    '  row = dt.NewRow
    '  row("Value") = 2
    '  row("Description") = "All Lock"
    '  dt.Rows.Add(row)

    '  Return dt
    'End Function
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "StockSequence"
      Dim widths As New ArrayList
      Dim iCol As Integer = 10 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

      widths.Add(100)
      widths.Add(200)
      widths.Add(150)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(120)
      widths.Add(120)
      widths.Add(120)
      widths.Add(120)

      For i As Integer = 0 To iCol
        If i = 1 Then
          Dim cs As New PlusMinusTreeTextColumn
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          cs.ReadOnly = True
          cs.Format = "s"
          'AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        Else
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          'If Me.m_showDetailInGrid <> 0 Then
          '  Select Case i
          '    Case 0, 1, 2
          '      cs.Alignment = HorizontalAlignment.Left
          '      cs.DataAlignment = HorizontalAlignment.Left
          '      cs.Format = "s"
          '    Case Else
          '      cs.Alignment = HorizontalAlignment.Right
          '      cs.DataAlignment = HorizontalAlignment.Right
          '      cs.Format = "d"
          '  End Select
          'Else
          '  Select Case i
          '    Case 0, 1
          '      cs.Alignment = HorizontalAlignment.Left
          '      cs.DataAlignment = HorizontalAlignment.Left
          '      cs.Format = "s"
          '    Case Else
          '      cs.Alignment = HorizontalAlignment.Right
          '      cs.DataAlignment = HorizontalAlignment.Right
          '      cs.Format = "d"
          '  End Select
          'End If

          cs.ReadOnly = True

          'AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        End If
      Next

      Return dst
    End Function
    Public Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Report")
      myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col6", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col7", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Event Handlers"

#End Region

#Region "Overrides"
    'Public Overrides ReadOnly Property TabPageText() As String
    'Get
    'Return Me.m_entity.ListPanelTitle
    'End Get
    'End Property
    'Public Overloads Overrides Sub Save()
    'OnSaving(New EventArgs)
    'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    'Dim currentUserId As Integer = currentUserId
    ''If SecurityService.CurrentUser Is Nothing Then
    ''  msgServ.ShowMessage("${res:Global.Error.NoUser}")
    ''  Me.OnSaved(New SaveEventArgs(False))
    ''  SecurityService.UpdateAccessTable()
    ''  WorkbenchSingleton.Workbench.RedrawEditComponents()
    ''  Return
    ''End If
    'currentUserId = SecurityService.CurrentUser.Id

    ' ''If validator.GetErrorMessage(txtDocDateStart).Length <> 0 Then
    ' ''  msgServ.ShowMessage(validator.ValidationSummary)
    ' ''  Return
    ' ''End If
    ''If Not Validator Is Nothing Then
    ''  If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
    ''    msgServ.ShowMessage(Validator.ValidationSummary)
    ''    Me.OnSaved(New SaveEventArgs(False))
    ''    SecurityService.UpdateAccessTable()
    ''    WorkbenchSingleton.Workbench.RedrawEditComponents()
    ''    Return
    ''  End If
    ''End If

    ''EnableTextBox()

    ''If Not Me.WorkbenchWindow.SubViewContents Is Nothing AndAlso Me.WorkbenchWindow.SubViewContents.Count > 0 Then
    ''  For Each content As IBaseViewContent In Me.WorkbenchWindow.SubViewContents
    ''    If TypeOf content Is IValidatable Then
    ''      Dim validator As Gui.Components.PJMTextboxValidator = CType(content, IValidatable).FormValidator
    ''      If Not validator Is Nothing Then
    ''        If Not validator.ValidationSummary Is Nothing AndAlso validator.ValidationSummary.Length > 0 Then
    ''          msgServ.ShowMessage(validator.ValidationSummary)
    ''          Me.OnSaved(New SaveEventArgs(False))
    ''          SecurityService.UpdateAccessTable()
    ''          WorkbenchSingleton.Workbench.RedrawEditComponents()
    ''          Return
    ''        End If
    ''      End If
    ''    End If
    ''  Next
    ''End If

    'Dim errorMessage As String = Me.m_entity.Save(currentUserId).Message

    'ProgressBar1.Value = 50
    'Timer1.Enabled = False
    'If Not IsNumeric(errorMessage) AndAlso errorMessage.Length > 0 Then 'Todo
    'msgServ.ShowMessage(errorMessage)
    'Me.OnSaved(New SaveEventArgs(False))
    'Else
    'msgServ.ShowMessage("${res:Global.Info.DataSaved}")
    ''CType(Me, ISimpleListPanel).RefreshData("")
    'Me.IsDirty = False
    'Me.OnSaved(New SaveEventArgs(True))
    'End If

    ''SecurityService.UpdateAccessTable()
    ''WorkbenchSingleton.Workbench.RedrawEditComponents()

    ''lblProgress.Text = ""
    ''ProgressBar1.Visible = False
    ' ''CheckFormEnable()

    ''m_entity = New StockSequence("***") 'Hack by julawut
    ''Me.UpdateEntityProperties()

    ''GC.Collect()
    'End Sub
#End Region

#Region "IClipboardHandler Overrides"
#End Region

#Region "IKeyReceiver"
    'Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
    'Try
    'Select Case keyPressed
    'Case Keys.Insert
    ''ibtnBlank_Click(Nothing, Nothing)
    'Return True
    'Case Keys.Delete
    'If Me.tgItem.Focused Then
    ''ibtnDelRow_Click(Nothing, Nothing)
    'Return True
    'Else
    'Return False
    'End If
    'Case Else
    'Return False
    'End Select
    'Catch ex As Exception
    'Throw ex
    'End Try
    'End Function
#End Region

    Private Sub tgItem_CurrentCellStartEditing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tgItem.CurrentCellStartEditing
      e.Cancel = True
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click

      CurrentFormat = New EntityAutoGen
      RefreshEdit(True)

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Longkong.Pojjaman.BusinessLogic.SimpleBusinessEntityBase.ConnectionString)
      Dim sql As String = ""
      Dim command As SqlCommand

      Dim success As Boolean = False
      conn.Open()
      command = conn.CreateCommand
      trans = conn.BeginTransaction()
      command.Transaction = trans
      command.CommandType = CommandType.Text

      sql = "delete entityautogen where entityauto_id = " & CurrentFormat.EntityFormatId.ToString

      command.CommandText = sql

      Try
        command.ExecuteNonQuery()
        trans.Commit()

        success = True

      Catch ex As Exception
        MessageBox.Show(ex.ToString)
        trans.Rollback()
      Finally
        conn.Close()
      End Try

      If success Then

        MessageBox.Show("Finish!")

        CurrentFormat = New EntityAutoGen

        SetGridValue(CurrentRow, 1, CurrentFormat.EntityName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
        SetGridValue(CurrentRow, 2, CurrentFormat.EntityGLName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
        SetGridValue(CurrentRow, 3, CurrentFormat.EntityConfigName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
        SetGridValue(CurrentRow, 4, CurrentFormat.EntityFormat, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
        SetGridValue(CurrentRow, 5, CurrentFormat.EntityNote, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)

        tgItem(CurrentRow, 1).Tag = CurrentFormat

        'PopulateData()

        'PopulateGrid()

        'CurrentFormat = New EntityAutoGen

        'RefreshEdit(True)

      End If

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Longkong.Pojjaman.BusinessLogic.SimpleBusinessEntityBase.ConnectionString)
      Dim sql As String = ""
      Dim command As SqlCommand

      Dim success As Boolean = False
      conn.Open()
      command = conn.CreateCommand
      trans = conn.BeginTransaction()
      command.Transaction = trans
      command.CommandType = CommandType.Text



      If CurrentFormat.EntityFormatId = -1 Then
        sql = "insert into entityautogen (entity_id,entity_autocodeFormat,entityauto_glf,entityauto_config,entityauto_desc) values ("
        sql = sql & CType(cmbEntity.SelectedItem, IdValuePair).Id.ToString
        sql = sql & ",'" & txtFormat.Text & "'"
        If CType(cmbGLFormat.SelectedItem, IdValuePair).Id = -1 Then
          sql = sql & ",Null"
        Else
          sql = sql & "," & CType(cmbGLFormat.SelectedItem, IdValuePair).Id.ToString
        End If
        sql = sql & "," & CType(cmbGLConfig.SelectedItem, IdValuePair).Id.ToString
        sql = sql & ",'" & txtDescription.Text & "'"
        sql = sql & ");"
        sql = sql & "Select Scope_Identity()"
      Else
        sql = "update entityautogen set "
        sql = sql & "entity_id = " & CType(cmbEntity.SelectedItem, IdValuePair).Id.ToString
        sql = sql & ",entity_autocodeFormat = '" & txtFormat.Text & "'"
        If CType(cmbGLFormat.SelectedItem, IdValuePair).Id = -1 Then
          sql = sql & ",entityauto_glf = Null"
        Else
          sql = sql & ",entityauto_glf = " & CType(cmbGLFormat.SelectedItem, IdValuePair).Id.ToString
        End If
        sql = sql & ",entityauto_config = " & CType(cmbGLConfig.SelectedItem, IdValuePair).Id.ToString
        sql = sql & ",entityauto_desc = '" & txtDescription.Text & "'"
        sql = sql & " where entityauto_id = " & CurrentFormat.EntityFormatId.ToString
      End If


      Dim id As Integer
      Dim isnew As Boolean = False
      command.CommandText = sql

      Try

        If CurrentFormat.EntityFormatId = -1 Then
          id = command.ExecuteScalar()
          CurrentFormat.EntityFormatId = id
          CurrentFormat.EntityId = CType(cmbEntity.SelectedItem, IdValuePair).Id
          CurrentFormat.EntityName = CType(cmbEntity.SelectedItem, IdValuePair).Value
          CurrentFormat.EntityGLId = CType(cmbGLFormat.SelectedItem, IdValuePair).Id
          CurrentFormat.EntityGLName = CType(cmbGLFormat.SelectedItem, IdValuePair).Value
          CurrentFormat.EntityConfigId = CType(cmbGLConfig.SelectedItem, IdValuePair).Id
          CurrentFormat.EntityConfigName = CType(cmbGLConfig.SelectedItem, IdValuePair).Value
          CurrentFormat.EntityFormat = txtFormat.Text
          CurrentFormat.EntityNote = txtDescription.Text
          isnew = True
        Else
          command.ExecuteNonQuery()
          CurrentFormat.EntityId = CType(cmbEntity.SelectedItem, IdValuePair).Id
          CurrentFormat.EntityName = CType(cmbEntity.SelectedItem, IdValuePair).Value
          CurrentFormat.EntityGLId = CType(cmbGLFormat.SelectedItem, IdValuePair).Id
          CurrentFormat.EntityGLName = CType(cmbGLFormat.SelectedItem, IdValuePair).Value
          CurrentFormat.EntityConfigId = CType(cmbGLConfig.SelectedItem, IdValuePair).Id
          CurrentFormat.EntityConfigName = CType(cmbGLConfig.SelectedItem, IdValuePair).Value
          CurrentFormat.EntityFormat = txtFormat.Text
          CurrentFormat.EntityNote = txtDescription.Text
        End If

        trans.Commit()

        success = True

      Catch ex As Exception
        MessageBox.Show(ex.ToString)
        trans.Rollback()
      Finally
        conn.Close()
      End Try

      If success Then

        MessageBox.Show("Finish!")

        'PopulateData()

        'PopulateGrid()

        'CurrentFormat = New EntityAutoGen

        'RefreshEdit(True)

        If isnew Then
          tgItem.RowCount += 1

          SetGridValue(tgItem.RowCount, 1, CurrentFormat.EntityName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
          SetGridValue(tgItem.RowCount, 2, CurrentFormat.EntityGLName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
          SetGridValue(tgItem.RowCount, 3, CurrentFormat.EntityConfigName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
          SetGridValue(tgItem.RowCount, 4, CurrentFormat.EntityFormat, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
          SetGridValue(tgItem.RowCount, 5, CurrentFormat.EntityNote, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
          tgItem(tgItem.RowCount, 1).Tag = CurrentFormat

        Else

          SetGridValue(CurrentRow, 1, CurrentFormat.EntityName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
          SetGridValue(CurrentRow, 2, CurrentFormat.EntityGLName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
          SetGridValue(CurrentRow, 3, CurrentFormat.EntityConfigName, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
          SetGridValue(CurrentRow, 4, CurrentFormat.EntityFormat, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)
          SetGridValue(CurrentRow, 5, CurrentFormat.EntityNote, False, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left)

        End If

      End If

    End Sub


    Private Sub tgItem_CellClick(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs) Handles tgItem.CellClick

      If e.RowIndex > 1 Then
        CurrentFormat = CType(tgItem(e.RowIndex, 1).Tag, EntityAutoGen)
        CurrentRow = e.RowIndex
        RefreshEdit(False)
      End If

    End Sub

    Private Sub cmbEntity_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbEntity.SelectedIndexChanged

      If m_isInitialized Then

        cmbGLFormat.Items.Clear()
        Dim nulliv As New IdValuePair(-1, "")
        Me.cmbGLFormat.Items.Add(nulliv)
        cmbGLFormat.SelectedIndex = 0
        If Me.EntityGLFormat.ContainsKey(CType(Me.cmbEntity.SelectedItem, IdValuePair).Id) Then
          For Each iv As IdValuePair In Me.EntityGLFormat(CType(Me.cmbEntity.SelectedItem, IdValuePair).Id)
            Me.cmbGLFormat.Items.Add(iv)
          Next
          If cmbGLFormat.Items.Count > 0 Then
            cmbGLFormat.SelectedIndex = 0
          End If
        End If

      End If

    End Sub

  End Class
End Namespace