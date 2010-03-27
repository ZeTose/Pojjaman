Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class DepreTransferDetail
    Inherits AbstractEntityDetailPanelView
    Implements IHelperCapable, IReversibleEntityProperty, IValidatable


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
    Friend WithEvents grb As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents grbTransIN As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnPersonInFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnPersonInEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCInFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCInEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCInName As System.Windows.Forms.TextBox
    Friend WithEvents txtPersonInName As System.Windows.Forms.TextBox
    Friend WithEvents txtCCInCode As System.Windows.Forms.TextBox
    Friend WithEvents lblPersonIn As System.Windows.Forms.Label
    Friend WithEvents lblCCIn As System.Windows.Forms.Label
    Friend WithEvents txtPersonInCode As System.Windows.Forms.TextBox
    Friend WithEvents grbTransOut As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnPersonOutFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnPersonOutEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCOutFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCOutName As System.Windows.Forms.TextBox
    Friend WithEvents txtPersonOutCode As System.Windows.Forms.TextBox
    Friend WithEvents lblPersonOut As System.Windows.Forms.Label
    Friend WithEvents lblCCOut As System.Windows.Forms.Label
    Friend WithEvents btnCCOutEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCOutCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPersonOutName As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepreTransferDetail))
      Me.grb = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbTransIN = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnPersonInFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnPersonInEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCInFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCInEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCInName = New System.Windows.Forms.TextBox()
      Me.txtPersonInName = New System.Windows.Forms.TextBox()
      Me.txtCCInCode = New System.Windows.Forms.TextBox()
      Me.lblPersonIn = New System.Windows.Forms.Label()
      Me.lblCCIn = New System.Windows.Forms.Label()
      Me.txtPersonInCode = New System.Windows.Forms.TextBox()
      Me.grbTransOut = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnPersonOutFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnPersonOutEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCOutFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCOutName = New System.Windows.Forms.TextBox()
      Me.txtPersonOutCode = New System.Windows.Forms.TextBox()
      Me.lblPersonOut = New System.Windows.Forms.Label()
      Me.lblCCOut = New System.Windows.Forms.Label()
      Me.btnCCOutEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCOutCode = New System.Windows.Forms.TextBox()
      Me.txtPersonOutName = New System.Windows.Forms.TextBox()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grb.SuspendLayout()
      Me.grbTransIN.SuspendLayout()
      Me.grbTransOut.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grb
      '
      Me.grb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grb.Controls.Add(Me.grbTransIN)
      Me.grb.Controls.Add(Me.grbTransOut)
      Me.grb.Controls.Add(Me.btnOk)
      Me.grb.Controls.Add(Me.btnCancel)
      Me.grb.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grb.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grb.ForeColor = System.Drawing.Color.Blue
      Me.grb.Location = New System.Drawing.Point(8, 8)
      Me.grb.Name = "grb"
      Me.grb.Size = New System.Drawing.Size(408, 209)
      Me.grb.TabIndex = 0
      Me.grb.TabStop = False
      Me.grb.Text = "ข้อมูลโอนสินทรัพย์ : "
      '
      'grbTransIN
      '
      Me.grbTransIN.Controls.Add(Me.btnPersonInFind)
      Me.grbTransIN.Controls.Add(Me.btnPersonInEdit)
      Me.grbTransIN.Controls.Add(Me.btnCCInFind)
      Me.grbTransIN.Controls.Add(Me.btnCCInEdit)
      Me.grbTransIN.Controls.Add(Me.txtCCInName)
      Me.grbTransIN.Controls.Add(Me.txtPersonInName)
      Me.grbTransIN.Controls.Add(Me.txtCCInCode)
      Me.grbTransIN.Controls.Add(Me.lblPersonIn)
      Me.grbTransIN.Controls.Add(Me.lblCCIn)
      Me.grbTransIN.Controls.Add(Me.txtPersonInCode)
      Me.grbTransIN.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbTransIN.Location = New System.Drawing.Point(17, 97)
      Me.grbTransIN.Name = "grbTransIN"
      Me.grbTransIN.Size = New System.Drawing.Size(384, 71)
      Me.grbTransIN.TabIndex = 13
      Me.grbTransIN.TabStop = False
      Me.grbTransIN.Text = "โอนเข้า"
      '
      'btnPersonInFind
      '
      Me.btnPersonInFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPersonInFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPersonInFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPersonInFind.Location = New System.Drawing.Point(328, 40)
      Me.btnPersonInFind.Name = "btnPersonInFind"
      Me.btnPersonInFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPersonInFind.TabIndex = 8
      Me.btnPersonInFind.TabStop = False
      Me.btnPersonInFind.ThemedImage = CType(resources.GetObject("btnPersonInFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnPersonInEdit
      '
      Me.btnPersonInEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPersonInEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPersonInEdit.Location = New System.Drawing.Point(352, 40)
      Me.btnPersonInEdit.Name = "btnPersonInEdit"
      Me.btnPersonInEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnPersonInEdit.TabIndex = 9
      Me.btnPersonInEdit.TabStop = False
      Me.btnPersonInEdit.ThemedImage = CType(resources.GetObject("btnPersonInEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCInFind
      '
      Me.btnCCInFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCInFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCInFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCInFind.Location = New System.Drawing.Point(328, 16)
      Me.btnCCInFind.Name = "btnCCInFind"
      Me.btnCCInFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCCInFind.TabIndex = 3
      Me.btnCCInFind.TabStop = False
      Me.btnCCInFind.ThemedImage = CType(resources.GetObject("btnCCInFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCInEdit
      '
      Me.btnCCInEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCInEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCInEdit.Location = New System.Drawing.Point(352, 16)
      Me.btnCCInEdit.Name = "btnCCInEdit"
      Me.btnCCInEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCCInEdit.TabIndex = 4
      Me.btnCCInEdit.TabStop = False
      Me.btnCCInEdit.ThemedImage = CType(resources.GetObject("btnCCInEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCInName
      '
      Me.txtCCInName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCCInName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCInName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCCInName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCCInName, System.Drawing.Color.Empty)
      Me.txtCCInName.Location = New System.Drawing.Point(200, 16)
      Me.Validator.SetMinValue(Me.txtCCInName, "")
      Me.txtCCInName.Name = "txtCCInName"
      Me.txtCCInName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCCInName, "")
      Me.Validator.SetRequired(Me.txtCCInName, False)
      Me.txtCCInName.Size = New System.Drawing.Size(128, 21)
      Me.txtCCInName.TabIndex = 2
      Me.txtCCInName.TabStop = False
      '
      'txtPersonInName
      '
      Me.txtPersonInName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtPersonInName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPersonInName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPersonInName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPersonInName, System.Drawing.Color.Empty)
      Me.txtPersonInName.Location = New System.Drawing.Point(200, 40)
      Me.Validator.SetMinValue(Me.txtPersonInName, "")
      Me.txtPersonInName.Name = "txtPersonInName"
      Me.txtPersonInName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtPersonInName, "")
      Me.Validator.SetRequired(Me.txtPersonInName, False)
      Me.txtPersonInName.Size = New System.Drawing.Size(128, 21)
      Me.txtPersonInName.TabIndex = 7
      Me.txtPersonInName.TabStop = False
      '
      'txtCCInCode
      '
      Me.txtCCInCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCCInCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCInCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCCInCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCInCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCInCode, System.Drawing.Color.Empty)
      Me.txtCCInCode.Location = New System.Drawing.Point(136, 16)
      Me.txtCCInCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCCInCode, "")
      Me.txtCCInCode.Name = "txtCCInCode"
      Me.Validator.SetRegularExpression(Me.txtCCInCode, "")
      Me.Validator.SetRequired(Me.txtCCInCode, True)
      Me.txtCCInCode.Size = New System.Drawing.Size(64, 21)
      Me.txtCCInCode.TabIndex = 12
      '
      'lblPersonIn
      '
      Me.lblPersonIn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPersonIn.Location = New System.Drawing.Point(8, 40)
      Me.lblPersonIn.Name = "lblPersonIn"
      Me.lblPersonIn.Size = New System.Drawing.Size(128, 18)
      Me.lblPersonIn.TabIndex = 5
      Me.lblPersonIn.Text = "ผู้รับเข้า"
      Me.lblPersonIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCCIn
      '
      Me.lblCCIn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCIn.Location = New System.Drawing.Point(8, 16)
      Me.lblCCIn.Name = "lblCCIn"
      Me.lblCCIn.Size = New System.Drawing.Size(128, 18)
      Me.lblCCIn.TabIndex = 0
      Me.lblCCIn.Text = "Cost Center Transfer In"
      Me.lblCCIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPersonInCode
      '
      Me.txtPersonInCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtPersonInCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPersonInCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPersonInCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPersonInCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPersonInCode, System.Drawing.Color.Empty)
      Me.txtPersonInCode.Location = New System.Drawing.Point(136, 40)
      Me.txtPersonInCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtPersonInCode, "")
      Me.txtPersonInCode.Name = "txtPersonInCode"
      Me.Validator.SetRegularExpression(Me.txtPersonInCode, "")
      Me.Validator.SetRequired(Me.txtPersonInCode, False)
      Me.txtPersonInCode.Size = New System.Drawing.Size(64, 21)
      Me.txtPersonInCode.TabIndex = 13
      '
      'grbTransOut
      '
      Me.grbTransOut.Controls.Add(Me.btnPersonOutFind)
      Me.grbTransOut.Controls.Add(Me.btnPersonOutEdit)
      Me.grbTransOut.Controls.Add(Me.btnCCOutFind)
      Me.grbTransOut.Controls.Add(Me.txtCCOutName)
      Me.grbTransOut.Controls.Add(Me.txtPersonOutCode)
      Me.grbTransOut.Controls.Add(Me.lblPersonOut)
      Me.grbTransOut.Controls.Add(Me.lblCCOut)
      Me.grbTransOut.Controls.Add(Me.btnCCOutEdit)
      Me.grbTransOut.Controls.Add(Me.txtCCOutCode)
      Me.grbTransOut.Controls.Add(Me.txtPersonOutName)
      Me.grbTransOut.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbTransOut.Location = New System.Drawing.Point(17, 20)
      Me.grbTransOut.Name = "grbTransOut"
      Me.grbTransOut.Size = New System.Drawing.Size(384, 71)
      Me.grbTransOut.TabIndex = 12
      Me.grbTransOut.TabStop = False
      Me.grbTransOut.Text = "โอนออก"
      '
      'btnPersonOutFind
      '
      Me.btnPersonOutFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPersonOutFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPersonOutFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnPersonOutFind.Location = New System.Drawing.Point(328, 38)
      Me.btnPersonOutFind.Name = "btnPersonOutFind"
      Me.btnPersonOutFind.Size = New System.Drawing.Size(24, 23)
      Me.btnPersonOutFind.TabIndex = 8
      Me.btnPersonOutFind.TabStop = False
      Me.btnPersonOutFind.ThemedImage = CType(resources.GetObject("btnPersonOutFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnPersonOutEdit
      '
      Me.btnPersonOutEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnPersonOutEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnPersonOutEdit.Location = New System.Drawing.Point(352, 38)
      Me.btnPersonOutEdit.Name = "btnPersonOutEdit"
      Me.btnPersonOutEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnPersonOutEdit.TabIndex = 9
      Me.btnPersonOutEdit.TabStop = False
      Me.btnPersonOutEdit.ThemedImage = CType(resources.GetObject("btnPersonOutEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCOutFind
      '
      Me.btnCCOutFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCOutFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCOutFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCOutFind.Location = New System.Drawing.Point(328, 14)
      Me.btnCCOutFind.Name = "btnCCOutFind"
      Me.btnCCOutFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCCOutFind.TabIndex = 3
      Me.btnCCOutFind.TabStop = False
      Me.btnCCOutFind.ThemedImage = CType(resources.GetObject("btnCCOutFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCOutName
      '
      Me.txtCCOutName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCCOutName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCOutName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCCOutName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCCOutName, System.Drawing.Color.Empty)
      Me.txtCCOutName.Location = New System.Drawing.Point(200, 14)
      Me.Validator.SetMinValue(Me.txtCCOutName, "")
      Me.txtCCOutName.Name = "txtCCOutName"
      Me.txtCCOutName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCCOutName, "")
      Me.Validator.SetRequired(Me.txtCCOutName, False)
      Me.txtCCOutName.Size = New System.Drawing.Size(128, 21)
      Me.txtCCOutName.TabIndex = 2
      Me.txtCCOutName.TabStop = False
      '
      'txtPersonOutCode
      '
      Me.txtPersonOutCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtPersonOutCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPersonOutCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPersonOutCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtPersonOutCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtPersonOutCode, System.Drawing.Color.Empty)
      Me.txtPersonOutCode.Location = New System.Drawing.Point(136, 38)
      Me.txtPersonOutCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtPersonOutCode, "")
      Me.txtPersonOutCode.Name = "txtPersonOutCode"
      Me.Validator.SetRegularExpression(Me.txtPersonOutCode, "")
      Me.Validator.SetRequired(Me.txtPersonOutCode, False)
      Me.txtPersonOutCode.Size = New System.Drawing.Size(64, 21)
      Me.txtPersonOutCode.TabIndex = 11
      '
      'lblPersonOut
      '
      Me.lblPersonOut.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPersonOut.Location = New System.Drawing.Point(12, 40)
      Me.lblPersonOut.Name = "lblPersonOut"
      Me.lblPersonOut.Size = New System.Drawing.Size(120, 18)
      Me.lblPersonOut.TabIndex = 5
      Me.lblPersonOut.Text = "ผู้โอนออก"
      Me.lblPersonOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCCOut
      '
      Me.lblCCOut.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCOut.Location = New System.Drawing.Point(12, 16)
      Me.lblCCOut.Name = "lblCCOut"
      Me.lblCCOut.Size = New System.Drawing.Size(120, 18)
      Me.lblCCOut.TabIndex = 0
      Me.lblCCOut.Text = "Cost Center โอนออก"
      Me.lblCCOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCCOutEdit
      '
      Me.btnCCOutEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCOutEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCOutEdit.Location = New System.Drawing.Point(352, 14)
      Me.btnCCOutEdit.Name = "btnCCOutEdit"
      Me.btnCCOutEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCCOutEdit.TabIndex = 4
      Me.btnCCOutEdit.TabStop = False
      Me.btnCCOutEdit.ThemedImage = CType(resources.GetObject("btnCCOutEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCOutCode
      '
      Me.txtCCOutCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCCOutCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCOutCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCCOutCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCOutCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCOutCode, System.Drawing.Color.Empty)
      Me.txtCCOutCode.Location = New System.Drawing.Point(136, 14)
      Me.txtCCOutCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCCOutCode, "")
      Me.txtCCOutCode.Name = "txtCCOutCode"
      Me.Validator.SetRegularExpression(Me.txtCCOutCode, "")
      Me.Validator.SetRequired(Me.txtCCOutCode, True)
      Me.txtCCOutCode.Size = New System.Drawing.Size(64, 21)
      Me.txtCCOutCode.TabIndex = 10
      '
      'txtPersonOutName
      '
      Me.txtPersonOutName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtPersonOutName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPersonOutName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtPersonOutName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPersonOutName, System.Drawing.Color.Empty)
      Me.txtPersonOutName.Location = New System.Drawing.Point(200, 38)
      Me.Validator.SetMinValue(Me.txtPersonOutName, "")
      Me.txtPersonOutName.Name = "txtPersonOutName"
      Me.txtPersonOutName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtPersonOutName, "")
      Me.Validator.SetRequired(Me.txtPersonOutName, False)
      Me.txtPersonOutName.Size = New System.Drawing.Size(128, 21)
      Me.txtPersonOutName.TabIndex = 7
      Me.txtPersonOutName.TabStop = False
      '
      'btnOk
      '
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnOk.ForeColor = System.Drawing.Color.Black
      Me.btnOk.Location = New System.Drawing.Point(200, 174)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(96, 24)
      Me.btnOk.TabIndex = 33
      Me.btnOk.Text = "OK"
      '
      'btnCancel
      '
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.Black
      Me.btnCancel.Location = New System.Drawing.Point(304, 174)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(96, 24)
      Me.btnCancel.TabIndex = 34
      Me.btnCancel.TabStop = False
      Me.btnCancel.Text = "Cancel"
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'DepreTransferDetail
      '
      Me.Controls.Add(Me.grb)
      Me.Name = "DepreTransferDetail"
      Me.Size = New System.Drawing.Size(424, 225)
      Me.grb.ResumeLayout(False)
      Me.grbTransIN.ResumeLayout(False)
      Me.grbTransIN.PerformLayout()
      Me.grbTransOut.ResumeLayout(False)
      Me.grbTransOut.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SelLabelText "
    Public Overrides Sub SetLabelText()
      'lblSaleDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaleDate}")
      'Me.Validator.SetDisplayName(txtSaleDate, lblSaleDate.Text)

      'lblSalePrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSalePrice}")
      'Me.Validator.SetDisplayName(txtSalePrice, lblSalePrice.Text)

      'lblSaleDocCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaleDocCode}")
      'Me.Validator.SetDisplayName(txtSaleDocCode, lblSaleDocCode.Text)

      'lblSaleDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaleDocDate}")
      'Me.Validator.SetDisplayName(txtSaleDocDate, lblSaleDocDate.Text)

      'lblBuyer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblBuyer}")
      'Me.Validator.SetDisplayName(txtBuyer, lblBuyer.Text)

      'lblInsuranceCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsuranceCode}")
      'Me.Validator.SetDisplayName(txtInsurranceCode, lblInsuranceCode.Text)

      'lblSaftyCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaftyCode}")
      'Me.Validator.SetDisplayName(txtSaftyCode, lblSaftyCode.Text)

      'lblSaftyCompany.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblSaftyCompany}")
      'Me.Validator.SetDisplayName(txtSaftyCompany, lblSaftyCompany.Text)

      'lblInsurancePremium.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsurancePremium}")
      'Me.Validator.SetDisplayName(txtInsurrancePremium, lblInsurancePremium.Text)

      'lblInsuranceeAge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsuranceeAge}")
      'Me.Validator.SetDisplayName(txtInsurranceAge, lblInsuranceeAge.Text)

      'lblInsuranceStartDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsuranceStartDate}")
      'Me.Validator.SetDisplayName(txtInsurranceStartDate, lblInsuranceStartDate.Text)

      'lblInsuranceEndDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.lblInsuranceEndDate}")
      'Me.Validator.SetDisplayName(txtInsurranceEndDate, lblInsuranceEndDate.Text)

      '' Description
      'lblYear.Text = Me.StringParserService.Parse("${res:Global.YearText}")
      'lblCurrencyUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyText}")
      '' Button 
      'btnOk.Text = Me.StringParserService.Parse("${res:Global.OKButtonText}")
      'btnCancel.Text = Me.StringParserService.Parse("${res:Global.CancelButtonText}")

      '' GroupBox ...
      'grb.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.PrimaryGroupBoxControl}")
      'grbSaleDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.grbSaleDetail}")
      'grbInsurranceDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetAuxDetail.grbInsurranceDetail}")

      ' Trans out section
      Me.lblCCOut.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblCCOut}")
      Me.Validator.SetDisplayName(txtCCOutCode, lblCCOut.Text)

      Me.lblPersonOut.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblPersonOut}")
      Me.Validator.SetDisplayName(txtPersonOutCode, lblPersonOut.Text)

      'Trans in section
      Me.lblCCIn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblCCIn}")
      Me.Validator.SetDisplayName(txtCCInCode, lblCCIn.Text)

      Me.lblPersonIn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.lblPersonIn}")
      Me.Validator.SetDisplayName(txtPersonInCode, lblPersonIn.Text)

      Me.grbTransIN.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.grbTransIN}")
      Me.grbTransOut.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.DepreciationCalDetail.grbTransOut}")

    End Sub
#End Region

#Region "Member"
    Private m_entity As DepreciationCal
    Private m_isInitialized As Boolean = False
    Dim dirtyFlag As Boolean = False
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.m_entity = New DepreciationCal
      'Me.m_entity =  CType(Entity, DepreciationCal)
      
    End Sub
    Public Sub New(ByVal m_entity As DepreciationCal)
      MyBase.New()
      Me.InitializeComponent()
      Me.Initialize()
      Me.Entity = m_entity
      Me.UpdateEntityProperties()
      Me.EventWiring()
      Me.SetLabelText()
    End Sub
#End Region

#Region "Property"
    Property DepreciationCal() As DepreciationCal
      Get
        Return m_entity
      End Get
      Set(ByVal Value As DepreciationCal)
        m_entity = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Overrides Sub Initialize()

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCCInCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtPersonInCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCCOutCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtPersonOutCode.Validated, AddressOf Me.ChangeProperty

    End Sub
#End Region

#Region "IListDetail"

    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity.Canceled Then
        For Each grbCtrl As Control In grb.Controls
          grbCtrl.Enabled = False
        Next
      Else
        For Each grbCtrl As Control In grb.Controls
          grbCtrl.Enabled = True
        Next
      End If

    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      For Each grbCtrl As Control In grb.Controls
        If TypeOf grbCtrl Is FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf Ctrl Is TextBox Then
              Ctrl.Text = ""
            End If
          Next
        End If
      Next

    End Sub

    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      If m_entity Is Nothing OrElse Not m_entity.Originated Then
        ClearDetail()
        Return
      End If

      If Me.m_entity.FromCostcenter.Originated Then
        txtCCOutCode.Text = Me.m_entity.FromCostcenter.Code
        txtCCOutName.Text = Me.m_entity.FromCostcenter.Name
      End If
      If Me.m_entity.FromPerson.Originated Then
        txtPersonOutCode.Text = Me.m_entity.FromPerson.Code
        txtPersonOutName.Text = Me.m_entity.FromPerson.Name
      End If

      ' Transfer IN
      If Me.m_entity.ToCostcenter.Originated Then
        txtCCInCode.Text = Me.m_entity.ToCostcenter.Code
        txtCCInName.Text = Me.m_entity.ToCostcenter.Name
      End If
      If Me.m_entity.ToPerson.Originated Then
        txtPersonInCode.Text = Me.m_entity.ToPerson.Code
        txtPersonInName.Text = Me.m_entity.ToPerson.Name
      End If

      SetLabelText()
      CheckFormEnable()

      m_isInitialized = True
    End Sub

    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If

      Select Case CType(sender, Control).Name.ToLower
        Case "txtccincode"
          dirtyFlag = CostCenter.GetCostCenter(txtCCInCode, txtCCInName, Me.m_entity.ToCostcenter)

        Case "txtpersonincode"
          dirtyFlag = Employee.GetEmployee(txtPersonInCode, txtPersonInName, Me.m_entity.ToPerson)

        Case "txtccoutcode"
          dirtyFlag = CostCenter.GetCostCenter(txtCCOutCode, txtCCOutName, Me.m_entity.FromCostcenter)
          If dirtyFlag Then
            Me.m_entity.ItemCollection.Clear()
          End If

        Case "txtpersonoutcode"
          dirtyFlag = Employee.GetEmployee(txtPersonOutCode, txtPersonOutName, Me.m_entity.FromPerson)
      End Select

      'Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      'myContent.IsDirty = True
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, DepreciationCal)
        Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
        Me.SaveProperties()
        'Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
        EventWiring()
      End Set
    End Property

#End Region

#Region " Ivalidator "
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region " Event of Button controls "
    ' Person
    Private Sub btnPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersonInEdit.Click, btnPersonOutEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
        Private Sub btnPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersonOutFind.Click, btnPersonInFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnpersonoutfind"
                    myEntityPanelService.OpenListDialog(New Employee, AddressOf SetPersonOutDialog)
                Case "btnpersoninfind"
                    myEntityPanelService.OpenListDialog(New Employee, AddressOf SetPersonINDialog)
            End Select
        End Sub

    Private Sub SetPersonINDialog(ByVal e As ISimpleEntity)
      Me.txtPersonInCode.Text = e.Code
       Employee.GetEmployee(txtPersonInCode, txtPersonInName, Me.m_entity.ToPerson)
    End Sub
    Private Sub SetPersonOutDialog(ByVal e As ISimpleEntity)
      Me.txtPersonOutCode.Text = e.Code
       Employee.GetEmployee(txtPersonOutCode, txtPersonOutName, Me.m_entity.FromPerson)
    End Sub
    ' Costcenter
    Private Sub btnCostcenterEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCInEdit.Click, btnCCOutEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCInFind.Click, btnCCOutFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
         CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnccoutfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterOutDialog)
        Case "btnccinfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterINDialog)
      End Select
    End Sub
    Private Sub SetCostCenterINDialog(ByVal e As ISimpleEntity)
      Me.txtCCInCode.Text = e.Code
       CostCenter.GetCostCenter(txtCCInCode, txtCCInName, Me.m_entity.ToCostcenter)
    End Sub
    Private Sub SetCostCenterOutDialog(ByVal e As ISimpleEntity)
      Me.txtCCOutCode.Text = e.Code
       CostCenter.GetCostCenter(txtCCOutCode, txtCCOutName, Me.m_entity.FromCostcenter)
    End Sub


#End Region

#Region "IHelperCapable"
    Public ReadOnly Property Helpers() As HelperCollection Implements IHelperCapable.Helpers
      Get

      End Get
    End Property

    Public Sub LoadHelpers() Implements IHelperCapable.LoadHelpers

    End Sub

    Public Sub UpdateValue(ByVal value As BusinessLogic.BusinessEntity) Implements IHelperCapable.UpdateValue

    End Sub

#End Region

#Region "Member Old Entity"
    Private m_oldCCin As CostCenter
    Private m_oldCCout As CostCenter
    Private m_oldccinperson As Employee
    Private m_oldccoutperson As Employee
    Private m_olddirty As Boolean
#End Region

#Region " IClipboardHandler Overrides "
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        ' Person
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Employee).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtpersonincode", "txtpersoninname"
                Return True
              Case "txtpersonoutcode", "txtpersonoutname"
                Return True
            End Select
          End If
        End If
        ' Cost center
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtccincode", "txtccinname"
                Return True
              Case "txtccoutcode", "txtccoutname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' Person
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtpersonincode", "txtpersoninname"
              Me.SetPersonINDialog(entity)
            Case "txtpersonoutcode", "txtpersonoutname"
              Me.SetPersonOutDialog(entity)
          End Select
        End If
      End If
      ' Cost center
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtccincode", "txtccinname"
              Me.SetCostCenterINDialog(entity)
            Case "txtccoutcode", "txtccoutname"
              Me.SetCostCenterOutDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " IReversibleEntityProperty "
    Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = m_olddirty
      Me.m_entity.FromCC = m_oldCCout
      Me.m_entity.FromPerson = m_oldccoutperson
      Me.m_entity.ToCC = m_oldCCin
      Me.m_entity.ToPerson = m_oldccinperson
    End Sub

    Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      m_olddirty = myContent.IsDirty
      m_oldCCout = m_entity.FromCostcenter
      m_oldccoutperson = m_entity.FromPerson
      m_oldCCin = m_entity.ToCostcenter
      m_oldccinperson = m_entity.ToPerson
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      Me.RevertProperties()
    End Sub
#End Region
    
  End Class

End Namespace
