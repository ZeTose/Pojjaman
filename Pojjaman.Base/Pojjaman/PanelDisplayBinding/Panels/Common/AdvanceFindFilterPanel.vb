Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid

Namespace Longkong.Pojjaman.Gui.Panels

  Public Class AdvanceFindFilterPanel
    Inherits AbstractEntityDetailPanelView

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
    Friend WithEvents rbAnd As System.Windows.Forms.RadioButton
    Friend WithEvents lblFilterLevel As System.Windows.Forms.Label
    Friend WithEvents cmbFilterLevel As System.Windows.Forms.ComboBox
    Friend WithEvents rbOr As System.Windows.Forms.RadioButton
    Friend WithEvents tgWBS As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.btnClear = New System.Windows.Forms.Button
      Me.rbAnd = New System.Windows.Forms.RadioButton
      Me.rbOr = New System.Windows.Forms.RadioButton
      Me.lblFilterLevel = New System.Windows.Forms.Label
      Me.cmbFilterLevel = New System.Windows.Forms.ComboBox
      Me.tgWBS = New Syncfusion.Windows.Forms.Grid.GridControl
      Me.btnOK = New System.Windows.Forms.Button
      CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnClear
      '
      Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnClear.Location = New System.Drawing.Point(542, 272)
      Me.btnClear.Name = "btnClear"
      Me.btnClear.Size = New System.Drawing.Size(80, 24)
      Me.btnClear.TabIndex = 0
      Me.btnClear.Text = "Clear"
      '
      'rbAnd
      '
      Me.rbAnd.Checked = True
      Me.rbAnd.Location = New System.Drawing.Point(16, 16)
      Me.rbAnd.Name = "rbAnd"
      Me.rbAnd.Size = New System.Drawing.Size(64, 21)
      Me.rbAnd.TabIndex = 1
      Me.rbAnd.TabStop = True
      Me.rbAnd.Text = "And"
      '
      'rbOr
      '
      Me.rbOr.Location = New System.Drawing.Point(80, 16)
      Me.rbOr.Name = "rbOr"
      Me.rbOr.Size = New System.Drawing.Size(56, 21)
      Me.rbOr.TabIndex = 1
      Me.rbOr.Text = "Or"
      '
      'lblFilterLevel
      '
      Me.lblFilterLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblFilterLevel.Location = New System.Drawing.Point(486, 16)
      Me.lblFilterLevel.Name = "lblFilterLevel"
      Me.lblFilterLevel.Size = New System.Drawing.Size(72, 21)
      Me.lblFilterLevel.TabIndex = 3
      Me.lblFilterLevel.Text = "Filter Level"
      Me.lblFilterLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbFilterLevel
      '
      Me.cmbFilterLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbFilterLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFilterLevel.Location = New System.Drawing.Point(566, 16)
      Me.cmbFilterLevel.Name = "cmbFilterLevel"
      Me.cmbFilterLevel.Size = New System.Drawing.Size(56, 21)
      Me.cmbFilterLevel.TabIndex = 4
      '
      'tgWBS
      '
      Me.tgWBS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgWBS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.tgWBS.ColCount = 0
      Me.tgWBS.DefaultColWidth = 100
      Me.tgWBS.ForeColor = System.Drawing.SystemColors.ControlText
      Me.tgWBS.Location = New System.Drawing.Point(8, 40)
      Me.tgWBS.Name = "tgWBS"
      Me.tgWBS.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.tgWBS.RowCount = 0
      Me.tgWBS.Size = New System.Drawing.Size(614, 224)
      Me.tgWBS.SmartSizeBox = False
      Me.tgWBS.TabIndex = 2
      Me.tgWBS.ThemesEnabled = True
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOK.Location = New System.Drawing.Point(456, 272)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(80, 24)
      Me.btnOK.TabIndex = 0
      Me.btnOK.Text = "OK"
      '
      'AdvanceFindFilterPanel
      '
      Me.Controls.Add(Me.tgWBS)
      Me.Controls.Add(Me.btnClear)
      Me.Controls.Add(Me.lblFilterLevel)
      Me.Controls.Add(Me.cmbFilterLevel)
      Me.Controls.Add(Me.rbAnd)
      Me.Controls.Add(Me.rbOr)
      Me.Controls.Add(Me.btnOK)
      Me.Name = "AdvanceFindFilterPanel"
      Me.Size = New System.Drawing.Size(630, 302)
      CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As iAdvanceFind
    Private m_group As String
    Private m_advanceFind As AdvanceFind
#End Region

#Region "Constructors"
    Public Sub New(ByVal myEntity As iAdvanceFind, ByVal advFindGroup As String)
      MyBase.New()
      Me.InitializeComponent()
      m_entity = myEntity
      m_group = advFindGroup
      'Me.SetLabelText()
      Initialize()

      'm_entity = CType(myEntity, AdvancedSearchs)

      'm_entity = myEntity
      'm_collection = m_entity.AdvancePayItemCollection
      'm_oldcollection = CType(Me.m_collection.Clone, AdvancePayItemCollection)
    End Sub
#End Region

#Region "Style"
    Public Sub CreateGridStyle(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      grid.RowCount = 10
      grid.ColCount = 4

      grid.Model.ColStyles(1).CellType = "ComboBox"
      grid.Model.ColStyles(1).DataSource = AdvanceFindField.GetFieldList(m_group)
      grid.Model.ColStyles(1).DisplayMember = "advfind_description"
      grid.Model.ColStyles(1).ValueMember = "advfind_code"
      grid.Model.ColStyles(1).DropDownStyle = Syncfusion.Windows.Forms.Grid.GridDropDownStyle.Exclusive

      grid.Model.ColStyles(4).CellType = "PushButton"
      grid.Model.ColStyles(4).CellAppearance = GridCellAppearance.Raised
      grid.Model.ColStyles(4).Description = "X"

      grid.Model.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      grid.Model.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      grid.Model.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      grid.Model.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center

      grid.ColWidths(1) = 150
      grid.ColWidths(2) = 200
      grid.ColWidths(3) = 200
      grid.ColWidths(4) = 25

      grid(0, 1).Text = "Field"
      grid(0, 2).Text = "Min"
      grid(0, 3).Text = "Max"
      grid(0, 4).Text = " "
    End Sub
#End Region

#Region "Method"
    Public Overrides Sub Initialize()
      For i As Integer = 1 To 4
        Me.cmbFilterLevel.Items.Add(i)
      Next
      Me.cmbFilterLevel.SelectedIndex = 0
    End Sub
    Public Sub ListInGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      Grid.BeginUpdate()
      Grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Grid.Model.Options.NumberedColHeaders = False
      Grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
      CreateGridStyle(Grid)
      PopulateData(Grid)
      Grid.Refresh()
      Grid.EndUpdate()
    End Sub
    Public Sub PopulateData(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      ClearGrid(grid)
      If Not m_advanceFind Is Nothing AndAlso m_advanceFind.ItemCollection.Count > 0 Then
        Dim i As Integer = 0
        For Each myRow As AdvanceFindItem In m_advanceFind.ItemCollection
          i += 1
          tgWBS(i, 1).CellValue = myRow.Field
          tgWBS(i, 2).CellValue = myRow.MinValue
          tgWBS(i, 3).CellValue = myRow.MaxValue
          tgWBS.RowStyles(i).Tag = myRow
        Next
      End If

    End Sub
    Public Sub ClearGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      grid.ClearCells(grid.GridCellsRange, True)
      For i As Integer = 1 To grid.RowCount
        grid.RowStyles(i).Tag = Nothing
        grid(i, 1).ResetCellValue()
      Next
    End Sub
#End Region

#Region "Event Handler"
    Private Sub cmbFilterLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilterLevel.SelectedIndexChanged
      m_advanceFind = m_entity.AdvanceFindCollection.GetItem(CInt(cmbFilterLevel.SelectedItem))
      If m_advanceFind.OperatorAnd Then
        rbAnd.Checked = True
      Else
        rbOr.Checked = True
      End If
      ListInGrid(tgWBS)
    End Sub
    Private Sub tgWBS_CurrentCellDeactivated(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCurrentCellDeactivatedEventArgs) Handles tgWBS.CurrentCellDeactivated
      If Me.tgWBS.RowStyles(e.RowIndex).Tag Is Nothing Then
        If e.ColIndex = 1 AndAlso tgWBS(e.RowIndex, 1).CellValue.ToString.Length > 0 Then
          Dim myField As New AdvanceFindItem
          myField.Field = tgWBS(e.RowIndex, 1).CellValue.ToString
          myField.DataType = AdvanceFindField.GetDataType(m_group, myField.Field)
          Me.tgWBS.RowStyles(e.RowIndex).Tag = myField
          'Add to Collection
          m_advanceFind.ItemCollection.Add(myField)
        Else
          Me.tgWBS(e.RowIndex, e.ColIndex).Text = ""
        End If
      Else
        Dim myField As AdvanceFindItem = CType(Me.tgWBS.RowStyles(e.RowIndex).Tag, AdvanceFindItem)
        myField.Field = tgWBS(e.RowIndex, 1).CellValue.ToString
        myField.DataType = AdvanceFindField.GetDataType(m_group, myField.Field)
        myField.MinValue = tgWBS(e.RowIndex, 2).Text
        myField.MaxValue = tgWBS(e.RowIndex, 3).Text
        Me.tgWBS.RowStyles(e.RowIndex).Tag = myField
      End If
    End Sub
    Private Sub tgWBS_CellButtonClicked(ByVal sender As Object, ByVal e As GridCellButtonClickedEventArgs) Handles tgWBS.CellButtonClicked
      If Not Me.tgWBS.RowStyles(e.RowIndex).Tag Is Nothing AndAlso e.ColIndex = 4 Then
        m_advanceFind.ItemCollection.RemoveAt(e.RowIndex - 1)
        PopulateData(tgWBS)
      End If
    End Sub
    Private Sub rbAnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAnd.CheckedChanged
      If Not m_advanceFind Is Nothing Then
        m_advanceFind.OperatorAnd = True
      End If
    End Sub
    Private Sub rbOr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOr.CheckedChanged
      If Not m_advanceFind Is Nothing Then
        m_advanceFind.OperatorAnd = False
      End If
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
      m_entity.AdvanceFindCollection.Clear()
      m_advanceFind = m_entity.AdvanceFindCollection.GetItem(CInt(cmbFilterLevel.SelectedItem))
      ListInGrid(tgWBS)
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      Form.ActiveForm.Close()
    End Sub
#End Region


  End Class

End Namespace
