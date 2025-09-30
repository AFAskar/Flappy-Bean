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
