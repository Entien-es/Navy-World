using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    [SerializeField] public GameObject panelPauseGame;
    [SerializeField] public GameObject panelInventory;
    [SerializeField] GameObject panelToolbar;
    [SerializeField] GameObject menuButton;

    private bool openInventory;
    private bool openMenu;

    private void Update()
    {
        GetInput();
        OpenInventory();
        OpenMenu();
    }

    private void GetInput()
    {
        openInventory = Input.GetKeyDown(KeyCode.I);
        openMenu = Input.GetKeyDown(KeyCode.Escape);
    }
    public void OpenInventory()
    {
        if (openInventory)
        {
            panelInventory.SetActive(!panelInventory.activeInHierarchy);
            panelToolbar.SetActive(!panelToolbar.activeInHierarchy);
        }
    }
    public void OpenMenu()
    {
        if (openMenu) 
        {
            panelPauseGame.SetActive(!panelPauseGame.activeInHierarchy);
            menuButton.SetActive(!menuButton.activeInHierarchy);
        }
    }
}
