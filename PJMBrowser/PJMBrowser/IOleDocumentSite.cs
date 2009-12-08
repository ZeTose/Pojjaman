using System;
using System.Runtime.InteropServices;

namespace Longkong.Pojjaman.BrowserDisplayBinding
{
  [ComImport,
  Guid("b722bcc7-4e68-101b-a2bc-00aa00404770"),
  InterfaceType(ComInterfaceType.InterfaceIsIUnknown) ]
  public interface IOleDocumentSite
  {
    void ActivateMe(ref object pViewToActivate);
  }
}
