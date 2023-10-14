public interface IPieceBehavior {
    /// <summary>
    /// The validateMove method checks to see if the given move is valid or not.
    /// </summary>
    /// <returns>bool indicating the validity of the move.</returns>
    public abstract bool validateMove(int startIndex, int endIndex);
}