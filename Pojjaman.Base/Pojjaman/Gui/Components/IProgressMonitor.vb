Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui
    Public Interface IProgressMonitor
        ' Methods
        Sub BeginTask(ByVal name As String, ByVal totalWork As Integer)
        Sub Done()
        Sub Worked(ByVal work As Integer)

        ' Properties
        Property Canceled() As Boolean
        Property TaskName() As String
    End Interface
End Namespace



