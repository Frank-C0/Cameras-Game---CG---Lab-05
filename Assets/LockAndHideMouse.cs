using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAndHideMouse : MonoBehaviour
{
    void Start()
    {
        // Ocultar el cursor del mouse
        Cursor.visible = false;
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Presionar la tecla ESC para mostrar y liberar el cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}