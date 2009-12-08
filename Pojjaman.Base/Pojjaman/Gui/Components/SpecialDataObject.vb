Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class SpecialDataObject
        Implements IDataObject

#Region "Members"
        Private m_dataObjects As ArrayList
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_dataObjects = New ArrayList
        End Sub
#End Region

#Region "IDataObject"
        Public Overloads Function GetData(ByVal format As String) As Object Implements System.Windows.Forms.IDataObject.GetData
            Return Me.GetData(format, True)
        End Function
        Public Overloads Function GetData(ByVal format As String, ByVal autoConvert As Boolean) As Object Implements System.Windows.Forms.IDataObject.GetData
            For Each obj As Object In Me.m_dataObjects
                If Not obj Is Nothing Then
                    Dim typeName As String = obj.GetType.ToString
                    If (typeName = format) Then
                        Return obj
                    End If
                    If (typeName = "Longkong.Pojjaman.Gui.Components.PojjamanSideTabItem") AndAlso (format = "TimeSprint.Alexandria.UI.SideBar.AxSideTabItem") Then
                        Return obj
                    End If
                End If
            Next
            Return Nothing
        End Function
        Public Overloads Function GetData(ByVal format As System.Type) As Object Implements System.Windows.Forms.IDataObject.GetData
            Dim obj As Object
            For Each obj In Me.m_dataObjects
                If (obj.GetType Is format) Then
                    Return obj
                End If
            Next
            Return Nothing
        End Function
        Public Overloads Function GetDataPresent(ByVal format As String) As Boolean Implements System.Windows.Forms.IDataObject.GetDataPresent
            Return Me.GetDataPresent(format, True)
        End Function
        Public Overloads Function GetDataPresent(ByVal format As String, ByVal autoConvert As Boolean) As Boolean Implements System.Windows.Forms.IDataObject.GetDataPresent
            Return (Not Me.GetData(format, autoConvert) Is Nothing)
        End Function
        Public Overloads Function GetDataPresent(ByVal format As System.Type) As Boolean Implements System.Windows.Forms.IDataObject.GetDataPresent
            Return (Not Me.GetData(format) Is Nothing)
        End Function
        Public Overloads Function GetFormats() As String() Implements System.Windows.Forms.IDataObject.GetFormats
            Return Nothing
        End Function
        Public Overloads Function GetFormats(ByVal autoConvert As Boolean) As String() Implements System.Windows.Forms.IDataObject.GetFormats
            Return Nothing
        End Function
        Public Overloads Sub SetData(ByVal format As String, ByVal autoConvert As Boolean, ByVal data As Object) Implements System.Windows.Forms.IDataObject.SetData
            '----------
        End Sub
        Public Overloads Sub SetData(ByVal format As String, ByVal data As Object) Implements System.Windows.Forms.IDataObject.SetData
            '----------
        End Sub
        Public Overloads Sub SetData(ByVal data As Object) Implements System.Windows.Forms.IDataObject.SetData
            Me.m_dataObjects.Add(data)
        End Sub
        Public Overloads Sub SetData(ByVal format As System.Type, ByVal data As Object) Implements System.Windows.Forms.IDataObject.SetData
            '----------
        End Sub
#End Region

    End Class
End Namespace

