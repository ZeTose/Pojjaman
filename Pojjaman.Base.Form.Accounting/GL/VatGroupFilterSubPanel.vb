Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class VatGroupFilterSubPanel
        Inherits AbstractFilterSubPanel

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
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblEndCode As System.Windows.Forms.Label
        Friend WithEvents txtEndCode As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblStartCode As System.Windows.Forms.Label
        Friend WithEvents txtStartCode As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.lblEndCode = New System.Windows.Forms.Label
            Me.txtEndCode = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblStartCode = New System.Windows.Forms.Label
            Me.txtStartCode = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblEndCode
            '
            Me.lblEndCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEndCode.ForeColor = System.Drawing.Color.Black
            Me.lblEndCode.Location = New System.Drawing.Point(208, 24)
            Me.lblEndCode.Name = "lblEndCode"
            Me.lblEndCode.Size = New System.Drawing.Size(32, 18)
            Me.lblEndCode.TabIndex = 4
            Me.lblEndCode.Text = "ถึง"
            Me.lblEndCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEndCode
            '
            Me.Validator.SetDataType(Me.txtEndCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEndCode, "")
            Me.txtEndCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEndCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEndCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEndCode, System.Drawing.Color.Empty)
            Me.txtEndCode.Location = New System.Drawing.Point(240, 24)
            Me.txtEndCode.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtEndCode, "")
            Me.Validator.SetMinValue(Me.txtEndCode, "")
            Me.txtEndCode.Name = "txtEndCode"
            Me.Validator.SetRegularExpression(Me.txtEndCode, "")
            Me.Validator.SetRequired(Me.txtEndCode, False)
            Me.txtEndCode.Size = New System.Drawing.Size(120, 21)
            Me.txtEndCode.TabIndex = 2
            Me.txtEndCode.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(16, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(72, 18)
            Me.lblName.TabIndex = 8
            Me.lblName.Text = "ชื่อกลุ่มภาษี"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(88, 48)
            Me.txtName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(272, 21)
            Me.txtName.TabIndex = 3
            Me.txtName.Text = ""
            '
            'lblStartCode
            '
            Me.lblStartCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStartCode.ForeColor = System.Drawing.Color.Black
            Me.lblStartCode.Location = New System.Drawing.Point(16, 25)
            Me.lblStartCode.Name = "lblStartCode"
            Me.lblStartCode.Size = New System.Drawing.Size(72, 18)
            Me.lblStartCode.TabIndex = 0
            Me.lblStartCode.Text = "รหัสกลุ่มภาษี"
            Me.lblStartCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtStartCode
            '
            Me.Validator.SetDataType(Me.txtStartCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtStartCode, "")
            Me.txtStartCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtStartCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtStartCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtStartCode, System.Drawing.Color.Empty)
            Me.txtStartCode.Location = New System.Drawing.Point(88, 24)
            Me.txtStartCode.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtStartCode, "")
            Me.Validator.SetMinValue(Me.txtStartCode, "")
            Me.txtStartCode.Name = "txtStartCode"
            Me.Validator.SetRegularExpression(Me.txtStartCode, "")
            Me.Validator.SetRequired(Me.txtStartCode, False)
            Me.txtStartCode.Size = New System.Drawing.Size(120, 21)
            Me.txtStartCode.TabIndex = 1
            Me.txtStartCode.Text = ""
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.txtEndCode)
            Me.grbDetail.Controls.Add(Me.txtName)
            Me.grbDetail.Controls.Add(Me.txtStartCode)
            Me.grbDetail.Controls.Add(Me.lblStartCode)
            Me.grbDetail.Controls.Add(Me.lblEndCode)
            Me.grbDetail.Controls.Add(Me.lblName)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(376, 112)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลลูกค้า"
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(286, 80)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 16
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(206, 80)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 15
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "Reset"
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
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'VatGroupFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "VatGroupFilterSubPanel"
            Me.Size = New System.Drawing.Size(392, 128)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Member"
        Dim m_vatGroup As New VatGroup
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()
            LoopControl(Me)

        End Sub
#End Region

#Region "Properties"
        Private Property VatGroup() As VatGroup
            Get
                Return m_vatGroup
            End Get
            Set(ByVal Value As VatGroup)
                m_vatGroup = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub Initialize()
            'Province.ListProvinceInComboBox(Me.cmbProvince)
        End Sub

        Private Sub ClearCriterias()
            For Each ctrl As Control In Me.grbDetail.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next
        End Sub

        Public Sub SetLabelText()
            Me.lblStartCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupFilterSubPanel.lblStartCode}")
            Me.lblEndCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupFilterSubPanel.lblEndCode}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupFilterSubPanel.grbDetail}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.VatGroupFilterSubPanel.lblName}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(2) As Filter
            arr(0) = New Filter("startcode", IIf(Me.txtStartCode.Text.Length = 0, DBNull.Value, Me.txtStartCode.Text))
            arr(1) = New Filter("endcode", IIf(Me.txtEndCode.Text.Length = 0, DBNull.Value, Me.txtEndCode.Text))
            arr(2) = New Filter("name", IIf(Me.txtName.Text.Length = 0, DBNull.Value, Me.txtName.Text))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        'Public Overrides ReadOnly Property EnablePaste() As Boolean
        '    Get
        '        Dim data As IDataObject = Clipboard.GetDataObject
        '        If data.GetDataPresent((New VatGroup).FullClassName) Then
        '            If Not Me.ActiveControl Is Nothing Then
        '                Select Case Me.ActiveControl.Name.ToLower
        '                    Case 
        '                        Return True
        '                End Select
        '            End If
        '        End If
        '    End Get
        'End Property
        'Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
        '    Dim data As IDataObject = Clipboard.GetDataObject
        '    If data.GetDataPresent((New CustomerGroup).FullClassName) Then
        '        Dim id As Integer = CInt(data.GetData((New CustomerGroup).FullClassName))
        '        Dim entity As New CustomerGroup(id)
        '        If Not Me.ActiveControl Is Nothing Then
        '            Select Case Me.ActiveControl.Name.ToLower
        '                Case "txtgroupcode", "txtgroupname"
        '                    Me.SetCustomerGroup(entity)
        '            End Select
        '        End If
        '    End If
        'End Sub
#End Region

    End Class
End Namespace

