Public Class gameover

    Private Sub tryagain_Click(sender As Object, e As EventArgs) Handles tryagain.Click

        Me.Hide()
    End Sub

    Private Sub quit_Click(sender As Object, e As EventArgs) Handles otherquit.Click

        Me.Hide()
        Quit = True
    End Sub
End Class