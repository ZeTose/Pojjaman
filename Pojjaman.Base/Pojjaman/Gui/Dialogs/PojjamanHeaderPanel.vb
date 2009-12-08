Imports Longkong.Core.Services
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class PojjamanHeaderPanel
        Inherits Panel

#Region "Members"
        Private m_barColor As String = "Pink"
        Private m_title As String = ""
        Private m_info As String = ""
        Private m_resourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.ResizeRedraw = True
            Me.BackColor = Color.White
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
            Dim leftBand As Bitmap = m_resourceService.GetBitmap("PJMBand.Left." & Me.m_barColor)
            Dim rightBand As Bitmap = m_resourceService.GetBitmap("PJMBand.Right." & Me.m_barColor)
            g.DrawImage(leftBand, 0, 0)
            g.DrawImage(rightBand, Me.Width - rightBand.Width, 0)
        End Sub
#End Region

    End Class
End Namespace

