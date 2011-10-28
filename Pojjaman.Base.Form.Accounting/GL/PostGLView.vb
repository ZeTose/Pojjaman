Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Data.SqlClient

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class PostGLView
    Inherits UserControl

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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lvItem As Longkong.Pojjaman.Gui.Components.PJMListView
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ibtnPost As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbSearch As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnCheckAll As System.Windows.Forms.Button
    Friend WithEvents btnShowRefDoc As System.Windows.Forms.Button
    Friend WithEvents btnAcctBookEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookEnd As System.Windows.Forms.Label
    Friend WithEvents btnAcctBookStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAcctBookStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAcctBookStart As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents pgPosting As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PostGLView))
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.lvItem = New Longkong.Pojjaman.Gui.Components.PJMListView()
      Me.lblStartDate = New System.Windows.Forms.Label()
      Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
      Me.lblEndDate = New System.Windows.Forms.Label()
      Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
      Me.btnRefresh = New System.Windows.Forms.Button()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ibtnPost = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbSearch = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnCheckAll = New System.Windows.Forms.Button()
      Me.btnShowRefDoc = New System.Windows.Forms.Button()
      Me.pgPosting = New System.Windows.Forms.ProgressBar()
      Me.btnAcctBookEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctBookEnd = New System.Windows.Forms.TextBox()
      Me.lblAcctBookEnd = New System.Windows.Forms.Label()
      Me.btnAcctBookStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAcctBookStart = New System.Windows.Forms.TextBox()
      Me.lblAcctBookStart = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbSearch.SuspendLayout()
      Me.SuspendLayout()
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'lvItem
      '
      Me.lvItem.AllowSort = True
      Me.lvItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lvItem.CheckBoxes = True
      Me.lvItem.FullRowSelect = True
      Me.lvItem.GridLines = True
      Me.lvItem.HideSelection = False
      Me.lvItem.Location = New System.Drawing.Point(32, 132)
      Me.lvItem.MultiSelect = False
      Me.lvItem.Name = "lvItem"
      Me.lvItem.Size = New System.Drawing.Size(680, 303)
      Me.lvItem.SortIndex = -1
      Me.lvItem.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lvItem.TabIndex = 1
      Me.lvItem.TabStop = False
      Me.lvItem.UseCompatibleStateImageBehavior = False
      Me.lvItem.View = System.Windows.Forms.View.Details
      '
      'lblStartDate
      '
      Me.lblStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStartDate.ForeColor = System.Drawing.Color.Black
      Me.lblStartDate.Location = New System.Drawing.Point(16, 16)
      Me.lblStartDate.Name = "lblStartDate"
      Me.lblStartDate.Size = New System.Drawing.Size(64, 18)
      Me.lblStartDate.TabIndex = 0
      Me.lblStartDate.Text = "วันที่เริ่มต้น:"
      Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpStartDate
      '
      Me.dtpStartDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpStartDate.Location = New System.Drawing.Point(88, 16)
      Me.dtpStartDate.Name = "dtpStartDate"
      Me.dtpStartDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpStartDate.TabIndex = 1
      Me.dtpStartDate.TabStop = False
      '
      'lblEndDate
      '
      Me.lblEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEndDate.ForeColor = System.Drawing.Color.Black
      Me.lblEndDate.Location = New System.Drawing.Point(200, 16)
      Me.lblEndDate.Name = "lblEndDate"
      Me.lblEndDate.Size = New System.Drawing.Size(72, 18)
      Me.lblEndDate.TabIndex = 2
      Me.lblEndDate.Text = "วันที่สิ้นสุด:"
      Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpEndDate
      '
      Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpEndDate.Location = New System.Drawing.Point(280, 16)
      Me.dtpEndDate.Name = "dtpEndDate"
      Me.dtpEndDate.Size = New System.Drawing.Size(96, 21)
      Me.dtpEndDate.TabIndex = 3
      Me.dtpEndDate.TabStop = False
      '
      'btnRefresh
      '
      Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRefresh.Location = New System.Drawing.Point(384, 16)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
      Me.btnRefresh.TabIndex = 4
      Me.btnRefresh.TabStop = False
      Me.btnRefresh.Text = "Refresh"
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(29, 111)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(168, 18)
      Me.lblItem.TabIndex = 4
      Me.lblItem.Text = "GL ที่ยังไม่ผ่านรายการ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnPost
      '
      Me.ibtnPost.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnPost.Location = New System.Drawing.Point(512, 8)
      Me.ibtnPost.Name = "ibtnPost"
      Me.ibtnPost.Size = New System.Drawing.Size(72, 64)
      Me.ibtnPost.TabIndex = 2
      Me.ibtnPost.TabStop = False
      Me.ibtnPost.ThemedImage = CType(resources.GetObject("ibtnPost.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbSearch
      '
      Me.grbSearch.Controls.Add(Me.txtCode)
      Me.grbSearch.Controls.Add(Me.lblCode)
      Me.grbSearch.Controls.Add(Me.btnAcctBookEndFind)
      Me.grbSearch.Controls.Add(Me.txtAcctBookEnd)
      Me.grbSearch.Controls.Add(Me.lblAcctBookEnd)
      Me.grbSearch.Controls.Add(Me.btnAcctBookStartFind)
      Me.grbSearch.Controls.Add(Me.txtAcctBookStart)
      Me.grbSearch.Controls.Add(Me.lblAcctBookStart)
      Me.grbSearch.Controls.Add(Me.dtpStartDate)
      Me.grbSearch.Controls.Add(Me.btnRefresh)
      Me.grbSearch.Controls.Add(Me.lblEndDate)
      Me.grbSearch.Controls.Add(Me.dtpEndDate)
      Me.grbSearch.Controls.Add(Me.lblStartDate)
      Me.grbSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSearch.Location = New System.Drawing.Point(32, 8)
      Me.grbSearch.Name = "grbSearch"
      Me.grbSearch.Size = New System.Drawing.Size(472, 89)
      Me.grbSearch.TabIndex = 0
      Me.grbSearch.TabStop = False
      Me.grbSearch.Text = "ค้นหารายการ"
      '
      'btnCheckAll
      '
      Me.btnCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCheckAll.Location = New System.Drawing.Point(32, 443)
      Me.btnCheckAll.Name = "btnCheckAll"
      Me.btnCheckAll.Size = New System.Drawing.Size(120, 23)
      Me.btnCheckAll.TabIndex = 3
      Me.btnCheckAll.TabStop = False
      Me.btnCheckAll.Text = "เลือก/ไม่เลือกทั้งหมด"
      '
      'btnShowRefDoc
      '
      Me.btnShowRefDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnShowRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnShowRefDoc.Location = New System.Drawing.Point(160, 443)
      Me.btnShowRefDoc.Name = "btnShowRefDoc"
      Me.btnShowRefDoc.Size = New System.Drawing.Size(104, 23)
      Me.btnShowRefDoc.TabIndex = 219
      Me.btnShowRefDoc.TabStop = False
      Me.btnShowRefDoc.Text = "ไปยังเอกสารอ้างอิง"
      '
      'pgPosting
      '
      Me.pgPosting.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pgPosting.Location = New System.Drawing.Point(592, 48)
      Me.pgPosting.Name = "pgPosting"
      Me.pgPosting.Size = New System.Drawing.Size(120, 23)
      Me.pgPosting.TabIndex = 220
      '
      'btnAcctBookEndFind
      '
      Me.btnAcctBookEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctBookEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookEndFind.Location = New System.Drawing.Point(376, 40)
      Me.btnAcctBookEndFind.Name = "btnAcctBookEndFind"
      Me.btnAcctBookEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookEndFind.TabIndex = 42
      Me.btnAcctBookEndFind.TabStop = False
      Me.btnAcctBookEndFind.ThemedImage = CType(resources.GetObject("btnAcctBookEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctBookEnd
      '
      Me.Validator.SetDataType(Me.txtAcctBookEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookEnd, "")
      Me.txtAcctBookEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctBookEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookEnd, System.Drawing.Color.Empty)
      Me.txtAcctBookEnd.Location = New System.Drawing.Point(280, 40)
      Me.Validator.SetMinValue(Me.txtAcctBookEnd, "")
      Me.txtAcctBookEnd.Name = "txtAcctBookEnd"
      Me.Validator.SetRegularExpression(Me.txtAcctBookEnd, "")
      Me.Validator.SetRequired(Me.txtAcctBookEnd, False)
      Me.txtAcctBookEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookEnd.TabIndex = 38
      '
      'lblAcctBookEnd
      '
      Me.lblAcctBookEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookEnd.Location = New System.Drawing.Point(235, 40)
      Me.lblAcctBookEnd.Name = "lblAcctBookEnd"
      Me.lblAcctBookEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAcctBookEnd.TabIndex = 41
      Me.lblAcctBookEnd.Text = "ถึง"
      Me.lblAcctBookEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnAcctBookStartFind
      '
      Me.btnAcctBookStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAcctBookStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAcctBookStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAcctBookStartFind.Location = New System.Drawing.Point(184, 40)
      Me.btnAcctBookStartFind.Name = "btnAcctBookStartFind"
      Me.btnAcctBookStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAcctBookStartFind.TabIndex = 40
      Me.btnAcctBookStartFind.TabStop = False
      Me.btnAcctBookStartFind.ThemedImage = CType(resources.GetObject("btnAcctBookStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAcctBookStart
      '
      Me.Validator.SetDataType(Me.txtAcctBookStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookStart, "")
      Me.txtAcctBookStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAcctBookStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookStart, System.Drawing.Color.Empty)
      Me.txtAcctBookStart.Location = New System.Drawing.Point(88, 40)
      Me.Validator.SetMinValue(Me.txtAcctBookStart, "")
      Me.txtAcctBookStart.Name = "txtAcctBookStart"
      Me.Validator.SetRegularExpression(Me.txtAcctBookStart, "")
      Me.Validator.SetRequired(Me.txtAcctBookStart, False)
      Me.txtAcctBookStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAcctBookStart.TabIndex = 37
      '
      'lblAcctBookStart
      '
      Me.lblAcctBookStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBookStart.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBookStart.Location = New System.Drawing.Point(16, 40)
      Me.lblAcctBookStart.Name = "lblAcctBookStart"
      Me.lblAcctBookStart.Size = New System.Drawing.Size(62, 18)
      Me.lblAcctBookStart.TabIndex = 39
      Me.lblAcctBookStart.Text = "สมุดรายวัน"
      Me.lblAcctBookStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(88, 64)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(275, 21)
      Me.txtCode.TabIndex = 43
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(6, 64)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(82, 18)
      Me.lblCode.TabIndex = 44
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'PostGLView
      '
      Me.Controls.Add(Me.pgPosting)
      Me.Controls.Add(Me.btnShowRefDoc)
      Me.Controls.Add(Me.grbSearch)
      Me.Controls.Add(Me.ibtnPost)
      Me.Controls.Add(Me.lvItem)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.btnCheckAll)
      Me.Name = "PostGLView"
      Me.Size = New System.Drawing.Size(744, 475)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbSearch.ResumeLayout(False)
      Me.grbSearch.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_startDate As Date
    Private m_endDate As Date
    Private myParser As StringParserService
    Private m_gl As JournalEntry
    Private m_selectedItems As ArrayList
    Private m_selectedItemsId As Generic.List(Of String)
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      myParser = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      m_gl = New JournalEntry
      m_selectedItems = New ArrayList
      EventWiring()
    End Sub
    Public Sub New(ByVal startDate As Date, ByVal endDate As Date)
      MyBase.New()
      InitializeComponent()
      myParser = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Me.SetLabelText()
      m_startDate = startDate
      m_endDate = endDate
      m_selectedItems = New ArrayList
      Me.dtpStartDate.Value = startDate
      Me.dtpEndDate.Value = endDate
      m_gl = New JournalEntry
      For Each col As Column In m_gl.Columns
        lvItem.Columns.Add(col.Alias, col.Width, col.Alignment)
      Next
      Me.lvItem.CheckBoxes = True
      EventWiring()
    End Sub
    Public Sub SetLabelText()
      Me.lblStartDate.Text = myParser.Parse("${res:Longkong.Pojjaman.Gui.Panels.PostGLView.lblStartDate}")
      Me.lblEndDate.Text = myParser.Parse("${res:Longkong.Pojjaman.Gui.Panels.PostGLView.lblEndDate}")
      Me.btnRefresh.Text = myParser.Parse("${res:Longkong.Pojjaman.Gui.Panels.PostGLView.btnRefresh}")
      Me.lblItem.Text = myParser.Parse("${res:Longkong.Pojjaman.Gui.Panels.PostGLView.lblItem}")
      Me.grbSearch.Text = myParser.Parse("${res:Global.SearchButtonText}")
    End Sub
#End Region

#Region "Methods"
    Public Sub RefreshList()
      Dim dt As DataTable = m_gl.GetUnpostListTable(m_startDate, m_endDate, txtCode.Text, txtAcctBookStart.Text, txtAcctBookEnd.Text)
      lvItem.Items.Clear()
      Dim comparer As IComparer = lvItem.ListViewItemSorter
      lvItem.ListViewItemSorter = Nothing
      For Each row As DataRow In dt.Rows
        Dim litem As ListViewItem = Me.lvItem.Items.Add(row(m_gl.Columns(0).Name).ToString)
        litem.Tag = row
        For i As Integer = 1 To m_gl.Columns.Count - 1
          If row.Table.Columns.Contains(m_gl.Columns(i).Name) Then
            Dim myType As Type = m_gl.Columns(i).DataType
            Dim value As String = ""
            Select Case myType.FullName.ToLower
              Case "system.datetime"
                Dim val As Date = Date.Now
                If Not row.IsNull(m_gl.Columns(i).Name) Then
                  val = CDate(row(m_gl.Columns(i).Name))
                End If
                If m_gl.Columns(i).Format = 2 Then
                  value = val.ToShortDateString
                Else
                  value = val.ToShortDateString & ":" & val.ToShortTimeString
                End If
              Case "system.decimal"
                Dim val As Decimal = 0
                If Not row.IsNull(m_gl.Columns(i).Name) Then
                  val = CDec(row(m_gl.Columns(i).Name))
                End If
                value = Configuration.FormatToString(val, m_gl.Columns(i).Format)
              Case Else
                Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                value = row(m_gl.Columns(i).Name).ToString()
                value = myStringParserService.Parse(value)
            End Select
            litem.SubItems.Add(value)
          End If
        Next
      Next
      lvItem.ListViewItemSorter = comparer
      If Not lvItem.ListViewItemSorter Is Nothing Then
        lvItem.Sort()
      End If
      lvItem.PaintAlternatingBackColor(Color.White, Color.Khaki)
      Me.pgPosting.Value = Me.pgPosting.Minimum
      m_isCkecked = False
    End Sub
#End Region

#Region "Event Handlers"
    Protected Sub EventWiring()
      
      AddHandler dtpStartDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpStartDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler btnAcctBookStartFind.Click, AddressOf Me.btnAccountBookFind_Click
      AddHandler btnAcctBookEndFind.Click, AddressOf Me.btnAccountBookFind_Click
      
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      Select Case CType(sender, Control).Name.ToLower
        Case "dtpstartdate"
          If Not m_startDate.Equals(dtpStartDate.Value) Then
            m_startDate = dtpStartDate.Value
          End If
        Case "dtpenddate"
          If Not m_endDate.Equals(dtpEndDate.Value) Then
            m_endDate = dtpEndDate.Value
          End If
      End Select
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
      RefreshList()
    End Sub
    Private Sub lvItem_SortChanged() Handles lvItem.SortChanged
      If m_gl Is Nothing Then
        Return
      End If
      Dim indx As Integer = lvItem.SortIndex
      Dim sortOrder As System.Windows.Forms.SortOrder = lvItem.SortOrder
      Dim myType As Type = m_gl.Columns(indx).DataType
      If myType Is GetType(Date) Then
        lvItem.ListViewItemSorter = New ListViewHelper.CompareByDate(indx, sortOrder)
      ElseIf myType Is GetType(String) Then
        lvItem.ListViewItemSorter = New ListViewHelper.CompareByText(indx, sortOrder)
      Else
        lvItem.ListViewItemSorter = New ListViewHelper.CompareByNumber(indx, sortOrder)
      End If
      lvItem.Sort()
      lvItem.PaintAlternatingBackColor(Color.White, Color.Khaki)
    End Sub
    Private m_isCkecked As Boolean = False
    Private Sub btnCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAll.Click
      If lvItem.Items.Count = 0 Then
        Return
      End If
      For Each item As ListViewItem In lvItem.Items
        item.Checked = Not m_isCkecked
      Next
      m_isCkecked = Not m_isCkecked
    End Sub
    Private Sub btnShowRefDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowRefDoc.Click
      If lvItem.SelectedItems.Count = 0 Then
        Return
      End If
      Dim entity As ISimpleEntity
      Dim row As DataRow = CType(lvItem.SelectedItems(0).Tag, DataRow)
      Dim refDocType As Integer = CInt(row("gl_refDocType"))
      Dim refId As Integer
      If refDocType <> 38 Then
        refId = CInt(row("gl_refId"))
      Else
        refId = CInt(row("gl_id"))
      End If
      Dim fullClassName As String = BusinessLogic.Entity.GetFullClassName(refDocType)
      entity = SimpleBusinessEntityBase.GetEntity(fullClassName, refId)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenDetailPanel(entity)
    End Sub
    Private Sub ibtnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnPost.Click
      PostAll()
    End Sub
    Private Sub GetArrayList()
      m_selectedItems = New ArrayList
      m_selectedItemsId = New Generic.List(Of String)
      Me.pgPosting.Value = Me.pgPosting.Minimum
      Me.pgPosting.Maximum = lvItem.CheckedItems.Count
      Dim i As Integer = 0
      For Each item As ListViewItem In lvItem.CheckedItems
        Dim row As DataRow = CType(item.Tag, DataRow)
        Dim refDocType As Integer = CInt(row("gl_refDocType"))
        Dim refDocCode As String = row("gl_refCode").ToString
        Dim refId As Integer
        Dim glId As Integer
        If refDocType <> 38 Then
          refId = CInt(row("gl_refId"))
        Else
          refId = CInt(row("gl_id"))
        End If
        glId = CInt(row("gl_id"))
        m_selectedItemsId.Add(glId)
        'Dim fullClassName As String = Entity.GetFullClassName(refDocType)
        'Dim newEntity As ISimpleEntity = SimpleBusinessEntityBase.GetEntity(fullClassName, refId)
        'If TypeOf newEntity Is JournalEntry Then
        '  CType(newEntity, JournalEntry).RefDoc = New GenericGlAble(newEntity.Id, refDocCode, CType(newEntity, JournalEntry).DocDate)
        '  CType(newEntity, JournalEntry).NoSaveMessage = True
        'End If
        'm_selectedItems.Add(newEntity)
        i += 1
        Me.pgPosting.Value = i
      Next
    End Sub
    Private Sub PostAll()
      GetArrayList()
      If m_selectedItems Is Nothing AndAlso m_selectedItemsId Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim currentUserId As Integer
      Dim mySecurityService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      If mySecurityService.CurrentUser Is Nothing Then
        msgServ.ShowMessage("${res:Global.Error.NoUser}")
        Return
      End If
      Dim count As Integer = 0
      Dim i As Integer = 0
      Dim lists As Generic.List(Of String) = GetGlListLimit()
      count = m_selectedItemsId.Count
      For Each sublist As String In lists

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList
        paramArrayList.Add(New SqlParameter("@gl_idList", sublist))
        paramArrayList.Add(New SqlParameter("@CurrentUserId", currentUserId))
        'paramArrayList.Add(New SqlParameter("@PostDate", Today.ToString))

        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(RecentCompanies.CurrentCompany.ConnectionString)

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        trans = conn.BeginTransaction()

        Try
          SqlHelper.ExecuteNonQuery(conn, trans _
                    , CommandType.StoredProcedure _
                    , "UpdatePostGLFromList" _
                    , sqlparams)
          trans.Commit()
        Catch ex As Exception
          trans.Rollback()
        Finally
          conn.Close()
        End Try
      Next

      'Me.pgPosting.Maximum = m_selectedItems.Count
      'Me.pgPosting.Value = Me.pgPosting.Minimum
      'For Each newEntity As ISimpleEntity In m_selectedItems
      '  If TypeOf newEntity Is JournalEntry Then
      '    newEntity.Status.Value = 4
      '  ElseIf TypeOf newEntity Is IGLAble Then
      '    Try
      '      CType(newEntity, IGLAble).JournalEntry.Status.Value = 4
      '    Catch ex As Exception
      '      msgServ.ShowMessage(ex.ToString)
      '    End Try
      '  End If
      '  If TypeOf newEntity Is SimpleBusinessEntityBase Then
      '    CType(newEntity, SimpleBusinessEntityBase).NoSaveMessage = True
      '  End If
      '  Dim saveError As SaveErrorException = newEntity.Save(currentUserId)
      '  Dim entityIdentity As String = myParser.Parse("${res:Global.Entity." & newEntity.EntityId.ToString & "}") & "(" & newEntity.Code & ")"
      '  If Not IsNumeric(saveError.Message) Then  'Todo
      '    If Not saveError.Params Is Nothing AndAlso saveError.Params.Length > 0 Then
      '      msgServ.ShowMessageFormatted(saveError.Message & ":" & entityIdentity, saveError.Params)
      '    Else
      '      msgServ.ShowMessage(saveError.Message & ":" & entityIdentity)
      '    End If
      '    Exit For
      '  ElseIf CInt(saveError.Message) = -1 Then
      '    'code ซ้ำ
      '    'Todo
      '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasThisCode}", New String() {entityIdentity})
      '    Exit For
      '  ElseIf CInt(saveError.Message) = -2 Then
      '    'Status >=3
      '    'Todo
      '    msgServ.ShowMessageFormatted("${res:Global.Error.InvalidStatus}", New String() {entityIdentity})
      '    Exit For
      '  Else
      '    count += 1
      '    'msgServ.ShowMessageFormatted("${res:Global.Info.EntityPosted}", New String() {newEntity.TabPageText})
      '  End If
      '  i += 1
      '  Me.pgPosting.Value = i
      'Next
      msgServ.ShowMessageFormatted("${res:Global.Info.EntityPostedCount}", New String() {count})
      RefreshList()
    End Sub

    Private Function GetGlListLimit() As Generic.List(Of String)
      Dim lists As New Generic.List(Of String)
      Dim sublist As New Generic.List(Of String)
      Dim l As Integer = 0
      Dim max As Integer = 1000
      For Each id As String In m_selectedItemsId
        l += id.Length
        If l > max Then
          lists.Add(String.Join(",", sublist))
          l = id.Length + 1
          sublist = New Generic.List(Of String)
          sublist.Add(id)
        Else
          sublist.Add(id)
          l += 1
        End If
      Next
      lists.Add(String.Join(",", sublist))
      Return lists
    End Function

    Private Sub btnAccountBookFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnacctbookstartfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookStartDialog)

        Case "btnacctbookendfind"
          myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAccountBookEndDialog)

      End Select
    End Sub
    Private Sub SetAccountBookStartDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookStart.Text = e.Code
    End Sub
    Private Sub SetAccountBookEndDialog(ByVal e As ISimpleEntity)
      Me.txtAcctBookEnd.Text = e.Code
    End Sub
#End Region

  End Class
End Namespace

