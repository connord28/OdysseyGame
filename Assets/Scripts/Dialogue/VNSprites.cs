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
    }

    [YarnCommand("remove")]
    public void remove(string other) //find string
    {
        this.GetComponent<Image>().color = Color.white;
        GameObject.Find(other).SetActive(false);
    }
}
