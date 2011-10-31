Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Syncfusion.Windows.Forms.Grid
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic

Public Class RptGLPayTypeDetailForm

  Public Property ColumnName As String
  Public Property DocId As Integer
  Public Property DocType As Integer
  Public Property Amount As Decimal
  Public Property GLAcountId As Integer
  Public Property CostCenterId As Integer

  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

    Me.Text = "แสดงรายละเอียด"
    'Me.Location = New Point(bt.Location.X, bt.Location.Y)
    '' Add any initialization after the InitializeComponent() call.
    Me.ListView1.HeaderStyle = ColumnHeaderStyle.None

    Me.ListView1.AllowSort = True
    Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListView1.FullRowSelect = True
    Me.ListView1.GridLines = True
    Me.ListView1.HideSelection = True
    Me.ListView1.MultiSelect = False
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.Details
    Me.ListView1.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))

    Me.ListView1.Columns.Add("", 265)

    Me.ListView1.Items.Clear()

  End Sub

  Private Sub RptGLPayTypeDetailForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
    Dim wpX As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
    Dim wpY As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
    Dim wpL As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Left
    Dim wpT As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Top


    Dim mpX As Integer = System.Windows.Forms.Control.MousePosition.X
    Dim mpY As Integer = System.Windows.Forms.Control.MousePosition.Y

    If (mpX > wpX) OrElse (mpY > wpY) OrElse (mpX < wpL) OrElse (mpY < wpT) Then
      Me.Close()
    End If
  End Sub

  Private Sub RptGLPayTypeDetailForm_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
    Me.Close()
  End Sub

  Private Sub RptGLPayTypeDetailForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Me.Label1.Text = ColumnName.ToLower & " : " & Configuration.FormatToString(Amount, DigitConfig.Price)
    'Me.Label2.Text = DocId
    'Me.Label3.Text = DocType
    LoadDetail()
  End Sub

  Private Function LoadDetailFromDB() As DataSet
    Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString,
                                                 CommandType.StoredProcedure,
                                                 "GetDescriptionForCell",
                                                 New SqlParameter("@entity_id", Me.DocId),
                                                 New SqlParameter("@entity_type", Me.DocType),
                                                 New SqlParameter("@column_name", Me.ColumnName),
                                                 New SqlParameter("@gli_acct", Me.GLAcountId),
                                                 New SqlParameter("@cc_id", Me.CostCenterId))
    Return ds
  End Function
  Private Sub LoadDetail()
    Dim ds As DataSet
    Dim key As String = DocId.ToString & "|" & DocType.ToString
    If RptGLPayType.m_hashDescription Is Nothing Then
      RptGLPayType.m_hashDescription = New Hashtable
    End If
    If Not RptGLPayType.m_hashDescription.ContainsKey(key) Then
      ds = Me.LoadDetailFromDB
    Else
      ds = CType(RptGLPayType.m_hashDescription(key), DataSet)
    End If


    Dim lvitem As ListViewItem

    Dim amtText As String = "มูลค่า : " & Configuration.FormatToString(Me.Amount, DigitConfig.Price)
    Dim docRefText As String = ""
    Dim docRefTabText As String = ""
    Dim indent As String = Space(5)
    Dim refdocKey As String = ""
    Dim refpaymentKey As String = ""

    'lblCancel.BackColor = ConfigurationUser.GetColorConfiguration(currentUserId, "color.approve")
    lvitem = ListView1.Items.Add(amtText)
    For Each row As DataRow In ds.Tables(0).Rows
      Dim drh As New DataRowHelper(row)

      refdocKey = drh.GetValue(Of Integer)("payment_refdoc", 0).ToString & "|" & drh.GetValue(Of Integer)("payment_refDocType", 0).ToString
      Trace.WriteLine(refdocKey)

      docRefText = "เอกสารอ้างอิง (" & drh.GetValue(Of String)("entity_description", "") & ") " & drh.GetValue(Of String)("payment_refdocCode", "")
      lvitem = ListView1.Items.Add(docRefText)
      lvitem.Tag = refdocKey
      docRefText = indent & "วันที่ " & drh.GetValue(Of Date)("payment_refdocDate").ToShortDateString
      lvitem = ListView1.Items.Add(docRefText)
      lvitem.Tag = refdocKey

      Select Case ColumnName.ToLower
        Case "cash"
          docRefTabText = "เอกสารสำคัญจ่าย " & drh.GetValue(Of String)("payment_code")
          lvitem = ListView1.Items.Add(docRefTabText)
          lvitem.Tag = refdocKey
          docRefTabText = indent & "วันที่ " & drh.GetValue(Of Date)("payment_docdate").ToShortDateString
          lvitem = ListView1.Items.Add(docRefTabText)
          lvitem.Tag = refdocKey
          docRefTabText = indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("payment_gross"), DigitConfig.Price)
          lvitem = ListView1.Items.Add(docRefTabText)
          lvitem.Tag = refdocKey

          Select Case drh.GetValue(Of Integer)("paymenti_entityType", 0)
            Case 0
              docRefTabText = indent & "จ่ายชำระด้วยเงินสด ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("paymenti_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
            Case 36
              docRefTabText = indent & "จ่ายชำระด้วยเงินสดย่อย ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("paymenti_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
              docRefTabText = indent & indent & "เอกสารเงินสดย่อย " & drh.GetValue(Of String)("pc_code")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
              docRefTabText = indent & indent & indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("pc_amount"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
            Case 174
              docRefTabText = indent & "จ่ายชำระด้วยเงินทดรองจ่าย ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("paymenti_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
              docRefTabText = indent & indent & "เอกสารเงินทดรองจ่าย " & drh.GetValue(Of String)("advm_code")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
              docRefTabText = indent & indent & indent & indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("advm_amount"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
          End Select
        Case "bank"
          If drh.GetValue(Of Integer)("stock_id") > 0 Then
            docRefTabText = indent & "เอกสาร" & drh.GetValue(Of String)("stockref_description") & " " & drh.GetValue(Of String)("stock_code")
            lvitem = ListView1.Items.Add(docRefTabText)
            lvitem.Tag = drh.GetValue(Of Integer)("stock_id", 0).ToString & "|" & drh.GetValue(Of Integer)("stock_type", 0).ToString
            docRefTabText = indent & indent & "วันที่" & drh.GetValue(Of Date)("stock_docdate").ToShortDateString
            lvitem = ListView1.Items.Add(docRefTabText)
            lvitem.Tag = drh.GetValue(Of Integer)("stock_id", 0).ToString & "|" & drh.GetValue(Of Integer)("stock_type", 0).ToString
            docRefTabText = indent & indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_aftertax"), DigitConfig.Price)
            lvitem = ListView1.Items.Add(docRefTabText)
            lvitem.Tag = drh.GetValue(Of Integer)("stock_id", 0).ToString & "|" & drh.GetValue(Of Integer)("stock_type", 0).ToString
          End If

          docRefTabText = "เอกสารสำคัญจ่าย " & drh.GetValue(Of String)("payment_code")
          lvitem = ListView1.Items.Add(docRefTabText)
          lvitem.Tag = refdocKey
          docRefTabText = indent & "วันที่ " & drh.GetValue(Of Date)("payment_docdate").ToShortDateString
          lvitem = ListView1.Items.Add(docRefTabText)
          lvitem.Tag = refdocKey
          docRefTabText = indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("payment_gross"), DigitConfig.Price)
          lvitem = ListView1.Items.Add(docRefTabText)
          lvitem.Tag = refdocKey

          Select Case drh.GetValue(Of Integer)("paymenti_entityType", 0)
            Case 22
              docRefTabText = indent & "จ่ายชำระด้วยเช็คจ่าย ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("paymenti_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
              docRefTabText = indent & indent & "เอกสารเช็คจ่าย " & drh.GetValue(Of String)("outgoingcheck.check_code")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
              docRefTabText = indent & indent & indent & "เลขที่เช็ค " & drh.GetValue(Of String)("outgoingcheck.check_cqcode")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
              docRefTabText = indent & indent & indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("outgoingcheck.check_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
            Case 27
              docRefTabText = indent & "จ่ายชำระด้วยเช็ครับ ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("paymenti_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
              docRefTabText = indent & indent & "เอกสารเช็ครับ " & drh.GetValue(Of String)("incomingcheck.check_code")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
              docRefTabText = indent & indent & indent & "เลขที่เช็ค " & drh.GetValue(Of String)("incomingcheck.check_cqcode")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
              docRefTabText = indent & indent & indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("incomingcheck.check_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
            Case 65
              docRefTabText = indent & "จ่ายชำระด้วยโอนเงินจ่าย มูลค่า " & Configuration.FormatToString(drh.GetValue(Of Decimal)("paymenti_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
              docRefTabText = indent & indent & "เอกสารโอนเงินจ่าย " & drh.GetValue(Of String)("bto_code")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
              docRefTabText = indent & indent & indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("bto_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
            Case 22
              docRefTabText = indent & "จ่ายชำระด้วยตั๋วอาวัล มูลค่า " & Configuration.FormatToString(drh.GetValue(Of Decimal)("paymenti_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
              docRefTabText = indent & "เอกสารตั๋วอาวัล " & drh.GetValue(Of String)("outgoingcheck.check_code")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
              docRefTabText = indent & indent & indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("outgoingcheck.check_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = drh.GetValue(Of Integer)("paymenti_entity", 0).ToString & "|" & drh.GetValue(Of Integer)("paymenti_entityType", 0).ToString
          End Select
        Case "remain"
          Select Case drh.GetValue(Of Integer)("payment_refdocType", 0)
            Case 38
              docRefTabText = indent & drh.GetValue(Of String)("accountbook_name")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
              docRefTabText = indent & indent & "ผังบัญชี " & drh.GetValue(Of String)("acct_code") & " : " & drh.GetValue(Of String)("acct_name")
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
              docRefTabText = indent & indent & indent & drh.GetValue(Of String)("isdebit") & " " & Configuration.FormatToString(drh.GetValue(Of Decimal)("gli_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
            Case Else
              docRefTabText = indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("payment_amt"), DigitConfig.Price)
              lvitem = ListView1.Items.Add(docRefTabText)
              lvitem.Tag = refdocKey
              If drh.GetValue(Of Decimal)("payment_gross") > 0 Then
                docRefTabText = indent & indent & "เอกสารอ้างอิงการจ่าย " & drh.GetValue(Of Decimal)("payment_refdoccode")
                lvitem = ListView1.Items.Add(docRefTabText)
                lvitem.Tag = refdocKey
                docRefTabText = indent & indent & indent & "วันที่ " & drh.GetValue(Of Date)("payment_refdoccode").ToString
                lvitem = ListView1.Items.Add(docRefTabText)
                lvitem.Tag = refdocKey
                docRefTabText = indent & indent & indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("payment_amt"), DigitConfig.Price)
                lvitem = ListView1.Items.Add(docRefTabText)
                lvitem.Tag = refdocKey
              End If

              For Each row2 As DataRow In ds.Tables(0).Rows
                Dim drh2 As New DataRowHelper(row2)

                refdocKey = drh2.GetValue(Of Integer)("pays_id").ToString & "|73"

                docRefTabText = indent & indent & "เอกสารอ้างอิงการจ่าย " & drh2.GetValue(Of String)("pays_code")
                lvitem = ListView1.Items.Add(docRefTabText)
                lvitem.Tag = refdocKey
                docRefTabText = indent & indent & indent & "วันที่ " & drh.GetValue(Of Date)("pays_doccode").ToString
                lvitem = ListView1.Items.Add(docRefTabText)
                lvitem.Tag = refdocKey
                docRefTabText = indent & indent & indent & "ยอด " & Configuration.FormatToString(drh.GetValue(Of Decimal)("paysi_amt"), DigitConfig.Price)
                lvitem = ListView1.Items.Add(docRefTabText)
                lvitem.Tag = refdocKey
              Next

              Exit For
          End Select

      End Select
    Next

  End Sub

  'Private Sub RptGLPayTypeDetailForm_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ParentChanged
  '  Me.Close()
  'End Sub

  'Private Sub RptGLPayTypeDetailForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
  '  Me.Close()
  'End Sub

  'Private Sub RptGLPayTypeDetailForm_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
  '  Dim wpX As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
  '  Dim wpY As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
  '  Dim wpL As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Left
  '  Dim wpT As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Top


  '  Dim mpX As Integer = System.Windows.Forms.Control.MousePosition.X
  '  Dim mpY As Integer = System.Windows.Forms.Control.MousePosition.Y

  '  If (mpX > wpX) OrElse (mpY > wpY) OrElse (mpX < wpL) OrElse (mpY < wpT) Then
  '    Me.Close()
  '  End If
  'End Sub

  Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
    Dim keyText As String = ListView1.SelectedItems(0).Tag
    If keyText.Length = 0 Then
      Me.Close()
    Else
      Dim keySplit() As String = keyText.Split("|")

      Dim docId As Integer = CInt(keySplit(0))
      Dim docType As Integer = CInt(keySplit(1))

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End If
    Me.Close()
  End Sub

End Class