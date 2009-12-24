Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MappingListDialog
        Inherits AbstractEntityDetailPanelView


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
        Friend WithEvents grdMapping As Syncfusion.Windows.Forms.Grid.GridControl
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Dim GridBaseStyle1 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle
            Dim GridBaseStyle2 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle
            Dim GridBaseStyle3 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle
            Dim GridBaseStyle4 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle
            Me.grdMapping = New Syncfusion.Windows.Forms.Grid.GridControl
            CType(Me.grdMapping, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grdMapping
            '
            GridBaseStyle1.Name = "Header"
            GridBaseStyle1.StyleInfo.CellType = "Header"
            GridBaseStyle1.StyleInfo.Font.Bold = True
            GridBaseStyle1.StyleInfo.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
            GridBaseStyle2.Name = "Column Header"
            GridBaseStyle2.StyleInfo.BaseStyle = "Header"
            GridBaseStyle2.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
            GridBaseStyle3.Name = "Row Header"
            GridBaseStyle3.StyleInfo.BaseStyle = "Header"
            GridBaseStyle3.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            GridBaseStyle4.Name = "Standard"
            GridBaseStyle4.StyleInfo.Font.Facename = "Tahoma"
            Me.grdMapping.BaseStylesMap.AddRange(New Syncfusion.Windows.Forms.Grid.GridBaseStyle() {GridBaseStyle1, GridBaseStyle2, GridBaseStyle3, GridBaseStyle4})
            Me.grdMapping.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.grdMapping.ColCount = 4
            Me.grdMapping.DefaultColWidth = 100
            Me.grdMapping.ForeColor = System.Drawing.SystemColors.ControlText
            Me.grdMapping.HorizontalThumbTrack = True
            Me.grdMapping.Location = New System.Drawing.Point(8, 8)
            Me.grdMapping.Name = "grdMapping"
            Me.grdMapping.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.grdMapping.RowCount = 0
            Me.grdMapping.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeAsRangeStylesIntoCode
            Me.grdMapping.Size = New System.Drawing.Size(640, 456)
            Me.grdMapping.SmartSizeBox = False
            Me.grdMapping.TabIndex = 2
            Me.grdMapping.UseRightToLeftCompatibleTextBox = True
            Me.grdMapping.VerticalThumbTrack = True
            '
            'MappingListDialog
            '
            Me.Controls.Add(Me.grdMapping)
            Me.Name = "MappingListDialog"
            Me.Size = New System.Drawing.Size(656, 472)
            CType(Me.grdMapping, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            GetEntity()
        End Sub
#End Region

        Private dpiColl As DocPrintingItemCollection

        Private Sub GetEntity()
            Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow

            If TypeOf window.ActiveViewContent Is IAuxTab Then
        Dim aux As Object = CType(window.ActiveViewContent, IAuxTab).AuxEntity
        If aux Is Nothing Then
          aux = CType(window.ActiveViewContent, IAuxTabItem).AuxEntityItem
        End If
                If TypeOf aux Is IPrintableEntity Then
                    Dim auxPrintable As IPrintableEntity = CType(aux, IPrintableEntity)
                    dpiColl = auxPrintable.GetDocPrintingEntries
                End If
            ElseIf TypeOf window.ActiveViewContent Is ISimpleEntityPanel Then
                Dim myentity As Object = CType(window.ActiveViewContent, ISimpleEntityPanel).Entity
                If TypeOf myentity Is IPrintableEntity Then
                    Dim iprintable As IPrintableEntity = CType(myentity, IPrintableEntity)
                    dpiColl = iprintable.GetDocPrintingEntries
                End If
            End If

            Populate()
        End Sub

        Private Sub Populate()
            If dpiColl Is Nothing Then
                Return
            End If

            Me.grdMapping.Clear(True)
            Me.grdMapping.RowCount = dpiColl.Count
            Me.grdMapping.TableStyle.ReadOnly = True

            Me.grdMapping.ColWidths.SetSize(1, 200)
            Me.grdMapping.ColWidths.SetSize(2, 80)
            Me.grdMapping.ColWidths.SetSize(3, 50)
            Me.grdMapping.ColWidths.SetSize(4, 220)

            Me.grdMapping(0, 1).Text = "Mapping"
            Me.grdMapping(0, 2).Text = "Table"
            Me.grdMapping(0, 3).Text = "Line"
            Me.grdMapping(0, 4).Text = "Value"

            Dim i As Integer = 0
            For Each dpi As DocPrintingItem In dpiColl
                i += 1
                Me.grdMapping(i, 1).Text = dpi.Mapping
                Me.grdMapping(i, 2).Text = CStr(IIf(dpi.Table Is Nothing, "", dpi.Table))
                Me.grdMapping(i, 3).Text = CStr(IIf(dpi.Row <= 0, "", dpi.Row))
                Me.grdMapping(i, 4).Text = CStr(IIf(dpi.Value Is DBNull.Value OrElse dpi.Value Is Nothing, "", dpi.Value))
            Next
        End Sub

    End Class
End Namespace