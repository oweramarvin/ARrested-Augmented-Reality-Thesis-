using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class GenerateDialog : MonoBehaviour
{
    public string[] dialogList_nonsense = new string[]
    {
        "Did you know that the moon is made of cheese? I tried tasting it once, but it was too far away.",
        "I have a pet unicorn named Gerald. He likes to eat rainbows and poop glitter.",
        "The world is flat and it's held up by giant turtles. I saw it in a dream last night.",
        "I can speak to trees, but they always talk back in riddles. It's very frustrating.",
        "My favorite hobby is knitting sweaters for invisible friends. They never complain about the size or the color.",
        "I used to be a superhero, but then I realized that villains are much more interesting. Plus, their outfits are cooler.",
        "I once tried to swim to the bottom of the ocean, but I got lost in a school of talking fish. They were very chatty.",
        "I'm convinced that time travel is possible. I just need to figure out how to reverse the polarity of the neutron flow.",
        "I have a collection of rocks that I talk to every day. They have really interesting stories to tell.",
        "I'm secretly a mermaid, but I can only transform when I'm in the bathtub. Don't tell anyone, it's a secret.",
        "Did you know that butterflies are just tiny fairies wearing butterfly wings as disguises? They're very good at hiding their magical powers.",
        "I once met a talking tree who gave me advice on how to become a unicorn. I'm still working on growing a horn.",
        "I have a pet rock that I take on walks. It's very good at playing dead when we encounter other rocks.",
        "I tried to bake a cake using moonbeams as the main ingredient, but it turned out to be too bright to eat. I ended up using it as a night light instead.",
        "I'm convinced that aliens exist and they're just waiting for us to invite them over for tea. Maybe they prefer coffee, though. I'll have to ask them.",
        "I have a dream of one day building a castle made entirely out of marshmallows. It might not be structurally sound, but it'll be delicious.",
        "I once had a conversation with a cloud, but it just kept drifting away mid-sentence. I guess it had better things to do.",
        "I can communicate with animals, but only if they're wearing hats. It's a strange gift, but it comes in handy sometimes.",
        "Greetings, traveler! Have you ever tasted the sound of a rainbow? It's like a symphony of flavors dancing on your tongue!",
        "Did you know that the clouds are made of cotton candy? I once tried to eat one and ended up with a mouthful of raindrops.",
        "I'm sorry, but I didn't see or hear anything that could help with the investigation. I wish I could be of more help.",
        "I don't feel comfortable discussing the situation. I think it's best if I don't get involved.",
        "I heard some noise earlier, but I didn't investigate. It could have been related to the crime, or it could have been something else entirely.",
        "I was out of town when the crime happened, so I have no information to offer.",
        "I'm not sure what happened, but I do know that the victim was a good person. They didn't deserve this.",
        "I don't want to speculate about what happened. It's important to let the police handle the investigation.",
        "I'm sorry, but I'm really not feeling well today. I don't think I can be of much help.",
        "I didn't see anything out of the ordinary, but I did hear some strange sounds coming from the victim's room earlier.",
        "I'm not comfortable sharing any information about the victim or the situation. I hope you understand.",
        "I didn't see anything, but I did notice that the victim was acting strangely in the days leading up to the crime."

    };
    string[] dialogList_lie = new string[]
    {
        "I can tell you for certain that victim died of natural causes.",
        "I was nearby when it occurred, but it was too dark to see who was involved. I'd rather not get involved.",
        "I was at home all night, so I couldn't have witnessed anything related to the murder.",
        "I saw a shadowy figure leaving the scene, but I couldn't make out any details. It all happened so quickly.",
        "I heard the victim was actually a secret agent who faked their own death to go undercover.",
        "The closer you get to the killer, the further you drift from the truth.",
        "The innocent whispers hold darker secrets than the guilty screams.",
        "Trust the untrustworthy, for their deceit leads to the ultimate truth.",
        "I saw a group of clowns leaving the scene of the crime. They were definitely up to something.",
        "The path to justice is paved with the footsteps of those who conceal it.",
        "The silence of the culprit speaks louder than the confession of the innocent.",
        "I heard the killer was actually a robot that malfunctioned and went on a killing spree.",
        "Listen closely, every word I utter is pure fabrication.",
        "I did see the victim arguing with someone earlier. It could have been maybe someone I knew.",
        "You can trust me, I am incapable of being truthful."

    };
    public string[] dialogList_truth = new string[]
    {
        "I see one of the  &killerRole wearing a &color &bodyParts later that day.",
        "I saw &killer leaving the building around &timeKillerHappen.",
        "I found &killerThings of the victim's shirt near the trash cans this &timeKillerHappen.",
        "Yesterday, I saw &victim talking to &fakeRole, it's look like &victim is happy and nothing to worry.",
        "I heard &killerRole running away from the scene of the crime.",
        "I saw the killer's shirt color &color",
        "I overheard one of the &killerRole planning to kill &victim.",
        "I saw the victim arguing with the &killerRole shortly before their death.",
        "I saw &killerRole sneaking around the victim's room before they died.",
        "I overheard &killerRole saying that they were going to get revenge for something that happened in the past.",
        "&killer has been avoiding &notKiller all day, and seemed nervous when they were in the same room together.",
        "I saw &killer and &lieName shaking hands and exchanging money earlier today.",
        "I saw the victim arguing with the person who always carries a &killerEquipment.",
        "&killerRole who always talks about &killerEquipment was acting strangely before the murder.",
        "&notKiller who always talks about &fakeEquipment are veryt alkative.",
        "The person who always carries a &killerEquipment was missing from the party this &timeKillerHappen.",
        "Believe me &lieName is telling a lie.",
        "I see some &victimThings from &killerRole",
        "I noticed the person who always have &killerThings trying to hide something after the murder.",
        "I see some &victimThings and &killerThings this &timeKillerHappen at the crime scene."
    };

    public string[] dialogList_story1_VictimFriendIsTheKiller = new string[]
    {
        "There are rumors circulating that someone close to the victim seemed to be acting strangely in the days leading up to the crime. Could there be a connection?",
        "I've heard whispers that a close friend of the victim had a complicated relationship with them.",
        "Some have suggested that the victim's friend was harboring feelings for them, leading to a messy and tragic situation.",
        "There are rumors that the victim's friend had a history of being possessive and controlling.",
        "I heard that the victim's friend was known for their impulsiveness and unpredictability.",
        "Some speculate that the victim's friend was struggling with their own personal demons at the time of the crime. ",
        "There are whispers that the victim's friend was in debt and desperate for money.",
        "I've heard that the victim's friend was struggling with jealousy and resentment toward the victim.",
        "There are rumors that the victim's friend had a history of violence, leading some to believe that they may have been involved in the crime.",
        "I heard whispers that the victim's friend was prone to outbursts of anger and aggression. "

    };
    public string[] dialogList_story2_YourFriendIsTheKiller = new string[]
    {
        "There are whispers going around that someone close to you may have had a motive to commit the crime.",
        "I've heard that &victim and your friend had a complicated history.",
        "Some have suggested that your friend had a secret that they were desperate to keep hidden.",
        "There are rumors that your friend was involved in some shady business dealings, leading some to believe that they may have been involved in the crime.",
        "I heard that your friend was struggling with addiction and financial troubles at the time of the crime.",
        "Some speculate that your friend was harboring feelings of jealousy and resentment toward &victim.",
        "There are whispers that your friend had a history of being impulsive and making rash decisions.",
        "I've heard that your friend was known for being hot-headed and quick to anger. Could their temper have gotten the best of them in a moment of weakness?",
        "There are rumors that your friend had a criminal record, leading some to believe that they may have been involved in the crime.",
        "I heard whispers that your friend had been acting strangely in the days leading up to the crime. Could this behavior be a sign that they were involved in what happened?",

    };
    public string[] dialogList_story3_Cheating = new string[]
    {
        "Whispers around town suggest that one of the lovers had a history of infidelity. ",
        "I heard that one of the lovers was extremely possessive and would often fly into fits of rage when they felt threatened. ",
        "Could the obsession have turned dangerous?",
        "Some say that the two lovers had a tumultuous relationship, with constant arguments and bouts of anger. ",
        "I've heard whispers that one of the lovers had a dark past, with a history of violence and aggression. Could this history have resurfaced and resulted in a tragic event?",
        "There are rumors that one of the lovers was prone to bouts of jealousy and possessiveness. Could this have led to a fatal mistake?",
        "Some say that one of the lovers had a hidden past, with secrets that they kept even from their partner. Could those secrets have been exposed?",
        "Whispers around town suggest that one of the lovers had a substance abuse problem. ",
        "I heard that one of the lovers had a history of mental health issues. Could a mental health crisis have led to a terrible mistake?",
        "Some speculate that the two lovers were involved in a love triangle, with a third person at the center of the drama. " +
            "Could the dynamics of the situation have led to something unexpected and deadly?",

    };
    public string[] dialogList_story4_DrugPusher = new string[]
    {
        "I heard from a reliable source that the victim owed a lot of money to someone involved in the drug trade.",
        "There's a theory going around that the victim's death was related to a drug deal gone wrong.",
        "The police found traces of an illegal substance in the victim's system during the autopsy.",
        "I heard that the victim was involved in buying and selling drugs, and may have been mixed up with some dangerous people.",
        "A witness reported seeing the victim arguing with a known drug dealer shortly before their death.",
        "The victim's cell phone records show that they frequently contacted someone known to be a drug dealer.",
        "There were signs of a struggle in the victim's apartment, and it's possible that they were attacked by someone trying to steal drugs or money.",
        "The victim had a reputation for being involved in the drug scene, and had been known to get into dangerous situations.",
        "I heard that the victim had recently cut ties with a drug dealer who was known for being violent and unpredictable.",
        "There were several empty drug baggies found near the victim's body, indicating that they may have been buying or selling drugs shortly before their death.",

    };
    public string[] dialogList_story5_DrugUser = new string[]
    {
        "I heard that the police found drug paraphernalia at the scene of the crime, which suggests that drugs may have been involved in the incident.",
        "There are rumors going around that the victim was involved in drug trafficking, and that their death may be related to that.",
        "A neighbor reported seeing a suspicious-looking person near the victim's apartment building who appeared to be under the influence of drugs.",
        "The victim had a history of drug addiction and was known to associate with other drug users and dealers.",
        "The police are investigating the possibility that the victim's death may be related to a drug deal gone wrong.",
        "A witness reported hearing an argument about drugs shortly before the victim's death.",
        "The victim had recently been arrested for drug possession, and it's possible that their death was related to their involvement in the drug trade.",
        "The autopsy revealed that the victim had recently used drugs, which may have contributed to their death.",
        "There were several known drug dealers and users in the area around the time of the murder.",
        "The police are exploring the possibility that the victim's death was related to a larger drug-related criminal enterprise.",

    };
    public string[] dialogList_story6_ThiefIsKiller = new string[]
    {
       "I overheard that the person who stole the victim's &victimThings had blood on their clothes later that night.",
       "The &killerEquipment was found in the same place where the stolen &victimThings was kept.",
       "A witness reported seeing someone leaving the scene of the crime with a bag that appeared to be filled &victimThings.",
       "Forensic analysis revealed that the DNA found on the &victimThings and at the crime scene belonged to the same person.",
       "The thief's alibi for the time of the murder doesn't check out.",
       "The thief was seen with a fresh scratch on their &bodyParts, which could have been caused by the victim fighting back.",
       "The stolen &victimThings was found near the crime scene, and it contained a weapon that matched the one used in the murder.",
       "The thief was found with the victim's wallet on their person.",
       "A surveillance camera captured the thief and the victim arguing just before the murder took place."

    };
    public string[] dialogList_story7_TheThiefIsDead = new string[]
    {
        "I heard that someone finally got what they deserved. The one who had been relentlessly pursued by the shadow of their past has finally found peace, knowing that justice has been served.",
        "There's a whisper going around that one of the city's most elusive troublemakers has met their end. ",
        "Rumor has it that their pursuer finally caught up with them and put an end to their reign of chaos.",
        "The streets are buzzing with news of a long-standing vendetta that has finally been resolved. The hunter has become the hunted, and justice has been served.",
        "It seems that someone has taken justice into their own hands. The one who had caused so much pain and suffering has met their demise, at the hands of the very person they wronged.",
        "Word on the street is that a notorious criminal has been taken out. The one who had been on the run for so long was finally caught by their relentless pursuer.",
        "It's a somber day for the criminal underworld, as news has spread of the untimely demise of one of their own. " +
            "The circumstances surrounding their death are hazy, but rumors suggest that their past finally caught up with them.",
        "A certain individual is no longer a threat to the community. Their pursuer, fueled by a deep sense of justice, finally brought them to justice.",
        "The shadows whisper of a hunter who finally caught their prey. The hunted, who had been on the run for so long, has finally met their end.",
        "The air is thick with rumors of a long-standing feud that has finally come to an end. The one who had been pursued for so long was finally caught by their determined opponent.",
        "It's a sad day for some, and a day of justice for others. The one who had caused so much pain and suffering has been silenced, by the very person they had wronged."

    };

    /*
    public string[] dialogList_scenario1_2truth2lie = new string[]
    {
        "It's a peculiar bunch, to be sure. Two of them have never told a lie, two of them couldn't tell the truth, and the others are a mystery to me.",
        "Well, well, well, what do we have here? Two of them are as honest as the day is long, two of them wouldn't know the truth if it smacked them in the face, and the rest are unknown to me.",
        "This is quite the society. Two of them have hearts of gold and wouldn't deceive a soul, two of them are about as trustworthy as a snake in the grass, and the others are total strangers.",
        "Let me see if I've got this straight. Two of them always tell the truth, two of them couldn't tell the truth if it meant saving their own skin, and the rest are complete unknowns to me.",
        "It's an interesting crew, no doubt about it. Two of them are honest to a fault, two of them couldn't tell the truth if their lives depended on it, and the others are a mystery to me."
    };
    public string[] dialogList_scenario2_AllLie = new string[]
    {
        "It's a tricky situation, because as far as I can tell, everyone in this society is a liar except for one lone soul who always tells the truth.",
        "I've seen my fair share of dishonest types, but this society takes the cake - they're all liars, except for one who seems to be the only one telling the truth.",
        "Believe me, you don't want to trust anyone in this society except for one individual who's an honest-to-goodness truth-teller - the rest of them are all lying through their teeth.",
        "I've never seen a more duplicitous bunch in my life - everyone in this society is a liar, except for one person who seems to be the only beacon of honesty.",
        "It's hard to know who to believe in a society like this, because every single one of them is a liar, except for one person who always seems to be truthful."
    };
    public string[] dialogList_scenario3_PointToOne = new string[]
    {
        "I hate to say it, but all signs seem to point to one person in this society - they're the only one who seems to have the motive, means, and opportunity.",
        "It's a difficult situation, but it's hard not to be suspicious of one particular person in this society they just seem to be acting a bit too cagey for my liking.",
        "I'm not one to jump to conclusions, but all the evidence seems to be pointing in one direction - and unfortunately, that direction leads straight to one particular person.",
        "It's not a comfortable feeling, but I have to admit that all my instincts are telling me to be wary of one individual in this society - they're just giving off too many red flags.",
        "I don't want to accuse anyone without proof, but it's hard not to be suspicious of one person in this society - everything seems to be pointing in their direction."
    };
    public string[] dialogList_scenario4_AllTrue1lie = new string[]
    {
        "This is a pretty honest society, but unfortunately, there seems to be one person who's not being entirely truthful - it's hard to say what their motive is.",
        "As far as I can tell, everyone in this group is being completely honest - except for one person who seems to be holding something back.",
        "It's a rare thing to find a group where everyone is telling the truth, but unfortunately, there's one person who's bucking that trend - and it's making things a bit difficult.",
        "I want to believe that everyone here is being truthful, but there's one person who's not quite measuring up - it's hard to know what to make of it.",
        "It's a bit of a mixed bag, but for the most part, everyone in this group is being truthful - except for one person who's a bit more elusive."
    };
    public string[] dialogList_scenario5_KillerTrueAllLie = new string[]
    {
        "Listen closely to the details in the killer's story.",
        "The killer's words may be the key to unlocking the truth.",
        "Only the killer's words align with the evidence.",
        "Don't ignore the killer's testimony - it holds the truth.",
        "The killer's statement is the missing piece of the puzzle."
    };
    public string[] dialogList_scenario6_AllStranger = new string[]
    {
        "Despite your best efforts to communicate your needs, it was clear from their responses that the others were just as clueless as you were.",
        "The group seemed to be in a state of collective amnesia, unable to recall anything about themselves or their circumstances.",
        "Every time you tried to engage someone in conversation, they seemed to be starting from scratch, lacking even the most basic information.",
        "As you looked around at the bewildered faces of the others, it became clear that no one possessed the knowledge or skills required to solve the problem at hand.",
        "With each passing moment, it became increasingly obvious that everyone in the group was equally helpless," +
            "and that there was no hope of finding a way out of the situation without outside assistance."
    };
    */

    public int tellingTheTruthCount;
    public int tellingTheLieCount;
    public int tellingNonsenseCount;

    public string[] tellingTheTruthName;
    public string[] tellingTheLieName;
    public string[] tellingNonsenseName;
    
    public string textToDialog;

    private GenerateStory generateStory_Script;
    private GenerateNPC GenerateNPC_Script;
    private VictimAndKillerThings victimAndKillerThings;

    public TMP_Text dialog;
    public TMP_Text dialogName;

    public Image spriteRenderer;
    public Sprite[] npcSprite;

    // Start is called before the first frame update
    void Start()
    {
        GameObject GenerateNPC_GO = GameObject.Find("GenerateNPC");
        GenerateNPC_Script = GenerateNPC_GO.GetComponent<GenerateNPC>();

        GameObject generateStory_GO = GameObject.Find("GenerateStory");
        generateStory_Script = generateStory_GO.GetComponent<GenerateStory>();
        
        ShuffleDialogList();
        ChangeSpecificValueOfDialog();

        victimAndKillerThings = GameObject.Find("VictimAndKillerThings").GetComponent<VictimAndKillerThings>();
        
        // The GenerateTellingTheTruthLieNonsense() function was already called at the start of GenerateStory Script.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DialogName(string name)
    {
        if (name.Replace("(Clone)", "") == GenerateNPC_Script.yourFriend) 
        {
            dialogName.text = name.Replace("(Clone)", "(Your friend)");
        }
        else
        {
            dialogName.text = name.Replace("(Clone)", "");
        }

        int spriteNum = 0;

        switch (name.Replace("(Clone)", ""))
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

    public void GenerateTellingTruth()
    {
        tellingTheTruthCount = GenerateNPC_Script.policeCount + GenerateNPC_Script.doctorCount + GenerateNPC_Script.civilianCount - tellingTheLieCount;

        string[] randomName = new string[tellingTheTruthCount];

        int i = 0;

        for (int j = 0; j < GenerateNPC_Script.policeCount; j++)
        {
            if(tellingTheLieName[0] != GenerateNPC_Script.policeName[j] && tellingTheLieName[1] != GenerateNPC_Script.policeName[j])
            {
                randomName[i] = GenerateNPC_Script.policeName[j];
                i++;
            }
        }
        for (int j = 0; j < GenerateNPC_Script.doctorCount; j++)
        {
            if (tellingTheLieName[0] != GenerateNPC_Script.doctorName[j] && tellingTheLieName[1] != GenerateNPC_Script.doctorName[j])
            {
                randomName[i] = GenerateNPC_Script.doctorName[j];
                i++;
            }
        }
        for (int j = 0; j < GenerateNPC_Script.civilianCount; j++)
        {
            if (tellingTheLieName[0] != GenerateNPC_Script.civilianName[j] && tellingTheLieName[1] != GenerateNPC_Script.civilianName[j])
            {
                randomName[i] = GenerateNPC_Script.civilianName[j];
                i++;
            }
        }

        // Shuffle randomName array
        for (i = 0; i < randomName.Length; i++)
        {
            int numTemp = Random.Range(0, randomName.Length);

            string nameTemp = randomName[i];
            randomName[i] = randomName[numTemp];
            randomName[numTemp] = nameTemp;
        }

        i = 0;

        /*  
         *  Telling the truth = 5
         *  Telling about story = 8
         *  Telling about scenario = 6
         */

        // Assigning telling the Truth Name
        for (int j = 0; j < tellingTheTruthCount; j++)
        {
            tellingTheTruthName[j] = randomName[j];
        }
    }

    public void GenerateTellingTheTruthLieNonsense()
    {
        // Get all name of police, doctor, and civilian
        string[] randomName = new string[GenerateNPC_Script.policeCount + GenerateNPC_Script.doctorCount + GenerateNPC_Script.civilianCount];
        
        int i = 0;

        for (int j = 0; j < GenerateNPC_Script.policeCount; j++)
        {
            randomName[i] = GenerateNPC_Script.policeName[j];
            i++;
        }
        for (int j = 0; j < GenerateNPC_Script.doctorCount; j++)
        {
            randomName[i] = GenerateNPC_Script.doctorName[j];
            i++;
        }
        for (int j = 0; j < GenerateNPC_Script.civilianCount; j++)
        {
            randomName[i] = GenerateNPC_Script.civilianName[j];
            i++;
        }

        // Shuffle randomName array
        for (i = 0; i < randomName.Length; i++)
        {
            int numTemp = Random.Range(0, randomName.Length);

            string nameTemp = randomName[i];
            randomName[i] = randomName[numTemp];
            randomName[numTemp] = nameTemp;
        }

        i = 0;

        /*  
         *  Telling the truth = 5
         *  Telling about story = 8
         *  Telling about scenario = 6
         */

        // Assigning telling the Truth Name
        for (int j = 0; j < randomName.Length; j++)
        {
            tellingTheTruthName[j] = randomName[i];
            i++;
        }

        tellingTheLieName[0] = GenerateNPC_Script.killerFriend;
        tellingNonsenseName[0] = GenerateNPC_Script.killerName;

        /*
        // Assigning telling the Lie Name
        for (int j = 0; j < tellingTheLieCount; j++)
        {
            tellingTheLieName[j] = randomName[i];
            i++;
        }

        // Assigning telling Nonsense Name
        for (int j = 0; j < tellingNonsenseCount; j++)
        {
            tellingNonsenseName[j] = randomName[i];
            i++;
        }
        */

    }

    void Shuffle(string[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = Random.Range(0, n);
            string t = array[r];
            array[r] = array[n];
            array[n] = t;
        }
    }

    public void Generate_Dialog(string name)
    {
        
        int i = 0;

        foreach (string nameList in tellingNonsenseName)
        {
            if (nameList + "(Clone)" == name)
            {
                dialog.text = dialogList_nonsense[i];
            }
            else
            {
                i++;
            }
        }

        i = 0;
        foreach (string nameList in tellingTheLieName)
        {
            if (nameList + "(Clone)" == name)
            {
                dialog.text = dialogList_lie[i];
            }
            else
            {
                i++;
            }
        }

        i = 0;
        foreach (string nameList in tellingTheTruthName)
        {
            if (nameList + "(Clone)" == name)
            {
                switch (generateStory_Script.storyNumber)
                {
                    case 1:
                        dialog.text = dialogList_story1_VictimFriendIsTheKiller[i];
                        break;
                    case 2:
                        dialog.text = dialogList_story2_YourFriendIsTheKiller[i];
                        break;
                    case 3:
                        dialog.text = dialogList_story3_Cheating[i];
                        break;
                    case 4:
                        dialog.text = dialogList_story4_DrugPusher[i];
                        break;
                    case 5:
                        dialog.text = dialogList_story5_DrugUser[i];
                        break;
                    case 6:
                        dialog.text = dialogList_story6_ThiefIsKiller[i];
                        break;
                    case 7:
                        dialog.text = dialogList_story7_TheThiefIsDead[i];
                        break;
                }
                
            }
            else
            {
                i++;
            }
        }

    }

    void ChangeSpecificValueOfDialog()
    {
        ChangeDialogValue(dialogList_nonsense);
        ChangeDialogValue(dialogList_lie);
        ChangeDialogValue(dialogList_truth);

    }

    void ChangeDialogValue(string[] array)
    {
        /*  Inspector change value of string
                 * 
                 *  &victim = victim name
                 *  &yourfriend = killer
                 *  &victimfriend = killer
                 *  &killer = killer
                 *  &victimThings = stolen or victim accesories, wear, etc
                 *  &killerThings = killer wear, accessories, or what
                 *  &killerEquipment = killer weapon
                 *  &bodyParts = for blood, tattoo, or wearing
                 *  &fakeEquipment = fake killer weapon
                 *  &fakeRole = fake NPC role, not the killer role
                 *  &killerRole = killer role
                 *  &notKiller = not the killer name
                 *  &isLefthanded = left-handed or right-handed
                 *  &color = killer color either shirt or what
                 *  &timeKillerHappen = morning, afternoon, night
                 *  &lieName = one of telling the lie
                 */

        for(int i=0; i < array.Length; i++)
        {
            array[i].Replace("&victim", GenerateNPC_Script.victimName[0]);
            array[i].Replace("&yourfriend", GenerateNPC_Script.killerName);
            array[i].Replace("&victimfriend", GenerateNPC_Script.killerName);
            array[i].Replace("&killer", GenerateNPC_Script.killerName);
            //array[i].Replace("&victimThings", GenerateNPC_Script.killerName);
            //array[i].Replace("&killerThings", GenerateNPC_Script.killerName);
            //array[i].Replace("&killerEquipment", victimAndKillerThings.killerEquipment);


        }

    }

    void ShuffleDialogList()
    {
        Shuffle(dialogList_truth);
        Shuffle(dialogList_lie);
        Shuffle(dialogList_nonsense);
        Shuffle(dialogList_story1_VictimFriendIsTheKiller);
        Shuffle(dialogList_story2_YourFriendIsTheKiller);
        Shuffle(dialogList_story3_Cheating);
        Shuffle(dialogList_story4_DrugPusher);
        Shuffle(dialogList_story5_DrugUser);
        Shuffle(dialogList_story6_ThiefIsKiller);
        Shuffle(dialogList_story7_TheThiefIsDead);
        /*
        Shuffle(dialogList_scenario1_2truth2lie);
        Shuffle(dialogList_scenario2_AllLie);
        Shuffle(dialogList_scenario3_PointToOne);
        Shuffle(dialogList_scenario4_AllTrue1lie);
        Shuffle(dialogList_scenario5_KillerTrueAllLie);
        Shuffle(dialogList_scenario6_AllStranger);
        */
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

    

}
