Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class LCIForList
    Inherits SimpleBusinessEntityBase

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal code As String, ByVal ParamArray filters() As Filter)
      MyBase.New(code, filters)
    End Sub
    Public Sub New(ByVal id As Integer, ByVal ParamArray filters() As Filter)
      MyBase.New(id, filters)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      Dim deh As New DataRowHelper(dr)
    End Sub
#End Region
#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "LCIForList"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.LCIForList.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.LCIItem"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.LCIItem"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.LCIForList.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "lci"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "GetLCIItem"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

  End Class
  Public Class LCIItem
    Inherits TreeBaseEntity
    Implements IHasImage, IPJMUpdatable, IHasAccount, IHasUnit, IHasPrice, IHasNote

#Region "Members"
    Private lci_lv1 As String
    Private lci_lv2 As String
    Private lci_lv3 As String
    Private lci_lv4 As String
    Private lci_lv5 As String

    Private m_wbscode As String
    Private m_account As Account
    Private m_fairPrice As Decimal
    Private m_movingCost As Decimal
    Private m_shelfLife As Integer
    Private m_note As String
    Private m_defaultUnit As Unit
    Private m_CompareUnit1 As Unit
    Private m_CompareUnit2 As Unit
    Private m_CompareUnit3 As Unit
    Private m_conversionUnit1 As Decimal
    Private m_conversionUnit2 As Decimal
    Private m_conversionUnit3 As Decimal
    Private m_image As Image
    Private m_pjmid As Integer

    Private m_LCISupplierCostLink As LCISupplierCostLink

    Private m_LCILaborCostLink As LCILaborCostLink

    Private m_LCIEquipmentCostLink As LCIEquipmentCostLink

    Private m_unvatable As Boolean

    Private m_customerCode As String
    Private m_monthperiod As Integer

    Private Shared m_AllLciitems As Hashtable
    Public Shared ReadOnly Property AllLciitems As Hashtable
      Get
        If m_AllLciitems Is Nothing Then
          RefreshAllData()
        End If
        Return m_AllLciitems
      End Get
    End Property
    Private Shared m_LciitemTable As DataTable
    Public Shared ReadOnly Property LciitemTable As DataTable
      Get
        If m_LciitemTable Is Nothing Then
          RefreshData()
        End If
        Return m_LciitemTable
      End Get
    End Property

#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal myParent As LCIItem)
      MyBase.New(myParent)
      Me.lci_lv1 = myParent.Lv1
      Select Case myParent.Level
        Case 1
          Me.lci_lv2 = ""
          Me.lci_lv3 = "00"
          Me.lci_lv4 = ""
        Case 2
          Me.lci_lv2 = myParent.Lv2
          Me.lci_lv3 = ""
          Me.lci_lv4 = ""
        Case 3
          Me.lci_lv2 = myParent.Lv2
          Me.lci_lv3 = myParent.Lv3
          Me.lci_lv4 = ""
        Case 4
          Me.lci_lv2 = myParent.Lv2
          Me.lci_lv3 = myParent.Lv3
          Me.lci_lv4 = myParent.Lv4
      End Select
      Me.Level = myParent.Level + 1
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      'MessageBox.Show("Construct:LCI:" & Me.Id.ToString)
      Me.m_account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.MatInStore).Account
      Me.m_defaultUnit = New Unit
      Me.m_CompareUnit1 = New Unit
      Me.m_CompareUnit2 = New Unit
      Me.m_CompareUnit3 = New Unit
      Me.m_unvatable = False
      LoadCostLink()
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        Dim drh As New DataRowHelper(dr)

        '================================
        Dim key As String = Me.Id.ToString
        Me.AllLciitems(key) = dr
        '================================

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_code") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_code") Then
          m_code = CStr(dr(aliasPrefix & Me.Prefix & "_code"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_lv1") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_lv1") Then
          .lci_lv1 = CStr(dr(aliasPrefix & Prefix & "_lv1"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_lv2") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_lv2") Then
          .lci_lv2 = CStr(dr(aliasPrefix & Prefix & "_lv2"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_lv3") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_lv3") Then
          .lci_lv3 = CStr(dr(aliasPrefix & Prefix & "_lv3"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_lv4") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_lv4") Then
          .lci_lv4 = CStr(dr(aliasPrefix & Prefix & "_lv4"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_lv5") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_lv5") Then
          .lci_lv5 = CStr(dr(aliasPrefix & Prefix & "_lv5"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_customerCode") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_customerCode") Then
          .m_customerCode = CStr(dr(aliasPrefix & Prefix & "_customerCode"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_wbsCode") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_wbsCode") Then
          .m_wbscode = CStr(dr(aliasPrefix & Prefix & "_wbsCode"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") Then
          If Not dr.IsNull(aliasPrefix & "acct_id") Then
            .m_account = New Account(dr, aliasPrefix)
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_acct") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_acct") Then
            .m_account = New Account(CInt(dr(aliasPrefix & Me.Prefix & "_acct")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unvatable") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unvatable") Then
          .m_unvatable = CBool(dr(aliasPrefix & Me.Prefix & "_unvatable"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fairPrice") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fairPrice") Then
          .m_fairPrice = CDec(dr(aliasPrefix & Me.Prefix & "_fairPrice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_movingcost") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_movingcost") Then
          .m_movingCost = CDec(dr(aliasPrefix & Me.Prefix & "_movingcost"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_pjmid") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_pjmid") Then
          .m_pjmid = CInt(dr(aliasPrefix & Me.Prefix & "_pjmid"))
        End If

        ' กำหนดค่าของหน่วยนับ LCIitem
        Dim defaultUnitId As Nullable(Of Integer) = drh.GetValue(Of Integer)("lci_defaultUnit")
        Dim compareUnitId1 As Nullable(Of Integer) = drh.GetValue(Of Integer)("lci_compareUnit1")
        Dim compareUnitId2 As Nullable(Of Integer) = drh.GetValue(Of Integer)("lci_compareUnit2")
        Dim compareUnitId3 As Nullable(Of Integer) = drh.GetValue(Of Integer)("lci_compareUnit3")
        If defaultUnitId.HasValue AndAlso defaultUnitId.Value > 0 Then
          .m_defaultUnit = Unit.GetUnitById(defaultUnitId.Value)
        End If
        If compareUnitId1.HasValue AndAlso compareUnitId1.Value > 0 Then
          .m_CompareUnit1 = Unit.GetUnitById(compareUnitId1.Value)
        End If
        If compareUnitId2.HasValue AndAlso compareUnitId2.Value > 0 Then
          .m_CompareUnit2 = Unit.GetUnitById(compareUnitId2.Value)
        End If
        If compareUnitId3.HasValue AndAlso compareUnitId3.Value > 0 Then
          .m_CompareUnit3 = Unit.GetUnitById(compareUnitId3.Value)
        End If

        'If dr.Table.Columns.Contains(aliasPrefix & "unit_id") Then
        '  If Not dr.IsNull(aliasPrefix & "unit_id") Then
        '    .m_defaultUnit = New Unit(dr, aliasPrefix)
        '  End If
        'Else
        '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_defaultUnit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_defaultUnit") Then
        '    .m_defaultUnit = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_defaultUnit")))
        '  End If
        'End If

        'If dr.Table.Columns.Contains(aliasPrefix & "compareUnit1.unit_id") Then
        '  If Not dr.IsNull(aliasPrefix & "compareUnit1.unit_id") Then
        '    .m_CompareUnit1 = New Unit(dr, aliasPrefix & "compareUnit1.")
        '  End If
        'Else
        '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_compareUnit1") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_compareUnit1") Then
        '    .m_CompareUnit1 = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_compareUnit1")))
        '  End If
        'End If

        'If dr.Table.Columns.Contains("compareUnit2.unit_id") Then
        '  If Not dr.IsNull("compareUnit2.unit_id") Then
        '    .m_CompareUnit2 = New Unit(dr, "compareUnit2.")
        '  End If
        'Else
        '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_compareUnit2") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_compareUnit2") Then
        '    .m_CompareUnit2 = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_compareUnit2")))
        '  End If
        'End If

        'If dr.Table.Columns.Contains("compareUnit3.unit_id") Then
        '  If Not dr.IsNull("compareUnit3.unit_id") Then
        '    .m_CompareUnit3 = New Unit(dr, "compareUnit3.")
        '  End If
        'Else
        '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_compareUnit3") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_compareUnit3") Then
        '    .m_CompareUnit3 = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_compareUnit3")))
        '  End If
        'End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_shelfLife") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_shelfLife") Then
          .m_shelfLife = CInt(dr(aliasPrefix & Me.Prefix & "_shelfLife"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If
        ' Huaneng edit Conversion
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unitConversion1") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unitConversion1") Then
          .m_conversionUnit1 = CDec(dr(aliasPrefix & Me.Prefix & "_unitConversion1"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unitConversion2") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unitConversion2") Then
          .m_conversionUnit2 = CDec(dr(aliasPrefix & Me.Prefix & "_unitConversion2"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unitConversion3") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unitConversion3") Then
          .m_conversionUnit3 = CDec(dr(aliasPrefix & Me.Prefix & "_unitConversion3"))
        End If
        If Not Configuration.GetConfig("ActualPricePeriod") Is Nothing Then
          .m_monthperiod = CInt(Configuration.GetConfig("ActualPricePeriod"))
        End If
      End With

    End Sub

    Public Sub LoadCostLink()
      m_LCISupplierCostLink = New LCISupplierCostLink(Me)
      m_LCILaborCostLink = New LCILaborCostLink(Me)
      m_LCIEquipmentCostLink = New LCIEquipmentCostLink(Me)
    End Sub
    Public Sub LoadImage()
      If Id <= 0 Then
        Return
      End If

      Dim conn As New SqlConnection(Me.RealConnectionString)
      Dim sql As String = "select lci_image from lciimage where lci_id=" & Id

      conn.Open()

      Dim cmd As SqlCommand = conn.CreateCommand
      cmd.CommandText = sql

      Dim reader As SqlDataReader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))
      If reader.Read Then
        LoadImage(reader)
      End If
    End Sub
    Private Sub LoadImage(ByVal reader As IDataReader)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      m_image = Field.GetImage(reader, "lci_image")
      Try
        If Image Is Nothing Then
          m_image = Image.FromFile(myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Entity.BlankImage}"))
        End If
      Catch ex As Exception

      End Try
    End Sub
#End Region

#Region "Properties"
    Public Property LCIEquipmentCostLink() As LCIEquipmentCostLink      Get        Return m_LCIEquipmentCostLink      End Get      Set(ByVal Value As LCIEquipmentCostLink)        m_LCIEquipmentCostLink = Value      End Set    End Property
    Public Property LCILaborCostLink() As LCILaborCostLink      Get        Return m_LCILaborCostLink      End Get      Set(ByVal Value As LCILaborCostLink)        m_LCILaborCostLink = Value      End Set    End Property
    Public Property LCISupplierCostLink() As LCISupplierCostLink      Get        Return m_LCISupplierCostLink      End Get      Set(ByVal Value As LCISupplierCostLink)        m_LCISupplierCostLink = Value      End Set    End Property
    Public Property WBSCode() As String      Get        Return m_wbscode      End Get      Set(ByVal Value As String)        m_wbscode = Value      End Set    End Property
    Public Property CustomerCode() As String      Get        Return m_customerCode      End Get      Set(ByVal Value As String)        m_customerCode = Value      End Set    End Property
    Public Property Lv1() As String      Get        Return lci_lv1      End Get      Set(ByVal Value As String)        lci_lv1 = Value      End Set    End Property    Public Property Lv2() As String      Get        Return lci_lv2      End Get      Set(ByVal Value As String)        lci_lv2 = Value      End Set    End Property    Public Property Lv3() As String      Get        Return lci_lv3      End Get      Set(ByVal Value As String)        lci_lv3 = Value      End Set    End Property    Public Property Lv4() As String      Get        Return lci_lv4      End Get      Set(ByVal Value As String)        lci_lv4 = Value      End Set    End Property    Public Property Lv5() As String      Get        Return lci_lv5      End Get      Set(ByVal Value As String)        lci_lv5 = Value      End Set    End Property
    Private m_code As String
    Public Overrides Property Code() As String
      Get
        'HACK
        If ConfigurationSettings.AppSettings.Item("AddInsDirectory") Is Nothing OrElse Not ConfigurationSettings.AppSettings.Item("AddInsDirectory").ToLower.EndsWith("_ple\") Then
          Dim myCode As String = ""
          myCode &= Me.lci_lv1 & "." & Me.lci_lv2 & "." & Me.lci_lv3

          If Not Me.Lv4 Is Nothing AndAlso Me.Lv4.Length > 0 Then
            myCode &= "." & Me.lci_lv4
          End If
          If Not Me.Lv5 Is Nothing AndAlso Me.Lv5.Length > 0 Then
            myCode &= "." & Me.lci_lv5
          End If
          If myCode = ".." Then
            myCode = ""
          End If
          m_code = myCode
        End If
        Return m_code
      End Get
      Set(ByVal Value As String)
        If Value Is Nothing Then
          Value = ""
        End If
        m_code = Value
        Me.lci_lv1 = ""
        Me.lci_lv2 = ""
        Me.lci_lv3 = ""
        Me.lci_lv4 = ""
        Me.lci_lv5 = ""
        Dim lvs() As String = Value.Split("."c)
        If lvs.Length >= 1 Then
          lci_lv1 = lvs(0)
          If lvs.Length >= 2 Then
            lci_lv2 = lvs(1)
            If lvs.Length >= 3 Then
              lci_lv3 = lvs(2)
              If lvs.Length >= 4 Then
                lci_lv4 = lvs(3)
                If lvs.Length >= 5 Then
                  lci_lv5 = lvs(4)
                End If
              End If
            End If
          End If
        End If
      End Set
    End Property
    Public Property Account() As Account Implements IHasAccount.Account      Get        Return m_account      End Get      Set(ByVal Value As Account)        m_account = Value      End Set    End Property    Public Property Unvatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property    Public Property FairPrice() As Decimal      Get        Return m_fairPrice      End Get      Set(ByVal Value As Decimal)        m_fairPrice = Value      End Set    End Property    Public ReadOnly Property MovingCost() As Decimal      Get        Return m_movingCost      End Get    End Property    Public ReadOnly Property Price1() As Decimal      Get
        Return Me.FairPrice * Me.ConversionUnit1
      End Get
    End Property    Public ReadOnly Property Price2() As Decimal      Get
        Return Me.FairPrice * Me.ConversionUnit2
      End Get
    End Property    Public ReadOnly Property Price3() As Decimal      Get
        Return Me.FairPrice * Me.ConversionUnit3
      End Get
    End Property    Public Property ShelfLife() As Integer      Get        Return m_shelfLife      End Get      Set(ByVal Value As Integer)        m_shelfLife = Value      End Set    End Property    Public Property Note() As String Implements IHasNote.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property
    Public Property DefaultUnit() As Unit Implements IHasUnit.DefaultUnit      Get        If Me.Originated Then
          'Return (New LCIItem(Me.Id).MemoryUnit)  
          Return Me.GetLciitem(Me.Id).MemoryUnit
        End If        Return m_defaultUnit      End Get      Set(ByVal Value As Unit)        'm_defaultUnit = Value      End Set    End Property    Public Property MemoryUnit() As Unit Implements IHasUnit.MemoryUnit
      Get
        Return Me.m_defaultUnit
      End Get
      Set(ByVal Value As Unit)
        Me.m_defaultUnit = Value
      End Set
    End Property    Public Property CompareUnit1() As Unit
      Get
        If Me.Originated Then
          'Return (New LCIItem(Me.Id).MemoryCompareUnit1)
          Return Me.GetLciitem(Me.Id).MemoryCompareUnit1
        End If
        Return m_CompareUnit1
      End Get
      Set(ByVal Value As Unit)
        'm_CompareUnit1 = Value
      End Set
    End Property
    Public Property MemoryCompareUnit1() As Unit
      Get
        Return Me.m_CompareUnit1
      End Get
      Set(ByVal Value As Unit)
        Me.m_CompareUnit1 = Value
      End Set
    End Property
    Public Property CompareUnit2() As Unit
      Get
        If Me.Originated Then
          'Return (New LCIItem(Me.Id).MemoryCompareUnit2)
          Return Me.GetLciitem(Me.Id).MemoryCompareUnit2
        End If
        Return m_CompareUnit2
      End Get
      Set(ByVal Value As Unit)
        'm_CompareUnit1 = Value
      End Set
    End Property
    Public Property MemoryCompareUnit2() As Unit
      Get
        Return Me.m_CompareUnit2
      End Get
      Set(ByVal Value As Unit)
        Me.m_CompareUnit2 = Value
      End Set
    End Property
    Public Property CompareUnit3() As Unit
      Get
        If Me.Originated Then
          'Return (New LCIItem(Me.Id).MemoryCompareUnit3)
          Return Me.GetLciitem(Me.Id).MemoryCompareUnit3
        End If
        Return m_CompareUnit3
      End Get
      Set(ByVal Value As Unit)
        'm_CompareUnit1 = Value
      End Set
    End Property
    Public Property MemoryCompareUnit3() As Unit
      Get
        Return Me.m_CompareUnit3
      End Get
      Set(ByVal Value As Unit)
        Me.m_CompareUnit3 = Value
      End Set
    End Property
    Public Property ConversionUnit1() As Decimal
      Get
        If Me.Originated Then
          'Return (New LCIItem(Me.Id).MemoryConversionUnit1)
          Return Me.GetLciitem(Me.Id).MemoryConversionUnit1
        End If
        Return m_conversionUnit1
      End Get
      Set(ByVal Value As Decimal)
        'm_conversionUnit1 = Value
      End Set
    End Property
    Public Property MemoryConversionUnit1() As Decimal
      Get
        Return m_conversionUnit1
      End Get
      Set(ByVal Value As Decimal)
        m_conversionUnit1 = Value
      End Set
    End Property
    Public Property ConversionUnit2() As Decimal
      Get
        If Me.Originated Then
          'Return (New LCIItem(Me.Id).MemoryConversionUnit2)
          Return Me.GetLciitem(Me.Id).MemoryConversionUnit2
        End If
        Return m_conversionUnit2
      End Get
      Set(ByVal Value As Decimal)
        'm_conversionUnit2 = Value
      End Set
    End Property
    Public Property MemoryConversionUnit2() As Decimal
      Get
        Return m_conversionUnit2
      End Get
      Set(ByVal Value As Decimal)
        m_conversionUnit2 = Value
      End Set
    End Property
    Public Property ConversionUnit3() As Decimal
      Get
        If Me.Originated Then
          'Return (New LCIItem(Me.Id).MemoryConversionUnit3)
          Return Me.GetLciitem(Me.Id).MemoryConversionUnit3
        End If
        Return m_conversionUnit3
      End Get
      Set(ByVal Value As Decimal)
        'm_conversionUnit3 = Value
      End Set
    End Property
    Public Property MemoryConversionUnit3() As Decimal
      Get
        Return m_conversionUnit3
      End Get
      Set(ByVal Value As Decimal)
        m_conversionUnit3 = Value
      End Set
    End Property
    Public Property MonthPeriod() As Integer
      Get
        Return m_monthperiod
      End Get
      Set(ByVal Value As Integer)
        m_monthperiod = Value
      End Set
    End Property
    Public Overrides ReadOnly Property GetCollectionSproc() As String
      Get
        Return "GetLCICollection"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "lci"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "LCIItem"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.LCIItem.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.LCIItem"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.LCIItem"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.LCIItem.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Methods"
    'Public Shared Function GetSchemaTable() As DataTable
    'Dim myDatatable As New DataTable("lciitem")
    'myDatatable.Columns.Add(New DataColumn("lci_id", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_code", GetType(String)))
    'myDatatable.Columns.Add(New DataColumn("lci_name", GetType(String)))
    'myDatatable.Columns.Add(New DataColumn("lci_altName", GetType(String)))
    'myDatatable.Columns.Add(New DataColumn("lci_parid", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lciparent_id", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_level", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_path", GetType(String)))
    'myDatatable.Columns.Add(New DataColumn("lci_control", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_lv1", GetType(String)))
    'myDatatable.Columns.Add(New DataColumn("lci_lv2", GetType(String)))
    'myDatatable.Columns.Add(New DataColumn("lci_lv3", GetType(String)))
    'myDatatable.Columns.Add(New DataColumn("lci_lv4", GetType(String)))
    'myDatatable.Columns.Add(New DataColumn("lci_lv5", GetType(String)))
    'myDatatable.Columns.Add(New DataColumn("lci_acct", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_unvatable", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_fairprice", GetType(Decimal)))
    'myDatatable.Columns.Add(New DataColumn("lci_movingCost", GetType(Decimal)))
    'myDatatable.Columns.Add(New DataColumn("lci_defaultunit", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_compareUnit1", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_compareUnit2", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_compareUnit3", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_unitConversion1", GetType(Decimal)))
    'myDatatable.Columns.Add(New DataColumn("lci_unitConversion2", GetType(Decimal)))
    'myDatatable.Columns.Add(New DataColumn("lci_unitConversion3", GetType(Decimal)))
    'myDatatable.Columns.Add(New DataColumn("lci_shelflife", GetType(Integer)))
    'myDatatable.Columns.Add(New DataColumn("lci_note", GetType(String)))
    'Return myDatatable
    'End Function
    Public Shared Sub RefreshAllData()
      LCIItem.m_AllLciitems = New Hashtable
      Dim key As String = ""

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetLCICollection" _
    , Nothing)
      If ds.Tables(0).Rows.Count >= 1 Then
        For Each row As DataRow In ds.Tables(0).Rows
          Dim drh As New DataRowHelper(row)
          key = CStr(drh.GetValue(Of Integer)("lci_id"))
          LCIItem.m_AllLciitems(key) = row
        Next
      End If
    End Sub
    Public Shared Sub RefreshData(ByVal ParamArray commandParameters() As SqlParameter)
      Dim key As String = ""

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetLCICollection" _
    , commandParameters)
      'If ds.Tables(0).Rows.Count >= 1 Then
      LCIItem.m_LciitemTable = ds.Tables(0)

      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        key = CStr(drh.GetValue(Of Integer)("lci_id"))
      Next
      'End If
    End Sub
    Public Function GetLciitemFilter(ByVal level As Integer, ByVal parentId As Integer) As DataRow()
      Dim drs As DataRow()

      If level = 1 Then
        drs = LCIItem.LciitemTable.Select("lci_level=1")
      Else
        drs = LCIItem.LciitemTable.Select("lci_level=" & level.ToString & " and lci_parid=" & parentId.ToString)
      End If

      Return drs
    End Function
    'Public Function GetLciitemFilterLv5(ByVal lv4 As TreeBaseEntityCollection) As DataRow()
    'Dim drs As DataRow()
    'Dim idString As String = ""
    'For Each lci As LCIItem In lv4
    'If idString.Length > 0 Then
    'idString &= ","
    'End If
    'idString &= lci.Id.ToString
    'Next
    'drs = m_LciitemLv5.Select("lci_parid in (" & idString & ")")

    'Return drs
    'End Function
    Public Shared Function GetLciitem(ByVal Id As Integer) As LCIItem
      Dim key As String = Id.ToString
      Dim row As DataRow = CType(AllLciitems(key), DataRow)
      Dim lci As New LCIItem(row, "") 'Pui
      Return lci
    End Function
    'Private Function NewLciitem(ByVal row As DataRow) As LCIItem
    'Dim lci As New LCIItem(row)
    'Dim drh As New DataRowHelper(row)
    'lci.Id = drh.GetValue(Of Integer)("lci_id")
    'lci.Code = drh.GetValue(Of String)("lci_code")
    'lci.Name = drh.GetValue(Of String)("lci_name")
    'lci.AlternateName = drh.GetValue(Of String)("lci_altName")

    'lci.Parent = New LCIItem(row)
    'lci.Parent.Id = drh.GetValue(Of Integer)("lciparent_id")

    'lci.Level = drh.GetValue(Of Integer)("lci_level")
    'lci.Lv1 = drh.GetValue(Of String)("lci_lv1")
    'lci.Lv2 = drh.GetValue(Of String)("lci_lv2")
    'lci.Lv3 = drh.GetValue(Of String)("lci_lv3")
    'lci.Lv4 = drh.GetValue(Of String)("lci_lv4")
    'lci.Lv5 = drh.GetValue(Of String)("lci_lv5")
    'lci.FairPrice = drh.GetValue(Of Decimal)("lci_fairprice")

    'lci.DefaultUnit = New Unit
    'lci.DefaultUnit.Id = drh.GetValue(Of Integer)("unit_id")
    'lci.DefaultUnit.Code = drh.GetValue(Of String)("unit_code")
    'lci.DefaultUnit.Name = drh.GetValue(Of String)("unit_name")

    'lci.MemoryCompareUnit1 = New Unit
    'lci.MemoryCompareUnit1.Id = drh.GetValue(Of Integer)("compareUnit1.unit_id")
    'lci.MemoryCompareUnit1.Code = drh.GetValue(Of String)("compareUnit1.unit_code")
    'lci.MemoryCompareUnit1.Name = drh.GetValue(Of String)("compareUnit1.unit_name")

    'lci.MemoryCompareUnit2 = New Unit
    'lci.MemoryCompareUnit2.Id = drh.GetValue(Of Integer)("compareUnit2.unit_id")
    'lci.MemoryCompareUnit2.Code = drh.GetValue(Of String)("compareUnit2.unit_code")
    'lci.MemoryCompareUnit2.Name = drh.GetValue(Of String)("compareUnit2.unit_name")

    'lci.MemoryCompareUnit3 = New Unit
    'lci.MemoryCompareUnit3.Id = drh.GetValue(Of Integer)("compareUnit3.unit_id")
    'lci.MemoryCompareUnit3.Code = drh.GetValue(Of String)("compareUnit3.unit_code")
    'lci.MemoryCompareUnit3.Name = drh.GetValue(Of String)("compareUnit3.unit_name")
    'Return lci
    'End Function
    Public Function CheckUnitBeforeSaving() As String
      Dim dt As DataTable = GetRefUnitTable()
      If dt Is Nothing Then
        Return ""
      End If
      If dt.Rows.Count = 0 Then
        Return ""
      End If
      For Each row As DataRow In dt.Rows
        If row.IsNull("level") Then
          Dim theLevel As Integer = CInt(row("level"))
          Dim lciToCompare As LCIItem
          If theLevel = Me.Level Then
            'Level เดียวกัน
            lciToCompare = Me
          ElseIf theLevel = Me.Level - 1 Then
            'lciToCompare = New LCIItem(Me.Parent.Id)
            lciToCompare = Me.GetLciitem(Me.Parent.Id)
          ElseIf theLevel = Me.Level - 2 Then
            'lciToCompare = New LCIItem(Me.Parent.Id)
            'lciToCompare = New LCIItem(lciToCompare.Parent.Id)
            lciToCompare = Me.GetLciitem(Me.Parent.Id)
            lciToCompare = Me.GetLciitem(lciToCompare.Parent.Id)
          ElseIf theLevel = Me.Level - 3 Then
            'lciToCompare = New LCIItem(Me.Parent.Id)
            'lciToCompare = New LCIItem(lciToCompare.Parent.Id)
            'lciToCompare = New LCIItem(lciToCompare.Parent.Id)
            lciToCompare = Me.GetLciitem(Me.Parent.Id)
            lciToCompare = Me.GetLciitem(lciToCompare.Parent.Id)
            lciToCompare = Me.GetLciitem(lciToCompare.Parent.Id)
          ElseIf theLevel = Me.Level - 4 Then
            'lciToCompare = New LCIItem(Me.Parent.Id)
            'lciToCompare = New LCIItem(lciToCompare.Parent.Id)
            'lciToCompare = New LCIItem(lciToCompare.Parent.Id)
            'lciToCompare = New LCIItem(lciToCompare.Parent.Id)
            lciToCompare = Me.GetLciitem(Me.Parent.Id)
            lciToCompare = Me.GetLciitem(lciToCompare.Parent.Id)
            lciToCompare = Me.GetLciitem(lciToCompare.Parent.Id)
            lciToCompare = Me.GetLciitem(lciToCompare.Parent.Id)
          End If
          If Not row.IsNull("unit_id") Then
            Dim refUnit As New Unit(CInt(row("unit_id")))
            If Not lciToCompare Is Nothing AndAlso Not lciToCompare.ValidUnit(refUnit, True, True) Then
              Return "ต้องมีหน่วยนับ " & refUnit.Name & " ในวัสดุนี้หรือวัสดุในสังกัดด้วย"
            End If
          End If
        End If
      Next
      Return ""
    End Function
    Public Function GetRefUnitTable() As DataTable
      If Not Me.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, "GetRefUnitForLCI", _
      New SqlParameter("@lci_id", Me.Id))
      Return ds.Tables(0)
    End Function
    Public Shared Function GetBestPriceSchema() As TreeTable
      Dim myDatatable As New TreeTable("BestPrice")
      Dim col As New DataColumn("Type", GetType(String))
      myDatatable.Columns.Add(col)
      col = New DataColumn("AVG", GetType(String))
      myDatatable.Columns.Add(col)
      col = New DataColumn("Max", GetType(String))
      myDatatable.Columns.Add(col)
      col = New DataColumn("Min", GetType(String))
      myDatatable.Columns.Add(col)
      Return myDatatable
    End Function
    Public Function GetBestPriceTable(ByVal unit As Unit) As TreeTable
      If Not Me.Originated OrElse unit Is Nothing OrElse Not unit.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, "GetLCIBestPrice", _
      New SqlParameter("@lci_id", Me.Id), _
      New SqlParameter("@unit_id", unit.Id), _
      New SqlParameter("@monthperiod", Me.MonthPeriod))
      Dim tt As TreeTable = GetBestPriceSchema()
      Dim i As Integer = 0
      For Each row As DataRow In ds.Tables(0).Rows
        Dim tr As TreeRow = tt.Childs.Add
        For Each col As DataColumn In ds.Tables(0).Columns
          If row.IsNull(col) Then
            tr(col.ColumnName) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.LCIItem.NoPrice}")
          Else
            tr(col.ColumnName) = Configuration.FormatToString(CDec(row(col)), DigitConfig.UnitPrice)
          End If
        Next
        Select Case i
          Case 0
            tr("Type") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.LCIItem.BuyPrice}")
          Case 1
            tr("Type") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.LCIItem.DatabasePrice}")
          Case 2
            tr("Type") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.LCIItem.RecentBuyPrice}")
        End Select
        i += 1
      Next
      Return tt
    End Function
    Public Function GetSupplierListTable() As TreeTable
      If Not Me.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.StoredProcedure, "GetLCISupplierList", _
      New SqlParameter("@lci_id", Me.Id))
      Dim tt As TreeTable = LCISupplierCostLink.GetSchemaTable
      For Each row As DataRow In ds.Tables(0).Rows
        Dim tr As TreeRow = tt.Childs.Add
        For Each col As DataColumn In ds.Tables(0).Columns
          tr(col.ColumnName) = row(col)
        Next
      Next
      Return tt
    End Function
    Public Function GetLaborListTable(ByVal unit As Unit) As TreeTable
      If Not Me.Originated OrElse unit Is Nothing OrElse Not unit.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.StoredProcedure, "GetLCILaborList", _
      New SqlParameter("@lci_id", Me.Id), _
      New SqlParameter("@unit_id", unit.Id), _
      New SqlParameter("@lcil_type", "1"))
      Dim tt As TreeTable = LCILaborCostLink.GetSchemaTable
      For Each row As DataRow In ds.Tables(0).Rows
        Dim tr As TreeRow = tt.Childs.Add
        For Each col As DataColumn In ds.Tables(0).Columns
          tr(col.ColumnName) = row(col)
        Next
      Next
      Return tt
    End Function
    Public Function GetEqCostListTable(ByVal unit As Unit) As TreeTable
      If Not Me.Originated OrElse unit Is Nothing OrElse Not unit.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.StoredProcedure, "GetLCILaborList", _
      New SqlParameter("@lci_id", Me.Id), _
      New SqlParameter("@unit_id", unit.Id), _
      New SqlParameter("@lcil_type", "2"))
      Dim tt As TreeTable = LCIEquipmentCostLink.GetSchemaTable
      For Each row As DataRow In ds.Tables(0).Rows
        Dim tr As TreeRow = tt.Childs.Add
        For Each col As DataColumn In ds.Tables(0).Columns
          tr(col.ColumnName) = row(col)
        Next
      Next
      Return tt
    End Function
    Public Function GetUnitIdList() As String
      Dim ret As String = ""
      For Each myId As Integer In Me.GetUnitIdArrayList
        ret &= myId.ToString & ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Remove(Len(ret) - 1, 1)
      End If
      Return ret
    End Function
    Public Function GetUnitIdArrayList(Optional ByVal excludeSelf As Boolean = False, Optional ByVal internal As Boolean = False) As ArrayList
      Dim ret As New ArrayList
      If Me.Level <= 4 Then
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.StoredProcedure, "GetLCIUnits", _
        New SqlParameter("@lci_id", Me.Id) _
        , New SqlParameter("@excludeSelf", excludeSelf))
        Dim dt As DataTable = ds.Tables(0)
        For Each row As DataRow In dt.Rows
          For Each col As DataColumn In dt.Columns
            If Not row.IsNull(col) Then
              ret.Add(row(col))
            End If
          Next
        Next
      End If
      If excludeSelf Or Me.Level > 4 Then
        If internal Then
          If Not Me.MemoryUnit Is Nothing AndAlso Me.MemoryUnit.Originated Then
            ret.Add(Me.MemoryUnit.Id)
          End If
          If Not Me.MemoryCompareUnit1 Is Nothing _
                          AndAlso Me.MemoryCompareUnit1.Originated Then
            ret.Add(Me.MemoryCompareUnit1.Id)
          End If
          If Not Me.MemoryCompareUnit2 Is Nothing _
              AndAlso Me.MemoryCompareUnit2.Originated Then
            ret.Add(Me.MemoryCompareUnit2.Id)
          End If
          If Not Me.MemoryCompareUnit3 Is Nothing _
              AndAlso Me.MemoryCompareUnit3.Originated Then
            ret.Add(Me.MemoryCompareUnit3.Id)
          End If
        Else
          If Not Me.DefaultUnit Is Nothing AndAlso Me.DefaultUnit.Originated Then
            ret.Add(Me.DefaultUnit.Id)
          End If
          If Not Me.CompareUnit1 Is Nothing _
                          AndAlso Me.CompareUnit1.Originated Then
            ret.Add(Me.CompareUnit1.Id)
          End If
          If Not Me.CompareUnit2 Is Nothing _
              AndAlso Me.CompareUnit2.Originated Then
            ret.Add(Me.CompareUnit2.Id)
          End If
          If Not Me.CompareUnit3 Is Nothing _
              AndAlso Me.CompareUnit3.Originated Then
            ret.Add(Me.CompareUnit3.Id)
          End If
        End If
      End If
      Return ret
    End Function
    Public Function ValidUnit(ByVal unit As Unit, Optional ByVal excludeSelf As Boolean = False, Optional ByVal internal As Boolean = False) As Boolean
      For Each myId As Integer In GetUnitIdArrayList(excludeSelf, internal)
        If unit.Id = myId Then
          Return True
        End If
      Next
      Return False
    End Function
    Public Shared Function GetLciItemById(ByVal id As Integer) As LCIItem
      Dim key As String = id.ToString
      Dim row As DataRow = CType(LCIItem.AllLciitems(key), DataRow)
      Try
        Dim lci As New LCIItem(row, "") 'Pui
        Return lci
      Catch ex As Exception
        Throw New Exception(ex.InnerException.ToString)
      End Try
    End Function
    Public Shared Function GetLciConversionByIdUnitId(ByVal id As Integer, ByVal unitId As Integer) As Decimal
      Dim newLci As LCIItem = LCIItem.GetLciItemById(id)
      Select Case unitId
        Case newLci.DefaultUnit.Id
          Return 1
        Case newLci.CompareUnit1.Id
          Return newLci.ConversionUnit1
        Case newLci.CompareUnit2.Id
          Return newLci.ConversionUnit2
        Case newLci.CompareUnit3.Id
          Return newLci.ConversionUnit3
      End Select
      Return 0
    End Function
    Public Function GetConversion(ByVal unit As Unit) As Decimal

      Dim conversion As Decimal = LCIItem.GetLciConversionByIdUnitId(Me.Id, unit.Id)
      If conversion <> 0 Then
        Return conversion
      End If

      Try
        If SqlHelper.GetVersion >= "1.01.0003" OrElse SqlHelper.CheckObjectExist("GetLCIConversion") Then
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
          ConnectionString _
          , CommandType.StoredProcedure _
          , "GetLCIConversion" _
          , New SqlParameter("@unit_id", unit.Id) _
          , New SqlParameter("@lci_id", Me.Id) _
          )
          If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).IsNull(0) Then
              Return 1
            End If
            Dim ret As Decimal = CDec(ds.Tables(0).Rows(0)(0))
            If ret = 0 Then
              MessageBox.Show(Me.Name & ":" & unit.Name & ":0")
              Throw New NoConversionException(Me, unit)
            End If
            Return CDec(ds.Tables(0).Rows(0)(0))
          End If
        Else 'Fallback --> ใช้วิธีเดิม
          If Not Me.DefaultUnit Is Nothing AndAlso unit.Id = Me.DefaultUnit.Id Then
            Return 1
          ElseIf Not Me.CompareUnit1 Is Nothing _
              AndAlso Me.CompareUnit1.Originated _
              AndAlso unit.Id = Me.CompareUnit1.Id Then
            Return Me.ConversionUnit1
          ElseIf Not Me.CompareUnit2 Is Nothing _
              AndAlso Me.CompareUnit2.Originated _
              AndAlso unit.Id = Me.CompareUnit2.Id Then
            Return Me.ConversionUnit2
          ElseIf Not Me.CompareUnit3 Is Nothing _
              AndAlso Me.CompareUnit3.Originated _
              AndAlso unit.Id = Me.CompareUnit3.Id Then
            Return Me.ConversionUnit3
          End If
        End If
      Catch ex As Exception

      End Try
      If Me.Level <= 4 Then
        'HACK
        Return 1
      End If
      MessageBox.Show(Me.Name & ":" & unit.Name)
      Throw New NoConversionException(Me, unit)
    End Function
    Public Function GetChildCount() As Integer
      Dim ds As DataSet = SqlHelper.ExecuteDataset( _
      ConnectionString _
      , CommandType.StoredProcedure _
      , "GetLCIChildCount" _
      , New SqlParameter("@lci_id", Me.Id) _
      )
      Return CInt(ds.Tables(0).Rows(0)(0))
    End Function
    Public Overrides Function ToString() As String
      Return Me.Code & " " & Me.Name
    End Function
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New LCIItem(parId)
      Else
        Me.Parent = Nothing
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New LCIItem
      par.Id = id
      par.Code = code
      par.Name = name
      Me.Parent = par
    End Sub
    Public Function GetLCICollection(ByVal requiredLevel As Integer, ByVal parentId As Integer, ByVal refresh As Boolean, ByVal ParamArray filters() As Filter) As TreeBaseEntityCollection
      Dim params(filters.Length - 1 + 2) As SqlParameter
      For i As Integer = 0 To filters.Length - 1
        params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
      Next
      params(filters.Length) = New SqlParameter("@level", requiredLevel)
      params(filters.Length + 1) = New SqlParameter("@parid", parentId)

      'Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.StoredProcedure, Me.GetCollectionSproc, params)
      If refresh Then
        Me.RefreshData(params)
      End If
      'Trace.Write(filtersString)
      Dim drs As DataRow() = Me.GetLciitemFilter(requiredLevel, parentId)

      Dim myCollection As New TreeBaseEntityCollection
      'For Each dr As DataRow In ds.Tables(0).Rows
      'For Each row As DataRow In dt.Rows
      'Dim lci As LCIItem = Me.NewLciitem(row)
      'myCollection.Add(lci)
      'Next
      Dim key As String = ""
      For i As Integer = 0 To drs.Length - 1
        'Dim row As DataRow = drs(i)
        Dim drh As New DataRowHelper(drs(i))

        key = drh.GetValue(Of String)("lci_id")
        'row = CType(Me.m_AllLciitem(key), DataRow)
        Dim lci As New LCIItem(drs(i), "") 'Pui
        myCollection.Add(lci)
      Next

      Return myCollection
    End Function
    Private m_currentParenLciitem As LCIItem
    Public Function CountCurrentLv4Lv5() As Integer
      Dim drs As DataRow()
      Dim drs2 As DataRow()
      Dim lv4Ids As String = ""
      Dim countLci As Integer
      drs = LCIItem.LciitemTable.Select("lci_level=4 and lci_parid=" & Me.Id.ToString)
      For i As Integer = 0 To drs.Length - 1
        Dim dr As DataRow = drs(i)
        If lv4Ids.Length > 0 Then
          lv4Ids &= ","
        End If

        lv4Ids &= CStr(dr("lci_id"))
        countLci += 1
      Next
      If lv4Ids.Length > 0 Then
        drs2 = LCIItem.LciitemTable.Select("lci_level=5 and lci_parid in (" & lv4Ids & ")")
        countLci += drs2.Length
      End If
      Return countLci
    End Function
    Public Property CurrentParentLciitem As LCIItem
      Get
        Return m_currentParenLciitem
      End Get
      Set(ByVal value As LCIItem)
        m_currentParenLciitem = value
      End Set
    End Property

    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()

      Dim parentItem As LCIItem = Me.CurrentParentLciitem
      Dim drs As DataRow() = GetLciitemFilter(4, parentItem.Id)
      Dim lciLv4Id As Integer
      For i As Integer = 0 To drs.Length - 1
        Dim drh As New DataRowHelper(drs(i))
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow.State = RowExpandState.Expanded
        newRow("Selected") = False
        newRow("Code") = drh.GetValue(Of String)("lci_code")
        newRow("Description") = drh.GetValue(Of String)("lci_name")
        newRow.Tag = New LCIItem(drs(i), "") 'Pui

        lciLv4Id = drh.GetValue(Of Integer)("lci_id")
        Dim drs4 As DataRow() = GetLciitemFilter(5, lciLv4Id)
        For j As Integer = 0 To drs4.Length - 1

          Dim drh5 As New DataRowHelper(drs4(j))
          Dim newRow5 As TreeRow = newRow.Childs.Add()
          newRow5.State = RowExpandState.None
          newRow5("Selected") = False
          newRow5("Code") = drh5.GetValue(Of String)("lci_code")
          newRow5("Description") = drh5.GetValue(Of String)("lci_name")

          newRow5("Unit") = drh5.GetValue(Of String)("unit_name")
          If drh5.GetValue(Of Decimal)("lci_fairprice") <> 0 Then
            newRow5("UnitPrice") = Configuration.FormatToString(drh5.GetValue(Of Decimal)("lci_fairprice"), DigitConfig.UnitPrice)
          End If

          newRow5("Unit1") = drh5.GetValue(Of String)("compareUnit1.unit_name")
          If drh5.GetValue(Of Decimal)("lci_fairprice1") <> 0 Then
            newRow5("UnitPrice1") = Configuration.FormatToString(drh5.GetValue(Of Decimal)("lci_fairprice1"), DigitConfig.UnitPrice)
          End If

          newRow5("Unit2") = drh5.GetValue(Of String)("compareUnit2.unit_name")
          If drh5.GetValue(Of Decimal)("lci_fairprice2") <> 0 Then
            newRow5("UnitPrice2") = Configuration.FormatToString(drh5.GetValue(Of Decimal)("lci_fairprice2"), DigitConfig.UnitPrice)
          End If

          newRow5("Unit3") = drh5.GetValue(Of String)("compareUnit3.unit_name")
          If drh5.GetValue(Of Decimal)("lci_fairprice3") <> 0 Then
            newRow5("UnitPrice3") = Configuration.FormatToString(drh5.GetValue(Of Decimal)("lci_fairprice3"), DigitConfig.UnitPrice)
          End If

          newRow5.Tag = New LCIItem(drs4(j), "") 'Pui 

        Next
      Next

      'Dim l4coll As TreeBaseEntityCollection = Me.GetLCICollection(4, parentItem.Id, "")
      'For Each lci As LCIItem In l4coll
      'i += 1
      'Dim newRow As TreeRow = dt.Childs.Add()
      'lci.CopyToDataRow(newRow)
      'lci.ItemValidateRow(newRow)
      'newRow.Tag = lci
      'Next
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim unitError As String = CheckUnitBeforeSaving()
        If Not unitError Is Nothing AndAlso unitError.Length > 0 Then
          Return New SaveErrorException(unitError)
        End If
        Dim parID As Object = 0
        If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
          parID = Me.Parent.Id
        ElseIf Me.Originated Then
          parID = Me.Id
        Else
          parID = DBNull.Value
        End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        Dim paramArrayList As New ArrayList
        paramArrayList.Add(returnVal)
        If .Originated Then
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_altName", Me.AlternateName))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_parid", parID))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_control", Me.IsControlGroup))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lv1", Me.Lv1))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lv2", Me.Lv2))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lv3", Me.Lv3))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lv4", Me.Lv4))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_lv5", Me.Lv5))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acct", Me.Account.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_unvatable", Me.Unvatable))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fairprice", Me.FairPrice))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_defaultunit", Me.MemoryUnit.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_compareUnit1", Me.MemoryCompareUnit1.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_compareUnit2", Me.MemoryCompareUnit2.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_compareUnit3", Me.MemoryCompareUnit3.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_unitConversion1", Me.MemoryConversionUnit1))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_unitConversion2", Me.MemoryConversionUnit2))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_unitConversion3", Me.MemoryConversionUnit3))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_shelflife", Me.ShelfLife))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_pjmid", Me.PJMID))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wbscode", Me.WBSCode))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2
                trans.Rollback()
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          Dim saveSupplierError As SaveErrorException = Me.m_LCISupplierCostLink.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveSupplierError.Message) Then
            trans.Rollback()
            Return saveSupplierError
          Else
            Select Case CInt(saveSupplierError.Message)
              Case -1, -2
                trans.Rollback()
                Return saveSupplierError
              Case Else
            End Select
          End If
          Dim saveLaborError As SaveErrorException = Me.m_LCILaborCostLink.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveLaborError.Message) Then
            trans.Rollback()
            Return saveLaborError
          Else
            Select Case CInt(saveLaborError.Message)
              Case -1, -2
                trans.Rollback()
                Return saveLaborError
              Case Else
            End Select
          End If
          Dim saveEqError As SaveErrorException = Me.m_LCIEquipmentCostLink.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveEqError.Message) Then
            trans.Rollback()
            Return saveEqError
          Else
            Select Case CInt(saveEqError.Message)
              Case -1, -2
                trans.Rollback()
                Return saveEqError
              Case Else
            End Select
          End If

          trans.Commit()

          '== ทำลาย Member นี้ทิ้งเสมอ เมื่อมีการแก้ไข ============
          m_AllLciitems = Nothing
          m_LciitemTable = Nothing
          '== ทำลาย Member นี้ทิ้งเสมอ เมื่อมีการแก้ไข ============

          Try
            SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure _
          , "InsertLciitemDepend" _
          , New SqlParameter("@lci_id", Me.Id))
            'Undone
            'If Not Me.Image Is Nothing Then
            ' call update image 
            SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure _
            , "InsertLCIimage" _
            , New SqlParameter("@lci_id", Me.Id) _
            , New SqlParameter("@lci_image", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(Me.Image)))

            '== Update Lciitem ==========================================================
            Dim key As String = Me.Id.ToString
            Dim row As DataRow = CType(LCIItem.AllLciitems(key), DataRow)
            If row Is Nothing Then
              row = LCIItem.LciitemTable.NewRow
              LCIItem.LciitemTable.Rows.Add(row)
              LCIItem.AllLciitems(key) = row
            End If
            Dim dbRow As DataRow
            Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
            , CommandType.StoredProcedure _
            , Me.GetSprocName _
            , New SqlParameter("@" & Me.Prefix & "_id", Id) _
            )
            If ds.Tables(0).Rows.Count = 1 Then
              dbRow = ds.Tables(0).Rows(0)
            End If
            If Not dbRow Is Nothing Then
              For Each col As DataColumn In row.Table.Columns
                If dbRow.Table.Columns.Contains(col.ColumnName) Then
                  row(col) = dbRow(col.ColumnName)
                End If
              Next
            End If
            If row.Table.Columns.Contains("lci_fairprice1") Then
              row("lci_fairprice1") = Configuration.FormatToString(Me.FairPrice * Me.MemoryConversionUnit1, DigitConfig.Price)
            End If
            If row.Table.Columns.Contains("lci_fairprice2") Then
              row("lci_fairprice2") = Configuration.FormatToString(Me.FairPrice * Me.MemoryConversionUnit2, DigitConfig.Price)
            End If
            If row.Table.Columns.Contains("lci_fairprice3") Then
              row("lci_fairprice3") = Configuration.FormatToString(Me.FairPrice * Me.MemoryConversionUnit3, DigitConfig.Price)
            End If
            '============================================================
            'End If
          Catch ex As Exception
            Throw New AfterCommitException("Error After Commit", ex)
          End Try
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As AfterCommitException
          Return New SaveErrorException(ex.InnerException.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try

      End With
    End Function
    Public Shared Sub Import(ByVal dt As DataTable)
      Dim lciArray As New ArrayList
      Dim levelHash As New Hashtable
      Dim currLevel As Integer = 1
      Dim currLCI As LCIItem
      Dim opbHash As New Hashtable
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        If IsNumeric(row("Level")) Then
          Dim newLevel As Integer = CInt(row("Level"))
          Dim newLCI As LCIItem
          Dim canAdd As Boolean = True
          If newLevel = 1 Then          'มี root อีกอัน
            newLCI = New LCIItem
            newLCI.Parent = newLCI
            newLCI.Level = 1
          ElseIf newLevel = currLevel + 1 Then          'เป็นลูกอันก่อน
            newLCI = New LCIItem(currLCI)
          ElseIf newLevel = currLevel Then          'เป็นพี่น้อง
            newLCI = New LCIItem(CType(currLCI.Parent, LCIItem))
          ElseIf newLevel < currLevel Then          'เป็นพี่น้อง
            If Not levelHash(newLevel - 1) Is Nothing Then
              Dim parent As LCIItem = CType(levelHash(newLevel - 1), LCIItem)
              newLCI = New LCIItem(parent)
            Else
              canAdd = False
            End If
          Else
            canAdd = False
          End If
          If canAdd AndAlso Not newLCI Is Nothing Then
            If dt.Columns.Contains("Lv1") AndAlso Not row.IsNull("Lv1") Then
              newLCI.Lv1 = CStr(row("Lv1"))
            End If
            If dt.Columns.Contains("Lv2") AndAlso Not row.IsNull("Lv2") Then
              newLCI.Lv2 = CStr(row("Lv2"))
            End If
            If dt.Columns.Contains("Lv3") AndAlso Not row.IsNull("Lv3") Then
              newLCI.Lv3 = CStr(row("Lv3"))
            End If
            If newLCI.Level >= 4 Then
              If dt.Columns.Contains("Lv4") AndAlso Not row.IsNull("Lv4") Then
                newLCI.Lv4 = CStr(row("Lv4"))
              End If
              If newLCI.Level = 5 Then
                If dt.Columns.Contains("Lv5") AndAlso Not row.IsNull("Lv5") Then
                  newLCI.Lv5 = CStr(row("Lv5"))
                End If
              End If
            End If
            Dim testLci As New LCIItem(newLCI.Code)
            If testLci.Originated Then
              newLCI = testLci
            End If
            If dt.Columns.Contains("Name") AndAlso Not row.IsNull("Name") Then
              newLCI.Name = CStr(row("Name"))
            End If
            If dt.Columns.Contains("AltName") AndAlso Not row.IsNull("AltName") Then
              newLCI.AlternateName = CStr(row("AltName"))
            End If
            If dt.Columns.Contains("Unit") AndAlso Not row.IsNull("Unit") Then
              newLCI.MemoryUnit = New Unit(CStr(row("Unit")))
            End If

            If dt.Columns.Contains("Unit1") AndAlso Not row.IsNull("Unit1") Then
              newLCI.MemoryCompareUnit1 = New Unit(CStr(row("Unit1")))
              If newLCI.MemoryCompareUnit1.Originated Then
                If dt.Columns.Contains("Conv1") AndAlso Not row.IsNull("Conv1") Then
                  newLCI.MemoryConversionUnit1 = CDec(row("Conv1"))
                End If
              End If
            End If
            If dt.Columns.Contains("Unit2") AndAlso Not row.IsNull("Unit2") Then
              newLCI.MemoryCompareUnit2 = New Unit(CStr(row("Unit2")))
              If newLCI.MemoryCompareUnit2.Originated Then
                If dt.Columns.Contains("Conv2") AndAlso Not row.IsNull("Conv2") Then
                  newLCI.MemoryConversionUnit2 = CDec(row("Conv2"))
                End If
              End If
            End If
            If dt.Columns.Contains("Unit3") AndAlso Not row.IsNull("Unit3") Then
              newLCI.MemoryCompareUnit3 = New Unit(CStr(row("Unit3")))
              If newLCI.MemoryCompareUnit3.Originated Then
                If dt.Columns.Contains("Conv3") AndAlso Not row.IsNull("Conv3") Then
                  newLCI.MemoryConversionUnit3 = CDec(row("Conv3"))
                End If
              End If
            End If

            If dt.Columns.Contains("FairPrice") AndAlso Not row.IsNull("FairPrice") Then
              newLCI.FairPrice = CDec(row("FairPrice"))
            End If

            newLCI.Save(1)
            currLCI = newLCI
            currLevel = newLevel
            levelHash(newLevel) = currLCI

            If newLCI.Level = 5 Then
              i += 1
              If dt.Columns.Contains("CC") AndAlso Not row.IsNull("CC") Then
                Dim cc As New CostCenter(CStr(row("CC")))
                If Not cc.Originated Then
                  cc = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                End If
                If cc.Originated Then
                  Dim qty As Decimal = 0
                  If dt.Columns.Contains("Qty") AndAlso Not row.IsNull("Qty") Then
                    qty = CDec(row("Qty"))
                  End If
                  If qty <> 0 Then
                    Dim opb As MatOpenningBalance
                    If Not opbHash.Contains(cc.Id) Then
                      opb = New MatOpenningBalance
                      opb.ToCostCenter = cc
                      opb.DocDate = Now.Date
                      opb.Note = "AutoImport From Excel"
                      opbHash(cc.Id) = opb
                    Else
                      opb = CType(opbHash(cc.Id), MatOpenningBalance)
                    End If
                    Dim item As New MatOpenningBalanceItem
                    item.Entity = newLCI
                    item.Unit = newLCI.DefaultUnit
                    item.Conversion = 1
                    item.Qty = qty
                    item.UnitPrice = newLCI.FairPrice
                    opb.Add(item)

                  End If
                End If
              End If
            End If
          End If
        End If
      Next

      For Each opb As MatOpenningBalance In opbHash.Values
        opb.JournalEntry.RefDoc = opb
        opb.JournalEntry.SetGLFormat(opb.GetDefaultGLFormat)
        Dim s As SaveErrorException = opb.Save(1)
        If Not IsNumeric(s.Message) OrElse CInt(s.Message) < 0 Then
          MessageBox.Show(s.Message)
        End If
      Next
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "CleanLCI")
      trans.Commit()
      conn.Close()
      conn = Nothing
    End Sub
#End Region

#Region "IHasImage"
    Public Property Image() As System.Drawing.Image Implements IHasImage.Image
      Get
        Return m_image
      End Get
      Set(ByVal Value As System.Drawing.Image)
        m_image = Value
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetLCIItem(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldLci As LCIItem) As Boolean
      Dim lci As New LCIItem(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not lci.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        lci = oldLci
      End If
      txtCode.Text = lci.Code
      txtName.Text = lci.Name
      If oldLci.Id <> lci.Id Then
        oldLci = lci
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetAvailabilityInCC(ByVal filters As Filter()) As DataTable
      'GetRemainLCIItemListForCC
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetRemainLCIItemListForCC", params)
      Return ds.Tables(0)
    End Function
#End Region

#Region "IPJMUpdatable"
    Public Property PJMID() As Integer Implements IPJMUpdatable.PJMID
      Get
        Return m_pjmid
      End Get
      Set(ByVal Value As Integer)
        m_pjmid = Value
      End Set
    End Property
#End Region

#Region "Members"
    Public ManualAdding As Boolean = False
#End Region

#Region "IHasPrice"
    Public Property Price() As Decimal Implements IHasPrice.Price
      Get
        Return Me.FairPrice
      End Get
      Set(ByVal Value As Decimal)
        FairPrice = Value
      End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return True 'Hack
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteLCI}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteLciItem", New SqlParameter() {New SqlParameter("@lci_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.LCIIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        trans.Commit()
        '== ทำลาย Member นี้ทิ้งเสมอ เมื่อมีการแก้ไข ============
        m_AllLciitems = Nothing
        m_LciitemTable = Nothing
        '== ทำลาย Member นี้ทิ้งเสมอ เมื่อมีการแก้ไข ============
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

    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "LCIItem"
      End Get
    End Property

  End Class
  Public Class LCIForSelection
    Inherits LCIItem
    Public CC As New CostCenter
    Public FromWip As Boolean = False
    Private m_refEntityId As Integer
    Public Property IDList As String
    Public Property StokId As Integer
    Public Property refEntityId() As Integer
      Get
        Return m_refEntityId
      End Get
      Set(ByVal Value As Integer)
        m_refEntityId = Value
      End Set
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "LCIForSelection"
      End Get
    End Property
  End Class
  Public Class NoConversionException
    Inherits Exception

#Region "Members"
    Private m_lci As LCIItem
    Private m_unit As Unit
#End Region

#Region "Constructors"
    Public Sub New(ByVal lci As LCIItem, ByVal unit As Unit)
      MyBase.New()
      m_lci = lci
      m_unit = unit
    End Sub
#End Region

#Region "Properties"
    Public Property Lci() As LCIItem      Get        Return m_lci      End Get      Set(ByVal Value As LCIItem)        m_lci = Value      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        m_unit = Value      End Set    End Property
#End Region

  End Class
  Public Class AfterCommitException
    Inherits Exception
    Public Sub New(ByVal m As String, ByVal ex As Exception)
      MyBase.New(m, ex)
    End Sub
  End Class

End Namespace
