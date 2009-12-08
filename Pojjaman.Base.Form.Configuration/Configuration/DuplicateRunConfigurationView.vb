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
  Public Class DuplicateRunConfigurationView
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
    Friend WithEvents chkNoDup As System.Windows.Forms.CheckBox
    Friend WithEvents chkPutPONoteInGR As System.Windows.Forms.CheckBox
    Friend WithEvents chkPutGRNoteInOtherTabs As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.chkNoDup = New System.Windows.Forms.CheckBox
      Me.chkPutPONoteInGR = New System.Windows.Forms.CheckBox
      Me.chkPutGRNoteInOtherTabs = New System.Windows.Forms.CheckBox
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Nothing
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'chkNoDup
      '
      Me.chkNoDup.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNoDup.Location = New System.Drawing.Point(24, 24)
      Me.chkNoDup.Name = "chkNoDup"
      Me.chkNoDup.Size = New System.Drawing.Size(376, 24)
      Me.chkNoDup.TabIndex = 0
      Me.chkNoDup.Text = "ไม่อนุญาตให้เลขที่เอกสารซ้ำกันหากเป็น supplier รายเดียวกัน"
      '
      'chkPutPONoteInGR
      '
      Me.chkPutPONoteInGR.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPutPONoteInGR.Location = New System.Drawing.Point(24, 48)
      Me.chkPutPONoteInGR.Name = "chkPutPONoteInGR"
      Me.chkPutPONoteInGR.Size = New System.Drawing.Size(312, 24)
      Me.chkPutPONoteInGR.TabIndex = 1
      Me.chkPutPONoteInGR.Text = "ดึงหมายเหตุจากใบสั่งซื้อมายังหน้าซื้อสินค้า/บริการ"
      '
      'chkPutGRNoteInOtherTabs
      '
      Me.chkPutGRNoteInOtherTabs.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPutGRNoteInOtherTabs.Location = New System.Drawing.Point(24, 72)
      Me.chkPutGRNoteInOtherTabs.Name = "chkPutGRNoteInOtherTabs"
      Me.chkPutGRNoteInOtherTabs.Size = New System.Drawing.Size(296, 24)
      Me.chkPutGRNoteInOtherTabs.TabIndex = 2
      Me.chkPutGRNoteInOtherTabs.Text = "ดึงหมายเหตุจาก Tab รายละเอียดรับของไปที่ Tab อื่นๆ"
      '
      'DuplicateRunConfigurationView
      '
      Me.Controls.Add(Me.chkPutGRNoteInOtherTabs)
      Me.Controls.Add(Me.chkPutPONoteInGR)
      Me.Controls.Add(Me.chkNoDup)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "DuplicateRunConfigurationView"
      Me.Size = New System.Drawing.Size(472, 256)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean
    Public ConfigFilters(2) As Filter
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
      Me.chkNoDup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkNoDup}")
      Me.chkPutPONoteInGR.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkPutPONoteInGR}")
      Me.chkPutGRNoteInOtherTabs.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ApproveConfigurationView.chkPutGRNoteInOtherTabs}")
    End Sub
    Protected Sub EventWiring()
      AddHandler chkNoDup.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPutPONoteInGR.CheckedChanged, AddressOf ChangeProperty
      AddHandler chkPutGRNoteInOtherTabs.CheckedChanged, AddressOf ChangeProperty
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "chknodup"
          Me.SetFilterValue("NoDupSupplierDoc", chkNoDup.Checked)
          dirtyFlag = True
        Case "chkputponoteingr"
          Me.SetFilterValue("PutPONoteInGR", chkPutPONoteInGR.Checked)
          dirtyFlag = True
        Case "chkputgrnoteinothertabs"
          Me.SetFilterValue("PutGRNoteInOtherTabs", chkPutGRNoteInOtherTabs.Checked)
          dirtyFlag = True
      End Select
      Dirty = Dirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub Initialize()
      ConfigFilters(0) = New Filter("NoDupSupplierDoc", Configuration.GetConfig("NoDupSupplierDoc"))
      ConfigFilters(1) = New Filter("PutPONoteInGR", Configuration.GetConfig("PutPONoteInGR"))
      ConfigFilters(2) = New Filter("PutGRNoteInOtherTabs", Configuration.GetConfig("PutGRNoteInOtherTabs"))
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
      Me.chkNoDup.Checked = CBool(GetFilterValue("NoDupSupplierDoc"))
      Me.chkPutPONoteInGR.Checked = CBool(GetFilterValue("PutPONoteInGR"))
      Me.chkPutGRNoteInOtherTabs.Checked = CBool(GetFilterValue("PutGRNoteInOtherTabs"))
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