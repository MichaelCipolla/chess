using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPieceBehavior
{
    /// <summary>
    /// The validateMove method checks to see if the given move is valid or not.
    /// </summary>
    /// <returns>bool indicating the validity of the move.</returns>
    public virtual bool validateMove(int startIndex, int endIndex);
}
