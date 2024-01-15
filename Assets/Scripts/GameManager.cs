using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isStart = false;

    public GameObject parentGameObjectWithPhysic;
    public GameObject parcours;

    public GameObject menuUIEditObjectPos;

    public GameObject menuUIEnding;

    public GameObject menuUIStartReset;

    public static GameManager Manager;

    public GameObject selectedObject;

    public TMP_Text buttonRotPosText;

    public TMP_Text posOrRot;

    public TMP_Text timerText;

    public TMP_Text objectNbText;

    public bool objectIsSelect = false;

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

    public float Timer = 0f;

    public int nbObjectFixed = 0;

    public void Awake()
    {
        if(GameManager.Manager != null) { Destroy(this); }
        Manager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sliderX.minValue = sliderY.minValue = sliderZ.minValue = minPos;
        sliderX.maxValue = sliderY.maxValue = sliderZ.maxValue = maxPos;
        //initialPos = selectedObject.transform.localPosition;
        //initialRot = selectedObject.transform.localRotation.eulerAngles;

        posOrRot.text = "Position";
    }

    // Update is called once per frame
    void Update()
    {
        if(objectIsSelect){
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
        
        if(isStart){
            Timer += Time.deltaTime;
        }
    }

    public void Rotation(){
        if(objectIsSelect){
            rotate = !rotate;
            //sliderX.value = sliderY.value = sliderZ.value = 0;

            if(rotate){
                //Save object position
                initialPos = selectedObject.transform.localPosition;

                //Restore rotation
                selectedObject.transform.localRotation = Quaternion.Euler(initialRot);

                initForChangeRot();
            }
            else {
                //Save rotation
                initialRot = selectedObject.transform.localRotation.eulerAngles;

                //Restore object position
                selectedObject.transform.localPosition = initialPos;

                initForChangePos();
            }

            Debug.Log("Rotate is "+rotate);
        }
    }

    //Init slider value for allowing to change position of gameObject
    void initForChangePos(){
        sliderX.minValue = sliderY.minValue = sliderZ.minValue = minPos;
        sliderX.maxValue = sliderY.maxValue = sliderZ.maxValue = maxPos;
    
        sliderX.value = initialPos.x; 
        sliderY.value = initialPos.y; 
        sliderZ.value = initialPos.z;

        buttonRotPosText.text = "Rotate";
        posOrRot.text = "Position";
    }

    //Init slider value for allowing to change rotation of gameObject
    void initForChangeRot() {
        sliderX.minValue = sliderY.minValue = sliderZ.minValue = minRotate;
        sliderX.maxValue = sliderY.maxValue = sliderZ.maxValue = maxRotate;

        sliderX.value = initialRot.x;
        sliderY.value = initialRot.y;
        sliderZ.value = initialRot.z;

        buttonRotPosText.text = "Move";
        posOrRot.text = "Rotation";
    }

    public void SelectObject(GameObject newObject){
        selectedObject = newObject;
        initialPos = newObject.transform.localPosition;
        initialRot = newObject.transform.localRotation.eulerAngles;

        rotate = false;
        objectIsSelect = true;

        menuUIEditObjectPos.SetActive(true);

        initForChangePos();
    }

    public void unselectAndHide(){
        objectIsSelect = false;
        selectedObject = null;

        //hide UI
        menuUIEditObjectPos.SetActive(false);
    }

    public void fixToParcours() {
        selectedObject.transform.SetParent(parcours.transform);

        unselectAndHide();
        nbObjectFixed++;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game reset");
    }

    public void StartGame()
    {
        isStart = true;
        Transform[] children = parentGameObjectWithPhysic.GetComponentsInChildren<Transform>();

        if(children != null)
        {
            foreach(Transform child in children)
            {
                Rigidbody rb = child.GetComponent<Rigidbody>();
                if(rb != null){
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }
            }
        }
    }

    public void EndGame(){
        //TODO end timer display ending screen
        isStart = false;

        timerText.text = Timer.ToString();
        objectNbText.text = nbObjectFixed.ToString();

        menuUIStartReset.SetActive(false);
        menuUIEnding.SetActive(true);
    }
}
