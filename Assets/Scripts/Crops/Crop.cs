using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data/Crop")]
public class Crop : ScriptableObject
{
    public Item yield;
    public int timeToGrow = 10;
    public int count = 1;
}
