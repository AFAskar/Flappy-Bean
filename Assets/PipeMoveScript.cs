using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    float deadzone = -15;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    }
}
