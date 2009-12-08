Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports Longkong.Core.Services
Imports System.Configuration
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class StockItemBase
        Inherits SimpleBusinessEntityBase
        Implements IMultiName, IHasImage

#Region "Members"
        Private m_name As String
        Private m_alternateName As String
        Private m_image As Image
        Private m_defaultUnit As Unit
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
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            MyBase.New(ds, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            Me.m_defaultUnit = New Unit
            Try
                Me.m_image = Image.FromFile(StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Entity.BlankImage}"))
            Catch ex As Exception

            End Try
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_altName") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_altName") Then
                    .m_alternateName = CStr(dr(aliasPrefix & Me.Prefix & "_altName"))
                End If
                If dr.Table.Columns.Contains("unit_id") Then
                    If Not dr.IsNull("unit_id") Then
                        .m_defaultUnit = New Unit(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_defaultunit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_defaultunit") Then
                        .m_defaultUnit = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_defaultunit")))
                    End If
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property DefaultUnit() As Unit            Get                Return m_defaultUnit            End Get            Set(ByVal Value As Unit)                m_defaultUnit = Value            End Set        End Property
#End Region

#Region "IMultiName"
        Public Property Name() As String Implements IHasName.Name
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property
        Public Property AlternateName() As String Implements IMultiName.AlternateName
            Get
                Return m_alternateName
            End Get
            Set(ByVal Value As String)
                m_alternateName = Value
            End Set
        End Property
#End Region

#Region "IHasImage"
        Public Property Image() As System.Drawing.Image Implements IHasImage.Image
            Get
                Return m_image
            End Get
            Set(ByVal Value As System.Drawing.Image)
                m_image = Value
            End Set
        End Property
#End Region


    End Class
End Namespace
