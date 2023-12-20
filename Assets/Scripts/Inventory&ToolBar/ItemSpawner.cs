using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimeAgent))]
public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item itemToSpawn;
    [SerializeField] int count = 1;
    [SerializeField] float spread = 2f;
    [SerializeField] float probability = .5f;

    private void Start()
    {
        TimeAgent timeAgent = GetComponent<TimeAgent>();
        timeAgent.onTimeTick += Spawn;
    }
    void Spawn()
    {
        if (UnityEngine.Random.value < probability)
        {
            Vector2 pos = transform.position;
            pos.x += spread * UnityEngine.Random.value - spread / 2;
            pos.y += spread * UnityEngine.Random.value - spread / 2;
            ItemSpawnManager.instance.SpawnItem(pos, itemToSpawn, count);
        }
    }
}
