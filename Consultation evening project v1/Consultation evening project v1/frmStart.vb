Public Class frmStart

    Private Sub frmStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'splits up the user data to seperate out the users username
        Dim parts() As String = Split(My.User.Name, "\")
        user = parts(1)

        'finds the length of each dat file and if they dont exist sets it to -1
        Try
            Nstaff = FileLen("staff.dat") / Len(Staff)
        Catch
            Nstaff = -1
        End Try
        Try
            NStaffAv = FileLen("staffav.dat") / Len(StaffAv)
        Catch
            NStaffAv = -1
        End Try
        Try
            Nstudents = FileLen("student.dat") / Len(student)
        Catch
            Nstudents = -1
        End Try
        Try
            NStudAv = FileLen("studav.dat") / Len(StudAv)
        Catch
            NStudAv = -1
        End Try
        Try
            NAppointment = FileLen("appointments.dat") / Len(Appointment)
        Catch
            NAppointment = -1
        End Try
        Try
            NDay = FileLen("day.dat") / Len(Day)
        Catch
            NDay = -1
        End Try
        Try
            Nlesson = FileLen("lesson.dat") / Len(Lesson)
        Catch
            Nlesson = -1
        End Try
        


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
            For counter As Integer = 1 To Nstaff
                Staff = GetStaff(counter)
                'checks if the user has been found
                If user.ToUpper = Staff.staffID.ToUpper Then
                    'records that the user is a member of staff
                    usertype = 2
                    'checks if the user is an admin
                    If Staff.admin = True Then
                        'makes the admin button visible so that the admin form may be accessed
                        btnAvailability.Text = "Your Availability"
                        btnadmin.Visible = True
                    End If
                    Exit For
                End If
            Next
        End If
        'checks if the system doesnt have any staff. if so then there arnt any admins and it checks if the user is in the format of a staff member
        'if so then it sends the user to the admin file to set up the system

        If FileLen("staff.dat") = 0 And IsNumeric(user) = False And Len(user) = 3 Then
            frmAdmin.Show()
            Me.Close()
        End If

        'if the usesr has been given a usertype of 0 then he is not in the system so access to the other forms is blocked of by making the buttons
        'invisible and it then sends an error message sayting they arent in the system and advising them to check with an admisistrator if they
        'feel it is wrong
        If usertype = 0 Then
            btnAvailability.Visible = False
            MsgBox("Your username is not recognised by the system. If this is an error please contact the it technicians.", , "ERROR")

        End If


    End Sub

    Private Sub btnAvailability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvailability.Click
        'though the button should only be vissible if hte user is in the system if first checks if they are tne sends them to the availablility form
        If usertype = 1 Or usertype = 2 Then
            frmAvailability.Show()
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
