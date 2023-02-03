Module PolarPerilStuff
    Public Quit As Boolean
    Structure SpriteType
        Dim Speed As Point
        Dim Floattime As Integer
        Dim picnum As Integer
        Dim Floating As Boolean
        Dim OnLadder As Boolean
        Dim FloorNumber As Integer
        Dim OnFloor As Boolean
    End Structure
    Structure nansenSprite
        Dim LeftSprites() As Image
        Dim RightSprites() As Image
        Dim ClimbSprites() As Image
        Dim LeftJump As Image
        Dim RightJump As Image
        Dim FacingRight As Boolean
    End Structure
    Structure floortype
        Dim Slope As Single
        Dim LeftEdge As Integer
        Dim RightEdge As Integer
        Dim X As Single
        Dim Y As Single
    End Structure
End Module
