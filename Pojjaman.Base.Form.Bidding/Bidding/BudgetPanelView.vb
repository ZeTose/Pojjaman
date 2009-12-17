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
    Friend WithEvents picLockUnlock As System.Windows.Forms.PictureBox
    Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnInsert As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnApproval As System.Windows.Forms.Button
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BudgetPanelView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnApproval = New System.Windows.Forms.Button()
      Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnInsert = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.picLockUnlock = New System.Windows.Forms.PictureBox()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
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
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.btnApproval)
      Me.grbDetail.Controls.Add(Me.ibtnZoomIn)
      Me.grbDetail.Controls.Add(Me.ibtnZoomOut)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.ibtnInsert)
      Me.grbDetail.Controls.Add(Me.picLockUnlock)
      Me.grbDetail.Controls.Add(Me.tgItem)
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
      Me.grbDetail.Text = "Info"
      '
      'btnApproval
      '
      Me.btnApproval.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnApproval.Location = New System.Drawing.Point(201, 101)
      Me.btnApproval.Name = "btnApproval"
      Me.btnApproval.Size = New System.Drawing.Size(104, 23)
      Me.btnApproval.TabIndex = 17
      Me.btnApproval.TabStop = False
      Me.btnApproval.Text = "Approval"
      '
      'ibtnZoomIn
      '
      Me.ibtnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomIn.Location = New System.Drawing.Point(378, 101)
      Me.ibtnZoomIn.Name = "ibtnZoomIn"
      Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomIn.TabIndex = 19
      Me.ibtnZoomIn.TabStop = False
      Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnZoomOut
      '
      Me.ibtnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomOut.Location = New System.Drawing.Point(354, 101)
      Me.ibtnZoomOut.Name = "ibtnZoomOut"
      Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomOut.TabIndex = 18
      Me.ibtnZoomOut.TabStop = False
      Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
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
      'picLockUnlock
      '
      Me.picLockUnlock.Image = CType(resources.GetObject("picLockUnlock.Image"), System.Drawing.Image)
      Me.picLockUnlock.Location = New System.Drawing.Point(311, 100)
      Me.picLockUnlock.Name = "picLockUnlock"
      Me.picLockUnlock.Size = New System.Drawing.Size(24, 24)
      Me.picLockUnlock.TabIndex = 330
      Me.picLockUnlock.TabStop = False
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.DarkGray, System.Drawing.Color.LightGray, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.White})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 127)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(1032, 491)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 20
      Me.tgItem.TreeManager = Nothing
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
      'BudgetPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "BudgetPanelView"
      Me.Size = New System.Drawing.Size(1072, 640)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructors"
    Private m_treeManager As TreeManager
    Private Sub RowExpandCollapseHandler(ByVal e As RowExpandCollapseEventArgs)

      If TypeOf e.Row.Tag Is WorkBreakdownStructure Then
        CType(e.Row.Tag, WorkBreakdownStructure).State = e.Row.State
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = Me.GetSchemaTable()
      m_treeManager = New TreeManager(dt, tgItem)
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt.RowExpandStateChanged, AddressOf RowExpandCollapseHandler

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
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      Me.m_treeManager.Treetable.AcceptChanges()
      If Not Me.m_tableInitialized Then
        Return
      End If
      If Not TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        Return
      End If
      m_tableInitialized = False
      CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure).PopulateRow(CType(e.Row, TreeRow), Nothing, 0, False)
      Dim parentRow As ITreeParent = CType(e.Row, TreeRow).Parent
      While TypeOf (parentRow) Is TreeRow
        CType(CType(parentRow, TreeRow).Tag, WorkBreakdownStructure).PopulateRow(CType(parentRow, TreeRow), Nothing, 0, False)
        parentRow = CType(parentRow, TreeRow).Parent
      End While
      m_tableInitialized = True
      'If ValidateRow(CType(e.Row, TreeRow)) Then
      'UpdateAmount(e)
      'UpdateItem()
      'End If
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Me.tgItem.RefreshHeights()
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.m_tableInitialized Then
        Return
      End If
      If Not TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        Return
      End If
      If e.Column.ColumnName.ToLower = "linenumber" Then
        e.ProposedValue = e.Row(e.Column)
        Return
      End If
      Dim w As WorkBreakdownStructure = CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure)
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "name"
            SetName(e)
          Case "unit"
            SetUnit(e)
          Case "qty"
            SetQty(e)
          Case "unitprice"
            SetUnitprice(e)
          Case "amount"
            SetAmount(e)
          Case "cbs"
            SetCBS(e)
          Case "note"
            SetNote(e)
          Case "startdate"
            If IsDate(e.ProposedValue) Then
              w.PlannedStartDate = CDate(e.ProposedValue)
            Else
              w.PlannedStartDate = Nothing
            End If
          Case "finishdate"
            If IsDate(e.ProposedValue) Then
              w.PlannedFinishDate = CDate(e.ProposedValue)
            Else
              w.PlannedFinishDate = Nothing
            End If
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private m_updating As Boolean = False
    Private Sub SetNote(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      If TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure).Note = e.ProposedValue.ToString
      End If
      m_updating = False
    End Sub
    Private Sub SetName(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      If TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure).Name = e.ProposedValue.ToString
      End If
      m_updating = False
    End Sub
    Private Sub SetUnit(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      If TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure).Unit = New Unit(e.ProposedValue.ToString)
      End If
      m_updating = False
    End Sub
    Private Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      If TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure).Code = e.ProposedValue.ToString
      End If
      m_updating = False
    End Sub
    Private Sub SetCBS(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If Not TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        Return
      End If
      Dim c As CBS = CBS.GetByCode(e.ProposedValue.ToString)
      If c.IdOrNull.HasValue Then
        m_updating = True
        CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure).CBS = c
        m_updating = False
      Else
        Dim msgServ As MessageService = CType(ServiceManager.Services.GetService(GetType(MessageService)), MessageService)
        msgServ.ShowMessageFormatted("${res:Global.Error.NoCBSCode}", e.ProposedValue.ToString)
      End If
    End Sub
    Private Sub SetAmount(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      If TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure).Amount = value
      End If
      m_updating = False
    End Sub
    Private Sub SetQty(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      If TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure).Qty = value
      End If
      m_updating = False
    End Sub
    Private Sub SetUnitprice(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.UnitPrice)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      If TypeOf CType(e.Row, TreeRow).Tag Is WorkBreakdownStructure Then
        CType(CType(e.Row, TreeRow).Tag, WorkBreakdownStructure).UnitPrice = value
      End If
      m_updating = False
    End Sub
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
          Me.tgItem.Visible = False
          UpdateEntityProperties()
          Me.tgItem.Visible = True
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

    End Sub
    Private m_isInitialized As Boolean = False
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
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private m_tableInitialized As Boolean = False
    Private Sub RefreshItems()
      InitProgress()
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_tableInitialized = False
      Me.m_entity.PopulateWorkBreakdownStructures(m_treeManager.Treetable, AddressOf WorkDone)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.Done()
      Me.m_tableInitialized = True
      Me.tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.tgItem.RefreshHeights()
      'ให้เลือกที่ cell ที่ต้องการ เพราะไปอยู่ col แรกมันจะเผลอ wheel ได้
      Me.tgItem.CurrentCell = New DataGridCell(Me.tgItem.CurrentRowIndex, 2)
    End Sub
    Public Sub WorkDone(ByVal i As Integer)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.Worked(i)
    End Sub
    Dim myIndex As Integer
    Private Sub ReIndex()
      If Me.m_treeManager.Treetable.Childs.Count = 0 Then
        Return
      End If
      myIndex = 0
      TreeRow.TraverseRow(Me.m_treeManager.Treetable.Childs(0), AddressOf SetLine)
    End Sub
    Private Sub SetLine(ByVal row As TreeRow)
      myIndex += 1
      row("linenumber") = myIndex
      If TypeOf row.Parent Is TreeRow Then
        CType(row.Parent, TreeRow)("linenumber") = row.Index
      End If
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
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Budget"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "Linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True

      Dim csCBS As New TreeTextColumn
      csCBS.MappingName = "CBS"
      csCBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
      csCBS.NullText = ""
      csCBS.Width = 90

      Dim csCode As New PlusMinusTreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 90


      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 360

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      csUnit.Width = 50

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClick

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "QTY"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.Width = 55


      Dim csUMC As New TreeTextColumn
      csUMC.MappingName = "UnitPrice"
      csUMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UnitpriceHeaderText}")
      csUMC.NullText = ""
      csUMC.DataAlignment = HorizontalAlignment.Right
      csUMC.Format = "#,###.##"
      csUMC.Width = 55

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "Amount"
      csAmount.Width = 55

      Dim csBudget As New TreeTextColumn
      csBudget.MappingName = "Budget"
      csBudget.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
      csBudget.NullText = ""
      csBudget.DataAlignment = HorizontalAlignment.Right
      csBudget.Format = "#,###.##"
      csBudget.TextBox.Name = "Budget"
      csBudget.ReadOnly = True
      csBudget.Width = 55

      Dim csStartDate As New DataGridTimePickerColumn
      csStartDate.MappingName = "StartDate"
      csStartDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.StartDateHeaderText}")
      csStartDate.NullText = ""
      csStartDate.Width = 100

      Dim csEndDate As New DataGridTimePickerColumn
      csEndDate.MappingName = "FinishDate"
      csEndDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.EndDateHeaderText}")
      csEndDate.NullText = ""
      csEndDate.Width = 100


      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "Note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCBS)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)

      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csUMC)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csBudget)

      dst.GridColumnStyles.Add(csStartDate)
      dst.GridColumnStyles.Add(csEndDate)

      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function
    Public Sub ButtonClick(ByVal e As ButtonColumnEventArgs)
      Me.UnitButtonClick(e)
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
#End Region
  End Class
End Namespace
