Imports System.Xml
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Namespace Longkong.AdobeForm
  Public Class TableControl
    Inherits BorderyControl

#Region "Members"
    Private m_columns As ColumnCollection
    Private m_headerHeight As Integer
    Private m_headerFont As Font
    Private m_rowHeight As Integer
    Private m_rowsPerPage As Integer

    Private m_headerBackColor As Color
    Private m_headerForeColor As Color
    Private m_formFormatCode As String
    Private m_tableName As String

    Private m_cellTopEdge As New Edge
    Private m_cellBottomEdge As New Edge

    Private m_rowCount As Integer

    Private m_currentRow As Integer
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_headerHeight = 60
      m_headerFont = Me.Font
      m_columns = New ColumnCollection(Me)
      m_rowsPerPage = 10
      m_rowHeight = 30
      m_tableName = "Item"

      m_headerBackColor = Me.BackColor
      m_headerForeColor = Me.ForeColor

    End Sub
    Public Sub New(ByVal xmlNode As XmlNode)
      MyBase.New(xmlNode)
      m_headerHeight = 60
      m_headerFont = Me.Font
      m_columns = New ColumnCollection(Me)
      m_rowsPerPage = 10
      m_rowHeight = 30
      m_tableName = "Item"

      m_headerBackColor = Me.BackColor
      m_headerForeColor = Me.ForeColor
      ProcessXmlNode(xmlNode)
    End Sub
    Private Sub ProcessXmlNode(ByVal xmlnode As XmlNode)
      'columnWidths
      Dim cols As String()
      Dim foundedNode As xmlnode
      If Not xmlnode.Attributes("columnWidths") Is Nothing Then
        cols = xmlnode.Attributes("columnWidths").Value.Split(" "c)
        Dim nodes As XmlNodeList = xmlnode.SelectNodes("subform")
        If Not nodes Is Nothing Then
          Me.m_rowsPerPage = nodes.Count
          Me.m_rowsPerLastPage = Me.m_rowsPerPage
          For i As Integer = 0 To nodes.Count - 1
            Dim cell As xmlnode = nodes(i).SelectSingleNode("draw")
            If Not cell Is Nothing Then
              Dim t As New TextControl(cell)
              If Not t.Caption Is Nothing AndAlso t.Caption.ToLower = "lastrow" Then
                Me.m_rowsPerLastPage = i + 1
              End If
            End If
          Next
        End If

        foundedNode = xmlnode.SelectSingleNode("subform")
        If Not foundedNode Is Nothing Then
          Dim cells As XmlNodeList = foundedNode.SelectNodes("draw")
          If Not cells Is Nothing Then
            For i As Integer = 0 To cells.Count - 1
              Dim node As xmlnode = cells(i)
              Dim cell As New TextControl(node)
              If i = 0 Then
                Me.m_rowHeight = cell.Height
                Me.Font = cell.CaptionFont
                Me.CellTopEdge = cell.TopEdge
                Me.CellBottomEdge = cell.BottomEdge
              End If
              Dim col As New Column(cell.Caption, cell.Caption, cell.Caption, DesignerForm.AnyThingToPixel(cols(i)), cell.HAlignment, cell.CaptionFont)
              col.LeftEdge = cell.LeftEdge
              col.RightEdge = cell.RightEdge
              Me.m_columns.Add(col)
            Next
          End If
        End If
      End If
      If Not xmlnode.Attributes("name") Is Nothing Then
        Me.TableName = xmlnode.Attributes("name").Value
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property CellTopEdge() As Edge      Get        Return m_cellTopEdge      End Get      Set(ByVal Value As Edge)        m_cellTopEdge = Value      End Set    End Property    Public Property CellBottomEdge() As Edge      Get        Return m_cellBottomEdge      End Get      Set(ByVal Value As Edge)        m_cellBottomEdge = Value      End Set    End Property
    Public Overrides Property Height() As Integer
      Get
        Return Me.m_rowsPerPage * Me.RowHeight + CInt(m_rowsPerPage * 0.55)
      End Get
      Set(ByVal Value As Integer)

      End Set
    End Property
    Public Property LastPageHeight() As Integer
      Get
        Return Me.m_rowsPerLastPage * Me.RowHeight + CInt(m_rowsPerPage * 0.55)
      End Get
      Set(ByVal Value As Integer)

      End Set
    End Property
    Public Overrides Property Width() As Integer
      Get
        Return m_columns.TotalColWidth
      End Get
      Set(ByVal Value As Integer)

      End Set
    End Property
    '<ControlProperty("สีพื้นของหัวตาราง", Description:="สีพื้นของหัวตาราง", Category:="หัวตาราง")> _    Public Property HeaderBackColor() As Color      Get        Return m_headerBackColor      End Get      Set(ByVal Value As Color)        m_headerBackColor = Value      End Set    End Property    '<ControlProperty("สีตัวหนังสือของหัวตาราง", Description:="สีตัวหนังสือของหัวตาราง", Category:="หัวตาราง")> _    Public Property HeaderForeColor() As Color      Get        Return m_headerForeColor      End Get      Set(ByVal Value As Color)        m_headerForeColor = Value      End Set    End Property
    '<ControlProperty("ความสูงของหัวตาราง", Description:="ความสูงของหัวตาราง", Category:="หัวตาราง")> _    Public Property HeaderHeight() As Integer      Get        Return m_headerHeight      End Get      Set(ByVal Value As Integer)        m_headerHeight = Value      End Set    End Property
    '<ControlProperty("Font หัวตาราง", Description:="Font หัวตาราง", Category:="หัวตาราง")> _
    Public Property HeaderFont() As Font      Get        Return m_headerFont      End Get      Set(ByVal Value As Font)        m_headerFont = Value      End Set    End Property
    '<ControlProperty("คอลัมน์", Description:="คอลัมน์ต่างๆในตาราง", Category:="ข้อมูล")> _
    Public Property Columns() As ColumnCollection      Get        Return m_columns      End Get      Set(ByVal Value As ColumnCollection)        m_columns = Value      End Set    End Property    '<ControlProperty("ความสูงของแถว", Description:="ความสูงของแถว", Category:="ข้อมูล")> _    Public Property RowHeight() As Integer      Get        Return m_rowHeight      End Get      Set(ByVal Value As Integer)        m_rowHeight = Value      End Set    End Property    '<ControlProperty("จำนวนแถวต่อหน้า", Description:="จำนวนแถวต่อหน้า", Category:="ข้อมูล")> _    Public Property RowsPerPage() As Integer      Get        Return m_rowsPerPage      End Get      Set(ByVal Value As Integer)        m_rowsPerPage = Value      End Set    End Property    Private m_rowsPerLastPage As Integer    Public Property RowsPerLastPage() As Integer      Get        Return m_rowsPerLastPage      End Get      Set(ByVal Value As Integer)        m_rowsPerLastPage = Value      End Set    End Property    '<ControlProperty("สีพื้น", Description:="สีพื้น", Category:="ลักษณะ")> _
    Public Property BackColor() As System.Drawing.Color
      Get
        Return MyBase.FillColor
      End Get
      Set(ByVal Value As System.Drawing.Color)
        MyBase.FillColor = Value
      End Set
    End Property
    '<ControlProperty("สีตัวหนังสือ", Description:="สีตัวหนังสือ", Category:="ลักษณะ")> _
    Public Property ForeColor() As System.Drawing.Color
      Get
        Return MyBase.CaptionColor
      End Get
      Set(ByVal Value As System.Drawing.Color)
        MyBase.CaptionColor = Value
      End Set
    End Property
    '<ControlProperty("ตำแหน่ง", Description:="ตำแหน่ง", Category:="การจัดวาง")> _
    Public Shadows Property Location() As Point
      Get
        Return MyBase.Location
      End Get
      Set(ByVal Value As Point)
        MyBase.Location = Value
      End Set
    End Property
    Public Property Font() As System.Drawing.Font
      Get
        Return MyBase.CaptionFont
      End Get
      Set(ByVal Value As System.Drawing.Font)
        MyBase.CaptionFont = Value
      End Set
    End Property
    '<ControlProperty("รูปแบบฟอร์ม", Description:="รูปแบบฟอร์ม", Category:="ข้อมูล")> _
    Public Property FormFormatCode() As String      Get        Return m_formFormatCode      End Get      Set(ByVal Value As String)        m_formFormatCode = Value        For Each col As Column In Me.Columns
          col.FormFormatCode = Value
        Next      End Set    End Property    '<ControlProperty("ตารางในรูปแบบฟอร์ม", Description:="ตารางในรูปแบบฟอร์ม", Category:="ข้อมูล")> _    Public Property TableName() As String      Get        Return m_tableName      End Get      Set(ByVal Value As String)        m_tableName = Value        For Each col As Column In Me.Columns
          col.Table = Value
        Next      End Set    End Property

    Public Property RowCount() As Integer
      Get
        Return m_rowCount
      End Get
      Set(ByVal Value As Integer)
        m_rowCount = Value
      End Set
    End Property
    Private m_printRowCount As Integer
    Public Property PrintRowCount() As Integer
      Get
        Return m_printRowCount
      End Get
      Set(ByVal Value As Integer)
        m_printRowCount = Value
      End Set
    End Property
    Public Property CurrentRow() As Integer
      Get
        Return m_currentRow
      End Get
      Set(ByVal Value As Integer)
        m_currentRow = Value
      End Set
    End Property
    Public ReadOnly Property EndOfTable() As Boolean
      Get
        Return CurrentRow >= RowCount
      End Get
    End Property
#End Region

#Region "Methods"
    Public Overloads Overrides Sub Draw(ByVal g As Graphics, ByVal loc As Point)
      Dim Rect As New RectangleF(Location.X, Location.Y, Width, Height)
      Dim fillBr As New SolidBrush(FillColor)
      g.FillRectangle(fillBr, Rect)

      DrawEdge(g, Me.LeftEdge, LeftRightTopBottom.Left)
      DrawEdge(g, Me.RightEdge, LeftRightTopBottom.Right)
      DrawEdge(g, Me.TopEdge, LeftRightTopBottom.Top)
      DrawEdge(g, Me.BottomEdge, LeftRightTopBottom.Bottom)

      'Draw the column header line
      'g.DrawLine(p, loc.X, loc.Y + Me.m_headerHeight, loc.X + Me.Width, loc.Y + Me.m_headerHeight)


      'Draw the columns
      Dim p As New Pen(BorderColor)
      Dim colOffset As Integer = 0
      Dim i As Integer = 0
      For Each col As Column In Me.Columns
        colOffset = col.Width + colOffset
        If i <> Me.Columns.Count - 1 Then
          If col.RightEdge.BorderThickness > 0 Then
            p.Width = col.RightEdge.BorderThickness
            g.DrawLine(p, loc.X + colOffset, loc.Y, loc.X + colOffset, loc.Y + Me.Height)
          End If
        End If
        i += 1
      Next
      p.Dispose()
    End Sub
    Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal data As String)
      Me.Draw(g, loc)
    End Sub
    Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal image As Image)
      Me.Draw(g, loc)
    End Sub
    Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
      Me.Draw(g, Me.Location)
    End Sub
#End Region

  End Class
  Public Class Column

#Region "Members"
    Private m_text As String
    Private m_alias As String
    Private m_reportField As String
    Private m_width As Integer
    Private m_alignment As HorizontalAlignment
    Private m_headerAlignment As HorizontalAlignment
    Private m_formFormatCode As String
    Private m_table As String
    Private m_isReport As Boolean

    Private m_leftEdge As New Edge
    Private m_rightEdge As New Edge

    Private m_font As Font
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal text As String, ByVal [alias] As String, ByVal reportField As String, ByVal width As Integer, ByVal alignment As HorizontalAlignment, ByVal font As Font)
      With Me
        .m_text = text
        .m_alias = [alias]
        .m_reportField = reportField
        .m_width = width
        .m_alignment = alignment
        .m_font = font
      End With
    End Sub
#End Region

#Region "Proprties"
    Public Property LeftEdge() As Edge      Get        Return m_leftEdge      End Get      Set(ByVal Value As Edge)        m_leftEdge = Value      End Set    End Property    Public Property RightEdge() As Edge      Get        Return m_rightEdge      End Get      Set(ByVal Value As Edge)        m_rightEdge = Value      End Set    End Property    Public Property Font() As Font
      Get
        Return m_font
      End Get
      Set(ByVal Value As Font)
        m_font = Value
      End Set
    End Property
    '<ControlProperty("เป็น Report", Description:="เป็น Report", Category:="อื่นๆ")> _
    Public Property IsReport() As Boolean      Get        Return m_isReport      End Get      Set(ByVal Value As Boolean)        m_isReport = Value      End Set    End Property
    '<ControlProperty("รูปแบบฟอร์มที่ใช้", Description:="รูปแบบฟอร์มที่ใช้", Category:="อื่นๆ")> _
    Public Property FormFormatCode() As String      Get        Return m_formFormatCode      End Get      Set(ByVal Value As String)        m_formFormatCode = Value      End Set    End Property    '<ControlProperty("ตารางจากรูปแบบฟอร์ม", Description:="ชื่อของตารางจากรูปแบบฟอร์ม", Category:="อื่นๆ")> _    Public Property Table() As String      Get        Return m_table      End Get      Set(ByVal Value As String)        m_table = Value      End Set    End Property    '<ControlProperty("คำบรรยาย", Description:="คำบรรยาย", Category:="ข้อมูล")> _    Public Property Text() As String
      Get
        Return m_text
      End Get
      Set(ByVal Value As String)
        m_text = Value
      End Set
    End Property
    '<ControlProperty("คำบรรยายเสริม", Description:="คำบรรยายเสริม", Category:="ข้อมูล")> _
    Public Property [Alias]() As String
      Get
        Return m_alias
      End Get
      Set(ByVal Value As String)
        m_alias = Value
      End Set
    End Property
    '<ControlProperty("ตัวแปรที่ใช้", Description:="ตัวแปรที่ใช้เป็นข้อมูล", Category:="ข้อมูล"), Editor(GetType(DataFieldTypeEditor), GetType(UITypeEditor))> _
    Public Property ReportField() As String      Get        Return m_reportField      End Get      Set(ByVal Value As String)        m_reportField = Value      End Set    End Property
    '<ControlProperty("ความกว้าง", Description:="ความกว้าง", Category:="ลักษณะ")> _
    Public Property Width() As Integer
      Get
        Return m_width
      End Get
      Set(ByVal Value As Integer)
        m_width = Value
      End Set
    End Property
    '<ControlProperty("การจัดวางข้อมูล", Description:="การจัดวางข้อมูลในแนวนอน", Category:="ลักษณะ")> _
    Public Property Alignment() As HorizontalAlignment
      Get
        Return m_alignment
      End Get
      Set(ByVal Value As HorizontalAlignment)
        m_alignment = Value
      End Set
    End Property
    '<ControlProperty("การจัดวางหัวตาราง", Description:="การจัดวางหัวตารางในแนวนอน", Category:="ลักษณะ")> _
    Public Property HeaderAlignment() As HorizontalAlignment      Get        Return m_headerAlignment      End Get      Set(ByVal Value As HorizontalAlignment)        m_headerAlignment = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Overrides Function ToString() As String
      Return Me.Text
    End Function
#End Region

  End Class
  Public Class ColumnCollection
    Inherits CollectionBase

#Region "Members"
    Private m_formTable As TableControl
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal ft As TableControl)
      m_formTable = ft
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As Column
      Get
        Return CType(MyBase.List.Item(index), Column)
      End Get
      Set(ByVal value As Column)
        MyBase.List.Item(index) = value
      End Set
    End Property
    ReadOnly Property TotalColWidth() As Integer
      Get
        Dim total As Integer = 0
        For Each col As Column In Me
          total += col.Width
        Next
        Return total
      End Get
    End Property
#End Region

#Region "Methods"
    Public Function Add(ByVal value As Column) As Integer
      value.FormFormatCode = m_formTable.FormFormatCode
      value.Table = m_formTable.TableName
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As ColumnCollection)
      For i As Integer = 0 To value.Count - 1
        value(i).FormFormatCode = m_formTable.FormFormatCode
        value(i).Table = m_formTable.TableName
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As Column())
      For i As Integer = 0 To value.Length - 1
        value(i).FormFormatCode = m_formTable.FormFormatCode
        value(i).Table = m_formTable.TableName
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As Column) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As Column(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As ItemEnumerator
      Return New ItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As Column) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As Column)
      value.FormFormatCode = m_formTable.FormFormatCode
      value.Table = m_formTable.TableName
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As Column)
      MyBase.List.Remove(value)
    End Sub
#End Region


    Public Class ItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As ColumnCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, Column)
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

