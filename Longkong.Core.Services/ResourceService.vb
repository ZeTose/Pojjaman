Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections
Imports System.Threading
Imports System.Resources
Imports System.Drawing
Imports System.Diagnostics
Imports System.Reflection
Imports System.Xml
Imports System.Configuration
Imports System.Globalization
Imports Longkong.Core.Properties

Namespace Longkong.Core.Services
    Public Class ResourceService
        Inherits AbstractService
        Implements IResourceService

#Region "Members"
        Private m_assemblies As ArrayList
        Private m_icon As ArrayList

        Private m_localIcons As Hashtable
        Private m_localIconsResMgrs As ArrayList
        Private m_localStrings As Hashtable
        Private m_localStringsResMgrs As ArrayList
        Private m_localUserIcons As Hashtable
        Private m_localUserStrings As Hashtable
        Private m_strings As ArrayList
        Private m_userIcons As Hashtable
        Private m_userStrings As Hashtable

        Private Shared ResourceDirctory As String

        Private Shared ReadOnly ImageResources As String
        Private Shared ReadOnly StringResources As String
        Private Shared ReadOnly UiLanguageProperty As String
#End Region

#Region "Costructors"
        Shared Sub New()
            ResourceService.UiLanguageProperty = "CoreProperties.UILanguage"
            ResourceService.StringResources = "StringResources"
            ResourceService.ImageResources = "BitmapResources"
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            ResourceService.ResourceDirctory = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "resources")
        End Sub
        Public Sub New()
            Me.m_userStrings = Nothing
            Me.m_userIcons = Nothing
            Me.m_localUserStrings = Nothing
            Me.m_localUserIcons = Nothing
            Me.m_strings = New ArrayList
            Me.m_icon = New ArrayList
            Me.m_localStrings = Nothing
            Me.m_localIcons = Nothing
            Me.m_localStringsResMgrs = New ArrayList
            Me.m_localIconsResMgrs = New ArrayList
            Me.m_assemblies = New ArrayList
            If (Not ConfigurationSettings.AppSettings.Item("UserStrings") Is Nothing) Then
                Me.m_userStrings = Me.Load((ResourceService.ResourceDirctory & Path.DirectorySeparatorChar & ConfigurationSettings.AppSettings.Item("UserStrings")))
            End If
            If (Not ConfigurationSettings.AppSettings.Item("UserIcons") Is Nothing) Then
                Me.m_userIcons = Me.Load((ResourceService.ResourceDirctory & Path.DirectorySeparatorChar & ConfigurationSettings.AppSettings.Item("UserIcons")))
            End If
        End Sub
#End Region

#Region "Methods"
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As PropertyEventArgs)
            If ((e.Key Is ResourceService.UiLanguageProperty) AndAlso (Not e.OldValue Is e.NewValue)) Then
                Me.LoadLanguageResources()
            End If
        End Sub
        Public Function GetBitmap(ByVal name As String) As Bitmap
            Return CType(Me.GetImageResource(name), Bitmap)
        End Function
        Public Function GetIcon(ByVal name As String) As Icon
            Dim myImageResource As Object = Me.GetImageResource(name)
            If (myImageResource Is Nothing) Then
                Return Nothing
            End If
            If TypeOf myImageResource Is Icon Then
                Return CType(myImageResource, Icon)
            End If
            Return Icon.FromHandle(CType(myImageResource, Bitmap).GetHicon)
        End Function
        Private Function GetImageResource(ByVal name As String) As Object
            Dim iconobj As Object = Nothing
            If ((Not Me.m_localUserIcons Is Nothing) AndAlso (Not Me.m_localUserIcons.Item(name) Is Nothing)) Then
                Return Me.m_localUserIcons.Item(name)
            End If
            If ((Not Me.m_userIcons Is Nothing) AndAlso (Not Me.m_userIcons.Item(name) Is Nothing)) Then
                Return Me.m_userIcons.Item(name)
            End If
            If ((Not Me.m_localIcons Is Nothing) AndAlso (Not Me.m_localIcons.Item(name) Is Nothing)) Then
                Return Me.m_localIcons.Item(name)
            End If
            For Each myResourceManager As ResourceManager In Me.m_localIconsResMgrs
                iconobj = myResourceManager.GetObject(name)
                If (Not iconobj Is Nothing) Then
                    Exit For
                End If
            Next
            If (iconobj Is Nothing) Then
                For Each myResourceManager As ResourceManager In Me.m_icon
                    iconobj = myResourceManager.GetObject(name)
                    If (Not iconobj Is Nothing) Then
                        Return iconobj
                    End If
                Next
            End If
            Return iconobj
        End Function
        Public Overrides Sub InitializeService()
            Me.RegisterAssembly([Assembly].GetEntryAssembly)
            MyBase.InitializeService()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            AddHandler myPropertyService.PropertyChanged, New PropertyEventHandler(AddressOf Me.ChangeProperty)
            Me.LoadLanguageResources()
        End Sub
        Private Function Load(ByVal fileName As String) As Hashtable
            If Not File.Exists(fileName) Then
                Return Nothing
            End If
            Dim resources As New Hashtable
            Dim rr As New ResourceReader(fileName)
            For Each entry As DictionaryEntry In rr
                resources.Add(entry.Key, entry.Value)
            Next
            rr.Close()
            Return resources
        End Function
        Private Function Load(ByVal name As String, ByVal language As String) As Hashtable
            Return Me.Load(ResourceService.ResourceDirctory & Path.DirectorySeparatorChar & name & "." & language & ".resources")
        End Function
        Public Function LoadFont(ByVal fontName As String, ByVal size As Integer) As Font
            Return Me.LoadFont(fontName, size, FontStyle.Regular)
        End Function
        Public Function LoadFont(ByVal fontName As String, ByVal size As Integer, ByVal style As FontStyle) As Font
            Try
                Return New Font(fontName, size, style)
            Catch exception1 As Exception
                Return SystemInformation.MenuFont
            End Try
        End Function
        Public Function LoadFont(ByVal fontName As String, ByVal size As Integer, ByVal unit As GraphicsUnit) As Font
            Return Me.LoadFont(fontName, size, FontStyle.Regular, unit)
        End Function
        Public Function LoadFont(ByVal fontName As String, ByVal size As Integer, ByVal style As FontStyle, ByVal unit As GraphicsUnit) As Font
            Try
                Return New Font(fontName, size, style, unit)
            Catch exception1 As Exception
                Return SystemInformation.MenuFont
            End Try
        End Function
        Private Sub LoadLanguageResources()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim language As String = myPropertyService.GetProperty(ResourceService.UiLanguageProperty, Thread.CurrentThread.CurrentUICulture.Name)
            Try
                Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)
            Catch
                Try
                    Thread.CurrentThread.CurrentUICulture = New CultureInfo(language.Split(New Char() {"-"c})(0))
                Catch
                End Try
            End Try
            If (Not ConfigurationSettings.AppSettings.Item("UserStrings") Is Nothing) Then
                Dim resourceName As String = ConfigurationSettings.AppSettings.Item("UserStrings")
                resourceName = resourceName.Insert(resourceName.LastIndexOf(".resources"), ("." & language))
                Me.m_localUserStrings = Me.Load((ResourceService.ResourceDirctory & Path.DirectorySeparatorChar & resourceName))
            End If
            If (Not ConfigurationSettings.AppSettings.Item("UserIcons") Is Nothing) Then
                Dim resourceName As String = ConfigurationSettings.AppSettings.Item("UserIcons")
                resourceName = resourceName.Insert(resourceName.LastIndexOf(".resources"), ("." & language))
                Me.m_localUserIcons = Me.Load((ResourceService.ResourceDirctory & Path.DirectorySeparatorChar & resourceName))
            End If

            Me.m_localStrings = Me.Load(ResourceService.StringResources, language)
            If ((Me.m_localStrings Is Nothing) AndAlso (language.IndexOf("-"c) > 0)) Then
                Me.m_localStrings = Me.Load(ResourceService.StringResources, language.Split("-"c)(0))
            End If

            Me.m_localIcons = Me.Load(ResourceService.ImageResources, language)
            If ((Me.m_localIcons Is Nothing) AndAlso (language.IndexOf("-"c) > 0)) Then
                Me.m_localIcons = Me.Load(ResourceService.ImageResources, language.Split("-"c)(0))
            End If

            Me.m_localStringsResMgrs.Clear()
            Me.m_localIconsResMgrs.Clear()

            For Each asm As [Assembly] In AppDomain.CurrentDomain.GetAssemblies
                If Me.m_assemblies.Contains(asm.FullName) Then
                    If (Not asm.GetManifestResourceInfo((ResourceService.StringResources & ".resources")) Is Nothing) Then
                        Me.m_localStringsResMgrs.Add(New ResourceManager(ResourceService.StringResources, asm))
                    End If

                    If (Not asm.GetManifestResourceInfo((ResourceService.ImageResources & ".resources")) Is Nothing) Then
                        Me.m_localIconsResMgrs.Add(New ResourceManager(ResourceService.ImageResources, asm))
                    End If
                End If
            Next
        End Sub
#End Region

#Region "IResourceService implementations"
        Public Function GetString(ByVal name As String) As String Implements IResourceService.GetString
            If ((Not Me.m_localUserStrings Is Nothing) AndAlso (Not Me.m_localUserStrings.Item(name) Is Nothing)) Then
                Return Me.m_localUserStrings.Item(name).ToString
            End If

            If ((Not Me.m_userStrings Is Nothing) AndAlso (Not Me.m_userStrings.Item(name) Is Nothing)) Then
                Return Me.m_userStrings.Item(name).ToString
            End If

            If ((Not Me.m_localStrings Is Nothing) AndAlso (Not Me.m_localStrings.Item(name) Is Nothing)) Then
                Return Me.m_localStrings.Item(name).ToString
            End If

            Dim s As String = Nothing
            For Each rsm As ResourceManager In Me.m_localStringsResMgrs
                s = rsm.GetString(name)
                If (Not s Is Nothing) Then
                    Exit For
                End If
            Next
            If (s Is Nothing) Then
                For Each rsm As ResourceManager In Me.m_strings
                    s = rsm.GetString(name)
                    If (Not s Is Nothing) Then
                        Exit For
                    End If
                Next
            End If
            If (s Is Nothing) Then
                Return "TBD!" 'name 'Todo:
                'Throw New ResourceNotFoundException(("string >" & name & "<"))
            End If
            Return s
        End Function

        Public Sub RegisterAssembly(ByVal [assembly] As System.Reflection.Assembly) Implements IResourceService.RegisterAssembly
            If [assembly] Is Nothing Then
                Return
            End If
            Me.m_assemblies.Add([assembly].FullName)
            If (Not [assembly].GetManifestResourceInfo((ResourceService.StringResources & ".resources")) Is Nothing) Then
                Me.m_strings.Add(New ResourceManager(ResourceService.StringResources, [assembly]))
            End If
            If (Not [assembly].GetManifestResourceInfo((ResourceService.ImageResources & ".resources")) Is Nothing) Then
                Me.m_icon.Add(New ResourceManager(ResourceService.ImageResources, [assembly]))
            End If
        End Sub
#End Region

    End Class
End Namespace

