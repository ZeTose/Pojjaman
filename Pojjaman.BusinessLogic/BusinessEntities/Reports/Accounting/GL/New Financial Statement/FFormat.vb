Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Data.Linq
Imports System.Linq

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class FFormatType
    Inherits CodeDescription

#Region "Construtors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "financialstatement_type"
      End Get
    End Property
#End Region

  End Class
  Public Class FFormatAutoType
    Inherits CodeDescription

#Region "Construtors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "ff_autotype"
      End Get
    End Property
#End Region

  End Class



  Public Class FFormat
    Inherits SimpleBusinessEntityBase
    Implements IHasName, IPrintableEntity, IDuplicable

#Region "Members"
    Private m_name As String
    Private m_reportType As FFormatType
    Private m_note As String
    Private m_header As String
    Private m_condition As String
    Private m_companyname As String
    Private m_useCompanyNameInOption As Boolean
    Private m_isDefault As Boolean
    Private m_itemCollection As FFormatItemCollection
    Private m_columnCollection As FFormatColumnCollection

    Private m_autotype As FFormatAutoType
    Private m_divider As Integer = 1
#End Region

#Region "Constructors"
    Public Sub New(ByVal type As FFormatType)
      MyBase.New()
      Me.ReportType = type
    End Sub
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
        .m_note = ""
        m_header = ""
        m_condition = ""
        m_companyname = CStr(Configuration.GetConfig("CompanyName"))
        m_columnCollection = New FFormatColumnCollection(Me)
        m_itemCollection = New FFormatItemCollection(Me)
        m_useCompanyNameInOption = True
        m_reportType = New FFormatType(1)
        m_autotype = New FFormatAutoType(0)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      Dim drh As New DataRowHelper(dr)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
          .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_header") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_header") Then
          .m_header = CStr(dr(aliasPrefix & Me.Prefix & "_header"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_condition") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_condition") Then
          .m_condition = CStr(dr(aliasPrefix & Me.Prefix & "_condition"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_companyname") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_companyname") Then
          .m_companyname = CStr(dr(aliasPrefix & Me.Prefix & "_companyname"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isdefault") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isdefault") Then
          .m_isDefault = CBool(dr(aliasPrefix & Me.Prefix & "_isdefault"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_useCompanyNameInOption") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_useCompanyNameInOption") Then
          .m_useCompanyNameInOption = CBool(dr(aliasPrefix & Me.Prefix & "_useCompanyNameInOption"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_reporttype") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_reporttype") Then
          .m_reportType.Value = CInt(dr(aliasPrefix & Me.Prefix & "_reporttype"))
        End If

        .m_autotype.Value = CInt(drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_autotype"))

        m_columnCollection = New FFormatColumnCollection(Me) 'ต้องอยู่ก่อน Item!!!!
        m_itemCollection = New FFormatItemCollection(Me)

      End With
    End Sub
#End Region

#Region "Properties"
    Public Property Divider() As Integer      Get        Return m_divider      End Get      Set(ByVal Value As Integer)        m_divider = Value      End Set    End Property
    Public Property Header() As String      Get        Return m_header      End Get      Set(ByVal Value As String)        m_header = Value      End Set    End Property    Public Property Condition() As String      Get        Return m_condition      End Get      Set(ByVal Value As String)        m_condition = Value      End Set    End Property    Public Property Companyname() As String      Get        If UseCompanyNameInOption Then          Return CStr(Configuration.GetConfig("CompanyName"))
        End If        Return m_companyname      End Get      Set(ByVal Value As String)        m_companyname = Value      End Set    End Property    Public Property UseCompanyNameInOption() As Boolean      Get        Return m_useCompanyNameInOption      End Get      Set(ByVal Value As Boolean)        m_useCompanyNameInOption = Value      End Set    End Property
    Public Property ReportType() As FFormatType      Get        Return m_reportType      End Get      Set(ByVal Value As FFormatType)        m_reportType = Value      End Set    End Property
    Public Property AutoType As FFormatAutoType
      Get
        Return m_autotype
      End Get
      Set(ByVal value As FFormatAutoType)
        m_autotype = value
      End Set
    End Property
    Public Property ColumnCollection() As FFormatColumnCollection
      Get
        Return Me.m_columnCollection
      End Get
      Set(ByVal Value As FFormatColumnCollection)
        Me.m_columnCollection = Value
      End Set
    End Property
    Public Property ItemCollection() As FFormatItemCollection
      Get
        Return Me.m_itemCollection
      End Get
      Set(ByVal Value As FFormatItemCollection)
        Me.m_itemCollection = Value
      End Set
    End Property
    Public Property IsDefault() As Boolean      Get        Return m_isDefault      End Get      Set(ByVal Value As Boolean)        m_isDefault = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "FFormat"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.FFormat.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.FFormat"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.FFormat"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.FFormat.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "ff"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Name & ")"
        If tpt.EndsWith("()") Then
          tpt = tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property

#End Region

#Region "Shared"
    Public Shared Function GetColumnSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("FFormatColumn")
      myDatatable.Columns.Add(New DataColumn("ffc_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("ffc_name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ffc_widthpercent", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ffc_alignment", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("CCCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ffc_includechildcc", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("JCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("JButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("JName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EJCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EJButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EJName", GetType(String)))

      Dim dateCol As New DataColumn("ffc_startdate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      dateCol = New DataColumn("ffc_enddate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)


      Return myDatatable
    End Function
    Public Shared Sub Populate(ByVal tvGroup As TreeView, ByVal filters() As Filter)
      Dim ds As DataSet = GetFFormatDataset(filters)
      Populate(tvGroup, ds)
    End Sub
    Public Shared Sub Populate(ByVal tvGroup As TreeView)
      Dim ds As DataSet = GetFFormatDataset()
      Populate(tvGroup, ds)
    End Sub
    Private Shared Sub Populate(ByVal tvGroup As TreeView, ByVal ds As DataSet)
      Dim dtType As DataTable = ds.Tables(0)  ' Codedescription
      Dim dtFormat As DataTable = ds.Tables(1)   ' FFormat
      Dim currentGroupNode As New TreeNode("")
      Dim currentNode As TreeNode
      For Each row As DataRow In dtType.Rows
        If row("code_description").ToString <> currentGroupNode.Text Then
          currentGroupNode = tvGroup.Nodes.Add(row("code_description").ToString)
          currentGroupNode.Tag = New IdValuePair(CInt(row("code_value")), "reporttype")
        End If
        Dim childRows As DataRow() = dtFormat.Select("ff_reporttype = " & row("code_value").ToString)
        For Each childRow As DataRow In childRows
          Dim childNode As TreeNode = currentGroupNode.Nodes.Add(childRow("ff_code").ToString & " - " & childRow("ff_name").ToString)
          childNode.Tag = New IdValuePair(CInt(childRow("ff_id")), "fformat")
        Next
      Next
    End Sub
    Private Shared Function GetFFormatDataset() As DataSet
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetFFormatList")
      Return ds
    End Function
    Private Shared Function GetFFormatDataset(ByVal filters() As Filter) As DataSet
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetFFormatList", params)
      Return ds
    End Function
    Public Shared Function GetFFormat(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldFsFormat As FFormat) As Boolean
      Dim newFsFormat As New FFormat(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not newFsFormat.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        newFsFormat = oldFsFormat
      End If
      txtCode.Text = newFsFormat.Code
      txtName.Text = newFsFormat.Name
      If oldFsFormat.Id <> newFsFormat.Id Then
        oldFsFormat = newFsFormat
        Return True
      End If
      Return False
    End Function
    Public Shared Function FontToString(ByVal f As System.Drawing.Font) As String
      If f Is Nothing Then
        Return "Tahoma,8.25,0"
      End If
      Dim strs(2) As String
      strs(0) = f.FontFamily.Name
      strs(1) = f.Size.ToString
      strs(2) = f.Style.GetHashCode.ToString
      Dim str As String = strs(0) & "," & strs(1) & "," & strs(2)
      Return str
    End Function
    Public Shared Function StringToFont(ByVal str As String) As System.Drawing.Font
      If str Is Nothing OrElse str.Length = 0 Then
        Return New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
      End If
      Dim strs() As String = str.Split(CType(",", Char))
      Dim f As System.Drawing.Font
      Try
        Dim ffamily As String = strs(0)
        Dim fsize As Single = CSng(strs(1))
        Dim fs As FontStyle = CType(strs(2), FontStyle)
        f = New Font(ffamily, fsize, fs)
      Catch ex As Exception
        f = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
      End Try
      Return f
    End Function
#End Region

#Region " Style "
    Public Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("FFormatItem")

      myDatatable.Columns.Add(New DataColumn("ffi_linenumber", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("ffi_code", GetType(String)))

      Dim i As Integer = 0
      For Each col As FFormatColumn In Me.ColumnCollection
        i += 1
        myDatatable.Columns.Add(New DataColumn("ffi_formula" & i.ToString, GetType(String)))
        myDatatable.Columns.Add(New DataColumn("btn_account" & i.ToString, GetType(String)))
      Next

      myDatatable.Columns.Add(New DataColumn("ffi_isnewpage", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("ffi_linestyle", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("ffi_invisible", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ffi_style", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("btn_style", GetType(String)))

      Return myDatatable
    End Function
    Public Function CreateValueTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "FFormatItem"

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      ' line number 
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "ffi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetail.GridLineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "ffi_linenumber"

      ' rownum หมายเลข line number
      Dim csCode As New TreeTextColumn
      csCode.MappingName = "ffi_code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetail.GridCodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 45
      csCode.ReadOnly = True
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Center
      csCode.TextBox.Name = "ffi_code"

      Dim csIsInvisible As New DataGridCheckBoxColumn
      csIsInvisible.MappingName = "ffi_invisible"
      csIsInvisible.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetail.GridIsInvisibleHeaderText}")
      csIsInvisible.Width = 50
      csIsInvisible.ReadOnly = True
      csIsInvisible.InvisibleWhenUnspcified = True

      'dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)

      Dim i As Integer = 0
      For Each col As FFormatColumn In Me.ColumnCollection
        i += 1
        Dim csFormula As New TreeTextColumn
        csFormula.MappingName = "ffi_formula" & i.ToString
        csFormula.HeaderText = TextHelper.StringHelper.GetExcelColumnString(i) & " [" & col.Name & "]"
        csFormula.NullText = ""
        csFormula.Width = 150
        csFormula.ReadOnly = True
        csFormula.Alignment = HorizontalAlignment.Center
        csFormula.DataAlignment = HorizontalAlignment.Left

        dst.GridColumnStyles.Add(csFormula)
      Next

      dst.GridColumnStyles.Add(csIsInvisible)
      Return dst
    End Function
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "FFormatItem"

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      ' line number 
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "ffi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetail.GridLineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "ffi_linenumber"

      ' rownum หมายเลข line number
      Dim csCode As New TreeTextColumn
      csCode.MappingName = "ffi_code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetail.GridCodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 45
      csCode.ReadOnly = True
      csCode.Alignment = HorizontalAlignment.Center
      csCode.DataAlignment = HorizontalAlignment.Center
      csCode.TextBox.Name = "ffi_code"

      Dim csIsNewpage As New DataGridCheckBoxColumn(Me.ColumnCollection.Count * 2 + 1)
      csIsNewpage.MappingName = "ffi_isnewpage"
      csIsNewpage.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetail.GridIsNewPageHeaderText}")
      csIsNewpage.Width = 70
      csIsNewpage.InvisibleWhenUnspcified = True

      Dim csIsInvisible As New DataGridCheckBoxColumn(Me.ColumnCollection.Count * 2 + 2)
      csIsInvisible.MappingName = "ffi_invisible"
      csIsInvisible.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetail.GridIsInvisibleHeaderText}")
      csIsInvisible.Width = 50
      csIsInvisible.InvisibleWhenUnspcified = True

      Dim csLineStyle As DataGridComboColumn
      csLineStyle = New DataGridComboColumn("ffi_linestyle" _
          , CodeDescription.GetCodeList("line_style") _
          , "code_description", "code_value")
      csLineStyle.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatDetail.GridLineStyleHeaderText}")
      csLineStyle.NullText = String.Empty
      'csLineStyle.ReadOnly = False
      csLineStyle.Alignment = HorizontalAlignment.Center


      'dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)

      Dim i As Integer = 0
      For Each col As FFormatColumn In Me.ColumnCollection
        i += 1
        Dim csFormula As New TreeTextColumn
        csFormula.MappingName = "ffi_formula" & i.ToString
        csFormula.HeaderText = TextHelper.StringHelper.GetExcelColumnString(i) & " [" & col.Name & "]"
        csFormula.NullText = ""
        csFormula.Width = 150
        csFormula.ReadOnly = False
        csFormula.Alignment = HorizontalAlignment.Center
        csFormula.DataAlignment = HorizontalAlignment.Left

        ' Formula style
        Dim csaccount As New DataGridButtonColumn
        csaccount.MappingName = "btn_account" & i.ToString
        csaccount.HeaderText = ""
        csaccount.NullText = ""
        If i = 1 Then
          AddHandler csaccount.Click, AddressOf ButtonClicked
        End If

        dst.GridColumnStyles.Add(csFormula)
        dst.GridColumnStyles.Add(csaccount)
      Next

      dst.GridColumnStyles.Add(csIsInvisible)
      dst.GridColumnStyles.Add(csIsNewpage)
      'dst.GridColumnStyles.Add(csLineStyle)
      Return dst
    End Function
    Public Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      RaiseEvent FormulaButtonClicked(e)
    End Sub
    Public Event FormulaButtonClicked(ByVal e As ButtonColumnEventArgs)

    Public Shared Function GetRunColumn(ByVal index As Integer) As String
      If index <= 0 Then
        Return "" 'Error
      End If
      If index <= 26 Then 'หลักเดียว
        Return Chr(index + 64)
      End If
    End Function
#End Region

#Region "Methods"
    Public Sub RefreshGLValue()

      'แยกกันเพื่อให้ส่ง parameter ไม่ต้อง save ก่อน
      For Each col As FFormatColumn In ColumnCollection
        col.RefreshGLValue()
      Next


      'ของเก่าต้องบังคับให้ save ก่อน
      'Dim startdate As Date = Date.MaxValue
      'Dim enddate As Date = Date.MinValue

      'For Each col As FFormatColumn In ColumnCollection
      '  If col.StartDate < startdate Then
      '    startdate = col.StartDate
      '  End If
      '  If col.EndDate > enddate Then
      '    enddate = col.EndDate
      '  End If
      'Next


      'Dim params(0) As SqlParameter
      'params(0) = New SqlParameter("@fformat", Me.Id)


      'Dim dsGlItem As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, "SumGLFromFFormat", params)

      'dicGlValue = New Dictionary(Of String, Decimal)

      'For Each row As DataRow In dsGlItem.Tables(0).Rows
      '  Dim drh As New DataRowHelper(row)
      '  dicGlValue.Add(drh.GetValue(Of String)("key"), drh.GetValue(Of Decimal)("Value"))
      'Next


    End Sub
    Public Function GetGLValueFromAccount(ByVal col As FFormatColumn, ByVal acct As Account) As Decimal
      

      

      'เปลี่ยนเป็น เก็บไว้ใน แต่ละ Col
      Dim key As String = acct.Code

      If col.DicGlValue.ContainsKey(key) Then
        Return col.DicGlValue.Item(key)

      End If
      Return 0

      'Dim params(6) As SqlParameter
      'params(0) = New SqlParameter("@docdatestart", ValidDateOrDBNull(col.StartDate))
      'params(1) = New SqlParameter("@docdateend", ValidDateOrDBNull(col.EndDate))
      'params(2) = New SqlParameter("@acct_id", ValidIdOrDBNull(acct))
      'params(3) = New SqlParameter("@cc_id", ValidIdOrDBNull(col.CostCenter))
      'params(4) = New SqlParameter("@IncludeChildCC", col.IncludeChildCostCenter)
      'params(5) = New SqlParameter("@acctbook_id", ValidIdOrDBNull(col.AccountBook))
      'params(6) = New SqlParameter("@endacctbook_id", ValidIdOrDBNull(col.EndAccountBook))
      'Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, "GetGLValue", params)
      'If ds.Tables(0).Rows.Count > 0 Then
      '  If Not IsDBNull(ds.Tables(0).Rows(0)(0)) Then
      '    Return CDec(ds.Tables(0).Rows(0)(0))
      '  End If
      'End If
      'Return 0

      ''ลองใช้ LINQ
      'value = Aggregate glitemforFFormat In dt.AsEnumerable _
      '            Where glitemforFFormat.Field(Of Decimal)("gli_acct") = acct.Id _
      '            AndAlso glitemforFFormat.Field(Of Decimal)("cc_id") = col.CostCenter.Id _
      'Into Sum(glitemforFFormat.Field(Of Decimal)("Value"))
      ''AndAlso (col.IncludeChildCostCenter = True andalso glitemforFFormat.Field(Of String)("cc_path") like "|"&col.CostCenter.Id.ToString & "|*" ) _
      ''AndAlso 
    End Function
    Public Function GetDataFromExcelRowCol(ByVal pattern As String) As FFormatData
      Dim re As New Regex(FFormatData.ColumnFormulaPettern)
      Dim m As Match = re.Match(pattern)
      Dim colNum As Integer = TextHelper.StringHelper.GetExcelColumnIndex(m.Groups(1).Value)
      Dim rowNum As Integer = CInt(m.Groups(2).Value)
      Return Me.ItemCollection(rowNum - 1).DataCollection(Me.ColumnCollection(colNum))
    End Function

    Public Overrides Function ToString() As String
      Return m_name
    End Function
    Private Sub ResetId(ByVal oldId As Integer)
      Me.Id = oldId
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@ff_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        paramArrayList.Add(New SqlParameter("@ff_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@ff_reporttype", Me.ReportType.Value))
        paramArrayList.Add(New SqlParameter("@ff_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@ff_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@ff_isdefault", Me.IsDefault))
        paramArrayList.Add(New SqlParameter("@ff_header", Me.Header))
        paramArrayList.Add(New SqlParameter("@ff_condition", Me.Condition))
        paramArrayList.Add(New SqlParameter("@ff_companyname", Me.Companyname))
        paramArrayList.Add(New SqlParameter("@ff_usecompanynameinoption", Me.UseCompanyNameInOption))
        paramArrayList.Add(New SqlParameter("@ff_autotype", Me.AutoType.Value))

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldId As Integer = Me.Id
        Try
          Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
          Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
          If Not IsNumeric(saveDetailError.Message) Then
            trans.Rollback()
            ResetId(oldId)
            Return saveDetailError
          Else
            Select Case CInt(saveDetailError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldId)
                Return saveDetailError
              Case Else
            End Select
          End If
          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          ResetId(oldId)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          ResetId(oldId)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim daCol As New SqlDataAdapter("Select * from FFormatColumn where ffc_ff=" & Me.Id, conn)
        Dim da As New SqlDataAdapter("Select * from FFormatitem where ffi_ff=" & Me.Id, conn)
        Dim daFormula As New SqlDataAdapter("select * from FFormatFormula where fff_ff=" & Me.Id, conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "FFormatitem")
        da.Fill(ds, "FFormatitem")

        cmdBuilder = New SqlCommandBuilder(daCol)
        daCol.SelectCommand.Transaction = trans
        daCol.DeleteCommand = cmdBuilder.GetDeleteCommand
        daCol.DeleteCommand.Transaction = trans
        daCol.InsertCommand = cmdBuilder.GetInsertCommand
        daCol.InsertCommand.Transaction = trans
        daCol.UpdateCommand = cmdBuilder.GetUpdateCommand
        daCol.UpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daCol.FillSchema(ds, SchemaType.Mapped, "FFormatColumn")
        daCol.Fill(ds, "FFormatColumn")

        cmdBuilder = New SqlCommandBuilder(daFormula)
        daFormula.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daFormula.FillSchema(ds, SchemaType.Mapped, "FFormatFormula")
        daFormula.Fill(ds, "FFormatFormula")

        Dim dt As DataTable = ds.Tables("FFormatitem")
        Dim dtColumn As DataTable = ds.Tables("FFormatColumn")
        Dim dtFormula As DataTable = ds.Tables("FFormatFormula")

        For Each row As DataRow In dtFormula.Rows
          row.Delete()
        Next
        For Each row As DataRow In dt.Rows
          row.Delete()
        Next

        With ds.Tables("FFormatColumn")
          Dim rowsToDelete As New ArrayList
          For Each dr As DataRow In .Rows
            Dim found As Boolean = False
            For Each testCol As FFormatColumn In Me.ColumnCollection
              If testCol.LineNumber = CInt(dr("ffc_linenumber")) Then
                found = True
                Exit For
              End If
            Next
            If Not found Then
              If Not rowsToDelete.Contains(dr) Then
                rowsToDelete.Add(dr)
              End If
            End If
          Next
          For Each row As DataRow In rowsToDelete
            row.Delete()
          Next
          For Each item As FFormatColumn In Me.ColumnCollection
            Dim drs As DataRow() = .Select("ffc_linenumber=" & item.LineNumber)
            Dim newdr As DataRow
            If drs.Length = 0 Then
              newdr = .NewRow
            Else
              newdr = drs(0)
            End If
            newdr("ffc_ff") = Me.Id
            newdr("ffc_linenumber") = item.LineNumber
            newdr("ffc_name") = item.Name
            newdr("ffc_widthpercent") = item.WidthPercent
            newdr("ffc_alignment") = CInt(item.Alignment)
            newdr("ffc_startdate") = IIf(item.StartDate.Equals(Date.MinValue), DBNull.Value, item.StartDate)
            newdr("ffc_enddate") = IIf(item.EndDate.Equals(Date.MinValue), DBNull.Value, item.EndDate)
            newdr("ffc_cc") = Me.ValidIdOrDBNull(item.CostCenter)
            newdr("ffc_includechildcc") = item.IncludeChildCostCenter
            newdr("ffc_journal") = Me.ValidIdOrDBNull(item.AccountBook)
            newdr("ffc_endjournal") = Me.ValidIdOrDBNull(item.EndAccountBook)
            If drs.Length = 0 Then
              .Rows.Add(newdr)
            End If
          Next
        End With
        For Each item As FFormatItem In Me.ItemCollection
          Dim newdr As DataRow = dt.NewRow
          newdr("ffi_ff") = Me.Id
          newdr("ffi_linenumber") = item.LineNumber
          newdr("ffi_code") = item.Code
          newdr("ffi_style") = item.Style
          newdr("ffi_isnewpage") = item.IsNewPage
          newdr("ffi_invisible") = item.IsInvisible
          newdr("ffi_linestyle") = item.LineStyle

          dt.Rows.Add(newdr)
          For Each fff As FFormatData In item.DataCollection
            Dim childDr As DataRow = dtFormula.NewRow
            childDr("fff_ff") = Me.Id
            childDr("fff_ffi") = item.LineNumber
            childDr("fff_ffc") = fff.Column.LineNumber
            childDr("fff_formula") = fff.Formula
            childDr("fff_style") = fff.Style
            childDr("fff_linestyle") = fff.Linestyle
            childDr("fff_indentation") = fff.Indentation
            dtFormula.Rows.Add(childDr)
          Next
        Next

        daFormula.Update(dtFormula.Select("", "", DataViewRowState.Deleted))
        da.Update(dt.Select("", "", DataViewRowState.Deleted))
        daCol.Update(dtColumn.Select("", "", DataViewRowState.Deleted))

        da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        daCol.Update(dtColumn.Select("", "", DataViewRowState.ModifiedCurrent))
        daFormula.Update(dtFormula.Select("", "", DataViewRowState.ModifiedCurrent))

        da.Update(dt.Select("", "", DataViewRowState.Added))
        daCol.Update(dtColumn.Select("", "", DataViewRowState.Added))
        daFormula.Update(dtFormula.Select("", "", DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function

    Public Sub CopyColumn(ByVal source As Integer, ByVal listCol As List(Of Integer))

      For Each ffi As FFormatItem In ItemCollection
        For Each col As Integer In listCol
          Dim fcol As FFormatColumn = Me.ColumnCollection.Item(col)
          Dim fsource As FFormatColumn = Me.ColumnCollection.Item(source)
          ffi.DataCollection.CopyColumn(fsource, source, fcol, col)
        Next
      Next
    End Sub
    ''' <summary>
    ''' Autogen ช่วงวันที่
    ''' 
    ''' </summary>
    ''' <param name="startdate"></param>
    ''' <param name="NumCol"></param>
    ''' <param name="CC"></param>
    ''' <param name="IncChild"></param>
    ''' <remarks></remarks>
    Public Sub IntervalAutoGen(ByVal startdate As Date, ByVal NumCol As Integer, ByVal CC As Decimal, ByVal IncChild As Boolean, ByVal StartCol As Integer)

      Dim oldCol As Integer = CInt(ColumnCollection.Count2) '- 1 'ไม่นับแถวแรก
      'If NumCol > oldCol Then
      '  For i As Integer = oldCol + 1 To NumCol
      '    Dim col As New FFormatColumn
      '    ColumnCollection.Add(col)
      '  Next
      'End If

      If ((StartCol + NumCol) - 1) > oldCol Then
        For i As Integer = 1 To (((StartCol + NumCol) - 1) - oldCol)
          Dim col As New FFormatColumn
          ColumnCollection.Add(col)
        Next
      End If



      'Dim lstInt As New List(Of Integer)
      'Dim source As Integer

      'If ColumnCollection.Count2 >= 2 Then
      '  source = 2
      'Else
      '  source = 0
      'End If

      'For i As Integer = source + 1 To NumCol
      '  lstInt.Add(i)
      'Next



      Dim colEndDate As Date
      Dim colStartDate As Date


      Dim intType As DateInterval
      Select Case Me.AutoType.Value
        Case 2 'month
          intType = DateInterval.Month

        Case 3 'Quarter
          intType = DateInterval.Quarter
        Case 4 'Year
          intType = DateInterval.Year
      End Select

      Dim Costceneter As New CostCenter(CInt(CC))
      Dim int As Integer = 1
      Dim scol As FFormatColumn = ColumnCollection.Item(1)
      Dim widthpercent As Decimal = (100 - scol.WidthPercent) / NumCol
      'For Each col As FFormatColumn In ColumnCollection
      '  If col.LineNumber > 1 AndAlso col.LineNumber <= NumCol + 1 Then
      '    colStartDate = DateAdd(intType, int, startdate)
      '    Dim mon As New CalcCalendar(colStartDate)
      '    col.StartDate = mon.StartPeriodDate(intType)
      '    col.EndDate = mon.EndPeriodDate(intType)
      '    col.Name = mon.Name(intType)
      '    col.WidthPercent = widthpercent
      '    col.Alignment = HorizontalAlignment.Right
      '    col.CostCenter = Costceneter
      '    col.IncludeChildCostCenter = IncChild
      '    col.AccountBook = scol.AccountBook
      '    col.EndAccountBook = scol.EndAccountBook
      '    int += 1
      '  End If
      'Next
      Dim ic As Integer = 1
      For Each col As FFormatColumn In ColumnCollection
        If ic >= StartCol AndAlso ic <= ((NumCol + StartCol) - 1) Then
          colStartDate = DateAdd(intType, int, startdate)
          Dim mon As New CalcCalendar(colStartDate)
          col.StartDate = mon.StartPeriodDate(intType)
          col.EndDate = mon.EndPeriodDate(intType)
          col.Name = mon.Name(intType)
          col.WidthPercent = widthpercent
          col.Alignment = HorizontalAlignment.Right
          col.CostCenter = Costceneter
          col.IncludeChildCostCenter = IncChild
          col.AccountBook = scol.AccountBook
          col.EndAccountBook = scol.EndAccountBook
          int += 1
        End If
        ic += 1
      Next
    End Sub
    Public Sub CostCenterAutogen(ByVal items As BasketItemCollection)

      Dim scol As FFormatColumn = ColumnCollection.Item(1)
      Dim widthpercent As Decimal = (100 - scol.WidthPercent) / items.Count

      For i As Integer = 0 To items.Count - 1 Step 1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim index As Integer = i + 2
        If Me.ColumnCollection.Item(index) Is Nothing Then
          Dim col0 As New FFormatColumn
          Me.ColumnCollection.Add(col0)
        End If

        Dim col As FFormatColumn = Me.ColumnCollection.Item(index)
        Dim mycc As New CostCenter(item.Id)


        col.StartDate = scol.StartDate
        col.EndDate = scol.EndDate
        col.Name = mycc.Code
        col.WidthPercent = widthpercent
        col.Alignment = HorizontalAlignment.Right
        col.CostCenter = mycc
        col.IncludeChildCostCenter = scol.IncludeChildCostCenter
        col.AccountBook = scol.AccountBook
        col.EndAccountBook = scol.EndAccountBook
      Next
    End Sub

#End Region

#Region "IHasName"
    Public Property Name() As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
        OnTabPageTextChanged(Me, New EventArgs)
      End Set
    End Property
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "RptFinancialStatement"
    End Function
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return ""
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'CPName
      dpi = New DocPrintingItem
      dpi.Mapping = "CPName"
      dpi.Value = Me.Companyname
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Header
      dpi = New DocPrintingItem
      dpi.Mapping = "Header"
      dpi.Value = Me.Header
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Condition
      dpi = New DocPrintingItem
      dpi.Mapping = "Condition"
      dpi.Value = Me.Condition
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Unit
      dpi = New DocPrintingItem
      dpi.Mapping = "Unit"
      Dim u As New CodeDescription
      dpi.Value = "(หน่วย:" & u.GetDescription("currencydivider", Me.Divider) & ")"
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return True
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteFFormat}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteFFormat", New SqlParameter() {New SqlParameter("@ff_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.FFormatIsReferencedCannotBeDeleted}")
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

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      Me.Status.Value = -1
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Code = "Copy of " & Me.Code
      Return Me
    End Function
#End Region

    

  End Class

  Public Class FFormatColumn

#Region "Members"
    Private m_FFormat As FFormat
    Private m_linenumber As Integer
    Private m_name As String
    Private m_widthPercent As Decimal
    Private m_alignment As HorizontalAlignment
    Private m_startDate As Date
    Private m_endDate As Date
    Private m_cc As CostCenter
    Private m_includeChildCC As Boolean
    Private m_accountBook As AccountBook
    Private m_endaccountBook As AccountBook
#End Region

#Region "Constructors"
    Public Sub New()
      m_cc = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      m_accountBook = New AccountBook
      m_endaccountBook = New AccountBook
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      m_cc = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      m_accountBook = New AccountBook
      m_endaccountBook = New AccountBook
      Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        Dim drh As New DataRowHelper(dr)
        If dr.Table.Columns.Contains(aliasPrefix & "ffc_linenumber") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffc_linenumber") Then
          .m_linenumber = CInt(dr(aliasPrefix & "ffc_linenumber"))
        End If
        ' Name.
        If dr.Table.Columns.Contains(aliasPrefix & "ffc_name") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffc_name") Then
          .m_name = CStr(dr(aliasPrefix & "ffc_name"))
        End If
        ' Width Percent.
        If dr.Table.Columns.Contains(aliasPrefix & "ffc_widthpercent") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffc_widthpercent") Then
          .m_widthPercent = CDec(dr(aliasPrefix & "ffc_widthpercent"))
        End If
        ' Alignment.
        If dr.Table.Columns.Contains(aliasPrefix & "ffc_alignment") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffc_alignment") Then
          .m_alignment = CType(dr(aliasPrefix & "ffc_alignment"), HorizontalAlignment)
        End If
        ' StartDate.
        If dr.Table.Columns.Contains(aliasPrefix & "ffc_startdate") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffc_startdate") Then
          .m_startDate = CDate(dr(aliasPrefix & "ffc_startdate"))
        End If
        ' EndDate.
        If dr.Table.Columns.Contains(aliasPrefix & "ffc_enddate") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffc_enddate") Then
          .m_endDate = CDate(dr(aliasPrefix & "ffc_enddate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "cc_id") AndAlso Not dr.IsNull(aliasPrefix & "cc_id") Then
          If Not dr.IsNull("cc_id") Then
            .m_cc = New CostCenter(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "ffc_cc") AndAlso Not dr.IsNull(aliasPrefix & "ffc_cc") Then
            .m_cc = New CostCenter(CInt(dr(aliasPrefix & "ffc_cc")))
          End If
        End If

        ' IncludeChild.
        If dr.Table.Columns.Contains(aliasPrefix & "ffc_includechildcc") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffc_includechildcc") Then
          .m_includeChildCC = CBool(dr(aliasPrefix & "ffc_includechildcc"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "ffc_journal") AndAlso Not dr.IsNull(aliasPrefix & "ffc_journal") Then
          .m_accountBook = New AccountBook(CInt(dr(aliasPrefix & "ffc_journal")))
        End If

        If drh.GetValue(Of Integer)("ffc_endjournal") > 0 Then
          .m_endaccountBook = New AccountBook(drh.GetValue(Of Integer)("ffc_endjournal"))
        End If

      End With
    End Sub
#End Region

#Region "Properties"
    Public Property FFormat() As FFormat      Get        Return m_FFormat      End Get      Set(ByVal Value As FFormat)        m_FFormat = Value      End Set    End Property
    Public Property LineNumber() As Integer
      Get
        Return m_linenumber
      End Get
      Set(ByVal Value As Integer)
        m_linenumber = Value
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
    Public Property WidthPercent() As Decimal
      Get
        Return m_widthPercent
      End Get
      Set(ByVal Value As Decimal)
        m_widthPercent = Value
      End Set
    End Property
    Public Property Alignment() As HorizontalAlignment
      Get
        Return m_alignment
      End Get
      Set(ByVal Value As HorizontalAlignment)
        m_alignment = Value
      End Set
    End Property
    Public Property StartDate() As Date
      Get
        Return m_startDate
      End Get
      Set(ByVal Value As Date)
        m_startDate = Value
      End Set
    End Property
    Public Property EndDate() As Date
      Get
        Return m_endDate
      End Get
      Set(ByVal Value As Date)
        m_endDate = Value
      End Set
    End Property
    Public Property CostCenter() As CostCenter      Get        Return m_cc      End Get      Set(ByVal Value As CostCenter)        m_cc = Value      End Set    End Property
    Public Property IncludeChildCostCenter() As Boolean      Get        Return m_includeChildCC      End Get      Set(ByVal Value As Boolean)        m_includeChildCC = Value      End Set    End Property
    Public Property AccountBook() As AccountBook      Get        Return m_accountBook      End Get      Set(ByVal Value As AccountBook)        m_accountBook = Value      End Set    End Property
    Public Property EndAccountBook() As AccountBook      Get        Return m_endaccountBook      End Get      Set(ByVal Value As AccountBook)        m_endaccountBook = Value      End Set    End Property
    Public ReadOnly Property DicGlValue As Dictionary(Of String, Decimal)
      Get
        If m_dicGlValue Is Nothing Then
          RefreshGLValue()
        End If
        Return m_dicGlValue
      End Get
    End Property
#End Region

#Region "Methods"
    Private m_dicGlValue As Dictionary(Of String, Decimal)
    Public Sub RefreshGLValue()

      Dim params(5) As SqlParameter
      params(0) = New SqlParameter("@docdatestart", Me.FFormat.ValidDateOrDBNull(Me.StartDate))
      params(1) = New SqlParameter("@docdateend", Me.FFormat.ValidDateOrDBNull(Me.EndDate))
      params(2) = New SqlParameter("@cc_id", Me.FFormat.ValidIdOrDBNull(Me.CostCenter))
      params(3) = New SqlParameter("@IncludeChildCC", Me.IncludeChildCostCenter)
      params(4) = New SqlParameter("@acctbook_id", Me.FFormat.ValidIdOrDBNull(Me.AccountBook))
      params(5) = New SqlParameter("@endacctbook_id", Me.FFormat.ValidIdOrDBNull(Me.EndAccountBook))
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.FFormat.ConnectionString, CommandType.StoredProcedure, "GetGLValueFromCol", params)

      m_dicGlValue = New Dictionary(Of String, Decimal)

      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        dicGlValue.Add(drh.GetValue(Of String)("key"), drh.GetValue(Of Decimal)("Value"))
      Next

    End Sub
#End Region

  End Class
  <Serializable(), DefaultMember("Item")> _
  Public Class FFormatColumnCollection
    Inherits CollectionBase

#Region "Members"
    Private m_fFormat As FFormat
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal ff As FFormat)
      m_fFormat = ff
      If Not m_fFormat.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetFFormatColumns" _
      , New SqlParameter("@ff_id", m_fFormat.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New FFormatColumn(row, "")
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property FFormat() As FFormat      Get        Return m_fFormat      End Get      Set(ByVal Value As FFormat)        m_fFormat = Value      End Set    End Property
    Default Public Property Item(ByVal index As Integer) As FFormatColumn
      Get
        For Each ffc As FFormatColumn In Me
          If ffc.LineNumber = index Then
            Return ffc
          End If
        Next
      End Get
      Set(ByVal value As FFormatColumn)
        For Each ffc As FFormatColumn In Me
          If ffc.LineNumber = index Then
            MyBase.List.Item(Me.IndexOf(ffc)) = value
            Return
          End If
        Next
      End Set
    End Property
    Public ReadOnly Property Count2 As Decimal
      Get
        Dim ret As Decimal = 0
        For Each col As FFormatColumn In Me
          ret += 1
        Next
        Return ret
      End Get
    End Property
    Public ReadOnly Property StartDate As Date
      Get
        Return Me.Item(1).StartDate
      End Get
    End Property

#End Region

#Region "Class Methods"
    Public Function AllWidthPercent() As Decimal
      Dim ret As Decimal = 0
      For Each item As FFormatColumn In Me
        ret += item.WidthPercent
      Next
      Return ret
    End Function
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each ffc As FFormatColumn In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()

        newRow("ffc_linenumber") = i
        newRow("ffc_name") = ffc.Name
        newRow("ffc_widthpercent") = Configuration.FormatToString(ffc.WidthPercent, 2)
        newRow("ffc_alignment") = CInt(ffc.Alignment)
        newRow("ffc_startdate") = ffc.StartDate
        newRow("ffc_enddate") = ffc.EndDate
        newRow("CCCode") = ffc.CostCenter.Code
        newRow("CCName") = ffc.CostCenter.Name
        newRow("ffc_includechildcc") = ffc.IncludeChildCostCenter
        newRow("JCode") = ffc.AccountBook.Code
        newRow("JName") = ffc.AccountBook.Name
        newRow("EJCode") = ffc.EndAccountBook.Code
        newRow("EJName") = ffc.EndAccountBook.Name
        newRow.Tag = ffc
      Next
    End Sub
    Public Function GetMaxLine() As Integer
      Dim max As Integer = 0
      For Each col As FFormatColumn In Me
        If col.LineNumber > max Then
          max = col.LineNumber
        End If
      Next
      Return max
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As FFormatColumn) As Integer
      value.FFormat = Me.m_fFormat
      If value.LineNumber = 0 Then
        Dim max As Integer = GetMaxLine()
        value.LineNumber = max + 1
      End If
      Dim ret As Integer = MyBase.List.Add(value)
      If Not Me.m_fFormat Is Nothing AndAlso Not Me.m_fFormat.ItemCollection Is Nothing Then
        For Each item As FFormatItem In Me.m_fFormat.ItemCollection
          If Not item.DataCollection Is Nothing Then
            item.DataCollection.RefreshColumn()
          End If
        Next
      End If
      Return ret
    End Function
    Public Sub AddRange(ByVal value As FFormatColumn())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As FFormatColumn) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As FFormatColumn(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As FFormatColumnEnumerator
      Return New FFormatColumnEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As FFormatColumn) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As FFormatColumn)
      value.FFormat = Me.m_fFormat
      MyBase.List.Insert(index, value)
      If Not Me.m_fFormat Is Nothing AndAlso Not Me.m_fFormat.ItemCollection Is Nothing Then
        m_fFormat.ItemCollection.ShiftFormula(index, False, True)
        For Each item As FFormatItem In Me.m_fFormat.ItemCollection
          If Not item.DataCollection Is Nothing Then
            item.DataCollection.RefreshColumn()
          End If
        Next
      End If
    End Sub
    Public Sub Remove(ByVal value As FFormatColumn)
      value.FFormat = Nothing
      MyBase.List.Remove(value)
      If Not Me.m_fFormat Is Nothing AndAlso Not Me.m_fFormat.ItemCollection Is Nothing Then
        m_fFormat.ItemCollection.ShiftFormula(value.LineNumber, False, False)
        For Each item As FFormatItem In Me.m_fFormat.ItemCollection
          If Not item.DataCollection Is Nothing Then
            item.DataCollection.RefreshDeletedColumn()
          End If
        Next
      End If
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
      If Not Me.m_fFormat Is Nothing AndAlso Not Me.m_fFormat.ItemCollection Is Nothing Then
        For Each item As FFormatItem In Me.m_fFormat.ItemCollection
          If Not item.DataCollection Is Nothing Then
            item.DataCollection.RefreshDeletedColumn()
          End If
        Next
      End If
    End Sub

#End Region


    Public Class FFormatColumnEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As FFormatColumnCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, FFormatColumn)
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
  Public Class FFormatItemType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "financialstatement_list"
      End Get
    End Property
#End Region

  End Class
  Public Class FFormatItem

#Region "Members"
    Private m_FFormat As FFormat
    Private m_linenumber As Integer
    Private m_code As String
    Private m_style As String
    Private m_isinvisible As Boolean
    Private m_isnewpage As Boolean
    Private m_linestyle As Integer
    Private m_dataCollection As FFormatDataCollection
#End Region

#Region "Constructors"
    Public Sub New(ByVal fformat As FFormat)
      Me.FFormat = fformat
      m_dataCollection = New FFormatDataCollection(Me)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal fformat As FFormat)
      Me.FFormat = fformat
      Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "ffi_linenumber") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffi_linenumber") Then
          .m_linenumber = CInt(dr(aliasPrefix & "ffi_linenumber"))
        End If
        ' Code.
        If dr.Table.Columns.Contains(aliasPrefix & "ffi_code") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffi_code") Then
          .m_code = CStr(dr(aliasPrefix & "ffi_code"))
        End If
        ' Style.
        If dr.Table.Columns.Contains(aliasPrefix & "ffi_style") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffi_style") Then
          .m_style = CStr(dr(aliasPrefix & "ffi_style"))
        End If
        ' is NewPage.
        If dr.Table.Columns.Contains(aliasPrefix & "ffi_isnewpage") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffi_isnewpage") Then
          .m_isnewpage = CBool(dr(aliasPrefix & "ffi_isnewpage"))
        End If
        ' is Invisible.
        If dr.Table.Columns.Contains(aliasPrefix & "ffi_invisible") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffi_invisible") Then
          .m_isinvisible = CBool(dr(aliasPrefix & "ffi_invisible"))
        End If
        ' line style.
        If dr.Table.Columns.Contains(aliasPrefix & "ffi_linestyle") _
        AndAlso Not dr.IsNull(aliasPrefix & "ffi_linestyle") Then
          .m_linestyle = CInt(dr(aliasPrefix & "ffi_linestyle"))
        End If

      End With
      m_dataCollection = New FFormatDataCollection(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property FFormat() As FFormat      Get        Return m_FFormat      End Get      Set(ByVal Value As FFormat)        m_FFormat = Value      End Set    End Property
    Public Property DataCollection() As FFormatDataCollection      Get        Return m_dataCollection      End Get      Set(ByVal Value As FFormatDataCollection)        m_dataCollection = Value      End Set    End Property
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
    Public Property Style() As String
      Get
        Return m_style
      End Get
      Set(ByVal Value As String)
        m_style = Value
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
    Public Property IsInvisible() As Boolean
      Get
        Return m_isinvisible
      End Get
      Set(ByVal Value As Boolean)
        m_isinvisible = Value
      End Set
    End Property
    Public Property LineStyle() As Integer
      Get
        Return m_linestyle
      End Get
      Set(ByVal Value As Integer)
        m_linestyle = Value
      End Set
    End Property
#End Region

#Region "Methods"

#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class FFormatItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_fFormat As FFormat
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal ff As FFormat)
      m_fFormat = ff
      If Not m_fFormat.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetFFormatItems" _
      , New SqlParameter("@ff_id", m_fFormat.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New FFormatItem(row, "", m_fFormat)
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property FFormat() As FFormat      Get        Return m_fFormat      End Get      Set(ByVal Value As FFormat)        m_fFormat = Value      End Set    End Property
    Default Public Property Item(ByVal index As Integer) As FFormatItem
      Get
        Return CType(MyBase.List.Item(index), FFormatItem)
      End Get
      Set(ByVal value As FFormatItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetNewPageIndices() As ArrayList
      Dim arr As New ArrayList
      Dim i As Integer
      For Each item As FFormatItem In Me
        If item.IsNewPage And i <> 0 Then
          arr.Add(i)
        End If
        i += 1
      Next
      Return arr
    End Function
    Public Function GetPageCountSets() As ArrayList
      Dim arr As New ArrayList
      Dim indices As ArrayList = Me.GetNewPageIndices
      If indices.Count > 0 Then
        arr.Add(indices(0)) 'ชุดแรก
        If indices.Count > 1 Then
          For i As Integer = 0 To indices.Count - 2
            arr.Add(CInt(indices(i + 1)) - CInt(indices(i)))
          Next
        End If
        arr.Add(Me.Count - CInt(indices(indices.Count - 1)))  'ชุดสุดท้าย
      Else
        arr.Add(Me.Count)
      End If
      Dim currRow As Integer = 0
      For i As Integer = 0 To arr.Count - 1
        Dim start As Integer = currRow
        Dim subtract As Integer = 0
        For n As Integer = start To CInt(arr(i)) - 1
          If Me(n).IsInvisible Then
            subtract += 1
          End If
          currRow += 1
        Next
        arr(i) = CInt(arr(i)) - subtract
      Next
      Return arr
    End Function
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each ffi As FFormatItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("ffi_linenumber") = i
        ffi.LineNumber = i
        ffi.Code = ffi.LineNumber.ToString
        newRow("ffi_code") = ffi.Code

        Dim n As Integer = 0
        For Each col As FFormatColumn In Me.m_fFormat.ColumnCollection
          n += 1
          Dim fff As FFormatData = ffi.DataCollection(col)
          If Not fff Is Nothing Then
            newRow("ffi_formula" & (n).ToString) = fff.FormulaText
          End If
        Next

        newRow("ffi_isnewpage") = ffi.IsNewPage
        newRow("ffi_linestyle") = ffi.LineStyle
        newRow("ffi_invisible") = ffi.IsInvisible

        newRow.Tag = ffi
      Next
    End Sub
    Public Sub PopulateValue(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      Me.FFormat.RefreshGLValue()
      For Each ffi As FFormatItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("ffi_linenumber") = i
        ffi.LineNumber = i
        ffi.Code = ffi.LineNumber.ToString
        newRow("ffi_code") = ffi.Code

        Dim n As Integer = 0
        For Each col As FFormatColumn In Me.m_fFormat.ColumnCollection
          n += 1
          Dim fff As FFormatData = ffi.DataCollection(col)
          If Not fff Is Nothing Then
            Dim val As Decimal = 0
            Dim valString As String = fff.FormulaText
            If fff.IsAcctFormula Or fff.IsFormula Then
              val = fff.GetUltimateValue
              Dim sp As String = ""
              For x As Integer = 1 To fff.Indentation
                sp &= " "
              Next
              valString = sp & Configuration.FormatToString(val, DigitConfig.Price)
            End If
            newRow("ffi_formula" & (n).ToString) = valString
          End If
        Next

        newRow("ffi_isnewpage") = ffi.IsNewPage
        newRow("ffi_linestyle") = ffi.LineStyle
        newRow("ffi_invisible") = ffi.IsInvisible

        newRow.Tag = ffi
      Next
    End Sub
    Public Function GetMaxLine() As Integer
      Dim max As Integer = 0
      For Each item As FFormatItem In Me
        If item.LineNumber > max Then
          max = item.LineNumber
        End If
      Next
      Return max
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As FFormatItem) As Integer
      value.FFormat = Me.m_fFormat
      If value.LineNumber = 0 Then
        Dim max As Integer = GetMaxLine()
        value.LineNumber = max + 1
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As FFormatItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As FFormatItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As FFormatItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As FFormatItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As FFormatItemEnumerator
      Return New FFormatItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As FFormatItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As FFormatItem)
      value.FFormat = Me.m_fFormat
      MyBase.List.Insert(index, value)
      ShiftFormula(index, True, True)
    End Sub
    Public Sub Remove(ByVal value As FFormatItem)
      value.FFormat = Nothing
      MyBase.List.Remove(value)
      ShiftFormula(value.LineNumber, True, False)
    End Sub
    Public Sub Remove(ByVal value As FFormatItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
    Public Sub ShiftFormula(ByVal index As Integer, ByVal IsRow As Boolean, ByVal IsInsert As Boolean)
      Dim i As Integer = 0
      For Each ffi As FFormatItem In Me
        i += 1

        For Each col As FFormatColumn In Me.m_fFormat.ColumnCollection
          Dim fff As FFormatData = ffi.DataCollection(col)
          If Not fff Is Nothing Then
            If fff.IsFormula Then
              'ค่า linenumber ใน ffi น่าจะยังเป็นของเดิม
              fff.ShiftFormula(index, IsRow, IsInsert)
            End If
          End If
        Next


      Next
    End Sub
#End Region


    Public Class FFormatItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As FFormatItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, FFormatItem)
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

  Public Class FFormatData

#Region "Members"
    Private m_column As FFormatColumn
    Private m_item As FFormatItem
    Private m_style As String
    Private m_formula As String
    Private m_linestyle As Integer
    Private m_indentation As Integer

    Public Const AccountCodePattern As String = "\|(?<AcctCode>[^\|]+)\|"
    Public Const ColumnFormulaPettern As String = "([A-Z]{1,2})(\d+)"
    Public Const ColumnFormulaWSignPettern As String = "([+-/*^]?[A-Z]{1,2})(\d+)"
    Public Const ColumnDigitFormulaPettern As String = "(\d+)"
    Public Const ColumnStrFormulaWSignPettern As String = "([-+/*]?[A-Za-z]+)"
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal item As FFormatItem)
      Me.Item = item
      Me.Style = Me.Item.Style
      Me.Linestyle = item.LineStyle
      Construct(dr, aliasPrefix)
    End Sub
    Public Sub Clone(ByVal f As FFormatData)
      Me.Formula = f.Formula
      Me.Style = f.Style
      Me.Linestyle = f.Linestyle
      Me.Indentation = f.Indentation
    End Sub
    Public Sub Copy(ByVal f As FFormatData, ByVal source As Integer, ByVal col As Integer)
      Me.Style = f.Style
      Me.Linestyle = f.Linestyle
      Me.Indentation = f.Indentation
      If f.IsFormula Then
        Dim redigit As New Regex(ColumnDigitFormulaPettern)
        Dim restr As New Regex("([A-Z]{1,2})")
        Dim resign As New Regex("[+-/*^]?")
        Dim list As New List(Of String)
        Dim ShiftList As New List(Of String)
        list = f.GetVariable
        Dim difCol As Integer = CInt((col - source))
        For Each strv As String In list
          Dim n As Integer = CInt(redigit.Match(strv).ToString)
          Dim strws As String = CStr(restr.Match(strv).ToString)
          Dim sign As String = CStr(resign.Match(strv).ToString)
          

          Dim i As Integer = TextHelper.StringHelper.GetExcelColumnIndex(strws)
          If i + difCol >= 1 Then
            i = i + difCol
          Else
            i = 1
          End If
          strws = TextHelper.StringHelper.GetExcelColumnString(i)

          ShiftList.Add(sign + strws + n.ToString)
        Next
        Me.Formula = "=" + String.Join("", ShiftList)
      Else
        Me.Formula = f.Formula
      End If
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        ' Style.
        If dr.Table.Columns.Contains(aliasPrefix & "fff_style") _
        AndAlso Not dr.IsNull(aliasPrefix & "fff_style") Then
          .m_style = CStr(dr(aliasPrefix & "fff_style"))
        End If
        ' Formula.
        If dr.Table.Columns.Contains(aliasPrefix & "fff_formula") _
        AndAlso Not dr.IsNull(aliasPrefix & "fff_formula") Then
          .m_formula = CStr(dr(aliasPrefix & "fff_formula"))
        End If
        ' line style.
        If dr.Table.Columns.Contains(aliasPrefix & "fff_linestyle") _
        AndAlso Not dr.IsNull(aliasPrefix & "fff_linestyle") Then
          .m_linestyle = CInt(dr(aliasPrefix & "fff_linestyle"))
        End If
        ' Column Id.
        If dr.Table.Columns.Contains(aliasPrefix & "fff_ffc") _
        AndAlso Not dr.IsNull(aliasPrefix & "fff_ffc") Then
          If Not m_item Is Nothing Then
            If Not m_item.FFormat Is Nothing Then
              .m_column = m_item.FFormat.ColumnCollection(CInt(dr(aliasPrefix & "fff_ffc")))
            End If
          End If
        End If
        ' Idention.
        If dr.Table.Columns.Contains(aliasPrefix & "fff_indentation") _
        AndAlso Not dr.IsNull(aliasPrefix & "fff_indentation") Then
          .m_indentation = CInt(dr(aliasPrefix & "fff_indentation"))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property Column() As FFormatColumn      Get        Return m_column      End Get      Set(ByVal Value As FFormatColumn)        m_column = Value      End Set    End Property    Public Property Indentation() As Integer
      Get
        Return m_indentation
      End Get
      Set(ByVal Value As Integer)
        m_indentation = Value
      End Set
    End Property    Public Property Item() As FFormatItem      Get        Return m_item      End Get      Set(ByVal Value As FFormatItem)        m_item = Value      End Set    End Property    Public Property Style() As String      Get        Return m_style      End Get      Set(ByVal Value As String)        m_style = Value      End Set    End Property    Public Property Formula() As String      Get        Return m_formula      End Get      Set(ByVal Value As String)        m_formula = Value      End Set    End Property    Public ReadOnly Property FormulaText() As String      Get        Dim sp As String = ""
        For i As Integer = 1 To Me.Indentation
          sp &= " "
        Next        Return sp & m_formula      End Get    End Property    Public Property Linestyle() As Integer      Get        Return m_linestyle      End Get      Set(ByVal Value As Integer)        m_linestyle = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Function GetUltimateValue() As Decimal
      If Me.IsFormula Then
        Return GetValue()
      End If
      If Me.IsAcctFormula Then
        Return GetAcctValue()
      End If
    End Function
    Public Function IsFormula() As Boolean
      If Me.Formula Is Nothing OrElse Me.Formula.Length = 0 Then
        Return False
      End If
      Return Me.Formula.StartsWith("=")
    End Function
    Public Function GetValue() As Decimal
      Try
        If Not IsFormula() Then
          Return 0
        End If
        Dim re As New Regex(ColumnFormulaPettern)
        Dim tmpFormula As String = Me.Formula.Replace("=", "")
        Do While re.IsMatch(tmpFormula)
          tmpFormula = re.Replace(tmpFormula, AddressOf ReplaceData)
        Loop
        Return CDec(TextHelper.TextParser.Evaluate(tmpFormula))
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Function
    Private Function GetVariable() As List(Of String)
      Try
        If Not IsFormula() Then
          Return Nothing
        End If
        Dim list As New List(Of String)
        Dim re As New Regex(ColumnFormulaWSignPettern)
        Dim tmpFormula As String = Me.Formula.Replace("=", "")
        Dim n As Integer = 1
        Do While re.IsMatch(tmpFormula)
          Dim v As String = re.Match(tmpFormula).ToString
          tmpFormula = tmpFormula.Replace(v, "")
          list.Add(v)
        Loop
        Return list
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Function
    Public Sub ShiftFormula(ByVal index As Integer, ByVal isRow As Boolean, ByVal IsInsert As Boolean)
      Try
        If Not IsFormula() Then
          Return
        End If
        Dim redigit As New Regex(ColumnDigitFormulaPettern)
        Dim restr As New Regex(ColumnStrFormulaWSignPettern)
        Dim list As New List(Of String)
        Dim ShiftList As New List(Of String)
        list = Me.GetVariable
        For Each strv As String In list
          Dim n As Integer = CInt(redigit.Match(strv).ToString)
          Dim str As String = CStr(restr.Match(strv).ToString)
          If isRow Then
            'Index จะมาลดจาก linenumber 1 จาก Insert นะ
            If n > index Then
              If IsInsert Then
                n = n + 1
              Else
                n = n - 1
                If n < 1 Then
                  n = 1
                End If
              End If
            End If
          Else
            Dim i As Integer = TextHelper.StringHelper.GetExcelColumnIndex(str)
            If i > index Then
              If IsInsert Then
                i = i + 1
              Else
                i = i - 1
                If i < 1 Then
                  i = 1
                End If
              End If
            End If
            str = TextHelper.StringHelper.GetExcelColumnString(i)
          End If
          
          ShiftList.Add(str + n.ToString)
        Next
        Me.Formula = "=" + String.Join("", ShiftList)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ShiftFormula(ByVal oldrowI As Integer, ByVal oldcolI As Integer, _
                            ByVal newrowI As Integer, ByVal newcolI As Integer)
      Try
        If Not IsFormula() Then
          Return
        End If
        Dim redigit As New Regex(ColumnDigitFormulaPettern)
        Dim restr As New Regex("([A-Z]{1,2})")
        Dim resign As New Regex("[+-/*^]?")
        Dim list As New List(Of String)
        Dim ShiftList As New List(Of String)
        list = Me.GetVariable
        Dim difCol As Integer = CInt((newcolI - oldcolI) / 2)
        Dim difRow As Integer = newrowI - oldrowI
        For Each strv As String In list
          Dim n As Integer = CInt(redigit.Match(strv).ToString)
          Dim strws As String = CStr(restr.Match(strv).ToString)
          Dim sign As String = CStr(resign.Match(strv).ToString)
          'Index จะมาลดจาก linenumber 1 จาก Insert นะ
          If n + difRow >= 1 Then
            n = n + difRow
          Else
            n = 1
          End If

          Dim i As Integer = TextHelper.StringHelper.GetExcelColumnIndex(strws)
          If i + difCol >= 1 Then
            i = i + difCol
          Else
            i = 1
          End If
          strws = TextHelper.StringHelper.GetExcelColumnString(i)

          ShiftList.Add(sign + strws + n.ToString)
        Next
        Me.Formula = "=" + String.Join("", ShiftList)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Function ReplaceData(ByVal m As Match) As String
      Dim dat As FFormatData = Me.m_item.FFormat.GetDataFromExcelRowCol(m.Value)
      If dat Is Me Then
        Throw New Exception("Cyclic" & m.Value)
      End If
      Return dat.GetUltimateValue.ToString
    End Function
    Public Function IsAcctFormula() As Boolean
      If Me.Formula Is Nothing OrElse Me.Formula.Length = 0 Then
        Return False
      End If
      Dim re As New Regex(AccountCodePattern)
      Return re.IsMatch(Me.Formula)
    End Function
    Public Function GetAcctValue() As Decimal
      If Not IsAcctFormula() Then
        Return 0
      End If
      Dim val As Decimal = 0
      Dim re As New Regex(AccountCodePattern)
      For Each m As Match In re.Matches(Me.Formula, Me.AccountCodePattern)
        Dim acct As New Account(m.Groups("AcctCode").Value)
        If acct.Originated Then
          val += Me.m_item.FFormat.GetGLValueFromAccount(Me.Column, acct)
        End If
      Next
      Return val
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class FFormatDataCollection
    Inherits CollectionBase

#Region "Members"
    Private m_FFormatItem As FFormatItem
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal ffi As FFormatItem)
      m_FFormatItem = ffi
      If Not ffi.FFormat Is Nothing Then
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

        Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "GetFFormatDatas" _
        , New SqlParameter("@fff_ff", ffi.FFormat.Id) _
        , New SqlParameter("@fff_ffi", ffi.LineNumber) _
        )

        For Each row As DataRow In ds.Tables(0).Rows
          Dim item As New FFormatData(row, "", ffi)
          Me.Add(item)
        Next

        RefreshColumn()

      End If
    End Sub
    Public Sub RefreshColumn()
      If m_FFormatItem.FFormat Is Nothing Then
        Return
      End If
      For Each col As FFormatColumn In m_FFormatItem.FFormat.ColumnCollection
        If Not Me.Contains(col) Then
          Dim item As New FFormatData
          item.Column = col
          Me.Add(item)
        End If
      Next
    End Sub
    Public Sub RefreshDeletedColumn()
      If m_FFormatItem.FFormat Is Nothing Then
        Return
      End If
      Dim dataToRemove As New ArrayList
      For Each myItem As FFormatData In Me
        If myItem.Column Is Nothing Then
          If Not dataToRemove.Contains(myItem) Then
            dataToRemove.Add(myItem)
          End If
        ElseIf Not m_FFormatItem.FFormat.ColumnCollection.Contains(myItem.Column) Then
          If Not dataToRemove.Contains(myItem) Then
            dataToRemove.Add(myItem)
          End If
        Else
          'MessageBox.Show("alive:" & myItem.Column.LineNumber.ToString)
        End If
      Next
      For Each itemToRemove As FFormatData In dataToRemove
        Me.Remove(itemToRemove)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property FFormatitem() As FFormatItem      Get        Return m_FFormatItem      End Get      Set(ByVal Value As FFormatItem)        m_FFormatItem = Value      End Set    End Property
    Default Public Property Item(ByVal col As FFormatColumn) As FFormatData
      Get
        For Each fff As FFormatData In Me
          If fff.Column Is col Then
            Return fff
          End If
        Next
      End Get
      Set(ByVal value As FFormatData)
        For Each fff As FFormatData In Me
          If fff.Column Is col Then
            MyBase.List.Item(Me.IndexOf(fff)) = value
            Return
          End If
        Next
        'MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"

#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As FFormatData) As Integer
      value.Item = Me.m_FFormatItem
      Return MyBase.List.Add(value)
    End Function
    'Public Sub AddRange(ByVal value As FFormatDataCollection)
    '    For i As Integer = 0 To value.Count - 1
    '        Me.Add(value(i))
    '    Next
    'End Sub
    Public Sub AddRange(ByVal value As FFormatData())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As FFormatData) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Function Contains(ByVal value As FFormatColumn) As Boolean
      For Each fff As FFormatData In Me
        If fff.Column Is value Then
          Return True
        End If
      Next
      Return False
    End Function
    Public Sub CopyTo(ByVal array As FFormatData(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As FFormatDataEnumerator
      Return New FFormatDataEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As FFormatData) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As FFormatData)
      value.Item = Me.m_FFormatItem
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As FFormatData)
      value.Item = Me.m_FFormatItem
      MyBase.List.Remove(value)
    End Sub
    'Public Sub Remove(ByVal value As FFormatDataCollection)
    '    For i As Integer = 0 To value.Count - 1
    '        Me.Remove(value(col))
    '    Next
    'End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class FFormatDataEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As FFormatDataCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, FFormatData)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class

    Public Sub CopyColumn(ByVal fsource As FFormatColumn, ByVal source As Integer, ByVal fcol As FFormatColumn, ByVal col As Integer)
      Me.Item(fcol).Copy(Me.Item(fsource), source, col)
    End Sub

  End Class
End Namespace
