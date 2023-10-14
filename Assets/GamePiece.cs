using System;
using UnityEngine;
using ChessClasses;

namespace ChessClasses {
    public class GamePiece : GameObject, IPieceBehavior
    {
        // Gamepiece should inherit from GameObject
        // Transform and such

        // It should also implement some kind of validate move interface.

        // It needs to have a control attribute (we will use the DragAndDrop behavior at first):
        public MonoBehaviour controlInterface;

        public GameObject referenceQuad;

        // It should have a sprite renderer for its sprite
        public SpriteRenderer spriteRenderer;

        private Vector2 _scale;
        public Vector2 scale {
            get => _scale;
            set {
                _scale = value * spriteRenderer.transform.localScale;
            }
        }

        private Vector2 _position;
        public Vector2 position {
            get => _position;
            set {
                int currentQuad = value.x;
                int currentRank = value.y;
                _position = new Vector2(referenceQuad.transform.position.x + (currentQuad % 8), referenceQuad.transform.position.y + currentRank);
            }
        }
        public GameObject gameObjectRef; // TODO: Should we extend from gameObject or should we contain a gameObejct reference??

        public BoxCollider boxCollider;

        public bool validateMove(int startIndex, int endIndex) {
            Debug.Log("WARNING: Validate Move has not been implemented!");
            return false;
        }
        GamePiece() {
            spriteRenderer = this.AddComponent<SpriteRenderer>();
            boxCollider = this.AddComponent<BoxCollider>();
            controlInterface = this.AddComponent<DragAndDrop>();
        }
    }
}

