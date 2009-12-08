Namespace Longkong.Core.Properties
    Public Delegate Sub PropertyEventHandler(ByVal sender As Object, ByVal e As PropertyEventArgs)

    Public Class PropertyEventArgs

#Region "Members"
        Private m_key As String
        Private m_newValue As Object
        Private m_oldValue As Object
        Private m_properties As IProperties
#End Region

#Region "Costructors"
        Public Sub New(ByVal properties As IProperties, ByVal key As String, ByVal oldValue As Object, ByVal newValue As Object)
            Me.m_properties = properties
            Me.m_key = key
            Me.m_oldValue = oldValue
            Me.m_newValue = newValue
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Key() As String
            Get
                Return Me.m_key
            End Get
        End Property
        Public ReadOnly Property NewValue() As Object
            Get
                Return Me.m_newValue
            End Get
        End Property
        Public ReadOnly Property OldValue() As Object
            Get
                Return Me.m_oldValue
            End Get
        End Property
        Public ReadOnly Property Properties() As IProperties
            Get
                Return Me.m_properties
            End Get
        End Property
#End Region

    End Class
End Namespace

