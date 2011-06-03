Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data.Objects
Imports Longkong.Core.Properties
Imports System.IO

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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      'BuilkMatchView
      '
      Me.Name = "BuilkMatchView"
      Me.Size = New System.Drawing.Size(672, 525)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
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
      'InitGrid()
      '
      '      PopulateGrid()

    End Sub
#End Region

#Region "Properties"
    Public Overrides Property TitleName As String
      Get
        Return "Approve Line"
      End Get
      Set(ByVal value As String)
        MyBase.TitleName = value
      End Set
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return "Approve Line" 'Me.m_entity.ListPanelTitle
      End Get
    End Property
#End Region

#Region "Methods"

    'Private Sub InitGrid()


    '  tgItem.ColCount = 22
    '  tgItem.RowCount = 21
    '  'tgItem(1, 1).BackColor = Color.FromArgb(167, 236, 156)
    '  tgItem.Rows.HeaderCount = 2
    '  tgItem.Rows.FrozenCount = 2
    '  tgItem.Cols.HeaderCount = 1
    '  tgItem.Cols.FrozenCount = 1
    '  tgItem.ColWidths(1) = 150
    '  'tgItem.ColWidths(2) = 80
    '  For i As Integer = 2 To tgItem.ColCount
    '    tgItem.ColWidths(i) = 80
    '    tgItem.ColStyles(i).VerticalAlignment = GridVerticalAlignment.Middle
    '    tgItem.ColStyles(i).HorizontalAlignment = GridHorizontalAlignment.Center
    '  Next

    '  tgItem.Model.CoveredRanges.Add(GridRangeInfo.Cells(1, 1, 2, 1))
    '  tgItem.Model.CoveredRanges.Add(GridRangeInfo.Cells(1, 2, 2, 2))
    '  tgItem.Model.CoveredRanges.Add(GridRangeInfo.Cells(1, 3, 1, tgItem.ColCount))

    '  SetGridValue(1, 1, "Document", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(1, 2, "Maker", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)

    '  SetGridValue(1, 3, "Approval Tier", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)

    '  For i As Integer = 3 To 22
    '    SetGridValue(2, i, i - 2, True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  Next

    '  SetGridValue(3, 1, "Budget", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(4, 1, "PR", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(5, 1, "PO", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(6, 1, "Invoice Entry", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(7, 1, "Invoice Summary", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(8, 1, "Other Payment", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(9, 1, "Other Receive", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(10, 1, "Interim Payment Application", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)

    '  SetGridValue(11, 1, "Receive Record", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(12, 1, "Payment Record", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)

    '  SetGridValue(13, 1, "Cash Withdraw", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(14, 1, "Cash Deposit", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(15, 1, "Bank Tranfer", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(16, 1, "Bank Charge", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(17, 1, "Bank Income", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)

    '  SetGridValue(18, 1, "Petty Cash Withdraw", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(19, 1, "Petty Cash Close", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(20, 1, "Adance Money", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
    '  SetGridValue(21, 1, "Journal Entry", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)

    '  tgItem.BackColor = Color.White



    'End Sub


    Private Sub PopulateGrid()


    End Sub

    Private Sub ClearGrid()

    End Sub


    Private Sub SetGridValue(ByVal row As Integer, ByVal col As Integer, ByVal value As String _
, Optional ByVal bold As Boolean = False _
, Optional ByVal hAlign As Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left _
, Optional ByVal vAlign As Syncfusion.Windows.Forms.Grid.GridVerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle)
      'tgItem(row, col).HorizontalAlignment = hAlign
      'tgItem(row, col).VerticalAlignment = vAlign
      'tgItem(row, col).Text = value
      'tgItem(row, col).Font.Bold = bold
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





  End Class
End Namespace