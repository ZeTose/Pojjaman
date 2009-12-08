Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace Longkong.Pojjaman.DataAccessLayer
    Public Class PropertyHelper
        Private Sub New()
        End Sub
        Public Shared Sub ListPropertyDescriptors(ByVal b As Object)
            Debug.WriteLine("Printing Property Descriptions")
            Dim ps As PropertyDescriptorCollection = TypeDescriptor.GetProperties(b)
            Dim i As Integer
            For i = 0 To ps.Count - 1
                Debug.WriteLine((ControlChars.Tab & ps(i).Name & ControlChars.Tab & ps(i).PropertyType.ToString))
                Debug.Write(Environment.NewLine)
            Next i
        End Sub
    End Class
End Namespace
