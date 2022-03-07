using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CustomCommands : MonoBehaviour
{

    // Drag and drop your Dialogue Runner into this variable.
    public DialogueRunner dialogueRunner;


    private Color highlightColor = new Color(193 / 255f, 193 / 255f, 193 / 255f);

    /*public void Awake()
    {
        Debug.Log("test");
        dialogueRunner.AddCommandHandler<GameObject>(
            "highlight",     // the name of the command
            Highlight// the method to run
        );
        Debug.Log("registered highlight");
    }*/

    // The method that gets called when '<<camera_look>>' is run.
    /*private void Highlight(GameObject Controller)
    {
        Controller.GetComponent<VNSprites>().highlight();
    }*/
}
