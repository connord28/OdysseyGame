using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;


public class CaveController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject npc;
    [SerializeField] GameObject dialogueRunner;
    [SerializeField] GameObject currentScene;


    [YarnCommand("CyclopsNext")]
    public void CyclopsNext(string scene)
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (scene == "game")
        {
            dialogueRunner.SetActive(false);
            npc.SetActive(true);
            currentScene.SetActive(false);
            SceneManager.LoadScene(current + 1, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(current + 2);
        }
    }

    public void restart()
    {
        currentScene.SetActive(true);
        player.SetActive(true);
        npc.SetActive(true);
        dialogueRunner.SetActive(false);
        dialogueRunner.GetComponent<DialogueRunner>().startNode = "Cyclops";
    }
}
