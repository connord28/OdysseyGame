using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScrene : MonoBehaviour
{
    [SerializeField] GameObject credits;
    public void startGame()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current+1);
    }

    public void Credits(bool set)
    {
        credits.SetActive(set);
    }
}
