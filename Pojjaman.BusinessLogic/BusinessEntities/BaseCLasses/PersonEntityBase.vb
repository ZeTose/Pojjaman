Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports Longkong.Core.Services
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class PersonEntityBase
        Inherits SimpleBusinessEntityBase
        Implements IBillablePerson, ILocatable, IMultiName, IHasImage, IHasAccount

#Region "Members"
        Private m_name As String
        Private m_alternateName As String
        Private m_address As String
        Private m_province As String
        Private m_billingAddress As String
        Private m_phone As String
        Private m_fax As String
        Private m_detailDiscount As Discount
        Private m_summaryDiscount As Discount
        Private m_taxRate As Decimal
        Private m_taxId As String
        Private m_idNo As String
        Private m_homePage As String
        Private m_emailAddress As String
        Private m_personType As BusinessPersonType
        Private m_map As Image
        Private m_mapPosition As Point
        Private m_image As Image
        Private m_account As Longkong.Pojjaman.BusinessLogic.Account
        Private m_contact As String
        Private m_mobile As String
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
        Public Sub New(ByVal code As String, ByVal ParamArray filters() As Filter)
            MyBase.New(code, filters)
        End Sub
        Public Sub New(ByVal id As Integer, ByVal ParamArray filters() As Filter)
            MyBase.New(id, filters)
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            m_name = ""
            m_alternateName = ""
            m_address = ""
            m_province = ""
            m_billingAddress = ""
            m_phone = ""
            m_mobile = ""
            m_contact = ""
            m_fax = ""
            m_detailDiscount = New Discount("")
            m_summaryDiscount = New Discount("")
            m_taxRate = 0
            m_taxId = ""
            m_idNo = ""
            m_homePage = ""
            m_emailAddress = ""
            m_personType = New BusinessPersonType(0)
            m_map = Nothing
            m_mapPosition = New Point(0, 0)
            m_image = Nothing
            Me.m_personType = New BusinessPersonType
            Me.m_account = New Account
            Me.m_detailDiscount = New Discount("")
            Me.m_summaryDiscount = New Discount("")
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains("acct_id") Then
                    If Not dr.IsNull("acct_id") Then
                        .m_account = New Account(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_acct") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_acct") Then
                        .m_account = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_acct")))
                    End If
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_address") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_address") Then
                    .m_address = CStr(dr(aliasPrefix & Me.Prefix & "_address"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_altName") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_altName") Then
                    .m_alternateName = CStr(dr(aliasPrefix & Me.Prefix & "_altName"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_detailDiscount") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_detailDiscount") Then
                    .m_detailDiscount = New Discount(CStr(dr(aliasPrefix & Me.Prefix & "_detailDiscount")))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_summaryDiscount") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_summaryDiscount") Then
                    .m_summaryDiscount = New Discount(CStr(dr(aliasPrefix & Me.Prefix & "_summaryDiscount")))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_emailAddress") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_emailAddress") Then
                    .m_emailAddress = CStr(dr(aliasPrefix & Me.Prefix & "_emailAddress"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fax") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fax") Then
                    .m_fax = CStr(dr(aliasPrefix & Me.Prefix & "_fax"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_mobile") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_mobile") Then
                    .m_mobile = CStr(dr(aliasPrefix & Me.Prefix & "_mobile"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_contact") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_contact") Then
                    .m_contact = CStr(dr(aliasPrefix & Me.Prefix & "_contact"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fax") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fax") Then
                    .m_fax = CStr(dr(aliasPrefix & Me.Prefix & "_fax"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_billingAddress") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_billingAddress") Then
                    .m_billingAddress = CStr(dr(aliasPrefix & Me.Prefix & "_billingAddress"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_homePage") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_homePage") Then
                    .m_homePage = CStr(dr(aliasPrefix & Me.Prefix & "_homePage"))
                End If

                Dim x, y As Integer
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_mapPointX") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_mapPointX") Then
                    x = CInt(dr(aliasPrefix & Me.Prefix & "_mapPointX"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_mapPointY") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_mapPointY") Then
                    y = CInt(dr(aliasPrefix & Me.Prefix & "_mapPointY"))
                End If
                .m_mapPosition = New Point(x, y)

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_personType") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_personType") Then
                    .m_personType.Value = CInt(dr(aliasPrefix & Me.Prefix & "_personType"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_phone") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_phone") Then
                    .m_phone = CStr(dr(aliasPrefix & Me.Prefix & "_phone"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_taxId") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_taxId") Then
                    .m_taxId = CStr(dr(aliasPrefix & Me.Prefix & "_taxId"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_idNo") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_idNo") Then
                    .m_idNo = CStr(dr(aliasPrefix & Me.Prefix & "_idNo"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_taxRate") AndAlso Not dr.IsNull(Me.Prefix & "_taxRate") Then
                    .m_taxRate = CDec(dr(Me.Prefix & "_taxRate"))
                End If

                'LoadImage()
            End With
        End Sub
        Public Sub LoadImage()
            If Id <= 0 Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String = "select " & Me.Prefix & "_image," & Me.Prefix & "_map from " & Me.TableName & " where " & Me.Prefix & "_id=" & Id

            conn.Open()

            Dim cmd As SqlCommand = conn.CreateCommand
            cmd.CommandText = sql

            Dim custReader As SqlDataReader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))
            If custReader.Read Then
                LoadImage(custReader)
            End If
        End Sub
        Public Sub LoadImage(ByVal reader As IDataReader)
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            m_image = Field.GetImage(reader, Me.Prefix & "_image")
            m_map = Field.GetImage(reader, Me.Prefix & "_map")
            Try
                If Image Is Nothing Then
                    m_image = Image.FromFile(myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Entity.BlankImage}"))
                End If
                If Map Is Nothing Then
                    m_map = Image.FromFile(myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Entity.BlankImage}"))
                End If
            Catch ex As Exception

            End Try
        End Sub
#End Region

#Region "IBillablePerson"
        Public Property Address() As String Implements IBillablePerson.Address
            Get
                Return m_address
            End Get
            Set(ByVal Value As String)
                m_address = Value
            End Set
        End Property
        Public Property BillingAddress() As String Implements IBillablePerson.BillingAddress
            Get
                Return m_billingAddress
            End Get
            Set(ByVal Value As String)
                m_billingAddress = Value
            End Set
        End Property
        Public Property DetailDiscount() As Discount Implements IBillablePerson.DetailDiscount
            Get
                Return m_detailDiscount
            End Get
            Set(ByVal Value As Discount)
                m_detailDiscount = Value
            End Set
        End Property
        Public Property EmailAddress() As String Implements IBillablePerson.EmailAddress
            Get
                Return m_emailAddress
            End Get
            Set(ByVal Value As String)
                m_emailAddress = Value
            End Set
        End Property
        Public Property Fax() As String Implements IBillablePerson.Fax
            Get
                Return m_fax
            End Get
            Set(ByVal Value As String)
                m_fax = Value
            End Set
        End Property
        Public Property HomePage() As String Implements IBillablePerson.HomePage
            Get
                Return m_homePage
            End Get
            Set(ByVal Value As String)
                m_homePage = Value
            End Set
        End Property
        Public Property Phone() As String Implements IBillablePerson.Phone
            Get
                Return m_phone
            End Get
            Set(ByVal Value As String)
                m_phone = Value
            End Set
        End Property
        Public Property Province() As String Implements IBillablePerson.Province
            Get
                Return m_province
            End Get
            Set(ByVal Value As String)
                m_province = Value
            End Set
        End Property
        Public Property SummaryDiscount() As Discount Implements IBillablePerson.SummaryDiscount
            Get
                Return m_summaryDiscount
            End Get
            Set(ByVal Value As Discount)
                m_summaryDiscount = Value
            End Set
        End Property
        Public Property TaxId() As String Implements IBillablePerson.TaxId
            Get
                Return m_taxId
            End Get
            Set(ByVal Value As String)
                m_taxId = Value
            End Set
        End Property
        Public Property IdNo() As String Implements IBillablePerson.IdNo
            Get
                Return m_idNo
            End Get
            Set(ByVal Value As String)
                m_idNo = Value
            End Set
        End Property
        Public Property TaxRate() As Decimal Implements IBillablePerson.TaxRate
            Get
                Return m_taxRate
            End Get
            Set(ByVal Value As Decimal)
                m_taxRate = Value
            End Set
        End Property
        Public Property Name() As String Implements IHasName.Name
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
                Me.OnTabPageTextChanged(Me, New EventArgs)
            End Set
        End Property
        Public Property PersonType() As BusinessPersonType Implements IBillablePerson.PersonType
            Get
                Return m_personType
            End Get
            Set(ByVal Value As BusinessPersonType)
                m_personType = Value
            End Set
        End Property
        Public Property Contact() As String Implements IBillablePerson.Contact
            Get
                Return m_contact
            End Get
            Set(ByVal Value As String)
                m_contact = Value
            End Set
        End Property
        Public Property Mobile() As String Implements IBillablePerson.Mobile            Get                Return m_mobile            End Get            Set(ByVal Value As String)                m_mobile = Value            End Set        End Property
#End Region

#Region "Ilocatable"
        Public Property Map() As System.Drawing.Image Implements ILocatable.Map
            Get
                Return m_map
            End Get
            Set(ByVal Value As System.Drawing.Image)
                m_map = Value
            End Set
        End Property
        Public Property MapPosition() As System.Drawing.Point Implements ILocatable.MapPosition
            Get
                Return m_mapPosition
            End Get
            Set(ByVal Value As System.Drawing.Point)
                m_mapPosition = Value
            End Set
        End Property
#End Region

#Region "IMultiName"
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

#Region "IHasAccount"
        Public Property Account() As Account Implements IHasAccount.Account
            Get
                Return m_account
            End Get
            Set(ByVal Value As Account)
                m_account = Value
            End Set
        End Property
#End Region

    End Class

End Namespace
