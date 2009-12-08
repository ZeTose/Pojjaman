Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Namespace Longkong.FormTable
    Public Class ImageBox
        Inherits PictureBox
        Implements ICustomTypeDescriptor

#Region "Members"
        Private parsedProps As PropertyDescriptorCollection

        Private m_site As ISite
#End Region

#Region "Override Proerties"
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
        <ControlProperty("เส้นขอบ", Description:="ลักษณะเส้นขอบ", Category:="ลักษณะ")> _
        Public Shadows Property BorderStyle() As BorderStyle
            Get
                Return MyBase.BorderStyle
            End Get
            Set(ByVal Value As BorderStyle)
                MyBase.BorderStyle = Value
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
                MyBase.Size = Value
            End Set
        End Property
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
End Namespace