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
    bool mugThrown;
    public Slider throwStrengthSlider;

    [SerializeField] AudioClip failSound;

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
        mugThrown = false;
        spawnMug();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mugThrown) {
            handleClick();
        }
        else
        {
            checkAtRest();
        }
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
            throwStrengthSlider.value = (Time.time - startHold)/3 + .25f;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            float throwStrength = Mathf.Min((Time.time - startHold)/3, 1f) +.25f;
            mugBody.AddForce(Vector3.forward * -2750 * throwStrength);
            mugThrown = true;
        }
    }
    public void spawnMug()
    {
        throwStrengthSlider.value = 0;
        Destroy(currentMug);
        currentMug = Instantiate(mugPrefab);
        currentMug.transform.position = mugSpawn.position;
        mugBody = currentMug.GetComponent<Rigidbody>();
        mugThrown = false;
    }

    void checkAtRest()
    {
        if (mugBody.IsSleeping())
        {
            Debug.Log("under/overthrow, try again");
            AudioManager.Instance.playSound(failSound);
            spawnMug();
        }
    }
}
