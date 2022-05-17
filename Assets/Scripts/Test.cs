using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] Animator animator;

    private InputAction move;
    private InputAction interact;
    private int currDir;

    private Rigidbody2D rigidbody2D;

    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        interact = playerControls.Player.Fire;
        interact.Enable();
        interact.performed += Interact;
    }

    private void OnDisable()
    {
        move.Disable();

        interact.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        moveDirection = move.ReadValue<Vector2>();
        if(moveDirection.magnitude > 0)
        {
            Debug.Log("test");
            animator.SetBool("walking", true);
            switch (currDir)
            {
                case 0:
                case 1:
                    if (moveDirection.y != 0)
                    {
                        animator.SetInteger("Direction", moveDirection.y > 0 ? 2 : 3);
                        currDir = 2;
                        Debug.Log("test2");
                    }
                    else if (moveDirection.x != 0)
                    {
                        animator.SetInteger("Direction", moveDirection.x > 0 ? 1 : 0);
                        Debug.Log("test3");
                        currDir = 1;
                    }
                    break;
                case 2:
                    if (moveDirection.x != 0)
                    {
                        animator.SetInteger("Direction", moveDirection.x > 0 ? 1 : 0);
                        Debug.Log("test4");
                        currDir = 1;
                    }
                    else if (moveDirection.y != 0)
                    {
                        animator.SetInteger("Direction", moveDirection.y > 0 ? 2 : 3);
                        Debug.Log("test5");
                        currDir = 2;
                    }
                    break;
            }
        }
        else
        {
            animator.SetBool("walking", false);
            currDir = 0;
        }

    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Interact(InputAction.CallbackContext context)
    {
        //Interact logic
        Debug.Log("Tried to interact");
    }
}
