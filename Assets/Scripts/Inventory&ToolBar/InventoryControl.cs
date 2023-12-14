using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    [SerializeField]public GameObject panelInventory;
    [SerializeField]public GameObject panelPauseGame;

    private void Update()
    {
        OpenInventory();
        Escape();
    }
    public void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panelInventory.SetActive(!panelInventory.activeInHierarchy);
        }
    }
    public void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && panelInventory.activeInHierarchy == false)
        {
            panelPauseGame.SetActive(!panelPauseGame.activeInHierarchy);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && panelInventory.activeInHierarchy == true) 
        { 
            OpenInventory(); 
        }
    }
}
