using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InteractableObject
{
    bool opened;

    public InventoryItemData m_item;
    private InventorySystem currInventory;

    [SerializeField] private Sprite open;
    [SerializeField] private Sprite closed;

    // Start is called before the first frame update
    void Start()
    {
        currInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void startInteraction()
    {
        openChest();
    }

    public override void endInteraction()
    {
        if (opened) { closeChest(); }
    }

    public void openChest()
    {
        if(!opened)
        {
            opened = true;
            currInventory.Add(m_item);
            gameObject.GetComponent<SpriteRenderer>().sprite = open;
            Debug.Log("Opened chest. The key has 3 numbers enscribed into it: 1 0 2");
        }
    }

    public void closeChest()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = closed;
    }
}
