using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    Vector2 movement;
    public Transform spawnPoint;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMove();
    }
    public int isVertical()
    {
        float vertical = Input.GetAxis("Vertical");
        return vertical != 0 ? 1 : 0;
    }
    public int isHorizontal()
    {
        float horizontal = Input.GetAxis("Horizontal");
        return horizontal != 0 ? 1 : 0;
    }
    public bool VerticalDirection()
    {
        bool verticalDirection = false;
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            verticalDirection = true;
        }
        return verticalDirection;
    }
    public void PlayerMove()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.x < 0 && movement.y < 0) {

            sr.flipX = true;
        }
        else if (movement.x < 0 && movement.y > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        if (movement.x < 0)
        {
            sr.flipX = true;
        }
        else if (movement.x > 0)
        {
            sr.flipX = false;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

    }
    public float Angle()
    {
        float angle = 0;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0 && vertical > 0)
        {
            angle = 45;
        }
        if (horizontal > 0 && vertical < 0)
        {
            angle = 135;
        }
        if (horizontal < 0 && vertical < 0)
        {
            angle = -135;
        }
        if (horizontal < 0 && vertical > 0)
        {
            angle = -45;
        }
        if ((horizontal > 0|| horizontal < 0) && vertical == 0)
        {
            angle = 180;
        }
        if (horizontal == 0 && (vertical > 0 || vertical <0) )
        {
            angle = 90;
        }

        return angle;
    }   
   
}
