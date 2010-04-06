Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.BusinessLogic

  Public Class EquipmentGroup

  End Class

  Public Interface IHasEquipment
    'ReadOnly Property Equipment As Equipment
    'Property ItemCollection As EquipmentItemCollection
  End Interface

  Public Class Equipment
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IHasToCostCenter, IHasEquipment

#Region "Members"
    Private m_name As String
    Private m_group As EquipmentGroup
    Private m_Description As String
    Private m_unit As Unit
    Private m_rentalrate As Decimal
    Private m_itemCollection As EquipmentItemCollection
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
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_group = New EquipmentGroup
        .m_unit = New Unit
        .m_itemCollection = New EquipmentItemCollection(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
          .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_description") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_description") Then
          .m_Description = CStr(dr(aliasPrefix & Me.Prefix & "_description"))
        End If
        'If dr.Table.Columns.Contains(aliasPrefix & "equipmentgroup_id") Then
        '  If Not dr.IsNull(aliasPrefix & "unit_id") Then
        '    .m_group = New EquipmentGroup(dr, aliasPrefix)
        '  Else
        '    .m_group = New EquipmentGroup
        '  End If
        'Else
        '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
        '    .m_group = New EquipmentGroup(CInt(dr(aliasPrefix & Me.Prefix & "_unit")))
        '  Else
        '    .m_group = New EquipmentGroup
        '  End If
        'End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_description") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_description") Then
          .m_Description = CStr(dr(aliasPrefix & Me.Prefix & "_description"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") Then
          If Not dr.IsNull(aliasPrefix & "unit_id") Then
            .m_unit = New Unit(dr, aliasPrefix)
          Else
            .m_unit = New Unit
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_unit")))
          Else
            .m_unit = New Unit
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_rentalrate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_rentalrate") Then
          .m_rentalrate = CDec(dr(aliasPrefix & Me.Prefix & "_rentalrate"))
        End If
      End With

      m_itemCollection = New EquipmentItemCollection(Me)
    End Sub
#End Region

#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Equipment"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "equipment"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Equipment.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Equipment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Equipment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Equipment.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "eq"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return Me.ClassName & ":" & Me.Code
      End Get
    End Property
    Public Property Name As String
      Get
        Return m_name
      End Get
      Set(ByVal value As String)
        m_name = value
      End Set
    End Property
    Public Property Group As EquipmentGroup
      Get
        Return m_group
      End Get
      Set(ByVal value As EquipmentGroup)
        m_group = value
      End Set
    End Property
    Public Property Description As String
      Get
        Return m_Description
      End Get
      Set(ByVal value As String)
        m_Description = value
      End Set
    End Property
    Public Property Unit As Unit
      Get
        Return m_unit
      End Get
      Set(ByVal value As Unit)
        m_unit = value
      End Set
    End Property
    Public Property Rentalrate As Decimal
      Get
        Return m_rentalrate
      End Get
      Set(ByVal value As Decimal)
        m_rentalrate = value
      End Set
    End Property
    Public Property ItemCollection As EquipmentItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal value As EquipmentItemCollection)
        m_itemCollection = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Overloads Overrides Function GetDataset(ByVal query As String, ByVal order As String) As System.Data.DataSet
      Dim ds As DataSet = MyBase.GetDataset(query, order)
      Dim rows As DataRow() = ds.Tables(0).Select("asset_isEquipment=1")
      ds.Tables(0).Rows.Clear()
      For Each row As DataRow In rows
        ds.Tables(0).Rows.Add(row)
        Debug.WriteLine(row.Item(0))
      Next
      Return ds
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetEquipment(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEntity As Equipment) As Boolean
      Dim entity As New Equipment(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not entity.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        entity = oldEntity
      End If
      txtCode.Text = entity.Code
      txtName.Text = entity.Name
      If oldEntity.Id <> entity.Id Then
        oldEntity = entity
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Equipment")

      myDatatable.Columns.Add(New DataColumn("code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("status", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("costcenter", GetType(String)))

    
      Return myDatatable
    End Function
#End Region

    Public Property ToCC As CostCenter Implements IHasToCostCenter.ToCC
      Get

      End Get
      Set(ByVal value As CostCenter)

      End Set
    End Property

    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function

    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath

    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries

    End Function

#Region "IHasEquipmentItemCollection"
    'Public Property ItemCollection As EquipmentItemCollection Implements IHasEquipmentItemCollection.ItemCollection
    '  Get
    '    Return m_itemCollection
    '  End Get
    '  Set(ByVal value As EquipmentItemCollection)
    '    m_itemCollection = value
    '  End Set
    'End Property
#End Region

    'Public ReadOnly Property Equipment As Equipment Implements IHasEquipmentItemCollection.Equipment
    '  Get

    '  End Get
    'End Property
  End Class


End Namespace
