using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTile {
    // This is going to be a chessTile class that will work as a wrapper for the chess tile game ojbect
    GameObject gameObject { get; set; }
    int tileIndex { get; set; }

    public ChessTile(GameObject tile, int index) {
        this.gameObject = tile;
        this.tileIndex = index;
    }

    public int getIndex() {
        return this.tileIndex;
    }

    public GameObject getGameObject() {
        return this.gameObject;
    }
}
