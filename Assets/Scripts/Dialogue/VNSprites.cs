using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
public class VNSprites : MonoBehaviour
{
    private Color shadeColor = new Color(193/255f, 193/255f, 193/255f);

    //[SerializeField] GameObject odysseus;
    //[SerializeField] GameObject Penelope;
    //private int turn = 0;

    [YarnCommand("highlight")]
    public void highlight(string other) //find string
    {
        this.GetComponent<Image>().color = Color.white;
        GameObject.Find(other).GetComponent<Image>().color = shadeColor;
        /*if (turn == 2)
        {
            odysseus.GetComponent<Image>().color = Color.white;
            Penelope.GetComponent<Image>().color = highlightColor;
        }
        else if (turn == 0 || turn == 1 || turn == 3 || turn == 4)
        {
            odysseus.GetComponent<Image>().color = highlightColor;
            Penelope.GetComponent<Image>().color = Color.white;
        }
        turn++;
        Debug.Log("Worked");*/
    }
}
