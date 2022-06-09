using System;
using System.Diagnostics;
using UnityEngine;

public class Gun : MonoBehaviour{


    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpscamera;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;
    public GameObject BloodStreamEffect;
    AudioSource m_shootingSound;

    private float nextTimeToFire = 0f;

    // Shooting
    void Update ()
    {
        
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    void Shoot ()
    {
        muzzleflash.Play();
        m_shootingSound = GetComponent<AudioSource>();
        m_shootingSound.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpscamera.transform.position, fpscamera.transform.forward, out hit, range))
        {
            UnityEngine.Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (hit.collider.tag != "Enemy")
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
            
            if (hit.collider.tag == "Enemy")
            {
                GameObject bloodGO = Instantiate(BloodStreamEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(bloodGO, 1f);
            }
        }

    }
}