Namespace Longkong.Core.AddIns.Codons
    Public MustInherit Class AbstractCommand
        Implements ICommand

#Region "Members"
        Private m_owner As Object
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_owner = Nothing
        End Sub
#End Region

#Region "ICommand"
        Public MustOverride Sub Run() Implements ICommand.Run

        Public Property Owner() As Object Implements ICommand.Owner
            Get
                Return m_owner
            End Get
            Set(ByVal Value As Object)
                m_owner = Value
            End Set
        End Property

#End Region

    End Class
End Namespace

