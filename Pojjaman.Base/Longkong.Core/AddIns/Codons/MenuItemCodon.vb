Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Commands
Namespace Longkong.Core.AddIns.Codons
    <CodonName("MenuItem")> _
    Public Class MenuItemCodon
        Inherits AbstractCodon

#Region "Members"
        <XmlMemberAttributeAttribute("description")> _
        Private m_description As String
        <XmlMemberAttributeAttribute("icon")> _
        Private m_icon As String
        <XmlMemberAttributeAttribute("label", IsRequired:=True)> _
        Private m_label As String
        <XmlMemberAttributeAttribute("link")> _
        Private m_link As String
        'TODO Separator
        <XmlMemberArray("shortcut", Separator:="|"c)> _
        Private m_shortcut As String()
        <XmlMemberAttributeAttribute("entity")> _
        Private m_entity As String
    <XmlMemberAttributeAttribute("panel")> _
    Private m_panel As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_label = Nothing
            Me.m_description = Nothing
            Me.m_shortcut = Nothing
            Me.m_icon = Nothing
            Me.m_link = Nothing
        End Sub
#End Region

#Region "Properties"
    Public Property Panel As String
      Get
        Return m_panel
      End Get
      Set(ByVal value As String)
        m_panel = value
      End Set
    End Property
        Public Property Description() As String
            Get
                Return Me.m_description
            End Get
            Set(ByVal value As String)
                Me.m_description = value
            End Set
        End Property
        Public Overrides ReadOnly Property HandleConditions() As Boolean
            Get
                Return True
            End Get
        End Property
        Public Property Icon() As String
            Get
                Return Me.m_icon
            End Get
            Set(ByVal value As String)
                Me.m_icon = value
            End Set
        End Property
        Public Property Label() As String
            Get
                Return Me.m_label
            End Get
            Set(ByVal value As String)
                Me.m_label = value
            End Set
        End Property
        Public Property Link() As String
            Get
                Return Me.m_link
            End Get
            Set(ByVal value As String)
                Me.m_link = value
            End Set
        End Property
        Public Property Entity() As String
            Get
                Return Me.m_entity
            End Get
            Set(ByVal value As String)
                Me.m_entity = value
            End Set
        End Property
        Public Property Shortcut() As String()
            Get
                Return Me.m_shortcut
            End Get
            Set(ByVal value As String())
                Me.m_shortcut = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function BuildItem(ByVal owner As Object, ByVal subItems As System.Collections.ArrayList, ByVal conditions As Conditions.ConditionCollection) As Object
      Dim newItem As ToolStripItem = Nothing
            If (Me.Label = "-") Then
        newItem = New PJMToolStripSeparator(conditions, owner)
            Else
                If (Not Me.Link Is Nothing) Then
          newItem = New Pojjaman.Gui.Components.PJMToolStripMenuItem(conditions, Nothing, Me.Label, CType(IIf(Me.Link.StartsWith("http"), New GotoWebSite(Me.Link), New GotoLink(Me.Link)), ICommand))
                Else
                    Dim o As Object = Nothing
                    If (Not MyBase.Class Is Nothing) Then
                        o = MyBase.AddIn.CreateObject(MyBase.Class)
                    End If
                    If (Not o Is Nothing) Then
                        If TypeOf o Is IEntityMenuCommand Then
                            Dim command1 As IEntityMenuCommand = CType(o, IEntityMenuCommand)
                            command1.Owner = owner
                            command1.Entity = Me.Entity
              newItem = New Pojjaman.Gui.Components.PJMToolStripMenuItem(conditions, owner, Me.Label, command1)
              If TypeOf command1 Is OpenPanel Then
                CType(command1, OpenPanel).Panel = Me.Panel
                CType(command1, OpenPanel).AddIn = Me.AddIn
              End If
                        ElseIf TypeOf o Is IMenuCommand Then
                            Dim command1 As IMenuCommand = CType(o, IMenuCommand)
                            command1.Owner = owner
                            If TypeOf o Is ICheckableMenuCommand Then
                'newItem = New PJMMenuCheckBox(conditions, owner, Me.Label, CType(command1, ICheckableMenuCommand))
                            Else
                newItem = New Pojjaman.Gui.Components.PJMToolStripMenuItem(conditions, owner, Me.Label, command1)
                            End If
                        Else
                            If TypeOf o Is ISubmenuBuilder Then
                                Return o
                            End If
                        End If
                    End If
                End If
            End If
            If (newItem Is Nothing) Then
        Dim newMenu As New PJMToolStripMenuItem(conditions, owner, Me.Label)
                If ((Not subItems Is Nothing) AndAlso (subItems.Count > 0)) Then
                    For Each item As Object In subItems
            If TypeOf item Is ToolStripItem Then
              newMenu.DropDownItems.Add(CType(item, ToolStripItem))
            Else
              Dim a As Object = item
                        End If
                    Next
                End If
                newItem = newMenu
            End If
            If (Not Me.Icon Is Nothing) Then
                Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
                newItem.Image = myResourceService.GetBitmap(Me.Icon)
            End If
      If TypeOf newItem Is Pojjaman.Gui.Components.PJMToolStripMenuItem Then
        CType(newItem, Pojjaman.Gui.Components.PJMToolStripMenuItem).Description = Me.m_description
            End If
      If ((Not Me.Shortcut Is Nothing) AndAlso TypeOf newItem Is Pojjaman.Gui.Components.PJMToolStripMenuItem) Then
                Try
                    Dim textArray1 As String() = Me.m_shortcut
                    For Each key As String In Me.m_shortcut
            Dim myCommand As Pojjaman.Gui.Components.PJMToolStripMenuItem = CType(newItem, Pojjaman.Gui.Components.PJMToolStripMenuItem)
            myCommand.ShortcutKeys = (myCommand.ShortcutKeys Or CType([Enum].Parse(GetType(Keys), key), Keys))
                    Next
                Catch ex As Exception
          CType(newItem, Pojjaman.Gui.Components.PJMToolStripMenuItem).ShortcutKeys = Keys.None
                End Try
            End If
      newItem.Enabled = True
            Return newItem
        End Function
#End Region

    End Class
End Namespace
