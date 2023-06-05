using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Lever : MonoBehaviour
{
    public float brakingForce = 1.0f;  // Adjust the braking intensity
    public float brakingIntensity = 1.0f; // Adjust the value as needed


    public Rigidbody minecartRigidbody;  // Reference to the minecart's Rigidbody

    private XRController controller;
    private bool isPulled = false;

    private void Start()
    {
        // Get the XRController component attached to the lever
        controller = GetComponent<XRController>();
    }

    private void Update()
    {
        // Check for input to control the lever
        if (controller != null && controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue)
        {
            ToggleLever();
        }
    }

    private void ToggleLever()
    {
        isPulled = !isPulled;

        if (isPulled)
        {
            ApplyBrakingForce();
            Debug.Log("Lever pulled");
        }
        else
        {
            Debug.Log("Lever released");
        }
    }

    private void ApplyBrakingForce()
    {
        if (minecartRigidbody == null)
        {
            Debug.LogWarning("Minecart Rigidbody reference not set!");
            return;
        }

        Vector3 brakingForce = -minecartRigidbody.velocity.normalized * brakingIntensity;

        minecartRigidbody.AddForce(brakingForce, ForceMode.Acceleration);
    }
}
