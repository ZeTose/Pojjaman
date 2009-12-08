Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class CurrentPanelPanel
        Inherits UserControl

#Region "Members"
        Private m_backGround As Bitmap
        Private m_normalFont As Font
        Private m_resourceService As ResourceService
        Private m_wizard As WizardDialog
#End Region

#Region "Constructors"
        Public Sub New(ByVal wizard As WizardDialog)
            Me.m_backGround = Nothing
            Me.m_resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Me.m_normalFont = Me.m_resourceService.LoadFont("SansSerif", 18, GraphicsUnit.World)
            Me.m_wizard = wizard
            'Me.m_backGround = Me.m_resourceService.GetBitmap("PojjamanWizard")
            MyBase.Size = New Size((wizard.Width - 198), 30)
            MyBase.ResizeRedraw = False
            MyBase.SetStyle(ControlStyles.UserPaint, True)
        End Sub
#End Region

#Region "Methds"
        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            Dim g As Graphics = pe.Graphics
            Dim myBrush As Brush = New LinearGradientBrush(New Point(0, 0), New Point(MyBase.Width, MyBase.Height), Color.White, SystemColors.Control)
            g.FillRectangle(myBrush, New Rectangle(0, 0, MyBase.Width, MyBase.Height))
            myBrush.Dispose()
            g.DrawString(CType(Me.m_wizard.WizardPanels.Item(Me.m_wizard.ActivePanelNumber), IDialogPanelDescriptor).Label, Me.m_normalFont, Brushes.Black, 10.0!, CType((24 - Me.m_normalFont.Height), Single), StringFormat.GenericTypographic)
            g.DrawLine(Pens.Black, 10, 24, CType((MyBase.Width - 10), Integer), 24)
        End Sub
#End Region

    End Class
End Namespace

