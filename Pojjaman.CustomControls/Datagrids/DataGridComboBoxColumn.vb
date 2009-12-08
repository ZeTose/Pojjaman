Imports System
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Longkong.CustomControl

Namespace Longkong.Pojjaman.Gui.Components

    Public Class DataGridComboBoxColumn
        Inherits PJMColumnStyle

        Private m_comboBox As ComboBox
        Private m_previouslyEditedCellRow As Integer
        Private Const DRAW_COMBO As Boolean = False


        Public ReadOnly Property ComboBox() As ComboBox
            Get
                Return m_comboBox
            End Get
        End Property

        Public Overrides Property ControlSize() As Size
            Get
                Return m_comboBox.Size
            End Get
            Set(ByVal Value As Size)
                m_comboBox.Size = Value
            End Set
        End Property

        Public Sub New()

            m_comboBox = New ComboBox

            m_comboBox.DropDownStyle = ComboBoxStyle.DropDownList
            m_comboBox.Visible = False
            AddHandler m_comboBox.SizeChanged, AddressOf ComboBox_SizeChanged

            Me.ControlSize = m_comboBox.Size
            Me.Padding.SetPadding(0, 0, 0, 0)
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width

        End Sub


        Protected Overrides Sub Abort(ByVal rowNum As Integer)

            ' reset combobox
            m_comboBox.Visible = False
        End Sub


        Protected Overloads Overrides Sub Edit(ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal bounds As Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

            ' get cursor coordinates
            Dim p As Point = Me.DataGridTableStyle.DataGrid.PointToClient(Cursor.Position)

            ' get control bounds
            Dim controlBounds As Rectangle = Me.GetControlBounds(bounds)

            ' get cursor bounds
            Dim cursorBounds As New Rectangle(p.X, p.Y, 1, 1)
            Dim value As Object = Me.GetColumnValueAtRow([source], rowNum)
            If IsDBNull(value) Then
                m_comboBox.SelectedIndex = -1
            Else
                m_comboBox.SelectedIndex = CInt(value)

            End If

            m_comboBox.Location = New Point(controlBounds.X, controlBounds.Y)
            m_comboBox.Visible = True

            If cursorBounds.IntersectsWith(controlBounds) Then
                m_comboBox.DroppedDown = True
            End If

            m_previouslyEditedCellRow = rowNum
        End Sub


        Protected Overrides Function Commit(ByVal dataSource As CurrencyManager, ByVal rowNum As Integer) As Boolean

            If m_previouslyEditedCellRow = rowNum Then
                Me.SetColumnValueAtRow(dataSource, rowNum, m_comboBox.SelectedIndex)
            End If

            m_comboBox.Visible = False

            Return True
        End Function


        Protected Overrides Sub SetDataGridInColumn(ByVal value As DataGrid)

            MyBase.SetDataGridInColumn(value)

            If Not value.Controls.Contains(m_comboBox) Then
                value.Controls.Add(m_comboBox)
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
            If IsDBNull(Me.GetColumnValueAtRow([source], rowNum)) Then
                colValue = -1
                selectedItem = ""
            Else
                colValue = CInt(Me.GetColumnValueAtRow([source], rowNum))
                selectedItem = m_comboBox.Items(colValue).ToString()
            End If

            Dim textRegionF As New RectangleF(controlBounds.X + 1, controlBounds.Y + 4, controlBounds.Width - 3, CInt(g.MeasureString(selectedItem, m_comboBox.Font).Height))

            g.DrawString(selectedItem, m_comboBox.Font, foreBrush, textRegionF)

            If DRAW_COMBO Then
                ControlPaint.DrawBorder3D(g, controlBounds, Border3DStyle.Sunken)

                Dim buttonBounds As Rectangle = controlBounds
                buttonBounds.Inflate(-2, -2)
                ControlPaint.DrawComboButton(g, buttonBounds.X + (controlBounds.Width - 20), buttonBounds.Y, 16, 17, ButtonState.Normal)
            End If

        End Sub

        Private Sub ComboBox_SizeChanged(ByVal sender As Object, ByVal e As EventArgs)

            Me.ControlSize = m_comboBox.Size
            Me.Width = Me.GetPreferredSize(Nothing, Nothing).Width
            Me.Invalidate()
        End Sub
    End Class
End Namespace
