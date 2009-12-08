Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class LinkFinancialItem

#Region "Members"
        Private m_baseentity As LinkFinancial
        Private m_linenumber As Integer
        Private m_indention As Integer
        Private m_code As String
        Private m_name As String
        Private m_namestyle As String
        Private m_linktype As LinkFinancialTypeList
        Private m_note As String
        Private m_notestyle As String
        Private m_formular As String
        Private m_formularstyle As String
        Private m_isnewpage As Boolean
        Private m_linestype As Integer

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                ' Entity Base.
                'If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_link") _
                'AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_link") Then
                '    .m_baseentity = New LinkFinancial(CInt(dr(aliasPrefix & Me.Prefixi & "_link")))
                'End If
                ' Line Number.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_linenumber") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_linenumber") Then
                    .m_linenumber = CInt(dr(aliasPrefix & Me.Prefixi & "_linenumber"))
                End If
                ' Idention.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_indention") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_indention") Then
                    .m_indention = CInt(dr(aliasPrefix & Me.Prefixi & "_indention"))
                End If
                ' Code.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_code") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_code") Then
                    .m_code = CStr(dr(aliasPrefix & Me.Prefixi & "_code"))
                End If
                ' Name.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefixi & "_name"))
                End If
                ' Name Style.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_namestyle") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_namestyle") Then
                    .m_namestyle = CStr(dr(aliasPrefix & Me.Prefixi & "_namestyle"))
                End If
                ' Note.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_note") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefixi & "_note"))
                End If
                ' Note Style.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_notestyle") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_notestyle") Then
                    .m_notestyle = CStr(dr(aliasPrefix & Me.Prefixi & "_notestyle"))
                End If
                ' Formular.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_formular") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_formular") Then
                    .m_formular = CStr(dr(aliasPrefix & Me.Prefixi & "_formular"))
                End If
                ' Formular Style.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_formularstyle") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_formularstyle") Then
                    .m_formularstyle = CStr(dr(aliasPrefix & Me.Prefixi & "_formularstyle"))
                End If
                ' is NewPage.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_isnewpage") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_isnewpage") Then
                    .m_isnewpage = CBool(dr(aliasPrefix & Me.Prefixi & "_isnewpage"))
                End If
                ' line style.
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefixi & "_linestype") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefixi & "_linestype") Then
                    .m_linestype = CInt(dr(aliasPrefix & Me.Prefixi & "_linestype"))
                End If

            End With
        End Sub
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct()
            With Me
                .BaseEntity = New LinkFinancial
                .LinkType = New LinkFinancialTypeList(0)
                Dim f As System.Drawing.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                f.ToString()
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property BaseEntity() As LinkFinancial
            Get
                Return m_baseentity
            End Get
            Set(ByVal Value As LinkFinancial)
                m_baseentity = Value
            End Set
        End Property
        Public Property LineNumber() As Integer
            Get
                Return m_linenumber
            End Get
            Set(ByVal Value As Integer)
                m_linenumber = Value
            End Set
        End Property
        Public Property Code() As String
            Get
                Return m_code
            End Get
            Set(ByVal Value As String)
                m_code = Value
            End Set
        End Property
        Public Property Indention() As Integer
            Get
                Return m_indention
            End Get
            Set(ByVal Value As Integer)
                m_indention = Value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property
        Public Property NameStyle() As String
            Get
                Return m_namestyle
            End Get
            Set(ByVal Value As String)
                m_namestyle = Value
            End Set
        End Property
        Public Property LinkType() As LinkFinancialTypeList
            Get
                Return m_linktype
            End Get
            Set(ByVal Value As LinkFinancialTypeList)
                m_linktype = Value
            End Set
        End Property
        Public Property Note() As String
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property
        Public Property NoteStyle() As String
            Get
                Return m_notestyle
            End Get
            Set(ByVal Value As String)
                m_notestyle = Value
            End Set
        End Property
        Public Property Formular() As String
            Get
                Return m_formular
            End Get
            Set(ByVal Value As String)
                m_formular = Value
            End Set
        End Property
        Public Property FormularStyle() As String
            Get
                Return m_formularstyle
            End Get
            Set(ByVal Value As String)
                m_formularstyle = Value
            End Set
        End Property
        Public Property IsNewPage() As Boolean
            Get
                Return m_isnewpage
            End Get
            Set(ByVal Value As Boolean)
                m_isnewpage = Value
            End Set
        End Property
        Public Property LineStyle() As Integer
            Get
                Return m_linestype
            End Get
            Set(ByVal Value As Integer)
                m_linestype = Value
            End Set
        End Property
        Private ReadOnly Property Prefixi() As String
            Get
                Return "linki"
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub CopyToDataRow(ByVal row As DataRow)
            If row Is Nothing Then
                Return
            End If
            Me.BaseEntity.IsInitialized = False

            row("linki_link") = Me.BaseEntity.Id
            row("linki_linenumber") = Me.LineNumber
            row("linki_idention") = Me.Indention
            row("linki_code") = Me.Code
            row("linki_name") = Me.Name
            row("linki_namestyle") = Me.NameStyle
            row("linki_note") = Me.Note
            row("linki_notestyle") = Me.NoteStyle
            row("linki_formular") = Me.Formular
            row("linki_formularstyle") = Me.FormularStyle
            row("linki_isnewpage") = Me.IsNewPage
            row("linki_linestyle") = Me.LineStyle

            Me.BaseEntity.IsInitialized = True
        End Sub
        Public Sub CopyFromDataRow(ByVal row As DataRow)
            If row Is Nothing Then
                Return
            End If
            Try
                If Not row.IsNull("linki_link") Then
                    Me.BaseEntity = New LinkFinancial
                    Me.BaseEntity.Id = CInt(row("linki_link"))
                End If
                ' Line number.
                If Not row.IsNull(("linki_linenumber")) Then
                    Me.LineNumber = CInt(row("linki_linenumber"))
                End If
                ' Indention.
                If Not row.IsNull(("linki_idention")) Then
                    Me.Indention = CInt(row("linki_idention"))
                End If
                ' Code.
                If Not row.IsNull(("linki_code")) Then
                    Me.Code = CStr(row("linki_code"))
                End If
                ' Name.
                If Not row.IsNull(("linki_name")) Then
                    Me.Name = CStr(row("linki_name"))
                End If
                ' Name Style.
                If Not row.IsNull(("linki_namestyle")) Then
                    Me.NameStyle = CStr(row("linki_namestyle"))
                End If
                ' Note.
                If Not row.IsNull(("linki_note")) Then
                    Me.Note = CStr(row("linki_note"))
                End If
                ' Note Style.
                If Not row.IsNull(("linki_notestyle")) Then
                    Me.NoteStyle = CStr(row("linki_notestyle"))
                End If
                ' Formular.
                If Not row.IsNull(("linki_formular")) Then
                    Me.Formular = CStr(row("linki_formular"))
                End If
                ' Formular Style.
                If Not row.IsNull(("linki_formularstyle")) Then
                    Me.FormularStyle = CStr(row("linki_formularstyle"))
                End If
                ' Is Newpage.
                If Not row.IsNull(("linki_isnewpage")) Then
                    Me.IsNewPage = CBool(row("linki_isnewpage"))
                End If
                ' Line Style.
                If Not row.IsNull(("linki_linestyle")) Then
                    Me.LineStyle = CInt(row("linki_linestyle"))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

    End Class
End Namespace