using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TilemapController : MonoBehaviour
{
    [SerializeField] Tilemap tileMap;
    [SerializeField] List<TileData> tileDatas;
    Dictionary<TileBase, TileData> dataFromTiles;

    private void Start()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    public Vector3Int GetGridPos(Vector2 position, bool mousePosition)
    {
        Vector3 worldPos;

        if (mousePosition)
        {
            worldPos = Camera.main.ScreenToWorldPoint(position);
        }
        else
        {
            worldPos = position;
        }

        Vector3Int gridPos = tileMap.WorldToCell(worldPos);
        return gridPos;
    }

    public TileBase GetTileBase(Vector3Int gridPos)
    {
        TileBase tile = tileMap.GetTile(gridPos);
        Debug.Log("tile in pos = " + gridPos + " is " + tile);

        return tile;
    }
    public TileData GetTileData(TileBase tileBase)
    {
        return dataFromTiles[tileBase];
    }
}
