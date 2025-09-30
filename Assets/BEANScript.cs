using UnityEngine;
using UnityEngine.InputSystem;
public class BEANScript : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction m_jump_Action;
    public float jumpForce;
    private Animator m_animator;
    private Rigidbody2D m_rigidbody2D;


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
        m_jump_Action = InputActions.FindActionMap("Player").FindAction("Jump");
        m_animator = GetComponent<Animator>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();

    }
    public InputActionAsset InputActions;
    void Start()
    {
    }
    public void Jump()
    {
        m_rigidbody2D.linearVelocity = Vector2.up * jumpForce;
        m_animator.SetTrigger("Jump");

    }
    // Update is called once per frame
    public void Update()
    {
        if (m_jump_Action.WasPressedThisFrame())
        {
            Jump();
        }


    }
}
