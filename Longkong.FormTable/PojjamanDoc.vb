Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.FormTable
    Public MustInherit Class BasePropertyForm
        Inherits System.Windows.Forms.Form
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
    Public Class PojjamanDoc
        Inherits BasePropertyForm

#Region "Members"
        Private m_formFormatCode As String
#End Region

#Region "Properties"
        <ControlProperty("รูปแบบฟอร์มที่ใช้", Description:="รูปแบบฟอร์มที่ใช้", Category:="ข้อมูล")> _
        Public Property FormFormatCode() As String            Get                Return m_formFormatCode            End Get            Set(ByVal Value As String)                m_formFormatCode = Value            End Set        End Property
#End Region

    End Class
End Namespace