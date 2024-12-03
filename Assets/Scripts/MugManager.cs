using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MugManager : MonoBehaviour
{
    public static MugManager Instance;

    public Transform mugSpawn;
    public GameObject mugPrefab;
    GameObject currentMug;
    Rigidbody mugBody;
    public Slider throwStrengthSlider;

    float startHold;
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
        spawnMug();
    }

    // Update is called once per frame
    void Update()
    {
        handleClick();
        //unpair current mug and spawn next one when velocity = 0 OR falls off side?
    }

    void handleClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            throwStrengthSlider.value = 0;
            startHold = Time.time;
            
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            throwStrengthSlider.value = (Time.time - startHold)/2 + .5f;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            float throwStrength = Mathf.Min((Time.time - startHold)/2, 1f) +.5f;
            Debug.Log(throwStrength);
            mugBody.AddForce(Vector3.forward * -1750 * throwStrength);
            
        }
    }
    public void spawnMug()
    {
        Destroy(currentMug);
        currentMug = Instantiate(mugPrefab);
        currentMug.transform.position = mugSpawn.position;
        mugBody = currentMug.GetComponent<Rigidbody>();
    }
}
