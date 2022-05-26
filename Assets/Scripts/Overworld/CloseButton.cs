using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject toClose;

    public void close()
    {
        toClose.GetComponent<Inspectable>().exit();
    }
}
