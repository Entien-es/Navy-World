using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;

    public long lastUpdated;
    public float time;
    public int days;
    public int health;
    public int xp;
    public int coin;

    public SerializableDictionary<string, bool> itemsCollected;

    public GameData()
    {
        this.time = 25200.0f;
        this.days = 0;
        this.health = 3;
        this.xp = 0;
        this.coin = 0;
        this.playerPosition = Vector3.zero;
        this.itemsCollected = new SerializableDictionary<string, bool>();
    }
   
}
