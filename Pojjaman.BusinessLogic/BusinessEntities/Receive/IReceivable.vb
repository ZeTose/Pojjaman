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
    Public Class ReceivableItemType
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "ReceivableItemType"
            End Get
        End Property
#End Region

    End Class
    Public Interface IReceivable
        Inherits IIdentifiable
        Property [Date]() As Date
        Property Note() As String
        Property DueDate() As Date
        Function RemainingAmount() As Decimal
        Function AmountToReceive() As Decimal
        Property Receive() As Receive
        ReadOnly Property Payer() As IBillablePerson
    End Interface
    Public Class GenericReceivable
        Implements IReceivable

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
        Public Property [Date]() As Date Implements IReceivable.Date
            Get
                Return m_date
            End Get
            Set(ByVal Value As Date)
                m_date = Value
            End Set
        End Property
        Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive

        End Function
        Public Property DueDate() As Date Implements IReceivable.DueDate
            Get

            End Get
            Set(ByVal Value As Date)

            End Set
        End Property
        Public Function RemainingAmount() As Decimal Implements IReceivable.RemainingAmount

        End Function
        Public ReadOnly Property Payer() As IBillablePerson Implements IReceivable.Payer
            Get

            End Get
        End Property
        Public Property Receive() As Receive Implements IReceivable.Receive
            Get

            End Get
            Set(ByVal Value As Receive)

            End Set
        End Property
#End Region

        Public Property Note() As String Implements IReceivable.Note
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property
    End Class
    Public Interface IBillIssuable
        Inherits ISaleBillIssuable, IPaymentApplicable
    End Interface
    Public Interface ISaleBillIssuable
        Inherits IReceivable
        Function GetRemainingAmountWithBillIssue(ByVal billi_id As Integer) As Decimal
        Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer) As Decimal
        Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer, ByVal billi_id As Integer) As Decimal
    End Interface
End Namespace
