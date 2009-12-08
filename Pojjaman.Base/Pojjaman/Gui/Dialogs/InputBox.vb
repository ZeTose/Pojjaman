Imports Longkong.Pojjaman.Gui.XmlForms
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class InputBox
        Inherits BasePojjamanForm

#Region "Members"
        Private m_label As label
        Private m_textBox As textBox
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New(Path.Combine(BasePojjamanForm.PropertyService.DataDirectory, "resources\dialogs\InputBox.xfrm"))
            Me.m_label = CType(MyBase.ControlDictionary.Item("label"), Label)
            Me.m_textBox = CType(MyBase.ControlDictionary.Item("textBox"), TextBox)
        End Sub
#End Region

#Region "Propeties"
        Public ReadOnly Property Label() As Label
            Get
                Return Me.m_label
            End Get
        End Property
        Public ReadOnly Property TextBox() As TextBox
            Get
                Return Me.m_textBox
            End Get
        End Property
#End Region

    End Class
End Namespace

