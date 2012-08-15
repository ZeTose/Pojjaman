Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Properties
'Imports Longkong.Pojjaman.DataAccessLayer
'Imports Longkong.Pojjaman.Gui.ReportsAndDocs

Imports System.IO
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Net
'Imports System.Reflection
'Imports System.Drawing.Printing
'Imports System.Drawing
'Imports System.Drawing.Drawing2D
'Imports System.Data.Objects

Imports Syncfusion.Windows.Forms.Grid

Imports Newtonsoft.Json
Imports System.Text


Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BuilkMatchView
    'Inherits UserControl
    Inherits AbstractEntityPanelViewContent
    Implements ISaveContent ', IPrintableEntity
    'Implements ISimpleListPanel 'IValidatable, 

#Region " Windows Form Designer generated code "
    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents tgitem As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents GridControl1 As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.GridControl1 = New Syncfusion.Windows.Forms.Grid.GridControl()
      Me.tgitem = New Syncfusion.Windows.Forms.Grid.GridControl()
      Me.btnRefresh = New System.Windows.Forms.Button()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgitem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Nothing
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'GridControl1
      '
      Me.GridControl1.Location = New System.Drawing.Point(0, 0)
      Me.GridControl1.Name = "GridControl1"
      Me.GridControl1.Size = New System.Drawing.Size(130, 80)
      Me.GridControl1.SmartSizeBox = False
      '
      'tgitem
      '
      Me.tgitem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgitem.DefaultGridBorderStyle = Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid
      Me.tgitem.DefaultRowHeight = 20
      Me.tgitem.ExcelLikeSelectionFrame = True
      Me.tgitem.Location = New System.Drawing.Point(14, 38)
      Me.tgitem.Name = "tgitem"
      Me.tgitem.NumberedColHeaders = False
      Me.tgitem.NumberedRowHeaders = False
      Me.tgitem.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeAsRangeStylesIntoCode
      Me.tgitem.Size = New System.Drawing.Size(640, 473)
      Me.tgitem.SmartSizeBox = False
      Me.tgitem.TabIndex = 0
      Me.tgitem.Text = "GridControl2"
      Me.tgitem.ThemesEnabled = True
      Me.tgitem.UseRightToLeftCompatibleTextBox = True
      '
      'btnRefresh
      '
      Me.btnRefresh.Location = New System.Drawing.Point(14, 9)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
      Me.btnRefresh.TabIndex = 1
      Me.btnRefresh.Text = "Refresh"
      Me.btnRefresh.UseVisualStyleBackColor = True
      '
      'BuilkMatchView
      '
      Me.Controls.Add(Me.btnRefresh)
      Me.Controls.Add(Me.tgitem)
      Me.Name = "BuilkMatchView"
      Me.Size = New System.Drawing.Size(672, 525)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgitem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    'Private m_entity As WorkCode

    Private m_isInitialized As Boolean

    Private m_tableInitialized As Boolean


    Private m_updating As Boolean = False



#End Region

#Region "Constructors"

    Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      InitGrid()

      GetBuilkRequest()

      PopulateGrid()

    End Sub

#End Region

#Region "Properties"

    Public Overrides Property TitleName As String
      Get
        Return "Builk™ Match"
      End Get
      Set(ByVal value As String)
        MyBase.TitleName = value
      End Set
    End Property

    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return "Builk™ Match" 'Me.m_entity.ListPanelTitle
      End Get
    End Property

    Public Overrides ReadOnly Property TabPageIcon As String
      Get
        Return "Icons.16x16.Builk"
      End Get
    End Property


    Private _builkMatchList As List(Of BuilkMatch)
    Public Property BuilkMatchList As List(Of BuilkMatch)
      Get
        Return _builkMatchList
      End Get
      Set(ByVal value As List(Of BuilkMatch))
        _builkMatchList = value
      End Set
    End Property

#End Region

#Region "Methods"

    Private Sub InitGrid()

      tgitem.ColCount = 6
      tgitem.RowCount = 1

      tgitem.Rows.HeaderCount = 1
      tgitem.Rows.FrozenCount = 1
      'tgItem.Cols.HeaderCount = 1
      'tgitem.Cols.FrozenCount = 1

      tgitem.TableStyle.CheckBoxOptions = New GridCheckBoxCellInfo("True", "False", "", False)

      tgitem.ColStyles(1).VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      tgitem.ColStyles(2).VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      tgitem.ColStyles(3).VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      tgitem.ColStyles(4).VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      tgitem.ColStyles(5).VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center

      Dim items As New StringCollection
      Dim dt As DataTable = (New Supplier).GetCodeNameList
      For Each row As DataRow In dt.Select(Nothing, "supplier_code asc")
        items.Add(row("supplier_code").ToString & ":" & row("supplier_name").ToString)
      Next
      For Each row As DataRow In dt.Select(Nothing, "supplier_name asc")
        items.Add(row("supplier_name").ToString & "|" & row("supplier_code").ToString)
      Next

      tgitem.ColStyles(5).CellType = "PushButton"

      tgitem.ColStyles(4).CellType = "ComboBox"
      tgitem.ColStyles(4).ChoiceList = items
      tgitem.ColStyles(4).CellValue = ""

      tgitem.ColStyles(6).CellType = "CheckBox"
      tgitem.ColStyles(6).TriState = False
      tgitem.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center

      tgitem.ColWidths(1) = 200
      tgitem.ColWidths(2) = 550
      tgitem.ColWidths(3) = 200
      tgitem.ColWidths(4) = 300
      tgitem.ColWidths(5) = 40
      tgitem.ColWidths(6) = 100

      SetGridValue(1, 1, "ชื่อ", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 2, "ที่อยู่", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 3, "เลขประจำตัวผู้เสียภาษี", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 4, "ผู้ขาย", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)
      SetGridValue(1, 6, "ปฏิเสธ", True, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center)

      tgitem.BackColor = Color.White

    End Sub

    Private Sub PopulateGrid()

      tgitem.BeginUpdate()

      tgitem.RowCount = 1


      If Not Me.BuilkMatchList Is Nothing AndAlso Me.BuilkMatchList.Count > 0 Then

        For Each bm As BuilkMatch In Me.BuilkMatchList

          tgitem.RowCount += 1

          SetGridValue(tgitem.RowCount, 1, bm.BuilkNameInfo)
          SetGridValue(tgitem.RowCount, 2, bm.BuilkAddressInfo)
          SetGridValue(tgitem.RowCount, 3, bm.BuilkTaxIDInfo)

          If Not bm.PJMSupplier Is Nothing Then
            SetGridValue(tgitem.RowCount, 4, bm.PJMSupplier.Code & ":" & bm.PJMSupplier.Name)
          End If

          If bm.Reject.HasValue Then
            tgitem(tgitem.RowCount, 6).CellValue = bm.Reject
          End If

        Next


      End If


      'tgitem.RowCount += 1
      'SetGridValue(tgitem.RowCount, 1, "")
      'SetGridValue(tgitem.RowCount, 2, "")
      'SetGridValue(tgitem.RowCount, 3, "")
      'tgitem(tgitem.RowCount, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center

      tgitem.EndUpdate()

    End Sub

    Private Sub SetGridValue(ByVal row As Integer, ByVal col As Integer, ByVal value As String _
, Optional ByVal bold As Boolean = False _
, Optional ByVal hAlign As Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left _
, Optional ByVal vAlign As Syncfusion.Windows.Forms.Grid.GridVerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle)
      tgitem(row, col).HorizontalAlignment = hAlign
      tgitem(row, col).VerticalAlignment = vAlign
      tgitem(row, col).Text = value
      tgitem(row, col).Font.Bold = bold
    End Sub

    Public Overloads Overrides Sub Save()
      'Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)

      'MessageBox.Show("It's Ok.")

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Longkong.Pojjaman.BusinessLogic.SimpleBusinessEntityBase.ConnectionString)
      Dim sql As String = ""
      Dim command As SqlCommand

      Dim success As Boolean = False
      conn.Open()
      command = conn.CreateCommand
      trans = conn.BeginTransaction()
      command.Transaction = trans
      command.CommandType = CommandType.Text



      Try

        For Each bm As BuilkMatch In Me.BuilkMatchList
          sql = ""

          If Not bm.PJMSupplier Is Nothing AndAlso ((bm.Reject.HasValue AndAlso Not bm.Reject) OrElse (Not bm.Reject.HasValue)) Then

            sql = "update supplier set supplier_builkid = '" & bm.BuilkIdInfo & "' where supplier_id = " & bm.PJMSupplier.Id

            command.CommandText = sql
            command.ExecuteNonQuery()

          End If

        Next

        trans.Commit()

        ReturnBuilkRequest()

        Me.WorkbenchWindow.ViewContent.IsDirty = False

      Catch ex As Exception

        trans.Rollback()

        MessageBox.Show(ex.ToString)

      Finally

        conn.Close()

      End Try

      MessageBox.Show("Finish!")

      GetBuilkRequest()

      PopulateGrid()

    End Sub

    Private blist As List(Of BuilkInfo)
    Public Sub GetBuilkRequest()


      Dim BuilkID As String = Configuration.GetConfig("BuilkID").ToString
      Dim HostURL As String = Configuration.GetConfig("WebServiceHostURL").ToString

      If BuilkID = "" Then
        Return
      End If

      Dim WebService As String = HostURL & "/paymenttrack/requestbuilksupplier/?bid=" & BuilkID

      Me.BuilkMatchList = New List(Of BuilkMatch)

      ' Create a request for the URL. 
      'Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/requestbuilksupplier/?bid=" & BuilkID)
      Dim request As WebRequest = WebRequest.Create(WebService)
      ' If required by the server, set the credentials.
      request.Credentials = CredentialCache.DefaultCredentials
      ' Get the response.
      Dim response As WebResponse = request.GetResponse()
      ' Display the status.
      'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
      ' Get the stream containing content returned by the server.
      Dim dataStream As Stream = response.GetResponseStream()
      ' Open the stream using a StreamReader for easy access.
      Dim reader As New StreamReader(dataStream)
      ' Read the content.
      Dim responseFromServer As String = reader.ReadToEnd()
      ' Display the content.
      'Console.WriteLine(responseFromServer)
      ' Clean up the streams and the response.
      reader.Close()
      response.Close()



      blist = JsonConvert.DeserializeObject(Of List(Of BuilkInfo))(responseFromServer)

      Dim bm As BuilkMatch

      For Each bi As BuilkInfo In blist

        bm = New BuilkMatch

        bm.BuilkIdInfo = bi.Bid
        bm.BuilkNameInfo = bi.Bname
        bm.BuilkAddressInfo = bi.Baddress
        bm.BuilkTaxIDInfo = bi.Btid

        Me.BuilkMatchList.Add(bm)

      Next


    End Sub

    Public Sub ReturnBuilkRequest()

      Dim BuilkID As String = Configuration.GetConfig("BuilkID").ToString
      Dim HostURL As String = Configuration.GetConfig("WebServiceHostURL").ToString

      If BuilkID = "" Then
        Return
      End If

      Dim WebService As String = HostURL & "/paymenttrack/approvebuilksupplier/?bid=" & BuilkID

      ' Create a request using a URL that can receive a post. 
      Dim request As WebRequest = WebRequest.Create(WebService)
      'Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/approvebuilksupplier/?bid=" & BuilkID)
      'Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/Transaction/?bid=" & BuilkID)
      ' Set the Method property of the request to POST.
      request.Method = "POST"
      ' Create POST data and convert it to a byte array.

      Dim rblist As New List(Of BuilkInfo)

      For Each bm As BuilkMatch In Me.BuilkMatchList
        For Each bi As BuilkInfo In blist
          If bm.BuilkIdInfo = bi.Bid Then
            If Not bm.PJMSupplier Is Nothing AndAlso ((bm.Reject.HasValue AndAlso Not bm.Reject) OrElse (Not bm.Reject.HasValue)) Then
              bi.IsApprove = True
              rblist.Add(bi)
            ElseIf bm.Reject.HasValue AndAlso bm.Reject Then
              bi.IsApprove = False
              rblist.Add(bi)
            End If
          End If
        Next
      Next

      Dim postData As String = JsonConvert.SerializeObject(rblist) '"This is a test that posts this string to a Web server."
      Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
      ' Set the ContentType property of the WebRequest.
      request.ContentType = "application/jason"
      'request.ContentType = "text/plain"
      ' Set the ContentLength property of the WebRequest.
      request.ContentLength = byteArray.Length
      ' Get the request stream.
      Dim dataStream As Stream = request.GetRequestStream()
      ' Write the data to the request stream.
      dataStream.Write(byteArray, 0, byteArray.Length)
      ' Close the Stream object.
      dataStream.Close()
      ' Get the response.
      Dim response As WebResponse = request.GetResponse()
      ' Display the status.
      'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
      ' Get the stream containing content returned by the server.
      dataStream = response.GetResponseStream()
      ' Open the stream using a StreamReader for easy access.
      Dim reader As New StreamReader(dataStream)
      ' Read the content.
      Dim responseFromServer As String = reader.ReadToEnd()
      ' Display the content.
      'Console.WriteLine(responseFromServer)
      ' Clean up the streams.

      reader.Close()
      dataStream.Close()
      response.Close()

    End Sub

#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          Case Keys.Insert
            'ibtnBlank_Click(Nothing, Nothing)
            Return True
          Case Keys.Delete
            'If Me.tgItem.Focused Then
            '  'ibtnDelRow_Click(Nothing, Nothing)
            '  Return True
            'Else
            Return False
            'End If
          Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
#End Region

#Region "Event"

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

      GetBuilkRequest()

      PopulateGrid()

    End Sub

    Private Sub tgitem_CellButtonClicked(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellButtonClickedEventArgs) Handles tgitem.CellButtonClicked
      tgitem.CurrentCell.SetCurrentCellNoActivate(e.RowIndex, e.ColIndex)
      If e.ColIndex = 5 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim entity As New Supplier
        myEntityPanelService.OpenListDialog(entity, AddressOf SetSupplier)
      End If
    End Sub

    Private Sub SetSupplier(ByVal supp As ISimpleEntity)

      Dim cc As GridCurrentCell = Me.tgitem.CurrentCell
      If cc.RowIndex <= 1 Then
        Return
      End If
      If cc.RowIndex - 1 > Me.BuilkMatchList.Count Then
        Return
      End If

      If TypeOf supp Is Supplier Then

        Me.BuilkMatchList(cc.RowIndex - 2).PJMSupplier = supp
        SetGridValue(cc.RowIndex, 4, CType(supp, Supplier).Code & ":" & CType(supp, Supplier).Name)
        Me.WorkbenchWindow.ViewContent.IsDirty = True

      End If

    End Sub

    Private Sub tgitem_CurrentCellStartEditing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tgitem.CurrentCellStartEditing
      If tgitem.CurrentCell.ColIndex < 4 Then
        e.Cancel = True
      End If
    End Sub

    Private Sub tgitem_CurrentCellValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tgitem.CurrentCellValidating
      Dim cc As GridCurrentCell = Me.tgitem.CurrentCell
      If cc.RowIndex <= 1 Then
        Return
      End If
      If cc.RowIndex - 1 > Me.BuilkMatchList.Count Then
        Return
      End If

      Try

        Select Case cc.ColIndex
          Case 4
            Dim txt As String = cc.Renderer.ControlValue
            Dim reg As New Regex("(.*):")
            Dim reg2 As New Regex("\|(.*)")

            If reg.IsMatch(txt) Then

              Dim supp As Supplier = Nothing
              Dim oldsupp As Supplier = Nothing
              supp = New Supplier(reg.Match(txt).Groups(1).Value)
              oldsupp = Me.BuilkMatchList(cc.RowIndex - 2).PJMSupplier

              If reg.Match(txt).Groups(1).Value.Length <> 0 AndAlso Not supp.Valid Then
                MessageBox.Show(reg.Match(txt).Groups(1).Value & " ไม่มีในระบบ")
              Else
                Me.BuilkMatchList(cc.RowIndex - 2).PJMSupplier = supp
                Me.WorkbenchWindow.ViewContent.IsDirty = True
                SetGridValue(cc.RowIndex, cc.ColIndex, supp.Code & ":" & supp.Name)
              End If

            ElseIf reg2.IsMatch(txt) Then

              Dim supp As Supplier = Nothing
              Dim oldsupp As Supplier = Nothing
              supp = New Supplier(reg.Match(txt).Groups(1).Value)
              oldsupp = Me.BuilkMatchList(cc.RowIndex - 2).PJMSupplier

              If reg.Match(txt).Groups(1).Value.Length <> 0 AndAlso Not supp.Valid Then
                MessageBox.Show(reg.Match(txt).Groups(1).Value & " ไม่มีในระบบ")
              Else
                Me.BuilkMatchList(cc.RowIndex - 2).PJMSupplier = supp
                Me.WorkbenchWindow.ViewContent.IsDirty = True
                SetGridValue(cc.RowIndex, cc.ColIndex, supp.Code & ":" & supp.Name)
              End If

            ElseIf txt.Length > 0 Then

              Dim supp As Supplier = Nothing
              Dim oldsupp As Supplier = Nothing
              supp = New Supplier(txt)
              oldsupp = Me.BuilkMatchList(cc.RowIndex - 2).PJMSupplier

              If txt.Length <> 0 AndAlso Not supp.Valid Then
                MessageBox.Show(txt & " ไม่มีในระบบ")
              Else
                Me.BuilkMatchList(cc.RowIndex - 2).PJMSupplier = supp
                Me.WorkbenchWindow.ViewContent.IsDirty = True
                SetGridValue(cc.RowIndex, cc.ColIndex, supp.Code & ":" & supp.Name)
              End If

            End If

          Case 6
            Me.BuilkMatchList(cc.RowIndex - 2).Reject = CBool(cc.Renderer.ControlValue)
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            tgitem(cc.RowIndex, cc.ColIndex).CellValue = CBool(cc.Renderer.ControlValue)

        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try

    End Sub

#End Region

    '#Region "IPrintable"
    '        Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
    '            Get
    '                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    '                Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")
    '                Dim thePath As String = ""
    '                Dim fileName As String
    '                If fileName Is Nothing OrElse fileName.Length = 0 Then
    '                    fileName = "ActionPath"
    '                End If
    '                thePath = ReportPath & Path.DirectorySeparatorChar & fileName & ".xml"
    '                Dim paths As FormPaths
    '                Dim nameForPath As String
    '                nameForPath = "Longkong.Pojjaman.BusinessLogic.ActionPath" & ".Reports"
    '                Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    '                paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, "ActionPath", thePath)), FormPaths)
    '                Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
    '                If dlg.ShowDialog() = DialogResult.OK Then
    '                    thePath = dlg.KeyValuePair.Value
    '                Else
    '                    Return Nothing
    '                End If
    '                If File.Exists(thePath) Then
    '                    Dim df As New AdobeForm.DesignerForm(thePath, Me)
    '                    Return df.PrintDocument
    '                End If
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property CanPrint() As Boolean
    '            Get
    '                Return False
    '            End Get
    '        End Property
    '#End Region

    '#Region "IPrintableEntity"
    '        Public Property Code() As String Implements BusinessLogic.IIdentifiable.Code
    '            Get

    '            End Get
    '            Set(ByVal Value As String)

    '            End Set
    '        End Property

    '        Public Property Id() As Integer Implements BusinessLogic.IIdentifiable.Id
    '            Get

    '            End Get
    '            Set(ByVal Value As Integer)

    '            End Set
    '        End Property

    '        Public Function GetDefaultForm() As String Implements BusinessLogic.IPrintableEntity.GetDefaultForm

    '        End Function

    '        Public Function GetDefaultFormPath() As String Implements BusinessLogic.IPrintableEntity.GetDefaultFormPath

    '        End Function

    '        Public Function GetDocPrintingEntries() As BusinessLogic.DocPrintingItemCollection Implements BusinessLogic.IPrintableEntity.GetDocPrintingEntries
    '            Dim dpiColl As New DocPrintingItemCollection
    '            Dim dpi As DocPrintingItem

    '      Return dpiColl
    '        End Function
    '#End Region

  End Class

  Public Class BuilkMatch

    Public Sub New()
      _builkIdInfo = ""
      _builkNameInfo = ""
      _builkAddressInfo = ""
      _pjmSupplier = Nothing
      Reject = False
    End Sub

    Private _builkIdInfo As String
    Public Property BuilkIdInfo As String
      Get
        Return _builkIdInfo
      End Get
      Set(ByVal value As String)
        _builkIdInfo = value
      End Set
    End Property

    Private _builkNameInfo As String
    Public Property BuilkNameInfo As String
      Get
        Return _builkNameInfo
      End Get
      Set(ByVal value As String)
        _builkNameInfo = value
      End Set
    End Property

    Private _builkAddressInfo As String
    Public Property BuilkAddressInfo As String
      Get
        Return _builkAddressInfo
      End Get
      Set(ByVal value As String)
        _builkAddressInfo = value
      End Set
    End Property

    Private _builkTaxIDInfo As String
    Public Property BuilkTaxIDInfo As String
      Get
        Return _builkTaxIDInfo
      End Get
      Set(ByVal value As String)
        _builkTaxIDInfo = value
      End Set
    End Property

    Private _pjmSupplier As Supplier
    Public Property PJMSupplier As Supplier
      Get
        Return _pjmSupplier
      End Get
      Set(ByVal value As Supplier)
        _pjmSupplier = value
      End Set
    End Property

    Public Reject? As Boolean
    'Public Property Reject As Boolean
    '  Get
    '    Return _reject
    '  End Get
    '  Set(ByVal value As Boolean)
    '    _reject = value
    '  End Set
    'End Property

  End Class

  Public Class BuilkInfo
    Public Bid As String
    Public IsApprove? As Boolean
    Public Bname As String
    Public Baddress As String
    Public Btid As String
  End Class

End Namespace