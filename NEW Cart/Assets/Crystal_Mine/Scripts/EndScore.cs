using System;
using TMPro;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    public PauseMenuManager pauseMenuScript;
    public Score scoreScript;
    public GameTimer gameTimerScript;

    public TextMeshProUGUI EndingScoreText;
    public TextMeshProUGUI EndingTimerText;

    private GameObject resumeButt;
    private GameObject panelsObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "END")
        {
            Debug.Log("END");

            pauseMenuScript.PauseGame();

            HideResume();

            HidePanels();

            ShowAchievment();
        }
    }

    private void HidePanels()
    {
        // Find the panels object
        panelsObject = GameObject.Find("Panels");

        // Deactivate the panels
        panelsObject.SetActive(false);
    }

    private void HideResume()
    {
        // Find the resume button by tag
        resumeButt = GameObject.FindWithTag("ResumeButton");

        if (resumeButt != null)
        {
            // Deactivate the resume button
            resumeButt.SetActive(false);
        }
        else
        {
            Debug.Log("Resume Button not found!");
        }
    }

    public void ShowAchievment()
    {
        Debug.Log("ShowEnd");

        // Set the ending score text
        EndingScoreText.text = "You collected " + scoreScript.score.ToString() + " crystals!";

        // Set the ending timer text using the formatted time text from GameTimer
        EndingTimerText.text = "And you took " + gameTimerScript.GetTimeText().ToString() + " minutes!";
    }
}
