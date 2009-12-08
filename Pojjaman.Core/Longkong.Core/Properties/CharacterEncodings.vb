Imports System.Text
Namespace Longkong.Core.Properties
    Public Class CharacterEncodings

#Region "Members"
        Private Shared _cp2index As Hashtable
        Private Shared _encodings As ArrayList
        Private Shared _names As ArrayList
        Private Shared _wellKnownCodePages As Integer()
#End Region

#Region "Consructors"
        Shared Sub New()
            CharacterEncodings._wellKnownCodePages = New Integer() {37, 437, 500, 708, 850, 852, 855, 857, 858, 860, 861, 862, 863, 864, 865, 866, 869, 870, 874, 875, 932, 936, 949, 950, 1026, 1047, 1140, 1141, 1142, 1143, 1144, 1145, 1146, 1147, 1148, 1149, 1200, 1201, 1250, 1251, 1252, 1253, 1254, 1255, 1256, 1257, 1258, 10000, 10007, 10017, 10079, 20127, 20261, 20273, 20277, 20278, 20280, 20284, 20285, 20290, 20297, 20420, 20424, 20866, 20871, 21025, 21866, 28591, 28592, 28593, 28594, 28595, 28596, 28597, 28598, 28599, 28605, 38598, 50220, 50221, 50222, 50225, 50227, 51932, 51936, 52936, 54936, 57002, 57003, 57004, 57005, 57006, 57007, 57008, 57009, 57010, 57011, 65000, 65001}
            '   37,    //  IBM EBCDIC (US-Canada)
            '  437,    //  OEM United States
            '  500,    //  IBM EBCDIC (International)
            '  708,    //  Arabic (ASMO 708)
            '  850,    //  Western European (DOS)
            '  852,    //  Central European (DOS)
            '  855,    //  Cyrillic (DOS)
            '  857,    //  Turkish (DOS)
            '  858,    //  Western European (DOS with Euro)
            '  860,    //  Portuguese (DOS)
            '  861,    //  Icelandic (DOS)
            '  862,    //  Hebrew (DOS)
            '  863,    //  French Canadian (DOS)
            '  864,    //  Arabic (DOS)
            '  865,    //  Nordic (DOS)
            '  866,    //  Russian (DOS)
            '  869,    //  Greek (DOS)
            '  870,    //  IBM EBCDIC (Latin 2)
            '  874,    //  Thai (Windows)
            '  875,    //  IBM EBCDIC (Greek)
            '  932,    //  Japanese (Shift-JIS)
            '  936,    //  Chinese Simplified (GB2312)
            '  949,    //  Korean
            '  950,    //  Chinese Traditional (Big5)
            ' 1026,    //  IBM EBCDIC (Turkish)
            ' 1047,    //  IBM EBCDIC (Open Systems Latin 1)
            ' 1140,    //  IBM EBCDIC (US-Canada with Euro)
            ' 1141,    //  IBM EBCDIC (Germany with Euro)
            ' 1142,    //  IBM EBCDIC (Denmark/Norway with Euro)
            ' 1143,    //  IBM EBCDIC (Finland/Sweden with Euro)
            ' 1144,    //  IBM EBCDIC (Italy with Euro)
            ' 1145,    //  IBM EBCDIC (Latin America/Spain with Euro)
            ' 1146,    //  IBM EBCDIC (United Kingdom with Euro)
            ' 1147,    //  IBM EBCDIC (France with Euro)
            ' 1148,    //  IBM EBCDIC (International with Euro)
            ' 1149,    //  IBM EBCDIC (Icelandic with Euro)
            ' 1200,    //  Unicode
            ' 1201,    //  Unicode (Big-Endian)
            ' 1250,    //  Central European (Windows)
            ' 1251,    //  Cyrillic (Windows)
            ' 1252,    //  Western European (Windows)
            ' 1253,    //  Greek (Windows)
            ' 1254,    //  Turkish (Windows)
            ' 1255,    //  Hebrew (Windows)
            ' 1256,    //  Arabic (Windows)
            ' 1257,    //  Baltic (Windows)
            ' 1258,    //  Vietnamese (Windows)
            '10000,    //  Western European (Mac)
            '10007,    //  Cyrillic (Mac)
            '10017,    //  Ukrainian (Mac)
            '10079,    //  Icelandic (Mac)
            '20127,    //  US-ASCII
            '20261,    //  T.61
            '20273,    //  IBM EBCDIC (Germany)
            '20277,    //  IBM EBCDIC (Denmark/Norway)
            '20278,    //  IBM EBCDIC (Finland/Sweden)
            '20280,    //  IBM EBCDIC (Italy)
            '20284,    //  IBM EBCDIC (Latin America/Spain)
            '20285,    //  IBM EBCDIC (United Kingdom)
            '20290,    //  IBM EBCDIC (Japanese Katakana Extended)
            '20297,    //  IBM EBCDIC (France)
            '20420,    //  IBM EBCDIC (Arabic)
            '20424,    //  IBM EBCDIC (Hebrew)
            '20866,    //  Cyrillic (KOI8-R)
            '20871,    //  IBM EBCDIC (Icelandic)
            '21025,    //  IBM EBCDIC (Cyrillic - Serbian, Bulgarian)
            '21866,    //  Ukrainian (KOI8-U)
            '28591,    //  Western European (ISO)
            '28592,    //  Central European (ISO)
            '28593,    //  Latin 3 (ISO)
            '28594,    //  Baltic (ISO)
            '28595,    //  Cyrillic (ISO)
            '28596,    //  Arabic (ISO)
            '28597,    //  Greek (ISO)
            '28598,    //  Hebrew (ISO)
            '28599,    //  Latin 5 (ISO)
            '28605,    //  Latin 9 (ISO)
            '38598,    //  Hebrew (ISO Alternative)
            '50220,    //  Japanese (JIS)
            '50221,    //  Japanese (JIS-Allow 1 byte Kana)
            '50222,    //  Japanese (JIS-Allow 1 byte Kana - SO/SI)
            '50225,    //  Korean (ISO)
            '50227,    //  Chinese Simplified (ISO-2022)
            '51932,    //  Japanese (EUC)
            '51936,    //  Chinese Simplified (EUC)
            '52936,    //  Chinese Simplified (HZ)
            '54936,    //  Chinese Simplified (GB18030)
            '57002,    //  ISCII Devanagari
            '57003,    //  ISCII Bengali
            '57004,    //  ISCII Tamil
            '57005,    //  ISCII Telugu
            '57006,    //  ISCII Assamese
            '57007,    //  ISCII Oriya
            '57008,    //  ISCII Kannada
            '57009,    //  ISCII Malayalam
            '57010,    //  ISCII Gujarati
            '57011,    //  ISCII Punjabi
            '65000,    //  Unicode (UTF-7)
            '65001     //  Unicode (UTF-8)
            CharacterEncodings._encodings = New ArrayList
            CharacterEncodings._encodings.AddRange(CharacterEncodings.GetSupportedEncodings)
            CharacterEncodings._names = New ArrayList
            CharacterEncodings._cp2index = New Hashtable
            Dim num1 As Integer = 0
            Dim wrapper1 As EncodingWrapper
            For Each wrapper1 In CharacterEncodings._encodings
                CharacterEncodings._names.Add(wrapper1.Name)
                CharacterEncodings._cp2index.Item(wrapper1.CodePage) = num1
                num1 += 1
            Next
        End Sub
#End Region

#Region "Properties"
        Public Shared ReadOnly Property Names() As IList
            Get
                Return CharacterEncodings._names
            End Get
        End Property
#End Region

#Region "Methods"
        Public Shared Function GetCodePageByIndex(ByVal i As Integer) As Integer
            Dim encoding1 As Encoding = CharacterEncodings.GetEncodingByIndex(i)
            If (Not encoding1 Is Nothing) Then
                Return encoding1.CodePage
            End If
            Return -1
        End Function
        Public Shared Function GetEncodingByCodePage(ByVal cp As Integer) As Encoding
            Return CharacterEncodings.GetEncodingByIndex(CharacterEncodings.GetEncodingIndex(cp))
        End Function
        Public Shared Function GetEncodingByIndex(ByVal i As Integer) As Encoding
            If ((i >= 0) AndAlso (i < CharacterEncodings._encodings.Count)) Then
                Return CType(CharacterEncodings._encodings.Item(i), EncodingWrapper).Encoding
            End If
            Return Nothing
        End Function
        Public Shared Function GetEncodingIndex(ByVal cp As Integer) As Integer
            Dim num1 As Integer
            Try
                num1 = CType(CharacterEncodings._cp2index.Item(cp), Integer)
            Catch obj1 As Exception
                num1 = -1
            End Try
            Return num1
        End Function
        Private Shared Function GetSupportedEncodings() As IList
            Dim list1 As New ArrayList
            Dim numArray1 As Integer() = CharacterEncodings._wellKnownCodePages
            Dim num2 As Integer
            For num2 = 0 To numArray1.Length - 1
                Dim num1 As Integer = numArray1(num2)
                Try
                    list1.Add(New EncodingWrapper(num1))
                Catch obj1 As Exception
                End Try
            Next num2
            list1.Sort()
            Return list1
        End Function
        Public Shared Function IsUnicode(ByVal codePage As Integer) As Boolean
            If (((codePage <> 1200) AndAlso (codePage <> 1201)) AndAlso (codePage <> 65000)) Then
                Return (codePage = 65001)
            End If
            Return True
        End Function
        Public Shared Function IsUnicode(ByVal encoding As Encoding) As Boolean
            Return CharacterEncodings.IsUnicode(encoding.CodePage)
        End Function
#End Region

        Private Class EncodingWrapper
            Implements IComparable

#Region "Members"
            Private _cp As Integer
            Private _encoding As Encoding
#End Region

#Region "Constructors"
            Public Sub New(ByVal cp As Integer)
                Me._encoding = Encoding.GetEncoding(cp)
                Me._cp = cp
            End Sub
#End Region

#Region "Properties"
            Public ReadOnly Property CodePage() As Integer
                Get
                    Return Me._cp
                End Get
            End Property
            Public ReadOnly Property Encoding() As Encoding
                Get
                    Return Me._encoding
                End Get
            End Property
            Public ReadOnly Property Name() As String
                Get
                    If (Me._cp = 0) Then
                        Return ("System Default  [ " & Me.Encoding.EncodingName & " ]")
                    End If
                    Return Me.Encoding.EncodingName
                End Get
            End Property
#End Region

#Region "Methods"
            Public Shadows Function Equals(ByVal o As Object) As Boolean 'Todo:
                If (Not o Is Nothing) Then
                    If (o Is Me) Then
                        Return True
                    End If
                    If TypeOf o Is EncodingWrapper Then
                        Return (Me._cp = CType(o, EncodingWrapper)._cp)
                    End If
                End If
                Return False
            End Function
            Public Overrides Function GetHashCode() As Integer
                Return Me._cp
            End Function
            Public Overrides Function ToString() As String
                Return Me._cp.ToString
            End Function
#End Region
#Region "IComparable"
            Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
                Return Me.Name.CompareTo(CType(obj, EncodingWrapper).Name)
            End Function
#End Region

        End Class
    End Class
End Namespace

