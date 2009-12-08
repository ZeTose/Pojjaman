Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Namespace Longkong.Pojjaman.Gui.Components
    Public Class ControlPropertyDescriptor
        Inherits PropertyDescriptor

#Region "Members"
        Private m_basePropertyDescriptor As PropertyDescriptor
        Private m_parsedName As String = ""
        Private m_parsedDescription As String = ""
        Private m_parsedCategory As String = ""
#End Region

#Region "Constructors"
        Public Sub New(ByVal basePropertyDescriptor As PropertyDescriptor)
            MyBase.New(basePropertyDescriptor)
            Me.m_basePropertyDescriptor = basePropertyDescriptor
        End Sub
#End Region

#Region "Overrides"
        Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
            Return Me.m_basePropertyDescriptor.CanResetValue(component)
        End Function

        Public Overrides ReadOnly Property ComponentType() As System.Type
            Get
                Return Me.m_basePropertyDescriptor.ComponentType
            End Get
        End Property

        Public Overrides Function GetValue(ByVal component As Object) As Object
            Return Me.m_basePropertyDescriptor.GetValue(component)
        End Function

        Public Overrides ReadOnly Property IsReadOnly() As Boolean
            Get
                Return Me.m_basePropertyDescriptor.IsReadOnly
            End Get
        End Property

        Public Overrides ReadOnly Property PropertyType() As System.Type
            Get
                Return Me.m_basePropertyDescriptor.PropertyType
            End Get
        End Property

        Public Overrides Sub ResetValue(ByVal component As Object)
            Me.m_basePropertyDescriptor.ResetValue(component)
        End Sub

        Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
            Me.m_basePropertyDescriptor.SetValue(component, value)
        End Sub

        Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
            Return Me.m_basePropertyDescriptor.ShouldSerializeValue(component)
        End Function

        Public Overrides ReadOnly Property Name() As String
            Get
                Return Me.m_basePropertyDescriptor.Name
            End Get
        End Property
#End Region

#Region "Parsing"
        Private Function Parse(ByVal s As String) As String
            'Todo : Implement!!!
            Select Case s.ToLower
                Case "appearance"
                    s = "ลักษณะ"
                Case "layout"
                    s = "การจัดวาง"
                Case "design"
                    s = "การออกแบบ"
                Case "behavior"
                    s = "พฤติกรรม"
                Case Else
            End Select

            Return s
        End Function
        Public Overrides ReadOnly Property DisplayName() As String
            Get
                Dim myDisplayName As String = ""
                For Each oAtt As Attribute In Me.m_basePropertyDescriptor.Attributes
                    If TypeOf oAtt Is ControlPropertyAttribute Then
                        myDisplayName = CType(oAtt, ControlPropertyAttribute).Name
                    End If
                Next
                If myDisplayName.Length = 0 Then
                    myDisplayName = Me.m_basePropertyDescriptor.DisplayName
                End If
                myDisplayName = Me.Parse(myDisplayName)
                If myDisplayName Is Nothing Then
                    Me.m_parsedName = Me.m_basePropertyDescriptor.DisplayName
                Else
                    Me.m_parsedName = myDisplayName
                End If
                Return Me.m_parsedName
            End Get
        End Property

        Public Overrides ReadOnly Property Description() As String
            Get
                Dim myDescription As String = ""
                For Each oAtt As Attribute In Me.m_basePropertyDescriptor.Attributes
                    If TypeOf oAtt Is ControlPropertyAttribute Then
                        myDescription = CType(oAtt, ControlPropertyAttribute).Description
                    End If
                Next
                If myDescription.Length = 0 Then
                    myDescription = Me.m_basePropertyDescriptor.DisplayName & "Description"
                End If
                myDescription = Me.Parse(myDescription)
                If myDescription Is Nothing Then
                    Me.m_parsedDescription = Me.m_basePropertyDescriptor.Description
                Else
                    Me.m_parsedDescription = myDescription
                End If
                Return Me.m_parsedDescription
            End Get
        End Property

        Public Overrides ReadOnly Property Category() As String
            Get
                Dim myCategory As String = ""
                For Each oAtt As Attribute In Me.m_basePropertyDescriptor.Attributes
                    If TypeOf oAtt Is ControlPropertyAttribute Then
                        myCategory = CType(oAtt, ControlPropertyAttribute).Category
                        Exit For
                    End If
                    If TypeOf oAtt Is CategoryAttribute Then
                        myCategory = CType(oAtt, CategoryAttribute).Category
                    End If
                Next
                If myCategory Is Nothing OrElse myCategory.Length = 0 Then
                    myCategory = Me.m_basePropertyDescriptor.Category
                End If
                myCategory = Me.Parse(myCategory)
                If myCategory Is Nothing Then
                    Me.m_parsedCategory = Me.m_basePropertyDescriptor.Category
                Else
                    Me.m_parsedCategory = myCategory
                End If
                Return Me.m_parsedCategory
            End Get
        End Property
#End Region


    End Class
End Namespace
