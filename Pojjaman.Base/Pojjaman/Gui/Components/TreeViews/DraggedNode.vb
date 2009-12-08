Namespace Longkong.Pojjaman.Gui.Components
    Public Class DraggedNode
        Implements IDisposable


#Region " ::::::::::: Private Data Fields ::::::::::::: "
        Private m_initialRegion As Rectangle
        Private m_currentRegion As Rectangle

        Private m_node As TreeNode
        Private m_cursorLocation As Point
        Private m_nodeImage As Image

        Private disposed As Boolean = False

#End Region

#Region " ::::::::::: Properties ::::::::::::: "
        'An integer representing the original column index.
        Public ReadOnly Property Node() As TreeNode
            Get
                CheckState()
                Return m_node
            End Get
        End Property

        ' A Rectangle structure that identifies the region of the column at
        ' the time the drag and drop operation was initiated.
        Public ReadOnly Property InitialRegion() As Rectangle
            Get
                CheckState()
                Return m_initialRegion
            End Get
        End Property

        ' A Rectangle structure that identifies the current region of the 
        ' column that is being dragged. This is the only member that can be 
        ' modified after an instance has been created.

        Public Property CurrentRegion() As Rectangle
            Get
                CheckState()
                Return m_currentRegion
            End Get
            Set(ByVal Value As Rectangle)
                CheckState()
                m_currentRegion = Value
            End Set
        End Property

        ' A Bitmap object containing a bitmap representation of the column at 
        ' the time that the drag and drop operation was initiated.
        Public ReadOnly Property NodeImage() As Image
            Get
                Me.CheckState()
                Return m_nodeImage
            End Get

        End Property

        Public ReadOnly Property CurrentLocation() As Point
            Get
                CheckState()
                Return m_cursorLocation
            End Get
        End Property




#End Region

#Region " ::::::::::: Constructors ::::::::::::: "

        Public Sub New(ByVal _node As TreeNode, ByVal initialRegion As Rectangle, ByVal cursorLocation As Point, ByVal _nodeImage As Image)
            m_node = _node
            m_initialRegion = initialRegion
            m_currentRegion = initialRegion
            m_cursorLocation = cursorLocation
            m_nodeImage = _nodeImage
        End Sub

        Public Sub New(ByVal _node As TreeNode, ByVal initialRegion As Rectangle, ByVal cursorLocation As Point)
            Me.New(_node, initialRegion, cursorLocation, Nothing)
        End Sub

#End Region

        Public Sub Dispose() Implements System.IDisposable.Dispose
            If Not disposed Then
                m_initialRegion = Rectangle.Empty
                m_currentRegion = Rectangle.Empty
                m_node = Nothing
                m_cursorLocation = Point.Empty

                If Not m_nodeImage Is Nothing Then
                    m_nodeImage.Dispose()
                End If
                disposed = True

            End If

        End Sub

        Private Sub CheckState()
            If disposed Then
                Throw New ObjectDisposedException("DraggedDataGridColumn object has already been disposed.")

            End If
        End Sub

    End Class
End Namespace

