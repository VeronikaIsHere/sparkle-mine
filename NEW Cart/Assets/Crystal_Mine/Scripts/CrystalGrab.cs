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
        if (collider != null && collider.enabled && collider.gameObject.activeInHierarchy)
        {
            Collider[] colliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation);
            foreach (Collider otherCollider in colliders)
            {
                if (otherCollider.CompareTag(crystalTag))
                {
                    CollectCrystal(otherCollider.gameObject);
                    scoreScript.IncrementScore(1);
                    Debug.Log("Collected by " + collider.name + ": " + otherCollider.name);
                }
                else
                {
                    Debug.Log("Collided with " + collider.name + " but not a crystal: " + otherCollider.name);
                }
            }
        }
    }

    private void CollectCrystal(GameObject crystal)
    {
        crystal.SetActive(false);
        Debug.Log("Deactivated: " + crystal.name);
    }
}
