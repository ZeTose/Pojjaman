Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptFinancialStatement
        Inherits Report

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
            MyBase.New(filters, fixValueCollection)
        End Sub
#End Region

#Region "Methods"
        'Public Overrides Sub ListInGrid(ByVal tm As TreeManager)

        'End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptFinancialStatement"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptFinancialStatement.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptFinancialStatement"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptFinancialStatement"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptFinancialStatement.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
                If tpt.EndsWith("()") Then
                    tpt.TrimEnd("()".ToCharArray)
                End If
                Return tpt
            End Get
        End Property
#End Region
#Region "IPrintableEntity"
        Public Overrides Function GetDefaultFormPath() As String
            Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
        End Function
        Public Overrides Function GetDefaultForm() As String

        End Function
        Private Function LoopChild(ByVal row As TreeRow) As Decimal
            Dim sum As Decimal
            For Each child As TreeRow In Findchild(row)
                Dim myValue As Decimal
                If Not child.IsNull("value") Then
                    Try
                        myValue = CDec(TextParser.Evaluate(child("value").ToString))
                    Catch ex As Exception
                        myValue = 0
                    End Try
                Else
                    myValue = 0
                End If
                sum += myValue + LoopChild(child)
            Next
            row.Tag = sum
            Return sum
        End Function
        Private Function Findchild(ByVal row As TreeRow) As ArrayList
            Dim arr As New ArrayList
            Dim level As Integer
            If row.IsNull("level") Then
                level = 0
            Else
                level = CInt(row("level"))
            End If
            Dim start As Boolean = False
            For Each myRow As TreeRow In Me.Treemanager.Treetable.Rows
                Dim myLevel As Integer
                If myRow.IsNull("level") Then
                    myLevel = 0
                Else
                    myLevel = CInt(myRow("level"))
                End If
                If myRow Is row Then
                    start = True
                End If
                If start And myLevel = level And Not myRow Is row Then
                    Exit For
                End If
                If start AndAlso Not myRow Is row And myLevel = level + 1 Then
                    arr.Add(myRow)
                End If
            Next
            Return arr
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                Select Case fixDpi.Mapping.ToLower
                    Case "month", "year", "today"
                        dpiColl.Add(fixDpi)
                    Case "docdatestart", "docdateend"
                        dpiColl.Add(fixDpi)
                End Select
            Next

            Dim i As Integer = 0
            If Me.Filters.Length > 0 Then
                Dim fi As Filter = Me.Filters(Me.Filters.Length - 1)
                If fi.Name.ToLower = "ffi_ff" Then
                    Dim ff As New FFormat(CInt(fi.Value))
                    For Each item As FFormatItem In ff.ItemCollection

                    Next
                End If
            End If
            i = 0
            For Each itemRow As TreeRow In Me.Treemanager.Treetable.Rows
                dpi = New DocPrintingItem
                dpi.Mapping = "name"
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                If itemRow.Table.Columns.Contains("name") AndAlso _
                Not itemRow.IsNull("name") Then
                    dpi.Value = CStr(itemRow("name"))
                End If


                dpiColl.Add(dpi)

                'formular
                dpi = New DocPrintingItem
                dpi.Mapping = "formular"
                If itemRow.Table.Columns.Contains("formular") AndAlso _
                Not itemRow.IsNull("formular") Then
                    dpi.Value = CStr(itemRow("formular"))
                End If
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'value
                dpi = New DocPrintingItem
                dpi.Mapping = "value"
                dpi.DataType = "System.Decimal"
                If Not itemRow.IsNull("value") Then
                    dpi.Value = CalcFormular(CStr(itemRow("value")))
                Else
                    dpi.Value = itemRow("value")
                End If
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'b4value
                dpi = New DocPrintingItem
                dpi.Mapping = "b4value"
                dpi.DataType = "System.Decimal"
                If Not itemRow.IsNull("b4value") Then
                    dpi.Value = CalcFormular(CStr(itemRow("b4value")))
                Else
                    dpi.Value = itemRow("b4value")
                End If
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                i += 1
            Next
            Return dpiColl
        End Function
        Public Function CalcFormular(ByVal strFormular As String) As String
            Dim val As String
            Try
                val = Configuration.FormatToString(CDec(TextParser.Evaluate(strFormular)), DigitConfig.Price)
            Catch ex As Exception
                val = strFormular
            End Try
            Return val
        End Function
#End Region

    End Class
End Namespace

