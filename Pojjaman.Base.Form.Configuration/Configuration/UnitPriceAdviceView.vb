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
    Public Class UnitPriceAdviceView
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
        Friend WithEvents grbDetail As FixedGroupBox
        Friend WithEvents lbl1 As System.Windows.Forms.Label
        Friend WithEvents txtMonth As System.Windows.Forms.TextBox
        Friend WithEvents lblMonth As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lbl1 = New System.Windows.Forms.Label
            Me.txtMonth = New System.Windows.Forms.TextBox
            Me.lblMonth = New System.Windows.Forms.Label
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.txtMonth)
            Me.grbDetail.Controls.Add(Me.lblMonth)
            Me.grbDetail.Controls.Add(Me.lbl1)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(480, 56)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            '
            'lbl1
            '
            Me.lbl1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lbl1.Location = New System.Drawing.Point(16, 24)
            Me.lbl1.Name = "lbl1"
            Me.lbl1.Size = New System.Drawing.Size(208, 14)
            Me.lbl1.TabIndex = 0
            Me.lbl1.Text = "จำนวนเดือนย้อนหลังสำหรับตัวช่วยค่าวัสดุ"
            Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtMonth
            '
            Me.txtMonth.Location = New System.Drawing.Point(320, 22)
            Me.txtMonth.Name = "txtMonth"
            Me.txtMonth.Size = New System.Drawing.Size(80, 21)
            Me.txtMonth.TabIndex = 1
            Me.txtMonth.Text = ""
            '
            'lblMonth
            '
            Me.lblMonth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.lblMonth.Location = New System.Drawing.Point(408, 24)
            Me.lblMonth.Name = "lblMonth"
            Me.lblMonth.Size = New System.Drawing.Size(56, 14)
            Me.lblMonth.TabIndex = 0
            Me.lblMonth.Text = "เดือน"
            Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'UnitPriceAdviceView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "UnitPriceAdviceView"
            Me.Size = New System.Drawing.Size(500, 304)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_isInitialized As Boolean
        Public ConfigFilters(0) As Filter
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
        End Sub
        Public Sub SetLabelText()
            Me.lbl1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitPriceAdviceView.lbl1}")
            Me.lblMonth.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitPriceAdviceView.lblMonth}")
        End Sub
        Protected Sub EventWiring()
            AddHandler txtMonth.TextChanged, AddressOf ChangeProperty
            AddHandler txtMonth.Validated, AddressOf TextHandler
        End Sub
        Public Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "txtmonth"
                    Dim txt As String = Me.txtMonth.Text
                    Dim val As Integer
                    If txt.Length > 0 AndAlso IsNumeric(txt) Then
                        val = CInt(txt)
                    Else
                        val = 0
                    End If
                    Me.SetFilterValue("ActualPricePeriod", val)
                    txtMonth.Text = Configuration.FormatToString(val, DigitConfig.Int)
            End Select
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtmonth"
                    dirtyFlag = True
            End Select
            Dirty = Dirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Sub Initialize()
            ConfigFilters(0) = New Filter("ActualPricePeriod", Configuration.GetConfig("ActualPricePeriod"))
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

            Me.txtMonth.Text = Configuration.FormatToString(CDec(GetFilterValue("ActualPricePeriod")), DigitConfig.Int)

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