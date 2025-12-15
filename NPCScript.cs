using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCScript : MonoBehaviour
{
    private CameraScript cameraScript;

    private GenerateDialog generateDialog_Script;
    private PlayerScript player_Script;


    // Start is called before the first frame update
    void Start()
    {
        GameObject generateDialog_GO = GameObject.Find("GenerateDialog");
        generateDialog_Script = generateDialog_GO.GetComponent<GenerateDialog>();

        GameObject player_GO = GameObject.Find("Player");
        player_Script = player_GO.GetComponent<PlayerScript>();

        //dialog = GameObject.Find("Text").GetComponent<TMP_Text>();
        //camera = GameObject.Find("CameraScript");
        cameraScript = GameObject.Find("CameraScript").GetComponent<CameraScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        cameraScript.NPCClicked();
        //cameraScript.NPCClicked();
        // perform some action when the object is clicked


        /*
        if (generateDialog_Script.dialogList_nonsense.Contains(this.gameObject.name))
        {
            for(int i)
            dialog.text 
        }*/

        generateDialog_Script.DialogName(this.gameObject.name);
        generateDialog_Script.Generate_Dialog(this.gameObject.name);
        
    }
}
