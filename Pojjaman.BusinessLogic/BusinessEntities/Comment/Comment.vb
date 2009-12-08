Namespace Longkong.Pojjaman.BusinessLogic
    Public Class Comment

#Region "Members"
        Private m_entity As BusinessEntity
        Private m_column As ListColumn
        Private m_headerText As String
        Private m_text As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal entity As BusinessEntity, ByVal col As ListColumn)

        End Sub
#End Region

#Region "Properties"
        Public Property Entity() As BusinessEntity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessEntity)
                m_entity = Value
            End Set
        End Property
        Public Property Column() As ListColumn
            Get
                Return m_column
            End Get
            Set(ByVal Value As ListColumn)
                m_column = Value
            End Set
        End Property
        Public Property HeaderText() As String
            Get
                Return m_headerText
            End Get
            Set(ByVal Value As String)
                m_headerText = Value
            End Set
        End Property
        Public Property Text() As String
            Get
                Return m_text
            End Get
            Set(ByVal Value As String)
                m_text = Value
            End Set
        End Property
#End Region

#Region "Methods"

#End Region

    End Class
End Namespace
