Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class PJMModule
        Implements IIdentifiable, IHasName

#Region "Members"
        Private mod_id As Integer
        Private mod_code As String
        Private mod_name As String
        Private mod_activated As Boolean

        Private Shared modHash As Hashtable
#End Region

#Region "Constructors"
        Shared Sub New()
            If modHash Is Nothing OrElse modHash.Count = 0 Then
                RefreshPJMModuleList()
            End If
        End Sub
        Public Sub New()

        End Sub
        Public Sub New(ByVal code As String)
            Me.mod_code = code
            GetPJMModule(code)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                If Not dr.IsNull(aliasPrefix & "mod_code") Then
                    .mod_code = CStr(dr(aliasPrefix & "mod_code"))                    GetPJMModule(.mod_code)                End If
            End With
        End Sub
        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            Me.New(ds.Tables(0).Rows(0), aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Property Id() As Integer Implements IIdentifiable.Id            Get                Return mod_id            End Get            Set(ByVal Value As Integer)                mod_id = Value            End Set        End Property        Public Property Code() As String Implements IIdentifiable.Code            Get                Return mod_code            End Get            Set(ByVal Value As String)                mod_code = Value            End Set        End Property        Public Property Name() As String Implements IHasName.Name            Get                Return mod_name            End Get            Set(ByVal Value As String)                mod_name = Value            End Set        End Property
        Public Property Activated() As Boolean            Get                Return mod_activated            End Get            Set(ByVal Value As Boolean)                mod_activated = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Sub GetPJMModule(ByVal code As String)
            If modHash Is Nothing OrElse modHash.Count = 0 Then
                RefreshPJMModuleList()
            End If
            Me.mod_id = CInt(CType(modHash(code), DataRow).Item("mod_id"))
            Me.mod_name = CStr(CType(modHash(code), DataRow).Item("mod_name"))
            'อาจจะใช้วิธีตรวจสอบแบบอื่นในการบอกว่า Activated หรือยัง
            Me.mod_activated = CBool(CType(modHash(code), DataRow).Item("mod_activated"))
        End Sub
        Public Shared Function GetPJMModuleList() As Hashtable
            If modHash Is Nothing OrElse modHash.Count = 0 Then
                RefreshPJMModuleList()
            End If
            Return modHash
        End Function
        Public Shared Sub RefreshPJMModuleList()
            modHash = New Hashtable
            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select mod_id,mod_code,mod_name,mod_activated from pjmmodule order by mod_code")
            Dim myTable As DataTable = ds.Tables(0)
            For Each row As DataRow In myTable.Rows
                modHash(row("mod_code").ToString.ToLower) = row
            Next
        End Sub
#End Region

    End Class

End Namespace
