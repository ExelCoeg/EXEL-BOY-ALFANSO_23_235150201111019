using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    public float grenadeTimeToExplode = 0.5f;
    public float explodeRadius = 1.25f;
    private float grenadeTimer;
    bool grenadeStop = false;
    public float grenadeSpeed;

    public Animator anim;
    public Camera cam;
    Vector2 mousePos;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void Update()
    {
        
    Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.75f);
        if (hit.tag == "Boss" || hit.tag == "Enemy" || hit.tag == "MiniBoss")
        {
            grenadeStop = true;
        }
        if (grenadeStop)
        {
            transform.position = transform.position;
            grenadeTimer += Time.deltaTime;
            if(grenadeTimer >= grenadeTimeToExplode)
            {
                Explode();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePos, grenadeSpeed * Time.deltaTime);
        }
        if (transform.position == new Vector3(mousePos.x, mousePos.y, 0))
        {
            Explode();
        }

    }
    void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explodeRadius);
        foreach(Collider2D hit in hits)
        {
            if(hit.tag == "Enemy" || hit.tag == "MiniBoss" || hit.tag == "Boss")
            {
                hit.gameObject.GetComponent<EnemyHealth>().currentHealth -= 6;
                hit.gameObject.GetComponent<Animator>().SetTrigger("hurt");

            }
        }
        anim.SetTrigger("explode");
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }
}
