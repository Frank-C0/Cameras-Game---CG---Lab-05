using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActivateTextOnTrigger : MonoBehaviour
{
    public TextMeshProUGUI textToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textToActivate.gameObject.SetActive(true);
        }
    }
}