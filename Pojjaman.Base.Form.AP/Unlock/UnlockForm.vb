Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.Services
Imports System.Reflection
Imports Syncfusion.Windows.Forms.Grid

Namespace Longkong.Pojjaman.Gui.Panels
	Public Class UnlockCommentForm
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
    Friend WithEvents btnUnlock As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnUnlockLevel1 As Longkong.Pojjaman.Gui.Components.ImageButton
		Friend WithEvents grdUnlock As Syncfusion.Windows.Forms.Grid.GridControl
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim GridBaseStyle1 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle2 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle3 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle4 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Me.txtComment = New System.Windows.Forms.TextBox()
      Me.btnUnlock = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grdUnlock = New Syncfusion.Windows.Forms.Grid.GridControl()
      Me.btnUnlockLevel1 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      CType(Me.grdUnlock, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtComment
      '
      Me.txtComment.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me.txtComment.Location = New System.Drawing.Point(8, 392)
      Me.txtComment.Multiline = True
      Me.txtComment.Name = "txtComment"
      Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtComment.Size = New System.Drawing.Size(414, 112)
      Me.txtComment.TabIndex = 2
      '
      'btnUnlock
      '
      Me.btnUnlock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnUnlock.Location = New System.Drawing.Point(428, 392)
      Me.btnUnlock.Name = "btnUnlock"
      Me.btnUnlock.Size = New System.Drawing.Size(116, 23)
      Me.btnUnlock.TabIndex = 7
      Me.btnUnlock.Text = "ปลดล๊อคทั้งหมด"
      Me.btnUnlock.ThemedImage = Global.My.Resources.Resources.Alert
      '
      'grdUnlock
      '
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
      Me.grdUnlock.BaseStylesMap.AddRange(New Syncfusion.Windows.Forms.Grid.GridBaseStyle() {GridBaseStyle1, GridBaseStyle2, GridBaseStyle3, GridBaseStyle4})
      Me.grdUnlock.ColCount = 2
      Me.grdUnlock.ColWidthEntries.AddRange(New Syncfusion.Windows.Forms.Grid.GridColWidth() {New Syncfusion.Windows.Forms.Grid.GridColWidth(0, 35), New Syncfusion.Windows.Forms.Grid.GridColWidth(1, 300), New Syncfusion.Windows.Forms.Grid.GridColWidth(2, 200), New Syncfusion.Windows.Forms.Grid.GridColWidth(3, 100)})
      Me.grdUnlock.ForeColor = System.Drawing.SystemColors.ControlText
      Me.grdUnlock.Location = New System.Drawing.Point(8, 8)
      Me.grdUnlock.Name = "grdUnlock"
      Me.grdUnlock.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.grdUnlock.RowCount = 20
      Me.grdUnlock.RowHeightEntries.AddRange(New Syncfusion.Windows.Forms.Grid.GridRowHeight() {New Syncfusion.Windows.Forms.Grid.GridRowHeight(0, 21)})
      Me.grdUnlock.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeAsRangeStylesIntoCode
      Me.grdUnlock.Size = New System.Drawing.Size(536, 376)
      Me.grdUnlock.SmartSizeBox = False
      Me.grdUnlock.TabIndex = 8
      Me.grdUnlock.UseRightToLeftCompatibleTextBox = True
      '
      'btnUnlockLevel1
      '
      Me.btnUnlockLevel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnUnlockLevel1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnUnlockLevel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnUnlockLevel1.Location = New System.Drawing.Point(428, 421)
      Me.btnUnlockLevel1.Name = "btnUnlockLevel1"
      Me.btnUnlockLevel1.Size = New System.Drawing.Size(116, 23)
      Me.btnUnlockLevel1.TabIndex = 7
      Me.btnUnlockLevel1.Text = "ปลดล๊อคบางส่วน"
      Me.btnUnlockLevel1.ThemedImage = Global.My.Resources.Resources.Warn
      '
      'UnlockCommentForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(552, 518)
      Me.Controls.Add(Me.grdUnlock)
      Me.Controls.Add(Me.txtComment)
      Me.Controls.Add(Me.btnUnlockLevel1)
      Me.Controls.Add(Me.btnUnlock)
      Me.Name = "UnlockCommentForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Advance Approval Comments"
      CType(Me.grdUnlock, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
		Private m_entity As ISimpleEntity
		Private m_unlockDoc As UnlockDoc
		Private m_unlockDocColl As UnlockDocCollection
		Private myDT As DataTable
		Private mySService As SecurityService
		Private myColor As New Hashtable
    Private StringParserService As StringParserService
    Private m_unlock As UnlockType
#End Region

#Region "SetLabelText"
		'Dim StringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
		Public Sub SetLabelText()
		End Sub
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal unlock As UnlockType)
      MyBase.New()
      InitializeComponent()
      SetLabelText()
      m_entity = entity
      m_unlock = unlock
      If Not m_entity.Originated Then
        Return
      End If
      If m_unlock = UnlockType.UnlockAll Then
        Me.btnUnlock.Enabled = True
        Me.btnUnlockLevel1.Enabled = False
      ElseIf unlock = UnlockType.UnlockLevel1 Then
        Me.btnUnlock.Visible = False
        Me.btnUnlockLevel1.Enabled = True
        Me.btnUnlockLevel1.Location = New Point(Me.btnUnlock.Location.X, Me.btnUnlock.Location.Y)
      End If

      mySService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      m_unlockDocColl = New UnlockDocCollection(m_entity)
      'PrepareColor()
      PrepareDataTable()
      Populate()
      StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

    End Sub
		Private Sub PrepareDataTable()
			myDT = New DataTable
			'สร้าง DataColumn ขึ้นมาเก็บข้อมูล
			myDT.Columns.Add(New DataColumn("No."))
			myDT.Columns.Add(New DataColumn("หมายเหตุ"))
			myDT.Columns.Add(New DataColumn("โดย"))

			'เป็นหัว Column ที่ใช้แสดงผล
			Me.grdUnlock(0, 1).Text = "หมายเหตุ"
			Me.grdUnlock(0, 2).Text = "โดย"
			'Me.grdUnlock(0, 3).Text = " "
		End Sub
		'Private Sub PrepareColor()
		'	myColor(1) = Color.Pink
		'	myColor(2) = Color.NavajoWhite
		'	myColor(3) = Color.LightGreen
		'	myColor(4) = Color.LightBlue
		'	myColor(5) = Color.LightCoral
		'	myColor(6) = Color.LightGray
		'	myColor(7) = Color.LightYellow
		'End Sub
#End Region

#Region "Method"

		Private Sub Populate()
			myDT.Rows.Clear()
			If m_unlockDocColl Is Nothing Then
				Return
			End If

			'ตั้งไว้ 20 rows ถ้าข้อมูลมีมากกว่า ให้ปรับจำนวน row ใน grid
			If m_unlockDocColl.Count > Me.grdUnlock.RowCount Then
				Me.grdUnlock.RowCount = m_unlockDocColl.Count
			End If

			Dim myDR As DataRow
			Dim i As Integer = 0
			For Each ulDoc As UnlockDoc In m_unlockDocColl
				i = i + 1
				myDR = myDT.NewRow
				myDR.Item(0) = i
				myDR.Item(1) = ulDoc.Comment
				Dim temp As User = New User(ulDoc.Person)
				myDR.Item(2) = temp.Name & Format(ulDoc.Date, "dd/MM/yyyy HH:mm:ss")
				myDT.Rows.Add(myDR)
			Next

			Me.grdUnlock.BeginUpdate()
			Me.grdUnlock.Model.PopulateValues(GridRangeInfo.Cells(1, 0, myDT.Rows.Count, myDT.Columns.Count), myDT)
			Me.grdUnlock.Model.RowHeights.ResizeToFit(GridRangeInfo.Rows(0, Me.grdUnlock.Model.RowCount), GridResizeToFitOptions.None)

			Dim cc As Boolean = False
			For i2 As Integer = 1 To myDT.Rows.Count
				If cc Then
					Me.grdUnlock.RowStyles(i2).BackColor = Color.LightGreen
					cc = Not (cc)
				End If
			Next

			'ให้ Col1 - 3 เป็น readonly
			Me.grdUnlock.ColStyles(1).ReadOnly = True
			Me.grdUnlock.ColStyles(2).ReadOnly = True
			'Me.grdUnlock.ColStyles(3).ReadOnly = True

			Me.grdUnlock.Refresh()
			Me.grdUnlock.EndUpdate()
		End Sub

#End Region

#Region "Event Handlers"
		Private tempComment As ApproveDoc
		Private CurrentComment As ApproveDoc
    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click, btnUnlockLevel1.Click
      If Me.txtComment.TextLength <= 0 Then
        Return
      End If
      If CType(sender, Button).Name.ToLower = Me.btnUnlock.Name.ToLower Then
        CType(Me.m_entity, IUnlockAble).Unlock = UnlockType.UnlockAll
      ElseIf CType(sender, Button).Name.ToLower = Me.btnUnlockLevel1.Name.ToLower Then
        CType(Me.m_entity, IUnlockAble).Unlock = UnlockType.UnlockLevel1
      End If
      AddNewComment()
      Populate()
    End Sub
		Private Sub AddNewComment()
			Me.m_unlockDoc = New UnlockDoc
			If Not Me.m_entity Is Nothing Then
				m_unlockDoc.EntityId = m_entity.Id
				m_unlockDoc.EntityType = m_entity.EntityId
			End If
			m_unlockDoc.Comment = Me.txtComment.Text
			m_unlockDoc.Date = Now
      m_unlockDoc.Person = mySService.CurrentUser.Id
      m_unlockDoc.UnlockType = CType(Me.m_entity, IUnlockAble).Unlock
			m_unlockDocColl.Add(m_unlockDoc)
			Try
        Dim saveerr As SaveErrorException = m_unlockDocColl.Save()
        If IsNumeric(saveerr.Message) Then
          MessageBox.Show(Me.StringParserService.Parse("${res:Global.Info.Unlocked}"))
          Me.Close()
        Else
          'CType(Me.m_entity, IUnlockAble).Unlock = UnlockType.Non
          MessageBox.Show(saveerr.Message & vbCrLf & saveerr.InnerException.ToString)
        End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString)
			End Try

		End Sub
#End Region

#Region "Properties"
		Public ReadOnly Property UnlockDocColl() As UnlockDocCollection
			Get
				Return m_unlockDocColl
			End Get
		End Property
#End Region

	End Class

End Namespace

