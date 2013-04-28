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

        'clears the secondary comboboxes
        cmbStart.Items.Clear()
        cmbEnd.Items.Clear()
        cmbDay.Items.Clear()
        'resets the day settings
        For counter As Integer = 1 To NDay
            Day.DayNO = counter
            Day.finish = 288
            Day.Start = 0
            Putday(Day, Day.DayNO)
        Next

        'calls the subroutine second half which decided weather to complete the other repacutions of changing the appointment length
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

        'clears the secondary comboboxes
        cmbStart.Items.Clear()
        cmbEnd.Items.Clear()
        cmbDay.Items.Clear()
        'resets the day settings
        For counter As Integer = 1 To NDay
            Day.DayNO = counter
            Day.finish = 288
            Day.Start = 0
            Putday(Day, Day.DayNO)
        Next
        'calls the subroutine second half which decided weather to complete the other repacutions of changing the number of days
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

        'clears the secondary comboboxes
        cmbStart.Items.Clear()
        cmbEnd.Items.Clear()
        cmbDay.Items.Clear()
        'resets the day settings
        For counter As Integer = 1 To NDay
            Day.DayNO = counter
            Day.finish = 288
            Day.Start = 0
            Putday(Day, Day.DayNO)
        Next
        'calls the subroutine second half which decided weather to complete the other repacutions of changing the appointment length
        Call secondhalf()
    End Sub

    Private Sub cmbDay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDay.SelectedIndexChanged
        'calls the subrootine that will populate cmbstart and cmbend
        Call populateStartEndDaySettings()
    End Sub

    Private Sub cmbStart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStart.SelectedIndexChanged
        Dim hours As Integer = (cmbStart.SelectedItem) \ 100
        Dim minuets As Integer = ((cmbStart.SelectedItem) - (((cmbStart.SelectedItem) \ 100) * 100)) / 5

        'eliminates any accidental loops
        If change = True Then
            change = False
            Exit Sub
        End If
        'sets the start time for the day selected
        Day.Start = (hours * 12) + minuets
        Day.DayNO = cmbDay.SelectedItem
        Putday(Day, Day.DayNO)
        'clears the cmbstart andc cmbend
        cmbEnd.Items.Clear()
        cmbStart.Items.Clear()
        'calls the subroutine to populate cmbstart and cmbend
        Call populateStartEndDaySettings()
        change = True
        'selects the start time in cmbstart
        cmbStart.SelectedIndex = Day.Start / 6
        change1 = True
        'selects the end time in cmbend
        If Appointmentlength = 5 Then
            cmbEnd.SelectedIndex = (Day.finish - Day.Start) \ 6 - 2
        Else
            cmbEnd.SelectedIndex = (Day.finish - Day.Start) \ 6 - 3
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        'closes the form
        Me.Close()
    End Sub

    Private Sub cmbEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEnd.SelectedIndexChanged
        Dim hours As Integer = (cmbEnd.SelectedItem) \ 100
        Dim minuets As Integer = ((cmbEnd.SelectedItem) - (((cmbEnd.SelectedItem) \ 100) * 100)) / 5
        'eliminates accidental loops
        If change1 = True Then
            change1 = False
            Exit Sub
        End If
        'sets the end time for the day selected
        Day.finish = (hours * 12) + minuets
        Day.DayNO = cmbDay.SelectedItem
        Putday(Day, Day.DayNO)
        'clears cmbend and cmbstart
        cmbEnd.Items.Clear()
        cmbStart.Items.Clear()
        'calls the subroutine to populate cmbstart and cmbend
        Call populateStartEndDaySettings()
        change = True
        'selscts the start time in cmbstart
        cmbStart.SelectedIndex = Day.Start / 6
        change1 = True
        'selects the end time in cmbend
        If Appointmentlength = 5 Then
            cmbEnd.SelectedIndex = (Day.finish - Day.Start) \ 6 - 2
        Else
            cmbEnd.SelectedIndex = (Day.finish - Day.Start) \ 6 - 3
        End If
    End Sub
End Class