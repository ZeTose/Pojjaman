Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class MilestoneItem

#Region "Members"
        Private m_milestone As Milestone
        Private m_lineNumber As Integer
        Private m_desc As String
        Private m_unit As Unit
        Private m_qty As Decimal
        Private m_unitPrice As Decimal
        Private m_note As String
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

                If dr.Table.Columns.Contains(aliasPrefix & "milestonei_desc") AndAlso Not dr.IsNull(aliasPrefix & "milestonei_desc") Then
                    .m_desc = CStr(dr(aliasPrefix & "milestonei_desc"))
                Else
                    .m_desc = ""
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "milestonei_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "milestonei_lineNumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & "milestonei_lineNumber"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "milestonei_qty") AndAlso Not dr.IsNull(aliasPrefix & "milestonei_qty") Then
                    .m_qty = CDec(dr(aliasPrefix & "milestonei_qty"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "milestonei_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "milestonei_unitprice") Then
                    .m_unitPrice = CDec(dr(aliasPrefix & "milestonei_unitprice"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "milestonei_note") AndAlso Not dr.IsNull(aliasPrefix & "milestonei_note") Then
                    .m_note = CStr(dr(aliasPrefix & "milestonei_note"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
                    If Not dr.IsNull("unit_id") Then
                        .m_unit = New Unit(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "milestonei_unit") AndAlso Not dr.IsNull(aliasPrefix & "milestonei_unit") Then
                        .m_unit = New Unit(CInt(dr(aliasPrefix & "milestonei_unit")))
                    End If
                End If
            End With
        End Sub
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Property Milestone() As Milestone            Get                Return m_milestone            End Get            Set(ByVal Value As Milestone)                m_milestone = Value            End Set        End Property        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property Description() As String            Get                Return m_desc            End Get            Set(ByVal Value As String)                m_desc = Value            End Set        End Property        Public Property Unit() As Unit            Get                Return m_unit            End Get            Set(ByVal Value As Unit)                m_unit = Value            End Set        End Property        Public Property Qty() As Decimal            Get                Return m_qty            End Get            Set(ByVal Value As Decimal)                m_qty = Value            End Set        End Property        Public Property UnitPrice() As Decimal            Get                Return m_unitPrice            End Get            Set(ByVal Value As Decimal)                m_unitPrice = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public ReadOnly Property Amount() As Decimal
            Get
                Return (Me.UnitPrice * Me.Qty)
            End Get
        End Property
#End Region

#Region "Methods"
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Me.Milestone.IsInitialized = False
            row("milestonei_linenumber") = Me.LineNumber
            row("milestonei_desc") = Me.Description
            If Not Me.Unit Is Nothing Then
                row("milestonei_unit") = Me.Unit.Id
                row("Unit") = Me.Unit.Name
            End If

            If Me.Qty <> 0 Then
                row("milestonei_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
            Else
                row("milestonei_qty") = ""
            End If

            If Me.UnitPrice <> 0 Then
                row("milestonei_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
            Else
                row("milestonei_unitprice") = ""
            End If
            If Me.Amount <> 0 Then
                row("milestonei_amt") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
            Else
                row("milestonei_amt") = ""
            End If
            row("milestonei_note") = Me.Note
            Me.Milestone.IsInitialized = True
        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If

            Try
                If Not row.IsNull(("milestonei_linenumber")) Then
                    Me.LineNumber = CInt(row("milestonei_linenumber"))
                End If

                If Not row.IsNull(("milestonei_desc")) Then
                    Me.Description = CStr(row("milestonei_desc"))
                End If

                If Not row.IsNull(("milestonei_unit")) Then
                    Me.Unit = New Unit(CInt(row("milestonei_unit")))
                Else
                    Me.Unit = New Unit
                End If
                If Not row.IsNull(("milestonei_note")) Then
                    Me.Note = CStr(row("milestonei_note"))
                End If
                If Not row.IsNull(("milestonei_qty")) Then
                    If CStr(row("milestonei_qty")).Length = 0 Then
                        Me.Qty = 0
                    Else
                        Me.Qty = CDec(row("milestonei_qty"))
                    End If
                End If
                If Not row.IsNull(("milestonei_unitprice")) Then
                    If CStr(row("milestonei_unitprice")).Length = 0 Then
                        Me.UnitPrice = 0
                    Else
                        Me.UnitPrice = CDec(row("milestonei_unitprice"))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
#End Region

    End Class

End Namespace
