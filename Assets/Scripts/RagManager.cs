using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagManager : MonoBehaviour
{
    public Transform RagBody;

    public float speed = 100f;

    private Vector3 initialMousePos;
    private float initialRigidbodyPosZ;
    private float initialRigidbodyPosX;

    void Start()
    {
        initialRigidbodyPosZ = RagBody.position.z;
        initialRigidbodyPosX = RagBody.position.x;
        initialMousePos = Input.mousePosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            initialRigidbodyPosZ = RagBody.position.z;
            initialMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            float mouseDeltaX = initialMousePos.x - Input.mousePosition.x;
            float mouseDeltaY = Input.mousePosition.y - initialMousePos.y;
            
            float newZPosition = initialRigidbodyPosZ + (mouseDeltaX * speed);
            float newXPosition = initialRigidbodyPosX + (mouseDeltaY * speed);

            if (newZPosition >= initialRigidbodyPosZ + 50f) {
                newZPosition = initialRigidbodyPosZ + 50f;
            }

            if (newZPosition <= initialRigidbodyPosZ - 50f) {
                newZPosition = initialRigidbodyPosZ - 50f;
            }

            if (newXPosition >= initialRigidbodyPosX + 10f)
            {
                newXPosition = initialRigidbodyPosX + 10f;
            }

            if (newXPosition <= initialRigidbodyPosX- 10f)
            {
                newXPosition = initialRigidbodyPosX - 10f;
            }

            RagBody.position = (new Vector3(newXPosition, RagBody.position.y, newZPosition));
        }
    }
}
