using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class CaveController : MonoBehaviour
{
    [YarnCommand("nextScene")]
    public void nextScene(string scene)
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
}
