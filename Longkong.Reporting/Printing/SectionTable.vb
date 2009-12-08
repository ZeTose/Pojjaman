Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class SectionTable
        Inherits ReportSection

#Region "Members"
        Private m_allowMultiPageWidth As Boolean
        Private m_alternatingRowTextStyle As TextStyle
        Private m_borderPens As borderPens
        Private m_columns As ArrayList
        Private m_currentHorizPage As Integer
        Private m_dataRowsFit As Integer
        Private m_dataSource As DataView
        Private m_detailRowTextStyle As TextStyle
        Private m_headerRowHeight As Single
        Private m_headerSizeInit As Boolean
        Private m_headerTextStyle As TextStyle
        Private m_infoForPages As ArrayList
        Private m_innerPenHeaderBottom As Pen
        Private m_innerPenRow As Pen
        Private m_maxDetailRowHeight As Single
        Private m_maxHeaderRowHeight As Single
        Private m_minDetailRowHeight As Single
        Private m_minHeaderRowHeight As Single
        Private m_percentWidth As Single
        Private m_repeatHeaderRow As Boolean
        Private m_rowHeights As ArrayList
        Private m_showSummaryRow As Boolean
        Private m_suppressHeaderRow As Boolean
        Private m_tableHeightForPage As Single

        Protected rowIndex As Integer

        Private Const HeaderRowNumber As Integer = -1

#End Region

#Region "Constructors"
        Public Property AllowMultiPageWidth() As Boolean
            Get
                Return Me.m_allowMultiPageWidth
            End Get
            Set(ByVal value As Boolean)
                Me.m_allowMultiPageWidth = value
            End Set
        End Property
        Public ReadOnly Property AlternatingRowTextStyle() As TextStyle
            Get
                Return Me.m_alternatingRowTextStyle
            End Get
        End Property
        Public ReadOnly Property ColumnCount() As Integer
            Get
                Return Me.m_columns.Count
            End Get
        End Property
        Public Property DataSource() As DataView
            Get
                Return Me.m_dataSource
            End Get
            Set(ByVal value As DataView)
                Me.m_dataSource = value
            End Set
        End Property
        Public ReadOnly Property DetailRowTextStyle() As TextStyle
            Get
                Return Me.m_detailRowTextStyle
            End Get
        End Property
        Private ReadOnly Property HeaderSize() As SizeF
            Get
                Return New SizeF(Me.GetPageInfo.Width, Me.m_headerRowHeight)
            End Get
        End Property
        Public ReadOnly Property HeaderTextStyle() As TextStyle
            Get
                Return Me.m_headerTextStyle
            End Get
        End Property
        Public Property InnerPenHeaderBottom() As Pen
            Get
                Return Me.m_innerPenHeaderBottom
            End Get
            Set(ByVal value As Pen)
                Me.m_innerPenHeaderBottom = value
            End Set
        End Property
        Public Property InnerPenRow() As Pen
            Get
                Return Me.m_innerPenRow
            End Get
            Set(ByVal value As Pen)
                Me.m_innerPenRow = value
            End Set
        End Property
        Public Property MaxDetailRowHeight() As Single
            Get
                Return Me.m_maxDetailRowHeight
            End Get
            Set(ByVal value As Single)
                Me.m_maxDetailRowHeight = value
            End Set
        End Property
        Public Property MaxHeaderRowHeight() As Single
            Get
                Return Me.m_maxHeaderRowHeight
            End Get
            Set(ByVal value As Single)
                Me.m_maxHeaderRowHeight = value
            End Set
        End Property
        Public Property MinDetailRowHeight() As Single
            Get
                Return Me.m_minDetailRowHeight
            End Get
            Set(ByVal value As Single)
                Me.m_minDetailRowHeight = value
            End Set
        End Property
        Public Property MinHeaderRowHeight() As Single
            Get
                Return Me.m_minHeaderRowHeight
            End Get
            Set(ByVal value As Single)
                Me.m_minHeaderRowHeight = value
            End Set
        End Property
        Public Property OuterPenBottom() As Pen
            Get
                Return Me.m_borderPens.Bottom
            End Get
            Set(ByVal value As Pen)
                Me.m_borderPens.Bottom = value
            End Set
        End Property
        Public Property OuterPenLeft() As Pen
            Get
                Return Me.m_borderPens.Left
            End Get
            Set(ByVal value As Pen)
                Me.m_borderPens.Left = value
            End Set
        End Property
        Public Property OuterPenRight() As Pen
            Get
                Return Me.m_borderPens.Right
            End Get
            Set(ByVal value As Pen)
                Me.m_borderPens.Right = value
            End Set
        End Property
        Public WriteOnly Property OuterPens() As Pen
            Set(ByVal value As Pen)
                Me.m_borderPens.Top = value
                Me.m_borderPens.Right = value
                Me.m_borderPens.Bottom = value
                Me.m_borderPens.Left = value
            End Set
        End Property
        Public Property OuterPenTop() As Pen
            Get
                Return Me.m_borderPens.Top
            End Get
            Set(ByVal value As Pen)
                Me.m_borderPens.Top = value
            End Set
        End Property
        Public Property PercentWidth() As Single
            Get
                Return Me.m_percentWidth
            End Get
            Set(ByVal value As Single)
                If ((value < 0.0!) OrElse (value > 100.0!)) Then
                    Throw New ArgumentException("PercentWidth must be between 0 and 100, inclusive")
                End If
                Me.m_percentWidth = value
            End Set
        End Property
        Public Property RepeatHeaderRow() As Boolean
            Get
                Return Me.m_repeatHeaderRow
            End Get
            Set(ByVal value As Boolean)
                Me.m_repeatHeaderRow = value
            End Set
        End Property
        Public Property ShowSummaryRow() As Boolean
            Get
                Return Me.m_showSummaryRow
            End Get
            Set(ByVal value As Boolean)
                Me.m_showSummaryRow = value
            End Set
        End Property
        Public Property SuppressHeaderRow() As Boolean
            Get
                Return Me.m_suppressHeaderRow
            End Get
            Set(ByVal value As Boolean)
                Me.m_suppressHeaderRow = value
            End Set
        End Property
        Public ReadOnly Property TotalRows() As Integer
            Get
                If (Me.DataSource Is Nothing) Then
                    Return 0
                End If
                If Me.ShowSummaryRow Then
                    Return (Me.DataSource.Count + 1)
                End If
                Return Me.DataSource.Count
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub New(ByVal dataSource As DataView)
            Me.m_tableHeightForPage = 0.0!
            Me.m_headerRowHeight = 0.0!
            Me.m_minHeaderRowHeight = 0.0!
            Me.m_minDetailRowHeight = 0.0!
            Me.m_maxHeaderRowHeight = 8.0!
            Me.m_maxDetailRowHeight = 8.0!
            Me.m_columns = New ArrayList
            Me.DataSource = dataSource
            Me.m_borderPens = New BorderPens
            Me.m_headerTextStyle = New TextStyle(TextStyle.TableHeader)
            Me.m_detailRowTextStyle = New TextStyle(TextStyle.TableRow)
            Me.m_alternatingRowTextStyle = New TextStyle(Me.m_detailRowTextStyle)
            Me.m_rowHeights = New ArrayList(dataSource.Count)
        End Sub
        Public Overridable Function AddColumn(ByVal rc As IDataColumn) As Integer
            rc.MaxHeaderRowHeight = Me.MaxHeaderRowHeight
            rc.MaxDetailRowHeight = Me.MaxDetailRowHeight
            rc.HeaderTextStyle = New TextStyle(Me.HeaderTextStyle)
            rc.DetailRowTextStyle = New TextStyle(Me.DetailRowTextStyle)
            rc.AlternatingRowTextStyle = New TextStyle(Me.AlternatingRowTextStyle)
            rc.SummaryRowTextStyle = New TextStyle(Me.DetailRowTextStyle)
            rc.SummaryRowTextStyle.Bold = True
            Return Me.m_columns.Add(rc)
        End Function
        Private Function CalcHeaderSize(ByVal g As Graphics, ByVal bounds As Bounds) As SizeF
            If Not Me.m_headerSizeInit Then
                Dim single1 As Single = bounds.Width
                If (Me.PercentWidth <> 0.0!) Then
                    single1 = (single1 * (Me.PercentWidth / 100.0!))
                End If
                Me.ResizeColumns(single1)
                Me.m_headerRowHeight = Me.SizePrintRow(g, -1, bounds.Position.X, bounds.Position.Y, bounds.Width, Me.MaxHeaderRowHeight, True, True)
                Me.m_headerSizeInit = True
            End If
            Return New SizeF(Me.GetPageInfo.Width, Me.m_headerRowHeight)
        End Function
        Public Overridable Sub ClearColumns()
            Me.m_columns.Clear()
        End Sub
        Protected Overrides Sub DoBeginPrint(ByVal g As Graphics)
            If (Me.SuppressHeaderRow OrElse Me.RepeatHeaderRow) Then
                Me.rowIndex = 0
            Else
                Me.rowIndex = -1
            End If
            Dim column1 As IDataColumn
            For Each column1 In Me.m_columns
                column1.SizeColumn(g, Me.DataSource)
            Next
            Me.m_currentHorizPage = 0
            Me.m_dataRowsFit = 0
        End Sub
        Protected Overrides Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            Dim bounds1 As bounds = Me.m_borderPens.GetInnerBounds(bounds)
            Me.CalcHeaderSize(g, bounds1)
            Dim bounds2 As bounds = Me.GetTableBounds(bounds1)
            Dim tf1 As PointF = bounds2.Position
            If Me.SizePrintHeader(g, bounds2, True) Then
                If (Me.m_currentHorizPage = 0) Then
                    Me.m_dataRowsFit = Me.FindDataRowsFit(g, bounds2)
                    Me.m_tableHeightForPage = (bounds2.Position.Y - tf1.Y)
                End If
                If (Me.TotalRows = 0) Then
                    values1.Fits = True
                Else
                    If (Me.m_dataRowsFit > 0) Then
                        values1.Fits = True
                        If (Me.m_currentHorizPage < (Me.m_infoForPages.Count - 1)) Then
                            values1.Continued = True
                        Else
                            If ((Me.rowIndex + Me.m_dataRowsFit) < Me.TotalRows) Then
                                values1.Continued = True
                            End If
                        End If
                    End If
                End If
            End If
            values1.RequiredSize = Me.m_borderPens.AddBorderSize(New SizeF(Me.GetPageInfo.Width, Me.m_tableHeightForPage))
            Return values1
        End Function
        Protected Overrides Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            Dim num1 As Integer = Me.rowIndex
            Dim bounds1 As bounds = Me.GetTableBounds(bounds, MyBase.RequiredSize)
            Dim bounds2 As bounds = Me.m_borderPens.GetInnerBounds(bounds1)
            Dim bounds3 As bounds = bounds2
            Me.SizePrintHeader(g, bounds3, False)
            Me.PrintRows(g, bounds3)
            Me.PrintAllRowLines(g, bounds2, (Not Me.SuppressHeaderRow AndAlso Me.RepeatHeaderRow))
            Me.PrintAllColumnLines(g, bounds2)
            Me.m_borderPens.DrawBorder(g, bounds1)
            If (Me.m_currentHorizPage < (Me.m_infoForPages.Count - 1)) Then
                Me.m_currentHorizPage += 1
                Me.rowIndex = num1
            Else
                Me.m_currentHorizPage = 0
            End If
        End Sub
        Private Function FindDataRowsFit(ByVal g As Graphics, ByRef bounds As Bounds) As Integer
            Dim num1 As Integer = 0
            Dim num2 As Integer = Me.rowIndex
            Me.m_rowHeights = New ArrayList
            Do While (num2 < Me.TotalRows)
                Dim flag1 As Boolean = (num2 < (Me.TotalRows - 1))
                Dim single1 As Single = Me.SizePrintRow(g, num2, bounds.Position.X, bounds.Position.Y, bounds.Width, Me.MaxDetailRowHeight, True, flag1)
                If bounds.SizeFits(New SizeF(Me.GetPageInfo.Width, single1)) Then
                    Debug.Assert((Me.m_rowHeights.Count = num1), "rowHeights.Count is not equal to index")
                    Me.m_rowHeights.Add(single1)
                    bounds.Position.Y = (bounds.Position.Y + single1)
                    num2 += 1
                    num1 += 1
                Else
                    If (Me.m_rowHeights.Count > 0) Then
                        single1 = Me.SizePrintRow(g, (num2 - 1), bounds.Position.X, bounds.Position.Y, bounds.Width, Me.MaxDetailRowHeight, True, False)
                        bounds.Position.Y = (bounds.Position.Y - CType(Me.m_rowHeights.Item((Me.m_rowHeights.Count - 1)), Single))
                        bounds.Position.Y = (bounds.Position.Y + single1)
                        Me.m_rowHeights.Item((Me.m_rowHeights.Count - 1)) = single1
                    End If
                    Exit Do
                End If
            Loop
            Return num1
        End Function
        Public Overridable Function GetColumn(ByVal index As Integer) As IDataColumn
            Return CType(Me.m_columns.Item(index), IDataColumn)
        End Function
        Private Function GetPageInfo() As PageInfo
            Return CType(Me.m_infoForPages.Item(Me.m_currentHorizPage), PageInfo)
        End Function
        Private Function GetTableBounds(ByVal bounds As Bounds) As Bounds
            Dim ef1 As SizeF = Me.m_borderPens.AddBorderSize(Me.HeaderSize)
            Dim ef2 As RectangleF = bounds.GetRectangleF(ef1, Me.HorizontalAlignment, Me.VerticalAlignment)
            Return New bounds(ef2.Left, bounds.Position.Y, ef2.Right, bounds.Limit.Y)
        End Function
        Private Function GetTableBounds(ByVal bounds As Bounds, ByVal size As SizeF) As Bounds
            Dim ef1 As RectangleF = bounds.GetRectangleF(size, Me.HorizontalAlignment, Me.VerticalAlignment)
            Return New bounds(ef1.Left, ef1.Top, ef1.Right, ef1.Bottom)
        End Function
        Protected Overridable Function GetValidHeight(ByVal height As Single, ByVal isHeader As Boolean) As Single
            Dim single1 As Single
            Dim single2 As Single
            If isHeader Then
                single1 = Me.MinHeaderRowHeight
                single2 = Me.MaxHeaderRowHeight
            Else
                single1 = Me.MinDetailRowHeight
                single2 = Me.MaxDetailRowHeight
            End If
            If (height < single1) Then
                Return single1
            End If
            If (height > single2) Then
                Return single2
            End If
            Return height
        End Function
        Private Sub PrintAllColumnLines(ByVal g As Graphics, ByVal bounds As Bounds)
            Dim info1 As PageInfo = Me.GetPageInfo
            Dim single1 As Single = bounds.Position.X
            Dim single2 As Single = bounds.Position.Y
            Dim num1 As Integer = info1.FirstColumn
            Do While (num1 <= (info1.LastColumn - 1))
                Dim column1 As IDataColumn = Me.GetColumn(num1)
                single1 = (single1 + column1.Width)
                column1.DrawRightLine(g, single1, single2, bounds.Height)
                num1 += 1
            Loop
        End Sub
        Private Sub PrintAllRowLines(ByVal g As Graphics, ByVal bounds As Bounds, ByVal includeHeader As Boolean)
            Dim single1 As Single = bounds.Position.X
            Dim single2 As Single = bounds.Position.Y
            Dim single3 As Single = bounds.Width
            If includeHeader Then
                Me.RowLine(g, single1, (single2 + Me.m_headerRowHeight), single3, True, False)
                single2 = (single2 + Me.m_headerRowHeight)
            End If
            Dim num1 As Integer
            For num1 = 0 To (Me.m_dataRowsFit - 1) - 1
                Dim single4 As Single = CType(Me.m_rowHeights.Item(num1), Single)
                Dim flag1 As Boolean = (num1 <> (Me.m_dataRowsFit - 1))
                Me.RowLine(g, single1, (single2 + single4), single3, False, False)
                single2 = (single2 + single4)
            Next num1
        End Sub
        Private Sub PrintRows(ByVal g As Graphics, ByRef bounds As Bounds)
            Dim num1 As Integer = 0
            Do While (num1 < Me.m_dataRowsFit)
                Dim single1 As Single = CType(Me.m_rowHeights.Item(num1), Single)
                Dim flag1 As Boolean = False
                Me.SizePrintRow(g, Me.rowIndex, bounds.Position.X, bounds.Position.Y, bounds.Width, single1, False, flag1)
                bounds.Position.Y = (bounds.Position.Y + single1)
                Debug.Assert(((bounds.Position.Y - bounds.Limit.Y) < 0.005!), ("Row doesn't really fit, but we thought it did. Delta: " & (bounds.Position.Y - bounds.Limit.Y)))
                num1 += 1
                Me.rowIndex += 1
            Loop
        End Sub
        Public Overridable Sub RemoveColumn(ByVal index As Integer)
            Me.m_columns.RemoveAt(index)
        End Sub
        Protected Overridable Sub ResizeColumns(ByVal width As Single)
            If (Me.PercentWidth = 0.0!) Then
                Me.SetupPageInfo(width, Me.m_allowMultiPageWidth, True)
            Else
                Me.SetupPageInfo(width, Me.m_allowMultiPageWidth, False)
                Dim info1 As PageInfo
                For Each info1 In Me.m_infoForPages
                    Dim single1 As Single = (width - info1.Width)
                    Dim num1 As Integer = info1.FirstColumn
                    Do While (num1 <= info1.LastColumn)
                        Dim column1 As IDataColumn = Me.GetColumn(num1)
                        column1.Width = (column1.Width + (single1 * (column1.Width / info1.Width)))
                        num1 += 1
                    Loop
                    info1.Width = width
                Next
            End If
        End Sub
        Protected Overridable Function RowLine(ByVal g As Graphics, ByVal x As Single, ByVal y As Single, ByVal length As Single, ByVal isHeader As Boolean, ByVal sizeOnly As Boolean) As Single
            Dim pen1 As Pen
            Dim single1 As Single = 0.0!
            If isHeader Then
                pen1 = Me.m_innerPenHeaderBottom
            Else
                pen1 = Me.m_innerPenRow
            End If
            If (pen1 Is Nothing) Then
                Return single1
            End If
            If Not sizeOnly Then
                y = (y - (pen1.Width / 2.0!))
                g.DrawLine(pen1, x, y, CType((x + length), Single), y)
            End If
            Return pen1.Width
        End Function
        Private Sub SetupPageInfo(ByVal width As Single, ByVal allowMultiPageWidth As Boolean, ByVal limitFirstPage As Boolean)
            Me.m_infoForPages = New ArrayList
            Dim info1 As New PageInfo
            Dim num1 As Integer = 0
            Dim column1 As IDataColumn = Me.GetColumn(num1)
            For num1 = 0 To Me.ColumnCount - 1
                info1.NumberOfColumns += 1
                info1.Width = (info1.Width + column1.Width)
                Dim num2 As Integer = (num1 + 1)
                If (num2 < Me.ColumnCount) Then
                    column1 = Me.GetColumn(num2)
                    If ((info1.Width + column1.Width) > width) Then
                        If allowMultiPageWidth Then
                            Me.m_infoForPages.Add(info1)
                            info1 = New PageInfo
                            info1.FirstColumn = num2
                        Else
                            If limitFirstPage Then
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next num1
            Me.m_infoForPages.Add(info1)
        End Sub
        Private Function SizePrintHeader(ByVal g As Graphics, ByRef bounds As Bounds, ByVal sizeOnly As Boolean) As Boolean
            Dim flag1 As Boolean = True
            If (Me.SuppressHeaderRow OrElse Not Me.RepeatHeaderRow) Then
                Return flag1
            End If
            If bounds.SizeFits(Me.HeaderSize) Then
                If Not sizeOnly Then
                    Me.SizePrintRow(g, -1, bounds.Position.X, bounds.Position.Y, Me.GetPageInfo.Width, Me.m_headerRowHeight, False, False)
                End If
                bounds.Position.Y = (bounds.Position.Y + Me.m_headerRowHeight)
                Return flag1
            End If
            Return False
        End Function
        Private Function SizePrintRow(ByVal g As Graphics, ByVal rowIndex As Integer, ByVal x As Single, ByVal y As Single, ByVal maxWidth As Single, ByVal maxHeight As Single, ByVal sizeOnly As Boolean, ByVal showLine As Boolean) As Single
            Dim info1 As PageInfo = Me.GetPageInfo
            Dim flag1 As Boolean = (rowIndex = -1)
            Dim flag2 As Boolean = (rowIndex >= Me.DataSource.Count)
            Dim flag3 As Boolean = ((rowIndex Mod 2) <> 0)
            Dim single1 As Single = 0.0!
            Dim single2 As Single = x
            Dim view1 As DataRowView = Nothing
            If (Not flag1 AndAlso Not flag2) Then
                view1 = Me.DataSource.Item(rowIndex)
            End If
            Dim num1 As Integer = info1.FirstColumn
            Dim num2 As Integer = info1.LastColumn
            If sizeOnly Then
                num1 = 0
                num2 = (Me.ColumnCount - 1)
            End If
            Dim num3 As Integer = num1
            Do While (num3 <= num2)
                Dim column1 As IDataColumn = Me.GetColumn(num3)
                Dim ef1 As SizeF = column1.SizePaintCell(g, flag1, flag3, flag2, view1, single2, y, column1.Width, maxHeight, sizeOnly)
                single1 = Math.Max(single1, Me.GetValidHeight(ef1.Height, flag1))
                single2 = (single2 + column1.Width)
                num3 += 1
            Loop
            If showLine Then
                single1 = (single1 + Me.RowLine(g, x, (y + single1), info1.Width, flag1, sizeOnly))
            End If
            Return single1
        End Function
#End Region

#Region "Properties"

#End Region

#Region "Methods"

#End Region

#Region "PageInfo"
        Private Class PageInfo

#Region "Members"
            Public FirstColumn As Integer
            Public NumberOfColumns As Integer
            Public Width As Single
#End Region

#Region "Constructors"
            Public Sub New()
                Me.FirstColumn = 0
                Me.NumberOfColumns = 0
                Me.Width = 0.0!
            End Sub
#End Region

#Region "Properties"
            Public ReadOnly Property LastColumn() As Integer
                Get
                    Return ((Me.FirstColumn + Me.NumberOfColumns) - 1)
                End Get
            End Property
#End Region

        End Class
#End Region
    End Class
End Namespace