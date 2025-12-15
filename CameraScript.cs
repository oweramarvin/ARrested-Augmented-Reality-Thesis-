using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CameraScript : MonoBehaviour
{
    public GameObject textInstruction;
    public GameObject playButton;
    public GameObject skipButton;
    public GameObject loading;
    public GameObject menu;
    public GameObject playGame;
    public GameObject pauseButton;

    public GameObject arCamera;
    public GameObject arScene;
    private GameObject arButton;
    public GameObject timerGO;
    private GameObject exitButton;
    public GameObject arExit;
    public TMP_Text timer;

    public float smoothing = 0.1f;
    public Vector3 offset;

    [SerializeField]
    public Camera camera_;
    private Vector3 positionCamera;
    public GameObject mainCamera;

    public GameObject player;
    private PlayerScript playerScript;
    private GenerateStory generateStory;

    private GameObject dialogBox;
    private GameObject roomExitButton;
    private GameObject joystick;
    private GameObject startGameIntro;
    private GameObject spawnNPC;
    private GameObject cardContainer;
    private GameObject sky;
    public GameObject policeStation;

    bool isPlayerWalking;
    public bool isPlayerMoving;

    private Vector3 previousCameraPosition;

    private GameObject mainLight_GO;
    private GameObject thingsLight_GO;
    public UnityEngine.Rendering.Universal.Light2D mainLight;
    public UnityEngine.Rendering.Universal.Light2D light1;
    public UnityEngine.Rendering.Universal.Light2D light2;

    private GameObject lightBackground;

    public AudioSource iWannaBeTutubi;
    public AudioSource backgroundMusic;
    public AudioSource onOffSound;

    public float durationTime;
    float nightTime;
    bool startOfGame;

    float thingsLight = 1f;
    bool isThingsClicked;

    int page;
    float nightLight;
    bool isSoundOn;
    int randomScaryView;

    public GameObject introductionCanvas;
    bool introduction;
    public TMP_Text narratorSay;

    bool isLoading;

    bool isPause;

    string[] story1 = new string[]
    {
        "A community member is found dead, shocking the town.",
        "A trusted friend becomes a killer. As a detective, unravel the truth and bring justice to the grieving community.",
        "Investigate secrets, motives, and shattered trust.",
    };

    string[] story2 = new string[]
    {
        "A tragic murder case unfolds, leaving the community in shock.",
        "The victim was brutally killed by someone related to you",
        "As investigators dig deeper, uncovering hidden motives and secrets, the pursuit of justice begins, unraveling the dark betrayal that shattered trust.",
    };

    string[] story3 = new string[]
    {
        "In a quiet town, a murder has shocked the community. The victim, involved in a secret affair, was found dead in a secluded location.",
        "As investigators dig deeper, the identities of those involved remain undisclosed.",
        "Hidden motives and tangled relationships hold the key to solving this perplexing crime.",
    };

    string[] story4 = new string[]
    {
        "In the dark underbelly of crime, a chilling discovery has sent shockwaves through the city.",
        "Just moments before the game commences, news has emerged that a notorious drug pusher has been found dead, shrouded in mystery.",
        "As you step into the role of a skilled investigator, it's up to you to unravel the secrets surrounding this grim demise and bring justice to the streets.",
    };

    string[] story5 = new string[]
    {
        "In a quiet neighborhood, authorities have discovered the lifeless body of a deceased individual with a history of drug use.",
        "The circumstances surrounding the death are shrouded in mystery.",
        "As a detective, your task is to unravel the secrets, gather evidence, and interview witnesses to solve this puzzling murder case.",
    };

    string[] story6 = new string[]
    {
        "As the game begins, word has just come in that the thief you were pursuing is not only a cunning criminal,",
        "but also a cold-blooded killer.",
        "The stakes have been raised, and it's up to you to navigate through a web of deceit, uncovering the truth behind this unexpected twist.",
    };

    string[] story7 = new string[]
    {
        "News has just broken that a notorious thief has been found dead under mysterious circumstances.",
        "The criminal underworld is buzzing with speculation, and it's up to you to uncover the truth.",
        "Equipped with your detective skills, you will search for clues, interrogate suspects, and piece together the puzzle surrounding this enigmatic demise.",
    };

    string[] introDialogTemp = new string[3];

    float timerValue;
    int min;
    int sec;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
        generateStory = GameObject.Find("GenerateStory").GetComponent<GenerateStory>();
        //camera = GetComponent<Camera>();
        positionCamera = camera_.transform.position;
        dialogBox = GameObject.FindGameObjectWithTag("DialogBox");
        roomExitButton = GameObject.Find("Room Exit Button");
        joystick = GameObject.Find("Floating Joystick");
        lightBackground = GameObject.Find("Light Background");
        spawnNPC = GameObject.Find("SpawnNPC");
        startGameIntro = GameObject.Find("StartGame Intro");
        mainLight_GO = GameObject.FindGameObjectWithTag("Main Light");
        thingsLight_GO = GameObject.FindGameObjectWithTag("Things Light");
        //backgroundLight_GO = GameObject.FindGameObjectWithTag("Background Light");
        arButton = GameObject.FindGameObjectWithTag("AR Button");
        exitButton = GameObject.Find("Exit Button");
        cardContainer = GameObject.Find("Card Container");
        sky = GameObject.Find("Sky");
        //policeStation = GameObject.FindGameObjectWithTag("Police Station");

        arCamera.SetActive(false);
        arScene.SetActive(false);
        arExit.SetActive(false);
        policeStation.SetActive(false);
        playButton.SetActive(false);
        textInstruction.SetActive(false);
        pauseButton.SetActive(false);
        timerValue = 460f;
        timer.text = "";

        page = 0;
        isPlayerMoving = false;

        isLoading = true;
        isLoading = false;
        isPause = false;

        StartOfGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause)
        {
            iWannaBeTutubi.Pause();
            backgroundMusic.Pause();
        }
        else
        {


            if (isPlayerWalking)
            {
                Vector3 desiredPosition = player.transform.position + offset;
                camera_.transform.position = Vector3.Lerp(camera_.transform.position, desiredPosition, smoothing);
            }

            if (isThingsClicked)
            {
                thingsLight -= Time.deltaTime;
                if (thingsLight < 0)
                {
                    thingsLight_GO.SetActive(false);
                    thingsLight = 1f;
                    isThingsClicked = false;
                }
            }

            if (isLoading)
            {
                playGame.SetActive(false);
                menu.SetActive(true);
                isLoading = false;
            }
            else if (introduction)
            {
                durationTime += Time.deltaTime;


                switch (generateStory.storyNumber)
                {
                    case 1:
                        introDialogTemp = story1;
                        break;
                    case 2:
                        introDialogTemp = story2;
                        break;
                    case 3:
                        introDialogTemp = story3;
                        break;
                    case 4:
                        introDialogTemp = story4;
                        break;
                    case 5:
                        introDialogTemp = story5;
                        break;
                    case 6:
                        introDialogTemp = story6;
                        break;
                    case 7:
                        introDialogTemp = story7;
                        break;
                }


                if (durationTime <= 5f)
                {
                    narratorSay.text = introDialogTemp[0];
                }
                else if (durationTime <= 10f)
                {
                    narratorSay.text = introDialogTemp[1];
                }
                else if (durationTime <= 16f)
                {
                    narratorSay.text = introDialogTemp[2];
                }
                else
                {
                    durationTime = 60f;
                    introduction = false;
                    introductionCanvas.SetActive(false);

                    PlaySoundInterval(iWannaBeTutubi, 140f, 153f);
                    //iWannaBeTutubi.time = 150f; //for testing
                    page = 0;
                }

            }
            else if (startOfGame && page == 0)
            {
                if (iWannaBeTutubi.time < 146.7f)
                {
                    Vector3 desiredPosition = new Vector3(130f, 1f, -10f); // Park
                    camera_.transform.position = desiredPosition;
                    //camera_.transform.position = Vector3.Lerp(camera_.transform.position, desiredPosition, 0f);
                }
                else if (iWannaBeTutubi.time < 148.7f)
                {
                    Vector3 desiredPosition = new Vector3(157f, 2f, -10f); // Police
                    camera_.transform.position = desiredPosition;
                    //camera_.transform.position = Vector3.Lerp(camera_.transform.position, desiredPosition, 0f);
                }
                else if (iWannaBeTutubi.time < 149f)
                {
                    Vector3 desiredPosition = new Vector3(220f, 2f, -10f); // Doctor
                    camera_.transform.position = desiredPosition;
                    //camera_.transform.position = Vector3.Lerp(camera_.transform.position, desiredPosition, 0f);
                }
                else if (iWannaBeTutubi.time < 149.3f)
                {
                    Vector3 desiredPosition = new Vector3(-88f, 2.7f, -10f); // Victim
                    camera_.transform.position = desiredPosition;
                    //camera_.transform.position = Vector3.Lerp(camera_.transform.position, desiredPosition, 1f);
                }
                else if (iWannaBeTutubi.time < 149.7f)
                {
                    Vector3 desiredPosition = new Vector3(-2f, 1f, -10f); // Civilian
                    camera_.transform.position = desiredPosition;
                    //camera_.transform.position = Vector3.Lerp(camera_.transform.position, desiredPosition, 1f);
                }
                else if (iWannaBeTutubi.time < 151f)
                {
                    Vector3 desiredPosition = new Vector3(114f, 2f, -10f); // Kid
                    camera_.transform.position = desiredPosition;
                    //camera_.transform.position = Vector3.Lerp(camera_.transform.position, desiredPosition, 1f);
                }
                else
                {
                    skipButton.SetActive(false);
                    mainLight_GO.SetActive(true);
                    //backgroundLight_GO.SetActive(false);
                    startOfGame = false;
                    startGameIntro.SetActive(false);
                    joystick.SetActive(true);
                    arButton.SetActive(true);
                    timerGO.SetActive(true);
                    exitButton.SetActive(true);
                    pauseButton.SetActive(true);
                    cardContainer.SetActive(true);

                    isPlayerWalking = true;

                    PlaySoundInterval(backgroundMusic, 70f, 206f); // 135 seconds
                    //PlaySoundInterval(backgroundMusic, 195f, 206f); // 10 seconds for testing
                    page = 1;

                    durationTime = 200f;
                    //durationTime = 150f;
                    //durationTime = 10f; // 2:30 minutes // should be 150 seconds
                    nightLight = 1f;
                    textInstruction.SetActive(true);
                }
            }
            else if (page == 1)
            {
                // Day time
                timerValue -= Time.deltaTime;
                min = Mathf.FloorToInt(timerValue / 60);
                sec = Mathf.FloorToInt(timerValue % 60);
                timer.text = min.ToString("00") + ":" + sec.ToString("00");

                durationTime -= Time.deltaTime;

                if (nightLight >= 0.2f)
                {
                    nightLight = (durationTime / 200);
                    //nightLight = (durationTime / 10); // should be same as first duration on line 178
                    mainLight.intensity = nightLight;
                }
                else if (durationTime <= 40)
                {
                    page = 2;
                    mainLight_GO.SetActive(false);
                    durationTime = 300f; // 300 seconds 
                    PlaySoundInterval(backgroundMusic, 70f, 206f);
                }

                if (backgroundMusic.time >= 205f && backgroundMusic.time <= 206f)
                {
                    PlaySoundInterval(backgroundMusic, 70f, 206f); // 25 seconds
                }




            }
            else if (page == 2)
            {
                // Night time


                if (durationTime >= 0)
                {
                    durationTime -= Time.deltaTime;

                    timerValue -= Time.deltaTime;
                    min = Mathf.FloorToInt(timerValue / 60);
                    sec = Mathf.FloorToInt(timerValue % 60);
                    timer.text = min.ToString("00") + ":" + sec.ToString("00");

                    if (backgroundMusic.time >= 205f && backgroundMusic.time <= 206f)
                    {
                        PlaySoundInterval(backgroundMusic, 70f, 206f); // 25 seconds
                    }
                }
                else
                {
                    InsidePolice();
                    roomExitButton.SetActive(false);
                    AR_Exit();
                    arButton.SetActive(false);
                    timerGO.SetActive(false);
                    exitButton.SetActive(false);
                    pauseButton.SetActive(false);
                    page = 3;
                }

            }
        }
        
      
    }

    public void IsPause()
    {
        if (isPause)
        {
            isPause = false;
            backgroundMusic.Play();
            playButton.SetActive(false);
            joystick.SetActive(true);
        }
        else
        {
            backgroundMusic.Pause();
            isPause = true;
            playButton.SetActive(true);
            joystick.SetActive(false);
        }
    }

    public void Skip()
    {
        introductionCanvas.SetActive(false);
        isLoading = false;
        introduction = false;
        mainLight_GO.SetActive(true);
        startOfGame = false;
        startGameIntro.SetActive(false);
        joystick.SetActive(true);
        arButton.SetActive(true);
        timerGO.SetActive(true);
        exitButton.SetActive(true);
        pauseButton.SetActive(true);
        cardContainer.SetActive(true);
        isPlayerWalking = true;
        iWannaBeTutubi.Stop();
        PlaySoundInterval(backgroundMusic, 70f, 206f);
        page = 1;
        durationTime = 200f;
        nightLight = 1f;
        skipButton.SetActive(false);
        textInstruction.SetActive(true);
    }

    void StartOfGame()
    {
        durationTime = 10f;

        joystick.SetActive(false);
        thingsLight_GO.SetActive(false);
        mainLight_GO.SetActive(false);
        //backgroundLight_GO.SetActive(true);
        dialogBox.SetActive(false);
        roomExitButton.SetActive(false);
        startGameIntro.SetActive(true);
        arButton.SetActive(false);
        timerGO.SetActive(false);
        exitButton.SetActive(false);
        pauseButton.SetActive(false);
        cardContainer.SetActive(false);

        isPlayerWalking = false;
        isThingsClicked = false;

        startOfGame = true;
        durationTime = 60f;
        nightTime = 30f;
        nightLight = 1f;
        isSoundOn = true;

        //lightBackground.SetActive(false);
        //player.SetActive(false);
        //spawnNPC.SetActive(false);

        //mainLight.pointLightInnerRadius = 0f;
        //mainLight.pointLightOuterRadius = 0f;

        //PlaySoundInterval(iWannaBeTutubi, 67f, 72f);

        introduction = true;

        // For testing
        //PlaySoundInterval(iWannaBeTutubi, 67f, 76f);
        durationTime = 0f;

        // FOR TESTING



    }



    void PlaySoundInterval(AudioSource audioName, float fromSeconds, float toSeconds)
    {
        audioName.time = fromSeconds;
        audioName.Play();
        audioName.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));

    }

    public void NPCClicked()
    {
        offset.y = 0;
        Vector3 desiredPosition_ = player.transform.position + offset;
        camera_.transform.position = Vector3.Lerp(camera_.transform.position, desiredPosition_, smoothing);

        dialogBox.SetActive(true);

    }

    public void ThingsClicked()
    {
        isThingsClicked = true;
        thingsLight_GO.SetActive(true);
    }

    public void Door1()
    {
        isPlayerWalking = false;
        previousCameraPosition = camera_.transform.position;
        camera_.transform.position = new Vector3(-54f, -27f, -5f);
        roomExitButton.SetActive(true);
        joystick.SetActive(false);
        arButton.SetActive(false);
        timerGO.SetActive(false);
        exitButton.SetActive(false);
        pauseButton.SetActive(false);
        dialogBox.SetActive(false);
        
        

        //light1.pointLightOuterRadius = 0f;


    }

    public void Door2()
    {
        isPlayerWalking = false;
        previousCameraPosition = camera_.transform.position;
        camera_.transform.position = new Vector3(-29.5f, -27f, -5f);
        roomExitButton.SetActive(true);
        joystick.SetActive(false);
        arButton.SetActive(false);
        timerGO.SetActive(false);
        exitButton.SetActive(false);
        pauseButton.SetActive(false);
        dialogBox.SetActive(false);

        //light2.pointLightOuterRadius = 0f;

    }

    public void InsidePolice()
    {
        isPlayerWalking = false;
        previousCameraPosition = camera_.transform.position;
        camera_.transform.position = new Vector3(14f, -27.5f, -5f);
        roomExitButton.SetActive(true);
        joystick.SetActive(false);
        arButton.SetActive(false);
        timerGO.SetActive(false);
        exitButton.SetActive(false);
        pauseButton.SetActive(false);
        dialogBox.SetActive(false);
        policeStation.SetActive(true);
        cardContainer.SetActive(false);

        //light2.pointLightOuterRadius = 0f;+

    }

    public void backCameraToPlayer()
    {
        isPlayerWalking = true;
        camera_.transform.position = previousCameraPosition;
        dialogBox.SetActive(false);
        roomExitButton.SetActive(false);
        joystick.SetActive(true);
        arButton.SetActive(true);
        timerGO.SetActive(true);
        exitButton.SetActive(true);
        pauseButton.SetActive(true);
        policeStation.SetActive(false);
        cardContainer.SetActive(true);
    }

    public void AR_Exit()
    {
        //iWannaBeTutubi.Play();
       // arCamera.SetActive(false);
        arScene.SetActive(false);
        mainCamera.SetActive(true);
        joystick.SetActive(true);
        arButton.SetActive(true);
        timerGO.SetActive(true);
        exitButton.SetActive(true);
        pauseButton.SetActive(true);
        arExit.SetActive(false);
        textInstruction.SetActive(true);

    }

    public void ARScene()
    {
        iWannaBeTutubi.Pause();
        mainCamera.SetActive(false);
        arScene.SetActive(true);
        joystick.SetActive(false);  
        arButton.SetActive(false);
        timerGO.SetActive(false);
        exitButton.SetActive(false);
        pauseButton.SetActive(false);
        // arCamera.SetActive(true);
        textInstruction.SetActive(false);
        arExit.SetActive(true);
        //SceneManager.LoadScene("AR");

    }

    public void GoingToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Map1");
    }

}
