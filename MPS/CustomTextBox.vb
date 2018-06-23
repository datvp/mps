Public Class CustomTextBox
    Inherits Infragistics.Win.UltraWinEditors.UltraTextEditor

    Private isPlaceHolder As Boolean = True
    Private _placeHolderText As String
    Public Property PlaceHolderText() As String
        Get
            Return _placeHolderText
        End Get
        Set(ByVal value As String)
            _placeHolderText = value
            setPlaceholder()
        End Set
    End Property

    'when the control loses focus, the placeholder is shown
    Private Sub setPlaceholder()
        If String.IsNullOrEmpty(Me.Text) Then
            Me.Text = PlaceHolderText
            Me.ForeColor = Color.Gray
            Me.Font = New Font(Me.Font, FontStyle.Italic)
            isPlaceHolder = True
        End If
    End Sub

    'when the control is focused, the placeholder is removed
    Private Sub removePlaceHolder()

        If isPlaceHolder Then
            Me.Text = ""
            Me.ForeColor = System.Drawing.SystemColors.WindowText
            Me.Font = New Font(Me.Font, FontStyle.Regular)
            isPlaceHolder = False
        End If
    End Sub
    Public Sub New()
        AddHandler KeyDown, AddressOf removePlaceHolder
        AddHandler LostFocus, AddressOf setPlaceholder
    End Sub

    Private Sub setPlaceholder(ByVal sender As Object, ByVal e As EventArgs)
        setPlaceholder()
    End Sub

    Private Sub removePlaceHolder(ByVal sender As Object, ByVal e As EventArgs)
        removePlaceHolder()
    End Sub
End Class