Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms


Namespace Longkong.Pojjaman.Gui.Components

    Public Class PJMDataGrid
        Inherits ColumnDragDataGrid

#Region "Members"
        Private m_allowRowDeletion As Boolean = False
        Private m_autoColumnResize As Boolean = True
        Private m_columnResize As Boolean = False
        Private m_rowResize As Boolean = False
        Private m_columnLeft As Integer = 0
        Private m_rowTop As Integer = 0
        Private m_columnIndex As Integer = -1
        Private m_rowIndex As Integer = -1
        Private m_preferredWidth As Integer = 0
        Private m_preferredHeight As Integer = 0
        Private m_allowColumnResize As Boolean = False
        Private m_usePreferredSize As Boolean = False
        Private m_fullRowSelect As Boolean = False
        Private m_allowNew As Boolean = False
        Private m_rowOrder As ArrayList
        Private m_gridScrollBar As VScrollBar
        Private m_selectedRow As Integer

        Protected protCustomColumnsHeaders As Boolean
        Protected protOldHeaderFont As Font
        Protected protNRowsInCaption As Integer
        Protected protRowHeaderWidth As Integer

        Protected Const WM_KEYDOWN As Integer = &H100
        Protected Const VK_LEFT As Integer = &H25
        Protected Const VK_UP As Integer = &H26
        Protected Const VK_RIGHT As Integer = &H27
        Protected Const VK_DOWN As Integer = &H28

        Private m_hitRow As Integer
        Private m_hitCol As Integer
        Private oldSelectedRow As Integer = -1
        Private m_rowHeights As DataGridRowHeightSetter
        Public WithEvents m_dataTable As DataTable

#End Region

#Region "Events"
        Public Event CellValueChanged(ByVal e As DatagridCellValueChangedEventArgs)
        Public Event CellTextChanged(ByVal e As DatagridCellTextChangedEventArgs)
        Public Event ColumnHeaderClicked(ByVal sender As Object, ByVal e As ColumnHeaderClickEventArgs)
        Public Sub OnCellTextChanged(ByVal e As DatagridCellTextChangedEventArgs)
            RaiseEvent CellTextChanged(e)
        End Sub
        Public Sub ChangeCellValue(ByVal e As DatagridCellValueChangedEventArgs)
            RaiseEvent CellValueChanged(e)
        End Sub
        Private Sub PJMDataGrid_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.CurrentCellChanged
            Dim row As Integer = Me.CurrentCell.RowNumber
            Dim col As Integer = Me.CurrentCell.ColumnNumber
            Me.SelectRow(row, col)
            'If Me.TableStyle.GridColumnStyles(col).ReadOnly = True Or Me.TableStyle.GridColumnStyles(col).Width = 0 Then
            '    Me.ProcessTabKey(Keys.Tab Or Keys.Shift)
            'End If
        End Sub
        Private Sub PJMDataGrid_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DataSourceChanged
            Try
                Dim cm As CurrencyManager = CType(Me.BindingContext(Me.DataSource, Me.DataMember), CurrencyManager)
                CType(cm.List, DataView).AllowNew = m_allowNew
                m_rowHeights = New DataGridRowHeightSetter(Me)
                If TypeOf Me.DataSource Is ExpandableRowDataTable Then
                    CType(Me.DataSource, ExpandableRowDataTable).Grid = Me
                    CType(Me.DataSource, ExpandableRowDataTable).m_allowNew = Me.m_allowNew
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub PJMDataGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
            If Not TypeOf Me.DataSource Is ExpandableRowDataTable Then
                Return
            End If
            Dim p As Point = Me.PointToClient(Cursor.Position)
            Dim hti As DataGrid.HitTestInfo = Me.HitTest(p)
            If hti.Type <> DataGrid.HitTestType.Cell Then
                Exit Sub
            End If            Dim dt As ExpandableRowDataTable = CType(Me.DataSource, ExpandableRowDataTable)            Dim row As ExpandableDataRow = CType(dt.Rows(hti.Row), ExpandableDataRow)            dt.ToggleRowState(row)
        End Sub

        Private Sub PJMDataGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
            If Not TypeOf Me.DataSource Is ExpandableRowDataTable Then
                Return
            End If
            Dim plusMinusColIndex As Integer = Me.GetPlusMinusColumnIndex            If plusMinusColIndex = -1 Then
                Return
            End If            Dim p As Point = Me.PointToClient(Cursor.Position)
            Dim cursorBounds As New Rectangle(p.X, p.Y, 1, 1)
            Dim hti As DataGrid.HitTestInfo = Me.HitTest(p)
            If hti.Type <> DataGrid.HitTestType.Cell Then
                Exit Sub
            End If
            Dim dt As ExpandableRowDataTable = CType(Me.DataSource, ExpandableRowDataTable)
            Dim row As ExpandableDataRow = CType(dt.Rows(hti.Row), ExpandableDataRow)
            Dim plusMinusCellBound As Rectangle
            plusMinusCellBound = Me.GetCellBounds(hti.Row, plusMinusColIndex)
            Dim plusminusLocation As Point
            plusminusLocation.X = plusMinusCellBound.X + (row.Level * PlusMinusColumn.PlusMinusSize.Width)
            plusminusLocation.Y = plusMinusCellBound.Y + CInt((plusMinusCellBound.Height / 2) - (PlusMinusColumn.PlusMinusSize.Height / 2))
            Dim plusMinusRect As New Rectangle(plusminusLocation, PlusMinusColumn.PlusMinusSize)
            If cursorBounds.IntersectsWith(plusMinusRect) Then
                dt.ToggleRowState(row)
            End If
        End Sub
        Private Sub PJMDataGrid_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
            If m_autoColumnResize AndAlso Not Me.TableStyles Is Nothing AndAlso Me.TableStyles.Count > 0 Then
                Dim space As Integer = SystemInformation.VerticalScrollBarWidth + 10
                Dim w As Integer = Me.Width
                Dim preferredWidth As Integer = w - (space + Me.RowHeaderWidth)
                Dim allColWidth As Integer = 0
                For Each col As DataGridColumnStyle In Me.TableStyles(0).GridColumnStyles
                    allColWidth += col.Width
                Next
                For Each col As DataGridColumnStyle In Me.TableStyles(0).GridColumnStyles
                    col.Width = CInt((col.Width / allColWidth) * preferredWidth)
                Next
            End If
            Try
                Me.UpdateScrollBar()
            Catch ex As Exception

            End Try
        End Sub
        Private lastRow As Integer = -1
        Private Sub PJMDataGrid_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Scroll
            Return
            If Me.m_rowOrder.IndexOf(VertScrollBar.Value) = -1 Then
                Dim nextRow As Integer = NextVisibleRow(lastRow, VertScrollBar.Value)
                lastRow = VertScrollBar.Value
                ScrollToRow(nextRow)
            Else
                lastRow = VertScrollBar.Value
            End If
        End Sub
        Private Sub PJMDataGrid_ListChanged(ByVal sender As Object, ByVal e As ItemChangedEventArgs)

        End Sub
#End Region

#Region "Constructors"
        Public Sub New()
            ' put a stop to the flickering nonsense
            Me.SetStyle(ControlStyles.DoubleBuffer, True)
            m_preferredWidth = 0 'Me.PreferredColumnWidth
            m_preferredHeight = Me.PreferredRowHeight
            m_hitRow = -1
            m_hitCol = -1
            m_selectedRow = -1
            m_gridScrollBar = New VScrollBar

            protNRowsInCaption = 3
            protRowHeaderWidth = Me.RowHeaderWidth
            CustomColumnHeaders = True

        End Sub
#End Region

#Region "Properies"
        Public Property AllowRowDeletion() As Boolean            Get                Return m_allowRowDeletion            End Get            Set(ByVal Value As Boolean)                m_allowRowDeletion = Value            End Set        End Property
        Public Property AutoColumnResize() As Boolean            Get                Return m_autoColumnResize            End Get            Set(ByVal Value As Boolean)                m_autoColumnResize = Value            End Set        End Property
        Public ReadOnly Property RowHeights() As DataGridRowHeightSetter            Get                Return m_rowHeights            End Get        End Property
        Public Property AllowNew() As Boolean            Get                Return m_allowNew            End Get            Set(ByVal Value As Boolean)                m_allowNew = Value            End Set        End Property
        Public ReadOnly Property SelectedRow() As Integer            Get                Return m_selectedRow            End Get        End Property
        Public Property CustomColumnHeaders() As Boolean
            Get
                Return protCustomColumnsHeaders
            End Get
            Set(ByVal Value As Boolean)
                If Value Then
                    If protCustomColumnsHeaders = False Then
                        protOldHeaderFont = Me.HeaderFont
                        Dim g As Graphics = Me.CreateGraphics()
                        Me.HeaderFont = New Font(System.Drawing.FontFamily.GenericSerif, (protNRowsInCaption) * Me.HeaderFont.GetHeight(g) - 8, FontStyle.Regular, GraphicsUnit.Point)
                        g.Dispose()
                        protRowHeaderWidth = Me.RowHeaderWidth
                    End If
                    Me.CaptionVisible = False
                    Me.ColumnHeadersVisible = True
                    'Me.RowHeaderWidth = 0
                    'Me.RowHeadersVisible = False
                Else
                    If Not Me.HeaderFont Is Nothing Then Me.HeaderFont.Dispose()
                    Me.HeaderFont = Me.protOldHeaderFont
                    Me.protOldHeaderFont = Nothing
                    'Me.CaptionVisible = True
                    Me.ColumnHeadersVisible = True
                    'Me.RowHeaderWidth = protRowHeaderWidth
                    'Me.RowHeadersVisible = True
                End If
                protCustomColumnsHeaders = Value
            End Set
        End Property
        Public Property AllowColumnResize() As Boolean
            Get
                Return m_allowColumnResize
            End Get
            Set(ByVal Value As Boolean)
                m_allowColumnResize = Value
            End Set
        End Property
        Public Property FullRowSelect() As Boolean
            Get
                Return m_fullRowSelect
            End Get
            Set(ByVal Value As Boolean)
                m_fullRowSelect = Value
            End Set
        End Property
        Private ReadOnly Property TableStyle() As DataGridTableStyle
            Get
                Dim myGridTableInfo As FieldInfo = Me.GetType().GetField("myGridTable", BindingFlags.NonPublic Or BindingFlags.Instance)
                Return CType(myGridTableInfo.GetValue(Me), DataGridTableStyle)
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub RefreshRowHeightSetter()
            Me.m_rowHeights = New DataGridRowHeightSetter(Me)
        End Sub
        Public Function SelectRow(ByVal row As Integer, Optional ByVal col As Integer = 0) As Integer
            If m_selectedRow >= 0 And m_selectedRow < CType(Me.DataSource, DataTable).Rows.Count Then
                Me.UnSelect(m_selectedRow)
            End If
            If TypeOf Me.DataSource Is ExpandableRowDataTable Then
                Dim myRow As ExpandableDataRow = CType(CType(Me.DataSource, ExpandableRowDataTable).Rows(row), ExpandableDataRow)
                If Not myRow.Parent Is Nothing AndAlso myRow.Parent.State = PlusMinusState.Collapsed Then
                    If Not myRow.Parent.NextSibling Is Nothing Then
                        SelectRow(myRow.Parent.NextSibling.Index, col)
                        Return myRow.Parent.NextSibling.Index
                    End If
                End If
            End If

            If Me.CurrentCell.ColumnNumber <> col And Me.CurrentCell.RowNumber <> row Then
                Me.CurrentCell = New DataGridCell(row, col)
            End If
            m_selectedRow = Me.CurrentCell.RowNumber
            Me.Select(row)
            Try
                Me.BeginEdit(Me.TableStyles(0).GridColumnStyles(col), row)
            Catch ex As Exception

            End Try
            'If state <> PlusMinusState.UnderParent Then
            '    Me.EndEdit(Me.TableStyles(0).GridColumnStyles(col), row, False)
            'End If
        End Function
        Private Function NextVisibleRow(ByVal lastRow As Integer, ByVal idx As Integer) As Integer
            If lastRow < idx Then
                For i As Integer = 0 To m_rowOrder.Count - 1
                    If CInt(m_rowOrder(i)) >= idx Then
                        Return CInt(m_rowOrder(i))
                    End If
                Next
            End If
            If lastRow > idx Then
                For i As Integer = m_rowOrder.Count - 1 To 0 Step -1
                    If CInt(m_rowOrder(i)) <= idx Then
                        Return CInt(m_rowOrder(i))
                    End If
                Next
            End If
        End Function
        Public Function GetRowCount() As Integer
            Dim count As Integer
            m_rowOrder = New ArrayList
            If Not TypeOf Me.DataSource Is ExpandableRowDataTable Then
                Return 0
            End If
            Dim dt As ExpandableRowDataTable = CType(Me.DataSource, ExpandableRowDataTable)
            For i As Integer = 0 To dt.Rows.Count - 1
                If Me.m_rowHeights(i) > 0 Then
                    count += 1
                    m_rowOrder.Add(CType(dt.Rows(i), ExpandableDataRow).Index)
                End If
            Next
            Return count
        End Function
        Private Sub DrawHeader(ByVal g As Graphics, ByVal CallNativePaint As Boolean, ByVal ClipRect As Rectangle, ByVal OffsetX As Integer, ByVal OffsetY As Integer)
            Dim rs As Rectangle
            Dim rs2 As Rectangle
            Dim rs3 As Rectangle
            If g Is Nothing Then
                g = Me.CreateGraphics()
            End If
            Dim ev As PaintEventArgs
            Dim top As Integer = Me.HeaderFont.Height
            If CallNativePaint Then
                ev = New PaintEventArgs(g, ClipRect)
                MyBase.OnPaint(ev)
            End If
            If ClipRect.Top < top Then
                Dim b As New SolidBrush(Me.HeaderBackColor)
                Dim b2 As New SolidBrush(Me.HeaderForeColor)
                Dim b3 As New SolidBrush(Me.BackgroundColor)
                Dim x As Integer = Me.RowHeaderWidth + 4
                Dim i As Integer
                Dim w, r As Integer
                Dim dx As Integer
                rs3 = New Rectangle(0, 2, x - 2, top + 6)
                For i = Me.FirstVisibleColumn To Me.FirstVisibleColumn + Me.VisibleColumnCount - 1
                    If i = Me.FirstVisibleColumn Then
                        w = Me.GetCellBounds(Me.CurrentCell.RowNumber, i).Right - x - 1
                    Else
                        w = Me.TableStyles(0).GridColumnStyles(i).Width
                    End If
                    r = w + 2

                    If i = FirstVisibleColumn Then
                        dx = -4
                    Else
                        dx = 0
                    End If
                    rs = New Rectangle(x + 2 + dx, 3, r - 3 - dx, top + 3)
                    'rs2 = New Rectangle(x + 1 + dx, 1, r - dx, top + 8)
                    If Me.FirstVisibleColumn + Me.VisibleColumnCount - 1 = i Then
                        rs2 = New Rectangle(x + 1 + dx, 2, r - dx - 1, top + 6)
                    Else
                        rs2 = New Rectangle(x + 1 + dx, 2, r - dx, top + 6)
                    End If
                    g.FillRectangle(b, rs)
                    ControlPaint.DrawBorder3D(g, rs2)
                    PaintHeaderCell(g, Me.TableStyles(0).GridColumnStyles(i).HeaderText, Me.protOldHeaderFont, b2, rs, OffsetX, OffsetY)
                    x += w
                    If Me.FirstVisibleColumn + Me.VisibleColumnCount - 1 = i Then
                        Dim pn As New Drawing.Pen(Me.BackColor)
                        g.DrawLine(pn, x + 1, 2, x + 1, top + 6)
                        pn.Dispose()
                    End If
                Next
                Dim p As New Drawing.Pen(Me.BackgroundColor)
                g.DrawLine(p, x + 2, 2, x + 2, top + 7)
                p.Dispose()
                b.Dispose()
                b2.Dispose()
                g.FillRectangle(b3, rs3)
                b3.Dispose()
                Return
            End If
        End Sub
        Public Sub PaintHeaderCell(ByVal g As Graphics, ByVal Sentence As String, ByVal F As Font, ByVal br As Brush, ByVal Bounds As Rectangle, ByVal offsetx As Integer, ByVal offsety As Integer)
            Dim strs(protNRowsInCaption - 1), tt() As String
            tt = Sentence.Split(" "c)
            Dim i, j, n As Integer
            j = 0
            Dim s As String = ""
            Dim os As String
            os = s
            For i = 0 To protNRowsInCaption - 1
                strs(i) = ""
            Next
            For i = 0 To tt.Length - 1
                If s <> "" Then
                    s &= " " & tt(i)
                Else
                    s = tt(i)
                    os = s
                End If
                Dim w As Integer = CInt(g.MeasureString(s, F).Width)
                If w >= Bounds.Width Then
                    strs(j) = os
                    If s <> tt(i) Then
                        s = tt(i)
                        os = tt(i)
                    Else
                        s = ""
                        os = ""
                    End If
                    If j = protNRowsInCaption - 1 And i <= tt.Length - 1 Then
                        strs(j) = "..."
                        Exit For
                    End If
                    j += 1
                Else
                    os = s
                End If
                If i = tt.Length - 1 And j <> protNRowsInCaption Then
                    strs(j) = s
                End If
            Next
            n = Me.protNRowsInCaption - 1
            Dim h As Integer = (Bounds.Height Mod F.Height) \ 2
            For i = 0 To n
                Dim w As Integer = CInt(g.MeasureString(strs(i), F).Width)
                If w < Bounds.Width Then
                    w = (Bounds.Width - w) \ 2
                Else
                    If Bounds.Width > 0 Then
                        While w >= Bounds.Width
                            strs(i) = strs(i).Substring(0, strs(i).Length - 1)
                            w = CInt(g.MeasureString(strs(i), F).Width)
                        End While
                    Else
                        Return
                    End If
                    w = 0
                End If
                g.DrawString(strs(i), F, br, Bounds.X + w + offsetx, Bounds.Y + h + offsety)
                h += F.Height
            Next
        End Sub
        Public Function GetPlusMinusColumnIndex() As Integer
            For i As Integer = 0 To Me.TableStyles(0).GridColumnStyles.Count - 1
                Dim colStyle As DataGridColumnStyle = Me.TableStyles(0).GridColumnStyles(i)
                If TypeOf colStyle Is PlusMinusColumn Then
                    Return i
                End If
            Next
            Return -1
        End Function
        Public Sub ScrollToRow(ByVal row As Integer)
            If Not Me.DataSource Is Nothing Then
                Me.GridVScrolled(Me, New ScrollEventArgs(ScrollEventType.ThumbPosition, row))
            End If
        End Sub
        Private Sub SetRow(ByVal fromRow As DataRow, ByVal toRow As DataRow, ByVal numCols As Integer)
            Dim i As Integer
            i = 0
            Do While (i < numCols)
                toRow(i) = fromRow(i)
                i = (i + 1)
            Loop
        End Sub
        Public Sub MoveRowFromTo(ByVal fromRow As Integer, ByVal toRow As Integer)
            'save the row to be deleted
            If (toRow < 0) Then
                Return
            End If
            Dim dr As DataRow
            dr = m_dataTable.NewRow
            SetRow(m_dataTable.Rows(fromRow), dr, m_dataTable.Columns.Count)
            'delete it
            m_dataTable.Rows.RemoveAt(fromRow)
            'insert the copy
            m_dataTable.Rows.InsertAt(dr, toRow)
            'accept the changes so they show up in the grid
            m_dataTable.AcceptChanges()
        End Sub

        Public Sub UpdateScrollBar()
            lastRow = -1
            'If Me.VertScrollBar.Visible = True Or True Then
            Dim count As Integer = GetRowCount()
            Dim dt As ExpandableRowDataTable = CType(Me.DataSource, ExpandableRowDataTable)
            VertScrollBar.Minimum = 0
            Dim pageSize As Integer = CInt((Me.Height - 51) / 17)
            If pageSize < 0 Then
                pageSize = 0
            End If
            VertScrollBar.LargeChange = pageSize
            If count >= pageSize Then
                VertScrollBar.Maximum = CInt(m_rowOrder(count - pageSize)) + pageSize
            Else
                VertScrollBar.Visible = False
            End If
            'End If
        End Sub
        ' Since a row is composed of several different column styles, 
        ' we need to enumerate all of the column styles in the collection 
        ' and find the largest minimum height.
        Private Function CalculatePreferredHeight() As Integer

            Dim ts As DataGridTableStyle = Me.TableStyle
            Dim maxHeight As Integer = 0

            Dim cs As DataGridColumnStyle
            For Each cs In ts.GridColumnStyles
                Try
                    maxHeight = Math.Max(maxHeight, CType(cs, PJMColumnStyle).MinimumHeight)
                Catch ex As Exception
                    maxHeight = 24
                End Try
            Next cs
            Return maxHeight
        End Function
        Private Function GetRowTop(ByVal rowNum As Integer) As Integer
            Dim dg As New DataGrid
            Dim dgMethod As MethodInfo = dg.GetType().GetMethod("GetRowTop", BindingFlags.Instance Or BindingFlags.NonPublic) ', BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static );
            Return CInt(dgMethod.Invoke(Me, New Object() {rowNum}))
        End Function
        Private Sub SetRowHeight(ByVal rowIndex As Integer, ByVal height As Integer)
            Dim dg As New DataGrid
            Dim dgRowsInfo As PropertyInfo = dg.GetType().GetProperty("DataGridRows", BindingFlags.Instance Or BindingFlags.NonPublic) ', BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static );
            Dim rows As Object() = CType(dgRowsInfo.GetValue(Me, Nothing), Object())
            Dim dgRowHeightInfo As PropertyInfo = rows(rowIndex).GetType().GetProperty("Height", BindingFlags.Instance Or BindingFlags.Public)
            dgRowHeightInfo.SetValue(rows(rowIndex), height, Nothing)
        End Sub
        Private Function GetColumnLeft(ByVal columnNum As Integer) As Integer
            Dim ts As DataGridTableStyle = TableStyle
            Dim columnLeft As Integer = 0
            If ts.RowHeadersVisible Then
                columnLeft = ts.RowHeaderWidth
            End If
            Dim i As Integer
            For i = 0 To columnNum - 1
                columnLeft += ts.GridColumnStyles(i).Width
            Next i
            Return columnLeft
        End Function
        Public Function GetTblStyle(ByVal Table As DataTable) As DataGridTableStyle
            Dim tblStyle As DataGridTableStyle
            tblStyle = Me.TableStyles(Table.TableName)
            If tblStyle Is Nothing Then
                tblStyle = CreateTableStyle(Table)
                Me.TableStyles.Add(tblStyle)
            End If
            Return tblStyle
        End Function
        Public Sub AdjustColumnWidths(ByVal Table As DataTable)
            AdjustColumnWidthToTitles(Table)
            Dim i As Integer
            For i = 0 To Table.Columns.Count - 1
                AdjustColumnToOptimumSize(Table, i)
            Next
        End Sub

        Public Sub AdjustColumnWidthToTitles(ByVal Table As DataTable)
            Dim tblStyle As DataGridTableStyle
            tblStyle = GetTblStyle(Table)
            Dim i As Integer
            Dim cs As DataGridColumnStyle
            Dim g As Graphics
            g = Me.CreateGraphics()
            Dim f As Font = Me.HeaderFont
            If Me.CustomColumnHeaders Then
                f = Me.protOldHeaderFont
            End If
            For Each cs In tblStyle.GridColumnStyles
                If cs.Width <> 0 Then
                    If Me.CustomColumnHeaders Then
                        cs.Width = GetHeaderWidth(g, cs.HeaderText) + 10
                    Else
                        cs.Width = CInt(g.MeasureString(cs.HeaderText, f).Width + 10)
                    End If
                End If
            Next
            g.Dispose()
        End Sub
        Public Function GetHeaderWidth(ByVal g As Graphics, ByVal Text As String) As Integer
            Dim strs() As String
            strs = Text.Split(" "c)
            Dim ws(strs.Length - 1) As Integer
            Dim i, n As Integer
            n = Math.Min(ws.Length - 1, Me.protNRowsInCaption - 1)
            Dim f As Font
            If protCustomColumnsHeaders Then
                f = protOldHeaderFont
            Else
                f = Me.HeaderFont
            End If
            For i = 0 To n
                ws(i) = CInt(g.MeasureString(strs(i), f).Width)
                GetHeaderWidth = Math.Max(GetHeaderWidth, ws(i))
            Next
        End Function

        Private Sub AdjustColumnToOptimumSize(ByVal Table As DataTable, ByVal ColumnNumber As Integer)
            Try
                Dim cn As Integer = ColumnNumber
                Dim tbl As DataTable
                If Not Table Is Nothing Then
                    tbl = Table
                Else
                    If TypeOf Me.DataSource Is DataTable Then
                        tbl = CType(Me.DataSource, DataTable)
                    ElseIf TypeOf Me.DataSource Is DataView Then
                        tbl = CType(Me.DataSource, DataView).Table
                    Else
                        Return
                    End If
                End If
                If tbl.Columns(cn).DataType Is GetType(String) Then
                    Dim i, l As Integer
                    Dim tblStyle As DataGridTableStyle
                    For Each tblStyle In Me.TableStyles
                        If tblStyle.MappingName = tbl.TableName Then
                            Exit For
                        End If
                    Next
                    If Not tblStyle Is Nothing Then
                        If tblStyle.MappingName <> tbl.TableName Then
                            tblStyle = Nothing
                        End If
                    End If
                    If tblStyle Is Nothing Then
                        tblStyle = CreateTableStyle(tbl)
                    End If
                    l = tblStyle.GridColumnStyles(tbl.Columns(cn).ColumnName).Width
                    Dim g As Graphics
                    g = Me.CreateGraphics()
                    Dim f As Font = Me.Font
                    For i = 0 To tbl.Rows.Count - 1
                        l = CInt(System.Math.Max(l, g.MeasureString(CStr(tbl.Rows(i).Item(cn)), f).Width))
                    Next
                    g.Dispose()
                    l += 10
                    If l > tblStyle.GridColumnStyles(tbl.Columns(cn).ColumnName).Width Then
                        tblStyle.GridColumnStyles(tbl.Columns(cn).ColumnName).Width = l
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub
        Public Function CreateTableStyle(ByVal Table As DataTable) As DataGridTableStyle
            Dim ts1 As New DataGridTableStyle
            ts1.MappingName = Table.TableName
            Dim i As Integer
            For i = 0 To Table.Columns.Count - 1
                If Table.Columns(i).DataType Is GetType(Boolean) Then
                    Dim boolCol As New DataGridBoolColumn
                    boolCol.MappingName = Table.Columns(i).ColumnName
                    boolCol.HeaderText = Table.Columns(i).ColumnName
                    ts1.GridColumnStyles.Add(boolCol)
                Else
                    Dim TextCol As New HeaderAndDataAlignColumn
                    TextCol.MappingName = Table.Columns(i).ColumnName
                    TextCol.HeaderText = Table.Columns(i).ColumnName
                    ts1.GridColumnStyles.Add(TextCol)
                End If
            Next
            Me.TableStyles.Add(ts1)
            Return ts1
        End Function
        Public Sub SetColumnName(ByVal Table As DataTable, ByVal ColumnName As String, ByVal HeaderText As String)
            Dim tblStyle As DataGridTableStyle = GetTblStyle(Table)
            Try
                tblStyle.GridColumnStyles(ColumnName).HeaderText = HeaderText
            Catch ex As Exception
            End Try
        End Sub
#End Region

#Region "Overrides"

        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                SendKeys.Send("{Tab}")
                Return True
            End If
            If msg.Msg = WM_KEYDOWN Then
                Dim keyCode As Keys = CType((msg.WParam.ToInt32), Keys)
                If TypeOf Me.DataSource Is ExpandableRowDataTable Then
                    Dim dt As DataTable = CType(Me.DataSource, ExpandableRowDataTable)
                    Dim row As ExpandableDataRow
                    Dim colIndex As Integer = Me.CurrentCell.ColumnNumber
                    If m_selectedRow >= 0 Then
                        row = CType(dt.Rows(m_selectedRow), ExpandableDataRow)
                    End If
                    'Debug.WriteLine("ProcessCmdKey")
                    If dt.Rows.Count > 0 Then
                        If Not row Is Nothing Then
                            Dim parentRow As ExpandableDataRow = row.Parent
                            If keyCode = Keys.Left Then
                                If row.State = PlusMinusState.Expanded Then
                                    row.State = PlusMinusState.Collapsed
                                ElseIf Not row.Parent Is Nothing Then
                                    Me.SelectRow(parentRow.Index, colIndex)
                                End If
                                Invalidate()
                                Return True
                            ElseIf keyCode = Keys.Right Then ' expand current node or move down to first child
                                If Not row.State = PlusMinusState.Expanded And row.Childs.Count > 0 Then
                                    row.State = PlusMinusState.Expanded
                                ElseIf row.State = PlusMinusState.Expanded And row.Childs.Count > 0 Then
                                    Me.SelectRow(row.FirstChild.Index, colIndex)
                                End If
                                Invalidate()
                                Return True
                            ElseIf keyCode = Keys.Up Then
                                If row.PreviousSibling Is Nothing And Not row.Parent Is Nothing Then
                                    Me.SelectRow(parentRow.Index, colIndex)
                                    Invalidate()
                                    Return True
                                ElseIf Not row.PreviousSibling Is Nothing Then
                                    Dim prow As ExpandableDataRow = row.PreviousSibling
                                    If (prow.Childs.Count > 0 And prow.State = PlusMinusState.Expanded) Then
                                        While prow.Childs.Count > 0 And prow.State = PlusMinusState.Expanded
                                            prow = prow.LastChild
                                            Me.SelectRow(prow.Index, colIndex)
                                        End While
                                    Else
                                        Me.SelectRow(prow.Index, colIndex)
                                    End If
                                    Invalidate()
                                    Return True
                                End If
                            ElseIf keyCode = Keys.Down Then
                                If (row.State = PlusMinusState.Expanded And row.Childs.Count > 0) Then
                                    Me.SelectRow(row.FirstChild.Index, colIndex)
                                ElseIf row.NextSibling Is Nothing And Not row.Parent Is Nothing Then
                                    Dim thisRow As ExpandableDataRow = row
                                    While thisRow.NextSibling Is Nothing And Not thisRow.Parent Is Nothing
                                        thisRow = thisRow.Parent
                                        If Not thisRow.NextSibling Is Nothing Then
                                            Me.SelectRow(thisRow.NextSibling.Index, colIndex)
                                        End If
                                    End While
                                ElseIf Not row.NextSibling Is Nothing Then
                                    Me.SelectRow(row.NextSibling.Index, colIndex)
                                End If
                                Invalidate()
                                Return True
                            ElseIf keyCode = Keys.Tab Then

                            ElseIf keyCode = Keys.Delete Then
                                If Not m_allowRowDeletion Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                Else 'DataSource เป็นอย่างอื่น ไม่ใช่ ExpandableDataTable
                    If keyCode = Keys.Delete Then
                        Return True
                    End If
                End If
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function
        Protected Overrides Sub WndProc(ByRef msg As Message)
            If msg.Msg = WM_KEYDOWN Then
                'Debug.WriteLine("WndProc")
            End If
            MyBase.WndProc(msg)
        End Sub 'WndProc

        Public Overrides Function PreProcessMessage(ByRef msg As System.Windows.Forms.Message) As Boolean
            If msg.Msg = WM_KEYDOWN Then
                'Debug.WriteLine("PreProcessMessage")
            End If
            Return MyBase.PreProcessMessage(msg)
            'Dim keyCode As Keys = CType((msg.WParam.ToInt32 And Keys.KeyCode), Keys)
            'If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            '    Return False
            'End If
            'If msg.Msg = &H100 And keyCode = Keys.Delete Then
            '    Return False
            'End If
            'Return MyBase.PreProcessMessage(msg)
        End Function

        Protected Overloads Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            If protCustomColumnsHeaders = True Then
                DrawHeader(e.Graphics, True, e.ClipRectangle, 0, 0)
                Return
            End If
            MyBase.OnPaint(e)
        End Sub

        Public inTabKey As Boolean = False
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            inTabKey = keyData = Keys.Tab
            Return MyBase.ProcessDialogKey(keyData)
        End Function
        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            Dim hti As HitTestInfo = Me.HitTest(e.X, e.Y)
            Dim ts As DataGridTableStyle = Me.TableStyle
            Dim dg As DataGridColumnStyle
            Dim isPJMStyle As Boolean
            If hti.Column <> -1 Then
                dg = ts.GridColumnStyles(hti.Column)
                isPJMStyle = (TypeOf dg Is PJMColumnStyle)
            End If
            If Not m_allowColumnResize And hti.Type = DataGrid.HitTestType.ColumnResize Then
                Return
            End If
            If hti.Type = DataGrid.HitTestType.Cell And False Then
                m_hitCol = hti.Column
                m_hitRow = hti.Row
                'If Not IsNothing(Me.m_toolTip) And m_toolTip.Active Then
                '    m_toolTip.Active = False
                'End If
                'm_toolTip.SetToolTip(Me, "YES")
                'm_toolTip.Active = True
            End If
            If hti.Column <> -1 And m_columnResize AndAlso (Me.m_usePreferredSize Or isPJMStyle) Then
                If e.X >= m_columnLeft + m_preferredWidth Then
                    MyBase.OnMouseMove(e)
                End If
            Else
                If hti.Row <> -1 And m_rowResize And (Me.m_usePreferredSize Or isPJMStyle) Then
                    If e.Y >= m_rowTop + m_preferredHeight Then
                        MyBase.OnMouseMove(e)
                    End If
                Else
                    MyBase.OnMouseMove(e)
                End If
            End If
        End Sub
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            Dim hti As HitTestInfo = Me.HitTest(e.X, e.Y)
            If Not m_allowColumnResize And hti.Type = DataGrid.HitTestType.ColumnResize Then
                Return
            End If
            MyBase.OnMouseDown(e)
            Dim ts As DataGridTableStyle = Me.TableStyle
            If hti.Type = DataGrid.HitTestType.Cell And m_fullRowSelect Then
                Me.SelectRow(hti.Row, hti.Column)
            End If
            If hti.Type = DataGrid.HitTestType.ColumnHeader Then
                RaiseEvent ColumnHeaderClicked(Me, New ColumnHeaderClickEventArgs(hti.Column))
            End If
            If hti.Type = HitTestType.ColumnResize And hti.Column <> -1 Then
                m_rowResize = False
                m_columnResize = True
                m_columnLeft = GetColumnLeft(hti.Column)
                m_columnIndex = hti.Column
                Try
                    m_preferredWidth = 24 'CType(ts.GridColumnStyles(hti.Column), PJMColumnStyle).MinimumWidth
                Catch ex As Exception
                    'm_preferredWidth = Me.PreferredColumnWidth
                End Try
            Else
                If hti.Type = HitTestType.RowResize And hti.Row <> -1 Then
                    m_columnResize = False
                    m_rowResize = True
                    m_rowTop = GetRowTop(hti.Row)
                    m_rowIndex = hti.Row
                    Try
                        m_preferredHeight = CalculatePreferredHeight()
                    Catch ex As Exception
                        m_preferredHeight = Me.PreferredRowHeight
                    End Try

                Else
                    m_columnResize = False
                    m_rowResize = False
                End If
            End If
            If hti.Type = DataGrid.HitTestType.Cell Then
                Me.ContextMenu = Nothing 'Me.GridContextMenu
                'Me.manipulatedRow = hti.Row
                'Me.manipulatedColumn = hti.Column
            Else
                Me.ContextMenu = Nothing
            End If
        End Sub
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            Dim ts As DataGridTableStyle = Me.TableStyle
            Dim hti As HitTestInfo = Me.HitTest(e.X, e.Y)
            Dim dg As DataGridColumnStyle
            Dim isPJMStyle As Boolean
            If hti.Column <> -1 Then
                dg = ts.GridColumnStyles(hti.Column)
                isPJMStyle = (TypeOf dg Is PJMColumnStyle)
            End If
            MyBase.OnMouseUp(e)
            If m_columnResize And (Me.m_usePreferredSize Or isPJMStyle) Then
                If e.X < m_columnLeft + m_preferredWidth Then
                    ts.GridColumnStyles(m_columnIndex).Width = m_preferredWidth
                End If
                m_columnResize = False
            ElseIf m_rowResize And (Me.m_usePreferredSize Or isPJMStyle) Then
                If e.Y < m_rowTop + m_preferredHeight Then
                    SetRowHeight(m_rowIndex, m_preferredHeight)
                Else
                    'MyBase.OnMouseUp(e)
                End If
                m_rowResize = False
            End If
        End Sub
#End Region

    End Class
End Namespace

