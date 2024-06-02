using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int gridWidth = 21;
    public int gridHeight = 21;
    public float tileSize = 1.0f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = -(gridWidth / 2); x < gridWidth / 2; x++)
        {
            for (int y = -gridHeight; y < 0; y++)
            {
                Vector2 tilePosition = new Vector2(x * tileSize, y * tileSize);
                Instantiate(tilePrefab, tilePosition, Quaternion.identity);
            }
        }
    }
}
