using UnityEngine;

public class BarratzaMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    float deadzone = -10;
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
