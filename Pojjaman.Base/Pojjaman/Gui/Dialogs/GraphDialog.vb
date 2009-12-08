Imports Longkong.Pojjaman.Gui.XmlForms
Imports System.Reflection
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class GraphDialog
        Inherits UserControl

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
        Friend WithEvents PieChart1 As System.Drawing.PieChart.PieChartControl
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.PieChart1 = New System.Drawing.PieChart.PieChartControl
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.PieChart1)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(488, 352)
            Me.grbDetail.TabIndex = 7
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "Pie Chart"
            '
            'PieChart1
            '
            Me.PieChart1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PieChart1.Location = New System.Drawing.Point(3, 16)
            Me.PieChart1.Name = "PieChart1"
            Me.PieChart1.Size = New System.Drawing.Size(482, 333)
            Me.PieChart1.TabIndex = 1
            Me.PieChart1.ToolTips = Nothing
            '
            'GraphDialog
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "GraphDialog"
            Me.Size = New System.Drawing.Size(504, 376)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region "Constrctors"
        Public Sub New(ByVal chartName As String)
            MyBase.New()
            Me.InitializeComponent()
            Me.grbDetail.Text = chartName
        End Sub
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()

        End Sub
#End Region

#Region "Methods"
        Public Sub DrawGraph()
            Me.PieChart1.Visible = True
            PieChart1.LeftMargin = 10
            PieChart1.RightMargin = 10
            PieChart1.TopMargin = 10
            PieChart1.BottomMargin = 10
            PieChart1.FitChart = False
            PieChart1.SliceRelativeHeight = 0.25
            PieChart1.InitialAngle = -30
            PieChart1.EdgeLineWidth = 1
            PieChart1.EdgeColorType = System.Drawing.PieChart.EdgeColorType.DarkerThanSurface
        End Sub
        Public Sub SetValues(ByVal values As Decimal())
            Me.PieChart1.Values = values
        End Sub
        Public Sub SetPieDisplacements(ByVal values As Single())
            Me.PieChart1.SliceRelativeDisplacements = values
        End Sub
        Public Sub SetColors()
            Dim colors As New ArrayList
            colors.Add(Color.FromArgb(122, System.Drawing.Color.DeepSkyBlue))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.Firebrick))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.Yellow))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.Blue))
            colors.Add(Color.FromArgb(122, System.Drawing.Color.LimeGreen))
            Me.PieChart1.Colors = CType(colors.ToArray(GetType(Color)), Color())
        End Sub
        Public Sub SetColors(ByVal colors As ArrayList)
            Me.PieChart1.Colors = CType(colors.ToArray(GetType(Color)), Color())
        End Sub
        Public Sub SetTexts(ByVal texts As String())
            Me.PieChart1.Texts = texts
        End Sub
        Public Sub SetToolTips(ByVal toolTips As String())
            Me.PieChart1.ToolTips = toolTips
        End Sub
#End Region

    End Class
End Namespace

