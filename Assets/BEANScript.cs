using UnityEngine;
using UnityEngine.InputSystem;
public class BEANScript : MonoBehaviour
{
    public AudioSource CollisionSound;
    private Rigidbody2D m_rigidbody2D;
    public float jumpForce = 5;
    private LogicManagerScript logic;
    public InputActionAsset InputActions;
    private InputAction m_jump_Action;

    public bool isAlive = true;

    // Rotation easing variables
    public float rotationSpeed = 5f; // How fast the rotation changes
    private float currentRotation = 90f; // Current rotation angle


    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        m_jump_Action = InputSystem.actions.FindAction("Jump");
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        if (m_rigidbody2D == null)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }


    }
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }
    public void Jump()
    {
        m_rigidbody2D.linearVelocity = Vector2.up * jumpForce;

    }
    // Update is called once per frame
    private void Update()
    {
        if (isAlive == false)
        {
            logic.gameOver();
            return;
        }
        if (m_jump_Action.WasPressedThisFrame() && isAlive)
        {
            Jump();
        }
        // Tilt the bean's tip based on vertical velocity with smooth easing
        if (m_rigidbody2D != null)
        {
            // Calculate target rotation based on velocity
            float targetAngle = Mathf.Clamp(m_rigidbody2D.linearVelocityY * 10, -90, 45);
            targetAngle = 90 + targetAngle;

            // Smoothly interpolate to target rotation
            currentRotation = Mathf.LerpAngle(currentRotation, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }

        // Check if the bean has fallen below camera view 
        if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - 1f && isAlive)
        {
            isAlive = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionSound.Play();
        isAlive = false;
    }


}
