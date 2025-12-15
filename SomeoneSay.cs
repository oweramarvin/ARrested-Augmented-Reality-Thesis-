using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SomeoneSay : MonoBehaviour
{
    private GenerateDialog generateDialog_Script;
    private Sketch sketch;

    public TMP_Text textToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        generateDialog_Script = GameObject.Find("GenerateDialog").GetComponent<GenerateDialog>();
        sketch = GameObject.Find("Sketch").GetComponent<Sketch>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ARCards()
    {
        switch (sketch.sketchNumber)
        {
            case 1:
                KillerSketch();
                break;
            case 2:
                KillerFriendSketch();
                break;
            case 3:
                VictimFriendSketch();
                break;
            case 4:
                YourFriendSketch();
                break;
        }
    }

    void YourFriendSketch()
    {
        string dialog = "Pay attention to the sketch, because the portrait behind it unveils the face of your friend";
        textToDisplay.text = dialog;

    }

    void KillerSketch()
    {
        string[] dialog =
        {
            "Pay attention to the sketch, because the portrait behind it unveils the face of our elusive killer.",
            "Take a closer look at the sketch, for the portrait hidden behind it holds the secret of the murderer's face.",
            "If you examine the sketch carefully, the portrait hanging behind it provides a chilling glimpse into the identity of the murderer."
        };

        int randomNum = Random.Range(1, 4);

        textToDisplay.text = dialog[randomNum];
    }

    void KillerFriendSketch()
    {
        string dialog = "Take a closer look at the sketch, for the portrait hidden behind it holds the secret and some connection to the murderer's.";
        textToDisplay.text = dialog;

    }


    void VictimFriendSketch()
    {
        string dialog = "Don't overlook the significance of the sketch – the portrait behind it only holds the key to unmasking the friend of the victim";
        textToDisplay.text = dialog;
    }

}
