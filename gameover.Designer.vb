<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gameover
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gameover))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tryagain = New System.Windows.Forms.Button()
        Me.otherquit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Javanese Text", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(103, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 47)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Game Over"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tryagain
        '
        Me.tryagain.AutoSize = True
        Me.tryagain.Font = New System.Drawing.Font("Javanese Text", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tryagain.ForeColor = System.Drawing.Color.Teal
        Me.tryagain.Location = New System.Drawing.Point(37, 194)
        Me.tryagain.Name = "tryagain"
        Me.tryagain.Size = New System.Drawing.Size(107, 46)
        Me.tryagain.TabIndex = 1
        Me.tryagain.Text = "Try Again"
        Me.tryagain.UseVisualStyleBackColor = True
        '
        'otherquit
        '
        Me.otherquit.AutoSize = True
        Me.otherquit.Font = New System.Drawing.Font("Javanese Text", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.otherquit.ForeColor = System.Drawing.Color.Teal
        Me.otherquit.Location = New System.Drawing.Point(174, 194)
        Me.otherquit.Name = "otherquit"
        Me.otherquit.Size = New System.Drawing.Size(75, 46)
        Me.otherquit.TabIndex = 2
        Me.otherquit.Text = "Quit"
        Me.otherquit.UseVisualStyleBackColor = True
        '
        'gameover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.otherquit)
        Me.Controls.Add(Me.tryagain)
        Me.Controls.Add(Me.Label1)
        Me.Name = "gameover"
        Me.Text = "gameover"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tryagain As System.Windows.Forms.Button
    Friend WithEvents otherquit As System.Windows.Forms.Button
End Class
