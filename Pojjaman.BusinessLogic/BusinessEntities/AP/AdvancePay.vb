Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AdvancePayStatus
    Inherits StockStatus

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "check_status"  ' Hack :
      End Get
    End Property
#End Region

  End Class
  Public Class AdvancePay
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IVatable, IWitholdingTaxable _
    , IPayable, IPaymentItem, IPrintableEntity, IHasIBillablePerson, IHasToCostCenter, IHasFromCostCenter, ICancelable

#Region "Members"
    Private m_supplier As Supplier
    Private m_costCenter As CostCenter

    Private m_docDate As Date


    Private m_vat As Vat
    Private m_whtcol As WitholdingTaxCollection
    Private m_payment As Payment
    Private m_je As JournalEntry

    Private m_note As String
    Private m_creditPeriod As Long

    Private m_taxRate As Decimal
    Private m_taxType As TaxType

    Private m_status As AdvancePayStatus

    Private m_itemTable As TreeTable

    Private m_realTaxBase As Decimal
    Private m_realTaxAmount As Decimal
    Private m_type As Integer

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
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      'ReLoadItems(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      'ReLoadItems()
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
      'ReLoadItems()
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_supplier = New Supplier
        .m_creditPeriod = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_type = 0
        .m_taxType = New TaxType(2)
        .m_docDate = Date.Now.Date
        .m_status = New AdvancePayStatus(-1)
        Me.m_costCenter = New CostCenter

        '----------------------------Tab Entities-----------------------------------------
        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)

        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 1

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        .m_payment = New Payment(Me)
        .m_payment.OnHold = True
        .m_payment.DocDate = Me.m_docDate
        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("supplier.supplier_id") Then
          If Not dr.IsNull("supplier.supplier_id") Then
            .m_supplier = New Supplier(dr, "supplier.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "advp_entity") Then
            .m_supplier = New Supplier(CInt(dr(aliasPrefix & "advp_entity")))
          End If
        End If

        If dr.Table.Columns.Contains("costcenter.cc_id") Then
          If Not dr.IsNull("costcenter.cc_id") Then
            .m_costCenter = New CostCenter(dr, "costcenter.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "advp_cc") Then
            .m_costCenter = New CostCenter(CInt(dr(aliasPrefix & "advp_cc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "advp_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "advp_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "advp_creditperiod"))
        End If
        If Not dr.IsNull(aliasPrefix & "advp_aftertax") Then
          .m_afterTax = CDec(dr(aliasPrefix & "advp_aftertax"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "CostCenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "CostCenter.cc_id") Then
            .m_costCenter = New CostCenter(dr, "CostCenter.")
          End If
        Else
          If dr.Table.Columns.Contains("advp_tocc") AndAlso Not dr.IsNull(aliasPrefix & "advp_tocc") Then
            .m_costCenter = New CostCenter(CInt(dr(aliasPrefix & "advp_tocc")))
          End If
        End If

        If dr.Table.Columns.Contains("advp_docDate") AndAlso Not dr.IsNull(aliasPrefix & "advp_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "advp_docDate"))
        End If

        If dr.Table.Columns.Contains("advp_note") AndAlso Not dr.IsNull(aliasPrefix & "advp_note") Then
          .m_note = CStr(dr(aliasPrefix & "advp_note"))
        End If
        If dr.Table.Columns.Contains("advp_type") AndAlso Not dr.IsNull(aliasPrefix & "advp_type") Then
          .m_type = CInt(dr(aliasPrefix & "advp_type"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advp_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "advp_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "advp_taxtype")))
        End If

        If Not dr.IsNull(aliasPrefix & "advp_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "advp_taxrate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advp_status") AndAlso Not dr.IsNull(aliasPrefix & "advp_status") Then
          .m_status = New AdvancePayStatus(CInt(dr(aliasPrefix & "advp_status")))
        End If

        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "advp_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "advp_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "advp_taxbase"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "advp_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "advp_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "advp_taxamt"))
        End If
        '--------------------END REAL-------------------------

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 1

        '.m_wht = New WitholdingTax(Me)
        '.m_wht.Direction.Value = 1

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)

        .m_payment = New Payment(Me)

        .m_je = New JournalEntry(Me)

      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property Type() As Integer
      Get
        Return m_type
      End Get
      Set(ByVal Value As Integer)
        m_type = Value
      End Set
    End Property
    '--------------------REAL-------------------------
    Public Property RealTaxAmount() As Decimal
      Get
        Return m_realTaxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxAmount = Value
      End Set
    End Property
    Public Property RealTaxBase() As Decimal      Get        Return m_realTaxBase      End Get      Set(ByVal Value As Decimal)        m_realTaxBase = Value      End Set    End Property
    '--------------------END REAL-------------------------
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public Property Supplier() As Supplier      Get        Return m_supplier      End Get      Set(ByVal Value As Supplier)        Dim oldPerson As IBillablePerson = m_supplier
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If        m_supplier = Value      End Set    End Property    Public Property DocDate() As Date Implements IVatable.Date, IWitholdingTaxable.Date, IGLAble.Date, IPayable.Date, IPaymentItem.DueDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public Property DueDate() As Date Implements IPayable.DueDate
      Get
        Return Me.DocDate.AddDays(Me.CreditPeriod)
      End Get
      Set(ByVal Value As Date)

      End Set
    End Property    Public Property CostCenter() As CostCenter      Get        Return m_costCenter      End Get      Set(ByVal Value As CostCenter)        m_costCenter = Value      End Set    End Property    Public ReadOnly Property ToAccount() As Account      Get        If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then          Return Me.CostCenter.StoreAccount
        End If      End Get    End Property    Public Property Vat() As Vat Implements IVatable.Vat      Get        Return m_vat      End Get      Set(ByVal Value As Vat)        m_vat = Value      End Set    End Property    Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
      Get
        Return m_whtcol
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_whtcol = Value
      End Set
    End Property    Public Property Payment() As Payment Implements IPayable.Payment
      Get
        Return m_payment
      End Get
      Set(ByVal Value As Payment)
        m_payment = Value
      End Set
    End Property    Public Property Note() As String Implements IPayable.Note, IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Long      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Long)        m_creditPeriod = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, AdvancePayStatus)      End Set    End Property    Public Property TaxRate() As Decimal      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Select Case Me.TaxType.Value
          Case 0 '"�����"
            Return 0
          Case 1, 2
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
        End Select
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property    Public Property TaxType() As TaxType      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"�����"
            Return 0
          Case 2 '��� VAT
            Return Me.AfterTax - Me.RealTaxBase
          Case Else '1 �¡
            Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)        End Select      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"�����"
            Return Me.AfterTax
          Case 1 '"�¡"
            Return Me.AfterTax
          Case 2 '"���"
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
        End Select      End Get    End Property    Private m_afterTax As Decimal    Public Property AfterTax() As Decimal Implements IHasAmount.Amount      Get        Return m_afterTax      End Get      Set(ByVal Value As Decimal)        m_afterTax = Value
      End Set    End Property    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.CostCenter = Value
      End Set
    End Property

    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.CostCenter = Value
      End Set
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AdvancePay"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "advp"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "advancepay"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AdvancePay.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AdvancePay"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AdvancePay"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AdvancePay.ListLabel}"
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

#Region "Shared"
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "AdvancePay"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      ' Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "advpp_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvancePayDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "advpp_linenumber"

      Dim csDate As New TreeTextColumn
      csDate.MappingName = "Date"
      csDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvancePayDetail.DateHeaderText}")
      csDate.NullText = ""
      'csCode.ReadOnly = True
      csDate.TextBox.Name = "Date"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvancePayDetail.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvancePayDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"

      Dim csRemainingAmount As New TreeTextColumn
      csRemainingAmount.MappingName = "RemainingAmount"
      csRemainingAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvancePayDetail.RemainingAmountHeaderText}")
      csRemainingAmount.NullText = ""
      csRemainingAmount.TextBox.Name = "RemainingAmount"
      csRemainingAmount.ReadOnly = True
      csRemainingAmount.Format = "#,###.##"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "advpp_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvancePayDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "advpp_note"


      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csRemainingAmount)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function

    Public Shared Sub UnitClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 4 Then
        RaiseEvent UnitButtonClick(e)
      Else
        RaiseEvent ItemButtonClick(e)
      End If
    End Sub
    Public Shared Event UnitButtonClick As DataGridButtonColumn.ButtonColumnClickHandler
    Public Shared Event ItemButtonClick As DataGridButtonColumn.ButtonColumnClickHandler

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("AdvancePay")

      myDatatable.Columns.Add(New DataColumn("advpp_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainingAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("advpp_note", GetType(String)))
      Return myDatatable
    End Function
    Public Shared Function GetAdvancePayRemain(ByVal txtCode As TextBox, ByVal txtAmount As TextBox, ByRef oldADVP As AdvancePay) As Boolean
      Dim advp As New AdvancePay(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not advp.Valid Then
        MessageBox.Show(txtCode.Text & " �������к�")
        advp = oldADVP
      End If
      'If advp.Valid Then
      txtCode.Text = advp.Code
      txtAmount.Text = Configuration.FormatToString(advp.GetRemainingAmount, DigitConfig.Price)
      If oldADVP Is Nothing OrElse oldADVP.Id <> advp.Id Then
        oldADVP = advp
        Return True
      End If
      'End If
      'txtCode.Text = ""
      'txtAmount.Text = Configuration.FormatToString(0, DigitConfig.Price)
      Return False
    End Function
#End Region

#Region "Shared2"
    Public Shared Function GetAdvancePaySelectionSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("AdvancePaySelection")
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("remain", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("amount", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Dim m_AdvisReference As Nullable(Of Boolean)
    Public Overrides Function IsReferenced() As Boolean
      Try
        If m_AdvisReference.HasValue Then
          Return m_AdvisReference.Value
        End If
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAdvancePayIsReferenced" _
                , New SqlParameter("@entity_id", Me.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If ds.Tables(0).Rows(0).IsNull(0) Then
            m_AdvisReference = False
            Return False
          End If
          m_AdvisReference = CBool(ds.Tables(0).Rows(0)(0))
          Return m_AdvisReference.Value
        End If
      Catch ex As Exception
      End Try
      Return False
    End Function
    Public Function GetRemainingAmount() As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAdvancePayAmount" _
                , New SqlParameter("@advp_id", Me.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmount(ByVal paymentId As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAdvancePayAmount" _
                , New SqlParameter("@advp_id", Me.Id) _
                , New SqlParameter("@paymenti_payment", paymentId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainExcludeVatAmount(Optional ByVal myValue As Decimal = 0) As Decimal
      Dim myTemp As Decimal
      If myValue > 0 Then
        If Not Me.m_taxType Is Nothing And Me.m_taxType.Value = 2 Then  '������ Vat ����¡ Vat
          myTemp = Vat.GetExcludedVatAmount(myValue)
        Else
          myTemp = myValue
        End If
      Else
        If Not Me.m_taxType Is Nothing And Me.m_taxType.Value = 2 Then
          myTemp = Vat.GetExcludedVatAmount(Me.GetRemainingAmount)
        Else
          myTemp = Me.GetRemainingAmount
        End If
      End If
      Return myTemp
    End Function
    Public Function GetRemainVatAmount(Optional ByVal myValue As Decimal = 0) As Decimal
      Dim myTemp As Decimal
      If myValue > 0 Then
        If Not Me.m_taxType Is Nothing And Me.m_taxType.Value = 2 Then  '������ Vat
          myTemp = myValue - GetRemainExcludeVatAmount(myValue)
        Else
          myTemp = 0
        End If
      Else
        If Not Me.m_taxType Is Nothing And Me.m_taxType.Value = 2 Then
          myTemp = Me.GetRemainingAmount - GetRemainExcludeVatAmount()
        Else
          myTemp = 0
        End If
      End If
      Return myTemp
    End Function
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldvat As Integer, ByVal oldpay As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_vat.Id = oldvat
      Me.m_payment.Id = oldpay
      Me.m_je.Id = oldje
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
    End Sub
        Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
            Me.Code = oldCode
            Me.AutoGen = oldautogen
            Me.m_payment.Code = oldJecode
            Me.m_payment.AutoGen = oldjeautogen
            Me.m_je.Code = oldJecode
            Me.m_je.AutoGen = oldjeautogen
        End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
                'Dim oldcode As String
                'Dim oldjecode As String
        If Originated Then
          If Not Supplier Is Nothing Then
            If Supplier.Canceled Then
              Return New SaveErrorException(StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Supplier.Code})
            End If
          End If
        End If

        Dim tmpTaxBase As Decimal = Configuration.Format(Me.RealTaxBase, DigitConfig.Price)
        Dim tmpVatTaxBase As Decimal = Configuration.Format(Me.Vat.TaxBase, DigitConfig.Price)
        'If tmpTaxBase <> tmpVatTaxBase Then
        '    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.TaxBaseNotEqualRefDocTaxBase}"), _
        '    New String() {Configuration.FormatToString(tmpVatTaxBase, DigitConfig.Price) _
        '    , Configuration.FormatToString(tmpTaxBase, DigitConfig.Price)})
        'End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@advp_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_payment.Status.Value = 4
          Me.m_whtcol.SetStatus(4)
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status = New AdvancePayStatus(2)
        End If

        '---- AutoCode Format --------
        Me.m_je.RefreshGLFormat()

                Dim oldcode As String
                Dim oldautogen As Boolean
                Dim oldjecode As String
                Dim oldjeautogen As Boolean

                oldcode = Me.Code
                oldautogen = Me.AutoGen
                oldjecode = Me.m_je.Code
                oldjeautogen = Me.m_je.AutoGen
        If Not AutoCodeFormat Is Nothing Then


          Select Case Me.AutoCodeFormat.CodeConfig.Value
            Case 0
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.DontSave = True
              Me.m_je.Code = ""
              Me.m_je.DocDate = Me.DocDate
            Case 1
              '��� entity
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.Code = Me.Code
            Case 2
              '��� gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
            Case Else
              '�¡
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        Me.m_payment.Code = m_je.Code
        'Me.m_payment.DocDate = m_je.DocDate
        If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
          Me.m_payment.Code = Me.Code
          Me.m_payment.DocDate = Me.DocDate
        End If
        Me.m_payment.DocDate = Me.DocDate
        Me.AutoGen = False
        Me.m_payment.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.Supplier.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Supplier.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toAcct", ValidIdOrDBNull(Me.ToAccount)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ValidIdOrDBNull(Me.CostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_afterTax", Me.AfterTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.Type))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Dim oldvat As Integer = Me.m_vat.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If
        Dim oldpay As Integer = Me.m_payment.Id
        Dim oldje As Integer = Me.m_je.Id

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1
                trans.Rollback()
                Me.ResetID(oldid, oldvat, oldpay, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -2
                trans.Rollback()
                Me.ResetID(oldid, oldvat, oldpay, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -5
                trans.Rollback()
                Me.ResetID(oldid, oldvat, oldpay, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldvat, oldpay, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If
          If Not Me.CostCenter Is Nothing Then
            Me.m_payment.CCId = Me.CostCenter.Id
            Me.m_whtcol.SetCCId(Me.CostCenter.Id)
            Me.m_vat.SetCCId(Me.CostCenter.Id)
          End If
          Me.m_vat.SetRefDocToItem(Me.Id, Me.EntityId)
          Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveVatError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldvat, oldpay, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveVatError
          End If
          If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
            Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveWhtError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldvat, oldpay, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveWhtError
            Else
              Select Case CInt(saveWhtError.Message)
                Case -1, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldvat, oldpay, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveWhtError
                Case -2
                  trans.Rollback()
                  Me.ResetID(oldid, oldvat, oldpay, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveWhtError
                Case Else
              End Select
            End If
          End If
          Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
          If Not IsNumeric(savePaymentError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldvat, oldpay, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return savePaymentError
          Else
            Select Case CInt(savePaymentError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldvat, oldpay, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return savePaymentError
              Case -2
                trans.Rollback()
                Me.ResetID(oldid, oldvat, oldpay, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return savePaymentError
              Case Else
            End Select
          End If


          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldvat, oldpay, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldvat, oldpay, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveJeError
              Case -2
                'Post �����
                Return saveJeError
              Case Else
            End Select
          End If

          '==============================AUTOGEN==========================================
          Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          If Not IsNumeric(saveAutoCodeError.Message) Then
            trans.Rollback()
            ResetID(oldid, oldvat, oldpay, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid, oldvat, oldpay, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================

          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid, oldvat, oldpay, oldje)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid, oldvat, oldpay, oldje)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
#End Region

#Region "Items"
    Public Overloads Sub ReLoadItems()
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      LoadItems()
      Me.IsInitialized = True
    End Sub
    Public Overloads Sub ReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      Me.IsInitialized = True
    End Sub
    Private Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetAdvancePayPayments" _
      , New SqlParameter("@advp_id", Me.Id) _
      )

      Dim i As Integer = 0
      Dim amt As Decimal = Me.AfterTax
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim dr As TreeRow = m_itemTable.Childs.Add
        dr("advpp_linenumber") = i
        dr("Date") = row("refdocDate")
        dr("Code") = row("refdocCode")
        dr("advpp_note") = row("refdocNote")
        If IsNumeric(row("amount")) Then
          Dim rowAmt As Decimal = CDec(row("amount"))
          dr("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
          amt -= rowAmt
        End If
        dr("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
      Next
    End Sub
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem

      If Me.BeforeTax > 0 Then
        '�Ѵ�Ө�����ǧ˹��
        ji = New JournalEntryItem
        ji.Mapping = "B4.1"
        ji.Amount = Configuration.Format(Me.BeforeTax, DigitConfig.Price)
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If


      '���ի���
      If Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B4.2"
        ji.Amount = Configuration.Format(Me.RealTaxAmount, DigitConfig.Price)
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      For Each vi As VatItem In Me.Vat.ItemCollection
        If vi.Amount > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "B4.2D"
          ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = vi.Code & "/" & vi.PrintName
          jiColl.Add(ji)
        End If
      Next

      '���ի������֧��˹�
      If Me.RealTaxAmount - Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B4.2.1"
        ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.Note = Me.Code & ":�Ѵ�Ө���:" & Me.Supplier.Name
        ji.EntityItem = Me.Id
        ji.EntityItemType = Me.EntityId
        jiColl.Add(ji)
      End If

      '�����ѡ � ������
      If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B4.10"
        ji.Amount = Me.WitholdingTaxCollection.Amount
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
      Dim WHTTypeSum As New Hashtable

      For Each wht As WitholdingTax In Me.WitholdingTaxCollection
        If WHTTypeSum.Contains(wht.Type.Value) Then
          WHTTypeSum(wht.Type.Value) = CDec(WHTTypeSum(wht.Type.Value)) + wht.Amount
        Else
          WHTTypeSum(wht.Type.Value) = wht.Amount
        End If
      Next
      Dim typeNum As String
      For Each obj As Object In WHTTypeSum.Keys
        typeNum = CStr(obj)
        If Not (typeNum.Length > 1) Then
          typeNum = "0" & typeNum
        End If
        If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.18"
          ji.Amount = CDec(WHTTypeSum(obj))
          ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
        End If
      Next
      For Each wht As WitholdingTax In Me.WitholdingTaxCollection
        typeNum = CStr(wht.Type.Value)
        If Not (typeNum.Length > 1) Then
          typeNum = "0" & typeNum
        End If
        If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.18D"
          ji.Amount = wht.Amount
          ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
        End If
      Next
      For Each wht As WitholdingTax In Me.WitholdingTaxCollection
        typeNum = CStr(wht.Type.Value)
        If Not (typeNum.Length > 1) Then
          typeNum = "0" & typeNum
        End If
        If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.18W"
          ji.Amount = wht.Amount
          ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
        End If
      Next
      If Not Me.Payment Is Nothing Then
        jiColl.AddRange(Me.Payment.GetJournalEntries)
      End If
      Return jiColl
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property
#End Region

#Region "IVatable"
    Public Function GetMaximumTaxBase() As Decimal Implements IVatable.GetMaximumTaxBase
      Return Me.RealTaxBase
    End Function
    Public Property Person() As IBillablePerson Implements IVatable.Person, IWitholdingTaxable.Person
      Get
        Return Me.Supplier
      End Get
      Set(ByVal Value As IBillablePerson)
        Me.Supplier = CType(Value, Supplier)
      End Set
    End Property
    Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax
      Return Me.AfterTax
    End Function
    Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax
      Return Me.BeforeTax
    End Function
    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        Return Me.TaxType.Value = 0
      End Get
    End Property
#End Region

#Region "IWitholdingTaxable"
    Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return Me.RealTaxBase
    End Function
#End Region

#Region "IPayable"
    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      Return Me.AfterTax
    End Function
    Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount
      Return 0
    End Function
    Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
      Get
        Return Me.Supplier
      End Get
    End Property
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "AdvancePay"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "AdvancePay"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      '            �Ţ����͡���(Code)
      '            �ѹ����͡���(DocDate)
      '            �Ţ���㺡ӡѺ����(RefDoc)
      '            �ѹ���(RefDate)
      '            �����(SupplierInfo)
      '            ���ʼ����(SupplierCode)
      '            ���ͼ����(SupplierName)
      '            CostCenter(CostCenterInfo)
      '���� CostCenter	CostCenterCode
      '���� CostCenter	CostCenterName
      '            �ôԵ(CreditPeriod)
      '            ������(TaxType)
      '            �ѵ������(TaxRate)
      '            �ú��˹�(DueDate)
      '            �ӹǹ�Թ��͹����(BeforeTax)
      '            ������Ť������(TaxAmount)
      '            ��Ť���������(AfterTax)
      '            �ʹ�Թ�Ѵ�Ӥ������(Amount)
      '            �����˵�(Note)

      'Code
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'RefCode
      dpi = New DocPrintingItem
      dpi.Mapping = "RefDoc"
      dpi.Value = Me.Vat.GetVatItemCodes()
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'RefDate
      dpi = New DocPrintingItem
      dpi.Mapping = "RefDate"
      dpi.Value = Me.Vat.GetVatItemDates()
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'SupplierInfo
      If Me.Supplier.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierInfo"
        dpi.Value = Me.Supplier.Code & ":" & Me.Supplier.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierCode"
        dpi.Value = Me.Supplier.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierName"
        dpi.Value = Me.Supplier.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CostCenterInfo
      If Me.CostCenter.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CreditPeriod
      dpi = New DocPrintingItem
      dpi.Mapping = "CreditPeriod"
      dpi.Value = Me.CreditPeriod
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TaxType
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxType"
      dpi.Value = Me.TaxType.Description
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TaxRate
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxRate"
      dpi.Value = Me.TaxRate
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.Datetime"
      dpiColl.Add(dpi)

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      dpi.Value = Configuration.FormatToString(Me.RealTaxAmount, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'Amount
      dpi = New DocPrintingItem
      dpi.Mapping = "Amount"
      dpi.Value = Configuration.FormatToString(Me.GetRemainingAmount, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)
      Dim sumAmount As Decimal
      Dim sumRemainingAmount As Decimal
      Dim n As Integer = 0
      For i As Integer = 0 To Me.m_itemTable.Rows.Count - 1
        Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = itemRow("advpp_linenumber")
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.DocDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DocDate"
        dpi.Value = itemRow("Date")
        dpi.DataType = "System.DateTime"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.DocCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DocCode"
        dpi.Value = itemRow("Code")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Amount"
        dpi.Value = itemRow("Amount")
        dpi.DataType = "System.Decimal"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        If Not IsDBNull(dpi.Value) Then
          sumAmount += CDec(dpi.Value)
        End If

        'Item.RemainingAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RemainingAmount"
        dpi.Value = itemRow("RemainingAmount")
        dpi.DataType = "System.Decimal"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        If Not IsDBNull(dpi.Value) Then
          sumRemainingAmount += CDec(dpi.Value)
        End If

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = 1234 'itemRow("advpp_note")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)



        n += 1

      Next

      'Item.TotalAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "Item.TotalAmount"
      dpi.Value = Configuration.FormatToString(sumAmount, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'Item.TotalRemainingAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "Item.TotalRemainingAmount"
      dpi.Value = Configuration.FormatToString(sumRemainingAmount, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)


      Return dpiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        ' Hack :
        Return Not Me.IsReferenced() 'True
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAdvancePay}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAdvancePay", New SqlParameter() {New SqlParameter("@advp_id", Me.Id), returnVal})
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePaymentItemEntityStatus", New SqlParameter("@payment_id", Me.Payment.Id))
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AdvancePayIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        trans.Commit()
        Return New SaveErrorException("1")
      Catch ex As SqlException
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Finally
        conn.Close()
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

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Dim refAmt As Decimal = 0
        For Each row As DataRow In Me.ItemTable.Rows
          If Not row.IsNull("Amount") Then
            refAmt += CDec(row("Amount"))
          End If
        Next
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable AndAlso refAmt = 0
      End Get
    End Property

    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Me.Payment.Status.Value = 0
      Me.JournalEntry.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

  End Class


  Public Interface IAdvancePayItemAble
    Inherits IIdentifiable
    Property DocDate() As Date
    Property Supplier() As Supplier
    Property Note() As String
    Property AdvancePayItemCollection() As AdvancePayItemCollection
    Property TaxType() As TaxType
  End Interface


  Public Class AdvancePayItem
    Implements ICloneable

#Region "Members"
    Private m_advancepay As AdvancePay
    Private m_lineNumber As Integer
    Private m_amt As Decimal
    Private m_refDocDate As Date
    Private m_note As String
    Private m_status As Integer
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
        If dr.Table.Columns.Contains(aliasPrefix & "advpi_advp") AndAlso Not dr.IsNull(aliasPrefix & "advpi_advp") Then
          .m_advancepay = New AdvancePay(CInt(dr(aliasPrefix & "advpi_advp")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advpi_linenumber") AndAlso Not dr.IsNull(aliasPrefix & "advpi_linenumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "advpi_linenumber"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advpi_amt") AndAlso Not dr.IsNull(aliasPrefix & "advpi_amt") Then
          .m_amt = CDec(dr(aliasPrefix & "advpi_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advpi_refdocdate") AndAlso Not dr.IsNull(aliasPrefix & "advpi_refdocdate") Then
          .m_refDocDate = CDate(dr(aliasPrefix & "advpi_refdocdate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advpi_note") AndAlso Not dr.IsNull(aliasPrefix & "advpi_note") Then
          .m_note = CStr(dr(aliasPrefix & "advpi_note"))
        End If
        'type
        'If dr.Table.Columns.Contains(aliasPrefix & "advp_type") AndAlso Not dr.IsNull(aliasPrefix & "advp_type") Then
        '  .m_type = CInt(dr(aliasPrefix & "advp_type"))
        'End If
        If dr.Table.Columns.Contains(aliasPrefix & "advpi_status") AndAlso Not dr.IsNull(aliasPrefix & "advpi_status") Then
          .m_status = CInt(dr(aliasPrefix & "advpi_status"))
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property AdvancePay() As AdvancePay      Get        Return m_advancepay      End Get      Set(ByVal Value As AdvancePay)        m_advancepay = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property RefDocDate() As Date      Get        Return m_refDocDate      End Get      Set(ByVal Value As Date)        m_refDocDate = Value      End Set    End Property    'Public Property RefAmount() As Decimal    '    Get    '        Return m_refamt    '    End Get    '    Set(ByVal Value As Decimal)    '        m_refamt = Value    '    End Set    'End Property    Public Property Amount() As Decimal      Get        Return m_amt      End Get      Set(ByVal Value As Decimal)        m_amt = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Status() As Integer      Get        Return m_status      End Get      Set(ByVal Value As Integer)        m_status = Value      End Set    End Property#End Region

#Region "ICloneable"
    Public Function Clone() As Object Implements System.ICloneable.Clone
      Dim advpi As New AdvancePayItem
      advpi.m_advancepay = Me.m_advancepay
      advpi.m_amt = Me.m_amt
      advpi.Note = Me.m_note
      advpi.m_refDocDate = Me.m_refDocDate
      Return advpi
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class AdvancePayItemCollection
    Inherits CollectionBase
    Implements ICloneable

#Region "Members"
    Private advpi_refDoc As IAdvancePayItemAble
    Private m_advpi As AdvancePayItem
#End Region

#Region "Constructors"
    Public Sub New()
      Me.m_advpi = New AdvancePayItem
    End Sub
    Public Sub New(ByVal refDoc As IAdvancePayItemAble)
      Me.New(refDoc.Id, CType(refDoc, IObjectReflectable).EntityId)
      Me.RefDoc = refDoc
    End Sub
    Public Sub New(ByVal refId As Integer, ByVal refType As Integer)
      If refId = 0 Then
        Return
      End If
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetAdvancePayItemList" _
      , New SqlParameter("@refid", refId) _
      , New SqlParameter("@reftype", refType))

      If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count >= 1 Then
        For Each row As DataRow In ds.Tables(0).Rows
          Dim item As New AdvancePayItem(row, "")
          Me.Add(item)
        Next
      End If
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As AdvancePayItem
      Get
        Return CType(MyBase.List.Item(index), AdvancePayItem)
      End Get
      Set(ByVal value As AdvancePayItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property RefDoc() As IAdvancePayItemAble
      Get
        Return advpi_refDoc
      End Get
      Set(ByVal Value As IAdvancePayItemAble)
        advpi_refDoc = Value
      End Set
    End Property
#End Region

#Region "Shared"
#End Region

#Region "Class Methods"
    Public Function GetAmount() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvancePayItem In Me
        ret += item.Amount
      Next
      Return ret
    End Function
    Public Function GetAmountForCalculate() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvancePayItem In Me
        If item.AdvancePay.TaxType.Value = 2 Then
          ret += item.Amount
        End If
      Next
      Return ret
    End Function
    Public Function GetExcludeVATAmount() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvancePayItem In Me
        ret += item.AdvancePay.GetRemainExcludeVatAmount(item.Amount)
      Next
      Return ret
    End Function
    Public Function GetExcludeVATAmountForCalculate() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvancePayItem In Me
        If item.AdvancePay.TaxType.Value = 2 Then
          ret += item.AdvancePay.GetRemainExcludeVatAmount(item.Amount)
        End If
      Next
      Return ret
    End Function
    Public Function GetVATAmount() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvancePayItem In Me
        ret += item.AdvancePay.GetRemainVatAmount(item.Amount)
      Next
      Return ret
    End Function
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each advpayi As AdvancePayItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        If Not advpayi.AdvancePay Is Nothing AndAlso advpayi.AdvancePay.Originated Then
          newRow("Code") = advpayi.AdvancePay.Code
        End If
        newRow("amount") = Configuration.FormatToString(advpayi.Amount, DigitConfig.Price)
        newRow.Tag = advpayi
      Next
    End Sub
    Public Sub CleanCollection()
      Dim temp As New ArrayList
      For Each item As AdvancePayItem In Me
        If item.AdvancePay Is Nothing OrElse Not item.AdvancePay.Originated Then
          temp.Add(item)
        End If
      Next
      For Each item As AdvancePayItem In temp
        Me.Remove(item)
      Next
    End Sub

    Public Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      If advpi_refDoc Is Nothing Then
        'UNDONE
        Return New SaveErrorException("RefDoc Is Nothing")
      End If

      Try
        Dim refDocType As Integer
        If TypeOf advpi_refDoc Is ISimpleEntity Then
          refDocType = CType(advpi_refDoc, ISimpleEntity).EntityId
        End If

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "Select * from advancepayitem where advpi_refdoc=" & advpi_refDoc.Id & " and advpi_refdoctype =" & refDocType

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        m_da.SelectCommand.Transaction = trans

        '��ͧ�����ͨҡ da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        m_da.Fill(m_dataset, "advancepayitem")

        Dim dt As DataTable = m_dataset.Tables("advancepayitem")
        For Each row As DataRow In dt.Rows
          row.Delete()
        Next

        Dim i As Integer = 0

        For Each item As AdvancePayItem In Me
          i += 1
          Dim dr As DataRow = dt.NewRow
          dr("advpi_advp") = item.AdvancePay.Id
          dr("advpi_linenumber") = i 'item.LineNumber
          dr("advpi_refdoc") = Me.RefDoc.Id
          dr("advpi_refdoctype") = refDocType
          dr("advpi_refdoccode") = Me.RefDoc.Code
          dr("advpi_refdocdate") = Me.RefDoc.DocDate
          'dr("advpi_refamt") = 
          dr("advpi_amt") = item.Amount
          dr("advpi_note") = Me.RefDoc.Note
          dr("advpi_status") = item.Status
          dt.Rows.Add(dr)
        Next

        ' First process deletes.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException("Error Saving:" & ex.ToString)
      End Try
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As AdvancePayItem) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Function Contains(ByVal value As AdvancePayItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As AdvancePayItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Function IndexOf(ByVal value As AdvancePayItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As AdvancePayItem)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As AdvancePayItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

#Region "ICloneable"
    Public Function Clone() As Object Implements System.ICloneable.Clone
      Dim newColl As New AdvancePayItemCollection
      newColl.m_advpi = Me.m_advpi
      For Each oldItem As AdvancePayItem In Me
        newColl.Add(CType(oldItem.Clone, AdvancePayItem))
      Next
      Return newColl
    End Function
#End Region

    Public Class AdvancePayItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As AdvancePayItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, AdvancePayItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class
  End Class
End Namespace
