using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerScript : MonoBehaviour
{
    // Script
    public TMP_Text textInstruction;
    private GameObject cameraGO;
    private CameraScript cameraScript;
    
    private GenerateDialog generateDialog_Script;

    public GameObject dialogBox_GO;

    public GameObject GenerateNPC_GO;
    private GenerateNPC GenerateNPC_Script;

    public float speed;

    public FloatingJoystick joystick;
    public Rigidbody2D rb;
    bool facingRight = true;

    public float horizontal;
    public float vertical;

    public bool isTriggered;

    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;

        GameObject generateDialog_GO = GameObject.Find("GenerateDialog");
        generateDialog_Script = generateDialog_GO.GetComponent<GenerateDialog>();

        GenerateNPC_Script = GenerateNPC_GO.GetComponent<GenerateNPC>();
        rb = GetComponent<Rigidbody2D>();

        cameraGO = GameObject.Find("CameraScript");
        cameraScript = cameraGO.GetComponent<CameraScript>();

        m_Animator = gameObject.GetComponent<Animator>();
        textInstruction.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void FixedUpdate()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        if (horizontal > 0.1 || horizontal < -0.1 || vertical > 0.1 || vertical < -0.1)
        {
            dialogBox_GO.SetActive(false);
            cameraScript.offset.y = 2.5f;
            //transform.up = new Vector3(horizontal * Speed, 0, 0);
            transform.Translate(new Vector3(horizontal, 0, 0) * speed * Time.deltaTime);
            // transform.Translate(new Vector3(0, vertical + 0.2f, 0) * speed * Time.deltaTime);

            m_Animator.SetBool("isRun", true);
            cameraScript.isPlayerMoving = true;

        }
        else
        {
            m_Animator.SetBool("isRun", false);
            cameraScript.isPlayerMoving = false;
        }
        
        if(joystick.Horizontal > 0.1 && facingRight)
        {
            flipFace();

        }
        else if(joystick.Horizontal < -0.1 && !facingRight)
        {
            flipFace();
        }

        /*
        if (gameObject.GetComponent<Rigidbody2D>().transform.position.x < 0 && facingRight)
        {
            flipFace();
        }
        else if (gameObject.GetComponent<Rigidbody2D>().transform.position.x > 0 && !facingRight)
        {
            flipFace();
        }
        */
    }

    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "PortalToAR")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            //Debug.Log("Do something here");
            
            GameObject myObject = GameObject.Find("Load Scene");
            myObject.GetComponent<LoadScene>().AugmentedReality();

        }

        if (collision.gameObject.name == "House Collider")
        {
            Debug.Log("House Collider");
            textInstruction.text = "There are 2 houses, you can go inside them by tapping the door.";   
        }
        else if (collision.gameObject.name == "NPC Collider")
        {
            Debug.Log("NPC Collider");
            textInstruction.text = "Tap the NPC to see what they are saying, beware some of them may tell a lie";
        }
        else if (collision.gameObject.name == "Police Collider")
        {
            Debug.Log("Police Collider");
            textInstruction.text = "Tap the Police door to point who is the killer";
        }

        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("1");
            isTriggered = true;
            //dialogBox.SetActive(true);
            //camera.transform.position = new Vector3(0.02f, 1.15f, -10f);
            /*
            for(float i = 0; i < 2; )
            {
                camera.transform.position = this.transform.position + new Vector3(0f, i, -5f);
                i += Time.deltaTime;
            }
            */
            for (int i = 0; i < generateDialog_Script.tellingTheTruthName.Length; i++)
            {
                string tempName = generateDialog_Script.tellingTheTruthName[i] + "(Clone)"; 
                if(collision.gameObject.name == tempName)
                {
                    Debug.Log("2");
                    switch (GenerateNPC_Script.dayTime)
                    {
                        case 1:
                            //dialog.text = generateDialog_Script.TellingTheTruth();
                            Debug.Log("3");
                            break;
                    }
                }
            }

            for (int i = 0; i < generateDialog_Script.tellingTheLieName.Length; i++)
            {
                string tempName = generateDialog_Script.tellingTheLieName[i] + "(Clone)";
                if (collision.gameObject.name == tempName)
                {
                    Debug.Log("2");
                    switch (GenerateNPC_Script.dayTime)
                    {
                        case 1:
                            //dialog.text = generateDialog_Script.TellingTheLie();
                            Debug.Log("3");
                            break;
                    }
                }
            }

            for (int i = 0; i < generateDialog_Script.tellingNonsenseName.Length; i++)
            {
                string tempName = generateDialog_Script.tellingNonsenseName[i] + "(Clone)";
                if (collision.gameObject.name == tempName)
                {
                    Debug.Log("2");
                    switch (GenerateNPC_Script.dayTime)
                    {
                        case 1:
                            //dialog.text = generateDialog_Script.TellingNonsense();
                            Debug.Log("3");
                            break;
                    }
                }
            }
        }

        

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        //if (collision.gameObject.tag == "MyGameObjectTag")
        // {
        //If the GameObject has the same tag as specified, output this message in the console
        //    Debug.Log("Do something else here");
        //}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit 1");
        isTriggered = false;
        //dialogBox.SetActive(false);
        //camera.transform.position = positionCamera;
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("Exit 2");

        }

        if (collision.gameObject.name == "House Collider")
        {
            Debug.Log("House Collider");
            textInstruction.text = "";
        }
        else if (collision.gameObject.name == "NPC Collider")
        {
            Debug.Log("NPC Collider");
            textInstruction.text = "";
        }
        else if (collision.gameObject.name == "Police Collider")
        {
            Debug.Log("Police Collider");
            textInstruction.text = "";
        }
    }
}
