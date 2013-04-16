Public Class frmAdmin

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        frmStart.Show()
        Me.Close()
    End Sub

    Private Sub btnDay_Click(sender As System.Object, e As System.EventArgs) Handles btnDay.Click
        frmDaySettings.Show()
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        Call ImportStaff()
        Call ImportStudents()
        Call importLessonsStudent()
        Call importLessonStaff()
    End Sub

    Private Sub btnResent_Click(sender As System.Object, e As System.EventArgs) Handles btnResent.Click
        For counter As Integer = 1 To Nstaff
            Staff = Nothing
            PutStaff(Staff, counter)
        Next
    End Sub
End Class