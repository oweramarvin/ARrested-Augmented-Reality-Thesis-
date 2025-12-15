using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorScript : MonoBehaviour
{
    public TMP_Text textInstruction;
    private CameraScript cameraScript;
    float timer = 5f;
    bool isDoorClicked;

    // Start is called before the first frame update
    void Start()
    {
        cameraScript = GameObject.Find("CameraScript").GetComponent<CameraScript>();
        timer = 4f;
        isDoorClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorClicked && timer > 0)
        {
            timer -= Time.deltaTime;
            textInstruction.text = "Move the light buld to find objects, Tap the object to collect";
            if (timer <= 0)
            {
                isDoorClicked = false;
                textInstruction.text = "";
            }
        }
    }

    void OnMouseDown()
    {
        //thingsLight.transform.position = this.transform.position;

        if (this.gameObject.name == "Door Portal 1")
        {
            isDoorClicked = true;
            cameraScript.Door1();
            //transform.position = new Vector3(-53.75f, -27.1f, transform.position.z);
        }
        else if(this.gameObject.name == "Door Portal 2")
        {
            isDoorClicked = true;
            cameraScript.Door2();
        }
        else if(this.gameObject.name == "Police Portal")
        {
            cameraScript.InsidePolice();
            //policeDialog.SetActive(true);
        }


        //cameraScript.NPCClicked();+
        // perform some action when the object is clicked


        /*
        if (generateDialog_Script.dialogList_nonsense.Contains(this.gameObject.name))
        {
            for(int i)
            dialog.text 
        }*/


    }
}
