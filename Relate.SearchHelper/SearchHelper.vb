Option Explicit On
Option Strict On
Option Compare Text

'--- Exception when the search expression can not be used
Public Class InvalidSearchExpressionException
    Inherits Exception

    Public Sub New(ByVal strError As String)
        MyBase.New(strError)
    End Sub
End Class

Public Class SearchHelper
    Private m_strSearchExpression As String
    Private m_strSuggestedSearchExpression As String
    Private m_strDBSearchExpression As String
    Private m_bolHasError As Boolean = False
    Private m_strErrorDescription As String = ""
    Private m_strCleanSearchExpression As String
    Private m_bolUseInflections As Boolean

    '--- Throws ArgumentNullException if search expression is nothing or just whitespace
    '--- or Exception if passed in search expression can not be used at all
    Public Sub New(ByVal strSearchExpression As String, ByVal bolUseInflections As Boolean)

        m_bolUseInflections = bolUseInflections
        m_strSearchExpression = strSearchExpression

        If strSearchExpression Is Nothing OrElse strSearchExpression.Trim = "" Then
            Throw New ArgumentNullException("strSearchExpression")
        End If

        m_strCleanSearchExpression = strSearchExpression

        Dim strCleanExpression As String = m_strCleanSearchExpression.Trim.ToLower

        '--- Remove all invalid characters and replace with whitespace
        strCleanExpression = mstrCleanExpression(strCleanExpression)

        '--- Remove double white spaces
        strCleanExpression = mstrRepeatReplace(strCleanExpression, "  ", " ")

        '--- Validate quotes
        If Not mbolHasValidQuotes(strCleanExpression) Then
            mSetError("Missing closing quotation marks")
            '--- Remove all quotes with spaces
            strCleanExpression = strCleanExpression.Replace("""", " ")
            '--- Remove all invalid characters and replace with whitespace
            '--- already gone this, but we excluded invalid characters that were inside quotes
            '--- now that we've removed quotes, we have to remove all other invalid characters
            strCleanExpression = mstrCleanExpression(strCleanExpression)
            '--- and remove all duplicate wyhite spaces
            strCleanExpression = mstrRepeatReplace(strCleanExpression, "  ", " ")
        End If

        '--- Validate brackets
        If Not mbolHasValidBrackets(strCleanExpression) Then
            mSetError("Invalid brackets")
            '--- Remove all brackets
            strCleanExpression = strCleanExpression.Replace("(", " ").Replace(")", " ")
            '--- remove all duplicate white spaces
            strCleanExpression = mstrRepeatReplace(strCleanExpression, "  ", " ").Trim
        End If

        '--- Make sure we don't start with "and", "or" or "not" or "near"
        While mstrRecurseExpression(strCleanExpression, AddressOf mstrCheckPrefixIsValidWord) <> strCleanExpression
            strCleanExpression = mstrRecurseExpression(strCleanExpression, AddressOf mstrCheckPrefixIsValidWord)
        End While

        '--- Make sure we don't end with "and", "or" or "not" or "near"
        While mstrRecurseExpression(strCleanExpression, AddressOf mstrCheckSuffixIsValidWord) <> strCleanExpression
            strCleanExpression = mstrRecurseExpression(strCleanExpression, AddressOf mstrCheckSuffixIsValidWord)
        End While

        '--- We are about to replace all spaces with " and ",
        '--- but we don't want to do this for expressions inside quotes
        '--- So first we will replace all spaces inside quotes with "_"
        '--- This will be replace back to spaces afterwords
        strCleanExpression = mstrFillInSpacesInQuotes(strCleanExpression)

        '--- add spaced between ")(" this will get converted to ") and ("
        strCleanExpression = strCleanExpression.Replace(")(", ") (")

        '--- Find any invalid expressions such as " or not "
        '--- these will be filtered out later
        mbolCheckInvalidExpression(strCleanExpression, "or not")
        mbolCheckInvalidExpression(strCleanExpression, "not or")
        mbolCheckInvalidExpression(strCleanExpression, "not and")
        mbolCheckInvalidExpression(strCleanExpression, "and or")
        mbolCheckInvalidExpression(strCleanExpression, "or and")

        strCleanExpression = strCleanExpression.Trim

        '--- put spaces between brackets
        strCleanExpression = mstrSpaceBrackets(strCleanExpression)

        '--- now all spaces simply get converted to " and "
        '--- we will remove duplicate ands (and other invalid expressions) later
        strCleanExpression = strCleanExpression.Replace(" ", " and ")

        '--- now replace all invalid expressions with a safe one, i.e. " and "
        '--- first prefix and suffix clean expression with " " 
        '--- this makes sure we find whole words
        strCleanExpression = " " + strCleanExpression.Trim + " "
        strCleanExpression = mstrRepeatReplace(strCleanExpression, "  ", " ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, " and or ", " or ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, " or and ", " or ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, " or not ", " and not ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, " not and ", " and not ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, " not or ", " and not ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, " and not and ", " and not ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, " not not ", " not ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, "( and ", "( ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, " and )", " )")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, " and and ", " and ")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, "(", "")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, ")", "")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, "|", "")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, "&", "")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, "*", "")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, "^", "")
        strCleanExpression = mstrRepeatReplace(strCleanExpression, "/", "")

        '--- trim the clean expression
        strCleanExpression = strCleanExpression.Trim

        '--- remove leading "and"
        If strCleanExpression.StartsWith("and ") Then
            strCleanExpression = strCleanExpression.Substring(Len("and "))
        End If

        '--- Remove trailing "and"
        If strCleanExpression.EndsWith(" and") Then
            strCleanExpression = strCleanExpression.Substring(0, Len(strCleanExpression) - Len(" and"))
        End If

        '--- now replace all "_" back to spaces
        strCleanExpression = strCleanExpression.Replace("_", " ")

        '--- Do we have any search expression to search on?
        '--- If not, raise an error as otherwise the db engine will spit the dummy
        If strCleanExpression = "" Then
            strCleanExpression = """"""
        End If

        '--- Set the properties
        m_strCleanSearchExpression = strCleanExpression
        m_strSuggestedSearchExpression = strCleanExpression

        Dim temp As String = String.Empty
        For Each exp As String In m_strSuggestedSearchExpression.Split(New String() {" and "}, StringSplitOptions.RemoveEmptyEntries)
            Dim charsToTrim() As Char = {""""c}

            temp = temp & """" & exp & """ AND "
            If temp.Length > 500 Then
                Exit For
            End If
        Next

        temp = temp.Substring(0, temp.Length - 5)

        temp = String.Empty
        For Each exp As String In m_strSuggestedSearchExpression.Split(New String() {" or "}, StringSplitOptions.RemoveEmptyEntries)
            Dim charsToTrim() As Char = {""""c}

            temp = temp & """" & exp & """ OR "
            If temp.Length > 500 Then
                Exit For
            End If
        Next

        temp = temp.Substring(0, temp.Length - 4)
        m_strSuggestedSearchExpression = temp.Replace("AND OR", "AND").Replace("OR AND", "AND").Trim()

        If (m_strSuggestedSearchExpression.Trim().Contains(" ")) Then
            Dim charsToTrim() As Char = {""""c}
            m_strSuggestedSearchExpression = """" & m_strSuggestedSearchExpression.Trim(charsToTrim) & """"
        End If

        If bolUseInflections Then
            m_strDBSearchExpression = mstrGetInflections(strCleanExpression)

            For Each c As Char In m_strDBSearchExpression.ToCharArray()
                Dim cat As System.Globalization.UnicodeCategory = Char.GetUnicodeCategory(c)

                If cat = Globalization.UnicodeCategory.OtherLetter And c <> ","c And c <> " "c Then
                    m_strDBSearchExpression = m_strDBSearchExpression.Replace(c.ToString(), c.ToString() & ", ")
                End If
            Next

            Dim chars() As Char = {","c, " "c, """"c, ")"c}
            m_strDBSearchExpression = m_strDBSearchExpression.Replace(", )", ")").Replace(", , ", ", ")
            m_strDBSearchExpression = m_strDBSearchExpression.TrimEnd(chars) & ")"
        Else
            m_strDBSearchExpression = strCleanExpression

            '--- when not using inflections, lets replace
            '--- all "and"s with "near" (this improves ranking)
            '--- but we don't want to touch anything inside quotes
            '--- and we still need "and not" ("near not" doesn't work)

            '--- first, lets fill in blanks inside quotes so expression in quotes won't be effected
            m_strDBSearchExpression = mstrFillInSpacesInQuotes(m_strDBSearchExpression)

            '--- Now, replace all " and not " with " and not " 
            '--- this will be fixed back again after replacing "and"s with "near"
            m_strDBSearchExpression = m_strDBSearchExpression.Replace(" and not ", " and_not ")

            '--- Replace all " and " with " near "
            m_strDBSearchExpression = m_strDBSearchExpression.Replace(" and ", " near ")

            '--- (expression) near expression 
            '--- doesn't work, replace with
            '--- (expression) and expression
            m_strDBSearchExpression = m_strDBSearchExpression.Replace(") near ", ") and ")

            '--- expression near (expression)
            '--- doesn't work, replace with
            '--- expression and (expression)
            m_strDBSearchExpression = m_strDBSearchExpression.Replace("near (", "and (")

            '--- now remove all "_" back to " "
            m_strDBSearchExpression = m_strDBSearchExpression.Replace("_", " ")

            For Each c As Char In m_strDBSearchExpression.ToCharArray()
                Dim cat As System.Globalization.UnicodeCategory = Char.GetUnicodeCategory(c)

                If cat = Globalization.UnicodeCategory.OtherLetter And c <> ","c And c <> " "c Then
                    m_strDBSearchExpression = m_strDBSearchExpression.Replace(c.ToString(), c.ToString() & ", ")
                End If
            Next
            Dim chars() As Char = {","c, " "c, """"c, ")"c}
            m_strDBSearchExpression = m_strDBSearchExpression.Replace(", )", ")").Replace(", , ", ", ")
            m_strDBSearchExpression = m_strDBSearchExpression.TrimEnd(chars) & ")"
        End If

        If m_strDBSearchExpression = ")" Then
            m_strDBSearchExpression = String.Empty
        End If
    End Sub

#Region "Implementation"

    '--- Replace all brackets not in quotes with " " bracket " "
    Private Function mstrSpaceBrackets(ByVal strExpression As String) As String
        Dim strCleanExpression As String = ""
        Dim bolInQuotes As Boolean = False
        For Each c As Char In strExpression.ToCharArray

            If c = """"c Then
                bolInQuotes = Not bolInQuotes
                strCleanExpression += c
            ElseIf c = "("c And Not bolInQuotes Then
                strCleanExpression += " ( "
            ElseIf c = ")"c And Not bolInQuotes Then
                strCleanExpression += " ) "
            Else
                strCleanExpression += c
            End If

        Next

        Return strCleanExpression
    End Function

    '--- Delegate function to take an expression and return a clean expression
    Private Delegate Function mstrCleanSubExpression(ByVal strSubExpression As String) As String

    '-- Function for recursing through all bracketed expressions
    Private Function mstrRecurseExpression(ByVal strExpression As String, ByVal func As mstrCleanSubExpression) As String

        Dim strCleanExpression As String = func.Invoke(strExpression.Trim)

        '--- Get bracketed expressions
        '--- and recurisivly clean each bracketed expression
        Dim intPos As Integer = 0
        Dim intStartBracket As Integer = -1
        Dim intEndBracket As Integer = -1
        Dim intBracketCount As Integer = 0
        Dim bolInQuotes As Boolean = False
        For Each c As Char In strCleanExpression

            If c = """"c Then
                '--- Toggle in quotes
                bolInQuotes = Not bolInQuotes
            End If

            If Not bolInQuotes Then
                If c = "("c Then
                    If intBracketCount = 0 Then
                        '--- Record start of bracket
                        intStartBracket = intPos
                    End If
                    intBracketCount += 1
                ElseIf c = ")"c Then
                    '--- We should have already checked that brackets are valid
                    Debug.Assert(intBracketCount > 0)

                    intBracketCount -= 1

                    If intBracketCount = 0 Then
                        '--- Found matching closing bracket
                        '--- Record end position
                        intEndBracket = intPos

                        '--- Get the bracketed sub string
                        Dim strSubString As String = strCleanExpression.Substring(intStartBracket + 1, intEndBracket - intStartBracket - 1)

                        '--- Recurse through the sub string
                        strSubString = mstrRecurseExpression(strSubString, func)

                        '--- Replace the sub string with the cleaned sub string
                        Dim strBegin As String
                        Dim strEnd As String

                        If strSubString = "" Then
                            '--- remove entire bracketed expression

                            If intStartBracket = 0 Then
                                '--- Starts with '(', so remove entire start
                                strBegin = ""
                            Else
                                '--- Starts with proper text, make sure we include
                                strBegin = strCleanExpression.Substring(0, intStartBracket)
                            End If

                            If intEndBracket = Len(strCleanExpression) - 1 Then
                                '--- ends With ')', so remove entire end
                                strEnd = ""
                            Else
                                '--- ends with proper text, make sure we include
                                strEnd = strCleanExpression.Substring(intEndBracket + 1)
                            End If

                            '--- Replace the sub string in the clean expression
                            strCleanExpression = strBegin + strEnd

                            '--- Recalc the end bracket
                            intEndBracket = 0
                        Else
                            '--- Insert bracketed expression
                            strBegin = strCleanExpression.Substring(0, intStartBracket + 1)
                            strEnd = strCleanExpression.Substring(intEndBracket, Len(strCleanExpression) - intEndBracket)
                            '--- recalc end bracket
                            intEndBracket = Len(strBegin) + Len(strSubString)
                            '--- Setup the clean expression
                            strCleanExpression = strBegin + strSubString + strEnd
                        End If


                    End If
                End If
            End If


            '--- Increment current position
            intPos += 1
        Next


        '--- return the clean expression
        Return strCleanExpression

    End Function

    '--- Replace all words not in quotes (besides "and", "or" and "not") with "FORMSOF(INFLECTIONAL, word)"
    Private Function mstrGetInflections(ByVal strExpression As String) As String
        Dim strInflection As String = ""
        Dim intWordStart As Integer
        Dim intWordEnd As Integer
        Dim intWordLength As Integer
        Dim bolInWord As Boolean = False
        Dim intIndex As Integer = 0
        Dim strWord As String
        Dim bolInQuotes As Boolean = False
        Dim c As Char

        For Each c In strExpression.ToCharArray
            If Not bolInQuotes And (Char.IsLetterOrDigit(c) Or c = "#"c Or c = "."c Or c = "@"c Or c = "\"c Or c = "/"c) Then
                '--- Dont append until end of word
                If Not bolInWord Then
                    intWordStart = intIndex
                    bolInWord = True
                End If
            Else
                If c = """"c Then
                    bolInQuotes = Not bolInQuotes
                End If
                If bolInWord Then
                    '--- word breaker
                    bolInWord = False
                    intWordEnd = intIndex - 1
                    intWordLength = intWordEnd - intWordStart + 1
                    strWord = strExpression.Substring(intWordStart, intWordLength)
                    If strWord <> "and" And strWord <> "or" And strWord <> "not" Then

                        ''SQL SERVER 2008 FTI Fix
                        'strWord = String.Format("""{0}""", strWord)
                        ''END SQL SERVER 2008 FTI Fix

                        strWord = "FORMSOF(INFLECTIONAL, " + strWord + ")"
                    End If
                    '--- append the word
                    strInflection += If(String.IsNullOrEmpty(strInflection), String.Empty, "AND ") + strWord
                End If

                '--- append the word breaker character
                strInflection += c
            End If

            intIndex += 1
        Next

        '--- Check if final character is in word
        If bolInWord Then
            '--- word breaker
            bolInWord = False
            intWordEnd = intIndex - 1
            intWordLength = intWordEnd - intWordStart + 1
            strWord = strExpression.Substring(intWordStart, intWordLength)
            If strWord <> "and" And strWord <> "or" And strWord <> "not" Then

                ''SQL SERVER 2008 FTI Fix
                'strWord = String.Format("""{0}""", strWord)
                ''END SQL SERVER 2008 FTI Fix

                strWord = "FORMSOF(INFLECTIONAL, " + strWord + ")"
            End If
            '--- append the word
            strInflection += If(String.IsNullOrEmpty(strInflection), String.Empty, "AND ") + strWord
        End If


        Return strInflection

    End Function

    '--- Conditionally set the has erorr and error description fields
    '--- (only if not previously set)
    Private Sub mSetError(ByVal strErrorDescription As String)
        If Not m_bolHasError Then
            m_bolHasError = True
            m_strErrorDescription = strErrorDescription
        End If
    End Sub

    '--- Check for invalid expressions
    Private Function mbolCheckInvalidExpression(ByVal strExpression As String, ByVal strInvalidExpression As String) As Boolean
        If ((" " + strExpression + " ").IndexOf(" " + strInvalidExpression + " ") > -1) Then
            mSetError("Invalid search expression: '" + strInvalidExpression + "'")
        End If
    End Function

    '--- Check suffix is not "and", "or" or "not"
    '--- Note that this function may change the value of:
    '---    m_bolHasError
    '---    m_strErrorDescription
    Private Function mstrCheckSuffixIsValidWord(ByVal strExpression As String) As String
        Dim strCleanExpression As String = " " + strExpression + " "

        '--- Check ends with "and"
        If strCleanExpression.EndsWith(" and ") Then
            mSetError("Invalid suffix: 'and'")
            Return strCleanExpression.Substring(0, Len(strCleanExpression) - Len(" and ")).Trim
        End If

        '--- Check ends with "or"
        If strCleanExpression.EndsWith(" or ") Then
            mSetError("Invalid suffix: 'or'")
            Return strCleanExpression.Substring(0, Len(strCleanExpression) - Len(" or ")).Trim
        End If

        '--- Check ends with "not"
        If strCleanExpression.EndsWith(" not ") Then
            mSetError("Invalid suffix: 'not'")
            Return strCleanExpression.Substring(0, Len(strCleanExpression) - Len(" not ")).Trim
        End If

        '--- Check ends with "near"
        If strCleanExpression.EndsWith(" near ") Then
            mSetError("Invalid suffix: 'near'")
            Return strCleanExpression.Substring(0, Len(strCleanExpression) - Len(" near ")).Trim
        End If

        Return strCleanExpression.Trim

    End Function

    '--- Check prefix is not "and", "or" or "not"
    '--- Note that this function may change the value of:
    '---    m_bolHasError
    '---    m_strErrorDescription
    Private Function mstrCheckPrefixIsValidWord(ByVal strExpression As String) As String
        Dim strCleanExpression As String = " " + strExpression + " "

        '--- Check starts with "and"
        If strCleanExpression.StartsWith(" and ") Then
            mSetError("Invalid prefix: 'and'")
            Return strCleanExpression.Substring(Len(" and ")).Trim
        End If

        '--- Check starts with "or"
        If strCleanExpression.StartsWith(" or ") Then
            mSetError("Invalid prefix: 'or'")
            Return strCleanExpression.Substring(Len(" or ")).Trim
        End If

        '--- Check starts with "not"
        If strCleanExpression.StartsWith(" not ") Then
            mSetError("Invalid prefix: 'not'")
            Return strCleanExpression.Substring(Len(" not ")).Trim
        End If

        '--- Check starts with "near"
        If strCleanExpression.StartsWith(" near ") Then
            mSetError("Invalid prefix: 'near'")
            Return strCleanExpression.Substring(Len(" near ")).Trim
        End If

        '--- Trim search expresion
        Return strCleanExpression.Trim


    End Function

    '--- Repeatedly replace all ocurrences of strFind in strExpression with strReplace
    '--- until there are no more instances of strFind
    Private Function mstrRepeatReplace(ByVal strExpression As String, ByVal strFind As String, ByVal strReplace As String) As String
        Dim strCleanExpression As String = strExpression
        While strCleanExpression.IndexOf(strFind) > -1
            strCleanExpression = strCleanExpression.Replace(strFind, strReplace)
        End While
        Return strCleanExpression
    End Function


    '--- Replace all spoaces inside quotes with "_"
    Private Function mstrFillInSpacesInQuotes(ByVal strExpression As String) As String
        Dim bolInQuotes As Boolean = False
        Dim strCleanExpression As String = ""

        For Each c As Char In strExpression.ToCharArray
            Dim cReplace As Char = c
            If c = """"c Then
                bolInQuotes = Not bolInQuotes
            ElseIf c = " "c And bolInQuotes Then
                cReplace = "_"c
            End If
            strCleanExpression += cReplace
        Next

        Return strCleanExpression

    End Function

    '--- Test to see if we have valid brackets
    Private Function mbolHasValidBrackets(ByVal strExpression As String) As Boolean

        Dim intBracketCount As Integer = 0
        Dim bolInQuotes As Boolean = False

        For Each c As Char In strExpression.ToCharArray
            If c = """"c Then
                bolInQuotes = Not bolInQuotes
            ElseIf c = "("c And Not bolInQuotes Then
                intBracketCount += 1
            ElseIf c = ")"c And Not bolInQuotes Then
                If intBracketCount = 0 Then
                    '--- No corresponding opening bracker
                    Return False
                End If
                intBracketCount -= 1
            End If
        Next

        Return (intBracketCount = 0)

    End Function

    '--- Test to see if quotes and brackets are correct
    Private Function mbolHasValidQuotes(ByVal strExpression As String) As Boolean
        If strExpression.IndexOf("""") = -1 Then
            Return True
        End If

        Dim intIndex As Integer = strExpression.IndexOf("""")
        While intIndex > -1
            '--- Have we an end quote?
            If strExpression.IndexOf("""", intIndex + 1) = -1 Then
                Return False
            End If
            '--- Get the end quote
            intIndex = strExpression.IndexOf("""", intIndex + 1)
            '--- And the next quote
            intIndex = strExpression.IndexOf("""", intIndex + 1)
        End While

        '--- All ok
        Return True
    End Function

    '--- Clean non valid characters
    Private Function mstrCleanExpression(ByVal strExpression As String) As String
        Dim strCleanExpression As String = ""
        Dim bolInQuotes As Boolean = False

        '--- Replace all excluded charcters with aspaces
        For Each c As Char In strExpression.ToCharArray

            '--- replace single quite with double quote
            'If c = "'"c Then
            '    c = """"c
            'End If

            If c = """"c Then
                bolInQuotes = Not bolInQuotes
            End If

            If bolInQuotes Then
                '--- include all characters inside quotes
                strCleanExpression += c
            Else
                '--- Include letters, numbers, space, double quotes left and richr brackets, hash, full stop and at symbol
                If Char.IsLetterOrDigit(c) Or c = " "c Or c = """"c Or c = "("c Or c = ")"c Or c = "#"c Or c = "."c Or c = "@"c Or c = "\"c Or c = "/"c Or c = "|"c Or c = "&"c Or c = "*"c Or c = "^"c Or c = "/"c Then
                    strCleanExpression += c
                Else
                    mSetError("Invalid character: '" + c + "'")
                    '--- replace with space
                    strCleanExpression += " "
                End If
            End If

        Next

        Return strCleanExpression

    End Function

#End Region

#Region "Properties"

    '--- Original search expression
    Public ReadOnly Property strSearchExpression() As String
        Get
            Return m_strSearchExpression
        End Get
    End Property

    '--- Clean search expression
    Public ReadOnly Property strCleanSearchExpression() As String
        Get
            Return m_strCleanSearchExpression
        End Get
    End Property


    '--- Suggested search expression
    Public ReadOnly Property strSuggestedSearchExpression() As String
        Get
            Return m_strSuggestedSearchExpression
        End Get
    End Property

    '--- Database search expression
    Public ReadOnly Property strDBSearchExpression() As String
        Get
            Return m_strDBSearchExpression
        End Get
    End Property

    '--- Has Error
    Public ReadOnly Property bolHasError() As Boolean
        Get
            Return m_bolHasError
        End Get
    End Property

    '--- Error Description
    Public ReadOnly Property strErrorDescription() As String
        Get
            Return m_strErrorDescription
        End Get
    End Property

    '--- Use inflections
    Public ReadOnly Property bolUseInflections() As Boolean
        Get
            Return m_bolUseInflections
        End Get
    End Property

    '--- Use Near
    Public ReadOnly Property bolUseNear() As Boolean
        Get
            Return Not Me.bolUseInflections
        End Get
    End Property

#End Region

End Class
