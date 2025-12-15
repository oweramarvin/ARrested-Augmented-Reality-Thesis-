using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PoliceScript : MonoBehaviour
{
    public int score;
    public GameObject canvas;
    public TMP_Text congratsLabel;
    public TMP_Text question;
    public TMP_Text answer1;
    public TMP_Text answer2;

    public TMP_Text[] npcName;

    public GameObject insidePoliceStation;
    public string[] questionList = new string[6];
    public string[] answerCorrect = new string[5];
    public string[] answerWrong = new string[5];

    int questionCount;
    bool isButton1;

    public GameObject isTheKillerGO;
    public Image killerFace;
    public TMP_Text killerNameText;

    public GameObject inputfield;
    public GameObject questionGO;
    public GameObject starGO;
    public GameObject[] star;
    public GameObject continueButton;
    public GameObject ExitButton;
    public GameObject Answer;
    public GameObject NPC;
    public Image[] image;
    public Sprite[] npcSprite;
    string[] suspect = new string[5];
    int spriteNum = 0;
    int killerPosition;

    private GenerateNPC generateNPC;

    string[] npcNameArray = new string[12];

    public AudioSource correctWrong;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        questionCount = 0;
        isButton1 = true;

        generateNPC = GameObject.Find("GenerateNPC").GetComponent<GenerateNPC>();
        continueButton.SetActive(false);
        ExitButton.SetActive(false);
        canvas.SetActive(false);
        inputfield.SetActive(false);

        killerPosition = Random.Range(0, 5);

        KillerFriend();
        ShuffleName();

        // question1 = old photograph
        // question2 = trace mark
        // question3 = sketch
        // question4 = killer friend
        // question5 = about story

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterPoliceStation()
    {
        canvas.SetActive(true);
        AnswerTheQuestion();

    }

    public void PoliceStationContinue()
    {
        insidePoliceStation.SetActive(false);
    }

    void PlaySoundInterval(AudioSource audioName, float fromSeconds, float toSeconds)
    {
        audioName.time = fromSeconds;
        audioName.Play();
        audioName.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));

    }

    public void CommentButton()
    {
        inputfield.SetActive(true);
    }

    public void InputfieldButton()
    {
        inputfield.SetActive(false);
    }

    void ShuffleName()
    {
        npcNameArray[0] = "Bino";
        npcNameArray[1] = "Fauni";
        npcNameArray[2] = "Hazel";
        npcNameArray[3] = "Jomar";
        npcNameArray[4] = "Lian";
        npcNameArray[5] = "Yam";
        npcNameArray[6] = "Dolores";
        npcNameArray[7] = "Lanie";
        npcNameArray[8] = "Lee";
        npcNameArray[9] = "SPO1";
        npcNameArray[10] = "SPO2";
        npcNameArray[11] = "SPO3";

        for (int i = 0; i < npcNameArray.Length; i++)
        {
            int numTemp = Random.Range(0, npcNameArray.Length);

            string nameTemp = npcNameArray[i];
            npcNameArray[i] = npcNameArray[numTemp];
            npcNameArray[numTemp] = nameTemp;
        }
    }

    string GenerateRandomName()
    {
        int randomNum = Random.Range(1, 13);
        string name = "aaa";

        switch (randomNum)
        {
            case 1:
                name = "Bino";
                break;
            case 2:
                name = "Fauni";
                break;
            case 3:
                name = "Hazel";
                break;
            case 4:
                name = "Jomar";
                break;
            case 5:
                name = "Lian";
                break;
            case 6:
                name = "Yam";
                break;
            case 7:
                name = "Dolores";
                break;
            case 8:
                name = "Lanie";
                break;
            case 9:
                name = "Lee";
                break;
            case 10:
                name = "SPO1";
                break;
            case 11:
                name = "SPO2";
                break;
            case 12:
                name = "SPO3";
                break;
        }

        return name;
    }

    void KillerFriend()
    {

        //answerCorrect[3] = generateNPC.killerFriend; is in the GenerateNPC Script
        //answerWrong[3] = generateNPC.GenerateRandomNameReveal();

        questionList[3] = "who is the friend of the killer?";
        
        do
        {
            answerWrong[3] = GenerateRandomName();
        } while (answerCorrect[3] == answerWrong[3]);
        
    }

    void AnswerTheQuestion()
    {
        question.text = questionList[questionCount];

        int randomNum = Random.Range(1, 3);
        
        switch (randomNum)
        {
            case 1:
                answer1.text = answerCorrect[questionCount];
                answer2.text = answerWrong[questionCount];
                isButton1 = true;
                break;
            case 2:
                answer2.text = answerCorrect[questionCount];
                answer1.text = answerWrong[questionCount];
                isButton1 = false;
                break;
        }
        
    }

    void Congrats()
    {
        Debug.Log("Congratulations");
        questionGO.SetActive(false);
        starGO.SetActive(true);

        congratsLabel.text = "Congratulations!";

        if (score == 5)
        {
            for (int i=0; i<3; i++)
            {
                star[i].SetActive(true);
            }
        }
        else if (score == 4)
        {
            for (int i = 0; i < 2; i++)
            {
                star[i].SetActive(true);
            }
        }
        else if (score == 3)
        {
            for (int i = 0; i < 1; i++)
            {
                star[i].SetActive(true);
            }
        }
        else
        {
            Failed();
            congratsLabel.text = "Lack of evidence";
        }

        continueButton.SetActive(true);
        ExitButton.SetActive(true);



    }

    void Failed()
    {
        Debug.Log("You are failed");
        questionGO.SetActive(false);
        starGO.SetActive(true);
        continueButton.SetActive(true);
        ExitButton.SetActive(true);

        isTheKillerGO.SetActive(true);

        killerNameText.text = generateNPC.killerName;

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

        killerFace.sprite = npcSprite[spriteNum];
        congratsLabel.text = "You accused wrong person!";
    }

    public void Answer1()
    {
        if (isButton1)
        {
            if (questionCount != 5)
            {
                score++;
                PlaySoundInterval(correctWrong, 2f, 4f);
            }
            else
            {
                Congrats();
                PlaySoundInterval(correctWrong, 2f, 4f);
            }
            
        }
        else if (questionCount == 5)
        {
            Failed();
        }
        else
        {
            PlaySoundInterval(correctWrong, 4f, 6f);
        }

        questionCount++;

        if (questionCount < 5)
        {
            AnswerTheQuestion();
        }
        else
        {
            LastQuestion();
        }
        
    }

    public void Answer2()
    {
        if (!isButton1)
        {
            if (questionCount != 5)
            {
                score++;
                PlaySoundInterval(correctWrong, 2f, 4f);
            }
            else
            {
                Congrats();
                PlaySoundInterval(correctWrong, 2f, 4f);
            }
        }
        else if (questionCount == 5)
        {
            Failed();
        }
        else
        {
            PlaySoundInterval(correctWrong, 4f, 6f);
        }

        questionCount++;

        if (questionCount < 5)
        {
            AnswerTheQuestion();
        }
        else
        {
            LastQuestion();
        }
    }

    void NPC_Sprite(string name)
    {
        

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

    }

    void LastQuestion()
    {
        string correctAnswer = generateNPC.killerName;

        question.text = "Who is the killer?";
        Answer.SetActive(false);
        NPC.SetActive(true);
        
        suspect[killerPosition] = correctAnswer;

        for (int i=0; i<5; i++)
        {
            if (i == killerPosition)
            {
                suspect[i] = correctAnswer;
            }
            else
            {
                suspect[i] = npcNameArray[i];
            }
            
            if (suspect[i] == suspect[killerPosition] && i != killerPosition)
            {
                suspect[i] = npcNameArray[5];
            }
            
        }

        for (int i=0; i<5; i++)
        {
            NPC_Sprite(suspect[i]);
            npcName[i].text = npcSprite[spriteNum].name;
            image[i].sprite = npcSprite[spriteNum];
        }

    }

    public void Option1()
    {
        if (killerPosition == 0)
        {
            PlaySoundInterval(correctWrong, 3f, 4f);
            Congrats();
        }
        else
        {
            PlaySoundInterval(correctWrong, 5f, 6f);
            Failed();
        }
    }

    public void Option2()
    {
        if (killerPosition == 1)
        {
            PlaySoundInterval(correctWrong, 3f, 4f);
            Congrats();
        }
        else
        {
            PlaySoundInterval(correctWrong, 5f, 6f);
            Failed();
        }
    }

    public void Option3()
    {
        if (killerPosition == 2)
        {
            PlaySoundInterval(correctWrong, 3f, 4f);
            Congrats();
        }
        else
        {
            PlaySoundInterval(correctWrong, 5f, 6f);
            Failed();
        }
    }

    public void Option4()
    {
        if (killerPosition == 3)
        {
            PlaySoundInterval(correctWrong, 3f, 4f);
            Congrats();
        }
        else
        {
            PlaySoundInterval(correctWrong, 5f, 6f);
            Failed();
        }
    }

    public void Option5()
    {
        if (killerPosition == 4)
        {
            PlaySoundInterval(correctWrong, 3f, 4f);
            Congrats();
        }
        else
        {
            PlaySoundInterval(correctWrong, 5f, 6f);
            Failed();
        }
    }
}
