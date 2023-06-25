using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    public PauseMenuManager pauseMenuManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            pauseMenuManager.PauseGame();
        }
    }
}
