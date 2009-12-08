Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    Public MustInherit Class AbstractCheckableMenuCommand
        Inherits AbstractMenuCommand
        Implements ICheckableMenuCommand

#Region "Members"
        Private m_isChecked As Boolean
#End Region

#Region "ICheckableMenuCommand"
        Public Overridable Property IsChecked() As Boolean Implements ICheckableMenuCommand.IsChecked
            Get
                Return m_isChecked
            End Get
            Set(ByVal Value As Boolean)
                m_isChecked = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
