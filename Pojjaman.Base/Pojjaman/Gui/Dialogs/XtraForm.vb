Imports System.Windows.Forms
Imports System.ComponentModel
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
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports Longkong.Pojjaman.Commands
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.AdobeForm
Imports System.Collections.Generic
Imports DevExpress
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting.Drawing
Imports System.Text.RegularExpressions
Imports System.Globalization

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class XtraForm
    Inherits System.Windows.Forms.Form

    Private m_userHash As Hashtable
    Private m_employeeHash As Hashtable

#Region "Contructor"
    Public Sub New(ByVal printingEntity As INewPrintableEntity, ByVal path As String, ByVal entity As ISimpleEntity)
      Me.InitializeComponent()
      Me.WindowState = FormWindowState.Maximized

      Me.m_printingEntity = printingEntity
      Me.m_path = path
      Me.m_entity = entity

      'If TypeOf entity Is IPrintableEntity Then
      '  If Not CType(entity, IPrintableEntity).GetDocPrintingEntries Is Nothing AndAlso
      '    CType(entity, IPrintableEntity).GetDocPrintingEntries.RelationList Is Nothing Then

      '    Me.m_printTableEntity.GetDocPrintingEntries.RelationList.AddRange(CType(entity, IPrintableEntity).GetDocPrintingEntries.RelationList)

      '  End If

      'End If

      Me.CheckAccessRight()
      Me.RefreshReport()
    End Sub
    Public Sub New(ByVal printingEntity As INewPrintableEntity, ByVal path As String, ByVal entityList As List(Of ISimpleEntity))
      Me.InitializeComponent()
      Me.WindowState = FormWindowState.Maximized

      Me.m_printingEntity = printingEntity
      Me.m_path = path

      Me.m_entity = entityList(0)

      Me.CheckAccessRight()
      Me.RefreshReportList(entityList)
    End Sub
    Public Sub New(ByVal myEntity As ISimpleEntity, ByVal path As String, ByVal idList As List(Of Integer))
      Me.InitializeComponent()
      Me.WindowState = FormWindowState.Maximized

      Me.m_printingEntity = Nothing
      Me.m_path = path

      Me.m_entity = myEntity

      Me.CheckAccessRight()
      Me.RefreshReportList(idList)
    End Sub
    'Public Sub New(ByVal entity As ISimpleEntity, ByVal path As String, ByVal docPrintingItemColl As DocPrintingItemCollection)
    '  Me.InitializeComponent()
    '  Me.WindowState = FormWindowState.Maximized

    '  Me.m_entity = entity
    '  Me.m_path = path
    '  Me.m_docPrintingItemColl = docPrintingItemColl

    '  Me.CheckAccessRight()
    '  Me.RefreshReport(True)
    'End Sub
#End Region

#Region "Method"
    Public Overridable Sub RefreshReport(Optional ByVal GetSchemaFromListView As Boolean = False)
      If Me.m_printingEntity Is Nothing Then
        Return
      End If

      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim currentUserName As String = secSrv.CurrentUser.Name

      Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      Dim culture As String = CType(myProperties.GetProperty("CoreProperties.UILanguage"), String)

      Dim companyLogo As Image = EntitySimpleSchema.GetCompanyConfigLogo
      Dim companyConfig As DataSet = EntitySimpleSchema.GetCompanyConfig()

      Dim newReport As XtraReport

      'm_userHash = New Hashtable
      'm_employeeHash = New Hashtable

      Try

        Dim xr As New LKXtraReport(Me.m_entity, Me.m_path, Me.m_printingEntity)
        newReport = xr.GetXtraReport
        'newReport = Me.CreateNewReport(companyLogo, companyConfig)

        AddHandler newReport.AfterPrint, AddressOf AfterPrint

        PrintControl1.PrintingSystem = newReport.PrintingSystem

        PrintControl1.ShowPageMargins = False

        PrintControl1.Refresh()

        newReport.CreateDocument()

        'Show the Document Map button. 
        newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.DocumentMap, XtraPrinting.CommandVisibility.All)
        newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Watermark, XtraPrinting.CommandVisibility.None)
        newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Customize, XtraPrinting.CommandVisibility.None)
        newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.SendFile, XtraPrinting.CommandVisibility.None)

        'Dim _xrLabel As XRLabel = CType(newReport.FindControl("label7", True), XRLabel)

        '_xrLabel.Text = _xrLabel.Text.Replace("1", "๑").Replace("2", "๒").Replace("3", "๓")
        'Debug.WriteLine(_xrLabel.Text)

        'PrintControl1.Refresh()

        'newReport.ShowPreviewMarginLines = False
      Catch ex As Exception
        MessageBox.Show("Load form .repx failed", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

    End Sub

    'Private Function CreateNewReport(ByVal companyLogo As Image, ByVal companyConfig As DataSet) As XtraReport
    '  Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    '  Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
    '  Dim newReport As DevExpress.XtraReports.UI.XtraReport
    '  'AddHandler newReport.AfterPrint, AddressOf AfterPrint
    '  'newReport = New XtraReport
    '  Try
    '    newReport = XtraReport.FromFile(Me.m_path, True)

    '    Dim ds As DataSet
    '    ds = GetDataFromEntitySchemaId(newReport.DataSourceSchema)

    '    '--Watermark-- 
    '    Dim config As Boolean = CBool(Configuration.GetConfig("ShowWaterMarkInExtraReports"))
    '    If config Then
    '      newReport.Watermark.Text = ""
    '      newReport.Watermark.TextDirection = DirectionMode.ForwardDiagonal
    '      newReport.Watermark.Font = New Font("Times New Roman", 72)
    '      newReport.Watermark.ForeColor = Color.Red
    '      'newReport.Watermark.Transparency = 150
    '      newReport.Watermark.TextTransparency = 180
    '      newReport.Watermark.ShowBehind = True
    '      'newReport.Watermark.PageRange = "1,3-5"
    '      'newReport.Watermark.Image = Bitmap.FromFile("D:\SVN\BuiLKSource\BuilkCostControl\trunk\BuilkMvc\Images\companyprofile\longkong_logo.jpg")
    '      'newReport.Watermark.ImageAlign = ContentAlignment.TopCenter
    '      'newReport.Watermark.ImageTiling = False
    '      'newReport.Watermark.ImageViewMode = ImageViewMode.Clip
    '      'newReport.Watermark.ImageTransparency = 100
    '      If TypeOf m_printingEntity Is IDocStatus Then
    '        Dim newWatermarkText As String = CType(m_printingEntity, IDocStatus).DocStatus
    '        newReport.Watermark.Text = newWatermarkText
    '      Else

    '      End If
    '    End If
    '    '--Watermark-- 

    '    '--Data Source Data--
    '    newReport.DataSource = ds
    '    '--Data Source Data--

    '    '--Company Logo--
    '    Dim xrLogoPictureBox As Object = newReport.FindControl("CompanyLogo", True)
    '    If Not xrLogoPictureBox Is Nothing AndAlso TypeOf xrLogoPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '      'Dim companyLogo As Image = EntitySimpleSchema.GetCompanyConfigLogo
    '      CType(xrLogoPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = companyLogo
    '    End If
    '    '--Company Logo--

    '    '--Company Config--
    '    'Dim companyConfig As DataSet = EntitySimpleSchema.GetCompanyConfig()
    '    Dim rows As New DataRowHelper(companyConfig.Tables(0).Rows(0))
    '    Dim xrCompanyNameRichText As Object = newReport.FindControl("CompanyName", True)
    '    If Not xrCompanyNameRichText Is Nothing AndAlso TypeOf xrCompanyNameRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '      CType(xrCompanyNameRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyName", "")
    '    End If
    '    Dim xrCompanyAddressRichText As Object = newReport.FindControl("CompanyAddress", True)
    '    If Not xrCompanyAddressRichText Is Nothing AndAlso TypeOf xrCompanyAddressRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '      CType(xrCompanyAddressRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyAddress", "")
    '    End If
    '    Dim xrCompanyBillingAddressRichText As Object = newReport.FindControl("CompanyBillingAddress", True)
    '    If Not xrCompanyBillingAddressRichText Is Nothing AndAlso TypeOf xrCompanyBillingAddressRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '      CType(xrCompanyBillingAddressRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyBillingAddress", "")
    '    End If
    '    Dim xrCompanyPhoneFaxRichText As Object = newReport.FindControl("CompanyPhoneCompanyFax", True)
    '    If Not xrCompanyPhoneFaxRichText Is Nothing AndAlso TypeOf xrCompanyPhoneFaxRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '      CType(xrCompanyPhoneFaxRichText, DevExpress.XtraReports.UI.XRLabel).Text = String.Format("โทรศัพท์ {0} โทรสาร {1}", rows.GetValue(Of String)("CompanyPhone", ""), rows.GetValue(Of String)("CompanyFax", ""))
    '    End If
    '    Dim xrCompanyPhoneRichText As Object = newReport.FindControl("CompanyPhone", True)
    '    If Not xrCompanyPhoneRichText Is Nothing AndAlso TypeOf xrCompanyPhoneRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '      CType(xrCompanyPhoneRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyPhone", "")
    '    End If
    '    Dim xrCompanyFaxRichText As Object = newReport.FindControl("CompanyFax", True)
    '    If Not xrCompanyFaxRichText Is Nothing AndAlso TypeOf xrCompanyFaxRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '      CType(xrCompanyFaxRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyFax", "")
    '    End If
    '    Dim xrCompanyTaxIdRichText As Object = newReport.FindControl("CompanyTaxId", True)
    '    If Not xrCompanyTaxIdRichText Is Nothing AndAlso TypeOf xrCompanyTaxIdRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '      CType(xrCompanyTaxIdRichText, DevExpress.XtraReports.UI.XRLabel).Text = String.Format("เลขประจำตัวผู้เสียภาษี {0}", rows.GetValue(Of String)("CompanyTaxId", ""))
    '    End If
    '    '--Company Config--

    '    '--Signature Image Name and Date--
    '    If TypeOf Me.m_entity Is IDocumentPersonAble Then
    '      Dim docPerson As IDocumentPersonAble = CType(Me.m_entity, IDocumentPersonAble)
    '      If Not docPerson Is Nothing AndAlso Not docPerson.DocumentEditedUser Is Nothing Then
    '        Dim _docEditedUser As DocumentEditedUser = docPerson.DocumentEditedUser
    '        If Not docPerson.DocumentEditedUser.Employee Is Nothing AndAlso docPerson.DocumentEditedUser.Employee.Originated Then
    '          Dim xrEmployeePictureBox As Object = newReport.FindControl("Employee", True)
    '          If Not xrEmployeePictureBox Is Nothing AndAlso TypeOf xrEmployeePictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '            Dim img As Image
    '            If Not m_employeeHash.ContainsKey(CStr(docPerson.DocumentEditedUser.Employee.Id)) Then
    '              img = CType(Employee.GetSignator(CStr(docPerson.DocumentEditedUser.Employee.Id)), Image)
    '              m_employeeHash.Add(CStr(docPerson.DocumentEditedUser.Employee.Id), img)
    '            Else
    '              img = CType(m_employeeHash(CStr(docPerson.DocumentEditedUser.Employee.Id)), Image)
    '            End If
    '            CType(xrEmployeePictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
    '          End If
    '          Dim xrEmployeeRichText As Object = newReport.FindControl("EmployeeName", True)
    '          If Not xrEmployeeRichText Is Nothing AndAlso TypeOf xrEmployeeRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrEmployeeRichText, DevExpress.XtraReports.UI.XRLabel).Text = docPerson.DocumentEditedUser.Employee.Name
    '          End If
    '        End If
    '        If Not _docEditedUser.CanceledUser Is Nothing Then
    '          Dim xrCanceledUserPictureBox As Object = newReport.FindControl("Cancel", True)
    '          If Not xrCanceledUserPictureBox Is Nothing AndAlso TypeOf xrCanceledUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '            Dim img As Image
    '            If Not m_userHash.ContainsKey(CStr(_docEditedUser.CanceledUser.UserId)) Then
    '              img = CType(User.GetSignator(CStr(_docEditedUser.CanceledUser.UserId)), Image)
    '              m_userHash.Add(CStr(_docEditedUser.CanceledUser.UserId), img)
    '            Else
    '              img = CType(m_userHash(CStr(_docEditedUser.CanceledUser.UserId)), Image)
    '            End If
    '            CType(xrCanceledUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
    '          End If
    '          Dim xrCanceledUserRichText As Object = newReport.FindControl("CancelName", True)
    '          If Not xrCanceledUserRichText Is Nothing AndAlso TypeOf xrCanceledUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrCanceledUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CanceledUser.UserName
    '          End If
    '          Dim xrCanceledUserDateRichText As Object = newReport.FindControl("CancelDate", True)
    '          If Not xrCanceledUserDateRichText Is Nothing AndAlso TypeOf xrCanceledUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrCanceledUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CanceledUser.EditedDate.ToShortDateString
    '          End If
    '        End If
    '        If Not _docEditedUser.CreatedUser Is Nothing Then
    '          Dim xrCreatedUserPictureBox As Object = newReport.FindControl("Create", True)
    '          If Not xrCreatedUserPictureBox Is Nothing AndAlso TypeOf xrCreatedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '            Dim img As Image
    '            If Not m_userHash.ContainsKey(CStr(_docEditedUser.CreatedUser.UserId)) Then
    '              img = CType(User.GetSignator(CStr(_docEditedUser.CreatedUser.UserId)), Image)
    '              m_userHash.Add(CStr(_docEditedUser.CreatedUser.UserId), img)
    '            Else
    '              img = CType(m_userHash(CStr(_docEditedUser.CreatedUser.UserId)), Image)
    '            End If
    '            CType(xrCreatedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
    '          End If
    '          Dim xrCreatedUserRichText As Object = newReport.FindControl("CreateName", True)
    '          If Not xrCreatedUserRichText Is Nothing AndAlso TypeOf xrCreatedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrCreatedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CreatedUser.UserName
    '          End If
    '          Dim xrCreatedUserDateRichText As Object = newReport.FindControl("CreateDate", True)
    '          If Not xrCreatedUserDateRichText Is Nothing AndAlso TypeOf xrCreatedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrCreatedUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CreatedUser.EditedDate.ToShortDateString
    '          End If
    '        End If
    '        If Not _docEditedUser.EditedUser Is Nothing Then
    '          Dim xrEditedUserPictureBox As Object = newReport.FindControl("Edite", True)
    '          If Not xrEditedUserPictureBox Is Nothing AndAlso TypeOf xrEditedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '            Dim img As Image
    '            If Not m_userHash.ContainsKey(CStr(_docEditedUser.EditedUser.UserId)) Then
    '              img = CType(User.GetSignator(CStr(_docEditedUser.EditedUser.UserId)), Image)
    '              m_userHash.Add(CStr(_docEditedUser.EditedUser.UserId), img)
    '            Else
    '              img = CType(m_userHash(CStr(_docEditedUser.EditedUser.UserId)), Image)
    '            End If
    '            CType(xrEditedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
    '          End If
    '          Dim xrEditedUserRichText As Object = newReport.FindControl("EditeName", True)
    '          If Not xrEditedUserRichText Is Nothing AndAlso TypeOf xrEditedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrEditedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.EditedUser.UserName
    '          End If
    '          Dim xrEditedUserDateRichText As Object = newReport.FindControl("EditeDate", True)
    '          If Not xrEditedUserDateRichText Is Nothing AndAlso TypeOf xrEditedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrEditedUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.EditedUser.EditedDate.ToShortDateString
    '          End If
    '        End If
    '        If Not _docEditedUser.ApprovedUser Is Nothing Then
    '          Dim xrApprovedUserPictureBox As Object = newReport.FindControl("Approve", True)
    '          If Not xrApprovedUserPictureBox Is Nothing AndAlso TypeOf xrApprovedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '            Dim img As Image
    '            If Not m_userHash.ContainsKey(CStr(_docEditedUser.ApprovedUser.UserId)) Then
    '              img = CType(User.GetSignator(CStr(_docEditedUser.ApprovedUser.UserId)), Image)
    '              m_userHash.Add(CStr(_docEditedUser.ApprovedUser.UserId), img)
    '            Else
    '              img = CType(m_userHash(CStr(_docEditedUser.ApprovedUser.UserId)), Image)
    '            End If
    '            CType(xrApprovedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
    '          End If
    '          Dim xrApprovedUserRichText As Object = newReport.FindControl("ApproveName", True)
    '          If Not xrApprovedUserRichText Is Nothing AndAlso TypeOf xrApprovedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrApprovedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.ApprovedUser.UserName
    '          End If
    '          Dim xrApproveUserDateRichText As Object = newReport.FindControl("ApproveDate", True)
    '          If Not xrApproveUserDateRichText Is Nothing AndAlso TypeOf xrApproveUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrApproveUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.ApprovedUser.EditedDate.ToShortDateString
    '          End If
    '        End If
    '        If Not _docEditedUser.AuthorizedUser Is Nothing Then
    '          Dim xrAuthorizedUserPictureBox As Object = newReport.FindControl("Authorize", True)
    '          If Not xrAuthorizedUserPictureBox Is Nothing AndAlso TypeOf xrAuthorizedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '            Dim img As Image
    '            If Not m_userHash.ContainsKey(CStr(_docEditedUser.AuthorizedUser.UserId)) Then
    '              img = CType(User.GetSignator(CStr(_docEditedUser.AuthorizedUser.UserId)), Image)
    '              m_userHash.Add(CStr(_docEditedUser.AuthorizedUser.UserId), img)
    '            Else
    '              img = CType(m_userHash(CStr(_docEditedUser.AuthorizedUser.UserId)), Image)
    '            End If
    '            CType(xrAuthorizedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
    '          End If
    '          Dim xrAuthorizedUserRichText As Object = newReport.FindControl("AuthorizeName", True)
    '          If Not xrAuthorizedUserRichText Is Nothing AndAlso TypeOf xrAuthorizedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrAuthorizedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.AuthorizedUser.UserName
    '          End If
    '          Dim xrAuthorizedUserDateRichText As Object = newReport.FindControl("AuthorizeDate", True)
    '          Trace.WriteLine((Not xrAuthorizedUserDateRichText Is Nothing).ToString)
    '          Trace.WriteLine((TypeOf xrAuthorizedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel).ToString)
    '          If Not xrAuthorizedUserDateRichText Is Nothing AndAlso TypeOf xrAuthorizedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrAuthorizedUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.AuthorizedUser.EditedDate.ToShortDateString
    '          End If
    '        End If
    '        If Not _docEditedUser.RejectUser Is Nothing Then
    '          Dim xrRejectUserPictureBox As Object = newReport.FindControl("Reject", True)
    '          If Not xrRejectUserPictureBox Is Nothing AndAlso TypeOf xrRejectUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '            Dim img As Image
    '            If Not m_userHash.ContainsKey(CStr(_docEditedUser.RejectUser.UserId)) Then
    '              img = CType(User.GetSignator(CStr(_docEditedUser.RejectUser.UserId)), Image)
    '              m_userHash.Add(CStr(_docEditedUser.RejectUser.UserId), img)
    '            Else
    '              img = CType(m_userHash(CStr(_docEditedUser.RejectUser.UserId)), Image)
    '            End If
    '            CType(xrRejectUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
    '          End If
    '          Dim xrRejectUserRichText As Object = newReport.FindControl("RejectName", True)
    '          If Not xrRejectUserRichText Is Nothing AndAlso TypeOf xrRejectUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrRejectUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.RejectUser.UserName
    '          End If
    '          Dim xrRejectUserDateRichText As Object = newReport.FindControl("RejectDate", True)
    '          If Not xrRejectUserDateRichText Is Nothing AndAlso TypeOf xrRejectUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '            CType(xrRejectUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.RejectUser.EditedDate.ToShortDateString
    '          End If
    '        End If
    '        If Not _docEditedUser.ApprovedUserList Is Nothing AndAlso _docEditedUser.ApprovedUserList.Count > 0 Then
    '          Dim ctlSignatureName As String = ""
    '          Dim ctlName As String = ""
    '          Dim ctlApproveDate As String = ""
    '          For Each ap As ApproveDoc In _docEditedUser.ApprovedUserList
    '            ctlSignatureName = String.Format("ApproveLevel{0}", ap.Level)
    '            Dim xrApproveUserLevelPictureBox As Object = newReport.FindControl(ctlSignatureName, True)
    '            If Not xrApproveUserLevelPictureBox Is Nothing AndAlso TypeOf xrApproveUserLevelPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '              Dim img As Image
    '              If Not m_userHash.ContainsKey(CStr(ap.Originator)) Then
    '                img = CType(User.GetSignator(CStr(ap.Originator)), Image)
    '                m_userHash.Add(CStr(ap.Originator), img)
    '              Else
    '                img = CType(m_userHash(CStr(ap.Originator)), Image)
    '              End If
    '              CType(xrApproveUserLevelPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
    '            End If
    '            ctlName = String.Format("ApproveLevel{0}Name", ap.Level)
    '            Dim xrctlNameRichText As Object = newReport.FindControl(ctlName, True)
    '            If Not xrctlNameRichText Is Nothing AndAlso TypeOf xrctlNameRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '              CType(xrctlNameRichText, DevExpress.XtraReports.UI.XRLabel).Text = New User(ap.Originator).Name
    '            End If
    '            ctlApproveDate = String.Format("ApproveLevel{0}Date", ap.Level)
    '            Dim xrctlApproveDateRichText As Object = newReport.FindControl(ctlName, True)
    '            If Not xrctlApproveDateRichText Is Nothing AndAlso TypeOf xrctlApproveDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '              CType(xrctlApproveDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = ap.OriginDate.ToShortDateString
    '            End If
    '          Next
    '        End If
    '      End If
    '    End If

    '    Dim xrUserPictureBox As Object = newReport.FindControl("User", True)
    '    If Not xrUserPictureBox Is Nothing AndAlso TypeOf xrUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
    '      Dim img As Image
    '      If Not m_userHash.ContainsKey(CStr(secSrv.CurrentUser.Id)) Then
    '        img = CType(User.GetSignator(CStr(secSrv.CurrentUser.Id)), Image)
    '        m_userHash.Add(CStr(secSrv.CurrentUser.Id), img)
    '      Else
    '        img = CType(m_userHash(CStr(secSrv.CurrentUser.Id)), Image)
    '      End If
    '      CType(xrUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
    '    End If
    '    Dim xrUserRichText As Object = newReport.FindControl("UserName", True)
    '    If Not xrUserRichText Is Nothing AndAlso TypeOf xrUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '      CType(xrUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = secSrv.CurrentUser.Name
    '    End If
    '    Dim xrUserDateRichText As Object = newReport.FindControl("UserDate", True)
    '    If Not xrUserDateRichText Is Nothing AndAlso TypeOf xrUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '      CType(xrUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = Now.ToShortDateString
    '    End If
    '    '--Signature Image--

    '    '--CUSTOM NOTES--
    '    'If m_entityNames.ContainsKey(Entity) AndAlso activeContent.GetType.Name = m_entityNames(Entity) Then
    '    If TypeOf m_printingEntity Is IHasCustomNote Then
    '      Dim coll As CustomNoteCollection        ' = CType(m_entity, IHasCustomNote).GetCustomNoteCollection
    '      If TypeOf m_printingEntity Is IHasMainDoc Then
    '        If Not (TypeOf (m_printingEntity) Is JournalEntry) Then
    '          coll = CType(CType(m_printingEntity, IHasMainDoc).MainDoc, IHasCustomNote).GetCustomNoteCollection
    '        Else
    '          coll = CType(m_printingEntity, IHasCustomNote).GetCustomNoteCollection
    '        End If
    '      Else
    '        coll = CType(m_printingEntity, IHasCustomNote).GetCustomNoteCollection
    '      End If
    '      Dim hsNote As New Hashtable
    '      For Each note As CustomNote In coll
    '        hsNote(note.NoteName.ToLower) = note
    '      Next

    '      For Each cName As String In hsNote.Keys
    '        Dim xrcNoteRichText As Object = newReport.FindControl(cName, True)
    '        If Not xrcNoteRichText Is Nothing AndAlso TypeOf xrcNoteRichText Is DevExpress.XtraReports.UI.XRLabel Then
    '          CType(xrcNoteRichText, DevExpress.XtraReports.UI.XRLabel).Text = ""
    '          If Not CType(hsNote(cName.ToLower), CustomNote) Is Nothing AndAlso Not CType(hsNote(cName.ToLower), CustomNote).Note Is Nothing Then
    '            CType(xrcNoteRichText, DevExpress.XtraReports.UI.XRLabel).Text = CType(hsNote(cName.ToLower), CustomNote).Note.ToString
    '          End If
    '        ElseIf Not xrcNoteRichText Is Nothing AndAlso TypeOf xrcNoteRichText Is DevExpress.XtraReports.UI.XRCheckBox Then
    '          If Not CType(hsNote(cName.ToLower), CustomNote) Is Nothing AndAlso Not CType(hsNote(cName.ToLower), CustomNote).Note Is Nothing Then
    '            CType(xrcNoteRichText, DevExpress.XtraReports.UI.XRCheckBox).Checked = CBool(CType(hsNote(cName), CustomNote).Note)
    '          End If
    '        End If
    '      Next

    '      'Dim parameterName As String
    '      'For index As Integer = 0 To newReport.Parameters.Count - 1
    '      '  parameterName = newReport.Parameters(index).Name.ToLower
    '      '  If hsNote.ContainsKey(parameterName) Then
    '      '    newReport.Parameters(index).Value = CType(hsNote(parameterName), CustomNote).Note
    '      '  End If
    '      'Next
    '    End If
    '    'End If
    '    '--END CUSTOM NOTES--

    '    Dim newCtl As Object = CalculateFields(newReport)

    '    Dim culture As String = CType(myProperties.GetProperty("CoreProperties.UILanguage"), String).Replace("-TH", "").Replace("-EN", "")
    '    Dim cultureV As New CultureInfo(culture, True)

    '    Dim dds As DataSet = CType(newReport.DataSource, DataSet)
    '    For Each ddt As DataTable In dds.Tables
    '      For Each ddc As DataColumn In ddt.Columns
    '        If ddc.DataType = GetType(System.DateTime) Then
    '          For Each ddr As DataRow In ddt.Rows
    '            If Not ddr(ddc.ColumnName) Is DBNull.Value Then
    '              ddr(ddc.ColumnName) = CDate(ddr(ddc.ColumnName)).ToString(cultureV)
    '              'Debug.WriteLine(CDate(ddr(ddc.ColumnName)).ToString("dd/MM/yyyy"))
    '              'Debug.WriteLine(culture)
    '            End If
    '          Next
    '        End If
    '      Next
    '    Next

    '    For Each b As Band In newReport.Bands
    '      For Each c As Object In b.Controls

    '      Next
    '    Next

    '    'CType(newCtl, DevExpress.XtraReports.UI.CalculatedField).Expression = "สิบบาทยี่สิบห้าสตางค์"

    '    'Dim xrLabel As New DevExpress.XtraReports.UI.XRLabel
    '    'xrLabel.Name = "xrLabel"
    '    'xrLabel.Text = "Longkongstudio co., ltd. "
    '    'xrLabel.AutoWidth = True
    '    'newReport.Bands(BandKind.BottomMargin).Controls.Add(xrLabel)

    '    For Each param As DevExpress.XtraReports.Parameters.Parameter In newReport.Parameters
    '      param.Visible = False
    '    Next

    '    Return newReport

    '  Catch ex As Exception
    '    Return New XtraReport
    '  End Try
    'End Function

    Private Sub AfterPrint(sender As Object, e As System.EventArgs)
      'Dim newReport As XtraReport = CType(sender, XtraReport)

      'For Each b As Band In newReport.Bands
      '  For Each obj As Object In b.Controls
      '    If TypeOf obj Is XRLabel Then
      '      Debug.WriteLine(CType(obj, XRLabel).Text)
      '    End If
      '  Next
      'Next
    End Sub

    Private Function CreateNewReportByStore(_docId As Integer, ByVal companyLogo As Image, ByVal companyConfig As DataSet) As XtraReport
      'Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      'Dim newReport As DevExpress.XtraReports.UI.XtraReport
      'Try
      '  newReport = XtraReport.FromFile(Me.m_path, True)

      '  Dim ds As DataSet
      '  ds = GetDataFromEntitySchemaId(newReport.DataSourceSchema)

      '  '--Watermark-- 
      '  Dim config As Boolean = CBool(Configuration.GetConfig("ShowWaterMarkInExtraReports"))
      '  If config Then
      '    newReport.Watermark.Text = ""
      '    newReport.Watermark.TextDirection = DirectionMode.ForwardDiagonal
      '    newReport.Watermark.Font = New Font("Times New Roman", 72)
      '    newReport.Watermark.ForeColor = Color.Red
      '    'newReport.Watermark.Transparency = 150
      '    newReport.Watermark.TextTransparency = 180
      '    newReport.Watermark.ShowBehind = True
      '    'newReport.Watermark.PageRange = "1,3-5"
      '    'newReport.Watermark.Image = Bitmap.FromFile("D:\SVN\BuiLKSource\BuilkCostControl\trunk\BuilkMvc\Images\companyprofile\longkong_logo.jpg")
      '    'newReport.Watermark.ImageAlign = ContentAlignment.TopCenter
      '    'newReport.Watermark.ImageTiling = False
      '    'newReport.Watermark.ImageViewMode = ImageViewMode.Clip
      '    'newReport.Watermark.ImageTransparency = 100

      '    If TypeOf m_printingEntity Is IDocStatus Then
      '      Dim newWatermarkText As String = CType(m_printingEntity, IDocStatus).DocStatus
      '      newReport.Watermark.Text = newWatermarkText
      '    Else

      '    End If
      '  End If
      '  '--Watermark-- 

      '  '--Data Source Data--
      '  newReport.DataSource = ds
      '  '--Data Source Data--

      '  '--Company Logo--
      '  Dim xrLogoPictureBox As Object = newReport.FindControl("CompanyLogo", True)
      '  If Not xrLogoPictureBox Is Nothing AndAlso TypeOf xrLogoPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '    'Dim companyLogo As Image = EntitySimpleSchema.GetCompanyConfigLogo
      '    CType(xrLogoPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = companyLogo
      '  End If
      '  '--Company Logo--

      '  '--Company Config--
      '  'Dim companyConfig As DataSet = EntitySimpleSchema.GetCompanyConfig()
      '  Dim rows As New DataRowHelper(companyConfig.Tables(0).Rows(0))
      '  Dim xrCompanyNameRichText As Object = newReport.FindControl("CompanyName", True)
      '  If Not xrCompanyNameRichText Is Nothing AndAlso TypeOf xrCompanyNameRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCompanyNameRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyName", "")
      '  End If
      '  Dim xrCompanyAddressRichText As Object = newReport.FindControl("CompanyAddress", True)
      '  If Not xrCompanyAddressRichText Is Nothing AndAlso TypeOf xrCompanyAddressRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCompanyAddressRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyAddress", "")
      '  End If
      '  Dim xrCompanyBillingAddressRichText As Object = newReport.FindControl("CompanyBillingAddress", True)
      '  If Not xrCompanyBillingAddressRichText Is Nothing AndAlso TypeOf xrCompanyBillingAddressRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCompanyBillingAddressRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyBillingAddress", "")
      '  End If
      '  Dim xrCompanyPhoneFaxRichText As Object = newReport.FindControl("CompanyPhoneCompanyFax", True)
      '  If Not xrCompanyPhoneFaxRichText Is Nothing AndAlso TypeOf xrCompanyPhoneFaxRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCompanyPhoneFaxRichText, DevExpress.XtraReports.UI.XRLabel).Text = String.Format("โทรศัพท์ {0} โทรสาร {1}", rows.GetValue(Of String)("CompanyPhone", ""), rows.GetValue(Of String)("CompanyFax", ""))
      '  End If
      '  Dim xrCompanyPhoneRichText As Object = newReport.FindControl("CompanyPhone", True)
      '  If Not xrCompanyPhoneRichText Is Nothing AndAlso TypeOf xrCompanyPhoneRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCompanyPhoneRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyPhone", "")
      '  End If
      '  Dim xrCompanyFaxRichText As Object = newReport.FindControl("CompanyFax", True)
      '  If Not xrCompanyFaxRichText Is Nothing AndAlso TypeOf xrCompanyFaxRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCompanyFaxRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyFax", "")
      '  End If
      '  Dim xrCompanyTaxIdRichText As Object = newReport.FindControl("CompanyTaxId", True)
      '  If Not xrCompanyTaxIdRichText Is Nothing AndAlso TypeOf xrCompanyTaxIdRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCompanyTaxIdRichText, DevExpress.XtraReports.UI.XRLabel).Text = String.Format("เลขประจำตัวผู้เสียภาษี {0}", rows.GetValue(Of String)("CompanyTaxId", ""))
      '  End If
      '  '--Company Config--

      '  '--Signature Image Name and Date--
      '  Dim xrEmployeePictureBox As Object = newReport.FindControl("Employee", True)
      '  If Not xrEmployeePictureBox Is Nothing AndAlso TypeOf xrEmployeePictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '    Dim img As Image = CType(Employee.GetSignator(CStr(docPerson.DocumentEditedUser.Employee.Id)), Image)
      '    CType(xrEmployeePictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      '  End If
      '  Dim xrEmployeeRichText As Object = newReport.FindControl("EmployeeName", True)
      '  If Not xrEmployeeRichText Is Nothing AndAlso TypeOf xrEmployeeRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrEmployeeRichText, DevExpress.XtraReports.UI.XRLabel).Text = docPerson.DocumentEditedUser.Employee.Name
      '  End If


      '  Dim xrCanceledUserPictureBox As Object = newReport.FindControl("Cancel", True)
      '  If Not xrCanceledUserPictureBox Is Nothing AndAlso TypeOf xrCanceledUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '    Dim img As Image = CType(User.GetSignator(CStr(_docEditedUser.CanceledUser.UserId)), Image)
      '    CType(xrCanceledUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      '  End If
      '  Dim xrCanceledUserRichText As Object = newReport.FindControl("CancelName", True)
      '  If Not xrCanceledUserRichText Is Nothing AndAlso TypeOf xrCanceledUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCanceledUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CanceledUser.UserName
      '  End If
      '  Dim xrCanceledUserDateRichText As Object = newReport.FindControl("CancelDate", True)
      '  If Not xrCanceledUserDateRichText Is Nothing AndAlso TypeOf xrCanceledUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCanceledUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CanceledUser.EditedDate.ToShortDateString
      '  End If

      '  Dim xrCreatedUserPictureBox As Object = newReport.FindControl("Create", True)
      '  If Not xrCreatedUserPictureBox Is Nothing AndAlso TypeOf xrCreatedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '    Dim img As Image = CType(User.GetSignator(CStr(_docEditedUser.CreatedUser.UserId)), Image)
      '    CType(xrCreatedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      '  End If
      '  Dim xrCreatedUserRichText As Object = newReport.FindControl("CreateName", True)
      '  If Not xrCreatedUserRichText Is Nothing AndAlso TypeOf xrCreatedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCreatedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CreatedUser.UserName
      '  End If
      '  Dim xrCreatedUserDateRichText As Object = newReport.FindControl("CreateDate", True)
      '  If Not xrCreatedUserDateRichText Is Nothing AndAlso TypeOf xrCreatedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrCreatedUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CreatedUser.EditedDate.ToShortDateString
      '  End If

      '  Dim xrEditedUserPictureBox As Object = newReport.FindControl("Edite", True)
      '  If Not xrEditedUserPictureBox Is Nothing AndAlso TypeOf xrEditedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '    Dim img As Image = CType(User.GetSignator(CStr(_docEditedUser.EditedUser.UserId)), Image)
      '    CType(xrEditedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      '  End If
      '  Dim xrEditedUserRichText As Object = newReport.FindControl("EditeName", True)
      '  If Not xrEditedUserRichText Is Nothing AndAlso TypeOf xrEditedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrEditedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.EditedUser.UserName
      '  End If
      '  Dim xrEditedUserDateRichText As Object = newReport.FindControl("EditeDate", True)
      '  If Not xrEditedUserDateRichText Is Nothing AndAlso TypeOf xrEditedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrEditedUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.EditedUser.EditedDate.ToShortDateString
      '  End If

      '  Dim xrApprovedUserPictureBox As Object = newReport.FindControl("Approve", True)
      '  If Not xrApprovedUserPictureBox Is Nothing AndAlso TypeOf xrApprovedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '    Dim img As Image = CType(User.GetSignator(CStr(_docEditedUser.ApprovedUser.UserId)), Image)
      '    CType(xrApprovedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      '  End If
      '  Dim xrApprovedUserRichText As Object = newReport.FindControl("ApproveName", True)
      '  If Not xrApprovedUserRichText Is Nothing AndAlso TypeOf xrApprovedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrApprovedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.ApprovedUser.UserName
      '  End If
      '  Dim xrApproveUserDateRichText As Object = newReport.FindControl("ApproveDate", True)
      '  If Not xrApproveUserDateRichText Is Nothing AndAlso TypeOf xrApproveUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrApproveUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.ApprovedUser.EditedDate.ToShortDateString
      '  End If

      '  Dim xrAuthorizedUserPictureBox As Object = newReport.FindControl("Authorize", True)
      '  If Not xrAuthorizedUserPictureBox Is Nothing AndAlso TypeOf xrAuthorizedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '    Dim img As Image = CType(User.GetAuthorizeSignator(CStr(_docEditedUser.AuthorizedUser.UserId)), Image)
      '    CType(xrAuthorizedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      '  End If
      '  Dim xrAuthorizedUserRichText As Object = newReport.FindControl("AuthorizeName", True)
      '  If Not xrAuthorizedUserRichText Is Nothing AndAlso TypeOf xrAuthorizedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrAuthorizedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.AuthorizedUser.UserName
      '  End If
      '  Dim xrAuthorizedUserDateRichText As Object = newReport.FindControl("AuthorizeDate", True)
      '  If Not xrAuthorizedUserDateRichText Is Nothing AndAlso TypeOf xrAuthorizedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrAuthorizedUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.AuthorizedUser.EditedDate.ToShortDateString
      '  End If

      '  Dim xrRejectUserPictureBox As Object = newReport.FindControl("Reject", True)
      '  If Not xrRejectUserPictureBox Is Nothing AndAlso TypeOf xrRejectUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '    Dim img As Image = CType(User.GetSignator(CStr(_docEditedUser.RejectUser.UserId)), Image)
      '    CType(xrRejectUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      '  End If
      '  Dim xrRejectUserRichText As Object = newReport.FindControl("RejectName", True)
      '  If Not xrRejectUserRichText Is Nothing AndAlso TypeOf xrRejectUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrRejectUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.RejectUser.UserName
      '  End If
      '  Dim xrRejectUserDateRichText As Object = newReport.FindControl("RejectDate", True)
      '  If Not xrRejectUserDateRichText Is Nothing AndAlso TypeOf xrRejectUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrRejectUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.RejectUser.EditedDate.ToShortDateString
      '  End If

      '  Dim ctlSignatureName As String = ""
      '  Dim ctlName As String = ""
      '  Dim ctlApproveDate As String = ""
      '  For Each ap As ApproveDoc In _docEditedUser.ApprovedUserList
      '    ctlSignatureName = String.Format("ApproveLevel{0}", ap.Level)
      '    Dim xrApproveUserLevelPictureBox As Object = newReport.FindControl(ctlSignatureName, True)
      '    If Not xrApproveUserLevelPictureBox Is Nothing AndAlso TypeOf xrApproveUserLevelPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '      Dim img As Image = CType(User.GetSignator(CStr(ap.Originator)), Image)
      '      CType(xrApproveUserLevelPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      '    End If
      '    ctlName = String.Format("ApproveLevel{0}Name", ap.Level)
      '    Dim xrctlNameRichText As Object = newReport.FindControl(ctlName, True)
      '    If Not xrctlNameRichText Is Nothing AndAlso TypeOf xrctlNameRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '      CType(xrctlNameRichText, DevExpress.XtraReports.UI.XRLabel).Text = New User(ap.Originator).Name
      '    End If
      '    ctlApproveDate = String.Format("ApproveLevel{0}Date", ap.Level)
      '    Dim xrctlApproveDateRichText As Object = newReport.FindControl(ctlName, True)
      '    If Not xrctlApproveDateRichText Is Nothing AndAlso TypeOf xrctlApproveDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '      CType(xrctlApproveDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = ap.OriginDate.ToShortDateString
      '    End If
      '  Next

      '  Dim xrUserPictureBox As Object = newReport.FindControl("User", True)
      '  If Not xrUserPictureBox Is Nothing AndAlso TypeOf xrUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
      '    Dim img As Image = CType(User.GetSignator(CStr(secSrv.CurrentUser.Id)), Image)
      '    CType(xrUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      '  End If
      '  Dim xrUserRichText As Object = newReport.FindControl("UserName", True)
      '  If Not xrUserRichText Is Nothing AndAlso TypeOf xrUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = secSrv.CurrentUser.Name
      '  End If
      '  Dim xrUserDateRichText As Object = newReport.FindControl("UserDate", True)
      '  If Not xrUserDateRichText Is Nothing AndAlso TypeOf xrUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '    CType(xrUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = Now.ToShortDateString
      '  End If
      '  '--Signature Image--

      '  '--CUSTOM NOTES--
      '  If TypeOf m_printingEntity Is IHasCustomNote Then
      '    Dim coll As CustomNoteCollection        ' = CType(m_entity, IHasCustomNote).GetCustomNoteCollection
      '    If TypeOf m_printingEntity Is IHasMainDoc Then
      '      If Not (TypeOf (m_printingEntity) Is JournalEntry) Then
      '        coll = CType(CType(m_printingEntity, IHasMainDoc).MainDoc, IHasCustomNote).GetCustomNoteCollection
      '      Else
      '        coll = CType(m_printingEntity, IHasCustomNote).GetCustomNoteCollection
      '      End If
      '    Else
      '      coll = CType(m_printingEntity, IHasCustomNote).GetCustomNoteCollection
      '    End If
      '    Dim hsNote As New Hashtable
      '    For Each note As CustomNote In coll
      '      hsNote(note.NoteName.ToLower) = note
      '    Next

      '    For Each cName As String In hsNote.Keys
      '      Dim xrcNoteRichText As Object = newReport.FindControl(cName, True)
      '      If Not xrcNoteRichText Is Nothing AndAlso TypeOf xrcNoteRichText Is DevExpress.XtraReports.UI.XRLabel Then
      '        CType(xrcNoteRichText, DevExpress.XtraReports.UI.XRLabel).Text = ""
      '        If Not CType(hsNote(cName.ToLower), CustomNote) Is Nothing AndAlso Not CType(hsNote(cName.ToLower), CustomNote).Note Is Nothing Then
      '          CType(xrcNoteRichText, DevExpress.XtraReports.UI.XRLabel).Text = CType(hsNote(cName.ToLower), CustomNote).Note.ToString
      '        End If
      '      ElseIf Not xrcNoteRichText Is Nothing AndAlso TypeOf xrcNoteRichText Is DevExpress.XtraReports.UI.XRCheckBox Then
      '        If Not CType(hsNote(cName.ToLower), CustomNote) Is Nothing AndAlso Not CType(hsNote(cName.ToLower), CustomNote).Note Is Nothing Then
      '          CType(xrcNoteRichText, DevExpress.XtraReports.UI.XRCheckBox).Checked = CBool(CType(hsNote(cName), CustomNote).Note)
      '        End If
      '      End If
      '    Next

      '  End If
      '  '--END CUSTOM NOTES--

      '  Dim newCtl As Object = CalculateFields(newReport)

      '  For Each param As DevExpress.XtraReports.Parameters.Parameter In newReport.Parameters
      '    param.Visible = False
      '  Next

      '  Return newReport

      'Catch ex As Exception
      '  Return New XtraReport
      'End Try
    End Function

    Private Function CalculateFields(xr As XtraReport) As Object
      Dim calColl As CalculatedFieldCollection = xr.CalculatedFields

      Dim _expr As String = ""
      'Dim _reg As New RegularExpressions.Regex("ctext([\d{n}],[th],[\{n}],[\{n}],[\{n}])")
      For Each cal As CalculatedField In calColl
        _expr = cal.Expression
        cal.Expression = "'" & Me.MatchFunction(_expr, xr) & "'"
      Next

      Return calColl
    End Function

    Private Function MatchFunction(expr As String, ByRef xr As XtraReport) As String
      'Dim expr As String = "ctext(12345678,th,baht,stang,only)"
      Const Var As String = "([^\(\),]*)"
      Dim ctextFunc As New Regex("ctext" &
      "\(\s*" & Var & _
      "\s*,\s*" & Var & _
      "\s*,\s*" & Var & _
      "\s*,\s*" & Var & _
      "\s*,\s*" & Var & _
      "\s*\)", RegexOptions.IgnoreCase)

      'dim expr As String = "cnthai(%)"
      Dim ctextFunc2 As New Regex("cnthai\(.*\)")

      'Dim expr As String = "cnthai(123)"
      Dim ctextFunc3 As New Regex("cnthai" &
      "\(" &
      "[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\.[0-9]{2})?" &
      "\)", RegexOptions.IgnoreCase)

      If ctextFunc.IsMatch(expr) Then
        Dim m As Match = ctextFunc.Match(expr)
        Dim value1 As String = m.Groups(1).Value.Replace("'", "")
        Dim value2 As String = m.Groups(2).Value.Replace("'", "")
        Dim value3 As String = m.Groups(3).Value.Replace("'", "")
        Dim value4 As String = m.Groups(4).Value.Replace("'", "")
        Dim value5 As String = m.Groups(5).Value.Replace("'", "")
        If Not IsNumeric(value1) Then
          Dim newValue1 As String = Me.GetValueFromField(value1, xr)
          If newValue1.Length > 0 Then
            value1 = newValue1
          Else
            Return ""
          End If
        End If
        Return Configuration.FormatToString(value1, value2.Trim(), value3.Trim, value4.Trim)
      End If

      If ctextFunc2.IsMatch(expr) Then
        expr = expr.Replace("cnthai(", "")
        expr = expr.Substring(0, expr.Length - 1)

        If Not IsNumeric(expr) Then
          Dim newValue1 As String = Me.GetValueFromField(expr, xr)
          If newValue1.Length > 0 Then
            expr = newValue1
          Else
            Return ""
          End If
        End If
        Return Me.ReplaceThaiNumber(expr)
      End If

      If ctextFunc3.IsMatch(expr) Then
        Return Me.ReplaceThaiNumber(expr)
      End If
      'Dim calcFunc As New Regex("calc\(\s*\)", RegexOptions.IgnoreCase)
      'If calcFunc.IsMatch(expr) Then
      '  Dim patturn As String = expr.Substring(5, Len(expr) - 1)
      '  Dim g1() As String = patturn.Split("
      'End If

      Return expr

    End Function

    Private Function ReplaceThaiNumber(input As String) As String
      Dim hs As New Hashtable
      hs.Add("1", "๑")
      hs.Add("2", "๒")
      hs.Add("3", "๓")
      hs.Add("4", "๔")
      hs.Add("5", "๕")
      hs.Add("6", "๖")
      hs.Add("7", "๗")
      hs.Add("8", "๘")
      hs.Add("9", "๙")
      hs.Add("0", "๐")

      Dim output As String = ""
      For i As Integer = 1 To input.Length
        output &= CStr(hs(Mid(input, i, 1)))
      Next

      Return output

    End Function

    Private Function GetValueFromField(value As String, ByRef xr As XtraReport) As String
      'Dim fieldFunc As New Regex("(\s*)\.(\s*)", RegexOptions.IgnoreCase)
      Dim fieldFunc As New Regex("(\[[^]\r\n]+](?:\r?\n(?:[^[\r\n].*)?)*)\.(\[[^]\r\n]+](?:\r?\n(?:[^[\r\n].*)?)*)", RegexOptions.IgnoreCase)
      If fieldFunc.IsMatch(value) Then
        If Not xr.DataSource Is Nothing AndAlso TypeOf xr.DataSource Is DataSet Then
          Dim ds As DataSet = CType(xr.DataSource, DataSet)

          Dim m As Match = fieldFunc.Match(value)
          Dim value1 As String = m.Groups(1).Value.Replace("[", "").Replace("]", "")
          Dim value2 As String = m.Groups(2).Value.Replace("[", "").Replace("]", "")

          If ds.Tables.Contains(value1) Then
            If ds.Tables(value1).Columns.Contains(value2) Then
              If Not ds.Tables(value1).Rows(0)(value2) Is Nothing AndAlso IsNumeric(ds.Tables(value1).Rows(0)(value2)) Then
                Return ds.Tables(value1).Rows(0)(value2).ToString
              End If
            End If
          End If
        End If
      End If
      Return ""
    End Function

    'Private Function SplitValueText(value1 As String, value3 As String, value4 As String, value5 As String) As String

    '  Dim ztext As String = ""


    '  If IsNumeric(value1) Then
    '    If CDec(value1) < 0 Then
    '      ztext &= "ลบ"
    '    End If

    '    If CDec(value1) = 0 Then
    '      ztext &= "ศูนย์"
    '      ztext &= value3.Trim
    '      ztext &= value5.Trim
    '    Else
    '      value1 = CDec(value1).ToString.Trim
    '      Dim decValue() As String = value1.Split("."c)

    '      Dim numberValue As String = Math.Abs(CDec(decValue(0))).ToString.Trim
    '      Dim digitValue As String = "00"
    '      If decValue.Length > 1 Then
    '        digitValue = String.Format(decValue(1), "00").Substring(0, 2)
    '      End If

    '      numberValue = ConvertToThaiText(numberValue)
    '      digitValue = ConvertToThaiText(digitValue)

    '      If numberValue.Length > 0 Then
    '        ztext &= numberValue
    '        ztext &= value3.Trim
    '      End If
    '      If digitValue.Length > 0 Then
    '        ztext &= digitValue
    '        ztext &= value4.Trim
    '      Else
    '        ztext &= value5.Trim
    '      End If
    '    End If
    '  Else
    '    If value1.Trim.Length = 0 Then
    '      ztext &= "ศูนย์"
    '      ztext &= value3.Trim
    '      ztext &= value5.Trim
    '    End If
    '  End If

    '  Return ztext

    'End Function

    'Private Function ConvertToThaiText(value1 As String) As String

    '  Dim digitNumber As New Hashtable
    '  digitNumber("1") = ""
    '  digitNumber("2") = "สิบ"
    '  digitNumber("3") = "ร้อย"
    '  digitNumber("4") = "พัน"
    '  digitNumber("5") = "หมื่น"
    '  digitNumber("0") = "แสน"
    '  digitNumber("7") = "ล้าน"

    '  Dim digitValue As New Hashtable
    '  digitValue("0") = ""
    '  digitValue("1") = "หนึ่ง"
    '  digitValue("2") = "สอง"
    '  digitValue("3") = "สาม"
    '  digitValue("4") = "สี่"
    '  digitValue("5") = "ห้า"
    '  digitValue("6") = "หก"
    '  digitValue("7") = "เจ็ด"
    '  digitValue("8") = "แปด"
    '  digitValue("9") = "เก้า"

    '  digitValue("10") = "ยี่"
    '  digitValue("11") = "เอ็ด"

    '  Dim charValue As String = ""
    '  Dim charIndex As Integer = 0
    '  Dim _text As String = ""
    '  For i As Integer = value1.Length To 1 Step -1
    '    charValue = value1.Substring((value1.Length) - i, 1)
    '    charIndex = (i Mod 6)

    '    If charIndex = 0 And _text.Trim.Length > 0 Then
    '      _text &= "ล้าน"
    '    End If

    '    Select Case charValue
    '      Case "0"
    '        charIndex = 1
    '      Case "1"
    '        If charIndex = 2 Then '""
    '          charValue = "0"
    '        ElseIf charIndex = 1 Then '"เอ็ด"
    '          If _text.Trim.Length > 0 Then
    '            charValue = "11"
    '          End If
    '        End If
    '      Case "2"
    '        If charIndex = 2 Then '"ยี่"
    '          charValue = "10"
    '        End If
    '    End Select

    '    _text &= digitValue(charValue).ToString

    '    _text &= digitNumber(CStr(charIndex)).ToString
    '  Next

    '  Return _text
    'End Function

    'Private Function IsDefaultSchema(entity_ As ISimpleEntity) As Boolean
    '  Dim newReport As DevExpress.XtraReports.UI.XtraReport
    '  If IO.File.Exists(Me.m_path) Then
    '    newReport = XtraReport.FromFile(Me.m_path, True)
    '    Dim schemaId As String = CType(newReport.DataSource, DataSet).DataSetName
    '    If EntitySimpleSchema.IsDefaultSchema(entity_, schemaId) Then
    '      Return True
    '    Else
    '      Return False
    '    End If
    '  End If
    '  Return True
    'End Function

    Public Overridable Sub RefreshReportList(ByVal entityList As List(Of ISimpleEntity))
      If Me.m_printingEntity Is Nothing Then
        Return
      End If

      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim currentUserName As String = secSrv.CurrentUser.Name

      Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      Dim culture As String = CType(myProperties.GetProperty("CoreProperties.UILanguage"), String)

      Dim companyLogo As Image = EntitySimpleSchema.GetCompanyConfigLogo
      Dim companyConfig As DataSet = EntitySimpleSchema.GetCompanyConfig()

      Dim newReport As XtraReport
      Dim newOtherReport As XtraReport

      m_userHash = New Hashtable
      m_employeeHash = New Hashtable

      Try
        Me.m_entity = entityList(0)
        Dim xr As New LKXtraReport(Me.m_entity, Me.m_path, Me.m_printingEntity)
        newReport = xr.GetXtraReport
        'newReport = Me.CreateNewReport(companyLogo, companyConfig)

        PrintControl1.PrintingSystem = newReport.PrintingSystem

        PrintControl1.ShowPageMargins = False

        newReport.CreateDocument()

        'newReport.ShowPreviewMarginLines = False
      Catch ex As Exception
        Throw New Exception("Load form .repx failed")
      End Try

      For Each _entity As ISimpleEntity In entityList
        Try
          If Not Me.m_entity.Equals(_entity) Then

            Me.m_printingEntity = CType(_entity, INewPrintableEntity)
            Me.m_entity = _entity
            Dim xr As New LKXtraReport(Me.m_entity, Me.m_path, Me.m_printingEntity)
            newOtherReport = xr.GetXtraReport
            'newOtherReport = Me.CreateNewReport(companyLogo, companyConfig)

            'PrintControl1.PrintingSystem = newOtherReport.PrintingSystem

            'PrintControl1.ShowPageMargins = False

            'PrintControl1.Refresh()

            newOtherReport.CreateDocument()

            'Show the Document Map button. 
            'newOtherReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.DocumentMap, XtraPrinting.CommandVisibility.All)
            'newOtherReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Watermark, XtraPrinting.CommandVisibility.None)
            'newOtherReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Customize, XtraPrinting.CommandVisibility.None)
            'newOtherReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.SendFile, XtraPrinting.CommandVisibility.None)

            newReport.Pages.AddRange(newOtherReport.Pages)

            'newReport.ShowPreviewDialog()
          End If

          'newReport.ShowPreviewMarginLines = False
        Catch ex As Exception
          Throw New Exception("Load form .repx failed")
        End Try
      Next

      PrintControl1.Refresh()

      newReport.PrintingSystem.ContinuousPageNumbering = False

      'Show the Document Map button. 
      newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.DocumentMap, XtraPrinting.CommandVisibility.All)
      newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Watermark, XtraPrinting.CommandVisibility.None)
      newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Customize, XtraPrinting.CommandVisibility.None)
      newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.SendFile, XtraPrinting.CommandVisibility.None)

    End Sub

    Public Overridable Sub RefreshReportList(ByVal idList As List(Of Integer))
      'If Me.m_printingEntity Is Nothing Then
      '  Return
      'End If

      'Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      'Dim currentUserName As String = secSrv.CurrentUser.Name

      'Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      'Dim culture As String = CType(myProperties.GetProperty("CoreProperties.UILanguage"), String)

      'Dim companyLogo As Image = EntitySimpleSchema.GetCompanyConfigLogo
      'Dim companyConfig As DataSet = EntitySimpleSchema.GetCompanyConfig()

      'Dim newReport As XtraReport
      'Dim newOtherReport As XtraReport
      'Try
      '  'Me.m_entity = entityList(0)

      '  newReport = Me.CreateNewReportByStore(0, companyLogo, companyConfig))

      '  PrintControl1.PrintingSystem = newReport.PrintingSystem

      '  PrintControl1.ShowPageMargins = False

      '  newReport.CreateDocument()

      '  'newReport.ShowPreviewMarginLines = False
      'Catch ex As Exception
      '  Throw New Exception("Load form .repx failed")
      'End Try

      'For Each _entity As ISimpleEntity In entityList
      '  Try
      '    If Not Me.m_entity.Equals(_entity) Then

      '      Me.m_printingEntity = CType(_entity, INewPrintableEntity)
      '      Me.m_entity = _entity
      '      If Me.IsDefaultSchema(_entity) Then
      '        newOtherReport = Me.CreateNewReport
      '      Else
      '        newOtherReport = Me.CreateNewReportByStore
      '      End If

      '      'PrintControl1.PrintingSystem = newOtherReport.PrintingSystem

      '      'PrintControl1.ShowPageMargins = False

      '      'PrintControl1.Refresh()

      '      newOtherReport.CreateDocument()

      '      'Show the Document Map button. 
      '      'newOtherReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.DocumentMap, XtraPrinting.CommandVisibility.All)
      '      'newOtherReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Watermark, XtraPrinting.CommandVisibility.None)
      '      'newOtherReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Customize, XtraPrinting.CommandVisibility.None)
      '      'newOtherReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.SendFile, XtraPrinting.CommandVisibility.None)

      '      newReport.Pages.AddRange(newOtherReport.Pages)

      '      'newReport.ShowPreviewDialog()
      '    End If

      '    'newReport.ShowPreviewMarginLines = False
      '  Catch ex As Exception
      '    Throw New Exception("Load form .repx failed")
      '  End Try
      'Next

      'PrintControl1.Refresh()

      'newReport.PrintingSystem.ContinuousPageNumbering = False

      ''Show the Document Map button. 
      'newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.DocumentMap, XtraPrinting.CommandVisibility.All)
      'newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Watermark, XtraPrinting.CommandVisibility.None)
      'newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Customize, XtraPrinting.CommandVisibility.None)
      'newReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.SendFile, XtraPrinting.CommandVisibility.None)

    End Sub

    'Private Function GetDataFromEntitySchemaId(ByVal dataSourceSchema As String) As DataSet
    '  If dataSourceSchema.Length = 0 Then
    '    Return Nothing
    '  End If

    '  Dim doc As New XmlDocument
    '  doc.LoadXml(dataSourceSchema)

    '  Dim xn As XmlNode = doc.DocumentElement.Attributes("id")
    '  Dim schemaid As String = xn.InnerText

    '  Dim ds As DataSet = EntitySimpleSchema.GetData(m_entity, m_printingEntity, schemaid)
    '  If Not ds Is Nothing Then
    '    Return ds
    '  End If
    '  'Dim entitySchema As New EntitySimpleSchema(m_entity, schemaid, m_printTableEntity)
    '  'If Not entitySchema.DataSet Is Nothing OrElse
    '  '   Not entitySchema.DataSet.Tables.Count = 0 Then
    '  '  Return entitySchema.DataSet
    '  'End If

    '  Return New DataSet
    'End Function

    'Private Function GetDataFromEntityListView() As DataSet
    '  Dim entitySchema As New EntitySimpleSchema(m_entity, m_docPrintingItemColl)
    '  If Not entitySchema.DataSet Is Nothing OrElse
    '     Not entitySchema.DataSet.Tables.Count = 0 Then
    '    Return entitySchema.DataSet
    '  End If

    '  Return New DataSet
    'End Function
    Private Sub CheckAccessRight()
      Dim simpleentity As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName)

      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim accessId As Integer = Longkong.Pojjaman.BusinessLogic.Entity.GetAccessIdFromFullClassName(simpleentity.FullClassName)

      Dim level As Integer = secSrv.GetAccess(accessId)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      'Trace.WriteLine(checkString)
      'If CBool(checkString.Substring(3, 1)) Then
      '  Me.CrystalReportViewer1.ShowPrintButton = True
      '  Me.CrystalReportViewer1.ShowExportButton = True
      'Else
      '  Me.CrystalReportViewer1.ShowPrintButton = False
      '  Me.CrystalReportViewer1.ShowExportButton = False
      'End If
    End Sub
    'Private Sub newReport_AfterPrint(sender As Object, e As EventArgs)
    '  MessageBox.Show("Yahoo")
    'End Sub
#End Region

#Region "Member"
    Private m_printingEntity As INewPrintableEntity
    Private m_entity As ISimpleEntity
    'Private m_newPrintingEntity As INewPrintableEntity
    Private m_path As String
    'Private m_printTableEntity As IPrintableEntity
    'Private m_docPrintingItemColl As DocPrintingItemCollection
    'Private newReport As DevExpress.XtraReports.UI.XtraReport

    Friend WithEvents PrintBarManager1 As DevExpress.XtraPrinting.Preview.PrintBarManager
    Friend WithEvents PreviewBar1 As DevExpress.XtraPrinting.Preview.PreviewBar
    Friend WithEvents PrintPreviewBarItem2 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem3 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem4 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem5 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem6 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem7 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem8 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem9 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem10 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem11 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem12 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem13 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem14 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem15 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents ZoomBarEditItem1 As DevExpress.XtraPrinting.Preview.ZoomBarEditItem
    Friend WithEvents PrintPreviewRepositoryItemComboBox1 As DevExpress.XtraPrinting.Preview.PrintPreviewRepositoryItemComboBox
    Friend WithEvents PrintPreviewBarItem16 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem17 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem18 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem19 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem20 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem21 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem22 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem23 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem24 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem25 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem26 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PreviewBar2 As DevExpress.XtraPrinting.Preview.PreviewBar
    Friend WithEvents PrintPreviewStaticItem1 As DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents ProgressBarEditItem1 As DevExpress.XtraPrinting.Preview.ProgressBarEditItem
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents PrintPreviewBarItem1 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PrintPreviewStaticItem2 As DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem
    Friend WithEvents ZoomTrackBarEditItem1 As DevExpress.XtraPrinting.Preview.ZoomTrackBarEditItem
    Friend WithEvents RepositoryItemZoomTrackBar1 As DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar
    Friend WithEvents PreviewBar3 As DevExpress.XtraPrinting.Preview.PreviewBar
    Friend WithEvents PrintPreviewSubItem1 As DevExpress.XtraPrinting.Preview.PrintPreviewSubItem
    Friend WithEvents PrintPreviewSubItem2 As DevExpress.XtraPrinting.Preview.PrintPreviewSubItem
    Friend WithEvents PrintPreviewSubItem4 As DevExpress.XtraPrinting.Preview.PrintPreviewSubItem
    Friend WithEvents PrintPreviewBarItem27 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewBarItem28 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BarToolbarsListItem1 As DevExpress.XtraBars.BarToolbarsListItem
    Friend WithEvents PrintPreviewSubItem3 As DevExpress.XtraPrinting.Preview.PrintPreviewSubItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents PrintControl1 As DevExpress.XtraPrinting.Control.PrintControl
    Friend WithEvents PrintPreviewBarCheckItem1 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem2 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem3 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem4 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem5 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem6 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem7 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem8 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem9 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem10 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem11 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem12 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem13 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem14 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
#End Region

    Friend WithEvents PrintPreviewBarCheckItem17 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem16 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem15 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraForm))
      Me.PrintBarManager1 = New DevExpress.XtraPrinting.Preview.PrintBarManager()
      Me.PreviewBar1 = New DevExpress.XtraPrinting.Preview.PreviewBar()
      Me.PrintPreviewBarItem2 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem3 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem4 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem5 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem6 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem7 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem8 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem9 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem10 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem11 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem12 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem13 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem14 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem15 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.ZoomBarEditItem1 = New DevExpress.XtraPrinting.Preview.ZoomBarEditItem()
      Me.PrintPreviewRepositoryItemComboBox1 = New DevExpress.XtraPrinting.Preview.PrintPreviewRepositoryItemComboBox()
      Me.PrintPreviewBarItem16 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem17 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem18 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem19 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem20 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem21 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem22 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem23 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem24 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem25 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem26 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PreviewBar2 = New DevExpress.XtraPrinting.Preview.PreviewBar()
      Me.PrintPreviewStaticItem1 = New DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem()
      Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
      Me.ProgressBarEditItem1 = New DevExpress.XtraPrinting.Preview.ProgressBarEditItem()
      Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
      Me.PrintPreviewBarItem1 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
      Me.PrintPreviewStaticItem2 = New DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem()
      Me.ZoomTrackBarEditItem1 = New DevExpress.XtraPrinting.Preview.ZoomTrackBarEditItem()
      Me.RepositoryItemZoomTrackBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar()
      Me.PreviewBar3 = New DevExpress.XtraPrinting.Preview.PreviewBar()
      Me.PrintPreviewSubItem1 = New DevExpress.XtraPrinting.Preview.PrintPreviewSubItem()
      Me.PrintPreviewSubItem2 = New DevExpress.XtraPrinting.Preview.PrintPreviewSubItem()
      Me.PrintPreviewSubItem4 = New DevExpress.XtraPrinting.Preview.PrintPreviewSubItem()
      Me.PrintPreviewBarItem27 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.PrintPreviewBarItem28 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
      Me.BarToolbarsListItem1 = New DevExpress.XtraBars.BarToolbarsListItem()
      Me.PrintPreviewSubItem3 = New DevExpress.XtraPrinting.Preview.PrintPreviewSubItem()
      Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
      Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
      Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
      Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
      Me.PrintPreviewBarCheckItem1 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem2 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem3 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem4 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem5 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem6 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem7 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem8 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem9 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem10 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem11 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem12 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem13 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem14 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem15 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem16 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintPreviewBarCheckItem17 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
      Me.PrintControl1 = New DevExpress.XtraPrinting.Control.PrintControl()
      CType(Me.PrintBarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PrintPreviewRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RepositoryItemZoomTrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'PrintBarManager1
      '
      Me.PrintBarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.PreviewBar1, Me.PreviewBar2, Me.PreviewBar3})
      Me.PrintBarManager1.DockControls.Add(Me.barDockControlTop)
      Me.PrintBarManager1.DockControls.Add(Me.barDockControlBottom)
      Me.PrintBarManager1.DockControls.Add(Me.barDockControlLeft)
      Me.PrintBarManager1.DockControls.Add(Me.barDockControlRight)
      Me.PrintBarManager1.Form = Me
      Me.PrintBarManager1.ImageStream = CType(resources.GetObject("PrintBarManager1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
      Me.PrintBarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.PrintPreviewStaticItem1, Me.BarStaticItem1, Me.ProgressBarEditItem1, Me.PrintPreviewBarItem1, Me.BarButtonItem1, Me.PrintPreviewStaticItem2, Me.ZoomTrackBarEditItem1, Me.PrintPreviewBarItem2, Me.PrintPreviewBarItem3, Me.PrintPreviewBarItem4, Me.PrintPreviewBarItem5, Me.PrintPreviewBarItem6, Me.PrintPreviewBarItem7, Me.PrintPreviewBarItem8, Me.PrintPreviewBarItem9, Me.PrintPreviewBarItem10, Me.PrintPreviewBarItem11, Me.PrintPreviewBarItem12, Me.PrintPreviewBarItem13, Me.PrintPreviewBarItem14, Me.PrintPreviewBarItem15, Me.ZoomBarEditItem1, Me.PrintPreviewBarItem16, Me.PrintPreviewBarItem17, Me.PrintPreviewBarItem18, Me.PrintPreviewBarItem19, Me.PrintPreviewBarItem20, Me.PrintPreviewBarItem21, Me.PrintPreviewBarItem22, Me.PrintPreviewBarItem23, Me.PrintPreviewBarItem24, Me.PrintPreviewBarItem25, Me.PrintPreviewBarItem26, Me.PrintPreviewSubItem1, Me.PrintPreviewSubItem2, Me.PrintPreviewSubItem3, Me.PrintPreviewSubItem4, Me.PrintPreviewBarItem27, Me.PrintPreviewBarItem28, Me.BarToolbarsListItem1, Me.PrintPreviewBarCheckItem1, Me.PrintPreviewBarCheckItem2, Me.PrintPreviewBarCheckItem3, Me.PrintPreviewBarCheckItem4, Me.PrintPreviewBarCheckItem5, Me.PrintPreviewBarCheckItem6, Me.PrintPreviewBarCheckItem7, Me.PrintPreviewBarCheckItem8, Me.PrintPreviewBarCheckItem9, Me.PrintPreviewBarCheckItem10, Me.PrintPreviewBarCheckItem11, Me.PrintPreviewBarCheckItem12, Me.PrintPreviewBarCheckItem13, Me.PrintPreviewBarCheckItem14, Me.PrintPreviewBarCheckItem15, Me.PrintPreviewBarCheckItem16, Me.PrintPreviewBarCheckItem17})
      Me.PrintBarManager1.MainMenu = Me.PreviewBar3
      Me.PrintBarManager1.MaxItemId = 57
      Me.PrintBarManager1.PreviewBar = Me.PreviewBar1
      Me.PrintBarManager1.PrintControl = Me.PrintControl1
      Me.PrintBarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1, Me.RepositoryItemZoomTrackBar1, Me.PrintPreviewRepositoryItemComboBox1})
      Me.PrintBarManager1.StatusBar = Me.PreviewBar2
      Me.PrintBarManager1.TransparentEditors = True
      '
      'PreviewBar1
      '
      Me.PreviewBar1.BarName = "Toolbar"
      Me.PreviewBar1.DockCol = 0
      Me.PreviewBar1.DockRow = 1
      Me.PreviewBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
      Me.PreviewBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem4), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem5, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem6, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem7), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem8, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem9), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem10), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem11), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem12), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem13, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem14), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem15, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ZoomBarEditItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem16), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem17, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem18), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem19), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem20), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem21, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem22), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem23), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem24, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem25), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem26, True)})
      Me.PreviewBar1.Text = "Toolbar"
      '
      'PrintPreviewBarItem2
      '
      Me.PrintPreviewBarItem2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
      Me.PrintPreviewBarItem2.Caption = "Document Map"
      Me.PrintPreviewBarItem2.Command = DevExpress.XtraPrinting.PrintingSystemCommand.DocumentMap
      Me.PrintPreviewBarItem2.Enabled = False
      Me.PrintPreviewBarItem2.Hint = "Document Map"
      Me.PrintPreviewBarItem2.Id = 7
      Me.PrintPreviewBarItem2.ImageIndex = 19
      Me.PrintPreviewBarItem2.Name = "PrintPreviewBarItem2"
      '
      'PrintPreviewBarItem3
      '
      Me.PrintPreviewBarItem3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
      Me.PrintPreviewBarItem3.Caption = "Parameters"
      Me.PrintPreviewBarItem3.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Parameters
      Me.PrintPreviewBarItem3.Enabled = False
      Me.PrintPreviewBarItem3.Hint = "Parameters"
      Me.PrintPreviewBarItem3.Id = 8
      Me.PrintPreviewBarItem3.ImageIndex = 22
      Me.PrintPreviewBarItem3.Name = "PrintPreviewBarItem3"
      '
      'PrintPreviewBarItem4
      '
      Me.PrintPreviewBarItem4.Caption = "Search"
      Me.PrintPreviewBarItem4.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Find
      Me.PrintPreviewBarItem4.Enabled = False
      Me.PrintPreviewBarItem4.Hint = "Search"
      Me.PrintPreviewBarItem4.Id = 9
      Me.PrintPreviewBarItem4.ImageIndex = 20
      Me.PrintPreviewBarItem4.Name = "PrintPreviewBarItem4"
      '
      'PrintPreviewBarItem5
      '
      Me.PrintPreviewBarItem5.Caption = "Customize"
      Me.PrintPreviewBarItem5.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Customize
      Me.PrintPreviewBarItem5.Enabled = False
      Me.PrintPreviewBarItem5.Hint = "Customize"
      Me.PrintPreviewBarItem5.Id = 10
      Me.PrintPreviewBarItem5.ImageIndex = 14
      Me.PrintPreviewBarItem5.Name = "PrintPreviewBarItem5"
      '
      'PrintPreviewBarItem6
      '
      Me.PrintPreviewBarItem6.Caption = "Open"
      Me.PrintPreviewBarItem6.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Open
      Me.PrintPreviewBarItem6.Enabled = False
      Me.PrintPreviewBarItem6.Hint = "Open a document"
      Me.PrintPreviewBarItem6.Id = 11
      Me.PrintPreviewBarItem6.ImageIndex = 23
      Me.PrintPreviewBarItem6.Name = "PrintPreviewBarItem6"
      '
      'PrintPreviewBarItem7
      '
      Me.PrintPreviewBarItem7.Caption = "Save"
      Me.PrintPreviewBarItem7.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Save
      Me.PrintPreviewBarItem7.Enabled = False
      Me.PrintPreviewBarItem7.Hint = "Save the document"
      Me.PrintPreviewBarItem7.Id = 12
      Me.PrintPreviewBarItem7.ImageIndex = 24
      Me.PrintPreviewBarItem7.Name = "PrintPreviewBarItem7"
      '
      'PrintPreviewBarItem8
      '
      Me.PrintPreviewBarItem8.Caption = "&Print..."
      Me.PrintPreviewBarItem8.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Print
      Me.PrintPreviewBarItem8.Enabled = False
      Me.PrintPreviewBarItem8.Hint = "Print"
      Me.PrintPreviewBarItem8.Id = 13
      Me.PrintPreviewBarItem8.ImageIndex = 0
      Me.PrintPreviewBarItem8.Name = "PrintPreviewBarItem8"
      '
      'PrintPreviewBarItem9
      '
      Me.PrintPreviewBarItem9.Caption = "P&rint"
      Me.PrintPreviewBarItem9.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect
      Me.PrintPreviewBarItem9.Enabled = False
      Me.PrintPreviewBarItem9.Hint = "Quick Print"
      Me.PrintPreviewBarItem9.Id = 14
      Me.PrintPreviewBarItem9.ImageIndex = 1
      Me.PrintPreviewBarItem9.Name = "PrintPreviewBarItem9"
      '
      'PrintPreviewBarItem10
      '
      Me.PrintPreviewBarItem10.Caption = "Page Set&up..."
      Me.PrintPreviewBarItem10.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageSetup
      Me.PrintPreviewBarItem10.Enabled = False
      Me.PrintPreviewBarItem10.Hint = "Page Setup"
      Me.PrintPreviewBarItem10.Id = 15
      Me.PrintPreviewBarItem10.ImageIndex = 2
      Me.PrintPreviewBarItem10.Name = "PrintPreviewBarItem10"
      '
      'PrintPreviewBarItem11
      '
      Me.PrintPreviewBarItem11.Caption = "Header And Footer"
      Me.PrintPreviewBarItem11.Command = DevExpress.XtraPrinting.PrintingSystemCommand.EditPageHF
      Me.PrintPreviewBarItem11.Enabled = False
      Me.PrintPreviewBarItem11.Hint = "Header And Footer"
      Me.PrintPreviewBarItem11.Id = 16
      Me.PrintPreviewBarItem11.ImageIndex = 15
      Me.PrintPreviewBarItem11.Name = "PrintPreviewBarItem11"
      '
      'PrintPreviewBarItem12
      '
      Me.PrintPreviewBarItem12.ActAsDropDown = True
      Me.PrintPreviewBarItem12.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
      Me.PrintPreviewBarItem12.Caption = "Scale"
      Me.PrintPreviewBarItem12.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Scale
      Me.PrintPreviewBarItem12.Enabled = False
      Me.PrintPreviewBarItem12.Hint = "Scale"
      Me.PrintPreviewBarItem12.Id = 17
      Me.PrintPreviewBarItem12.ImageIndex = 25
      Me.PrintPreviewBarItem12.Name = "PrintPreviewBarItem12"
      '
      'PrintPreviewBarItem13
      '
      Me.PrintPreviewBarItem13.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
      Me.PrintPreviewBarItem13.Caption = "Hand Tool"
      Me.PrintPreviewBarItem13.Command = DevExpress.XtraPrinting.PrintingSystemCommand.HandTool
      Me.PrintPreviewBarItem13.Enabled = False
      Me.PrintPreviewBarItem13.Hint = "Hand Tool"
      Me.PrintPreviewBarItem13.Id = 18
      Me.PrintPreviewBarItem13.ImageIndex = 16
      Me.PrintPreviewBarItem13.Name = "PrintPreviewBarItem13"
      '
      'PrintPreviewBarItem14
      '
      Me.PrintPreviewBarItem14.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
      Me.PrintPreviewBarItem14.Caption = "Magnifier"
      Me.PrintPreviewBarItem14.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Magnifier
      Me.PrintPreviewBarItem14.Enabled = False
      Me.PrintPreviewBarItem14.Hint = "Magnifier"
      Me.PrintPreviewBarItem14.Id = 19
      Me.PrintPreviewBarItem14.ImageIndex = 3
      Me.PrintPreviewBarItem14.Name = "PrintPreviewBarItem14"
      '
      'PrintPreviewBarItem15
      '
      Me.PrintPreviewBarItem15.Caption = "Zoom Out"
      Me.PrintPreviewBarItem15.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomOut
      Me.PrintPreviewBarItem15.Enabled = False
      Me.PrintPreviewBarItem15.Hint = "Zoom Out"
      Me.PrintPreviewBarItem15.Id = 20
      Me.PrintPreviewBarItem15.ImageIndex = 5
      Me.PrintPreviewBarItem15.Name = "PrintPreviewBarItem15"
      '
      'ZoomBarEditItem1
      '
      Me.ZoomBarEditItem1.Caption = "Zoom"
      Me.ZoomBarEditItem1.Edit = Me.PrintPreviewRepositoryItemComboBox1
      Me.ZoomBarEditItem1.EditValue = "100%"
      Me.ZoomBarEditItem1.Enabled = False
      Me.ZoomBarEditItem1.Hint = "Zoom"
      Me.ZoomBarEditItem1.Id = 21
      Me.ZoomBarEditItem1.Name = "ZoomBarEditItem1"
      Me.ZoomBarEditItem1.Width = 70
      '
      'PrintPreviewRepositoryItemComboBox1
      '
      Me.PrintPreviewRepositoryItemComboBox1.AutoComplete = False
      Me.PrintPreviewRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
      Me.PrintPreviewRepositoryItemComboBox1.DropDownRows = 11
      Me.PrintPreviewRepositoryItemComboBox1.Name = "PrintPreviewRepositoryItemComboBox1"
      Me.PrintPreviewRepositoryItemComboBox1.UseParentBackground = True
      '
      'PrintPreviewBarItem16
      '
      Me.PrintPreviewBarItem16.Caption = "Zoom In"
      Me.PrintPreviewBarItem16.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomIn
      Me.PrintPreviewBarItem16.Enabled = False
      Me.PrintPreviewBarItem16.Hint = "Zoom In"
      Me.PrintPreviewBarItem16.Id = 22
      Me.PrintPreviewBarItem16.ImageIndex = 4
      Me.PrintPreviewBarItem16.Name = "PrintPreviewBarItem16"
      '
      'PrintPreviewBarItem17
      '
      Me.PrintPreviewBarItem17.Caption = "First Page"
      Me.PrintPreviewBarItem17.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowFirstPage
      Me.PrintPreviewBarItem17.Enabled = False
      Me.PrintPreviewBarItem17.Hint = "First Page"
      Me.PrintPreviewBarItem17.Id = 23
      Me.PrintPreviewBarItem17.ImageIndex = 7
      Me.PrintPreviewBarItem17.Name = "PrintPreviewBarItem17"
      '
      'PrintPreviewBarItem18
      '
      Me.PrintPreviewBarItem18.Caption = "Previous Page"
      Me.PrintPreviewBarItem18.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowPrevPage
      Me.PrintPreviewBarItem18.Enabled = False
      Me.PrintPreviewBarItem18.Hint = "Previous Page"
      Me.PrintPreviewBarItem18.Id = 24
      Me.PrintPreviewBarItem18.ImageIndex = 8
      Me.PrintPreviewBarItem18.Name = "PrintPreviewBarItem18"
      '
      'PrintPreviewBarItem19
      '
      Me.PrintPreviewBarItem19.Caption = "Next Page"
      Me.PrintPreviewBarItem19.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowNextPage
      Me.PrintPreviewBarItem19.Enabled = False
      Me.PrintPreviewBarItem19.Hint = "Next Page"
      Me.PrintPreviewBarItem19.Id = 25
      Me.PrintPreviewBarItem19.ImageIndex = 9
      Me.PrintPreviewBarItem19.Name = "PrintPreviewBarItem19"
      '
      'PrintPreviewBarItem20
      '
      Me.PrintPreviewBarItem20.Caption = "Last Page"
      Me.PrintPreviewBarItem20.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowLastPage
      Me.PrintPreviewBarItem20.Enabled = False
      Me.PrintPreviewBarItem20.Hint = "Last Page"
      Me.PrintPreviewBarItem20.Id = 26
      Me.PrintPreviewBarItem20.ImageIndex = 10
      Me.PrintPreviewBarItem20.Name = "PrintPreviewBarItem20"
      '
      'PrintPreviewBarItem21
      '
      Me.PrintPreviewBarItem21.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
      Me.PrintPreviewBarItem21.Caption = "Multiple Pages"
      Me.PrintPreviewBarItem21.Command = DevExpress.XtraPrinting.PrintingSystemCommand.MultiplePages
      Me.PrintPreviewBarItem21.Enabled = False
      Me.PrintPreviewBarItem21.Hint = "Multiple Pages"
      Me.PrintPreviewBarItem21.Id = 27
      Me.PrintPreviewBarItem21.ImageIndex = 11
      Me.PrintPreviewBarItem21.Name = "PrintPreviewBarItem21"
      '
      'PrintPreviewBarItem22
      '
      Me.PrintPreviewBarItem22.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
      Me.PrintPreviewBarItem22.Caption = "&Color..."
      Me.PrintPreviewBarItem22.Command = DevExpress.XtraPrinting.PrintingSystemCommand.FillBackground
      Me.PrintPreviewBarItem22.Enabled = False
      Me.PrintPreviewBarItem22.Hint = "Background"
      Me.PrintPreviewBarItem22.Id = 28
      Me.PrintPreviewBarItem22.ImageIndex = 12
      Me.PrintPreviewBarItem22.Name = "PrintPreviewBarItem22"
      '
      'PrintPreviewBarItem23
      '
      Me.PrintPreviewBarItem23.Caption = "&Watermark..."
      Me.PrintPreviewBarItem23.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Watermark
      Me.PrintPreviewBarItem23.Enabled = False
      Me.PrintPreviewBarItem23.Hint = "Watermark"
      Me.PrintPreviewBarItem23.Id = 29
      Me.PrintPreviewBarItem23.ImageIndex = 21
      Me.PrintPreviewBarItem23.Name = "PrintPreviewBarItem23"
      '
      'PrintPreviewBarItem24
      '
      Me.PrintPreviewBarItem24.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
      Me.PrintPreviewBarItem24.Caption = "Export Document..."
      Me.PrintPreviewBarItem24.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile
      Me.PrintPreviewBarItem24.Enabled = False
      Me.PrintPreviewBarItem24.Hint = "Export Document..."
      Me.PrintPreviewBarItem24.Id = 30
      Me.PrintPreviewBarItem24.ImageIndex = 18
      Me.PrintPreviewBarItem24.Name = "PrintPreviewBarItem24"
      '
      'PrintPreviewBarItem25
      '
      Me.PrintPreviewBarItem25.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
      Me.PrintPreviewBarItem25.Caption = "Send via E-Mail..."
      Me.PrintPreviewBarItem25.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendFile
      Me.PrintPreviewBarItem25.Enabled = False
      Me.PrintPreviewBarItem25.Hint = "Send via E-Mail..."
      Me.PrintPreviewBarItem25.Id = 31
      Me.PrintPreviewBarItem25.ImageIndex = 17
      Me.PrintPreviewBarItem25.Name = "PrintPreviewBarItem25"
      '
      'PrintPreviewBarItem26
      '
      Me.PrintPreviewBarItem26.Caption = "E&xit"
      Me.PrintPreviewBarItem26.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ClosePreview
      Me.PrintPreviewBarItem26.Enabled = False
      Me.PrintPreviewBarItem26.Hint = "Close Preview"
      Me.PrintPreviewBarItem26.Id = 32
      Me.PrintPreviewBarItem26.ImageIndex = 13
      Me.PrintPreviewBarItem26.Name = "PrintPreviewBarItem26"
      '
      'PreviewBar2
      '
      Me.PreviewBar2.BarName = "Status Bar"
      Me.PreviewBar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
      Me.PreviewBar2.DockCol = 0
      Me.PreviewBar2.DockRow = 0
      Me.PreviewBar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
      Me.PreviewBar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewStaticItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem1, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ProgressBarEditItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewStaticItem2, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ZoomTrackBarEditItem1)})
      Me.PreviewBar2.OptionsBar.AllowQuickCustomization = False
      Me.PreviewBar2.OptionsBar.DrawDragBorder = False
      Me.PreviewBar2.OptionsBar.UseWholeRow = True
      Me.PreviewBar2.Text = "Status Bar"
      '
      'PrintPreviewStaticItem1
      '
      Me.PrintPreviewStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
      Me.PrintPreviewStaticItem1.Caption = "Nothing"
      Me.PrintPreviewStaticItem1.Id = 0
      Me.PrintPreviewStaticItem1.LeftIndent = 1
      Me.PrintPreviewStaticItem1.Name = "PrintPreviewStaticItem1"
      Me.PrintPreviewStaticItem1.RightIndent = 1
      Me.PrintPreviewStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near
      Me.PrintPreviewStaticItem1.Type = "PageOfPages"
      '
      'BarStaticItem1
      '
      Me.BarStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
      Me.BarStaticItem1.Id = 1
      Me.BarStaticItem1.Name = "BarStaticItem1"
      Me.BarStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near
      Me.BarStaticItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime
      '
      'ProgressBarEditItem1
      '
      Me.ProgressBarEditItem1.Edit = Me.RepositoryItemProgressBar1
      Me.ProgressBarEditItem1.EditHeight = 12
      Me.ProgressBarEditItem1.Id = 2
      Me.ProgressBarEditItem1.Name = "ProgressBarEditItem1"
      Me.ProgressBarEditItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
      Me.ProgressBarEditItem1.Width = 150
      '
      'RepositoryItemProgressBar1
      '
      Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
      Me.RepositoryItemProgressBar1.UseParentBackground = True
      '
      'PrintPreviewBarItem1
      '
      Me.PrintPreviewBarItem1.Caption = "Stop"
      Me.PrintPreviewBarItem1.Command = DevExpress.XtraPrinting.PrintingSystemCommand.StopPageBuilding
      Me.PrintPreviewBarItem1.Enabled = False
      Me.PrintPreviewBarItem1.Hint = "Stop"
      Me.PrintPreviewBarItem1.Id = 3
      Me.PrintPreviewBarItem1.Name = "PrintPreviewBarItem1"
      Me.PrintPreviewBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
      '
      'BarButtonItem1
      '
      Me.BarButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
      Me.BarButtonItem1.Enabled = False
      Me.BarButtonItem1.Id = 4
      Me.BarButtonItem1.Name = "BarButtonItem1"
      Me.BarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime
      '
      'PrintPreviewStaticItem2
      '
      Me.PrintPreviewStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
      Me.PrintPreviewStaticItem2.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
      Me.PrintPreviewStaticItem2.Caption = "100%"
      Me.PrintPreviewStaticItem2.Id = 5
      Me.PrintPreviewStaticItem2.Name = "PrintPreviewStaticItem2"
      Me.PrintPreviewStaticItem2.TextAlignment = System.Drawing.StringAlignment.Far
      Me.PrintPreviewStaticItem2.Type = "ZoomFactor"
      Me.PrintPreviewStaticItem2.Width = 40
      '
      'ZoomTrackBarEditItem1
      '
      Me.ZoomTrackBarEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
      Me.ZoomTrackBarEditItem1.Edit = Me.RepositoryItemZoomTrackBar1
      Me.ZoomTrackBarEditItem1.EditValue = 90
      Me.ZoomTrackBarEditItem1.Enabled = False
      Me.ZoomTrackBarEditItem1.Id = 6
      Me.ZoomTrackBarEditItem1.Name = "ZoomTrackBarEditItem1"
      Me.ZoomTrackBarEditItem1.Range = New Integer() {10, 500}
      Me.ZoomTrackBarEditItem1.Width = 140
      '
      'RepositoryItemZoomTrackBar1
      '
      Me.RepositoryItemZoomTrackBar1.Alignment = DevExpress.Utils.VertAlignment.Center
      Me.RepositoryItemZoomTrackBar1.AllowFocused = False
      Me.RepositoryItemZoomTrackBar1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
      Me.RepositoryItemZoomTrackBar1.Maximum = 180
      Me.RepositoryItemZoomTrackBar1.Name = "RepositoryItemZoomTrackBar1"
      Me.RepositoryItemZoomTrackBar1.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight
      Me.RepositoryItemZoomTrackBar1.UseParentBackground = True
      '
      'PreviewBar3
      '
      Me.PreviewBar3.BarName = "Main Menu"
      Me.PreviewBar3.DockCol = 0
      Me.PreviewBar3.DockRow = 0
      Me.PreviewBar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
      Me.PreviewBar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewSubItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewSubItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewSubItem3)})
      Me.PreviewBar3.OptionsBar.MultiLine = True
      Me.PreviewBar3.OptionsBar.UseWholeRow = True
      Me.PreviewBar3.Text = "Main Menu"
      '
      'PrintPreviewSubItem1
      '
      Me.PrintPreviewSubItem1.Caption = "&File"
      Me.PrintPreviewSubItem1.Command = DevExpress.XtraPrinting.PrintingSystemCommand.File
      Me.PrintPreviewSubItem1.Id = 33
      Me.PrintPreviewSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem10), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem8), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem9), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem24, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem25), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem26, True)})
      Me.PrintPreviewSubItem1.Name = "PrintPreviewSubItem1"
      '
      'PrintPreviewSubItem2
      '
      Me.PrintPreviewSubItem2.Caption = "&View"
      Me.PrintPreviewSubItem2.Command = DevExpress.XtraPrinting.PrintingSystemCommand.View
      Me.PrintPreviewSubItem2.Id = 34
      Me.PrintPreviewSubItem2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewSubItem4, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarToolbarsListItem1, True)})
      Me.PrintPreviewSubItem2.Name = "PrintPreviewSubItem2"
      '
      'PrintPreviewSubItem4
      '
      Me.PrintPreviewSubItem4.Caption = "&Page Layout"
      Me.PrintPreviewSubItem4.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayout
      Me.PrintPreviewSubItem4.Id = 36
      Me.PrintPreviewSubItem4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem27), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem28)})
      Me.PrintPreviewSubItem4.Name = "PrintPreviewSubItem4"
      '
      'PrintPreviewBarItem27
      '
      Me.PrintPreviewBarItem27.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
      Me.PrintPreviewBarItem27.Caption = "&Facing"
      Me.PrintPreviewBarItem27.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayoutFacing
      Me.PrintPreviewBarItem27.Enabled = False
      Me.PrintPreviewBarItem27.GroupIndex = 100
      Me.PrintPreviewBarItem27.Id = 37
      Me.PrintPreviewBarItem27.Name = "PrintPreviewBarItem27"
      '
      'PrintPreviewBarItem28
      '
      Me.PrintPreviewBarItem28.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
      Me.PrintPreviewBarItem28.Caption = "&Continuous"
      Me.PrintPreviewBarItem28.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayoutContinuous
      Me.PrintPreviewBarItem28.Enabled = False
      Me.PrintPreviewBarItem28.GroupIndex = 100
      Me.PrintPreviewBarItem28.Id = 38
      Me.PrintPreviewBarItem28.Name = "PrintPreviewBarItem28"
      '
      'BarToolbarsListItem1
      '
      Me.BarToolbarsListItem1.Caption = "Bars"
      Me.BarToolbarsListItem1.Id = 39
      Me.BarToolbarsListItem1.Name = "BarToolbarsListItem1"
      '
      'PrintPreviewSubItem3
      '
      Me.PrintPreviewSubItem3.Caption = "&Background"
      Me.PrintPreviewSubItem3.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Background
      Me.PrintPreviewSubItem3.Id = 35
      Me.PrintPreviewSubItem3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem22), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem23)})
      Me.PrintPreviewSubItem3.Name = "PrintPreviewSubItem3"
      '
      'barDockControlTop
      '
      Me.barDockControlTop.CausesValidation = False
      Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
      Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
      Me.barDockControlTop.Size = New System.Drawing.Size(898, 53)
      '
      'barDockControlBottom
      '
      Me.barDockControlBottom.CausesValidation = False
      Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.barDockControlBottom.Location = New System.Drawing.Point(0, 443)
      Me.barDockControlBottom.Size = New System.Drawing.Size(898, 28)
      '
      'barDockControlLeft
      '
      Me.barDockControlLeft.CausesValidation = False
      Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
      Me.barDockControlLeft.Location = New System.Drawing.Point(0, 53)
      Me.barDockControlLeft.Size = New System.Drawing.Size(0, 390)
      '
      'barDockControlRight
      '
      Me.barDockControlRight.CausesValidation = False
      Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
      Me.barDockControlRight.Location = New System.Drawing.Point(898, 53)
      Me.barDockControlRight.Size = New System.Drawing.Size(0, 390)
      '
      'PrintPreviewBarCheckItem1
      '
      Me.PrintPreviewBarCheckItem1.Caption = "PDF File"
      Me.PrintPreviewBarCheckItem1.Checked = True
      Me.PrintPreviewBarCheckItem1.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportPdf
      Me.PrintPreviewBarCheckItem1.Enabled = False
      Me.PrintPreviewBarCheckItem1.GroupIndex = 2
      Me.PrintPreviewBarCheckItem1.Hint = "PDF File"
      Me.PrintPreviewBarCheckItem1.Id = 40
      Me.PrintPreviewBarCheckItem1.Name = "PrintPreviewBarCheckItem1"
      '
      'PrintPreviewBarCheckItem2
      '
      Me.PrintPreviewBarCheckItem2.Caption = "HTML File"
      Me.PrintPreviewBarCheckItem2.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm
      Me.PrintPreviewBarCheckItem2.Enabled = False
      Me.PrintPreviewBarCheckItem2.GroupIndex = 2
      Me.PrintPreviewBarCheckItem2.Hint = "HTML File"
      Me.PrintPreviewBarCheckItem2.Id = 41
      Me.PrintPreviewBarCheckItem2.Name = "PrintPreviewBarCheckItem2"
      '
      'PrintPreviewBarCheckItem3
      '
      Me.PrintPreviewBarCheckItem3.Caption = "MHT File"
      Me.PrintPreviewBarCheckItem3.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportMht
      Me.PrintPreviewBarCheckItem3.Enabled = False
      Me.PrintPreviewBarCheckItem3.GroupIndex = 2
      Me.PrintPreviewBarCheckItem3.Hint = "MHT File"
      Me.PrintPreviewBarCheckItem3.Id = 42
      Me.PrintPreviewBarCheckItem3.Name = "PrintPreviewBarCheckItem3"
      '
      'PrintPreviewBarCheckItem4
      '
      Me.PrintPreviewBarCheckItem4.Caption = "RTF File"
      Me.PrintPreviewBarCheckItem4.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportRtf
      Me.PrintPreviewBarCheckItem4.Enabled = False
      Me.PrintPreviewBarCheckItem4.GroupIndex = 2
      Me.PrintPreviewBarCheckItem4.Hint = "RTF File"
      Me.PrintPreviewBarCheckItem4.Id = 43
      Me.PrintPreviewBarCheckItem4.Name = "PrintPreviewBarCheckItem4"
      '
      'PrintPreviewBarCheckItem5
      '
      Me.PrintPreviewBarCheckItem5.Caption = "XLS File"
      Me.PrintPreviewBarCheckItem5.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
      Me.PrintPreviewBarCheckItem5.Enabled = False
      Me.PrintPreviewBarCheckItem5.GroupIndex = 2
      Me.PrintPreviewBarCheckItem5.Hint = "XLS File"
      Me.PrintPreviewBarCheckItem5.Id = 44
      Me.PrintPreviewBarCheckItem5.Name = "PrintPreviewBarCheckItem5"
      '
      'PrintPreviewBarCheckItem6
      '
      Me.PrintPreviewBarCheckItem6.Caption = "XLSX File"
      Me.PrintPreviewBarCheckItem6.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXlsx
      Me.PrintPreviewBarCheckItem6.Enabled = False
      Me.PrintPreviewBarCheckItem6.GroupIndex = 2
      Me.PrintPreviewBarCheckItem6.Hint = "XLSX File"
      Me.PrintPreviewBarCheckItem6.Id = 45
      Me.PrintPreviewBarCheckItem6.Name = "PrintPreviewBarCheckItem6"
      '
      'PrintPreviewBarCheckItem7
      '
      Me.PrintPreviewBarCheckItem7.Caption = "CSV File"
      Me.PrintPreviewBarCheckItem7.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportCsv
      Me.PrintPreviewBarCheckItem7.Enabled = False
      Me.PrintPreviewBarCheckItem7.GroupIndex = 2
      Me.PrintPreviewBarCheckItem7.Hint = "CSV File"
      Me.PrintPreviewBarCheckItem7.Id = 46
      Me.PrintPreviewBarCheckItem7.Name = "PrintPreviewBarCheckItem7"
      '
      'PrintPreviewBarCheckItem8
      '
      Me.PrintPreviewBarCheckItem8.Caption = "Text File"
      Me.PrintPreviewBarCheckItem8.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportTxt
      Me.PrintPreviewBarCheckItem8.Enabled = False
      Me.PrintPreviewBarCheckItem8.GroupIndex = 2
      Me.PrintPreviewBarCheckItem8.Hint = "Text File"
      Me.PrintPreviewBarCheckItem8.Id = 47
      Me.PrintPreviewBarCheckItem8.Name = "PrintPreviewBarCheckItem8"
      '
      'PrintPreviewBarCheckItem9
      '
      Me.PrintPreviewBarCheckItem9.Caption = "Image File"
      Me.PrintPreviewBarCheckItem9.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportGraphic
      Me.PrintPreviewBarCheckItem9.Enabled = False
      Me.PrintPreviewBarCheckItem9.GroupIndex = 2
      Me.PrintPreviewBarCheckItem9.Hint = "Image File"
      Me.PrintPreviewBarCheckItem9.Id = 48
      Me.PrintPreviewBarCheckItem9.Name = "PrintPreviewBarCheckItem9"
      '
      'PrintPreviewBarCheckItem10
      '
      Me.PrintPreviewBarCheckItem10.Caption = "PDF File"
      Me.PrintPreviewBarCheckItem10.Checked = True
      Me.PrintPreviewBarCheckItem10.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendPdf
      Me.PrintPreviewBarCheckItem10.Enabled = False
      Me.PrintPreviewBarCheckItem10.GroupIndex = 1
      Me.PrintPreviewBarCheckItem10.Hint = "PDF File"
      Me.PrintPreviewBarCheckItem10.Id = 49
      Me.PrintPreviewBarCheckItem10.Name = "PrintPreviewBarCheckItem10"
      '
      'PrintPreviewBarCheckItem11
      '
      Me.PrintPreviewBarCheckItem11.Caption = "MHT File"
      Me.PrintPreviewBarCheckItem11.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendMht
      Me.PrintPreviewBarCheckItem11.Enabled = False
      Me.PrintPreviewBarCheckItem11.GroupIndex = 1
      Me.PrintPreviewBarCheckItem11.Hint = "MHT File"
      Me.PrintPreviewBarCheckItem11.Id = 50
      Me.PrintPreviewBarCheckItem11.Name = "PrintPreviewBarCheckItem11"
      '
      'PrintPreviewBarCheckItem12
      '
      Me.PrintPreviewBarCheckItem12.Caption = "RTF File"
      Me.PrintPreviewBarCheckItem12.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendRtf
      Me.PrintPreviewBarCheckItem12.Enabled = False
      Me.PrintPreviewBarCheckItem12.GroupIndex = 1
      Me.PrintPreviewBarCheckItem12.Hint = "RTF File"
      Me.PrintPreviewBarCheckItem12.Id = 51
      Me.PrintPreviewBarCheckItem12.Name = "PrintPreviewBarCheckItem12"
      '
      'PrintPreviewBarCheckItem13
      '
      Me.PrintPreviewBarCheckItem13.Caption = "XLS File"
      Me.PrintPreviewBarCheckItem13.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendXls
      Me.PrintPreviewBarCheckItem13.Enabled = False
      Me.PrintPreviewBarCheckItem13.GroupIndex = 1
      Me.PrintPreviewBarCheckItem13.Hint = "XLS File"
      Me.PrintPreviewBarCheckItem13.Id = 52
      Me.PrintPreviewBarCheckItem13.Name = "PrintPreviewBarCheckItem13"
      '
      'PrintPreviewBarCheckItem14
      '
      Me.PrintPreviewBarCheckItem14.Caption = "XLSX File"
      Me.PrintPreviewBarCheckItem14.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendXlsx
      Me.PrintPreviewBarCheckItem14.Enabled = False
      Me.PrintPreviewBarCheckItem14.GroupIndex = 1
      Me.PrintPreviewBarCheckItem14.Hint = "XLSX File"
      Me.PrintPreviewBarCheckItem14.Id = 53
      Me.PrintPreviewBarCheckItem14.Name = "PrintPreviewBarCheckItem14"
      '
      'PrintPreviewBarCheckItem15
      '
      Me.PrintPreviewBarCheckItem15.Caption = "CSV File"
      Me.PrintPreviewBarCheckItem15.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendCsv
      Me.PrintPreviewBarCheckItem15.Enabled = False
      Me.PrintPreviewBarCheckItem15.GroupIndex = 1
      Me.PrintPreviewBarCheckItem15.Hint = "CSV File"
      Me.PrintPreviewBarCheckItem15.Id = 54
      Me.PrintPreviewBarCheckItem15.Name = "PrintPreviewBarCheckItem15"
      '
      'PrintPreviewBarCheckItem16
      '
      Me.PrintPreviewBarCheckItem16.Caption = "Text File"
      Me.PrintPreviewBarCheckItem16.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendTxt
      Me.PrintPreviewBarCheckItem16.Enabled = False
      Me.PrintPreviewBarCheckItem16.GroupIndex = 1
      Me.PrintPreviewBarCheckItem16.Hint = "Text File"
      Me.PrintPreviewBarCheckItem16.Id = 55
      Me.PrintPreviewBarCheckItem16.Name = "PrintPreviewBarCheckItem16"
      '
      'PrintPreviewBarCheckItem17
      '
      Me.PrintPreviewBarCheckItem17.Caption = "Image File"
      Me.PrintPreviewBarCheckItem17.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendGraphic
      Me.PrintPreviewBarCheckItem17.Enabled = False
      Me.PrintPreviewBarCheckItem17.GroupIndex = 1
      Me.PrintPreviewBarCheckItem17.Hint = "Image File"
      Me.PrintPreviewBarCheckItem17.Id = 56
      Me.PrintPreviewBarCheckItem17.Name = "PrintPreviewBarCheckItem17"
      '
      'PrintControl1
      '
      Me.PrintControl1.BackColor = System.Drawing.Color.Empty
      Me.PrintControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.PrintControl1.ForeColor = System.Drawing.Color.Empty
      Me.PrintControl1.IsMetric = True
      Me.PrintControl1.Location = New System.Drawing.Point(0, 53)
      Me.PrintControl1.Name = "PrintControl1"
      Me.PrintControl1.Size = New System.Drawing.Size(898, 390)
      Me.PrintControl1.TabIndex = 4
      Me.PrintControl1.TooltipFont = New System.Drawing.Font("Tahoma", 8.25!)
      '
      'XtraForm
      '
      Me.ClientSize = New System.Drawing.Size(898, 471)
      Me.Controls.Add(Me.PrintControl1)
      Me.Controls.Add(Me.barDockControlLeft)
      Me.Controls.Add(Me.barDockControlRight)
      Me.Controls.Add(Me.barDockControlBottom)
      Me.Controls.Add(Me.barDockControlTop)
      Me.Name = "XtraForm"
      CType(Me.PrintBarManager1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PrintPreviewRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RepositoryItemZoomTrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub
  End Class
End Namespace