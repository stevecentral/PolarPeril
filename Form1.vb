Public Class mainForm
    Dim nStuff As SpriteType
    Dim NAnim As nansenSprite
    Dim Ladders(NUMLADDERS) As PictureBox
    Const NUMLADDERS As Integer = 6
    Dim Floors(NUMFLOORS) As floortype
    Const NUMFLOORS As Integer = 6
    Dim Balls(NUMBALLS) As PictureBox
    Const NUMBALLS As Integer = 3
    Dim bstuff(NUMBALLS) As SpriteType
    Dim BAnim(3) As Image
    Public Shared uDIEForm As New uDIE
    Dim ThrowTimer As Integer
    Dim BobAnim(6) As Image
    Dim BobDancing As Boolean
    Dim lives(2) As PictureBox
    Dim livesleft As Integer = 2
    Public Shared VictoryForm As New Victory
    Public Shared gameoverForm As New gameover
    Dim score As Integer

    Private Sub moveNansen()

        nStuff.FloorNumber = GetFloorNumber(nansen)
        'Enable boundaries 
        If nansen.Left < 77 Then
            nansen.Left = 77
            nStuff.Speed.X = 0
        End If
        If nansen.Left > 540 Then
            nansen.Left = 540
            nStuff.Speed.X = 0
        End If

        'Enable the jumping mechanics 
        If nStuff.Floating = True Then
            Call JumpingMechanics(nStuff)

        Else
            nStuff.OnLadder = checkladder()
            If nStuff.OnLadder = False Then
                Call MoveOnFloor(nStuff, nansen)
            Else
                nStuff.Speed.X = 0
            End If
        End If
        nansen.Left = nansen.Left + nStuff.Speed.X
        nansen.Top = nansen.Top + nStuff.Speed.Y
    End Sub

    Private Sub MoveBall(ByVal Index As Integer)

        bstuff(Index).FloorNumber = GetFloorNumber(Balls(Index))
        'Enable boundaries 
        If Balls(Index).Left < 77 Then
            Balls(Index).Left = 77
            bstuff(Index).Speed.X = 0
        End If
        If Balls(Index).Left > 540 Then
            Balls(Index).Left = 540
            bstuff(Index).Speed.X = 0
        End If
        'Enable the jumping mechanics 
        If bstuff(Index).Floating = True Then
            Call JumpingMechanics(bstuff(Index))

        Else
            bstuff(Index).OnLadder = BallCheckLadder(Index)
            If bstuff(Index).OnLadder = False Then
                If Floors(bstuff(Index).FloorNumber).Slope > 0 Then
                    bstuff(Index).Speed.X = 5
                ElseIf Floors(bstuff(Index).FloorNumber).Slope < 0 Then
                    bstuff(Index).Speed.X = -5
                End If
                Call MoveOnFloor(bstuff(Index), Balls(Index))
            Else
                bstuff(Index).Speed.X = 0
                bstuff(Index).Speed.Y = 10
                bstuff(Index).Floating = True
            End If
        End If
        Balls(Index).Left = Balls(Index).Left + bstuff(Index).Speed.X
        Balls(Index).Top = Balls(Index).Top + bstuff(Index).Speed.Y
        If bstuff(Index).FloorNumber = 0 And Balls(Index).Left < 77 Then
            Balls(Index).Visible = False
            BobDancing = False
            ThrowTimer = 0
        End If
    End Sub

    Private Sub ThrowBalls()

        Dim Done As Boolean
        Dim Index As Integer
        ThrowTimer = ThrowTimer + 1
        If ThrowTimer = 40 Then
            ThrowTimer = 0
            Do While Done = False
                If Balls(Index).Visible = False Then
                    Done = True
                    Balls(Index).Visible = True
                    Balls(Index).Top = 70
                    Balls(Index).Left = 203
                    bstuff(Index).Floating = False
                    bstuff(Index).Speed.X = 5
                    bstuff(Index).Speed.Y = 0
                    bstuff(Index).OnFloor = True
                    bstuff(Index).OnLadder = False
                    bstuff(Index).picnum = 1
                    BobDancing = True
                    For cindex = 0 To 3
                        If Balls(cindex).Visible = False Then
                            BobDancing = False
                        End If
                    Next
                End If
                Index = Index + 1
                If Index = 4 Then
                    Done = True
                End If
            Loop
        End If
    End Sub

    Private Sub animateNansen()

        If nStuff.Speed.Y <> 0 Then
            If nStuff.Floating = True Then
                Call AnimateJump()
            Else
                Call Animateclimb()
            End If

        ElseIf nStuff.OnLadder = False Then
            If nStuff.Speed.X < 0 Then
                Call AnimteLeft()

            ElseIf nStuff.Speed.X > 0 Then
                Call AnimateRight()

            Else
                Call AnimateStanding()
            End If
        End If
    End Sub

    Private Sub animateBob()

            If BobDancing Then
                If ThrowTimer < 9 Then
                    bob.Image = BobAnim(6)
                ElseIf ThrowTimer < 16 Then
                    bob.Image = BobAnim(0)
                ElseIf ThrowTimer < 24 Then
                    bob.Image = BobAnim(1)
                Else
                    bob.Image = BobAnim(5)
                End If
            Else
                If ThrowTimer < 7 Then
                    bob.Image = BobAnim(6)
                ElseIf ThrowTimer < 17 Then
                    bob.Image = BobAnim(2)
                ElseIf ThrowTimer < 30 Then
                    bob.Image = BobAnim(3)
                Else
                    bob.Image = BobAnim(4)
                End If
            End If
    End Sub

    Private Sub MoveOnFloor(ByRef Sprite As SpriteType, ByRef Image As PictureBox)

        Sprite.Speed.Y = 0
        Sprite.OnFloor = True
        Image.Top = Floors(Sprite.FloorNumber).Slope * (Image.Left - Floors(Sprite.FloorNumber).X) + Floors(Sprite.FloorNumber).Y - Image.Height
        If Image.Left > Floors(Sprite.FloorNumber).RightEdge Then
            Sprite.Speed.Y = 10
            Sprite.Floating = True
            Sprite.Floattime = 1

        End If
        If Image.Right < Floors(Sprite.FloorNumber).LeftEdge Then
            Sprite.Speed.Y = 10
            Sprite.Floating = True
            Sprite.Floattime = 1
        End If
    End Sub

    Private Sub JumpingMechanics(ByRef Stuff As SpriteType)

        If Stuff.Floattime = 7 Then
            If Stuff.Speed.Y = -5 Then
                Stuff.Speed.Y = 5
            Else
                Stuff.Speed.Y = 0
                Stuff.Floating = False
            End If
            Stuff.Floattime = 1
        Else
            Stuff.Floattime = Stuff.Floattime + 1
        End If
    End Sub

    Private Sub Animateclimb()

        nansen.Image = NAnim.ClimbSprites(nStuff.picnum)
        nStuff.picnum = (nStuff.picnum + 1) Mod 3
    End Sub

    Private Sub AnimateJump()

        If nStuff.Speed.X > 0 Or NAnim.FacingRight = True Then
            nansen.Image = NAnim.RightJump
        ElseIf nStuff.Speed.X < 0 Or NAnim.FacingRight = False Then
            nansen.Image = NAnim.LeftJump
        End If
    End Sub

    Private Sub AnimteLeft()

        nansen.Image = NAnim.LeftSprites(nStuff.picnum)
        nStuff.picnum = (nStuff.picnum + 1) Mod 3
    End Sub

    Private Sub AnimateRight()

        nansen.Image = NAnim.RightSprites(nStuff.picnum)
        nStuff.picnum = (nStuff.picnum + 1) Mod 3
    End Sub

    Private Sub AnimateStanding()

        If NAnim.FacingRight = True Then
            nansen.Image = NAnim.RightSprites(0)
        End If
        If NAnim.FacingRight = False Then
            nansen.Image = NAnim.LeftSprites(0)
        End If
    End Sub

    Private Sub AnimateBall(ByVal Index As Integer)

        bstuff(Index).picnum = (bstuff(Index).picnum + 1) Mod 4
        Balls(Index).Image = BAnim(bstuff(Index).picnum)
    End Sub

    Private Function checkladder()

        Dim Index As Integer
        For Index = 0 To NUMLADDERS
            Dim ladderoffset As Integer
            ladderoffset = 15
            If nansen.Left > (Ladders(Index).Left - ladderoffset) And nansen.Right < Ladders(Index).Right + ladderoffset Then
                If nStuff.Speed.Y < 0 Then
                    If nansen.Bottom > Ladders(Index).Top And nansen.Top < Ladders(Index).Bottom Then
                        Return True
                    End If

                ElseIf nStuff.Speed.Y > 0 Then
                    If nansen.Bottom > Ladders(Index).Top - ladderoffset And nansen.Bottom < (Ladders(Index).Bottom) Then
                        Return True
                    End If
                Else
                    If nansen.Bottom < (Ladders(Index).Bottom - ladderoffset) And nansen.Bottom > (Ladders(Index).Top + ladderoffset) Then
                        Return True
                    End If
                End If
            End If
        Next Index
    End Function

    Private Function BallCheckLadder(ByVal cIndex As Integer)

        Dim Index As Integer
        Dim ladderoffset As Integer
        ladderoffset = 13
        If 0 = Int(Rnd() * 6) Then
            For Index = 0 To NUMLADDERS
                If Balls(cIndex).Left > Ladders(Index).Left And Balls(cIndex).Right < Ladders(Index).Right Then
                    If (Balls(cIndex).Bottom + ladderoffset) > Ladders(Index).Top And (Balls(cIndex).Bottom - ladderoffset) < Ladders(Index).Top Then
                        Return True
                    End If
                End If

            Next Index
        End If
    End Function

    Private Function GetFloorNumber(ByVal Thing As PictureBox)

        If Thing.Top < 20 Then
            Return 6
        ElseIf Thing.Top < 73 Then
            Return 5
        ElseIf Thing.Top < 160 Then
            Return 4
        ElseIf Thing.Top < 240 Then
            Return 3
        ElseIf Thing.Top < 320 Then
            Return 2
        ElseIf Thing.Top < 393 Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Private Function Touching(ByVal PictureBox1 As PictureBox, ByVal PictureBox2 As PictureBox)

        If PictureBox1.Left < PictureBox2.Right And PictureBox1.Right > PictureBox2.Left Then
            If PictureBox1.Top < PictureBox2.Bottom And PictureBox1.Bottom > PictureBox2.Top Then
                Return True
            End If
        End If
    End Function


    Private Sub mainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'Might need to change later
        'Enabled speed to update Nansen
        If e.KeyCode = Keys.A Then
            If nansen.Left >= 77 Then
                NAnim.FacingRight = False
                nStuff.Speed.X = -5
            End If
        End If
        If e.KeyCode = Keys.D Then
            If nansen.Left <= 540 Then
                NAnim.FacingRight = True
                nStuff.Speed.X = 5
            End If
        End If
        If e.KeyCode = Keys.Space And nStuff.Speed.Y = 0 And nStuff.OnFloor = True Then
            nStuff.Speed.Y = -5
            nStuff.Floattime = 0
            nStuff.Floating = True
            nStuff.OnFloor = False
        End If
        If e.KeyCode = Keys.W And nStuff.Floating = False Then
            nStuff.Speed.Y = -5
        End If
        If e.KeyCode = Keys.S And nStuff.Floating = False Then
            nStuff.Speed.Y = 5
        End If
    End Sub

    Public Sub FloorSet()

        Floors(0).Slope = -0.00001
        Floors(1).Slope = 0.078
        Floors(2).Slope = -0.078
        Floors(3).Slope = 0.078
        Floors(4).Slope = -0.078
        Floors(5).Slope = 0
        Floors(6).Slope = 0

        Floors(0).X = 137
        Floors(1).X = 137
        Floors(2).X = 137
        Floors(3).X = 137
        Floors(4).X = 137
        Floors(5).X = 137
        Floors(6).X = 137

        Floors(0).Y = 465
        Floors(1).Y = 377
        Floors(2).Y = 327
        Floors(3).Y = 226
        Floors(4).Y = 176
        Floors(5).Y = 92
        Floors(6).Y = 42

        Floors(0).LeftEdge = 0
        Floors(1).LeftEdge = 0
        Floors(2).LeftEdge = 133
        Floors(3).LeftEdge = 0
        Floors(4).LeftEdge = 133
        Floors(5).LeftEdge = 0
        Floors(6).LeftEdge = 200

        Floors(0).RightEdge = 570
        Floors(1).RightEdge = 507
        Floors(2).RightEdge = 570
        Floors(3).RightEdge = 507
        Floors(4).RightEdge = 570
        Floors(5).RightEdge = 507
        Floors(6).RightEdge = 312
    End Sub

    Private Sub LoadLives()

        lives(0) = lives0
        lives(1) = lives1
        lives(2) = lives2

    End Sub

    Private Sub LoadBalls()

        Balls(0) = ball0
        Balls(1) = ball1
        Balls(2) = ball2
        Balls(3) = ball3

        For Index = 0 To 3
            Balls(Index).Visible = False
            bstuff(Index).Floating = False
            bstuff(Index).OnLadder = False
            bstuff(Index).Speed.Y = 0
            bstuff(Index).Speed.X = 10
            bstuff(Index).picnum = 0
            Balls(Index).Top = 70
            Balls(Index).Left = 203
        Next
    End Sub

    Private Sub LoadLadders()

        Ladders(0) = Ladder0
        Ladders(1) = Ladder1
        Ladders(2) = Ladder2
        Ladders(3) = Ladder3
        Ladders(4) = Ladder4
        Ladders(5) = Ladder5
        Ladders(6) = Ladder6
    End Sub

    Private Sub NansenSet()

        nansen.Top = 430
        nansen.Left = 104
        nStuff.picnum = 0
        nStuff.Speed.Y = 0
        nStuff.Speed.X = 0
        nStuff.Floating = False
        nStuff.OnLadder = False
        nStuff.OnFloor = True
        NAnim.FacingRight = True
        nansen.Image = NAnim.RightSprites(0)
    End Sub

    Private Sub LoadAnimations()
        'Load Right Images
        ReDim NAnim.RightSprites(2)
        NAnim.RightSprites(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenRightMove1.jpg")
        NAnim.RightSprites(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenRightMove2.jpg")
        NAnim.RightSprites(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenRightMove3.jpg")
        'Load Left Images
        ReDim NAnim.LeftSprites(2)
        NAnim.LeftSprites(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenLeftMove1.jpg")
        NAnim.LeftSprites(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenLeftMove2.jpg")
        NAnim.LeftSprites(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenLeftMove3.jpg")
        'Load Jump Images
        NAnim.LeftJump = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenLeftFloat.jpg")
        NAnim.RightJump = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenRightFloat.jpg")
        'Load climb Images
        ReDim NAnim.ClimbSprites(2)
        NAnim.ClimbSprites(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenClimb1.jpg")
        NAnim.ClimbSprites(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenClimb2.jpg")
        NAnim.ClimbSprites(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\nansenClimb3.jpg")
        'Load ball Images
        BAnim(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\Ball1.jpg")
        BAnim(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\Ball2.jpg")
        BAnim(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\Ball3.jpg")
        BAnim(3) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\Ball4.jpg")
        'Load Bob Images
        BobAnim(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobDancing.jpg")
        BobAnim(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobDancing2.jpg")
        BobAnim(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobGettingBall.jpg")
        BobAnim(3) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobHoldingBall.jpg")
        BobAnim(4) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobRollingBall.jpg")
        BobAnim(5) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobSmiling.jpg")
        BobAnim(6) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Pics\BobStanding.jpg")
    End Sub

    Private Sub ResetLevel()

        Call LoadBalls()
        Call LoadLadders()
        Call FloorSet()
        Call NansenSet()
        BobDancing = False
    End Sub

    Private Sub FlashHelp()

        If help.Visible = True Then
            help.Visible = False
        Else
            help.Visible = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles mainTimer.Tick

        Call moveNansen()
        Call animateNansen()
        Call ThrowBalls()
        Call animateBob()
        'Call FlashHelp()
        For Index = 0 To NUMBALLS
            If Balls(Index).Visible = True Then
                Call MoveBall(Index)
                Call AnimateBall(Index)
                If Touching(nansen, Balls(Index)) = True Then
                    If livesleft = 0 Then
                        mainTimer.Stop()
                        gameoverForm.ShowDialog()
                        Call ResetLevel()
                        livesleft = 2
                        mainTimer.Start()
                        lives(0).Visible = True
                        lives(1).Visible = True
                        lives(2).Visible = True
                    Else
                        mainTimer.Stop()
                        lives(livesleft).Visible = False
                        livesleft = livesleft - 1
                        uDIEForm.ShowDialog()
                        Call ResetLevel()
                        mainTimer.Start()
                    End If
                End If
            End If
        Next Index
        If Quit = True Then
            Me.Close()
        End If
        If Touching(nansen, penguin) = True Then
            mainTimer.Stop()
            VictoryForm.ShowDialog()
            Call ResetLevel()
            mainTimer.Start()
        End If
        If Quit = True Then
            Me.Close()
        End If
    End Sub

    Private Sub mainForm_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        If e.KeyCode = Keys.A Or e.KeyCode = Keys.D Then
            nStuff.Speed.X = 0
        End If
        If e.KeyCode = Keys.W Or e.KeyCode = Keys.S Then
            If nStuff.Floating = False Then
                nStuff.Speed.Y = 0
            End If
        End If
    End Sub

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call LoadLives()
        Call LoadAnimations()
        Call ResetLevel()
        My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\Music\Ransom.wav", AudioPlayMode.BackgroundLoop)
        mainTimer.Start()
    End Sub
End Class
