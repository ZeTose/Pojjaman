Imports Longkong.Core.Properties
Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports System.Xml
Imports System.IO
Namespace Longkong.Pojjaman.Services
    Public Class Company

#Region "Members"
        Private m_name As String
        Private m_connectionString As String
        Private m_siteConnectionString As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String, ByVal connstring As String)
            Me.New(name, connstring, connstring)
        End Sub
        Public Sub New(ByVal name As String, ByVal connstring As String, ByVal siteConnstring As String)
            Me.m_name = name
            Me.m_connectionString = connstring
            Me.m_siteConnectionString = siteConnstring
        End Sub
#End Region

#Region "Properties"
        Public Property Name() As String            Get                Return m_name            End Get            Set(ByVal Value As String)                m_name = Value            End Set        End Property        Public Property SiteConnectionString() As String            Get                Return m_siteConnectionString            End Get            Set(ByVal Value As String)                m_siteConnectionString = Value            End Set        End Property        Public Property ConnectionString() As String            Get                Return m_connectionString            End Get            Set(ByVal Value As String)                m_connectionString = Value            End Set        End Property
#End Region

#Region "Overides"
        Public Overrides Function ToString() As String
            Return Me.Name
        End Function
#End Region

    End Class
    Public Class RecentCompanies
        Implements IXmlConvertable

#Region "Members"
        Private m_lastCompanies As ArrayList
        Private MAX_LENGTH As Integer
        Public Shared CurrentCompany As Company
#End Region

#Region "Events"
        Public Event RecentCompaniesChanged As EventHandler
#End Region

#Region "Constructors"
        Shared Sub New()
            Dim properties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim rc As RecentCompanies = CType(properties.GetProperty("Longkong.Pojjaman.RecentCompanies", New RecentCompanies), RecentCompanies)
            If rc.m_lastCompanies.Count = 0 Then
                Return
            End If
            CurrentCompany = CType(rc.m_lastCompanies(0), Company)
        End Sub
        Public Sub New()
            Me.MAX_LENGTH = 50 'ได้ 50 บริษัท
            Me.m_lastCompanies = New ArrayList
        End Sub
        Public Sub New(ByVal element As XmlElement)
            Me.new()
            Dim nodes As XmlNodeList = element.Item("COMPANIES").ChildNodes
            For Each el As XmlElement In element.Item("COMPANIES").ChildNodes
                If el.Name = "COMPANY" Then
                    Dim name As String = el.Attributes.ItemOf("name").InnerText
                    Dim connstring As String = el.Attributes.ItemOf("connstring").InnerText
                    Dim siteconnstring As String = ""
                    If Not el.Attributes.ItemOf("siteconnstring") Is Nothing Then
                        siteconnstring = el.Attributes.ItemOf("siteconnstring").InnerText
                    End If
                    Dim co As New Company(name, connstring, siteconnstring)
                    Me.m_lastCompanies.Add(co)
                End If
            Next
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property RecentCompanies() As ArrayList
            Get
                Return Me.m_lastCompanies
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub ChangeCurrentCompany(ByVal name As String)
            Dim companyToSet As Company
            For Each co As Company In Me.m_lastCompanies
                If co.Name = name Then
                    companyToSet = co
                    Exit For
                End If
            Next
            If Not companyToSet Is Nothing Then
                Me.m_lastCompanies.Remove(companyToSet)
                If (Me.m_lastCompanies.Count > 0) Then
                    Me.m_lastCompanies.Insert(0, companyToSet)
                Else
                    Me.m_lastCompanies.Add(companyToSet)
                End If
                CurrentCompany = companyToSet
                Me.OnRecentCompaniesChange()
            End If
        End Sub
        Public Sub AddCompany(ByVal name As String, ByVal connString As String)
            If Me.m_lastCompanies.Count = MAX_LENGTH Then
                If Me.m_lastCompanies.Count > 0 Then
                    Me.m_lastCompanies.RemoveAt(Me.m_lastCompanies.Count - 1)
                End If
            End If
            Dim companyToAdd As New Company(name, connString)
            For Each co As Company In Me.m_lastCompanies
                If co.Name = companyToAdd.Name Then
                    Return
                End If
            Next
            If (Me.m_lastCompanies.Count > 0) Then
                Me.m_lastCompanies.Insert(0, companyToAdd)
            Else
                Me.m_lastCompanies.Add(companyToAdd)
            End If
            CurrentCompany = companyToAdd
            Me.OnRecentCompaniesChange()
        End Sub
        Public Sub DeleteCompany(ByVal name As String)
            For Each co As Company In Me.m_lastCompanies
                If co.Name = name Then
                    Me.m_lastCompanies.Remove(co)
                    Exit For
                End If
            Next
            If m_lastCompanies.Count = 0 Then
                Return
            End If
            CurrentCompany = CType(m_lastCompanies(0), Company)
            Me.OnRecentCompaniesChange()
        End Sub
        Public Sub ClearRecentCompanies()
            Me.m_lastCompanies.Clear()
            Me.OnRecentCompaniesChange()
        End Sub
        Private Sub OnRecentCompaniesChange()
            RaiseEvent RecentCompaniesChanged(Me, Nothing)
        End Sub
#End Region

#Region "IXmlConvertable"
        Public Function FromXmlElement(ByVal element As System.Xml.XmlElement) As Object Implements IXmlConvertable.FromXmlElement
            Return New RecentCompanies(element)
        End Function
        Public Function ToXmlElement(ByVal doc As System.Xml.XmlDocument) As System.Xml.XmlElement Implements IXmlConvertable.ToXmlElement
            Dim rootEl As XmlElement = doc.CreateElement("RECENTCOMPANIES")
            Dim companiesEl As XmlElement = doc.CreateElement("COMPANIES")
            For Each co As Company In Me.m_lastCompanies
                Dim coEl As XmlElement = doc.CreateElement("COMPANY")
                Dim name As XmlAttribute = doc.CreateAttribute("name")
                name.InnerText = co.Name
                coEl.Attributes.Append(name)
                Dim connstring As XmlAttribute = doc.CreateAttribute("connstring")
                connstring.InnerText = co.ConnectionString
                If co.SiteConnectionString.Length = 0 Then
                    co.SiteConnectionString = co.ConnectionString
                End If
                coEl.Attributes.Append(connstring)
                Dim siteconnstring As XmlAttribute = doc.CreateAttribute("siteconnstring")
                siteconnstring.InnerText = co.SiteConnectionString
                coEl.Attributes.Append(siteconnstring)
                companiesEl.AppendChild(coEl)
            Next
            rootEl.AppendChild(companiesEl)
            Return rootEl
        End Function
#End Region

    End Class
End Namespace



