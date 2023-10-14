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
        interpretFENData();
    }

    private void interpretFENData()
    {
        if (string.IsNullOrEmpty(fenInput))
        {
            // TODO: We should just default to the starting board position if no FEN is defined.
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
            Sprite currentSprite = null;
            switch (processedQuad)
            {
                case ('k'):
                    currentSprite = isWhite ? whiteKing : blackKing;
                    currentPieceDatagram = ChessPieceData.king;
                    break;
                case ('n'):
                    currentSprite = isWhite ? whiteKnight : blackKnight;
                    currentPieceDatagram = ChessPieceData.knight;
                    break;
                case ('b'):
                    currentSprite = isWhite ? whiteBishop : blackBishop;
                    currentPieceDatagram = ChessPieceData.bishop;
                    break;
                case ('r'):
                    currentSprite = isWhite ? whiteRook : blackRook;
                    currentPieceDatagram = ChessPieceData.rook;
                    break;
                case ('p'):
                    currentSprite = isWhite ? whitePawn : blackPawn;
                    currentPieceDatagram = ChessPieceData.pawn;
                    break;
                case ('q'):
                    currentSprite = isWhite ? whiteQueen : blackQueen;
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
            if (currentSprite)
            {
                PieceColor pieceColor = PieceColor.black;
                if(isWhite)
                {
                    pieceColor = PieceColor.white;
                }
                currentQuad = instantiateNewPiece(currentQuad, currentRank, currentPieceDatagram, pieceColor, currentSprite);
            }
        }
    }

    private int instantiateNewPiece(int currentQuad, int currentRank, ChessPieceData currentPieceDatagram, PieceColor pieceColor, Sprite currentPiece)
    {
        GameObject newPiece = new GameObject(); // TODO: Using the new system, we can now instantiate a new GamePiece()

        // newPiece.name = ChessData.getPieceName((byte)currentPieceDatagram);

        SpriteRenderer newSpriteRenderer = newPiece.AddComponent<SpriteRenderer>();
        
        newSpriteRenderer.sprite = currentPiece;
        Vector2 newScale = newSpriteRenderer.transform.localScale * scale;
        newSpriteRenderer.transform.localScale = newScale;
        newPiece.transform.position = new Vector2(firstQuad.transform.position.x + (currentQuad % 8), firstQuad.transform.position.y + currentRank);
        // ChessData.initializePieceData(currentQuad, currentPieceDatagram, pieceColor);
        currentQuad++;

        newPiece.AddComponent<BoxCollider>();
        newPiece.AddComponent<DragAndDrop>();
        DragAndDrop movementScript = newPiece.GetComponent<DragAndDrop>();
        movementScript.chessBoard = chessBoardData;
        return currentQuad;
    }

    private int instantiateNewPieceTemp(int currentQuad, int currentRank, ChessPieceData currentPieceDataGram, PieceColor pieceColor, Sprite currentPiece) {
        GamePiece newPiece = pieceFactory(currentPieceDataGram);

        // Add sprite...
        newPiece.controlInterface.chessBoard = chessBoardData;
        newPiece.spriteRenderer.sprite = currentPiece;
        // Update position...
        newPiece.scale = scale;
        newPiece.position = Vector2(currentQuad, currentRank);

        return ++currentQuad;
    }

    private GamePiece pieceFactory(ChessPieceData currentPieceDataGram) {
        GamePiece newPiece;
        switch(currentPieceDataGram){
            case(ChessPieceData.pawn):
                newPiece = new PawnPiece();
                break;
            case(ChessPieceData.rook): 
                newPiece = new RookPiece();
                break;
            case(ChessPieceData.knight):
                newPiece = new KnightPiece(); 
                break;
            case(ChessPieceData.bishop):
                newPiece = new BishopPiece();
                break;
            case(ChessPieceData.king):
                newPiece = new KingPiece();
                break;
            case(ChessPieceData.queen):
                newPiece = new QueenPiece();
                break;
            default: 
                Console.log("ERROR: pieceFactory is creating an unsupported piece!");
                break;
        }
        return newPiece;
    }
}
