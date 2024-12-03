using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;

    public GameObject handPrefab;
    GameObject currentHand;

    public Transform[] spawnPoints;
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
        currentHand = Instantiate(handPrefab);
        currentHand.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            spawnCustomer();
        }
    }
    public void spawnCustomer() {
        Destroy(currentHand);
        currentHand = Instantiate(handPrefab);
        currentHand.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }
}
