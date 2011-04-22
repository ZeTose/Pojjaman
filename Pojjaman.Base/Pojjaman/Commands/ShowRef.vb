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
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Collections.Generic
Imports System.IO

Namespace Longkong.Pojjaman.Commands
  Public Class ShowRef
    Inherits AbstractEntityAccessCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Private rd As RefDialog
    Public Overrides Sub Run()
      If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is ISimpleEntity Then
        Dim theEntity As ISimpleEntity = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity
        If TypeOf theEntity Is SimpleBusinessEntityBase Then
          Dim ds As DataSet = CType(theEntity, SimpleBusinessEntityBase).GetReferenceDocs
          Dim dt As DataTable
          Dim dt2 As DataTable
          dt = ds.Tables(0)
          dt2 = ds.Tables(1)
          rd = New RefDialog
          rd.dt1 = dt
          rd.dt2 = dt2
          rd.ShowDialog()
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
        'เอาแค่ Read ก็เปิด Ref ได้
        Return 0
      End Get
    End Property
#End Region
  End Class

  Public Class ShowPrintLog
    Inherits AbstractEntityAccessCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Private rd As RefPrintDialog
    Public Overrides Sub Run()
      If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is ISimpleEntity Then
        Dim theEntity As ISimpleEntity = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity
        If TypeOf theEntity Is SimpleBusinessEntityBase Then
          Dim ds As DataSet = CType(theEntity, SimpleBusinessEntityBase).GetPrintLogs
          Dim dt As DataTable
          If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
            rd = New RefPrintDialog
            rd.dt1 = dt
            rd.ShowDialog()
          End If
        End If
      End If
    End Sub
    Private Shared m_fileList As List(Of String)
    Public Shared ReadOnly Property FileList As List(Of String)
      Get
        If m_fileList Is Nothing Then
          m_fileList = New List(Of String)
        End If
        Return m_fileList
      End Get
    End Property
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
