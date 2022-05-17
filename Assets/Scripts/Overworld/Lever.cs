using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractableObject
{
    [SerializeField] private int maxState;
    [SerializeField] private int minState;

    [SerializeField] private int leverState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int retState()
    {
        return leverState;
    }

    public override void startInteraction()
    {
        updateLever();
    }

    public void incState()
    {
        if(leverState < maxState)
        {
            leverState++;
        } else
        {
            leverState = minState;
        }
    }

    private void updateLever()
    {
        //change state of lever (visually)
        incState();
        GetComponentInParent<LeverPuzzle>().puzzleStatus();
    }
}
