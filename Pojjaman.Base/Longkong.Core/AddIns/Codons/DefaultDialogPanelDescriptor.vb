Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    Public Class DefaultDialogPanelDescriptor
        Implements IDialogPanelDescriptor

#Region "Members"
        Private m_dialogPanel As IDialogPanel
        Private m_dialogPanelDescriptors As ArrayList
        Private m_id As String
        Private m_label As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal id As String, ByVal label As String)
            Me.m_dialogPanelDescriptors = Nothing
            Me.m_dialogPanel = Nothing
            Me.m_id = id
            Me.m_label = label
        End Sub
        Public Sub New(ByVal id As String, ByVal label As String, ByVal dialogPanel As IDialogPanel)
            Me.New(id, label)
            Me.m_dialogPanel = dialogPanel
        End Sub
        Public Sub New(ByVal id As String, ByVal label As String, ByVal dialogPanelDescriptors As ArrayList)
            Me.New(id, label)
            Me.m_dialogPanelDescriptors = dialogPanelDescriptors
        End Sub
#End Region

#Region "IDialogPanelDescriptor"
        Public Property DialogPanel() As IDialogPanel Implements IDialogPanelDescriptor.DialogPanel
            Get
                Return Me.m_dialogPanel
            End Get
            Set(ByVal Value As IDialogPanel)
                m_dialogPanel = Value
            End Set
        End Property

        Public Property DialogPanelDescriptors() As System.Collections.ArrayList Implements IDialogPanelDescriptor.DialogPanelDescriptors
            Get
                Return Me.m_dialogPanelDescriptors
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                Me.m_dialogPanelDescriptors = Value
            End Set
        End Property

        Public ReadOnly Property ID() As String Implements IDialogPanelDescriptor.ID
            Get
                Return Me.m_id
            End Get
        End Property

        Public Property Label() As String Implements IDialogPanelDescriptor.Label
            Get
                Return Me.m_label
            End Get
            Set(ByVal Value As String)
                m_label = Value
            End Set
        End Property
#End Region

    End Class

End Namespace
