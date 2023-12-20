using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data/Tool Action/Seed")]
public class SeedTile : ToolAction
{
    public override bool OnApplyToTilemap(Vector3Int grid, TilemapController tilemap, Item item)
    {
        if (tilemap.cropsManager.Check(grid) == false)
        {
            return false;
        }
        tilemap.cropsManager.Seed(grid, item.crop);
        return true;
    }

    public override void OnItemUsed(Item item, ItemContainer inventory)
    {
        inventory.Remove(item);
    }
}
