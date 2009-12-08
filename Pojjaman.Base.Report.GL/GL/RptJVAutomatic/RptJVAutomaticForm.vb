Imports Longkong.Pojjaman.Gui.XmlForms
Imports System.IO
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.FormTable
Imports longkong.Pojjaman.Services
Imports longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Gui.ReportsAndDocs
    Public Class RptJVAutomaticForm
        Inherits BasePojjamanForm

#Region "Members"
        Private m_ft As FormTable.MultiHeaderFormTable
        Private m_entity As RptJVAutomatic
        Private m_pageCount As Integer
        Private m_currentPage As Integer
        Private m_coll As DocPrintingItemCollection
        Private Shared FormPath As String = ""
        Private Shared ReportPath As String = ""
        Private m_rowCount As Integer
        Private m_rowList As ArrayList
#End Region

#Region "Constructors"
        Shared Sub New()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            ReportPath = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "reports")
        End Sub
        Public Sub New(ByVal prinTableEntity As RptJVAutomatic)
            MyBase.New()
            Me.SetupFromXml(ReportPath & Path.DirectorySeparatorChar & "TestMulti" & ".dfm") 'CType(prinTableEntity, Report).ClassName & ".dfm")
            m_entity = prinTableEntity
            m_rowList = New ArrayList
            Init()
        End Sub
#End Region

#Region "Methods"
        Public Sub Init()
            m_pageCount = 0
            m_currentPage = 0
            For Each entry As DictionaryEntry In Me.ControlDictionary.Hashtable
                If TypeOf entry.Value Is FormTable.MultiHeaderFormTable Then
                    m_ft = CType(entry.Value, FormTable.MultiHeaderFormTable)
                    Exit For
                End If
            Next
            m_coll = Me.m_entity.GetDocPrintingEntries
            SetItemTT()
            m_rowCount = m_rowList.Count
            SetPageCount()
        End Sub
        Public Sub SetPageCount()
            If m_ft Is Nothing Then
                Return
            End If
            Dim maxPGs As Integer = 0
            If m_ft.RowsPerPage > 0 Then
                Dim pgs As Integer = CInt(Math.Ceiling(m_rowCount / m_ft.RowsPerPage))
                If pgs > maxPGs Then
                    maxPGs = pgs
                End If
            End If
            m_pageCount = maxPGs
        End Sub
        Public Function GetPageCount() As Integer
            Return m_pageCount
        End Function
        Private Sub SetItemTT()
            If m_ft Is Nothing Then
                Return
            End If
            For Each child As TreeRow In Me.m_entity.Treemanager.Treetable.Childs
                If Not child.Index = 0 AndAlso Not child.Index = 1 Then
                    Dim items As New DocPrintingItemCollection(0)
                    Dim sumDebit As Decimal
                    Dim dummyItem As New DocPrintingItem
                    'col 0 Code
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = child(0)
                    items.Add(dummyItem)

                    'col 1 Note
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = child(1)
                    items.Add(dummyItem)

                    'col 2 RefCode
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = child(2)
                    items.Add(dummyItem)

                    'col 3 RefType
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = child(3)
                    items.Add(dummyItem)

                    'col 4 Debit1
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.Decimal"
                    dummyItem.Value = child(4)
                    items.Add(dummyItem)

                    'col 5 Credit1
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.Decimal"
                    dummyItem.Value = child(5)
                    items.Add(dummyItem)

                    'col 6 Debit2
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.Decimal"
                    dummyItem.Value = child(6)
                    items.Add(dummyItem)

                    'col 7 Credit2
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.Decimal"
                    dummyItem.Value = child(7)
                    items.Add(dummyItem)

                    'col 8 Debit3
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.Decimal"
                    dummyItem.Value = child(8)
                    items.Add(dummyItem)

                    'col 9 Credit3
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.Decimal"
                    dummyItem.Value = child(9)
                    items.Add(dummyItem)

                    'col 10 CC
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = child(10)
                    items.Add(dummyItem)

                    'col 11 Log in
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = child(11)
                    items.Add(dummyItem)

                    'col 12 Date
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.DateTime"
                    dummyItem.Value = child(12)
                    items.Add(dummyItem)
                    Me.m_rowList.Add(items)

                    For Each tr As TreeRow In child.Childs
                        Dim childitems As New DocPrintingItemCollection(1)
                        Dim dummychildItem As New DocPrintingItem
                        'col 0 Code
                        dummychildItem.DataType = "System.String"
                        dummychildItem.Value = tr(0)
                        childitems.Add(dummychildItem)

                        'col 1 Note
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.String"
                        dummychildItem.Value = tr(1)
                        childitems.Add(dummychildItem)

                        'col 2 RefCode
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.String"
                        dummychildItem.Value = tr(2)
                        childitems.Add(dummychildItem)

                        'col 3 RefType
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.String"
                        dummychildItem.Value = tr(3)
                        childitems.Add(dummychildItem)

                        'col 4 Debit1
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.Decimal"
                        dummychildItem.Value = tr(4)
                        childitems.Add(dummychildItem)

                        'col 5 Credit1
                        dummychildItem = New DocPrintingItem
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.Decimal"
                        dummychildItem.Value = tr(5)
                        childitems.Add(dummychildItem)

                        'col 6 Debit2
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.Decimal"
                        dummychildItem.Value = tr(6)
                        childitems.Add(dummychildItem)
                        If Not tr.IsNull(6) Then
                            sumDebit += CDec(tr(6))
                        End If

                        'col 7 Credit2
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.Decimal"
                        dummychildItem.Value = tr(7)
                        childitems.Add(dummyItem)

                        'col 8 Debit3
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.Decimal"
                        dummychildItem.Value = tr(8)
                        childitems.Add(dummychildItem)

                        'col 9 Credit3
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.Decimal"
                        dummychildItem.Value = tr(9)
                        childitems.Add(dummychildItem)

                        'col 10 CC
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.String"
                        dummychildItem.Value = tr(10)
                        childitems.Add(dummychildItem)

                        'col 11 Log in
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.String"
                        dummychildItem.Value = tr(11)
                        childitems.Add(dummychildItem)

                        'col 12 Date
                        dummychildItem = New DocPrintingItem
                        dummychildItem.DataType = "System.DateTime"
                        dummychildItem.Value = tr(12)
                        childitems.Add(dummychildItem)

                        Me.m_rowList.Add(childitems)
                    Next

                    items = New DocPrintingItemCollection(0)
                    'col 0 Code
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = ""
                    items.Add(dummyItem)

                    'col 1 Note
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = ""
                    items.Add(dummyItem)

                    'col 2 RefCode
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = ""
                    items.Add(dummyItem)

                    'col 3 RefType
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = "รวมรายการ"
                    items.Add(dummyItem)

                    'col 4 Debit1
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.Decimal"
                    dummyItem.Value = child.Childs.Count
                    items.Add(dummyItem)

                    'col 5 Credit1
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.Decimal"
                    dummyItem.Value = "จำนวนเงิน"
                    items.Add(dummyItem)

                    'col 6 Debit2
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.Decimal"
                    dummyItem.Value = Math.Abs(sumDebit)
                    items.Add(dummyItem)

                    'col 7 Credit2
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = "บาท"
                    items.Add(dummyItem)

                    'col 8 Debit3
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = ""
                    items.Add(dummyItem)

                    'col 9 Credit3
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = ""
                    items.Add(dummyItem)

                    'col 10 CC
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = ""
                    items.Add(dummyItem)

                    'col 11 Log in
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = ""
                    items.Add(dummyItem)

                    'col 12 Date
                    dummyItem = New DocPrintingItem
                    dummyItem.DataType = "System.String"
                    dummyItem.Value = ""
                    items.Add(dummyItem)
                    Me.m_rowList.Add(items)
                End If
            Next
        End Sub
#End Region

#Region "Properties"
        Public Property FormTable() As FormTable.MultiHeaderFormTable
            Get
                Return m_ft
            End Get
            Set(ByVal Value As FormTable.MultiHeaderFormTable)
                m_ft = Value
            End Set
        End Property
        Public ReadOnly Property PrintDocument() As PrintDocument
            Get
                Dim pd As New PrintDocument

                AddHandler pd.PrintPage, AddressOf PrintPage_Handler
                Return pd
            End Get
        End Property
        Private Sub PrintPage_Handler(ByVal sender As Object, ByVal pe As PrintPageEventArgs)
            'Undone: Refactor please!!!!
            Me.m_currentPage += 1
            Try
                For x As Integer = Me.ControlDictionary.ArrayList.Count - 1 To 0 Step -1
                    Dim o As Object = Me.ControlDictionary.ArrayList(x)
                    If TypeOf o Is IDrawable Then
                        If Not TypeOf o Is FormTable.MultiHeaderFormTable Then
                            Dim ctrl As IDrawable = CType(o, IDrawable)
                            If Not ctrl.Data Is Nothing Then
                                If ctrl.Data.ToLower = "=page" Then
                                    ctrl.Data = Me.m_currentPage.ToString
                                ElseIf ctrl.Data.ToLower = "=pages" Then
                                    ctrl.Data = Me.m_pageCount.ToString
                                ElseIf ctrl.Data.ToLower = "=date" Then
                                    ctrl.Data = Now.ToShortDateString
                                ElseIf ctrl.Data.ToLower = "=time" Then
                                    ctrl.Data = Now.ToShortTimeString
                                ElseIf ctrl.Data.StartsWith("=CText(") Then
                                    Dim num As String = ctrl.Data.Substring(7, ctrl.Data.Length - 8)
                                    Dim item As DocPrintingItem = m_coll.GetMappingItem(num)
                                    If Not item Is Nothing AndAlso IsNumeric(item.Value) Then
                                        Dim number As Decimal = CDec(item.Value)
                                        ctrl.Data = Configuration.FormatToString(number, DigitConfig.CurrencyText)
                                    End If

                                    'Fixed Value ทุกอันต้องอยู่ก่อนบรรทัดนี้:
                                ElseIf ctrl.Data.StartsWith("=") Then
                                    Dim map As String = ctrl.Data.Substring(1, Len(ctrl.Data) - 1)
                                    Dim item As DocPrintingItem = m_coll.GetMappingItem(map)
                                    If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
                                        ctrl.Data = item.Value.ToString
                                    End If
                                ElseIf ctrl.Data.StartsWith("Company") Then
                                    Dim config As Object = Configuration.GetConfig(ctrl.Data)
                                    If Not config Is Nothing Then
                                        ctrl.Data = config.ToString
                                    End If
                                End If
                            End If
                            ctrl.Draw(pe.Graphics, CType(o, Control).Location)
                        Else
                            Dim ft As FormTable.MultiHeaderFormTable = CType(o, FormTable.MultiHeaderFormTable)
                            ft.Draw(pe.Graphics, ft.Location)
                            Dim startRow As Integer = ((m_currentPage - 1) * ft.RowsPerPage) + 1
                            Dim colOffset As Integer = 0
                            Dim verticalInterval As Integer = 5
                            Dim horizontalInterval As Integer = 5
                            Dim colIndex As Integer = 0
                            For Each col As FormTable.MultiHeaderColumn In ft.MultiHeaderColumns
                                colOffset = col.Width + colOffset
                                For i As Integer = startRow To (ft.RowsPerPage + startRow - 1)
                                    If i > m_rowCount Then
                                        'เกินจำนวนแล้ว
                                        Exit For
                                    End If
                                    Dim docColl As DocPrintingItemCollection = CType(Me.m_rowList(i - 1), DocPrintingItemCollection)
                                    Dim item As DocPrintingItem = docColl(colIndex)
                                    Dim indent As Integer
                                    If col.Levels.Count > docColl.Level Then
                                        indent = col.Levels(docColl.Level).Indent
                                    End If
                                    If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
                                        If item.DataType = "System.Boolean" Then
                                            If CBool(item.Value) = False Then

                                            Else
                                                Dim glyphSize As Integer = 15
                                                Dim startPoint As Integer
                                                Select Case col.Alignment
                                                    Case HorizontalAlignment.Center
                                                        startPoint = CInt((col.Width / 2) - (glyphSize / 2)) + colOffset - col.Width
                                                    Case HorizontalAlignment.Left
                                                        startPoint = colOffset - col.Width + horizontalInterval
                                                    Case HorizontalAlignment.Right
                                                        startPoint = CInt(colOffset - glyphSize - horizontalInterval)
                                                End Select
                                                ControlPaint.DrawMenuGlyph(pe.Graphics, ft.Location.X + startPoint + indent, ft.HeaderHeight + ft.Location.Y + (i - startRow) * ft.RowHeight + verticalInterval, glyphSize, glyphSize, MenuGlyph.Checkmark)
                                            End If
                                        Else
                                            Dim data As String
                                            data = item.Value.ToString
                                            Dim textSize As SizeF = pe.Graphics.MeasureString(data, ft.Font)
                                            Dim stf As New StringFormat
                                            stf.Trimming = StringTrimming.EllipsisWord
                                            Select Case col.Alignment
                                                Case HorizontalAlignment.Center
                                                    stf.LineAlignment = StringAlignment.Center
                                                    stf.Alignment = StringAlignment.Center
                                                Case HorizontalAlignment.Left
                                                    stf.LineAlignment = StringAlignment.Center
                                                    stf.Alignment = StringAlignment.Near
                                                Case HorizontalAlignment.Right
                                                    stf.LineAlignment = StringAlignment.Center
                                                    stf.Alignment = StringAlignment.Far
                                            End Select
                                            Dim x1 As Integer = ft.Location.X + colOffset - col.Width '+ horizontalInterval
                                            Dim y1 As Integer = ft.HeaderHeight + ft.Location.Y + (i - startRow) * ft.RowHeight '+ verticalInterval
                                            Dim drawRect As New RectangleF(x1 + indent, y1, col.Width, ft.RowHeight)
                                            pe.Graphics.DrawString(data, ft.Font, New SolidBrush(ft.ForeColor), drawRect, stf)
                                        End If
                                    End If
                                Next
                                colIndex += 1
                            Next
                        End If
                    End If
                Next
                If m_currentPage < Me.m_pageCount Then
                    pe.HasMorePages = True
                Else
                    pe.HasMorePages = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
#End Region

    End Class
End Namespace

