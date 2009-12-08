Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class SumCostCenter
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
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblItem = New System.Windows.Forms.Label
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(8, 8)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(168, 18)
            Me.lblItem.TabIndex = 212
            Me.lblItem.Text = " √ÿª¬Õ¥ Cost Center:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 24)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(656, 384)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 213
            Me.tgItem.TreeManager = Nothing
            '
            'SumCostCenter
            '
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.lblItem)
            Me.Name = "SumCostCenter"
            Me.Size = New System.Drawing.Size(672, 416)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Overrides Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SumCostCenter.lblItem}")

        End Sub
    End Class
End Namespace