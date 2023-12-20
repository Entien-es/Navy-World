using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject pickUpItemPrefabs;
    public static ItemSpawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnItem(Vector3 position, Item item, int count)
    {
        GameObject obj = Instantiate(pickUpItemPrefabs, position, Quaternion.identity);
        obj.GetComponent<PickupItem>().Set(item, count);
    }
}
