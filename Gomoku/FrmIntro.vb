' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' frmIntro.vb - The Windows Form that the application starts with.

Public Class FrmIntro

    ' Declare variables for manipulating form objects.
    Dim intTextSlideTickCount As Integer    ' Integer variable for storing total tick cout for the Text Slide Timer.
    Dim intTextSlideState As Integer        ' Integer variable for storing the text slide state.

    ' Declare variables for game preparation
    Dim IsPlayerOneHuman As Boolean
    Dim IsPlayerTwoHuman As Boolean
    Dim BoardSize As Integer

    ' Introduction form load event handler
    Private Sub FrmIntro_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ' Start text animation in state 0: Application Startup, New Game
        intTextSlideState = 0
        tmrTextSlideStart.Start()

        ' Remove these two enable statements once AI works.
        radComputerVsComputer.Enabled = True
        radPlayerVsComputer.Enabled = True
    End Sub

    ' Text Slide Start Timer Tick event handler.
    Private Sub TmrTextSlideStart_Tick(sender As Object, e As EventArgs) Handles tmrTextSlideStart.Tick
        ' Allows for a delay in animation.
        tmrTextSlide.Start()        ' Start the Text Slide Timer.
        tmrTextSlideStart.Stop()    ' Stop the Text Slide Start Timer.
    End Sub

    ' Text Slide Timer Ticket event handler.
    Private Sub TmrTextSlide_Tick(sender As Object, e As EventArgs) Handles tmrTextSlide.Tick

        ' If the slied state is in 0:
        '   - Add one to the tick counter.
        If intTextSlideState = 0 Then
            intTextSlideTickCount += 1              ' Adds 1 to the total Text Slide Timer Ticket Count

            ' If the tick counter is below 100, shift the title label up by 1.
            If intTextSlideTickCount <= 100 Then
                lblTitle.Top = lblTitle.Top - 1
            Else
                ' Otherwise, stop the animation and show all the main menu buttons.
                tmrTextSlide.Stop()
                intTextSlideTickCount = 0
                btnStartGame.Visible = True
                btnAbout.Visible = True
                btnHowToPlay.Visible = True
                btnExit.Visible = True
            End If

            ' End Text Slide State 0 Code


        ElseIf intTextSlideState = 1 Then
            ' If the text slide state = 1 : Begin a game
            '   - Hide all main menu buttons.
            btnStartGame.Visible = False
            btnAbout.Visible = False
            btnHowToPlay.Visible = False
            btnExit.Visible = False

            ' Increase the tick counter by 1.
            intTextSlideTickCount += 1

            ' If the tick count is below 150, shift the title text label left.
            If intTextSlideTickCount <= 150 Then
                lblTitle.Left -= 1
            Else
                ' Otherwise,
                ' - Show the New Game options.
                tmrTextSlide.Stop()
                intTextSlideTickCount = 0
                grpBoardSize.Visible = True
                grpPlayerMode.Visible = True
                btnPlayNow.Visible = True
                btnCancelGame.Visible = True
            End If

            ' End Text Slide State 1 Code


        ElseIf intTextSlideState = 2 Then
            ' If the new game is canceled, reverse the animation in state 1.
            '   - Hide all new game elements.
            grpBoardSize.Visible = False
            grpPlayerMode.Visible = False
            btnPlayNow.Visible = False
            btnCancelGame.Visible = False

            ' Increase the tick counter by 1.
            intTextSlideTickCount += 1

            ' If the tick count is below 150
            If intTextSlideTickCount <= 150 Then
                ' Shift the text label to the left.
                lblTitle.Left += 1
            Else
                ' Otherwise, stop the animation and restore the main menu buttons.
                tmrTextSlide.Stop()
                intTextSlideTickCount = 0
                btnStartGame.Visible = True
                btnAbout.Visible = True
                btnHowToPlay.Visible = True
                btnExit.Visible = True
            End If
        End If

    End Sub

    ' Exit Button click event handler.
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()  ' Terminates the application.
    End Sub

    ' Start Game Button click event handler.
    Private Sub BtnStartGame_Click(sender As Object, e As EventArgs) Handles btnStartGame.Click
        ' Begin Text Slide State 1: New Game.
        intTextSlideState = 1
        tmrTextSlide.Start()
    End Sub

    ' Play Now event handler.
    Private Sub BtnPlayNow_Click(sender As Object, e As EventArgs) Handles btnPlayNow.Click
        ' Validate that both a Player Mode and Board Size is checked.
        ' If validation fails, show error messages.
        If (radPlayerVsPlayer.Checked = False And radPlayerVsComputer.Checked = False And radComputerVsComputer.Checked = False) Then
            ' No Player Mode error
            MessageBox.Show("Error: No Player Mode selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If (radTwelve.Checked = False And radFifteen.Checked = False And radNineteen.Checked = False) Then
            ' No Board Size error
            MessageBox.Show("Error: No Board Size selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' If validation succeeds, store values for game play.
        If ((radPlayerVsPlayer.Checked = True Or radPlayerVsComputer.Checked = True Or radComputerVsComputer.Checked = True) And (radTwelve.Checked = True Or radFifteen.Checked = True Or radNineteen.Checked = True)) Then

            If radPlayerVsPlayer.Checked = True Then
                ' Both Players Human
                IsPlayerOneHuman = True
                IsPlayerTwoHuman = True
                frmCreatePlayer.Show()

            ElseIf radPlayerVsComputer.Checked = True Then
                ' Player One Human, Player Two Computer
                IsPlayerOneHuman = True
                IsPlayerTwoHuman = False
                frmCreatePlayer.Show()

            ElseIf radComputerVsComputer.Checked = True Then
                ' Both Players Computer
                IsPlayerOneHuman = False
                IsPlayerTwoHuman = False
            End If

            If radTwelve.Checked = True Then
                ' 12 x 12 board
                BoardSize = 12

            ElseIf radFifteen.Checked = True Then
                ' 15 x 15 board
                BoardSize = 15

            ElseIf radNineteen.Checked = True Then
                ' 19 x 19 board.
                BoardSize = 19
            End If

            ' Show Create Player form, and close this form.
            frmCreatePlayer.PreparePlayers(IsPlayerOneHuman, IsPlayerTwoHuman, BoardSize)

        End If
    End Sub

    ' Cancel Game Button click event handler.
    Private Sub BtnCancelGame_Click(sender As Object, e As EventArgs) Handles btnCancelGame.Click
        ' Start Text Slide with State 2: Canceled Game (aka reversed Play a Game)
        intTextSlideState = 2
        tmrTextSlide.Start()
    End Sub

    ' How to Play Button click event handler.
    Private Sub BtnHowToPlay_Click(sender As Object, e As EventArgs) Handles btnHowToPlay.Click
        ' Initialize a string variable for the URL of a Gomoku rules webpage.
        Dim strHowToPlayWeb = "http://gamerulesguru.com/gomoku.shtml"

        ' Open the webpage in the client's default browser.
        Process.Start(strHowToPlayWeb)
    End Sub

    ' About Button click event handler.
    Private Sub BtnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        ' Show the About form.
        frmAbout.Show()
    End Sub
End Class
