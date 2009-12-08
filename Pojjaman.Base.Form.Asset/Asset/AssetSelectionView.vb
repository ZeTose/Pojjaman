Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AssetSelectionView
        Inherits System.Windows.Forms.UserControl
        Implements IPreAddView

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
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents tvItems As System.Windows.Forms.TreeView
        Friend WithEvents btnOPB As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.tvItems = New System.Windows.Forms.TreeView
            Me.btnOPB = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'tvItems
            '
            Me.tvItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tvItems.FullRowSelect = True
            Me.tvItems.HideSelection = False
            Me.tvItems.ImageIndex = -1
            Me.tvItems.Location = New System.Drawing.Point(8, 8)
            Me.tvItems.Name = "tvItems"
            Me.tvItems.SelectedImageIndex = -1
            Me.tvItems.Size = New System.Drawing.Size(576, 360)
            Me.tvItems.TabIndex = 5
            '
            'btnOPB
            '
            Me.btnOPB.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOPB.Location = New System.Drawing.Point(488, 376)
            Me.btnOPB.Name = "btnOPB"
            Me.btnOPB.Size = New System.Drawing.Size(80, 23)
            Me.btnOPB.TabIndex = 6
            Me.btnOPB.Text = "สินทรัพย์ยกมา"
            '
            'AssetSelectionView
            '
            Me.Controls.Add(Me.btnOPB)
            Me.Controls.Add(Me.tvItems)
            Me.Name = "AssetSelectionView"
            Me.Size = New System.Drawing.Size(592, 408)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_selectedRow As DataRow
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Asset.PopulateUnregisteredTree(Me.tvItems)

        End Sub
#End Region

#Region "Properties"
        Public Property SelectedRow() As DataRow Implements IPreAddView.SelectedRow            Get                Return m_selectedRow            End Get            Set(ByVal Value As DataRow)                m_selectedRow = Value            End Set        End Property
#End Region

#Region "Methods"
        Private Sub tvItems_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvItems.AfterSelect
            If Not e.Node Is Nothing Then
                If TypeOf e.Node.Tag Is DataRow Then
                    m_selectedRow = CType(e.Node.Tag, DataRow)
                End If
            End If
        End Sub
        Private Sub tvItems_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvItems.DoubleClick
            Me.FindForm.DialogResult = DialogResult.OK
            Me.FindForm.Close()
        End Sub
        Private Sub btnOPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOPB.Click
            Dim dt As New DataTable("Asset")
            dt.Columns.Add(New DataColumn("stocki_itemname", GetType(String)))
            dt.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
            dt.Columns.Add(New DataColumn("stocki_acct", GetType(Integer)))
            dt.Columns.Add(New DataColumn("stocki_sequence", GetType(Integer)))
            dt.Columns.Add(New DataColumn("stock_docDate", GetType(Date)))
            dt.Columns.Add(New DataColumn("stocki_unitPrice", GetType(Decimal)))
            dt.Columns.Add(New DataColumn("stock_Code", GetType(String)))
            dt.Columns.Add(New DataColumn("stock_entity", GetType(Integer)))            dt.Columns.Add(New DataColumn("stocki_tocc", GetType(Integer)))
            Dim dr As DataRow = dt.NewRow

            dr("stocki_itemname") = "<NAME>"
            dr("stocki_unit") = DBNull.Value
            dr("stocki_acct") = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.GeneralAsset).Id
            dr("stocki_sequence") = 0
            dr("stock_docDate") = Now.Date
            dr("stocki_unitPrice") = 0
            dr("stock_Code") = DBNull.Value
            dr("stock_entity") = DBNull.Value
            dr("stocki_tocc") = DBNull.Value
            dt.Rows.Add(dr)

            Me.SelectedRow = dr

            Me.FindForm.DialogResult = DialogResult.OK
            Me.FindForm.Close()
        End Sub
#End Region

    End Class
End Namespace