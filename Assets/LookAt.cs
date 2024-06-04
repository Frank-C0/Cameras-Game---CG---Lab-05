using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform objetoAseguir;
    public float distancia = 5.0f;
    public Vector3 offset;

    void Update()
    {
        // Calculamos la posición a la que queremos que la cámara se dirija
        Vector3 posicionDeseada = objetoAseguir.position + offset.normalized * distancia;

        // Movemos la cámara hacia la posición deseada
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime);

        // Hacemos que la cámara mire hacia el objeto que estamos siguiendo
        transform.LookAt(objetoAseguir);
    }
}