using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropTile
{
    public Crop crop;
    public int growTimer;
}

public class CropsManager : MonoBehaviour
{
    [SerializeField] TileBase plow;
    [SerializeField] TileBase seed;
    [SerializeField] Tilemap targetTilemap;

    Dictionary<Vector2Int, CropTile> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropTile>();
    }
    public bool Check(Vector3Int pos)
    {
        return crops.ContainsKey((Vector2Int) pos);
    }
    public void Plow(Vector3Int pos)
    {
        if (crops.ContainsKey((Vector2Int) pos))
        {
            return;
        }
        CreatePlowedTile((Vector2Int) pos);
    }
    public void Seed(Vector3Int pos, Crop toSeed)
    {
        targetTilemap.SetTile(pos, seed);

        crops[(Vector2Int) pos].crop = toSeed;
    }
    private void CreatePlowedTile(Vector2Int pos)
    {
        CropTile crop = new CropTile();
        crops.Add(pos, crop);

        targetTilemap.SetTile((Vector3Int)pos, plow);
    }
}
