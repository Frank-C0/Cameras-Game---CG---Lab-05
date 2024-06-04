using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct copyObjectRotation
{
    public Transform target;
    public bool copyX;
    public bool copyY;
    public bool copyZ;
}

public class RotateWithMouse : MonoBehaviour
{
    
    public float rotationSpeed = 100.0f; // Velocidad de rotación
    private float yaw = 0.0f; // Rotación en el eje Y (izquierda-derecha)
    private float pitch = 0.0f; // Rotación en el eje X (arriba-abajo)
    public CameraOcclusionCollision cameraOcclusionCollision;
    [SerializeField] public copyObjectRotation[] copyObjectRotations;

    void Update()
    {
        
        // Obtener el desplazamiento del mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Ajustar la rotación del objeto según el movimiento del mouse
        yaw += mouseX * rotationSpeed * Time.deltaTime;
        pitch -= mouseY * rotationSpeed * Time.deltaTime;


        Vector3 newObjectRotation = new Vector3(pitch, yaw, 0.0f);
        transform.eulerAngles = newObjectRotation;


        if (cameraOcclusionCollision.isOnMaxOcclusion)
        {
            Debug.Log("Occlusion");
            return;
        }
        foreach (copyObjectRotation copyObjectRotation in copyObjectRotations)
        {
            Vector3 newTargetrotarion = new Vector3(
            copyObjectRotation.copyX ? pitch : copyObjectRotation.target.rotation.eulerAngles.x,
            copyObjectRotation.copyY ? yaw : copyObjectRotation.target.rotation.eulerAngles.y,
            copyObjectRotation.copyZ ? 0.0f : copyObjectRotation.target.rotation.eulerAngles.z);
            copyObjectRotation.target.eulerAngles = newTargetrotarion;
        }
    }
}