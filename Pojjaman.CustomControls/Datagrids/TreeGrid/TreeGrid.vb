Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports System.ComponentModel
Namespace Longkong.Pojjaman.Gui.Components
    Public Class TreeGrid
        Inherits DataGrid

#Region "Members"
        Protected Const WM_KEYDOWN As Integer = &H100
        Protected Const VK_LEFT As Integer = &H25
        Protected Const VK_UP As Integer = &H26
        Protected Const VK_RIGHT As Integer = &H27
        Protected Const VK_DOWN As Integer = &H28

        Protected m_rowHeight As DataGridRowHeightSetter

        Private m_sortings As ArrayList
        Private m_sortingArrowColor As Color = Color.Red
        Private m_allowNew As Boolean = True
        Private m_treeManager As TreeManager

        Private m_cellchanged As Boolean = False 'ตรวจสอบว่ามีการเปลี่ยน Cell รึปล่าว

        Private m_colorList As New ColorCollection
        Private m_foreColorList As New ColorCollection

        Private m_autoColumnResize As Boolean = True
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.SetStyle(ControlStyles.UserPaint, True)
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.DoubleBuffer, True)
            Me.AllowSorting = False
            m_sortings = New ArrayList
        End Sub
#End Region

#Region "Properties"
        Public Property AutoColumnResize() As Boolean            Get                Return m_autoColumnResize            End Get            Set(ByVal Value As Boolean)                m_autoColumnResize = Value            End Set        End Property
        Public Property AllowNew() As Boolean            Get                Return m_allowNew            End Get            Set(ByVal Value As Boolean)                m_allowNew = Value            End Set        End Property
        Protected Overrides Sub OnCurrentCellChanged(ByVal e As System.EventArgs)
            MyBase.OnCurrentCellChanged(e)
            m_cellchanged = True
        End Sub
        <Browsable(False)> _
        Public Property Cellchanged() As Boolean            Get                Return m_cellchanged            End Get            Set(ByVal Value As Boolean)                m_cellchanged = Value            End Set        End Property
        <Browsable(False)> _
        Public ReadOnly Property ForeColorList() As ColorCollection            Get                m_foreColorList = New ColorCollection                For Each col As Color In m_colorList                    If CInt(col.R) + CInt(col.G) + CInt(col.B) > 128 * 3 Then
                        m_foreColorList.Add(Color.Black)
                    Else
                        m_foreColorList.Add(Color.White)
                    End If
                Next                Return m_foreColorList            End Get        End Property
        <Category("Colors"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Property ColorList() As ColorCollection            Get                Return m_colorList            End Get            Set(ByVal Value As ColorCollection)                m_colorList = Value            End Set        End Property
        <Category("Colors")> _
        Public Property SortingArrowColor() As Color            Get                Return m_sortingArrowColor            End Get            Set(ByVal Value As Color)                m_sortingArrowColor = Value            End Set        End Property
        <Browsable(False)> _
        Public Property TreeManager() As TreeManager            Get                Return m_treeManager            End Get            Set(ByVal Value As TreeManager)                m_treeManager = Value            End Set        End Property
#End Region

#Region "Event Handlers"
        Private Sub TreeGrid_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Scroll
            Me.Invalidate()
        End Sub
        Private Sub TreeGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
            If Not TypeOf Me.DataSource Is TreeTable Then
                Return
            End If
            Try
                Dim plusMinusColIndex As Integer = Me.GetPlusMinusColumnIndex                If plusMinusColIndex = -1 Then
                    Return
                End If                Dim p As Point = Me.PointToClient(Cursor.Position)
                Dim cursorBounds As New Rectangle(p.X, p.Y, 1, 1)
                Dim hti As DataGrid.HitTestInfo = Me.HitTest(p)
                Dim dt As TreeTable = CType(Me.DataSource, TreeTable)
                If hti.Type <> DataGrid.HitTestType.Cell OrElse hti.Row >= dt.Rows.Count Then
                    Exit Sub
                End If
                Dim row As TreeRow = CType(dt.Rows(hti.Row), TreeRow)
                Dim plusMinusCellBound As Rectangle
                plusMinusCellBound = Me.GetCellBounds(hti.Row, plusMinusColIndex)
                Dim plusminusLocation As Point
                plusminusLocation.X = plusMinusCellBound.X + (row.Level * PlusMinusTreeTextColumn.PlusMinusSize.Width)
                plusminusLocation.Y = plusMinusCellBound.Y + CInt((plusMinusCellBound.Height / 2) - (PlusMinusTreeTextColumn.PlusMinusSize.Height / 2))
                Dim plusMinusRect As New Rectangle(plusminusLocation, PlusMinusTreeTextColumn.PlusMinusSize)
                If cursorBounds.IntersectsWith(plusMinusRect) Then
                    dt.ToggleRowState(row)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
        Private Sub TreeGrid_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DataSourceChanged
            If TypeOf Me.DataSource Is TreeTable Then
                Dim cm As CurrencyManager = CType(Me.BindingContext(Me.DataSource, Me.DataMember), CurrencyManager)
                CType(cm.List, DataView).AllowNew = m_allowNew
                Dim dt As TreeTable = CType(Me.DataSource, TreeTable)
                AddHandler dt.RowExpandStateChanged, AddressOf RowExpandStateChanged
            End If
        End Sub
        Private Sub RowExpandStateChanged(ByVal e As RowExpandCollapseEventArgs)
            RefreshHeights()
        End Sub
        Private Sub DataGrid_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
            If m_autoColumnResize AndAlso Not Me.TableStyles Is Nothing AndAlso Me.TableStyles.Count > 0 Then
                Dim space As Integer = SystemInformation.VerticalScrollBarWidth + 10
                Dim w As Integer = Me.Width
                Dim preferredWidth As Integer = w - (space + Me.RowHeaderWidth)
                Dim allColWidth As Integer = 0
                For Each col As DataGridColumnStyle In Me.TableStyles(0).GridColumnStyles
                    allColWidth += col.Width
                Next
                If allColWidth < preferredWidth Then
                    For Each col As DataGridColumnStyle In Me.TableStyles(0).GridColumnStyles
                        col.Width = CInt((col.Width / allColWidth) * preferredWidth)
                    Next
                End If
            End If
            'Try
            '    Me.UpdateScrollBar()
            'Catch ex As Exception

            'End Try
        End Sub
#End Region

#Region "Methods"
        Public Shared Function GetDefaultColorList() As ColorCollection
            Dim myColorList As New ColorCollection
            'Dim myPropertyService As Longkong.Core.Properties.PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim colorListTokens As String = "252,252,3;77,247,242;230,23,23" 'myPropertyService.GetProperty("Pojjaman.ColorList", "0,0,0")
            If Not colorListTokens = "" Then
                Dim colorStringList As String() = colorListTokens.Split(New Char() {";"c})
                For Each colorString As String In colorStringList
                    Dim colorRgb As String() = colorString.Split(New Char() {","c})
                    myColorList.Add(Color.FromArgb(CInt(colorRgb(0)), CInt(colorRgb(1)), CInt(colorRgb(2))))
                Next
            End If
            Return myColorList
        End Function
        Public Sub RefreshHeights()
            'If Not m_rowHeight Is Nothing Then
            '    m_rowHeight.RefreshHeights()
            'Else
            '    m_rowHeight = New DataGridRowHeightSetter(Me)
            'End If
            m_rowHeight = Nothing
            m_rowHeight = New DataGridRowHeightSetter(Me)
            If TypeOf Me.DataSource Is TreeTable Then
                Dim dt As TreeTable = CType(Me.DataSource, TreeTable)
                For Each row As TreeRow In dt.Rows
                    If row.IsVisible Then
                        m_rowHeight(row.Index) = Me.TableStyles(0).PreferredRowHeight 'Me.PreferredRowHeight
                    Else
                        m_rowHeight(row.Index) = 0
                    End If
                Next
            End If
            'Hack:แก้ปัญหาเรื่อง ScrollBar (ไม่น่าเชื่อว่าจะง่ายขนาดนี้)
            Me.Size = New Size(Me.Size.Width + 1, Me.Size.Height)
            Me.Size = New Size(Me.Size.Width - 1, Me.Size.Height)
        End Sub
        Public Function GetPlusMinusColumnIndex() As Integer
            For i As Integer = 0 To Me.TableStyles(0).GridColumnStyles.Count - 1
                Dim colStyle As DataGridColumnStyle = Me.TableStyles(0).GridColumnStyles(i)
                If TypeOf colStyle Is PlusMinusTreeTextColumn Then
                    Return i
                End If
            Next
            Return -1
        End Function
#End Region

#Region "Events"
        Public Event ColumnHeaderClicked(ByVal sender As Object, ByVal e As TreeColumnHeaderClickEventArgs)
#End Region

        '#Region "Header Drawing Methods"
        '        Private Sub DrawHeader(ByVal g As Graphics, ByVal ClipRect As Rectangle, ByVal OffsetX As Integer, ByVal OffsetY As Integer)
        '            Dim oldHeaderFont As Font = Me.HeaderFont
        '            Dim rs As Rectangle
        '            Dim rs2 As Rectangle
        '            Dim rs3 As Rectangle
        '            Dim top As Integer = Me.HeaderFont.Height
        '            If ClipRect.Top < top Then
        '                Dim b As New SolidBrush(Me.HeaderBackColor)
        '                Dim b2 As New SolidBrush(Me.HeaderForeColor)
        '                Dim b3 As New SolidBrush(Me.BackgroundColor)
        '                Dim x As Integer = Me.RowHeaderWidth + 4
        '                Dim i As Integer
        '                Dim w, r As Integer
        '                Dim dx As Integer
        '                rs3 = New Rectangle(0, 2, x - 2, top + 6)
        '                For i = Me.FirstVisibleColumn To Me.FirstVisibleColumn + Me.VisibleColumnCount - 1
        '                    If i = Me.FirstVisibleColumn Then
        '                        w = Me.GetCellBounds(Me.CurrentCell.RowNumber, i).Right - x - 1
        '                    Else
        '                        w = Me.TableStyles(0).GridColumnStyles(i).Width
        '                    End If
        '                    Debug.WriteLine(i & " " & w)
        '                    r = w + 2

        '                    If i = FirstVisibleColumn Then
        '                        dx = -4
        '                    Else
        '                        dx = 0
        '                    End If
        '                    rs = New Rectangle(x + 2 + dx, 3, r - 3 - dx, top + 3)
        '                    If Me.FirstVisibleColumn + Me.VisibleColumnCount - 1 = i Then
        '                        rs2 = New Rectangle(x + 1 + dx, 2, r - dx - 1, top + 6)
        '                    Else
        '                        rs2 = New Rectangle(x + 1 + dx, 2, r - dx, top + 6)
        '                    End If
        '                    g.FillRectangle(b, rs)
        '                    ControlPaint.DrawBorder3D(g, rs2)

        '                    If Not Me.m_treeManager Is Nothing AndAlso Me.TreeManager.AllowSorting Then
        '                        Dim j As Integer = 1
        '                        For Each col As SortedColumn In m_treeManager.SortStack
        '                            If m_treeManager.GridTableStyle.GridColumnStyles(i).MappingName = col.ColName Then
        '                                If col.SortingDirection <> SortingDirection.None Then
        '                                    Dim glyphRect As New Rectangle(x + 5, 5, 12, 12)
        '                                    Dim up As Boolean = (col.SortingDirection = SortingDirection.Asc)
        '                                    DrawTriangle(g, glyphRect, up, j)
        '                                End If
        '                            End If
        '                            j += 1
        '                        Next
        '                    End If


        '                    PaintHeaderCell(g, Me.TableStyles(0).GridColumnStyles(i).HeaderText, oldHeaderFont, b2, rs, OffsetX, OffsetY)
        '                    x += w
        '                    If Me.FirstVisibleColumn + Me.VisibleColumnCount - 1 = i Then
        '                        Dim pn As New Drawing.Pen(Me.BackColor)
        '                        g.DrawLine(pn, x + 1, 2, x + 1, top + 6)
        '                        pn.Dispose()
        '                    End If
        '                Next
        '                Dim p As New Drawing.Pen(Me.BackgroundColor)
        '                g.DrawLine(p, x + 2, 2, x + 2, top + 7)
        '                p.Dispose()
        '                b.Dispose()
        '                b2.Dispose()
        '                g.FillRectangle(b3, rs3)
        '                b3.Dispose()
        '            End If
        '        End Sub
        '        Private Sub DrawTriangle(ByVal g As Graphics, ByVal rect As Rectangle, ByVal up As Boolean, ByVal order As Integer)
        '            Dim outline As New GraphicsPath
        '            If up Then
        '                outline.AddPolygon(New Point() {New Point(rect.Left, rect.Bottom), New Point(rect.Right, rect.Bottom), New Point(CInt(rect.Width / 2) + rect.Left, rect.Top)})
        '            Else
        '                outline.AddPolygon(New Point() {New Point(rect.Left, rect.Top), New Point(rect.Right, rect.Top), New Point(CInt(rect.Width / 2) + rect.Left, rect.Bottom)})
        '            End If
        '            g.DrawPath(New Pen(m_sortingArrowColor), outline)

        '            Dim sf As New StringFormat
        '            sf.Alignment = StringAlignment.Center
        '            sf.LineAlignment = StringAlignment.Center
        '            Dim smallFont As New Font(Me.HeaderFont.FontFamily, 8, FontStyle.Bold, GraphicsUnit.Pixel)
        '            If up Then
        '                rect.Y += 3
        '                g.DrawString(order.ToString, smallFont, New SolidBrush(Me.HeaderForeColor), RectangleF.op_Implicit(rect), sf)
        '            Else
        '                g.DrawString(order.ToString, smallFont, New SolidBrush(Me.HeaderForeColor), RectangleF.op_Implicit(rect), sf)
        '            End If
        '        End Sub
        '        Public Sub PaintHeaderCell(ByVal g As Graphics, ByVal Sentence As String, ByVal F As Font, ByVal br As Brush, ByVal Bounds As Rectangle, ByVal offsetx As Integer, ByVal offsety As Integer)
        '            Dim nRowsInCaption As Integer = 1
        '            Dim strs(nRowsInCaption - 1), tt() As String
        '            tt = Sentence.Split(" "c)
        '            Dim i, j, n As Integer
        '            j = 0
        '            Dim s As String = ""
        '            Dim os As String
        '            os = s
        '            For i = 0 To nRowsInCaption - 1
        '                strs(i) = ""
        '            Next
        '            For i = 0 To tt.Length - 1
        '                If s <> "" Then
        '                    s &= " " & tt(i)
        '                Else
        '                    s = tt(i)
        '                    os = s
        '                End If
        '                Dim w As Integer = CInt(g.MeasureString(s, F).Width)
        '                If w >= Bounds.Width Then
        '                    strs(j) = os
        '                    If s <> tt(i) Then
        '                        s = tt(i)
        '                        os = tt(i)
        '                    Else
        '                        s = ""
        '                        os = ""
        '                    End If
        '                    If j = nRowsInCaption - 1 And i <= tt.Length - 1 Then
        '                        strs(j) = "..."
        '                        Exit For
        '                    End If
        '                    j += 1
        '                Else
        '                    os = s
        '                End If
        '                If i = tt.Length - 1 And j <> nRowsInCaption Then
        '                    strs(j) = s
        '                End If
        '            Next
        '            n = nRowsInCaption - 1
        '            Dim h As Integer = (Bounds.Height Mod F.Height) \ 2
        '            For i = 0 To n
        '                Dim w As Integer = CInt(g.MeasureString(strs(i), F).Width)
        '                If w < Bounds.Width Then
        '                    w = (Bounds.Width - w) \ 2
        '                Else
        '                    If Bounds.Width > 0 Then
        '                        While w >= Bounds.Width
        '                            strs(i) = strs(i).Substring(0, strs(i).Length - 1)
        '                            w = CInt(g.MeasureString(strs(i), F).Width)
        '                        End While
        '                    Else
        '                        Return
        '                    End If
        '                    w = 0
        '                End If
        '                g.DrawString(strs(i), F, br, Bounds.X + w + offsetx, Bounds.Y + h + offsety)
        '                h += F.Height
        '            Next
        '        End Sub
        '#End Region

#Region "Overrides"
        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                SendKeys.Send("{Tab}")
                Return True
            End If
            If msg.WParam.ToInt32() = CInt(Keys.Delete) Then
                If Not Me.m_treeManager Is Nothing AndAlso Not Me.m_treeManager.AllowDelete Then
                    If m_lastClickedPosIsRowHeader Then
                        Return True
                    End If
                End If
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function

        'Public Overrides Function PreProcessMessage(ByRef msg As System.Windows.Forms.Message) As Boolean
        '    Dim keyCode As Keys = CType((msg.WParam.ToInt32 And Keys.KeyCode), Keys)

        '    If msg.Msg = WM_KEYDOWN And keyCode = Keys.Delete Then
        '        If Not Me.m_treeManager Is Nothing AndAlso Not Me.m_treeManager.AllowDelete Then
        '            Return True
        '        End If
        '    End If

        '    Return MyBase.PreProcessMessage(msg)

        'End Function
        'Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        '    Dim pt As Point
        '    Dim hti As DataGrid.HitTestInfo

        '    pt = Me.PointToClient(Cursor.Position)
        '    hti = Me.HitTest(pt)

        '    If keyData = Keys.Delete Then
        '        If hti.Type = Me.HitTestType.RowHeader Then
        '            If Not Me.m_treeManager Is Nothing AndAlso Not Me.m_treeManager.AllowDelete Then
        '                Return True
        '            End If
        '        End If
        '    End If
        '    Return MyBase.ProcessDialogKey(keyData)
        'End Function
        Private m_lastClickedPosIsRowHeader As Boolean = False
        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            Dim hti As HitTestInfo = Me.HitTest(e.X, e.Y)
            If hti.Type = DataGrid.HitTestType.ColumnHeader Then
                RaiseEvent ColumnHeaderClicked(Me, New TreeColumnHeaderClickEventArgs(hti.Column, e.Button))
            End If
            If hti.Type = DataGrid.HitTestType.RowHeader Then
                m_lastClickedPosIsRowHeader = True
            Else
                m_lastClickedPosIsRowHeader = False
            End If
        End Sub
        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim hti As HitTestInfo = Me.HitTest(e.X, e.Y)
            If hti.Type = DataGrid.HitTestType.ColumnResize And hti.Column >= 0 Then
                If Me.TableStyles.Count = 0 Then
                    Return
                End If
                Dim style As DataGridTableStyle = Me.TableStyles(0)
                If style Is Nothing Then
                    Return
                End If
                Dim colStyle As DataGridColumnStyle = style.GridColumnStyles(hti.Column)
                If TypeOf colStyle Is DataGridButtonColumn OrElse TypeOf colStyle Is DataGridBarrierColumn Then
                    Return
                End If
            End If
            If hti.Type = DataGrid.HitTestType.RowResize Then
                Return
            End If
            MyBase.OnMouseMove(e)
        End Sub
        Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
            Try
                MyBase.OnPaint(pe)
            Catch ex As Exception
                'MessageBox.Show(ex.Message & ":" & ex.StackTrace)
                MessageBox.Show("Drawing Error")
            End Try
            'Try
            '    DrawHeader(pe.Graphics, pe.ClipRectangle, 0, 0)

            'Catch ex As Exception
            '    'MessageBox.Show(ex.ToString)
            'End Try

        End Sub
#End Region

    End Class

End Namespace

