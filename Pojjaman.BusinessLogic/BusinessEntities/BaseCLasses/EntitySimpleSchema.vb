Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports System.ComponentModel
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic

  Public Class EntitySimpleSchema

#Region "Contstructor"
    Public Sub New()

    End Sub
    'Public Sub New(ByVal entity As ISimpleEntity, ByVal schemaId As String, ByVal prinTableEntity As IPrintableEntity)
    '  m_entity = entity
    '  m_schemaId = schemaId
    '  'm_schemaName = SchemaName

    '  'If TypeOf m_entity Is SimpleBusinessEntityBase Then
    '  '  CType(m_entity, SimpleBusinessEntityBase).SimpleSchema = Me
    '  'End If

    '  m_docPrintingItemCollection = prinTableEntity.GetDocPrintingEntries
    'End Sub
#End Region

#Region "Member"
    Private m_entity As ISimpleEntity
    'Private m_schemaId As String
    ''Private m_schemaName As String
    'Private m_docPrintingItemCollection As DocPrintingItemCollection
    'Private m_dataSet As DataSet
#End Region

#Region "Properties"
    'Public Property SchemaId As String
    '  Get
    '    Return m_schemaId
    '  End Get
    '  Set(ByVal value As String)
    '    m_schemaId = value
    '  End Set
    'End Property
    'Public ReadOnly Property SchemaName As String
    '  Get
    '    If m_schemaId.Trim.Length = 0 Then
    '      Dim nextnumber As String = Me.GetNumberOfEntitySchemaFromDB
    '      Return String.Format("Get_{0}_{1}", m_entity.ClassName, nextnumber)
    '    Else
    '      Return m_schemaId
    '    End If
    '  End Get
    'End Property
    'Private ReadOnly Property ListSchemaName As String
    '  Get
    '    Return String.Format("Get_{0}_List", Me.m_entity.ClassName)
    '  End Get
    'End Property
    'Private ReadOnly Property GeneralSchemaName As String
    '  Get
    '    Return String.Format("Get_{0}_General", m_entity.ClassName)
    '  End Get
    'End Property
    'Public Property DataSet As DataSet
    '  Get
    '    m_dataSet = GetDataSchema()
    '    m_dataSet.DataSetName = Me.SchemaId.Trim.ToLower

    '    Return m_dataSet
    '  End Get
    '  Set(ByVal value As DataSet)
    '    m_dataSet = value
    '  End Set
    'End Property
#End Region

#Region "Shrard"
    Public Shared Function GetData(entity As ISimpleEntity, ByVal printingEntity As INewPrintableEntity, ByVal schemaId As String) As DataSet
      If printingEntity Is Nothing Then
        Return Nothing
      End If

      Dim ds As DataSet
      If IsDefaultSchema(entity, schemaId) Then
        ds = GetNewListData(printingEntity)
      Else
        ds = GetNewListSchemaFromDB(printingEntity, schemaId)
      End If
      ds.DataSetName = schemaId

      Return ds
    End Function
    Public Shared Function GetSchema(entity As ISimpleEntity, ByVal printingEntity As INewPrintableEntity, ByVal schemaId As String) As DataSet
      If printingEntity Is Nothing OrElse schemaId Is Nothing OrElse schemaId.Trim.Length = 0 Then
        Return Nothing
      End If

      Dim ds As DataSet
      If IsDefaultSchema(entity, schemaId) Then
        ds = GetNewListSchema(printingEntity)
      Else
        ds = GetNewListOnlySchemaFromDB(printingEntity, schemaId)
      End If
      ds.DataSetName = schemaId

      Return ds
    End Function
    Private Shared Function IsDefaultSchema(entity As ISimpleEntity, ByVal schemaId As String) As Boolean
      If TypeOf entity Is ISimpleEntity Then
        Dim en As ISimpleEntity = CType(entity, ISimpleEntity)

        If schemaId.ToLower.Trim.Equals(String.Format("Get_{0}_List", en.ClassName).ToLower.Trim) OrElse _
          schemaId.ToLower.Trim.Equals(String.Format("Get_{0}_General", en.ClassName).ToLower.Trim) Then
          Return True
        End If

      End If

      Return False
    End Function
    'Public Shared Function GetData(ByVal entity As ISimpleEntity, ByVal schemaId As String) As DataSet
    '  If entity Is Nothing Then
    '    Return Nothing
    '  End If

    '  If TypeOf entity Is INewPrintableEntity Then
    '    Return GetNewListData(CType(entity, INewPrintableEntity))
    '  End If
    '  If TypeOf entity Is SimpleBusinessEntityBase Then
    '    If Not CType(entity, SimpleBusinessEntityBase).NewPrintableEntities Is Nothing Then
    '      Return GetNewListData(CType(entity, SimpleBusinessEntityBase).NewPrintableEntities)
    '    End If

    '  End If

    'End Function
    'Public Shared Function GetSchema(ByVal entity As ISimpleEntity, ByVal schemaId As String) As DataSet
    '  If entity Is Nothing OrElse schemaId Is Nothing OrElse schemaId.Trim.Length = 0 Then
    '    Return Nothing
    '  End If

    '  If TypeOf entity Is SimpleBusinessEntityBase Then
    '    If Not CType(entity, SimpleBusinessEntityBase).NewPrintableEntities Is Nothing Then
    '      Return GetNewListSchema(CType(entity, SimpleBusinessEntityBase).NewPrintableEntities)
    '    End If
    '  End If

    'End Function
#End Region

#Region "Method"
    Private Shared Function PairDataAndSchema(ByVal dpientity As INewPrintableEntity) As DocPrintingItemCollection
      Dim key As String
      Dim newDpiColl As New DocPrintingItemCollection
      Dim dataDpiColl As DocPrintingItemCollection = dpientity.GetDocPrintingDataEntries
      Dim schemaDpiColl As DocPrintingItemCollection = dpientity.GetDocPrintingColumnsEntries

      dataDpiColl.AddRange(GetPrintingDetailOfEntity(dpientity, False))
      'schemaDpiColl.AddRange(GetPrintingDetailOfEntity(dpientity))

      dataDpiColl.RefreshTableList()
      schemaDpiColl.RefreshTableList()

      For Each dpi As DocPrintingItem In schemaDpiColl.TableListOf("general")
        key = String.Format("{0}>{1}>{2}", dpi.Table.ToLower, dpi.Mapping.ToLower, dpi.Row.ToString)
        Dim dataDpi As DocPrintingItem = dataDpiColl.ColumnHashOf(key)
        If Not dataDpi Is Nothing Then
          dpi.Value = dataDpi.Value
        End If
        newDpiColl.Add(dpi)
      Next

      For Each tbName As String In schemaDpiColl.TableHash.Keys

        If Not tbName.Equals("general") Then
          For Each dpi As DocPrintingItem In schemaDpiColl.TableListOf(tbName)
            For Each rowIndex As Integer In dataDpiColl.RowsTableHashOf(tbName)
              key = String.Format("{0}>{1}>{2}", dpi.Table.ToLower, dpi.Mapping.ToLower, rowIndex.ToString)
              Dim dataDpi As DocPrintingItem = dataDpiColl.ColumnHashOf(key)
              If Not dataDpi Is Nothing Then
                Dim newDpi As New DocPrintingItem
                newDpi.Mapping = dpi.Mapping
                newDpi.Value = dataDpi.Value
                newDpi.DataType = dpi.DataType
                newDpi.Row = rowIndex
                newDpi.Table = dpi.Table
                newDpiColl.Add(newDpi)
              Else
                Dim newDpi As New DocPrintingItem
                newDpi.Mapping = dpi.Mapping
                newDpi.Value = dpi.Value
                newDpi.DataType = dpi.DataType
                newDpi.Row = rowIndex
                newDpi.Table = dpi.Table
                newDpiColl.Add(newDpi)
              End If
            Next
          Next
        End If

      Next

      Return newDpiColl

    End Function
    Public Shared Function NewDocPrintingItem(ByVal name As String, ByVal datatype As String, Optional ByVal tablename As String = "General") As DocPrintingItem
      Dim dpi As New DocPrintingItem
      dpi.Mapping = name
      dpi.Value = GetDefaultValue(datatype)
      dpi.DataType = datatype
      dpi.Row = 0
      dpi.Table = tablename
      Return dpi
    End Function
    Public Shared Function NewDocPrintingItem(ByVal name As String, ByVal value As Object, ByVal datatype As String, ByVal row As Integer, ByVal tablename As String) As DocPrintingItem
      Dim dpi As New DocPrintingItem
      dpi.Mapping = name
      dpi.Value = value
      dpi.DataType = datatype
      dpi.Row = row
      dpi.Table = tablename
      Return dpi
    End Function
    Private Shared Function GetNewListData(ByVal dpientity As INewPrintableEntity) As DataSet
      Dim ds As New DataSet
      Dim dt As DataTable
      Dim dr As DataRow
      Dim dc As DataColumn

      '--Generate DataSet Tables and Columns--============================================================================
      Dim dpiColl As DocPrintingItemCollection = PairDataAndSchema(dpientity)

      If Not dpiColl Is Nothing AndAlso Not dpiColl.TableList Is Nothing Then
        'dpiColl.AddRange(GetPrintingDetailOfEntity(dpientity, False))

        For Each tbName As String In dpiColl.TableList

          dt = New DataTable(tbName)
          For Each dpiColumn As DocPrintingItem In dpiColl.ColumnsTableHashOf(tbName)
            Dim m_column As String = ""
            Dim m_columntype As System.Type
            If Not dpiColumn.Mapping Is Nothing Then
              m_column = dpiColumn.Mapping
            End If
            If Not dpiColumn.DataType Is Nothing Then
              Try
                m_columntype = ConfirmType(dpiColumn.DataType)
              Catch ex As Exception
              End Try
            End If
            If m_columntype Is Nothing Then
              m_columntype = System.Type.GetType("System.String")
            End If
            dc = New DataColumn(m_column, m_columntype)
            dt.Columns.Add(dc)
          Next
          ds.Tables.Add(dt)

          For Each rowIndex As Integer In dpiColl.RowsTableHashOf(tbName)
            dr = dt.NewRow
            For Each dpiColumn As DocPrintingItem In dpiColl.ColumnsTableHashOf(tbName)
              Dim key As String = String.Format("{0}>{1}>{2}", tbName.ToLower, dpiColumn.Mapping.ToLower, rowIndex.ToString)
              Dim dpi As DocPrintingItem = dpiColl.ColumnHashOf(key)
              If Not dpi Is Nothing Then
                Dim m_column As String = ""
                Dim m_value As Object = DBNull.Value
                If Not dpi.Mapping Is Nothing Then
                  m_column = dpi.Mapping
                End If

                If dpi.Value Is Nothing OrElse dpi.Value Is DBNull.Value OrElse (dpi.DataType.ToLower <> "system.string" AndAlso TypeOf dpi.Value Is String AndAlso dpi.Value.ToString.Trim.Length = 0) Then
                  m_value = GetDefaultValue(dpi.DataType)
                Else
                  m_value = dpi.Value
                End If

                dr(m_column) = m_value
              End If
            Next
            dt.Rows.Add(dr)
          Next

        Next
      End If

      Return ds
   
    End Function
    Private Shared Function GetNewListSchema(ByVal dpientity As INewPrintableEntity) As DataSet
      Dim ds As New DataSet
      Dim dt As DataTable
      Dim dr As DataRow
      Dim dc As DataColumn

      '--Generate DataSet Tables and Columns--============================================================================
      Dim dpiColl As DocPrintingItemCollection = CType(dpientity, INewPrintableEntity).GetDocPrintingColumnsEntries

      If Not dpiColl Is Nothing Then
        dpiColl.AddRange(GetPrintingDetailOfEntity(dpientity))
      End If

      If Not dpiColl Is Nothing AndAlso Not dpiColl.TableList Is Nothing Then

        For Each tbName As String In dpiColl.TableList

          dt = New DataTable(tbName)
          For Each dpiColumn As DocPrintingItem In dpiColl.ColumnsTableHashOf(tbName)
            Dim m_column As String = ""
            Dim m_columntype As System.Type
            If Not dpiColumn.Mapping Is Nothing Then
              m_column = dpiColumn.Mapping
            End If
            If Not dpiColumn.DataType Is Nothing Then
              Try
                m_columntype = ConfirmType(dpiColumn.DataType)
              Catch ex As Exception
              End Try
            End If
            If m_columntype Is Nothing Then
              m_columntype = System.Type.GetType("System.String")
            End If
            dc = New DataColumn(m_column, m_columntype)
            dt.Columns.Add(dc)
          Next
          ds.Tables.Add(dt)

        Next
      End If

      '--Generate DataSet Relations--============================================================================
      Dim relationList As List(Of String) = dpientity.GetDocPrintingColumnsEntries.RelationList ' CType(m_entity, IPrintableEntity).GetDocPrintingEntries.RelationList

      If Not relationList Is Nothing AndAlso relationList.Count > 0 Then
        Dim relationhash As New Hashtable

        Dim hashDupRelation As New Hashtable

        For Each rlist As String In relationList
          If Not hashDupRelation.ContainsKey(rlist) Then
            hashDupRelation(rlist) = rlist

            Dim rname As String = rlist.Replace(">", "_")
            Dim rlistsplit() As String = rlist.Split(">"c)

            Dim pname As String = rlistsplit(0)
            Dim pcoll As String = rlistsplit(1)
            Dim cname As String = rlistsplit(2)
            Dim ccoll As String = rlistsplit(3)

            If ds.Tables.Contains(pname) AndAlso ds.Tables(pname).Columns.Contains(pcoll) AndAlso
               ds.Tables.Contains(cname) AndAlso ds.Tables(cname).Columns.Contains(ccoll) Then

              Dim key As String = String.Format("relation_{0}_{1}", pname, cname)
              If Not relationhash.ContainsKey(key) Then
                Dim pairrelation As New ArrayList
                Dim parentlist As New List(Of DataColumn)
                Dim childlist As New List(Of DataColumn)

                parentlist.Add(ds.Tables(pname).Columns(pcoll)) 'parent
                childlist.Add(ds.Tables(cname).Columns(ccoll)) 'child 

                pairrelation.Add(parentlist)
                pairrelation.Add(childlist)
                relationhash(key) = pairrelation
              Else
                Dim pairrelation As ArrayList = CType(relationhash(key), ArrayList)
                Dim parentlist As List(Of DataColumn) = CType(pairrelation(0), List(Of DataColumn))
                Dim childlist As List(Of DataColumn) = CType(pairrelation(1), List(Of DataColumn))

                parentlist.Add(ds.Tables(pname).Columns(pcoll)) 'parent
                childlist.Add(ds.Tables(cname).Columns(ccoll)) 'child 
              End If

            End If

          End If

        Next

        For Each rname As String In relationhash.Keys
          Dim pairrelation As ArrayList = CType(relationhash(rname), ArrayList)
          Dim parentlist As List(Of DataColumn) = CType(pairrelation(0), List(Of DataColumn))
          Dim childlist As List(Of DataColumn) = CType(pairrelation(1), List(Of DataColumn))
          Dim drelation As New DataRelation(rname, parentlist.ToArray, childlist.ToArray, False)
          ds.Relations.Add(drelation)
        Next
      End If

      Return ds
    End Function
    Private Shared Function GetNewListSchemaFromDB(ByVal dpientity As INewPrintableEntity, ByVal schemaId As String) As DataSet
      If Not TypeOf dpientity Is ISimpleEntity Then
        Return New DataSet
      End If

      Dim _entity As ISimpleEntity = CType(dpientity, ISimpleEntity)

      Dim ds As DataSet = SqlHelper.ExecuteDataset(
                                                    SimpleBusinessEntityBase.ConnectionString,
                                                    CommandType.StoredProcedure,
                                                    schemaId,
                                                    New SqlParameter("@entityid", _entity.Id),
                                                    New SqlParameter("@entitytype", _entity.EntityId)
                                                )
      If ds.Tables.Count > 0 Then
        ds.Tables(0).TableName = _entity.ClassName
      End If

      Return ds
    End Function
    Private Shared Function GetNewListOnlySchemaFromDB(ByVal dpientity As INewPrintableEntity, ByVal schemaId As String) As DataSet
      If Not TypeOf dpientity Is ISimpleEntity Then
        Return New DataSet
      End If

      Dim _entity As ISimpleEntity = CType(dpientity, ISimpleEntity)

      Dim ds As DataSet = SqlHelper.ExecuteDataset(
                                                    SimpleBusinessEntityBase.ConnectionString,
                                                    CommandType.StoredProcedure,
                                                    schemaId,
                                                    New SqlParameter("@entityid", 0),
                                                    New SqlParameter("@entitytype", _entity.EntityId)
                                                )
      If ds.Tables.Count > 0 Then
        ds.Tables(0).TableName = _entity.ClassName
      End If

      Return ds
    End Function
    Private Shared Function GetPrintingDetailOfEntity(ByVal entity As INewPrintableEntity, Optional ByVal schemaOnly As Boolean = True) As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim myDpi As DocPrintingItem

      If TypeOf entity Is ISimpleEntity Then
        Dim myEntity As ISimpleEntity = CType(entity, ISimpleEntity)

        If schemaOnly Then
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreatorId", "System.String"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreatorName", "System.String"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreatorCode", "System.String"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreatorInfo", "System.String"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreateDate", "System.DateTime"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditorId", "System.String"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditorCode", "System.String"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditorName", "System.String"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditorInfo", "System.String"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditDate", "System.DateTime"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PrintBy", "System.String"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PrintDate", "System.DateTime"))
          dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PrintNumber", "System.Integer"))

          Return dpiColl
        End If

        'ชื่อผู้สร้างเอกสาร
        If myEntity.Originator IsNot Nothing Then
          myDpi = New DocPrintingItem
          myDpi.Mapping = "CreatorId"
          myDpi.Value = myEntity.Originator.Id
          myDpi.DataType = "System.String"
          myDpi.SignatureType = SignatureType.User
          dpiColl.Add(myDpi)

          myDpi = New DocPrintingItem
          myDpi.Mapping = "CreatorName"
          myDpi.Value = myEntity.Originator.Name
          myDpi.DataType = "System.String"
          dpiColl.Add(myDpi)

          myDpi = New DocPrintingItem
          myDpi.Mapping = "CreatorCode"
          myDpi.Value = myEntity.Originator.Code
          myDpi.DataType = "System.String"
          dpiColl.Add(myDpi)

          myDpi = New DocPrintingItem
          myDpi.Mapping = "CreatorInfo"
          myDpi.Value = myEntity.Originator.Code & ":" & myEntity.Originator.Name
          myDpi.DataType = "System.String"
          dpiColl.Add(myDpi)
        End If

        'วันที่สร้างเอกสาร
        If myEntity.OriginDate <> Date.MinValue Then
          myDpi = New DocPrintingItem
          myDpi.Mapping = "CreateDate"
          myDpi.Value = myEntity.OriginDate.ToShortDateString
          myDpi.DataType = "System.DateTime"
          dpiColl.Add(myDpi)
        End If

        'ผู้แก้ไขล่าสุด
        If myEntity.LastEditor IsNot Nothing Then
          myDpi = New DocPrintingItem
          myDpi.Mapping = "LastEditorId"
          myDpi.Value = myEntity.LastEditor.Id
          myDpi.DataType = "System.String"
          myDpi.SignatureType = SignatureType.User
          dpiColl.Add(myDpi)

          myDpi = New DocPrintingItem
          myDpi.Mapping = "LastEditorName"
          myDpi.Value = myEntity.LastEditor.Name
          myDpi.DataType = "System.String"
          dpiColl.Add(myDpi)

          myDpi = New DocPrintingItem
          myDpi.Mapping = "LastEditorCode"
          myDpi.Value = myEntity.LastEditor.Code
          myDpi.DataType = "System.String"
          dpiColl.Add(myDpi)

          myDpi = New DocPrintingItem
          myDpi.Mapping = "LastEditorInfo"
          myDpi.Value = myEntity.LastEditor.Code & ":" & myEntity.LastEditor.Name
          myDpi.DataType = "System.String"
          dpiColl.Add(myDpi)
        End If

        'วันที่แก้ไขล่าสุด
        If myEntity.LastEditDate <> Date.MinValue Then
          myDpi = New DocPrintingItem
          myDpi.Mapping = "LastEditDate"
          myDpi.Value = myEntity.LastEditDate.ToShortDateString
          myDpi.DataType = "System.DateTime"
          dpiColl.Add(myDpi)
        End If

        ''ผู้ที่ทำเอกสาร
        'Dim mySecurity As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
        'myDpi = New DocPrintingItem
        'myDpi.Mapping = "UserId"
        'myDpi.Value = mySecurity.CurrentUser.Id
        'myDpi.DataType = "System.String"
        'myDpi.SignatureType = SignatureType.User
        'myDpiColl.Add(myDpi)

        'ผู้ที่ Print
        'Dim mySecurity As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
        myDpi = New DocPrintingItem
        myDpi.Mapping = "PrintBy"
        myDpi.Value = User.CurrentUserName 'mySecurity.CurrentUser.Name
        myDpi.DataType = "System.String"
        dpiColl.Add(myDpi)

        'วันที่ Print
        myDpi = New DocPrintingItem
        myDpi.Mapping = "PrintDate"
        myDpi.Value = Date.Now.ToString("dd/MM/yyyy hh:mm:ss")
        myDpi.DataType = "System.Datetime"
        dpiColl.Add(myDpi)

        ''จำนวนครั้งที่ Print
        'myDpi = New DocPrintingItem
        'myDpi.Mapping = m_entityNames(entity) & "." & "PrintNumber"
        'myDpi.Value = myEntity.GetNumberOfPrinting + 1
        'myDpi.DataType = "System.Integer"
        'dpiColl.Add(myDpi)

      End If

      Return dpiColl

    End Function

    Public Shared Function GetListSchemaName(ByVal entity As ISimpleEntity) As List(Of KeyValuePair)
      Dim scname As String = String.Format("Get_{0}_List", entity.ClassName)
      Dim scaliasname As String = scname
      If TypeOf entity Is SimpleBusinessEntityBase Then

        Dim m_stringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        scaliasname = CType(entity, SimpleBusinessEntityBase).DetailPanelTitle
        scaliasname = String.Format("{0}(List)", m_stringParserService.Parse(scaliasname))
      End If

      Dim sclist As New List(Of KeyValuePair)
      Dim kv As New KeyValuePair(scaliasname, scname)
      sclist.Add(kv)

      For Each li As KeyValuePair In GetSchemaFromDB(entity)
        sclist.Add(li)
      Next

      Return sclist
    End Function
    Public Shared Function GetGeneralSchemaNameList(ByVal entity As ISimpleEntity) As List(Of KeyValuePair)
      Dim scname As String = String.Format("Get_{0}_General", entity.ClassName)
      Dim scaliasname As String = scname
      If TypeOf entity Is SimpleBusinessEntityBase Then

        Dim m_stringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        scaliasname = CType(entity, SimpleBusinessEntityBase).DetailPanelTitle
        scaliasname = m_stringParserService.Parse(scaliasname)
      End If

      Dim sclist As New List(Of KeyValuePair)
      Dim kv As New KeyValuePair(scaliasname, scname)
      sclist.Add(kv)

      For Each li As KeyValuePair In GetSchemaFromDB(entity)
        sclist.Add(li)
      Next

      Return sclist
    End Function
    'Private Function GetNumberOfEntitySchemaFromDB() As String
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString,
    '                                                 CommandType.StoredProcedure,
    '                                                 "GetNumberOfEntitySchemaFromDB",
    '                                                 New SqlParameter("@entity_id", Me.m_entity.EntityId))
    '  If ds.Tables.Count > 0 Then
    '    Return CStr(ds.Tables(0).Rows(0)("nextnumber"))
    '  End If

    '  Return "001"
    'End Function
    'Public Function GetDataSchema() As DataSet
    '  If m_entity Is Nothing Then
    '    Return Nothing
    '  End If
    '  If Me.SchemaId.Length > 0 Then
    '    If Me.SchemaId.Trim.ToLower = Me.GeneralSchemaName.Trim.ToLower Then
    '      Return GetGeneralDataSchema()
    '    ElseIf Me.SchemaId.Trim.ToLower = Me.ListSchemaName.Trim.ToLower Then
    '      Return GetGeneralDataSchema() ' GetListSchema()
    '    Else
    '      Return GetDatabaseDataSchema()
    '    End If
    '  End If
    '  Return Nothing
    'End Function

    Private Shared Function GetSchemaFromDB(ByVal entity As ISimpleEntity) As List(Of KeyValuePair)
      Dim sclist As New List(Of KeyValuePair)

      If entity Is Nothing Then
        Return sclist
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(
                                                      SimpleBusinessEntityBase.ConnectionString,
                                                      CommandType.StoredProcedure,
                                                      "GetSchemaName",
                                                      New SqlParameter("@entity_id", entity.EntityId)
                                                  )
      For Each d As DataRow In ds.Tables(0).Rows
        Dim dh As New DataRowHelper(d)
        Dim k As New KeyValuePair(dh.GetValue(Of String)("schema_aliasname", ""), dh.GetValue(Of String)("schema_name", ""))
        sclist.Add(k)
      Next
      Return sclist
    End Function
    'Public Function GetGeneralDataSchema() As DataSet
    '  If m_entity Is Nothing Then
    '    Return Nothing
    '  End If
    '  If TypeOf m_entity Is IPrintableEntity Then
    '    Dim ds As New DataSet
    '    Dim dt As DataTable
    '    Dim dr As DataRow
    '    Dim dc As DataColumn
    '    Dim hashTable As New Hashtable

    '    Dim m_rowcount As Integer = 0
    '    '--Generate DataSet Tables and Columns--============================================================================

    '    'For Each dpi As DocPrintingItem In CType(m_entity, IPrintableEntity).GetDocPrintingEntries
    '    For Each dpi As DocPrintingItem In m_docPrintingItemCollection
    '      Dim m_column As String = ""
    '      Dim m_row As Integer = 0
    '      Dim m_value As Object = DBNull.Value
    '      Dim m_table As String = ""
    '      Dim m_columntype As System.Type

    '      m_row = dpi.Row
    '      If Not dpi.Mapping Is Nothing Then
    '        m_column = dpi.Mapping
    '      End If
    '      If Not dpi.Table Is Nothing Then
    '        m_table = dpi.Table.ToString
    '      End If
    '      If Not dpi.DataType Is Nothing Then
    '        Try
    '          m_columntype = Me.ConfirmType(dpi.DataType)
    '        Catch ex As Exception

    '        End Try
    '      End If
    '      If m_columntype Is Nothing Then
    '        m_columntype = System.Type.GetType("System.String")
    '      End If
    '      If Not dpi.Value Is Nothing Then
    '        m_value = dpi.Value.ToString
    '      End If
    '      If dpi.DataType.ToLower = "system.datetime" AndAlso Not m_value Is Nothing AndAlso CType(m_value, String).Length = 0 Then
    '        m_value = DBNull.Value
    '      End If
    '      'If [Enum].GetName(GetType(System.DateTime), m_column) = "" Then

    '      'End If

    '      '--======== General Table ========--
    '      If m_table.Trim.Length = 0 Then
    '        If Not hashTable.ContainsKey("general") Then
    '          '--ที่ถูกต้องส่วนนี้ควรเข้ารอบเดียว--
    '          dt = New DataTable("general")
    '          If Not dt.Columns.Contains(m_column) Then
    '            dc = New DataColumn(m_column, m_columntype)
    '            dt.Columns.Add(dc)
    '            dr = dt.NewRow
    '            dr(m_column) = m_value
    '            dt.Rows.Add(dr)
    '          End If
    '          ds.Tables.Add(dt)
    '          hashTable("general") = dt
    '        Else
    '          dt = CType(hashTable("general"), DataTable)
    '          If Not dt.Columns.Contains(m_column) Then
    '            dc = New DataColumn(m_column, m_columntype)
    '            dt.Columns.Add(dc)
    '          End If
    '          dr = dt.Rows(0)
    '          dr(m_column) = m_value
    '        End If

    '      Else '--======== Other Table ========--
    '        If Not hashTable.ContainsKey(m_table) Then
    '          m_rowcount = 0
    '          '--ที่ถูกต้องส่วนนี้ควรเข้ารอบเดียว--
    '          dt = New DataTable(m_table)
    '          If Not dt.Columns.Contains(m_column) Then
    '            dc = New DataColumn(m_column, m_columntype)
    '            dt.Columns.Add(dc)
    '            dr = dt.NewRow
    '            m_rowcount = 1
    '            dr(m_column) = m_value
    '            dt.Rows.Add(dr)
    '          End If
    '          ds.Tables.Add(dt)
    '          hashTable(m_table) = dt
    '        Else
    '          dt = CType(hashTable(m_table), DataTable)
    '          If Not dt.Columns.Contains(m_column) Then
    '            dc = New DataColumn(m_column, m_columntype)
    '            dt.Columns.Add(dc)
    '            If m_rowcount < m_row Then
    '              dr = dt.NewRow
    '              m_rowcount += 1
    '              dt.Rows.Add(dr)
    '            Else
    '              dr = dt.Rows(dt.Rows.Count - 1)
    '            End If
    '            dr(m_column) = m_value
    '          Else
    '            dc = dt.Columns(m_column)
    '            If m_rowcount < m_row Then
    '              dr = dt.NewRow
    '              m_rowcount += 1
    '              dt.Rows.Add(dr)
    '            Else
    '              dr = dt.Rows(dt.Rows.Count - 1)
    '            End If
    '            dr(m_column) = m_value
    '          End If
    '        End If
    '      End If
    '    Next

    '    '--Generate DataSet Relations--============================================================================
    '    Dim relationList As List(Of String) = m_docPrintingItemCollection.RelationList ' CType(m_entity, IPrintableEntity).GetDocPrintingEntries.RelationList

    '    If Not relationList Is Nothing AndAlso relationList.Count > 0 Then
    '      Dim relationhash As New Hashtable

    '      Dim hashDupRelation As New Hashtable

    '      For Each rlist As String In relationList
    '        If Not hashDupRelation.ContainsKey(rlist) Then
    '          hashDupRelation(rlist) = rlist

    '          Dim rname As String = rlist.Replace(">", "_")
    '          Dim rlistsplit() As String = rlist.Split(">"c)

    '          Dim pname As String = rlistsplit(0)
    '          Dim pcoll As String = rlistsplit(1)
    '          Dim cname As String = rlistsplit(2)
    '          Dim ccoll As String = rlistsplit(3)

    '          If ds.Tables.Contains(pname) AndAlso ds.Tables(pname).Columns.Contains(pcoll) AndAlso
    '             ds.Tables.Contains(cname) AndAlso ds.Tables(cname).Columns.Contains(ccoll) Then

    '            Dim key As String = String.Format("relation_{0}_{1}", pname, cname)
    '            If Not relationhash.ContainsKey(key) Then
    '              Dim pairrelation As New ArrayList
    '              Dim parentlist As New List(Of DataColumn)
    '              Dim childlist As New List(Of DataColumn)

    '              parentlist.Add(ds.Tables(pname).Columns(pcoll)) 'parent
    '              childlist.Add(ds.Tables(cname).Columns(ccoll)) 'child 

    '              pairrelation.Add(parentlist)
    '              pairrelation.Add(childlist)
    '              relationhash(key) = pairrelation
    '            Else
    '              Dim pairrelation As ArrayList = CType(relationhash(key), ArrayList)
    '              Dim parentlist As List(Of DataColumn) = CType(pairrelation(0), List(Of DataColumn))
    '              Dim childlist As List(Of DataColumn) = CType(pairrelation(1), List(Of DataColumn))

    '              parentlist.Add(ds.Tables(pname).Columns(pcoll)) 'parent
    '              childlist.Add(ds.Tables(cname).Columns(ccoll)) 'child 
    '            End If

    '          End If

    '        End If

    '      Next

    '      For Each rname As String In relationhash.Keys
    '        Dim pairrelation As ArrayList = CType(relationhash(rname), ArrayList)
    '        Dim parentlist As List(Of DataColumn) = CType(pairrelation(0), List(Of DataColumn))
    '        Dim childlist As List(Of DataColumn) = CType(pairrelation(1), List(Of DataColumn))
    '        Dim drelation As New DataRelation(rname, parentlist.ToArray, childlist.ToArray, False)
    '        ds.Relations.Add(drelation)
    '      Next
    '    End If

    '    Return ds

    '  End If
    '  Return Nothing
    'End Function

    Private Shared Function ConfirmType(ByVal _type As String) As System.Type

      Select Case _type.Trim.ToLower
        Case "boolean", "system.boolean"
          Return System.Type.GetType("System.Boolean")
        Case "byte", "system.byte"
          Return System.Type.GetType("System.Byte")
        Case "char", "system.char"
          Return System.Type.GetType("System.Char")
        Case "datetime", "system.datetime"
          Return System.Type.GetType("System.DateTime")
        Case "decimal", "system.decimal"
          Return System.Type.GetType("System.Decimal")
        Case "double", "system.double"
          Return System.Type.GetType("System.Double")
        Case "int16", "system.int16"
          Return System.Type.GetType("System.Int16")
        Case "int32", "system.int32"
          Return System.Type.GetType("System.Int32")
        Case "int64", "system.int64"
          Return System.Type.GetType("System.Int64")
        Case "sbyte", "system.sbyte"
          Return System.Type.GetType("System.SByte")
        Case "single", "system.single"
          Return System.Type.GetType("System.Single")
        Case "string", "system.string"
          Return System.Type.GetType("System.String")
        Case "timespan", "system.timespan"
          Return System.Type.GetType("System.TimeSpan")
        Case "uint16", "system.uint16"
          Return System.Type.GetType("System.UInt16")
        Case "uint32", "system.uint32"
          Return System.Type.GetType("System.UInt32")
        Case "uint64", "system.uint64"
          Return System.Type.GetType("System.UInt64")
        Case Else
          Return System.Type.GetType("System.String")
      End Select

    End Function

    Private Shared Function GetDefaultValue(ByVal _type As String) As Object

      Select Case _type.Trim.ToLower
        Case "boolean", "system.boolean"
          Return False
        Case "byte", "system.byte"
          Return DBNull.Value
        Case "char", "system.char"
          Return ""
        Case "datetime", "system.datetime"
          Return DBNull.Value
        Case "decimal", "system.decimal"
          Return 0
        Case "double", "system.double"
          Return 0
        Case "int16", "system.int16"
          Return 0
        Case "int32", "system.int32"
          Return 0
        Case "int64", "system.int64"
          Return 0
        Case "sbyte", "system.sbyte"
          Return DBNull.Value
        Case "single", "system.single"
          Return 0
        Case "string", "system.string"
          Return ""
        Case "timespan", "system.timespan"
          Return DBNull.Value
        Case "uint16", "system.uint16"
          Return 0
        Case "uint32", "system.uint32"
          Return 0
        Case "uint64", "system.uint64"
          Return 0
        Case Else
          Return ""
      End Select

    End Function
#End Region

  End Class

End Namespace

