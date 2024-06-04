using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform target; // Objeto alrededor del cual la cámara girará
    public float rotationSpeed = 5.0f; // Velocidad de rotación de la cámara

    private Vector3 offset; // Distancia entre la cámara y el objeto

    void Start()
    {
        offset = transform.position - target.position; // Calcula la distancia inicial entre la cámara y el objeto
    }

    void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed; // Obtiene el movimiento horizontal del mouse
        target.Rotate(Vector3.up, horizontalInput); // Rota el objeto objetivo alrededor de su eje vertical

        Quaternion rotation = Quaternion.Euler(0, target.eulerAngles.y, 0); // Calcula la rotación de la cámara basada en la rotación del objeto
        transform.position = target.position - (rotation * offset); // Aplica la posición relativa de la cámara alrededor del objeto

        transform.LookAt(target); // Hace que la cámara siempre mire hacia el objeto
    }
}