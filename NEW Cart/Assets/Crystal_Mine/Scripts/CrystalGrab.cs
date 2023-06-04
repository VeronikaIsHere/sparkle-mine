using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalGrab : MonoBehaviour
{
    public string crystalTag = "Crystal";
    public int score = 0;

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + "->" + other.gameObject.name);
        if (other.CompareTag(crystalTag))
        {
            CollectCrystal(other.gameObject);
            score++;
        }
    }

    private void CollectCrystal(GameObject crystal)
    {
        crystal.SetActive(false);
    }
}
