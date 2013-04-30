Module mod1
    'structures

    'Student structure

    Public Structure StudRec
        Public StudNO As Short
        <VBFixedString(6)> Public StudID As String
        <VBFixedString(20)> Public Forename As String
        <VBFixedString(20)> Public Surname As String
        Public Year As Byte
    End Structure

    'staff structure

    Public Structure StaffRec
        Public StaffNO As Byte
        <VBFixedString(3)> Public staffID As String
        <VBFixedString(20)> Public Forename As String
        <VBFixedString(20)> Public Surname As String
        Public admin As Boolean
    End Structure

    'Student availabity structure

    Public Structure StudAvRec
        public studAVNO as integer
        Public Appointment As Integer
        Public StudNo As Short
        Public DayNO As Byte
        Public Block As Byte
        Public available As Boolean
    End Structure

    'staff availability structure

    Public Structure StaffAvRec
        public staffAVNO as integer
        Public Appointment As Integer
        Public StaffNO As Byte
        Public DayNO As Byte
        Public Block As Byte
        Public Available As Boolean
    End Structure

    'day stucture

    Public Structure DayRec
        Public DayNO As Byte
        Public Start As Integer
        Public finish As Integer
    End Structure

    'appointments structure

    Public Structure AppointmentsRec
        Public studNO As integer
        Public StaffNO As integer
		public start as integer
		public day as integer
        Public AppointmentNO As Byte
    End Structure

    'Lesson structure

    Public Structure LessonRec
        Public LessonNO As Integer
        Public StudNO As Short
        Public StaffNO As Short
    End Structure

    'variables


    'general variables 
    'contains the users username
    Public user As String
    Public usertype As Byte = 0
    Public stopimport As Boolean = False

    'student variables

    Public student As StudRec = Nothing
    Public Nstudents As Integer = -1

    'staff variables

    Public Staff As StaffRec = Nothing
    Public Nstaff As Integer = -1

    'student availability variables

    Public StudAv As StudAvRec = Nothing
    Public studav2 As StudAvRec = Nothing
    Public NStudAv As Integer = -1

    'staff availablitiy variables

    Public StaffAv As StaffAvRec = Nothing
    Public NStaffAv As Integer = -1

    'Day variables

    Public Appointmentlength As Integer = -1
    Public Day As DayRec = Nothing
    Public NDay As Integer = -1

    'Appointment variables

    Public Appointment As AppointmentsRec = Nothing
    Public NAppointment As Integer = -1

    'Lesson variables

    Public Lesson As LessonRec = Nothing
    Public Nlesson As Integer = -1

    'reading csv files and creating dat files

    'imports the students into thier dat file
    Public Sub ImportStudents()
        'opnes up file reader and sets it to read students.csv the file in which the student data is stored
        Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("students.csv")
        TextFileReader.TextFieldType = FileIO.FieldType.Delimited
        TextFileReader.SetDelimiters(",")

        Dim CurrentRow As String()
        Dim OnRec As Integer = 0
        Dim FileNum As Integer = FreeFile()
        'opens file
        FileOpen(FileNum, "Student.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(student))

        While Not TextFileReader.EndOfData
            Try
                CurrentRow = TextFileReader.ReadFields()
                If Not CurrentRow Is Nothing Then
                    OnRec = OnRec + 1
                    'puts data into the studet structure
                    With student
                        Try
                            
                            .StudNO = CurrentRow(0)
                            .StudID = CurrentRow(1)
                            .Surname = CurrentRow(2)
                            .Forename = CurrentRow(3)
                            .Year = CurrentRow(4)
                        Catch
                            'this is trigered if there was a problem with inputing to the student structure
                            'it stops the importing and telles the suer what has happened
                            stopimport = True
                            MsgBox("error with student.csv")
                            Exit Sub
                        End Try

                    End With
                    'puts data from the student structure into the student dat file
                    FilePut(FileNum, student, OnRec)
                End If
            Catch ex As  _
                Microsoft.VisualBasic.FileIO.MalformedLineException
                'if error then error message is sent and try ends
                MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
            End Try
        End While
        'message box is sent saying that the students are imported and how many
        Nstudents = OnRec
        MsgBox(NStudents & " students imported")
        'file is closed
        FileClose(FileNum)
        TextFileReader.Dispose()
    End Sub

    'imports staff into thier dat file
    Public Sub ImportStaff()
        'opens microsoft file reader and sets the file to be read as tutor.csv
        Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("tutor.csv")
        TextFileReader.TextFieldType = FileIO.FieldType.Delimited
        TextFileReader.SetDelimiters(",")

        Dim CurrentRow As String()
        Dim OnRec As Integer = 0
        Dim FileNum As Integer = FreeFile()

        'opens the file
        FileOpen(FileNum, "Staff.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Staff))
        Dim parts() As String
        While Not TextFileReader.EndOfData
            Try
                CurrentRow = TextFileReader.ReadFields()
                If Not CurrentRow Is Nothing Then
                    OnRec = OnRec + 1
                    'puts data into file structure staff
                    With Staff
                        Try
                            .StaffNO = CurrentRow(0)
                            'forename and surname are saved in the same field on the parent file so need to be broken up
                            parts = Split(CurrentRow(1), " ")
                            .Surname = parts(1)
                            .Forename = parts(0)
                            .staffID = CurrentRow(2)
                            If CurrentRow(3) = 0 Then
                                .admin = False
                            Else : .admin = True
                            End If
                        Catch
                            'this is trigered if there was a problem with inputing to the staff structure
                            'it stops the importing and telles the suer what has happened
                            stopimport = True
                            MsgBox("error with staff.csv")
                            Exit Sub
                        End Try
                    End With
                    'puts data in file structure staff into the staff dat file
                    FilePut(FileNum, Staff, OnRec)
                End If
            Catch ex As  _
            Microsoft.VisualBasic.FileIO.MalformedLineException
                'error in text sends error message and ends try
                MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
            End Try
        End While
        Nstaff = OnRec
        'sends message box notifying student that staff have been imported and how many have been
        MsgBox(Nstaff & " Staff imported")
        FileClose(FileNum)
        TextFileReader.Dispose()
    End Sub

    Public Sub importLessonsStudent()
        'opens microsoft file reader and sets the file to be read as tutor.csv
        Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("studentclass.csv")
        TextFileReader.TextFieldType = FileIO.FieldType.Delimited
        TextFileReader.SetDelimiters(",")

        Dim CurrentRow As String()
        Dim OnRec As Integer = 0
        Dim FileNum As Integer = FreeFile()

        'opens the file
        FileOpen(FileNum, "lesson.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Lesson))
        While Not TextFileReader.EndOfData
            Try
                CurrentRow = TextFileReader.ReadFields()
                If Not CurrentRow Is Nothing Then
                    OnRec = OnRec + 1
                    'puts data into file structure staff
                    With Lesson
                        Try
                            .LessonNO = OnRec
                            .StaffNO = CurrentRow(1)
                            .StudNO = CurrentRow(0)
                        Catch
                            'this is trigered if there was a problem with inputing to the lesson structure
                            'it stops the importing and telles the suer what has happened
                            stopimport = True
                            MsgBox("error with studentclass.csv")
                            Exit Sub
                        End Try
                    End With
                    'puts data in the lesson file structure into the lesson dat file
                    FilePut(FileNum, Lesson, OnRec)
                End If
            Catch ex As  _
            Microsoft.VisualBasic.FileIO.MalformedLineException
                'error in text sends error message and ends try
                MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
            End Try
        End While
        Nlesson = OnRec
        'sends message box notifying admin that student part of lessons have been imported and how many have been imported
        MsgBox("Student half imported")
        FileClose(FileNum)
        TextFileReader.Dispose()
    End Sub

    Public Sub importLessonStaff()
        'opens microsoft file reader and sets the file to be read as classslots.csv
        Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("classSlots.csv")
        TextFileReader.TextFieldType = FileIO.FieldType.Delimited
        TextFileReader.SetDelimiters(",")

        Dim lastlesson As Integer = -1
        Dim currentrow As String() = Nothing
        Dim onrec As Integer = 0

        OnRec = 0

        While Not TextFileReader.EndOfData
            Try
                currentrow = TextFileReader.ReadFields()
                If (Not currentrow Is Nothing) And (currentrow(0) <> lastlesson.ToString) Then
                    onrec = onrec + 1
                    lastlesson = currentrow(0)
                    For counter As Integer = 1 To Nlesson
                        Getlesson(counter)
                        Try
                            If Lesson.StaffNO = currentrow(0) Then
                                Lesson.StaffNO = currentrow(3)
                            End If
                        Catch
                            'this is trigered if there was a problem with inputing to the lesson structure
                            'it stops the importing and telles the suer what has happened
                            stopimport = True
                            MsgBox("error with classslots.csv")
                            Exit Sub
                        End Try
                        Putlesson(Lesson, Lesson.LessonNO)
                    Next
                End If
            Catch ex As  _
                    Microsoft.VisualBasic.FileIO.MalformedLineException
                'error in text sends error message and ends try      
                MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
            End Try
        End While
        'sends message box notifying admin that the staff side of lessons have been imported
        MsgBox("staff half imported")
        TextFileReader.Dispose()

    End Sub
    ' retrives a student record
    Public Function GetStudent(ByVal RecNo As Integer) As StudRec
        'function for getting data from student dat file
        Dim Filenum As Integer = FreeFile()
        GetStudent = Nothing
        'opens the student dat file
        FileOpen(Filenum, "Student.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(student))
        'gets data
        FileGet(Filenum, GetStudent, RecNo)
        'closes file
        FileClose(Filenum)
    End Function

    'retrives a staff record
    Public Function GetStaff(ByVal RecNo As Integer) As StaffRec
        'function for getting data from staff dat file
        Dim Filenum As Integer = FreeFile()
        GetStaff = Nothing
        'opens the staff dat file
        FileOpen(Filenum, "Staff.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Staff))
        'gets data
        FileGet(Filenum, GetStaff, RecNo)
        'closes file
        FileClose(Filenum)
    End Function

    'retrives a student availability record
    Public Function GetStudAV(ByVal RecNo As Integer) As StudAvRec
        'function for getting data from studAV dat file
        Dim Filenum As Integer = FreeFile()
        GetStudAV = Nothing
        'opens the studav dat file
        FileOpen(Filenum, "StudAV.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(StudAv))
        'gets data
        FileGet(Filenum, GetStudAV, RecNo)
        'closes file
        FileClose(Filenum)
    End Function

    'retrives a staff availiability record
    Public Function GetStaffAV(ByVal RecNo As Integer) As StaffAvRec
        'function for getting data from staffav dat file
        Dim Filenum As Integer = FreeFile()
        GetStaffAV = Nothing
        'opens the staffav dat file
        FileOpen(Filenum, "StaffAV.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(StaffAv))
        'gets data
        FileGet(Filenum, GetStaffAV, RecNo)
        'closes file
        FileClose(Filenum)
    End Function

    'retrives a day record
    Public Function GetDay(ByVal RecNo As Integer) As DayRec
        'function for getting data from day dat file
        Dim Filenum As Integer = FreeFile()
        GetDay = Nothing
        'opens the day dat file
        FileOpen(Filenum, "Day.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Day))
        'gets data
        FileGet(Filenum, GetDay, RecNo)
        'closes file
        FileClose(Filenum)
    End Function

    'retrives a lesson record
    Public Function Getlesson(ByVal RecNo As Integer) As LessonRec
        'function for getting data from lesson dat file
        Dim Filenum As Integer = FreeFile()
        Getlesson = Nothing
        'opens the lesson dat file
        FileOpen(Filenum, "Lesson.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Lesson))
        'gets data
        FileGet(Filenum, Getlesson, RecNo)
        'closes file
        FileClose(Filenum)
    End Function

    'retreives a appointment record
    Public Function Getappointmentrec(ByVal RecNo As Integer) As AppointmentsRec
        'function for getting data from Appointments dat file
        Dim Filenum As Integer = FreeFile()
        Getappointmentrec = Nothing
        'opens the appointments dat file
        FileOpen(Filenum, "Appointments.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Appointment))
        'gets data
        FileGet(Filenum, Getappointmentrec, RecNo)
        'closes file
        FileClose(Filenum)
    End Function

    'overwrites an student onto the student dat file
    Public Sub PutStudent(ByVal EditedStudent As StudRec, ByVal RecNo As Integer)
        'sub for putting data into the student dat file
        Dim Filenum As Integer = FreeFile()
        'opens student dat file
        FileOpen(Filenum, "Student.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(student))
        'puts data into student dat file
        FilePut(Filenum, EditedStudent, RecNo)
        'closes student dat file
        FileClose(Filenum)
    End Sub

    'overwrites an staff onto the staff dat file
    Public Sub PutStaff(ByVal EditedStaff As StaffRec, ByVal RecNo As Integer)
        'sub for putting data into the staff dat file
        Dim Filenum As Integer = FreeFile()
        'opens staff dat file
        FileOpen(Filenum, "Staff.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Staff))
        'puts data into staff dat file
        FilePut(Filenum, EditedStaff, RecNo)
        'closes staff dat file
        FileClose(Filenum)
    End Sub

    'overwrites an studavrec onto the studav dat file
    Public Sub PutStudAv(ByVal EditedStudAv As StudAvRec, ByVal RecNo As Integer)
        'sub for putting data into the studAv dat file
        Dim Filenum As Integer = FreeFile()
        'opens studAv dat file
        FileOpen(Filenum, "StudAv.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(StudAv))
        'puts data into studAv dat file
        FilePut(Filenum, EditedStudAv, RecNo)
        'closes studAv dat file
        FileClose(Filenum)
    End Sub

    'overwrites an staffAv onto the staffAv dat file
    Public Sub PutStaffAv(ByVal EditedStaffAv As StaffAvRec, ByVal RecNo As Integer)
        'sub for putting data into the staffAv dat file
        Dim Filenum As Integer = FreeFile()
        'opens staffAv dat file
        FileOpen(Filenum, "StaffAv.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(StaffAv))
        'puts data into staffAv dat file
        FilePut(Filenum, EditedStaffAv, RecNo)
        'closes staffAv dat file
        FileClose(Filenum)
    End Sub

    'overwrites an Day onto the day dat file
    Public Sub Putday(ByVal Editedday As DayRec, ByVal RecNo As Integer)
        'sub for putting data into the day dat file
        Dim Filenum As Integer = FreeFile()
        'opens day dat file
        FileOpen(Filenum, "day.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Day))
        'puts data into day dat file
        FilePut(Filenum, Editedday, RecNo)
        'closes day dat file
        FileClose(Filenum)
    End Sub

    'overwrites an lesson onto the lesson dat file
    Public Sub Putlesson(ByVal Editedlesson As LessonRec, ByVal RecNo As Integer)
        'sub for putting data into the lesson dat file
        Dim Filenum As Integer = FreeFile()
        'opens lesson dat file
        FileOpen(Filenum, "Lesson.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Lesson))
        'puts data into lesson dat file
        FilePut(Filenum, Editedlesson, RecNo)
        'closes lesson dat file
        FileClose(Filenum)
    End Sub

    'overwrites an appointment onto the appointment dat file
    Public Sub Putappointment(ByVal Editedappointment As AppointmentsRec, ByVal RecNo As Integer)
        'sub for putting data into the appointment dat file
        Dim Filenum As Integer = FreeFile()
        'opens appointment dat file
        FileOpen(Filenum, "appointments.dat", OpenMode.Random, OpenAccess.Default, OpenShare.Default, Len(Appointment))
        'puts data into appointment dat file
        FilePut(Filenum, Editedappointment, RecNo)
        'closes the appointment dat file
        FileClose(Filenum)
    End Sub

    Public Sub populateStartEndDaySettings()
        'populates cmbstart with the times at the required appiontment length apart
        Day = GetDay(frmDaySettings.cmbDay.SelectedItem)
        If Appointmentlength = 5 Then
            'populates cmbstart with 5 min appointments slots
            For counter As Integer = 0 To (Day.finish - 12) Step 6
                'each slot contained between the beginin and the finsish time is converted into 24hour 
                'military style time
                frmDaySettings.cmbStart.Items.Add(militarytime(counter))
            Next

            'populates the cmbEnd list witht the available times
            For counter As Integer = (Day.Start + 12) To 288 Step 6
                'each slot contained between the beginin and the finsish time is converted into 24hour 
                'military style time
                frmDaySettings.cmbEnd.Items.Add(militarytime(counter))
            Next
        Else
            'populates cmbstart with 10 min appointments slots
            For counter As Integer = 0 To (Day.finish - 18) Step 6
                'each slot contained between the beginin and the finsish time is converted into 24hour 
                'military style time
                frmDaySettings.cmbStart.Items.Add(militarytime(counter))
            Next

            'populates the cmbEnd list witht the available times
            For counter As Integer = (Day.Start + 18) To 288 Step 6
                'each slot contained between the beginin and the finsish time is converted into 24hour 
                'military style time
                frmDaySettings.cmbEnd.Items.Add(militarytime(counter))
            Next

        End If

    End Sub
    'fucntion that changes a number from 0 to 287 into its coresponidng 24 hour clock time
    Public Function militarytime(ByVal timeNO As Integer) As String
        Dim hours As String
        Dim minuets As String

        'works out how many hours there are
        hours = (timeNO \ 12).ToString
        'puts in the place filler zeroes to keep it 2 characters
        If Len(hours) = 1 Then
            hours = "0" + hours
        ElseIf Len(hours) = 0 Then
            hours = "00"
        End If
        'works out how many minuets remain not counting the hours 
        minuets = (timeNO - ((timeNO \ 12) * 12))
        minuets = minuets * 5
        'puts in the place filling zeroes if need to keep it to 2 characters
        If Len(minuets) = 1 Then
            minuets = "0" + minuets
        ElseIf Len(minuets) = 0 Then
            minuets = "00"
        End If
        'puts the 2 halves to gether to be returned
        militarytime = hours + minuets
    End Function

    Public Sub TheSortingAlogorithm()
        Dim OnAppointment As Integer = 0
        Dim lowerbound As Integer = 0

        'for loop goes through every student
        For counter1 As Integer = 0 To Nstudents
            'gets studnet information
            student = GetStudent(counter1)
            'finds all the lessons with the student and retives the teacher
            For counter2 As Integer = 0 To Nlesson
                Lesson = Getlesson(counter2)
                If Lesson.StudNO = student.StudNO Then
                    Staff = GetStaff(counter2)
                    'for each students availablity it looks for avaliable spots that are also available for the teacher
                    For counter3 As Integer = 0 To NStudAv
                        StudAv = GetStudAV(counter3)
                        If StudAv.StudNo = student.StudNO And StudAv.available = True Then
                            For counter4 As Integer = 0 To NStaffAv
                                StaffAv = GetStaffAV(counter4)
                                If StaffAv.StaffNO = Staff.StaffNO And StaffAv.Available = True Then
                                    'an appointment slot has been found for which both the studen and staff memver are available for
                                    'the record for the appointment is populated
                                    Appointment.AppointmentNO = OnAppointment
                                    Appointment.studNO = StudAv.StudNo
                                    Appointment.StaffNO = StaffAv.StaffNO
                                    Appointment.day = StudAv.DayNO
                                    Appointment.StaffNO = StudAv.Appointment
                                    'handels block values for the student so as to make sure that the values are only within one block.
                                    If Appointmentlength = 5 Then
                                        For counter5 As Integer = 0 To NStudAv
                                            studav2 = GetStudAV(counter5)
                                            'checks if teh block value of the current spot is 21 because if it is and the other is 20 then they are
                                            'not in the same block and it needs to be set as unavailable
                                            If StudAv.Block = 21 And studav2.Block = 20 Then
                                                studav2.Block = 0
                                                studav2.available = False
                                                PutStudAv(studav2, studav2.studAVNO)
                                                'checks if teh block value of the current spot is 20 because if it is and the other is 21 then they are
                                                'not in the same block and it needs to be set as unavailable
                                            ElseIf StudAv.Block = 20 And studav2.Block = 21 Then
                                                studav2.Block = 0
                                                studav2.available = False
                                                PutStudAv(studav2, studav2.studAVNO)
                                            End If
                                        Next

                                    Else
                                        'handles 10 min cases
                                        For counter5 As Integer = 0 To NStudAv
                                            studav2 = GetStudAV(counter5)
                                            'checks if teh block value of the current spot is 20 because if it is and the other is 22 or 23 then they are
                                            'not in the same block and it needs to be set as unavailable
                                            If StudAv.Block = 20 And (studav2.Block = 22 Or studav2.Block = 23) Then
                                                studav2.Block = 0
                                                studav2.available = False
                                                PutStudAv(studav2, studav2.studAVNO)
                                                'checks if teh block value of the current spot is 21 because if it is and the other is 23 then they are
                                                'not in the same block and it needs to be set as unavailable
                                            ElseIf StudAv.Block = 21 And studav2.Block = 23 Then
                                                studav2.Block = 0
                                                studav2.available = False
                                                PutStudAv(studav2, studav2.studAVNO)
                                                'checks if teh block value of the current spot is 23 because if it is and the other is 20 or 21 then they are
                                                'not in the same block and it needs to be set as unavailable
                                            ElseIf StudAv.Block = 23 And (studav2.Block = 20 Or studav2.Block = 21) Then
                                                studav2.Block = 0
                                                studav2.available = False
                                                PutStudAv(studav2, studav2.studAVNO)
                                                'checks if teh block value of the current spot is 22 because if it is and the other is 20 then they are
                                                'not in the same block and it needs to be set as unavailable
                                            ElseIf StudAv.Block = 22 And studav2.Block = 20 Then
                                                studav2.Block = 0
                                                studav2.available = False
                                                PutStudAv(studav2, studav2.studAVNO)
                                            End If
                                        Next
                                    End If
                                    'sets the staffav availablitity
                                    StaffAv.Available = False
                                    PutStaffAv(StaffAv, StaffAv.staffAVNO)

                                    'sets the stud blocks and availablitity for appointment blocks 
                                    'cycles through each studavrecord
                                    For counter5 As Integer = 0 To NStudAv
                                        studav2 = GetStudAV(counter5)
                                        'for appointmetn length 5
                                        If Appointmentlength = 5 Then
                                            'works out the first appointment of the half hour
                                            lowerbound = (studav2.Appointment \ 6) * 6
                                            'checks if the studav is not already been set in the earlier check and if it is for the right student 
                                            If studav2.StudNo = student.StudNO And StudAv.Block <> 21 Or 20 Then
                                                Select Case studav2.Appointment
                                                    'too early
                                                    Case Is <= (lowerbound - 7)
                                                        studav2.available = False
                                                        studav2.Block = 0
                                                        'too late
                                                    Case Is >= (lowerbound + 12)
                                                        studav2.available = False
                                                        studav2.Block = 0
                                                        'half hour early
                                                    Case (lowerbound - 6) To (lowerbound - 1)
                                                        studav2.Block = 20
                                                        'half hour later
                                                    Case (lowerbound + 6) To (lowerbound + 11)
                                                        studav2.Block = 21
                                                        'appointmetn before
                                                    Case (StudAv.Appointment - 1)
                                                        studav2.available = False
                                                        studav2.Block = 0
                                                        'appointment after
                                                    Case (StudAv.Appointment + 1)
                                                        studav2.available = False
                                                        studav2.Block = 0
                                                        'the appointmetn in question
                                                    Case StudAv.Appointment
                                                        studav2.Block = 0
                                                        studav2.available = False
                                                End Select


                                            End If
                                        Else
                                            'works out the first appointment of the half hour
                                            lowerbound = (studav2.Appointment \ 6) * 6
                                            'checks if the studav is not already been set in the earlier check and if it is for the right student 
                                            If studav2.StudNo = student.StudNO And StudAv.Block <> 21 Or 20 Then
                                                Select Case studav2.Appointment
                                                    'too early
                                                    Case Is <= (lowerbound - 13)
                                                        studav2.available = False
                                                        studav2.Block = 0
                                                        'too late
                                                    Case Is >= (lowerbound + 18)
                                                        studav2.available = False
                                                        studav2.Block = 0
                                                        'half hour early
                                                    Case (lowerbound - 6) To (lowerbound - 1)
                                                        studav2.Block = 21
                                                        'half hour later
                                                    Case (lowerbound + 6) To (lowerbound + 11)
                                                        studav2.Block = 22
                                                        'hour early
                                                    Case (lowerbound - 12) To (lowerbound - 7)
                                                        studav2.Block = 20
                                                        'hour later
                                                    Case (lowerbound + 12) To (lowerbound + 17)
                                                        studav2.Block = 23
                                                        'appointmetn before
                                                    Case (StudAv.Appointment - 1)
                                                        studav2.available = False
                                                        studav2.Block = 0
                                                        'appointment after
                                                    Case (StudAv.Appointment + 1)
                                                        studav2.available = False
                                                        studav2.Block = 0
                                                        'the appointmetn in question
                                                    Case StudAv.Appointment
                                                        studav2.Block = 0
                                                        studav2.available = False
                                                End Select
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Next




    End Sub
	public sub sendemailspart1()
        Dim subject As String = "Consultation evening appointments"
        Dim body As String = ""
        Dim username As String = "sim.bellows@gmail.com"
        Dim password As String = "l09m3e?!"
        Dim recipient As String


        'loop that cycles through each student so each gets an email
        For counter1 As Integer = 1 To Nstudents
            'loads current students details
            student = GetStudent(counter1)
            'generates the students school email
            recipient = student.StudID + "@WMSF.ac.uk"
            'puts the initial greeting for the email and clears the old message
            body = "Dear " & student.Forename & " " & student.Surname & vbNewLine & vbNewLine
            'finds each appointment of the student
            For counter2 As Integer = 1 To NAppointment
                If Appointment.studNO = student.StudNO Then
                    'gets the name of the member of staff the appointment is with
                    Staff = GetStaff(Appointment.StaffNO)
                    'puts in the details of the appiontment into the email
                    body = body & Staff.Forename & " " & Staff.Surname & "" & militarytime(Appointment.start) & " day " & Appointment.day & vbNewLine
                End If
            Next
            'puts the sign off of the email into the text
            body = body & vbNewLine & "thank you very much" & vbNewLine & "simon bellows" & vbNewLine & vbNewLine & "deputy head"
            'calls the routine to send the email
            Call SendEmails2("sim.bellows@gmail.com", subject, body, username, password, recipient)
        Next
        'loop that cycles through each staff member so each gets an email
        For counter1 As Integer = 1 To Nstaff
            'loads current staff members details
            Staff = GetStaff(counter1)
            'genereates the staff school email
            recipient = Staff.staffID + "@WMSF.ac.uk"
            'puts the intitial greeting for the email and clears the old message
            body = "Dear " & Staff.Forename & " " & Staff.Surname & vbNewLine & vbNewLine
            'finds each appoointment of the staff member
            For counter2 As Integer = 1 To NAppointment
                If Appointment.StaffNO = Staff.StaffNO Then
                    'gets the name of the student the appointmetn is with
                    student = GetStudent(Appointment.studNO)
                    'puts in the details of the appointment into the email
                    body = body & student.Forename & " " & student.Surname & "" & militarytime(Appointment.start) & " day " & Appointment.day & vbNewLine
                End If
            Next
            'puts the sign off of the email into the message
            body = body & vbNewLine & "thank you very much" & vbNewLine & "simon bellows" & vbNewLine & vbNewLine & "deputy head"
            'calls the routine to send the email
            Call SendEmails2("sim.bellows@gmail.com", subject, body, username, password, recipient)
        Next
        
	end sub
    Public Sub SendEmails2(ByVal FromAddress As String, _
                     ByVal Subject As String, _
                        ByVal Body As String, _
                          ByVal UserName As String, _
                          ByVal Password As String, _
                          ByVal recipient As String, _
                          Optional ByVal Server As String = "smtp.gmail.com", _
                          Optional ByVal Port As Integer = 587)

        Dim Email As New MailMessage()

        'trys to send the email
        Try
            Dim SMTPServer As New SmtpClient
            'fills in the senders email adress from the fromaddress parameter
            Email.From = New MailAddress(FromAddress)
            'puts in the recipent for the mail
            For Each Recipient As String In Recipients
                Email.To.Add(Recipient)
            Next
            'adds subject body and server, host and such information
            Email.Subject = Subject
            Email.Body = Body
            SMTPServer.Host = Server
            SMTPServer.Port = Port
            SMTPServer.Credentials = New System.Net.NetworkCredential(UserName, Password)
            SMTPServer.EnableSsl = True
            'sends it
            SMTPServer.Send(Email)
            'clears it
            Email.Dispose()
            'notificaltion if smtp failed
        Catch ex As SmtpException
            Email.Dispose()
            MsgBox("Sending Email Failed. Smtp Error.")
            'notification if portnuimber owas wrong
        Catch ex As ArgumentOutOfRangeException
            Email.Dispose()
            MsgBox("Sending Email Failed. Check Port Number.")
            'notification if portnunber is wrong
        Catch Ex As InvalidOperationException
            Email.Dispose()
            MsgBox("Sending Email Failed. Check Port Number.")
        End Try
    End Sub
End Module
