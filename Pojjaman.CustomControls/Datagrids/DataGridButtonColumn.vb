Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Reflection
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Components

    Public Class DataGridButtonColumn
        Inherits PJMColumnStyle


#Region "Events"
        Delegate Sub ButtonColumnClickHandler(ByVal e As ButtonColumnEventArgs)
        Public Event Click As ButtonColumnClickHandler
#End Region

#Region "Members"
        Private m_buttonColor As Color
        Private m_depressedBounds As Rectangle

        Protected ColorList As ColorCollection
        Protected ForeColorList As ColorCollection
#End Region

#Region "Properties"
        Public Property ButtonColor() As Color            Get                Return m_buttonColor            End Get            Set(ByVal Value As Color)                m_buttonColor = Value            End Set        End Property
#End Region

#Region "Methods"
        Private Function IsInvisible(ByVal row As Integer) As Boolean
            Try
                Dim ds As Object = Me.DataGridTableStyle.DataGrid.DataSource
                Dim dataMember As String = Me.DataGridTableStyle.DataGrid.DataMember
                Dim cm As CurrencyManager = CType(Me.DataGridTableStyle.DataGrid.BindingContext(ds, dataMember), CurrencyManager)
                Dim obj As Object = Me.GetColumnValueAtRow(cm, row)
                If obj Is Nothing OrElse IsDBNull(obj) Then
                    Return False
                End If
                If obj.ToString = "invisible" Then
                    Return True
                End If
            Catch ex As Exception
                Return True
            End Try
        End Function
        Private Function IsInvisible(ByVal hti As DataGrid.HitTestInfo) As Boolean
            Try
                Dim ds As Object = Me.DataGridTableStyle.DataGrid.DataSource
                Dim dataMember As String = Me.DataGridTableStyle.DataGrid.DataMember
                Dim cm As CurrencyManager = CType(Me.DataGridTableStyle.DataGrid.BindingContext(ds, dataMember), CurrencyManager)
                Dim obj As Object = Me.GetColumnValueAtRow(cm, hti.Row)
                If obj Is Nothing OrElse IsDBNull(obj) Then
                    Return False
                End If
                If obj.ToString = "invisible" Then
                    Return True
                End If
            Catch ex As Exception
                Return True
            End Try
        End Function
#End Region

#Region "Constructors"
        Public Sub New()
            m_buttonColor = Color.Khaki
            Me.ControlSize = New Size(16, 16)
            Me.Padding.SetPadding(0, 0, 0, 0)
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width
        End Sub
#End Region

#Region "Button Drawing"
        Private Sub DrawButton(ByVal g As Graphics, ByVal baseRect As RectangleF, ByVal pushed As Boolean)
            Dim outline As New GraphicsPath
            outline = GetRoundedRect(baseRect, 3)

            Dim baseColor As Color
            Dim topColor As Color
            If Not pushed Then
                baseColor = SystemColors.ControlDark
                topColor = SystemColors.Control
            Else
                baseColor = SystemColors.ControlDarkDark
                topColor = SystemColors.ControlDark
            End If
            Dim rect As New RectangleF(baseRect.X, baseRect.Y, baseRect.Width, baseRect.Height + 15)
            g.FillRectangle(New LinearGradientBrush(rect, Color.White, baseColor, LinearGradientMode.Vertical), baseRect)

            Dim rect2 As New RectangleF(baseRect.X, baseRect.Y, baseRect.Width, baseRect.Height - 2)
            Dim b As New LinearGradientBrush(rect2, Color.White, topColor, LinearGradientMode.Vertical)
            g.FillRectangle(b, rect2)

            Dim p As New Pen(Color.Black, 1)
            p.DashStyle = DashStyle.Solid

            g.SmoothingMode = SmoothingMode.HighQuality
            g.DrawPath(p, outline)
            p.Dispose()
        End Sub
        Private Function GetRoundedRect(ByVal baseRect As RectangleF, ByVal radius As Single) As GraphicsPath
            ' if corner radius is less than or equal to zero, 
            ' return the original rectangle 
            If radius <= 0.0F Then
                Dim mPath As New GraphicsPath
                mPath.AddRectangle(baseRect)
                mPath.CloseFigure()
                Return mPath
            End If

            ' if the corner radius is greater than or equal to 
            ' half the width, or height (whichever is shorter) 
            ' then return a capsule instead of a lozenge 
            If radius >= Math.Min(baseRect.Width, baseRect.Height) / 2.0 Then
                Return GetCapsule(baseRect)
            End If
            ' create the arc for the rectangle sides and declare 
            ' a graphics path object for the drawing 
            Dim diameter As Single = radius * 2.0F
            Dim sizeF As New sizeF(diameter, diameter)
            Dim arc As New RectangleF(baseRect.Location, sizeF)
            Dim path As New System.Drawing.Drawing2D.GraphicsPath

            ' top left arc 
            path.AddArc(arc, 180, 90)

            ' top right arc 
            arc.X = baseRect.Right - diameter
            path.AddArc(arc, 270, 90)

            ' bottom right arc 
            arc.Y = baseRect.Bottom - diameter
            path.AddArc(arc, 0, 90)

            ' bottom left arc
            arc.X = baseRect.Left
            path.AddArc(arc, 90, 90)

            path.CloseFigure()
            Return path
        End Function
        Private Function GetCapsule(ByVal baseRect As RectangleF) As GraphicsPath
            Dim diameter As Single
            Dim arc As RectangleF
            Dim path As New System.Drawing.Drawing2D.GraphicsPath
            Try
                If baseRect.Width > baseRect.Height Then
                    ' return horizontal capsule 
                    diameter = baseRect.Height
                    Dim sizeF As New SizeF(diameter, diameter)
                    arc = New RectangleF(baseRect.Location, sizeF)
                    path.AddArc(arc, 90, 180)
                    arc.X = baseRect.Right - diameter
                    path.AddArc(arc, 270, 180)
                Else
                    If baseRect.Width < baseRect.Height Then
                        ' return vertical capsule 
                        diameter = baseRect.Width
                        Dim sizeF As New SizeF(diameter, diameter)
                        arc = New RectangleF(baseRect.Location, sizeF)
                        path.AddArc(arc, 180, 180)
                        arc.Y = baseRect.Bottom - diameter
                        path.AddArc(arc, 0, 180)
                    Else
                        ' return circle 
                        path.AddEllipse(baseRect)
                    End If
                End If
            Catch ex As Exception
                path.AddEllipse(baseRect)
            Finally
                path.CloseFigure()
            End Try
            Return path
        End Function
#End Region

#Region "Overrides"
        Public Overrides Sub RemoveHandlers()
            ' unsubscribe to DataGrid events
            If Me.DataGridTableStyle Is Nothing Then
                Return
            End If
            If Me.DataGridTableStyle.DataGrid Is Nothing Then
                Return
            End If
            RemoveHandler Me.DataGridTableStyle.DataGrid.MouseDown, AddressOf DataGrid_MouseDown
            RemoveHandler Me.DataGridTableStyle.DataGrid.MouseUp, AddressOf DataGrid_MouseUp
        End Sub
        Protected Overrides Sub SetDataGridInColumn(ByVal value As DataGrid)
            If value Is Nothing OrElse Not TypeOf value Is TreeGrid Then
                Return
            End If
            Dim grid As TreeGrid = CType(value, TreeGrid)
            If grid.ColorList.Count > 0 Then
                Me.ColorList = grid.ColorList
            Else
                Me.ColorList = grid.GetDefaultColorList
            End If
            ForeColorList = New ColorCollection            For Each col As Color In ColorList                If CInt(col.R) + CInt(col.G) + CInt(col.B) > 128 * 3 Then
                    ForeColorList.Add(Color.Black)
                Else
                    ForeColorList.Add(Color.White)
                End If
            Next
            MyBase.SetDataGridInColumn(value)

            ' unsubscribe to DataGrid events
            RemoveHandler Me.DataGridTableStyle.DataGrid.MouseDown, AddressOf DataGrid_MouseDown
            RemoveHandler Me.DataGridTableStyle.DataGrid.MouseUp, AddressOf DataGrid_MouseUp

            ' subscribe to DataGrid events
            AddHandler Me.DataGridTableStyle.DataGrid.MouseDown, AddressOf DataGrid_MouseDown
            AddHandler Me.DataGridTableStyle.DataGrid.MouseUp, AddressOf DataGrid_MouseUp
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)

            Dim myFont As Font = Me.DataGridTableStyle.DataGrid.Font
            If TypeOf Me.DataGridTableStyle.DataGrid.DataSource Is TreeTable Then
                If rowNum < CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable).Rows.Count Then
                    PrePareRow(g, rowNum, source, backBrush, foreBrush, myFont)
                End If
            End If

            g.FillRectangle(backBrush, bounds)

            Dim valueObj As Object
            If Not Me.PropertyDescriptor Is Nothing Then
                Try
                    valueObj = Me.GetColumnValueAtRow([source], rowNum)
                Catch ex As Exception
                    valueObj = ""
                End Try
            Else
                valueObj = ""
            End If
            'Try
            '    valueObj = Me.GetColumnValueAtRow([source], rowNum)
            'Catch ex As Exception
            '    valueObj = ""
            '    'MessageBox.Show("Drawing Error")
            'End Try

            If Not valueObj Is Nothing AndAlso Not IsDBNull(valueObj) Then
                If valueObj.ToString = "invisible" Then
                    Return
                End If
            End If


            Dim controlBounds As Rectangle = Me.GetControlBounds(bounds)
            Dim drawFocusRectangle As Boolean = True

            Dim focusBounds As Rectangle = controlBounds
            focusBounds.Inflate(-4, -4)

            Dim fontBoundsF As New System.Drawing.RectangleF( _
                CType(bounds.X, Single), _
                CType(bounds.Y, Single), _
                CType(bounds.Width, Single), _
                CType(bounds.Height, Single))

            fontBoundsF.Inflate(-3, -3)

            Dim bs As ButtonState = ButtonState.Inactive

            If Not m_depressedBounds.Equals(Rectangle.Empty) And m_depressedBounds.Equals(bounds) Then
                bs = ButtonState.Pushed
            Else
                drawFocusRectangle = False
            End If
            Dim focusRectangle As Rectangle = controlBounds
            focusRectangle.Inflate(-2, -2)
            ControlPaint.DrawButton(g, controlBounds, bs)
            g.FillRectangle(New SolidBrush(m_buttonColor), focusRectangle)
            'Dim recF As RectangleF = RectangleF.op_Implicit(controlBounds)
            'recF.Inflate(-1, -1)
            'DrawButton(g, recF, bs = ButtonState.Pushed)
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft Or StringFormatFlags.FitBlackBox
            g.DrawString(valueObj.ToString(), Me.DataGridTableStyle.DataGrid.Font, foreBrush, fontBoundsF, sf)
            If drawFocusRectangle Then
                ControlPaint.DrawFocusRectangle(g, focusRectangle, Color.Red, Control.DefaultBackColor)
            End If
        End Sub
        Protected Sub PrePareRow(ByVal g As Graphics, ByVal rowNum As Integer, ByVal source As CurrencyManager, ByRef backBrush As Brush, ByRef foreBrush As Brush, ByRef myFont As Font)
            Dim row As TreeRow = CType(CType(Me.DataGridTableStyle.DataGrid.DataSource, DataTable).Rows(rowNum), TreeRow)
            Dim table As TreeTable = CType(Me.DataGridTableStyle.DataGrid.DataSource, TreeTable)
            Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
            Dim state As RowExpandState = row.State
            Dim level As Integer = row.Level
            If source.Position = rowNum Then 'selected
                backBrush = New SolidBrush(dg.SelectionBackColor)
                foreBrush = New SolidBrush(dg.SelectionForeColor)
			ElseIf row.State = RowExpandState.None And row.FixLevel >= 0 Then
				backBrush = New SolidBrush(CType(ColorList((level Mod ColorList.Count)), Color))
				foreBrush = New SolidBrush(CType(ForeColorList((level Mod ColorList.Count)), Color))
			ElseIf row.State = RowExpandState.None Then
				'backBrush = New SolidBrush(dg.BackColor)
				'foreBrush = New SolidBrush(dg.ForeColor)
			Else
				backBrush = New SolidBrush(CType(ColorList((level Mod ColorList.Count)), Color))
				foreBrush = New SolidBrush(CType(ForeColorList((level Mod ColorList.Count)), Color))
			End If

			If row.State <> RowExpandState.None Then
				myFont = New Font("Tahoma", 8, FontStyle.Bold)
			Else
				myFont = dg.Font
			End If

			If Not (row.CustomBackColor.IsEmpty) Then
				backBrush = New SolidBrush(row.CustomBackColor)
			End If
			If Not (row.CustomForeColor.IsEmpty) Then
				foreBrush = New SolidBrush(row.CustomForeColor)
			End If
			If Not (row.CustomFontStyle = Nothing) Then
				myFont = New Font(myFont, row.CustomFontStyle)
			End If

        End Sub
#End Region

#Region "Event Handlers"
        Private Sub DataGrid_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim hti As DataGrid.HitTestInfo = Me.DataGridTableStyle.DataGrid.HitTest(e.X, e.Y)
            If e.Button = MouseButtons.Left And hti.Type = DataGrid.HitTestType.Cell AndAlso TypeOf Me.DataGridTableStyle.GridColumnStyles(hti.Column) Is DataGridButtonColumn Then
                Dim cursorRect As New Rectangle(e.X, e.Y, 1, 1)
                Dim cellBounds As Rectangle = Me.DataGridTableStyle.DataGrid.GetCellBounds(hti.Row, hti.Column)
                Dim buttonBounds As Rectangle = Me.GetControlBounds(cellBounds)
                If cursorRect.IntersectsWith(buttonBounds) Then
                    If Me.ReadOnly Then
                        Return
                    End If
                    If IsInvisible(hti.Row) Then
                        Return
                    End If
                    m_depressedBounds = cellBounds
                    Me.DataGridTableStyle.DataGrid.Invalidate(cellBounds)
                End If
            End If
        End Sub
        Private Sub DataGrid_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim hti As DataGrid.HitTestInfo = Me.DataGridTableStyle.DataGrid.HitTest(e.X, e.Y)
            Dim cursorRect As New Rectangle(e.X, e.Y, 1, 1)
            If Not m_depressedBounds.Equals(Rectangle.Empty) Then
                Dim cellBounds As Rectangle = Me.DataGridTableStyle.DataGrid.GetCellBounds(hti.Row, hti.Column)
                If m_depressedBounds.Equals(cellBounds) Then
                    If Me.ReadOnly Then
                        Return
                    End If
                    If IsInvisible(hti.Row) Then
                        Return
                    End If
                    Dim buttonBounds As Rectangle = Me.GetControlBounds(cellBounds)
                    If cursorRect.IntersectsWith(buttonBounds) Then
                        RaiseEvent Click(New ButtonColumnEventArgs(hti.Row, hti.Column, Nothing))
                    End If
                End If
                m_depressedBounds = Rectangle.Empty
                Me.DataGridTableStyle.DataGrid.Invalidate(cellBounds)
            End If
        End Sub
#End Region

    End Class

    Public Class DataGridBarrierColumn
        Inherits PJMColumnStyle

#Region "Members"
        Private m_backColor As Color
#End Region

#Region "Constructors"
        Public Sub New()
            Me.ControlSize = New Size(5, 5)
            Me.Padding.SetPadding(0, 0, 0, 0)
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width
        End Sub
#End Region

#Region "Properties"
        Public Property BackColor() As Color            Get                Return m_backColor            End Get            Set(ByVal Value As Color)                m_backColor = Value            End Set        End Property
#End Region

#Region "Overrides"
        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            Dim b As New SolidBrush(Me.m_backColor)
            g.FillRectangle(b, bounds)
            b.Dispose()
        End Sub
        Protected Overrides Sub SetDataGridInColumn(ByVal value As System.Windows.Forms.DataGrid)
            MyBase.SetDataGridInColumn(value)
            If m_backColor.Equals(Color.Empty) Then
                m_backColor = Me.DataGridTableStyle.GridLineColor
            End If
        End Sub
#End Region

    End Class
End Namespace

