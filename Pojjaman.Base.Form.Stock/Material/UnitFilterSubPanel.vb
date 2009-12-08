Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class UnitFilterSubPanel
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
        Friend WithEvents cmbUnitType As System.Windows.Forms.ComboBox
        Friend WithEvents lblUnitType As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.cmbUnitType = New System.Windows.Forms.ComboBox
            Me.lblUnitType = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.cmbUnitType)
            Me.grbDetail.Controls.Add(Me.lblUnitType)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(808, 88)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            '
            'txtCode
            '
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCode.Location = New System.Drawing.Point(120, 16)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(176, 21)
            Me.txtCode.TabIndex = 198
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 199
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbUnitType
            '
            Me.cmbUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbUnitType.Location = New System.Drawing.Point(120, 40)
            Me.cmbUnitType.Name = "cmbUnitType"
            Me.cmbUnitType.Size = New System.Drawing.Size(104, 21)
            Me.cmbUnitType.TabIndex = 3
            '
            'lblUnitType
            '
            Me.lblUnitType.BackColor = System.Drawing.Color.Transparent
            Me.lblUnitType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnitType.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblUnitType.Location = New System.Drawing.Point(16, 40)
            Me.lblUnitType.Name = "lblUnitType"
            Me.lblUnitType.Size = New System.Drawing.Size(104, 18)
            Me.lblUnitType.TabIndex = 197
            Me.lblUnitType.Text = "ประเภท:"
            Me.lblUnitType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(224, 40)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(72, 24)
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.TabStop = False
            Me.btnSearch.Text = "Search"
            '
            'UnitFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "UnitFilterSubPanel"
            Me.Size = New System.Drawing.Size(832, 104)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()

        End Sub
#End Region

#Region "Members"
#End Region

#Region "Methods"
        Public Sub Initialize()
            PopulateType()
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()

        End Sub
        Private Sub PopulateType()
            Me.cmbUnitType.Items.AddRange(New Object() _
            { _
            Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.All}") _
            , Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.Default}") _
            , Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.UserDefined}") _
            })
            cmbUnitType.SelectedIndex = 0
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.lblUnitType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.lblUnitType}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(1) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            Dim unitIsDefault As Object
            Select Case Me.cmbUnitType.SelectedIndex
                Case -1, 0
                    unitIsDefault = DBNull.Value
                Case 1
                    unitIsDefault = True
                Case 2
                    unitIsDefault = False
            End Select
            arr(1) = New Filter("unit_default", unitIsDefault)
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub cmbUnitType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUnitType.SelectedIndexChanged
            'OnSearch(e)
        End Sub
#End Region

    End Class
End Namespace

