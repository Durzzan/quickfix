Public Class frmAvailability



    Private Sub frmAvailability_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hides the start form
        frmStart.Hide()
        'checks weather the user is a student and files in the name correctly
        If usertype = 1 Then
            lblname.Text = "welcome " + student.Forename.Trim + " " + student.Surname.Trim
        ElseIf usertype = 2 Then
            lblname.Text = "welcome " + Staff.Forename.Trim + " " + Staff.Surname.Trim
        End If
        'populates the checked list box containing appointment blocks 

        If Appointmentlength = 5 Then
            'appointmetn length is 5 minuets
            For counter As Integer = 1 To NDay
                'start and finish times for each day are retrived
                Day = GetDay(counter)
                For counter2 As Integer = 0 To (Day.finish - Day.Start) \ 6 - 2
                    'for each appintment an item is added contianinng the appointment number changed into a 24 hour time
                    chklstavailability.Items.Add("Day " + counter.ToString + " " + militarytime(Day.Start + (counter2 * 6)) + " to " + militarytime(Day.Start + 12 + (counter2 * 6)))
                Next
            Next
        Else
            'appointment lent is 10 minuetes
            For counter As Integer = 1 To NDay
                'start and finish times for each day are retrived
                Day = GetDay(counter)
                For counter2 As Integer = 0 To (Day.finish - Day.Start) \ 6 - 4
                    'for each appintment an item is added contianinng the appointment number changed into a 24 hour time
                    chklstavailability.Items.Add("Day " + counter.ToString + " " + militarytime(Day.Start + (counter2 * 6)) + " to " + militarytime(Day.Start + 18 + (counter2 * 6)))
                Next
            Next
        End If
    End Sub

    Private Sub chklst_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstavailability.ItemCheck
        'handles the chanaging of availablitity for a blcok
        Dim parts() As String = Split(chklstavailability.SelectedItem, " ")
        'checks if the availability is turned on or off
        If chklstavailability.GetItemChecked(chklstavailability.SelectedIndex) = False Then
            'availability turned on
            If usertype = 1 Then
                'student
                If Appointmentlength = 5 Then
                    'appointment length 5
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 5)
                        'finds relevant stud av records that are in the first half hour of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 1 to  their block number
                        StudAv.available = True
                        StudAv.Block += 1
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(3)) \ 100) * 100)) / 5) + 11)
                        'finds relevant stud av records that are in the second half hour of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 2 to  their block number
                        StudAv.available = True
                        StudAv.Block += 2
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                Else
                    'appointment length 10

                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 4) Step 2
                        'finds relevant stud av records that are in the first third of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 1 to  their block number
                        StudAv.available = True
                        StudAv.Block += 1
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 10) Step 2
                        'finds relevant stud av records that are in the second third of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 2 to  their block number
                        StudAv.available = True
                        StudAv.Block += 2
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 12 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 16) Step 2
                        'finds relevant stud av records that are in the last third of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 4 to  their block number
                        StudAv.available = True
                        StudAv.Block += 4
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                End If
            Else
                'staff
                'appointment length 5
                If Appointmentlength = 5 Then
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 5)
                        'finds relevant stud av records that are in the first half hour of the block
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 1 to  their block number
                        StaffAv.Available = True
                        StaffAv.Block += 1
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6) To (((parts(2) \ 100) + (((parts(2)) - (((parts(3)) \ 100) * 100)) / 5) + 11))
                        'finds relevant stud av records that are in the second half hour of the block
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 2 to  their block number
                        StaffAv.Available = True
                        StaffAv.Block += 2
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                Else
                    'appointment length 10

                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 4) Step 2
                        'finds relevant stud av records that are in the first half hour of the block
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 1 to  their block number
                        StaffAv.Available = True
                        StaffAv.Block += 1
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 10) Step 2
                        'finds relevant stud av records that are in the second half hour of the block
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 2 to  their block number
                        StaffAv.Available = True
                        StaffAv.Block += 2
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 12 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 16) Step 2
                        'finds relevant stud av records that are in the third half hour of the block
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets them to available and addes 4 to  their block number
                        StaffAv.Available = True
                        StaffAv.Block += 4
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                End If
            End If
        Else
            'box is unchecked 
            If usertype = 1 Then
                'student
                If Appointmentlength = 5 Then
                    'appointment lenght 5
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 5)
                        'finds relevant stud av records that are in the first half hour of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 1
                        StudAv.Block -= 1
                        If StudAv.Block = 0 Then
                            StudAv.available = False
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(3)) \ 100) * 100)) / 5) + 11)
                        'finds relevant stud av records that are in the second half hour of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 2
                        StudAv.Block -= 2
                        If StudAv.Block = 0 Then
                            StudAv.available = False
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                Else
                    'appointment length 10
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 4) Step 2
                        'finds relevant stud av records that are in the first half hour of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 1
                        StudAv.Block -= 1
                        If StudAv.Block = 0 Then
                            StudAv.available = False
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 10) Step 2
                        'finds relevant stud av records that are in the second half hour of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 2
                        StudAv.Block -= 2
                        If StudAv.Block = 0 Then
                            StudAv.available = False
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 12 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 16) Step 2
                        'finds relevant stud av records that are in the third half hour of the block
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 4
                        StudAv.Block -= 4
                        If StudAv.Block = 0 Then
                            StudAv.available = False
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                End If
            Else
                'staff
                If Appointmentlength = 5 Then
                    'appointment length 5
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 5)
                        'finds relevant stud av records that are in the first half hour of the block
                        For counter1 As Integer = 1 To Nstaff
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 1
                        StaffAv.Block -= 1
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = False
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(3)) \ 100) * 100)) / 5) + 11)
                        'finds relevant stud av records that are in the second half hour of the block
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 2
                        StaffAv.Block -= 2
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = False
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                Else
                    'appointment length 10
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 4) Step 2
                        'finds relevant stud av records that are in the first half hour of the block
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 1
                        StaffAv.Block -= 1
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = False
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 10) Step 2
                        'finds relevant stud av records that are in the second half hour of the block
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 2
                        StaffAv.Block -= 2
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = False
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 12 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 16) Step 2
                        'finds relevant stud av records that are in the first half hour of the block
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        'sets there availability to false if block number is 0 after decreasing it by 4
                        StaffAv.Block -= 4
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = False
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'closes the availability form and opens the start form
        frmStart.Show()
        Me.Close()
    End Sub
End Class
