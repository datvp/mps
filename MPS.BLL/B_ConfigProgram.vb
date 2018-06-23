Public Class B_ConfigProgram

    Private WithEvents cls As New DAL.DAL_ConfigProgram
    Event _errorRaise(ByVal messege As String)
    Private Sub New()
    End Sub
    Private Shared obj As B_ConfigProgram
    Public Shared ReadOnly Property Instance() As B_ConfigProgram
        Get
            If obj Is Nothing Then
                obj = New B_ConfigProgram
            End If
            Return obj
        End Get
    End Property
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub
    Public Function CheckUpdate() As Boolean
        Return cls.CheckUpdate()
    End Function

    Public Function UPDATEDB(ByVal m As Model.MConfigProgram) As Boolean
        Return cls.UPDATEDB(m)
    End Function
    Public Function UpdateAlerTimeDownload(ByVal AutoCheckHQ As Boolean, ByVal nMinute As Integer) As Boolean
        Return cls.UpdateAlerTimeDownload(AutoCheckHQ, nMinute)
    End Function
    Public Function DELETEDB() As Boolean
        Return cls.DELETEDB()
    End Function
    Public Function UpdateConfigReport(ByVal tb As DataTable) As Boolean
        Return cls.UpdateConfigReport(tb)
    End Function
    Public Function GetConfigReport() As DataTable
        Return cls.GetConfigReport
    End Function
    Public Function getInfo() As Model.MConfigProgram
        Return cls.getInfo()
    End Function
    Public Function CheckSendHQOnLine(ByVal ID As Integer) As Boolean
        Return cls.CheckSendHQOnLine(ID)
    End Function
    Public Function UpdateSchedule(ByVal ID As Integer, ByVal dtTime As Date) As Boolean
        Return cls.UpdateSchedule(ID, dtTime)
    End Function
    Public Function UpdateOnlineHQ(ByVal ID As Integer, ByVal Online As Boolean) As Boolean
        Return cls.UpdateOnlineHQ(ID, Online)
    End Function
    Public Function GetConfigSendHQ() As DataTable
        Return cls.GetConfigSendHQ
    End Function
    Public Function getisChangeCurr(ByVal sCurr As String) As Boolean
        Return cls.getisChangeCurr(sCurr)
    End Function
    'Cot dung de in trong Barcode
    Public Function getCol_Bar() As DataTable
        Return cls.getCol_Bar()
    End Function
    'update cac cot in barcode
    Public Function Update_PrintBar(ByVal tb As DataTable) As Boolean
        Return cls.Update_PrintBar(tb)
    End Function
    Public Function Delete_PrintBar() As Boolean
        Return cls.Delete_PrintBar()
    End Function

    'phan giai ma thue ra 14 cot
    Public Function TachVAT(ByVal s As String) As Boolean
        Return cls.TachVAT(s)
    End Function
End Class
