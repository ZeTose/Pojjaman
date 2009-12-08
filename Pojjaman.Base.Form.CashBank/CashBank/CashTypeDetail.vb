Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class CashTypeDetail
        Inherits AbstractEntityDetailPanelView
#Region "Members"
        Private m_entity As isimpleentity
#End Region
#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

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
        Friend WithEvents ddgAccChart As Longkong.Pojjaman.Gui.Components.DropDownGrid
        Friend WithEvents ImageButton2 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblCodeGL As System.Windows.Forms.Label
        Friend WithEvents txtCodeGL As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CashTypeDetail))
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblCodeGL = New System.Windows.Forms.Label
            Me.ddgAccChart = New Longkong.Pojjaman.Gui.Components.DropDownGrid
            Me.ImageButton2 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCodeGL = New System.Windows.Forms.TextBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.SuspendLayout()
            '
            'txtCode
            '
            Me.txtCode.Location = New System.Drawing.Point(104, 8)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(104, 20)
            Me.txtCode.TabIndex = 0
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Location = New System.Drawing.Point(16, 8)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(88, 16)
            Me.lblCode.TabIndex = 1
            Me.lblCode.Text = "ÃËÑÊ»ÃÐàÀ·à§Ô¹Ê´:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCodeGL
            '
            Me.lblCodeGL.Location = New System.Drawing.Point(16, 56)
            Me.lblCodeGL.Name = "lblCodeGL"
            Me.lblCodeGL.Size = New System.Drawing.Size(88, 16)
            Me.lblCodeGL.TabIndex = 1
            Me.lblCodeGL.Text = "ÃËÑÊ¼Ñ§ºÑ­ªÕ:"
            Me.lblCodeGL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ddgAccChart
            '
            Me.ddgAccChart.CodeColumnName = Nothing
            Me.ddgAccChart.Location = New System.Drawing.Point(104, 56)
            Me.ddgAccChart.Name = "ddgAccChart"
            Me.ddgAccChart.Size = New System.Drawing.Size(104, 22)
            Me.ddgAccChart.TabIndex = 190
            Me.ddgAccChart.TextReadOnly = False
            Me.ddgAccChart.Value = Nothing
            Me.ddgAccChart.ValueSetting = False
            '
            'ImageButton2
            '
            Me.ImageButton2.Image = CType(resources.GetObject("ImageButton2.Image"), System.Drawing.Image)
            Me.ImageButton2.Location = New System.Drawing.Point(208, 56)
            Me.ImageButton2.Name = "ImageButton2"
            Me.ImageButton2.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton2.TabIndex = 191
            Me.ImageButton2.ThemedImage = CType(resources.GetObject("ImageButton2.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCodeGL
            '
            Me.txtCodeGL.Location = New System.Drawing.Point(232, 56)
            Me.txtCodeGL.Name = "txtCodeGL"
            Me.txtCodeGL.ReadOnly = True
            Me.txtCodeGL.Size = New System.Drawing.Size(328, 20)
            Me.txtCodeGL.TabIndex = 0
            Me.txtCodeGL.Text = ""
            '
            'txtName
            '
            Me.txtName.Location = New System.Drawing.Point(104, 32)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(456, 20)
            Me.txtName.TabIndex = 0
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Location = New System.Drawing.Point(16, 32)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(88, 16)
            Me.lblName.TabIndex = 1
            Me.lblName.Text = "ª×èÍ»ÃÐàÀ·à§Ô¹Ê´:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CashTypeDetail
            '
            Me.Controls.Add(Me.ddgAccChart)
            Me.Controls.Add(Me.ImageButton2)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblCodeGL)
            Me.Controls.Add(Me.txtCodeGL)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.lblName)
            Me.Name = "CashTypeDetail"
            Me.Size = New System.Drawing.Size(576, 88)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

        End Sub

        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CashTypeDetail.lblCode}")
            Me.lblCodeGL.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CashTypeDetail.lblCodeGL}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CashTypeDetail.lblName}")

        End Sub
    End Class
End Namespace