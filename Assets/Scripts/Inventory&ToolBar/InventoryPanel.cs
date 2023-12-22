using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
    private void Start()
    {
        inventory = Resources.Load<ItemContainer>("Data/Inventory");
        Debug.LogWarning("Inventory ID: " + inventory.GetInstanceID());
    }
    public override void OnClick(int id)
    {
        GameManager.instance.dragAndDropController.OnClick(inventory.slots[id]);
        Show();
    }
}
