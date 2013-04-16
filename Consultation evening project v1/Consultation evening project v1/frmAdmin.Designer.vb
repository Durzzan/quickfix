<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
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
        Me.btnResent = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnDay = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnResent
        '
        Me.btnResent.Location = New System.Drawing.Point(42, 105)
        Me.btnResent.Name = "btnResent"
        Me.btnResent.Size = New System.Drawing.Size(93, 49)
        Me.btnResent.TabIndex = 0
        Me.btnResent.Text = "reset"
        Me.btnResent.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnImport.Location = New System.Drawing.Point(141, 50)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(93, 49)
        Me.btnImport.TabIndex = 1
        Me.btnImport.Text = "Import staff and student data"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnDay
        '
        Me.btnDay.Location = New System.Drawing.Point(42, 50)
        Me.btnDay.Name = "btnDay"
        Me.btnDay.Size = New System.Drawing.Size(93, 49)
        Me.btnDay.TabIndex = 2
        Me.btnDay.Text = "Day settings"
        Me.btnDay.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(316, 260)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 3
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 295)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnDay)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnResent)
        Me.Name = "frmAdmin"
        Me.Text = "frmAdmin"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnResent As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnDay As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
