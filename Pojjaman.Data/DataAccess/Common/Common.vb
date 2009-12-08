Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Xml

Namespace Longkong.Pojjaman.DataAccessLayer

    Public Enum DataBase
        SQLServer
        MSDE
        XML
        Access
    End Enum

    Public Interface IDataAccessHelper

    End Interface
End Namespace