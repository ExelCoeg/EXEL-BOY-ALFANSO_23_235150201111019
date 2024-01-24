
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    [SerializeField]
    float disappearTime;
    void Update()
    {
        Destroy(gameObject, disappearTime);
    }

}
