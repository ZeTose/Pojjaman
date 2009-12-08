Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Interface IDataColumn
        ' Methods
        Sub DrawRightLine(ByVal g As Graphics, ByVal x As Single, ByVal y As Single, ByVal height As Single)
        Sub SizeColumn(ByVal g As Graphics, ByVal dataSource As DataView)
        Function SizePaintCell(ByVal g As Graphics, ByVal headerRow As Boolean, ByVal alternatingRow As Boolean, ByVal summaryRow As Boolean, ByVal drv As DataRowView, ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single, ByVal sizeOnly As Boolean) As SizeF

        ' Properties
        Property AlternatingRowTextStyle() As TextStyle
        Property DetailRowTextStyle() As TextStyle
        Property HeaderTextStyle() As TextStyle
        Property MaxDetailRowHeight() As Single
        Property MaxHeaderRowHeight() As Single
        Property MaxWidth() As Single
        Property RightPen() As Pen
        Property SizeWidthToContents() As Boolean
        Property SizeWidthToHeader() As Boolean
        Property SummaryRowTextStyle() As TextStyle
        Property Width() As Single
    End Interface
End Namespace