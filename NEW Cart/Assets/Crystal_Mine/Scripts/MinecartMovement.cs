using BLINDED_AM_ME;
using UnityEngine;

public class MinecartMovement : MonoBehaviour
{
    public Path_Comp spline;
    public bool isCircuit = false;

    private float currentDistance = 0.0f;

    private int crystalsCollected = 0;
    private float baseSpeed = 2f;
    private int crystalsPerSpeedIncrease = 2;
    private float speedIncrement = 0.5f;

    private float currentSpeed;

    private bool isPaused = false;
    private float pausedSpeed;

    private void Start()
    {
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        if (!isPaused)
        {
            // Move the cart along the spline
            currentDistance += currentSpeed * Time.deltaTime;
            currentDistance = Mathf.Clamp(currentDistance, 0.0f, spline.TotalDistance);

            // Get the path point on the spline at the current distance
            Path_Point pathPoint = spline.GetPathPoint(currentDistance);

            // Set the cart's position and rotation based on the path point
            transform.position = pathPoint.point;
            transform.rotation = Quaternion.LookRotation(pathPoint.forward, pathPoint.up);

            //Debug.Log("Current Speed: " + currentSpeed);
        }
    }

    public void IncrementCrystalsCollected()
    {
        crystalsCollected++;

        if (crystalsCollected % crystalsPerSpeedIncrease == 0)
        {
            // Increase the speed by the specified increment
            currentSpeed = baseSpeed + (crystalsCollected / crystalsPerSpeedIncrease) * speedIncrement;
            //Debug.Log("Speed Increased: " + currentSpeed);
        }
    }

    public void PauseMovement()
    {
        if (!isPaused)
        {
            isPaused = true;
            pausedSpeed = currentSpeed;
            currentSpeed = 0f;
        }
    }

    public void ResumeMovement()
    {
        if (isPaused)
        {
            isPaused = false;
            currentSpeed = pausedSpeed;
        }
    }
}
