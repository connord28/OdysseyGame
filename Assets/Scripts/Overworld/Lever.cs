using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractableObject
{
    [SerializeField] private Sprite[] leverSprites;

    [SerializeField] private int maxState;
    [SerializeField] private int minState;

    [SerializeField] private int leverState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        int state = Random.Range(minState, maxState);
        leverState = state;
        //GetComponent<SpriteRenderer>().sprite = leverSprites[state];
        setSprite(leverSprites[state]);
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

        //GetComponent<SpriteRenderer>().sprite = leverSprites[leverState];
        setSprite(leverSprites[leverState]);
    }

    private void updateLever()
    {
        incState();
        GetComponentInParent<LeverPuzzle>().puzzleStatus();
    }
}
