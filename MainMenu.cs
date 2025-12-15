using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject backgroundIntro;
    public GameObject loading;
    public GameObject menu;
    public GameObject playGame;
    public GameObject about;
    public GameObject help;
    public GameObject arCard;

    public GameObject aboutPreviousButton;
    public GameObject aboutNextButton;
    
    public GameObject helpPreviousButton;
    public GameObject helpNextButton;
    
    public GameObject cardPreviousButton;
    public GameObject cardNextButton;

    public Image aboutImage;
    public Sprite[] aboutSprite;
    int aboutCount = 0;

    public Image helpImage;
    public Sprite[] helpSprite;
    int helpCount = 0;

    public Image arCardImage;
    public Sprite[] arCardSprite;
    int arCardCount = 0;

    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        backgroundIntro.SetActive(true);
        loading.SetActive(false);
        menu.SetActive(false);
        about.SetActive(false);
        help.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        backgroundMusic.Stop();
        loading.SetActive(true);
        SceneManager.LoadSceneAsync("Map1");
        //playGame.SetActive(true);
        //menu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Intro()
    {
        backgroundMusic.Play();
        backgroundIntro.SetActive(false);
        menu.SetActive(true);
    }

    public void About()
    {
        aboutNextButton.SetActive(true);
        menu.SetActive(false);
        about.SetActive(true);
    }

    public void Help()
    {
        helpNextButton.SetActive(true);
        menu.SetActive(false);
        help.SetActive(true);
    }

    public void ARCard()
    {
        cardNextButton.SetActive(true);
        arCard.SetActive(true);
        menu.SetActive(false);
        about.SetActive(false);
        help.SetActive(false);

    }

    public void Back()
    {
        menu.SetActive(true);
        about.SetActive(false);
        help.SetActive(false);
        arCard.SetActive(false);

        helpCount = 0;
        aboutCount = 0;
        arCardCount = 0;

        aboutPreviousButton.SetActive(false);
        helpPreviousButton.SetActive(false);
        cardPreviousButton.SetActive(false);
    }

    public void AboutNextButton()
    {
        if (aboutCount < 7)
        {
            aboutCount++;
            aboutImage.sprite = aboutSprite[aboutCount];
        }

        AboutButton();

    }

    public void AboutPreviousButton()
    {
        if (aboutCount > 0)
        {
            aboutCount--;
            aboutImage.sprite = aboutSprite[aboutCount];
        }

        AboutButton();
    }

    public void HelpNextButton()
    {
        if (helpCount < 10)
        {
            helpCount++;
            helpImage.sprite = helpSprite[helpCount];
        }

        HelpButton();
    }

    public void HelpPreviousButton()
    {
        if (helpCount > 0)
        {
            helpCount--;
            helpImage.sprite = helpSprite[helpCount];
        }

        HelpButton();

    }

    public void ARcardNextButton()
    {
        if (arCardCount < 7)
        {
            arCardCount++;
            arCardImage.sprite = arCardSprite[arCardCount];
        }

        ARCardButton();
    }

    public void ARcardPreviousButton()
    {
        if (arCardCount > 0)
        {
            arCardCount--;
            arCardImage.sprite = arCardSprite[arCardCount];
        }

        ARCardButton();

    }

    void ARCardButton()
    {
        if (arCardCount > 0)
            cardPreviousButton.SetActive(true);
        else
            cardPreviousButton.SetActive(false);

        if (arCardCount < 7)
            cardNextButton.SetActive(true);
        else
            cardNextButton.SetActive(false);
    }

    void HelpButton()
    {
        if (helpCount > 0)
            helpPreviousButton.SetActive(true);
        else
            helpPreviousButton.SetActive(false);

        if (helpCount < 10)
            helpNextButton.SetActive(true);
        else
            helpNextButton.SetActive(false);
    }

    void AboutButton()
    {
        if (aboutCount > 0)
            aboutPreviousButton.SetActive(true);
        else
            aboutPreviousButton.SetActive(false);

        if (aboutCount < 7)
            aboutNextButton.SetActive(true);
        else
            aboutNextButton.SetActive(false);
    }
}
