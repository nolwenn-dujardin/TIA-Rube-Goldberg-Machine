using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConveyorActivator : MonoBehaviour
{
    public UnityEvent activateBelt;

    private void OnTriggerEnter(Collider other) {
        if(GameManager.Manager.isStart && other.CompareTag("Player")){
            activateBelt.Invoke();
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
