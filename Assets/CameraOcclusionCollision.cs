using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraOcclusionCollision : MonoBehaviour
{
    public Transform target;
    private Vector3 initialPosition;
    private float distance = 10f;
    public GameObject realPosition;
    private Transform realPositionTransform;
    private MoveTowardsObject realPositionMoveTowardsObject;
    public float sphereRadius = 0.5f;
    public bool isOnMaxOcclusion = false;

    public LayerMask layerMaskOcclusion;


    void Start()
    {
        initialPosition = transform.localPosition;
        Vector3 direction = transform.position - target.position;
        distance = direction.magnitude;
        realPositionTransform = realPosition.transform;
        realPositionMoveTowardsObject = realPosition.GetComponent<MoveTowardsObject>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 offset = new Vector3(0, 0.5f, 0);
        Vector3 directionSphere = transform.position - target.position;

        // Create a sphere cast from the target to the camera
        RaycastHit hitSphere;

        

        if (Physics.SphereCast(target.position, sphereRadius, directionSphere, out hitSphere, distance + 1f, layerMaskOcclusion))
        {
            Debug.Log("Object between the camera and the player");

            if (hitSphere.distance > 1.0f)
            {
                isOnMaxOcclusion = false;
                realPositionMoveTowardsObject.follow = true;
                // Move the camera to the collision point
                Vector3 centerOnCollision = SphereOrCapsuleCastCenterOnCollision(
                    target.position, 
                    directionSphere, 
                    hitSphere.distance);
                transform.position = centerOnCollision;
                // realPositionTransform.position = hitSphere.point + hitSphere.normal * 0.5f;
                realPositionTransform.position = centerOnCollision;
                
            }
            else
            {
                realPositionMoveTowardsObject.follow = false;
                isOnMaxOcclusion = true;
            }
        }
        else
        {
            realPositionMoveTowardsObject.follow = true;
            // Debug.Log("No objects between the camera and the player");
            // If there is no collision, keep the camera in its initial position
            transform.localPosition = initialPosition;
            isOnMaxOcclusion = false;
        }
    }

    public static Vector3 SphereOrCapsuleCastCenterOnCollision(Vector3 origin, Vector3 directionCast, float hitInfoDistance)
    {
        return origin + (directionCast.normalized * hitInfoDistance);
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(target.position, transform.position);
    //}
}