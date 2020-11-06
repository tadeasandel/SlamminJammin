using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public float maxTimeEnding;
    float deathTime;
    public Text timerText;
    // Start is called before the first frame update
     void Start()
    {
        deathTime = Random.Range(0, maxTimeEnding);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (timeRemaining > deathTime)
        {
            timeRemaining -= Time.deltaTime;
           

            DisplayTime(timeRemaining);
        }
        else
        {
            Debug.LogError("You are death");

        }

        
    }
    void DisplayTime(float timeToDisplay) 
    {
       
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        

    }
}
