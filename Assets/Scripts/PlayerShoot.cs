using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    PlayerController player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        print(player.Angle());
        float horizontalDirection = player.sr.flipX == false ? 1 : -1;
        float verticalDirection = player.VerticalDirection() ? 1 : -1;
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, new Quaternion(0,0,player.Angle(),0));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(bulletSpeed * horizontalDirection * player.isHorizontal(), bulletSpeed * verticalDirection * player.isVertical());
    }
}
