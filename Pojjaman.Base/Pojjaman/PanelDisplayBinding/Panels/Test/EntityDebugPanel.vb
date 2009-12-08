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
        Inherits AbstractEntityDetailPanelView

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
        Friend WithEvents txtTableName As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.txtPropertyName = New System.Windows.Forms.TextBox
            Me.btnShowProperty = New System.Windows.Forms.Button
            Me.txtPropertyValue = New System.Windows.Forms.TextBox
            Me.lstItems = New System.Windows.Forms.ListBox
            Me.btnRefresh = New System.Windows.Forms.Button
            Me.txtTableName = New System.Windows.Forms.TextBox
            Me.SuspendLayout()
            '
            'txtPropertyName
            '
            Me.txtPropertyName.Location = New System.Drawing.Point(48, 32)
            Me.txtPropertyName.Name = "txtPropertyName"
            Me.txtPropertyName.Size = New System.Drawing.Size(192, 20)
            Me.txtPropertyName.TabIndex = 0
            Me.txtPropertyName.Text = ""
            '
            'btnShowProperty
            '
            Me.btnShowProperty.Location = New System.Drawing.Point(248, 32)
            Me.btnShowProperty.Name = "btnShowProperty"
            Me.btnShowProperty.TabIndex = 1
            Me.btnShowProperty.Text = ">>"
            '
            'txtPropertyValue
            '
            Me.txtPropertyValue.Location = New System.Drawing.Point(336, 32)
            Me.txtPropertyValue.Name = "txtPropertyValue"
            Me.txtPropertyValue.Size = New System.Drawing.Size(200, 20)
            Me.txtPropertyValue.TabIndex = 2
            Me.txtPropertyValue.Text = ""
            '
            'lstItems
            '
            Me.lstItems.Location = New System.Drawing.Point(40, 112)
            Me.lstItems.Name = "lstItems"
            Me.lstItems.Size = New System.Drawing.Size(528, 329)
            Me.lstItems.TabIndex = 3
            '
            'btnRefresh
            '
            Me.btnRefresh.Location = New System.Drawing.Point(40, 80)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.TabIndex = 1
            Me.btnRefresh.Text = "Refresh"
            '
            'txtTableName
            '
            Me.txtTableName.Location = New System.Drawing.Point(128, 80)
            Me.txtTableName.Name = "txtTableName"
            Me.txtTableName.Size = New System.Drawing.Size(192, 20)
            Me.txtTableName.TabIndex = 0
            Me.txtTableName.Text = "ItemTable"
            '
            'EntityDebugPanel
            '
            Me.Controls.Add(Me.lstItems)
            Me.Controls.Add(Me.txtPropertyValue)
            Me.Controls.Add(Me.btnShowProperty)
            Me.Controls.Add(Me.txtPropertyName)
            Me.Controls.Add(Me.btnRefresh)
            Me.Controls.Add(Me.txtTableName)
            Me.Name = "EntityDebugPanel"
            Me.Size = New System.Drawing.Size(656, 472)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As Object
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As Object)
            MyBase.New()
            Me.InitializeComponent()
            m_entity = entity
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
                Dim pi As PropertyInfo = ty.GetProperty(Me.txtPropertyName.Text)
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
    End Class
End Namespace