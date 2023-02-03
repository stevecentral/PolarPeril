<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Victory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Victory))
        Me.continue_button = New System.Windows.Forms.Button()
        Me.Quit_Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'continue_button
        '
        Me.continue_button.AutoSize = True
        Me.continue_button.Font = New System.Drawing.Font("Javanese Text", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.continue_button.ForeColor = System.Drawing.Color.Teal
        Me.continue_button.Location = New System.Drawing.Point(46, 190)
        Me.continue_button.Name = "continue_button"
        Me.continue_button.Size = New System.Drawing.Size(98, 46)
        Me.continue_button.TabIndex = 0
        Me.continue_button.Text = "Continue"
        Me.continue_button.UseVisualStyleBackColor = True
        '
        'Quit_Button
        '
        Me.Quit_Button.AutoSize = True
        Me.Quit_Button.Font = New System.Drawing.Font("Javanese Text", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Quit_Button.ForeColor = System.Drawing.Color.Teal
        Me.Quit_Button.Location = New System.Drawing.Point(229, 190)
        Me.Quit_Button.Name = "Quit_Button"
        Me.Quit_Button.Size = New System.Drawing.Size(75, 46)
        Me.Quit_Button.TabIndex = 1
        Me.Quit_Button.Text = "Quit"
        Me.Quit_Button.UseVisualStyleBackColor = True
        '
        'Victory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(345, 261)
        Me.Controls.Add(Me.Quit_Button)
        Me.Controls.Add(Me.continue_button)
        Me.DoubleBuffered = True
        Me.Name = "Victory"
        Me.Text = "Victory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents continue_button As System.Windows.Forms.Button
    Friend WithEvents Quit_Button As System.Windows.Forms.Button
End Class
