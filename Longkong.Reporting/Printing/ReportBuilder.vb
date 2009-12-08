Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Namespace Longkong.Reporting.Printing
    Public Class ReportBuilder

#Region "Members"
        Private m_columnLayoutMode As Boolean
        Private m_containers As Stack
        Private m_currentColumn As ReportDataColumn
        Private m_currentDocument As ReportDocument
        Private m_currentSection As ReportSection
        Private m_defaultColumnAlignment As HorizontalAlignment
        Private m_defaultTablePen As Pen
        Private m_documentMode As Boolean
        Private m_headerFooterMargins As Single
        Private m_horizLineMargins As Single
        Private m_maxDetailRowHeight As Single
        Private m_maxHeaderRowHeight As Single
        Private m_minDetailRowHeight As Single
        Private m_minHeaderRowHeight As Single

        Public UseImageColumnForBool As Boolean
        Public DataGridToPrinterHScale As Single
        Private Const DefaultDateTimeFormatString As String = "d"
        Private ReadOnly m_formatStrings As Hashtable

#End Region

#Region "Contructors"
        Public Sub New(ByVal reportDocument As ReportDocument)
            Me.UseImageColumnForBool = True
            Me.DataGridToPrinterHScale = 75.0!
            Me.m_currentDocument = reportDocument
            Me.m_containers = New Stack
            Me.m_formatStrings = New Hashtable
            Me.AddFormatExpression(GetType(DateTime), "d")
            Dim single1 As Single = reportDocument.GetScale
            Me.m_maxDetailRowHeight = (8.0! * single1)
            Me.m_maxHeaderRowHeight = (8.0! * single1)
            Me.m_horizLineMargins = (0.1! * single1)
            Me.m_headerFooterMargins = (Me.m_horizLineMargins * 2.0!)
            Me.m_defaultTablePen = reportDocument.ThinPen
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Box() As SectionBox
            Get
                Return CType(Me.CurrentContainer, SectionBox)
            End Get
        End Property
        Public ReadOnly Property CurrentColumn() As ReportDataColumn
            Get
                Return Me.m_currentColumn
            End Get
        End Property
        Public ReadOnly Property CurrentContainer() As SectionContainer
            Get
                If (Me.m_containers.Count = 0) Then
                    Return Nothing
                End If
                Return CType(Me.m_containers.Peek, SectionContainer)
            End Get
        End Property
        Public ReadOnly Property CurrentDocument() As ReportDocument
            Get
                Return Me.m_currentDocument
            End Get
        End Property
        Public ReadOnly Property CurrentSection() As ReportSection
            Get
                Return Me.m_currentSection
            End Get
        End Property
        Public Property DefaultColumnAlignment() As HorizontalAlignment
            Get
                Return Me.m_defaultColumnAlignment
            End Get
            Set(ByVal value As HorizontalAlignment)
                Me.m_defaultColumnAlignment = value
            End Set
        End Property
        Public Property DefaultTablePen() As Pen
            Get
                Return Me.m_defaultTablePen
            End Get
            Set(ByVal value As Pen)
                Me.m_defaultTablePen = value
            End Set
        End Property
        Public Property HorizLineMargins() As Single
            Get
                Return Me.m_horizLineMargins
            End Get
            Set(ByVal value As Single)
                Me.m_horizLineMargins = value
            End Set
        End Property
        Public ReadOnly Property Line() As SectionLine
            Get
                Return CType(Me.CurrentSection, SectionLine)
            End Get
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
        Public Property MaxPageFooterHeight() As Single
            Get
                Return Me.CurrentDocument.PageFooterMaxHeight
            End Get
            Set(ByVal value As Single)
                Me.CurrentDocument.PageFooterMaxHeight = value
            End Set
        End Property
        Public Property MaxPageHeaderHeight() As Single
            Get
                Return Me.CurrentDocument.PageHeaderMaxHeight
            End Get
            Set(ByVal value As Single)
                Me.CurrentDocument.PageHeaderMaxHeight = value
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
        Public ReadOnly Property PageFooter() As LayeredSections
            Get
                Dim sections1 As LayeredSections = CType(Me.CurrentDocument.PageFooter, LayeredSections)
                If (sections1 Is Nothing) Then
                    sections1 = New LayeredSections(True, False)
                    sections1.MarginTop = Me.m_headerFooterMargins
                    sections1.VerticalAlignment = VerticalAlignment.Bottom
                    Me.CurrentDocument.PageFooter = sections1
                End If
                Return sections1
            End Get
        End Property
        Public ReadOnly Property PageHeader() As LayeredSections
            Get
                Dim sections1 As LayeredSections = CType(Me.CurrentDocument.PageHeader, LayeredSections)
                If (sections1 Is Nothing) Then
                    sections1 = New LayeredSections(True, False)
                    sections1.MarginBottom = Me.m_headerFooterMargins
                    Me.CurrentDocument.PageHeader = sections1
                End If
                Return sections1
            End Get
        End Property
        Public ReadOnly Property Table() As SectionTable
            Get
                Return CType(Me.CurrentSection, SectionTable)
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub AddAllColumns(ByVal maxWidth As Single, ByVal sizeWidthToHeader As Boolean, ByVal sizeWidthToContents As Boolean)
            If (Me.Table Is Nothing) Then
                Throw New ReportBuilderException("Table must first be added with AddTable")
            End If
            Dim column1 As DataColumn
            For Each column1 In Me.Table.DataSource.Table.Columns
                Me.AddColumn(column1, column1.ColumnName, maxWidth, sizeWidthToHeader, sizeWidthToContents)
            Next
        End Sub
        Public Function AddColumn(ByVal col As DataColumn, ByVal headerText As String, ByVal width As Single) As ReportDataColumn
            Return Me.AddColumn(col, headerText, width, False, False)
        End Function
        Public Function AddColumn(ByVal columnName As String, ByVal headerText As String, ByVal width As Single) As ReportDataColumn
            Return Me.AddColumn(columnName, headerText, width, False, False)
        End Function
        Public Function AddColumn(ByVal col As DataColumn, ByVal headerText As String, ByVal maxWidth As Single, ByVal sizeWidthToHeader As Boolean, ByVal sizeWidthToContents As Boolean) As ReportDataColumn
            Return Me.AddColumn(col, headerText, maxWidth, sizeWidthToHeader, sizeWidthToContents, Me.DefaultColumnAlignment)
        End Function
        Public Function AddColumn(ByVal columnName As String, ByVal headerText As String, ByVal width As Single, ByVal sizeWidthToHeader As Boolean, ByVal sizeWidthToContents As Boolean) As ReportDataColumn
            Return Me.AddColumn(columnName, headerText, width, sizeWidthToHeader, sizeWidthToContents, Me.DefaultColumnAlignment)
        End Function
        Public Function AddColumn(ByVal col As DataColumn, ByVal headerText As String, ByVal maxWidth As Single, ByVal sizeWidthToHeader As Boolean, ByVal sizeWidthToContents As Boolean, ByVal horizontalAlignment As HorizontalAlignment) As ReportDataColumn
            If (Me.Table Is Nothing) Then
                Throw New ReportBuilderException("Table must first be added with AddTable")
            End If
            Me.m_currentColumn = Nothing
            If (Me.UseImageColumnForBool AndAlso (col.DataType Is GetType(Boolean))) Then
                Me.m_currentColumn = New ReportBoolColumn(col.ColumnName, maxWidth)
            Else
                Me.m_currentColumn = New ReportDataColumn(col.ColumnName, maxWidth)
            End If
            Me.Table.AddColumn(Me.m_currentColumn)
            Me.m_currentColumn.HeaderRowText = headerText
            Me.m_currentColumn.SizeWidthToHeader = sizeWidthToHeader
            Me.m_currentColumn.SizeWidthToContents = sizeWidthToContents
            If Me.m_formatStrings.ContainsKey(col.DataType) Then
                Me.m_currentColumn.FormatExpression = CType(Me.m_formatStrings.Item(col.DataType), String)
            End If
            Me.m_currentColumn.RightPen = Me.DefaultTablePen
            Me.m_currentColumn.HeaderTextStyle.StringAlignment = SectionText.ConvertAlign(horizontalAlignment)
            Me.m_currentColumn.DetailRowTextStyle.StringAlignment = SectionText.ConvertAlign(horizontalAlignment)
            Me.m_currentColumn.AlternatingRowTextStyle.StringAlignment = SectionText.ConvertAlign(horizontalAlignment)
            Me.m_currentColumn.SummaryRowTextStyle.StringAlignment = SectionText.ConvertAlign(horizontalAlignment)
            Return Me.m_currentColumn
        End Function
        Public Function AddColumn(ByVal columnName As String, ByVal headerText As String, ByVal maxWidth As Single, ByVal sizeWidthToHeader As Boolean, ByVal sizeWidthToContents As Boolean, ByVal horizontalAlignment As HorizontalAlignment) As ReportDataColumn
            If (Me.Table Is Nothing) Then
                Throw New ReportBuilderException("Table must first be added with AddTable")
            End If
            Dim column1 As DataColumn = Me.Table.DataSource.Table.Columns.Item(columnName)
            If (column1 Is Nothing) Then
                Dim textArray1 As String() = New String() {"There is no column named '", columnName, "' in table '", Me.Table.DataSource.Table.TableName, "'"}
                Throw New ReportBuilderException(String.Concat(textArray1))
            End If
            Return Me.AddColumn(column1, headerText, maxWidth, sizeWidthToHeader, sizeWidthToContents, horizontalAlignment)
        End Function
        Public Function AddColumnBreak() As SectionBreak
            Return CType(Me.AddSection(New SectionBreak(False)), SectionBreak)
        End Function
        Public Function AddDataGrid(ByVal dataGrid As DataGrid, ByVal textSize As Single, ByVal includeFormatting As Boolean) As SectionTable
            If (dataGrid Is Nothing) Then
                Throw New ArgumentNullException("dataGrid")
            End If
            Dim manager1 As CurrencyManager = CType(dataGrid.BindingContext.Item(dataGrid.DataSource, dataGrid.DataMember), CurrencyManager)
            Dim view1 As DataView = CType(manager1.List, DataView)
            Dim table1 As SectionTable = Me.AddTable(view1, True)
            Me.DgApplyDefaultStyles(table1, textSize)
            Dim style1 As DataGridTableStyle = Nothing
            Dim style2 As DataGridTableStyle
            For Each style2 In dataGrid.TableStyles
                If (style2.MappingName Is view1.Table.TableName) Then
                    style1 = style2
                End If
            Next
            Dim pen1 As Pen = Me.DefaultTablePen
            If includeFormatting Then
                table1.DetailRowTextStyle.SetFromFont(dataGrid.Font)
                If (style1 Is Nothing) Then
                    Me.DefaultTablePen = Me.DgGridPen(table1, dataGrid)
                    Me.DgApplyTableStyles(table1, dataGrid)
                Else
                    Me.DefaultTablePen = Me.DgGridPen(table1, style1)
                    Me.DgApplyTableStyles(table1, style1)
                End If
            End If
            If (style1 Is Nothing) Then
                Dim single1 As Single = (CType(dataGrid.PreferredColumnWidth, Single) / Me.DataGridToPrinterHScale)
                Me.AddAllColumns(single1, True, True)
            Else
                Me.DgAddColumns(table1, style1)
            End If
            Me.DefaultTablePen = pen1
            Return table1
        End Function
        Public Sub AddFormatExpression(ByVal type As Type, ByVal formatString As String)
            Me.m_formatStrings.Item(type) = formatString
        End Sub
        Public Function AddHorizontalLine() As SectionLine
            Return Me.AddHorizontalLine(Me.CurrentDocument.NormalPen)
        End Function
        Public Function AddHorizontalLine(ByVal pen As Pen) As SectionLine
            Dim line1 As New SectionLine(Direction.Horizontal, pen)
            line1.MarginTop = Me.HorizLineMargins
            line1.MarginBottom = Me.HorizLineMargins
            Me.AddSection(line1)
            Return line1
        End Function
        Public Function AddPageBreak() As SectionBreak
            Return CType(Me.AddSection(New SectionBreak), SectionBreak)
        End Function
        Public Function AddPageBreak(ByVal newOrientation As PageOrientation) As SectionBreak
            Dim break1 As New SectionBreak(True)
            break1.NewPageOrientation = newOrientation
            Me.AddSection(break1)
            Return break1
        End Function
        Public Sub AddPageFooter(ByVal [text] As String, ByVal hAlign As HorizontalAlignment)
            Me.PageFooter.AddSection(Me.GetRepeatable(text, text, text, TextStyle.PageFooter, hAlign))
        End Sub
        Public Sub AddPageFooter(ByVal leftText As String, ByVal centerText As String, ByVal rightText As String)
            Me.AddPageFooter(leftText, centerText, rightText, leftText, centerText, rightText, leftText, centerText, rightText)
        End Sub
        Public Sub AddPageFooter(ByVal textFirstPage As String, ByVal textEvenPages As String, ByVal textOddPages As String, ByVal hAlign As HorizontalAlignment)
            Me.PageFooter.AddSection(Me.GetRepeatable(textFirstPage, textEvenPages, textOddPages, TextStyle.PageFooter, hAlign))
        End Sub
        Public Sub AddPageFooter(ByVal leftTextFirstPage As String, ByVal centerTextFirstPage As String, ByVal rightTextFirstPage As String, ByVal leftText As String, ByVal centerText As String, ByVal rightText As String)
            Me.AddPageFooter(leftTextFirstPage, centerTextFirstPage, rightTextFirstPage, leftText, centerText, rightText, leftText, centerText, rightText)
        End Sub
        Public Sub AddPageFooter(ByVal leftTextFirstPage As String, ByVal centerTextFirstPage As String, ByVal rightTextFirstPage As String, ByVal leftTextEvenPages As String, ByVal centerTextEvenPages As String, ByVal rightTextEvenPages As String, ByVal leftTextOddPages As String, ByVal centerTextOddPages As String, ByVal rightTextOddPages As String)
            Me.AddPageFooter(leftTextFirstPage, leftTextEvenPages, leftTextOddPages, HorizontalAlignment.Left)
            Me.AddPageFooter(centerTextFirstPage, centerTextEvenPages, centerTextOddPages, HorizontalAlignment.Center)
            Me.AddPageFooter(rightTextFirstPage, rightTextEvenPages, rightTextOddPages, HorizontalAlignment.Right)
        End Sub
        Public Function AddPageFooterLine() As SectionLine
            Dim line1 As New SectionLine(Direction.Horizontal, Me.CurrentDocument.NormalPen)
            line1.VerticalAlignment = VerticalAlignment.Top
            line1.MarginTop = -Me.m_horizLineMargins
            Me.PageFooter.AddSection(line1)
            Me.PageFooter.MarginTop = (2.0! * Me.m_horizLineMargins)
            Return line1
        End Function
        Public Sub AddPageHeader(ByVal [text] As String, ByVal hAlign As HorizontalAlignment)
            Me.PageHeader.AddSection(Me.GetRepeatable(text, text, text, TextStyle.PageHeader, hAlign))
        End Sub
        Public Sub AddPageHeader(ByVal leftText As String, ByVal centerText As String, ByVal rightText As String)
            Me.AddPageHeader(leftText, centerText, rightText, leftText, centerText, rightText)
        End Sub
        Public Sub AddPageHeader(ByVal textFirstPage As String, ByVal textEvenPages As String, ByVal textOddPages As String, ByVal hAlign As HorizontalAlignment)
            Me.PageHeader.AddSection(Me.GetRepeatable(textFirstPage, textEvenPages, textOddPages, TextStyle.PageHeader, hAlign))
        End Sub
        Public Sub AddPageHeader(ByVal leftTextFirstPage As String, ByVal centerTextFirstPage As String, ByVal rightTextFirstPage As String, ByVal leftText As String, ByVal centerText As String, ByVal rightText As String)
            Me.AddPageHeader(leftTextFirstPage, centerTextFirstPage, rightTextFirstPage, leftText, centerText, rightText, leftText, centerText, rightText)
        End Sub
        Public Sub AddPageHeader(ByVal leftTextFirstPage As String, ByVal centerTextFirstPage As String, ByVal rightTextFirstPage As String, ByVal leftTextEvenPages As String, ByVal centerTextEvenPages As String, ByVal rightTextEvenPages As String, ByVal leftTextOddPages As String, ByVal centerTextOddPages As String, ByVal rightTextOddPages As String)
            Me.AddPageHeader(leftTextFirstPage, leftTextEvenPages, leftTextOddPages, HorizontalAlignment.Left)
            Me.AddPageHeader(centerTextFirstPage, centerTextEvenPages, centerTextOddPages, HorizontalAlignment.Center)
            Me.AddPageHeader(rightTextFirstPage, rightTextEvenPages, rightTextOddPages, HorizontalAlignment.Right)
        End Sub
        Public Function AddPageHeaderLine() As SectionLine
            Dim line1 As New SectionLine(Direction.Horizontal, Me.CurrentDocument.NormalPen)
            line1.VerticalAlignment = VerticalAlignment.Bottom
            line1.MarginBottom = -Me.m_horizLineMargins
            Me.PageHeader.MarginBottom = (2.0! * Me.m_horizLineMargins)
            Me.PageHeader.AddSection(line1)
            Return line1
        End Function
        Public Function AddSection(ByVal section As ReportSection) As ReportSection
            If (Me.CurrentContainer Is Nothing) Then
                Throw New ReportBuilderException(("No SectionContainer defined to add section: " & section.ToString))
            End If
            Me.CurrentContainer.AddSection(section)
            Me.m_currentSection = section
            If Me.m_documentMode Then
                section.VerticalAlignment = VerticalAlignment.Bottom
            End If
            Return section
        End Function
        Public Function AddTable(ByVal dataSource As DataView, ByVal repeatHeaderRow As Boolean) As SectionTable
            Return Me.AddTable(dataSource, repeatHeaderRow, 0.0!)
        End Function
        Public Function AddTable(ByVal dataSource As DataView, ByVal repeatHeaderRow As Boolean, ByVal tablePercentWidth As Single) As SectionTable
            Dim table1 As New SectionTable(dataSource)
            table1.RepeatHeaderRow = repeatHeaderRow
            table1.MaxDetailRowHeight = Me.MaxDetailRowHeight
            table1.MinDetailRowHeight = Me.MinDetailRowHeight
            table1.MaxHeaderRowHeight = Me.MaxHeaderRowHeight
            table1.MinHeaderRowHeight = Me.MinHeaderRowHeight
            table1.InnerPenHeaderBottom = Me.DefaultTablePen
            table1.InnerPenRow = Me.DefaultTablePen
            table1.OuterPens = Me.DefaultTablePen
            table1.PercentWidth = tablePercentWidth
            Me.AddSection(table1)
            Return table1
        End Function
        Public Function AddText(ByVal [text] As String) As SectionText
            Return Me.AddText(text, TextStyle.Normal)
        End Function
        Public Function AddText(ByVal [text] As String, ByVal textStyle As TextStyle) As SectionText
            Dim text1 As New SectionText(text, textStyle)
            If Me.m_documentMode Then
                text1.SingleLineMode = True
            End If
            Me.AddSection(text1)
            Return text1
        End Function
        Public Sub ClearFormatExpression(ByVal type As Type)
            If Me.m_formatStrings.ContainsKey(type) Then
                Me.m_formatStrings.Remove(type)
            End If
        End Sub
        Private Sub DgAddColumns(ByVal table As SectionTable, ByVal tableStyle As DataGridTableStyle)
            Dim style1 As DataGridColumnStyle
            For Each style1 In tableStyle.GridColumnStyles
                Dim single1 As Single = ((CType(style1.Width, Single) / Me.DataGridToPrinterHScale) * Me.CurrentDocument.GetScale)
                Dim column1 As ReportDataColumn = Me.AddColumn(style1.MappingName, style1.HeaderText, single1, True, True, CType(style1.Alignment, HorizontalAlignment))
                column1.NullValueString = style1.NullText
                Dim column2 As DataGridTextBoxColumn = CType(style1, DataGridTextBoxColumn)
                If (Not column2 Is Nothing) Then
                    column1.FormatExpression = column2.Format
                End If
            Next
        End Sub
        Private Sub DgApplyDefaultStyles(ByVal table As SectionTable, ByVal textSize As Single)
            table.HeaderTextStyle.Size = textSize
            table.DetailRowTextStyle.Size = textSize
            table.HeaderTextStyle.MarginFar = (0.05! * Me.CurrentDocument.GetScale)
            table.HeaderTextStyle.MarginNear = (0.05! * Me.CurrentDocument.GetScale)
            table.DetailRowTextStyle.MarginFar = (0.05! * Me.CurrentDocument.GetScale)
            table.DetailRowTextStyle.MarginNear = (0.05! * Me.CurrentDocument.GetScale)
        End Sub
        Private Sub DgApplyTableStyles(ByVal table As SectionTable, ByVal dataGrid As DataGrid)
            table.HeaderTextStyle.SetFromFont(dataGrid.HeaderFont)
            table.HeaderTextStyle.Brush = New SolidBrush(dataGrid.HeaderForeColor)
            table.HeaderTextStyle.BackgroundBrush = New SolidBrush(dataGrid.HeaderBackColor)
            table.DetailRowTextStyle.Brush = New SolidBrush(dataGrid.ForeColor)
            table.DetailRowTextStyle.BackgroundBrush = New SolidBrush(dataGrid.BackColor)
            table.AlternatingRowTextStyle.BackgroundBrush = New SolidBrush(dataGrid.AlternatingBackColor)
        End Sub
        Private Sub DgApplyTableStyles(ByVal table As SectionTable, ByVal tableStyle As DataGridTableStyle)
            table.HeaderTextStyle.SetFromFont(tableStyle.HeaderFont)
            table.HeaderTextStyle.Brush = New SolidBrush(tableStyle.HeaderForeColor)
            table.HeaderTextStyle.BackgroundBrush = New SolidBrush(tableStyle.HeaderBackColor)
            table.DetailRowTextStyle.Brush = New SolidBrush(tableStyle.ForeColor)
            table.DetailRowTextStyle.BackgroundBrush = New SolidBrush(tableStyle.BackColor)
            table.AlternatingRowTextStyle.BackgroundBrush = New SolidBrush(tableStyle.AlternatingBackColor)
        End Sub
        Private Function DgGridPen(ByVal table As SectionTable, ByVal dataGrid As DataGrid) As Pen
            Dim pen1 As Pen = Nothing
            If (dataGrid.GridLineStyle = DataGridLineStyle.Solid) Then
                pen1 = New Pen(dataGrid.GridLineColor, Me.CurrentDocument.ThinPen.Width)
                table.OuterPens = pen1
                table.InnerPenHeaderBottom = pen1
                table.InnerPenRow = pen1
            End If
            Return pen1
        End Function
        Private Function DgGridPen(ByVal table As SectionTable, ByVal tableStyle As DataGridTableStyle) As Pen
            Dim pen1 As Pen = Nothing
            If (tableStyle.GridLineStyle = DataGridLineStyle.Solid) Then
                pen1 = New Pen(tableStyle.GridLineColor, Me.CurrentDocument.ThinPen.Width)
                table.OuterPens = pen1
                table.InnerPenHeaderBottom = pen1
                table.InnerPenRow = pen1
            End If
            Return pen1
        End Function
        Public Function FinishBox() As SectionBox
            Return CType(Me.FinishContainer, SectionBox)
        End Function
        Public Sub FinishColumnLayout()
            Debug.Assert(Me.m_columnLayoutMode, "Not in column layout mode - finishing makes no sense.")
            Me.FinishContainer()
            Me.FinishContainer()
        End Sub
        Public Function FinishContainer() As SectionContainer
            Return CType(Me.m_containers.Pop, SectionContainer)
        End Function
        Public Sub FinishDocumentLayout()
            Debug.Assert(Me.m_documentMode, "Not in document layout.  This could present problems trying to FinishDocumentLayout()")
            Me.FinishContainer()
            Me.FinishContainer()
            Me.m_documentMode = False
        End Sub
        Public Function FinishLayeredLayout() As LayeredSections
            Return CType(Me.FinishContainer, LayeredSections)
        End Function
        Public Function FinishLinearLayout() As LinearSections
            Return CType(Me.FinishContainer, LinearSections)
        End Function
        Public Function GetRepeatable(ByVal firstPageText As String, ByVal evenPageText As String, ByVal oddPageText As String, ByVal textStyle As TextStyle, ByVal hAlign As HorizontalAlignment) As RepeatableTextSection
            Dim section1 As New RepeatableTextSection(oddPageText, textStyle)
            section1.TextFirstPage = firstPageText
            section1.TextEvenPage = evenPageText
            section1.TextOddPage = oddPageText
            section1.UseFullWidth = True
            section1.HorizontalAlignment = hAlign
            Return section1
        End Function
        Public Function StartBox() As SectionBox
            Dim box1 As New SectionBox
            Me.StartContainer(box1)
            Return box1
        End Function
        Public Function StartBox(ByVal margins As Single, ByVal borders As Pen, ByVal padding As Single, ByVal background As Brush) As SectionBox
            Return Me.StartBox(margins, borders, padding, background, 0.0!, 0.0!)
        End Function
        Public Function StartBox(ByVal margins As Single, ByVal borders As Pen, ByVal padding As Single, ByVal background As Brush, ByVal width As Single, ByVal height As Single) As SectionBox
            Dim box1 As SectionBox = Me.StartBox
            box1.Margin = margins
            box1.Border = borders
            box1.Padding = padding
            box1.Background = background
            box1.Width = width
            box1.Height = height
            Return box1
        End Function
        Public Sub StartColumnLayout(ByVal numberOfColumns As Integer, ByVal spaceBetween As Single)
            Me.StartColumnLayout(numberOfColumns, spaceBetween, CType(Nothing, Pen))
        End Sub
        Public Sub StartColumnLayout(ByVal numberOfColumns As Integer, ByVal spaceBetween As Single, ByVal lineDivider As Pen)
            Dim single1 As Single = Me.CurrentDocument.DefaultPageSettings.Bounds.Width
            single1 = (single1 - Me.CurrentDocument.DefaultPageSettings.Margins.Left)
            single1 = (single1 - Me.CurrentDocument.DefaultPageSettings.Margins.Right)
            single1 = (single1 * (Me.CurrentDocument.GetScale / 100.0!))
            single1 = (single1 - ((numberOfColumns - 1) * spaceBetween))
            Debug.Assert((single1 > 0.0!), "Too many columns, too wide of margins, or some other problem.  Columns will not print.")
            single1 = (single1 / CType(numberOfColumns, Single))
            Me.StartColumnLayout(single1, spaceBetween, lineDivider)
        End Sub
        Public Sub StartColumnLayout(ByVal columnWidth As Single, ByVal spaceBetween As Single, ByVal lineDivider As Pen)
            Me.m_columnLayoutMode = True
            Dim sections1 As New LinearRepeatableSections(Direction.Horizontal)
            Me.StartContainer(sections1)
            If (Not lineDivider Is Nothing) Then
                Dim line1 As New SectionLine(Direction.Vertical, lineDivider)
                line1.MarginLeft = ((spaceBetween - lineDivider.Width) / 2.0!)
                line1.MarginRight = ((spaceBetween - lineDivider.Width) / 2.0!)
                sections1.Divider = line1
            Else
                sections1.SkipAmount = spaceBetween
            End If
            Dim sections2 As LinearSections = Me.StartLinearLayout(Direction.Vertical)
            sections2.MaxWidth = columnWidth
            sections2.UseFullWidth = True
        End Sub
        Public Function StartContainer(ByVal container As SectionContainer) As SectionContainer
            If (Me.CurrentDocument.Body Is Nothing) Then
                Me.CurrentDocument.Body = container
            Else
                If (Not Me.CurrentContainer Is Nothing) Then
                    Me.CurrentContainer.AddSection(container)
                End If
            End If
            Me.m_containers.Push(container)
            Return container
        End Function
        Public Sub StartDocumentLayout()
            Debug.WriteLine("Avoid using the document layout - unsupported...")
            Debug.Assert(Not Me.m_documentMode, "Already in document layout.  May not nest these.")
            Dim sections1 As New LinearRepeatableSections(Direction.Vertical)
            Me.StartContainer(sections1)
            Me.StartLinearLayout(Direction.Horizontal)
            Me.m_documentMode = True
        End Sub
        Public Function StartLayeredLayout() As LayeredSections
            Return Me.StartLayeredLayout(True, True)
        End Function
        Public Function StartLayeredLayout(ByVal useFullWidth As Boolean, ByVal useFullHeight As Boolean) As LayeredSections
            Dim sections1 As New LayeredSections(useFullWidth, useFullHeight)
            Me.StartContainer(sections1)
            Return sections1
        End Function
        Public Function StartLinearLayout(ByVal direction As Direction) As LinearSections
            Dim sections1 As New LinearSections
            sections1.Direction = direction
            Select Case direction
                Case direction.Vertical
                    sections1.UseFullWidth = True
                Case direction.Horizontal
                    sections1.UseFullHeight = True
            End Select
            Me.StartContainer(sections1)
            Return sections1
        End Function
#End Region


    End Class
End Namespace