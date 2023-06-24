using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject buttonPanel;
    public MinecartMovement minecartMovement;

    public string sceneToLoad;

    private XRController xrController;
    private bool menuOpen = false;
    private bool buttonPressed = false;

    public GameTimer timer;


    private void Start()
    {
        xrController = FindObjectOfType<XRController>();
    }

    private void Update()
    {
        CheckButtonPress();

    }

    private void CheckButtonPress()
    {
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            if (!buttonPressed)
            {
                buttonPressed = true;
                if (menuOpen)
                {
                    ResumeGame();
                    // Debug.Log("Resumed");
                }
                else
                {
                    PauseGame();
                    // Debug.Log("Paused");
                }
            }
        }
        else
        {
            buttonPressed = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered:", other.gameObject);
        if (other.tag != "")
            Debug.Log("Why no tag?", other.gameObject);

        if (other.CompareTag("RestartButton"))
        {
            Debug.Log("Restarting...");
            RestartGame();
        }
        else if (other.CompareTag("ResumeButton"))
        {
            Debug.Log("Resuming...");
            ResumeGame();
        }
        else if (other.CompareTag("QuitButton"))
        {
            Debug.Log("Quitting...");
            QuitGame();
        }

        // Check if the collider belongs to the controller
        // if (other.CompareTag("Controller"))
        // {
        //     // Check which button was collided with and perform the corresponding action
        //     if (.CompareTag("RestartButton"))
        //     {
        //         RestartGame();
        //     }
        //     else if (ResumeButton.CompareTag("ResumeButton"))
        //     {
        //         ResumeGame();
        //     }
        //     else if (QuitButton.CompareTag("QuitButton"))
        //     {
        //         QuitGame();
        //     }
        // }
    }

    public void PauseGame()
    {
        // Pause the game
        // Time.timeScale = 0f;


        timer.timeRunning = false;

        // Show the pause menu
        buttonPanel.SetActive(true);

        // Pause the minecart movement
        minecartMovement.PauseMovement();

        menuOpen = true;
    }

    public void ResumeGame()
    {
        // Resume the game
        // Time.timeScale = 1f;

        timer.timeRunning = true; 

        // Hide the pause menu
        buttonPanel.SetActive(false);

        // Resume the minecart movement
        minecartMovement.ResumeMovement();
        menuOpen = false;
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }

    public void RestartGame()
    {
        // Restart the current scene
        SceneManager.LoadScene(sceneToLoad);

    }
}
