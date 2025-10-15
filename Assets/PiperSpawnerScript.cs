using UnityEngine;

public class PiperSpawnerScript : MonoBehaviour
{
    public GameObject PipePrefab;
    public float spawnInterval = 2;
    private float timer = 0;

    public float heightOffset = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipe();
        // set spawn interval based on difficulty easy,medium,hard
        int difficulty = PlayerPrefs.GetInt("Difficulty");
        switch (difficulty)
        {
            case 0: // Easy
                spawnInterval = 3;
                heightOffset = 5;
                break;
            case 1: // Medium
                spawnInterval = 2;
                heightOffset = 4;
                break;
            case 2: // Hard
                spawnInterval = 1;
                heightOffset = 3;
                break;
            default:
                spawnInterval = 2;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnInterval)
        {
            timer += Time.deltaTime;
            return;
        }
        else
        {
            spawnPipe();
            timer = 0f;
        }

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float randomY = Random.Range(lowestPoint, highestPoint);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);
        Instantiate(PipePrefab, spawnPosition, PipePrefab.transform.rotation);
    }


}
