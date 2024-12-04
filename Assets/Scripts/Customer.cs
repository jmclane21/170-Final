using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
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
        ////determine success of throw
        //Debug.Log(collision.relativeVelocity.magnitude);
        ////magic number is the amount of force the mug can hit the customer with
        //if (collision.relativeVelocity.magnitude < 17)
        //{
        //    Debug.Log("succeed");
        //}
        //collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, collision.gameObject.transform.position, .3f); ;

        //spawn new customer and mug at end
        //CustomerManager.Instance.spawnCustomer();
        //MugManager.Instance.spawnMug();
    }

    private void OnTriggerStay(Collider other) {
        //determine success of throw
        if (other.gameObject.GetComponent<Rigidbody>().IsSleeping()) {
            Debug.Log("succeed");

            //spawn new customer and mug at end
            CustomerManager.Instance.spawnCustomer();
            MugManager.Instance.spawnMug();
        }
    }
}
