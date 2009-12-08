Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Interface IReportMaker
        ' Methods
        Sub MakeDocument(ByVal reportDocument As ReportDocument)
    End Interface
End Namespace