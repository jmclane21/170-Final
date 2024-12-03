using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailTV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //auto fail when hit tv

        //spawn new customer and mug at end
        CustomerManager.Instance.spawnCustomer();
        MugManager.Instance.spawnMug();
    }
}
