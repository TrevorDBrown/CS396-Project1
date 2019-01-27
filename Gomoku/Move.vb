' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' Move.vb - A reference for Players and Computer Players to use to figure out stone placement.

Public Class Move

    ' Declare variables to construct a Move instance.
    Protected XPosition As Integer     ' Integer: Space X coordinate.
    Protected YPosition As Integer     ' Integer: Space Y coordinate.

    ' Move constructor.
    Public Sub New(ByVal X As Integer, Y As Integer)
        XPosition = X    ' Initialize X to equal its equivalent constructor parameter.
        YPosition = Y    ' Initialize Y to equal its equivalent constructor parameter.

    End Sub

    ' The following code is used to establish getters and setters for properties of a move instance.

    ' Property of a Move instance: X coordinate.
    Public ReadOnly Property X As Integer
        Get
            Return CType(XPosition, Integer)     ' Returns a casted integer of the X coordinate of an occupied space.
        End Get
    End Property

    ' Property of a Move instance: Y coordinate.
    Public ReadOnly Property Y As Integer
        Get
            Return CType(YPosition, Integer)     ' Returns a casted integer of the X coordinate of an occupied space.
        End Get
    End Property

End Class
