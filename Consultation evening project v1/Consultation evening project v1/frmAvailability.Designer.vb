﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAvailability
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
        Me.lblname = New System.Windows.Forms.Label()
        Me.chklstavailability = New System.Windows.Forms.CheckedListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.Location = New System.Drawing.Point(81, 69)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(39, 13)
        Me.lblname.TabIndex = 0
        Me.lblname.Text = "Label1"
        '
        'chklstavailability
        '
        Me.chklstavailability.FormattingEnabled = True
        Me.chklstavailability.Location = New System.Drawing.Point(67, 85)
        Me.chklstavailability.Name = "chklstavailability"
        Me.chklstavailability.Size = New System.Drawing.Size(132, 124)
        Me.chklstavailability.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(242, 280)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAvailability
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 334)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.chklstavailability)
        Me.Controls.Add(Me.lblname)
        Me.Name = "frmAvailability"
        Me.Text = "frmAvailability"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents chklstavailability As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
