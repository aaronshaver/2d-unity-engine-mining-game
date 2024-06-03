using UnityEngine;
using System.Collections.Generic;

public class TerrainManager : MonoBehaviour
{
    public GameObject basicDirtPrefab;
    public ObjectPool objectPool;

    public float minNoiseScale = 0.05f;
    public float maxNoiseScale = 0.2f;
    public float minThreshold = 0.4f;
    public float maxThreshold = 0.6f;

    private float noiseScale;
    private float threshold;

    public int chunkWidth = 21;
    public int chunkHeight = 21;
    public float tileSize = 1.0f;
    public Transform player;

    private Dictionary<Vector2Int, GameObject> chunks = new Dictionary<Vector2Int, GameObject>();

    void Start()
    {
        noiseScale = Random.Range(minNoiseScale, maxNoiseScale);
        threshold = Random.Range(minThreshold, maxThreshold);

        // Generate initial chunks around the player
        GenerateInitialChunks();
    }

    void Update()
    {
        Vector2Int playerChunk = new Vector2Int(
            Mathf.FloorToInt(player.position.x / (chunkWidth * tileSize)),
            Mathf.FloorToInt(player.position.y / (chunkHeight * tileSize))
        );

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector2Int chunkCoord = playerChunk + new Vector2Int(x, y);
                if (!chunks.ContainsKey(chunkCoord))
                {
                    GenerateChunk(chunkCoord.x, chunkCoord.y);
                }
            }
        }
    }

    void GenerateInitialChunks()
    {
        Vector2Int playerChunk = new Vector2Int(
            Mathf.FloorToInt(player.position.x / (chunkWidth * tileSize)),
            Mathf.FloorToInt(player.position.y / (chunkHeight * tileSize))
        );

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 0; y++)
            {
                Vector2Int chunkCoord = playerChunk + new Vector2Int(x, y);
                GenerateChunk(chunkCoord.x, chunkCoord.y);
            }
        }
    }

    void GenerateChunk(int chunkX, int chunkY)
    {
        float offsetX = Random.Range(0, 10000);
        float offsetY = Random.Range(0, 10000);

        for (int x = 0; x < chunkWidth; x++)
        {
            for (int y = 0; y < chunkHeight; y++)
            {
                float worldX = (chunkX * chunkWidth + x) * tileSize;
                float worldY = (chunkY * chunkHeight + y) * tileSize;
                if (worldY >= 0) continue; // Skip generation above y == 0

                float perlinValue = Mathf.PerlinNoise((worldX * noiseScale) + offsetX, (worldY * noiseScale) + offsetY);
                if (perlinValue > threshold)
                {
                    Vector2 tilePosition = new Vector2(worldX, worldY);
                    objectPool.GetObject(tilePosition);
                }
            }
        }

        chunks[new Vector2Int(chunkX, chunkY)] = null; // Track the generated chunk
    }
}
