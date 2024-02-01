
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform firePoint;
   
    public float grenadeSpeed = 10f;

    float grenadeDelay = 2f;
    float grenadeTimer;
    private void Start()
    {
        grenadeTimer = grenadeDelay;
    }
    // Update is called once per frame
    void Update()
    {
        grenadeTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.G) && !GameManager.instance.paused && grenadeTimer >= grenadeDelay)
        {
            ThrowGrenade();
            grenadeTimer = 0;
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);

        FindObjectOfType<AudioManager>().Play("PinPullGrenade");
    }
}
