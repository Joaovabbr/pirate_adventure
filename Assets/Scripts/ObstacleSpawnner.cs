using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ObstacleSpawnner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 3.0f;
    public float minX, maxX, minY, maxY;
    private List<GameObject> activeObstacles = new List<GameObject>();
    private int spawnCounter = 0;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1.0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        if (GameController.GameOver) return;

        Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);


        activeObstacles.Add(newObstacle);
        spawnCounter++;

        if (spawnCounter >= 4)
        {
            RemoveRandomObstacle();
            spawnCounter = 0;
        }
    }

    void RemoveRandomObstacle()
    {
        activeObstacles.RemoveAll(item => item.IsUnityNull());

        if (activeObstacles.Count > 0)
        {
            int randomIndex = Random.Range(0, activeObstacles.Count);

            Destroy(activeObstacles[randomIndex]);
            activeObstacles.RemoveAt(randomIndex);
            Debug.Log("5 obstáculos criados: Um foi removido aleatoriamente!");
        }
    }
}
