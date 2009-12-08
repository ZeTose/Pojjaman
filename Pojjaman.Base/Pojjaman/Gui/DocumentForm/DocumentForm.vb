Imports Longkong.Pojjaman.Gui.XmlForms
Imports System.IO
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.FormTable
Imports longkong.Pojjaman.Services
Imports longkong.Core.Services
Imports Longkong.Core.Properties
Namespace Longkong.Pojjaman.Gui.ReportsAndDocs
    Public Class DocumentForm
        Inherits BasePojjamanForm

#Region "Members"
        Private m_fts As ArrayList
        Private m_entity As IPrintableEntity
        Private m_pageCount As Integer
        Private m_currentPage As Integer
        Private m_coll As DocPrintingItemCollection
        Private Shared FormPath As String = ""
        Private Shared ReportPath As String = ""
#End Region

#Region "Constructors"
        Shared Sub New()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            FormPath = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "documents")
            ReportPath = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "reports")
        End Sub
        Public Sub New(ByVal fileName As String)
            MyBase.New(fileName)
            m_fts = New ArrayList
        End Sub
        Public Sub New(ByVal fileName As String, ByVal prinTableEntity As IPrintableEntity)
            MyBase.New(fileName)
            m_entity = prinTableEntity
            Init()
        End Sub
        Public Sub New(ByVal entity As IListable)
            MyBase.New()
            Dim thePath As String = ""

            If TypeOf entity Is IObjectReflectable Then
                thePath = FormPath & Path.DirectorySeparatorChar & CType(entity, IObjectReflectable).ClassName & "List.dfm"
            Else
                Return
            End If
            If Not File.Exists(thePath) Then
                thePath = FormPath & Path.DirectorySeparatorChar & "GeneralList.dfm"
            End If
            If File.Exists(thePath) Then
                Me.SetupFromXml(thePath)
            Else
                Me.MessageService.ShowMessageFormatted("${res:Global.Error.FileNotFound}", New String() {thePath})
                Return
            End If
            'm_entity = prinTableEntity
            Init()
        End Sub
        Public Sub New(ByVal prinTableEntity As IPrintableEntity)
            MyBase.New()
            Dim thePath As String = ""

            If TypeOf prinTableEntity Is Report Then
                thePath = ReportPath & Path.DirectorySeparatorChar & CType(prinTableEntity, Report).ClassName & ".dfm"
            ElseIf TypeOf prinTableEntity Is ISimpleEntity Then
                thePath = FormPath & Path.DirectorySeparatorChar & CType(prinTableEntity, ISimpleEntity).ClassName & ".dfm"
            Else
                Return
            End If
            If File.Exists(thePath) Then
                Me.SetupFromXml(thePath)
            Else
                Me.MessageService.ShowMessageFormatted("${res:Global.Error.FileNotFound}", New String() {thePath})
                Return
            End If
            m_entity = prinTableEntity
            Init()
        End Sub
#End Region

#Region "Methods"
        Public Sub Init()
            m_pageCount = 0
            m_currentPage = 0
            m_fts = New ArrayList
            For Each entry As DictionaryEntry In Me.ControlDictionary.Hashtable
                If TypeOf entry.Value Is FormTable.FormTable Then
                    m_fts.Add(entry.Value)
                End If
            Next
            m_coll = Me.m_entity.GetDocPrintingEntries
            SetPageCount()
        End Sub
        Public Sub SetPageCount()
            Dim maxPGs As Integer = 0
            For Each ft As FormTable.FormTable In m_fts
                If ft.RowsPerPage > 0 Then
                    Dim cnt As Integer = m_coll.GetRowCount(ft.TableName)
                    Dim pgs As Integer = CInt(Math.Ceiling(cnt / ft.RowsPerPage))
                    If pgs > maxPGs Then
                        maxPGs = pgs
                    End If
                End If
            Next
            m_pageCount = maxPGs
        End Sub
        Public Function GetPageCount() As Integer
            Return m_pageCount
        End Function
#End Region

#Region "Properties"
        Public Property FormTables() As ArrayList
            Get
                Return m_fts
            End Get
            Set(ByVal Value As ArrayList)
                m_fts = Value
            End Set
        End Property
        Public ReadOnly Property PrintDocument() As PrintDocument
            Get
                If m_entity Is Nothing Then
                    Return Nothing
                End If
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
                        If Not TypeOf o Is FormTable.FormTable Then
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
                                    If ctrl.Data.StartsWith("=") Then
                                        ctrl.Data = ""
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
                            Dim ft As FormTable.FormTable = CType(o, FormTable.FormTable)
                            ft.Draw(pe.Graphics, ft.Location)
                            Dim startRow As Integer = ((m_currentPage - 1) * ft.RowsPerPage) + 1
                            Dim colOffset As Integer = 0
                            Dim verticalInterval As Integer = 5
                            Dim horizontalInterval As Integer = 5
                            For Each col As FormTable.Column In ft.Columns
                                colOffset = col.Width + colOffset
                                For i As Integer = startRow To (ft.RowsPerPage + startRow - 1)
                                    If i > m_coll.GetRowCount(ft.TableName) Then
                                        'เกินจำนวนแล้ว
                                        Exit For
                                    End If
                                    Dim item As DocPrintingItem = m_coll.GetMappingItem(ft.TableName, col.ReportField, i)
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
                                                ControlPaint.DrawMenuGlyph(pe.Graphics, ft.Location.X + startPoint, ft.HeaderHeight + ft.Location.Y + (i - startRow) * ft.RowHeight + verticalInterval, glyphSize, glyphSize, MenuGlyph.Checkmark)
                                            End If
                                        Else
                                            Dim data As String

                                            Select Case item.DataType.ToLower
                                                Case "system.datetime"
                                                    If IsDate(item.Value) Then
                                                        Dim itemDate As DateTime = CDate(item.Value)
                                                        data = itemDate.ToShortDateString
                                                    Else
                                                        data = item.Value.ToString
                                                    End If
                                                Case "system.integer"
                                                    Dim itemValue As Integer
                                                    If item.Value.tostring.Length > 0 Then
                                                        If IsNumeric(item.Value) Then
                                                            itemValue = CInt(item.Value)
                                                            data = Configuration.FormatToString(itemValue, DigitConfig.Int)
                                                        Else
                                                            data = item.Value.ToString
                                                        End If
                                                    Else
                                                        data = item.Value.ToString
                                                    End If
                                                Case "system.decimal"
                                                    Dim itemValue As Decimal
                                                    If item.Value.tostring.Length > 0 Then
                                                        If IsNumeric(item.Value) Then
                                                            itemValue = CDec(item.Value)
                                                            If itemvalue = 0 Then
                                                                data = ""
                                                            Else
                                                                data = Configuration.FormatToString(itemValue, DigitConfig.Price)
                                                            End If
                                                        Else
                                                            data = item.Value.ToString
                                                        End If
                                                    Else
                                                        data = item.Value.ToString
                                                    End If
                                                Case Else
                                                    data = item.Value.ToString
                                            End Select

                                            Dim dataFont As Font

                                            If Not item.Font Is Nothing Then
                                                dataFont = New Font(ft.Font.FontFamily.Name, ft.Font.Size, item.Font.Style, System.Drawing.GraphicsUnit.Point, ft.Font.GdiCharSet)
                                            Else
                                                dataFont = New Font(ft.Font.FontFamily.Name, ft.Font.Size, ft.Font.Style, System.Drawing.GraphicsUnit.Point, ft.Font.GdiCharSet)
                                            End If
                                            Dim textSize As SizeF = pe.Graphics.MeasureString(data, dataFont)
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
                                            Dim drawRect As New RectangleF(x1, y1, col.Width, ft.RowHeight)
                                            pe.Graphics.DrawString(data, dataFont, New SolidBrush(ft.ForeColor), drawRect, stf)
                                        End If
                                    End If
                                Next
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

