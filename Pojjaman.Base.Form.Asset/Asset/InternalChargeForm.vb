Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class InternalChargeForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents calendar As Syncfusion.Windows.Forms.Grid.GridControl
    Friend WithEvents DateTimePickerAdv1 As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.calendar = New Syncfusion.Windows.Forms.Grid.GridControl
        Me.DateTimePickerAdv1 = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
        CType(Me.calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimePickerAdv1.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(496, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        '
        'calendar
        '
        Me.calendar.DefaultColWidth = 30
        Me.calendar.DefaultRowHeight = 30
        Me.calendar.Location = New System.Drawing.Point(16, 40)
        Me.calendar.Name = "calendar"
        Me.calendar.SerializeCellsBehavior = Syncfusion.Windows.Forms.Grid.GridSerializeCellsBehavior.SerializeAsRangeStylesIntoCode
        Me.calendar.Size = New System.Drawing.Size(216, 216)
        Me.calendar.SmartSizeBox = False
        Me.calendar.TabIndex = 4
        Me.calendar.Text = "GridControl3"
        Me.calendar.UseRightToLeftCompatibleTextBox = True
        '
        'DateTimePickerAdv1
        '
        Me.DateTimePickerAdv1.BorderColor = System.Drawing.SystemColors.ControlDark
        '
        'DateTimePickerAdv1.Calendar
        '
        Me.DateTimePickerAdv1.Calendar.AllowMultipleSelection = False
        Me.DateTimePickerAdv1.Calendar.Culture = New System.Globalization.CultureInfo("")
        Me.DateTimePickerAdv1.Calendar.DayNamesFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.DateTimePickerAdv1.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.DateTimePickerAdv1.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTimePickerAdv1.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DateTimePickerAdv1.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.DateTimePickerAdv1.Calendar.MinValue = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateTimePickerAdv1.Calendar.Name = "monthCalendar"
        '
        'DateTimePickerAdv1.Calendar.NoneButton
        '
        Me.DateTimePickerAdv1.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.WindowsXP
        Me.DateTimePickerAdv1.Calendar.NoneButton.Location = New System.Drawing.Point(194, 0)
        Me.DateTimePickerAdv1.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.DateTimePickerAdv1.Calendar.NoneButton.Text = "None"
        Me.DateTimePickerAdv1.Calendar.NoneButton.UseVisualStyle = False
        Me.DateTimePickerAdv1.Calendar.SelectedDates = New Date() {New Date(2007, 9, 18, 15, 1, 27, 453)}
        Me.DateTimePickerAdv1.Calendar.Size = New System.Drawing.Size(266, 174)
        Me.DateTimePickerAdv1.Calendar.SizeToFit = True
        Me.DateTimePickerAdv1.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Default
        Me.DateTimePickerAdv1.Calendar.TabIndex = 0
        '
        'DateTimePickerAdv1.Calendar.TodayButton
        '
        Me.DateTimePickerAdv1.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.WindowsXP
        Me.DateTimePickerAdv1.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.DateTimePickerAdv1.Calendar.TodayButton.Size = New System.Drawing.Size(194, 20)
        Me.DateTimePickerAdv1.Calendar.TodayButton.Text = "Today"
        Me.DateTimePickerAdv1.Calendar.TodayButton.UseVisualStyle = False
        Me.DateTimePickerAdv1.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.DateTimePickerAdv1.CustomFormat = "mm/yyyy"
        Me.DateTimePickerAdv1.DropDownImage = Nothing
        Me.DateTimePickerAdv1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAdv1.Location = New System.Drawing.Point(16, 16)
        Me.DateTimePickerAdv1.Name = "DateTimePickerAdv1"
        Me.DateTimePickerAdv1.ShowCheckBox = False
        Me.DateTimePickerAdv1.ShowDropButton = False
        Me.DateTimePickerAdv1.ShowUpDown = True
        Me.DateTimePickerAdv1.Size = New System.Drawing.Size(216, 20)
        Me.DateTimePickerAdv1.TabIndex = 5
        Me.DateTimePickerAdv1.Value = New Date(2007, 9, 18, 15, 1, 27, 453)
        '
        'InternalChargeForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 526)
        Me.Controls.Add(Me.DateTimePickerAdv1)
        Me.Controls.Add(Me.calendar)
        Me.Controls.Add(Me.Button1)
        Me.Name = "InternalChargeForm"
        Me.Text = "InternalChargeForm"
        CType(Me.calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimePickerAdv1.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimePickerAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InternalChargeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePickerAdv1.Value = Now.Date
    End Sub
    Private m_cells As ArrayList
    Private Sub DateTimePickerAdv1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerAdv1.ValueChanged
        Dim theDate As Date = DateTimePickerAdv1.Value
        m_cells = CalendarHelper.WriteCalendar(DateTimePickerAdv1.Value, calendar, DayOfWeek.Monday)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If m_cells Is Nothing Then
            Return
        End If
        For Each gi As Syncfusion.Windows.Forms.Grid.GridStyleInfo In m_cells
            gi.BackColor = Color.AliceBlue
        Next
        If m_cells Is Nothing OrElse m_cells.Count = 0 Then
            Return
        End If
        Dim theDate As Date = DateTimePickerAdv1.Value
        Dim theStart As Date = New Date(theDate.Year, theDate.Month, CInt(CType(m_cells(0), Syncfusion.Windows.Forms.Grid.GridStyleInfo).CellValue))
        Dim theEnd As Date = New Date(theDate.Year, theDate.Month, CInt(CType(m_cells(m_cells.Count - 1), Syncfusion.Windows.Forms.Grid.GridStyleInfo).CellValue))
        Dim myRange As New DateRange(theStart, theEnd)



        Dim testDate As New Date(theDate.Year, theDate.Month, 11)
        Dim testEndDate As New Date(theDate.Year, theDate.Month, 15)
        Dim myOtherRange As New DateRange(testDate, testEndDate)
        Dim rangeColl As New DateRangeCollection
        rangeColl.Add(myOtherRange)
        testDate = New Date(theDate.Year, theDate.Month, 21)
        testEndDate = New Date(theDate.Year, theDate.Month, 30)
        myOtherRange = New DateRange(testDate, testEndDate)
        rangeColl.Add(myOtherRange)

        For Each otherRange As DateRange In rangeColl
            Dim x As DateRange = myRange.GetIntersection(otherRange)
            For i As Integer = x.StartDate.Day - 1 To x.EndDate.Day - 1
                CType(m_cells(i), Syncfusion.Windows.Forms.Grid.GridStyleInfo).BackColor = Color.Cyan
            Next
        Next
    End Sub
End Class
