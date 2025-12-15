using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStory : MonoBehaviour
{
    public int storyNumber; // Goal: atleast 5
    public string[] story;
    public int scenarioNumber;
    public string[] scenario;

    private GenerateNPC GenerateNPC_Script;
    private GenerateDialog generateDialog_Script;
    private PoliceScript policeScript;

    // Start is called before the first frame update
    void Start()
    {
        policeScript = GameObject.Find("Police Script").GetComponent<PoliceScript>();

        GameObject GenerateNPC_GO = GameObject.Find("GenerateNPC");
        GenerateNPC_Script = GenerateNPC_GO.GetComponent<GenerateNPC>();

        GameObject generateDialog_GO = GameObject.Find("GenerateDialog");
        generateDialog_Script = generateDialog_GO.GetComponent<GenerateDialog>();


        RandomStory();
        //generateDialog_Script.GenerateTellingTheTruthLieNonsense();
        GenerateNPC_Script.GenerateFriend();
        generateDialog_Script.GenerateTellingTruth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string GenerateRandomNameReveal()
    {
        string nameReveal = "Sample Name";
        int randomRole = Random.Range(1, 4); // Police, Doctor, Civilian
        int randomCount = 0;

        switch (randomRole)
        {
            case 1:
                randomCount = Random.Range(0, GenerateNPC_Script.policeCount);
                nameReveal = GenerateNPC_Script.policeName[randomCount];
                break;
            case 2:
                randomCount = Random.Range(0, GenerateNPC_Script.doctorCount);
                nameReveal = GenerateNPC_Script.doctorName[randomCount];
                break;
            case 3:
                randomCount = Random.Range(0, GenerateNPC_Script.civilianCount);
                nameReveal = GenerateNPC_Script.civilianName[randomCount];
                break;
        }

        return nameReveal;
    }

    void RandomStory()
    {
        string nameReveal = GenerateRandomNameReveal();

        
        generateDialog_Script.tellingTheLieCount = 2;
        generateDialog_Script.tellingNonsenseCount = 1;

        generateDialog_Script.tellingTheTruthCount = GenerateNPC_Script.policeCount + GenerateNPC_Script.civilianCount + 
            GenerateNPC_Script.doctorCount - generateDialog_Script.tellingTheLieCount - generateDialog_Script.tellingNonsenseCount;
        

        storyNumber = Random.Range(1, 8);

        //storyNumber = 7; // for testing

        policeScript.questionList[4] = "The story is about?";

        switch (storyNumber)
        {
            case 1:
                policeScript.answerCorrect[4] = "The victim friend is the killer";
                policeScript.answerWrong[4] = "The thief is the killer";
                break;
            case 2:
                policeScript.answerCorrect[4] = "Your friend is the killer";
                policeScript.answerWrong[4] = "The drug pusher is the killer";
                break;
            case 3:
                policeScript.answerCorrect[4] = "It's all about love";
                policeScript.answerWrong[4] = "Drug addiction";
                break;
            case 4:
                policeScript.answerCorrect[4] = "The Drug pusher is the killer";
                policeScript.answerWrong[4] = "The victim friend is the killer";
                break;
            case 5:
                policeScript.answerCorrect[4] = "Drug addiction";
                policeScript.answerWrong[4] = "It's all about love";
                break;
            case 6:
                policeScript.answerCorrect[4] = "There's a thief";
                policeScript.answerWrong[4] = "It's all about love";
                break;
            case 7:
                policeScript.answerCorrect[4] = "The thief is killed by his/her victim";
                policeScript.answerWrong[4] = "Your friend is the killer";
                break;

        }

        // Whos gonna side with whom?
        switch (storyNumber)
        {
            case 1:
                story[0] = "Victim Friend";
                story[1] = "The victim friend is the killer.";
                // Not unless if the victim and the killer is the same
                break;
            case 2:
                story[0] = "Supportive Friend";
                story[1] = "The supportive friend is the killer";
                break;
            case 3:
                story[0] = "Cheating";
                story[1] = "It can be the husband or wife caught cheating";
                break;
            case 4:
                story[0] = "Pusher";
                story[1] = "The pusher is the killer";
                break;
            case 5:
                story[0] = "Drug";
                story[1] = "The killer put a drug in the victim, with a poster 'NANLABAN'";
                break;
            case 6:
                story[0] = "Thief";
                story[1] = "The thief is the killer";
                break;
            case 7:
                story[0] = "The thief is dead";
                story[1] = "The stolen person kill the thief";
                break;
        }

    }
}
