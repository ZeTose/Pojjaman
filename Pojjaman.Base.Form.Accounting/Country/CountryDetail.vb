'Imports Longkong.Pojjaman.Services
'Imports Longkong.Core.Services
'Imports Longkong.Pojjaman.Gui
'Imports Longkong.Pojjaman.BusinessLogic
'Imports System.Drawing.Printing
'Imports Longkong.Pojjaman.Gui.Components
'Imports System.Globalization
'Imports System.Reflection
'Imports Longkong.Pojjaman.TextHelper
'Imports Longkong.Pojjaman.Gui.ReportsAndDocs

'Namespace Longkong.Pojjaman.Gui.Panels
'    Public Class CountryDetail
'        Inherits AbstractEntityDetailPanelView
'        Implements IValidatable

'#Region " Windows Form Designer generated code "
'        'UserControl overrides dispose to clean up the component list.
'        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'            If disposing Then
'                If Not (components Is Nothing) Then
'                    components.Dispose()
'                End If
'            End If
'            MyBase.Dispose(disposing)
'        End Sub

'        'Required by the Windows Form Designer
'        Private components As System.ComponentModel.IContainer

'        'NOTE: The following procedure is required by the Windows Form Designer
'        'It can be modified using the Windows Form Designer.  
'        'Do not modify it using the code editor.
'        Friend WithEvents lblItem As System.Windows.Forms.Label
'        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
'        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
'        Friend WithEvents lblCode As System.Windows.Forms.Label
'        Friend WithEvents txtCode As System.Windows.Forms.TextBox
'        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
'        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
'        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
'        Friend WithEvents txtName As System.Windows.Forms.TextBox
'        Friend WithEvents txtUnit As System.Windows.Forms.TextBox
'        Friend WithEvents txtSubUnit As System.Windows.Forms.TextBox
'        Friend WithEvents lblName As System.Windows.Forms.Label
'        Friend WithEvents lblUnit As System.Windows.Forms.Label
'        Friend WithEvents lblSubUnit As System.Windows.Forms.Label
'        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
'            Me.components = New System.ComponentModel.Container
'            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CountryDetail))
'            Me.lblItem = New System.Windows.Forms.Label
'            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
'            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
'            Me.txtCode = New System.Windows.Forms.TextBox
'            Me.txtName = New System.Windows.Forms.TextBox
'            Me.txtUnit = New System.Windows.Forms.TextBox
'            Me.txtSubUnit = New System.Windows.Forms.TextBox
'            Me.lblCode = New System.Windows.Forms.Label
'            Me.lblName = New System.Windows.Forms.Label
'            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
'            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
'            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
'            Me.lblUnit = New System.Windows.Forms.Label
'            Me.lblSubUnit = New System.Windows.Forms.Label
'            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
'            Me.SuspendLayout()
'            '
'            'lblItem
'            '
'            Me.lblItem.BackColor = System.Drawing.Color.Transparent
'            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.lblItem.Location = New System.Drawing.Point(8, 80)
'            Me.lblItem.Name = "lblItem"
'            Me.lblItem.Size = New System.Drawing.Size(112, 18)
'            Me.lblItem.TabIndex = 9
'            Me.lblItem.Text = "รายการรับวางบิล:"
'            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'            '
'            'ErrorProvider1
'            '
'            Me.ErrorProvider1.ContainerControl = Me
'            '
'            'Validator
'            '
'            Me.Validator.BackcolorChanging = False
'            Me.Validator.DataTable = Nothing
'            Me.Validator.ErrorProvider = Me.ErrorProvider1
'            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
'            Me.Validator.HasNewRow = False
'            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
'            '
'            'txtCode
'            '
'            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
'            Me.Validator.SetDisplayName(Me.txtCode, "")
'            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
'            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
'            Me.txtCode.Location = New System.Drawing.Point(96, 15)
'            Me.Validator.SetMaxValue(Me.txtCode, "")
'            Me.Validator.SetMinValue(Me.txtCode, "")
'            Me.txtCode.Name = "txtCode"
'            Me.Validator.SetRegularExpression(Me.txtCode, "")
'            Me.Validator.SetRequired(Me.txtCode, True)
'            Me.txtCode.Size = New System.Drawing.Size(112, 21)
'            Me.txtCode.TabIndex = 0
'            Me.txtCode.TabStop = False
'            Me.txtCode.Text = ""
'            '
'            'txtName
'            '
'            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
'            Me.Validator.SetDisplayName(Me.txtName, "")
'            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
'            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
'            Me.txtName.Location = New System.Drawing.Point(288, 16)
'            Me.Validator.SetMaxValue(Me.txtName, "")
'            Me.Validator.SetMinValue(Me.txtName, "")
'            Me.txtName.Name = "txtName"
'            Me.Validator.SetRegularExpression(Me.txtName, "")
'            Me.Validator.SetRequired(Me.txtName, False)
'            Me.txtName.Size = New System.Drawing.Size(400, 21)
'            Me.txtName.TabIndex = 1
'            Me.txtName.TabStop = False
'            Me.txtName.Text = ""
'            '
'            'txtUnit
'            '
'            Me.Validator.SetDataType(Me.txtUnit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
'            Me.Validator.SetDisplayName(Me.txtUnit, "")
'            Me.txtUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.Validator.SetGotFocusBackColor(Me.txtUnit, System.Drawing.Color.Empty)
'            Me.Validator.SetInvalidBackColor(Me.txtUnit, System.Drawing.Color.Empty)
'            Me.txtUnit.Location = New System.Drawing.Point(96, 40)
'            Me.Validator.SetMaxValue(Me.txtUnit, "")
'            Me.Validator.SetMinValue(Me.txtUnit, "")
'            Me.txtUnit.Name = "txtUnit"
'            Me.Validator.SetRegularExpression(Me.txtUnit, "")
'            Me.Validator.SetRequired(Me.txtUnit, True)
'            Me.txtUnit.Size = New System.Drawing.Size(112, 21)
'            Me.txtUnit.TabIndex = 2
'            Me.txtUnit.TabStop = False
'            Me.txtUnit.Text = ""
'            '
'            'txtSubUnit
'            '
'            Me.Validator.SetDataType(Me.txtSubUnit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
'            Me.Validator.SetDisplayName(Me.txtSubUnit, "")
'            Me.txtSubUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.Validator.SetGotFocusBackColor(Me.txtSubUnit, System.Drawing.Color.Empty)
'            Me.Validator.SetInvalidBackColor(Me.txtSubUnit, System.Drawing.Color.Empty)
'            Me.txtSubUnit.Location = New System.Drawing.Point(288, 40)
'            Me.Validator.SetMaxValue(Me.txtSubUnit, "")
'            Me.Validator.SetMinValue(Me.txtSubUnit, "")
'            Me.txtSubUnit.Name = "txtSubUnit"
'            Me.Validator.SetRegularExpression(Me.txtSubUnit, "")
'            Me.Validator.SetRequired(Me.txtSubUnit, True)
'            Me.txtSubUnit.Size = New System.Drawing.Size(112, 21)
'            Me.txtSubUnit.TabIndex = 3
'            Me.txtSubUnit.TabStop = False
'            Me.txtSubUnit.Text = ""
'            '
'            'lblCode
'            '
'            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.lblCode.ForeColor = System.Drawing.Color.Black
'            Me.lblCode.Location = New System.Drawing.Point(16, 16)
'            Me.lblCode.Name = "lblCode"
'            Me.lblCode.Size = New System.Drawing.Size(80, 18)
'            Me.lblCode.TabIndex = 5
'            Me.lblCode.Text = "รหัส:"
'            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblName
'            '
'            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.lblName.ForeColor = System.Drawing.Color.Black
'            Me.lblName.Location = New System.Drawing.Point(208, 16)
'            Me.lblName.Name = "lblName"
'            Me.lblName.Size = New System.Drawing.Size(80, 18)
'            Me.lblName.TabIndex = 6
'            Me.lblName.Text = "ชื่อ:"
'            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'ibtnBlank
'            '
'            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
'            Me.ibtnBlank.Location = New System.Drawing.Point(120, 72)
'            Me.ibtnBlank.Name = "ibtnBlank"
'            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
'            Me.ibtnBlank.TabIndex = 10
'            Me.ibtnBlank.TabStop = False
'            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
'            '
'            'ibtnDelRow
'            '
'            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
'            Me.ibtnDelRow.Location = New System.Drawing.Point(144, 72)
'            Me.ibtnDelRow.Name = "ibtnDelRow"
'            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
'            Me.ibtnDelRow.TabIndex = 11
'            Me.ibtnDelRow.TabStop = False
'            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
'            '
'            'tgItem
'            '
'            Me.tgItem.AllowNew = False
'            Me.tgItem.AllowSorting = False
'            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
'                        Or System.Windows.Forms.AnchorStyles.Left) _
'                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
'            Me.tgItem.AutoColumnResize = False
'            Me.tgItem.CaptionVisible = False
'            Me.tgItem.Cellchanged = False
'            Me.tgItem.DataMember = ""
'            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
'            Me.tgItem.Location = New System.Drawing.Point(8, 96)
'            Me.tgItem.Name = "tgItem"
'            Me.tgItem.Size = New System.Drawing.Size(784, 296)
'            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
'            Me.tgItem.TabIndex = 4
'            Me.tgItem.TreeManager = Nothing
'            '
'            'lblUnit
'            '
'            Me.lblUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.lblUnit.ForeColor = System.Drawing.Color.Black
'            Me.lblUnit.Location = New System.Drawing.Point(16, 40)
'            Me.lblUnit.Name = "lblUnit"
'            Me.lblUnit.Size = New System.Drawing.Size(80, 18)
'            Me.lblUnit.TabIndex = 7
'            Me.lblUnit.Text = "หน่วยเงินตรา:"
'            Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblSubUnit
'            '
'            Me.lblSubUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
'            Me.lblSubUnit.ForeColor = System.Drawing.Color.Black
'            Me.lblSubUnit.Location = New System.Drawing.Point(208, 40)
'            Me.lblSubUnit.Name = "lblSubUnit"
'            Me.lblSubUnit.Size = New System.Drawing.Size(80, 18)
'            Me.lblSubUnit.TabIndex = 8
'            Me.lblSubUnit.Text = "หน่วยย่อย:"
'            Me.lblSubUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'CountryDetail
'            '
'            Me.Controls.Add(Me.lblSubUnit)
'            Me.Controls.Add(Me.txtSubUnit)
'            Me.Controls.Add(Me.lblUnit)
'            Me.Controls.Add(Me.txtUnit)
'            Me.Controls.Add(Me.tgItem)
'            Me.Controls.Add(Me.ibtnBlank)
'            Me.Controls.Add(Me.ibtnDelRow)
'            Me.Controls.Add(Me.lblCode)
'            Me.Controls.Add(Me.txtCode)
'            Me.Controls.Add(Me.lblName)
'            Me.Controls.Add(Me.txtName)
'            Me.Controls.Add(Me.lblItem)
'            Me.Name = "CountryDetail"
'            Me.Size = New System.Drawing.Size(808, 400)
'            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'#Region "Members"
'        Private m_entity As Country
'        Private m_isInitialized As Boolean = False
'        Private m_treeManager As TreeManager

'        Private m_tableStyleEnable As Hashtable

'        Private m_enableState As Hashtable
'#End Region

'#Region "Constructors"
'        Public Sub New()
'            MyBase.New()
'            Me.InitializeComponent()
'            Me.SetLabelText()
'            Initialize()

'            SaveEnableState()
'            Dim dt As TreeTable = Country.GetSchemaTable()
'            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
'            m_treeManager = New TreeManager(dt, tgItem)
'            m_treeManager.SetTableStyle(dst)
'            m_treeManager.AllowSorting = False
'            m_treeManager.AllowDelete = False
'            tgItem.AllowNew = False

'            AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
'            AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
'            AddHandler dt.RowDeleted, AddressOf ItemDelete

'            EventWiring()
'        End Sub
'        Private Sub SaveEnableState()
'            m_enableState = New Hashtable
'            For Each ctrl As Control In Me.Controls
'                m_enableState.Add(ctrl, ctrl.Enabled)
'            Next
'        End Sub
'#End Region

'#Region "Style"
'        Public Function CreateTableStyle() As DataGridTableStyle
'            Dim dst As New DataGridTableStyle
'            dst.MappingName = "CurrencyRate"
'            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

'            Dim csLineNumber As New TreeTextColumn
'            csLineNumber.MappingName = "Linenumber"
'            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CountryDetail.LineNumberHeaderText}")
'            csLineNumber.NullText = ""
'            csLineNumber.Width = 30
'            csLineNumber.DataAlignment = HorizontalAlignment.Center
'            csLineNumber.ReadOnly = True
'            csLineNumber.TextBox.Name = "Linenumber"

'            Dim csDate As New DataGridTimePickerColumn
'            csDate.MappingName = "Date"
'            csDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CountryDetail.DateHeaderText}")
'            csDate.NullText = ""

'            Dim csRate As New TreeTextColumn
'            csRate.MappingName = "Rate"
'            csRate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CountryDetail.RateHeaderText}")
'            csRate.NullText = ""
'            csRate.DataAlignment = HorizontalAlignment.Right
'            csRate.Format = "#,###.##"
'            csRate.TextBox.Name = "Rate"


'            dst.GridColumnStyles.Add(csLineNumber)
'            dst.GridColumnStyles.Add(csDate)
'            dst.GridColumnStyles.Add(csRate)

'            m_tableStyleEnable = New Hashtable
'            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
'                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
'            Next
'            Return dst
'        End Function
'#End Region

'#Region "Properties"
'        Private ReadOnly Property CurrentItem() As CurrencyRate
'            Get
'                Dim row As TreeRow = Me.m_treeManager.SelectedRow
'                If row Is Nothing Then
'                    Return Nothing
'                End If
'                If Not TypeOf row.Tag Is CurrencyRate Then
'                    Return Nothing
'                End If
'                Return CType(row.Tag, CurrencyRate)
'            End Get
'        End Property
'#End Region

'#Region "TreeTable Handlers"
'        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
'            If Not m_isInitialized Then
'                Return
'            End If
'            Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
'            If ValidateRow(CType(e.Row, TreeRow)) Then
'                Me.m_treeManager.Treetable.AcceptChanges()
'            End If
'            Me.WorkbenchWindow.ViewContent.IsDirty = True
'        End Sub
'        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
'            If Not m_isInitialized Then
'                Return
'            End If
'            If Me.m_treeManager.SelectedRow Is Nothing Then
'                Return
'            End If
'            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
'            If Me.m_entity Is Nothing Then
'                Return
'            End If
'            If Me.CurrentItem Is Nothing Then
'                Dim doc As New CurrencyRate
'                Me.m_entity.RateCollection.Add(doc)
'                Me.m_treeManager.SelectedRow.Tag = doc
'            End If
'            Try
'                Select Case e.Column.ColumnName.ToLower
'                    Case "date"
'                        SetDate(e)
'                    Case "rate"
'                        SetRate(e)
'                End Select
'                ValidateRow(e)
'            Catch ex As Exception
'                MessageBox.Show(ex.ToString)
'            End Try
'        End Sub
'        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
'            'Dim code As Object = e.Row("code")
'            'Dim billai_entitytype As Object = e.Row("billai_entitytype")
'            'Dim billai_amt As Object = e.Row("billai_amt")

'            'Select Case e.Column.ColumnName.ToLower
'            '    Case "code"
'            '        code = e.ProposedValue
'            '    Case "billai_entitytype"
'            '        billai_entitytype = e.ProposedValue
'            '    Case "billai_amt"
'            '        billai_amt = e.ProposedValue
'            '    Case Else
'            '        Return
'            'End Select

'            'Dim isBlankRow As Boolean = False
'            'If IsDBNull(billai_entitytype) Then
'            '    isBlankRow = True
'            'End If
'            'If Not isBlankRow Then
'            '    Select Case CInt(billai_entitytype)
'            '        Case 45 'รับของ
'            '            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
'            '                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.GoodsReceiptCodeMissing}"))
'            '            Else
'            '                e.Row.SetColumnError("code", "")
'            '            End If
'            '        Case 50 'รับของ
'            '            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
'            '                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.EqMaintenanceCodeMissing}"))
'            '            Else
'            '                e.Row.SetColumnError("code", "")
'            '            End If
'            '        Case 46 'ลดหนี้
'            '            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
'            '                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.PurchaseCNCodeMissing}"))
'            '            Else
'            '                e.Row.SetColumnError("code", "")
'            '            End If
'            '        Case 47 'เพิ่มหนี้
'            '            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
'            '                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.BillAcceptanceCodeMissing}"))
'            '            Else
'            '                e.Row.SetColumnError("code", "")
'            '            End If
'            '        Case 15 'เจ้าหนี้ยกมา
'            '            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
'            '                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.APOpeningBalanceCodeMissing}"))
'            '            Else
'            '                e.Row.SetColumnError("code", "")
'            '            End If
'            '        Case Else
'            '            Return
'            '    End Select
'            '    If IsDBNull(billai_amt) OrElse Not IsNumeric(billai_amt) OrElse CDec(billai_amt) <= 0 Then
'            '        e.Row.SetColumnError("billai_amt", Me.StringParserService.Parse("${res:Global.Error.BillAcceptanceAmountMissing}"))
'            '    Else
'            '        e.Row.SetColumnError("billai_amt", "")
'            '    End If
'            'End If
'        End Sub
'        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
'            If row.Tag Is Nothing Then
'                Return False
'            End If
'            Return True
'        End Function
'        Private m_updating As Boolean = False
'        Public Sub SetDate(ByVal e As DataColumnChangeEventArgs)
'            If m_updating Then
'                Return
'            End If
'            Dim cr As CurrencyRate = Me.CurrentItem
'            m_updating = True
'            cr.Date = CDate(e.ProposedValue)
'            m_updating = False
'        End Sub
'        Public Sub SetRate(ByVal e As DataColumnChangeEventArgs)
'            If m_updating Then
'                Return
'            End If
'            Dim cr As CurrencyRate = Me.CurrentItem
'            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
'                e.ProposedValue = ""
'                Return
'            End If
'            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), 5)
'            Dim value As Decimal = CDec(e.ProposedValue)
'            m_updating = True
'            If cr.Date.Equals(Date.MinValue) Then
'                cr.Date = Now.Date
'                e.Row("date") = cr.Date
'            End If
'            cr.Rate = value
'            m_updating = False
'        End Sub
'        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
'        End Sub
'#End Region

'#Region "IListDetail"
'        Public Overrides Sub CheckFormEnable()
'            If Me.m_entity Is Nothing Then
'                Return
'            End If
'            If Me.m_entity.Status.Value = 0 _
'            OrElse Me.m_entity.Status.Value >= 3 _
'            Then
'                Me.Enabled = False
'            Else
'                Me.Enabled = True
'            End If
'        End Sub
'        Public Overrides Sub ClearDetail()
'            For Each crlt As Control In Me.Controls
'                If crlt.Name.StartsWith("txt") Then
'                    crlt.Text = ""
'                End If
'            Next
'        End Sub
'        Public Overrides Sub SetLabelText()
'            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
'            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CountryDetail.lblCode}")
'            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CountryDetail.lblName}")
'            Me.lblUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CountryDetail.lblUnit}")
'            Me.lblSubUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CountryDetail.lblSubUnit}")

'            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CountryDetail.lblItem}")
'        End Sub
'        Protected Overrides Sub EventWiring()
'            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
'            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
'            AddHandler txtUnit.TextChanged, AddressOf Me.ChangeProperty
'            AddHandler txtSubUnit.TextChanged, AddressOf Me.ChangeProperty
'        End Sub
'        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
'        Public Overrides Sub UpdateEntityProperties()
'            m_isInitialized = False
'            ClearDetail()
'            If m_entity Is Nothing Then
'                Return
'            End If
'            txtCode.Text = m_entity.Code
'            txtName.Text = m_entity.Name
'            txtUnit.Text = m_entity.Unit
'            txtSubUnit.Text = m_entity.SubUnit

'            RefreshDocs()

'            SetStatus()
'            SetLabelText()
'            CheckFormEnable()
'            m_isInitialized = True
'        End Sub
'        Private Sub RefreshDocs()
'            Me.m_isInitialized = False
'            Me.m_entity.RateCollection.PopulateCountry(m_treeManager.Treetable)
'            RefreshBlankGrid()
'            ReIndex()
'            Me.m_isInitialized = True
'        End Sub
'        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
'            If e.Name = "ItemChanged" Then
'                Me.WorkbenchWindow.ViewContent.IsDirty = True
'            End If
'        End Sub
'        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
'            If Me.m_entity Is Nothing Or Not m_isInitialized Then
'                Return
'            End If
'            Dim dirtyFlag As Boolean = False
'            Select Case CType(sender, Control).Name.ToLower
'                Case "txtcode"
'                    Me.m_entity.Code = txtCode.Text
'                    dirtyFlag = True
'                Case "txtname"
'                    Me.m_entity.Name = txtName.Text
'                    dirtyFlag = True
'                Case "txtunit"
'                    Me.m_entity.Unit = txtUnit.Text
'                    dirtyFlag = True
'                Case "txtsubunit"
'                    Me.m_entity.SubUnit = txtSubUnit.Text
'                    dirtyFlag = True
'            End Select
'            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
'            CheckFormEnable()
'        End Sub
'        Public Sub SetStatus()
'            'If m_entity.Canceled Then
'            '    Me.StatusBarService.SetMessage("ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
'            '    " " & m_entity.CancelDate.ToShortTimeString & _
'            '    "  โดย:" & m_entity.CancelPerson.Name)
'            'ElseIf m_entity.Edited Then
'            '    Me.StatusBarService.SetMessage("แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
'            '    " " & m_entity.LastEditDate.ToShortTimeString & _
'            '    "  โดย:" & m_entity.LastEditor.Name)
'            'ElseIf m_entity.Originated Then
'            '    Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
'            '    " " & m_entity.OriginDate.ToShortTimeString & _
'            '    "  โดย:" & m_entity.Originator.Name)
'            'Else
'            '    Me.StatusBarService.SetMessage("")
'            'End If
'        End Sub
'        Public Overrides Property Entity() As ISimpleEntity
'            Get
'                Return Me.m_entity
'            End Get
'            Set(ByVal Value As ISimpleEntity)
'                If Not m_entity Is Nothing Then
'                    RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
'                    Me.m_entity = Nothing
'                End If
'                Me.m_entity = CType(Value, Country)
'                'Hack:
'                If Not m_entity Is Nothing Then
'                    Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
'                End If
'                UpdateEntityProperties()
'            End Set
'        End Property

'        Public Overrides Sub Initialize()
'            'PopulateRequestor()
'            'PopulateCostCenter()
'        End Sub


'#End Region

'#Region "Event Handlers"
'        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
'            Dim index As Integer = tgItem.CurrentRowIndex
'            If index > Me.m_entity.RateCollection.Count - 1 Then
'                Return
'            End If
'            Me.m_entity.RateCollection.Insert(index, New CurrencyRate)
'            RefreshDocs()
'            tgItem.CurrentRowIndex = index
'            '   Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
'            ', Me.m_treeManager.Treetable.Columns("billai_amt") _
'            ', Me.CurrentItem.Amount)
'            '   Me.ValidateRow(re)
'            Me.WorkbenchWindow.ViewContent.IsDirty = True
'        End Sub
'        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
'            Dim index As Integer = Me.tgItem.CurrentRowIndex
'            Dim row As TreeRow = Me.m_treeManager.SelectedRow
'            If row Is Nothing Then
'                Return
'            End If
'            Dim doc As CurrencyRate = Me.CurrentItem
'            If doc Is Nothing Then
'                Return
'            End If
'            Me.WorkbenchWindow.ViewContent.IsDirty = True
'            Me.m_entity.RateCollection.Remove(doc)
'            RefreshDocs()
'            Me.tgItem.CurrentRowIndex = index
'        End Sub
'        Private Sub ReIndex()
'            Dim i As Integer = 0
'            For Each row As DataRow In Me.m_treeManager.Treetable.Rows
'                row("Linenumber") = i + 1
'                i += 1
'            Next
'        End Sub
'#End Region

'#Region "IValidatable"
'        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
'            Get
'                Return Me.Validator
'            End Get
'        End Property
'#End Region

'#Region "Overrides"
'        Public Overrides Sub NotifyBeforeSave()

'        End Sub
'        'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
'        '    If Not successful Then
'        '        Return
'        '    End If
'        '    Me.Entity = New PR(Me.Entity.Id)
'        '    Dim listPanel As ISimpleListPanel = CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel)
'        '    listPanel.SelectedEntity = Me.Entity
'        'End Sub
'        Public Overrides ReadOnly Property TabPageIcon() As String
'            Get
'                Return (New PR).DetailPanelIcon
'            End Get
'        End Property
'#End Region

'#Region "Event of Button controls"

'#End Region

'#Region "IClipboardHandler Overrides"
'        Public Overrides ReadOnly Property EnablePaste() As Boolean
'            Get
'                Dim data As IDataObject = Clipboard.GetDataObject
'                If data.GetDataPresent((New Supplier).FullClassName) Then
'                    If Not Me.ActiveControl Is Nothing Then
'                        Select Case Me.ActiveControl.Name.ToLower
'                            Case "txtsuppliercode", "txtsuppliername"
'                                Return True
'                        End Select
'                    End If
'                End If
'                Return False
'            End Get
'        End Property
'        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
'            Dim data As IDataObject = Clipboard.GetDataObject
'            'If data.GetDataPresent((New Supplier).FullClassName) Then
'            '    Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
'            '    Dim entity As New Supplier(id)
'            '    If Not Me.ActiveControl Is Nothing Then
'            '        Select Case Me.ActiveControl.Name.ToLower
'            '            Case "txtsuppliercode", "txtsuppliername"
'            '                Me.SetSupplier(entity)
'            '        End Select
'            '    End If
'            'End If
'        End Sub
'#End Region

'#Region "Grid Resizing"
'        Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
'            If Me.m_entity Is Nothing Then
'                Return
'            End If
'            RefreshBlankGrid()
'        End Sub
'        Private Sub RefreshBlankGrid()
'            If Me.tgItem.Height = 0 Then
'                Return
'            End If
'            Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
'            Dim index As Integer = tgItem.CurrentRowIndex
'            Dim maxVisibleCount As Integer
'            Dim tgRowHeight As Integer = 17
'            maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
'            Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
'                'เพิ่มแถวจนเต็ม
'                Me.m_treeManager.Treetable.Childs.Add()
'            Loop
'            'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
'            '    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
'            '        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
'            '        Me.m_treeManager.Treetable.Childs.Add()
'            '    End If
'            'End If
'            Me.m_treeManager.Treetable.AcceptChanges()
'            tgItem.CurrentRowIndex = Math.Max(0, index)
'            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
'        End Sub
'#End Region

'    End Class
'End Namespace