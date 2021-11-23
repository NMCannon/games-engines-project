using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int terrain_depth = 20;
    public int terrain_width = 1000;
    public int terrain_height = 1000;
    public float terrain_scale = 10f;
    public float terrain_offset_x = 10f;
    public float terrain_offset_y = 10f;

    void Start()
    {
        GenerateOffset();
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    void GenerateOffset()
    {
        terrain_offset_x = Random.Range(0f, 100f);
        terrain_offset_y = Random.Range(0f, 100f);
    }

    TerrainData GenerateTerrain(TerrainData data)
    {
        data.heightmapResolution = terrain_width + 1;
        data.size = new Vector3(terrain_width, terrain_depth, terrain_height);
        data.SetHeights(0, 0, GenerateHeights());

        return data;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[terrain_width, terrain_height];
        for (int x = 0; x < terrain_width; x++)
        {
            for (int y = 0; y < terrain_height; y++)
            {
                heights[x, y] = CalculateHeights(x, y);
            }
        }
        return heights;
    }

    float CalculateHeights(int x, int y)
    {
        float xCoordinate = ((float)x / terrain_width) * terrain_scale + terrain_offset_x;
        float yCoordinate = ((float)y / terrain_height) * terrain_scale + terrain_offset_y;
        return Mathf.PerlinNoise(xCoordinate, yCoordinate);
    
    }
}