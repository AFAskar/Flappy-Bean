using UnityEngine;

public class PiperSpawnerScript : MonoBehaviour
{
    public GameObject barratzaPrefab;
    public float spawnInterval = 2;
    private float timer = 0;

    public float heightOffset = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnBarratza();
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
            spawnBarratza();
            timer = 0f;
        }

    }

    void spawnBarratza()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float randomY = Random.Range(lowestPoint, highestPoint);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);
        Instantiate(barratzaPrefab, spawnPosition, transform.rotation);
    }


}
