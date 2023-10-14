using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceColor
{
    white,
    black,
}

public interface IPieceBehavior
{
	// TODO: These elements belong in the gamePiece class. Not the behavior interface.
    protected PieceColor pieceColor;

    public PieceBehavior(PieceColor color)
    {
        this.pieceColor = color;
    }

    /// <summary>
    /// The validateMove method checks to see if the given move is valid or not.
    /// </summary>
    /// <returns>bool indicating the validity of the move.</returns>
    public virtual bool validateMove(int startIndex, int endIndex);
}
