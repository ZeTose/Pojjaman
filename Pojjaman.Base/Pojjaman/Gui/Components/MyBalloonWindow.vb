'Option Strict Off
'Imports System
'Imports System.IO
'Imports System.Resources
'Imports System.Collections
'Imports System.Reflection
'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Windows.Forms
'Imports Rilling.Common.UI.Forms


'Namespace Pojjaman.UI
'    _
'    Public Class MyBalloonWindow
'        Inherits BalloonWindow
'        Private cboTrigShape As System.Windows.Forms.ComboBox
'        Private label1 As System.Windows.Forms.Label
'        Private WithEvents tmrMoveTime As System.Windows.Forms.Timer
'        Private label2 As System.Windows.Forms.Label
'        Private WithEvents pnlTrigShape As System.Windows.Forms.Panel
'        Private label5 As System.Windows.Forms.Label
'        Private components As System.ComponentModel.IContainer = Nothing


'        Public Sub New()
'            ' This call is required by the Windows Form Designer.
'            InitializeComponent()
'        End Sub 'New

'        ' TODO: Add any initialization after the InitializeComponent call

'        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
'            SetRadianTick()

'            MyBase.OnLoad(e)
'        End Sub 'OnLoad


'        Private Sub SetRadianTick()
'            Dim drawWidth As Integer = pnlTrigShape.Width - 1
'            'double period = ((double)numericUpDown2.Value)*(2*Math.PI);
'            Dim period As Double = 2 * Math.PI

'            __radianTick = period / drawWidth
'        End Sub 'SetRadianTick

'        Private __radianTick As Double


'        '/ <summary>
'        '/ Clean up any resources being used.
'        '/ </summary>
'        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'            If disposing Then
'                If Not (components Is Nothing) Then
'                    components.Dispose()
'                End If
'            End If
'            MyBase.Dispose(disposing)
'        End Sub 'Dispose


'        '
'        'ToDo: Error processing original source shown below
'        '
'        '
'        '-----^--- Pre-processor directives not translated
'        '/ <summary>
'        '
'        'ToDo: Error processing original source shown below
'        '
'        '
'        '--^--- Unexpected pre-processor directive
'        '/ Required method for Designer support - do not modify
'        '/ the contents of this method with the code editor.
'        '/ </summary>
'        Private Sub InitializeComponent()
'            Me.components = New System.ComponentModel.Container
'            Me.cboTrigShape = New System.Windows.Forms.ComboBox
'            Me.label1 = New System.Windows.Forms.Label
'            Me.tmrMoveTime = New System.Windows.Forms.Timer(Me.components)
'            Me.label2 = New System.Windows.Forms.Label
'            Me.pnlTrigShape = New System.Windows.Forms.Panel
'            Me.label5 = New System.Windows.Forms.Label
'            Me.SuspendLayout()
'            ' 
'            ' cboTrigShape
'            ' 
'            Me.cboTrigShape.Items.AddRange(New Object() {"Cosine", "Sine", "Tangent"})
'            Me.cboTrigShape.Location = New System.Drawing.Point(152, 160)
'            Me.cboTrigShape.Name = "cboTrigShape"
'            Me.cboTrigShape.Size = New System.Drawing.Size(112, 21)
'            Me.cboTrigShape.TabIndex = 2
'            Me.cboTrigShape.Text = "Sine"
'            ' 
'            ' label1
'            ' 
'            Me.label1.BackColor = System.Drawing.Color.Transparent
'            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
'            Me.label1.Location = New System.Drawing.Point(32, 160)
'            Me.label1.Name = "label1"
'            Me.label1.Size = New System.Drawing.Size(120, 24)
'            Me.label1.TabIndex = 4
'            Me.label1.Text = "Trigonometric Shape:"
'            Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'            ' 
'            ' tmrMoveTime
'            ' 
'            ' 
'            ' label2
'            ' 
'            Me.label2.BackColor = System.Drawing.Color.Transparent
'            Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
'            Me.label2.Location = New System.Drawing.Point(32, 8)
'            Me.label2.Name = "label2"
'            Me.label2.Size = New System.Drawing.Size(248, 16)
'            Me.label2.TabIndex = 10
'            Me.label2.Text = "Sample Balloon Containing Controls"
'            ' 
'            ' pnlTrigShape
'            ' 
'            Me.pnlTrigShape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.pnlTrigShape.Location = New System.Drawing.Point(8, 24)
'            Me.pnlTrigShape.Name = "pnlTrigShape"
'            Me.pnlTrigShape.Size = New System.Drawing.Size(288, 100)
'            Me.pnlTrigShape.TabIndex = 20
'            ' 
'            ' label5
'            ' 
'            Me.label5.BackColor = System.Drawing.Color.Transparent
'            Me.label5.Location = New System.Drawing.Point(136, 128)
'            Me.label5.Name = "label5"
'            Me.label5.Size = New System.Drawing.Size(152, 23)
'            Me.label5.TabIndex = 21
'            Me.label5.Text = "label5"
'            Me.label5.TextAlign = System.Drawing.ContentAlignment.TopRight
'            ' 
'            ' MyBalloonWindow
'            ' 
'            Me.AnchorPoint = New System.Drawing.Point(312, 30)
'            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'            Me.ClientSize = New System.Drawing.Size(300, 200)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label5, Me.pnlTrigShape, Me.label2, Me.cboTrigShape, Me.label1})
'            Me.Name = "MyBalloonWindow"
'            Me.Shadow = False
'            Me.ResumeLayout(False)
'        End Sub 'InitializeComponent 
'        '
'        'ToDo: Error processing original source shown below
'        '
'        '
'        '-----^--- Pre-processor directives not translated
'        Private displayPoint As Point = Point.Empty '
'        'ToDo: Error processing original source shown below
'        '
'        '
'        '--^--- Unexpected pre-processor directive
'        Private nextRadian As Double = 0

'        Private Sub pnlTrigShape_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlTrigShape.Paint
'            Dim grx As Graphics = e.Graphics
'            grx.DrawRectangle(Pens.Black, displayPoint.X, displayPoint.Y, 2, 2)
'            label5.Text = displayPoint.ToString()
'        End Sub 'pnlTrigShape_Paint



'        Private Sub numericUpDown2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
'            SetRadianTick()
'        End Sub 'numericUpDown2_ValueChanged


'        Protected Overrides Sub OnVisibleChanged(ByVal e As EventArgs)
'            tmrMoveTime.Enabled = Visible

'            MyBase.OnVisibleChanged(e)
'        End Sub 'OnVisibleChanged


'        Private Sub tmrMoveTime_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrMoveTime.Tick
'            Dim trig As String = Me.cboTrigShape.Text

'            Select Case trig
'                Case "Sine"
'                    displayPoint.Y = CInt(Math.Sin(nextRadian) * Me.pnlTrigShape.Height)
'                Case "Cosine"
'                    displayPoint.Y = CInt(Math.Cos(nextRadian) * Me.pnlTrigShape.Height)
'                Case "Tangent"
'                    displayPoint.Y = CInt(Math.Tan(nextRadian) * Me.pnlTrigShape.Height)
'            End Select

'            displayPoint.Y = displayPoint.Y / 2 + Me.pnlTrigShape.Height / 2

'            displayPoint.X = (displayPoint.X + 1) Mod Me.pnlTrigShape.Width
'            nextRadian += Me.__radianTick
'            Me.pnlTrigShape.Invalidate(False)
'        End Sub 'tmrMoveTime_Tick
'    End Class 'MyBalloonWindow
'End Namespace 'Rilling.Applications.Samples.BalloonWindowDemo
