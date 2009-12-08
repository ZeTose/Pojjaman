Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptAPPRbyProjectFilterSubPanel
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
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents txtProjectCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents btnPREndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPRCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblPREnd As System.Windows.Forms.Label
        Friend WithEvents btnPRStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPRCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblPRStart As System.Windows.Forms.Label
        Friend WithEvents btnProjectCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblProjectStart As System.Windows.Forms.Label
        Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptAPPRbyProjectFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnProjectCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtProjectCodeStart = New System.Windows.Forms.TextBox
            Me.lblProjectStart = New System.Windows.Forms.Label
            Me.txtProjectName = New System.Windows.Forms.TextBox
            Me.btnPREndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtPRCodeEnd = New System.Windows.Forms.TextBox
            Me.lblPREnd = New System.Windows.Forms.Label
            Me.btnPRStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtPRCodeStart = New System.Windows.Forms.TextBox
            Me.lblPRStart = New System.Windows.Forms.Label
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
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
            Me.grbDetail.Controls.Add(Me.btnProjectCodeStart)
            Me.grbDetail.Controls.Add(Me.txtProjectCodeStart)
            Me.grbDetail.Controls.Add(Me.lblProjectStart)
            Me.grbDetail.Controls.Add(Me.txtProjectName)
            Me.grbDetail.Controls.Add(Me.btnPREndFind)
            Me.grbDetail.Controls.Add(Me.txtPRCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblPREnd)
            Me.grbDetail.Controls.Add(Me.btnPRStartFind)
            Me.grbDetail.Controls.Add(Me.txtPRCodeStart)
            Me.grbDetail.Controls.Add(Me.lblPRStart)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(400, 96)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnProjectCodeStart
            '
            Me.btnProjectCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnProjectCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnProjectCodeStart.Image = CType(resources.GetObject("btnProjectCodeStart.Image"), System.Drawing.Image)
            Me.btnProjectCodeStart.Location = New System.Drawing.Point(200, 64)
            Me.btnProjectCodeStart.Name = "btnProjectCodeStart"
            Me.btnProjectCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnProjectCodeStart.TabIndex = 22
            Me.btnProjectCodeStart.TabStop = False
            Me.btnProjectCodeStart.ThemedImage = CType(resources.GetObject("btnProjectCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtProjectCodeStart
            '
            Me.Validator.SetDataType(Me.txtProjectCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectCodeStart, "")
            Me.txtProjectCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtProjectCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtProjectCodeStart, System.Drawing.Color.Empty)
            Me.txtProjectCodeStart.Location = New System.Drawing.Point(104, 64)
            Me.txtProjectCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtProjectCodeStart, "")
            Me.Validator.SetMinValue(Me.txtProjectCodeStart, "")
            Me.txtProjectCodeStart.Name = "txtProjectCodeStart"
            Me.Validator.SetRegularExpression(Me.txtProjectCodeStart, "")
            Me.Validator.SetRequired(Me.txtProjectCodeStart, False)
            Me.txtProjectCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtProjectCodeStart.TabIndex = 21
            Me.txtProjectCodeStart.Text = ""
            '
            'lblProjectStart
            '
            Me.lblProjectStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProjectStart.ForeColor = System.Drawing.Color.Black
            Me.lblProjectStart.Location = New System.Drawing.Point(32, 64)
            Me.lblProjectStart.Name = "lblProjectStart"
            Me.lblProjectStart.Size = New System.Drawing.Size(64, 18)
            Me.lblProjectStart.TabIndex = 19
            Me.lblProjectStart.Text = "Project"
            Me.lblProjectStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtProjectName
            '
            Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectName, "")
            Me.txtProjectName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtProjectName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.txtProjectName.Location = New System.Drawing.Point(224, 64)
            Me.txtProjectName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtProjectName, "")
            Me.Validator.SetMinValue(Me.txtProjectName, "")
            Me.txtProjectName.Name = "txtProjectName"
            Me.txtProjectName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProjectName, "")
            Me.Validator.SetRequired(Me.txtProjectName, False)
            Me.txtProjectName.Size = New System.Drawing.Size(160, 21)
            Me.txtProjectName.TabIndex = 20
            Me.txtProjectName.Text = ""
            '
            'btnPREndFind
            '
            Me.btnPREndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPREndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPREndFind.Image = CType(resources.GetObject("btnPREndFind.Image"), System.Drawing.Image)
            Me.btnPREndFind.Location = New System.Drawing.Point(360, 40)
            Me.btnPREndFind.Name = "btnPREndFind"
            Me.btnPREndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnPREndFind.TabIndex = 11
            Me.btnPREndFind.TabStop = False
            Me.btnPREndFind.ThemedImage = CType(resources.GetObject("btnPREndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPRCodeEnd
            '
            Me.Validator.SetDataType(Me.txtPRCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPRCodeEnd, "")
            Me.txtPRCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPRCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPRCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPRCodeEnd, System.Drawing.Color.Empty)
            Me.txtPRCodeEnd.Location = New System.Drawing.Point(264, 40)
            Me.Validator.SetMaxValue(Me.txtPRCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtPRCodeEnd, "")
            Me.txtPRCodeEnd.Name = "txtPRCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtPRCodeEnd, "")
            Me.Validator.SetRequired(Me.txtPRCodeEnd, False)
            Me.txtPRCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtPRCodeEnd.TabIndex = 10
            Me.txtPRCodeEnd.Text = ""
            '
            'lblPREnd
            '
            Me.lblPREnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPREnd.ForeColor = System.Drawing.Color.Black
            Me.lblPREnd.Location = New System.Drawing.Point(232, 40)
            Me.lblPREnd.Name = "lblPREnd"
            Me.lblPREnd.Size = New System.Drawing.Size(24, 18)
            Me.lblPREnd.TabIndex = 9
            Me.lblPREnd.Text = "ถึง"
            Me.lblPREnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnPRStartFind
            '
            Me.btnPRStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnPRStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPRStartFind.Image = CType(resources.GetObject("btnPRStartFind.Image"), System.Drawing.Image)
            Me.btnPRStartFind.Location = New System.Drawing.Point(200, 40)
            Me.btnPRStartFind.Name = "btnPRStartFind"
            Me.btnPRStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnPRStartFind.TabIndex = 8
            Me.btnPRStartFind.TabStop = False
            Me.btnPRStartFind.ThemedImage = CType(resources.GetObject("btnPRStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPRCodeStart
            '
            Me.Validator.SetDataType(Me.txtPRCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPRCodeStart, "")
            Me.txtPRCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPRCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPRCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPRCodeStart, System.Drawing.Color.Empty)
            Me.txtPRCodeStart.Location = New System.Drawing.Point(104, 40)
            Me.Validator.SetMaxValue(Me.txtPRCodeStart, "")
            Me.Validator.SetMinValue(Me.txtPRCodeStart, "")
            Me.txtPRCodeStart.Name = "txtPRCodeStart"
            Me.Validator.SetRegularExpression(Me.txtPRCodeStart, "")
            Me.Validator.SetRequired(Me.txtPRCodeStart, False)
            Me.txtPRCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtPRCodeStart.TabIndex = 7
            Me.txtPRCodeStart.Text = ""
            '
            'lblPRStart
            '
            Me.lblPRStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPRStart.ForeColor = System.Drawing.Color.Black
            Me.lblPRStart.Location = New System.Drawing.Point(8, 40)
            Me.lblPRStart.Name = "lblPRStart"
            Me.lblPRStart.Size = New System.Drawing.Size(88, 18)
            Me.lblPRStart.TabIndex = 6
            Me.lblPRStart.Text = "ตั้งแต่เลขที่:"
            Me.lblPRStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(264, 16)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 4
            Me.txtDocDateEnd.Text = ""
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(104, 16)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateStart.TabIndex = 1
            Me.txtDocDateStart.Text = ""
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(264, 16)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 16)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(232, 16)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(344, 120)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(264, 120)
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
            'RptAPPRbyProjectFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptAPPRbyProjectFilterSubPanel"
            Me.Size = New System.Drawing.Size(448, 168)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblPRStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPRbyProjectFilterSubPanel.lblPRStart}")
            Me.Validator.SetDisplayName(txtPRCodeStart, lblPRStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPRbyProjectFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblProjectStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPRbyProjectFilterSubPanel.lblProjectStart}")
            Me.Validator.SetDisplayName(txtProjectCodeStart, lblProjectStart.Text)

            ' Global {ถึง}
            Me.lblPREnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtPRCodeEnd, lblPREnd.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPRbyProjectFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAPPRbyProjectFilterSubPanel.grbDetail}")
        End Sub
#End Region

#Region "Member"
        Private m_prstart As PR
        Private m_prend As PR

        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date

        Private m_project As Project
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
        Public Property PRStart() As PR
            Get
                Return m_prstart
            End Get
            Set(ByVal Value As PR)
                m_prstart = Value
            End Set
        End Property
        Public Property PREnd() As PR
            Get
                Return m_prend
            End Get
            Set(ByVal Value As PR)
                m_prend = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property

        Public Property Project() As Project
            Get
                Return m_project
            End Get
            Set(ByVal Value As Project)
                m_project = Value
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

            Me.Project = New Project

            Me.PRStart = New PR
            Me.PREnd = New PR

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(4) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("PRCodeStart", IIf(txtPRCodeStart.TextLength > 0, txtPRCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("PRCodeEnd", IIf(txtPRCodeEnd.TextLength > 0, txtPRCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("project_id", Me.ValidIdOrDBNull(m_project))
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

#Region " IReportFilterSubPanel "
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'project start
            dpi = New DocPrintingItem
            dpi.Mapping = "projectstart"
            dpi.Value = Me.txtProjectName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnPRStartFind.Click, AddressOf Me.btnPRFind_Click
            AddHandler btnPREndFind.Click, AddressOf Me.btnPRFind_Click

            AddHandler btnProjectCodeStart.Click, AddressOf Me.btnProjectFind_Click
            AddHandler txtProjectCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtprojectcodestart"
                    Project.GetProject(txtProjectCodeStart, Me.txtProjectName, m_project)

                Case "dtpdocdatestart"
                    If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.DocDateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.DocDateStart = Date.MinValue
                    End If
                    m_dateSetting = False

                Case "dtpdocdateend"
                    If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.DocDateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.DocDateEnd = Date.MinValue
                    End If
                    m_dateSetting = False

                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtprcodestart", "txtprcodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Project
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtprojectcodestart"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtprcodestart"
                            Me.SetPRStartDialog(entity)

                        Case "txtprcodeend"
                            Me.SetPREndDialog(entity)

                    End Select
                End If
            End If
            ' Project
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtprojectcodestart"
                            Me.SetProjectCodeStartDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnPRFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnprstartfind"
                    myEntityPanelService.OpenListDialog(New PR, AddressOf SetPRStartDialog)

                Case "btnprendfind"
                    myEntityPanelService.OpenListDialog(New PR, AddressOf SetPREndDialog)

            End Select
        End Sub
        ' Project
        Private Sub btnProjectFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnprojectcodestart"
                    myEntityPanelService.OpenTreeDialog(New Project, AddressOf SetProjectCodeStartDialog)
            End Select
        End Sub
        Private Sub SetPRStartDialog(ByVal e As ISimpleEntity)
            Me.txtPRCodeStart.Text = e.Code
            PR.GetPR(txtPRCodeStart, txtTemp, Me.PRStart)
        End Sub
        Private Sub SetPREndDialog(ByVal e As ISimpleEntity)
            Me.txtPRCodeEnd.Text = e.Code
            PR.GetPR(txtPRCodeEnd, txtTemp, Me.PREnd)
        End Sub
        Private Sub SetProjectCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtProjectCodeStart.Text = e.Code
            Project.GetProject(txtProjectCodeStart, txtProjectName, m_project)
        End Sub
#End Region

    End Class
End Namespace

