using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard
{
    public ChessTile[] tileArray;

    public ChessBoard(GameObject boardArt) {
        Transform parentTransform = boardArt.transform;
        tileArray = new ChessTile[parentTransform.childCount];
        for (int i = 0; i < parentTransform.childCount; i++) {
            tileArray[i] = new ChessTile(parentTransform.GetChild(i).gameObject, i);
        }
    }
}
