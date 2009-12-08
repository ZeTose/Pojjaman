Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms


Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMDraggableTreeView
        Inherits PJMTreeView

#Region "Members"
        Private m_showNodeWhileDragging As Boolean = True
        Private m_allowNodeDrag As Boolean = True

        Private m_draggedNode As DraggedTreeNode
#End Region

#Region "Properties"
        Public Property ShowNodeWhileDragging() As Boolean            Get                Return m_showNodeWhileDragging            End Get            Set(ByVal Value As Boolean)                m_showNodeWhileDragging = Value            End Set        End Property        Public Property AllowNodeDrag() As Boolean            Get                Return m_allowNodeDrag            End Get            Set(ByVal Value As Boolean)                m_allowNodeDrag = Value            End Set        End Property
#End Region

#Region "Overrides"
        Private Sub NodeManager(ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim nodeRect As Rectangle = Me.SelectedNode.Bounds
            Dim nodeSize As Size = Size.Empty
            Dim xCoordinate As Integer = nodeRect.X
            Dim yCoordinate As Integer = nodeRect.Y
            Dim startingLocation As Point = New Point(xCoordinate, yCoordinate)
            Dim cursorLocation As Point = New Point(e.X - xCoordinate, e.Y - yCoordinate)
            If ShowNodeWhileDragging Then
                nodeSize = nodeRect.Size
                Dim si As New ScreenImage
                Dim columnImage As Bitmap = CType(si.GetScreenshot(Me.Handle, startingLocation, nodeSize), Bitmap)
                m_draggedNode = New DraggedTreeNode(nodeRect, cursorLocation, columnImage)
            Else
                m_draggedNode = New DraggedTreeNode(nodeRect, cursorLocation)
            End If

            m_draggedNode.CurrentRegion = nodeRect
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            If m_allowNodeDrag AndAlso Not Me.SelectedNode Is Nothing AndAlso _
                   Me.m_draggedNode Is Nothing Then
                NodeManager(e)
            End If
            Me.Update()
        End Sub
        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            Me.Invalidate(Me.ClientRectangle)
            Me.Update()
        End Sub
        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)

            If Not m_draggedNode Is Nothing Then
                Dim g As Graphics = e.Graphics
                Dim x As Integer = m_draggedNode.InitialRegion.X
                Dim y As Integer = m_draggedNode.InitialRegion.Y
                Dim width As Integer = m_draggedNode.InitialRegion.Width
                Dim height As Integer = m_draggedNode.InitialRegion.Height
                Dim region As Rectangle = New Rectangle(x, y, width, height)


                ' Color of border
                Dim blackBrush As SolidBrush = New SolidBrush(Color.FromArgb(255, 0, 0, 0))
                ' Color of the interier of source column
                Dim darkGreyBrush As SolidBrush = New SolidBrush(Color.FromArgb(150, 50, 50, 50))
                ' Draw border around source column
                Dim blackPen As Pen = New Pen(blackBrush, 2.0F)


                g.FillRectangle(darkGreyBrush, m_draggedNode.InitialRegion)
                g.DrawRectangle(blackPen, region)

                blackBrush.Dispose()
                darkGreyBrush.Dispose()
                blackPen.Dispose()

                ' draw bitmap image
                If ShowNodeWhileDragging Then
                    g.DrawImage(m_draggedNode.ColumnImage, m_draggedNode.CurrentRegion.X, m_draggedNode.CurrentRegion.Y)
                End If

                ' translucent file
                Dim filmBorder As Pen = New Pen(New SolidBrush(Color.FromArgb(255, 200, 200, 230)), 2.0F)
                Dim filmFill As SolidBrush = New SolidBrush(Color.FromArgb(100, 200, 200, 255))

                g.FillRectangle(filmFill, m_draggedNode.CurrentRegion.X, m_draggedNode.CurrentRegion.Y, m_draggedNode.CurrentRegion.Width, m_draggedNode.CurrentRegion.Height)
                g.DrawRectangle(filmBorder, New Rectangle(m_draggedNode.CurrentRegion.X, m_draggedNode.CurrentRegion.Y + Convert.ToInt16(filmBorder.Width), width, height))

                filmBorder.Dispose()
                filmFill.Dispose()

            End If
        End Sub
#End Region

    End Class
End Namespace

