using System;
using UnityEngine;
using ChessClasses;

public class GeneratePositions : MonoBehaviour
{
    //public ChessPositions chessData;

    public GameObject chessBoard;
    
    // Bottom left quad for position reference
    public GameObject firstQuad;

    // Fen Input:
    public string fenInput;

    // Scale attribute
    public float scale;


    // Chess piece prefabs:
    public Sprite whiteKnight;
    public Sprite whiteKing;
    public Sprite whitePawn;
    public Sprite whiteQueen;
    public Sprite whiteRook;
    public Sprite whiteBishop;
    
    public Sprite blackKnight;
    public Sprite blackKing;
    public Sprite blackPawn;
    public Sprite blackQueen;
    public Sprite blackRook;
    public Sprite blackBishop;

    public ChessBoard chessBoardData;

    private void Start()
    {
        this.chessBoardData = new ChessBoard(chessBoard);
        //chessData = new ChessPositions();
        PlacePieces();
    }

    private void PlacePieces()
    {
        if (string.IsNullOrEmpty(fenInput))
        {
            return;
        }
        // Quad = 0 is the lower left square (a1)
        int currentQuad = 0;
        int currentRank = 0;
        ChessPieceData currentPieceDatagram = ChessPieceData.white;

        foreach (char quad in fenInput)
        {
            bool isWhite = char.IsUpper(quad);
            char processedQuad = char.ToLower(quad);
            Sprite currentPiece = null;
            switch (processedQuad)
            {
                case ('k'):
                    currentPiece = isWhite ? whiteKing : blackKing;
                    currentPieceDatagram = ChessPieceData.king;
                    break;
                case ('n'):
                    currentPiece = isWhite ? whiteKnight : blackKnight;
                    currentPieceDatagram = ChessPieceData.knight;
                    break;
                case ('b'):
                    currentPiece = isWhite ? whiteBishop : blackBishop;
                    currentPieceDatagram = ChessPieceData.bishop;
                    break;
                case ('r'):
                    currentPiece = isWhite ? whiteRook : blackRook;
                    currentPieceDatagram = ChessPieceData.rook;
                    break;
                case ('p'):
                    currentPiece = isWhite ? whitePawn : blackPawn;
                    currentPieceDatagram = ChessPieceData.pawn;
                    break;
                case ('q'):
                    currentPiece = isWhite ? whiteQueen : blackQueen;
                    currentPieceDatagram = ChessPieceData.queen;
                    break;
                case ('/'):
                    // Continue loop without iterating quad, and also increment the rank
                    currentRank++;
                    break;
                default:
                    // number will skip
                    currentQuad += int.Parse(processedQuad.ToString());
                    break;
            }
            if (currentPiece)
            {
                currentQuad=instantiateNewPiece(currentQuad, currentRank, currentPieceDatagram, isWhite, currentPiece);
            }
        }
    }

    private int instantiateNewPiece(int currentQuad, int currentRank, ChessPieceData currentPieceDatagram, bool isWhite, Sprite currentPiece)
    {
        GameObject newPiece = new GameObject();
        newPiece.name = ChessData.getPieceName((byte)currentPieceDatagram);
        SpriteRenderer newSpriteRenderer = newPiece.AddComponent<SpriteRenderer>();
        newSpriteRenderer.sprite = currentPiece;
        Vector2 newScale = newSpriteRenderer.transform.localScale * scale;
        newSpriteRenderer.transform.localScale = newScale;
        newPiece.transform.position = new Vector2(firstQuad.transform.position.x + (currentQuad % 8), firstQuad.transform.position.y + currentRank);
        ChessData.initializePieceData(currentQuad, currentPieceDatagram, isWhite);
        currentQuad++;

        newPiece.AddComponent<BoxCollider>();
        newPiece.AddComponent<DragAndDrop>();
        DragAndDrop movementScript = newPiece.GetComponent<DragAndDrop>();
        movementScript.chessBoard = chessBoardData;
        return currentQuad;
    }
}
