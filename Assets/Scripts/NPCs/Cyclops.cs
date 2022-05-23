using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cyclops : InteractableObject
{
    [SerializeField] GameObject dialogueController;
    [SerializeField] GameObject player;
    [SerializeField] YarnProject project;

    public void runDialogue()
    {
        //canvas.enabled = true;
        //eventSystem.enabled = true;
        player.SetActive(false);
        dialogueController.SetActive(true);
        dialogueController.GetComponent<DialogueRunner>().startAutomatically = false;
        dialogueController.GetComponent<DialogueRunner>().SetProject(project);
        dialogueController.GetComponent<DialogueRunner>().StartDialogue("Start");

        /*DialogueRunner runner = dialogueController.GetComponent<DialogueRunner>();
        Debug.Log(runner.yarnProject);
        Debug.Log(runner.startNode);*/
        //dialogueController.GetComponent<DialogueRunner>().StartDialogue("Start");
    }
}
