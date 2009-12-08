Public Class PJMDateTimePicker
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

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
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(0, 0)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.TabIndex = 0
        Me.txtValue.Text = ""
        '
        'PJMDateTimePicker
        '
        Me.Controls.Add(Me.txtValue)
        Me.Name = "PJMDateTimePicker"
        Me.Size = New System.Drawing.Size(368, 20)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
