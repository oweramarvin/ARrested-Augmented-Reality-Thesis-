using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsScript : MonoBehaviour
{
    public string thingsRole;
    private CameraScript cameraScript;
    private FindObject findObject_Script;

    //private GameObject thingsLight;
    Quaternion pos;

    Vector3 startPoint;

    float displayTime = 1f;
    bool isClicked;

    void Start()
    {
        cameraScript = GameObject.Find("CameraScript").GetComponent<CameraScript>();
        findObject_Script = GameObject.Find("Find Object").GetComponent<FindObject>();
        //thingsLight = GameObject.Find("ThingsLight");
        isClicked = false;

      
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            displayTime -= Time.deltaTime;

            if (displayTime < 0)
            {

                displayTime = 1f;
                isClicked = false;
                Destroy(this.gameObject);

            }
        }

    }

    void OnMouseDown()
    {
        if (isClicked == false)
        {
            cameraScript.ThingsClicked();

            //thingsLight.transform.position = this.transform.position;

            findObject_Script.ThingsClicked(this.gameObject.name);

            this.transform.localScale *= 2;

            isClicked = true;

            if (this.transform.position.x < -40f)
            {
                transform.position = new Vector3(-53.75f, -27.1f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(-29.75f, -27.1f, transform.position.z);
            }
        }
        

        
    }

}
