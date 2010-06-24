Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Data.SqlClient

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AccountBaseDate
    Inherits SimpleBusinessEntityBase


    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AccountBaseDate"
      End Get
    End Property

    Public Shared Function GetBaseDateFromDB() As Date
      Dim ds As DataSet = SqlHelper.ExecuteDataset( _
               RecentCompanies.CurrentCompany.ConnectionString _
               , CommandType.StoredProcedure _
               , "GetAccountBaseDate" _
               )
      Return CDate(ds.Tables(0).Rows(0)(0))
    End Function
  End Class
End Namespace
