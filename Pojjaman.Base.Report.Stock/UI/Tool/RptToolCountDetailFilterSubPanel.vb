Imports System.Collections.Generic
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptToolCountDetailFilterSubPanel
    'Inherits UserControl
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel

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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents grbProject As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnSearchProject As System.Windows.Forms.Button
    Friend WithEvents txtSearchProject As System.Windows.Forms.TextBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkonlyRemain As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnlyChecked As System.Windows.Forms.CheckBox
    Friend WithEvents clbCostCenter As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblDocEndDate As System.Windows.Forms.Label
    Friend WithEvents lblDocStartDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents btnGroupFindStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnGroupFindEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGroupCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents btnToolEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnToolStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtToolCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtToolCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents ibtnDown As System.Windows.Forms.Button
    Friend WithEvents ibtnUp As System.Windows.Forms.Button
    Friend WithEvents ChkGroupAll As System.Windows.Forms.CheckBox

    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptToolCountDetailFilterSubPanel))
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtToolCodeEnd = New System.Windows.Forms.TextBox()
      Me.txtToolCodeStart = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtGroupCodeEnd = New System.Windows.Forms.TextBox()
      Me.txtGroupCodeStart = New System.Windows.Forms.TextBox()
      Me.txtSearchProject = New System.Windows.Forms.TextBox()
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ChkGroupAll = New System.Windows.Forms.CheckBox()
      Me.btnGroupFindEnd = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnGroupFindStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbProject = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnDown = New System.Windows.Forms.Button()
      Me.ibtnUp = New System.Windows.Forms.Button()
      Me.btnSearchProject = New System.Windows.Forms.Button()
      Me.chkAll = New System.Windows.Forms.CheckBox()
      Me.chkonlyRemain = New System.Windows.Forms.CheckBox()
      Me.chkOnlyChecked = New System.Windows.Forms.CheckBox()
      Me.clbCostCenter = New System.Windows.Forms.CheckedListBox()
      Me.btnToolEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.btnToolStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblDocStartDate = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblDocEndDate = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbMaster.SuspendLayout()
      Me.grbProject.SuspendLayout()
      Me.SuspendLayout()
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtToolCodeEnd
      '
      Me.Validator.SetDataType(Me.txtToolCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolCodeEnd, "")
      Me.txtToolCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToolCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToolCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToolCodeEnd, System.Drawing.Color.Empty)
      Me.txtToolCodeEnd.Location = New System.Drawing.Point(717, 45)
      Me.Validator.SetMaxValue(Me.txtToolCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtToolCodeEnd, "")
      Me.txtToolCodeEnd.Name = "txtToolCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtToolCodeEnd, "")
      Me.Validator.SetRequired(Me.txtToolCodeEnd, False)
      Me.txtToolCodeEnd.Size = New System.Drawing.Size(102, 21)
      Me.txtToolCodeEnd.TabIndex = 66
      '
      'txtToolCodeStart
      '
      Me.Validator.SetDataType(Me.txtToolCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolCodeStart, "")
      Me.txtToolCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToolCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToolCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToolCodeStart, System.Drawing.Color.Empty)
      Me.txtToolCodeStart.Location = New System.Drawing.Point(559, 44)
      Me.Validator.SetMaxValue(Me.txtToolCodeStart, "")
      Me.Validator.SetMinValue(Me.txtToolCodeStart, "")
      Me.txtToolCodeStart.Name = "txtToolCodeStart"
      Me.Validator.SetRegularExpression(Me.txtToolCodeStart, "")
      Me.Validator.SetRequired(Me.txtToolCodeStart, False)
      Me.txtToolCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtToolCodeStart.TabIndex = 65
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(559, 20)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 40
      '
      'txtGroupCodeEnd
      '
      Me.Validator.SetDataType(Me.txtGroupCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGroupCodeEnd, "")
      Me.txtGroupCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGroupCodeEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGroupCodeEnd, System.Drawing.Color.Empty)
      Me.txtGroupCodeEnd.Location = New System.Drawing.Point(717, 69)
      Me.txtGroupCodeEnd.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtGroupCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtGroupCodeEnd, "")
      Me.txtGroupCodeEnd.Name = "txtGroupCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtGroupCodeEnd, "")
      Me.Validator.SetRequired(Me.txtGroupCodeEnd, False)
      Me.txtGroupCodeEnd.Size = New System.Drawing.Size(102, 21)
      Me.txtGroupCodeEnd.TabIndex = 74
      '
      'txtGroupCodeStart
      '
      Me.Validator.SetDataType(Me.txtGroupCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGroupCodeStart, "")
      Me.txtGroupCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGroupCodeStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGroupCodeStart, System.Drawing.Color.Empty)
      Me.txtGroupCodeStart.Location = New System.Drawing.Point(559, 69)
      Me.txtGroupCodeStart.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtGroupCodeStart, "")
      Me.Validator.SetMinValue(Me.txtGroupCodeStart, "")
      Me.txtGroupCodeStart.Name = "txtGroupCodeStart"
      Me.Validator.SetRegularExpression(Me.txtGroupCodeStart, "")
      Me.Validator.SetRequired(Me.txtGroupCodeStart, False)
      Me.txtGroupCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtGroupCodeStart.TabIndex = 69
      '
      'txtSearchProject
      '
      Me.Validator.SetDataType(Me.txtSearchProject, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSearchProject, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSearchProject, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSearchProject, System.Drawing.Color.Empty)
      Me.txtSearchProject.Location = New System.Drawing.Point(7, 17)
      Me.Validator.SetMaxValue(Me.txtSearchProject, "")
      Me.Validator.SetMinValue(Me.txtSearchProject, "")
      Me.txtSearchProject.Name = "txtSearchProject"
      Me.Validator.SetRegularExpression(Me.txtSearchProject, "")
      Me.Validator.SetRequired(Me.txtSearchProject, False)
      Me.txtSearchProject.Size = New System.Drawing.Size(235, 21)
      Me.txtSearchProject.TabIndex = 25
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.ChkGroupAll)
      Me.grbMaster.Controls.Add(Me.txtGroupCodeEnd)
      Me.grbMaster.Controls.Add(Me.btnGroupFindEnd)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.chkonlyRemain)
      Me.grbMaster.Controls.Add(Me.btnGroupFindStart)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.txtGroupCodeStart)
      Me.grbMaster.Controls.Add(Me.grbProject)
      Me.grbMaster.Controls.Add(Me.btnToolEndFind)
      Me.grbMaster.Controls.Add(Me.Label2)
      Me.grbMaster.Controls.Add(Me.btnToolStartFind)
      Me.grbMaster.Controls.Add(Me.lblDocStartDate)
      Me.grbMaster.Controls.Add(Me.txtToolCodeEnd)
      Me.grbMaster.Controls.Add(Me.Label1)
      Me.grbMaster.Controls.Add(Me.txtToolCodeStart)
      Me.grbMaster.Controls.Add(Me.lblDocEndDate)
      Me.grbMaster.Controls.Add(Me.txtDocDateEnd)
      Me.grbMaster.Controls.Add(Me.lblDocDateEnd)
      Me.grbMaster.Controls.Add(Me.dtpDocDateEnd)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(3, 3)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(856, 233)
      Me.grbMaster.TabIndex = 1
      Me.grbMaster.TabStop = False
      '
      'ChkGroupAll
      '
      Me.ChkGroupAll.AutoSize = True
      Me.ChkGroupAll.Location = New System.Drawing.Point(559, 101)
      Me.ChkGroupAll.Name = "ChkGroupAll"
      Me.ChkGroupAll.Size = New System.Drawing.Size(145, 17)
      Me.ChkGroupAll.TabIndex = 29
      Me.ChkGroupAll.Text = "รวมยอดตามกลุ่มเครื่องมือ"
      Me.ChkGroupAll.UseVisualStyleBackColor = True
      '
      'btnGroupFindEnd
      '
      Me.btnGroupFindEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnGroupFindEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupFindEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.btnGroupFindEnd.Location = New System.Drawing.Point(820, 68)
      Me.btnGroupFindEnd.Name = "btnGroupFindEnd"
      Me.btnGroupFindEnd.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupFindEnd.TabIndex = 73
      Me.btnGroupFindEnd.TabStop = False
      Me.btnGroupFindEnd.ThemedImage = CType(resources.GetObject("btnGroupFindEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(764, 204)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(80, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnGroupFindStart
      '
      Me.btnGroupFindStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnGroupFindStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupFindStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnGroupFindStart.Location = New System.Drawing.Point(655, 68)
      Me.btnGroupFindStart.Name = "btnGroupFindStart"
      Me.btnGroupFindStart.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupFindStart.TabIndex = 71
      Me.btnGroupFindStart.TabStop = False
      Me.btnGroupFindStart.ThemedImage = CType(resources.GetObject("btnGroupFindStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(683, 204)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(80, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'grbProject
      '
      Me.grbProject.Controls.Add(Me.ibtnDown)
      Me.grbProject.Controls.Add(Me.ibtnUp)
      Me.grbProject.Controls.Add(Me.btnSearchProject)
      Me.grbProject.Controls.Add(Me.txtSearchProject)
      Me.grbProject.Controls.Add(Me.chkAll)
      Me.grbProject.Controls.Add(Me.chkOnlyChecked)
      Me.grbProject.Controls.Add(Me.clbCostCenter)
      Me.grbProject.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbProject.Location = New System.Drawing.Point(15, 13)
      Me.grbProject.Name = "grbProject"
      Me.grbProject.Size = New System.Drawing.Size(429, 211)
      Me.grbProject.TabIndex = 0
      Me.grbProject.TabStop = False
      Me.grbProject.Text = "Cost Center"
      '
      'ibtnDown
      '
      Me.ibtnDown.Image = CType(resources.GetObject("ibtnDown.Image"), System.Drawing.Image)
      Me.ibtnDown.Location = New System.Drawing.Point(299, 77)
      Me.ibtnDown.Name = "ibtnDown"
      Me.ibtnDown.Size = New System.Drawing.Size(34, 37)
      Me.ibtnDown.TabIndex = 28
      Me.ibtnDown.UseVisualStyleBackColor = False
      '
      'ibtnUp
      '
      Me.ibtnUp.Image = CType(resources.GetObject("ibtnUp.Image"), System.Drawing.Image)
      Me.ibtnUp.Location = New System.Drawing.Point(299, 40)
      Me.ibtnUp.Name = "ibtnUp"
      Me.ibtnUp.Size = New System.Drawing.Size(34, 37)
      Me.ibtnUp.TabIndex = 27
      Me.ibtnUp.UseVisualStyleBackColor = False
      '
      'btnSearchProject
      '
      Me.btnSearchProject.Location = New System.Drawing.Point(242, 16)
      Me.btnSearchProject.Name = "btnSearchProject"
      Me.btnSearchProject.Size = New System.Drawing.Size(51, 23)
      Me.btnSearchProject.TabIndex = 26
      Me.btnSearchProject.Text = "ค้นหา"
      Me.btnSearchProject.UseVisualStyleBackColor = True
      '
      'chkAll
      '
      Me.chkAll.AutoSize = True
      Me.chkAll.Location = New System.Drawing.Point(10, 191)
      Me.chkAll.Name = "chkAll"
      Me.chkAll.Size = New System.Drawing.Size(85, 17)
      Me.chkAll.TabIndex = 24
      Me.chkAll.Text = "เลือกทั้งหมด"
      Me.chkAll.UseMnemonic = False
      Me.chkAll.UseVisualStyleBackColor = True
      '
      'chkonlyRemain
      '
      Me.chkonlyRemain.AutoSize = True
      Me.chkonlyRemain.Location = New System.Drawing.Point(559, 122)
      Me.chkonlyRemain.Name = "chkonlyRemain"
      Me.chkonlyRemain.Size = New System.Drawing.Size(117, 17)
      Me.chkonlyRemain.TabIndex = 23
      Me.chkonlyRemain.Text = "แสดงเฉพาะคงเหลือ"
      Me.chkonlyRemain.UseVisualStyleBackColor = True
      '
      'chkOnlyChecked
      '
      Me.chkOnlyChecked.AutoSize = True
      Me.chkOnlyChecked.Location = New System.Drawing.Point(299, 129)
      Me.chkOnlyChecked.Name = "chkOnlyChecked"
      Me.chkOnlyChecked.Size = New System.Drawing.Size(113, 17)
      Me.chkOnlyChecked.TabIndex = 22
      Me.chkOnlyChecked.Text = "แสดงเฉพาะที่เลือก"
      Me.chkOnlyChecked.UseMnemonic = False
      Me.chkOnlyChecked.UseVisualStyleBackColor = True
      '
      'clbCostCenter
      '
      Me.clbCostCenter.FormattingEnabled = True
      Me.clbCostCenter.Location = New System.Drawing.Point(7, 41)
      Me.clbCostCenter.Name = "clbCostCenter"
      Me.clbCostCenter.Size = New System.Drawing.Size(286, 148)
      Me.clbCostCenter.TabIndex = 21
      '
      'btnToolEndFind
      '
      Me.btnToolEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolEndFind.Location = New System.Drawing.Point(820, 44)
      Me.btnToolEndFind.Name = "btnToolEndFind"
      Me.btnToolEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnToolEndFind.TabIndex = 68
      Me.btnToolEndFind.TabStop = False
      Me.btnToolEndFind.ThemedImage = CType(resources.GetObject("btnToolEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(471, 49)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(82, 13)
      Me.Label2.TabIndex = 28
      Me.Label2.Text = "เครื่องมือ ตั้งแต่:"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnToolStartFind
      '
      Me.btnToolStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolStartFind.Location = New System.Drawing.Point(655, 43)
      Me.btnToolStartFind.Name = "btnToolStartFind"
      Me.btnToolStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnToolStartFind.TabIndex = 67
      Me.btnToolStartFind.TabStop = False
      Me.btnToolStartFind.ThemedImage = CType(resources.GetObject("btnToolStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDocStartDate
      '
      Me.lblDocStartDate.AutoSize = True
      Me.lblDocStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocStartDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocStartDate.Location = New System.Drawing.Point(450, 75)
      Me.lblDocStartDate.Name = "lblDocStartDate"
      Me.lblDocStartDate.Size = New System.Drawing.Size(103, 13)
      Me.lblDocStartDate.TabIndex = 21
      Me.lblDocStartDate.Text = "กลุ่มเครื่องมือ ตั้งแต่:"
      Me.lblDocStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(689, 47)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(22, 13)
      Me.Label1.TabIndex = 30
      Me.Label1.Text = "ถึง:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocEndDate
      '
      Me.lblDocEndDate.AutoSize = True
      Me.lblDocEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocEndDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocEndDate.Location = New System.Drawing.Point(689, 71)
      Me.lblDocEndDate.Name = "lblDocEndDate"
      Me.lblDocEndDate.Size = New System.Drawing.Size(22, 13)
      Me.lblDocEndDate.TabIndex = 24
      Me.lblDocEndDate.Text = "ถึง:"
      Me.lblDocEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.AutoSize = True
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(510, 23)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(43, 13)
      Me.lblDocDateEnd.TabIndex = 39
      Me.lblDocDateEnd.Text = "ณ วันที่:"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(559, 20)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 41
      Me.dtpDocDateEnd.TabStop = False
      '
      'RptToolCountDetailFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptToolCountDetailFilterSubPanel"
      Me.Size = New System.Drawing.Size(875, 242)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbProject.ResumeLayout(False)
      Me.grbProject.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptToolCountDetailFilterSubPanel.grbMaster}")
      Me.grbProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptToolCountDetailFilterSubPanel.grbProject}")
      Me.ChkGroupAll.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptToolCountDetailFilterSubPanel.ChkGroupAll}")
    End Sub
#End Region

#Region "Member"
    Private DocList As String
    Private CCIdList As String
    Private CCList As Dictionary(Of String, CostCenter)
    'Private CCList As List(Of KeyValuePair(Of String, String))
    Private CCIndexList As IDictionary(Of Integer, Integer)

    Private m_equipmentstart As Equipment
    Private m_equipmentend As Equipment

    Private m_toolstart As Tool
    Private m_toolend As Tool

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Dim m_toolgroupstart As New ToolGroup
    Dim m_toolgroupend As New ToolGroup
    Private m_cc As CostCenter

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      clbCostCenter.CheckOnClick = True


      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property DocDateEnd() As Date
      Get
        Return m_DocDateEnd
      End Get
      Set(ByVal Value As Date)
        m_DocDateEnd = Value
      End Set
    End Property

    Public Property DocDateStart() As Date
      Get
        Return m_DocDateStart
      End Get
      Set(ByVal Value As Date)
        m_DocDateStart = Value
      End Set
    End Property

    Public Property Toolstart() As Tool
      Get
        Return m_toolstart
      End Get
      Set(ByVal Value As Tool)
        m_toolstart = Value
      End Set
    End Property
    Public Property ToolEnd() As Tool
      Get
        Return m_toolend
      End Get
      Set(ByVal Value As Tool)
        m_toolend = Value
      End Set
    End Property
    Private Property GroupStart() As ToolGroup
      Get
        Return m_toolgroupstart
      End Get
      Set(ByVal Value As ToolGroup)
        m_toolgroupstart = Value
      End Set
    End Property
    Private Property GroupEnd() As ToolGroup
      Get
        Return m_toolgroupend
      End Get
      Set(ByVal Value As ToolGroup)
        m_toolgroupend = Value
      End Set
    End Property
    Public Property equipmentstart() As Equipment
      Get
        Return m_equipmentstart
      End Get
      Set(ByVal Value As Equipment)
        m_equipmentstart = Value
      End Set
    End Property
    Public Property EquipmentEnd() As Equipment
      Get
        Return m_equipmentend
      End Get
      Set(ByVal Value As Equipment)
        m_equipmentend = Value
      End Set
    End Property


#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler btnToolStartFind.Click, AddressOf Me.btnToolFind_Click
      AddHandler btnToolEndFind.Click, AddressOf Me.btnToolFind_Click

      AddHandler btnGroupFindStart.Click, AddressOf Me.btnToolFind_Click
      AddHandler btnGroupFindEnd.Click, AddressOf Me.btnToolFind_Click

      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower

        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          End If
          m_dateSetting = False
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False

        Case Else

      End Select
    End Sub
#End Region

#Region "Methods"
    Private Sub btnSearchProject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchProject.Click
      If txtSearchProject.Text.Trim.Length = 0 Then
        RefreshCheckCCListBox()
      Else
        RefreshCheckCCListBoxFilter(txtSearchProject.Text.Trim)
      End If
    End Sub
    Private Sub RefreshCheckCCListBoxFilter(ByVal textFilter As String)
      Dim notonlychecked As Boolean = Not chkOnlyChecked.Checked
      Dim onlyRemain As Boolean = chkonlyRemain.Checked

      Dim ccFilterList As Dictionary(Of String, CostCenter) = New Dictionary(Of String, CostCenter)
      Dim ccHash As New Hashtable
      Dim ccdt As DataTable = Me.CostCenterSchema
      For Each kv As KeyValuePair(Of String, CostCenter) In CCList
        Dim dr As DataRow = ccdt.NewRow
        dr("cc_code") = kv.Value.Code
        dr("cc_name") = kv.Value.Name
        ccdt.Rows.Add(dr)
        ccHash(kv.Value.Code) = kv.Value
      Next

      textFilter = Replace(Replace(Replace(Replace(textFilter, "%", ""), "'", ""), "?", ""), "*", "")

      Dim ccCode As String = ""
      Dim cc As CostCenter
      For Each dr_ As DataRow In ccdt.Select("cc_code like '%" & textFilter & "%' or cc_name like '%" & textFilter & "%'")
        ccCode = CStr(dr_("cc_code"))
        cc = CType(ccHash(ccCode), CostCenter)
        If Not ccFilterList.ContainsKey(ccCode) Then
          ccFilterList.Add(ccCode, cc)
        End If
      Next

      Dim chkCode As New List(Of String)
      For Each chki As Object In clbCostCenter.CheckedItems
        Dim s As String = chki.ToString.Split(CChar(":"))(0)
        If Not chkCode.Contains(s) Then
          chkCode.Add(s)
          cc = CType(ccHash(s), CostCenter)
          If Not ccFilterList.ContainsKey(s) Then
            ccFilterList.Add(s, cc)
          End If
        End If
      Next

      clbCostCenter.Items.Clear()
      For Each kv As KeyValuePair(Of String, CostCenter) In ccFilterList
        'If (kv.Value.IsActive OrElse onlyRemain) AndAlso (notonlychecked OrElse chkCode.Contains(kv.Key)) Then
        If (notonlychecked OrElse chkCode.Contains(kv.Key)) Then
          Dim chk As Boolean = chkCode.Contains(kv.Key)
          Dim list As String = kv.Value.Code & ":" & kv.Value.Name
          Dim ob As New IdValuePair(kv.Value.Id, list)
          clbCostCenter.Items.Add(ob, chk)
        End If
      Next


    End Sub
    Private Function CostCenterSchema() As DataTable
      Dim dt As New DataTable
      Dim dcc As New DataColumn("cc_code")
      Dim dcn As New DataColumn("cc_name")
      dt.Columns.Add(dcc)
      dt.Columns.Add(dcn)
      Return dt
    End Function
    Private Sub LoadCostCenter() Handles chkonlyRemain.CheckedChanged
      Dim currentuserid As Integer = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id

      Dim dt As DataTable = CostCenter.GetCostCenterSet()

      CCList = New Dictionary(Of String, CostCenter)
      'CCList = CostCenter.CostCenterRightList(currentuserid)

      For Each row As DataRow In dt.Rows

        Dim cc As New CostCenter
        CostCenter.SetMinimumCC(cc, row)
        If Not CCList.ContainsKey(cc.Code) Then
          CCList.Add(cc.Code, cc)
        End If
      Next

      RefreshCheckCCListBox()

    End Sub

    Private Sub Initialize()
      CCIndexList = New Dictionary(Of Integer, Integer)
      LoadCostCenter()
      ClearCriterias()
    End Sub

    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbMaster.Controls
        If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf Ctrl Is TextBox Then
              Ctrl.Text = ""
            End If
          Next
        ElseIf TypeOf grbCtrl Is TextBox Then
          grbCtrl.Text = ""
        End If
      Next
      m_dateSetting = True

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      chkAll.Checked = False
      chkonlyRemain.Checked = True
      chkOnlyChecked.Checked = False

      Me.m_equipmentstart = New Equipment
      Me.m_equipmentend = New Equipment

      Me.m_toolstart = New Tool
      Me.m_toolend = New Tool

      Me.m_toolgroupstart = New ToolGroup
      Me.m_toolgroupend = New ToolGroup

      Me.CCIdList = ""

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(8) As Filter
      arr(0) = New Filter("CCCodeList", CheckedCCListString)
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("ToolCodeStart", IIf(txtToolCodeStart.TextLength > 0, txtToolCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("ToolCodeEnd", IIf(txtToolCodeEnd.TextLength > 0, txtToolCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("ToolGroupStart", IIf(txtGroupCodeStart.TextLength > 0, txtGroupCodeStart.Text, DBNull.Value))
      arr(5) = New Filter("ToolGroupEnd", IIf(txtGroupCodeEnd.TextLength > 0, txtGroupCodeEnd.Text, DBNull.Value))
      arr(6) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(7) = New Filter("onlyRemain", Me.chkonlyRemain.Checked)
      arr(8) = New Filter("showGroupSummary", Me.ChkGroupAll.Checked)
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

#Region " Event Handlers "
    Private Function CheckedCCListString() As String

      Dim chkId As New List(Of String)
      Dim order As Integer = 0
      For Each chki As Object In clbCostCenter.CheckedItems
        Dim s As String = CType(chki, IdValuePair).Value.Split(CChar(":"))(0)
        s = s & "|" & order.ToString
        chkId.Add(s)
        order += 1
      Next

      Return String.Join(",", chkId)
    End Function
    Private Sub RefreshCheckCCListBox() Handles chkOnlyChecked.CheckedChanged
      Dim notonlychecked As Boolean = Not chkOnlyChecked.Checked
      Dim onlyRemain As Boolean = chkonlyRemain.Checked

      Dim chkCode As New List(Of String)
      For Each chki As Object In clbCostCenter.CheckedItems
        Dim s As String = chki.ToString.Split(CChar(":"))(0)
        chkCode.Add(s)
      Next

      clbCostCenter.Items.Clear()

      For Each kv As KeyValuePair(Of String, CostCenter) In CCList

        'If (kv.Value.IsActive OrElse onlyRemain) AndAlso (notonlychecked OrElse chkCode.Contains(kv.Key)) Then
        If (notonlychecked OrElse chkCode.Contains(kv.Key)) Then
          Dim chk As Boolean = chkCode.Contains(kv.Key)
          Dim list As String = kv.Value.Code & ":" & kv.Value.Name
          Dim ob As New IdValuePair(kv.Value.Id, list)
          clbCostCenter.Items.Add(ob, chk)
        End If
      Next

    End Sub
    Private checking As Boolean = False
    Private Sub CheckedALLCC() Handles chkAll.CheckedChanged
      If checking Then
        Return
      End If
      Dim chk As Boolean = chkAll.Checked
      For i As Integer = 0 To Me.clbCostCenter.Items.Count - 1
        Me.clbCostCenter.SetItemChecked(i, chk)
      Next

    End Sub
    Private Sub clbCostCenter_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clbCostCenter.MouseUp
      CheckChanged()
    End Sub
    Private Sub clbCostCenter_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles clbCostCenter.KeyUp
      CheckChanged()
    End Sub
    Private Sub CheckChanged()
      checking = True
      If clbCostCenter.CheckedItems.Count = 0 Then
        chkAll.CheckState = CheckState.Unchecked
      ElseIf clbCostCenter.CheckedItems.Count = clbCostCenter.Items.Count Then
        chkAll.CheckState = CheckState.Checked
      Else
        chkAll.CheckState = CheckState.Indeterminate
      End If
      checking = False
    End Sub

    Private Sub btnToolFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btntoolstartfind"

          myEntityPanelService.OpenListDialog(New Tool, AddressOf SetToolStartDialog)

        Case "btntoolendfind"
          myEntityPanelService.OpenListDialog(New Tool, AddressOf SetToolEndDialog)
      End Select
    End Sub

    Dim tmp1 As New TextBox
    Private Sub SetToolStartDialog(ByVal e As ISimpleEntity)
      Me.txtToolCodeStart.Text = e.Code
      Tool.GetTool(txtToolCodeStart, tmp1, Me.Toolstart)
    End Sub

    Private Sub SetToolEndDialog(ByVal e As ISimpleEntity)
      Me.txtToolCodeEnd.Text = e.Code
      Tool.GetTool(txtToolCodeEnd, tmp1, Me.ToolEnd)
    End Sub

    Private Sub btnGroupFindStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFindStart.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New ToolGroup, AddressOf SetToolGroupStart)
    End Sub

    Private Sub txtGroupCodeStart_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupCodeStart.Validated
      ToolGroup.GetToolGroup(txtGroupCodeStart, tmp1, Me.GroupStart)
    End Sub
    Private Sub SetToolGroupStart(ByVal e As ISimpleEntity)
      Me.txtGroupCodeStart.Text = e.Code
      ToolGroup.GetToolGroup(txtGroupCodeStart, tmp1, Me.GroupStart)
    End Sub

    Private Sub btnGroupFindEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFindEnd.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New ToolGroup, AddressOf SetToolGroupEnd)
    End Sub

    Private Sub txtGroupCodeEnd_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupCodeEnd.Validated
      ToolGroup.GetToolGroup(txtGroupCodeEnd, tmp1, Me.GroupEnd)
    End Sub
    Private Sub SetToolGroupEnd(ByVal e As ISimpleEntity)
      Me.txtGroupCodeEnd.Text = e.Code
      ToolGroup.GetToolGroup(txtGroupCodeEnd, tmp1, Me.GroupEnd)
    End Sub

#End Region

#Region "IReportFilterSubPanel"
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'EquipmentCodeStart 
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolCodeStart"
      dpi.Value = Me.txtToolCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'EquipmentCodeEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolCodeEnd"
      dpi.Value = Me.txtToolCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'GroupCodeStart 
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolGroupStart"
      dpi.Value = Me.txtGroupCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'GroupCodeEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolGroupEnd"
      dpi.Value = Me.txtGroupCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'DocDateEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDateEnd"
      dpi.Value = txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function

#End Region


#Region "IClipboardHandler Overrides"

#End Region

    Private Sub grbMaster_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ibtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnUp.Click
      Dim code As String = clbCostCenter.SelectedItem.ToString
      Dim index As Integer = clbCostCenter.SelectedIndex
      Dim chk As Boolean = clbCostCenter.CheckedItems.Contains(clbCostCenter.SelectedItem)
      Dim swap As Object = clbCostCenter.SelectedItem
      If Not (swap Is Nothing) AndAlso index >= 1 Then               'If something is selected...
        clbCostCenter.Items.RemoveAt(index)                   'Remove it
        clbCostCenter.Items.Insert(index - 1, swap)           'Add it back in one spot up
        clbCostCenter.SetItemChecked(index - 1, chk)
        clbCostCenter.SelectedItem = swap                     'Keep this item selected

      End If
    End Sub

    Private Sub ibtnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDown.Click
      Dim index As Integer = clbCostCenter.SelectedIndex
      Dim swap As Object = clbCostCenter.SelectedItem
      Dim chk As Boolean = clbCostCenter.CheckedItems.Contains(clbCostCenter.SelectedItem)
      If Not (swap Is Nothing) AndAlso index < clbCostCenter.Items.Count - 1 Then     'If something is selected...
        clbCostCenter.Items.RemoveAt(index)                   'Remove it
        clbCostCenter.Items.Insert(index + 1, swap)           'Add it back in one spot up
        clbCostCenter.SetItemChecked(index + 1, chk)
        clbCostCenter.SelectedItem = swap                     'Keep this item selected
      End If
    End Sub

    Private Sub LoadCostCenter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkonlyRemain.CheckedChanged

    End Sub
  End Class
End Namespace

