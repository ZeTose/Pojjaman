Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Reporting
Imports Longkong.Reporting.Printing
Imports System.Drawing.Printing
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ReportPrintingPanel
        Inherits System.Windows.Forms.UserControl
        Implements IReportMaker

#Region "Members"

#End Region

#Region "Constructors"
        Public Sub New()
            InitializeComponent()
            Dim rd As New ReportDocument
            MakeDocument(rd)
            Me.PrintControl1.Document = rd
        End Sub
#End Region

#Region "Initialze"
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents PrintControl1 As PrintControl
        Private Sub InitializeComponent()
            Me.Button1 = New System.Windows.Forms.Button
            Me.PrintControl1 = New Longkong.Reporting.Printing.PrintControl
            Me.SuspendLayout()
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(144, 432)
            Me.Button1.Name = "Button1"
            Me.Button1.TabIndex = 2
            Me.Button1.Text = "Print"
            '
            'PrintControl1
            '
            Me.PrintControl1.Document = Nothing
            Me.PrintControl1.HideOnPrint = True
            Me.PrintControl1.Location = New System.Drawing.Point(56, 176)
            Me.PrintControl1.Name = "PrintControl1"
            Me.PrintControl1.Size = New System.Drawing.Size(384, 40)
            Me.PrintControl1.TabIndex = 0
            '
            'ReportPrintingPanel
            '
            Me.BackColor = System.Drawing.Color.White
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.PrintControl1)
            Me.Name = "ReportPrintingPanel"
            Me.Size = New System.Drawing.Size(681, 483)
            Me.ResumeLayout(False)

        End Sub
#End Region

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim rd As New ReportDocument
            MakeDocument(rd)
            rd.Print()
        End Sub

        Private Function GetDataView() As DataView
            Dim dt As New DataTable("People")
            dt.Columns.Add("FirstName", GetType(String))
            dt.Columns.Add("LastName", GetType(String))
            dt.Columns.Add("Birthdate", GetType(DateTime))
            dt.Columns.Add("Test", GetType(Integer))
            For i As Integer = 0 To 15
                dt.Rows.Add(New Object() {"Theodore", "Roosevelt", New DateTime(1858, 11, 27), 5})
                dt.Rows.Add(New Object() {"Winston ", "Churchill", New DateTime(1874, 11, 30), 5})
                dt.Rows.Add(New Object() {"Pablo", "Picasso", New DateTime(1881, 10, 25), 5})
                dt.Rows.Add(New Object() {"Charlie", "Chaplin", New DateTime(1889, 4, 16), 5})
                dt.Rows.Add(New Object() {"Steven", "Spielberg", New DateTime(1946, 12, 18), 5})
                dt.Rows.Add(New Object() {"Bart", "Simpson", New DateTime(1987, 4, 19), 5})
            Next

            Return dt.DefaultView
        End Function

        Public Sub MakeDocument(ByVal reportDocument As Reporting.Printing.ReportDocument) Implements Reporting.Printing.IReportMaker.MakeDocument

            ' create a data table and a default view from it.
            Dim dataView As dataView = Me.GetDataView()
            ' create a builder to help with putting the table together.
            Dim builder As New ReportBuilder(reportDocument)

            ' Add a simple page header and footer that is the same on all pages.
            builder.AddPageHeader("Birthdays Report", String.Empty, "หน้า %p")
            builder.AddPageFooter("left", "center", "right")
            builder.StartLinearLayout(Direction.Vertical)
            ' Add text sections
            builder.AddText("Birthdays", TextStyle.Heading3)
            builder.AddText("The following are various birthdays of people who " & _
            "are considered important in history.")
            ' Add a data section, then add columns
            builder.AddTable(dataView, True)
            builder.AddColumn("LastName", "Last Name", 1.5F, False, False)
            builder.AddColumn("FirstName", "First Name", 1.5F, False, False)
            builder.AddColumn("Birthdate", "Birthdate", 3.0F, False, False)
            builder.AddColumn("Test", "Test", 3.0F, False, False)
            ' Set the format expression to this string.
            builder.CurrentColumn.FormatExpression = "{0:D}"
            builder.FinishLinearLayout()
        End Sub
    End Class
End Namespace

