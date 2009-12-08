Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class BusinessItem
        Inherits BusinessEntity

#Region "Events"
        Public Event ItemPropertyChanged As ItemPropertyChangeHandler
#End Region

#Region "Metods"
        Protected Sub OnItemPropertyChanged(ByVal e As ItemPropertyChangeEventArgs)
            RaiseEvent ItemPropertyChanged(Me, e)
        End Sub
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal itemReader As IDataReader)
            MyBase.New(itemReader)
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub
#End Region

    End Class

End Namespace