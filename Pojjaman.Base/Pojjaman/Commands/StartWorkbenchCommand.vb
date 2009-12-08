Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports System.IO
Namespace Longkong.Pojjaman.Commands
    Public Class StartWorkbenchCommand
        Inherits AbstractCommand

#Region "Members"
        Private m_isCalled As Boolean
        Private Const m_workbenchMemento As String = "Pojjaman.Workbench.WorkbenchMemento"
        Private idleEventHandler As EventHandler
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_isCalled = False
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim workBenchForm As Form = CType(WorkbenchSingleton.Workbench, Form)
            workBenchForm.Show()
            Me.idleEventHandler = New EventHandler(AddressOf Me.ShowTipOfTheDay)
            AddHandler Application.Idle, Me.idleEventHandler
            Dim noLoadPrev As Boolean = False
            Dim textArray1 As String() = SplashScreenForm.GetRequestedFileList
            If (Not noLoadPrev AndAlso myPropertyService.GetProperty("SharpDevelop.LoadPrevProjectOnStartup", False)) Then
                Dim obj1 As Object = myPropertyService.GetProperty("Longkong.Pojjaman.Gui.MainWindow.RecentOpen")
                If TypeOf obj1 Is RecentOpen Then
                    Dim open1 As RecentOpen = CType(obj1, RecentOpen)
                    If (open1.RecentProject.Count > 0) Then
                        'service3.OpenCombine(open1.RecentProject.Item(0).ToString)
                    End If
                End If
            End If
            workBenchForm.Focus()
            Application.AddMessageFilter(New FormKeyHandler)
            Application.Run(workBenchForm)
            Try
                myPropertyService.SetProperty("Pojjaman.Workbench.WorkbenchMemento", WorkbenchSingleton.Workbench.CreateMemento)
            Catch ex As Exception
                Console.WriteLine(("Exception while saving workbench state: " & ex.ToString))
            End Try
        End Sub
        Private Sub ShowTipOfTheDay(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_isCalled Then
                RemoveHandler Application.Idle, Me.idleEventHandler
            Else
                Me.m_isCalled = True
                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
                If myPropertyService.GetProperty("Longkong.Pojjaman.Gui.Dialog.TipOfTheDayView.ShowTipsAtStartup", True) Then
                    Dim myViewTipOfTheDay As New ViewTipOfTheDay
                    myViewTipOfTheDay.Run()
                End If
            End If
        End Sub
#End Region

#Region "FormKeyHandler Class"
        Private Class FormKeyHandler
            Implements IMessageFilter

#Region "Members"
            Private Const keyPressedMessage As Integer = 256
#End Region

#Region "Constructors"
            Public Sub New()
            End Sub
#End Region

#Region "IMessageFilter"
            Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
                If (m.Msg = keyPressedMessage) Then
                    Dim keys As keys = (CType(m.WParam.ToInt32, keys) Or Control.ModifierKeys)
                    If (((keys = keys.Escape) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent.Control.ContainsFocus AndAlso (Form.ActiveForm Is CType(WorkbenchSingleton.Workbench, Form)))) Then
                        WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent.Control.Focus()
                        Return True
                    End If
                End If
                Return False
            End Function
#End Region

        End Class
#End Region

    End Class
End Namespace
