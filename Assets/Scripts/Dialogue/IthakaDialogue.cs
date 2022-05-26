using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class IthakaDialogue : MonoBehaviour
{
    [YarnCommand("endScene")]
    public void CyclopsNext(bool suceed)
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (suceed)
        {
            SceneManager.LoadScene(current + 1);
        }
        else
        {
            SceneManager.LoadScene(current);
        }
    }
}
