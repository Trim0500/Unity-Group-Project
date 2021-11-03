using UnityEngine;
using System.Collections;
using System;

public class Bomb : MonoBehaviour
{
    public GameObject explosionParticlesPrefab;

    // Use this for initialization
    void Start ()
    {

    }

    public void OnCollisionEnter (Collision collision)
    {
        if (explosionParticlesPrefab)
        {
            GameObject explosion = (GameObject)Instantiate (explosionParticlesPrefab, transform.position, explosionParticlesPrefab.transform.rotation);
            Destroy (explosion, explosion.GetComponent<ParticleSystem> ().main.startLifetimeMultiplier);
        }

        Destroy (gameObject);
    }


}
