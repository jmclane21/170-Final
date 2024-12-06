using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] AudioClip successSound;


    //private void OnCollisionEnter(Collision collision)
    //{
    //    //launch the mug?
    //    collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, collision.gameObject.transform.position, .3f);
    //}

    private void OnTriggerStay(Collider other) {
        //determine success of throw
        if (other.gameObject.GetComponent<Rigidbody>().IsSleeping()) {
            Debug.Log("succeed");

            AudioManager.Instance.playSound(successSound);
            //spawn new customer and mug at end
            CustomerManager.Instance.spawnCustomer();
            MugManager.Instance.spawnMug();
        }
    }
}
