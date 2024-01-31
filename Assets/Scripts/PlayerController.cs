
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Animator anim;
    public Rigidbody2D rb;
    public Camera cam;
    public Transform spawnPoint;
    Vector2 mousePos;

    private void Update()
    {
       
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    
      
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        rb.position += new Vector2(movementSpeed * horizontal * Time.fixedDeltaTime, movementSpeed * vertical *  Time.fixedDeltaTime);
        
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        
    }
    
   
}
