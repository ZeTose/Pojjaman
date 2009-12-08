Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.IO
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components

    Public NotInheritable Class ListViewHelper

        'Private Const LVM_GETHEADER As Integer = 4127
        'Private Const HDM_SETIMAGELIST As Integer = 4616
        Private Const LVM_SETCOLUMN As Integer = 4122
        Private Const LVCF_FMT As Integer = 1
        Private Const LVCF_IMAGE As Integer = 16

        Private Const LVCFMT_LEFT As Integer = 0
        'Private Const LVCFMT_RIGHT As Integer = 2
        'Private Const LVCFMT_CENTER As Integer = 2
        Private Const LVCFMT_IMAGE As Integer = 2048
        Private Const LVCFMT_BITMAP_ON_RIGHT As Integer = 4096
        Private Const LVCFMT_STRING As Integer = &H4000
        'Private Const LVCFMT_COL_HAS_IMAGES As Integer = 32768

        Private Const LVM_FIRST As Integer = &H1000
        Private Const LVM_GETHEADER As Integer = (LVM_FIRST + 31)

        Private Const HDI_BITMAP As Integer = &H10
        Private Const HDI_IMAGE As Integer = &H20
        Private Const HDI_FORMAT As Integer = &H4
        Private Const HDI_TEXT As Integer = &H2

        Private Const HDF_BITMAP_ON_RIGHT As Integer = &H1000
        Private Const HDF_BITMAP As Integer = &H2000
        Private Const HDF_IMAGE As Integer = &H800
        Private Const HDF_STRING As Integer = &H4000

        Private Const HDM_FIRST As Integer = &H1200
        Private Const HDM_SETITEM As Integer = (HDM_FIRST + 4)
        Private Const HDM_SETIMAGELIST As Integer = (HDM_FIRST + 8)
        Private Const HDM_GETIMAGELIST As Integer = (HDM_FIRST + 9)


        'Define the LVCOLUMN for use with Interop.
        <StructLayout(LayoutKind.Sequential, pack:=8, CharSet:=CharSet.Auto)> _
        Structure LVCOLUMN
            Dim mask As Integer
            Dim fmt As Integer
            Dim cx As Integer
            Dim pszText As IntPtr
            Dim cchTextMax As Integer
            Dim iSubItem As Integer
            Dim iImage As Integer
            Dim iOrder As Integer
        End Structure

        'Declare two overloaded SendMessage functions. The
        'difference is in the last parameter.
        <DllImport("User32.dll")> _
        Private Overloads Shared Function SendMessage _
            (ByVal hWnd As IntPtr, ByVal Msg As Integer, _
             ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
        End Function

        <DllImport("User32", CharSet:=CharSet.Auto)> _
        Private Overloads Shared Function SendMessage _
            (ByVal hWnd As IntPtr, ByVal msg As Integer, _
             ByVal wParam As Integer, ByRef lParam As LVCOLUMN) As IntPtr
        End Function

        Private Sub New()
        End Sub 'New
        '**********************************************************************
        'ใช้ method นี้เพื่อ Populate listview
        '!!!!Caution!!!!! เช็คจำนวนคอลัมน์กับ sql ให้ดี
        '**********************************************************************
        Public Shared Sub PopulateList(ByRef myList As ListView, ByVal sql As String, ByVal cols As Integer)

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim cn As New SqlConnection(sqlConString)
            cn.Open()
            Dim ds As DataSet = SqlHelper.ExecuteDataset(cn, CommandType.Text, sql)
            Dim row As DataRow
            myList.ListViewItemSorter = Nothing
            myList.Items.Clear()
            For Each row In ds.Tables(0).Select()
                Dim item As New ListViewItem(CStr(row(0)))
                myList.Items.Add(item)
                Dim i As Integer
                For i = 1 To cols - 1
                    item.SubItems.Add(CStr(row(i)))
                Next
                item.Tag = row(cols)
            Next
            cn.Close()
            cn = Nothing
            ds = Nothing
        End Sub
        Public Shared Sub PopulateList(ByRef myList As ListView, ByVal ds As DataSet, ByVal primaryIndex As Integer)

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim cn As New SqlConnection(sqlConString)
            cn.Open()
            Dim row As DataRow
            myList.ListViewItemSorter = Nothing
            myList.Items.Clear()
            For Each row In ds.Tables(0).Select()
                Dim item As New ListViewItem(CStr(row(0)))
                myList.Items.Add(item)
                Dim i As Integer
                Dim cols As Integer = ds.Tables(0).Columns.Count
                For i = 1 To cols - 1
                    item.SubItems.Add(CStr(row(i)))
                Next
                item.Tag = row(primaryIndex)
            Next
            cn.Close()
            cn = Nothing
            ds = Nothing
        End Sub
        Public Class CompareByText
            Implements IComparer

            Dim index As Integer
      Dim m_sortOrder As System.Windows.Forms.SortOrder
      Sub New(ByVal subitemIndex As Integer, ByVal sort_order As System.Windows.Forms.SortOrder)
        Me.index = subitemIndex
        Me.m_sortOrder = sort_order
      End Sub

            Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
            Implements System.Collections.IComparer.Compare
                Dim item1 As ListViewItem = CType(x, ListViewItem)
                Dim item2 As ListViewItem = CType(y, ListViewItem)
        If m_sortOrder = System.Windows.Forms.SortOrder.Ascending Then
          Return String.Compare(item1.SubItems(index).Text, item2.SubItems(index).Text)
        Else
          Return String.Compare(item2.SubItems(index).Text, item1.SubItems(index).Text)
        End If
            End Function
        End Class

        Public Class CompareByNumber
            Implements IComparer

            Dim index As Integer
      Dim m_sortOrder As System.Windows.Forms.SortOrder
      Sub New(ByVal subitemIndex As Integer, ByVal sort_order As System.Windows.Forms.SortOrder)
        Me.index = subitemIndex
        Me.m_sortOrder = sort_order
      End Sub

            Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
            Implements System.Collections.IComparer.Compare
                Dim item1 As ListViewItem = CType(x, ListViewItem)
                Dim item2 As ListViewItem = CType(y, ListViewItem)
        If m_sortOrder = System.Windows.Forms.SortOrder.Ascending Then
          If item1.SubItems(index).Text = "" And item2.SubItems(index).Text = "" Then
            Return 0
          ElseIf item1.SubItems(index).Text = "" Then
            Return -1
          ElseIf item2.SubItems(index).Text = "" Then
            Return 1
          End If
          Return Math.Sign(CDbl(item1.SubItems(index).Text) - CDbl(item2.SubItems(index).Text))
        Else
          If item1.SubItems(index).Text = "" And item2.SubItems(index).Text = "" Then
            Return 0
          ElseIf item1.SubItems(index).Text = "" Then
            Return 1
          ElseIf item2.SubItems(index).Text = "" Then
            Return -1
          End If
          Return Math.Sign(CDbl(item2.SubItems(index).Text) - CDbl(item1.SubItems(index).Text))
        End If
            End Function
        End Class

        Public Class CompareByDate
            Implements IComparer

            Dim index As Integer
      Dim m_sortOrder As System.Windows.Forms.SortOrder
      Sub New(ByVal subitemIndex As Integer, ByVal sort_order As System.Windows.Forms.SortOrder)
        Me.index = subitemIndex
        Me.m_sortOrder = sort_order
      End Sub

            Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
            Implements System.Collections.IComparer.Compare
                Dim item1 As ListViewItem = CType(x, ListViewItem)
                Dim item2 As ListViewItem = CType(y, ListViewItem)

                Dim d1 As Date = Date.MinValue
                If IsDate(item1.SubItems(index).Text) Then
                    d1 = CDate(item1.SubItems(index).Text)
                End If
                Dim d2 As Date
                If IsDate(item2.SubItems(index).Text) Then
                    d2 = CDate(item2.SubItems(index).Text)
                End If
        If m_sortOrder = System.Windows.Forms.SortOrder.Ascending Then
          Return Date.Compare(d1, d2)
        Else
          Return Date.Compare(d2, d1)
        End If
            End Function
        End Class
        Public Shared Sub PaintAlternatingBackColor(ByVal lv As ListView, ByVal color1 As Color, ByVal color2 As Color)
            Dim item As ListViewItem
            For Each item In lv.Items
                PaintAlternatingBackColor(item, color1, color2)
            Next
        End Sub
        Public Shared Sub PaintAlternatingBackColor(ByVal item As ListViewItem, ByVal color1 As Color, ByVal color2 As Color)
            Dim subitem As ListViewItem.ListViewSubItem
            If (item.Index Mod 2) = 0 Then
                item.BackColor = color1
            Else
                item.BackColor = color2
            End If

            For Each subitem In item.SubItems
                subitem.BackColor = item.BackColor
            Next
        End Sub
        Public Shared Sub Search(ByVal myList As ListView, ByVal criteria As String)
            If criteria = "" Then
                Return
            End If
            myList.BeginUpdate()
            Dim i As Integer
            While i < myList.Items.Count
                Dim j As Integer
                Dim item As ListViewItem = myList.Items(i)
                i += 1
                Dim found As Boolean = False
                For j = 0 To item.SubItems.Count - 1
                    Dim subitem As ListViewItem.ListViewSubItem = item.SubItems(j)
                    If subitem.Text.ToUpper.IndexOf(criteria.ToUpper) >= 0 Then
                        HilightItem(item)
                        found = True
                        Exit For
                    End If
                Next
                If Not found Then
                    item.Remove()
                    i -= 1
                End If
            End While
            myList.EndUpdate()
        End Sub
        Public Shared Sub HilightItem(ByVal item As ListViewItem)
            'item.BackColor = Color.FromKnownColor(KnownColor.Green)
            item.ForeColor = Color.Red
            item.EnsureVisible()
        End Sub
        Public Shared Sub SetHeaderImage(ByRef LV As ListView, ByVal colIndex As Integer, ByVal img As Integer, ByVal showImage As Boolean)
            Dim iml As New ImageList
            iml.ColorDepth = ColorDepth.Depth32Bit
            Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
            iml.Images.Add(myIconService.GetBitmap("Icons.16x16.ListView.HeaderUpArrow"))
            iml.Images.Add(myIconService.GetBitmap("Icons.16x16.ListView.HeaderDownArrow"))
            SetHeaderImage(LV, iml, colIndex, img, showImage)
        End Sub
        Public Shared Sub SetHeaderImage(ByRef LV As ListView, ByVal ImgList As ImageList, ByVal colIndex As Integer, ByVal img As Integer, ByVal showImage As Boolean)
            Dim hwnd As IntPtr
            Dim lret As IntPtr
            'Assign the ImageList to the header control.
            'The header control includes all columns.
            'Get a handle to the header control.
            hwnd = SendMessage(LV.Handle, LVM_GETHEADER, 0, 0)

            'Add the ImageList to the header control.
            lret = SendMessage(hwnd, HDM_SETIMAGELIST, 0, (ImgList.Handle).ToInt32)

            'The code to follow uses successive images in the ImageList to loop  
            'through all columns and place successive columns in the ColumnHeader.
            'This code uses LVCOLUMN to define alignment. By using LVCOLUMN here, 
            'you reset the alignment if it was defined in the designer. 
            'If you need to set the alignment, you must change the code below to set it here.
            'Use the LVM_SETCOLUMN message to set the column's image index. 
            Dim col As LVCOLUMN
            col.mask = LVCF_FMT Or LVCF_IMAGE

            If Not showImage Then
                col.fmt = LVCFMT_STRING
            Else
                col.fmt = LVCFMT_IMAGE Or LVCFMT_BITMAP_ON_RIGHT
            End If

            'The image to use from the Image List.
            col.iImage = img
            col.cchTextMax = 0
            col.cx = 0
            col.iOrder = 0
            col.iSubItem = 0
            col.pszText = IntPtr.op_Explicit(0)
            'Send the LVM_SETCOLUMN message.
            'The column to which you are assigning the image is defined in the third parameter.
            lret = SendMessage(LV.Handle, LVM_SETCOLUMN, colIndex, col)
        End Sub
        Public Shared Function SearchTag(ByVal lv As ListView, ByVal t As Integer) As ListViewItem
            For Each item As ListViewItem In lv.Items
                If IsNumeric(item.Tag) AndAlso CInt(item.Tag) = t Then
                    Return item
                End If
            Next
        End Function
        Public Shared Function SearchTag(ByVal lv As ListView, ByVal t As String) As ListViewItem
            For Each item As ListViewItem In lv.Items
                If Not item.Tag Is Nothing AndAlso CStr(item.Tag) = t Then
                    Return item
                End If
            Next
        End Function
    End Class
End Namespace

