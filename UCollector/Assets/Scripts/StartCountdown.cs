using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
 
public class StartCountdown : MonoBehaviour
{
    public float CountdownFrom;
    public TMP_Text timeText;
    public bool CountdownStarted;
    public static bool CountownOver;
    private Animator animText;
    private void Awake()
    {
        CountdownStarted = false;
        CountownOver = false;
        animText = timeText.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CountdownStarted = true;
            animText.enabled = false;
        }
        if (CountdownStarted)
        {
            CountdownFrom -= Time.deltaTime;
            timeText.text = CountdownFrom.ToString("0");
            if (CountdownFrom<1f)
            {
                timeText.text = "GO!";
            }
            if (CountdownFrom <= 0f)
            {
                
                TimeUp();
            }

        }
        
    }

    void TimeUp()
    {

        timeText.gameObject.SetActive(false);
        CountownOver = true;
        CountdownStarted = false;
        

    }
   
}
