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
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RunNumberView
        'Inherits UserControl
        Inherits AbstractOptionPanel
        Implements IValidatable

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
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'tgItem
            '
            Me.tgItem.AllowNew = False
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = False
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 8)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(496, 240)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 0
            Me.tgItem.TreeManager = Nothing
            '
            'RunNumberView
            '
            Me.Controls.Add(Me.tgItem)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RunNumberView"
            Me.Size = New System.Drawing.Size(512, 256)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As FormEntity
        Private m_treeManager As TreeManager

        Private m_isInitialized As Boolean

        Private m_tableInitialized As Boolean

        Private m_form As FormEntity
        Private m_oldRow As TreeRow = Nothing

        Private m_formCollection As FormEntityCollection

        Private Dirty As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()

            Me.SetLabelText()
            Initialize()
            m_entity = New FormEntity


            Dim dt As TreeTable = Me.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            'WrapperArrayList.AddItemAddedHandler(dt, AddressOf ItemAdded)
            AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete

            EventWiring()

            m_formCollection = New FormEntityCollection

            Me.m_tableInitialized = False
      Me.m_formCollection.PopulateTable2(Me.m_treeManager.Treetable)
            Me.m_tableInitialized = True
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "FormEntity"

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "LineNumber"
            csLineNumber.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RunNumberView.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True

            Dim csDescription As New TreeTextColumn
            csDescription.MappingName = "Description"
            csDescription.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RunNumberView.DescriptionHeaderText}")
            csDescription.NullText = ""
            csDescription.Width = 100
            csDescription.TextBox.Name = "Description"
            csDescription.ReadOnly = True

            Dim csAutoCodeFormat As New TreeTextColumn
            csAutoCodeFormat.MappingName = "AutoCodeFormat"
            csAutoCodeFormat.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RunNumberView.AutoCodeFormatHeaderText}")
            csAutoCodeFormat.NullText = ""
            csAutoCodeFormat.Width = 100
            csAutoCodeFormat.TextBox.Name = "AutoCodeFormat"

            Dim csAutoGen As New DataGridCheckBoxColumn
            csAutoGen.MappingName = "AutoGen"
            csAutoGen.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RunNumberView.AutoGenHeaderText}")
            csAutoGen.Width = 100

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csDescription)
            dst.GridColumnStyles.Add(csAutoCodeFormat)
            dst.GridColumnStyles.Add(csAutoGen)
            Return dst
        End Function
        Public Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("FormEntity")
            myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("AutoCodeFormat", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("AutoGen", GetType(Boolean)))
            Return myDatatable
        End Function
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            Me.m_treeManager.Treetable.AcceptChanges()
            If Not Me.m_tableInitialized Then
                Return
            End If
            If CType(e.Row, TreeRow).Tag Is Nothing Then
                Return
            End If
            Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            Me.m_treeManager.Treetable.AcceptChanges()
            Me.Dirty = True
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.m_tableInitialized Then
                Return
            End If
            If CType(e.Row, TreeRow).Tag Is Nothing Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "autocodeformat"
                        SetAutoCode(e)
                    Case "autogen"
                        SetAutoGen(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim autocodeformat As Object = e.Row("autocodeformat")

            Select Case e.Column.ColumnName.ToLower
                Case "autocodeformat"
                    autocodeformat = e.ProposedValue
            End Select

            If IsDBNull(autocodeformat) OrElse CStr(autocodeformat).Length = 0 Then
                e.Row.SetColumnError("autocodeformat", Me.StringParserService.Parse("${res:Global.Error.NoAutoCodeFormat}"))
            Else
                e.Row.SetColumnError("autocodeformat", "")
            End If
        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            Return True
        End Function
        Private m_updating As Boolean = False
        Public Sub SetAutoCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            If m_form Is Nothing Then
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            m_form.AutoCodeFormat = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Public Sub SetAutoGen(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            If CType(e.Row, TreeRow).Tag Is Nothing OrElse Not TypeOf CType(e.Row, TreeRow).Tag Is FormEntity Then
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            m_form = CType(CType(e.Row, TreeRow).Tag, FormEntity)
            If m_form Is Nothing Then
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            m_form.IsAutoGen = CBool(e.ProposedValue)
            m_updating = False
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
            'Dim row As DataRow = e.Row
            'Me.m_treeManager.Treetable.Childs.Remove(CType(row, TreeRow))
            'Try
            '    If Not Me.m_isInitialized Then
            '        Return
            '    End If

            '    Dim index As TreeRow = CType(e.Row, TreeRow)
            '    Me.m_treeManager.Treetable.Childs.Remove(index)
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString)
            'End Try
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
            Dim theRow As TreeRow = m_treeManager.SelectedRow
            If m_oldRow Is theRow Then
                Return
            End If
            If TypeOf theRow.Tag Is FormEntity Then
                m_form = CType(theRow.Tag, FormEntity)
            Else
                m_form = Nothing
            End If
            m_oldRow = m_treeManager.SelectedRow
        End Sub
#End Region

#Region "Properties"
        Public Property FormCollection() As FormEntityCollection            Get                Return m_formCollection            End Get            Set(ByVal Value As FormEntityCollection)                m_formCollection = Value            End Set        End Property
#End Region

#Region "IListDetail"
        Public Sub CheckFormEnable()
        End Sub
        Public Sub ClearDetail()
        End Sub
        Public Sub SetLabelText()

        End Sub
        Protected Sub EventWiring()

        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower

            End Select
            Dirty = Dirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Sub Initialize()

        End Sub
#End Region

#Region "Methods"

#End Region

#Region "Overrides"
        Public Overloads Overrides Sub LoadPanelContents()
            m_isInitialized = False
            ClearDetail()

            Me.m_tableInitialized = False
      Me.m_formCollection.PopulateTable2(Me.m_treeManager.Treetable)
            Me.m_tableInitialized = True

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Overloads Overrides Function StorePanelContents() As Boolean
            If Not m_isInitialized Then
                Return True
            End If
            If Not Dirty Then
                Return True
            End If
            Me.m_formCollection.Save()
            Return True
        End Function
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