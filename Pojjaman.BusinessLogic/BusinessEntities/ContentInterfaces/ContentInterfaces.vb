Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class SaveErrorException
    Inherits Exception

#Region "Members"
    Private m_params As String()
#End Region

#Region "Constructors"
    Public Sub New(ByVal message As String, ByVal ParamArray myParams As String())
      MyBase.New(message)
      ReDim m_params(myParams.Length - 1)
      For i As Integer = 0 To myParams.Length - 1
        m_params(i) = myParams(i)
      Next
    End Sub
    Public Sub New(ByVal message As String)
      MyBase.New(message)
    End Sub
#End Region

#Region "Properties"
    Public Property Params() As String()      Get        Return m_params      End Get      Set(ByVal Value As String())        m_params = Value      End Set    End Property
#End Region

  End Class
  Public Interface IAbleHideCostByView
    ReadOnly Property HideCost As Boolean
  End Interface
  Public Interface ICanSaveTreeTable
    Function SaveTreeTable(ByVal tt As Longkong.Pojjaman.Gui.Components.TreeTable) As SaveErrorException
  End Interface
  Public Interface IForceListDialog
  End Interface
  Public Interface IDirtyAble
    Property IsDirty() As Boolean
  End Interface
  Public Interface IHasConditionBeforeAdding
    ReadOnly Property ControlName() As String
  End Interface
  Public Interface IHasGroup
    ReadOnly Property Group() As ISimpleEntity
  End Interface
  Public Interface IHasToCostCenter
    Property ToCC() As CostCenter
  End Interface
  Public Interface IHasFromCostCenter
    Property FromCC() As CostCenter
  End Interface
  Public Interface IHasIBillablePerson
    Property BillablePerson() As IBillablePerson
  End Interface
  Public Interface IDuplicable
    Function GetNewEntity() As Object
  End Interface
  Public Interface IApprovAble
    Function ApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException
    Function UnApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException
    ReadOnly Property IsApproved() As Boolean
    ReadOnly Property ApproveIcon() As String
    ReadOnly Property UnApproveIcon() As String
    ReadOnly Property ShowUnApproveButton() As Boolean
    ReadOnly Property AmountToApprove() As Decimal
  End Interface
  Public Interface IHasStatusString
    ReadOnly Property StatusString As String
  End Interface
  Public Interface IApprovableByFlow
    ReadOnly Property ApprovalAmount As Decimal
  End Interface
  Public Interface ICancelable
    Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException
    ReadOnly Property CanCancel() As Boolean
  End Interface
  Public Interface IDeletable
    Function Delete() As SaveErrorException
    ReadOnly Property CanDelete() As Boolean
  End Interface
  Public Interface IDeletableWithLog
    Inherits IDeletable
    Function DeleteWithLog(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException
  End Interface
  Public Interface IHasAccountBook
    Property AccountBook() As AccountBook
  End Interface
  Public Interface IHasAmount
    Inherits IIdentifiable
    Property Amount() As Decimal
  End Interface
  Public Interface IReceiveItem
    Inherits IHasAmount
    ReadOnly Property CreateDate As Nullable(Of Date)
  End Interface
  Public Interface IPaymentItem
    Inherits IHasAmount
    Property DueDate() As Date
    ReadOnly Property CreateDate As Nullable(Of Date)
  End Interface
  Public Interface IDatabaseEntity
    Inherits IDeletable
    ReadOnly Property TableName() As String
    ReadOnly Property GetSprocName() As String
    ReadOnly Property GetListSprocName() As String
    ReadOnly Property SaveSprocName() As String
    ReadOnly Property Prefix() As String

    Function Save() As SaveErrorException
    Function Save(ByVal currentUserId As Integer) As SaveErrorException
    Function Save(ByVal currentUserId As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
  End Interface
  Public Interface IExtender
    Function Delete(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
    Function Save(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
  End Interface

  Public Interface IListable
    ReadOnly Property Columns() As ColumnCollection
    Function GetListDatatable(ByVal query As String, ByVal order As String) As DataTable
    Function GetListDatatable(ByVal order As String, ByVal ParamArray filters As Filter()) As DataTable
    Function GetListDataSet(ByVal order As String, ByVal ParamArray filters As Filter()) As DataSet
    Function GeDatatable() As Longkong.Pojjaman.Gui.Components.TreeTable
  End Interface

  'มีสถานะต่างๆ (ใน Database)
  Public Interface IBaseEntityStatusCapable
    ReadOnly Property Originated() As Boolean
    Property OriginDate() As Date
    Property Originator() As User
    Property Edited() As Boolean
    Property LastEditDate() As Date
    Property LastEditor() As User
    Property Canceled() As Boolean
    Property CancelDate() As Date
    Property CancelPerson() As User
  End Interface
  'มี Id,Code
  Public Interface IIdentifiable
    Property Id() As Integer
    Property Code() As String
  End Interface

  Public Interface IDescripable
    Property id As Integer
    Property name As String
    Property desc As String
  End Interface
  Public Interface IHasName
    Inherits IIdentifiable
    Property Name() As String
  End Interface

  Public Interface IHasNote
    Property Note() As String
  End Interface

  Public Interface IMultiName
    Inherits IHasName
    Property AlternateName() As String
  End Interface

  Public Interface IHasImage
    Property Image() As Image
  End Interface

  Public Interface IHasBankAccount
    Property BankAccount() As BankAccount
  End Interface
  Public Interface IHasAccount
    Property Account() As Account
  End Interface

  Public Interface ICodeGeneratable
    Property AutoGen() As Boolean
    Function GetNextCode() As String
    Function GetLastCode(ByVal prefixPattern As String) As String
  End Interface

  Public Interface IBillablePerson
    Inherits IHasName
    Property Address() As String
    Property Province() As String
    Property BillingAddress() As String
    Property Phone() As String
    Property Mobile() As String
        Property Fax() As String
        Property FaxforExport() As String
    Property EmailAddress() As String
    Property HomePage() As String
    Property TaxId() As String
    Property IdNo() As String
    Property TaxRate() As Decimal
    Property DetailDiscount() As Discount
    Property SummaryDiscount() As Discount
    Property PersonType() As BusinessPersonType
    Property Contact() As String
  End Interface
  Public Class BusinessPersonType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal value As Integer)
      MyBase.new(value)
    End Sub
#End Region

    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "person_type"
      End Get
    End Property

  End Class

  'มี status 
  Public Interface IHasStatus
    Property Status() As CodeDescription
  End Interface
  'สามารถสร้างได้....
  Public Interface IObjectReflectable
    ReadOnly Property EntityId() As Integer
    ReadOnly Property [Namespace]() As String
    ReadOnly Property ClassName() As String
    ReadOnly Property FullClassName() As String
    ReadOnly Property FullClassNameForSecurity() As String
  End Interface

  Public Interface IPageInfoCapable
    ReadOnly Property ListPanelIcon() As String
    ReadOnly Property ListPanelTitle() As String
    ReadOnly Property DetailPanelIcon() As String
    ReadOnly Property DetailPanelTitle() As String
    Property MenuLabel As String
    ReadOnly Property TabPageText() As String
    Event TabPageTextChanged As EventHandler
  End Interface

  Public Interface ILocatable
    Property Map() As Image
    Property MapPosition() As Point
  End Interface

  Public Interface IItemEntity
    'คือ Entity ที่สามารถเป็น item ในเอกสารได้ เช่น LCI,Tool,F/A,Blank Item
    Inherits IHasName

  End Interface
  Public Interface IHasEntityList
    ReadOnly Property EntityList As List(Of ISimpleEntity)
    ReadOnly Property CurrentUserId As Integer
  End Interface
  Public Interface ISimpleEntity
    Inherits IBaseEntityStatusCapable, IIdentifiable _
    , IHasStatus, IDatabaseEntity, IObjectReflectable _
    , IPageInfoCapable, IListable
    ReadOnly Property CodonName() As String
    Function GetNumberOfPrinting() As Integer
  End Interface
  'Public Interface ICanEditList
  '    Inherits ISimpleEntity
  '    Property List() As IListEditableCollection
  'End Interface
  Public Interface IPJMUpdatable
    Property PJMID() As Integer
  End Interface
  Public Interface ILCIGroupable
    Inherits ISimpleEntity
    Property LCI() As LCIItem
  End Interface

  Public Interface IPropertyChangeable
    ReadOnly Property Initialized() As Boolean
    Event PropertyChanged As PropertyChangedHandler
  End Interface

  Public Delegate Sub PropertyChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

  Public Class PropertyChangedEventArgs
    Inherits EventArgs

#Region "Members"
    Private m_name As String
    Private m_oldValue As Object
    Private m_value As Object
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal name As String, ByVal value As Object, ByVal oldValue As Object)
      MyBase.New()
      m_name = name
      m_value = value
      m_oldValue = oldValue
    End Sub
#End Region

#Region "Properties"
    Public Property Name() As String
      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
      End Set
    End Property
    Public Property Value() As Object
      Get
        Return m_value
      End Get
      Set(ByVal Value As Object)
        m_value = Value
      End Set
    End Property
    Public Property OldValue() As Object
      Get
        Return m_oldValue
      End Get
      Set(ByVal Value As Object)
        m_oldValue = Value
      End Set
    End Property
#End Region

  End Class

  Public Interface IHasUnit
    Property DefaultUnit() As Unit
    Property MemoryUnit() As Unit
  End Interface

  Public Interface IHasPrice
    Property Price() As Decimal
  End Interface

  'Public Interface IPropertyChangeable
  '    Event PropertyChanged As EventHandler
  'End Interface

  Public Interface IHasGL

  End Interface

  Public Interface IHasPayment

  End Interface

  Public Interface IListEditableCollection
    Sub RefreshDataSet(ByVal filters() As Filter)
    Sub ColumnChanged(ByVal sende As Object, ByVal e As DataColumnChangeEventArgs)
    Sub ColumnChanging(ByVal sende As Object, ByVal e As DataColumnChangeEventArgs)
    Sub RowDeleted(ByVal sende As Object, ByVal e As DataRowChangeEventArgs)
    Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
    Function Save(ByVal currentUserId As Integer) As SaveErrorException
    Function CreateTableStyle() As DataGridTableStyle
    ReadOnly Property Dataset() As DataSet
    ReadOnly Property SprocName() As String
    ReadOnly Property TableName() As String
    Property Owner() As ISimpleEntity
  End Interface

  Public Delegate Sub ColumnChangedHandler(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
  Public Delegate Sub RowChangedHandler(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)

  Public Interface IExportEntityDetail
    Property ExportEntity As ExportEntity
  End Interface

End Namespace
