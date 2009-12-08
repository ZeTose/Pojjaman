Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports System.Data.SqlClient
Namespace Longkong.Pojjaman.Commands
    Public Class ShowRef
        Inherits AbstractEntityAccessCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is ISimpleEntity Then
                Dim theEntity As ISimpleEntity = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity
                If TypeOf theEntity Is SimpleBusinessEntityBase Then
                    Dim dt As DataTable = CType(theEntity, SimpleBusinessEntityBase).GetReferenceDocs
                    If dt Is Nothing Then
                        Return
                    End If
                    Dim sMessage As String = ""
                    For Each row As DataRow In dt.Rows
                        Dim sThisMessage As String

                        Dim dr As DataRow = SimpleBusinessEntityBase.GetEntityRow(CInt(row("refto_id")), CInt(row("refto_type")))

                        Dim prefix As String = CStr(row("entity_prefix"))
                        Dim theCode As String = ""
                        If Not dr Is Nothing AndAlso dr.Table.Columns.Contains(prefix & "_code") Then
                            theCode = CStr(dr(prefix & "_code"))
                        End If
                        sThisMessage = row("entity_description").ToString & ":" & theCode

                        If Len(sThisMessage) > 0 Then
                            If Len(sMessage) > 0 Then
                                sMessage &= vbCrLf
                            End If
                            sMessage &= " - " & sThisMessage
                        End If
                    Next
                    MessageBox.Show(sMessage)
                End If
            End If
        End Sub
        Public Overrides Property IsEnabled() As Boolean
            Get
                If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
                    Return MyBase.IsEnabled
                End If
                If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing Then
                    Return MyBase.IsEnabled
                End If
                If Not TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is ISimpleListPanel Then
                    Return MyBase.IsEnabled
                End If
                Return MyBase.IsEnabledWithChecking
            End Get
            Set(ByVal Value As Boolean)
                MyBase.IsEnabled = Value
            End Set
        End Property
        Public Overrides ReadOnly Property ValidLevel() As Integer
            Get
                Return 1
            End Get
        End Property
#End Region


    End Class
End Namespace
