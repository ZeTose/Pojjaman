Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    Public MustInherit Class AbstractComboBoxCommand
        Inherits AbstractCommand
        Implements IComboBoxCommand

#Region "Members"
        Private m_isEnabled As Boolean
#End Region

#Region "Constructors"
        Protected Sub New()
            Me.m_isEnabled = True
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Mehods"
        Public Overrides Sub Run()
        End Sub
#End Region

#Region "IComboBoxCommand"
        Public Property IsEnabled() As Boolean Implements IComboBoxCommand.IsEnabled
            Get
                Return Me.m_isEnabled
            End Get
            Set(ByVal value As Boolean)
                Me.m_isEnabled = value
            End Set
        End Property
#End Region

    End Class
End Namespace
