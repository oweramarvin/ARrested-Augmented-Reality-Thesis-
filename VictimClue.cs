using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictimClue : MonoBehaviour
{
    public SpriteRenderer[] npc;
    public Sprite[] spriteNpc;

    int spriteNum = 0;

    private GenerateNPC generateNPC;

    public TMP_Text textToDisplay;
    public TMP_Text name1;
    public TMP_Text name2;
    public TMP_Text name3;

    int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        generateNPC = GameObject.Find("GenerateNPC").GetComponent<GenerateNPC>();

        randomNumber = Random.Range(1, 4);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ARCards()
    {
        randomNumber = Random.Range(1, 4);

        switch (randomNumber)
        {
            case 1:
                OneOfThemIsKiller();
                break;
            case 2:
                OneOfThemIsKillerFriend();
                break;
            case 3:
                OneOfThemIsVictimFriend();
                break;

        }
    }

    void OneOfThemIsKiller()
    {
        NpcName(generateNPC.killerName);
        textToDisplay.text = "One of them is the killer";

    }

    void OneOfThemIsVictimFriend()
    {
        NpcName(generateNPC.victimFriend);
        textToDisplay.text = "One of them is the friend of the victim";
        
    }

    void OneOfThemIsKillerFriend()
    {
        NpcName(generateNPC.killerFriend);
        textToDisplay.text = "One of them is the friend of the killer";

    }

    void NpcName(string name)
    {
        string[] npcName =
        {
            "Bino", "Fauni", "Hazel", "Jomar", "Lian", "Yam", "Dolores", "Lanie", "Lee", "SPO1", "SPO2", "SPO3"
        };

        switch (name)
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

        int randomSprite1 = 0;
        int randomSprite2 = 0;

        do
        {
            randomSprite1 = Random.Range(0, 12);
            randomSprite2 = Random.Range(0, 12);
        } while (randomSprite1 == spriteNum || randomSprite2 == spriteNum || randomSprite1 == randomSprite2);

        int randomNum = Random.Range(1, 4);

        switch (randomNum)
        {
            case 1:
                npc[0].sprite = spriteNpc[spriteNum];
                name1.text = name;
                npc[1].sprite = spriteNpc[randomSprite1];
                name2.text = npcName[randomSprite1];
                npc[2].sprite = spriteNpc[randomSprite2];
                name3.text = npcName[randomSprite2];
                break;
            case 2:
                
                npc[0].sprite = spriteNpc[randomSprite1];
                name1.text = npcName[randomSprite1];
                npc[1].sprite = spriteNpc[spriteNum];
                name2.text = name;
                npc[2].sprite = spriteNpc[randomSprite2];
                name3.text = npcName[randomSprite2];
                break;
            case 3:
                npc[0].sprite = spriteNpc[randomSprite1];
                name1.text = npcName[randomSprite1];
                npc[1].sprite = spriteNpc[randomSprite2];
                name2.text = npcName[randomSprite2];
                npc[2].sprite = spriteNpc[spriteNum];
                name3.text = name;
                break;
        }


    }



}
