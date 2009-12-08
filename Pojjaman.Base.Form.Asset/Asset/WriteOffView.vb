Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class WriteOffView
        Inherits AbstractEntityDetailPanelView
#Region "Members"
        Private m_entity As WriteOff
#End Region
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
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents ListView1 As System.Windows.Forms.ListView
        Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents txtPerson As System.Windows.Forms.TextBox
        Friend WithEvents lblPerson As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WriteOffView))
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
            Me.lblDocDate = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.ListView1 = New System.Windows.Forms.ListView
            Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
            Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblItem = New System.Windows.Forms.Label
            Me.txtPerson = New System.Windows.Forms.TextBox
            Me.lblPerson = New System.Windows.Forms.Label
            Me.ImageButton1 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(104, 56)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(552, 20)
            Me.txtNote.TabIndex = 234
            Me.txtNote.Text = ""
            '
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(24, 56)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(80, 18)
            Me.lblNote.TabIndex = 235
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDate.Location = New System.Drawing.Point(336, 8)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(104, 20)
            Me.dtpDocDate.TabIndex = 230
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(256, 8)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(80, 16)
            Me.lblDocDate.TabIndex = 233
            Me.lblDocDate.Text = "วันที่เอกสาร"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(24, 8)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 16)
            Me.lblCode.TabIndex = 232
            Me.lblCode.Text = "เลขที่เอกสาร:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.txtCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(104, 8)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(152, 20)
            Me.txtCode.TabIndex = 228
            Me.txtCode.Text = ""
            '
            'ListView1
            '
            Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
            Me.ListView1.Location = New System.Drawing.Point(8, 120)
            Me.ListView1.Name = "ListView1"
            Me.ListView1.Size = New System.Drawing.Size(648, 152)
            Me.ListView1.TabIndex = 227
            Me.ListView1.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader1
            '
            Me.ColumnHeader1.Text = "รหัสเครื่องจักร"
            Me.ColumnHeader1.Width = 81
            '
            'ColumnHeader2
            '
            Me.ColumnHeader2.Text = "ชื่อเครื่องจักร"
            Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.ColumnHeader2.Width = 198
            '
            'ColumnHeader3
            '
            Me.ColumnHeader3.Text = "ค่าเสื่อมราคาคงเหลือ"
            Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.ColumnHeader3.Width = 109
            '
            'ColumnHeader4
            '
            Me.ColumnHeader4.Text = "ค่าซาก"
            Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.ColumnHeader4.Width = 85
            '
            'ColumnHeader5
            '
            Me.ColumnHeader5.Text = "รวม"
            Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.ColumnHeader5.Width = 84
            '
            'ColumnHeader6
            '
            Me.ColumnHeader6.Text = "ราคาขาย"
            Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.ColumnHeader6.Width = 86
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 112)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(656, 168)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 225
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(8, 96)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(120, 18)
            Me.lblItem.TabIndex = 226
            Me.lblItem.Text = "รายการเครื่องจักร"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPerson
            '
            Me.txtPerson.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtPerson, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPerson, "")
            Me.Validator.SetGotFocusBackColor(Me.txtPerson, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPerson, System.Drawing.Color.Empty)
            Me.txtPerson.Location = New System.Drawing.Point(104, 32)
            Me.Validator.SetMaxValue(Me.txtPerson, "")
            Me.Validator.SetMinValue(Me.txtPerson, "")
            Me.txtPerson.Name = "txtPerson"
            Me.Validator.SetRegularExpression(Me.txtPerson, "")
            Me.Validator.SetRequired(Me.txtPerson, False)
            Me.txtPerson.Size = New System.Drawing.Size(552, 20)
            Me.txtPerson.TabIndex = 229
            Me.txtPerson.Text = ""
            '
            'lblPerson
            '
            Me.lblPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPerson.Location = New System.Drawing.Point(24, 32)
            Me.lblPerson.Name = "lblPerson"
            Me.lblPerson.Size = New System.Drawing.Size(80, 16)
            Me.lblPerson.TabIndex = 231
            Me.lblPerson.Text = "ขายให้:"
            Me.lblPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ImageButton1
            '
            Me.ImageButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton1.Image = CType(resources.GetObject("ImageButton1.Image"), System.Drawing.Image)
            Me.ImageButton1.Location = New System.Drawing.Point(136, 88)
            Me.ImageButton1.Name = "ImageButton1"
            Me.ImageButton1.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton1.TabIndex = 236
            Me.ImageButton1.TabStop = False
            Me.ImageButton1.ThemedImage = CType(resources.GetObject("ImageButton1.ThemedImage"), System.Drawing.Bitmap)
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Me.ErrorProvider1
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'WriteOffView
            '
            Me.Controls.Add(Me.ImageButton1)
            Me.Controls.Add(Me.txtNote)
            Me.Controls.Add(Me.lblNote)
            Me.Controls.Add(Me.dtpDocDate)
            Me.Controls.Add(Me.lblDocDate)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.ListView1)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.txtPerson)
            Me.Controls.Add(Me.lblPerson)
            Me.Name = "WriteOffView"
            Me.Size = New System.Drawing.Size(672, 312)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub txtPerson_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPerson.TextChanged

        End Sub

        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")
            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WriteOffView.lblCode}")
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WriteOffView.lblItem}")
            Me.lblPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WriteOffView.lblPerson}")

        End Sub
    End Class
End Namespace