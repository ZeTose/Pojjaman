Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.ComponentModel
Namespace Longkong.Pojjaman.Gui.Components
    ' <summary>
    ' A System.Windows.Forms.Button that can have an image on systems that support visual styles.
    ' Uses the BCM_SETIMAGE message that is provided by comctl32.dll, version 6.
    ' On systems that have a lower version of comctl32.dll, i.e. earlier than Windows XP,
    ' falls back to FlatStyle.Standard.
    ' </summary>
    Public Class ImageButton
        Inherits Button

        Public Sub New()
            FlatStyle = FlatStyle.System
        End Sub

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure RECT
            Public left As Integer
            Public top As Integer
            Public right As Integer
            Public bottom As Integer
        End Structure

        Public Enum Alignment
            Left
            Right
            Top
            Bottom
            Center
        End Enum
        Private Const BCM_SETIMAGELIST As Integer = 5632 + 2

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure BUTTON_IMAGELIST
            Public himl As IntPtr
            Public margin As RECT
            Public uAlign As Integer
        End Structure

        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByRef lParam As BUTTON_IMAGELIST) As Integer
        End Function

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure DLLVERSIONINFO
            Public cbSize As Integer
            Public dwMajorVersion As Integer
            Public dwMinorVersion As Integer
            Public dwBuildNumber As Integer
            Public dwPlatformID As Integer
        End Structure

        <DllImport("comctl32.dll", EntryPoint:="DllGetVersion")> _
        Private Shared Function GetCommonControlDLLVersion(ByRef dvi As DLLVERSIONINFO) As Integer
        End Function
        Private ComCtlMajorVersion As Integer = -1
        Private m_themedImage As Bitmap

        <Description("The image on the face of the button."), Category("Appearance"), DefaultValue("")> _
        Public Property ThemedImage() As Bitmap
            Get
                Return m_themedImage
            End Get
            Set(ByVal Value As Bitmap)
                If Not (Value Is Nothing) Then
                    SetImage(Value)
                End If
                m_themedImage = Value
            End Set
        End Property

        Public Sub SetImage(ByVal image As Bitmap)
            Dim align As Alignment
            Select Case Me.ImageAlign
                Case ContentAlignment.BottomCenter
                    align = Alignment.Bottom
                Case ContentAlignment.TopCenter
                    align = Alignment.Top
                Case ContentAlignment.BottomLeft, ContentAlignment.MiddleLeft, ContentAlignment.TopLeft
                    align = Alignment.Left
                Case ContentAlignment.BottomRight, ContentAlignment.MiddleRight, ContentAlignment.TopRight
                    align = Alignment.Right
                Case Else
                    align = Alignment.Center
            End Select
            SetImage(New Bitmap() {image}, align, 4, 0, 0, 0)
        End Sub

        Public Sub SetImage(ByVal image As Bitmap, ByVal align As Alignment)
            SetImage(New Bitmap() {image}, align, 0, 0, 0, 0)
        End Sub

        Public Sub SetImage(ByVal image As Bitmap, ByVal align As Alignment, ByVal leftMargin As Integer, ByVal topMargin As Integer, ByVal rightMargin As Integer, ByVal bottomMargin As Integer)
            SetImage(New Bitmap() {image}, align, leftMargin, topMargin, rightMargin, bottomMargin)
        End Sub

        Public Sub SetImage(ByVal normalImage As Bitmap, ByVal hoverImage As Bitmap, ByVal pressedImage As Bitmap, ByVal disabledImage As Bitmap, ByVal focusedImage As Bitmap)
            SetImage(New Bitmap() {normalImage, hoverImage, pressedImage, disabledImage, focusedImage}, Alignment.Center, 0, 0, 0, 0)
        End Sub

        Public Sub SetImage(ByVal normalImage As Bitmap, ByVal hoverImage As Bitmap, ByVal pressedImage As Bitmap, ByVal disabledImage As Bitmap, ByVal focusedImage As Bitmap, ByVal align As Alignment)
            SetImage(New Bitmap() {normalImage, hoverImage, pressedImage, disabledImage, focusedImage}, align, 0, 0, 0, 0)
        End Sub

        Public Sub SetImage(ByVal normalImage As Bitmap, ByVal hoverImage As Bitmap, ByVal pressedImage As Bitmap, ByVal disabledImage As Bitmap, ByVal focusedImage As Bitmap, ByVal align As Alignment, ByVal leftMargin As Integer, ByVal topMargin As Integer, ByVal rightMargin As Integer, ByVal bottomMargin As Integer)
            SetImage(New Bitmap() {normalImage, hoverImage, pressedImage, disabledImage, focusedImage}, align, leftMargin, topMargin, rightMargin, bottomMargin)
        End Sub
        Private m_generateDisabledImage As Boolean = False

        <Description("Determines whether the image for the disabled state will be generated automatically from the normal one."), Category("Appearance"), DefaultValue(False)> _
             Public Property GenerateDisabledImage() As Boolean
            Get
                Return m_generateDisabledImage
            End Get
            Set(ByVal Value As Boolean)
                m_generateDisabledImage = Value
            End Set
        End Property

        <DllImport("UxTheme")> _
        Private Shared Function IsThemeActive() As Boolean
        End Function

        <DllImport("UxTheme")> _
        Private Shared Function IsAppThemed() As Boolean
        End Function

        Private Shared ReadOnly Property IsVisualStylesEnabled() As Boolean
            Get
                Return OSFeature.Feature.IsPresent(OSFeature.Themes) AndAlso IsAppThemed() AndAlso IsThemeActive()
            End Get
        End Property

        Public Sub SetImage(ByVal images As Bitmap(), ByVal align As Alignment, ByVal leftMargin As Integer, ByVal topMargin As Integer, ByVal rightMargin As Integer, ByVal bottomMargin As Integer)
            If GenerateDisabledImage Then
                If images.Length = 1 Then
                    Dim image As Bitmap = images(0)
                    images = New Bitmap() {image, image, image, image, image}
                End If
                images(3) = DrawImageDisabled(images(3))
            End If
            If ComCtlMajorVersion < 0 Then
                Dim dllVersion As DLLVERSIONINFO = New DLLVERSIONINFO
                dllVersion.cbSize = Marshal.SizeOf(GetType(DLLVERSIONINFO))
                GetCommonControlDLLVersion(dllVersion)
                ComCtlMajorVersion = dllVersion.dwMajorVersion
            End If
            If ComCtlMajorVersion >= 6 AndAlso FlatStyle = FlatStyle.System AndAlso IsVisualStylesEnabled Then
                Dim rect As rect = New rect
                rect.left = leftMargin
                rect.top = topMargin
                rect.right = rightMargin
                rect.bottom = bottomMargin
                Dim buttonImageList As BUTTON_IMAGELIST = New BUTTON_IMAGELIST
                buttonImageList.margin = rect
                buttonImageList.uAlign = CType(align, Integer)
                ImageList = GenerateImageList(images)
                buttonImageList.himl = ImageList.Handle
                SendMessage(Me.Handle, BCM_SETIMAGELIST, 0, buttonImageList)
            Else
                FlatStyle = FlatStyle.Standard
                If images.Length > 0 Then
                    image = images(0)
                End If
                Select Case align
                    Case Alignment.Bottom
                        ImageAlign = ContentAlignment.BottomCenter
                        ' break 
                    Case Alignment.Left
                        ImageAlign = ContentAlignment.MiddleLeft
                        ' break 
                    Case Alignment.Right
                        ImageAlign = ContentAlignment.MiddleRight
                        ' break 
                    Case Alignment.Top
                        ImageAlign = ContentAlignment.TopCenter
                        ' break 
                    Case Alignment.Center
                        ImageAlign = ContentAlignment.MiddleCenter
                        ' break 
                End Select
            End If
        End Sub

        Private Function DrawImageDisabled(ByVal image As System.Drawing.Image) As System.Drawing.Bitmap
            Dim active As System.Drawing.Bitmap = New Bitmap(image)
            Dim disable As System.Drawing.Bitmap = New Bitmap(active.Width, active.Height)
            Dim g As System.Drawing.Graphics = Graphics.FromImage(disable)
            g.DrawImage(active, 0, 0)
            ControlPaint.DrawImageDisabled(g, active, 0, 0, Color.Empty)
            g.Dispose()
            Return disable
        End Function

        Private Function GenerateImageList(ByVal images As Bitmap()) As ImageList
            Dim il As ImageList = New ImageList
            il.ColorDepth = ColorDepth.Depth32Bit
            If images.Length > 0 Then
                Dim i As Integer = 0
                While i < images.Length
                    Dim ReSizeHeight As Integer = Me.Height
                    Dim ReSizeWidth As Integer = Me.Width
                    If ReSizeHeight > 256 Then
                        ReSizeHeight = 256
                    End If
                    If ReSizeWidth > 256 Then
                        ReSizeWidth = 256
                    End If
                    If images(i).Width > ReSizeWidth OrElse images(i).Height > ReSizeHeight Then
                        Dim Scaling As Double
                        Dim WidthScaling As Double = ReSizeWidth / CType(images(i).Width, Double)
                        Dim HeightScaling As Double = ReSizeHeight / CType(images(i).Height, Double)
                        If WidthScaling < HeightScaling Then
                            Scaling = WidthScaling
                        Else
                            Scaling = HeightScaling
                        End If
                        Dim newWidth As Integer = CType((images(i).Width * Scaling), Integer)
                        Dim newHeight As Integer = CType((images(i).Height * Scaling), Integer)
                        Dim bm As Bitmap = New Bitmap(newWidth, newHeight)
                        Dim graphics As graphics = graphics.FromImage(bm)
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
                        graphics.DrawImage(images(i), 0, 0, newWidth, newHeight)
                        images(i) = bm
                    End If
                    System.Math.Min(System.Threading.Interlocked.Increment(i), i - 1)
                End While
                il.ImageSize = New Size(images(0).Width, images(0).Height)
                For Each image As Bitmap In images
                    il.Images.Add(image)
                    Dim bm As Bitmap = CType(il.Images(il.Images.Count - 1), Bitmap)
                    For x As Integer = 0 To bm.Width - 1
                        For y As Integer = 0 To bm.Height - 1
                            bm.SetPixel(x, y, image.GetPixel(x, y))
                        Next
                    Next
                    'Dim rc As Rectangle = New Rectangle(New Point(0, 0), image.Size)
                    'Dim src As BitmapData = image.LockBits(rc, ImageLockMode.ReadOnly, image.PixelFormat)
                    'Dim dst As BitmapData = bm.LockBits(rc, ImageLockMode.WriteOnly, image.PixelFormat)
                    'Try
                    '    Dim pSrc As Integer = src.Scan0.ToInt32
                    '    Dim pDst As Integer = dst.Scan0.ToInt32
                    '    Dim row As Integer = 0
                    '    While row < bm.Height
                    '        Dim col As Integer = 0
                    '        While col < bm.Width
                    '            pDst(col) = pSrc(col)
                    '            System.Math.Min(System.Threading.Interlocked.Increment(col), col - 1)
                    '        End While
                    '        pSrc += src.Stride >> 2
                    '        pDst += dst.Stride >> 2
                    '        System.Math.Min(System.Threading.Interlocked.Increment(row), row - 1)
                    '    End While
                    'Finally
                    '    bm.UnlockBits(dst)
                    '    image.UnlockBits(src)
                    'End Try
                Next
            End If
            Return il
        End Function
        Private m_dropDown As Boolean = False

        <Description("Determines whether a small dropdown arrow will painted."), Category("Appearance"), DefaultValue(False)> _
        Public Property DropDown() As Boolean
            Get
                Return m_dropDown
            End Get
            Set(ByVal Value As Boolean)
                m_dropDown = Value
            End Set
        End Property
        Public Const WM_PAINT As Integer = 15
        Public Const WM_ENABLE As Integer = 10

        Protected Overloads Overrides Sub WndProc(ByRef m As Message)
            MyBase.WndProc(m)
            If DropDown AndAlso (m.Msg = WM_PAINT OrElse m.Msg = WM_ENABLE) Then
                Try
                    Dim g As Graphics = CreateGraphics()
                    Dim font As font = New font("Marlett", Me.Font.Size)
                    Dim sizeF As sizeF = g.MeasureString("6", font)
                    Dim brush As brush = CType(Microsoft.VisualBasic.IIf(Enabled, SystemBrushes.ControlText, New SolidBrush(SystemColors.GrayText)), brush)
                    g.DrawString("6", font, brush, Width - 4 - sizeF.Width, (Height - sizeF.Height) / 2.0F)
                Catch ex As Exception
                    Trace.WriteLine("Problem drawing dropdown arrow:" & ex.Message)
                End Try
            End If
        End Sub
    End Class
End Namespace