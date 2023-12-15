using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TreeCutable : ToolHit
{
    public GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = .7f;

    private void Start()
    {
        //pickUpDrop = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Plants/wood.prefab", typeof(GameObject));
    }
    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector2 pos = transform.position;
            pos.x += spread * UnityEngine.Random.value - spread / 2;
            pos.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject obj = Instantiate(pickUpDrop);
            obj.transform.position = pos;
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .5f);
        GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
