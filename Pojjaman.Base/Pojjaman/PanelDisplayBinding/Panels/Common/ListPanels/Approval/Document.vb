Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Properties
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.AdobeForm
Imports Longkong.Pojjaman.Services

Public Class Document
  Private m_entity As SimpleBusinessEntityBase
  Public Sub SetEntity(ByVal entity As SimpleBusinessEntityBase)
    m_entity = entity
    RefreshListBox()
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
      Dim thePath As String = CType(Me.ListBox1.SelectedItem, Longkong.Pojjaman.Services.FormPath).Path
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
  'Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
  '  Dim document As PrintDocument = Me.PrintDocument
  '  If (Not document Is Nothing) Then
  '    Dim dialog As PrintDialog = New PrintDialog
  '    dialog.Document = document
  '    dialog.AllowSomePages = True

  '    Dim i As Integer
  '    Try
  '      i = 0
  '      For Each pSz As PaperSize In dialog.PrinterSettings.PaperSizes
  '        If ((String.Compare(document.DefaultPageSettings.PaperSize.PaperName, pSz.PaperName)) = 0) Then
  '          Exit For
  '        End If
  '        i += 1
  '      Next
  '      If i > (dialog.PrinterSettings.PaperSizes.Count - 1) Then
  '        i = 0 ' papersize not found
  '      End If
  '    Catch ex As Exception
  '      MessageBox.Show("Error #" + Str$(Err.Number) + " has occured." + Err.Description)
  '    Finally
  '      dialog.PrinterSettings.DefaultPageSettings.PaperSize = dialog.PrinterSettings.PaperSizes(i)
  '    End Try

  '    If (dialog.ShowDialog = DialogResult.OK) Then
  '      document.Print()
  '    End If
  '  End If
  'End Sub
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
End Class
