using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Cinemachine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] Animator animator;

    // Camera settings



    private InputAction move;
    private InputAction interact;

    private Rigidbody2D rigidbody2D;

    private Vector2 moveDirection = Vector2.zero;

    private bool isXMoving = false;
    private bool isYMoving = false;

    [SerializeField] private InventorySystem currInventory;

    [SerializeField] private CinemachineVirtualCamera vCam;
    private CameraAdjust vCamSettings;

    private void Awake()
    {
        playerControls = new PlayerControls();
        //currInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventorySystem>();
        //vCam = GameObject.FindGameObjectWithTag("CM vCam").GetComponent<CinemachineVirtualCamera>();
        vCamSettings = vCam.GetComponent<CameraAdjust>();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        interact = playerControls.Player.Interact;
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
    }

    private void Move()
    {
        if(moveDirection.x != 0 && !isYMoving)
        {
            animator.SetBool("walking", true);
            rigidbody2D.velocity = new Vector2(moveDirection.x * moveSpeed, 0);
            animator.SetInteger("Direction", moveDirection.x > 0 ? 1 : 0);
            isXMoving = true;
            isYMoving = false;
        } else if(moveDirection.y != 0 && !isXMoving)
        {
            animator.SetBool("walking", true);
            rigidbody2D.velocity = new Vector2(0, moveDirection.y * moveSpeed);
            animator.SetInteger("Direction", moveDirection.y > 0 ? 2 : 3);
            isXMoving = false;
            isYMoving = true;
        } else
        {
            animator.SetBool("walking", false);
            rigidbody2D.velocity = Vector2.zero;
            isXMoving = false;
            isYMoving = false;
        }
        
    }

    private void Interact(InputAction.CallbackContext context)
    {
        //Didn't use
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MazeStart"))
        {
            //vCam.m_Lens.OrthographicSize = vCamSettings.getMazeOrthoSize();
            StartCoroutine(zoomIn());
            vCam.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = vCamSettings.getMazeXDamping(); ;
            vCam.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = vCamSettings.getMazeYDamping(); ;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MazeStart"))
        {
            //vCam.m_Lens.OrthographicSize = vCamSettings.getRegOrthoSize();
            StartCoroutine(zoomOut());
            vCam.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = vCamSettings.getRegXDamping(); ;
            vCam.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = vCamSettings.getRegYDamping(); ;
        }
    }

    public bool hasItem(InventoryItemData refData)
    {
        if(currInventory.Get(refData) != null)
        {
            return true;
        } else
        {
            return false;
        }
    }

    IEnumerator zoomIn()
    {
        while (vCam.m_Lens.OrthographicSize > vCamSettings.getMazeOrthoSize())
        {
            float orthoSize = vCam.m_Lens.OrthographicSize - (vCamSettings.getZoomSpeed() * Time.deltaTime);
            vCam.m_Lens.OrthographicSize = orthoSize;

            yield return null;
        }

        vCam.m_Lens.OrthographicSize = vCamSettings.getMazeOrthoSize();
    }

    IEnumerator zoomOut()
    {
        while (vCam.m_Lens.OrthographicSize < vCamSettings.getRegOrthoSize())
        {
            float orthoSize = vCam.m_Lens.OrthographicSize + (vCamSettings.getZoomSpeed() * Time.deltaTime);
            vCam.m_Lens.OrthographicSize = orthoSize;

            yield return null;
        }

        vCam.m_Lens.OrthographicSize = vCamSettings.getRegOrthoSize();
    }
}
