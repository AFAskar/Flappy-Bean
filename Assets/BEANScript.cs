using UnityEngine;
using UnityEngine.InputSystem;
public class BEANScript : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction m_jump_Action;
    public float jumpForce = 5;
    private Animator m_animator;
    private Rigidbody2D m_rigidbody2D;
    private LogicManagerScript logic;
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


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;

    }
}
