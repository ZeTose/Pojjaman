Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Namespace Longkong.Pojjaman.BusinessLogic

    Public Class Equipment
        Inherits Asset

#Region "Members"
        Private m_project As Project
        Private m_status As AssetStatus
        Private m_lci As LCIItem
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)

        End Sub
#End Region

#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Equipment"
            End Get
        End Property
        Public Overrides ReadOnly Property TableName() As String
            Get
                Return "asset"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Equipment.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Equipment"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Equipment"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Equipment.ListLabel}"
            End Get
        End Property
        'Public Overrides ReadOnly Property Prefix() As String
        '    Get
        '        Return "equipment"
        '    End Get
        'End Property
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Return "Equipment" & ":" & Me.Code 'Me.ClassName & ":" & Me.Code
            End Get
        End Property
        Public Overrides ReadOnly Property UseSiteConnString() As Boolean
            Get
                Return True
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overloads Overrides Function GetDataset(ByVal query As String, ByVal order As String) As System.Data.DataSet
            Dim ds As DataSet = MyBase.GetDataset(query, order)
            Dim rows As DataRow() = ds.Tables(0).Select("asset_isEquipment=1")
            ds.Tables(0).Rows.Clear()
            For Each row As DataRow In rows
                ds.Tables(0).Rows.Add(row)
                Debug.WriteLine(row.Item(0))
            Next
            Return ds
        End Function
#End Region

#Region "Shared"
        Public Shared Function GetEquipment(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEntity As Equipment) As Boolean
            Dim entity As New Equipment(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not entity.Originated Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                entity = oldEntity
            End If
            txtCode.Text = entity.Code
            txtName.Text = entity.Name
            If oldEntity.Id <> entity.Id Then
                oldEntity = entity
                Return True
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
