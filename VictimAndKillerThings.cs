using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimAndKillerThings : MonoBehaviour
{
    public GameObject[] doctorThings;
    public GameObject[] policeThings;
    public GameObject[] civilianThings;
    public GameObject[] arCard;

    public GameObject[] killerEquipmentSpawn;

    public string killerEquipment;

    public GameObject spawnThings;
    public GameObject spawnClue;

    private GameObject generateNPC_GO;
    private GenerateNPC generateNPC_Script;

    public int killerEquipmentNumber;

    private FindObject findObject_Script;

    // Start is called before the first frame update
    void Start()
    {
        //spawnThings = GameObject.FindGameObjectWithTag("SpawnThings");
        //spawnClue = GameObject.FindGameObjectWithTag("SpawnClue");
        //generateNPC_GO = GameObject.Find("GenerateNPC");
        generateNPC_Script = GameObject.Find("GenerateNPC").GetComponent<GenerateNPC>();

        findObject_Script = GameObject.Find("Find Object").GetComponent<FindObject>();

        ShuffleThings();

        SpawnKillerEquipment();
        SpawnVictimThings();
        SpawnKillerThings();
        SpawnCards();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShuffleThings()
    {
        ShuffleGO(doctorThings);
        ShuffleGO(policeThings);
        ShuffleGO(civilianThings);
        //ShuffleGO(arCard);

    }

    void CopyThingsToFindObject(string role, int count, string type)
    {
        switch (role)
        {
            case "Police":
                findObject_Script.PasteThingsToFindObject(policeThings, count, type);
                break;
            case "Doctor":
                findObject_Script.PasteThingsToFindObject(doctorThings, count, type);
                break;
            case "Civilian":
                findObject_Script.PasteThingsToFindObject(civilianThings, count, type);
                break;
            //case "Cards":
              //  findObject_Script.PasteThingsToFindObject(arCard, count, type);
                //break;
            case "KillerEquipment":
                findObject_Script.PasteThingsToFindObject(killerEquipmentSpawn, count, type);
                break;
        }

    }

    void SpawnVictimThings()
    {
        int spawnVictimThingsCount = 3;

        if (generateNPC_Script.victimRole[0] == generateNPC_Script.killerRole)
            spawnVictimThingsCount = 6;
        
        SpawnThingsInRoom(generateNPC_Script.victimRole[0], spawnVictimThingsCount);
        CopyThingsToFindObject(generateNPC_Script.victimRole[0], spawnVictimThingsCount, "Victim");

    }

    void SpawnKillerThings()
    {
        int spawnKillerThingsCount = 3;
        
        if (generateNPC_Script.victimRole[0] == generateNPC_Script.killerRole)
            spawnKillerThingsCount = 0;

        SpawnThingsInRoom(generateNPC_Script.killerRole, spawnKillerThingsCount);
        CopyThingsToFindObject(generateNPC_Script.killerRole, spawnKillerThingsCount, "Killer");
    }

    void SpawnCards()
    {
        int spawnCardsCount = 8;

        SpawnThingsInRoom("Cards", spawnCardsCount);
        //CopyThingsToFindObject("Cards", spawnCardsCount, "Cards");
    }

    void SpawnKillerEquipment()
    {
        killerEquipmentNumber = Random.Range(0, killerEquipmentSpawn.Length);

        switch (killerEquipmentNumber)
        {
            case 0:
                killerEquipment = "Gun";
                break;
            case 1:
                killerEquipment = "Knife";
                break;
            case 2:
                killerEquipment = "Injection";
                break;
            case 3:
                killerEquipment = "Pills";
                break;
            case 4:
                killerEquipment = "Hammer";
                break;
            case 5:
                killerEquipment = "Samurai";
                break;
            case 6:
                killerEquipment = "Poison";
                break;
            case 7:
                killerEquipment = "Scissor";
                break;
            case 8:
                killerEquipment = "Punch";
                break;

        }

        SpawnThingsInRoom("Killer", 1);
        CopyThingsToFindObject( "KillerEquipment", 1, "KillerEquipment");
    }

    void SpawnThingsInRoom(string role, int count)
    {
        float positionRandom_x = 0f;
        float positionRandom_y = 0f;
        var position = new Vector3(0, 0, 0);
        
        float minimumPositionX = 0f;
        float maximumPositionX = 0f;
        float minimumPositionY = 0f;
        float maximumPositionY = 0f;

        for (int i = 0; i < count; i++)
        {
            int roomNumber = Random.Range(1, 3);
            
            switch (roomNumber)
            {
                case 1:
                    minimumPositionX = -61.5f;
                    maximumPositionX = -46f;
                    minimumPositionY = -31.2f;
                    maximumPositionY = -23f;
                    break;
                case 2:
                    minimumPositionX = -38f;
                    maximumPositionX = -21.5f;
                    minimumPositionY = -31.2f;
                    maximumPositionY = -23f;
                    break;
            }

            positionRandom_x = Random.Range(minimumPositionX, maximumPositionX + 1);
            positionRandom_y = Random.Range(minimumPositionY, maximumPositionY + 1);
            position = new Vector3(positionRandom_x, positionRandom_y, 0);

            switch (role)
            {
                case "Killer":
                    killerEquipmentSpawn[killerEquipmentNumber].transform.position = position;
                    Instantiate(killerEquipmentSpawn[killerEquipmentNumber], spawnThings.transform);
                    break;
                case "Police":
                    policeThings[i].transform.position = position;
                    Instantiate(policeThings[i], spawnThings.transform);
                    break;
                case "Doctor":
                    doctorThings[i].transform.position = position;
                    Instantiate(doctorThings[i], spawnThings.transform);
                    break;
                case "Civilian":
                    civilianThings[i].transform.position = position;
                    Instantiate(civilianThings[i], spawnThings.transform);
                    break;
                case "Cards":
                    arCard[i].transform.position = position;
                    Instantiate(arCard[i], spawnThings.transform);
                    break;
            }

        }
        
    }

    public void SpawnCardsAgain(string cardName)
    {
        float positionRandom_x = 0f;
        float positionRandom_y = 0f;
        var position = new Vector3(0, 0, 0);

        float minimumPositionX = 0f;
        float maximumPositionX = 0f;
        float minimumPositionY = 0f;
        float maximumPositionY = 0f;

        
        int roomNumber = Random.Range(1, 3);

        switch (roomNumber)
        {
            case 1:
                minimumPositionX = -61.5f;
                maximumPositionX = -46f;
                minimumPositionY = -31.2f;
                maximumPositionY = -23f;
                break;
            case 2:
                minimumPositionX = -38f;
                maximumPositionX = -21.5f;
                minimumPositionY = -31.2f;
                maximumPositionY = -23f;
                break;
        }

        positionRandom_x = Random.Range(minimumPositionX, maximumPositionX + 1);
        positionRandom_y = Random.Range(minimumPositionY, maximumPositionY + 1);
        position = new Vector3(positionRandom_x, positionRandom_y, 0);

        switch (cardName)
        {
            case "Find Object":
                arCard[0].transform.position = position;
                Instantiate(arCard[0], spawnThings.transform);
                break;
            case "Old Photograph":
                arCard[1].transform.position = position;
                Instantiate(arCard[1], spawnThings.transform);
                break;
            case "Past Sight":
                arCard[2].transform.position = position;
                Instantiate(arCard[2], spawnThings.transform);
                break;
            case "Trace Mark":
                arCard[3].transform.position = position;
                Instantiate(arCard[3], spawnThings.transform);
                break;
            case "Someone Say":
                arCard[4].transform.position = position;
                Instantiate(arCard[4], spawnThings.transform);
                break;
            case "Game Help":
                arCard[5].transform.position = position;
                Instantiate(arCard[5], spawnThings.transform);
                break;
            case "Victim Clue":
                arCard[6].transform.position = position;
                Instantiate(arCard[6], spawnThings.transform);
                break;
            case "Sketch":
                arCard[7].transform.position = position;
                Instantiate(arCard[7], spawnThings.transform);
                break;
            

        }

    }

    void ShuffleGO(GameObject[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = Random.Range(0, n);
            GameObject t = array[r];
            array[r] = array[n];
            array[n] = t;
        }
    }

}
