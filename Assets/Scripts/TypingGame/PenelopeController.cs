using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class PenelopeController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject dialogueRunner;
    [SerializeField] GameObject currentScene;
    [SerializeField] GameObject IntroText;
    [SerializeField] YarnProject project;
    [SerializeField] Image npc;
    [SerializeField] List<Sprite> npcSprites;
    //[SerializeField] Image background;
    //[SerializeField] List<Sprite> backgroundSprites;



    [YarnCommand("PenelopeNext")]
    public void PenelopeNext(string scene)
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (scene == "game")
        {
            dialogueRunner.SetActive(false);
            currentScene.SetActive(false);
            SceneManager.LoadScene(current + 1, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(current + 2);
        }
    }

    [YarnCommand("switch")]
    public void switchSprite()
    {
        npc.sprite = npcSprites[1];
    }

    /*[YarnCommand("TelemachusEnd")]
    public void TelemachusEnd()
    {
        player.SetActive(true);
        dialogueRunner.SetActive(false);
        npc.sprite = npcSprites[1];
        background.sprite = backgroundSprites[1];
    }*/

    public void restart()
    {
        currentScene.SetActive(true);
        player.SetActive(true);
        dialogueRunner.SetActive(false);
        dialogueRunner.GetComponent<DialogueRunner>().startNode = "Penelope";
    }

    public void DiaogueOne()
    {
        IntroText.SetActive(false);
        player.SetActive(true);
        //dialogueRunner.SetActive(true);
        //npc.sprite = npcSprites[0];
        //background.sprite = backgroundSprites[0];
        //dialogueRunner.GetComponent<DialogueRunner>().startAutomatically = false;
        //dialogueRunner.GetComponent<DialogueRunner>().SetProject(project); 
        //dialogueRunner.GetComponent<DialogueRunner>().StartDialogue("Telemachus");
    }

    [YarnCommand("endGame")]
    public void endGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
