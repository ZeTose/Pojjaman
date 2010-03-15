Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptRptAPGoodsReceiptByBillaFilterSubPanel
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
    Friend WithEvents lblBillDocEnd As System.Windows.Forms.Label
    Friend WithEvents lblBillDocStart As System.Windows.Forms.Label
    Friend WithEvents btnBillEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBillEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnBillStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBillStart As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptRptAPGoodsReceiptByBillaFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnBillEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBillEnd = New System.Windows.Forms.TextBox()
      Me.lblBillDocEnd = New System.Windows.Forms.Label()
      Me.btnBillStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtBillStart = New System.Windows.Forms.TextBox()
      Me.lblBillDocStart = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.txtTemp)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(456, 148)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เช็ครับ"
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(375, 116)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(64, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(305, 116)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(64, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(832, 32)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 21)
      Me.txtTemp.TabIndex = 3
      Me.txtTemp.Visible = False
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnBillEndFind)
      Me.grbDetail.Controls.Add(Me.txtBillEnd)
      Me.grbDetail.Controls.Add(Me.lblBillDocEnd)
      Me.grbDetail.Controls.Add(Me.btnBillStartFind)
      Me.grbDetail.Controls.Add(Me.txtBillStart)
      Me.grbDetail.Controls.Add(Me.lblBillDocStart)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(439, 96)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลทั่วไป"
      '
      'btnBillEndFind
      '
      Me.btnBillEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBillEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBillEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBillEndFind.Location = New System.Drawing.Point(376, 40)
      Me.btnBillEndFind.Name = "btnBillEndFind"
      Me.btnBillEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnBillEndFind.TabIndex = 20
      Me.btnBillEndFind.TabStop = False
      Me.btnBillEndFind.ThemedImage = CType(resources.GetObject("btnBillEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBillEnd
      '
      Me.Validator.SetDataType(Me.txtBillEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillEnd, "")
      Me.txtBillEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBillEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBillEnd, System.Drawing.Color.Empty)
      Me.txtBillEnd.Location = New System.Drawing.Point(280, 40)
      Me.Validator.SetMinValue(Me.txtBillEnd, "")
      Me.txtBillEnd.Name = "txtBillEnd"
      Me.Validator.SetRegularExpression(Me.txtBillEnd, "")
      Me.Validator.SetRequired(Me.txtBillEnd, False)
      Me.txtBillEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtBillEnd.TabIndex = 6
      '
      'lblBillDocEnd
      '
      Me.lblBillDocEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillDocEnd.ForeColor = System.Drawing.Color.Black
      Me.lblBillDocEnd.Location = New System.Drawing.Point(248, 40)
      Me.lblBillDocEnd.Name = "lblBillDocEnd"
      Me.lblBillDocEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblBillDocEnd.TabIndex = 58
      Me.lblBillDocEnd.Text = "ถึง"
      Me.lblBillDocEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnBillStartFind
      '
      Me.btnBillStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBillStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBillStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnBillStartFind.Location = New System.Drawing.Point(216, 40)
      Me.btnBillStartFind.Name = "btnBillStartFind"
      Me.btnBillStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnBillStartFind.TabIndex = 19
      Me.btnBillStartFind.TabStop = False
      Me.btnBillStartFind.ThemedImage = CType(resources.GetObject("btnBillStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBillStart
      '
      Me.Validator.SetDataType(Me.txtBillStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillStart, "")
      Me.txtBillStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBillStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBillStart, System.Drawing.Color.Empty)
      Me.txtBillStart.Location = New System.Drawing.Point(120, 40)
      Me.Validator.SetMinValue(Me.txtBillStart, "")
      Me.txtBillStart.Name = "txtBillStart"
      Me.Validator.SetRegularExpression(Me.txtBillStart, "")
      Me.Validator.SetRequired(Me.txtBillStart, False)
      Me.txtBillStart.Size = New System.Drawing.Size(96, 21)
      Me.txtBillStart.TabIndex = 5
      '
      'lblBillDocStart
      '
      Me.lblBillDocStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillDocStart.ForeColor = System.Drawing.Color.Black
      Me.lblBillDocStart.Location = New System.Drawing.Point(32, 40)
      Me.lblBillDocStart.Name = "lblBillDocStart"
      Me.lblBillDocStart.Size = New System.Drawing.Size(80, 18)
      Me.lblBillDocStart.TabIndex = 55
      Me.lblBillDocStart.Text = "ใบรับวางบิล"
      Me.lblBillDocStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'RptRptAPGoodsReceiptByBillaFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptRptAPGoodsReceiptByBillaFilterSubPanel"
      Me.Size = New System.Drawing.Size(472, 164)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptRptAPGoodsReceiptByBillaFilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptRptAPGoodsReceiptByBillaFilterSubPanel.grbDetail}")

      Me.lblBillDocStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptRptAPGoodsReceiptByBillaFilterSubPanel.lblBillDocStart}")
      Me.Validator.SetDisplayName(txtBillStart, lblBillDocStart.Text)
      Me.lblBillDocEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtBillEnd, lblBillDocEnd.Text)
    End Sub
#End Region

#Region "Member"
    Private m_BillStart As BillAcceptance
    Private m_BillEnd As BillAcceptance
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
    Public Property BillStart() As BillAcceptance
      Get
        Return m_BillStart
      End Get
      Set(ByVal Value As BillAcceptance)
        m_BillStart = Value
      End Set
    End Property
    Public Property BillEnd() As BillAcceptance
      Get
        Return m_BillEnd
      End Get
      Set(ByVal Value As BillAcceptance)
        m_BillEnd = Value
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

      Me.BillStart = New BillAcceptance
      Me.BillEnd = New BillAcceptance
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(2) As Filter
      arr(0) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(1) = New Filter("BillStart", Me.ValidCodeOrDBNull(BillStart))
      arr(2) = New Filter("BillEnd", Me.ValidCodeOrDBNull(BillEnd))
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

#Region " IReportFilterSubPanel "
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

      'BillStart
      dpi = New DocPrintingItem
      dpi.Mapping = "BillStart"
      dpi.Value = Me.txtBillStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'BillEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "BillEnd"
      dpi.Value = Me.txtBillEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      AddHandler txtBillStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtBillEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler btnBillStartFind.Click, AddressOf Me.btnBillFind_Click
      AddHandler btnBillEndFind.Click, AddressOf Me.btnBillFind_Click
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtbillstart"
          BillAcceptance.GetBillAcceptance(txtBillStart, BillStart)

        Case "txtbillend"
          BillAcceptance.GetBillAcceptance(txtBillEnd, BillEnd)

        Case Else
      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsupplicodestart", "txtsupplicodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            'Case "txtsupplicodestart"
            'Me.SetSupplierStartDialog(entity)

            'Case "txtsupplicodeend"
            'Me.SetSupplierEndDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Dim oldBAStart As BillAcceptance
    Dim oldBAEnd As BillAcceptance
    Private Sub btnBillFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnbillstartfind"
          myEntityPanelService.OpenListDialog(New BillAcceptance, AddressOf SetbtnBillStartDialog)

        Case "btnbillendfind"
          myEntityPanelService.OpenListDialog(New BillAcceptance, AddressOf SetbtnBillEndDialog)

      End Select
    End Sub
    Private Sub SetbtnBillStartDialog(ByVal e As ISimpleEntity)
      Me.txtBillStart.Text = e.Code
      BillAcceptance.GetBillAcceptance(txtBillStart, BillStart)
      'If BillAcceptance.GetBillAcceptance(txtBillStart, BillStart) Then
      '    oldBAStart = New BillAcceptance(e.Code)
      'End If
    End Sub
    Private Sub SetbtnBillEndDialog(ByVal e As ISimpleEntity)
      Me.txtBillEnd.Text = e.Code
      BillAcceptance.GetBillAcceptance(txtBillEnd, BillEnd)
      'If BillAcceptance.GetBillAcceptance(txtBillEnd, BillEnd) Then
      '    oldBAEnd = New BillAcceptance(e.Code)
      'End If
    End Sub
  
#End Region

  End Class
End Namespace

