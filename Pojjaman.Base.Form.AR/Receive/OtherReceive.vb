Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class OtherReceive
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents lblGrossUnit As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnBlank1 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow1 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCancel1 As System.Windows.Forms.Button
    Friend WithEvents btnOK1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(OtherReceive))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.ibtnBlank1 = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow1 = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnCancel1 = New System.Windows.Forms.Button
      Me.btnOK1 = New System.Windows.Forms.Button
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblGross = New System.Windows.Forms.Label
      Me.lblGrossUnit = New System.Windows.Forms.Label
      Me.txtGross = New System.Windows.Forms.TextBox
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.ibtnBlank1)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow1)
      Me.grbDetail.Controls.Add(Me.btnCancel1)
      Me.grbDetail.Controls.Add(Me.btnOK1)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblGross)
      Me.grbDetail.Controls.Add(Me.lblGrossUnit)
      Me.grbDetail.Controls.Add(Me.txtGross)
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(488, 368)
      Me.grbDetail.TabIndex = 27
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายได้/จ่ายอื่นๆ"
      '
      'ibtnBlank1
      '
      Me.ibtnBlank1.Image = CType(resources.GetObject("ibtnBlank1.Image"), System.Drawing.Image)
      Me.ibtnBlank1.Location = New System.Drawing.Point(8, 16)
      Me.ibtnBlank1.Name = "ibtnBlank1"
      Me.ibtnBlank1.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank1.TabIndex = 38
      Me.ibtnBlank1.TabStop = False
      Me.ibtnBlank1.ThemedImage = CType(resources.GetObject("ibtnBlank1.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow1
      '
      Me.ibtnDelRow1.Image = CType(resources.GetObject("ibtnDelRow1.Image"), System.Drawing.Image)
      Me.ibtnDelRow1.Location = New System.Drawing.Point(32, 16)
      Me.ibtnDelRow1.Name = "ibtnDelRow1"
      Me.ibtnDelRow1.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow1.TabIndex = 39
      Me.ibtnDelRow1.TabStop = False
      Me.ibtnDelRow1.ThemedImage = CType(resources.GetObject("ibtnDelRow1.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCancel1
      '
      Me.btnCancel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel1.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel1.Location = New System.Drawing.Point(392, 336)
      Me.btnCancel1.Name = "btnCancel1"
      Me.btnCancel1.TabIndex = 37
      Me.btnCancel1.Text = "Cancel"
      '
      'btnOK1
      '
      Me.btnOK1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK1.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOK1.Location = New System.Drawing.Point(312, 336)
      Me.btnOK1.Name = "btnOK1"
      Me.btnOK1.TabIndex = 36
      Me.btnOK1.Text = "OK"
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 40)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(464, 256)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 35
      Me.tgItem.TreeManager = Nothing
      '
      'lblGross
      '
      Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGross.ForeColor = System.Drawing.Color.Black
      Me.lblGross.Location = New System.Drawing.Point(176, 304)
      Me.lblGross.Name = "lblGross"
      Me.lblGross.Size = New System.Drawing.Size(120, 18)
      Me.lblGross.TabIndex = 31
      Me.lblGross.Text = "รวมยอดเงินจ่ายทั้งสิ้น:"
      Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblGrossUnit
      '
      Me.lblGrossUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblGrossUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGrossUnit.ForeColor = System.Drawing.Color.Black
      Me.lblGrossUnit.Location = New System.Drawing.Point(432, 304)
      Me.lblGrossUnit.Name = "lblGrossUnit"
      Me.lblGrossUnit.Size = New System.Drawing.Size(32, 18)
      Me.lblGrossUnit.TabIndex = 32
      Me.lblGrossUnit.Text = "บาท"
      Me.lblGrossUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtGross
      '
      Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGross, "")
      Me.txtGross.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
      Me.txtGross.Location = New System.Drawing.Point(296, 296)
      Me.Validator.SetMaxValue(Me.txtGross, "")
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(136, 33)
      Me.txtGross.TabIndex = 30
      Me.txtGross.TabStop = False
      Me.txtGross.Text = ""
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'OtherReceive
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "OtherReceive"
      Me.Size = New System.Drawing.Size(504, 384)
      Me.grbDetail.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_receive As Receive
    Private m_collection As ReceiveAccountItemCollection
    Private m_oldCollection As ReceiveAccountItemCollection
    Private m_isDebit As Boolean
#End Region

#Region "Constructors"
    Public Sub New(ByVal myReceive As Receive, ByVal isDebit As Boolean)
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = Receive.GetDebitCreditSchemaTable
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf ItemDelete

      m_isDebit = isDebit
      m_receive = myReceive
      If m_isDebit Then
        m_collection = Me.m_receive.DebitCollection
      Else
        m_collection = Me.m_receive.CreditCollection
      End If

      m_oldCollection = CType(Me.m_collection.Clone, ReceiveAccountItemCollection)

      EventWiring()

      UpdateEntityProperties()
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "OtherReceive"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OtherReceive.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "Linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OtherReceive.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      csButton.ButtonColor = Color.Lavender
      AddHandler csButton.Click, AddressOf ButtonClicked

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OtherReceive.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "receivea_amt"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OtherReceive.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "receivea_amt"
      csAmount.Width = 60

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csAmount)

      Return dst
    End Function
    Public Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      ItemButtonClick(e)
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As ReceiveAccountItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is ReceiveAccountItem Then
          Return Nothing
        End If
        Return CType(row.Tag, ReceiveAccountItem)
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.UpdateAmount()
        Me.m_treeManager.Treetable.AcceptChanges()
      End If
      RefreshDocs()
      tgItem.CurrentRowIndex = index

    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_receive Is Nothing Then
        Return
      End If
      If Me.CurrentItem Is Nothing Then
        Dim doc As New ReceiveAccountItem
        Me.m_collection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "receivea_amt"
            SetAmount(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim code As Object = e.Row("code")
      Dim receivea_amt As Object = e.Row("receivea_amt")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          code = e.ProposedValue
        Case "receivea_amt"
          receivea_amt = e.ProposedValue
        Case Else
          Return
      End Select
      If IsDBNull(code) OrElse code.ToString.Length = 0 Then
        e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AccountCodeMissing}"))
      Else
        e.Row.SetColumnError("code", "")
      End If
      If IsDBNull(receivea_amt) OrElse Not IsNumeric(receivea_amt) OrElse CDec(receivea_amt) <= 0 Then
        e.Row.SetColumnError("receivea_amt", Me.StringParserService.Parse("${res:Global.Error.ReceiveAccountItemMissing}"))
      Else
        e.Row.SetColumnError("receivea_amt", "")
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.Tag Is Nothing Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As ReceiveAccountItem = Me.CurrentItem
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = 0
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      doc.Amount = value
      m_updating = False
    End Sub
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      Dim doc As ReceiveAccountItem = Me.CurrentItem
      If doc Is Nothing Then
        Return False
      End If
      For Each item As ReceiveAccountItem In Me.m_collection
        If Not doc Is item Then
          If e.ProposedValue.ToString.ToLower = item.Account.Code.ToLower Then
            Return True
          End If
        End If
      Next
      Return False
    End Function
    Public Sub SetCode(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim doc As ReceiveAccountItem = Me.CurrentItem
      If doc Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If DupCode(e) Then
                msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {"${res:Global.Error.AccountChart}", e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim acct As New Account(e.ProposedValue.ToString)
      If Not acct.Originated Then
        msgServ.ShowMessageFormatted("${res:Global.Error.NoAccount}", New String() {e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      Else
        doc.Account = acct
      End If
      m_updating = False
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_receive Is Nothing Then
        Return
      End If
      If Me.m_receive.Status.Value >= 3 OrElse Me.m_receive.Status.Value = 0 Then
        grbDetail.Enabled = False
      Else
        grbDetail.Enabled = True
      End If
    End Sub

    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_receive Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_receive.TabPageText)
      If Me.m_isDebit Then
        Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveOutDetail.lblDebitAmount}")
      Else
        Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveOutDetail.lblCreditAmount}")
      End If
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OtherReceive.lblGross}")
      Me.lblGrossUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyText}")
    End Sub
    Protected Overrides Sub EventWiring()
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_receive Is Nothing Then
        Return
      End If

      'Load Items**********************************************************
      RefreshDocs()
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      UpdateAmount()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub UpdateAmount()
      Dim oldFlag As Boolean = m_isInitialized
      m_isInitialized = False
      Me.txtGross.Text = Configuration.FormatToString(Me.m_collection.GetAmount, DigitConfig.Price)
      m_isInitialized = oldFlag
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()

      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_receive Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
      'If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '    " " & m_entity.CancelDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.CancelPerson.Name
      'ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '    " " & m_entity.LastEditDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.LastEditor.Name
      'ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '    " " & m_entity.OriginDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.Originator.Name
      'Else
      '    lblStatus.Text = ""
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
      End Get
      Set(ByVal Value As ISimpleEntity)
      End Set
    End Property

    Public Overrides Sub Initialize()
    End Sub
#End Region

#Region "Event Handlers"

    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim filters(0) As Filter
      filters(0) = New Filter("CodeList", GenIDList())
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccts, filters, Nothing)
    End Sub
    Private Sub SetAccts(ByVal items As BasketItemCollection)
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim myItem As New ReceiveAccountItem
        myItem.Account = New Account(item.Id)
        If i = items.Count - 1 Then
          If m_collection.Count = 0 Then
            m_collection.Add(myItem)
          Else
            If Me.CurrentItem Is Nothing Then
              Me.m_treeManager.SelectedRow.Tag = New ReceiveAccountItem
              Me.m_collection.Insert(index, myItem)
            End If
            Me.CurrentItem.Account = myItem.Account
          End If
        Else
          Me.m_collection.Insert(index, myItem)
        End If
        Me.m_treeManager.Treetable.AcceptChanges()
      Next
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Function GenIDList() As String
      Dim idlist As String = ""
      For Each item As ReceiveAccountItem In Me.m_collection
        idlist += "|" & item.Account.Code & "|"
      Next
      Return idlist
    End Function
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank1.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      If index = -1 OrElse index > Me.m_collection.Count - 1 Then
        Me.m_collection.Add(New ReceiveAccountItem)
      Else
        Me.m_collection.Insert(index, New ReceiveAccountItem)
      End If
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow1.Click
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      If row Is Nothing Then
        Return
      End If
      Dim item As ReceiveAccountItem = Me.CurrentItem
      If item Is Nothing Then
        Return
      End If

      Me.m_collection.Remove(item)
      RefreshDocs()
      Me.tgItem.CurrentRowIndex = index
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_collection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      Me.m_isInitialized = True
    End Sub
#End Region

#Region "Buttons Event"
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK1.Click

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel1.Click
      If m_isDebit Then
        Me.m_receive.DebitCollection = m_oldCollection
      Else
        Me.m_receive.CreditCollection = m_oldCollection
      End If
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New Receive).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_receive Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim maxVisibleCount As Integer
      Dim tgRowHeight As Integer = 17
      maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop
      'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
      '    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
      '        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      '        Me.m_treeManager.Treetable.Childs.Add()
      '    End If
      'End If
      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
    End Sub
#End Region

  End Class
End Namespace