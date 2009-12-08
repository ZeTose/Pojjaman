Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptPOQtyRecommendedFilterSubPanel
        Inherits AbstractFilterSubPanel
        Implements IReportFilterSubPanel

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
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents txtCCstart As System.Windows.Forms.TextBox
        Friend WithEvents btnCCstart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnPRstart As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptPOQtyRecommendedFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnPRstart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblPRStart = New System.Windows.Forms.Label
            Me.btnCCstart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCCstart = New System.Windows.Forms.TextBox
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.txtPRStart = New System.Windows.Forms.TextBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(432, 152)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "เช็ครับ"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(432, 32)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtTemp, "")
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(104, 21)
            Me.txtTemp.TabIndex = 3
            Me.txtTemp.Text = ""
            Me.txtTemp.Visible = False
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnPRstart)
            Me.grbDetail.Controls.Add(Me.lblPRStart)
            Me.grbDetail.Controls.Add(Me.btnCCstart)
            Me.grbDetail.Controls.Add(Me.txtCCstart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtPRStart)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(400, 96)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnPRstart
            '
            Me.btnPRstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPRstart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPRstart.Image = CType(resources.GetObject("btnPRstart.Image"), System.Drawing.Image)
            Me.btnPRstart.Location = New System.Drawing.Point(246, 51)
            Me.btnPRstart.Name = "btnPRstart"
            Me.btnPRstart.Size = New System.Drawing.Size(24, 22)
            Me.btnPRstart.TabIndex = 13
            Me.btnPRstart.TabStop = False
            Me.btnPRstart.ThemedImage = CType(resources.GetObject("btnPRstart.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblPRStart
            '
            Me.lblPRStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPRStart.ForeColor = System.Drawing.Color.Black
            Me.lblPRStart.Location = New System.Drawing.Point(14, 54)
            Me.lblPRStart.Name = "lblPRStart"
            Me.lblPRStart.Size = New System.Drawing.Size(136, 16)
            Me.lblPRStart.TabIndex = 12
            Me.lblPRStart.Text = "ตั้งแต่ Cost Center"
            Me.lblPRStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCCstart
            '
            Me.btnCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCstart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCstart.Image = CType(resources.GetObject("btnCCstart.Image"), System.Drawing.Image)
            Me.btnCCstart.Location = New System.Drawing.Point(246, 23)
            Me.btnCCstart.Name = "btnCCstart"
            Me.btnCCstart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCstart.TabIndex = 11
            Me.btnCCstart.TabStop = False
            Me.btnCCstart.ThemedImage = CType(resources.GetObject("btnCCstart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCCstart
            '
            Me.Validator.SetDataType(Me.txtCCstart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCstart, "")
            Me.txtCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCstart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCstart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCstart, System.Drawing.Color.Empty)
            Me.txtCCstart.Location = New System.Drawing.Point(150, 24)
            Me.Validator.SetMaxValue(Me.txtCCstart, "")
            Me.Validator.SetMinValue(Me.txtCCstart, "")
            Me.txtCCstart.Name = "txtCCstart"
            Me.Validator.SetRegularExpression(Me.txtCCstart, "")
            Me.Validator.SetRequired(Me.txtCCstart, False)
            Me.txtCCstart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCstart.TabIndex = 10
            Me.txtCCstart.Text = ""
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(14, 24)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(136, 18)
            Me.lblCCStart.TabIndex = 9
            Me.lblCCStart.Text = "ตั้งแต่ Cost Center"
            Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPRStart
            '
            Me.Validator.SetDataType(Me.txtPRStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPRStart, "")
            Me.txtPRStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPRStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPRStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPRStart, System.Drawing.Color.Empty)
            Me.txtPRStart.Location = New System.Drawing.Point(150, 52)
            Me.Validator.SetMaxValue(Me.txtPRStart, "")
            Me.Validator.SetMinValue(Me.txtPRStart, "")
            Me.txtPRStart.Name = "txtPRStart"
            Me.Validator.SetRegularExpression(Me.txtPRStart, "")
            Me.Validator.SetRequired(Me.txtPRStart, False)
            Me.txtPRStart.Size = New System.Drawing.Size(96, 21)
            Me.txtPRStart.TabIndex = 10
            Me.txtPRStart.Text = ""
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(343, 120)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(72, 23)
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(263, 120)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(72, 23)
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
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
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'RptPOQtyRecommendedFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptPOQtyRecommendedFilterSubPanel"
            Me.Size = New System.Drawing.Size(448, 168)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOQtyRecommendedFilterSubPanel.lblCCStart}")
            Me.Validator.SetDisplayName(txtCCstart, lblCCStart.Text)

            Me.lblPRStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOQtyRecommendedFilterSubPanel.lblPRStart}")
            Me.Validator.SetDisplayName(txtPRStart, lblPRStart.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOQtyRecommendedFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOQtyRecommendedFilterSubPanel.grbDetail}")
        End Sub
#End Region

#Region "Member"
        Private m_ccstart As CostCenter
        Private m_prstart As PR
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Public Property CCStart() As CostCenter
            Get
                Return m_ccstart
            End Get
            Set(ByVal Value As CostCenter)
                m_ccstart = Value
            End Set
        End Property
        Public Property PRStart() As PR
            Get
                Return m_prstart
            End Get
            Set(ByVal Value As PR)
                m_prstart = Value
            End Set
        End Property
#End Region

#Region "Methods"

        Private Sub Initialize()
            ClearCriterias()
        End Sub

        Private Sub ClearCriterias()
            For Each grbCtrl As Control In grbMaster.Controls
                If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next

            Me.CCStart = New CostCenter
            Me.PRStart = New PR

        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(2) As Filter
            arr(0) = New Filter("cc_code", IIf(Me.txtCCstart.TextLength > 0, Me.txtCCstart.Text, DBNull.Value))
            arr(1) = New Filter("pr_code", IIf(Me.txtPRStart.TextLength > 0, Me.txtPRStart.Text, DBNull.Value))
            arr(2) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "IReportFilterSubPanel"
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'Month
            dpi = New DocPrintingItem
            dpi.Mapping = "Month"
            dpi.Value = "" 'Me.cmbMonth.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Year
            dpi = New DocPrintingItem
            dpi.Mapping = "Year"
            dpi.Value = "" 'Me.cmbYear.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenter
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterStart"
            dpi.Value = txtCCstart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'PRCode
            dpi = New DocPrintingItem
            dpi.Mapping = "PRCode"
            dpi.Value = txtPRStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnCCStart.Click, AddressOf Me.btnCCFind_Click
            AddHandler btnPRstart.Click, AddressOf Me.btnPRFind_Click

            AddHandler txtCCstart.Validated, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Dim tempTxt As New TextBox
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtccstart"
                    CostCenter.GetCostCenter(txtCCstart, tempTxt, m_ccstart, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                    'Case "txtsupplicodestart"
                    '    Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)

                    'Case "txtsupplicodeend"
                    '    Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)

                    'Case "dtpdocdatestart"
                    '        If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
                    '            If Not m_dateSetting Then
                    '                Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                    '                Me.DocDateStart = dtpDocDateStart.Value
                    '            End If
                    '        End If
                    '    Case "txtdocdatestart"
                    '        m_dateSetting = True
                    '        If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                    '            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                    '            If Not Me.DocDateStart.Equals(theDate) Then
                    '                dtpDocDateStart.Value = theDate
                    '                Me.DocDateStart = dtpDocDateStart.Value
                    '            End If
                    '        Else
                    '            Me.dtpDocDateStart.Value = Date.Now
                    '            Me.DocDateStart = Date.MinValue
                    '        End If
                    '        m_dateSetting = False

                    '    Case "dtpdocdateend"
                    '        If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
                    '            If Not m_dateSetting Then
                    '                Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                    '                Me.DocDateEnd = dtpDocDateEnd.Value
                    '            End If
                    '        End If
                    '    Case "txtdocdateend"
                    '        m_dateSetting = True
                    '        If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                    '            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                    '            If Not Me.DocDateEnd.Equals(theDate) Then
                    '                dtpDocDateEnd.Value = theDate
                    '                Me.DocDateEnd = dtpDocDateEnd.Value
                    '            End If
                    '        Else
                    '            Me.dtpDocDateEnd.Value = Date.Now
                    '            Me.DocDateEnd = Date.MinValue
                    '        End If
                    '        m_dateSetting = False

                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtccstart"
                                Return True
                        End Select
                    End If
                End If
                If data.GetDataPresent((New PR).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtprstart"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtccstart"
                            Me.SetCCStartDialog(entity)
                    End Select
                End If
            End If
            If data.GetDataPresent((New PR).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New PR).FullClassName))
                Dim entity As New PR(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtprstart"
                            Me.SetPRStartDialog(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnccstart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCStartDialog)
            End Select
        End Sub
        Private Sub btnPRFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnprstart"
                    myEntityPanelService.OpenListDialog(New PR, AddressOf SetPRStartDialog)
            End Select
        End Sub

        Private Sub SetCCStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCstart.Text = e.Code
            CostCenter.GetCostCenter(txtCCstart, txtTemp, Me.CCStart, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub SetPRStartDialog(ByVal e As ISimpleEntity)
            Me.txtPRStart.Text = e.Code
            PR.GetPR(txtPRStart, txtTemp, Me.PRStart)
        End Sub
#End Region

        Friend WithEvents lblPRStart As System.Windows.Forms.Label
        Friend WithEvents txtPRStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
    End Class
End Namespace
