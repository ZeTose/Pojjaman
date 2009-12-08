Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing.Printing
Namespace Longkong.Reporting.Printing
    <DefaultProperty("Document"), DefaultEvent("Printing")> _
    Public Class PrintControl
        Inherits UserControl

#Region "Events"
        Public Event Printed As EventHandler
        Public Event Printing As EventHandler
#End Region

#Region "Members"
        Private btnCancel As Button
        Private btnOK As Button
        Private btnPageSetup As Button
        Private btnPreview As Button
        Private toolTip1 As ToolTip
        Private components As IContainer

        Private m_hideOnPrint As Boolean
        Private printLogic1 As PrintLogic
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_hideOnPrint = True
            Me.InitializeComponent()
        End Sub
#End Region

#Region "Properties"
        <Description("Gets or sets the PrintDocument used by the dialog.")> _
        Public Property Document() As PrintDocument
            Get
                Return Me.printLogic1.Document
            End Get
            Set(ByVal value As PrintDocument)
                Me.printLogic1.Document = value
            End Set
        End Property
        <DefaultValue(False), Description("Indicates that the parent of this control will be hidden when Print is clicked.")> _
        Public Property HideOnPrint() As Boolean
            Get
                Return Me.m_hideOnPrint
            End Get
            Set(ByVal value As Boolean)
                Me.m_hideOnPrint = value
            End Set
        End Property
        <DefaultValue(False), Description("Indicates that printing should be done in the background.")> _
        Public Property PrintInBackground() As Boolean
            Get
                Return Me.printLogic1.PrintInBackground
            End Get
            Set(ByVal value As Boolean)
                Me.printLogic1.PrintInBackground = value
            End Set
        End Property
        <Browsable(False)> _
        Public ReadOnly Property PrintInProgress() As Boolean
            Get
                Return Me.printLogic1.PrintInProgress
            End Get
        End Property
        <DefaultValue(True), Description("The progress of the print job is shown in a status dialog.")> _
        Public Property ShowStatusDialog() As Boolean
            Get
                Return Me.printLogic1.ShowStatusDialog
            End Get
            Set(ByVal value As Boolean)
                Me.printLogic1.ShowStatusDialog = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overridable Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_hideOnPrint Then
                MyBase.ParentForm.Hide()
            End If
        End Sub
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.components Is Nothing)) Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
        Private Sub InitializeComponent()
            Me.components = New Container
            Me.btnPreview = New Button
            Me.printLogic1 = New PrintLogic
            Me.btnCancel = New Button
            Me.btnOK = New Button
            Me.btnPageSetup = New Button
            Me.toolTip1 = New ToolTip(Me.components)
            MyBase.SuspendLayout()
            Me.btnPreview.Location = New Point(112, 8)
            Me.btnPreview.Name = "btnPreview"
            Me.btnPreview.TabIndex = 1
            Me.btnPreview.Text = "Pre&view"
            AddHandler Me.btnPreview.Click, New EventHandler(AddressOf Me.Preview)
            Me.toolTip1.SetToolTip(Me.btnPreview, "Preivew the print job.")
            Me.printLogic1.Document = Nothing
            Me.printLogic1.PrintInBackground = False
            AddHandler Me.printLogic1.Printing, New EventHandler(AddressOf Me.printLogic1_Printing)
            AddHandler Me.printLogic1.Printed, New EventHandler(AddressOf Me.printLogic1_Printed)
            Me.btnCancel.DialogResult = DialogResult.Cancel
            Me.btnCancel.Location = New Point(304, 8)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.TabIndex = 3
            Me.btnCancel.Text = "&Cancel"
            Me.toolTip1.SetToolTip(Me.btnCancel, "Quit this dialog without printing.")
            AddHandler Me.btnCancel.Click, New EventHandler(AddressOf Me.btnCancel_Click)
            Me.btnOK.DialogResult = DialogResult.OK
            Me.btnOK.Location = New Point(208, 8)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "&Print"
            AddHandler Me.btnOK.Click, New EventHandler(AddressOf Me.Print)
            Me.toolTip1.SetToolTip(Me.btnOK, "Print the selected document.")
            Me.btnPageSetup.Location = New Point(8, 8)
            Me.btnPageSetup.Name = "btnPageSetup"
            Me.btnPageSetup.Size = New Size(88, 23)
            Me.btnPageSetup.TabIndex = 0
            Me.btnPageSetup.Text = "Page &Setup"
            AddHandler Me.btnPageSetup.Click, New EventHandler(AddressOf Me.PageSetup)
            Me.toolTip1.SetToolTip(Me.btnPageSetup, "Setup page and printer settings.")
            Dim controlArray1 As Control() = New Control() {Me.btnPreview, Me.btnCancel, Me.btnOK, Me.btnPageSetup}
            MyBase.Controls.AddRange(controlArray1)
            MyBase.Name = "PrintControl"
            MyBase.Size = New Size(384, 40)
            MyBase.ResumeLayout(False)
        End Sub
        Public Sub PageSetup(ByVal sender As Object, ByVal e As EventArgs)
            Me.printLogic1.PageSetup(sender, e)
        End Sub
        Public Sub Preview(ByVal sender As Object, ByVal e As EventArgs)
            Me.printLogic1.Preview(sender, e)
        End Sub
        Public Overridable Sub Print(ByVal sender As Object, ByVal e As EventArgs)
            Me.printLogic1.Print(sender, e)
        End Sub
        Private Sub printLogic1_Printed(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent Printed(sender, e)
        End Sub
        Private Sub printLogic1_Printing(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent Printing(sender, e)
        End Sub
#End Region

    End Class

End Namespace