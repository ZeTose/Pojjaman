Imports Longkong.Core.Services
Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Gui.Pads
    Public Class ToolBox
        Inherits System.Windows.Forms.UserControl

#Region "Members"
        Private m_node As IAddInTreeNode
        Private m_toolBarPath As String
        Public m_commandBarManager As CommandBarManager
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            'This call is required by the Windows Form Designer.
            InitializeComponent()

            Me.m_toolBarPath = "/Pojjaman/Workbench/FormatToolBar"
            Try
                Me.m_node = AddInTreeSingleton.AddInTree.GetTreeNode(Me.m_toolBarPath)
            Catch ex As TreePathNotFoundException
                Me.m_node = Nothing
            End Try
            m_commandBarManager = New CommandBarManager
            For Each tb As CommandBar In Me.CreateToolbars()
                Me.m_commandBarManager.CommandBars.Add(tb)
            Next
            Me.Controls.Add(Me.m_commandBarManager)
            Me.ClientSize = Me.m_commandBarManager.Size
        End Sub
        Public Sub New(ByVal path As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            Me.m_toolBarPath = path
            Try
                Me.m_node = AddInTreeSingleton.AddInTree.GetTreeNode(Me.m_toolBarPath)
            Catch ex As TreePathNotFoundException
                Me.m_node = Nothing
            End Try
            m_commandBarManager = New CommandBarManager
            For Each tb As CommandBar In Me.CreateToolbars()
                Me.m_commandBarManager.CommandBars.Add(tb)
            Next
            Me.Controls.Add(Me.m_commandBarManager)
            Me.ClientSize = Me.m_commandBarManager.Size
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
            '
            'ToolBox
            '
            Me.Name = "ToolBox"
            Me.Size = New System.Drawing.Size(416, 40)

        End Sub

#End Region

#Region "Methods"
        Private Function CreateToolBarFromCodon(ByVal owner As Object, ByVal codon As ToolbarItemCodon) As CommandBar
            Dim tb As New CommandBar(Me.m_commandBarManager, CommandBarStyle.ToolBar)
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            If codon.SubItems.Count > 0 Then
                If CType(codon.SubItems(0), ToolbarItemCodon).Label <> "" Then
                    tb.Style = CommandBarStyle.TextToolBar
                End If
            End If
            For Each tbCodon As ToolbarItemCodon In codon.SubItems
                Dim text As String
                If tbCodon.Label <> "" Then
                    text = tbCodon.Label
                Else
                    text = tbCodon.ToolTip
                End If
                Dim item As CommandBarItem = Nothing
                Dim o As Object = Nothing
                If (Not tbCodon.Class Is Nothing) Then
                    o = tbCodon.AddIn.CreateObject(tbCodon.Class)
                    item = Nothing
                End If
                If ((Not o Is Nothing) AndAlso TypeOf o Is IComboBoxCommand) Then
                    item = New PJMMenuComboBox(tbCodon.ID, tbCodon.Conditions, owner, CType(o, ICommand))
                    CType(o, IComboBoxCommand).Owner = item
                ElseIf Not o Is Nothing AndAlso TypeOf o Is ICheckableMenuCommand Then
                    item = New PJMMenuCheckBox(tbCodon.Conditions, owner, text, CType(o, ICheckableMenuCommand))
                    item.Image = myResourceService.GetBitmap(tbCodon.Icon)
                    CType(o, ICheckableMenuCommand).Owner = item
                Else
                    If Not (tbCodon.ToolTip Is Nothing) Then
                        If (tbCodon.ToolTip = "-") Then
                            item = New CommandBarSeparator
                        Else
                            item = New PJMMenuCommand(tbCodon.Conditions, owner, text)
                            item.Image = myResourceService.GetBitmap(tbCodon.Icon)
                        End If
                        If (Not tbCodon.Class Is Nothing) Then
                            CType(item, PJMMenuCommand).Command = CType(tbCodon.AddIn.CreateObject(tbCodon.Class), ICommand)
                        End If
                    End If
                End If
                tb.Items.Add(item)
            Next
            Return tb
        End Function
        Private Function CreateToolbars() As CommandBar()
            If (Me.m_node Is Nothing) Then
                Return New CommandBar(0 - 1) {}
            End If
            Dim tbCodons As ToolbarItemCodon() = CType(Me.m_node.BuildChildItems(Me).ToArray(GetType(ToolbarItemCodon)), ToolbarItemCodon())
            Dim toolBars As CommandBar() = New CommandBar(tbCodons.Length - 1) {}
            For i As Integer = 0 To tbCodons.Length - 1
                toolBars(i) = Me.CreateToolBarFromCodon(Me, tbCodons(i))
            Next
            Return toolBars
        End Function
        Private Sub ToolBarButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            If TypeOf sender Is CommandBarItem Then
                CType(CType(sender, CommandBarItem).Tag, ICommand).Run()
            End If
        End Sub
#End Region

    End Class

End Namespace
