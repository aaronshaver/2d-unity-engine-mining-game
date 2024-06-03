using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject basicDirt;

    public float minNoiseScale = 0.05f;
    public float maxNoiseScale = 0.2f;
    public float minThreshold = 0.4f;
    public float maxThreshold = 0.6f;

    private float noiseScale;
    private float threshold;

    public int gridWidth = 21;
    public int gridHeight = 21;
    public float tileSize = 1.0f;

    void Start()
    {
        noiseScale = Random.Range(minNoiseScale, maxNoiseScale);
        threshold = Random.Range(minThreshold, maxThreshold);
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
                    Instantiate(basicDirt, tilePosition, Quaternion.identity);
                }
            }
        }
    }
}