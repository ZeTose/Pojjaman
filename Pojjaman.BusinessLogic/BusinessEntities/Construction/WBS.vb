Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class WBSStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub

    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      MyBase.New(ds, aliasPrefix)
    End Sub

    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub

#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "wbs_status"
      End Get
    End Property
#End Region

  End Class
  <AttributeUsage(AttributeTargets.Property, AllowMultiple:=False, Inherited:=True)> _
  Public Class LevelPropertyAttribute
    Inherits Attribute

#Region "Members"
    Private m_name As String
    Private m_description As String
    Private m_category As String
#End Region

#Region "Constructors"
    Public Sub New(ByVal name As String)
      Me.m_name = name
    End Sub
#End Region

#Region "Properties"
    Public Property Name() As String      Get        Return m_name      End Get      Set(ByVal Value As String)        m_name = Value      End Set    End Property    Public Property Description() As String      Get        Return m_description      End Get      Set(ByVal Value As String)        m_description = Value      End Set    End Property
    Public Property Category() As String      Get        Return m_category      End Get      Set(ByVal Value As String)        m_category = Value      End Set    End Property
#End Region

  End Class
  Public MustInherit Class BasePropertyObject
    Implements ICustomTypeDescriptor

#Region "Members"
    Private parsedProps As PropertyDescriptorCollection
#End Region

#Region "Methods"
    Public Shared Function Parse(ByVal s As String) As String
      'Todo: implements
      Return s
    End Function
#End Region

#Region "ICustomTypeDescriptor"
    Public Function GetAttributes() As System.ComponentModel.AttributeCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetAttributes
      Return TypeDescriptor.GetAttributes(Me, True)
    End Function
    Public Function GetClassName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetClassName
      Return TypeDescriptor.GetClassName(Me, True)
    End Function
    Public Function GetComponentName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetComponentName
      Return TypeDescriptor.GetComponentName(Me, True)
    End Function
    Public Function GetConverter() As System.ComponentModel.TypeConverter Implements System.ComponentModel.ICustomTypeDescriptor.GetConverter
      Return TypeDescriptor.GetConverter(Me, True)
    End Function
    Public Function GetDefaultEvent() As System.ComponentModel.EventDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent
      Return TypeDescriptor.GetDefaultEvent(Me, True)
    End Function
    Public Function GetDefaultProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty
      Return TypeDescriptor.GetDefaultProperty(Me, True)
    End Function
    Public Function GetEditor(ByVal editorBaseType As System.Type) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetEditor
      Return TypeDescriptor.GetEditor(Me, editorBaseType, True)
    End Function
    Public Overloads Function GetEvents() As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
      Return TypeDescriptor.GetEvents(Me, True)
    End Function
    Public Overloads Function GetEvents(ByVal attributes() As System.Attribute) As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
      Return TypeDescriptor.GetEvents(Me, attributes, True)
    End Function
    Public Function GetPropertyOwner(ByVal pd As System.ComponentModel.PropertyDescriptor) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner
      Return Me
    End Function

    Public Overloads Function GetProperties() As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
      Return GetFilteredProperties(Nothing)
    End Function

    Public Overloads Function GetProperties(ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
      Return GetFilteredProperties(attributes)
    End Function
    Public Function GetFilteredProperties(ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
      If parsedProps Is Nothing Then
        Dim baseProps As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me, attributes, True)
        parsedProps = New PropertyDescriptorCollection(Nothing)
        For Each oProp As PropertyDescriptor In baseProps
          Select Case oProp.Category
            Case "Data", "Configurations", "Focus", "Design", "Behavior"
            Case Else
              parsedProps.Add(New LevelPropertyDescriptor(oProp))
          End Select
        Next
      End If
      Return parsedProps
    End Function
#End Region

  End Class
  Public Class LevelPropertyDescriptor
    Inherits PropertyDescriptor

#Region "Members"
    Private m_basePropertyDescriptor As PropertyDescriptor
    Private m_parsedName As String = ""
    Private m_parsedDescription As String = ""
    Private m_parsedCategory As String = ""
#End Region

#Region "Constructors"
    Public Sub New(ByVal basePropertyDescriptor As PropertyDescriptor)
      MyBase.New(basePropertyDescriptor)
      Me.m_basePropertyDescriptor = basePropertyDescriptor
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
      Return Me.m_basePropertyDescriptor.CanResetValue(component)
    End Function

    Public Overrides ReadOnly Property ComponentType() As System.Type
      Get
        Return Me.m_basePropertyDescriptor.ComponentType
      End Get
    End Property

    Public Overrides Function GetValue(ByVal component As Object) As Object
      Return Me.m_basePropertyDescriptor.GetValue(component)
    End Function

    Public Overrides ReadOnly Property IsReadOnly() As Boolean
      Get
        Return Me.m_basePropertyDescriptor.IsReadOnly
      End Get
    End Property

    Public Overrides ReadOnly Property PropertyType() As System.Type
      Get
        Return Me.m_basePropertyDescriptor.PropertyType
      End Get
    End Property

    Public Overrides Sub ResetValue(ByVal component As Object)
      Me.m_basePropertyDescriptor.ResetValue(component)
    End Sub

    Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
      Me.m_basePropertyDescriptor.SetValue(component, value)
    End Sub

    Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
      Return Me.m_basePropertyDescriptor.ShouldSerializeValue(component)
    End Function

    Public Overrides ReadOnly Property Name() As String
      Get
        Return Me.m_basePropertyDescriptor.Name
      End Get
    End Property
#End Region

#Region "Parsing"
    Private Function Parse(ByVal s As String) As String
      'Todo : Implement!!!
      Select Case s.ToLower
        Case "appearance"
          s = "ลักษณะ"
        Case "layout"
          s = "การจัดวาง"
        Case "design"
          s = "การออกแบบ"
        Case "behavior"
          s = "พฤติกรรม"
        Case Else
      End Select

      Return s
    End Function
    Public Overrides ReadOnly Property DisplayName() As String
      Get
        Dim myDisplayName As String = ""
        For Each oAtt As Attribute In Me.m_basePropertyDescriptor.Attributes
          If TypeOf oAtt Is LevelPropertyAttribute Then
            myDisplayName = CType(oAtt, LevelPropertyAttribute).Name
          End If
        Next
        If myDisplayName.Length = 0 Then
          myDisplayName = Me.m_basePropertyDescriptor.DisplayName
        End If
        myDisplayName = Me.Parse(myDisplayName)
        If myDisplayName Is Nothing Then
          Me.m_parsedName = Me.m_basePropertyDescriptor.DisplayName
        Else
          Me.m_parsedName = myDisplayName
        End If
        Return Me.m_parsedName
      End Get
    End Property

    Public Overrides ReadOnly Property Description() As String
      Get
        Dim myDescription As String = ""
        For Each oAtt As Attribute In Me.m_basePropertyDescriptor.Attributes
          If TypeOf oAtt Is LevelPropertyAttribute Then
            myDescription = CType(oAtt, LevelPropertyAttribute).Description
          End If
        Next
        If myDescription.Length = 0 Then
          myDescription = Me.m_basePropertyDescriptor.DisplayName & "Description"
        End If
        myDescription = Me.Parse(myDescription)
        If myDescription Is Nothing Then
          Me.m_parsedDescription = Me.m_basePropertyDescriptor.Description
        Else
          Me.m_parsedDescription = myDescription
        End If
        Return Me.m_parsedDescription
      End Get
    End Property

    Public Overrides ReadOnly Property Category() As String
      Get
        Dim myCategory As String = ""
        For Each oAtt As Attribute In Me.m_basePropertyDescriptor.Attributes
          If TypeOf oAtt Is LevelPropertyAttribute Then
            myCategory = CType(oAtt, LevelPropertyAttribute).Category
            Exit For
          End If
          If TypeOf oAtt Is CategoryAttribute Then
            myCategory = CType(oAtt, CategoryAttribute).Category
          End If
        Next
        If myCategory Is Nothing OrElse myCategory.Length = 0 Then
          myCategory = Me.m_basePropertyDescriptor.Category
        End If
        myCategory = Me.Parse(myCategory)
        If myCategory Is Nothing Then
          Me.m_parsedCategory = Me.m_basePropertyDescriptor.Category
        Else
          Me.m_parsedCategory = myCategory
        End If
        Return Me.m_parsedCategory
      End Get
    End Property
#End Region


  End Class
  Public Class LevelConfig
    Inherits BasePropertyObject

#Region "Enum"
    Public Enum LineStyle
      Solid
      [Double]
    End Enum
    Public Enum SumPosition
      None
      Top
      Bottom
    End Enum
#End Region

#Region "Members"
    Private m_font As Font
    Private m_foreColor As Color
    Private m_borderColor As Color
    Private m_backColor As Color
    Private m_lineStyle As LineStyle
    Private m_level As Integer
    Private m_penWidth As Single
    Private m_LevelSumPositon As SumPosition
    Private m_newPage As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      Me.New(0)
    End Sub
    Public Sub New(ByVal level As Integer)
      m_level = level
      m_font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      m_borderColor = SystemColors.ControlText
      m_backColor = SystemColors.Window
      m_foreColor = SystemColors.WindowText
      m_lineStyle = LineStyle.Solid
      m_LevelSumPositon = SumPosition.None
      m_penWidth = 1
      m_newPage = False
    End Sub
#End Region

#Region "Properties"
    <Browsable(False)> _
    Public Property Level() As Integer      Get        Return m_level      End Get      Set(ByVal Value As Integer)        m_level = Value      End Set    End Property
    <LevelProperty("ขึ้นหน้าใหม่", Description:="ขึ้นหน้าใหม่", Category:="รูปแบบ")> _
    Public Property NewPage() As Boolean      Get        Return m_newPage      End Get      Set(ByVal Value As Boolean)        m_newPage = Value      End Set    End Property    <LevelProperty("ผลรวม", Description:="ตำแหน่งผลรวม", Category:="รูปแบบ")> _
    Public Property LevelSumPositon() As SumPosition      Get        Return m_LevelSumPositon      End Get      Set(ByVal Value As SumPosition)        m_LevelSumPositon = Value      End Set    End Property    <LevelProperty("ความหนาเส้น", Description:="ความหนาของเส้นขอบ", Category:="เส้น")> _
    Public Property PenWidth() As Single      Get        Return m_penWidth      End Get      Set(ByVal Value As Single)        m_penWidth = Value      End Set    End Property
    <LevelProperty("สีของเส้นขอบ", Description:="สีของเส้นขอบ", Category:="ลักษณะ")> _
    Public Property BorderColor() As Color      Get        Return m_borderColor      End Get      Set(ByVal Value As Color)        m_borderColor = Value      End Set    End Property    <LevelProperty("สีพื้น", Description:="สีพื้น", Category:="ลักษณะ")> _
    Public Property BackColor() As System.Drawing.Color
      Get
        Return m_backColor
      End Get
      Set(ByVal Value As System.Drawing.Color)
        m_backColor = Value
      End Set
    End Property
    <LevelProperty("สีของตัวอักษร", Description:="สีของตัวอักษร", Category:="ลักษณะ")> _
    Public Property ForeColor() As System.Drawing.Color
      Get
        Return m_foreColor
      End Get
      Set(ByVal Value As System.Drawing.Color)
        m_foreColor = Value
      End Set
    End Property
    <LevelProperty("ฟ้อนท์", Description:="ฟ้อนท์", Category:="ลักษณะ")> _
    Public Property Font() As System.Drawing.Font
      Get
        Return Me.m_font
      End Get
      Set(ByVal Value As System.Drawing.Font)
        Me.m_font = Value
      End Set
    End Property
    <LevelProperty("เส้น", Description:="ลักษณะของเส้นตาราง", Category:="เส้น")> _
    Public Property LevelLineStyle() As LineStyle
      Get
        Return Me.m_lineStyle
      End Get
      Set(ByVal Value As LineStyle)
        Me.m_lineStyle = Value
      End Set
    End Property
    <Browsable(False)> _
    Public Overrides Function ToString() As String
      Return Space(Me.Level * 3) & "Level " & Me.Level.ToString
    End Function
#End Region

  End Class
  Public Class WBS
    Inherits TreeBaseEntity
    Implements IDisposable

#Region "Member"
    Private m_boq As Boq
    Private m_note As String
    Private m_status As WBSStatus
    Private m_state As RowExpandState
    Private m_milestone As Milestone
    Private m_noQtyControl As Boolean 'ไม่คุมปริมาณ
    Private m_startdate As Date
    Private m_finishdate As Date

    Private m_qty As Decimal 'ปริมาณ

    Private m_unit As Unit
    Private m_ListNumber As String
    Private m_direction As Byte
    Private m_referenced As Boolean

    Private m_mcbs As CBS
    Private m_lcbs As CBS
    Private m_ecbs As CBS
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As WBS)
      MyBase.New(myParent)
      Me.Level = myParent.Level + 1
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal boq As Boq)
      Me.m_boq = boq
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_status = New WBSStatus(-1)
        .m_state = RowExpandState.Expanded
        m_milestone = New Milestone
        .m_noQtyControl = False
        .m_startdate = Now
        .m_finishdate = Now
        .m_qty = 0
        .m_unit = New Unit

        .m_mcbs = New CBS
        .m_lcbs = New CBS
        .m_ecbs = New CBS
      End With
    End Sub
    Private m_dr As DataRow
    Private m_aliasPrefix As String = ""
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)

      Dim drh As New DataRowHelper(dr)

      If dr.Table.Columns.Contains(aliasPrefix & "wbs_note") AndAlso Not dr.IsNull(aliasPrefix & "wbs_note") Then
        Me.m_note = CStr(dr(aliasPrefix & "wbs_note"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "wbs_status") AndAlso Not dr.IsNull(aliasPrefix & "wbs_status") Then
        Me.m_status.Value = CInt(dr(aliasPrefix & "wbs_status"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "wbs_state") AndAlso Not dr.IsNull(aliasPrefix & "wbs_state") Then
        Me.m_state = CType([Enum].Parse(GetType(RowExpandState), CStr(dr(aliasPrefix & "wbs_state"))), RowExpandState)
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "parent_state") AndAlso Not dr.IsNull(aliasPrefix & "parent_state") Then
        If TypeOf Me.Parent Is WBS Then
          CType(Me.Parent, WBS).State = CType([Enum].Parse(GetType(RowExpandState), CStr(dr(aliasPrefix & "parent_state"))), RowExpandState)
        End If
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "wbs_noQtyControl") AndAlso Not dr.IsNull(aliasPrefix & "wbs_noQtyControl") Then
        Me.m_noQtyControl = CBool(dr(aliasPrefix & "wbs_noQtyControl"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "wbs_startdate") AndAlso Not dr.IsNull(aliasPrefix & "wbs_startdate") Then
        Me.m_startdate = CDate(dr(aliasPrefix & "wbs_startdate"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "wbs_finishdate") AndAlso Not dr.IsNull(aliasPrefix & "wbs_finishdate") Then
        Me.m_finishdate = CDate(dr(aliasPrefix & "wbs_finishdate"))
      End If

      If dr.Table.Columns.Contains(aliasPrefix & "wbs_qty") AndAlso Not dr.IsNull(aliasPrefix & "wbs_qty") Then
        Me.m_qty = CDec(dr(aliasPrefix & "wbs_qty"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
        If Not dr.IsNull("unit_id") Then
          m_unit = New Unit(dr, aliasPrefix)
        End If
      Else
        If dr.Table.Columns.Contains(aliasPrefix & "wbs_unit") AndAlso Not dr.IsNull(aliasPrefix & "wbs_unit") Then
          m_unit = New Unit(CInt(dr(aliasPrefix & "wbs_unit")))
        End If
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "wbs_number") AndAlso Not dr.IsNull(aliasPrefix & "wbs_number") Then
        m_ListNumber = dr(aliasPrefix & "wbs_number").ToString
      End If
      If dr.Table.Columns.Contains("isReference") AndAlso Not dr.IsNull("isReference") Then
        m_referenced = CBool(dr("isReference").ToString)
      End If

      m_mcbs = New CBS(drh.GetValue(Of Integer)("boqi_mcbs"))
      m_lcbs = New CBS(drh.GetValue(Of Integer)("boqi_lcbs"))
      m_ecbs = New CBS(drh.GetValue(Of Integer)("boqi_ecbs"))

      m_dr = dr
      m_aliasPrefix = aliasPrefix
      'LoadMileStone()
    End Sub
    Public Sub LoadMileStone()
      If m_dr Is Nothing Then
        Return
      End If
      If m_dr.Table.Columns.Contains("milestone_id") Then
        If Not m_dr.IsNull("milestone_id") Then
          m_milestone = New Milestone(m_dr, "")
        End If
      Else
        If m_dr.Table.Columns.Contains(m_aliasPrefix & "wbs_milestone") AndAlso Not m_dr.IsNull(m_aliasPrefix & "wbs_milestone") Then
          m_milestone = New Milestone(CInt(m_dr(m_aliasPrefix & "wbs_milestone")))
        End If
      End If
    End Sub
#End Region

#Region "Properties"
    Private m_childs As WBSCollection
    Public Property Childs() As WBSCollection
      Get
        If m_childs Is Nothing Then
          m_childs = New WBSCollection
        End If
        Return m_childs
      End Get
      Set(ByVal Value As WBSCollection)
        m_childs = Value
      End Set
    End Property
    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        m_unit = Value      End Set    End Property
    Public Property Boq() As BOQ      Get        Return m_boq      End Get      Set(ByVal Value As BOQ)        m_boq = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property NoQtyControl() As Boolean      Get        Return m_noQtyControl      End Get      Set(ByVal Value As Boolean)        m_noQtyControl = Value        Try          Dim coll As WBSCollection = Me.Childs
          For Each child As WBS In coll
            child.m_noQtyControl = m_noQtyControl
          Next
        Catch ex As Exception

        End Try      End Set    End Property    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        m_qty = Value      End Set    End Property    Public ReadOnly Property AllQty() As Decimal      Get
        Dim myWBS As WBS = Me
        Dim root As WBS = myWBS.Boq.WBSCollection.GetRoot
        Dim theQty As Decimal = 1
        Do Until myWBS Is root
          Dim tmp As WBS = myWBS
          myWBS = myWBS.Boq.WBSCollection.GetParentOf(myWBS)
          If tmp.Qty <> 0 Then
            theQty *= tmp.Qty
          End If
        Loop
        If root.Qty <> 0 Then
          theQty *= root.Qty
        End If
        Return theQty
      End Get
    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, WBSStatus)      End Set    End Property    Public Property State() As RowExpandState      Get        Return m_state      End Get      Set(ByVal Value As RowExpandState)        m_state = Value      End Set    End Property    Public Property Milestone() As Milestone      Get        Return m_milestone      End Get      Set(ByVal Value As Milestone)        m_milestone = Value      End Set    End Property    Public Property StartDate() As Date      Get
        Return m_startdate
      End Get
      Set(ByVal Value As Date)
        m_startdate = Value
      End Set
    End Property    Public Property FinishDate() As Date
      Get
        Return m_finishdate
      End Get
      Set(ByVal Value As Date)
        m_finishdate = Value
      End Set
    End Property    Public ReadOnly Property IsVisible() As Boolean      Get
        Dim par As WBS = Me.Boq.WBSCollection(CType(Me.Parent, WBS))
        Do While (Not par Is Nothing) AndAlso (Not par Is par.Parent) AndAlso (par.Id <> par.Parent.Id)
          If par.State = RowExpandState.Collapsed Then
            Return False
          End If
          par = Me.Boq.WBSCollection(CType(par.Parent, WBS))
        Loop
        Return True
      End Get
    End Property    Public Property ListNumber() As String      Get
        Return m_ListNumber
      End Get
      Set(ByVal Value As String)
        m_ListNumber = Value
      End Set
    End Property    Public Property Direction() As Byte
      Get
        Return m_direction
      End Get
      Set(ByVal Value As Byte)
        m_direction = Value
      End Set
    End Property    Public Property Referenced As Boolean      Get
        Return m_referenced
      End Get
      Set(ByVal value As Boolean)
        m_referenced = value
      End Set
    End Property    Public Property OwnerMatBudgetAmount As Decimal    Public Property OwnerLabBudgetAmount As Decimal    Public Property OwnerEqBudgetAmount As Decimal    Public Property MatCBS As CBS
      Get
        Return m_mcbs
      End Get
      Set(ByVal value As CBS)
        m_mcbs = value
      End Set
    End Property
    Public Property LabCBS As CBS
      Get
        Return m_lcbs
      End Get
      Set(ByVal value As CBS)
        m_lcbs = value
      End Set
    End Property
    Public Property EqCBS As CBS
      Get
        Return m_ecbs
      End Get
      Set(ByVal value As CBS)
        m_ecbs = value
      End Set
    End Property#Region "Cost Control"    Public Shared WBSReportType As BOQ.WBSReportType = WBSReportType.GoodsReceipt    Public Shared Function GetAmountFromSproc(ByVal sproc As String, ByVal toDate As Date, ByVal id As Integer, ByVal isMarkup As Boolean, ByVal view As Integer, ByVal requestor As Integer) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@stockiw_wbs", id) _
                , New SqlParameter("@toDate", toDate) _
                , New SqlParameter("@stockiw_ismarkup", isMarkup) _
                , New SqlParameter("@view", view) _
                , New SqlParameter("@requestor", IIf(requestor = -99, DBNull.Value, requestor)) _
                )
        Dim tableIndex As Integer = 0
        'Select Case WBSReportType
        '    Case WBSReportType.GoodsReceipt, WBSReportType.MatWithdraw
        '        tableIndex = 0
        '    Case WBSReportType.PR
        '        tableIndex = 1
        '    Case WBSReportType.PO
        '        tableIndex = 2
        'End Select
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
    End Function    Public Shared Function GetTableFromSproc(ByVal sproc As String, ByVal toDate As Date, ByVal id As Integer, ByVal isMarkup As Boolean, ByVal view As Integer, ByVal requestor As Integer) As DataTable      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@stockiw_wbs", id) _
                , New SqlParameter("@toDate", toDate) _
                , New SqlParameter("@stockiw_ismarkup", isMarkup) _
                , New SqlParameter("@view", view) _
                , New SqlParameter("@requestor", IIf(requestor = -99, DBNull.Value, requestor)) _
                )
        Dim tableIndex As Integer = 0
        'Select Case WBSReportType
        '    Case WBSReportType.GoodsReceipt, WBSReportType.MatWithdraw
        '        tableIndex = 0
        '    Case WBSReportType.PR
        '        tableIndex = 1
        '    Case WBSReportType.PO
        '        tableIndex = 2
        'End Select
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            Return ds.Tables(tableIndex)
          End If
        End If
      Catch ex As Exception
      End Try
    End Function    Public Shared Function GetTableFromSproc(ByVal sproc As String, ByVal toDate As Date, ByVal id As Integer, ByVal isMarkup As Boolean, ByVal view As Integer, ByVal docId As Integer, ByVal requestor As Integer) As DataTable      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@stockiw_wbs", id) _
                , New SqlParameter("@toDate", toDate) _
                , New SqlParameter("@stockiw_ismarkup", isMarkup) _
                , New SqlParameter("@view", view) _
                , New SqlParameter("@docId", docId) _
                , New SqlParameter("@requestor", IIf(requestor = -99, DBNull.Value, requestor)) _
                )
        Dim tableIndex As Integer = 0
        'Select Case WBSReportType
        '    Case WBSReportType.GoodsReceipt, WBSReportType.MatWithdraw
        '        tableIndex = 0
        '    Case WBSReportType.PR
        '        tableIndex = 1
        '    Case WBSReportType.PO
        '        tableIndex = 2
        'End Select
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            Return ds.Tables(tableIndex)
          End If
        End If
      Catch ex As Exception
      End Try
    End Function    Public Shared Function GetAmountFromSproc(ByVal sproc As String, ByVal id As Integer _    , ByVal isMarkup As Boolean, ByVal view As Integer, ByVal stockId As Integer, ByVal requestor As Integer) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@stockiw_wbs", id) _
                , New SqlParameter("@stockiw_ismarkup", isMarkup) _
                , New SqlParameter("@view", view) _
                , New SqlParameter("@stock_id", stockId) _
                , New SqlParameter("@requestor", IIf(requestor = -99, DBNull.Value, requestor)) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
    End Function#Region "Total"#Region "Performance"    Public Function GetWBSActualFromDB(ByVal Id As Integer, ByVal entityId As Integer _                                        , ByVal ItemTypeId As Integer) As Decimal      Return GetWBSActualFromDB(Id, entityId, ItemTypeId, False)
    End Function    Public Function GetWBSActualFromDB(ByVal Id As Integer, ByVal entityId As Integer _                                        , ByVal ItemTypeId As Integer, ByVal direction As Boolean) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetWBSActualRemain" _
                , New SqlParameter("@id", Id) _
                , New SqlParameter("@entityId", entityId) _
                , New SqlParameter("@wbsid", Me.Id) _
                , New SqlParameter("@itemTypeId", ItemTypeId) _
                , New SqlParameter("@direction", direction) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function    Public Function GetWBSMarkUpActualFromDB(ByVal Id As Integer, ByVal entityId As Integer _                                      , ByVal ItemTypeId As Integer, ByVal direction As Boolean) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetWBSMarkUpActualRemain" _
                , New SqlParameter("@id", Id) _
                , New SqlParameter("@entityId", entityId) _
                , New SqlParameter("@wbsid", Me.Id) _
                , New SqlParameter("@itemTypeId", ItemTypeId) _
                , New SqlParameter("@direction", direction) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function    Public Function GetWBSQtyActualFromDB(ByVal Id As Integer, ByVal docType As Integer _                                         , ByVal itemId As Integer, ByVal ItemTypeId As Integer, ByVal itemName As String) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetWBSQtyActualRemain" _
                , New SqlParameter("@id", Id) _
                , New SqlParameter("@docType", docType) _
                , New SqlParameter("@wbsid", Me.Id) _
                , New SqlParameter("@entity", itemId) _
                , New SqlParameter("@entityType", ItemTypeId) _
                , New SqlParameter("@entityName", itemName) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function    Public Function GetTotalMatFromDB() As Decimal      Dim dt As DataTable = GetBudgetFromDB("mat")      For Each row As DataRow In dt.Rows        Dim drh As New DataRowHelper(row)
        Me.OwnerMatBudgetAmount = drh.GetValue(Of Decimal)("mat")
        Return drh.GetValue(Of Decimal)("mat") + drh.GetValue(Of Decimal)("childmat")
      Next      'Try
      '  Dim ds As DataSet = SqlHelper.ExecuteDataset( _
      '          ConnectionString _
      '          , CommandType.Text _
      '          , "select isnull(wbs_umcbudget,0) + isnull(wbs_childumcbudget,0) from" & _
      '          " swang_wbsbudget where wbs_id = '" & Me.Id.ToString & "'" _
      '          )
      '  Dim tableIndex As Integer = 0
      '  If ds.Tables.Count > tableIndex Then
      '    If ds.Tables(tableIndex).Rows.Count > 0 Then
      '      If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
      '        Return 0
      '      End If
      '      Return CDec(ds.Tables(tableIndex).Rows(0)(0))
      '    End If
      '  End If
      'Catch ex As Exception
      'End Try
      Return 0
    End Function    Public Function GetBudgetFromDB(ByVal budgetType As String) As DataTable      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetBudgetFromDB" _
                , New SqlParameter("@budgetType", budgetType.ToLower) _
                , New SqlParameter("@wbs_id", Me.Id.ToString) _
                )
        If ds.Tables.Count > 0 Then
          Return ds.Tables(0)
        End If
      Catch ex As Exception
      End Try
      Return New DataTable
    End Function    Public Function GetTotalMatQtyFromDB(ByVal matId As Integer) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetQtyInBoqForWbs" _
                , New SqlParameter("@wbs_id", Me.Id) _
                , New SqlParameter("@lci_id", matId) _
                , New SqlParameter("@type", 42) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function

    Public Function GetTotalLabFromDB() As Decimal      Dim dt As DataTable = GetBudgetFromDB("lab")      For Each row As DataRow In dt.Rows        Dim drh As New DataRowHelper(row)
        Me.OwnerLabBudgetAmount = drh.GetValue(Of Decimal)("lab")
        Return drh.GetValue(Of Decimal)("lab") + drh.GetValue(Of Decimal)("childlab")
      Next      'Try
      '  Dim ds As DataSet = SqlHelper.ExecuteDataset( _
      '          ConnectionString _
      '          , CommandType.Text _
      '          , "select isnull(wbs_ulcbudget,0) + isnull(wbs_childulcbudget,0) from" & _
      '          " swang_wbsbudget where wbs_id = '" & Me.Id.ToString & "'" _
      '          )
      '  Dim tableIndex As Integer = 0
      '  If ds.Tables.Count > tableIndex Then
      '    If ds.Tables(tableIndex).Rows.Count > 0 Then
      '      If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
      '        Return 0
      '      End If
      '      Return CDec(ds.Tables(tableIndex).Rows(0)(0))
      '    End If
      '  End If
      'Catch ex As Exception
      'End Try
      'Return 0
    End Function    Public Function GetTotalLabQtyFromDB(ByVal name As String) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetQtyInBoqForWbs" _
                , New SqlParameter("@wbs_id", Me.Id) _
                , New SqlParameter("@name", name) _
                , New SqlParameter("@type", 18) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function

    Public Function GetTotalEQFromDB() As Decimal      Dim dt As DataTable = GetBudgetFromDB("eq")      For Each row As DataRow In dt.Rows        Dim drh As New DataRowHelper(row)
        Me.OwnerEqBudgetAmount = drh.GetValue(Of Decimal)("eq")
        Return drh.GetValue(Of Decimal)("eq") + drh.GetValue(Of Decimal)("childeq")
      Next      'Try
      '  Dim ds As DataSet = SqlHelper.ExecuteDataset( _
      '          ConnectionString _
      '          , CommandType.Text _
      '          , "select isnull(wbs_uecbudget,0) + isnull(wbs_childuecbudget,0) from" & _
      '          " swang_wbsbudget where wbs_id = '" & Me.Id.ToString & "'" _
      '          )
      '  Dim tableIndex As Integer = 0
      '  If ds.Tables.Count > tableIndex Then
      '    If ds.Tables(tableIndex).Rows.Count > 0 Then
      '      If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
      '        Return 0
      '      End If
      '      Return CDec(ds.Tables(tableIndex).Rows(0)(0))
      '    End If
      '  End If
      'Catch ex As Exception
      'End Try
      'Return 0
    End Function    Public Function GetTotalEQQtyFromDB(ByVal name As String) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetQtyInBoqForWbs" _
                , New SqlParameter("@wbs_id", Me.Id) _
                , New SqlParameter("@name", name) _
                , New SqlParameter("@type", 20) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function

    Public Function GetBudgetQtyForType0FromDB(ByVal name As String) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetQtyInBoqForWbs" _
                , New SqlParameter("@wbs_id", Me.Id) _
                , New SqlParameter("@name", name) _
                , New SqlParameter("@type", 0) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function

    Public Function GetTotalMarkUpFromDB() As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.Text _
                , "select isnull(markup_totalamt,0) [budget] " & _
                " from markup where markup_id = " & Me.Id.ToString & "" _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function

    Public Function GetTotalParentBudget() As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.Text _
                , "select isnull(wbs_umcbudget,0) + isnull(wbs_ulcbudget,0) + isnull(wbs_uecbudget,0) " & _
                " from swang_wbsbudget where wbs_id = '" & Me.Id.ToString & "'" _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function

    Public Function GetBoqItemConversion(ByVal lci_id As Integer, ByVal unit_id As Integer, ByVal entityType As Integer) As Decimal      If lci_id = 0 OrElse unit_id = 0 Then        Return 0
      End If      If entityType <> 42 Then        Return 1
      End If      Dim conversion As Decimal = LCIItem.GetLciConversionByIdUnitId(lci_id, unit_id)
      If conversion <> 0 Then
        Return conversion
      End If      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetLciConversionbyView" _
                , New SqlParameter("@lci_id", lci_id) _
                , New SqlParameter("@unit_id", unit_id) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function
    Public Function GetBudget(ByVal wbs_id As Integer, ByVal wbs_boq As Integer, ByVal type As Integer) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetBudget" _
                , New SqlParameter("@wbs_id", wbs_id) _
                , New SqlParameter("@wbs_boq", wbs_boq) _
                , New SqlParameter("@type", type) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function
    Public Function GetThisDocActualFromDB(ByVal docType As Integer, ByVal docId As Integer, ByVal ccId As Integer) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetThisDocActualFromDB" _
                , New SqlParameter("@docType", docType) _
                , New SqlParameter("@docId", docId) _
                , New SqlParameter("@ccId", ccId) _
                )

        Return CDec(ds.Tables(0).Rows(0)(0))

      Catch ex As Exception
      End Try
      Return 0
    End Function
    Public Function GetWBSRootId() As Integer
      ''เพื่อความเร็ว
      If Me.Path Is Nothing OrElse Me.Path.Length = 0 Then
        Return 0
      End If
      Dim pathx As String = Me.Path
      Dim rep0x As String = pathx.Replace("||", ",")
      Dim rep1x As String = rep0x.Replace("|", "")
      Dim splitx() As String = rep1x.Split(","c)
      If splitx(0).Length > 0 Then
        Return CInt(splitx(0))
      Else
        Return 0
      End If
    End Function
#End Region    Private m_totalMat As Nullable(Of Decimal)    Public Function GetTotalMat() As Decimal      If m_totalMat.HasValue Then
        Return m_totalMat.Value
      End If      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetTotalMat
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetTotalMat
      items = Nothing
      m_totalMat = ret
      Return ret
    End Function    Public Function GetTotalMatQty(ByVal matId As Integer) As Decimal      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetTotalMatQty(matId)
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetTotalMatQty(matId)
      items = Nothing
      Return ret
    End Function    Public Function GetFinalMat() As Decimal      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetFinalMat
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetFinalMat
      items = Nothing
      Return ret
    End Function    Private m_totalLab As Nullable(Of Decimal)    Public Function GetTotalLab() As Decimal      If m_totalLab.HasValue Then
        Return m_totalLab.Value
      End If      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetTotalLab
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetTotalLab
      items = Nothing
      m_totalLab = ret
      Return ret
    End Function    Public Function GetTotalLabQty(ByVal name As String) As Decimal      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetTotalLabQty(name)
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetTotalLabQty(name)
      items = Nothing
      Return ret
    End Function    Public Function GetFinalLab() As Decimal      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetFinalLab
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetFinalLab
      items = Nothing
      Return ret
    End Function
    Private m_totalEQ As Nullable(Of Decimal)
    Public Function GetTotalEq() As Decimal      If m_totalEQ.HasValue Then
        Return m_totalEQ.Value
      End If      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetTotalEq
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetTotalEq
      items = Nothing
      m_totalEQ = ret
      Return ret
    End Function    Public Function GetTotalEqQty(ByVal name As String) As Decimal      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetTotalEqQty(name)
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetTotalEqQty(name)
      items = Nothing
      Return ret
    End Function    Public Function GetFinalEq() As Decimal      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetFinalEq
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetFinalEq
      items = Nothing
      Return ret
    End Function
    Public Function GetTotalSameMilestone() As Decimal      Dim ret As Decimal = 0
      Me.LoadMileStone()
      For Each myWbs As WBS In Me.Boq.WBSCollection.GetCollectionWithSameMilestone(Me.Milestone)
        Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(myWbs)
        ret += items.GetTotal
        items = Nothing
      Next
      Return ret
    End Function
    Public Function GetTotalNochild() As Decimal      Dim ret As Decimal = 0
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetTotal
      items = Nothing
      Return ret
    End Function
    Private m_total As Nullable(Of Decimal)
    Public Function GetTotal() As Decimal      If m_total.HasValue Then
        Return m_total.Value
      End If      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetTotal
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetTotal
      items = Nothing
      m_total = ret
      Return ret
    End Function
    Private m_totalPerWbs As Nullable(Of Decimal)
    Public Function GetTotalPerWBS() As Decimal      If m_totalPerWbs.HasValue Then
        Return m_totalPerWbs.Value
      End If      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += (child.GetTotalPerWBS * child.Qty)
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetTotalPerWbs
      items = Nothing
      m_totalPerWbs = ret
      Return ret
    End Function
    Public Function GetFinalTotal() As Decimal      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetFinalTotal
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetFinalTotal
      items = Nothing
      Return ret
    End Function
    Public Function GetBudgetQtyForType0(ByVal name As String) As Decimal
      Dim childs As WBSCollection = Me.Childs
      Dim ret As Decimal = 0
      For Each child As WBS In childs
        ret += child.GetBudgetQtyForType0(name)
      Next
      childs = Nothing
      Dim items As BoqItemCollection = Me.Boq.ItemCollection.GetCollectionForWBS(Me)
      ret += items.GetBudgetQtyForType0(name)
      items = Nothing
      Return ret
    End Function
#End Region#Region "ActualStock"    Public Function GetActualMat(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Dim ret As Decimal = 0
      'Dim childs As WBSCollection = Me.Childs
      'For Each child As WBS In childs
      '    ret += child.GetActualMat(toDate, view)
      'Next
      'childs = Nothing
      Return ret + GetAmountFromSproc("GetMatAmountForWbs", toDate, Me.Id, False, view, requestor)
    End Function    Public Function GetActualMat(ByVal stock As ISimpleEntity, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      'Dim ret As Decimal = 0
      'Return ret + GetAmountFromSproc("GetMatAmountForWbsWithoutThisStock", Me.Id, False, view, stock.Id, requestor)

      Try
        Dim tb As String = ""
        Select Case view
          Case 7
            tb = "pr"
          Case 6
            tb = "po"
          Case 45
            If TypeOf stock Is MatWithdraw OrElse TypeOf stock Is MatReturn Then
              'Return GetAmountFromSproc("GetMatAmountForWbsWithoutThisStock", Me.Id, False, view, stock.Id, requestor)
              tb = "mat"
            End If
            tb = "gr"
          Case 31
            'Return GetAmountFromSproc("GetMatAmountForWbsWithoutThisStock", Me.Id, False, view, stock.Id, requestor)
            tb = "mat"
        End Select
        'Dim ds As DataSet = SqlHelper.ExecuteDataset( _
        '        ConnectionString _
        '        , CommandType.Text _
        '        , "select isnull(wbs_matactual,0) + isnull(wbs_childmatactual,0)  from" & _
        '        " swang_" & tb & "_wbsactual where wbs_id = '" & Me.Id.ToString & "'" _
        '        )
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
        ConnectionString _
        , CommandType.Text _
        , "select isnull(matactual,0)  from" & _
        " swang_" & tb & "_wbsrealactual where wbs_id = '" & Me.Id.ToString & "'" _
        )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function    Public Function GetActualMatQty(ByVal stock As ISimpleEntity, ByVal view As Integer, ByVal entityId As Integer, ByVal entityType As Integer) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetMatQtyForWbsWithoutThisStock" _
                , New SqlParameter("@stockiw_wbs", Me.Id) _
                , New SqlParameter("@stockiw_ismarkup", False) _
                , New SqlParameter("@view", view) _
                , New SqlParameter("@stock_id", stock.Id) _
                , New SqlParameter("@entityId", entityId) _
                , New SqlParameter("@entityType", entityType) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try      Return 0
    End Function    Public Function GetActualDocTable(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As DataTable      Return GetTableFromSproc("GetDocsForWbs", toDate, Me.Id, False, view, requestor)
    End Function
    Public Function GetActualItemTable(ByVal toDate As Date, ByVal view As Integer, ByVal docId As Integer, Optional ByVal requestor As Integer = -99) As DataTable      Return GetTableFromSproc("GetItemsForWbs", toDate, Me.Id, False, view, docId, requestor)
    End Function
    Public Function GetActualItemOnlyTable(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As DataTable      Return GetTableFromSproc("GetItemsOnlyForWbs", toDate, Me.Id, False, view, requestor)
    End Function
    Public Function GetActualLab(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Dim ret As Decimal = 0
      Return ret + GetAmountFromSproc("GetLabAmountForWbs", toDate, Me.Id, False, view, requestor)
    End Function    Public Function GetActualLab(ByVal stock As ISimpleEntity, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      'Dim ret As Decimal = 0
      'Return ret + GetAmountFromSproc("GetLabAmountForWbsWithoutThisStock", Me.Id, False, view, stock.Id, requestor)
      Try
        Dim tb As String = ""
        Select Case view
          Case 7
            tb = "pr"
          Case 6
            tb = "po"
          Case 45
            tb = "gr"
          Case 31
            Return GetAmountFromSproc("GetLabAmountForWbsWithoutThisStock", Me.Id, False, view, stock.Id, requestor)
        End Select
        'Dim ds As DataSet = SqlHelper.ExecuteDataset( _
        '        ConnectionString _
        '        , CommandType.Text _
        '        , "select isnull(wbs_labactual,0) + isnull(wbs_childlabactual,0)  from" & _
        '        " swang_" & tb & "_wbsactual where wbs_id = '" & Me.Id.ToString & "'" _
        '        )
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
        ConnectionString _
        , CommandType.Text _
        , "select isnull(labactual,0)  from" & _
        " swang_" & tb & "_wbsrealactual where wbs_id = '" & Me.Id.ToString & "'" _
        )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function    Public Function GetActualLabQty(ByVal stock As ISimpleEntity, ByVal view As Integer) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetLabQtyForWbsWithoutThisStock" _
                , New SqlParameter("@stockiw_wbs", Id) _
                , New SqlParameter("@stockiw_ismarkup", False) _
                , New SqlParameter("@view", view) _
                , New SqlParameter("@stock_id", stock.Id) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
    End Function
    Public Function GetActualEq(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Dim ret As Decimal = 0
      'Dim childs As WBSCollection = Me.Childs
      'For Each child As WBS In childs
      '    ret += child.GetActualEq(toDate, view)
      'Next
      'childs = Nothing
      Return ret + GetAmountFromSproc("GetEqAmountForWbs", toDate, Me.Id, False, view, requestor)
    End Function    Public Function GetActualEq(ByVal stock As ISimpleEntity, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Try
        Dim tb As String = ""
        Select Case view
          Case 7
            tb = "pr"
          Case 6
            tb = "po"
          Case 45
            tb = "gr"
          Case 31
            Return GetAmountFromSproc("GetEqAmountForWbsWithoutThisStock", Me.Id, False, view, stock.Id, requestor)
        End Select
        'Dim ds As DataSet = SqlHelper.ExecuteDataset( _
        '        ConnectionString _
        '        , CommandType.Text _
        '        , "select isnull(wbs_eqactual,0) + isnull(wbs_childeqactual,0)  from" & _
        '        " swang_" & tb & "_wbsactual where wbs_id = '" & Me.Id.ToString & "'" _
        '        )
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
        ConnectionString _
        , CommandType.Text _
        , "select isnull(eqactual,0)  from" & _
        " swang_" & tb & "_wbsrealactual where wbs_id = '" & Me.Id.ToString & "'" _
        )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function    Public Function GetActualEqQty(ByVal stock As ISimpleEntity, ByVal view As Integer) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetEqQtyForWbsWithoutThisStock" _
                , New SqlParameter("@stockiw_wbs", Id) _
                , New SqlParameter("@stockiw_ismarkup", False) _
                , New SqlParameter("@view", view) _
                , New SqlParameter("@stock_id", stock.Id) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
    End Function
    Public Function GetActualIncome(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Dim ret As Decimal = 0
      Dim total As Decimal = Me.GetTotalNochild
      Dim totalMilestone As Decimal = Me.GetTotalSameMilestone
      Dim totalIncome As Decimal = GetAmountFromSproc("GetTotalIncomeForWbs", toDate, Me.Id, False, view, requestor)
      If totalMilestone <> 0 Then
        totalIncome = (total / totalMilestone) * totalIncome
      End If
      Dim childs As WBSCollection = Me.Childs
      For Each child As WBS In childs
        ret += child.GetActualIncome(toDate, view)
      Next
      childs = Nothing
      ret += totalIncome
      Return ret
    End Function
    Public Function GetActualTotalNoChild(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Dim ret As Decimal = 0
      'Dim childs As WBSCollection = Me.Childs
      'For Each child As WBS In childs
      '    ret += child.GetActualTotal(toDate, view)
      'Next
      'childs = Nothing
      Return ret + GetAmountFromSproc("GetTotalAmountForWbsNoChild", toDate, Me.Id, False, view, requestor)
    End Function
    Public Function GetActualTotal(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Dim ret As Decimal = 0
      'Dim childs As WBSCollection = Me.Childs
      'For Each child As WBS In childs
      '    ret += child.GetActualTotal(toDate, view)
      'Next
      'childs = Nothing
      Return ret + GetAmountFromSproc("GetTotalAmountForWbs", toDate, Me.Id, False, view, requestor)
    End Function
    Public Function GetActualTotal(ByVal stock As ISimpleEntity, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      'เอา gr นี้ออก      Dim ret As Decimal = 0
      'Dim childs As WBSCollection = Me.Childs
      'For Each child As WBS In childs
      '    ret += child.GetActualTotal(stock, view)
      'Next
      'childs = Nothing
      Return ret + GetAmountFromSproc("GetTotalAmountForWbsWithoutThisStock", Me.Id, False, view, stock.Id, requestor)
    End Function
    Public Function GetActualTotalQty(ByVal stock As ISimpleEntity, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      'เอา gr นี้ออก      Dim ret As Decimal = 0
      'Dim childs As WBSCollection = Me.Childs
      'For Each child As WBS In childs
      '    ret += child.GetActualTotalQty(stock, view)
      'Next
      'childs = Nothing
      Return ret + GetAmountFromSproc("GetTotalQtyForWbsWithoutThisStock", Me.Id, False, view, stock.Id, requestor)
    End Function

    Public Function GetActualType0Qty(ByVal stock As ISimpleEntity, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Dim ret As Decimal = 0
      'Dim childs As WBSCollection = Me.Childs
      'For Each child As WBS In childs
      '    ret += child.GetActualType0Qty(stock, view)
      'Next
      'childs = Nothing
      Return ret + GetAmountFromSproc("GetType0QtyForWbsWithoutThisStock", Me.Id, False, view, stock.Id, requestor)
    End Function


#End Region
#End Region    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "WBS"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WBS.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.TextTree"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.TextTree"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WBS.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "wbs"
      End Get
    End Property
#End Region

#Region "Methods"
    Public Function GetUnit() As Unit
      'GetUnitForWbs
      Dim ds As DataSet = SqlHelper.ExecuteDataset( _
          Me.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetUnitForWbs" _
          , New SqlParameter("@wbs_id", Me.Id) _
          )
      Dim tableIndex As Integer = 0
      If ds.Tables.Count > tableIndex Then
        If ds.Tables(tableIndex).Rows.Count > 0 Then
          If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
            Return Nothing
          End If
          Return New Unit(CInt(ds.Tables(tableIndex).Rows(0)(0)))
        End If
      End If
    End Function
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New WBS(parId)
      Else
        Me.Parent = Nothing
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As WBS
      If Not m_boq Is Nothing Then
        For Each parent As WBS In m_boq.WBSCollection
          If parent.Id = id Then
            par = parent
            Exit Sub
          End If
        Next
      End If
      If par Is Nothing Then
        par = New WBS
        par.Id = id
        par.Code = code
        par.Name = name
      End If
      Me.Parent = par
    End Sub
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("0")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim cmd As New SqlCommand("delete wbs where wbs_id=" & Me.Id)
        cmd.Connection = conn
        cmd.Transaction = trans
        'cmd.CommandText = "delete glformat where glf_id=" & Me.Id
        cmd.ExecuteNonQuery()
        trans.Commit()
        Return New SaveErrorException("1")
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Finally
        conn.Close()
      End Try
    End Function
    Public Shared Function GetParentsBudgetList(ByVal doctype As Integer, ByVal wbsidList As String) As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset( _
          SimpleBusinessEntityBase.ConnectionString _
         , CommandType.StoredProcedure _
         , "GetParentsBudget" _
         , New SqlParameter("@wbsidlist", wbsidList) _
         , New SqlParameter("@doctype", doctype) _
         )
      If Not ds.Tables(0) Is Nothing Then
        Return ds
      End If

    End Function
    Public Shared ParentBudgetHash As New Hashtable
    Public Function GetParentsBudget(ByVal doctype As Integer, Optional ByVal ccid As Integer = 0) As ArrayList
      'Dim arr As New ArrayList
      'If ccid <> 0 Then
      '  Dim ds As DataSet = SqlHelper.ExecuteDataset( _
      '   Me.ConnectionString _
      '   , CommandType.StoredProcedure _
      '   , "GetParentsBudget" _
      '   , New SqlParameter("@wbs_id", Me.Id) _
      '   , New SqlParameter("@doctype", doctype) _
      '   , New SqlParameter("@cc", ccid) _
      '   )
      '  For Each row As DataRow In ds.Tables(0).Rows
      '    arr.Add(row)
      '  Next
      '  Return arr
      'Else
      '  Dim ds As DataSet = SqlHelper.ExecuteDataset( _
      '   Me.ConnectionString _
      '   , CommandType.StoredProcedure _
      '   , "GetParentsBudget" _
      '   , New SqlParameter("@wbs_id", Me.Id) _
      '   , New SqlParameter("@doctype", doctype) _
      '   )
      '  For Each row As DataRow In ds.Tables(0).Rows
      '    arr.Add(row)
      '  Next
      '  Return arr
      'End If

      Dim arr As New ArrayList
      Dim searchKey As String

      If WBS.ParentBudgetHash.Count > 10 Then
        WBS.ParentBudgetHash = New Hashtable
      End If

      If ccid <> 0 Then
        searchKey = Me.Id & "|" & doctype & "|" & ccid
        If WBS.ParentBudgetHash.Contains(searchKey) Then
          Return CType(WBS.ParentBudgetHash(searchKey), ArrayList)
        Else
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
           Me.ConnectionString _
           , CommandType.StoredProcedure _
           , "GetParentsBudget" _
           , New SqlParameter("@wbs_id", Me.Id) _
           , New SqlParameter("@doctype", doctype) _
           , New SqlParameter("@cc", ccid) _
           )
          For Each row As DataRow In ds.Tables(0).Rows
            arr.Add(row)
          Next
          WBS.ParentBudgetHash(searchKey) = arr
          Return arr
        End If
      Else
        searchKey = Me.Id & "|" & doctype
        If WBS.ParentBudgetHash.Contains(searchKey) Then
          Return CType(WBS.ParentBudgetHash(searchKey), ArrayList)
        Else
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
           Me.ConnectionString _
           , CommandType.StoredProcedure _
           , "GetParentsBudget" _
           , New SqlParameter("@wbs_id", Me.Id) _
           , New SqlParameter("@doctype", doctype) _
           )
          For Each row As DataRow In ds.Tables(0).Rows
            arr.Add(row)
          Next
          WBS.ParentBudgetHash(searchKey) = arr
          Return arr
        End If
      End If
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim parID As Object = 0
        If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
          parID = Me.Parent.Id
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
          paramArrayList.Add(New SqlParameter("@wbs_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        paramArrayList.Add(New SqlParameter("@wbs_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@wbs_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@wbs_boq", ValidIdOrDBNull(Me.Boq)))
        paramArrayList.Add(New SqlParameter("@wbs_parid", parID))
        paramArrayList.Add(New SqlParameter("@wbs_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@wbs_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@wbs_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@wbs_noqtycontrol", Me.NoQtyControl))
        paramArrayList.Add(New SqlParameter("@wbs_qty", Me.Qty))
        'paramArrayList.Add(New SqlParameter("@wbs_startdate", Me.StartDate))
        'paramArrayList.Add(New SqlParameter("@wbs_finishdate", Me.FinishDate))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)

        ' ตรวจจับ Error ของการ Save ...

        Return New SaveErrorException(returnVal.Value.ToString)

      End With
    End Function
#End Region

#Region "OVerrides"
    Public Overrides Sub PopulateTree(ByVal tvGroup As TreeView, ByVal ParamArray filters() As Filter)
      Dim ds As DataSet = Me.GetListDataSet("", filters)
      Dim dt As DataTable = ds.Tables(0)
      tvGroup.BeginUpdate()
      tvGroup.Nodes.Clear()
      'tvGroup.ForeColor = Color.Gray
      For Each row As DataRow In dt.Rows
        Dim NodeTag As WBS = New WBS(row, "")
        Dim nodeNote As String = ""
        If Not row.IsNull(Prefix & "_note") AndAlso row(Prefix & "_note").ToString.Length > 0 Then
          nodeNote = " (" & CStr(row(Prefix & "_note")) & ")"
        End If
        Dim NodeNme As String = CStr(row(Prefix & "_code")) & " - " & CStr(row(Prefix & "_name")) & nodeNote
        Dim parentNodes As TreeNodeCollection
        If IsDBNull(row(Prefix & "_parid")) OrElse CInt(row(Prefix & "_parid")) = CInt(row(Prefix & "_id")) Then
          parentNodes = tvGroup.Nodes
        Else
          Dim parnode As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(row(Prefix & "_parid")))
          If parnode Is Nothing Then
            parentNodes = tvGroup.Nodes
          Else
            parentNodes = parnode.Nodes
          End If
        End If
        Dim theNode As TreeNode = parentNodes.Add(NodeNme)
        theNode.Tag = NodeTag
      Next
      If ds.Tables.Count = 2 Then
        Dim dt2 As DataTable = ds.Tables(1)
        For Each row As DataRow In dt2.Rows
          Dim node As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(row(Prefix & "_id")))
          TreeViewHelper.HilightNode(node, Color.Blue)
        Next
      End If
      tvGroup.EndUpdate()
    End Sub
    Public Overrides Function ToString() As String
      Dim nodeNote As String = ""
      If Not Me.Note Is Nothing AndAlso Me.Note.Length > 0 Then
        nodeNote = " (" & Me.Note & ")"
      End If
      If Me.Referenced Then
        nodeNote &= " <Ref>"
      End If
      Return Me.Code & " - " & Me.Name & nodeNote
    End Function
#End Region

#Region "IDisposable"
    Public Sub Dispose() Implements System.IDisposable.Dispose
      Dispose(True)
    End Sub
    Protected Overrides Sub Finalize()
      Dispose(False)
    End Sub
    Protected m_disposed As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If m_disposed Then
        Return
      End If
      If disposing Then
        m_disposed = True
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
      Me.m_boq = Nothing
    End Sub
#End Region

    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "WBS"
      End Get
    End Property

#Region "Shared"
    Public Shared Function GetWBS(ByVal code As String, ByVal cc As CostCenter) As WBS
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetWbsFromCodeAndCC" _
                , New SqlParameter("@cc_id", cc.Id) _
                , New SqlParameter("@wbs_code", code) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Dim myWBS As New WBS(ds.Tables(0).Rows(0), "")
          Return myWBS
        End If
      Catch ex As Exception
      End Try
    End Function
    Public Shared Function GetWBS(ByVal code As String, ByVal ccId As Integer) As WBS
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetWbsFromCodeAndCC2" _
                , New SqlParameter("@cc_id", ccId) _
                , New SqlParameter("@wbs_code", code) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Dim myWBS As New WBS(ds.Tables(0).Rows(0), "")
          Return myWBS
        Else
          Return Nothing
        End If
      Catch ex As Exception
      End Try
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class WBSCollection
    Inherits CollectionBase
    Implements IDisposable

#Region "Members"
    Private m_boq As Boq
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As Boq)
      Me.m_boq = owner
      If Not Me.m_boq.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetWBSs" _
      , New SqlParameter("@boq_id", Me.m_boq.Id) _
      , New SqlParameter("@isGenerateListNumber", 1) _
      )

      Construct(ds)

    End Sub
    Public Sub New(ByVal ownerId As Integer)
      Me.m_boq = New Boq
      Me.m_boq.Id = ownerId
      If Not Me.m_boq.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetWBSs" _
      , New SqlParameter("@boq_id", Me.m_boq.Id) _
      )

      Construct(ds)

    End Sub
    Private Sub Construct(ByVal ds As DataSet)
      Dim parentHash As New Hashtable
      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New WBS(row, "", m_boq)
        parentHash(item.Id) = item
        Dim parid As Integer = 0
        If Not row.IsNull("wbs_parid") Then
          parid = CInt(row("wbs_parid"))
        End If
        If parentHash.Contains(parid) Then
          Dim theParent As WBS = CType(parentHash(parid), WBS)
          item.Parent = theParent
          If Not theParent Is item Then
            theParent.Childs.Add(item)
          End If
          theParent = Nothing
        End If
        If Not item Is Nothing Then
          Me.Add(item)
          If Not Me.m_boq.Originated Then
            item.Boq = New Boq
            item.Boq.Id = CInt(row("wbs_boq"))
          End If
        End If
      Next
      parentHash = Nothing
    End Sub
#End Region

#Region "Properties"
    Public Property Boq() As Boq      Get        Return m_boq      End Get      Set(ByVal Value As Boq)        m_boq = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As WBS
      Get
        Return CType(MyBase.List.Item(index), WBS)
      End Get
      Set(ByVal value As WBS)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Default Public Property Item(ByVal theWbs As WBS) As WBS
      Get
        If theWbs Is Nothing Then
          Return Nothing
        End If
        For Each myWbs As WBS In Me
          If theWbs Is myWbs OrElse theWbs.Id <> 0 And theWbs.Id = myWbs.Id Then
            Return myWbs
          End If
        Next
      End Get
      Set(ByVal value As WBS)

      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetMaxLevel() As Integer
      Dim tmpMax As Integer = 0
      For Each tmpWbs As WBS In Me
        tmpMax = Math.Max(tmpMax, tmpWbs.Level)
      Next
      Return tmpMax
    End Function
    Public Function GetParentOf(ByVal childWbs As WBS) As WBS
      For Each myWbs As WBS In Me
        If myWbs.Id <> 0 And myWbs.Id = childWbs.Parent.Id Then
          Return myWbs
        End If
        If myWbs Is childWbs.Parent Then
          Return myWbs
        End If
      Next
    End Function
    Public Function SearchCodeOrName(ByVal criteria As String) As WBSCollection()
      Dim ret(1) As WBSCollection
      Dim foundWbsColl As New WBSCollection
      Dim exactWbsColl As New WBSCollection
      foundWbsColl.Boq = Me.Boq
      exactWbsColl.Boq = Me.Boq
      Dim root As WBS = GetRoot()
      If Not foundWbsColl.ContainsId(root) Then
        foundWbsColl.Add(root)
      End If
      For Each tmpWbs As WBS In Me
        If (Not tmpWbs.Code Is Nothing AndAlso tmpWbs.Code.ToLower.IndexOf(criteria.ToLower) >= 0) OrElse (Not tmpWbs.Name Is Nothing AndAlso tmpWbs.Name.ToLower.IndexOf(criteria.ToLower) >= 0) Then
          AddParent(tmpWbs, foundWbsColl)
          If Not exactWbsColl.ContainsId(tmpWbs) Then
            exactWbsColl.Add(tmpWbs)
          End If
          If Not foundWbsColl.ContainsId(tmpWbs) Then
            foundWbsColl.Add(tmpWbs)
          End If
        End If
      Next
      ret(0) = foundWbsColl
      ret(1) = exactWbsColl
      Return ret
    End Function
    Private Sub AddParent(ByVal myWbs As WBS, ByVal col As WBSCollection)
      Dim root As WBS = GetRoot()
      If myWbs Is root Or myWbs Is Nothing Then
        Return
      End If
      AddParent(Me.GetParentOf(myWbs), col)
      If Not col.ContainsId(myWbs) Then
        col.Add(myWbs)
      End If
    End Sub
    Public Function GetRoot() As WBS
      For Each myWbs As WBS In Me
        If myWbs.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          Return myWbs
        End If
        If myWbs.Parent Is myWbs Then
          Return myWbs
        End If
      Next
    End Function
    Public Sub UpdateParentId(ByVal oldParid As Integer, ByVal newParid As Integer)
      For Each myWbs As WBS In Me
        Dim parent As WBS = CType(myWbs.Parent, WBS)
        If Not Me.Contains(parent) Then
          If parent.Id = oldParid Then
            parent.Id = newParid
          End If
        End If
      Next
    End Sub
    Public Function GetCollectionWithSameMilestone(ByVal mileStone As Milestone) As WBSCollection
      Dim newWbsColl As New WBSCollection
      newWbsColl.Boq = Me.Boq
      If mileStone Is Nothing OrElse Not mileStone.Originated Then
        Return newWbsColl
      End If
      For Each myWbs As WBS In Me
        If Not myWbs.Milestone Is Nothing AndAlso myWbs.Milestone.Id = mileStone.Id Then
          newWbsColl.Add(myWbs)
        End If
      Next
      Return newWbsColl
    End Function
    'Public Function GetChildsOf(ByVal parent As WBS) As WBSCollection
    '  Dim newWbsColl As New WBSCollection
    '  newWbsColl.Boq = Me.Boq
    '  For Each myWbs As WBS In Me
    '    'MessageBox.Show("Id" & ":" & myWbs.Id.ToString)
    '    If Not myWbs Is myWbs.Parent AndAlso myWbs.Parent Is parent Then
    '      'MessageBox.Show("added:" & myWbs.Id.ToString & ":" & parent.Id.ToString)
    '      newWbsColl.Add(myWbs)
    '    ElseIf myWbs.Id <> 0 AndAlso myWbs.Id <> parent.Id AndAlso myWbs.Parent.Id = parent.Id Then
    '      'MessageBox.Show("added:" & myWbs.Id.ToString & ":" & parent.Id.ToString)
    '      newWbsColl.Add(myWbs)
    '    Else
    '      'MessageBox.Show("Not added:" & myWbs.Id.ToString & ":" & parent.Id.ToString)
    '    End If
    '  Next
    '  Return newWbsColl
    'End Function
    Public Function GetSubOrdinatesOf(ByVal parent As WBS) As WBSCollection
      Dim newWbsColl As New WBSCollection
      newWbsColl.Boq = Me.Boq
      For Each collWbs As WBS In Me
        Dim tmpWbs As WBS = collWbs
        Dim tmpColl As New WBSCollection
        tmpColl.Add(tmpWbs)
        While Not tmpWbs Is Nothing AndAlso tmpWbs.Level >= parent.Level
          '>>>> สุดทางเจอแม่แล้ว
          If tmpWbs.Id <> 0 And tmpWbs.Id = parent.Id Then
            newWbsColl.AddRange(tmpColl)
            Exit While
          ElseIf tmpWbs Is parent Then
            newWbsColl.AddRange(tmpColl)
            Exit While
          End If
          tmpWbs = GetParentOf(tmpWbs) ' CType(tmpWbs.Parent, WBS)
          If Not tmpWbs Is Nothing And Not tmpWbs Is tmpWbs Then
            tmpColl.Add(tmpWbs)
          End If
        End While
        tmpColl.Clear()
      Next
      Return newWbsColl
    End Function
    Public Function GetSubOrdinatesOf(ByVal parent As WBS, ByVal fiters As Filter()) As WBSCollection
      Dim valueFrom As Object = DBNull.Value
      Dim valueTo As Object = DBNull.Value
      Dim containName As Object = DBNull.Value
      For Each myFilter As Filter In fiters
        Select Case myFilter.Name.ToLower
          Case "valuefrom"
            valueFrom = myFilter.Value
          Case "valueto"
            valueTo = myFilter.Value
          Case "containname"
            containName = myFilter.Value
        End Select
      Next
      If IsDBNull(valueFrom) Then
        valueFrom = Decimal.MinValue
      End If
      If IsDBNull(valueTo) Then
        valueTo = Decimal.MaxValue
      End If
      If IsDBNull(containName) Then
        containName = ""
      End If
      Dim newWbsColl As New WBSCollection
      newWbsColl.Boq = Me.Boq
      For Each collWbs As WBS In Me
        Dim tmpWbs As WBS = collWbs
        Dim tmpColl As New WBSCollection
        Dim value As Decimal = tmpWbs.GetTotal
        If value >= CDec(valueFrom) And value <= CDec(valueTo) Then
          If containName.ToString.Length = 0 OrElse tmpWbs.Name.ToLower.IndexOf(containName.ToString.ToLower) >= 0 OrElse tmpWbs.Code.ToLower.IndexOf(containName.ToString.ToLower) >= 0 Then
            tmpColl.Add(tmpWbs)
          End If
        End If
        While Not tmpWbs Is Nothing AndAlso tmpWbs.Level >= parent.Level
          '>>>> สุดทางเจอแม่แล้ว
          If tmpWbs.Id <> 0 And tmpWbs.Id = parent.Id Then
            newWbsColl.AddRange(tmpColl)
            Exit While
          ElseIf tmpWbs Is parent Then
            newWbsColl.AddRange(tmpColl)
            Exit While
          End If
          tmpWbs = GetParentOf(tmpWbs) ' CType(tmpWbs.Parent, WBS)
          If Not tmpWbs Is Nothing And Not tmpWbs Is tmpWbs Then
            If value >= CDec(valueFrom) And value <= CDec(valueTo) Then
              If containName.ToString.Length = 0 OrElse tmpWbs.Name.ToLower.IndexOf(containName.ToString.ToLower) >= 0 OrElse tmpWbs.Code.ToLower.IndexOf(containName.ToString.ToLower) >= 0 Then
                tmpColl.Add(tmpWbs)
              End If
            End If
          End If
        End While
        tmpColl.Clear()
      Next
      Return newWbsColl
    End Function
    Public Sub Populate(ByVal tvWbs As TreeView, Optional ByVal searchedColl As WBSCollection = Nothing, Optional ByVal showMilestone As Boolean = False)
      tvWbs.BeginUpdate()
      tvWbs.Nodes.Clear()
      For Each myWbs As WBS In Me
        Dim parentNodes As TreeNodeCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = tvWbs.Nodes
        ElseIf myWbs.Parent Is Nothing Then
          'Hack
          Try
            parentNodes = tvWbs.Nodes(0).Nodes
          Catch ex As Exception

          End Try
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = tvWbs.Nodes
        Else
          Dim parentNode As TreeNode = FindNode(tvWbs, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Nodes
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim nodeText As String = myWbs.ToString
          If showMilestone Then
            nodeText &= ":" & myWbs.Milestone.ToString
          End If
          Dim n As TreeNode = parentNodes.Add(nodeText)
          n.Tag = myWbs
          If Not searchedColl Is Nothing Then
            For Each searched As WBS In searchedColl
              If searched.Id = myWbs.Id Then
                TreeViewHelper.HilightNode(n, Color.Blue)
                Exit For
              End If
            Next
          End If
        End If
      Next
      tvWbs.EndUpdate()
    End Sub
    Public Function FindNode(ByVal tv As TreeView, ByVal myWbs As WBS) As TreeNode
      Dim n As TreeNode
      For Each n In tv.Nodes
        Dim tn As TreeNode = FindNode(n, myWbs)
        If Not tn Is Nothing Then
          Return tn
        End If
      Next
    End Function
    Private Function FindNode(ByVal n As TreeNode, ByVal myWbs As WBS) As TreeNode
      If TypeOf n.Tag Is WBS Then
        Dim nodeWbs As WBS = CType(n.Tag, WBS)
        If nodeWbs Is myWbs Then
          Return n
        End If
        If nodeWbs.Id <> 0 And nodeWbs.Id = myWbs.Id Then
          Return n
        End If
      End If
      Dim aNode As TreeNode
      For Each aNode In n.Nodes
        Dim tn As TreeNode = FindNode(aNode, myWbs)
        If Not tn Is Nothing Then
          Return tn
        End If
      Next
    End Function
    Public Sub Sumarize(ByVal lv As Integer)
      For Each item As WBS In Me
        If item.Level < lv Then
          item.State = RowExpandState.Expanded
        End If
        If item.Level = lv Then
          item.State = RowExpandState.Collapsed
        End If
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As WBS) As Integer
      If Not Me.Contains(value) Then
        value.Boq = m_boq
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As WBSCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As WBS())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function ContainsId(ByVal value As WBS) As Boolean
      For Each myWbs As WBS In Me
        If myWbs.Id <> 0 And myWbs.Id = value.Id Then
          Return True
        End If
      Next
      Return Contains(value)
    End Function
    Public Function Contains(ByVal value As WBS) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As WBS(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As WBSEnumerator
      Return New WBSEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As WBS) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As WBS)
      value.Boq = m_boq
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As WBS)
      If Not Me.m_boq Is Nothing Then
        If Not Me.m_boq.ItemCollection Is Nothing Then
          Dim col As BoqItemCollection = Me.m_boq.ItemCollection.GetCollectionForWBS(value)
          Me.m_boq.ItemCollection.Remove(col)
          Me.m_boq.LaborMarkupItems.Remove(col)
          Me.m_boq.MaterialMarkupItems.Remove(col)
          Me.m_boq.EquipmentMarkupItems.Remove(col)
          For Each mrkup As Markup In Me.m_boq.MarkupCollection
            mrkup.DistributedItems.Remove(col)
          Next
          col.Dispose()
          col = Nothing
        End If
      End If
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As WBSCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

#Region "IDisposable"
    Public Sub Dispose() Implements System.IDisposable.Dispose
      Dispose(True)
    End Sub
    Protected Overrides Sub Finalize()
      Dispose(False)
    End Sub
    Protected m_disposed As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If m_disposed Then
        Return
      End If
      If disposing Then
        For Each item As WBS In Me
          item.Dispose()
          item = Nothing
        Next
        m_disposed = True
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
      Me.m_boq = Nothing
    End Sub
#End Region

    Public Class WBSEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As WBSCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, WBS)
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

  Public Class MultiAllocate
    Public Property LineNumber As Integer
    Public Property CostCenter As CostCenter
    Public Property CBS As CBS
    Public Property WBS As WBS
    Public Property Percent As Decimal

    Public Shared Function GetMultiBudgetAndActual(ByVal wbsListId As String, ByVal docType As String) As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, _
                                                   CommandType.StoredProcedure, _
                                                   "GetMultiPleAllocation", _
                                                   New SqlParameter("@wbsListId", wbsListId), _
                                                   New SqlParameter("@docType", docType))
      Return ds
    End Function
  End Class
End Namespace

