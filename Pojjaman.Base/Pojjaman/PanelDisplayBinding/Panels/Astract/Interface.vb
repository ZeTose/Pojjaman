Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Panels
  Public Enum ReportExtentionType
    CrystalReport
    XtraReport
    XMLReport
  End Enum
  Public Interface INewPrintable
    Sub ShowSelectSchemaDataDialog()
  End Interface
  Public Interface IPreAddView
    Property SelectedRow() As DataRow
  End Interface
  Public Interface ISimplePanel
    ReadOnly Property Title() As String
    ReadOnly Property Icon() As String
    Sub ShowInPad()

    Sub SetLabelText()
    Sub UpdateEntityProperties()
    Sub ClearDetail()
    Sub CheckFormEnable()
    Sub Initialize()
  End Interface
  Public Interface ISimpleListEditablePanel
    Inherits ISimpleEntityPanel
    ReadOnly Property List() As IListEditableCollection
  End Interface
  Public Interface IHasTreeTable
    ReadOnly Property TreeTable() As Longkong.Pojjaman.Gui.Components.TreeTable
    ReadOnly Property CanSaveBy() As ICanSaveTreeTable
  End Interface
  Public Interface ISimpleEntityPanel
    Inherits ISimplePanel
    Event EntityPropertyChanged As EventHandler
    Property Entity() As BusinessLogic.ISimpleEntity
  End Interface

  Public Interface IFilterSubPanel
    Inherits IClipboardHandler
    Property Entity() As BusinessLogic.IListable
    Property Entities() As ArrayList
    Function GetFilterString() As String
    Function GetFilterArray() As Filter()
    ReadOnly Property SearchButton() As Button
    Event SearchHandler As EventHandler
  End Interface

  Public Interface IReportFilterSubPanel
    Inherits IFilterSubPanel
    Function GetFixValueCollection() As DocPrintingItemCollection
  End Interface

  Public Interface IExcellExportAble
    Property tgItem As LKGrid
  End Interface

  'Test
End Namespace

