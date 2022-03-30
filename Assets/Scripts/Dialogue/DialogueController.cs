using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;


public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;

    [YarnCommand("highlight")]
    public static void highlight(GameObject speaker, GameObject other) //find string
    {
        /*if(who == "Odysseus")
        {
            Odysseus.GetComponent<Image>().color = Color.white;
            Other.GetComponent<Image>().color = shadeColor;
        }
        else
        {
            Odysseus.GetComponent<Image>().color = shadeColor; 
            Other.GetComponent<Image>().color = Color.white;
        }*/
        speaker.GetComponent<Image>().color = Color.white;
        other.GetComponent<Image>().color = new Color(193 / 255f, 193 / 255f, 193 / 255f);
    }

    [YarnCommand("swapBackground")]
    public void swapBackground() //find string
    {
        background1.SetActive(false);
        background2.SetActive(true);
    }
}
