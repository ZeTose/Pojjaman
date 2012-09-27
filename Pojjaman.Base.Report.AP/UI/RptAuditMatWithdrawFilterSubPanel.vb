Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptAuditMatWithdrawFilterSubPanel
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
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents btnCostcenterCodeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents TxtCostcenterCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblCostcenterEnd As System.Windows.Forms.Label
        Friend WithEvents btnCostcenterCodeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents TxtCostcenterCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCostcenterStart As System.Windows.Forms.Label
        Friend WithEvents btnEmpEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtEmpCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblEmpEnd As System.Windows.Forms.Label
        Friend WithEvents btnEmpStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtEmpCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblEmpStart As System.Windows.Forms.Label
        Friend WithEvents ibtnPRCodeEnd As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPRCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblPRCodeEnd As System.Windows.Forms.Label
        Friend WithEvents ibtnPRStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPRStart As System.Windows.Forms.TextBox
        Friend WithEvents lblPRSart As System.Windows.Forms.Label
        Friend WithEvents chkDontCarePR As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptAuditMatWithdrawFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtTemp = New System.Windows.Forms.TextBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkDontCarePR = New System.Windows.Forms.CheckBox
      Me.ibtnPRCodeEnd = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtPRCodeEnd = New System.Windows.Forms.TextBox
      Me.lblPRCodeEnd = New System.Windows.Forms.Label
      Me.ibtnPRStart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtPRStart = New System.Windows.Forms.TextBox
      Me.lblPRSart = New System.Windows.Forms.Label
      Me.btnCostcenterCodeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.TxtCostcenterCodeEnd = New System.Windows.Forms.TextBox
      Me.lblCostcenterEnd = New System.Windows.Forms.Label
      Me.btnCostcenterCodeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.TxtCostcenterCodeStart = New System.Windows.Forms.TextBox
      Me.lblCostcenterStart = New System.Windows.Forms.Label
      Me.btnEmpEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEmpCodeEnd = New System.Windows.Forms.TextBox
      Me.lblEmpEnd = New System.Windows.Forms.Label
      Me.btnEmpStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtEmpCodeStart = New System.Windows.Forms.TextBox
      Me.lblEmpStart = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
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
      Me.grbMaster.Size = New System.Drawing.Size(456, 200)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(464, 32)
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
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.Controls.Add(Me.chkDontCarePR)
      Me.grbDetail.Controls.Add(Me.ibtnPRCodeEnd)
      Me.grbDetail.Controls.Add(Me.txtPRCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblPRCodeEnd)
      Me.grbDetail.Controls.Add(Me.ibtnPRStart)
      Me.grbDetail.Controls.Add(Me.txtPRStart)
      Me.grbDetail.Controls.Add(Me.lblPRSart)
      Me.grbDetail.Controls.Add(Me.btnCostcenterCodeEndFind)
      Me.grbDetail.Controls.Add(Me.TxtCostcenterCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblCostcenterEnd)
      Me.grbDetail.Controls.Add(Me.btnCostcenterCodeStartFind)
      Me.grbDetail.Controls.Add(Me.TxtCostcenterCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCostcenterStart)
      Me.grbDetail.Controls.Add(Me.btnEmpEndFind)
      Me.grbDetail.Controls.Add(Me.txtEmpCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblEmpEnd)
      Me.grbDetail.Controls.Add(Me.btnEmpStartFind)
      Me.grbDetail.Controls.Add(Me.txtEmpCodeStart)
      Me.grbDetail.Controls.Add(Me.lblEmpStart)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(424, 144)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'chkDontCarePR
      '
      Me.chkDontCarePR.Location = New System.Drawing.Point(128, 112)
      Me.chkDontCarePR.Name = "chkDontCarePR"
      Me.chkDontCarePR.TabIndex = 18
      Me.chkDontCarePR.Text = "ไม่แสดง PR"
      '
      'ibtnPRCodeEnd
      '
      Me.ibtnPRCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnPRCodeEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnPRCodeEnd.Image = CType(resources.GetObject("ibtnPRCodeEnd.Image"), System.Drawing.Image)
      Me.ibtnPRCodeEnd.Location = New System.Drawing.Point(384, 64)
      Me.ibtnPRCodeEnd.Name = "ibtnPRCodeEnd"
      Me.ibtnPRCodeEnd.Size = New System.Drawing.Size(24, 22)
      Me.ibtnPRCodeEnd.TabIndex = 17
      Me.ibtnPRCodeEnd.TabStop = False
      Me.ibtnPRCodeEnd.ThemedImage = CType(resources.GetObject("ibtnPRCodeEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtPRCodeEnd
      '
      Me.Validator.SetDataType(Me.txtPRCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPRCodeEnd, "")
      Me.txtPRCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPRCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPRCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPRCodeEnd, System.Drawing.Color.Empty)
      Me.txtPRCodeEnd.Location = New System.Drawing.Point(288, 64)
      Me.Validator.SetMaxValue(Me.txtPRCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtPRCodeEnd, "")
      Me.txtPRCodeEnd.Name = "txtPRCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtPRCodeEnd, "")
      Me.Validator.SetRequired(Me.txtPRCodeEnd, False)
      Me.txtPRCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtPRCodeEnd.TabIndex = 5
      Me.txtPRCodeEnd.Text = ""
      '
      'lblPRCodeEnd
      '
      Me.lblPRCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPRCodeEnd.ForeColor = System.Drawing.Color.Black
      Me.lblPRCodeEnd.Location = New System.Drawing.Point(256, 64)
      Me.lblPRCodeEnd.Name = "lblPRCodeEnd"
      Me.lblPRCodeEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblPRCodeEnd.TabIndex = 14
      Me.lblPRCodeEnd.Text = "ถึง"
      Me.lblPRCodeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnPRStart
      '
      Me.ibtnPRStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnPRStart.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnPRStart.Image = CType(resources.GetObject("ibtnPRStart.Image"), System.Drawing.Image)
      Me.ibtnPRStart.Location = New System.Drawing.Point(224, 64)
      Me.ibtnPRStart.Name = "ibtnPRStart"
      Me.ibtnPRStart.Size = New System.Drawing.Size(24, 22)
      Me.ibtnPRStart.TabIndex = 11
      Me.ibtnPRStart.TabStop = False
      Me.ibtnPRStart.ThemedImage = CType(resources.GetObject("ibtnPRStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtPRStart
      '
      Me.Validator.SetDataType(Me.txtPRStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPRStart, "")
      Me.txtPRStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPRStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPRStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPRStart, System.Drawing.Color.Empty)
      Me.txtPRStart.Location = New System.Drawing.Point(128, 64)
      Me.Validator.SetMaxValue(Me.txtPRStart, "")
      Me.Validator.SetMinValue(Me.txtPRStart, "")
      Me.txtPRStart.Name = "txtPRStart"
      Me.Validator.SetRegularExpression(Me.txtPRStart, "")
      Me.Validator.SetRequired(Me.txtPRStart, False)
      Me.txtPRStart.Size = New System.Drawing.Size(96, 21)
      Me.txtPRStart.TabIndex = 4
      Me.txtPRStart.Text = ""
      '
      'lblPRSart
      '
      Me.lblPRSart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPRSart.ForeColor = System.Drawing.Color.Black
      Me.lblPRSart.Location = New System.Drawing.Point(8, 64)
      Me.lblPRSart.Name = "lblPRSart"
      Me.lblPRSart.Size = New System.Drawing.Size(112, 18)
      Me.lblPRSart.TabIndex = 8
      Me.lblPRSart.Text = "ตั้งแต่ PR"
      Me.lblPRSart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCostcenterCodeEndFind
      '
      Me.btnCostcenterCodeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterCodeEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostcenterCodeEndFind.Image = CType(resources.GetObject("btnCostcenterCodeEndFind.Image"), System.Drawing.Image)
      Me.btnCostcenterCodeEndFind.Location = New System.Drawing.Point(384, 40)
      Me.btnCostcenterCodeEndFind.Name = "btnCostcenterCodeEndFind"
      Me.btnCostcenterCodeEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCostcenterCodeEndFind.TabIndex = 16
      Me.btnCostcenterCodeEndFind.TabStop = False
      Me.btnCostcenterCodeEndFind.ThemedImage = CType(resources.GetObject("btnCostcenterCodeEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'TxtCostcenterCodeEnd
      '
      Me.Validator.SetDataType(Me.TxtCostcenterCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtCostcenterCodeEnd, "")
      Me.TxtCostcenterCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.TxtCostcenterCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.TxtCostcenterCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.TxtCostcenterCodeEnd, System.Drawing.Color.Empty)
      Me.TxtCostcenterCodeEnd.Location = New System.Drawing.Point(288, 40)
      Me.Validator.SetMaxValue(Me.TxtCostcenterCodeEnd, "")
      Me.Validator.SetMinValue(Me.TxtCostcenterCodeEnd, "")
      Me.TxtCostcenterCodeEnd.Name = "TxtCostcenterCodeEnd"
      Me.Validator.SetRegularExpression(Me.TxtCostcenterCodeEnd, "")
      Me.Validator.SetRequired(Me.TxtCostcenterCodeEnd, False)
      Me.TxtCostcenterCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.TxtCostcenterCodeEnd.TabIndex = 3
      Me.TxtCostcenterCodeEnd.Text = ""
      '
      'lblCostcenterEnd
      '
      Me.lblCostcenterEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostcenterEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCostcenterEnd.Location = New System.Drawing.Point(256, 40)
      Me.lblCostcenterEnd.Name = "lblCostcenterEnd"
      Me.lblCostcenterEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCostcenterEnd.TabIndex = 13
      Me.lblCostcenterEnd.Text = "ถึง"
      Me.lblCostcenterEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnCostcenterCodeStartFind
      '
      Me.btnCostcenterCodeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterCodeStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostcenterCodeStartFind.Image = CType(resources.GetObject("btnCostcenterCodeStartFind.Image"), System.Drawing.Image)
      Me.btnCostcenterCodeStartFind.Location = New System.Drawing.Point(224, 40)
      Me.btnCostcenterCodeStartFind.Name = "btnCostcenterCodeStartFind"
      Me.btnCostcenterCodeStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCostcenterCodeStartFind.TabIndex = 10
      Me.btnCostcenterCodeStartFind.TabStop = False
      Me.btnCostcenterCodeStartFind.ThemedImage = CType(resources.GetObject("btnCostcenterCodeStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'TxtCostcenterCodeStart
      '
      Me.Validator.SetDataType(Me.TxtCostcenterCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtCostcenterCodeStart, "")
      Me.TxtCostcenterCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.TxtCostcenterCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.TxtCostcenterCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.TxtCostcenterCodeStart, System.Drawing.Color.Empty)
      Me.TxtCostcenterCodeStart.Location = New System.Drawing.Point(128, 40)
      Me.Validator.SetMaxValue(Me.TxtCostcenterCodeStart, "")
      Me.Validator.SetMinValue(Me.TxtCostcenterCodeStart, "")
      Me.TxtCostcenterCodeStart.Name = "TxtCostcenterCodeStart"
      Me.Validator.SetRegularExpression(Me.TxtCostcenterCodeStart, "")
      Me.Validator.SetRequired(Me.TxtCostcenterCodeStart, False)
      Me.TxtCostcenterCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.TxtCostcenterCodeStart.TabIndex = 2
      Me.TxtCostcenterCodeStart.Text = ""
      '
      'lblCostcenterStart
      '
      Me.lblCostcenterStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostcenterStart.ForeColor = System.Drawing.Color.Black
      Me.lblCostcenterStart.Location = New System.Drawing.Point(8, 40)
      Me.lblCostcenterStart.Name = "lblCostcenterStart"
      Me.lblCostcenterStart.Size = New System.Drawing.Size(112, 18)
      Me.lblCostcenterStart.TabIndex = 7
      Me.lblCostcenterStart.Text = "ตั้งแต่ Cost Center"
      Me.lblCostcenterStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnEmpEndFind
      '
      Me.btnEmpEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmpEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmpEndFind.Image = CType(resources.GetObject("btnEmpEndFind.Image"), System.Drawing.Image)
      Me.btnEmpEndFind.Location = New System.Drawing.Point(384, 16)
      Me.btnEmpEndFind.Name = "btnEmpEndFind"
      Me.btnEmpEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEmpEndFind.TabIndex = 15
      Me.btnEmpEndFind.TabStop = False
      Me.btnEmpEndFind.ThemedImage = CType(resources.GetObject("btnEmpEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEmpCodeEnd
      '
      Me.Validator.SetDataType(Me.txtEmpCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmpCodeEnd, "")
      Me.txtEmpCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmpCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmpCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmpCodeEnd, System.Drawing.Color.Empty)
      Me.txtEmpCodeEnd.Location = New System.Drawing.Point(288, 16)
      Me.Validator.SetMaxValue(Me.txtEmpCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtEmpCodeEnd, "")
      Me.txtEmpCodeEnd.Name = "txtEmpCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtEmpCodeEnd, "")
      Me.Validator.SetRequired(Me.txtEmpCodeEnd, False)
      Me.txtEmpCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtEmpCodeEnd.TabIndex = 1
      Me.txtEmpCodeEnd.Text = ""
      '
      'lblEmpEnd
      '
      Me.lblEmpEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEmpEnd.ForeColor = System.Drawing.Color.Black
      Me.lblEmpEnd.Location = New System.Drawing.Point(256, 16)
      Me.lblEmpEnd.Name = "lblEmpEnd"
      Me.lblEmpEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblEmpEnd.TabIndex = 12
      Me.lblEmpEnd.Text = "ถึง"
      Me.lblEmpEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnEmpStartFind
      '
      Me.btnEmpStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnEmpStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnEmpStartFind.Image = CType(resources.GetObject("btnEmpStartFind.Image"), System.Drawing.Image)
      Me.btnEmpStartFind.Location = New System.Drawing.Point(224, 16)
      Me.btnEmpStartFind.Name = "btnEmpStartFind"
      Me.btnEmpStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnEmpStartFind.TabIndex = 9
      Me.btnEmpStartFind.TabStop = False
      Me.btnEmpStartFind.ThemedImage = CType(resources.GetObject("btnEmpStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEmpCodeStart
      '
      Me.Validator.SetDataType(Me.txtEmpCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEmpCodeStart, "")
      Me.txtEmpCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEmpCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEmpCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtEmpCodeStart, System.Drawing.Color.Empty)
      Me.txtEmpCodeStart.Location = New System.Drawing.Point(128, 16)
      Me.Validator.SetMaxValue(Me.txtEmpCodeStart, "")
      Me.Validator.SetMinValue(Me.txtEmpCodeStart, "")
      Me.txtEmpCodeStart.Name = "txtEmpCodeStart"
      Me.Validator.SetRegularExpression(Me.txtEmpCodeStart, "")
      Me.Validator.SetRequired(Me.txtEmpCodeStart, False)
      Me.txtEmpCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtEmpCodeStart.TabIndex = 0
      Me.txtEmpCodeStart.Text = ""
      '
      'lblEmpStart
      '
      Me.lblEmpStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEmpStart.ForeColor = System.Drawing.Color.Black
      Me.lblEmpStart.Location = New System.Drawing.Point(8, 16)
      Me.lblEmpStart.Name = "lblEmpStart"
      Me.lblEmpStart.Size = New System.Drawing.Size(112, 18)
      Me.lblEmpStart.TabIndex = 6
      Me.lblEmpStart.Text = "Supplier:"
      Me.lblEmpStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(368, 168)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(288, 168)
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
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(288, 88)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 23
      Me.txtDocDateEnd.Text = ""
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(128, 88)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 20
      Me.txtDocDateStart.Text = ""
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(128, 88)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 21
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(288, 88)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 24
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(48, 88)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(72, 18)
      Me.lblDocDateStart.TabIndex = 19
      Me.lblDocDateStart.Text = "ตั้งแต่ PR วันที่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(256, 88)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 22
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'RptAuditMatWithdrawFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptAuditMatWithdrawFilterSubPanel"
      Me.Size = New System.Drawing.Size(472, 216)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblEmpStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAuditMatWithdrawFilterSubPanel.lblEmpStart}")
            Me.Validator.SetDisplayName(txtEmpCodeStart, lblEmpStart.Text)

            Me.lblCostcenterStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAuditMatWithdrawFilterSubPanel.lblCostcenterStart}")
            Me.Validator.SetDisplayName(TxtCostcenterCodeStart, lblCostcenterStart.Text)
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptStockCardMatFilterSubPanel.lbDate}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)
            ' Global {ถึง}
            Me.lblEmpEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtEmpCodeStart, lblEmpStart.Text)
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            Me.lblCostcenterEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(TxtCostcenterCodeEnd, lblCostcenterEnd.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAuditMatWithdrawFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAuditMatWithdrawFilterSubPanel.grbDetail}")
            Me.lblPRSart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAuditMatWithdrawFilterSubPanel.lblPRSart}")
            Me.lblPRCodeEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblEmpEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.chkDontCarePR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptAuditMatWithdrawFilterSubPanel.chkDontCarePR}")
        End Sub
#End Region

#Region "Member"
        Private m_employee As Employee
        Private m_cc As Costcenter

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
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
        Public Property Employee() As Employee
            Get
                Return m_employee
            End Get
            Set(ByVal Value As Employee)
                m_employee = Value
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
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
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
                        End If
                    Next
                End If
            Next

            Me.Employee = New Employee
            Me.Costcenter = New Costcenter

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
      Dim arr(9) As Filter
            arr(0) = New Filter("EmployeeStart", IIf(txtEmpCodeStart.TextLength > 0, txtEmpCodeStart.Text, DBNull.Value))
            arr(1) = New Filter("EmployeeEnd", IIf(txtEmpCodeEnd.TextLength > 0, txtEmpCodeEnd.Text, DBNull.Value))
            arr(2) = New Filter("CostcenterStart", IIf(TxtCostcenterCodeStart.TextLength > 0, TxtCostcenterCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("CostcenterEnd", IIf(TxtCostcenterCodeEnd.TextLength > 0, TxtCostcenterCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("PRCodeStart", IIf(txtPRStart.TextLength > 0, txtPRStart.Text, DBNull.Value))
            arr(5) = New Filter("PRCodeEnd", IIf(txtPRCodeEnd.TextLength > 0, txtPRCodeEnd.Text, DBNull.Value))
            arr(6) = New Filter("DontCarePR", Me.chkDontCarePR.Checked)
            arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(8) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(9) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))

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

#Region "IReportFilterSubPanel"
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

      'Docdate Start
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate End
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

            'Employee Start
            dpi = New DocPrintingItem
            dpi.Mapping = "EmployeeStart"
            dpi.Value = Me.txtEmpCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Employee End
            dpi = New DocPrintingItem
            dpi.Mapping = "EmployeeEnd"
            dpi.Value = Me.txtEmpCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Cost Center Start
            dpi = New DocPrintingItem
            dpi.Mapping = "CostcenterStart"
            dpi.Value = Me.TxtCostcenterCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Cost Center End
            dpi = New DocPrintingItem
            dpi.Mapping = "CostcenterEnd"
            dpi.Value = Me.TxtCostcenterCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            ''today
            'dpi = New DocPrintingItem
            'dpi.Mapping = "today"
            'dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnEmpStartFind.Click, AddressOf Me.btnEmployeeFind_Click
            AddHandler btnEmpEndFind.Click, AddressOf Me.btnEmployeeFind_Click

            AddHandler btnCostcenterCodeStartFind.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler btnCostcenterCodeEndFind.Click, AddressOf Me.btnCostcenterFind_Click

            AddHandler TxtCostcenterCodeStart.Validated, AddressOf Me.ChangeProperty
            AddHandler TxtCostcenterCodeEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler ibtnPRStart.Click, AddressOf btnPRFind_Click
            AddHandler ibtnPRCodeEnd.Click, AddressOf btnPRFind_Click

            'AddHandler txtSuppliCodeStart.Validated, AddressOf Me.ChangeProperty
            'AddHandler txtSuppliCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcostcentercodestart"
                    Costcenter.GetCostCenter(TxtCostcenterCodeStart, txtTemp, Me.Costcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                Case "txtcostcentercodeend"
                    Costcenter.GetCostCenter(TxtCostcenterCodeEnd, txtTemp, Me.Costcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

          'Case "txtsupplicodestart"
          '  Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)

          'Case "txtsupplicodeend"
          '  Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)

        Case "dtpdocdatestart"
          If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.DocDateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          Else
            Me.dtpDocDateStart.Value = Date.Now
            Me.DocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False

        Case Else

      End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' Employee
                If data.GetDataPresent((New Employee).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtempcodestart", "txtempcodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Costcenter
                If data.GetDataPresent((New Costcenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcostcentercodestart", "txtcostcentercodeend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            ' Employee
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtempcodestart"
                            Me.SetEmployeeStartDialog(entity)

                        Case "txtempcodeend"
                            Me.SetEmployeeEndDialog(entity)

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
                            Me.SetCostcenterStartDialog(entity)

                        Case "txtcostcentercodeend"
                            Me.SetCostcenterStartDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnPRFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim tmppr As New PR
            Select Case CType(sender, Control).Name.ToLower
                Case "ibtnprstart"
                    myEntityPanelService.OpenListDialog(tmppr, AddressOf SetPRStartDialog)

                Case "ibtnprcodeend"
                    myEntityPanelService.OpenListDialog(tmppr, AddressOf SetPREndDialog)

            End Select
        End Sub
        Private Sub SetPRStartDialog(ByVal e As ISimpleEntity)
            Me.txtPRStart.Text = e.Code
            'PR.GetPR(txtEmpCodeStart, txtTemp, New PR)
        End Sub
        Private Sub SetPREndDialog(ByVal e As ISimpleEntity)
            Me.txtPRCodeEnd.Text = e.Code
            'PR.GetPR(txtEmpCodeEnd, txtTemp, New PR)
        End Sub

        ' Employee
        Private Sub btnEmployeeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnempstartfind"
                    myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeStartDialog)

                Case "btnempendfind"
                    myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeEndDialog)

            End Select
        End Sub
        Private Sub SetEmployeeStartDialog(ByVal e As ISimpleEntity)
            Me.txtEmpCodeStart.Text = e.Code
            Employee.GetEmployee(txtEmpCodeStart, txtTemp, Me.Employee)
        End Sub
        Private Sub SetEmployeeEndDialog(ByVal e As ISimpleEntity)
            Me.txtEmpCodeEnd.Text = e.Code
            Employee.GetEmployee(txtEmpCodeEnd, txtTemp, Me.Employee)
        End Sub

        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncostcentercodestartfind"
                    myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCostcenterStartDialog)

                Case "btncostcentercodeendfind"
                    myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCostcenterEndDialog)

            End Select
        End Sub
        Private Sub SetCostcenterStartDialog(ByVal e As ISimpleEntity)
            Me.TxtCostcenterCodeStart.Text = e.Code
            Costcenter.GetCostCenter(TxtCostcenterCodeStart, txtTemp, Me.Costcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub SetCostcenterEndDialog(ByVal e As ISimpleEntity)
            Me.TxtCostcenterCodeEnd.Text = e.Code
            Costcenter.GetCostCenter(TxtCostcenterCodeEnd, txtTemp, Me.Costcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
#End Region


  End Class
End Namespace

