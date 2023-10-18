using MyBox;
using System;
using Unity.VisualScripting;

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

        public override bool validateMove(int startIndex, int endIndex) {
            byte pieceData = ChessData.getPieceData(endIndex);

            int moveAmount = endIndex - startIndex;
            int rank = startIndex % 8;
            int minRank = rank;
            int maxRank = 7 - rank;
            if (moveAmount >= -minRank && moveAmount <= maxRank) {
                return true;
            }

            foreach (int move in validMoveSet) {
                if(Math.Abs(moveAmount) % move == 0) {
                    return true;
                } 
            }

            if (pieceData != (byte)ChessPieceData.blank) {
                // We should execute capture logic here...
                // Based on capture logic, we can further validate the move...
                return false;
            }
            // Here we will check if the requested move is valid.
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
