Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Components
  Public Class PJMListView
    Inherits ListView

#Region "Const"
    'Private Const LVM_GETHEADER As Integer = 4127
    'Private Const HDM_SETIMAGELIST As Integer = 4616
    Private Const LVM_SETCOLUMN As Integer = 4122
    Private Const LVCF_FMT As Integer = 1
    Private Const LVCF_IMAGE As Integer = 16

    Private Const LVCFMT_LEFT As Integer = 0
    Private Const LVCFMT_RIGHT As Integer = 1
    Private Const LVCFMT_CENTER As Integer = 2
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
#End Region

#Region "Win32"
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
#End Region

#Region "Members"
    Private m_sortIndex As Integer
    Private m_sortOrder As SortOrder
    Private m_allowSort As Boolean
    Public Event SortChanged()
#End Region

#Region "Constructos"
    Public Sub New()
      MyBase.New()
      m_sortIndex = -1
      m_sortOrder = SortOrder.None
      m_allowSort = True
    End Sub
#End Region

#Region "Properties"
    <Browsable(False)> _
    Public Property SortIndex() As Integer      Get        Return m_sortIndex      End Get      Set(ByVal Value As Integer)        m_sortIndex = Value      End Set    End Property    <Browsable(False)> _    Public Property SortOrder() As SortOrder      Get        Return m_sortOrder      End Get      Set(ByVal Value As SortOrder)        m_sortOrder = Value        RaiseEvent SortChanged()      End Set    End Property
    Public Property AllowSort() As Boolean      Get        Return m_allowSort      End Get      Set(ByVal Value As Boolean)        m_allowSort = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Shadows Function GetItemAt(ByVal x As Integer, ByVal y As Integer) As ListViewItem
      Return MyBase.GetItemAt(x, y)
    End Function
    Public Sub PaintAlternatingBackColor(ByVal color1 As Color, ByVal color2 As Color)
      For Each item As ListViewItem In Me.Items
        PaintAlternatingBackColor(item, color1, color2)
      Next
    End Sub
    Public Sub PaintAlternatingBackColor(ByVal item As ListViewItem, ByVal color1 As Color, ByVal color2 As Color)
      If (item.Index Mod 2) = 0 Then
        SetColors(item, color1, SystemColors.ControlText)
      Else
        SetColors(item, color2, SystemColors.ControlText)
      End If
    End Sub
    Public Sub SetColors(ByVal item As ListViewItem, ByVal bgColor As Color, ByVal fontColor As Color)
      item.BackColor = bgColor
      item.ForeColor = fontColor
      For Each subitem As ListViewItem.ListViewSubItem In item.SubItems
        subitem.BackColor = item.BackColor
        subitem.ForeColor = item.ForeColor
      Next
    End Sub
    Public Shared Sub SetHeaderImage(ByRef LV As ListView, ByVal colIndex As Integer, ByVal img As Integer, ByVal showImage As Boolean, ByVal align As HorizontalAlignment)
      Dim iml As New ImageList
      iml.ColorDepth = ColorDepth.Depth32Bit
      Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
      iml.Images.Add(myIconService.GetBitmap("Icons.16x16.ListView.HeaderUpArrow"))
      iml.Images.Add(myIconService.GetBitmap("Icons.16x16.ListView.HeaderDownArrow"))
      SetHeaderImage(LV, iml, colIndex, img, showImage, align)
    End Sub
    Public Shared Sub SetHeaderImage(ByRef LV As ListView, ByVal ImgList As ImageList, ByVal colIndex As Integer, ByVal img As Integer, ByVal showImage As Boolean, ByVal align As HorizontalAlignment)
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

      Select Case align
        Case HorizontalAlignment.Center
          col.fmt = LVCFMT_CENTER
        Case HorizontalAlignment.Left
          col.fmt = LVCFMT_LEFT
        Case HorizontalAlignment.Right
          col.fmt = LVCFMT_RIGHT
      End Select

      If showImage Then
        col.fmt = col.fmt Or LVCFMT_IMAGE Or LVCFMT_BITMAP_ON_RIGHT
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
#End Region

#Region "Overrides"
    Protected Overrides Sub OnColumnClick(ByVal e As System.Windows.Forms.ColumnClickEventArgs)
      MyBase.OnColumnClick(e)
      For i As Integer = 0 To Me.Columns.Count - 1
        SetHeaderImage(Me, i, 0, False, Me.Columns(i).TextAlign)
      Next
      If Me.m_allowSort Then
        If Me.m_sortIndex <> e.Column Then
          Me.m_sortOrder = SortOrder.Ascending
          SetHeaderImage(Me, e.Column, 0, True, Me.Columns(e.Column).TextAlign)
        Else
          If Me.m_sortOrder <> SortOrder.Ascending Then
            Me.m_sortOrder = SortOrder.Ascending
            SetHeaderImage(Me, e.Column, 0, True, Me.Columns(e.Column).TextAlign)
          ElseIf Me.m_sortOrder <> SortOrder.Descending Then
            Me.m_sortOrder = SortOrder.Descending
            SetHeaderImage(Me, e.Column, 1, True, Me.Columns(e.Column).TextAlign)
          End If
        End If
        Me.m_sortIndex = e.Column
        RaiseEvent SortChanged()
      Else
        Me.m_sortOrder = SortOrder.Ascending
        Me.m_sortIndex = -1
      End If
    End Sub
#End Region

  End Class
End Namespace

