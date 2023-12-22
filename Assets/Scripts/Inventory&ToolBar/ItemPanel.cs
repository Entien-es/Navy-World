using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ItemPanel : MonoBehaviour, IDataPersistence
{
    public ItemContainer inventory;
    public List<InventoryButton> buttons;

    [SerializeField] private string idKey;
    [ContextMenu("Genegrate guid for id")]
    private void GenegrateGuid()
    {
        idKey = System.Guid.NewGuid().ToString();
    }

    public void Awake()
    {
        inventory = Resources.Load<ItemContainer>("Data/Inventory");
        Init();
    }
    private void OnEnable()
    {
        Show();
    }
    public void Init()
    {
        SetIndex();
        Show();
    }

    private void SetIndex()
    {
        for(int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }
    public void Show()
    {
        for(int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }
    public virtual void OnClick(int id) { }


    public void LoadData(GameData data)
    {
        data.itemsCollected.TryGetValue(idKey, out inventory);
    }

    public void SaveData(ref GameData data)
    {
        if (data.itemsCollected.ContainsKey(idKey))
        {
            data.itemsCollected.Remove(idKey);
        }
        data.itemsCollected.Add(idKey, inventory);
    }
}
