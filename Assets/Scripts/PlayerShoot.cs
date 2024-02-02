
using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Animator anim;
    public GameObject bulletPrefab;
   
    public Transform firePoint;
    //public SpriteRenderer sr;
    public Sprite[] weaponsSprites;

    public float bulletSpeed = 20f;
    string onShotgun_parameter = "onShotgun";

    public bool onShotgun;
    public bool onPistol;

    float timer;
    float shotgunPumpDelay = .75f;
    float shotgunAmmo;
    float maxShotgunAmmo = 4;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
    private void Start()
    {
        shotgunAmmo = maxShotgunAmmo;
        onPistol = true;
    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (onShotgun)
        {
            anim.SetBool("onShotgun", true);
        }
        if (shotgunAmmo <= 0)
        {
            onShotgun = false;
            onPistol = true;
            shotgunAmmo = maxShotgunAmmo;
            anim.SetBool("onShotgun", false);
        }
       
      

        if (!GameManager.instance.paused)
        {
            if (!GetComponent<PlayerMelee>().onMelee)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if(onPistol){ 
                        Shoot();
                    }
                    if (onShotgun && timer >= shotgunPumpDelay && shotgunAmmo > 0)
                    {
                        ShotgunPump();
                        timer = 0;
                    }
                }
            }
        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("Shoot");
    }
    public void ShotgunPump()
    {

        FindObjectOfType<AudioManager>().Play("ShotgunPump");

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        rb2.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        rb3.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

        FindObjectOfType<AudioManager>().Play("ShotgunCocking");




        shotgunAmmo--;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shotgun") && !onShotgun)
        {
            onShotgun = true;
            onPistol = false;
            Destroy(collision.gameObject);
        }
    }


}
