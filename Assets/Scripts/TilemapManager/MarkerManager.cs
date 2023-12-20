using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    [SerializeField] Tilemap targetTilemap;
    [SerializeField] TileBase tileBase;
    
    public Vector3Int markedCellPosition;
    Vector3Int oldCellPosition;
    bool isShow;

    private void Update()
    {
        if (isShow == false) return;
        targetTilemap.SetTile(oldCellPosition, null);
        targetTilemap.SetTile(markedCellPosition, tileBase);
        oldCellPosition = markedCellPosition;
    }

    internal void Show(bool selectable)
    {
        isShow = selectable;
        targetTilemap.gameObject.SetActive(isShow);
    }
}
