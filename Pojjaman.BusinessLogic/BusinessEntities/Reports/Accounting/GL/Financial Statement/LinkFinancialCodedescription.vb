Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components

Namespace Longkong.Pojjaman.BusinessLogic


    ' รายงานงบกำไรขาดทุน
    Public Class LinkFinancialProfitList
        Inherits CodeDescription
#Region "Construtors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "profitlost_list"
            End Get
        End Property
#End Region
    End Class

    ' รายงานงบดุล List
    Public Class LinkFinancialBSList
        Inherits CodeDescription
#Region "Construtors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "balancesheet_list"
            End Get
        End Property
#End Region
    End Class



    ' Status 
    Public Class LinkFinancialStatus
        Inherits CodeDescription
#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "fs_status"
            End Get
        End Property
#End Region
    End Class
End Namespace
