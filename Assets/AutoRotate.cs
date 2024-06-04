using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidad de rotación en grados por segundo
    public bool rotateAroundX = false;
    public bool rotateAroundY = true;
    public bool rotateAroundZ = false;

    void Update()
    {
        float rotationAngle = rotationSpeed * Time.deltaTime;

        if (rotateAroundX)
        {
            transform.Rotate(Vector3.right, rotationAngle);
        }
        if (rotateAroundY)
        {
            transform.Rotate(Vector3.up, rotationAngle);
        }
        if (rotateAroundZ)
        {
            transform.Rotate(Vector3.forward, rotationAngle);
        }
    }
}