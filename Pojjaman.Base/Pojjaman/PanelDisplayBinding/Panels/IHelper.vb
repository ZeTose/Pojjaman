Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports Microsoft.Win32
Imports System.Text
Imports System.Threading
Imports Longkong.Pojjaman.FormDisplayBinding

Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IHelper

        Sub ShowHelper(ByVal rect As Rectangle)
        Sub HideHelper()
        Property Owner() As IHelperCapable
        ReadOnly Property SearhingPanel() As Panel
        ReadOnly Property SearchingTextBox() As TextBox
    End Interface
End Namespace

