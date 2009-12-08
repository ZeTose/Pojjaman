Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Namespace Longkong.Pojjaman.Gui.Components
    <AttributeUsage(AttributeTargets.Property, AllowMultiple:=False, Inherited:=True)> _
    Public Class ControlPropertyAttribute
        Inherits Attribute

#Region "Members"
        Private m_name As String
        Private m_description As String
        Private m_category As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String)
            Me.m_name = name
        End Sub
#End Region

#Region "Properties"
        Public Property Name() As String            Get                Return m_name            End Get            Set(ByVal Value As String)                m_name = Value            End Set        End Property        Public Property Description() As String            Get                Return m_description            End Get            Set(ByVal Value As String)                m_description = Value            End Set        End Property
        Public Property Category() As String            Get                Return m_category            End Get            Set(ByVal Value As String)                m_category = Value            End Set        End Property
#End Region

    End Class
End Namespace
