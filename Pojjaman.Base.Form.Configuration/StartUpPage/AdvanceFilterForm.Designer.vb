<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvanceFilterForm
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
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.chkCostCenterList = New System.Windows.Forms.CheckedListBox()
    Me.txtDocDateEnd = New DevExpress.XtraEditors.DateEdit()
    Me.txtDocDateStart = New DevExpress.XtraEditors.DateEdit()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtCodePrefix = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.btnClear = New System.Windows.Forms.Button()
    Me.btnOK = New System.Windows.Forms.Button()
    Me.GroupBox1.SuspendLayout()
    CType(Me.txtDocDateEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtDocDateEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtDocDateStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtDocDateStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.chkCostCenterList)
    Me.GroupBox1.Controls.Add(Me.txtDocDateEnd)
    Me.GroupBox1.Controls.Add(Me.txtDocDateStart)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.txtCodePrefix)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(401, 401)
    Me.GroupBox1.TabIndex = 15
    Me.GroupBox1.TabStop = False
    '
    'chkCostCenterList
    '
    Me.chkCostCenterList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.chkCostCenterList.CheckOnClick = True
    Me.chkCostCenterList.FormattingEnabled = True
    Me.chkCostCenterList.Location = New System.Drawing.Point(110, 70)
    Me.chkCostCenterList.Name = "chkCostCenterList"
    Me.chkCostCenterList.Size = New System.Drawing.Size(277, 319)
    Me.chkCostCenterList.TabIndex = 3
    '
    'txtDocDateEnd
    '
    Me.txtDocDateEnd.EditValue = Nothing
    Me.txtDocDateEnd.Location = New System.Drawing.Point(249, 43)
    Me.txtDocDateEnd.Name = "txtDocDateEnd"
    Me.txtDocDateEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
    Me.txtDocDateEnd.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.txtDocDateEnd.Size = New System.Drawing.Size(100, 20)
    Me.txtDocDateEnd.TabIndex = 2
    '
    'txtDocDateStart
    '
    Me.txtDocDateStart.EditValue = Nothing
    Me.txtDocDateStart.Location = New System.Drawing.Point(110, 43)
    Me.txtDocDateStart.Name = "txtDocDateStart"
    Me.txtDocDateStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
    Me.txtDocDateStart.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.txtDocDateStart.Size = New System.Drawing.Size(100, 20)
    Me.txtDocDateStart.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(224, 46)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(19, 13)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "ถึง"
    '
    'txtCodePrefix
    '
    Me.txtCodePrefix.Location = New System.Drawing.Point(110, 16)
    Me.txtCodePrefix.MaxLength = 50
    Me.txtCodePrefix.Name = "txtCodePrefix"
    Me.txtCodePrefix.Size = New System.Drawing.Size(151, 20)
    Me.txtCodePrefix.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(13, 73)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(62, 13)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "Cost Center"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 46)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(66, 13)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "วันที่ เอกสาร"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 19)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(96, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "รหัสเอกสาร (Prefix)"
    '
    'btnClear
    '
    Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnClear.Location = New System.Drawing.Point(317, 413)
    Me.btnClear.Name = "btnClear"
    Me.btnClear.Size = New System.Drawing.Size(96, 23)
    Me.btnClear.TabIndex = 13
    Me.btnClear.Text = "Clear"
    '
    'btnOK
    '
    Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnOK.Location = New System.Drawing.Point(215, 413)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(96, 23)
    Me.btnOK.TabIndex = 10
    Me.btnOK.Text = "OK"
    '
    'AdvanceFilterForm
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(425, 444)
    Me.Controls.Add(Me.btnClear)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.btnOK)
    Me.Name = "AdvanceFilterForm"
    Me.Text = "Advance Filters Box"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.txtDocDateEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtDocDateEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtDocDateStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtDocDateStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents btnClear As System.Windows.Forms.Button
  Friend WithEvents btnOK As System.Windows.Forms.Button
  Friend WithEvents chkCostCenterList As System.Windows.Forms.CheckedListBox
  Friend WithEvents txtDocDateEnd As DevExpress.XtraEditors.DateEdit
  Friend WithEvents txtDocDateStart As DevExpress.XtraEditors.DateEdit
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtCodePrefix As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
