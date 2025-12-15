using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastSight : MonoBehaviour
{
    private GenerateNPC generateNPC;

    public GameObject[] NPC;
    public Animator[] animator;

    bool isScan;

    int count;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        generateNPC = GameObject.Find("GenerateNPC").GetComponent<GenerateNPC>();

        count = 0;
        time = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScan)
        {
            if(count == 12)
            {
                count = 0;
                isScan = false;
            }
            else if (time > 0)
            {
                time -= Time.deltaTime;
                NPC[count].SetActive(true);
                if (generateNPC.killerName == NPC[count].name)
                {
                    animator[count].SetInteger("reaction", 2);
                }
                else if (generateNPC.victimName[0] == NPC[count].name)
                {
                    animator[count].SetInteger("reaction", 1);
                }
                
            }
            else
            {
                NPC[count].SetActive(false);
                animator[count].SetInteger("reaction", 0);
                count++;
                time = 1.5f;
            }

        }
    }

    public void ARCards()
    {
        isScan = true;
    }

    public void OnTargetLost()
    {
        isScan = false;
    }
}
