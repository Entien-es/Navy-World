using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class ResourceNode : ToolHit
{
    [SerializeField] Item item;
    [SerializeField] int itemCountInOneDrop = 1;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = .7f;
    [SerializeField] ResourceNodeType type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .5f);
        GetComponent<SpriteRenderer>().sortingOrder = 4;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector2 pos = transform.position;
            pos.x += spread * UnityEngine.Random.value - spread / 2;
            pos.y += spread * UnityEngine.Random.value - spread / 2;
            ItemSpawnManager.instance.SpawnItem(pos, item, itemCountInOneDrop);
        }
        Destroy(gameObject);
    }
    public override bool CanBeHit(List<ResourceNodeType> canBeHit)
    {
        Debug.Log(type);
        return canBeHit.Contains(type);
    }
}
