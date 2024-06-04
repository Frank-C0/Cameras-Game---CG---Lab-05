using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    public Transform target; // Objeto cuya rotaci�n se copiar�
    public bool copyX = true; // Copiar rotaci�n en el eje X
    public bool copyY = true; // Copiar rotaci�n en el eje Y
    public bool copyZ = true; // Copiar rotaci�n en el eje Z

    void Update()
    {
        if (target != null)
        {
            Vector3 newRotation = target.rotation.eulerAngles;
            Vector3 targetRotation = transform.rotation.eulerAngles;

            if (copyX)
            {
                newRotation.x = targetRotation.x;
            }
            if (copyY)
            {
                newRotation.y = targetRotation.y;
            }
            if (copyZ)
            {
                newRotation.z = targetRotation.z;
            }

            target.rotation = Quaternion.Euler(newRotation);
        }
    }
}