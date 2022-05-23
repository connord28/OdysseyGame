using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class Calypso : InteractableObject
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
        dialogueController.GetComponent<DialogueRunner>().StartDialogue("CalypsoNext");

        /*DialogueRunner runner = dialogueController.GetComponent<DialogueRunner>();
        Debug.Log(runner.yarnProject);
        Debug.Log(runner.startNode);*/
        //dialogueController.GetComponent<DialogueRunner>().StartDialogue("Start");
    }

    [YarnCommand("CalypsoNext")]
    public void CalypsoNext(string scene)
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (scene == "game")
        {
            SceneManager.LoadScene(current + 1);
        }
        else
        {
            SceneManager.LoadScene(current + 2);
        }
    }

    /*public override void startInteraction()
    {
    }

    public override void endInteraction()
    {
    }*/
}
