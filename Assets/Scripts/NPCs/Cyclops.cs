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
    [SerializeField] GameObject Eventsystem;
    public EventSystem eventSystem;
    public Canvas canvas;

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
        Eventsystem.SetActive(true);
        dialogueController.SetActive(true);
        /*DialogueRunner runner = dialogueController.GetComponent<DialogueRunner>();
        Debug.Log(runner.yarnProject);
        Debug.Log(runner.startNode);*/
        //dialogueController.GetComponent<DialogueRunner>().StartDialogue("Start");
    }
}
