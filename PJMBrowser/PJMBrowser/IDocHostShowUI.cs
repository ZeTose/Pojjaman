using System;
using mshtml;
//using SHDocVw;
using System.Runtime.InteropServices;

namespace Longkong.Pojjaman.BrowserDisplayBinding
{
  [ComImport,
  Guid("C4D244B0-D43E-11CF-893B-00AA00BDCE1A"),
  InterfaceType(ComInterfaceType.InterfaceIsIUnknown) ]
  public interface IDocHostShowUI
  {
//     HRESULT ShowMessage(
//            [in] HWND hwnd,
//            [in] LPOLESTR lpstrText,
//            [in] LPOLESTR lpstrCaption,
//            [in] DWORD dwType,
//            [in] LPOLESTR lpstrHelpFile,
//            [in] DWORD dwHelpContext,
//            [out] LRESULT * plResult);
//    HRESULT ShowHelp(
//            [in] HWND hwnd,
//            [in] LPOLESTR pszHelpFile,
//            [in] UINT uCommand,
//            [in] DWORD dwData,
//            [in] POINT ptMouse,
//            [out] IDispatch * pDispatchObjectHit);

   [PreserveSig]
    uint ShowMessage(IntPtr hwnd, 
      [MarshalAs(UnmanagedType.BStr)] string lpstrText, 
      [MarshalAs(UnmanagedType.BStr)] string lpstrCaption, 
      uint dwType, 
      [MarshalAs(UnmanagedType.BStr)] string lpstrHelpFile, 
      uint dwHelpContext,
      out int lpResult);
                                  
    [PreserveSig]
    uint ShowHelp(IntPtr hwnd, [MarshalAs(UnmanagedType.BStr)] string pszHelpFile, 
      uint uCommand, uint dwData, 
      tagPOINT ptMouse, 
      [MarshalAs(UnmanagedType.IDispatch)] object pDispatchObjectHit);                       
  }
}
