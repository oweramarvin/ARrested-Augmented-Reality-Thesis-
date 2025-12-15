using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARScript : MonoBehaviour
{

    public string[] arCard = new string[8]; 

    public GameObject[] noCard;
    public GameObject[] haveCard;

    private FindObject findObject;
    private OldPhotograph oldPhotograph;
    private PastSight pastSight;
    private TraceMark traceMark;
    private SomeoneSay someoneSay;
    private GameHelp gameHelp;
    private VictimClue victimClue;
    private Sketch sketch;

    public Image[] cardList;
    public Sprite[] cardSprite;

    private VictimAndKillerThings victimKillerThingsScript;
    // Start is called before the first frame update
    void Start()
    {
        findObject = GameObject.Find("Find Object").GetComponent<FindObject>();
        oldPhotograph = GameObject.Find("Old Photograph").GetComponent<OldPhotograph>();
        pastSight = GameObject.Find("Past Sight").GetComponent<PastSight>();
        traceMark = GameObject.Find("Trace Mark").GetComponent<TraceMark>();
        someoneSay = GameObject.Find("Someone Say").GetComponent<SomeoneSay>();
        gameHelp = GameObject.Find("Game Help").GetComponent<GameHelp>();
        victimClue = GameObject.Find("Victim Clue").GetComponent<VictimClue>();
        sketch = GameObject.Find("Sketch").GetComponent<Sketch>();

        victimKillerThingsScript = GameObject.Find("VictimAndKillerThings").GetComponent<VictimAndKillerThings>();

        //noCard = GameObject.FindGameObjectWithTag("No Card");
        //haveCard = GameObject.FindGameObjectWithTag("Have Card");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCards(string cardName)
    {
        
        arCard[0] = "Card 1(Find Object)";
        int randomCard = Random.Range(2, 9);
        switch (randomCard)
        {
            case 2:
                arCard[1] = "Card 2 (Old Photograph)";
                break;
            case 3:
                arCard[1] = "Card 3 (Past Sight)";
                break;
            case 4:
                arCard[1] = "Card 4(Trace Mark)";
                break;
            case 5:
                arCard[1] = "Card 5 (Someone Say)";
                break;
            case 6:
                arCard[1] = "Card 6 (Game Help)";
                break;
            case 7:
                arCard[1] = "Card 7 (Victim Clue)";
                break;
            case 8:
                arCard[1] = "Card 8 (Sketch)";
                break;
        }
        
        /*
        arCard[0] = "Card 1(Find Object)";
        arCard[1] = "Card 2 (Old Photograph)";
        arCard[2] = "Card 3 (Past Sight)";
        arCard[3] = "Card 4(Trace Mark)";
        arCard[4] = "Card 5 (Someone Say)";
        arCard[5] = "Card 6 (Game Help)";
        arCard[6] = "Card 7 (Victim Clue)";
        arCard[7] = "Card 8 (Sketch)";
        */
    }

    public void ARCardClicked(string cardName)
    {
        for (int i = 0; i < 9; i++)
        {
            if (arCard[i] == "")
            {
                arCard[i] = cardName;

                if(cardName.Contains("Find Object"))
                {
                    cardList[i].sprite = cardSprite[0];
                }
                else if (cardName.Contains("Old Photograph"))
                {
                    cardList[i].sprite = cardSprite[1];
                }
                else if(cardName.Contains("Past Sight"))
                {
                    cardList[i].sprite = cardSprite[2];
                }
                else if(cardName.Contains("Trace Mark"))
                {
                    cardList[i].sprite = cardSprite[3];
                }
                else if(cardName.Contains("Someone Say"))
                {
                    cardList[i].sprite = cardSprite[4];
                }
                else if(cardName.Contains("Game Help"))
                {
                    cardList[i].sprite = cardSprite[5];
                }
                else if(cardName.Contains("Victim Clue"))
                {
                    cardList[i].sprite = cardSprite[6];
                }
                else if(cardName.Contains("Sketch"))
                {
                    cardList[i].sprite = cardSprite[7];
                }

                break;

            }
        }

    }

    bool IsCardExist(string cardName, int cardNum)
    {
        bool isScannable = false;
        for (int i = 0; i < 9; i++)
        {
            if (arCard[i].Contains(cardName))
            {
                isScannable = true;
                /*
                if(arCard[i].Contains("Find Object"))
                {
                    bool objectExist = IsFindObjectNotNull(i);
                    if (objectExist)
                    {
                        isScannable = true;
                    }
                    else
                    {
                        isScannable = false;
                    }
                }
                else
                {
                */
                    arCard[i] = "";
                    victimKillerThingsScript.SpawnCardsAgain(cardName);

                    cardList[i].sprite = null;

                /*   
                }
                */
            }
        }

        if (isScannable)
        {
            HaveCards(cardNum);
            return true;
        }
        else
        {
            NoCards(cardNum);
            return false;
        }

    }

    bool IsFindObjectNotNull(int i)
    {
        for (int j = 0; j < findObject.thingsClickedList.Length; j++)
        {
            if (findObject.thingsClickedList[j] != "")
            {
                Debug.Log("IsFindObjectNotNull Function");
                return true;
            }
        }

        return false;

    }

    public void FindObject_Scan()
    {
        if(IsCardExist("Find Object", 0))
            findObject.ARCards();
    }

    public void OldPhotograph_Scan()
    {
        if (IsCardExist("Old Photograph", 1))
            oldPhotograph.ARCards();
        
    }

    public void PastSight_Scan()
    {
        if (IsCardExist("Past Sight", 2))
            pastSight.ARCards();

    }

    public void TraceMark_Scan()
    {
        if(IsCardExist("Trace Mark", 3))
            traceMark.ARCards();
    }

    public void SomeoneSay_Scan()
    {
        if (IsCardExist("Someone Say", 4))
            someoneSay.ARCards();
    }

    public void GameHelp_Scan()
    {
        if (IsCardExist("Game Help", 5))
            gameHelp.ARCards();

    }

    public void VictimClue_Scan()
    {
        if (IsCardExist("Victim Clue", 6))
            victimClue.ARCards();
    }

    public void Sketch_Scan()
    {
        if (IsCardExist("Sketch", 7))
            sketch.ARCards();

    }

    public void HaveCards(int num)
    {
        haveCard[num].SetActive(true);
        noCard[num].SetActive(false);
    }

    public void NoCards(int num)
    {
        haveCard[num].SetActive(false);
        noCard[num].SetActive(true);
    }
}
