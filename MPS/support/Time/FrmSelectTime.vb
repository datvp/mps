Imports Infragistics.Win.UltraWinSchedule
Public Class FrmSelectTime
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub New(ByVal fromDate As Date, ByVal toDate As Date)
        Me.InitializeComponent()
        dtFrom.Value = fromDate
        dtTo.Value = toDate
        Me.UltraCalendarInfo1.ActiveDay = Me.UltraCalendarInfo1.GetDay(fromDate, True)
        Me.UltraCalendarInfo2.ActiveDay = Me.UltraCalendarInfo1.GetDay(toDate, True)

    End Sub

    Dim d1 As Date = Now 'CDate("1900-1-1")
    Dim d2 As Date = Now 'CDate("1900-1-1")
    Dim isView As Boolean = False

    Public Overloads Sub ShowDialog(ByRef fromDate As Date, ByRef toDate As Date, ByRef b_isView As Boolean)
        Me.ShowDialog()

        fromDate = d1
        toDate = d2
        b_isView = isView
        Me.Close()
    End Sub
    Public Overloads Sub ShowDialog(ByRef fromDate As Date, ByRef toDate As Date, ByRef b_isView As Boolean, ByVal isEditDate As Boolean)
        Me.ShowDialog()

        fromDate = d1
        toDate = d2
        b_isView = isView
        isEditDate = chEditDate.Checked
        Me.Close()
    End Sub
    Private b_isFrom As Boolean = False
    Private isLoad As Boolean = False
    Private Sub FrmSelectTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me,UltraLabel1.Text)
        isLoad = True
        dtFrom.Focus()
    End Sub

    Private Sub dtFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFrom.ValueChanged
        If isLoad Then
            If Me.UltraCalendarInfo1.ActiveDay.Date <> dtFrom.Value Then
                Me.UltraCalendarInfo1.ActiveDay = Me.UltraCalendarInfo1.GetDay(dtFrom.Value, True)

            End If

            If dtTo.Value < dtFrom.Value Then
                dtTo.Value = dtFrom.Value
            End If

        End If

    End Sub
    Private Sub dtTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTo.ValueChanged
        If isLoad Then
            If Me.UltraCalendarInfo2.ActiveDay.Date <> dtTo.Value Then
                Me.UltraCalendarInfo2.ResetActiveDay()
                Me.UltraCalendarInfo2.ActiveDay = Me.UltraCalendarInfo2.GetDay(dtTo.Value, True)
            End If

            If dtFrom.Value > dtTo.Value Then
                dtFrom.Value = dtTo.Value
            End If

        End If

    End Sub

    Private Sub UltraCalendarInfo1_AfterActiveDayChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.AfterActiveDayChangedEventArgs) Handles UltraCalendarInfo1.AfterActiveDayChanged
        If isLoad Then

            If dtFrom.Value <> Me.UltraCalendarInfo1.ActiveDay.Date Then
                Me.dtFrom.Value = Me.UltraCalendarInfo1.ActiveDay.Date
            End If

            If Me.UltraCalendarInfo2.ActiveDay.Date < Me.UltraCalendarInfo1.ActiveDay.Date Then
                Me.UltraCalendarInfo2.ActiveDay = Me.UltraCalendarInfo1.ActiveDay
            End If

        End If

    End Sub
    Private Sub UltraCalendarInfo2_AfterActiveDayChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.AfterActiveDayChangedEventArgs) Handles UltraCalendarInfo2.AfterActiveDayChanged
        If isLoad Then
            If dtTo.Value <> Me.UltraCalendarInfo2.ActiveDay.Date Then
                Me.dtTo.Value = Me.UltraCalendarInfo2.ActiveDay.Date
            End If

            If Me.UltraCalendarInfo1.ActiveDay.Date > Me.UltraCalendarInfo2.ActiveDay.Date Then
                Me.UltraCalendarInfo1.ActiveDay = Me.UltraCalendarInfo2.ActiveDay
            End If

        End If

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        d1 = dtFrom.Value
        d2 = dtTo.Value
        isView = True
        Me.Close()
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'd1 = Me.UltraCalendarInfo1.ActiveDay.Date
        'd2 = Me.UltraCalendarInfo2.ActiveDay.Date
        d1 = Now 'dtFrom.Value
        d2 = Now 'dtTo.Value
        isView = False
    End Sub

End Class