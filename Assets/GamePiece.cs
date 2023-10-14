using Unity.VisualScripting;
using UnityEngine;

namespace ChessClasses {
    public enum PieceColor {
        white,
        black,
    }

    public class GamePiece : MonoBehaviour, IPieceBehavior {

        // TODO: These elements belong in the gamePiece class. Not the behavior interface.
        protected PieceColor pieceColor;

        // Gamepiece should inherit from GameObject
        // Transform and such

        // It should also implement some kind of validate move interface.

        // It needs to have a control attribute (we will use the DragAndDrop behavior at first):
        public DragAndDrop controlInterface;

        public GameObject referenceQuad;

        // It should have a sprite renderer for its sprite
        public SpriteRenderer spriteRenderer;

        private Vector3 _scale;

        private float _scaleFactor;
        public float scale {
            get => _scaleFactor;
            set {
                _scaleFactor = value;
                _scale = value * spriteRenderer.transform.localScale;
            }
        }

        private Vector2 _position;
        public Vector2 position {
            get => _position;
            set {
                float currentQuad = value.x;
                float currentRank = value.y;
                _position = new Vector2(referenceQuad.transform.position.x + (currentQuad % 8), referenceQuad.transform.position.y + currentRank);
            }
        }
        public GameObject gameObjectRef; // TODO: Should we extend from gameObject or should we contain a gameObejct reference??

        public BoxCollider boxCollider;

        public virtual bool validateMove(int startIndex, int endIndex) {
            Debug.Log("WARNING: Validate Move has not been implemented!");
            return false;
        }
        public GamePiece(PieceColor color) {
            this.pieceColor = color;

            spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
            boxCollider = this.gameObject.AddComponent<BoxCollider>();
            controlInterface = this.gameObject.AddComponent<DragAndDrop>();
        }
    }
}

