using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private InventorySystem inventory;

    private Transform hotbar;

    // Start is called before the first frame update
    void Start()
    {
        hotbar = transform.Find("Hotbar");
        foreach (RectTransform slot in hotbar)
        {
            Image slotImg = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            slotImg.enabled = false;
        }
    }

    public void inventoryAddedItem(InventoryItem refData)
    {
        foreach(Transform slot in hotbar)
        {
            Image slotImg = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if (!slotImg.enabled)
            {
                slotImg.enabled = true;
                slotImg.sprite = refData.data.icon;

                slotImg.GetComponent<ItemImage>().item = refData.data;

                break;
            }
        }
    }
}
