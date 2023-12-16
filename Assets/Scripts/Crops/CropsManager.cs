using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Crops
{

}

public class CropsManager : MonoBehaviour
{
    [SerializeField] TileBase plow;
    [SerializeField] TileBase seed;
    [SerializeField] Tilemap targetTilemap;

    Dictionary<Vector2Int, Crops> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, Crops>();
    }
    public bool Check(Vector2Int pos)
    {
        return crops.ContainsKey(pos);
    }
    public void Plow(Vector2Int pos)
    {
        if (crops.ContainsKey(pos))
        {
            return;
        }
        CreatePlowedTile(pos);
    }
    public void Seed(Vector3Int pos)
    {
        targetTilemap.SetTile(pos, seed);
    }
    private void CreatePlowedTile(Vector2Int pos)
    {
        Crops crop = new Crops();
        crops.Add(pos, crop);

        targetTilemap.SetTile((Vector3Int)pos, plow);
    }
}
