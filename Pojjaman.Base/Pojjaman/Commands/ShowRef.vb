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

          Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
          rd = New RefDialog
          Dim lbl As New Label
          lbl.Text = myStringParserService.Parse("${res:Commands.ShowRef.lbl}") '"ถูกอ้างอิงไปที่: (ดับเบิ้ลคลิกเพื่อไปยังเอกสาร)"
          lbl.Width = rd.FlowLayoutPanel1.Width - 5
          rd.FlowLayoutPanel1.Controls.Add(lbl)
          For Each row As DataRow In dt.Rows
            Dim deh As New DataRowHelper(row)
            Dim prefix As String = deh.GetValue(Of String)("entity_prefix")
            Dim theDescription As String = deh.GetValue(Of String)("entity_description")
            Dim fullClassName As String = deh.GetValue(Of String)("entity_fullClassName")

            Dim thisMessage As String

            Dim dr As DataRow = SimpleBusinessEntityBase.GetEntityRow(CInt(row("refto_id")), CInt(row("refto_type")))

            deh = New DataRowHelper(dr)


            Dim theCode As String = deh.GetValue(Of String)(prefix & "_code")
            Dim theId As Integer = deh.GetValue(Of Integer)(prefix & "_id")

            thisMessage = theDescription & ":" & theCode

            Dim tb As New TextBox
            tb.Text = thisMessage
            tb.ReadOnly = True
            tb.Width = rd.FlowLayoutPanel1.Width - 5
            tb.Tag = New KeyValuePair(Of Integer, String)(theId, fullClassName)
            AddHandler tb.DoubleClick, AddressOf tb_DoubleClick
            rd.FlowLayoutPanel1.Controls.Add(tb)
          Next
          Dim lbl2 As New Label
          lbl2.Text = myStringParserService.Parse("${res:Commands.ShowRef.lbl2}") '"อ้างอิงมาจาก: (ดับเบิ้ลคลิกเพื่อไปยังเอกสาร)"
          lbl2.Width = rd.FlowLayoutPanel1.Width - 5
          Dim linklbl As New LinkLabel
          rd.FlowLayoutPanel1.Controls.Add(lbl2)
          For Each row As DataRow In dt2.Rows
            Dim deh As New DataRowHelper(row)
            Dim prefix As String = deh.GetValue(Of String)("entity_prefix")
            Dim theDescription As String = deh.GetValue(Of String)("entity_description")
            Dim fullClassName As String = deh.GetValue(Of String)("entity_fullClassName")

            Dim thisMessage As String

            Dim dr As DataRow = SimpleBusinessEntityBase.GetEntityRow(CInt(row("entity_id")), CInt(row("entity_type")))

            deh = New DataRowHelper(dr)


            Dim theCode As String = deh.GetValue(Of String)(prefix & "_code")
            Dim theId As Integer = deh.GetValue(Of Integer)(prefix & "_id")

            thisMessage = theDescription & ":" & theCode

            Dim tb As New TextBox
            tb.Text = thisMessage
            tb.ReadOnly = True
            tb.Width = rd.FlowLayoutPanel1.Width - 5
            tb.Tag = New KeyValuePair(Of Integer, String)(theId, fullClassName)
            AddHandler tb.DoubleClick, AddressOf tb_DoubleClick
            rd.FlowLayoutPanel1.Controls.Add(tb)
          Next
          rd.ShowDialog()
        End If
      End If
    End Sub
    Private Sub tb_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
      Dim ctrl As Control = CType(sender, Control)
      Dim kv As KeyValuePair(Of Integer, String) = CType(ctrl.Tag, Global.System.Collections.Generic.KeyValuePair(Of Integer, String))
      Dim theId As Integer = kv.Key
      Dim theType As String = kv.Value
      Dim theEntity As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(theType, theId)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenDetailPanel(theEntity)
      If Not rd Is Nothing Then
        rd.Close()
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

  Public Class ShowPrintLog
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
          Dim ds As DataSet = CType(theEntity, SimpleBusinessEntityBase).GetPrintLogs
          Dim dt As DataTable
          If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            rd = New RefDialog
            Dim lbl As New Label
            lbl.Text = "Printing:"
            lbl.Width = rd.FlowLayoutPanel1.Width - 5
            rd.FlowLayoutPanel1.Controls.Add(lbl)
            For Each row As DataRow In dt.Rows
              Dim deh As New DataRowHelper(row)
              Dim printTime As String = deh.GetValue(Of Date)("printtime").ToString
              Dim printUser As String = deh.GetValue(Of String)("user_name")
              Dim theData() As Byte = CType(row("XPS"), Byte())
              Dim thisMessage As String

              thisMessage = printTime & ":" & printUser

              Dim tb As New TextBox
              tb.Text = thisMessage
              tb.ReadOnly = True
              tb.Width = rd.FlowLayoutPanel1.Width - 5
              tb.Tag = theData
              AddHandler tb.DoubleClick, AddressOf tb_DoubleClick
              rd.FlowLayoutPanel1.Controls.Add(tb)
            Next
            rd.ShowDialog()
          End If
        End If
      End If
    End Sub
    Private Sub tb_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
      Dim ctrl As Control = CType(sender, Control)
      Dim data() As Byte = CType(ctrl.Tag, Byte())
      Try
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim xpsDIR As String = myPropertyService.GetProperty("XPSDIR", "C:\")
        Dim fileName As String = xpsDIR & Path.DirectorySeparatorChar & Now.Ticks.ToString & "tmp.xps"
        Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)
        Dim bw As New BinaryWriter(fs)
        bw.Write(data)
        bw.Close()
        If Not rd Is Nothing Then
          rd.Close()
        End If
        Process.Start(fileName)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
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
