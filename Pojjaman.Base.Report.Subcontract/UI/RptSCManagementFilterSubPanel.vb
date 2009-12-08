Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptSCManagementFilterSubPanel
        Inherits AbstractFilterSubPanel
        Implements IReportFilterSubPanel

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
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnSpgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSpgCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSpgStart As System.Windows.Forms.Label
        Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
        Friend WithEvents chkIncludeChildCC As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowDetail As System.Windows.Forms.CheckBox
        Friend WithEvents chkMat As System.Windows.Forms.CheckBox
        Friend WithEvents grWbsDetail As System.Windows.Forms.GroupBox
        Friend WithEvents chkLab As System.Windows.Forms.CheckBox
        Friend WithEvents chkEq As System.Windows.Forms.CheckBox
        Friend WithEvents chkNoDigit As System.Windows.Forms.CheckBox
        Friend WithEvents lblSubcontratorEnd As System.Windows.Forms.Label
        Friend WithEvents lblSubcontratorStart As System.Windows.Forms.Label
        Friend WithEvents chkIncludeSCGroup As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptSCManagementFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtTemp = New System.Windows.Forms.TextBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkNoDigit = New System.Windows.Forms.CheckBox
      Me.grWbsDetail = New System.Windows.Forms.GroupBox
      Me.chkMat = New System.Windows.Forms.CheckBox
      Me.chkLab = New System.Windows.Forms.CheckBox
      Me.chkEq = New System.Windows.Forms.CheckBox
      Me.chkIncludeChildCC = New System.Windows.Forms.CheckBox
      Me.chkIncludeSCGroup = New System.Windows.Forms.CheckBox
      Me.btnSpgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtSpgCodeStart = New System.Windows.Forms.TextBox
      Me.lblSpgStart = New System.Windows.Forms.Label
      Me.txtSupplierGroupName = New System.Windows.Forms.TextBox
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox
      Me.lblCCStart = New System.Windows.Forms.Label
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox
      Me.lblSubcontratorEnd = New System.Windows.Forms.Label
      Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox
      Me.lblSubcontratorStart = New System.Windows.Forms.Label
      Me.chkShowDetail = New System.Windows.Forms.CheckBox
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.grWbsDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(608, 248)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(608, 32)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtTemp, "")
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 3
      Me.txtTemp.Text = ""
      Me.txtTemp.Visible = False
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.chkNoDigit)
      Me.grbDetail.Controls.Add(Me.grWbsDetail)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildCC)
      Me.grbDetail.Controls.Add(Me.chkIncludeSCGroup)
      Me.grbDetail.Controls.Add(Me.btnSpgCodeStart)
      Me.grbDetail.Controls.Add(Me.txtSpgCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSpgStart)
      Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
      Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblSubcontratorEnd)
      Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
      Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
      Me.grbDetail.Controls.Add(Me.lblSubcontratorStart)
      Me.grbDetail.Controls.Add(Me.chkShowDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(576, 194)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'chkNoDigit
      '
      Me.chkNoDigit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNoDigit.Location = New System.Drawing.Point(104, 168)
      Me.chkNoDigit.Name = "chkNoDigit"
      Me.chkNoDigit.Size = New System.Drawing.Size(120, 24)
      Me.chkNoDigit.TabIndex = 33
      Me.chkNoDigit.Text = "No Digit"
      '
      'grWbsDetail
      '
      Me.grWbsDetail.Controls.Add(Me.chkMat)
      Me.grWbsDetail.Controls.Add(Me.chkLab)
      Me.grWbsDetail.Controls.Add(Me.chkEq)
      Me.grWbsDetail.Location = New System.Drawing.Point(400, 16)
      Me.grWbsDetail.Name = "grWbsDetail"
      Me.grWbsDetail.Size = New System.Drawing.Size(160, 96)
      Me.grWbsDetail.TabIndex = 32
      Me.grWbsDetail.TabStop = False
      Me.grWbsDetail.Text = "WBS Budget Included"
      '
      'chkMat
      '
      Me.chkMat.Checked = True
      Me.chkMat.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkMat.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkMat.Location = New System.Drawing.Point(8, 16)
      Me.chkMat.Name = "chkMat"
      Me.chkMat.TabIndex = 31
      Me.chkMat.Text = "Include Matetial"
      '
      'chkLab
      '
      Me.chkLab.Checked = True
      Me.chkLab.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkLab.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkLab.Location = New System.Drawing.Point(8, 40)
      Me.chkLab.Name = "chkLab"
      Me.chkLab.TabIndex = 31
      Me.chkLab.Text = "Include Labor"
      '
      'chkEq
      '
      Me.chkEq.Checked = True
      Me.chkEq.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkEq.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkEq.Location = New System.Drawing.Point(8, 64)
      Me.chkEq.Name = "chkEq"
      Me.chkEq.Size = New System.Drawing.Size(128, 24)
      Me.chkEq.TabIndex = 31
      Me.chkEq.Text = "Include Equipment"
      '
      'chkIncludeChildCC
      '
      Me.chkIncludeChildCC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildCC.Location = New System.Drawing.Point(104, 120)
      Me.chkIncludeChildCC.Name = "chkIncludeChildCC"
      Me.chkIncludeChildCC.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildCC.TabIndex = 31
      Me.chkIncludeChildCC.Text = "รวม Cost Center ลูก"
      '
      'chkIncludeSCGroup
      '
      Me.chkIncludeSCGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeSCGroup.Location = New System.Drawing.Point(104, 48)
      Me.chkIncludeSCGroup.Name = "chkIncludeSCGroup"
      Me.chkIncludeSCGroup.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeSCGroup.TabIndex = 30
      Me.chkIncludeSCGroup.Text = "รวมกลุ่มผู้รับเหมา"
      '
      'btnSpgCodeStart
      '
      Me.btnSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSpgCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSpgCodeStart.Image = CType(resources.GetObject("btnSpgCodeStart.Image"), System.Drawing.Image)
      Me.btnSpgCodeStart.Location = New System.Drawing.Point(200, 24)
      Me.btnSpgCodeStart.Name = "btnSpgCodeStart"
      Me.btnSpgCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnSpgCodeStart.TabIndex = 6
      Me.btnSpgCodeStart.TabStop = False
      Me.btnSpgCodeStart.ThemedImage = CType(resources.GetObject("btnSpgCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSpgCodeStart
      '
      Me.Validator.SetDataType(Me.txtSpgCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSpgCodeStart, "")
      Me.txtSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSpgCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
      Me.txtSpgCodeStart.Location = New System.Drawing.Point(104, 24)
      Me.txtSpgCodeStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtSpgCodeStart, "")
      Me.Validator.SetMinValue(Me.txtSpgCodeStart, "")
      Me.txtSpgCodeStart.Name = "txtSpgCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSpgCodeStart, "")
      Me.Validator.SetRequired(Me.txtSpgCodeStart, False)
      Me.txtSpgCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSpgCodeStart.TabIndex = 5
      Me.txtSpgCodeStart.Text = ""
      '
      'lblSpgStart
      '
      Me.lblSpgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSpgStart.ForeColor = System.Drawing.Color.Black
      Me.lblSpgStart.Location = New System.Drawing.Point(8, 24)
      Me.lblSpgStart.Name = "lblSpgStart"
      Me.lblSpgStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSpgStart.TabIndex = 28
      Me.lblSpgStart.Text = "กลุ่มผู้รับเหมา"
      Me.lblSpgStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSupplierGroupName
      '
      Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
      Me.txtSupplierGroupName.Location = New System.Drawing.Point(224, 24)
      Me.txtSupplierGroupName.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtSupplierGroupName, "")
      Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
      Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
      Me.txtSupplierGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
      Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
      Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
      Me.txtSupplierGroupName.TabIndex = 29
      Me.txtSupplierGroupName.Text = ""
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
      Me.btnCCCodeStart.Location = New System.Drawing.Point(200, 96)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 12
      Me.btnCCCodeStart.TabStop = False
      Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(104, 96)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 11
      Me.txtCCCodeStart.Text = ""
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(8, 96)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(88, 18)
      Me.lblCCStart.TabIndex = 24
      Me.lblCCStart.Text = "Cost Center"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(224, 96)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
      Me.txtCostCenterName.TabIndex = 25
      Me.txtCostCenterName.Text = ""
      '
      'btnSuppliEndFind
      '
      Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliEndFind.Image = CType(resources.GetObject("btnSuppliEndFind.Image"), System.Drawing.Image)
      Me.btnSuppliEndFind.Location = New System.Drawing.Point(360, 72)
      Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
      Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliEndFind.TabIndex = 10
      Me.btnSuppliEndFind.TabStop = False
      Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuppliCodeEnd
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(264, 72)
      Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
      Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeEnd.TabIndex = 9
      Me.txtSuppliCodeEnd.Text = ""
      '
      'lblSubcontratorEnd
      '
      Me.lblSubcontratorEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubcontratorEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSubcontratorEnd.Location = New System.Drawing.Point(232, 72)
      Me.lblSubcontratorEnd.Name = "lblSubcontratorEnd"
      Me.lblSubcontratorEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSubcontratorEnd.TabIndex = 9
      Me.lblSubcontratorEnd.Text = "ถึง"
      Me.lblSubcontratorEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSuppliStartFind
      '
      Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliStartFind.Image = CType(resources.GetObject("btnSuppliStartFind.Image"), System.Drawing.Image)
      Me.btnSuppliStartFind.Location = New System.Drawing.Point(200, 72)
      Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
      Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliStartFind.TabIndex = 8
      Me.btnSuppliStartFind.TabStop = False
      Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuppliCodeStart
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.txtSuppliCodeStart.Location = New System.Drawing.Point(104, 72)
      Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
      Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
      Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtSuppliCodeStart.TabIndex = 7
      Me.txtSuppliCodeStart.Text = ""
      '
      'lblSubcontratorStart
      '
      Me.lblSubcontratorStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubcontratorStart.ForeColor = System.Drawing.Color.Black
      Me.lblSubcontratorStart.Location = New System.Drawing.Point(8, 72)
      Me.lblSubcontratorStart.Name = "lblSubcontratorStart"
      Me.lblSubcontratorStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSubcontratorStart.TabIndex = 6
      Me.lblSubcontratorStart.Text = "Start Supplier:"
      Me.lblSubcontratorStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkShowDetail
      '
      Me.chkShowDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowDetail.Location = New System.Drawing.Point(104, 144)
      Me.chkShowDetail.Name = "chkShowDetail"
      Me.chkShowDetail.Size = New System.Drawing.Size(128, 24)
      Me.chkShowDetail.TabIndex = 31
      Me.chkShowDetail.Text = "Show Detail"
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(520, 216)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(440, 216)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'RptSCManagementFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptSCManagementFilterSubPanel"
      Me.Size = New System.Drawing.Size(624, 264)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grWbsDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.lblSpgStart}") '"กลุ่มผู้รับเหมา"
            Me.chkIncludeSCGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.chkIncludeSCGroup}") '"รวมกลุ่มผู้รับเหมา"
            Me.lblSubcontratorStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.lblSubcontratorStart}") '"กลุ่มผู้รับเหมา"
            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.lblCCStart}") '"Cost Center"
            Me.chkIncludeChildCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.chkIncludeChildCC}") '"รวม Cost Center ลูก"
            Me.chkShowDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.chkShowDetail}") '"แสดงรายละเอียด"
            Me.chkNoDigit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.chkNoDigit}") '"ไม่แสดงทศนิยม"
            Me.grWbsDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.grWbsDetail}") '"รวม Budget ตาม"
            Me.chkMat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.chkMat}")
            Me.chkLab.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.chkLab}")
            Me.chkEq.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.chkEq}")

            'Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.lblSuppliStart}")
            'Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            ' Global {ถึง}
            'Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            'Me.Validator.SetDisplayName(txtSuppliCodeEnd, lblSuppliEnd.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.grbDetail}")


            
        End Sub
#End Region

#Region "Member"
        Private m_suppliergroup As SupplierGroup
        Private m_supplierstart As Supplier
        Private m_supplierend As Supplier

        Private m_cc As Costcenter

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Public Property SupplierGroup() As SupplierGroup
            Get
                Return m_suppliergroup
            End Get
            Set(ByVal Value As SupplierGroup)
                m_suppliergroup = Value
            End Set
        End Property
        Public Property SupplierStart() As Supplier
            Get
                Return m_supplierstart
            End Get
            Set(ByVal Value As Supplier)
                m_supplierstart = Value
            End Set
        End Property
        Public Property SupplierEnd() As Supplier
            Get
                Return m_supplierend
            End Get
            Set(ByVal Value As Supplier)
                m_supplierend = Value
            End Set
        End Property
        Public Property Costcenter() As Costcenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As Costcenter)
                m_cc = Value
            End Set
        End Property
        Public ReadOnly Property IncludedBudgetType() As String
            Get
                Dim m_include As String = ""
                If chkMat.Checked Then
                    m_include &= "M"
                End If
                If chkLab.Checked Then
                    m_include &= "L"
                End If
                If chkEq.Checked Then
                    m_include &= "E"
                End If
                Return m_include
            End Get
        End Property
        Public ReadOnly Property ShowDetail() As Byte
            Get
                If chkShowDetail.Checked Then
                    Return 1
                Else
                    Return 0
                End If
            End Get
        End Property
        Public ReadOnly Property Nodigit() As Boolean
            Get
                If chkNoDigit.Checked Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
#End Region

#Region "Methods"

        Private Sub Initialize()
            ClearCriterias()
        End Sub

        Private Sub ClearCriterias()
            For Each grbCtrl As Control In grbMaster.Controls
                If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        ElseIf TypeOf Ctrl Is CheckBox Then
                            CType(Ctrl, CheckBox).Checked = False
                        End If
                    Next
                End If
            Next

            Me.Costcenter = New Costcenter

            Me.SupplierGroup = New SupplierGroup

            Me.SupplierStart = New Supplier
            Me.SupplierEnd = New Supplier
            Me.chkLab.Checked = True

        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(11) As Filter
            arr(0) = New Filter("SubcontractorGroupCode", IIf(txtSpgCodeStart.TextLength > 0, txtSpgCodeStart.Text, DBNull.Value))
            arr(1) = New Filter("SubcontractorCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(2) = New Filter("SubcontractorCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(3) = New Filter("cc", Me.ValidIdOrDBNull(m_cc))
            arr(4) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(5) = New Filter("ChildCCIncluded", Me.chkIncludeChildCC.Checked)
            arr(6) = New Filter("ChildSubcontractorGroupIncluded", Me.chkIncludeSCGroup.Checked)
            'arr(7) = New Filter("SummaryType", Me.IncludedBudgetType)
            arr(7) = New Filter("ShowDetail", Me.ShowDetail)
            arr(8) = New Filter("Nodigit", Me.Nodigit)
            arr(9) = New Filter("ShowMat", IIf(Me.chkMat.Checked, 1, 0))
            arr(10) = New Filter("ShowLab", IIf(Me.chkLab.Checked, 1, 0))
            arr(11) = New Filter("ShowEq", IIf(Me.chkEq.Checked, 1, 0))

            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region " IReportFilterSubPanel "
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            ''Month
            'dpi = New DocPrintingItem
            'dpi.Mapping = "Month"
            'dpi.Value = "" 'Me.cmbMonth.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''Year
            'dpi = New DocPrintingItem
            'dpi.Mapping = "Year"
            'dpi.Value = "" 'Me.cmbYear.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            'docdate start
            'dpi = New DocPrintingItem
            'dpi.Mapping = "docdatestart"
            'dpi.Value = Me.txtDocDateStart.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            'docdate end
            'dpi = New DocPrintingItem
            'dpi.Mapping = "docdateend"
            'dpi.Value = Me.txtDocDateEnd.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            'supplier group
            dpi = New DocPrintingItem
            dpi.Mapping = "suppliergroup"
            dpi.Value = Me.txtSpgCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'supplier start
            dpi = New DocPrintingItem
            dpi.Mapping = "supplierstart"
            dpi.Value = Me.txtSuppliCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'supplier end
            dpi = New DocPrintingItem
            dpi.Mapping = "supplierend"
            dpi.Value = Me.txtSuppliCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterStart
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterStart"
            dpi.Value = Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CheckBox ChildCostCenterInclude
            If Me.chkIncludeChildCC.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "childCCincluded"
                dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.ChildCC}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CheckBox ChildSupplierGroupInclude
            If Me.chkIncludeSCGroup.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "childSupplierGroupincluded"
                dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.ChildSupplierGroup}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CheckBox Included Budget Type
            If Me.chkMat.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "IncludedMatBudget"
                dpi.Value = "P" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.IncludedMatBudget}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If
            If Me.chkLab.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "IncludedLabBudget"
                dpi.Value = "P" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.IncludedMatBudget}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If
            If Me.chkEq.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "IncludedEqBudget"
                dpi.Value = "P" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.IncludedMatBudget}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CheckBox Show Detail
            If Me.chkShowDetail.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "ShowDetail"
                dpi.Value = "P" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.ShowDetail}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CheckBox Don't Show Digit
            If Me.chkShowDetail.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "nodigit"
                dpi.Value = "P" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagementFilterSubPanel.nodigit}")
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click

            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtsupplicodestart", "txtsupplicodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Costcenter
                If data.GetDataPresent((New Costcenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccodestart", "txtcccodeend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtsupplicodestart"
                            Me.SetSupplierStartDialog(entity)

                        Case "txtsupplicodeend"
                            Me.SetSupplierEndDialog(entity)

                    End Select
                End If
            End If
            ' Costcenter
            If data.GetDataPresent((New Costcenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
                Dim entity As New Costcenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercodestart"
                            Me.SetCCCodeStartDialog(entity)

                        Case "txtcostcentercodeend"
                            Me.SetCCCodeStartDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsupplistartfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

                Case "btnsuppliendfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

            End Select
        End Sub
        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeStart.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)
        End Sub
        Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeEnd.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        ' SupplierGroup
        Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnspgcodestart"
                    myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSpgCodeStartDialog)
            End Select
        End Sub
        Private Sub SetSpgCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtSpgCodeStart.Text = e.Code
            SupplierGroup.GetSupplierGroup(txtSpgCodeStart, txtSupplierGroupName, m_suppliergroup, True)
        End Sub
#End Region

    End Class
End Namespace

