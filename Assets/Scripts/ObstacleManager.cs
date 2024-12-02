using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    private int obstacles_spawned;
    private int obstacles_deactivated;

    public static ObstacleManager Instance;
    public List<GameObject> pooledObstacles;
    public GameObject obstacleBlueprint;
    public int amountToPool;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObstacles = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(obstacleBlueprint);
            tmp.SetActive(false);
            pooledObstacles.Add(tmp);
        }
    }

    void Update()
    {
        if (obstacles_spawned < 3)
        {
            obstacles_spawned = 0;
            obstacles_deactivated = 0;
            StartCoroutine(SpawnObstacle());
        }
    }

    public void deactivateObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        obstacles_deactivated++;
    }

    public void deactivateAll()
    {
        for (int i = 0; i < pooledObstacles.Count; i++)
        {
            pooledObstacles[i].SetActive(false);
        }
    }

    public GameObject GetPooledObstacle()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObstacles[i].activeInHierarchy)
            {
                return pooledObstacles[i];
            }
        }
        return null;
    }

    public IEnumerator SpawnObstacle()
    {
        while (obstacles_spawned < amountToPool)
        {
            int whichSpawn = Random.Range(0, spawnPoints.Length);
            Transform spawn_point = spawnPoints[whichSpawn];
            obstacles_spawned++;

            GameObject obstacle = GetPooledObstacle();
            if (obstacle != null)
            {
                obstacle.transform.position = spawn_point.transform.position;
                obstacle.SetActive(true);
            }
            yield return new WaitForSeconds(1.5f);
        }

    }
}
