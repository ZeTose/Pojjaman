Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Namespace Longkong.Pojjaman.BusinessLogic
    Public MustInherit Class Person
        Inherits BusinessEntity

#Region "Members"
        Private m_id As Integer
        Private m_code As String
        Private m_name As String
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub
        Public Sub New(ByVal reader As IDataReader)
            MyBase.New(reader)
        End Sub
        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            m_code = ""
            m_name = ""
        End Sub
#End Region

#Region "Properties"
        Public Overrides Property Id() As Integer            Get                Return m_id            End Get            Set(ByVal Value As Integer)                m_id = Value            End Set        End Property        Public Overrides Property Code() As String            Get                Return m_code            End Get            Set(ByVal Value As String)                m_code = Value            End Set        End Property        Public Overrides Property Name() As String            Get                Return m_name            End Get            Set(ByVal Value As String)                m_name = Value            End Set        End Property        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Person"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Person.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Person"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Person"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Person.ListLabel}"
            End Get
        End Property#End Region

        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "person"
            End Get
        End Property
    End Class
End Namespace