using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float distance;
    public float speed;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime) ;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }
}
