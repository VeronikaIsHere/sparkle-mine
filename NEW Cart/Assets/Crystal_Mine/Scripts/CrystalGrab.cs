using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CrystalGrab : MonoBehaviour
{
    public string crystalTag = "Crystal";
    public Score scoreScript;

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
        Debug.Log("OnTriggerEnter");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag + "->" + other.gameObject.name);
        if (other.CompareTag(crystalTag))
        {
            CollectCrystal(other.gameObject);
            scoreScript.IncrementScore(1);
            Debug.Log("collected");
        }
    }

    private void CollectCrystal(GameObject crystal)
    {
        crystal.SetActive(false);
        Debug.Log("deactivated");
    }
}

