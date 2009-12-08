Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports System.Windows.Forms
Imports System.Collections.Specialized
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Core.Services
    Public Enum EntityErrorPolicy
        Inform
        ProvideAlternative
    End Enum
    Public Enum EntityOperationResult
        OK
        Failed
        SavedAlternatively
    End Enum

    Public Delegate Sub NamedEntityOperationDelegate(ByVal entity As ISimpleEntity)
    Public Delegate Sub EntityOperationDelegate()
    Public Class EntityUtilityService
        Inherits AbstractService

#Region "Members"
        Private Shared ReadOnly m_separators As Char() = New Char() {Path.DirectorySeparatorChar, Path.VolumeSeparatorChar}
        Private m_pojjamanRootPath As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_pojjamanRootPath = (Path.GetDirectoryName([Assembly].GetEntryAssembly.Location) & Path.DirectorySeparatorChar & "..")
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"
        Public Overrides Sub InitializeService()
            MyBase.InitializeService()
        End Sub
        Public Function ObservedLoad(ByVal loadEntity As NamedEntityOperationDelegate, ByVal entity As ISimpleEntity) As EntityOperationResult
            Return Me.ObservedLoad(loadEntity, entity, EntityErrorPolicy.Inform)
        End Function
        Public Function ObservedLoad(ByVal loadEntity As NamedEntityOperationDelegate, ByVal entity As ISimpleEntity, ByVal policy As EntityErrorPolicy) As EntityOperationResult
            Dim resourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
            Return Me.ObservedLoad(loadEntity, entity, resourceService.GetString("Pojjaman.Services.EntityUtilityService.CantLoadEntityStandardText"), policy)
        End Function
        Public Function ObservedLoad(ByVal loadEntity As NamedEntityOperationDelegate, ByVal entity As ISimpleEntity, ByVal message As String, ByVal policy As EntityErrorPolicy) As EntityOperationResult
            Return Me.ObservedLoad(New EntityOperationDelegate(AddressOf New LoadWrapper(loadEntity, entity).Invoke), entity, message, policy)
        End Function
        Public Function ObservedLoad(ByVal loadEntity As EntityOperationDelegate, ByVal entity As ISimpleEntity, ByVal message As String, ByVal policy As EntityErrorPolicy) As EntityOperationResult
            Try
                loadEntity()
                Return EntityOperationResult.OK
            Catch e As Exception
                Select Case policy
                    Case EntityErrorPolicy.Inform
                        Dim informDialog As New SaveErrorInformDialog(entity.ClassName, message, "${res:EntityUtilityService.ErrorWhileLoading}", e)
                        Try
                            informDialog.ShowDialog()
                        Finally
                            informDialog.Dispose()
                        End Try
                    Case EntityErrorPolicy.ProvideAlternative
                        Dim chooseDialog As New SaveErrorChooseDialog(entity.ClassName, message, "${res:EntityUtilityService.ErrorWhileLoading}", e, False)
                        Try
                            Select Case chooseDialog.ShowDialog()
                                Case DialogResult.OK ' choose location (never happens here)
                                Case DialogResult.Retry
                                    Return ObservedLoad(loadEntity, entity, message, policy)
                                Case DialogResult.Ignore
                                    Return EntityOperationResult.Failed
                            End Select
                        Finally
                            chooseDialog.Dispose()
                        End Try
                End Select
            End Try
            Return EntityOperationResult.Failed
        End Function
        Public Function ObservedSave(ByVal saveEntity As EntityOperationDelegate, ByVal entity As ISimpleEntity) As EntityOperationResult
            Return Me.ObservedSave(saveEntity, entity, EntityErrorPolicy.Inform)
        End Function
        Public Function ObservedSave(ByVal saveEntity As EntityOperationDelegate, ByVal entity As ISimpleEntity, ByVal policy As EntityErrorPolicy) As EntityOperationResult
            Dim resourceService As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
            Return Me.ObservedSave(saveEntity, entity, resourceService.GetString("ICSharpCode.Services.EntityUtilityService.CantSaveFileStandardText"), policy)
        End Function
        Public Function ObservedSave(ByVal saveEntity As EntityOperationDelegate, ByVal entity As ISimpleEntity, ByVal message As String, ByVal policy As EntityErrorPolicy) As EntityOperationResult
            Try
                saveEntity()
                Return EntityOperationResult.OK
            Catch e As Exception
                Select Case policy
                    Case EntityErrorPolicy.Inform
                        Dim informDialog As New SaveErrorInformDialog(entity.ClassName, message, "${res:EntityUtilityService.ErrorWhileSaving}", e)
                        Try
                            informDialog.ShowDialog()
                        Finally
                            informDialog.Dispose()
                        End Try
                    Case EntityErrorPolicy.ProvideAlternative
                        Dim chooseDialog As New SaveErrorChooseDialog(entity.ClassName, message, "${res:EntityUtilityService.ErrorWhileSaving}", e, False)
                        Try
                            Select Case chooseDialog.ShowDialog()
                                Case DialogResult.OK ' choose location (never happens here)
                                Case DialogResult.Retry
                                    Return ObservedSave(saveEntity, entity, message, policy)
                                Case DialogResult.Ignore
                                    Return EntityOperationResult.Failed
                            End Select
                        Finally
                            chooseDialog.Dispose()
                        End Try
                End Select
            End Try
            Return EntityOperationResult.Failed
        End Function
        Public Overrides Sub UnloadService()
            MyBase.UnloadService()
        End Sub
#End Region

#Region "LoadWrapper Class"
        Private Class LoadWrapper

#Region "Members"
            Private m_entity As ISimpleEntity
            Private m_loadEntity As NamedEntityOperationDelegate
#End Region

#Region "Constructors"
            Public Sub New(ByVal loadEntity As NamedEntityOperationDelegate, ByVal entity As ISimpleEntity)
                Me.m_loadEntity = loadEntity
                Me.m_entity = entity
            End Sub
#End Region

#Region "Methods"
            Public Sub Invoke()
                Me.m_loadEntity.Invoke(Me.m_entity)
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace

