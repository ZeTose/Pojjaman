Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ProjectReceivePaymentDetailView
    'Inherits UserControl
    Inherits AbstractEntityDetailPanelView
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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblAccountPeriodStart As System.Windows.Forms.Label
    Friend WithEvents tDeliverDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents tProjectName As System.Windows.Forms.TextBox
    Friend WithEvents tProjectCode As System.Windows.Forms.TextBox
    Friend WithEvents iFindProjectDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents tAccountDateStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents tSentMileStoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents tMileStoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents tReceiveNumber As System.Windows.Forms.TextBox
    Friend WithEvents tReceiveMileStoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblSentMileStoneNumber As System.Windows.Forms.Label
    Friend WithEvents lblMileStoneNumber As System.Windows.Forms.Label
    Friend WithEvents lblReceiveNumber As System.Windows.Forms.Label
    Friend WithEvents lblReceiveMileStoneNumber As System.Windows.Forms.Label
    Friend WithEvents tReceiveAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblReceiveAmount As System.Windows.Forms.Label
    Friend WithEvents tContractAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblContract As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cNoExpenditure As System.Windows.Forms.CheckBox
    Friend WithEvents cNoRevenue As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rDeliverUnNormal As System.Windows.Forms.RadioButton
    Friend WithEvents rDeliver As System.Windows.Forms.RadioButton
    Friend WithEvents tDeliverNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblDeliverNumber As System.Windows.Forms.Label
    Friend WithEvents grbAccountPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents tAccountDateEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblAccountPeriodEnd As System.Windows.Forms.Label
    Friend WithEvents tAcceptPerson2Name As System.Windows.Forms.TextBox
    Friend WithEvents tAcceptPerson1Name As System.Windows.Forms.TextBox
    Friend WithEvents tAcceptPerson2 As System.Windows.Forms.TextBox
    Friend WithEvents iFindEmployee2 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tAcceptPerson1 As System.Windows.Forms.TextBox
    Friend WithEvents iFindEmployee1 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblAcceptPerson2 As System.Windows.Forms.Label
    Friend WithEvents lblAcceptPerson1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents tBindingFinishedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents rBindingFinished As System.Windows.Forms.RadioButton
    Friend WithEvents rUnBindingFinished As System.Windows.Forms.RadioButton
    Friend WithEvents lblPeriod2 As System.Windows.Forms.Label
    Friend WithEvents lblPeriod3 As System.Windows.Forms.Label
    Friend WithEvents lblPeriod1 As System.Windows.Forms.Label
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents lblBaht1 As System.Windows.Forms.Label
    Friend WithEvents cCode As System.Windows.Forms.ComboBox
    Friend WithEvents ibtnRefresh As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tAcceptPosition2 As System.Windows.Forms.TextBox
    Friend WithEvents tAcceptPosition As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCostCenter As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents ibottonShowValue As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectReceivePaymentDetailView))
      Me.lblItem = New System.Windows.Forms.Label()
      Me.lblAccountPeriodStart = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.tProjectName = New System.Windows.Forms.TextBox()
      Me.tProjectCode = New System.Windows.Forms.TextBox()
      Me.tDeliverNumber = New System.Windows.Forms.TextBox()
      Me.tContractAmount = New System.Windows.Forms.TextBox()
      Me.tMileStoneNumber = New System.Windows.Forms.TextBox()
      Me.tReceiveMileStoneNumber = New System.Windows.Forms.TextBox()
      Me.tReceiveAmount = New System.Windows.Forms.TextBox()
      Me.tReceiveNumber = New System.Windows.Forms.TextBox()
      Me.tSentMileStoneNumber = New System.Windows.Forms.TextBox()
      Me.tAcceptPerson1 = New System.Windows.Forms.TextBox()
      Me.tAcceptPerson1Name = New System.Windows.Forms.TextBox()
      Me.tAcceptPerson2 = New System.Windows.Forms.TextBox()
      Me.tAcceptPerson2Name = New System.Windows.Forms.TextBox()
      Me.tAcceptPosition = New System.Windows.Forms.TextBox()
      Me.tAcceptPosition2 = New System.Windows.Forms.TextBox()
      Me.txtCostCenter = New System.Windows.Forms.TextBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.tDeliverDate = New DevExpress.XtraEditors.DateEdit()
      Me.lblDate = New System.Windows.Forms.Label()
      Me.iFindProjectDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblProject = New System.Windows.Forms.Label()
      Me.tAccountDateStart = New DevExpress.XtraEditors.DateEdit()
      Me.lblAccountPeriodEnd = New System.Windows.Forms.Label()
      Me.tAccountDateEnd = New DevExpress.XtraEditors.DateEdit()
      Me.grbAccountPeriod = New System.Windows.Forms.GroupBox()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.rDeliverUnNormal = New System.Windows.Forms.RadioButton()
      Me.rDeliver = New System.Windows.Forms.RadioButton()
      Me.lblDeliverNumber = New System.Windows.Forms.Label()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.cNoExpenditure = New System.Windows.Forms.CheckBox()
      Me.cNoRevenue = New System.Windows.Forms.CheckBox()
      Me.GroupBox4 = New System.Windows.Forms.GroupBox()
      Me.lblSentMileStoneNumber = New System.Windows.Forms.Label()
      Me.lblMileStoneNumber = New System.Windows.Forms.Label()
      Me.lblReceiveNumber = New System.Windows.Forms.Label()
      Me.lblReceiveMileStoneNumber = New System.Windows.Forms.Label()
      Me.lblPeriod2 = New System.Windows.Forms.Label()
      Me.lblPeriod3 = New System.Windows.Forms.Label()
      Me.lblPeriod1 = New System.Windows.Forms.Label()
      Me.lblPeriod = New System.Windows.Forms.Label()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.lblReceiveAmount = New System.Windows.Forms.Label()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.lblContract = New System.Windows.Forms.Label()
      Me.lblBaht1 = New System.Windows.Forms.Label()
      Me.lblAcceptPerson1 = New System.Windows.Forms.Label()
      Me.iFindEmployee1 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAcceptPerson2 = New System.Windows.Forms.Label()
      Me.iFindEmployee2 = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.GroupBox6 = New System.Windows.Forms.GroupBox()
      Me.tBindingFinishedDate = New DevExpress.XtraEditors.DateEdit()
      Me.rBindingFinished = New System.Windows.Forms.RadioButton()
      Me.rUnBindingFinished = New System.Windows.Forms.RadioButton()
      Me.cCode = New System.Windows.Forms.ComboBox()
      Me.ibtnRefresh = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.ibottonShowValue = New Longkong.Pojjaman.Gui.Components.ImageButton()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tDeliverDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tDeliverDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tAccountDateStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tAccountDateStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tAccountDateEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tAccountDateEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbAccountPeriod.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.GroupBox4.SuspendLayout()
      Me.GroupBox6.SuspendLayout()
      CType(Me.tBindingFinishedDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tBindingFinishedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(30, 267)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(92, 18)
      Me.lblItem.TabIndex = 15
      Me.lblItem.Text = "รายการ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAccountPeriodStart
      '
      Me.lblAccountPeriodStart.BackColor = System.Drawing.Color.Transparent
      Me.lblAccountPeriodStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountPeriodStart.Location = New System.Drawing.Point(17, 21)
      Me.lblAccountPeriodStart.Name = "lblAccountPeriodStart"
      Me.lblAccountPeriodStart.Size = New System.Drawing.Size(41, 18)
      Me.lblAccountPeriodStart.TabIndex = 12
      Me.lblAccountPeriodStart.Text = "ตั้งแต่:"
      Me.lblAccountPeriodStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'tProjectName
      '
      Me.Validator.SetDataType(Me.tProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tProjectName, "")
      Me.Validator.SetGotFocusBackColor(Me.tProjectName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tProjectName, System.Drawing.Color.Empty)
      Me.tProjectName.Location = New System.Drawing.Point(237, 56)
      Me.Validator.SetMaxValue(Me.tProjectName, "")
      Me.Validator.SetMinValue(Me.tProjectName, "")
      Me.tProjectName.Name = "tProjectName"
      Me.tProjectName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.tProjectName, "")
      Me.Validator.SetRequired(Me.tProjectName, False)
      Me.tProjectName.Size = New System.Drawing.Size(212, 20)
      Me.tProjectName.TabIndex = 331
      Me.tProjectName.TabStop = False
      '
      'tProjectCode
      '
      Me.tProjectCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.tProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tProjectCode, "")
      Me.Validator.SetGotFocusBackColor(Me.tProjectCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tProjectCode, System.Drawing.Color.Empty)
      Me.tProjectCode.Location = New System.Drawing.Point(121, 56)
      Me.Validator.SetMaxValue(Me.tProjectCode, "")
      Me.Validator.SetMinValue(Me.tProjectCode, "")
      Me.tProjectCode.Name = "tProjectCode"
      Me.Validator.SetRegularExpression(Me.tProjectCode, "")
      Me.Validator.SetRequired(Me.tProjectCode, True)
      Me.tProjectCode.Size = New System.Drawing.Size(116, 20)
      Me.tProjectCode.TabIndex = 2
      '
      'tDeliverNumber
      '
      Me.Validator.SetDataType(Me.tDeliverNumber, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tDeliverNumber, "")
      Me.tDeliverNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.tDeliverNumber, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tDeliverNumber, System.Drawing.Color.Empty)
      Me.tDeliverNumber.Location = New System.Drawing.Point(125, 24)
      Me.tDeliverNumber.MaxLength = 20
      Me.Validator.SetMaxValue(Me.tDeliverNumber, "")
      Me.Validator.SetMinValue(Me.tDeliverNumber, "")
      Me.tDeliverNumber.Name = "tDeliverNumber"
      Me.Validator.SetRegularExpression(Me.tDeliverNumber, "")
      Me.Validator.SetRequired(Me.tDeliverNumber, False)
      Me.tDeliverNumber.Size = New System.Drawing.Size(34, 21)
      Me.tDeliverNumber.TabIndex = 3
      Me.tDeliverNumber.TabStop = False
      Me.tDeliverNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tContractAmount
      '
      Me.Validator.SetDataType(Me.tContractAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tContractAmount, "")
      Me.tContractAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.tContractAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tContractAmount, System.Drawing.Color.Empty)
      Me.tContractAmount.Location = New System.Drawing.Point(110, 36)
      Me.tContractAmount.MaxLength = 20
      Me.Validator.SetMaxValue(Me.tContractAmount, "")
      Me.Validator.SetMinValue(Me.tContractAmount, "")
      Me.tContractAmount.Name = "tContractAmount"
      Me.Validator.SetRegularExpression(Me.tContractAmount, "")
      Me.Validator.SetRequired(Me.tContractAmount, False)
      Me.tContractAmount.Size = New System.Drawing.Size(99, 21)
      Me.tContractAmount.TabIndex = 0
      Me.tContractAmount.TabStop = False
      Me.tContractAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tMileStoneNumber
      '
      Me.Validator.SetDataType(Me.tMileStoneNumber, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tMileStoneNumber, "")
      Me.tMileStoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.tMileStoneNumber, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tMileStoneNumber, System.Drawing.Color.Empty)
      Me.tMileStoneNumber.Location = New System.Drawing.Point(110, 60)
      Me.tMileStoneNumber.MaxLength = 20
      Me.Validator.SetMaxValue(Me.tMileStoneNumber, "")
      Me.Validator.SetMinValue(Me.tMileStoneNumber, "")
      Me.tMileStoneNumber.Name = "tMileStoneNumber"
      Me.Validator.SetRegularExpression(Me.tMileStoneNumber, "")
      Me.Validator.SetRequired(Me.tMileStoneNumber, False)
      Me.tMileStoneNumber.Size = New System.Drawing.Size(99, 21)
      Me.tMileStoneNumber.TabIndex = 2
      Me.tMileStoneNumber.TabStop = False
      Me.tMileStoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tReceiveMileStoneNumber
      '
      Me.Validator.SetDataType(Me.tReceiveMileStoneNumber, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tReceiveMileStoneNumber, "")
      Me.tReceiveMileStoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.tReceiveMileStoneNumber, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tReceiveMileStoneNumber, System.Drawing.Color.Empty)
      Me.tReceiveMileStoneNumber.Location = New System.Drawing.Point(110, 84)
      Me.tReceiveMileStoneNumber.MaxLength = 20
      Me.Validator.SetMaxValue(Me.tReceiveMileStoneNumber, "")
      Me.Validator.SetMinValue(Me.tReceiveMileStoneNumber, "")
      Me.tReceiveMileStoneNumber.Name = "tReceiveMileStoneNumber"
      Me.Validator.SetRegularExpression(Me.tReceiveMileStoneNumber, "")
      Me.Validator.SetRequired(Me.tReceiveMileStoneNumber, False)
      Me.tReceiveMileStoneNumber.Size = New System.Drawing.Size(99, 21)
      Me.tReceiveMileStoneNumber.TabIndex = 4
      Me.tReceiveMileStoneNumber.TabStop = False
      Me.tReceiveMileStoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tReceiveAmount
      '
      Me.Validator.SetDataType(Me.tReceiveAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tReceiveAmount, "")
      Me.tReceiveAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.tReceiveAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tReceiveAmount, System.Drawing.Color.Empty)
      Me.tReceiveAmount.Location = New System.Drawing.Point(365, 38)
      Me.tReceiveAmount.MaxLength = 20
      Me.Validator.SetMaxValue(Me.tReceiveAmount, "")
      Me.Validator.SetMinValue(Me.tReceiveAmount, "")
      Me.tReceiveAmount.Name = "tReceiveAmount"
      Me.Validator.SetRegularExpression(Me.tReceiveAmount, "")
      Me.Validator.SetRequired(Me.tReceiveAmount, False)
      Me.tReceiveAmount.Size = New System.Drawing.Size(99, 21)
      Me.tReceiveAmount.TabIndex = 1
      Me.tReceiveAmount.TabStop = False
      Me.tReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tReceiveNumber
      '
      Me.Validator.SetDataType(Me.tReceiveNumber, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tReceiveNumber, "")
      Me.tReceiveNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.tReceiveNumber, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tReceiveNumber, System.Drawing.Color.Empty)
      Me.tReceiveNumber.Location = New System.Drawing.Point(365, 86)
      Me.tReceiveNumber.MaxLength = 20
      Me.Validator.SetMaxValue(Me.tReceiveNumber, "")
      Me.Validator.SetMinValue(Me.tReceiveNumber, "")
      Me.tReceiveNumber.Name = "tReceiveNumber"
      Me.Validator.SetRegularExpression(Me.tReceiveNumber, "")
      Me.Validator.SetRequired(Me.tReceiveNumber, False)
      Me.tReceiveNumber.Size = New System.Drawing.Size(99, 21)
      Me.tReceiveNumber.TabIndex = 5
      Me.tReceiveNumber.TabStop = False
      Me.tReceiveNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tSentMileStoneNumber
      '
      Me.Validator.SetDataType(Me.tSentMileStoneNumber, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tSentMileStoneNumber, "")
      Me.tSentMileStoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.tSentMileStoneNumber, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tSentMileStoneNumber, System.Drawing.Color.Empty)
      Me.tSentMileStoneNumber.Location = New System.Drawing.Point(365, 62)
      Me.tSentMileStoneNumber.MaxLength = 20
      Me.Validator.SetMaxValue(Me.tSentMileStoneNumber, "")
      Me.Validator.SetMinValue(Me.tSentMileStoneNumber, "")
      Me.tSentMileStoneNumber.Name = "tSentMileStoneNumber"
      Me.Validator.SetRegularExpression(Me.tSentMileStoneNumber, "")
      Me.Validator.SetRequired(Me.tSentMileStoneNumber, False)
      Me.tSentMileStoneNumber.Size = New System.Drawing.Size(99, 21)
      Me.tSentMileStoneNumber.TabIndex = 3
      Me.tSentMileStoneNumber.TabStop = False
      Me.tSentMileStoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tAcceptPerson1
      '
      Me.tAcceptPerson1.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.tAcceptPerson1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tAcceptPerson1, "")
      Me.Validator.SetGotFocusBackColor(Me.tAcceptPerson1, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tAcceptPerson1, System.Drawing.Color.Empty)
      Me.tAcceptPerson1.Location = New System.Drawing.Point(887, 88)
      Me.Validator.SetMaxValue(Me.tAcceptPerson1, "")
      Me.Validator.SetMinValue(Me.tAcceptPerson1, "")
      Me.tAcceptPerson1.Name = "tAcceptPerson1"
      Me.Validator.SetRegularExpression(Me.tAcceptPerson1, "")
      Me.Validator.SetRequired(Me.tAcceptPerson1, False)
      Me.tAcceptPerson1.Size = New System.Drawing.Size(83, 20)
      Me.tAcceptPerson1.TabIndex = 4
      '
      'tAcceptPerson1Name
      '
      Me.Validator.SetDataType(Me.tAcceptPerson1Name, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tAcceptPerson1Name, "")
      Me.Validator.SetGotFocusBackColor(Me.tAcceptPerson1Name, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tAcceptPerson1Name, System.Drawing.Color.Empty)
      Me.tAcceptPerson1Name.Location = New System.Drawing.Point(971, 88)
      Me.Validator.SetMaxValue(Me.tAcceptPerson1Name, "")
      Me.Validator.SetMinValue(Me.tAcceptPerson1Name, "")
      Me.tAcceptPerson1Name.Name = "tAcceptPerson1Name"
      Me.tAcceptPerson1Name.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.tAcceptPerson1Name, "")
      Me.Validator.SetRequired(Me.tAcceptPerson1Name, False)
      Me.tAcceptPerson1Name.Size = New System.Drawing.Size(178, 20)
      Me.tAcceptPerson1Name.TabIndex = 331
      Me.tAcceptPerson1Name.TabStop = False
      '
      'tAcceptPerson2
      '
      Me.tAcceptPerson2.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.tAcceptPerson2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tAcceptPerson2, "")
      Me.Validator.SetGotFocusBackColor(Me.tAcceptPerson2, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tAcceptPerson2, System.Drawing.Color.Empty)
      Me.tAcceptPerson2.Location = New System.Drawing.Point(887, 148)
      Me.Validator.SetMaxValue(Me.tAcceptPerson2, "")
      Me.Validator.SetMinValue(Me.tAcceptPerson2, "")
      Me.tAcceptPerson2.Name = "tAcceptPerson2"
      Me.Validator.SetRegularExpression(Me.tAcceptPerson2, "")
      Me.Validator.SetRequired(Me.tAcceptPerson2, False)
      Me.tAcceptPerson2.Size = New System.Drawing.Size(83, 20)
      Me.tAcceptPerson2.TabIndex = 5
      '
      'tAcceptPerson2Name
      '
      Me.Validator.SetDataType(Me.tAcceptPerson2Name, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tAcceptPerson2Name, "")
      Me.Validator.SetGotFocusBackColor(Me.tAcceptPerson2Name, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tAcceptPerson2Name, System.Drawing.Color.Empty)
      Me.tAcceptPerson2Name.Location = New System.Drawing.Point(971, 148)
      Me.Validator.SetMaxValue(Me.tAcceptPerson2Name, "")
      Me.Validator.SetMinValue(Me.tAcceptPerson2Name, "")
      Me.tAcceptPerson2Name.Name = "tAcceptPerson2Name"
      Me.tAcceptPerson2Name.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.tAcceptPerson2Name, "")
      Me.Validator.SetRequired(Me.tAcceptPerson2Name, False)
      Me.tAcceptPerson2Name.Size = New System.Drawing.Size(178, 20)
      Me.tAcceptPerson2Name.TabIndex = 331
      Me.tAcceptPerson2Name.TabStop = False
      '
      'tAcceptPosition
      '
      Me.tAcceptPosition.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.tAcceptPosition, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tAcceptPosition, "")
      Me.Validator.SetGotFocusBackColor(Me.tAcceptPosition, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tAcceptPosition, System.Drawing.Color.Empty)
      Me.tAcceptPosition.Location = New System.Drawing.Point(887, 111)
      Me.Validator.SetMaxValue(Me.tAcceptPosition, "")
      Me.Validator.SetMinValue(Me.tAcceptPosition, "")
      Me.tAcceptPosition.Name = "tAcceptPosition"
      Me.Validator.SetRegularExpression(Me.tAcceptPosition, "")
      Me.Validator.SetRequired(Me.tAcceptPosition, False)
      Me.tAcceptPosition.Size = New System.Drawing.Size(262, 20)
      Me.tAcceptPosition.TabIndex = 4
      '
      'tAcceptPosition2
      '
      Me.tAcceptPosition2.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.tAcceptPosition2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.tAcceptPosition2, "")
      Me.Validator.SetGotFocusBackColor(Me.tAcceptPosition2, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.tAcceptPosition2, System.Drawing.Color.Empty)
      Me.tAcceptPosition2.Location = New System.Drawing.Point(887, 171)
      Me.Validator.SetMaxValue(Me.tAcceptPosition2, "")
      Me.Validator.SetMinValue(Me.tAcceptPosition2, "")
      Me.tAcceptPosition2.Name = "tAcceptPosition2"
      Me.Validator.SetRegularExpression(Me.tAcceptPosition2, "")
      Me.Validator.SetRequired(Me.tAcceptPosition2, False)
      Me.tAcceptPosition2.Size = New System.Drawing.Size(262, 20)
      Me.tAcceptPosition2.TabIndex = 4
      '
      'txtCostCenter
      '
      Me.Validator.SetDataType(Me.txtCostCenter, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenter, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenter, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenter, System.Drawing.Color.Empty)
      Me.txtCostCenter.Location = New System.Drawing.Point(110, 14)
      Me.Validator.SetMaxValue(Me.txtCostCenter, "")
      Me.Validator.SetMinValue(Me.txtCostCenter, "")
      Me.txtCostCenter.Name = "txtCostCenter"
      Me.txtCostCenter.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenter, "")
      Me.Validator.SetRequired(Me.txtCostCenter, False)
      Me.txtCostCenter.Size = New System.Drawing.Size(353, 20)
      Me.txtCostCenter.TabIndex = 331
      Me.txtCostCenter.TabStop = False
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(237, 9)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 9
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(40, 10)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 8
      Me.lblCode.Text = "เลขที่:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = False
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 295)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.PreferredRowHeight = 21
      Me.tgItem.Size = New System.Drawing.Size(1191, 263)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 10
      Me.tgItem.TreeManager = Nothing
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(257, 8)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 327
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      '
      'tDeliverDate
      '
      Me.tDeliverDate.EditValue = Nothing
      Me.tDeliverDate.Location = New System.Drawing.Point(121, 33)
      Me.tDeliverDate.Name = "tDeliverDate"
      Me.tDeliverDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
      Me.tDeliverDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
      Me.tDeliverDate.Size = New System.Drawing.Size(100, 20)
      Me.tDeliverDate.TabIndex = 1
      '
      'lblDate
      '
      Me.lblDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDate.ForeColor = System.Drawing.Color.Black
      Me.lblDate.Location = New System.Drawing.Point(52, 33)
      Me.lblDate.Name = "lblDate"
      Me.lblDate.Size = New System.Drawing.Size(65, 18)
      Me.lblDate.TabIndex = 8
      Me.lblDate.Text = "วันที่ยื่น:"
      Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'iFindProjectDialog
      '
      Me.iFindProjectDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.iFindProjectDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.iFindProjectDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.iFindProjectDialog.Location = New System.Drawing.Point(450, 54)
      Me.iFindProjectDialog.Name = "iFindProjectDialog"
      Me.iFindProjectDialog.Size = New System.Drawing.Size(24, 23)
      Me.iFindProjectDialog.TabIndex = 332
      Me.iFindProjectDialog.TabStop = False
      Me.iFindProjectDialog.ThemedImage = CType(resources.GetObject("iFindProjectDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblProject
      '
      Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProject.Location = New System.Drawing.Point(29, 56)
      Me.lblProject.Name = "lblProject"
      Me.lblProject.Size = New System.Drawing.Size(91, 18)
      Me.lblProject.TabIndex = 330
      Me.lblProject.Text = "โครงการก่อสร้าง:"
      Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tAccountDateStart
      '
      Me.tAccountDateStart.EditValue = Nothing
      Me.tAccountDateStart.Location = New System.Drawing.Point(58, 20)
      Me.tAccountDateStart.Name = "tAccountDateStart"
      Me.tAccountDateStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
      Me.tAccountDateStart.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
      Me.tAccountDateStart.Size = New System.Drawing.Size(100, 20)
      Me.tAccountDateStart.TabIndex = 0
      '
      'lblAccountPeriodEnd
      '
      Me.lblAccountPeriodEnd.BackColor = System.Drawing.Color.Transparent
      Me.lblAccountPeriodEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccountPeriodEnd.Location = New System.Drawing.Point(27, 44)
      Me.lblAccountPeriodEnd.Name = "lblAccountPeriodEnd"
      Me.lblAccountPeriodEnd.Size = New System.Drawing.Size(31, 18)
      Me.lblAccountPeriodEnd.TabIndex = 12
      Me.lblAccountPeriodEnd.Text = "ถึง:"
      Me.lblAccountPeriodEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tAccountDateEnd
      '
      Me.tAccountDateEnd.EditValue = Nothing
      Me.tAccountDateEnd.Location = New System.Drawing.Point(58, 43)
      Me.tAccountDateEnd.Name = "tAccountDateEnd"
      Me.tAccountDateEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
      Me.tAccountDateEnd.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
      Me.tAccountDateEnd.Size = New System.Drawing.Size(100, 20)
      Me.tAccountDateEnd.TabIndex = 1
      '
      'grbAccountPeriod
      '
      Me.grbAccountPeriod.Controls.Add(Me.tAccountDateStart)
      Me.grbAccountPeriod.Controls.Add(Me.lblAccountPeriodStart)
      Me.grbAccountPeriod.Controls.Add(Me.tAccountDateEnd)
      Me.grbAccountPeriod.Controls.Add(Me.lblAccountPeriodEnd)
      Me.grbAccountPeriod.Location = New System.Drawing.Point(516, 79)
      Me.grbAccountPeriod.Name = "grbAccountPeriod"
      Me.grbAccountPeriod.Size = New System.Drawing.Size(274, 72)
      Me.grbAccountPeriod.TabIndex = 6
      Me.grbAccountPeriod.TabStop = False
      Me.grbAccountPeriod.Text = "รอบระยะเวลาบัญชี"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.rDeliverUnNormal)
      Me.GroupBox2.Controls.Add(Me.rDeliver)
      Me.GroupBox2.Controls.Add(Me.tDeliverNumber)
      Me.GroupBox2.Controls.Add(Me.lblDeliverNumber)
      Me.GroupBox2.Location = New System.Drawing.Point(516, 148)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(274, 63)
      Me.GroupBox2.TabIndex = 7
      Me.GroupBox2.TabStop = False
      '
      'rDeliverUnNormal
      '
      Me.rDeliverUnNormal.AccessibleName = "deliver"
      Me.rDeliverUnNormal.AutoSize = True
      Me.rDeliverUnNormal.Location = New System.Drawing.Point(15, 37)
      Me.rDeliverUnNormal.Name = "rDeliverUnNormal"
      Me.rDeliverUnNormal.Size = New System.Drawing.Size(67, 17)
      Me.rDeliverUnNormal.TabIndex = 2
      Me.rDeliverUnNormal.Text = "ยื่นแก้ไข"
      Me.rDeliverUnNormal.UseVisualStyleBackColor = True
      '
      'rDeliver
      '
      Me.rDeliver.AccessibleName = "deliver"
      Me.rDeliver.AutoSize = True
      Me.rDeliver.Checked = True
      Me.rDeliver.Location = New System.Drawing.Point(15, 14)
      Me.rDeliver.Name = "rDeliver"
      Me.rDeliver.Size = New System.Drawing.Size(61, 17)
      Me.rDeliver.TabIndex = 1
      Me.rDeliver.TabStop = True
      Me.rDeliver.Text = "ยื่นปกติ"
      Me.rDeliver.UseVisualStyleBackColor = True
      '
      'lblDeliverNumber
      '
      Me.lblDeliverNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDeliverNumber.ForeColor = System.Drawing.Color.Black
      Me.lblDeliverNumber.Location = New System.Drawing.Point(78, 25)
      Me.lblDeliverNumber.Name = "lblDeliverNumber"
      Me.lblDeliverNumber.Size = New System.Drawing.Size(48, 18)
      Me.lblDeliverNumber.TabIndex = 8
      Me.lblDeliverNumber.Text = "ครั้งที่:"
      Me.lblDeliverNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.cNoExpenditure)
      Me.GroupBox3.Controls.Add(Me.cNoRevenue)
      Me.GroupBox3.Location = New System.Drawing.Point(516, 208)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(274, 63)
      Me.GroupBox3.TabIndex = 8
      Me.GroupBox3.TabStop = False
      '
      'cNoExpenditure
      '
      Me.cNoExpenditure.AutoSize = True
      Me.cNoExpenditure.Location = New System.Drawing.Point(16, 37)
      Me.cNoExpenditure.Name = "cNoExpenditure"
      Me.cNoExpenditure.Size = New System.Drawing.Size(132, 17)
      Me.cNoExpenditure.TabIndex = 1
      Me.cNoExpenditure.Text = "รอบบัญชีนี้ไม่มีรายจ่าย"
      Me.cNoExpenditure.UseVisualStyleBackColor = True
      '
      'cNoRevenue
      '
      Me.cNoRevenue.AutoSize = True
      Me.cNoRevenue.Location = New System.Drawing.Point(16, 15)
      Me.cNoRevenue.Name = "cNoRevenue"
      Me.cNoRevenue.Size = New System.Drawing.Size(127, 17)
      Me.cNoRevenue.TabIndex = 0
      Me.cNoRevenue.Text = "รอบบัญชีนี้ไม่มีรายรับ"
      Me.cNoRevenue.UseVisualStyleBackColor = True
      '
      'GroupBox4
      '
      Me.GroupBox4.Controls.Add(Me.tSentMileStoneNumber)
      Me.GroupBox4.Controls.Add(Me.tMileStoneNumber)
      Me.GroupBox4.Controls.Add(Me.tReceiveNumber)
      Me.GroupBox4.Controls.Add(Me.tReceiveMileStoneNumber)
      Me.GroupBox4.Controls.Add(Me.lblSentMileStoneNumber)
      Me.GroupBox4.Controls.Add(Me.lblMileStoneNumber)
      Me.GroupBox4.Controls.Add(Me.txtCostCenter)
      Me.GroupBox4.Controls.Add(Me.lblReceiveNumber)
      Me.GroupBox4.Controls.Add(Me.lblReceiveMileStoneNumber)
      Me.GroupBox4.Controls.Add(Me.tReceiveAmount)
      Me.GroupBox4.Controls.Add(Me.lblPeriod2)
      Me.GroupBox4.Controls.Add(Me.lblPeriod3)
      Me.GroupBox4.Controls.Add(Me.lblPeriod1)
      Me.GroupBox4.Controls.Add(Me.lblPeriod)
      Me.GroupBox4.Controls.Add(Me.lblBaht)
      Me.GroupBox4.Controls.Add(Me.lblReceiveAmount)
      Me.GroupBox4.Controls.Add(Me.tContractAmount)
      Me.GroupBox4.Controls.Add(Me.lblCostCenter)
      Me.GroupBox4.Controls.Add(Me.lblContract)
      Me.GroupBox4.Controls.Add(Me.lblBaht1)
      Me.GroupBox4.Location = New System.Drawing.Point(11, 80)
      Me.GroupBox4.Name = "GroupBox4"
      Me.GroupBox4.Size = New System.Drawing.Size(499, 118)
      Me.GroupBox4.TabIndex = 3
      Me.GroupBox4.TabStop = False
      '
      'lblSentMileStoneNumber
      '
      Me.lblSentMileStoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSentMileStoneNumber.ForeColor = System.Drawing.Color.Black
      Me.lblSentMileStoneNumber.Location = New System.Drawing.Point(285, 63)
      Me.lblSentMileStoneNumber.Name = "lblSentMileStoneNumber"
      Me.lblSentMileStoneNumber.Size = New System.Drawing.Size(80, 18)
      Me.lblSentMileStoneNumber.TabIndex = 8
      Me.lblSentMileStoneNumber.Text = "ได้ส่งงานแล้ว:"
      Me.lblSentMileStoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMileStoneNumber
      '
      Me.lblMileStoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMileStoneNumber.ForeColor = System.Drawing.Color.Black
      Me.lblMileStoneNumber.Location = New System.Drawing.Point(30, 61)
      Me.lblMileStoneNumber.Name = "lblMileStoneNumber"
      Me.lblMileStoneNumber.Size = New System.Drawing.Size(80, 18)
      Me.lblMileStoneNumber.TabIndex = 8
      Me.lblMileStoneNumber.Text = "จำนวนงวดงาน:"
      Me.lblMileStoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblReceiveNumber
      '
      Me.lblReceiveNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReceiveNumber.ForeColor = System.Drawing.Color.Black
      Me.lblReceiveNumber.Location = New System.Drawing.Point(285, 87)
      Me.lblReceiveNumber.Name = "lblReceiveNumber"
      Me.lblReceiveNumber.Size = New System.Drawing.Size(80, 18)
      Me.lblReceiveNumber.TabIndex = 8
      Me.lblReceiveNumber.Text = "ได้รับเงินแล้ว:"
      Me.lblReceiveNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblReceiveMileStoneNumber
      '
      Me.lblReceiveMileStoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReceiveMileStoneNumber.ForeColor = System.Drawing.Color.Black
      Me.lblReceiveMileStoneNumber.Location = New System.Drawing.Point(2, 85)
      Me.lblReceiveMileStoneNumber.Name = "lblReceiveMileStoneNumber"
      Me.lblReceiveMileStoneNumber.Size = New System.Drawing.Size(108, 18)
      Me.lblReceiveMileStoneNumber.TabIndex = 8
      Me.lblReceiveMileStoneNumber.Text = "จำนวนงวดการรับเงิน:"
      Me.lblReceiveMileStoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPeriod2
      '
      Me.lblPeriod2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPeriod2.ForeColor = System.Drawing.Color.Black
      Me.lblPeriod2.Location = New System.Drawing.Point(210, 85)
      Me.lblPeriod2.Name = "lblPeriod2"
      Me.lblPeriod2.Size = New System.Drawing.Size(30, 18)
      Me.lblPeriod2.TabIndex = 8
      Me.lblPeriod2.Text = "งวด"
      Me.lblPeriod2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPeriod3
      '
      Me.lblPeriod3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPeriod3.ForeColor = System.Drawing.Color.Black
      Me.lblPeriod3.Location = New System.Drawing.Point(464, 88)
      Me.lblPeriod3.Name = "lblPeriod3"
      Me.lblPeriod3.Size = New System.Drawing.Size(30, 18)
      Me.lblPeriod3.TabIndex = 8
      Me.lblPeriod3.Text = "งวด"
      Me.lblPeriod3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPeriod1
      '
      Me.lblPeriod1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPeriod1.ForeColor = System.Drawing.Color.Black
      Me.lblPeriod1.Location = New System.Drawing.Point(464, 65)
      Me.lblPeriod1.Name = "lblPeriod1"
      Me.lblPeriod1.Size = New System.Drawing.Size(30, 18)
      Me.lblPeriod1.TabIndex = 8
      Me.lblPeriod1.Text = "งวด"
      Me.lblPeriod1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPeriod
      '
      Me.lblPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPeriod.ForeColor = System.Drawing.Color.Black
      Me.lblPeriod.Location = New System.Drawing.Point(210, 62)
      Me.lblPeriod.Name = "lblPeriod"
      Me.lblPeriod.Size = New System.Drawing.Size(30, 18)
      Me.lblPeriod.TabIndex = 8
      Me.lblPeriod.Text = "งวด"
      Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.ForeColor = System.Drawing.Color.Black
      Me.lblBaht.Location = New System.Drawing.Point(210, 39)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(30, 18)
      Me.lblBaht.TabIndex = 8
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblReceiveAmount
      '
      Me.lblReceiveAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblReceiveAmount.ForeColor = System.Drawing.Color.Black
      Me.lblReceiveAmount.Location = New System.Drawing.Point(242, 39)
      Me.lblReceiveAmount.Name = "lblReceiveAmount"
      Me.lblReceiveAmount.Size = New System.Drawing.Size(123, 18)
      Me.lblReceiveAmount.TabIndex = 8
      Me.lblReceiveAmount.Text = "ได้รับเงินตามสัญญาแล้ว:"
      Me.lblReceiveAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostCenter.Location = New System.Drawing.Point(26, 16)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(85, 18)
      Me.lblCostCenter.TabIndex = 8
      Me.lblCostCenter.Text = "Cost Center:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblContract
      '
      Me.lblContract.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblContract.ForeColor = System.Drawing.Color.Black
      Me.lblContract.Location = New System.Drawing.Point(30, 37)
      Me.lblContract.Name = "lblContract"
      Me.lblContract.Size = New System.Drawing.Size(80, 18)
      Me.lblContract.TabIndex = 8
      Me.lblContract.Text = "มูลค่าสัญญา:"
      Me.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBaht1
      '
      Me.lblBaht1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht1.ForeColor = System.Drawing.Color.Black
      Me.lblBaht1.Location = New System.Drawing.Point(464, 39)
      Me.lblBaht1.Name = "lblBaht1"
      Me.lblBaht1.Size = New System.Drawing.Size(30, 18)
      Me.lblBaht1.TabIndex = 8
      Me.lblBaht1.Text = "บาท"
      Me.lblBaht1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAcceptPerson1
      '
      Me.lblAcceptPerson1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcceptPerson1.Location = New System.Drawing.Point(796, 88)
      Me.lblAcceptPerson1.Name = "lblAcceptPerson1"
      Me.lblAcceptPerson1.Size = New System.Drawing.Size(91, 18)
      Me.lblAcceptPerson1.TabIndex = 330
      Me.lblAcceptPerson1.Text = "ผู้ตรวจสอบ:"
      Me.lblAcceptPerson1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'iFindEmployee1
      '
      Me.iFindEmployee1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.iFindEmployee1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.iFindEmployee1.ForeColor = System.Drawing.SystemColors.Control
      Me.iFindEmployee1.Location = New System.Drawing.Point(1149, 86)
      Me.iFindEmployee1.Name = "iFindEmployee1"
      Me.iFindEmployee1.Size = New System.Drawing.Size(24, 23)
      Me.iFindEmployee1.TabIndex = 332
      Me.iFindEmployee1.TabStop = False
      Me.iFindEmployee1.ThemedImage = CType(resources.GetObject("iFindEmployee1.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAcceptPerson2
      '
      Me.lblAcceptPerson2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcceptPerson2.Location = New System.Drawing.Point(796, 148)
      Me.lblAcceptPerson2.Name = "lblAcceptPerson2"
      Me.lblAcceptPerson2.Size = New System.Drawing.Size(91, 18)
      Me.lblAcceptPerson2.TabIndex = 330
      Me.lblAcceptPerson2.Text = "ผู้รับรอง:"
      Me.lblAcceptPerson2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'iFindEmployee2
      '
      Me.iFindEmployee2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.iFindEmployee2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.iFindEmployee2.ForeColor = System.Drawing.SystemColors.Control
      Me.iFindEmployee2.Location = New System.Drawing.Point(1149, 146)
      Me.iFindEmployee2.Name = "iFindEmployee2"
      Me.iFindEmployee2.Size = New System.Drawing.Size(24, 23)
      Me.iFindEmployee2.TabIndex = 332
      Me.iFindEmployee2.TabStop = False
      Me.iFindEmployee2.ThemedImage = CType(resources.GetObject("iFindEmployee2.ThemedImage"), System.Drawing.Bitmap)
      '
      'GroupBox6
      '
      Me.GroupBox6.Controls.Add(Me.tBindingFinishedDate)
      Me.GroupBox6.Controls.Add(Me.rBindingFinished)
      Me.GroupBox6.Controls.Add(Me.rUnBindingFinished)
      Me.GroupBox6.Location = New System.Drawing.Point(11, 195)
      Me.GroupBox6.Name = "GroupBox6"
      Me.GroupBox6.Size = New System.Drawing.Size(499, 63)
      Me.GroupBox6.TabIndex = 9
      Me.GroupBox6.TabStop = False
      '
      'tBindingFinishedDate
      '
      Me.tBindingFinishedDate.EditValue = Nothing
      Me.tBindingFinishedDate.Location = New System.Drawing.Point(246, 35)
      Me.tBindingFinishedDate.Name = "tBindingFinishedDate"
      Me.tBindingFinishedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
      Me.tBindingFinishedDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
      Me.tBindingFinishedDate.Size = New System.Drawing.Size(100, 20)
      Me.tBindingFinishedDate.TabIndex = 2
      '
      'rBindingFinished
      '
      Me.rBindingFinished.AccessibleName = "deliver"
      Me.rBindingFinished.AutoSize = True
      Me.rBindingFinished.Location = New System.Drawing.Point(110, 37)
      Me.rBindingFinished.Name = "rBindingFinished"
      Me.rBindingFinished.Size = New System.Drawing.Size(143, 17)
      Me.rBindingFinished.TabIndex = 1
      Me.rBindingFinished.Text = "สิ้นสุดภาระผูกพันแล้วเมื่อ"
      Me.rBindingFinished.UseVisualStyleBackColor = True
      '
      'rUnBindingFinished
      '
      Me.rUnBindingFinished.AccessibleName = "deliver"
      Me.rUnBindingFinished.AutoSize = True
      Me.rUnBindingFinished.Checked = True
      Me.rUnBindingFinished.Location = New System.Drawing.Point(110, 14)
      Me.rUnBindingFinished.Name = "rUnBindingFinished"
      Me.rUnBindingFinished.Size = New System.Drawing.Size(172, 17)
      Me.rUnBindingFinished.TabIndex = 0
      Me.rUnBindingFinished.TabStop = True
      Me.rUnBindingFinished.Text = "ยังไม่หมดภาระผูกพันตามสัญญา"
      Me.rUnBindingFinished.UseVisualStyleBackColor = True
      '
      'cCode
      '
      Me.cCode.FormattingEnabled = True
      Me.cCode.Location = New System.Drawing.Point(121, 9)
      Me.cCode.Name = "cCode"
      Me.cCode.Size = New System.Drawing.Size(117, 21)
      Me.cCode.TabIndex = 333
      '
      'ibtnRefresh
      '
      Me.ibtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnRefresh.Location = New System.Drawing.Point(121, 260)
      Me.ibtnRefresh.Name = "ibtnRefresh"
      Me.ibtnRefresh.Size = New System.Drawing.Size(32, 32)
      Me.ibtnRefresh.TabIndex = 347
      Me.ibtnRefresh.TabStop = False
      Me.ibtnRefresh.ThemedImage = CType(resources.GetObject("ibtnRefresh.ThemedImage"), System.Drawing.Bitmap)
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.Location = New System.Drawing.Point(796, 112)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(91, 18)
      Me.Label1.TabIndex = 330
      Me.Label1.Text = "ตำแหน่ง:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.Location = New System.Drawing.Point(796, 171)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(91, 18)
      Me.Label2.TabIndex = 330
      Me.Label2.Text = "ตำแหน่ง:"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibottonShowValue
      '
      Me.ibottonShowValue.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibottonShowValue.Location = New System.Drawing.Point(206, 260)
      Me.ibottonShowValue.Name = "ibottonShowValue"
      Me.ibottonShowValue.Size = New System.Drawing.Size(32, 32)
      Me.ibottonShowValue.TabIndex = 348
      Me.ibottonShowValue.TabStop = False
      Me.ibottonShowValue.ThemedImage = CType(resources.GetObject("ibottonShowValue.ThemedImage"), System.Drawing.Bitmap)
      '
      'ProjectReceivePaymentDetailView
      '
      Me.Controls.Add(Me.ibottonShowValue)
      Me.Controls.Add(Me.ibtnRefresh)
      Me.Controls.Add(Me.cCode)
      Me.Controls.Add(Me.GroupBox4)
      Me.Controls.Add(Me.grbAccountPeriod)
      Me.Controls.Add(Me.tAcceptPerson2Name)
      Me.Controls.Add(Me.tAcceptPerson1Name)
      Me.Controls.Add(Me.tProjectName)
      Me.Controls.Add(Me.tAcceptPerson2)
      Me.Controls.Add(Me.iFindEmployee2)
      Me.Controls.Add(Me.tAcceptPosition2)
      Me.Controls.Add(Me.tAcceptPosition)
      Me.Controls.Add(Me.tAcceptPerson1)
      Me.Controls.Add(Me.iFindEmployee1)
      Me.Controls.Add(Me.lblAcceptPerson2)
      Me.Controls.Add(Me.tProjectCode)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblAcceptPerson1)
      Me.Controls.Add(Me.iFindProjectDialog)
      Me.Controls.Add(Me.lblProject)
      Me.Controls.Add(Me.tDeliverDate)
      Me.Controls.Add(Me.ibtnCopyMe)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.chkAutorun)
      Me.Controls.Add(Me.lblDate)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox3)
      Me.Controls.Add(Me.GroupBox6)
      Me.Name = "ProjectReceivePaymentDetailView"
      Me.Size = New System.Drawing.Size(1205, 562)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tDeliverDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tDeliverDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tAccountDateStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tAccountDateStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tAccountDateEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tAccountDateEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbAccountPeriod.ResumeLayout(False)
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.GroupBox4.ResumeLayout(False)
      Me.GroupBox4.PerformLayout()
      Me.GroupBox6.ResumeLayout(False)
      Me.GroupBox6.PerformLayout()
      CType(Me.tBindingFinishedDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tBindingFinishedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As ProjectReceivePayment
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      Dim dt As TreeTable = ProjectReceivePayment.GetColumnSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf ItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      'For Each ctrl As Control In Me.Controls
      '  m_enableState.Add(ctrl, ctrl.Enabled)
      'Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "ProjectReceivePayment"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "LineNumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 100
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.Alignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "LineNumber"

      Dim csThaiNumber As New TreeTextColumn
      csThaiNumber.MappingName = "ThaiNumber"
      csThaiNumber.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.ThaiNumberHeaderText}")
      csThaiNumber.NullText = ""
      csThaiNumber.Width = 45
      csThaiNumber.DataAlignment = HorizontalAlignment.Center
      csThaiNumber.ReadOnly = True
      csThaiNumber.TextBox.Name = "ThaiNumber"

      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "Description"
      csDescription.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.DescriptionText}")
      csDescription.NullText = ""
      csDescription.Width = 300
      csDescription.ReadOnly = True
      csDescription.TextBox.Name = "Description"

      Dim csSeparator1 As New DataGridBarrierColumn
      csSeparator1.MappingName = "Separator1"
      csSeparator1.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.DescriptionText}")
      csSeparator1.NullText = ""

      Dim csGLAccount As New TreeTextColumn
      csGLAccount.MappingName = "GLAccount"
      csGLAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.GLAccountText}")
      csGLAccount.NullText = ""
      csGLAccount.Width = 500
      csGLAccount.ReadOnly = True
      csGLAccount.TextBox.Name = "GLAccount"

      Dim csGLButton As New DataGridButtonColumn
      csGLButton.MappingName = "GLButton"
      csGLButton.HeaderText = ""
      csGLButton.NullText = ""
      AddHandler csGLButton.Click, AddressOf GLAccountClicked

      Dim csCash As New TreeTextColumn
      csCash.MappingName = "Cash"
      csCash.HeaderText = myStringParserService.Parse("เงินสด")
      'csCash.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.CashText}")
      csCash.NullText = ""
      csCash.Width = 120
      csCash.ReadOnly = True
      csCash.TextBox.Name = "Cash"

      Dim csBank As New TreeTextColumn
      csBank.MappingName = "Bank"
      csBank.HeaderText = myStringParserService.Parse("ธนาคาร")
      'csBank.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.BankText}")
      csBank.NullText = ""
      csBank.Width = 120
      csBank.ReadOnly = True
      csBank.TextBox.Name = "Bank"

      Dim csRemain As New TreeTextColumn
      csRemain.MappingName = "Remain"
      csRemain.HeaderText = myStringParserService.Parse("คงค้าง")
      'csRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.RemainText}")
      csRemain.NullText = ""
      csRemain.Width = 120
      csRemain.ReadOnly = True
      csRemain.TextBox.Name = "Remain"

      Dim csOther As New TreeTextColumn
      csOther.MappingName = "Other"
      csOther.HeaderText = myStringParserService.Parse("อื่นๆ")
      'csOther.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.OtherText}")
      csOther.NullText = ""
      csOther.Width = 120
      csOther.ReadOnly = True
      csOther.TextBox.Name = "Other"

      Dim csSum As New TreeTextColumn
      csSum.MappingName = "Sum"
      csSum.HeaderText = myStringParserService.Parse("รวม")
      'csSum.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.SumText}")
      csSum.NullText = ""
      csSum.Width = 120
      csSum.ReadOnly = True
      csSum.TextBox.Name = "Sum"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csThaiNumber)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csSeparator1)
      dst.GridColumnStyles.Add(csGLAccount)
      'dst.GridColumnStyles.Add(csGLButton)
      dst.GridColumnStyles.Add(csCash)
      dst.GridColumnStyles.Add(csBank)
      dst.GridColumnStyles.Add(csRemain)
      dst.GridColumnStyles.Add(csOther)
      dst.GridColumnStyles.Add(csSum)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Public Sub GLClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 7 Then
        GLAccountClicked(e)
      End If
    End Sub
    Public Sub GLAccountClicked(ByVal e As ButtonColumnEventArgs)

      Dim theRow As TreeRow = m_treeManager.SelectedRow
      If theRow Is Nothing OrElse theRow.Tag Is Nothing Then
        Return
      End If
      Dim itm As ProjectReceivePaymentItem = Nothing
      If TypeOf theRow.Tag Is ProjectReceivePaymentItem Then
        itm = CType(theRow.Tag, ProjectReceivePaymentItem)
      End If
      Dim filters(1) As Filter
      filters(0) = New Filter("CheckedIdList", itm.GLIdSeparate)
      filters(1) = New Filter("acct_typeGroup", "4,5")

      Dim Entities As New ArrayList
      Dim _entity As New Account
      _entity.Type = New AccountType(-1)
      Entities.Add(_entity)

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetGLAccount, filters, Entities)
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub SetGLAccount(ByVal items As BasketItemCollection)
      'Me.m_treeManager.SelectedRow("CCCode") = cc.Code
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      Dim itm As ProjectReceivePaymentItem = Nothing
      If TypeOf theRow.Tag Is ProjectReceivePaymentItem Then
        itm = CType(theRow.Tag, ProjectReceivePaymentItem)
        itm.GLAccountList = New List(Of Account)
      End If
      For i As Integer = 0 To items.Count - 1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim myItem As New Account(item.Id)
        If myItem.IsControlGroup Then
          'ToDo:
        Else
          itm.GLAccountList.Add(myItem)
        End If
      Next
      theRow("GLAccount") = itm.GLCodeSeparate
      Me.m_treeManager.Treetable.AcceptChanges()
    End Sub
    'Public Sub JClicked(ByVal e As ButtonColumnEventArgs)
    '  If e.Column = 11 Then
    '    JButtonClick(e)
    '  ElseIf e.Column = 14 Then
    '    EJButtonClick(e)
    '  End If
    'End Sub
    'Public Sub JButtonClick(ByVal e As ButtonColumnEventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetJournal)
    'End Sub
    'Private Sub SetJournal(ByVal jr As ISimpleEntity)
    '  Me.m_treeManager.SelectedRow("JCode") = jr.Code
    'End Sub
    'Public Sub EJButtonClick(ByVal e As ButtonColumnEventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetEJournal)
    'End Sub
    'Private Sub SetEJournal(ByVal jr As ISimpleEntity)
    '  Me.m_treeManager.SelectedRow("EJCode") = jr.Code
    'End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Return False
      End Get
    End Property
    Private ReadOnly Property CurrentItem() As ProjectReceivePaymentItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is ProjectReceivePaymentItem Then
          Return Nothing
        End If
        Return CType(row.Tag, ProjectReceivePaymentItem)
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      '  Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.m_treeManager.Treetable.AcceptChanges()
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      '  If Me.CurrentItem Is Nothing Then
      '    Dim doc As New FFormatColumn
      '    Me.m_entity.ColumnCollection.Add(doc)
      '    Me.m_treeManager.SelectedRow.Tag = doc
      '  End If
      '  Try
      Select Case e.Column.ColumnName.ToLower
        Case "glaccount"
          SetGLCodeList(e)
          '      Case "ffc_name"
          '        SetName(e)
          '      Case "ffc_widthpercent"
          '        SetWidthPercent(e)
          '      Case "ffc_alignment"
          '        SetAlignment(e)
          '      Case "ffc_startdate"
          '        SetStartDate(e)
          '      Case "ffc_enddate"
          '        SetEndDate(e)
          '      Case "cccode"
          '        SetCostCenterValue(e)
          '      Case "ffc_includechildcc"
          '        Dim eindex As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
          '        Dim sindex As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(Me.m_treeManager.SelectedRow)
          '        If eindex <> sindex Then
          '          m_treeManager.SelectedRow = CType(e.Row, TreeRow)
          '        End If
          '        Me.CurrentItem.IncludeChildCostCenter = CBool(e.ProposedValue)
          '      Case "jcode"
          '        SetJournalValue(e)
          '      Case "ejcode"
          '        SetJournalValue(e)
      End Select
      '    ValidateRow(e)
      '  Catch ex As Exception
      '    MessageBox.Show(ex.ToString)
      '  End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      'Dim ffc_name As Object = e.Row("ffc_name")
      'Dim ffc_alignment As Object = e.Row("ffc_alignment")
      'Dim ffc_widthpercent As Object = e.Row("ffc_widthpercent")
      'Dim ffc_startdate As Object = e.Row("ffc_startdate")
      'Dim ffc_enddate As Object = e.Row("ffc_enddate")

      'Select Case e.Column.ColumnName.ToLower
      '  Case "ffc_name"
      '    ffc_name = e.ProposedValue
      '  Case "ffc_alignment"
      '    ffc_alignment = e.ProposedValue
      '  Case "ffc_widthpercent"
      '    ffc_widthpercent = e.ProposedValue
      '  Case "ffc_startdate"
      '    ffc_startdate = e.ProposedValue
      '  Case "ffc_enddate"
      '    ffc_enddate = e.ProposedValue
      '  Case Else
      '    Return
      'End Select

      'Dim isBlankRow As Boolean = False
      'If IsDBNull(ffc_alignment) _
      'AndAlso IsDBNull(ffc_name) _
      'AndAlso IsDBNull(ffc_widthpercent) _
      'AndAlso IsDBNull(ffc_startdate) _
      'AndAlso IsDBNull(ffc_enddate) Then
      '  isBlankRow = True
      'End If
      'If Not isBlankRow Then
      '  If Not IsNumeric(ffc_widthpercent) OrElse CDec(ffc_widthpercent) < 0 Then
      '    e.Row.SetColumnError("ffc_widthpercent", Me.StringParserService.Parse("${res:Global.Error.FFCWidthMissing}"))
      '  Else
      '    e.Row.SetColumnError("ffc_widthpercent", "")
      '  End If
      '  If Not IsNumeric(ffc_alignment) Then
      '    e.Row.SetColumnError("ffc_alignment", Me.StringParserService.Parse("${res:Global.Error.FFCAlignmentMissing}"))
      '  Else
      '    e.Row.SetColumnError("ffc_alignment", "")
      '  End If
      '  If Not IsDate(ffc_enddate) OrElse CDate(ffc_enddate).Equals(Date.MinValue) Then
      '    e.Row.SetColumnError("ffc_enddate", Me.StringParserService.Parse("${res:Global.Error.FFCEndDateMissing}"))
      '  Else
      '    e.Row.SetColumnError("ffc_enddate", "")
      '  End If
      'End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      'If row.Tag Is Nothing Then
      '  Return False
      'End If
      'Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetCostCenterValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      'If m_updating Then
      '  Return
      'End If
      'm_updating = True
      'Dim entity As New CostCenter(e.ProposedValue.ToString)
      'If entity.Originated Then
      '  e.ProposedValue = entity.Code
      '  e.Row("CCName") = entity.Name
      'Else
      '  e.ProposedValue = DBNull.Value
      '  e.Row("CCName") = DBNull.Value
      'End If
      'Dim doc As FFormatColumn = Me.CurrentItem
      'doc.CostCenter = entity
      'm_updating = False
    End Sub
    Public Sub SetJournalValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      'If m_updating Then
      '  Return
      'End If
      'm_updating = True
      'Dim entity As New AccountBook(e.ProposedValue.ToString)
      'If entity.Originated Then
      '  e.ProposedValue = entity.Code
      '  If e.Column.ColumnName.ToLower = "jcode" Then
      '    e.Row("JName") = entity.Name
      '  ElseIf e.Column.ColumnName.ToLower = "ejcode" Then
      '    e.Row("EJName") = entity.Name
      '  End If
      'Else
      '  e.ProposedValue = DBNull.Value
      '  If e.Column.ColumnName.ToLower = "jcode" Then
      '    e.Row("JName") = DBNull.Value
      '  ElseIf e.Column.ColumnName.ToLower = "ejcode" Then
      '    e.Row("EJName") = DBNull.Value
      '  End If
      'End If
      'Dim doc As FFormatColumn = Me.CurrentItem
      'If e.Column.ColumnName.ToLower = "jcode" Then
      '  doc.AccountBook = entity
      'ElseIf e.Column.ColumnName.ToLower = "ejcode" Then
      '  doc.EndAccountBook = entity
      'End If
      'm_updating = False
    End Sub
    Public Sub SetGLCodeList(ByVal e As DataColumnChangeEventArgs)
      Dim doc As ProjectReceivePaymentItem = Me.CurrentItem
      If doc.IsFormula Then
        e.ProposedValue = doc.Formula
      Else
        e.ProposedValue = doc.GLCodeSeparate
      End If
    End Sub
    Public Sub SetName(ByVal e As DataColumnChangeEventArgs)
      'If m_updating Then
      '  Return
      'End If
      'Dim doc As FFormatColumn = Me.CurrentItem
      'm_updating = True
      'doc.Name = e.ProposedValue.ToString
      'm_updating = False
    End Sub
    Public Sub SetWidthPercent(ByVal e As DataColumnChangeEventArgs)
      'If m_updating Then
      '  Return
      'End If
      'Dim doc As FFormatColumn = Me.CurrentItem
      'If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
      '  e.ProposedValue = ""
      '  Return
      'End If
      'e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      'Dim value As Decimal = CDec(e.ProposedValue)
      'If Configuration.Compare(Me.m_entity.ColumnCollection.AllWidthPercent - doc.WidthPercent + value, 100, DigitConfig.Price) > 0 Then
      '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      '  msgServ.ShowMessage("${res:Global.Error.WidthPercentExceed100}")
      '  e.ProposedValue = e.Row(e.Column)
      '  m_updating = False
      '  Return
      'End If
      'm_updating = True
      'doc.WidthPercent = value
      'm_updating = False
    End Sub
    Public Sub SetAlignment(ByVal e As DataColumnChangeEventArgs)
      'If m_updating Then
      '  Return
      'End If
      'm_updating = True
      'Dim doc As FFormatColumn = Me.CurrentItem
      'doc.Alignment = CType(CInt(e.ProposedValue), HorizontalAlignment)
      'm_updating = False
    End Sub
    Public Sub SetStartDate(ByVal e As DataColumnChangeEventArgs)
      'If m_updating Then
      '  Return
      'End If
      'Dim doc As FFormatColumn = Me.CurrentItem
      'If Not IsDate(e.ProposedValue) Then
      '  e.ProposedValue = Date.MinValue
      'End If
      'm_updating = True
      'doc.StartDate = CDate(e.ProposedValue)
      'm_updating = False
    End Sub
    Public Sub SetEndDate(ByVal e As DataColumnChangeEventArgs)
      'If m_updating Then
      '  Return
      'End If
      'Dim doc As FFormatColumn = Me.CurrentItem
      'If Not IsDate(e.ProposedValue) Then
      '  e.ProposedValue = Date.MinValue
      'End If
      'm_updating = True
      'doc.EndDate = CDate(e.ProposedValue)
      'm_updating = False
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      'If Me.m_entity Is Nothing Then
      '  Return
      'End If
      'If Me.m_entity.Status.Value = 0 _
      'OrElse Me.m_entity.Status.Value >= 3 _
      'Then
      '  Me.Enabled = False
      'Else
      '  Me.Enabled = True
      'End If
      SetBidingFinishedDate()
    End Sub
    Private Sub SetBidingFinishedDate()
      If Me.m_entity.IsBiddingFinished Then
        Me.tBindingFinishedDate.Enabled = True
      Else
        Me.tBindingFinishedDate.Enabled = False
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      'For Each crlt As Control In Me.Controls
      '  If crlt.Name.StartsWith("txt") Then
      '    crlt.Text = ""
      '  End If
      'Next
      'For Each crlt As Control In grbCompanyName.Controls
      '  If crlt.Name.StartsWith("txt") Then
      '    crlt.Text = ""
      '  End If
      'Next
    End Sub
    Public Overrides Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      'Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.lblItem}")
      'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.lblCode}")
      'Me.lblHeader.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.lblHeader}")
      'Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.lblName}")
      'Me.lblCondition.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.lblCondition}")
      'Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.lblNote}")
      'Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.lblType}")
      'Me.rdOption.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.rdOption}")
      'Me.rdCustom.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.rdCustom}")
      'Me.grbCompanyName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetailView.grbCompanyName}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblCode}")
      Me.lblDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblDate}")
      Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblProject}")
      Me.lblContract.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblContract}")
      Me.lblMileStoneNumber.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblMileStoneNumber}")
      Me.lblReceiveMileStoneNumber.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblReceiveMileStoneNumber}")
      Me.lblReceiveAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblReceiveAmount}")
      Me.lblSentMileStoneNumber.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblSentMileStoneNumber}")
      Me.lblReceiveNumber.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblReceiveNumber}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.lblBaht1.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.lblPeriod.Text = Me.StringParserService.Parse("${res:Global.Period}")
      Me.lblPeriod1.Text = Me.StringParserService.Parse("${res:Global.Period}")
      Me.lblPeriod2.Text = Me.StringParserService.Parse("${res:Global.Period}")
      Me.lblPeriod3.Text = Me.StringParserService.Parse("${res:Global.Period}")
      Me.rUnBindingFinished.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.rUnBindingFinished}")
      Me.rBindingFinished.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.rBindingFinished}")
      Me.grbAccountPeriod.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.grbAccountPeriod}")
      Me.lblAccountPeriodStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblAccountPeriodStart}")
      Me.lblAccountPeriodEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblAccountPeriodEnd}")
      Me.rDeliver.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.rDeliver}")
      Me.rDeliverUnNormal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.rDeliverUnNormal}")
      Me.lblDeliverNumber.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblDeliverNumber}")
      Me.cNoExpenditure.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.cNoExpenditure}")
      Me.cNoRevenue.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.cNoRevenue}")
      Me.lblAcceptPerson1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblAcceptPerson1}")
      Me.Label1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.Label1}")
      Me.Label2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.Label2}")
      Me.lblAcceptPerson2.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblAcceptPerson2}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.lblItem}")

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler tDeliverDate.TextChanged, AddressOf Me.TextHandler
      AddHandler tDeliverDate.Validated, AddressOf Me.ChangeProperty
      AddHandler tProjectCode.Validated, AddressOf Me.ChangeProperty

      AddHandler tContractAmount.Validated, AddressOf Me.TextHandler
      AddHandler tContractAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler tReceiveAmount.Validated, AddressOf Me.TextHandler
      AddHandler tReceiveAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler tMileStoneNumber.Validated, AddressOf Me.TextHandler
      AddHandler tMileStoneNumber.TextChanged, AddressOf Me.ChangeProperty
      AddHandler tSentMileStoneNumber.Validated, AddressOf Me.TextHandler
      AddHandler tSentMileStoneNumber.TextChanged, AddressOf Me.ChangeProperty
      AddHandler tReceiveMileStoneNumber.Validated, AddressOf Me.TextHandler
      AddHandler tReceiveMileStoneNumber.TextChanged, AddressOf Me.ChangeProperty
      AddHandler tReceiveNumber.Validated, AddressOf Me.TextHandler
      AddHandler tReceiveNumber.TextChanged, AddressOf Me.ChangeProperty

      AddHandler tAcceptPerson1.Validated, AddressOf Me.ChangeProperty
      AddHandler tAcceptPerson2.Validated, AddressOf Me.ChangeProperty
      AddHandler tAccountDateStart.EditValueChanged, AddressOf Me.ChangeProperty
      AddHandler tAccountDateEnd.EditValueChanged, AddressOf Me.ChangeProperty
      AddHandler rDeliver.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler rDeliverUnNormal.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler tDeliverNumber.Validated, AddressOf Me.ChangeProperty

      AddHandler cNoRevenue.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler cNoExpenditure.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler rUnBindingFinished.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler rBindingFinished.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler tBindingFinishedDate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler tAcceptPosition.TextChanged, AddressOf Me.ChangeProperty
      AddHandler tAcceptPosition2.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler cmbType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      'AddHandler cmbAutoGenType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      'AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtHeader.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtCondition.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler rdOption.CheckedChanged, AddressOf Me.ChangeProperty
      'AddHandler rdCustom.CheckedChanged, AddressOf Me.ChangeProperty
      'AddHandler txtCompanyName.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      'ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      'txtCode.Text = m_entity.Code
      'txtName.Text = m_entity.Name
      'txtHeader.Text = m_entity.Header
      'txtCondition.Text = m_entity.Condition
      'txtNote.Text = m_entity.Note

      'If Me.m_entity.UseCompanyNameInOption Then
      '  rdOption.PerformClick()
      '  Me.txtCompanyName.ReadOnly = True
      'Else
      '  rdCustom.PerformClick()
      '  Me.txtCompanyName.ReadOnly = False
      'End If
      'Me.txtCompanyName.Text = m_entity.Companyname


      'Me.m_oldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      If Not Me.m_entity.DeliverDate.Equals(Date.MinValue) Then
        Me.tDeliverDate.Text = Me.m_entity.DeliverDate.ToShortDateString
        Me.tDeliverDate.EditValue = Me.m_entity.DeliverDate
      Else
        Me.tDeliverDate.Text = ""
      End If
      Me.tProjectCode.Text = Me.m_entity.Project.Code
      Me.tProjectName.Text = Me.m_entity.Project.Name

      Me.tAcceptPerson1.Text = Me.m_entity.AcceptPerson.Code
      Me.tAcceptPerson1Name.Text = Me.m_entity.AcceptPerson.Name
      Me.tAcceptPerson2.Text = Me.m_entity.AcceptPerson2.Code
      Me.tAcceptPerson2Name.Text = Me.m_entity.AcceptPerson2.Name

      Me.tContractAmount.Text = Configuration.FormatToString(Me.m_entity.ContractAmount, DigitConfig.Price)
      Me.tReceiveAmount.Text = Configuration.FormatToString(Me.m_entity.ReceivedAmount, DigitConfig.Price)
      Me.tMileStoneNumber.Text = Configuration.FormatToString(m_entity.MileStoneNumber, DigitConfig.Int)
      Me.tSentMileStoneNumber.Text = Configuration.FormatToString(m_entity.SentMileStoneNumber, DigitConfig.Int)
      Me.tReceiveMileStoneNumber.Text = Configuration.FormatToString(m_entity.ReceivedMileStoneNumber, DigitConfig.Int)
      Me.tReceiveNumber.Text = Configuration.FormatToString(m_entity.ReceivedNumber, DigitConfig.Int)
      If Not Me.m_entity.AccountPeriodDateStart.Equals(Date.MinValue) Then
        Me.tAccountDateStart.Text = Me.m_entity.AccountPeriodDateStart.ToShortDateString
        Me.tAccountDateStart.EditValue = Me.m_entity.AccountPeriodDateStart
      Else
        Me.tAccountDateStart.Text = ""
      End If
      If Not Me.m_entity.AccountPeriodDateEnd.Equals(Date.MinValue) Then
        Me.tAccountDateEnd.Text = Me.m_entity.AccountPeriodDateEnd.ToShortDateString
        Me.tAccountDateEnd.EditValue = Me.m_entity.AccountPeriodDateEnd
      Else
        Me.tAccountDateEnd.Text = ""
      End If
      If Me.m_entity.IsNomalDeliver Then
        Me.rDeliver.Checked = True
      Else
        Me.rDeliverUnNormal.Checked = True
      End If
      Me.tDeliverNumber.Text = Me.m_entity.DeliverNumber
      Me.cNoRevenue.Checked = Me.m_entity.NoRevenue
      Me.cNoExpenditure.Checked = Me.m_entity.NoExpenditure
      If Me.m_entity.IsBiddingFinished Then
        Me.rBindingFinished.Checked = True
      Else
        Me.rUnBindingFinished.Checked = True
      End If
      If Not Me.m_entity.BiddingFinishedDate.Equals(Date.MinValue) Then
        Me.tBindingFinishedDate.Text = Me.m_entity.BiddingFinishedDate.ToShortDateString
        Me.tBindingFinishedDate.EditValue = Me.m_entity.BiddingFinishedDate
      Else
        Me.tBindingFinishedDate.Text = ""
      End If

      Me.tAcceptPosition.Text = m_entity.Acceptancepersonposition
      Me.tAcceptPosition2.Text = m_entity.Acceptancepersonposition2

      If Me.m_entity.CostCenter.Originated Then
        Me.txtCostCenter.Text = String.Format("{0} : {1}", Me.m_entity.CostCenter.Code, Me.m_entity.CostCenter.Name)
      End If

      'CodeDescription.ComboSelect(Me.cmbType, Me.m_entity.ReportType)
      'CodeDescription.ComboSelect(Me.cmbAutoGenType, Me.m_entity.AutoType)

      RefreshDocs()

      'SetStatus()
      'SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      'If e.Name = "ItemChanged" Then
      '  Me.WorkbenchWindow.ViewContent.IsDirty = True
      'End If
    End Sub
    Private Sub RefreshProjectContract()
      tContractAmount.Text = Configuration.FormatToString(m_entity.ContractAmount, DigitConfig.Price)
      tReceiveAmount.Text = Configuration.FormatToString(m_entity.ReceivedAmount, DigitConfig.Price)
      tMileStoneNumber.Text = Configuration.FormatToString(m_entity.MileStoneNumber, DigitConfig.Int)
      tSentMileStoneNumber.Text = Configuration.FormatToString(m_entity.SentMileStoneNumber, DigitConfig.Int)
      tReceiveMileStoneNumber.Text = Configuration.FormatToString(m_entity.ReceivedMileStoneNumber, DigitConfig.Int)
      tReceiveNumber.Text = Configuration.FormatToString(m_entity.ReceivedNumber, DigitConfig.Int)
      tDeliverNumber.Text = Configuration.FormatToString(m_entity.DeliverNumber, DigitConfig.Int)
    End Sub
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing OrElse Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case tDeliverDate.Name.ToLower
          m_dateSetting = True
        Case tContractAmount.Name.ToLower
          If IsNumeric(tContractAmount.Text) Then
            m_entity.ContractAmount = CDbl(tContractAmount.Text)
            m_numeric = True
          End If
          tContractAmount.Text = Configuration.FormatToString(m_entity.ContractAmount, DigitConfig.Price)
        Case tReceiveAmount.Name.ToLower
          If IsNumeric(tReceiveAmount.Text) Then
            m_entity.ReceivedAmount = CDbl(tReceiveAmount.Text)
            m_numeric = True
          End If
          tReceiveAmount.Text = Configuration.FormatToString(m_entity.ReceivedAmount, DigitConfig.Price)
        Case tMileStoneNumber.Name.ToLower
          If IsNumeric(tMileStoneNumber.Text) Then
            m_entity.MileStoneNumber = CDbl(tMileStoneNumber.Text)
            m_numeric = True
          End If
          tMileStoneNumber.Text = Configuration.FormatToString(m_entity.MileStoneNumber, DigitConfig.Int)
        Case tSentMileStoneNumber.Name.ToLower
          If IsNumeric(tSentMileStoneNumber.Text) Then
            m_entity.SentMileStoneNumber = CDbl(tSentMileStoneNumber.Text)
            m_numeric = True
          End If
          tSentMileStoneNumber.Text = Configuration.FormatToString(m_entity.SentMileStoneNumber, DigitConfig.Int)
        Case tReceiveMileStoneNumber.Name.ToLower
          If IsNumeric(tReceiveMileStoneNumber.Text) Then
            m_entity.ReceivedMileStoneNumber = CDbl(tReceiveMileStoneNumber.Text)
            m_numeric = True
          End If
          tReceiveMileStoneNumber.Text = Configuration.FormatToString(m_entity.ReceivedMileStoneNumber, DigitConfig.Int)
        Case tReceiveNumber.Name.ToLower
          If IsNumeric(tReceiveNumber.Text) Then
            m_entity.ReceivedNumber = CDbl(tReceiveNumber.Text)
            m_numeric = True
          End If
          tReceiveNumber.Text = Configuration.FormatToString(m_entity.ReceivedNumber, DigitConfig.Int)
      End Select
    End Sub
    Private m_optionsetting As Boolean = False
    Private m_dateSetting As Boolean = False
    Private m_numeric As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False

      Select Case CType(sender, Control).Name.ToLower
        Case cCode.Name.ToLower
          Me.m_entity.Code = cCode.Text
          'เพิ่ม AutoCode--
          If TypeOf cCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(cCode.SelectedItem, AutoCodeFormat)
            'Me.m_entity.OnGlChanged()
          End If
          dirtyFlag = True
        Case tDeliverDate.Name.ToLower
          If m_dateSetting Then
            If tDeliverDate.Text.Trim.Length = 0 Then
              Me.m_entity.DeliverDate = Date.MinValue
            Else
              Me.m_entity.DeliverDate = tDeliverDate.EditValue
            End If
            m_dateSetting = False

            dirtyFlag = True
          End If
        Case tProjectCode.Name.ToLower
          If Me.tProjectCode.TextLength <> 0 Then
            dirtyFlag = Project.GetProject(tProjectCode, tProjectName, Me.m_entity.Project)
            Me.SetCostCenter()
            If Me.m_entity.CostCenter.Originated Then
              Me.txtCostCenter.Text = String.Format("{0} : {1}", Me.m_entity.CostCenter.Code, Me.m_entity.CostCenter.Name)
            End If
          Else
            dirtyFlag = True
            Me.m_entity.Project = New Project
            Me.m_entity.CostCenter = New CostCenter
            tProjectCode.Text = ""
            tProjectName.Text = ""
          End If
          RefreshProjectContract()
        Case tContractAmount.Name.ToLower
          If m_numeric Then
            dirtyFlag = True
          End If
          m_numeric = False
        Case tReceiveAmount.Name.ToLower
          If m_numeric Then
            dirtyFlag = True
          End If
          m_numeric = False
        Case tMileStoneNumber.Name.ToLower
          If m_numeric Then
            dirtyFlag = True
          End If
          m_numeric = False
        Case tSentMileStoneNumber.Name.ToLower
          If m_numeric Then
            dirtyFlag = True
          End If
          m_numeric = False
        Case tReceiveMileStoneNumber.Name.ToLower
          If IsNumeric(tReceiveMileStoneNumber.Text) Then
            m_entity.ReceivedMileStoneNumber = CDbl(tReceiveMileStoneNumber.Text)
            dirtyFlag = True
          End If
          tReceiveMileStoneNumber.Text = Configuration.FormatToString(m_entity.ReceivedMileStoneNumber, DigitConfig.Int)
        Case tReceiveNumber.Name.ToLower
          If m_numeric Then
            dirtyFlag = True
          End If
          m_numeric = False
        Case tAcceptPerson1.Name.ToLower
          If Me.tAcceptPerson1.TextLength <> 0 Then
            dirtyFlag = Employee.GetEmployee(tAcceptPerson1, tAcceptPerson1Name, Me.m_entity.AcceptPerson)
          Else
            Me.m_entity.AcceptPerson = New Employee
            tAcceptPerson1.Text = ""
            tAcceptPerson1Name.Text = ""
          End If
        Case tAcceptPerson2.Name.ToLower
          If Me.tAcceptPerson2.TextLength <> 0 Then
            dirtyFlag = Employee.GetEmployee(tAcceptPerson2, tAcceptPerson2Name, Me.m_entity.AcceptPerson2)
          Else
            Me.m_entity.AcceptPerson2 = New Employee
            tAcceptPerson2.Text = ""
            tAcceptPerson2Name.Text = ""
          End If
        Case tAccountDateStart.Name.ToLower
          If tAccountDateStart.Text.Trim.Length = 0 Then
            Me.m_entity.AccountPeriodDateStart = Date.MinValue
          Else
            Me.m_entity.AccountPeriodDateStart = tAccountDateStart.EditValue
          End If
          dirtyFlag = True
        Case tAccountDateEnd.Name.ToLower
          If tAccountDateEnd.Text.Trim.Length = 0 Then
            Me.m_entity.AccountPeriodDateEnd = Date.MinValue
          Else
            Me.m_entity.AccountPeriodDateEnd = tAccountDateEnd.EditValue
          End If
          dirtyFlag = True
        Case rDeliver.Name.ToLower
          m_entity.IsNomalDeliver = True
          dirtyFlag = True
        Case rDeliverUnNormal.Name.ToLower
          m_entity.IsNomalDeliver = False
          dirtyFlag = True
        Case tDeliverNumber.Name.ToLower
          If IsNumeric(tDeliverNumber.Text) Then
            m_entity.DeliverNumber = CDbl(tDeliverNumber.Text)
            dirtyFlag = True
          End If
          tDeliverNumber.Text = Configuration.FormatToString(m_entity.DeliverNumber, DigitConfig.Int)
        Case cNoRevenue.Name.ToLower
          m_entity.NoRevenue = cNoRevenue.Checked
          dirtyFlag = True
        Case cNoExpenditure.Name.ToLower
          m_entity.NoExpenditure = cNoExpenditure.Checked
          dirtyFlag = True
        Case rUnBindingFinished.Name.ToLower
          m_entity.IsBiddingFinished = False
          SetBidingFinishedDate()
          dirtyFlag = True
        Case rBindingFinished.Name.ToLower
          m_entity.IsBiddingFinished = True
          SetBidingFinishedDate()
          dirtyFlag = True
        Case tBindingFinishedDate.Name.ToLower
          If tBindingFinishedDate.Text.Trim.Length = 0 Then
            Me.m_entity.BiddingFinishedDate = Date.MinValue
          Else
            Me.m_entity.BiddingFinishedDate = tBindingFinishedDate.EditValue
          End If
          dirtyFlag = True
        Case tAcceptPosition.Name.ToLower
          m_entity.Acceptancepersonposition = Me.tAcceptPosition.Text.Trim
          dirtyFlag = True
        Case tAcceptPosition2.Name.ToLower
          m_entity.Acceptancepersonposition2 = Me.tAcceptPosition2.Text.Trim
          dirtyFlag = True
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      'CheckFormEnable()
    End Sub
    Private Sub SetCostCenter()
      If m_entity.Originated Then
        Dim _id As Integer = m_entity.Project.GetCostCenterForNacc
        If _id > 0 Then
          Me.m_entity.CostCenter = New CostCenter(_id)
        End If
      End If
    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, ProjectReceivePayment)
        ''Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      PopulateType()
      PopulateAutoType()
    End Sub
    Private Sub PopulateType()
      'CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "financialstatement_type")
    End Sub
    Private Sub PopulateAutoType()
      'CodeDescription.ListCodeDescriptionInComboBox(Me.cmbAutoGenType, "ff_autotype")
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cCode.DropDownStyle = ComboBoxStyle.DropDownList
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cCode, Me.m_entity.EntityId, currentUserId)
        If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
          If Me.cCode.Items.Count > 0 Then
            Me.m_entity.Code = CType(Me.cCode.Items(0), AutoCodeFormat).Format
            Me.cCode.SelectedIndex = 0
            Me.m_entity.AutoCodeFormat = CType(Me.cCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cCode.SelectedIndex = Me.cCode.FindStringExact(Me.m_entity.Code)
          If TypeOf Me.cCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(Me.cCode.SelectedItem, AutoCodeFormat)
          End If
        End If
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        'If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
        '  Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
        'End If
        Me.cCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cCode.Items.Clear()
        Me.cCode.Text = Me.m_entity.Code
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim index As Integer = tgItem.CurrentRowIndex
      'If index > Me.m_entity.ColumnCollection.Count - 1 Then
      '  Return
      'End If
      'Me.m_entity.ColumnCollection.Insert(index, New FFormatColumn)
      'RefreshDocs()
      'tgItem.CurrentRowIndex = index
      'Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
      ', Me.m_treeManager.Treetable.Columns("ffc_widthpercent") _
      ', Me.CurrentItem.WidthPercent)
      'Me.ValidateRow(re)
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim index As Integer = Me.tgItem.CurrentRowIndex
      'Dim row As TreeRow = Me.m_treeManager.SelectedRow
      'If row Is Nothing Then
      '  Return
      'End If
      'Dim doc As FFormatColumn = Me.CurrentItem
      'If doc Is Nothing Then
      '  Return
      'End If
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
      'Me.m_entity.ColumnCollection.Remove(doc)
      'RefreshDocs()
      'Me.tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ReIndex()
      'Dim i As Integer = 0
      'For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
      '  row("ffc_linenumber") = i + 1
      '  If TypeOf row.Tag Is FFormatColumn Then
      '    CType(row.Tag, FFormatColumn).LineNumber = i + 1
      '  End If
      '  i += 1
      'Next
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides Sub NotifyBeforeSave()

    End Sub
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New ProjectReceivePayment).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

#Region "Event of Button controls"

#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'If Me.m_entity Is Nothing Then
      '  Return
      'End If
      'RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
        row("GLButton") = "invisible"
      Loop

      If Me.m_entity.ProjectReceivePaymentItemList.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
        row("GLButton") = "invisible"
      End If
      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

      'If Me.tgItem.Height = 0 Then
      '    Return
      'End If
      'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim maxVisibleCount As Integer
      'Dim tgRowHeight As Integer = 17
      'maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
      'Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
      '    'เพิ่มแถวจนเต็ม
      '    Me.m_treeManager.Treetable.Childs.Add()
      'Loop
      ''If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
      ''    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
      ''        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      ''        Me.m_treeManager.Treetable.Childs.Add()
      ''    End If
      ''End If
      'Me.m_treeManager.Treetable.AcceptChanges()
      'tgItem.CurrentRowIndex = Math.Max(0, index)
      'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      'Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      'CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      'Me.Entity = newEntity
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub btnSetAutoGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'If m_entity.AutoType.Value = 0 OrElse (m_entity.ColumnCollection.Count2 - 1) = 0 Then 'ไม่ Autogen
      '  Return

      'ElseIf Not m_entity.AutoType.Value = 1 Then 'Interval Autogen 
      '  Dim Intdlg As New Longkong.Pojjaman.Gui.Panels.IntervalDialog(m_entity.AutoType, _
      '                                                                Me.m_entity.ColumnCollection.StartDate, _
      '                                                                Me.m_entity.ColumnCollection.Count2 - 1, _
      '                                                                Me.m_entity.ColumnCollection.Item(1).CostCenter.Id, _
      '                                                                Me.m_entity.ColumnCollection.Item(1).IncludeChildCostCenter)
      '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(Intdlg)
      '  If myDialog.ShowDialog() = DialogResult.OK Then
      '    Dim startdate As Date = Intdlg.DocDate
      '    Dim NumCol As Integer = Intdlg.NumCol
      '    Dim StartCol As Integer = Intdlg.StartCol
      '    Dim CC As Decimal = Intdlg.ccID
      '    Dim IncChild As Boolean = Intdlg.IncChild
      '    m_entity.IntervalAutoGen(startdate, NumCol, CC, IncChild, StartCol)
      '    RefreshDocs()
      '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      '    myContent.IsDirty = True
      '  End If
      'Else 'Auto gen Costcenter

      '  Dim filters() As Filter
      '  filters = New Filter() {New Filter("IDList", "")}

      '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '  myEntityPanelService.OpenListDialog(New CostCenter, AddressOf Me.m_entity.CostCenterAutogen, filters)
      '  RefreshDocs()
      '  Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      '  Me.WorkbenchWindow.ViewContent.IsDirty = True
      'End If

    End Sub

    'Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
    '  Dim i As Integer = tgItem.CurrentRowIndex
    '  MessageBox.Show(i.ToString)
    'End Sub

    Private Sub iFindProjectDialog_Click(sender As System.Object, e As System.EventArgs) Handles iFindProjectDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
     CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Project, AddressOf SetProject)
    End Sub
    Private Sub SetProject(ByVal e As ISimpleEntity)
      Me.tProjectCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Project.GetProject(tProjectCode, tProjectName, m_entity.Project)
      'Me.ChangeProperty(tProjectCodeq, Nothing)
      RefreshProjectContract()
    End Sub
    Private Sub iFindEmployee1_Click(sender As System.Object, e As System.EventArgs) Handles iFindEmployee1.Click, iFindEmployee2.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      If CType(sender, ImageButton).Name = iFindEmployee1.Name Then
        myEntityPanelService.OpenListDialog(New RunningEmployee, AddressOf SetEmployee)
      ElseIf CType(sender, ImageButton).Name = iFindEmployee2.Name Then
        myEntityPanelService.OpenListDialog(New RunningEmployee, AddressOf SetEmployee2)
      End If
    End Sub
    Private Sub SetEmployee(ByVal e As ISimpleEntity)
      Me.tAcceptPerson1.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Employee.GetEmployee(tAcceptPerson1, tAcceptPerson1Name, m_entity.AcceptPerson)
      'Me.ChangeProperty(tProjectCodeq, Nothing)
    End Sub
    Private Sub SetEmployee2(ByVal e As ISimpleEntity)
      Me.tAcceptPerson2.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Employee.GetEmployee(tAcceptPerson2, tAcceptPerson2Name, m_entity.AcceptPerson2)
      'Me.ChangeProperty(tProjectCodeq, Nothing)
    End Sub

    Private Sub ibtnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles ibtnRefresh.Click
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      ''รายการผังบัญชีของเอกสารนี้จะถูกเขียนทับด้วย รายการผังบัญชีที่กำหนดไว้
      'msgServ.ShowWarning("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceiveDetailView.RefreshItem}")

      Me.m_entity.GetPRPMI()
      Me.RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnShowValue_Click(sender As System.Object, e As System.EventArgs) Handles ibottonShowValue.Click
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      ''รายการผังบัญชีของเอกสารนี้จะถูกเขียนทับด้วย รายการผังบัญชีที่กำหนดไว้
      'msgServ.ShowWarning("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceiveDetailView.RefreshItem}")

      Me.m_entity.GetPRPMIValue()
      Me.RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
  End Class
End Namespace