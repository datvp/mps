Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsReportBarcode
    Public Function InitReport(ByVal strFileName As String) As ReportDocument
        Try
            Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
            Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
            Dim rp As New ReportDocument
            rp.Load(strFileName)
            For Each tbCurrent In rp.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = Application.StartupPath & "\dbBMSBarcode.mdb" 'sFilePath
                    .UserID = ""
                    .Password = ""
                    .DatabaseName = "dbBMSBarcode.mdb" 'sFilePath
                End With
                'tbCurrent.Location = DatabaseName.Trim & ".dbo." & tbCurrent.Name
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent
            Return rp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function
    'Public Function InitReport(ByVal strFileName As String, ByVal sFilePath As String) As ReportDocument
    '    Try
    '        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
    '        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
    '        Dim rp As New ReportDocument
    '        rp.Load(strFileName)
    '        For Each tbCurrent In rp.Database.Tables
    '            tliCurrent = tbCurrent.LogOnInfo
    '            With tliCurrent.ConnectionInfo
    '                .ServerName = sFilePath
    '                .UserID = ""
    '                .Password = ""
    '                .DatabaseName = sFilePath
    '            End With
    '            'tbCurrent.Location = DatabaseName.Trim & ".dbo." & tbCurrent.Name
    '            tbCurrent.ApplyLogOnInfo(tliCurrent)
    '        Next tbCurrent
    '        Return rp
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return Nothing
    '    End Try

    'End Function

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

    Public Function SetParameter(ByVal rpt As ReportDocument, ByVal lst As IList(Of Object)) As ReportDocument

        For i As Integer = 0 To lst.Count - 1
            rpt.SetParameterValue(i, lst.Item(i))
        Next
        Return rpt
    End Function
End Class
