Imports Longkong.Pojjaman.Gui
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Namespace Longkong.Pojjaman.Gui.HtmlControl
    <InterfaceType(ComInterfaceType.InterfaceIsIDispatch), Guid("eab22ac2-30c1-11cf-a7eb-0000c05bae0b")> _
    Public Interface IWebBrowserEvents
        ' Methods
        <DispId(100)> _
        Sub RaiseBeforeNavigate(ByVal url As String, ByVal flags As Integer, ByVal targetFrameName As String, ByRef postData As Object, ByVal headers As String, ByRef cancel As Boolean)
        <DispId(101)> _
        Sub RaiseNavigateComplete(ByVal url As String)
    End Interface
End Namespace