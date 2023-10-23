using MyBox;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace ChessClasses {
    class PawnPiece : GamePiece {
        private bool firstMove = true;

        private int[] validMoveSet = null;

        public PawnPiece(PieceColor color) : base(color) {
            // TODO: I'm not super happy with how the mapping of valid moves turned out...
            if (color == PieceColor.BLACK) {
                this.validMoveSet = new int[] { 7, 8, 9 };
            }
            else {
                this.validMoveSet = new int[] { -7, -8, -9 };
            }
        }

        public override bool capturePiece(int startIndex, int endIndex) {
            byte pieceData = ChessData.getPieceData(endIndex);

            if ((endIndex == startIndex + this.validMoveSet[0] || endIndex == startIndex + this.validMoveSet[2]) && pieceData != (byte)ChessPieceData.blank) {
                GamePiece pieceToDestroy = ChessData.getGamePiece(endIndex);
                if (this.pieceColor != pieceToDestroy.pieceColor) {
                    pieceToDestroy.gameObject.SetActive(false);
                    ChessData.setGamePiece(endIndex, null);
                    UnityEngine.Object.Destroy(pieceToDestroy.gameObject);
                    firstMove = false;
                    return true;
                }
            }
            return false;
        }
        public override bool validateMove(int startIndex, int endIndex) {
            /* Here we will check if the requested move is valid.
            Pawn moves: index + 8 (black)
                        index + 9 (black)
                        index + 7 (black)

                        index - 8 (white)
                        index - 9 (white)
                        index - 7 (white)

                First move: +- 8 or +- 16

            */

            byte pieceData = ChessData.getPieceData(endIndex);
            if(pieceData == (byte)ChessPieceData.blank) {
                if (firstMove && endIndex == startIndex + 2 * this.validMoveSet[1]) {
                    firstMove = false;
                    return true;
                }
                else if (endIndex == startIndex + this.validMoveSet[1]) {
                    firstMove = false;
                    return true;
                }
            }
            else {
                return this.capturePiece(startIndex, endIndex);
            }

            return false;
        }
    }

    class KnightPiece : GamePiece {
        private int[] validMoveSet = null;
        public KnightPiece(PieceColor color) : base(color) {
            this.validMoveSet = new[] { 6, 10, 15, 17 };
        }

        public override bool capturePiece(int startIndex, int endIndex) {
            GamePiece pieceToDestroy = ChessData.getGamePiece(endIndex);
            if (this.pieceColor != pieceToDestroy.pieceColor) {
                pieceToDestroy.gameObject.SetActive(false);
                ChessData.setGamePiece(endIndex, null);
                UnityEngine.Object.Destroy(pieceToDestroy.gameObject);
                return true;
            }
            return false;
        }
        public override bool validateMove(int startIndex, int endIndex) {
            byte pieceData = ChessData.getPieceData(endIndex);
            int amountMoved = endIndex - startIndex;
            if (this.validMoveSet.IndexOfItem(Math.Abs(amountMoved)) != -1) {
                if (pieceData != (byte)ChessPieceData.blank) {
                    return capturePiece(startIndex, endIndex);
                }
                return true;
            }
            return false;
        }
    }

    class BishopPiece : GamePiece {
        public BishopPiece(PieceColor color) : base(color) {

        }
        public override bool validateMove(int startIndex, int endIndex) {
            byte pieceData = ChessData.getPieceData(endIndex);

            if (pieceData != (byte)ChessPieceData.blank) {
                // We should execute capture logic here...
                // Based on capture logic, we can further validate the move...
                return false;
            }
            // Here we will check if the requested move is valid.
            return true;
        }
    }

    class RookPiece : GamePiece {
        public RookPiece(PieceColor color) : base(color) {

        }
        public override bool validateMove(int startIndex, int endIndex) {
            byte pieceData = ChessData.getPieceData(endIndex);

            if (pieceData != (byte)ChessPieceData.blank) {
                // We should execute capture logic here...
                // Based on capture logic, we can further validate the move...
                return false;
            }
            // Here we will check if the requested move is valid.
            return true;
        }
    }

    class QueenPiece : GamePiece {
        private int[] validMoveSet = null;

        public QueenPiece(PieceColor color) : base(color) {
            this.validMoveSet = new[] { 7, 8, 9 }; 
        }
        public override bool capturePiece(int startIndex, int endIndex) {
            GamePiece pieceToDestroy = ChessData.getGamePiece(endIndex);
            if (this.pieceColor != pieceToDestroy.pieceColor) {
                pieceToDestroy.gameObject.SetActive(false);
                ChessData.setGamePiece(endIndex, null);
                UnityEngine.Object.Destroy(pieceToDestroy.gameObject);
                return true;
            }
            return false;
        }

        public bool horizontalMove(int startIndex, int endIndex, int moveAmount, byte pieceData) {
            int index = startIndex;
            for(int i = 0; i < Math.Abs(moveAmount); i++) {
                index += startIndex > endIndex ? -1 : 1; 

                if(index == endIndex) {
                    break;
                }
                
                if(ChessData.getPieceData(index) != (byte)ChessPieceData.blank) {
                    return false;
                }
            }
            if (pieceData != (byte)ChessPieceData.blank) {
                // We should execute capture logic here...
                // Based on capture logic, we can further validate the move...
                return this.capturePiece(startIndex, endIndex);
            }
            return true;
        }

        public bool diagonalMove(int startIndex, int endIndex, int moveAmount, int move, int boundary, byte pieceData) {
            for (int i = 1; i <= boundary; i++) {
                int moveDirection = endIndex > startIndex ? 1 : -1;
                int nextIndex = startIndex + move * i * moveDirection;
                
                if (nextIndex == endIndex) {
                    break;
                }

                if (ChessData.getPieceData(nextIndex) != (byte)ChessPieceData.blank) {
                    return false;
                }
            }
            
            if (pieceData != (byte)ChessPieceData.blank) {
                // We should execute capture logic here...
                // Based on capture logic, we can further validate the move...
                return this.capturePiece(startIndex, endIndex);
            }
            return true;
        }

        public override bool validateMove(int startIndex, int endIndex) {
            byte pieceData = ChessData.getPieceData(endIndex);

            int moveAmount = endIndex - startIndex;
            int filePosition = startIndex % 8;
            int minFile = filePosition;
            int maxFile = 7 - filePosition;

            int minRank = (int)Math.Floor(startIndex / 8.0f);
            int maxRank = 7 - minRank;

            // Could check if endIndex is < startIndex - filePosition, or > 8 - filePosition
            // If true, we need to check each index between endIndex and start index, if there's
            // a piece, we want to disqualify the move.
            
            // Check if the piece is in the horizontal bounds...
            if (moveAmount >= -minFile && moveAmount <= maxFile) {
                return this.horizontalMove(startIndex, endIndex, moveAmount, pieceData);
            }

            foreach (int move in validMoveSet) {
                if (Math.Abs(moveAmount) % move == 0) {
                    // Find all multiples, negative or positive:
                    // Check startIndex + (move * i)
                    int validMove = move;
                    validMove *= moveAmount < 0 ? -1 : 1; 
                    int boundary = 0;
                    if (validMove == 7 || validMove == -9) {
                        boundary = minFile;
                    }
                    else if (validMove == 9 || validMove == -7) {
                        boundary = maxFile;
                    }
                    else { // In this condition we handle the +-8 movement
                        if (endIndex > startIndex) {
                            boundary = maxRank; // anything above 63 is invalid. Anything below 0 is invalid.
                        }
                        else {
                            boundary = minRank;
                        }
                    }
                    return this.diagonalMove(startIndex, endIndex, moveAmount, move, boundary, pieceData);
                }
            }
            return false;
        }
    }

    class KingPiece : GamePiece {
        public KingPiece(PieceColor color) : base(color) {

        }
        public override bool validateMove(int startIndex, int endIndex) {
            byte pieceData = ChessData.getPieceData(endIndex);

            if (pieceData != (byte)ChessPieceData.blank) {
                // We should execute capture logic here...
                // Based on capture logic, we can further validate the move...
                return false;
            }
            // Here we will check if the requested move is valid.
            return true;
        }
    }
}
