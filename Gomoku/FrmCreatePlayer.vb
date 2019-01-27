' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' frmCreatePlayer.vb - The Windows Form that allows a user to create player object instances.

Public Class frmCreatePlayer

    ' Declares variables to be used to create a Player object instance.
    Protected IsPlayerOneHuman As Boolean
    Protected IsPlayerTwoHuman As Boolean
    Protected WhatIsBoardSize As Integer
    Protected AbsolutePlayerCount As Integer = 2       ' Integer: Player count, to change control layout.
    Protected EnteredPlayerName As String      ' String: The name the player desires to use for themselves.
    Protected SelectedPlayerColor As Color           ' Color: the preferred stone color of the player.
    Protected Randomizer As New Random()

    Protected Players(1) As Player

    ' Create Player loading procedures.
    Private Sub FrmCreatePlayer_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        ' Nothing to load.
    End Sub

    ' OK Button click event handler.
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click

        ' Validate if a name has been entered (any text), and if a stone color has been selected.
        If (txtName.Text = "") Then
            ' Show error message if no name is entered.
            MessageBox.Show("Error: No name entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If (radRed.Checked = False And radBlue.Checked = False And radGreen.Checked = False And radYellow.Checked = False) Then
            ' Show error message if no stone color is selected.
            MessageBox.Show("Error: No stone color selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' If a name has been entered, and if a stone color has been selected, store the values in a new Player object instance.
        If (txtName.Text <> "" And ((radRed.Checked = True) Or (radBlue.Checked = True) Or (radGreen.Checked = True) Or (radYellow.Checked = True))) Then
            EnteredPlayerName = txtName.Text     ' Store the text field data in the appropirate string.

            ' Validates that the selected stone color cannot be selected by another player.
            ' Stores the selcted stone color.

            If (radRed.Checked = True) Then
                SelectedPlayerColor = Color.Red
                radRed.Enabled = False
                radRed.Checked = False
            ElseIf (radBlue.Checked = True) Then
                SelectedPlayerColor = Color.Blue
                radBlue.Enabled = False
                radBlue.Checked = False
            ElseIf (radGreen.Checked = True) Then
                SelectedPlayerColor = Color.Green
                radGreen.Enabled = False
                radGreen.Checked = False
            ElseIf (radYellow.Checked = True) Then
                SelectedPlayerColor = Color.Yellow
                radYellow.Enabled = False
                radYellow.Checked = False
            End If

            ' If the Player Count is two, and both players are humans,
            ' For Player One:
            '   - Create a new player object.
            '   - Decrement the player count by 1
            '   - Replace the form title text
            '   - Clear the text box field.

            ' ElseIf the player count is one,  then
            ' For Player Two:
            '   - Create a new player object.
            '   - Show a message stating who is playing against each other
            '   - Show the board form.
            '   - Close this form.

            ' ElseIf te player count is two and the other player is a computer player
            ' For Player One:
            '   - Create a new Player object.
            ' For Computer Player:
            '   - Create a new Computer Player object.
            '   - Show a message stating who is playing against each other
            '   - Show the board form.
            '   - Close this form.

            If AbsolutePlayerCount = 2 And IsPlayerTwoHuman = True Then
                Players(0) = New Player(EnteredPlayerName, IsPlayerOneHuman, SelectedPlayerColor, 1)

                AbsolutePlayerCount -= 1

                Me.Text = "Player Two Configuration"
                txtName.Clear()

            ElseIf AbsolutePlayerCount = 1 And IsPlayerTwoHuman = True Then
                Players(1) = New Player(EnteredPlayerName, IsPlayerTwoHuman, SelectedPlayerColor, 2)
                LetsPlay(Players)

            ElseIf AbsolutePlayerCount = 1 And IsPlayerTwoHuman = False Then
                ' Player vs. Computer condition

            ElseIf AbsolutePlayerCount = 2 And IsPlayerTwoHuman = False Then
                Players(0) = New Player(EnteredPlayerName, IsPlayerOneHuman, SelectedPlayerColor, 1)

                If (Randomizer.Next(3, 5) = 3) Then
                    Players(1) = New Player("Howard Hughes", False, Color.Orange, 3)
                Else
                    Players(1) = New Player("Steve Jobs", False, Color.Black, 4)
                End If

                LetsPlay(Players)

            End If

        End If
    End Sub

    Sub LetsPlay(ByVal Players As Player())

        MessageBox.Show("Player One: " & Players(0).Name & Environment.NewLine & "Color: " & Players(0).ColorToString(Players(0).Color) & Environment.NewLine & Environment.NewLine & "Player Two: " & Players(1).Name & Environment.NewLine & "Color: " & Players(1).ColorToString(Players(1).Color), "Match", MessageBoxButtons.OK, MessageBoxIcon.None)
        frmBoard.PrepareBoardInWindow(Players, WhatIsBoardSize)
        frmBoard.Show()
        FrmIntro.Close()
        ' FrmPlayerInfo.PreparePlayerControls(Players(0))
        Me.Close()

        If (Players(0).IsHuman = False And Players(1).IsHuman = False) Then
            frmBoard.MnuAutomateGame.PerformClick()
            frmBoard.MnuAutomateGame.Enabled = False
        End If

    End Sub

    Sub PreparePlayers(ByVal PlayerOneHuman As Boolean, ByVal PlayerTwoHuman As Boolean, ByVal BoardSize As Integer)

        IsPlayerOneHuman = PlayerOneHuman
        IsPlayerTwoHuman = PlayerTwoHuman
        WhatIsBoardSize = BoardSize

        ' If both players are human, or if only one is human, set the form's title text to "Player One Configuration:
        ' Otherwise, Create the computer plays for Computer vs. Computer.
        If (PlayerOneHuman = True And PlayerTwoHuman = True) Or (PlayerOneHuman = True And PlayerTwoHuman = False) Then
            Me.Text = "Player One Configuration"
        Else
            Players(0) = New Player("Howard Hughes", False, Color.Orange, 3)
            Players(1) = New Player("Steve Jobs", False, Color.Black, 4)

            ' Begin game routine
            LetsPlay(Players)

            ' Close this form.
            Me.Close()

        End If

    End Sub


End Class
