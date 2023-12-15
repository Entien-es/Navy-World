using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarUI : MonoBehaviour
{
    [SerializeField] private int currentToolIndex;
    [SerializeField] private int totalToolbar = 1;

    public Action<int> onChange;
    public GameObject[] itemToolbar;
    public GameObject holderTool;
    public PlayerController player;

    private GameObject currentTool;
	private float delta;

    private void Start()
    {
        totalToolbar = holderTool.transform.childCount;
        itemToolbar = new GameObject[totalToolbar];

        for (int i = 0; i < totalToolbar; i++)
        {
            itemToolbar[i] = holderTool.transform.GetChild(i).gameObject;
            itemToolbar[i].SetActive(false);
        }

        itemToolbar[0].SetActive(true);
        currentTool = itemToolbar[0];
        currentToolIndex = 0;
        player.currentTool = currentToolIndex + 1;

        Debug.Log("Current tool: " + player.currentTool);
    }
    private void Update()
    {
        GetInput();
        ChangeTool();
    }
    private void GetInput()
    {
		delta = Input.mouseScrollDelta.y;
    }
    private void ChangeTool()
    {
        if (delta != 0)
        {
			if (delta > 0)
			{
				itemToolbar[currentToolIndex].SetActive(false);
				currentToolIndex += 1;
				currentToolIndex = (currentToolIndex >= totalToolbar ? 0 : currentToolIndex);
                itemToolbar[currentToolIndex].SetActive(true);

                currentTool = itemToolbar[currentToolIndex];
                player.currentTool = currentToolIndex + 1;
			}
			else
			{
                itemToolbar[currentToolIndex].SetActive(false);
                currentToolIndex -= 1;
				currentToolIndex = (currentToolIndex < 0 ? totalToolbar-1 : currentToolIndex);
                itemToolbar[currentToolIndex].SetActive(true);

                currentTool = itemToolbar[currentToolIndex];
                player.currentTool = currentToolIndex + 1;
            }
            onChange?.Invoke(currentToolIndex);
			Debug.Log("Current tool: " + player.currentTool);
        }
    }
}
