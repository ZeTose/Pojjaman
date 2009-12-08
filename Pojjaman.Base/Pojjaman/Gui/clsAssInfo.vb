Option Strict Off
Imports System.Reflection
Public Class clsAssInfo
    Dim m_AssInfo As System.Reflection.Assembly
    Public Sub New(ByVal asm As [Assembly])
        m_AssInfo = asm
    End Sub
    Public ReadOnly Property Company() As String
        Get
            Dim m_Company As AssemblyCompanyAttribute
            m_Company = m_AssInfo.GetCustomAttributes(GetType(AssemblyCompanyAttribute), False)(0)
            Return m_Company.Company.ToString
        End Get
    End Property

    Public ReadOnly Property Copyright() As String
        Get
            Dim m_Copyright As AssemblyCopyrightAttribute
            m_Copyright = m_AssInfo.GetCustomAttributes(GetType(AssemblyCopyrightAttribute), False)(0)
            Return m_Copyright.Copyright.ToCharArray
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Dim m_Description As AssemblyDescriptionAttribute
            m_Description = m_AssInfo.GetCustomAttributes(GetType(AssemblyDescriptionAttribute), False)(0)
            Return m_Description.Description.ToString
        End Get
    End Property

    Public ReadOnly Property Product() As String
        Get
            Dim m_Product As AssemblyProductAttribute
            m_Product = m_AssInfo.GetCustomAttributes(GetType(AssemblyProductAttribute), False)(0)
            Return m_Product.Product.ToString
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Dim m_Title As AssemblyTitleAttribute
            m_Title = m_AssInfo.GetCustomAttributes(GetType(AssemblyTitleAttribute), False)(0)
            Return m_Title.Title.ToString
        End Get
    End Property

    Public ReadOnly Property Trademark() As String
        Get
            Dim m_Trademark As AssemblyTrademarkAttribute
            m_Trademark = m_AssInfo.GetCustomAttributes(GetType(AssemblyTrademarkAttribute), False)(0)
            Return m_Trademark.Trademark.ToString
        End Get
    End Property

    Public ReadOnly Property Version() As String
        Get
            Dim GigVersion As Version = [Assembly].GetEntryAssembly.GetName.Version
            'Dim GigVersionArray As Object() = New Object() {GigVersion.Major, ".", GigVersion.Minor.ToString("00"), ".", GigVersion.Build.ToString("0000")}
            Return GigVersion.Major.ToString & "." & GigVersion.Minor.ToString("00") & "." & GigVersion.Build.ToString("0000") & " Build " & GigVersion.Revision.ToString("###")
        End Get
    End Property

    'Public ReadOnly Property GUID() As String Implements clsAppInfo.IApplicationSM.GUID
    '    Get
    '        Dim m_GUID As AssemblyTrademarkAttribute
    '        m_GUID = m_AssInfo.GetCustomAttributes(GetType(AssemblyKeyFileAttribute), False)(0)
    '        Return m_GUID.
    '    End Get
    'End Property

End Class
