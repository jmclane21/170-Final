using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagManager : MonoBehaviour
{
    public Rigidbody RagBody;

    public float speed = .1f;

    private Vector3 initialMousePos;
    private float initialRigidbodyPos;

    void Start()
    {
        initialRigidbodyPos = RagBody.position.x;
        initialMousePos = Input.mousePosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            initialRigidbodyPos = RagBody.position.x;
            initialMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            float mouseDeltaX = Input.mousePosition.x - initialMousePos.x;

            float newXPosition = initialRigidbodyPos + (mouseDeltaX * Time.deltaTime * speed);

            if (newXPosition >= initialRigidbodyPos + .5f) {
                newXPosition = initialRigidbodyPos + .5f;
            }

            if (newXPosition <= initialRigidbodyPos - .5f) {
                newXPosition = initialRigidbodyPos - .5f;
            }

            RagBody.MovePosition(new Vector3(newXPosition, RagBody.position.y, RagBody.position.z));
        }
    }
}
