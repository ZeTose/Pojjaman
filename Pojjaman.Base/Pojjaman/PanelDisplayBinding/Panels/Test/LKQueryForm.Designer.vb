<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LKQueryForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LKQueryForm))
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
    Me.btnExecute = New System.Windows.Forms.Button()
    Me.txtCommand = New System.Windows.Forms.TextBox()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.txtMessage = New System.Windows.Forms.TextBox()
    Me.lblWord = New System.Windows.Forms.Label()
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblWord)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnExecute)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtCommand)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
    Me.SplitContainer1.Size = New System.Drawing.Size(595, 373)
    Me.SplitContainer1.SplitterDistance = 84
    Me.SplitContainer1.TabIndex = 0
    '
    'btnExecute
    '
    Me.btnExecute.Location = New System.Drawing.Point(3, 3)
    Me.btnExecute.Name = "btnExecute"
    Me.btnExecute.Size = New System.Drawing.Size(75, 23)
    Me.btnExecute.TabIndex = 1
    Me.btnExecute.Text = "Execute"
    Me.btnExecute.UseVisualStyleBackColor = True
    '
    'txtCommand
    '
    Me.txtCommand.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtCommand.Location = New System.Drawing.Point(3, 27)
    Me.txtCommand.Multiline = True
    Me.txtCommand.Name = "txtCommand"
    Me.txtCommand.Size = New System.Drawing.Size(589, 54)
    Me.txtCommand.TabIndex = 0
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(595, 285)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.AutoScroll = True
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(587, 259)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "Results"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.txtMessage)
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(587, 259)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "Messages"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'txtMessage
    '
    Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
    Me.txtMessage.Location = New System.Drawing.Point(3, 3)
    Me.txtMessage.Multiline = True
    Me.txtMessage.Name = "txtMessage"
    Me.txtMessage.Size = New System.Drawing.Size(581, 253)
    Me.txtMessage.TabIndex = 0
    '
    'lblWord
    '
    Me.lblWord.AutoSize = True
    Me.lblWord.ForeColor = System.Drawing.Color.Tomato
    Me.lblWord.Location = New System.Drawing.Point(95, 8)
    Me.lblWord.Name = "lblWord"
    Me.lblWord.Size = New System.Drawing.Size(443, 13)
    Me.lblWord.TabIndex = 2
    Me.lblWord.Text = "!! การเปิด begin transaction ใน query ต้องปิด commit transaction/rollback transac" & _
    "tion ไปเลย "
    '
    'LKQueryForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(595, 373)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "LKQueryForm"
    Me.Text = "Query Form"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.ResumeLayout(False)
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents btnExecute As System.Windows.Forms.Button
  Friend WithEvents txtCommand As System.Windows.Forms.TextBox
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents txtMessage As System.Windows.Forms.TextBox
  Friend WithEvents lblWord As System.Windows.Forms.Label
End Class
