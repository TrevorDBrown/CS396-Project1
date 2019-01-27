' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' BoardSpace.vb - Allows the application to develop a reference for individual board spaces.

Public Class BoardSpace

    ' Board Space properties
    Protected BoardSpaceName As String         ' String: the Name of the Board Space (i.e. its index value in the BoardSpace array.
    Protected BoardSpaceOccupied As Boolean     ' Boolean: determines whether or not a Board Space is available for stone placement (True = Yes, False = No)
    Protected BoardSpaceOwner As Integer        ' Integer: the numeric representation of the player who owns the board space.

    ' Board Space constructor
    Sub New(ByVal SpaceName As String)
        BoardSpaceName = SpaceName                ' Initialize the Board Space name with its equivalent constructor parameter.
        BoardSpaceOccupied = False                  ' Initialize the Board Space occupation state with its equivalent constructor parameter.
        BoardSpaceOwner = 0                   ' Initialize the Board Space ownership with 0, since it has no stone.
    End Sub

    ' The following code is used to establish getters and setters for properties of a board space instance.

    ' Property of a Board Space instance: Space Name
    Public ReadOnly Property Name() As String
        Get
            Return BoardSpaceName    ' Returns a casted string response to the request.
        End Get
    End Property

    Public ReadOnly Property ID() As Integer
        Get
            Return Integer.Parse(Name)
        End Get
    End Property

    ' Property of a Board Space instance: Board Space Ownership Status
    Public Property SpaceOccupation() As Boolean
        Set(newStatus As Boolean)
            BoardSpaceOccupied = newStatus               ' Sets the new status of the board space (most likely occupied.)
        End Set

        Get
            Return BoardSpaceOccupied
        End Get
    End Property

    ' Property of a Board Space instance: Space Ownership
    Public Property Owner() As Integer
        Set(PlayerID As Integer)
            BoardSpaceOwner = PlayerID            ' Set the board space ownership to the player who clicked the equivalent board space button successfully.
        End Set

        Get
            Return BoardSpaceOwner
        End Get
    End Property

End Class
