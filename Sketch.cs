using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sketch : MonoBehaviour
{
    public GameObject mask;

    public SpriteRenderer spriteRenderer;
    public Sprite[] npcSprite;

    private GenerateNPC generateNPC;

    public int sketchNumber;

    int randomNum;

    private PoliceScript policeScript;

    // Start is called before the first frame update
    void Start()
    {
        generateNPC = GameObject.Find("GenerateNPC").GetComponent<GenerateNPC>();
        policeScript = GameObject.Find("Police Script").GetComponent<PoliceScript>();

        sketchNumber = Random.Range(1, 5);

        policeScript.questionList[2] = "who is the person in the sketch/ drawing?";

        switch (sketchNumber)
        {
            case 1:
                policeScript.answerCorrect[2] = "The killer";
                policeScript.answerWrong[2] = "The killer friend";
                break;
            case 2:
                policeScript.answerCorrect[2] = "The killer friend";
                policeScript.answerWrong[2] = "Victim friend";
                break;
            case 3:
                policeScript.answerCorrect[2] = "Victim friend";
                policeScript.answerWrong[2] = "The killer";
                break;
            case 4:
                policeScript.answerCorrect[2] = "Your friend";
                policeScript.answerWrong[2] = "The killer friend";
                break;
        }

        //randomNum = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void ARCards()
    {

        switch (sketchNumber)
        {
            case 1:
                KillerSketch();
                break;
            case 2:
                KillerFriendSketch();
                break;
            case 3:
                VictimFriendSketch();
                break;
            case 4:
                YourFriendSketch();
                break;
        }
    }

    void YourFriendSketch()
    {
        int spriteNum = 0;

        switch (generateNPC.yourFriend)
        {
            case "Bino":
                spriteNum = 0;
                break;
            case "Fauni":
                spriteNum = 1;
                break;
            case "Hazel":
                spriteNum = 2;
                break;
            case "Jomar":
                spriteNum = 3;
                break;
            case "Lian":
                spriteNum = 4;
                break;
            case "Yam":
                spriteNum = 5;
                break;
            case "Dolores":
                spriteNum = 6;
                break;
            case "Lanie":
                spriteNum = 7;
                break;
            case "Lee":
                spriteNum = 8;
                break;
            case "SPO1":
                spriteNum = 9;
                break;
            case "SPO2":
                spriteNum = 10;
                break;
            case "SPO3":
                spriteNum = 11;
                break;
        }

        spriteRenderer.sprite = npcSprite[spriteNum];
    }

    void VictimFriendSketch()
    {
        int spriteNum = 0;

        switch (generateNPC.victimFriend)
        {
            case "Bino":
                spriteNum = 0;
                break;
            case "Fauni":
                spriteNum = 1;
                break;
            case "Hazel":
                spriteNum = 2;
                break;
            case "Jomar":
                spriteNum = 3;
                break;
            case "Lian":
                spriteNum = 4;
                break;
            case "Yam":
                spriteNum = 5;
                break;
            case "Dolores":
                spriteNum = 6;
                break;
            case "Lanie":
                spriteNum = 7;
                break;
            case "Lee":
                spriteNum = 8;
                break;
            case "SPO1":
                spriteNum = 9;
                break;
            case "SPO2":
                spriteNum = 10;
                break;
            case "SPO3":
                spriteNum = 11;
                break;
        }

        spriteRenderer.sprite = npcSprite[spriteNum];
    }

    void KillerFriendSketch()
    {
        int spriteNum = 0;

        switch (generateNPC.killerFriend)
        {
            case "Bino":
                spriteNum = 0;
                break;
            case "Fauni":
                spriteNum = 1;
                break;
            case "Hazel":
                spriteNum = 2;
                break;
            case "Jomar":
                spriteNum = 3;
                break;
            case "Lian":
                spriteNum = 4;
                break;
            case "Yam":
                spriteNum = 5;
                break;
            case "Dolores":
                spriteNum = 6;
                break;
            case "Lanie":
                spriteNum = 7;
                break;
            case "Lee":
                spriteNum = 8;
                break;
            case "SPO1":
                spriteNum = 9;
                break;
            case "SPO2":
                spriteNum = 10;
                break;
            case "SPO3":
                spriteNum = 11;
                break;
        }

        spriteRenderer.sprite = npcSprite[spriteNum];
    }

    void KillerSketch()
    {
        int spriteNum = 0;

        switch (generateNPC.killerName)
        {
            case "Bino":
                spriteNum = 0;
                break;
            case "Fauni":
                spriteNum = 1;
                break;
            case "Hazel":
                spriteNum = 2;
                break;
            case "Jomar":
                spriteNum = 3;
                break;
            case "Lian":
                spriteNum = 4;
                break;
            case "Yam":
                spriteNum = 5;
                break;
            case "Dolores":
                spriteNum = 6;
                break;
            case "Lanie":
                spriteNum = 7;
                break;
            case "Lee":
                spriteNum = 8;
                break;
            case "SPO1":
                spriteNum = 9;
                break;
            case "SPO2":
                spriteNum = 10;
                break;
            case "SPO3":
                spriteNum = 11;
                break;
        }

        spriteRenderer.sprite = npcSprite[spriteNum];

    }

}
