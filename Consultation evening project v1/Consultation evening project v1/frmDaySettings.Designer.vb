<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDaySettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbNdays = New System.Windows.Forms.ComboBox()
        Me.cmbDay = New System.Windows.Forms.ComboBox()
        Me.rad5min = New System.Windows.Forms.RadioButton()
        Me.rad10min = New System.Windows.Forms.RadioButton()
        Me.cmbStart = New System.Windows.Forms.ComboBox()
        Me.cmbEnd = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbNdays
        '
        Me.cmbNdays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNdays.FormattingEnabled = True
        Me.cmbNdays.Location = New System.Drawing.Point(112, 56)
        Me.cmbNdays.Name = "cmbNdays"
        Me.cmbNdays.Size = New System.Drawing.Size(121, 21)
        Me.cmbNdays.TabIndex = 0
        '
        'cmbDay
        '
        Me.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDay.FormattingEnabled = True
        Me.cmbDay.Location = New System.Drawing.Point(112, 149)
        Me.cmbDay.Name = "cmbDay"
        Me.cmbDay.Size = New System.Drawing.Size(121, 21)
        Me.cmbDay.TabIndex = 1
        Me.cmbDay.Visible = False
        '
        'rad5min
        '
        Me.rad5min.AutoSize = True
        Me.rad5min.Location = New System.Drawing.Point(112, 83)
        Me.rad5min.Name = "rad5min"
        Me.rad5min.Size = New System.Drawing.Size(55, 17)
        Me.rad5min.TabIndex = 4
        Me.rad5min.TabStop = True
        Me.rad5min.Text = "5 mins"
        Me.rad5min.UseVisualStyleBackColor = True
        '
        'rad10min
        '
        Me.rad10min.AutoSize = True
        Me.rad10min.Location = New System.Drawing.Point(112, 106)
        Me.rad10min.Name = "rad10min"
        Me.rad10min.Size = New System.Drawing.Size(61, 17)
        Me.rad10min.TabIndex = 5
        Me.rad10min.TabStop = True
        Me.rad10min.Text = "10 mins"
        Me.rad10min.UseVisualStyleBackColor = True
        '
        'cmbStart
        '
        Me.cmbStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStart.FormattingEnabled = True
        Me.cmbStart.Location = New System.Drawing.Point(112, 177)
        Me.cmbStart.Name = "cmbStart"
        Me.cmbStart.Size = New System.Drawing.Size(121, 21)
        Me.cmbStart.TabIndex = 6
        Me.cmbStart.Visible = False
        '
        'cmbEnd
        '
        Me.cmbEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEnd.FormattingEnabled = True
        Me.cmbEnd.Location = New System.Drawing.Point(112, 205)
        Me.cmbEnd.Name = "cmbEnd"
        Me.cmbEnd.Size = New System.Drawing.Size(121, 21)
        Me.cmbEnd.TabIndex = 7
        Me.cmbEnd.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "No. of Days"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 26)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Duration of " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "appoinments"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Day No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Start time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Finnish time"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(235, 289)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 13
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'frmDaySettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 324)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEnd)
        Me.Controls.Add(Me.cmbStart)
        Me.Controls.Add(Me.rad10min)
        Me.Controls.Add(Me.rad5min)
        Me.Controls.Add(Me.cmbDay)
        Me.Controls.Add(Me.cmbNdays)
        Me.Name = "frmDaySettings"
        Me.Text = "frmDaySettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbNdays As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDay As System.Windows.Forms.ComboBox
    Friend WithEvents rad5min As System.Windows.Forms.RadioButton
    Friend WithEvents rad10min As System.Windows.Forms.RadioButton
    Friend WithEvents cmbStart As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEnd As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
