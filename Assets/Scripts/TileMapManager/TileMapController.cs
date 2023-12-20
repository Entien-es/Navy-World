using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TilemapController : MonoBehaviour
{
    public CropsManager cropsManager;

    [SerializeField] Tilemap tileMap;

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
        if (tile != null)
            Debug.Log("Tile in position: " + gridPos + " is " + tile);
        else
            Debug.LogWarning("Not found tile in position: " + gridPos);

        return tile;
    }
}
