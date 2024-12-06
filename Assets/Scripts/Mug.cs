using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Mug : MonoBehaviour
{
    [SerializeField] AudioClip clinkSound;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("clink");
        AudioManager.Instance.playSound(clinkSound);
    }
}
