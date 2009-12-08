Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptSpecialWBSView
    Inherits AbstractEntityPanelViewContent
    Implements IValidatable, ISimpleListPanel

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
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnShowCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents tgItem As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptSpecialWBSView))
      Dim GridBaseStyle1 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle
      Dim GridBaseStyle2 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle
      Dim GridBaseStyle3 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle
      Dim GridBaseStyle4 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.btnShowCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.tgItem = New Syncfusion.Windows.Forms.Grid.GridControl
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(384, 40)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 8
      Me.txtDocDateEnd.Text = ""
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(152, 16)
      Me.Validator.SetMaxValue(Me.txtCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(72, 21)
      Me.txtCostCenterCode.TabIndex = 1
      Me.txtCostCenterCode.Text = ""
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(224, 16)
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(184, 21)
      Me.txtCostCenterName.TabIndex = 2
      Me.txtCostCenterName.Text = ""
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(152, 40)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 5
      Me.txtDocDateStart.Text = ""
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
      'grbMaster
      '
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(616, 128)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "Searching"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.btnShowCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(592, 72)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "Info"
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(152, 40)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 6
      Me.dtpDocDateStart.TabStop = False
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(272, 40)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(112, 18)
      Me.lblDocDateEnd.TabIndex = 7
      Me.lblDocDateEnd.Text = "~"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(384, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 9
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(32, 40)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(112, 18)
      Me.lblDocDateStart.TabIndex = 4
      Me.lblDocDateStart.Text = "From Date:"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnShowCostCenter
      '
      Me.btnShowCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnShowCostCenter.ForeColor = System.Drawing.SystemColors.Control
      Me.btnShowCostCenter.Image = CType(resources.GetObject("btnShowCostCenter.Image"), System.Drawing.Image)
      Me.btnShowCostCenter.Location = New System.Drawing.Point(408, 16)
      Me.btnShowCostCenter.Name = "btnShowCostCenter"
      Me.btnShowCostCenter.Size = New System.Drawing.Size(24, 22)
      Me.btnShowCostCenter.TabIndex = 3
      Me.btnShowCostCenter.TabStop = False
      Me.btnShowCostCenter.ThemedImage = CType(resources.GetObject("btnShowCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostCenter.Location = New System.Drawing.Point(8, 16)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(136, 18)
      Me.lblCostCenter.TabIndex = 0
      Me.lblCostCenter.Text = "Cost Center:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(512, 96)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(80, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(432, 96)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(80, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "Clear"
      '
      'tgItem
      '
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      GridBaseStyle1.Name = "Header"
      GridBaseStyle1.StyleInfo.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.Borders.Left = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.CellType = "Header"
      GridBaseStyle1.StyleInfo.Font.Bold = True
      GridBaseStyle1.StyleInfo.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
      GridBaseStyle2.Name = "Column Header"
      GridBaseStyle2.StyleInfo.BaseStyle = "Header"
      GridBaseStyle2.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      GridBaseStyle3.Name = "Row Header"
      GridBaseStyle3.StyleInfo.BaseStyle = "Header"
      GridBaseStyle3.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      GridBaseStyle4.Name = "Standard"
      GridBaseStyle4.StyleInfo.Font.Facename = "Tahoma"
      Me.tgItem.BaseStylesMap.AddRange(New Syncfusion.Windows.Forms.Grid.GridBaseStyle() {GridBaseStyle1, GridBaseStyle2, GridBaseStyle3, GridBaseStyle4})
      Me.tgItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.tgItem.ColCount = 16
      Me.tgItem.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 1, 2, 1), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 2, 2, 2), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 3, 2, 3), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 4, 2, 4), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 6, 1, 7), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 8, 1, 10), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 11, 1, 14), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 15, 2, 15), Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 16, 2, 16)})
      Me.tgItem.DefaultColWidth = 100
      Me.tgItem.DefaultRowHeight = 50
      Me.tgItem.ExcelLikeSelectionFrame = True
      Me.tgItem.Font = New System.Drawing.Font("MS Mincho", 8.25!)
      Me.tgItem.ForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 144)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Properties.ColHeaders = False
      Me.tgItem.Properties.RowHeaders = False
      Me.tgItem.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.tgItem.RowCount = 20
      Me.tgItem.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeIntoCode
      Me.tgItem.Size = New System.Drawing.Size(880, 360)
      Me.tgItem.SmartSizeBox = False
      Me.tgItem.TabIndex = 1
      Me.tgItem.ThemesEnabled = True
      '
      'RptSpecialWBSView
      '
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.grbMaster)
      Me.Name = "RptSpecialWBSView"
      Me.Size = New System.Drawing.Size(904, 512)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As RptSpecialWBS

    Private m_DocDateStart As Date
    Private m_DocDateEnd As Date

    Private m_cc As CostCenter


#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Me.SetLabelText()
      Initialize()

      m_entity = New RptSpecialWBS


      InitGrid()


      'initial entity
      Me.UpdateEntityProperties()
      Me.TitleName = m_entity.TabPageText

      btnSearch_Click(Nothing, Nothing)
      LoopControl(Me)
    End Sub
    Private Sub InitGrid()

      tgItem.Rows.HeaderCount = 2
      tgItem.Cols.FrozenCount = 2

      tgItem.ColWidths(0) = 35
      tgItem.ColWidths(4) = 150

      tgItem.RowHeights(1) = 30
      tgItem.RowHeights(2) = 30

      SetGridValue(1, 1, "Code", True)
      SetGridValue(1, 2, "Work Description", True)
      SetGridValue(1, 3, "Control Budget", True)
      SetGridValue(1, 4, "Total Order (Control Only)", True)

      SetGridValue(1, 5, "???", True)
      SetGridValue(2, 5, "Work DOne", True)

      SetGridValue(1, 6, "Payment this Month", True)
      SetGridValue(2, 6, "Contract", True)
      SetGridValue(2, 7, "Direct", True)

      SetGridValue(1, 8, "Payment Accumulate", True)
      SetGridValue(2, 8, "Contract", True)
      SetGridValue(2, 9, "Direct", True)
      SetGridValue(2, 10, "Total Accumulate", True)

      SetGridValue(1, 11, "Expected Payment", True)
      SetGridValue(2, 11, "Remain", True)
      SetGridValue(2, 12, "Expected Contract", True)
      SetGridValue(2, 13, "Expected Direct", True)
      SetGridValue(2, 14, "Total Expected", True)

      SetGridValue(1, 15, "Final", True)
      SetGridValue(1, 16, "Balance", True)

      tgItem.ExcelLikeSelectionFrame = True
    End Sub
#End Region

#Region "Properties"
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property
    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
#End Region

#Region "ISimpleListPanel"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleListPanel.ChangeTitle

    End Sub
    Public Sub CheckFormEnable() Implements ISimplePanel.CheckFormEnable

    End Sub
    Public Sub ClearDetail() Implements ISimplePanel.ClearDetail
    End Sub
    Public Sub SetLabelText() Implements ISimplePanel.SetLabelText
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      'Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSpecialWBSView.lblItem}")
      'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.lblCode}")
      'Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      'Me.lblUnitType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.lblUnitType}")
    End Sub
    Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      'Hack
      Me.IsDirty = False

      SetStatus()
      SetLabelText()
      CheckFormEnable()
    End Sub
    Private m_dateSetting As Boolean
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

    End Sub
    Private Sub EventWiring()
      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpdocdatestart"
          If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.DocDateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          Else
            Me.dtpDocDateStart.Value = Date.Now
            Me.DocDateStart = Date.MinValue
          End If
          m_dateSetting = False
        Case Else

      End Select
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

    Public Sub AddNew() Implements ISimpleListPanel.AddNew

    End Sub

    Private Sub OnEntitySelected(ByVal entity As ISimpleEntity)
      RaiseEvent EntitySelected(entity)
    End Sub
    Public Event EntitySelected(ByVal entity As BusinessLogic.ISimpleEntity) Implements ISimpleListPanel.EntitySelected

    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData

    End Sub

    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
      End Set
    End Property
    Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
      Get

      End Get
    End Property

    Public Sub Initialize() Implements ISimplePanel.Initialize
      ClearCriterias()
    End Sub
    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbMaster.Controls
        If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf Ctrl Is TextBox Then
              Ctrl.Text = ""
            End If
          Next
        End If
      Next

      Me.DocDateStart = Date.Now
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      m_cc = New CostCenter
    End Sub
    Private Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
      If dt.Equals(Date.MinValue) Then
        Return nullString
      End If
      Return dt.ToShortDateString
    End Function
#End Region

#Region "Methods"

#End Region

#Region "Event Handlers"
    Private Sub SetGridValue(ByVal row As Integer, ByVal col As Integer, ByVal value As String, Optional ByVal bold As Boolean = False)
      tgItem(row, col).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      tgItem(row, col).VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
      tgItem(row, col).Text = value
      tgItem(row, col).Font.Bold = bold
    End Sub
    Private Function Percent(ByVal top As Decimal, ByVal bottom As Decimal) As Decimal
      If bottom = 0 Then
        Return 0
      End If
      Return 100 * (top / bottom)
    End Function
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
      Dim filters() As Filter = GetFilterArray()

      If m_cc Is Nothing OrElse Not m_cc.Originated Then
        'm_treeManager.Treetable.Clear()
        Return
      End If
      If m_cc.BoqId = 0 Then
        'm_treeManager.Treetable.Clear()
        Return
      End If
      Dim myBoq As New BOQ(m_cc.BoqId)

      InitGrid()


      If TypeOf filters(1).Value Is Date Then
        'myBoq.PopulateWBSMonitorListing(m_treeManager, CDate(filters(1).Value), type, detailed, nodigit)
      End If
    End Sub
    Private Function GetFilterArray() As Filter()
      Dim arr(2) As Filter
      arr(0) = New Filter("cc", m_cc)
      arr(1) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(2) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      Return arr
    End Function
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
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          'Case Keys.Insert
          '  ibtnBlank_Click(Nothing, Nothing)
          '  Return True
          'Case Keys.Delete
          '  If Me.tgItem.Focused Then
          '    ibtnDelRow_Click(Nothing, Nothing)
          '    Return True
          '  Else
          '    Return False
          '  End If
        Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
#End Region

    Public Overloads Overrides Sub Save()
      OnSaving(New EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim currentUserId As Integer = currentUserId
      If SecurityService.CurrentUser Is Nothing Then
        msgServ.ShowMessage("${res:Global.Error.NoUser}")
        Me.OnSaved(New SaveEventArgs(False))
        SecurityService.UpdateAccessTable()
        WorkbenchSingleton.Workbench.RedrawEditComponents()
        Return
      End If
      currentUserId = SecurityService.CurrentUser.Id
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing AndAlso Me.WorkbenchWindow.SubViewContents.Count > 0 Then
        For Each content As IBaseViewContent In Me.WorkbenchWindow.SubViewContents
          If TypeOf content Is IValidatable Then
            Dim validator As Gui.Components.PJMTextboxValidator = CType(content, IValidatable).FormValidator
            If Not validator Is Nothing Then
              If Not validator.ValidationSummary Is Nothing AndAlso validator.ValidationSummary.Length > 0 Then
                msgServ.ShowMessage(validator.ValidationSummary)
                Me.OnSaved(New SaveEventArgs(False))
                SecurityService.UpdateAccessTable()
                WorkbenchSingleton.Workbench.RedrawEditComponents()
                Return
              End If
            End If
          End If
        Next
      End If

      'If Not Me.UnitCollection Is Nothing Then
      '  Dim errorMessage As String = Me.UnitCollection.Save(currentUserId).Message
      '  If Not IsNumeric(errorMessage) Then 'Todo
      '    msgServ.ShowMessage(errorMessage)
      '    Me.OnSaved(New SaveEventArgs(False))
      '  Else
      '    msgServ.ShowMessage("${res:Global.Info.DataSaved}")
      '    CType(Me, ISimpleListPanel).RefreshData("")
      '    Me.IsDirty = False
      '    Me.OnSaved(New SaveEventArgs(True))
      '  End If
      'End If

      SecurityService.UpdateAccessTable()
      WorkbenchSingleton.Workbench.RedrawEditComponents()
      GC.Collect()
    End Sub

    Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostCenterCode.Validated
      CostCenter.GetCostCenter(txtCostCenterCode, Me.txtCostCenterName, Me.m_cc)
    End Sub
    Private Sub btnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowCostCenter.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal e As ISimpleEntity)
      Me.txtCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_cc)
    End Sub
  End Class
End Namespace