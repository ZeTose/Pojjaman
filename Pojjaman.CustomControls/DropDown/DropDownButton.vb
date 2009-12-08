Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Longkong.Pojjaman.Gui.Components
    Public Class DropDownButton
        Inherits Button

#Region "Members"
        Private m_state As ButtonState
        Private imlComboArrow As System.Windows.Forms.ImageList
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.SetStyle(ControlStyles.UserPaint, True)
            MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
            MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DropDownButton))
            Me.imlComboArrow = New System.Windows.Forms.ImageList
            '
            'imlComboArrow
            '
            Me.imlComboArrow.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
            Me.imlComboArrow.ImageSize = New System.Drawing.Size(15, 17)
            Me.imlComboArrow.ImageStream = CType(resources.GetObject("imlComboArrow.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imlComboArrow.TransparentColor = System.Drawing.Color.Transparent
        End Sub
#End Region

#Region "Methods"
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            Me.m_state = ButtonState.Pushed
            MyBase.OnMouseDown(e)
        End Sub
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            Me.m_state = ButtonState.Normal
            MyBase.OnMouseUp(e)
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            Select Case Me.m_state
                Case ButtonState.Normal
                    e.Graphics.DrawImage(Me.imlComboArrow.Images(0), 1, 1)
                Case ButtonState.Pushed
                    e.Graphics.DrawImage(Me.imlComboArrow.Images(2), 1, 1)
            End Select
            'ControlPaint.DrawComboButton(e.Graphics, 0, 0, MyBase.Width, MyBase.Height, Me.m_state)
        End Sub
#End Region
    End Class

End Namespace

