
using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isRealoading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    AudioSource m_shootingSound;

    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start()
    {
        m_shootingSound = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
    }


    


    // Update is called once per frame
    void Update()
                 {
        if (isRealoading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            m_shootingSound.Play();
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        IEnumerator Reload ()
        {
            isRealoading = true;

            animator.SetBool("Reloading", true);

            yield return new WaitForSeconds(reloadTime - .25f);

            animator.SetBool("Reloading", false);

            yield return new WaitForSeconds(.25f);

            currentAmmo = maxAmmo;
            isRealoading = false;
        }
    }
    public void Shoot ()
       {
            muzzleFlash.Play();

            currentAmmo--;

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











