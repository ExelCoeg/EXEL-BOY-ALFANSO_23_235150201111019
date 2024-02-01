
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{

    public Animator anim;
    public Transform meleePoint;

    float timer;
    [SerializeField]
    float meleeDelay = 0.5f;
    [SerializeField]
    float meleeRadius = 0.5f;

    public bool onMelee = false;
    // Update is called once per frame
    private void Start()
    {
        timer = meleeDelay;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (!GameManager.instance.paused)
        {
            if(timer >= meleeDelay)
            {
                if (Input.GetKeyDown(KeyCode.V))
                {
                    onMelee = true;
                    timer = 0;
                    Melee();
                }
            }
        }
    }
    void Melee()
    {
        Collider2D check = Physics2D.OverlapCircle(meleePoint.position, meleeRadius);
        if(check == null) {
            FindObjectOfType<AudioManager>().Play("SwordSlash");
        }
        else
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(meleePoint.position, meleeRadius);
            foreach (Collider2D hit in hits)
            {
                if (hit.tag == "Enemy" || hit.tag == "MiniBoss" || hit.tag == "Boss")
                {
                    hit.gameObject.GetComponent<EnemyHealth>().currentHealth -= 2;
                    FindObjectOfType<AudioManager>().Play("SwordImpact");
                    hit.gameObject.GetComponent<Animator>().SetTrigger("hurt");
                }
            }
        }
        anim.SetTrigger("melee");
        onMelee = false;
    }
}
