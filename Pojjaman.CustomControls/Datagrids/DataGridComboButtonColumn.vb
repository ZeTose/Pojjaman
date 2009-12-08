Imports System
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Longkong.CustomControl

Namespace Longkong.Pojjaman.Gui.Components

    Public Class DataGridComboButtonColumn
        Inherits PJMColumnStyle

        Private m_comboBox As Longkong.CustomControl.BaseComboBox
        Private WithEvents m_button As ImageButton
        Private m_previouslyEditedCellRow As Integer
        Private Const DRAW_COMBO As Boolean = False

        Delegate Sub ButtonColumnClickHandler(ByVal e As ButtonColumnEventArgs)
        Public Event Click As ButtonColumnClickHandler

        Public ReadOnly Property Button() As ImageButton
            Get
                Return m_button
            End Get
        End Property
        Public ReadOnly Property ComboBox() As Longkong.CustomControl.BaseComboBox
            Get
                Return m_comboBox
            End Get
        End Property

        Public Overrides Property ControlSize() As Size
            Get
                Dim csize As New Size(m_button.Width + m_comboBox.Width + 1, m_comboBox.Height)
                Return csize
            End Get
            Set(ByVal Value As Size)
                Dim cbsize As New Size(Value.Width - 1 - m_button.Width, Value.Height)
                m_comboBox.Size = cbsize
            End Set
        End Property

        Public Overrides Property Width() As Integer
            Get
                Return MyBase.Width
            End Get
            Set(ByVal Value As Integer)
                Dim ctsize As New Size(Value - Me.Padding.Left - Me.Padding.Right, Me.ControlSize.Height)
                Me.ControlSize = ctsize
                MyBase.Width = Value
            End Set
        End Property
        Public Property ThemedImage() As Bitmap
            Get
                Return m_button.ThemedImage
            End Get
            Set(ByVal Value As Bitmap)
                If Not (Value Is Nothing) Then
                    m_button.SetImage(Value)
                End If
            End Set
        End Property
        Public Sub New()

            m_comboBox = New Longkong.CustomControl.BaseComboBox

            'm_comboBox.DropDownStyle = ComboBoxStyle.DropDownList
            m_comboBox.Visible = False
            'AddHandler m_comboBox.SizeChanged, AddressOf ComboBox_SizeChanged

            m_button = New ImageButton
            m_button.Width = 24
            m_button.Height -= 3
            m_button.Text = "..."
            m_button.Visible = False

            Dim csize As New Size(m_button.Width + m_comboBox.Width + 1, m_comboBox.Height)
            Me.ControlSize = csize
            Me.Padding.SetPadding(0, 0, 0, 0)
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width

        End Sub


        Protected Overrides Sub Abort(ByVal rowNum As Integer)

            ' reset combobox and button
            m_comboBox.Visible = False
            m_button.Visible = False
        End Sub
        Protected Overrides Sub ConcedeFocus()
            ' Hide the ComboBox and the Button when conceding focus.
            Me.m_comboBox.Visible = False
            Me.m_button.Visible = False
            MyBase.ConcedeFocus()
        End Sub 'ConcedeFocus

        Protected Overloads Overrides Sub Edit(ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal bounds As Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
            ' get cursor coordinates
            Dim p As Point = Me.DataGridTableStyle.DataGrid.PointToClient(Cursor.Position)

            ' get control bounds
            Dim controlBounds As Rectangle = Me.GetControlBounds(bounds)

            ' get cursor bounds
            Dim cursorBounds As New Rectangle(p.X, p.Y, 1, 1)


            m_comboBox.Location = New Point(controlBounds.X, controlBounds.Y)
            m_button.Location = New Point(m_comboBox.Location.X + m_comboBox.Width, controlBounds.Y)
            m_button.Visible = True
            m_comboBox.Visible = True
            'm_comboBox.Focus()
            Dim value As Object = Me.GetColumnValueAtRow([source], rowNum)
            If IsDBNull(value) Then
                m_comboBox.SelectedIndex = -1
            Else
                'm_comboBox.ActiveItem = m_comboBox.ListItems(CStr(value))
                m_comboBox.SelectedIndex = CInt(value)
            End If


            Dim cmbRect As New Rectangle(m_comboBox.Left, m_comboBox.Top, m_comboBox.Width, m_comboBox.Height)
            If cursorBounds.IntersectsWith(cmbRect) Then
                m_comboBox.DroppedDown = True
            End If

            m_previouslyEditedCellRow = rowNum
        End Sub


        Protected Overrides Function Commit(ByVal dataSource As CurrencyManager, ByVal rowNum As Integer) As Boolean

            If m_previouslyEditedCellRow = rowNum Then
                Me.SetColumnValueAtRow(dataSource, rowNum, m_comboBox.SelectedIndex)
            End If

            m_comboBox.Visible = False
            m_button.Visible = False
            Return True
        End Function


        Protected Overrides Sub SetDataGridInColumn(ByVal value As DataGrid)

            MyBase.SetDataGridInColumn(value)

            If Not value.Controls.Contains(m_comboBox) Then
                value.Controls.Add(m_comboBox)
            End If
            If Not value.Controls.Contains(m_button) Then
                value.Controls.Add(m_button)
            End If
        End Sub

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)


            g.FillRectangle(backBrush, bounds)

            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Near
            sf.LineAlignment = StringAlignment.Center

            Dim controlBounds As Rectangle = Me.GetControlBounds(bounds)
            Dim colValue As Integer
            Dim selectedItem As String
            Dim value As Object = Me.GetColumnValueAtRow([source], rowNum)
            If IsDBNull(value) OrElse CInt(value) <= -1 Then
                colValue = -1
                selectedItem = ""
            Else
                colValue = CInt(value)
                selectedItem = m_comboBox.Items(colValue).ToString()
            End If

            Dim textRegionF As New RectangleF(controlBounds.X + 1, controlBounds.Y + 4, controlBounds.Width - 3 - m_button.Width, CInt(g.MeasureString(selectedItem, m_comboBox.Font).Height))

            g.DrawString(selectedItem, m_comboBox.Font, foreBrush, textRegionF)

            If DRAW_COMBO Then
                Dim cmbRect As New Rectangle(controlBounds.X, controlBounds.Y, controlBounds.Width - Me.m_button.Width, controlBounds.Height)
                ControlPaint.DrawBorder3D(g, cmbRect, Border3DStyle.Sunken)
                Dim buttonBounds As Rectangle = cmbRect
                ControlPaint.DrawButton(g, buttonBounds.X + cmbRect.Width, buttonBounds.Y, m_button.Width, m_button.Height, ButtonState.Normal)
                buttonBounds.Inflate(-2, -2)
                ControlPaint.DrawComboButton(g, buttonBounds.X + (cmbRect.Width - 20), buttonBounds.Y, 16, 17, ButtonState.Normal)
            End If

        End Sub

        Private Sub ComboBox_SizeChanged(ByVal sender As Object, ByVal e As EventArgs)

            Me.ControlSize = m_comboBox.Size
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width
            Me.Invalidate()
        End Sub
        Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles m_button.Click
            Dim hti As DataGrid.HitTestInfo = Me.DataGridTableStyle.DataGrid.HitTest(m_button.Location.X + CInt(m_button.Width / 2), m_button.Location.Y + CInt(m_button.Height / 2))
            RaiseEvent Click(New ButtonColumnEventArgs(hti.Row, hti.Column, "..."))
        End Sub
    End Class
End Namespace

