using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform target; // Objeto alrededor del cual la c�mara girar�
    public float rotationSpeed = 5.0f; // Velocidad de rotaci�n de la c�mara

    private Vector3 offset; // Distancia entre la c�mara y el objeto

    void Start()
    {
        offset = transform.position - target.position; // Calcula la distancia inicial entre la c�mara y el objeto
    }

    void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed; // Obtiene el movimiento horizontal del mouse
        target.Rotate(Vector3.up, horizontalInput); // Rota el objeto objetivo alrededor de su eje vertical

        Quaternion rotation = Quaternion.Euler(0, target.eulerAngles.y, 0); // Calcula la rotaci�n de la c�mara basada en la rotaci�n del objeto
        transform.position = target.position - (rotation * offset); // Aplica la posici�n relativa de la c�mara alrededor del objeto

        transform.LookAt(target); // Hace que la c�mara siempre mire hacia el objeto
    }
}