using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public long lastUpdated;

    public float time;
        
    public int days;

    public Vector3 playerPosition;

    public SerializableDictionary<string, bool> itemsCollected;

    public GameData()
    {
        this.time = 0.0f;
        this.days = 0;
        playerPosition = Vector3.zero;
        itemsCollected = new SerializableDictionary<string, bool>();
    }
   
}
