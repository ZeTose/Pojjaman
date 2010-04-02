Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  <Serializable()> _
  Public Class LogDTO
    Public Property ActionId As Decimal
    Public Property UserId As Integer
    Public Property RoleId As Decimal
    Public Property Time As Date
    Public Property Note As String

    Public Property EntityId As Integer
    Public Property EntityTypeId As Integer

    Public Sub New(ByVal al As ActionLog)
      If Not al.Action Is Nothing Then
        ActionId = al.Action.Id
      End If
      If Not al.User Is Nothing Then
        UserId = al.User.Id
      End If
      If Not al.Role Is Nothing Then
        RoleId = al.Role.Id
      End If
      Note = al.Note
      Time = al.Time
      EntityId = al.EntityId
      EntityTypeId = al.EntityTypeId
    End Sub
  End Class
End Namespace


