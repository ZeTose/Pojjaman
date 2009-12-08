Namespace Longkong.Pojjaman.BusinessLogic
    Public Class SaleDN
        Inherits SimpleBusinessEntityBase
        Implements IHasIBillablePerson


        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "SaleDN"
            End Get
        End Property
        Public Property Customer() As Customer
            Get

            End Get
            Set(ByVal Value As Customer)

            End Set
        End Property

#Region "IHasIBillablePerson"
        Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
            Get
                Return Me.Customer
            End Get
            Set(ByVal Value As IBillablePerson)
                If TypeOf Value Is Customer Then
                    Me.Customer = CType(Value, Customer)
                End If
            End Set
        End Property
#End Region
    End Class
End Namespace
