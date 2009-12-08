Imports System
Imports System.Drawing
Imports System.Windows.Forms


Namespace Longkong.Pojjaman.Gui.Components

    Public Enum ControlVertAlignment
        Top
        Center
        Bottom
    End Enum

    Public Enum ControlHorizAlignment
        Left
        Center
        Right
    End Enum

    Public Class PJMColumnStyle
        Inherits DataGridColumnStyle

        Private m_padding As PJMColumnStylePadding
        Private m_controlSize As Size
        Private m_controlVertAlignment As ControlVertAlignment
        Private m_controlHorizAlignment As ControlHorizAlignment


        Public Sub New() '

            m_padding = New PJMColumnStylePadding(0)
            m_controlSize = New Size(Me.Width, 16)
            m_controlHorizAlignment = ControlHorizAlignment.Center
            m_controlVertAlignment = ControlVertAlignment.Center
        End Sub

        ' Gets the PJMColumnStylePadding object representing the
        ' amount of padding that exists around the controls that are displayed
        ' in the data grid column cells.

        Public ReadOnly Property Padding() As PJMColumnStylePadding
            Get
                Return m_padding
            End Get
        End Property
        ' Gets the preferred minimum width

        Public Overridable ReadOnly Property MinimumWidth() As Integer
            Get
                Return Me.GetPreferredSize(Nothing, Nothing).Width
            End Get
        End Property
        ' Gets the preferred minimum height

        Public Overridable ReadOnly Property MinimumHeight() As Integer
            Get
                Return Me.GetMinimumHeight()
            End Get
        End Property
        ' Gets and sets the preferred control size (this is the size of the control
        ' when it is rendered in the data grid cells.

        Public Overridable Property ControlSize() As Size
            Get
                Return m_controlSize
            End Get
            Set(ByVal Value As Size)
                m_controlSize = Value
            End Set
        End Property
        ' Gets and sets the horizontal alignment of the control in the grid cell

        Public Overridable Property ControlHorizAlignment() As ControlHorizAlignment
            Get
                Return m_controlHorizAlignment
            End Get
            Set(ByVal Value As ControlHorizAlignment)
                m_controlHorizAlignment = Value
            End Set
        End Property
        ' Gets and sets the vertical alignment of the control in the grid cell

        Public Overridable Property ControlVertAlignment() As ControlVertAlignment
            Get
                Return m_controlVertAlignment
            End Get
            Set(ByVal Value As ControlVertAlignment)
                m_controlVertAlignment = Value
            End Set
        End Property

        ' Calculates the control bounds, taking alignment and padding into consideration
        Protected Overridable Function GetControlBounds(ByVal cellBounds As Rectangle) As Rectangle

            Dim controlBounds As New Rectangle(cellBounds.X + Me.Padding.Left, cellBounds.Y + Me.Padding.Top, Me.ControlSize.Width, Me.ControlSize.Height)

            Select Case m_controlVertAlignment

                Case ControlVertAlignment.Center
                    controlBounds.Y = cellBounds.Top + CInt((cellBounds.Height - Me.ControlSize.Height) / 2)

                Case ControlVertAlignment.Bottom
                    controlBounds.Y = cellBounds.Top + (cellBounds.Height - (Me.Padding.Bottom + Me.ControlSize.Height))
            End Select


            Select Case m_controlHorizAlignment

                Case ControlHorizAlignment.Center
                    controlBounds.X = cellBounds.Left + CInt((cellBounds.Width - Me.ControlSize.Width) / 2)

                Case ControlHorizAlignment.Right
                    controlBounds.X = cellBounds.Left + (cellBounds.Width - (Me.Padding.Right + Me.ControlSize.Width))
            End Select


            Return controlBounds
        End Function

        ' The implementation of the abstract DataGridColumnStyle methods 
        ' represent the least common functionality in all of the styles. Some
        ' methods, such as the Paint methods, need to be overridden in the
        ' subclasses.
        ' Determines how the active column cell is to react to the user's 
        ' request to interrupt the editing procedure. 
        Protected Overrides Sub Abort(ByVal rowNum As Integer)
        End Sub


        ' Initiates a request to complete an editing procedure.
        Protected Overrides Function Commit(ByVal dataSource As CurrencyManager, ByVal rowNum As Integer) As Boolean
            Return True
        End Function


        ' Prepares the cell for editing
        Protected Overloads Overrides Sub Edit(ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal bounds As Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)

        End Sub
        ' no implementation 

        ' Returns the minimum height of the data grid column cell.
        Protected Overrides Function GetMinimumHeight() As Integer
            Return GetPreferredHeight(Nothing, Nothing)
        End Function


        ' Returns the preferred height of the data grid column cell.
        Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer
            Return Me.ControlSize.Height + Me.Padding.Top + Me.Padding.Bottom
        End Function


        ' Returns the preferred size of the data grid column cell.
        Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size

            Dim width As Integer = Me.ControlSize.Width + Me.Padding.Left + Me.Padding.Right
            Dim height As Integer = Me.ControlSize.Height + Me.Padding.Top + Me.Padding.Bottom

            Return New Size(width, height)
        End Function


        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As CurrencyManager, ByVal rowNum As Integer)
            ' no implementation 
        End Sub


        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)
        End Sub

        Public Overridable Sub RemoveHandlers()

        End Sub
    End Class
    Public Class PJMColumnStylePadding

        Private m_left As Integer
        Private m_right As Integer
        Private m_top As Integer
        Private m_bottom As Integer


        Public Property Left() As Integer
            Get
                Return m_left
            End Get
            Set(ByVal Value As Integer)
                m_left = Value
            End Set
        End Property

        Public Property Right() As Integer
            Get
                Return m_right
            End Get
            Set(ByVal Value As Integer)
                m_right = Value
            End Set
        End Property

        Public Property Top() As Integer
            Get
                Return m_top
            End Get
            Set(ByVal Value As Integer)
                m_top = Value
            End Set
        End Property

        Public Property Bottom() As Integer
            Get
                Return m_bottom
            End Get
            Set(ByVal Value As Integer)
                m_bottom = Value
            End Set
        End Property

        Public Overloads Sub SetPadding(ByVal padValue As Integer)

            m_left = padValue
            m_right = padValue
            m_top = padValue
            m_bottom = padValue
        End Sub


        Public Overloads Sub SetPadding(ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer, ByVal left As Integer)
            UpdatePaddingValues(top, right, bottom, left)
        End Sub


        Public Sub New(ByVal padValue As Integer)
            Me.SetPadding(padValue)
        End Sub


        Public Sub New(ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer, ByVal left As Integer)
            UpdatePaddingValues(top, right, bottom, left)
        End Sub


        Private Sub UpdatePaddingValues(ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer, ByVal left As Integer)

            m_top = top
            m_right = right
            m_bottom = bottom
            m_left = left
        End Sub
    End Class
End Namespace