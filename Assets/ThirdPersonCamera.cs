using UnityEngine;
using Cinemachine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float collisionRadius = 0.2f;
    public LayerMask collisionLayer;

    private Transform cameraTransform;
    private CinemachineFreeLook freeLookCamera;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        freeLookCamera = FindObjectOfType<CinemachineFreeLook>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 dirToCamera = cameraTransform.position - transform.position;

        if (Physics.SphereCast(transform.position, collisionRadius, dirToCamera, out hit, dirToCamera.magnitude, collisionLayer))
        {
            freeLookCamera.m_YAxis.Value += hit.normal.y * Time.deltaTime; // Ajusta la altura de la cámara para evitar colisiones con el suelo
            freeLookCamera.m_XAxis.Value += hit.normal.x * Time.deltaTime; // Ajusta la rotación horizontal de la cámara
        }
    }
}