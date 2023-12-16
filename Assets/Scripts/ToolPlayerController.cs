using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolPlayerController : MonoBehaviour
{
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TilemapController tilemapController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowable;

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
        Vector2 playerPos = transform.position;
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

    public void UseTool()
    {
        Vector2 pos = rb.position + (Vector2)player.transform.position.normalized + new Vector2(1, -.5f);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, 1f);

        foreach (var item in colliders)
        {
            ToolHit hit = item.GetComponent<ToolHit>();
            if (hit != null)
            {
                Debug.DrawLine(pos, hit.transform.position, Color.red, 1.5f);
                hit.Hit();
                break;
            }
        }
    }

    public void UseToolGrid()
    {
        if (selectable)
        {
            try
            {
                TileBase tileBase = tilemapController.GetTileBase(selectedTile);
                TileData tileData = tilemapController.GetTileData(tileBase);
                if (tileData != plowable) return;

                if (cropsManager.Check((Vector2Int)selectedTile)) { cropsManager.Seed(selectedTile); }
                else { cropsManager.Plow((Vector2Int)selectedTile); }
            }
            catch { }
        }
    }
}
