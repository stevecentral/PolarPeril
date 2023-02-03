Public Class uDIE

    Private Sub continue_button_Click(sender As Object, e As EventArgs) Handles continue_button.Click

        Me.Hide()
    End Sub

    Private Sub quit_Button_Click(sender As Object, e As EventArgs) Handles quit_Button.Click

        Me.Hide()
        Quit = True
    End Sub
End Class