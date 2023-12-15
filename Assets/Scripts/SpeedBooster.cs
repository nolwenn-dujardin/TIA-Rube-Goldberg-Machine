using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    public float speedBoost = 2f; // Facteur d'accélération

    private bool hasBeenActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        // Vérifiez si l'objet a entré en collision avec l'objet accélérateur
        if (!hasBeenActivated && other.CompareTag("Player"))
        {
            // Définir le déclencheur comme activé
            hasBeenActivated = true;

            // Accélérez l'objet en ajustant sa vitesse
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

