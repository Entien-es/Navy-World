using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    [SerializeField] public GameObject panelPauseGame;
    [SerializeField] public GameObject panelInventory;
    [SerializeField] public GameObject panelToolbar;

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
            panelToolbar.SetActive(!panelToolbar.activeInHierarchy);

        }
    }
    public void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && panelInventory.activeInHierarchy == false)
        {
            panelPauseGame.SetActive(!panelPauseGame.activeInHierarchy);
            panelToolbar.SetActive(!panelToolbar.activeInHierarchy);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && panelInventory.activeInHierarchy == true) 
        {
            panelInventory.SetActive(!panelInventory.activeInHierarchy);
            panelToolbar.SetActive(!panelToolbar.activeInHierarchy);
        }
    }
}
