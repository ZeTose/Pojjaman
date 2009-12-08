Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMTreeView
        Inherits TreeView

#Region "Members"
        Private m_Ticks As Long
        Private m_draggedNode As TreeNode
        Private imlDraggedNode As New ImageList
#End Region

#Region "Overrides"
        Protected Overrides Sub OnDragOver(ByVal e As System.Windows.Forms.DragEventArgs)
            Dim pt As Point = Me.PointToClient(New Point(e.X, e.Y))
            Dim targetNode As TreeNode = Me.GetNodeAt(pt)

            Dim ts As New TimeSpan(Now.Ticks - m_Ticks)
            'Scroll Up
            If pt.Y < Me.ItemHeight Then
                'if within one node of top, scroll quickly
                If Not targetNode.PrevVisibleNode Is Nothing Then
                    targetNode = targetNode.PrevVisibleNode()
                End If
                DragHelper.ImageList_DragShowNolock(False)
                targetNode.EnsureVisible()
                DragHelper.ImageList_DragShowNolock(True)
                m_Ticks = Now.Ticks
            ElseIf pt.Y < (Me.ItemHeight * 2) Then
                'if within two nodes of the top, scroll slowly
                If ts.TotalMilliseconds > 250 Then
                    targetNode = targetNode.PrevVisibleNode
                    If Not targetNode.PrevVisibleNode Is Nothing Then
                        targetNode = targetNode.PrevVisibleNode
                    End If
                    DragHelper.ImageList_DragShowNolock(False)
                    targetNode.EnsureVisible()
                    DragHelper.ImageList_DragShowNolock(True)
                    m_Ticks = Now.Ticks
                End If
            End If

            'Scroll Down
            If pt.Y > Me.ItemHeight Then
                'if within one node of bottom, scroll quickly
                If Not targetNode.NextVisibleNode Is Nothing Then
                    targetNode = targetNode.NextVisibleNode()
                End If
                targetNode.EnsureVisible()
                m_Ticks = Now.Ticks
            ElseIf pt.Y > (Me.ItemHeight * 2) Then
                'if within two nodes of the bottom, scroll slowly
                If ts.TotalMilliseconds > 250 Then
                    targetNode = targetNode.NextVisibleNode
                    If Not targetNode.NextVisibleNode Is Nothing Then
                        targetNode = targetNode.NextVisibleNode
                    End If
                    DragHelper.ImageList_DragShowNolock(False)
                    targetNode.EnsureVisible()
                    DragHelper.ImageList_DragShowNolock(True)
                    m_Ticks = Now.Ticks
                End If
            End If
            MyBase.OnDragOver(e)
        End Sub
        Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
            If Me.SelectedNode Is Nothing Then
                Return
            End If
            If Not Me.SelectedNode.Bounds.Contains(Me.PointToClient(Me.MousePosition)) Then
                Return
            End If
            MyBase.OnDoubleClick(e)
        End Sub


        Protected Overrides Sub OnItemDrag(ByVal e As System.Windows.Forms.ItemDragEventArgs)
            m_draggedNode = CType(e.Item, TreeNode)

            Me.imlDraggedNode.Images.Clear()
            Dim w As Integer = Me.m_draggedNode.Bounds.Width + Me.Indent
            If w > 256 Then w = 256
            Me.imlDraggedNode.ImageSize = New Size(w, Me.m_draggedNode.Bounds.Height)

            Dim bmp As New Bitmap(Me.m_draggedNode.Bounds.Width + Me.Indent, Me.m_draggedNode.Bounds.Height)

            Dim g As Graphics = Graphics.FromImage(bmp)
            Dim imgIndx As Integer = m_draggedNode.ImageIndex
            If imgIndx < 0 Then imgIndx = 0
            g.DrawImage(Me.ImageList.Images(imgIndx), 0, 0)

            g.DrawString(Me.m_draggedNode.Text, _
            Me.Font, _
            New SolidBrush(Me.ForeColor), _
            Me.Indent, 1.0F)

            Me.imlDraggedNode.Images.Add(bmp)

            Dim p As Point = Me.PointToClient(Control.MousePosition)

            Dim dx As Integer = p.X + Me.Indent - Me.m_draggedNode.Bounds.Left
            Dim dy As Integer = p.Y - Me.m_draggedNode.Bounds.Top

            If (DragHelper.ImageList_BeginDrag(Me.imlDraggedNode.Handle, 0, dx, dy)) Then
                Me.DoDragDrop(bmp, DragDropEffects.Move)
                DragHelper.ImageList_EndDrag()
            End If
            MyBase.OnItemDrag(e)
        End Sub
        Protected Overrides Sub OnDragEnter(ByVal e As System.Windows.Forms.DragEventArgs)
            DragHelper.ImageList_DragEnter(Me.Handle, e.X - Me.Left, _
            e.Y - Me.Top)
            MyBase.OnDragEnter(e)
        End Sub

        Protected Overrides Sub OnDragLeave(ByVal e As System.EventArgs)
            DragHelper.ImageList_DragLeave(Me.Handle)
            MyBase.OnDragLeave(e)
        End Sub
#End Region

    End Class

    Public Class DragHelper
        <DllImport("comctl32.dll")> _
        Public Shared Function InitCommonControls() As Boolean
        End Function

        <DllImport("comctl32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function ImageList_BeginDrag( _
        ByVal himlTrack As IntPtr, _
        ByVal iTrack As Integer, _
        ByVal dxHotspot As Integer, _
        ByVal dyHotspot As Integer _
        ) As Boolean
        End Function

        <DllImport("comctl32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function ImageList_DragMove( _
        ByVal x As Integer, _
        ByVal y As Integer _
        ) As Boolean
        End Function

        <DllImport("comctl32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Sub ImageList_EndDrag()
        End Sub

        <DllImport("comctl32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function ImageList_DragEnter( _
        ByVal hwndLock As IntPtr, _
        ByVal x As Integer, _
        ByVal y As Integer _
        ) As Boolean
        End Function

        <DllImport("comctl32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function ImageList_DragLeave( _
        ByVal hwndLock As IntPtr _
        ) As Boolean
        End Function

        <DllImport("comctl32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function ImageList_DragShowNolock( _
        ByVal fShow As Boolean _
        ) As Boolean
        End Function

        Shared Sub New()
            InitCommonControls()
        End Sub
    End Class
    Public Class GroupTreeView
        Inherits TreeView

#Region "Overrides"
        Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
            If Me.SelectedNode Is Nothing Then
                Return
            End If
            If Not Me.SelectedNode.Bounds.Contains(Me.PointToClient(Me.MousePosition)) Then
                Return
            End If
            MyBase.OnDoubleClick(e)
        End Sub
        Protected Overrides Sub DefWndProc(ByRef m As Message)
            If m.Msg = 515 Then    'WM_LBUTTONDBLCLK - &H203
                'Do Nothing
            Else
                MyBase.DefWndProc(m)
            End If
        End Sub
#End Region

    End Class
End Namespace

