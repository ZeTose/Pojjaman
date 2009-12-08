Namespace Longkong.Pojjaman.Gui.Components
#Region "Enum"
    Public Enum PlusMinusState
        Expanded
        Collapsed
        UnderParent
        Total
        None
    End Enum
#End Region
    Public Class ExpandableDataRow
        Inherits DataRow

#Region "Events"
        Delegate Sub ExpandHandler(ByVal e As ExpandCollapseEventArgs)
        Delegate Sub CollapseHandler(ByVal e As ExpandCollapseEventArgs)
        Public Event Expand As ExpandHandler
        Public Event Collapse As CollapseHandler
#End Region

#Region "Members"
        Private m_plusMinusState As PlusMinusState
        Private m_backColor As Color
        Private m_font As Font
        Private m_level As Integer
        Private m_childs As ExpandableDatarowCollection
        Private m_index As Integer
        Private m_parent As ExpandableDataRow
#End Region

#Region "Constructors"
        Public Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.m_plusMinusState = PlusMinusState.UnderParent
            Me.m_backColor = Color.Empty
            m_childs = New ExpandableDatarowCollection
        End Sub
#End Region

#Region "Properties"
        Public Property Parent() As ExpandableDataRow            Get                Return m_parent            End Get            Set(ByVal Value As ExpandableDataRow)                m_parent = Value            End Set        End Property
        Public Property Index() As Integer            Get                Return m_index            End Get            Set(ByVal Value As Integer)                m_index = Value            End Set        End Property        Public Property Level() As Integer            Get                Return m_level            End Get            Set(ByVal Value As Integer)                m_level = Value            End Set        End Property
        Public Property State() As PlusMinusState
            Get
                Return m_plusMinusState
            End Get
            Set(ByVal Value As PlusMinusState)
                m_plusMinusState = Value
                If m_plusMinusState = PlusMinusState.Expanded Then
                    RaiseEvent Expand(New ExpandCollapseEventArgs(Me))
                ElseIf m_plusMinusState = PlusMinusState.Collapsed Then
                    RaiseEvent Collapse(New ExpandCollapseEventArgs(Me))
                End If
            End Set
        End Property
        Public Property BackColor() As Color
            Get
                Return m_backColor
            End Get
            Set(ByVal Value As Color)
                m_backColor = Value
            End Set
        End Property
        Public Property Font() As Font
            Get
                Return m_font
            End Get
            Set(ByVal Value As Font)
                m_font = Value
            End Set
        End Property
        Public Property Childs() As ExpandableDatarowCollection            Get                Return m_childs            End Get            Set(ByVal Value As ExpandableDatarowCollection)                m_childs = Value            End Set        End Property        Public ReadOnly Property PreviousSibling() As ExpandableDataRow
            Get
                If m_level = 0 Then
                    Dim dt As ExpandableRowDataTable = CType(Me.Table, ExpandableRowDataTable)
                    Dim childIndex As Integer = dt.Childs.IndexOf(Me)
                    If childIndex > 0 Then
                        Return dt.Childs(childIndex - 1)
                    End If
                ElseIf Not IsNothing(m_parent) AndAlso m_parent.Childs.Count > 0 Then
                    Dim childIndex As Integer = m_parent.Childs.IndexOf(Me)
                    If childIndex > 0 Then
                        Return m_parent.Childs(childIndex - 1)
                    End If
                End If
            End Get
        End Property        Public ReadOnly Property NextSibling() As ExpandableDataRow
            Get
                If m_level = 0 Then
                    Dim dt As ExpandableRowDataTable = CType(Me.Table, ExpandableRowDataTable)
                    Dim childIndex As Integer = dt.Childs.IndexOf(Me)
                    If childIndex < dt.Childs.Count - 1 Then
                        Return dt.Childs(childIndex + 1)
                    End If
                ElseIf Not IsNothing(m_parent) AndAlso m_parent.Childs.Count > 0 Then
                    Dim childIndex As Integer = m_parent.Childs.IndexOf(Me)
                    If childIndex < m_parent.Childs.Count - 1 Then
                        Return m_parent.Childs(childIndex + 1)
                    End If
                End If
            End Get
        End Property        Public ReadOnly Property FirstChild() As ExpandableDataRow
            Get
                Return Childs(0)
            End Get
        End Property        Public ReadOnly Property LastChild() As ExpandableDataRow
            Get
                If Childs.Count > 0 Then
                    Return Childs(Childs.Count - 1)
                Else
                    Return Nothing
                End If
            End Get
        End Property#End Region

#Region "Methods"
        Public Sub EnsureVisible()
            EnsureVisible(Me)
        End Sub
        Private Sub EnsureVisible(ByVal row As ExpandableDataRow)
            If row.Parent Is Nothing Then
                Return
            End If
            EnsureVisible(row.Parent)
            If row.Parent.State <> PlusMinusState.Expanded Then
                row.Parent.State = PlusMinusState.Expanded
            End If
        End Sub
#End Region

        Public Class ExpandableDatarowCollection
            Inherits CollectionBase
            Public Shadows Function Add(ByVal row As ExpandableDataRow) As ExpandableDataRow
                MyBase.List.Add(row)
                Return row
            End Function

            Public Shadows Sub Remove(ByVal row As ExpandableDataRow)
                MyBase.List.Remove(row)
            End Sub
            Default Public Property Item(ByVal index As Integer) As ExpandableDataRow
                Get
                    If InnerList.Count > 0 Then
                        Return CType(InnerList(index), ExpandableDataRow)
                    Else
                        Return Nothing
                    End If
                End Get
                Set(ByVal Value As ExpandableDataRow)
                    InnerList(index) = Value
                End Set
            End Property
            Public Function IndexOf(ByVal row As ExpandableDataRow) As Integer
                Return InnerList.IndexOf(row)
            End Function
            Public Function InsertAt(ByVal index As Integer, ByVal row As ExpandableDataRow) As ExpandableDataRow
                MyBase.List.Insert(index, row)
                Return row
            End Function
        End Class
    End Class
End Namespace

