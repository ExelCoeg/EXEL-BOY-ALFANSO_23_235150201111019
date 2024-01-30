using System.Collections;
using UnityEngine;

public class rocketTargetBehaviour : MonoBehaviour
{
    float rocketTargetRadius = 0.25f;
    float fadeOutTime = 2f;
    private void Start()
    {
        StartCoroutine(FadeInAndExplode(GetComponent<SpriteRenderer>()));
    }
    IEnumerator FadeInAndExplode(SpriteRenderer sr)
    {
        WaitForSeconds waitAfterFadeIn = new WaitForSeconds(1f);
        Color tmpColor = sr.color;
        while (tmpColor.a < 1f)
        {
            tmpColor.a += Time.deltaTime / fadeOutTime;
            sr.color = tmpColor;
            if(tmpColor.a >= 1f)
            {
                tmpColor.a = 1f;
            }
            yield return null;
        }
        sr.color = tmpColor;
        yield return waitAfterFadeIn;
        Explode();
        yield return null;
    }
    public void Explode()
    {
        //Explode Particle
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, rocketTargetRadius);
        foreach(Collider2D hit in hits)
        {
            if(hit.name == "Player")
            {
                hit.gameObject.GetComponent<PlayerHealth>().currentHealth -= 3;
            }
            
        }
        Destroy(gameObject);
    }
}
