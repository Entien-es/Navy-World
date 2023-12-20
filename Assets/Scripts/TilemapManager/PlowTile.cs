using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName="Data/Tool Action/Plow")]
public class PlowTile : ToolAction
{
    [SerializeField] List<TileBase> canPlow;
    public override bool OnApplyToTilemap(Vector3Int grid, TilemapController tilemap, Item item)
    {
        TileBase tileToPlow = tilemap.GetTileBase(grid);
        if (canPlow.Contains(tileToPlow) == false)
        {
            return false;
        }
        tilemap.cropsManager.Plow(grid);
        return true;
    }
}
