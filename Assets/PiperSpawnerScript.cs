using UnityEngine;

public class PiperSpawnerScript : MonoBehaviour
{
    public GameObject PipePrefab;
    public GameObject CoinPrefab; // Prefab for the coin
    public float spawnInterval = 2;
    public float coinSpawnChance = 1f; // 100% chance to spawn a coin
    private float timer = 0;

    public float heightOffset = 2.25f;

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
        // Spawn the pipe
        GameObject spawnedPipe = Instantiate(PipePrefab, spawnPosition, PipePrefab.transform.rotation);

        if (CoinPrefab == null)
        {
            Debug.LogError("CoinPrefab is not assigned in PiperSpawnerScript.");
            return;
        }
        // Determine random Y position for the coin within the pipe gap with a buffer
        float buffer = 1.5f; // Adjust this value to increase the gap
        float coinRandomY = Random.Range(lowestPoint + buffer, highestPoint - buffer);

        float coinRandomChance = Random.Range(0f, 1f);
        //  decide whether to spawn a coin
        if (coinRandomChance <= coinSpawnChance)
        {
            // Spawn the coin as a child of the pipe
            Vector3 coinPosition = new Vector3(spawnPosition.x, coinRandomY, 0.5f); // Set Z position to 0.5
            GameObject spawnedCoin = Instantiate(CoinPrefab, coinPosition, Quaternion.identity);
            spawnedCoin.transform.parent = spawnedPipe.transform; // Make the coin a child of the pipe
        }
    }


}
