using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateKillerEquipment : MonoBehaviour
{
    public GameObject[] killerEquipmentSpawn;
    private int killerEquipmentNumber;
    public string killerEquipment;

    private GameObject spawnKillerEquipment;
    private GameObject spawnClue;

    public GameObject[] clueFindObjectSpawn;
    
    public int[] randomObjectClue;
    // Start is called before the first frame update
    void Start()
    {
        spawnKillerEquipment = GameObject.FindGameObjectWithTag("SpawnKillerEquipment");
        spawnClue = GameObject.FindGameObjectWithTag("SpawnClue");

        SpawnKillerEquipment();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnKillerEquipment()
    {
        float positionRandom_x = 0f;
        float positionRandom_y = 0f;
        var position = new Vector3(0, 0, 0);

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

        /* Killer Equipment
         * 0. Gun
         * 1. Knife
         * 2. Injection
         * 3. Pills
         * 4. Hammer
         * 5. Samurai
         * 6. Poison
         * 7. Scissor
         * 8. Punch
         */

        int insideNumber = Random.Range(1, 4);
        float minimumPositionX = 0f;
        float maximumPositionX = 0f;
        float minimumPositionY = 0f;
        float maximumPositionY = 0f;

        int randomObjectClueCount = Random.Range(6, 11);
        //int[] randomObjectClue = new int[randomObjectClueCount];

        for (int i = 0; i < randomObjectClueCount; i++)
        {
            randomObjectClue[i] = Random.Range(0, 24);

            for (int j = 0; j < i; j++)
            {
                if (randomObjectClue[i] == randomObjectClue[j])
                {
                    i--;
                }
            }
        }

        for (int i = 0; i <= randomObjectClueCount; i++)
        {

            switch (insideNumber)
            {
                case 1:
                    minimumPositionX = -62f;
                    maximumPositionX = -45f;
                    minimumPositionY = -31f;
                    maximumPositionY = -23f;
                    break;
                case 2:
                    minimumPositionX = -38f;
                    maximumPositionX = -21f;
                    minimumPositionY = -31f;
                    maximumPositionY = -23f;
                    break;
                case 3:
                    minimumPositionX = -14f;
                    maximumPositionX = 3f;
                    minimumPositionY = -31f;
                    maximumPositionY = -23f;
                    break;
                case 4:
                    minimumPositionX = -62f;
                    maximumPositionX = -45f;
                    minimumPositionY = -45f;
                    maximumPositionY = -37f;
                    break;
                case 5:
                    minimumPositionX = -38f;
                    maximumPositionX = -21f;
                    minimumPositionY = -45f;
                    maximumPositionY = -37f;
                    break;
                case 6:
                    minimumPositionX = -14f;
                    maximumPositionX = 3f;
                    minimumPositionY = -45f;
                    maximumPositionY = -37f;
                    break;

            }

            positionRandom_x = Random.Range(minimumPositionX, maximumPositionX + 1);
            positionRandom_y = Random.Range(minimumPositionY, maximumPositionY + 1);
            position = new Vector3(positionRandom_x, positionRandom_y, 0);

            if (i == 0)
            {
                killerEquipmentSpawn[killerEquipmentNumber].transform.position = position;
              //  Instantiate(killerEquipmentSpawn[killerEquipmentNumber], spawnKillerEquipment.transform);
            }
            else
            {
                clueFindObjectSpawn[randomObjectClue[i - 1]].transform.position = position;
               // Instantiate(clueFindObjectSpawn[randomObjectClue[i - 1]], spawnClue.transform);
            }
        }
    }
}
