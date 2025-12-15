using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindObject : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEngine.Rendering.Universal.Light2D light;

    public GameObject[] showNPC;
    public GameObject[] showThings;

    public string[] thingsClickedList = new string[10];
    public string[] arCard = new string[9]; // okay

    public string[] victimThings = new string[6]; // okay
    public string[] killerThings = new string[6]; // okay
    public string killerEquipment; // okay
    
    private VictimAndKillerThings victimKillerThings;
    private ARScript arScript;
    private GenerateNPC generateNPC;

    int shuffleClue;

    string condition = "";
    bool isTryAgain;

    int randomNum;

    public TMP_Text dialog;

    void Start()
    {
        // There are 3 things of killer and 3 things of victim and 3 AR Cards

        victimKillerThings = GameObject.Find("VictimAndKillerThings").GetComponent<VictimAndKillerThings>();
        arScript = GameObject.FindGameObjectWithTag("AR Script").GetComponent<ARScript>();
        generateNPC = GameObject.Find("GenerateNPC").GetComponent<GenerateNPC>();

        isTryAgain = true;
        shuffleClue = Random.Range(1, 5);
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (condition == "Victim Things") {
            for (int i = 0; i < showThings.Length; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < victimThings.Length; k++)
                    {
                        if (thingsClickedList[j].Replace("(Clone)", "") == victimThings[k] && showThings[i].name.Contains(thingsClickedList[j].Replace("(Clone)", "")) && thingsClickedList[j] != "")
                        {
                            showThings[i].SetActive(true);
                            //thingsClickedList[j] = "";
                            isTryAgain = false;
                        }
                    }
                }
            }

            if (isTryAgain)
            {
                ARCards();
            }

        }
        else if (condition == "Killer Things")
        {
            for (int i = 0; i < showThings.Length; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < killerThings.Length; k++)
                    {
                        if (thingsClickedList[j].Replace("(Clone)", "") == killerThings[k] && showThings[i].name.Contains(thingsClickedList[j].Replace("(Clone)", "")) && thingsClickedList[j] != "")
                        {
                            showThings[i].SetActive(true);
                            //thingsClickedList[j] = "";
                            isTryAgain = false;
                        }
                    }
                }
            }

            if (isTryAgain)
            {
                ARCards();
            }
        }
        else if (condition == "Killer Equipment")
        {
            for (int i=0; i < thingsClickedList.Length; i++)
            {
                if(thingsClickedList[i].Replace("(Clone)", "") == killerEquipment)
                {
                    foreach (GameObject things in showThings)
                    {
                        if (things.name.Contains(killerEquipment))
                        {
                            things.SetActive(true);
                            //thingsClickedList[i] = "";
                            isTryAgain = false;
                        }
                    }

                }

            }

            
            if (isTryAgain)
            {
                ARCards();
            }
            
        }
        
    }

    public void PasteThingsToFindObject(GameObject[] things, int count, string role)
    {
        
        for (int i = 0; i < count; i++)
        {
            switch (role)
            {
                case "Victim":
                    victimThings[i] = things[i].name;
                    if (count == 6 && i == 2)
                    {
                        role = "Killer";
                        i = -1;
                        count = 3;
                    }
                    break;
                case "Killer":
                    killerThings[i] = things[i].name;
                    break;
                case "KillerEquipment":
                    killerEquipment = things[victimKillerThings.killerEquipmentNumber].name;
                    break;
            }

        }
        
        

    }
    
    public void ARCards()
    {
        isTryAgain = true;

        randomNum = Random.Range(1, 6);

        switch (randomNum)
        {
            case 1:
                dialog.text = "A scene after the crime happened, Those things are from the victim";
                break;
            case 2:
                dialog.text = "A scene before the crime happened, Those things are from the victim";
                break;
            case 3:
                dialog.text = "A scene after the crime happened, Those are left from the killer";
                break;
            case 4:
                dialog.text = "A scene before the crime happened, Those things are from the killer";
                break;
            case 5:
                dialog.text = "That is the equipment used to kill the victim";
                break;
        }

        switch (randomNum)
        {
            case 1:
                condition = "Victim Things";
                VictimThingsWithTheKiller();
                break;
            case 2:
                condition = "Victim Things";
                VictimThingsWithTheVictim();
                break;
            case 3:
                condition = "Killer Things";
                KillerThingsWithTheVictim();
                break;
            case 4:
                condition = "Killer Things";
                KillerThingsWithTheKiller();
                break;
            case 5:
                condition = "Killer Equipment";
                KillerEquipmentInKillerBody();
                break;
        }

    }

    public void OnTargetLost()
    {
        light.pointLightOuterRadius = 0.1f;

        
        foreach (GameObject character in showNPC)
        {
            character.SetActive(false);
        }

        foreach (GameObject things in showThings)
        {
            things.SetActive(false);
        }
        
    }

    void ShuffleClue()
    {


    }

    public void ThingsClicked(string thingsName)
    {
        if (thingsName.Contains("Card"))
        {
            arScript.ARCardClicked(thingsName);
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (thingsClickedList[i] == "")
                {
                    thingsClickedList[i] = thingsName;
                    break;
                }
            }
        }

        

    }

    void KillerThingsWithTheVictim()
    {
        for (int i = 0; i < showNPC.Length; i++)
        {
            if (showNPC[i].name == generateNPC.victimName[0])
            {
                showNPC[i].SetActive(true);
            }
        }

        light.pointLightOuterRadius = 1f;
    }

    void VictimThingsWithTheKiller()
    {
        for (int i = 0; i < showNPC.Length; i++)
        {
            if (showNPC[i].name == generateNPC.killerName)
            {
                showNPC[i].SetActive(true);
            }
        }

        light.pointLightOuterRadius = 0.1f;
    }

    void VictimThingsWithTheVictim()
    {
        for (int i = 0; i < showNPC.Length; i++)
        {
            if (showNPC[i].name == generateNPC.victimName[0])
            {
                showNPC[i].SetActive(true);
            }
        }

        light.pointLightOuterRadius = 1f;
    }

    void KillerThingsWithTheKiller()
    {
        for (int i = 0; i < showNPC.Length; i++)
        {
            if (showNPC[i].name == generateNPC.killerName)
            {
                showNPC[i].SetActive(true);
            }
        }

        light.pointLightOuterRadius = 0.1f;
    }

    void KillerEquipmentInKillerBody()
    {
        

        light.pointLightOuterRadius = 0.1f;
    }



}
