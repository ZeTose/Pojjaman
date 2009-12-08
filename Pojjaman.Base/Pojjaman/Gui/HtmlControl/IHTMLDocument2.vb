Imports Longkong.Pojjaman.Gui
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Namespace Longkong.Pojjaman.Gui.HtmlControl
    <InterfaceType(ComInterfaceType.InterfaceIsDual), ComVisible(True), Guid("332C4425-26CB-11D0-B483-00C04FD90119")> _
    Friend Interface IHTMLDocument2
        ' Methods
        Sub Clear()
        Sub Close()
        Function CreateElement(ByVal eTag As String) As <MarshalAs(UnmanagedType.Interface)> Object
        Function CreateStyleSheet(ByVal bstrHref As String, ByVal lIndex As Integer) As <MarshalAs(UnmanagedType.Interface)> Object
        Sub DummyWrite(ByVal psarray As Integer)
        Sub DummyWriteln(ByVal psarray As Integer)
        Function ElementFromPoint(ByVal x As Integer, ByVal y As Integer) As <MarshalAs(UnmanagedType.Interface)> Object
        Function ExecCommand(ByVal cmdID As String, ByVal showUI As Boolean, ByVal value As Object) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Function ExecCommandShowHelp(ByVal cmdID As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Function GetActiveElement() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetAlinkColor() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetAll() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetAnchors() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetApplets() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetBgColor() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetBody() As <MarshalAs(UnmanagedType.Interface)> IHTMLElement
        Function GetCharset() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetCookie() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetDefaultCharset() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetDesignMode() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetDomain() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetEmbeds() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetExpando() As <MarshalAs(UnmanagedType.Bool)> Boolean
        Function GetFgColor() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetFileCreatedDate() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetFileModifiedDate() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetFileSize() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetFileUpdatedDate() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetForms() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetFrames() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetImages() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetLastModified() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetLinkColor() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetLinks() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetLocation() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetMimeType() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetNameProp() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetOnafterupdate() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnbeforeupdate() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnclick() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOndblclick() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOndragstart() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnerrorupdate() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnhelp() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnkeydown() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnkeypress() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnkeyup() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmousedown() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmousemove() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmouseout() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmouseover() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmouseup() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnreadystatechange() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnrowenter() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnrowexit() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnselectstart() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetParentWindow() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetPlugins() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetProtocol() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetReadyState() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetReferrer() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetScript() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetScripts() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetSecurity() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetSelection() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetStyleSheets() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetTitle() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetURL() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetVlinkColor() As <MarshalAs(UnmanagedType.Struct)> Object
        Function Open(ByVal URL As String, ByVal name As Object, ByVal features As Object, ByVal replace As Object) As <MarshalAs(UnmanagedType.Interface)> Object
        Function QueryCommandEnabled(ByVal cmdID As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Function QueryCommandIndeterm(ByVal cmdID As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Function QueryCommandState(ByVal cmdID As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Function QueryCommandSupported(ByVal cmdID As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Function QueryCommandText(ByVal cmdID As String) As <MarshalAs(UnmanagedType.BStr)> String
        Function QueryCommandValue(ByVal cmdID As String) As <MarshalAs(UnmanagedType.Struct)> Object
        Sub SetAlinkColor(ByVal p As Object)
        Sub SetBgColor(ByVal p As Object)
        Sub SetCharset(ByVal p As String)
        Sub SetCookie(ByVal p As String)
        Sub SetDefaultCharset(ByVal p As String)
        Sub SetDesignMode(ByVal p As String)
        Sub SetDomain(ByVal p As String)
        Sub SetExpando(ByVal p As Boolean)
        Sub SetFgColor(ByVal p As Object)
        Sub SetLinkColor(ByVal p As Object)
        Sub SetOnafterupdate(ByVal p As Object)
        Sub SetOnbeforeupdate(ByVal p As Object)
        Sub SetOnclick(ByVal p As Object)
        Sub SetOndblclick(ByVal p As Object)
        Sub SetOndragstart(ByVal p As Object)
        Sub SetOnerrorupdate(ByVal p As Object)
        Sub SetOnhelp(ByVal p As Object)
        Sub SetOnkeydown(ByVal p As Object)
        Sub SetOnkeypress(ByVal p As Object)
        Sub SetOnkeyup(ByVal p As Object)
        Sub SetOnmousedown(ByVal p As Object)
        Sub SetOnmousemove(ByVal p As Object)
        Sub SetOnmouseout(ByVal p As Object)
        Sub SetOnmouseover(ByVal p As Object)
        Sub SetOnmouseup(ByVal p As Object)
        Sub SetOnreadystatechange(ByVal p As Object)
        Sub SetOnrowenter(ByVal p As Object)
        Sub SetOnrowexit(ByVal p As Object)
        Sub SetOnselectstart(ByVal p As Object)
        Sub SetTitle(ByVal p As String)
        Sub SetURL(ByVal p As String)
        Sub SetVlinkColor(ByVal p As Object)
        Function toString() As <MarshalAs(UnmanagedType.BStr)> String
    End Interface
End Namespace