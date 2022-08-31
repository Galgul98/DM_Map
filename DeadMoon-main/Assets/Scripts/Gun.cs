using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{
    Transform cam;

    [Header("General Stats")]

    [SerializeField] float range = 50f; 
    [SerializeField] float fireRate = 5f;

    public int damage = 10;
    [SerializeField] int maxAmmo;
    [SerializeField] int extraBullets = 120;

    int currentAmmo;
    [SerializeField] float reloadTime;
    WaitForSeconds reloadWait;

    public ParticleSystem muzzleFlash;
    public Text magazineSizeText;
    public Text maxAmmoText;
    AudioSource shootingSound;
   
    [Header("Rapid Fire")]
    WaitForSeconds rapidFireWait;
    [SerializeField] bool rapidFire = false;

    [Header("Shotgun")]
    [SerializeField] private bool shotgun = false;
    [SerializeField] private int bulletsPerShot = 6;




    private void Awake()
    {
        shootingSound = GetComponent<AudioSource>();
        cam = Camera.main.transform;
        rapidFireWait = new WaitForSeconds(0.5f / fireRate);
        reloadWait = new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        
    }
    private void Update()
    {
        magazineSizeText.text = currentAmmo.ToString();
        maxAmmoText.text = extraBullets.ToString();
    }

    public void Shoot()
    {
        currentAmmo--; //currentAmmo = currentAmmo -1

        if(shotgun)
        {
            for (int i = 0; i < bulletsPerShot; i++)
            {
               RaycastHit hit;
               muzzleFlash.Play();
               shootingSound.Play();
        
              if (Physics.Raycast(cam.position, cam.forward, out hit, range))
              {
                if (hit.collider.GetComponent<Damageable>() != null)
                {
                  hit.collider.GetComponent<Damageable>().TakeDamage(damage, hit.point, hit.normal);
                }
                
              }

            }
        }
        else
        {
            RaycastHit hit;
            muzzleFlash.Play();
            shootingSound.Play();

            if (Physics.Raycast(cam.position, cam.forward, out hit, range))
            {
                if (hit.collider.GetComponent<Damageable>() != null)
                {
                    hit.collider.GetComponent<Damageable>().TakeDamage(damage, hit.point, hit.normal);
                }

            }
        }
                
    }
       

    
    public IEnumerator RapidFire()
    {
        if (CanShoot())
        {
            Shoot();
            if (rapidFire)
            {
                while (CanShoot())
                {
                    yield return rapidFireWait;
                    Shoot();
                }
                StartCoroutine(Reload());
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
       
    }

    IEnumerator Reload()
    {
        if(currentAmmo <= 0 && extraBullets >= 1)
        {
            yield return null;
        }

        

        print("reloading...");
        yield return reloadWait;
        currentAmmo = maxAmmo;
        extraBullets -= 30;
        print("finished reloading.");
    }

   

    bool CanShoot()
    {
        bool enoughAmmo = currentAmmo > 0;
        return enoughAmmo;
      
        
    }



    
    
    


}
