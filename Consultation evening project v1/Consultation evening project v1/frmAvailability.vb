﻿Public Class frmAvailability
    Dim appointmentlength As Integer = 10
    Dim nday As Integer = 2


    Private Sub frmAvailability_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        frmStart.Hide()
        If usertype = 1 Then
            lblname.Text = "welcome " + student.Forename.Trim + " " + student.Surname.Trim
        ElseIf usertype = 2 Then
            lblname.Text = "welcome " + Staff.Forename.Trim + " " + Staff.Surname.Trim
        End If
        If appointmentlength = 5 Then
            For counter As Integer = 1 To nday
                Day = GetDay(counter)
                Day.Start = 204
                Day.finish = 246
                For counter2 As Integer = 0 To (Day.finish - Day.Start) \ 6 - 2
                    chklstavailability.Items.Add("Day " + counter.ToString + " " + militarytime(Day.Start + (counter2 * 6)) + " to " + militarytime(Day.Start + 12 + (counter2 * 6)))
                Next
            Next
        Else
            For counter As Integer = 1 To nday
                Day = GetDay(counter)
                Day.Start = 204
                Day.finish = 252
                For counter2 As Integer = 0 To (Day.finish - Day.Start) \ 6 - 4
                    chklstavailability.Items.Add("Day " + counter.ToString + " " + militarytime(Day.Start + (counter2 * 6)) + " to " + militarytime(Day.Start + 18 + (counter2 * 6)))
                Next
            Next
        End If
    End Sub

    Private Sub chklst_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstavailability.ItemCheck

        Dim parts() As String = Split(chklstavailability.SelectedItem, " ")
        If chklstavailability.GetItemChecked(chklstavailability.SelectedIndex) = False Then
            If usertype = 1 Then
                'student
                If appointmentlength = 5 Then
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 5)
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.available = True
                        StudAv.Block += 1
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(3)) \ 100) * 100)) / 5) + 11)
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.available = True
                        StudAv.Block += 2
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                Else
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 4) Step 2
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.available = True
                        StudAv.Block += 1
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 10) Step 2
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.available = True
                        StudAv.Block += 2
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 12 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 16) Step 2
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.available = True
                        StudAv.Block += 4
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                End If
            Else
                'staff
                If appointmentlength = 5 Then
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 5)
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Available = True
                        StaffAv.Block += 1
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6) To (((parts(2) \ 100) + (((parts(2)) - (((parts(3)) \ 100) * 100)) / 5) + 11))
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Available = True
                        StaffAv.Block += 2
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                Else
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 4) Step 2
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Available = True
                        StaffAv.Block += 1
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 10) Step 2
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Available = True
                        StaffAv.Block += 2
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 12 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 16) Step 2
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Available = True
                        StaffAv.Block += 4
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                End If
            End If
        Else
            If usertype = 1 Then
                'student
                If appointmentlength = 5 Then
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 5)
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.Block -= 1
                        If StudAv.Block = 0 Then
                            StudAv.available = True
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(3)) \ 100) * 100)) / 5) + 11)
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.Block -= 2
                        If StudAv.Block = 0 Then
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                Else
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 4) Step 2
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.Block -= 1
                        If StudAv.Block = 0 Then
                            StudAv.available = True
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 10) Step 2
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.Block -= 2
                        If StudAv.Block = 0 Then
                            StudAv.available = True
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 12 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 16) Step 2
                        For counter1 As Integer = 1 To NStudAv
                            GetStudAV(counter1)
                            If StudAv.StudNo = student.StudNO And StudAv.Appointment = counter And StudAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StudAv.Block -= 4
                        If StudAv.Block = 0 Then
                            StudAv.available = True
                        End If
                        PutStudAv(StudAv, StudAv.studAVNO)
                    Next
                End If
            Else
                'staff
                If appointmentlength = 5 Then
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 5)
                        For counter1 As Integer = 1 To Nstaff
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Block -= 1
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = True
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(3)) \ 100) * 100)) / 5) + 11)
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Block -= 2
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = True
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                Else
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 4) Step 2
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Block -= 1
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = True
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 6 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 10) Step 2
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Block -= 2
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = True
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                    For counter As Integer = (parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 12 To ((parts(2) \ 100) + (((parts(2)) - (((parts(2)) \ 100) * 100)) / 5) + 16) Step 2
                        For counter1 As Integer = 1 To NStaffAv
                            GetStaffAV(counter1)
                            If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Appointment = counter And StaffAv.DayNO = parts(1) Then
                                Exit For
                            End If
                        Next
                        StaffAv.Block -= 4
                        If StaffAv.Block = 0 Then
                            StaffAv.Available = True
                        End If
                        PutStaffAv(StaffAv, StaffAv.staffAVNO)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        frmStart.Show()
        Me.Close()
    End Sub
End Class
