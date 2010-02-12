Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.Services
Imports System.Reflection

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ApprovalCommentForm
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
        Friend WithEvents btnSend As System.Windows.Forms.Button
        Friend WithEvents txtComment As System.Windows.Forms.TextBox
        Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents btnMod As System.Windows.Forms.Button
        Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents chkApprove As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ApprovalCommentForm))
            Me.btnSend = New System.Windows.Forms.Button
            Me.txtComment = New System.Windows.Forms.TextBox
            Me.DataGrid1 = New System.Windows.Forms.DataGrid
            Me.btnCancel = New System.Windows.Forms.Button
            Me.btnAdd = New System.Windows.Forms.Button
            Me.btnMod = New System.Windows.Forms.Button
            Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.chkApprove = New System.Windows.Forms.CheckBox
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnSend
            '
            Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSend.Location = New System.Drawing.Point(576, 400)
            Me.btnSend.Name = "btnSend"
            Me.btnSend.Size = New System.Drawing.Size(96, 23)
            Me.btnSend.TabIndex = 4
            Me.btnSend.Text = "Send"
            '
            'txtComment
            '
            Me.txtComment.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.txtComment.Location = New System.Drawing.Point(8, 396)
            Me.txtComment.Multiline = True
            Me.txtComment.Name = "txtComment"
            Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtComment.Size = New System.Drawing.Size(560, 48)
            Me.txtComment.TabIndex = 2
            Me.txtComment.Text = ""
            '
            'DataGrid1
            '
            Me.DataGrid1.AllowSorting = False
            Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGrid1.CaptionVisible = False
            Me.DataGrid1.DataMember = ""
            Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid1.Location = New System.Drawing.Point(8, 32)
            Me.DataGrid1.Name = "DataGrid1"
            Me.DataGrid1.ReadOnly = True
            Me.DataGrid1.RowHeaderWidth = 0
            Me.DataGrid1.Size = New System.Drawing.Size(670, 360)
            Me.DataGrid1.TabIndex = 6
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Location = New System.Drawing.Point(576, 432)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 23)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "ยกเลิก"
            '
            'btnAdd
            '
            Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAdd.Location = New System.Drawing.Point(472, 8)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(96, 23)
            Me.btnAdd.TabIndex = 0
            Me.btnAdd.Text = "เพิ่มความเห็น"
            '
            'btnMod
            '
            Me.btnMod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnMod.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnMod.Location = New System.Drawing.Point(576, 8)
            Me.btnMod.Name = "btnMod"
            Me.btnMod.Size = New System.Drawing.Size(96, 23)
            Me.btnMod.TabIndex = 1
            Me.btnMod.Text = "แก้ไข"
            '
            'btnApprove
            '
            Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnApprove.Image = CType(resources.GetObject("btnApprove.Image"), System.Drawing.Image)
            Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnApprove.Location = New System.Drawing.Point(360, 8)
            Me.btnApprove.Name = "btnApprove"
            Me.btnApprove.Size = New System.Drawing.Size(96, 23)
            Me.btnApprove.TabIndex = 7
            Me.btnApprove.Text = "อนุมัติ"
            Me.btnApprove.ThemedImage = CType(resources.GetObject("btnApprove.ThemedImage"), System.Drawing.Bitmap)
            Me.btnApprove.Visible = False
            '
            'chkApprove
            '
            Me.chkApprove.Location = New System.Drawing.Point(8, 446)
            Me.chkApprove.Name = "chkApprove"
            Me.chkApprove.Size = New System.Drawing.Size(176, 24)
            Me.chkApprove.TabIndex = 3
            Me.chkApprove.Text = "อนุมัติเอกสารพร้อมความเห็นนี้"
            '
            'ApprovalCommentForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(686, 470)
            Me.Controls.Add(Me.chkApprove)
            Me.Controls.Add(Me.DataGrid1)
            Me.Controls.Add(Me.txtComment)
            Me.Controls.Add(Me.btnSend)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnAdd)
            Me.Controls.Add(Me.btnMod)
            Me.Controls.Add(Me.btnApprove)
            Me.Name = "ApprovalCommentForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Approval Comments"
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As ISimpleEntity
        Private m_approvalComment As ApprovalComment
        Private m_approvalCommentColl As ApprovalCommentCollection

        Private m_isApproved As Boolean

        Private myDT As DataTable
#End Region

#Region "SetLabelText"
        Dim StringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Public Sub SetLabelText()
            Me.btnAdd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.ApprovalCommentForm.btnAdd}")
            Me.btnMod.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.ApprovalCommentForm.btnMod}")

            Me.chkApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.ApprovalCommentForm.chkApprove}")

            Me.btnSend.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.ApprovalCommentForm.btnSend}")
            Me.btnCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.ApprovalCommentForm.btnCancel}")
        End Sub
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity)
            MyBase.New()
            InitializeComponent()
            SetLabelText()
            m_entity = entity
            If Not m_entity.Originated Then
                Return
            End If
            m_approvalCommentColl = New ApprovalCommentCollection(m_entity)
            m_isApproved = False
            CheckIsApproved()
            PrepareDataTable()
            Populate()
            btnMod.Enabled = False
            DisableButton()
        End Sub
        Private Sub PrepareDataTable()
            myDT = New DataTable
            myDT.Columns.Add(New DataColumn("No."))
            myDT.Columns.Add(New DataColumn("ความคิดเห็น"))
            myDT.Columns.Add(New DataColumn("โดย"))
            myDT.Columns.Add(New DataColumn("ApproveStatus"))
            DataGrid1.TableStyles.Add(GetTableStyle(myDT))
        End Sub
#End Region

#Region "Style"
        Private Function GetTableStyle(ByVal myDT As DataTable) As DataGridTableStyle
            Dim ts As New DataGridTableStyle
            ts.MappingName = myDT.TableName

            Dim column1 As New DataGridColoredTextBoxColumn 'DataGridTextBoxColumn
            column1.Alignment = HorizontalAlignment.Center
            column1.MappingName = myDT.Columns(0).ColumnName
            column1.HeaderText = "No."
            column1.Width = 35

            Dim column2 As New MultiLineColoredColumn 'MultiLineColumn
            column2.Alignment = HorizontalAlignment.Left
            column2.MappingName = myDT.Columns(1).ColumnName
            column2.HeaderText = "Comment"
            column2.Width = 450
            column2.ReadOnly = False
            column2.AutoAdjustHeight = True

            Dim column3 As New MultiLineColoredColumn 'MultiLineColumn
            column3.Alignment = HorizontalAlignment.Left
            column3.MappingName = myDT.Columns(2).ColumnName
            column3.HeaderText = "By"
            column3.Width = 135
            column3.ReadOnly = False
            column3.AutoAdjustHeight = True

            ts.GridColumnStyles.Add(column1)
            ts.GridColumnStyles.Add(column2)
            ts.GridColumnStyles.Add(column3)
            Return ts
        End Function
#End Region

#Region "Method"
        Private Sub CheckIsApproved()
            Dim DocApprovable As IApprovAble = CType(m_entity, IApprovAble)

            Dim accessId As Integer = Entity.GetAccessIdFromFullClassName(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(m_entity.EntityId) & "ForApprove")
            Dim accessValue As Integer = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).GetAccess(accessId)

            If DocApprovable.IsApproved OrElse m_approvalCommentColl.IsApproved OrElse accessValue = 0 Then
                m_isApproved = True
            End If
        End Sub
        Private Sub Populate()
            If m_isApproved Then
                'btnApprove.Visible = False
                chkApprove.Visible = False
            End If

            DataGrid1.DataSource = Nothing
            myDT.Rows.Clear()

            If m_approvalCommentColl Is Nothing Then
                Return
            End If

            Dim myDR As DataRow
            For Each comm As ApprovalComment In m_approvalCommentColl
                myDR = myDT.NewRow
                myDR.Item(0) = comm.LineNumber
                myDR.Item(1) = comm.Comment & vbCrLf & vbCrLf & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.ApprovalCommentForm.MsgAdd}") & Format(comm.OriginDate, "dd/MM/yyyy HH:mm")
                If Not comm.LastEditDate.Equals(Date.MinValue) Then
                    myDR.Item(1) &= vbCrLf & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.ApprovalCommentForm.MsgLastEdit}") & Format(comm.LastEditDate, "dd/MM/yyyy HH:mm")
                End If
                Dim temp As User = New User(comm.Originator)
                myDR.Item(2) = temp.Name
                myDR.Item(3) = comm.IsApproveComment
                myDT.Rows.Add(myDR)
            Next
            myDT.DefaultView.AllowNew = False

            DataGrid1.DataSource = myDT
        End Sub
        Private Sub SelectTheCell()
            If m_approvalCommentColl.Count <= 1 Then
                Return
            End If
            Dim myRow As Integer
            If Not CurrentComment Is Nothing Then
                myRow = CurrentComment.LineNumber - 1
            Else
                myRow = m_approvalCommentColl.Count - 1
            End If
            DataGrid1.CurrentCell = New DataGridCell(m_approvalCommentColl.Count - 1, 1)
            DataGrid1.CurrentCell = New DataGridCell(myRow, 1)
            DataGrid1.Select(myRow)
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub DisableButton()
            txtComment.Text = ""
            chkApprove.Checked = False
            Me.txtComment.Enabled = False
            Me.btnSend.Enabled = False
            Me.btnCancel.Enabled = False
            Me.chkApprove.Enabled = False
        End Sub
        Private Sub EnableButton()
            txtComment.Text = ""
            chkApprove.Checked = False
            Me.txtComment.Enabled = True
            Me.btnSend.Enabled = True
            Me.btnCancel.Enabled = True
            Me.chkApprove.Enabled = True
        End Sub
        Private tempComment As ApprovalComment
        Private CurrentComment As ApprovalComment
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            btnMod.Enabled = False
            EnableButton()
            CurrentComment = Nothing
            txtComment.Focus()
        End Sub
        Private Sub btnMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMod.Click
            EnableButton()
            CurrentComment = tempComment
            txtComment.Text = CurrentComment.Comment
            txtComment.Focus()
        End Sub
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            DisableButton()
            CurrentComment = Nothing
        End Sub
        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            If Me.txtComment.TextLength <= 0 Then
                Return
            End If
            Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            If Not CurrentComment Is Nothing Then
                Dim i As Integer = m_approvalCommentColl.IndexOf(CurrentComment)
                m_approvalCommentColl.Remove(CurrentComment)
                CurrentComment.Comment = txtComment.Text
                If Not m_isApproved Then
                    CurrentComment.IsApproveComment = chkApprove.Checked
                End If
                CurrentComment.LastEditor = CurrentComment.Originator
                CurrentComment.LastEditDate = Now
                m_approvalCommentColl.Insert(i, CurrentComment)
            Else
                Me.m_approvalComment = New ApprovalComment
                If Not Me.m_entity Is Nothing Then
                    m_approvalComment.EntityId = m_entity.Id
                    m_approvalComment.EntityType = m_entity.EntityId
                End If
                m_approvalComment.LineNumber = m_approvalCommentColl.Count + 1
                m_approvalComment.Comment = Me.txtComment.Text
                m_approvalComment.IsApproveComment = Me.chkApprove.Checked
                'Record Submitter
                m_approvalComment.Originator = mySService.CurrentUser.Id
                m_approvalComment.OriginDate = Now

                'Add to Collection
                m_approvalCommentColl.Add(m_approvalComment)
            End If
            m_approvalCommentColl.Save()

            If chkApprove.Checked Then
                If TypeOf m_entity Is IApprovAble Then
                    Dim DocApprovable As IApprovAble = CType(m_entity, IApprovAble)
                    DocApprovable.ApproveData(m_entity.Id, mySService.CurrentUser.Id, Now)
                    m_isApproved = True

                    Dim ty As Type = CType(m_entity, Object).GetType
                    Dim pi As PropertyInfo = ty.GetProperty("ApprovePerson")
                    If Not pi Is Nothing Then
                        pi.SetValue(m_entity, mySService.CurrentUser, Nothing)
                    End If

                    pi = ty.GetProperty("ApproveDate")
                    If Not pi Is Nothing Then
                        pi.SetValue(m_entity, Now, Nothing)
                    End If
                End If
            End If

            Populate()
            SelectTheCell()

            btnMod.Enabled = False
            DisableButton()
            CurrentComment = Nothing
        End Sub
        Public Sub DataGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
            For Each comm As ApprovalComment In m_approvalCommentColl
                If comm.LineNumber = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) Then
                    tempComment = comm
                End If
            Next

            Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            If tempComment.Originator = mySService.CurrentUser.Id Then
                btnMod.Enabled = True
            Else
                btnMod.Enabled = False
            End If
        End Sub
        Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
            Dim DocToApprove As Object = SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(m_entity.EntityId), m_entity.Id)
            Dim DocApprovable As IApprovAble = CType(DocToApprove, IApprovAble)

            Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            DocApprovable.ApproveData(m_entity.Id, mySService.CurrentUser.Id, Now)

            m_isApproved = True
            Populate()
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property ApprovalCommentColl() As ApprovalCommentCollection
            Get
                Return m_approvalCommentColl
            End Get
        End Property
#End Region

    End Class

End Namespace


Public Class DataGridColoredTextBoxColumn
    Inherits DataGridTextBoxColumn
    'Fields
    'Constructors
    'Events
    'Methods
    Public Sub New()
        'Warning: Implementation not found
    End Sub
    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)
        Try
            Dim o As Object
            o = Me.GetColumnValueAtRow(source, rowNum)
            Dim DR As DataRow
            DR = DirectCast(source.Current, DataRowView).DataView.Item(rowNum).Row
            If Not o Is Nothing Then
                If DR.Item(3) Then
                    backBrush = New SolidBrush(Color.Pink)
                    'foreBrush = New SolidBrush(Color.White)
                End If
            End If
        Catch ex As Exception
            ' empty catch
        Finally
            ' make sure the base class gets called to do the drawing with
            ' the possibly changed brushes
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        End Try

    End Sub
End Class

Public Class MultiLineColoredColumn
    Inherits MultiLineColumn
    'Fields
    'Constructors
    'Events
    'Methods
    Public Sub New()
        'Warning: Implementation not found
    End Sub
    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)
        Try
            Dim o As Object
            o = Me.GetColumnValueAtRow(source, rowNum)
            Dim DR As DataRow
            DR = DirectCast(source.Current, DataRowView).DataView.Item(rowNum).Row
            If Not o Is Nothing Then
                If DR.Item(3) Then
                    backBrush = New SolidBrush(Color.Pink)
                    'foreBrush = New SolidBrush(Color.White)
                End If
            End If
        Catch ex As Exception
            ' empty catch
        Finally
            ' make sure the base class gets called to do the drawing with
            ' the possibly changed brushes
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        End Try

    End Sub
End Class

