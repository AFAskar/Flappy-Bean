using UnityEngine;
using UnityEngine.InputSystem;
public class BEANScript : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    public float jumpForce = 5;
    private Animator m_animator;
    private LogicManagerScript logic;
    public InputActionAsset InputActions;
    private InputAction m_jump_Action;

    public bool isAlive = true;


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
        m_animator = GetComponent<Animator>();
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
        if (m_animator != null)
        {
            m_animator.SetTrigger("Jump");
        }

    }
    // Update is called once per frame
    private void Update()
    {
        if (m_jump_Action.WasPressedThisFrame() && isAlive)
        {
            Jump();
        }
        // Tilt the bean's tip based on vertical velocity
        if (m_rigidbody2D != null)
        {
            // the bean has been rotated 90 degrees on the z axis in the sprite editor 
            float angle = Mathf.Clamp(m_rigidbody2D.linearVelocityY * 10, -90, 45);
            angle = 90 + angle;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        // Check if the bean has fallen below camera view 
        if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - 1f && isAlive)
        {
            logic.gameOver();
            isAlive = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;
    }


}
