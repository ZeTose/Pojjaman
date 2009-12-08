Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.FormTable
    <Designer(GetType(FormTableDesigner))> _
    Public Class FormTable
        Inherits BasePropertyControl
        Implements IDrawable

#Region "Members"
        Private m_columns As ColumnCollection
        Private m_headerHeight As Integer
        Private m_headerFont As Font
        Private m_rowHeight As Integer
        Private m_rowsPerPage As Integer

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
            m_columns = New ColumnCollection(Me)
            m_rowsPerPage = 10
            m_rowHeight = 30
            SetHeight()

            m_borderColor = Color.Black
            m_headerBackColor = Me.BackColor
            m_headerForeColor = Me.ForeColor

        End Sub
#End Region

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

#Region "Properties"
        <ControlProperty("สีพื้นของหัวตาราง", Description:="สีพื้นของหัวตาราง", Category:="หัวตาราง")> _        Public Property HeaderBackColor() As Color            Get                Return m_headerBackColor            End Get            Set(ByVal Value As Color)                m_headerBackColor = Value                Me.Invalidate()            End Set        End Property        <ControlProperty("สีตัวหนังสือของหัวตาราง", Description:="สีตัวหนังสือของหัวตาราง", Category:="หัวตาราง")> _        Public Property HeaderForeColor() As Color            Get                Return m_headerForeColor            End Get            Set(ByVal Value As Color)                m_headerForeColor = Value                Me.Invalidate()            End Set        End Property
        <ControlProperty("ความสูงของหัวตาราง", Description:="ความสูงของหัวตาราง", Category:="หัวตาราง")> _        Public Property HeaderHeight() As Integer            Get                Return m_headerHeight            End Get            Set(ByVal Value As Integer)                m_headerHeight = Value                SetHeight()                'Me.Invalidate()            End Set        End Property
        <ControlProperty("Font หัวตาราง", Description:="Font หัวตาราง", Category:="หัวตาราง")> _
        Public Property HeaderFont() As Font            Get                Return m_headerFont            End Get            Set(ByVal Value As Font)                m_headerFont = Value                Me.Invalidate()            End Set        End Property

        <ControlProperty("สีของเส้นขอบ", Description:="สีของเส้นขอบ", Category:="ลักษณะ")> _
        Public Property BorderColor() As Color            Get                Return m_borderColor            End Get            Set(ByVal Value As Color)                m_borderColor = Value                Me.Invalidate()            End Set        End Property        <ControlProperty("คอลัมน์", Description:="คอลัมน์ต่างๆในตาราง", Category:="ข้อมูล")> _
        Public Property Columns() As ColumnCollection            Get                Return m_columns            End Get            Set(ByVal Value As ColumnCollection)                m_columns = Value                Me.Invalidate()            End Set        End Property        <ControlProperty("ความสูงของแถว", Description:="ความสูงของแถว", Category:="ข้อมูล")> _        Public Property RowHeight() As Integer            Get                Return m_rowHeight            End Get            Set(ByVal Value As Integer)                m_rowHeight = Value                SetHeight()            End Set        End Property        <ControlProperty("จำนวนแถวต่อหน้า", Description:="จำนวนแถวต่อหน้า", Category:="ข้อมูล")> _        Public Property RowsPerPage() As Integer            Get                Return m_rowsPerPage            End Get            Set(ByVal Value As Integer)                m_rowsPerPage = Value                SetHeight()            End Set        End Property
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
        Public Property FormFormatCode() As String            Get                Return m_formFormatCode            End Get            Set(ByVal Value As String)                m_formFormatCode = Value                For Each col As Column In Me.Columns
                    col.FormFormatCode = Value
                Next            End Set        End Property        <ControlProperty("ตารางในรูปแบบฟอร์ม", Description:="ตารางในรูปแบบฟอร์ม", Category:="ข้อมูล")> _        Public Property TableName() As String            Get                Return m_tableName            End Get            Set(ByVal Value As String)                m_tableName = Value                For Each col As Column In Me.Columns
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
            g.DrawPath(p, outline)

            'Draw the column header line
            g.DrawLine(p, loc.X, loc.Y + Me.m_headerHeight, loc.X + Me.Width - 1, loc.Y + Me.m_headerHeight)

            'Draw the columns
            Dim colOffset As Integer = 0
            Dim verticalInterval As Integer = 5
            Dim horizontalInterval As Integer = 5
            Dim i As Integer = 0
            For Each col As Column In Me.Columns
                colOffset = col.Width + colOffset

                Dim textSize As SizeF = g.MeasureString(col.Text, Me.m_headerFont)
                Dim aliasSize As SizeF = g.MeasureString(col.Alias, Me.m_headerFont)
                Dim startPoint As Integer
                Dim aliasStartPoint As Integer
                Select Case col.HeaderAlignment
                    Case HorizontalAlignment.Center
                        startPoint = CInt((col.Width / 2) - (textSize.Width / 2)) + colOffset - col.Width
                        aliasStartPoint = CInt((col.Width / 2) - (aliasSize.Width / 2)) + colOffset - col.Width
                    Case HorizontalAlignment.Left
                        startPoint = colOffset - col.Width + horizontalInterval
                        aliasStartPoint = colOffset - col.Width + horizontalInterval
                    Case HorizontalAlignment.Right
                        startPoint = CInt(colOffset - textSize.Width - horizontalInterval)
                        aliasStartPoint = CInt(colOffset - aliasSize.Width - horizontalInterval)
                End Select

                g.DrawString(col.Text, Me.m_headerFont, New SolidBrush(Me.m_headerForeColor), loc.X + startPoint, loc.Y + verticalInterval)
                g.DrawString(col.Alias, Me.m_headerFont, New SolidBrush(Me.m_headerForeColor), loc.X + aliasStartPoint, loc.Y + textSize.Height + (2 * verticalInterval))

                'ลากเส้นแนวตั้ง
                If i <> Me.Columns.Count - 1 Then
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
            If Me.Columns.Count > 0 Then
                Dim lastColWith As Integer = Me.Columns(Me.Columns.Count - 1).Width
                Dim totalWidth As Integer = Me.Columns.TotalColWidth
                Me.Columns(Me.Columns.Count - 1).Width = Me.Width - (totalWidth - lastColWith)
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
    Public Class FormTableDesigner
        Inherits ControlDesigner

        Sub New()
        End Sub

        Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
            Get
                Return SelectionRules.Moveable Or _
                SelectionRules.LeftSizeable Or _
                SelectionRules.RightSizeable Or _
                SelectionRules.Visible
            End Get
        End Property
    End Class
    Public MustInherit Class BasePropertyObject
        Inherits Object
        Implements ICustomTypeDescriptor

#Region "Members"
        Private parsedProps As PropertyDescriptorCollection
#End Region

#Region "Methods"
        Public Shared Function Parse(ByVal s As String) As String
            'Todo: implements
            Return s
        End Function
#End Region

#Region "ICustomTypeDescriptor"
        Public Function GetAttributes() As System.ComponentModel.AttributeCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetAttributes
            Return TypeDescriptor.GetAttributes(Me, True)
        End Function
        Public Function GetClassName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetClassName
            Return TypeDescriptor.GetClassName(Me, True)
        End Function
        Public Function GetComponentName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetComponentName
            Return TypeDescriptor.GetComponentName(Me, True)
        End Function
        Public Function GetConverter() As System.ComponentModel.TypeConverter Implements System.ComponentModel.ICustomTypeDescriptor.GetConverter
            Return TypeDescriptor.GetConverter(Me, True)
        End Function
        Public Function GetDefaultEvent() As System.ComponentModel.EventDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent
            Return TypeDescriptor.GetDefaultEvent(Me, True)
        End Function
        Public Function GetDefaultProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty
            Return TypeDescriptor.GetDefaultProperty(Me, True)
        End Function
        Public Function GetEditor(ByVal editorBaseType As System.Type) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetEditor
            Return TypeDescriptor.GetEditor(Me, editorBaseType, True)
        End Function
        Public Overloads Function GetEvents() As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
            Return TypeDescriptor.GetEvents(Me, True)
        End Function
        Public Overloads Function GetEvents(ByVal attributes() As System.Attribute) As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
            Return TypeDescriptor.GetEvents(Me, attributes, True)
        End Function
        Public Function GetPropertyOwner(ByVal pd As System.ComponentModel.PropertyDescriptor) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner
            Return Me
        End Function

        Public Overloads Function GetProperties() As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
            Return GetFilteredProperties(Nothing)
        End Function

        Public Overloads Function GetProperties(ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
            Return GetFilteredProperties(attributes)
        End Function
        Public Function GetFilteredProperties(ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
            If parsedProps Is Nothing Then
                Dim baseProps As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me, attributes, True)
                parsedProps = New PropertyDescriptorCollection(Nothing)
                For Each oProp As PropertyDescriptor In baseProps
                    Select Case oProp.Category
                        Case "Data", "Configurations", "Focus", "Design", "Behavior"
                        Case Else
                            parsedProps.Add(New ControlPropertyDescriptor(oProp))
                    End Select
                Next
            End If
            Return parsedProps
        End Function
#End Region

    End Class
    Public Class Column
        Inherits BasePropertyObject

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
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal text As String, ByVal [alias] As String, ByVal reportField As String, ByVal width As Integer, ByVal alignment As HorizontalAlignment)
            With Me
                .m_text = text
                .m_alias = [alias]
                .m_reportField = reportField
                .m_width = width
                .m_alignment = alignment
            End With
        End Sub
#End Region

#Region "Proprties"
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
        <ControlProperty("คำบรรยายเสริม", Description:="คำบรรยายเสริม", Category:="ข้อมูล")> _
        Public Property [Alias]() As String
            Get
                Return m_alias
            End Get
            Set(ByVal Value As String)
                m_alias = Value
            End Set
        End Property
        <ControlProperty("ตัวแปรที่ใช้", Description:="ตัวแปรที่ใช้เป็นข้อมูล", Category:="ข้อมูล"), Editor(GetType(DataFieldTypeEditor), GetType(UITypeEditor))> _
        Public Property ReportField() As String            Get                Return m_reportField            End Get            Set(ByVal Value As String)                m_reportField = Value            End Set        End Property
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
    Public Class ColumnCollection
        Inherits CollectionBase

#Region "Members"
        Private m_formTable As FormTable
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal ft As FormTable)
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
    Public Class ReportField

#Region "Members"
        Private m_name As String
        Private m_format As String
        Private m_datatype As Type
#End Region

    End Class

End Namespace