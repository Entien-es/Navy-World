using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        icon.color = new Color(255, 255, 255, 1);

        if (slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else { text.gameObject.SetActive(false); }
        
    }
    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive (false);
        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemContainer inventory = GameManager.instance.inventoryContainer;
        ItemContainer tool = GameManager.instance.toolbarContainer;

        GameManager.instance.dragAndDropController.OnClick(inventory.slots[myIndex]);
        transform.parent.GetComponent<ItemPanel>().Show();
    }
}
