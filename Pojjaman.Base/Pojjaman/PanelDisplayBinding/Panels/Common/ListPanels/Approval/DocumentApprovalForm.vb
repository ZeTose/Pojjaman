Imports WeifenLuo.WinFormsUI.Docking
Imports Longkong.Pojjaman.Commands
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic

Public Class DocumentApprovalForm
  Private m_entity As SimpleBusinessEntityBase
  Public Sub SetEntity(ByVal entity As SimpleBusinessEntityBase)
    m_entity = entity
    doc.SetEntity(m_entity)
  End Sub
  Private hst As History
  Private doc As Document
  Private docList As DocumentList
  Private Sub DocumentApprovalForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DockPanel1.DocumentStyle = DocumentStyle.DockingWindow
    DockPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    doc = New Document
    Dim window As New ControlWrapper(doc)
    window.DockAreas = DockAreas.Document
    window.CloseButtonVisible = False
    window.Show(Me.DockPanel1)
    window.Text = "อนุมัติเอกสาร"

    Dim myContent As New ControlWrapper(New History)
    Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
    myContent.Icon = myIconService.GetIcon("Icons.16x16.Shell")
    myContent.Text = "History"
    myContent.DockAreas = DockAreas.DockLeft
    myContent.CloseButtonVisible = False
    myContent.Show(DockPanel1)

    myContent = New ControlWrapper(New ActionForm)
    myContent.Icon = myIconService.GetIcon("Icons.16x16.Shell")
    myContent.Text = "Actions"
    myContent.DockAreas = DockAreas.DockRight
    myContent.CloseButtonVisible = False
    myContent.Show(DockPanel1)

    docList = New DocumentList
    docList.ParentForm = Me
    myContent = New ControlWrapper(docList)
    myContent.Icon = myIconService.GetIcon("Icons.16x16.Shell")
    myContent.Text = "Todo List"
    myContent.DockAreas = DockAreas.DockBottom
    myContent.CloseButtonVisible = False
    myContent.Show(DockPanel1)
  End Sub

  Private Class ControlWrapper
    Inherits DockContent

#Region "Members"
    Private m_dlg As UserControl
#End Region

#Region "Constructors"
    Public Sub New(ByVal dlg As UserControl)
      Me.m_dlg = dlg
      dlg.Dock = DockStyle.Fill
      Me.Controls.Add(dlg)
      Me.KeyPreview = True
      MyBase.HideOnClose = False
    End Sub
#End Region

#Region "Methods"
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      MyBase.Dispose(disposing)
      If (disposing AndAlso (Not Me.m_dlg Is Nothing)) Then
        Me.m_dlg.Dispose()
        Me.m_dlg = Nothing
      End If
    End Sub
    Protected Overrides Function GetPersistString() As String
      Return CType(Me.m_dlg, Object).GetType.ToString
    End Function
#End Region

#Region "Events"
    Private Sub PadContentWrapper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
      Select Case e.KeyCode
        Case Keys.Enter
          If StartPojjamanWorkbenchCommand.ALLOWTAB Then
            SendKeys.Send("{tab}")
          End If
          e.Handled = True
      End Select
    End Sub
#End Region

  End Class
End Class