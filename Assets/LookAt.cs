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
        // Calculamos la posici�n a la que queremos que la c�mara se dirija
        Vector3 posicionDeseada = objetoAseguir.position + offset.normalized * distancia;

        // Movemos la c�mara hacia la posici�n deseada
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime);

        // Hacemos que la c�mara mire hacia el objeto que estamos siguiendo
        transform.LookAt(objetoAseguir);
    }
}