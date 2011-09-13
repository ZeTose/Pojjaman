Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports System.ComponentModel
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Configuration
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AbstractFilterSubPanel
    Inherits System.Windows.Forms.UserControl
    Implements IFilterSubPanel, ISecurityValidatable, Commands.IKeyReceiver

#Region "Members"
    Private m_StringParserService As StringParserService
    Private m_entity As IListable
    Private m_entities As ArrayList
    Private m_accessTale As DataTable
    Private m_statusbarService As IStatusBarService
#End Region

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      components = New System.ComponentModel.Container
    End Sub

#End Region

#Region "IFilterSubPanel"
    Public Overridable Property Entities() As System.Collections.ArrayList Implements IFilterSubPanel.Entities
      Get
        Return m_entities
      End Get
      Set(ByVal Value As System.Collections.ArrayList)
        m_entities = Value
      End Set
    End Property
    Public Property Entity() As BusinessLogic.IListable Implements IFilterSubPanel.Entity
      Get
        Return m_entity
      End Get
      Set(ByVal Value As BusinessLogic.IListable)
        m_entity = Value
      End Set
    End Property
    Public Overridable Function GetFilterString() As String Implements IFilterSubPanel.GetFilterString
      Dim s As String = ""
      For Each f As Filter In Me.GetFilterArray
        s &= f.Name & ":" & f.Value.ToString & vbCrLf
      Next
      Return s
    End Function
    Public Overridable Function GetFilterArray() As Filter() Implements IFilterSubPanel.GetFilterArray

    End Function
    Public Overridable ReadOnly Property SearchButton() As System.Windows.Forms.Button Implements IFilterSubPanel.SearchButton
      Get

      End Get
    End Property

    Public Event SearchHandler(ByVal sender As Object, ByVal e As System.EventArgs) Implements IFilterSubPanel.SearchHandler

    Protected Sub OnSearch(ByVal e As EventArgs)
      RaiseEvent SearchHandler(Me, e)
    End Sub
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Me.SetDefaultStatusBar()
    End Sub
    Private Sub AbstractFilterSubPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim fullName As String = Me.GetType.FullName
      'm_accessTale = Access.GetFormAccessTable(fullName)
      'If Not FormSecurityValidator Is Nothing AndAlso Not m_accessTale Is Nothing Then
      '    LoopSecurity(Me)
      'End If
      LoopControl(Me)
    End Sub
#End Region

#Region "Methods"
    Public Sub SetDefaultStatusBar()
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Me.StatusColor = Color.FromArgb(0, Color.White)
      Me.StatusDescription = "" 'myStringParserService.Parse("${res:Global.Already}")
      Me.StatusBarService.SetMessage(Me.StatusDescription)
      Me.StatusBarService.SetStatusMessage(Me.StatusMessage, Me.StatusColor)
    End Sub
    Public Sub LoopSecurity(ByVal thisCtrl As Control)
      For Each ctrl As Control In thisCtrl.Controls
        Dim rows As DataRow() = m_accessTale.Select("form_controlname='" & ctrl.Name & "'")
        If rows.Length = 1 Then
          Dim row As DataRow = rows(0)
          Dim accessId As Integer = CInt(row("form_accessID"))
          Dim requiredLevel As Integer = CInt(row("form_requiredlevel"))
          Dim action As FailAction = CType([Enum].Parse(GetType(FailAction), row("form_failaction").ToString), FailAction)
          Me.FormSecurityValidator.SetAccessId(ctrl, accessId)
          Me.FormSecurityValidator.SetFailAction(ctrl, action)
          Me.FormSecurityValidator.SetRequiredLevel(ctrl, requiredLevel)
        End If
        LoopSecurity(ctrl)
      Next
    End Sub
    Public Sub LoopControl(ByVal thisCtr As Control)
      Dim ctr As Control
      For Each ctr In thisCtr.Controls
        If TypeOf ctr Is TextBox Then
          RemoveHandler ctr.GotFocus, AddressOf ControlFocus
          AddHandler ctr.GotFocus, AddressOf ControlFocus
        End If
        If Not TypeOf ctr Is DataGrid Then
          LoopControl(ctr)
        End If
      Next
    End Sub
    Private Sub ControlFocus(ByVal sender As Object, ByVal e As EventArgs)
      'WorkbenchSingleton.Workbench.RedrawEditComponents()
    End Sub
    Public Function ValidIdOrDBNull(ByVal entity As SimpleBusinessEntityBase) As Object
      If entity Is Nothing OrElse Not entity.Valid Then
        Return DBNull.Value
      End If
      Return entity.Id
    End Function
    Public Function ValidCodeOrDBNull(ByVal entity As SimpleBusinessEntityBase) As Object
      If entity Is Nothing OrElse Not entity.Valid Then
        Return DBNull.Value
      End If
      Return entity.Code
    End Function
    Public Function ValidDateOrDBNull(ByVal myDate As Date) As Object
      If myDate.Equals(Date.MinValue) Then
        Return DBNull.Value
      End If
      Return myDate
    End Function
    Public Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
      If dt.Equals(Date.MinValue) Then
        Return nullString
      End If
      Return dt.ToShortDateString
    End Function
    Public Function MinDateToNow(ByVal dt As Date) As Date
      If dt.Equals(Date.MinValue) Then
        dt = Now
      End If
      Return dt
    End Function
    Public Function MaxDtpDate(ByVal dt As Date) As Date
      If dt.CompareTo(DateTimePicker.MaxDateTime) >= 0 Then
        Return DateTimePicker.MaxDateTime
      End If
      Return dt
    End Function
#End Region

#Region "Properties"
    Public Overridable Property StatusDescription As String
    Public Overridable Property StatusMessage As String
    Public Property StatusColor As Color
    <Browsable(False)> _
    Public ReadOnly Property StringParserService() As StringParserService
      Get
        If m_StringParserService Is Nothing Then
          m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End If
        Return m_StringParserService
      End Get
    End Property
    <Browsable(False)> _
    Public ReadOnly Property StatusBarService() As IStatusBarService
      Get
        If m_statusbarService Is Nothing Then
          m_statusbarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
        End If
        Return m_statusbarService
      End Get
    End Property
#End Region

#Region "Datetime"
    Public Function DateToString(ByVal dtp As DateTimePicker, ByVal txtdate As TextBox) As String
      txtdate.Text = String.Format("{0:dd\/MM\/yyyy}", dtp.Value)
      Return dtp.Value.ToShortDateString
    End Function
    Public Function StringToDate(ByVal txtdate As TextBox, ByVal dtp As DateTimePicker) As DateTime
      If txtdate.Text Is Nothing OrElse txtdate.TextLength = 0 Then
        dtp.Value = Date.Now
        txtdate.Text = Nothing
        Return Date.MinValue
      Else
        dtp.Value = Convert.ToDateTime(txtdate.Text)
        Return dtp.Value
      End If
    End Function
#End Region

#Region "IClipboardHandler"
    Public Overridable Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Copy

    End Sub
    Public Overridable Sub Cut(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Cut

    End Sub
    Public Overridable Sub Delete(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Delete

    End Sub
    Public Overridable ReadOnly Property EnableCopy() As Boolean Implements IClipboardHandler.EnableCopy
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableCut() As Boolean Implements IClipboardHandler.EnableCut
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableDelete() As Boolean Implements IClipboardHandler.EnableDelete
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnablePaste() As Boolean Implements IClipboardHandler.EnablePaste
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableSelectAll() As Boolean Implements IClipboardHandler.EnableSelectAll
      Get
        Return False
      End Get
    End Property
    Public Overridable Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Paste

    End Sub
    Public Overridable Sub SelectAll(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.SelectAll

    End Sub
#End Region

#Region "ISecurityValidatable"
    Public Overridable ReadOnly Property FormSecurityValidator() As Components.SecurityValidator Implements ISecurityValidatable.FormSecurityValidator
      Get

      End Get
    End Property
#End Region

#Region "IKeyReceiver"
    Public Overridable Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean Implements Commands.IKeyReceiver.ProcessKey
      Select Case keyPressed
        Case Keys.Enter
          If TypeOf Me.ActiveControl Is TextBox Then
            If Me.ActiveControl.Name.ToLower.StartsWith("txt") Then
              If CType(Me.ActiveControl, TextBox).Multiline Then
                Dim tmpIndx As Integer = CType(Me.ActiveControl, TextBox).SelectionStart
                CType(Me.ActiveControl, TextBox).Text = CType(Me.ActiveControl, TextBox).Text.Insert(CType(Me.ActiveControl, TextBox).SelectionStart, vbCrLf)
                CType(Me.ActiveControl, TextBox).SelectionStart = tmpIndx + 2
                Return True
              End If
            End If
          End If
          SendKeys.Send("{tab}")
          Return True
      End Select
      Return False
    End Function
#End Region

    Private Sub AbstractFilterSubPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
      If Not Me.DesignMode Then
        Try
          Me.SetDefaultStatusBar()
        Catch ex As Exception

        End Try
      End If
    End Sub
  End Class
End Namespace

