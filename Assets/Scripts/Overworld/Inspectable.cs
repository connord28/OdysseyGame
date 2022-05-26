using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Inspectable : MonoBehaviour
{
    [SerializeField] private Image _img;
    [SerializeField] private Button _button;
    
    void Awake()
    {
        _img.enabled = false;
        _button.GetComponent<Image>().enabled = false;
        _button.enabled = false;
    }

    public void itemClickRoutine()
    {
        _img.enabled = true;
        _button.GetComponent<Image>().enabled = true;
        _button.enabled = true;
    }

    public void exit()
    {
        Debug.Log("Closing shit");
        _img.enabled = false;
        _button.enabled = false;
        _button.GetComponent<Image>().enabled = false;
    }
}
