
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.paused)
        {
            Shoot();
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
