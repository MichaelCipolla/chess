public interface IPieceBehavior {
    /// <summary>
    /// The validateMove method checks to see if the given move is valid or not.
    /// </summary>
    /// <returns>bool indicating the validity of the move.</returns>
    public abstract bool validateMove(int startIndex, int endIndex);

    /// <summary>
    /// The capturePiece method checks to see if the input index contains a piece. If it does, it "captures" the piece,
    /// removing that piece from the game board.
    /// </summary>
    /// <returns>bool indicating the validity of the move.</returns>
    public abstract bool capturePiece(int endIndex);

}