Imports Longkong.Pojjaman.BusinessLogic
Imports System.Collections.Generic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Workflow
Imports System.Workflow.Activities
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Properties
Imports System.IO
Imports Longkong.AdobeForm

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ActionHistoryForm
    Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      'workflowDesigner = New WorkflowViewWrapper()
      '
      'Me.SplitContainer1.Panel2.Controls.Add(workflowDesigner)
      'workflowDesigner.Show()
    End Sub
    Private Logs As List(Of ActionLog)
    Private Sub ActionHistoryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      'RefreshFlow()
      RefreshForm()
      RefreshPreview()
    End Sub
    Private Sub RefreshPreview()
      If m_entity Is Nothing Then
        Return
      End If
      Dim pd As PrintDocument = Me.PrintDocument
      If Not pd Is Nothing Then
        pd.PrintController = New PJMPreviewControl(AddressOf SetPreviewPageInfos)
        If TypeOf m_entity Is RptJVAutomatic Then
          pd.DefaultPageSettings.Landscape = True
        End If
        pd.Print()
      End If
      numPages_ValueChanged(Nothing, Nothing)
    End Sub
    Private Sub SetPreviewPageInfos(ByVal ppis As PreviewPageInfo())
      m_ppis = New ArrayList
      For Each ppi As PreviewPageInfo In ppis
        m_ppis.Add(ppi)
      Next
      Me.numPages.Maximum = m_ppis.Count
      Me.numPages.Minimum = 1
      numPages.Value = 1
    End Sub
    Private Sub RefreshForm()
      For Each ctrl As Control In Me.FlowLayoutPanel1.Controls
        RemoveHandler ctrl.Click, AddressOf Button_Click
      Next
      Me.FlowLayoutPanel1.Controls.Clear()
      Me.FlowLayoutPanel1.Controls.Add(Me.btnPrint)
      Me.lstLogs.Items.Clear()
      If m_entity Is Nothing Then
        Return
      End If
      Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      m_entity.RefreshActionLogs() 'Maybe not neccessary
      Logs = m_entity.Logs
      For Each log As ActionLog In Logs
        Me.lstLogs.Items.Add(log)
      Next
      Dim node As FlowNode = m_entity.GetActiveNode
      For Each atp As ActionPath In m_entity.GetPossibleActions(node, mySService.CurrentUser.Id)
        Dim btn As New Button
        btn.Text = atp.Action.Name
        If atp.PossibleRoles.Count > 0 Then
          btn.Text &= " ("
          For Each r As CCRole In atp.PossibleRoles
            btn.Text &= r.Code
            If atp.Tier.HasValue Then
              btn.Text &= "-" & atp.Tier.ToString
            End If
            btn.Text &= ","
          Next
          btn.Text = btn.Text.TrimEnd(","c)
          btn.Text &= ")"
        End If
        btn.AutoSize = True
        btn.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
        btn.Tag = atp
        AddHandler btn.Click, AddressOf Button_Click
        Me.FlowLayoutPanel1.Controls.Add(btn)
      Next
    End Sub
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
      If Not TypeOf sender Is Control Then
        Return
      End If
      Dim ctrl As Control = CType(sender, Control)
      If Not TypeOf ctrl.Tag Is ActionPath Then
        Return
      End If
      Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim atp As ActionPath = CType(ctrl.Tag, ActionPath)

      Dim dlg As New ActionDialog
      dlg.Text = "Please specify remark for this action """ & atp.Action.Name & """"
      dlg.OK_Button.Text = atp.Action.Name
      If atp.WarningLimit.HasValue Then
        If TypeOf m_entity Is IApprovAble Then
          Dim amount As Decimal = CType(m_entity, IApprovAble).AmountToApprove
          If amount > atp.WarningLimit.Value Then
            dlg.SetWarning(atp.WarningLimit.Value, amount)
          End If
        End If
      End If
      If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim log As ActionLog = m_entity.CreatLog(atp, mySService.CurrentUser, dlg.TextBox1.Text)
        Dim err As SaveErrorException = log.Insert()
        If Not IsNumeric(err.Message) Then
          MessageBox.Show(err.Message)
        Else
          If atp.Approve Then
            If TypeOf m_entity Is IApprovAble Then
              Dim approveError As SaveErrorException = CType(m_entity, IApprovAble).ApproveData(m_entity.Id _
                                                      , mySService.CurrentUser.Id _
                                                      , Now)
              If Not IsNumeric(approveError.Message) Then
                MessageBox.Show(approveError.Message)
              End If
            End If
          End If
        End If
      Else
      End If
      'RefreshFlow()
      RefreshForm()
      RefreshPreview()
    End Sub
    Private Sub lstLogs_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstLogs.DrawItem
      e.DrawBackground()
      If e.Index >= 0 Then
        Dim bounds As Rectangle = e.Bounds
        Dim theLog As ActionLog = CType(lstLogs.Items(e.Index), ActionLog)
        Dim c As Color = e.ForeColor
        '1:    View()
        '2:    Create()
        '3:    Edit()
        '4:    Delete()
        '5:    Approve()
        '6:    Authorize()
        '7:    Reject()
        '
        Dim imgIndex As Integer = -1
        Select Case theLog.Action.Name
          Case "Approve"
            imgIndex = 0
            c = Color.Green
          Case "Authorize"
            imgIndex = 1
            c = Color.Blue
          Case "Reject"
            imgIndex = 2
            c = Color.Red
        End Select
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
          c = e.ForeColor
        End If
        If imgIndex <> -1 Then
          ImageList1.Draw(e.Graphics, bounds.Left, bounds.Top, imgIndex)
        End If
        Dim actionText As String = theLog.Action.Name
        Dim actionSize As SizeF = e.Graphics.MeasureString(actionText, e.Font)

        Dim itemText As String = ""
        itemText &= " By: "
        itemText &= theLog.User.Name
        If Not (theLog.Role Is Nothing) Then
          itemText &= " ("
          itemText &= theLog.Role.Code
          If theLog.Tier.HasValue Then
            itemText &= "-" & theLog.Tier.ToString
          End If
          itemText &= ")"
        End If
        itemText &= " AT: " & theLog.Time.ToShortDateString
        itemText &= " Time: " & theLog.Time.ToShortTimeString
        itemText &= " Remark: "
        Dim s As SizeF = e.Graphics.MeasureString(itemText, e.Font)
        Dim y As Integer = CInt((bounds.Height / 2) - (s.Height / 2))
        Dim boldFont As New Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold)
        e.Graphics.DrawString(actionText, boldFont, New SolidBrush(c), bounds.Left + ImageList1.ImageSize.Width + s.Height, bounds.Top + y)

        e.Graphics.DrawString(itemText, e.Font, New SolidBrush(c), bounds.Left + ImageList1.ImageSize.Width + s.Height + actionSize.Width, bounds.Top + y)

        Dim noteText As String = theLog.Note
        Dim italFont As New Font(e.Font.FontFamily, e.Font.Size, FontStyle.Italic)

        e.Graphics.DrawString(noteText, italFont, New SolidBrush(c), bounds.Left + ImageList1.ImageSize.Width + s.Height + actionSize.Width + s.Width, bounds.Top + y)

        e.Graphics.DrawRectangle(New Pen(c), bounds)
      End If
      e.DrawFocusRectangle()
    End Sub

    Private Sub lstLogs_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles lstLogs.MeasureItem
      e.ItemHeight = 32
    End Sub
    Private m_entity As SimpleBusinessEntityBase
    Public Sub SetEntity(ByVal entity As SimpleBusinessEntityBase)
      m_entity = entity
      RefreshListBox()
    End Sub

#Region "Event Handlers"
    Private m_originalSize As New Size(0, 0)
    Private m_ppis As ArrayList
    Private Sub numPages_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPages.ValueChanged
      If m_ppis Is Nothing OrElse m_ppis.Count = 0 Then
        Return
      End If
      Dim ppi As PreviewPageInfo = CType(m_ppis(CInt(Me.numPages.Value - 1)), PreviewPageInfo)
      'ZoomFactor = 1
      Me.txtPercent.Text = (ZoomFactor * 100).ToString & " %"
      m_originalSize = ppi.Image.Size
      Me.picMap.Image = ppi.Image
      Me.picMap.Size = ppi.Image.Size
      picMap.Size = New Size(CInt(m_originalSize.Width * ZoomFactor * ZoomConst), CInt(m_originalSize.Height * ZoomFactor * ZoomConst))
    End Sub
    Private ZoomFactor As Double = 1
    Private ZoomConst As Double = 0.24 '=72/300 มั้ง
    Private ZoomDelta As Double = 0.1
    Private Sub ibtnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomOut.Click
      ZoomFactor -= ZoomDelta
      ZoomFactor = Math.Max(0, ZoomFactor)
      Try
        picMap.Size = New Size(CInt(m_originalSize.Width * ZoomFactor * ZoomConst), CInt(m_originalSize.Height * ZoomFactor * ZoomConst))
      Catch ex As Exception

      End Try
      Me.txtPercent.Text = (ZoomFactor * 100).ToString & " %"
    End Sub
    Private Sub ibtnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomIn.Click
      ZoomFactor += ZoomDelta
      ZoomFactor = Math.Min(5, ZoomFactor)
      Try
        picMap.Size = New Size(CInt(m_originalSize.Width * ZoomFactor * ZoomConst), CInt(m_originalSize.Height * ZoomFactor * ZoomConst))
      Catch ex As Exception

      End Try
      Me.txtPercent.Text = (ZoomFactor * 100).ToString & " %"
    End Sub
#End Region

#Region "IPrintable"
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
      RefreshPreview()
    End Sub
    Private Sub RefreshListBox()
      Me.ListBox1.Items.Clear()
      If m_entity Is Nothing Then
        Return
      End If
      Dim printEntity As IPrintableEntity = m_entity.GetEntityForPrintingOnApproval
      If printEntity Is Nothing Then
        Return
      End If
      If Not TypeOf printEntity Is SimpleBusinessEntityBase Then
        Return
      End If
      Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      Dim nameForPath As String = CType(printEntity, SimpleBusinessEntityBase).FullClassName & ".Documents"
      Dim paths As FormPaths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, CType(printEntity, SimpleBusinessEntityBase).ClassName, "")), FormPaths)
      For Each p As FormPath In paths.FormPaths
        Me.ListBox1.Items.Add(p)
      Next
      If Me.ListBox1.Items.Count > 0 Then
        Me.ListBox1.SelectedItem = Me.ListBox1.Items(0)
      End If
    End Sub
    Private ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        If Me.ListBox1.SelectedItem Is Nothing Then
          Return Nothing
        End If
        If m_entity Is Nothing Then
          Return Nothing
        End If
        Dim printEntity As IPrintableEntity = m_entity.GetEntityForPrintingOnApproval
        If printEntity Is Nothing Then
          Return Nothing
        End If
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
        Dim thePath As String = CType(Me.ListBox1.SelectedItem, FormPath).Path
        If Not printEntity Is Nothing Then
          If TypeOf printEntity Is IPrintableEntity Then
            If File.Exists(thePath) Then
              Dim df As New DesignerForm(thePath, CType(printEntity, IPrintableEntity))
              Return df.PrintDocument
            End If
          End If
        End If
      End Get
    End Property
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
      Dim document As PrintDocument = Me.PrintDocument
      If (Not document Is Nothing) Then
        Dim dialog As PrintDialog = New PrintDialog
        dialog.Document = document
        dialog.AllowSomePages = True

        Dim i As Integer
        Try
          i = 0
          For Each pSz As PaperSize In dialog.PrinterSettings.PaperSizes
            If ((String.Compare(document.DefaultPageSettings.PaperSize.PaperName, pSz.PaperName)) = 0) Then
              Exit For
            End If
            i += 1
          Next
          If i > (dialog.PrinterSettings.PaperSizes.Count - 1) Then
            i = 0 ' papersize not found
          End If
        Catch ex As Exception
          MessageBox.Show("Error #" + Str$(Err.Number) + " has occured." + Err.Description)
        Finally
          dialog.PrinterSettings.DefaultPageSettings.PaperSize = dialog.PrinterSettings.PaperSizes(i)
        End Try

        If (dialog.ShowDialog = DialogResult.OK) Then
          document.Print()
        End If
      End If
    End Sub
#End Region

  End Class
End Namespace
