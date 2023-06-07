using UnityEngine;

public class CrystalGrab : MonoBehaviour
{
    public string crystalTag = "Crystal";
    public Score scoreScript;
    public Collider leftHandCollider;
    public Collider rightHandCollider;

    private void Update()
    {
        CheckCollision(leftHandCollider);
        CheckCollision(rightHandCollider);
    }

    private void CheckCollision(Collider collider)
    {
        // Check if the collider is valid and active
        if (collider != null && collider.enabled && collider.gameObject.activeInHierarchy)
        {
            // Get all colliders overlapping with the collider's bounding box
            Collider[] colliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation);

            // Iterate through each collider
            foreach (Collider otherCollider in colliders)
            {
                // Check if the collider has the crystal tag
                if (otherCollider.CompareTag(crystalTag))
                {
                    CollectCrystal(otherCollider.gameObject);
                    scoreScript.IncrementScore(1);
                }
            }
        }
    }

    private void CollectCrystal(GameObject crystal)
    {
        // Deactivate the crystal
        crystal.SetActive(false);
    }
}
