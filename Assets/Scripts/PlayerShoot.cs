
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
   
    void Update()
    {
        if (!GameManager.instance.paused)
        {
            if (!GetComponent<PlayerMelee>().onMelee)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    print("player is shooting");
                    Shoot();
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

   
}
