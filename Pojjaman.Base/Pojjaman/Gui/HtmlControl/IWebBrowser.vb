Imports Longkong.Pojjaman.Gui
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Namespace Longkong.Pojjaman.Gui.HtmlControl
    <Guid("eab22ac1-30c1-11cf-a7eb-0000c05bae0b")> _
    Friend Interface IWebBrowser
        ' Methods
        Sub GetApplication()
        Sub GetContainer()
        Function GetDocument() As <MarshalAs(UnmanagedType.Interface)> IHTMLDocument2
        Sub GetParent()
        Sub GoBack()
        Sub GoForward()
        Sub GoHome()
        Sub GoSearch()
        Sub Navigate(ByVal Url As String, ByRef Flags As Object, ByRef targetFrame As Object, ByRef postData As Object, ByRef headers As Object)
        Sub Refresh()
        Sub Refresh2()
        Sub [Stop]()
    End Interface
End Namespace