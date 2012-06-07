Imports Longkong.Pojjaman.BusinessLogic

Public Class ResponseForm
  Public Sub New(entity As ExportOutgoingCheck)
    MyBase.New()
    Me.InitializeComponent()

    Me.Construct(entity)
  End Sub
  Private Sub Construct(entity As ExportOutgoingCheck)
    Dim ds As DataSet = entity.GetResponseFromBuilkData
    Dim lsToBank As New ArrayList
    Dim lsToBuilk As New ArrayList
    Dim ident As String = Space(4)
    Dim toBankDateString As String = ""
    Dim toBuilkDateString As String = ""
    For Each row As DataRow In ds.Tables(0).Rows
      Dim ex As New exDetail
      If IsDate(row("eocheckl_exportDate")) Then
        ex.ExDate = row("eocheckl_exportDate")
      End If
      ex.Code = row("eocheckl_checkCode")
      ex.Supplier = row("eocheckl_checkSupplier")
      ex.Amount = row("eocheckl_checkAmount")
      If Not row.IsNull("eocheckl_exportType") AndAlso CStr(row("eocheckl_exportType")).Trim = "0" Then
        lsToBank.Add(ex)
        toBankDateString = "วันที่ " & ex.ExDate.ToString("dd/MM/yyyy")
      Else
        lsToBuilk.Add(ex)
        If Not Date.MinValue.Equals(ex.ExDate) Then
          toBuilkDateString = "วันที่ " & ex.ExDate.ToString("dd/MM/yyyy")
        End If
      End If
    Next
    Dim toBankAmount As Decimal = 0
    Dim toBuilkAmount As Decimal = 0
    For Each ex As exDetail In lsToBank
      toBankAmount += ex.Amount
    Next
    For Each ex As exDetail In lsToBuilk
      toBuilkAmount += ex.Amount
    Next

    ListView1.Items.Clear()
    ListView2.Items.Clear()

    ListView1.Columns(1).Text = String.Format("รายการ Export เช็คไปที่ธนาคาร {0} จำนวน {1} รายการ", toBankDateString, lsToBank.Count)
    ListView1.Columns(2).Text = String.Format("มูลค่า ({0})", Configuration.FormatToString(toBankAmount, 2))
    ListView2.Columns(1).Text = String.Format("รายการที่ Builk.com ตอบรับแล้ว {0} จำนวน {1} รายการ", toBuilkDateString, lsToBuilk.Count)
    ListView2.Columns(2).Text = String.Format("มูลค่า ({0})", Configuration.FormatToString(toBuilkAmount, 2))

    For Each ex As exDetail In lsToBank
      Dim itm As New ListViewItem
      itm.SubItems.Add(ident & ex.Code & " " & ex.Supplier)
      itm.SubItems.Add(ident & Configuration.FormatToString(ex.Amount, 2))
      ListView1.Items.Add(itm)
    Next
    For Each ex As exDetail In lsToBuilk
      Dim itm As New ListViewItem
      itm.SubItems.Add(ident & ex.Code & " " & ex.Supplier)
      itm.SubItems.Add(ident & Configuration.FormatToString(ex.Amount, 2))
      ListView2.Items.Add(itm)
    Next
  End Sub
  Private Class exDetail
    Public Property ExDate As Date
    Public Property Code As String
    Public Property Supplier As String
    Public Property Amount As Decimal
  End Class
End Class