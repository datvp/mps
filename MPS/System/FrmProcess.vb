Public Class FrmProcess
    Private Sub New()
        InitializeComponent()
    End Sub
    Private Shared obj As FrmProcess
    Public Shared ReadOnly Property Instance() As FrmProcess
        Get
            If obj Is Nothing Then
                obj = New FrmProcess
            End If
            Return obj
        End Get
    End Property
End Class