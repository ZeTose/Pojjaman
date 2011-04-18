Imports Longkong.Core.Services
Imports System.Collections.Generic
Imports Longkong.Pojjaman.BusinessLogic
Imports System.ComponentModel
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class IntervalDialog
    Inherits System.Windows.Forms.UserControl

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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grbInterval As System.Windows.Forms.GroupBox
    Friend WithEvents txtdocdate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents nudInt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCCName As System.Windows.Forms.TextBox
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IntervalDialog))
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.grbInterval = New System.Windows.Forms.GroupBox()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCode = New System.Windows.Forms.TextBox()
      Me.txtCCName = New System.Windows.Forms.TextBox()
      Me.nudInt = New System.Windows.Forms.NumericUpDown()
      Me.txtdocdate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.grbInterval.SuspendLayout()
      CType(Me.nudInt, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnOK.ForeColor = System.Drawing.Color.Black
      Me.btnOK.Location = New System.Drawing.Point(113, 139)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(96, 23)
      Me.btnOK.TabIndex = 3
      Me.btnOK.Text = "btnOK"
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.Black
      Me.btnCancel.Location = New System.Drawing.Point(217, 139)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(96, 23)
      Me.btnCancel.TabIndex = 4
      Me.btnCancel.Text = "btnCancel"
      '
      'grbInterval
      '
      Me.grbInterval.Controls.Add(Me.chkIncludeChildren)
      Me.grbInterval.Controls.Add(Me.Label2)
      Me.grbInterval.Controls.Add(Me.Label1)
      Me.grbInterval.Controls.Add(Me.btnCCFind)
      Me.grbInterval.Controls.Add(Me.txtCCCode)
      Me.grbInterval.Controls.Add(Me.txtCCName)
      Me.grbInterval.Controls.Add(Me.nudInt)
      Me.grbInterval.Controls.Add(Me.txtdocdate)
      Me.grbInterval.Controls.Add(Me.dtpDocDate)
      Me.grbInterval.Controls.Add(Me.lblDocDate)
      Me.grbInterval.Location = New System.Drawing.Point(13, 3)
      Me.grbInterval.Name = "grbInterval"
      Me.grbInterval.Size = New System.Drawing.Size(306, 128)
      Me.grbInterval.TabIndex = 7
      Me.grbInterval.TabStop = False
      Me.grbInterval.Text = "รอบเวลา"
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.AutoSize = True
      Me.chkIncludeChildren.Location = New System.Drawing.Point(85, 99)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(117, 17)
      Me.chkIncludeChildren.TabIndex = 20
      Me.chkIncludeChildren.Text = "รวม cost center ลูก"
      Me.chkIncludeChildren.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(7, 72)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(78, 18)
      Me.Label2.TabIndex = 19
      Me.Label2.Text = "Cost Center :"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(10, 45)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(75, 18)
      Me.Label1.TabIndex = 18
      Me.Label1.Text = "จำนวนช่วง:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCCFind
      '
      Me.btnCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCFind.Location = New System.Drawing.Point(278, 70)
      Me.btnCCFind.Name = "btnCCFind"
      Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
      Me.btnCCFind.TabIndex = 15
      Me.btnCCFind.TabStop = False
      Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCode
      '
      Me.txtCCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtCCCode.Location = New System.Drawing.Point(85, 72)
      Me.txtCCCode.Name = "txtCCCode"
      Me.txtCCCode.Size = New System.Drawing.Size(61, 21)
      Me.txtCCCode.TabIndex = 16
      '
      'txtCCName
      '
      Me.txtCCName.Enabled = False
      Me.txtCCName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtCCName.Location = New System.Drawing.Point(148, 72)
      Me.txtCCName.Name = "txtCCName"
      Me.txtCCName.ReadOnly = True
      Me.txtCCName.Size = New System.Drawing.Size(129, 21)
      Me.txtCCName.TabIndex = 17
      Me.txtCCName.TabStop = False
      '
      'nudInt
      '
      Me.nudInt.Location = New System.Drawing.Point(85, 45)
      Me.nudInt.Name = "nudInt"
      Me.nudInt.Size = New System.Drawing.Size(120, 21)
      Me.nudInt.TabIndex = 9
      '
      'txtdocdate
      '
      Me.txtdocdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtdocdate.Location = New System.Drawing.Point(85, 17)
      Me.txtdocdate.Name = "txtdocdate"
      Me.txtdocdate.Size = New System.Drawing.Size(110, 21)
      Me.txtdocdate.TabIndex = 7
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(85, 17)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(128, 21)
      Me.dtpDocDate.TabIndex = 8
      Me.dtpDocDate.TabStop = False
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocDate.Location = New System.Drawing.Point(10, 17)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(75, 18)
      Me.lblDocDate.TabIndex = 6
      Me.lblDocDate.Text = "วันที่เริ่มต้น:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'IntervalDialog
      '
      Me.Controls.Add(Me.grbInterval)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "IntervalDialog"
      Me.Size = New System.Drawing.Size(332, 162)
      Me.grbInterval.ResumeLayout(False)
      Me.grbInterval.PerformLayout()
      CType(Me.nudInt, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_StringParserService As StringParserService
    Private m_startdate As Date
    Private m_int As Integer
    Private m_cc As CostCenter
    Private m_includechild As Boolean
    Private m_ccid As Decimal

#End Region


#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler txtdocdate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler nudInt.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler chkIncludeChildren.CheckedChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "dtpdocdate"
          If Not Me.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtdocdate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDate = dtpDocDate.Value
            End If
          End If
          m_dateSetting = False
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtdocdate.Text.Length = 0 Then
            Dim theDate As Date = CDate(Me.txtdocdate.Text)
            If Not Me.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.DocDate = dtpDocDate.Value
            End If
          Else
            Me.dtpDocDate.Value = Date.Now
            Me.DocDate = Date.MinValue
          End If
          m_dateSetting = False
        Case "nudint"
          m_int = CInt(nudInt.Value)
        Case "chkincludechildren"
          m_includechild = chkIncludeChildren.Checked
        Case Else

      End Select
    End Sub
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()

      Dim sps As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Me.btnCancel.Text = sps.Parse("${res:Global.CancelButtonText}")
      Me.btnOK.Text = sps.Parse("${res:Global.OKButtonText}")
    End Sub

    Public Sub New(ByVal ffType As FFormatAutoType, ByVal StartDate As Date, ByVal Int As Integer, ByVal cc As Decimal, ByVal includechild As Boolean)
      Me.New()
      Select Case ffType.Value
        Case 2 'Month
          grbInterval.Text = "รายเดือน"
        Case 3 'Quarter
          grbInterval.Text = "รายไตรมาส"
        Case 4 'Year
          grbInterval.Text = "รายปี"
      End Select

      DocDate = StartDate
      m_int = Int
      m_ccid = cc
      m_includechild = includechild

      txtdocdate.Text = DocDate.ToShortDateString
      dtpDocDate.Value = DocDate
      m_cc = New CostCenter(CInt(m_ccid))

      If m_cc IsNot Nothing Then
        txtCCCode.Text = m_cc.Code
        txtCCName.Text = m_cc.Name
      End If
      
      chkIncludeChildren.Checked = m_includechild
      nudInt.Value = m_int
      EventWiring()

    End Sub
#End Region

#Region "Properties"
    Public Property DocDate As Date
    Public ReadOnly Property ccID As Decimal
      Get
        Return m_ccid
      End Get
    End Property

    Public ReadOnly Property NumCol As Integer
      Get
        Return m_int
      End Get
    End Property
    Public ReadOnly Property IncChild As Boolean
      Get
        Return m_includechild
      End Get
    End Property

#End Region

#Region "Methods"
    Private Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
      If dt.Equals(Date.MinValue) Then
        Return nullString
      End If
      Return dt.ToShortDateString
    End Function
    <Browsable(False)> _
    Private ReadOnly Property StringParserService() As StringParserService
      Get
        If m_StringParserService Is Nothing Then
          m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End If
        Return m_StringParserService
      End Get
    End Property

#End Region

#Region " Event Handlers "
    Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCCCode.Validated
      CostCenter.GetCostCenter(txtCCCode, Me.txtCCName, Me.m_cc)
      If m_cc IsNot Nothing Then
        m_ccid = m_cc.Id
      End If
    End Sub

    Private Sub btnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnccfind"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetCostCenter)
      End Select
    End Sub

    Private Sub SetCostCenter(ByVal e As ISimpleEntity)
      Me.txtCCCode.Text = e.Code
      CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.m_cc)
      If m_cc IsNot Nothing Then
        m_ccid = m_cc.Id
      End If
    End Sub

#End Region
  End Class
End Namespace