using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public void MuteAudio(bool mute)
    {
        if(mute) 
        { 
            AudioListener.volume = 0;
        }
        else 
        { 
            AudioListener.volume = 1;
        }
    }
}
