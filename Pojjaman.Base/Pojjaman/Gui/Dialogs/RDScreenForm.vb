Imports System.Reflection
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class RDScreenForm
        Inherits Form
        Friend WithEvents btnOK As System.Windows.Forms.Button

        Private Sub InitializeComponent()
            Me.btnOK = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Location = New System.Drawing.Point(272, 256)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.TabIndex = 0
            Me.btnOK.Text = "OK"
            '
            'RDScreenForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(352, 286)
            Me.Controls.Add(Me.btnOK)
            Me.Name = "RDScreenForm"
            Me.ResumeLayout(False)

        End Sub

#Region "Members"
        Private Shared m_rdScreen As RDScreenForm
#End Region

#Region "Constructors"
        Shared Sub New()
            m_rdScreen = New RDScreenForm
        End Sub
        Public Sub New()
            InitializeComponent()

            MyBase.TopMost = True
            MyBase.FormBorderStyle = FormBorderStyle.None
            MyBase.StartPosition = FormStartPosition.CenterScreen
            MyBase.ShowInTaskbar = False
            Dim splashBitMap As Bitmap
            Try
                Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
                splashBitMap = myResourceService.GetBitmap("RDScreen") 'New Bitmap([Assembly].GetEntryAssembly.GetManifestResourceStream("RDScreen"))
                MyBase.Size = splashBitMap.Size
                Me.BackgroundImage = splashBitMap
            Catch ex As Exception
                MessageBox.Show(ex.Message & ":RDScreen")
            End Try
        End Sub
#End Region

#Region "Properties"
        Public Shared ReadOnly Property RDScreen() As RDScreenForm
            Get
                Return m_rdScreen
            End Get
        End Property
#End Region


    End Class
End Namespace
