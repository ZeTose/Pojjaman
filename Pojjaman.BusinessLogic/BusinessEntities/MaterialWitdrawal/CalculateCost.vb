Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Imports System.Threading.Tasks
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class CalcMatCostStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "stock_status"   'Return "CalcMatCost_status"
      End Get
    End Property
#End Region

  End Class

  Public Class InventoryMethod
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)

      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "config_invmethod"   'Return "CalcMatCost_status"
      End Get
    End Property
#End Region

  End Class

  Public Class CalculateCost
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, ICheckPeriod, IPrintableEntity, INewGLAble


#Region "Members"

    Private m_docDate As Date
    Private m_olddocDate As Date

    Private m_startcalcdate As Date
    Private m_endcalcdate As Date

    Private m_inventorymethod As InventoryMethod

    Private m_CostCenter As CostCenter
    Private m_note As String
    Private m_status As CalcMatCostStatus

    Private m_je As JournalEntry
    Private m_matbfitems As CalcMatCostItemCollection
    Private m_matbuyitems As CalcMatCostItemCollection
    Private m_matmoveinitems As CalcMatCostItemCollection
    Private m_matmoveoutitems As CalcMatCostItemCollection
    Private m_matbalitems As CalcMatCostItemCollection
    Private m_matsumitems As CalcMatCostItemCollection

    Private m_wipbfitems As CalcMatCostItemCollection
    Private m_wipoutitems As CalcMatCostItemCollection

    Private m_buyothitems As CalcMatCostItemCollection

    Private m_wipsumitems As CalcMatCostItemCollection

    Private m_wipcannotcostitems As CalcMatCostItemCollection
    Private m_percentwip As Decimal

    'final output
    Private m_CostItems As CalcMatCostItemCollection
    Private m_wipbalItems As CalcMatCostItemCollection

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
        .m_je = New JournalEntry(Me)
        .m_note = ""
        .m_docDate = Now.Date
        .m_olddocDate = Now.Date
        .m_status = New CalcMatCostStatus(-1)
        Me.m_CostCenter = New CostCenter
        .m_je.DocDate = Me.m_docDate

        .m_inventorymethod = New InventoryMethod(CInt(Configuration.GetConfig("CompanyInventoryMethod")))
        'AutoCode
        Me.m_matbfitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatBF, False)
        Me.m_matbuyitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatBuy, False)
        Me.m_matmoveinitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatMoveIn, False)
        Me.m_matmoveoutitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatMoveOut, False)
        Me.m_matbalitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatBalance, False)

        Me.m_matsumitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatSum, False)

        Me.m_wipbfitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPBF, False)
        Me.m_wipoutitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPMoveOut, False)

        Me.m_buyothitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.BuyOth, False)

        Me.m_wipsumitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPSum, False)

        Me.m_wipcannotcostitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPCannotCost, False)

        Me.m_CostItems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.CostItem, False)
        Me.m_wipbalItems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPBalance, False)

        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        Dim drh As New DataRowHelper(dr)


        If dr.Table.Columns.Contains("cmc_cc") AndAlso Not dr.IsNull(aliasPrefix & "cmc_cc") Then
          .m_CostCenter = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "cmc_cc")))
          '.m_toCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_tocc")))
        End If

        If dr.Table.Columns.Contains("cmc_docDate") AndAlso Not dr.IsNull(aliasPrefix & "cmc_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "cmc_docDate"))
          .m_olddocDate = CDate(dr(aliasPrefix & "cmc_docDate"))
        End If
        .m_startcalcdate = CDate(dr(aliasPrefix & "cmc_startcalcDate"))
        .m_endcalcdate = CDate(dr(aliasPrefix & "cmc_endcalcDate"))

        If dr.Table.Columns.Contains("cmc_note") AndAlso Not dr.IsNull(aliasPrefix & "cmc_note") Then
          .m_note = CStr(dr(aliasPrefix & "cmc_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "cmc_status") AndAlso Not dr.IsNull(aliasPrefix & "cmc_status") Then
          .m_status = New CalcMatCostStatus(CInt(dr(aliasPrefix & "cmc_status")))
        End If
        .m_inventorymethod = New InventoryMethod(drh.GetValue(Of Integer)("cmc_matmethod", CInt(Configuration.GetConfig("CompanyInventoryMethod"))))

        m_je = New JournalEntry(Me)
      End With
      Me.m_matbfitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatBF, False)
      Me.m_matbuyitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatBuy, False)
      Me.m_matmoveinitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatMoveIn, False)
      Me.m_matmoveoutitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatMoveOut, False)
      Me.m_matbalitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatBalance, False)

      Me.m_matsumitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.MatSum, False)

      Me.m_wipbfitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPBF, False)
      Me.m_wipoutitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPMoveOut, False)

      Me.m_buyothitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.BuyOth, False)

      Me.m_wipsumitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPSum, False)

      Me.m_wipcannotcostitems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPCannotCost, False)

      Me.m_CostItems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.CostItem, False)
      Me.m_wipbalItems = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPBalance, False)

      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property InvMethod As InventoryMethod
      Get
        Return m_inventorymethod
      End Get
      Set(ByVal value As InventoryMethod)
        m_inventorymethod = value
      End Set
    End Property
    Public Property DocDate() As Date Implements IGLAble.Date, ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        Me.m_je.DocDate = Value      End Set    End Property    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocDate
      End Get
    End Property    Public Property StartCalcDate() As Date      Get        Return m_startcalcdate      End Get      Set(ByVal Value As Date)        m_startcalcdate = Value      End Set    End Property    Public Property EndCalcDate() As Date      Get        Return m_endcalcdate      End Get      Set(ByVal Value As Date)        m_endcalcdate = Value      End Set    End Property    Public numofcalc As Integer
    Public num As Integer
    Public Property PercentWIP As Decimal
      Get
        Return m_percentwip
      End Get
      Set(ByVal value As Decimal)
        m_percentwip = value
      End Set
    End Property    Public Property CostCenter() As CostCenter      Get        Return m_CostCenter      End Get      Set(ByVal Value As CostCenter)        m_CostCenter = Value        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
                   , CommandType.StoredProcedure _
                   , "GetLastCalcCostDate" _
                   , New SqlParameter("@cc", Me.CostCenter.Id) _
                   )        If ds.Tables.Count > 0 Then          Dim drh As New DataRowHelper(ds.Tables(0).Rows(0))
          m_startcalcdate = drh.GetValue(Of Date)("lastdate")
          m_endcalcdate = Date.Now
          Dim i As Integer = drh.GetValue(Of Integer)("num")
          If i = 0 Then
            numofcalc = 0
            num = 1
          Else
            numofcalc = i
            num = i
          End If
        End If      End Set    End Property    Public ReadOnly Property ToAccount() As Account      Get        If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then          Return Me.CostCenter.StoreAccount
        End If      End Get    End Property    Private m_gross As Decimal    Public ReadOnly Property Gross() As Decimal      Get        Return m_gross      End Get    End Property    Public Property Note() As String Implements IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, CalcMatCostStatus)      End Set    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "CalculateCost"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "cmc"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "calcmatcost"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CalculateCost.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.CalcMatCost"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.CalcMatCost"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CalculateCost.ListLabel}"
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
    Public ReadOnly Property MatBFAmount As Decimal
      Get
        Return Me.m_matbfitems.Amount
      End Get
    End Property
    Public ReadOnly Property MatBuyAmount As Decimal
      Get
        Return Me.m_matbuyitems.Amount
      End Get
    End Property
    Public ReadOnly Property MatMoveInAmount As Decimal
      Get
        Return Me.m_matmoveinitems.Amount
      End Get
    End Property
    Public ReadOnly Property MatMoveOutAmount As Decimal
      Get
        Return Me.m_matmoveoutitems.Amount
      End Get
    End Property
    Public ReadOnly Property MatBalAmount As Decimal
      Get
        Return Me.m_matbalitems.Amount
      End Get
    End Property
    Public ReadOnly Property MatSumAmount As Decimal
      Get
        Return Me.m_matsumitems.Amount
      End Get
    End Property
    Public ReadOnly Property WIPBFAmount As Decimal
      Get
        Return Me.m_wipbfitems.Amount
      End Get
    End Property
    Public ReadOnly Property WIPOutAmount As Decimal
      Get
        Return Me.m_wipoutitems.Amount
      End Get
    End Property
    Public ReadOnly Property WIPSumAmount As Decimal
      Get
        Return Me.m_wipsumitems.Amount
      End Get
    End Property
    Public ReadOnly Property BuyOtherAmount As Decimal
      Get
        Return Me.m_buyothitems.Amount
      End Get
    End Property
    Public ReadOnly Property CannotCostAmount As Decimal
      Get
        Return Me.m_wipcannotcostitems.Amount
      End Get
    End Property
    Public ReadOnly Property CostAmount As Decimal
      Get
        Return Me.m_CostItems.Amount
      End Get
    End Property
    Public ReadOnly Property WIPbalAmount As Decimal
      Get
        Return Me.m_wipbalItems.Amount
      End Get
    End Property
    Public ReadOnly Property RealPercentCost As Nullable(Of Decimal)
      Get
        If m_wipsumitems.Amount <= 0 Then
          Return Nothing
        End If
        Return m_CostItems.Amount / m_wipsumitems.Amount * 100
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("CalcMatCost")

      myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_sequence", GetType(Long)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("StockQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Sub CalculateMatForWIPSum()
      If m_inventorymethod.Value = 1 Then '1 periodic
        'เอาไว้ชัวก่อนแล้วคือ ขนาน
        'Parallel.Invoke(Sub()
        '                  m_matbfitems.GetCalculate()
        '                End Sub,
        '                Sub()
        '                  m_matbuyitems.GetCalculate()
        '                End Sub,
        '                Sub()
        '                  m_matmoveinitems.GetCalculate()
        '                End Sub,
        '                  Sub()
        '                    m_matmoveoutitems.GetCalculate()
        '                  End Sub,
        'Sub()
        'm_matbalitems.GetCalculate()
        'End sub,
        '                  Sub()
        'm_matsumitems.GetCalculate()
        '                  End Sub,
        '                  Sub()
        'm_wipbfitems.GetCalculate()
        '                  End Sub,
        '                  Sub()
        'm_wipoutitems.GetCalculate()
        '                  End Sub,
        '                  Sub()
        'm_buyothitems.GetCalculate()
        '                  End Sub,
        '                  Sub()
        'm_wipcannotcostitems.GetCalculate()
        '                  End Sub
        '                    )

        m_matbfitems.GetCalculate()
        m_matbuyitems.GetCalculate()
        m_matmoveinitems.GetCalculate()
        m_matmoveoutitems.GetCalculate()
        m_matbalitems.GetCalculate()
        m_matsumitems.GetCalculate()
        m_wipbfitems.GetCalculate()
        m_wipoutitems.GetCalculate()
        m_buyothitems.GetCalculate()
        m_wipcannotcostitems.GetCalculate()

        CalculateWIPSumItems()

      Else '0 perpetual

        CalculateWIPSumItems()
      End If
    End Sub
    Public Sub CalculateWIPSumItems()
      m_wipsumitems.Clear()
      If Me.InvMethod.Value = 1 Then 'periodic
        'จาก Matsumitems + wipbf - wipout + buyoth 
        m_wipsumitems.AddRange(m_wipbfitems)
        m_wipsumitems.AddRange(m_matsumitems)
        m_wipsumitems.AddRange(m_buyothitems)
        m_wipsumitems.DecreaseRange(m_wipoutitems)
      Else 'perpetual
        'get จาก database ได้ wip ที่เหลืออยู่ตรงๆ 
      End If
    End Sub
    ''' <summary>
    ''' คำนวณ % ของ WIP SUM ทั้งหมด 
    ''' เช่น 70% of wipsum = cost
    ''' 30% = wipbal
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CalculateCostandWIPBal()
      Me.GLIsChanged = True
      Dim maxCost As Decimal = m_wipsumitems.Amount * PercentWIP / 100
      Dim tmpcost As Decimal = 0
      m_CostItems.Clear()
      m_wipbalItems.Clear()

      Dim tmpwip As New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPSum, True)

      m_wipbalItems.AddRange(m_wipcannotcostitems)

      If PercentWIP = 100 Then
        tmpwip.AddRange(m_wipsumitems)
        tmpwip.DecreaseRange(m_wipcannotcostitems)
        m_CostItems.AddRange(tmpwip)
        Return
      ElseIf PercentWIP = 0 Then
        m_wipbalItems.Clear()
        m_wipbalItems.AddRange(m_wipsumitems)
        Return
      End If

      ' WIP เดิมออกก่อน 
      tmpwip = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPBF, True)
      tmpwip.AddRange(m_wipbfitems)
      tmpwip.DecreaseRange(m_wipoutitems)


      For Each wi As CalcMatCostItem In tmpwip
        If tmpcost + wi.Amount <= maxCost Then
          m_CostItems.Add(wi)
          tmpcost += wi.Amount
        ElseIf tmpcost < maxCost AndAlso wi.checkQtyCost(tmpcost, maxCost) Then
          tmpcost += wi.Devideitem(m_CostItems, m_wipbalItems, tmpcost, maxCost)
        Else
          m_wipbalItems.Add(wi)
        End If
      Next

      ' เดิมออกก่อน 
      tmpwip = New CalcMatCostItemCollection(Me, CalcMatItemTypeEnum.WIPSum, True)
      tmpwip.AddRange(m_matsumitems)
      tmpwip.DecreaseRange(m_wipcannotcostitems)
      tmpwip.AddRange(m_buyothitems)
      tmpwip.SortCollection()

      For Each wi As CalcMatCostItem In tmpwip
        If tmpcost + wi.Amount <= maxCost Then
          m_CostItems.Add(wi)
          tmpcost += wi.Amount
        ElseIf tmpcost < maxCost AndAlso wi.checkQtyCost(tmpcost, maxCost) Then
          tmpcost += wi.Devideitem(m_CostItems, m_wipbalItems, tmpcost, maxCost)
        Else
          m_wipbalItems.Add(wi)
        End If
      Next
    End Sub
    Private Sub ResetId(ByVal oldid As Integer, ByVal oldjeid As Integer)
      Me.Id = oldid
      Me.m_je.Id = oldjeid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      'If Not Me.m_je.ManualFormat Then
      '  m_je.SetGLFormat(Me.GetDefaultGLFormat)
      'End If

      Return New SaveErrorException("0")

    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        'If Me.MaxRowIndex < 0 Then
        '  Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        'End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
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
        Me.m_je.DocDate = Me.DocDate
        Me.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_costcenter", ValidIdOrDBNull(Me.CostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_stratcalcdate", ValidDateOrDBNull(Me.StartCalcDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_endcalcdate", ValidDateOrDBNull(Me.EndCalcDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_matmethod", Me.InvMethod.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_matbf", Me.MatBFAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_buy", Me.MatBuyAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_movein", Me.MatMoveInAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_moveout", Me.MatMoveOutAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_matbal", Me.MatBalAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wipbf", Me.WIPBFAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wipout", Me.WIPOutAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wipbal", Me.WIPbalAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cost", Me.CostAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_percentwip", Me.PercentWIP))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))


        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
        Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
        If Not IsNumeric(ValidateError2.Message) Then
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return ValidateError2
        End If
        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()

     

        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Dim oldjeid As Integer = Me.m_je.Id
        Try



          Try
            Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2
                  trans.Rollback()
                  Me.ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              Me.ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If

         

            Dim saveinputDetailError As SaveErrorException = SaveInputDetail(Me.Id, conn, trans)
            If Not IsNumeric(saveinputDetailError.Message) Then
              trans.Rollback()
              Me.ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveinputDetailError
            Else
              Select Case CInt(saveinputDetailError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveinputDetailError
                Case Else
              End Select
            End If

            Dim saveoutputDetailError As SaveErrorException = SaveOutPutDetail(Me.Id, conn, trans)
            If Not IsNumeric(saveoutputDetailError.Message) Then
              trans.Rollback()
              Me.ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveinputDetailError
            Else
              Select Case CInt(saveoutputDetailError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveinputDetailError
                Case Else
              End Select
            End If

            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            End If
            Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveJeError.Message) Then
              trans.Rollback()
              Me.ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveJeError
            Else
              Select Case CInt(saveJeError.Message)
                Case -1
                  trans.Rollback()
                  Me.ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
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
              ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================

            trans.Commit()
          Catch ex As SqlException
            trans.Rollback()
            Me.ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          End Try

          'Sub Save Block

          '--Sub Save Block-- ============================================================
          Try
            Dim subsaveerror3 As SaveErrorException = SubSaveJeAtom(conn)
            If Not IsNumeric(subsaveerror3.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
            Return New SaveErrorException(returnVal.Value.ToString)
            'Complete Save
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try
          'Sub Save Block

        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      ''==============================STOCKCOST=========================================
      ''ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut) 
      'If Not Me.IsReferenced Then
      '  Dim transCost As SqlTransaction = conn.BeginTransaction
      '  Try

      '    'InsertStockiCostFirstFIFO ใช้สำหรับเอกสารตั้งต้น Cost จะได้ลดภาระ database
      '    SqlHelper.ExecuteNonQuery(conn, transCost, CommandType.StoredProcedure, "InsertStockiCostFirstFIFO", New SqlParameter("@stock_id", Me.Id))
      '  Catch ex As Exception
      '    transCost.Rollback()
      '    Return New SaveErrorException(ex.InnerException.ToString)
      '  End Try
      '  transCost.Commit()
      'End If
      ''==============================STOCKCOST=========================================


      Return New SaveErrorException("0")
    End Function
    Private Function SaveInputDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim unitCost As Decimal = 0
        Dim Cost As Decimal = 0

        Dim da As New SqlDataAdapter("Select * from calcmatinputitem where cmcini_cmc=" & Me.Id, conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From calcmatinputitem Where cmcini_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "calcmatinputitem")
        da.Fill(ds, "calcmatinputitem")



        Dim dt As DataTable = ds.Tables("calcmatinputitem")


        For Each row As DataRow In ds.Tables("calcmatinputitem").Rows
          row.Delete()
        Next



        For Each item As CalcMatCostItem In Me.m_matbfitems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcini_cmc") = Me.Id
          dr("cmcini_stockisequence") = item.StockiSequence
          dr("cmcini_stockicsequence") = item.stockicostSequence
          dr("cmcini_unitcost") = item.UnitCost
          dr("cmcini_stockqty") = item.StockQty
          dr("cmcini_entity") = item.Entity.Id
          dr("cmcini_entitytype") = item.EntityType
          dr("cmcini_name") = item.Entity.Name
          dr("cmcini_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcini_ga") = item.ga.Id
          End If
          dr("cmcini_sort") = item.Sort
          dr("cmcini_refid") = item.RefDoc
          dr("cmcini_reftype") = item.RefType
          dr("cmcini_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next

        For Each item As CalcMatCostItem In Me.m_matbuyitems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcini_cmc") = Me.Id
          dr("cmcini_stockisequence") = item.StockiSequence
          dr("cmcini_stockicsequence") = item.stockicostSequence
          dr("cmcini_unitcost") = item.UnitCost
          dr("cmcini_stockqty") = item.StockQty
          dr("cmcini_entity") = item.Entity.Id
          dr("cmcini_entitytype") = item.EntityType
          dr("cmcini_name") = item.Entity.Name
          dr("cmcini_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcini_ga") = item.ga.Id
          End If
          dr("cmcini_sort") = item.Sort
          dr("cmcini_refid") = item.RefDoc
          dr("cmcini_reftype") = item.RefType
          dr("cmcini_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next

        For Each item As CalcMatCostItem In Me.m_matmoveinitems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcini_cmc") = Me.Id
          dr("cmcini_stockisequence") = item.StockiSequence
          dr("cmcini_stockicsequence") = item.stockicostSequence
          dr("cmcini_unitcost") = item.UnitCost
          dr("cmcini_stockqty") = item.StockQty
          dr("cmcini_entity") = item.Entity.Id
          dr("cmcini_entitytype") = item.EntityType
          dr("cmcini_name") = item.Entity.Name
          dr("cmcini_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcini_ga") = item.ga.Id
          End If
          dr("cmcini_sort") = item.Sort
          dr("cmcini_refid") = item.RefDoc
          dr("cmcini_reftype") = item.RefType
          dr("cmcini_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next

        For Each item As CalcMatCostItem In Me.m_matmoveoutitems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcini_cmc") = Me.Id
          dr("cmcini_stockisequence") = item.StockiSequence
          dr("cmcini_stockicsequence") = item.stockicostSequence
          dr("cmcini_unitcost") = item.UnitCost
          dr("cmcini_stockqty") = item.StockQty
          dr("cmcini_entity") = item.Entity.Id
          dr("cmcini_entitytype") = item.EntityType
          dr("cmcini_name") = item.Entity.Name
          dr("cmcini_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcini_ga") = item.ga.Id
          End If
          dr("cmcini_sort") = item.Sort
          dr("cmcini_refid") = item.RefDoc
          dr("cmcini_reftype") = item.RefType
          dr("cmcini_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next

        For Each item As CalcMatCostItem In Me.m_matsumitems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcini_cmc") = Me.Id
          dr("cmcini_stockisequence") = item.StockiSequence
          dr("cmcini_stockicsequence") = item.stockicostSequence
          dr("cmcini_unitcost") = item.UnitCost
          dr("cmcini_stockqty") = item.StockQty
          dr("cmcini_entity") = item.Entity.Id
          dr("cmcini_entitytype") = item.EntityType
          dr("cmcini_name") = item.Entity.Name
          dr("cmcini_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcini_ga") = item.ga.Id
          End If
          dr("cmcini_sort") = item.Sort
          dr("cmcini_refid") = item.RefDoc
          dr("cmcini_reftype") = item.RefType
          dr("cmcini_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next


        For Each item As CalcMatCostItem In Me.m_wipbfitems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcini_cmc") = Me.Id
          dr("cmcini_stockisequence") = item.StockiSequence
          dr("cmcini_stockicsequence") = item.stockicostSequence
          dr("cmcini_unitcost") = item.UnitCost
          dr("cmcini_stockqty") = item.StockQty
          dr("cmcini_entity") = item.Entity.Id
          dr("cmcini_entitytype") = item.EntityType
          dr("cmcini_name") = item.Entity.Name
          dr("cmcini_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcini_ga") = item.ga.Id
          End If
          dr("cmcini_sort") = item.Sort
          dr("cmcini_refid") = item.RefDoc
          dr("cmcini_reftype") = item.RefType
          dr("cmcini_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next

        For Each item As CalcMatCostItem In Me.m_wipoutitems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcini_cmc") = Me.Id
          dr("cmcini_stockisequence") = item.StockiSequence
          dr("cmcini_stockicsequence") = item.stockicostSequence
          dr("cmcini_unitcost") = item.UnitCost
          dr("cmcini_stockqty") = item.StockQty
          dr("cmcini_entity") = item.Entity.Id
          dr("cmcini_entitytype") = item.EntityType
          dr("cmcini_name") = item.Entity.Name
          dr("cmcini_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcini_ga") = item.ga.Id
          End If
          dr("cmcini_sort") = item.Sort
          dr("cmcini_refid") = item.RefDoc
          dr("cmcini_reftype") = item.RefType
          dr("cmcini_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated

        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        ds.EnforceConstraints = True
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function

    Private Function SaveOutPutDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim unitCost As Decimal = 0
        Dim Cost As Decimal = 0

        Dim da As New SqlDataAdapter("Select * from calcmatoutputitem where cmcoi_cmc=" & Me.Id, conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From calcmatoutputitem Where cmcoi_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "calcmatoutputitem")
        da.Fill(ds, "calcmatoutputitem")



        Dim dt As DataTable = ds.Tables("calcmatoutputitem")


        For Each row As DataRow In ds.Tables("calcmatoutputitem").Rows
          row.Delete()
        Next



        For Each item As CalcMatCostItem In Me.m_matbalitems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcoi_cmc") = Me.Id
          dr("cmcoi_stockisequence") = item.StockiSequence
          dr("cmcoi_stockicsequence") = item.stockicostSequence
          dr("cmcoi_unitcost") = item.UnitCost
          dr("cmcoi_stockqty") = item.StockQty
          dr("cmcoi_entity") = item.Entity.Id
          dr("cmcoi_entitytype") = item.EntityType
          dr("cmcoi_name") = item.Entity.Name
          dr("cmcoi_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcoi_ga") = item.ga.Id
          End If
          dr("cmcoi_sort") = item.Sort
          dr("cmcoi_refid") = item.RefDoc
          dr("cmcoi_reftype") = item.RefType
          dr("cmcoi_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next

        For Each item As CalcMatCostItem In Me.m_wipbalItems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcoi_cmc") = Me.Id
          dr("cmcoi_stockisequence") = item.StockiSequence
          dr("cmcoi_stockicsequence") = item.stockicostSequence
          dr("cmcoi_unitcost") = item.UnitCost
          dr("cmcoi_stockqty") = item.StockQty
          dr("cmcoi_entity") = item.Entity.Id
          dr("cmcoi_entitytype") = item.EntityType
          dr("cmcoi_name") = item.Entity.Name
          dr("cmcoi_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcoi_ga") = item.ga.Id
          End If
          dr("cmcoi_sort") = item.Sort
          dr("cmcoi_refid") = item.RefDoc
          dr("cmcoi_reftype") = item.RefType
          dr("cmcoi_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next

        For Each item As CalcMatCostItem In Me.m_CostItems

          Dim dr As DataRow

          dr = dt.NewRow

          dr("cmcoi_cmc") = Me.Id
          dr("cmcoi_stockisequence") = item.StockiSequence
          dr("cmcoi_stockicsequence") = item.stockicostSequence
          dr("cmcoi_unitcost") = item.UnitCost
          dr("cmcoi_stockqty") = item.StockQty
          dr("cmcoi_entity") = item.Entity.Id
          dr("cmcoi_entitytype") = item.EntityType
          dr("cmcoi_name") = item.Entity.Name
          dr("cmcoi_itemtype") = item.CalcMatType
          If Not item.ga Is Nothing Then
            dr("cmcoi_ga") = item.ga.Id
          End If
          dr("cmcoi_sort") = item.Sort
          dr("cmcoi_refid") = item.RefDoc
          dr("cmcoi_reftype") = item.RefType
          dr("cmcoi_reftypedesc") = item.RefTypeDesc
          dt.Rows.Add(dr)
        Next

        

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated

        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        ds.EnforceConstraints = True
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Function GetDeletedRows(ByVal dt As DataTable) As DataRow()
      Dim Rows() As DataRow
      If dt Is Nothing Then Return Rows
      Rows = dt.Select("", "", DataViewRowState.Deleted)
      If Rows.Length = 0 OrElse Not (Rows(0) Is Nothing) Then Return Rows
      '
      ' Workaround:
      ' With a remoted DataSet, Select returns the array elements
      ' filled with Nothing/null, instead of DataRow objects.
      '
      Dim r As DataRow, I As Integer = 0
      For Each r In dt.Rows
        If r.RowState = DataRowState.Deleted Then
          Rows(I) = r
          I += 1
        End If
      Next
      Return Rows
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
      , New SqlParameter("@entity_name", Me.ClassName), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        Me.m_je = Value
      End Set
    End Property
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection

      Dim ji As New JournalEntryItem

      'k1 ต้นทุนก่อสร้าง
      For Each ci As CalcMatCostItem In m_CostItems
        ji = New JournalEntryItem
        ji.Mapping = "K1D"
        ji.Amount = Configuration.Format(ci.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " ต้นทุน" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(ci.Sequence)
        ji.EntityItemType = ci.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "outputitem"
        ji.CustomRefstr = ""
        ji.CustomRefType = ""
        ji.AtomNote = "Costitem" & ci.RefTypeDesc
        jiColl.Add(ji)
      Next

      ji = New JournalEntryItem
      ji.Mapping = "K1"
      ji.Amount = Configuration.Format(CostAmount, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " ต้นทุน" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "Costitem"
      jiColl.Add(ji)


      'K2	WIP งานระหว่างทำ ยกไป

      For Each wi As CalcMatCostItem In m_wipbalItems
        ji = New JournalEntryItem
        ji.Mapping = "K2D"
        ji.Amount = Configuration.Format(wi.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " งานระหว่างทำยกไป" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(wi.Sequence)
        ji.EntityItemType = wi.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "outputitem"
        ji.CustomRefstr = ""
        ji.CustomRefType = ""
        ji.AtomNote = "WIPBAL" & wi.RefTypeDesc
        jiColl.Add(ji)
      Next

      ji = New JournalEntryItem
      ji.Mapping = "K2"
      ji.Amount = Configuration.Format(WIPbalAmount, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " งานระหว่างทำยกไป" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "WIPBAL"
      jiColl.Add(ji)

      'K3(วัสดุคงเหลือ)

      For Each mi As CalcMatCostItem In m_matbalitems
        ji = New JournalEntryItem
        ji.Mapping = "K3D"
        ji.Amount = Configuration.Format(mi.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " วัสดุคงเหลือยกไป" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(mi.Sequence)
        ji.EntityItemType = mi.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "outputitem"
        ji.CustomRefstr = ""
        ji.CustomRefType = ""
        ji.AtomNote = "MatBAL" & mi.RefTypeDesc
        jiColl.Add(ji)
      Next

      ji = New JournalEntryItem
      ji.Mapping = "K3"
      ji.Amount = Configuration.Format(MatBalAmount, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " วัสดุคงเหลือยกไป" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "MatBAL"
      jiColl.Add(ji)


      'K4	WIP ยกมา
      For Each item As CalcMatCostItem In m_wipbfitems
        ji = New JournalEntryItem
        ji.Mapping = "K4D"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " งานระหว่างทำยกมา" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = ""
        ji.CustomRefType = ""
        ji.AtomNote = "WIPBF" & item.RefTypeDesc
        jiColl.Add(ji)
      Next

      ji = New JournalEntryItem
      ji.Mapping = "K4"
      ji.Amount = Configuration.Format(WIPBFAmount, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " งานระหว่างทำยกมา" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "WIPBF"
      jiColl.Add(ji)


      'K5(วัสดุคงเหลือยกมา)
      For Each item As CalcMatCostItem In m_matbfitems
        ji = New JournalEntryItem
        ji.Mapping = "K5D"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " วัสดุยกมา" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = ""
        ji.CustomRefType = ""
        ji.AtomNote = "MatBF" & item.RefTypeDesc
        jiColl.Add(ji)
      Next

      ji = New JournalEntryItem
      ji.Mapping = "K5"
      ji.Amount = Configuration.Format(MatBFAmount, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " วัสดุยกมา" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "MatBF"
      jiColl.Add(ji)


      ''K6(ซื้อวัสดุก่อสร้าง)
     

      For Each item As CalcMatCostItem In m_matbuyitems
        ji = New JournalEntryItem
        ji.Mapping = "K6D"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " ซื้อวัสดุ" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = ""
        ji.CustomRefType = ""
        ji.AtomNote = "BuyLci" & item.RefTypeDesc
        jiColl.Add(ji)

      Next

      ji = New JournalEntryItem
      ji.Mapping = "K6"
      ji.Amount = Configuration.Format(MatBuyAmount, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " ซื้อวัสดุ" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "BuyLci"
      jiColl.Add(ji)

      'K12(โอนวัสดุรับ)

      For Each item As CalcMatCostItem In m_matmoveinitems
        ji = New JournalEntryItem
        ji.Mapping = "K12D"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " MatMovein" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = ""
        ji.CustomRefType = ""
        ji.AtomNote = "MoveIn" & item.RefTypeDesc
        jiColl.Add(ji)
      Next

      ji = New JournalEntryItem
      ji.Mapping = "K12"
      ji.Amount = Configuration.Format(MatMoveInAmount, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " MatMovein" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "MoveIn"
      jiColl.Add(ji)

      'K13(โอนวัสดุจ่าย)

      For Each item As CalcMatCostItem In m_matmoveinitems
        ji = New JournalEntryItem
        ji.Mapping = "K13D"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " MatMoveOut" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = ""
        ji.CustomRefType = ""
        ji.AtomNote = "MoveIn" & item.RefTypeDesc
        jiColl.Add(ji)
      Next

      ji = New JournalEntryItem
      ji.Mapping = "K13"
      ji.Amount = Configuration.Format(MatMoveOutAmount, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " MatMoveOut" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "MatMoveOut"
      jiColl.Add(ji)

      'K7(เครื่องมือ / วัสดุสิ้นเปลือง)
      Dim tmpamt As Decimal = 0

      For Each item As CalcMatCostItem In m_buyothitems
        If item.EntityType = 19 AndAlso item.RefType <> 292 Then
          ji = New JournalEntryItem
          ji.Mapping = "K7D"
          ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
          ji.CostCenter = Me.CostCenter
          ji.Note = Me.CostCenter.Name & " ซื้อเครื่องมือ / วัสดุสิ้นเปลือง" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
          ji.EntityItem = CInt(item.Sequence)
          ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
          ji.table = Me.TableName & "inputitem"
          ji.CustomRefstr = ""
          ji.CustomRefType = ""
          ji.AtomNote = "BuyOther" & item.RefTypeDesc
          jiColl.Add(ji)

          tmpamt += item.Amount
        End If

      Next

      ji = New JournalEntryItem
      ji.Mapping = "K7"
      ji.Amount = Configuration.Format(tmpamt, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " ซื้อเครื่องมือ / วัสดุสิ้นเปลือง" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "BuyOther"
      jiColl.Add(ji)
      tmpamt = 0

      'K8(ค่าใช้จ่ายอื่นๆ(ซื้อสินค้า))

      For Each item As CalcMatCostItem In m_buyothitems
        If (item.EntityType = 44 OrElse item.EntityType = 29) AndAlso item.RefType <> 292 Then
            ji = New JournalEntryItem
            ji.Mapping = "K8D"
            ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
            ji.CostCenter = Me.CostCenter
            ji.Note = Me.CostCenter.Name & " ค่าใช้จ่ายอื่นๆ(ซื้อสินค้า)" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
            ji.EntityItem = CInt(item.Sequence)
            ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
            ji.table = Me.TableName & "inputitem"
            ji.CustomRefstr = ""
            ji.CustomRefType = ""
            ji.AtomNote = "BuyOther" & item.RefTypeDesc
            jiColl.Add(ji)

            tmpamt += item.Amount
          End If

      Next

      ji = New JournalEntryItem
      ji.Mapping = "K8"
      ji.Amount = Configuration.Format(tmpamt, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " ค่าใช้จ่ายอื่นๆ(ซื้อสินค้า)" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "BuyOther"
      jiColl.Add(ji)
      tmpamt = 0

      'K9(ค่าเช่าเครื่องจักร)

      For Each item As CalcMatCostItem In m_buyothitems
        If item.EntityType = 28 AndAlso item.RefType <> 292 Then
          ji = New JournalEntryItem
          ji.Mapping = "K9D"
          ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
          ji.CostCenter = Me.CostCenter
          ji.Note = Me.CostCenter.Name & " ค่าเช่าเครื่องจักร" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
          ji.EntityItem = CInt(item.Sequence)
          ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
          ji.table = Me.TableName & "inputitem"
          ji.CustomRefstr = ""
          ji.CustomRefType = ""
          ji.AtomNote = "BuyOther" & item.RefTypeDesc
          jiColl.Add(ji)

          tmpamt += item.Amount
        End If

      Next

      ji = New JournalEntryItem
      ji.Mapping = "K9"
      ji.Amount = Configuration.Format(tmpamt, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " ค่าเช่าเครื่องจักร" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "BuyOther"
      jiColl.Add(ji)
      tmpamt = 0

      'K10(ค่าจ้างเหมา)

      For Each item As CalcMatCostItem In m_buyothitems
        If item.RefType = 292 Then
          ji = New JournalEntryItem
          ji.Mapping = "K10D"
          ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
          ji.CostCenter = Me.CostCenter
          ji.Note = Me.CostCenter.Name & " ค่าจ้างเหมา" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
          ji.EntityItem = CInt(item.Sequence)
          ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
          ji.table = Me.TableName & "inputitem"
          ji.CustomRefstr = ""
          ji.CustomRefType = ""
          ji.AtomNote = "SC" & item.RefTypeDesc
          jiColl.Add(ji)

          tmpamt += item.Amount
        End If

      Next

      ji = New JournalEntryItem
      ji.Mapping = "K10"
      ji.Amount = Configuration.Format(tmpamt, DigitConfig.Price)
      ji.CostCenter = Me.CostCenter
      ji.Note = Me.CostCenter.Name & " ค่าจ้างเหมา" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
      ji.AtomNote = "SC"
      jiColl.Add(ji)
      tmpamt = 0

      'K11(ค่าปรับผู้รับเหมาช่วง)

     

      Return jiColl
    End Function
#End Region

#Region "INewGLAble"
    Public Function OnlyGenGlAtom() As SaveErrorException Implements INewGLAble.OnlyGenGLAtom
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      SubSaveJeAtom(conn)
      conn.Close()
    End Function
    Private Function SubSaveJeAtom(ByVal conn As SqlConnection) As SaveErrorException Implements INewGLAble.SubSaveJeAtom
      Me.JournalEntry.RefreshOnlyGLAtom()
      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        Me.JournalEntry.SaveAutoMateDetail(Me.JournalEntry.Id, conn, trans)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try
      trans.Commit()
      Return New SaveErrorException("0")
    End Function
    Public Function NewGetJournalEntries() As JournalEntryItemCollection Implements INewGLAble.NewGetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      jiColl.AddRange(Me.NewGetItemJournalEntries)
      Return jiColl
    End Function
    Private Function NewGetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      Dim ji As New JournalEntryItem

      'k1 ต้นทุนก่อสร้าง
      For Each item As CalcMatCostItem In m_CostItems
        ji = New JournalEntryItem
        ji.Mapping = "K1"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " ต้นทุน" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "outputitem"
        ji.CustomRefstr = item.RefDoc.ToString
        ji.CustomRefType = item.RefType.ToString
        ji.AtomNote = "Costitem" & item.RefTypeDesc
        jiColl.Add(ji)
      Next




      'K2	WIP งานระหว่างทำ ยกไป

      For Each item As CalcMatCostItem In m_wipbalItems
        ji = New JournalEntryItem
        ji.Mapping = "K2"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " งานระหว่างทำยกไป" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "outputitem"
        ji.CustomRefstr = item.RefDoc.ToString
        ji.CustomRefType = item.RefType.ToString
        ji.AtomNote = "WIPBAL" & item.RefTypeDesc
        jiColl.Add(ji)
      Next



      'K3(วัสดุคงเหลือ)
      For Each item As CalcMatCostItem In m_matbalitems
        ji = New JournalEntryItem
        ji.Mapping = "K3"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " วัสดุคงเหลือยกไป" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "outputitem"
        ji.CustomRefstr = item.RefDoc.ToString
        ji.CustomRefType = item.RefType.ToString
        ji.AtomNote = "MatBAL" & item.RefTypeDesc
        jiColl.Add(ji)
      Next




      'K4	WIP ยกมา
      For Each item As CalcMatCostItem In m_wipbfitems
        ji = New JournalEntryItem
        ji.Mapping = "K4"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " งานระหว่างทำยกมา" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = item.RefDoc.ToString
        ji.CustomRefType = item.RefType.ToString
        ji.AtomNote = "WIPBF" & item.RefTypeDesc
        jiColl.Add(ji)
      Next



      'K5(วัสดุคงเหลือยกมา)
      For Each item As CalcMatCostItem In m_matbfitems
        ji = New JournalEntryItem
        ji.Mapping = "K5"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " วัสดุยกมา" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = item.RefDoc.ToString
        ji.CustomRefType = item.RefType.ToString
        ji.AtomNote = "MatBF" & item.RefTypeDesc
        jiColl.Add(ji)
      Next



      'K6(ซื้อวัสดุก่อสร้าง)

      For Each item As CalcMatCostItem In m_matbuyitems
        ji = New JournalEntryItem
        ji.Mapping = "K6"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " ซื้อวัสดุ" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = item.RefDoc.ToString
        ji.CustomRefType = item.RefType.ToString
        ji.AtomNote = "BuyLci" & item.RefTypeDesc
        jiColl.Add(ji)
      Next


      'K7(เครื่องมือ / วัสดุสิ้นเปลือง)

      For Each item As CalcMatCostItem In m_buyothitems
        If item.EntityType = 19 AndAlso item.RefType <> 292 Then
          ji = New JournalEntryItem
          ji.Mapping = "K7"
          ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
          ji.CostCenter = Me.CostCenter
          ji.Note = Me.CostCenter.Name & " ซื้อเครื่องมือ / วัสดุสิ้นเปลือง" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
          ji.EntityItem = CInt(item.Sequence)
          ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
          ji.table = Me.TableName & "inputitem"
          ji.CustomRefstr = item.RefDoc.ToString
          ji.CustomRefType = item.RefType.ToString
          ji.AtomNote = "BuyOther" & item.RefTypeDesc
          jiColl.Add(ji)

        End If

      Next

    

      'K8(ค่าใช้จ่ายอื่นๆ(ซื้อสินค้า))

      For Each item As CalcMatCostItem In m_buyothitems
        If (item.EntityType = 44 OrElse item.EntityType = 29) AndAlso item.RefType <> 292 Then
          ji = New JournalEntryItem
          ji.Mapping = "K8"
          ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
          ji.CostCenter = Me.CostCenter
          ji.Note = Me.CostCenter.Name & " ค่าใช้จ่ายอื่นๆ(ซื้อสินค้า)" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
          ji.EntityItem = CInt(item.Sequence)
          ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
          ji.table = Me.TableName & "inputitem"
          ji.CustomRefstr = item.RefDoc.ToString
          ji.CustomRefType = item.RefType.ToString
          ji.AtomNote = "BuyOther" & item.RefTypeDesc
          jiColl.Add(ji)

        End If

      Next

     

      'K9(ค่าเช่าเครื่องจักร)

      For Each item As CalcMatCostItem In m_buyothitems
        If item.EntityType = 28 AndAlso item.RefType <> 292 Then
          ji = New JournalEntryItem
          ji.Mapping = "K9"
          ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
          ji.CostCenter = Me.CostCenter
          ji.Note = Me.CostCenter.Name & " ค่าเช่าเครื่องจักร" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
          ji.EntityItem = CInt(item.Sequence)
          ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
          ji.table = Me.TableName & "inputitem"
          ji.CustomRefstr = item.RefDoc.ToString
          ji.CustomRefType = item.RefType.ToString
          ji.AtomNote = "BuyOther" & item.RefTypeDesc
          jiColl.Add(ji)

        End If

      Next

  

      'K10(ค่าจ้างเหมา)

      For Each item As CalcMatCostItem In m_buyothitems
        If item.RefType = 292 Then
          ji = New JournalEntryItem
          ji.Mapping = "K10"
          ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
          ji.CostCenter = Me.CostCenter
          ji.Note = Me.CostCenter.Name & " ค่าจ้างเหมา" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
          ji.EntityItem = CInt(item.Sequence)
          ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
          ji.table = Me.TableName & "inputitem"
          ji.CustomRefstr = item.RefDoc.ToString
          ji.CustomRefType = item.RefType.ToString
          ji.AtomNote = "SC" & item.RefTypeDesc
          jiColl.Add(ji)

        End If

      Next

     

      'K11(ค่าปรับผู้รับเหมาช่วง)

      'K12(โอนวัสดุรับ)

      For Each item As CalcMatCostItem In m_matmoveinitems
        ji = New JournalEntryItem
        ji.Mapping = "K12"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " MatMovein" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = item.RefDoc.ToString
        ji.CustomRefType = item.RefType.ToString
        ji.AtomNote = "MoveIn" & item.RefTypeDesc
        jiColl.Add(ji)
      Next

   

      'K13(โอนวัสดุจ่าย)

      For Each item As CalcMatCostItem In m_matmoveinitems
        ji = New JournalEntryItem
        ji.Mapping = "K13"
        ji.Amount = Configuration.Format(item.Amount, DigitConfig.Price)
        ji.CostCenter = Me.CostCenter
        ji.Note = Me.CostCenter.Name & " MatMoveOut" & Me.StartCalcDate.ToShortDateString & "ถึง" & Me.EndCalcDate.ToShortDateString
        ji.EntityItem = CInt(item.Sequence)
        ji.EntityItemType = item.EntityType 'ใช้ Incomingvat 
        ji.table = Me.TableName & "inputitem"
        ji.CustomRefstr = item.RefDoc.ToString
        ji.CustomRefType = item.RefType.ToString
        ji.AtomNote = "MoveIn" & item.RefTypeDesc
        jiColl.Add(ji)
      Next

      Return jiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return True
        Else
          Return False
        End If
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteCalcMatCost}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteCalcMatCost", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.CalcMatCostIsReferencedCannotBeDeleted}")
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


#Region "IPrintableEntity"

    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\MOB.dfm"
    End Function

    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

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

      If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then
        'ToCCInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim n As Integer = 0


      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function


#End Region

    

  End Class


End Namespace
