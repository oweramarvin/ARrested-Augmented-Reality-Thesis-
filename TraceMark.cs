using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceMark : MonoBehaviour
{
    public GameObject victimBody;
    public GameObject killerBody;

    public GameObject[] victimNPC;
    public GameObject[] victimBloodmark;

    public GameObject NPCposition;
    public GameObject[] killerNPC;
    public GameObject[] killerBloodmark;

    private GenerateNPC generateNPC;
    private PoliceScript policeScript;

    int randomNum;
    int randomParts;

    // Start is called before the first frame update
    void Start()
    {
        generateNPC = GameObject.Find("GenerateNPC").GetComponent<GenerateNPC>();
        policeScript = GameObject.Find("Police Script").GetComponent<PoliceScript>();

        randomNum = Random.Range(1, 3);
        randomParts = Random.Range(1, 4);

        switch (randomNum)
        {
            case 1:
                policeScript.questionList[1] = "which part of the body does the killer have blood on?";
                break;
            case 2:
                policeScript.questionList[1] = "which part of the body does the victim have blood on?";
                break;
        }

        switch (randomParts)
        {
            case 1:
                policeScript.answerCorrect[1] = "Foot/ Leg";
                policeScript.answerWrong[1] = "Hand";
                break;
            case 2:
                policeScript.answerCorrect[1] = "Hand";
                policeScript.answerWrong[1] = "Body";
                break;
            case 3:
                policeScript.answerCorrect[1] = "Body";
                policeScript.answerWrong[1] = "Foot/ Leg";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ARCards()
    {

        switch (randomNum)
        {
            case 1:
                BloodOnKillerBody();
                break;
            case 2:
                BloodOnVictimBody();
                break;
        }
    }

    void BloodOnKillerBody() 
    {
        // NPC position (0, 0.21, 0) = foot
        // NPC position (0, 0.1, 0) = hand
        // NPC position (0, -0.01, 0) = body

        killerBody.SetActive(true);

        switch (generateNPC.killerName)
        {
            case "Bino":
                killerNPC[0].SetActive(true);
                break;
            case "Fauni":
                killerNPC[1].SetActive(true);
                break;
            case "Hazel":
                killerNPC[2].SetActive(true);
                break;
            case "Jomar":
                killerNPC[3].SetActive(true);
                break;
            case "Lian":
                killerNPC[4].SetActive(true);
                break;
            case "Yam":
                killerNPC[5].SetActive(true);
                break;
            case "Dolores":
                killerNPC[6].SetActive(true);
                break;
            case "Lanie":
                killerNPC[7].SetActive(true);
                break;
            case "Lee":
                killerNPC[8].SetActive(true);
                break;
            case "SPO1":
                killerNPC[9].SetActive(true);
                break;
            case "SPO2":
                killerNPC[10].SetActive(true);
                break;
            case "SPO3":
                killerNPC[11].SetActive(true);
                break;
        }

        // NPC position (0, -0.01, 0) = body
        // NPC position (0, 0.1, 0) = hand
        // NPC position (0, 0.21, 0) = foot

        
        float yPos = 0f;

        switch (randomParts)
        {
            case 1:
                yPos = -0.01f;
                killerBloodmark[0].SetActive(true);
                break;
            case 2:
                yPos = 0.1f;
                killerBloodmark[1].SetActive(true);
                break;
            case 3:
                yPos = 0.21f;
                killerBloodmark[2].SetActive(true);
                break;

        }

        Vector3 desiredPos = new Vector3(0f, yPos , 0f);

        NPCposition.transform.position = Vector3.Lerp(NPCposition.transform.position, desiredPos, 0f);
    }

    void BloodOnVictimBody()
    {
        victimBody.SetActive(true);

        switch (generateNPC.victimName[0])
        {
            case "Bino":
                victimNPC[0].SetActive(true);
                break;
            case "Fauni":
                victimNPC[1].SetActive(true);
                break;
            case "Hazel":
                victimNPC[2].SetActive(true);
                break;
            case "Jomar":
                victimNPC[3].SetActive(true);
                break;
            case "Lian":
                victimNPC[4].SetActive(true);
                break;
            case "Yam":
                victimNPC[5].SetActive(true);
                break;
            case "Dolores":
                victimNPC[6].SetActive(true);
                break;
            case "Lanie":
                victimNPC[7].SetActive(true);
                break;
            case "Lee":
                victimNPC[8].SetActive(true);
                break;
            case "SPO1":
                victimNPC[9].SetActive(true);
                break;
            case "SPO2":
                victimNPC[10].SetActive(true);
                break;
            case "SPO3":
                victimNPC[11].SetActive(true);
                break;
        }

        int randomParts = Random.Range(1, 4);

        switch (randomParts)
        {
            case 1:
                victimBloodmark[0].SetActive(true);
                break;
            case 2:
                victimBloodmark[1].SetActive(true);
                break;
            case 3:
                victimBloodmark[2].SetActive(true);
                break;

        }
    }

    public void OnTargetLost()
    {
        for (int i=0; i<12; i++)
        {
            killerNPC[i].SetActive(false);
            victimNPC[i].SetActive(false);
        }

        for (int i=0; i<3; i++)
        {
            victimBloodmark[i].SetActive(false);
            killerBloodmark[i].SetActive(false);
        }

        victimBody.SetActive(false);
        killerBody.SetActive(false);
    }
}
