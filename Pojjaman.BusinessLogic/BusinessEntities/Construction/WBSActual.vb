Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class WBSActual

    '-- PR View --------------------------------------------------------------------------------
    Public Shared Function SummaryPRWBSActual(ByVal conn As SqlConnection) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "swang_UpdateTempPRWBSActual")
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Public Shared Function SummaryWRWBSActual(ByVal conn As SqlConnection) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "swang_UpdateTempWRWBSActual")
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Public Shared Function SummaryPRAdjWBSActual(ByVal conn As SqlConnection) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "swang_UpdateTempPRAdjWBSActual")
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Public Shared Function SummaryChildActual(ByVal conn As SqlConnection, view As String) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "swang_UpdateChildActual", New SqlParameter("@viewname", view))
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function
    '-- PR View --------------------------------------------------------------------------------


    '-- PO View --------------------------------------------------------------------------------
    Public Shared Function SummaryPOWBSActual(ByVal conn As SqlConnection) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "swang_UpdateTempPOWBSActual")
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Public Shared Function SummarySCWBSActual(ByVal conn As SqlConnection) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "swang_UpdateTempSCWBSActual")
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Public Shared Function SummaryVOWBSActual(ByVal conn As SqlConnection) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "swang_UpdateTempVOWBSActual")
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Public Shared Function SummaryPOAdjWBSActual(ByVal conn As SqlConnection) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "swang_UpdateTempPOAdjWBSActual")
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function

    Public Shared Function SummaryDRWBSActual(ByVal conn As SqlConnection) As SaveErrorException
      Dim newcon As New SqlConnection(conn.ConnectionString)
      newcon.Open()
      Dim trans As SqlTransaction = newcon.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(newcon, trans, CommandType.StoredProcedure, "swang_UpdateTempDRWBSActual")
      Catch ex As Exception
        trans.Rollback()
        newcon.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      newcon.Close()
      Return New SaveErrorException("0")
    End Function
    '-- PO View --------------------------------------------------------------------------------------------

  End Class
End Namespace

