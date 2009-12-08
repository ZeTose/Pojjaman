Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports Longkong.FormTable
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ReportPreviewPanel
        Inherits AbstractEntityDetailPanelView

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
        Friend WithEvents numPages As System.Windows.Forms.NumericUpDown
        Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents pnlPicHolder As System.Windows.Forms.Panel
        Friend WithEvents picMap As System.Windows.Forms.PictureBox
        Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPercent As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReportPreviewPanel))
            Me.numPages = New System.Windows.Forms.NumericUpDown
            Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.pnlPicHolder = New System.Windows.Forms.Panel
            Me.picMap = New System.Windows.Forms.PictureBox
            Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtPercent = New System.Windows.Forms.TextBox
            CType(Me.numPages, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbMap.SuspendLayout()
            Me.pnlPicHolder.SuspendLayout()
            Me.SuspendLayout()
            '
            'numPages
            '
            Me.numPages.Location = New System.Drawing.Point(32, 24)
            Me.numPages.Name = "numPages"
            Me.numPages.Size = New System.Drawing.Size(40, 20)
            Me.numPages.TabIndex = 7
            '
            'grbMap
            '
            Me.grbMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMap.Controls.Add(Me.pnlPicHolder)
            Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMap.Location = New System.Drawing.Point(112, 16)
            Me.grbMap.Name = "grbMap"
            Me.grbMap.Size = New System.Drawing.Size(576, 464)
            Me.grbMap.TabIndex = 8
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
            Me.pnlPicHolder.Size = New System.Drawing.Size(570, 444)
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
            'ibtnZoomOut
            '
            Me.ibtnZoomOut.Image = CType(resources.GetObject("ibtnZoomOut.Image"), System.Drawing.Image)
            Me.ibtnZoomOut.Location = New System.Drawing.Point(8, 64)
            Me.ibtnZoomOut.Name = "ibtnZoomOut"
            Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
            Me.ibtnZoomOut.TabIndex = 10
            Me.ibtnZoomOut.TabStop = False
            Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnZoomIn
            '
            Me.ibtnZoomIn.Image = CType(resources.GetObject("ibtnZoomIn.Image"), System.Drawing.Image)
            Me.ibtnZoomIn.Location = New System.Drawing.Point(32, 64)
            Me.ibtnZoomIn.Name = "ibtnZoomIn"
            Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
            Me.ibtnZoomIn.TabIndex = 10
            Me.ibtnZoomIn.TabStop = False
            Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPercent
            '
            Me.txtPercent.Location = New System.Drawing.Point(56, 66)
            Me.txtPercent.Name = "txtPercent"
            Me.txtPercent.ReadOnly = True
            Me.txtPercent.Size = New System.Drawing.Size(48, 20)
            Me.txtPercent.TabIndex = 11
            Me.txtPercent.Text = ""
            '
            'ReportPreviewPanel
            '
            Me.Controls.Add(Me.txtPercent)
            Me.Controls.Add(Me.ibtnZoomOut)
            Me.Controls.Add(Me.grbMap)
            Me.Controls.Add(Me.numPages)
            Me.Controls.Add(Me.ibtnZoomIn)
            Me.Name = "ReportPreviewPanel"
            Me.Size = New System.Drawing.Size(712, 496)
            CType(Me.numPages, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbMap.ResumeLayout(False)
            Me.pnlPicHolder.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As Report
        Private m_isInitialized As Boolean = False
        Private m_ppis As ArrayList
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            EventWiring()
        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()

        End Sub
        Public Overrides Sub ClearDetail()
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            Dim pd As PrintDocument = Me.PrintDocument
            If Not pd Is Nothing Then
                pd.PrintController = New PJMPreviewControl(AddressOf SetPreviewPageInfos)
				If m_entity.ClassName = "RptJVAutomatic" Then
					pd.DefaultPageSettings.Landscape = True
				End If
				pd.Print()
			End If
            numPages_ValueChanged(Nothing, Nothing)

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
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

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not m_entity Is Nothing Then
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, Report)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()
            'PopulateRequestor()
            'PopulateCostCenter()
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

        '#Region "IPrintable"
        '        Public Overrides ReadOnly Property PrintDocument() As PrintDocument
        '            Get
        '                Dim df As New DocumentForm("C:\Documents and Settings\Administrator\Desktop\Report.dfm", Me.m_entity)
        '                Return df.PrintDocument
        '            End Get
        '        End Property
        '#End Region


    End Class
End Namespace