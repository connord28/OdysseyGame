using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool isInRange;
    [SerializeField] private UnityEvent interactAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(isInRange)
        {
            if(Keyboard.current.eKey.wasPressedThisFrame) // interact key
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            //Debug.Log("Player now in range of of an interactable object");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            GetComponentInParent<InteractableObject>().endInteraction();
            //Debug.Log("Player now not in range of an interactable object");
        }
    }
}
