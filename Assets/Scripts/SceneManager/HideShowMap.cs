using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowMap : MonoBehaviour
{
    private bool isOutside = true;
    private bool isInside = false;

    public AudioSource music;
    public AudioSource src;
    public AudioClip openTheDoor;
    public AudioClip closeTheDoor;

    public GameObject roof;
    public EdgeCollider2D edgInside;
    public EdgeCollider2D edgOutside;

    private void Awake()
    {
        music.Play();
        music.Pause();
    }

    private void FixedUpdate()
    {
        roof.SetActive(isOutside);
        edgOutside.enabled = isOutside;
        edgInside.enabled = isInside;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        src.PlayOneShot(openTheDoor);
        if (!music.isPlaying) { music.Play(); }
        music.UnPause();

        isInside = !isInside;
        isOutside = !isOutside;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        src.PlayOneShot(closeTheDoor);
        music.Pause();

        isOutside = !isOutside;
        isInside = !isInside;
    }
}
