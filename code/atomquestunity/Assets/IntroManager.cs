using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            } else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
                popUpIndex++;
            } /*else if (popUpIndex == 1)
            {
                if ()
                {
                    popUpIndex++;
                }
            } else if (popUpIndex == 2)
            {
                if ()
                {
                    popUpIndex++;
                }
            } else if (popUpIndex == 3)
            {
                if ()
                {
                    popUpIndex++;
                }
            }*/
        }
    
}
