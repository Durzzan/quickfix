Public Class frmAdmin

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        frmStart.Show()
        Me.Close()
    End Sub

    Private Sub btnDay_Click(sender As System.Object, e As System.EventArgs) Handles btnDay.Click
        frmDaySettings.Show()
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        Try
            Call ImportStaff()
        Catch
            MsgBox("system cannot find staff.csv", , "Error")
            Exit Sub
        End Try
        If stopimport = True Then
            stopimport = False
            Exit Sub
        End If
        Try
            Call ImportStudents()
        Catch
            MsgBox("system cannot find student.csv", , "Error")
            Exit Sub
        End Try
        If stopimport = True Then
            stopimport = False
            Exit Sub
        End If
        Try
            Call importLessonsStudent()
        Catch
            MsgBox("system cannot find studentclasses.csv", , "Error")
            Exit Sub
        End Try
        If stopimport = True Then
            stopimport = False
            Exit Sub
        End If
        Try
            Call importLessonStaff()
        Catch
            MsgBox("system cannot find classslots.csv", , "Error")
            Exit Sub
        End Try
        If stopimport = True Then
            stopimport = False
            Exit Sub
        End If
    End Sub

    Private Sub btnResent_Click(sender As System.Object, e As System.EventArgs) Handles btnResent.Click
        For counter As Integer = 1 To Nstaff
            Staff = Nothing
            PutStaff(Staff, counter)
        Next

        For counter As Integer = 1 To NStaffAv
            StaffAv = Nothing
            PutStaffAv(StaffAv, counter)
        Next

        For counter As Integer = 1 To Nstudents
            student = Nothing
            PutStudent(student, counter)
        Next

        For counter As Integer = 1 To NStudAv
            StudAv = Nothing
            PutStudAv(StudAv, counter)
        Next

        For counter As Integer = 1 To NDay
            Day = Nothing
            Putday(Day, counter)
        Next

        For counter As Integer = 1 To Nlesson
            Lesson = Nothing
            Putlesson(Lesson, counter)
        Next

        For counter As Integer = 1 To NAppointment
            Appointment = Nothing
            Putappointment(Appointment, counter)
        Next
    End Sub

    Private Sub btnalgorithm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnalgorithm.Click
        Call TheSortingAlogorithm()
    End Sub
End Class