using Unity.VisualScripting;
using UnityEngine;

namespace ChessClasses {
    public enum PieceColor {
        WHITE,
        BLACK,
    }

    public class GamePiece : IPieceBehavior {
        // TODO: These elements belong in the gamePiece class. Not the behavior interface.
        public PieceColor pieceColor {
            get;
            protected set;
        }

        public GameObject gameObject;

        public BoxCollider boxCollider;

        // Gamepiece should inherit from GameObject
        // Transform and such

        // It should also implement some kind of validate move interface.

        // It needs to have a control attribute (we will use the DragAndDrop behavior at first):
        public DragAndDrop controlInterface;

        public GameObject referenceQuad;

        // It should have a sprite renderer for its sprite
        public SpriteRenderer spriteRenderer;

        private Vector2 _scale;

        private float _scaleFactor;
        public float scale {
            get => _scaleFactor;
            set {
                _scaleFactor = value;
                _scale = value * this.spriteRenderer.transform.localScale;
                this.spriteRenderer.transform.localScale = _scale;
                this.boxCollider.size *= 1 / _scaleFactor;
            }
        }

        private Vector2 _position;
        public Vector2 position {
            get => _position;
            set {
                float currentQuad = value.x;
                float currentRank = value.y;
                _position = new Vector2(referenceQuad.transform.position.x + (currentQuad % 8), referenceQuad.transform.position.y + currentRank);
                this.gameObject.transform.position = _position;
            }
        }

        public virtual bool validateMove(int startIndex, int endIndex) {
            Debug.Log("WARNING: Validate Move has not been implemented!");
            return false;
        }
        public bool capturePiece(int endIndex) {
            ChessData.setPieceData(endIndex, (byte)ChessPieceData.blank);
            // TODO: We need to get the reference to the piece at this point and remove it from the game.

            return true;
        }


        public GamePiece(PieceColor color) {
            this.pieceColor = color;
            this.gameObject = new GameObject();
            spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
            controlInterface = this.gameObject.AddComponent<DragAndDrop>();
            boxCollider = this.gameObject.AddComponent<BoxCollider>();
        }
    }
}

