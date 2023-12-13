using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

    public GameObject selectedObject;

    private bool rotate = false;
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    public Vector3 initialPos;
    public Vector3 initialRot;

    public int minPos = -1;
    public int maxPos = 1;

    public int minRotate = 0;
    public int maxRotate = 360;


    // Start is called before the first frame update
    void Start()
    {
        sliderX.minValue = sliderY.minValue = sliderZ.minValue = minPos;
        sliderX.maxValue = sliderY.maxValue = sliderZ.maxValue = maxPos;
        initialPos = selectedObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate){
            var rot = selectedObject.transform.localRotation.eulerAngles;
            rot.Set(sliderX.value,
            sliderY.value, 
            sliderZ.value);

            selectedObject.transform.localRotation = Quaternion.Euler(rot);
        }
        else {
            /*Work if object pos is (0,0,0) -> in other case, 
            modify min and max value of slider for position to be (initialPos-minValue,initialPos+maxValue)
           */
           selectedObject.transform.localPosition = new Vector3(sliderX.value,
            sliderY.value, 
            sliderZ.value); 
        }
    }

    //TODO Save rotation value

    public void Rotation(){
        rotate = !rotate;
        //sliderX.value = sliderY.value = sliderZ.value = 0;

        if(rotate){
            //Save object position
            initialPos = selectedObject.transform.localPosition;

            sliderX.minValue = sliderY.minValue = sliderZ.minValue = minRotate;
            sliderX.maxValue = sliderY.maxValue = sliderZ.maxValue = maxRotate;

            sliderX.value = sliderY.value = sliderZ.value = 0;
        }
        else {
            //Restore object position
            selectedObject.transform.localPosition = initialPos;

            sliderX.minValue = sliderY.minValue = sliderZ.minValue = minPos;
            sliderX.maxValue = sliderY.maxValue = sliderZ.maxValue = maxPos;
            
            sliderX.value = initialPos.x; 
            sliderY.value = initialPos.y; 
            sliderZ.value = initialPos.z;
        }

        Debug.Log("Rotate is "+rotate);
    }

    public void SelectObject(GameObject newObject){
        selectedObject = newObject;
    }
}
