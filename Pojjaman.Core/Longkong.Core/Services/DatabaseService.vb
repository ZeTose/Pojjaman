Imports Longkong.Core.Properties
Imports System.Text.RegularExpressions
Imports Longkong.Core.Services
Imports System.Windows.Forms
Namespace Longkong.Core.Services
    Public Class DatabaseService
        Inherits AbstractService

#Region "Members"
        Private Shared m_connectionString As String
#End Region

#Region "Constructors"
        Public Sub New()

        End Sub
#End Region

#Region "Properties"
        Public Shared ReadOnly Property ConnectionString() As String            Get                Return m_connectionString            End Get        End Property#End Region

#Region "Methods"
        Public Sub SetConnString()

        End Sub
        Private Sub PopulateServerList(ByVal cmbServerList As ComboBox)
            'Try
            '    Dim sqlServers As SQLDMO.NameList = New SQLDMO.Application().ListAvailableSQLServers
            '    For i As Integer = 1 To sqlServers.Count
            '        Dim srv As Object = sqlServers.Item(i)
            '        cmbServerList.Items.Add(srv)
            '    Next
            '    If cmbServerList.Items.Count > 0 Then
            '        cmbServerList.SelectedIndex = 0
            '    Else
            '        cmbServerList.Text = "<No Server Available>"
            '    End If
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString)
            'End Try
        End Sub
#End Region

#Region "Overrides"
        Public Overrides Sub InitializeService()
            MyBase.InitializeService()
        End Sub
        Public Overrides Sub UnloadService()
            MyBase.UnloadService()
        End Sub
#End Region

    End Class
End Namespace

