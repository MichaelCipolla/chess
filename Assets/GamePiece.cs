using ChessClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece
{
    private GameObject gameObject;
    private SpriteRenderer spriteRenderer;
    private Vector2 scale;
    private BoxCollider boxColliderComponent;
    private DragAndDrop dragAndDropComponent;

    private PieceBehavior behavior;

    public GamePiece(int currentQuad, int currentRank, ChessPieceData currentPieceDatagram, PieceColor pieceColor, Sprite currentPiece, GameObject firstQuad, PieceBehavior newBehavior, ChessBoard chessBoardData)
    {
        this.gameObject = new GameObject();
        this.gameObject.name = ChessData.getPieceName((byte)currentPieceDatagram);
        
        this.spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = currentPiece;
        Vector2 newScale = this.spriteRenderer.transform.localScale * scale;
        this.spriteRenderer.transform.localScale = newScale;
        
        this.gameObject.transform.position = new Vector2(firstQuad.transform.position.x + (currentQuad % 8), firstQuad.transform.position.y + currentRank);
        ChessData.initializePieceData(currentQuad, currentPieceDatagram, pieceColor);

        this.boxColliderComponent = this.gameObject.AddComponent<BoxCollider>();
        this.dragAndDropComponent = this.gameObject.AddComponent<DragAndDrop>();
        this.dragAndDropComponent.chessBoard = chessBoardData;

        // Add the behavior:
        this.behavior = newBehavior;
    }


}
