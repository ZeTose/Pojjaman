Imports System
Imports System.Reflection
Namespace Longkong.Pojjaman.Gui.Components
    Public Class DataGridRowHeightSetter
        Private dg As DataGrid
        Private rowObjects As ArrayList

        Public Sub New(ByVal dg As DataGrid)
            Me.dg = dg
            RefreshHeights()
        End Sub
        Public Sub RefreshHeights()
            If Me.dg Is Nothing Then
                Return
            End If
            Dim mi As MethodInfo = (New DataGrid).GetType().GetMethod("get_DataGridRows", BindingFlags.FlattenHierarchy Or BindingFlags.IgnoreCase Or BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Static)

            Dim dgra As System.Array = CType(mi.Invoke(Me.dg, Nothing), System.Array)

            rowObjects = New ArrayList
            Dim dgrr As Object
            For Each dgrr In dgra
                If dgrr.ToString().EndsWith("DataGridRelationshipRow") = True Then
                    rowObjects.Add(dgrr)
                End If
            Next dgrr
        End Sub
        Default Public Property Item(ByVal row As Integer) As Integer
            Get
                Try
                    Dim pi As PropertyInfo = rowObjects(row).GetType().GetProperty("Height")
                    Return Fix(CInt((pi.GetValue(rowObjects(row), Nothing))))
                Catch
                    Throw New ArgumentException("invalid row index")
                End Try
            End Get
            Set(ByVal Value As Integer)
                Try
                    Dim pi As PropertyInfo = rowObjects(row).GetType().GetProperty("Height")
                    pi.SetValue(rowObjects(row), Value, Nothing)
                Catch
                    Throw New ArgumentException("invalid row index:" & row)
                End Try
            End Set
        End Property
    End Class
End Namespace
