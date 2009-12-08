Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CodeDescriptionDialog
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
        Friend WithEvents lstItems As System.Windows.Forms.ListBox
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents txtCodeName As System.Windows.Forms.TextBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
        Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.lstItems = New System.Windows.Forms.ListBox
            Me.btnRefresh = New System.Windows.Forms.Button
            Me.txtCodeName = New System.Windows.Forms.TextBox
            Me.TextBox1 = New System.Windows.Forms.TextBox
            Me.Button1 = New System.Windows.Forms.Button
            Me.TextBox2 = New System.Windows.Forms.TextBox
            Me.TextBox3 = New System.Windows.Forms.TextBox
            Me.ListBox1 = New System.Windows.Forms.ListBox
            Me.Button2 = New System.Windows.Forms.Button
            Me.TextBox4 = New System.Windows.Forms.TextBox
            Me.SuspendLayout()
            '
            'lstItems
            '
            Me.lstItems.Location = New System.Drawing.Point(40, 48)
            Me.lstItems.Name = "lstItems"
            Me.lstItems.Size = New System.Drawing.Size(528, 186)
            Me.lstItems.TabIndex = 3
            '
            'btnRefresh
            '
            Me.btnRefresh.Location = New System.Drawing.Point(240, 16)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.TabIndex = 1
            Me.btnRefresh.Text = "Refresh"
            '
            'txtCodeName
            '
            Me.txtCodeName.Location = New System.Drawing.Point(40, 16)
            Me.txtCodeName.Name = "txtCodeName"
            Me.txtCodeName.Size = New System.Drawing.Size(192, 20)
            Me.txtCodeName.TabIndex = 0
            Me.txtCodeName.Text = ""
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(40, 240)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(192, 20)
            Me.TextBox1.TabIndex = 0
            Me.TextBox1.Text = ""
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(240, 240)
            Me.Button1.Name = "Button1"
            Me.Button1.TabIndex = 1
            Me.Button1.Text = ">>"
            '
            'TextBox2
            '
            Me.TextBox2.Location = New System.Drawing.Point(320, 240)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(192, 20)
            Me.TextBox2.TabIndex = 0
            Me.TextBox2.Text = ""
            '
            'TextBox3
            '
            Me.TextBox3.Location = New System.Drawing.Point(40, 272)
            Me.TextBox3.Multiline = True
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Size = New System.Drawing.Size(440, 88)
            Me.TextBox3.TabIndex = 4
            Me.TextBox3.Text = "TextBox3"
            '
            'ListBox1
            '
            Me.ListBox1.Location = New System.Drawing.Point(40, 368)
            Me.ListBox1.Name = "ListBox1"
            Me.ListBox1.Size = New System.Drawing.Size(440, 134)
            Me.ListBox1.TabIndex = 5
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(488, 368)
            Me.Button2.Name = "Button2"
            Me.Button2.TabIndex = 1
            Me.Button2.Text = ">>"
            '
            'TextBox4
            '
            Me.TextBox4.Location = New System.Drawing.Point(488, 272)
            Me.TextBox4.Multiline = True
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Size = New System.Drawing.Size(440, 88)
            Me.TextBox4.TabIndex = 6
            Me.TextBox4.Text = "TextBox4"
            '
            'CodeDescriptionDialog
            '
            Me.Controls.Add(Me.TextBox4)
            Me.Controls.Add(Me.ListBox1)
            Me.Controls.Add(Me.TextBox3)
            Me.Controls.Add(Me.lstItems)
            Me.Controls.Add(Me.btnRefresh)
            Me.Controls.Add(Me.txtCodeName)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.Button2)
            Me.Name = "CodeDescriptionDialog"
            Me.Size = New System.Drawing.Size(1024, 520)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
        End Sub
#End Region

        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Me.lstItems.Items.Clear()
            Dim dt As DataTable = CodeDescription.GetCodeList(Me.txtCodeName.Text)
            For Each row As DataRow In dt.Rows
                Me.lstItems.Items.Add(row("code_description").ToString & ":" & row("code_value").ToString)
            Next
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Me.TextBox2.Text = Configuration.FormatToString(CDbl(TextBox1.Text), DigitConfig.CurrencyText)
        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            For Each line As String In TextHelper.StringHelper.CutText(Me.TextBox3.Text, Me.ListBox1.Width, Me.ListBox1.CreateGraphics, Me.ListBox1.Font)
                Me.ListBox1.Items.Add(line)
            Next
            Me.TextBox4.Text = TextHelper.StringHelper.CTTEX(Me.TextBox3.Text)
        End Sub
    End Class
End Namespace