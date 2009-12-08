Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AliasConfigurationView
        'Inherits UserControl
        Inherits AbstractOptionPanel
        Implements IValidatable

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
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents pnlSupplier As System.Windows.Forms.Panel
        Friend WithEvents rdSupplierNoAlias As System.Windows.Forms.RadioButton
        Friend WithEvents rdSupplierAlias As System.Windows.Forms.RadioButton
        Friend WithEvents lblSupplier As System.Windows.Forms.Label
        Friend WithEvents pnlCustomer As System.Windows.Forms.Panel
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents rdCustAlias As System.Windows.Forms.RadioButton
        Friend WithEvents rdCustNoAlias As System.Windows.Forms.RadioButton
        Friend WithEvents pnlAcct As System.Windows.Forms.Panel
        Friend WithEvents lblAcct As System.Windows.Forms.Label
        Friend WithEvents rdAcctAlias As System.Windows.Forms.RadioButton
        Friend WithEvents rdAcctNoAlias As System.Windows.Forms.RadioButton
        Friend WithEvents pnlLCI As System.Windows.Forms.Panel
        Friend WithEvents lblLCI As System.Windows.Forms.Label
        Friend WithEvents rdLCIAlias As System.Windows.Forms.RadioButton
        Friend WithEvents rdLCINoAlias As System.Windows.Forms.RadioButton
        Friend WithEvents pnlTool As System.Windows.Forms.Panel
        Friend WithEvents lblTool As System.Windows.Forms.Label
        Friend WithEvents rdToolAlias As System.Windows.Forms.RadioButton
        Friend WithEvents rdToolNoAlias As System.Windows.Forms.RadioButton
        Friend WithEvents grbDetail As FixedGroupBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.pnlSupplier = New System.Windows.Forms.Panel
            Me.lblSupplier = New System.Windows.Forms.Label
            Me.rdSupplierAlias = New System.Windows.Forms.RadioButton
            Me.rdSupplierNoAlias = New System.Windows.Forms.RadioButton
            Me.pnlCustomer = New System.Windows.Forms.Panel
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.rdCustAlias = New System.Windows.Forms.RadioButton
            Me.rdCustNoAlias = New System.Windows.Forms.RadioButton
            Me.pnlAcct = New System.Windows.Forms.Panel
            Me.lblAcct = New System.Windows.Forms.Label
            Me.rdAcctAlias = New System.Windows.Forms.RadioButton
            Me.rdAcctNoAlias = New System.Windows.Forms.RadioButton
            Me.pnlLCI = New System.Windows.Forms.Panel
            Me.lblLCI = New System.Windows.Forms.Label
            Me.rdLCIAlias = New System.Windows.Forms.RadioButton
            Me.rdLCINoAlias = New System.Windows.Forms.RadioButton
            Me.pnlTool = New System.Windows.Forms.Panel
            Me.lblTool = New System.Windows.Forms.Label
            Me.rdToolAlias = New System.Windows.Forms.RadioButton
            Me.rdToolNoAlias = New System.Windows.Forms.RadioButton
            Me.grbDetail = New FixedGroupBox
            Me.pnlSupplier.SuspendLayout()
            Me.pnlCustomer.SuspendLayout()
            Me.pnlAcct.SuspendLayout()
            Me.pnlLCI.SuspendLayout()
            Me.pnlTool.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'pnlSupplier
            '
            Me.pnlSupplier.Controls.Add(Me.lblSupplier)
            Me.pnlSupplier.Controls.Add(Me.rdSupplierAlias)
            Me.pnlSupplier.Controls.Add(Me.rdSupplierNoAlias)
            Me.pnlSupplier.Location = New System.Drawing.Point(16, 16)
            Me.pnlSupplier.Name = "pnlSupplier"
            Me.pnlSupplier.Size = New System.Drawing.Size(272, 48)
            Me.pnlSupplier.TabIndex = 0
            '
            'lblSupplier
            '
            Me.lblSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblSupplier.Location = New System.Drawing.Point(8, 18)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(64, 23)
            Me.lblSupplier.TabIndex = 0
            Me.lblSupplier.Text = "ชื่อ Supplier"
            Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'rdSupplierAlias
            '
            Me.rdSupplierAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdSupplierAlias.Location = New System.Drawing.Point(160, 15)
            Me.rdSupplierAlias.Name = "rdSupplierAlias"
            Me.rdSupplierAlias.TabIndex = 2
            Me.rdSupplierAlias.Text = "ใช้ชื่ออื่น"
            '
            'rdSupplierNoAlias
            '
            Me.rdSupplierNoAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdSupplierNoAlias.Location = New System.Drawing.Point(80, 15)
            Me.rdSupplierNoAlias.Name = "rdSupplierNoAlias"
            Me.rdSupplierNoAlias.TabIndex = 1
            Me.rdSupplierNoAlias.Text = "ใช้ชื่อแรก"
            '
            'pnlCustomer
            '
            Me.pnlCustomer.Controls.Add(Me.lblCustomer)
            Me.pnlCustomer.Controls.Add(Me.rdCustAlias)
            Me.pnlCustomer.Controls.Add(Me.rdCustNoAlias)
            Me.pnlCustomer.Location = New System.Drawing.Point(16, 64)
            Me.pnlCustomer.Name = "pnlCustomer"
            Me.pnlCustomer.Size = New System.Drawing.Size(272, 48)
            Me.pnlCustomer.TabIndex = 1
            '
            'lblCustomer
            '
            Me.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblCustomer.Location = New System.Drawing.Point(8, 18)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(64, 23)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "ชื่อลูกค้า"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'rdCustAlias
            '
            Me.rdCustAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdCustAlias.Location = New System.Drawing.Point(160, 15)
            Me.rdCustAlias.Name = "rdCustAlias"
            Me.rdCustAlias.TabIndex = 2
            Me.rdCustAlias.Text = "ใช้ชื่ออื่น"
            '
            'rdCustNoAlias
            '
            Me.rdCustNoAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdCustNoAlias.Location = New System.Drawing.Point(80, 15)
            Me.rdCustNoAlias.Name = "rdCustNoAlias"
            Me.rdCustNoAlias.TabIndex = 1
            Me.rdCustNoAlias.Text = "ใช้ชื่อแรก"
            '
            'pnlAcct
            '
            Me.pnlAcct.Controls.Add(Me.lblAcct)
            Me.pnlAcct.Controls.Add(Me.rdAcctAlias)
            Me.pnlAcct.Controls.Add(Me.rdAcctNoAlias)
            Me.pnlAcct.Location = New System.Drawing.Point(16, 112)
            Me.pnlAcct.Name = "pnlAcct"
            Me.pnlAcct.Size = New System.Drawing.Size(272, 48)
            Me.pnlAcct.TabIndex = 2
            '
            'lblAcct
            '
            Me.lblAcct.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblAcct.Location = New System.Drawing.Point(8, 18)
            Me.lblAcct.Name = "lblAcct"
            Me.lblAcct.Size = New System.Drawing.Size(64, 23)
            Me.lblAcct.TabIndex = 0
            Me.lblAcct.Text = "ชื่อบัญชี"
            Me.lblAcct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'rdAcctAlias
            '
            Me.rdAcctAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdAcctAlias.Location = New System.Drawing.Point(160, 15)
            Me.rdAcctAlias.Name = "rdAcctAlias"
            Me.rdAcctAlias.TabIndex = 2
            Me.rdAcctAlias.Text = "ใช้ชื่ออื่น"
            '
            'rdAcctNoAlias
            '
            Me.rdAcctNoAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdAcctNoAlias.Location = New System.Drawing.Point(80, 15)
            Me.rdAcctNoAlias.Name = "rdAcctNoAlias"
            Me.rdAcctNoAlias.TabIndex = 1
            Me.rdAcctNoAlias.Text = "ใช้ชื่อแรก"
            '
            'pnlLCI
            '
            Me.pnlLCI.Controls.Add(Me.lblLCI)
            Me.pnlLCI.Controls.Add(Me.rdLCIAlias)
            Me.pnlLCI.Controls.Add(Me.rdLCINoAlias)
            Me.pnlLCI.Location = New System.Drawing.Point(16, 160)
            Me.pnlLCI.Name = "pnlLCI"
            Me.pnlLCI.Size = New System.Drawing.Size(272, 48)
            Me.pnlLCI.TabIndex = 3
            '
            'lblLCI
            '
            Me.lblLCI.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblLCI.Location = New System.Drawing.Point(8, 18)
            Me.lblLCI.Name = "lblLCI"
            Me.lblLCI.Size = New System.Drawing.Size(64, 23)
            Me.lblLCI.TabIndex = 0
            Me.lblLCI.Text = "ชื่อวัสดุ"
            Me.lblLCI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'rdLCIAlias
            '
            Me.rdLCIAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdLCIAlias.Location = New System.Drawing.Point(160, 15)
            Me.rdLCIAlias.Name = "rdLCIAlias"
            Me.rdLCIAlias.TabIndex = 2
            Me.rdLCIAlias.Text = "ใช้ชื่ออื่น"
            '
            'rdLCINoAlias
            '
            Me.rdLCINoAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdLCINoAlias.Location = New System.Drawing.Point(80, 15)
            Me.rdLCINoAlias.Name = "rdLCINoAlias"
            Me.rdLCINoAlias.TabIndex = 1
            Me.rdLCINoAlias.Text = "ใช้ชื่อแรก"
            '
            'pnlTool
            '
            Me.pnlTool.Controls.Add(Me.lblTool)
            Me.pnlTool.Controls.Add(Me.rdToolAlias)
            Me.pnlTool.Controls.Add(Me.rdToolNoAlias)
            Me.pnlTool.Location = New System.Drawing.Point(16, 208)
            Me.pnlTool.Name = "pnlTool"
            Me.pnlTool.Size = New System.Drawing.Size(272, 48)
            Me.pnlTool.TabIndex = 4
            '
            'lblTool
            '
            Me.lblTool.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblTool.Location = New System.Drawing.Point(8, 18)
            Me.lblTool.Name = "lblTool"
            Me.lblTool.Size = New System.Drawing.Size(64, 23)
            Me.lblTool.TabIndex = 0
            Me.lblTool.Text = "ชื่อเครื่องมือ"
            Me.lblTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'rdToolAlias
            '
            Me.rdToolAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdToolAlias.Location = New System.Drawing.Point(160, 15)
            Me.rdToolAlias.Name = "rdToolAlias"
            Me.rdToolAlias.TabIndex = 2
            Me.rdToolAlias.Text = "ใช้ชื่ออื่น"
            '
            'rdToolNoAlias
            '
            Me.rdToolNoAlias.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdToolNoAlias.Location = New System.Drawing.Point(80, 15)
            Me.rdToolNoAlias.Name = "rdToolNoAlias"
            Me.rdToolNoAlias.TabIndex = 1
            Me.rdToolNoAlias.Text = "ใช้ชื่อแรก"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.pnlSupplier)
            Me.grbDetail.Controls.Add(Me.pnlLCI)
            Me.grbDetail.Controls.Add(Me.pnlCustomer)
            Me.grbDetail.Controls.Add(Me.pnlTool)
            Me.grbDetail.Controls.Add(Me.pnlAcct)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(296, 264)
            Me.grbDetail.TabIndex = 5
            Me.grbDetail.TabStop = False
            '
            'AliasConfigurationView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "AliasConfigurationView"
            Me.Size = New System.Drawing.Size(320, 288)
            Me.pnlSupplier.ResumeLayout(False)
            Me.pnlCustomer.ResumeLayout(False)
            Me.pnlAcct.ResumeLayout(False)
            Me.pnlLCI.ResumeLayout(False)
            Me.pnlTool.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_isInitialized As Boolean
        Public ConfigFilters(4) As Filter
        Private Dirty As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Me.SetLabelText()
            Initialize()
            EventWiring()
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
        Public Sub CheckFormEnable()
        End Sub
        Public Sub ClearDetail()
            Me.rdAcctNoAlias.PerformClick()
            Me.rdCustNoAlias.PerformClick()
            Me.rdLCINoAlias.PerformClick()
            Me.rdSupplierNoAlias.PerformClick()
            Me.rdToolNoAlias.PerformClick()
        End Sub
        Public Sub SetLabelText()
            Me.rdSupplierNoAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.NoAlias}")
            Me.rdSupplierAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.Alias}")
            Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.lblSupplier}")
            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.lblCustomer}")
            Me.rdCustAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.Alias}")
            Me.rdCustNoAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.NoAlias}")
            Me.lblAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.lblAcct}")
            Me.rdAcctAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.Alias}")
            Me.rdAcctNoAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.NoAlias}")
            Me.lblLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.lblLCI}")
            Me.rdLCIAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.Alias}")
            Me.rdLCINoAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.NoAlias}")
            Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.lblTool}")
            Me.rdToolAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.Alias}")
            Me.rdToolNoAlias.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AliasConfigurationView.NoAlias}")
        End Sub
        Protected Sub EventWiring()
            AddHandler rdAcctAlias.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdAcctNoAlias.CheckedChanged, AddressOf ChangeProperty

            AddHandler rdCustAlias.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdCustNoAlias.CheckedChanged, AddressOf ChangeProperty

            AddHandler rdLCIAlias.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdLCINoAlias.CheckedChanged, AddressOf ChangeProperty

            AddHandler rdSupplierAlias.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdSupplierNoAlias.CheckedChanged, AddressOf ChangeProperty

            AddHandler rdToolAlias.CheckedChanged, AddressOf ChangeProperty
            AddHandler rdToolNoAlias.CheckedChanged, AddressOf ChangeProperty

        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "rdacctalias", "rdacctnoalias"
                    If rdAcctNoAlias.Checked Then
                        SetFilterValue("UseAcctAlias", 0)
                    Else
                        SetFilterValue("UseAcctAlias", 1)
                    End If
                    dirtyFlag = True
                Case "rdcustalias", "rdcustnoalias"
                    If rdCustNoAlias.Checked Then
                        SetFilterValue("UseCustAlias", 0)
                    Else
                        SetFilterValue("UseCustAlias", 1)
                    End If
                    dirtyFlag = True
                Case "rdlcialias", "rdlcinoalias"
                    If rdLCINoAlias.Checked Then
                        SetFilterValue("UseLCIAlias", 0)
                    Else
                        SetFilterValue("UseLCIAlias", 1)
                    End If
                    dirtyFlag = True
                Case "rdsupplieralias", "rdsuppliernoalias"
                    If rdSupplierNoAlias.Checked Then
                        SetFilterValue("UseSupplierAlias", 0)
                    Else
                        SetFilterValue("UseSupplierAlias", 1)
                    End If
                    dirtyFlag = True
                Case "rdtoolalias", "rdtoolnoalias"
                    If rdToolNoAlias.Checked Then
                        SetFilterValue("UseToolAlias", 0)
                    Else
                        SetFilterValue("UseToolAlias", 1)
                    End If
                    dirtyFlag = True
            End Select
            Dirty = Dirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Sub Initialize()
            ConfigFilters(0) = New Filter("UseSupplierAlias", Configuration.GetConfig("UseSupplierAlias"))
            ConfigFilters(1) = New Filter("UseCustAlias", Configuration.GetConfig("UseCustAlias"))
            ConfigFilters(2) = New Filter("UseAcctAlias", Configuration.GetConfig("UseAcctAlias"))
            ConfigFilters(3) = New Filter("UseLCIAlias", Configuration.GetConfig("UseLCIAlias"))
            ConfigFilters(4) = New Filter("UseToolAlias", Configuration.GetConfig("UseToolAlias"))
        End Sub
        Private Sub SetFilterValue(ByVal name As String, ByVal value As Object)
            For Each filter As filter In ConfigFilters
                If filter.Name.ToLower = name.ToLower Then
                    filter.Value = value
                    Exit For
                End If
            Next
        End Sub
        Private Function GetFilterValue(ByVal name As String) As Object
            For Each filter As filter In ConfigFilters
                If filter.Name.ToLower = name.ToLower Then
                    Return filter.Value
                End If
            Next
        End Function
#End Region

#Region "Methods"
#End Region

#Region "Event Handers"
        Private Sub ibtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
#End Region

#Region "Overrides"
        Public Overloads Overrides Sub LoadPanelContents()
            m_isInitialized = False
            ClearDetail()

            If CInt(GetFilterValue("UseSupplierAlias")) = 0 Then
                Me.rdSupplierNoAlias.PerformClick()
            Else
                Me.rdSupplierAlias.PerformClick()
            End If

            If CInt(GetFilterValue("UseCustAlias")) = 0 Then
                Me.rdCustNoAlias.PerformClick()
            Else
                Me.rdCustAlias.PerformClick()
            End If

            If CInt(GetFilterValue("UseAcctAlias")) = 0 Then
                Me.rdAcctNoAlias.PerformClick()
            Else
                Me.rdAcctAlias.PerformClick()
            End If

            If CInt(GetFilterValue("UseLCIAlias")) = 0 Then
                Me.rdLCINoAlias.PerformClick()
            Else
                Me.rdLCIAlias.PerformClick()
            End If

            If CInt(GetFilterValue("UseToolAlias")) = 0 Then
                Me.rdToolNoAlias.PerformClick()
            Else
                Me.rdToolAlias.PerformClick()
            End If

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Overloads Overrides Function StorePanelContents() As Boolean
            If Not m_isInitialized Then
                Return True
            End If
            If Not Dirty Then
                Return True
            End If
            Configuration.Save(Me.ConfigFilters)
            Return True
        End Function
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

    End Class
End Namespace