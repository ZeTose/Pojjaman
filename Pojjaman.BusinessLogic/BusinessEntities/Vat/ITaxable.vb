Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Namespace Longkong.Pojjaman.BusinessLogic
    Public Interface IVatable
        Inherits IIdentifiable
        Property [Date]() As Date
        Property Person() As IBillablePerson
    ReadOnly Property NoVat() As Boolean
    Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal
        Property Vat() As Vat
        Function GetAfterTax() As Decimal
        Function GetBeforeTax() As Decimal
    Property TaxBase() As Decimal
    
  End Interface

  Public Interface IHasVat
    Property Taxrate As Decimal
    Property Taxtype As TaxType
  End Interface
    Public Class GenericVatble
        Implements IVatable

#Region "Members"
        Private m_id As Integer
        Private m_code As String
        Private m_date As Date
        Private m_person As IBillablePerson
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal id As Integer, ByVal code As String, ByVal myDate As Date)
            m_id = id
            m_code = code
            m_date = myDate
            m_person = New PersonEntityBase
        End Sub
#End Region

#Region "IWitholdingTaxable"
        Public Property Code() As String Implements IIdentifiable.Code
            Get
                Return m_code
            End Get
            Set(ByVal Value As String)
                m_code = Value
            End Set
        End Property
        Public Property Id() As Integer Implements IIdentifiable.Id
            Get
                Return m_id
            End Get
            Set(ByVal Value As Integer)
                m_id = Value
            End Set
        End Property
        Public Property [Date]() As Date Implements IVatable.Date
            Get
                Return m_date
            End Get
            Set(ByVal Value As Date)
                m_date = Value
            End Set
        End Property
    Public Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal Implements IVatable.GetMaximumTaxBase
      Return Decimal.MaxValue
    End Function
        Public Property Vat() As Vat Implements IVatable.Vat
            Get

            End Get
            Set(ByVal Value As Vat)

            End Set
        End Property
#End Region

        Public Property Person() As IBillablePerson Implements IVatable.Person
            Get
                Return m_person
            End Get
            Set(ByVal Value As IBillablePerson)
                m_person = Value
            End Set
        End Property

        Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax

        End Function

        Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax

        End Function

        Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
            Get
                Return False
            End Get
        End Property

        Public Property TaxBase() As Decimal Implements IVatable.TaxBase
            Get

            End Get
            Set(ByVal Value As Decimal)

            End Set
    End Property
  
    End Class

    Public Interface IWitholdingTaxable
        Inherits IIdentifiable
        Property [Date]() As Date
        Property Person() As IBillablePerson
    Function GetMaximumWitholdingTaxBase() As Decimal
    Property WitholdingTaxCollection() As WitholdingTaxCollection
  End Interface

    Public Interface ICanDelayWHT
    End Interface

    Public Class GenericWitholdingTaxble
        Implements IWitholdingTaxable

#Region "Members"
        Private m_id As Integer
        Private m_code As String
        Private m_date As Date
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal id As Integer, ByVal code As String, ByVal myDate As Date)
            m_id = id
            m_code = code
            m_date = myDate
        End Sub
#End Region

#Region "IWitholdingTaxable"
        Public Property Code() As String Implements IIdentifiable.Code
            Get
                Return m_code
            End Get
            Set(ByVal Value As String)
                m_code = Value
            End Set
        End Property
        Public Property Id() As Integer Implements IIdentifiable.Id
            Get
                Return m_id
            End Get
            Set(ByVal Value As Integer)
                m_id = Value
            End Set
        End Property
        Public Property [Date]() As Date Implements IWitholdingTaxable.Date
            Get
                Return m_date
            End Get
            Set(ByVal Value As Date)
                m_date = Value
            End Set
        End Property
        Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
            Return Decimal.MaxValue
        End Function
        Public Property Person() As IBillablePerson Implements IWitholdingTaxable.Person
            Get

            End Get
            Set(ByVal Value As IBillablePerson)

            End Set
        End Property
        Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
            Get

            End Get
            Set(ByVal Value As WitholdingTaxCollection)

            End Set
        End Property
#End Region

    End Class

End Namespace
