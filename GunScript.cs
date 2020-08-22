
using System.Diagnostics;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    AudioSource m_shootingSound;

    private float nextTimeToFire = 0f;

    void Start()
    {
        m_shootingSound = GetComponent<AudioSource>();
    }




    // Update is called once per frame
    void Update()
                 {
        
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            m_shootingSound.Play();
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }
       public void Shoot ()
       {
            muzzleFlash.Play();

            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range));
            {
              

               Target target = hit.transform.GetComponent<Target>();
               if (target != null)
               { 
                 target.TakeDamage(damage);
               }

               if(hit.rigidbody != null)
               {
                 hit.rigidbody.AddForce(-hit.normal * impactForce);
               }

               GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
               Destroy(impactGO, 2f);
       
       
            }
       }
}











