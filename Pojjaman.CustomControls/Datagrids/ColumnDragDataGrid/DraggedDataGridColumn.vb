Namespace Longkong.Pojjaman.Gui.Components
    Public Class DraggedDataGridColumn
        Implements IDisposable


#Region " ::::::::::: Private Data Fields ::::::::::::: "
        Private m_initialRegion As Rectangle
        Private m_currentRegion As Rectangle

        Private m_index As Integer
        Private m_cursorLocation As Point
        Private m_columnImage As Image

        Private disposed As Boolean = False

#End Region

#Region " ::::::::::: Properties ::::::::::::: "
        'An integer representing the original column index.
        Public ReadOnly Property Index() As Integer
            Get
                CheckState()
                Return m_index
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
        Public ReadOnly Property ColumnImage() As Image
            Get
                Me.CheckState()
                Return m_columnImage
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

        Public Sub New(ByVal index As Integer, ByVal initialRegion As Rectangle, ByVal cursorLocation As Point, ByVal columnImage As Image)
            m_index = index
            m_initialRegion = initialRegion
            m_currentRegion = initialRegion
            m_cursorLocation = cursorLocation
            m_columnImage = columnImage
        End Sub

        Public Sub New(ByVal index As Integer, ByVal initialRegion As Rectangle, ByVal cursorLocation As Point)
            Me.New(index, initialRegion, cursorLocation, Nothing)
        End Sub

#End Region

        Public Sub Dispose() Implements System.IDisposable.Dispose
            If Not disposed Then
                m_initialRegion = Rectangle.Empty
                m_currentRegion = Rectangle.Empty
                m_index = -1
                m_cursorLocation = Point.Empty

                If Not m_columnImage Is Nothing Then
                    m_columnImage.Dispose()
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