Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Collections.Generic
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BudgetPanelView
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
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ibtnShowEstimator As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowEstimatorDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtEstimatorName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowProject As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowProjectDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtEstimatorCode As System.Windows.Forms.TextBox
    Friend WithEvents lblEstimator As System.Windows.Forms.Label
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnImportFromExcel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnInsert As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents dtpEnd As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents dtpStart As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BudgetPanelView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpEnd = New Telerik.WinControls.UI.RadDateTimePicker()
      Me.dtpStart = New Telerik.WinControls.UI.RadDateTimePicker()
      Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnInsert = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtProjectCode = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.ibtnImportFromExcel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtEstimatorCode = New System.Windows.Forms.TextBox()
      Me.lblProject = New System.Windows.Forms.Label()
      Me.ibtnShowProjectDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblEstimator = New System.Windows.Forms.Label()
      Me.ibtnShowProject = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtEstimatorName = New System.Windows.Forms.TextBox()
      Me.txtProjectName = New System.Windows.Forms.TextBox()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowEstimatorDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowEstimator = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.Button1 = New System.Windows.Forms.Button()
      Me.grbDetail.SuspendLayout()
      CType(Me.dtpEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dtpStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.Button1)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.dtpEnd)
      Me.grbDetail.Controls.Add(Me.dtpStart)
      Me.grbDetail.Controls.Add(Me.RadGridView1)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.ibtnInsert)
      Me.grbDetail.Controls.Add(Me.txtProjectCode)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.ibtnImportFromExcel)
      Me.grbDetail.Controls.Add(Me.txtEstimatorCode)
      Me.grbDetail.Controls.Add(Me.lblProject)
      Me.grbDetail.Controls.Add(Me.ibtnShowProjectDialog)
      Me.grbDetail.Controls.Add(Me.lblEstimator)
      Me.grbDetail.Controls.Add(Me.ibtnShowProject)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.txtEstimatorName)
      Me.grbDetail.Controls.Add(Me.txtProjectName)
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.Controls.Add(Me.ibtnShowEstimatorDialog)
      Me.grbDetail.Controls.Add(Me.ibtnShowEstimator)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(1048, 624)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "Detail"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label1.Location = New System.Drawing.Point(661, 104)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(31, 18)
      Me.Label1.TabIndex = 335
      Me.Label1.Text = "TO"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpEnd
      '
      Me.dtpEnd.AutoSize = True
      Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpEnd.Location = New System.Drawing.Point(702, 102)
      Me.dtpEnd.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
      Me.dtpEnd.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
      Me.dtpEnd.Name = "dtpEnd"
      Me.dtpEnd.NullDate = New Date(1900, 1, 1, 0, 0, 0, 0)
      Me.dtpEnd.Size = New System.Drawing.Size(96, 23)
      Me.dtpEnd.TabIndex = 334
      Me.dtpEnd.TabStop = False
      Me.dtpEnd.Text = "c"
      Me.dtpEnd.Value = New Date(2010, 6, 16, 17, 4, 25, 351)
      '
      'dtpStart
      '
      Me.dtpStart.AutoSize = True
      Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpStart.Location = New System.Drawing.Point(563, 102)
      Me.dtpStart.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
      Me.dtpStart.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
      Me.dtpStart.Name = "dtpStart"
      Me.dtpStart.NullDate = New Date(1900, 1, 1, 0, 0, 0, 0)
      Me.dtpStart.Size = New System.Drawing.Size(96, 23)
      Me.dtpStart.TabIndex = 333
      Me.dtpStart.TabStop = False
      Me.dtpStart.Value = New Date(2010, 6, 16, 17, 4, 25, 351)
      '
      'RadGridView1
      '
      Me.RadGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.RadGridView1.Location = New System.Drawing.Point(14, 130)
      Me.RadGridView1.Name = "RadGridView1"
      Me.RadGridView1.Size = New System.Drawing.Size(1028, 488)
      Me.RadGridView1.TabIndex = 331
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(123, 100)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 14
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(171, 100)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 16
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnInsert
      '
      Me.ibtnInsert.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnInsert.Location = New System.Drawing.Point(147, 100)
      Me.ibtnInsert.Name = "ibtnInsert"
      Me.ibtnInsert.Size = New System.Drawing.Size(24, 24)
      Me.ibtnInsert.TabIndex = 15
      Me.ibtnInsert.TabStop = False
      Me.ibtnInsert.ThemedImage = CType(resources.GetObject("ibtnInsert.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtProjectCode
      '
      Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
      Me.txtProjectCode.Location = New System.Drawing.Point(123, 20)
      Me.Validator.SetMinValue(Me.txtProjectCode, "")
      Me.txtProjectCode.Name = "txtProjectCode"
      Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
      Me.Validator.SetRequired(Me.txtProjectCode, False)
      Me.txtProjectCode.Size = New System.Drawing.Size(144, 21)
      Me.txtProjectCode.TabIndex = 1
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCode.Location = New System.Drawing.Point(11, 71)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(112, 18)
      Me.lblCode.TabIndex = 12
      Me.lblCode.Text = "Budget Name:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnImportFromExcel
      '
      Me.ibtnImportFromExcel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnImportFromExcel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnImportFromExcel.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnImportFromExcel.Location = New System.Drawing.Point(635, 20)
      Me.ibtnImportFromExcel.Name = "ibtnImportFromExcel"
      Me.ibtnImportFromExcel.Size = New System.Drawing.Size(24, 23)
      Me.ibtnImportFromExcel.TabIndex = 6
      Me.ibtnImportFromExcel.TabStop = False
      Me.ibtnImportFromExcel.ThemedImage = CType(resources.GetObject("ibtnImportFromExcel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtEstimatorCode
      '
      Me.Validator.SetDataType(Me.txtEstimatorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEstimatorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEstimatorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEstimatorCode, System.Drawing.Color.Empty)
      Me.txtEstimatorCode.Location = New System.Drawing.Point(123, 45)
      Me.Validator.SetMinValue(Me.txtEstimatorCode, "")
      Me.txtEstimatorCode.Name = "txtEstimatorCode"
      Me.Validator.SetRegularExpression(Me.txtEstimatorCode, "")
      Me.Validator.SetRequired(Me.txtEstimatorCode, False)
      Me.txtEstimatorCode.Size = New System.Drawing.Size(144, 21)
      Me.txtEstimatorCode.TabIndex = 8
      '
      'lblProject
      '
      Me.lblProject.BackColor = System.Drawing.Color.Transparent
      Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProject.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblProject.Location = New System.Drawing.Point(11, 20)
      Me.lblProject.Name = "lblProject"
      Me.lblProject.Size = New System.Drawing.Size(112, 18)
      Me.lblProject.TabIndex = 0
      Me.lblProject.Text = "Project:"
      Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowProjectDialog
      '
      Me.ibtnShowProjectDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowProjectDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowProjectDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowProjectDialog.Location = New System.Drawing.Point(539, 20)
      Me.ibtnShowProjectDialog.Name = "ibtnShowProjectDialog"
      Me.ibtnShowProjectDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowProjectDialog.TabIndex = 3
      Me.ibtnShowProjectDialog.TabStop = False
      Me.ibtnShowProjectDialog.ThemedImage = CType(resources.GetObject("ibtnShowProjectDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblEstimator
      '
      Me.lblEstimator.BackColor = System.Drawing.Color.Transparent
      Me.lblEstimator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEstimator.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblEstimator.Location = New System.Drawing.Point(11, 46)
      Me.lblEstimator.Name = "lblEstimator"
      Me.lblEstimator.Size = New System.Drawing.Size(112, 18)
      Me.lblEstimator.TabIndex = 7
      Me.lblEstimator.Text = "Estimator:"
      Me.lblEstimator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnShowProject
      '
      Me.ibtnShowProject.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowProject.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowProject.Location = New System.Drawing.Point(563, 20)
      Me.ibtnShowProject.Name = "ibtnShowProject"
      Me.ibtnShowProject.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowProject.TabIndex = 4
      Me.ibtnShowProject.TabStop = False
      Me.ibtnShowProject.ThemedImage = CType(resources.GetObject("ibtnShowProject.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCode
      '
      Me.txtCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -13)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(123, 71)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(464, 21)
      Me.txtCode.TabIndex = 13
      '
      'txtEstimatorName
      '
      Me.txtEstimatorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtEstimatorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEstimatorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEstimatorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEstimatorName, System.Drawing.Color.Empty)
      Me.txtEstimatorName.Location = New System.Drawing.Point(267, 45)
      Me.Validator.SetMinValue(Me.txtEstimatorName, "")
      Me.txtEstimatorName.Name = "txtEstimatorName"
      Me.txtEstimatorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEstimatorName, "")
      Me.Validator.SetRequired(Me.txtEstimatorName, False)
      Me.txtEstimatorName.Size = New System.Drawing.Size(272, 21)
      Me.txtEstimatorName.TabIndex = 9
      Me.txtEstimatorName.TabStop = False
      '
      'txtProjectName
      '
      Me.txtProjectName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtProjectName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
      Me.txtProjectName.Location = New System.Drawing.Point(267, 20)
      Me.Validator.SetMinValue(Me.txtProjectName, "")
      Me.txtProjectName.Name = "txtProjectName"
      Me.txtProjectName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtProjectName, "")
      Me.Validator.SetRequired(Me.txtProjectName, False)
      Me.txtProjectName.Size = New System.Drawing.Size(272, 21)
      Me.txtProjectName.TabIndex = 2
      Me.txtProjectName.TabStop = False
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(611, 20)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 5
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowEstimatorDialog
      '
      Me.ibtnShowEstimatorDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEstimatorDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEstimatorDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEstimatorDialog.Location = New System.Drawing.Point(539, 44)
      Me.ibtnShowEstimatorDialog.Name = "ibtnShowEstimatorDialog"
      Me.ibtnShowEstimatorDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEstimatorDialog.TabIndex = 10
      Me.ibtnShowEstimatorDialog.TabStop = False
      Me.ibtnShowEstimatorDialog.ThemedImage = CType(resources.GetObject("ibtnShowEstimatorDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowEstimator
      '
      Me.ibtnShowEstimator.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEstimator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEstimator.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEstimator.Location = New System.Drawing.Point(563, 44)
      Me.ibtnShowEstimator.Name = "ibtnShowEstimator"
      Me.ibtnShowEstimator.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEstimator.TabIndex = 11
      Me.ibtnShowEstimator.TabStop = False
      Me.ibtnShowEstimator.ThemedImage = CType(resources.GetObject("ibtnShowEstimator.ThemedImage"), System.Drawing.Bitmap)
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
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(201, 101)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 336
      Me.Button1.Text = "Cash Flow"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'BudgetPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "BudgetPanelView"
      Me.Size = New System.Drawing.Size(1072, 640)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.dtpEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dtpStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      RadGridView1.EnableGrouping = False
      RadGridView1.EnableSorting = False

      GetColumns()
      Me.RadGridView1.MasterGridViewTemplate.AllowAddNewRow = False

      EventWiring()
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"

#End Region

    Private m_entity As Budget
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          'm_level = 0
          'Me.lblLevel.Text = m_level.ToString()
          If Not Me.m_entity Is Nothing Then
            Me.m_entity.Dispose()
            Me.m_entity = Nothing
          End If
          Me.m_entity = CType(Value, Budget)
        End If
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        If Me.WorkbenchWindow.ActiveViewContent Is Me Then
          UpdateEntityProperties()
        End If
      End Set
    End Property
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPanelView.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPanelView.lblCode}")
      Me.lblEstimator.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPanelView.lblEstimator}")
      Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPanelView.lblProject}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtEstimatorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtProjectCode.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpEnd.ValueChanged, AddressOf Me.ChangeProperty

    End Sub
    Private m_isInitialized As Boolean = False
    Private m_colList As List(Of GridViewTextBoxColumn)
    Private m_colGroupList As List(Of GridViewColumnGroup)
    Private m_weekList As Dictionary(Of Week, GridViewTextBoxColumn)
    Private Sub UpdateWeeks()
      If Not m_colGroupList Is Nothing Then
        For Each col As GridViewColumnGroup In m_colGroupList
          viewDef.ColumnGroups.Remove(col)
        Next
      End If
      If Not m_colList Is Nothing Then
        For Each col As GridViewTextBoxColumn In m_colList
          RadGridView1.Columns.Remove(col)
        Next
      End If
      m_colList = New List(Of GridViewTextBoxColumn)
      m_colGroupList = New List(Of GridViewColumnGroup)
      m_weekList = New Dictionary(Of Week, GridViewTextBoxColumn)
      Dim ws As List(Of Week) = m_entity.GetWeeks
      Dim i As Integer = 0
      Dim dateList As New List(Of String)
      dateList.Add("1-7")
      dateList.Add("8-14")
      dateList.Add("15-21")
      dateList.Add("22-31")

      For Each w As Week In ws
        Dim colGroup As GridViewColumnGroup
        If w.Number = 1 Then
          Dim gc As New GridViewTextBoxColumn("Col" & i.ToString)
          gc.HeaderText = ""
          gc.Width = 10
          m_colList.Add(gc)
          RadGridView1.Columns.Add(gc)

          colGroup = New GridViewColumnGroup(MonthName(w.Month) & " " & w.Year)
          m_colGroupList.Add(colGroup)
          viewDef.ColumnGroups.Add(colGroup)
          colGroup.Rows.Add(New GridViewColumnGroupRow())
          i += 1
        End If

        Dim col As New GridViewTextBoxColumn("Col" & i.ToString)
        col.HeaderText = dateList(w.Number - 1)
        col.TextAlignment = ContentAlignment.MiddleRight
        col.Width = 90
        RadGridView1.Columns.Add(col)
        colGroup.Rows(0).Columns.Add(col)
        m_weekList(w) = col

        i += 1
      Next
      Me.RadGridView1.ViewDefinition = viewDef
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      txtCode.Text = m_entity.Code
      txtProjectCode.Text = m_entity.Project.Code
      txtProjectName.Text = m_entity.Project.Name

      txtEstimatorCode.Text = m_entity.Estimator.Code
      txtEstimatorName.Text = m_entity.Estimator.Name

      dtpStart.Value = m_entity.StartDate
      dtpEnd.Value = m_entity.EndDate

      UpdateWeeks()

      RefreshItems()

      'SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtestimatorcode"
          dirtyFlag = Employee.GetEmployee(txtEstimatorCode, txtEstimatorName, Me.m_entity.Estimator)
        Case "txtprojectcode"
          dirtyFlag = Project.GetProject(txtProjectCode, txtProjectName, Me.m_entity.Project)
        Case "dtpstart"
          m_entity.StartDate = dtpStart.Value
          For Each w As WorkBreakdownStructure In m_entity.Childs
            w.UpdatePlan()
          Next
          UpdateWeeks()
          RefreshItems()
          dirtyFlag = True
        Case "dtpend"
          m_entity.EndDate = dtpEnd.Value
          For Each w As WorkBreakdownStructure In m_entity.Childs
            w.UpdatePlan()
          Next
          UpdateWeeks()
          RefreshItems()
          dirtyFlag = True
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub PopulateRow(ByVal w As WorkBreakdownStructure, ByVal tr As GridViewDataRowInfo, ByVal SetWorkDone As CountDelegate, ByVal current As Integer, ByVal includeChildren As Boolean)
      If tr Is Nothing Then
        Return
      End If
      If Not SetWorkDone Is Nothing Then
        current += 1
        SetWorkDone(current)
      End If

      tr.Cells("Code").Value = w.Code

      If Not w.CBS Is Nothing AndAlso w.CBS.IdOrNull.HasValue Then
        tr.Cells("CBS").Value = w.CBS.Code
      Else
        tr.Cells("CBS").Value = ""
      End If

      'Dim s As String = Space(w.Level * 3)
      'tr.Cells("Name").Value = s & w.Name
      tr.Cells("Name").Value = w.Name
      tr.Cells("Unit").Value = w.Unit.Name
      tr.Cells("Note").Value = w.Note

      Dim tmat As Decimal = 0 'Me.GetTotalMat
      Dim tlab As Decimal = 0 'Me.GetTotalLab
      Dim teq As Decimal = 0 'Me.GetTotalEq
      Dim t As Decimal = 0 'Me.GetTotal
      Dim tpw As Decimal = 0 'Me.GetTotalPerWBS

      If w.UnitPrice.HasValue Then
        tr.Cells("Unitprice").Value = Configuration.FormatToString(w.UnitPrice.Value, DigitConfig.UnitPrice)
      Else
        tr.Cells("Unitprice").Value = ""
      End If

      If w.Qty.HasValue Then
        tr.Cells("QTY").Value = Configuration.FormatToString(w.Qty.Value, DigitConfig.UnitPrice)
      Else
        tr.Cells("QTY").Value = ""
      End If

      For Each p As KeyValuePair(Of Week, Decimal) In w.Plan
        For Each wk As Week In m_weekList.Keys
          If wk.Equals(p.Key) Then
            tr.Cells(m_weekList(wk).Index).Value = Configuration.FormatToString(p.Value, DigitConfig.UnitPrice)
          End If
        Next
      Next

      tr.Cells("Amount").Value = Configuration.FormatToString(w.Amount, DigitConfig.Price)
      tr.Cells("Budget").Value = Configuration.FormatToString(w.Budget, DigitConfig.Price)
      tr.Cells("Planned").Value = Configuration.FormatToString(w.GetPlannedValue, DigitConfig.Price)

      tr.Tag = w

      If includeChildren Then
        For Each child As WorkBreakdownStructure In w.Childs
          Dim childTR As GridViewDataRowInfo = RadGridView1.Rows.AddNew
          PopulateRow(child, childTR, SetWorkDone, current, includeChildren)
        Next
      End If
    End Sub
    Private m_tableInitialized As Boolean = False
    Private Sub RefreshItems()
      m_tableInitialized = False
      Me.RadGridView1.Rows.Clear()
      For Each w As WorkBreakdownStructure In m_entity.Childs
        Dim row As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
        PopulateRow(w, row, AddressOf WorkDone, 0, True)
      Next
      Dim i As Integer = 1
      For Each row As GridViewDataRowInfo In Me.RadGridView1.Rows
        row.Cells("Linenumber").Value = i
        i += 1
      Next
      m_tableInitialized = True
      'InitProgress()
      'Dim index As Integer = Me.tgItem.CurrentRowIndex
      'Me.m_tableInitialized = False
      'Me.m_entity.PopulateWorkBreakdownStructures(m_treeManager.Treetable, AddressOf WorkDone)
      'Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      'myStatusBarService.ProgressMonitor.Done()
      'Me.m_tableInitialized = True
      'Me.tgItem.CurrentRowIndex = Math.Max(0, index)
      'Me.tgItem.RefreshHeights()
      ''ให้เลือกที่ cell ที่ต้องการ เพราะไปอยู่ col แรกมันจะเผลอ wheel ได้
      'Me.tgItem.CurrentCell = New DataGridCell(Me.tgItem.CurrentRowIndex, 2)
    End Sub
    Public Sub WorkDone(ByVal i As Integer)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.Worked(i)
    End Sub

#Region "Event of Button controls"
    ' Requestor
    Private dummyEmployee As New Employee
    Private Sub ibtnShowEstimator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEstimator.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyEmployee)
    End Sub
    Private Sub ibtnShowEstimatorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEstimatorDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(dummyEmployee, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtEstimatorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtEstimatorCode, txtEstimatorName, Me.m_entity.Estimator)
    End Sub

    Private Sub ibtnShowProjectDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowProjectDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
                   CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(dummyProject, AddressOf SetProjectDialog)
    End Sub
    Private Sub SetProjectDialog(ByVal e As ISimpleEntity)
      If Not Me.m_entity.Project.Id = e.Id Then
        If TypeOf e Is Project Then
          Me.m_entity.Project = CType(e, Project)
          Me.txtProjectCode.Text = e.Code
          Me.txtProjectName.Text = Me.m_entity.Project.Name
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      End If

      'Me.WorkbenchWindow.ViewContent.IsDirty = _
      '    Me.WorkbenchWindow.ViewContent.IsDirty _
      '    Or Project.GetProject(txtProjectCode, txtProjectName, Me.m_entity.Project)
    End Sub
    Private dummyProject As New Project
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowProject.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyProject)
    End Sub
    'Private Sub ibtnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim myEntityPanelService As IEntityPanelService = _
    '                             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenListDialog(New BOQ, AddressOf CopyBoq)
    'End Sub
    'Private Sub CopyBoq(ByVal e As ISimpleEntity)
    '    If e Is Nothing Then
    '        Return
    '    End If
    '    Dim newBoq As BOQ = CType(CType(e, BOQ).GetNewEntity, BOQ)
    '    CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newBoq
    '    Me.Entity = newBoq
    '    Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub
#End Region

#Region "Style"
    Private Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Budget")
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CBS", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Budget", GetType(String)))

      Dim dateCol As New DataColumn("StartDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      dateCol = New DataColumn("FinishDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))

      Return myDatatable
    End Function
    Dim viewDef As ColumnGroupsViewDefinition
    Private Sub GetColumns()

      viewDef = New ColumnGroupsViewDefinition

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim gcLineNumber As New GridViewDecimalColumn("Linenumber")
      gcLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.LineNumberHeaderText}")
      gcLineNumber.Width = 45
      gcLineNumber.ReadOnly = True
      gcLineNumber.DecimalPlaces = 0
      gcLineNumber.TextAlignment = ContentAlignment.MiddleCenter
      Me.RadGridView1.Columns.Add(gcLineNumber)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(0).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(0).Rows(0).Columns.Add(gcLineNumber)
      viewDef.ColumnGroups(0).IsPinned = True

      Dim gcCBS As New GridViewTextBoxColumn("CBS")
      gcCBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
      gcCBS.Width = 60
      Me.RadGridView1.Columns.Add(gcCBS)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(1).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(1).Rows(0).Columns.Add(gcCBS)
      viewDef.ColumnGroups(1).IsPinned = True

      Dim gcCode As New GridViewTextBoxColumn("Code")
      gcCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CodeHeaderText}")
      gcCode.Width = 100
      Me.RadGridView1.Columns.Add(gcCode)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(2).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(2).Rows(0).Columns.Add(gcCode)
      viewDef.ColumnGroups(2).IsPinned = True

      Dim gcName As New GridViewTextBoxColumn("Name")
      gcName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      gcName.Width = 150
      Me.RadGridView1.Columns.Add(gcName)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(3).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(3).Rows(0).Columns.Add(gcName)
      viewDef.ColumnGroups(3).IsPinned = True

      Dim gcUnit As New GridViewTextBoxColumn("Unit")
      gcUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UnitHeaderText}")
      gcUnit.Width = 80
      Me.RadGridView1.Columns.Add(gcUnit)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(4).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(4).Rows(0).Columns.Add(gcUnit)
      viewDef.ColumnGroups(4).IsPinned = True

      'Dim gcUnitButton As New DataGridViewButtonColumn
      'gcUnitButton.Width = 360
      'Me.RadGridView1.Columns.Add(gcUnitButton)

      Dim gcQty As New GridViewTextBoxColumn("QTY")
      gcQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.QtyHeaderText}")
      gcQty.Width = 80
      gcQty.TextAlignment = ContentAlignment.MiddleRight
      Me.RadGridView1.Columns.Add(gcQty)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(5).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(5).Rows(0).Columns.Add(gcQty)
      viewDef.ColumnGroups(5).IsPinned = True

      Dim csUMC As New GridViewTextBoxColumn("UnitPrice")
      csUMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UnitpriceHeaderText}")
      csUMC.Width = 80
      csUMC.TextAlignment = ContentAlignment.MiddleRight
      Me.RadGridView1.Columns.Add(csUMC)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(6).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(6).Rows(0).Columns.Add(csUMC)
      viewDef.ColumnGroups(6).IsPinned = True

      Dim csAmount As New GridViewTextBoxColumn("Amount")
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.AmountHeaderText}")
      csAmount.Width = 80
      csAmount.TextAlignment = ContentAlignment.MiddleRight
      Me.RadGridView1.Columns.Add(csAmount)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(7).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(7).Rows(0).Columns.Add(csAmount)
      viewDef.ColumnGroups(7).IsPinned = True

      Dim csPlanned As New GridViewTextBoxColumn("Planned")
      csPlanned.HeaderText = "Planned" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
      csPlanned.ReadOnly = True
      csPlanned.Width = 80
      csPlanned.TextAlignment = ContentAlignment.MiddleRight
      Me.RadGridView1.Columns.Add(csPlanned)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(8).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(8).Rows(0).Columns.Add(csPlanned)
      viewDef.ColumnGroups(8).IsPinned = True

      Dim csBudget As New GridViewTextBoxColumn("Budget")
      csBudget.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
      csBudget.ReadOnly = True
      csBudget.Width = 80
      csBudget.TextAlignment = ContentAlignment.MiddleRight
      Me.RadGridView1.Columns.Add(csBudget)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(9).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(9).Rows(0).Columns.Add(csBudget)

      Dim csNote As New GridViewTextBoxColumn("Note")
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.NoteHeaderText}")
      csNote.Width = 180
      Me.RadGridView1.Columns.Add(csNote)
      viewDef.ColumnGroups.Add(New GridViewColumnGroup)
      viewDef.ColumnGroups(10).Rows.Add(New GridViewColumnGroupRow())
      viewDef.ColumnGroups(10).Rows(0).Columns.Add(csNote)
    End Sub
    Public Sub ButtonClick(ByVal e As ButtonColumnEventArgs)
      Me.UnitButtonClick(e)
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      'Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
#End Region

    '#Region "Buttons"
    '    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
    '      Dim newWbs As New WorkBreakdownStructure
    '      If m_entity.Childs.Count = 0 Then
    '        newWbs.Name = m_entity.Code
    '        m_entity.Childs.Add(newWbs)
    '        Dim newRow As TreeRow = m_treeManager.Treetable.Childs.Add()
    '        newWbs.PopulateRow(newRow, Nothing, 1, False)
    '      Else
    '        Dim theRow As TreeRow = Me.m_treeManager.SelectedRow
    '        If theRow Is Nothing Then
    '          Return
    '        End If
    '        Dim parentW As WorkBreakdownStructure = CType(m_treeManager.SelectedRow.Tag, WorkBreakdownStructure)
    '        parentW.Childs.Add(newWbs)


    '        Dim newRow As TreeRow = theRow.Childs.Add()
    '        newWbs.PopulateRow(newRow, Nothing, 1, False)

    '        Me.m_treeManager.Treetable.AcceptChanges()
    '        Me.m_treeManager.SelectedRow = newRow
    '        Me.tgItem.RefreshHeights()
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '      End If
    '    End Sub
    '    Private Sub ibtnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnInsert.Click

    '    End Sub
    '    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
    '      Dim currentWBS As WorkBreakdownStructure = CType(m_treeManager.SelectedRow.Tag, WorkBreakdownStructure)
    '      If currentWBS Is Nothing Then
    '        Return
    '      End If
    '      Dim theRow As TreeRow = Me.m_treeManager.SelectedRow
    '      If theRow Is Nothing Then
    '        Return
    '      End If
    '      If Not currentWBS.Parent Is Nothing Then
    '        Dim parWBS As WorkBreakdownStructure = CType(currentWBS.Parent, WorkBreakdownStructure)
    '        If parWBS.Childs.Contains(currentWBS) Then
    '          parWBS.Childs.Remove(currentWBS)
    '        End If
    '        parWBS = Nothing
    '      End If
    '      currentWBS = Nothing
    '      theRow.Parent.Childs.Remove(theRow)
    '      Me.m_treeManager.Treetable.AcceptChanges()
    '      Me.tgItem.RefreshHeights()
    '      Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End Sub
    '#End Region

    Private Sub RadGridView1_RowFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles RadGridView1.RowFormatting
      If e.RowElement IsNot Nothing AndAlso e.RowElement.RowInfo IsNot Nothing AndAlso TypeOf e.RowElement.RowInfo.Tag Is WorkBreakdownStructure Then
        Dim w As WorkBreakdownStructure = CType(e.RowElement.RowInfo.Tag, WorkBreakdownStructure)
        Dim colorList As New List(Of Color)
        colorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(255, Byte))})
        Dim foreColorList As New List(Of Color)        For Each col As Color In colorList          If CInt(col.R) + CInt(col.G) + CInt(col.B) > 128 * 3 Then
            foreColorList.Add(Color.Black)
          Else
            foreColorList.Add(Color.White)
          End If
        Next

        Dim bgColor As Color = colorList((w.Level Mod colorList.Count))
        Dim fColor As Color = foreColorList((w.Level Mod foreColorList.Count))

        e.RowElement.NumberOfColors = 1
        e.RowElement.BackColor = bgColor
        e.RowElement.DrawFill = True
        e.RowElement.ForeColor = fColor
      Else
        e.RowElement.DrawFill = False
        e.RowElement.ResetValue(VisualElement.BackColorProperty)
        e.RowElement.ResetValue(VisualElement.ForeColorProperty)
      End If
    End Sub

    Private Sub RadGridView1_CellValueChanged(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles RadGridView1.CellValueChanged
      If Not Me.m_tableInitialized Then
        Return
      End If
      If Not TypeOf sender Is GridDataCellElement Then
        Return
      End If
      Dim cell As GridDataCellElement = CType(sender, GridDataCellElement)
      m_tableInitialized = False
      Try
        Dim w As WorkBreakdownStructure = CType(cell.RowInfo.Tag, WorkBreakdownStructure)
        PopulateRow(w, cell.RowInfo, Nothing, 0, False)
        Dim i As Integer = e.RowIndex
        Do Until i = 0
          i -= 1
          Dim r As GridViewDataRowInfo = RadGridView1.Rows(i)
          Dim childW As WorkBreakdownStructure = CType(r.Tag, WorkBreakdownStructure)
          PopulateRow(childW, r, Nothing, 0, False)
        Loop

        'Dim parentRow As ITreeParent = CType(e.Row, TreeRow).Parent
        'While TypeOf (parentRow) Is TreeRow
        '  CType(CType(parentRow, TreeRow).Tag, WorkBreakdownStructure).PopulateRow(CType(parentRow, TreeRow), Nothing, 0, False)
        '  parentRow = CType(parentRow, TreeRow).Parent
        'End While
      Catch ex As Exception

      End Try
      m_tableInitialized = True
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private m_updating As Boolean = False
    Private Sub RadGridView1_CellValidating(ByVal sender As Object, ByVal e As CellValidatingEventArgs) Handles RadGridView1.CellValidating
      'Dim column As GridViewDataColumn = TryCast(e.Column, GridViewDataColumn)
      'If TypeOf e.Row Is GridViewDataRowInfo AndAlso column IsNot Nothing AndAlso column.FieldName = "Name" Then
      '  If String.IsNullOrEmpty(DirectCast(e.Value, String)) Then
      '    e.Cancel = True
      '    DirectCast(e.Row, GridViewDataRowInfo).ErrorText = "Validation error!"
      '  Else
      '    DirectCast(e.Row, GridViewDataRowInfo).ErrorText = String.Empty
      '  End If
      'End If
      Dim column As GridViewDataColumn = TryCast(e.Column, GridViewDataColumn)
      If e.Row Is Nothing Then
        Return
      End If
      If Not TypeOf e.Row Is GridViewDataRowInfo OrElse column Is Nothing Then
        Return
      End If
      If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
        Return
      End If
      If Not Me.m_tableInitialized Then
        Return
      End If
      Dim w As WorkBreakdownStructure = CType(e.Row.Tag, WorkBreakdownStructure)
      If m_updating Then
        Return
      End If
      m_updating = True
      If Not e.Value Is Nothing Then
        Select Case column.FieldName.ToLower
          Case "code"
            w.Code = e.Value.ToString
          Case "name"
            w.Name = e.Value.ToString
          Case "unit"
            w.Unit = New Unit(e.Value.ToString)
          Case "qty"
            Dim value As Decimal = CDec(Configuration.FormatToString(CDec(TextParser.Evaluate(e.Value.ToString)), DigitConfig.Qty))
            w.Qty = value
          Case "unitprice"
            Dim value As Decimal = CDec(Configuration.FormatToString(CDec(TextParser.Evaluate(e.Value.ToString)), DigitConfig.UnitPrice))
            w.UnitPrice = value
          Case "amount"
            Dim value As Decimal = CDec(Configuration.FormatToString(CDec(TextParser.Evaluate(e.Value.ToString)), DigitConfig.Price))
            w.Amount = value
          Case "cbs"
            If Not String.IsNullOrEmpty(e.Value.ToString) Then
              Dim c As CBS = CBS.GetByCode(e.Value.ToString)
              If c.IdOrNull.HasValue Then
                w.CBS = c
              Else
                Dim msgServ As MessageService = CType(ServiceManager.Services.GetService(GetType(MessageService)), MessageService)
                msgServ.ShowMessageFormatted("${res:Global.Error.NoCBSCode}", e.Value.ToString)
              End If
            Else
              w.CBS = New CBS
            End If
          Case "note"
            w.Note = e.Value.ToString
          Case Else
            If Not String.IsNullOrEmpty(e.Value.ToString) Then
              Dim value As Decimal = CDec(Configuration.FormatToString(CDec(TextParser.Evaluate(e.Value.ToString)), DigitConfig.Price))
              For Each x As KeyValuePair(Of Week, GridViewTextBoxColumn) In m_weekList
                If x.Value.Equals(e.Column) Then
                  w.Plan(x.Key) = value
                  Exit For
                End If
              Next
            End If
        End Select
      End If
      m_updating = False
    End Sub

    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click

    End Sub

    Private Sub ibtnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnInsert.Click

    End Sub

    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      'Dim cf As New CashFlowView
      'cf.Budget = Me.m_entity
      'cf.Show()
      Dim exp As New Export.ExportToExcelML(RadGridView1)
      exp.ExportVisualSettings = True
      exp.RunExport("C:\mk8-1-2.xls")

    End Sub
  End Class
End Namespace
