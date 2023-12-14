using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private void OnMouseDown() {
        Debug.Log("Click on cube");
        if (GameManager.Manager != null)
        {
            GameManager.Manager.SelectObject(gameObject);
        }
        else
        {
            Debug.LogWarning("GameManager.Manager is null!");
        }
    }
}
