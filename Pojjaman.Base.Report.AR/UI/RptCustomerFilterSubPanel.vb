Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptCustomerFilterSubPanel
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
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents txtCsgCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCsgStart As System.Windows.Forms.Label
        Friend WithEvents txtCustomerGroupName As System.Windows.Forms.TextBox
        Friend WithEvents btnCsgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptCustomerFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.txtCsgCodeStart = New System.Windows.Forms.TextBox
            Me.lblCsgStart = New System.Windows.Forms.Label
            Me.txtCustomerGroupName = New System.Windows.Forms.TextBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.btnCsgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
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
            Me.grbMaster.Size = New System.Drawing.Size(464, 144)
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
            Me.txtTemp.Location = New System.Drawing.Point(488, 32)
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
            Me.grbDetail.Controls.Add(Me.btnCsgCodeStart)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.txtCsgCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCsgStart)
            Me.grbDetail.Controls.Add(Me.txtCustomerGroupName)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(432, 88)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(64, 48)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 23
            Me.chkIncludeChildren.Text = "รวมกลุ่มผู้ขายลูก"
            '
            'txtCsgCodeStart
            '
            Me.Validator.SetDataType(Me.txtCsgCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCsgCodeStart, "")
            Me.txtCsgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCsgCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCsgCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCsgCodeStart, System.Drawing.Color.Empty)
            Me.txtCsgCodeStart.Location = New System.Drawing.Point(128, 24)
            Me.txtCsgCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCsgCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCsgCodeStart, "")
            Me.txtCsgCodeStart.Name = "txtCsgCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCsgCodeStart, "")
            Me.Validator.SetRequired(Me.txtCsgCodeStart, False)
            Me.txtCsgCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCsgCodeStart.TabIndex = 21
            Me.txtCsgCodeStart.Text = ""
            '
            'lblCsgStart
            '
            Me.lblCsgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCsgStart.ForeColor = System.Drawing.Color.Black
            Me.lblCsgStart.Location = New System.Drawing.Point(16, 24)
            Me.lblCsgStart.Name = "lblCsgStart"
            Me.lblCsgStart.Size = New System.Drawing.Size(104, 18)
            Me.lblCsgStart.TabIndex = 19
            Me.lblCsgStart.Text = "กลุ่มผู้ขาย"
            Me.lblCsgStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustomerGroupName
            '
            Me.Validator.SetDataType(Me.txtCustomerGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerGroupName, "")
            Me.txtCustomerGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerGroupName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCustomerGroupName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerGroupName, System.Drawing.Color.Empty)
            Me.txtCustomerGroupName.Location = New System.Drawing.Point(248, 24)
            Me.txtCustomerGroupName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCustomerGroupName, "")
            Me.Validator.SetMinValue(Me.txtCustomerGroupName, "")
            Me.txtCustomerGroupName.Name = "txtCustomerGroupName"
            Me.txtCustomerGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerGroupName, "")
            Me.Validator.SetRequired(Me.txtCustomerGroupName, False)
            Me.txtCustomerGroupName.Size = New System.Drawing.Size(160, 21)
            Me.txtCustomerGroupName.TabIndex = 20
            Me.txtCustomerGroupName.Text = ""
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(372, 112)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(288, 112)
            Me.btnReset.Name = "btnReset"
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
            'btnCsgCodeStart
            '
            Me.btnCsgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCsgCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCsgCodeStart.Image = CType(resources.GetObject("btnCsgCodeStart.Image"), System.Drawing.Image)
            Me.btnCsgCodeStart.Location = New System.Drawing.Point(224, 24)
            Me.btnCsgCodeStart.Name = "btnCsgCodeStart"
            Me.btnCsgCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCsgCodeStart.TabIndex = 24
            Me.btnCsgCodeStart.TabStop = False
            Me.btnCsgCodeStart.ThemedImage = CType(resources.GetObject("btnCsgCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'RptCustomerFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptCustomerFilterSubPanel"
            Me.Size = New System.Drawing.Size(480, 160)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            Me.lblCsgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCustomerFilterSubPanel.lblCsgStart}")
            Me.Validator.SetDisplayName(txtCsgCodeStart, lblCsgStart.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCustomerFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCustomerFilterSubPanel.grbDetail}")

            'Checkbox
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCustomerFilterSubPanel.chkIncludeChildren}")
        End Sub
#End Region

#Region "Member"
        Private m_csg As CustomerGroup
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
        Public Property CustomerGroup() As CustomerGroup
            Get
                Return m_csg
            End Get
            Set(ByVal Value As CustomerGroup)
                m_csg = Value
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

            Me.CustomerGroup = New CustomerGroup
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(1) As Filter
            arr(0) = New Filter("customer_group", Me.ValidIdOrDBNull(m_csg))
            arr(1) = New Filter("IncludeChildCsg", Me.chkIncludeChildren.Checked)
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

            'CustomerGroupStart
            dpi = New DocPrintingItem
            dpi.Mapping = "CustomerGroupStart"
            dpi.Value = Me.txtCustomerGroupName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CheckBox ChildInclude
            If Me.chkIncludeChildren.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "childincluded"
                dpi.Value = "(รวมในสังกัด)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnCsgCodeStart.Click, AddressOf Me.btnCustomerGroupFind_Click
            AddHandler txtCsgCodeStart.Validated, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcsgcodestart"
                    CustomerGroup.GetCustomerGroup(txtCsgCodeStart, Me.txtCustomerGroupName, m_csg)
            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New CustomerGroup).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcsgcodestart", "txtcsgcodeend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New CustomerGroup).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CustomerGroup).FullClassName))
                Dim entity As New CustomerGroup(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcustomerGroupcodestart"
                            Me.SetCsgCodeStartDialog(entity)

                        Case "txtcustomerGroupcodeend"
                            Me.SetCsgCodeStartDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        ' CustomerGroup
        Private Sub btnCustomerGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncsgcodestart"
                    myEntityPanelService.OpenTreeDialog(New CustomerGroup, AddressOf SetCsgCodeStartDialog)
            End Select
        End Sub
        Private Sub SetCsgCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCsgCodeStart.Text = e.Code
            CustomerGroup.GetCustomerGroup(txtCsgCodeStart, txtCustomerGroupName, m_csg, True)
        End Sub
#End Region

    End Class
End Namespace

