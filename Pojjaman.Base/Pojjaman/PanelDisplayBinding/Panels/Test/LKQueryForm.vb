Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
'Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Core.Properties
Imports System.Data.SqlClient

Public Class LKQueryForm
  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

    StratUp(True)
  End Sub

  Private Sub StratUp(collap As Boolean)
    Me.SplitContainer1.Panel2Collapsed = collap
  End Sub


  Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click
    'Me.TabPage1 = New System.Windows.Forms.TabPage
    Me.TabPage1.Controls.Clear()
    Me.txtMessage.Text = ""

    Me.StratUp(False)

    Dim cmd As String = Trim(Me.txtCommand.SelectedText)
    If cmd.Trim.Length = 0 Then
      cmd = Trim(Me.txtCommand.Text)
    End If
    cmd &= ";select @@rowcount rc;"

    Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
    conn.Open()
    Dim trans As SqlTransaction = conn.BeginTransaction
    Try
      Dim ds As DataSet = SqlHelper.ExecuteDataset(conn, trans, CommandType.Text, cmd)

      If ds.Tables.Count = 1 Then
        Me.txtMessage.Text = String.Format("({0} row(s) affected)", ds.Tables(0).Rows(0)(0))
        Me.TabControl1.SelectedIndex = 0
        Return
      End If

      For Each dt As DataTable In ds.Tables
        If dt.Columns.Contains("rc") Then

        Else
          If Me.txtMessage.TextLength > 0 Then
            Me.txtMessage.Text &= vbCrLf
            Me.txtMessage.Text &= vbCrLf
          End If
          Me.txtMessage.Text &= String.Format("({0} row(s) affected)", dt.Rows.Count)
        End If
      Next

      'GridControl1.DataSource = ds.Tables(0)
      'GridControl2.DataSource = ds.Tables(1)

      If ds.Tables.Count = 2 Then
        Dim gr As New DevExpress.XtraGrid.GridControl
        Dim gv As New DevExpress.XtraGrid.Views.Grid.GridView
        AddHandler gv.RowCellStyle, AddressOf GridView1_RowCellStyle
        gv.OptionsView.ShowGroupPanel = False
        gv.OptionsCustomization.AllowColumnMoving = False
        gv.OptionsCustomization.AllowFilter = False
        gv.OptionsCustomization.AllowGroup = False
        gv.OptionsCustomization.AllowSort = False
        'gv.OptionsView.ShowColumnHeaders = False

        gr.Dock = System.Windows.Forms.DockStyle.Top
        gr.MainView = gv
        gr.Name = String.Format("{0}_{1}", "GridControl", ds.Tables(0).TableName)

        gr.Location = New System.Drawing.Point(0, 0)
        gr.Size = New System.Drawing.Size(TabControl1.Width, TabControl1.Height)

        gr.TabIndex = 0
        gr.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {gv})

        gv.GridControl = gr
        gv.Name = String.Format("{0}_{1}", "GridView", ds.Tables(0).TableName)

        gr.DataSource = ds.Tables(0)
        TabPage1.Controls.Add(gr)

        Me.TabControl1.SelectedIndex = 0
        Return
      End If

      Dim index As Integer = 0
      Dim hashGrid As New Hashtable

      For Each dt As DataTable In ds.Tables
        If dt.Columns.Contains("rc") Then

        Else
          Dim gr As New DevExpress.XtraGrid.GridControl
          Dim gv As New DevExpress.XtraGrid.Views.Grid.GridView
          AddHandler gv.RowCellStyle, AddressOf GridView1_RowCellStyle
          gv.OptionsView.ShowGroupPanel = False
          gv.OptionsCustomization.AllowColumnMoving = False
          gv.OptionsCustomization.AllowFilter = False
          gv.OptionsCustomization.AllowGroup = False
          gv.OptionsCustomization.AllowSort = False

          gr.Dock = System.Windows.Forms.DockStyle.Top
          gr.MainView = gv
          gr.Name = String.Format("{0}_{1}", "GridControl", dt.TableName)

          'gr.Location = New System.Drawing.Point(0, 0)
          gr.Size = New System.Drawing.Size(TabControl1.Width, 200)

          gr.TabIndex = index
          gr.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {gv})

          gv.GridControl = gr
          gv.Name = String.Format("{0}_{1}", "GridView", dt.TableName)

          gr.DataSource = dt

          hashGrid.Add(index, gr)

          index += 1
        End If

      Next

      index = 0
      For gindex As Integer = hashGrid.Count - 1 To 0 Step -1
        If index > 0 Then
          Dim sp As New DevExpress.XtraEditors.SplitterControl
          sp.Dock = System.Windows.Forms.DockStyle.Top
          TabPage1.Controls.Add(sp)
        End If
        Dim gr As DevExpress.XtraGrid.GridControl = CType(hashGrid(gindex), DevExpress.XtraGrid.GridControl)
        TabPage1.Controls.Add(gr)

        index += 1
      Next

      trans.Commit()

      If Me.txtMessage.TextLength = 0 Then
        Me.txtMessage.Text = "Command(s) completed successfully."
      End If

      Me.TabControl1.SelectedIndex = 0
    Catch ex As Exception
      trans.Rollback()

      Me.TabControl1.SelectedIndex = 1

      If Me.txtMessage.TextLength > 0 Then
        Me.txtMessage.Text &= vbCrLf
        Me.txtMessage.Text &= vbCrLf
      End If

      Me.txtMessage.Text &= ex.Message
    Finally
      conn.Close()
    End Try

  End Sub

  Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) 'Handles GridView1.RowCellStyle
    e.Column.OptionsColumn.AllowEdit = False
    'e.Column.Width = 25
  End Sub

End Class