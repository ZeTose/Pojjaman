Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Text.RegularExpressions

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class Discount
        Implements IPropertyChangeable

#Region "Members"
        Private m_rate As String = ""
        Private m_amountBeforeDiscount As Decimal
        Public Const RULE As String = "(?<discount>(\+|-)?[0-9][0-9]*(\.[0-9]*)?\s*%{0,1})" '"(?<discount>\d+\s*%{0,1})\s*(,|$)"
        Private m_initialized As Boolean = False
#End Region

#Region "Consructors"
        Public Sub New(ByVal rate As String)
            m_initialized = False
            Me.m_rate = rate
            m_initialized = True
        End Sub
#End Region

#Region "Properties"
        Public Property Rate() As String            Get                Return m_rate            End Get            Set(ByVal Value As String)                m_rate = Value            End Set        End Property        Public Property AmountBeforeDiscount() As Decimal            Get                Return m_amountBeforeDiscount            End Get            Set(ByVal Value As Decimal)                m_amountBeforeDiscount = Value            End Set        End Property        Public ReadOnly Property Amount() As Decimal            Get                Return Me.GetFinalDiscount(Me.m_rate, Me.m_amountBeforeDiscount)
            End Get        End Property
#End Region

#Region "Methods"
        Public Shared Function GetFinalDiscount(ByVal rate As String, ByVal amountB4 As Decimal) As Decimal
            Dim re As New Regex(RULE)
            Dim ar As New ArrayList
            If Not re.IsMatch(rate) And rate <> "" Then
                Return 0
                'Hack
                'Throw New Exception("Incorrect Discount Format")
            End If
            Dim oldAmt As Decimal = amountB4
            For Each m As Match In re.Matches(rate)
                Dim partialRateString As String = m.Groups("discount").Value
                Dim partialRate As Decimal
                If partialRateString.EndsWith("%") Then
                    partialRate = CDec(partialRateString.TrimEnd("%"c).Replace(" ", ""))
                    amountB4 -= (partialRate * amountB4) / 100
                Else
                    partialRate = CDec(partialRateString)
                    amountB4 -= partialRate
                End If
            Next
            Return oldAmt - amountB4
    End Function
    Public Shared Function GetFixDiscount(ByVal rate As String, ByVal amountB4 As Decimal) As Decimal
      Dim re As New Regex(RULE)
      Dim ar As New ArrayList
      If Not re.IsMatch(rate) And rate <> "" Then
        Return 0
        'Hack
        'Throw New Exception("Incorrect Discount Format")
      End If
      Dim oldAmt As Decimal = amountB4
      For Each m As Match In re.Matches(rate)
        Dim partialRateString As String = m.Groups("discount").Value
        Dim partialRate As Decimal
        If Not partialRateString.EndsWith("%") Then
          partialRate = CDec(partialRateString)
          amountB4 -= partialRate
        End If
      Next
      Return oldAmt - amountB4
    End Function
#End Region

#Region "IPropertyChangeable"
        Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements IPropertyChangeable.PropertyChanged
        Public ReadOnly Property Initialized() As Boolean Implements IPropertyChangeable.Initialized
            Get
                Return m_initialized
            End Get
        End Property
#End Region

        Public Overrides Function ToString() As String
            Return Me.Rate & ":" & Me.Amount.ToString
        End Function

    End Class
End Namespace
