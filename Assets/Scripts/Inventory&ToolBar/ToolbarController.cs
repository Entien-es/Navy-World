using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    private int totalToolbar = 9;
    private float delta;

    public Action<int> onChange;
    public PlayerController player;

    private int selectedTool;

    public Item GetItem
    {
        get { return GameManager.instance.inventoryContainer.slots[selectedTool].item; }
    }

    private void Update()
    {
        delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            if (delta > 0)
            {
                selectedTool += 1;
                selectedTool = (selectedTool >= totalToolbar ? 0 : selectedTool);
            }
            else
            {
                selectedTool -= 1;
                selectedTool = (selectedTool < 0 ? totalToolbar - 1 : selectedTool);
            }
            onChange?.Invoke(selectedTool);
        }
    }

    internal void Set(int id)
    {
        selectedTool = id;
    }
}
