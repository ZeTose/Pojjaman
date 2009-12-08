Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AccountPeriodFilterSubPanel
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
        Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
        Friend WithEvents lblYear As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbYear = New System.Windows.Forms.ComboBox
            Me.lblYear = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.cmbYear)
            Me.grbDetail.Controls.Add(Me.lblYear)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(808, 104)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            '
            'cmbYear
            '
            Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbYear.Location = New System.Drawing.Point(120, 24)
            Me.cmbYear.Name = "cmbYear"
            Me.cmbYear.Size = New System.Drawing.Size(104, 21)
            Me.cmbYear.TabIndex = 3
            '
            'lblYear
            '
            Me.lblYear.BackColor = System.Drawing.Color.Transparent
            Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblYear.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblYear.Location = New System.Drawing.Point(16, 24)
            Me.lblYear.Name = "lblYear"
            Me.lblYear.Size = New System.Drawing.Size(104, 18)
            Me.lblYear.TabIndex = 197
            Me.lblYear.Text = "ª’¿“…’:"
            Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(224, 24)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(72, 24)
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.TabStop = False
            Me.btnSearch.Text = "Search"
            '
            'AccountPeriodFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "AccountPeriodFilterSubPanel"
            Me.Size = New System.Drawing.Size(832, 120)
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
            PopulateStatus()
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()

        End Sub
        Private Sub PopulateStatus()
            Dim years(9) As Date
            For i As Integer = 0 To 9
                years(i) = New Date(2005 + i, 1, 1)
            Next
            Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
            myDateTimeService.ListYearsInComboBox(Me.cmbYear, years)
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodFilterSubPanel.grbDetail}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodFilterSubPanel.lblYear}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(0) As Filter
            arr(0) = New Filter("year", IIf(CDate(cmbYear.SelectedValue).Equals(Date.MinValue), DBNull.Value, Me.cmbYear.SelectedValue))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Event Handlers"
        Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
            OnSearch(e)
            Me.btnSearch.PerformClick()
        End Sub
#End Region

    End Class
End Namespace

