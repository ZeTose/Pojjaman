Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class Province
        Implements IIdentifiable, IHasName

#Region "Members"
        Private province_id As Integer
        Private province_code As String
        Private province_name As String
        Private Shared m_provinceTable As DataTable
#End Region

#Region "Constructors"
        Shared Sub New()
            If m_provinceTable Is Nothing OrElse m_provinceTable.Rows.Count = 0 Then
                RefreshProvinceList()
            End If
        End Sub
        Public Sub New()

        End Sub
        Public Sub New(ByVal id As Integer)
            Me.province_id = id
            Me.province_code = GetProvinceCode(id)
            Me.province_name = GetProvinceName(id)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                If Not dr.IsNull(aliasPrefix & "province_id") Then
                    .province_id = CInt(dr(aliasPrefix & "province_id"))                    .province_code = GetProvinceCode(.province_id)
                    .province_name = GetProvinceName(.province_id)                End If
            End With
        End Sub
        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            Me.New(ds.Tables(0).Rows(0), aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Property Id() As Integer Implements IIdentifiable.Id            Get                Return province_id            End Get            Set(ByVal Value As Integer)                province_id = Value            End Set        End Property        Public Property Code() As String Implements IIdentifiable.Code            Get                Return province_code            End Get            Set(ByVal Value As String)                province_code = Value            End Set        End Property        Public Property Name() As String Implements IHasName.Name            Get                Return province_name            End Get            Set(ByVal Value As String)                province_name = Value            End Set        End Property

#End Region

#Region "Methods"
        Public Shared Function GetProvinceCode(ByVal id As Integer) As String
            If m_provinceTable Is Nothing OrElse m_provinceTable.Rows.Count = 0 Then
                RefreshProvinceList()
            End If
            Dim rows() As DataRow = m_provinceTable.Select("province_id=" & id)
            If rows.Length = 1 Then
                Return CStr(rows(0)("province_code"))
            End If
        End Function
        Public Shared Function GetProvinceName(ByVal id As Integer) As String
            If m_provinceTable Is Nothing OrElse m_provinceTable.Rows.Count = 0 Then
                RefreshProvinceList()
            End If
            Dim rows() As DataRow = m_provinceTable.Select("province_id=" & id)
            If rows.Length = 1 Then
                Return CStr(rows(0)("province_name"))
            End If
        End Function
        Public Shared Function GetProvinceList() As DataTable
            If m_provinceTable Is Nothing OrElse m_provinceTable.Rows.Count = 0 Then
                RefreshProvinceList()
            End If
            Return m_provinceTable
        End Function
        Public Shared Sub ListProvinceInComboBox(ByVal cmb As ComboBox)
            If m_provinceTable Is Nothing OrElse m_provinceTable.Rows.Count = 0 Then
                RefreshProvinceList()
            End If
            cmb.Items.Clear()
            For Each row As DataRow In m_provinceTable.Rows
                Dim id As Integer = CInt(row("province_id"))
                Dim name As String = CStr(row("province_name"))
                Dim idpair As New IdValuePair(id, name)
                'cmb.Items.Add(row("province_name"))
                cmb.Items.Add(idpair)
            Next
        End Sub
        Public Shared Sub RefreshProvinceList()

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select province_id,province_name,province_code from province order by province_code")
            m_provinceTable = ds.Tables(0)
        End Sub
#End Region

    End Class

End Namespace
