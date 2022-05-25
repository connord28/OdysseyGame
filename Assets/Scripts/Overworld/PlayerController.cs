using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private PlayerControls playerControls;
   
    private InputAction move;
    private InputAction interact;

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
        //Vector2 pos = rigidbody2D.position;
        //pos.x = pos.x + speed * horizontal * Time.deltaTime;
        //pos.y = pos.y + speed * vertical * Time.deltaTime;

        //rigidbody2D.MovePosition(pos);

        Move();
    }

    private void GatherInput()
    {
        moveDirection = move.ReadValue<Vector2>();
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
