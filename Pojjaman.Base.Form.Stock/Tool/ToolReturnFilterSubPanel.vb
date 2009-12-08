Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ToolReturnFilterSubPanel
        Inherits AbstractFilterSubPanel

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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbStock As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblRecieveperson As System.Windows.Forms.Label
        Friend WithEvents txtRecievepersonCode As System.Windows.Forms.TextBox
        Friend WithEvents txtRecievepersonName As System.Windows.Forms.TextBox
        Friend WithEvents txtRecieveCCName As System.Windows.Forms.TextBox
        Friend WithEvents txtRecieveCCCode As System.Windows.Forms.TextBox
        Friend WithEvents grbreturn As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtreturnPersonCode As System.Windows.Forms.TextBox
        Friend WithEvents txtreturnPersonName As System.Windows.Forms.TextBox
        Friend WithEvents lblreturnPerson As System.Windows.Forms.Label
        Friend WithEvents txtreturnCCCode As System.Windows.Forms.TextBox
        Friend WithEvents txtreturnCCName As System.Windows.Forms.TextBox
        Friend WithEvents lblreturnCC As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents lblRecieveCC As System.Windows.Forms.Label
        Friend WithEvents btnReturnPersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnReturnPersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnReturnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnReturnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecievePersonEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecievePersonFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecieveCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnRecieveCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ToolReturnFilterSubPanel))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblCode = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbStock = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnRecievePersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnRecievePersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnRecieveCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnRecieveCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblRecieveperson = New System.Windows.Forms.Label
            Me.txtRecievepersonCode = New System.Windows.Forms.TextBox
            Me.txtRecievepersonName = New System.Windows.Forms.TextBox
            Me.txtRecieveCCName = New System.Windows.Forms.TextBox
            Me.lblRecieveCC = New System.Windows.Forms.Label
            Me.txtRecieveCCCode = New System.Windows.Forms.TextBox
            Me.grbreturn = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnReturnPersonEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnReturnPersonFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnReturnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnReturnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtreturnPersonCode = New System.Windows.Forms.TextBox
            Me.txtreturnPersonName = New System.Windows.Forms.TextBox
            Me.lblreturnPerson = New System.Windows.Forms.Label
            Me.txtreturnCCCode = New System.Windows.Forms.TextBox
            Me.txtreturnCCName = New System.Windows.Forms.TextBox
            Me.lblreturnCC = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbDetail.SuspendLayout()
            Me.grbGeneral.SuspendLayout()
            Me.grbStock.SuspendLayout()
            Me.grbreturn.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.grbGeneral)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.Controls.Add(Me.grbStock)
            Me.grbDetail.Controls.Add(Me.grbreturn)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 0)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(728, 200)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            '
            'grbGeneral
            '
            Me.grbGeneral.Controls.Add(Me.txtCode)
            Me.grbGeneral.Controls.Add(Me.lblDocDateStart)
            Me.grbGeneral.Controls.Add(Me.lblDocDateEnd)
            Me.grbGeneral.Controls.Add(Me.dtpDocDateStart)
            Me.grbGeneral.Controls.Add(Me.dtpDocDateEnd)
            Me.grbGeneral.Controls.Add(Me.lblCode)
            Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbGeneral.Location = New System.Drawing.Point(8, 10)
            Me.grbGeneral.Name = "grbGeneral"
            Me.grbGeneral.Size = New System.Drawing.Size(712, 72)
            Me.grbGeneral.TabIndex = 0
            Me.grbGeneral.TabStop = False
            Me.grbGeneral.Text = "วันที่เอกสาร"
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(112, 16)
            Me.txtCode.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(344, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 40)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(96, 18)
            Me.lblDocDateStart.TabIndex = 2
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 41)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(72, 18)
            Me.lblDocDateEnd.TabIndex = 4
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 40)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
            Me.dtpDocDateStart.TabIndex = 3
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(320, 40)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
            Me.dtpDocDateEnd.TabIndex = 5
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(96, 18)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "เลขที่เอกสาร"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(648, 168)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 4
            Me.btnSearch.Text = "Search"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(568, 168)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 3
            Me.btnReset.Text = "Reset"
            '
            'grbStock
            '
            Me.grbStock.Controls.Add(Me.btnRecievePersonEdit)
            Me.grbStock.Controls.Add(Me.btnRecievePersonFind)
            Me.grbStock.Controls.Add(Me.btnRecieveCCEdit)
            Me.grbStock.Controls.Add(Me.btnRecieveCCFind)
            Me.grbStock.Controls.Add(Me.lblRecieveperson)
            Me.grbStock.Controls.Add(Me.txtRecievepersonCode)
            Me.grbStock.Controls.Add(Me.txtRecievepersonName)
            Me.grbStock.Controls.Add(Me.txtRecieveCCName)
            Me.grbStock.Controls.Add(Me.lblRecieveCC)
            Me.grbStock.Controls.Add(Me.txtRecieveCCCode)
            Me.grbStock.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbStock.Location = New System.Drawing.Point(368, 88)
            Me.grbStock.Name = "grbStock"
            Me.grbStock.Size = New System.Drawing.Size(352, 72)
            Me.grbStock.TabIndex = 2
            Me.grbStock.TabStop = False
            Me.grbStock.Text = "ผู้ให้เบิก"
            '
            'btnRecievePersonEdit
            '
            Me.btnRecievePersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecievePersonEdit.Image = CType(resources.GetObject("btnRecievePersonEdit.Image"), System.Drawing.Image)
            Me.btnRecievePersonEdit.Location = New System.Drawing.Point(320, 40)
            Me.btnRecievePersonEdit.Name = "btnRecievePersonEdit"
            Me.btnRecievePersonEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnRecievePersonEdit.TabIndex = 9
            Me.btnRecievePersonEdit.TabStop = False
            Me.btnRecievePersonEdit.ThemedImage = CType(resources.GetObject("btnRecievePersonEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnRecievePersonFind
            '
            Me.btnRecievePersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecievePersonFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRecievePersonFind.Image = CType(resources.GetObject("btnRecievePersonFind.Image"), System.Drawing.Image)
            Me.btnRecievePersonFind.Location = New System.Drawing.Point(296, 40)
            Me.btnRecievePersonFind.Name = "btnRecievePersonFind"
            Me.btnRecievePersonFind.Size = New System.Drawing.Size(24, 23)
            Me.btnRecievePersonFind.TabIndex = 8
            Me.btnRecievePersonFind.TabStop = False
            Me.btnRecievePersonFind.ThemedImage = CType(resources.GetObject("btnRecievePersonFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnRecieveCCEdit
            '
            Me.btnRecieveCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecieveCCEdit.Image = CType(resources.GetObject("btnRecieveCCEdit.Image"), System.Drawing.Image)
            Me.btnRecieveCCEdit.Location = New System.Drawing.Point(320, 16)
            Me.btnRecieveCCEdit.Name = "btnRecieveCCEdit"
            Me.btnRecieveCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnRecieveCCEdit.TabIndex = 4
            Me.btnRecieveCCEdit.TabStop = False
            Me.btnRecieveCCEdit.ThemedImage = CType(resources.GetObject("btnRecieveCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnRecieveCCFind
            '
            Me.btnRecieveCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRecieveCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRecieveCCFind.Image = CType(resources.GetObject("btnRecieveCCFind.Image"), System.Drawing.Image)
            Me.btnRecieveCCFind.Location = New System.Drawing.Point(296, 16)
            Me.btnRecieveCCFind.Name = "btnRecieveCCFind"
            Me.btnRecieveCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnRecieveCCFind.TabIndex = 3
            Me.btnRecieveCCFind.TabStop = False
            Me.btnRecieveCCFind.ThemedImage = CType(resources.GetObject("btnRecieveCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblRecieveperson
            '
            Me.lblRecieveperson.BackColor = System.Drawing.Color.Transparent
            Me.lblRecieveperson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRecieveperson.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRecieveperson.Location = New System.Drawing.Point(8, 40)
            Me.lblRecieveperson.Name = "lblRecieveperson"
            Me.lblRecieveperson.Size = New System.Drawing.Size(104, 18)
            Me.lblRecieveperson.TabIndex = 5
            Me.lblRecieveperson.Text = "ผู้ให้เบิก"
            Me.lblRecieveperson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRecievepersonCode
            '
            Me.Validator.SetDataType(Me.txtRecievepersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRecievepersonCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRecievepersonCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRecievepersonCode, System.Drawing.Color.Empty)
            Me.txtRecievepersonCode.Location = New System.Drawing.Point(120, 40)
            Me.txtRecievepersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtRecievepersonCode, "")
            Me.Validator.SetMinValue(Me.txtRecievepersonCode, "")
            Me.txtRecievepersonCode.Name = "txtRecievepersonCode"
            Me.Validator.SetRegularExpression(Me.txtRecievepersonCode, "")
            Me.Validator.SetRequired(Me.txtRecievepersonCode, False)
            Me.txtRecievepersonCode.Size = New System.Drawing.Size(80, 20)
            Me.txtRecievepersonCode.TabIndex = 6
            Me.txtRecievepersonCode.Text = ""
            '
            'txtRecievepersonName
            '
            Me.Validator.SetDataType(Me.txtRecievepersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRecievepersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRecievepersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRecievepersonName, System.Drawing.Color.Empty)
            Me.txtRecievepersonName.Location = New System.Drawing.Point(200, 40)
            Me.Validator.SetMaxValue(Me.txtRecievepersonName, "")
            Me.Validator.SetMinValue(Me.txtRecievepersonName, "")
            Me.txtRecievepersonName.Name = "txtRecievepersonName"
            Me.txtRecievepersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRecievepersonName, "")
            Me.Validator.SetRequired(Me.txtRecievepersonName, False)
            Me.txtRecievepersonName.Size = New System.Drawing.Size(96, 20)
            Me.txtRecievepersonName.TabIndex = 0
            Me.txtRecievepersonName.TabStop = False
            Me.txtRecievepersonName.Text = ""
            '
            'txtRecieveCCName
            '
            Me.Validator.SetDataType(Me.txtRecieveCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRecieveCCName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRecieveCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRecieveCCName, System.Drawing.Color.Empty)
            Me.txtRecieveCCName.Location = New System.Drawing.Point(200, 16)
            Me.Validator.SetMaxValue(Me.txtRecieveCCName, "")
            Me.Validator.SetMinValue(Me.txtRecieveCCName, "")
            Me.txtRecieveCCName.Name = "txtRecieveCCName"
            Me.txtRecieveCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRecieveCCName, "")
            Me.Validator.SetRequired(Me.txtRecieveCCName, False)
            Me.txtRecieveCCName.Size = New System.Drawing.Size(96, 20)
            Me.txtRecieveCCName.TabIndex = 0
            Me.txtRecieveCCName.TabStop = False
            Me.txtRecieveCCName.Text = ""
            '
            'lblRecieveCC
            '
            Me.lblRecieveCC.BackColor = System.Drawing.Color.Transparent
            Me.lblRecieveCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRecieveCC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRecieveCC.Location = New System.Drawing.Point(8, 16)
            Me.lblRecieveCC.Name = "lblRecieveCC"
            Me.lblRecieveCC.Size = New System.Drawing.Size(104, 18)
            Me.lblRecieveCC.TabIndex = 0
            Me.lblRecieveCC.Text = "Cost Center ให้เบิก"
            Me.lblRecieveCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRecieveCCCode
            '
            Me.Validator.SetDataType(Me.txtRecieveCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRecieveCCCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRecieveCCCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRecieveCCCode, System.Drawing.Color.Empty)
            Me.txtRecieveCCCode.Location = New System.Drawing.Point(120, 16)
            Me.txtRecieveCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtRecieveCCCode, "")
            Me.Validator.SetMinValue(Me.txtRecieveCCCode, "")
            Me.txtRecieveCCCode.Name = "txtRecieveCCCode"
            Me.Validator.SetRegularExpression(Me.txtRecieveCCCode, "")
            Me.Validator.SetRequired(Me.txtRecieveCCCode, False)
            Me.txtRecieveCCCode.Size = New System.Drawing.Size(80, 20)
            Me.txtRecieveCCCode.TabIndex = 1
            Me.txtRecieveCCCode.Text = ""
            '
            'grbreturn
            '
            Me.grbreturn.Controls.Add(Me.btnReturnPersonEdit)
            Me.grbreturn.Controls.Add(Me.btnReturnPersonFind)
            Me.grbreturn.Controls.Add(Me.btnReturnCCEdit)
            Me.grbreturn.Controls.Add(Me.btnReturnCCFind)
            Me.grbreturn.Controls.Add(Me.txtreturnPersonCode)
            Me.grbreturn.Controls.Add(Me.txtreturnPersonName)
            Me.grbreturn.Controls.Add(Me.lblreturnPerson)
            Me.grbreturn.Controls.Add(Me.txtreturnCCCode)
            Me.grbreturn.Controls.Add(Me.txtreturnCCName)
            Me.grbreturn.Controls.Add(Me.lblreturnCC)
            Me.grbreturn.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbreturn.Location = New System.Drawing.Point(8, 88)
            Me.grbreturn.Name = "grbreturn"
            Me.grbreturn.Size = New System.Drawing.Size(352, 72)
            Me.grbreturn.TabIndex = 1
            Me.grbreturn.TabStop = False
            Me.grbreturn.Text = "ผู้ขอเบิก"
            '
            'btnReturnPersonEdit
            '
            Me.btnReturnPersonEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnPersonEdit.Image = CType(resources.GetObject("btnReturnPersonEdit.Image"), System.Drawing.Image)
            Me.btnReturnPersonEdit.Location = New System.Drawing.Point(320, 40)
            Me.btnReturnPersonEdit.Name = "btnReturnPersonEdit"
            Me.btnReturnPersonEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnPersonEdit.TabIndex = 9
            Me.btnReturnPersonEdit.TabStop = False
            Me.btnReturnPersonEdit.ThemedImage = CType(resources.GetObject("btnReturnPersonEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnReturnPersonFind
            '
            Me.btnReturnPersonFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnPersonFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnReturnPersonFind.Image = CType(resources.GetObject("btnReturnPersonFind.Image"), System.Drawing.Image)
            Me.btnReturnPersonFind.Location = New System.Drawing.Point(296, 40)
            Me.btnReturnPersonFind.Name = "btnReturnPersonFind"
            Me.btnReturnPersonFind.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnPersonFind.TabIndex = 8
            Me.btnReturnPersonFind.TabStop = False
            Me.btnReturnPersonFind.ThemedImage = CType(resources.GetObject("btnReturnPersonFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnReturnCCEdit
            '
            Me.btnReturnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnCCEdit.Image = CType(resources.GetObject("btnReturnCCEdit.Image"), System.Drawing.Image)
            Me.btnReturnCCEdit.Location = New System.Drawing.Point(320, 16)
            Me.btnReturnCCEdit.Name = "btnReturnCCEdit"
            Me.btnReturnCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnCCEdit.TabIndex = 4
            Me.btnReturnCCEdit.TabStop = False
            Me.btnReturnCCEdit.ThemedImage = CType(resources.GetObject("btnReturnCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnReturnCCFind
            '
            Me.btnReturnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReturnCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnReturnCCFind.Image = CType(resources.GetObject("btnReturnCCFind.Image"), System.Drawing.Image)
            Me.btnReturnCCFind.Location = New System.Drawing.Point(296, 16)
            Me.btnReturnCCFind.Name = "btnReturnCCFind"
            Me.btnReturnCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnReturnCCFind.TabIndex = 3
            Me.btnReturnCCFind.TabStop = False
            Me.btnReturnCCFind.ThemedImage = CType(resources.GetObject("btnReturnCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtreturnPersonCode
            '
            Me.Validator.SetDataType(Me.txtreturnPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtreturnPersonCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtreturnPersonCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtreturnPersonCode, System.Drawing.Color.Empty)
            Me.txtreturnPersonCode.Location = New System.Drawing.Point(120, 40)
            Me.txtreturnPersonCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtreturnPersonCode, "")
            Me.Validator.SetMinValue(Me.txtreturnPersonCode, "")
            Me.txtreturnPersonCode.Name = "txtreturnPersonCode"
            Me.Validator.SetRegularExpression(Me.txtreturnPersonCode, "")
            Me.Validator.SetRequired(Me.txtreturnPersonCode, False)
            Me.txtreturnPersonCode.Size = New System.Drawing.Size(80, 20)
            Me.txtreturnPersonCode.TabIndex = 6
            Me.txtreturnPersonCode.Text = ""
            '
            'txtreturnPersonName
            '
            Me.Validator.SetDataType(Me.txtreturnPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtreturnPersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtreturnPersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtreturnPersonName, System.Drawing.Color.Empty)
            Me.txtreturnPersonName.Location = New System.Drawing.Point(200, 40)
            Me.Validator.SetMaxValue(Me.txtreturnPersonName, "")
            Me.Validator.SetMinValue(Me.txtreturnPersonName, "")
            Me.txtreturnPersonName.Name = "txtreturnPersonName"
            Me.txtreturnPersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtreturnPersonName, "")
            Me.Validator.SetRequired(Me.txtreturnPersonName, False)
            Me.txtreturnPersonName.Size = New System.Drawing.Size(96, 20)
            Me.txtreturnPersonName.TabIndex = 0
            Me.txtreturnPersonName.TabStop = False
            Me.txtreturnPersonName.Text = ""
            '
            'lblreturnPerson
            '
            Me.lblreturnPerson.BackColor = System.Drawing.Color.Transparent
            Me.lblreturnPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblreturnPerson.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblreturnPerson.Location = New System.Drawing.Point(8, 40)
            Me.lblreturnPerson.Name = "lblreturnPerson"
            Me.lblreturnPerson.Size = New System.Drawing.Size(104, 18)
            Me.lblreturnPerson.TabIndex = 5
            Me.lblreturnPerson.Text = "ผู้ขอเบิก"
            Me.lblreturnPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtreturnCCCode
            '
            Me.Validator.SetDataType(Me.txtreturnCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtreturnCCCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtreturnCCCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtreturnCCCode, System.Drawing.Color.Empty)
            Me.txtreturnCCCode.Location = New System.Drawing.Point(120, 16)
            Me.txtreturnCCCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtreturnCCCode, "")
            Me.Validator.SetMinValue(Me.txtreturnCCCode, "")
            Me.txtreturnCCCode.Name = "txtreturnCCCode"
            Me.Validator.SetRegularExpression(Me.txtreturnCCCode, "")
            Me.Validator.SetRequired(Me.txtreturnCCCode, False)
            Me.txtreturnCCCode.Size = New System.Drawing.Size(80, 20)
            Me.txtreturnCCCode.TabIndex = 1
            Me.txtreturnCCCode.Text = ""
            '
            'txtreturnCCName
            '
            Me.Validator.SetDataType(Me.txtreturnCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtreturnCCName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtreturnCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtreturnCCName, System.Drawing.Color.Empty)
            Me.txtreturnCCName.Location = New System.Drawing.Point(200, 16)
            Me.Validator.SetMaxValue(Me.txtreturnCCName, "")
            Me.Validator.SetMinValue(Me.txtreturnCCName, "")
            Me.txtreturnCCName.Name = "txtreturnCCName"
            Me.txtreturnCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtreturnCCName, "")
            Me.Validator.SetRequired(Me.txtreturnCCName, False)
            Me.txtreturnCCName.Size = New System.Drawing.Size(96, 20)
            Me.txtreturnCCName.TabIndex = 0
            Me.txtreturnCCName.TabStop = False
            Me.txtreturnCCName.Text = ""
            '
            'lblreturnCC
            '
            Me.lblreturnCC.BackColor = System.Drawing.Color.Transparent
            Me.lblreturnCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblreturnCC.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblreturnCC.Location = New System.Drawing.Point(8, 16)
            Me.lblreturnCC.Name = "lblreturnCC"
            Me.lblreturnCC.Size = New System.Drawing.Size(104, 18)
            Me.lblreturnCC.TabIndex = 0
            Me.lblreturnCC.Text = "Cost Center ขอเบิก"
            Me.lblreturnCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            'ToolReturnFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "ToolReturnFilterSubPanel"
            Me.Size = New System.Drawing.Size(744, 208)
            Me.grbDetail.ResumeLayout(False)
            Me.grbGeneral.ResumeLayout(False)
            Me.grbStock.ResumeLayout(False)
            Me.grbreturn.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()
            Me.LoopControl(Me)
        End Sub
#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.lblDocDateEnd}")
            Me.lblRecieveCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.lblRecieveCC}")
            Me.lblRecieveperson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.lblRecieveperson}")
            Me.lblreturnPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.lblreturnPerson}")
            Me.lblreturnCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.lblreturnCC}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.lblCode}")
            Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.grbGeneral}")
            Me.grbreturn.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.grbreturn}")
            Me.grbStock.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ToolReturnFilterSubPanel.grbStock}")
        End Sub
#End Region

#Region "Members"
        Private m_returnperson As Employee
        Private m_returncc As CostCenter
        Private m_Recieveperson As Employee
        Private m_Recievecc As CostCenter
#End Region

#Region "Methods"
        Public Sub Initialize()
            PopulateStatus()
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()
            Me.txtCode.Text = ""

            Me.txtRecievepersonCode.Text = ""
            Me.txtRecievepersonName.Text = ""
            Me.m_Recieveperson = New Employee


            Me.txtRecieveCCCode.Text = ""
            Me.txtRecieveCCName.Text = ""
            Me.m_Recievecc = New CostCenter

            Me.txtreturnPersonCode.Text = ""
            Me.txtreturnPersonName.Text = ""
            Me.m_returnperson = New Employee

            Me.txtreturnCCCode.Text = ""
            Me.txtreturnCCName.Text = ""
            Me.m_returncc = New CostCenter

            Me.dtpDocDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.dtpDocDateEnd.Value = Now.Date

        End Sub
        Private Sub PopulateStatus()

        End Sub

        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(7) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("returnperson", IIf(Me.m_returnperson.Originated, Me.m_returnperson.Id, DBNull.Value))
            arr(2) = New Filter("returncc", IIf(Me.m_returncc.Originated, Me.m_returncc.Id, DBNull.Value))
            arr(3) = New Filter("Recieveperson", IIf(Me.m_Recieveperson.Originated, Me.m_Recieveperson.Id, DBNull.Value))
            arr(4) = New Filter("RecieveCC", IIf(Me.m_Recievecc.Originated, Me.m_Recievecc.Id, DBNull.Value))
            arr(5) = New Filter("startdate", Me.dtpDocDateStart.Value.Date)
            arr(6) = New Filter("enddate", Me.dtpDocDateEnd.Value.Date)
            arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        ' return Person ...
        Private Sub txtreturnPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtreturnPersonCode.Validated
            Employee.GetEmployee(txtreturnPersonCode, txtreturnPersonName, Me.m_returnperson)
        End Sub
        Private Sub btnReturnPersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnPersonEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub btnreturnPersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnPersonFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetreturnPerson)
        End Sub
        Private Sub SetreturnPerson(ByVal e As ISimpleEntity)
            Me.txtreturnPersonCode.Text = e.Code
            Employee.GetEmployee(txtreturnPersonCode, txtreturnPersonName, Me.m_returnperson)
        End Sub
        ' return Costcenter ...
        Private Sub txtreturnCCCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtreturnCCCode.Validated
            CostCenter.GetCostCenterWithoutRight(txtreturnCCCode, txtreturnCCName, Me.m_returncc)
        End Sub
        Private Sub btnreturnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCCEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub btnreturnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnCCFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetreturnCC, New Filter() {New Filter("checkright", False)})
        End Sub
        Private Sub SetreturnCC(ByVal e As ISimpleEntity)
            Me.txtreturnCCCode.Text = e.Code
            CostCenter.GetCostCenterWithoutRight(txtreturnCCCode, txtreturnCCName, Me.m_returncc)
        End Sub
        ' Store Person ...
        Private Sub txtRecievepersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecievepersonCode.Validated
            Employee.GetEmployee(txtRecievepersonCode, txtRecievepersonName, Me.m_Recieveperson)
        End Sub
        Private Sub btnRecievepersonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecievePersonEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub btnRecievepersonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecievePersonFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetRecieveperson)
        End Sub
        Private Sub SetRecieveperson(ByVal e As ISimpleEntity)
            Me.txtRecievepersonCode.Text = e.Code
            Employee.GetEmployee(txtRecievepersonCode, txtRecievepersonName, Me.m_Recieveperson)
        End Sub
        ' Store Costcenter ...
        Private Sub txtRecieveCCCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecieveCCCode.Validated
            CostCenter.GetCostCenter(txtRecieveCCCode, txtRecieveCCName, Me.m_Recievecc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        Private Sub btnRecieveCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecieveCCEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
        Private Sub btnRecieveCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecieveCCFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetRecieveCC)
        End Sub
        Private Sub SetRecieveCC(ByVal e As ISimpleEntity)
            Me.txtRecieveCCCode.Text = e.Code
            CostCenter.GetCostCenter(txtRecieveCCCode, txtRecieveCCName, Me.m_Recievecc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        ' Reset Button ...
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub

#End Region

#Region "IClipboardHandler Overrides" 'Undone
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                If Me.ActiveControl Is Nothing Then
                    Return False
                End If
                Dim data As IDataObject = Clipboard.GetDataObject
                ' return person ...
                If data.GetDataPresent((New Employee).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtreturnpersoncode", "txtreturnpersonname"
                            Return True
                    End Select
                End If
                ' store person ...
                If data.GetDataPresent((New Employee).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtRecievepersoncode", "txtRecievepersonname"
                            Return True
                    End Select
                End If
                ' return costcenter ...
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtreturncccode", "txtreturnccname"
                            Return True
                        Case "txtstorecccode", "txtstoreccname"
                            Return True
                    End Select
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.ActiveControl Is Nothing Then
                Return
            End If
            Dim data As IDataObject = Clipboard.GetDataObject
            ' return person ...
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtreturnpersoncode", "txtreturnpersonname"
                        Me.SetreturnPerson(entity)
                End Select
            End If
            ' Store Person ...
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtRecievepersoncode", "txtRecievepersonname"
                        Me.SetRecieveperson(entity)
                End Select
            End If
            ' Costcenter ...
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                Select Case Me.ActiveControl.Name.ToLower
                    Case "txtreturncccode", "txtreturnccname"
                        Me.SetreturnCC(entity)
                    Case "txtstorecccode", "txtstoreccname"
                        Me.SetRecieveCC(entity)
                End Select
            End If
        End Sub
#End Region

        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                For Each entity As ISimpleEntity In Value
                    If TypeOf entity Is ToolReturn Then
                        Dim obj As ToolReturn = CType(entity, ToolReturn)
                        If obj.ReturnPerson.Originated Then
                            Me.SetreturnPerson(obj.ReturnPerson)
                            Me.txtreturnPersonCode.Enabled = False
                            Me.txtreturnPersonName.Enabled = False
                            Me.btnreturnPersonEdit.Enabled = False
                            Me.btnreturnPersonFind.Enabled = False
                        End If

                        If obj.ReturnCostcenter.Originated Then
                            Me.SetreturnCC(obj.ReturnCostcenter)
                            Me.txtreturnCCCode.Enabled = False
                            Me.txtreturnCCName.Enabled = False
                            Me.btnreturnCCEdit.Enabled = False
                            Me.btnreturnCCFind.Enabled = False
                        End If

                        If obj.Recieveperson.Originated Then
                            Me.SetRecieveperson(obj.Recieveperson)
                            Me.txtRecievepersonCode.Enabled = False
                            Me.txtRecievepersonName.Enabled = False
                            Me.btnRecievepersonEdit.Enabled = False
                            Me.btnRecievepersonFind.Enabled = False
                        End If

                        If obj.RecieveCostcenter.Originated Then
                            Me.SetRecieveCC(obj.RecieveCostcenter)
                            Me.txtRecieveCCCode.Enabled = False
                            Me.txtRecieveCCName.Enabled = False
                            Me.btnRecieveCCEdit.Enabled = False
                            Me.btnRecieveCCFind.Enabled = False
                        End If
                    End If
                Next
            End Set
        End Property


    End Class
End Namespace

