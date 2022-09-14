using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{
    Transform cam;
    private PlayerInput palyerInput;

    [Header("General Stats")]

    [SerializeField] float range = 50f; 
    [SerializeField] float fireRate = 5f;

    public int damage = 10;
    
    [Header("Ammo Stats")]
     public int currentAmmo = 30;
    public int maxAmmo;
    public int extraMags = 3;
    [SerializeField] float reloadTime;
    WaitForSeconds reloadWait;
    private int magazineTamp;
    private bool isReloading = false;

    public ParticleSystem muzzleFlash;
    public Text magazineSizeText;
    public Text maxAmmoText;
    AudioSource shootingSound;
    [SerializeField] private float inaccuracyDistance;
   
    [Header("Rapid Fire")]
    WaitForSeconds rapidFireWait;
    [SerializeField] bool rapidFire = false;

   // [Header("Recoil")]
    //public ProceduralRecoil recoil;

    [Header("Shotgun")]
    [SerializeField] private bool shotgun = false;
    [SerializeField] private int bulletsPerShot = 6;




    private void Awake()
    {
        shootingSound = GetComponent<AudioSource>();
        cam = Camera.main.transform;
        rapidFireWait = new WaitForSeconds(0.5f / fireRate);
        reloadWait = new WaitForSeconds(reloadTime);
        maxAmmo = currentAmmo * extraMags;
        magazineTamp = currentAmmo;
        
    }
    private void Update()
    {
        magazineSizeText.text = currentAmmo.ToString();
        maxAmmoText.text = maxAmmo.ToString();
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
        
              if (Physics.Raycast(cam.position, GetShootingDirection(), out hit, range))
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

            if (Physics.Raycast(cam.position, GetShootingDirection(), out hit, range))
            {
                if (hit.collider.GetComponent<Damageable>() != null)
                {
                    hit.collider.GetComponent<Damageable>().TakeDamage(damage, hit.point, hit.normal);

                }

                //recoil.Recoil();

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

     public IEnumerator Reload()
    {
        if(currentAmmo <= 0 && maxAmmo > 0 )
        {
            print("reloading...");
            isReloading = true;
            yield return reloadWait;
           maxAmmo = maxAmmo - 30 + currentAmmo;
           currentAmmo = magazineTamp;
            print("finished reloading.");
            
        }
        if(maxAmmo < 0)
        {
            currentAmmo += maxAmmo;
            maxAmmo = 0;
        }
        yield return null;



    }

   

    bool CanShoot()
    {
        bool enoughAmmo = currentAmmo > 0;
        return enoughAmmo;
      
        
    }

    Vector3 GetShootingDirection()
    {
        Vector3 targetPos = cam.position + cam.forward * range;
        targetPos = new Vector3(
            targetPos.x + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetPos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetPos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance));

        Vector3 direction = targetPos - cam.position;
        return direction.normalized;
    }


    
    
    


}
