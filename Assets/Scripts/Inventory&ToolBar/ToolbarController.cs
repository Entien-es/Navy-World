using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    public Action<int> onChange;
    public PlayerController player;

    public int selectedTool;

    private int totalToolbar = 9;
    private float delta;

    private void Start()
    {
        
    }
    private void Update()
    {
        GetInput();
        ChangeToolbar();
    }
    private void GetInput()
    {
		delta = Input.mouseScrollDelta.y;
    }
    private void ChangeToolbar()
    {
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
