Module ModLang
    Const UVowels = "áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴĐ"
    Const Vowels = "¸µ¶·¹¨¾»¼½Æ©ÊÇÈÉËÐÌÎÏÑªÕÒÓÔÖÝ×ØÜÞãßáâä«èåæçé¬íêëìîóïñòô­øõö÷ùýúûüþ®¸µ¶·¹¡¡¡¡¡¡¢¢¢¢¢¢ÐÌÎÏÑ££££££Ý×ØÜÞãßáâä¤¤¤¤¤¤¥¥¥¥¥¥óïñòô¦¦¦¦¦¦ýúûüþ§"
    Const UNoneff = "aaaaaaaaaaaaaaaaaeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyydAAAAAAAAAAAAAAAAAEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYD"
    Public Function ConvertUniocode2None(ByVal strSource As String) As String
        Dim letter As String
        Dim Text1 As String = ""
        Dim Text2 As String = ""
        Dim i, Pos
        ' Use Text1 to execute  a litle faster than TextBox1(0)
        Text1 = strSource
        ' Iterate through each character of the from Text string
        For i = 1 To Len(Text1)
            letter = Mid(Text1, i, 1)
            ' Leave Carriage Return and Line Feed characters as is
            If (letter = vbCr) Then
                Text2 = Text2 & vbCr
            ElseIf (letter = vbLf) Then
                Text2 = Text2 & vbLf
            Else
                ' Find position of character in the vowel list
                Pos = InStr(UVowels, letter)
                If Pos <= 0 Then
                    ' Not found - so do  not map
                    Text2 = Text2 & letter
                Else
                    ' Found - so pick the corresponding character in the other vowel list
                    Text2 = Text2 & Mid(UNoneff, Pos, 1)
                End If
            End If
        Next
        Return Text2
    End Function
    Public Function ConvertUnicode_TCVN(ByVal strSource As String) As String
        Try
            Dim letter As String
            Dim Text1 As String = ""
            Dim Text2 As String = ""
            Dim i, Pos
            ' Use Text1 to execute  a litle faster than TextBox1(0)
            Text1 = strSource
            ' Iterate through each character of the from Text string
            For i = 1 To Len(Text1)
                letter = Mid(Text1, i, 1)
                ' Leave Carriage Return and Line Feed characters as is
                If (letter = vbCr) Then
                    Text2 = Text2 & vbCr
                ElseIf (letter = vbLf) Then
                    Text2 = Text2 & vbLf
                Else
                    ' Find position of character in the vowel list
                    Pos = InStr(UVowels, letter)
                    If Pos <= 0 Then
                        ' Not found - so do  not map
                        Text2 = Text2 & letter
                    Else
                        ' Found - so pick the corresponding character in the other vowel list
                        Text2 = Text2 & Mid(Vowels, Pos, 1)
                    End If
                End If
            Next
            Return Text2
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Public Function ConvertTCVN_Unicode(ByVal strSource As String) As String
        Try
            Dim letter As String
            Dim Text1 As String = ""
            Dim Text2 As String = ""
            Dim i, Pos
            ' Use Text1 to execute  a litle faster than TextBox1(0)
            Text1 = strSource
            ' Iterate through each character of the from Text string
            For i = 1 To Len(Text1)
                letter = Mid(Text1, i, 1)
                ' Leave Carriage Return and Line Feed characters as is
                If (letter = vbCr) Then
                    Text2 = Text2 & vbCr
                ElseIf (letter = vbLf) Then
                    Text2 = Text2 & vbLf
                Else
                    ' Find position of character in the vowel list
                    Pos = InStr(Vowels, letter)
                    If Pos <= 0 Then
                        ' Not found - so do  not map
                        Text2 = Text2 & letter
                    Else
                        ' Found - so pick the corresponding character in the other vowel list
                        Text2 = Text2 & Mid(UVowels, Pos, 1)
                    End If
                End If
            Next
            Return Text2
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function OpenDataSetAccess(ByVal strSQL As String) As DataSet
        Dim strCnn As String
        Dim fileName As String = "Lang.mdb"
        If Not System.IO.File.Exists(fileName) Then
            Return Nothing
        End If
        strCnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & fileName & ";Jet OLEDB:Database Password=2010;Mode=ReadWrite|Share Deny None;Persist Security Info=False"
        Dim cn As New System.Data.OleDb.OleDbConnection(strCnn)
        Try
            cn.Open()
        Catch ex As Exception
            Return Nothing
        End Try
        Dim da As New System.Data.OleDb.OleDbDataAdapter(strSQL, cn)
        da.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet
        Try
            da.Fill(ds)
            cn.Close()
        Catch e As Exception
            cn.Close()
            Return Nothing
        End Try
        cn.Close()

        Return ds
    End Function
End Module
