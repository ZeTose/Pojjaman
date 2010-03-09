Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class LCIListViewPanelView
    Inherits AbstractEntityPanelViewContent
    Implements ISimpleListPanel, IValidatable

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
    Friend WithEvents txtlv5 As System.Windows.Forms.TextBox
    Friend WithEvents txtlv4 As System.Windows.Forms.TextBox
    Friend WithEvents txtlv3 As System.Windows.Forms.TextBox
    Friend WithEvents txtlv2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAltName As System.Windows.Forms.Label
    Friend WithEvents txtAltName As System.Windows.Forms.TextBox
    Friend WithEvents txtlv1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblLevel4_5 As System.Windows.Forms.Label
    Friend WithEvents lblLevel3 As System.Windows.Forms.Label
    Friend WithEvents lblLevel2 As System.Windows.Forms.Label
    Friend WithEvents lblLevel1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grpAmount As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFilterLv5 As System.Windows.Forms.TextBox
    Friend WithEvents txtFilterLv4 As System.Windows.Forms.TextBox
    Friend WithEvents txtFilterLv3 As System.Windows.Forms.TextBox
    Friend WithEvents txtFilterLv2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFilterLv1 As System.Windows.Forms.TextBox
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents txtFilterAltName As System.Windows.Forms.TextBox
    Friend WithEvents txtFilterName As System.Windows.Forms.TextBox
    Friend WithEvents txtMinPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxPrice As System.Windows.Forms.TextBox
    Friend WithEvents lvLevel1 As PJMListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLevel3 As PJMListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lvLevel2 As PJMListView
    Friend WithEvents chkIncludeCancel As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblAltName = New System.Windows.Forms.Label()
      Me.txtAltName = New System.Windows.Forms.TextBox()
      Me.txtlv5 = New System.Windows.Forms.TextBox()
      Me.txtlv4 = New System.Windows.Forms.TextBox()
      Me.txtlv3 = New System.Windows.Forms.TextBox()
      Me.txtlv2 = New System.Windows.Forms.TextBox()
      Me.txtlv1 = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblName = New System.Windows.Forms.Label()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblLevel4_5 = New System.Windows.Forms.Label()
      Me.lblLevel3 = New System.Windows.Forms.Label()
      Me.lblLevel2 = New System.Windows.Forms.Label()
      Me.lblLevel1 = New System.Windows.Forms.Label()
      Me.GroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkIncludeCancel = New System.Windows.Forms.CheckBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtFilterAltName = New System.Windows.Forms.TextBox()
      Me.grpAmount = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtMinPrice = New System.Windows.Forms.TextBox()
      Me.txtMaxPrice = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtFilterLv5 = New System.Windows.Forms.TextBox()
      Me.txtFilterLv4 = New System.Windows.Forms.TextBox()
      Me.txtFilterLv3 = New System.Windows.Forms.TextBox()
      Me.txtFilterLv2 = New System.Windows.Forms.TextBox()
      Me.txtFilterLv1 = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtFilterName = New System.Windows.Forms.TextBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnClearAll = New System.Windows.Forms.Button()
      Me.lvLevel1 = New Longkong.Pojjaman.Gui.Components.PJMListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.lvLevel2 = New Longkong.Pojjaman.Gui.Components.PJMListView()
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.lvLevel3 = New Longkong.Pojjaman.Gui.Components.PJMListView()
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.grbDetail.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.grpAmount.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.lblAltName)
      Me.grbDetail.Controls.Add(Me.txtAltName)
      Me.grbDetail.Controls.Add(Me.txtlv5)
      Me.grbDetail.Controls.Add(Me.txtlv4)
      Me.grbDetail.Controls.Add(Me.txtlv3)
      Me.grbDetail.Controls.Add(Me.txtlv2)
      Me.grbDetail.Controls.Add(Me.txtlv1)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.Enabled = False
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.Location = New System.Drawing.Point(9, 2)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(243, 94)
      Me.grbDetail.TabIndex = 180
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียดวัสดุ"
      '
      'lblAltName
      '
      Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAltName.Location = New System.Drawing.Point(6, 63)
      Me.lblAltName.Name = "lblAltName"
      Me.lblAltName.Size = New System.Drawing.Size(79, 24)
      Me.lblAltName.TabIndex = 124
      Me.lblAltName.Text = "Other Name:"
      Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAltName
      '
      Me.txtAltName.BackColor = System.Drawing.SystemColors.Window
      Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtAltName.Location = New System.Drawing.Point(86, 64)
      Me.txtAltName.MaxLength = 200
      Me.txtAltName.Name = "txtAltName"
      Me.txtAltName.ReadOnly = True
      Me.txtAltName.Size = New System.Drawing.Size(152, 22)
      Me.txtAltName.TabIndex = 7
      '
      'txtlv5
      '
      Me.txtlv5.BackColor = System.Drawing.SystemColors.Window
      Me.txtlv5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv5.Location = New System.Drawing.Point(182, 16)
      Me.txtlv5.MaxLength = 7
      Me.txtlv5.Name = "txtlv5"
      Me.txtlv5.ReadOnly = True
      Me.txtlv5.Size = New System.Drawing.Size(56, 23)
      Me.txtlv5.TabIndex = 4
      '
      'txtlv4
      '
      Me.txtlv4.BackColor = System.Drawing.SystemColors.Window
      Me.txtlv4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv4.Location = New System.Drawing.Point(158, 16)
      Me.txtlv4.MaxLength = 2
      Me.txtlv4.Name = "txtlv4"
      Me.txtlv4.ReadOnly = True
      Me.txtlv4.Size = New System.Drawing.Size(24, 23)
      Me.txtlv4.TabIndex = 3
      '
      'txtlv3
      '
      Me.txtlv3.BackColor = System.Drawing.SystemColors.Info
      Me.txtlv3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv3.Location = New System.Drawing.Point(134, 16)
      Me.txtlv3.MaxLength = 2
      Me.txtlv3.Name = "txtlv3"
      Me.txtlv3.ReadOnly = True
      Me.txtlv3.Size = New System.Drawing.Size(24, 23)
      Me.txtlv3.TabIndex = 2
      '
      'txtlv2
      '
      Me.txtlv2.BackColor = System.Drawing.SystemColors.Info
      Me.txtlv2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv2.Location = New System.Drawing.Point(110, 16)
      Me.txtlv2.MaxLength = 2
      Me.txtlv2.Name = "txtlv2"
      Me.txtlv2.ReadOnly = True
      Me.txtlv2.Size = New System.Drawing.Size(24, 23)
      Me.txtlv2.TabIndex = 1
      '
      'txtlv1
      '
      Me.txtlv1.BackColor = System.Drawing.SystemColors.Info
      Me.txtlv1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtlv1.Location = New System.Drawing.Point(86, 16)
      Me.txtlv1.MaxLength = 2
      Me.txtlv1.Name = "txtlv1"
      Me.txtlv1.ReadOnly = True
      Me.txtlv1.Size = New System.Drawing.Size(24, 23)
      Me.txtlv1.TabIndex = 0
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(6, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(79, 20)
      Me.lblCode.TabIndex = 123
      Me.lblCode.Text = "LCI Code:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.Location = New System.Drawing.Point(6, 40)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(79, 20)
      Me.lblName.TabIndex = 122
      Me.lblName.Text = "Name:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.txtName.BackColor = System.Drawing.SystemColors.Window
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtName.Location = New System.Drawing.Point(86, 40)
      Me.txtName.MaxLength = 200
      Me.txtName.Name = "txtName"
      Me.txtName.ReadOnly = True
      Me.txtName.Size = New System.Drawing.Size(152, 22)
      Me.txtName.TabIndex = 6
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText
      Me.tgItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 267)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 270)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 190
      Me.tgItem.TreeManager = Nothing
      '
      'lblLevel4_5
      '
      Me.lblLevel4_5.AutoSize = True
      Me.lblLevel4_5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLevel4_5.Location = New System.Drawing.Point(8, 253)
      Me.lblLevel4_5.Name = "lblLevel4_5"
      Me.lblLevel4_5.Size = New System.Drawing.Size(70, 14)
      Me.lblLevel4_5.TabIndex = 189
      Me.lblLevel4_5.Text = "Material List"
      Me.lblLevel4_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLevel3
      '
      Me.lblLevel3.AutoSize = True
      Me.lblLevel3.Font = New System.Drawing.Font("Tahoma", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
      Me.lblLevel3.Location = New System.Drawing.Point(505, 94)
      Me.lblLevel3.Name = "lblLevel3"
      Me.lblLevel3.Size = New System.Drawing.Size(50, 16)
      Me.lblLevel3.TabIndex = 188
      Me.lblLevel3.Text = "Level3"
      Me.lblLevel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLevel2
      '
      Me.lblLevel2.AutoSize = True
      Me.lblLevel2.Font = New System.Drawing.Font("Tahoma", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
      Me.lblLevel2.Location = New System.Drawing.Point(256, 94)
      Me.lblLevel2.Name = "lblLevel2"
      Me.lblLevel2.Size = New System.Drawing.Size(50, 16)
      Me.lblLevel2.TabIndex = 187
      Me.lblLevel2.Text = "Level2"
      Me.lblLevel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLevel1
      '
      Me.lblLevel1.AutoSize = True
      Me.lblLevel1.Font = New System.Drawing.Font("Tahoma", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblLevel1.Location = New System.Drawing.Point(12, 94)
      Me.lblLevel1.Name = "lblLevel1"
      Me.lblLevel1.Size = New System.Drawing.Size(50, 16)
      Me.lblLevel1.TabIndex = 186
      Me.lblLevel1.Text = "Level1"
      Me.lblLevel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.chkIncludeCancel)
      Me.GroupBox1.Controls.Add(Me.txtFilterAltName)
      Me.GroupBox1.Controls.Add(Me.grpAmount)
      Me.GroupBox1.Controls.Add(Me.txtFilterLv5)
      Me.GroupBox1.Controls.Add(Me.txtFilterLv4)
      Me.GroupBox1.Controls.Add(Me.txtFilterLv3)
      Me.GroupBox1.Controls.Add(Me.txtFilterLv2)
      Me.GroupBox1.Controls.Add(Me.txtFilterLv1)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.txtFilterName)
      Me.GroupBox1.Controls.Add(Me.btnSearch)
      Me.GroupBox1.Controls.Add(Me.btnClearAll)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.GroupBox1.Location = New System.Drawing.Point(255, 2)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(513, 94)
      Me.GroupBox1.TabIndex = 180
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "ค้นหาวัสดุ/หมวดวัสดุ"
      '
      'chkIncludeCancel
      '
      Me.chkIncludeCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeCancel.Location = New System.Drawing.Point(434, 10)
      Me.chkIncludeCancel.Name = "chkIncludeCancel"
      Me.chkIncludeCancel.Size = New System.Drawing.Size(72, 24)
      Me.chkIncludeCancel.TabIndex = 190
      Me.chkIncludeCancel.TabStop = False
      Me.chkIncludeCancel.Text = "รวมยกเลิก"
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.Location = New System.Drawing.Point(4, 63)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(79, 24)
      Me.Label2.TabIndex = 124
      Me.Label2.Text = "Other Name:"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFilterAltName
      '
      Me.txtFilterAltName.BackColor = System.Drawing.SystemColors.Window
      Me.txtFilterAltName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtFilterAltName.Location = New System.Drawing.Point(81, 64)
      Me.txtFilterAltName.MaxLength = 200
      Me.txtFilterAltName.Name = "txtFilterAltName"
      Me.txtFilterAltName.Size = New System.Drawing.Size(152, 22)
      Me.txtFilterAltName.TabIndex = 6
      '
      'grpAmount
      '
      Me.grpAmount.Controls.Add(Me.Label5)
      Me.grpAmount.Controls.Add(Me.Label6)
      Me.grpAmount.Controls.Add(Me.txtMinPrice)
      Me.grpAmount.Controls.Add(Me.txtMaxPrice)
      Me.grpAmount.Controls.Add(Me.Label7)
      Me.grpAmount.Controls.Add(Me.Label8)
      Me.grpAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grpAmount.Location = New System.Drawing.Point(235, 8)
      Me.grpAmount.Name = "grpAmount"
      Me.grpAmount.Size = New System.Drawing.Size(195, 78)
      Me.grpAmount.TabIndex = 189
      Me.grpAmount.TabStop = False
      Me.grpAmount.Text = "ราคา"
      '
      'Label5
      '
      Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(6, 18)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(48, 18)
      Me.Label5.TabIndex = 11
      Me.Label5.Text = "From"
      Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label6
      '
      Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(6, 42)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(48, 18)
      Me.Label6.TabIndex = 11
      Me.Label6.Text = "To"
      Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtMinPrice
      '
      Me.txtMinPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtMinPrice.Location = New System.Drawing.Point(56, 16)
      Me.txtMinPrice.Name = "txtMinPrice"
      Me.txtMinPrice.Size = New System.Drawing.Size(80, 22)
      Me.txtMinPrice.TabIndex = 187
      '
      'txtMaxPrice
      '
      Me.txtMaxPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtMaxPrice.Location = New System.Drawing.Point(56, 40)
      Me.txtMaxPrice.Name = "txtMaxPrice"
      Me.txtMaxPrice.Size = New System.Drawing.Size(80, 22)
      Me.txtMaxPrice.TabIndex = 187
      '
      'Label7
      '
      Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(136, 18)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(56, 18)
      Me.Label7.TabIndex = 11
      Me.Label7.Text = "บาท/หน่วย"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label8
      '
      Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(136, 42)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(56, 18)
      Me.Label8.TabIndex = 11
      Me.Label8.Text = "บาท/หน่วย"
      Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFilterLv5
      '
      Me.txtFilterLv5.BackColor = System.Drawing.SystemColors.Window
      Me.txtFilterLv5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtFilterLv5.Location = New System.Drawing.Point(177, 16)
      Me.txtFilterLv5.MaxLength = 7
      Me.txtFilterLv5.Name = "txtFilterLv5"
      Me.txtFilterLv5.Size = New System.Drawing.Size(56, 23)
      Me.txtFilterLv5.TabIndex = 4
      '
      'txtFilterLv4
      '
      Me.txtFilterLv4.BackColor = System.Drawing.SystemColors.Window
      Me.txtFilterLv4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtFilterLv4.Location = New System.Drawing.Point(153, 16)
      Me.txtFilterLv4.MaxLength = 2
      Me.txtFilterLv4.Name = "txtFilterLv4"
      Me.txtFilterLv4.Size = New System.Drawing.Size(24, 23)
      Me.txtFilterLv4.TabIndex = 3
      '
      'txtFilterLv3
      '
      Me.txtFilterLv3.BackColor = System.Drawing.SystemColors.Info
      Me.txtFilterLv3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtFilterLv3.Location = New System.Drawing.Point(129, 16)
      Me.txtFilterLv3.MaxLength = 2
      Me.txtFilterLv3.Name = "txtFilterLv3"
      Me.txtFilterLv3.Size = New System.Drawing.Size(24, 23)
      Me.txtFilterLv3.TabIndex = 2
      '
      'txtFilterLv2
      '
      Me.txtFilterLv2.BackColor = System.Drawing.SystemColors.Info
      Me.txtFilterLv2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtFilterLv2.Location = New System.Drawing.Point(105, 16)
      Me.txtFilterLv2.MaxLength = 2
      Me.txtFilterLv2.Name = "txtFilterLv2"
      Me.txtFilterLv2.Size = New System.Drawing.Size(24, 23)
      Me.txtFilterLv2.TabIndex = 1
      '
      'txtFilterLv1
      '
      Me.txtFilterLv1.BackColor = System.Drawing.SystemColors.Info
      Me.txtFilterLv1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtFilterLv1.Location = New System.Drawing.Point(81, 16)
      Me.txtFilterLv1.MaxLength = 2
      Me.txtFilterLv1.Name = "txtFilterLv1"
      Me.txtFilterLv1.Size = New System.Drawing.Size(24, 23)
      Me.txtFilterLv1.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label3.Location = New System.Drawing.Point(4, 16)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(79, 20)
      Me.Label3.TabIndex = 123
      Me.Label3.Text = "LCI Code:"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label4
      '
      Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label4.Location = New System.Drawing.Point(4, 40)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(79, 20)
      Me.Label4.TabIndex = 122
      Me.Label4.Text = "Name:"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFilterName
      '
      Me.txtFilterName.BackColor = System.Drawing.SystemColors.Window
      Me.txtFilterName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtFilterName.Location = New System.Drawing.Point(81, 40)
      Me.txtFilterName.MaxLength = 200
      Me.txtFilterName.Name = "txtFilterName"
      Me.txtFilterName.Size = New System.Drawing.Size(152, 22)
      Me.txtFilterName.TabIndex = 5
      '
      'btnSearch
      '
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSearch.Location = New System.Drawing.Point(432, 34)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(64, 24)
      Me.btnSearch.TabIndex = 184
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnClearAll
      '
      Me.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnClearAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnClearAll.Location = New System.Drawing.Point(432, 62)
      Me.btnClearAll.Name = "btnClearAll"
      Me.btnClearAll.Size = New System.Drawing.Size(64, 24)
      Me.btnClearAll.TabIndex = 184
      Me.btnClearAll.Text = "Clear All"
      '
      'lvLevel1
      '
      Me.lvLevel1.AllowSort = True
      Me.lvLevel1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
      Me.lvLevel1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lvLevel1.HideSelection = False
      Me.lvLevel1.Location = New System.Drawing.Point(8, 109)
      Me.lvLevel1.Name = "lvLevel1"
      Me.lvLevel1.Size = New System.Drawing.Size(249, 144)
      Me.lvLevel1.SortIndex = -1
      Me.lvLevel1.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lvLevel1.TabIndex = 192
      Me.lvLevel1.UseCompatibleStateImageBehavior = False
      Me.lvLevel1.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Items"
      Me.ColumnHeader1.Width = 223
      '
      'lvLevel2
      '
      Me.lvLevel2.AllowSort = True
      Me.lvLevel2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
      Me.lvLevel2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lvLevel2.HideSelection = False
      Me.lvLevel2.Location = New System.Drawing.Point(257, 109)
      Me.lvLevel2.Name = "lvLevel2"
      Me.lvLevel2.Size = New System.Drawing.Size(249, 144)
      Me.lvLevel2.SortIndex = -1
      Me.lvLevel2.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lvLevel2.TabIndex = 192
      Me.lvLevel2.UseCompatibleStateImageBehavior = False
      Me.lvLevel2.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Items"
      Me.ColumnHeader2.Width = 222
      '
      'lvLevel3
      '
      Me.lvLevel3.AllowSort = True
      Me.lvLevel3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
      Me.lvLevel3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lvLevel3.HideSelection = False
      Me.lvLevel3.Location = New System.Drawing.Point(506, 109)
      Me.lvLevel3.Name = "lvLevel3"
      Me.lvLevel3.Size = New System.Drawing.Size(260, 144)
      Me.lvLevel3.SortIndex = -1
      Me.lvLevel3.SortOrder = System.Windows.Forms.SortOrder.None
      Me.lvLevel3.TabIndex = 192
      Me.lvLevel3.UseCompatibleStateImageBehavior = False
      Me.lvLevel3.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Items"
      Me.ColumnHeader3.Width = 222
      '
      'LCIListViewPanelView
      '
      Me.Controls.Add(Me.lvLevel1)
      Me.Controls.Add(Me.lvLevel2)
      Me.Controls.Add(Me.lvLevel3)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblLevel4_5)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.lblLevel3)
      Me.Controls.Add(Me.lblLevel2)
      Me.Controls.Add(Me.lblLevel1)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "LCIListViewPanelView"
      Me.Size = New System.Drawing.Size(776, 544)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.grpAmount.ResumeLayout(False)
      Me.grpAmount.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As LCIItem
    Private m_selectedEntity As ISimpleEntity

    Private m_treeManager As TreeManager

    Private m_filters As Filter()

    Private m_basketItems As BasketItemCollection
    Private m_proposedBasketItems As BasketItemCollection
    Private m_oldBasket As BasketItemCollection

    Private m_mode As Selection = Selection.None
    Private m_isInitialized As Boolean = False
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        If Me.Entity Is Nothing OrElse Not Me.Entity.Originated Then
          Return "รายละเอียด"
        End If
        Return "รายละเอียด:" & Me.Entity.Code
      End Get
    End Property
#End Region

#Region "Constructors"
    Public Sub SelectNewEntity()
      Me.m_selectedEntity = CType(SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName), LCIItem)
    End Sub
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      InitializeComponent()

      m_mode = Selection.MultiSelect
      If TypeOf handler Is NamedEntityOperationDelegate Then
        m_mode = Selection.SingleSelect
      End If

      If TypeOf entity Is LCIItem Then
        m_entity = CType(entity, LCIItem)
      End If

      Me.SetLabelText()
      Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      Me.PanelName = Me.Name
      Dim dt As TreeTable = GetDataTable()
      Dim dst As DataGridTableStyle = CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      tgItem.AllowNew = False

      AddHandler dt.RowChanging, AddressOf ItemTreetable_RowChanging

      m_filters = filters

      m_basketItems = New BasketItemCollection
      m_proposedBasketItems = New BasketItemCollection
      m_oldBasket = New BasketItemCollection

      If m_mode = Selection.None Or m_mode = Selection.SingleSelect Then
        'Me.lvLevel1.CheckBoxes = False
        'Me.lvLevel2.CheckBoxes = False
        'Me.lvLevel3.CheckBoxes = False
      Else
        Me.dlg = basket
        'Me.lvLevel1.CheckBoxes = True
        'Me.lvLevel2.CheckBoxes = True
        'Me.lvLevel3.CheckBoxes = True
      End If
    End Sub
    Public Enum Selection
      None
      MultiSelect
      SingleSelect
    End Enum
#End Region

#Region "Overrides"
    Public Event EntitySelected(ByVal e As ISimpleEntity) Implements ISimpleListPanel.EntitySelected
    Public Sub OnEntitySelected(ByVal e As ISimpleEntity)
      RaiseEvent EntitySelected(e)
    End Sub
    Public Sub CheckFormEnable() Implements ISimpleEntityPanel.CheckFormEnable

    End Sub

    Public Sub ClearDetail() Implements ISimpleEntityPanel.ClearDetail

    End Sub

    Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, LCIItem)
      End Set
    End Property

    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

    Public Sub Initialize() Implements ISimpleEntityPanel.Initialize

    End Sub

    Public Sub SetLabelText() Implements ISimpleEntityPanel.SetLabelText

    End Sub

    Public Sub UpdateEntityProperties() Implements ISimpleEntityPanel.UpdateEntityProperties

    End Sub

    Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
      Get
        Return Me.m_entity.ListPanelIcon
      End Get
    End Property

    Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

    End Sub

    Public ReadOnly Property Title() As String Implements ISimplePanel.Title
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get

      End Get
    End Property
    Public Adding As Boolean
    Public Sub AddNew() Implements ISimpleListPanel.AddNew
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        Dim selectedLci As LCIItem = CType(Me.SelectedEntity, LCIItem)
        Dim newLci As LCIItem
        If selectedLci Is Nothing Then
          newLci = New LCIItem
          newLci.Level = 1
          newLci.Lv1 = ""
          newLci.Lv2 = "00"
          newLci.Lv3 = "00"
        ElseIf selectedLci.Level <= 4 Then
          newLci = New LCIItem(selectedLci)
        Else
          Dim theId As Integer = selectedLci.Parent.Id
          Dim theParent As New LCIItem(theId)
          newLci = New LCIItem(theParent)
        End If
        Me.m_selectedEntity = newLci
        AddHandler Me.m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        Adding = True
        If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
          Me.WorkbenchWindow.SwitchView(1)
        Else
          CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity = Me.m_selectedEntity
        End If
        Adding = False
      End If
    End Sub

    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData
      'If Not m_isInitialized = False Then
      'Return
      'End If
      Dim selectedLci As LCIItem = CType(Me.SelectedEntity, LCIItem)
      If Not selectedLci Is Nothing Then
        Select Case selectedLci.Level
          Case 1
            Me.btnSearch.PerformClick()
          Case 2
            Me.lvLevel1_SelectedIndexChanged(Me.lvLevel1, Nothing)
            Me.lvLevel1.Focus()
          Case 3
            Me.lvLevel2_SelectedIndexChanged(Me.lvLevel2, Nothing)
            Me.lvLevel2.Focus()
          Case 4, 5
            Me.lvLevel3_SelectedIndexChanged(Me.lvLevel3, Nothing)
            For Each row As TreeRow In m_treeManager.Treetable.Rows
              If selectedLci.Id = CType(row.Tag, LCIItem).Id Then
                tgItem.CurrentRowIndex = Math.Max(0, row.Index)
                Exit For
              End If
            Next
            Me.tgItem.Focus()
        End Select
      Else
        'Deleted?
        Select Case m_theLevel
          Case 1
            Me.btnSearch.PerformClick()
          Case 2
            Me.lvLevel1_SelectedIndexChanged(Me.lvLevel1, Nothing)
            Me.lvLevel1.Focus()
          Case 3
            Me.lvLevel2_SelectedIndexChanged(Me.lvLevel2, Nothing)
            Me.lvLevel2.Focus()
          Case 4, 5
            Me.lvLevel3_SelectedIndexChanged(Me.lvLevel3, Nothing)
            Me.tgItem.Focus()
        End Select
      End If
    End Sub

    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
        'Hack: pui
        Dim newLci As LCIItem
        If Not m_selectedEntity Is Nothing Then
          newLci = New LCIItem(m_selectedEntity.Id)
          m_selectedEntity = newLci
        End If

        Return m_selectedEntity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        If Object.ReferenceEquals(m_selectedEntity, Value) Then
          Return
        End If
        Me.m_selectedEntity = Value
        If Not m_selectedEntity Is Nothing Then
          m_theLevel = CType(m_selectedEntity, LCIItem).Level
          Me.RefreshData(m_selectedEntity.Id.ToString)
        End If
      End Set
    End Property
#End Region

#Region "Event Handlers"
    Private m_minSelectionLevel As Integer = 3
    Private m_theLevel As Integer = 0
    Private Sub SelectItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLevel1.DoubleClick, lvLevel2.DoubleClick, lvLevel3.DoubleClick, tgItem.DoubleClick
      If Not Me.WorkbenchWindow Is Nothing Then
        If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
          Me.WorkbenchWindow.SwitchView(1)
        End If
        Return
      End If
      If Me.SelectedEntity Is Nothing OrElse CType(Me.SelectedEntity, LCIItem).Level < m_minSelectionLevel Then
        Return
      End If
      Me.OnEntitySelected(Me.SelectedEntity)
      If Not Me.m_mode = Selection.MultiSelect AndAlso Not Me.FindForm Is Nothing Then
        Me.FindForm.Close()
      End If
    End Sub
    Private Sub FreezeSearchBox(ByVal freeze As Boolean)
      If freeze Then
        Me.txtFilterLv1.BackColor = System.Drawing.Color.Aqua
        Me.txtFilterLv2.BackColor = System.Drawing.Color.Aqua
        Me.txtFilterLv3.BackColor = System.Drawing.Color.Aqua
        Me.txtFilterLv4.BackColor = System.Drawing.Color.Aqua
        Me.txtFilterLv5.BackColor = System.Drawing.Color.Aqua
        Me.txtFilterAltName.BackColor = System.Drawing.Color.Aqua
        Me.txtFilterName.BackColor = System.Drawing.Color.Aqua
      Else
        Me.txtFilterLv1.BackColor = System.Drawing.SystemColors.Info
        Me.txtFilterLv2.BackColor = System.Drawing.SystemColors.Info
        Me.txtFilterLv3.BackColor = System.Drawing.SystemColors.Info
        Me.txtFilterLv4.BackColor = System.Drawing.SystemColors.Window
        Me.txtFilterLv5.BackColor = System.Drawing.SystemColors.Window
        Me.txtFilterAltName.BackColor = System.Drawing.SystemColors.Window
        Me.txtFilterName.BackColor = System.Drawing.SystemColors.Window
      End If
      Me.Invalidate()
    End Sub
    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtFilterLv1.TextChanged, txtFilterLv2.TextChanged _
    , txtFilterLv3.TextChanged, txtFilterLv4.TextChanged, txtFilterLv5.TextChanged _
    , txtFilterAltName.TextChanged, txtFilterName.TextChanged
      Dim txt As TextBox = CType(sender, TextBox)
      If txt.TextLength = txt.MaxLength Then
        txt.Parent.SelectNextControl(Me.ActiveControl, True, True, False, False)
      End If
      FreezeSearchBox(False)
    End Sub
    Private Sub tgItem_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
      'If Not m_isInitialized = False Then
      'Return
      'End If
      Dim t As Date = Now
      FreezeSearchBox(True)
      ClearSelectedValue()
      'Dim m_filterstring As String = Me.GetFilterString
      m_filters = Me.GetFilterArray
      Dim coll As TreeBaseEntityCollection = Me.m_entity.GetLCICollection(1, -1, True, m_filters)
      Me.lvLevel1.Items.Clear()
      Me.lvLevel2.Items.Clear()
      Me.lvLevel3.Items.Clear()
      'Me.m_treeManager.Treetable.Rows.Clear()
      Me.Cursor = Cursors.WaitCursor
      Me.lvLevel1.BeginUpdate()
      Me.StatusBarService.ProgressMonitor.BeginTask(Me.StringParserService.Parse("${res:Global.LCI.Level1Loading}"), coll.Count)
      Dim i As Integer = 0
      For Each lci As LCIItem In coll
        i += 1
        Me.lvLevel1.Items.Add(lci.ToString).Tag = lci
        Me.StatusBarService.ProgressMonitor.Worked(i)
      Next
      Me.StatusBarService.ProgressMonitor.Done()
      Me.lvLevel1.EndUpdate()
      Me.Cursor = Cursors.Default
      If Me.lvLevel1.Items.Count > 0 Then
        Try
          Me.lvLevel1.Items(0).Selected = True
        Catch ex As Exception
          'หาสาเหตุมะเจอเลย hack ไว้แบบนี้ก่อนละกัน
        End Try
      End If
    End Sub
    Private Sub Control_Focus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLevel1.GotFocus, lvLevel2.GotFocus _
    , lvLevel3.GotFocus, tgItem.GotFocus, tgItem.CurrentCellChanged, txtAltName.GotFocus, txtFilterAltName.GotFocus, txtFilterLv1.GotFocus, _
    txtFilterLv2.GotFocus, txtFilterLv3.GotFocus, txtFilterLv4.GotFocus, _
    txtFilterLv5.GotFocus, txtFilterName.GotFocus, txtlv1.GotFocus, _
    txtlv2.GotFocus, txtlv3.GotFocus, txtlv4.GotFocus, _
    txtlv5.GotFocus, txtMaxPrice.GotFocus, txtMinPrice.GotFocus, _
    txtName.GotFocus, btnClearAll.GotFocus, btnSearch.GotFocus
      'If Not m_isInitialized = False Then
      'Return
      'End If
      Try

        Select Case CType(sender, Control).Name.ToLower
          Case "lvlevel1"
            If Not Me.ActiveControl Is Nothing AndAlso Me.ActiveControl Is Me.lvLevel1 AndAlso lvLevel1.SelectedItems.Count > 0 Then
              SetSelectedValue(CType(lvLevel1.SelectedItems(0).Tag, LCIItem))
            End If
          Case "lvlevel2"
            If Not Me.ActiveControl Is Nothing AndAlso Me.ActiveControl Is Me.lvLevel2 AndAlso lvLevel2.SelectedItems.Count > 0 Then
              SetSelectedValue(CType(lvLevel2.SelectedItems(0).Tag, LCIItem))
            End If
          Case "lvlevel3"
            If Not Me.ActiveControl Is Nothing AndAlso Me.ActiveControl Is Me.lvLevel3 AndAlso lvLevel3.SelectedItems.Count > 0 Then
              SetSelectedValue(CType(lvLevel3.SelectedItems(0).Tag, LCIItem))
            End If
          Case "tgitem"
            If Not Me.m_gridsetting Then
              If Not Me.m_treeManager.SelectedRow Is Nothing Then
                If TypeOf Me.m_treeManager.Treetable.Rows(tgItem.CurrentCell.RowNumber) Is TreeRow Then
                  Dim tr As TreeRow = CType(Me.m_treeManager.Treetable.Rows(tgItem.CurrentCell.RowNumber), TreeRow)
                  If TypeOf tr.Tag Is LCIItem Then
                    Dim item As LCIItem = CType(tr.Tag, LCIItem)
                    If item.Level = 4 Then
                      item.Parent = CType(lvLevel3.SelectedItems(0).Tag, LCIItem)
                    ElseIf item.Level = 5 Then
                      Dim parentItem As LCIItem = CType(CType(CType(Me.m_treeManager.Treetable.Rows(tgItem.CurrentCell.RowNumber), TreeRow).Parent, TreeRow).Tag, LCIItem)
                      item.Parent = parentItem
                    End If
                    If Not Me.ActiveControl Is Nothing AndAlso Me.ActiveControl Is Me.tgItem Then
                      SetSelectedValue(item)
                    End If
                  End If
                End If
              End If
            End If
          Case Me.txtAltName.Name.ToLower, Me.txtFilterAltName.Name.ToLower, Me.txtFilterLv1.Name.ToLower, _
          Me.txtFilterLv2.Name.ToLower, Me.txtFilterLv3.Name.ToLower, Me.txtFilterLv4.Name.ToLower, _
          Me.txtFilterLv5.Name.ToLower, Me.txtFilterName.Name.ToLower, Me.txtlv1.Name.ToLower, _
          Me.txtlv2.Name.ToLower, Me.txtlv3.Name.ToLower, Me.txtlv4.Name.ToLower, _
          Me.txtlv5.Name.ToLower, Me.txtMaxPrice.Name.ToLower, Me.txtMinPrice.Name.ToLower, _
          Me.txtName.Name.ToLower, Me.btnClearAll.Name.ToLower, Me.btnSearch.Name.ToLower
            If Me.ActiveControl Is Nothing Then
              ClearSelectedValue()
            ElseIf Not Me.ActiveControl Is lvLevel1 And _
            Not Me.ActiveControl Is lvLevel2 And _
            Not Me.ActiveControl Is lvLevel3 And _
            Not Me.ActiveControl Is tgItem Then
              ClearSelectedValue()
            End If
        End Select
      Catch ex As Exception
        'หาสาเหตุมะเจอเลย hack ไว้แบบนี้ก่อนละกัน
      End Try
    End Sub
    Private Sub lvLevel1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLevel1.SelectedIndexChanged
      If lvLevel1.SelectedItems.Count = 0 Then
        ClearSelectedValue()
        Return
      End If
      Application.DoEvents()
      Dim t As Date = Now
      Dim coll As TreeBaseEntityCollection = Me.m_entity.GetLCICollection(2, CType(lvLevel1.SelectedItems(0).Tag, LCIItem).Id, False, m_filters)
      Me.lvLevel2.Items.Clear()
      Me.lvLevel3.Items.Clear()
      'Me.m_treeManager.Treetable.Rows.Clear()
      Me.Cursor = Cursors.WaitCursor
      Me.lvLevel2.BeginUpdate()
      Me.StatusBarService.ProgressMonitor.BeginTask(Me.StringParserService.Parse("${res:Global.LCI.Level2Loading}"), coll.Count)
      Dim i As Integer = 0
      For Each lci As LCIItem In coll
        i += 1
        Me.lvLevel2.Items.Add(lci.ToString).Tag = lci
        Me.StatusBarService.ProgressMonitor.Worked(i)
      Next
      Me.StatusBarService.ProgressMonitor.Done()
      Me.lvLevel2.EndUpdate()
      Me.Cursor = Cursors.Default
      Control_Focus(lvLevel1, Nothing)
      If Me.lvLevel2.Items.Count > 0 Then
        Try
          Me.lvLevel2.Items(0).Selected = True
        Catch ex As Exception
          'หาสาเหตุมะเจอเลย hack ไว้แบบนี้ก่อนละกัน
        End Try
      End If
    End Sub
    Private Sub lvLevel2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLevel2.SelectedIndexChanged
      If lvLevel2.SelectedItems.Count = 0 Then
        ClearSelectedValue()
        Return
      End If
      Application.DoEvents()
      Dim t As Date = Now
      Dim coll As TreeBaseEntityCollection = Me.m_entity.GetLCICollection(3, CType(lvLevel2.SelectedItems(0).Tag, LCIItem).Id, False, m_filters)
      Me.lvLevel3.Items.Clear()
      'Me.m_treeManager.Treetable.Rows.Clear()
      Me.Cursor = Cursors.WaitCursor
      Me.lvLevel3.BeginUpdate()
      Me.StatusBarService.ProgressMonitor.BeginTask(Me.StringParserService.Parse("${res:Global.LCI.Level3Loading}"), coll.Count)
      Dim i As Integer = 0
      For Each lci As LCIItem In coll
        i += 1
        Me.lvLevel3.Items.Add(lci.ToString).Tag = lci
        Me.StatusBarService.ProgressMonitor.Worked(i)
      Next
      Me.StatusBarService.ProgressMonitor.Done()
      Me.lvLevel3.EndUpdate()
      Me.Cursor = Cursors.Default
      Control_Focus(lvLevel2, Nothing)
      If Me.lvLevel3.Items.Count > 0 Then
        Try
          Me.lvLevel3.Items(0).Selected = True
        Catch ex As Exception
          'หาสาเหตุมะเจอเลย hack ไว้แบบนี้ก่อนละกัน
        End Try
      End If
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.Populate(m_treeManager.Treetable)
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.m_isInitialized = True
    End Sub
    Private Sub ItemTreetable_RowChanging(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
      'If Not m_isInitialized Then
      'Return
      'End If
      If Me.m_treeManager Is Nothing Then
        Return
      End If
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim rowCount As Integer = Me.m_treeManager.Treetable.Rows.Count
      If rowCount <= Me.m_entity.CountCurrentLv4Lv5 Then
        Me.StatusBarService.ProgressMonitor.Worked(rowCount)
      End If
    End Sub
    Private m_gridsetting As Boolean = False
    Private Sub lvLevel3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLevel3.SelectedIndexChanged
      If lvLevel3.SelectedItems.Count = 0 Then
        ClearSelectedValue()
        Return
      End If

      Application.DoEvents()
      Me.Cursor = Cursors.WaitCursor
      Me.m_gridsetting = True
      Me.m_entity.CurrentParentLciitem = CType(lvLevel3.SelectedItems(0).Tag, LCIItem)

      Me.StatusBarService.ProgressMonitor.BeginTask(Me.StringParserService.Parse("${res:Global.LCI.Level5Loading}"), Me.m_entity.CountCurrentLv4Lv5)
      
      RefreshDocs()

      Me.Cursor = Cursors.Default
      Me.StatusBarService.ProgressMonitor.Done()
      Me.m_treeManager.Treegrid.RefreshHeights()
      Me.m_gridsetting = False
      Control_Focus(lvLevel3, Nothing)
      Return

      'Application.DoEvents()
      'Dim parentItem As LCIItem = CType(lvLevel3.SelectedItems(0).Tag, LCIItem)
      'Dim dt As TreeTable = Me.GetDataTable
      'Dim l4coll As TreeBaseEntityCollection = Me.m_entity.GetLCICollection(4, parentItem.Id, "")
      'm_gridsetting = True
      'Me.Cursor = Cursors.WaitCursor
      'Me.StatusBarService.ProgressMonitor.BeginTask(Me.StringParserService.Parse("${res:Global.LCI.Level5Loading}"), l4coll.Count)
      'Dim j As Integer = 0
      'For Each l4item As LCIItem In l4coll
      'Dim l4row As TreeRow = dt.Childs.Add()
      'l4row.State = RowExpandState.Expanded
      'l4row("Selected") = False
      'l4row("Code") = l4item.Code
      'l4row("Description") = l4item.Name
      'l4row.Tag = l4item
      'Dim l5coll As TreeBaseEntityCollection = Me.m_entity.GetLCICollection(5, l4item.Id, "")
      'Dim i As Integer = 0
      'Dim tmpLv5Item As LCIItem
      'For Each l5item As LCIItem In l5coll
      'Dim l5row As TreeRow = l4row.Childs.Add()
      'l5row.State = RowExpandState.None
      'l5row("Selected") = False
      'l5row("Code") = l5item.Code
      'l5row("Description") = l5item.Name

      'l5row("Unit") = l5item.DefaultUnit.Name
      'If l5item.FairPrice <> 0 Then
      'l5row("UnitPrice") = Configuration.FormatToString(l5item.FairPrice, DigitConfig.UnitPrice)
      'End If

      'l5row("Unit1") = l5item.CompareUnit1.Name
      'If l5item.Price1 <> 0 Then
      'l5row("UnitPrice1") = Configuration.FormatToString(l5item.Price1, DigitConfig.UnitPrice)
      'End If

      'l5row("Unit2") = l5item.CompareUnit2.Name
      'If l5item.Price2 <> 0 Then
      'l5row("UnitPrice2") = Configuration.FormatToString(l5item.Price2, DigitConfig.UnitPrice)
      'End If

      'l5row("Unit3") = l5item.CompareUnit3.Name
      'If l5item.Price3 <> 0 Then
      'l5row("UnitPrice3") = Configuration.FormatToString(l5item.Price3, DigitConfig.UnitPrice)
      'End If

      'l5row.Tag = l5item
      'If i = l5coll.Count - 1 Then
      'tmpLv5Item = l5item
      'End If
      'i += 1
      'Next
      ''If Not tmpLv5Item Is Nothing Then
      ''    SetSelectedValue(tmpLv5Item)
      ''End If
      'j += 1
      'Me.StatusBarService.ProgressMonitor.Worked(j)
      'Next
      'Me.StatusBarService.ProgressMonitor.Done()
      'Me.m_treeManager.Treetable = dt
      'Me.Cursor = Cursors.Default
      'Me.m_treeManager.Treegrid.RefreshHeights()
      'm_gridsetting = False
      'Control_Focus(lvLevel3, Nothing)
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
      Select Case CType(sender, Button).Name.ToLower
        Case "btnclearlci"
          Me.txtFilterLv1.Text = ""
          Me.txtFilterLv2.Text = ""
          Me.txtFilterLv3.Text = ""
          Me.txtFilterLv4.Text = ""
          Me.txtFilterLv5.Text = ""
        Case "btnclearaltname"
          Me.txtFilterAltName.Text = ""
        Case "btnclearname"
          Me.txtFilterName.Text = ""
        Case "btnclearall"
          Me.txtFilterLv1.Text = ""
          Me.txtFilterLv2.Text = ""
          Me.txtFilterLv3.Text = ""
          Me.txtFilterLv4.Text = ""
          Me.txtFilterLv5.Text = ""
          Me.txtFilterAltName.Text = ""
          Me.txtFilterName.Text = ""

          Me.txtMinPrice.Text = ""
          Me.txtMaxPrice.Text = ""

          Me.m_selectedEntity = Nothing
          Me.lvLevel1.Items.Clear()
          Me.lvLevel2.Items.Clear()
          Me.lvLevel3.Items.Clear()
          Me.m_treeManager.Treetable.Clear()
      End Select
    End Sub

    Private tp As New ToolTip
    Private lastLv1Item As ListViewItem
    Private Sub lvLevel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvLevel1.MouseMove
      Dim item As ListViewItem = Me.lvLevel1.GetItemAt(e.X, e.Y)
      If item Is Nothing Then
        lastLv1Item = Nothing
        tp.SetToolTip(Me.lvLevel1, "")
        Return
      End If
      If lastLv1Item Is item Then
        Return
      End If
      lastLv1Item = item
      Dim lci As LCIItem = CType(item.Tag, LCIItem)
      tp.SetToolTip(Me.lvLevel1, lci.Code & " " & lci.AlternateName)
    End Sub
    Private lastLv2Item As ListViewItem
    Private Sub lvLevel2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvLevel2.MouseMove
      Dim item As ListViewItem = Me.lvLevel2.GetItemAt(e.X, e.Y)
      If item Is Nothing Then
        lastLv2Item = Nothing
        tp.SetToolTip(Me.lvLevel2, "")
        Return
      End If
      If lastLv2Item Is item Then
        Return
      End If
      lastLv2Item = item
      Dim lci As LCIItem = CType(item.Tag, LCIItem)
      tp.SetToolTip(Me.lvLevel2, lci.Code & " " & lci.AlternateName)
    End Sub
    Private lastLv3Item As ListViewItem
    Private Sub lvLevel3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvLevel3.MouseMove
      Dim item As ListViewItem = Me.lvLevel3.GetItemAt(e.X, e.Y)
      If item Is Nothing Then
        lastLv3Item = Nothing
        tp.SetToolTip(Me.lvLevel3, "")
        Return
      End If
      If lastLv3Item Is item Then
        Return
      End If
      lastLv3Item = item
      Dim lci As LCIItem = CType(item.Tag, LCIItem)
      tp.SetToolTip(Me.lvLevel3, lci.Code & " " & lci.AlternateName)
    End Sub
#End Region

#Region "Methods"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      ElseIf Not Me.m_selectedEntity Is Nothing Then
        Me.TitleName = Me.m_selectedEntity.TabPageText
      End If
    End Sub
    Private Function GetFilterArray() As Filter()
      Dim arr(9) As Filter
      arr(0) = New Filter("lci_lv1", IIf(Me.txtFilterLv1.Text.Length = 0, DBNull.Value, Me.txtFilterLv1.Text))
      arr(1) = New Filter("lci_lv2", IIf(Me.txtFilterLv2.Text.Length = 0, DBNull.Value, Me.txtFilterLv2.Text))
      arr(2) = New Filter("lci_lv3", IIf(Me.txtFilterLv3.Text.Length = 0, DBNull.Value, Me.txtFilterLv3.Text))
      arr(3) = New Filter("lci_lv4", IIf(Me.txtFilterLv4.Text.Length = 0, DBNull.Value, Me.txtFilterLv4.Text))
      arr(4) = New Filter("lci_lv5", IIf(Me.txtFilterLv5.Text.Length = 0, DBNull.Value, Me.txtFilterLv5.Text))
      arr(5) = New Filter("lci_name", IIf(Me.txtFilterName.Text.Length = 0, DBNull.Value, Me.txtFilterName.Text))
      arr(6) = New Filter("lci_altname", IIf(Me.txtFilterAltName.Text.Length = 0, DBNull.Value, Me.txtFilterAltName.Text))
      arr(7) = New Filter("minprice", IIf(Me.txtMinPrice.Text.Length = 0, DBNull.Value, Me.txtMinPrice.Text))
      arr(8) = New Filter("maxprice", IIf(Me.txtMaxPrice.Text.Length = 0, DBNull.Value, Me.txtMaxPrice.Text))
      arr(9) = New Filter("includecancel", Me.chkIncludeCancel.Checked)
      Return arr
    End Function
    Private Function GetFilterString() As String
      Dim filter As String = ""
      If Me.txtFilterLv1.Text.Length > 0 Then
        filter &= ConCatAnd(filter) & "lci_code='" & Me.txtFilterLv1.Text & "." & Me.txtFilterLv2.Text & "." & Me.txtFilterLv3.Text & "." & Me.txtFilterLv4.Text & "." & Me.txtFilterLv5.Text & "'"
        filter &= "and lci_lv1 like '%" & Me.txtFilterLv1.Text & "%'"
      End If
      If Me.txtFilterName.Text.Length > 0 Then
        filter &= ConCatAnd(filter) & "lci_name like '%" & Me.txtFilterName.Text & "%'"
      End If
      If Me.txtFilterAltName.Text.Length > 0 Then
        filter &= ConCatAnd(filter) & "lci_altname like '%" & Me.txtFilterAltName.Text & "%'"
      End If
      If Me.txtMinPrice.Text.Length > 0 AndAlso IsNumeric(Me.txtMinPrice.Text) Then
        filter &= ConCatAnd(filter) & "lci_fairprice>=" & Me.txtMinPrice.Text
      End If
      If Me.txtMaxPrice.Text.Length > 0 AndAlso IsNumeric(Me.txtMaxPrice.Text) Then
        filter &= ConCatAnd(filter) & "lci_fairprice>=" & Me.txtMaxPrice.Text
      End If
      If Me.chkIncludeCancel.Checked Then
        filter &= ConCatAnd(filter) & "lci_canceled=1"
      End If

      Return filter

    End Function
    Private Function ConCatAnd(ByVal filter As String) As String
      If filter.Length > 0 Then
        Return " and "
      End If
      Return ""
    End Function
    Private Sub SetSelectedValue(ByVal lci As LCIItem)
      If lci Is Nothing Then
        Return
      End If
      'lci = New LCIItem(lci.Id)
      'lci.Parent = New LCIItem(lci.Parent.Id)
      lci = Me.m_entity.GetLciitem(lci.Id)
      lci.Parent = Me.m_entity.GetLciitem(lci.Parent.Id)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      If lci.Level = 5 Then
        StatusBarService.SetMessage("${res:MainWindow.StatusBar.ReadyMessage}")
      End If
      Me.m_selectedEntity = lci
      Me.txtlv1.Text = lci.Lv1
      Me.txtlv2.Text = lci.Lv2
      Me.txtlv3.Text = lci.Lv3
      Me.txtlv4.Text = lci.Lv4
      Me.txtlv5.Text = lci.Lv5
      Me.txtName.Text = lci.Name
      Me.txtAltName.Text = lci.AlternateName
    End Sub
    Private Sub ClearSelectedValue()
      Me.m_selectedEntity = Nothing
      Me.txtlv1.Text = ""
      Me.txtlv2.Text = ""
      Me.txtlv3.Text = ""
      Me.txtlv4.Text = ""
      Me.txtlv5.Text = ""
      Me.txtName.Text = ""
      Me.txtAltName.Text = ""
    End Sub
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "LCI"
      dst.ReadOnly = True

      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Selected"
      csSelected.HeaderText = ""

      Dim csCode As New PlusMinusTreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LCIListViewPanelView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.ReadOnly = True
      csCode.Width = 160

      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "Description"
      csDescription.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LCIListViewPanelView.DescriptionHeaderText}")
      csDescription.NullText = ""
      csDescription.Width = 180
      csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LCIListViewPanelView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.DataAlignment = HorizontalAlignment.Center
      csUnit.ReadOnly = True

      Dim csUMC As New TreeTextColumn
      csUMC.MappingName = "UnitPrice"
      csUMC.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LCIListViewPanelView.UnitPriceHeaderText}")
      csUMC.NullText = ""
      csUMC.DataAlignment = HorizontalAlignment.Right
      csUMC.Format = "#,###.##"
      csUMC.ReadOnly = True

      If m_mode = Selection.MultiSelect Then
        dst.GridColumnStyles.Add(csSelected)
      End If
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csUMC)
      dst.GridColumnStyles.Add(csUnit)

      For i As Integer = 0 To 2
        Dim cunit As New TreeTextColumn
        cunit.MappingName = "Unit" & i + 1
        cunit.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LCIListViewPanelView.UnitHeaderText}") & " " & i + 1
        cunit.NullText = ""
        cunit.DataAlignment = HorizontalAlignment.Center
        cunit.ReadOnly = True

        Dim cumc As New TreeTextColumn
        cumc.MappingName = "UnitPrice" & i + 1
        cumc.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LCIListViewPanelView.UnitPriceHeaderText}")
        cumc.NullText = ""
        cumc.DataAlignment = HorizontalAlignment.Right
        cumc.Format = "#,###.##"
        cumc.ReadOnly = True

        Dim cb As New DataGridBarrierColumn
        cb.MappingName = "Barrier" & i + 1
        cb.BackColor = Color.Brown

        dst.GridColumnStyles.Add(cb)
        dst.GridColumnStyles.Add(cumc)
        dst.GridColumnStyles.Add(cunit)
      Next

      Return dst
    End Function
    Private Function GetDataTable() As TreeTable
      Dim myDatatable As New TreeTable("LCI")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("unitId", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitPrice", GetType(String)))

      For i As Integer = 0 To 2
        myDatatable.Columns.Add(New DataColumn("Barrier" & i + 1, GetType(String)))
        myDatatable.Columns.Add(New DataColumn("Unit" & i + 1, GetType(String)))
        myDatatable.Columns.Add(New DataColumn("UnitPrice" & i + 1, GetType(String)))
      Next
      Return myDatatable
    End Function
#End Region

#Region "Overrides"
    Public Overrides Sub Deselected()
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        If Not m_selectedEntity Is Nothing Then
          AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        End If
      End If
    End Sub
    'Public Overrides Sub Selected()
    '    Me.RefreshData(Me.SelectedEntity.Id.ToString)
    '    Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
    'End Sub
#End Region

#Region "IBasketCollectable"
    Private dlg As BasketDialog
    Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
      Get
        'For Each item As LCIItem In Me.lsbLevel1.CheckedItems
        '    Dim basketitem As New BasketItem(item.Id, item.Code, item.FullClassName, item.Code & ":" & item.Name)
        '    m_basketItems.Add(basketitem)
        'Next
        'For Each item As LCIItem In Me.lsbLevel2.CheckedItems
        '    Dim basketitem As New BasketItem(item.Id, item.Code, item.FullClassName, item.Code & ":" & item.Name)
        '    m_basketItems.Add(basketitem)
        'Next
        m_basketItems.Clear()
        For Each item As ListViewItem In Me.lvLevel3.CheckedItems
          Dim lci As LCIItem = CType(item.Tag, LCIItem)
          If lci.Level = 5 Then
            Dim basketitem As New BasketItem(lci.Id, lci.Code, lci.FullClassName, lci.Code & ":" & lci.Name)
            m_basketItems.Add(basketitem)
          End If
        Next
        For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
          If Not IsDBNull(row("Selected")) AndAlso CBool(row("Selected")) Then
            Dim lci As LCIItem = CType(row.Tag, LCIItem)
            If lci.Level = 5 Then
              Dim basketitem As New BasketItem(lci.Id, lci.Code, lci.FullClassName, lci.Code & ":" & lci.Name)
              m_basketItems.Add(basketitem)
            End If
          End If
        Next
        Return m_basketItems
      End Get
    End Property
    Public Overrides ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection
      Get
        Return m_proposedBasketItems
      End Get
    End Property

#End Region

  End Class
End Namespace

