using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
    private void OnEnable()
    {
        inventory = (ItemContainer)Resources.InstanceIDToObject(29304);
        Debug.LogWarning(inventory.GetInstanceID());
        Init();
    }
    public override void OnClick(int id)
    {
        GameManager.instance.dragAndDropController.OnClick(inventory.slots[id]);
        Show();
    }
}
