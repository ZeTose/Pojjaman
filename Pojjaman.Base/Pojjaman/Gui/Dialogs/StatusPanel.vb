Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class StatusPanel
        Inherits UserControl

#Region "Members"
        Private m_backGround As Bitmap
        Private m_boldFont As Font
        Private m_normalFont As Font
        Private m_resourceService As ResourceService
        Private m_smallFont As Font
        Private m_wizard As WizardDialog
#End Region

#Region "Constructors"
        Public Sub New(ByVal wizard As WizardDialog)
            Me.m_backGround = Nothing
            Me.m_resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Me.m_smallFont = Me.m_resourceService.LoadFont("Tahoma", 14, GraphicsUnit.World)
            Me.m_normalFont = Me.m_resourceService.LoadFont("Tahoma", 14, GraphicsUnit.World)
            Me.m_boldFont = Me.m_resourceService.LoadFont("Tahoma", 14, FontStyle.Bold, GraphicsUnit.World)
            Me.m_wizard = wizard
            Me.m_backGround = Me.m_resourceService.GetBitmap("Building")
            MyBase.Size = New Size(198, 400)
            MyBase.ResizeRedraw = False
            MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
            MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        End Sub
#End Region

#Region "Methods"
        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            Dim g As Graphics = pe.Graphics
            g.DrawString(Me.m_resourceService.GetString("Pojjaman.Gui.Dialogs.WizardDialog.StepsLabel"), Me.m_smallFont, Brushes.Black, CType(10.0!, Single), CType((24 - Me.m_smallFont.Height), Single))
            g.DrawLine(Pens.Black, 10, 24, CType((MyBase.Width - 10), Integer), 24)
            Dim i As Integer = 0
            Dim j As Integer = 0
            Do While (j < Me.m_wizard.WizardPanels.Count)
                Dim myFont As Font
                If Me.m_wizard.ActivePanelNumber = j Then
                    myFont = Me.m_boldFont
                Else
                    myFont = Me.m_normalFont
                End If
                Dim desc As IDialogPanelDescriptor = CType(Me.m_wizard.WizardPanels.Item(j), IDialogPanelDescriptor)
                g.DrawString(((1 + i) & ". " & desc.Label), myFont, Brushes.Black, CType(10.0!, Single), CType((40 + (i * myFont.Height)), Single))
                i += 1
                j = Me.m_wizard.GetSuccessorNumber(j)
            Loop
        End Sub
        Protected Overrides Sub OnPaintBackground(ByVal pe As PaintEventArgs)
            If (Not Me.m_backGround Is Nothing) Then
                pe.Graphics.DrawImage(Me.m_backGround, 0, 0, MyBase.Width, MyBase.Height)
            End If
        End Sub
#End Region
    End Class
End Namespace

