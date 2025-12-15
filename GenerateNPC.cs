using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNPC : MonoBehaviour
{
    public GameObject[] deadBodySpawn;
    public GameObject[] policeSpawn;
    public GameObject[] doctorSpawn;
    public GameObject[] civilianSpawn;

    public int dayTime;

    
    public string[] policeName;
    public string[] doctorName;
    public string[] civilianName;

    public string victimFriend;
    public string killerFriend;
    public string yourFriend;

    public string[] victimRole;
    public string[] victimName;

    public string killerName;
    public string killerRole;

    // Characters including (victim, suspect, normal human, police, doctor, )
    public int victimCount; // 1 or 2
    public int policeCount; // 2 or 3 (SPO1, SPO2, SPO3)
    public int doctorCount; // 2 or 3 (Eric Crosby, Julia Potts, Ricky Moses)
    public int civilianCount;   // 4-6 (Eden Nash, Yasmine Alvarado, Tilly Jacobson, Leila Juarez, Zach Murphy, Albert Le)
    public int killerCount; // Only 1 (You need to guess)

    public int crimeNumber;
    
    public string isAllyOrNot; // "Friend" "Stranger" "Liar"

    //public string textToDialog;

    
    /*
    public int storyNumber; // Goal: atleast 5
    public string[] story;
    public int scenarioNumber;
    public string[] scenario;
    */
    private GenerateDialog generateDialog_Script;

    /*
    public int tellingTheTruthCount;
    public int tellingTheLieCount;
    public int tellingNonsenseCount;
    public string[] tellingTheTruthName;
    public int[] tellingTheTruthNumber;
    public string[] tellingTheLieName;
    public int[] tellingTheLieNumber;
    public string[] tellingNonsenseName;
    public int[] tellingNonsenseNumber;
    */

    public int clueCount;   /* CLUE 10-15 (random)
                             * 
                             * 1. Find image (random object which can see in the AR and need to fing in game like criminal case (random object or puzzle *pag pinagsama sama may mabubuo*) 
                             * 2. Old photograph (Random character, random how many *2-5*, show their emotion, show some clue on how they interact)
                       x     * 3. Future sight (Ex. Person2 will die later, Random person will change position *EX. A killer/civilian/suspect will face/change other direction/position, what will they do) 
                             * 4. Past sight (EX. You will see knife/gun/sakal or on how the murderer kill its victim
                             * 5. Trace Mark (Blood print, footprint)
                       x     * 6. randomPerson1, randomPerson2, 
                       x     * 7. relativeSay (always true except if you found out that he/she is not your really relative. Ex. There are 2 person introduce that they are your mother, so one is lying)
                            * 8. someoneSay (Can be true or false)
                             * 9. Secret Intel (choose 2 or 3 person, then you will know what is their role, what they are doing 
                             * 10. Victim clue (last word, concealed clues on the victim body *bullet, knife, etc*, money, note, jewelry, what is victim wearing, )
                             * 11. Sketch of the murderer
                             * 12. Time
                             */

    

    bool[] clue = new bool[13];

    private GameObject spawnNPC;
    
    private VictimAndKillerThings victimAndKillerThings_Script;
    private GenerateStory generateStory_Script;
    private PoliceScript policeScript;

    int civilianRandom;
    int policeRandom;
    int doctorRandom;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(prefab, transform.position, Quaternion.identity);
        spawnNPC = GameObject.FindGameObjectWithTag("SpawnNPC");

        GameObject generateDialog_GO = GameObject.Find("GenerateDialog");
        generateDialog_Script = generateDialog_GO.GetComponent<GenerateDialog>();

        GameObject generateStory_GO = GameObject.Find("GenerateStory");
        generateStory_Script = generateStory_GO.GetComponent<GenerateStory>();

        GameObject victimAndKillerThings__GO = GameObject.Find("VictimAndKillerThings");
        victimAndKillerThings_Script = victimAndKillerThings__GO.GetComponent<VictimAndKillerThings>();
        policeScript = GameObject.Find("Police Script").GetComponent<PoliceScript>();

        dayTime = 1;

        GenerateVictim();
        SpawnNPC();
        GenerateKiller();



        //GenerateStory();
        //GenerateDialog();
        //SpawnClue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateFriend()
    {
        Debug.Log("AAAAAAA: " + generateStory_Script.storyNumber);
        switch (generateStory_Script.storyNumber)
        {
            case 1:
                victimFriend = killerName;
                yourFriend = GenerateRandomNameReveal();
                do
                {
                    killerFriend = GenerateRandomNameReveal();
                } while (killerFriend == killerName);

                generateDialog_Script.tellingTheLieName[0] = killerFriend;
                generateDialog_Script.tellingTheLieName[1] = victimFriend;
                generateDialog_Script.tellingTheLieCount = 2;
                // Give clue if victim friend == your friend || victim friend == killer friend
                break;
            case 2:
                yourFriend = killerName;
                victimFriend = GenerateRandomNameReveal();
                do
                {
                    killerFriend = GenerateRandomNameReveal();
                } while (killerFriend == yourFriend || killerFriend == victimFriend);

                generateDialog_Script.tellingTheLieName[0] = yourFriend;
                generateDialog_Script.tellingTheLieName[1] = killerFriend;
                generateDialog_Script.tellingTheLieCount = 2;

                break;
            default:
                do
                {
                    killerFriend = GenerateRandomNameReveal();
                } while (killerFriend == killerName);
                yourFriend = GenerateRandomNameReveal();
                victimFriend = GenerateRandomNameReveal();

                generateDialog_Script.tellingTheLieName[0] = killerFriend;
                generateDialog_Script.tellingTheLieName[1] = killerName;
                generateDialog_Script.tellingTheLieCount = 2;

                break;
        }

        policeScript.answerCorrect[3] = killerFriend;

    }

    void GenerateVictim()
    {
        // Random.Range (minimum, maximum + 1)
        victimCount = Random.Range(1, 3);
        civilianCount = Random.Range(civilianSpawn.Length - 2, civilianSpawn.Length);
        policeCount = Random.Range(policeSpawn.Length - 1, policeSpawn.Length);
        doctorCount = Random.Range(doctorSpawn.Length - 1, doctorSpawn.Length);

        a:

        //For temporary
        victimCount = 1;

        // Randomizing Victim
        for (int i = 0; i < victimCount; i++)
        {
            int victimRoleRandom = Random.Range(1, 4);

            switch (victimRoleRandom)
            {
                case 1:
                    victimRole[i] = "Civilian";
                    if(generateStory_Script.storyNumber != 1)
                        civilianCount--;
                    break;
                case 2:
                    victimRole[i] = "Police";
                    if (generateStory_Script.storyNumber != 1)
                        policeCount--;
                    break;
                case 3:
                    victimRole[i] = "Doctor";
                    if (generateStory_Script.storyNumber != 1)
                        doctorCount--;
                    break;
            }
            GenerateRandomName(i, true, false, victimRole[i]);
        }

        for (int i = 0; i < victimCount - 1; i++)
        {
            if (victimName[i] == victimName[i + 1])
                goto a;
        }
    }

    void GenerateKiller()
    {
        int countTemp = 0;
        string[] nameTempForKiller = civilianName;
        killerCount = 1;

        generateKillerAgain:

        // Randomizing Killer
        for (int i = 0; i < killerCount; i++)
        {
            int killerRoleRandom = Random.Range(1, 4);

            switch (killerRoleRandom)
            {
                case 1:
                    killerRole = "Civilian";
                    countTemp = civilianCount;
                    nameTempForKiller = civilianName;
                    break;
                case 2:
                    killerRole = "Police";
                    countTemp = policeCount;
                    nameTempForKiller = policeName;
                    break;
                case 3:
                    killerRole = "Doctor";
                    countTemp = doctorCount;
                    nameTempForKiller = doctorName;
                    break;
            }
            GenerateRandomName(0, false, false, killerRole);

            for(int j = 0; j < countTemp; j++)
            {
                if (killerName == nameTempForKiller[j])
                    break;
                else if (j == countTemp - 1)
                    goto generateKillerAgain;
            }
        }

    }

    void GenerateRandomName(int i, bool isVictim, bool isNPC, string role)
    {
        string tempName = "aaa";

        if((role == "Civilian" && isVictim && !isNPC) || (role == "Civilian" && !isVictim && !isNPC) || (role == "Civilian" && isNPC))
        {
            civilianRandom = Random.Range(0, 6);
            switch (civilianRandom)
            {
                case 0:
                    tempName = "Bino";
                    break;
                case 1:
                    tempName = "Fauni";
                    break;
                case 2:
                    tempName = "Hazel";
                    break;
                case 3:
                    tempName = "Jomar";
                    break;
                case 4:
                    tempName  = "Lian";
                    break;
                case 5:
                    tempName = "Yam";
                    break;
            }
        }
        else if((role == "Police" && isVictim && !isNPC) || (role == "Police" && !isVictim && !isNPC) || (role == "Police" && isNPC))
        {
            policeRandom = Random.Range(0, 3);
            switch (policeRandom)
            {
                case 0:
                    tempName = "SPO1";
                    break;
                case 1:
                    tempName = "SPO2";
                    break;
                case 2:
                    tempName = "SPO3";
                    break;
            }
        }
        else if((role == "Doctor" && isVictim && !isNPC) || (role == "Doctor" && !isVictim && !isNPC) || (role == "Doctor" && isNPC))
        {
            doctorRandom = Random.Range(0, 3);
            switch (doctorRandom)
            {
                case 0:
                    tempName = "Lee";
                    break;
                case 1:
                    tempName = "Lanie";
                    break;
                case 2:
                    tempName = "Dolores";
                    break;
            }
        }

        if (isNPC)
        {
            if(role == "Civilian")
            {
                civilianName[i] = tempName;
            }
            else if(role == "Police")
            {
                policeName[i] = tempName;
            }
            else if(role == "Doctor")
            {
                doctorName[i] = tempName;
            }
        }
        else if (isVictim)
        {
            victimName[i] = tempName;
        }
        else if(!isVictim)
        {
            killerName = tempName;
        }
            

    }

    void SpawnNPC()
    {
        float positionRandom_x = 0f;
        float positionRandom_y = 0f;
        var position = new Vector3(0,0,0);
        /*
        for (int i = 0; i < victimCount; i++)
        {
        
            positionRandom_x = Random.Range(63, 226);
            positionRandom_y = -2.7f;


            position = new Vector3(positionRandom_x, positionRandom_y, 0);
            deadBodySpawn[i].transform.position = position;
            Instantiate(deadBodySpawn[i], spawnNPC.transform);
        }
        */
        for (int i = 0; i < civilianCount; i++)
        {
            //int randTemp = Random.Range(1, 3);
            bool isDuplicateName = false;

            positionRandom_x = Random.Range(63, 226);
            positionRandom_y = -2.7f;


            GenerateRandomName(i, false, true, "Civilian");
            if(civilianName[i] == victimName[0] && generateStory_Script.storyNumber != 1)
            {
                i--;
                isDuplicateName = true;
            }
            else
            {
                for (int j = 0; j < i; j++)
                {
                    if (civilianName[j] == civilianName[i])
                    {
                        i--;
                        isDuplicateName = true;
                    }
                }
            }

            if (!isDuplicateName)
            {
                position = new Vector3(positionRandom_x, positionRandom_y, 0);
                civilianSpawn[civilianRandom].transform.position = position;
                Instantiate(civilianSpawn[civilianRandom], spawnNPC.transform);
            }
        }

        for (int i = 0; i < doctorCount; i++)
        {
            int randTemp = Random.Range(1, 3);
            bool isDuplicateName = false;

            positionRandom_x = Random.Range(63, 226);
            positionRandom_y = -2.7f;

            GenerateRandomName(i, false, true, "Doctor");
            if (doctorName[i] == victimName[0] && generateStory_Script.storyNumber != 1)
            {
                i--;
                isDuplicateName = true;
            }
            else
            {
                for (int j = 0; j < i; j++)
                {
                    if (doctorName[j] == doctorName[i])
                    {
                        i--;
                        isDuplicateName = true;
                    }
                }
            }

            if (!isDuplicateName)
            {
                position = new Vector3(positionRandom_x, positionRandom_y, 0);
                doctorSpawn[doctorRandom].transform.position = position;
                Instantiate(doctorSpawn[doctorRandom], spawnNPC.transform);
            }
                
        }

        for (int i = 0; i < policeCount; i++)
        {
            int randTemp = Random.Range(1, 3);
            bool isDuplicateName = false;

            positionRandom_x = Random.Range(63, 226);
            positionRandom_y = -2.7f;

            GenerateRandomName(i, false, true, "Police");
            if(policeName[i] == victimName[0] && generateStory_Script.storyNumber != 1)
            {
                i--;
                isDuplicateName = true;
            }
            else
            {
                for (int j = 0; j < i; j++)
                {
                    if (policeName[j] == policeName[i])
                    {
                        i--;
                        isDuplicateName = true;
                    }
                }
            }
            
            if (!isDuplicateName)
            {
                position = new Vector3(positionRandom_x, positionRandom_y, 0);
                policeSpawn[policeRandom].transform.position = position;
                Instantiate(policeSpawn[policeRandom], spawnNPC.transform);
            }
        }
    }

    public string GenerateRandomNameReveal()
    {
        string nameReveal = "Sample Name";
        int randomRole = Random.Range(1, 4); // Police, Doctor, Civilian
        int randomCount = 0;

        switch (randomRole)
        {
            case 1:
                randomCount = Random.Range(0, policeCount);
                nameReveal = policeName[randomCount];
                break;
            case 2:
                randomCount = Random.Range(0, doctorCount);
                nameReveal = doctorName[randomCount];
                break;
            case 3:
                randomCount = Random.Range(0, civilianCount);
                nameReveal = civilianName[randomCount];
                break;
        }

        return nameReveal;
    }

    void GenerateOldPhotograph()
    {
        /*
         *  Old Photograph
         * 
         *  1. The killer is at the back of victim, looking angry
         *  2. The killer with his/her equipment
         *  3. The killer is with the liar
         *  4. Two random people showing their role (friend, stranger, or what)
         *  5. Three random people
         * 
         */

        int randomOldPhotograph = Random.Range(1, 6);

        switch (randomOldPhotograph)
        {
            case 1:
                // Instantiate killer at the back of the victim
                break;
            case 2:
                // Instantiate killer and his/her equipment
                break;
            case 3:
                // Instantiate killer and his/her friend/lover/partner
                break;
            case 4:
                // Instantiate 2 people and show their emotion as what's their role
                break;
            case 5:
                // Instantiate 3 people and show their emotion as what's ther role
                break;

        }

        int humanRole;
        int[] imageIndex = new int[3];
        bool[] isKiller = new bool[3];
        int humanInThePictureCount;

        humanInThePictureCount = Random.Range(2, 4);

        for (int i = 0; i < humanInThePictureCount; i++)
        {
            imageIndex[i] = Random.Range(0, policeCount + doctorCount + civilianCount);



            humanRole = Random.Range(1, 4);

            switch (humanRole)
            {
                case 1:
                    imageIndex[i] = Random.Range(0, policeCount);
                    if(policeName[imageIndex[i]] == killerName)
                    {
                        isKiller[i] = true;
                    }
                    break;
                case 2:
                    imageIndex[i] = Random.Range(0, doctorCount);
                    if (doctorName[imageIndex[i]] == killerName)
                    {
                        isKiller[i] = true;
                    }
                    break;
                case 3:
                    imageIndex[i] = Random.Range(0, civilianCount);
                    if (civilianName[imageIndex[i]] == killerName)
                    {
                        isKiller[i] = true;
                    }
                    break;
            }
        }


    }

    
}
