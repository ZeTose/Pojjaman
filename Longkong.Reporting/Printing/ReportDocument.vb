Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Namespace Longkong.Reporting.Printing
    Public Class ReportDocument
        Inherits PrintDocument

#Region "Members"
        Private m_body As ReportSection
        Private m_components As Container
        Private m_currentPage As Integer
        Private m_documentUnit As GraphicsUnit
        Private m_normalPen As Pen
        Private m_pageFooter As ReportSection
        Private m_pageFooterMaxHeight As Single
        Private m_pageHeader As ReportSection
        Private m_pageHeaderMaxHeight As Single
        Private m_pageOrientations As Hashtable
        Private m_reportMaker As IReportMaker
        Private m_resetAfterPrint As Boolean
        Private m_thickPen As Pen
        Private m_thinPen As Pen
        Private m_totalPages As Integer
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_components = Nothing
            Me.InitializeComponent()
            Me.m_resetAfterPrint = True
            Me.DocumentUnit = GraphicsUnit.Inch
            Me.ResetPens()
        End Sub
#End Region

#Region "Properties"
        <Browsable(False)> _
        Public Property Body() As ReportSection
            Get
                Return Me.m_body
            End Get
            Set(ByVal value As ReportSection)
                Me.m_body = value
            End Set
        End Property
        <DefaultValue(4)> _
        Public Overridable Property DocumentUnit() As GraphicsUnit
            Get
                Return Me.m_documentUnit
            End Get
            Set(ByVal value As GraphicsUnit)
                Me.m_documentUnit = value
                Me.ResetPens()
            End Set
        End Property
        <Browsable(False)> _
        Public ReadOnly Property NormalPen() As Pen
            Get
                Return Me.m_normalPen
            End Get
        End Property
        <Browsable(False)> _
        Public Property PageFooter() As ReportSection
            Get
                Return Me.m_pageFooter
            End Get
            Set(ByVal value As ReportSection)
                Me.m_pageFooter = value
            End Set
        End Property
        <Description("The maximum height allowed for the page footer."), DefaultValue(CType(0.0!, Single))> _
        Public Property PageFooterMaxHeight() As Single
            Get
                Return Me.m_pageFooterMaxHeight
            End Get
            Set(ByVal value As Single)
                Me.m_pageFooterMaxHeight = value
            End Set
        End Property
        <Browsable(False)> _
        Public Property PageHeader() As ReportSection
            Get
                Return Me.m_pageHeader
            End Get
            Set(ByVal value As ReportSection)
                Me.m_pageHeader = value
            End Set
        End Property
        <Description("The maximum height allowed for the page header."), DefaultValue(CType(0.0!, Single))> _
        Public Property PageHeaderMaxHeight() As Single
            Get
                Return Me.m_pageHeaderMaxHeight
            End Get
            Set(ByVal value As Single)
                Me.m_pageHeaderMaxHeight = value
            End Set
        End Property
        <DefaultValue(CType(Nothing, String))> _
        Public Property ReportMaker() As IReportMaker
            Get
                Return Me.m_reportMaker
            End Get
            Set(ByVal value As IReportMaker)
                Me.m_reportMaker = value
            End Set
        End Property
        <DefaultValue(True)> _
        Public Property ResetAfterPrint() As Boolean
            Get
                Return Me.m_resetAfterPrint
            End Get
            Set(ByVal value As Boolean)
                Me.m_resetAfterPrint = value
            End Set
        End Property
        <Browsable(False)> _
        Public ReadOnly Property ThickPen() As Pen
            Get
                Return Me.m_thickPen
            End Get
        End Property
        <Browsable(False)> _
        Public ReadOnly Property ThinPen() As Pen
            Get
                Return Me.m_thinPen
            End Get
        End Property
        <Browsable(False)> _
        Public ReadOnly Property TotalPages() As Integer
            Get
                Return Me.m_totalPages
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overridable Sub ClearPageOrientation(ByVal page As Integer)
            If Me.m_pageOrientations.ContainsKey(page) Then
                Me.m_pageOrientations.Remove(page)
            End If
        End Sub
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.m_components Is Nothing)) Then
                Me.m_components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
        <Browsable(False)> _
        Public Function GetCurrentPage() As Integer
            Return Me.m_currentPage
        End Function
        Public Overridable Function GetScale() As Single
            Dim single1 As Single = 1.0!
            Select Case Me.DocumentUnit
                Case GraphicsUnit.Display
                    Return 75.0!
                Case GraphicsUnit.Point
                    Return 72.0!
                Case GraphicsUnit.Inch
                    Return 1.0!
                Case GraphicsUnit.Document
                    Return 300.0!
                Case GraphicsUnit.Millimeter
                    Return 25.4!
            End Select
            Throw New ApplicationException(("GraphicsUnit not supported: " & Me.DocumentUnit))
        End Function
        Private Sub InitializeComponent()
            Me.m_components = New Container
        End Sub
        Protected Overrides Sub OnBeginPrint(ByVal e As PrintEventArgs)
            Me.m_totalPages = 0
            Me.Reset()
        End Sub
        Protected Overrides Sub OnEndPrint(ByVal e As PrintEventArgs)
            If Me.ResetAfterPrint Then
                Me.PageHeader = Nothing
                Me.PageFooter = Nothing
                Me.Body = Nothing
                Me.PageHeaderMaxHeight = 0.0!
                Me.PageFooterMaxHeight = 0.0!
                Me.DocumentUnit = GraphicsUnit.Inch
            End If
        End Sub
        Protected Overrides Sub OnPrintPage(ByVal e As PrintPageEventArgs)
            Me.m_currentPage += 1
            Me.PrintAPage(e, False)
            Me.SetOrientation(e, (Me.m_currentPage + 1))
        End Sub
        Protected Overridable Function PrintAPage(ByVal e As PrintPageEventArgs, ByVal sizeOnly As Boolean) As Boolean
            Dim graphics1 As Graphics = e.Graphics
            graphics1.PageUnit = Me.DocumentUnit
            Dim single1 As Single = (Me.GetScale / 100.0!)
            Dim ptr1 As IntPtr = e.Graphics.GetHdc
            Dim info1 As New PrinterMarginInfo(ptr1.ToInt32)
            e.Graphics.ReleaseHdc(ptr1)
            Dim bounds1 As Bounds = info1.GetBounds(e.PageBounds, e.MarginBounds, single1)
            If (Not Me.PageHeader Is Nothing) Then
                Dim bounds2 As Bounds = bounds1
                If (Me.PageHeaderMaxHeight > 0.0!) Then
                    bounds2.Limit.Y = (bounds2.Position.Y + Me.PageHeaderMaxHeight)
                End If
                Me.PageHeader.Print(Me, graphics1, bounds2)
                bounds1.Position.Y = (bounds1.Position.Y + Me.PageHeader.Size.Height)
            End If
            If (Not Me.PageFooter Is Nothing) Then
                Dim bounds3 As Bounds = bounds1
                If (Me.PageFooterMaxHeight > 0.0!) Then
                    bounds3.Position.Y = (bounds3.Limit.Y - Me.PageFooterMaxHeight)
                End If
                Me.PageFooter.CalcSize(Me, graphics1, bounds3)
                bounds3 = bounds3.GetBounds(Me.PageFooter.Size, Me.PageFooter.HorizontalAlignment, Me.PageFooter.VerticalAlignment)
                Me.PageFooter.Print(Me, graphics1, bounds3)
                bounds1.Limit.Y = (bounds1.Limit.Y - Me.PageFooter.Size.Height)
            End If
            If (Not Me.Body Is Nothing) Then
                Me.Body.Print(Me, graphics1, bounds1)
                e.HasMorePages = Me.Body.Continued
            Else
                e.HasMorePages = False
            End If
            Return e.HasMorePages
        End Function
        Private Sub Reset()
            Me.m_pageOrientations = New Hashtable
            If (Not Me.ReportMaker Is Nothing) Then
                Me.ReportMaker.MakeDocument(Me)
            End If
            If (Not Me.Body Is Nothing) Then
                Me.Body.Reset()
            End If
            If (Not Me.PageFooter Is Nothing) Then
                Me.PageFooter.Reset()
            End If
            If (Not Me.PageHeader Is Nothing) Then
                Me.PageHeader.Reset()
            End If
            Me.m_currentPage = 0
        End Sub
        Public Overridable Sub ResetPens()
            Dim single1 As Single = Me.GetScale
            Me.m_thinPen = New Pen(Color.Black, (0.01! * single1))
            Me.m_normalPen = New Pen(Color.Black, (0.03! * single1))
            Me.m_thickPen = New Pen(Color.Black, (0.08! * single1))
        End Sub
        Protected Overridable Sub SetOrientation(ByVal e As PrintPageEventArgs, ByVal page As Integer)
            If Me.m_pageOrientations.ContainsKey(page) Then
                Select Case CType(Me.m_pageOrientations.Item(page), PageOrientation)
                    Case PageOrientation.Portrait
                        e.PageSettings.Landscape = False
                        Return
                    Case PageOrientation.Landscape
                        e.PageSettings.Landscape = True
                        Return
                End Select
            End If
        End Sub
        Public Overridable Sub SetPageOrientation(ByVal page As Integer, ByVal orient As PageOrientation)
            Me.m_pageOrientations(page) = orient
        End Sub
#End Region

    End Class
End Namespace