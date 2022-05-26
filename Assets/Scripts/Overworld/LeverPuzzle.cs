using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    [SerializeField] private List<Lever> m_levers;

    [SerializeField] private int[] solutions;

    [SerializeField] private GameObject door;
    [SerializeField] private GameObject notification;

    private int numTrue;
    private bool doorOpened;

    [SerializeField] private InventoryItemData keyNeeded;
    private InventorySystem currInventory;

    // Start is called before the first frame update
    void Start()
    {
        currInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventorySystem>();

        Lever[] levers = (Lever[])FindObjectsOfType<Lever>();
        foreach (Lever x in levers)
        {
            m_levers.Add(x);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void puzzleStatus()
    {
        int i = 0;
        foreach (Lever x in m_levers)
        {
            if(x.retState() == solutions[i])
            {
                numTrue++;
            } else
            {
                numTrue = 0;
            }
            i++;
        }

        if (numTrue == m_levers.Count && currInventory.Get(keyNeeded) != null && !doorOpened)
        {
            doorOpened = true;
            endPuzzle();
        } else
        {
            Debug.Log("Missing either the key or incorrect code.");
        }

        numTrue = 0;
    }

    private void endPuzzle()
    {
        Debug.Log("Puzzle solved! Opening exit!");
        door.GetComponent<LockedDoor>().puzzleCompleted();
        notification.GetComponent<PuzzleFinishedText>().displayNoti();
    }
}
