using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolPlayerController : MonoBehaviour
{
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TilemapController tilemapController;
    [SerializeField] ToolbarController toolbar;
    [SerializeField] float maxDistance = 1.5f;

    PlayerController player;
    Rigidbody2D rb;
    Vector3Int selectedTile;

    bool selectable;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void CanSelectCheck()
    {
        Vector2 playerPos = transform.position + new Vector3(0, 2f);
        Vector2 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(playerPos, cam) < maxDistance;
        markerManager.Show(selectable);
    }

    public void SelectedTile()
    {
        selectedTile = tilemapController.GetGridPos(Input.mousePosition, true);
    }

    public void Marker()
    {
        markerManager.markedCellPosition = selectedTile;
    }

    public bool UseTool()
    {
        Vector2 pos = (Vector2)player.transform.position + new Vector2(0f, 2f);

        Item item = toolbar.GetItem;
        Debug.Log(item.Name);

        if (item == null) { return false; }
        if (item.onAction == null) { return false; }

        bool complete = item.onAction.OnApply(pos);
        if (complete)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }
        }
        return complete;
    }
    public void UseToolGrid()
    {
        if (selectable)
        {
            Item item = toolbar.GetItem;
            Debug.Log(item.Name);
            if (item == null) { return; }
            if (item.onTilemapAction == null) { return; }

            bool complete = item.onTilemapAction.OnApplyToTilemap(selectedTile, tilemapController, item);
            if (complete) 
            {
                if (item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer); 
                }
            }
        }
    }
}
