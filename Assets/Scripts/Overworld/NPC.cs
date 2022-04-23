using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class NPC : MonoBehaviour
{
    [SerializeField] DialogueRunner runner;
    public string startNode;
    public void Interaction()
    {
        runner.StartDialogue(startNode);
    }

}
