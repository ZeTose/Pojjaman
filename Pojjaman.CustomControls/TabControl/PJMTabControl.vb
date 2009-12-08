Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMTabControl
        Inherits Windows.Forms.TabControl

#Region "Members"
        Private intTab As Integer

        'Notification messages for Tab control
        Private Const TCN_FIRST As Long = &HFFFFFFFFFFFFFDDA&
        Private Const TCN_SELCHANGE As Long = (TCN_FIRST - 1)
        Private Const TCN_SELCHANGING As Long = (TCN_FIRST - 2)
        Private Const TCM_GETCURSEL As Integer = &H1300 + 11
        Private Const TCM_SETCURSEL As Integer = &H1300 + 12
        'Constants to capture WM_NOTIFY messages
        Private Const WM_USER As Long = &H400&
        Private Const WM_NOTIFY As Long = &H4E&
        Private Const WM_REFLECT As Long = WM_USER + &H1C00&

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure NMHDR
            Public HWND As Int32
            Public idFrom As Int32
            Public code As Int32

            Public Overloads Function ToString() As String
                Dim strReturn As String = String.Format("Hwnd {0}", HWND)
                strReturn &= vbCrLf & String.Format("From {0}", idFrom)
                strReturn &= vbCrLf & String.Format("Code {0}", code)
                Return strReturn
            End Function
        End Structure
#End Region

#Region "Constructors"
        Public Sub New()
            Me.DrawMode = TabDrawMode.OwnerDrawFixed
        End Sub
#End Region

#Region "Methods"
        Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
            Dim g As Graphics = e.Graphics
            Dim tp As TabPage = Me.TabPages(e.Index)
            Dim sf As New StringFormat
            Dim brText As New SolidBrush(tp.ForeColor)
            Dim rDraw As RectangleF

            Dim br As New LinearGradientBrush(e.Bounds, tp.BackColor, Color.White, 90, False)

            Dim bl As New Blend

            bl.Factors = New Single() {0.0F, 0.1F, 0.5F, 0.7F, 0.7F, 0.5F, 0.3F, 0.2F, 0}

            bl.Positions = New Single() {0, 0.1F, 0.2F, 0.5F, 0.6F, 0.7F, 0.8F, 0.9F, 1.0F}

            br.Blend = bl

            sf.LineAlignment = StringAlignment.Center
            sf.Alignment = StringAlignment.Center

            g.FillRectangle(br, RectangleF.op_Implicit(e.Bounds))

            If tp.ImageIndex >= 0 Then
                Dim img As Image = Me.ImageList.Images.Item(tp.ImageIndex)
                rDraw = New RectangleF(e.Bounds.Left + 21, e.Bounds.Top, _
                    e.Bounds.Width - 21, e.Bounds.Height)
                Dim yOffset As Integer = 0
                Dim xOffset As Integer = 0
                If e.Index <> Me.SelectedIndex Then
                    yOffset += 4
                    xOffset += 3
                End If
                g.DrawImage(img, e.Bounds.Left + 5 - xOffset, e.Bounds.Top + 2 - yOffset, 16, 16)
            Else
                rDraw = RectangleF.op_Implicit(e.Bounds)
            End If
            If Not tp.Enabled Then
                brText = New SolidBrush(SystemColors.GrayText)
            End If

            g.DrawString(tp.Text, Me.Font, brText, rDraw, sf)
        End Sub

        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

            If m.Msg = (WM_REFLECT + WM_NOTIFY) Then
                'We've received a WM_NOTIFY message
                'get the NMHDR struct
                Try
                    Dim hdr As NMHDR
                    hdr = CType(System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, hdr.GetType()), NMHDR)
                    If hdr.code = TCN_SELCHANGING Then
                        'the selection is changing.
                        'Raise the SelectedIndexChanging event and allow user to cancel
                        Dim pt As Point
                        pt = Me.PointToClient(Cursor.Position)

                        Dim x As Integer
                        For x = 0 To Me.TabCount - 1
                            Dim r As Rectangle = Me.GetTabRect(x)

                            If r.Contains(pt) Then
                                intTab = x
                            End If
                        Next

                        Dim tp As TabPage = Me.TabPages.Item(intTab)
                        Dim e As New TabSelectionChangingArgs(Me.SelectedIndex, intTab)

                        RaiseEvent SelectedIndexChanging(Me, e)

                        If e.Cancel Then
                            m.Result = New IntPtr(1)
                            Return
                        End If
                    End If
                Catch
                    'ignore errors
                End Try
            End If
            MyBase.WndProc(m)
        End Sub
        Private Sub OnteoraTabControl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
            'Dim pt As Point
            'Dim x As Integer
            'Dim tp As TabPage

            'pt = Me.PointToClient(Cursor.Position)

            'For x = 0 To Me.TabCount - 1
            '    Dim r As Rectangle = Me.GetTabRect(x)

            '    If r.Contains(pt) Then
            '        intTab = x
            '    End If
            'Next

            'tp = Me.TabPages.Item(intTab)

            'Dim frm As New frmFloatTab(Me)
            'Dim ctrl As Control

            'frm.Text = tp.Text
            'frm.Panel1.BackColor = tp.BackColor
            'frm.Panel1.ForeColor = tp.ForeColor

            'For Each ctrl In tp.Controls
            '    ctrl.Parent = frm.Panel1
            'Next

            'If tp.ImageIndex >= 0 Then
            '    Dim bm As Bitmap = CType(Me.ImageList.Images(tp.ImageIndex), Bitmap)
            '    frm.Icon = Icon.FromHandle(bm.GetHicon)
            '    frm.Tag = tp.ImageIndex
            'End If

            'frm.Show()
            'frm.BringToFront()
            'Me.TabPages.Remove(tp)
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Events"
        <Description("Occurs as a tab is being changed.")> _
        Public Event SelectedIndexChanging(ByVal sender As Object, ByVal e As TabSelectionChangingArgs)
#End Region

    End Class

    Public Class TabSelectionChangingArgs
        Inherits CancelEventArgs

        Dim m_intCurrent As Integer
        Dim m_intNew As Integer

        Public ReadOnly Property CurrentTabIndex() As Integer
            Get
                Return m_intCurrent
            End Get
        End Property

        Public ReadOnly Property NewTabIndex() As Integer
            Get
                Return m_intNew
            End Get
        End Property

        Public Sub New(ByVal CurrentTabIndex As Integer, ByVal NewTabIndex As Integer)
            MyBase.New()
            m_intCurrent = CurrentTabIndex
            m_intNew = NewTabIndex
        End Sub
    End Class
End Namespace

