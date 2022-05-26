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
        Debug.Log("test0");
        dialogueController.GetComponent<DialogueRunner>().startAutomatically = false;
        dialogueController.GetComponent<DialogueRunner>().SetProject(project);
        //dialogueController.GetComponent<DialogueRunner>().verboseLogging = true;
        Debug.Log("test");
        //Debug.Log(dialogueController.GetComponent<DialogueRunner>().NodeExists("test"));
        dialogueController.GetComponent<DialogueRunner>().StartDialogue("Cyclops");

        /*DialogueRunner runner = dialogueController.GetComponent<DialogueRunner>();
        Debug.Log(runner.yarnProject);
        Debug.Log(runner.startNode);*/
        //dialogueController.GetComponent<DialogueRunner>().StartDialogue("Start");
    }
}
