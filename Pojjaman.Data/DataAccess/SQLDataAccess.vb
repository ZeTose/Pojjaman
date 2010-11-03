Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Text.RegularExpressions
Namespace Longkong.Pojjaman.DataAccessLayer

#Region "SqlHelper Class"
  Public NotInheritable Class SqlHelper

#Region "Constructor"
    Private Sub New()
    End Sub
#End Region

#Region "Private Methods"
    '*********************************************************************
    '
    ' This method is used to attach array of SqlParameters to a SqlCommand.
    ' 
    ' This method will assign a value of DbNull to any parameter with a direction of
    ' InputOutput and a value of null.  
    ' 
    ' This behavior will prevent default values from being used, but
    ' this will be the less common case than an intended pure output parameter (derived as InputOutput)
    ' where the user provided no input value.
    ' 
    ' param name="command" The command to which the parameters will be added
    ' param name="commandParameters" an array of SqlParameters tho be added to command
    '
    '*********************************************************************

    Private Shared Sub AttachParameters(ByVal command As SqlCommand, ByVal commandParameters() As SqlParameter)
      Dim p As SqlParameter
      For Each p In commandParameters
        'check for derived output value with no value assigned
        If p.Direction = ParameterDirection.InputOutput And p.Value Is Nothing Then
          p.Value = Nothing
        End If
        command.Parameters.Add(p)
      Next p
    End Sub

    '*********************************************************************
    '
    ' This method assigns an array of values to an array of SqlParameters.
    ' 
    ' param name="commandParameters" array of SqlParameters to be assigned values
    ' param name="parameterValues" array of objects holding the values to be assigned
    '
    '*********************************************************************

    Private Shared Sub AssignParameterValues(ByVal commandParameters() As SqlParameter, ByVal parameterValues() As Object)

      Dim i As Integer
      Dim j As Integer

      If (commandParameters Is Nothing) And (parameterValues Is Nothing) Then
        'do nothing if we get no data
        Return
      End If

      ' we must have the same number of values as we pave parameters to put them in
      If commandParameters.Length <> parameterValues.Length Then
        Throw New ArgumentException("Parameter count does not match Parameter Value count.")
      End If

      'value array
      j = commandParameters.Length - 1
      For i = 0 To j
        commandParameters(i).Value = parameterValues(i)
      Next

    End Sub

    '*********************************************************************
    '
    ' This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
    ' to the provided command.
    ' 
    ' param name="command" the SqlCommand to be prepared
    ' param name="connection" a valid SqlConnection, on which to execute this command
    ' param name="transaction" a valid SqlTransaction, or 'null'
    ' param name="commandType" the CommandType (stored procedure, text, etc.)
    ' param name="commandText" the stored procedure name or T-SQL command
    ' param name="commandParameters" an array of SqlParameters to be associated with the command or 'null' if no parameters are required
    '
    '*********************************************************************

    Private Shared Sub PrepareCommand(ByVal command As SqlCommand, _
                                      ByVal connection As SqlConnection, _
                                      ByVal transaction As SqlTransaction, _
                                      ByVal commandType As CommandType, _
                                      ByVal commandText As String, _
                                      ByVal commandParameters() As SqlParameter)

      'if the provided connection is not open, we will open it
      If connection.State <> ConnectionState.Open Then
        connection.Open()
      End If

      'associate the connection with the command
      command.Connection = connection

      'set the command text (stored procedure name or SQL statement)
      command.CommandText = commandText

      'if we were provided a transaction, assign it.
      If Not (transaction Is Nothing) Then
        command.Transaction = transaction
      End If

      'set the command type
      command.CommandType = commandType

      'attach the command parameters if they are provided
      If Not (commandParameters Is Nothing) Then
        AttachParameters(command, commandParameters)
      End If

      Return
    End Sub

#End Region

#Region "Shared Methods"
    Public Shared CurrentConnString As String
    Public Shared Function GetConnString(ByVal oldConnString As String) As String
      CurrentConnString = ""
      Dim re As New Regex("(Provider\s*=\s*[^;]*;)(.*)")
      Dim mydlg As New MSDASC.DataLinks
      Dim ADOcon As ADODB._Connection = New ADODB.ConnectionClass
      If oldConnString.Length = 0 Then
        ADOcon = CType(mydlg.PromptNew, ADODB._Connection)
      Else
        If re.IsMatch(oldConnString) Then
        Else
          oldConnString = "Provider=SQLOLEDB;" & oldConnString
        End If
        ADOcon.ConnectionString = oldConnString
        mydlg.PromptEdit(CType(ADOcon, ADODB._Connection))
      End If
      If re.IsMatch(ADOcon.ConnectionString) Then
        ADOcon.ConnectionString = re.Replace(ADOcon.ConnectionString, "${2}")
      End If
      CurrentConnString = ADOcon.ConnectionString
      Return CurrentConnString
    End Function
    Public Shared Function GetDBName(ByVal connString As String) As String
      Dim re As New Regex("Initial\sCatalog\s*=\s*(?<dbName>[^;]*)(;|$)")
      If re.IsMatch(connString) Then
        Dim g As Group = re.Match(connString).Groups("dbName")
        Return g.Value
      End If
      Return ""
    End Function
    Public Shared Function GetInstanceName(ByVal connString As String) As String
      Dim re As New Regex("Data\sSource\s*=\s*(?<instanceName>[^;]*)(;|$)")
      If re.IsMatch(connString) Then
        Dim g As Group = re.Match(connString).Groups("instanceName")
        Return g.Value
      End If
      Return ""
    End Function
    Public Shared Function GetUserName(ByVal connString As String) As String
      Dim re As New Regex("User\sId\s*=\s*(?<userName>[^;]*)(;|$)")
      If re.IsMatch(connString) Then
        Dim g As Group = re.Match(connString).Groups("userName")
        Return g.Value
      End If
      Return ""
    End Function
    Public Shared Function GetPassword(ByVal connString As String) As String
      Dim re As New Regex("Password\s*=\s*(?<password>[^;]*)(;|$)")
      If re.IsMatch(connString) Then
        Dim g As Group = re.Match(connString).Groups("password")
        Return g.Value
      End If
      Return ""
    End Function
    Public Shared Function Backup(ByVal fileName As String) As Boolean

      Dim uid As String = GetUserName(CurrentConnString)
      Dim password As String = GetPassword(CurrentConnString)
      Dim dbName As String = GetDBName(CurrentConnString)
      Dim instance As String = GetInstanceName(CurrentConnString)

      Dim oSQLServer As New SQLDMO.SQLServer
      Dim oBackup As New SQLDMO.Backup
      Try
        With oBackup
          .Initialize = True
          .Files = fileName
          .Database = dbName
          .BackupSetName = dbName & "Bakup"
          .BackupSetDescription = "Manually Backup"
          If uid.Length > 0 And password.Length = 0 Then
            oSQLServer.Connect(instance, uid)
          ElseIf uid.Length = 0 Then
            oSQLServer.LoginSecure = True
            oSQLServer.Connect(instance)
          Else
            oSQLServer.Connect(instance, uid, password)
          End If
          .SQLBackup(oSQLServer)
        End With
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
        Return False
      End Try
      Return True
    End Function
    Public Shared Function Restore(ByVal fileName As String) As Boolean
      Dim oSQLServer As New SQLDMO.SQLServer
      Dim oRestore As New SQLDMO.Restore

      Dim uid As String = GetUserName(CurrentConnString)
      Dim password As String = GetPassword(CurrentConnString)
      Dim dbName As String = GetDBName(CurrentConnString)
      Dim instance As String = GetInstanceName(CurrentConnString)

      Try
        With oRestore
          .Files = fileName
          .Database = dbName
          .ReplaceDatabase = True
          If uid.Length > 0 And password.Length = 0 Then
            oSQLServer.Connect(instance, uid)
          ElseIf uid.Length = 0 Then
            oSQLServer.LoginSecure = True
            oSQLServer.Connect(instance)
          Else
            oSQLServer.Connect(instance, uid, password)
          End If
          .SQLRestore(oSQLServer)
        End With
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
        Return False
      End Try
      Return True
    End Function
    Public Shared Function CleanSQL(ByVal txt As String) As String
      Return txt.Replace("'", "''")
    End Function
    Private Shared CurrentVersion As String = ""
    Public Shared Function GetVersion() As String
      If CurrentVersion = "" Then
        If CheckObjectExist("GetPJMVersion") Then
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
          CurrentConnString _
          , CommandType.StoredProcedure _
          , "GetPJMVersion" _
          )
          CurrentVersion = CStr(ds.Tables(0).Rows(0)(0))
        Else
          CurrentVersion = "0"
        End If
      End If
      Return CurrentVersion
    End Function
    Private Shared CurrentRealVersion As String = ""
    Public Shared Function GetRealVersion() As String
      If CurrentRealVersion = "" Then
        If CheckObjectExist("GetPJMVersion") Then
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
          CurrentConnString _
          , CommandType.StoredProcedure _
          , "GetPJMRealVersion" _
          )
          CurrentRealVersion = CStr(ds.Tables(0).Rows(0)(0))
        Else
          Return GetVersion()
        End If
      End If
      Return CurrentRealVersion
    End Function
    Public Shared Function CheckObjectExist(ByVal objectName As String) As Boolean
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset(CurrentConnString, CommandType.Text, _
        "select * from dbo.sysobjects where id = object_id(N'[dbo].[" & objectName & "]') ")
        If ds.Tables.Count > 0 Then
          If ds.Tables(0).Rows.Count > 0 Then
            Return True
          End If
        End If
        Return False
      Catch ex As Exception
        Return False
      End Try
    End Function
    Public Shared Function IsCompatible(ByVal pjmVersion As String, ByVal dbVersion As String) As Boolean
      If pjmVersion = dbVersion Then
        Return True
      End If
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
       CurrentConnString _
       , CommandType.StoredProcedure _
       , "GetCompatibility" _
       , New SqlParameter("@pjmVersion", pjmVersion) _
       , New SqlParameter("@dbVersion", dbVersion) _
       )
        If ds.Tables(0).Rows.Count > 0 Then
          Return True
        End If
      Catch ex As Exception
      End Try
      Return False
    End Function
    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
    ' using the provided parameters.
    '
    ' e.g.:  
    '  dim result as integer = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24))
    '
    ' param name="connectionString" a valid connection string for a SqlConnection
    ' param name="commandType" the CommandType (stored procedure, text, etc.)
    ' param name="commandText" the stored procedure name or T-SQL command
    ' param name="commandParameters" an array of SqlParamters used to execute the command
    ' returns an int representing the number of rows affected by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As Integer
      'create & open a SqlConnection, and dispose of it after we are done.
      Dim cn As New SqlConnection(connectionString)
      Try
        cn.Open()

        'call the overload that takes a connection in place of the connection string
        Return ExecuteNonQuery(cn, commandType, commandText, commandParameters)
      Finally
        cn.Dispose()
      End Try
    End Function

    '*********************************************************************
    '
    ' Execute a stored procedure via a SqlCommand (that returns no resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' 
    ' This method provides no access to output parameters or the stored procedure's return value parameter.
    ' 
    ' e.g.:  
    '  int result = ExecuteNonQuery(connString, "PublishOrders", 24, 36);
    '
    ' param name="connectionString" a valid connection string for a SqlConnection
    ' param name="spName" the name of the stored prcedure
    ' param name="parameterValues" an array of objects to be assigned as the input values of the stored procedure
    ' returns an int representing the number of rows affected by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                     ByVal spName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer
      Dim commandParameters As SqlParameter()

      'if we receive parameter values, we need to figure out where they go
      If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
        'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)

        commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

        'assign the provided values to these parameters based on parameter order
        AssignParameterValues(commandParameters, parameterValues)

        'call the overload that takes an array of SqlParameters
        Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        'otherwise we can just call the SP without params
      Else
        Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName)
      End If
    End Function

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns no resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    ' 
    ' param name="connection" a valid SqlConnection 
    ' param name="commandType" the CommandType (stored procedure, text, etc.) 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters used to execute the command 
    ' returns an int representing the number of rows affected by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As Integer

      'create a command and prepare it for execution
      Dim cmd As New SqlCommand
      Dim retval As Integer

      PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

      'finally, execute the command.
      retval = cmd.ExecuteNonQuery()

      'detach the SqlParameters from the command object, so they can be used again
      cmd.Parameters.Clear()

      Return retval

    End Function
    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns no resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    ' 
    ' param name="connection" a valid SqlConnection 
    ' param name="commandType" the CommandType (stored procedure, text, etc.) 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters used to execute the command 
    ' returns an int representing the number of rows affected by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                    ByVal trans As SqlTransaction, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As Integer

      'create a command and prepare it for execution
      Dim cmd As New SqlCommand
      Dim retval As Integer

      PrepareCommand(cmd, connection, trans, commandType, commandText, commandParameters)

      'finally, execute the command.
      retval = cmd.ExecuteNonQuery()

      'detach the SqlParameters from the command object, so they can be used again
      cmd.Parameters.Clear()

      Return retval

    End Function

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="commandType" the CommandType (stored procedure, text, etc.) 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters used to execute the command 
    ' returns a dataset containing the resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet

      '=======================CHECKING IF DB EXIESTS=================================
      Dim tmpCN As New SqlConnection(connectionString & ";Connection Timeout=5")
      Try
        tmpCN.Open()
      Catch ex As Exception
        Throw ex
      Finally
        tmpCN.Dispose()
      End Try
      '=======================CHECKING IF DB EXIESTS=================================

      'create & open a SqlConnection, and dispose of it after we are done.
      Dim cn As New SqlConnection(connectionString & ";Connection Timeout=300")
      Try

        Try
          cn.Open()
        Catch ex As Exception
          Throw ex
        End Try

        'call the overload that takes a connection in place of the connection string

        Return ExecuteDataset(cn, commandType, commandText, commandParameters)
      Catch ex As Exception
        Throw ex
      Finally
        cn.Dispose()
      End Try
    End Function

    '*********************************************************************
    '
    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' 
    ' This method provides no access to output parameters or the stored procedure's return value parameter.
    ' 
    ' e.g.:  
    '  DataSet ds = ExecuteDataset(connString, "GetOrders", 24, 36);
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection
    ' param name="spName" the name of the stored procedure
    ' param name="parameterValues" an array of objects to be assigned as the input values of the stored procedure
    ' returns a dataset containing the resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                    ByVal spName As String, _
                                                    ByVal ParamArray parameterValues() As Object) As DataSet

      Dim commandParameters As SqlParameter()

      'if we receive parameter values, we need to figure out where they go
      If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
        'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
        commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

        'assign the provided values to these parameters based on parameter order
        AssignParameterValues(commandParameters, parameterValues)

        'call the overload that takes an array of SqlParameters
        Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        'otherwise we can just call the SP without params
      Else
        Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName)
      End If
    End Function

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
    '
    ' param name="connection" a valid SqlConnection
    ' param name="commandType" the CommandType (stored procedure, text, etc.)
    ' param name="commandText" the stored procedure name or T-SQL command
    ' param name="commandParameters" an array of SqlParamters used to execute the command
    ' returns a dataset containing the resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet

      'create a command and prepare it for execution
      Dim cmd As New SqlCommand
      Dim ds As New DataSet
      Dim da As SqlDataAdapter

      PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

      cmd.CommandTimeout = 600
      'create the DataAdapter & DataSet
      da = New SqlDataAdapter(cmd)

      'fill the DataSet using default values for DataTable names, etc.

      Dim t As Date = Now
      Try
        da.Fill(ds)

        'detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        'return the dataset
      Catch ex As Exception
        Throw ex
        'MessageBox.Show(commandText & ":" & DateDiff(DateInterval.Second, t, Now).ToString & ":" & ex.ToString)
      End Try
      Return ds

    End Function
    Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                ByVal transaction As SqlTransaction, _
                ByVal commandType As CommandType, _
                ByVal commandText As String, _
                ByVal ParamArray commandParameters() As SqlParameter) As DataSet

      'create a command and prepare it for execution
      Dim cmd As New SqlCommand
      Dim ds As New DataSet
      Dim da As SqlDataAdapter

      PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters)

      cmd.CommandTimeout = 600
      'create the DataAdapter & DataSet
      da = New SqlDataAdapter(cmd)

      'fill the DataSet using default values for DataTable names, etc.

      Dim t As Date = Now
      Try
        da.Fill(ds)

        'detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        'return the dataset
      Catch ex As Exception
        Throw ex
        'MessageBox.Show(commandText & ":" & DateDiff(DateInterval.Second, t, Now).ToString & ":" & ex.ToString)
      End Try
      Return ds

    End Function


    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns a 1x1 resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="commandType" the CommandType (stored procedure, text, etc.) 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters used to execute the command 
    ' returns an object containing the value in the 1x1 resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
          ByVal commandType As CommandType, _
          ByVal commandText As String, _
          ByVal ParamArray commandParameters() As SqlParameter) As Object
      'create & open a SqlConnection, and dispose of it after we are done.
      Dim cn As New SqlConnection(connectionString)
      Try
        cn.Open()

        'call the overload that takes a connection in place of the connection string
        Return ExecuteScalar(cn, commandType, commandText, commandParameters)
      Finally
        cn.Dispose()
      End Try
    End Function

    '*********************************************************************
    '
    ' Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' 
    ' This method provides no access to output parameters or the stored procedure's return value parameter.
    ' 
    ' e.g.:  
    '  int orderCount = (int)ExecuteScalar(connString, "GetOrderCount", 24, 36);
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="spName" the name of the stored procedure 
    ' param name="parameterValues" an array of objects to be assigned as the input values of the stored procedure 
    ' returns an object containing the value in the 1x1 resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
          ByVal spName As String, _
          ByVal ParamArray parameterValues() As Object) As Object
      Dim commandParameters As SqlParameter()

      'if we receive parameter values, we need to figure out where they go
      If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
        'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
        commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

        'assign the provided values to these parameters based on parameter order
        AssignParameterValues(commandParameters, parameterValues)

        'call the overload that takes an array of SqlParameters
        Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        'otherwise we can just call the SP without params
      Else
        Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName)
      End If
    End Function

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
    ' 
    ' param name="connection" a valid SqlConnection 
    ' param name="commandType" the CommandType (stored procedure, text, etc.) 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters used to execute the command 
    ' returns an object containing the value in the 1x1 resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
          ByVal commandType As CommandType, _
          ByVal commandText As String, _
          ByVal ParamArray commandParameters() As SqlParameter) As Object
      'create a command and prepare it for execution
      Dim cmd As New SqlCommand
      Dim retval As Object

      PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

      'execute the command & return the results
      retval = cmd.ExecuteScalar()

      'detach the SqlParameters from the command object, so they can be used again
      cmd.Parameters.Clear()

      Return retval

    End Function
#End Region

  End Class
#End Region

#Region "SqlHelperParameterCache"

  '*********************************************************************
  '
  ' SqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
  ' ability to discover parameters for stored procedures at run-time.
  '
  '*********************************************************************

  Public NotInheritable Class SqlHelperParameterCache

    '*********************************************************************
    '
    ' Since this class provides only static methods, make the default constructor private to prevent 
    ' instances from being created with "new SqlHelperParameterCache()".
    '
    '*********************************************************************

    Private Sub New()
    End Sub

    Private Shared paramCache As Hashtable = Hashtable.Synchronized(New Hashtable)

    '*********************************************************************
    '
    ' resolve at run time the appropriate set of SqlParameters for a stored procedure
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="spName" the name of the stored procedure 
    ' param name="includeReturnValueParameter" whether or not to include their return value parameter 
    '
    '*********************************************************************

    Private Shared Function DiscoverSpParameterSet(ByVal connectionString As String, _
                                                   ByVal spName As String, _
                                                   ByVal includeReturnValueParameter As Boolean, _
                                                   ByVal ParamArray parameterValues() As Object) As SqlParameter()

      Dim cn As New SqlConnection(connectionString)
      Dim cmd As SqlCommand = New SqlCommand(spName, cn)
      Dim discoveredParameters() As SqlParameter

      Try
        cn.Open()
        cmd.CommandType = CommandType.StoredProcedure
        SqlCommandBuilder.DeriveParameters(cmd)
        If Not includeReturnValueParameter Then
          cmd.Parameters.RemoveAt(0)
        End If

        discoveredParameters = New SqlParameter(cmd.Parameters.Count - 1) {}
        cmd.Parameters.CopyTo(discoveredParameters, 0)
      Finally
        cmd.Dispose()
        cn.Dispose()

      End Try

      Return discoveredParameters

    End Function

    'deep copy of cached SqlParameter array
    Private Shared Function CloneParameters(ByVal originalParameters() As SqlParameter) As SqlParameter()

      Dim i As Integer
      Dim j As Integer = originalParameters.Length - 1
      Dim clonedParameters(j) As SqlParameter

      For i = 0 To j
        clonedParameters(i) = CType(CType(originalParameters(i), ICloneable).Clone, SqlParameter)
      Next

      Return clonedParameters
    End Function

    '*********************************************************************
    '
    ' add parameter array to the cache
    '
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters to be cached 
    '
    '*********************************************************************

    Public Shared Sub CacheParameterSet(ByVal connectionString As String, _
                                        ByVal commandText As String, _
                                        ByVal ParamArray commandParameters() As SqlParameter)
      Dim hashKey As String = connectionString + ":" + commandText

      paramCache(hashKey) = commandParameters
    End Sub

    '*********************************************************************
    '
    ' Retrieve a parameter array from the cache
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' returns an array of SqlParamters
    '
    '*********************************************************************

    Public Shared Function GetCachedParameterSet(ByVal connectionString As String, ByVal commandText As String) As SqlParameter()
      Dim hashKey As String = connectionString + ":" + commandText
      Dim cachedParameters As SqlParameter() = CType(paramCache(hashKey), SqlParameter())

      If cachedParameters Is Nothing Then
        Return Nothing
      Else
        Return CloneParameters(cachedParameters)
      End If
    End Function

    '*********************************************************************
    '
    ' Retrieves the set of SqlParameters appropriate for the stored procedure
    ' 
    ' This method will query the database for this information, and then store it in a cache for future requests.
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="spName" the name of the stored procedure 
    ' returns an array of SqlParameters
    '
    '*********************************************************************

    Public Overloads Shared Function GetSpParameterSet(ByVal connectionString As String, ByVal spName As String) As SqlParameter()
      Return GetSpParameterSet(connectionString, spName, False)
    End Function

    '*********************************************************************
    '
    ' Retrieves the set of SqlParameters appropriate for the stored procedure
    ' 
    ' This method will query the database for this information, and then store it in a cache for future requests.
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="spName" the name of the stored procedure 
    ' param name="includeReturnValueParameter" a bool value indicating whether the return value parameter should be included in the results 
    ' returns an array of SqlParameters
    '
    '*********************************************************************

    Public Overloads Shared Function GetSpParameterSet(ByVal connectionString As String, _
                                                       ByVal spName As String, _
                                                       ByVal includeReturnValueParameter As Boolean) As SqlParameter()

      Dim cachedParameters() As SqlParameter
      Dim hashKey As String

      hashKey = connectionString + ":" + spName
      If includeReturnValueParameter = True Then
        hashKey = hashKey + ":include ReturnValue Parameter"
      End If

      cachedParameters = CType(paramCache(hashKey), SqlParameter())

      If (cachedParameters Is Nothing) Then
        paramCache(hashKey) = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter)
        cachedParameters = CType(paramCache(hashKey), SqlParameter())

      End If

      Return CloneParameters(cachedParameters)

    End Function
  End Class
#End Region

End Namespace