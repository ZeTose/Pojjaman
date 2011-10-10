Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Interface IGLAble
        Inherits IIdentifiable
        Property [Date]() As Date
        Property Note() As String
        Function GetDefaultGLFormat() As GLFormat
        Function GetJournalEntries() As JournalEntryItemCollection
        Property JournalEntry() As JournalEntry
  End Interface
  Public Interface INewGLAble
    Inherits IGLAble
    Function NewGetJournalEntries() As JournalEntryItemCollection
    Function OnlyGenGLAtom() As SaveErrorException
    Function SubSaveJeAtom(ByVal conn As SqlConnection) As SaveErrorException
  End Interface
  Public Interface IGlChangable
    Event GlChanged As EventHandler
  End Interface
  Public Class GenericGlAble
    Implements IGLAble

#Region "Members"
    Private m_id As Integer
    Private m_code As String
    Private m_date As Date
    Private m_note As String
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal id As Integer, ByVal code As String, ByVal myDate As Date)
      m_id = id
      m_code = code
      m_date = myDate
    End Sub
    Public Sub New(ByVal id As Integer, ByVal code As String, ByVal myDate As Date, ByVal myNote As String)
      m_id = id
      m_code = code
      m_date = myDate
      m_note = myNote
    End Sub
#End Region

#Region "IGLAble"
    Public Property Id() As Integer Implements IIdentifiable.Id
      Get
        Return m_id
      End Get
      Set(ByVal Value As Integer)
        m_id = Value
      End Set
    End Property
    Public Property Code() As String Implements IIdentifiable.Code
      Get
        Return m_code
      End Get
      Set(ByVal Value As String)
        m_code = Value
      End Set
    End Property
    Public Property [Date]() As Date Implements IGLAble.Date
      Get
        Return m_date
      End Get
      Set(ByVal Value As Date)
        m_date = Value
      End Set
    End Property
    Public Property Note() As String Implements IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat

    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries

    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get

      End Get
      Set(ByVal Value As JournalEntry)

      End Set
    End Property
#End Region



  End Class
End Namespace
