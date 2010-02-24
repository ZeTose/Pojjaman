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
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class WHTConfigurationView
        'Inherits UserControl
        Inherits AbstractOptionPanel
    Implements IValidatable

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
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAccountFind01 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountEdit01 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountName01 As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountCode01 As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountFind07 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountEdit07 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountName07 As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountCode07 As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountFind06 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountEdit06 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountName06 As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountCode06 As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountFind05 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountEdit05 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountName05 As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountCode05 As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountFind04 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountEdit04 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountName04 As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountCode04 As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountFind03 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountEdit03 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountName03 As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountCode03 As System.Windows.Forms.TextBox
    Friend WithEvents btnAccountFind02 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountEdit02 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAccountName02 As System.Windows.Forms.TextBox
        Friend WithEvents txtAccountCode02 As System.Windows.Forms.TextBox
        Friend WithEvents btnAccountFind08 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnAccountEdit08 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAccountName08 As System.Windows.Forms.TextBox
        Friend WithEvents txtAccountCode08 As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WHTConfigurationView))
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
            Me.txtAccountCode01 = New System.Windows.Forms.TextBox()
            Me.txtAccountCode02 = New System.Windows.Forms.TextBox()
            Me.txtAccountCode03 = New System.Windows.Forms.TextBox()
            Me.txtAccountCode04 = New System.Windows.Forms.TextBox()
            Me.txtAccountCode05 = New System.Windows.Forms.TextBox()
            Me.txtAccountCode06 = New System.Windows.Forms.TextBox()
            Me.txtAccountCode07 = New System.Windows.Forms.TextBox()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
            Me.txtAccountName01 = New System.Windows.Forms.TextBox()
            Me.txtAccountName02 = New System.Windows.Forms.TextBox()
            Me.txtAccountName03 = New System.Windows.Forms.TextBox()
            Me.txtAccountName04 = New System.Windows.Forms.TextBox()
            Me.txtAccountName05 = New System.Windows.Forms.TextBox()
            Me.txtAccountName06 = New System.Windows.Forms.TextBox()
            Me.txtAccountName07 = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.btnAccountFind01 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountEdit01 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountFind02 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountEdit02 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountFind03 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountEdit03 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountFind04 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountEdit04 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountFind05 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountEdit05 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountFind06 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountEdit06 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountFind07 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountEdit07 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountFind08 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountEdit08 = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtAccountName08 = New System.Windows.Forms.TextBox()
            Me.txtAccountCode08 = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txtAccountCode01
            '
            Me.Validator.SetDataType(Me.txtAccountCode01, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode01, "")
            Me.txtAccountCode01.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode01, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode01, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode01, System.Drawing.Color.Empty)
            Me.txtAccountCode01.Location = New System.Drawing.Point(124, 51)
            Me.txtAccountCode01.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode01, "")
            Me.txtAccountCode01.Name = "txtAccountCode01"
            Me.Validator.SetRegularExpression(Me.txtAccountCode01, "")
            Me.Validator.SetRequired(Me.txtAccountCode01, True)
            Me.txtAccountCode01.Size = New System.Drawing.Size(80, 21)
            Me.txtAccountCode01.TabIndex = 24
            '
            'txtAccountCode02
            '
            Me.Validator.SetDataType(Me.txtAccountCode02, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode02, "")
            Me.txtAccountCode02.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode02, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode02, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode02, System.Drawing.Color.Empty)
            Me.txtAccountCode02.Location = New System.Drawing.Point(124, 81)
            Me.txtAccountCode02.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode02, "")
            Me.txtAccountCode02.Name = "txtAccountCode02"
            Me.Validator.SetRegularExpression(Me.txtAccountCode02, "")
            Me.Validator.SetRequired(Me.txtAccountCode02, True)
            Me.txtAccountCode02.Size = New System.Drawing.Size(80, 21)
            Me.txtAccountCode02.TabIndex = 29
            '
            'txtAccountCode03
            '
            Me.Validator.SetDataType(Me.txtAccountCode03, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode03, "")
            Me.txtAccountCode03.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode03, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode03, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode03, System.Drawing.Color.Empty)
            Me.txtAccountCode03.Location = New System.Drawing.Point(124, 111)
            Me.txtAccountCode03.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode03, "")
            Me.txtAccountCode03.Name = "txtAccountCode03"
            Me.Validator.SetRegularExpression(Me.txtAccountCode03, "")
            Me.Validator.SetRequired(Me.txtAccountCode03, True)
            Me.txtAccountCode03.Size = New System.Drawing.Size(80, 21)
            Me.txtAccountCode03.TabIndex = 33
            '
            'txtAccountCode04
            '
            Me.Validator.SetDataType(Me.txtAccountCode04, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode04, "")
            Me.txtAccountCode04.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode04, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode04, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode04, System.Drawing.Color.Empty)
            Me.txtAccountCode04.Location = New System.Drawing.Point(124, 142)
            Me.txtAccountCode04.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode04, "")
            Me.txtAccountCode04.Name = "txtAccountCode04"
            Me.Validator.SetRegularExpression(Me.txtAccountCode04, "")
            Me.Validator.SetRequired(Me.txtAccountCode04, True)
            Me.txtAccountCode04.Size = New System.Drawing.Size(80, 21)
            Me.txtAccountCode04.TabIndex = 37
            '
            'txtAccountCode05
            '
            Me.Validator.SetDataType(Me.txtAccountCode05, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode05, "")
            Me.txtAccountCode05.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode05, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode05, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode05, System.Drawing.Color.Empty)
            Me.txtAccountCode05.Location = New System.Drawing.Point(124, 171)
            Me.txtAccountCode05.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode05, "")
            Me.txtAccountCode05.Name = "txtAccountCode05"
            Me.Validator.SetRegularExpression(Me.txtAccountCode05, "")
            Me.Validator.SetRequired(Me.txtAccountCode05, True)
            Me.txtAccountCode05.Size = New System.Drawing.Size(80, 21)
            Me.txtAccountCode05.TabIndex = 41
            '
            'txtAccountCode06
            '
            Me.Validator.SetDataType(Me.txtAccountCode06, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode06, "")
            Me.txtAccountCode06.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode06, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode06, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode06, System.Drawing.Color.Empty)
            Me.txtAccountCode06.Location = New System.Drawing.Point(124, 201)
            Me.txtAccountCode06.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode06, "")
            Me.txtAccountCode06.Name = "txtAccountCode06"
            Me.Validator.SetRegularExpression(Me.txtAccountCode06, "")
            Me.Validator.SetRequired(Me.txtAccountCode06, True)
            Me.txtAccountCode06.Size = New System.Drawing.Size(80, 21)
            Me.txtAccountCode06.TabIndex = 45
            '
            'txtAccountCode07
            '
            Me.Validator.SetDataType(Me.txtAccountCode07, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode07, "")
            Me.txtAccountCode07.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode07, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode07, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode07, System.Drawing.Color.Empty)
            Me.txtAccountCode07.Location = New System.Drawing.Point(124, 231)
            Me.txtAccountCode07.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode07, "")
            Me.txtAccountCode07.Name = "txtAccountCode07"
            Me.Validator.SetRegularExpression(Me.txtAccountCode07, "")
            Me.Validator.SetRequired(Me.txtAccountCode07, True)
            Me.txtAccountCode07.Size = New System.Drawing.Size(80, 21)
            Me.txtAccountCode07.TabIndex = 49
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Nothing
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            '
            'txtAccountName01
            '
            Me.Validator.SetDataType(Me.txtAccountName01, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName01, "")
            Me.txtAccountName01.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName01, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName01, System.Drawing.Color.Empty)
            Me.txtAccountName01.Location = New System.Drawing.Point(204, 51)
            Me.Validator.SetMinValue(Me.txtAccountName01, "")
            Me.txtAccountName01.Name = "txtAccountName01"
            Me.txtAccountName01.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName01, "")
            Me.Validator.SetRequired(Me.txtAccountName01, False)
            Me.txtAccountName01.Size = New System.Drawing.Size(120, 21)
            Me.txtAccountName01.TabIndex = 26
            Me.txtAccountName01.TabStop = False
            '
            'txtAccountName02
            '
            Me.Validator.SetDataType(Me.txtAccountName02, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName02, "")
            Me.txtAccountName02.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName02, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName02, System.Drawing.Color.Empty)
            Me.txtAccountName02.Location = New System.Drawing.Point(204, 81)
            Me.Validator.SetMinValue(Me.txtAccountName02, "")
            Me.txtAccountName02.Name = "txtAccountName02"
            Me.txtAccountName02.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName02, "")
            Me.Validator.SetRequired(Me.txtAccountName02, False)
            Me.txtAccountName02.Size = New System.Drawing.Size(120, 21)
            Me.txtAccountName02.TabIndex = 30
            Me.txtAccountName02.TabStop = False
            '
            'txtAccountName03
            '
            Me.Validator.SetDataType(Me.txtAccountName03, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName03, "")
            Me.txtAccountName03.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName03, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName03, System.Drawing.Color.Empty)
            Me.txtAccountName03.Location = New System.Drawing.Point(204, 111)
            Me.Validator.SetMinValue(Me.txtAccountName03, "")
            Me.txtAccountName03.Name = "txtAccountName03"
            Me.txtAccountName03.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName03, "")
            Me.Validator.SetRequired(Me.txtAccountName03, False)
            Me.txtAccountName03.Size = New System.Drawing.Size(120, 21)
            Me.txtAccountName03.TabIndex = 34
            Me.txtAccountName03.TabStop = False
            '
            'txtAccountName04
            '
            Me.Validator.SetDataType(Me.txtAccountName04, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName04, "")
            Me.txtAccountName04.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName04, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName04, System.Drawing.Color.Empty)
            Me.txtAccountName04.Location = New System.Drawing.Point(204, 142)
            Me.Validator.SetMinValue(Me.txtAccountName04, "")
            Me.txtAccountName04.Name = "txtAccountName04"
            Me.txtAccountName04.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName04, "")
            Me.Validator.SetRequired(Me.txtAccountName04, False)
            Me.txtAccountName04.Size = New System.Drawing.Size(120, 21)
            Me.txtAccountName04.TabIndex = 38
            Me.txtAccountName04.TabStop = False
            '
            'txtAccountName05
            '
            Me.Validator.SetDataType(Me.txtAccountName05, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName05, "")
            Me.txtAccountName05.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName05, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName05, System.Drawing.Color.Empty)
            Me.txtAccountName05.Location = New System.Drawing.Point(204, 171)
            Me.Validator.SetMinValue(Me.txtAccountName05, "")
            Me.txtAccountName05.Name = "txtAccountName05"
            Me.txtAccountName05.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName05, "")
            Me.Validator.SetRequired(Me.txtAccountName05, False)
            Me.txtAccountName05.Size = New System.Drawing.Size(120, 21)
            Me.txtAccountName05.TabIndex = 42
            Me.txtAccountName05.TabStop = False
            '
            'txtAccountName06
            '
            Me.Validator.SetDataType(Me.txtAccountName06, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName06, "")
            Me.txtAccountName06.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName06, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName06, System.Drawing.Color.Empty)
            Me.txtAccountName06.Location = New System.Drawing.Point(204, 201)
            Me.Validator.SetMinValue(Me.txtAccountName06, "")
            Me.txtAccountName06.Name = "txtAccountName06"
            Me.txtAccountName06.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName06, "")
            Me.Validator.SetRequired(Me.txtAccountName06, False)
            Me.txtAccountName06.Size = New System.Drawing.Size(120, 21)
            Me.txtAccountName06.TabIndex = 46
            Me.txtAccountName06.TabStop = False
            '
            'txtAccountName07
            '
            Me.Validator.SetDataType(Me.txtAccountName07, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName07, "")
            Me.txtAccountName07.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName07, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName07, System.Drawing.Color.Empty)
            Me.txtAccountName07.Location = New System.Drawing.Point(204, 231)
            Me.Validator.SetMinValue(Me.txtAccountName07, "")
            Me.txtAccountName07.Name = "txtAccountName07"
            Me.txtAccountName07.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName07, "")
            Me.Validator.SetRequired(Me.txtAccountName07, False)
            Me.txtAccountName07.Size = New System.Drawing.Size(120, 21)
            Me.txtAccountName07.TabIndex = 50
            Me.txtAccountName07.TabStop = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(40, 55)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(51, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "¿.ß.¥.1°"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(40, 85)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "¿.ß.¥.1° æ‘‡»…"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(40, 115)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(44, 13)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "¿.ß.¥.2"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(40, 146)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(44, 13)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "¿.ß.¥.3"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(40, 175)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(51, 13)
            Me.Label5.TabIndex = 4
            Me.Label5.Text = "¿.ß.¥.2°"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(40, 205)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(51, 13)
            Me.Label6.TabIndex = 5
            Me.Label6.Text = "¿.ß.¥.3°"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(40, 235)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(50, 13)
            Me.Label7.TabIndex = 6
            Me.Label7.Text = "¿.ß.¥.53"
            '
            'btnAccountFind01
            '
            Me.btnAccountFind01.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind01.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind01.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind01.Location = New System.Drawing.Point(324, 50)
            Me.btnAccountFind01.Name = "btnAccountFind01"
            Me.btnAccountFind01.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind01.TabIndex = 27
            Me.btnAccountFind01.TabStop = False
            Me.btnAccountFind01.ThemedImage = CType(resources.GetObject("btnAccountFind01.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit01
            '
            Me.btnAccountEdit01.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit01.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit01.Location = New System.Drawing.Point(348, 50)
            Me.btnAccountEdit01.Name = "btnAccountEdit01"
            Me.btnAccountEdit01.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit01.TabIndex = 23
            Me.btnAccountEdit01.TabStop = False
            Me.btnAccountEdit01.ThemedImage = CType(resources.GetObject("btnAccountEdit01.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind02
            '
            Me.btnAccountFind02.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind02.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind02.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind02.Location = New System.Drawing.Point(324, 80)
            Me.btnAccountFind02.Name = "btnAccountFind02"
            Me.btnAccountFind02.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind02.TabIndex = 31
            Me.btnAccountFind02.TabStop = False
            Me.btnAccountFind02.ThemedImage = CType(resources.GetObject("btnAccountFind02.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit02
            '
            Me.btnAccountEdit02.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit02.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit02.Location = New System.Drawing.Point(348, 80)
            Me.btnAccountEdit02.Name = "btnAccountEdit02"
            Me.btnAccountEdit02.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit02.TabIndex = 28
            Me.btnAccountEdit02.TabStop = False
            Me.btnAccountEdit02.ThemedImage = CType(resources.GetObject("btnAccountEdit02.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind03
            '
            Me.btnAccountFind03.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind03.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind03.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind03.Location = New System.Drawing.Point(324, 110)
            Me.btnAccountFind03.Name = "btnAccountFind03"
            Me.btnAccountFind03.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind03.TabIndex = 35
            Me.btnAccountFind03.TabStop = False
            Me.btnAccountFind03.ThemedImage = CType(resources.GetObject("btnAccountFind03.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit03
            '
            Me.btnAccountEdit03.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit03.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit03.Location = New System.Drawing.Point(348, 110)
            Me.btnAccountEdit03.Name = "btnAccountEdit03"
            Me.btnAccountEdit03.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit03.TabIndex = 32
            Me.btnAccountEdit03.TabStop = False
            Me.btnAccountEdit03.ThemedImage = CType(resources.GetObject("btnAccountEdit03.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind04
            '
            Me.btnAccountFind04.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind04.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind04.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind04.Location = New System.Drawing.Point(324, 141)
            Me.btnAccountFind04.Name = "btnAccountFind04"
            Me.btnAccountFind04.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind04.TabIndex = 39
            Me.btnAccountFind04.TabStop = False
            Me.btnAccountFind04.ThemedImage = CType(resources.GetObject("btnAccountFind04.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit04
            '
            Me.btnAccountEdit04.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit04.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit04.Location = New System.Drawing.Point(348, 141)
            Me.btnAccountEdit04.Name = "btnAccountEdit04"
            Me.btnAccountEdit04.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit04.TabIndex = 36
            Me.btnAccountEdit04.TabStop = False
            Me.btnAccountEdit04.ThemedImage = CType(resources.GetObject("btnAccountEdit04.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind05
            '
            Me.btnAccountFind05.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind05.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind05.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind05.Location = New System.Drawing.Point(324, 170)
            Me.btnAccountFind05.Name = "btnAccountFind05"
            Me.btnAccountFind05.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind05.TabIndex = 43
            Me.btnAccountFind05.TabStop = False
            Me.btnAccountFind05.ThemedImage = CType(resources.GetObject("btnAccountFind05.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit05
            '
            Me.btnAccountEdit05.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit05.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit05.Location = New System.Drawing.Point(348, 170)
            Me.btnAccountEdit05.Name = "btnAccountEdit05"
            Me.btnAccountEdit05.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit05.TabIndex = 40
            Me.btnAccountEdit05.TabStop = False
            Me.btnAccountEdit05.ThemedImage = CType(resources.GetObject("btnAccountEdit05.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind06
            '
            Me.btnAccountFind06.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind06.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind06.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind06.Location = New System.Drawing.Point(324, 200)
            Me.btnAccountFind06.Name = "btnAccountFind06"
            Me.btnAccountFind06.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind06.TabIndex = 47
            Me.btnAccountFind06.TabStop = False
            Me.btnAccountFind06.ThemedImage = CType(resources.GetObject("btnAccountFind06.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit06
            '
            Me.btnAccountEdit06.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit06.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit06.Location = New System.Drawing.Point(348, 200)
            Me.btnAccountEdit06.Name = "btnAccountEdit06"
            Me.btnAccountEdit06.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit06.TabIndex = 44
            Me.btnAccountEdit06.TabStop = False
            Me.btnAccountEdit06.ThemedImage = CType(resources.GetObject("btnAccountEdit06.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind07
            '
            Me.btnAccountFind07.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind07.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind07.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind07.Location = New System.Drawing.Point(324, 230)
            Me.btnAccountFind07.Name = "btnAccountFind07"
            Me.btnAccountFind07.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind07.TabIndex = 51
            Me.btnAccountFind07.TabStop = False
            Me.btnAccountFind07.ThemedImage = CType(resources.GetObject("btnAccountFind07.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit07
            '
            Me.btnAccountEdit07.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit07.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit07.Location = New System.Drawing.Point(348, 230)
            Me.btnAccountEdit07.Name = "btnAccountEdit07"
            Me.btnAccountEdit07.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit07.TabIndex = 48
            Me.btnAccountEdit07.TabStop = False
            Me.btnAccountEdit07.ThemedImage = CType(resources.GetObject("btnAccountEdit07.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind08
            '
            Me.btnAccountFind08.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind08.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind08.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind08.Location = New System.Drawing.Point(324, 23)
            Me.btnAccountFind08.Name = "btnAccountFind08"
            Me.btnAccountFind08.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind08.TabIndex = 56
            Me.btnAccountFind08.TabStop = False
            Me.btnAccountFind08.ThemedImage = CType(resources.GetObject("btnAccountFind08.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountEdit08
            '
            Me.btnAccountEdit08.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit08.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit08.Location = New System.Drawing.Point(348, 23)
            Me.btnAccountEdit08.Name = "btnAccountEdit08"
            Me.btnAccountEdit08.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit08.TabIndex = 53
            Me.btnAccountEdit08.TabStop = False
            Me.btnAccountEdit08.ThemedImage = CType(resources.GetObject("btnAccountEdit08.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountName08
            '
            Me.Validator.SetDataType(Me.txtAccountName08, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName08, "")
            Me.txtAccountName08.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName08, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName08, System.Drawing.Color.Empty)
            Me.txtAccountName08.Location = New System.Drawing.Point(204, 24)
            Me.Validator.SetMinValue(Me.txtAccountName08, "")
            Me.txtAccountName08.Name = "txtAccountName08"
            Me.txtAccountName08.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName08, "")
            Me.Validator.SetRequired(Me.txtAccountName08, False)
            Me.txtAccountName08.Size = New System.Drawing.Size(120, 21)
            Me.txtAccountName08.TabIndex = 55
            Me.txtAccountName08.TabStop = False
            '
            'txtAccountCode08
            '
            Me.Validator.SetDataType(Me.txtAccountCode08, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCode08, "")
            Me.txtAccountCode08.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCode08, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCode08, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCode08, System.Drawing.Color.Empty)
            Me.txtAccountCode08.Location = New System.Drawing.Point(124, 24)
            Me.txtAccountCode08.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtAccountCode08, "")
            Me.txtAccountCode08.Name = "txtAccountCode08"
            Me.Validator.SetRegularExpression(Me.txtAccountCode08, "")
            Me.Validator.SetRequired(Me.txtAccountCode08, True)
            Me.txtAccountCode08.Size = New System.Drawing.Size(80, 21)
            Me.txtAccountCode08.TabIndex = 54
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(40, 28)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(44, 13)
            Me.Label8.TabIndex = 52
            Me.Label8.Text = "¿.ß.¥.1"
            '
            'WHTConfigurationView
            '
            Me.Controls.Add(Me.btnAccountFind08)
            Me.Controls.Add(Me.btnAccountEdit08)
            Me.Controls.Add(Me.txtAccountName08)
            Me.Controls.Add(Me.txtAccountCode08)
            Me.Controls.Add(Me.Label8)
            Me.Controls.Add(Me.btnAccountFind07)
            Me.Controls.Add(Me.btnAccountEdit07)
            Me.Controls.Add(Me.txtAccountName07)
            Me.Controls.Add(Me.txtAccountCode07)
            Me.Controls.Add(Me.btnAccountFind06)
            Me.Controls.Add(Me.btnAccountEdit06)
            Me.Controls.Add(Me.txtAccountName06)
            Me.Controls.Add(Me.txtAccountCode06)
            Me.Controls.Add(Me.btnAccountFind05)
            Me.Controls.Add(Me.btnAccountEdit05)
            Me.Controls.Add(Me.txtAccountName05)
            Me.Controls.Add(Me.txtAccountCode05)
            Me.Controls.Add(Me.btnAccountFind04)
            Me.Controls.Add(Me.btnAccountEdit04)
            Me.Controls.Add(Me.txtAccountName04)
            Me.Controls.Add(Me.txtAccountCode04)
            Me.Controls.Add(Me.btnAccountFind03)
            Me.Controls.Add(Me.btnAccountEdit03)
            Me.Controls.Add(Me.txtAccountName03)
            Me.Controls.Add(Me.txtAccountCode03)
            Me.Controls.Add(Me.btnAccountFind02)
            Me.Controls.Add(Me.btnAccountEdit02)
            Me.Controls.Add(Me.txtAccountName02)
            Me.Controls.Add(Me.txtAccountCode02)
            Me.Controls.Add(Me.btnAccountFind01)
            Me.Controls.Add(Me.btnAccountEdit01)
            Me.Controls.Add(Me.txtAccountName01)
            Me.Controls.Add(Me.txtAccountCode01)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "WHTConfigurationView"
            Me.Size = New System.Drawing.Size(472, 312)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

#Region "Members"
    Private m_isInitialized As Boolean
        Public ConfigFilters(7) As Filter
    Private Dirty As Boolean
    Private WHTAcc01 As New Account
    Private WHTAcc02 As New Account
    Private WHTAcc03 As New Account
    Private WHTAcc04 As New Account
    Private WHTAcc05 As New Account
    Private WHTAcc06 As New Account
        Private WHTAcc07 As New Account
        Private WHTAcc08 As New Account
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()

      'Check Module
            CheckModuleActivation()
    End Sub
#End Region

#Region "CheckPJMModule"
    Private m_ApproveDocModule As New PJMModule("approvedoc")
    ReadOnly Property Activated() As Boolean
      Get
        Return m_ApproveDocModule.Activated
      End Get
    End Property
    Public Sub CheckModuleActivation()
      If Not Me.Activated Then
        'Me.lblMaxLevelApprovePR.Visible = False
        'Me.lblMaxLevelApprovePO.Visible = False
        'Me.lblMaxLevelApproveDO.Visible = False

        'Me.nudMaxLevelApprovePR.Visible = False
        'Me.nudMaxLevelApprovePO.Visible = False
        'Me.nudMaxLevelApproveDO.Visible = False
      End If
    End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
    Public Sub CheckFormEnable()

    End Sub
    Public Sub ClearDetail()
    End Sub
    Public Sub SetLabelText()
    End Sub
    Protected Sub EventWiring()

      AddHandler txtAccountCode01.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAccountCode02.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAccountCode03.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAccountCode04.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAccountCode05.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAccountCode06.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAccountCode07.Validated, AddressOf Me.ChangeProperty
            AddHandler txtAccountCode08.Validated, AddressOf Me.ChangeProperty

      AddHandler btnAccountEdit01.Click, AddressOf Me.btnAccountEdit_Click
      AddHandler btnAccountFind01.Click, AddressOf Me.btnAccountFind_Click

      AddHandler btnAccountEdit02.Click, AddressOf Me.btnAccountEdit_Click
      AddHandler btnAccountFind02.Click, AddressOf Me.btnAccountFind_Click

      AddHandler btnAccountEdit03.Click, AddressOf Me.btnAccountEdit_Click
      AddHandler btnAccountFind03.Click, AddressOf Me.btnAccountFind_Click

      AddHandler btnAccountEdit04.Click, AddressOf Me.btnAccountEdit_Click
      AddHandler btnAccountFind04.Click, AddressOf Me.btnAccountFind_Click

      AddHandler btnAccountEdit05.Click, AddressOf Me.btnAccountEdit_Click
      AddHandler btnAccountFind05.Click, AddressOf Me.btnAccountFind_Click

      AddHandler btnAccountEdit06.Click, AddressOf Me.btnAccountEdit_Click
      AddHandler btnAccountFind06.Click, AddressOf Me.btnAccountFind_Click

      AddHandler btnAccountEdit07.Click, AddressOf Me.btnAccountEdit_Click
      AddHandler btnAccountFind07.Click, AddressOf Me.btnAccountFind_Click

            AddHandler btnAccountEdit08.Click, AddressOf Me.btnAccountEdit_Click
            AddHandler btnAccountFind08.Click, AddressOf Me.btnAccountFind_Click

    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      '-----
      Select Case CType(sender, Control).Name.ToLower
        Case "txtaccountcode01"
          dirtyFlag = Account.GetAccount(txtAccountCode01, txtAccountName01, WHTAcc01)
        Case "txtaccountcode02"
          dirtyFlag = Account.GetAccount(txtAccountCode02, txtAccountName01, WHTAcc02)
        Case "txtaccountcode03"
          dirtyFlag = Account.GetAccount(txtAccountCode03, txtAccountName01, WHTAcc03)
        Case "txtaccountcode04"
          dirtyFlag = Account.GetAccount(txtAccountCode04, txtAccountName01, WHTAcc04)
        Case "txtaccountcode05"
          dirtyFlag = Account.GetAccount(txtAccountCode05, txtAccountName01, WHTAcc05)
        Case "txtaccountcode06"
          dirtyFlag = Account.GetAccount(txtAccountCode06, txtAccountName01, WHTAcc06)
        Case "txtaccountcode07"
          dirtyFlag = Account.GetAccount(txtAccountCode07, txtAccountName01, WHTAcc07)
      End Select
      '-----
      Dirty = Dirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub Initialize()
      ConfigFilters(0) = New Filter("WHTAcc01", Configuration.GetConfig("WHTAcc01"))
      ConfigFilters(1) = New Filter("WHTAcc02", Configuration.GetConfig("WHTAcc02"))
      ConfigFilters(2) = New Filter("WHTAcc03", Configuration.GetConfig("WHTAcc03"))
      ConfigFilters(3) = New Filter("WHTAcc04", Configuration.GetConfig("WHTAcc04"))
      ConfigFilters(4) = New Filter("WHTAcc05", Configuration.GetConfig("WHTAcc05"))
      ConfigFilters(5) = New Filter("WHTAcc06", Configuration.GetConfig("WHTAcc06"))
      ConfigFilters(6) = New Filter("WHTAcc07", Configuration.GetConfig("WHTAcc07"))
    End Sub
    Private Sub SetFilterValue(ByVal name As String, ByVal value As Object)
      For Each filter As Filter In ConfigFilters
        If filter.Name.ToLower = name.ToLower Then
          filter.Value = value
          Exit For
        End If
      Next
    End Sub
    Private Function GetFilterValue(ByVal name As String) As Object
      For Each filter As Filter In ConfigFilters
        If filter.Name.ToLower = name.ToLower Then
          Return filter.Value
        End If
      Next
    End Function
#End Region

#Region "Methods"
#End Region

#Region "Event Handers"
    Private Sender As String = ""
    Private Sub ibtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnAccountEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles btnAccountEdit01.Click
      'sender = CType(sender, Control).Name.ToLower
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Account)
    End Sub
    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles btnAccountFind01.Click
      Me.Sender = CType(sender, Control).Name.ToLower
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountDialog)
    End Sub
    Private Sub SetAccountDialog(ByVal e As ISimpleEntity)
      Select Case Me.Sender
        Case "btnaccountfind01"
          Me.txtAccountCode01.Text = e.Code
          Me.Dirty = Account.GetAccount(txtAccountCode01, txtAccountName01, WHTAcc01)
          If Dirty Then
            ConfigFilters(0).Value = WHTAcc01.Code
          End If
        Case "btnaccountfind02"
          Me.txtAccountCode02.Text = e.Code
          Me.Dirty = Account.GetAccount(txtAccountCode02, txtAccountName02, WHTAcc02)
          If Dirty Then
            ConfigFilters(1).Value = WHTAcc02.Code
          End If
        Case "btnaccountfind03"
          Me.txtAccountCode03.Text = e.Code
          Me.Dirty = Account.GetAccount(txtAccountCode03, txtAccountName03, WHTAcc03)
          If Dirty Then
            ConfigFilters(2).Value = WHTAcc03.Code
          End If
        Case "btnaccountfind04"
          Me.txtAccountCode04.Text = e.Code
          Me.Dirty = Account.GetAccount(txtAccountCode04, txtAccountName04, WHTAcc04)
          If Dirty Then
            ConfigFilters(3).Value = WHTAcc04.Code
          End If
        Case "btnaccountfind05"
          Me.txtAccountCode05.Text = e.Code
          Me.Dirty = Account.GetAccount(txtAccountCode05, txtAccountName05, WHTAcc05)
          If Dirty Then
            ConfigFilters(4).Value = WHTAcc05.Code
          End If
        Case "btnaccountfind06"
          Me.txtAccountCode06.Text = e.Code
          Me.Dirty = Account.GetAccount(txtAccountCode06, txtAccountName06, WHTAcc06)
          If Dirty Then
            ConfigFilters(5).Value = WHTAcc06.Code
          End If
        Case "btnaccountfind07"
          Me.txtAccountCode07.Text = e.Code
          Me.Dirty = Account.GetAccount(txtAccountCode07, txtAccountName07, WHTAcc07)
          If Dirty Then
            ConfigFilters(6).Value = WHTAcc07.Code
                    End If
                Case "btnaccountfind08"
                    Me.txtAccountCode08.Text = e.Code
                    Me.Dirty = Account.GetAccount(txtAccountCode08, txtAccountName08, WHTAcc08)
                    If Dirty Then
                        ConfigFilters(7).Value = WHTAcc08.Code
                    End If

            End Select
    End Sub
#End Region

#Region "Overrides"
    Public Overloads Overrides Sub LoadPanelContents()
      m_isInitialized = False
      ClearDetail()

      If IsDBNull(GetFilterValue("WHTAcc01")) Then
        txtAccountCode01.Text = ""
      Else
        WHTAcc01 = New Account(CStr(GetFilterValue("WHTAcc01")))
        txtAccountCode01.Text = WHTAcc01.Code
        txtAccountName01.Text = WHTAcc01.Name
      End If

      If IsDBNull(GetFilterValue("WHTAcc02")) Then
        txtAccountCode02.Text = ""
      Else
        WHTAcc02 = New Account(CStr(GetFilterValue("WHTAcc02")))
        txtAccountCode02.Text = WHTAcc02.Code
        txtAccountName02.Text = WHTAcc02.Name
      End If

      If IsDBNull(GetFilterValue("WHTAcc03")) Then
        txtAccountCode03.Text = ""
      Else
        WHTAcc03 = New Account(CStr(GetFilterValue("WHTAcc03")))
        txtAccountCode03.Text = WHTAcc03.Code
        txtAccountName03.Text = WHTAcc03.Name
      End If

      If IsDBNull(GetFilterValue("WHTAcc04")) Then
        txtAccountCode04.Text = ""
      Else
        WHTAcc04 = New Account(CStr(GetFilterValue("WHTAcc04")))
        txtAccountCode04.Text = WHTAcc04.Code
        txtAccountName04.Text = WHTAcc04.Name
      End If

      If IsDBNull(GetFilterValue("WHTAcc05")) Then
        txtAccountCode05.Text = ""
      Else
        WHTAcc05 = New Account(CStr(GetFilterValue("WHTAcc05")))
        txtAccountCode05.Text = WHTAcc05.Code
        txtAccountName05.Text = WHTAcc05.Name
      End If

      If IsDBNull(GetFilterValue("WHTAcc06")) Then
        txtAccountCode06.Text = ""
      Else
        WHTAcc06 = New Account(CStr(GetFilterValue("WHTAcc06")))
        txtAccountCode06.Text = WHTAcc06.Code
        txtAccountName06.Text = WHTAcc06.Name
      End If

      If IsDBNull(GetFilterValue("WHTAcc07")) Then
        txtAccountCode07.Text = ""
      Else
        WHTAcc07 = New Account(CStr(GetFilterValue("WHTAcc07")))
        txtAccountCode07.Text = WHTAcc07.Code
        txtAccountName07.Text = WHTAcc07.Name
      End If

            If IsDBNull(GetFilterValue("WHTAcc08")) Then
                txtAccountCode08.Text = ""
            Else
                WHTAcc08 = New Account(CStr(GetFilterValue("WHTAcc08")))
                txtAccountCode08.Text = WHTAcc08.Code
                txtAccountName08.Text = WHTAcc08.Name
            End If


            SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Public Overloads Overrides Function StorePanelContents() As Boolean
      If Not m_isInitialized Then
        Return True
      End If
      If Not Dirty Then
        Return True
      End If
      Configuration.Save(Me.ConfigFilters)
      Return True
    End Function
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region
  End Class
End Namespace