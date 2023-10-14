using UnityEngine;
using UnityEditor;

public class GenerateGameBoard : MonoBehaviour {
    private const int RANKS = 8;
    private const int FILES = 8;
    private const float spacing = 1f;

    public Material blackMat;
    public Material whiteMat;

    void Start() {
        GenerateBoard();
    }
    void GenerateBoard() {
        int count = 0;
        GameObject parent = new GameObject("Board");
        for (int i = 0; i < RANKS; i++) {
            for (int j = 0; j < FILES; j++) {
                GameObject square = GameObject.CreatePrimitive(PrimitiveType.Quad);
                square.name = "Quad_" + count;
                square.transform.position = new Vector2(j * spacing, i * spacing);
                square.transform.parent = parent.transform;

                Renderer squareRenderer = square.GetComponent<Renderer>();
                squareRenderer.material = (i + j) % 2 == 0 ? blackMat : whiteMat;

                // Remove the MeshCollider component
                MeshCollider defaultMesh = square.GetComponent<MeshCollider>();
                DestroyImmediate(defaultMesh);

                // Add a BoxCollider2D component
                square.AddComponent<BoxCollider2D>();

                count++;
            }
        }
        PrefabUtility.SaveAsPrefabAsset(parent, "Assets/Prefabs/GameBoard.prefab");
    }
}
