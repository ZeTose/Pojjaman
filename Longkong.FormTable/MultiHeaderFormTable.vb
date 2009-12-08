Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.FormTable
    <Designer(GetType(FormTableDesigner))> _
    Public Class MultiHeaderFormTable
        Inherits BasePropertyControl
        Implements IDrawable

#Region " Windows Form Designer generated code "
        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        End Sub

#End Region

#Region "Members"
        Private m_MultiHeaderColumns As MultiHeaderColumnCollection
        Private m_headerHeight As Integer
        Private m_headerFont As Font
        Private m_rowHeight As Integer
        Private m_rowsPerPage As Integer
        Private m_showVerticalLine As Boolean = True

        Private m_borderColor As Color
        Private m_headerBackColor As Color
        Private m_headerForeColor As Color
        Private m_formFormatCode As String
        Private m_tableName As String


        Private m_site As ISite
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()

            Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or _
            ControlStyles.DoubleBuffer Or _
            ControlStyles.AllPaintingInWmPaint Or _
            ControlStyles.UserPaint, True)

            Me.SetStyle(ControlStyles.ResizeRedraw, True)

            m_headerHeight = 60
            m_headerFont = Me.Font
            m_MultiHeaderColumns = New MultiHeaderColumnCollection(Me)
            m_rowsPerPage = 10
            m_rowHeight = 30
            SetHeight()

            m_borderColor = Color.Black
            m_headerBackColor = Me.BackColor
            m_headerForeColor = Me.ForeColor

        End Sub
#End Region

#Region "Properties"
        <ControlProperty("แสดงเส้นแนวตั้ง", Description:="แสดงเส้นแนวตั้ง", Category:="ลักษณะ")> _
        Public Property ShowVerticalLine() As Boolean            Get                Return m_showVerticalLine            End Get            Set(ByVal Value As Boolean)                m_showVerticalLine = Value            End Set        End Property
        <ControlProperty("สีพื้นของหัวตาราง", Description:="สีพื้นของหัวตาราง", Category:="หัวตาราง")> _        Public Property HeaderBackColor() As Color            Get                Return m_headerBackColor            End Get            Set(ByVal Value As Color)                m_headerBackColor = Value                Me.Invalidate()            End Set        End Property        <ControlProperty("สีตัวหนังสือของหัวตาราง", Description:="สีตัวหนังสือของหัวตาราง", Category:="หัวตาราง")> _        Public Property HeaderForeColor() As Color            Get                Return m_headerForeColor            End Get            Set(ByVal Value As Color)                m_headerForeColor = Value                Me.Invalidate()            End Set        End Property
        <ControlProperty("ความสูงของหัวตาราง", Description:="ความสูงของหัวตาราง", Category:="หัวตาราง")> _        Public Property HeaderHeight() As Integer            Get                Return m_headerHeight            End Get            Set(ByVal Value As Integer)                m_headerHeight = Value                SetHeight()                'Me.Invalidate()            End Set        End Property
        <ControlProperty("Font หัวตาราง", Description:="Font หัวตาราง", Category:="หัวตาราง")> _
        Public Property HeaderFont() As Font            Get                Return m_headerFont            End Get            Set(ByVal Value As Font)                m_headerFont = Value                Me.Invalidate()            End Set        End Property

        <ControlProperty("สีของเส้นขอบ", Description:="สีของเส้นขอบ", Category:="ลักษณะ")> _
        Public Property BorderColor() As Color            Get                Return m_borderColor            End Get            Set(ByVal Value As Color)                m_borderColor = Value                Me.Invalidate()            End Set        End Property        <ControlProperty("คอลัมน์", Description:="คอลัมน์ต่างๆในตาราง", Category:="ข้อมูล")> _
        Public Property MultiHeaderColumns() As MultiHeaderColumnCollection            Get                Return m_MultiHeaderColumns            End Get            Set(ByVal Value As MultiHeaderColumnCollection)                m_MultiHeaderColumns = Value                Me.Invalidate()            End Set        End Property        <ControlProperty("ความสูงของแถว", Description:="ความสูงของแถว", Category:="ข้อมูล")> _        Public Property RowHeight() As Integer            Get                Return m_rowHeight            End Get            Set(ByVal Value As Integer)                m_rowHeight = Value                SetHeight()            End Set        End Property        <ControlProperty("จำนวนแถวต่อหน้า", Description:="จำนวนแถวต่อหน้า", Category:="ข้อมูล")> _        Public Property RowsPerPage() As Integer            Get                Return m_rowsPerPage            End Get            Set(ByVal Value As Integer)                m_rowsPerPage = Value                SetHeight()            End Set        End Property
        <ControlProperty("สีพื้น", Description:="สีพื้น", Category:="ลักษณะ")> _
        Public Overrides Property BackColor() As System.Drawing.Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                MyBase.BackColor = Value
                Me.Invalidate()
            End Set
        End Property
        <ControlProperty("สีตัวหนังสือ", Description:="สีตัวหนังสือ", Category:="ลักษณะ")> _
        Public Overrides Property ForeColor() As System.Drawing.Color
            Get
                Return MyBase.ForeColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                MyBase.ForeColor = Value
                Me.Invalidate()
            End Set
        End Property
        <ControlProperty("ตำแหน่ง", Description:="ตำแหน่ง", Category:="การจัดวาง")> _
        Public Shadows Property Location() As Point
            Get
                Return MyBase.Location
            End Get
            Set(ByVal Value As Point)
                MyBase.Location = Value
            End Set
        End Property
        <ControlProperty("ขนาด", Description:="ขนาด", Category:="การจัดวาง")> _
        Public Shadows Property Size() As Size
            Get
                Return MyBase.Size
            End Get
            Set(ByVal Value As Size)
                Dim oldHeight As Integer = MyBase.Size.Height
                MyBase.Size = New Size(Value.Width, oldHeight)
            End Set
        End Property
        <ControlProperty("Font", Description:="Font", Category:="ลักษณะ")> _
        Public Overrides Property Font() As System.Drawing.Font
            Get
                Return MyBase.Font
            End Get
            Set(ByVal Value As System.Drawing.Font)
                MyBase.Font = Value
            End Set
        End Property
        <ControlProperty("รูปแบบฟอร์ม", Description:="รูปแบบฟอร์ม", Category:="ข้อมูล")> _
        Public Property FormFormatCode() As String            Get                Return m_formFormatCode            End Get            Set(ByVal Value As String)                m_formFormatCode = Value                For Each col As MultiHeaderColumn In Me.MultiHeaderColumns
                    col.FormFormatCode = Value
                Next            End Set        End Property        <ControlProperty("ตารางในรูปแบบฟอร์ม", Description:="ตารางในรูปแบบฟอร์ม", Category:="ข้อมูล")> _        Public Property TableName() As String            Get                Return m_tableName            End Get            Set(ByVal Value As String)                m_tableName = Value                For Each col As MultiHeaderColumn In Me.MultiHeaderColumns
                    col.Table = Value
                Next            End Set        End Property
#End Region

#Region "Methods"
        Private Sub SetHeight()
            MyBase.Height = Me.RowsPerPage * Me.RowHeight + Me.HeaderHeight
        End Sub
        Public Overloads Sub Draw(ByVal g As Graphics, ByVal loc As Point) Implements IDrawable.Draw

            Dim outline As New GraphicsPath
            outline.AddRectangle(New Rectangle(loc.X, loc.Y, Me.Width - 1, Me.Height - 1))
            Dim p As New Pen(m_borderColor, 1)
            p.DashStyle = DashStyle.Solid

            g.FillRectangle(New SolidBrush(Me.m_headerBackColor), New Rectangle(loc.X, loc.Y, Width, Me.m_headerHeight))
            g.SmoothingMode = SmoothingMode.HighQuality

            If m_showVerticalLine Then
                g.DrawPath(p, outline)
            Else
                g.DrawLine(p, loc.X, loc.Y, loc.X + Me.Width - 1, loc.Y)
            End If

            'Draw the MultiHeaderColumn header line
            g.DrawLine(p, loc.X, loc.Y + Me.m_headerHeight, loc.X + Me.Width - 1, loc.Y + Me.m_headerHeight)

            'Draw the MultiHeaderColumns
            Dim colOffset As Integer = 0
            Dim verticalInterval As Integer = 5
            Dim horizontalInterval As Integer = 5
            Dim i As Integer = 0
            For Each col As MultiHeaderColumn In Me.MultiHeaderColumns
                colOffset = col.Width + colOffset
                Dim lv As Integer = 0
                For Each level As ColumnLevel In col.Levels
                    Dim textSize As SizeF = g.MeasureString(level.Text, Me.m_headerFont)
                    Dim startPoint As Integer
                    Dim aliasStartPoint As Integer
                    Select Case col.HeaderAlignment
                        Case HorizontalAlignment.Center
                            startPoint = CInt((col.Width / 2) - (textSize.Width / 2)) + colOffset - col.Width
                        Case HorizontalAlignment.Left
                            startPoint = colOffset - col.Width + horizontalInterval
                            aliasStartPoint = colOffset - col.Width + horizontalInterval
                        Case HorizontalAlignment.Right
                            startPoint = CInt(colOffset - textSize.Width - horizontalInterval)
                    End Select

                    g.DrawString(level.Text, Me.m_headerFont, New SolidBrush(Me.m_headerForeColor), loc.X + startPoint + level.Indent, loc.Y + verticalInterval + lv * textSize.Height)
                    lv += 1
                Next

                'ลากเส้นแนวตั้ง
                If m_showVerticalLine AndAlso i <> Me.MultiHeaderColumns.Count - 1 Then
                    g.DrawLine(p, loc.X + colOffset, loc.Y, loc.X + colOffset, loc.Y + Me.Height - 1)
                End If
                i += 1
            Next

            p.Dispose()
        End Sub
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal data As String) Implements IDrawable.Draw
            Me.Draw(g, loc)
        End Sub
        Public Overloads Sub Draw(ByVal g As System.Drawing.Graphics, ByVal loc As System.Drawing.Point, ByVal image As Image) Implements IDrawable.Draw
            Me.Draw(g, loc)
        End Sub
#End Region

#Region "Overrides"
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Me.Draw(e.Graphics, New Point(0, 0))
            MyBase.OnPaint(e)
        End Sub
        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            If Me.MultiHeaderColumns.Count > 0 Then
                Dim lastColWith As Integer = Me.MultiHeaderColumns(Me.MultiHeaderColumns.Count - 1).Width
                Dim totalWidth As Integer = Me.MultiHeaderColumns.TotalColWidth
                Me.MultiHeaderColumns(Me.MultiHeaderColumns.Count - 1).Width = Me.Width - (totalWidth - lastColWith)
            End If
            MyBase.OnResize(e)
        End Sub
#End Region

#Region "Hiding Properties"
        Public Overrides Property Site() As System.ComponentModel.ISite
            Get
                Return m_site
            End Get
            Set(ByVal Value As System.ComponentModel.ISite)
                m_site = Value
            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property Text() As String
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property Cursor() As System.Windows.Forms.Cursor
            Get

            End Get
            Set(ByVal Value As System.Windows.Forms.Cursor)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property Dock() As System.Windows.Forms.DockStyle
            Get

            End Get
            Set(ByVal Value As System.Windows.Forms.DockStyle)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property ImeMode() As ImeMode
            Get

            End Get
            Set(ByVal Value As ImeMode)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property TabIndex() As Integer
            Get

            End Get
            Set(ByVal Value As Integer)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property RightToLeft() As Boolean
            Get

            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property Enabled() As Boolean
            Get

            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property TabStop() As Boolean
            Get

            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
        <Browsable(False), ControlProperty("วิซิเบิ้ล", Description:="วิซิเบิ้ล", Category:="ลักษณะ")> _
        Public Shadows Property Visble() As Boolean
            Get
                Return MyBase.Visible
            End Get
            Set(ByVal Value As Boolean)
                MyBase.Visible = True
            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property ContextMenu() As System.Windows.Forms.ContextMenu
            Get

            End Get
            Set(ByVal Value As System.Windows.Forms.ContextMenu)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property AccessibleDescription() As String
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property AccessibleName() As String
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property
        <Browsable(False)> _
        Public Shadows Property AccessibleRole() As AccessibleRole
            Get

            End Get
            Set(ByVal Value As AccessibleRole)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property AllowDrop() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property Anchor() As System.Windows.Forms.AnchorStyles
            Get

            End Get
            Set(ByVal Value As System.Windows.Forms.AnchorStyles)

            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property BackgroundImage() As System.Drawing.Image
            Get

            End Get
            Set(ByVal Value As System.Drawing.Image)

            End Set
        End Property
#End Region

        Public Property Data() As String Implements IDrawable.Data
            Get

            End Get
            Set(ByVal Value As String)

            End Set
        End Property
    End Class
    Public Class ColumnLevel
        Inherits BasePropertyObject

#Region "Members"
        Private m_text As String
        Private m_reportField As String
        Private m_indent As Integer
        Private m_formFormatCode As String
        Private m_table As String
        Private m_isReport As Boolean

        Private m_dataType As String

        Private m_levelAgg As Aggregate
        Private m_pageAgg As Aggregate
        Private m_totalAgg As Aggregate
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Proprties"
        <ControlProperty("Data Type", Description:="Data Type", Category:="ข้อมูล")> _
        Public Property DataType() As String            Get                Return m_dataType            End Get            Set(ByVal Value As String)                m_dataType = Value            End Set        End Property
        <ControlProperty("ผลรวมในระดับ", Description:="ผลรวมในระดับ", Category:="ข้อมูล")> _
        Public Property LevelAgg() As Aggregate            Get                Return m_levelAgg            End Get            Set(ByVal Value As Aggregate)                m_levelAgg = Value            End Set        End Property        <ControlProperty("ผลรวมในหน้า", Description:="ผลรวมในหน้า", Category:="ข้อมูล")> _        Public Property PageAgg() As Aggregate            Get                Return m_pageAgg            End Get            Set(ByVal Value As Aggregate)                m_pageAgg = Value            End Set        End Property        <ControlProperty("ผลรวมทั้งหมด", Description:="ผลรวมทั้งหมด", Category:="ข้อมูล")> _        Public Property TotalAgg() As Aggregate            Get                Return m_totalAgg            End Get            Set(ByVal Value As Aggregate)                m_totalAgg = Value            End Set        End Property
        <ControlProperty("เป็น Report", Description:="เป็น Report", Category:="อื่นๆ")> _
        Public Property IsReport() As Boolean            Get                Return m_isReport            End Get            Set(ByVal Value As Boolean)                m_isReport = Value            End Set        End Property
        <ControlProperty("รูปแบบฟอร์มที่ใช้", Description:="รูปแบบฟอร์มที่ใช้", Category:="อื่นๆ")> _
        Public Property FormFormatCode() As String            Get                Return m_formFormatCode            End Get            Set(ByVal Value As String)                m_formFormatCode = Value            End Set        End Property        <ControlProperty("ตารางจากรูปแบบฟอร์ม", Description:="ชื่อของตารางจากรูปแบบฟอร์ม", Category:="อื่นๆ")> _        Public Property Table() As String            Get                Return m_table            End Get            Set(ByVal Value As String)                m_table = Value            End Set        End Property        <ControlProperty("คำบรรยาย", Description:="คำบรรยาย", Category:="ข้อมูล")> _        Public Property Text() As String
            Get
                Return m_text
            End Get
            Set(ByVal Value As String)
                m_text = Value
            End Set
        End Property
        <ControlProperty("ตัวแปรที่ใช้", Description:="ตัวแปรที่ใช้เป็นข้อมูล", Category:="ข้อมูล"), Editor(GetType(DataFieldTypeEditor), GetType(UITypeEditor))> _
        Public Property ReportField() As String            Get                Return m_reportField            End Get            Set(ByVal Value As String)                m_reportField = Value            End Set        End Property
        <ControlProperty("ย่อหน้า", Description:="ย่อหน้า", Category:="ลักษณะ")> _
        Public Property Indent() As Integer
            Get
                Return m_indent
            End Get
            Set(ByVal Value As Integer)
                m_indent = Value
            End Set
        End Property

#End Region

    End Class
    Public Class ColumnLevelCollection
        Inherits CollectionBase

#Region "Members"
        Private m_MultiHeaderColumn As MultiHeaderColumn
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal col As MultiHeaderColumn)
            m_MultiHeaderColumn = col
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As ColumnLevel
            Get
                Return CType(MyBase.List.Item(index), ColumnLevel)
            End Get
            Set(ByVal value As ColumnLevel)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function Add(ByVal value As ColumnLevel) As Integer
            value.FormFormatCode = m_MultiHeaderColumn.FormFormatCode
            value.Table = m_MultiHeaderColumn.Table
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As ColumnLevelCollection)
            For i As Integer = 0 To value.Count - 1
                value(i).FormFormatCode = m_MultiHeaderColumn.FormFormatCode
                value(i).Table = m_MultiHeaderColumn.Table
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As ColumnLevel())
            For i As Integer = 0 To value.Length - 1
                value(i).FormFormatCode = m_MultiHeaderColumn.FormFormatCode
                value(i).Table = m_MultiHeaderColumn.Table
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As ColumnLevel) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As ColumnLevel(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ItemEnumerator
            Return New ItemEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As ColumnLevel) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As ColumnLevel)
            value.FormFormatCode = m_MultiHeaderColumn.FormFormatCode
            value.Table = m_MultiHeaderColumn.Table
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As ColumnLevel)
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
            Public Sub New(ByVal mappings As ColumnLevelCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, ColumnLevel)
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

    Public Class MultiHeaderColumn
        Inherits BasePropertyObject

#Region "Members"
        Private m_text As String
        Private m_width As Integer
        Private m_alignment As HorizontalAlignment
        Private m_headerAlignment As HorizontalAlignment
        Private m_formFormatCode As String
        Private m_table As String
        Private m_isReport As Boolean

        Private m_levels As ColumnLevelCollection

#End Region

#Region "Constructors"
        Public Sub New()
            m_levels = New ColumnLevelCollection(Me)
        End Sub
        Public Sub New(ByVal text As String, ByVal width As Integer, ByVal alignment As HorizontalAlignment)
            With Me
                .m_text = text
                .m_width = width
                .m_alignment = alignment
            End With
        End Sub
#End Region

#Region "Proprties"
        <ControlProperty("Level", Description:="Levelต่างๆใน Column", Category:="ข้อมูล")> _
        Public Property Levels() As ColumnLevelCollection            Get                Return m_levels            End Get            Set(ByVal Value As ColumnLevelCollection)                m_levels = Value            End Set        End Property
        <ControlProperty("เป็น Report", Description:="เป็น Report", Category:="อื่นๆ")> _
        Public Property IsReport() As Boolean            Get                Return m_isReport            End Get            Set(ByVal Value As Boolean)                m_isReport = Value            End Set        End Property
        <ControlProperty("รูปแบบฟอร์มที่ใช้", Description:="รูปแบบฟอร์มที่ใช้", Category:="อื่นๆ")> _
        Public Property FormFormatCode() As String            Get                Return m_formFormatCode            End Get            Set(ByVal Value As String)                m_formFormatCode = Value            End Set        End Property        <ControlProperty("ตารางจากรูปแบบฟอร์ม", Description:="ชื่อของตารางจากรูปแบบฟอร์ม", Category:="อื่นๆ")> _        Public Property Table() As String            Get                Return m_table            End Get            Set(ByVal Value As String)                m_table = Value            End Set        End Property        <ControlProperty("คำบรรยาย", Description:="คำบรรยาย", Category:="ข้อมูล")> _        Public Property Text() As String
            Get
                Return m_text
            End Get
            Set(ByVal Value As String)
                m_text = Value
            End Set
        End Property
        <ControlProperty("ความกว้าง", Description:="ความกว้าง", Category:="ลักษณะ")> _
        Public Property Width() As Integer
            Get
                Return m_width
            End Get
            Set(ByVal Value As Integer)
                m_width = Value
            End Set
        End Property
        <ControlProperty("การจัดวางข้อมูล", Description:="การจัดวางข้อมูลในแนวนอน", Category:="ลักษณะ")> _
        Public Property Alignment() As HorizontalAlignment
            Get
                Return m_alignment
            End Get
            Set(ByVal Value As HorizontalAlignment)
                m_alignment = Value
            End Set
        End Property
        <ControlProperty("การจัดวางหัวตาราง", Description:="การจัดวางหัวตารางในแนวนอน", Category:="ลักษณะ")> _
        Public Property HeaderAlignment() As HorizontalAlignment            Get                Return m_headerAlignment            End Get            Set(ByVal Value As HorizontalAlignment)                m_headerAlignment = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Overrides Function ToString() As String
            Return Me.Text
        End Function
#End Region

    End Class
    Public Class MultiHeaderColumnCollection
        Inherits CollectionBase

#Region "Members"
        Private m_MultiHeaderFormTable As MultiHeaderFormTable
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal ft As MultiHeaderFormTable)
            m_MultiHeaderFormTable = ft
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As MultiHeaderColumn
            Get
                Return CType(MyBase.List.Item(index), MultiHeaderColumn)
            End Get
            Set(ByVal value As MultiHeaderColumn)
                MyBase.List.Item(index) = value
            End Set
        End Property
        ReadOnly Property TotalColWidth() As Integer
            Get
                Dim total As Integer = 0
                For Each col As MultiHeaderColumn In Me
                    total += col.Width
                Next
                Return total
            End Get
        End Property
#End Region

#Region "Methods"
        Public Function Add(ByVal value As MultiHeaderColumn) As Integer
            value.FormFormatCode = m_MultiHeaderFormTable.FormFormatCode
            value.Table = m_MultiHeaderFormTable.TableName
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As MultiHeaderColumnCollection)
            For i As Integer = 0 To value.Count - 1
                value(i).FormFormatCode = m_MultiHeaderFormTable.FormFormatCode
                value(i).Table = m_MultiHeaderFormTable.TableName
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As MultiHeaderColumn())
            For i As Integer = 0 To value.Length - 1
                value(i).FormFormatCode = m_MultiHeaderFormTable.FormFormatCode
                value(i).Table = m_MultiHeaderFormTable.TableName
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As MultiHeaderColumn) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As MultiHeaderColumn(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ItemEnumerator
            Return New ItemEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As MultiHeaderColumn) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As MultiHeaderColumn)
            value.FormFormatCode = m_MultiHeaderFormTable.FormFormatCode
            value.Table = m_MultiHeaderFormTable.TableName
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As MultiHeaderColumn)
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
            Public Sub New(ByVal mappings As MultiHeaderColumnCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, MultiHeaderColumn)
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