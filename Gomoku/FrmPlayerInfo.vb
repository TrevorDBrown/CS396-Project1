' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' frmPlayerOne.vb - The Windows Form responsible for showing player information.

Public Class FrmPlayerInfo

    ' Player One information form load event.
    Private Sub FrmPlayerOne_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Nothing to load.

    End Sub

    Sub PreparePlayerControls(ByVal PlayerOne As Player)
        ' Position the form on the left side of the Board form.
        Me.Left = frmBoard.Left - Me.Width

        ' Depending on the game mode, set the form text to the following:
        Me.Text = "Gomoku - Moves of the game"

        ' Clear the player move list.
        lstPlayerOneMoveList.Items.Clear()

    End Sub

    ' Update Move List subroutine
    Public Sub UpdateMoveList(ByVal Player As Player, ByVal MoveSet As Move(), ByVal TotalMoves As Integer)

        Dim CurrentMoveItem As String = "Stone placed by " & Player.Name & " at Space: " & MoveSet(MoveSet.Length - 2).X & ", " & MoveSet(MoveSet.Length - 2).Y

        If lstPlayerOneMoveList.InvokeRequired Then
            lstPlayerOneMoveList.Invoke(Sub() lstPlayerOneMoveList.Items.Add(CurrentMoveItem))
        Else
            lstPlayerOneMoveList.Items.Add(CurrentMoveItem)
        End If

        lstPlayerOneMoveList.Update()
        lstPlayerOneMoveList.TopIndex = lstPlayerOneMoveList.Items.Count - 1

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