Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Components
    Public Class OptionFrame
        Inherits System.Windows.Forms.UserControl

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
        Friend WithEvents Frame As FixedGroupBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Frame = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.Frame.SuspendLayout()
            Me.SuspendLayout()
            '
            'Frame
            '
            Me.Frame.Controls.Add(Me.Panel1)
            Me.Frame.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Frame.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.Frame.Location = New System.Drawing.Point(0, 0)
            Me.Frame.Name = "Frame"
            Me.Frame.Size = New System.Drawing.Size(208, 104)
            Me.Frame.TabIndex = 0
            Me.Frame.TabStop = False
            '
            'Panel1
            '
            Me.Panel1.AutoScroll = True
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(3, 16)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(202, 85)
            Me.Panel1.TabIndex = 0
            '
            'OptionFrame
            '
            Me.Controls.Add(Me.Frame)
            Me.Name = "OptionFrame"
            Me.Size = New System.Drawing.Size(208, 104)
            Me.Frame.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_access As Access
        Private m_entity As IHasAccess
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub
        Public Sub New(ByVal access As Access, ByVal entity As IHasAccess)
            MyBase.New()
            InitializeComponent()
            Me.m_access = access
            Me.m_entity = entity
        End Sub
#End Region

#Region "Methods"
        Public Sub ClearControl()
            Me.Panel1.Controls.Clear()
        End Sub
        Private Function RevertString(ByVal st As String) As String
            Dim chArr As Char() = st.ToCharArray
            Array.Reverse(chArr)
            st = ""
            For Each ch As Char In chArr
                st &= ch
            Next
            Return st
        End Function
        Public Sub PopulateControl()
            If m_access Is Nothing Then
                Return
            End If
            Dim w As Integer = Me.Panel1.Width
            Dim h As Integer = Me.Panel1.Height
            Dim leftGap As Integer = 8
            Dim rightGap As Integer = 8
            Dim topGap As Integer = 0
            Me.Panel1.Controls.Clear()
            Dim dt As DataTable = CodeDescription.GetCodeList(m_access.CodeName)
            Dim checkString As String = BinaryHelper.DecToBin(m_access.GetEffectiveAccess(m_entity), dt.Rows.Count)
            checkString = Me.RevertString(checkString)
            Dim valueString As String = Configuration.FormatToString(m_access.GetEffectiveValue(m_entity), DigitConfig.Price)
            Select Case m_access.Type
                Case 0 'Key ค่าโดยตรง
                    Dim offset As Integer = topGap
                    Dim interval As Integer = 2
                    Dim indent As Integer = 20
                    Dim i As Integer = 0
                    For Each row As DataRow In dt.Select("code_value<=2", "code_order")
                        Dim rdText As String = row(1).ToString
                        Dim rd1 As New RadioButton
                        rd1.Text = rdText
                        rd1.Width = w - leftGap - rightGap
                        rd1.FlatStyle = FlatStyle.System
                        Me.Panel1.Controls.Add(rd1)
                        rd1.Location = New Point(leftGap, offset)
                        offset += rd1.Height + interval
                        rd1.Checked = CBool(checkString.Substring(i, 1))
                        i += 1
                    Next
                    Dim lbl As New Label
                    lbl.AutoSize = True
                    Me.Panel1.Controls.Add(lbl)
                    lbl.Location = New Point(indent + leftGap, offset + topGap)
                    lbl.Text = dt.Select("code_value=4")(0)("code_description").ToString & ":"
                    Dim txt As New TextBox
                    txt.Width = w - leftGap - rightGap - lbl.Width - indent
                    Me.Panel1.Controls.Add(txt)
                    txt.Location = New Point(indent + leftGap + lbl.Width + interval, offset + topGap)
                    txt.Text = valueString
                Case 1 'Single Select
                    Dim offset As Integer = topGap
                    Dim interval As Integer = 2
                    Dim i As Integer = 0
                    For Each row As DataRow In dt.Rows
                        Dim rdText As String = row(1).ToString
                        Dim rd1 As New RadioButton
                        rd1.Text = rdText
                        rd1.Width = w - leftGap - rightGap
                        rd1.FlatStyle = FlatStyle.System
                        Me.Panel1.Controls.Add(rd1)
                        rd1.Location = New Point(leftGap, offset)
                        offset += rd1.Height + interval
                        rd1.Checked = CBool(checkString.Substring(i, 1))
                        i += 1
                    Next
                Case 2 'multi
                    Dim offset As Integer = topGap
                    Dim interval As Integer = 2
                    Dim i As Integer = 0
                    For Each row As DataRow In dt.Select("code_value<=4", "code_order")
                        Dim rdText As String = row(1).ToString
                        Dim rd1 As New RadioButton
                        rd1.Text = rdText
                        rd1.Width = w - leftGap - rightGap
                        rd1.FlatStyle = FlatStyle.System
                        Me.Panel1.Controls.Add(rd1)
                        rd1.Location = New Point(leftGap, offset)
                        offset += rd1.Height + interval
                        rd1.Checked = CBool(checkString.Substring(i, 1))
                        i += 1
                    Next
                    For Each row As DataRow In dt.Select("code_value>4", "code_order")
                        Dim indent As Integer = CInt(row("code_tag")) * 20
                        Dim chkText As String = row(1).ToString
                        Dim chk1 As New CheckBox
                        chk1.Text = chkText
                        chk1.Width = w - leftGap - rightGap - indent
                        chk1.FlatStyle = FlatStyle.System
                        Me.Panel1.Controls.Add(chk1)
                        chk1.Location = New Point(indent + leftGap, offset)
                        offset += chk1.Height + interval
                        chk1.Checked = CBool(checkString.Substring(i, 1))
                        i += 1
                    Next
                Case 3 'bool
                    Dim trueText As String = dt.Rows(0)(1).ToString
                    Dim falseText As String = dt.Rows(1)(1).ToString
                    Dim interval As Integer = 2
                    Dim rd1 As New RadioButton
                    rd1.Text = trueText
                    rd1.Width = w - leftGap - rightGap
                    rd1.FlatStyle = FlatStyle.System
                    Me.Panel1.Controls.Add(rd1)
                    rd1.Location = New Point(leftGap, topGap)
                    Dim rd2 As New RadioButton
                    rd2.Text = falseText
                    rd2.Width = w - leftGap - rightGap
                    rd2.FlatStyle = FlatStyle.System
                    Me.Panel1.Controls.Add(rd2)
                    rd2.Location = New Point(leftGap, topGap + rd1.Height + interval)
                    rd1.Checked = CBool(checkString.Substring(0, 1))
                    rd2.Checked = CBool(checkString.Substring(1, 1))

            End Select
        End Sub
        Private Function FindControlWitTag(ByVal tag As Integer) As Control
            For Each ctrl As Control In Me.Panel1.Controls
                If Not ctrl.Tag Is Nothing AndAlso IsNumeric(ctrl.Tag) Then
                    If CInt(ctrl.Tag) = tag Then
                        Return ctrl
                    End If
                End If
            Next
        End Function
        Private Sub ControlHandler(ByVal sender As Object, ByVal e As EventArgs)
            If m_access Is Nothing Then
                Return
            End If

        End Sub
#End Region

#Region "Properties"
        Public Property Access() As Access            Get                Return m_access            End Get            Set(ByVal Value As Access)                m_access = Value            End Set        End Property        Public Property Entity() As IHasAccess            Get                Return m_entity            End Get            Set(ByVal Value As IHasAccess)                m_entity = Value            End Set        End Property
        Public Overrides Property Text() As String
            Get
                Return Me.Frame.Text
            End Get
            Set(ByVal Value As String)
                Me.Frame.Text = Value
                MyBase.Text = Value
            End Set
        End Property
#End Region

    End Class

End Namespace