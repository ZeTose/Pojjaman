Option Explicit On
Option Strict On
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptSCMovementEnumerate
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
      MyBase.New(filters, fixValueCollection)
    End Sub
#End Region

#Region "Methods"
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      'Try
      m_grid = grid
      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable

      lkg.Rows.HeaderCount = 2
      lkg.Rows.FrozenCount = 2

      'Catch ex As Exception
      '  Throw ex
      'Finally
      '  m_grid.EndUpdate()
      'End Try
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Treemanager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      'm_showDetailInGrid = CInt(Me.Filters(9).Value)
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.SubcontractorInfo}") '("รหัส : ชื่อผู้รับเหมา") ' 
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.docType}")  '     "ประเภทเอกสาร")     
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.codeNumber}")  '     ("เลขที่เอกสาร") 
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.ccinfo}")          '"Cost Center "
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Unit}")             '"หน่วย"
      tr("col5") = Me.StringParserService.Parse("ปริมาณ")             '"ปริมาณ"
      tr("col6") = Me.StringParserService.Parse("ราคาต่อหน่วย")       '"ราคาต่อหน่วย"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Mat}")             '"MAT"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Lab}")       '"LAB"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Eq}")      '"EQ"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Amount}")    '"Amount+
      tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.SCbudget}")   '("SC Budget")    
      tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.DRdebit}") '("ยอดหัก DR")      
      tr("col17") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Advancepay}")  '("มัดจำ")
      tr("col20") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Retention}")    '("Retention") 
      tr("col23") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Note}")
      'tr("col23") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Debt}")      '"ยอดหนี้"
      'tr("col24") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.DebtRetention}")    '"ยอดหนี้ Retention"
      'tr("col25") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Total}")      '"รวมทั้งสิ้น"
      'tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Note}")

      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.DocNumber}")  '     ("วันที่เอกสาร")
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.ItemType}")  '     ("ประเภทรายการ")
      'tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Code}")  '     ("รหัส")
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Item}")  '     ("รายการ")
      'tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DocAmount}") '"ยอดเอกสาร"
      tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.put}")             '"ตั้ง"
      tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.withdraw}")       '"เบิก"
      tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Remain}")       '"เบิก"
      tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.put}")             '"ตั้ง"
      tr("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.withdraw}")       '"เบิก"
      tr("col16") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Remain}")       '"เบิก"
      tr("col17") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.put}")             '"ตั้ง"
      tr("col18") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.withdraw}")       '"เบิก"
      tr("col19") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Remain}")       '"เบิก"
      tr("col20") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.put}")             '"ตั้ง"
      tr("col21") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.withdraw}")       '"เบิก"
      tr("col22") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.Remain}")

      'tr("col11") = Me.StringParserService.Parse("${res:SC}")             '"ตั้ง"
      'tr("col12") = Me.StringParserService.Parse("${res:ADV}")             '"ตั้ง"
      'tr("col13") = Me.StringParserService.Parse("${res:Ret}")             '"ตั้ง"
      'tr("col14") = Me.StringParserService.Parse("${res:DR}")             '"ตั้ง"
      'tr("col15") = Me.StringParserService.Parse("${res:SC}")      '"คงเหลือ"
      'tr("col16") = Me.StringParserService.Parse("${res:ADV}")      '"คงเหลือ"
      'tr("col17") = Me.StringParserService.Parse("${res:Ret}")      '"คงเหลือ"
      'tr("col18") = Me.StringParserService.Parse("${res:DR}")    '"คงเหลือ"
      'tr("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.withdraw}")       '"เบิก"
      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                    {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 5, 2, 5), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 6, 2, 6), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 7, 2, 7), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 8, 2, 8), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 9, 2, 9), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 10, 2, 10), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 11, 2, 11), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 12, 1, 14), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 15, 1, 17), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 18, 1, 20), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 21, 1, 23), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 24, 2, 24), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 25, 2, 25), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 26, 2, 26)})
    End Sub

    Private Sub PopulateData()

      Dim dtSup As DataTable = Me.DataSet.Tables(0)
      Dim dtCC As DataTable = Me.DataSet.Tables(1)
      Dim dtDoc As DataTable = Me.DataSet.Tables(2)
      Dim dtDetail As DataTable = Me.DataSet.Tables(4)

      If dtSup.Rows.Count = 0 Then
        Return
      End If

      If dtDoc.Rows.Count = 0 Then
        Return
      End If
      Dim trSubContranctor As TreeRow
      Dim trCC As TreeRow
      Dim trSC As TreeRow
      Dim trChild As TreeRow
      Dim trItem As TreeRow

      Dim scRemain As Decimal = 0
      Dim drRemain As Decimal = 0
      Dim advRemain As Decimal = 0
      Dim retRemain As Decimal = 0

      Dim summarrySCDebt As Decimal = 0
      Dim summarryRetDebt As Decimal = 0
      Dim summarryDebt As Decimal = 0
      Dim summarryAdvDebt As Decimal = 0
      Dim currSubContract As String = ""
      Dim currCC As Integer = 0
      Dim currSC As String = ""
      Dim isFirstAdvance As Boolean = False

      Dim DocAmount As Decimal = 0
      Dim index As Integer = 2
      For Each subcontractRow As DataRow In dtSup.Rows
        Dim newSubContRow As New DataRowHelper(subcontractRow)
        'If currSubContract <> newSubContRow.GetValue(Of String)("SubcontractorInfo").ToString Then
        '  currSubContract = newSubContRow.GetValue(Of String)("SubcontractorInfo").ToString

        trSubContranctor = Me.Treemanager.Treetable.Childs.Add
        index += 1
        trSubContranctor.Tag = "Font.Bold"
        trSubContranctor.CustomFontStyle = FontStyle.Bold
        trSubContranctor("col0") = newSubContRow.GetValue(Of String)("SubcontractorInfo").ToString

        trSubContranctor.State = RowExpandState.Expanded
        m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                   {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(index, 1, index, 2)})
        summarrySCDebt = 0
        summarryRetDebt = 0
        summarryDebt = 0
        summarryAdvDebt = 0
        isFirstAdvance = False

        If currSC <> newSubContRow.GetValue(Of String)("SubcontractorInfo").ToString & ":" & newSubContRow.GetValue(Of String)("supplier_id").ToString Then
          currSC = subcontractRow("SubcontractorInfo").ToString & ":" & subcontractRow("supplier_id").ToString
          scRemain = 0
          drRemain = 0
          advRemain = 0
          retRemain = 0
        End If

        For Each ccrow As DataRow In dtCC.Select("supplier_id = " & subcontractRow("supplier_id").ToString)
          Dim newCC As New DataRowHelper(ccrow)
          'If currCC <> newCC.GetValue(Of Integer)("cc_id") Then
          'currCC = newCC.GetValue(Of Integer)("cc_id")
          trCC = trSubContranctor.Childs.Add
          index += 1
          trCC.Tag = "Font.Bold"
          trCC.CustomFontStyle = FontStyle.Bold
          trCC("col0") = newCC.GetValue(Of String)("ccinfo").ToString
          trCC.State = RowExpandState.Expanded

          m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                   {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(index, 1, index, 2)})

          For Each ScRow As DataRow In dtDoc.Select("supplier_id = " & subcontractRow("supplier_id").ToString & " and entityId = 289" _
                                               & " and cc_id =" & ccrow("cc_id").ToString) 'ขึ้น SC ใบใหม่ใน SubContractor เดียวกัน 'dt.Select("supplier_id=" & subcontractRow("Supplier_ID").ToString)
            Dim newSCRow As New DataRowHelper(ScRow)
            If Not trSubContranctor Is Nothing Then
              'ถ้ามี AdvancePay Balance มากกว่าศูนย์ก็ให้แสดงยอด ไว้รายการแรก
              If Not isFirstAdvance Then
                isFirstAdvance = True
                If Not ScRow.IsNull("ADVBalance") AndAlso CDec(ScRow("ADVBalance")) > 0 Then
                  trCC = trSubContranctor.Childs.Add
                  index += 1
                  trCC("col2") = "ยอดมัดจำจ่ายยกมา"
                  trCC("col12") = Configuration.FormatToString(CDec(ScRow("ADVBalance")), DigitConfig.Price)
                  trCC("col16") = Configuration.FormatToString((CDec(ScRow("ADVBalance")) - CDec(ScRow("advance_debit"))), DigitConfig.Price)
                  summarryAdvDebt += CDec(ScRow("ADVBalance"))
                  trCC.State = RowExpandState.Expanded
                End If
              End If
              DocAmount = newSCRow.GetValue(Of Decimal)("sc") - newSCRow.GetValue(Of Decimal)("advance") - newSCRow.GetValue(Of Decimal)("retention") + newSCRow.GetValue(Of Decimal)("dr")

              scRemain += newSCRow.GetValue(Of Decimal)("sc")
              scRemain -= newSCRow.GetValue(Of Decimal)("sc_debit")
              drRemain += newSCRow.GetValue(Of Decimal)("dr")
              drRemain -= newSCRow.GetValue(Of Decimal)("dr_debit")
              advRemain += newSCRow.GetValue(Of Decimal)("advance")
              advRemain -= newSCRow.GetValue(Of Decimal)("advance_debit")
              retRemain += newSCRow.GetValue(Of Decimal)("retention")
              retRemain -= newSCRow.GetValue(Of Decimal)("retention_debit")


              trSC = trCC.Childs.Add
              index += 1
              trSC("col0") = newSCRow.GetValue(Of Date)("sc_Date").ToShortDateString
              trSC("col1") = newSCRow.GetValue(Of String)("Code").ToString
              trSC("col2") = newSCRow.GetValue(Of String)("sc_Type").ToString
              trSC("col3") = newSCRow.GetValue(Of String)("ccinfo").ToString
              trSC("col10") = Configuration.FormatToString(DocAmount, DigitConfig.Price)
              trSC("col11") = Configuration.FormatToString(newSCRow.GetValue(Of Decimal)("sc"), DigitConfig.Price)
              trSC("col14") = Configuration.FormatToString(newSCRow.GetValue(Of Decimal)("advance"), DigitConfig.Price)
              trSC("col17") = Configuration.FormatToString(newSCRow.GetValue(Of Decimal)("retention"), DigitConfig.Price)
              trSC("col20") = Configuration.FormatToString(newSCRow.GetValue(Of Decimal)("dr"), DigitConfig.Price)
              trSC("col13") = Configuration.FormatToString(scRemain, DigitConfig.Price)
              trSC("col16") = Configuration.FormatToString(advRemain, DigitConfig.Price)
              trSC("col19") = Configuration.FormatToString(retRemain, DigitConfig.Price)
              trSC("col22") = Configuration.FormatToString(drRemain, DigitConfig.Price)
              trSC("col23") = newSCRow.GetValue(Of String)("sc_note")

              trSC.Tag = "Font.Bold"
              trSC.CustomFontStyle = FontStyle.Bold
              trSC.State = RowExpandState.Expanded

              Dim indent As String = Space(3)
              Dim condindent As String = ""
              'Dim currItemIndex As Integer = -1
              For Each SCitemRow As DataRow In dtDetail.Select("sci_sc=" & ScRow("sc_id").ToString & " and EntityID=" & ScRow("entityID").ToString & " and Id=" & ScRow("id").ToString _
                                                        & " and sc_cc =" & ccrow("cc_id").ToString)
                Dim newItem As New DataRowHelper(SCitemRow)
                If Not trSC Is Nothing Then

                  trItem = trSC.Childs.Add
                  index += 1
                  If newItem.GetValue(Of Integer)("sci_entityType") = 289 Then
                    trItem("col1") = newItem.GetValue(Of String)("itemType").ToString
                    trItem.Tag = "Font.Bold"
                    trItem.CustomFontStyle = FontStyle.Bold
                    condindent = ""
                  Else
                    trItem("col1") = indent & newItem.GetValue(Of String)("itemType").ToString
                    condindent = indent
                  End If
                  If newItem.GetValue(Of String)("LciInfo").Length > 0 Then
                    trItem("col2") = condindent & newItem.GetValue(Of String)("LciInfo").ToString
                  Else
                    trItem("col2") = condindent & newItem.GetValue(Of String)("itemName").ToString
                  End If
                  trItem("col4") = newItem.GetValue(Of String)("Unit").ToString
                  trItem("col5") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("Qty"), DigitConfig.Price)
                  trItem("col6") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("UnitPrice"), DigitConfig.Price)
                  trItem("col7") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("MAT"), DigitConfig.Price)
                  trItem("col8") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("LAB"), DigitConfig.Price)
                  trItem("col9") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("EQ"), DigitConfig.Price)
                  trItem("col10") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("Amount"), DigitConfig.Price)
                End If

                'trItem.State = RowExpandState.Expanded
              Next

              For Each childRow As DataRow In dtDoc.Select("supplier_id = " & subcontractRow("supplier_id").ToString & " and sc_id = " & ScRow("sc_id").ToString & " and entityId <> 289")
                Dim newChild As New DataRowHelper(childRow)

                DocAmount = newChild.GetValue(Of Decimal)("sc") - newChild.GetValue(Of Decimal)("advance") - newChild.GetValue(Of Decimal)("retention") + newChild.GetValue(Of Decimal)("dr")


                scRemain += newChild.GetValue(Of Decimal)("sc")
                scRemain -= newChild.GetValue(Of Decimal)("sc_debit")
                drRemain += newChild.GetValue(Of Decimal)("dr")
                drRemain -= newChild.GetValue(Of Decimal)("dr_debit")
                advRemain += newChild.GetValue(Of Decimal)("advance")
                advRemain -= newChild.GetValue(Of Decimal)("advance_debit")
                retRemain += newChild.GetValue(Of Decimal)("retention")
                retRemain -= newChild.GetValue(Of Decimal)("retention_debit")


                trChild = trSC.Childs.Add
                index += 1
                trChild("col0") = newChild.GetValue(Of Date)("sc_Date").ToShortDateString
                trChild("col1") = newChild.GetValue(Of String)("Code").ToString
                trChild("col2") = newChild.GetValue(Of String)("sc_Type").ToString
                trChild("col3") = newChild.GetValue(Of String)("ccinfo").ToString
                trChild("col10") = Configuration.FormatToString(DocAmount, DigitConfig.Price)
                trChild("col11") = Configuration.FormatToString(newChild.GetValue(Of Decimal)("sc"), DigitConfig.Price)
                trChild("col14") = Configuration.FormatToString(newChild.GetValue(Of Decimal)("advance"), DigitConfig.Price)
                trChild("col17") = Configuration.FormatToString(newChild.GetValue(Of Decimal)("retention"), DigitConfig.Price)
                trChild("col20") = Configuration.FormatToString(newChild.GetValue(Of Decimal)("dr"), DigitConfig.Price)
                trChild("col13") = Configuration.FormatToString(scRemain, DigitConfig.Price)
                trChild("col16") = Configuration.FormatToString(advRemain, DigitConfig.Price)
                trChild("col19") = Configuration.FormatToString(retRemain, DigitConfig.Price)
                trChild("col22") = Configuration.FormatToString(drRemain, DigitConfig.Price)
                If newChild.GetValue(Of Integer)("entityId") = 292 Then
                  DocAmount = newChild.GetValue(Of Decimal)("sc_debit") - newChild.GetValue(Of Decimal)("advance_debit") - newChild.GetValue(Of Decimal)("retention_debit") + newChild.GetValue(Of Decimal)("dr_debit")
                  trChild("col10") = Configuration.FormatToString(DocAmount, DigitConfig.Price)
                  trChild("col12") = Configuration.FormatToString(newChild.GetValue(Of Decimal)("sc_debit"), DigitConfig.Price)
                  trChild("col15") = Configuration.FormatToString(newChild.GetValue(Of Decimal)("advance_debit"), DigitConfig.Price)
                  trChild("col18") = Configuration.FormatToString(newChild.GetValue(Of Decimal)("retention_debit"), DigitConfig.Price)
                  trChild("col21") = Configuration.FormatToString(newChild.GetValue(Of Decimal)("dr_debit"), DigitConfig.Price)
                End If

                trChild.State = RowExpandState.Expanded

                'Dim currItemIndex As Integer = -1
                For Each ChilditemRow As DataRow In dtDetail.Select("sci_sc=" & ScRow("sc_id").ToString & " and EntityID=" & ScRow("entityID").ToString & " and Id=" & ScRow("Id").ToString)
                  Dim newItem As New DataRowHelper(ChilditemRow)
                  If Not trChild Is Nothing Then

                    trItem = trChild.Childs.Add
                    index += 1
                    If newItem.GetValue(Of Integer)("sci_entityType") = 289 Then
                      trItem("col1") = newItem.GetValue(Of String)("itemType").ToString
                      trItem.CustomFontStyle = FontStyle.Bold
                      condindent = ""
                    Else
                      trItem("col1") = indent & newItem.GetValue(Of String)("itemType").ToString
                      condindent = indent
                    End If
                    If newItem.GetValue(Of String)("LciInfo").Length > 0 Then
                      trItem("col2") = condindent & newItem.GetValue(Of String)("LciInfo").ToString
                    Else
                      trItem("col2") = condindent & newItem.GetValue(Of String)("itemName").ToString
                    End If
                    trItem("col4") = newItem.GetValue(Of String)("Unit").ToString
                    trItem("col5") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("Qty"), DigitConfig.Price)
                    trItem("col6") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("UnitPrice"), DigitConfig.Price)
                    trItem("col7") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("MAT"), DigitConfig.Price)
                    trItem("col8") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("LAB"), DigitConfig.Price)
                    trItem("col9") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("EQ"), DigitConfig.Price)
                    trItem("col10") = Configuration.FormatToString(newItem.GetValue(Of Decimal)("Amount"), DigitConfig.Price)
                    trItem("col23") = newItem.GetValue(Of String)("Note")
                  End If

                Next

              Next


              summarrySCDebt = scRemain - drRemain - advRemain
              summarryRetDebt = retRemain
              summarryDebt = summarrySCDebt + summarryRetDebt
              summarryAdvDebt = summarrySCDebt + summarryRetDebt

              If summarrySCDebt > 0 Then
                trSC("col20") = Configuration.FormatToString(summarrySCDebt, DigitConfig.Price)
              End If
              If summarryRetDebt > 0 Then
                trSC("col21") = Configuration.FormatToString(summarryRetDebt, DigitConfig.Price)
              End If
              If summarryDebt > 0 Then
                trSC("col22") = Configuration.FormatToString(summarryDebt, DigitConfig.Price)
              End If

            End If


          Next
          'End If


        Next



        'End If
      Next

      m_grid.RowCount += 1
      'currItemIndex = m_grid.RowCount
      'm_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
      'm_grid.RowStyles(currItemIndex).Font.Bold = True
      'm_grid.RowStyles(currItemIndex).ReadOnly = True
      ''m_grid(currTrIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.SumAll}") 'รวม
      '''m_grid(currTrIndex, 6).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price) 'ยอดเงิน
      '''m_grid(currTrIndex, 7).CellValue = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price) 'ยอดภาษี
      '''m_grid(currTrIndex, 8).CellValue = Configuration.FormatToString(SumAfterTax, DigitConfig.Price) 'ยอดรวมภาษี 

      Return
    End Sub
    Private Function SearchTag(ByVal id As Integer) As TreeRow
      If Me.m_treemanager Is Nothing Then
        Return Nothing
      End If
      Dim dt As TreeTable = m_treemanager.Treetable
      For Each row As TreeRow In dt.Rows
        If IsNumeric(row.Tag) AndAlso CInt(row.Tag) = id Then
          Return row
        End If
      Next
      Return Nothing
    End Function
    Public Overrides Function GetSimpleSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Report")
      myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col6", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col7", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col14", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col15", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col16", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col17", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col18", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col19", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col20", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col21", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col22", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col23", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col24", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col25", GetType(String)))

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList

      widths.Add(100)
      widths.Add(120)
      widths.Add(200)
      widths.Add(0)
      widths.Add(50)
      widths.Add(50)
      widths.Add(100) '6
      widths.Add(80) '7
      widths.Add(80) '8
      widths.Add(80) '9
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100) '19
      widths.Add(100) '20
      widths.Add(100) '21
      widths.Add(100) '22
      widths.Add(100)
      widths.Add(100)
      widths.Add(0)
      widths.Add(0)

      For i As Integer = 0 To 25
        If i = 0 Then

          Dim cs As New PlusMinusTreeTextColumn
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          cs.ReadOnly = True
          cs.Format = "s"
          AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        Else
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          If i >= 5 AndAlso i <= 25 Then
            cs.DataAlignment = HorizontalAlignment.Right
          Else
            cs.DataAlignment = HorizontalAlignment.Left
          End If
          'Select Case i
          '    Case 0, 1
          '        cs.Alignment = HorizontalAlignment.Left
          '        cs.DataAlignment = HorizontalAlignment.Left
          '        cs.Format = "s"
          '    Case Else
          '        cs.Alignment = HorizontalAlignment.Right
          '        cs.DataAlignment = HorizontalAlignment.Right
          '        cs.Format = "d"
          'End Select


          cs.ReadOnly = True

          AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        End If
      Next

      Return dst
    End Function
    Public Overrides Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If e.Row <= 1 Then
        e.HilightValue = True
      End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptSCMovementEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptSCMovementEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptSCMovementEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCMovementEnumerate.ListLabel}"
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
#End Region#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "RptSCMovementEnumerate"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptSCMovementEnumerate"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      'Dim dpiColl As New DocPrintingItemCollection
      'Dim dpi As DocPrintingItem

      'For Each fixDpi As DocPrintingItem In Me.FixValueCollection
      '    dpiColl.Add(fixDpi)
      'Next

      'Dim LineNumber As Integer = 0

      'Dim n As Integer = 0
      'Dim i As Integer = 0
      'For rowIndex As Integer = 1 To m_grid.RowCount
      '    i += 1
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.LineNumber"
      '    dpi.Value = i
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col0"
      '    dpi.Value = m_grid(rowIndex, 1).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col1"
      '    dpi.Value = m_grid(rowIndex, 2).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col2"
      '    dpi.Value = m_grid(rowIndex, 3).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col3"
      '    dpi.Value = m_grid(rowIndex, 4).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col4"
      '    dpi.Value = m_grid(rowIndex, 5).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col5"
      '    dpi.Value = m_grid(rowIndex, 6).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col6"
      '    dpi.Value = m_grid(rowIndex, 7).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col7"
      '    dpi.Value = m_grid(rowIndex, 8).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col8"
      '    dpi.Value = m_grid(rowIndex, 9).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col9"
      '    dpi.Value = m_grid(rowIndex, 10).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col10"
      '    dpi.Value = m_grid(rowIndex, 11).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col11"
      '    dpi.Value = m_grid(rowIndex, 12).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col12"
      '    dpi.Value = m_grid(rowIndex, 13).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col13"
      '    dpi.Value = m_grid(rowIndex, 14).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col14"
      '    dpi.Value = m_grid(rowIndex, 15).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "col15"
      '    dpi.Value = m_grid(rowIndex, 16).CellValue
      '    dpi.DataType = "System.String"
      '    dpi.Row = n + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)


      '    n += 1
      'Next

      'Return dpiColl
    End Function
#End Region
  End Class
End Namespace
