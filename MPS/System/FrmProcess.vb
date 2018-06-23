Public Class FrmProcess
    Private m_Title As String = ""


    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(ByVal Value As String)
            m_Title = Value
            lblLable.Text = m_Title
        End Set
    End Property
End Class