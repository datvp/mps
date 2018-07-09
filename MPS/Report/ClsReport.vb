Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class ClsReport

    Public Function InitReport_old(ByVal strFileName As String) As ReportDocument
        Try
            If Not System.IO.File.Exists(strFileName) Then
                ShowMsg("File not found(" & strFileName & ")", m_MsgCaption)
                Return Nothing
            End If
            Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
            Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
            Dim rp As New ReportDocument
            rp.Load(strFileName)

            Dim connection As IConnectionInfo
            For Each connection In rp.DataSourceConnections
                connection.SetConnection(m_Srv, m_DB, m_UID, m_PWD)

                'connection.SetLogon(m_UID, m_PWD)
            Next
            If Not rp.Subreports Is Nothing Then
                For Each it As ReportDocument In rp.Subreports
                    For Each connection In it.DataSourceConnections
                        connection.SetConnection(m_Srv, m_DB, m_UID, m_PWD)
                    Next
                Next
            End If

            For Each tbCurrent In rp.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                'Dim s As String = tliCurrent.TableName
                With tliCurrent.ConnectionInfo
                    .ServerName = ModMain.m_Srv
                    .UserID = ModMain.m_UID
                    .Password = ModMain.m_PWD
                    .DatabaseName = ModMain.m_DB
                End With
                'tbCurrent.Location = m_DB.Trim & ".dbo." & tbCurrent.Name

                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next
            If Not rp.Subreports Is Nothing Then
                For Each it As ReportDocument In rp.Subreports

                    For Each tbCurrent In it.Database.Tables
                        tliCurrent = tbCurrent.LogOnInfo
                        'Dim s As String = tliCurrent.TableName
                        With tliCurrent.ConnectionInfo
                            .ServerName = ModMain.m_Srv
                            .UserID = ModMain.m_UID
                            .Password = ModMain.m_PWD
                            .DatabaseName = ModMain.m_DB
                        End With
                        'tbCurrent.Location = DatabaseName.Trim & ".dbo." & tbCurrent.Name

                        tbCurrent.ApplyLogOnInfo(tliCurrent)
                    Next

                Next
            End If
            'Tuu19.06.2010
            Dim m As CrystalDecisions.Shared.PageMargins = rp.PrintOptions.PageMargins
            m.rightMargin = 100
            m.leftMargin = 300
            rp.PrintOptions.ApplyPageMargins(m)

            Return rp
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Nothing
    End Function

    Public Function InitReport(ByVal strFileName As String) As ReportDocument
        Try
            If Not System.IO.File.Exists(strFileName) Then
                ShowMsg("File not found(" & strFileName & ")", m_MsgCaption)
                Return Nothing
            End If

            Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
            Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
            Dim rp As New ReportDocument
            rp.Load(strFileName)

            Dim connection As IConnectionInfo
            For Each connection In rp.DataSourceConnections
                For i As Integer = 0 To rp.DataSourceConnections.Count - 1
                    rp.DataSourceConnections(i).SetConnection(m_Srv, m_DB, False)
                    rp.DataSourceConnections(i).SetLogon(m_UID, m_PWD)
                Next
            Next

            If Not rp.Subreports Is Nothing Then
                For Each it As ReportDocument In rp.Subreports
                    For Each connection In it.DataSourceConnections
                        For i As Integer = 0 To it.DataSourceConnections.Count - 1
                            it.DataSourceConnections(i).SetConnection(m_Srv, m_DB, False)
                            it.DataSourceConnections(i).SetLogon(m_UID, m_PWD)
                        Next
                    Next
                Next
            End If

            For Each tbCurrent In rp.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = m_Srv
                    .UserID = m_UID
                    .Password = m_PWD
                    .DatabaseName = m_DB
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next
            If Not rp.Subreports Is Nothing Then
                For Each it As ReportDocument In rp.Subreports

                    For Each tbCurrent In it.Database.Tables
                        tliCurrent = tbCurrent.LogOnInfo
                        With tliCurrent.ConnectionInfo
                            .ServerName = m_Srv
                            .UserID = m_UID
                            .Password = m_PWD
                            .DatabaseName = m_DB
                        End With

                        tbCurrent.ApplyLogOnInfo(tliCurrent)
                    Next

                Next
            End If

            'Tuu19.06.2010
            Dim m As CrystalDecisions.Shared.PageMargins = rp.PrintOptions.PageMargins
            m.rightMargin = 100
            m.leftMargin = 100
            rp.PrintOptions.ApplyPageMargins(m)
            Dim sFile As String = strFileName.Substring(Application.StartupPath.Length, strFileName.Length - Application.StartupPath.Length)

            If m_Lang <> 1 Then
                For Each obj As ReportObject In rp.ReportDefinition.ReportObjects
                    Try
                        Dim stype As String = obj.GetType.ToString

                        If stype = "CrystalDecisions.CrystalReports.Engine.TextObject" Then
                            Dim objtxt As CrystalDecisions.CrystalReports.Engine.TextObject = obj
                            If objtxt.Text.ToString.Trim <> "" AndAlso objtxt.Text.IndexOf(Chr(10)) = -1 Then
                                objtxt.Text = objtxt.Text
                            Else
                                Dim sDate As String = objtxt.Text
                                sDate = sDate.Replace("  ", " ")
                                sDate = sDate.Replace(Chr(10), String.Empty)
                                '"Ngày PrintDate tháng PrintDate năm PrintDate"

                                If sDate.ToLower = "Ngày PrintDate tháng PrintDate năm PrintDate".ToLower Then
                                    Dim sD As String = Format(Now, "dd")
                                    Dim sM As String = Format(Now, "MM")
                                    Dim sY As String = Format(Now, "yyyy")
                                    Dim sInfo As String = "Ngày " & sD & " tháng " & sM & " năm " & sY
                                    objtxt.Text = sInfo
                                End If
                            End If

                        End If
                        If stype = "CrystalDecisions.CrystalReports.Engine.FieldHeadingObject" Then
                            Dim objtxt As CrystalDecisions.CrystalReports.Engine.FieldHeadingObject = obj
                            If objtxt.Text.ToString.Trim <> "" AndAlso objtxt.Text.IndexOf(Chr(10)) = -1 Then
                                objtxt.Text = objtxt.Text
                            End If
                        End If
                        If stype = "CrystalDecisions.CrystalReports.Engine.SubreportObject" Then
                            Dim subobj As SubreportObject = obj
                            Dim rpSub As ReportDocument = subobj.OpenSubreport(subobj.SubreportName)
                            For Each objsub As ReportObject In rpSub.ReportDefinition.ReportObjects
                                stype = objsub.GetType.ToString
                                If stype = "CrystalDecisions.CrystalReports.Engine.TextObject" Then
                                    If rpSub.Name.ToLower.IndexOf("header.rpt") <> -1 Then
                                        If Not mbc Is Nothing Then
                                            Dim objtxt As CrystalDecisions.CrystalReports.Engine.TextObject = objsub
                                            Dim sInfo As String = ""
                                            Select Case objtxt.Name.ToLower
                                                Case "text22", "text23"
                                                    sInfo = "Địa chỉ: " & mbc.s_Address
                                                Case "text24", "text26"
                                                    sInfo = "Điện thoại: " & mbc.s_Phone1.Trim
                                                    If mbc.s_Phone2 <> "" Then
                                                        sInfo += " " & mbc.s_Phone2.Trim
                                                    End If
                                                    sInfo += " - Fax: " & mbc.s_Fax.Trim

                                                Case "text25", "text27"
                                                    sInfo = "Email: " & mbc.s_Email.Trim
                                                    sInfo += " - Website: " & mbc.s_Website.Trim
                                            End Select
                                            objtxt.Text = sInfo
                                        End If


                                    Else
                                        Dim objtxt As CrystalDecisions.CrystalReports.Engine.TextObject = objsub
                                        If objtxt.Text.ToString.Trim <> "" AndAlso objtxt.Text.IndexOf(Chr(10)) = -1 Then
                                            objtxt.Text = objtxt.Text
                                        End If
                                    End If

                                End If

                            Next
                        End If
                    Catch ex1 As Exception
                        Dim strError As String = ex1.Message
                    End Try

                Next
            End If


            Return rp
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Nothing
    End Function
    Private Function DetachFomular(ByVal sReport As String) As DataTable
        Dim tb As New DataTable
        tb.Columns.Add("s")
        tb.Columns.Add("isText", GetType(Boolean))
        'tb.Columns.Contains 
        Dim ind As Integer = sReport.IndexOf(Chr(10))
        If ind = -1 Then
            Dim drN As DataRow = tb.NewRow
            drN("s") = sReport
            drN("isText") = True
            tb.Rows.Add(drN)
        Else
            Dim s As String = sReport.Replace(Chr(10), "*")
            For i As Integer = 0 To sReport.Length - 1
                Dim ch As String = sReport.Substring(i, 1)
                If ch = Chr(10) Then
                    If i <> 0 Then

                    End If
                End If
            Next
        End If
        '"C:*PrintDate*{@tt}*PrintTime*A*PrintTime"
        '"PrintDate*PrintTime"
        '"C:*PrintDate*{@tt}*PrintTime*A"
        '"C:*PrintDate"
        '"Filename"
        Return tb
    End Function
    Private Function TranslateStringToCRFormula(ByVal VBString As String) As String

        Dim Returnstring As String = "'"
        Dim arrS() As String = VBString.Split(Chr(10))
        'Split the string at every LF 
        For Each SubString As String In arrS

            SubString = SubString.Replace("'", "' & Chr(39) & '")

            'Trim all the CR / LF characters 
            SubString = SubString.Trim(vbCrLf.ToCharArray)

            'Form your string to the compatible CR Formula format. Chr(10) &nd Chr(13) should be inserted as a string, not as values!! 
            Returnstring = Returnstring & "' & Chr(10) & Chr(13) & '" & SubString

        Next

        Returnstring = Returnstring & "'"

        Return Returnstring

    End Function
    Private Function TranslateStringToCRFormula11(ByVal strValue As String) As String
        Dim Returnstring As String = "'"
        Dim i As Integer = 0

        'Split the string at every LF 
        Dim arrS() As String = strValue.Split(Chr(10))
        For Each SubString As String In arrS
            'Trim all the CR / LF characters 
            SubString = SubString.Trim(vbCrLf.ToCharArray)

            If i > 0 Then
                Returnstring &= "' & Chr(10) & Chr(13) & '"
            End If
            i += 1

            SubString = SubString.Replace("'", "' & Chr(39) & '")

            Returnstring &= SubString

        Next

        Returnstring = Returnstring & "'"

        Return Returnstring

    End Function
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object)
        rp.SetParameterValue(0, value1)
    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object)
        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object, ByVal value3 As Object)
        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
        rp.SetParameterValue(2, value3)
    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object, ByVal value3 As Object, _
                            ByVal value4 As Object)
        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
        rp.SetParameterValue(2, value3)
        rp.SetParameterValue(3, value4)
    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object, ByVal value3 As Object, _
                            ByVal value4 As Object, ByVal value5 As Object)

        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
        rp.SetParameterValue(2, value3)
        rp.SetParameterValue(3, value4)
        rp.SetParameterValue(4, value5)

    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object, ByVal value3 As Object, _
                            ByVal value4 As Object, ByVal value5 As Object, ByVal value6 As Object)
        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
        rp.SetParameterValue(2, value3)
        rp.SetParameterValue(3, value4)
        rp.SetParameterValue(4, value5)
        rp.SetParameterValue(5, value6)
    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object, ByVal value3 As Object, _
                            ByVal value4 As Object, ByVal value5 As Object, ByVal value6 As Object, ByVal value7 As Object)
        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
        rp.SetParameterValue(2, value3)
        rp.SetParameterValue(3, value4)
        rp.SetParameterValue(4, value5)
        rp.SetParameterValue(5, value6)
        rp.SetParameterValue(6, value7)
    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object, _
                            ByVal value3 As Object, ByVal value4 As Object, ByVal value5 As Object, ByVal value6 As Object, _
                            ByVal value7 As Object, ByVal value8 As Object)
        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
        rp.SetParameterValue(2, value3)
        rp.SetParameterValue(3, value4)
        rp.SetParameterValue(4, value5)
        rp.SetParameterValue(5, value6)
        rp.SetParameterValue(6, value7)
        rp.SetParameterValue(7, value8)
    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object, ByVal value3 As Object, _
                            ByVal value4 As Object, ByVal value5 As Object, ByVal value6 As Object, ByVal value7 As Object, _
                            ByVal value8 As Object, ByVal value9 As Object)
        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
        rp.SetParameterValue(2, value3)
        rp.SetParameterValue(3, value4)
        rp.SetParameterValue(4, value5)
        rp.SetParameterValue(5, value6)
        rp.SetParameterValue(6, value7)
        rp.SetParameterValue(7, value8)
        rp.SetParameterValue(8, value9)
    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object, ByVal value3 As Object, _
                            ByVal value4 As Object, ByVal value5 As Object, ByVal value6 As Object, ByVal value7 As Object, _
                            ByVal value8 As Object, ByVal value9 As Object, ByVal value10 As Object)
        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
        rp.SetParameterValue(2, value3)
        rp.SetParameterValue(3, value4)
        rp.SetParameterValue(4, value5)
        rp.SetParameterValue(5, value6)
        rp.SetParameterValue(6, value7)
        rp.SetParameterValue(7, value8)
        rp.SetParameterValue(8, value9)
        rp.SetParameterValue(9, value10)
    End Sub
    Public Sub SetParameter(ByRef rp As ReportDocument, ByVal value1 As Object, ByVal value2 As Object, ByVal value3 As Object, _
                            ByVal value4 As Object, ByVal value5 As Object, ByVal value6 As Object, ByVal value7 As Object, _
                            ByVal value8 As Object, ByVal value9 As Object, ByVal value10 As Object, ByVal value11 As Object)
        rp.SetParameterValue(0, value1)
        rp.SetParameterValue(1, value2)
        rp.SetParameterValue(2, value3)
        rp.SetParameterValue(3, value4)
        rp.SetParameterValue(4, value5)
        rp.SetParameterValue(5, value6)
        rp.SetParameterValue(6, value7)
        rp.SetParameterValue(7, value8)
        rp.SetParameterValue(8, value9)
        rp.SetParameterValue(9, value10)
        rp.SetParameterValue(10, value11)
    End Sub
    Public Function SetParameter(ByVal rpt As ReportDocument, ByVal lst As IList(Of Object)) As ReportDocument

        For i As Integer = 0 To lst.Count - 1
            rpt.SetParameterValue(i, lst.Item(i))
        Next
        Return rpt
    End Function

End Class
