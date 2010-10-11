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
  Public Class AdvanceReceiveStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "advr_status"
      End Get
    End Property
#End Region

  End Class
  Public Class AdvanceReceive
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IVatable, IWitholdingTaxable, IHasAmount, ISaleBillIssuable, IHasIBillablePerson, IHasFromCostCenter, IHasToCostCenter, ICheckPeriod


#Region "Members"
    Private m_customer As Customer
    Private m_costCenter As CostCenter

    Private m_docDate As Date


    Private m_vat As Vat
    Private m_whtcol As WitholdingTaxCollection
    Private m_receive As Receive
    Private m_je As JournalEntry

    Private m_note As String
    Private m_creditPeriod As Integer

    Private m_taxRate As Decimal
    Private m_taxType As TaxType

    Private m_status As AdvanceReceiveStatus

    Private m_itemTable As TreeTable

    Private m_realTaxBase As Decimal
    Private m_realTaxAmount As Decimal

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      ReLoadItems()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
      ReLoadItems()
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docDate = Now.Date
        .m_customer = New Customer
        .m_creditPeriod = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_taxType = New TaxType(2)
        .m_status = New AdvanceReceiveStatus(-1)
        Me.m_costCenter = New CostCenter

        '----------------------------Tab Entities-----------------------------------------
        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 0

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        .m_receive = New Receive(Me)
        .m_receive.DocDate = Me.m_docDate
        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("customer.cust_id") Then
          If Not dr.IsNull("customer.cust_id") Then
            .m_customer = New Customer(dr, "customer.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "advr_entity") Then
            .m_customer = New Customer(CInt(dr(aliasPrefix & "advr_entity")))
          End If
        End If

        If dr.Table.Columns.Contains("costcenter.cc_id") Then
          If Not dr.IsNull("costcenter.cc_id") Then
            .m_costCenter = New CostCenter(dr, "costcenter.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "advr_cc") Then
            .m_costCenter = New CostCenter(CInt(dr(aliasPrefix & "advr_cc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "advr_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "advr_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "advr_creditperiod"))
        End If
        If Not dr.IsNull(aliasPrefix & "advr_aftertax") Then
          .m_afterTax = CDec(dr(aliasPrefix & "advr_aftertax"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "CostCenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "CostCenter.cc_id") Then
            .m_costCenter = New CostCenter(dr, "CostCenter.")
          End If
        Else
          If dr.Table.Columns.Contains("advr_tocc") AndAlso Not dr.IsNull(aliasPrefix & "advr_tocc") Then
            .m_costCenter = New CostCenter(CInt(dr(aliasPrefix & "advr_tocc")))
          End If
        End If

        If dr.Table.Columns.Contains("advr_docDate") AndAlso Not dr.IsNull(aliasPrefix & "advr_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "advr_docDate"))
        End If

        If dr.Table.Columns.Contains("advr_note") AndAlso Not dr.IsNull(aliasPrefix & "advr_note") Then
          .m_note = CStr(dr(aliasPrefix & "advr_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advr_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "advr_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "advr_taxtype")))
        End If

        If Not dr.IsNull(aliasPrefix & "advr_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "advr_taxrate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advr_status") AndAlso Not dr.IsNull(aliasPrefix & "advr_status") Then
          .m_status = New AdvanceReceiveStatus(CInt(dr(aliasPrefix & "advr_status")))
        End If

        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "advr_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "advr_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "advr_taxbase"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "advr_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "advr_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "advr_taxamt"))
        End If
        '--------------------END REAL-------------------------

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 0

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_receive = New Receive(Me)

        .m_je = New JournalEntry(Me)

      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
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
    Public Property Customer() As Customer      Get        Return m_customer      End Get      Set(ByVal Value As Customer)        Dim oldPerson As IBillablePerson = m_customer
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If        m_customer = Value      End Set    End Property    Public Property DocDate() As Date Implements IVatable.Date, IWitholdingTaxable.Date, IGLAble.Date, IReceivable.Date, ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public Property DueDate() As Date Implements IReceivable.DueDate
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
    End Property    Public Property Receive() As Receive Implements IReceivable.Receive
      Get
        Return m_receive
      End Get
      Set(ByVal Value As Receive)
        m_receive = Value
      End Set
    End Property    Public Property Note() As String Implements IReceivable.Note, IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        m_creditPeriod = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, AdvanceReceiveStatus)      End Set    End Property    Public Property TaxRate() As Decimal      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1, 2
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
        End Select
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property    Public Property TaxType() As TaxType      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 2 'รวม VAT
            Return Me.AfterTax - Me.RealTaxBase
          Case Else '1 แยก
            Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)        End Select      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.AfterTax
          Case 1 '"แยก"
            Return Me.AfterTax
          Case 2 '"รวม"
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
        End Select      End Get    End Property    Private m_afterTax As Decimal    Public Property AfterTax() As Decimal Implements IHasAmount.Amount      Get        Return m_afterTax      End Get      Set(ByVal Value As Decimal)        m_afterTax = Value
      End Set    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AdvanceReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "advr"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "advancereceive"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AdvanceReceive.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AdvanceReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AdvanceReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AdvanceReceive.ListLabel}"
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
      dst.MappingName = "AdvanceReceive"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      ' Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "advrp_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "advrp_linenumber"

      Dim csDate As New TreeTextColumn
      csDate.MappingName = "Date"
      csDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveDetail.DateHeaderText}")
      csDate.NullText = ""
      'csCode.ReadOnly = True
      csDate.TextBox.Name = "Date"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveDetail.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"

      Dim csRemainingAmount As New TreeTextColumn
      csRemainingAmount.MappingName = "RemainingAmount"
      csRemainingAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveDetail.RemainingAmountHeaderText}")
      csRemainingAmount.NullText = ""
      csRemainingAmount.TextBox.Name = "RemainingAmount"
      csRemainingAmount.ReadOnly = True
      csRemainingAmount.Format = "#,###.##"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "advrp_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AdvanceReceiveDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "advrp_note"

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
      Dim myDatatable As New TreeTable("AdvanceReceive")

      myDatatable.Columns.Add(New DataColumn("advrp_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainingAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("advrp_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("refdoc", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("reftype", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Shared2"
    Public Shared Function GetAdvanceReceiveSelectionSchema() As TreeTable
      Dim myDatatable As New TreeTable("AdvanceReceiveSelection")
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("remain", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("amount", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Function GetRemainingAmount() As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAdvanceReceiveAmount" _
                , New SqlParameter("@advr_id", Me.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

    End Function
    Public Function GetRemainingAmount(ByVal receiveID As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAdvanceReceiveAmount" _
                , New SqlParameter("@advr_id", Me.Id) _
                , New SqlParameter("@receivei_receive", receiveID) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainExcludeVatAmount(Optional ByVal myValue As Decimal = 0) As Decimal
      Dim myTemp As Decimal
      If myValue > 0 Then
        If Not Me.m_taxType Is Nothing And Me.m_taxType.Value = 2 Then  'ถ้ารวม Vat ให้แยก Vat
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
        If Not Me.m_taxType Is Nothing And Me.m_taxType.Value = 2 Then  'ถ้ารวม Vat
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
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer, ByVal oldvat As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_receive.Id = oldreceive
      Me.m_vat.Id = oldvat
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
      Me.m_je.Id = oldje
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim tmpTaxBase As Decimal = Configuration.Format(Me.RealTaxBase, DigitConfig.Price)
        Dim tmpVatTaxBase As Decimal = Configuration.Format(Me.Vat.TaxBase, DigitConfig.Price)
        If tmpTaxBase <> tmpVatTaxBase Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.TaxBaseNotEqualRefDocTaxBase}"), _
          New String() {Configuration.FormatToString(tmpVatTaxBase, DigitConfig.Price) _
          , Configuration.FormatToString(tmpTaxBase, DigitConfig.Price)})
        End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@advr_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_receive.Status.Value = 4
          Me.m_whtcol.SetStatus(4)
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status = New AdvanceReceiveStatus(2)
        End If

        '---- AutoCode Format --------
        Dim oldcode As String
        Dim oldautogen As Boolean
        Dim oldjecode As String
        Dim oldjeautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
        oldjecode = Me.m_je.Code
        oldjeautogen = Me.m_je.AutoGen

        Me.m_je.RefreshGLFormat()
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
              'ตาม entity
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.Code = Me.Code
            Case 2
              'ตาม gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
            Case Else
              'แยก
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
        Me.m_receive.Code = m_je.Code
        Me.m_receive.DocDate = m_je.DocDate
        If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
          Me.m_receive.Code = Me.Code
          Me.m_receive.DocDate = Me.DocDate
        End If
        Me.AutoGen = False
        Me.m_receive.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.Customer.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Customer.EntityId))
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


        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Dim oldreceive As Integer = m_receive.Id
        Dim oldvat As Integer = m_vat.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If
        Dim oldje As Integer = m_je.Id

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -2
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If
          If Not Me.CostCenter Is Nothing Then
            Me.m_receive.CcId = Me.CostCenter.Id
            Me.m_whtcol.SetCCId(Me.CostCenter.Id)
            Me.m_vat.SetCCId(Me.CostCenter.Id)
          End If
          '== Hack by pui ;ถ้าไม่มี vat ก็เคลียร์ Item ตรงนี้เลยละกัน =========
          If Me.TaxType.Value = 0 Then
            Me.m_vat.ItemCollection.Clear()
          End If
          '======================================================
          Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveVatError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return saveVatError
          End If
          If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
            Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveWhtError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              Return saveWhtError
            Else
              Select Case CInt(saveWhtError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  Return saveWhtError
                Case Else
              End Select
            End If
          End If

          Dim saveReceiveError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveReceiveError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return saveReceiveError
          Else
            Select Case CInt(saveReceiveError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                Return saveReceiveError
              Case -2
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                Return saveReceiveError
              Case Else
            End Select
          End If


          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                Return saveJeError
              Case -2
                'Post ไปแล้ว
                Return saveJeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================
          Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          If Not IsNumeric(saveAutoCodeError.Message) Then
            trans.Rollback()
            ResetID(oldid, oldreceive, oldvat, oldje)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid, oldreceive, oldvat, oldje)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================


          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldvat, oldje)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldvat, oldje)
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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetAdvanceReceiveSelectionReceive" _
      , New SqlParameter("@advr_id", Me.Id) _
      )

      Dim i As Integer = 0
      Dim amt As Decimal = Me.AfterTax
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim dr As TreeRow = m_itemTable.Childs.Add
        dr("advrp_linenumber") = i
        If IsDate(row("refdocDate")) Then
          dr("Date") = CDate(row("refdocDate")).ToShortDateString
        End If
        dr("Code") = row("refdocCode")
        dr("advrp_note") = row("refdocNote")
        dr("refdoc") = row("refdoc")
        dr("reftype") = row("reftype")
        If IsNumeric(row("amount")) Then
          Dim rowAmt As Decimal = CDec(row("amount"))
          dr("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
          amt -= rowAmt
        End If
        dr("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
      Next
    End Sub
    Public Function Add(ByVal item As AdvanceReceiveReceive) As TreeRow

    End Function
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
        'มัดจำรับล่วงหน้า
        ji = New JournalEntryItem
        ji.Mapping = "C4.2"
        ji.Amount = Configuration.Format(Me.BeforeTax, DigitConfig.Price)
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If


      'ภาษีขาย
      If Me.RealTaxAmount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "C4.3"
        ji.Amount = Configuration.Format(Me.RealTaxAmount, DigitConfig.Price)
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If


      'ภาษีถูกหัก ณ ที่จ่าย
      If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "C4.1"
        ji.Amount = Me.WitholdingTaxCollection.Amount
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)

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
            jiColl.Add(ji)
          End If
        Next
      End If

      If Not Me.Receive Is Nothing Then
        jiColl.AddRange(Me.Receive.GetJournalEntries)
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
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        Me.Customer = CType(Value, Customer)
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

#Region "IBillIssuable"
    Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive
      Return Me.AfterTax
    End Function
    Public Function RemainingAmount() As Decimal Implements IReceivable.RemainingAmount
      Return Me.GetRemainingAmount
    End Function
    Public ReadOnly Property Payer() As IBillablePerson Implements IReceivable.Payer
      Get
        Return Me.Customer
      End Get
    End Property
    Public Function GetRemainingAmountWithBillIssue(ByVal billi_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountWithBillIssue
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@salebillii_salebilli", billi_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountReceiveSelection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@receivesi_receives", receives_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer, ByVal billi_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountReceiveSelection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@receivesi_receives", receives_id) _
                , New SqlParameter("@billii_billi", billi_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return Me.Status.Value <= 2
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAdvanceReceive}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAdvanceReceive", New SqlParameter() {New SqlParameter("@advr_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AdvanceReceiveIsReferencedCannotBeDeleted}")
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
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Customer Then
          Me.Customer = CType(Value, Customer)
        End If
      End Set
    End Property
#End Region

    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.CostCenter = Value
      End Set
    End Property

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.CostCenter = Value
      End Set
    End Property

    
  End Class

  Public Class AdvanceReceiveReceive

  End Class


  Public Interface IAdvanceReceiveItemAble
    Inherits IIdentifiable
    Property DocDate() As Date
    Property Customer() As Customer
    Property Note() As String
    Property AdvanceReceiveItemCollection() As AdvanceReceiveItemCollection
    Property TaxType() As TaxType
  End Interface

  Public Class AdvanceReceiveItem
    Implements ICloneable

#Region "Members"
    Private m_advancereceive As AdvanceReceive
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
        If dr.Table.Columns.Contains(aliasPrefix & "advri_advr") AndAlso Not dr.IsNull(aliasPrefix & "advri_advr") Then
          .m_advancereceive = New AdvanceReceive(CInt(dr(aliasPrefix & "advri_advr")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advri_linenumber") AndAlso Not dr.IsNull(aliasPrefix & "advri_linenumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "advri_linenumber"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advri_amt") AndAlso Not dr.IsNull(aliasPrefix & "advri_amt") Then
          .m_amt = CDec(dr(aliasPrefix & "advri_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advri_refdocdate") AndAlso Not dr.IsNull(aliasPrefix & "advri_refdocdate") Then
          .m_refDocDate = CDate(dr(aliasPrefix & "advri_refdocdate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advri_note") AndAlso Not dr.IsNull(aliasPrefix & "advri_note") Then
          .m_note = CStr(dr(aliasPrefix & "advri_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "advri_status") AndAlso Not dr.IsNull(aliasPrefix & "advri_status") Then
          .m_status = CInt(dr(aliasPrefix & "advri_status"))
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property AdvanceReceive() As AdvanceReceive      Get        Return m_advancereceive      End Get      Set(ByVal Value As AdvanceReceive)        m_advancereceive = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property RefDocDate() As Date      Get        Return m_refDocDate      End Get      Set(ByVal Value As Date)        m_refDocDate = Value      End Set    End Property    Public Property Amount() As Decimal      Get        Return m_amt      End Get      Set(ByVal Value As Decimal)        m_amt = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Status() As Integer      Get        Return m_status      End Get      Set(ByVal Value As Integer)        m_status = Value      End Set    End Property#End Region

#Region "ICloneable"
    Public Function Clone() As Object Implements System.ICloneable.Clone
      Dim advri As New AdvanceReceiveItem
      advri.m_advancereceive = Me.m_advancereceive
      advri.m_amt = Me.m_amt
      advri.Note = Me.m_note
      advri.m_refDocDate = Me.m_refDocDate
      Return advri
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class AdvanceReceiveItemCollection
    Inherits CollectionBase
    Implements ICloneable

#Region "Members"
    Private advri_refDoc As IAdvanceReceiveItemAble
    Private m_advri As AdvanceReceiveItem
#End Region

#Region "Constructors"
    Public Sub New()
      Me.m_advri = New AdvanceReceiveItem
    End Sub
    Public Sub New(ByVal refDoc As IAdvanceReceiveItemAble)
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
      , "GetAdvanceReceiveItemList" _
      , New SqlParameter("@refid", refId) _
      , New SqlParameter("@reftype", refType))

      If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count >= 1 Then
        For Each row As DataRow In ds.Tables(0).Rows
          Dim item As New AdvanceReceiveItem(row, "")
          Me.Add(item)
        Next
      End If
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As AdvanceReceiveItem
      Get
        Return CType(MyBase.List.Item(index), AdvanceReceiveItem)
      End Get
      Set(ByVal value As AdvanceReceiveItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property RefDoc() As IAdvanceReceiveItemAble
      Get
        Return advri_refDoc
      End Get
      Set(ByVal Value As IAdvanceReceiveItemAble)
        advri_refDoc = Value
      End Set
    End Property
#End Region

#Region "Shared"
#End Region

#Region "Class Methods"
    Public Function GetAmount() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvanceReceiveItem In Me
        ret += item.Amount
      Next
      Return ret
    End Function
    Public Function GetAmountForCalculate() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvanceReceiveItem In Me
        If item.AdvanceReceive.TaxType.Value = 2 Then
          ret += item.Amount
        End If
      Next
      Return ret
    End Function
    Public Function GetExcludeVATAmount() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvanceReceiveItem In Me
        ret += item.AdvanceReceive.GetRemainExcludeVatAmount(item.Amount)
      Next
      Return ret
    End Function
    Public Function GetExcludeVATAmountForCalculate() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvanceReceiveItem In Me
        If item.AdvanceReceive.TaxType.Value = 2 Then
          ret += item.AdvanceReceive.GetRemainExcludeVatAmount(item.Amount)
        End If
      Next
      Return ret
    End Function
    Public Function GetVATAmount() As Decimal
      Dim ret As Decimal = 0
      For Each item As AdvanceReceiveItem In Me
        ret += item.AdvanceReceive.GetRemainVatAmount(item.Amount)
      Next
      Return ret
    End Function
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each advritem As AdvanceReceiveItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        If Not advritem.AdvanceReceive Is Nothing AndAlso advritem.AdvanceReceive.Originated Then
          newRow("Code") = advritem.AdvanceReceive.Code
        End If
        newRow("amount") = Configuration.FormatToString(advritem.Amount, DigitConfig.Price)
        newRow.Tag = advritem
      Next
    End Sub
    Public Sub CleanCollection()
      Dim temp As New ArrayList
      For Each item As AdvanceReceiveItem In Me
        If item.AdvanceReceive Is Nothing OrElse Not item.AdvanceReceive.Originated Then
          temp.Add(item)
        End If
      Next
      For Each item As AdvanceReceiveItem In temp
        Me.Remove(item)
      Next
    End Sub

    Public Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      If advri_refDoc Is Nothing Then
        'UNDONE
        Return New SaveErrorException("RefDoc Is Nothing")
      End If

      Try
        Dim refDocType As Integer
        If TypeOf advri_refDoc Is ISimpleEntity Then
          refDocType = CType(advri_refDoc, ISimpleEntity).EntityId
        End If

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "Select * from advancereceiveitem where advri_refdoc=" & advri_refDoc.Id & " and advri_refdoctype =" & refDocType

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        m_da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        m_da.Fill(m_dataset, "advancereceiveitem")

        Dim dt As DataTable = m_dataset.Tables("advancereceiveitem")
        For Each row As DataRow In dt.Rows
          row.Delete()
        Next

        Dim i As Integer = 0

        For Each item As AdvanceReceiveItem In Me
          i += 1
          Dim dr As DataRow = dt.NewRow
          dr("advri_advr") = item.AdvanceReceive.Id
          dr("advri_linenumber") = i 'item.LineNumber
          dr("advri_refdoc") = Me.RefDoc.Id
          dr("advri_refdoctype") = refDocType
          dr("advri_refdoccode") = Me.RefDoc.Code
          dr("advri_refdocdate") = Me.RefDoc.DocDate
          dr("advri_amt") = item.Amount
          dr("advri_note") = Me.RefDoc.Note
          dr("advri_status") = item.Status
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
    Public Function Add(ByVal value As AdvanceReceiveItem) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Function Contains(ByVal value As AdvanceReceiveItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As AdvanceReceiveItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Function IndexOf(ByVal value As AdvanceReceiveItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As AdvanceReceiveItem)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As AdvanceReceiveItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

#Region "ICloneable"
    Public Function Clone() As Object Implements System.ICloneable.Clone
      Dim newColl As New AdvanceReceiveItemCollection
      newColl.m_advri = Me.m_advri
      For Each oldItem As AdvanceReceiveItem In Me
        newColl.Add(CType(oldItem.Clone, AdvanceReceiveItem))
      Next
      Return newColl
    End Function
#End Region

    Public Class AdvanceReceiveItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As AdvanceReceiveItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, AdvanceReceiveItem)
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
