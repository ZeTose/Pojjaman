Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
'Imports System.Reflection
'Imports Longkong.Pojjaman.DataAccessLayer
'Imports Longkong.Pojjaman.Services
'Imports System.Drawing.Printing
'Imports Longkong.Pojjaman.Gui.ReportsAndDocs
'Imports System.Drawing
'Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Generic
Imports System.Data.SqlClient
'Imports System.Data.Objects
Imports Longkong.Core.Properties
Imports System.IO
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BuilkMatchView
    'Inherits UserControl
    Inherits AbstractEntityPanelViewContent
    Implements ISaveContent ', IPrintableEntity
    'Implements ISimpleListPanel 'IValidatable, 

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
    Friend WithEvents tgitem As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents GridControl1 As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.GridControl1 = New Syncfusion.Windows.Forms.Grid.GridControl()
      Me.tgitem = New Syncfusion.Windows.Forms.Grid.GridControl()
      Me.btnRefresh = New System.Windows.Forms.Button()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgitem, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'GridControl1
      '
      Me.GridControl1.Location = New System.Drawing.Point(0, 0)
      Me.GridControl1.Name = "GridControl1"
      Me.GridControl1.Size = New System.Drawing.Size(130, 80)
      Me.GridControl1.SmartSizeBox = False
      '
      'tgitem
      '
      Me.tgitem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgitem.DefaultGridBorderStyle = Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid
      Me.tgitem.DefaultRowHeight = 20
      Me.tgitem.ExcelLikeSelectionFrame = True
      Me.tgitem.Location = New System.Drawing.Point(14, 38)
      Me.tgitem.Name = "tgitem"
      Me.tgitem.NumberedColHeaders = False
      Me.tgitem.NumberedRowHeaders = False
      Me.tgitem.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeAsRangeStylesIntoCode
      Me.tgitem.Size = New System.Drawing.Size(640, 473)
      Me.tgitem.SmartSizeBox = False
      Me.tgitem.TabIndex = 0
      Me.tgitem.Text = "GridControl2"
      Me.tgitem.ThemesEnabled = True
      Me.tgitem.UseRightToLeftCompatibleTextBox = True
      '
      'btnRefresh
      '
      Me.btnRefresh.Location = New System.Drawing.Point(14, 9)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
      Me.btnRefresh.TabIndex = 1
      Me.btnRefresh.Text = "Refresh"
      Me.btnRefresh.UseVisualStyleBackColor = True
      '
      'BuilkMatchView
      '
      Me.Controls.Add(Me.btnRefresh)
      Me.Controls.Add(Me.tgitem)
      Me.Name = "BuilkMatchView"
      Me.Size = New System.Drawing.Size(672, 525)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgitem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    'Private m_entity As WorkCode

    Private m_isInitialized As Boolean

    Private m_tableInitialized As Boolean


    Private m_updating As Boolean = False


#End Region

#Region "Constructors"
    Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      InitGrid()

      PopulateGrid()

    End Sub
#End Region

#Region "Properties"
    Public Overrides Property TitleName As String
      Get
        Return "Builk Match"
      End Get
      Set(ByVal value As String)
        MyBase.TitleName = value
      End Set
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return "Builk Match" 'Me.m_entity.ListPanelTitle
      End Get
    End Property
#End Region

#Region "Methods"

    Private Sub InitGrid()

      tgitem.ColCount = 4
      tgitem.RowCount = 1

      tgitem.Rows.HeaderCount = 1
      tgitem.Rows.FrozenCount = 1
      'tgItem.Cols.HeaderCount = 1
      'tgitem.Cols.FrozenCount = 1

      tgitem.TableStyle.CheckBoxOptions = New GridCheckBoxCellInfo("True", "False", "", False)

      tgitem.ColStyles(4).CellType = "CheckBox"
      tgitem.ColStyles(4).TriState = False
      tgitem.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center


      Dim items As New StringCollection
      Dim dt As DataTable = (New Supplier).GetCodeNameList
      For Each row As DataRow In dt.Rows
        items.Add(row("supplier_name").ToString & "[" & row("supplier_code").ToString & "]")
      Next


      tgitem.ColStyles(3).CellType = "ComboBox"
      tgitem.ColStyles(3).ChoiceList = items
      tgitem.ColStyles(3).CellValue = ""


      tgitem.ColWidths(1) = 200
      tgitem.ColWidths(2) = 550
      tgitem.ColWidths(3) = 200
      tgitem.ColWidths(4) = 100

      SetGridValue(1, 1, "ชื่อ", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 2, "ที่อยู่", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 3, "ผู้ขาย", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 4, "Payment Track", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)



      tgItem.BackColor = Color.White



    End Sub


    Private Sub PopulateGrid()

      tgitem.BeginUpdate()

      tgitem.RowCount = 1


      tgitem.RowCount += 1
      SetGridValue(tgitem.RowCount, 1, "")
      SetGridValue(tgitem.RowCount, 2, "")
      'SetGridValue(tgitem.RowCount, 3, "")
      'tgitem(tgitem.RowCount, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center

      tgitem.EndUpdate()

    End Sub

    Private Sub ClearGrid()

    End Sub


    Private Sub SetGridValue(ByVal row As Integer, ByVal col As Integer, ByVal value As String _
, Optional ByVal bold As Boolean = False _
, Optional ByVal hAlign As Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left _
, Optional ByVal vAlign As Syncfusion.Windows.Forms.Grid.GridVerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle)
      tgitem(row, col).HorizontalAlignment = hAlign
      tgitem(row, col).VerticalAlignment = vAlign
      tgitem(row, col).Text = value
      tgitem(row, col).Font.Bold = bold
    End Sub



    Public Overloads Overrides Sub Save()
      'Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)

      MessageBox.Show("It's Ok.")

    End Sub



#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          Case Keys.Insert
            'ibtnBlank_Click(Nothing, Nothing)
            Return True
          Case Keys.Delete
            'If Me.tgItem.Focused Then
            '  'ibtnDelRow_Click(Nothing, Nothing)
            '  Return True
            'Else
            Return False
            'End If
          Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
#End Region

#Region "Event"
    Private Sub tgItem_CellDoubleClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      'MessageBox.Show("Hello" & MousePosition.X & ":" & MousePosition.Y)

      If e.RowIndex < 3 Or e.ColIndex < 2 Then
        Return
      End If


    End Sub

    Private Sub tgItem_CurrentCellStartEditing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
      If Not m_updating Then
        e.Cancel = True
      End If
    End Sub
#End Region



    '#Region "IPrintable"
    '        Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
    '            Get
    '                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    '                Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
    '                Dim thePath As String = ""
    '                Dim fileName As String
    '                If fileName Is Nothing OrElse fileName.Length = 0 Then
    '                    fileName = "ActionPath"
    '                End If
    '                thePath = ReportPath & Path.DirectorySeparatorChar & fileName & ".xml"
    '                Dim paths As FormPaths
    '                Dim nameForPath As String
    '                nameForPath = "Longkong.Pojjaman.BusinessLogic.ActionPath" & ".Reports"
    '                Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    '                paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, "ActionPath", thePath)), FormPaths)
    '                Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
    '                If dlg.ShowDialog() = DialogResult.OK Then
    '                    thePath = dlg.KeyValuePair.Value
    '                Else
    '                    Return Nothing
    '                End If
    '                If File.Exists(thePath) Then
    '                    Dim df As New AdobeForm.DesignerForm(thePath, Me)
    '                    Return df.PrintDocument
    '                End If
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property CanPrint() As Boolean
    '            Get
    '                Return False
    '            End Get
    '        End Property
    '#End Region

    '#Region "IPrintableEntity"
    '        Public Property Code() As String Implements BusinessLogic.IIdentifiable.Code
    '            Get

    '            End Get
    '            Set(ByVal Value As String)

    '            End Set
    '        End Property

    '        Public Property Id() As Integer Implements BusinessLogic.IIdentifiable.Id
    '            Get

    '            End Get
    '            Set(ByVal Value As Integer)

    '            End Set
    '        End Property

    '        Public Function GetDefaultForm() As String Implements BusinessLogic.IPrintableEntity.GetDefaultForm

    '        End Function

    '        Public Function GetDefaultFormPath() As String Implements BusinessLogic.IPrintableEntity.GetDefaultFormPath

    '        End Function

    '        Public Function GetDocPrintingEntries() As BusinessLogic.DocPrintingItemCollection Implements BusinessLogic.IPrintableEntity.GetDocPrintingEntries
    '            Dim dpiColl As New DocPrintingItemCollection
    '            Dim dpi As DocPrintingItem

    '      Return dpiColl
    '        End Function
    '#End Region





    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

    End Sub

    Private Sub tgitem_CurrentCellStartEditing1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tgitem.CurrentCellStartEditing
      If tgitem.CurrentCell.ColIndex < 3 Then
        e.Cancel = True
      End If
    End Sub
  End Class
End Namespace