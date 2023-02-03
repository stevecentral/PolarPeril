<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uDIE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uDIE))
        Me.continue_button = New System.Windows.Forms.Button()
        Me.quit_Button = New System.Windows.Forms.Button()
        Me.gameover = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'continue_button
        '
        Me.continue_button.AutoSize = True
        Me.continue_button.Font = New System.Drawing.Font("Javanese Text", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.continue_button.ForeColor = System.Drawing.Color.Teal
        Me.continue_button.Location = New System.Drawing.Point(24, 173)
        Me.continue_button.Name = "continue_button"
        Me.continue_button.Size = New System.Drawing.Size(122, 46)
        Me.continue_button.TabIndex = 0
        Me.continue_button.Text = "Continue"
        Me.continue_button.UseVisualStyleBackColor = True
        '
        'quit_Button
        '
        Me.quit_Button.AutoSize = True
        Me.quit_Button.Font = New System.Drawing.Font("Javanese Text", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quit_Button.ForeColor = System.Drawing.Color.Teal
        Me.quit_Button.Location = New System.Drawing.Point(183, 173)
        Me.quit_Button.Name = "quit_Button"
        Me.quit_Button.Size = New System.Drawing.Size(75, 46)
        Me.quit_Button.TabIndex = 1
        Me.quit_Button.Text = "Quit"
        Me.quit_Button.UseVisualStyleBackColor = True
        '
        'gameover
        '
        Me.gameover.AutoSize = True
        Me.gameover.Font = New System.Drawing.Font("Javanese Text", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gameover.ForeColor = System.Drawing.Color.Teal
        Me.gameover.Location = New System.Drawing.Point(80, 18)
        Me.gameover.Name = "gameover"
        Me.gameover.Size = New System.Drawing.Size(130, 47)
        Me.gameover.TabIndex = 2
        Me.gameover.Text = "Game Over"
        '
        'uDIE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.gameover)
        Me.Controls.Add(Me.quit_Button)
        Me.Controls.Add(Me.continue_button)
        Me.Name = "uDIE"
        Me.Text = "uDIE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents continue_button As System.Windows.Forms.Button
    Friend WithEvents quit_Button As System.Windows.Forms.Button
    Friend WithEvents gameover As System.Windows.Forms.Label
End Class
