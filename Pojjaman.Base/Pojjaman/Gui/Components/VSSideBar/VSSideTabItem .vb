Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.Pojjaman.Gui.Components
    Public Class VSSideTabItem

#Region "Members"
        Private m_icon As Bitmap
        Private m_name As String
        Private m_sideTabItemStatus As SideTabItemStatus
        Private m_tag As Object
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String)
            Dim indx As Integer = name.IndexOf(ChrW(10))
            If (indx > 0) Then
                Me.m_name = name.Substring(0, indx)
            Else
                Me.m_name = name
            End If
        End Sub
        Public Sub New(ByVal name As String, ByVal tag As Object)
            Me.New(name)
            Me.m_tag = tag
        End Sub
        Public Sub New(ByVal name As String, ByVal tag As Object, ByVal icon As Bitmap)
            Me.New(name, tag)
            Me.m_icon = New Bitmap(icon)
        End Sub
#End Region

#Region "Properties"
        Public Property Icon() As Bitmap
            Get
                Return Me.m_icon
            End Get
            Set(ByVal value As Bitmap)
                Me.m_icon = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return Me.m_name
            End Get
            Set(ByVal value As String)
                Me.m_name = value
            End Set
        End Property
        Public Property SideTabItemStatus() As SideTabItemStatus
            Get
                Return Me.m_sideTabItemStatus
            End Get
            Set(ByVal value As SideTabItemStatus)
                Me.m_sideTabItemStatus = value
            End Set
        End Property
        Public Property Tag() As Object
            Get
                Return Me.m_tag
            End Get
            Set(ByVal value As Object)
                Me.m_tag = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function Clone() As VSSideTabItem
            Return CType(MyBase.MemberwiseClone, VSSideTabItem)
        End Function
        Public Overridable Sub DrawItem(ByVal g As Graphics, ByVal f As Font, ByVal rectangle As Rectangle)
            Dim iconWidth As Integer = 0
            Select Case Me.m_sideTabItemStatus
                Case SideTabItemStatus.Normal
                    If (Not Me.Icon Is Nothing) Then
                        g.DrawImage(Me.Icon, 0, rectangle.Y)
                        iconWidth = Me.Icon.Width
                    End If
                    g.DrawString(Me.m_name, f, SystemBrushes.ControlText, New PointF(CType(((rectangle.X + iconWidth) + 1), Single), CType((rectangle.Y + 1), Single)))
                    Return
                Case SideTabItemStatus.Selected
                    ControlPaint.DrawBorder3D(g, rectangle, Border3DStyle.RaisedInner)
                    If (Not Me.Icon Is Nothing) Then
                        g.DrawImage(Me.Icon, 0, rectangle.Y)
                        iconWidth = Me.Icon.Width
                    End If
                    g.DrawString(Me.m_name, f, SystemBrushes.ControlText, New PointF(CType(((rectangle.X + iconWidth) + 1), Single), CType((rectangle.Y + 1), Single)))
                    Return
                Case SideTabItemStatus.Choosed
                    ControlPaint.DrawBorder3D(g, rectangle, Border3DStyle.Sunken)
                    rectangle.X += 1
                    rectangle.Y += 1
                    rectangle.Width = (rectangle.Width - 2)
                    rectangle.Height = (rectangle.Height - 2)
                    Dim myBrush As Brush = New SolidBrush(ControlPaint.Light(SystemColors.Control))
                    g.FillRectangle(myBrush, rectangle)
                    myBrush.Dispose()
                    If (Not Me.Icon Is Nothing) Then
                        g.DrawImage(Me.Icon, 1, CType((rectangle.Y + 1), Integer))
                        iconWidth = Me.Icon.Width
                    End If
                    g.DrawString(Me.m_name, f, SystemBrushes.ControlText, New PointF(CType(((rectangle.X + iconWidth) + 2), Single), CType((rectangle.Y + 2), Single)))
                    Return
                Case SideTabItemStatus.Drag
                    ControlPaint.DrawBorder3D(g, rectangle, Border3DStyle.RaisedInner)
                    rectangle.X += 1
                    rectangle.Y += 1
                    rectangle.Width = (rectangle.Width - 2)
                    rectangle.Height = (rectangle.Height - 2)
                    g.FillRectangle(SystemBrushes.ControlDarkDark, rectangle)
                    If (Not Me.Icon Is Nothing) Then
                        g.DrawImage(Me.Icon, 0, rectangle.Y)
                        iconWidth = Me.Icon.Width
                    End If
                    g.DrawString(Me.m_name, f, SystemBrushes.HighlightText, New PointF(CType(((rectangle.X + iconWidth) + 1), Single), CType((rectangle.Y + 1), Single)))
                    Return
            End Select
        End Sub
#End Region

    End Class
    Public Enum SideTabItemStatus
        Normal
        Selected
        Choosed
        Drag
    End Enum
End Namespace