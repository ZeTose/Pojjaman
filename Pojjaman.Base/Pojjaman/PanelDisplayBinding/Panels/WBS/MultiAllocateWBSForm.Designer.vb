<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiAllocateWBSForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiAllocateWBSForm))
    Me.btnOK = New System.Windows.Forms.Button()
    Me.btnCancel = New System.Windows.Forms.Button()
    Me.lblSumPercent = New System.Windows.Forms.Label()
    Me.ibtnAddWBS = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.ibtnDelWBS = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.tgToCC = New Longkong.Pojjaman.Gui.Components.TreeGrid()
    CType(Me.tgToCC, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btnOK
    '
    Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.btnOK.Location = New System.Drawing.Point(511, 232)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(75, 23)
    Me.btnOK.TabIndex = 34
    Me.btnOK.Text = "ตกลง"
    Me.btnOK.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.Location = New System.Drawing.Point(592, 232)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 34
    Me.btnCancel.Text = "ยกเลิก"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'lblSumPercent
    '
    Me.lblSumPercent.AutoSize = True
    Me.lblSumPercent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblSumPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblSumPercent.Location = New System.Drawing.Point(569, 6)
    Me.lblSumPercent.Name = "lblSumPercent"
    Me.lblSumPercent.Size = New System.Drawing.Size(97, 18)
    Me.lblSumPercent.TabIndex = 35
    Me.lblSumPercent.Text = "lblSumPercent"
    Me.lblSumPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ibtnAddWBS
    '
    Me.ibtnAddWBS.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ibtnAddWBS.Location = New System.Drawing.Point(34, 4)
    Me.ibtnAddWBS.Name = "ibtnAddWBS"
    Me.ibtnAddWBS.Size = New System.Drawing.Size(24, 24)
    Me.ibtnAddWBS.TabIndex = 32
    Me.ibtnAddWBS.TabStop = False
    Me.ibtnAddWBS.ThemedImage = CType(resources.GetObject("ibtnAddWBS.ThemedImage"), System.Drawing.Bitmap)
    Me.ibtnAddWBS.Visible = False
    '
    'ibtnDelWBS
    '
    Me.ibtnDelWBS.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ibtnDelWBS.Location = New System.Drawing.Point(58, 4)
    Me.ibtnDelWBS.Name = "ibtnDelWBS"
    Me.ibtnDelWBS.Size = New System.Drawing.Size(24, 24)
    Me.ibtnDelWBS.TabIndex = 33
    Me.ibtnDelWBS.TabStop = False
    Me.ibtnDelWBS.ThemedImage = CType(resources.GetObject("ibtnDelWBS.ThemedImage"), System.Drawing.Bitmap)
    '
    'tgToCC
    '
    Me.tgToCC.AllowNew = False
    Me.tgToCC.AllowSorting = False
    Me.tgToCC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.tgToCC.AutoColumnResize = True
    Me.tgToCC.CaptionVisible = False
    Me.tgToCC.Cellchanged = False
    Me.tgToCC.DataMember = ""
    Me.tgToCC.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.tgToCC.Location = New System.Drawing.Point(1, 30)
    Me.tgToCC.Name = "tgToCC"
    Me.tgToCC.Size = New System.Drawing.Size(670, 196)
    Me.tgToCC.SortingArrowColor = System.Drawing.Color.Red
    Me.tgToCC.TabIndex = 29
    Me.tgToCC.TreeManager = Nothing
    '
    'MultiAllocateWBSForm
    '
    Me.AcceptButton = Me.btnOK
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(672, 262)
    Me.Controls.Add(Me.lblSumPercent)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.btnOK)
    Me.Controls.Add(Me.ibtnAddWBS)
    Me.Controls.Add(Me.ibtnDelWBS)
    Me.Controls.Add(Me.tgToCC)
    Me.Name = "MultiAllocateWBSForm"
    Me.Text = "MultiAllocateWBSForm"
    CType(Me.tgToCC, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents tgToCC As Longkong.Pojjaman.Gui.Components.TreeGrid
  Friend WithEvents ibtnAddWBS As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents ibtnDelWBS As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents btnOK As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents lblSumPercent As System.Windows.Forms.Label
End Class
