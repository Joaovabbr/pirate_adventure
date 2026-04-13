using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2.0f;
    
    public float minX, maxX, minY, maxY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnCoin", 2.0f, spawnInterval);
    }

    void SpawnCoin()
    {
        if (!GameController.GameOver)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPos = new Vector2(randomX, randomY);

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
}
