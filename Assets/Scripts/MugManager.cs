using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MugManager : MonoBehaviour
{
    public Rigidbody MugBody;
    public Slider throwStrengthSlider;

    float startHold;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        handleClick();
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
            throwStrengthSlider.value = (Time.time - startHold)/2;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            float throwStrength = Mathf.Min((Time.time - startHold)/2, 1);
            Debug.Log(throwStrengthSlider.value);
            Debug.Log(throwStrength);
            MugBody.AddForce(Vector3.forward * 1000 * throwStrength);
        }
    }
}
