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

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        if(movement.x < 0 && (movement.y < 0 || movement.y > 0))
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
        else if(movement.x > 0)
        {
            sr.flipX = false;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }


}
