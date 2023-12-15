using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    public float speedBoost = 2f; // Facteur d'acc�l�ration

    private bool hasBeenActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        // V�rifiez si l'objet a entr� en collision avec l'objet acc�l�rateur
        if (!hasBeenActivated && other.CompareTag("Player"))
        {
            // D�finir le d�clencheur comme activ�
            hasBeenActivated = true;

            // Acc�l�rez l'objet en ajustant sa vitesse
            Rigidbody rb = other.GetComponent<Rigidbody>();

            Debug.Log("Boost player before : " + rb.velocity);
            if (rb != null)
            {
                rb.velocity *= speedBoost;
            }
            Debug.Log("Boost player after : " + rb.velocity);

            Destroy(gameObject);
        }
    }
}

