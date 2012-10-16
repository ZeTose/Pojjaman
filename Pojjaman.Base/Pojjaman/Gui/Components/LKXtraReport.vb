Imports DevExpress.XtraReports.UI
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Xml
Imports DevExpress.XtraPrinting.Drawing
Imports System.Text.RegularExpressions
Imports System.Globalization

Public Class LKXtraReport

  Public Property Entity As ISimpleEntity
  Public Property PrintingEntity As INewPrintableEntity
  Public Property FileName As String

  Public ReadOnly Property CompanyLogo As Image
    Get
      Return EntitySimpleSchema.GetCompanyConfigLogo
    End Get
  End Property
  Public ReadOnly Property AllCompanyConfiguration As DataSet
    Get
      Return EntitySimpleSchema.GetCompanyConfig()
    End Get
  End Property
  Public ReadOnly Property IsShowWaterMark As Boolean
    Get
      Return CBool(Configuration.GetConfig("ShowWaterMarkInExtraReports"))
    End Get
  End Property

  Public Sub New()
    MyBase.New()
  End Sub

  Public Sub New(_entity As ISimpleEntity, _fileName As String, _printingEntity As INewPrintableEntity)
    Me.Entity = _entity
    Me.FileName = _fileName
    Me.PrintingEntity = _printingEntity
  End Sub

  Public Function GetXtraReport() As XtraReport
    Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
    Dim newReport As DevExpress.XtraReports.UI.XtraReport
    Dim m_userHash As New Hashtable
    Dim m_employeeHash As New Hashtable
    'AddHandler newReport.AfterPrint, AddressOf AfterPrint
    'newReport = New XtraReport
    Try
      newReport = XtraReport.FromFile(Me.FileName, True)

      Dim ds As DataSet
      ds = GetDataFromEntitySchemaId(newReport.DataSourceSchema)

      '--Watermark-- 
      If IsShowWaterMark Then
        newReport.Watermark.Text = ""
        newReport.Watermark.TextDirection = DirectionMode.ForwardDiagonal
        newReport.Watermark.Font = New Font("Times New Roman", 72)
        newReport.Watermark.ForeColor = Color.Red
        'newReport.Watermark.Transparency = 150
        newReport.Watermark.TextTransparency = 180
        newReport.Watermark.ShowBehind = True
        'newReport.Watermark.PageRange = "1,3-5"
        'newReport.Watermark.Image = Bitmap.FromFile("D:\SVN\BuiLKSource\BuilkCostControl\trunk\BuilkMvc\Images\companyprofile\longkong_logo.jpg")
        'newReport.Watermark.ImageAlign = ContentAlignment.TopCenter
        'newReport.Watermark.ImageTiling = False
        'newReport.Watermark.ImageViewMode = ImageViewMode.Clip
        'newReport.Watermark.ImageTransparency = 100
        If TypeOf Me.PrintingEntity Is IDocStatus Then
          Dim newWatermarkText As String = CType(Me.PrintingEntity, IDocStatus).DocStatus
          newReport.Watermark.Text = newWatermarkText
        Else

        End If
      End If
      '--Watermark-- 

      '--Data Source Data--
      newReport.DataSource = ds
      '--Data Source Data--

      '--Company Logo--
      Dim xrLogoPictureBox As Object = newReport.FindControl("CompanyLogo", True)
      If Not xrLogoPictureBox Is Nothing AndAlso TypeOf xrLogoPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
        CType(xrLogoPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = CompanyLogo
      End If
      '--Company Logo--

      '--Company Config--
      Dim rows As New DataRowHelper(Me.AllCompanyConfiguration.Tables(0).Rows(0))
      Dim xrCompanyNameRichText As Object = newReport.FindControl("CompanyName", True)
      If Not xrCompanyNameRichText Is Nothing AndAlso TypeOf xrCompanyNameRichText Is DevExpress.XtraReports.UI.XRLabel Then
        CType(xrCompanyNameRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyName", "")
      End If
      Dim xrCompanyAddressRichText As Object = newReport.FindControl("CompanyAddress", True)
      If Not xrCompanyAddressRichText Is Nothing AndAlso TypeOf xrCompanyAddressRichText Is DevExpress.XtraReports.UI.XRLabel Then
        CType(xrCompanyAddressRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyAddress", "")
      End If
      Dim xrCompanyBillingAddressRichText As Object = newReport.FindControl("CompanyBillingAddress", True)
      If Not xrCompanyBillingAddressRichText Is Nothing AndAlso TypeOf xrCompanyBillingAddressRichText Is DevExpress.XtraReports.UI.XRLabel Then
        CType(xrCompanyBillingAddressRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyBillingAddress", "")
      End If
      Dim xrCompanyPhoneFaxRichText As Object = newReport.FindControl("CompanyPhoneCompanyFax", True)
      If Not xrCompanyPhoneFaxRichText Is Nothing AndAlso TypeOf xrCompanyPhoneFaxRichText Is DevExpress.XtraReports.UI.XRLabel Then
        CType(xrCompanyPhoneFaxRichText, DevExpress.XtraReports.UI.XRLabel).Text = String.Format("โทรศัพท์ {0} โทรสาร {1}", rows.GetValue(Of String)("CompanyPhone", ""), rows.GetValue(Of String)("CompanyFax", ""))
      End If
      Dim xrCompanyPhoneRichText As Object = newReport.FindControl("CompanyPhone", True)
      If Not xrCompanyPhoneRichText Is Nothing AndAlso TypeOf xrCompanyPhoneRichText Is DevExpress.XtraReports.UI.XRLabel Then
        CType(xrCompanyPhoneRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyPhone", "")
      End If
      Dim xrCompanyFaxRichText As Object = newReport.FindControl("CompanyFax", True)
      If Not xrCompanyFaxRichText Is Nothing AndAlso TypeOf xrCompanyFaxRichText Is DevExpress.XtraReports.UI.XRLabel Then
        CType(xrCompanyFaxRichText, DevExpress.XtraReports.UI.XRLabel).Text = rows.GetValue(Of String)("CompanyFax", "")
      End If
      Dim xrCompanyTaxIdRichText As Object = newReport.FindControl("CompanyTaxId", True)
      If Not xrCompanyTaxIdRichText Is Nothing AndAlso TypeOf xrCompanyTaxIdRichText Is DevExpress.XtraReports.UI.XRLabel Then
        CType(xrCompanyTaxIdRichText, DevExpress.XtraReports.UI.XRLabel).Text = String.Format("เลขประจำตัวผู้เสียภาษี {0}", rows.GetValue(Of String)("CompanyTaxId", ""))
      End If
      '--Company Config--

      '--Signature Image Name and Date--
      If TypeOf Me.Entity Is IDocumentPersonAble Then
        Dim docPerson As IDocumentPersonAble = CType(Me.Entity, IDocumentPersonAble)
        If Not docPerson Is Nothing AndAlso Not docPerson.DocumentEditedUser Is Nothing Then
          Dim _docEditedUser As DocumentEditedUser = docPerson.DocumentEditedUser
          If Not docPerson.DocumentEditedUser.Employee Is Nothing AndAlso docPerson.DocumentEditedUser.Employee.Originated Then
            Dim xrEmployeePictureBox As Object = newReport.FindControl("Employee", True)
            If Not xrEmployeePictureBox Is Nothing AndAlso TypeOf xrEmployeePictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
              Dim img As Image
              If Not m_employeeHash.ContainsKey(CStr(docPerson.DocumentEditedUser.Employee.Id)) Then
                img = CType(Employee.GetSignator(CStr(docPerson.DocumentEditedUser.Employee.Id)), Image)
                m_employeeHash.Add(CStr(docPerson.DocumentEditedUser.Employee.Id), img)
              Else
                img = CType(m_employeeHash(CStr(docPerson.DocumentEditedUser.Employee.Id)), Image)
              End If
              CType(xrEmployeePictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
            End If
            Dim xrEmployeeRichText As Object = newReport.FindControl("EmployeeName", True)
            If Not xrEmployeeRichText Is Nothing AndAlso TypeOf xrEmployeeRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrEmployeeRichText, DevExpress.XtraReports.UI.XRLabel).Text = docPerson.DocumentEditedUser.Employee.Name
            End If
          End If
          If Not _docEditedUser.CanceledUser Is Nothing Then
            Dim xrCanceledUserPictureBox As Object = newReport.FindControl("Cancel", True)
            If Not xrCanceledUserPictureBox Is Nothing AndAlso TypeOf xrCanceledUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
              Dim img As Image
              If Not m_userHash.ContainsKey(CStr(_docEditedUser.CanceledUser.UserId)) Then
                img = CType(User.GetSignator(CStr(_docEditedUser.CanceledUser.UserId)), Image)
                m_userHash.Add(CStr(_docEditedUser.CanceledUser.UserId), img)
              Else
                img = CType(m_userHash(CStr(_docEditedUser.CanceledUser.UserId)), Image)
              End If
              CType(xrCanceledUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
            End If
            Dim xrCanceledUserRichText As Object = newReport.FindControl("CancelName", True)
            If Not xrCanceledUserRichText Is Nothing AndAlso TypeOf xrCanceledUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrCanceledUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CanceledUser.UserName
            End If
            Dim xrCanceledUserDateRichText As Object = newReport.FindControl("CancelDate", True)
            If Not xrCanceledUserDateRichText Is Nothing AndAlso TypeOf xrCanceledUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrCanceledUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CanceledUser.EditedDate.ToShortDateString
            End If
          End If
          If Not _docEditedUser.CreatedUser Is Nothing Then
            Dim xrCreatedUserPictureBox As Object = newReport.FindControl("Create", True)
            If Not xrCreatedUserPictureBox Is Nothing AndAlso TypeOf xrCreatedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
              Dim img As Image
              If Not m_userHash.ContainsKey(CStr(_docEditedUser.CreatedUser.UserId)) Then
                img = CType(User.GetSignator(CStr(_docEditedUser.CreatedUser.UserId)), Image)
                m_userHash.Add(CStr(_docEditedUser.CreatedUser.UserId), img)
              Else
                img = CType(m_userHash(CStr(_docEditedUser.CreatedUser.UserId)), Image)
              End If
              CType(xrCreatedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
            End If
            Dim xrCreatedUserRichText As Object = newReport.FindControl("CreateName", True)
            If Not xrCreatedUserRichText Is Nothing AndAlso TypeOf xrCreatedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrCreatedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CreatedUser.UserName
            End If
            Dim xrCreatedUserDateRichText As Object = newReport.FindControl("CreateDate", True)
            If Not xrCreatedUserDateRichText Is Nothing AndAlso TypeOf xrCreatedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrCreatedUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.CreatedUser.EditedDate.ToShortDateString
            End If
          End If
          If Not _docEditedUser.EditedUser Is Nothing Then
            Dim xrEditedUserPictureBox As Object = newReport.FindControl("Edite", True)
            If Not xrEditedUserPictureBox Is Nothing AndAlso TypeOf xrEditedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
              Dim img As Image
              If Not m_userHash.ContainsKey(CStr(_docEditedUser.EditedUser.UserId)) Then
                img = CType(User.GetSignator(CStr(_docEditedUser.EditedUser.UserId)), Image)
                m_userHash.Add(CStr(_docEditedUser.EditedUser.UserId), img)
              Else
                img = CType(m_userHash(CStr(_docEditedUser.EditedUser.UserId)), Image)
              End If
              CType(xrEditedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
            End If
            Dim xrEditedUserRichText As Object = newReport.FindControl("EditeName", True)
            If Not xrEditedUserRichText Is Nothing AndAlso TypeOf xrEditedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrEditedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.EditedUser.UserName
            End If
            Dim xrEditedUserDateRichText As Object = newReport.FindControl("EditeDate", True)
            If Not xrEditedUserDateRichText Is Nothing AndAlso TypeOf xrEditedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrEditedUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.EditedUser.EditedDate.ToShortDateString
            End If
          End If
          If Not _docEditedUser.ApprovedUser Is Nothing Then
            Dim xrApprovedUserPictureBox As Object = newReport.FindControl("Approve", True)
            If Not xrApprovedUserPictureBox Is Nothing AndAlso TypeOf xrApprovedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
              Dim img As Image
              If Not m_userHash.ContainsKey(CStr(_docEditedUser.ApprovedUser.UserId)) Then
                img = CType(User.GetSignator(CStr(_docEditedUser.ApprovedUser.UserId)), Image)
                m_userHash.Add(CStr(_docEditedUser.ApprovedUser.UserId), img)
              Else
                img = CType(m_userHash(CStr(_docEditedUser.ApprovedUser.UserId)), Image)
              End If
              CType(xrApprovedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
            End If
            Dim xrApprovedUserRichText As Object = newReport.FindControl("ApproveName", True)
            If Not xrApprovedUserRichText Is Nothing AndAlso TypeOf xrApprovedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrApprovedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.ApprovedUser.UserName
            End If
            Dim xrApproveUserDateRichText As Object = newReport.FindControl("ApproveDate", True)
            If Not xrApproveUserDateRichText Is Nothing AndAlso TypeOf xrApproveUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrApproveUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.ApprovedUser.EditedDate.ToShortDateString
            End If
          End If
          If Not _docEditedUser.AuthorizedUser Is Nothing Then
            Dim xrAuthorizedUserPictureBox As Object = newReport.FindControl("Authorize", True)
            If Not xrAuthorizedUserPictureBox Is Nothing AndAlso TypeOf xrAuthorizedUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
              Dim img As Image
              If Not m_userHash.ContainsKey(CStr(_docEditedUser.AuthorizedUser.UserId)) Then
                img = CType(User.GetSignator(CStr(_docEditedUser.AuthorizedUser.UserId)), Image)
                m_userHash.Add(CStr(_docEditedUser.AuthorizedUser.UserId), img)
              Else
                img = CType(m_userHash(CStr(_docEditedUser.AuthorizedUser.UserId)), Image)
              End If
              CType(xrAuthorizedUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
            End If
            Dim xrAuthorizedUserRichText As Object = newReport.FindControl("AuthorizeName", True)
            If Not xrAuthorizedUserRichText Is Nothing AndAlso TypeOf xrAuthorizedUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrAuthorizedUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.AuthorizedUser.UserName
            End If
            Dim xrAuthorizedUserDateRichText As Object = newReport.FindControl("AuthorizeDate", True)
            Trace.WriteLine((Not xrAuthorizedUserDateRichText Is Nothing).ToString)
            Trace.WriteLine((TypeOf xrAuthorizedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel).ToString)
            If Not xrAuthorizedUserDateRichText Is Nothing AndAlso TypeOf xrAuthorizedUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrAuthorizedUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.AuthorizedUser.EditedDate.ToShortDateString
            End If
          End If
          If Not _docEditedUser.RejectUser Is Nothing Then
            Dim xrRejectUserPictureBox As Object = newReport.FindControl("Reject", True)
            If Not xrRejectUserPictureBox Is Nothing AndAlso TypeOf xrRejectUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
              Dim img As Image
              If Not m_userHash.ContainsKey(CStr(_docEditedUser.RejectUser.UserId)) Then
                img = CType(User.GetSignator(CStr(_docEditedUser.RejectUser.UserId)), Image)
                m_userHash.Add(CStr(_docEditedUser.RejectUser.UserId), img)
              Else
                img = CType(m_userHash(CStr(_docEditedUser.RejectUser.UserId)), Image)
              End If
              CType(xrRejectUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
            End If
            Dim xrRejectUserRichText As Object = newReport.FindControl("RejectName", True)
            If Not xrRejectUserRichText Is Nothing AndAlso TypeOf xrRejectUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrRejectUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.RejectUser.UserName
            End If
            Dim xrRejectUserDateRichText As Object = newReport.FindControl("RejectDate", True)
            If Not xrRejectUserDateRichText Is Nothing AndAlso TypeOf xrRejectUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
              CType(xrRejectUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = _docEditedUser.RejectUser.EditedDate.ToShortDateString
            End If
          End If
          If Not _docEditedUser.ApprovedUserList Is Nothing AndAlso _docEditedUser.ApprovedUserList.Count > 0 Then
            Dim ctlSignatureName As String = ""
            Dim ctlName As String = ""
            Dim ctlApproveDate As String = ""
            For Each ap As ApproveDoc In _docEditedUser.ApprovedUserList
              ctlSignatureName = String.Format("ApproveLevel{0}", ap.Level)
              Dim xrApproveUserLevelPictureBox As Object = newReport.FindControl(ctlSignatureName, True)
              If Not xrApproveUserLevelPictureBox Is Nothing AndAlso TypeOf xrApproveUserLevelPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
                Dim img As Image
                If Not m_userHash.ContainsKey(CStr(ap.Originator)) Then
                  img = CType(User.GetSignator(CStr(ap.Originator)), Image)
                  m_userHash.Add(CStr(ap.Originator), img)
                Else
                  img = CType(m_userHash(CStr(ap.Originator)), Image)
                End If
                CType(xrApproveUserLevelPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
              End If
              ctlName = String.Format("ApproveLevel{0}Name", ap.Level)
              Dim xrctlNameRichText As Object = newReport.FindControl(ctlName, True)
              If Not xrctlNameRichText Is Nothing AndAlso TypeOf xrctlNameRichText Is DevExpress.XtraReports.UI.XRLabel Then
                CType(xrctlNameRichText, DevExpress.XtraReports.UI.XRLabel).Text = New User(ap.Originator).Name
              End If
              ctlApproveDate = String.Format("ApproveLevel{0}Date", ap.Level)
              Dim xrctlApproveDateRichText As Object = newReport.FindControl(ctlName, True)
              If Not xrctlApproveDateRichText Is Nothing AndAlso TypeOf xrctlApproveDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
                CType(xrctlApproveDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = ap.OriginDate.ToShortDateString
              End If
            Next
          End If
        End If
      End If

      Dim xrUserPictureBox As Object = newReport.FindControl("User", True)
      If Not xrUserPictureBox Is Nothing AndAlso TypeOf xrUserPictureBox Is DevExpress.XtraReports.UI.XRPictureBox Then
        Dim img As Image
        If Not m_userHash.ContainsKey(CStr(secSrv.CurrentUser.Id)) Then
          img = CType(User.GetSignator(CStr(secSrv.CurrentUser.Id)), Image)
          m_userHash.Add(CStr(secSrv.CurrentUser.Id), img)
        Else
          img = CType(m_userHash(CStr(secSrv.CurrentUser.Id)), Image)
        End If
        CType(xrUserPictureBox, DevExpress.XtraReports.UI.XRPictureBox).Image = img
      End If
      Dim xrUserRichText As Object = newReport.FindControl("UserName", True)
      If Not xrUserRichText Is Nothing AndAlso TypeOf xrUserRichText Is DevExpress.XtraReports.UI.XRLabel Then
        CType(xrUserRichText, DevExpress.XtraReports.UI.XRLabel).Text = secSrv.CurrentUser.Name
      End If
      Dim xrUserDateRichText As Object = newReport.FindControl("UserDate", True)
      If Not xrUserDateRichText Is Nothing AndAlso TypeOf xrUserDateRichText Is DevExpress.XtraReports.UI.XRLabel Then
        CType(xrUserDateRichText, DevExpress.XtraReports.UI.XRLabel).Text = Now.ToShortDateString
      End If
      '--Signature Image--

      '--CUSTOM NOTES--
      If TypeOf Me.PrintingEntity Is IHasCustomNote Then
        Dim coll As CustomNoteCollection        ' = CType(m_entity, IHasCustomNote).GetCustomNoteCollection
        If TypeOf Me.PrintingEntity Is IHasMainDoc Then
          If Not (TypeOf (Me.PrintingEntity) Is JournalEntry) Then
            coll = CType(CType(Me.PrintingEntity, IHasMainDoc).MainDoc, IHasCustomNote).GetCustomNoteCollection
          Else
            coll = CType(Me.PrintingEntity, IHasCustomNote).GetCustomNoteCollection
          End If
        Else
          coll = CType(Me.PrintingEntity, IHasCustomNote).GetCustomNoteCollection
        End If
        Dim hsNote As New Hashtable
        For Each note As CustomNote In coll
          hsNote(note.NoteName.ToLower) = note
        Next

        For Each cName As String In hsNote.Keys
          Dim xrcNoteRichText As Object = newReport.FindControl(cName, True)
          If Not xrcNoteRichText Is Nothing AndAlso TypeOf xrcNoteRichText Is DevExpress.XtraReports.UI.XRLabel Then
            CType(xrcNoteRichText, DevExpress.XtraReports.UI.XRLabel).Text = ""
            If Not CType(hsNote(cName.ToLower), CustomNote) Is Nothing AndAlso Not CType(hsNote(cName.ToLower), CustomNote).Note Is Nothing Then
              CType(xrcNoteRichText, DevExpress.XtraReports.UI.XRLabel).Text = CType(hsNote(cName.ToLower), CustomNote).Note.ToString
            End If
          ElseIf Not xrcNoteRichText Is Nothing AndAlso TypeOf xrcNoteRichText Is DevExpress.XtraReports.UI.XRCheckBox Then
            If Not CType(hsNote(cName.ToLower), CustomNote) Is Nothing AndAlso Not CType(hsNote(cName.ToLower), CustomNote).Note Is Nothing Then
              CType(xrcNoteRichText, DevExpress.XtraReports.UI.XRCheckBox).Checked = CBool(CType(hsNote(cName), CustomNote).Note)
            End If
          End If
        Next

      End If
      '--END CUSTOM NOTES--

      Dim newCtl As Object = CalculateFields(newReport)

      Dim culture As String = CType(myProperties.GetProperty("CoreProperties.UILanguage"), String).Replace("-TH", "").Replace("-EN", "")
      Dim cultureV As New CultureInfo(culture, True)

      Dim dds As DataSet = CType(newReport.DataSource, DataSet)
      For Each ddt As DataTable In dds.Tables
        For Each ddc As DataColumn In ddt.Columns
          If ddc.DataType = GetType(System.DateTime) Then
            For Each ddr As DataRow In ddt.Rows
              If Not ddr(ddc.ColumnName) Is DBNull.Value Then
                ddr(ddc.ColumnName) = CDate(ddr(ddc.ColumnName)).ToString(cultureV)
                'Debug.WriteLine(CDate(ddr(ddc.ColumnName)).ToString("dd/MM/yyyy"))
                'Debug.WriteLine(culture)
              End If
            Next
          End If
        Next
      Next

      'For Each b As Band In newReport.Bands
      '  For Each c As Object In b.Controls

      '  Next
      'Next

      For Each param As DevExpress.XtraReports.Parameters.Parameter In newReport.Parameters
        param.Visible = False
      Next

      Return newReport

    Catch ex As Exception
      Return New XtraReport
    End Try
  End Function

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

  Private Function GetDataFromEntitySchemaId(ByVal dataSourceSchema As String) As DataSet
    If dataSourceSchema.Length = 0 Then
      Return Nothing
    End If

    Dim doc As New XmlDocument
    doc.LoadXml(dataSourceSchema)

    Dim xn As XmlNode = doc.DocumentElement.Attributes("id")
    Dim schemaid As String = xn.InnerText

    Dim ds As DataSet = EntitySimpleSchema.GetData(Me.Entity, Me.PrintingEntity, schemaid)
    If Not ds Is Nothing Then
      Return ds
    End If
    'Dim entitySchema As New EntitySimpleSchema(m_entity, schemaid, m_printTableEntity)
    'If Not entitySchema.DataSet Is Nothing OrElse
    '   Not entitySchema.DataSet.Tables.Count = 0 Then
    '  Return entitySchema.DataSet
    'End If

    Return New DataSet
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
End Class
