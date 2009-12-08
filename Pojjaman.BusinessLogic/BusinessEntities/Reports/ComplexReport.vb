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
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class ComplexReportField
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
        Private m_name As String
        Private m_sproc As String
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
                .m_name = ""
                .m_sproc = ""
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_sprocname") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_sprocname") Then
                    .m_sproc = CStr(dr(aliasPrefix & Me.Prefix & "_sprocname"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Sproc() As String
            Get
                Return m_sproc
            End Get
            Set(ByVal Value As String)
                m_sproc = Value
            End Set
        End Property
        Public Property Name() As String Implements IHasName.Name
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "ComplexReportField"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.ComplexReportField.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.ComplexReportField"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.ComplexReportField"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.ComplexReportField.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "crptfield"
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
        Public Shared Function GetComplexReportField(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldFsFormat As ComplexReportField) As Boolean
            Dim newFsFormat As New ComplexReportField(txtCode.Text)
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
#End Region

    End Class
    Public Class ComplexReport
        Inherits SimpleBusinessEntityBase
        Implements IHasName, IPrintableEntity, IDuplicable

#Region "Members"
        Private m_name As String
        Private m_note As String
        Private m_header As String
        Private m_condition As String
        Private m_companyname As String
        Private m_useCompanyNameInOption As Boolean
        Private m_isDefault As Boolean
        Private m_itemCollection As ComplexReportItemCollection
        Private m_columnCollection As ComplexReportColumnCollection

        Private m_divider As Integer = 1
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
                .m_note = ""
                m_header = ""
                m_condition = ""
                m_companyname = CStr(Configuration.GetConfig("CompanyName"))
                m_columnCollection = New ComplexReportColumnCollection(Me)
                m_itemCollection = New ComplexReportItemCollection(Me)
                m_useCompanyNameInOption = True
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
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

                m_columnCollection = New ComplexReportColumnCollection(Me) 'ต้องอยู่ก่อน Item!!!!
                m_itemCollection = New ComplexReportItemCollection(Me)

            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Divider() As Integer            Get                Return m_divider            End Get            Set(ByVal Value As Integer)                m_divider = Value            End Set        End Property
        Public Property Header() As String            Get                Return m_header            End Get            Set(ByVal Value As String)                m_header = Value            End Set        End Property        Public Property Condition() As String            Get                Return m_condition            End Get            Set(ByVal Value As String)                m_condition = Value            End Set        End Property        Public Property Companyname() As String            Get                If UseCompanyNameInOption Then                    Return CStr(Configuration.GetConfig("CompanyName"))
                End If                Return m_companyname            End Get            Set(ByVal Value As String)                m_companyname = Value            End Set        End Property        Public Property UseCompanyNameInOption() As Boolean            Get                Return m_useCompanyNameInOption            End Get            Set(ByVal Value As Boolean)                m_useCompanyNameInOption = Value            End Set        End Property
        Public Property ColumnCollection() As ComplexReportColumnCollection
            Get
                Return Me.m_columnCollection
            End Get
            Set(ByVal Value As ComplexReportColumnCollection)
                Me.m_columnCollection = Value
            End Set
        End Property
        Public Property ItemCollection() As ComplexReportItemCollection
            Get
                Return Me.m_itemCollection
            End Get
            Set(ByVal Value As ComplexReportItemCollection)
                Me.m_itemCollection = Value
            End Set
        End Property
        Public Property IsDefault() As Boolean            Get                Return m_isDefault            End Get            Set(ByVal Value As Boolean)                m_isDefault = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "ComplexReport"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.ComplexReport.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.ComplexReport"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.ComplexReport"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.ComplexReport.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "crpt"
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
            Dim myDatatable As New TreeTable("ComplexReportColumn")
            myDatatable.Columns.Add(New DataColumn("crptc_linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("crptc_name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("crptc_widthpercent", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("crptc_alignment", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("CCCode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("CCButton", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("CCName", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("crptc_includechildcc", GetType(Boolean)))
            myDatatable.Columns.Add(New DataColumn("LCICode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("LCIButton", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("LCIName", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("crptc_isnotlci", GetType(Boolean)))
            Dim dateCol As New DataColumn("crptc_startdate", GetType(Date))
            dateCol.DefaultValue = Date.MinValue
            myDatatable.Columns.Add(dateCol)

            dateCol = New DataColumn("crptc_enddate", GetType(Date))
            dateCol.DefaultValue = Date.MinValue
            myDatatable.Columns.Add(dateCol)


            Return myDatatable
        End Function
        Public Shared Sub Populate(ByVal tvGroup As TreeView, ByVal filters() As Filter)
            Dim ds As DataSet = GetComplexReportDataset(filters)
            Populate(tvGroup, ds)
        End Sub
        Public Shared Sub Populate(ByVal tvGroup As TreeView)
            Dim ds As DataSet = GetComplexReportDataset()
            Populate(tvGroup, ds)
        End Sub
        Private Shared Sub Populate(ByVal tvGroup As TreeView, ByVal ds As DataSet)
            Dim dtType As DataTable = ds.Tables(0)  ' Codedescription
            Dim dtFormat As DataTable = ds.Tables(1)   ' ComplexReport
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode
            For Each row As DataRow In dtType.Rows
                If row("code_description").ToString <> currentGroupNode.Text Then
                    currentGroupNode = tvGroup.Nodes.Add(row("code_description").ToString)
                    currentGroupNode.Tag = New IdValuePair(CInt(row("code_value")), "reporttype")
                End If
                Dim childRows As DataRow() = dtFormat.Select("crpt_reporttype = " & row("code_value").ToString)
                For Each childRow As DataRow In childRows
                    Dim childNode As TreeNode = currentGroupNode.Nodes.Add(childRow("crpt_code").ToString & " - " & childRow("crpt_name").ToString)
                    childNode.Tag = New IdValuePair(CInt(childRow("crpt_id")), "ComplexReport")
                Next
            Next
        End Sub
        Private Shared Function GetComplexReportDataset() As DataSet
            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetComplexReportList")
            Return ds
        End Function
        Private Shared Function GetComplexReportDataset(ByVal filters() As Filter) As DataSet
            Dim params() As SqlParameter
            If Not filters Is Nothing AndAlso filters.Length > 0 Then
                ReDim params(filters.Length - 1)
                For i As Integer = 0 To filters.Length - 1
                    params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
                Next
            End If
            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetComplexReportList", params)
            Return ds
        End Function
        Public Shared Function GetComplexReport(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldFsFormat As ComplexReport) As Boolean
            Dim newFsFormat As New ComplexReport(txtCode.Text)
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
            Dim myDatatable As New TreeTable("ComplexReportItem")

            myDatatable.Columns.Add(New DataColumn("crpti_linenumber", GetType(Integer)))

            myDatatable.Columns.Add(New DataColumn("crpti_code", GetType(String)))

            Dim i As Integer = 0
            For Each col As ComplexReportColumn In Me.ColumnCollection
                i += 1
                myDatatable.Columns.Add(New DataColumn("crpti_formula" & i.ToString, GetType(String)))
                myDatatable.Columns.Add(New DataColumn("btn_account" & i.ToString, GetType(String)))
            Next

            myDatatable.Columns.Add(New DataColumn("crpti_isnewpage", GetType(Boolean)))
            myDatatable.Columns.Add(New DataColumn("crpti_linestyle", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("crpti_invisible", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("crpti_style", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("btn_style", GetType(String)))

            Return myDatatable
        End Function
        Public Function CreateValueTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "ComplexReportItem"

            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            ' line number 
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "crpti_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetail.GridLineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "crpti_linenumber"

            ' rownum หมายเลข line number
            Dim csCode As New TreeTextColumn
            csCode.MappingName = "crpti_code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetail.GridCodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 45
            csCode.ReadOnly = True
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Center
            csCode.TextBox.Name = "crpti_code"

            Dim csIsInvisible As New DataGridCheckBoxColumn
            csIsInvisible.MappingName = "crpti_invisible"
            csIsInvisible.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetail.GridIsInvisibleHeaderText}")
            csIsInvisible.Width = 50
            csIsInvisible.ReadOnly = True
            csIsInvisible.InvisibleWhenUnspcified = True

            'dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)

            Dim i As Integer = 0
            For Each col As ComplexReportColumn In Me.ColumnCollection
                i += 1
                Dim csFormula As New TreeTextColumn
                csFormula.MappingName = "crpti_formula" & i.ToString
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
            dst.MappingName = "ComplexReportItem"

            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            ' line number 
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "crpti_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetail.GridLineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "crpti_linenumber"

            ' rownum หมายเลข line number
            Dim csCode As New TreeTextColumn
            csCode.MappingName = "crpti_code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetail.GridCodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 45
            csCode.ReadOnly = True
            csCode.Alignment = HorizontalAlignment.Center
            csCode.DataAlignment = HorizontalAlignment.Center
            csCode.TextBox.Name = "crpti_code"

            Dim csIsNewpage As New DataGridCheckBoxColumn(Me.ColumnCollection.Count * 2 + 1)
            csIsNewpage.MappingName = "crpti_isnewpage"
            csIsNewpage.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetail.GridIsNewPageHeaderText}")
            csIsNewpage.Width = 70
            csIsNewpage.InvisibleWhenUnspcified = True

            Dim csIsInvisible As New DataGridCheckBoxColumn(Me.ColumnCollection.Count * 2 + 2)
            csIsInvisible.MappingName = "crpti_invisible"
            csIsInvisible.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetail.GridIsInvisibleHeaderText}")
            csIsInvisible.Width = 50
            csIsInvisible.InvisibleWhenUnspcified = True

            Dim csLineStyle As DataGridComboColumn
            csLineStyle = New DataGridComboColumn("crpti_linestyle" _
                , CodeDescription.GetCodeList("line_style") _
                , "code_description", "code_value")
            csLineStyle.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetail.GridLineStyleHeaderText}")
            csLineStyle.NullText = String.Empty
            'csLineStyle.ReadOnly = False
            csLineStyle.Alignment = HorizontalAlignment.Center


            'dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)

            Dim i As Integer = 0
            For Each col As ComplexReportColumn In Me.ColumnCollection
                i += 1
                Dim csFormula As New TreeTextColumn
                csFormula.MappingName = "crpti_formula" & i.ToString
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
        Public Function GetValueFromFilter(ByVal col As ComplexReportColumn, ByVal field As ComplexReportField) As Object
            Dim params(5) As SqlParameter
            params(0) = New SqlParameter("@docdatestart", ValidDateOrDBNull(col.StartDate))
            params(1) = New SqlParameter("@docdateend", ValidDateOrDBNull(col.EndDate))
            params(2) = New SqlParameter("@cc_id", ValidIdOrDBNull(col.CostCenter))
            params(3) = New SqlParameter("@lci_id", ValidIdOrDBNull(col.LCI))
            params(4) = New SqlParameter("@IncludeChildCC", col.IncludeChildCostCenter)
            params(5) = New SqlParameter("@IsNotLCI", col.IsNotLci)
            Try
                Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, field.Sproc, params)
                If ds.Tables(0).Rows.Count > 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0)(0)) Then
                        Return ds.Tables(0).Rows(0)(0)
                    End If
                End If
            Catch ex As Exception
                Return 0
            End Try
            Return 0
        End Function
        Public Function GetDataFromExcelRowCol(ByVal pattern As String) As ComplexReportData
            Dim re As New Regex(ComplexReportData.ColumnFormulaPettern)
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
                    paramArrayList.Add(New SqlParameter("@crpt_id", Me.Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False
                paramArrayList.Add(New SqlParameter("@crpt_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@crpt_name", Me.Name))
                paramArrayList.Add(New SqlParameter("@crpt_note", Me.Note))
                paramArrayList.Add(New SqlParameter("@crpt_isdefault", Me.IsDefault))
                paramArrayList.Add(New SqlParameter("@crpt_header", Me.Header))
                paramArrayList.Add(New SqlParameter("@crpt_condition", Me.Condition))
                paramArrayList.Add(New SqlParameter("@crpt_companyname", Me.Companyname))
                paramArrayList.Add(New SqlParameter("@crpt_usecompanynameinoption", Me.UseCompanyNameInOption))

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
                Dim daCol As New SqlDataAdapter("Select * from ComplexReportColumn where crptc_crpt=" & Me.Id, conn)
                Dim da As New SqlDataAdapter("Select * from ComplexReportitem where crpti_crpt=" & Me.Id, conn)
                Dim daFormula As New SqlDataAdapter("select * from ComplexReportFormula where crptf_crpt=" & Me.Id, conn)

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
                da.FillSchema(ds, SchemaType.Mapped, "ComplexReportitem")
                da.Fill(ds, "ComplexReportitem")

                cmdBuilder = New SqlCommandBuilder(daCol)
                daCol.SelectCommand.Transaction = trans
                daCol.DeleteCommand = cmdBuilder.GetDeleteCommand
                daCol.DeleteCommand.Transaction = trans
                daCol.InsertCommand = cmdBuilder.GetInsertCommand
                daCol.InsertCommand.Transaction = trans
                daCol.UpdateCommand = cmdBuilder.GetUpdateCommand
                daCol.UpdateCommand.Transaction = trans
                cmdBuilder = Nothing
                daCol.FillSchema(ds, SchemaType.Mapped, "ComplexReportColumn")
                daCol.Fill(ds, "ComplexReportColumn")

                cmdBuilder = New SqlCommandBuilder(daFormula)
                daFormula.SelectCommand.Transaction = trans
                cmdBuilder.GetDeleteCommand.Transaction = trans
                cmdBuilder.GetInsertCommand.Transaction = trans
                cmdBuilder.GetUpdateCommand.Transaction = trans
                cmdBuilder = Nothing
                daFormula.FillSchema(ds, SchemaType.Mapped, "ComplexReportFormula")
                daFormula.Fill(ds, "ComplexReportFormula")

                Dim dt As DataTable = ds.Tables("ComplexReportitem")
                Dim dtColumn As DataTable = ds.Tables("ComplexReportColumn")
                Dim dtFormula As DataTable = ds.Tables("ComplexReportFormula")

                For Each row As DataRow In dtFormula.Rows
                    row.Delete()
                Next
                For Each row As DataRow In dt.Rows
                    row.Delete()
                Next

                With ds.Tables("ComplexReportColumn")
                    Dim rowsToDelete As New ArrayList
                    For Each dr As DataRow In .Rows
                        Dim found As Boolean = False
                        For Each testCol As ComplexReportColumn In Me.ColumnCollection
                            If testCol.LineNumber = CInt(dr("crptc_linenumber")) Then
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
                    For Each item As ComplexReportColumn In Me.ColumnCollection
                        Dim drs As DataRow() = .Select("crptc_linenumber=" & item.LineNumber)
                        Dim newdr As DataRow
                        If drs.Length = 0 Then
                            newdr = .NewRow
                        Else
                            newdr = drs(0)
                        End If
                        newdr("crptc_crpt") = Me.Id
                        newdr("crptc_linenumber") = item.LineNumber
                        newdr("crptc_name") = item.Name
                        newdr("crptc_widthpercent") = item.WidthPercent
                        newdr("crptc_alignment") = CInt(item.Alignment)
                        newdr("crptc_startdate") = IIf(item.StartDate.Equals(Date.MinValue), DBNull.Value, item.StartDate)
                        newdr("crptc_enddate") = IIf(item.EndDate.Equals(Date.MinValue), DBNull.Value, item.EndDate)
                        newdr("crptc_cc") = Me.ValidIdOrDBNull(item.CostCenter)
                        newdr("crptc_includechildcc") = item.IncludeChildCostCenter
                        newdr("crptc_lci") = Me.ValidIdOrDBNull(item.LCI)
                        newdr("crptc_isnotlci") = item.IsNotLci
                        If drs.Length = 0 Then
                            .Rows.Add(newdr)
                        End If
                    Next
                End With
                For Each item As ComplexReportItem In Me.ItemCollection
                    Dim newdr As DataRow = dt.NewRow
                    newdr("crpti_crpt") = Me.Id
                    newdr("crpti_linenumber") = item.LineNumber
                    newdr("crpti_code") = item.Code
                    newdr("crpti_style") = item.Style
                    newdr("crpti_isnewpage") = item.IsNewPage
                    newdr("crpti_invisible") = item.IsInvisible
                    newdr("crpti_linestyle") = item.LineStyle

                    dt.Rows.Add(newdr)
                    For Each fff As ComplexReportData In item.DataCollection
                        Dim childDr As DataRow = dtFormula.NewRow
                        childDr("crptf_crpt") = Me.Id
                        childDr("crptf_crpti") = item.LineNumber
                        childDr("crptf_crptc") = fff.Column.LineNumber
                        childDr("crptf_formula") = fff.Formula
                        childDr("crptf_style") = fff.Style
                        childDr("crptf_linestyle") = fff.Linestyle
                        childDr("crptf_indentation") = fff.Indentation
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
            Return ""
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
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteComplexReport}", format) Then
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteComplexReport", New SqlParameter() {New SqlParameter("@crpt_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.ComplexReportIsReferencedCannotBeDeleted}")
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

    Public Class ComplexReportColumn

#Region "Members"
        Private m_ComplexReport As ComplexReport
        Private m_linenumber As Integer
        Private m_name As String
        Private m_widthPercent As Decimal
        Private m_alignment As HorizontalAlignment
        Private m_startDate As Date
        Private m_endDate As Date
        Private m_cc As CostCenter
        Private m_lci As LCIItem
        Private m_includeChildCC As Boolean
        Private m_isnotlci As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            m_cc = New CostCenter
            m_lci = New LCIItem
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            m_cc = New CostCenter
            m_lci = New LCIItem
            Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & "crptc_linenumber") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptc_linenumber") Then
                    .m_linenumber = CInt(dr(aliasPrefix & "crptc_linenumber"))
                End If
                ' Name.
                If dr.Table.Columns.Contains(aliasPrefix & "crptc_name") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptc_name") Then
                    .m_name = CStr(dr(aliasPrefix & "crptc_name"))
                End If
                ' Width Percent.
                If dr.Table.Columns.Contains(aliasPrefix & "crptc_widthpercent") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptc_widthpercent") Then
                    .m_widthPercent = CDec(dr(aliasPrefix & "crptc_widthpercent"))
                End If
                ' Alignment.
                If dr.Table.Columns.Contains(aliasPrefix & "crptc_alignment") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptc_alignment") Then
                    .m_alignment = CType(dr(aliasPrefix & "crptc_alignment"), HorizontalAlignment)
                End If
                ' StartDate.
                If dr.Table.Columns.Contains(aliasPrefix & "crptc_startdate") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptc_startdate") Then
                    .m_startDate = CDate(dr(aliasPrefix & "crptc_startdate"))
                End If
                ' EndDate.
                If dr.Table.Columns.Contains(aliasPrefix & "crptc_enddate") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptc_enddate") Then
                    .m_endDate = CDate(dr(aliasPrefix & "crptc_enddate"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "cc_id") AndAlso Not dr.IsNull(aliasPrefix & "cc_id") Then
                    If Not dr.IsNull("cc_id") Then
                        .m_cc = New CostCenter(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "crptc_cc") AndAlso Not dr.IsNull(aliasPrefix & "crptc_cc") Then
                        .m_cc = New CostCenter(CInt(dr(aliasPrefix & "crptc_cc")))
                    End If
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "lci_id") AndAlso Not dr.IsNull(aliasPrefix & "lci_id") Then
                    If Not dr.IsNull("lci_id") Then
                        .m_lci = New LCIItem(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "crptc_lci") AndAlso Not dr.IsNull(aliasPrefix & "crptc_lci") Then
                        .m_lci = New LCIItem(CInt(dr(aliasPrefix & "crptc_lci")))
                    End If
                End If

                ' IncludeChild.
                If dr.Table.Columns.Contains(aliasPrefix & "crptc_includechildcc") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptc_includechildcc") Then
                    .m_includeChildCC = CBool(dr(aliasPrefix & "crptc_includechildcc"))
                End If

                ' IsNotLCI.
                If dr.Table.Columns.Contains(aliasPrefix & "crptc_isnotlci") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptc_isnotlci") Then
                    .m_isnotlci = CBool(dr(aliasPrefix & "crptc_isnotlci"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property ComplexReport() As ComplexReport            Get                Return m_ComplexReport            End Get            Set(ByVal Value As ComplexReport)                m_ComplexReport = Value            End Set        End Property
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
        Public Property CostCenter() As CostCenter            Get                Return m_cc            End Get            Set(ByVal Value As CostCenter)                m_cc = Value            End Set        End Property
        Public Property IncludeChildCostCenter() As Boolean            Get                Return m_includeChildCC            End Get            Set(ByVal Value As Boolean)                m_includeChildCC = Value            End Set        End Property
        Public Property LCI() As LCIItem            Get                Return m_lci            End Get            Set(ByVal Value As LCIItem)                m_lci = Value            End Set        End Property
        Public Property IsNotLci() As Boolean            Get                Return m_isnotlci            End Get            Set(ByVal Value As Boolean)                m_isnotlci = Value            End Set        End Property
#End Region

#Region "Methods"

#End Region

    End Class
    <Serializable(), DefaultMember("Item")> _
Public Class ComplexReportColumnCollection
        Inherits CollectionBase

#Region "Members"
        Private m_ComplexReport As ComplexReport
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal ff As ComplexReport)
            m_ComplexReport = ff
            If Not m_ComplexReport.Originated Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetComplexReportColumns" _
            , New SqlParameter("@crpt_id", m_ComplexReport.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New ComplexReportColumn(row, "")
                Me.Add(item)
            Next
        End Sub
#End Region

#Region "Properties"
        Public Property ComplexReport() As ComplexReport            Get                Return m_ComplexReport            End Get            Set(ByVal Value As ComplexReport)                m_ComplexReport = Value            End Set        End Property
        Default Public Property Item(ByVal index As Integer) As ComplexReportColumn
            Get
                For Each ffc As ComplexReportColumn In Me
                    If ffc.LineNumber = index Then
                        Return ffc
                    End If
                Next
            End Get
            Set(ByVal value As ComplexReportColumn)
                For Each ffc As ComplexReportColumn In Me
                    If ffc.LineNumber = index Then
                        MyBase.List.Item(Me.IndexOf(ffc)) = value
                        Return
                    End If
                Next
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Function AllWidthPercent() As Decimal
            Dim ret As Decimal = 0
            For Each item As ComplexReportColumn In Me
                ret += item.WidthPercent
            Next
            Return ret
        End Function
        Public Sub Populate(ByVal dt As TreeTable)
            dt.Clear()
            Dim i As Integer = 0
            For Each ffc As ComplexReportColumn In Me
                i += 1
                Dim newRow As TreeRow = dt.Childs.Add()
                newRow("crptc_linenumber") = i
                newRow("crptc_name") = ffc.Name
                newRow("crptc_widthpercent") = Configuration.FormatToString(ffc.WidthPercent, 2)
                newRow("crptc_alignment") = CInt(ffc.Alignment)
                newRow("crptc_startdate") = ffc.StartDate
                newRow("crptc_enddate") = ffc.EndDate
                newRow("CCCode") = ffc.CostCenter.Code
                newRow("CCName") = ffc.CostCenter.Name
                newRow("crptc_includechildcc") = ffc.IncludeChildCostCenter
                newRow("LCICode") = ffc.LCI.Code
                newRow("LCIName") = ffc.LCI.Name
                newRow("crptc_isnotlci") = ffc.IsNotLci
                newRow.Tag = ffc
            Next
        End Sub
        Public Function GetMaxLine() As Integer
            Dim max As Integer = 0
            For Each col As ComplexReportColumn In Me
                If col.LineNumber > max Then
                    max = col.LineNumber
                End If
            Next
            Return max
        End Function
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As ComplexReportColumn) As Integer
            value.ComplexReport = Me.m_ComplexReport
            If value.LineNumber = 0 Then
                Dim max As Integer = GetMaxLine()
                value.LineNumber = max + 1
            End If
            Dim ret As Integer = MyBase.List.Add(value)
            If Not Me.m_ComplexReport Is Nothing AndAlso Not Me.m_ComplexReport.ItemCollection Is Nothing Then
                For Each item As ComplexReportItem In Me.m_ComplexReport.ItemCollection
                    If Not item.DataCollection Is Nothing Then
                        item.DataCollection.RefreshColumn()
                    End If
                Next
            End If
            Return ret
        End Function
        'Public Sub AddRange(ByVal value As ComplexReportColumnCollection)
        '    For i As Integer = 0 To value.Count - 1
        '        Me.Add(value(i))
        '    Next
        'End Sub
        Public Sub AddRange(ByVal value As ComplexReportColumn())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As ComplexReportColumn) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As ComplexReportColumn(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ComplexReportColumnEnumerator
            Return New ComplexReportColumnEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As ComplexReportColumn) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As ComplexReportColumn)
            value.ComplexReport = Me.m_ComplexReport
            MyBase.List.Insert(index, value)
            If Not Me.m_ComplexReport Is Nothing AndAlso Not Me.m_ComplexReport.ItemCollection Is Nothing Then
                For Each item As ComplexReportItem In Me.m_ComplexReport.ItemCollection
                    If Not item.DataCollection Is Nothing Then
                        item.DataCollection.RefreshColumn()
                    End If
                Next
            End If
        End Sub
        Public Sub Remove(ByVal value As ComplexReportColumn)
            value.ComplexReport = Nothing
            MyBase.List.Remove(value)
            If Not Me.m_ComplexReport Is Nothing AndAlso Not Me.m_ComplexReport.ItemCollection Is Nothing Then
                For Each item As ComplexReportItem In Me.m_ComplexReport.ItemCollection
                    If Not item.DataCollection Is Nothing Then
                        item.DataCollection.RefreshDeletedColumn()
                    End If
                Next
            End If
        End Sub
        'Public Sub Remove(ByVal value As ComplexReportColumnCollection)
        '    For i As Integer = 0 To value.Count - 1
        '        Me.Remove(value(i))
        '    Next
        'End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
            If Not Me.m_ComplexReport Is Nothing AndAlso Not Me.m_ComplexReport.ItemCollection Is Nothing Then
                For Each item As ComplexReportItem In Me.m_ComplexReport.ItemCollection
                    If Not item.DataCollection Is Nothing Then
                        item.DataCollection.RefreshDeletedColumn()
                    End If
                Next
            End If
        End Sub
#End Region


        Public Class ComplexReportColumnEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As ComplexReportColumnCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, ComplexReportColumn)
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
    Public Class ComplexReportItemType
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
    Public Class ComplexReportItem

#Region "Members"
        Private m_ComplexReport As ComplexReport
        Private m_linenumber As Integer
        Private m_code As String
        Private m_style As String
        Private m_isinvisible As Boolean
        Private m_isnewpage As Boolean
        Private m_linestyle As Integer
        Private m_dataCollection As ComplexReportDataCollection
#End Region

#Region "Constructors"
        Public Sub New(ByVal ComplexReport As ComplexReport)
            Me.ComplexReport = ComplexReport
            m_dataCollection = New ComplexReportDataCollection(Me)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal ComplexReport As ComplexReport)
            Me.ComplexReport = ComplexReport
            Construct(dr, aliasPrefix)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & "crpti_linenumber") _
                AndAlso Not dr.IsNull(aliasPrefix & "crpti_linenumber") Then
                    .m_linenumber = CInt(dr(aliasPrefix & "crpti_linenumber"))
                End If
                ' Code.
                If dr.Table.Columns.Contains(aliasPrefix & "crpti_code") _
                AndAlso Not dr.IsNull(aliasPrefix & "crpti_code") Then
                    .m_code = CStr(dr(aliasPrefix & "crpti_code"))
                End If
                ' Style.
                If dr.Table.Columns.Contains(aliasPrefix & "crpti_style") _
                AndAlso Not dr.IsNull(aliasPrefix & "crpti_style") Then
                    .m_style = CStr(dr(aliasPrefix & "crpti_style"))
                End If
                ' is NewPage.
                If dr.Table.Columns.Contains(aliasPrefix & "crpti_isnewpage") _
                AndAlso Not dr.IsNull(aliasPrefix & "crpti_isnewpage") Then
                    .m_isnewpage = CBool(dr(aliasPrefix & "crpti_isnewpage"))
                End If
                ' is Invisible.
                If dr.Table.Columns.Contains(aliasPrefix & "crpti_invisible") _
                AndAlso Not dr.IsNull(aliasPrefix & "crpti_invisible") Then
                    .m_isinvisible = CBool(dr(aliasPrefix & "crpti_invisible"))
                End If
                ' line style.
                If dr.Table.Columns.Contains(aliasPrefix & "crpti_linestyle") _
                AndAlso Not dr.IsNull(aliasPrefix & "crpti_linestyle") Then
                    .m_linestyle = CInt(dr(aliasPrefix & "crpti_linestyle"))
                End If

            End With
            m_dataCollection = New ComplexReportDataCollection(Me)
        End Sub
#End Region

#Region "Properties"
        Public Property ComplexReport() As ComplexReport            Get                Return m_ComplexReport            End Get            Set(ByVal Value As ComplexReport)                m_ComplexReport = Value            End Set        End Property
        Public Property DataCollection() As ComplexReportDataCollection            Get                Return m_dataCollection            End Get            Set(ByVal Value As ComplexReportDataCollection)                m_dataCollection = Value            End Set        End Property
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
Public Class ComplexReportItemCollection
        Inherits CollectionBase

#Region "Members"
        Private m_ComplexReport As ComplexReport
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal ff As ComplexReport)
            m_ComplexReport = ff
            If Not m_ComplexReport.Originated Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetComplexReportItems" _
            , New SqlParameter("@crpt_id", m_ComplexReport.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New ComplexReportItem(row, "", m_ComplexReport)
                Me.Add(item)
            Next
        End Sub
#End Region

#Region "Properties"
        Public Property ComplexReport() As ComplexReport            Get                Return m_ComplexReport            End Get            Set(ByVal Value As ComplexReport)                m_ComplexReport = Value            End Set        End Property
        Default Public Property Item(ByVal index As Integer) As ComplexReportItem
            Get
                Return CType(MyBase.List.Item(index), ComplexReportItem)
            End Get
            Set(ByVal value As ComplexReportItem)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Function GetNewPageIndices() As ArrayList
            Dim arr As New ArrayList
            Dim i As Integer
            For Each item As ComplexReportItem In Me
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
            For Each ffi As ComplexReportItem In Me
                i += 1
                Dim newRow As TreeRow = dt.Childs.Add()
                newRow("crpti_linenumber") = i
                ffi.LineNumber = i
                ffi.Code = ffi.LineNumber.ToString
                newRow("crpti_code") = ffi.Code

                Dim n As Integer = 0
                For Each col As ComplexReportColumn In Me.m_ComplexReport.ColumnCollection
                    n += 1
                    Dim fff As ComplexReportData = ffi.DataCollection(col)
                    If Not fff Is Nothing Then
                        newRow("crpti_formula" & (n).ToString) = fff.FormulaText
                    End If
                Next

                newRow("crpti_isnewpage") = ffi.IsNewPage
                newRow("crpti_linestyle") = ffi.LineStyle
                newRow("crpti_invisible") = ffi.IsInvisible

                newRow.Tag = ffi
            Next
        End Sub
        Public Sub PopulateValue(ByVal dt As TreeTable)
            dt.Clear()
            Dim i As Integer = 0
            For Each ffi As ComplexReportItem In Me
                i += 1
                Dim newRow As TreeRow = dt.Childs.Add()
                newRow("crpti_linenumber") = i
                ffi.LineNumber = i
                ffi.Code = ffi.LineNumber.ToString
                newRow("crpti_code") = ffi.Code

                Dim n As Integer = 0
                For Each col As ComplexReportColumn In Me.m_ComplexReport.ColumnCollection
                    n += 1
                    Dim fff As ComplexReportData = ffi.DataCollection(col)
                    If Not fff Is Nothing Then
                        Dim val As Decimal = 0
                        Dim valString As String = fff.FormulaText
                        If fff.IsAcctFormula Or fff.IsFormula Then
                            Dim o As Object = fff.GetUltimateValue
                            Dim sp As String = ""
                            For x As Integer = 1 To fff.Indentation
                                sp &= " "
                            Next
                            If IsNumeric(o) Then
                                val = CDec(o)
                                valString = sp & Configuration.FormatToString(val, DigitConfig.Price)
                            ElseIf Not o Is Nothing Then
                                valString = sp & o.ToString
                            End If
                        End If
                        newRow("crpti_formula" & (n).ToString) = valString
                    End If
                Next

                newRow("crpti_isnewpage") = ffi.IsNewPage
                newRow("crpti_linestyle") = ffi.LineStyle
                newRow("crpti_invisible") = ffi.IsInvisible

                newRow.Tag = ffi
            Next
        End Sub
        Public Function GetMaxLine() As Integer
            Dim max As Integer = 0
            For Each item As ComplexReportItem In Me
                If item.LineNumber > max Then
                    max = item.LineNumber
                End If
            Next
            Return max
        End Function
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As ComplexReportItem) As Integer
            value.ComplexReport = Me.m_ComplexReport
            If value.LineNumber = 0 Then
                Dim max As Integer = GetMaxLine()
                value.LineNumber = max + 1
            End If
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As ComplexReportItemCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As ComplexReportItem())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As ComplexReportItem) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As ComplexReportItem(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ComplexReportItemEnumerator
            Return New ComplexReportItemEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As ComplexReportItem) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As ComplexReportItem)
            value.ComplexReport = Me.m_ComplexReport
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As ComplexReportItem)
            value.ComplexReport = Nothing
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As ComplexReportItemCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class ComplexReportItemEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As ComplexReportItemCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, ComplexReportItem)
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

    Public Class ComplexReportData

#Region "Members"
        Private m_column As ComplexReportColumn
        Private m_item As ComplexReportItem
        Private m_style As String
        Private m_formula As String
        Private m_linestyle As Integer
        Private m_indentation As Integer

        Public Const FieldCodePattern As String = "\|(?<FieldCode>[^\|]+)\|"
        Public Const ColumnFormulaPettern As String = "([A-Z]{1,2})(\d+)"
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Construct(dr, aliasPrefix)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal item As ComplexReportItem)
            Me.Item = item
            Me.Style = Me.Item.Style
            Me.Linestyle = item.LineStyle
            Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                ' Style.
                If dr.Table.Columns.Contains(aliasPrefix & "crptf_style") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptf_style") Then
                    .m_style = CStr(dr(aliasPrefix & "crptf_style"))
                End If
                ' Formula.
                If dr.Table.Columns.Contains(aliasPrefix & "crptf_formula") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptf_formula") Then
                    .m_formula = CStr(dr(aliasPrefix & "crptf_formula"))
                End If
                ' line style.
                If dr.Table.Columns.Contains(aliasPrefix & "crptf_linestyle") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptf_linestyle") Then
                    .m_linestyle = CInt(dr(aliasPrefix & "crptf_linestyle"))
                End If
                ' Column Id.
                If dr.Table.Columns.Contains(aliasPrefix & "crptf_crptc") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptf_crptc") Then
                    If Not m_item Is Nothing Then
                        If Not m_item.ComplexReport Is Nothing Then
                            .m_column = m_item.ComplexReport.ColumnCollection(CInt(dr(aliasPrefix & "crptf_crptc")))
                        End If
                    End If
                End If
                ' Idention.
                If dr.Table.Columns.Contains(aliasPrefix & "crptf_indentation") _
                AndAlso Not dr.IsNull(aliasPrefix & "crptf_indentation") Then
                    .m_indentation = CInt(dr(aliasPrefix & "crptf_indentation"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Column() As ComplexReportColumn            Get                Return m_column            End Get            Set(ByVal Value As ComplexReportColumn)                m_column = Value            End Set        End Property        Public Property Indentation() As Integer
            Get
                Return m_indentation
            End Get
            Set(ByVal Value As Integer)
                m_indentation = Value
            End Set
        End Property        Public Property Item() As ComplexReportItem            Get                Return m_item            End Get            Set(ByVal Value As ComplexReportItem)                m_item = Value            End Set        End Property        Public Property Style() As String            Get                Return m_style            End Get            Set(ByVal Value As String)                m_style = Value            End Set        End Property        Public Property Formula() As String            Get                Return m_formula            End Get            Set(ByVal Value As String)                m_formula = Value            End Set        End Property        Public ReadOnly Property FormulaText() As String            Get                Dim sp As String = ""
                For i As Integer = 1 To Me.Indentation
                    sp &= " "
                Next                Return sp & m_formula            End Get        End Property        Public Property Linestyle() As Integer            Get                Return m_linestyle            End Get            Set(ByVal Value As Integer)                m_linestyle = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Function GetUltimateValue() As Object
            If Me.IsFormula Then
                Return GetValue()
            End If
            If Me.IsAcctFormula Then
                Return GetFieldValue()
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
                Try
                    Return CDec(TextHelper.TextParser.Evaluate(tmpFormula))
                Catch ex As Exception
                    Return 0
                End Try
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Function
        Private Function ReplaceData(ByVal m As Match) As String
            Dim dat As ComplexReportData = Me.m_item.ComplexReport.GetDataFromExcelRowCol(m.Value)
            If dat Is Me Then
                Throw New Exception("Cyclic" & m.Value)
            End If
            Try
                Return dat.GetUltimateValue.ToString
            Catch ex As Exception
                Throw New Exception("Please check your Formula" & m.Value)
            End Try
        End Function
        Public Function IsAcctFormula() As Boolean
            If Me.Formula Is Nothing OrElse Me.Formula.Length = 0 Then
                Return False
            End If
            Dim re As New Regex(FieldCodePattern)
            Return re.IsMatch(Me.Formula)
        End Function
        Public Function GetFieldValue() As Object
            If Not IsAcctFormula() Then
                Return 0
            End If
            Dim val As Decimal = 0
            Dim re As New Regex(FieldCodePattern)
            For Each m As Match In re.Matches(Me.Formula, Me.FieldCodePattern)
                Dim field As New ComplexReportField(m.Groups("FieldCode").Value)
                If field.Originated Then
                    Dim o As Object = Me.m_item.ComplexReport.GetValueFromFilter(Me.Column, field)
                    If IsNumeric(o) Then
                        val += CDec(o)
                    Else
                        Return o
                    End If
                End If
            Next
            Return val
        End Function
#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
Public Class ComplexReportDataCollection
        Inherits CollectionBase

#Region "Members"
        Private m_ComplexReportItem As ComplexReportitem
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal ffi As ComplexReportitem)
            m_ComplexReportItem = ffi
            If Not ffi.ComplexReport Is Nothing Then
                Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

                Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
                , CommandType.StoredProcedure _
                , "GetComplexReportDatas" _
                , New SqlParameter("@crptf_crpt", ffi.ComplexReport.Id) _
                , New SqlParameter("@crptf_crpti", ffi.LineNumber) _
                )

                For Each row As DataRow In ds.Tables(0).Rows
                    Dim item As New ComplexReportData(row, "", ffi)
                    Me.Add(item)
                Next

                RefreshColumn()

            End If
        End Sub
        Public Sub RefreshColumn()
            If m_ComplexReportItem.ComplexReport Is Nothing Then
                Return
            End If
            For Each col As ComplexReportColumn In m_ComplexReportItem.ComplexReport.ColumnCollection
                If Not Me.Contains(col) Then
                    Dim item As New ComplexReportData
                    item.Column = col
                    Me.Add(item)
                End If
            Next
        End Sub
        Public Sub RefreshDeletedColumn()
            If m_ComplexReportItem.ComplexReport Is Nothing Then
                Return
            End If
            Dim dataToRemove As New ArrayList
            For Each myItem As ComplexReportData In Me
                If myItem.Column Is Nothing Then
                    If Not dataToRemove.Contains(myItem) Then
                        dataToRemove.Add(myItem)
                    End If
                ElseIf Not m_ComplexReportItem.ComplexReport.ColumnCollection.Contains(myItem.Column) Then
                    If Not dataToRemove.Contains(myItem) Then
                        dataToRemove.Add(myItem)
                    End If
                Else
                    'MessageBox.Show("alive:" & myItem.Column.LineNumber.ToString)
                End If
            Next
            For Each itemToRemove As ComplexReportData In dataToRemove
                Me.Remove(itemToRemove)
            Next
        End Sub
#End Region

#Region "Properties"
        Public Property ComplexReportitem() As ComplexReportitem            Get                Return m_ComplexReportItem            End Get            Set(ByVal Value As ComplexReportitem)                m_ComplexReportItem = Value            End Set        End Property
        Default Public Property Item(ByVal col As ComplexReportColumn) As ComplexReportData
            Get
                For Each fff As ComplexReportData In Me
                    If fff.Column Is col Then
                        Return fff
                    End If
                Next
            End Get
            Set(ByVal value As ComplexReportData)
                For Each fff As ComplexReportData In Me
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
        Public Function Add(ByVal value As ComplexReportData) As Integer
            value.Item = Me.m_ComplexReportItem
            Return MyBase.List.Add(value)
        End Function
        'Public Sub AddRange(ByVal value As ComplexReportDataCollection)
        '    For i As Integer = 0 To value.Count - 1
        '        Me.Add(value(i))
        '    Next
        'End Sub
        Public Sub AddRange(ByVal value As ComplexReportData())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As ComplexReportData) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Function Contains(ByVal value As ComplexReportColumn) As Boolean
            For Each fff As ComplexReportData In Me
                If fff.Column Is value Then
                    Return True
                End If
            Next
            Return False
        End Function
        Public Sub CopyTo(ByVal array As ComplexReportData(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ComplexReportDataEnumerator
            Return New ComplexReportDataEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As ComplexReportData) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As ComplexReportData)
            value.Item = Me.m_ComplexReportItem
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As ComplexReportData)
            value.Item = Me.m_ComplexReportItem
            MyBase.List.Remove(value)
        End Sub
        'Public Sub Remove(ByVal value As ComplexReportDataCollection)
        '    For i As Integer = 0 To value.Count - 1
        '        Me.Remove(value(col))
        '    Next
        'End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class ComplexReportDataEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As ComplexReportDataCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, ComplexReportData)
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
