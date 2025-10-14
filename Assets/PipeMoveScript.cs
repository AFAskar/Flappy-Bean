using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    float deadzone = -15;
    void Start()
    {
        // change move speed based on difficuilty easy,medium,hard
        int difficulty = PlayerPrefs.GetInt("Difficulty");
        switch (difficulty)
        {
            case 0: // Easy
                moveSpeed = 3;
                break;
            case 1: // Medium
                moveSpeed = 5;
                break;
            case 2: // Hard
                moveSpeed = 8.5f;
                break;
            default:
                moveSpeed = 5;
                break;

        }


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
