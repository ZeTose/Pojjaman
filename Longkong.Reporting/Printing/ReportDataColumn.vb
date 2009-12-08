Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class ReportDataColumn
        Implements IDataColumn

#Region "Events"
        Public Event FormatColumn As FormatColumnHandler
        Public Event FormatSummaryRow As FormatSummaryRowHandler
        Public Event UpdateMath As UpdateMathHandler
#End Region

#Region "Members"
        Private m_alternatingRowTextStyle As TextStyle
        Private m_countOfValues As Double
        Private m_detailRowTextStyle As TextStyle
        Private m_displayAvg As Boolean
        Private m_displayCount As Boolean
        Private m_displaySum As Boolean
        Private m_field As String
        Private m_formatExpression As String
        Private m_headerRowText As String
        Private m_headerTextStyle As TextStyle
        Private m_maxDetailRowHeight As Single
        Private m_maxHeaderRowHeight As Single
        Private m_maxWidth As Single
        Private m_nullValueString As String
        Private m_prefix As String
        Private m_rightPen As Pen
        Private m_rowValues As Hashtable
        Private m_sizeWidthToContents As Boolean
        Private m_sizeWidthToHeader As Boolean
        Private m_suffix As String
        Private m_summaryRowText As String
        Private m_summaryRowTextStyle As TextStyle
        Private m_sumOfValues As Double
        Private m_width As Single
#End Region

#Region "Constgructors"
        Public Sub New(ByVal field As String, ByVal maxWidth As Single)
            Me.m_nullValueString = "<NULL>"
            Me.m_prefix = "{0:"
            Me.m_suffix = "}"
            Me.Field = field
            Me.MaxWidth = maxWidth
            Me.HeaderRowText = field
            Me.m_sumOfValues = 0
            Me.m_countOfValues = 0
            Me.m_rowValues = New Hashtable
        End Sub
#End Region

#Region "Properties"
        Public Property Field() As String
            Get
                Return Me.m_field
            End Get
            Set(ByVal value As String)
                Me.m_field = value
            End Set
        End Property
        Public Property FormatExpression() As String
            Get
                Return Me.m_formatExpression
            End Get
            Set(ByVal value As String)
                If value.StartsWith(Me.m_prefix) Then
                    Debug.WriteLine("Deprecated use of FormatExpression.  In the future, omit the {0:}")
                    Me.m_formatExpression = value
                Else
                    Me.m_formatExpression = (Me.m_prefix & value & Me.m_suffix)
                End If
            End Set
        End Property
        Public Property HeaderRowText() As String
            Get
                Return Me.m_headerRowText
            End Get
            Set(ByVal value As String)
                Me.m_headerRowText = value
            End Set
        End Property
        Public Property NullValueString() As String
            Get
                Return Me.m_nullValueString
            End Get
            Set(ByVal value As String)
                Me.m_nullValueString = value
            End Set
        End Property
        Protected ReadOnly Property RightPenWidth() As Single
            Get
                Dim single1 As Single = 0.0!
                If (Not Me.RightPen Is Nothing) Then
                    single1 = Me.RightPen.Width
                End If
                Return single1
            End Get
        End Property
        Public Property SummaryRowText() As String
            Get
                Return Me.m_summaryRowText
            End Get
            Set(ByVal value As String)
                Dim text1 As String
                Me.m_summaryRowText = String.Empty
                Me.m_displayAvg = False
                Me.m_displayCount = False
                Me.m_displaySum = False
                text1 = value
                If (Not text1 Is Nothing) Then
                    text1 = String.IsInterned(text1)
                    If (Not text1 = "=[avg]") Then
                        If (text1 = "=[sum]") Then
                            Me.m_displaySum = True
                            Return
                        End If
                        If (text1 = "=[count]") Then
                            Me.m_displayCount = True
                            Return
                        End If
                    Else
                        Me.m_displayAvg = True
                        Return
                    End If
                End If
                Me.SummaryRowText = value
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overridable Function ApplyFormat(ByVal obj As Object) As String
            If ((Me.FormatExpression Is Nothing) OrElse (Me.FormatExpression Is String.Empty)) Then
                Return obj.ToString
            End If
            Return String.Format(Me.FormatExpression, obj)
        End Function
        Protected Overridable Function GetDetailRowString(ByVal drv As DataRowView) As String
            Dim obj1 As Object = drv.Item(Me.Field)
            Dim args1 As New FormatColumnEventArgs
            args1.OriginalValue = obj1
            If (Not obj1 Is Nothing) Then
                args1.StringValue = Me.ApplyFormat(obj1)
            Else
                args1.StringValue = Me.NullValueString
            End If
            RaiseEvent FormatColumn(Me, args1)
            Me.UpdateMathForRow(drv, obj1, args1.StringValue)
            Return args1.StringValue
        End Function
        Protected Overridable Function GetString(ByVal headerRow As Boolean, ByVal summaryRow As Boolean, ByVal drv As DataRowView) As String
            Dim text1 As String
            If headerRow Then
                Return Me.m_headerRowText
            End If
            If summaryRow Then
                Return Me.GetSummaryRowString
            End If
            If Me.m_rowValues.ContainsKey(drv) Then
                text1 = CType(Me.m_rowValues.Item(drv), String)
            Else
                text1 = Me.GetDetailRowString(drv)
                Me.m_rowValues.Add(drv, text1)
            End If
            Return text1
        End Function
        Protected Overridable Function GetSummaryRowString() As String
            Dim text1 As String = Me.SummaryRowText
            If Me.m_displayCount Then
                text1 = Me.m_countOfValues.ToString
            Else
                If Me.m_displaySum Then
                    text1 = Me.ApplyFormat(Me.m_sumOfValues)
                Else
                    If Me.m_displayAvg Then
                        Dim num1 As Double = (Me.m_sumOfValues / Me.m_countOfValues)
                        text1 = Me.ApplyFormat(num1)
                    End If
                End If
            End If
            Dim args1 As New FormatSummaryRowEventArgs
            args1.Field = Me.Field
            args1.StringValue = text1
            RaiseEvent FormatSummaryRow(Me, args1)
            Return args1.StringValue
        End Function
        Protected Overridable Function GetTextStyle(ByVal headerRow As Boolean, ByVal alternatingRow As Boolean, ByVal summaryRow As Boolean) As TextStyle
            Dim style1 As TextStyle
            If headerRow Then
                Return Me.HeaderTextStyle
            End If
            If (alternatingRow AndAlso (Not Me.AlternatingRowTextStyle Is Nothing)) Then
                style1 = Me.AlternatingRowTextStyle
            Else
                style1 = Me.DetailRowTextStyle
            End If
            If (summaryRow AndAlso (Not Me.SummaryRowTextStyle Is Nothing)) Then
                style1 = Me.SummaryRowTextStyle
            End If
            Return style1
        End Function
        Protected Overridable Sub UpdateMathForRow(ByVal drv As DataRowView, ByVal obj As Object, ByVal stringRepresentation As String)
            'If (Me.UpdateMath Is Nothing) Then
            '    If (Me.m_displayAvg OrElse Me.m_displaySum) Then
            '        Try
            '            Me.m_sumOfValues = (Me.m_sumOfValues + Convert.ToDouble(stringRepresentation))
            '        Catch exception1 As Exception
            '            Console.WriteLine(exception1.Message)
            '        End Try
            '    End If
            '    Me.m_countOfValues = (Me.m_countOfValues + 1)
            'Else
                Dim args1 As New UpdateMathEventArgs(drv, obj, stringRepresentation)
                args1.Count = Me.m_countOfValues
                args1.Sum = Me.m_sumOfValues
                RaiseEvent UpdateMath(Me, args1)
                Me.m_sumOfValues = args1.Sum
                Me.m_countOfValues = args1.Count
            'End If
        End Sub
#End Region

#Region "IDataColumn"
        Public Overridable Sub DrawRightLine(ByVal g As Graphics, ByVal x As Single, ByVal y As Single, ByVal height As Single) Implements IDataColumn.DrawRightLine
            If (Not Me.RightPen Is Nothing) Then
                x = (x - Me.RightPenWidth)
                g.DrawLine(Me.RightPen, x, y, x, CType((y + height), Single))
            End If
        End Sub
        Public Property MaxDetailRowHeight() As Single Implements IDataColumn.MaxDetailRowHeight
            Get
                Return m_maxDetailRowHeight
            End Get
            Set(ByVal Value As Single)
                m_maxDetailRowHeight = Value
            End Set
        End Property
        Public Property MaxHeaderRowHeight() As Single Implements IDataColumn.MaxHeaderRowHeight
            Get
                Return m_maxHeaderRowHeight
            End Get
            Set(ByVal Value As Single)
                m_maxHeaderRowHeight = Value
            End Set
        End Property
        Public Property MaxWidth() As Single Implements IDataColumn.MaxWidth
            Get
                Return Me.m_maxWidth
            End Get
            Set(ByVal value As Single)
                Me.m_maxWidth = value
            End Set
        End Property
        Public Property RightPen() As System.Drawing.Pen Implements IDataColumn.RightPen
            Get
                Return Me.m_rightPen
            End Get
            Set(ByVal value As Pen)
                Me.m_rightPen = value
            End Set
        End Property
        Public Overridable Sub SizeColumn(ByVal g As Graphics, ByVal dataSource As DataView) Implements IDataColumn.SizeColumn
            Dim single1 As Single = Me.MaxHeaderRowHeight
            Dim single2 As Single = 0.0!
            If Me.SizeWidthToHeader Then
                Dim ef1 As SizeF = Me.SizePaintCell(g, True, False, False, Nothing, 0.0!, 0.0!, Me.MaxWidth, single1, True)
                single2 = ef1.Width
            End If
            single1 = Me.MaxDetailRowHeight
            Dim single3 As Single = 0.0!
            If Me.SizeWidthToContents Then
                Dim flag1 As Boolean = False
                Dim view1 As DataRowView
                For Each view1 In dataSource
                    Dim ef2 As SizeF = Me.SizePaintCell(g, False, flag1, False, view1, 0.0!, 0.0!, Me.MaxWidth, single1, True)
                    single3 = Math.Max(single3, ef2.Width)
                    flag1 = Not flag1
                Next
            End If
            Dim single4 As Single = Math.Max(single2, single3)
            If ((single4 > 0.0!) AndAlso (single4 < Me.MaxWidth)) Then
                Me.Width = single4
            Else
                Me.Width = Me.MaxWidth
            End If
        End Sub
        Public Overridable Function SizePaintCell(ByVal g As Graphics, ByVal headerRow As Boolean, ByVal alternatingRow As Boolean, ByVal summaryRow As Boolean, ByVal drv As DataRowView, ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single, ByVal sizeOnly As Boolean) As SizeF Implements IDataColumn.SizePaintCell
            Dim ef1 As SizeF
            Dim bounds1 As Bounds
            ef1 = New SizeF(width, height)
            Dim text1 As String = Me.GetString(headerRow, summaryRow, drv)
            Dim style1 As TextStyle = Me.GetTextStyle(headerRow, alternatingRow, summaryRow)
            Dim font1 As Font = style1.GetFont
            Dim format1 As StringFormat = style1.GetStringFormat
            Dim single1 As Single = ((style1.MarginNear + style1.MarginFar) + Me.RightPenWidth)
            Dim single2 As Single = (style1.MarginTop + style1.MarginBottom)
            bounds1 = New Bounds(x, y, (x + width), (y + height))
            Dim bounds2 As Bounds = bounds1.GetBounds(style1.MarginTop, (style1.MarginFar + Me.RightPenWidth), style1.MarginBottom, style1.MarginNear)
            Dim ef2 As SizeF = bounds2.GetSizeF
            If sizeOnly Then
                ef1 = g.MeasureString(text1, font1, ef2, format1)
                ef1.Width = (ef1.Width + single1)
                ef1.Height = (ef1.Height + single2)
                ef1.Height = Math.Min(ef1.Height, height)
                Return ef1
            End If
            If (Not style1.BackgroundBrush Is Nothing) Then
                g.FillRectangle(style1.BackgroundBrush, bounds1.GetRectangleF)
            End If
            Dim ef3 As RectangleF = bounds2.GetRectangleF(ef1, SectionText.ConvertAlign(style1.StringAlignment), style1.VerticalAlignment)
            g.DrawString(text1, font1, style1.Brush, ef3, format1)
            Return ef1
        End Function
        Public Property SizeWidthToContents() As Boolean Implements IDataColumn.SizeWidthToContents
            Get
                Return Me.m_sizeWidthToContents
            End Get
            Set(ByVal value As Boolean)
                Me.m_sizeWidthToContents = value
            End Set
        End Property
        Public Property SizeWidthToHeader() As Boolean Implements IDataColumn.SizeWidthToHeader
            Get
                Return Me.m_sizeWidthToHeader
            End Get
            Set(ByVal value As Boolean)
                Me.m_sizeWidthToHeader = value
            End Set

        End Property
        Public Property Width() As Single Implements IDataColumn.Width
            Get
                Return Me.m_width
            End Get
            Set(ByVal value As Single)
                Me.m_width = value
            End Set
        End Property
        Public Property AlternatingRowTextStyle() As TextStyle Implements IDataColumn.AlternatingRowTextStyle
            Get
                Return Me.m_alternatingRowTextStyle
            End Get
            Set(ByVal value As TextStyle)
                Me.m_alternatingRowTextStyle = value
            End Set
        End Property
        Public Property DetailRowTextStyle() As TextStyle Implements IDataColumn.DetailRowTextStyle
            Get
                Return Me.m_detailRowTextStyle
            End Get
            Set(ByVal value As TextStyle)
                Me.m_detailRowTextStyle = value
            End Set
        End Property
        Public Property HeaderTextStyle() As TextStyle Implements IDataColumn.HeaderTextStyle
            Get
                Return Me.m_headerTextStyle
            End Get
            Set(ByVal value As TextStyle)
                Me.m_headerTextStyle = value
            End Set
        End Property
        Public Property SummaryRowTextStyle() As TextStyle Implements IDataColumn.SummaryRowTextStyle
            Get
                Return Me.m_summaryRowTextStyle
            End Get
            Set(ByVal value As TextStyle)
                Me.m_summaryRowTextStyle = value
            End Set
        End Property
#End Region

    End Class
End Namespace