Imports System.Xml
Namespace Longkong.Core.AddIns.Codons
    Public Class CodonFactory

#Region "Members"
        Private m_codonHashtable As Hashtable
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_codonHashtable = New Hashtable
        End Sub
#End Region

#Region "Methods"
        Public Sub AddCodonBuilder(ByVal builder As CodonBuilder)
            If (Not Me.m_codonHashtable(builder.CodonName) Is Nothing) Then
                Throw New DuplicateCodonException(builder.CodonName)
            End If
            Me.m_codonHashtable(builder.CodonName) = builder
        End Sub
        Public Function CreateCodon(ByVal addIn As AddIn, ByVal codonNode As XmlNode) As ICodon
            Dim myCodonBuilder As CodonBuilder = CType(Me.m_codonHashtable(codonNode.Name), CodonBuilder)
            If (myCodonBuilder Is Nothing) Then
                Throw New CodonNotFoundException(String.Format("no codon builder found for <{0}>", codonNode.Name))
            End If
            Return myCodonBuilder.BuildCodon(addIn)
        End Function
#End Region

    End Class
End Namespace
