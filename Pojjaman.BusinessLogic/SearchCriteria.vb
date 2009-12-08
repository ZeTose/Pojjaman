Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports System.Configuration
Imports System.Reflection
Namespace Longkong.Pojjaman.BusinessLogic
    Public Enum CriteriaType
        FixValue
        Range
        [AND]
        [OR]
        OpenParenthesis
        CloseParenthesis
    End Enum
    Public Class ANDCriteria
        Inherits SearchCriteria

#Region "Constructors"
        Public Sub New()
            Me.LabelText = "AND"
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CriteriaType() As CriteriaType
            Get
                Return CriteriaType.AND
            End Get
        End Property
#End Region

    End Class
    Public Class ORCriteria
        Inherits SearchCriteria

#Region "Constructors"
        Public Sub New()
            Me.LabelText = "OR"
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CriteriaType() As CriteriaType
            Get
                Return CriteriaType.OR
            End Get
        End Property
#End Region

    End Class
    Public Class OpenParenthesisCriteria
        Inherits SearchCriteria

#Region "Constructors"
        Public Sub New()
            Me.LabelText = "("
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CriteriaType() As CriteriaType
            Get
                Return CriteriaType.OpenParenthesis
            End Get
        End Property
#End Region

    End Class
    Public Class CloseParenthesisCriteria
        Inherits SearchCriteria

#Region "Constructors"
        Public Sub New()
            Me.LabelText = ")"
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CriteriaType() As CriteriaType
            Get
                Return CriteriaType.CloseParenthesis
            End Get
        End Property
#End Region

    End Class
    Public Class RangeCriteria
        Inherits SearchCriteria

#Region "Members"
        Private m_minValue As Object
        Private m_maxValue As Object
        Private m_defaultMinValue As Object
        Private m_defaultMaxValue As Object
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String, ByVal type As Type, ByVal labelText As String, ByVal defaultMinValue As Object, ByVal defaultMaxValue As Object)
            MyBase.New(name, type, labelText)
            Me.m_defaultMaxValue = defaultMaxValue
            Me.m_defaultMinValue = defaultMinValue
        End Sub
#End Region

#Region "Properties"
        Public Property MinValue() As Object            Get                If m_minValue Is Nothing Then                    Return Me.DefaultMinValue
                End If                Return m_minValue            End Get            Set(ByVal Value As Object)                m_minValue = Value            End Set        End Property
        Public Property MaxValue() As Object            Get                If m_maxValue Is Nothing Then                    Return Me.DefaultMaxValue
                End If                Return m_maxValue            End Get            Set(ByVal Value As Object)                m_maxValue = Value            End Set        End Property
        Public ReadOnly Property DefaultMinValue() As Object            Get                Return m_defaultMinValue            End Get        End Property
        Public ReadOnly Property DefaultMaxValue() As Object            Get                Return m_defaultMaxValue            End Get        End Property
        Public Overrides ReadOnly Property CriteriaType() As CriteriaType
            Get
                Return CriteriaType.Range
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overrides Function ToString() As String
            If Not Me.m_minValue Is Nothing AndAlso Not Me.m_maxValue Is Nothing Then
                Return Me.LabelText & " between " & Me.MinValue.ToString & " and " & Me.MaxValue.ToString
            End If
            Return Me.LabelText
        End Function
#End Region

    End Class
    Public Class FixValueCriteria
        Inherits SearchCriteria

#Region "Members"
        Private m_value As Object
        Private m_defautValue As Object
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String, ByVal type As Type, ByVal labelText As String, ByVal defautValue As Object)
            MyBase.New(name, type, labelText)
            Me.m_defautValue = defautValue
        End Sub
#End Region

#Region "Properties"
        Public Property Value() As Object            Get                If m_value Is Nothing Then                    Return Me.DefautValue
                End If                Return m_value            End Get            Set(ByVal Value As Object)                m_value = Value            End Set        End Property
        Public ReadOnly Property DefautValue() As Object            Get                Return m_defautValue            End Get        End Property
        Public Overrides ReadOnly Property CriteriaType() As CriteriaType
            Get
                Return CriteriaType.FixValue
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overrides Function ToString() As String
            If Not Me.m_value Is Nothing Then
                Return Me.LabelText & " is " & Me.Value.ToString
            End If
            Return Me.LabelText
        End Function
#End Region

    End Class
    Public Class SearchCriteria

#Region "Members"
        Private m_name As String
        Private m_type As Type
        Private m_labelText As String
        Private m_criteriaType As CriteriaType
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal name As String, ByVal type As Type, ByVal labelText As String)
            m_name = name
            m_type = type
            m_labelText = labelText
        End Sub
#End Region

#Region "Methods"
        Public Overrides Function ToString() As String
            Return m_labelText
        End Function
#End Region

#Region "Properties"
        Public Property Name() As String            Get                Return m_name            End Get            Set(ByVal Value As String)                m_name = Value            End Set        End Property        Public Property Type() As Type            Get                Return m_type            End Get            Set(ByVal Value As Type)                m_type = Value
            End Set        End Property        Public Property LabelText() As String            Get                Return m_labelText            End Get            Set(ByVal Value As String)                m_labelText = Value            End Set        End Property
        Public Overridable ReadOnly Property CriteriaType() As CriteriaType            Get                Return m_criteriaType            End Get        End Property
#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
    Public Class SearchCriteriaCollection
        Inherits CollectionBase

#Region "Members"
        Private m_panelText As String
#End Region

#Region "Properties"
        Public Property PanelText() As String            Get                Return m_panelText            End Get            Set(ByVal Value As String)                m_panelText = Value            End Set        End Property
        Default Public Property Item(ByVal index As Integer) As SearchCriteria
            Get
                Return CType(MyBase.List.Item(index), SearchCriteria)
            End Get
            Set(ByVal value As SearchCriteria)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function Add(ByVal value As SearchCriteria) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As SearchCriteriaCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As SearchCriteria())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As SearchCriteria) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As SearchCriteria(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ItemEnumerator
            Return New ItemEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As SearchCriteria) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As SearchCriteria)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As SearchCriteria)
            MyBase.List.Remove(value)
        End Sub
#End Region


        Public Class ItemEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As SearchCriteriaCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, SearchCriteria)
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                Return Me.m_baseEnumerator.MoveNext
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                Me.m_baseEnumerator.Reset()
            End Sub
        End Class
    End Class
End Namespace

