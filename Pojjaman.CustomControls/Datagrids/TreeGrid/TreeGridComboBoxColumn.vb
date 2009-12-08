Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class TreeGridComboBoxColumn
        Inherits DataGridTextBoxColumn

#Region "Members"
        Private m_comboBox As ComboBox
        Private cm As CurrencyManager
        Private m_currentRow As Integer
#End Region

#Region "Constructors"
        Public Sub New()
            Me.cm = Nothing
            Me.m_comboBox = New ComboBox
            Me.m_comboBox.DropDownStyle = ComboBoxStyle.DropDownList
            AddHandler Me.m_comboBox.Leave, New EventHandler(AddressOf Me.m_comboBox_Leave)
        End Sub
#End Region

#Region "Methods"
        Protected Overloads Overrides Sub Edit(ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal bounds As Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
            Debug.WriteLine(String.Format("Edit {0}", rowNum))
            MyBase.Edit(source, rowNum, bounds, [readOnly], instantText, cellIsVisible)
            If (Not [readOnly] AndAlso cellIsVisible) Then
                Me.m_currentRow = rowNum
                Me.cm = source
                AddHandler Me.DataGridTableStyle.DataGrid.Scroll, New EventHandler(AddressOf Me.DataGrid_Scroll)
                Me.m_comboBox.Parent = Me.TextBox.Parent
                Dim rectangle1 As Rectangle = Me.DataGridTableStyle.DataGrid.GetCurrentCellBounds
                Me.m_comboBox.Location = rectangle1.Location
                Me.m_comboBox.Size = New Size(Me.TextBox.Size.Width, Me.m_comboBox.Size.Height)
                Me.m_comboBox.SelectedIndex = Me.m_comboBox.FindStringExact(Me.TextBox.Text)
                Me.m_comboBox.Show()
                Me.m_comboBox.BringToFront()
                Me.m_comboBox.Focus()
            End If
        End Sub
        Protected Overrides Function GetColumnValueAtRow(ByVal source As CurrencyManager, ByVal rowNum As Integer) As Object
            Debug.WriteLine(String.Format("GetColumnValueAtRow {0}", rowNum))
            Dim o As Object = MyBase.GetColumnValueAtRow(source, rowNum)
            Dim manager1 As CurrencyManager = CType(Me.DataGridTableStyle.DataGrid.BindingContext.Item(Me.m_comboBox.DataSource), CurrencyManager)
            Dim view1 As DataView = CType(manager1.List, DataView)
            Dim i As Integer = 0
            Do While (i < view1.Count)
                If o.Equals(view1.Item(i).Item(Me.m_comboBox.ValueMember)) Then
                    Exit Do
                End If
                i += 1
            Loop
            If (i < view1.Count) Then
                Return view1.Item(i).Item(Me.m_comboBox.DisplayMember)
            End If
            Return DBNull.Value
        End Function
        Protected Overrides Sub SetColumnValueAtRow(ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal value As Object)
            Debug.WriteLine(String.Format("SetColumnValueAtRow {0} {1}", rowNum, value))
            Dim o As Object = value
            Dim manager1 As CurrencyManager = CType(Me.DataGridTableStyle.DataGrid.BindingContext.Item(Me.m_comboBox.DataSource), CurrencyManager)
            Dim view1 As DataView = CType(manager1.List, DataView)
            Dim i As Integer = 0
            Do While (i < view1.Count)
                If o.Equals(view1.Item(i).Item(Me.m_comboBox.DisplayMember)) Then
                    Exit Do
                End If
                i += 1
            Loop
            If (i < view1.Count) Then
                o = view1.Item(i).Item(Me.m_comboBox.ValueMember)
            Else
                o = DBNull.Value
            End If
            MyBase.SetColumnValueAtRow(source, rowNum, o)
        End Sub
        Private Sub DataGrid_Scroll(ByVal sender As Object, ByVal e As EventArgs)
            Debug.WriteLine("Scroll")
            Me.m_comboBox.Hide()
        End Sub
        Private Sub m_comboBox_Leave(ByVal sender As Object, ByVal e As EventArgs)
            Dim view1 As DataRowView = CType(Me.m_comboBox.SelectedItem, DataRowView)
            Dim text1 As String = CType(view1.Row.Item(Me.m_comboBox.DisplayMember), String)
            Debug.WriteLine(String.Format("Leave: {0} {1}", Me.m_comboBox.Text, text1))
            Me.SetColumnValueAtRow(Me.cm, Me.m_currentRow, text1)
            Me.Invalidate()
            Me.m_comboBox.Hide()
            RemoveHandler Me.DataGridTableStyle.DataGrid.Scroll, New EventHandler(AddressOf Me.DataGrid_Scroll)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property ComboBox() As ComboBox
            Get
                Return Me.m_comboBox
            End Get
        End Property
#End Region

    End Class
End Namespace

