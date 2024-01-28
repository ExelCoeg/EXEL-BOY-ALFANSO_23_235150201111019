
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    [SerializeField]
    float disappearTime;
    void Update()
    {
        Destroy(gameObject, disappearTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("MiniBoss"))
        {
            Destroy(gameObject);
        }
    }
}
