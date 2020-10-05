using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.Analytics;

//Terrence
public class Bom : MonoBehaviour
{
    public float delay = 2.5f;
    public float radius = 5f;
    public float force = 700f;
    public int damage = 75;
    bool hasExploded = false;

    VisualEffect explosionEffect;
    AudioSource explo;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        explosionEffect = GetComponent<VisualEffect>();
        explo = GetComponent<AudioSource>();
    }

    void Explode()
    {
        this.GetComponent<MeshRenderer>().enabled = false;

        explo.Play();
        explosionEffect.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && !nearbyObject.CompareTag("Player"))
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject, delay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            Explode();
        }
        else if (other.CompareTag("Player"))
        {
            transform.SetParent(this.transform);
            this.rb.isKinematic = true;
            Player pl = other.GetComponent<Player>();
            pl.DoDamge(damage);

            Explode();
        }
    }
}
