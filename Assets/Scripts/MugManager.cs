using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MugManager : MonoBehaviour
{
    public Rigidbody MugBody;

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
            Debug.Log("applying force");
            MugBody.AddForce(Vector3.forward * 1000f);
        }
    }
}
