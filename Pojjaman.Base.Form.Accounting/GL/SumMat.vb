Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class SumMat
        Inherits AbstractEntityDetailPanelView

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
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.RadioButton1 = New System.Windows.Forms.RadioButton
            Me.RadioButton2 = New System.Windows.Forms.RadioButton
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 32)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(656, 376)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 215
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(16, 8)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(168, 18)
            Me.lblItem.TabIndex = 214
            Me.lblItem.Text = "สรุปยอดวัสดุก่อสร้าง:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'RadioButton1
            '
            Me.RadioButton1.Location = New System.Drawing.Point(184, 8)
            Me.RadioButton1.Name = "RadioButton1"
            Me.RadioButton1.Size = New System.Drawing.Size(96, 24)
            Me.RadioButton1.TabIndex = 216
            Me.RadioButton1.Text = "รวมทั้งหมด"
            '
            'RadioButton2
            '
            Me.RadioButton2.Location = New System.Drawing.Point(288, 8)
            Me.RadioButton2.Name = "RadioButton2"
            Me.RadioButton2.Size = New System.Drawing.Size(160, 24)
            Me.RadioButton2.TabIndex = 216
            Me.RadioButton2.Text = "จำแนกตามCost Center"
            '
            'SumMat
            '
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.RadioButton1)
            Me.Controls.Add(Me.RadioButton2)
            Me.Name = "SumMat"
            Me.Size = New System.Drawing.Size(672, 416)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Overrides Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SumMat.lblItem}")
            Me.RadioButton1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SumMat.RadioButton1}")
            Me.RadioButton2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SumMat.RadioButton2}")

        End Sub
    End Class
End Namespace