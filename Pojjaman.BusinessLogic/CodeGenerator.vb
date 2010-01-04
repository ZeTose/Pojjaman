Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports System.Text.RegularExpressions
Imports System.Reflection
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class CodeGenerator
        Public Shared Function Validate(ByVal pattern As String) As Boolean
            Dim invalidPattern1 As String = "\#+[^#]\#+"
            Dim ivalidPattern2 As String = "\#+$"
            If Regex.IsMatch(pattern, invalidPattern1) Then
                'MessageBox.Show("Invalid Pettern:" & Regex.Match(pattern, invalidPattern1).Value)
                Return False
            End If
            If Not Regex.IsMatch(pattern, ivalidPattern2) Then
                'MessageBox.Show("Invalid Pettern: there must be at least one occurence of ""#.""")
                Return False
            End If
            Return True
        End Function
        Public Shared Function Generate(ByVal pattern As String, ByVal lastCode As String, ByVal o As Object) As String

            pattern = CodeGenerator.GetPattern(pattern, o)

            Dim runNum As String = "\#+$"
            Dim ptn As String = Regex.Replace(CleanRegEx(pattern), runNum, "") & "\d+$"
            Dim newCode As String
            Dim digit As Integer = Regex.Match(pattern, runNum).Value.Length
            Try
                If Regex.IsMatch(lastCode, ptn) Then
                    newCode = CStr(CInt(Regex.Match(lastCode, "\d{" & digit.ToString & "}$").Value) + 1)
                Else
                    newCode = "1"
                End If
            Catch ex As Exception
                newCode = "1"
            End Try
            pattern = Regex.Replace(pattern, runNum, newCode.PadLeft(digit, "0"c))
            Return pattern
        End Function
        Public Shared Function GetPattern(ByVal pattern As String _
        , ByVal o As Object) As String

            Dim year2D As String = """YY"""
            Dim year4D As String = """YYYY"""
            Dim month2D As String = """MM"""
            Dim day2D As String = """DD"""

            Dim dueYear2D As String = """yy"""
            Dim dueYear4D As String = """yyyy"""
            Dim dueMonth2D As String = """mm"""
            Dim dueDay2D As String = """dd"""

            Dim groupText As String = """G"""
            Dim custText As String = """C"""
            Dim supplierText As String = """S"""
            Dim toCCText As String = """TCC"""
            Dim fromCCText As String = """FCC"""
            Dim ccText As String = """CC"""
            Dim accountBookText As String = """J"""

            Dim ty As Type = o.GetType
            Dim pi As PropertyInfo = ty.GetProperty("DocDate")
            Dim docDate As Date = Date.MinValue
            If Not pi Is Nothing Then
                Dim d As Object = pi.GetValue(o, Nothing)
                If IsDate(d) Then
                    docDate = CDate(d)
                End If
            End If

            pi = ty.GetProperty("DueDate")
            Dim dueDate As Date = Date.MinValue
            If Not pi Is Nothing Then
                Dim d As Object = pi.GetValue(o, Nothing)
                If IsDate(d) Then
                    dueDate = CDate(d)
                End If
            End If

            Dim groupCode As String = ""
            If TypeOf o Is IHasGroup Then
                If Not CType(o, IHasGroup).Group Is Nothing Then
                    groupCode = CType(o, IHasGroup).Group.Code
                End If
            End If
            Dim supCustCode As String = ""
            If TypeOf o Is IHasIBillablePerson Then
                If Not CType(o, IHasIBillablePerson).BillablePerson Is Nothing Then
                    supCustCode = CType(o, IHasIBillablePerson).BillablePerson.Code
                End If
            End If
            Dim toCCCode As String = ""
            If TypeOf o Is IHasToCostCenter Then
                If Not CType(o, IHasToCostCenter).ToCC Is Nothing Then
                    toCCCode = CType(o, IHasToCostCenter).ToCC.Code
                End If
            End If
            Dim fromCCCode As String = ""
            If TypeOf o Is IHasFromCostCenter Then
                If Not CType(o, IHasFromCostCenter).FromCC Is Nothing Then
                    fromCCCode = CType(o, IHasFromCostCenter).FromCC.Code
                End If
            End If

            Dim accountBookCode As String = ""
            If TypeOf o Is IHasAccountBook Then
                If Not CType(o, IHasAccountBook).AccountBook Is Nothing Then
                    accountBookCode = CType(o, IHasAccountBook).AccountBook.CodePrefix
                End If
            End If

            Dim ccCode As String = ""
            If Not toCCCode Is Nothing AndAlso toCCCode.Length > 0 Then
                ccCode = toCCCode
            ElseIf Not fromCCCode Is Nothing AndAlso fromCCCode.Length > 0 Then
                ccCode = fromCCCode
            End If

            Dim myDate As Date = Now

            'HACK by Pla <--- Good!
            If TypeOf o Is Banking Then
                myDate = CType(o, Banking).Docdate
            End If

            If Not docDate.Equals(Date.MinValue) Then
                myDate = docDate
            End If
            Dim day As String = myDate.Day.ToString("00")
            Dim month As String = myDate.Month.ToString("00")
            Dim year As String = CStr(DatePart(DateInterval.Year, myDate))

            While Regex.IsMatch(pattern, year4D)
                pattern = Regex.Replace(pattern, year4D, year)
            End While
            While Regex.IsMatch(pattern, year2D)
                pattern = Regex.Replace(pattern, year2D, year.Substring(2, 2))
            End While
            While Regex.IsMatch(pattern, month2D)
                pattern = Regex.Replace(pattern, month2D, month)
            End While
            While Regex.IsMatch(pattern, day2D)
                pattern = Regex.Replace(pattern, day2D, day)
            End While

            'DueDate
            If Not dueDate.Equals(Date.MinValue) Then
                myDate = dueDate
            End If
            day = myDate.Day.ToString("00")
            month = myDate.Month.ToString("00")
            year = CStr(DatePart(DateInterval.Year, myDate))
            While Regex.IsMatch(pattern, dueYear4D)
                pattern = Regex.Replace(pattern, dueYear4D, year)
            End While
            While Regex.IsMatch(pattern, dueYear2D)
                pattern = Regex.Replace(pattern, dueYear2D, year.Substring(2, 2))
            End While
            While Regex.IsMatch(pattern, dueMonth2D)
                pattern = Regex.Replace(pattern, dueMonth2D, month)
            End While
            While Regex.IsMatch(pattern, dueDay2D)
                pattern = Regex.Replace(pattern, dueDay2D, day)
            End While

            While Regex.IsMatch(pattern, groupText)
                pattern = Regex.Replace(pattern, groupText, groupCode)
            End While
            While Regex.IsMatch(pattern, custText)
                pattern = Regex.Replace(pattern, custText, supCustCode)
            End While
            While Regex.IsMatch(pattern, supplierText)
                pattern = Regex.Replace(pattern, supplierText, supCustCode)
            End While
            While Regex.IsMatch(pattern, toCCText)
                pattern = Regex.Replace(pattern, toCCText, toCCCode)
            End While
            While Regex.IsMatch(pattern, fromCCText)
                pattern = Regex.Replace(pattern, fromCCText, fromCCCode)
            End While
            While Regex.IsMatch(pattern, ccText)
                pattern = Regex.Replace(pattern, ccText, ccCode)
            End While
      While Regex.IsMatch(pattern, accountBookText)
        pattern = Regex.Replace(pattern, accountBookText, accountBookCode)
      End While
            Return pattern
        End Function
        'Public Shared Function GetPattern(ByVal pattern As String _
        ', ByVal docDate As Date _
        ', Optional ByVal groupCode As String = "" _
        ', Optional ByVal custCode As String = "" _
        ', Optional ByVal supplierCode As String = "" _
        ', Optional ByVal toCCCode As String = "" _
        ', Optional ByVal fromCCCode As String = "" _
        ', Optional ByVal ccCode As String = "") As String

        '    Dim year2D As String = """YY"""
        '    Dim year4D As String = """YYYY"""
        '    Dim month2D As String = """MM"""
        '    Dim day2D As String = """DD"""
        '    Dim groupText As String = """G"""
        '    Dim custText As String = """C"""
        '    Dim supplierText As String = """S"""
        '    Dim toCCText As String = """TCC"""
        '    Dim fromCCText As String = """FCC"""
        '    Dim ccText As String = """CC"""

        '    If Not ccCode Is Nothing AndAlso ccCode.Length > 0 Then
        '        'ผ่าน
        '    ElseIf Not toCCCode Is Nothing AndAlso toCCCode.Length > 0 Then
        '        ccCode = toCCCode
        '    ElseIf Not fromCCCode Is Nothing AndAlso fromCCCode.Length > 0 Then
        '        ccCode = fromCCCode
        '    End If

        '    Dim myDate As Date = Now
        '    If Not docDate.Equals(Date.MinValue) Then
        '        myDate = docDate
        '    End If
        '    Dim day As String = myDate.Day.ToString("00")
        '    Dim month As String = myDate.Month.ToString("00")
        '    Dim year As String = CStr(DatePart(DateInterval.Year, myDate))

        '    While Regex.IsMatch(pattern, year4D)
        '        pattern = Regex.Replace(pattern, year4D, year)
        '    End While
        '    While Regex.IsMatch(pattern, year2D)
        '        pattern = Regex.Replace(pattern, year2D, year.Substring(2, 2))
        '    End While
        '    While Regex.IsMatch(pattern, month2D)
        '        pattern = Regex.Replace(pattern, month2D, month)
        '    End While
        '    While Regex.IsMatch(pattern, day2D)
        '        pattern = Regex.Replace(pattern, day2D, day)
        '    End While
        '    While Regex.IsMatch(pattern, groupText)
        '        pattern = Regex.Replace(pattern, groupText, groupCode)
        '    End While
        '    While Regex.IsMatch(pattern, custText)
        '        pattern = Regex.Replace(pattern, custText, custCode)
        '    End While
        '    While Regex.IsMatch(pattern, supplierText)
        '        pattern = Regex.Replace(pattern, supplierText, supplierCode)
        '    End While
        '    While Regex.IsMatch(pattern, toCCText)
        '        pattern = Regex.Replace(pattern, toCCText, toCCCode)
        '    End While
        '    While Regex.IsMatch(pattern, fromCCText)
        '        pattern = Regex.Replace(pattern, fromCCText, fromCCCode)
        '    End While
        '    While Regex.IsMatch(pattern, ccText)
        '        pattern = Regex.Replace(pattern, ccText, ccCode)
        '    End While
        '    Return pattern
        'End Function
        Public Shared Function GetPattern(ByVal pattern As String) As String
            Dim runNum As String = "\#+$"
            Dim ptn As String = Regex.Replace(CleanRegEx(pattern), runNum, "")
            Return ptn
        End Function
        Public Shared Function CleanRegEx(ByVal input As String) As String
            Dim invalidCharacters As String = "(\(|\\|\[|\]|\)|\||\}|\{)"
            Dim offset As Integer = 0
            For Each m As Match In Regex.Matches(input, invalidCharacters)
                input = input.Insert(m.Index + offset, "\")
                offset += 1
            Next
            Return input
        End Function
    End Class
End Namespace
