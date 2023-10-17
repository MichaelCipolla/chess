namespace ChessClasses {
    class PawnPiece : GamePiece {
        private bool firstMove = true;

        public PawnPiece(PieceColor color) : base(color) {
            
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

            // Collision check: 
            byte pieceData = ChessData.getPieceData(endIndex);
            if(firstMove && endIndex == startIndex + 16 && pieceData == (byte)ChessPieceData.blank) {
                firstMove = false;
                return true;
            }

            if (endIndex == startIndex + 8 && pieceData == (byte)ChessPieceData.blank) {
                firstMove = false;
                return true;
            }

            if ((endIndex == startIndex + 7 || endIndex == startIndex + 9) && pieceData != (byte)ChessPieceData.blank) {
                // TODO: We should execute capture logic here...
                // Based on capture logic, we can further validate the move...
                // We could further reduce the amount of if statements here through refactoring this capture logic into a method.
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
    }

    class KnightPiece : GamePiece {
        public KnightPiece(PieceColor color) : base(color) {

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
        public QueenPiece(PieceColor color) : base(color) {

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
