<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToollotBoxForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToollotBoxForm))
    Me.Grbeqi = New System.Windows.Forms.GroupBox()
    Me.txtBuyQTY = New System.Windows.Forms.TextBox()
    Me.txtBuyDate = New System.Windows.Forms.TextBox()
    Me.txtUnitCost = New System.Windows.Forms.TextBox()
    Me.txtDescription = New System.Windows.Forms.TextBox()
    Me.lblBrand = New System.Windows.Forms.Label()
    Me.lblRefDocQty = New System.Windows.Forms.Label()
    Me.lblUnitCost = New System.Windows.Forms.Label()
    Me.lblDescription = New System.Windows.Forms.Label()
    Me.TxtBrand = New System.Windows.Forms.TextBox()
    Me.cmbCode = New System.Windows.Forms.ComboBox()
    Me.chkAutorun = New System.Windows.Forms.CheckBox()
    Me.lblToollotCode = New System.Windows.Forms.Label()
    Me.lblRefDocAmount = New System.Windows.Forms.Label()
    Me.lblRefDocDate = New System.Windows.Forms.Label()
    Me.txtBuyCode = New System.Windows.Forms.TextBox()
    Me.lblRefDoc = New System.Windows.Forms.Label()
    Me.ImageButton1 = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.ibtnSave = New System.Windows.Forms.Button()
    Me.ibtnCancel = New System.Windows.Forms.Button()
    Me.btnAssetFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.txtAssetName = New System.Windows.Forms.TextBox()
    Me.txtAssetCode = New System.Windows.Forms.TextBox()
    Me.lblAsset = New System.Windows.Forms.Label()
    Me.Grbeqi.SuspendLayout()
    Me.SuspendLayout()
    '
    'Grbeqi
    '
    Me.Grbeqi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Grbeqi.Controls.Add(Me.txtBuyQTY)
    Me.Grbeqi.Controls.Add(Me.txtBuyDate)
    Me.Grbeqi.Controls.Add(Me.txtUnitCost)
    Me.Grbeqi.Controls.Add(Me.txtDescription)
    Me.Grbeqi.Controls.Add(Me.lblBrand)
    Me.Grbeqi.Controls.Add(Me.lblRefDocQty)
    Me.Grbeqi.Controls.Add(Me.lblUnitCost)
    Me.Grbeqi.Controls.Add(Me.lblDescription)
    Me.Grbeqi.Controls.Add(Me.TxtBrand)
    Me.Grbeqi.Controls.Add(Me.cmbCode)
    Me.Grbeqi.Controls.Add(Me.chkAutorun)
    Me.Grbeqi.Controls.Add(Me.lblToollotCode)
    Me.Grbeqi.Controls.Add(Me.lblRefDocAmount)
    Me.Grbeqi.Controls.Add(Me.lblRefDocDate)
    Me.Grbeqi.Controls.Add(Me.txtBuyCode)
    Me.Grbeqi.Controls.Add(Me.lblAsset)
    Me.Grbeqi.Controls.Add(Me.lblRefDoc)
    Me.Grbeqi.Controls.Add(Me.ImageButton1)
    Me.Grbeqi.Controls.Add(Me.btnAssetFind)
    Me.Grbeqi.Controls.Add(Me.txtAssetName)
    Me.Grbeqi.Controls.Add(Me.txtAssetCode)
    Me.Grbeqi.Controls.Add(Me.TxtAmount)
    Me.Grbeqi.Location = New System.Drawing.Point(12, 5)
    Me.Grbeqi.Name = "Grbeqi"
    Me.Grbeqi.Size = New System.Drawing.Size(525, 269)
    Me.Grbeqi.TabIndex = 0
    Me.Grbeqi.TabStop = False
    Me.Grbeqi.Text = "Lot ของเครื่องมือ"
    '
    'txtBuyQTY
    '
    Me.txtBuyQTY.Location = New System.Drawing.Point(141, 107)
    Me.txtBuyQTY.Name = "txtBuyQTY"
    Me.txtBuyQTY.Size = New System.Drawing.Size(145, 20)
    Me.txtBuyQTY.TabIndex = 3
    Me.txtBuyQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'txtBuyDate
    '
    Me.txtBuyDate.Location = New System.Drawing.Point(389, 83)
    Me.txtBuyDate.Name = "txtBuyDate"
    Me.txtBuyDate.ReadOnly = True
    Me.txtBuyDate.Size = New System.Drawing.Size(87, 20)
    Me.txtBuyDate.TabIndex = 9
    '
    'txtUnitCost
    '
    Me.txtUnitCost.AcceptsTab = True
    Me.txtUnitCost.Location = New System.Drawing.Point(141, 131)
    Me.txtUnitCost.Name = "txtUnitCost"
    Me.txtUnitCost.Size = New System.Drawing.Size(145, 20)
    Me.txtUnitCost.TabIndex = 4
    Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'txtDescription
    '
    Me.txtDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.txtDescription.Location = New System.Drawing.Point(141, 202)
    Me.txtDescription.MaxLength = 255
    Me.txtDescription.Multiline = True
    Me.txtDescription.Name = "txtDescription"
    Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtDescription.Size = New System.Drawing.Size(254, 47)
    Me.txtDescription.TabIndex = 6
    '
    'lblBrand
    '
    Me.lblBrand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblBrand.ForeColor = System.Drawing.Color.Black
    Me.lblBrand.Location = New System.Drawing.Point(10, 179)
    Me.lblBrand.Name = "lblBrand"
    Me.lblBrand.Size = New System.Drawing.Size(125, 18)
    Me.lblBrand.TabIndex = 4
    Me.lblBrand.Text = "Brand :"
    Me.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblRefDocQty
    '
    Me.lblRefDocQty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblRefDocQty.ForeColor = System.Drawing.Color.Black
    Me.lblRefDocQty.Location = New System.Drawing.Point(10, 110)
    Me.lblRefDocQty.Name = "lblRefDocQty"
    Me.lblRefDocQty.Size = New System.Drawing.Size(125, 18)
    Me.lblRefDocQty.TabIndex = 5
    Me.lblRefDocQty.Text = "จำนวนซื้อ :"
    Me.lblRefDocQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblUnitCost
    '
    Me.lblUnitCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblUnitCost.ForeColor = System.Drawing.Color.Black
    Me.lblUnitCost.Location = New System.Drawing.Point(10, 134)
    Me.lblUnitCost.Name = "lblUnitCost"
    Me.lblUnitCost.Size = New System.Drawing.Size(125, 18)
    Me.lblUnitCost.TabIndex = 5
    Me.lblUnitCost.Text = "ต้นทุน/หน่วย :"
    Me.lblUnitCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblDescription
    '
    Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblDescription.ForeColor = System.Drawing.Color.Black
    Me.lblDescription.Location = New System.Drawing.Point(10, 213)
    Me.lblDescription.Name = "lblDescription"
    Me.lblDescription.Size = New System.Drawing.Size(125, 18)
    Me.lblDescription.TabIndex = 5
    Me.lblDescription.Text = "Description :"
    Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtBrand
    '
    Me.TxtBrand.Location = New System.Drawing.Point(141, 179)
    Me.TxtBrand.Name = "TxtBrand"
    Me.TxtBrand.Size = New System.Drawing.Size(145, 20)
    Me.TxtBrand.TabIndex = 5
    '
    'cmbCode
    '
    Me.cmbCode.Location = New System.Drawing.Point(141, 34)
    Me.cmbCode.Name = "cmbCode"
    Me.cmbCode.Size = New System.Drawing.Size(145, 21)
    Me.cmbCode.TabIndex = 1
    '
    'chkAutorun
    '
    Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
    Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
    Me.chkAutorun.Location = New System.Drawing.Point(287, 33)
    Me.chkAutorun.Name = "chkAutorun"
    Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
    Me.chkAutorun.TabIndex = 6
    Me.chkAutorun.TabStop = False
    '
    'lblToollotCode
    '
    Me.lblToollotCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblToollotCode.ForeColor = System.Drawing.Color.Black
    Me.lblToollotCode.Location = New System.Drawing.Point(6, 36)
    Me.lblToollotCode.Name = "lblToollotCode"
    Me.lblToollotCode.Size = New System.Drawing.Size(131, 18)
    Me.lblToollotCode.TabIndex = 0
    Me.lblToollotCode.Text = "รหัส :"
    Me.lblToollotCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblRefDocAmount
    '
    Me.lblRefDocAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblRefDocAmount.ForeColor = System.Drawing.Color.Black
    Me.lblRefDocAmount.Location = New System.Drawing.Point(10, 155)
    Me.lblRefDocAmount.Name = "lblRefDocAmount"
    Me.lblRefDocAmount.Size = New System.Drawing.Size(125, 18)
    Me.lblRefDocAmount.TabIndex = 4
    Me.lblRefDocAmount.Text = "มูลค่าซื้อ :"
    Me.lblRefDocAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblRefDocDate
    '
    Me.lblRefDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblRefDocDate.ForeColor = System.Drawing.Color.Black
    Me.lblRefDocDate.Location = New System.Drawing.Point(316, 82)
    Me.lblRefDocDate.Name = "lblRefDocDate"
    Me.lblRefDocDate.Size = New System.Drawing.Size(67, 18)
    Me.lblRefDocDate.TabIndex = 5
    Me.lblRefDocDate.Text = "วันที่ซื้อ :"
    Me.lblRefDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtBuyCode
    '
    Me.txtBuyCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.txtBuyCode.Location = New System.Drawing.Point(141, 82)
    Me.txtBuyCode.Name = "txtBuyCode"
    Me.txtBuyCode.ReadOnly = True
    Me.txtBuyCode.Size = New System.Drawing.Size(145, 21)
    Me.txtBuyCode.TabIndex = 8
    '
    'lblRefDoc
    '
    Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblRefDoc.ForeColor = System.Drawing.Color.Black
    Me.lblRefDoc.Location = New System.Drawing.Point(6, 84)
    Me.lblRefDoc.Name = "lblRefDoc"
    Me.lblRefDoc.Size = New System.Drawing.Size(131, 18)
    Me.lblRefDoc.TabIndex = 3
    Me.lblRefDoc.Text = "เลขที่เอกสารซื้อ :"
    Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ImageButton1
    '
    Me.ImageButton1.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ImageButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.ImageButton1.ForeColor = System.Drawing.SystemColors.Control
    Me.ImageButton1.Location = New System.Drawing.Point(286, 80)
    Me.ImageButton1.Name = "ImageButton1"
    Me.ImageButton1.Size = New System.Drawing.Size(24, 23)
    Me.ImageButton1.TabIndex = 8
    Me.ImageButton1.TabStop = False
    Me.ImageButton1.ThemedImage = CType(resources.GetObject("ImageButton1.ThemedImage"), System.Drawing.Bitmap)
    '
    'TxtAmount
    '
    Me.TxtAmount.Location = New System.Drawing.Point(141, 155)
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.ReadOnly = True
    Me.TxtAmount.Size = New System.Drawing.Size(145, 20)
    Me.TxtAmount.TabIndex = 10
    Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ibtnSave
    '
    Me.ibtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ibtnSave.Location = New System.Drawing.Point(381, 280)
    Me.ibtnSave.Name = "ibtnSave"
    Me.ibtnSave.Size = New System.Drawing.Size(75, 23)
    Me.ibtnSave.TabIndex = 1
    Me.ibtnSave.Text = "บันทึก"
    Me.ibtnSave.UseVisualStyleBackColor = True
    '
    'ibtnCancel
    '
    Me.ibtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ibtnCancel.Location = New System.Drawing.Point(462, 280)
    Me.ibtnCancel.Name = "ibtnCancel"
    Me.ibtnCancel.Size = New System.Drawing.Size(75, 23)
    Me.ibtnCancel.TabIndex = 2
    Me.ibtnCancel.Text = "ยกเลิก"
    Me.ibtnCancel.UseVisualStyleBackColor = True
    '
    'btnAssetFind
    '
    Me.btnAssetFind.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnAssetFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.btnAssetFind.ForeColor = System.Drawing.SystemColors.Control
    Me.btnAssetFind.Location = New System.Drawing.Point(452, 56)
    Me.btnAssetFind.Name = "btnAssetFind"
    Me.btnAssetFind.Size = New System.Drawing.Size(24, 23)
    Me.btnAssetFind.TabIndex = 7
    Me.btnAssetFind.TabStop = False
    Me.btnAssetFind.ThemedImage = CType(resources.GetObject("btnAssetFind.ThemedImage"), System.Drawing.Bitmap)
    '
    'txtAssetName
    '
    Me.txtAssetName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.txtAssetName.Location = New System.Drawing.Point(287, 58)
    Me.txtAssetName.Name = "txtAssetName"
    Me.txtAssetName.ReadOnly = True
    Me.txtAssetName.Size = New System.Drawing.Size(164, 21)
    Me.txtAssetName.TabIndex = 7
    Me.txtAssetName.TabStop = False
    '
    'txtAssetCode
    '
    Me.txtAssetCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.txtAssetCode.Location = New System.Drawing.Point(141, 58)
    Me.txtAssetCode.Name = "txtAssetCode"
    Me.txtAssetCode.Size = New System.Drawing.Size(145, 21)
    Me.txtAssetCode.TabIndex = 2
    '
    'lblAsset
    '
    Me.lblAsset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblAsset.ForeColor = System.Drawing.Color.Black
    Me.lblAsset.Location = New System.Drawing.Point(6, 60)
    Me.lblAsset.Name = "lblAsset"
    Me.lblAsset.Size = New System.Drawing.Size(131, 18)
    Me.lblAsset.TabIndex = 0
    Me.lblAsset.Text = "สินทรัพย์ :"
    Me.lblAsset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ToollotBoxForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(549, 312)
    Me.Controls.Add(Me.ibtnCancel)
    Me.Controls.Add(Me.ibtnSave)
    Me.Controls.Add(Me.Grbeqi)
    Me.Name = "ToollotBoxForm"
    Me.Text = "Toollot Box"
    Me.Grbeqi.ResumeLayout(False)
    Me.Grbeqi.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Grbeqi As System.Windows.Forms.GroupBox
  Friend WithEvents txtBuyQTY As System.Windows.Forms.TextBox
  Friend WithEvents txtBuyDate As System.Windows.Forms.TextBox
  Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
  Friend WithEvents txtDescription As System.Windows.Forms.TextBox
  Friend WithEvents lblBrand As System.Windows.Forms.Label
  Friend WithEvents lblRefDocQty As System.Windows.Forms.Label
  Friend WithEvents lblUnitCost As System.Windows.Forms.Label
  Friend WithEvents lblDescription As System.Windows.Forms.Label
  Friend WithEvents TxtBrand As System.Windows.Forms.TextBox
  Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
  Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
  Friend WithEvents lblToollotCode As System.Windows.Forms.Label
  Friend WithEvents lblRefDocAmount As System.Windows.Forms.Label
  Friend WithEvents lblRefDocDate As System.Windows.Forms.Label
  Friend WithEvents txtBuyCode As System.Windows.Forms.TextBox
  Friend WithEvents lblRefDoc As System.Windows.Forms.Label
  Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
  Friend WithEvents ibtnSave As System.Windows.Forms.Button
  Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents ibtnCancel As System.Windows.Forms.Button
  Friend WithEvents lblAsset As System.Windows.Forms.Label
  Friend WithEvents btnAssetFind As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents txtAssetName As System.Windows.Forms.TextBox
  Friend WithEvents txtAssetCode As System.Windows.Forms.TextBox
End Class
