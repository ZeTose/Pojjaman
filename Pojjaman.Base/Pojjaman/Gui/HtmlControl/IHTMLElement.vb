Imports Longkong.Pojjaman.Gui
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Namespace Longkong.Pojjaman.Gui.HtmlControl
    <Guid("3050F1FF-98B5-11CF-BB82-00AA00BDCE0B"), InterfaceType(ComInterfaceType.InterfaceIsDual), ComVisible(True)> _
    Friend Interface IHTMLElement
        ' Methods
        Sub Click()
        Function Contains(ByVal pChild As IHTMLElement) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Function GetAll() As <MarshalAs(UnmanagedType.Interface)> Object
        Sub GetAttribute(ByVal strAttributeName As String, ByVal lFlags As Integer, ByVal pvars As Object())
        Function GetChildren() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetClassName() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetDocument() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetFilters() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetId() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetInnerHTML() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetInnerText() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetIsTextEdit() As <MarshalAs(UnmanagedType.Bool)> Boolean
        Function GetLang() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetLanguage() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetOffsetHeight() As <MarshalAs(UnmanagedType.I4)> Integer
        Function GetOffsetLeft() As <MarshalAs(UnmanagedType.I4)> Integer
        Function GetOffsetParent() As <MarshalAs(UnmanagedType.Interface)> IHTMLElement
        Function GetOffsetTop() As <MarshalAs(UnmanagedType.I4)> Integer
        Function GetOffsetWidth() As <MarshalAs(UnmanagedType.I4)> Integer
        Function GetOnafterupdate() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnbeforeupdate() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnclick() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOndataavailable() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOndatasetchanged() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOndatasetcomplete() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOndblclick() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOndragstart() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnerrorupdate() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnfilterchange() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnhelp() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnkeydown() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnkeypress() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnkeyup() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmousedown() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmousemove() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmouseout() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmouseover() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnmouseup() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnrowenter() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnrowexit() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOnselectstart() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetOuterHTML() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetOuterText() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetParentElement() As <MarshalAs(UnmanagedType.Interface)> IHTMLElement
        Function GetParentTextEdit() As <MarshalAs(UnmanagedType.Interface)> IHTMLElement
        Function GetRecordNumber() As <MarshalAs(UnmanagedType.Struct)> Object
        Function GetSourceIndex() As <MarshalAs(UnmanagedType.I4)> Integer
        Function GetStyle() As <MarshalAs(UnmanagedType.Interface)> Object
        Function GetTagName() As <MarshalAs(UnmanagedType.BStr)> String
        Function GetTitle() As <MarshalAs(UnmanagedType.BStr)> String
        Sub InsertAdjacentHTML(ByVal where As String, ByVal html As String)
        Sub InsertAdjacentText(ByVal where As String, ByVal [text] As String)
        Function RemoveAttribute(ByVal strAttributeName As String, ByVal lFlags As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        Sub ScrollIntoView(ByVal varargStart As Object)
        Sub SetAttribute(ByVal strAttributeName As String, ByVal AttributeValue As Object, ByVal lFlags As Integer)
        Sub SetClassName(ByVal p As String)
        Sub SetId(ByVal p As String)
        Sub SetInnerHTML(ByVal p As String)
        Sub SetInnerText(ByVal p As String)
        Sub SetLang(ByVal p As String)
        Sub SetLanguage(ByVal p As String)
        Sub SetOnafterupdate(ByVal p As Object)
        Sub SetOnbeforeupdate(ByVal p As Object)
        Sub SetOnclick(ByVal p As Object)
        Sub SetOndataavailable(ByVal p As Object)
        Sub SetOndatasetchanged(ByVal p As Object)
        Sub SetOndatasetcomplete(ByVal p As Object)
        Sub SetOndblclick(ByVal p As Object)
        Sub SetOndragstart(ByVal p As Object)
        Sub SetOnerrorupdate(ByVal p As Object)
        Sub SetOnfilterchange(ByVal p As Object)
        Sub SetOnhelp(ByVal p As Object)
        Sub SetOnkeydown(ByVal p As Object)
        Sub SetOnkeypress(ByVal p As Object)
        Sub SetOnkeyup(ByVal p As Object)
        Sub SetOnmousedown(ByVal p As Object)
        Sub SetOnmousemove(ByVal p As Object)
        Sub SetOnmouseout(ByVal p As Object)
        Sub SetOnmouseover(ByVal p As Object)
        Sub SetOnmouseup(ByVal p As Object)
        Sub SetOnrowenter(ByVal p As Object)
        Sub SetOnrowexit(ByVal p As Object)
        Sub SetOnselectstart(ByVal p As Object)
        Sub SetOuterHTML(ByVal p As String)
        Sub SetOuterText(ByVal p As String)
        Sub SetTitle(ByVal p As String)
        Function toString() As <MarshalAs(UnmanagedType.BStr)> String
    End Interface
End Namespace