Option Strict On
Option Explicit On
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Syncfusion.Windows.Forms.Grid
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptGLPayReceivebyAcct
        Inherits Report
        Implements INewReport

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
        Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
        Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
            m_grid = grid
            RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            m_grid.BeginUpdate()
            m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            m_grid.Model.Options.NumberedColHeaders = False
            m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
            m_grid.HorizontalThumbTrack = True
            m_grid.VerticalThumbTrack = True
            CreateHeader()
            PopulateData()
            m_grid.EndUpdate()
        End Sub
        Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

            Dim dr As DataRow = CType(m_grid(e.RowIndex, 0).Tag, DataRow)
            If dr Is Nothing Then
                Return
            End If

            Dim drh As New DataRowHelper(dr)

            Dim docId As Integer = drh.GetValue(Of Integer)("refId")
            Dim docType As Integer = drh.GetValue(Of Integer)("refType")

            If docId > 0 AndAlso docType > 0 Then
                Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                myEntityPanelService.OpenDetailPanel(en)
            End If
        End Sub
        Private Sub CreateHeader()
            m_grid.RowCount = 2
            m_grid.ColCount = 9

            m_grid.RowStyles(0).Font.Bold = True
            m_grid.RowStyles(1).Font.Bold = True
            m_grid.RowStyles(2).Font.Bold = True

            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 200
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 140
            m_grid.ColWidths(5) = 140
            m_grid.ColWidths(6) = 120
            m_grid.ColWidths(7) = 120
            m_grid.ColWidths(8) = 120
            m_grid.ColWidths(9) = 100


            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2

            '"เลขที่ผังบัญชี"
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.AcctCode}")
            '"ชื่อผังบัญชี"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.AcctName}")
            '"รหัสเจ้าหนี้"
            m_grid(1, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.APCode}")
            '"ชื่อเจ้าหนี้"
            m_grid(1, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.APName}")
            '"วงเงินเครดิต"
            m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.CreditAmount}")
            '"สถานะเจ้าหนี้"
            m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.APStatus}")
            '"วันที่เอกสาร"
            m_grid(2, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.DocDate}")
            '"เลขที่เอกสาร"
            m_grid(2, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.DocCode}")
            '"เลขที่ใบสำคัญ"
            m_grid(2, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.GLCode}")
            '"ประเภทเอกสาร"
            m_grid(2, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.DocType}")
            '"เลขที่ใบสำคัญ รับ/จ่าย"
            m_grid(2, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.PVCode}")
            '"เดบิต"
            m_grid(2, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.Debit}")
            '"เครดิต"
            m_grid(2, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.Credit}")
            '"คงเหลือ"
            m_grid(2, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.Remain}")
            '"เทอม"
            m_grid(2, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.Term}")

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currDocIndex As Integer = -1
            Dim currEntityIndex As Integer = -1
            Dim currAccountIndex As Integer = -1
            Dim opnAccountIndex As Integer = -1
            'Dim opnEntityIndex As Integer = -1
            Dim opnAccount As Decimal = 0
            Dim opnEntity As Decimal = 0
            Dim currentEntityCode As String = ""
            Dim currentEntityType As Integer = -1
            Dim currentEntityName As String = ""
            Dim currentAccountCode As String = ""
            Dim currentAccountName As String = ""
            Dim remainAccount As Decimal = 0
            Dim remainEntity As Decimal = 0
            Dim sumAccountDebit As Decimal = 0
            Dim sumAccountCredit As Decimal = 0
            Dim sumEntityDebit As Decimal = 0
            Dim sumEntityCredit As Decimal = 0
            Dim totalRow As Integer = 0
            Dim countRow As Integer = 0
            Dim countEntity As Integer = 0
            totalRow = dt.Rows.Count
            Dim AcctType As Integer = 0

            For Each row As DataRow In dt.Rows

                countRow += 1

                If Not (CStr(row("AcctCode")) = currentAccountCode) Then

                    If opnAccountIndex > -1 Then
                        m_grid(opnAccountIndex, 8).CellValue = Configuration.FormatToString(opnAccount, DigitConfig.Price)

                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount

                        m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(250, 192, 144)
                        m_grid.RowStyles(currDocIndex).Font.Bold = True
                        m_grid.RowStyles(currDocIndex).ReadOnly = True

                        'm_grid(currDocIndex, 1).CellValue = currentEntityCode
                        'm_grid(currDocIndex, 2).CellValue = currentEntityName
                        m_grid(currDocIndex, 4).CellValue = "รวมเงิน"
                        m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumEntityDebit, DigitConfig.Price)
                        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumEntityCredit, DigitConfig.Price)
                        '--------------------------------------------------------
                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount

                        m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(255, 255, 0)
                        m_grid.RowStyles(currDocIndex).Font.Bold = True
                        m_grid.RowStyles(currDocIndex).ReadOnly = True

                        m_grid(currDocIndex, 4).CellValue = "จำนวนเจ้าหนี้(ราย)"
                        m_grid(currDocIndex, 5).CellValue = "ยอดยกมา"
                        m_grid(currDocIndex, 6).CellValue = "เดบิต"
                        m_grid(currDocIndex, 7).CellValue = "เครดิต"
                        m_grid(currDocIndex, 8).CellValue = "คงเหลือ"
                        '--------------------------------------------------------
                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount

                        m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(255, 255, 0)
                        m_grid.RowStyles(currDocIndex).Font.Bold = True
                        m_grid.RowStyles(currDocIndex).ReadOnly = True

                        'm_grid(currDocIndex, 1).CellValue = currentAccountCode
                        'm_grid(currDocIndex, 2).CellValue = currentAccountName
                        m_grid(currDocIndex, 4).CellValue = countEntity
                        m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(opnAccount, DigitConfig.Price)
                        m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumAccountDebit, DigitConfig.Price)
                        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumAccountCredit, DigitConfig.Price)
                        m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(remainAccount, DigitConfig.Price)
                        '--------------------------------------------------------   
                    End If
                    currentAccountCode = CStr(row("AcctCode"))
                    currentAccountName = CStr(row("AcctName"))
                    AcctType = CInt(row("AcctType"))
                    If AcctType = 1 OrElse AcctType = 5 Then
                        opnAccount = CDec(row("OPNDebit")) - CDec(row("OPNCredit"))
                    Else
                        opnAccount = CDec(row("OPNCredit")) - CDec(row("OPNDebit"))
                    End If
                    m_grid.RowCount += 1
                    currAccountIndex = m_grid.RowCount
                    currDocIndex = m_grid.RowCount
                    opnAccountIndex = m_grid.RowCount

                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(255, 255, 0)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True

                    m_grid(currDocIndex, 1).CellValue = row("AcctCode")
                    m_grid(currDocIndex, 2).CellValue = row("AcctName")
                    m_grid(currDocIndex, 4).CellValue = "ยอดยกมา"
                    'm_grid(currDocIndex, 6).CellValue = CDec(row("OPNDebit"))
                    'm_grid(currDocIndex, 7).CellValue = CDec(row("OPNCredit"))
                    'm_grid(currDocIndex, 8).CellValue = 0
                    '-------------------------------------------------
                    currentEntityCode = CStr(row("EntityCode"))
                    currentEntityType = CInt(row("EntityType"))
                    currentEntityName = CStr(row("EntityName"))
                    If AcctType = 1 OrElse AcctType = 5 Then
                        opnEntity = CDec(row("OPNDebit")) - CDec(row("OPNCredit"))
                    Else
                        opnEntity = CDec(row("OPNCredit")) - CDec(row("OPNDebit"))
                    End If
                    m_grid.RowCount += 1
                    currEntityIndex = m_grid.RowCount
                    currDocIndex = m_grid.RowCount

                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(250, 192, 144)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True

                    m_grid(currDocIndex, 1).CellValue = row("EntityCode")
                    m_grid(currDocIndex, 2).CellValue = row("EntityName")
                    m_grid(currDocIndex, 3).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")), DigitConfig.Price)
                    m_grid(currDocIndex, 5).CellValue = row("EntityStatus")
                    '--------------------------------------------------
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount

                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(182, 221, 232)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True

                    m_grid(currDocIndex, 4).CellValue = "ยอดยกมา"
                    'm_grid(currDocIndex, 6).CellValue = CDec(row("OPNDebit"))
                    'm_grid(currDocIndex, 7).CellValue = CDec(row("OPNCredit"))
                    m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(opnEntity, DigitConfig.Price)

                    remainAccount = opnEntity
                    remainEntity = opnEntity
                    sumAccountDebit = 0
                    sumAccountCredit = 0
                    sumEntityDebit = 0
                    sumEntityCredit = 0

                    countEntity = 1

                ElseIf Not (CStr(row("EntityCode")) = currentEntityCode) _
                OrElse Not (CInt(row("EntityType")) = currentEntityType) Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount

                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(250, 192, 144)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True

                    'm_grid(currDocIndex, 1).CellValue = currentEntityCode
                    'm_grid(currDocIndex, 2).CellValue = currentEntityName
                    m_grid(currDocIndex, 4).CellValue = "รวมเงิน"
                    m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumEntityDebit, DigitConfig.Price)
                    m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumEntityCredit, DigitConfig.Price)
                    '--------------------------------------------------------
                    currentEntityCode = CStr(row("EntityCode"))
                    currentEntityType = CInt(row("EntityType"))
                    currentEntityName = CStr(row("EntityName"))

                    If AcctType = 1 OrElse AcctType = 5 Then
                        opnEntity = CDec(row("OPNDebit")) - CDec(row("OPNCredit"))
                        opnAccount += CDec(row("OPNDebit")) - CDec(row("OPNCredit"))
                    Else
                        opnAccount += CDec(row("OPNCredit")) - CDec(row("OPNDebit"))
                        opnEntity = CDec(row("OPNCredit")) - CDec(row("OPNDebit"))
                    End If
                    m_grid.RowCount += 1
                    currEntityIndex = m_grid.RowCount
                    currDocIndex = m_grid.RowCount

                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(250, 192, 144)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True

                    m_grid(currDocIndex, 1).CellValue = row("EntityCode")
                    m_grid(currDocIndex, 2).CellValue = row("EntityName")
                    m_grid(currDocIndex, 3).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")), DigitConfig.Price)
                    m_grid(currDocIndex, 5).CellValue = row("EntityStatus")
                    '----------------------------------------
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount

                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(182, 221, 232)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True

                    m_grid(currDocIndex, 4).CellValue = "ยอดยกมา"
                    'm_grid(currDocIndex, 6).CellValue = CDec(row("OPNDebit"))
                    'm_grid(currDocIndex, 7).CellValue = CDec(row("OPNCredit"))
                    m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(opnEntity, DigitConfig.Price)
                    'opnEntityIndex = m_grid.RowCount
                    '----------------------------------------

                    remainAccount += opnEntity
                    remainEntity = opnEntity
                    sumEntityDebit = 0
                    sumEntityCredit = 0

                    countEntity += 1

                End If

                If AcctType = 1 OrElse AcctType = 5 Then
                    remainEntity += (CDec(row("Debit")) - CDec(row("Credit")))
                Else
                    remainEntity += (CDec(row("Credit")) - CDec(row("Debit")))
                End If

                m_grid.RowCount += 1
                currDocIndex = m_grid.RowCount
                m_grid(currDocIndex, 0).Tag = row
                m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(182, 221, 232)
                'm_grid.RowStyles(currDocIndex).Font.Bold = True
                m_grid.RowStyles(currDocIndex).ReadOnly = True

                m_grid(currDocIndex, 1).CellValue = CDate(row("DocDate")).ToShortDateString()
                m_grid(currDocIndex, 2).CellValue = row("DocCode")
                m_grid(currDocIndex, 3).CellValue = row("TransCode")
                m_grid(currDocIndex, 4).CellValue = row("DocType")
                m_grid(currDocIndex, 5).CellValue = row("PVCode")
                m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Debit")), DigitConfig.Price)
                m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Credit")), DigitConfig.Price)
                m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(remainEntity, DigitConfig.Price)
                m_grid(currDocIndex, 9).CellValue = row("Period")
                '----------------------------------------

                If AcctType = 1 OrElse AcctType = 5 Then
                    remainAccount += (CDec(row("Debit")) - CDec(row("Credit")))
                Else
                    remainAccount += (CDec(row("Credit")) - CDec(row("Debit")))
                End If

                sumEntityDebit += CDec(row("Debit"))
                sumEntityCredit += CDec(row("Credit"))
                sumAccountDebit += CDec(row("Debit"))
                sumAccountCredit += CDec(row("Credit"))

                If countRow = totalRow Then

                    If opnAccountIndex > -1 Then
                        m_grid(opnAccountIndex, 8).CellValue = Configuration.FormatToString(opnAccount, DigitConfig.Price)

                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount

                        m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(250, 192, 144)
                        m_grid.RowStyles(currDocIndex).Font.Bold = True
                        m_grid.RowStyles(currDocIndex).ReadOnly = True

                        'm_grid(currDocIndex, 1).CellValue = currentEntityCode
                        'm_grid(currDocIndex, 2).CellValue = currentEntityName
                        m_grid(currDocIndex, 4).CellValue = "รวมเงิน"
                        m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumEntityDebit, DigitConfig.Price)
                        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumEntityCredit, DigitConfig.Price)
                        '----------------------------------------------------
                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount

                        m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(255, 255, 0)
                        m_grid.RowStyles(currDocIndex).Font.Bold = True
                        m_grid.RowStyles(currDocIndex).ReadOnly = True

                        m_grid(currDocIndex, 4).CellValue = "จำนวนเจ้าหนี้(ราย)"
                        m_grid(currDocIndex, 5).CellValue = "ยอดยกมา"
                        m_grid(currDocIndex, 6).CellValue = "เดบิต"
                        m_grid(currDocIndex, 7).CellValue = "เครดิต"
                        m_grid(currDocIndex, 8).CellValue = "คงเหลือ"
                        '--------------------------------------------------------
                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount

                        m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(255, 255, 0)
                        m_grid.RowStyles(currDocIndex).Font.Bold = True
                        m_grid.RowStyles(currDocIndex).ReadOnly = True

                        'm_grid(currDocIndex, 1).CellValue = currentAccountCode
                        'm_grid(currDocIndex, 2).CellValue = currentAccountName
                        m_grid(currDocIndex, 4).CellValue = countEntity
                        m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(opnAccount, DigitConfig.Price)
                        m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumAccountDebit, DigitConfig.Price)
                        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumAccountCredit, DigitConfig.Price)
                        m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(remainAccount, DigitConfig.Price)
                        '--------------------------------------------------------   

                    End If

                End If

            Next

        End Sub

#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptGLPayReceivebyAcct"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptGLPayReceivebyAcct.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptAPGL"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptAPGL"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptGLPayReceivebyAcct.DetailLabel}"
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
            Return "RptAPGL"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptAPGL"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            'Dim IsSummaryLine As Boolean = False

            For rowIndex As Integer = 3 To m_grid.RowCount
                'IsSummaryLine = False

                dpi = New DocPrintingItem
                dpi.Mapping = "col0"
                dpi.Value = m_grid(rowIndex, 1).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col1"
                dpi.Value = m_grid(rowIndex, 2).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col2"
                dpi.Value = m_grid(rowIndex, 3).CellValue
                'If CStr(dpi.Value) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.Total}") Then
                '    IsSummaryLine = True
                '    dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                'End If
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col3"
                dpi.Value = m_grid(rowIndex, 4).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col4"
                dpi.Value = m_grid(rowIndex, 5).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col5"
                dpi.Value = m_grid(rowIndex, 6).CellValue
                'If IsSummaryLine Then
                '    dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                'End If
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col6"
                dpi.Value = m_grid(rowIndex, 7).CellValue
                'If IsSummaryLine Then
                '    dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                'End If
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col7"
                dpi.Value = m_grid(rowIndex, 8).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col8"
                dpi.Value = m_grid(rowIndex, 9).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col9"
                dpi.Value = m_grid(rowIndex, 10).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)


                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

