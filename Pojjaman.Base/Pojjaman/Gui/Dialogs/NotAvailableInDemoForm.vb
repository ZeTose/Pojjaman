Imports System.Reflection
Imports Longkong.Core.Services
Imports System.Resources
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class NotAvailableInDemoForm
        Inherits Form

        Private Sub InitializeComponent()
            '
            'NotAvailableInDemoForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(352, 286)
            Me.Name = "NotAvailableInDemoForm"

        End Sub

#Region "Members"
        Private Shared m_notAvailableInDemoForm As NotAvailableInDemoForm
#End Region

#Region "Constructors"
        Shared Sub New()
            m_notAvailableInDemoForm = New NotAvailableInDemoForm
        End Sub
        Public Sub New()
            InitializeComponent()

            MyBase.TopMost = True
            MyBase.FormBorderStyle = FormBorderStyle.FixedDialog
            MyBase.StartPosition = FormStartPosition.CenterScreen
            MyBase.ShowInTaskbar = False
            MyBase.BackColor = Color.White
            Dim splashBitMap As Bitmap
            Try
                Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
                'splashBitMap = myResourceService.GetBitmap("RDScreen") 
                'splashBitMap = New Bitmap([Assembly].GetEntryAssembly.GetManifestResourceStream("NotAvailableInDemo"))
                Dim resources As New ResourceManager("BitmapResources", [Assembly].GetEntryAssembly)
                splashBitMap = CType(resources.GetObject("NotAvailableInDemo"), Bitmap)
                MyBase.Size = splashBitMap.Size
                Me.BackgroundImage = splashBitMap
            Catch ex As Exception
                MessageBox.Show(ex.Message & ":NotAvailableInDemoForm")
            End Try
        End Sub
#End Region

#Region "Properties"
        Public Shared ReadOnly Property NotAvailableInDemoForm() As NotAvailableInDemoForm
            Get
                Return m_notAvailableInDemoForm
            End Get
        End Property
#End Region


    End Class
End Namespace
