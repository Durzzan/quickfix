Public Class frmDaySettings
    'used in the time selecting subroutines
    Public change As Boolean = False
    Public change1 As Boolean = False
    Private Sub rad5min_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad5min.CheckedChanged
        'checks if the the 5 min radio button is checked and if it is sets the appointmetn length to 5 mins
        'otherwise it sets the appointment length to 10 mins
        If rad5min.Checked = True Then
            Appointmentlength = 5
        Else
            Appointmentlength = 10
        End If

        Call secondhalf()
    End Sub

    Private Sub frmDaySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'populates the dropdown combobox with numbers 1 to 255
        For counter As Integer = 1 To 255
            cmbNdays.Items.Add(counter)
        Next
    End Sub

    Private Sub cmbNdays_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNdays.SelectedIndexChanged
        'records the number of dayz
        NDay = cmbNdays.SelectedItem

        Call secondhalf()


    End Sub

    Public Sub secondhalf()
        'sub to check if the appointment length and day numbers have been chosen. if so it populates the
        'day.dat file
        If NDay <> -1 And Appointmentlength <> -1 Then
            For counter As Integer = 1 To NDay
                Day.DayNO = counter
                Day.Start = 0
                Day.finish = 288
                Putday(Day, counter)
            Next
        Else
            Exit Sub
        End If

        cmbDay.Visible = True
        cmbStart.Visible = True
        cmbEnd.Visible = True

        'populates the day selector combo box with each of the days
        cmbDay.Items.Clear()
        For counter = 1 To NDay
            cmbDay.Items.Add(counter)
        Next
    End Sub

    Private Sub rad10min_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad10min.CheckedChanged
        'records the new value of appintment length and checks if its ready to start hte second half
        Appointmentlength = 10
        Call secondhalf()
    End Sub

    Private Sub cmbDay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDay.SelectedIndexChanged
        Call populateStartEndDaySettings()
    End Sub

    Private Sub cmbStart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStart.SelectedIndexChanged
        Dim hours As Integer = (cmbStart.SelectedItem) \ 100
        Dim minuets As Integer = ((cmbStart.SelectedItem) - (((cmbStart.SelectedItem) \ 100) * 100)) / 5
        If change = True Then
            change = False
            Exit Sub
        End If
        Day.Start = (hours * 12) + minuets
        Day.DayNO = cmbDay.SelectedItem
        Putday(Day, Day.DayNO)
        cmbEnd.Items.Clear()
        cmbStart.Items.Clear()
        Call populateStartEndDaySettings()
        change = True
        cmbStart.SelectedIndex = Day.Start / 6
        change1 = True
        If Appointmentlength = 5 Then
            cmbEnd.SelectedIndex = (Day.finish - Day.Start) \ 6 - 2
        Else
            cmbEnd.SelectedIndex = (Day.finish - Day.Start) \ 6 - 3
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub cmbEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEnd.SelectedIndexChanged
        Dim hours As Integer = (cmbEnd.SelectedItem) \ 100
        Dim minuets As Integer = ((cmbEnd.SelectedItem) - (((cmbEnd.SelectedItem) \ 100) * 100)) / 5
        If change1 = True Then
            change1 = False
            Exit Sub
        End If
        Day.finish = (hours * 12) + minuets
        Day.DayNO = cmbDay.SelectedItem
        Putday(Day, Day.DayNO)
        cmbEnd.Items.Clear()
        cmbStart.Items.Clear()
        Call populateStartEndDaySettings()
        change = True
        cmbStart.SelectedIndex = Day.Start / 6
        change1 = True
        If Appointmentlength = 5 Then
            cmbEnd.SelectedIndex = (Day.finish - Day.Start) \ 6 - 2
        Else
            cmbEnd.SelectedIndex = (Day.finish - Day.Start) \ 6 - 3
        End If
    End Sub
End Class