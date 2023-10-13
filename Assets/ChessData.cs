using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChessPieceData
{
    blank = 0,
    pawn = 1 << 1,
    rook = 1 << 2,
    knight = 1 << 3,
    bishop = 1 << 4,
    queen = 1 << 5,
    king = 1 << 6,
    white = 1 << 7,
    firstMove = 1 << 8,
}

public static class ChessData
{   
    private const int RANK = 8;
    private const int FILE = 8;

    private static byte[] chessBoardDataMap = new byte[64];

    public static void generateBoardStruct()
    {
        // Generate an empty board.
        for (int i = 0; i < RANK; i++)
        {
            for(int j = 0; j < FILE; j++)
            {
                setPieceData(i + j, (byte)ChessPieceData.blank);
            }
        }
    }

    public static void initializePieceData(int index, ChessPieceData pieceType, PieceColor pieceColor = PieceColor.black)
    {

        byte pieceData = (byte)pieceType;
        if(pieceColor == PieceColor.white)
        {
            pieceData |= (byte)ChessPieceData.white;
        }
        
        pieceData |= unchecked((byte)ChessPieceData.firstMove);
        chessBoardDataMap[index] = pieceData;
    }

    public static void setPieceData(int index, byte pieceType) 
    {
        chessBoardDataMap[index] = pieceType;
    }
    public static byte getPieceData(int index)
    {
        return chessBoardDataMap[index];
    }

    public static string getPieceName(byte piece)
    {
        if((piece & (byte)ChessPieceData.pawn) != 0)
        {
            return "Pawn";
        }
        else if ((piece & (byte)ChessPieceData.rook) != 0)
        {
            return "Rook";
        }
        else if((piece & (byte)ChessPieceData.knight) != 0)
        {
            return "Knight";
        }
        else if ((piece & (byte)ChessPieceData.bishop) != 0)
        {
            return "Bishop";
        }
        else if ((piece & (byte)ChessPieceData.king) != 0)
        {
            return "King";
        }
        else if ((piece & (byte)ChessPieceData.queen) != 0)
        {
            return "Queen";
        }
        else
        {
            return "Unknown Piece";
        }
    }
}

