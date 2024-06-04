using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{
    [SerializeField] private int cameraType = 0; // El tipo de cámara a activar al entrar en el trigger

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Change camera "+other.tag);
        if (other.CompareTag("Player")) 
        {
            CameraController.Instance.EnableCamera(cameraType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Change camera " + other.tag);
        if (other.CompareTag("Player")) 
        {
            // Cuando salimos del trigger, restauramos la cámara por defecto
            CameraController.Instance.RestoreDefaultCamera();
        }
    }
}