using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClickHandler : MonoBehaviour
{
    [SerializeField] private ItemImage itemImg;
    private Inspectable item;
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        item = GameObject.FindGameObjectWithTag("Inspectable").GetComponent<Inspectable>();
    }
    public void OnItemClicked()
    {
        if(itemImg.item != null && player.hasItem(itemImg.item))
        {
            item.itemClickRoutine();
        }
    }
}
