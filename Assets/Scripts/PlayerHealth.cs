
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int numOfHealth;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Image[] hearts;
 


    // Update is called once per frame
    void Update()
    {
        if(currentHealth > numOfHealth)
        {
            currentHealth = numOfHealth;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if(currentHealth <= 0)
        {
            GameManager.instance.playerDead = true;           
            Destroy(gameObject);
        }
    }
    
}
