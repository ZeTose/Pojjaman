Imports longkong.Core.Services
Namespace Longkong.AdobeForm
  Public Class ImageControl
    Inherits AdobeControl
    Implements IHasRootPath

#Region "Members"
    Private m_Path As String
    Private m_rootPath As String
    Private m_image As Image
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal xmlNode As XmlNode)
      MyBase.New(xmlNode)
      ProcessXmlNode(xmlNode)
    End Sub
    Private Sub ProcessXmlNode(ByVal xmlnode As XmlNode)
      Dim foundedNode As xmlnode = xmlnode.SelectSingleNode("value/image")
      If Not foundedNode Is Nothing Then
        If Not foundedNode.Attributes("href") Is Nothing Then
          Me.m_Path = foundedNode.Attributes("href").Value
        End If
        If Not foundedNode.InnerText Is Nothing AndAlso foundedNode.InnerText.Length > 0 Then
          Dim bt() As Byte = Convert.FromBase64String(foundedNode.InnerText)
          Dim stream As New IO.MemoryStream(bt, 0, bt.Length)
          stream.Write(bt, 0, bt.Length)
          Image = Image.FromStream(stream, True)
          stream.Close()
        End If
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property Path() As String
      Get
        Return m_Path
      End Get
      Set(ByVal Value As String)
        m_Path = Value
      End Set
    End Property
    Public Property Image() As Image      Get        Return m_image      End Get      Set(ByVal Value As Image)        m_image = Value      End Set    End Property
    Public ReadOnly Property AbsolutePath() As String
      Get
        Dim fu As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
        Return fu.RelativeToAbsolutePath(Me.m_rootPath, Me.m_Path)
      End Get
    End Property
#End Region

#Region "IDrawable"
    Public Overloads Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
      Dim imgRect As New RectangleF(Location.X, Location.Y, Width, Height)
      If Not Me.Image Is Nothing Then
        g.DrawImage(Me.Image, imgRect)
        Return
      End If
      Dim thePath As String = AbsolutePath
      If IO.File.Exists(thePath) Then
        Dim img As New Bitmap(thePath)
        g.DrawImage(img, imgRect)
      Else
        Dim f As New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        g.DrawString(thePath, f, SystemBrushes.ControlText, imgRect)
      End If
    End Sub
#End Region

#Region "IHasRootPath"
    Public Property RootPath() As String Implements IHasRootPath.RootPath
      Get
        Return m_rootPath
      End Get
      Set(ByVal Value As String)
        m_rootPath = Value
      End Set
    End Property
#End Region

  End Class
End Namespace

