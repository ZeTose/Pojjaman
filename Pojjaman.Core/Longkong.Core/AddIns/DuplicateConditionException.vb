Imports System.Collections.Specialized
Namespace Longkong.Core.AddIns
    Public Class DuplicateConditionException
        Inherits Exception

#Region "Constructors"
        Public Sub New(ByVal attributes As StringCollection)
            MyBase.New(("there already exists a condition with the required attributes : " & DuplicateConditionException.GenAttrList(attributes)))
        End Sub
#End Region

#Region "Methods"
        Private Shared Function GenAttrList(ByVal attributes As StringCollection) As String
            Dim attrList As String = ""
            For Each attr As String In attributes
                attrList = (attrList & " " & attr)
            Next
            Return attrList
        End Function
#End Region

    End Class
End Namespace
