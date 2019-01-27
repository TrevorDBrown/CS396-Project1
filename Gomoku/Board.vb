' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' Board.vb - Allows the application to develop a reference board for computations.

Public Class Board

    ' Board object properties
    Protected BoardSize As Integer                  ' Integer: Board Size (i.e. space count by space count)
    Protected TotalBoardSpaceCount As Integer       ' Integer: Total Board Space Count
    Protected RemainingBoardSpaceCount As Integer   ' Integer: Remaining Space Count (while in game)

    Protected IDofPotentialWinner As Integer        ' Integer: Numeric representation of the player being observed for a win.
    Protected WinnerExists As Boolean               ' Boolean: Boolean representation of win state.

    Protected BoardSpaces As BoardSpace()           ' Board Space Array: Primary component of a virtual Gomoku board.
    Protected Buttons As Button()                   ' Button Array: Visual component of the Gomoku board

    ' Gomoku Board constructor
    Sub New(ByVal UserSelectedBoardSize As Integer)

        BoardSize = UserSelectedBoardSize                                ' Initialize board size (number of spaces)
        TotalBoardSpaceCount = Math.Pow(UserSelectedBoardSize, 2)       ' Initialize total space count (width * height)
        RemainingBoardSpaceCount = 0                                    ' Initialize current space count (0)
        WinnerExists = False

        ReDim BoardSpaces(TotalBoardSpaceCount - 1)                 ' Redeclare the virtual game board in memory, sizing it to the total space count.
        ReDim Buttons(TotalBoardSpaceCount - 1)                     ' Redclare the button array in memorym sizing it to the total space count.

    End Sub

    ' The following code is used to establish  for properties of a board instance.

    Public Property LiteralBoardSpace(ByVal Index As Integer) As Button
        Get
            Return Buttons(Index)
        End Get

        Set(value As Button)
            Buttons(Index) = value
        End Set
    End Property

    Public Property BoardSpace(ByVal Index As Integer) As BoardSpace
        Get
            Return BoardSpaces(Index)
        End Get
        Set(value As BoardSpace)
            BoardSpace(Index) = value
        End Set
    End Property

    Public Property RemainingSpace() As Integer
        Set(value As Integer)
            RemainingBoardSpaceCount = value
        End Set

        Get
            Return RemainingBoardSpaceCount
        End Get
    End Property

    Public ReadOnly Property Size() As Integer
        Get
            Return BoardSize
        End Get
    End Property

    Public ReadOnly Property Winner() As Boolean
        Get
            Return WinnerExists
        End Get
    End Property

    ' The following code are operations performed on the board before and during game play.

    ' Gomoku Virtual Board Subroutine - Add Board Space
    Sub AddBoardSpace(ByVal BoardSpaceToAdd As BoardSpace)
        ' If the total space count is less than the current space count, report an error.
        If (TotalBoardSpaceCount < RemainingBoardSpaceCount) Then
            MessageBox.Show("Error: Cannot add board space. Board is full.", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()  ' Terminate the application.

            ' Otherwise, add the board space from the parameter of the subroutine to the virtual board.
        Else
            BoardSpaces(RemainingBoardSpaceCount) = BoardSpaceToAdd  ' Add the board space at the current space count.
            RemainingBoardSpaceCount += 1                   ' Increment the current space count by 1.

        End If
    End Sub

    ' Gomoku Virtual Board Subroutine - Update Board Information
    Sub UpdateBoard(ByVal CurrentPlayer As Player, SpaceName As String)
        BoardSpaces(Integer.Parse(SpaceName)).SpaceOccupation = True                   ' Change the status of the space to disabled.
        BoardSpaces(Integer.Parse(SpaceName)).Owner = CurrentPlayer.ID   ' Change the ownership of the space to the current player.
    End Sub


    ' The following code is used to process game logic functions, such as checking for a win on the game board.

    ' Game Logic Function: Check for Winner
    Function CheckForWinner(ByVal CurrentSpace As Integer) As Integer

        ' The following is the order in which a win is checked.
        '   - Right of placed stone.
        '   - Left of placed stone.
        '   - Above a placed stone.
        '   - Below a placed stone.
        '   - Diagonally, down and to the left, from a placed stone.
        '   - Diagonally, up and to the left, from a placed stone.
        '   - Diagonally, down and to the right, from a placed stone.
        '   - Diagonally, up and to the right, from a placed stone.

        ' If any of these conditions are met, the numeric representation of the player is
        ' returned to the request.
        ' Otherwise, 0 is returned.

        If CheckRight(CurrentSpace) = False Then
            If CheckLeft(CurrentSpace) = False Then
                If CheckUp(CurrentSpace) = False Then
                    If CheckDown(CurrentSpace) = False Then
                        If CheckDiagDL(CurrentSpace) = False Then
                            If CheckDiagUL(CurrentSpace) = False Then
                                If CheckDiagDR(CurrentSpace) = False Then
                                    If CheckDiagUR(CurrentSpace) = False Then
                                        WinnerExists = False
                                    Else
                                        WinnerExists = True
                                    End If
                                Else
                                    WinnerExists = True
                                End If
                            Else
                                WinnerExists = True
                            End If
                        Else
                            WinnerExists = True
                        End If
                    Else
                        WinnerExists = True
                    End If
                Else
                    WinnerExists = True
                End If
            Else
                WinnerExists = True
            End If
        Else
            WinnerExists = True
        End If

        Return WinnerExists

    End Function

    ' Game Logic Function: Check right of the placed stone for a winner.
    Function CheckRight(CurrentBoardSpace As Integer) As Boolean

        ' Win check preperations:
        Dim WinFromRight As Boolean = False                              ' Set default response.
        IDofPotentialWinner = BoardSpaces(CurrentBoardSpace).Owner    ' Set potential winner (aka the player who placed the last stone)
        Dim ConsectutiveStoneCount = 1                                           ' Set the consecutive stone count.
        Dim XIndex = (BoardSpaces(CurrentBoardSpace).ID Mod BoardSize)                          ' Set the index X, for the practical application check.

        ' If the X index, when increased by 4, does not exceed the board's width, proceed to check for a win from the right.
        If (XIndex + 4) < BoardSize Then
            ' From one space to the right to four spaces to the right, check each space ownership.
            For intCount As Integer = (CurrentBoardSpace + 1) To (CurrentBoardSpace + 4) Step +1

                ' If the space ownership comparison between the current player and the current space succeed, increment the consecutive stone counter.
                If BoardSpaces(intCount).Owner = IDofPotentialWinner Then
                    ConsectutiveStoneCount += 1
                End If
            Next

            ' If 5 consecutive stones are marked, declare the current player the winner.
            If ConsectutiveStoneCount >= 5 Then
                WinFromRight = True

                ' Otherwise, declare no win, and reset the consecutive stone counter.
            ElseIf ConsectutiveStoneCount < 5 Then
                WinFromRight = False
                ConsectutiveStoneCount = 0
            End If

        End If

        Return WinFromRight  ' Respond to the request with the result.

    End Function

    ' Game Logic Function: Check left of the placed stone for a winner.
    Function CheckLeft(CurrentBoardSpace As Integer) As Boolean

        ' Win check preperations:
        Dim WinFromLeft As Boolean = False                                   ' Set default response.
        IDofPotentialWinner = BoardSpaces(CurrentBoardSpace).Owner        ' Set potential winner (aka the player who placed the last stone)
        Dim ConsectutiveStoneCount = 1                                               ' Set the consecutive stone count.
        Dim XIndex = (BoardSpaces(CurrentBoardSpace).ID Mod BoardSize)                               ' Set the index X, for the practical application check.

        ' If the X index, when decreased by 4, does not exceed 0 (the board's left most border), proceed to check for a win from the left.
        If (XIndex - 4) > 0 Then
            ' From one space to the left to four spaces to the left, check each space ownership.
            For Count As Integer = (CurrentBoardSpace - 1) To (CurrentBoardSpace - 4) Step -1

                ' If the space ownership comparison between the current player and the current space succeed, increment the consecutive stone counter.
                ' Otherwise, do nothing.
                If BoardSpaces(Count).Owner = IDofPotentialWinner Then
                    ConsectutiveStoneCount += 1
                ElseIf BoardSpaces(Count).Owner <> IDofPotentialWinner Then
                    ' Do Nothing
                End If
            Next

            ' If 5 consecutive stones are marked, declare the current player the winner.
            If ConsectutiveStoneCount >= 5 Then
                WinFromLeft = True

                ' Otherwise, declare no win, and reset the consecutive stone counter.
            ElseIf ConsectutiveStoneCount < 5 Then
                WinFromLeft = False
                ConsectutiveStoneCount = 0
            End If

        End If

        Return WinFromLeft      ' Respond to the request with the result.

    End Function

    ' Game Logic Function: Check above of the placed stone for a winner.
    Function CheckUp(CurrentBoardSpace As Integer) As Boolean

        ' Win check preperations:
        Dim bolWinFromUp As Boolean = False                                     ' Set default response.
        IDofPotentialWinner = BoardSpaces(CurrentBoardSpace).Owner        ' Set potential winner (aka the player who placed the last stone)
        Dim ConsectutiveStoneCount = 1                                               ' Set the consecutive stone count.
        Dim YIndex = (BoardSpaces(CurrentBoardSpace).ID \ BoardSize)                              ' Set the index Y, for the practical application check.

        ' If the Y index, when decreased by 4, does not exceed 0 (the board's upper most border), proceed to check for a win from above.
        If (YIndex - 4) > 0 Then
            ' From one space above to four spaces above, check each space ownership.
            For intCount As Integer = (CurrentBoardSpace - BoardSize) To (CurrentBoardSpace - (4 * BoardSize)) Step -BoardSize

                ' If the space ownership comparison between the current player and the current space succeed, increment the consecutive stone counter.
                ' Otherwise, do nothing.
                If BoardSpaces(intCount).Owner = IDofPotentialWinner Then
                    ConsectutiveStoneCount += 1
                ElseIf BoardSpaces(intCount).Owner <> IDofPotentialWinner Then
                    ' Do Nothing
                End If
            Next

            ' If 5 consecutive stones are marked, declare the current player the winner.
            If ConsectutiveStoneCount >= 5 Then
                bolWinFromUp = True

                ' Otherwise, declare no win, and reset the consecutive stone counter.
            ElseIf ConsectutiveStoneCount < 5 Then
                bolWinFromUp = False
                ConsectutiveStoneCount = 0
            End If

        End If

        Return bolWinFromUp         ' Respond to the request with the result.
    End Function

    ' Game Logic Function: Check below of the placed stone for a winner.
    Function CheckDown(CurrentBoardSpace As Integer) As Boolean

        ' Win check preperations:
        Dim WinFromDown As Boolean = False                                             ' Assume win does not exists.
        IDofPotentialWinner = BoardSpaces(CurrentBoardSpace).Owner                       ' Set potential winner (aka the player who placed the last stone)
        Dim ConsectutiveStoneCount = 1                                                        ' Set the consecutive stone count.
        Dim YIndex = (BoardSpaces(CurrentBoardSpace).ID \ BoardSize)                          ' Set the index Y, for the practical application check.

        ' If the Y index, when decreased by 4, does not exceed 0 (the board's upper most border), proceed to check for a win from below.
        If (YIndex + 4) < BoardSize Then
            ' From one space below to four spaces below, check each space ownership.
            For intCount As Integer = (CurrentBoardSpace + BoardSize) To (CurrentBoardSpace + (4 * BoardSize)) Step +BoardSize

                ' If the space ownership comparison between the current player and the current space succeed, increment the consecutive stone counter.
                ' Otherwise, do nothing.
                If BoardSpaces(intCount).Owner = IDofPotentialWinner Then
                    ConsectutiveStoneCount += 1
                ElseIf BoardSpaces(intCount).Owner <> IDofPotentialWinner Then
                    ' Do Nothing
                End If
            Next

            ' If 5 consecutive stones are marked, declare the current player the winner.
            If ConsectutiveStoneCount >= 5 Then
                WinFromDown = True

                ' Otherwise, declare no win, and reset the consecutive stone counter.
            ElseIf ConsectutiveStoneCount < 5 Then
                WinFromDown = False
                ConsectutiveStoneCount = 0
            End If

        End If

        Return WinFromDown   ' Respond to the request with the result.    
    End Function

    ' Game Logic Function: Check diagonally down and to the left of the placed stone for a winner.
    Function CheckDiagDL(CurrentBoardSpace As Integer) As Boolean

        ' Win check preperations:
        Dim bolWinFromDiagDL As Boolean = False                             ' Set default response.
        IDofPotentialWinner = BoardSpaces(CurrentBoardSpace).Owner    ' Set potential winner (aka the player who placed the last stone)
        Dim ConsectutiveStoneCount = 1                                           ' Set the consecutive stone count.
        Dim XIndex = (BoardSpaces(CurrentBoardSpace).ID Mod BoardSize)                          ' Set the index X, for the practical application check.
        Dim YIndex = (BoardSpaces(CurrentBoardSpace).ID \ BoardSize)                          ' Set the index Y, for the practical application check.

        ' If the X index, when decreased by 4, does not exceed 0 (the board's leftmost border), and if the Y index, when increased by 4, does not exceed the board's width, proceed to check for a win from below.
        If ((XIndex - 4) >= 0) And ((YIndex + 4) < BoardSize) Then
            ' From one space diagonally down and to the left, to four spaces diagonally down and to the left, check each space ownership.
            For intCount As Integer = (CurrentBoardSpace + (BoardSize - 1)) To (CurrentBoardSpace + (4 * (BoardSize - 1))) Step +(BoardSize - 1)
                ' If the space ownership comparison between the current player and the current space succeed, increment the consecutive stone counter.
                ' Otherwise, do nothing.
                If BoardSpaces(intCount).Owner = IDofPotentialWinner Then
                    ConsectutiveStoneCount += 1
                ElseIf BoardSpaces(intCount).Owner <> IDofPotentialWinner Then
                    ' Do Nothing
                End If
            Next

            ' If 5 consecutive stones are marked, declare the current player the winner.
            If ConsectutiveStoneCount >= 5 Then
                bolWinFromDiagDL = True

                ' Otherwise, declare no win, and reset the consecutive stone counter.
            ElseIf ConsectutiveStoneCount < 5 Then
                bolWinFromDiagDL = False
                ConsectutiveStoneCount = 0
            End If

        End If

        Return bolWinFromDiagDL     ' Respond to the request with the result.   

    End Function

    ' Game Logic Function: Check diagonally up and to the left of the placed stone for a winner.
    Function CheckDiagUL(CurrentBoardSpace As Integer) As Boolean

        ' Win check preperations:
        Dim bolWinFromDiagUL As Boolean = False                             ' Set default response.
        IDofPotentialWinner = BoardSpaces(CurrentBoardSpace).Owner    ' Set potential winner (aka the player who placed the last stone)
        Dim ConsectutiveStoneCount = 1                                           ' Set the consecutive stone count.
        Dim XIndex = (BoardSpaces(CurrentBoardSpace).ID Mod BoardSize)                          ' Set the index X, for the practical application check.
        Dim YIndex = (BoardSpaces(CurrentBoardSpace).ID \ BoardSize)                         ' Set the index Y, for the practical application check.

        ' If the X index, when decreased by 4, does not exceed 0 (the board's leftmost border), and if the Y index, when decreased by 4, does not exceed 0 (the board's topmost border), proceed to check for a win from below.
        If ((XIndex - 4) >= 0 And (YIndex - 4) >= 0) Then
            ' From one space diagonally up and to the left, to four spaces diagonally up and to the left, check each space ownership.
            For intCount As Integer = (CurrentBoardSpace - (BoardSize + 1)) To (CurrentBoardSpace - (4 * (BoardSize + 1))) Step -(BoardSize + 1)
                ' If the space ownership comparison between the current player and the current space succeed, increment the consecutive stone counter.
                ' Otherwise, do nothing.
                If BoardSpaces(intCount).Owner = IDofPotentialWinner Then
                    ConsectutiveStoneCount += 1
                ElseIf BoardSpaces(intCount).Owner <> IDofPotentialWinner Then
                    ' Do Nothing
                End If
            Next

            ' If 5 consecutive stones are marked, declare the current player the winner.
            If ConsectutiveStoneCount >= 5 Then
                bolWinFromDiagUL = True

                ' Otherwise, declare no win, and reset the consecutive stone counter.
            ElseIf ConsectutiveStoneCount < 5 Then
                bolWinFromDiagUL = False
                ConsectutiveStoneCount = 0
            End If

        End If

        Return bolWinFromDiagUL     ' Respond to the request with the result. 

    End Function

    ' Game Logic Function: Check diagonally down and to the right of the placed stone for a winner.
    Function CheckDiagDR(CurrentBoardSpace As Integer) As Boolean

        ' Win check preperations:
        Dim bolWinFromDiagDR As Boolean = False                             ' Set default response.
        IDofPotentialWinner = BoardSpaces(CurrentBoardSpace).Owner    ' Set potential winner (aka the player who placed the last stone)
        Dim ConsectutiveStoneCount = 1                                           ' Set the consecutive stone count.
        Dim XIndex = (BoardSpaces(CurrentBoardSpace).ID Mod BoardSize)                          ' Set the index X, for the practical application check.
        Dim YIndex = (BoardSpaces(CurrentBoardSpace).ID \ BoardSize)                          ' Set the index Y, for the practical application check.

        ' If the X index, when increasd by 4, does not exceed the board's width, and if the Y index, when increased by 4, does not exceed the board's height, proceed to check for a win from below.
        If ((XIndex + 4) < BoardSize And (YIndex + 4) < BoardSize) Then
            ' From one space diagonally down and to the right, to four spaces diagonally down and to the right, check each space ownership.
            For intCount As Integer = (CurrentBoardSpace + (BoardSize + 1)) To (CurrentBoardSpace + (4 * (BoardSize + 1))) Step +(BoardSize + 1)
                ' If the space ownership comparison between the current player and the current space succeed, increment the consecutive stone counter.
                ' Otherwise, do nothing.
                If BoardSpaces(intCount).Owner = IDofPotentialWinner Then
                    ConsectutiveStoneCount += 1
                ElseIf BoardSpaces(intCount).Owner <> IDofPotentialWinner Then
                    ' Do Nothing
                End If
            Next

            ' If 5 consecutive stones are marked, declare the current player the winner.
            If ConsectutiveStoneCount >= 5 Then
                bolWinFromDiagDR = True

                ' Otherwise, declare no win, and reset the consecutive stone counter.
            ElseIf ConsectutiveStoneCount < 5 Then
                bolWinFromDiagDR = False
                ConsectutiveStoneCount = 0
            End If

        End If

        Return bolWinFromDiagDR         ' Respond to the request with the result. 

    End Function

    ' Game Logic Function: Check diagonally up and to the right of the placed stone for a winner.
    Function CheckDiagUR(CurrentBoardSpace As Integer) As Boolean

        ' Win check preperations:
        Dim bolWinFromDiagUR As Boolean = False                             ' Set default response.
        IDofPotentialWinner = BoardSpaces(CurrentBoardSpace).Owner    ' Set potential winner (aka the player who placed the last stone)
        Dim ConsectutiveStoneCount = 1                                           ' Set the consecutive stone count.
        Dim XIndex = (BoardSpaces(CurrentBoardSpace).ID Mod BoardSize)                          ' Set the index X, for the practical application check.
        Dim YIndex = (BoardSpaces(CurrentBoardSpace).ID \ BoardSize)                          ' Set the index Y, for the practical application check.

        ' If the X index, when increasd by 4, does not exceed the board's width, and if the Y index, when decreased by 4, does not exceed the 0 (aka the board's uppermost border, proceed to check for a win from below.
        If ((XIndex + 4) < BoardSize And (YIndex - 4) >= 0) Then
            ' From one space diagonally up and to the right, to four spaces diagonally up and to the right, check each space ownership.
            For intCount As Integer = (CurrentBoardSpace - (BoardSize - 1)) To (CurrentBoardSpace - (4 * (BoardSize - 1))) Step -(BoardSize - 1)
                ' If the space ownership comparison between the current player and the current space succeed, increment the consecutive stone counter.
                ' Otherwise, do nothing.
                If BoardSpaces(intCount).Owner = IDofPotentialWinner Then
                    ConsectutiveStoneCount += 1
                ElseIf BoardSpaces(intCount).Owner <> IDofPotentialWinner Then
                    ' Do Nothing
                End If
            Next

            ' If 5 consecutive stones are marked, declare the current player the winner.
            If ConsectutiveStoneCount >= 5 Then
                bolWinFromDiagUR = True

                ' Otherwise, declare no win, and reset the consecutive stone counter.
            ElseIf ConsectutiveStoneCount < 5 Then
                bolWinFromDiagUR = False
                ConsectutiveStoneCount = 0
            End If

        End If

        Return bolWinFromDiagUR     ' Respond to the request with the result. 

    End Function
End Class
