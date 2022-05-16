using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    private Vector3 offset;
    private Quaternion rotationOffset;
    private float damping = 4;

    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - character.position;
    }

    // Update is called once per frame
    void Update()
    {
        // slowly rotate the angle of the view
        float currentAngle = this.transform.eulerAngles.y;
        float desiredAngle = character.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        // transform the location of the camera to match the rotated view
        rotationOffset = Quaternion.Euler(10, angle, 0);
        this.transform.position = character.position + (rotationOffset * offset);

        // raise the camera 1.5
        Vector3 up = new Vector3(0, (float)1.5, 0);
        this.transform.LookAt(character.position + up);
    }
}
