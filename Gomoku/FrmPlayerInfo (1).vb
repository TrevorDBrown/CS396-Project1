' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' frmPlayerOne.vb - The Windows Form responsible for showing player information.

Public Class FrmPlayerInfo

    ' Current Player information form load event.
    Private Sub FrmPlayerInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Nothing to load.

    End Sub

    Sub PreparePlayerControls(ByVal PlayerOne As Player)

        ' Position the form to the left of the game board form.
        Me.Left = frmBoard.Left + frmBoard.Width

        ' Depending on the game mode, set the form text to the following:
        Me.Text = "Gomoku - " & PlayerOne.Name

        If (PlayerOne.IsHuman = False) Then
            mnuPlayerOneAction.Enabled = False   ' Disable Action button, since no human interaction is needed.
        End If

        ' Clear the player move list.
        lstPlayerOneMoveList.Items.Clear()
    End Sub

    ' Update Move List subroutine
    Public Sub UpdateMoveList(ByVal Player As Player, ByVal MoveSet As Move(), ByVal TotalMoves As Integer)

        ' Dim CurrentMoveItem As String

        ' Set title of form
        ' Me.Text = "Gomoku - " + Player.Name + "'s moves"
        Me.Text = "Gomoku - Moves of the game"

        'lstPlayerOneMoveList.Items.Clear()

        'For i As Integer = 0 To (TotalMoves - 1) Step 1
        ' CurrentMoveItem = "Stone placed at Space: " & MoveSet(i).X & ", " & MoveSet(i).Y     ' Store the latest move as a string of text.

        ' Add the latest move (as a string, parameter of subroutine), and if full, autoscroll the list.
        ' lstPlayerOneMoveList.Items.Add(CurrentMoveItem)
        ' lstPlayerOneMoveList.TopIndex = lstPlayerOneMoveList.Items.Count - 1
        ' Next

        Dim CurrentMoveItem As String = "Stone placed by " & Player.Name.ToString & " at Space: " & MoveSet(MoveSet.Length - 2).X.ToString & ", " & MoveSet(MoveSet.Length - 2).Y.ToString     ' Store the latest move as a string of text.
        lstPlayerOneMoveList.Items.Add(CurrentMoveItem)

    End Sub

    ' Player One Resign button click.
    Private Sub MnuPlayerOneResign_Click(sender As Object, e As EventArgs) Handles mnuPlayerOneResign.Click
        ' Call AutoWin function in Board.

        ' Display Feature not implemented error
        MessageBox.Show("Error: Feature not implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    ' This override allows the form's close button to be disabled.
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim Change As CreateParams = MyBase.CreateParams                ' Create a parameter instance to manipulate.
            Change.ClassStyle = Change.ClassStyle Or &H200                  ' Implement change to allow close button to disable.
            Return Change                                                   ' Return the altered setting.
        End Get
    End Property

End Class