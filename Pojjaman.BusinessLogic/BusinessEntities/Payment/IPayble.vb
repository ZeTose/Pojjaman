Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Interface IPayable
        Inherits IIdentifiable
        Property [Date]() As Date
        Property Note() As String
        'ReadOnly Property DueDate() As Date
        Property DueDate() As Date
        Function RemainingAmount() As Decimal
        Function AmountToPay() As Decimal
        Property Payment() As Payment
        ReadOnly Property Recipient() As IBillablePerson
    End Interface
    Public Class GenericPayable
        Implements IPayable

#Region "Members"
        Private m_id As Integer
        Private m_code As String
        Private m_date As Date
        Private m_note As String
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

#Region "IPayable"
        Public Property Id() As Integer Implements IIdentifiable.Id
            Get
                Return m_id
            End Get
            Set(ByVal Value As Integer)
                m_id = Value
            End Set
        End Property
        Public Property Code() As String Implements IIdentifiable.Code
            Get
                Return m_code
            End Get
            Set(ByVal Value As String)
                m_code = Value
            End Set
        End Property
        Public Property [Date]() As Date Implements IPayable.Date
            Get
                Return m_date
            End Get
            Set(ByVal Value As Date)
                m_date = Value
            End Set
        End Property
        Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay

        End Function
        Public Property Payment() As Payment Implements IPayable.Payment
            Get

            End Get
            Set(ByVal Value As Payment)

            End Set
        End Property
        Public Property DueDate() As Date Implements IPayable.DueDate
            Get

            End Get
            Set(ByVal Value As Date)

            End Set
        End Property
        Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount

        End Function
        Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
            Get

            End Get

        End Property
        Public Property Note() As String Implements IPayable.Note
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property
#End Region

    End Class
    Public Interface IBillAcceptable
        Inherits IPayable
        Function GetRemainingAmountWithBillAcceptance(ByVal billa_id As Integer) As Decimal
        Function GetRemainingAmountPayselection(ByVal pays_id As Integer) As Decimal
        Function GetRemainingAmountPayselection(ByVal pays_id As Integer, ByVal billa_id As Integer) As Decimal
    End Interface
End Namespace
