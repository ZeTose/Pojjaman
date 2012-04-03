
Public Class EntityAutoGen

  Public Sub New()
    _EntityFormatId = -1
    _EntityId = -1
    _EntityName = ""
    _EntityGLId = -1
    _EntityGLName = ""
    _EntityConfigId = -1
    _EntityConfigName = ""
    _EntityFormat = ""
    _EntityNote = ""
  End Sub

  Public Sub Clone(clone As EntityAutoGen)
    'clone = New EntityAutoGen
    clone.EntityFormatId = Me.EntityFormatId
    clone.EntityId = Me.EntityId
    clone.EntityName = Me.EntityName
    clone.EntityGLId = Me.EntityGLId
    clone.EntityGLName = Me.EntityGLName
    clone.EntityConfigId = Me.EntityConfigId
    clone.EntityConfigName = Me.EntityConfigName
    clone.EntityFormat = Me.EntityFormat
    clone.EntityNote = Me.EntityNote
  End Sub

  Private _EntityFormatId As Integer

  Public Property EntityFormatId As Integer
    Get
      Return _EntityFormatId
    End Get
    Set(value As Integer)
      _EntityFormatId = value
    End Set
  End Property

  Private _EntityId As Integer

  Public Property EntityId As Integer
    Get
      Return _EntityId
    End Get
    Set(value As Integer)
      _EntityId = value
    End Set
  End Property

  Private _EntityName As String

  Public Property EntityName As String
    Get
      Return _EntityName
    End Get
    Set(value As String)
      _EntityName = value
    End Set
  End Property

  Private _EntityGLId As Integer

  Public Property EntityGLId As Integer
    Get
      Return _EntityGLId
    End Get
    Set(value As Integer)
      _EntityGLId = value
    End Set
  End Property

  Private _EntityGLName As String

  Public Property EntityGLName As String
    Get
      Return _EntityGLName
    End Get
    Set(value As String)
      _EntityGLName = value
    End Set
  End Property

  Private _EntityConfigId As Integer

  Public Property EntityConfigId As Integer
    Get
      Return _EntityConfigId
    End Get
    Set(value As Integer)
      _EntityConfigId = value
    End Set
  End Property

  Private _EntityConfigName As String

  Public Property EntityConfigName As String
    Get
      Return _EntityConfigName
    End Get
    Set(value As String)
      _EntityConfigName = value
    End Set
  End Property

  Private _EntityFormat As String

  Public Property EntityFormat As String
    Get
      Return _EntityFormat
    End Get
    Set(value As String)
      _EntityFormat = value
    End Set
  End Property

  Private _EntityNote As String

  Public Property EntityNote As String
    Get
      Return _EntityNote
    End Get
    Set(value As String)
      _EntityNote = value
    End Set
  End Property

End Class
