' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' Player.vb - Allows the application to create players.

Imports Gomoku.frmBoard         ' Imports the Board form, so it can make calls to it.

Public Class Player

    ' Declare variables and objects to construct and manipulate Computer instances:
    Protected PlayerName As String               ' String: to store the Player's name.
    Protected Human As Boolean
    Protected StoneColor As Color          ' Color: to store the Player's preferred stone color.
    Protected WinCount As Integer              ' Integer: to store the player's total wins.
    Protected LossCount As Integer            ' Integer: to store the player's total losses.
    Protected Identifier As Integer                ' Integer: to store the player's ID number.

    ' The following variables/objects are used for moves
    Protected MoveSet(1) As Move                  ' Move array: for storing all moves made in a given Gomoku game.
    Protected TotalMoves As Integer = 0        ' Integer: to store the total amount of moves made.
    Protected LastMoveInfo As String    ' String: to store the last move made by player.

    ' Player constructor
    Sub New(ByVal Name As String, ByVal IsHuman As Boolean, StoneColor As Color, ID As Integer)
        MyClass.PlayerName = Name                           ' Initialize Player name using the equivalent constructor parameter.
        MyClass.Human = IsHuman
        MyClass.StoneColor = StoneColor                     ' Initialize Player's stone color, using the equivalent constructor parameter.
        MyClass.Identifier = ID                             ' Initialize the player's type (numeric representation)
    End Sub

    ' The following code is used to establish getters and setters for properties of a Player instance.

    ' Property of a Player instance: Name
    Public ReadOnly Property Name As String
        Get
            Return PlayerName     ' Returns a casted string response to the request.
        End Get
    End Property

    ' Property of a Player instance: IsHuman
    Public ReadOnly Property IsHuman As Boolean
        Get
            Return Human
        End Get
    End Property

    ' Property of a Player instance: Color
    Public ReadOnly Property Color As Color
        Get
            Return StoneColor    ' Returns a casted color response to the request.
        End Get
    End Property

    ' Property of a Player instance: ID
    Public ReadOnly Property ID As Integer
        Get
            Return Identifier        ' Returns a casted integer response to the request.
        End Get
    End Property

    ' Property of a Player instance: Last Move (X coordinate)
    Public ReadOnly Property LastMoveX As Integer
        Get
            Return MoveSet(TotalMoves).X    ' Returns a casted integer response to the request.
        End Get
    End Property

    ' Property of a Player instance: Last Move (Y coordinate)
    Public ReadOnly Property LastMoveY As Integer
        Get
            Return MoveSet(TotalMoves).Y    ' Returns a casted integer response to the request.
        End Get
    End Property

    ' The following code is used to process player functions, such as making a move.

    ' Player Function: Make a move.
    Sub MakeMove(ByVal intX As Integer, intY As Integer)

        ' Move actions:
        MoveSet(TotalMoves) = New Move(intX, intY)   ' Add the latest move to the Computer Player's move array.
        TotalMoves += 1                              ' Increment total moves by 1.
        ReDim Preserve MoveSet(TotalMoves)           ' Redeclare in memory, the move array, preserving all older entries.

        ' If the following game modes are on, update the correct player move list.
        ' FrmPlayerInfo.UpdateMoveList(Me, MoveSet, TotalMoves)

    End Sub

    ' ColorToString - Function that converts the color to an appropriate string representation
    ' Instead of "Color[ColorName]", we send "ColorName"
    Function ColorToString(ByVal color As Color)

        Dim ColorAsString = color.ToString

        ColorAsString = ColorAsString.Remove(0, 7)
        ColorAsString = ColorAsString.TrimEnd("]")

        Return ColorAsString

    End Function

End Class
