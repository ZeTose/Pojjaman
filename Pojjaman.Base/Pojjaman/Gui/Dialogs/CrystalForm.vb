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

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class CrystalForm
    Inherits System.Windows.Forms.Form
    'Private Sub CrystalForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '  Label1.Text = ""
    'End Sub

#Region "Member"
    Private WithEvents newReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
#End Region

    'Public Sub New()
    '  MyBase.New()
    'End Sub

    'Public Sub New()
    '  InitializeComponent()

    '  'MyBase.New()
    '  ' This call is required by the designer.

    '  ' Add any initialization after the InitializeComponent() call.
    'End Sub

    'Public Shadows Function ShowDialog() As DialogResult
    '  Me.RefreshReport()
    '  MyBase.ShowDialog()
    'End Function

    Public Sub New(ByVal entity As ISimpleEntity, ByVal path As String, Optional ByVal entityIdList As String = "")
      Me.InitializeComponent()
      Me.WindowState = FormWindowState.Maximized

      For Each ctrl As Control In CrystalReportViewer1.Controls
        If TypeOf ctrl Is ToolStrip Then
          Dim CLogo As ToolStrip = CType(ctrl, ToolStrip)
          CLogo.Items(CLogo.Items.Count - 1).Visible = False
        End If
      Next

      Me.m_entity = entity
      Me.m_path = path
      Me.m_entityIdList = entityIdList

      Me.CheckAccessRight()
      Me.RefreshReport()
    End Sub

    Public Overridable Sub RefreshReport()
      If Me.m_entity Is Nothing Then
        Return
      End If

      'If Not IO.File.Exists(sReportName) Then
      '  MessageBox.Show("Report File '" & sReportName & "' not found")
      'End If

      'Dim intCounter As Integer
      'Dim intCounter1 As Integer

      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim currentUserName As String = secSrv.CurrentUser.Name

      Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      Dim culture As String = CType(myProperties.GetProperty("CoreProperties.UILanguage"), String)

      CrystalReportViewer1.SetProductLocale(culture)

      'Dim newReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
      Dim paraValue As New CrystalDecisions.Shared.ParameterDiscreteValue
      Dim currValue As New CrystalDecisions.Shared.ParameterValues

      Dim newSubReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      Dim mySubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject

      Dim strParValPair() As String
      Dim strVal() As String
      Dim index As Integer

      Try
        newReport.Load(m_path)

        'If Not filters Is Nothing Then
        '  For Each flr As Filter In filters
        paraValue.Value = Me.m_entity.Id
        currValue = newReport.DataDefinition.ParameterFields("@EntityId").CurrentValues
        currValue.Add(paraValue)
        newReport.DataDefinition.ParameterFields("@EntityId").ApplyCurrentValues(currValue)

        paraValue.Value = Me.m_entity.EntityId
        currValue = newReport.DataDefinition.ParameterFields("@EntityType").CurrentValues
        currValue.Add(paraValue)
        newReport.DataDefinition.ParameterFields("@EntityType").ApplyCurrentValues(currValue)

        paraValue.Value = Me.m_entityIdList
        currValue = newReport.DataDefinition.ParameterFields("@EntityIdList").CurrentValues
        currValue.Add(paraValue)
        newReport.DataDefinition.ParameterFields("@EntityIdList").ApplyCurrentValues(currValue)

        paraValue.Value = culture
        currValue = newReport.DataDefinition.ParameterFields("@Culture").CurrentValues
        currValue.Add(paraValue)
        newReport.DataDefinition.ParameterFields("@Culture").ApplyCurrentValues(currValue)

        paraValue.Value = currentUserName
        currValue = newReport.DataDefinition.ParameterFields("@CurrentUserName").CurrentValues
        currValue.Add(paraValue)
        newReport.DataDefinition.ParameterFields("@CurrentUserName").ApplyCurrentValues(currValue)
        '  Next
        'End If

        'intCounter = newReport.DataDefinition.ParameterFields.Count

        'If intCounter = 1 Then
        '  If InStr(newReport.DataDefinition.ParameterFields(0).ParameterFieldName, ".", CompareMethod.Text) > 0 Then
        '    intCounter = 0
        '  End If
        'End If

        'If intCounter > 0 And Trim(param) <> "" Then
        '  strParValPair = param.Split("&")

        '  For index = 0 To UBound(strParValPair)
        '    If InStr(strParValPair(index), "=") > 0 Then
        '      strVal = strParValPair(index).Split("=")
        '      paraValue.Value = strVal(1)
        '      currValue = newReport.DataDefinition.ParameterFields(strVal(0)).CurrentValues
        '      currValue.Add(paraValue)
        '      newReport.DataDefinition.ParameterFields(strVal(0)).ApplyCurrentValues(currValue)
        '    End If
        '  Next
        'End If

        Dim myConnectionString As String = CType(Me.m_entity, SimpleBusinessEntityBase).ConnectionString

        ConInfo.ConnectionInfo.UserID = SqlHelper.GetUserID(myConnectionString)
        ConInfo.ConnectionInfo.Password = SqlHelper.GetPassword(myConnectionString)
        ConInfo.ConnectionInfo.ServerName = SqlHelper.GetInstanceName(myConnectionString)
        ConInfo.ConnectionInfo.DatabaseName = SqlHelper.GetDBName(myConnectionString)

        'For intCounter = 0 To newReport.Database.Tables.Count - 1
        '  newReport.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        'Next

        'For index = 0 To newReport.ReportDefinition.Sections.Count - 1
        '  For intCounter = 0 To newReport.ReportDefinition.Sections(index).ReportObjects.Count - 1
        '    With newReport.ReportDefinition.Sections(index)
        '      If .ReportObjects(intCounter).Kind = CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then
        '        mySubReportObject = CType(.ReportObjects(intCounter), CrystalDecisions.CrystalReports.Engine.SubreportObject)
        '        mySubRepDoc = mySubReportObject.OpenSubreport(mySubReportObject.SubreportName)
        '        For intCounter1 = 0 To mySubRepDoc.Database.Tables.Count - 1
        '          mySubRepDoc.Database.Tables(intCounter1).ApplyLogOnInfo(ConInfo)
        '          mySubRepDoc.Database.Tables(intCounter1).ApplyLogOnInfo(ConInfo)
        '        Next
        '      End If
        '    End With
        '  Next
        'Next

        For Each crTable As CrystalDecisions.CrystalReports.Engine.Table In newReport.Database.Tables
          crTable.ApplyLogOnInfo(ConInfo)
        Next
        For Each subReport As CrystalDecisions.CrystalReports.Engine.ReportDocument In newReport.Subreports
          For Each crTable As CrystalDecisions.CrystalReports.Engine.Table In subReport.Database.Tables
            crTable.ApplyLogOnInfo(ConInfo)
          Next
        Next

        'If sSelectionFormula.Length > 0 Then
        '  newReport.RecordSelectionFormula = sSelectionFormula
        'End If

        CrystalReportViewer1.ReportSource = Nothing

        CrystalReportViewer1.ReportSource = newReport

        CrystalReportViewer1.Show()

        'CrystalReportViewer1.Zoom(1)

      Catch ex As System.Exception
        MsgBox(ex.Message)
      End Try
    End Sub

#Region "Member"
    Private m_entity As ISimpleEntity
    Private m_path As String
    Private m_entityIdList As String
#End Region

#Region "Properties"
    'Public Property Entity As ISimpleEntity
    '  Get
    '    Return m_entity
    '  End Get
    '  Set(ByVal value As ISimpleEntity)
    '    m_entity = value
    '  End Set
    'End Property
    'Public Property Path As String
#End Region

#Region "Method"
    Public Sub ClearTex()
      'Me.Label1.text = ""
    End Sub
    Private Sub CheckAccessRight()
      Dim simpleentity As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName)

      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim accessId As Integer = Longkong.Pojjaman.BusinessLogic.Entity.GetAccessIdFromFullClassName(simpleentity.FullClassName)

      Dim level As Integer = secSrv.GetAccess(accessId)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      'Trace.WriteLine(checkString)
      If CBool(checkString.Substring(3, 1)) Then
        Me.CrystalReportViewer1.ShowPrintButton = True
        Me.CrystalReportViewer1.ShowExportButton = True
      Else
        Me.CrystalReportViewer1.ShowPrintButton = False
        Me.CrystalReportViewer1.ShowExportButton = False
      End If
    End Sub
#End Region

    Private Sub InitializeComponent()
      Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
      Me.SuspendLayout()
      '
      'CrystalReportViewer1
      '
      Me.CrystalReportViewer1.ActiveViewIndex = -1
      Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
      Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
      Me.CrystalReportViewer1.ShowGroupTreeButton = False
      Me.CrystalReportViewer1.ShowParameterPanelButton = False
      Me.CrystalReportViewer1.ShowTextSearchButton = False
      Me.CrystalReportViewer1.Size = New System.Drawing.Size(898, 471)
      Me.CrystalReportViewer1.TabIndex = 0
      Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      '
      'CrystalForm
      '
      Me.ClientSize = New System.Drawing.Size(898, 471)
      Me.Controls.Add(Me.CrystalReportViewer1)
      Me.Name = "CrystalForm"
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  End Class

End Namespace