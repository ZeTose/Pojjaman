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
    Public Class RptAPPaymentMethods
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
                Return "RptAPPaymentMethods"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPPaymentMethods.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptAPPaymentMethods"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptAPPaymentMethods"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPPaymentMethods.ListLabel}"
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
#End Region#Region "IPrintableEntity"
        Public Overrides Function GetDefaultFormPath() As String
            Return "RptAPPaymentMethods"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptAPPaymentMethods"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'Month
            dpi = New DocPrintingItem
            dpi.Mapping = "Month"
            dpi.Value = "" 'Me.cmbMonth.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Year
            dpi = New DocPrintingItem
            dpi.Mapping = "Year"
            dpi.Value = "" 'Me.cmbYear.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'docdate start
            dpi = New DocPrintingItem
            dpi.Mapping = "docdatestart"
            If Not IsDBNull(Filters(0).Value) Then
                dpi.Value = CDate((Filters(0).Value)).ToShortDateString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'docdate end
            dpi = New DocPrintingItem
            dpi.Mapping = "docdateend"
            If Not IsDBNull(Filters(1).Value) Then
                dpi.Value = CDate((Filters(1).Value)).ToShortDateString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'supplier start
            dpi = New DocPrintingItem
            dpi.Mapping = "supplierstart"
            If Not IsDBNull(Filters(2).Value) Then
                dpi.Value = CStr((Filters(2).Value)).ToString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'supplier end
            dpi = New DocPrintingItem
            dpi.Mapping = "supplierend"
            If Not IsDBNull(Filters(3).Value) Then
                dpi.Value = CStr((Filters(3).Value)).ToString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'costcenter start
            dpi = New DocPrintingItem
            dpi.Mapping = "costcenterstart"
            If Not IsDBNull(Filters(4).Value) Then
                dpi.Value = CStr((Filters(4).Value)).ToString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CheckBox ChildInclude
            dpi = New DocPrintingItem
            dpi.Mapping = "IncludeChildCC"
            If Not IsDBNull(Filters(5).Value) Then
                dpi.Value = "(รวมในสังกัด)"
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Dim SumAmt As Decimal = 0
            Dim SumDecsAmt As Decimal = 0
            Dim SumPayAmt As Decimal = 0

            Dim n As Integer = 0
            Dim i As Integer = 0
            For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
                If i > 1 Then

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col0"
                    dpi.Value = itemRow("col0")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col1"
                    dpi.Value = itemRow("col1")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col2"
                    dpi.Value = itemRow("col2")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col3"
                    dpi.Value = itemRow("col3")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col4"
                    dpi.Value = itemRow("col4")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)
                    If Not IsDBNull(itemRow("col4")) Then
                        SumAmt += CDec(itemRow("col4"))
                    End If

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col5"
                    dpi.Value = itemRow("col5")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)
                    If Not IsDBNull(itemRow("col5")) Then
                        SumDecsAmt += CDec(itemRow("col5"))
                    End If

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col6"
                    dpi.Value = itemRow("col6")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)
                    If Not IsDBNull(itemRow("col6")) Then
                        SumPayAmt += CDec(itemRow("col6"))
                    End If
                    n += 1
                End If
                i += 1
            Next

            'SumText
            dpi = New DocPrintingItem
            dpi.Mapping = "SumText"
            dpi.Value = "รวม"
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumAmt
            dpi = New DocPrintingItem
            dpi.Mapping = "sumAmt"
            dpi.Value = Configuration.FormatToString(SumAmt, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumDecsAmt
            dpi = New DocPrintingItem
            dpi.Mapping = "SumDecsAmt"
            dpi.Value = Configuration.FormatToString(SumDecsAmt, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumPayAmt
            dpi = New DocPrintingItem
            dpi.Mapping = "SumPayAmt"
            dpi.Value = Configuration.FormatToString(SumPayAmt, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

