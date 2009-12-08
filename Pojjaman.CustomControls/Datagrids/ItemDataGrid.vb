Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Longkong.Pojjaman.Gui.Components

    Public Class ItemDataGrid
        Inherits DataGrid

#Region "Members"
        Private m_allowRowDeletion As Boolean = False
        Private m_allowColumnResize As Boolean = False
        Private m_allowRowResize As Boolean = False

        Private m_autoColumnResize As Boolean = True
        Private m_fullRowSelect As Boolean = False

        Protected Const WM_KEYDOWN As Integer = &H100
        Protected Const VK_LEFT As Integer = &H25
        Protected Const VK_UP As Integer = &H26
        Protected Const VK_RIGHT As Integer = &H27
        Protected Const VK_DOWN As Integer = &H28

        Private m_hitRow As Integer
        Private m_hitCol As Integer

#End Region

#Region "Events"
        Private Sub ItemDataGrid_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
            If m_autoColumnResize AndAlso Not Me.TableStyles Is Nothing AndAlso Me.TableStyles.Count > 0 Then
                Dim space As Integer = SystemInformation.VerticalScrollBarWidth + 10
                Dim w As Integer = Me.Width
                Dim preferredWidth As Integer = w - (space + Me.RowHeaderWidth)
                Dim allColWidth As Integer = 0
                For Each col As DataGridColumnStyle In Me.TableStyles(0).GridColumnStyles
                    allColWidth += col.Width
                Next
                For Each col As DataGridColumnStyle In Me.TableStyles(0).GridColumnStyles
                    col.Width = CInt((col.Width / allColWidth) * preferredWidth)
                Next
            End If
        End Sub
#End Region

#Region "Properies"
        Public Property AllowRowDeletion() As Boolean            Get                Return m_allowRowDeletion            End Get            Set(ByVal Value As Boolean)                m_allowRowDeletion = Value            End Set        End Property
        Public Property AutoColumnResize() As Boolean            Get                Return m_autoColumnResize            End Get            Set(ByVal Value As Boolean)                m_autoColumnResize = Value            End Set        End Property
        Public Property AllowColumnResize() As Boolean
            Get
                Return m_allowColumnResize
            End Get
            Set(ByVal Value As Boolean)
                m_allowColumnResize = Value
            End Set
        End Property
        Public Property AllowRowResize() As Boolean
            Get
                Return m_allowRowResize
            End Get
            Set(ByVal Value As Boolean)
                m_allowRowResize = Value
            End Set
        End Property
        Public Property FullRowSelect() As Boolean
            Get
                Return m_fullRowSelect
            End Get
            Set(ByVal Value As Boolean)
                m_fullRowSelect = Value
            End Set
        End Property
        Private ReadOnly Property TableStyle() As DataGridTableStyle
            Get
                Dim myGridTableInfo As FieldInfo = Me.GetType().GetField("myGridTable", BindingFlags.NonPublic Or BindingFlags.Instance)
                Return CType(myGridTableInfo.GetValue(Me), DataGridTableStyle)
            End Get
        End Property
#End Region

#Region "Overrides"
        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                SendKeys.Send("{Tab}")
                Return True
            End If
            If msg.Msg = WM_KEYDOWN Then
                Dim keyCode As Keys = CType((msg.WParam.ToInt32), Keys)
                If keyCode = Keys.Delete And Not Me.m_allowRowDeletion Then
                    Return True
                End If
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function
        Protected Overloads Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
        End Sub

        Public inTabKey As Boolean = False
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            inTabKey = (keyData = Keys.Tab)
            Return MyBase.ProcessDialogKey(keyData)
        End Function
        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            Dim hti As HitTestInfo = Me.HitTest(e.X, e.Y)
            If Not m_allowColumnResize And hti.Type = DataGrid.HitTestType.ColumnResize Then
                Return
            End If
            If Not m_allowRowResize And hti.Type = DataGrid.HitTestType.ColumnResize Then
                Return
            End If
            MyBase.OnMouseMove(e)
        End Sub
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            Dim hti As HitTestInfo = Me.HitTest(e.X, e.Y)
            If Not m_allowColumnResize And hti.Type = DataGrid.HitTestType.ColumnResize Then
                Return
            End If
            If Not m_allowRowResize And hti.Type = DataGrid.HitTestType.RowResize Then
                Return
            End If
            MyBase.OnMouseDown(e)
        End Sub

        Private m_cellchanged As Boolean = False
        Protected Overrides Sub OnCurrentCellChanged(ByVal e As System.EventArgs)
            m_cellchanged = True
            MyBase.OnCurrentCellChanged(e)
        End Sub
        <Browsable(False)> _
        Public Property Cellchanged() As Boolean            Get                Return m_cellchanged            End Get            Set(ByVal Value As Boolean)                m_cellchanged = Value            End Set        End Property
#End Region


    End Class
End Namespace

