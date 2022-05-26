using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private Canvas inventoryUI;

    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    [SerializeField] public List<InventoryItem> inventory { get; private set; }
    
    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
            //Update UI?
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
            inventoryUI.GetComponent<HUD>().inventoryAddedItem(newItem);
            Debug.Log("Added " + referenceData.displayName + " to inventory.");
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }
}
