Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Commands
    Public MustInherit Class AbstractModeCommand
        Inherits AbstractCheckableMenuCommand

#Region "Members"
        Private m_ischecked As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_ischecked = (WorkbenchSingleton.Workbench.ApplicationMode And Mode) > Core.AddIns.ApplicationMode.None
        End Sub
#End Region

        Public MustOverride ReadOnly Property Mode() As Core.AddIns.ApplicationMode

        Public Overrides Property IsChecked() As Boolean 'Todo:
            Get
                Return m_ischecked
            End Get
            Set(ByVal Value As Boolean)
                If m_ischecked <> Value Then
                    If WorkbenchSingleton.Workbench.MultiMode Then
                        If Value Then
                            WorkbenchSingleton.Workbench.ApplicationMode = WorkbenchSingleton.Workbench.ApplicationMode Or Mode
                        Else
                            WorkbenchSingleton.Workbench.ApplicationMode = WorkbenchSingleton.Workbench.ApplicationMode And Not Mode
                        End If
                        m_ischecked = Value
                    ElseIf Value Then
                        WorkbenchSingleton.Workbench.ApplicationMode = Mode
                        m_ischecked = Value Or (WorkbenchSingleton.Workbench.ApplicationMode = Mode)
                    Else
                        m_ischecked = Value Or (WorkbenchSingleton.Workbench.ApplicationMode = Mode)
                        WorkbenchSingleton.Workbench.ApplicationMode = WorkbenchSingleton.Workbench.ApplicationMode
                    End If
                End If
            End Set
        End Property

    End Class
End Namespace
