using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Transform player;

    [SerializeField] float speed = 3f;
    [SerializeField] float pickUpDistance = 2f;
    [SerializeField] float ttl = 10f;

    public Item item;
    public int count = 1;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;

        if (ttl < 0) { Destroy(gameObject); }

        float distance = Vector2.Distance(transform.position, player.position + new Vector3(0f, 1f));
        if (distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards
            (
            transform.position, 
            player.position + new Vector3(0f, 2f),
            speed * Time.deltaTime
            );
        if (distance < 1.1f)
        {
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            }
            Destroy(gameObject);
        }
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.sprite = item.icon;
    }
}
