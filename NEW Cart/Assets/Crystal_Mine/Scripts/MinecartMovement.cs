using BLINDED_AM_ME;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartMovement : MonoBehaviour
{
    public Path_Comp spline;
    public float speed = 1.0f;
    public bool isCircuit = false;

    private float currentDistance = 0.0f;

    private void Update()
    {
        // Move the cart along the spline
        currentDistance += speed * Time.deltaTime;
        currentDistance = Mathf.Clamp(currentDistance, 0.0f, spline.TotalDistance);

        // Get the path point on the spline at the current distance
        Path_Point pathPoint = spline.GetPathPoint(currentDistance);

        // Set the cart's position and rotation based on the path point
        transform.position = pathPoint.point;
        transform.rotation = Quaternion.LookRotation(pathPoint.forward, pathPoint.up);
    }
}
