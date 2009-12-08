Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ItemGridPanel
        Inherits UserControl

#Region "Members"

#End Region

#Region "Constructors"
        Public Sub New()

        End Sub
#End Region

        Friend WithEvents dgIem As Longkong.Pojjaman.Gui.Components.PJMDataGrid

        Private Sub InitializeComponent()
            Me.dgIem = New Longkong.Pojjaman.Gui.Components.PJMDataGrid
            CType(Me.dgIem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dgIem
            '
            Me.dgIem.AllowColumnDrag = True
            Me.dgIem.AllowColumnResize = False
            Me.dgIem.AllowNew = False
            Me.dgIem.CaptionVisible = False
            Me.dgIem.CustomColumnHeaders = True
            Me.dgIem.DataMember = ""
            Me.dgIem.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgIem.FullRowSelect = False
            Me.dgIem.HeaderFont = New System.Drawing.Font("Times New Roman", 29.35059!)
            Me.dgIem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dgIem.Location = New System.Drawing.Point(0, 0)
            Me.dgIem.m_dataTable = Nothing
            Me.dgIem.Name = "dgIem"
            Me.dgIem.ShowColumnHeaderWhileDragging = True
            Me.dgIem.ShowColumnWhileDragging = True
            Me.dgIem.Size = New System.Drawing.Size(681, 200)
            Me.dgIem.TabIndex = 0
            '
            'POGridPanel
            '
            Me.Controls.Add(Me.dgIem)
            Me.Name = "ItemGridPanel"
            Me.Size = New System.Drawing.Size(681, 200)
            CType(Me.dgIem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace

