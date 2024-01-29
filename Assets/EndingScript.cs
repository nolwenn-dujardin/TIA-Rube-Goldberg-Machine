using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndingScript : MonoBehaviour
{
    public UnityEvent activateEnding;

    private void OnTriggerEnter(Collider other) {
        if(GameManager.Manager.isStart && other.CompareTag("Player")){
            activateEnding.Invoke();
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
