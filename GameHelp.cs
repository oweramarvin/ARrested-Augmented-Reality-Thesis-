using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHelp : MonoBehaviour
{
    string[] story1 = 
    {
        "In shadows cast by bonds once pure,\n" +
        "A tale unfolds of friendship's lure.\n" +
        "Within a heart, a darkness bred,\n" +
        "A killer's path, a friend now dead.\n",

        "So beware, dear friends, in bonds you weave,\n" +
        "For shadows lurk, where dark hearts conceive.\n" +
        "Guard your trust, for danger may dwell,\n" +
        "In the hearts of those who once knew you well.",

        "Laughter shared, like gentle rain,\n" +
        "But hidden beneath, a growing pain.\n" +
        "A twisted soul, secrets concealed\n," +
        "A friend's demise, the truth revealed.",

        "Betrayal's venom, quietly spread,\n" +
        "As friendship's mask slowly sheds.\n" +
        "With knife in hand, trust is broken,\n" +
        "The bond shattered, words unspoken.",
    };

    string[] story2 =
    {
        "In shadows I tread, the investigator's quest, \n" +
        "Unaware that my friend harbors darkness within their chest.\n" +
        "Side by side we ventured, solving mysteries anew,\n" +
        "But little did I know, the killer was someone I once knew.",

        "Through clues and puzzles, I sought the truth's embrace,\n" +
        "Blind to the fact that my friend wore a deceitful face.\n" +
        "As I pieced the puzzle, unraveling the mystery's threads,\n" +
        "I never fathomed that my friend's hands were stained red.",

        "Emotions clash, loyalty torn apart,\n" +
        "As I confront the reality, the anguish in my heart.\n" +
        "In the depths of my heart, a storm rages, strong,\n" +
        "For the killer I seek is the friend I've known for so long.",
    };

    string[] story3 =
    {
        "In the shadows deep where passions burn,\n" +
        "A story unfolds of love's harsh turn.\n" +
        "Once pure of heart, now tainted and cold,\n" +
        "Driven by jealousy, a tale to be told.",

        "A web of lies, spun with cunning and deceit,\n" +
        "A heart's betrayal, bitter and sweet.\n" +
        "A lover's gaze once filled with trust,\n" +
        "Now tainted by a dangerous lust.",

        "With trembling hands and eyes ablaze,\n" +
        "In darkness, a plan to end love's maze.\n" +
        "A desperate choice, born from despair,\n" +
        "To kill for love, an act so rare.\n",

        "For love, at its core, should heal and inspire,\n" +
        "Regret consumes the one who'd stray.\n" +
        "In this tale, a lesson to keep in mind,\n" +
        "That love's true essence is gentle and kind.\n"

    };

    string[] story4 =
    {
        "In a world full of darkness and sorrow,\n" +
        "A chilling tale unfolds, hard to swallow.\n" +
        "A drug dealer, entangled in a life so vile,\n" +
        "Crosses paths with a user, trapped in their own trial.\n",

        "The dealer's path, driven by greed and strife,\n" +
        "Sustained by a trade that ruins lives.\n" +
        "Seeking solace, the user falls prey,\n" +
        "To the substances that slowly decay.\n",

        "May compassion guide our actions, day and night,\n" +
        "To save lives from darkness and lead them to light.\n" +
        "For in our unity, we can rewrite this story,\n" +
        "Preventing the drug dealer's hand from robbing more glory.\n",

        "In a world filled with darkness and despair,\n" +
        "A story emerges, difficult to bear.\n" +
        "A drug dealer's path, filled with wrong,\n" +
        "Crosses paths with a user, trapped for too long.\n"

    };

    string[] story5 =
    {
        "In a cruel twist of fate, a life is taken,\n" +
        "As the drug user's grasp on reality is shaken.\n" +
        "Their actions driven by a mind distorted,\n" +
        "A tragic tale of a life self-aborted.\n",

        "The drugs they once sought for solace and escape,\n" +
        "Now turned them into a vessel of fate.\n" +
        "Regret floods their conscience, as reality sinks,\n" +
        "Confronting the horrors of the choices they link.\n",

        "A drug user, lost in a treacherous plight,\n" +
        "Becomes the very embodiment of darkness and blight.\n" +
        "For in understanding and compassion's embrace,\n" +
        "We can prevent further tragedies taking place.\n"

    };

    string[] story6 =
    {
        "In a world filled with darkness and despair,\n" +
        "A story unfolds about a thief's moral affair.\n" +
        "Driven by desperation, they went astray,\n" +
        "Their actions led to chaos, causing dismay.\n",

        "With quick fingers and no sense of right,\n" +
        "They moved through the shadows, seeking their blight.\n" +
        "In the pursuit of riches, the thief lost their way,\n" +
        "Unaware of the price they would ultimately pay.\n",

        "This tale serves as a reminder to us all,\n" +
        "That choices have consequences, causing others to fall.\n" +
        "Let us strive for a world where compassion prevails,\n" +
        "Where thieves find redemption and their morality unveils.\n"

    };

    string[] story7 =
    {
        "In a world consumed by darkness and despair,\n" +
        "A haunting tale unfolds, where justice seems rare.\n" +
        "The target of the thief, now consumed by pain,\n" +
        "Becomes the unexpected killer, seeking to regain.\n",

        "Once a victim of the thief's cunning ways,\n" +
        "Now driven by revenge in a tumultuous maze.\n" +
        "Motivated by anguish, their heart filled with strife,\n" +
        "They hunt down the thief, ending their life.\n",

        "The thief, once a predator, now falls prey,\n" +
        "At the hands of the one they once caused dismay.\n" +
        "The target, burdened by a deep sense of loss,\n" +
        "Takes matters into their own hands, a heavy cross.\n"
    };

    public TMP_Text poemToDisplay;
    private GenerateStory generateStory_Script;
    // Start is called before the first frame update
    void Start()
    {
        generateStory_Script = GameObject.Find("GenerateStory").GetComponent<GenerateStory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ARCards()
    {
        RandomPoem();
    }

    void RandomPoem()
    {
        int randomNum = 0;
        switch (generateStory_Script.storyNumber)
        {
            case 1:
                randomNum = Random.Range(0, story1.Length);
                poemToDisplay.text = story1[randomNum];
                break;
            case 2:
                randomNum = Random.Range(0, story2.Length);
                poemToDisplay.text = story2[randomNum];
                break;
            case 3:
                randomNum = Random.Range(0, story3.Length);
                poemToDisplay.text = story3[randomNum];
                break;
            case 4:
                randomNum = Random.Range(0, story4.Length);
                poemToDisplay.text = story4[randomNum];
                break;
            case 5:
                randomNum = Random.Range(0, story5.Length);
                poemToDisplay.text = story5[randomNum];
                break;
            case 6:
                randomNum = Random.Range(0, story6.Length);
                poemToDisplay.text = story6[randomNum];
                break;
            case 7:
                randomNum = Random.Range(0, story7.Length);
                poemToDisplay.text = story7[randomNum];
                break;
        }
        
    }

}
