Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class IncomingCheckFilterSubPanel
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
        Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCqCode As System.Windows.Forms.TextBox
        Friend WithEvents cmbOutgoingCheck As System.Windows.Forms.ComboBox
        Friend WithEvents lblCqCode As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents btnCustomerEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnCustomerFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
        Friend WithEvents btnBankEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtBankName As System.Windows.Forms.TextBox
        Friend WithEvents btnBankFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblBank As System.Windows.Forms.Label
        Friend WithEvents txtReceiveCode As System.Windows.Forms.TextBox
        Friend WithEvents txtReceiveName As System.Windows.Forms.TextBox
        Friend WithEvents lblReceive As System.Windows.Forms.Label
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnReceiverFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnReceiverEdit As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(IncomingCheckFilterSubPanel))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnCustomerEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnCustomerFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCustomerCode = New System.Windows.Forms.TextBox
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.txtBankCode = New System.Windows.Forms.TextBox
            Me.btnBankEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtBankName = New System.Windows.Forms.TextBox
            Me.btnBankFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblBank = New System.Windows.Forms.Label
            Me.txtReceiveCode = New System.Windows.Forms.TextBox
            Me.txtReceiveName = New System.Windows.Forms.TextBox
            Me.lblReceive = New System.Windows.Forms.Label
            Me.txtCqCode = New System.Windows.Forms.TextBox
            Me.cmbOutgoingCheck = New System.Windows.Forms.ComboBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblCqCode = New System.Windows.Forms.Label
            Me.lblStatus = New System.Windows.Forms.Label
            Me.btnReceiverFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnReceiverEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.grbGeneral.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.grbGeneral)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(736, 200)
            Me.grbDetail.TabIndex = 9
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "เช็ครับ"
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(8, 120)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(336, 72)
            Me.grbDocDate.TabIndex = 196
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "วันที่เอกสาร"
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 17)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(104, 18)
            Me.lblDocDateStart.TabIndex = 11
            Me.lblDocDateStart.Text = "ตั้งแต่"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 40)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(104, 18)
            Me.lblDocDateEnd.TabIndex = 11
            Me.lblDocDateEnd.Text = "ถึง"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(192, 20)
            Me.dtpDocDateStart.TabIndex = 0
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(112, 40)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(192, 20)
            Me.dtpDocDateEnd.TabIndex = 1
            '
            'grbGeneral
            '
            Me.grbGeneral.Controls.Add(Me.btnCustomerEdit)
            Me.grbGeneral.Controls.Add(Me.btnCustomerFind)
            Me.grbGeneral.Controls.Add(Me.txtCustomerCode)
            Me.grbGeneral.Controls.Add(Me.lblCustomer)
            Me.grbGeneral.Controls.Add(Me.txtCustomerName)
            Me.grbGeneral.Controls.Add(Me.txtBankCode)
            Me.grbGeneral.Controls.Add(Me.btnBankEdit)
            Me.grbGeneral.Controls.Add(Me.txtBankName)
            Me.grbGeneral.Controls.Add(Me.btnBankFind)
            Me.grbGeneral.Controls.Add(Me.lblBank)
            Me.grbGeneral.Controls.Add(Me.txtReceiveCode)
            Me.grbGeneral.Controls.Add(Me.txtReceiveName)
            Me.grbGeneral.Controls.Add(Me.lblReceive)
            Me.grbGeneral.Controls.Add(Me.txtCqCode)
            Me.grbGeneral.Controls.Add(Me.cmbOutgoingCheck)
            Me.grbGeneral.Controls.Add(Me.txtCode)
            Me.grbGeneral.Controls.Add(Me.lblCode)
            Me.grbGeneral.Controls.Add(Me.lblCqCode)
            Me.grbGeneral.Controls.Add(Me.lblStatus)
            Me.grbGeneral.Controls.Add(Me.btnReceiverFind)
            Me.grbGeneral.Controls.Add(Me.btnReceiverEdit)
            Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbGeneral.Location = New System.Drawing.Point(8, 16)
            Me.grbGeneral.Name = "grbGeneral"
            Me.grbGeneral.Size = New System.Drawing.Size(712, 96)
            Me.grbGeneral.TabIndex = 181
            Me.grbGeneral.TabStop = False
            Me.grbGeneral.Text = "รายละเอียดทั่วไป"
            '
            'btnCustomerEdit
            '
            Me.btnCustomerEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerEdit.Image = CType(resources.GetObject("btnCustomerEdit.Image"), System.Drawing.Image)
            Me.btnCustomerEdit.Location = New System.Drawing.Point(656, 40)
            Me.btnCustomerEdit.Name = "btnCustomerEdit"
            Me.btnCustomerEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnCustomerEdit.TabIndex = 189
            Me.btnCustomerEdit.TabStop = False
            Me.btnCustomerEdit.ThemedImage = CType(resources.GetObject("btnCustomerEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCustomerFind
            '
            Me.btnCustomerFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCustomerFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCustomerFind.Image = CType(resources.GetObject("btnCustomerFind.Image"), System.Drawing.Image)
            Me.btnCustomerFind.Location = New System.Drawing.Point(632, 40)
            Me.btnCustomerFind.Name = "btnCustomerFind"
            Me.btnCustomerFind.Size = New System.Drawing.Size(24, 23)
            Me.btnCustomerFind.TabIndex = 192
            Me.btnCustomerFind.TabStop = False
            Me.btnCustomerFind.ThemedImage = CType(resources.GetObject("btnCustomerFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCustomerCode
            '
            Me.txtCustomerCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCustomerCode.Location = New System.Drawing.Point(400, 40)
            Me.txtCustomerCode.MaxLength = 20
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.txtCustomerCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCustomerCode.TabIndex = 188
            Me.txtCustomerCode.Text = ""
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.Color.Black
            Me.lblCustomer.Location = New System.Drawing.Point(312, 40)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(88, 18)
            Me.lblCustomer.TabIndex = 181
            Me.lblCustomer.Text = "ลูกค้า:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustomerName
            '
            Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
            Me.txtCustomerName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCustomerName.Location = New System.Drawing.Point(488, 40)
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.txtCustomerName.Size = New System.Drawing.Size(144, 21)
            Me.txtCustomerName.TabIndex = 186
            Me.txtCustomerName.Text = ""
            '
            'txtBankCode
            '
            Me.txtBankCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtBankCode.Location = New System.Drawing.Point(400, 64)
            Me.txtBankCode.MaxLength = 20
            Me.txtBankCode.Name = "txtBankCode"
            Me.txtBankCode.Size = New System.Drawing.Size(88, 21)
            Me.txtBankCode.TabIndex = 187
            Me.txtBankCode.Text = ""
            '
            'btnBankEdit
            '
            Me.btnBankEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankEdit.Image = CType(resources.GetObject("btnBankEdit.Image"), System.Drawing.Image)
            Me.btnBankEdit.Location = New System.Drawing.Point(656, 64)
            Me.btnBankEdit.Name = "btnBankEdit"
            Me.btnBankEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnBankEdit.TabIndex = 190
            Me.btnBankEdit.TabStop = False
            Me.btnBankEdit.ThemedImage = CType(resources.GetObject("btnBankEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtBankName
            '
            Me.txtBankName.BackColor = System.Drawing.SystemColors.Control
            Me.txtBankName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtBankName.Location = New System.Drawing.Point(488, 64)
            Me.txtBankName.Name = "txtBankName"
            Me.txtBankName.ReadOnly = True
            Me.txtBankName.Size = New System.Drawing.Size(144, 21)
            Me.txtBankName.TabIndex = 183
            Me.txtBankName.Text = ""
            '
            'btnBankFind
            '
            Me.btnBankFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBankFind.Image = CType(resources.GetObject("btnBankFind.Image"), System.Drawing.Image)
            Me.btnBankFind.Location = New System.Drawing.Point(632, 64)
            Me.btnBankFind.Name = "btnBankFind"
            Me.btnBankFind.Size = New System.Drawing.Size(24, 23)
            Me.btnBankFind.TabIndex = 193
            Me.btnBankFind.TabStop = False
            Me.btnBankFind.ThemedImage = CType(resources.GetObject("btnBankFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblBank
            '
            Me.lblBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBank.ForeColor = System.Drawing.Color.Black
            Me.lblBank.Location = New System.Drawing.Point(312, 64)
            Me.lblBank.Name = "lblBank"
            Me.lblBank.Size = New System.Drawing.Size(88, 18)
            Me.lblBank.TabIndex = 180
            Me.lblBank.Text = "ธนาคาร:"
            Me.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtReceiveCode
            '
            Me.txtReceiveCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtReceiveCode.Location = New System.Drawing.Point(400, 16)
            Me.txtReceiveCode.MaxLength = 20
            Me.txtReceiveCode.Name = "txtReceiveCode"
            Me.txtReceiveCode.Size = New System.Drawing.Size(88, 21)
            Me.txtReceiveCode.TabIndex = 185
            Me.txtReceiveCode.Text = ""
            '
            'txtReceiveName
            '
            Me.txtReceiveName.BackColor = System.Drawing.SystemColors.Control
            Me.txtReceiveName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtReceiveName.Location = New System.Drawing.Point(488, 16)
            Me.txtReceiveName.Name = "txtReceiveName"
            Me.txtReceiveName.ReadOnly = True
            Me.txtReceiveName.Size = New System.Drawing.Size(144, 21)
            Me.txtReceiveName.TabIndex = 184
            Me.txtReceiveName.Text = ""
            '
            'lblReceive
            '
            Me.lblReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceive.ForeColor = System.Drawing.Color.Black
            Me.lblReceive.Location = New System.Drawing.Point(312, 16)
            Me.lblReceive.Name = "lblReceive"
            Me.lblReceive.Size = New System.Drawing.Size(88, 18)
            Me.lblReceive.TabIndex = 182
            Me.lblReceive.Text = "ผู้รับเช็ค:"
            Me.lblReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCqCode
            '
            Me.txtCqCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCqCode.Location = New System.Drawing.Point(112, 40)
            Me.txtCqCode.MaxLength = 20
            Me.txtCqCode.Name = "txtCqCode"
            Me.txtCqCode.Size = New System.Drawing.Size(192, 21)
            Me.txtCqCode.TabIndex = 8
            Me.txtCqCode.Text = ""
            '
            'cmbOutgoingCheck
            '
            Me.cmbOutgoingCheck.Location = New System.Drawing.Point(112, 64)
            Me.cmbOutgoingCheck.Name = "cmbOutgoingCheck"
            Me.cmbOutgoingCheck.Size = New System.Drawing.Size(192, 21)
            Me.cmbOutgoingCheck.TabIndex = 10
            '
            'txtCode
            '
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCode.Location = New System.Drawing.Point(112, 16)
            Me.txtCode.MaxLength = 20
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(192, 21)
            Me.txtCode.TabIndex = 7
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 13
            Me.lblCode.Text = "เลขที่เอกสาร :"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCqCode
            '
            Me.lblCqCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCqCode.ForeColor = System.Drawing.Color.Black
            Me.lblCqCode.Location = New System.Drawing.Point(8, 40)
            Me.lblCqCode.Name = "lblCqCode"
            Me.lblCqCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCqCode.TabIndex = 14
            Me.lblCqCode.Text = "เลขที่เช็ค :"
            Me.lblCqCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Black
            Me.lblStatus.Location = New System.Drawing.Point(8, 64)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(104, 18)
            Me.lblStatus.TabIndex = 11
            Me.lblStatus.Text = "สถานะเช็คจ่าย :"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnReceiverFind
            '
            Me.btnReceiverFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReceiverFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnReceiverFind.Image = CType(resources.GetObject("btnReceiverFind.Image"), System.Drawing.Image)
            Me.btnReceiverFind.Location = New System.Drawing.Point(632, 16)
            Me.btnReceiverFind.Name = "btnReceiverFind"
            Me.btnReceiverFind.Size = New System.Drawing.Size(24, 23)
            Me.btnReceiverFind.TabIndex = 192
            Me.btnReceiverFind.TabStop = False
            Me.btnReceiverFind.ThemedImage = CType(resources.GetObject("btnReceiverFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnReceiverEdit
            '
            Me.btnReceiverEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnReceiverEdit.Image = CType(resources.GetObject("btnReceiverEdit.Image"), System.Drawing.Image)
            Me.btnReceiverEdit.Location = New System.Drawing.Point(656, 16)
            Me.btnReceiverEdit.Name = "btnReceiverEdit"
            Me.btnReceiverEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnReceiverEdit.TabIndex = 189
            Me.btnReceiverEdit.TabStop = False
            Me.btnReceiverEdit.ThemedImage = CType(resources.GetObject("btnReceiverEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(584, 168)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 7
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(496, 168)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 7
            Me.btnReset.Text = "เคลียร์"
            '
            'IncomingCheckFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "IncomingCheckFilterSubPanel"
            Me.Size = New System.Drawing.Size(744, 208)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.grbGeneral.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.grbDetail}")
            Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.grbGeneral}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.grbDocDate}")

            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.lblCode}")

            Me.lblCqCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.lblCqCode}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.lblStatus}")
            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Global.CustomerText}")
            Me.lblBank.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.lblBank}")
            Me.lblReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.lblReceive}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckFilterSubPanel.lblDocDateEnd}")

        End Sub
#End Region

#Region "Member"
        Dim m_receive As New Employee
        Dim m_cust As New Customer
        Dim m_bank As New Bank
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Private Property ReceiverPerson() As Employee
            Get
                Return m_receive
            End Get
            Set(ByVal Value As Employee)
                m_receive = Value
            End Set
        End Property
        Private Property Customer() As Customer
            Get
                Return m_cust
            End Get
            Set(ByVal Value As Customer)
                m_cust = Value
            End Set
        End Property
        Private Property Bank() As Bank
            Get
                Return m_bank
            End Get
            Set(ByVal Value As Bank)
                m_bank = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub Initialize()
            ' list in combobox
            IncomingCheckDocStatus.ListCodeDescriptionInComboBox(Me.cmbOutgoingCheck, "incomingcheck_docstatus")
            ' Clear item
            ClearCriterias()
        End Sub

        Private Sub ClearCriterias()
            For Each ctrl As Control In grbDetail.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

            Me.cmbOutgoingCheck.SelectedIndex = -1
            Me.cmbOutgoingCheck.SelectedIndex = -1

            Me.ReceiverPerson = New Employee
            Me.Customer = New Customer
            Me.Bank = New Bank

            Me.dtpDocDateStart.Value = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.dtpDocDateEnd.Value = Date.Now

            EntityRefresh()
        End Sub


        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(7) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.TextLength = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("cqcode", IIf(Me.txtCqCode.TextLength = 0, DBNull.Value, Me.txtCqCode.Text))
            arr(2) = New Filter("receiver", IIf(Me.ReceiverPerson.Valid, Me.ReceiverPerson.Id, DBNull.Value))
            arr(3) = New Filter("customer", IIf(Me.Customer.Valid, Me.Customer.Id, DBNull.Value))
            arr(4) = New Filter("bank", IIf(Me.Bank.Valid, Me.Bank.Id, DBNull.Value))
            Dim docstatus As Integer
            Dim docstatusPair As Object = cmbOutgoingCheck.SelectedItem
            If TypeOf docstatusPair Is IdValuePair Then
                docstatus = CType(docstatusPair, IdValuePair).Id
            End If
            arr(5) = New Filter("status", IIf(Me.cmbOutgoingCheck.SelectedIndex < 0 Or Me.cmbOutgoingCheck.SelectedIndex > 6, DBNull.Value, docstatus))
            arr(6) = New Filter("startdate", Me.dtpDocDateStart.Value)
            arr(7) = New Filter("enddate", Me.dtpDocDateEnd.Value)
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

#Region "TextBox Validated"
        Private Sub txtReceiveCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiveCode.Validated
            Employee.GetEmployee(txtReceiveCode, txtReceiveName, Me.ReceiverPerson)
        End Sub
        Private Sub txtCustomerCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerCode.Validated
            Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.Customer)
        End Sub

        Private Sub txtBankCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBankCode.Validated
            Bank.GetBank(txtBankCode, txtBankName, Me.Bank)
        End Sub
#End Region

#Region "Event of Button Handlers"
        Private Sub btnReceiverEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiverEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Employee)
        End Sub
        Private Sub btnReceiverFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiverFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Employee, AddressOf SetReceiver)
        End Sub
        Private Sub SetReceiver(ByVal e As ISimpleEntity)
            Me.txtReceiveCode.Text = e.Code
            Employee.GetEmployee(txtReceiveCode, txtReceiveName, Me.ReceiverPerson)
        End Sub

        Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Customer)
        End Sub
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
        End Sub
        Private Sub SetCustomer(ByVal e As ISimpleEntity)
            Me.txtCustomerCode.Text = e.Code
            Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.Customer)
        End Sub

        Private Sub btnBankEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankEdit.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Bank)
        End Sub

        Private Sub btnBankFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankFind.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Bank, AddressOf SetBank)
        End Sub
        Private Sub SetBank(ByVal e As ISimpleEntity)
            Me.txtBankCode.Text = e.Code
            Bank.GetBank(txtBankCode, txtBankName, Me.Bank)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' ผู้รับเช็ค
                If data.GetDataPresent((New Employee).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtreceivecode", "txtreceivename"
                                Return True
                        End Select
                    End If
                End If
                ' ลูกค้า
                If data.GetDataPresent((New Customer).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcustomercode", "txtcustomername"
                                Return True
                        End Select
                    End If
                End If
                ' ธนาคาร
                If data.GetDataPresent((New Bank).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtbankcode", "txtbankname"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Employee).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
                Dim entity As New Employee(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtreceivecode", "txtreceivename"
                            Me.SetReceiver(entity)
                    End Select
                End If
            End If
            If data.GetDataPresent((New Customer).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
                Dim entity As New Customer(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcustomercode", "txtcustomername"
                            Me.SetCustomer(entity)
                    End Select
                End If
            End If
            If data.GetDataPresent((New Bank).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Bank).FullClassName))
                Dim entity As New Bank(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtbankcode", "txtbankname"
                            Me.SetBank(entity)
                    End Select
                End If
            End If
        End Sub
#End Region

        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                EntityRefresh()
            End Set
        End Property
        Private Sub EntityRefresh()
            If Entities Is Nothing Then
                Return
            End If

            For Each entity As ISimpleEntity In Entities
                If TypeOf entity Is IncomingCheck Then
                    Dim obj As IncomingCheck = CType(entity, IncomingCheck)
                    If Not obj.DocStatus Is Nothing AndAlso obj.DocStatus.Value > -1 Then
                        If obj.DocStatus.Value = 99 Then
                            Dim specialdoc As New IdValuePair(99, "เช็คในมือ , เช็คนำฝาก")
                            cmbOutgoingCheck.Items.Add(specialdoc)
                            Me.cmbOutgoingCheck.SelectedIndex = cmbOutgoingCheck.Items.Count - 1
                        Else
                            For Each item As IdValuePair In cmbOutgoingCheck.Items
                                If item.Id = obj.DocStatus.Value Then
                                    Me.cmbOutgoingCheck.SelectedItem = item
                                End If
                            Next
                        End If
                        Me.cmbOutgoingCheck.Enabled = False

                    End If
                    ' recieve person
                    If obj.ReceivePerson.Originated Then
                        Me.SetReceiver(obj.ReceivePerson)
                        Me.txtReceiveCode.Enabled = False
                        Me.txtReceiveName.Enabled = False
                        Me.btnReceiverEdit.Enabled = False
                        Me.btnReceiverFind.Enabled = False
                    End If
                    ' customer 
                    If obj.Customer.Originated Then
                        Me.SetCustomer(obj.Customer)
                        Me.txtCustomerCode.Enabled = False
                        Me.txtCustomerName.Enabled = False
                        Me.btnCustomerEdit.Enabled = False
                        Me.btnCustomerFind.Enabled = False
                    End If
                    ' Bank ...
                    If obj.Bank.Originated Then
                        Me.SetBank(obj.Bank)
                        Me.txtBankCode.Enabled = False
                        Me.txtBankName.Enabled = False
                        Me.btnBankEdit.Enabled = False
                        Me.btnBankFind.Enabled = False
                    End If
                    ' Bankaccount
                    If obj.BankAccount.Originated Then
                        Me.SetBank(obj.Bank)
                        Me.txtBankCode.Enabled = False
                        Me.txtBankName.Enabled = False
                        Me.btnBankEdit.Enabled = False
                        Me.btnBankFind.Enabled = False
                    End If

                End If
                If TypeOf entity Is Customer Then
                    Me.SetCustomer(CType(entity, Customer))
                    Me.txtCustomerCode.Enabled = False
                    Me.txtCustomerName.Enabled = False
                    Me.btnCustomerEdit.Enabled = False
                    Me.btnCustomerFind.Enabled = False
                End If
            Next
        End Sub

    End Class
End Namespace

