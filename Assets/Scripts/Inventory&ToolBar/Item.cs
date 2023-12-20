using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName="Data/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite icon;
    public ToolAction onAction;
    public ToolAction onTilemapAction;
    public ToolAction onItemUsed;
    public Crop crop;
}
