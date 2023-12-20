using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAgent : MonoBehaviour
{
    public Action onTimeTick;

    private void Start()
    {
        GameManager.instance.dayTimeController.Subcribe(this);
    }
    private void OnDestroy()
    {
        GameManager.instance.dayTimeController.Unsubcribe(this);
    }
    public void Invoke() 
    {
        onTimeTick?.Invoke();
    }
}
