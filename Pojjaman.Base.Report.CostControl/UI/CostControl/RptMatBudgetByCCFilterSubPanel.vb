Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptMatBudgetByCCFilterSubPanel
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
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnCostcenterCodeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents TxtCostcenterCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCostcenterStart As System.Windows.Forms.Label
    Friend WithEvents btnLciEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtLciCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblLciEnd As System.Windows.Forms.Label
    Friend WithEvents btnLciStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtLciCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblLciStart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptMatBudgetByCCFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtTemp = New System.Windows.Forms.TextBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.btnLciEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtLciCodeEnd = New System.Windows.Forms.TextBox
      Me.lblLciEnd = New System.Windows.Forms.Label
      Me.btnLciStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtLciCodeStart = New System.Windows.Forms.TextBox
      Me.lblLciStart = New System.Windows.Forms.Label
      Me.btnCostcenterCodeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.TxtCostcenterCodeStart = New System.Windows.Forms.TextBox
      Me.lblCostcenterStart = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(456, 136)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(464, 32)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtTemp, "")
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 3
      Me.txtTemp.Text = ""
      Me.txtTemp.Visible = False
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnLciEndFind)
      Me.grbDetail.Controls.Add(Me.txtLciCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblLciEnd)
      Me.grbDetail.Controls.Add(Me.btnLciStartFind)
      Me.grbDetail.Controls.Add(Me.txtLciCodeStart)
      Me.grbDetail.Controls.Add(Me.lblLciStart)
      Me.grbDetail.Controls.Add(Me.btnCostcenterCodeStartFind)
      Me.grbDetail.Controls.Add(Me.TxtCostcenterCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCostcenterStart)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(424, 80)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnLciEndFind
      '
      Me.btnLciEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLciEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLciEndFind.Image = CType(resources.GetObject("btnLciEndFind.Image"), System.Drawing.Image)
      Me.btnLciEndFind.Location = New System.Drawing.Point(384, 48)
      Me.btnLciEndFind.Name = "btnLciEndFind"
      Me.btnLciEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnLciEndFind.TabIndex = 23
      Me.btnLciEndFind.TabStop = False
      Me.btnLciEndFind.ThemedImage = CType(resources.GetObject("btnLciEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtLciCodeEnd
      '
      Me.Validator.SetDataType(Me.txtLciCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLciCodeEnd, "")
      Me.txtLciCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtLciCodeEnd, System.Drawing.Color.Empty)
      Me.txtLciCodeEnd.Location = New System.Drawing.Point(288, 48)
      Me.Validator.SetMaxValue(Me.txtLciCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtLciCodeEnd, "")
      Me.txtLciCodeEnd.Name = "txtLciCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtLciCodeEnd, "")
      Me.Validator.SetRequired(Me.txtLciCodeEnd, False)
      Me.txtLciCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtLciCodeEnd.TabIndex = 22
      Me.txtLciCodeEnd.Text = ""
      '
      'lblLciEnd
      '
      Me.lblLciEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLciEnd.ForeColor = System.Drawing.Color.Black
      Me.lblLciEnd.Location = New System.Drawing.Point(256, 48)
      Me.lblLciEnd.Name = "lblLciEnd"
      Me.lblLciEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblLciEnd.TabIndex = 21
      Me.lblLciEnd.Text = "ถึง"
      Me.lblLciEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnLciStartFind
      '
      Me.btnLciStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLciStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLciStartFind.Image = CType(resources.GetObject("btnLciStartFind.Image"), System.Drawing.Image)
      Me.btnLciStartFind.Location = New System.Drawing.Point(224, 48)
      Me.btnLciStartFind.Name = "btnLciStartFind"
      Me.btnLciStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnLciStartFind.TabIndex = 20
      Me.btnLciStartFind.TabStop = False
      Me.btnLciStartFind.ThemedImage = CType(resources.GetObject("btnLciStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtLciCodeStart
      '
      Me.Validator.SetDataType(Me.txtLciCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLciCodeStart, "")
      Me.txtLciCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtLciCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtLciCodeStart, System.Drawing.Color.Empty)
      Me.txtLciCodeStart.Location = New System.Drawing.Point(128, 48)
      Me.Validator.SetMaxValue(Me.txtLciCodeStart, "")
      Me.Validator.SetMinValue(Me.txtLciCodeStart, "")
      Me.txtLciCodeStart.Name = "txtLciCodeStart"
      Me.Validator.SetRegularExpression(Me.txtLciCodeStart, "")
      Me.Validator.SetRequired(Me.txtLciCodeStart, False)
      Me.txtLciCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtLciCodeStart.TabIndex = 19
      Me.txtLciCodeStart.Text = ""
      '
      'lblLciStart
      '
      Me.lblLciStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLciStart.ForeColor = System.Drawing.Color.Black
      Me.lblLciStart.Location = New System.Drawing.Point(32, 48)
      Me.lblLciStart.Name = "lblLciStart"
      Me.lblLciStart.Size = New System.Drawing.Size(88, 18)
      Me.lblLciStart.TabIndex = 18
      Me.lblLciStart.Text = "ตั้งแต่วัสดุ:"
      Me.lblLciStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCostcenterCodeStartFind
      '
      Me.btnCostcenterCodeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCostcenterCodeStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCostcenterCodeStartFind.Image = CType(resources.GetObject("btnCostcenterCodeStartFind.Image"), System.Drawing.Image)
      Me.btnCostcenterCodeStartFind.Location = New System.Drawing.Point(224, 16)
      Me.btnCostcenterCodeStartFind.Name = "btnCostcenterCodeStartFind"
      Me.btnCostcenterCodeStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCostcenterCodeStartFind.TabIndex = 14
      Me.btnCostcenterCodeStartFind.TabStop = False
      Me.btnCostcenterCodeStartFind.ThemedImage = CType(resources.GetObject("btnCostcenterCodeStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'TxtCostcenterCodeStart
      '
      Me.Validator.SetDataType(Me.TxtCostcenterCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.TxtCostcenterCodeStart, "")
      Me.TxtCostcenterCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.TxtCostcenterCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.TxtCostcenterCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.TxtCostcenterCodeStart, System.Drawing.Color.Empty)
      Me.TxtCostcenterCodeStart.Location = New System.Drawing.Point(128, 16)
      Me.Validator.SetMaxValue(Me.TxtCostcenterCodeStart, "")
      Me.Validator.SetMinValue(Me.TxtCostcenterCodeStart, "")
      Me.TxtCostcenterCodeStart.Name = "TxtCostcenterCodeStart"
      Me.Validator.SetRegularExpression(Me.TxtCostcenterCodeStart, "")
      Me.Validator.SetRequired(Me.TxtCostcenterCodeStart, False)
      Me.TxtCostcenterCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.TxtCostcenterCodeStart.TabIndex = 13
      Me.TxtCostcenterCodeStart.Text = ""
      '
      'lblCostcenterStart
      '
      Me.lblCostcenterStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostcenterStart.ForeColor = System.Drawing.Color.Black
      Me.lblCostcenterStart.Location = New System.Drawing.Point(8, 16)
      Me.lblCostcenterStart.Name = "lblCostcenterStart"
      Me.lblCostcenterStart.Size = New System.Drawing.Size(112, 18)
      Me.lblCostcenterStart.TabIndex = 12
      Me.lblCostcenterStart.Text = "ตั้งแต่ Cost Center"
      Me.lblCostcenterStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(368, 104)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(288, 104)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'RptMatBudgetByCCFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptMatBudgetByCCFilterSubPanel"
      Me.Size = New System.Drawing.Size(472, 168)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      Me.lblCostcenterStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatBudgetByCCFilterSubPanel.lblCostcenterStart}")
      Me.Validator.SetDisplayName(TxtCostcenterCodeStart, lblCostcenterStart.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatBudgetByCCFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatBudgetByCCFilterSubPanel.grbDetail}")

      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblLciStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPObyLCIFilterSubPanel.lblLciStart}")
      Me.Validator.SetDisplayName(txtLciCodeStart, lblLciStart.Text)

      ' Global {ถึง}
      Me.lblLciEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtLciCodeEnd, lblLciEnd.Text)

    End Sub
#End Region

#Region "Member"
    Private m_cc As Costcenter

    Private m_lcistart As LCIItem
    Private m_lciend As LCIItem
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property LciStart() As LCIItem
      Get
        Return m_lcistart
      End Get
      Set(ByVal Value As LCIItem)
        m_lcistart = Value
      End Set
    End Property
    Public Property LciEnd() As LCIItem
      Get
        Return m_lciend
      End Get
      Set(ByVal Value As LCIItem)
        m_lciend = Value
      End Set
    End Property
    Public Property Costcenter() As Costcenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As Costcenter)
        m_cc = Value
      End Set
    End Property
#End Region

#Region "Methods"

    Private Sub Initialize()
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
        End If
      Next

      Me.LciStart = New LCIItem
      Me.LciEnd = New LCIItem

      'Me.Supplier = New Supplier
      Me.Costcenter = New Costcenter
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(3) As Filter
      arr(0) = New Filter("CostCenter", IIf(TxtCostcenterCodeStart.TextLength > 0, TxtCostcenterCodeStart.Text, DBNull.Value))
      arr(1) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(2) = New Filter("LciStart", IIf(txtLciCodeStart.TextLength > 0, txtLciCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("LciEnd", IIf(txtLciCodeEnd.TextLength > 0, txtLciCodeEnd.Text, DBNull.Value))
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

#Region "IReportFilterSubPanel"
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'Month
      dpi = New DocPrintingItem
      dpi.Mapping = "Month"
      dpi.Value = "" 'Me.cmbMonth.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Year
      dpi = New DocPrintingItem
      dpi.Mapping = "Year"
      dpi.Value = "" 'Me.cmbYear.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Cost Center Start
      dpi = New DocPrintingItem
      dpi.Mapping = "Costcenter"
      dpi.Value = Me.TxtCostcenterCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'LCIStart
      dpi = New DocPrintingItem
      dpi.Mapping = "LCIStart"
      dpi.Value = Me.txtLciCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'LCIEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "LCIEnd"
      dpi.Value = Me.txtLciCodeEnd.Text
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

#Region " ChangeProperty "
    Private Sub EventWiring()
      'AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
      'AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnLciStartFind.Click, AddressOf Me.btnLciFind_Click
      AddHandler btnLciEndFind.Click, AddressOf Me.btnLciFind_Click

      AddHandler btnCostcenterCodeStartFind.Click, AddressOf Me.btnCostcenterFind_Click

      AddHandler TxtCostcenterCodeStart.Validated, AddressOf Me.ChangeProperty

    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcostcentercodestart"
          Costcenter.GetCostCenter(TxtCostcenterCodeStart, txtTemp, Me.Costcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        ' Supplier
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsupplicodestart", "txtsupplicodeend"
                Return True
            End Select
          End If
        End If
        ' Costcenter
        If data.GetDataPresent((New Costcenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcostcentercodestart", "txtcostcentercodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      '' Supplier
      'If data.GetDataPresent((New Supplier).FullClassName) Then
      '    Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
      '    Dim entity As New Supplier(id)
      '    If Not Me.ActiveControl Is Nothing Then
      '        Select Case Me.ActiveControl.Name.ToLower
      '            Case "txtsupplicodestart"
      '                Me.SetSupplierStartDialog(entity)

      '            Case "txtsupplicodeend"
      '                Me.SetSupplierEndDialog(entity)

      '        End Select
      '    End If
      'End If
      ' Costcenter
      If data.GetDataPresent((New Costcenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
        Dim entity As New Costcenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcostcentercodestart"
              Me.SetCostcenterStartDialog(entity)

            Case "txtcostcentercodeend"
              Me.SetCostcenterStartDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub btnLciFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnlcistartfind"
          myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciStartDialog)

        Case "btnlciendfind"
          myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLciEndDialog)

      End Select
    End Sub
    Private Sub SetLciStartDialog(ByVal e As ISimpleEntity)
      Me.txtLciCodeStart.Text = e.Code
      LCIItem.GetLCIItem(txtLciCodeStart, txtTemp, Me.LciStart)
    End Sub
    Private Sub SetLciEndDialog(ByVal e As ISimpleEntity)
      Me.txtLciCodeEnd.Text = e.Code
      LCIItem.GetLCIItem(txtLciCodeEnd, txtTemp, Me.LciEnd)
    End Sub

    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncostcentercodestartfind"
          myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCostcenterStartDialog)

      End Select
    End Sub
    Private Sub SetCostcenterStartDialog(ByVal e As ISimpleEntity)
      Me.TxtCostcenterCodeStart.Text = e.Code
      Costcenter.GetCostCenter(TxtCostcenterCodeStart, txtTemp, Me.Costcenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region

  End Class
End Namespace

