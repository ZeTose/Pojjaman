Imports Longkong.Core.Services
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class GradientHeaderPanel
        Inherits Label

#Region "Constructors"
        Public Sub New()
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            MyBase.ResizeRedraw = True
            Me.Text = String.Empty
        End Sub
        Public Sub New(ByVal fontSize As Integer)
            Me.New()
            Me.Font = New Font("Tahoma", CType(fontSize, Single))
        End Sub
#End Region

#Region "Methods"
        Protected Overrides Sub OnPaintBackground(ByVal pe As PaintEventArgs)
            MyBase.OnPaintBackground(pe)
            Dim g As Graphics = pe.Graphics
            Dim myBrush As Brush = New LinearGradientBrush(New Point(0, 0), New Point(MyBase.Width, MyBase.Height), SystemColors.Window, SystemColors.Control)
            g.FillRectangle(myBrush, New Rectangle(0, 0, MyBase.Width, MyBase.Height))
            myBrush.Dispose()
            myBrush = Nothing
        End Sub
#End Region

    End Class
End Namespace

