using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCustom : MonoBehaviour
{
    private void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
