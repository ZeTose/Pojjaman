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
                    connstring = BlendedCodeHelper.GetConnString(connstring, False)
                    Dim siteconnstring As String = ""
                    If Not el.Attributes.ItemOf("siteconnstring") Is Nothing Then
                        siteconnstring = el.Attributes.ItemOf("siteconnstring").InnerText
                        siteconnstring = BlendedCodeHelper.GetConnString(siteconnstring, False)
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
                connstring.InnerText = BlendedCodeHelper.GetConnString(co.ConnectionString, True)
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

    Public Class BlendedCodeHelper
        Private Shared Function DeCode(ByVal passwordToEnCode As String, ByVal aliasName As String) As String
            If Not (passwordToEnCode.StartsWith("[") AndAlso passwordToEnCode.EndsWith("]")) Then
                Return passwordToEnCode
            End If

            Dim arrayPws As New ArrayList

            Dim ctext As String = ""
            For i As Integer = passwordToEnCode.Length - 1 To 0 Step -1
                ctext = passwordToEnCode.Substring(i, 1)
                arrayPws.Add(ctext)
            Next
            For i As Integer = 0 To aliasName.Length - 1
                If i Mod 2 = 0 Then
                    arrayPws.RemoveAt(i)
                End If
            Next

            'Dim passwordLength As Integer = passwordToEnCode.Length
            'Dim cList As New ArrayList
            'Dim cInteger As Integer
            'Dim startEnCodeWithAsc As Integer = 216
            'For i As Integer = passwordLength - 1 To 0 Step -1
            '    cInteger = CInt(AscW(passwordToEnCode.Substring(i, 1))) - startEnCodeWithAsc
            '    Dim obj As Object
            '    obj = ChrW(cInteger)
            '    cList.Add(obj)
            'Next
            'passwordToEnCode = String.Concat(cList.ToArray)
            'passwordToEnCode = Replace(passwordToEnCode.Substring(0, passwordToEnCode.Length - 3), aliasName, "").Trim
            Return String.Concat(arrayPws.ToArray)
        End Function
        Private Shared Function EnCode(ByVal passwordToEnCode As String, ByVal aliasName As String) As String
            If Not (passwordToEnCode.StartsWith("[") AndAlso passwordToEnCode.EndsWith("]")) Then
                Return passwordToEnCode
            End If

            Dim hashPws As New Hashtable
            Dim hashAls As New Hashtable

            Dim ctext As String = ""
            For i As Integer = passwordToEnCode.Length - 1 To 0 Step -1
                ctext = passwordToEnCode.Substring(i, 1)
                hashPws(i) = ctext
            Next

            For i As Integer = aliasName.Length - 1 To 0 Step -1
                ctext = aliasName.Substring(i, 1)
                hashAls(i) = ctext
            Next

            Dim maxLenght As Integer = 0
            If hashPws.Count > hashAls.Count Then
                maxLenght = hashPws.Count
            Else
                maxLenght = hashAls.Count
            End If
            Dim blendtext As String = ""
            For index As Integer = maxLenght - 1 To 0 Step -1
                If hashPws.Contains(index) Then
                    blendtext &= CType(hashPws(index), String)
                End If
                If hashAls.Contains(index) Then
                    blendtext &= CType(hashAls(index), String)
                End If
            Next

            Return blendtext
        End Function
        Public Shared Function GetConnString(ByVal ConnectionString As String, ByVal WithEncode As Boolean, Optional ByVal AliasPrefix As String = "") As String
            'Password=tmhctr;Persist Security Info=True;User ID=sa;Initial Catalog=testsc;Data Source=(local)
            Dim splitString() As String = ConnectionString.Split(";"c)
            Dim newConnString As String = ""
            Dim passwordIndex As Integer
            Dim password As String = ""
            Dim dbName As String = ""
            Dim dataSource As String = ""

            For i As Integer = 0 To splitString.Length - 1
                If splitString(i).StartsWith("Password") Then
                    password = splitString(i).Split("="c)(1)
                    passwordIndex = i
                ElseIf splitString(i).StartsWith("Initial") Then
                    dbName = splitString(i).Split("="c)(1)
                ElseIf splitString(i).StartsWith("Data") Then
                    dataSource = splitString(i).Split("="c)(1)
                End If
            Next

            If AliasPrefix.Length = 0 Then
                AliasPrefix = dataSource & dbName
            End If

            'If WithEncode Then
            '    password = BlendedCodeHelper.EnCode(password, AliasPrefix)
            'Else
            '    password = BlendedCodeHelper.DeCode(password, AliasPrefix)
            'End If

            '
            splitString(passwordIndex) = "Password=" & password
            '

            newConnString = String.Join(";", splitString)
            Return newConnString

        End Function
    End Class

End Namespace



