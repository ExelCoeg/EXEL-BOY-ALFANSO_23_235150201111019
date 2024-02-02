
using UnityEngine;

public class LootPrefabDisappear : MonoBehaviour
{
    float timer;
    public float disappearTime = 2f;

   
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= disappearTime)
        {
            Destroy(gameObject);
        }
    }
    
}
