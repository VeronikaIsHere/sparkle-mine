using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;

    public float vignetteIntensity = 0.3f;
    public float vignetteSmoothness = 0.2f;

    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);

        if (vignette != null)
        {
            vignette.intensity.Override(vignetteIntensity);
            vignette.smoothness.Override(vignetteSmoothness);
        }
        else
        {
            Debug.LogWarning("Vignette component not found in the Post-processing Volume!");
        }
    }

    private void Update()
    {
        Vector3 playerPosition = transform.position;
        Vector3 cameraPosition = Camera.main.transform.position;
        float distanceToPlayer = Vector3.Distance(playerPosition, cameraPosition);

        float maxDistance = 5f; // Adjust this value as needed
        float vignetteMaxIntensity = 0.5f; // Adjust this value as needed

        float normalizedDistance = Mathf.Clamp01(distanceToPlayer / maxDistance);
        float vignetteIntensity = normalizedDistance * vignetteMaxIntensity;

        if (vignette != null)
        {
            vignette.intensity.Override(vignetteIntensity);
        }
    }
}
