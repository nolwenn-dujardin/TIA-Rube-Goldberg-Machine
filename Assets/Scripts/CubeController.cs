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

        public Vector3 initialPos;

        public int minPos = -1;
        public int maxPos = 1;

        public int minRotate = 0;
        public int maxRotate = 360;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate){
            var rot = transform.localRotation.eulerAngles;
            rot.Set(sliderX.value,
            sliderY.value, 
            sliderZ.value);

            transform.localRotation = Quaternion.Euler(rot);
        }
        else {
           transform.position = initialPos + new Vector3(sliderX.value,
            sliderY.value, 
            sliderZ.value); 
        }
    }

    public void Rotation(){
        rotate = !rotate;
        sliderX.value = sliderY.value = sliderZ.value = 0;

        if(rotate){
            sliderX.minValue = sliderY.minValue = sliderZ.minValue = minRotate;
            sliderX.maxValue = sliderY.maxValue = sliderZ.maxValue = maxRotate;

        }
        else {
            sliderX.minValue = sliderY.minValue = sliderZ.minValue = minPos;
            sliderX.maxValue = sliderY.maxValue = sliderZ.maxValue = maxPos;
        }
    }
}
