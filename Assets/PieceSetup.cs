namespace ChessClasses {
    class PawnPiece : GamePiece {
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

            if(pieceData != (byte)ChessPieceData.blank) {
                // TODO: We should execute capture logic here...
                // Based on capture logic, we can further validate the move...
                return false;
            }

            if (endIndex >= startIndex + 7 && endIndex <= startIndex + 9) {
                return true;
            }
            else {
                return false;
            }
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
