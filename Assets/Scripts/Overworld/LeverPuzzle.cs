using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    [SerializeField] private List<Lever> m_levers;

    [SerializeField] private int[] solutions;

    private int numTrue;

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
        int i = m_levers.Count - 1;
        Debug.Log("==========");
        foreach (Lever x in m_levers)
        {
            Debug.Log(x.name + ": " + x.retState());
            if(x.retState() == solutions[i])
            {
                numTrue++;
            } else
            {
                numTrue = 0;
            }
            i--;
        }
        Debug.Log("==========");

        if (numTrue == m_levers.Count && currInventory.Get(keyNeeded) != null)
        {
            endPuzzle();
        } else
        {
            Debug.Log("Missing either the key or incorrect code.");
        }

        numTrue = 0;
    }

    private void endPuzzle()
    {
        foreach (Lever x in m_levers)
        {
            Destroy(x);
        }
        Debug.Log("Puzzle solved!");
        Destroy(gameObject);
    }
}