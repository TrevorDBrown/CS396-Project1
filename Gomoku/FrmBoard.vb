' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' frmBoard.vb - The primary Windows Form of the application.

Imports System.Threading

Public Class frmBoard

    ' Variables for Game Board generation.
    Protected GameBoard As Board                      ' Board object: The "virtual game board", which the program will reference for values.
    Protected Randomizer As New Random()              ' Random: a randomizer object for randomizing elements of the game.

    ' Variables to be used in all games.
    Protected CurrentPlayer As Player               ' Player object: Player who has control of the board.
    Protected Players(1) As Player                  ' Player object array: Used to store all active players' information.

    ' Variable(s) to be used in Human vs. Computer and Computer vs. Computer games.
    Protected AutomatedThread As New Thread(AddressOf AutomateGame)     ' Thread: processes information in parallel to the main application (in background).

    Private Sub FrmBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Prepare the Automated Thread
        AutomatedThread.IsBackground = True                 ' Ensures the thread is running in the background.
        Control.CheckForIllegalCrossThreadCalls = False     ' Allows the thread to update the form, by suppressing errors related to cross-thread updating.

    End Sub

    ' Board button space click event handler.
    Private Sub BtnBoardSpace_Click(sender As Object, e As EventArgs)

        ' Declare a reference to the button that was clicked.
        Dim SelectedBoardSpace As Button = DirectCast(sender, Button)

        ' Modify the Board array content.
        GameBoard.UpdateBoard(CurrentPlayer, SelectedBoardSpace.Name)

        ' Disable button.
        SelectedBoardSpace.Enabled = False

        ' Decrement board space count by 1.
        GameBoard.RemainingSpace = GameBoard.RemainingSpace() - 1

        ' Set color of board space to current player's color.
        SelectedBoardSpace.BackColor = CurrentPlayer.Color
        CurrentPlayer.MakeMove((Integer.Parse(SelectedBoardSpace.Name) Mod GameBoard.Size), (Integer.Parse(SelectedBoardSpace.Name) \ GameBoard.Size))

        ' Check for Wins
        If (GameBoard.CheckForWinner(SelectedBoardSpace.Name) = False And GameBoard.RemainingSpace() > 0) Then
            ' No win found 
            SwapCurrentPlayer()
        ElseIf (GameBoard.CheckForWinner(SelectedBoardSpace.Name) = False And GameBoard.RemainingSpace() <= 0) Then
            ' Stalemate
            MessageBox.Show("The game has ended in stalemate.", "Stalemate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        ElseIf (GameBoard.CheckForWinner(SelectedBoardSpace.Name) = True) Then

            ' Winner found
            Dim WinnerID As Integer = CurrentPlayer.ID

            ' Display winner message, based on who won.
            If (WinnerID = Players(0).ID) Then
                MessageBox.Show("Congratulations, " & Players(0).Name & "! You've won!", "Gomoku says 'You're winner!'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf (WinnerID = Players(1).ID) Then
                MessageBox.Show("Congratulations, " & Players(1).Name & "! You've won!", "Gomoku says 'You're winner!'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            ' Close this form.
            Me.Close()
        End If

    End Sub

    ' New Game menu button click event handler
    Private Sub MnuNewGame_Click(sender As Object, e As EventArgs) Handles mnuNewGame.Click
        Me.Close()
    End Sub

    ' Exit menu button click event handler
    Private Sub MnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        If (AutomatedThread.IsAlive = True) Then
            AutomatedThread.Abort()
        End If

        Me.Close()

    End Sub

    ' About menu button click event handler
    Private Sub MnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        frmAbout.Show()
    End Sub

    ' Players Turn subroutine
    Sub SwapCurrentPlayer()

        ' Swap the players out.

        'If player one just played, swap for player two.
        If CurrentPlayer.ID = Players(0).ID Then
            CurrentPlayer = Players(1)
            Me.Text = "Gomoku - " & Players(1).Name & "'s Turn - " & GameBoard.RemainingSpace() & " spots remaining"
        ElseIf CurrentPlayer.ID = Players(1).ID Then
            'If player two just played, swap for player one.
            CurrentPlayer = Players(0)
            Me.Text = "Gomoku - " & Players(0).Name & "'s Turn - " & GameBoard.RemainingSpace() & " spots remaining"
        Else
            ' Player Swap failed.
            MessageBox.Show("Error: Player turn swap could not be completed.", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If

    End Sub

    Sub PopulateBoard(ByVal ButtonDimension As Integer)

        Dim CurrentSpacePostionX As Integer      ' Integer: Current column for placed space.
        Dim CurrentSpacePositionY As Integer     ' Integer: Current row for placed space.
        Dim CurrentXCoordinate As Integer        ' Integer: Current X coordinate for placed space.
        Dim CurrentYCoordinate As Integer        ' Integer: Current Y coordinate for placed space.

        While GameBoard.RemainingSpace() < (Math.Pow(GameBoard.Size(), 2))

            If GameBoard.RemainingSpace() = 0 Then
                ' Establish First Board Space

                ' Starting X and Y Coordinate for upper left corner of button.
                CurrentXCoordinate = 10
                CurrentYCoordinate = 30

                ' Establish X, Y position in relative grid.
                CurrentSpacePostionX = 0
                CurrentSpacePositionY = 0

                ' Declare a new button, position it in this form, and establish its attributes.
                Dim btnBoardSpace As New Button With {
                    .Location = New Point(CurrentXCoordinate, CurrentYCoordinate),    ' Starting at coordinate 10, 30
                    .Width = ButtonDimension,                       ' Button dimension (Width)
                    .Height = ButtonDimension,                      ' Button dimension (Height)
                    .Text = "",                                         ' Button text (none)
                    .BackColor = Color.BlanchedAlmond,                  ' Blanched Almond space color.
                    .Name = GameBoard.RemainingSpace()                 ' Name the button after its array index, for easier access.
                    }

                AddHandler btnBoardSpace.Click, AddressOf BtnBoardSpace_Click       ' Event handler for this button's click.
                Me.Controls.Add(btnBoardSpace)                                      ' Add button to the form.
                GameBoard.LiteralBoardSpace(GameBoard.RemainingSpace()) = btnBoardSpace   ' Add button to the Button array in the game board.

                ' Generate the logical board space, and add it to the logical (or virtual) game board.
                Dim CurrentBoardSpace As BoardSpace = New BoardSpace(btnBoardSpace.Name)
                GameBoard.AddBoardSpace(CurrentBoardSpace)

                ' Increment X Space Count by 1, increment the Current X Coordinate by the width of the button.
                CurrentSpacePostionX += 1
                CurrentXCoordinate += ButtonDimension

            ElseIf (CurrentSpacePostionX < GameBoard.Size()) And (CurrentSpacePositionY < GameBoard.Size()) Then
                ' Establish other board spaces on the same row.
                ' Declare a new button, position it in this form, and establish its attributes.
                ' Board space dimension
                ' No text in button.
                ' White back board color.
                ' Name the button after its array index, for easier access.
                Dim btnBoardSpace As New Button With {
                    .Location = New Point(CurrentXCoordinate, CurrentYCoordinate),
                    .Width = ButtonDimension,
                    .Height = ButtonDimension,
                    .Text = "",
                    .BackColor = Color.BlanchedAlmond,
                    .Name = GameBoard.RemainingSpace()
                }

                ' Event handler for this button's click.
                AddHandler btnBoardSpace.Click, AddressOf BtnBoardSpace_Click

                ' Add button to the form.
                Me.Controls.Add(btnBoardSpace)
                GameBoard.LiteralBoardSpace(GameBoard.RemainingSpace()) = btnBoardSpace

                ' Generate the logical board space, and add it to the logical (or virtual) game board.
                Dim CurrentBoardSpace As BoardSpace = New BoardSpace(btnBoardSpace.Name)
                GameBoard.AddBoardSpace(CurrentBoardSpace)

                ' Increment X Space Count by 1, increment the Current X Coordinate by the width of the button.
                CurrentSpacePostionX += 1
                CurrentXCoordinate += ButtonDimension

            ElseIf (CurrentSpacePostionX >= GameBoard.Size()) And (CurrentSpacePositionY < GameBoard.Size()) Then
                ' End of Row, start a new row.
                ' Reset X position to 1, Add 1 to Y position, set X coordinate back to 10, calculate Y coordinate based on how many rows down.
                CurrentSpacePostionX = 0
                CurrentXCoordinate = 10
                CurrentSpacePositionY += 1
                CurrentYCoordinate = (30 + (CurrentSpacePositionY * ButtonDimension))

            Else
                ' In case of an absolute problem, show a board generation error, and terminate the application.
                MessageBox.Show("Error: Board Generation Error", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End If
        End While

    End Sub

    Private Sub FrmBoard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Close the Player Information window.
        ' FrmPlayerInfo.Close()

    End Sub

    ' Board Form form closed event handler
    Private Sub FrmBoard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If (mnuNewGame.Pressed = False) Then
            ' Ask if the player is ready to quit playing.
            Dim QuitGame = MessageBox.Show("Are you done playing?", "Gomoku says 'Don't go!'", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' If so, terminate the application. Otherwise, allow the player to start a new game.
            If QuitGame = DialogResult.Yes Then
                Application.Exit()
            ElseIf QuitGame = DialogResult.No Then
                FrmIntro.Show()
            End If

        Else
            FrmIntro.Show()
        End If


    End Sub

    Sub PrepareBoardInWindow(ByVal Players As Player(), ByVal SpaceCountInRow As Integer)

        MyClass.Players = Players
        Dim PlayerOne = Players(0)
        Dim PlayerTwo = Players(1)

        ' Board Space Count preparation
        Dim BoardSpaceDimension = 30  ' Declares the board space dimension
        Dim PaddingX = 35        ' Integer: Addtional X space (void space, for aesthetics).
        Dim PaddingY = 80        ' Integer: Additional Y space (void space, for aesthetics).

        ' Compute the size of the game board window.
        Me.Size = New Size(((SpaceCountInRow * BoardSpaceDimension) + PaddingX), ((SpaceCountInRow * BoardSpaceDimension) + PaddingY))

        ' Generate Virtual Board, for computing various things.
        GameBoard = New Board(SpaceCountInRow)

        ' Generate Board (Interactive)
        ' While the current board space count is below the total board space count.
        PopulateBoard(BoardSpaceDimension)

        ' GameBoard.RemainingSpace = GameBoard.RemainingSpace() - 1     ' Decrease board space count by one, so it will accurately reflect the space count for later use.

        ' Establsish player modes as IDs and prepare gameplay.
        If (PlayerOne.IsHuman = True And PlayerTwo.IsHuman = True) Then
            ' Plauyer vs. Player
            ' Player 1 starts.

            CurrentPlayer = PlayerOne
            Me.Text = "Gomoku - " & PlayerOne.Name & "'s Turn - " & GameBoard.RemainingSpace() & " spots remaining"

        ElseIf (PlayerOne.IsHuman = True And PlayerTwo.IsHuman = False) Then
            ' Player vs. Computer
            ' Player 1 starts.

            CurrentPlayer = PlayerOne
            Me.Text = "Gomoku - " & PlayerOne.Name & "'s Turn - " & GameBoard.RemainingSpace() & " spots remaining"

        ElseIf (PlayerOne.IsHuman = False And PlayerTwo.IsHuman = False) Then
            ' Computer vs. Computer
            ' Computer Player 1 (3) starts

            If (Randomizer.Next(3, 5) = 3) Then
                Me.Text = "Gomoku - " & PlayerOne.Name & "'s Turn - " & GameBoard.RemainingSpace() & " spots remaining"
                CurrentPlayer = Players(0)
            Else
                Me.Text = "Gomoku - " & PlayerTwo.Name & "'s Turn - " & GameBoard.RemainingSpace() & " spots remaining"
                CurrentPlayer = Players(1)
            End If

        Else
            MessageBox.Show("Error: Indeterminate player mode.", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If

        ' Position forms that are displayed, so:
        '   - Board form is center screen
        '   - Player Move Information form is on the righthand side of the board form.

        Me.CenterToScreen()
        ' FrmPlayerInfo.Show()

    End Sub

    Sub AutomateGame()

        Do
            Dim CurrentBoardSpace = GameBoard.LiteralBoardSpace(Randomizer.Next(0, Math.Pow(GameBoard.Size, 2) - 1))
            Dim AssociatedSpace = GameBoard.BoardSpace(Integer.Parse(CurrentBoardSpace.Name)).SpaceOccupation

            If (AssociatedSpace = False) Then
                CurrentBoardSpace.PerformClick()
                Thread.Sleep(125)
            End If

        Loop While (GameBoard.Winner = False)

    End Sub

    Private Sub MnuAutomateGame_Click(sender As Object, e As EventArgs) Handles MnuAutomateGame.Click
        AutomatedThread.Start()
    End Sub

End Class
