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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void runDialogue()
    {
        //canvas.enabled = true;
        //eventSystem.enabled = true;
        player.SetActive(false);
        dialogueController.SetActive(true);
        dialogueController.GetComponent<DialogueRunner>().startAutomatically = false;
        dialogueController.GetComponent<DialogueRunner>().SetProject(project);
        dialogueController.GetComponent<DialogueRunner>().StartDialogue("Next");

        /*DialogueRunner runner = dialogueController.GetComponent<DialogueRunner>();
        Debug.Log(runner.yarnProject);
        Debug.Log(runner.startNode);*/
        //dialogueController.GetComponent<DialogueRunner>().StartDialogue("Start");
    }
}
