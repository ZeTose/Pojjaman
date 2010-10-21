Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class CommonAboutDialog
        Inherits XmlForm

#Region "Members"
        Private Shared m_fileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
        Private Shared m_propertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New((CommonAboutDialog.m_propertyService.DataDirectory & "\resources\dialogs\CommonAboutDialog.xfrm"))
            'icsharpcode.XmlForms.XmlLoader
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property ScrollBox() As ScrollBox
            Get
                Return CType(MyBase.ControlDictionary("aboutPictureScrollBox"), ScrollBox)
            End Get
        End Property
#End Region

#Region "Methods"
        Protected Overrides Sub SetupXmlLoader()
            Me.xmlLoader.StringValueFilter = New PojjamanStringValueFilter
            Me.xmlLoader.PropertyValueCreator = New PojjamanPropertyValueCreator
        End Sub
#End Region

    Private Sub CommonAboutDialog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
        AboutPojjamanTabPage.timerT.Stop()
        AboutPojjamanTabPage.timerT.Dispose()

        AboutLicenseTabPage.timerL.Stop()
        AboutLicenseTabPage.timerL.Dispose()
      Catch ex As Exception

      End Try
    End Sub
  End Class
End Namespace

