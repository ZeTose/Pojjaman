Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class SplashScreenForm
        Inherits Form

#Region "Members"
        Private Shared m_parameterList As ArrayList
        Private Shared m_requestedFileList As ArrayList
        Private Shared m_splashScreen As SplashScreenForm
#End Region

#Region "Constructors"
        Shared Sub New()
            SplashScreenForm.m_splashScreen = New SplashScreenForm
            SplashScreenForm.m_requestedFileList = New ArrayList
            SplashScreenForm.m_parameterList = New ArrayList
        End Sub
        Public Sub New()
            MyBase.TopMost = True
            MyBase.FormBorderStyle = FormBorderStyle.None
            MyBase.StartPosition = FormStartPosition.CenterScreen
            MyBase.ShowInTaskbar = False
            Dim splashBitMap As Image
            Try
                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                Dim thePath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "resources" & Path.DirectorySeparatorChar & "SplashScreen.png")
                splashBitMap = Bitmap.FromFile(thePath) 'New Bitmap([Assembly].GetEntryAssembly.GetManifestResourceStream("SplashScreen.png"))
                MyBase.Size = splashBitMap.Size
                Me.BackgroundImage = splashBitMap
            Catch ex As Exception
                MessageBox.Show(ex.Message & ":SplashScreen")
            End Try
        End Sub
#End Region

#Region "Properties"
        Public Shared ReadOnly Property SplashScreen() As SplashScreenForm
            Get
                Return SplashScreenForm.m_splashScreen
            End Get
        End Property
#End Region

#Region "Methods"
        Public Shared Function GetParameterList() As String()
            Return SplashScreenForm.GetStringArray(SplashScreenForm.m_parameterList)
        End Function
        Public Shared Function GetRequestedFileList() As String()
            Return SplashScreenForm.GetStringArray(SplashScreenForm.m_requestedFileList)
        End Function
        Private Shared Function GetStringArray(ByVal list As ArrayList) As String()
            Return CType(list.ToArray(GetType(String)), String())
        End Function
        Public Shared Sub SetCommandLineArgs(ByVal args As String())
            SplashScreenForm.m_requestedFileList.Clear()
            SplashScreenForm.m_parameterList.Clear()
            For i As Integer = 0 To args.Length - 1
                Dim arg As String = args(i)
                If ((arg.Chars(0) = "-"c) OrElse (arg.Chars(0) = "/"c)) Then
                    Dim j As Integer = 1
                    If (((arg.Length >= 2) AndAlso (arg.Chars(0) = "-"c)) AndAlso (arg.Chars(1) = "-"c)) Then
                        j = 2
                    End If
                    SplashScreenForm.m_parameterList.Add(arg.Substring(j))
                Else
                    SplashScreenForm.m_requestedFileList.Add(arg)
                End If
            Next
        End Sub
#End Region

    End Class
End Namespace
