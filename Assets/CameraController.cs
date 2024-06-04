using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public struct CameraObjects
{
    public GameObject[] cameraObjects;

}
public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }

    [SerializeField] private CameraObjects[] gameObjects;

    public int defaultCamera = 1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void EnableCamera(int cameraType)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (i != cameraType)
            {
                foreach (GameObject gameObject in gameObjects[i].cameraObjects)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        foreach (GameObject gameObject in gameObjects[cameraType].cameraObjects)
        {
            gameObject.SetActive(true);
        }
    }

    public void RestoreDefaultCamera()
    {
        EnableCamera(defaultCamera);
    }
}