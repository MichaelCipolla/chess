using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessClasses {
    public class DragAndDrop : MonoBehaviour
    {
        public ChessBoard chessBoard;
        private bool isGrabbed = false;
        private Vector2 positionCache;
        private int indexCache;
        private const int clickHeight = -1;

        private byte currentPiece = 0b0000;

        private void Start()
        {
            // chessBoard = GameObject.Find("GameBoard");
        }

        private void OnMouseDown()
        {
            ChessTile currentTile = getCurrentTile();
            if(currentTile == null) {
                Debug.Log("WARNING: START TILE NOT RECOGNIZED!!");
                return;
            }
            int index = currentTile.getIndex();
            currentPiece = ChessData.getPieceData(index);
            Debug.Log("First Index: " + index.ToString());
            ChessData.setPieceData(index, 0b00000);
            // Before the object moves, let's cache the original position.
            this.positionCache = transform.position;
            this.indexCache = index;
            this.isGrabbed = true;
        }

        private void Update()
        {
            if (this.isGrabbed)
            {
                // Get the position of the pointer in screen coordinates
                Vector3 pointerPos = Input.mousePosition;

                // Convert the screen coordinates to world coordinates
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(pointerPos);

                // Set the position of this object to the position of the pointer
                transform.position = new Vector2(worldPos.x, worldPos.y);
            }
        }

        private void OnMouseUp()
        {
            byte pieceCache = currentPiece;
            currentPiece = 0b0000;

            this.isGrabbed = false;
            ChessTile currentTile = getCurrentTile();
            if(currentTile == null) {
                transform.position = this.positionCache;
                return;
            }

            // Snap position:
            transform.position = new Vector3(currentTile.getGameObject().transform.position.x, currentTile.getGameObject().transform.position.y, clickHeight);
            int index = currentTile.getIndex();
            ChessData.setPieceData(index, pieceCache);
            Debug.Log("Second index" + index.ToString());
            string pieceName = ChessData.getPieceName(pieceCache);
            byte lastPositionData = ChessData.getPieceData(this.indexCache);
            string lastPieceName = ChessData.getPieceName(lastPositionData);

            Debug.Log("Data -> chessData[" + index.ToString() + "]: " + pieceName);
            Debug.Log("Data -> chessData[" + this.indexCache.ToStrding() + "]: " + lastPieceName);
            this.indexCache = -1;
        }
        
        private ChessTile? getCurrentTile() {
            for(int i = 0; i < this.chessBoard.tileArray.Length; i++)
            {
                // Grab the chessQuad
                ChessTile chessQuad = this.chessBoard.tileArray[i];

                // Check for collision
                Collider2D collider = chessQuad.getGameObject().GetComponent<Collider2D>();

                // Check if "this" is colliding with the given quad
                bool isColliding = collider.OverlapPoint(transform.position);
                if(isColliding)
                {
                    return chessQuad;
                }
            }
            return null;
        }
    }
}

