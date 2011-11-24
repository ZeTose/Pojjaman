Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports System.ComponentModel
Imports Syncfusion.Windows.Forms.Grid
Imports System.IO
Imports Longkong.Core.Services
Imports System.Runtime.Serialization
Namespace Longkong.Pojjaman.Gui.Components
  Public Class LKGrid
    Inherits GridControl

#Region "Members"
    Private m_colorList As New ColorCollection
    Private m_plusMinusColumnIndex As Integer
    Private m_autoColumnResize As Boolean = False

    Private m_treetable As TreeTable
    Private m_tableStyle As DataGridTableStyle
    Public Event CellBtnClick As DataGridButtonColumn.ButtonColumnClickHandler
    Private m_defaultBehavior As Boolean = True

    Public PlusMinusSize As Size
    Protected m_bmpMinus As Bitmap, m_bmpPlus As Bitmap

    Private m_hideHead As Boolean = False

    Private m_hilightWhenMinus As Boolean = False
    Private m_hilightGroupParentText As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.CellModels.Add("TreeCell", New TreeCellModel(Me.Model))
    End Sub
    Public Sub Init()
      If Not m_defaultBehavior Then
        Me.Model.Options.NumberedColHeaders = False
        Me.Model.Options.WrapCellBehavior = GridWrapCellBehavior.WrapRow
        'By PLA
        Me.HorizontalThumbTrack = True
        Me.VerticalThumbTrack = True
        Me.Properties.FixedLinesColor = Me.Properties.GridLineColor
        'By PLA
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property TreeTable() As TreeTable
      Get
        Return m_treetable
      End Get
      Set(ByVal Value As TreeTable)
        If Not m_treetable Is Nothing Then
          RemoveHandler m_treetable.RowExpandStateChanged, AddressOf RowExpandStateChanged

          RemoveHandler Me.QueryCellInfo, AddressOf GridQueryCellInfo
          RemoveHandler Me.QueryRowCount, AddressOf GridQueryRowCount
          RemoveHandler Me.QueryColCount, AddressOf GridQueryColCount

          RemoveHandler Me.SaveCellInfo, AddressOf GridSaveCellInfo

          RemoveHandler Me.QueryRowHeight, AddressOf GridQueryRowHeight
          RemoveHandler Me.QueryColWidth, AddressOf GridQueryColWidth
          RemoveHandler Me.QueryCoveredRange, AddressOf GridQueryCoveredRange
        End If
        m_treetable = Value
        If Not m_treetable Is Nothing Then
          AddHandler m_treetable.RowExpandStateChanged, AddressOf RowExpandStateChanged
          'prepare the grid for virtual data
          Me.ResetVolatileData()

          'hook up the events needed for virtual grid
          'While only the QueryCellInfo is absolutely required,
          'it would be unusual not to handle at least one of the row or column count events
          AddHandler Me.QueryCellInfo, AddressOf GridQueryCellInfo
          AddHandler Me.QueryRowCount, AddressOf GridQueryRowCount
          AddHandler Me.QueryColCount, AddressOf GridQueryColCount

          'if you want to edit your data in the grid, you need to 
          'handle saving data back to the data source...
          AddHandler Me.SaveCellInfo, AddressOf GridSaveCellInfo

          '
          'other events that you can use to provide virtual data
          'these events are optional depending upon the functionality you want
          AddHandler Me.QueryRowHeight, AddressOf GridQueryRowHeight
          AddHandler Me.QueryColWidth, AddressOf GridQueryColWidth
          AddHandler Me.QueryCoveredRange, AddressOf GridQueryCoveredRange

          Me.BeginUpdate()
          For i As Integer = 1 To Me.ColCount
            For Each col As DataColumn In Me.m_treetable.Columns
              If Not Me.TreeTableStyle.GridColumnStyles.Contains(col.ColumnName) Then
                If i - 1 = col.Ordinal Then
                  Me.Cols.Hidden(i) = True
                End If
              Else
                If i - 1 = col.Ordinal Then
                  Me.Cols.Hidden(i) = False
                  Me.ColWidths(i) = Me.TreeTableStyle.GridColumnStyles(col.ColumnName).Width
                End If
              End If
            Next
          Next
          For j As Integer = 1 To Me.RowCount
            Rows.Hidden(j) = False
          Next
          If m_hideHead Then
            Rows.Hidden(0) = True
          End If
          Me.EndUpdate()
        End If
      End Set
    End Property
    Public Property TreeTableStyle() As DataGridTableStyle
      Get
        Return m_tableStyle
      End Get
      Set(ByVal Value As DataGridTableStyle)
        m_tableStyle = Value
      End Set
    End Property
    Public Property DefaultBehavior() As Boolean      Get        Return m_defaultBehavior      End Get      Set(ByVal Value As Boolean)        m_defaultBehavior = Value      End Set    End Property
    Public Property AutoColumnResize() As Boolean      Get        Return m_autoColumnResize      End Get      Set(ByVal Value As Boolean)        m_autoColumnResize = Value      End Set    End Property
    <Browsable(False)> _
    Public ReadOnly Property ForeColorList() As ColorCollection      Get        Dim myForeColorList As New ColorCollection        For Each col As Color In ColorList          If CInt(col.R) + CInt(col.G) + CInt(col.B) > 128 * 3 Then
            myForeColorList.Add(Color.Black)
          Else
            myForeColorList.Add(Color.White)
          End If
        Next        Return myForeColorList      End Get    End Property
    <Category("Colors"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property ColorList() As ColorCollection      Get        Return m_colorList      End Get      Set(ByVal Value As ColorCollection)        m_colorList = Value      End Set    End Property
    Public Property PlusMinusColumnIndex() As Integer      Get        Return m_plusMinusColumnIndex      End Get      Set(ByVal Value As Integer)        m_plusMinusColumnIndex = Value      End Set    End Property
    Public Property HideHead() As Boolean      Get        Return m_hideHead      End Get      Set(ByVal Value As Boolean)        m_hideHead = Value      End Set    End Property
    Public Property HilightWhenMinus() As Boolean      Get        Return Me.m_hilightWhenMinus      End Get      Set(ByVal Value As Boolean)        m_hilightWhenMinus = Value      End Set    End Property
    Public Property HilightGroupParentText() As Boolean      Get        Return Me.m_hilightGroupParentText      End Get      Set(ByVal Value As Boolean)        m_hilightGroupParentText = Value      End Set    End Property
#End Region

#Region "Event Handlers"
    Private Sub LKGrid_CellClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs) Handles MyBase.CellClick
      If Not m_defaultBehavior Then
        Try
          Dim row As TreeRow = CType(m_treetable.Rows(e.RowIndex), TreeRow)
          If e.IsOverImage Then
            m_treetable.ToggleRowState(row)
          End If
        Catch ex As Exception

        End Try
      End If
    End Sub
    Private Sub RowExpandStateChanged(ByVal e As RowExpandCollapseEventArgs)
      RefreshHeights()
    End Sub
    Private Sub LKGrid_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      If Not m_defaultBehavior Then
        If m_autoColumnResize Then
          Dim space As Integer = SystemInformation.VerticalScrollBarWidth + 10
          Dim w As Integer = Me.Width
          Dim preferredWidth As Integer = w - (space + Me.ColWidths(0))
          Dim allColWidth As Integer = 0

          For i As Integer = 1 To Me.ColCount
            allColWidth += Me.ColWidths(i)
          Next
          If allColWidth < preferredWidth Then
            For i As Integer = 1 To Me.ColCount
              Me.ColWidths(i) = CInt((Me.ColWidths(i) / allColWidth) * preferredWidth)
            Next
          End If

        End If
      End If
    End Sub
#End Region

#Region "Methods"
    Public Shared Function GetDefaultColorList() As ColorCollection
      Dim myColorList As New ColorCollection
      'Dim myPropertyService As Longkong.Core.Properties.PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      Dim colorListTokens As String = "252,252,3;77,247,242;230,23,23" 'myPropertyService.GetProperty("Pojjaman.ColorList", "0,0,0")
      If Not colorListTokens = "" Then
        Dim colorStringList As String() = colorListTokens.Split(New Char() {";"c})
        For Each colorString As String In colorStringList
          Dim colorRgb As String() = colorString.Split(New Char() {","c})
          myColorList.Add(Color.FromArgb(CInt(colorRgb(0)), CInt(colorRgb(1)), CInt(colorRgb(2))))
        Next
      End If
      Return myColorList
    End Function
    Public Sub RefreshHeights()
      If Me.m_treetable Is Nothing Then
        Return
      End If
      Me.BeginUpdate()
      For Each row As TreeRow In m_treetable.Rows
        If row.IsVisible Then
          Rows.Hidden(row.Index + 1) = False
        Else
          Rows.Hidden(row.Index + 1) = True
        End If
        If m_hideHead Then
          Rows.Hidden(0) = True
        End If
      Next
      Me.EndUpdate()
      Me.Refresh()
    End Sub
#End Region

#Region "GridEvents"
    '
    'save the changes back to the datasource
    Sub GridSaveCellInfo(ByVal sender As Object, ByVal e As GridSaveCellInfoEventArgs)
      Try
        'move the changes back to the external data object
        If e.ColIndex > 0 AndAlso e.RowIndex > 0 Then
          Me.m_treetable.Rows(e.RowIndex - 1)(e.ColIndex - 1) = e.Style.CellValue
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
      'refresh this row so change is displayed
      Me.Refresh()
      e.Handled = True
    End Sub 'GridSaveCellInfo

    '
    'provide the row count from the datasource
    Sub GridQueryRowCount(ByVal sender As Object, ByVal e As GridRowColCountEventArgs)
      e.Count = Me.m_treetable.Rows.Count
      e.Handled = True
    End Sub 'GridQueryRowCount



    'provide the column count from the datasource
    Sub GridQueryColCount(ByVal sender As Object, ByVal e As GridRowColCountEventArgs)
      e.Count = Me.m_treetable.Columns.Count
      e.Handled = True
    End Sub 'GridQueryColCount

    'provide the data from the datasource
    Sub GridQueryCellInfo(ByVal sender As Object, ByVal e As GridQueryCellInfoEventArgs)
      If e Is Nothing Then
        Return
      End If
      Dim i As Integer = 0
      Try
        If e.RowIndex > 0 AndAlso e.ColIndex > 0 Then
          i = 1
          e.Style.CellValue = Me.m_treetable.Rows(e.RowIndex - 1)(e.ColIndex - 1)
          Dim row As TreeRow = CType(m_treetable.Rows(e.RowIndex - 1), TreeRow)
          Dim state As RowExpandState = row.State
          Dim level As Integer = row.Level
          i = 2
          For Each col As DataColumn In Me.m_treetable.Columns
            If Me.TreeTableStyle.GridColumnStyles.Contains(col.ColumnName) Then
              If e.ColIndex - 1 = col.Ordinal Then
                If TypeOf Me.TreeTableStyle.GridColumnStyles(col.ColumnName) Is DataGridCheckBoxColumn Then
                  i = 26
                  If CType(Me.m_treetable.Rows(e.RowIndex - 1), TreeRow).Level > 0 Then
                    e.Style.CellType = "CheckBox"
                    e.Style.TriState = False
                    e.Style.CheckBoxOptions.CheckedValue = "True"
                    e.Style.CheckBoxOptions.UncheckedValue = "False"
                    e.Style.Description = Me.TreeTableStyle.GridColumnStyles(col.ColumnName).HeaderText
                  End If
                  i = 27
                ElseIf TypeOf Me.TreeTableStyle.GridColumnStyles(col.ColumnName) Is DataGridButtonColumn Then
                  i = 28
                  If Me.m_treetable.Rows(e.RowIndex - 1)(e.ColIndex - 1).ToString.ToLower <> "invisible" Then
                    If Not CType(Me.m_treetable.Rows(e.RowIndex - 1), TreeRow).Tag Is Nothing Then
                      e.Style.CellType = "PushButton"
                      e.Style.CellAppearance = GridCellAppearance.Raised
                    End If
                  Else
                    e.Style.Text = ""
                  End If
                  i = 29
                ElseIf TypeOf Me.TreeTableStyle.GridColumnStyles(col.ColumnName) Is DataGridComboColumn Then
                  i = 30
                  Dim cmbCol As DataGridComboColumn = CType(Me.TreeTableStyle.GridColumnStyles(col.ColumnName), DataGridComboColumn)
                  If state = RowExpandState.None AndAlso Not CType(Me.m_treetable.Rows(e.RowIndex - 1), TreeRow).Tag Is Nothing Then
                    e.Style.CellType = "ComboBox"
                    e.Style.DataSource = cmbCol.DataTable
                    e.Style.DisplayMember = cmbCol.DisplayMember
                    e.Style.ValueMember = cmbCol.ValueMember
                    e.Style.DropDownStyle = GridDropDownStyle.AutoComplete
                  End If
                  i = 31
                ElseIf TypeOf Me.TreeTableStyle.GridColumnStyles(col.ColumnName) Is PlusMinusTreeTextColumn Then
                  i = 32
                  If e.RowIndex > Me.Rows.HeaderCount Then 'ไม่งั้นจะขึ้นขาวๆ ใน col ที่มีภาพ +-
                    e.Style.CellType = "TreeCell"
                  End If
                  If HilightGroupParentText And CType(Me.m_treetable.Rows(e.RowIndex - 1), TreeRow).Level = 0 Then
                    ' Hilight ที่หัวของ tree นั้นๆที่เป็น Level 0
                    e.Style.Font.Bold = True
                  End If
                  i = 33
                End If
                i = 34
                If Me.TreeTableStyle.GridColumnStyles(col.ColumnName).ReadOnly Then
                  e.Style.ReadOnly = True
                End If
                i = 35
                If TypeOf Me.TreeTableStyle.GridColumnStyles(col.ColumnName) Is TreeTextColumn Then
                  Dim ttc As TreeTextColumn = CType(Me.TreeTableStyle.GridColumnStyles(col.ColumnName), TreeTextColumn)
                  If e.RowIndex = 0 Then
                    Select Case ttc.Alignment
                      Case HorizontalAlignment.Center
                        e.Style.HorizontalAlignment = GridHorizontalAlignment.Center
                      Case HorizontalAlignment.Left
                        e.Style.HorizontalAlignment = GridHorizontalAlignment.Left
                      Case HorizontalAlignment.Right
                        e.Style.HorizontalAlignment = GridHorizontalAlignment.Right
                    End Select
                  Else
                    Select Case ttc.DataAlignment
                      Case HorizontalAlignment.Center
                        e.Style.HorizontalAlignment = GridHorizontalAlignment.Center
                      Case HorizontalAlignment.Left
                        e.Style.HorizontalAlignment = GridHorizontalAlignment.Left
                      Case HorizontalAlignment.Right
                        e.Style.HorizontalAlignment = GridHorizontalAlignment.Right
                    End Select
                  End If
                End If
              End If
            End If
          Next
          i = 3
          'If Me.CurrentCell.RowIndex = e.RowIndex Then
          '    backBrush = New SolidBrush(dg.SelectionBackColor)
          '    foreBrush = New SolidBrush(dg.SelectionForeColor)
          'ElseIf row.State = RowExpandState.None Then
          If row.State = RowExpandState.None OrElse row.State = RowExpandState.UnderParent Then
            e.Style.BackColor = Me.BackColor
            e.Style.TextColor = Me.ForeColor
          Else
            e.Style.BackColor = ColorList((level Mod ColorList.Count))
            e.Style.TextColor = ForeColorList((level Mod ColorList.Count))
          End If
          'If row.State <> RowExpandState.None Then
          '    myFont = New Font("Tahoma", 8, FontStyle.Bold)
          'Else
          '    myFont = MyBase.TextBox.Font
          'End If
          'If CType(m_treetable.Rows(e.RowIndex - 1), TreeRow).State = RowExpandState.Expanded Then
          '    e.Style.BackColor = Color.FromArgb(&HFF, &HBF, &H34)
          'End If
          If m_hilightWhenMinus AndAlso IsNumeric(e.Style.CellValue) Then
            Try
              If CDec(e.Style.CellValue) < 0 Then
                e.Style.TextColor = Color.Red
                e.Style.Font.Bold = True
              End If
            Catch ex As Exception
              '--pui-- กรณีบาง filed vb เข้าใจว่าเป็นตัวเลขเช่น '22778128,22778129,22781784,22781785 ซึ่งจะทำให้ CDec(..) นั้น error
            End Try
          End If
        ElseIf e.RowIndex = 0 Then
          i = 4
          For Each col As DataColumn In Me.m_treetable.Columns
            i = 5
            If Me.TreeTableStyle.GridColumnStyles.Contains(col.ColumnName) Then
              If e.ColIndex - 1 = col.Ordinal Then
                e.Style.CellValue = Me.TreeTableStyle.GridColumnStyles(col.ColumnName).HeaderText
              End If
            End If
            i = 6
          Next
          i = 7
        End If
        e.Handled = True
      Catch ex As Exception
        MessageBox.Show(ex.ToString & ":" & i.ToString)
      End Try
    End Sub 'GridQueryCellInfo
    Private Function GetStyleColIndex(ByVal index As Integer) As Integer
      For Each col As DataColumn In Me.m_treetable.Columns
        If index - 1 = col.Ordinal Then
          If Me.TreeTableStyle.GridColumnStyles.Contains(col.ColumnName) Then
            Return Me.TreeTableStyle.GridColumnStyles.IndexOf(Me.TreeTableStyle.GridColumnStyles(col.ColumnName))
          End If
        End If
      Next
    End Function
    Private Sub LKGrid_CellButtonClicked(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellButtonClickedEventArgs) Handles MyBase.CellButtonClicked
      If Me(e.RowIndex, e.ColIndex).CellType = "PushButton" Then
        Me.CurrentCell.MoveTo(e.RowIndex, e.ColIndex)
        RaiseEvent CellBtnClick(New ButtonColumnEventArgs(e.RowIndex - 1, GetStyleColIndex(e.ColIndex), Nothing))
        Me.Refresh()
      End If
    End Sub
    'provide the row heights on demand - optional...
    Sub GridQueryRowHeight(ByVal sender As Object, ByVal e As GridRowColSizeEventArgs)
      'If e.Index Mod 2 = 0 Then
      '    e.Size = 20
      '    e.Handled = True
      'End If
    End Sub 'GridQueryRowHeight



    'provide the col widths on demand - optional...
    Sub GridQueryColWidth(ByVal sender As Object, ByVal e As GridRowColSizeEventArgs)
      'e.Handled = True
    End Sub 'GridQueryColWidth

    'provide covered range on demand - optional...
    Sub GridQueryCoveredRange(ByVal sender As Object, ByVal e As GridQueryCoveredRangeEventArgs)
      ''cover odd rows, columns 1 through 3
      'If e.RowIndex Mod 2 = 1 AndAlso e.ColIndex >= 1 AndAlso e.ColIndex <= 3 Then
      '    e.Range = GridRangeInfo.Cells(e.RowIndex, 1, e.RowIndex, 3)
      '    e.Handled = True
      'End If

      ''cover column 6 with odd-even row pairs
      'If e.RowIndex > 0 AndAlso e.ColIndex = 6 Then
      '    Dim row As Integer = CInt((e.RowIndex - 1) / 2 * 2 + 1)
      '    Dim col As Integer = e.ColIndex
      '    e.Range = GridRangeInfo.Cells(row, col, row + 1, col)
      '    e.Handled = True
      'End If
    End Sub 'GridQueryCoveredRange
#End Region
  End Class
  Public Class TreeCellModel
    Inherits GridStaticCellModel
    'Constructors
    'Events
    'Methods
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      MyBase.New(info, context)
    End Sub
    Public Sub New(ByVal grid As GridModel)
      MyBase.New(grid)
    End Sub
    Public Overloads Overrides Function CreateRenderer(ByVal control As GridControlBase) As GridCellRendererBase
      Return New TreeCellRenderer(control, Me)
    End Function
  End Class
  Public Class TreeCellRenderer
    Inherits GridStaticCellRenderer


#Region "Members"
    Public PlusMinusSize As Size
    Protected m_bmpMinus As Bitmap, m_bmpPlus As Bitmap
    Private _rowIndex As Integer
    Private _colIndex As Integer
    Private m_lkGrid As LKGrid
#End Region

    Public Sub New(ByVal grid As GridControlBase, ByVal cellModel As GridCellModelBase)
      MyBase.New(grid, cellModel)
      m_lkGrid = CType(grid, LKGrid)
      Dim thePath As String = Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) & Path.DirectorySeparatorChar & ".." & Path.DirectorySeparatorChar & "Resources" & Path.DirectorySeparatorChar & "Images" & Path.DirectorySeparatorChar
      If Not ServiceManager.Services Is Nothing Then
        Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
        If myResourceService Is Nothing Then
          m_bmpMinus = New Bitmap(thePath & "tv_minus.bmp")
          m_bmpPlus = New Bitmap(thePath & "tv_plus.bmp")
        Else
          m_bmpMinus = myResourceService.GetBitmap("TreeGridMinus")
          m_bmpPlus = myResourceService.GetBitmap("TreeGridPlus")
        End If
      Else
        m_bmpMinus = New Bitmap(thePath & "tv_minus.bmp")
        m_bmpPlus = New Bitmap(thePath & "tv_plus.bmp")
      End If
      PlusMinusSize = m_bmpPlus.Size
    End Sub
    Public Overridable Sub OnCollapseRow(ByVal row As Integer)
      'Console.WriteLine("OnCollapseRow " + row.ToString() );
    End Sub
    Public Overridable Sub OnExpandRow(ByVal row As Integer)
      'Console.WriteLine("OnExpandRow " + row.ToString());
    End Sub
    Protected Overloads Overrides Sub OnClick(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As MouseEventArgs)
      If rowIndex < 1 Then
        MyBase.OnClick(rowIndex, colIndex, e)
        Return
      End If
      Dim dt As TreeTable = CType(m_lkGrid.TreeTable, TreeTable)
      Dim row As TreeRow = CType(dt.Rows(rowIndex - 1), TreeRow)
      Dim rect As Rectangle
      rect = GetCellBoundsCore(rowIndex, colIndex)
      Dim X As Integer
      X = (rect.X _
                  + (PlusMinusSize.Width * row.Level))
      rect.X = X
      Dim Y As Integer
      Y = rect.Y + CInt((rect.Height / 2) - (PlusMinusSize.Height / 2))
      rect.Y = Y
      rect.Width = PlusMinusSize.Width
      rect.Height = PlusMinusSize.Height
      If rect.Contains(New Point(e.X, e.Y)) Then
        dt.ToggleRowState(row)
      End If
      MyBase.OnClick(rowIndex, colIndex, e)
    End Sub
    Protected Overloads Overrides Sub OnDraw(ByVal g As Graphics, ByVal clientRectangle As Rectangle, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal style As GridStyleInfo)
      If clientRectangle.IsEmpty Then
        Return
      End If
      Try
        Dim dt As TreeTable = CType(m_lkGrid.TreeTable, TreeTable)
        Dim row As TreeRow = CType(dt.Rows(rowIndex - 1), TreeRow)
        Dim level As Integer = row.Level
        Dim state As RowExpandState = row.State
        Dim rect As Rectangle
        rect = GetCellBoundsCore(rowIndex, colIndex)
        Dim X As Integer
        X = (rect.X _
                    + (PlusMinusSize.Width * row.Level))
        Dim Y As Integer
        Y = rect.Y + CInt((rect.Height / 2) - (PlusMinusSize.Height / 2))

        Dim LastRow As TreeRow
        If rowIndex > 1 Then
          LastRow = CType(m_lkGrid.TreeTable.Rows(rowIndex - 2), TreeRow)
        End If
        For i As Integer = 0 To level
          If state = RowExpandState.None And i = level Then
            Exit For
          End If
          If (i <> level Or i = 0 Or (Not LastRow Is Nothing AndAlso LastRow.Level >= level)) And rowIndex - 1 > 0 Then
            g.FillRectangle(New SolidBrush(CType(m_lkGrid.ColorList((i Mod m_lkGrid.ColorList.Count)), Color)), New Rectangle(clientRectangle.X + i * PlusMinusSize.Width, clientRectangle.Y - 1, Me.PlusMinusSize.Width, clientRectangle.Height + 1))
          Else
            g.FillRectangle(New SolidBrush(CType(m_lkGrid.ColorList((i Mod m_lkGrid.ColorList.Count)), Color)), New Rectangle(clientRectangle.X + i * PlusMinusSize.Width, clientRectangle.Y, Me.PlusMinusSize.Width, clientRectangle.Height))
          End If
        Next

        If state = RowExpandState.Collapsed Then
          g.DrawImage(Me.m_bmpPlus, X, Y)
        ElseIf state = RowExpandState.Expanded Then
          g.DrawImage(Me.m_bmpMinus, X, Y)
        End If

        'now draw text past the image...
        Dim drawDisabled As Boolean
        drawDisabled = False
        Dim displayText As String
        displayText = String.Empty
        X = (X _
                    + (PlusMinusSize.Width + 2))

        Dim textRectangle As Rectangle
        textRectangle = RemoveMargins(clientRectangle, style)
        Dim shift As Integer
        shift = (X - textRectangle.X)
        textRectangle.X = X
        textRectangle.Width = (textRectangle.Width - shift)
        If textRectangle.IsEmpty Then
          Return
        End If
        Try
          displayText = Model.GetFormattedOrActiveTextAt(rowIndex, colIndex, style)
        Catch ex As System.Exception
          displayText = style.Text
          'style.ToolTip = ex.Message;
          drawDisabled = True
        End Try
        If style.HasError Then
          displayText = style.Error
          drawDisabled = True
        End If
        If (displayText.Length > 0) Then
          Dim font As font
          font = style.Font.GdipFont
          Dim textColor As Color
          textColor = CType(IIf(Grid.Model.Properties.BlackWhite, Color.Black, style.TextColor), Color)
          DrawText(g, displayText, font, textRectangle, style, textColor, drawDisabled)
        End If
      Catch ex As System.Exception
      End Try
    End Sub
  End Class
End Namespace
