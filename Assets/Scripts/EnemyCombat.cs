using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float timer;

    float attackDelay = 1f;
    float attackRange = 0.25f;
    public Transform attackPoint;

    public LayerMask playerLayers;


    private void Update()
    {
        if(timer >= attackDelay)
        {
            Attack();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void Attack()
    {
        Collider2D hitEnemies = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayers);

        if (hitEnemies == null)
        {
            print("is not colliding player");
        }
        else if(hitEnemies.name == "Player")
        {
            print("attack");
            if(gameObject.tag == "MiniBoss" ) {
                hitEnemies.GetComponent<PlayerHealth>().currentHealth -= 2;
            }
            else
            {
                hitEnemies.GetComponent<PlayerHealth>().currentHealth--;
            }
        }
        
    }
}
