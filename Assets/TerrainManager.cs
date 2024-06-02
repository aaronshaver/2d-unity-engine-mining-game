using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int gridWidth = 21;
    public int gridHeight = 21;
    public float tileSize = 1.0f;
    public float noiseScale = 0.1f;
    public float threshold = 0.5f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        int randomSeed = System.DateTime.Now.Millisecond;
        System.Random random = new System.Random(randomSeed);
        float offsetX = random.Next(0, 10000);
        float offsetY = random.Next(0, 10000);

        for (int x = -(gridWidth / 2); x < gridWidth / 2; x++)
        {
            for (int y = -gridHeight; y < 0; y++)
            {
                float perlinValue = Mathf.PerlinNoise((x * noiseScale) + offsetX, (y * noiseScale) + offsetY);
                if (perlinValue > threshold)
                {
                    Vector2 tilePosition = new Vector2(x * tileSize, y * tileSize);
                    Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                }
            }
        }
    }
}
