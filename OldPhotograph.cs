using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPhotograph : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderer;
    public Sprite[] civilianSprite;
    public Sprite[] doctorSprite;
    public Sprite[] policeSprite;

    public GameObject NPC1_DocPol;
    public GameObject NPC1_Civilian;
    public GameObject NPC2_DocPol;
    public GameObject NPC2_Civilian;


    private GenerateNPC generateNPC;

    string condition;

    int totalNPC;
    int leftRight; // killer is in the left or right
    int spriteNum1 = 1;
    int spriteNum2 = 2;

    int randomInnocent;
    string innocentName;
    string innocentRole;

    int randomNum;

    private PoliceScript policeScript;

    // Start is called before the first frame update
    void Start()
    {
        generateNPC = GameObject.Find("GenerateNPC").GetComponent<GenerateNPC>();
        policeScript = GameObject.Find("Police Script").GetComponent<PoliceScript>();

        totalNPC = generateNPC.civilianCount + generateNPC.doctorCount + generateNPC.policeCount;
        leftRight = Random.Range(1, 3); // killer is in the left or right

        randomNum = Random.Range(1, 4);

        policeScript.questionList[0] = "is the killer in the old photograph?";
        switch (randomNum)
        {
            case 1:
                policeScript.answerCorrect[0] = "Yes";
                policeScript.answerWrong[0] = "No";
                break;
            case 2:
                policeScript.answerCorrect[0] = "Yes";
                policeScript.answerWrong[0] = "No";
                break;
            case 3:
                policeScript.answerCorrect[0] = "No";
                policeScript.answerWrong[0] = "Yes";
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (condition == "KillerWithVictim")
        {
            if (generateNPC.killerRole == generateNPC.victimRole[0])
            {
                if (generateNPC.killerRole == "Civilian")
                {
                    NPC1_Civilian.SetActive(true);
                    NPC2_Civilian.SetActive(true);

                    spriteRenderer[0].sprite = civilianSprite[spriteNum2];
                    spriteRenderer[1].sprite = civilianSprite[spriteNum1];
                }
                else
                {
                    NPC1_DocPol.SetActive(true);
                    NPC2_DocPol.SetActive(true);

                    if(generateNPC.killerRole == "Doctor")
                    {
                        spriteRenderer[2].sprite = doctorSprite[spriteNum2];
                        spriteRenderer[3].sprite = doctorSprite[spriteNum1];
                    }
                    else
                    {
                        spriteRenderer[2].sprite = policeSprite[spriteNum2];
                        spriteRenderer[3].sprite = policeSprite[spriteNum1];
                    }
                        
                }
            }
            else
            {
                if (generateNPC.victimRole[0] == "Civilian")
                {
                    NPC1_Civilian.SetActive(true);
                    spriteRenderer[0].sprite = civilianSprite[spriteNum2];
                }
                else if (generateNPC.victimRole[0] == "Doctor")
                {
                    NPC1_DocPol.SetActive(true);
                    spriteRenderer[2].sprite = doctorSprite[spriteNum2];
                }
                else if (generateNPC.victimRole[0] == "Police")
                {
                    NPC1_DocPol.SetActive(true);
                    spriteRenderer[2].sprite = policeSprite[spriteNum2];
                }

                if (generateNPC.killerRole == "Civilian")
                {
                    NPC2_Civilian.SetActive(true);
                    spriteRenderer[1].sprite = civilianSprite[spriteNum1];
                }
                else if (generateNPC.killerRole == "Doctor")
                {
                    NPC2_DocPol.SetActive(true);
                    spriteRenderer[3].sprite = doctorSprite[spriteNum1];
                }
                else if (generateNPC.killerRole == "Police")
                {
                    NPC2_DocPol.SetActive(true);
                    spriteRenderer[3].sprite = policeSprite[spriteNum1];
                }
            }

        }
        else if (condition == "KillerWithInnocent")
        {
            if (generateNPC.killerRole == innocentRole)
            {
                if (generateNPC.killerRole == "Civilian")
                {
                    NPC1_Civilian.SetActive(true);
                    NPC2_Civilian.SetActive(true);

                    spriteRenderer[0].sprite = civilianSprite[spriteNum2];
                    spriteRenderer[1].sprite = civilianSprite[spriteNum1];
                }
                else
                {
                    NPC1_DocPol.SetActive(true);
                    NPC2_DocPol.SetActive(true);

                    if (generateNPC.killerRole == "Doctor")
                    {
                        spriteRenderer[2].sprite = doctorSprite[spriteNum2];
                        spriteRenderer[3].sprite = doctorSprite[spriteNum1];
                    }
                    else
                    {
                        spriteRenderer[2].sprite = policeSprite[spriteNum2];
                        spriteRenderer[3].sprite = policeSprite[spriteNum1];
                    }

                }
            }
            else
            {
                if (innocentRole == "Civilian")
                {
                    NPC1_Civilian.SetActive(true);
                    spriteRenderer[0].sprite = civilianSprite[spriteNum2];
                }
                else if (innocentRole == "Doctor")
                {
                    NPC1_DocPol.SetActive(true);
                    spriteRenderer[2].sprite = doctorSprite[spriteNum2];
                }
                else if (innocentRole == "Police")
                {
                    NPC1_DocPol.SetActive(true);
                    spriteRenderer[2].sprite = policeSprite[spriteNum2];
                }

                if (generateNPC.killerRole == "Civilian")
                {
                    NPC2_Civilian.SetActive(true);
                    spriteRenderer[1].sprite = civilianSprite[spriteNum1];
                }
                else if (generateNPC.killerRole == "Doctor")
                {
                    NPC2_DocPol.SetActive(true);
                    spriteRenderer[3].sprite = doctorSprite[spriteNum1];
                }
                else if (generateNPC.killerRole == "Police")
                {
                    NPC2_DocPol.SetActive(true);
                    spriteRenderer[3].sprite = policeSprite[spriteNum1];
                }
            }
        }
        else if (condition == "VictimWithInnocent")
        {
            if (generateNPC.victimRole[0] == innocentRole)
            {
                if (generateNPC.victimRole[0] == "Civilian")
                {
                    NPC1_Civilian.SetActive(true);
                    NPC2_Civilian.SetActive(true);

                    spriteRenderer[0].sprite = civilianSprite[spriteNum2];
                    spriteRenderer[1].sprite = civilianSprite[spriteNum1];
                }
                else
                {
                    NPC1_DocPol.SetActive(true);
                    NPC2_DocPol.SetActive(true);

                    if (generateNPC.victimRole[0] == "Doctor")
                    {
                        spriteRenderer[2].sprite = doctorSprite[spriteNum2];
                        spriteRenderer[3].sprite = doctorSprite[spriteNum1];
                    }
                    else
                    {
                        spriteRenderer[2].sprite = policeSprite[spriteNum2];
                        spriteRenderer[3].sprite = policeSprite[spriteNum1];
                    }

                }
            }
            else
            {
                if (innocentRole == "Civilian")
                {
                    NPC1_Civilian.SetActive(true);
                    spriteRenderer[0].sprite = civilianSprite[spriteNum2];
                }
                else if (innocentRole == "Doctor")
                {
                    NPC1_DocPol.SetActive(true);
                    spriteRenderer[2].sprite = doctorSprite[spriteNum2];
                }
                else if (innocentRole == "Police")
                {
                    NPC1_DocPol.SetActive(true);
                    spriteRenderer[2].sprite = policeSprite[spriteNum2];
                }

                if (generateNPC.victimRole[0] == "Civilian")
                {
                    NPC2_Civilian.SetActive(true);
                    spriteRenderer[1].sprite = civilianSprite[spriteNum1];
                }
                else if (generateNPC.victimRole[0] == "Doctor")
                {
                    NPC2_DocPol.SetActive(true);
                    spriteRenderer[3].sprite = doctorSprite[spriteNum1];
                }
                else if (generateNPC.victimRole[0] == "Police")
                {
                    NPC2_DocPol.SetActive(true);
                    spriteRenderer[3].sprite = policeSprite[spriteNum1];
                }
            }

        }
        
    }


    public void ARCards()
    {

        switch (randomNum)
        {
            case 1:
                condition = "KillerWithVictim";
                KillerWithVictim();
                break;
            case 2:
                condition = "KillerWithInnocent";
                KillerWithInnocent();
                break;
            case 3:
                condition = "VictimWithInnocent";
                VictimWithInnocent();
                break;
            /* nice to have
            case 4:
                condition = "InnocentWithInnocent";
                InnocentWithInnocent();
                break;
                */
        }

    }



    void ShuffleClue()
    {


    }


    void KillerWithVictim()
    {
        int totalNPC = generateNPC.civilianCount + generateNPC.doctorCount + generateNPC.policeCount;
        int leftRight = Random.Range(1, 3); // killer is in the left or right
        int spriteNum1 = 1;
        int spriteNum2 = 2;

        switch (generateNPC.killerName)
        {
            case "Bino":
                spriteNum1 = 1;
                break;
            case "Fauni":
                spriteNum1 = 3;
                break;
            case "Hazel":
                spriteNum1 = 5;
                break;
            case "Jomar":
                spriteNum1 = 7;
                break;
            case "Lian":
                spriteNum1 = 9;
                break;
            case "Yam":
                spriteNum1 = 11;
                break;
            case "Dolores":
                spriteNum1 = 1;
                break;
            case "Lanie":
                spriteNum1 = 3;
                break;
            case "Lee":
                spriteNum1 = 5;
                break;
            case "SPO1":
                spriteNum1 = 1;
                break;
            case "SPO2":
                spriteNum1 = 3;
                break;
            case "SPO3":
                spriteNum1 = 5;
                break;
        }

        switch (generateNPC.victimName[0])
        {
            case "Bino":
                spriteNum2 = 0;
                break;
            case "Fauni":
                spriteNum2 = 2;
                break;
            case "Hazel":
                spriteNum2 = 4;
                break;
            case "Jomar":
                spriteNum2 = 6;
                break;
            case "Lian":
                spriteNum2 = 8;
                break;
            case "Yam":
                spriteNum2 = 10;
                break;
            case "Dolores":
                spriteNum2 = 0;
                break;
            case "Lanie":
                spriteNum2 = 2;
                break;
            case "Lee":
                spriteNum2 = 4;
                break;
            case "SPO1":
                spriteNum2 = 0;
                break;
            case "SPO2":
                spriteNum2 = 2;
                break;
            case "SPO3":
                spriteNum2 = 4;
                break;
        }




    }

    void KillerWithInnocent()
    {
        switch (generateNPC.killerName)
        {
            case "Bino":
                spriteNum1 = 1;
                break;
            case "Fauni":
                spriteNum1 = 3;
                break;
            case "Hazel":
                spriteNum1 = 5;
                break;
            case "Jomar":
                spriteNum1 = 7;
                break;
            case "Lian":
                spriteNum1 = 9;
                break;
            case "Yam":
                spriteNum1 = 11;
                break;
            case "Dolores":
                spriteNum1 = 1;
                break;
            case "Lanie":
                spriteNum1 = 3;
                break;
            case "Lee":
                spriteNum1 = 5;
                break;
            case "SPO1":
                spriteNum1 = 1;
                break;
            case "SPO2":
                spriteNum1 = 3;
                break;
            case "SPO3":
                spriteNum1 = 5;
                break;
        }

        generateInnocentAgain:
        
        randomInnocent = Random.Range(1, 13);
    
        switch (randomInnocent)
        {
            case 1:
                innocentName = "Bino";
                innocentRole = "Civilian";
                spriteNum2 = 12;
                break;
            case 2:
                innocentName = "Fauni";
                innocentRole = "Civilian";
                spriteNum2 = 13;
                break;
            case 3:
                innocentName = "Hazel";
                innocentRole = "Civilian";
                spriteNum2 = 14; 
                break;
            case 4:
                innocentName = "Jomar";
                innocentRole = "Civilian";
                spriteNum2 = 15; 
                break;
            case 5:
                innocentName = "Lian";
                innocentRole = "Civilian";
                spriteNum2 = 16; 
                break;
            case 6:
                innocentName = "Yam";
                innocentRole = "Civilian";
                spriteNum2 = 17;
                break;
            case 7:
                innocentName = "Dolores";
                innocentRole = "Doctor";
                spriteNum2 = 6;
                break;
            case 8:
                innocentName = "Lanie";
                innocentRole = "Doctor";
                spriteNum2 = 7; 
                break;
            case 9:
                innocentName = "Lee";
                innocentRole = "Doctor";
                spriteNum2 = 8; 
                break;
            case 10:
                innocentName = "SPO1";
                innocentRole = "Police";
                spriteNum2 = 6;
                break;
            case 11:
                innocentName = "SPO2";
                innocentRole = "Police";
                spriteNum2 = 7;
                break;
            case 12:
                innocentName = "SPO3";
                innocentRole = "Police";
                spriteNum2 = 8;
                break;
        }

        if (innocentName == generateNPC.victimName[0] || innocentName == generateNPC.killerName)
        {
            goto generateInnocentAgain;
        }

    }

    void VictimWithInnocent()
    {
        switch (generateNPC.victimName[0])
        {
            case "Bino":
                spriteNum1 = 0;
                break;
            case "Fauni":
                spriteNum1 = 2;
                break;
            case "Hazel":
                spriteNum1 = 4;
                break;
            case "Jomar":
                spriteNum1 = 6;
                break;
            case "Lian":
                spriteNum1 = 8;
                break;
            case "Yam":
                spriteNum1 = 10;
                break;
            case "Dolores":
                spriteNum1 = 0;
                break;
            case "Lanie":
                spriteNum1 = 2;
                break;
            case "Lee":
                spriteNum1 = 4;
                break;
            case "SPO1":
                spriteNum1 = 0;
                break;
            case "SPO2":
                spriteNum1 = 2;
                break;
            case "SPO3":
                spriteNum1 = 4;
                break;
        }

        generateInnocentAgain:

        randomInnocent = Random.Range(1, 13);

        switch (randomInnocent)
        {
            case 1:
                innocentName = "Bino";
                innocentRole = "Civilian";
                spriteNum2 = 12;
                break;
            case 2:
                innocentName = "Fauni";
                innocentRole = "Civilian";
                spriteNum2 = 13;
                break;
            case 3:
                innocentName = "Hazel";
                innocentRole = "Civilian";
                spriteNum2 = 14;
                break;
            case 4:
                innocentName = "Jomar";
                innocentRole = "Civilian";
                spriteNum2 = 15;
                break;
            case 5:
                innocentName = "Lian";
                innocentRole = "Civilian";
                spriteNum2 = 16;
                break;
            case 6:
                innocentName = "Yam";
                innocentRole = "Civilian";
                spriteNum2 = 17;
                break;
            case 7:
                innocentName = "Dolores";
                innocentRole = "Doctor";
                spriteNum2 = 6;
                break;
            case 8:
                innocentName = "Lanie";
                innocentRole = "Doctor";
                spriteNum2 = 7;
                break;
            case 9:
                innocentName = "Lee";
                innocentRole = "Doctor";
                spriteNum2 = 8;
                break;
            case 10:
                innocentName = "SPO1";
                innocentRole = "Police";
                spriteNum2 = 6;
                break;
            case 11:
                innocentName = "SPO2";
                innocentRole = "Police";
                spriteNum2 = 7;
                break;
            case 12:
                innocentName = "SPO3";
                innocentRole = "Police";
                spriteNum2 = 8;
                break;
        }

        if (innocentName == generateNPC.victimName[0] || innocentName == generateNPC.killerName)
        {
            goto generateInnocentAgain;
        }
    }

    void InnocentWithInnocent()
    {
        Debug.Log("KillerThingsWithTheKiller");

    }

    public void OnTargetLost()
    {
        NPC1_Civilian.SetActive(false);
        NPC1_DocPol.SetActive(false);
        NPC2_Civilian.SetActive(false);
        NPC2_DocPol.SetActive(false);
    }

    void KillerWithKillerEquipment()
    {
        /* 
         * Layer = 2
         * 
         * Civilian
         * scale (0.045, 0.035,0)
         * position (-0.03, 0, 0)
         * 
         * DocPol
         * scale (0.025, 0.023, 0)
         * position (-0.02, 0, 0)
         * 
         * 
        */
    }
    
}
