using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessClasses {
    public class DragAndDrop : MonoBehaviour
    {
        public GameObject chessBoard;
        private bool isGrabbed = false;
        private Vector2 positionCache;
        private const int clickHeight = 25;

        private void Start()
        {
            //chessBoard = GameObject.Find("GameBoard");
        }

        private void OnMouseDown()
        {
            // Before the object moves, let's cache the original position.
            positionCache = transform.position;
            isGrabbed = true;
        }

        private void Update()
        {
            if (isGrabbed)
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
            isGrabbed = false;
            // Then we want to snap to a square.
            for(int i = 0; i < chessBoard.transform.childCount; i++)
            {
                // Grab the chessQuad
                GameObject chessQuad = chessBoard.transform.GetChild(i).gameObject;

                // Check for collision
                Collider2D collider = chessQuad.GetComponent<Collider2D>();

                // Check if "this" is colliding with the given quad
                bool isColliding = collider.OverlapPoint(transform.position);
                if(isColliding)
                {
                    // Snap the position of this to the position of the quad.
                    transform.position = new Vector3(chessQuad.transform.position.x, chessQuad.transform.position.y, clickHeight);
                    return;
                }
            }
            Debug.Log("LOG: No collision was detected!");
            transform.position = positionCache;
        }
    }
}

