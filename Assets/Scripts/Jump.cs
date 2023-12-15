using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
