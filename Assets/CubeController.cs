using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
        private bool rotate = false;
        public Slider sliderX;
        public Slider sliderY;
        public Slider sliderZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate){
            transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        }

        transform.position = new Vector3(sliderX.value,sliderY.value, sliderZ.value);
    }

    public void Rotation(){
        rotate = !rotate;
    }
}
