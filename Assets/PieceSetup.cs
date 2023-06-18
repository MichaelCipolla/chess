class PawnBehavior : PieceBehavior 
{
    public override bool validateMove(int startIndex, int endIndex) 
    {
        /* Here we will check if the requested move is valid.
           Pawn moves: index + 8 (black)
                       index + 9 (black)
                       index + 7 (black)

                       index - 8 (white)
                       index - 9 (white)
                       index - 7 (white)

            First move: +- 8 or +- 16

        */
        if (endIndex >= startIndex + 7 && endIndex <= startIndex + 9)
        { 
            return true;
        } else {
            return false;
        }
    }
}

class KnightBehavior : PieceBehavior 
{
    public override bool validateMove(int startIndex, int endIndex) 
    {
        // Here we will check if the requested move is valid.
        return false;
    }
}

class BishopBehavior : PieceBehavior
{
    public override bool validateMove(int startIndex, int endIndex) 
    {
        // Here we will check if the requested move is valid.
        return false;
    }
}

class RookBehavior : PieceBehavior 
{
    public override bool validateMove(int startIndex, int endIndex) 
    {
        // Here we will check if the requested move is valid.
        return false;
    }
}

class QueenBehavior : PieceBehavior
{
    public override bool validateMove(int startIndex, int endIndex) 
    {
        // Here we will check if the requested move is valid.
        return false;
    }
}

class KingBehavior : PieceBehavior 
{
    public override bool validateMove(int startIndex, int endIndex) 
    {
        // Here we will check if the requested move is valid.
        return false;
    }
}
