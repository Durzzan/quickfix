Public Class frmStart

    Private Sub frmStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'splits up the user data to seperate out the users username
        Dim parts() As String = Split(My.User.Name, "\")
        user = parts(1)

        Nstaff = FileLen("staff.dat") / Len(Staff)
        NStaffAv = FileLen("staffav.dat") / Len(StaffAv)
        Nstudents = FileLen("students.dat") / Len(student)
        NStudAv = FileLen("studav.dat") / Len(StudAv)
        NAppointment = FileLen("appointment.dat") / Len(Appointment)
        NDay = FileLen("day.dat") / Len(Day)
        Nlesson = FileLen("lesson.dat") / Len(Lesson)

        'checks if the user is a student or a staff member 
        If Len(user) = 6 Then
            'user is in the form of a students so the list of students is checked
            For counter As Integer = 1 To Nstudents
                student = GetStudent(counter)
                'checks if the student has been found
                If user = student.StudID Then
                    'records that the user is a student
                    usertype = 1
                    Exit For
                End If
            Next
        Else
            'user is not in the form of a student so the list of staff is checked
            For counter = 1 To Nstaff
                Staff = GetStaff(counter)
                'checks if the user has been found
                If user = Staff.staffID Then
                    'records that the user is a member of staff
                    usertype = 2
                    'checks if the user is an admin
                    If Staff.admin = True Then
                        'makes the admin button visible so that the admin form may be accessed
                        btnAvailability.Text = "Your Availability"
                        btnadmin.Visible = True
                    End If
                End If
            Next
        End If
        'checks if the system is empty and whether they are a staff member. if so then it will not report there
        'not being in the system to them as an error
        If FileLen("staff.dat") = 0 And IsNumeric(user) = False Then
        Else
            If usertype = 0 Then
                btnAvailability.Visible = False
                MsgBox("Your username is not recognised by the system. If this is an error please contact the it technicians.", , "ERROR")

            End If
        End If

    End Sub

    Private Sub btnAvailability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvailability.Click
        'checks if the staff files are empty and whether they are a staff member. if yes it will send
        'them to the admin form so they can import data and set the settings
        If FileLen("Staff.dat") = 0 And IsNumeric(user) = False Then
            frmAdmin.Show()
            Me.Hide()
        Else
            'checks if the user is a student if so it sends them to the student form
            If usertype = 1 Or usertype = 2 Then
                frmAvailability.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        'closes the form
        Me.Close()
    End Sub

    Private Sub btnadmin_Click(sender As System.Object, e As System.EventArgs) Handles btnadmin.Click
        'opens up the admin form and closes the start form
        frmAdmin.Show()
        Me.Hide()
    End Sub
End Class