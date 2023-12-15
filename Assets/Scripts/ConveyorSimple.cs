using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSimple : MonoBehaviour
{
    public float speed = 10;
    Rigidbody rBody;
    
    public bool activate = false;

    Material objectMaterial;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        objectMaterial = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {
        if(activate){
            Vector3 pos = rBody.position;
            rBody.position += -transform.forward * speed * Time.fixedDeltaTime;
            rBody.MovePosition(pos);
        }
    }

    public void activateConveyor()
    {
        activate = true;
        objectMaterial.SetFloat("_ScrollSpeed",1);
    }
}
