using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApply is not implemented");
        return true;
    }
    public virtual bool OnApplyToTilemap(Vector3Int grid, TilemapController tilemap, Item item)
    {
        Debug.LogWarning("OnApplyToTilemap is not implemented");
        return true;
    }
    public virtual void OnItemUsed(Item item, ItemContainer inventory) 
    {

    }
}
