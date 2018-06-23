'Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class DALAccess
    Dim m_SERVER As String = Application.StartupPath & "\dbBMSBarcode.mdb"
    Property SERVER() As String
        Get
            Return m_SERVER
        End Get
        Set(ByVal value As String)
            m_SERVER = value
        End Set
    End Property
    Public Function OpenDataSet(ByVal strSQL As String) As DataSet
        Dim strCnn As String
        strCnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & m_SERVER & ";Jet OLEDB:Database Password='';Mode=ReadWrite|Share Deny None;Persist Security Info=False"

        Dim cn As New OleDbConnection(strCnn)
        Try
            cn.Open()
        Catch ex As Exception
            MessageBox.Show("Không kết nối được cơ sở dữ liệu", "VsoftBMS-POS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.Message)
        End Try
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet
        Try
            da.Fill(ds)
            cn.Close()
        Catch e As Exception
            MessageBox.Show("Lỗi truy xuất dữ liệu", "VsoftBMS-POS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(e.Message)
        End Try
        cn.Close()
        Return (ds)
    End Function
    Public Function ExecuteSQL(ByVal strSQL As String) As Boolean
        Dim strCnn As String
        strCnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & m_SERVER & ";Jet OLEDB:Database Password='';Mode=ReadWrite|Share Deny None;Persist Security Info=False"
        Dim cn As New OleDbConnection(strCnn)
        Dim cmd As OleDbCommand = New OleDbCommand(strSQL, cn)
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function


End Class
