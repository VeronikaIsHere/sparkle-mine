using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float timeLeft = 0;
    public bool timeRunning = false;

    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRunning)
        {
            //if(timeLeft > 0)
            //{
                timeLeft += Time.deltaTime;
                updateTimer(timeLeft);
            /*}
            else
            {
                timeLeft = 0f;
                timeRunning = false;
                Debug.Log("Time is up!");
            }*/
        }
    }

    public void updateTimer(float currentTime) 
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //Debug.Log(seconds);
    }

    public float GetCurrentTime()
    {
        return timeLeft;
    }

    public string GetTimeText()
    {
        return timeText.text;
    }
}

