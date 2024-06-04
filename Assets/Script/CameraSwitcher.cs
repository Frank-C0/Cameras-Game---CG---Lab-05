using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    void Start()
    {
        // Desactiva todas las cámaras excepto la primera
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            currentCameraIndex = 0;
        }
    }

    void Update()
    {
        // Cambiar de cámara con la tecla C (puedes cambiar la tecla según tu preferencia)
        if (Input.GetKeyDown(KeyCode.K))
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0;
            }

            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].gameObject.SetActive(i == currentCameraIndex);
            }
        }
    }
}

