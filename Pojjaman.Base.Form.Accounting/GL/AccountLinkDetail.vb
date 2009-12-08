Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AccountLinkDetail
        Inherits AbstractEntityPanelViewContent
        Implements ISimpleListPanel, IValidatable

#Region " Windows Form Designer generated code "

        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    If Not Me.m_entity Is Nothing Then
                        RemoveHandler Me.m_entity.AcctButtonClick, AddressOf AccountButtonClick
                    End If
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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.grbDetail.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.tgItem)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(760, 384)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "กำหนดรหัสบัญชีทั่วไป"
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = True
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 16)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(744, 360)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 190
            Me.tgItem.TreeManager = Nothing
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Me.ErrorProvider1
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'AccountLinkDetail
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "AccountLinkDetail"
            Me.Size = New System.Drawing.Size(776, 408)
            Me.grbDetail.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As AccountLink
        Private m_treeManager As TreeManager
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            m_entity = New AccountLink

            Dim dt As TreeTable = AccountLink.GetSchemaTable()
            Dim dst As DataGridTableStyle = AccountLink.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            'Load Items**********************************************************
            Me.m_treeManager.Treetable = Me.m_entity.ItemTable
            AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
            AddHandler Me.m_entity.AcctButtonClick, AddressOf AccountButtonClick
            Me.Validator.DataTable = m_treeManager.Treetable
            '********************************************************************

            Me.TitleName = m_entity.TabPageText
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If Me.WorkbenchWindow Is Nothing Then
                Return
            End If
            If Me.WorkbenchWindow.ViewContent Is Nothing Then
                Return
            End If
            If e.Name = "ItemChanged" Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Public Sub AccountButtonClick(ByVal e As ButtonColumnEventArgs)
            If Me.m_entity.ItemTable.Childs.IndexOf(CType(Me.m_entity.ItemTable.Rows(e.Row), TreeRow)) >= 0 Then
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entities As New ArrayList
            Dim dummy As New Account
            dummy.Type = New AccountType(CInt(Me.m_treeManager.SelectedRow("ga_acctType")))
            entities.Add(dummy)
            myEntityPanelService.OpenTreeDialog(dummy, AddressOf SetAccount, Nothing, entities)
        End Sub
        Private Sub SetAccount(ByVal acct As ISimpleEntity)
            Me.m_treeManager.SelectedRow("AcctCode") = acct.Code
            Me.m_treeManager.SelectedRow("AcctName") = CType(acct, Account).Name
            Me.m_treeManager.SelectedRow("ga_acct") = acct.Id
        End Sub
#End Region

#Region "ISimpleEntityPanel"
        Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)

            End Set
        End Property
        Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged
        Public Sub AddNew() Implements ISimpleListPanel.AddNew

        End Sub
        Public Event EntitySelected(ByVal entity As BusinessLogic.ISimpleEntity) Implements ISimpleListPanel.EntitySelected
        Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData

        End Sub
        Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As BusinessLogic.ISimpleEntity)

            End Set
        End Property
        Public Sub CheckFormEnable() Implements ISimplePanel.CheckFormEnable

        End Sub
        Public Sub ClearDetail() Implements ISimplePanel.ClearDetail

        End Sub
        Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
            Get

            End Get
        End Property
        Public Sub Initialize() Implements ISimplePanel.Initialize

        End Sub
        Public Sub SetLabelText() Implements ISimplePanel.SetLabelText
            If Not m_entity Is Nothing Then
                Me.Text = Me.StringParserService.Parse(m_entity.ListPanelTitle)
            End If
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountLinkDetail.grbDetail}")
        End Sub
        Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

        End Sub
        Public ReadOnly Property Title() As String Implements ISimplePanel.Title
            Get
                If Not m_entity Is Nothing Then
                    Return Me.m_entity.ListPanelTitle
                End If
            End Get
        End Property
        Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties

        End Sub
        Public Sub ChangeTitle(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleListPanel.ChangeTitle

        End Sub
#End Region

#Region "Overrides"
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Return Me.m_entity.ListPanelTitle
            End Get
        End Property
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

    End Class
End Namespace
