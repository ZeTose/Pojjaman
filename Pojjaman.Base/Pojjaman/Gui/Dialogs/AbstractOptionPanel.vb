Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.AddIns.Codons
Namespace Longkong.Pojjaman.Gui.Dialogs
  Public Class AbstractOptionPanel
    Inherits BasePojjamanUserControl
    Implements IDialogPanel

#Region "Members"
    Private m_customizationObject As Object
    Private m_isFinished As Boolean
    Private m_wasActivated As Boolean
#End Region

#Region "Events"
    Public Event CustomizationObjectChanged As EventHandler
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New("")
      Me.m_wasActivated = False
      Me.m_isFinished = True
      Me.m_customizationObject = Nothing
    End Sub
    Public Sub New(ByVal fileName As String)
      MyBase.New(fileName)
      Me.m_wasActivated = False
      Me.m_isFinished = True
      Me.m_customizationObject = Nothing
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property WasActivated() As Boolean
      Get
        Return Me.m_wasActivated
      End Get
    End Property
#End Region

#Region "Methods"
    Public Overridable Sub LoadPanelContents()
    End Sub
    Protected Overridable Sub OnCustomizationObjectChanged()
      RaiseEvent CustomizationObjectChanged(Me, Nothing)
    End Sub
    Protected Overridable Sub OnEnableFinishChanged()
      RaiseEvent EnableFinishChanged(Me, Nothing)
    End Sub
    Public Overridable Function StorePanelContents() As Boolean
      Return True
    End Function
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
      MyBase.OnPaint(e)
      ControlPaint.DrawBorder3D(e.Graphics, e.ClipRectangle, Border3DStyle.Flat, Border3DSide.Bottom)
    End Sub
#End Region

#Region "IDialogPanel"
    Public Event EnableFinishChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements Core.AddIns.Codons.IDialogPanel.EnableFinishChanged

    Public ReadOnly Property Control() As System.Windows.Forms.Control Implements Core.AddIns.Codons.IDialogPanel.Control
      Get
        Return Me
      End Get
    End Property
    Public Property CustomizationObject() As Object Implements Core.AddIns.Codons.IDialogPanel.CustomizationObject
      Get
        Return Me.m_customizationObject
      End Get
      Set(ByVal value As Object)
        Me.m_customizationObject = value
        Me.OnCustomizationObjectChanged()
      End Set
    End Property

    Public Property EnableFinish() As Boolean Implements Core.AddIns.Codons.IDialogPanel.EnableFinish
      Get
        Return Me.m_isFinished
      End Get
      Set(ByVal value As Boolean)
        If (Me.m_isFinished <> value) Then
          Me.m_isFinished = value
          Me.OnEnableFinishChanged()
        End If
      End Set
    End Property
    Public Overridable Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean Implements Core.AddIns.Codons.IDialogPanel.ReceiveDialogMessage
      If (message <> DialogMessage.OK) Then
        If ((message = DialogMessage.Activated) AndAlso Not Me.m_wasActivated) Then
          Me.LoadPanelContents()
          Me.m_wasActivated = True
        End If
      Else
        If Me.m_wasActivated Then
          Return Me.StorePanelContents
        End If
      End If
      Return True
    End Function
#End Region

  End Class
End Namespace

