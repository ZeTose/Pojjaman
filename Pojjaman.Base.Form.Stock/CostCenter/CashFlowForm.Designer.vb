<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashFlowForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.lblName = New System.Windows.Forms.Label()
    Me.btnSearch = New System.Windows.Forms.Button()
    Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Panel2 = New System.Windows.Forms.Panel()
    CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblName
    '
    Me.lblName.AutoSize = True
    Me.lblName.BackColor = System.Drawing.SystemColors.Highlight
    Me.lblName.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblName.ForeColor = System.Drawing.Color.Snow
    Me.lblName.Location = New System.Drawing.Point(12, 5)
    Me.lblName.Name = "lblName"
    Me.lblName.Size = New System.Drawing.Size(359, 35)
    Me.lblName.TabIndex = 0
    Me.lblName.Text = "Cash Flow For: Project 101"
    Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnSearch
    '
    Me.btnSearch.Location = New System.Drawing.Point(198, 60)
    Me.btnSearch.Name = "btnSearch"
    Me.btnSearch.Size = New System.Drawing.Size(75, 23)
    Me.btnSearch.TabIndex = 1
    Me.btnSearch.Text = "ค้นหา"
    Me.btnSearch.UseVisualStyleBackColor = True
    '
    'DateTimePicker1
    '
    Me.DateTimePicker1.Location = New System.Drawing.Point(62, 61)
    Me.DateTimePicker1.Name = "DateTimePicker1"
    Me.DateTimePicker1.Size = New System.Drawing.Size(130, 20)
    Me.DateTimePicker1.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(13, 65)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(43, 13)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "ณ วันที่:"
    '
    'tgItem
    '
    Me.tgItem.AllowNew = False
    Me.tgItem.AllowSorting = False
    Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.tgItem.AutoColumnResize = True
    Me.tgItem.CaptionVisible = False
    Me.tgItem.Cellchanged = False
    Me.tgItem.DataMember = ""
    Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.tgItem.Location = New System.Drawing.Point(16, 560)
    Me.tgItem.Name = "tgItem"
    Me.tgItem.Size = New System.Drawing.Size(975, 158)
    Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
    Me.tgItem.TabIndex = 168
    Me.tgItem.TreeManager = Nothing
    '
    'Panel1
    '
    Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Panel1.Controls.Add(Me.Panel2)
    Me.Panel1.Controls.Add(Me.lblName)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.btnSearch)
    Me.Panel1.Controls.Add(Me.DateTimePicker1)
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1008, 554)
    Me.Panel1.TabIndex = 169
    '
    'Panel2
    '
    Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Panel2.BackColor = System.Drawing.Color.White
    Me.Panel2.Location = New System.Drawing.Point(18, 89)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(973, 450)
    Me.Panel2.TabIndex = 170
    '
    'CashFlowForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1008, 730)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.tgItem)
    Me.Name = "CashFlowForm"
    Me.Text = "Cash Flow"
    CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents lblName As System.Windows.Forms.Label
  Friend WithEvents btnSearch As System.Windows.Forms.Button
  Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
