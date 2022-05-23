using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScrene : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject controls;
    [SerializeField] GameObject title;
    [SerializeField] GameObject intro;
    /*public void startGame()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current+1);
    }*/

    public void Credits(bool set)
    {
        credits.SetActive(set);
    }

    public void Controls()
    {
        controls.SetActive(true);
        title.SetActive(false);
    }
    public void Intro()
    {
        intro.SetActive(true);
        controls.SetActive(false);
    }
}
