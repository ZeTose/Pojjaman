Imports System.Data.SqlClient
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AdvancedSearch
        Inherits System.Windows.Forms.UserControl

#Region "Members"
        Private m_criterias As SearchCriteriaCollection
        Private m_currentCriteria As SearchCriteria
        Private m_currentCriteriaType As CriteriaType
#End Region

#Region "Constructors"
        Public Sub New(ByVal criterias As SearchCriteriaCollection)
            MyBase.New()
            InitializeComponent()

            m_criterias = criterias
            If m_criterias Is Nothing Then
                Return
            End If
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.Text = myStringParserService.Parse(m_criterias.PanelText)
            PopulateCriteriaList()
        End Sub
#End Region

#Region "Methods"
        Private Sub PopulateCriteriaList()

            Me.cmbCriterias.Items.Add(New RangeCriteria("name", GetType(String), "Name", "A", "Z"))
            Me.cmbCriterias.Items.Add(New RangeCriteria("address", GetType(String), "Address", "A", "Z"))

            lstOperators.Items.Add(New ANDCriteria)
            lstOperators.Items.Add(New ORCriteria)
            lstOperators.Items.Add(New OpenParenthesisCriteria)
            lstOperators.Items.Add(New CloseParenthesisCriteria)

            Me.cmbCriterias.SelectedIndex = 0
            Me.cmbCriteriaType.SelectedIndex = 0
        End Sub
#End Region

#Region "Properties"
        Public Property Criterias() As SearchCriteriaCollection            Get                Return m_criterias            End Get            Set(ByVal Value As SearchCriteriaCollection)                m_criterias = Value            End Set        End Property
#End Region

#Region " Windows Form Designer generated code "

        'Form overrides dispose to clean up the component list.
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
        Friend WithEvents lstOperators As System.Windows.Forms.ListBox
        Friend WithEvents lstFinishedCriterias As System.Windows.Forms.ListBox
        Friend WithEvents cmbCriterias As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCriteriaType As System.Windows.Forms.ComboBox
        Friend WithEvents txtMinValue As System.Windows.Forms.TextBox
        Friend WithEvents txtMaxValue As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lstOperators = New System.Windows.Forms.ListBox
            Me.lstFinishedCriterias = New System.Windows.Forms.ListBox
            Me.cmbCriterias = New System.Windows.Forms.ComboBox
            Me.cmbCriteriaType = New System.Windows.Forms.ComboBox
            Me.txtMinValue = New System.Windows.Forms.TextBox
            Me.txtMaxValue = New System.Windows.Forms.TextBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.btnAdd = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'lstOperators
            '
            Me.lstOperators.Location = New System.Drawing.Point(512, 8)
            Me.lstOperators.Name = "lstOperators"
            Me.lstOperators.Size = New System.Drawing.Size(112, 121)
            Me.lstOperators.TabIndex = 1
            '
            'lstFinishedCriterias
            '
            Me.lstFinishedCriterias.Location = New System.Drawing.Point(8, 72)
            Me.lstFinishedCriterias.Name = "lstFinishedCriterias"
            Me.lstFinishedCriterias.Size = New System.Drawing.Size(448, 225)
            Me.lstFinishedCriterias.TabIndex = 2
            '
            'cmbCriterias
            '
            Me.cmbCriterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCriterias.Location = New System.Drawing.Point(8, 16)
            Me.cmbCriterias.Name = "cmbCriterias"
            Me.cmbCriterias.Size = New System.Drawing.Size(160, 21)
            Me.cmbCriterias.TabIndex = 3
            '
            'cmbCriteriaType
            '
            Me.cmbCriteriaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCriteriaType.Items.AddRange(New Object() {"Is", "From"})
            Me.cmbCriteriaType.Location = New System.Drawing.Point(184, 16)
            Me.cmbCriteriaType.Name = "cmbCriteriaType"
            Me.cmbCriteriaType.Size = New System.Drawing.Size(64, 21)
            Me.cmbCriteriaType.TabIndex = 4
            '
            'txtMinValue
            '
            Me.txtMinValue.Location = New System.Drawing.Point(256, 16)
            Me.txtMinValue.Name = "txtMinValue"
            Me.txtMinValue.TabIndex = 5
            Me.txtMinValue.Text = ""
            '
            'txtMaxValue
            '
            Me.txtMaxValue.Location = New System.Drawing.Point(400, 16)
            Me.txtMaxValue.Name = "txtMaxValue"
            Me.txtMaxValue.TabIndex = 6
            Me.txtMaxValue.Text = ""
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(368, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(17, 16)
            Me.Label1.TabIndex = 7
            Me.Label1.Text = "To"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnAdd
            '
            Me.btnAdd.Location = New System.Drawing.Point(8, 40)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.TabIndex = 8
            Me.btnAdd.Text = "Add"
            '
            'AdvancedSearch
            '
            Me.Controls.Add(Me.btnAdd)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.txtMaxValue)
            Me.Controls.Add(Me.txtMinValue)
            Me.Controls.Add(Me.cmbCriteriaType)
            Me.Controls.Add(Me.cmbCriterias)
            Me.Controls.Add(Me.lstFinishedCriterias)
            Me.Controls.Add(Me.lstOperators)
            Me.Name = "AdvancedSearch"
            Me.Size = New System.Drawing.Size(640, 328)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Event Handlers"
        Private Sub ListDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstOperators.DoubleClick
            Me.lstFinishedCriterias.Items.Add(CType(sender, ListBox).SelectedItem)
        End Sub
        Private Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriteriaType.SelectedIndexChanged, cmbCriterias.SelectedIndexChanged
            Test()
        End Sub
        Private Sub Test()
            Dim myCriteria As RangeCriteria = CType(cmbCriterias.SelectedItem, RangeCriteria)
      Select Case cmbCriteriaType.SelectedItem.ToString
        Case "Is"
          Me.m_currentCriteria = New FixValueCriteria(myCriteria.Name, myCriteria.Type, myCriteria.LabelText, myCriteria.DefaultMinValue)
          Me.txtMinValue.Text = CType(m_currentCriteria, FixValueCriteria).DefautValue.ToString
          Me.txtMaxValue.Text = ""
          Me.txtMaxValue.Visible = False
          Me.Label1.Visible = False
        Case "From"
          Me.m_currentCriteria = New RangeCriteria(myCriteria.Name, myCriteria.Type, myCriteria.LabelText, myCriteria.DefaultMinValue, myCriteria.DefaultMaxValue)
          Me.txtMinValue.Text = CType(m_currentCriteria, RangeCriteria).DefaultMinValue.ToString
          Me.txtMaxValue.Text = CType(m_currentCriteria, RangeCriteria).DefaultMaxValue.ToString
          Me.txtMaxValue.Visible = True
          Me.Label1.Visible = True
      End Select
        End Sub
        Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Me.lstFinishedCriterias.Items.Add(Me.m_currentCriteria)
        End Sub
        Private Sub txtMinValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMinValue.TextChanged, txtMaxValue.TextChanged
            Select Case Me.m_currentCriteria.CriteriaType
                Case CriteriaType.FixValue
                    CType(m_currentCriteria, FixValueCriteria).Value = txtMinValue.Text
                Case CriteriaType.Range
                    CType(m_currentCriteria, RangeCriteria).MinValue = txtMinValue.Text
                    CType(m_currentCriteria, RangeCriteria).MaxValue = txtMaxValue.Text
            End Select
        End Sub
#End Region

    End Class
End Namespace
