Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.Services
Imports System.Reflection
Imports Syncfusion.Windows.Forms.Grid

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AdvanceStoreApprovalCommentForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grdApproval As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents btnReject As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvanceStoreApprovalCommentForm))
      Dim GridBaseStyle1 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle2 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle3 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle4 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Me.txtComment = New System.Windows.Forms.TextBox()
      Me.btnAdd = New System.Windows.Forms.Button()
      Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grdApproval = New Syncfusion.Windows.Forms.Grid.GridControl()
      Me.btnReject = New System.Windows.Forms.Button()
      CType(Me.grdApproval, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtComment
      '
      Me.txtComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtComment.Location = New System.Drawing.Point(8, 388)
      Me.txtComment.Multiline = True
      Me.txtComment.Name = "txtComment"
      Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtComment.Size = New System.Drawing.Size(500, 80)
      Me.txtComment.TabIndex = 2
      '
      'btnAdd
      '
      Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAdd.Location = New System.Drawing.Point(578, 445)
      Me.btnAdd.Name = "btnAdd"
      Me.btnAdd.Size = New System.Drawing.Size(96, 23)
      Me.btnAdd.TabIndex = 0
      Me.btnAdd.Text = "เพิ่มความเห็น"
      Me.btnAdd.Visible = False
      '
      'btnApprove
      '
      Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnApprove.Location = New System.Drawing.Point(578, 387)
      Me.btnApprove.Name = "btnApprove"
      Me.btnApprove.Size = New System.Drawing.Size(96, 23)
      Me.btnApprove.TabIndex = 7
      Me.btnApprove.Text = "อนุมัติ"
      Me.btnApprove.ThemedImage = CType(resources.GetObject("btnApprove.ThemedImage"), System.Drawing.Bitmap)
      '
      'grdApproval
      '
      Me.grdApproval.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      GridBaseStyle1.Name = "Header"
      GridBaseStyle1.StyleInfo.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.Borders.Left = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None)
      GridBaseStyle1.StyleInfo.CellType = "Header"
      GridBaseStyle1.StyleInfo.Font.Bold = True
      GridBaseStyle1.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(184, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(216, Byte), Integer)))
      GridBaseStyle1.StyleInfo.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
      GridBaseStyle2.Name = "Standard"
      GridBaseStyle2.StyleInfo.Font.Facename = "Tahoma"
      GridBaseStyle2.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
      GridBaseStyle3.Name = "Row Header"
      GridBaseStyle3.StyleInfo.BaseStyle = "Header"
      GridBaseStyle3.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      GridBaseStyle3.StyleInfo.Interior = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Horizontal, System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(184, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(216, Byte), Integer)))
      GridBaseStyle4.Name = "Column Header"
      GridBaseStyle4.StyleInfo.BaseStyle = "Header"
      GridBaseStyle4.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      Me.grdApproval.BaseStylesMap.AddRange(New Syncfusion.Windows.Forms.Grid.GridBaseStyle() {GridBaseStyle1, GridBaseStyle2, GridBaseStyle3, GridBaseStyle4})
      Me.grdApproval.ColCount = 3
      Me.grdApproval.ColWidthEntries.AddRange(New Syncfusion.Windows.Forms.Grid.GridColWidth() {New Syncfusion.Windows.Forms.Grid.GridColWidth(0, 35), New Syncfusion.Windows.Forms.Grid.GridColWidth(1, 300), New Syncfusion.Windows.Forms.Grid.GridColWidth(2, 200), New Syncfusion.Windows.Forms.Grid.GridColWidth(3, 100)})
      Me.grdApproval.ForeColor = System.Drawing.SystemColors.ControlText
      Me.grdApproval.Location = New System.Drawing.Point(8, 8)
      Me.grdApproval.Name = "grdApproval"
      Me.grdApproval.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.grdApproval.RowCount = 20
      Me.grdApproval.RowHeightEntries.AddRange(New Syncfusion.Windows.Forms.Grid.GridRowHeight() {New Syncfusion.Windows.Forms.Grid.GridRowHeight(0, 21)})
      Me.grdApproval.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeAsRangeStylesIntoCode
      Me.grdApproval.Size = New System.Drawing.Size(668, 373)
      Me.grdApproval.SmartSizeBox = False
      Me.grdApproval.TabIndex = 8
      Me.grdApproval.UseRightToLeftCompatibleTextBox = True
      '
      'btnReject
      '
      Me.btnReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReject.Location = New System.Drawing.Point(578, 416)
      Me.btnReject.Name = "btnReject"
      Me.btnReject.Size = New System.Drawing.Size(96, 23)
      Me.btnReject.TabIndex = 9
      Me.btnReject.Text = "ส่งกลับ"
      '
      'AdvanceStoreApprovalCommentForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(688, 474)
      Me.Controls.Add(Me.btnReject)
      Me.Controls.Add(Me.grdApproval)
      Me.Controls.Add(Me.txtComment)
      Me.Controls.Add(Me.btnAdd)
      Me.Controls.Add(Me.btnApprove)
      Me.Name = "AdvanceStoreApprovalCommentForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Advance Approval Comments"
      CType(Me.grdApproval, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As IHasAppStoreColl

    Private m_approveDoc As ApprovalStoreComment
    'Private m_approveDocColl As ApproveDocCollection

    'Private m_refDocIsApproved As Boolean

    Private myDT As DataTable

    Private mySService As SecurityService
    'Private ApprovalDocLevel As ApprovalDocLevelCollection
    Private myColor As New Hashtable
    Private m_itemCollection As ApprovalStoreCommentCollection
#End Region

#Region "SetLabelText"
    Dim StringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    Public Sub SetLabelText()
      Me.btnAdd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AdvanceApprovalCommentForm.btnAdd}")
      Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AdvanceApprovalCommentForm.btnApprove}")
      Me.btnReject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AdvanceApprovalCommentForm.btnReject}")
    End Sub
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As IHasAppStoreColl)
      MyBase.New()
      InitializeComponent()
      SetLabelText()
      m_entity = entity
      If Not m_entity.Originated Then
        Return
      End If
      If m_entity.ApprovalCollection Is Nothing Then
      m_itemCollection = New ApprovalStoreCommentCollection(m_entity)
      Else
        m_itemCollection = m_entity.ApprovalCollection
      End If
      'm_approveDocColl = New ApproveDocCollection(m_entity)
      mySService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      'ApprovalDocLevel = New ApprovalDocLevelCollection(mySService.CurrentUser)
      'CheckIsApproved()
      PrepareColor()
      PrepareDataTable()
      Populate()
    End Sub
    Private Sub PrepareDataTable()
      myDT = New DataTable
      'สร้าง DataColumn ขึ้นมาเก็บข้อมูล
      myDT.Columns.Add(New DataColumn("No."))
      myDT.Columns.Add(New DataColumn("ความคิดเห็น"))
      myDT.Columns.Add(New DataColumn("โดย"))

      'เป็นหัว Column ที่ใช้แสดงผล
      Me.grdApproval(0, 1).Text = "ความคิดเห็น"
      Me.grdApproval(0, 2).Text = "โดย"
      Me.grdApproval(0, 3).Text = " "
    End Sub
    Private Sub PrepareColor()
      myColor(1) = Color.Pink
      myColor(2) = Color.NavajoWhite
      myColor(3) = Color.LightGreen
      myColor(4) = Color.LightBlue
      myColor(5) = Color.LightCoral
      myColor(6) = Color.LightGray
      myColor(7) = Color.LightYellow
    End Sub
#End Region

#Region "Method"
    'Private Sub CheckIsApproved()
    '	Dim DocApprovable As IApprovAble = CType(m_entity, IApprovAble)

    '	Dim accessId As Integer = Entity.GetAccessIdFromFullClassName(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(m_entity.EntityId) & "ForApprove")
    '	Dim accessValue As Integer = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).GetAccess(accessId)

    '	If DocApprovable.IsApproved OrElse m_approveDocColl.IsApproved OrElse accessValue = 0 Then
    '		m_refDocIsApproved = True
    '	End If
    'End Sub
    Private Sub Populate()
      DisableButton()
      myDT.Rows.Clear()
      If m_itemCollection Is Nothing Then
        Return
      End If

      'ตั้งไว้ 20 rows ถ้าข้อมูลมีมากกว่า ให้ปรับจำนวน row ใน grid
      If m_itemCollection.Count > Me.grdApproval.RowCount Then
        Me.grdApproval.RowCount = m_itemCollection.Count
      End If

      Dim myDR As DataRow
      For Each apvDoc As ApprovalStoreComment In m_itemCollection
        myDR = myDT.NewRow
        myDR.Item(0) = apvDoc.LineNumber
        myDR.Item(1) = apvDoc.Comment
        Dim temp As User = New User(apvDoc.Originator)
        myDR.Item(2) = temp.Name
        'If apvDoc.Level > 0 Then
        '	myDR.Item(2) &= " (Level " & apvDoc.Level.ToString & ")"
        'End If
        If Not apvDoc.LastEditDate.Equals(Date.MinValue) Then
          myDR.Item(2) &= vbCrLf & vbCrLf & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AdvanceApprovalCommentForm.MsgLastEdit}") & Format(apvDoc.LastEditDate, "dd/MM/yyyy HH:mm:ss")
        Else
          myDR.Item(2) &= vbCrLf & vbCrLf & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AdvanceApprovalCommentForm.MsgAdd}") & Format(apvDoc.OriginDate, "dd/MM/yyyy HH:mm:ss")
        End If
        myDT.Rows.Add(myDR)
      Next

      Me.grdApproval.BeginUpdate()
      Me.grdApproval.Model.PopulateValues(GridRangeInfo.Cells(1, 0, myDT.Rows.Count, myDT.Columns.Count), myDT)
      Me.grdApproval.Model.RowHeights.ResizeToFit(GridRangeInfo.Rows(0, Me.grdApproval.Model.RowCount), GridResizeToFitOptions.None)

      For i As Integer = 1 To myDT.Rows.Count
        'If Me.ApproveDocColl(i - 1).Level > 0 Then
        '	Me.grdApproval.RowStyles(i).BackColor = IIf(Me.ApproveDocColl(i - 1).Level > myColor.Count, Color.White, myColor(Me.ApproveDocColl(i - 1).Level))
        'End If
        If Me.ItemCollection(i - 1).Type = ApproveType.approved Then
          Me.grdApproval.RowStyles(i).BackColor = Color.LightGreen
        ElseIf Me.ItemCollection(i - 1).Type = ApproveType.reject Then
          Me.grdApproval.RowStyles(i).BackColor = Color.LightBlue
        End If

        If Me.ItemCollection(i - 1).Originator = mySService.CurrentUser.Id Then
          Me.grdApproval(i, 3).Description = "แก้ไข"
          Me.grdApproval(i, 3).CellType = "PushButton"
          Me.grdApproval(i, 3).CellAppearance = GridCellAppearance.Raised
        End If
        Me.grdApproval.RowStyles(i).Tag = "edit"
      Next

      'ให้ Col1 - 3 เป็น readonly
      Me.grdApproval.ColStyles(1).ReadOnly = True
      Me.grdApproval.ColStyles(2).ReadOnly = True
      Me.grdApproval.ColStyles(3).ReadOnly = True

      Me.grdApproval.Refresh()
      Me.grdApproval.EndUpdate()
    End Sub
    Private Sub DisableButton()
      txtComment.Text = ""

      If Me.m_itemCollection.Approved = ApproveType.approved Then
        Me.btnApprove.Enabled = False
        Me.btnReject.Enabled = True
      Else
        Me.btnApprove.Enabled = True
        Me.btnReject.Enabled = False
      End If

    End Sub
#End Region

#Region "Event Handlers"
    'Private tempComment As ApproveDoc
    'Private CurrentComment As ApproveDoc
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
      If Me.txtComment.TextLength <= 0 Then
        Return
      End If

      AddNewComment()
      Populate()
    End Sub
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
      If Me.txtComment.TextLength <= 0 Then
        Return
      End If

      AddNewComment(ApproveType.approved)
      Populate()
    End Sub
    Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click
      If Me.txtComment.TextLength <= 0 Then
        Return
      End If

      AddNewComment(ApproveType.reject)
      Populate()
    End Sub

    Private Sub AddNewComment(Optional ByVal commentType As ApproveType = ApproveType.comment)
      Try
        'Me.m_approveDoc = New ApproveDoc
        m_approveDoc = New ApprovalStoreComment
        If Not Me.m_entity Is Nothing Then
          m_approveDoc.EntityId = m_entity.Id
          m_approveDoc.EntityType = m_entity.EntityId
        End If
        Dim isapprove As Integer = 0
        'ถ้าไม่ approve ก็ Reject อย่ามากั๊ก ไม่ให้ comment
        If commentType = ApproveType.approved Then
          isapprove = 1
        Else
          'ใน Database เป็น -1 แต่ในโปรแกรมใช้ ApproveType ไม่อยากแก้ใน database แล้ว ยาก
          isapprove = commentType
        End If
        m_approveDoc.LineNumber = Me.m_itemCollection.Count + 1
        m_approveDoc.Comment = Me.txtComment.Text.Trim
        m_approveDoc.Type = isapprove
        m_approveDoc.Originator = mySService.CurrentUser.Id
        m_approveDoc.OriginDate = Now
        'Add to Collection
        m_itemCollection.Add(m_approveDoc)
        m_entity.ApprovalCollection = m_itemCollection
        'Me.Save(commentType)
      Catch ex As Exception
        Dim msg As MessageService = CType(ServiceManager.Services.GetService(GetType(MessageService)), MessageService)
        msg.ShowError(ex.Message.ToString & vbCrLf & ex.InnerException.ToString)
      End Try
    End Sub
    Private Function Save(ByVal commentType As ApproveType) As SaveErrorException
      Try
        If commentType = ApproveType.approved Then
          Dim currentUserId As Integer = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id
          m_itemCollection.Save(currentUserId)
        ElseIf commentType = ApproveType.reject Then
          m_itemCollection.Delete()
        End If
      Catch ex As Exception

      End Try
    End Function

    Private ChangedText As String
    Private Editing As Boolean = False
    Private Sub grdApproval_CellButtonClicked(ByVal sender As Object, ByVal e As GridCellButtonClickedEventArgs) Handles grdApproval.CellButtonClicked
      If Me.grdApproval.RowStyles(e.RowIndex).Tag = "edit" AndAlso Not Editing Then
        'ปลด lock 2 คอลัมน์
        Me.grdApproval(e.RowIndex, 1).ReadOnly = False
        Me.grdApproval(e.RowIndex, 3).ReadOnly = False

        'เปลี่ยน label บนปุ่ม
        Me.grdApproval(e.RowIndex, e.ColIndex).Description = "ตกลง"
        Me.grdApproval.RowStyles(e.RowIndex).Tag = "edited"

        Editing = True
      ElseIf Me.grdApproval.RowStyles(e.RowIndex).Tag = "edited" AndAlso Editing Then
        'เปลี่ยน label บนปุ่ม
        Me.grdApproval(e.RowIndex, e.ColIndex).Description = "แก้ไข"
        Me.grdApproval.RowStyles(e.RowIndex).Tag = "edit"

        Me.m_approveDoc = Me.m_itemCollection(e.RowIndex - 1)
        Dim cc As GridCurrentCell = Me.grdApproval.CurrentCell
        If cc.ColIndex = 1 And cc.RowIndex = e.RowIndex Then
          ChangedText = cc.Renderer.ControlText
        Else
          ChangedText = Me.grdApproval(e.RowIndex, 1).Text
        End If
        Me.m_approveDoc.Comment = ChangedText
        Me.m_approveDoc.LastEditor = Me.m_approveDoc.Originator
        Me.m_approveDoc.LastEditDate = Now

        Me.Save(Me.m_approveDoc.Type)
        Populate()

        Me.grdApproval.ColStyles(1).ReadOnly = True

        Editing = False
      End If
    End Sub

#End Region

#Region "Properties"
    Public ReadOnly Property ItemCollection() As ApprovalStoreCommentCollection
      Get
        Return m_itemCollection
      End Get
    End Property
    Public ReadOnly Property ApproveDoc As ApprovalStoreComment
      Get
        If Me.m_approveDoc Is Nothing Then
          If Me.ItemCollection.Count > 0 Then
            Me.m_approveDoc = Me.ItemCollection(Me.ItemCollection.Count - 1)
          Else
            Return Nothing
          End If
        Else
          Return Me.m_approveDoc
        End If
      End Get
    End Property
#End Region

  End Class

End Namespace

