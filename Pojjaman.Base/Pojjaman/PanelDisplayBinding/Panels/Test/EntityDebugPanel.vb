Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class EntityDebugPanel
    'Inherits AbstractEntityDetailPanelView
    Inherits UserControl

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
    Friend WithEvents txtPropertyName As System.Windows.Forms.TextBox
    Friend WithEvents btnShowProperty As System.Windows.Forms.Button
    Friend WithEvents txtPropertyValue As System.Windows.Forms.TextBox
    Friend WithEvents lstItems As System.Windows.Forms.ListBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdProperties As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Dim GridBaseStyle1 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle2 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle3 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Dim GridBaseStyle4 As Syncfusion.Windows.Forms.Grid.GridBaseStyle = New Syncfusion.Windows.Forms.Grid.GridBaseStyle()
      Me.txtPropertyName = New System.Windows.Forms.TextBox()
      Me.btnShowProperty = New System.Windows.Forms.Button()
      Me.txtPropertyValue = New System.Windows.Forms.TextBox()
      Me.lstItems = New System.Windows.Forms.ListBox()
      Me.btnRefresh = New System.Windows.Forms.Button()
      Me.txtTableName = New System.Windows.Forms.TextBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.grdProperties = New Syncfusion.Windows.Forms.Grid.GridControl()
      Me.GroupBox1.SuspendLayout()
      CType(Me.grdProperties, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtPropertyName
      '
      Me.txtPropertyName.Location = New System.Drawing.Point(16, 452)
      Me.txtPropertyName.Name = "txtPropertyName"
      Me.txtPropertyName.Size = New System.Drawing.Size(192, 20)
      Me.txtPropertyName.TabIndex = 0
      '
      'btnShowProperty
      '
      Me.btnShowProperty.Location = New System.Drawing.Point(216, 452)
      Me.btnShowProperty.Name = "btnShowProperty"
      Me.btnShowProperty.Size = New System.Drawing.Size(75, 23)
      Me.btnShowProperty.TabIndex = 1
      Me.btnShowProperty.Text = ">>"
      '
      'txtPropertyValue
      '
      Me.txtPropertyValue.Location = New System.Drawing.Point(304, 452)
      Me.txtPropertyValue.Name = "txtPropertyValue"
      Me.txtPropertyValue.Size = New System.Drawing.Size(240, 20)
      Me.txtPropertyValue.TabIndex = 2
      '
      'lstItems
      '
      Me.lstItems.Location = New System.Drawing.Point(16, 513)
      Me.lstItems.Name = "lstItems"
      Me.lstItems.Size = New System.Drawing.Size(625, 199)
      Me.lstItems.TabIndex = 3
      '
      'btnRefresh
      '
      Me.btnRefresh.Location = New System.Drawing.Point(16, 481)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
      Me.btnRefresh.TabIndex = 1
      Me.btnRefresh.Text = "Refresh"
      '
      'txtTableName
      '
      Me.txtTableName.Location = New System.Drawing.Point(104, 481)
      Me.txtTableName.Name = "txtTableName"
      Me.txtTableName.Size = New System.Drawing.Size(192, 20)
      Me.txtTableName.TabIndex = 0
      Me.txtTableName.Text = "ItemTable"
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.grdProperties)
      Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(625, 698)
      Me.GroupBox1.TabIndex = 4
      Me.GroupBox1.TabStop = False
      '
      'grdProperties
      '
      GridBaseStyle1.Name = "Header"
      GridBaseStyle1.StyleInfo.CellType = "Header"
      GridBaseStyle1.StyleInfo.Font.Bold = True
      GridBaseStyle1.StyleInfo.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
      GridBaseStyle2.Name = "Standard"
      GridBaseStyle2.StyleInfo.Font.Facename = "Tahoma"
      GridBaseStyle3.Name = "Row Header"
      GridBaseStyle3.StyleInfo.BaseStyle = "Header"
      GridBaseStyle3.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      GridBaseStyle4.Name = "Column Header"
      GridBaseStyle4.StyleInfo.BaseStyle = "Header"
      GridBaseStyle4.StyleInfo.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      Me.grdProperties.BaseStylesMap.AddRange(New Syncfusion.Windows.Forms.Grid.GridBaseStyle() {GridBaseStyle1, GridBaseStyle2, GridBaseStyle3, GridBaseStyle4})
      Me.grdProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.grdProperties.ColCount = 3
      Me.grdProperties.DefaultColWidth = 100
      Me.grdProperties.Dock = System.Windows.Forms.DockStyle.Fill
      Me.grdProperties.ForeColor = System.Drawing.SystemColors.ControlText
      Me.grdProperties.HorizontalThumbTrack = True
      Me.grdProperties.Location = New System.Drawing.Point(3, 16)
      Me.grdProperties.Name = "grdProperties"
      Me.grdProperties.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.grdProperties.RowCount = 0
      Me.grdProperties.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeAsRangeStylesIntoCode
      Me.grdProperties.Size = New System.Drawing.Size(619, 679)
      Me.grdProperties.SmartSizeBox = False
      Me.grdProperties.TabIndex = 3
      Me.grdProperties.UseRightToLeftCompatibleTextBox = True
      Me.grdProperties.VerticalThumbTrack = True
      '
      'EntityDebugPanel
      '
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.lstItems)
      Me.Controls.Add(Me.txtPropertyValue)
      Me.Controls.Add(Me.btnShowProperty)
      Me.Controls.Add(Me.txtPropertyName)
      Me.Controls.Add(Me.btnRefresh)
      Me.Controls.Add(Me.txtTableName)
      Me.Name = "EntityDebugPanel"
      Me.Size = New System.Drawing.Size(656, 725)
      Me.GroupBox1.ResumeLayout(False)
      CType(Me.grdProperties, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As Object
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As Object)
      MyBase.New()
      Me.InitializeComponent()
      Me.m_entity = entity

      Me.Populate()
    End Sub
#End Region

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
      Try
        Me.lstItems.Items.Clear()
        Dim ttb As TreeTable
        Dim ty As Type = Me.m_entity.GetType
        Dim pi As PropertyInfo = ty.GetProperty(Me.txtTableName.Text)
        ttb = CType(pi.GetValue(Me.m_entity, Nothing), TreeTable)
        For Each row As TreeRow In ttb.Rows
          Dim rowString As String = ""
          For Each col As DataColumn In row.Table.Columns
            rowString &= row(col).ToString & ":"
          Next
          Me.lstItems.Items.Add(rowString & row.State.ToString)
        Next
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub

    Private Sub btnShowProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowProperty.Click
      Try
        Dim ty As Type = Me.m_entity.GetType
        Dim pi As PropertyInfo = ty.GetProperty(Me.txtPropertyName.Text, BindingFlags.FlattenHierarchy Or BindingFlags.IgnoreCase Or BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Static)
        If Not pi Is Nothing Then
          Me.txtPropertyValue.Text = pi.GetValue(Me.m_entity, Nothing).ToString
          Return
        End If
        Dim mi As MethodInfo = ty.GetMethod(Me.txtPropertyName.Text)
        If Not mi Is Nothing Then
          Me.txtPropertyValue.Text = mi.Invoke(Me.m_entity, Nothing).ToString
          Return
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub

    Private Sub Populate()

      Me.grdProperties.Clear(True)

      'Me.grdProperties.RowCount = dpiColl.Count
      Me.grdProperties.TableStyle.ReadOnly = True

      Me.grdProperties.ColWidths.SetSize(1, 5)
      Me.grdProperties.ColWidths.SetSize(2, 250)
      Me.grdProperties.ColWidths.SetSize(3, 300)
      'Me.grdProperties.ColWidths.SetSize(4, 220)

      Me.grdProperties(0, 1).Text = " "
      Me.grdProperties(0, 2).Text = "Property"
      Me.grdProperties(0, 3).Text = "Value"

      Dim propertyList As New ArrayList
      Dim propertyHash As New Hashtable

      Dim i As Integer = 0
      Dim ty As Type = Me.m_entity.GetType
      For Each pi As PropertyInfo In ty.GetProperties(BindingFlags.FlattenHierarchy Or BindingFlags.IgnoreCase Or BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Static)
        Try

          If Not pi Is Nothing AndAlso Not pi.GetValue(Me.m_entity, Nothing) Is Nothing Then
            'Dim pi2 As PropertyInfo = ty.GetProperty(pi.Name, BindingFlags.FlattenHierarchy Or BindingFlags.IgnoreCase Or BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Static)

            'Dim prop As New KeyValuePair(pi.Name, pi.GetValue(Me.m_entity, Nothing).ToString)
            propertyList.Add(pi.Name.Trim)
            propertyHash.Add(pi.Name.Trim, pi.GetValue(Me.m_entity, Nothing).ToString)

            'i += 1
            'Me.grdProperties.RowCount = i + 1
            'Me.grdProperties(i, 1).Text = "" 'i.ToString
            'Me.grdProperties(i, 2).Text = pi.Name
            'Me.grdProperties(i, 3).Text = pi.GetValue(Me.m_entity, Nothing).ToString

          End If
        Catch ex As Exception

        End Try
      Next

      propertyList.Sort()

      For Each prop As String In propertyList
        i += 1
        Me.grdProperties.RowCount = i + 1
        Me.grdProperties(i, 1).Text = "" 'i.ToString
        Me.grdProperties(i, 2).Text = prop
        Me.grdProperties(i, 3).Text = CType(propertyHash(prop), String)
      Next


    End Sub


  End Class
End Namespace