Public Class Victory

    Private Sub continue_button_Click(sender As Object, e As EventArgs) Handles continue_button.Click
        Me.Hide()
    End Sub

    Private Sub Quit_Click(sender As Object, e As EventArgs) Handles Quit_Button.Click
        Me.Hide()
        Quit = True
    End Sub
End Class