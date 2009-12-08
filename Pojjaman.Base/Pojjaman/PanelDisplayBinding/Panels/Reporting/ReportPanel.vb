Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Reporting
Imports System.Drawing.Printing
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ReportPanel
        Inherits System.Windows.Forms.UserControl

#Region "Members"

#End Region

#Region "Constructors"
        Public Sub New()
            InitializeComponent()
            Me.ComboBox1.Items.Add("Bar")
            Me.ComboBox1.Items.Add("Pie")
            Me.ComboBox1.Items.Add("3DPie")
            Me.ComboBox1.SelectedIndex = 0
            ShowChart(ComboBox1.SelectedIndex)

        End Sub
#End Region

#Region "Initial"
        Friend WithEvents picReport As System.Windows.Forms.PictureBox
        Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
        Friend WithEvents PieChart1 As System.Drawing.PieChart.PieChartControl
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Private Sub InitializeComponent()
            Me.picReport = New System.Windows.Forms.PictureBox
            Me.ComboBox1 = New System.Windows.Forms.ComboBox
            Me.PieChart1 = New System.Drawing.PieChart.PieChartControl
            Me.Button1 = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'picReport
            '
            Me.picReport.Location = New System.Drawing.Point(16, 16)
            Me.picReport.Name = "picReport"
            Me.picReport.Size = New System.Drawing.Size(656, 408)
            Me.picReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.picReport.TabIndex = 0
            Me.picReport.TabStop = False
            '
            'ComboBox1
            '
            Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ComboBox1.Location = New System.Drawing.Point(8, 432)
            Me.ComboBox1.Name = "ComboBox1"
            Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
            Me.ComboBox1.TabIndex = 1
            '
            'PieChart1
            '
            Me.PieChart1.Location = New System.Drawing.Point(16, 16)
            Me.PieChart1.Name = "PieChart1"
            Me.PieChart1.Size = New System.Drawing.Size(656, 408)
            Me.PieChart1.TabIndex = 0
            Me.PieChart1.ToolTips = Nothing
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(144, 432)
            Me.Button1.Name = "Button1"
            Me.Button1.TabIndex = 2
            Me.Button1.Text = "Print"
            '
            'ReportPanel
            '
            Me.BackColor = System.Drawing.Color.White
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.ComboBox1)
            Me.Controls.Add(Me.picReport)
            Me.Controls.Add(Me.PieChart1)
            Me.Name = "ReportPanel"
            Me.Size = New System.Drawing.Size(681, 483)
            Me.ResumeLayout(False)

        End Sub
#End Region


        Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
            ShowChart(ComboBox1.SelectedIndex)
        End Sub

        Public Sub ShowChart(ByVal chartType As Integer)
            Dim bgColor As Color
            bgColor = Color.White 'Color.FromArgb(255, 253, 244)
            Select Case chartType
                Case 0
                    Dim bar As New BarGraph(bgColor)

                    bar.VerticalLabel = "ß"
                    bar.VerticalTickCount = 5
                    bar.ShowLegend = True
                    bar.ShowData = False
                    bar.Height = 400
                    bar.Width = 700

                    Dim Months As String() = New String() {"January", "February", "March", "April", "May", "June", "July"}
                    Dim Values As String() = New String() {"15", "33", "11", "24", "34", "39.5", "35"}
                    bar.CollectDataPoints(Months, Values)
                    Me.picReport.Image = bar.Draw
                    Me.picReport.Visible = True
                    Me.PieChart1.Visible = False
                Case 1
                    Dim pc As New PieChart(bgColor)
                    Dim Months As String() = New String() {"January", "February", "March", "April", "May", "June", "July"}
                    Dim Values As String() = New String() {"15", "33", "11", "24", "34", "39.5", "35"}
                    pc.CollectDataPoints(Months, Values)
                    Me.picReport.Image = pc.Draw
                    Me.picReport.Visible = True
                    Me.PieChart1.Visible = False
                Case 2
                    Me.PieChart1.Visible = True
                    Me.picReport.Visible = False
                    SetValues()
                    SetPieDisplacements()
                    SetColors()
                    SetTexts()
                    SetToolTips()
                    PieChart1.LeftMargin = 10
                    PieChart1.RightMargin = 10
                    PieChart1.TopMargin = 10
                    PieChart1.BottomMargin = 10
                    PieChart1.FitChart = False
                    PieChart1.SliceRelativeHeight = 0.25
                    PieChart1.InitialAngle = -30
                    PieChart1.EdgeLineWidth = 1
                    PieChart1.EdgeColorType = System.Drawing.PieChart.EdgeColorType.DarkerThanSurface
                    'PieChart1.BackColor = SystemColors.Window
            End Select
        End Sub
        Private Sub SetValues()
            Me.PieChart1.Values = New Decimal() {15, 33, 11, 24, 34, CDec(39.5), 35}
        End Sub
        Private Sub SetPieDisplacements()
            Me.PieChart1.SliceRelativeDisplacements = New Single() {0.05, 0.05, 0.05, 0.05, 0.05, 0.05, 0.05}
        End Sub
        Private Sub SetColors()
            Dim colors As New ArrayList
            colors.Add(Color.FromArgb(122, System.Drawing.Color.DeepSkyBlue))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.Firebrick))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.Yellow))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.Blue))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.LimeGreen))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.Red))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.Yellow))
            Me.PieChart1.Colors = CType(colors.ToArray(GetType(Color)), Color())
        End Sub
        Private Sub SetTexts()
            Me.PieChart1.Texts = New String() {"January", "February", "March", "April", "May", "June", "July"}
        End Sub
        Private Sub SetToolTips()

        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim pd As New PrintDocument
            AddHandler pd.PrintPage, AddressOf PrintGraphicsItemsHandler
            pd.Print()
        End Sub

        Private Sub PrintGraphicsItemsHandler(ByVal sender As Object, ByVal e As PrintPageEventArgs)
            Dim g As Graphics = e.Graphics
            Me.PieChart1.PieChart.Draw(g)
        End Sub
    End Class
End Namespace

