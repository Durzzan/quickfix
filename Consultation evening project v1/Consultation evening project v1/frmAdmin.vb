Public Class frmAdmin

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        'opens form start and close the admin form
        frmStart.Show()
        Me.Close()
    End Sub

    Private Sub btnDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDay.Click
        'opnes frm daysettings
        frmDaySettings.Show()
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        'tries to inport staff. if it failes then due to safeguards in Importstaff() it must be  that there is an error
        'with the csv so it reports that and quits the subroutine
        Try
            Call ImportStaff()
        Catch
            MsgBox("system cannot find staff.csv", , "Error")
            Exit Sub
        End Try
        'if there was no problems with the staff csv but there were isues with the data then an error message will have been sent
        'and the varialbe stopimport will be set to true meaning that the subroutine should stop.
        If stopimport = True Then
            stopimport = False
            Exit Sub
        End If
        'tries to inport students. if it failes then due to safeguards in Importstudents() it must be  that there is an error
        'with the csv so it reports that and quits the subroutine
        Try
            Call ImportStudents()
        Catch
            MsgBox("system cannot find student.csv", , "Error")
            Exit Sub
        End Try
        'if there was no problems with the student csv but there were isues with the data then an error message will have been sent
        'and the varialbe stopimport will be set to true meaning that the subroutine should stop.
        If stopimport = True Then
            stopimport = False
            Exit Sub
        End If
        'tries to inport student lesson information. if it failes then due to safeguards in ImportLessonsStudent() it must be  that there is an error
        'with the csv so it reports that and quits the subroutine
        Try
            Call importLessonsStudent()
        Catch
            MsgBox("system cannot find studentclasses.csv", , "Error")
            Exit Sub
        End Try
        'if there was no problems with the studentclass csv but there were isues with the data then an error message will have been sent
        'and the varialbe stopimport will be set to true meaning that the subroutine should stop.
        If stopimport = True Then
            stopimport = False
            Exit Sub
        End If
        'tries to inport staff lesson information. if it failes then due to safeguards in ImportLessonStaff() it must be  that there is an error
        'with the csv so it reports that and quits the subroutine
        Try
            Call importLessonStaff()
        Catch
            MsgBox("system cannot find classslots.csv", , "Error")
            Exit Sub
        End Try
        'if there was no problems with the classslots csv but there were isues with the data then an error message will have been sent
        'and the varialbe stopimport will be set to true meaning that the subroutine should stop.
        If stopimport = True Then
            stopimport = False
            Exit Sub
        End If
    End Sub

    Private Sub btnResent_Click(sender As System.Object, e As System.EventArgs) Handles btnResent.Click
        ' for each dat file it goes through and writes over every record wiht empty space

        'overwrites staff.dat
        For counter As Integer = 1 To Nstaff
            Staff = Nothing
            PutStaff(Staff, counter)
        Next

        'overwrites staffav.dat
        For counter As Integer = 1 To NStaffAv
            StaffAv = Nothing
            PutStaffAv(StaffAv, counter)
        Next

        'overwrites student.dat
        For counter As Integer = 1 To Nstudents
            student = Nothing
            PutStudent(student, counter)
        Next

        'overwrites studentav.dat
        For counter As Integer = 1 To NStudAv
            StudAv = Nothing
            PutStudAv(StudAv, counter)
        Next

        'overwrites day.dat
        For counter As Integer = 1 To NDay
            Day = Nothing
            Putday(Day, counter)
        Next

        'overwrites lesson.dat
        For counter As Integer = 1 To Nlesson
            Lesson = Nothing
            Putlesson(Lesson, counter)
        Next

        'overwrites appointment.dat
        For counter As Integer = 1 To NAppointment
            Appointment = Nothing
            Putappointment(Appointment, counter)
        Next
    End Sub

    Private Sub btnalgorithm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnalgorithm.Click
        'calls the sorting algortithm which is stored in mod1
        Call TheSortingAlogorithm()
    End Sub
End Class