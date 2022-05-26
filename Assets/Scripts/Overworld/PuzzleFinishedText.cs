using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleFinishedText : DisplayText
{

    // Start is called before the first frame update
    void Start()
    {
        Color temp = GetComponent<TextMeshProUGUI>().color;
        temp.a = 0;
        base.GetComponent<TextMeshProUGUI>().color = temp;

        //Color temp = base.GetComponent<TextMeshPro>().color;
        //temp.a = 0;
        //base.GetComponent<TextMeshPro>().color = temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayNoti()
    {
        displayUITextFadeIn();
        displayUITextFadeOut();
    }
}
