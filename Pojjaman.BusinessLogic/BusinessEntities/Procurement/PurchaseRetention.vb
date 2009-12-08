Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class PurchaseRetention
        Inherits SimpleBusinessEntityBase
        Implements IBillAcceptable, IHasIBillablePerson, IHasToCostCenter

#Region "Members"
        Private m_supplier As Supplier
        Private m_docDate As Date

        Private m_toCostCenter As CostCenter

        Private m_note As String
        Private m_creditPeriod As Long

        Private m_retention As Decimal
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Construct(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                .m_supplier = New Supplier
                .m_creditPeriod = 0
                .m_note = ""
                .m_docDate = Now.Date
                Me.m_toCostCenter = New CostCenter
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me

                If dr.Table.Columns.Contains("supplier_id") Then
                    If Not dr.IsNull("supplier_id") Then
                        .m_supplier = New Supplier(dr, "")
                    End If
                Else
                    If Not dr.IsNull(aliasPrefix & "stock_entity") Then
                        .m_supplier = New Supplier(CInt(dr(aliasPrefix & "stock_entity")))
                    End If
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "stock_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditperiod") Then
                    .m_creditPeriod = CInt(dr(aliasPrefix & "stock_creditperiod"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "cc_id") Then
                    If Not dr.IsNull(aliasPrefix & "cc_id") Then
                        .m_toCostCenter = New CostCenter(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains("stock_tocc") AndAlso Not dr.IsNull(aliasPrefix & "stock_tocc") Then
                        .m_toCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_tocc")))
                    End If
                End If

                If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
                    .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
                End If

                If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
                    .m_note = CStr(dr(aliasPrefix & "stock_note"))
                End If

                ' Retention Deducted
                If dr.Table.Columns.Contains(aliasPrefix & "stock_retention") AndAlso Not dr.IsNull(aliasPrefix & "stock_retention") Then
                    .m_retention = CDec(dr(aliasPrefix & "stock_retention"))
                End If

            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Supplier() As Supplier            Get                Return m_supplier            End Get            Set(ByVal Value As Supplier)                m_supplier = Value                Me.m_creditPeriod = Me.m_supplier.CreditPeriod            End Set        End Property        Public Property DocDate() As Date Implements IPayable.Date            Get                Return m_docDate            End Get            Set(ByVal Value As Date)                m_docDate = Value            End Set        End Property        Public Property ToCostCenter() As CostCenter            Get                Return m_toCostCenter            End Get            Set(ByVal Value As CostCenter)                m_toCostCenter = Value            End Set        End Property        Public Property Note() As String Implements IPayable.Note            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public Property CreditPeriod() As Long            Get                Return m_creditPeriod            End Get            Set(ByVal Value As Long)                m_creditPeriod = Value            End Set        End Property        Public Property Retention() As Decimal            Get
                Return m_retention
            End Get
            Set(ByVal Value As Decimal)
                m_retention = Value
            End Set
        End Property        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "PurchaseRetention"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "stock"
            End Get
        End Property
        Public Overrides ReadOnly Property TableName() As String
            Get
                Return "stock"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.PurchaseRetention.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.PurchaseRetention"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.PurchaseRetention"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.PurchaseRetention.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
                Dim blankSuffix As String = "()"
                If tpt.EndsWith(blankSuffix) Then
                    tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
                End If
                Return tpt
            End Get
        End Property
#End Region

#Region "Methods"
#End Region

#Region "IBillAcceptable"
        Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
            Return Me.Retention
        End Function
        Public Property DueDate() As Date Implements IPayable.DueDate
            Get
                Try
                    Return Me.DocDate.AddDays(Me.CreditPeriod)
                Catch ex As Exception
                    Return Me.DocDate
                End Try
            End Get
            Set(ByVal Value As Date)
             
            End Set
        End Property
        Public Property Payment() As Payment Implements IPayable.Payment
            Get
                Return Nothing
            End Get
            Set(ByVal Value As Payment)
            End Set
        End Property
        Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount
            'Undone
            Return AmountToPay()
        End Function
        Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
            Get
                Return Me.Supplier
            End Get
        End Property
        Public Function GetRemainingAmountWithBillAcceptance(ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountWithBillAcceptance
            Try
                Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                        Me.ConnectionString _
                        , CommandType.StoredProcedure _
                        , "GetUnpaidStockRetentionAmount" _
                        , New SqlParameter("@stock_id", Me.Id) _
                        , New SqlParameter("@billai_billa", billa_id) _
                        )
                If ds.Tables(0).Rows.Count > 0 Then
                    Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Function
        Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
            Try
                Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                        Me.ConnectionString _
                        , CommandType.StoredProcedure _
                        , "GetUnpaidStockRetentionAmount" _
                        , New SqlParameter("@stock_id", Me.Id) _
                        , New SqlParameter("@paysi_pays", pays_id) _
                        )
                If ds.Tables(0).Rows.Count > 0 Then
                    Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Function
        Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer, ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
            Try
                Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                        Me.ConnectionString _
                        , CommandType.StoredProcedure _
                        , "GetUnpaidStockRetentionAmount" _
                        , New SqlParameter("@stock_id", Me.Id) _
                        , New SqlParameter("@paysi_pays", pays_id) _
                        , New SqlParameter("@billai_billa", billa_id) _
                        )
                If ds.Tables(0).Rows.Count > 0 Then
                    Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Function
#End Region


#Region "IHasIBillablePerson"
        Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
            Get
                Return Me.Supplier
            End Get
            Set(ByVal Value As IBillablePerson)
                If TypeOf Value Is Supplier Then
                    Me.Supplier = CType(Value, Supplier)
                End If
            End Set
        End Property
#End Region

        Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
            Get
                Return Me.ToCostCenter
            End Get
            Set(ByVal Value As CostCenter)
                Me.ToCostCenter = Value
            End Set
        End Property
    End Class
End Namespace

