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
    Public Class FFormatPreview
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
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents cmbType As System.Windows.Forms.ComboBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents ibtnRefresh As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPercent As System.Windows.Forms.TextBox
        Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents pnlPicHolder As System.Windows.Forms.Panel
        Friend WithEvents picMap As System.Windows.Forms.PictureBox
        Friend WithEvents numPages As System.Windows.Forms.NumericUpDown
        Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents cmbUnit As System.Windows.Forms.ComboBox
        Friend WithEvents lblUnit As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FFormatPreview))
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.txtPercent = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblName = New System.Windows.Forms.Label
            Me.cmbType = New System.Windows.Forms.ComboBox
            Me.lblType = New System.Windows.Forms.Label
            Me.ibtnRefresh = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.pnlPicHolder = New System.Windows.Forms.Panel
            Me.picMap = New System.Windows.Forms.PictureBox
            Me.numPages = New System.Windows.Forms.NumericUpDown
            Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.cmbUnit = New System.Windows.Forms.ComboBox
            Me.lblUnit = New System.Windows.Forms.Label
            Me.grbMap.SuspendLayout()
            Me.pnlPicHolder.SuspendLayout()
            CType(Me.numPages, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Enabled = False
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(96, 15)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Enabled = False
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(96, 39)
            Me.txtName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(288, 21)
            Me.txtName.TabIndex = 3
            Me.txtName.TabStop = False
            Me.txtName.Text = ""
            '
            'txtPercent
            '
            Me.Validator.SetDataType(Me.txtPercent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPercent, "")
            Me.Validator.SetGotFocusBackColor(Me.txtPercent, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPercent, System.Drawing.Color.Empty)
            Me.txtPercent.Location = New System.Drawing.Point(640, 40)
            Me.Validator.SetMaxValue(Me.txtPercent, "")
            Me.Validator.SetMinValue(Me.txtPercent, "")
            Me.txtPercent.Name = "txtPercent"
            Me.txtPercent.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtPercent, "")
            Me.Validator.SetRequired(Me.txtPercent, False)
            Me.txtPercent.Size = New System.Drawing.Size(48, 20)
            Me.txtPercent.TabIndex = 12
            Me.txtPercent.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 7
            Me.lblCode.Text = "เลขที่:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(16, 40)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(80, 18)
            Me.lblName.TabIndex = 8
            Me.lblName.Text = "ชื่อรายงาน:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbType
            '
            Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbType.Enabled = False
            Me.cmbType.Location = New System.Drawing.Point(264, 16)
            Me.cmbType.Name = "cmbType"
            Me.cmbType.Size = New System.Drawing.Size(121, 21)
            Me.cmbType.TabIndex = 2
            '
            'lblType
            '
            Me.lblType.Enabled = False
            Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblType.ForeColor = System.Drawing.Color.Black
            Me.lblType.Location = New System.Drawing.Point(208, 16)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(56, 18)
            Me.lblType.TabIndex = 1
            Me.lblType.Text = "ประเภท:"
            Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnRefresh
            '
            Me.ibtnRefresh.Image = CType(resources.GetObject("ibtnRefresh.Image"), System.Drawing.Image)
            Me.ibtnRefresh.Location = New System.Drawing.Point(392, 16)
            Me.ibtnRefresh.Name = "ibtnRefresh"
            Me.ibtnRefresh.Size = New System.Drawing.Size(32, 32)
            Me.ibtnRefresh.TabIndex = 4
            Me.ibtnRefresh.ThemedImage = CType(resources.GetObject("ibtnRefresh.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnZoomOut
            '
            Me.ibtnZoomOut.Image = CType(resources.GetObject("ibtnZoomOut.Image"), System.Drawing.Image)
            Me.ibtnZoomOut.Location = New System.Drawing.Point(592, 40)
            Me.ibtnZoomOut.Name = "ibtnZoomOut"
            Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
            Me.ibtnZoomOut.TabIndex = 10
            Me.ibtnZoomOut.TabStop = False
            Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbMap
            '
            Me.grbMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMap.Controls.Add(Me.pnlPicHolder)
            Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMap.Location = New System.Drawing.Point(16, 64)
            Me.grbMap.Name = "grbMap"
            Me.grbMap.Size = New System.Drawing.Size(720, 384)
            Me.grbMap.TabIndex = 6
            Me.grbMap.TabStop = False
            Me.grbMap.Text = "Preview"
            '
            'pnlPicHolder
            '
            Me.pnlPicHolder.AutoScroll = True
            Me.pnlPicHolder.Controls.Add(Me.picMap)
            Me.pnlPicHolder.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlPicHolder.Location = New System.Drawing.Point(3, 17)
            Me.pnlPicHolder.Name = "pnlPicHolder"
            Me.pnlPicHolder.Size = New System.Drawing.Size(714, 364)
            Me.pnlPicHolder.TabIndex = 0
            '
            'picMap
            '
            Me.picMap.BackColor = System.Drawing.SystemColors.Window
            Me.picMap.Location = New System.Drawing.Point(0, 0)
            Me.picMap.Name = "picMap"
            Me.picMap.Size = New System.Drawing.Size(458, 444)
            Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.picMap.TabIndex = 6
            Me.picMap.TabStop = False
            '
            'numPages
            '
            Me.numPages.Location = New System.Drawing.Point(696, 40)
            Me.numPages.Name = "numPages"
            Me.numPages.Size = New System.Drawing.Size(40, 20)
            Me.numPages.TabIndex = 13
            '
            'ibtnZoomIn
            '
            Me.ibtnZoomIn.Image = CType(resources.GetObject("ibtnZoomIn.Image"), System.Drawing.Image)
            Me.ibtnZoomIn.Location = New System.Drawing.Point(616, 40)
            Me.ibtnZoomIn.Name = "ibtnZoomIn"
            Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
            Me.ibtnZoomIn.TabIndex = 11
            Me.ibtnZoomIn.TabStop = False
            Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
            '
            'cmbUnit
            '
            Me.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbUnit.Location = New System.Drawing.Point(480, 40)
            Me.cmbUnit.Name = "cmbUnit"
            Me.cmbUnit.Size = New System.Drawing.Size(88, 21)
            Me.cmbUnit.TabIndex = 5
            '
            'lblUnit
            '
            Me.lblUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit.ForeColor = System.Drawing.Color.Black
            Me.lblUnit.Location = New System.Drawing.Point(440, 40)
            Me.lblUnit.Name = "lblUnit"
            Me.lblUnit.Size = New System.Drawing.Size(40, 18)
            Me.lblUnit.TabIndex = 9
            Me.lblUnit.Text = "หน่วย:"
            Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'FFormatPreview
            '
            Me.Controls.Add(Me.txtPercent)
            Me.Controls.Add(Me.ibtnZoomOut)
            Me.Controls.Add(Me.grbMap)
            Me.Controls.Add(Me.numPages)
            Me.Controls.Add(Me.ibtnZoomIn)
            Me.Controls.Add(Me.ibtnRefresh)
            Me.Controls.Add(Me.cmbType)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.lblType)
            Me.Controls.Add(Me.cmbUnit)
            Me.Controls.Add(Me.lblUnit)
            Me.Name = "FFormatPreview"
            Me.Size = New System.Drawing.Size(752, 456)
            Me.grbMap.ResumeLayout(False)
            Me.pnlPicHolder.ResumeLayout(False)
            CType(Me.numPages, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As FFormat
        Private m_isInitialized As Boolean = False

        Private m_enableState As Hashtable

        Private m_ppis As ArrayList
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            SaveEnableState()
            EventWiring()
        End Sub
        Private Sub SaveEnableState()
            m_enableState = New Hashtable
            For Each ctrl As Control In Me.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Status.Value = 0 _
            OrElse Me.m_entity.Status.Value >= 3 _
            Then
                Me.Enabled = False
            Else
                Me.Enabled = True
            End If
        End Sub
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In Me.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            If Me.cmbUnit.Items.Count > 0 Then
                Me.cmbUnit.SelectedIndex = 0
            End If
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatPreview.lblCode}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatPreview.lblName}")
            Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatPreview.lblType}")
        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler cmbUnit.SelectedIndexChanged, AddressOf ChangeProperty
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            txtCode.Text = m_entity.Code
            txtName.Text = m_entity.Name

            CodeDescription.ComboSelect(Me.cmbType, Me.m_entity.ReportType)
            CodeDescription.ComboSelect(Me.cmbUnit, New CodeDescription(Me.m_entity.Divider))

            Dim pd As New PrintDocument
            If Not pd Is Nothing Then
                pd.PrintController = New PJMPreviewControl(AddressOf SetPreviewPageInfos)
                pd.Print()
            End If
            numPages_ValueChanged(Nothing, Nothing)

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "cmbunit"
                    If Not cmbUnit.SelectedItem Is Nothing Then
                        Me.m_entity.Divider = CType(cmbUnit.SelectedItem, IdValuePair).Id
                    Else
                        Me.m_entity.Divider = 1
                    End If
            End Select
            CheckFormEnable()
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
        Public Sub SetStatus()
            'If m_entity.Canceled Then
            '    Me.StatusBarService.SetMessage("ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
            '    " " & m_entity.CancelDate.ToShortTimeString & _
            '    "  โดย:" & m_entity.CancelPerson.Name)
            'ElseIf m_entity.Edited Then
            '    Me.StatusBarService.SetMessage("แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
            '    " " & m_entity.LastEditDate.ToShortTimeString & _
            '    "  โดย:" & m_entity.LastEditor.Name)
            'ElseIf m_entity.Originated Then
            '    Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
            '    " " & m_entity.OriginDate.ToShortTimeString & _
            '    "  โดย:" & m_entity.Originator.Name)
            'Else
            '    Me.StatusBarService.SetMessage("")
            'End If
        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not m_entity Is Nothing Then
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, FFormat)
                'Hack:
                If Not m_entity Is Nothing Then
                    Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                End If
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()
            PopulateType()
        End Sub
        Private Sub PopulateType()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "financialstatement_type")
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbUnit, "currencydivider")
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub ibtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnRefresh.Click
            Dim pd As PrintDocument = Me.PrintDocument
            If Not pd Is Nothing Then
                pd.PrintController = New PJMPreviewControl(AddressOf SetPreviewPageInfos)
                pd.Print()
            End If
            numPages_ValueChanged(Nothing, Nothing)
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
        Public Overrides Sub NotifyBeforeSave()

        End Sub
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New PR).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Event of Button controls"

#End Region

#Region "After the main entity has been saved"
        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            If Not successful Then
                Return
            End If
            Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
#End Region


#Region "Event Handlers"
        Private m_originalSize As New Size(0, 0)
        Private Sub numPages_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPages.ValueChanged
            If m_ppis Is Nothing OrElse m_ppis.Count = 0 Then
                Return
            End If
            Dim ppi As PreviewPageInfo = CType(m_ppis(CInt(Me.numPages.Value - 1)), PreviewPageInfo)
            ZoomFactor = 1
            Me.txtPercent.Text = (ZoomFactor * 100).ToString & " %"
            m_originalSize = ppi.Image.Size
            Me.picMap.Image = ppi.Image
            Me.picMap.Size = ppi.Image.Size
            picMap.Size = New Size(CInt(m_originalSize.Width * ZoomFactor * ZoomConst), CInt(m_originalSize.Height * ZoomFactor * ZoomConst))
        End Sub
        Private ZoomFactor As Double = 1
        Private ZoomConst As Double = 0.16
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

    End Class
End Namespace