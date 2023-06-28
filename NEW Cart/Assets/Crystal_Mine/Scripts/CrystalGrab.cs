using UnityEngine;

public class CrystalGrab : MonoBehaviour
{
    public string crystalTag = "Crystal";
    public Score scoreScript;
    // public Collider leftHandCollider;
    // public Collider rightHandCollider;
    public MinecartMovement minecartMovement;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        // CheckCollision(leftHandCollider);
        // CheckCollision(rightHandCollider);
    }

    // private void CheckCollision(Collider collider)
    // {
    //     // Check if the collider is valid and active
    //     if (collider != null && collider.enabled && collider.gameObject.activeInHierarchy)
    //     {
    //         // Get all colliders overlapping with the collider's bounding box
    //         Collider[] colliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation);

    //         // Iterate through each collider
    //         foreach (Collider otherCollider in colliders)
    //         {

    //             // Check if the collider has the crystal tag
    //             // TODO: Copy over as soon as hand colliders are implemented
    //             if (otherCollider.CompareTag(crystalTag))
    //             {
    //                 
    //             }
    //         }
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(crystalTag))
                {
            Debug.Log("Collect crystal now!");
                            _audioSource.time = 0.5f;
                            _audioSource.Play();
                            CollectCrystal(other.gameObject);
                            scoreScript.IncrementScore(1);
                            minecartMovement.IncrementCrystalsCollected();
        }
    }

    private void CollectCrystal(GameObject crystal)
    {
        
        // Deactivate the crystal
        crystal.SetActive(false);
    }
}
