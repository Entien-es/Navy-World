using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPlayerController : MonoBehaviour
{
    PlayerController player;
    Rigidbody2D rb;
    
    private void Awake()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void UseTool()
    {
        Vector2 pos = rb.position + (Vector2)player.transform.position.normalized + new Vector2(1.2f, 0);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, 1.2f);

        foreach (var item in colliders)
        {
            ToolHit hit = item.GetComponent<ToolHit>();
            if (hit != null)
            {
                Debug.DrawLine(pos, hit.transform.position, Color.red, 1.2f);
                hit.Hit();
                break;
            }
        }
    }
}
